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
namespace GeneXus.Programs.reloj_interface {
   public class reloj : GXDataArea
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
            if ( ( StringUtil.StrCmp(StringUtil.Right( GXDecQS, 6), Crypto.CheckSum( StringUtil.Left( GXDecQS, (short)(StringUtil.Len( GXDecQS)-6)), 6)) == 0 ) && ( StringUtil.StrCmp(StringUtil.Substring( GXDecQS, 1, StringUtil.Len( "reloj_interface.reloj.aspx")), "reloj_interface.reloj.aspx") == 0 ) )
            {
               SetQueryString( StringUtil.Right( StringUtil.Left( GXDecQS, (short)(StringUtil.Len( GXDecQS)-6)), (short)(StringUtil.Len( StringUtil.Left( GXDecQS, (short)(StringUtil.Len( GXDecQS)-6)))-StringUtil.Len( "reloj_interface.reloj.aspx")))) ;
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
                  AV7RelojID = (short)(NumberUtil.Val( GetPar( "RelojID"), "."));
                  AssignAttri("", false, "AV7RelojID", StringUtil.LTrimStr( (decimal)(AV7RelojID), 4, 0));
                  GxWebStd.gx_hidden_field( context, "gxhash_vRELOJID", GetSecureSignedToken( "", context.localUtil.Format( (decimal)(AV7RelojID), "ZZZ9"), context));
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
            Form.Meta.addItem("description", "Reloj", 0) ;
         }
         context.wjLoc = "";
         context.nUserReturn = 0;
         context.wbHandled = 0;
         if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
         {
         }
         if ( ! context.isAjaxRequest( ) )
         {
            GX_FocusControl = edtRelojID_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         wbErr = false;
         context.SetDefaultTheme("WorkWithPlusTheme");
         if ( ! context.IsLocalStorageSupported( ) )
         {
            context.PushCurrentUrl();
         }
      }

      public reloj( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDataStore2 = context.GetDataStore("DataStore2");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusTheme");
      }

