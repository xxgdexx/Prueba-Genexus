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
namespace GeneXus.Programs.almacen {
   public class r_kardexporproducto : GXDataArea
   {
      public r_kardexporproducto( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDataStore2 = context.GetDataStore("DataStore2");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusTheme");
      }

      public r_kardexporproducto( IGxContext context )
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
         PA6D2( ) ;
         gxajaxcallmode = (short)((isAjaxCallMode( ) ? 1 : 0));
         if ( ( gxajaxcallmode == 0 ) && ( GxWebError == 0 ) )
         {
            START6D2( ) ;
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
         context.AddJavascriptSource("gxcfg.js", "?20228181032241", false, true);
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
         context.WriteHtmlTextNl( "<form id=\"MAINFORM\" autocomplete=\"off\" name=\"MAINFORM\" method=\"post\" tabindex=-1  class=\"form-horizontal Form\" data-gx-class=\"form-horizontal Form\" novalidate action=\""+formatLink("almacen.r_kardexporproducto.aspx") +"\">") ;
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
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "vDDO_TITLESETTINGSICONS", AV42DDO_TitleSettingsIcons);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt("vDDO_TITLESETTINGSICONS", AV42DDO_TitleSettingsIcons);
         }
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "vALMCOD_DATA", AV49AlmCod_Data);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt("vALMCOD_DATA", AV49AlmCod_Data);
         }
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "vMOVCOD_DATA", AV44MovCod_Data);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt("vMOVCOD_DATA", AV44MovCod_Data);
         }
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "vCOSCOD_DATA", AV43CosCod_Data);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt("vCOSCOD_DATA", AV43CosCod_Data);
         }
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "vMVCLIORIGEN_DATA", AV45MVCliOrigen_Data);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt("vMVCLIORIGEN_DATA", AV45MVCliOrigen_Data);
         }
         GxWebStd.gx_hidden_field( context, "COMBO_ALMCOD_Cls", StringUtil.RTrim( Combo_almcod_Cls));
         GxWebStd.gx_hidden_field( context, "COMBO_ALMCOD_Selectedvalue_set", StringUtil.RTrim( Combo_almcod_Selectedvalue_set));
         GxWebStd.gx_hidden_field( context, "COMBO_MOVCOD_Cls", StringUtil.RTrim( Combo_movcod_Cls));
         GxWebStd.gx_hidden_field( context, "COMBO_MOVCOD_Selectedvalue_set", StringUtil.RTrim( Combo_movcod_Selectedvalue_set));
         GxWebStd.gx_hidden_field( context, "COMBO_COSCOD_Cls", StringUtil.RTrim( Combo_coscod_Cls));
         GxWebStd.gx_hidden_field( context, "COMBO_COSCOD_Selectedvalue_set", StringUtil.RTrim( Combo_coscod_Selectedvalue_set));
         GxWebStd.gx_hidden_field( context, "COMBO_MVCLIORIGEN_Cls", StringUtil.RTrim( Combo_mvcliorigen_Cls));
         GxWebStd.gx_hidden_field( context, "COMBO_MVCLIORIGEN_Selectedvalue_set", StringUtil.RTrim( Combo_mvcliorigen_Selectedvalue_set));
         GxWebStd.gx_hidden_field( context, "COMBO_MVCLIORIGEN_Selectedtext_set", StringUtil.RTrim( Combo_mvcliorigen_Selectedtext_set));
         GxWebStd.gx_hidden_field( context, "COMBO_MVCLIORIGEN_Datalistproc", StringUtil.RTrim( Combo_mvcliorigen_Datalistproc));
         GxWebStd.gx_hidden_field( context, "COMBO_MVCLIORIGEN_Datalistprocparametersprefix", StringUtil.RTrim( Combo_mvcliorigen_Datalistprocparametersprefix));
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
         GxWebStd.gx_hidden_field( context, "COMBO_MVCLIORIGEN_Selectedvalue_get", StringUtil.RTrim( Combo_mvcliorigen_Selectedvalue_get));
         GxWebStd.gx_hidden_field( context, "COMBO_COSCOD_Selectedvalue_get", StringUtil.RTrim( Combo_coscod_Selectedvalue_get));
         GxWebStd.gx_hidden_field( context, "COMBO_MOVCOD_Selectedvalue_get", StringUtil.RTrim( Combo_movcod_Selectedvalue_get));
         GxWebStd.gx_hidden_field( context, "COMBO_ALMCOD_Selectedvalue_get", StringUtil.RTrim( Combo_almcod_Selectedvalue_get));
         GxWebStd.gx_hidden_field( context, "COMBO_MVCLIORIGEN_Selectedvalue_get", StringUtil.RTrim( Combo_mvcliorigen_Selectedvalue_get));
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
            WE6D2( ) ;
            context.WriteHtmlText( "</div>") ;
         }
      }

      public override void DispatchEvents( )
      {
         EVT6D2( ) ;
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
         return formatLink("almacen.r_kardexporproducto.aspx")  ;
      }

      public override string GetPgmname( )
      {
         return "Almacen.R_KardexPorProducto" ;
      }

      public override string GetPgmdesc( )
      {
         return "Kardex Por Producto" ;
      }

      protected void WB6D0( )
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
            GxWebStd.gx_div_start( context, divTablesplittedalmcod_Internalname, 1, 0, "px", 0, "px", "Table", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-6 MergeLabelCell CellWidth_12_5", "left", "top", "", "", "div");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblTextblockcombo_almcod_Internalname, "Almacen", "", "", lblTextblockcombo_almcod_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "Label", 0, "", 1, 1, 0, 0, "HLP_Almacen\\R_KardexPorProducto.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-6 CellWidth_87_5", "left", "top", "", "", "div");
            /* User Defined Control */
            ucCombo_almcod.SetProperty("Caption", Combo_almcod_Caption);
            ucCombo_almcod.SetProperty("Cls", Combo_almcod_Cls);
            ucCombo_almcod.SetProperty("DropDownOptionsTitleSettingsIcons", AV42DDO_TitleSettingsIcons);
            ucCombo_almcod.SetProperty("DropDownOptionsData", AV49AlmCod_Data);
            ucCombo_almcod.Render(context, "dvelop.gxbootstrap.ddoextendedcombo", Combo_almcod_Internalname, "COMBO_ALMCODContainer");
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
            GxWebStd.gx_div_start( context, divTablesplittedmovcod_Internalname, 1, 0, "px", 0, "px", "Table", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-6 MergeLabelCell CellWidth_12_5", "left", "top", "", "", "div");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblTextblockcombo_movcod_Internalname, "Tipo de Movimiento", "", "", lblTextblockcombo_movcod_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "Label", 0, "", 1, 1, 0, 0, "HLP_Almacen\\R_KardexPorProducto.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-6 CellWidth_87_5", "left", "top", "", "", "div");
            /* User Defined Control */
            ucCombo_movcod.SetProperty("Caption", Combo_movcod_Caption);
            ucCombo_movcod.SetProperty("Cls", Combo_movcod_Cls);
            ucCombo_movcod.SetProperty("DropDownOptionsTitleSettingsIcons", AV42DDO_TitleSettingsIcons);
            ucCombo_movcod.SetProperty("DropDownOptionsData", AV44MovCod_Data);
            ucCombo_movcod.Render(context, "dvelop.gxbootstrap.ddoextendedcombo", Combo_movcod_Internalname, "COMBO_MOVCODContainer");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 DataContentCell ExtendedComboCell", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divTablesplittedcoscod_Internalname, 1, 0, "px", 0, "px", "Table", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-6 MergeLabelCell CellWidth_12_5", "left", "top", "", "", "div");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblTextblockcombo_coscod_Internalname, "Centro de Costo", "", "", lblTextblockcombo_coscod_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "Label", 0, "", 1, 1, 0, 0, "HLP_Almacen\\R_KardexPorProducto.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-6 CellWidth_87_5", "left", "top", "", "", "div");
            /* User Defined Control */
            ucCombo_coscod.SetProperty("Caption", Combo_coscod_Caption);
            ucCombo_coscod.SetProperty("Cls", Combo_coscod_Cls);
            ucCombo_coscod.SetProperty("DropDownOptionsTitleSettingsIcons", AV42DDO_TitleSettingsIcons);
            ucCombo_coscod.SetProperty("DropDownOptionsData", AV43CosCod_Data);
            ucCombo_coscod.Render(context, "dvelop.gxbootstrap.ddoextendedcombo", Combo_coscod_Internalname, "COMBO_COSCODContainer");
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
            GxWebStd.gx_label_ctrl( context, lblTextblockclicod_Internalname, "Cliente", "", "", lblTextblockclicod_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "Label", 0, "", 1, 1, 0, 0, "HLP_Almacen\\R_KardexPorProducto.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-6 CellWidth_87_5", "left", "top", "", "", "div");
            wb_table1_48_6D2( true) ;
         }
         else
         {
            wb_table1_48_6D2( false) ;
         }
         return  ;
      }

      protected void wb_table1_48_6D2e( bool wbgen )
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
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 DataContentCell ExtendedComboCell", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divTablesplittedmvcliorigen_Internalname, 1, 0, "px", 0, "px", "Table", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-6 MergeLabelCell CellWidth_12_5", "left", "top", "", "", "div");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblTextblockcombo_mvcliorigen_Internalname, "Cliente Destino 1", "", "", lblTextblockcombo_mvcliorigen_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "Label", 0, "", 1, 1, 0, 0, "HLP_Almacen\\R_KardexPorProducto.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-6 CellWidth_87_5", "left", "top", "", "", "div");
            /* User Defined Control */
            ucCombo_mvcliorigen.SetProperty("Caption", Combo_mvcliorigen_Caption);
            ucCombo_mvcliorigen.SetProperty("Cls", Combo_mvcliorigen_Cls);
            ucCombo_mvcliorigen.SetProperty("DataListProc", Combo_mvcliorigen_Datalistproc);
            ucCombo_mvcliorigen.SetProperty("DropDownOptionsTitleSettingsIcons", AV42DDO_TitleSettingsIcons);
            ucCombo_mvcliorigen.SetProperty("DropDownOptionsData", AV45MVCliOrigen_Data);
            ucCombo_mvcliorigen.Render(context, "dvelop.gxbootstrap.ddoextendedcombo", Combo_mvcliorigen_Internalname, "COMBO_MVCLIORIGENContainer");
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
            GxWebStd.gx_label_ctrl( context, lblTextblockprodcod_Internalname, " Producto", "", "", lblTextblockprodcod_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "Label", 0, "", 1, 1, 0, 0, "HLP_Almacen\\R_KardexPorProducto.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-6 CellWidth_87_5", "left", "top", "", "", "div");
            wb_table2_73_6D2( true) ;
         }
         else
         {
            wb_table2_73_6D2( false) ;
         }
         return  ;
      }

      protected void wb_table2_73_6D2e( bool wbgen )
      {
         if ( wbgen )
         {
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 DataContentCell", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divUnnamedtablemvadlref1_Internalname, 1, 0, "px", 0, "px", "Table", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-6 MergeLabelCell CellWidth_12_5", "left", "top", "", "", "div");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblTextblockmvadlref1_Internalname, "Nº Único", "", "", lblTextblockmvadlref1_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "Label", 0, "", 1, 1, 0, 0, "HLP_Almacen\\R_KardexPorProducto.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-6 CellWidth_87_5", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "left", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavMvadlref1_Internalname, "Referencia 1", "col-sm-3 AttributeLabel", 0, true, "");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 90,'',false,'',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavMvadlref1_Internalname, AV50MVADLRef1, StringUtil.RTrim( context.localUtil.Format( AV50MVADLRef1, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,90);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavMvadlref1_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtavMvadlref1_Enabled, 0, "text", "", 20, "chr", 1, "row", 20, 0, 0, 0, 1, -1, -1, true, "", "left", true, "", "HLP_Almacen\\R_KardexPorProducto.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
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
            GxWebStd.gx_div_start( context, divUnnamedtablefdesde_Internalname, 1, 0, "px", 0, "px", "Table", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-6 MergeLabelCell CellWidth_12_5", "left", "top", "", "", "div");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblTextblockfdesde_Internalname, "F.Desde", "", "", lblTextblockfdesde_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "Label", 0, "", 1, 1, 0, 0, "HLP_Almacen\\R_KardexPorProducto.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-6 CellWidth_87_5", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "left", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavFdesde_Internalname, "FDesde", "col-sm-3 AttributeDateLabel", 0, true, "");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 99,'',false,'',0)\"";
            context.WriteHtmlText( "<div id=\""+edtavFdesde_Internalname+"_dp_container\" class=\"dp_container\" style=\"white-space:nowrap;display:inline;\">") ;
            GxWebStd.gx_single_line_edit( context, edtavFdesde_Internalname, context.localUtil.Format(AV13FDesde, "99/99/99"), context.localUtil.Format( AV13FDesde, "99/99/99"), TempTags+" onchange=\""+"gx.date.valid_date(this, 8,'DMY',0,24,'spa',false,0);"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.date.valid_date(this, 8,'DMY',0,24,'spa',false,0);"+";gx.evt.onblur(this,99);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavFdesde_Jsonclick, 0, "AttributeDate", "", "", "", "", 1, edtavFdesde_Enabled, 0, "text", "", 8, "chr", 1, "row", 8, 0, 0, 0, 1, -1, 0, true, "", "right", false, "", "HLP_Almacen\\R_KardexPorProducto.htm");
            GxWebStd.gx_bitmap( context, edtavFdesde_Internalname+"_dp_trigger", context.GetImagePath( "61b9b5d3-dff6-4d59-9b00-da61bc2cbe93", "", context.GetTheme( )), "", "", "", "", ((1==0)||(edtavFdesde_Enabled==0) ? 0 : 1), 0, "Date selector", "Date selector", 0, 1, 0, "", 0, "", 0, 0, 0, "", "", "cursor: pointer;", "", "", "", "", "", "", "", "", 1, false, false, "", "HLP_Almacen\\R_KardexPorProducto.htm");
            context.WriteHtmlTextNl( "</div>") ;
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 CellPaddingLeft10", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divUnnamedtablefhasta_Internalname, 1, 0, "px", 0, "px", "Table", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-6 MergeLabelCell CellWidth_12_5", "left", "top", "", "", "div");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblTextblockfhasta_Internalname, "F.Hasta", "", "", lblTextblockfhasta_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "Label", 0, "", 1, 1, 0, 0, "HLP_Almacen\\R_KardexPorProducto.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-6 CellWidth_87_5", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "left", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavFhasta_Internalname, "FHasta", "col-sm-3 AttributeDateLabel", 0, true, "");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 108,'',false,'',0)\"";
            context.WriteHtmlText( "<div id=\""+edtavFhasta_Internalname+"_dp_container\" class=\"dp_container\" style=\"white-space:nowrap;display:inline;\">") ;
            GxWebStd.gx_single_line_edit( context, edtavFhasta_Internalname, context.localUtil.Format(AV15FHasta, "99/99/99"), context.localUtil.Format( AV15FHasta, "99/99/99"), TempTags+" onchange=\""+"gx.date.valid_date(this, 8,'DMY',0,24,'spa',false,0);"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.date.valid_date(this, 8,'DMY',0,24,'spa',false,0);"+";gx.evt.onblur(this,108);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavFhasta_Jsonclick, 0, "AttributeDate", "", "", "", "", 1, edtavFhasta_Enabled, 0, "text", "", 8, "chr", 1, "row", 8, 0, 0, 0, 1, -1, 0, true, "", "right", false, "", "HLP_Almacen\\R_KardexPorProducto.htm");
            GxWebStd.gx_bitmap( context, edtavFhasta_Internalname+"_dp_trigger", context.GetImagePath( "61b9b5d3-dff6-4d59-9b00-da61bc2cbe93", "", context.GetTheme( )), "", "", "", "", ((1==0)||(edtavFhasta_Enabled==0) ? 0 : 1), 0, "Date selector", "Date selector", 0, 1, 0, "", 0, "", 0, 0, 0, "", "", "cursor: pointer;", "", "", "", "", "", "", "", "", 1, false, false, "", "HLP_Almacen\\R_KardexPorProducto.htm");
            context.WriteHtmlTextNl( "</div>") ;
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
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 113,'',false,'',0)\"";
            ClassString = "ButtonPDF";
            StyleString = "";
            GxWebStd.gx_button_ctrl( context, bttBtnbtnimprimir_Internalname, "", "Imprimir", bttBtnbtnimprimir_Jsonclick, 5, "Imprimir", "", StyleString, ClassString, 1, 1, "standard", "'"+""+"'"+",false,"+"'"+"E\\'DOBTNIMPRIMIR\\'."+"'", TempTags, "", context.GetButtonType( ), "HLP_Almacen\\R_KardexPorProducto.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "left", "top", "", "", "div");
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 115,'',false,'',0)\"";
            ClassString = "ButtonExcel";
            StyleString = "";
            GxWebStd.gx_button_ctrl( context, bttBtnbtnexcel_Internalname, "", "Excel", bttBtnbtnexcel_Jsonclick, 5, "Exportal a Excel", "", StyleString, ClassString, 1, 1, "standard", "'"+""+"'"+",false,"+"'"+"E\\'DOBTNEXCEL\\'."+"'", TempTags, "", context.GetButtonType( ), "HLP_Almacen\\R_KardexPorProducto.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "left", "top", "", "", "div");
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 117,'',false,'',0)\"";
            ClassString = "ButtonColor";
            StyleString = "";
            GxWebStd.gx_button_ctrl( context, bttBtnbtnsalir_Internalname, "", "Salir", bttBtnbtnsalir_Jsonclick, 5, "Imprimir PDF", "", StyleString, ClassString, 1, 1, "standard", "'"+""+"'"+",false,"+"'"+"E\\'DOBTNSALIR\\'."+"'", TempTags, "", context.GetButtonType( ), "HLP_Almacen\\R_KardexPorProducto.htm");
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
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 124,'',false,'',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavAlmcod_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(AV48AlmCod), 6, 0, ".", "")), StringUtil.LTrim( context.localUtil.Format( (decimal)(AV48AlmCod), "ZZZZZ9")), " inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onblur(this,124);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavAlmcod_Jsonclick, 0, "Attribute", "", "", "", "", edtavAlmcod_Visible, 1, 0, "text", "1", 6, "chr", 1, "row", 6, 0, 0, 0, 1, -1, 0, true, "", "right", false, "", "HLP_Almacen\\R_KardexPorProducto.htm");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 125,'',false,'',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavMovcod_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(AV39MovCod), 6, 0, ".", "")), StringUtil.LTrim( context.localUtil.Format( (decimal)(AV39MovCod), "ZZZZZ9")), " inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onblur(this,125);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavMovcod_Jsonclick, 0, "Attribute", "", "", "", "", edtavMovcod_Visible, 1, 0, "text", "1", 6, "chr", 1, "row", 6, 0, 0, 0, 1, -1, 0, true, "", "right", false, "", "HLP_Almacen\\R_KardexPorProducto.htm");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 126,'',false,'',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavCoscod_Internalname, StringUtil.RTrim( AV38CosCod), StringUtil.RTrim( context.localUtil.Format( AV38CosCod, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,126);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavCoscod_Jsonclick, 0, "Attribute", "", "", "", "", edtavCoscod_Visible, 1, 0, "text", "", 10, "chr", 1, "row", 10, 0, 0, 0, 1, -1, -1, true, "", "left", true, "", "HLP_Almacen\\R_KardexPorProducto.htm");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 127,'',false,'',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavMvcliorigen_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(AV41MVCliOrigen), 6, 0, ".", "")), StringUtil.LTrim( context.localUtil.Format( (decimal)(AV41MVCliOrigen), "ZZZZZ9")), " inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onblur(this,127);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavMvcliorigen_Jsonclick, 0, "Attribute", "", "", "", "", edtavMvcliorigen_Visible, 1, 0, "text", "1", 6, "chr", 1, "row", 6, 0, 0, 0, 1, -1, 0, true, "", "right", false, "", "HLP_Almacen\\R_KardexPorProducto.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
         }
         wbLoad = true;
      }

      protected void START6D2( )
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
            Form.Meta.addItem("description", "Kardex Por Producto", 0) ;
         }
         context.wjLoc = "";
         context.nUserReturn = 0;
         context.wbHandled = 0;
         if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
         {
         }
         wbErr = false;
         STRUP6D0( ) ;
      }

      protected void WS6D2( )
      {
         START6D2( ) ;
         EVT6D2( ) ;
      }

      protected void EVT6D2( )
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
                           else if ( StringUtil.StrCmp(sEvt, "COMBO_MVCLIORIGEN.ONOPTIONCLICKED") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              E116D2 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "START") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              /* Execute user event: Start */
                              E126D2 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "'DOBTNIMPRIMIR'") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              /* Execute user event: 'DoBtnImprimir' */
                              E136D2 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "'DOBTNEXCEL'") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              /* Execute user event: 'DoBtnExcel' */
                              E146D2 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "'DOBTNSALIR'") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              /* Execute user event: 'DoBtnSalir' */
                              E156D2 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "LOAD") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              /* Execute user event: Load */
                              E166D2 ();
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

      protected void WE6D2( )
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

      protected void PA6D2( )
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
      }

      public void Refresh( )
      {
         send_integrity_hashes( ) ;
         RF6D2( ) ;
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

      protected void RF6D2( )
      {
         initialize_formulas( ) ;
         clear_multi_value_controls( ) ;
         gxdyncontrolsrefreshing = true;
         fix_multi_value_controls( ) ;
         gxdyncontrolsrefreshing = false;
         if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
         {
            /* Execute user event: Load */
            E166D2 ();
            WB6D0( ) ;
         }
      }

      protected void send_integrity_lvl_hashes6D2( )
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

      protected void STRUP6D0( )
      {
         /* Before Start, stand alone formulas. */
         before_start_formulas( ) ;
         /* Execute Start event if defined. */
         context.wbGlbDoneStart = 0;
         /* Execute user event: Start */
         E126D2 ();
         context.wbGlbDoneStart = 1;
         /* After Start, stand alone formulas. */
         if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
         {
            /* Read saved SDTs. */
            ajax_req_read_hidden_sdt(cgiGet( "vDDO_TITLESETTINGSICONS"), AV42DDO_TitleSettingsIcons);
            ajax_req_read_hidden_sdt(cgiGet( "vALMCOD_DATA"), AV49AlmCod_Data);
            ajax_req_read_hidden_sdt(cgiGet( "vMOVCOD_DATA"), AV44MovCod_Data);
            ajax_req_read_hidden_sdt(cgiGet( "vCOSCOD_DATA"), AV43CosCod_Data);
            ajax_req_read_hidden_sdt(cgiGet( "vMVCLIORIGEN_DATA"), AV45MVCliOrigen_Data);
            /* Read saved values. */
            Combo_almcod_Cls = cgiGet( "COMBO_ALMCOD_Cls");
            Combo_almcod_Selectedvalue_set = cgiGet( "COMBO_ALMCOD_Selectedvalue_set");
            Combo_movcod_Cls = cgiGet( "COMBO_MOVCOD_Cls");
            Combo_movcod_Selectedvalue_set = cgiGet( "COMBO_MOVCOD_Selectedvalue_set");
            Combo_coscod_Cls = cgiGet( "COMBO_COSCOD_Cls");
            Combo_coscod_Selectedvalue_set = cgiGet( "COMBO_COSCOD_Selectedvalue_set");
            Combo_mvcliorigen_Cls = cgiGet( "COMBO_MVCLIORIGEN_Cls");
            Combo_mvcliorigen_Selectedvalue_set = cgiGet( "COMBO_MVCLIORIGEN_Selectedvalue_set");
            Combo_mvcliorigen_Selectedtext_set = cgiGet( "COMBO_MVCLIORIGEN_Selectedtext_set");
            Combo_mvcliorigen_Datalistproc = cgiGet( "COMBO_MVCLIORIGEN_Datalistproc");
            Combo_mvcliorigen_Datalistprocparametersprefix = cgiGet( "COMBO_MVCLIORIGEN_Datalistprocparametersprefix");
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
            Combo_mvcliorigen_Selectedvalue_get = cgiGet( "COMBO_MVCLIORIGEN_Selectedvalue_get");
            /* Read variables values. */
            AV5CliCod = cgiGet( edtavClicod_Internalname);
            AssignAttri("", false, "AV5CliCod", AV5CliCod);
            AV7CliDsc = cgiGet( edtavClidsc_Internalname);
            AssignAttri("", false, "AV7CliDsc", AV7CliDsc);
            AV23ProdCod = StringUtil.Upper( cgiGet( edtavProdcod_Internalname));
            AssignAttri("", false, "AV23ProdCod", AV23ProdCod);
            AV24ProdDsc = cgiGet( edtavProddsc_Internalname);
            AssignAttri("", false, "AV24ProdDsc", AV24ProdDsc);
            AV50MVADLRef1 = cgiGet( edtavMvadlref1_Internalname);
            AssignAttri("", false, "AV50MVADLRef1", AV50MVADLRef1);
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
            if ( ( ( context.localUtil.CToN( cgiGet( edtavAlmcod_Internalname), ".", ",") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtavAlmcod_Internalname), ".", ",") > Convert.ToDecimal( 999999 )) ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "vALMCOD");
               GX_FocusControl = edtavAlmcod_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               AV48AlmCod = 0;
               AssignAttri("", false, "AV48AlmCod", StringUtil.LTrimStr( (decimal)(AV48AlmCod), 6, 0));
            }
            else
            {
               AV48AlmCod = (int)(context.localUtil.CToN( cgiGet( edtavAlmcod_Internalname), ".", ","));
               AssignAttri("", false, "AV48AlmCod", StringUtil.LTrimStr( (decimal)(AV48AlmCod), 6, 0));
            }
            if ( ( ( context.localUtil.CToN( cgiGet( edtavMovcod_Internalname), ".", ",") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtavMovcod_Internalname), ".", ",") > Convert.ToDecimal( 999999 )) ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "vMOVCOD");
               GX_FocusControl = edtavMovcod_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               AV39MovCod = 0;
               AssignAttri("", false, "AV39MovCod", StringUtil.LTrimStr( (decimal)(AV39MovCod), 6, 0));
            }
            else
            {
               AV39MovCod = (int)(context.localUtil.CToN( cgiGet( edtavMovcod_Internalname), ".", ","));
               AssignAttri("", false, "AV39MovCod", StringUtil.LTrimStr( (decimal)(AV39MovCod), 6, 0));
            }
            AV38CosCod = cgiGet( edtavCoscod_Internalname);
            AssignAttri("", false, "AV38CosCod", AV38CosCod);
            if ( ( ( context.localUtil.CToN( cgiGet( edtavMvcliorigen_Internalname), ".", ",") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtavMvcliorigen_Internalname), ".", ",") > Convert.ToDecimal( 999999 )) ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "vMVCLIORIGEN");
               GX_FocusControl = edtavMvcliorigen_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               AV41MVCliOrigen = 0;
               AssignAttri("", false, "AV41MVCliOrigen", StringUtil.LTrimStr( (decimal)(AV41MVCliOrigen), 6, 0));
            }
            else
            {
               AV41MVCliOrigen = (int)(context.localUtil.CToN( cgiGet( edtavMvcliorigen_Internalname), ".", ","));
               AssignAttri("", false, "AV41MVCliOrigen", StringUtil.LTrimStr( (decimal)(AV41MVCliOrigen), 6, 0));
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
         E126D2 ();
         if (returnInSub) return;
      }

      protected void E126D2( )
      {
         /* Start Routine */
         returnInSub = false;
         GXt_SdtDVB_SDTDropDownOptionsTitleSettingsIcons1 = AV42DDO_TitleSettingsIcons;
         new GeneXus.Programs.wwpbaseobjects.getwwptitlesettingsicons(context ).execute( out  GXt_SdtDVB_SDTDropDownOptionsTitleSettingsIcons1) ;
         AV42DDO_TitleSettingsIcons = GXt_SdtDVB_SDTDropDownOptionsTitleSettingsIcons1;
         edtavMvcliorigen_Visible = 0;
         AssignProp("", false, edtavMvcliorigen_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavMvcliorigen_Visible), 5, 0), true);
         edtavCoscod_Visible = 0;
         AssignProp("", false, edtavCoscod_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavCoscod_Visible), 5, 0), true);
         edtavMovcod_Visible = 0;
         AssignProp("", false, edtavMovcod_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavMovcod_Visible), 5, 0), true);
         edtavAlmcod_Visible = 0;
         AssignProp("", false, edtavAlmcod_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavAlmcod_Visible), 5, 0), true);
         /* Execute user subroutine: 'LOADCOMBOALMCOD' */
         S112 ();
         if (returnInSub) return;
         /* Execute user subroutine: 'LOADCOMBOMOVCOD' */
         S122 ();
         if (returnInSub) return;
         /* Execute user subroutine: 'LOADCOMBOCOSCOD' */
         S132 ();
         if (returnInSub) return;
         /* Execute user subroutine: 'LOADCOMBOMVCLIORIGEN' */
         S142 ();
         if (returnInSub) return;
         AV37Tipo = 2;
         AV13FDesde = DateTimeUtil.Today( context);
         AssignAttri("", false, "AV13FDesde", context.localUtil.Format(AV13FDesde, "99/99/99"));
         AV15FHasta = DateTimeUtil.Today( context);
         AssignAttri("", false, "AV15FHasta", context.localUtil.Format(AV15FHasta, "99/99/99"));
      }

      protected void E136D2( )
      {
         /* 'DoBtnImprimir' Routine */
         returnInSub = false;
         if ( (0==AV48AlmCod) )
         {
            GX_msglist.addItem("Falta seleccionar el almacen");
         }
         else
         {
            if ( String.IsNullOrEmpty(StringUtil.RTrim( AV50MVADLRef1)) )
            {
               GXKey = Crypto.GetSiteKey( );
               GXEncryptionTmp = "almacen.r_kardexdetallepdf.aspx"+UrlEncode(StringUtil.LTrimStr(AV48AlmCod,6,0)) + "," + UrlEncode(StringUtil.RTrim(AV23ProdCod)) + "," + UrlEncode(DateTimeUtil.FormatDateParm(AV13FDesde)) + "," + UrlEncode(DateTimeUtil.FormatDateParm(AV15FHasta)) + "," + UrlEncode(StringUtil.RTrim(AV5CliCod)) + "," + UrlEncode(StringUtil.LTrimStr(AV41MVCliOrigen,6,0)) + "," + UrlEncode(StringUtil.LTrimStr(AV39MovCod,6,0)) + "," + UrlEncode(StringUtil.RTrim(AV38CosCod));
               AV47URL = formatLink("almacen.r_kardexdetallepdf.aspx") + "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey);
               Innewwindow_Target = AV47URL;
               ucInnewwindow.SendProperty(context, "", false, Innewwindow_Internalname, "Target", Innewwindow_Target);
               this.executeUsercontrolMethod("", false, "INNEWWINDOWContainer", "OpenWindow", "", new Object[] {});
            }
            else
            {
               GXKey = Crypto.GetSiteKey( );
               GXEncryptionTmp = "almacen.r_kardexdetallelotepdf.aspx"+UrlEncode(StringUtil.LTrimStr(AV48AlmCod,6,0)) + "," + UrlEncode(StringUtil.RTrim(AV23ProdCod)) + "," + UrlEncode(DateTimeUtil.FormatDateParm(AV13FDesde)) + "," + UrlEncode(DateTimeUtil.FormatDateParm(AV15FHasta)) + "," + UrlEncode(StringUtil.RTrim(AV5CliCod)) + "," + UrlEncode(StringUtil.LTrimStr(AV41MVCliOrigen,6,0)) + "," + UrlEncode(StringUtil.LTrimStr(AV39MovCod,6,0)) + "," + UrlEncode(StringUtil.RTrim(AV50MVADLRef1));
               AV47URL = formatLink("almacen.r_kardexdetallelotepdf.aspx") + "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey);
               Innewwindow_Target = AV47URL;
               ucInnewwindow.SendProperty(context, "", false, Innewwindow_Internalname, "Target", Innewwindow_Target);
               this.executeUsercontrolMethod("", false, "INNEWWINDOWContainer", "OpenWindow", "", new Object[] {});
            }
         }
         /*  Sending Event outputs  */
      }

      protected void E146D2( )
      {
         /* 'DoBtnExcel' Routine */
         returnInSub = false;
         new GeneXus.Programs.almacen.r_kardexdetalleproductoexcel(context ).execute( ref  AV48AlmCod, ref  AV23ProdCod, ref  AV13FDesde, ref  AV15FHasta, ref  AV5CliCod, ref  AV41MVCliOrigen, ref  AV39MovCod, ref  AV38CosCod, out  AV10ExcelFilename, out  AV9ErrorMessage) ;
         AssignAttri("", false, "AV48AlmCod", StringUtil.LTrimStr( (decimal)(AV48AlmCod), 6, 0));
         AssignAttri("", false, "AV23ProdCod", AV23ProdCod);
         AssignAttri("", false, "AV13FDesde", context.localUtil.Format(AV13FDesde, "99/99/99"));
         AssignAttri("", false, "AV15FHasta", context.localUtil.Format(AV15FHasta, "99/99/99"));
         AssignAttri("", false, "AV5CliCod", AV5CliCod);
         AssignAttri("", false, "AV41MVCliOrigen", StringUtil.LTrimStr( (decimal)(AV41MVCliOrigen), 6, 0));
         AssignAttri("", false, "AV39MovCod", StringUtil.LTrimStr( (decimal)(AV39MovCod), 6, 0));
         AssignAttri("", false, "AV38CosCod", AV38CosCod);
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
      }

      protected void E156D2( )
      {
         /* 'DoBtnSalir' Routine */
         returnInSub = false;
         CallWebObject(formatLink("wwpbaseobjects.home.aspx") );
         context.wjLocDisableFrm = 1;
      }

      protected void E116D2( )
      {
         /* Combo_mvcliorigen_Onoptionclicked Routine */
         returnInSub = false;
         AV41MVCliOrigen = (int)(NumberUtil.Val( Combo_mvcliorigen_Selectedvalue_get, "."));
         AssignAttri("", false, "AV41MVCliOrigen", StringUtil.LTrimStr( (decimal)(AV41MVCliOrigen), 6, 0));
         /*  Sending Event outputs  */
      }

      protected void S142( )
      {
         /* 'LOADCOMBOMVCLIORIGEN' Routine */
         returnInSub = false;
         Combo_mvcliorigen_Datalistprocparametersprefix = StringUtil.Format( " \"ComboName\": \"MVCliOrigen\", \"Cond_CliCod\": \"#%1#\"", edtavClicod_Internalname, "", "", "", "", "", "", "", "");
         ucCombo_mvcliorigen.SendProperty(context, "", false, Combo_mvcliorigen_Internalname, "DataListProcParametersPrefix", Combo_mvcliorigen_Datalistprocparametersprefix);
         AV46Cond_CliCod = AV5CliCod;
         AV53GXLvl154 = 0;
         /* Using cursor H006D2 */
         pr_default.execute(0, new Object[] {AV41MVCliOrigen});
         while ( (pr_default.getStatus(0) != 101) )
         {
            A164CliDirItem = H006D2_A164CliDirItem[0];
            A600CliDirDsc = H006D2_A600CliDirDsc[0];
            AV53GXLvl154 = 1;
            Combo_mvcliorigen_Selectedtext_set = A600CliDirDsc;
            ucCombo_mvcliorigen.SendProperty(context, "", false, Combo_mvcliorigen_Internalname, "SelectedText_set", Combo_mvcliorigen_Selectedtext_set);
            /* Exit For each command. Update data (if necessary), close cursors & exit. */
            if (true) break;
            pr_default.readNext(0);
         }
         pr_default.close(0);
         if ( AV53GXLvl154 == 0 )
         {
            Combo_mvcliorigen_Selectedtext_set = "";
            ucCombo_mvcliorigen.SendProperty(context, "", false, Combo_mvcliorigen_Internalname, "SelectedText_set", Combo_mvcliorigen_Selectedtext_set);
         }
         Combo_mvcliorigen_Selectedvalue_set = ((0==AV41MVCliOrigen) ? "" : StringUtil.Trim( StringUtil.Str( (decimal)(AV41MVCliOrigen), 6, 0)));
         ucCombo_mvcliorigen.SendProperty(context, "", false, Combo_mvcliorigen_Internalname, "SelectedValue_set", Combo_mvcliorigen_Selectedvalue_set);
      }

      protected void S132( )
      {
         /* 'LOADCOMBOCOSCOD' Routine */
         returnInSub = false;
         /* Using cursor H006D3 */
         pr_default.execute(1);
         while ( (pr_default.getStatus(1) != 101) )
         {
            A762COSSts = H006D3_A762COSSts[0];
            A79COSCod = H006D3_A79COSCod[0];
            A761COSDsc = H006D3_A761COSDsc[0];
            AV8Combo_DataItem = new GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTComboData_Item(context);
            AV8Combo_DataItem.gxTpr_Id = A79COSCod;
            AV8Combo_DataItem.gxTpr_Title = A761COSDsc;
            AV43CosCod_Data.Add(AV8Combo_DataItem, 0);
            pr_default.readNext(1);
         }
         pr_default.close(1);
         Combo_coscod_Selectedvalue_set = AV38CosCod;
         ucCombo_coscod.SendProperty(context, "", false, Combo_coscod_Internalname, "SelectedValue_set", Combo_coscod_Selectedvalue_set);
      }

      protected void S122( )
      {
         /* 'LOADCOMBOMOVCOD' Routine */
         returnInSub = false;
         /* Using cursor H006D4 */
         pr_default.execute(2);
         while ( (pr_default.getStatus(2) != 101) )
         {
            A1240MovSts = H006D4_A1240MovSts[0];
            A234MovCod = H006D4_A234MovCod[0];
            A1239MovDsc = H006D4_A1239MovDsc[0];
            AV8Combo_DataItem = new GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTComboData_Item(context);
            AV8Combo_DataItem.gxTpr_Id = StringUtil.Trim( StringUtil.Str( (decimal)(A234MovCod), 6, 0));
            AV8Combo_DataItem.gxTpr_Title = A1239MovDsc;
            AV44MovCod_Data.Add(AV8Combo_DataItem, 0);
            pr_default.readNext(2);
         }
         pr_default.close(2);
         Combo_movcod_Selectedvalue_set = ((0==AV39MovCod) ? "" : StringUtil.Trim( StringUtil.Str( (decimal)(AV39MovCod), 6, 0)));
         ucCombo_movcod.SendProperty(context, "", false, Combo_movcod_Internalname, "SelectedValue_set", Combo_movcod_Selectedvalue_set);
      }

      protected void S112( )
      {
         /* 'LOADCOMBOALMCOD' Routine */
         returnInSub = false;
         /* Using cursor H006D5 */
         pr_default.execute(3);
         while ( (pr_default.getStatus(3) != 101) )
         {
            A438AlmSts = H006D5_A438AlmSts[0];
            A63AlmCod = H006D5_A63AlmCod[0];
            A436AlmDsc = H006D5_A436AlmDsc[0];
            AV8Combo_DataItem = new GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTComboData_Item(context);
            AV8Combo_DataItem.gxTpr_Id = StringUtil.Trim( StringUtil.Str( (decimal)(A63AlmCod), 6, 0));
            AV8Combo_DataItem.gxTpr_Title = A436AlmDsc;
            AV49AlmCod_Data.Add(AV8Combo_DataItem, 0);
            pr_default.readNext(3);
         }
         pr_default.close(3);
         Combo_almcod_Selectedvalue_set = ((0==AV48AlmCod) ? "" : StringUtil.Trim( StringUtil.Str( (decimal)(AV48AlmCod), 6, 0)));
         ucCombo_almcod.SendProperty(context, "", false, Combo_almcod_Internalname, "SelectedValue_set", Combo_almcod_Selectedvalue_set);
      }

      protected void nextLoad( )
      {
      }

      protected void E166D2( )
      {
         /* Load Routine */
         returnInSub = false;
      }

      protected void wb_table2_73_6D2( bool wbgen )
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
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 77,'',false,'',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavProdcod_Internalname, StringUtil.RTrim( AV23ProdCod), StringUtil.RTrim( context.localUtil.Format( AV23ProdCod, "@!")), TempTags+" onchange=\""+"this.value=this.value.toUpperCase();"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"this.value=this.value.toUpperCase();"+";gx.evt.onblur(this,77);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavProdcod_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtavProdcod_Enabled, 0, "text", "", 15, "chr", 1, "row", 15, 0, 0, 0, 1, -1, -1, true, "", "left", true, "", "HLP_Almacen\\R_KardexPorProducto.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "<td class='CellPaddingLeft10'>") ;
            /* Active images/pictures */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 79,'',false,'',0)\"";
            ClassString = "Image";
            StyleString = "";
            sImgUrl = (string)(context.GetImagePath( "f5b04895-0024-488b-8e3b-b687ca4598ee", "", context.GetTheme( )));
            GxWebStd.gx_bitmap( context, imgBtnbuscarpro_Internalname, sImgUrl, "", "", "", context.GetTheme( ), 1, 1, "", "Buscar Producto", 0, 0, 0, "px", 0, "px", 0, 0, 7, imgBtnbuscarpro_Jsonclick, "'"+""+"'"+",false,"+"'"+"e176d1_client"+"'", StyleString, ClassString, "", "", "", "", " "+"data-gx-image"+" "+TempTags, "", "", 1, false, false, context.GetImageSrcSet( sImgUrl), "HLP_Almacen\\R_KardexPorProducto.htm");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "<td class='DataContentCell'>") ;
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "left", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavProddsc_Internalname, "Prod Dsc", "gx-form-item ReadonlyAttributeLabel", 0, true, "width: 25%;");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 82,'',false,'',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavProddsc_Internalname, StringUtil.RTrim( AV24ProdDsc), StringUtil.RTrim( context.localUtil.Format( AV24ProdDsc, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,82);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavProddsc_Jsonclick, 0, "ReadonlyAttribute", "", "", "", "", 1, edtavProddsc_Enabled, 0, "text", "", 80, "chr", 1, "row", 100, 0, 0, 0, 1, -1, -1, true, "", "left", true, "", "HLP_Almacen\\R_KardexPorProducto.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "</tr>") ;
            /* End of table */
            context.WriteHtmlText( "</table>") ;
            wb_table2_73_6D2e( true) ;
         }
         else
         {
            wb_table2_73_6D2e( false) ;
         }
      }

      protected void wb_table1_48_6D2( bool wbgen )
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
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 52,'',false,'',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavClicod_Internalname, StringUtil.RTrim( AV5CliCod), StringUtil.RTrim( context.localUtil.Format( AV5CliCod, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,52);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavClicod_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtavClicod_Enabled, 0, "text", "", 20, "chr", 1, "row", 20, 0, 0, 0, 1, -1, -1, true, "", "left", true, "", "HLP_Almacen\\R_KardexPorProducto.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "<td class='CellPaddingLeft10'>") ;
            /* Active images/pictures */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 54,'',false,'',0)\"";
            ClassString = "Image";
            StyleString = "";
            sImgUrl = (string)(context.GetImagePath( "f5b04895-0024-488b-8e3b-b687ca4598ee", "", context.GetTheme( )));
            GxWebStd.gx_bitmap( context, imgBtnbuscar_Internalname, sImgUrl, "", "", "", context.GetTheme( ), 1, 1, "", "Buscar Cliente", 0, 0, 0, "px", 0, "px", 0, 0, 7, imgBtnbuscar_Jsonclick, "'"+""+"'"+",false,"+"'"+"e186d1_client"+"'", StyleString, ClassString, "", "", "", "", " "+"data-gx-image"+" "+TempTags, "", "", 1, false, false, context.GetImageSrcSet( sImgUrl), "HLP_Almacen\\R_KardexPorProducto.htm");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "<td class='DataContentCell'>") ;
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "left", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavClidsc_Internalname, "Descripción Cliente", "gx-form-item ReadonlyAttributeLabel", 0, true, "width: 25%;");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 57,'',false,'',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavClidsc_Internalname, StringUtil.RTrim( AV7CliDsc), StringUtil.RTrim( context.localUtil.Format( AV7CliDsc, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,57);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavClidsc_Jsonclick, 0, "ReadonlyAttribute", "", "", "", "", 1, edtavClidsc_Enabled, 0, "text", "", 80, "chr", 1, "row", 100, 0, 0, 0, 1, -1, -1, true, "", "left", true, "", "HLP_Almacen\\R_KardexPorProducto.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "</tr>") ;
            /* End of table */
            context.WriteHtmlText( "</table>") ;
            wb_table1_48_6D2e( true) ;
         }
         else
         {
            wb_table1_48_6D2e( false) ;
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
         PA6D2( ) ;
         WS6D2( ) ;
         WE6D2( ) ;
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
            context.AddJavascriptSource(StringUtil.RTrim( ((string)Form.Jscriptsrc.Item(idxLst))), "?20228181032492", true, true);
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
         context.AddJavascriptSource("almacen/r_kardexporproducto.js", "?20228181032493", false, true);
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
         context.AddJavascriptSource("Window/InNewWindowRender.js", "", false, true);
         /* End function include_jscripts */
      }

      protected void init_web_controls( )
      {
         /* End function init_web_controls */
      }

      protected void init_default_properties( )
      {
         lblTextblockcombo_almcod_Internalname = "TEXTBLOCKCOMBO_ALMCOD";
         Combo_almcod_Internalname = "COMBO_ALMCOD";
         divTablesplittedalmcod_Internalname = "TABLESPLITTEDALMCOD";
         lblTextblockcombo_movcod_Internalname = "TEXTBLOCKCOMBO_MOVCOD";
         Combo_movcod_Internalname = "COMBO_MOVCOD";
         divTablesplittedmovcod_Internalname = "TABLESPLITTEDMOVCOD";
         lblTextblockcombo_coscod_Internalname = "TEXTBLOCKCOMBO_COSCOD";
         Combo_coscod_Internalname = "COMBO_COSCOD";
         divTablesplittedcoscod_Internalname = "TABLESPLITTEDCOSCOD";
         lblTextblockclicod_Internalname = "TEXTBLOCKCLICOD";
         edtavClicod_Internalname = "vCLICOD";
         imgBtnbuscar_Internalname = "BTNBUSCAR";
         edtavClidsc_Internalname = "vCLIDSC";
         tblTablemergedclicod_Internalname = "TABLEMERGEDCLICOD";
         divTablesplittedclicod_Internalname = "TABLESPLITTEDCLICOD";
         lblTextblockcombo_mvcliorigen_Internalname = "TEXTBLOCKCOMBO_MVCLIORIGEN";
         Combo_mvcliorigen_Internalname = "COMBO_MVCLIORIGEN";
         divTablesplittedmvcliorigen_Internalname = "TABLESPLITTEDMVCLIORIGEN";
         lblTextblockprodcod_Internalname = "TEXTBLOCKPRODCOD";
         edtavProdcod_Internalname = "vPRODCOD";
         imgBtnbuscarpro_Internalname = "BTNBUSCARPRO";
         edtavProddsc_Internalname = "vPRODDSC";
         tblTablemergedprodcod_Internalname = "TABLEMERGEDPRODCOD";
         divTablesplittedprodcod_Internalname = "TABLESPLITTEDPRODCOD";
         lblTextblockmvadlref1_Internalname = "TEXTBLOCKMVADLREF1";
         edtavMvadlref1_Internalname = "vMVADLREF1";
         divUnnamedtablemvadlref1_Internalname = "UNNAMEDTABLEMVADLREF1";
         lblTextblockfdesde_Internalname = "TEXTBLOCKFDESDE";
         edtavFdesde_Internalname = "vFDESDE";
         divUnnamedtablefdesde_Internalname = "UNNAMEDTABLEFDESDE";
         lblTextblockfhasta_Internalname = "TEXTBLOCKFHASTA";
         edtavFhasta_Internalname = "vFHASTA";
         divUnnamedtablefhasta_Internalname = "UNNAMEDTABLEFHASTA";
         divPanel_Internalname = "PANEL";
         Dvpanel_panel_Internalname = "DVPANEL_PANEL";
         bttBtnbtnimprimir_Internalname = "BTNBTNIMPRIMIR";
         bttBtnbtnexcel_Internalname = "BTNBTNEXCEL";
         bttBtnbtnsalir_Internalname = "BTNBTNSALIR";
         Innewwindow_Internalname = "INNEWWINDOW";
         divTablecontent_Internalname = "TABLECONTENT";
         divTablemain_Internalname = "TABLEMAIN";
         edtavAlmcod_Internalname = "vALMCOD";
         edtavMovcod_Internalname = "vMOVCOD";
         edtavCoscod_Internalname = "vCOSCOD";
         edtavMvcliorigen_Internalname = "vMVCLIORIGEN";
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
         edtavClidsc_Jsonclick = "";
         edtavClidsc_Enabled = 1;
         edtavClicod_Jsonclick = "";
         edtavClicod_Enabled = 1;
         edtavProddsc_Jsonclick = "";
         edtavProddsc_Enabled = 1;
         edtavProdcod_Jsonclick = "";
         edtavProdcod_Enabled = 1;
         edtavMvcliorigen_Jsonclick = "";
         edtavMvcliorigen_Visible = 1;
         edtavCoscod_Jsonclick = "";
         edtavCoscod_Visible = 1;
         edtavMovcod_Jsonclick = "";
         edtavMovcod_Visible = 1;
         edtavAlmcod_Jsonclick = "";
         edtavAlmcod_Visible = 1;
         edtavFhasta_Jsonclick = "";
         edtavFhasta_Enabled = 1;
         edtavFdesde_Jsonclick = "";
         edtavFdesde_Enabled = 1;
         edtavMvadlref1_Jsonclick = "";
         edtavMvadlref1_Enabled = 1;
         Combo_mvcliorigen_Caption = "";
         Combo_coscod_Caption = "";
         Combo_movcod_Caption = "";
         Combo_almcod_Caption = "";
         Innewwindow_Target = "";
         Dvpanel_panel_Autoscroll = Convert.ToBoolean( 0);
         Dvpanel_panel_Iconposition = "Right";
         Dvpanel_panel_Showcollapseicon = Convert.ToBoolean( 0);
         Dvpanel_panel_Collapsed = Convert.ToBoolean( 0);
         Dvpanel_panel_Collapsible = Convert.ToBoolean( -1);
         Dvpanel_panel_Title = "Reporte de Kardex Por Productos";
         Dvpanel_panel_Cls = "PanelFilled Panel_BaseColor";
         Dvpanel_panel_Autoheight = Convert.ToBoolean( -1);
         Dvpanel_panel_Autowidth = Convert.ToBoolean( 0);
         Dvpanel_panel_Width = "100%";
         Combo_mvcliorigen_Datalistprocparametersprefix = "";
         Combo_mvcliorigen_Datalistproc = "Almacen.R_KardexPorProductoLoadDVCombo";
         Combo_mvcliorigen_Cls = "ExtendedCombo AttributeRealWidth50With";
         Combo_coscod_Cls = "ExtendedCombo AttributeRealWidth50With";
         Combo_movcod_Cls = "ExtendedCombo AttributeRealWidth50With";
         Combo_almcod_Cls = "ExtendedCombo AttributeRealWidth50With";
         Form.Headerrawhtml = "";
         Form.Background = "";
         Form.Textcolor = 0;
         Form.Backcolor = (int)(0xFFFFFF);
         Form.Caption = "Kardex Por Producto";
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
         setEventMetadata("REFRESH","{handler:'Refresh',iparms:[]");
         setEventMetadata("REFRESH",",oparms:[]}");
         setEventMetadata("'DOBTNIMPRIMIR'","{handler:'E136D2',iparms:[{av:'AV48AlmCod',fld:'vALMCOD',pic:'ZZZZZ9'},{av:'AV50MVADLRef1',fld:'vMVADLREF1',pic:''},{av:'AV23ProdCod',fld:'vPRODCOD',pic:'@!'},{av:'AV13FDesde',fld:'vFDESDE',pic:''},{av:'AV15FHasta',fld:'vFHASTA',pic:''},{av:'AV5CliCod',fld:'vCLICOD',pic:''},{av:'AV41MVCliOrigen',fld:'vMVCLIORIGEN',pic:'ZZZZZ9'},{av:'AV39MovCod',fld:'vMOVCOD',pic:'ZZZZZ9'},{av:'AV38CosCod',fld:'vCOSCOD',pic:''}]");
         setEventMetadata("'DOBTNIMPRIMIR'",",oparms:[{av:'Innewwindow_Target',ctrl:'INNEWWINDOW',prop:'Target'}]}");
         setEventMetadata("'DOBTNEXCEL'","{handler:'E146D2',iparms:[{av:'AV48AlmCod',fld:'vALMCOD',pic:'ZZZZZ9'},{av:'AV23ProdCod',fld:'vPRODCOD',pic:'@!'},{av:'AV13FDesde',fld:'vFDESDE',pic:''},{av:'AV15FHasta',fld:'vFHASTA',pic:''},{av:'AV5CliCod',fld:'vCLICOD',pic:''},{av:'AV41MVCliOrigen',fld:'vMVCLIORIGEN',pic:'ZZZZZ9'},{av:'AV39MovCod',fld:'vMOVCOD',pic:'ZZZZZ9'},{av:'AV38CosCod',fld:'vCOSCOD',pic:''}]");
         setEventMetadata("'DOBTNEXCEL'",",oparms:[{av:'AV38CosCod',fld:'vCOSCOD',pic:''},{av:'AV39MovCod',fld:'vMOVCOD',pic:'ZZZZZ9'},{av:'AV41MVCliOrigen',fld:'vMVCLIORIGEN',pic:'ZZZZZ9'},{av:'AV5CliCod',fld:'vCLICOD',pic:''},{av:'AV15FHasta',fld:'vFHASTA',pic:''},{av:'AV13FDesde',fld:'vFDESDE',pic:''},{av:'AV23ProdCod',fld:'vPRODCOD',pic:'@!'},{av:'AV48AlmCod',fld:'vALMCOD',pic:'ZZZZZ9'}]}");
         setEventMetadata("'DOBTNSALIR'","{handler:'E156D2',iparms:[]");
         setEventMetadata("'DOBTNSALIR'",",oparms:[]}");
         setEventMetadata("'DOBTNBUSCAR'","{handler:'E186D1',iparms:[]");
         setEventMetadata("'DOBTNBUSCAR'",",oparms:[{av:'AV7CliDsc',fld:'vCLIDSC',pic:''},{av:'AV5CliCod',fld:'vCLICOD',pic:''}]}");
         setEventMetadata("'DOBTNBUSCARPRO'","{handler:'E176D1',iparms:[]");
         setEventMetadata("'DOBTNBUSCARPRO'",",oparms:[{av:'AV24ProdDsc',fld:'vPRODDSC',pic:''},{av:'AV23ProdCod',fld:'vPRODCOD',pic:'@!'}]}");
         setEventMetadata("COMBO_MVCLIORIGEN.ONOPTIONCLICKED","{handler:'E116D2',iparms:[{av:'Combo_mvcliorigen_Selectedvalue_get',ctrl:'COMBO_MVCLIORIGEN',prop:'SelectedValue_get'}]");
         setEventMetadata("COMBO_MVCLIORIGEN.ONOPTIONCLICKED",",oparms:[{av:'AV41MVCliOrigen',fld:'vMVCLIORIGEN',pic:'ZZZZZ9'}]}");
         setEventMetadata("VALIDV_FDESDE","{handler:'Validv_Fdesde',iparms:[]");
         setEventMetadata("VALIDV_FDESDE",",oparms:[]}");
         setEventMetadata("VALIDV_FHASTA","{handler:'Validv_Fhasta',iparms:[]");
         setEventMetadata("VALIDV_FHASTA",",oparms:[]}");
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
         Combo_mvcliorigen_Selectedvalue_get = "";
         Combo_coscod_Selectedvalue_get = "";
         Combo_movcod_Selectedvalue_get = "";
         Combo_almcod_Selectedvalue_get = "";
         gxfirstwebparm = "";
         gxfirstwebparm_bkp = "";
         sDynURL = "";
         FormProcess = "";
         bodyStyle = "";
         GXKey = "";
         AV42DDO_TitleSettingsIcons = new GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTDropDownOptionsTitleSettingsIcons(context);
         AV49AlmCod_Data = new GXBaseCollection<GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTComboData_Item>( context, "Item", "");
         AV44MovCod_Data = new GXBaseCollection<GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTComboData_Item>( context, "Item", "");
         AV43CosCod_Data = new GXBaseCollection<GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTComboData_Item>( context, "Item", "");
         AV45MVCliOrigen_Data = new GXBaseCollection<GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTComboData_Item>( context, "Item", "");
         Combo_almcod_Selectedvalue_set = "";
         Combo_movcod_Selectedvalue_set = "";
         Combo_coscod_Selectedvalue_set = "";
         Combo_mvcliorigen_Selectedvalue_set = "";
         Combo_mvcliorigen_Selectedtext_set = "";
         GX_FocusControl = "";
         Form = new GXWebForm();
         sPrefix = "";
         ClassString = "";
         StyleString = "";
         ucDvpanel_panel = new GXUserControl();
         lblTextblockcombo_almcod_Jsonclick = "";
         ucCombo_almcod = new GXUserControl();
         lblTextblockcombo_movcod_Jsonclick = "";
         ucCombo_movcod = new GXUserControl();
         lblTextblockcombo_coscod_Jsonclick = "";
         ucCombo_coscod = new GXUserControl();
         lblTextblockclicod_Jsonclick = "";
         lblTextblockcombo_mvcliorigen_Jsonclick = "";
         ucCombo_mvcliorigen = new GXUserControl();
         lblTextblockprodcod_Jsonclick = "";
         lblTextblockmvadlref1_Jsonclick = "";
         TempTags = "";
         AV50MVADLRef1 = "";
         lblTextblockfdesde_Jsonclick = "";
         AV13FDesde = DateTime.MinValue;
         lblTextblockfhasta_Jsonclick = "";
         AV15FHasta = DateTime.MinValue;
         bttBtnbtnimprimir_Jsonclick = "";
         bttBtnbtnexcel_Jsonclick = "";
         bttBtnbtnsalir_Jsonclick = "";
         ucInnewwindow = new GXUserControl();
         AV38CosCod = "";
         sEvt = "";
         EvtGridId = "";
         EvtRowId = "";
         sEvtType = "";
         AV5CliCod = "";
         AV7CliDsc = "";
         AV23ProdCod = "";
         AV24ProdDsc = "";
         GXt_SdtDVB_SDTDropDownOptionsTitleSettingsIcons1 = new GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTDropDownOptionsTitleSettingsIcons(context);
         AV47URL = "";
         GXEncryptionTmp = "";
         AV10ExcelFilename = "";
         AV9ErrorMessage = "";
         AV46Cond_CliCod = "";
         scmdbuf = "";
         H006D2_A45CliCod = new string[] {""} ;
         H006D2_A164CliDirItem = new int[1] ;
         H006D2_A600CliDirDsc = new string[] {""} ;
         A600CliDirDsc = "";
         H006D3_A762COSSts = new short[1] ;
         H006D3_A79COSCod = new string[] {""} ;
         H006D3_A761COSDsc = new string[] {""} ;
         A79COSCod = "";
         A761COSDsc = "";
         AV8Combo_DataItem = new GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTComboData_Item(context);
         H006D4_A1240MovSts = new short[1] ;
         H006D4_A234MovCod = new int[1] ;
         H006D4_A1239MovDsc = new string[] {""} ;
         A1239MovDsc = "";
         H006D5_A438AlmSts = new short[1] ;
         H006D5_A63AlmCod = new int[1] ;
         H006D5_A436AlmDsc = new string[] {""} ;
         A436AlmDsc = "";
         sStyleString = "";
         sImgUrl = "";
         imgBtnbuscarpro_Jsonclick = "";
         imgBtnbuscar_Jsonclick = "";
         BackMsgLst = new msglist();
         LclMsgLst = new msglist();
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.almacen.r_kardexporproducto__default(),
            new Object[][] {
                new Object[] {
               H006D2_A45CliCod, H006D2_A164CliDirItem, H006D2_A600CliDirDsc
               }
               , new Object[] {
               H006D3_A762COSSts, H006D3_A79COSCod, H006D3_A761COSDsc
               }
               , new Object[] {
               H006D4_A1240MovSts, H006D4_A234MovCod, H006D4_A1239MovDsc
               }
               , new Object[] {
               H006D5_A438AlmSts, H006D5_A63AlmCod, H006D5_A436AlmDsc
               }
            }
         );
         /* GeneXus formulas. */
         context.Gx_err = 0;
         edtavClidsc_Enabled = 0;
         edtavProddsc_Enabled = 0;
      }

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
      private short nDonePA ;
      private short AV37Tipo ;
      private short AV53GXLvl154 ;
      private short A762COSSts ;
      private short A1240MovSts ;
      private short A438AlmSts ;
      private short nGXWrapped ;
      private int edtavMvadlref1_Enabled ;
      private int edtavFdesde_Enabled ;
      private int edtavFhasta_Enabled ;
      private int AV48AlmCod ;
      private int edtavAlmcod_Visible ;
      private int AV39MovCod ;
      private int edtavMovcod_Visible ;
      private int edtavCoscod_Visible ;
      private int AV41MVCliOrigen ;
      private int edtavMvcliorigen_Visible ;
      private int edtavClidsc_Enabled ;
      private int edtavProddsc_Enabled ;
      private int A164CliDirItem ;
      private int A234MovCod ;
      private int A63AlmCod ;
      private int edtavProdcod_Enabled ;
      private int edtavClicod_Enabled ;
      private int idxLst ;
      private string Combo_mvcliorigen_Selectedvalue_get ;
      private string Combo_coscod_Selectedvalue_get ;
      private string Combo_movcod_Selectedvalue_get ;
      private string Combo_almcod_Selectedvalue_get ;
      private string gxfirstwebparm ;
      private string gxfirstwebparm_bkp ;
      private string sDynURL ;
      private string FormProcess ;
      private string bodyStyle ;
      private string GXKey ;
      private string Combo_almcod_Cls ;
      private string Combo_almcod_Selectedvalue_set ;
      private string Combo_movcod_Cls ;
      private string Combo_movcod_Selectedvalue_set ;
      private string Combo_coscod_Cls ;
      private string Combo_coscod_Selectedvalue_set ;
      private string Combo_mvcliorigen_Cls ;
      private string Combo_mvcliorigen_Selectedvalue_set ;
      private string Combo_mvcliorigen_Selectedtext_set ;
      private string Combo_mvcliorigen_Datalistproc ;
      private string Combo_mvcliorigen_Datalistprocparametersprefix ;
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
      private string divTablesplittedalmcod_Internalname ;
      private string lblTextblockcombo_almcod_Internalname ;
      private string lblTextblockcombo_almcod_Jsonclick ;
      private string Combo_almcod_Caption ;
      private string Combo_almcod_Internalname ;
      private string divTablesplittedmovcod_Internalname ;
      private string lblTextblockcombo_movcod_Internalname ;
      private string lblTextblockcombo_movcod_Jsonclick ;
      private string Combo_movcod_Caption ;
      private string Combo_movcod_Internalname ;
      private string divTablesplittedcoscod_Internalname ;
      private string lblTextblockcombo_coscod_Internalname ;
      private string lblTextblockcombo_coscod_Jsonclick ;
      private string Combo_coscod_Caption ;
      private string Combo_coscod_Internalname ;
      private string divTablesplittedclicod_Internalname ;
      private string lblTextblockclicod_Internalname ;
      private string lblTextblockclicod_Jsonclick ;
      private string divTablesplittedmvcliorigen_Internalname ;
      private string lblTextblockcombo_mvcliorigen_Internalname ;
      private string lblTextblockcombo_mvcliorigen_Jsonclick ;
      private string Combo_mvcliorigen_Caption ;
      private string Combo_mvcliorigen_Internalname ;
      private string divTablesplittedprodcod_Internalname ;
      private string lblTextblockprodcod_Internalname ;
      private string lblTextblockprodcod_Jsonclick ;
      private string divUnnamedtablemvadlref1_Internalname ;
      private string lblTextblockmvadlref1_Internalname ;
      private string lblTextblockmvadlref1_Jsonclick ;
      private string edtavMvadlref1_Internalname ;
      private string TempTags ;
      private string edtavMvadlref1_Jsonclick ;
      private string divUnnamedtablefdesde_Internalname ;
      private string lblTextblockfdesde_Internalname ;
      private string lblTextblockfdesde_Jsonclick ;
      private string edtavFdesde_Internalname ;
      private string edtavFdesde_Jsonclick ;
      private string divUnnamedtablefhasta_Internalname ;
      private string lblTextblockfhasta_Internalname ;
      private string lblTextblockfhasta_Jsonclick ;
      private string edtavFhasta_Internalname ;
      private string edtavFhasta_Jsonclick ;
      private string bttBtnbtnimprimir_Internalname ;
      private string bttBtnbtnimprimir_Jsonclick ;
      private string bttBtnbtnexcel_Internalname ;
      private string bttBtnbtnexcel_Jsonclick ;
      private string bttBtnbtnsalir_Internalname ;
      private string bttBtnbtnsalir_Jsonclick ;
      private string Innewwindow_Internalname ;
      private string divHtml_bottomauxiliarcontrols_Internalname ;
      private string edtavAlmcod_Internalname ;
      private string edtavAlmcod_Jsonclick ;
      private string edtavMovcod_Internalname ;
      private string edtavMovcod_Jsonclick ;
      private string edtavCoscod_Internalname ;
      private string AV38CosCod ;
      private string edtavCoscod_Jsonclick ;
      private string edtavMvcliorigen_Internalname ;
      private string edtavMvcliorigen_Jsonclick ;
      private string sEvt ;
      private string EvtGridId ;
      private string EvtRowId ;
      private string sEvtType ;
      private string edtavClicod_Internalname ;
      private string edtavClidsc_Internalname ;
      private string edtavProddsc_Internalname ;
      private string AV5CliCod ;
      private string AV7CliDsc ;
      private string AV23ProdCod ;
      private string edtavProdcod_Internalname ;
      private string AV24ProdDsc ;
      private string GXEncryptionTmp ;
      private string AV46Cond_CliCod ;
      private string scmdbuf ;
      private string A600CliDirDsc ;
      private string A79COSCod ;
      private string A761COSDsc ;
      private string A1239MovDsc ;
      private string A436AlmDsc ;
      private string sStyleString ;
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
      private string AV50MVADLRef1 ;
      private string AV47URL ;
      private string AV10ExcelFilename ;
      private string AV9ErrorMessage ;
      private GXUserControl ucDvpanel_panel ;
      private GXUserControl ucCombo_almcod ;
      private GXUserControl ucCombo_movcod ;
      private GXUserControl ucCombo_coscod ;
      private GXUserControl ucCombo_mvcliorigen ;
      private GXUserControl ucInnewwindow ;
      private IGxDataStore dsDataStore2 ;
      private IGxDataStore dsDefault ;
      private IDataStoreProvider pr_default ;
      private string[] H006D2_A45CliCod ;
      private int[] H006D2_A164CliDirItem ;
      private string[] H006D2_A600CliDirDsc ;
      private short[] H006D3_A762COSSts ;
      private string[] H006D3_A79COSCod ;
      private string[] H006D3_A761COSDsc ;
      private short[] H006D4_A1240MovSts ;
      private int[] H006D4_A234MovCod ;
      private string[] H006D4_A1239MovDsc ;
      private short[] H006D5_A438AlmSts ;
      private int[] H006D5_A63AlmCod ;
      private string[] H006D5_A436AlmDsc ;
      private msglist BackMsgLst ;
      private msglist LclMsgLst ;
      private GXBaseCollection<GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTComboData_Item> AV49AlmCod_Data ;
      private GXBaseCollection<GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTComboData_Item> AV44MovCod_Data ;
      private GXBaseCollection<GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTComboData_Item> AV43CosCod_Data ;
      private GXBaseCollection<GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTComboData_Item> AV45MVCliOrigen_Data ;
      private GXWebForm Form ;
      private GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTComboData_Item AV8Combo_DataItem ;
      private GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTDropDownOptionsTitleSettingsIcons AV42DDO_TitleSettingsIcons ;
      private GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTDropDownOptionsTitleSettingsIcons GXt_SdtDVB_SDTDropDownOptionsTitleSettingsIcons1 ;
   }

   public class r_kardexporproducto__default : DataStoreHelperBase, IDataStoreHelper
   {
      public ICursor[] getCursors( )
      {
         cursorDefinitions();
         return new Cursor[] {
          new ForEachCursor(def[0])
         ,new ForEachCursor(def[1])
         ,new ForEachCursor(def[2])
         ,new ForEachCursor(def[3])
       };
    }

    private static CursorDef[] def;
    private void cursorDefinitions( )
    {
       if ( def == null )
       {
          Object[] prmH006D2;
          prmH006D2 = new Object[] {
          new ParDef("@AV41MVCliOrigen",GXType.Int32,6,0)
          };
          Object[] prmH006D3;
          prmH006D3 = new Object[] {
          };
          Object[] prmH006D4;
          prmH006D4 = new Object[] {
          };
          Object[] prmH006D5;
          prmH006D5 = new Object[] {
          };
          def= new CursorDef[] {
              new CursorDef("H006D2", "SELECT TOP 1 [CliCod], [CliDirItem], [CliDirDsc] FROM [CLCLIENTESDIRECCION] WHERE [CliDirItem] = @AV41MVCliOrigen ORDER BY [CliCod], [CliDirItem] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH006D2,1, GxCacheFrequency.OFF ,false,true )
             ,new CursorDef("H006D3", "SELECT [COSSts], [COSCod], [COSDsc] FROM [CBCOSTOS] WHERE [COSSts] = 1 ORDER BY [COSDsc] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH006D3,100, GxCacheFrequency.OFF ,false,false )
             ,new CursorDef("H006D4", "SELECT [MovSts], [MovCod], [MovDsc] FROM [CMOVALMACEN] WHERE [MovSts] = 1 ORDER BY [MovDsc] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH006D4,100, GxCacheFrequency.OFF ,false,false )
             ,new CursorDef("H006D5", "SELECT [AlmSts], [AlmCod], [AlmDsc] FROM [CALMACEN] WHERE [AlmSts] = 1 ORDER BY [AlmDsc] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH006D5,100, GxCacheFrequency.OFF ,false,false )
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
                ((string[]) buf[0])[0] = rslt.getString(1, 20);
                ((int[]) buf[1])[0] = rslt.getInt(2);
                ((string[]) buf[2])[0] = rslt.getString(3, 100);
                return;
             case 1 :
                ((short[]) buf[0])[0] = rslt.getShort(1);
                ((string[]) buf[1])[0] = rslt.getString(2, 10);
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
       }
    }

 }

}
