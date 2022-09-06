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
namespace GeneXus.Programs.ventas {
   public class r_ventasproductos : GXDataArea
   {
      public r_ventasproductos( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDataStore2 = context.GetDataStore("DataStore2");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusTheme");
      }

      public r_ventasproductos( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsDataStore2 = context.GetDataStore("DataStore2");
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( )
      {
         executePrivate();
      }

      void executePrivate( )
      {
         isStatic = false;
         webExecute();
      }

      protected override void createObjects( )
      {
         radavTipo = new GXRadio();
         chkavCheckrec = new GXCheckbox();
      }

      protected void INITWEB( )
      {
         initialize_properties( ) ;
         if ( nGotPars == 0 )
         {
            entryPointCalled = false;
            gxfirstwebparm = GetNextPar( );
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
               gxfirstwebparm = GetNextPar( );
            }
            else if ( StringUtil.StrCmp(gxfirstwebparm, "gxfullajaxEvt") == 0 )
            {
               if ( ! IsValidAjaxCall( true) )
               {
                  GxWebError = 1;
                  return  ;
               }
               gxfirstwebparm = GetNextPar( );
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
         }
         if ( ! context.IsLocalStorageSupported( ) )
         {
            context.PushCurrentUrl();
         }
      }

      public override void webExecute( )
      {
         if ( initialized == 0 )
         {
            createObjects();
            initialize();
         }
         INITWEB( ) ;
         if ( ! isAjaxCallMode( ) )
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

      public override short ExecuteStartEvent( )
      {
         PA5P2( ) ;
         gxajaxcallmode = (short)((isAjaxCallMode( ) ? 1 : 0));
         if ( ( gxajaxcallmode == 0 ) && ( GxWebError == 0 ) )
         {
            START5P2( ) ;
         }
         return gxajaxcallmode ;
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
         if ( nGXWrapped != 1 )
         {
            MasterPageObj.master_styles();
         }
         if ( ( ( context.GetBrowserType( ) == 1 ) || ( context.GetBrowserType( ) == 5 ) ) && ( StringUtil.StrCmp(context.GetBrowserVersion( ), "7.0") == 0 ) )
         {
            context.AddJavascriptSource("json2.js", "?"+context.GetBuildNumber( 194480), false, true);
         }
         context.AddJavascriptSource("jquery.js", "?"+context.GetBuildNumber( 194480), false, true);
         context.AddJavascriptSource("gxgral.js", "?"+context.GetBuildNumber( 194480), false, true);
         context.AddJavascriptSource("gxcfg.js", "?202281810315326", false, true);
         if ( context.isSpaRequest( ) )
         {
            enableOutput();
         }
         context.AddJavascriptSource("calendar.js", "?"+context.GetBuildNumber( 194480), false, true);
         context.AddJavascriptSource("calendar-setup.js", "?"+context.GetBuildNumber( 194480), false, true);
         context.AddJavascriptSource("calendar-es.js", "?"+context.GetBuildNumber( 194480), false, true);
         context.AddJavascriptSource("DVelop/Bootstrap/Shared/DVelopBootstrap.js", "", false, true);
         context.AddJavascriptSource("DVelop/Shared/WorkWithPlusCommon.js", "", false, true);
         context.AddJavascriptSource("DVelop/Bootstrap/Panel/BootstrapPanelRender.js", "", false, true);
         context.AddJavascriptSource("DVelop/Bootstrap/Shared/DVelopBootstrap.js", "", false, true);
         context.AddJavascriptSource("DVelop/Shared/WorkWithPlusCommon.js", "", false, true);
         context.AddJavascriptSource("DVelop/Bootstrap/DropDownOptions/BootstrapDropDownOptionsRender.js", "", false, true);
         context.AddJavascriptSource("DVelop/Bootstrap/Shared/DVelopBootstrap.js", "", false, true);
         context.AddJavascriptSource("DVelop/Shared/WorkWithPlusCommon.js", "", false, true);
         context.AddJavascriptSource("DVelop/Bootstrap/DropDownOptions/BootstrapDropDownOptionsRender.js", "", false, true);
         context.AddJavascriptSource("DVelop/Bootstrap/Shared/DVelopBootstrap.js", "", false, true);
         context.AddJavascriptSource("DVelop/Shared/WorkWithPlusCommon.js", "", false, true);
         context.AddJavascriptSource("DVelop/Bootstrap/DropDownOptions/BootstrapDropDownOptionsRender.js", "", false, true);
         context.AddJavascriptSource("DVelop/Bootstrap/Shared/DVelopBootstrap.js", "", false, true);
         context.AddJavascriptSource("DVelop/Shared/WorkWithPlusCommon.js", "", false, true);
         context.AddJavascriptSource("DVelop/Bootstrap/DropDownOptions/BootstrapDropDownOptionsRender.js", "", false, true);
         context.AddJavascriptSource("DVelop/Bootstrap/Shared/DVelopBootstrap.js", "", false, true);
         context.AddJavascriptSource("DVelop/Shared/WorkWithPlusCommon.js", "", false, true);
         context.AddJavascriptSource("DVelop/Bootstrap/DropDownOptions/BootstrapDropDownOptionsRender.js", "", false, true);
         context.AddJavascriptSource("DVelop/Bootstrap/Shared/DVelopBootstrap.js", "", false, true);
         context.AddJavascriptSource("DVelop/Shared/WorkWithPlusCommon.js", "", false, true);
         context.AddJavascriptSource("DVelop/Bootstrap/DropDownOptions/BootstrapDropDownOptionsRender.js", "", false, true);
         context.AddJavascriptSource("Window/InNewWindowRender.js", "", false, true);
         context.WriteHtmlText( Form.Headerrawhtml) ;
         context.CloseHtmlHeader();
         if ( context.isSpaRequest( ) )
         {
            disableOutput();
         }
         FormProcess = " data-HasEnter=\"false\" data-Skiponenter=\"false\"";
         context.WriteHtmlText( "<body ") ;
         bodyStyle = "" + "background-color:" + context.BuildHTMLColor( Form.Backcolor) + ";color:" + context.BuildHTMLColor( Form.Textcolor) + ";";
         if ( nGXWrapped == 0 )
         {
            bodyStyle += "-moz-opacity:0;opacity:0;";
         }
         if ( ! ( String.IsNullOrEmpty(StringUtil.RTrim( Form.Background)) ) )
         {
            bodyStyle += " background-image:url(" + context.convertURL( Form.Background) + ")";
         }
         context.WriteHtmlText( " "+"class=\"form-horizontal Form\""+" "+ "style='"+bodyStyle+"'") ;
         context.WriteHtmlText( FormProcess+">") ;
         context.skipLines(1);
         context.WriteHtmlTextNl( "<form id=\"MAINFORM\" autocomplete=\"off\" name=\"MAINFORM\" method=\"post\" tabindex=-1  class=\"form-horizontal Form\" data-gx-class=\"form-horizontal Form\" novalidate action=\""+formatLink("ventas.r_ventasproductos.aspx") +"\">") ;
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
      }

      protected void SendCloseFormHiddens( )
      {
         /* Send hidden variables. */
         /* Send saved values. */
         send_integrity_footer_hashes( ) ;
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "vTIECOD_DATA", AV32TieCod_Data);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt("vTIECOD_DATA", AV32TieCod_Data);
         }
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "vTIPCCOD_DATA", AV34TipCCod_Data);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt("vTIPCCOD_DATA", AV34TipCCod_Data);
         }
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "vLINCOD_DATA", AV19LinCod_Data);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt("vLINCOD_DATA", AV19LinCod_Data);
         }
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "vSUBLCOD_DATA", AV30SublCod_Data);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt("vSUBLCOD_DATA", AV30SublCod_Data);
         }
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "vZONCOD_DATA", AV45ZonCod_Data);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt("vZONCOD_DATA", AV45ZonCod_Data);
         }
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "vVENCOD_DATA", AV42VenCod_Data);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt("vVENCOD_DATA", AV42VenCod_Data);
         }
         GxWebStd.gx_hidden_field( context, "COMBO_TIECOD_Cls", StringUtil.RTrim( Combo_tiecod_Cls));
         GxWebStd.gx_hidden_field( context, "COMBO_TIECOD_Selectedvalue_set", StringUtil.RTrim( Combo_tiecod_Selectedvalue_set));
         GxWebStd.gx_hidden_field( context, "COMBO_TIPCCOD_Cls", StringUtil.RTrim( Combo_tipccod_Cls));
         GxWebStd.gx_hidden_field( context, "COMBO_TIPCCOD_Selectedvalue_set", StringUtil.RTrim( Combo_tipccod_Selectedvalue_set));
         GxWebStd.gx_hidden_field( context, "COMBO_LINCOD_Cls", StringUtil.RTrim( Combo_lincod_Cls));
         GxWebStd.gx_hidden_field( context, "COMBO_LINCOD_Selectedvalue_set", StringUtil.RTrim( Combo_lincod_Selectedvalue_set));
         GxWebStd.gx_hidden_field( context, "COMBO_SUBLCOD_Cls", StringUtil.RTrim( Combo_sublcod_Cls));
         GxWebStd.gx_hidden_field( context, "COMBO_SUBLCOD_Selectedvalue_set", StringUtil.RTrim( Combo_sublcod_Selectedvalue_set));
         GxWebStd.gx_hidden_field( context, "COMBO_ZONCOD_Cls", StringUtil.RTrim( Combo_zoncod_Cls));
         GxWebStd.gx_hidden_field( context, "COMBO_ZONCOD_Selectedvalue_set", StringUtil.RTrim( Combo_zoncod_Selectedvalue_set));
         GxWebStd.gx_hidden_field( context, "COMBO_VENCOD_Cls", StringUtil.RTrim( Combo_vencod_Cls));
         GxWebStd.gx_hidden_field( context, "COMBO_VENCOD_Selectedvalue_set", StringUtil.RTrim( Combo_vencod_Selectedvalue_set));
         GxWebStd.gx_hidden_field( context, "DVPANEL_PANEL_Width", StringUtil.RTrim( Dvpanel_panel_Width));
         GxWebStd.gx_hidden_field( context, "DVPANEL_PANEL_Autowidth", StringUtil.BoolToStr( Dvpanel_panel_Autowidth));
         GxWebStd.gx_hidden_field( context, "DVPANEL_PANEL_Autoheight", StringUtil.BoolToStr( Dvpanel_panel_Autoheight));
         GxWebStd.gx_hidden_field( context, "DVPANEL_PANEL_Cls", StringUtil.RTrim( Dvpanel_panel_Cls));
         GxWebStd.gx_hidden_field( context, "DVPANEL_PANEL_Title", StringUtil.RTrim( Dvpanel_panel_Title));
         GxWebStd.gx_hidden_field( context, "DVPANEL_PANEL_Collapsible", StringUtil.BoolToStr( Dvpanel_panel_Collapsible));
         GxWebStd.gx_hidden_field( context, "DVPANEL_PANEL_Collapsed", StringUtil.BoolToStr( Dvpanel_panel_Collapsed));
         GxWebStd.gx_hidden_field( context, "DVPANEL_PANEL_Showcollapseicon", StringUtil.BoolToStr( Dvpanel_panel_Showcollapseicon));
         GxWebStd.gx_hidden_field( context, "DVPANEL_PANEL_Iconposition", StringUtil.RTrim( Dvpanel_panel_Iconposition));
         GxWebStd.gx_hidden_field( context, "DVPANEL_PANEL_Autoscroll", StringUtil.BoolToStr( Dvpanel_panel_Autoscroll));
         GxWebStd.gx_hidden_field( context, "INNEWWINDOW_Target", StringUtil.RTrim( Innewwindow_Target));
         GxWebStd.gx_hidden_field( context, "COMBO_VENCOD_Selectedvalue_get", StringUtil.RTrim( Combo_vencod_Selectedvalue_get));
         GxWebStd.gx_hidden_field( context, "COMBO_ZONCOD_Selectedvalue_get", StringUtil.RTrim( Combo_zoncod_Selectedvalue_get));
         GxWebStd.gx_hidden_field( context, "COMBO_SUBLCOD_Selectedvalue_get", StringUtil.RTrim( Combo_sublcod_Selectedvalue_get));
         GxWebStd.gx_hidden_field( context, "COMBO_LINCOD_Selectedvalue_get", StringUtil.RTrim( Combo_lincod_Selectedvalue_get));
         GxWebStd.gx_hidden_field( context, "COMBO_TIPCCOD_Selectedvalue_get", StringUtil.RTrim( Combo_tipccod_Selectedvalue_get));
         GxWebStd.gx_hidden_field( context, "COMBO_TIECOD_Selectedvalue_get", StringUtil.RTrim( Combo_tiecod_Selectedvalue_get));
      }

      public override void RenderHtmlCloseForm( )
      {
         SendCloseFormHiddens( ) ;
         GxWebStd.gx_hidden_field( context, "GX_FocusControl", GX_FocusControl);
         SendAjaxEncryptionKey();
         SendSecurityToken((string)(sPrefix));
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

      public override void RenderHtmlContent( )
      {
         gxajaxcallmode = (short)((isAjaxCallMode( ) ? 1 : 0));
         if ( ( gxajaxcallmode == 0 ) && ( GxWebError == 0 ) )
         {
            context.WriteHtmlText( "<div") ;
            GxWebStd.ClassAttribute( context, "gx-ct-body"+" "+(String.IsNullOrEmpty(StringUtil.RTrim( Form.Class)) ? "form-horizontal Form" : Form.Class)+"-fx");
            context.WriteHtmlText( ">") ;
            WE5P2( ) ;
            context.WriteHtmlText( "</div>") ;
         }
      }

      public override void DispatchEvents( )
      {
         EVT5P2( ) ;
      }

      public override bool HasEnterEvent( )
      {
         return false ;
      }

      public override GXWebForm GetForm( )
      {
         return Form ;
      }

      public override string GetSelfLink( )
      {
         return formatLink("ventas.r_ventasproductos.aspx")  ;
      }

      public override string GetPgmname( )
      {
         return "Ventas.R_VentasProductos" ;
      }

      public override string GetPgmdesc( )
      {
         return "Resumen de Pedidos por producto" ;
      }

      protected void WB5P0( )
      {
         if ( context.isAjaxRequest( ) )
         {
            disableOutput();
         }
         if ( ! wbLoad )
         {
            if ( nGXWrapped == 1 )
            {
               RenderHtmlHeaders( ) ;
               RenderHtmlOpenForm( ) ;
            }
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "Section", "left", "top", " "+"data-gx-base-lib=\"bootstrapv3\""+" "+"data-abstract-form"+" ", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divLayoutmaintable_Internalname, 1, 0, "px", 0, "px", "Table", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divTablemain_Internalname, 1, 0, "px", 0, "px", "TableMain", "left", "top", "", "", "div");
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
            GxWebStd.gx_div_start( context, divTablecontent_Internalname, 1, 0, "px", 0, "px", "", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-9", "left", "top", "", "", "div");
            /* User Defined Control */
            ucDvpanel_panel.SetProperty("Width", Dvpanel_panel_Width);
            ucDvpanel_panel.SetProperty("AutoWidth", Dvpanel_panel_Autowidth);
            ucDvpanel_panel.SetProperty("AutoHeight", Dvpanel_panel_Autoheight);
            ucDvpanel_panel.SetProperty("Cls", Dvpanel_panel_Cls);
            ucDvpanel_panel.SetProperty("Title", Dvpanel_panel_Title);
            ucDvpanel_panel.SetProperty("Collapsible", Dvpanel_panel_Collapsible);
            ucDvpanel_panel.SetProperty("Collapsed", Dvpanel_panel_Collapsed);
            ucDvpanel_panel.SetProperty("ShowCollapseIcon", Dvpanel_panel_Showcollapseicon);
            ucDvpanel_panel.SetProperty("IconPosition", Dvpanel_panel_Iconposition);
            ucDvpanel_panel.SetProperty("AutoScroll", Dvpanel_panel_Autoscroll);
            ucDvpanel_panel.Render(context, "dvelop.gxbootstrap.panel_al", Dvpanel_panel_Internalname, "DVPANEL_PANELContainer");
            context.WriteHtmlText( "<div class=\"gx_usercontrol_child\" id=\""+"DVPANEL_PANELContainer"+"Panel"+"\" style=\"display:none;\">") ;
            /* Div Control */
            GxWebStd.gx_div_start( context, divPanel_Internalname, 1, 0, "px", 0, "px", "", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 DataContentCell ExtendedComboCell", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divTablesplittedtiecod_Internalname, 1, 0, "px", 0, "px", "Table", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-6 MergeLabelCell CellWidth_12_5", "left", "top", "", "", "div");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblTextblockcombo_tiecod_Internalname, "Local", "", "", lblTextblockcombo_tiecod_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "Label", 0, "", 1, 1, 0, 0, "HLP_Ventas\\R_VentasProductos.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-6 CellWidth_87_5", "left", "top", "", "", "div");
            /* User Defined Control */
            ucCombo_tiecod.SetProperty("Caption", Combo_tiecod_Caption);
            ucCombo_tiecod.SetProperty("Cls", Combo_tiecod_Cls);
            ucCombo_tiecod.SetProperty("DropDownOptionsData", AV32TieCod_Data);
            ucCombo_tiecod.Render(context, "dvelop.gxbootstrap.ddoextendedcombo", Combo_tiecod_Internalname, "COMBO_TIECODContainer");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 DataContentCell ExtendedComboCell", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divTablesplittedtipccod_Internalname, 1, 0, "px", 0, "px", "Table", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-6 MergeLabelCell CellWidth_12_5", "left", "top", "", "", "div");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblTextblockcombo_tipccod_Internalname, "Tipo Cliente", "", "", lblTextblockcombo_tipccod_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "Label", 0, "", 1, 1, 0, 0, "HLP_Ventas\\R_VentasProductos.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-6 CellWidth_87_5", "left", "top", "", "", "div");
            /* User Defined Control */
            ucCombo_tipccod.SetProperty("Caption", Combo_tipccod_Caption);
            ucCombo_tipccod.SetProperty("Cls", Combo_tipccod_Cls);
            ucCombo_tipccod.SetProperty("DropDownOptionsData", AV34TipCCod_Data);
            ucCombo_tipccod.Render(context, "dvelop.gxbootstrap.ddoextendedcombo", Combo_tipccod_Internalname, "COMBO_TIPCCODContainer");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 DataContentCell ExtendedComboCell", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divTablesplittedlincod_Internalname, 1, 0, "px", 0, "px", "Table", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-6 MergeLabelCell CellWidth_12_5", "left", "top", "", "", "div");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblTextblockcombo_lincod_Internalname, "Linea Productos", "", "", lblTextblockcombo_lincod_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "Label", 0, "", 1, 1, 0, 0, "HLP_Ventas\\R_VentasProductos.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-6 CellWidth_87_5", "left", "top", "", "", "div");
            /* User Defined Control */
            ucCombo_lincod.SetProperty("Caption", Combo_lincod_Caption);
            ucCombo_lincod.SetProperty("Cls", Combo_lincod_Cls);
            ucCombo_lincod.SetProperty("DropDownOptionsData", AV19LinCod_Data);
            ucCombo_lincod.Render(context, "dvelop.gxbootstrap.ddoextendedcombo", Combo_lincod_Internalname, "COMBO_LINCODContainer");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 DataContentCell ExtendedComboCell", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divTablesplittedsublcod_Internalname, 1, 0, "px", 0, "px", "Table", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-6 MergeLabelCell CellWidth_12_5", "left", "top", "", "", "div");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblTextblockcombo_sublcod_Internalname, "Sub Linea de Productos ", "", "", lblTextblockcombo_sublcod_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "Label", 0, "", 1, 1, 0, 0, "HLP_Ventas\\R_VentasProductos.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-6 CellWidth_87_5", "left", "top", "", "", "div");
            /* User Defined Control */
            ucCombo_sublcod.SetProperty("Caption", Combo_sublcod_Caption);
            ucCombo_sublcod.SetProperty("Cls", Combo_sublcod_Cls);
            ucCombo_sublcod.SetProperty("DropDownOptionsData", AV30SublCod_Data);
            ucCombo_sublcod.Render(context, "dvelop.gxbootstrap.ddoextendedcombo", Combo_sublcod_Internalname, "COMBO_SUBLCODContainer");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 DataContentCell ExtendedComboCell", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divTablesplittedzoncod_Internalname, 1, 0, "px", 0, "px", "Table", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-6 MergeLabelCell CellWidth_12_5", "left", "top", "", "", "div");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblTextblockcombo_zoncod_Internalname, "Zona", "", "", lblTextblockcombo_zoncod_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "Label", 0, "", 1, 1, 0, 0, "HLP_Ventas\\R_VentasProductos.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-6 CellWidth_87_5", "left", "top", "", "", "div");
            /* User Defined Control */
            ucCombo_zoncod.SetProperty("Caption", Combo_zoncod_Caption);
            ucCombo_zoncod.SetProperty("Cls", Combo_zoncod_Cls);
            ucCombo_zoncod.SetProperty("DropDownOptionsData", AV45ZonCod_Data);
            ucCombo_zoncod.Render(context, "dvelop.gxbootstrap.ddoextendedcombo", Combo_zoncod_Internalname, "COMBO_ZONCODContainer");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 DataContentCell ExtendedComboCell", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divTablesplittedvencod_Internalname, 1, 0, "px", 0, "px", "Table", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-6 MergeLabelCell CellWidth_12_5", "left", "top", "", "", "div");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblTextblockcombo_vencod_Internalname, "Vendedor", "", "", lblTextblockcombo_vencod_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "Label", 0, "", 1, 1, 0, 0, "HLP_Ventas\\R_VentasProductos.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-6 CellWidth_87_5", "left", "top", "", "", "div");
            /* User Defined Control */
            ucCombo_vencod.SetProperty("Caption", Combo_vencod_Caption);
            ucCombo_vencod.SetProperty("Cls", Combo_vencod_Cls);
            ucCombo_vencod.SetProperty("DropDownOptionsData", AV42VenCod_Data);
            ucCombo_vencod.Render(context, "dvelop.gxbootstrap.ddoextendedcombo", Combo_vencod_Internalname, "COMBO_VENCODContainer");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 DataContentCell", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divTablesplittedclicod_Internalname, 1, 0, "px", 0, "px", "Table", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-6 MergeLabelCell CellWidth_12_5", "left", "top", "", "", "div");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblTextblockclicod_Internalname, "Cliente", "", "", lblTextblockclicod_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "Label", 0, "", 1, 1, 0, 0, "HLP_Ventas\\R_VentasProductos.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-6 CellWidth_87_5", "left", "top", "", "", "div");
            wb_table1_73_5P2( true) ;
         }
         else
         {
            wb_table1_73_5P2( false) ;
         }
         return  ;
      }

      protected void wb_table1_73_5P2e( bool wbgen )
      {
         if ( wbgen )
         {
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 DataContentCell", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divTablesplittedprodcod_Internalname, 1, 0, "px", 0, "px", "Table", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-6 MergeLabelCell CellWidth_12_5", "left", "top", "", "", "div");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblTextblockprodcod_Internalname, " Producto", "", "", lblTextblockprodcod_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "Label", 0, "", 1, 1, 0, 0, "HLP_Ventas\\R_VentasProductos.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-6 CellWidth_87_5", "left", "top", "", "", "div");
            wb_table2_90_5P2( true) ;
         }
         else
         {
            wb_table2_90_5P2( false) ;
         }
         return  ;
      }

      protected void wb_table2_90_5P2e( bool wbgen )
      {
         if ( wbgen )
         {
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 DataContentCell", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divTablesplittedfdesde_Internalname, 1, 0, "px", 0, "px", "Table", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-6 MergeLabelCell CellWidth_12_5", "left", "top", "", "", "div");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblTextblockfdesde_Internalname, "F.Desde", "", "", lblTextblockfdesde_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "Label", 0, "", 1, 1, 0, 0, "HLP_Ventas\\R_VentasProductos.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-6 CellWidth_87_5", "left", "top", "", "", "div");
            wb_table3_107_5P2( true) ;
         }
         else
         {
            wb_table3_107_5P2( false) ;
         }
         return  ;
      }

      protected void wb_table3_107_5P2e( bool wbgen )
      {
         if ( wbgen )
         {
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 DataContentCell", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divUnnamedtabletipo_Internalname, 1, 0, "px", 0, "px", "Table", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-6 MergeLabelCell CellWidth_12_5", "left", "top", "", "", "div");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblTextblocktipo_Internalname, "Tipo", "", "", lblTextblocktipo_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "Label", 0, "", 1, 1, 0, 0, "HLP_Ventas\\R_VentasProductos.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-6 CellWidth_87_5", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "left", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, "", "Tipo", "col-sm-3 AttributeCheckBoxLabel", 0, true, "");
            /* Radio button */
            ClassString = "AttributeCheckBox";
            StyleString = "";
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 124,'',false,'',0)\"";
            GxWebStd.gx_radio_ctrl( context, radavTipo, radavTipo_Internalname, StringUtil.RTrim( AV37Tipo), "", 1, 1, 0, 0, StyleString, ClassString, "", "", 0, radavTipo_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", TempTags+" onclick="+"\""+"gx.evt.onchange(this, event);\""+" onblur=\""+""+";gx.evt.onblur(this,124);\"", "HLP_Ventas\\R_VentasProductos.htm");
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
            GxWebStd.gx_div_start( context, divUnnamedtablecheckrec_Internalname, 1, 0, "px", 0, "px", "Table", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-6 MergeLabelCell CellWidth_12_5", "left", "top", "", "", "div");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblTextblockcheckrec_Internalname, "Incluye Recibos", "", "", lblTextblockcheckrec_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "Label", 0, "", 1, 1, 0, 0, "HLP_Ventas\\R_VentasProductos.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-6 CellWidth_87_5", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "left", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, chkavCheckrec_Internalname, "Check Rec", "col-sm-3 AttributeCheckBoxLabel", 0, true, "");
            /* Check box */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 133,'',false,'',0)\"";
            ClassString = "AttributeCheckBox";
            StyleString = "";
            GxWebStd.gx_checkbox_ctrl( context, chkavCheckrec_Internalname, StringUtil.Str( (decimal)(AV43CheckRec), 1, 0), "", "Check Rec", 1, chkavCheckrec.Enabled, "1", "¿Desea Inlcuir Recibos?", StyleString, ClassString, "", "", TempTags+" onclick="+"\"gx.fn.checkboxClick(133, this, 1, 0,"+"''"+");"+"gx.evt.onchange(this, event);\""+" onblur=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onblur(this,133);\"");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            context.WriteHtmlText( "</div>") ;
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-action-group ActionGroup", "left", "top", " "+"data-gx-actiongroup-type=\"toolbar\""+" ", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "left", "top", "", "", "div");
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 138,'',false,'',0)\"";
            ClassString = "ButtonPDF";
            StyleString = "";
            GxWebStd.gx_button_ctrl( context, bttBtnbtnimprimir_Internalname, "", "Imprimir", bttBtnbtnimprimir_Jsonclick, 5, "Imprimir", "", StyleString, ClassString, 1, 1, "standard", "'"+""+"'"+",false,"+"'"+"E\\'DOBTNIMPRIMIR\\'."+"'", TempTags, "", context.GetButtonType( ), "HLP_Ventas\\R_VentasProductos.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "left", "top", "", "", "div");
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 140,'',false,'',0)\"";
            ClassString = "ButtonExcel";
            StyleString = "";
            GxWebStd.gx_button_ctrl( context, bttBtnbtnexcel_Internalname, "", "Excel", bttBtnbtnexcel_Jsonclick, 5, "Exportal a Excel", "", StyleString, ClassString, 1, 1, "standard", "'"+""+"'"+",false,"+"'"+"E\\'DOBTNEXCEL\\'."+"'", TempTags, "", context.GetButtonType( ), "HLP_Ventas\\R_VentasProductos.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "left", "top", "", "", "div");
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 142,'',false,'',0)\"";
            ClassString = "ButtonColor";
            StyleString = "";
            GxWebStd.gx_button_ctrl( context, bttBtnbtnsalir_Internalname, "", "Salir", bttBtnbtnsalir_Jsonclick, 5, "Imprimir PDF", "", StyleString, ClassString, 1, 1, "standard", "'"+""+"'"+",false,"+"'"+"E\\'DOBTNSALIR\\'."+"'", TempTags, "", context.GetButtonType( ), "HLP_Ventas\\R_VentasProductos.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
            /* User Defined Control */
            ucInnewwindow.Render(context, "innewwindow", Innewwindow_Internalname, "INNEWWINDOWContainer");
            GxWebStd.gx_div_end( context, "left", "top", "div");
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
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 149,'',false,'',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavTiecod_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(AV31TieCod), 6, 0, ".", "")), StringUtil.LTrim( context.localUtil.Format( (decimal)(AV31TieCod), "ZZZZZ9")), " inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onblur(this,149);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavTiecod_Jsonclick, 0, "Attribute", "", "", "", "", edtavTiecod_Visible, 1, 0, "text", "1", 6, "chr", 1, "row", 6, 0, 0, 0, 1, -1, 0, true, "", "right", false, "", "HLP_Ventas\\R_VentasProductos.htm");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 150,'',false,'',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavTipccod_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(AV33TipCCod), 6, 0, ".", "")), StringUtil.LTrim( context.localUtil.Format( (decimal)(AV33TipCCod), "ZZZZZ9")), " inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onblur(this,150);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavTipccod_Jsonclick, 0, "Attribute", "", "", "", "", edtavTipccod_Visible, 1, 0, "text", "1", 6, "chr", 1, "row", 6, 0, 0, 0, 1, -1, 0, true, "", "right", false, "", "HLP_Ventas\\R_VentasProductos.htm");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 151,'',false,'',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavLincod_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(AV18LinCod), 6, 0, ".", "")), StringUtil.LTrim( context.localUtil.Format( (decimal)(AV18LinCod), "ZZZZZ9")), " inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onblur(this,151);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavLincod_Jsonclick, 0, "Attribute", "", "", "", "", edtavLincod_Visible, 1, 0, "text", "1", 6, "chr", 1, "row", 6, 0, 0, 0, 1, -1, 0, true, "", "right", false, "", "HLP_Ventas\\R_VentasProductos.htm");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 152,'',false,'',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavSublcod_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(AV29SublCod), 6, 0, ".", "")), StringUtil.LTrim( context.localUtil.Format( (decimal)(AV29SublCod), "ZZZZZ9")), " inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onblur(this,152);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavSublcod_Jsonclick, 0, "Attribute", "", "", "", "", edtavSublcod_Visible, 1, 0, "text", "1", 6, "chr", 1, "row", 6, 0, 0, 0, 1, -1, 0, true, "", "right", false, "", "HLP_Ventas\\R_VentasProductos.htm");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 153,'',false,'',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavZoncod_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(AV44ZonCod), 6, 0, ".", "")), StringUtil.LTrim( context.localUtil.Format( (decimal)(AV44ZonCod), "ZZZZZ9")), " inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onblur(this,153);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavZoncod_Jsonclick, 0, "Attribute", "", "", "", "", edtavZoncod_Visible, 1, 0, "text", "1", 6, "chr", 1, "row", 6, 0, 0, 0, 1, -1, 0, true, "", "right", false, "", "HLP_Ventas\\R_VentasProductos.htm");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 154,'',false,'',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavVencod_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(AV41VenCod), 6, 0, ".", "")), StringUtil.LTrim( context.localUtil.Format( (decimal)(AV41VenCod), "ZZZZZ9")), " inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onblur(this,154);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavVencod_Jsonclick, 0, "Attribute", "", "", "", "", edtavVencod_Visible, 1, 0, "text", "1", 6, "chr", 1, "row", 6, 0, 0, 0, 1, -1, 0, true, "", "right", false, "", "HLP_Ventas\\R_VentasProductos.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
         }
         wbLoad = true;
      }

      protected void START5P2( )
      {
         wbLoad = false;
         wbEnd = 0;
         wbStart = 0;
         if ( ! context.isSpaRequest( ) )
         {
            if ( context.ExposeMetadata( ) )
            {
               Form.Meta.addItem("generator", "GeneXus .NET 17_0_9-159740", 0) ;
            }
            Form.Meta.addItem("description", "Resumen de Pedidos por producto", 0) ;
         }
         context.wjLoc = "";
         context.nUserReturn = 0;
         context.wbHandled = 0;
         if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
         {
         }
         wbErr = false;
         STRUP5P0( ) ;
      }

      protected void WS5P2( )
      {
         START5P2( ) ;
         EVT5P2( ) ;
      }

      protected void EVT5P2( )
      {
         if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
         {
            if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) && ! wbErr )
            {
               /* Read Web Panel buttons. */
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
                           if ( StringUtil.StrCmp(sEvt, "RFR") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                           }
                           else if ( StringUtil.StrCmp(sEvt, "START") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              /* Execute user event: Start */
                              E115P2 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "'DOBTNIMPRIMIR'") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              /* Execute user event: 'DoBtnImprimir' */
                              E125P2 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "'DOBTNEXCEL'") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              /* Execute user event: 'DoBtnExcel' */
                              E135P2 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "'DOBTNSALIR'") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              /* Execute user event: 'DoBtnSalir' */
                              E145P2 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "LOAD") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              /* Execute user event: Load */
                              E155P2 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "ENTER") == 0 )
                           {
                              context.wbHandled = 1;
                              if ( ! wbErr )
                              {
                                 Rfr0gs = false;
                                 if ( ! Rfr0gs )
                                 {
                                 }
                                 dynload_actions( ) ;
                              }
                              /* No code required for Cancel button. It is implemented as the Reset button. */
                           }
                           else if ( StringUtil.StrCmp(sEvt, "LSCR") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              dynload_actions( ) ;
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
      }

      protected void WE5P2( )
      {
         if ( ! GxWebStd.gx_redirect( context) )
         {
            Rfr0gs = true;
            Refresh( ) ;
            if ( ! GxWebStd.gx_redirect( context) )
            {
               if ( nGXWrapped == 1 )
               {
                  RenderHtmlCloseForm( ) ;
               }
            }
         }
      }

      protected void PA5P2( )
      {
         if ( nDonePA == 0 )
         {
            GXKey = Crypto.GetSiteKey( );
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
            if ( ! context.isAjaxRequest( ) )
            {
               GX_FocusControl = edtavClicod_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            }
            nDonePA = 1;
         }
      }

      protected void dynload_actions( )
      {
         /* End function dynload_actions */
      }

      protected void send_integrity_hashes( )
      {
      }

      protected void clear_multi_value_controls( )
      {
         if ( context.isAjaxRequest( ) )
         {
            dynload_actions( ) ;
            before_start_formulas( ) ;
         }
      }

      protected void fix_multi_value_controls( )
      {
         AssignAttri("", false, "AV37Tipo", AV37Tipo);
         AV43CheckRec = (short)(((StringUtil.StrCmp(StringUtil.LTrim( StringUtil.NToC( (decimal)(AV43CheckRec), 1, 0, ".", "")), "1")==0) ? 1 : 0));
         AssignAttri("", false, "AV43CheckRec", StringUtil.Str( (decimal)(AV43CheckRec), 1, 0));
      }

      public void Refresh( )
      {
         send_integrity_hashes( ) ;
         RF5P2( ) ;
         if ( isFullAjaxMode( ) )
         {
            send_integrity_footer_hashes( ) ;
         }
      }

      protected void initialize_formulas( )
      {
         /* GeneXus formulas. */
         context.Gx_err = 0;
         edtavClidsc_Enabled = 0;
         AssignProp("", false, edtavClidsc_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavClidsc_Enabled), 5, 0), true);
         edtavProddsc_Enabled = 0;
         AssignProp("", false, edtavProddsc_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavProddsc_Enabled), 5, 0), true);
      }

      protected void RF5P2( )
      {
         initialize_formulas( ) ;
         clear_multi_value_controls( ) ;
         gxdyncontrolsrefreshing = true;
         fix_multi_value_controls( ) ;
         gxdyncontrolsrefreshing = false;
         if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
         {
            /* Execute user event: Load */
            E155P2 ();
            WB5P0( ) ;
         }
      }

      protected void send_integrity_lvl_hashes5P2( )
      {
      }

      protected void before_start_formulas( )
      {
         context.Gx_err = 0;
         edtavClidsc_Enabled = 0;
         AssignProp("", false, edtavClidsc_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavClidsc_Enabled), 5, 0), true);
         edtavProddsc_Enabled = 0;
         AssignProp("", false, edtavProddsc_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavProddsc_Enabled), 5, 0), true);
         fix_multi_value_controls( ) ;
      }

      protected void STRUP5P0( )
      {
         /* Before Start, stand alone formulas. */
         before_start_formulas( ) ;
         /* Execute Start event if defined. */
         context.wbGlbDoneStart = 0;
         /* Execute user event: Start */
         E115P2 ();
         context.wbGlbDoneStart = 1;
         /* After Start, stand alone formulas. */
         if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
         {
            /* Read saved SDTs. */
            ajax_req_read_hidden_sdt(cgiGet( "vTIECOD_DATA"), AV32TieCod_Data);
            ajax_req_read_hidden_sdt(cgiGet( "vTIPCCOD_DATA"), AV34TipCCod_Data);
            ajax_req_read_hidden_sdt(cgiGet( "vLINCOD_DATA"), AV19LinCod_Data);
            ajax_req_read_hidden_sdt(cgiGet( "vSUBLCOD_DATA"), AV30SublCod_Data);
            ajax_req_read_hidden_sdt(cgiGet( "vZONCOD_DATA"), AV45ZonCod_Data);
            ajax_req_read_hidden_sdt(cgiGet( "vVENCOD_DATA"), AV42VenCod_Data);
            /* Read saved values. */
            Combo_tiecod_Cls = cgiGet( "COMBO_TIECOD_Cls");
            Combo_tiecod_Selectedvalue_set = cgiGet( "COMBO_TIECOD_Selectedvalue_set");
            Combo_tipccod_Cls = cgiGet( "COMBO_TIPCCOD_Cls");
            Combo_tipccod_Selectedvalue_set = cgiGet( "COMBO_TIPCCOD_Selectedvalue_set");
            Combo_lincod_Cls = cgiGet( "COMBO_LINCOD_Cls");
            Combo_lincod_Selectedvalue_set = cgiGet( "COMBO_LINCOD_Selectedvalue_set");
            Combo_sublcod_Cls = cgiGet( "COMBO_SUBLCOD_Cls");
            Combo_sublcod_Selectedvalue_set = cgiGet( "COMBO_SUBLCOD_Selectedvalue_set");
            Combo_zoncod_Cls = cgiGet( "COMBO_ZONCOD_Cls");
            Combo_zoncod_Selectedvalue_set = cgiGet( "COMBO_ZONCOD_Selectedvalue_set");
            Combo_vencod_Cls = cgiGet( "COMBO_VENCOD_Cls");
            Combo_vencod_Selectedvalue_set = cgiGet( "COMBO_VENCOD_Selectedvalue_set");
            Dvpanel_panel_Width = cgiGet( "DVPANEL_PANEL_Width");
            Dvpanel_panel_Autowidth = StringUtil.StrToBool( cgiGet( "DVPANEL_PANEL_Autowidth"));
            Dvpanel_panel_Autoheight = StringUtil.StrToBool( cgiGet( "DVPANEL_PANEL_Autoheight"));
            Dvpanel_panel_Cls = cgiGet( "DVPANEL_PANEL_Cls");
            Dvpanel_panel_Title = cgiGet( "DVPANEL_PANEL_Title");
            Dvpanel_panel_Collapsible = StringUtil.StrToBool( cgiGet( "DVPANEL_PANEL_Collapsible"));
            Dvpanel_panel_Collapsed = StringUtil.StrToBool( cgiGet( "DVPANEL_PANEL_Collapsed"));
            Dvpanel_panel_Showcollapseicon = StringUtil.StrToBool( cgiGet( "DVPANEL_PANEL_Showcollapseicon"));
            Dvpanel_panel_Iconposition = cgiGet( "DVPANEL_PANEL_Iconposition");
            Dvpanel_panel_Autoscroll = StringUtil.StrToBool( cgiGet( "DVPANEL_PANEL_Autoscroll"));
            Innewwindow_Target = cgiGet( "INNEWWINDOW_Target");
            /* Read variables values. */
            AV5CliCod = cgiGet( edtavClicod_Internalname);
            AssignAttri("", false, "AV5CliCod", AV5CliCod);
            AV7CliDsc = cgiGet( edtavClidsc_Internalname);
            AssignAttri("", false, "AV7CliDsc", AV7CliDsc);
            AV25ProdCod = StringUtil.Upper( cgiGet( edtavProdcod_Internalname));
            AssignAttri("", false, "AV25ProdCod", AV25ProdCod);
            AV26ProdDsc = cgiGet( edtavProddsc_Internalname);
            AssignAttri("", false, "AV26ProdDsc", AV26ProdDsc);
            if ( context.localUtil.VCDate( cgiGet( edtavFdesde_Internalname), 2) == 0 )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_faildate", new   object[]  {"FDesde"}), 1, "vFDESDE");
               GX_FocusControl = edtavFdesde_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               AV13FDesde = DateTime.MinValue;
               AssignAttri("", false, "AV13FDesde", context.localUtil.Format(AV13FDesde, "99/99/99"));
            }
            else
            {
               AV13FDesde = context.localUtil.CToD( cgiGet( edtavFdesde_Internalname), 2);
               AssignAttri("", false, "AV13FDesde", context.localUtil.Format(AV13FDesde, "99/99/99"));
            }
            if ( context.localUtil.VCDate( cgiGet( edtavFhasta_Internalname), 2) == 0 )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_faildate", new   object[]  {"FHasta"}), 1, "vFHASTA");
               GX_FocusControl = edtavFhasta_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               AV15FHasta = DateTime.MinValue;
               AssignAttri("", false, "AV15FHasta", context.localUtil.Format(AV15FHasta, "99/99/99"));
            }
            else
            {
               AV15FHasta = context.localUtil.CToD( cgiGet( edtavFhasta_Internalname), 2);
               AssignAttri("", false, "AV15FHasta", context.localUtil.Format(AV15FHasta, "99/99/99"));
            }
            AV37Tipo = cgiGet( radavTipo_Internalname);
            AssignAttri("", false, "AV37Tipo", AV37Tipo);
            if ( ( ( ((StringUtil.StrCmp(cgiGet( chkavCheckrec_Internalname), "1")==0) ? 1 : 0) < 0 ) ) || ( ( ((StringUtil.StrCmp(cgiGet( chkavCheckrec_Internalname), "1")==0) ? 1 : 0) > 9 ) ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "vCHECKREC");
               GX_FocusControl = chkavCheckrec_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               AV43CheckRec = 0;
               AssignAttri("", false, "AV43CheckRec", StringUtil.Str( (decimal)(AV43CheckRec), 1, 0));
            }
            else
            {
               AV43CheckRec = (short)(((StringUtil.StrCmp(cgiGet( chkavCheckrec_Internalname), "1")==0) ? 1 : 0));
               AssignAttri("", false, "AV43CheckRec", StringUtil.Str( (decimal)(AV43CheckRec), 1, 0));
            }
            if ( ( ( context.localUtil.CToN( cgiGet( edtavTiecod_Internalname), ".", ",") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtavTiecod_Internalname), ".", ",") > Convert.ToDecimal( 999999 )) ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "vTIECOD");
               GX_FocusControl = edtavTiecod_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               AV31TieCod = 0;
               AssignAttri("", false, "AV31TieCod", StringUtil.LTrimStr( (decimal)(AV31TieCod), 6, 0));
            }
            else
            {
               AV31TieCod = (int)(context.localUtil.CToN( cgiGet( edtavTiecod_Internalname), ".", ","));
               AssignAttri("", false, "AV31TieCod", StringUtil.LTrimStr( (decimal)(AV31TieCod), 6, 0));
            }
            if ( ( ( context.localUtil.CToN( cgiGet( edtavTipccod_Internalname), ".", ",") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtavTipccod_Internalname), ".", ",") > Convert.ToDecimal( 999999 )) ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "vTIPCCOD");
               GX_FocusControl = edtavTipccod_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               AV33TipCCod = 0;
               AssignAttri("", false, "AV33TipCCod", StringUtil.LTrimStr( (decimal)(AV33TipCCod), 6, 0));
            }
            else
            {
               AV33TipCCod = (int)(context.localUtil.CToN( cgiGet( edtavTipccod_Internalname), ".", ","));
               AssignAttri("", false, "AV33TipCCod", StringUtil.LTrimStr( (decimal)(AV33TipCCod), 6, 0));
            }
            if ( ( ( context.localUtil.CToN( cgiGet( edtavLincod_Internalname), ".", ",") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtavLincod_Internalname), ".", ",") > Convert.ToDecimal( 999999 )) ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "vLINCOD");
               GX_FocusControl = edtavLincod_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               AV18LinCod = 0;
               AssignAttri("", false, "AV18LinCod", StringUtil.LTrimStr( (decimal)(AV18LinCod), 6, 0));
            }
            else
            {
               AV18LinCod = (int)(context.localUtil.CToN( cgiGet( edtavLincod_Internalname), ".", ","));
               AssignAttri("", false, "AV18LinCod", StringUtil.LTrimStr( (decimal)(AV18LinCod), 6, 0));
            }
            if ( ( ( context.localUtil.CToN( cgiGet( edtavSublcod_Internalname), ".", ",") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtavSublcod_Internalname), ".", ",") > Convert.ToDecimal( 999999 )) ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "vSUBLCOD");
               GX_FocusControl = edtavSublcod_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               AV29SublCod = 0;
               AssignAttri("", false, "AV29SublCod", StringUtil.LTrimStr( (decimal)(AV29SublCod), 6, 0));
            }
            else
            {
               AV29SublCod = (int)(context.localUtil.CToN( cgiGet( edtavSublcod_Internalname), ".", ","));
               AssignAttri("", false, "AV29SublCod", StringUtil.LTrimStr( (decimal)(AV29SublCod), 6, 0));
            }
            if ( ( ( context.localUtil.CToN( cgiGet( edtavZoncod_Internalname), ".", ",") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtavZoncod_Internalname), ".", ",") > Convert.ToDecimal( 999999 )) ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "vZONCOD");
               GX_FocusControl = edtavZoncod_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               AV44ZonCod = 0;
               AssignAttri("", false, "AV44ZonCod", StringUtil.LTrimStr( (decimal)(AV44ZonCod), 6, 0));
            }
            else
            {
               AV44ZonCod = (int)(context.localUtil.CToN( cgiGet( edtavZoncod_Internalname), ".", ","));
               AssignAttri("", false, "AV44ZonCod", StringUtil.LTrimStr( (decimal)(AV44ZonCod), 6, 0));
            }
            if ( ( ( context.localUtil.CToN( cgiGet( edtavVencod_Internalname), ".", ",") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtavVencod_Internalname), ".", ",") > Convert.ToDecimal( 999999 )) ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "vVENCOD");
               GX_FocusControl = edtavVencod_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               AV41VenCod = 0;
               AssignAttri("", false, "AV41VenCod", StringUtil.LTrimStr( (decimal)(AV41VenCod), 6, 0));
            }
            else
            {
               AV41VenCod = (int)(context.localUtil.CToN( cgiGet( edtavVencod_Internalname), ".", ","));
               AssignAttri("", false, "AV41VenCod", StringUtil.LTrimStr( (decimal)(AV41VenCod), 6, 0));
            }
            /* Read subfile selected row values. */
            /* Read hidden variables. */
            GXKey = Crypto.GetSiteKey( );
         }
         else
         {
            dynload_actions( ) ;
         }
      }

      protected void GXStart( )
      {
         /* Execute user event: Start */
         E115P2 ();
         if (returnInSub) return;
      }

      protected void E115P2( )
      {
         /* Start Routine */
         returnInSub = false;
         edtavVencod_Visible = 0;
         AssignProp("", false, edtavVencod_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavVencod_Visible), 5, 0), true);
         edtavZoncod_Visible = 0;
         AssignProp("", false, edtavZoncod_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavZoncod_Visible), 5, 0), true);
         edtavSublcod_Visible = 0;
         AssignProp("", false, edtavSublcod_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavSublcod_Visible), 5, 0), true);
         edtavLincod_Visible = 0;
         AssignProp("", false, edtavLincod_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavLincod_Visible), 5, 0), true);
         edtavTipccod_Visible = 0;
         AssignProp("", false, edtavTipccod_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavTipccod_Visible), 5, 0), true);
         edtavTiecod_Visible = 0;
         AssignProp("", false, edtavTiecod_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavTiecod_Visible), 5, 0), true);
         /* Execute user subroutine: 'LOADCOMBOTIECOD' */
         S112 ();
         if (returnInSub) return;
         /* Execute user subroutine: 'LOADCOMBOTIPCCOD' */
         S122 ();
         if (returnInSub) return;
         /* Execute user subroutine: 'LOADCOMBOLINCOD' */
         S132 ();
         if (returnInSub) return;
         /* Execute user subroutine: 'LOADCOMBOSUBLCOD' */
         S142 ();
         if (returnInSub) return;
         /* Execute user subroutine: 'LOADCOMBOZONCOD' */
         S152 ();
         if (returnInSub) return;
         /* Execute user subroutine: 'LOADCOMBOVENCOD' */
         S162 ();
         if (returnInSub) return;
         AV37Tipo = "T";
         AssignAttri("", false, "AV37Tipo", AV37Tipo);
         AV13FDesde = DateTimeUtil.Today( context);
         AssignAttri("", false, "AV13FDesde", context.localUtil.Format(AV13FDesde, "99/99/99"));
         AV15FHasta = DateTimeUtil.Today( context);
         AssignAttri("", false, "AV15FHasta", context.localUtil.Format(AV15FHasta, "99/99/99"));
      }

      protected void E125P2( )
      {
         /* 'DoBtnImprimir' Routine */
         returnInSub = false;
         GXKey = Crypto.GetSiteKey( );
         GXEncryptionTmp = "rrventasproductos.aspx"+UrlEncode(StringUtil.LTrimStr(AV18LinCod,6,0)) + "," + UrlEncode(StringUtil.LTrimStr(AV29SublCod,6,0)) + "," + UrlEncode(StringUtil.RTrim(AV25ProdCod)) + "," + UrlEncode(DateTimeUtil.FormatDateParm(AV13FDesde)) + "," + UrlEncode(DateTimeUtil.FormatDateParm(AV15FHasta)) + "," + UrlEncode(StringUtil.RTrim(AV37Tipo)) + "," + UrlEncode(StringUtil.RTrim(AV5CliCod)) + "," + UrlEncode(StringUtil.LTrimStr(AV44ZonCod,6,0)) + "," + UrlEncode(StringUtil.LTrimStr(AV41VenCod,6,0)) + "," + UrlEncode(StringUtil.LTrimStr(AV31TieCod,6,0)) + "," + UrlEncode(StringUtil.LTrimStr(AV33TipCCod,6,0)) + "," + UrlEncode(StringUtil.LTrimStr(AV43CheckRec,1,0));
         Innewwindow_Target = formatLink("rrventasproductos.aspx") + "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey);
         ucInnewwindow.SendProperty(context, "", false, Innewwindow_Internalname, "Target", Innewwindow_Target);
         this.executeUsercontrolMethod("", false, "INNEWWINDOWContainer", "OpenWindow", "", new Object[] {});
         /*  Sending Event outputs  */
      }

      protected void E135P2( )
      {
         /* 'DoBtnExcel' Routine */
         returnInSub = false;
         context.DoAjaxRefresh();
         new rventasproductosexcel(context ).execute( ref  AV18LinCod, ref  AV29SublCod, ref  AV25ProdCod, ref  AV13FDesde, ref  AV15FHasta, ref  AV37Tipo, ref  AV5CliCod, ref  AV44ZonCod, ref  AV41VenCod, ref  AV31TieCod, ref  AV33TipCCod, ref  AV43CheckRec, out  AV10ExcelFilename, out  AV9ErrorMessage) ;
         AssignAttri("", false, "AV18LinCod", StringUtil.LTrimStr( (decimal)(AV18LinCod), 6, 0));
         AssignAttri("", false, "AV29SublCod", StringUtil.LTrimStr( (decimal)(AV29SublCod), 6, 0));
         AssignAttri("", false, "AV25ProdCod", AV25ProdCod);
         AssignAttri("", false, "AV13FDesde", context.localUtil.Format(AV13FDesde, "99/99/99"));
         AssignAttri("", false, "AV15FHasta", context.localUtil.Format(AV15FHasta, "99/99/99"));
         AssignAttri("", false, "AV37Tipo", AV37Tipo);
         AssignAttri("", false, "AV5CliCod", AV5CliCod);
         AssignAttri("", false, "AV44ZonCod", StringUtil.LTrimStr( (decimal)(AV44ZonCod), 6, 0));
         AssignAttri("", false, "AV41VenCod", StringUtil.LTrimStr( (decimal)(AV41VenCod), 6, 0));
         AssignAttri("", false, "AV31TieCod", StringUtil.LTrimStr( (decimal)(AV31TieCod), 6, 0));
         AssignAttri("", false, "AV33TipCCod", StringUtil.LTrimStr( (decimal)(AV33TipCCod), 6, 0));
         AssignAttri("", false, "AV43CheckRec", StringUtil.Str( (decimal)(AV43CheckRec), 1, 0));
         if ( StringUtil.StrCmp(AV10ExcelFilename, "") != 0 )
         {
            CallWebObject(formatLink(AV10ExcelFilename) );
            context.wjLocDisableFrm = 0;
         }
         else
         {
            GX_msglist.addItem(AV9ErrorMessage);
         }
         /*  Sending Event outputs  */
         radavTipo.CurrentValue = StringUtil.RTrim( AV37Tipo);
         AssignProp("", false, radavTipo_Internalname, "Values", radavTipo.ToJavascriptSource(), true);
      }

      protected void E145P2( )
      {
         /* 'DoBtnSalir' Routine */
         returnInSub = false;
         CallWebObject(formatLink("wwpbaseobjects.home.aspx") );
         context.wjLocDisableFrm = 1;
      }

      protected void S162( )
      {
         /* 'LOADCOMBOVENCOD' Routine */
         returnInSub = false;
         /* Using cursor H005P2 */
         pr_default.execute(0);
         while ( (pr_default.getStatus(0) != 101) )
         {
            A2047VenSts = H005P2_A2047VenSts[0];
            A309VenCod = H005P2_A309VenCod[0];
            A2045VenDsc = H005P2_A2045VenDsc[0];
            AV8Combo_DataItem = new GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTComboData_Item(context);
            AV8Combo_DataItem.gxTpr_Id = StringUtil.Trim( StringUtil.Str( (decimal)(A309VenCod), 6, 0));
            AV8Combo_DataItem.gxTpr_Title = A2045VenDsc;
            AV42VenCod_Data.Add(AV8Combo_DataItem, 0);
            pr_default.readNext(0);
         }
         pr_default.close(0);
         Combo_vencod_Selectedvalue_set = ((0==AV41VenCod) ? "" : StringUtil.Trim( StringUtil.Str( (decimal)(AV41VenCod), 6, 0)));
         ucCombo_vencod.SendProperty(context, "", false, Combo_vencod_Internalname, "SelectedValue_set", Combo_vencod_Selectedvalue_set);
      }

      protected void S152( )
      {
         /* 'LOADCOMBOZONCOD' Routine */
         returnInSub = false;
         /* Using cursor H005P3 */
         pr_default.execute(1);
         while ( (pr_default.getStatus(1) != 101) )
         {
            A2095ZonSts = H005P3_A2095ZonSts[0];
            A158ZonCod = H005P3_A158ZonCod[0];
            A2094ZonDsc = H005P3_A2094ZonDsc[0];
            AV8Combo_DataItem = new GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTComboData_Item(context);
            AV8Combo_DataItem.gxTpr_Id = StringUtil.Trim( StringUtil.Str( (decimal)(A158ZonCod), 6, 0));
            AV8Combo_DataItem.gxTpr_Title = A2094ZonDsc;
            AV45ZonCod_Data.Add(AV8Combo_DataItem, 0);
            pr_default.readNext(1);
         }
         pr_default.close(1);
         Combo_zoncod_Selectedvalue_set = ((0==AV44ZonCod) ? "" : StringUtil.Trim( StringUtil.Str( (decimal)(AV44ZonCod), 6, 0)));
         ucCombo_zoncod.SendProperty(context, "", false, Combo_zoncod_Internalname, "SelectedValue_set", Combo_zoncod_Selectedvalue_set);
      }

      protected void S142( )
      {
         /* 'LOADCOMBOSUBLCOD' Routine */
         returnInSub = false;
         /* Using cursor H005P4 */
         pr_default.execute(2);
         while ( (pr_default.getStatus(2) != 101) )
         {
            A1893SublSts = H005P4_A1893SublSts[0];
            A51SublCod = H005P4_A51SublCod[0];
            A1892SublDsc = H005P4_A1892SublDsc[0];
            AV8Combo_DataItem = new GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTComboData_Item(context);
            AV8Combo_DataItem.gxTpr_Id = StringUtil.Trim( StringUtil.Str( (decimal)(A51SublCod), 6, 0));
            AV8Combo_DataItem.gxTpr_Title = A1892SublDsc;
            AV30SublCod_Data.Add(AV8Combo_DataItem, 0);
            pr_default.readNext(2);
         }
         pr_default.close(2);
         Combo_sublcod_Selectedvalue_set = ((0==AV29SublCod) ? "" : StringUtil.Trim( StringUtil.Str( (decimal)(AV29SublCod), 6, 0)));
         ucCombo_sublcod.SendProperty(context, "", false, Combo_sublcod_Internalname, "SelectedValue_set", Combo_sublcod_Selectedvalue_set);
      }

      protected void S132( )
      {
         /* 'LOADCOMBOLINCOD' Routine */
         returnInSub = false;
         /* Using cursor H005P5 */
         pr_default.execute(3);
         while ( (pr_default.getStatus(3) != 101) )
         {
            A1159LinSts = H005P5_A1159LinSts[0];
            A52LinCod = H005P5_A52LinCod[0];
            A1153LinDsc = H005P5_A1153LinDsc[0];
            AV8Combo_DataItem = new GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTComboData_Item(context);
            AV8Combo_DataItem.gxTpr_Id = StringUtil.Trim( StringUtil.Str( (decimal)(A52LinCod), 6, 0));
            AV8Combo_DataItem.gxTpr_Title = A1153LinDsc;
            AV19LinCod_Data.Add(AV8Combo_DataItem, 0);
            pr_default.readNext(3);
         }
         pr_default.close(3);
         Combo_lincod_Selectedvalue_set = ((0==AV18LinCod) ? "" : StringUtil.Trim( StringUtil.Str( (decimal)(AV18LinCod), 6, 0)));
         ucCombo_lincod.SendProperty(context, "", false, Combo_lincod_Internalname, "SelectedValue_set", Combo_lincod_Selectedvalue_set);
      }

      protected void S122( )
      {
         /* 'LOADCOMBOTIPCCOD' Routine */
         returnInSub = false;
         /* Using cursor H005P6 */
         pr_default.execute(4);
         while ( (pr_default.getStatus(4) != 101) )
         {
            A1908TipCSts = H005P6_A1908TipCSts[0];
            A159TipCCod = H005P6_A159TipCCod[0];
            A1905TipCDsc = H005P6_A1905TipCDsc[0];
            AV8Combo_DataItem = new GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTComboData_Item(context);
            AV8Combo_DataItem.gxTpr_Id = StringUtil.Trim( StringUtil.Str( (decimal)(A159TipCCod), 6, 0));
            AV8Combo_DataItem.gxTpr_Title = A1905TipCDsc;
            AV34TipCCod_Data.Add(AV8Combo_DataItem, 0);
            pr_default.readNext(4);
         }
         pr_default.close(4);
         Combo_tipccod_Selectedvalue_set = ((0==AV33TipCCod) ? "" : StringUtil.Trim( StringUtil.Str( (decimal)(AV33TipCCod), 6, 0)));
         ucCombo_tipccod.SendProperty(context, "", false, Combo_tipccod_Internalname, "SelectedValue_set", Combo_tipccod_Selectedvalue_set);
      }

      protected void S112( )
      {
         /* 'LOADCOMBOTIECOD' Routine */
         returnInSub = false;
         /* Using cursor H005P7 */
         pr_default.execute(5);
         while ( (pr_default.getStatus(5) != 101) )
         {
            A1899TieSts = H005P7_A1899TieSts[0];
            A178TieCod = H005P7_A178TieCod[0];
            A1898TieDsc = H005P7_A1898TieDsc[0];
            AV8Combo_DataItem = new GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTComboData_Item(context);
            AV8Combo_DataItem.gxTpr_Id = StringUtil.Trim( StringUtil.Str( (decimal)(A178TieCod), 6, 0));
            AV8Combo_DataItem.gxTpr_Title = A1898TieDsc;
            AV32TieCod_Data.Add(AV8Combo_DataItem, 0);
            pr_default.readNext(5);
         }
         pr_default.close(5);
         Combo_tiecod_Selectedvalue_set = ((0==AV31TieCod) ? "" : StringUtil.Trim( StringUtil.Str( (decimal)(AV31TieCod), 6, 0)));
         ucCombo_tiecod.SendProperty(context, "", false, Combo_tiecod_Internalname, "SelectedValue_set", Combo_tiecod_Selectedvalue_set);
      }

      protected void nextLoad( )
      {
      }

      protected void E155P2( )
      {
         /* Load Routine */
         returnInSub = false;
      }

      protected void wb_table3_107_5P2( bool wbgen )
      {
         if ( wbgen )
         {
            /* Table start */
            sStyleString = "";
            GxWebStd.gx_table_start( context, tblTablemergedfdesde_Internalname, tblTablemergedfdesde_Internalname, "", "TableMerged", 0, "", "", 0, 0, sStyleString, "", "", 0);
            context.WriteHtmlText( "<tr>") ;
            context.WriteHtmlText( "<td class='MergeDataCell'>") ;
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "left", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavFdesde_Internalname, "FDesde", "gx-form-item AttributeDateLabel", 0, true, "width: 25%;");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 111,'',false,'',0)\"";
            context.WriteHtmlText( "<div id=\""+edtavFdesde_Internalname+"_dp_container\" class=\"dp_container\" style=\"white-space:nowrap;display:inline;\">") ;
            GxWebStd.gx_single_line_edit( context, edtavFdesde_Internalname, context.localUtil.Format(AV13FDesde, "99/99/99"), context.localUtil.Format( AV13FDesde, "99/99/99"), TempTags+" onchange=\""+"gx.date.valid_date(this, 8,'DMY',0,24,'spa',false,0);"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.date.valid_date(this, 8,'DMY',0,24,'spa',false,0);"+";gx.evt.onblur(this,111);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavFdesde_Jsonclick, 0, "AttributeDate", "", "", "", "", 1, edtavFdesde_Enabled, 0, "text", "", 8, "chr", 1, "row", 8, 0, 0, 0, 1, -1, 0, true, "", "right", false, "", "HLP_Ventas\\R_VentasProductos.htm");
            GxWebStd.gx_bitmap( context, edtavFdesde_Internalname+"_dp_trigger", context.GetImagePath( "61b9b5d3-dff6-4d59-9b00-da61bc2cbe93", "", context.GetTheme( )), "", "", "", "", ((1==0)||(edtavFdesde_Enabled==0) ? 0 : 1), 0, "Date selector", "Date selector", 0, 1, 0, "", 0, "", 0, 0, 0, "", "", "cursor: pointer;", "", "", "", "", "", "", "", "", 1, false, false, "", "HLP_Ventas\\R_VentasProductos.htm");
            context.WriteHtmlTextNl( "</div>") ;
            GxWebStd.gx_div_end( context, "left", "top", "div");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "<td class='CellPaddingLeft10'>") ;
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group gx-default-form-group", "left", "top", ""+" data-gx-for=\""+edtavFhasta_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavFhasta_Internalname, "F.Hasta", "gx-form-item AttributeDateLabel", 1, true, "width: 25%;");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 75, "%", 0, "px", "gx-form-item gx-attribute", "left", "top", "", "", "div");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 115,'',false,'',0)\"";
            context.WriteHtmlText( "<div id=\""+edtavFhasta_Internalname+"_dp_container\" class=\"dp_container\" style=\"white-space:nowrap;display:inline;\">") ;
            GxWebStd.gx_single_line_edit( context, edtavFhasta_Internalname, context.localUtil.Format(AV15FHasta, "99/99/99"), context.localUtil.Format( AV15FHasta, "99/99/99"), TempTags+" onchange=\""+"gx.date.valid_date(this, 8,'DMY',0,24,'spa',false,0);"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.date.valid_date(this, 8,'DMY',0,24,'spa',false,0);"+";gx.evt.onblur(this,115);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavFhasta_Jsonclick, 0, "AttributeDate", "", "", "", "", 1, edtavFhasta_Enabled, 0, "text", "", 8, "chr", 1, "row", 8, 0, 0, 0, 1, -1, 0, true, "", "right", false, "", "HLP_Ventas\\R_VentasProductos.htm");
            GxWebStd.gx_bitmap( context, edtavFhasta_Internalname+"_dp_trigger", context.GetImagePath( "61b9b5d3-dff6-4d59-9b00-da61bc2cbe93", "", context.GetTheme( )), "", "", "", "", ((1==0)||(edtavFhasta_Enabled==0) ? 0 : 1), 0, "Date selector", "Date selector", 0, 1, 0, "", 0, "", 0, 0, 0, "", "", "cursor: pointer;", "", "", "", "", "", "", "", "", 1, false, false, "", "HLP_Ventas\\R_VentasProductos.htm");
            context.WriteHtmlTextNl( "</div>") ;
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "</tr>") ;
            /* End of table */
            context.WriteHtmlText( "</table>") ;
            wb_table3_107_5P2e( true) ;
         }
         else
         {
            wb_table3_107_5P2e( false) ;
         }
      }

      protected void wb_table2_90_5P2( bool wbgen )
      {
         if ( wbgen )
         {
            /* Table start */
            sStyleString = "";
            GxWebStd.gx_table_start( context, tblTablemergedprodcod_Internalname, tblTablemergedprodcod_Internalname, "", "TableMerged", 0, "", "", 0, 0, sStyleString, "", "", 0);
            context.WriteHtmlText( "<tr>") ;
            context.WriteHtmlText( "<td class='MergeDataCell'>") ;
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "left", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavProdcod_Internalname, "Prod Cod", "gx-form-item AttributeLabel", 0, true, "width: 25%;");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 94,'',false,'',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavProdcod_Internalname, StringUtil.RTrim( AV25ProdCod), StringUtil.RTrim( context.localUtil.Format( AV25ProdCod, "@!")), TempTags+" onchange=\""+"this.value=this.value.toUpperCase();"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"this.value=this.value.toUpperCase();"+";gx.evt.onblur(this,94);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavProdcod_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtavProdcod_Enabled, 0, "text", "", 15, "chr", 1, "row", 15, 0, 0, 0, 1, -1, -1, true, "", "left", true, "", "HLP_Ventas\\R_VentasProductos.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "<td class='CellPaddingLeft10'>") ;
            /* Active images/pictures */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 96,'',false,'',0)\"";
            ClassString = "Image";
            StyleString = "";
            sImgUrl = (string)(context.GetImagePath( "f5b04895-0024-488b-8e3b-b687ca4598ee", "", context.GetTheme( )));
            GxWebStd.gx_bitmap( context, imgBtnbuscarpro_Internalname, sImgUrl, "", "", "", context.GetTheme( ), 1, 1, "", "Buscar Producto", 0, 0, 0, "px", 0, "px", 0, 0, 7, imgBtnbuscarpro_Jsonclick, "'"+""+"'"+",false,"+"'"+"e165p1_client"+"'", StyleString, ClassString, "", "", "", "", " "+"data-gx-image"+" "+TempTags, "", "", 1, false, false, context.GetImageSrcSet( sImgUrl), "HLP_Ventas\\R_VentasProductos.htm");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "<td class='DataContentCell'>") ;
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "left", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavProddsc_Internalname, "Prod Dsc", "gx-form-item ReadonlyAttributeLabel", 0, true, "width: 25%;");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 99,'',false,'',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavProddsc_Internalname, StringUtil.RTrim( AV26ProdDsc), StringUtil.RTrim( context.localUtil.Format( AV26ProdDsc, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,99);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavProddsc_Jsonclick, 0, "ReadonlyAttribute", "", "", "", "", 1, edtavProddsc_Enabled, 0, "text", "", 80, "chr", 1, "row", 100, 0, 0, 0, 1, -1, -1, true, "", "left", true, "", "HLP_Ventas\\R_VentasProductos.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "</tr>") ;
            /* End of table */
            context.WriteHtmlText( "</table>") ;
            wb_table2_90_5P2e( true) ;
         }
         else
         {
            wb_table2_90_5P2e( false) ;
         }
      }

      protected void wb_table1_73_5P2( bool wbgen )
      {
         if ( wbgen )
         {
            /* Table start */
            sStyleString = "";
            GxWebStd.gx_table_start( context, tblTablemergedclicod_Internalname, tblTablemergedclicod_Internalname, "", "TableMerged", 0, "", "", 0, 0, sStyleString, "", "", 0);
            context.WriteHtmlText( "<tr>") ;
            context.WriteHtmlText( "<td class='MergeDataCell'>") ;
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "left", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavClicod_Internalname, "Codigo Cliente", "gx-form-item AttributeLabel", 0, true, "width: 25%;");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 77,'',false,'',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavClicod_Internalname, StringUtil.RTrim( AV5CliCod), StringUtil.RTrim( context.localUtil.Format( AV5CliCod, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,77);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavClicod_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtavClicod_Enabled, 0, "text", "", 20, "chr", 1, "row", 20, 0, 0, 0, 1, -1, -1, true, "", "left", true, "", "HLP_Ventas\\R_VentasProductos.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "<td class='CellPaddingLeft10'>") ;
            /* Active images/pictures */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 79,'',false,'',0)\"";
            ClassString = "Image";
            StyleString = "";
            sImgUrl = (string)(context.GetImagePath( "f5b04895-0024-488b-8e3b-b687ca4598ee", "", context.GetTheme( )));
            GxWebStd.gx_bitmap( context, imgBtnbuscar_Internalname, sImgUrl, "", "", "", context.GetTheme( ), 1, 1, "", "Buscar Cliente", 0, 0, 0, "px", 0, "px", 0, 0, 7, imgBtnbuscar_Jsonclick, "'"+""+"'"+",false,"+"'"+"e175p1_client"+"'", StyleString, ClassString, "", "", "", "", " "+"data-gx-image"+" "+TempTags, "", "", 1, false, false, context.GetImageSrcSet( sImgUrl), "HLP_Ventas\\R_VentasProductos.htm");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "<td class='DataContentCell'>") ;
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "left", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavClidsc_Internalname, "Descripción Cliente", "gx-form-item ReadonlyAttributeLabel", 0, true, "width: 25%;");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 82,'',false,'',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavClidsc_Internalname, StringUtil.RTrim( AV7CliDsc), StringUtil.RTrim( context.localUtil.Format( AV7CliDsc, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,82);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavClidsc_Jsonclick, 0, "ReadonlyAttribute", "", "", "", "", 1, edtavClidsc_Enabled, 0, "text", "", 80, "chr", 1, "row", 100, 0, 0, 0, 1, -1, -1, true, "", "left", true, "", "HLP_Ventas\\R_VentasProductos.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "</tr>") ;
            /* End of table */
            context.WriteHtmlText( "</table>") ;
            wb_table1_73_5P2e( true) ;
         }
         else
         {
            wb_table1_73_5P2e( false) ;
         }
      }

      public override void setparameters( Object[] obj )
      {
         createObjects();
         initialize();
      }

      public override string getresponse( string sGXDynURL )
      {
         initialize_properties( ) ;
         BackMsgLst = context.GX_msglist;
         context.GX_msglist = LclMsgLst;
         sDynURL = sGXDynURL;
         nGotPars = (short)(1);
         nGXWrapped = (short)(1);
         context.SetWrapped(true);
         PA5P2( ) ;
         WS5P2( ) ;
         WE5P2( ) ;
         this.cleanup();
         context.SetWrapped(false);
         context.GX_msglist = BackMsgLst;
         return "";
      }

      public void responsestatic( string sGXDynURL )
      {
      }

      protected void define_styles( )
      {
         AddStyleSheetFile("calendar-system.css", "");
         AddThemeStyleSheetFile("", context.GetTheme( )+".css", "?"+GetCacheInvalidationToken( ));
         bool outputEnabled = isOutputEnabled( );
         if ( context.isSpaRequest( ) )
         {
            enableOutput();
         }
         idxLst = 1;
         while ( idxLst <= Form.Jscriptsrc.Count )
         {
            context.AddJavascriptSource(StringUtil.RTrim( ((string)Form.Jscriptsrc.Item(idxLst))), "?202281810315676", true, true);
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
         context.AddJavascriptSource("ventas/r_ventasproductos.js", "?202281810315676", false, true);
         context.AddJavascriptSource("DVelop/Bootstrap/Shared/DVelopBootstrap.js", "", false, true);
         context.AddJavascriptSource("DVelop/Shared/WorkWithPlusCommon.js", "", false, true);
         context.AddJavascriptSource("DVelop/Bootstrap/Panel/BootstrapPanelRender.js", "", false, true);
         context.AddJavascriptSource("DVelop/Bootstrap/Shared/DVelopBootstrap.js", "", false, true);
         context.AddJavascriptSource("DVelop/Shared/WorkWithPlusCommon.js", "", false, true);
         context.AddJavascriptSource("DVelop/Bootstrap/DropDownOptions/BootstrapDropDownOptionsRender.js", "", false, true);
         context.AddJavascriptSource("DVelop/Bootstrap/Shared/DVelopBootstrap.js", "", false, true);
         context.AddJavascriptSource("DVelop/Shared/WorkWithPlusCommon.js", "", false, true);
         context.AddJavascriptSource("DVelop/Bootstrap/DropDownOptions/BootstrapDropDownOptionsRender.js", "", false, true);
         context.AddJavascriptSource("DVelop/Bootstrap/Shared/DVelopBootstrap.js", "", false, true);
         context.AddJavascriptSource("DVelop/Shared/WorkWithPlusCommon.js", "", false, true);
         context.AddJavascriptSource("DVelop/Bootstrap/DropDownOptions/BootstrapDropDownOptionsRender.js", "", false, true);
         context.AddJavascriptSource("DVelop/Bootstrap/Shared/DVelopBootstrap.js", "", false, true);
         context.AddJavascriptSource("DVelop/Shared/WorkWithPlusCommon.js", "", false, true);
         context.AddJavascriptSource("DVelop/Bootstrap/DropDownOptions/BootstrapDropDownOptionsRender.js", "", false, true);
         context.AddJavascriptSource("DVelop/Bootstrap/Shared/DVelopBootstrap.js", "", false, true);
         context.AddJavascriptSource("DVelop/Shared/WorkWithPlusCommon.js", "", false, true);
         context.AddJavascriptSource("DVelop/Bootstrap/DropDownOptions/BootstrapDropDownOptionsRender.js", "", false, true);
         context.AddJavascriptSource("DVelop/Bootstrap/Shared/DVelopBootstrap.js", "", false, true);
         context.AddJavascriptSource("DVelop/Shared/WorkWithPlusCommon.js", "", false, true);
         context.AddJavascriptSource("DVelop/Bootstrap/DropDownOptions/BootstrapDropDownOptionsRender.js", "", false, true);
         context.AddJavascriptSource("Window/InNewWindowRender.js", "", false, true);
         /* End function include_jscripts */
      }

      protected void init_web_controls( )
      {
         radavTipo.Name = "vTIPO";
         radavTipo.WebTags = "";
         radavTipo.addItem("T", "Todos", 0);
         radavTipo.addItem("V", "Ventas", 0);
         radavTipo.addItem("M", "Muestras", 0);
         chkavCheckrec.Name = "vCHECKREC";
         chkavCheckrec.WebTags = "";
         chkavCheckrec.Caption = "¿Desea Inlcuir Recibos?";
         AssignProp("", false, chkavCheckrec_Internalname, "TitleCaption", chkavCheckrec.Caption, true);
         chkavCheckrec.CheckedValue = "0";
         AV43CheckRec = (short)(((StringUtil.StrCmp(StringUtil.LTrim( StringUtil.NToC( (decimal)(AV43CheckRec), 1, 0, ".", "")), "1")==0) ? 1 : 0));
         AssignAttri("", false, "AV43CheckRec", StringUtil.Str( (decimal)(AV43CheckRec), 1, 0));
         /* End function init_web_controls */
      }

      protected void init_default_properties( )
      {
         lblTextblockcombo_tiecod_Internalname = "TEXTBLOCKCOMBO_TIECOD";
         Combo_tiecod_Internalname = "COMBO_TIECOD";
         divTablesplittedtiecod_Internalname = "TABLESPLITTEDTIECOD";
         lblTextblockcombo_tipccod_Internalname = "TEXTBLOCKCOMBO_TIPCCOD";
         Combo_tipccod_Internalname = "COMBO_TIPCCOD";
         divTablesplittedtipccod_Internalname = "TABLESPLITTEDTIPCCOD";
         lblTextblockcombo_lincod_Internalname = "TEXTBLOCKCOMBO_LINCOD";
         Combo_lincod_Internalname = "COMBO_LINCOD";
         divTablesplittedlincod_Internalname = "TABLESPLITTEDLINCOD";
         lblTextblockcombo_sublcod_Internalname = "TEXTBLOCKCOMBO_SUBLCOD";
         Combo_sublcod_Internalname = "COMBO_SUBLCOD";
         divTablesplittedsublcod_Internalname = "TABLESPLITTEDSUBLCOD";
         lblTextblockcombo_zoncod_Internalname = "TEXTBLOCKCOMBO_ZONCOD";
         Combo_zoncod_Internalname = "COMBO_ZONCOD";
         divTablesplittedzoncod_Internalname = "TABLESPLITTEDZONCOD";
         lblTextblockcombo_vencod_Internalname = "TEXTBLOCKCOMBO_VENCOD";
         Combo_vencod_Internalname = "COMBO_VENCOD";
         divTablesplittedvencod_Internalname = "TABLESPLITTEDVENCOD";
         lblTextblockclicod_Internalname = "TEXTBLOCKCLICOD";
         edtavClicod_Internalname = "vCLICOD";
         imgBtnbuscar_Internalname = "BTNBUSCAR";
         edtavClidsc_Internalname = "vCLIDSC";
         tblTablemergedclicod_Internalname = "TABLEMERGEDCLICOD";
         divTablesplittedclicod_Internalname = "TABLESPLITTEDCLICOD";
         lblTextblockprodcod_Internalname = "TEXTBLOCKPRODCOD";
         edtavProdcod_Internalname = "vPRODCOD";
         imgBtnbuscarpro_Internalname = "BTNBUSCARPRO";
         edtavProddsc_Internalname = "vPRODDSC";
         tblTablemergedprodcod_Internalname = "TABLEMERGEDPRODCOD";
         divTablesplittedprodcod_Internalname = "TABLESPLITTEDPRODCOD";
         lblTextblockfdesde_Internalname = "TEXTBLOCKFDESDE";
         edtavFdesde_Internalname = "vFDESDE";
         edtavFhasta_Internalname = "vFHASTA";
         tblTablemergedfdesde_Internalname = "TABLEMERGEDFDESDE";
         divTablesplittedfdesde_Internalname = "TABLESPLITTEDFDESDE";
         lblTextblocktipo_Internalname = "TEXTBLOCKTIPO";
         radavTipo_Internalname = "vTIPO";
         divUnnamedtabletipo_Internalname = "UNNAMEDTABLETIPO";
         lblTextblockcheckrec_Internalname = "TEXTBLOCKCHECKREC";
         chkavCheckrec_Internalname = "vCHECKREC";
         divUnnamedtablecheckrec_Internalname = "UNNAMEDTABLECHECKREC";
         divPanel_Internalname = "PANEL";
         Dvpanel_panel_Internalname = "DVPANEL_PANEL";
         bttBtnbtnimprimir_Internalname = "BTNBTNIMPRIMIR";
         bttBtnbtnexcel_Internalname = "BTNBTNEXCEL";
         bttBtnbtnsalir_Internalname = "BTNBTNSALIR";
         Innewwindow_Internalname = "INNEWWINDOW";
         divTablecontent_Internalname = "TABLECONTENT";
         divTablemain_Internalname = "TABLEMAIN";
         edtavTiecod_Internalname = "vTIECOD";
         edtavTipccod_Internalname = "vTIPCCOD";
         edtavLincod_Internalname = "vLINCOD";
         edtavSublcod_Internalname = "vSUBLCOD";
         edtavZoncod_Internalname = "vZONCOD";
         edtavVencod_Internalname = "vVENCOD";
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
         chkavCheckrec.Caption = "Check Rec";
         edtavClidsc_Jsonclick = "";
         edtavClidsc_Enabled = 1;
         edtavClicod_Jsonclick = "";
         edtavClicod_Enabled = 1;
         edtavProddsc_Jsonclick = "";
         edtavProddsc_Enabled = 1;
         edtavProdcod_Jsonclick = "";
         edtavProdcod_Enabled = 1;
         edtavFhasta_Jsonclick = "";
         edtavFhasta_Enabled = 1;
         edtavFdesde_Jsonclick = "";
         edtavFdesde_Enabled = 1;
         edtavVencod_Jsonclick = "";
         edtavVencod_Visible = 1;
         edtavZoncod_Jsonclick = "";
         edtavZoncod_Visible = 1;
         edtavSublcod_Jsonclick = "";
         edtavSublcod_Visible = 1;
         edtavLincod_Jsonclick = "";
         edtavLincod_Visible = 1;
         edtavTipccod_Jsonclick = "";
         edtavTipccod_Visible = 1;
         edtavTiecod_Jsonclick = "";
         edtavTiecod_Visible = 1;
         chkavCheckrec.Enabled = 1;
         radavTipo_Jsonclick = "";
         Innewwindow_Target = "";
         Dvpanel_panel_Autoscroll = Convert.ToBoolean( 0);
         Dvpanel_panel_Iconposition = "Right";
         Dvpanel_panel_Showcollapseicon = Convert.ToBoolean( 0);
         Dvpanel_panel_Collapsed = Convert.ToBoolean( 0);
         Dvpanel_panel_Collapsible = Convert.ToBoolean( -1);
         Dvpanel_panel_Title = "Resumen de Pedidos por producto";
         Dvpanel_panel_Cls = "PanelFilled Panel_BaseColor";
         Dvpanel_panel_Autoheight = Convert.ToBoolean( -1);
         Dvpanel_panel_Autowidth = Convert.ToBoolean( 0);
         Dvpanel_panel_Width = "100%";
         Combo_vencod_Cls = "ExtendedCombo AttributeRealWidth50With";
         Combo_zoncod_Cls = "ExtendedCombo AttributeRealWidth50With";
         Combo_sublcod_Cls = "ExtendedCombo AttributeRealWidth50With";
         Combo_lincod_Cls = "ExtendedCombo AttributeRealWidth50With";
         Combo_tipccod_Cls = "ExtendedCombo AttributeRealWidth50With";
         Combo_tiecod_Cls = "ExtendedCombo AttributeRealWidth50With";
         Form.Headerrawhtml = "";
         Form.Background = "";
         Form.Textcolor = 0;
         Form.Backcolor = (int)(0xFFFFFF);
         Form.Caption = "Resumen de Pedidos por producto";
         context.GX_msglist.DisplayMode = 1;
         if ( context.isSpaRequest( ) )
         {
            enableJsOutput();
         }
      }

      public override bool SupportAjaxEvent( )
      {
         return true ;
      }

      public override void InitializeDynEvents( )
      {
         setEventMetadata("REFRESH","{handler:'Refresh',iparms:[{av:'radavTipo'},{av:'AV37Tipo',fld:'vTIPO',pic:''},{av:'AV43CheckRec',fld:'vCHECKREC',pic:'9'}]");
         setEventMetadata("REFRESH",",oparms:[{av:'radavTipo'},{av:'AV37Tipo',fld:'vTIPO',pic:''},{av:'AV43CheckRec',fld:'vCHECKREC',pic:'9'}]}");
         setEventMetadata("'DOBTNIMPRIMIR'","{handler:'E125P2',iparms:[{av:'AV18LinCod',fld:'vLINCOD',pic:'ZZZZZ9'},{av:'AV29SublCod',fld:'vSUBLCOD',pic:'ZZZZZ9'},{av:'AV25ProdCod',fld:'vPRODCOD',pic:'@!'},{av:'AV13FDesde',fld:'vFDESDE',pic:''},{av:'AV15FHasta',fld:'vFHASTA',pic:''},{av:'AV5CliCod',fld:'vCLICOD',pic:''},{av:'AV44ZonCod',fld:'vZONCOD',pic:'ZZZZZ9'},{av:'AV41VenCod',fld:'vVENCOD',pic:'ZZZZZ9'},{av:'AV31TieCod',fld:'vTIECOD',pic:'ZZZZZ9'},{av:'AV33TipCCod',fld:'vTIPCCOD',pic:'ZZZZZ9'},{av:'radavTipo'},{av:'AV37Tipo',fld:'vTIPO',pic:''},{av:'AV43CheckRec',fld:'vCHECKREC',pic:'9'}]");
         setEventMetadata("'DOBTNIMPRIMIR'",",oparms:[{av:'Innewwindow_Target',ctrl:'INNEWWINDOW',prop:'Target'},{av:'radavTipo'},{av:'AV37Tipo',fld:'vTIPO',pic:''},{av:'AV43CheckRec',fld:'vCHECKREC',pic:'9'}]}");
         setEventMetadata("'DOBTNEXCEL'","{handler:'E135P2',iparms:[{av:'AV18LinCod',fld:'vLINCOD',pic:'ZZZZZ9'},{av:'AV29SublCod',fld:'vSUBLCOD',pic:'ZZZZZ9'},{av:'AV25ProdCod',fld:'vPRODCOD',pic:'@!'},{av:'AV13FDesde',fld:'vFDESDE',pic:''},{av:'AV15FHasta',fld:'vFHASTA',pic:''},{av:'AV5CliCod',fld:'vCLICOD',pic:''},{av:'AV44ZonCod',fld:'vZONCOD',pic:'ZZZZZ9'},{av:'AV41VenCod',fld:'vVENCOD',pic:'ZZZZZ9'},{av:'AV31TieCod',fld:'vTIECOD',pic:'ZZZZZ9'},{av:'AV33TipCCod',fld:'vTIPCCOD',pic:'ZZZZZ9'},{av:'radavTipo'},{av:'AV37Tipo',fld:'vTIPO',pic:''},{av:'AV43CheckRec',fld:'vCHECKREC',pic:'9'}]");
         setEventMetadata("'DOBTNEXCEL'",",oparms:[{av:'AV33TipCCod',fld:'vTIPCCOD',pic:'ZZZZZ9'},{av:'AV31TieCod',fld:'vTIECOD',pic:'ZZZZZ9'},{av:'AV41VenCod',fld:'vVENCOD',pic:'ZZZZZ9'},{av:'AV44ZonCod',fld:'vZONCOD',pic:'ZZZZZ9'},{av:'AV5CliCod',fld:'vCLICOD',pic:''},{av:'AV15FHasta',fld:'vFHASTA',pic:''},{av:'AV13FDesde',fld:'vFDESDE',pic:''},{av:'AV25ProdCod',fld:'vPRODCOD',pic:'@!'},{av:'AV29SublCod',fld:'vSUBLCOD',pic:'ZZZZZ9'},{av:'AV18LinCod',fld:'vLINCOD',pic:'ZZZZZ9'},{av:'radavTipo'},{av:'AV37Tipo',fld:'vTIPO',pic:''},{av:'AV43CheckRec',fld:'vCHECKREC',pic:'9'}]}");
         setEventMetadata("'DOBTNSALIR'","{handler:'E145P2',iparms:[{av:'radavTipo'},{av:'AV37Tipo',fld:'vTIPO',pic:''},{av:'AV43CheckRec',fld:'vCHECKREC',pic:'9'}]");
         setEventMetadata("'DOBTNSALIR'",",oparms:[{av:'radavTipo'},{av:'AV37Tipo',fld:'vTIPO',pic:''},{av:'AV43CheckRec',fld:'vCHECKREC',pic:'9'}]}");
         setEventMetadata("'DOBTNBUSCAR'","{handler:'E175P1',iparms:[{av:'radavTipo'},{av:'AV37Tipo',fld:'vTIPO',pic:''},{av:'AV43CheckRec',fld:'vCHECKREC',pic:'9'}]");
         setEventMetadata("'DOBTNBUSCAR'",",oparms:[{av:'AV7CliDsc',fld:'vCLIDSC',pic:''},{av:'AV5CliCod',fld:'vCLICOD',pic:''},{av:'radavTipo'},{av:'AV37Tipo',fld:'vTIPO',pic:''},{av:'AV43CheckRec',fld:'vCHECKREC',pic:'9'}]}");
         setEventMetadata("'DOBTNBUSCARPRO'","{handler:'E165P1',iparms:[{av:'radavTipo'},{av:'AV37Tipo',fld:'vTIPO',pic:''},{av:'AV43CheckRec',fld:'vCHECKREC',pic:'9'}]");
         setEventMetadata("'DOBTNBUSCARPRO'",",oparms:[{av:'AV26ProdDsc',fld:'vPRODDSC',pic:''},{av:'AV25ProdCod',fld:'vPRODCOD',pic:'@!'},{av:'radavTipo'},{av:'AV37Tipo',fld:'vTIPO',pic:''},{av:'AV43CheckRec',fld:'vCHECKREC',pic:'9'}]}");
         setEventMetadata("VALIDV_FDESDE","{handler:'Validv_Fdesde',iparms:[{av:'radavTipo'},{av:'AV37Tipo',fld:'vTIPO',pic:''},{av:'AV43CheckRec',fld:'vCHECKREC',pic:'9'}]");
         setEventMetadata("VALIDV_FDESDE",",oparms:[{av:'radavTipo'},{av:'AV37Tipo',fld:'vTIPO',pic:''},{av:'AV43CheckRec',fld:'vCHECKREC',pic:'9'}]}");
         setEventMetadata("VALIDV_FHASTA","{handler:'Validv_Fhasta',iparms:[{av:'radavTipo'},{av:'AV37Tipo',fld:'vTIPO',pic:''},{av:'AV43CheckRec',fld:'vCHECKREC',pic:'9'}]");
         setEventMetadata("VALIDV_FHASTA",",oparms:[{av:'radavTipo'},{av:'AV37Tipo',fld:'vTIPO',pic:''},{av:'AV43CheckRec',fld:'vCHECKREC',pic:'9'}]}");
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
      }

      public override void initialize( )
      {
         Combo_vencod_Selectedvalue_get = "";
         Combo_zoncod_Selectedvalue_get = "";
         Combo_sublcod_Selectedvalue_get = "";
         Combo_lincod_Selectedvalue_get = "";
         Combo_tipccod_Selectedvalue_get = "";
         Combo_tiecod_Selectedvalue_get = "";
         gxfirstwebparm = "";
         gxfirstwebparm_bkp = "";
         sDynURL = "";
         FormProcess = "";
         bodyStyle = "";
         GXKey = "";
         AV32TieCod_Data = new GXBaseCollection<GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTComboData_Item>( context, "Item", "");
         AV34TipCCod_Data = new GXBaseCollection<GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTComboData_Item>( context, "Item", "");
         AV19LinCod_Data = new GXBaseCollection<GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTComboData_Item>( context, "Item", "");
         AV30SublCod_Data = new GXBaseCollection<GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTComboData_Item>( context, "Item", "");
         AV45ZonCod_Data = new GXBaseCollection<GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTComboData_Item>( context, "Item", "");
         AV42VenCod_Data = new GXBaseCollection<GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTComboData_Item>( context, "Item", "");
         Combo_tiecod_Selectedvalue_set = "";
         Combo_tipccod_Selectedvalue_set = "";
         Combo_lincod_Selectedvalue_set = "";
         Combo_sublcod_Selectedvalue_set = "";
         Combo_zoncod_Selectedvalue_set = "";
         Combo_vencod_Selectedvalue_set = "";
         GX_FocusControl = "";
         Form = new GXWebForm();
         sPrefix = "";
         ClassString = "";
         StyleString = "";
         ucDvpanel_panel = new GXUserControl();
         lblTextblockcombo_tiecod_Jsonclick = "";
         ucCombo_tiecod = new GXUserControl();
         Combo_tiecod_Caption = "";
         lblTextblockcombo_tipccod_Jsonclick = "";
         ucCombo_tipccod = new GXUserControl();
         Combo_tipccod_Caption = "";
         lblTextblockcombo_lincod_Jsonclick = "";
         ucCombo_lincod = new GXUserControl();
         Combo_lincod_Caption = "";
         lblTextblockcombo_sublcod_Jsonclick = "";
         ucCombo_sublcod = new GXUserControl();
         Combo_sublcod_Caption = "";
         lblTextblockcombo_zoncod_Jsonclick = "";
         ucCombo_zoncod = new GXUserControl();
         Combo_zoncod_Caption = "";
         lblTextblockcombo_vencod_Jsonclick = "";
         ucCombo_vencod = new GXUserControl();
         Combo_vencod_Caption = "";
         lblTextblockclicod_Jsonclick = "";
         lblTextblockprodcod_Jsonclick = "";
         lblTextblockfdesde_Jsonclick = "";
         lblTextblocktipo_Jsonclick = "";
         TempTags = "";
         AV37Tipo = "";
         lblTextblockcheckrec_Jsonclick = "";
         bttBtnbtnimprimir_Jsonclick = "";
         bttBtnbtnexcel_Jsonclick = "";
         bttBtnbtnsalir_Jsonclick = "";
         ucInnewwindow = new GXUserControl();
         sEvt = "";
         EvtGridId = "";
         EvtRowId = "";
         sEvtType = "";
         AV5CliCod = "";
         AV7CliDsc = "";
         AV25ProdCod = "";
         AV26ProdDsc = "";
         AV13FDesde = DateTime.MinValue;
         AV15FHasta = DateTime.MinValue;
         GXEncryptionTmp = "";
         AV10ExcelFilename = "";
         AV9ErrorMessage = "";
         scmdbuf = "";
         H005P2_A2047VenSts = new short[1] ;
         H005P2_A309VenCod = new int[1] ;
         H005P2_A2045VenDsc = new string[] {""} ;
         A2045VenDsc = "";
         AV8Combo_DataItem = new GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTComboData_Item(context);
         H005P3_A2095ZonSts = new short[1] ;
         H005P3_A158ZonCod = new int[1] ;
         H005P3_A2094ZonDsc = new string[] {""} ;
         A2094ZonDsc = "";
         H005P4_A1893SublSts = new short[1] ;
         H005P4_A51SublCod = new int[1] ;
         H005P4_A1892SublDsc = new string[] {""} ;
         A1892SublDsc = "";
         H005P5_A1159LinSts = new short[1] ;
         H005P5_A52LinCod = new int[1] ;
         H005P5_A1153LinDsc = new string[] {""} ;
         A1153LinDsc = "";
         H005P6_A1908TipCSts = new short[1] ;
         H005P6_A159TipCCod = new int[1] ;
         H005P6_A1905TipCDsc = new string[] {""} ;
         A1905TipCDsc = "";
         H005P7_A1899TieSts = new short[1] ;
         H005P7_A178TieCod = new int[1] ;
         H005P7_A1898TieDsc = new string[] {""} ;
         A1898TieDsc = "";
         sStyleString = "";
         sImgUrl = "";
         imgBtnbuscarpro_Jsonclick = "";
         imgBtnbuscar_Jsonclick = "";
         BackMsgLst = new msglist();
         LclMsgLst = new msglist();
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.ventas.r_ventasproductos__default(),
            new Object[][] {
                new Object[] {
               H005P2_A2047VenSts, H005P2_A309VenCod, H005P2_A2045VenDsc
               }
               , new Object[] {
               H005P3_A2095ZonSts, H005P3_A158ZonCod, H005P3_A2094ZonDsc
               }
               , new Object[] {
               H005P4_A1893SublSts, H005P4_A51SublCod, H005P4_A1892SublDsc
               }
               , new Object[] {
               H005P5_A1159LinSts, H005P5_A52LinCod, H005P5_A1153LinDsc
               }
               , new Object[] {
               H005P6_A1908TipCSts, H005P6_A159TipCCod, H005P6_A1905TipCDsc
               }
               , new Object[] {
               H005P7_A1899TieSts, H005P7_A178TieCod, H005P7_A1898TieDsc
               }
            }
         );
         AV37Tipo = "P";
         /* GeneXus formulas. */
         context.Gx_err = 0;
         edtavClidsc_Enabled = 0;
         edtavProddsc_Enabled = 0;
      }

      private short nRcdExists_8 ;
      private short nIsMod_8 ;
      private short nRcdExists_7 ;
      private short nIsMod_7 ;
      private short nRcdExists_6 ;
      private short nIsMod_6 ;
      private short nRcdExists_5 ;
      private short nIsMod_5 ;
      private short nRcdExists_4 ;
      private short nIsMod_4 ;
      private short nRcdExists_3 ;
      private short nIsMod_3 ;
      private short nGotPars ;
      private short GxWebError ;
      private short initialized ;
      private short gxajaxcallmode ;
      private short wbEnd ;
      private short wbStart ;
      private short AV43CheckRec ;
      private short nDonePA ;
      private short A2047VenSts ;
      private short A2095ZonSts ;
      private short A1893SublSts ;
      private short A1159LinSts ;
      private short A1908TipCSts ;
      private short A1899TieSts ;
      private short nGXWrapped ;
      private int AV31TieCod ;
      private int edtavTiecod_Visible ;
      private int AV33TipCCod ;
      private int edtavTipccod_Visible ;
      private int AV18LinCod ;
      private int edtavLincod_Visible ;
      private int AV29SublCod ;
      private int edtavSublcod_Visible ;
      private int AV44ZonCod ;
      private int edtavZoncod_Visible ;
      private int AV41VenCod ;
      private int edtavVencod_Visible ;
      private int edtavClidsc_Enabled ;
      private int edtavProddsc_Enabled ;
      private int A309VenCod ;
      private int A158ZonCod ;
      private int A51SublCod ;
      private int A52LinCod ;
      private int A159TipCCod ;
      private int A178TieCod ;
      private int edtavFdesde_Enabled ;
      private int edtavFhasta_Enabled ;
      private int edtavProdcod_Enabled ;
      private int edtavClicod_Enabled ;
      private int idxLst ;
      private string Combo_vencod_Selectedvalue_get ;
      private string Combo_zoncod_Selectedvalue_get ;
      private string Combo_sublcod_Selectedvalue_get ;
      private string Combo_lincod_Selectedvalue_get ;
      private string Combo_tipccod_Selectedvalue_get ;
      private string Combo_tiecod_Selectedvalue_get ;
      private string gxfirstwebparm ;
      private string gxfirstwebparm_bkp ;
      private string sDynURL ;
      private string FormProcess ;
      private string bodyStyle ;
      private string GXKey ;
      private string Combo_tiecod_Cls ;
      private string Combo_tiecod_Selectedvalue_set ;
      private string Combo_tipccod_Cls ;
      private string Combo_tipccod_Selectedvalue_set ;
      private string Combo_lincod_Cls ;
      private string Combo_lincod_Selectedvalue_set ;
      private string Combo_sublcod_Cls ;
      private string Combo_sublcod_Selectedvalue_set ;
      private string Combo_zoncod_Cls ;
      private string Combo_zoncod_Selectedvalue_set ;
      private string Combo_vencod_Cls ;
      private string Combo_vencod_Selectedvalue_set ;
      private string Dvpanel_panel_Width ;
      private string Dvpanel_panel_Cls ;
      private string Dvpanel_panel_Title ;
      private string Dvpanel_panel_Iconposition ;
      private string Innewwindow_Target ;
      private string GX_FocusControl ;
      private string sPrefix ;
      private string divLayoutmaintable_Internalname ;
      private string divTablemain_Internalname ;
      private string ClassString ;
      private string StyleString ;
      private string divTablecontent_Internalname ;
      private string Dvpanel_panel_Internalname ;
      private string divPanel_Internalname ;
      private string divTablesplittedtiecod_Internalname ;
      private string lblTextblockcombo_tiecod_Internalname ;
      private string lblTextblockcombo_tiecod_Jsonclick ;
      private string Combo_tiecod_Caption ;
      private string Combo_tiecod_Internalname ;
      private string divTablesplittedtipccod_Internalname ;
      private string lblTextblockcombo_tipccod_Internalname ;
      private string lblTextblockcombo_tipccod_Jsonclick ;
      private string Combo_tipccod_Caption ;
      private string Combo_tipccod_Internalname ;
      private string divTablesplittedlincod_Internalname ;
      private string lblTextblockcombo_lincod_Internalname ;
      private string lblTextblockcombo_lincod_Jsonclick ;
      private string Combo_lincod_Caption ;
      private string Combo_lincod_Internalname ;
      private string divTablesplittedsublcod_Internalname ;
      private string lblTextblockcombo_sublcod_Internalname ;
      private string lblTextblockcombo_sublcod_Jsonclick ;
      private string Combo_sublcod_Caption ;
      private string Combo_sublcod_Internalname ;
      private string divTablesplittedzoncod_Internalname ;
      private string lblTextblockcombo_zoncod_Internalname ;
      private string lblTextblockcombo_zoncod_Jsonclick ;
      private string Combo_zoncod_Caption ;
      private string Combo_zoncod_Internalname ;
      private string divTablesplittedvencod_Internalname ;
      private string lblTextblockcombo_vencod_Internalname ;
      private string lblTextblockcombo_vencod_Jsonclick ;
      private string Combo_vencod_Caption ;
      private string Combo_vencod_Internalname ;
      private string divTablesplittedclicod_Internalname ;
      private string lblTextblockclicod_Internalname ;
      private string lblTextblockclicod_Jsonclick ;
      private string divTablesplittedprodcod_Internalname ;
      private string lblTextblockprodcod_Internalname ;
      private string lblTextblockprodcod_Jsonclick ;
      private string divTablesplittedfdesde_Internalname ;
      private string lblTextblockfdesde_Internalname ;
      private string lblTextblockfdesde_Jsonclick ;
      private string divUnnamedtabletipo_Internalname ;
      private string lblTextblocktipo_Internalname ;
      private string lblTextblocktipo_Jsonclick ;
      private string TempTags ;
      private string radavTipo_Internalname ;
      private string radavTipo_Jsonclick ;
      private string divUnnamedtablecheckrec_Internalname ;
      private string lblTextblockcheckrec_Internalname ;
      private string lblTextblockcheckrec_Jsonclick ;
      private string chkavCheckrec_Internalname ;
      private string bttBtnbtnimprimir_Internalname ;
      private string bttBtnbtnimprimir_Jsonclick ;
      private string bttBtnbtnexcel_Internalname ;
      private string bttBtnbtnexcel_Jsonclick ;
      private string bttBtnbtnsalir_Internalname ;
      private string bttBtnbtnsalir_Jsonclick ;
      private string Innewwindow_Internalname ;
      private string divHtml_bottomauxiliarcontrols_Internalname ;
      private string edtavTiecod_Internalname ;
      private string edtavTiecod_Jsonclick ;
      private string edtavTipccod_Internalname ;
      private string edtavTipccod_Jsonclick ;
      private string edtavLincod_Internalname ;
      private string edtavLincod_Jsonclick ;
      private string edtavSublcod_Internalname ;
      private string edtavSublcod_Jsonclick ;
      private string edtavZoncod_Internalname ;
      private string edtavZoncod_Jsonclick ;
      private string edtavVencod_Internalname ;
      private string edtavVencod_Jsonclick ;
      private string sEvt ;
      private string EvtGridId ;
      private string EvtRowId ;
      private string sEvtType ;
      private string edtavClicod_Internalname ;
      private string edtavClidsc_Internalname ;
      private string edtavProddsc_Internalname ;
      private string AV5CliCod ;
      private string AV7CliDsc ;
      private string AV25ProdCod ;
      private string edtavProdcod_Internalname ;
      private string AV26ProdDsc ;
      private string edtavFdesde_Internalname ;
      private string edtavFhasta_Internalname ;
      private string GXEncryptionTmp ;
      private string scmdbuf ;
      private string A2045VenDsc ;
      private string A2094ZonDsc ;
      private string A1892SublDsc ;
      private string A1153LinDsc ;
      private string A1905TipCDsc ;
      private string A1898TieDsc ;
      private string sStyleString ;
      private string tblTablemergedfdesde_Internalname ;
      private string edtavFdesde_Jsonclick ;
      private string edtavFhasta_Jsonclick ;
      private string tblTablemergedprodcod_Internalname ;
      private string edtavProdcod_Jsonclick ;
      private string sImgUrl ;
      private string imgBtnbuscarpro_Internalname ;
      private string imgBtnbuscarpro_Jsonclick ;
      private string edtavProddsc_Jsonclick ;
      private string tblTablemergedclicod_Internalname ;
      private string edtavClicod_Jsonclick ;
      private string imgBtnbuscar_Internalname ;
      private string imgBtnbuscar_Jsonclick ;
      private string edtavClidsc_Jsonclick ;
      private DateTime AV13FDesde ;
      private DateTime AV15FHasta ;
      private bool entryPointCalled ;
      private bool toggleJsOutput ;
      private bool Dvpanel_panel_Autowidth ;
      private bool Dvpanel_panel_Autoheight ;
      private bool Dvpanel_panel_Collapsible ;
      private bool Dvpanel_panel_Collapsed ;
      private bool Dvpanel_panel_Showcollapseicon ;
      private bool Dvpanel_panel_Autoscroll ;
      private bool wbLoad ;
      private bool Rfr0gs ;
      private bool wbErr ;
      private bool gxdyncontrolsrefreshing ;
      private bool returnInSub ;
      private string AV37Tipo ;
      private string AV10ExcelFilename ;
      private string AV9ErrorMessage ;
      private GXUserControl ucDvpanel_panel ;
      private GXUserControl ucCombo_tiecod ;
      private GXUserControl ucCombo_tipccod ;
      private GXUserControl ucCombo_lincod ;
      private GXUserControl ucCombo_sublcod ;
      private GXUserControl ucCombo_zoncod ;
      private GXUserControl ucCombo_vencod ;
      private GXUserControl ucInnewwindow ;
      private IGxDataStore dsDataStore2 ;
      private IGxDataStore dsDefault ;
      private GXRadio radavTipo ;
      private GXCheckbox chkavCheckrec ;
      private IDataStoreProvider pr_default ;
      private short[] H005P2_A2047VenSts ;
      private int[] H005P2_A309VenCod ;
      private string[] H005P2_A2045VenDsc ;
      private short[] H005P3_A2095ZonSts ;
      private int[] H005P3_A158ZonCod ;
      private string[] H005P3_A2094ZonDsc ;
      private short[] H005P4_A1893SublSts ;
      private int[] H005P4_A51SublCod ;
      private string[] H005P4_A1892SublDsc ;
      private short[] H005P5_A1159LinSts ;
      private int[] H005P5_A52LinCod ;
      private string[] H005P5_A1153LinDsc ;
      private short[] H005P6_A1908TipCSts ;
      private int[] H005P6_A159TipCCod ;
      private string[] H005P6_A1905TipCDsc ;
      private short[] H005P7_A1899TieSts ;
      private int[] H005P7_A178TieCod ;
      private string[] H005P7_A1898TieDsc ;
      private msglist BackMsgLst ;
      private msglist LclMsgLst ;
      private GXBaseCollection<GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTComboData_Item> AV32TieCod_Data ;
      private GXBaseCollection<GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTComboData_Item> AV34TipCCod_Data ;
      private GXBaseCollection<GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTComboData_Item> AV19LinCod_Data ;
      private GXBaseCollection<GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTComboData_Item> AV30SublCod_Data ;
      private GXBaseCollection<GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTComboData_Item> AV45ZonCod_Data ;
      private GXBaseCollection<GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTComboData_Item> AV42VenCod_Data ;
      private GXWebForm Form ;
      private GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTComboData_Item AV8Combo_DataItem ;
   }

   public class r_ventasproductos__default : DataStoreHelperBase, IDataStoreHelper
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
       };
    }

    private static CursorDef[] def;
    private void cursorDefinitions( )
    {
       if ( def == null )
       {
          Object[] prmH005P2;
          prmH005P2 = new Object[] {
          };
          Object[] prmH005P3;
          prmH005P3 = new Object[] {
          };
          Object[] prmH005P4;
          prmH005P4 = new Object[] {
          };
          Object[] prmH005P5;
          prmH005P5 = new Object[] {
          };
          Object[] prmH005P6;
          prmH005P6 = new Object[] {
          };
          Object[] prmH005P7;
          prmH005P7 = new Object[] {
          };
          def= new CursorDef[] {
              new CursorDef("H005P2", "SELECT [VenSts], [VenCod], [VenDsc] FROM [CVENDEDORES] WHERE [VenSts] = 1 ORDER BY [VenDsc] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH005P2,100, GxCacheFrequency.OFF ,false,false )
             ,new CursorDef("H005P3", "SELECT [ZonSts], [ZonCod], [ZonDsc] FROM [CZONAS] WHERE [ZonSts] = 1 ORDER BY [ZonDsc] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH005P3,100, GxCacheFrequency.OFF ,false,false )
             ,new CursorDef("H005P4", "SELECT [SublSts], [SublCod], [SublDsc] FROM [CSUBLPROD] WHERE [SublSts] = 1 ORDER BY [SublDsc] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH005P4,100, GxCacheFrequency.OFF ,false,false )
             ,new CursorDef("H005P5", "SELECT [LinSts], [LinCod], [LinDsc] FROM [CLINEAPROD] WHERE [LinSts] = 1 ORDER BY [LinDsc] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH005P5,100, GxCacheFrequency.OFF ,false,false )
             ,new CursorDef("H005P6", "SELECT [TipCSts], [TipCCod], [TipCDsc] FROM [CTIPOCLIENTE] WHERE [TipCSts] = 1 ORDER BY [TipCDsc] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH005P6,100, GxCacheFrequency.OFF ,false,false )
             ,new CursorDef("H005P7", "SELECT [TieSts], [TieCod], [TieDsc] FROM [SGTIENDAS] WHERE [TieSts] = 1 ORDER BY [TieDsc] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH005P7,100, GxCacheFrequency.OFF ,false,false )
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
                ((int[]) buf[1])[0] = rslt.getInt(2);
                ((string[]) buf[2])[0] = rslt.getString(3, 100);
                return;
             case 1 :
                ((short[]) buf[0])[0] = rslt.getShort(1);
                ((int[]) buf[1])[0] = rslt.getInt(2);
                ((string[]) buf[2])[0] = rslt.getString(3, 100);
                return;
             case 2 :
                ((short[]) buf[0])[0] = rslt.getShort(1);
                ((int[]) buf[1])[0] = rslt.getInt(2);
                ((string[]) buf[2])[0] = rslt.getString(3, 100);
                return;
             case 3 :
                ((short[]) buf[0])[0] = rslt.getShort(1);
                ((int[]) buf[1])[0] = rslt.getInt(2);
                ((string[]) buf[2])[0] = rslt.getString(3, 100);
                return;
             case 4 :
                ((short[]) buf[0])[0] = rslt.getShort(1);
                ((int[]) buf[1])[0] = rslt.getInt(2);
                ((string[]) buf[2])[0] = rslt.getString(3, 100);
                return;
             case 5 :
                ((short[]) buf[0])[0] = rslt.getShort(1);
                ((int[]) buf[1])[0] = rslt.getInt(2);
                ((string[]) buf[2])[0] = rslt.getString(3, 100);
                return;
       }
    }

 }

}