      public reloj( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsDataStore2 = context.GetDataStore("DataStore2");
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( string aP0_Gx_mode ,
                           short aP1_RelojID )
      {
         this.Gx_mode = aP0_Gx_mode;
         this.AV7RelojID = aP1_RelojID;
         executePrivate();
      }

      void executePrivate( )
      {
         isStatic = false;
         webExecute();
      }

      protected override void createObjects( )
      {
         cmbReloj_Estado = new GXCombobox();
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
         if ( cmbReloj_Estado.ItemCount > 0 )
         {
            A2429Reloj_Estado = (short)(NumberUtil.Val( cmbReloj_Estado.getValidValue(StringUtil.Trim( StringUtil.Str( (decimal)(A2429Reloj_Estado), 1, 0))), "."));
            AssignAttri("", false, "A2429Reloj_Estado", StringUtil.Str( (decimal)(A2429Reloj_Estado), 1, 0));
         }
         if ( context.isAjaxRequest( ) )
         {
            cmbReloj_Estado.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(A2429Reloj_Estado), 1, 0));
            AssignProp("", false, cmbReloj_Estado_Internalname, "Values", cmbReloj_Estado.ToJavascriptSource(), true);
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
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
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
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 DataContentCell", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtRelojID_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtRelojID_Internalname, "Código", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 22,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtRelojID_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A2430RelojID), 4, 0, ".", "")), StringUtil.LTrim( context.localUtil.Format( (decimal)(A2430RelojID), "ZZZ9")), " inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onblur(this,22);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtRelojID_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtRelojID_Enabled, 1, "text", "1", 4, "chr", 1, "row", 4, 0, 0, 0, 1, -1, 0, true, "", "right", false, "", "HLP_Reloj_Interface\\Reloj.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 DataContentCell", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtReloj_Nom_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtReloj_Nom_Internalname, "Reloj", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 27,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtReloj_Nom_Internalname, A2425Reloj_Nom, StringUtil.RTrim( context.localUtil.Format( A2425Reloj_Nom, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,27);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtReloj_Nom_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtReloj_Nom_Enabled, 0, "text", "", 50, "chr", 1, "row", 50, 0, 0, 0, 1, -1, -1, true, "", "left", true, "", "HLP_Reloj_Interface\\Reloj.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 DataContentCell", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtReloj_Dsc_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtReloj_Dsc_Internalname, "Descripción", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 32,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtReloj_Dsc_Internalname, A2426Reloj_Dsc, StringUtil.RTrim( context.localUtil.Format( A2426Reloj_Dsc, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,32);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtReloj_Dsc_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtReloj_Dsc_Enabled, 0, "text", "", 80, "chr", 1, "row", 100, 0, 0, 0, 1, -1, -1, true, "", "left", true, "", "HLP_Reloj_Interface\\Reloj.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 DataContentCell", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtReloj_IP_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtReloj_IP_Internalname, "IP Reloj", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 37,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtReloj_IP_Internalname, A2427Reloj_IP, StringUtil.RTrim( context.localUtil.Format( A2427Reloj_IP, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,37);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtReloj_IP_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtReloj_IP_Enabled, 0, "text", "", 50, "chr", 1, "row", 50, 0, 0, 0, 1, -1, -1, true, "", "left", true, "", "HLP_Reloj_Interface\\Reloj.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 DataContentCell", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtReloj_Puerto_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtReloj_Puerto_Internalname, "Puerto Reloj", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 42,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtReloj_Puerto_Internalname, A2428Reloj_Puerto, StringUtil.RTrim( context.localUtil.Format( A2428Reloj_Puerto, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,42);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtReloj_Puerto_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtReloj_Puerto_Enabled, 0, "text", "", 50, "chr", 1, "row", 50, 0, 0, 0, 1, -1, -1, true, "", "left", true, "", "HLP_Reloj_Interface\\Reloj.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 DataContentCell", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+cmbReloj_Estado_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, cmbReloj_Estado_Internalname, "Estado", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 47,'',false,'',0)\"";
         /* ComboBox */
         GxWebStd.gx_combobox_ctrl1( context, cmbReloj_Estado, cmbReloj_Estado_Internalname, StringUtil.Trim( StringUtil.Str( (decimal)(A2429Reloj_Estado), 1, 0)), 1, cmbReloj_Estado_Jsonclick, 0, "'"+""+"'"+",false,"+"'"+""+"'", "int", "", 1, cmbReloj_Estado.Enabled, 0, 0, 0, "em", 0, "", "", "Attribute", "", "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,47);\"", "", true, 1, "HLP_Reloj_Interface\\Reloj.htm");
         cmbReloj_Estado.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(A2429Reloj_Estado), 1, 0));
         AssignProp("", false, cmbReloj_Estado_Internalname, "Values", (string)(cmbReloj_Estado.ToJavascriptSource()), true);
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
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 52,'',false,'',0)\"";
         ClassString = "ButtonMaterial";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtntrn_enter_Internalname, "", "Confirmar", bttBtntrn_enter_Jsonclick, 5, "Confirmar", "", StyleString, ClassString, bttBtntrn_enter_Visible, bttBtntrn_enter_Enabled, "standard", "'"+""+"'"+",false,"+"'"+"EENTER."+"'", TempTags, "", context.GetButtonType( ), "HLP_Reloj_Interface\\Reloj.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "left", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 54,'',false,'',0)\"";
         ClassString = "ButtonMaterialDefault";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtntrn_cancel_Internalname, "", "Cancelar", bttBtntrn_cancel_Jsonclick, 1, "Cancelar", "", StyleString, ClassString, bttBtntrn_cancel_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"ECANCEL."+"'", TempTags, "", context.GetButtonType( ), "HLP_Reloj_Interface\\Reloj.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "left", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 56,'',false,'',0)\"";
         ClassString = "ButtonMaterialDefault";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtntrn_delete_Internalname, "", "Eliminar", bttBtntrn_delete_Jsonclick, 5, "Eliminar", "", StyleString, ClassString, bttBtntrn_delete_Visible, bttBtntrn_delete_Enabled, "standard", "'"+""+"'"+",false,"+"'"+"EDELETE."+"'", TempTags, "", context.GetButtonType( ), "HLP_Reloj_Interface\\Reloj.htm");
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
         E117S2 ();
         context.wbGlbDoneStart = 1;
         assign_properties_default( ) ;
         if ( AnyError == 0 )
         {
            if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
            {
               /* Read saved SDTs. */
               /* Read saved values. */
               Z2430RelojID = (short)(context.localUtil.CToN( cgiGet( "Z2430RelojID"), ".", ","));
               Z2425Reloj_Nom = cgiGet( "Z2425Reloj_Nom");
               Z2426Reloj_Dsc = cgiGet( "Z2426Reloj_Dsc");
               Z2427Reloj_IP = cgiGet( "Z2427Reloj_IP");
               Z2428Reloj_Puerto = cgiGet( "Z2428Reloj_Puerto");
               Z2429Reloj_Estado = (short)(context.localUtil.CToN( cgiGet( "Z2429Reloj_Estado"), ".", ","));
               IsConfirmed = (short)(context.localUtil.CToN( cgiGet( "IsConfirmed"), ".", ","));
               IsModified = (short)(context.localUtil.CToN( cgiGet( "IsModified"), ".", ","));
               Gx_mode = cgiGet( "Mode");
               AV7RelojID = (short)(context.localUtil.CToN( cgiGet( "vRELOJID"), ".", ","));
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
               if ( ( ( context.localUtil.CToN( cgiGet( edtRelojID_Internalname), ".", ",") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtRelojID_Internalname), ".", ",") > Convert.ToDecimal( 9999 )) ) )
               {
                  GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "RELOJID");
                  AnyError = 1;
                  GX_FocusControl = edtRelojID_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  wbErr = true;
                  A2430RelojID = 0;
                  AssignAttri("", false, "A2430RelojID", StringUtil.LTrimStr( (decimal)(A2430RelojID), 4, 0));
               }
               else
               {
                  A2430RelojID = (short)(context.localUtil.CToN( cgiGet( edtRelojID_Internalname), ".", ","));
                  AssignAttri("", false, "A2430RelojID", StringUtil.LTrimStr( (decimal)(A2430RelojID), 4, 0));
               }
               A2425Reloj_Nom = cgiGet( edtReloj_Nom_Internalname);
               AssignAttri("", false, "A2425Reloj_Nom", A2425Reloj_Nom);
               A2426Reloj_Dsc = cgiGet( edtReloj_Dsc_Internalname);
               AssignAttri("", false, "A2426Reloj_Dsc", A2426Reloj_Dsc);
               A2427Reloj_IP = cgiGet( edtReloj_IP_Internalname);
               AssignAttri("", false, "A2427Reloj_IP", A2427Reloj_IP);
               A2428Reloj_Puerto = cgiGet( edtReloj_Puerto_Internalname);
               AssignAttri("", false, "A2428Reloj_Puerto", A2428Reloj_Puerto);
               cmbReloj_Estado.CurrentValue = cgiGet( cmbReloj_Estado_Internalname);
               A2429Reloj_Estado = (short)(NumberUtil.Val( cgiGet( cmbReloj_Estado_Internalname), "."));
               AssignAttri("", false, "A2429Reloj_Estado", StringUtil.Str( (decimal)(A2429Reloj_Estado), 1, 0));
               /* Read subfile selected row values. */
               /* Read hidden variables. */
               GXKey = Crypto.GetSiteKey( );
               forbiddenHiddens = new GXProperties();
               forbiddenHiddens.Add("hshsalt", "hsh"+"Reloj");
               forbiddenHiddens.Add("Gx_mode", StringUtil.RTrim( context.localUtil.Format( Gx_mode, "@!")));
               hsh = cgiGet( "hsh");
               if ( ( ! ( ( A2430RelojID != Z2430RelojID ) ) || ( StringUtil.StrCmp(Gx_mode, "INS") == 0 ) ) && ! GXUtil.CheckEncryptedHash( forbiddenHiddens.ToString(), hsh, GXKey) )
               {
                  GXUtil.WriteLogError("reloj_interface\\reloj:[ SecurityCheckFailed (403 Forbidden) value for]"+forbiddenHiddens.ToJSonString());
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
                  A2430RelojID = (short)(NumberUtil.Val( GetPar( "RelojID"), "."));
                  AssignAttri("", false, "A2430RelojID", StringUtil.LTrimStr( (decimal)(A2430RelojID), 4, 0));
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
                     sMode212 = Gx_mode;
                     Gx_mode = "UPD";
                     AssignAttri("", false, "Gx_mode", Gx_mode);
                     Gx_mode = sMode212;
                     AssignAttri("", false, "Gx_mode", Gx_mode);
                  }
                  standaloneModal( ) ;
                  if ( ! IsIns( ) )
                  {
                     getByPrimaryKey( ) ;
                     if ( RcdFound212 == 1 )
                     {
                        if ( IsDlt( ) )
                        {
                           /* Confirm record */
                           CONFIRM_7S0( ) ;
                           if ( AnyError == 0 )
                           {
                              GX_FocusControl = bttBtntrn_enter_Internalname;
                              AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                           }
                        }
                     }
                     else
                     {
                        GX_msglist.addItem(context.GetMessage( "GXM_noinsert", ""), 1, "RELOJID");
                        AnyError = 1;
                        GX_FocusControl = edtRelojID_Internalname;
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
                           E117S2 ();
                        }
                        else if ( StringUtil.StrCmp(sEvt, "AFTER TRN") == 0 )
                        {
                           context.wbHandled = 1;
                           dynload_actions( ) ;
                           /* Execute user event: After Trn */
                           E127S2 ();
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
            E127S2 ();
            trnEnded = 0;
            standaloneNotModal( ) ;
            standaloneModal( ) ;
            if ( IsIns( )  )
            {
               /* Clear variables for new insertion. */
               InitAll7S212( ) ;
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
            DisableAttributes7S212( ) ;
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

      protected void CONFIRM_7S0( )
      {
         BeforeValidate7S212( ) ;
         if ( AnyError == 0 )
         {
            if ( IsDlt( ) )
            {
               OnDeleteControls7S212( ) ;
            }
            else
            {
               CheckExtendedTable7S212( ) ;
               CloseExtendedTableCursors7S212( ) ;
            }
         }
         if ( AnyError == 0 )
         {
            IsConfirmed = 1;
            AssignAttri("", false, "IsConfirmed", StringUtil.LTrimStr( (decimal)(IsConfirmed), 4, 0));
         }
      }

      protected void ResetCaption7S0( )
      {
      }

      protected void E117S2( )
      {
         /* Start Routine */
         returnInSub = false;
         divLayoutmaintable_Class = divLayoutmaintable_Class+" "+"EditForm";
         AssignProp("", false, divLayoutmaintable_Internalname, "Class", divLayoutmaintable_Class, true);
         new GeneXus.Programs.wwpbaseobjects.loadwwpcontext(context ).execute( out  AV8WWPContext) ;
         AV9TrnContext.FromXml(AV10WebSession.Get("TrnContext"), null, "", "");
      }

      protected void E127S2( )
      {
         /* After Trn Routine */
         returnInSub = false;
         if ( ( StringUtil.StrCmp(Gx_mode, "DLT") == 0 ) && ! AV9TrnContext.gxTpr_Callerondelete )
         {
            CallWebObject(formatLink("reloj_interface.relojww.aspx") );
            context.wjLocDisableFrm = 1;
         }
         context.setWebReturnParms(new Object[] {});
         context.setWebReturnParmsMetadata(new Object[] {});
         context.wjLocDisableFrm = 1;
         context.nUserReturn = 1;
         returnInSub = true;
         if (true) return;
      }

      protected void ZM7S212( short GX_JID )
      {
         if ( ( GX_JID == 4 ) || ( GX_JID == 0 ) )
         {
            if ( ! IsIns( ) )
            {
               Z2425Reloj_Nom = T007S3_A2425Reloj_Nom[0];
               Z2426Reloj_Dsc = T007S3_A2426Reloj_Dsc[0];
               Z2427Reloj_IP = T007S3_A2427Reloj_IP[0];
               Z2428Reloj_Puerto = T007S3_A2428Reloj_Puerto[0];
               Z2429Reloj_Estado = T007S3_A2429Reloj_Estado[0];
            }
            else
            {
               Z2425Reloj_Nom = A2425Reloj_Nom;
               Z2426Reloj_Dsc = A2426Reloj_Dsc;
               Z2427Reloj_IP = A2427Reloj_IP;
               Z2428Reloj_Puerto = A2428Reloj_Puerto;
               Z2429Reloj_Estado = A2429Reloj_Estado;
            }
         }
         if ( GX_JID == -4 )
         {
            Z2430RelojID = A2430RelojID;
            Z2425Reloj_Nom = A2425Reloj_Nom;
            Z2426Reloj_Dsc = A2426Reloj_Dsc;
            Z2427Reloj_IP = A2427Reloj_IP;
            Z2428Reloj_Puerto = A2428Reloj_Puerto;
            Z2429Reloj_Estado = A2429Reloj_Estado;
         }
      }

      protected void standaloneNotModal( )
      {
         bttBtntrn_delete_Enabled = 0;
         AssignProp("", false, bttBtntrn_delete_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(bttBtntrn_delete_Enabled), 5, 0), true);
         if ( ! (0==AV7RelojID) )
         {
            A2430RelojID = AV7RelojID;
            AssignAttri("", false, "A2430RelojID", StringUtil.LTrimStr( (decimal)(A2430RelojID), 4, 0));
         }
         if ( ! (0==AV7RelojID) )
         {
            edtRelojID_Enabled = 0;
            AssignProp("", false, edtRelojID_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtRelojID_Enabled), 5, 0), true);
         }
         else
         {
            edtRelojID_Enabled = 1;
            AssignProp("", false, edtRelojID_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtRelojID_Enabled), 5, 0), true);
         }
         if ( ! (0==AV7RelojID) )
         {
            edtRelojID_Enabled = 0;
            AssignProp("", false, edtRelojID_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtRelojID_Enabled), 5, 0), true);
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
      }

      protected void Load7S212( )
      {
         /* Using cursor T007S4 */
         pr_default.execute(2, new Object[] {A2430RelojID});
         if ( (pr_default.getStatus(2) != 101) )
         {
            RcdFound212 = 1;
            A2425Reloj_Nom = T007S4_A2425Reloj_Nom[0];
            AssignAttri("", false, "A2425Reloj_Nom", A2425Reloj_Nom);
            A2426Reloj_Dsc = T007S4_A2426Reloj_Dsc[0];
            AssignAttri("", false, "A2426Reloj_Dsc", A2426Reloj_Dsc);
            A2427Reloj_IP = T007S4_A2427Reloj_IP[0];
            AssignAttri("", false, "A2427Reloj_IP", A2427Reloj_IP);
            A2428Reloj_Puerto = T007S4_A2428Reloj_Puerto[0];
            AssignAttri("", false, "A2428Reloj_Puerto", A2428Reloj_Puerto);
            A2429Reloj_Estado = T007S4_A2429Reloj_Estado[0];
            AssignAttri("", false, "A2429Reloj_Estado", StringUtil.Str( (decimal)(A2429Reloj_Estado), 1, 0));
            ZM7S212( -4) ;
         }
         pr_default.close(2);
         OnLoadActions7S212( ) ;
      }

      protected void OnLoadActions7S212( )
      {
      }

      protected void CheckExtendedTable7S212( )
      {
         nIsDirty_212 = 0;
         Gx_BScreen = 1;
         standaloneModal( ) ;
      }

      protected void CloseExtendedTableCursors7S212( )
      {
      }

      protected void enableDisable( )
      {
      }

      protected void GetKey7S212( )
      {
         /* Using cursor T007S5 */
         pr_default.execute(3, new Object[] {A2430RelojID});
         if ( (pr_default.getStatus(3) != 101) )
         {
            RcdFound212 = 1;
         }
         else
         {
            RcdFound212 = 0;
         }
         pr_default.close(3);
      }

      protected void getByPrimaryKey( )
      {
         /* Using cursor T007S3 */
         pr_default.execute(1, new Object[] {A2430RelojID});
         if ( (pr_default.getStatus(1) != 101) )
         {
            ZM7S212( 4) ;
            RcdFound212 = 1;
            A2430RelojID = T007S3_A2430RelojID[0];
            AssignAttri("", false, "A2430RelojID", StringUtil.LTrimStr( (decimal)(A2430RelojID), 4, 0));
            A2425Reloj_Nom = T007S3_A2425Reloj_Nom[0];
            AssignAttri("", false, "A2425Reloj_Nom", A2425Reloj_Nom);
            A2426Reloj_Dsc = T007S3_A2426Reloj_Dsc[0];
            AssignAttri("", false, "A2426Reloj_Dsc", A2426Reloj_Dsc);
            A2427Reloj_IP = T007S3_A2427Reloj_IP[0];
            AssignAttri("", false, "A2427Reloj_IP", A2427Reloj_IP);
            A2428Reloj_Puerto = T007S3_A2428Reloj_Puerto[0];
            AssignAttri("", false, "A2428Reloj_Puerto", A2428Reloj_Puerto);
            A2429Reloj_Estado = T007S3_A2429Reloj_Estado[0];
            AssignAttri("", false, "A2429Reloj_Estado", StringUtil.Str( (decimal)(A2429Reloj_Estado), 1, 0));
            Z2430RelojID = A2430RelojID;
            sMode212 = Gx_mode;
            Gx_mode = "DSP";
            AssignAttri("", false, "Gx_mode", Gx_mode);
            Load7S212( ) ;
            if ( AnyError == 1 )
            {
               RcdFound212 = 0;
               InitializeNonKey7S212( ) ;
            }
            Gx_mode = sMode212;
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         else
         {
            RcdFound212 = 0;
            InitializeNonKey7S212( ) ;
            sMode212 = Gx_mode;
            Gx_mode = "DSP";
            AssignAttri("", false, "Gx_mode", Gx_mode);
            standaloneModal( ) ;
            Gx_mode = sMode212;
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         pr_default.close(1);
      }

      protected void getEqualNoModal( )
      {
         GetKey7S212( ) ;
         if ( RcdFound212 == 0 )
         {
         }
         else
         {
         }
         getByPrimaryKey( ) ;
      }

      protected void move_next( )
      {
         RcdFound212 = 0;
         /* Using cursor T007S6 */
         pr_default.execute(4, new Object[] {A2430RelojID});
         if ( (pr_default.getStatus(4) != 101) )
         {
            while ( (pr_default.getStatus(4) != 101) && ( ( T007S6_A2430RelojID[0] < A2430RelojID ) ) )
            {
               pr_default.readNext(4);
            }
            if ( (pr_default.getStatus(4) != 101) && ( ( T007S6_A2430RelojID[0] > A2430RelojID ) ) )
            {
               A2430RelojID = T007S6_A2430RelojID[0];
               AssignAttri("", false, "A2430RelojID", StringUtil.LTrimStr( (decimal)(A2430RelojID), 4, 0));
               RcdFound212 = 1;
            }
         }
         pr_default.close(4);
      }

      protected void move_previous( )
      {
         RcdFound212 = 0;
         /* Using cursor T007S7 */
         pr_default.execute(5, new Object[] {A2430RelojID});
         if ( (pr_default.getStatus(5) != 101) )
         {
            while ( (pr_default.getStatus(5) != 101) && ( ( T007S7_A2430RelojID[0] > A2430RelojID ) ) )
            {
               pr_default.readNext(5);
            }
            if ( (pr_default.getStatus(5) != 101) && ( ( T007S7_A2430RelojID[0] < A2430RelojID ) ) )
            {
               A2430RelojID = T007S7_A2430RelojID[0];
               AssignAttri("", false, "A2430RelojID", StringUtil.LTrimStr( (decimal)(A2430RelojID), 4, 0));
               RcdFound212 = 1;
            }
         }
         pr_default.close(5);
      }

      protected void btn_enter( )
      {
         nKeyPressed = 1;
         GetKey7S212( ) ;
         if ( IsIns( ) )
         {
            /* Insert record */
            GX_FocusControl = edtRelojID_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            Insert7S212( ) ;
            if ( AnyError == 1 )
            {
               GX_FocusControl = "";
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            }
         }
         else
         {
            if ( RcdFound212 == 1 )
            {
               if ( A2430RelojID != Z2430RelojID )
               {
                  A2430RelojID = Z2430RelojID;
                  AssignAttri("", false, "A2430RelojID", StringUtil.LTrimStr( (decimal)(A2430RelojID), 4, 0));
                  GX_msglist.addItem(context.GetMessage( "GXM_getbeforeupd", ""), "CandidateKeyNotFound", 1, "RELOJID");
                  AnyError = 1;
                  GX_FocusControl = edtRelojID_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               }
               else if ( IsDlt( ) )
               {
                  delete( ) ;
                  AfterTrn( ) ;
                  GX_FocusControl = edtRelojID_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               }
               else
               {
                  /* Update record */
                  Update7S212( ) ;
                  GX_FocusControl = edtRelojID_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               }
            }
            else
            {
               if ( A2430RelojID != Z2430RelojID )
               {
                  /* Insert record */
                  GX_FocusControl = edtRelojID_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  Insert7S212( ) ;
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
                     GX_msglist.addItem(context.GetMessage( "GXM_recdeleted", ""), 1, "RELOJID");
                     AnyError = 1;
                     GX_FocusControl = edtRelojID_Internalname;
                     AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  }
                  else
                  {
                     /* Insert record */
                     GX_FocusControl = edtRelojID_Internalname;
                     AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                     Insert7S212( ) ;
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
         if ( A2430RelojID != Z2430RelojID )
         {
            A2430RelojID = Z2430RelojID;
            AssignAttri("", false, "A2430RelojID", StringUtil.LTrimStr( (decimal)(A2430RelojID), 4, 0));
            GX_msglist.addItem(context.GetMessage( "GXM_getbeforedlt", ""), 1, "RELOJID");
            AnyError = 1;
            GX_FocusControl = edtRelojID_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         else
         {
            delete( ) ;
            AfterTrn( ) ;
            GX_FocusControl = edtRelojID_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         if ( AnyError != 0 )
         {
         }
      }

      protected void CheckOptimisticConcurrency7S212( )
      {
         if ( ! IsIns( ) )
         {
            /* Using cursor T007S2 */
            pr_default.execute(0, new Object[] {A2430RelojID});
            if ( (pr_default.getStatus(0) == 103) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"Reloj"}), "RecordIsLocked", 1, "");
               AnyError = 1;
               return  ;
            }
            if ( (pr_default.getStatus(0) == 101) || ( StringUtil.StrCmp(Z2425Reloj_Nom, T007S2_A2425Reloj_Nom[0]) != 0 ) || ( StringUtil.StrCmp(Z2426Reloj_Dsc, T007S2_A2426Reloj_Dsc[0]) != 0 ) || ( StringUtil.StrCmp(Z2427Reloj_IP, T007S2_A2427Reloj_IP[0]) != 0 ) || ( StringUtil.StrCmp(Z2428Reloj_Puerto, T007S2_A2428Reloj_Puerto[0]) != 0 ) || ( Z2429Reloj_Estado != T007S2_A2429Reloj_Estado[0] ) )
            {
               if ( StringUtil.StrCmp(Z2425Reloj_Nom, T007S2_A2425Reloj_Nom[0]) != 0 )
               {
                  GXUtil.WriteLog("reloj_interface.reloj:[seudo value changed for attri]"+"Reloj_Nom");
                  GXUtil.WriteLogRaw("Old: ",Z2425Reloj_Nom);
                  GXUtil.WriteLogRaw("Current: ",T007S2_A2425Reloj_Nom[0]);
               }
               if ( StringUtil.StrCmp(Z2426Reloj_Dsc, T007S2_A2426Reloj_Dsc[0]) != 0 )
               {
                  GXUtil.WriteLog("reloj_interface.reloj:[seudo value changed for attri]"+"Reloj_Dsc");
                  GXUtil.WriteLogRaw("Old: ",Z2426Reloj_Dsc);
                  GXUtil.WriteLogRaw("Current: ",T007S2_A2426Reloj_Dsc[0]);
               }
               if ( StringUtil.StrCmp(Z2427Reloj_IP, T007S2_A2427Reloj_IP[0]) != 0 )
               {
                  GXUtil.WriteLog("reloj_interface.reloj:[seudo value changed for attri]"+"Reloj_IP");
                  GXUtil.WriteLogRaw("Old: ",Z2427Reloj_IP);
                  GXUtil.WriteLogRaw("Current: ",T007S2_A2427Reloj_IP[0]);
               }
               if ( StringUtil.StrCmp(Z2428Reloj_Puerto, T007S2_A2428Reloj_Puerto[0]) != 0 )
               {
                  GXUtil.WriteLog("reloj_interface.reloj:[seudo value changed for attri]"+"Reloj_Puerto");
                  GXUtil.WriteLogRaw("Old: ",Z2428Reloj_Puerto);
                  GXUtil.WriteLogRaw("Current: ",T007S2_A2428Reloj_Puerto[0]);
               }
               if ( Z2429Reloj_Estado != T007S2_A2429Reloj_Estado[0] )
               {
                  GXUtil.WriteLog("reloj_interface.reloj:[seudo value changed for attri]"+"Reloj_Estado");
                  GXUtil.WriteLogRaw("Old: ",Z2429Reloj_Estado);
                  GXUtil.WriteLogRaw("Current: ",T007S2_A2429Reloj_Estado[0]);
               }
               GX_msglist.addItem(context.GetMessage( "GXM_waschg", new   object[]  {"Reloj"}), "RecordWasChanged", 1, "");
               AnyError = 1;
               return  ;
            }
         }
      }

      protected void Insert7S212( )
      {
         BeforeValidate7S212( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable7S212( ) ;
         }
         if ( AnyError == 0 )
         {
            ZM7S212( 0) ;
            CheckOptimisticConcurrency7S212( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm7S212( ) ;
               if ( AnyError == 0 )
               {
                  BeforeInsert7S212( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor T007S8 */
                     pr_default.execute(6, new Object[] {A2430RelojID, A2425Reloj_Nom, A2426Reloj_Dsc, A2427Reloj_IP, A2428Reloj_Puerto, A2429Reloj_Estado});
                     pr_default.close(6);
                     dsDefault.SmartCacheProvider.SetUpdated("Reloj");
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
                           ResetCaption7S0( ) ;
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
               Load7S212( ) ;
            }
            EndLevel7S212( ) ;
         }
         CloseExtendedTableCursors7S212( ) ;
      }

      protected void Update7S212( )
      {
         BeforeValidate7S212( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable7S212( ) ;
         }
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency7S212( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm7S212( ) ;
               if ( AnyError == 0 )
               {
                  BeforeUpdate7S212( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor T007S9 */
                     pr_default.execute(7, new Object[] {A2425Reloj_Nom, A2426Reloj_Dsc, A2427Reloj_IP, A2428Reloj_Puerto, A2429Reloj_Estado, A2430RelojID});
                     pr_default.close(7);
                     dsDefault.SmartCacheProvider.SetUpdated("Reloj");
                     if ( (pr_default.getStatus(7) == 103) )
                     {
                        GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"Reloj"}), "RecordIsLocked", 1, "");
                        AnyError = 1;
                     }
                     DeferredUpdate7S212( ) ;
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
            EndLevel7S212( ) ;
         }
         CloseExtendedTableCursors7S212( ) ;
      }

      protected void DeferredUpdate7S212( )
      {
      }

      protected void delete( )
      {
         BeforeValidate7S212( ) ;
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency7S212( ) ;
         }
         if ( AnyError == 0 )
         {
            OnDeleteControls7S212( ) ;
            AfterConfirm7S212( ) ;
            if ( AnyError == 0 )
            {
               BeforeDelete7S212( ) ;
               if ( AnyError == 0 )
               {
                  /* No cascading delete specified. */
                  /* Using cursor T007S10 */
                  pr_default.execute(8, new Object[] {A2430RelojID});
                  pr_default.close(8);
                  dsDefault.SmartCacheProvider.SetUpdated("Reloj");
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
         sMode212 = Gx_mode;
         Gx_mode = "DLT";
         AssignAttri("", false, "Gx_mode", Gx_mode);
         EndLevel7S212( ) ;
         Gx_mode = sMode212;
         AssignAttri("", false, "Gx_mode", Gx_mode);
      }

      protected void OnDeleteControls7S212( )
      {
         standaloneModal( ) ;
         /* No delete mode formulas found. */
      }

      protected void EndLevel7S212( )
      {
         if ( ! IsIns( ) )
         {
            pr_default.close(0);
         }
         if ( AnyError == 0 )
         {
            BeforeComplete7S212( ) ;
         }
         if ( AnyError == 0 )
         {
            pr_default.close(1);
            context.CommitDataStores("reloj_interface.reloj",pr_default);
            if ( AnyError == 0 )
            {
               ConfirmValues7S0( ) ;
            }
            /* After transaction rules */
            /* Execute 'After Trn' event if defined. */
            trnEnded = 1;
         }
         else
         {
            pr_default.close(1);
            context.RollbackDataStores("reloj_interface.reloj",pr_default);
         }
         IsModified = 0;
         if ( AnyError != 0 )
         {
            context.wjLoc = "";
            context.nUserReturn = 0;
         }
      }

      public void ScanStart7S212( )
      {
         /* Scan By routine */
         /* Using cursor T007S11 */
         pr_default.execute(9);
         RcdFound212 = 0;
         if ( (pr_default.getStatus(9) != 101) )
         {
            RcdFound212 = 1;
            A2430RelojID = T007S11_A2430RelojID[0];
            AssignAttri("", false, "A2430RelojID", StringUtil.LTrimStr( (decimal)(A2430RelojID), 4, 0));
         }
         /* Load Subordinate Levels */
      }

      protected void ScanNext7S212( )
      {
         /* Scan next routine */
         pr_default.readNext(9);
         RcdFound212 = 0;
         if ( (pr_default.getStatus(9) != 101) )
         {
            RcdFound212 = 1;
            A2430RelojID = T007S11_A2430RelojID[0];
            AssignAttri("", false, "A2430RelojID", StringUtil.LTrimStr( (decimal)(A2430RelojID), 4, 0));
         }
      }

      protected void ScanEnd7S212( )
      {
         pr_default.close(9);
      }

      protected void AfterConfirm7S212( )
      {
         /* After Confirm Rules */
      }

      protected void BeforeInsert7S212( )
      {
         /* Before Insert Rules */
      }

      protected void BeforeUpdate7S212( )
      {
         /* Before Update Rules */
      }

      protected void BeforeDelete7S212( )
      {
         /* Before Delete Rules */
      }

      protected void BeforeComplete7S212( )
      {
         /* Before Complete Rules */
      }

      protected void BeforeValidate7S212( )
      {
         /* Before Validate Rules */
      }

      protected void DisableAttributes7S212( )
      {
         edtRelojID_Enabled = 0;
         AssignProp("", false, edtRelojID_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtRelojID_Enabled), 5, 0), true);
         edtReloj_Nom_Enabled = 0;
         AssignProp("", false, edtReloj_Nom_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtReloj_Nom_Enabled), 5, 0), true);
         edtReloj_Dsc_Enabled = 0;
         AssignProp("", false, edtReloj_Dsc_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtReloj_Dsc_Enabled), 5, 0), true);
         edtReloj_IP_Enabled = 0;
         AssignProp("", false, edtReloj_IP_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtReloj_IP_Enabled), 5, 0), true);
         edtReloj_Puerto_Enabled = 0;
         AssignProp("", false, edtReloj_Puerto_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtReloj_Puerto_Enabled), 5, 0), true);
         cmbReloj_Estado.Enabled = 0;
         AssignProp("", false, cmbReloj_Estado_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(cmbReloj_Estado.Enabled), 5, 0), true);
      }

      protected void send_integrity_lvl_hashes7S212( )
      {
      }

      protected void assign_properties_default( )
      {
      }

      protected void ConfirmValues7S0( )
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
         context.AddJavascriptSource("gxcfg.js", "?20228181235385", false, true);
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
         GXEncryptionTmp = "reloj_interface.reloj.aspx"+UrlEncode(StringUtil.RTrim(Gx_mode)) + "," + UrlEncode(StringUtil.LTrimStr(AV7RelojID,4,0));
         context.WriteHtmlTextNl( "<form id=\"MAINFORM\" autocomplete=\"off\" name=\"MAINFORM\" method=\"post\" tabindex=-1  class=\"form-horizontal Form\" data-gx-class=\"form-horizontal Form\" novalidate action=\""+formatLink("reloj_interface.reloj.aspx") + "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey)+"\">") ;
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
         forbiddenHiddens.Add("hshsalt", "hsh"+"Reloj");
         forbiddenHiddens.Add("Gx_mode", StringUtil.RTrim( context.localUtil.Format( Gx_mode, "@!")));
         GxWebStd.gx_hidden_field( context, "hsh", GetEncryptedHash( forbiddenHiddens.ToString(), GXKey));
         GXUtil.WriteLogInfo("reloj_interface\\reloj:[ SendSecurityCheck value for]"+forbiddenHiddens.ToJSonString());
      }

      protected void SendCloseFormHiddens( )
      {
         /* Send hidden variables. */
         /* Send saved values. */
         send_integrity_footer_hashes( ) ;
         GxWebStd.gx_hidden_field( context, "Z2430RelojID", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z2430RelojID), 4, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z2425Reloj_Nom", Z2425Reloj_Nom);
         GxWebStd.gx_hidden_field( context, "Z2426Reloj_Dsc", Z2426Reloj_Dsc);
         GxWebStd.gx_hidden_field( context, "Z2427Reloj_IP", Z2427Reloj_IP);
         GxWebStd.gx_hidden_field( context, "Z2428Reloj_Puerto", Z2428Reloj_Puerto);
         GxWebStd.gx_hidden_field( context, "Z2429Reloj_Estado", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z2429Reloj_Estado), 1, 0, ".", "")));
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
         GxWebStd.gx_hidden_field( context, "vRELOJID", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV7RelojID), 4, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "gxhash_vRELOJID", GetSecureSignedToken( "", context.localUtil.Format( (decimal)(AV7RelojID), "ZZZ9"), context));
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
         GXEncryptionTmp = "reloj_interface.reloj.aspx"+UrlEncode(StringUtil.RTrim(Gx_mode)) + "," + UrlEncode(StringUtil.LTrimStr(AV7RelojID,4,0));
         return formatLink("reloj_interface.reloj.aspx") + "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey) ;
      }

      public override string GetPgmname( )
      {
         return "Reloj_Interface.Reloj" ;
      }

      public override string GetPgmdesc( )
      {
         return "Reloj" ;
      }

      protected void InitializeNonKey7S212( )
      {
         A2425Reloj_Nom = "";
         AssignAttri("", false, "A2425Reloj_Nom", A2425Reloj_Nom);
         A2426Reloj_Dsc = "";
         AssignAttri("", false, "A2426Reloj_Dsc", A2426Reloj_Dsc);
         A2427Reloj_IP = "";
         AssignAttri("", false, "A2427Reloj_IP", A2427Reloj_IP);
         A2428Reloj_Puerto = "";
         AssignAttri("", false, "A2428Reloj_Puerto", A2428Reloj_Puerto);
         A2429Reloj_Estado = 0;
         AssignAttri("", false, "A2429Reloj_Estado", StringUtil.Str( (decimal)(A2429Reloj_Estado), 1, 0));
         Z2425Reloj_Nom = "";
         Z2426Reloj_Dsc = "";
         Z2427Reloj_IP = "";
         Z2428Reloj_Puerto = "";
         Z2429Reloj_Estado = 0;
      }

      protected void InitAll7S212( )
      {
         A2430RelojID = 0;
         AssignAttri("", false, "A2430RelojID", StringUtil.LTrimStr( (decimal)(A2430RelojID), 4, 0));
         InitializeNonKey7S212( ) ;
      }

      protected void StandaloneModalInsert( )
      {
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
            context.AddJavascriptSource(StringUtil.RTrim( ((string)Form.Jscriptsrc.Item(idxLst))), "?202281812353815", true, true);
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
         context.AddJavascriptSource("reloj_interface/reloj.js", "?202281812353815", false, true);
         context.AddJavascriptSource("DVelop/Bootstrap/Shared/DVelopBootstrap.js", "", false, true);
         context.AddJavascriptSource("DVelop/Shared/WorkWithPlusCommon.js", "", false, true);
         context.AddJavascriptSource("DVelop/Bootstrap/Panel/BootstrapPanelRender.js", "", false, true);
         /* End function include_jscripts */
      }

      protected void init_default_properties( )
      {
         edtRelojID_Internalname = "RELOJID";
         edtReloj_Nom_Internalname = "RELOJ_NOM";
         edtReloj_Dsc_Internalname = "RELOJ_DSC";
         edtReloj_IP_Internalname = "RELOJ_IP";
         edtReloj_Puerto_Internalname = "RELOJ_PUERTO";
         cmbReloj_Estado_Internalname = "RELOJ_ESTADO";
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
         Form.Caption = "Reloj";
         bttBtntrn_delete_Enabled = 0;
         bttBtntrn_delete_Visible = 1;
         bttBtntrn_cancel_Visible = 1;
         bttBtntrn_enter_Enabled = 1;
         bttBtntrn_enter_Visible = 1;
         cmbReloj_Estado_Jsonclick = "";
         cmbReloj_Estado.Enabled = 1;
         edtReloj_Puerto_Jsonclick = "";
         edtReloj_Puerto_Enabled = 1;
         edtReloj_IP_Jsonclick = "";
         edtReloj_IP_Enabled = 1;
         edtReloj_Dsc_Jsonclick = "";
         edtReloj_Dsc_Enabled = 1;
         edtReloj_Nom_Jsonclick = "";
         edtReloj_Nom_Enabled = 1;
         edtRelojID_Jsonclick = "";
         edtRelojID_Enabled = 1;
         Dvpanel_tableattributes_Autoscroll = Convert.ToBoolean( 0);
         Dvpanel_tableattributes_Iconposition = "Right";
         Dvpanel_tableattributes_Showcollapseicon = Convert.ToBoolean( 0);
         Dvpanel_tableattributes_Collapsed = Convert.ToBoolean( 0);
         Dvpanel_tableattributes_Collapsible = Convert.ToBoolean( 0);
         Dvpanel_tableattributes_Title = "Maestro del Reloj";
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
         cmbReloj_Estado.Name = "RELOJ_ESTADO";
         cmbReloj_Estado.WebTags = "";
         cmbReloj_Estado.addItem("1", "Activo", 0);
         cmbReloj_Estado.addItem("0", "Inactivo", 0);
         if ( cmbReloj_Estado.ItemCount > 0 )
         {
            A2429Reloj_Estado = (short)(NumberUtil.Val( cmbReloj_Estado.getValidValue(StringUtil.Trim( StringUtil.Str( (decimal)(A2429Reloj_Estado), 1, 0))), "."));
            AssignAttri("", false, "A2429Reloj_Estado", StringUtil.Str( (decimal)(A2429Reloj_Estado), 1, 0));
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
         setEventMetadata("ENTER","{handler:'UserMainFullajax',iparms:[{postForm:true},{av:'Gx_mode',fld:'vMODE',pic:'@!',hsh:true},{av:'AV7RelojID',fld:'vRELOJID',pic:'ZZZ9',hsh:true}]");
         setEventMetadata("ENTER",",oparms:[]}");
         setEventMetadata("REFRESH","{handler:'Refresh',iparms:[{av:'Gx_mode',fld:'vMODE',pic:'@!',hsh:true},{av:'AV9TrnContext',fld:'vTRNCONTEXT',pic:'',hsh:true},{av:'AV7RelojID',fld:'vRELOJID',pic:'ZZZ9',hsh:true}]");
         setEventMetadata("REFRESH",",oparms:[]}");
         setEventMetadata("AFTER TRN","{handler:'E127S2',iparms:[{av:'Gx_mode',fld:'vMODE',pic:'@!',hsh:true},{av:'AV9TrnContext',fld:'vTRNCONTEXT',pic:'',hsh:true}]");
         setEventMetadata("AFTER TRN",",oparms:[]}");
         setEventMetadata("VALID_RELOJID","{handler:'Valid_Relojid',iparms:[]");
         setEventMetadata("VALID_RELOJID",",oparms:[]}");
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
         Z2425Reloj_Nom = "";
         Z2426Reloj_Dsc = "";
         Z2427Reloj_IP = "";
         Z2428Reloj_Puerto = "";
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
         A2425Reloj_Nom = "";
         A2426Reloj_Dsc = "";
         A2427Reloj_IP = "";
         A2428Reloj_Puerto = "";
         bttBtntrn_enter_Jsonclick = "";
         bttBtntrn_cancel_Jsonclick = "";
         bttBtntrn_delete_Jsonclick = "";
         Dvpanel_tableattributes_Objectcall = "";
         Dvpanel_tableattributes_Class = "";
         Dvpanel_tableattributes_Height = "";
         forbiddenHiddens = new GXProperties();
         hsh = "";
         sMode212 = "";
         sEvt = "";
         EvtGridId = "";
         EvtRowId = "";
         sEvtType = "";
         endTrnMsgTxt = "";
         endTrnMsgCod = "";
         AV8WWPContext = new GeneXus.Programs.wwpbaseobjects.SdtWWPContext(context);
         AV9TrnContext = new GeneXus.Programs.wwpbaseobjects.SdtWWPTransactionContext(context);
         AV10WebSession = context.GetSession();
         T007S4_A2430RelojID = new short[1] ;
         T007S4_A2425Reloj_Nom = new string[] {""} ;
         T007S4_A2426Reloj_Dsc = new string[] {""} ;
         T007S4_A2427Reloj_IP = new string[] {""} ;
         T007S4_A2428Reloj_Puerto = new string[] {""} ;
         T007S4_A2429Reloj_Estado = new short[1] ;
         T007S5_A2430RelojID = new short[1] ;
         T007S3_A2430RelojID = new short[1] ;
         T007S3_A2425Reloj_Nom = new string[] {""} ;
         T007S3_A2426Reloj_Dsc = new string[] {""} ;
         T007S3_A2427Reloj_IP = new string[] {""} ;
         T007S3_A2428Reloj_Puerto = new string[] {""} ;
         T007S3_A2429Reloj_Estado = new short[1] ;
         T007S6_A2430RelojID = new short[1] ;
         T007S7_A2430RelojID = new short[1] ;
         T007S2_A2430RelojID = new short[1] ;
         T007S2_A2425Reloj_Nom = new string[] {""} ;
         T007S2_A2426Reloj_Dsc = new string[] {""} ;
         T007S2_A2427Reloj_IP = new string[] {""} ;
         T007S2_A2428Reloj_Puerto = new string[] {""} ;
         T007S2_A2429Reloj_Estado = new short[1] ;
         T007S11_A2430RelojID = new short[1] ;
         sDynURL = "";
         FormProcess = "";
         bodyStyle = "";
         GXEncryptionTmp = "";
         pr_datastore2 = new DataStoreProvider(context, new GeneXus.Programs.reloj_interface.reloj__datastore2(),
            new Object[][] {
            }
         );
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.reloj_interface.reloj__default(),
            new Object[][] {
                new Object[] {
               T007S2_A2430RelojID, T007S2_A2425Reloj_Nom, T007S2_A2426Reloj_Dsc, T007S2_A2427Reloj_IP, T007S2_A2428Reloj_Puerto, T007S2_A2429Reloj_Estado
               }
               , new Object[] {
               T007S3_A2430RelojID, T007S3_A2425Reloj_Nom, T007S3_A2426Reloj_Dsc, T007S3_A2427Reloj_IP, T007S3_A2428Reloj_Puerto, T007S3_A2429Reloj_Estado
               }
               , new Object[] {
               T007S4_A2430RelojID, T007S4_A2425Reloj_Nom, T007S4_A2426Reloj_Dsc, T007S4_A2427Reloj_IP, T007S4_A2428Reloj_Puerto, T007S4_A2429Reloj_Estado
               }
               , new Object[] {
               T007S5_A2430RelojID
               }
               , new Object[] {
               T007S6_A2430RelojID
               }
               , new Object[] {
               T007S7_A2430RelojID
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               T007S11_A2430RelojID
               }
            }
         );
      }

      private short wcpOAV7RelojID ;
      private short Z2430RelojID ;
      private short Z2429Reloj_Estado ;
      private short GxWebError ;
      private short AV7RelojID ;
      private short IsConfirmed ;
      private short IsModified ;
      private short AnyError ;
      private short nKeyPressed ;
      private short initialized ;
      private short A2429Reloj_Estado ;
      private short A2430RelojID ;
      private short RcdFound212 ;
      private short GX_JID ;
      private short nIsDirty_212 ;
      private short Gx_BScreen ;
      private short gxajaxcallmode ;
      private int trnEnded ;
      private int edtRelojID_Enabled ;
      private int edtReloj_Nom_Enabled ;
      private int edtReloj_Dsc_Enabled ;
      private int edtReloj_IP_Enabled ;
      private int edtReloj_Puerto_Enabled ;
      private int bttBtntrn_enter_Visible ;
      private int bttBtntrn_enter_Enabled ;
      private int bttBtntrn_cancel_Visible ;
      private int bttBtntrn_delete_Visible ;
      private int bttBtntrn_delete_Enabled ;
      private int Dvpanel_tableattributes_Gxcontroltype ;
      private int idxLst ;
      private string sPrefix ;
      private string wcpOGx_mode ;
      private string scmdbuf ;
      private string gxfirstwebparm ;
      private string gxfirstwebparm_bkp ;
      private string GXKey ;
      private string GXDecQS ;
      private string Gx_mode ;
      private string PreviousTooltip ;
      private string PreviousCaption ;
      private string GX_FocusControl ;
      private string edtRelojID_Internalname ;
      private string cmbReloj_Estado_Internalname ;
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
      private string edtRelojID_Jsonclick ;
      private string edtReloj_Nom_Internalname ;
      private string edtReloj_Nom_Jsonclick ;
      private string edtReloj_Dsc_Internalname ;
      private string edtReloj_Dsc_Jsonclick ;
      private string edtReloj_IP_Internalname ;
      private string edtReloj_IP_Jsonclick ;
      private string edtReloj_Puerto_Internalname ;
      private string edtReloj_Puerto_Jsonclick ;
      private string cmbReloj_Estado_Jsonclick ;
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
      private string sMode212 ;
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
      private string Z2425Reloj_Nom ;
      private string Z2426Reloj_Dsc ;
      private string Z2427Reloj_IP ;
      private string Z2428Reloj_Puerto ;
      private string A2425Reloj_Nom ;
      private string A2426Reloj_Dsc ;
      private string A2427Reloj_IP ;
      private string A2428Reloj_Puerto ;
      private IGxSession AV10WebSession ;
      private GXProperties forbiddenHiddens ;
      private GXUserControl ucDvpanel_tableattributes ;
      private IGxDataStore dsDataStore2 ;
      private IGxDataStore dsDefault ;
      private GXCombobox cmbReloj_Estado ;
      private IDataStoreProvider pr_default ;
      private short[] T007S4_A2430RelojID ;
      private string[] T007S4_A2425Reloj_Nom ;
      private string[] T007S4_A2426Reloj_Dsc ;
      private string[] T007S4_A2427Reloj_IP ;
      private string[] T007S4_A2428Reloj_Puerto ;
      private short[] T007S4_A2429Reloj_Estado ;
      private short[] T007S5_A2430RelojID ;
      private short[] T007S3_A2430RelojID ;
      private string[] T007S3_A2425Reloj_Nom ;
      private string[] T007S3_A2426Reloj_Dsc ;
      private string[] T007S3_A2427Reloj_IP ;
      private string[] T007S3_A2428Reloj_Puerto ;
      private short[] T007S3_A2429Reloj_Estado ;
      private short[] T007S6_A2430RelojID ;
      private short[] T007S7_A2430RelojID ;
      private short[] T007S2_A2430RelojID ;
      private string[] T007S2_A2425Reloj_Nom ;
      private string[] T007S2_A2426Reloj_Dsc ;
      private string[] T007S2_A2427Reloj_IP ;
      private string[] T007S2_A2428Reloj_Puerto ;
      private short[] T007S2_A2429Reloj_Estado ;
      private short[] T007S11_A2430RelojID ;
      private IDataStoreProvider pr_datastore2 ;
      private GXWebForm Form ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPContext AV8WWPContext ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPTransactionContext AV9TrnContext ;
   }

   public class reloj__datastore2 : DataStoreHelperBase, IDataStoreHelper
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

 public class reloj__default : DataStoreHelperBase, IDataStoreHelper
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
     };
  }

  private static CursorDef[] def;
  private void cursorDefinitions( )
  {
     if ( def == null )
     {
        Object[] prmT007S4;
        prmT007S4 = new Object[] {
        new ParDef("@RelojID",GXType.Int16,4,0)
        };
        Object[] prmT007S5;
        prmT007S5 = new Object[] {
        new ParDef("@RelojID",GXType.Int16,4,0)
        };
        Object[] prmT007S3;
        prmT007S3 = new Object[] {
        new ParDef("@RelojID",GXType.Int16,4,0)
        };
        Object[] prmT007S6;
        prmT007S6 = new Object[] {
        new ParDef("@RelojID",GXType.Int16,4,0)
        };
        Object[] prmT007S7;
        prmT007S7 = new Object[] {
        new ParDef("@RelojID",GXType.Int16,4,0)
        };
        Object[] prmT007S2;
        prmT007S2 = new Object[] {
        new ParDef("@RelojID",GXType.Int16,4,0)
        };
        Object[] prmT007S8;
        prmT007S8 = new Object[] {
        new ParDef("@RelojID",GXType.Int16,4,0) ,
        new ParDef("@Reloj_Nom",GXType.NVarChar,50,0) ,
        new ParDef("@Reloj_Dsc",GXType.NVarChar,100,0) ,
        new ParDef("@Reloj_IP",GXType.NVarChar,50,0) ,
        new ParDef("@Reloj_Puerto",GXType.NVarChar,50,0) ,
        new ParDef("@Reloj_Estado",GXType.Int16,1,0)
        };
        Object[] prmT007S9;
        prmT007S9 = new Object[] {
        new ParDef("@Reloj_Nom",GXType.NVarChar,50,0) ,
        new ParDef("@Reloj_Dsc",GXType.NVarChar,100,0) ,
        new ParDef("@Reloj_IP",GXType.NVarChar,50,0) ,
        new ParDef("@Reloj_Puerto",GXType.NVarChar,50,0) ,
        new ParDef("@Reloj_Estado",GXType.Int16,1,0) ,
        new ParDef("@RelojID",GXType.Int16,4,0)
        };
        Object[] prmT007S10;
        prmT007S10 = new Object[] {
        new ParDef("@RelojID",GXType.Int16,4,0)
        };
        Object[] prmT007S11;
        prmT007S11 = new Object[] {
        };
        def= new CursorDef[] {
            new CursorDef("T007S2", "SELECT [RelojID], [Reloj_Nom], [Reloj_Dsc], [Reloj_IP], [Reloj_Puerto], [Reloj_Estado] FROM [Reloj] WITH (UPDLOCK) WHERE [RelojID] = @RelojID ",true, GxErrorMask.GX_NOMASK, false, this,prmT007S2,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T007S3", "SELECT [RelojID], [Reloj_Nom], [Reloj_Dsc], [Reloj_IP], [Reloj_Puerto], [Reloj_Estado] FROM [Reloj] WHERE [RelojID] = @RelojID ",true, GxErrorMask.GX_NOMASK, false, this,prmT007S3,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T007S4", "SELECT TM1.[RelojID], TM1.[Reloj_Nom], TM1.[Reloj_Dsc], TM1.[Reloj_IP], TM1.[Reloj_Puerto], TM1.[Reloj_Estado] FROM [Reloj] TM1 WHERE TM1.[RelojID] = @RelojID ORDER BY TM1.[RelojID]  OPTION (FAST 100)",true, GxErrorMask.GX_NOMASK, false, this,prmT007S4,100, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T007S5", "SELECT [RelojID] FROM [Reloj] WHERE [RelojID] = @RelojID  OPTION (FAST 1)",true, GxErrorMask.GX_NOMASK, false, this,prmT007S5,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T007S6", "SELECT TOP 1 [RelojID] FROM [Reloj] WHERE ( [RelojID] > @RelojID) ORDER BY [RelojID]  OPTION (FAST 1)",true, GxErrorMask.GX_NOMASK, false, this,prmT007S6,1, GxCacheFrequency.OFF ,true,true )
           ,new CursorDef("T007S7", "SELECT TOP 1 [RelojID] FROM [Reloj] WHERE ( [RelojID] < @RelojID) ORDER BY [RelojID] DESC  OPTION (FAST 1)",true, GxErrorMask.GX_NOMASK, false, this,prmT007S7,1, GxCacheFrequency.OFF ,true,true )
           ,new CursorDef("T007S8", "INSERT INTO [Reloj]([RelojID], [Reloj_Nom], [Reloj_Dsc], [Reloj_IP], [Reloj_Puerto], [Reloj_Estado]) VALUES(@RelojID, @Reloj_Nom, @Reloj_Dsc, @Reloj_IP, @Reloj_Puerto, @Reloj_Estado)", GxErrorMask.GX_NOMASK,prmT007S8)
           ,new CursorDef("T007S9", "UPDATE [Reloj] SET [Reloj_Nom]=@Reloj_Nom, [Reloj_Dsc]=@Reloj_Dsc, [Reloj_IP]=@Reloj_IP, [Reloj_Puerto]=@Reloj_Puerto, [Reloj_Estado]=@Reloj_Estado  WHERE [RelojID] = @RelojID", GxErrorMask.GX_NOMASK,prmT007S9)
           ,new CursorDef("T007S10", "DELETE FROM [Reloj]  WHERE [RelojID] = @RelojID", GxErrorMask.GX_NOMASK,prmT007S10)
           ,new CursorDef("T007S11", "SELECT [RelojID] FROM [Reloj] ORDER BY [RelojID]  OPTION (FAST 100)",true, GxErrorMask.GX_NOMASK, false, this,prmT007S11,100, GxCacheFrequency.OFF ,true,false )
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
              ((short[]) buf[0])[0] = rslt.getShort(1);
              ((string[]) buf[1])[0] = rslt.getVarchar(2);
              ((string[]) buf[2])[0] = rslt.getVarchar(3);
              ((string[]) buf[3])[0] = rslt.getVarchar(4);
              ((string[]) buf[4])[0] = rslt.getVarchar(5);
              ((short[]) buf[5])[0] = rslt.getShort(6);
              return;
           case 1 :
              ((short[]) buf[0])[0] = rslt.getShort(1);
              ((string[]) buf[1])[0] = rslt.getVarchar(2);
              ((string[]) buf[2])[0] = rslt.getVarchar(3);
              ((string[]) buf[3])[0] = rslt.getVarchar(4);
              ((string[]) buf[4])[0] = rslt.getVarchar(5);
              ((short[]) buf[5])[0] = rslt.getShort(6);
              return;
           case 2 :
              ((short[]) buf[0])[0] = rslt.getShort(1);
              ((string[]) buf[1])[0] = rslt.getVarchar(2);
              ((string[]) buf[2])[0] = rslt.getVarchar(3);
              ((string[]) buf[3])[0] = rslt.getVarchar(4);
              ((string[]) buf[4])[0] = rslt.getVarchar(5);
              ((short[]) buf[5])[0] = rslt.getShort(6);
              return;
           case 3 :
              ((short[]) buf[0])[0] = rslt.getShort(1);
              return;
           case 4 :
              ((short[]) buf[0])[0] = rslt.getShort(1);
              return;
           case 5 :
              ((short[]) buf[0])[0] = rslt.getShort(1);
              return;
           case 9 :
              ((short[]) buf[0])[0] = rslt.getShort(1);
              return;
     }
  }

}

}
