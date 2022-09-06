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
   public class r_stockactualconsolidado : GXDataArea
   {
      public r_stockactualconsolidado( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDataStore2 = context.GetDataStore("DataStore2");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusTheme");
      }

      public r_stockactualconsolidado( IGxContext context )
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
         radavTipoorden = new GXRadio();
         radavSubtotal = new GXRadio();
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
         PA2W2( ) ;
         gxajaxcallmode = (short)((isAjaxCallMode( ) ? 1 : 0));
         if ( ( gxajaxcallmode == 0 ) && ( GxWebError == 0 ) )
         {
            START2W2( ) ;
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
         context.AddJavascriptSource("gxcfg.js", "?202281810305213", false, true);
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
         context.WriteHtmlTextNl( "<form id=\"MAINFORM\" autocomplete=\"off\" name=\"MAINFORM\" method=\"post\" tabindex=-1  class=\"form-horizontal Form\" data-gx-class=\"form-horizontal Form\" novalidate action=\""+formatLink("almacen.r_stockactualconsolidado.aspx") +"\">") ;
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
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "vALMCOD_DATA", AV6AlmCod_Data);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt("vALMCOD_DATA", AV6AlmCod_Data);
         }
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "vLINCOD_DATA", AV14LinCod_Data);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt("vLINCOD_DATA", AV14LinCod_Data);
         }
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "vSUBLCOD_DATA", AV19SubLCod_Data);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt("vSUBLCOD_DATA", AV19SubLCod_Data);
         }
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "vFAMCOD_DATA", AV11FamCod_Data);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt("vFAMCOD_DATA", AV11FamCod_Data);
         }
         GxWebStd.gx_hidden_field( context, "COMBO_ALMCOD_Cls", StringUtil.RTrim( Combo_almcod_Cls));
         GxWebStd.gx_hidden_field( context, "COMBO_ALMCOD_Selectedvalue_set", StringUtil.RTrim( Combo_almcod_Selectedvalue_set));
         GxWebStd.gx_hidden_field( context, "COMBO_LINCOD_Cls", StringUtil.RTrim( Combo_lincod_Cls));
         GxWebStd.gx_hidden_field( context, "COMBO_LINCOD_Selectedvalue_set", StringUtil.RTrim( Combo_lincod_Selectedvalue_set));
         GxWebStd.gx_hidden_field( context, "COMBO_SUBLCOD_Cls", StringUtil.RTrim( Combo_sublcod_Cls));
         GxWebStd.gx_hidden_field( context, "COMBO_SUBLCOD_Selectedvalue_set", StringUtil.RTrim( Combo_sublcod_Selectedvalue_set));
         GxWebStd.gx_hidden_field( context, "COMBO_FAMCOD_Cls", StringUtil.RTrim( Combo_famcod_Cls));
         GxWebStd.gx_hidden_field( context, "COMBO_FAMCOD_Selectedvalue_set", StringUtil.RTrim( Combo_famcod_Selectedvalue_set));
         GxWebStd.gx_hidden_field( context, "DVPANEL_PANEL1_Width", StringUtil.RTrim( Dvpanel_panel1_Width));
         GxWebStd.gx_hidden_field( context, "DVPANEL_PANEL1_Autowidth", StringUtil.BoolToStr( Dvpanel_panel1_Autowidth));
         GxWebStd.gx_hidden_field( context, "DVPANEL_PANEL1_Autoheight", StringUtil.BoolToStr( Dvpanel_panel1_Autoheight));
         GxWebStd.gx_hidden_field( context, "DVPANEL_PANEL1_Cls", StringUtil.RTrim( Dvpanel_panel1_Cls));
         GxWebStd.gx_hidden_field( context, "DVPANEL_PANEL1_Title", StringUtil.RTrim( Dvpanel_panel1_Title));
         GxWebStd.gx_hidden_field( context, "DVPANEL_PANEL1_Collapsible", StringUtil.BoolToStr( Dvpanel_panel1_Collapsible));
         GxWebStd.gx_hidden_field( context, "DVPANEL_PANEL1_Collapsed", StringUtil.BoolToStr( Dvpanel_panel1_Collapsed));
         GxWebStd.gx_hidden_field( context, "DVPANEL_PANEL1_Showcollapseicon", StringUtil.BoolToStr( Dvpanel_panel1_Showcollapseicon));
         GxWebStd.gx_hidden_field( context, "DVPANEL_PANEL1_Iconposition", StringUtil.RTrim( Dvpanel_panel1_Iconposition));
         GxWebStd.gx_hidden_field( context, "DVPANEL_PANEL1_Autoscroll", StringUtil.BoolToStr( Dvpanel_panel1_Autoscroll));
         GxWebStd.gx_hidden_field( context, "INNEWWINDOW_Target", StringUtil.RTrim( Innewwindow_Target));
         GxWebStd.gx_hidden_field( context, "COMBO_FAMCOD_Selectedvalue_get", StringUtil.RTrim( Combo_famcod_Selectedvalue_get));
         GxWebStd.gx_hidden_field( context, "COMBO_SUBLCOD_Selectedvalue_get", StringUtil.RTrim( Combo_sublcod_Selectedvalue_get));
         GxWebStd.gx_hidden_field( context, "COMBO_LINCOD_Selectedvalue_get", StringUtil.RTrim( Combo_lincod_Selectedvalue_get));
         GxWebStd.gx_hidden_field( context, "COMBO_ALMCOD_Selectedvalue_get", StringUtil.RTrim( Combo_almcod_Selectedvalue_get));
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
            WE2W2( ) ;
            context.WriteHtmlText( "</div>") ;
         }
      }

      public override void DispatchEvents( )
      {
         EVT2W2( ) ;
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
         return formatLink("almacen.r_stockactualconsolidado.aspx")  ;
      }

      public override string GetPgmname( )
      {
         return "Almacen.R_StockActualConsolidado" ;
      }

      public override string GetPgmdesc( )
      {
         return "Stock Actual Consolidado" ;
      }

      protected void WB2W0( )
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
            ucDvpanel_panel1.SetProperty("Width", Dvpanel_panel1_Width);
            ucDvpanel_panel1.SetProperty("AutoWidth", Dvpanel_panel1_Autowidth);
            ucDvpanel_panel1.SetProperty("AutoHeight", Dvpanel_panel1_Autoheight);
            ucDvpanel_panel1.SetProperty("Cls", Dvpanel_panel1_Cls);
            ucDvpanel_panel1.SetProperty("Title", Dvpanel_panel1_Title);
            ucDvpanel_panel1.SetProperty("Collapsible", Dvpanel_panel1_Collapsible);
            ucDvpanel_panel1.SetProperty("Collapsed", Dvpanel_panel1_Collapsed);
            ucDvpanel_panel1.SetProperty("ShowCollapseIcon", Dvpanel_panel1_Showcollapseicon);
            ucDvpanel_panel1.SetProperty("IconPosition", Dvpanel_panel1_Iconposition);
            ucDvpanel_panel1.SetProperty("AutoScroll", Dvpanel_panel1_Autoscroll);
            ucDvpanel_panel1.Render(context, "dvelop.gxbootstrap.panel_al", Dvpanel_panel1_Internalname, "DVPANEL_PANEL1Container");
            context.WriteHtmlText( "<div class=\"gx_usercontrol_child\" id=\""+"DVPANEL_PANEL1Container"+"Panel1"+"\" style=\"display:none;\">") ;
            /* Div Control */
            GxWebStd.gx_div_start( context, divPanel1_Internalname, 1, 0, "px", 0, "px", "", "left", "top", "", "", "div");
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
            GxWebStd.gx_label_ctrl( context, lblTextblockcombo_almcod_Internalname, "Almacen", "", "", lblTextblockcombo_almcod_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "Label", 0, "", 1, 1, 0, 0, "HLP_Almacen\\R_StockActualConsolidado.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-6 CellWidth_87_5", "left", "top", "", "", "div");
            /* User Defined Control */
            ucCombo_almcod.SetProperty("Caption", Combo_almcod_Caption);
            ucCombo_almcod.SetProperty("Cls", Combo_almcod_Cls);
            ucCombo_almcod.SetProperty("DropDownOptionsData", AV6AlmCod_Data);
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
            GxWebStd.gx_div_start( context, divTablesplittedlincod_Internalname, 1, 0, "px", 0, "px", "Table", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-6 MergeLabelCell CellWidth_12_5", "left", "top", "", "", "div");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblTextblockcombo_lincod_Internalname, "Linea Producto", "", "", lblTextblockcombo_lincod_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "Label", 0, "", 1, 1, 0, 0, "HLP_Almacen\\R_StockActualConsolidado.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-6 CellWidth_87_5", "left", "top", "", "", "div");
            /* User Defined Control */
            ucCombo_lincod.SetProperty("Caption", Combo_lincod_Caption);
            ucCombo_lincod.SetProperty("Cls", Combo_lincod_Cls);
            ucCombo_lincod.SetProperty("DropDownOptionsData", AV14LinCod_Data);
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
            GxWebStd.gx_label_ctrl( context, lblTextblockcombo_sublcod_Internalname, "Sub Linea", "", "", lblTextblockcombo_sublcod_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "Label", 0, "", 1, 1, 0, 0, "HLP_Almacen\\R_StockActualConsolidado.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-6 CellWidth_87_5", "left", "top", "", "", "div");
            /* User Defined Control */
            ucCombo_sublcod.SetProperty("Caption", Combo_sublcod_Caption);
            ucCombo_sublcod.SetProperty("Cls", Combo_sublcod_Cls);
            ucCombo_sublcod.SetProperty("DropDownOptionsData", AV19SubLCod_Data);
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
            GxWebStd.gx_div_start( context, divTablesplittedfamcod_Internalname, 1, 0, "px", 0, "px", "Table", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-6 MergeLabelCell CellWidth_12_5", "left", "top", "", "", "div");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblTextblockcombo_famcod_Internalname, "Familia", "", "", lblTextblockcombo_famcod_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "Label", 0, "", 1, 1, 0, 0, "HLP_Almacen\\R_StockActualConsolidado.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-6 CellWidth_87_5", "left", "top", "", "", "div");
            /* User Defined Control */
            ucCombo_famcod.SetProperty("Caption", Combo_famcod_Caption);
            ucCombo_famcod.SetProperty("Cls", Combo_famcod_Cls);
            ucCombo_famcod.SetProperty("DropDownOptionsData", AV11FamCod_Data);
            ucCombo_famcod.Render(context, "dvelop.gxbootstrap.ddoextendedcombo", Combo_famcod_Internalname, "COMBO_FAMCODContainer");
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
            GxWebStd.gx_label_ctrl( context, lblTextblockprodcod_Internalname, "Producto", "", "", lblTextblockprodcod_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "Label", 0, "", 1, 1, 0, 0, "HLP_Almacen\\R_StockActualConsolidado.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-6 CellWidth_87_5", "left", "top", "", "", "div");
            wb_table1_57_2W2( true) ;
         }
         else
         {
            wb_table1_57_2W2( false) ;
         }
         return  ;
      }

      protected void wb_table1_57_2W2e( bool wbgen )
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
            GxWebStd.gx_div_start( context, divUnnamedtablefecha_Internalname, 1, 0, "px", 0, "px", "Table", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-6 MergeLabelCell CellWidth_12_5", "left", "top", "", "", "div");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblTextblockfecha_Internalname, "Fecha", "", "", lblTextblockfecha_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "Label", 0, "", 1, 1, 0, 0, "HLP_Almacen\\R_StockActualConsolidado.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-6 CellWidth_87_5", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "left", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavFecha_Internalname, "Fecha", "col-sm-3 AttributeDateLabel", 0, true, "");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 75,'',false,'',0)\"";
            context.WriteHtmlText( "<div id=\""+edtavFecha_Internalname+"_dp_container\" class=\"dp_container\" style=\"white-space:nowrap;display:inline;\">") ;
            GxWebStd.gx_single_line_edit( context, edtavFecha_Internalname, context.localUtil.Format(AV12Fecha, "99/99/99"), context.localUtil.Format( AV12Fecha, "99/99/99"), TempTags+" onchange=\""+"gx.date.valid_date(this, 8,'DMY',0,24,'spa',false,0);"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.date.valid_date(this, 8,'DMY',0,24,'spa',false,0);"+";gx.evt.onblur(this,75);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavFecha_Jsonclick, 0, "AttributeDate", "", "", "", "", 1, edtavFecha_Enabled, 0, "text", "", 8, "chr", 1, "row", 8, 0, 0, 0, 1, -1, 0, true, "", "right", false, "", "HLP_Almacen\\R_StockActualConsolidado.htm");
            GxWebStd.gx_bitmap( context, edtavFecha_Internalname+"_dp_trigger", context.GetImagePath( "61b9b5d3-dff6-4d59-9b00-da61bc2cbe93", "", context.GetTheme( )), "", "", "", "", ((1==0)||(edtavFecha_Enabled==0) ? 0 : 1), 0, "Date selector", "Date selector", 0, 1, 0, "", 0, "", 0, 0, 0, "", "", "cursor: pointer;", "", "", "", "", "", "", "", "", 1, false, false, "", "HLP_Almacen\\R_StockActualConsolidado.htm");
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
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 DataContentCell", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divUnnamedtabletipoorden_Internalname, 1, 0, "px", 0, "px", "Table", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-6 MergeLabelCell CellWidth_12_5", "left", "top", "", "", "div");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblTextblocktipoorden_Internalname, "Ordenado por", "", "", lblTextblocktipoorden_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "Label", 0, "", 1, 1, 0, 0, "HLP_Almacen\\R_StockActualConsolidado.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-6 CellWidth_87_5", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "left", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, "", "Ordenado por", "col-sm-3 AttributeCheckBoxLabel", 0, true, "");
            /* Radio button */
            ClassString = "AttributeCheckBox";
            StyleString = "";
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 84,'',false,'',0)\"";
            GxWebStd.gx_radio_ctrl( context, radavTipoorden, radavTipoorden_Internalname, StringUtil.Str( (decimal)(AV20TipoOrden), 1, 0), "", 1, 1, 0, 0, StyleString, ClassString, "", "", 0, radavTipoorden_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", TempTags+" onclick="+"\""+"gx.evt.onchange(this, event);\""+" onblur=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onblur(this,84);\"", "HLP_Almacen\\R_StockActualConsolidado.htm");
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
            GxWebStd.gx_div_start( context, divUnnamedtablesubtotal_Internalname, 1, 0, "px", 0, "px", "Table", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-6 MergeLabelCell CellWidth_12_5", "left", "top", "", "", "div");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblTextblocksubtotal_Internalname, "Sub Totales", "", "", lblTextblocksubtotal_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "Label", 0, "", 1, 1, 0, 0, "HLP_Almacen\\R_StockActualConsolidado.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-6 CellWidth_87_5", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "left", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, "", "Sub Total", "col-sm-3 AttributeCheckBoxLabel", 0, true, "");
            /* Radio button */
            ClassString = "AttributeCheckBox";
            StyleString = "";
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 93,'',false,'',0)\"";
            GxWebStd.gx_radio_ctrl( context, radavSubtotal, radavSubtotal_Internalname, StringUtil.RTrim( AV23SubTotal), "", 1, 1, 0, 0, StyleString, ClassString, "", "", 0, radavSubtotal_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", TempTags+" onclick="+"\""+"gx.evt.onchange(this, event);\""+" onblur=\""+""+";gx.evt.onblur(this,93);\"", "HLP_Almacen\\R_StockActualConsolidado.htm");
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
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 98,'',false,'',0)\"";
            ClassString = "ButtonPDF";
            StyleString = "";
            GxWebStd.gx_button_ctrl( context, bttBtnbtnimprimir_Internalname, "", "Imprimir", bttBtnbtnimprimir_Jsonclick, 5, "Imprimir", "", StyleString, ClassString, 1, 1, "standard", "'"+""+"'"+",false,"+"'"+"E\\'DOBTNIMPRIMIR\\'."+"'", TempTags, "", context.GetButtonType( ), "HLP_Almacen\\R_StockActualConsolidado.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "left", "top", "", "", "div");
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 100,'',false,'',0)\"";
            ClassString = "ButtonExcel";
            StyleString = "";
            GxWebStd.gx_button_ctrl( context, bttBtnbtnexcel_Internalname, "", "Excel", bttBtnbtnexcel_Jsonclick, 5, "Exportal a Excel", "", StyleString, ClassString, 1, 1, "standard", "'"+""+"'"+",false,"+"'"+"E\\'DOBTNEXCEL\\'."+"'", TempTags, "", context.GetButtonType( ), "HLP_Almacen\\R_StockActualConsolidado.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "left", "top", "", "", "div");
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 102,'',false,'',0)\"";
            ClassString = "ButtonColor";
            StyleString = "";
            GxWebStd.gx_button_ctrl( context, bttBtnbtnsalir_Internalname, "", "Salir", bttBtnbtnsalir_Jsonclick, 5, "Imprimir PDF", "", StyleString, ClassString, 1, 1, "standard", "'"+""+"'"+",false,"+"'"+"E\\'DOBTNSALIR\\'."+"'", TempTags, "", context.GetButtonType( ), "HLP_Almacen\\R_StockActualConsolidado.htm");
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
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 109,'',false,'',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavAlmcod_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(AV5AlmCod), 6, 0, ".", "")), StringUtil.LTrim( context.localUtil.Format( (decimal)(AV5AlmCod), "ZZZZZ9")), " inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onblur(this,109);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavAlmcod_Jsonclick, 0, "Attribute", "", "", "", "", edtavAlmcod_Visible, 1, 0, "text", "1", 6, "chr", 1, "row", 6, 0, 0, 0, 1, -1, 0, true, "", "right", false, "", "HLP_Almacen\\R_StockActualConsolidado.htm");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 110,'',false,'',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavLincod_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(AV13LinCod), 6, 0, ".", "")), StringUtil.LTrim( context.localUtil.Format( (decimal)(AV13LinCod), "ZZZZZ9")), " inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onblur(this,110);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavLincod_Jsonclick, 0, "Attribute", "", "", "", "", edtavLincod_Visible, 1, 0, "text", "1", 6, "chr", 1, "row", 6, 0, 0, 0, 1, -1, 0, true, "", "right", false, "", "HLP_Almacen\\R_StockActualConsolidado.htm");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 111,'',false,'',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavSublcod_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(AV18SubLCod), 6, 0, ".", "")), StringUtil.LTrim( context.localUtil.Format( (decimal)(AV18SubLCod), "ZZZZZ9")), " inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onblur(this,111);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavSublcod_Jsonclick, 0, "Attribute", "", "", "", "", edtavSublcod_Visible, 1, 0, "text", "1", 6, "chr", 1, "row", 6, 0, 0, 0, 1, -1, 0, true, "", "right", false, "", "HLP_Almacen\\R_StockActualConsolidado.htm");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 112,'',false,'',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavFamcod_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(AV10FamCod), 6, 0, ".", "")), StringUtil.LTrim( context.localUtil.Format( (decimal)(AV10FamCod), "ZZZZZ9")), " inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onblur(this,112);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavFamcod_Jsonclick, 0, "Attribute", "", "", "", "", edtavFamcod_Visible, 1, 0, "text", "1", 6, "chr", 1, "row", 6, 0, 0, 0, 1, -1, 0, true, "", "right", false, "", "HLP_Almacen\\R_StockActualConsolidado.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
         }
         wbLoad = true;
      }

      protected void START2W2( )
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
            Form.Meta.addItem("description", "Stock Actual Consolidado", 0) ;
         }
         context.wjLoc = "";
         context.nUserReturn = 0;
         context.wbHandled = 0;
         if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
         {
         }
         wbErr = false;
         STRUP2W0( ) ;
      }

      protected void WS2W2( )
      {
         START2W2( ) ;
         EVT2W2( ) ;
      }

      protected void EVT2W2( )
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
                              E112W2 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "'DOBTNIMPRIMIR'") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              /* Execute user event: 'DoBtnImprimir' */
                              E122W2 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "'DOBTNEXCEL'") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              /* Execute user event: 'DoBtnExcel' */
                              E132W2 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "'DOBTNSALIR'") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              /* Execute user event: 'DoBtnSalir' */
                              E142W2 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "'DOBTNBUSCAR'") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              /* Execute user event: 'DoBtnBuscar' */
                              E152W2 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "LOAD") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              /* Execute user event: Load */
                              E162W2 ();
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

      protected void WE2W2( )
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

      protected void PA2W2( )
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
               GX_FocusControl = edtavProdcod_Internalname;
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
         AV20TipoOrden = (short)(context.localUtil.CToN( StringUtil.LTrim( StringUtil.NToC( (decimal)(AV20TipoOrden), 1, 0, ".", "")), ".", ","));
         AssignAttri("", false, "AV20TipoOrden", StringUtil.Str( (decimal)(AV20TipoOrden), 1, 0));
         AssignAttri("", false, "AV23SubTotal", AV23SubTotal);
      }

      public void Refresh( )
      {
         send_integrity_hashes( ) ;
         RF2W2( ) ;
         if ( isFullAjaxMode( ) )
         {
            send_integrity_footer_hashes( ) ;
         }
      }

      protected void initialize_formulas( )
      {
         /* GeneXus formulas. */
         context.Gx_err = 0;
         edtavProddsc_Enabled = 0;
         AssignProp("", false, edtavProddsc_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavProddsc_Enabled), 5, 0), true);
         imgprompt_Prodcod_Proddsc_Link = "javascript:"+"gx.popup.openPrompt('"+"generales.wwbusquedaproducto.aspx"+"',["+"{Ctrl:gx.dom.el('"+"vPRODCOD"+"'), id:'"+"vPRODCOD"+"'"+",IOType:'out'}"+","+"{Ctrl:gx.dom.el('"+"vPRODDSC"+"'), id:'"+"vPRODDSC"+"'"+",IOType:'out'}"+","+""+"],"+"null"+","+"'', false"+","+"false"+");";
      }

      protected void RF2W2( )
      {
         initialize_formulas( ) ;
         clear_multi_value_controls( ) ;
         gxdyncontrolsrefreshing = true;
         fix_multi_value_controls( ) ;
         gxdyncontrolsrefreshing = false;
         if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
         {
            /* Execute user event: Load */
            E162W2 ();
            WB2W0( ) ;
         }
      }

      protected void send_integrity_lvl_hashes2W2( )
      {
      }

      protected void before_start_formulas( )
      {
         context.Gx_err = 0;
         edtavProddsc_Enabled = 0;
         AssignProp("", false, edtavProddsc_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavProddsc_Enabled), 5, 0), true);
         imgprompt_Prodcod_Proddsc_Link = "javascript:"+"gx.popup.openPrompt('"+"generales.wwbusquedaproducto.aspx"+"',["+"{Ctrl:gx.dom.el('"+"vPRODCOD"+"'), id:'"+"vPRODCOD"+"'"+",IOType:'out'}"+","+"{Ctrl:gx.dom.el('"+"vPRODDSC"+"'), id:'"+"vPRODDSC"+"'"+",IOType:'out'}"+","+""+"],"+"null"+","+"'', false"+","+"false"+");";
         fix_multi_value_controls( ) ;
      }

      protected void STRUP2W0( )
      {
         /* Before Start, stand alone formulas. */
         before_start_formulas( ) ;
         /* Execute Start event if defined. */
         context.wbGlbDoneStart = 0;
         /* Execute user event: Start */
         E112W2 ();
         context.wbGlbDoneStart = 1;
         /* After Start, stand alone formulas. */
         if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
         {
            /* Read saved SDTs. */
            ajax_req_read_hidden_sdt(cgiGet( "vALMCOD_DATA"), AV6AlmCod_Data);
            ajax_req_read_hidden_sdt(cgiGet( "vLINCOD_DATA"), AV14LinCod_Data);
            ajax_req_read_hidden_sdt(cgiGet( "vSUBLCOD_DATA"), AV19SubLCod_Data);
            ajax_req_read_hidden_sdt(cgiGet( "vFAMCOD_DATA"), AV11FamCod_Data);
            /* Read saved values. */
            Combo_almcod_Cls = cgiGet( "COMBO_ALMCOD_Cls");
            Combo_almcod_Selectedvalue_set = cgiGet( "COMBO_ALMCOD_Selectedvalue_set");
            Combo_lincod_Cls = cgiGet( "COMBO_LINCOD_Cls");
            Combo_lincod_Selectedvalue_set = cgiGet( "COMBO_LINCOD_Selectedvalue_set");
            Combo_sublcod_Cls = cgiGet( "COMBO_SUBLCOD_Cls");
            Combo_sublcod_Selectedvalue_set = cgiGet( "COMBO_SUBLCOD_Selectedvalue_set");
            Combo_famcod_Cls = cgiGet( "COMBO_FAMCOD_Cls");
            Combo_famcod_Selectedvalue_set = cgiGet( "COMBO_FAMCOD_Selectedvalue_set");
            Dvpanel_panel1_Width = cgiGet( "DVPANEL_PANEL1_Width");
            Dvpanel_panel1_Autowidth = StringUtil.StrToBool( cgiGet( "DVPANEL_PANEL1_Autowidth"));
            Dvpanel_panel1_Autoheight = StringUtil.StrToBool( cgiGet( "DVPANEL_PANEL1_Autoheight"));
            Dvpanel_panel1_Cls = cgiGet( "DVPANEL_PANEL1_Cls");
            Dvpanel_panel1_Title = cgiGet( "DVPANEL_PANEL1_Title");
            Dvpanel_panel1_Collapsible = StringUtil.StrToBool( cgiGet( "DVPANEL_PANEL1_Collapsible"));
            Dvpanel_panel1_Collapsed = StringUtil.StrToBool( cgiGet( "DVPANEL_PANEL1_Collapsed"));
            Dvpanel_panel1_Showcollapseicon = StringUtil.StrToBool( cgiGet( "DVPANEL_PANEL1_Showcollapseicon"));
            Dvpanel_panel1_Iconposition = cgiGet( "DVPANEL_PANEL1_Iconposition");
            Dvpanel_panel1_Autoscroll = StringUtil.StrToBool( cgiGet( "DVPANEL_PANEL1_Autoscroll"));
            Innewwindow_Target = cgiGet( "INNEWWINDOW_Target");
            /* Read variables values. */
            AV15ProdCod = StringUtil.Upper( cgiGet( edtavProdcod_Internalname));
            AssignAttri("", false, "AV15ProdCod", AV15ProdCod);
            AV16ProdDsc = cgiGet( edtavProddsc_Internalname);
            AssignAttri("", false, "AV16ProdDsc", AV16ProdDsc);
            if ( context.localUtil.VCDate( cgiGet( edtavFecha_Internalname), 2) == 0 )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_faildate", new   object[]  {"Fecha"}), 1, "vFECHA");
               GX_FocusControl = edtavFecha_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               AV12Fecha = DateTime.MinValue;
               AssignAttri("", false, "AV12Fecha", context.localUtil.Format(AV12Fecha, "99/99/99"));
            }
            else
            {
               AV12Fecha = context.localUtil.CToD( cgiGet( edtavFecha_Internalname), 2);
               AssignAttri("", false, "AV12Fecha", context.localUtil.Format(AV12Fecha, "99/99/99"));
            }
            if ( ( ( context.localUtil.CToN( cgiGet( radavTipoorden_Internalname), ".", ",") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( radavTipoorden_Internalname), ".", ",") > Convert.ToDecimal( 9 )) ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "vTIPOORDEN");
               wbErr = true;
               AV20TipoOrden = 0;
               AssignAttri("", false, "AV20TipoOrden", StringUtil.Str( (decimal)(AV20TipoOrden), 1, 0));
            }
            else
            {
               AV20TipoOrden = (short)(context.localUtil.CToN( cgiGet( radavTipoorden_Internalname), ".", ","));
               AssignAttri("", false, "AV20TipoOrden", StringUtil.Str( (decimal)(AV20TipoOrden), 1, 0));
            }
            AV23SubTotal = cgiGet( radavSubtotal_Internalname);
            AssignAttri("", false, "AV23SubTotal", AV23SubTotal);
            if ( ( ( context.localUtil.CToN( cgiGet( edtavAlmcod_Internalname), ".", ",") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtavAlmcod_Internalname), ".", ",") > Convert.ToDecimal( 999999 )) ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "vALMCOD");
               GX_FocusControl = edtavAlmcod_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               AV5AlmCod = 0;
               AssignAttri("", false, "AV5AlmCod", StringUtil.LTrimStr( (decimal)(AV5AlmCod), 6, 0));
            }
            else
            {
               AV5AlmCod = (int)(context.localUtil.CToN( cgiGet( edtavAlmcod_Internalname), ".", ","));
               AssignAttri("", false, "AV5AlmCod", StringUtil.LTrimStr( (decimal)(AV5AlmCod), 6, 0));
            }
            if ( ( ( context.localUtil.CToN( cgiGet( edtavLincod_Internalname), ".", ",") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtavLincod_Internalname), ".", ",") > Convert.ToDecimal( 999999 )) ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "vLINCOD");
               GX_FocusControl = edtavLincod_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               AV13LinCod = 0;
               AssignAttri("", false, "AV13LinCod", StringUtil.LTrimStr( (decimal)(AV13LinCod), 6, 0));
            }
            else
            {
               AV13LinCod = (int)(context.localUtil.CToN( cgiGet( edtavLincod_Internalname), ".", ","));
               AssignAttri("", false, "AV13LinCod", StringUtil.LTrimStr( (decimal)(AV13LinCod), 6, 0));
            }
            if ( ( ( context.localUtil.CToN( cgiGet( edtavSublcod_Internalname), ".", ",") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtavSublcod_Internalname), ".", ",") > Convert.ToDecimal( 999999 )) ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "vSUBLCOD");
               GX_FocusControl = edtavSublcod_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               AV18SubLCod = 0;
               AssignAttri("", false, "AV18SubLCod", StringUtil.LTrimStr( (decimal)(AV18SubLCod), 6, 0));
            }
            else
            {
               AV18SubLCod = (int)(context.localUtil.CToN( cgiGet( edtavSublcod_Internalname), ".", ","));
               AssignAttri("", false, "AV18SubLCod", StringUtil.LTrimStr( (decimal)(AV18SubLCod), 6, 0));
            }
            if ( ( ( context.localUtil.CToN( cgiGet( edtavFamcod_Internalname), ".", ",") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtavFamcod_Internalname), ".", ",") > Convert.ToDecimal( 999999 )) ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "vFAMCOD");
               GX_FocusControl = edtavFamcod_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               AV10FamCod = 0;
               AssignAttri("", false, "AV10FamCod", StringUtil.LTrimStr( (decimal)(AV10FamCod), 6, 0));
            }
            else
            {
               AV10FamCod = (int)(context.localUtil.CToN( cgiGet( edtavFamcod_Internalname), ".", ","));
               AssignAttri("", false, "AV10FamCod", StringUtil.LTrimStr( (decimal)(AV10FamCod), 6, 0));
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
         E112W2 ();
         if (returnInSub) return;
      }

      protected void E112W2( )
      {
         /* Start Routine */
         returnInSub = false;
         edtavFamcod_Visible = 0;
         AssignProp("", false, edtavFamcod_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavFamcod_Visible), 5, 0), true);
         edtavSublcod_Visible = 0;
         AssignProp("", false, edtavSublcod_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavSublcod_Visible), 5, 0), true);
         edtavLincod_Visible = 0;
         AssignProp("", false, edtavLincod_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavLincod_Visible), 5, 0), true);
         edtavAlmcod_Visible = 0;
         AssignProp("", false, edtavAlmcod_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavAlmcod_Visible), 5, 0), true);
         /* Execute user subroutine: 'LOADCOMBOALMCOD' */
         S112 ();
         if (returnInSub) return;
         /* Execute user subroutine: 'LOADCOMBOLINCOD' */
         S122 ();
         if (returnInSub) return;
         /* Execute user subroutine: 'LOADCOMBOSUBLCOD' */
         S132 ();
         if (returnInSub) return;
         /* Execute user subroutine: 'LOADCOMBOFAMCOD' */
         S142 ();
         if (returnInSub) return;
         AV20TipoOrden = 2;
         AssignAttri("", false, "AV20TipoOrden", StringUtil.Str( (decimal)(AV20TipoOrden), 1, 0));
         AV23SubTotal = "N";
         AssignAttri("", false, "AV23SubTotal", AV23SubTotal);
         AV12Fecha = DateTimeUtil.Today( context);
         AssignAttri("", false, "AV12Fecha", context.localUtil.Format(AV12Fecha, "99/99/99"));
      }

      protected void E122W2( )
      {
         /* 'DoBtnImprimir' Routine */
         returnInSub = false;
         context.DoAjaxRefresh();
         GXKey = Crypto.GetSiteKey( );
         GXEncryptionTmp = "almacen.r_stockactualconsolidadopdf.aspx"+UrlEncode(StringUtil.LTrimStr(AV13LinCod,6,0)) + "," + UrlEncode(StringUtil.LTrimStr(AV18SubLCod,6,0)) + "," + UrlEncode(StringUtil.LTrimStr(AV10FamCod,6,0)) + "," + UrlEncode(StringUtil.LTrimStr(AV5AlmCod,6,0)) + "," + UrlEncode(StringUtil.RTrim(AV15ProdCod)) + "," + UrlEncode(StringUtil.LTrimStr(AV20TipoOrden,1,0)) + "," + UrlEncode(DateTimeUtil.FormatDateParm(AV12Fecha)) + "," + UrlEncode(StringUtil.RTrim(AV23SubTotal));
         Innewwindow_Target = formatLink("almacen.r_stockactualconsolidadopdf.aspx") + "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey);
         ucInnewwindow.SendProperty(context, "", false, Innewwindow_Internalname, "Target", Innewwindow_Target);
         this.executeUsercontrolMethod("", false, "INNEWWINDOWContainer", "OpenWindow", "", new Object[] {});
         /*  Sending Event outputs  */
      }

      protected void E132W2( )
      {
         /* 'DoBtnExcel' Routine */
         returnInSub = false;
         context.DoAjaxRefresh();
         new GeneXus.Programs.almacen.r_stockactualconsolidadoexcel(context ).execute( ref  AV13LinCod, ref  AV18SubLCod, ref  AV10FamCod, ref  AV5AlmCod, ref  AV15ProdCod, ref  AV20TipoOrden, ref  AV12Fecha, out  AV9ExcelFilename, out  AV8ErrorMessage) ;
         AssignAttri("", false, "AV13LinCod", StringUtil.LTrimStr( (decimal)(AV13LinCod), 6, 0));
         AssignAttri("", false, "AV18SubLCod", StringUtil.LTrimStr( (decimal)(AV18SubLCod), 6, 0));
         AssignAttri("", false, "AV10FamCod", StringUtil.LTrimStr( (decimal)(AV10FamCod), 6, 0));
         AssignAttri("", false, "AV5AlmCod", StringUtil.LTrimStr( (decimal)(AV5AlmCod), 6, 0));
         AssignAttri("", false, "AV15ProdCod", AV15ProdCod);
         AssignAttri("", false, "AV20TipoOrden", StringUtil.Str( (decimal)(AV20TipoOrden), 1, 0));
         AssignAttri("", false, "AV12Fecha", context.localUtil.Format(AV12Fecha, "99/99/99"));
         if ( StringUtil.StrCmp(AV9ExcelFilename, "") != 0 )
         {
            CallWebObject(formatLink(AV9ExcelFilename) );
            context.wjLocDisableFrm = 0;
         }
         else
         {
            GX_msglist.addItem(AV8ErrorMessage);
         }
         /*  Sending Event outputs  */
         radavTipoorden.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV20TipoOrden), 1, 0));
         AssignProp("", false, radavTipoorden_Internalname, "Values", radavTipoorden.ToJavascriptSource(), true);
      }

      protected void E142W2( )
      {
         /* 'DoBtnSalir' Routine */
         returnInSub = false;
         CallWebObject(formatLink("wwpbaseobjects.home.aspx") );
         context.wjLocDisableFrm = 1;
      }

      protected void E152W2( )
      {
         /* 'DoBtnBuscar' Routine */
         returnInSub = false;
         context.DoAjaxRefresh();
         context.PopUp(formatLink("generales.wwbusquedaproducto.aspx", new object[] {UrlEncode(StringUtil.RTrim("")),UrlEncode(StringUtil.RTrim("")),UrlEncode(StringUtil.RTrim(""))}, new string[] {"OutProdCod","OutProdDsc","InTipo"}) , new Object[] {"AV15ProdCod","AV16ProdDsc",});
         /*  Sending Event outputs  */
      }

      protected void S142( )
      {
         /* 'LOADCOMBOFAMCOD' Routine */
         returnInSub = false;
         /* Using cursor H002W2 */
         pr_default.execute(0);
         while ( (pr_default.getStatus(0) != 101) )
         {
            A979FamSts = H002W2_A979FamSts[0];
            A50FamCod = H002W2_A50FamCod[0];
            A977FamDsc = H002W2_A977FamDsc[0];
            AV7Combo_DataItem = new GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTComboData_Item(context);
            AV7Combo_DataItem.gxTpr_Id = StringUtil.Trim( StringUtil.Str( (decimal)(A50FamCod), 6, 0));
            AV7Combo_DataItem.gxTpr_Title = A977FamDsc;
            AV11FamCod_Data.Add(AV7Combo_DataItem, 0);
            pr_default.readNext(0);
         }
         pr_default.close(0);
         Combo_famcod_Selectedvalue_set = ((0==AV10FamCod) ? "" : StringUtil.Trim( StringUtil.Str( (decimal)(AV10FamCod), 6, 0)));
         ucCombo_famcod.SendProperty(context, "", false, Combo_famcod_Internalname, "SelectedValue_set", Combo_famcod_Selectedvalue_set);
      }

      protected void S132( )
      {
         /* 'LOADCOMBOSUBLCOD' Routine */
         returnInSub = false;
         /* Using cursor H002W3 */
         pr_default.execute(1);
         while ( (pr_default.getStatus(1) != 101) )
         {
            A1893SublSts = H002W3_A1893SublSts[0];
            A51SublCod = H002W3_A51SublCod[0];
            A1892SublDsc = H002W3_A1892SublDsc[0];
            AV7Combo_DataItem = new GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTComboData_Item(context);
            AV7Combo_DataItem.gxTpr_Id = StringUtil.Trim( StringUtil.Str( (decimal)(A51SublCod), 6, 0));
            AV7Combo_DataItem.gxTpr_Title = A1892SublDsc;
            AV19SubLCod_Data.Add(AV7Combo_DataItem, 0);
            pr_default.readNext(1);
         }
         pr_default.close(1);
         Combo_sublcod_Selectedvalue_set = ((0==AV18SubLCod) ? "" : StringUtil.Trim( StringUtil.Str( (decimal)(AV18SubLCod), 6, 0)));
         ucCombo_sublcod.SendProperty(context, "", false, Combo_sublcod_Internalname, "SelectedValue_set", Combo_sublcod_Selectedvalue_set);
      }

      protected void S122( )
      {
         /* 'LOADCOMBOLINCOD' Routine */
         returnInSub = false;
         /* Using cursor H002W4 */
         pr_default.execute(2);
         while ( (pr_default.getStatus(2) != 101) )
         {
            A1159LinSts = H002W4_A1159LinSts[0];
            A52LinCod = H002W4_A52LinCod[0];
            A1153LinDsc = H002W4_A1153LinDsc[0];
            AV7Combo_DataItem = new GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTComboData_Item(context);
            AV7Combo_DataItem.gxTpr_Id = StringUtil.Trim( StringUtil.Str( (decimal)(A52LinCod), 6, 0));
            AV7Combo_DataItem.gxTpr_Title = A1153LinDsc;
            AV14LinCod_Data.Add(AV7Combo_DataItem, 0);
            pr_default.readNext(2);
         }
         pr_default.close(2);
         Combo_lincod_Selectedvalue_set = ((0==AV13LinCod) ? "" : StringUtil.Trim( StringUtil.Str( (decimal)(AV13LinCod), 6, 0)));
         ucCombo_lincod.SendProperty(context, "", false, Combo_lincod_Internalname, "SelectedValue_set", Combo_lincod_Selectedvalue_set);
      }

      protected void S112( )
      {
         /* 'LOADCOMBOALMCOD' Routine */
         returnInSub = false;
         /* Using cursor H002W5 */
         pr_default.execute(3);
         while ( (pr_default.getStatus(3) != 101) )
         {
            A438AlmSts = H002W5_A438AlmSts[0];
            A63AlmCod = H002W5_A63AlmCod[0];
            A436AlmDsc = H002W5_A436AlmDsc[0];
            AV7Combo_DataItem = new GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTComboData_Item(context);
            AV7Combo_DataItem.gxTpr_Id = StringUtil.Trim( StringUtil.Str( (decimal)(A63AlmCod), 6, 0));
            AV7Combo_DataItem.gxTpr_Title = A436AlmDsc;
            AV6AlmCod_Data.Add(AV7Combo_DataItem, 0);
            pr_default.readNext(3);
         }
         pr_default.close(3);
         Combo_almcod_Selectedvalue_set = ((0==AV5AlmCod) ? "" : StringUtil.Trim( StringUtil.Str( (decimal)(AV5AlmCod), 6, 0)));
         ucCombo_almcod.SendProperty(context, "", false, Combo_almcod_Internalname, "SelectedValue_set", Combo_almcod_Selectedvalue_set);
      }

      protected void nextLoad( )
      {
      }

      protected void E162W2( )
      {
         /* Load Routine */
         returnInSub = false;
      }

      protected void wb_table1_57_2W2( bool wbgen )
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
            GxWebStd.gx_label_element( context, edtavProdcod_Internalname, "Codigo Producto", "gx-form-item AttributeLabel", 0, true, "width: 25%;");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 61,'',false,'',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavProdcod_Internalname, StringUtil.RTrim( AV15ProdCod), StringUtil.RTrim( context.localUtil.Format( AV15ProdCod, "@!")), TempTags+" onchange=\""+"this.value=this.value.toUpperCase();"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"this.value=this.value.toUpperCase();"+";gx.evt.onblur(this,61);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavProdcod_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtavProdcod_Enabled, 0, "text", "", 15, "chr", 1, "row", 15, 0, 0, 0, 1, -1, -1, true, "", "left", true, "", "HLP_Almacen\\R_StockActualConsolidado.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "<td class='CellPaddingLeft10'>") ;
            /* Active images/pictures */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 63,'',false,'',0)\"";
            ClassString = "Image";
            StyleString = "";
            sImgUrl = (string)(context.GetImagePath( "f5b04895-0024-488b-8e3b-b687ca4598ee", "", context.GetTheme( )));
            GxWebStd.gx_bitmap( context, imgBtnbuscar_Internalname, sImgUrl, "", "", "", context.GetTheme( ), 1, 1, "", "Buscar Producto", 0, 0, 0, "px", 0, "px", 0, 0, 7, imgBtnbuscar_Jsonclick, "'"+""+"'"+",false,"+"'"+"e172w1_client"+"'", StyleString, ClassString, "", "", "", "", " "+"data-gx-image"+" "+TempTags, "", "", 1, false, false, context.GetImageSrcSet( sImgUrl), "HLP_Almacen\\R_StockActualConsolidado.htm");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "<td class='DataContentCell'>") ;
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "left", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavProddsc_Internalname, "Descripcion producto", "gx-form-item ReadonlyAttributeLabel", 0, true, "width: 25%;");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 66,'',false,'',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavProddsc_Internalname, StringUtil.RTrim( AV16ProdDsc), StringUtil.RTrim( context.localUtil.Format( AV16ProdDsc, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,66);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavProddsc_Jsonclick, 0, "ReadonlyAttribute", "", "", "", "", 1, edtavProddsc_Enabled, 0, "text", "", 80, "chr", 1, "row", 100, 0, 0, 0, 1, -1, -1, true, "", "left", true, "", "HLP_Almacen\\R_StockActualConsolidado.htm");
            /* Static images/pictures */
            ClassString = "gx-prompt Image";
            StyleString = "";
            sImgUrl = (string)(context.GetImagePath( "f5b04895-0024-488b-8e3b-b687ca4598ee", "", context.GetTheme( )));
            GxWebStd.gx_bitmap( context, imgprompt_Prodcod_Proddsc_Internalname, sImgUrl, imgprompt_Prodcod_Proddsc_Link, "", "", context.GetTheme( ), 1, 1, "", "", 0, 0, 0, "", 0, "", 0, 0, 0, "", "", StyleString, ClassString, "", "", "", "", "", "", "", 1, false, false, context.GetImageSrcSet( sImgUrl), "HLP_Almacen\\R_StockActualConsolidado.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "</tr>") ;
            /* End of table */
            context.WriteHtmlText( "</table>") ;
            wb_table1_57_2W2e( true) ;
         }
         else
         {
            wb_table1_57_2W2e( false) ;
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
         PA2W2( ) ;
         WS2W2( ) ;
         WE2W2( ) ;
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
            context.AddJavascriptSource(StringUtil.RTrim( ((string)Form.Jscriptsrc.Item(idxLst))), "?202281810305434", true, true);
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
         context.AddJavascriptSource("almacen/r_stockactualconsolidado.js", "?202281810305434", false, true);
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
         radavTipoorden.Name = "vTIPOORDEN";
         radavTipoorden.WebTags = "";
         radavTipoorden.addItem("1", "Codigo", 0);
         radavTipoorden.addItem("2", "Nombre Producto", 0);
         radavSubtotal.Name = "vSUBTOTAL";
         radavSubtotal.WebTags = "";
         radavSubtotal.addItem("L", "Por Linea", 0);
         radavSubtotal.addItem("S", "Por Sub Linea", 0);
         radavSubtotal.addItem("N", "Ninguno", 0);
         /* End function init_web_controls */
      }

      protected void init_default_properties( )
      {
         lblTextblockcombo_almcod_Internalname = "TEXTBLOCKCOMBO_ALMCOD";
         Combo_almcod_Internalname = "COMBO_ALMCOD";
         divTablesplittedalmcod_Internalname = "TABLESPLITTEDALMCOD";
         lblTextblockcombo_lincod_Internalname = "TEXTBLOCKCOMBO_LINCOD";
         Combo_lincod_Internalname = "COMBO_LINCOD";
         divTablesplittedlincod_Internalname = "TABLESPLITTEDLINCOD";
         lblTextblockcombo_sublcod_Internalname = "TEXTBLOCKCOMBO_SUBLCOD";
         Combo_sublcod_Internalname = "COMBO_SUBLCOD";
         divTablesplittedsublcod_Internalname = "TABLESPLITTEDSUBLCOD";
         lblTextblockcombo_famcod_Internalname = "TEXTBLOCKCOMBO_FAMCOD";
         Combo_famcod_Internalname = "COMBO_FAMCOD";
         divTablesplittedfamcod_Internalname = "TABLESPLITTEDFAMCOD";
         lblTextblockprodcod_Internalname = "TEXTBLOCKPRODCOD";
         edtavProdcod_Internalname = "vPRODCOD";
         imgBtnbuscar_Internalname = "BTNBUSCAR";
         edtavProddsc_Internalname = "vPRODDSC";
         tblTablemergedprodcod_Internalname = "TABLEMERGEDPRODCOD";
         divTablesplittedprodcod_Internalname = "TABLESPLITTEDPRODCOD";
         lblTextblockfecha_Internalname = "TEXTBLOCKFECHA";
         edtavFecha_Internalname = "vFECHA";
         divUnnamedtablefecha_Internalname = "UNNAMEDTABLEFECHA";
         lblTextblocktipoorden_Internalname = "TEXTBLOCKTIPOORDEN";
         radavTipoorden_Internalname = "vTIPOORDEN";
         divUnnamedtabletipoorden_Internalname = "UNNAMEDTABLETIPOORDEN";
         lblTextblocksubtotal_Internalname = "TEXTBLOCKSUBTOTAL";
         radavSubtotal_Internalname = "vSUBTOTAL";
         divUnnamedtablesubtotal_Internalname = "UNNAMEDTABLESUBTOTAL";
         divPanel1_Internalname = "PANEL1";
         Dvpanel_panel1_Internalname = "DVPANEL_PANEL1";
         bttBtnbtnimprimir_Internalname = "BTNBTNIMPRIMIR";
         bttBtnbtnexcel_Internalname = "BTNBTNEXCEL";
         bttBtnbtnsalir_Internalname = "BTNBTNSALIR";
         Innewwindow_Internalname = "INNEWWINDOW";
         divTablecontent_Internalname = "TABLECONTENT";
         divTablemain_Internalname = "TABLEMAIN";
         edtavAlmcod_Internalname = "vALMCOD";
         edtavLincod_Internalname = "vLINCOD";
         edtavSublcod_Internalname = "vSUBLCOD";
         edtavFamcod_Internalname = "vFAMCOD";
         divHtml_bottomauxiliarcontrols_Internalname = "HTML_BOTTOMAUXILIARCONTROLS";
         divLayoutmaintable_Internalname = "LAYOUTMAINTABLE";
         Form.Internalname = "FORM";
         imgprompt_Prodcod_Proddsc_Internalname = "PROMPT_PRODCOD_PRODDSC";
      }

      public override void initialize_properties( )
      {
         context.SetDefaultTheme("WorkWithPlusTheme");
         if ( context.isSpaRequest( ) )
         {
            disableJsOutput();
         }
         init_default_properties( ) ;
         imgprompt_Prodcod_Proddsc_Link = "";
         edtavProddsc_Jsonclick = "";
         edtavProddsc_Enabled = 1;
         edtavProdcod_Jsonclick = "";
         edtavProdcod_Enabled = 1;
         edtavFamcod_Jsonclick = "";
         edtavFamcod_Visible = 1;
         edtavSublcod_Jsonclick = "";
         edtavSublcod_Visible = 1;
         edtavLincod_Jsonclick = "";
         edtavLincod_Visible = 1;
         edtavAlmcod_Jsonclick = "";
         edtavAlmcod_Visible = 1;
         radavSubtotal_Jsonclick = "";
         radavTipoorden_Jsonclick = "";
         edtavFecha_Jsonclick = "";
         edtavFecha_Enabled = 1;
         Innewwindow_Target = "";
         Dvpanel_panel1_Autoscroll = Convert.ToBoolean( 0);
         Dvpanel_panel1_Iconposition = "Right";
         Dvpanel_panel1_Showcollapseicon = Convert.ToBoolean( 0);
         Dvpanel_panel1_Collapsed = Convert.ToBoolean( 0);
         Dvpanel_panel1_Collapsible = Convert.ToBoolean( -1);
         Dvpanel_panel1_Title = "Reporte de Stock Actual Consolidado";
         Dvpanel_panel1_Cls = "PanelFilled Panel_BaseColor";
         Dvpanel_panel1_Autoheight = Convert.ToBoolean( -1);
         Dvpanel_panel1_Autowidth = Convert.ToBoolean( 0);
         Dvpanel_panel1_Width = "100%";
         Combo_famcod_Cls = "ExtendedCombo AttributeRealWidth50With";
         Combo_sublcod_Cls = "ExtendedCombo AttributeRealWidth50With";
         Combo_lincod_Cls = "ExtendedCombo AttributeRealWidth50With";
         Combo_almcod_Cls = "ExtendedCombo AttributeRealWidth50With";
         Form.Headerrawhtml = "";
         Form.Background = "";
         Form.Textcolor = 0;
         Form.Backcolor = (int)(0xFFFFFF);
         Form.Caption = "Stock Actual Consolidado";
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
         setEventMetadata("REFRESH","{handler:'Refresh',iparms:[{av:'radavTipoorden'},{av:'AV20TipoOrden',fld:'vTIPOORDEN',pic:'9'},{av:'radavSubtotal'},{av:'AV23SubTotal',fld:'vSUBTOTAL',pic:''}]");
         setEventMetadata("REFRESH",",oparms:[{av:'radavTipoorden'},{av:'AV20TipoOrden',fld:'vTIPOORDEN',pic:'9'},{av:'radavSubtotal'},{av:'AV23SubTotal',fld:'vSUBTOTAL',pic:''}]}");
         setEventMetadata("'DOBTNIMPRIMIR'","{handler:'E122W2',iparms:[{av:'AV13LinCod',fld:'vLINCOD',pic:'ZZZZZ9'},{av:'AV18SubLCod',fld:'vSUBLCOD',pic:'ZZZZZ9'},{av:'AV10FamCod',fld:'vFAMCOD',pic:'ZZZZZ9'},{av:'AV5AlmCod',fld:'vALMCOD',pic:'ZZZZZ9'},{av:'AV15ProdCod',fld:'vPRODCOD',pic:'@!'},{av:'AV12Fecha',fld:'vFECHA',pic:''},{av:'radavTipoorden'},{av:'AV20TipoOrden',fld:'vTIPOORDEN',pic:'9'},{av:'radavSubtotal'},{av:'AV23SubTotal',fld:'vSUBTOTAL',pic:''}]");
         setEventMetadata("'DOBTNIMPRIMIR'",",oparms:[{av:'Innewwindow_Target',ctrl:'INNEWWINDOW',prop:'Target'},{av:'radavTipoorden'},{av:'AV20TipoOrden',fld:'vTIPOORDEN',pic:'9'},{av:'radavSubtotal'},{av:'AV23SubTotal',fld:'vSUBTOTAL',pic:''}]}");
         setEventMetadata("'DOBTNEXCEL'","{handler:'E132W2',iparms:[{av:'AV13LinCod',fld:'vLINCOD',pic:'ZZZZZ9'},{av:'AV18SubLCod',fld:'vSUBLCOD',pic:'ZZZZZ9'},{av:'AV10FamCod',fld:'vFAMCOD',pic:'ZZZZZ9'},{av:'AV5AlmCod',fld:'vALMCOD',pic:'ZZZZZ9'},{av:'AV15ProdCod',fld:'vPRODCOD',pic:'@!'},{av:'AV12Fecha',fld:'vFECHA',pic:''},{av:'radavTipoorden'},{av:'AV20TipoOrden',fld:'vTIPOORDEN',pic:'9'},{av:'radavSubtotal'},{av:'AV23SubTotal',fld:'vSUBTOTAL',pic:''}]");
         setEventMetadata("'DOBTNEXCEL'",",oparms:[{av:'AV12Fecha',fld:'vFECHA',pic:''},{av:'AV15ProdCod',fld:'vPRODCOD',pic:'@!'},{av:'AV5AlmCod',fld:'vALMCOD',pic:'ZZZZZ9'},{av:'AV10FamCod',fld:'vFAMCOD',pic:'ZZZZZ9'},{av:'AV18SubLCod',fld:'vSUBLCOD',pic:'ZZZZZ9'},{av:'AV13LinCod',fld:'vLINCOD',pic:'ZZZZZ9'},{av:'radavTipoorden'},{av:'AV20TipoOrden',fld:'vTIPOORDEN',pic:'9'},{av:'radavSubtotal'},{av:'AV23SubTotal',fld:'vSUBTOTAL',pic:''}]}");
         setEventMetadata("'DOBTNSALIR'","{handler:'E142W2',iparms:[{av:'radavTipoorden'},{av:'AV20TipoOrden',fld:'vTIPOORDEN',pic:'9'},{av:'radavSubtotal'},{av:'AV23SubTotal',fld:'vSUBTOTAL',pic:''}]");
         setEventMetadata("'DOBTNSALIR'",",oparms:[{av:'radavTipoorden'},{av:'AV20TipoOrden',fld:'vTIPOORDEN',pic:'9'},{av:'radavSubtotal'},{av:'AV23SubTotal',fld:'vSUBTOTAL',pic:''}]}");
         setEventMetadata("'DOBTNBUSCAR'","{handler:'E152W2',iparms:[{av:'radavTipoorden'},{av:'AV20TipoOrden',fld:'vTIPOORDEN',pic:'9'},{av:'radavSubtotal'},{av:'AV23SubTotal',fld:'vSUBTOTAL',pic:''}]");
         setEventMetadata("'DOBTNBUSCAR'",",oparms:[{av:'AV16ProdDsc',fld:'vPRODDSC',pic:''},{av:'AV15ProdCod',fld:'vPRODCOD',pic:'@!'},{av:'radavTipoorden'},{av:'AV20TipoOrden',fld:'vTIPOORDEN',pic:'9'},{av:'radavSubtotal'},{av:'AV23SubTotal',fld:'vSUBTOTAL',pic:''}]}");
         setEventMetadata("BTNBUSCAR.CLICK","{handler:'E172W1',iparms:[{av:'radavTipoorden'},{av:'AV20TipoOrden',fld:'vTIPOORDEN',pic:'9'},{av:'radavSubtotal'},{av:'AV23SubTotal',fld:'vSUBTOTAL',pic:''}]");
         setEventMetadata("BTNBUSCAR.CLICK",",oparms:[{av:'AV16ProdDsc',fld:'vPRODDSC',pic:''},{av:'AV15ProdCod',fld:'vPRODCOD',pic:'@!'},{av:'radavTipoorden'},{av:'AV20TipoOrden',fld:'vTIPOORDEN',pic:'9'},{av:'radavSubtotal'},{av:'AV23SubTotal',fld:'vSUBTOTAL',pic:''}]}");
         setEventMetadata("VALIDV_FECHA","{handler:'Validv_Fecha',iparms:[{av:'radavTipoorden'},{av:'AV20TipoOrden',fld:'vTIPOORDEN',pic:'9'},{av:'radavSubtotal'},{av:'AV23SubTotal',fld:'vSUBTOTAL',pic:''}]");
         setEventMetadata("VALIDV_FECHA",",oparms:[{av:'radavTipoorden'},{av:'AV20TipoOrden',fld:'vTIPOORDEN',pic:'9'},{av:'radavSubtotal'},{av:'AV23SubTotal',fld:'vSUBTOTAL',pic:''}]}");
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
         Combo_famcod_Selectedvalue_get = "";
         Combo_sublcod_Selectedvalue_get = "";
         Combo_lincod_Selectedvalue_get = "";
         Combo_almcod_Selectedvalue_get = "";
         gxfirstwebparm = "";
         gxfirstwebparm_bkp = "";
         sDynURL = "";
         FormProcess = "";
         bodyStyle = "";
         GXKey = "";
         AV6AlmCod_Data = new GXBaseCollection<GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTComboData_Item>( context, "Item", "");
         AV14LinCod_Data = new GXBaseCollection<GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTComboData_Item>( context, "Item", "");
         AV19SubLCod_Data = new GXBaseCollection<GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTComboData_Item>( context, "Item", "");
         AV11FamCod_Data = new GXBaseCollection<GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTComboData_Item>( context, "Item", "");
         Combo_almcod_Selectedvalue_set = "";
         Combo_lincod_Selectedvalue_set = "";
         Combo_sublcod_Selectedvalue_set = "";
         Combo_famcod_Selectedvalue_set = "";
         GX_FocusControl = "";
         Form = new GXWebForm();
         sPrefix = "";
         ClassString = "";
         StyleString = "";
         ucDvpanel_panel1 = new GXUserControl();
         lblTextblockcombo_almcod_Jsonclick = "";
         ucCombo_almcod = new GXUserControl();
         Combo_almcod_Caption = "";
         lblTextblockcombo_lincod_Jsonclick = "";
         ucCombo_lincod = new GXUserControl();
         Combo_lincod_Caption = "";
         lblTextblockcombo_sublcod_Jsonclick = "";
         ucCombo_sublcod = new GXUserControl();
         Combo_sublcod_Caption = "";
         lblTextblockcombo_famcod_Jsonclick = "";
         ucCombo_famcod = new GXUserControl();
         Combo_famcod_Caption = "";
         lblTextblockprodcod_Jsonclick = "";
         lblTextblockfecha_Jsonclick = "";
         TempTags = "";
         AV12Fecha = DateTime.MinValue;
         lblTextblocktipoorden_Jsonclick = "";
         lblTextblocksubtotal_Jsonclick = "";
         AV23SubTotal = "";
         bttBtnbtnimprimir_Jsonclick = "";
         bttBtnbtnexcel_Jsonclick = "";
         bttBtnbtnsalir_Jsonclick = "";
         ucInnewwindow = new GXUserControl();
         sEvt = "";
         EvtGridId = "";
         EvtRowId = "";
         sEvtType = "";
         AV15ProdCod = "";
         AV16ProdDsc = "";
         GXEncryptionTmp = "";
         AV9ExcelFilename = "";
         AV8ErrorMessage = "";
         scmdbuf = "";
         H002W2_A979FamSts = new short[1] ;
         H002W2_A50FamCod = new int[1] ;
         H002W2_A977FamDsc = new string[] {""} ;
         A977FamDsc = "";
         AV7Combo_DataItem = new GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTComboData_Item(context);
         H002W3_A1893SublSts = new short[1] ;
         H002W3_A51SublCod = new int[1] ;
         H002W3_A1892SublDsc = new string[] {""} ;
         A1892SublDsc = "";
         H002W4_A1159LinSts = new short[1] ;
         H002W4_A52LinCod = new int[1] ;
         H002W4_A1153LinDsc = new string[] {""} ;
         A1153LinDsc = "";
         H002W5_A438AlmSts = new short[1] ;
         H002W5_A63AlmCod = new int[1] ;
         H002W5_A436AlmDsc = new string[] {""} ;
         A436AlmDsc = "";
         sStyleString = "";
         sImgUrl = "";
         imgBtnbuscar_Jsonclick = "";
         BackMsgLst = new msglist();
         LclMsgLst = new msglist();
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.almacen.r_stockactualconsolidado__default(),
            new Object[][] {
                new Object[] {
               H002W2_A979FamSts, H002W2_A50FamCod, H002W2_A977FamDsc
               }
               , new Object[] {
               H002W3_A1893SublSts, H002W3_A51SublCod, H002W3_A1892SublDsc
               }
               , new Object[] {
               H002W4_A1159LinSts, H002W4_A52LinCod, H002W4_A1153LinDsc
               }
               , new Object[] {
               H002W5_A438AlmSts, H002W5_A63AlmCod, H002W5_A436AlmDsc
               }
            }
         );
         AV23SubTotal = "N";
         /* GeneXus formulas. */
         context.Gx_err = 0;
         edtavProddsc_Enabled = 0;
         imgprompt_Prodcod_Proddsc_Link = "javascript:"+"gx.popup.openPrompt('"+"generales.wwbusquedaproducto.aspx"+"',["+"{Ctrl:gx.dom.el('"+"vPRODCOD"+"'), id:'"+"vPRODCOD"+"'"+",IOType:'out'}"+","+"{Ctrl:gx.dom.el('"+"vPRODDSC"+"'), id:'"+"vPRODDSC"+"'"+",IOType:'out'}"+","+""+"],"+"null"+","+"'', false"+","+"false"+");";
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
      private short AV20TipoOrden ;
      private short nDonePA ;
      private short A979FamSts ;
      private short A1893SublSts ;
      private short A1159LinSts ;
      private short A438AlmSts ;
      private short nGXWrapped ;
      private int edtavFecha_Enabled ;
      private int AV5AlmCod ;
      private int edtavAlmcod_Visible ;
      private int AV13LinCod ;
      private int edtavLincod_Visible ;
      private int AV18SubLCod ;
      private int edtavSublcod_Visible ;
      private int AV10FamCod ;
      private int edtavFamcod_Visible ;
      private int edtavProddsc_Enabled ;
      private int A50FamCod ;
      private int A51SublCod ;
      private int A52LinCod ;
      private int A63AlmCod ;
      private int edtavProdcod_Enabled ;
      private int idxLst ;
      private string Combo_famcod_Selectedvalue_get ;
      private string Combo_sublcod_Selectedvalue_get ;
      private string Combo_lincod_Selectedvalue_get ;
      private string Combo_almcod_Selectedvalue_get ;
      private string gxfirstwebparm ;
      private string gxfirstwebparm_bkp ;
      private string sDynURL ;
      private string FormProcess ;
      private string bodyStyle ;
      private string GXKey ;
      private string Combo_almcod_Cls ;
      private string Combo_almcod_Selectedvalue_set ;
      private string Combo_lincod_Cls ;
      private string Combo_lincod_Selectedvalue_set ;
      private string Combo_sublcod_Cls ;
      private string Combo_sublcod_Selectedvalue_set ;
      private string Combo_famcod_Cls ;
      private string Combo_famcod_Selectedvalue_set ;
      private string Dvpanel_panel1_Width ;
      private string Dvpanel_panel1_Cls ;
      private string Dvpanel_panel1_Title ;
      private string Dvpanel_panel1_Iconposition ;
      private string Innewwindow_Target ;
      private string GX_FocusControl ;
      private string sPrefix ;
      private string divLayoutmaintable_Internalname ;
      private string divTablemain_Internalname ;
      private string ClassString ;
      private string StyleString ;
      private string divTablecontent_Internalname ;
      private string Dvpanel_panel1_Internalname ;
      private string divPanel1_Internalname ;
      private string divTablesplittedalmcod_Internalname ;
      private string lblTextblockcombo_almcod_Internalname ;
      private string lblTextblockcombo_almcod_Jsonclick ;
      private string Combo_almcod_Caption ;
      private string Combo_almcod_Internalname ;
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
      private string divTablesplittedfamcod_Internalname ;
      private string lblTextblockcombo_famcod_Internalname ;
      private string lblTextblockcombo_famcod_Jsonclick ;
      private string Combo_famcod_Caption ;
      private string Combo_famcod_Internalname ;
      private string divTablesplittedprodcod_Internalname ;
      private string lblTextblockprodcod_Internalname ;
      private string lblTextblockprodcod_Jsonclick ;
      private string divUnnamedtablefecha_Internalname ;
      private string lblTextblockfecha_Internalname ;
      private string lblTextblockfecha_Jsonclick ;
      private string edtavFecha_Internalname ;
      private string TempTags ;
      private string edtavFecha_Jsonclick ;
      private string divUnnamedtabletipoorden_Internalname ;
      private string lblTextblocktipoorden_Internalname ;
      private string lblTextblocktipoorden_Jsonclick ;
      private string radavTipoorden_Internalname ;
      private string radavTipoorden_Jsonclick ;
      private string divUnnamedtablesubtotal_Internalname ;
      private string lblTextblocksubtotal_Internalname ;
      private string lblTextblocksubtotal_Jsonclick ;
      private string radavSubtotal_Internalname ;
      private string radavSubtotal_Jsonclick ;
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
      private string edtavLincod_Internalname ;
      private string edtavLincod_Jsonclick ;
      private string edtavSublcod_Internalname ;
      private string edtavSublcod_Jsonclick ;
      private string edtavFamcod_Internalname ;
      private string edtavFamcod_Jsonclick ;
      private string sEvt ;
      private string EvtGridId ;
      private string EvtRowId ;
      private string sEvtType ;
      private string edtavProdcod_Internalname ;
      private string edtavProddsc_Internalname ;
      private string imgprompt_Prodcod_Proddsc_Link ;
      private string AV15ProdCod ;
      private string AV16ProdDsc ;
      private string GXEncryptionTmp ;
      private string scmdbuf ;
      private string A977FamDsc ;
      private string A1892SublDsc ;
      private string A1153LinDsc ;
      private string A436AlmDsc ;
      private string sStyleString ;
      private string tblTablemergedprodcod_Internalname ;
      private string edtavProdcod_Jsonclick ;
      private string sImgUrl ;
      private string imgBtnbuscar_Internalname ;
      private string imgBtnbuscar_Jsonclick ;
      private string edtavProddsc_Jsonclick ;
      private string imgprompt_Prodcod_Proddsc_Internalname ;
      private DateTime AV12Fecha ;
      private bool entryPointCalled ;
      private bool toggleJsOutput ;
      private bool Dvpanel_panel1_Autowidth ;
      private bool Dvpanel_panel1_Autoheight ;
      private bool Dvpanel_panel1_Collapsible ;
      private bool Dvpanel_panel1_Collapsed ;
      private bool Dvpanel_panel1_Showcollapseicon ;
      private bool Dvpanel_panel1_Autoscroll ;
      private bool wbLoad ;
      private bool Rfr0gs ;
      private bool wbErr ;
      private bool gxdyncontrolsrefreshing ;
      private bool returnInSub ;
      private string AV23SubTotal ;
      private string AV9ExcelFilename ;
      private string AV8ErrorMessage ;
      private GXUserControl ucDvpanel_panel1 ;
      private GXUserControl ucCombo_almcod ;
      private GXUserControl ucCombo_lincod ;
      private GXUserControl ucCombo_sublcod ;
      private GXUserControl ucCombo_famcod ;
      private GXUserControl ucInnewwindow ;
      private IGxDataStore dsDataStore2 ;
      private IGxDataStore dsDefault ;
      private GXRadio radavTipoorden ;
      private GXRadio radavSubtotal ;
      private IDataStoreProvider pr_default ;
      private short[] H002W2_A979FamSts ;
      private int[] H002W2_A50FamCod ;
      private string[] H002W2_A977FamDsc ;
      private short[] H002W3_A1893SublSts ;
      private int[] H002W3_A51SublCod ;
      private string[] H002W3_A1892SublDsc ;
      private short[] H002W4_A1159LinSts ;
      private int[] H002W4_A52LinCod ;
      private string[] H002W4_A1153LinDsc ;
      private short[] H002W5_A438AlmSts ;
      private int[] H002W5_A63AlmCod ;
      private string[] H002W5_A436AlmDsc ;
      private msglist BackMsgLst ;
      private msglist LclMsgLst ;
      private GXBaseCollection<GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTComboData_Item> AV6AlmCod_Data ;
      private GXBaseCollection<GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTComboData_Item> AV14LinCod_Data ;
      private GXBaseCollection<GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTComboData_Item> AV19SubLCod_Data ;
      private GXBaseCollection<GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTComboData_Item> AV11FamCod_Data ;
      private GXWebForm Form ;
      private GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTComboData_Item AV7Combo_DataItem ;
   }

   public class r_stockactualconsolidado__default : DataStoreHelperBase, IDataStoreHelper
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
          Object[] prmH002W2;
          prmH002W2 = new Object[] {
          };
          Object[] prmH002W3;
          prmH002W3 = new Object[] {
          };
          Object[] prmH002W4;
          prmH002W4 = new Object[] {
          };
          Object[] prmH002W5;
          prmH002W5 = new Object[] {
          };
          def= new CursorDef[] {
              new CursorDef("H002W2", "SELECT [FamSts], [FamCod], [FamDsc] FROM [CFAMILIA] WHERE [FamSts] = 1 ORDER BY [FamDsc] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH002W2,100, GxCacheFrequency.OFF ,false,false )
             ,new CursorDef("H002W3", "SELECT [SublSts], [SublCod], [SublDsc] FROM [CSUBLPROD] WHERE [SublSts] = 1 ORDER BY [SublDsc] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH002W3,100, GxCacheFrequency.OFF ,false,false )
             ,new CursorDef("H002W4", "SELECT [LinSts], [LinCod], [LinDsc] FROM [CLINEAPROD] WHERE [LinSts] = 1 ORDER BY [LinDsc] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH002W4,100, GxCacheFrequency.OFF ,false,false )
             ,new CursorDef("H002W5", "SELECT [AlmSts], [AlmCod], [AlmDsc] FROM [CALMACEN] WHERE [AlmSts] = 1 ORDER BY [AlmDsc] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH002W5,100, GxCacheFrequency.OFF ,false,false )
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
       }
    }

 }

}
