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
   public class r_resumennotasentradas : GXDataArea
   {
      public r_resumennotasentradas( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDataStore2 = context.GetDataStore("DataStore2");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusTheme");
      }

      public r_resumennotasentradas( IGxContext context )
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
         radavValidar = new GXRadio();
         radavTipo = new GXRadio();
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
         PA4I2( ) ;
         gxajaxcallmode = (short)((isAjaxCallMode( ) ? 1 : 0));
         if ( ( gxajaxcallmode == 0 ) && ( GxWebError == 0 ) )
         {
            START4I2( ) ;
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
         context.AddJavascriptSource("gxcfg.js", "?202281810311645", false, true);
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
         context.WriteHtmlTextNl( "<form id=\"MAINFORM\" autocomplete=\"off\" name=\"MAINFORM\" method=\"post\" tabindex=-1  class=\"form-horizontal Form\" data-gx-class=\"form-horizontal Form\" novalidate action=\""+formatLink("almacen.r_resumennotasentradas.aspx") +"\">") ;
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
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "vMOVCOD_DATA", AV26MovCod_Data);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt("vMOVCOD_DATA", AV26MovCod_Data);
         }
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "vLINCOD_DATA", AV24LinCod_Data);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt("vLINCOD_DATA", AV24LinCod_Data);
         }
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "vSUBLCOD_DATA", AV34SubLCod_Data);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt("vSUBLCOD_DATA", AV34SubLCod_Data);
         }
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "vFAMCOD_DATA", AV17FamCod_Data);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt("vFAMCOD_DATA", AV17FamCod_Data);
         }
         GxWebStd.gx_hidden_field( context, "COMBO_ALMCOD_Cls", StringUtil.RTrim( Combo_almcod_Cls));
         GxWebStd.gx_hidden_field( context, "COMBO_ALMCOD_Selectedvalue_set", StringUtil.RTrim( Combo_almcod_Selectedvalue_set));
         GxWebStd.gx_hidden_field( context, "COMBO_MOVCOD_Cls", StringUtil.RTrim( Combo_movcod_Cls));
         GxWebStd.gx_hidden_field( context, "COMBO_MOVCOD_Selectedvalue_set", StringUtil.RTrim( Combo_movcod_Selectedvalue_set));
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
         GxWebStd.gx_hidden_field( context, "COMBO_MOVCOD_Selectedvalue_get", StringUtil.RTrim( Combo_movcod_Selectedvalue_get));
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
            WE4I2( ) ;
            context.WriteHtmlText( "</div>") ;
         }
      }

      public override void DispatchEvents( )
      {
         EVT4I2( ) ;
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
         return formatLink("almacen.r_resumennotasentradas.aspx")  ;
      }

      public override string GetPgmname( )
      {
         return "Almacen.R_ResumenNotasEntradas" ;
      }

      public override string GetPgmdesc( )
      {
         return "R_Resumen Notas Entradas" ;
      }

      protected void WB4I0( )
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
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-6 DataContentCell ExtendedComboCell", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divTablesplittedalmcod_Internalname, 1, 0, "px", 0, "px", "Table", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-6 MergeLabelCell CellWidth_12_5", "left", "top", "", "", "div");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblTextblockcombo_almcod_Internalname, "Almacen", "", "", lblTextblockcombo_almcod_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "Label", 0, "", 1, 1, 0, 0, "HLP_Almacen\\R_ResumenNotasEntradas.htm");
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
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-6 ExtendedComboCell", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divTablesplittedmovcod_Internalname, 1, 0, "px", 0, "px", "Table", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-3 MergeLabelCell", "left", "top", "", "", "div");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblTextblockcombo_movcod_Internalname, "Tipo de Movimiento", "", "", lblTextblockcombo_movcod_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "Label", 0, "", 1, 1, 0, 0, "HLP_Almacen\\R_ResumenNotasEntradas.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-9", "left", "top", "", "", "div");
            /* User Defined Control */
            ucCombo_movcod.SetProperty("Caption", Combo_movcod_Caption);
            ucCombo_movcod.SetProperty("Cls", Combo_movcod_Cls);
            ucCombo_movcod.SetProperty("DropDownOptionsData", AV26MovCod_Data);
            ucCombo_movcod.Render(context, "dvelop.gxbootstrap.ddoextendedcombo", Combo_movcod_Internalname, "COMBO_MOVCODContainer");
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
            GxWebStd.gx_label_ctrl( context, lblTextblockcombo_lincod_Internalname, "Linea Producto", "", "", lblTextblockcombo_lincod_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "Label", 0, "", 1, 1, 0, 0, "HLP_Almacen\\R_ResumenNotasEntradas.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-6 CellWidth_87_5", "left", "top", "", "", "div");
            /* User Defined Control */
            ucCombo_lincod.SetProperty("Caption", Combo_lincod_Caption);
            ucCombo_lincod.SetProperty("Cls", Combo_lincod_Cls);
            ucCombo_lincod.SetProperty("DropDownOptionsData", AV24LinCod_Data);
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
            GxWebStd.gx_label_ctrl( context, lblTextblockcombo_sublcod_Internalname, "Sub Linea", "", "", lblTextblockcombo_sublcod_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "Label", 0, "", 1, 1, 0, 0, "HLP_Almacen\\R_ResumenNotasEntradas.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-6 CellWidth_87_5", "left", "top", "", "", "div");
            /* User Defined Control */
            ucCombo_sublcod.SetProperty("Caption", Combo_sublcod_Caption);
            ucCombo_sublcod.SetProperty("Cls", Combo_sublcod_Cls);
            ucCombo_sublcod.SetProperty("DropDownOptionsData", AV34SubLCod_Data);
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
            GxWebStd.gx_label_ctrl( context, lblTextblockcombo_famcod_Internalname, "Familia", "", "", lblTextblockcombo_famcod_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "Label", 0, "", 1, 1, 0, 0, "HLP_Almacen\\R_ResumenNotasEntradas.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-6 CellWidth_87_5", "left", "top", "", "", "div");
            /* User Defined Control */
            ucCombo_famcod.SetProperty("Caption", Combo_famcod_Caption);
            ucCombo_famcod.SetProperty("Cls", Combo_famcod_Cls);
            ucCombo_famcod.SetProperty("DropDownOptionsData", AV17FamCod_Data);
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
            GxWebStd.gx_label_ctrl( context, lblTextblockprodcod_Internalname, "Producto", "", "", lblTextblockprodcod_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "Label", 0, "", 1, 1, 0, 0, "HLP_Almacen\\R_ResumenNotasEntradas.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-6 CellWidth_87_5", "left", "top", "", "", "div");
            wb_table1_64_4I2( true) ;
         }
         else
         {
            wb_table1_64_4I2( false) ;
         }
         return  ;
      }

      protected void wb_table1_64_4I2e( bool wbgen )
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
            GxWebStd.gx_div_start( context, divUnnamedtablevalidar_Internalname, 1, 0, "px", 0, "px", "Table", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-6 MergeLabelCell CellWidth_12_5", "left", "top", "", "", "div");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblTextblockvalidar_Internalname, "Tipo", "", "", lblTextblockvalidar_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "Label", 0, "", 1, 1, 0, 0, "HLP_Almacen\\R_ResumenNotasEntradas.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-6 CellWidth_87_5", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "left", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, "", "Validar", "col-sm-3 AttributeCheckBoxLabel", 0, true, "");
            /* Radio button */
            ClassString = "AttributeCheckBox";
            StyleString = "";
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 82,'',false,'',0)\"";
            GxWebStd.gx_radio_ctrl( context, radavValidar, radavValidar_Internalname, StringUtil.RTrim( AV40Validar), "", 1, 1, 0, 0, StyleString, ClassString, "", "", 0, radavValidar_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", TempTags+" onclick="+"\""+"gx.evt.onchange(this, event);\""+" onblur=\""+""+";gx.evt.onblur(this,82);\"", "HLP_Almacen\\R_ResumenNotasEntradas.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 DataContentCell", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divUnnamedtablefdesde_Internalname, 1, 0, "px", 0, "px", "Table", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-6 MergeLabelCell CellWidth_12_5", "left", "top", "", "", "div");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblTextblockfdesde_Internalname, "Desde", "", "", lblTextblockfdesde_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "Label", 0, "", 1, 1, 0, 0, "HLP_Almacen\\R_ResumenNotasEntradas.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-6 CellWidth_87_5", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "left", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavFdesde_Internalname, "FDesde", "col-sm-3 AttributeDateLabel", 0, true, "");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 90,'',false,'',0)\"";
            context.WriteHtmlText( "<div id=\""+edtavFdesde_Internalname+"_dp_container\" class=\"dp_container\" style=\"white-space:nowrap;display:inline;\">") ;
            GxWebStd.gx_single_line_edit( context, edtavFdesde_Internalname, context.localUtil.Format(AV18FDesde, "99/99/99"), context.localUtil.Format( AV18FDesde, "99/99/99"), TempTags+" onchange=\""+"gx.date.valid_date(this, 8,'DMY',0,24,'spa',false,0);"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.date.valid_date(this, 8,'DMY',0,24,'spa',false,0);"+";gx.evt.onblur(this,90);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavFdesde_Jsonclick, 0, "AttributeDate", "", "", "", "", 1, edtavFdesde_Enabled, 0, "text", "", 8, "chr", 1, "row", 8, 0, 0, 0, 1, -1, 0, true, "", "right", false, "", "HLP_Almacen\\R_ResumenNotasEntradas.htm");
            GxWebStd.gx_bitmap( context, edtavFdesde_Internalname+"_dp_trigger", context.GetImagePath( "61b9b5d3-dff6-4d59-9b00-da61bc2cbe93", "", context.GetTheme( )), "", "", "", "", ((1==0)||(edtavFdesde_Enabled==0) ? 0 : 1), 0, "Date selector", "Date selector", 0, 1, 0, "", 0, "", 0, 0, 0, "", "", "cursor: pointer;", "", "", "", "", "", "", "", "", 1, false, false, "", "HLP_Almacen\\R_ResumenNotasEntradas.htm");
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
            GxWebStd.gx_div_start( context, divUnnamedtablefhasta_Internalname, 1, 0, "px", 0, "px", "Table", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-6 MergeLabelCell CellWidth_12_5", "left", "top", "", "", "div");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblTextblockfhasta_Internalname, "Hasta", "", "", lblTextblockfhasta_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "Label", 0, "", 1, 1, 0, 0, "HLP_Almacen\\R_ResumenNotasEntradas.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-6 CellWidth_87_5", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "left", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavFhasta_Internalname, "FHasta", "col-sm-3 AttributeDateLabel", 0, true, "");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 99,'',false,'',0)\"";
            context.WriteHtmlText( "<div id=\""+edtavFhasta_Internalname+"_dp_container\" class=\"dp_container\" style=\"white-space:nowrap;display:inline;\">") ;
            GxWebStd.gx_single_line_edit( context, edtavFhasta_Internalname, context.localUtil.Format(AV22FHasta, "99/99/99"), context.localUtil.Format( AV22FHasta, "99/99/99"), TempTags+" onchange=\""+"gx.date.valid_date(this, 8,'DMY',0,24,'spa',false,0);"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.date.valid_date(this, 8,'DMY',0,24,'spa',false,0);"+";gx.evt.onblur(this,99);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavFhasta_Jsonclick, 0, "AttributeDate", "", "", "", "", 1, edtavFhasta_Enabled, 0, "text", "", 8, "chr", 1, "row", 8, 0, 0, 0, 1, -1, 0, true, "", "right", false, "", "HLP_Almacen\\R_ResumenNotasEntradas.htm");
            GxWebStd.gx_bitmap( context, edtavFhasta_Internalname+"_dp_trigger", context.GetImagePath( "61b9b5d3-dff6-4d59-9b00-da61bc2cbe93", "", context.GetTheme( )), "", "", "", "", ((1==0)||(edtavFhasta_Enabled==0) ? 0 : 1), 0, "Date selector", "Date selector", 0, 1, 0, "", 0, "", 0, 0, 0, "", "", "cursor: pointer;", "", "", "", "", "", "", "", "", 1, false, false, "", "HLP_Almacen\\R_ResumenNotasEntradas.htm");
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
            GxWebStd.gx_div_start( context, divUnnamedtabletipo_Internalname, 1, 0, "px", 0, "px", "Table", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-6 MergeLabelCell CellWidth_12_5", "left", "top", "", "", "div");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblTextblocktipo_Internalname, "Tipo", "", "", lblTextblocktipo_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "Label", 0, "", 1, 1, 0, 0, "HLP_Almacen\\R_ResumenNotasEntradas.htm");
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
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 108,'',false,'',0)\"";
            GxWebStd.gx_radio_ctrl( context, radavTipo, radavTipo_Internalname, StringUtil.RTrim( AV37Tipo), "", 1, 1, 0, 0, StyleString, ClassString, "", "", 0, radavTipo_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", TempTags+" onclick="+"\""+"gx.evt.onchange(this, event);\""+" onblur=\""+""+";gx.evt.onblur(this,108);\"", "HLP_Almacen\\R_ResumenNotasEntradas.htm");
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
            GxWebStd.gx_button_ctrl( context, bttBtnbtnimprimir_Internalname, "", "Imprimir", bttBtnbtnimprimir_Jsonclick, 5, "Imprimir", "", StyleString, ClassString, 1, 1, "standard", "'"+""+"'"+",false,"+"'"+"E\\'DOBTNIMPRIMIR\\'."+"'", TempTags, "", context.GetButtonType( ), "HLP_Almacen\\R_ResumenNotasEntradas.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "left", "top", "", "", "div");
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 115,'',false,'',0)\"";
            ClassString = "ButtonExcel";
            StyleString = "";
            GxWebStd.gx_button_ctrl( context, bttBtnbtnexcel_Internalname, "", "Excel", bttBtnbtnexcel_Jsonclick, 5, "Exportal a Excel", "", StyleString, ClassString, 1, 1, "standard", "'"+""+"'"+",false,"+"'"+"E\\'DOBTNEXCEL\\'."+"'", TempTags, "", context.GetButtonType( ), "HLP_Almacen\\R_ResumenNotasEntradas.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "left", "top", "", "", "div");
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 117,'',false,'',0)\"";
            ClassString = "ButtonColor";
            StyleString = "";
            GxWebStd.gx_button_ctrl( context, bttBtnbtnsalir_Internalname, "", "Salir", bttBtnbtnsalir_Jsonclick, 5, "Imprimir PDF", "", StyleString, ClassString, 1, 1, "standard", "'"+""+"'"+",false,"+"'"+"E\\'DOBTNSALIR\\'."+"'", TempTags, "", context.GetButtonType( ), "HLP_Almacen\\R_ResumenNotasEntradas.htm");
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
            GxWebStd.gx_single_line_edit( context, edtavAlmcod_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(AV5AlmCod), 6, 0, ".", "")), StringUtil.LTrim( context.localUtil.Format( (decimal)(AV5AlmCod), "ZZZZZ9")), " inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onblur(this,124);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavAlmcod_Jsonclick, 0, "Attribute", "", "", "", "", edtavAlmcod_Visible, 1, 0, "text", "1", 6, "chr", 1, "row", 6, 0, 0, 0, 1, -1, 0, true, "", "right", false, "", "HLP_Almacen\\R_ResumenNotasEntradas.htm");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 125,'',false,'',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavMovcod_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(AV25MovCod), 6, 0, ".", "")), StringUtil.LTrim( context.localUtil.Format( (decimal)(AV25MovCod), "ZZZZZ9")), " inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onblur(this,125);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavMovcod_Jsonclick, 0, "Attribute", "", "", "", "", edtavMovcod_Visible, 1, 0, "text", "1", 6, "chr", 1, "row", 6, 0, 0, 0, 1, -1, 0, true, "", "right", false, "", "HLP_Almacen\\R_ResumenNotasEntradas.htm");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 126,'',false,'',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavLincod_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(AV23LinCod), 6, 0, ".", "")), StringUtil.LTrim( context.localUtil.Format( (decimal)(AV23LinCod), "ZZZZZ9")), " inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onblur(this,126);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavLincod_Jsonclick, 0, "Attribute", "", "", "", "", edtavLincod_Visible, 1, 0, "text", "1", 6, "chr", 1, "row", 6, 0, 0, 0, 1, -1, 0, true, "", "right", false, "", "HLP_Almacen\\R_ResumenNotasEntradas.htm");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 127,'',false,'',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavSublcod_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(AV33SubLCod), 6, 0, ".", "")), StringUtil.LTrim( context.localUtil.Format( (decimal)(AV33SubLCod), "ZZZZZ9")), " inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onblur(this,127);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavSublcod_Jsonclick, 0, "Attribute", "", "", "", "", edtavSublcod_Visible, 1, 0, "text", "1", 6, "chr", 1, "row", 6, 0, 0, 0, 1, -1, 0, true, "", "right", false, "", "HLP_Almacen\\R_ResumenNotasEntradas.htm");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 128,'',false,'',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavFamcod_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(AV16FamCod), 6, 0, ".", "")), StringUtil.LTrim( context.localUtil.Format( (decimal)(AV16FamCod), "ZZZZZ9")), " inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onblur(this,128);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavFamcod_Jsonclick, 0, "Attribute", "", "", "", "", edtavFamcod_Visible, 1, 0, "text", "1", 6, "chr", 1, "row", 6, 0, 0, 0, 1, -1, 0, true, "", "right", false, "", "HLP_Almacen\\R_ResumenNotasEntradas.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
         }
         wbLoad = true;
      }

      protected void START4I2( )
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
            Form.Meta.addItem("description", "R_Resumen Notas Entradas", 0) ;
         }
         context.wjLoc = "";
         context.nUserReturn = 0;
         context.wbHandled = 0;
         if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
         {
         }
         wbErr = false;
         STRUP4I0( ) ;
      }

      protected void WS4I2( )
      {
         START4I2( ) ;
         EVT4I2( ) ;
      }

      protected void EVT4I2( )
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
                              E114I2 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "'DOBTNIMPRIMIR'") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              /* Execute user event: 'DoBtnImprimir' */
                              E124I2 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "'DOBTNEXCEL'") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              /* Execute user event: 'DoBtnExcel' */
                              E134I2 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "'DOBTNSALIR'") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              /* Execute user event: 'DoBtnSalir' */
                              E144I2 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "'DOBTNBUSCARPRO'") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              /* Execute user event: 'DoBtnBuscarPro' */
                              E154I2 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "LOAD") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              /* Execute user event: Load */
                              E164I2 ();
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

      protected void WE4I2( )
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

      protected void PA4I2( )
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
         AV40Validar = StringUtil.RTrim( AV40Validar);
         AssignAttri("", false, "AV40Validar", AV40Validar);
         AssignAttri("", false, "AV37Tipo", AV37Tipo);
      }

      public void Refresh( )
      {
         send_integrity_hashes( ) ;
         RF4I2( ) ;
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

      protected void RF4I2( )
      {
         initialize_formulas( ) ;
         clear_multi_value_controls( ) ;
         gxdyncontrolsrefreshing = true;
         fix_multi_value_controls( ) ;
         gxdyncontrolsrefreshing = false;
         if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
         {
            /* Execute user event: Load */
            E164I2 ();
            WB4I0( ) ;
         }
      }

      protected void send_integrity_lvl_hashes4I2( )
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

      protected void STRUP4I0( )
      {
         /* Before Start, stand alone formulas. */
         before_start_formulas( ) ;
         /* Execute Start event if defined. */
         context.wbGlbDoneStart = 0;
         /* Execute user event: Start */
         E114I2 ();
         context.wbGlbDoneStart = 1;
         /* After Start, stand alone formulas. */
         if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
         {
            /* Read saved SDTs. */
            ajax_req_read_hidden_sdt(cgiGet( "vALMCOD_DATA"), AV6AlmCod_Data);
            ajax_req_read_hidden_sdt(cgiGet( "vMOVCOD_DATA"), AV26MovCod_Data);
            ajax_req_read_hidden_sdt(cgiGet( "vLINCOD_DATA"), AV24LinCod_Data);
            ajax_req_read_hidden_sdt(cgiGet( "vSUBLCOD_DATA"), AV34SubLCod_Data);
            ajax_req_read_hidden_sdt(cgiGet( "vFAMCOD_DATA"), AV17FamCod_Data);
            /* Read saved values. */
            Combo_almcod_Cls = cgiGet( "COMBO_ALMCOD_Cls");
            Combo_almcod_Selectedvalue_set = cgiGet( "COMBO_ALMCOD_Selectedvalue_set");
            Combo_movcod_Cls = cgiGet( "COMBO_MOVCOD_Cls");
            Combo_movcod_Selectedvalue_set = cgiGet( "COMBO_MOVCOD_Selectedvalue_set");
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
            AV30ProdCod = StringUtil.Upper( cgiGet( edtavProdcod_Internalname));
            AssignAttri("", false, "AV30ProdCod", AV30ProdCod);
            AV31ProdDsc = cgiGet( edtavProddsc_Internalname);
            AssignAttri("", false, "AV31ProdDsc", AV31ProdDsc);
            AV40Validar = cgiGet( radavValidar_Internalname);
            AssignAttri("", false, "AV40Validar", AV40Validar);
            if ( context.localUtil.VCDate( cgiGet( edtavFdesde_Internalname), 2) == 0 )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_faildate", new   object[]  {"FDesde"}), 1, "vFDESDE");
               GX_FocusControl = edtavFdesde_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               AV18FDesde = DateTime.MinValue;
               AssignAttri("", false, "AV18FDesde", context.localUtil.Format(AV18FDesde, "99/99/99"));
            }
            else
            {
               AV18FDesde = context.localUtil.CToD( cgiGet( edtavFdesde_Internalname), 2);
               AssignAttri("", false, "AV18FDesde", context.localUtil.Format(AV18FDesde, "99/99/99"));
            }
            if ( context.localUtil.VCDate( cgiGet( edtavFhasta_Internalname), 2) == 0 )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_faildate", new   object[]  {"FHasta"}), 1, "vFHASTA");
               GX_FocusControl = edtavFhasta_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               AV22FHasta = DateTime.MinValue;
               AssignAttri("", false, "AV22FHasta", context.localUtil.Format(AV22FHasta, "99/99/99"));
            }
            else
            {
               AV22FHasta = context.localUtil.CToD( cgiGet( edtavFhasta_Internalname), 2);
               AssignAttri("", false, "AV22FHasta", context.localUtil.Format(AV22FHasta, "99/99/99"));
            }
            AV37Tipo = cgiGet( radavTipo_Internalname);
            AssignAttri("", false, "AV37Tipo", AV37Tipo);
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
            if ( ( ( context.localUtil.CToN( cgiGet( edtavMovcod_Internalname), ".", ",") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtavMovcod_Internalname), ".", ",") > Convert.ToDecimal( 999999 )) ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "vMOVCOD");
               GX_FocusControl = edtavMovcod_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               AV25MovCod = 0;
               AssignAttri("", false, "AV25MovCod", StringUtil.LTrimStr( (decimal)(AV25MovCod), 6, 0));
            }
            else
            {
               AV25MovCod = (int)(context.localUtil.CToN( cgiGet( edtavMovcod_Internalname), ".", ","));
               AssignAttri("", false, "AV25MovCod", StringUtil.LTrimStr( (decimal)(AV25MovCod), 6, 0));
            }
            if ( ( ( context.localUtil.CToN( cgiGet( edtavLincod_Internalname), ".", ",") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtavLincod_Internalname), ".", ",") > Convert.ToDecimal( 999999 )) ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "vLINCOD");
               GX_FocusControl = edtavLincod_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               AV23LinCod = 0;
               AssignAttri("", false, "AV23LinCod", StringUtil.LTrimStr( (decimal)(AV23LinCod), 6, 0));
            }
            else
            {
               AV23LinCod = (int)(context.localUtil.CToN( cgiGet( edtavLincod_Internalname), ".", ","));
               AssignAttri("", false, "AV23LinCod", StringUtil.LTrimStr( (decimal)(AV23LinCod), 6, 0));
            }
            if ( ( ( context.localUtil.CToN( cgiGet( edtavSublcod_Internalname), ".", ",") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtavSublcod_Internalname), ".", ",") > Convert.ToDecimal( 999999 )) ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "vSUBLCOD");
               GX_FocusControl = edtavSublcod_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               AV33SubLCod = 0;
               AssignAttri("", false, "AV33SubLCod", StringUtil.LTrimStr( (decimal)(AV33SubLCod), 6, 0));
            }
            else
            {
               AV33SubLCod = (int)(context.localUtil.CToN( cgiGet( edtavSublcod_Internalname), ".", ","));
               AssignAttri("", false, "AV33SubLCod", StringUtil.LTrimStr( (decimal)(AV33SubLCod), 6, 0));
            }
            if ( ( ( context.localUtil.CToN( cgiGet( edtavFamcod_Internalname), ".", ",") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtavFamcod_Internalname), ".", ",") > Convert.ToDecimal( 999999 )) ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "vFAMCOD");
               GX_FocusControl = edtavFamcod_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               AV16FamCod = 0;
               AssignAttri("", false, "AV16FamCod", StringUtil.LTrimStr( (decimal)(AV16FamCod), 6, 0));
            }
            else
            {
               AV16FamCod = (int)(context.localUtil.CToN( cgiGet( edtavFamcod_Internalname), ".", ","));
               AssignAttri("", false, "AV16FamCod", StringUtil.LTrimStr( (decimal)(AV16FamCod), 6, 0));
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
         E114I2 ();
         if (returnInSub) return;
      }

      protected void E114I2( )
      {
         /* Start Routine */
         returnInSub = false;
         edtavFamcod_Visible = 0;
         AssignProp("", false, edtavFamcod_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavFamcod_Visible), 5, 0), true);
         edtavSublcod_Visible = 0;
         AssignProp("", false, edtavSublcod_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavSublcod_Visible), 5, 0), true);
         edtavLincod_Visible = 0;
         AssignProp("", false, edtavLincod_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavLincod_Visible), 5, 0), true);
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
         /* Execute user subroutine: 'LOADCOMBOLINCOD' */
         S132 ();
         if (returnInSub) return;
         /* Execute user subroutine: 'LOADCOMBOSUBLCOD' */
         S142 ();
         if (returnInSub) return;
         /* Execute user subroutine: 'LOADCOMBOFAMCOD' */
         S152 ();
         if (returnInSub) return;
         AV38TipoOrden = 2;
         AV36SubTotal = "N";
         AV19Fecha = DateTimeUtil.Today( context);
      }

      protected void E124I2( )
      {
         /* 'DoBtnImprimir' Routine */
         returnInSub = false;
         context.DoAjaxRefresh();
         GXKey = Crypto.GetSiteKey( );
         GXEncryptionTmp = "almacen.r_resumenentradas.aspx"+UrlEncode(StringUtil.LTrimStr(AV25MovCod,6,0)) + "," + UrlEncode(StringUtil.LTrimStr(AV23LinCod,6,0)) + "," + UrlEncode(StringUtil.RTrim(AV30ProdCod)) + "," + UrlEncode(DateTimeUtil.FormatDateParm(AV18FDesde)) + "," + UrlEncode(DateTimeUtil.FormatDateParm(AV22FHasta)) + "," + UrlEncode(StringUtil.LTrimStr(AV5AlmCod,6,0)) + "," + UrlEncode(StringUtil.LTrimStr(AV33SubLCod,6,0)) + "," + UrlEncode(StringUtil.LTrimStr(AV16FamCod,6,0)) + "," + UrlEncode(StringUtil.RTrim(AV37Tipo));
         AV39URL = formatLink("almacen.r_resumenentradas.aspx") + "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey);
         Innewwindow_Target = AV39URL;
         ucInnewwindow.SendProperty(context, "", false, Innewwindow_Internalname, "Target", Innewwindow_Target);
         this.executeUsercontrolMethod("", false, "INNEWWINDOWContainer", "OpenWindow", "", new Object[] {});
         /*  Sending Event outputs  */
      }

      protected void E134I2( )
      {
         /* 'DoBtnExcel' Routine */
         returnInSub = false;
         context.DoAjaxRefresh();
         new GeneXus.Programs.almacen.r_resumenentradasexcel(context ).execute( ref  AV25MovCod, ref  AV23LinCod, ref  AV30ProdCod, ref  AV18FDesde, ref  AV22FHasta, ref  AV5AlmCod, ref  AV33SubLCod, ref  AV16FamCod, ref  AV37Tipo, out  AV15ExcelFilename, out  AV14ErrorMessage) ;
         AssignAttri("", false, "AV25MovCod", StringUtil.LTrimStr( (decimal)(AV25MovCod), 6, 0));
         AssignAttri("", false, "AV23LinCod", StringUtil.LTrimStr( (decimal)(AV23LinCod), 6, 0));
         AssignAttri("", false, "AV30ProdCod", AV30ProdCod);
         AssignAttri("", false, "AV18FDesde", context.localUtil.Format(AV18FDesde, "99/99/99"));
         AssignAttri("", false, "AV22FHasta", context.localUtil.Format(AV22FHasta, "99/99/99"));
         AssignAttri("", false, "AV5AlmCod", StringUtil.LTrimStr( (decimal)(AV5AlmCod), 6, 0));
         AssignAttri("", false, "AV33SubLCod", StringUtil.LTrimStr( (decimal)(AV33SubLCod), 6, 0));
         AssignAttri("", false, "AV16FamCod", StringUtil.LTrimStr( (decimal)(AV16FamCod), 6, 0));
         AssignAttri("", false, "AV37Tipo", AV37Tipo);
         if ( StringUtil.StrCmp(AV15ExcelFilename, "") != 0 )
         {
            CallWebObject(formatLink(AV15ExcelFilename) );
            context.wjLocDisableFrm = 0;
         }
         else
         {
            GX_msglist.addItem(AV14ErrorMessage);
         }
         /*  Sending Event outputs  */
         radavTipo.CurrentValue = StringUtil.RTrim( AV37Tipo);
         AssignProp("", false, radavTipo_Internalname, "Values", radavTipo.ToJavascriptSource(), true);
      }

      protected void E144I2( )
      {
         /* 'DoBtnSalir' Routine */
         returnInSub = false;
         CallWebObject(formatLink("wwpbaseobjects.home.aspx") );
         context.wjLocDisableFrm = 1;
      }

      protected void E154I2( )
      {
         /* 'DoBtnBuscarPro' Routine */
         returnInSub = false;
         context.DoAjaxRefresh();
         context.PopUp(formatLink("generales.wwbusquedaproducto.aspx", new object[] {UrlEncode(StringUtil.RTrim("")),UrlEncode(StringUtil.RTrim("")),UrlEncode(StringUtil.RTrim(""))}, new string[] {"OutProdCod","OutProdDsc","InTipo"}) , new Object[] {"AV30ProdCod","AV31ProdDsc",});
         /*  Sending Event outputs  */
      }

      protected void S152( )
      {
         /* 'LOADCOMBOFAMCOD' Routine */
         returnInSub = false;
         /* Using cursor H004I2 */
         pr_default.execute(0);
         while ( (pr_default.getStatus(0) != 101) )
         {
            A979FamSts = H004I2_A979FamSts[0];
            A50FamCod = H004I2_A50FamCod[0];
            A977FamDsc = H004I2_A977FamDsc[0];
            AV11Combo_DataItem = new GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTComboData_Item(context);
            AV11Combo_DataItem.gxTpr_Id = StringUtil.Trim( StringUtil.Str( (decimal)(A50FamCod), 6, 0));
            AV11Combo_DataItem.gxTpr_Title = A977FamDsc;
            AV17FamCod_Data.Add(AV11Combo_DataItem, 0);
            pr_default.readNext(0);
         }
         pr_default.close(0);
         Combo_famcod_Selectedvalue_set = ((0==AV16FamCod) ? "" : StringUtil.Trim( StringUtil.Str( (decimal)(AV16FamCod), 6, 0)));
         ucCombo_famcod.SendProperty(context, "", false, Combo_famcod_Internalname, "SelectedValue_set", Combo_famcod_Selectedvalue_set);
      }

      protected void S142( )
      {
         /* 'LOADCOMBOSUBLCOD' Routine */
         returnInSub = false;
         /* Using cursor H004I3 */
         pr_default.execute(1);
         while ( (pr_default.getStatus(1) != 101) )
         {
            A1893SublSts = H004I3_A1893SublSts[0];
            A51SublCod = H004I3_A51SublCod[0];
            A1892SublDsc = H004I3_A1892SublDsc[0];
            AV11Combo_DataItem = new GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTComboData_Item(context);
            AV11Combo_DataItem.gxTpr_Id = StringUtil.Trim( StringUtil.Str( (decimal)(A51SublCod), 6, 0));
            AV11Combo_DataItem.gxTpr_Title = A1892SublDsc;
            AV34SubLCod_Data.Add(AV11Combo_DataItem, 0);
            pr_default.readNext(1);
         }
         pr_default.close(1);
         Combo_sublcod_Selectedvalue_set = ((0==AV33SubLCod) ? "" : StringUtil.Trim( StringUtil.Str( (decimal)(AV33SubLCod), 6, 0)));
         ucCombo_sublcod.SendProperty(context, "", false, Combo_sublcod_Internalname, "SelectedValue_set", Combo_sublcod_Selectedvalue_set);
      }

      protected void S132( )
      {
         /* 'LOADCOMBOLINCOD' Routine */
         returnInSub = false;
         /* Using cursor H004I4 */
         pr_default.execute(2);
         while ( (pr_default.getStatus(2) != 101) )
         {
            A1159LinSts = H004I4_A1159LinSts[0];
            A52LinCod = H004I4_A52LinCod[0];
            A1153LinDsc = H004I4_A1153LinDsc[0];
            AV11Combo_DataItem = new GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTComboData_Item(context);
            AV11Combo_DataItem.gxTpr_Id = StringUtil.Trim( StringUtil.Str( (decimal)(A52LinCod), 6, 0));
            AV11Combo_DataItem.gxTpr_Title = A1153LinDsc;
            AV24LinCod_Data.Add(AV11Combo_DataItem, 0);
            pr_default.readNext(2);
         }
         pr_default.close(2);
         Combo_lincod_Selectedvalue_set = ((0==AV23LinCod) ? "" : StringUtil.Trim( StringUtil.Str( (decimal)(AV23LinCod), 6, 0)));
         ucCombo_lincod.SendProperty(context, "", false, Combo_lincod_Internalname, "SelectedValue_set", Combo_lincod_Selectedvalue_set);
      }

      protected void S122( )
      {
         /* 'LOADCOMBOMOVCOD' Routine */
         returnInSub = false;
         /* Using cursor H004I5 */
         pr_default.execute(3);
         while ( (pr_default.getStatus(3) != 101) )
         {
            A1240MovSts = H004I5_A1240MovSts[0];
            A234MovCod = H004I5_A234MovCod[0];
            A1239MovDsc = H004I5_A1239MovDsc[0];
            AV11Combo_DataItem = new GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTComboData_Item(context);
            AV11Combo_DataItem.gxTpr_Id = StringUtil.Trim( StringUtil.Str( (decimal)(A234MovCod), 6, 0));
            AV11Combo_DataItem.gxTpr_Title = A1239MovDsc;
            AV26MovCod_Data.Add(AV11Combo_DataItem, 0);
            pr_default.readNext(3);
         }
         pr_default.close(3);
         Combo_movcod_Selectedvalue_set = ((0==AV25MovCod) ? "" : StringUtil.Trim( StringUtil.Str( (decimal)(AV25MovCod), 6, 0)));
         ucCombo_movcod.SendProperty(context, "", false, Combo_movcod_Internalname, "SelectedValue_set", Combo_movcod_Selectedvalue_set);
      }

      protected void S112( )
      {
         /* 'LOADCOMBOALMCOD' Routine */
         returnInSub = false;
         /* Using cursor H004I6 */
         pr_default.execute(4);
         while ( (pr_default.getStatus(4) != 101) )
         {
            A438AlmSts = H004I6_A438AlmSts[0];
            A63AlmCod = H004I6_A63AlmCod[0];
            A436AlmDsc = H004I6_A436AlmDsc[0];
            AV11Combo_DataItem = new GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTComboData_Item(context);
            AV11Combo_DataItem.gxTpr_Id = StringUtil.Trim( StringUtil.Str( (decimal)(A63AlmCod), 6, 0));
            AV11Combo_DataItem.gxTpr_Title = A436AlmDsc;
            AV6AlmCod_Data.Add(AV11Combo_DataItem, 0);
            pr_default.readNext(4);
         }
         pr_default.close(4);
         Combo_almcod_Selectedvalue_set = ((0==AV5AlmCod) ? "" : StringUtil.Trim( StringUtil.Str( (decimal)(AV5AlmCod), 6, 0)));
         ucCombo_almcod.SendProperty(context, "", false, Combo_almcod_Internalname, "SelectedValue_set", Combo_almcod_Selectedvalue_set);
      }

      protected void nextLoad( )
      {
      }

      protected void E164I2( )
      {
         /* Load Routine */
         returnInSub = false;
      }

      protected void wb_table1_64_4I2( bool wbgen )
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
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 68,'',false,'',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavProdcod_Internalname, StringUtil.RTrim( AV30ProdCod), StringUtil.RTrim( context.localUtil.Format( AV30ProdCod, "@!")), TempTags+" onchange=\""+"this.value=this.value.toUpperCase();"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"this.value=this.value.toUpperCase();"+";gx.evt.onblur(this,68);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavProdcod_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtavProdcod_Enabled, 0, "text", "", 15, "chr", 1, "row", 15, 0, 0, 0, 1, -1, -1, true, "", "left", true, "", "HLP_Almacen\\R_ResumenNotasEntradas.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "<td class='CellPaddingLeft10'>") ;
            /* Active images/pictures */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 70,'',false,'',0)\"";
            ClassString = "Image";
            StyleString = "";
            sImgUrl = (string)(context.GetImagePath( "f5b04895-0024-488b-8e3b-b687ca4598ee", "", context.GetTheme( )));
            GxWebStd.gx_bitmap( context, imgBtnbuscarpro_Internalname, sImgUrl, "", "", "", context.GetTheme( ), 1, 1, "", "Buscar Producto", 0, 0, 0, "px", 0, "px", 0, 0, 5, imgBtnbuscarpro_Jsonclick, "'"+""+"'"+",false,"+"'"+"E\\'DOBTNBUSCARPRO\\'."+"'", StyleString, ClassString, "", "", "", "", " "+"data-gx-image"+" "+TempTags, "", "", 1, false, false, context.GetImageSrcSet( sImgUrl), "HLP_Almacen\\R_ResumenNotasEntradas.htm");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "<td class='DataContentCell'>") ;
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "left", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavProddsc_Internalname, "Descripcion producto", "gx-form-item ReadonlyAttributeLabel", 0, true, "width: 25%;");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 73,'',false,'',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavProddsc_Internalname, StringUtil.RTrim( AV31ProdDsc), StringUtil.RTrim( context.localUtil.Format( AV31ProdDsc, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,73);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavProddsc_Jsonclick, 0, "ReadonlyAttribute", "", "", "", "", 1, edtavProddsc_Enabled, 0, "text", "", 80, "chr", 1, "row", 100, 0, 0, 0, 1, -1, -1, true, "", "left", true, "", "HLP_Almacen\\R_ResumenNotasEntradas.htm");
            /* Static images/pictures */
            ClassString = "gx-prompt Image";
            StyleString = "";
            sImgUrl = (string)(context.GetImagePath( "f5b04895-0024-488b-8e3b-b687ca4598ee", "", context.GetTheme( )));
            GxWebStd.gx_bitmap( context, imgprompt_Prodcod_Proddsc_Internalname, sImgUrl, imgprompt_Prodcod_Proddsc_Link, "", "", context.GetTheme( ), 1, 1, "", "", 0, 0, 0, "", 0, "", 0, 0, 0, "", "", StyleString, ClassString, "", "", "", "", "", "", "", 1, false, false, context.GetImageSrcSet( sImgUrl), "HLP_Almacen\\R_ResumenNotasEntradas.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "</tr>") ;
            /* End of table */
            context.WriteHtmlText( "</table>") ;
            wb_table1_64_4I2e( true) ;
         }
         else
         {
            wb_table1_64_4I2e( false) ;
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
         PA4I2( ) ;
         WS4I2( ) ;
         WE4I2( ) ;
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
            context.AddJavascriptSource(StringUtil.RTrim( ((string)Form.Jscriptsrc.Item(idxLst))), "?202281810311920", true, true);
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
         context.AddJavascriptSource("almacen/r_resumennotasentradas.js", "?202281810311920", false, true);
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
         context.AddJavascriptSource("Window/InNewWindowRender.js", "", false, true);
         /* End function include_jscripts */
      }

      protected void init_web_controls( )
      {
         radavValidar.Name = "vVALIDAR";
         radavValidar.WebTags = "";
         radavValidar.addItem("T", "Todos", 0);
         radavValidar.addItem("C", "Costo Cero", 0);
         radavValidar.addItem("S", "Solo con Costo", 0);
         radavTipo.Name = "vTIPO";
         radavTipo.WebTags = "";
         radavTipo.addItem("1", "Resumido", 0);
         radavTipo.addItem("2", "Detallado", 0);
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
         imgBtnbuscarpro_Internalname = "BTNBUSCARPRO";
         edtavProddsc_Internalname = "vPRODDSC";
         tblTablemergedprodcod_Internalname = "TABLEMERGEDPRODCOD";
         divTablesplittedprodcod_Internalname = "TABLESPLITTEDPRODCOD";
         lblTextblockvalidar_Internalname = "TEXTBLOCKVALIDAR";
         radavValidar_Internalname = "vVALIDAR";
         divUnnamedtablevalidar_Internalname = "UNNAMEDTABLEVALIDAR";
         lblTextblockfdesde_Internalname = "TEXTBLOCKFDESDE";
         edtavFdesde_Internalname = "vFDESDE";
         divUnnamedtablefdesde_Internalname = "UNNAMEDTABLEFDESDE";
         lblTextblockfhasta_Internalname = "TEXTBLOCKFHASTA";
         edtavFhasta_Internalname = "vFHASTA";
         divUnnamedtablefhasta_Internalname = "UNNAMEDTABLEFHASTA";
         lblTextblocktipo_Internalname = "TEXTBLOCKTIPO";
         radavTipo_Internalname = "vTIPO";
         divUnnamedtabletipo_Internalname = "UNNAMEDTABLETIPO";
         divPanel1_Internalname = "PANEL1";
         Dvpanel_panel1_Internalname = "DVPANEL_PANEL1";
         bttBtnbtnimprimir_Internalname = "BTNBTNIMPRIMIR";
         bttBtnbtnexcel_Internalname = "BTNBTNEXCEL";
         bttBtnbtnsalir_Internalname = "BTNBTNSALIR";
         Innewwindow_Internalname = "INNEWWINDOW";
         divTablecontent_Internalname = "TABLECONTENT";
         divTablemain_Internalname = "TABLEMAIN";
         edtavAlmcod_Internalname = "vALMCOD";
         edtavMovcod_Internalname = "vMOVCOD";
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
         edtavMovcod_Jsonclick = "";
         edtavMovcod_Visible = 1;
         edtavAlmcod_Jsonclick = "";
         edtavAlmcod_Visible = 1;
         radavTipo_Jsonclick = "";
         edtavFhasta_Jsonclick = "";
         edtavFhasta_Enabled = 1;
         edtavFdesde_Jsonclick = "";
         edtavFdesde_Enabled = 1;
         radavValidar_Jsonclick = "";
         Innewwindow_Target = "";
         Dvpanel_panel1_Autoscroll = Convert.ToBoolean( 0);
         Dvpanel_panel1_Iconposition = "Right";
         Dvpanel_panel1_Showcollapseicon = Convert.ToBoolean( 0);
         Dvpanel_panel1_Collapsed = Convert.ToBoolean( 0);
         Dvpanel_panel1_Collapsible = Convert.ToBoolean( -1);
         Dvpanel_panel1_Title = "Resumen de Notas Entradas";
         Dvpanel_panel1_Cls = "PanelFilled Panel_BaseColor";
         Dvpanel_panel1_Autoheight = Convert.ToBoolean( -1);
         Dvpanel_panel1_Autowidth = Convert.ToBoolean( 0);
         Dvpanel_panel1_Width = "100%";
         Combo_famcod_Cls = "ExtendedCombo AttributeRealWidth50With";
         Combo_sublcod_Cls = "ExtendedCombo AttributeRealWidth50With";
         Combo_lincod_Cls = "ExtendedCombo AttributeRealWidth50With";
         Combo_movcod_Cls = "ExtendedCombo AttributeRealWidth50With";
         Combo_almcod_Cls = "ExtendedCombo AttributeRealWidth50With";
         Form.Headerrawhtml = "";
         Form.Background = "";
         Form.Textcolor = 0;
         Form.Backcolor = (int)(0xFFFFFF);
         Form.Caption = "R_Resumen Notas Entradas";
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
         setEventMetadata("REFRESH","{handler:'Refresh',iparms:[{av:'radavValidar'},{av:'AV40Validar',fld:'vVALIDAR',pic:''},{av:'radavTipo'},{av:'AV37Tipo',fld:'vTIPO',pic:''}]");
         setEventMetadata("REFRESH",",oparms:[{av:'radavValidar'},{av:'AV40Validar',fld:'vVALIDAR',pic:''},{av:'radavTipo'},{av:'AV37Tipo',fld:'vTIPO',pic:''}]}");
         setEventMetadata("'DOBTNIMPRIMIR'","{handler:'E124I2',iparms:[{av:'AV25MovCod',fld:'vMOVCOD',pic:'ZZZZZ9'},{av:'AV23LinCod',fld:'vLINCOD',pic:'ZZZZZ9'},{av:'AV30ProdCod',fld:'vPRODCOD',pic:'@!'},{av:'AV18FDesde',fld:'vFDESDE',pic:''},{av:'AV22FHasta',fld:'vFHASTA',pic:''},{av:'AV5AlmCod',fld:'vALMCOD',pic:'ZZZZZ9'},{av:'AV33SubLCod',fld:'vSUBLCOD',pic:'ZZZZZ9'},{av:'AV16FamCod',fld:'vFAMCOD',pic:'ZZZZZ9'},{av:'radavValidar'},{av:'AV40Validar',fld:'vVALIDAR',pic:''},{av:'radavTipo'},{av:'AV37Tipo',fld:'vTIPO',pic:''}]");
         setEventMetadata("'DOBTNIMPRIMIR'",",oparms:[{av:'Innewwindow_Target',ctrl:'INNEWWINDOW',prop:'Target'},{av:'radavValidar'},{av:'AV40Validar',fld:'vVALIDAR',pic:''},{av:'radavTipo'},{av:'AV37Tipo',fld:'vTIPO',pic:''}]}");
         setEventMetadata("'DOBTNEXCEL'","{handler:'E134I2',iparms:[{av:'AV25MovCod',fld:'vMOVCOD',pic:'ZZZZZ9'},{av:'AV23LinCod',fld:'vLINCOD',pic:'ZZZZZ9'},{av:'AV30ProdCod',fld:'vPRODCOD',pic:'@!'},{av:'AV18FDesde',fld:'vFDESDE',pic:''},{av:'AV22FHasta',fld:'vFHASTA',pic:''},{av:'AV5AlmCod',fld:'vALMCOD',pic:'ZZZZZ9'},{av:'AV33SubLCod',fld:'vSUBLCOD',pic:'ZZZZZ9'},{av:'AV16FamCod',fld:'vFAMCOD',pic:'ZZZZZ9'},{av:'radavValidar'},{av:'AV40Validar',fld:'vVALIDAR',pic:''},{av:'radavTipo'},{av:'AV37Tipo',fld:'vTIPO',pic:''}]");
         setEventMetadata("'DOBTNEXCEL'",",oparms:[{av:'AV16FamCod',fld:'vFAMCOD',pic:'ZZZZZ9'},{av:'AV33SubLCod',fld:'vSUBLCOD',pic:'ZZZZZ9'},{av:'AV5AlmCod',fld:'vALMCOD',pic:'ZZZZZ9'},{av:'AV22FHasta',fld:'vFHASTA',pic:''},{av:'AV18FDesde',fld:'vFDESDE',pic:''},{av:'AV30ProdCod',fld:'vPRODCOD',pic:'@!'},{av:'AV23LinCod',fld:'vLINCOD',pic:'ZZZZZ9'},{av:'AV25MovCod',fld:'vMOVCOD',pic:'ZZZZZ9'},{av:'radavValidar'},{av:'AV40Validar',fld:'vVALIDAR',pic:''},{av:'radavTipo'},{av:'AV37Tipo',fld:'vTIPO',pic:''}]}");
         setEventMetadata("'DOBTNSALIR'","{handler:'E144I2',iparms:[{av:'radavValidar'},{av:'AV40Validar',fld:'vVALIDAR',pic:''},{av:'radavTipo'},{av:'AV37Tipo',fld:'vTIPO',pic:''}]");
         setEventMetadata("'DOBTNSALIR'",",oparms:[{av:'radavValidar'},{av:'AV40Validar',fld:'vVALIDAR',pic:''},{av:'radavTipo'},{av:'AV37Tipo',fld:'vTIPO',pic:''}]}");
         setEventMetadata("'DOBTNBUSCARPRO'","{handler:'E154I2',iparms:[{av:'radavValidar'},{av:'AV40Validar',fld:'vVALIDAR',pic:''},{av:'radavTipo'},{av:'AV37Tipo',fld:'vTIPO',pic:''}]");
         setEventMetadata("'DOBTNBUSCARPRO'",",oparms:[{av:'AV31ProdDsc',fld:'vPRODDSC',pic:''},{av:'AV30ProdCod',fld:'vPRODCOD',pic:'@!'},{av:'radavValidar'},{av:'AV40Validar',fld:'vVALIDAR',pic:''},{av:'radavTipo'},{av:'AV37Tipo',fld:'vTIPO',pic:''}]}");
         setEventMetadata("VALIDV_FDESDE","{handler:'Validv_Fdesde',iparms:[{av:'radavValidar'},{av:'AV40Validar',fld:'vVALIDAR',pic:''},{av:'radavTipo'},{av:'AV37Tipo',fld:'vTIPO',pic:''}]");
         setEventMetadata("VALIDV_FDESDE",",oparms:[{av:'radavValidar'},{av:'AV40Validar',fld:'vVALIDAR',pic:''},{av:'radavTipo'},{av:'AV37Tipo',fld:'vTIPO',pic:''}]}");
         setEventMetadata("VALIDV_FHASTA","{handler:'Validv_Fhasta',iparms:[{av:'radavValidar'},{av:'AV40Validar',fld:'vVALIDAR',pic:''},{av:'radavTipo'},{av:'AV37Tipo',fld:'vTIPO',pic:''}]");
         setEventMetadata("VALIDV_FHASTA",",oparms:[{av:'radavValidar'},{av:'AV40Validar',fld:'vVALIDAR',pic:''},{av:'radavTipo'},{av:'AV37Tipo',fld:'vTIPO',pic:''}]}");
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
         Combo_movcod_Selectedvalue_get = "";
         Combo_almcod_Selectedvalue_get = "";
         gxfirstwebparm = "";
         gxfirstwebparm_bkp = "";
         sDynURL = "";
         FormProcess = "";
         bodyStyle = "";
         GXKey = "";
         AV6AlmCod_Data = new GXBaseCollection<GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTComboData_Item>( context, "Item", "");
         AV26MovCod_Data = new GXBaseCollection<GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTComboData_Item>( context, "Item", "");
         AV24LinCod_Data = new GXBaseCollection<GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTComboData_Item>( context, "Item", "");
         AV34SubLCod_Data = new GXBaseCollection<GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTComboData_Item>( context, "Item", "");
         AV17FamCod_Data = new GXBaseCollection<GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTComboData_Item>( context, "Item", "");
         Combo_almcod_Selectedvalue_set = "";
         Combo_movcod_Selectedvalue_set = "";
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
         lblTextblockcombo_movcod_Jsonclick = "";
         ucCombo_movcod = new GXUserControl();
         Combo_movcod_Caption = "";
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
         lblTextblockvalidar_Jsonclick = "";
         TempTags = "";
         AV40Validar = "";
         lblTextblockfdesde_Jsonclick = "";
         AV18FDesde = DateTime.MinValue;
         lblTextblockfhasta_Jsonclick = "";
         AV22FHasta = DateTime.MinValue;
         lblTextblocktipo_Jsonclick = "";
         AV37Tipo = "";
         bttBtnbtnimprimir_Jsonclick = "";
         bttBtnbtnexcel_Jsonclick = "";
         bttBtnbtnsalir_Jsonclick = "";
         ucInnewwindow = new GXUserControl();
         sEvt = "";
         EvtGridId = "";
         EvtRowId = "";
         sEvtType = "";
         AV30ProdCod = "";
         AV31ProdDsc = "";
         AV36SubTotal = "";
         AV19Fecha = DateTime.MinValue;
         AV39URL = "";
         GXEncryptionTmp = "";
         AV15ExcelFilename = "";
         AV14ErrorMessage = "";
         scmdbuf = "";
         H004I2_A979FamSts = new short[1] ;
         H004I2_A50FamCod = new int[1] ;
         H004I2_A977FamDsc = new string[] {""} ;
         A977FamDsc = "";
         AV11Combo_DataItem = new GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTComboData_Item(context);
         H004I3_A1893SublSts = new short[1] ;
         H004I3_A51SublCod = new int[1] ;
         H004I3_A1892SublDsc = new string[] {""} ;
         A1892SublDsc = "";
         H004I4_A1159LinSts = new short[1] ;
         H004I4_A52LinCod = new int[1] ;
         H004I4_A1153LinDsc = new string[] {""} ;
         A1153LinDsc = "";
         H004I5_A1240MovSts = new short[1] ;
         H004I5_A234MovCod = new int[1] ;
         H004I5_A1239MovDsc = new string[] {""} ;
         A1239MovDsc = "";
         H004I6_A438AlmSts = new short[1] ;
         H004I6_A63AlmCod = new int[1] ;
         H004I6_A436AlmDsc = new string[] {""} ;
         A436AlmDsc = "";
         sStyleString = "";
         sImgUrl = "";
         imgBtnbuscarpro_Jsonclick = "";
         BackMsgLst = new msglist();
         LclMsgLst = new msglist();
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.almacen.r_resumennotasentradas__default(),
            new Object[][] {
                new Object[] {
               H004I2_A979FamSts, H004I2_A50FamCod, H004I2_A977FamDsc
               }
               , new Object[] {
               H004I3_A1893SublSts, H004I3_A51SublCod, H004I3_A1892SublDsc
               }
               , new Object[] {
               H004I4_A1159LinSts, H004I4_A52LinCod, H004I4_A1153LinDsc
               }
               , new Object[] {
               H004I5_A1240MovSts, H004I5_A234MovCod, H004I5_A1239MovDsc
               }
               , new Object[] {
               H004I6_A438AlmSts, H004I6_A63AlmCod, H004I6_A436AlmDsc
               }
            }
         );
         AV37Tipo = "T";
         AV22FHasta = DateTimeUtil.Today( context);
         AV18FDesde = DateTimeUtil.Today( context);
         AV36SubTotal = "N";
         /* GeneXus formulas. */
         context.Gx_err = 0;
         edtavProddsc_Enabled = 0;
         imgprompt_Prodcod_Proddsc_Link = "javascript:"+"gx.popup.openPrompt('"+"generales.wwbusquedaproducto.aspx"+"',["+"{Ctrl:gx.dom.el('"+"vPRODCOD"+"'), id:'"+"vPRODCOD"+"'"+",IOType:'out'}"+","+"{Ctrl:gx.dom.el('"+"vPRODDSC"+"'), id:'"+"vPRODDSC"+"'"+",IOType:'out'}"+","+""+"],"+"null"+","+"'', false"+","+"false"+");";
      }

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
      private short nDonePA ;
      private short AV38TipoOrden ;
      private short A979FamSts ;
      private short A1893SublSts ;
      private short A1159LinSts ;
      private short A1240MovSts ;
      private short A438AlmSts ;
      private short nGXWrapped ;
      private int edtavFdesde_Enabled ;
      private int edtavFhasta_Enabled ;
      private int AV5AlmCod ;
      private int edtavAlmcod_Visible ;
      private int AV25MovCod ;
      private int edtavMovcod_Visible ;
      private int AV23LinCod ;
      private int edtavLincod_Visible ;
      private int AV33SubLCod ;
      private int edtavSublcod_Visible ;
      private int AV16FamCod ;
      private int edtavFamcod_Visible ;
      private int edtavProddsc_Enabled ;
      private int A50FamCod ;
      private int A51SublCod ;
      private int A52LinCod ;
      private int A234MovCod ;
      private int A63AlmCod ;
      private int edtavProdcod_Enabled ;
      private int idxLst ;
      private string Combo_famcod_Selectedvalue_get ;
      private string Combo_sublcod_Selectedvalue_get ;
      private string Combo_lincod_Selectedvalue_get ;
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
      private string divTablesplittedmovcod_Internalname ;
      private string lblTextblockcombo_movcod_Internalname ;
      private string lblTextblockcombo_movcod_Jsonclick ;
      private string Combo_movcod_Caption ;
      private string Combo_movcod_Internalname ;
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
      private string divUnnamedtablevalidar_Internalname ;
      private string lblTextblockvalidar_Internalname ;
      private string lblTextblockvalidar_Jsonclick ;
      private string TempTags ;
      private string radavValidar_Internalname ;
      private string AV40Validar ;
      private string radavValidar_Jsonclick ;
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
      private string divUnnamedtabletipo_Internalname ;
      private string lblTextblocktipo_Internalname ;
      private string lblTextblocktipo_Jsonclick ;
      private string radavTipo_Internalname ;
      private string radavTipo_Jsonclick ;
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
      private string AV30ProdCod ;
      private string AV31ProdDsc ;
      private string GXEncryptionTmp ;
      private string scmdbuf ;
      private string A977FamDsc ;
      private string A1892SublDsc ;
      private string A1153LinDsc ;
      private string A1239MovDsc ;
      private string A436AlmDsc ;
      private string sStyleString ;
      private string tblTablemergedprodcod_Internalname ;
      private string edtavProdcod_Jsonclick ;
      private string sImgUrl ;
      private string imgBtnbuscarpro_Internalname ;
      private string imgBtnbuscarpro_Jsonclick ;
      private string edtavProddsc_Jsonclick ;
      private string imgprompt_Prodcod_Proddsc_Internalname ;
      private DateTime AV18FDesde ;
      private DateTime AV22FHasta ;
      private DateTime AV19Fecha ;
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
      private string AV37Tipo ;
      private string AV36SubTotal ;
      private string AV39URL ;
      private string AV15ExcelFilename ;
      private string AV14ErrorMessage ;
      private GXUserControl ucDvpanel_panel1 ;
      private GXUserControl ucCombo_almcod ;
      private GXUserControl ucCombo_movcod ;
      private GXUserControl ucCombo_lincod ;
      private GXUserControl ucCombo_sublcod ;
      private GXUserControl ucCombo_famcod ;
      private GXUserControl ucInnewwindow ;
      private IGxDataStore dsDataStore2 ;
      private IGxDataStore dsDefault ;
      private GXRadio radavValidar ;
      private GXRadio radavTipo ;
      private IDataStoreProvider pr_default ;
      private short[] H004I2_A979FamSts ;
      private int[] H004I2_A50FamCod ;
      private string[] H004I2_A977FamDsc ;
      private short[] H004I3_A1893SublSts ;
      private int[] H004I3_A51SublCod ;
      private string[] H004I3_A1892SublDsc ;
      private short[] H004I4_A1159LinSts ;
      private int[] H004I4_A52LinCod ;
      private string[] H004I4_A1153LinDsc ;
      private short[] H004I5_A1240MovSts ;
      private int[] H004I5_A234MovCod ;
      private string[] H004I5_A1239MovDsc ;
      private short[] H004I6_A438AlmSts ;
      private int[] H004I6_A63AlmCod ;
      private string[] H004I6_A436AlmDsc ;
      private msglist BackMsgLst ;
      private msglist LclMsgLst ;
      private GXBaseCollection<GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTComboData_Item> AV6AlmCod_Data ;
      private GXBaseCollection<GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTComboData_Item> AV26MovCod_Data ;
      private GXBaseCollection<GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTComboData_Item> AV24LinCod_Data ;
      private GXBaseCollection<GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTComboData_Item> AV34SubLCod_Data ;
      private GXBaseCollection<GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTComboData_Item> AV17FamCod_Data ;
      private GXWebForm Form ;
      private GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTComboData_Item AV11Combo_DataItem ;
   }

   public class r_resumennotasentradas__default : DataStoreHelperBase, IDataStoreHelper
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
       };
    }

    private static CursorDef[] def;
    private void cursorDefinitions( )
    {
       if ( def == null )
       {
          Object[] prmH004I2;
          prmH004I2 = new Object[] {
          };
          Object[] prmH004I3;
          prmH004I3 = new Object[] {
          };
          Object[] prmH004I4;
          prmH004I4 = new Object[] {
          };
          Object[] prmH004I5;
          prmH004I5 = new Object[] {
          };
          Object[] prmH004I6;
          prmH004I6 = new Object[] {
          };
          def= new CursorDef[] {
              new CursorDef("H004I2", "SELECT [FamSts], [FamCod], [FamDsc] FROM [CFAMILIA] WHERE [FamSts] = 1 ORDER BY [FamDsc] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH004I2,100, GxCacheFrequency.OFF ,false,false )
             ,new CursorDef("H004I3", "SELECT [SublSts], [SublCod], [SublDsc] FROM [CSUBLPROD] WHERE [SublSts] = 1 ORDER BY [SublDsc] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH004I3,100, GxCacheFrequency.OFF ,false,false )
             ,new CursorDef("H004I4", "SELECT [LinSts], [LinCod], [LinDsc] FROM [CLINEAPROD] WHERE [LinSts] = 1 ORDER BY [LinDsc] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH004I4,100, GxCacheFrequency.OFF ,false,false )
             ,new CursorDef("H004I5", "SELECT [MovSts], [MovCod], [MovDsc] FROM [CMOVALMACEN] WHERE [MovSts] = 1 ORDER BY [MovDsc] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH004I5,100, GxCacheFrequency.OFF ,false,false )
             ,new CursorDef("H004I6", "SELECT [AlmSts], [AlmCod], [AlmDsc] FROM [CALMACEN] WHERE [AlmSts] = 1 ORDER BY [AlmDsc] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH004I6,100, GxCacheFrequency.OFF ,false,false )
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
       }
    }

 }

}
