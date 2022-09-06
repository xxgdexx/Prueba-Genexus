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
   public class r_reporteconciliacionbancaria : GXDataArea
   {
      public r_reporteconciliacionbancaria( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDataStore2 = context.GetDataStore("DataStore2");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusTheme");
      }

      public r_reporteconciliacionbancaria( IGxContext context )
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
         cmbavConmes = new GXCombobox();
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
         PA3N2( ) ;
         gxajaxcallmode = (short)((isAjaxCallMode( ) ? 1 : 0));
         if ( ( gxajaxcallmode == 0 ) && ( GxWebError == 0 ) )
         {
            START3N2( ) ;
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
         context.AddJavascriptSource("gxcfg.js", "?20228181031288", false, true);
         if ( context.isSpaRequest( ) )
         {
            enableOutput();
         }
         context.AddJavascriptSource("DVelop/Bootstrap/Shared/DVelopBootstrap.js", "", false, true);
         context.AddJavascriptSource("DVelop/Shared/WorkWithPlusCommon.js", "", false, true);
         context.AddJavascriptSource("DVelop/Bootstrap/Panel/BootstrapPanelRender.js", "", false, true);
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
         context.WriteHtmlTextNl( "<form id=\"MAINFORM\" autocomplete=\"off\" name=\"MAINFORM\" method=\"post\" tabindex=-1  class=\"form-horizontal Form\" data-gx-class=\"form-horizontal Form\" novalidate action=\""+formatLink("bancos.r_reporteconciliacionbancaria.aspx") +"\">") ;
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
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "vDDO_TITLESETTINGSICONS", AV11DDO_TitleSettingsIcons);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt("vDDO_TITLESETTINGSICONS", AV11DDO_TitleSettingsIcons);
         }
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "vBANCOD_DATA", AV14BanCod_Data);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt("vBANCOD_DATA", AV14BanCod_Data);
         }
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "vCBCOD_DATA", AV10CBCod_Data);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt("vCBCOD_DATA", AV10CBCod_Data);
         }
         GxWebStd.gx_hidden_field( context, "COMBO_BANCOD_Cls", StringUtil.RTrim( Combo_bancod_Cls));
         GxWebStd.gx_hidden_field( context, "COMBO_BANCOD_Selectedvalue_set", StringUtil.RTrim( Combo_bancod_Selectedvalue_set));
         GxWebStd.gx_hidden_field( context, "COMBO_CBCOD_Cls", StringUtil.RTrim( Combo_cbcod_Cls));
         GxWebStd.gx_hidden_field( context, "COMBO_CBCOD_Selectedvalue_set", StringUtil.RTrim( Combo_cbcod_Selectedvalue_set));
         GxWebStd.gx_hidden_field( context, "COMBO_CBCOD_Selectedtext_set", StringUtil.RTrim( Combo_cbcod_Selectedtext_set));
         GxWebStd.gx_hidden_field( context, "COMBO_CBCOD_Datalistproc", StringUtil.RTrim( Combo_cbcod_Datalistproc));
         GxWebStd.gx_hidden_field( context, "COMBO_CBCOD_Datalistprocparametersprefix", StringUtil.RTrim( Combo_cbcod_Datalistprocparametersprefix));
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
         GxWebStd.gx_hidden_field( context, "COMBO_CBCOD_Selectedvalue_get", StringUtil.RTrim( Combo_cbcod_Selectedvalue_get));
         GxWebStd.gx_hidden_field( context, "COMBO_BANCOD_Selectedvalue_get", StringUtil.RTrim( Combo_bancod_Selectedvalue_get));
         GxWebStd.gx_hidden_field( context, "COMBO_CBCOD_Selectedvalue_get", StringUtil.RTrim( Combo_cbcod_Selectedvalue_get));
         GxWebStd.gx_hidden_field( context, "COMBO_BANCOD_Selectedvalue_get", StringUtil.RTrim( Combo_bancod_Selectedvalue_get));
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
            WE3N2( ) ;
            context.WriteHtmlText( "</div>") ;
         }
      }

      public override void DispatchEvents( )
      {
         EVT3N2( ) ;
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
         return formatLink("bancos.r_reporteconciliacionbancaria.aspx")  ;
      }

      public override string GetPgmname( )
      {
         return "Bancos.R_ReporteConciliacionBancaria" ;
      }

      public override string GetPgmdesc( )
      {
         return "Reporte Conciliación Bancaria" ;
      }

      protected void WB3N0( )
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
            GxWebStd.gx_div_start( context, divTablesplittedbancod_Internalname, 1, 0, "px", 0, "px", "Table", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-6 MergeLabelCell CellWidth_12_5", "left", "top", "", "", "div");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblTextblockcombo_bancod_Internalname, "Banco", "", "", lblTextblockcombo_bancod_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "Label", 0, "", 1, 1, 0, 0, "HLP_Bancos\\R_ReporteConciliacionBancaria.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-6 CellWidth_87_5", "left", "top", "", "", "div");
            /* User Defined Control */
            ucCombo_bancod.SetProperty("Caption", Combo_bancod_Caption);
            ucCombo_bancod.SetProperty("Cls", Combo_bancod_Cls);
            ucCombo_bancod.SetProperty("DropDownOptionsTitleSettingsIcons", AV11DDO_TitleSettingsIcons);
            ucCombo_bancod.SetProperty("DropDownOptionsData", AV14BanCod_Data);
            ucCombo_bancod.Render(context, "dvelop.gxbootstrap.ddoextendedcombo", Combo_bancod_Internalname, "COMBO_BANCODContainer");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 DataContentCell ExtendedComboCell", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divTablesplittedcbcod_Internalname, 1, 0, "px", 0, "px", "Table", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-6 MergeLabelCell CellWidth_12_5", "left", "top", "", "", "div");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblTextblockcombo_cbcod_Internalname, "Cuenta ", "", "", lblTextblockcombo_cbcod_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "Label", 0, "", 1, 1, 0, 0, "HLP_Bancos\\R_ReporteConciliacionBancaria.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-6 CellWidth_87_5", "left", "top", "", "", "div");
            /* User Defined Control */
            ucCombo_cbcod.SetProperty("Caption", Combo_cbcod_Caption);
            ucCombo_cbcod.SetProperty("Cls", Combo_cbcod_Cls);
            ucCombo_cbcod.SetProperty("DataListProc", Combo_cbcod_Datalistproc);
            ucCombo_cbcod.SetProperty("DropDownOptionsTitleSettingsIcons", AV11DDO_TitleSettingsIcons);
            ucCombo_cbcod.SetProperty("DropDownOptionsData", AV10CBCod_Data);
            ucCombo_cbcod.Render(context, "dvelop.gxbootstrap.ddoextendedcombo", Combo_cbcod_Internalname, "COMBO_CBCODContainer");
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
            GxWebStd.gx_div_start( context, divUnnamedtablemondsc_Internalname, 1, 0, "px", 0, "px", "Table", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-6 MergeLabelCell CellWidth_12_5", "left", "top", "", "", "div");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblTextblockmondsc_Internalname, "Moneda", "", "", lblTextblockmondsc_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "Label", 0, "", 1, 1, 0, 0, "HLP_Bancos\\R_ReporteConciliacionBancaria.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-6 CellWidth_87_5", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "left", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavMondsc_Internalname, "Moneda", "col-sm-3 ReadonlyAttributeLabel", 0, true, "");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 41,'',false,'',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavMondsc_Internalname, StringUtil.RTrim( AV7MonDsc), StringUtil.RTrim( context.localUtil.Format( AV7MonDsc, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,41);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavMondsc_Jsonclick, 0, "ReadonlyAttribute", "", "", "", "", 1, edtavMondsc_Enabled, 1, "text", "", 80, "chr", 1, "row", 100, 0, 0, 0, 1, -1, -1, true, "", "left", true, "", "HLP_Bancos\\R_ReporteConciliacionBancaria.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 DataContentCell", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divUnnamedtableconano_Internalname, 1, 0, "px", 0, "px", "Table", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-6 MergeLabelCell CellWidth_12_5", "left", "top", "", "", "div");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblTextblockconano_Internalname, "Año", "", "", lblTextblockconano_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "Label", 0, "", 1, 1, 0, 0, "HLP_Bancos\\R_ReporteConciliacionBancaria.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-6 CellWidth_87_5", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "left", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavConano_Internalname, "Con Ano", "col-sm-3 AttributeWidthAutoLabel", 0, true, "");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 49,'',false,'',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavConano_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(AV8ConAno), 4, 0, ".", "")), StringUtil.LTrim( ((edtavConano_Enabled!=0) ? context.localUtil.Format( (decimal)(AV8ConAno), "ZZZ9") : context.localUtil.Format( (decimal)(AV8ConAno), "ZZZ9"))), " inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onblur(this,49);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavConano_Jsonclick, 0, "AttributeWidthAuto", "", "", "", "", 1, edtavConano_Enabled, 0, "text", "1", 4, "chr", 1, "row", 4, 0, 0, 0, 1, -1, 0, true, "", "right", false, "", "HLP_Bancos\\R_ReporteConciliacionBancaria.htm");
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
            GxWebStd.gx_div_start( context, divUnnamedtableconmes_Internalname, 1, 0, "px", 0, "px", "Table", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-6 MergeLabelCell CellWidth_12_5", "left", "top", "", "", "div");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblTextblockconmes_Internalname, "Mes", "", "", lblTextblockconmes_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "Label", 0, "", 1, 1, 0, 0, "HLP_Bancos\\R_ReporteConciliacionBancaria.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-6 CellWidth_87_5", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "left", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, cmbavConmes_Internalname, "Con Mes", "col-sm-3 AttributeRealWidth50WithLabel", 0, true, "");
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 58,'',false,'',0)\"";
            /* ComboBox */
            GxWebStd.gx_combobox_ctrl1( context, cmbavConmes, cmbavConmes_Internalname, StringUtil.Trim( StringUtil.Str( (decimal)(AV9ConMes), 2, 0)), 1, cmbavConmes_Jsonclick, 0, "'"+""+"'"+",false,"+"'"+""+"'", "int", "", 1, cmbavConmes.Enabled, 0, 0, 0, "em", 0, "", "", "AttributeRealWidth50With", "", "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,58);\"", "", true, 1, "HLP_Bancos\\R_ReporteConciliacionBancaria.htm");
            cmbavConmes.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV9ConMes), 2, 0));
            AssignProp("", false, cmbavConmes_Internalname, "Values", (string)(cmbavConmes.ToJavascriptSource()), true);
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
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 63,'',false,'',0)\"";
            ClassString = "ButtonPDF";
            StyleString = "";
            GxWebStd.gx_button_ctrl( context, bttBtnbtnimprimir_Internalname, "", "Imprimir", bttBtnbtnimprimir_Jsonclick, 5, "Imprimir", "", StyleString, ClassString, 1, 1, "standard", "'"+""+"'"+",false,"+"'"+"E\\'DOBTNIMPRIMIR\\'."+"'", TempTags, "", context.GetButtonType( ), "HLP_Bancos\\R_ReporteConciliacionBancaria.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "left", "top", "", "", "div");
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 65,'',false,'',0)\"";
            ClassString = "ButtonColor";
            StyleString = "";
            GxWebStd.gx_button_ctrl( context, bttBtnbtnsalir_Internalname, "", "Salir", bttBtnbtnsalir_Jsonclick, 5, "Salir", "", StyleString, ClassString, 1, 1, "standard", "'"+""+"'"+",false,"+"'"+"E\\'DOBTNSALIR\\'."+"'", TempTags, "", context.GetButtonType( ), "HLP_Bancos\\R_ReporteConciliacionBancaria.htm");
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
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 72,'',false,'',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavBancod_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(AV5BanCod), 6, 0, ".", "")), StringUtil.LTrim( context.localUtil.Format( (decimal)(AV5BanCod), "ZZZZZ9")), " inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onblur(this,72);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavBancod_Jsonclick, 0, "Attribute", "", "", "", "", edtavBancod_Visible, 1, 0, "text", "1", 6, "chr", 1, "row", 6, 0, 0, 0, 1, -1, 0, true, "", "right", false, "", "HLP_Bancos\\R_ReporteConciliacionBancaria.htm");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 73,'',false,'',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavCbcod_Internalname, StringUtil.RTrim( AV6CBCod), StringUtil.RTrim( context.localUtil.Format( AV6CBCod, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,73);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavCbcod_Jsonclick, 0, "Attribute", "", "", "", "", edtavCbcod_Visible, 1, 0, "text", "", 20, "chr", 1, "row", 20, 0, 0, 0, 1, -1, -1, true, "", "left", true, "", "HLP_Bancos\\R_ReporteConciliacionBancaria.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
         }
         wbLoad = true;
      }

      protected void START3N2( )
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
            Form.Meta.addItem("description", "Reporte Conciliación Bancaria", 0) ;
         }
         context.wjLoc = "";
         context.nUserReturn = 0;
         context.wbHandled = 0;
         if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
         {
         }
         wbErr = false;
         STRUP3N0( ) ;
      }

      protected void WS3N2( )
      {
         START3N2( ) ;
         EVT3N2( ) ;
      }

      protected void EVT3N2( )
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
                           else if ( StringUtil.StrCmp(sEvt, "COMBO_BANCOD.ONOPTIONCLICKED") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              E113N2 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "COMBO_CBCOD.ONOPTIONCLICKED") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              E123N2 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "START") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              /* Execute user event: Start */
                              E133N2 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "'DOBTNIMPRIMIR'") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              /* Execute user event: 'DoBtnImprimir' */
                              E143N2 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "'DOBTNSALIR'") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              /* Execute user event: 'DoBtnSalir' */
                              E153N2 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "LOAD") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              /* Execute user event: Load */
                              E163N2 ();
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

      protected void WE3N2( )
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

      protected void PA3N2( )
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
               GX_FocusControl = edtavMondsc_Internalname;
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
         if ( cmbavConmes.ItemCount > 0 )
         {
            AV9ConMes = (short)(NumberUtil.Val( cmbavConmes.getValidValue(StringUtil.Trim( StringUtil.Str( (decimal)(AV9ConMes), 2, 0))), "."));
            AssignAttri("", false, "AV9ConMes", StringUtil.LTrimStr( (decimal)(AV9ConMes), 2, 0));
         }
         if ( context.isAjaxRequest( ) )
         {
            cmbavConmes.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV9ConMes), 2, 0));
            AssignProp("", false, cmbavConmes_Internalname, "Values", cmbavConmes.ToJavascriptSource(), true);
         }
      }

      public void Refresh( )
      {
         send_integrity_hashes( ) ;
         RF3N2( ) ;
         if ( isFullAjaxMode( ) )
         {
            send_integrity_footer_hashes( ) ;
         }
      }

      protected void initialize_formulas( )
      {
         /* GeneXus formulas. */
         context.Gx_err = 0;
         edtavMondsc_Enabled = 0;
         AssignProp("", false, edtavMondsc_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavMondsc_Enabled), 5, 0), true);
      }

      protected void RF3N2( )
      {
         initialize_formulas( ) ;
         clear_multi_value_controls( ) ;
         gxdyncontrolsrefreshing = true;
         fix_multi_value_controls( ) ;
         gxdyncontrolsrefreshing = false;
         if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
         {
            /* Execute user event: Load */
            E163N2 ();
            WB3N0( ) ;
         }
      }

      protected void send_integrity_lvl_hashes3N2( )
      {
      }

      protected void before_start_formulas( )
      {
         context.Gx_err = 0;
         edtavMondsc_Enabled = 0;
         AssignProp("", false, edtavMondsc_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavMondsc_Enabled), 5, 0), true);
         fix_multi_value_controls( ) ;
      }

      protected void STRUP3N0( )
      {
         /* Before Start, stand alone formulas. */
         before_start_formulas( ) ;
         /* Execute Start event if defined. */
         context.wbGlbDoneStart = 0;
         /* Execute user event: Start */
         E133N2 ();
         context.wbGlbDoneStart = 1;
         /* After Start, stand alone formulas. */
         if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
         {
            /* Read saved SDTs. */
            ajax_req_read_hidden_sdt(cgiGet( "vDDO_TITLESETTINGSICONS"), AV11DDO_TitleSettingsIcons);
            ajax_req_read_hidden_sdt(cgiGet( "vBANCOD_DATA"), AV14BanCod_Data);
            ajax_req_read_hidden_sdt(cgiGet( "vCBCOD_DATA"), AV10CBCod_Data);
            /* Read saved values. */
            Combo_bancod_Cls = cgiGet( "COMBO_BANCOD_Cls");
            Combo_bancod_Selectedvalue_set = cgiGet( "COMBO_BANCOD_Selectedvalue_set");
            Combo_cbcod_Cls = cgiGet( "COMBO_CBCOD_Cls");
            Combo_cbcod_Selectedvalue_set = cgiGet( "COMBO_CBCOD_Selectedvalue_set");
            Combo_cbcod_Selectedtext_set = cgiGet( "COMBO_CBCOD_Selectedtext_set");
            Combo_cbcod_Datalistproc = cgiGet( "COMBO_CBCOD_Datalistproc");
            Combo_cbcod_Datalistprocparametersprefix = cgiGet( "COMBO_CBCOD_Datalistprocparametersprefix");
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
            Combo_cbcod_Selectedvalue_get = cgiGet( "COMBO_CBCOD_Selectedvalue_get");
            Combo_bancod_Selectedvalue_get = cgiGet( "COMBO_BANCOD_Selectedvalue_get");
            /* Read variables values. */
            AV7MonDsc = cgiGet( edtavMondsc_Internalname);
            AssignAttri("", false, "AV7MonDsc", AV7MonDsc);
            if ( ( ( context.localUtil.CToN( cgiGet( edtavConano_Internalname), ".", ",") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtavConano_Internalname), ".", ",") > Convert.ToDecimal( 9999 )) ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "vCONANO");
               GX_FocusControl = edtavConano_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               AV8ConAno = 0;
               AssignAttri("", false, "AV8ConAno", StringUtil.LTrimStr( (decimal)(AV8ConAno), 4, 0));
            }
            else
            {
               AV8ConAno = (short)(context.localUtil.CToN( cgiGet( edtavConano_Internalname), ".", ","));
               AssignAttri("", false, "AV8ConAno", StringUtil.LTrimStr( (decimal)(AV8ConAno), 4, 0));
            }
            cmbavConmes.CurrentValue = cgiGet( cmbavConmes_Internalname);
            AV9ConMes = (short)(NumberUtil.Val( cgiGet( cmbavConmes_Internalname), "."));
            AssignAttri("", false, "AV9ConMes", StringUtil.LTrimStr( (decimal)(AV9ConMes), 2, 0));
            if ( ( ( context.localUtil.CToN( cgiGet( edtavBancod_Internalname), ".", ",") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtavBancod_Internalname), ".", ",") > Convert.ToDecimal( 999999 )) ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "vBANCOD");
               GX_FocusControl = edtavBancod_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               AV5BanCod = 0;
               AssignAttri("", false, "AV5BanCod", StringUtil.LTrimStr( (decimal)(AV5BanCod), 6, 0));
            }
            else
            {
               AV5BanCod = (int)(context.localUtil.CToN( cgiGet( edtavBancod_Internalname), ".", ","));
               AssignAttri("", false, "AV5BanCod", StringUtil.LTrimStr( (decimal)(AV5BanCod), 6, 0));
            }
            AV6CBCod = cgiGet( edtavCbcod_Internalname);
            AssignAttri("", false, "AV6CBCod", AV6CBCod);
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
         E133N2 ();
         if (returnInSub) return;
      }

      protected void E133N2( )
      {
         /* Start Routine */
         returnInSub = false;
         GXt_SdtDVB_SDTDropDownOptionsTitleSettingsIcons1 = AV11DDO_TitleSettingsIcons;
         new GeneXus.Programs.wwpbaseobjects.getwwptitlesettingsicons(context ).execute( out  GXt_SdtDVB_SDTDropDownOptionsTitleSettingsIcons1) ;
         AV11DDO_TitleSettingsIcons = GXt_SdtDVB_SDTDropDownOptionsTitleSettingsIcons1;
         edtavCbcod_Visible = 0;
         AssignProp("", false, edtavCbcod_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavCbcod_Visible), 5, 0), true);
         edtavBancod_Visible = 0;
         AssignProp("", false, edtavBancod_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavBancod_Visible), 5, 0), true);
         /* Execute user subroutine: 'LOADCOMBOBANCOD' */
         S112 ();
         if (returnInSub) return;
         /* Execute user subroutine: 'LOADCOMBOCBCOD' */
         S122 ();
         if (returnInSub) return;
         AV8ConAno = (short)(DateTimeUtil.Year( DateTimeUtil.Today( context)));
         AssignAttri("", false, "AV8ConAno", StringUtil.LTrimStr( (decimal)(AV8ConAno), 4, 0));
         AV9ConMes = (short)(DateTimeUtil.Month( DateTimeUtil.Today( context)));
         AssignAttri("", false, "AV9ConMes", StringUtil.LTrimStr( (decimal)(AV9ConMes), 2, 0));
         edtavMondsc_Enabled = 0;
         AssignProp("", false, edtavMondsc_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavMondsc_Enabled), 5, 0), true);
      }

      protected void E143N2( )
      {
         /* 'DoBtnImprimir' Routine */
         returnInSub = false;
         GXKey = Crypto.GetSiteKey( );
         GXEncryptionTmp = "bancos.r_reporteconciliacionbancariapdf.aspx"+UrlEncode(StringUtil.LTrimStr(AV5BanCod,6,0)) + "," + UrlEncode(StringUtil.RTrim(AV6CBCod)) + "," + UrlEncode(StringUtil.LTrimStr(AV8ConAno,4,0)) + "," + UrlEncode(StringUtil.LTrimStr(AV9ConMes,2,0));
         Innewwindow_Target = formatLink("bancos.r_reporteconciliacionbancariapdf.aspx") + "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey);
         ucInnewwindow.SendProperty(context, "", false, Innewwindow_Internalname, "Target", Innewwindow_Target);
         this.executeUsercontrolMethod("", false, "INNEWWINDOWContainer", "OpenWindow", "", new Object[] {});
         /*  Sending Event outputs  */
      }

      protected void E153N2( )
      {
         /* 'DoBtnSalir' Routine */
         returnInSub = false;
         CallWebObject(formatLink("wwpbaseobjects.home.aspx") );
         context.wjLocDisableFrm = 1;
      }

      protected void E123N2( )
      {
         /* Combo_cbcod_Onoptionclicked Routine */
         returnInSub = false;
         AV6CBCod = Combo_cbcod_Selectedvalue_get;
         AssignAttri("", false, "AV6CBCod", AV6CBCod);
         GXt_char2 = AV7MonDsc;
         new GeneXus.Programs.generales.pobtienemoneda(context ).execute(  AV5BanCod,  AV6CBCod, out  GXt_char2) ;
         AV7MonDsc = GXt_char2;
         AssignAttri("", false, "AV7MonDsc", AV7MonDsc);
         /*  Sending Event outputs  */
      }

      protected void E113N2( )
      {
         /* Combo_bancod_Onoptionclicked Routine */
         returnInSub = false;
         AV13Cond_BanCod = AV5BanCod;
         AV5BanCod = (int)(NumberUtil.Val( Combo_bancod_Selectedvalue_get, "."));
         AssignAttri("", false, "AV5BanCod", StringUtil.LTrimStr( (decimal)(AV5BanCod), 6, 0));
         if ( AV13Cond_BanCod != AV5BanCod )
         {
            AV6CBCod = "";
            AssignAttri("", false, "AV6CBCod", AV6CBCod);
            Combo_cbcod_Selectedvalue_set = "";
            ucCombo_cbcod.SendProperty(context, "", false, Combo_cbcod_Internalname, "SelectedValue_set", Combo_cbcod_Selectedvalue_set);
            Combo_cbcod_Selectedtext_set = "";
            ucCombo_cbcod.SendProperty(context, "", false, Combo_cbcod_Internalname, "SelectedText_set", Combo_cbcod_Selectedtext_set);
         }
         /*  Sending Event outputs  */
      }

      protected void S122( )
      {
         /* 'LOADCOMBOCBCOD' Routine */
         returnInSub = false;
         Combo_cbcod_Datalistprocparametersprefix = StringUtil.Format( " \"ComboName\": \"CBCod\", \"Cond_BanCod\": \"#%1#\"", edtavBancod_Internalname, "", "", "", "", "", "", "", "");
         ucCombo_cbcod.SendProperty(context, "", false, Combo_cbcod_Internalname, "DataListProcParametersPrefix", Combo_cbcod_Datalistprocparametersprefix);
         AV13Cond_BanCod = AV5BanCod;
         AV18GXLvl80 = 0;
         /* Using cursor H003N2 */
         pr_default.execute(0, new Object[] {AV6CBCod});
         while ( (pr_default.getStatus(0) != 101) )
         {
            A504CBSts = H003N2_A504CBSts[0];
            A377CBCod = H003N2_A377CBCod[0];
            AV18GXLvl80 = 1;
            Combo_cbcod_Selectedtext_set = A377CBCod;
            ucCombo_cbcod.SendProperty(context, "", false, Combo_cbcod_Internalname, "SelectedText_set", Combo_cbcod_Selectedtext_set);
            /* Exit For each command. Update data (if necessary), close cursors & exit. */
            if (true) break;
            pr_default.readNext(0);
         }
         pr_default.close(0);
         if ( AV18GXLvl80 == 0 )
         {
            Combo_cbcod_Selectedtext_set = "";
            ucCombo_cbcod.SendProperty(context, "", false, Combo_cbcod_Internalname, "SelectedText_set", Combo_cbcod_Selectedtext_set);
         }
         Combo_cbcod_Selectedvalue_set = AV6CBCod;
         ucCombo_cbcod.SendProperty(context, "", false, Combo_cbcod_Internalname, "SelectedValue_set", Combo_cbcod_Selectedvalue_set);
      }

      protected void S112( )
      {
         /* 'LOADCOMBOBANCOD' Routine */
         returnInSub = false;
         /* Using cursor H003N3 */
         pr_default.execute(1);
         while ( (pr_default.getStatus(1) != 101) )
         {
            A483BanSts = H003N3_A483BanSts[0];
            A372BanCod = H003N3_A372BanCod[0];
            A482BanDsc = H003N3_A482BanDsc[0];
            AV12Combo_DataItem = new GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTComboData_Item(context);
            AV12Combo_DataItem.gxTpr_Id = StringUtil.Trim( StringUtil.Str( (decimal)(A372BanCod), 6, 0));
            AV12Combo_DataItem.gxTpr_Title = A482BanDsc;
            AV14BanCod_Data.Add(AV12Combo_DataItem, 0);
            pr_default.readNext(1);
         }
         pr_default.close(1);
         Combo_bancod_Selectedvalue_set = ((0==AV5BanCod) ? "" : StringUtil.Trim( StringUtil.Str( (decimal)(AV5BanCod), 6, 0)));
         ucCombo_bancod.SendProperty(context, "", false, Combo_bancod_Internalname, "SelectedValue_set", Combo_bancod_Selectedvalue_set);
      }

      protected void nextLoad( )
      {
      }

      protected void E163N2( )
      {
         /* Load Routine */
         returnInSub = false;
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
         PA3N2( ) ;
         WS3N2( ) ;
         WE3N2( ) ;
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
         AddThemeStyleSheetFile("", context.GetTheme( )+".css", "?"+GetCacheInvalidationToken( ));
         bool outputEnabled = isOutputEnabled( );
         if ( context.isSpaRequest( ) )
         {
            enableOutput();
         }
         idxLst = 1;
         while ( idxLst <= Form.Jscriptsrc.Count )
         {
            context.AddJavascriptSource(StringUtil.RTrim( ((string)Form.Jscriptsrc.Item(idxLst))), "?20228181031418", true, true);
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
         context.AddJavascriptSource("bancos/r_reporteconciliacionbancaria.js", "?20228181031418", false, true);
         context.AddJavascriptSource("DVelop/Bootstrap/Shared/DVelopBootstrap.js", "", false, true);
         context.AddJavascriptSource("DVelop/Shared/WorkWithPlusCommon.js", "", false, true);
         context.AddJavascriptSource("DVelop/Bootstrap/Panel/BootstrapPanelRender.js", "", false, true);
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
         cmbavConmes.Name = "vCONMES";
         cmbavConmes.WebTags = "";
         cmbavConmes.addItem("1", "Enero", 0);
         cmbavConmes.addItem("2", "Febrero", 0);
         cmbavConmes.addItem("3", "Marzo", 0);
         cmbavConmes.addItem("4", "Abril", 0);
         cmbavConmes.addItem("5", "Mayo", 0);
         cmbavConmes.addItem("6", "Junio", 0);
         cmbavConmes.addItem("7", "Julio", 0);
         cmbavConmes.addItem("8", "Agosto", 0);
         cmbavConmes.addItem("9", "Septiembre", 0);
         cmbavConmes.addItem("10", "Octubre", 0);
         cmbavConmes.addItem("11", "Noviembre", 0);
         cmbavConmes.addItem("12", "Diciembre", 0);
         if ( cmbavConmes.ItemCount > 0 )
         {
            AV9ConMes = (short)(NumberUtil.Val( cmbavConmes.getValidValue(StringUtil.Trim( StringUtil.Str( (decimal)(AV9ConMes), 2, 0))), "."));
            AssignAttri("", false, "AV9ConMes", StringUtil.LTrimStr( (decimal)(AV9ConMes), 2, 0));
         }
         /* End function init_web_controls */
      }

      protected void init_default_properties( )
      {
         lblTextblockcombo_bancod_Internalname = "TEXTBLOCKCOMBO_BANCOD";
         Combo_bancod_Internalname = "COMBO_BANCOD";
         divTablesplittedbancod_Internalname = "TABLESPLITTEDBANCOD";
         lblTextblockcombo_cbcod_Internalname = "TEXTBLOCKCOMBO_CBCOD";
         Combo_cbcod_Internalname = "COMBO_CBCOD";
         divTablesplittedcbcod_Internalname = "TABLESPLITTEDCBCOD";
         lblTextblockmondsc_Internalname = "TEXTBLOCKMONDSC";
         edtavMondsc_Internalname = "vMONDSC";
         divUnnamedtablemondsc_Internalname = "UNNAMEDTABLEMONDSC";
         lblTextblockconano_Internalname = "TEXTBLOCKCONANO";
         edtavConano_Internalname = "vCONANO";
         divUnnamedtableconano_Internalname = "UNNAMEDTABLECONANO";
         lblTextblockconmes_Internalname = "TEXTBLOCKCONMES";
         cmbavConmes_Internalname = "vCONMES";
         divUnnamedtableconmes_Internalname = "UNNAMEDTABLECONMES";
         divPanel1_Internalname = "PANEL1";
         Dvpanel_panel1_Internalname = "DVPANEL_PANEL1";
         bttBtnbtnimprimir_Internalname = "BTNBTNIMPRIMIR";
         bttBtnbtnsalir_Internalname = "BTNBTNSALIR";
         Innewwindow_Internalname = "INNEWWINDOW";
         divTablecontent_Internalname = "TABLECONTENT";
         divTablemain_Internalname = "TABLEMAIN";
         edtavBancod_Internalname = "vBANCOD";
         edtavCbcod_Internalname = "vCBCOD";
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
         edtavCbcod_Jsonclick = "";
         edtavCbcod_Visible = 1;
         edtavBancod_Jsonclick = "";
         edtavBancod_Visible = 1;
         cmbavConmes_Jsonclick = "";
         cmbavConmes.Enabled = 1;
         edtavConano_Jsonclick = "";
         edtavConano_Enabled = 1;
         edtavMondsc_Jsonclick = "";
         edtavMondsc_Enabled = 1;
         Combo_cbcod_Caption = "";
         Combo_bancod_Caption = "";
         Innewwindow_Target = "";
         Dvpanel_panel1_Autoscroll = Convert.ToBoolean( 0);
         Dvpanel_panel1_Iconposition = "Right";
         Dvpanel_panel1_Showcollapseicon = Convert.ToBoolean( 0);
         Dvpanel_panel1_Collapsed = Convert.ToBoolean( 0);
         Dvpanel_panel1_Collapsible = Convert.ToBoolean( -1);
         Dvpanel_panel1_Title = "Conciliación Bancaria";
         Dvpanel_panel1_Cls = "PanelFilled Panel_BaseColor";
         Dvpanel_panel1_Autoheight = Convert.ToBoolean( -1);
         Dvpanel_panel1_Autowidth = Convert.ToBoolean( 0);
         Dvpanel_panel1_Width = "100%";
         Combo_cbcod_Datalistprocparametersprefix = "";
         Combo_cbcod_Datalistproc = "Bancos.R_ReporteConciliacionBancariaLoadDVCombo";
         Combo_cbcod_Cls = "ExtendedCombo AttributeRealWidth50With";
         Combo_bancod_Cls = "ExtendedCombo AttributeRealWidth50With";
         Form.Headerrawhtml = "";
         Form.Background = "";
         Form.Textcolor = 0;
         Form.Backcolor = (int)(0xFFFFFF);
         Form.Caption = "Reporte Conciliación Bancaria";
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
         setEventMetadata("'DOBTNIMPRIMIR'","{handler:'E143N2',iparms:[{av:'AV5BanCod',fld:'vBANCOD',pic:'ZZZZZ9'},{av:'AV6CBCod',fld:'vCBCOD',pic:''},{av:'AV8ConAno',fld:'vCONANO',pic:'ZZZ9'},{av:'cmbavConmes'},{av:'AV9ConMes',fld:'vCONMES',pic:'Z9'}]");
         setEventMetadata("'DOBTNIMPRIMIR'",",oparms:[{av:'Innewwindow_Target',ctrl:'INNEWWINDOW',prop:'Target'}]}");
         setEventMetadata("'DOBTNSALIR'","{handler:'E153N2',iparms:[]");
         setEventMetadata("'DOBTNSALIR'",",oparms:[]}");
         setEventMetadata("COMBO_CBCOD.ONOPTIONCLICKED","{handler:'E123N2',iparms:[{av:'Combo_cbcod_Selectedvalue_get',ctrl:'COMBO_CBCOD',prop:'SelectedValue_get'},{av:'AV5BanCod',fld:'vBANCOD',pic:'ZZZZZ9'}]");
         setEventMetadata("COMBO_CBCOD.ONOPTIONCLICKED",",oparms:[{av:'AV6CBCod',fld:'vCBCOD',pic:''},{av:'AV7MonDsc',fld:'vMONDSC',pic:''}]}");
         setEventMetadata("COMBO_BANCOD.ONOPTIONCLICKED","{handler:'E113N2',iparms:[{av:'AV5BanCod',fld:'vBANCOD',pic:'ZZZZZ9'},{av:'Combo_bancod_Selectedvalue_get',ctrl:'COMBO_BANCOD',prop:'SelectedValue_get'}]");
         setEventMetadata("COMBO_BANCOD.ONOPTIONCLICKED",",oparms:[{av:'AV5BanCod',fld:'vBANCOD',pic:'ZZZZZ9'},{av:'AV6CBCod',fld:'vCBCOD',pic:''},{av:'Combo_cbcod_Selectedvalue_set',ctrl:'COMBO_CBCOD',prop:'SelectedValue_set'},{av:'Combo_cbcod_Selectedtext_set',ctrl:'COMBO_CBCOD',prop:'SelectedText_set'}]}");
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
         Combo_cbcod_Selectedvalue_get = "";
         Combo_bancod_Selectedvalue_get = "";
         gxfirstwebparm = "";
         gxfirstwebparm_bkp = "";
         sDynURL = "";
         FormProcess = "";
         bodyStyle = "";
         GXKey = "";
         AV11DDO_TitleSettingsIcons = new GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTDropDownOptionsTitleSettingsIcons(context);
         AV14BanCod_Data = new GXBaseCollection<GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTComboData_Item>( context, "Item", "");
         AV10CBCod_Data = new GXBaseCollection<GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTComboData_Item>( context, "Item", "");
         Combo_bancod_Selectedvalue_set = "";
         Combo_cbcod_Selectedvalue_set = "";
         Combo_cbcod_Selectedtext_set = "";
         GX_FocusControl = "";
         Form = new GXWebForm();
         sPrefix = "";
         ClassString = "";
         StyleString = "";
         ucDvpanel_panel1 = new GXUserControl();
         lblTextblockcombo_bancod_Jsonclick = "";
         ucCombo_bancod = new GXUserControl();
         lblTextblockcombo_cbcod_Jsonclick = "";
         ucCombo_cbcod = new GXUserControl();
         lblTextblockmondsc_Jsonclick = "";
         TempTags = "";
         AV7MonDsc = "";
         lblTextblockconano_Jsonclick = "";
         lblTextblockconmes_Jsonclick = "";
         bttBtnbtnimprimir_Jsonclick = "";
         bttBtnbtnsalir_Jsonclick = "";
         ucInnewwindow = new GXUserControl();
         AV6CBCod = "";
         sEvt = "";
         EvtGridId = "";
         EvtRowId = "";
         sEvtType = "";
         GXt_SdtDVB_SDTDropDownOptionsTitleSettingsIcons1 = new GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTDropDownOptionsTitleSettingsIcons(context);
         GXEncryptionTmp = "";
         GXt_char2 = "";
         scmdbuf = "";
         H003N2_A372BanCod = new int[1] ;
         H003N2_A504CBSts = new short[1] ;
         H003N2_A377CBCod = new string[] {""} ;
         A377CBCod = "";
         H003N3_A483BanSts = new short[1] ;
         H003N3_A372BanCod = new int[1] ;
         H003N3_A482BanDsc = new string[] {""} ;
         A482BanDsc = "";
         AV12Combo_DataItem = new GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTComboData_Item(context);
         BackMsgLst = new msglist();
         LclMsgLst = new msglist();
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.bancos.r_reporteconciliacionbancaria__default(),
            new Object[][] {
                new Object[] {
               H003N2_A372BanCod, H003N2_A504CBSts, H003N2_A377CBCod
               }
               , new Object[] {
               H003N3_A483BanSts, H003N3_A372BanCod, H003N3_A482BanDsc
               }
            }
         );
         /* GeneXus formulas. */
         context.Gx_err = 0;
         edtavMondsc_Enabled = 0;
      }

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
      private short AV8ConAno ;
      private short AV9ConMes ;
      private short nDonePA ;
      private short AV18GXLvl80 ;
      private short A504CBSts ;
      private short A483BanSts ;
      private short nGXWrapped ;
      private int edtavMondsc_Enabled ;
      private int edtavConano_Enabled ;
      private int AV5BanCod ;
      private int edtavBancod_Visible ;
      private int edtavCbcod_Visible ;
      private int AV13Cond_BanCod ;
      private int A372BanCod ;
      private int idxLst ;
      private string Combo_cbcod_Selectedvalue_get ;
      private string Combo_bancod_Selectedvalue_get ;
      private string gxfirstwebparm ;
      private string gxfirstwebparm_bkp ;
      private string sDynURL ;
      private string FormProcess ;
      private string bodyStyle ;
      private string GXKey ;
      private string Combo_bancod_Cls ;
      private string Combo_bancod_Selectedvalue_set ;
      private string Combo_cbcod_Cls ;
      private string Combo_cbcod_Selectedvalue_set ;
      private string Combo_cbcod_Selectedtext_set ;
      private string Combo_cbcod_Datalistproc ;
      private string Combo_cbcod_Datalistprocparametersprefix ;
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
      private string divTablesplittedbancod_Internalname ;
      private string lblTextblockcombo_bancod_Internalname ;
      private string lblTextblockcombo_bancod_Jsonclick ;
      private string Combo_bancod_Caption ;
      private string Combo_bancod_Internalname ;
      private string divTablesplittedcbcod_Internalname ;
      private string lblTextblockcombo_cbcod_Internalname ;
      private string lblTextblockcombo_cbcod_Jsonclick ;
      private string Combo_cbcod_Caption ;
      private string Combo_cbcod_Internalname ;
      private string divUnnamedtablemondsc_Internalname ;
      private string lblTextblockmondsc_Internalname ;
      private string lblTextblockmondsc_Jsonclick ;
      private string edtavMondsc_Internalname ;
      private string TempTags ;
      private string AV7MonDsc ;
      private string edtavMondsc_Jsonclick ;
      private string divUnnamedtableconano_Internalname ;
      private string lblTextblockconano_Internalname ;
      private string lblTextblockconano_Jsonclick ;
      private string edtavConano_Internalname ;
      private string edtavConano_Jsonclick ;
      private string divUnnamedtableconmes_Internalname ;
      private string lblTextblockconmes_Internalname ;
      private string lblTextblockconmes_Jsonclick ;
      private string cmbavConmes_Internalname ;
      private string cmbavConmes_Jsonclick ;
      private string bttBtnbtnimprimir_Internalname ;
      private string bttBtnbtnimprimir_Jsonclick ;
      private string bttBtnbtnsalir_Internalname ;
      private string bttBtnbtnsalir_Jsonclick ;
      private string Innewwindow_Internalname ;
      private string divHtml_bottomauxiliarcontrols_Internalname ;
      private string edtavBancod_Internalname ;
      private string edtavBancod_Jsonclick ;
      private string edtavCbcod_Internalname ;
      private string AV6CBCod ;
      private string edtavCbcod_Jsonclick ;
      private string sEvt ;
      private string EvtGridId ;
      private string EvtRowId ;
      private string sEvtType ;
      private string GXEncryptionTmp ;
      private string GXt_char2 ;
      private string scmdbuf ;
      private string A377CBCod ;
      private string A482BanDsc ;
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
      private GXUserControl ucDvpanel_panel1 ;
      private GXUserControl ucCombo_bancod ;
      private GXUserControl ucCombo_cbcod ;
      private GXUserControl ucInnewwindow ;
      private IGxDataStore dsDataStore2 ;
      private IGxDataStore dsDefault ;
      private GXCombobox cmbavConmes ;
      private IDataStoreProvider pr_default ;
      private int[] H003N2_A372BanCod ;
      private short[] H003N2_A504CBSts ;
      private string[] H003N2_A377CBCod ;
      private short[] H003N3_A483BanSts ;
      private int[] H003N3_A372BanCod ;
      private string[] H003N3_A482BanDsc ;
      private msglist BackMsgLst ;
      private msglist LclMsgLst ;
      private GXBaseCollection<GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTComboData_Item> AV14BanCod_Data ;
      private GXBaseCollection<GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTComboData_Item> AV10CBCod_Data ;
      private GXWebForm Form ;
      private GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTComboData_Item AV12Combo_DataItem ;
      private GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTDropDownOptionsTitleSettingsIcons AV11DDO_TitleSettingsIcons ;
      private GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTDropDownOptionsTitleSettingsIcons GXt_SdtDVB_SDTDropDownOptionsTitleSettingsIcons1 ;
   }

   public class r_reporteconciliacionbancaria__default : DataStoreHelperBase, IDataStoreHelper
   {
      public ICursor[] getCursors( )
      {
         cursorDefinitions();
         return new Cursor[] {
          new ForEachCursor(def[0])
         ,new ForEachCursor(def[1])
       };
    }

    private static CursorDef[] def;
    private void cursorDefinitions( )
    {
       if ( def == null )
       {
          Object[] prmH003N2;
          prmH003N2 = new Object[] {
          new ParDef("@AV6CBCod",GXType.NChar,20,0)
          };
          Object[] prmH003N3;
          prmH003N3 = new Object[] {
          };
          def= new CursorDef[] {
              new CursorDef("H003N2", "SELECT TOP 1 [BanCod], [CBSts], [CBCod] FROM [TSCUENTABANCO] WHERE ([CBCod] = @AV6CBCod) AND ([CBSts] = 1) ORDER BY [BanCod], [CBCod] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH003N2,1, GxCacheFrequency.OFF ,false,true )
             ,new CursorDef("H003N3", "SELECT [BanSts], [BanCod], [BanDsc] FROM [TSBANCOS] WHERE [BanSts] = 1 ORDER BY [BanDsc] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH003N3,100, GxCacheFrequency.OFF ,false,false )
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
                ((short[]) buf[1])[0] = rslt.getShort(2);
                ((string[]) buf[2])[0] = rslt.getString(3, 20);
                return;
             case 1 :
                ((short[]) buf[0])[0] = rslt.getShort(1);
                ((int[]) buf[1])[0] = rslt.getInt(2);
                ((string[]) buf[2])[0] = rslt.getString(3, 100);
                return;
       }
    }

 }

}
