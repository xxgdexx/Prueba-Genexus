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
   public class r_antiguedadsaldos : GXDataArea
   {
      public r_antiguedadsaldos( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDataStore2 = context.GetDataStore("DataStore2");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusTheme");
      }

      public r_antiguedadsaldos( IGxContext context )
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
         chkavFlag2 = new GXCheckbox();
         radavFlag = new GXRadio();
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
         PA5E2( ) ;
         gxajaxcallmode = (short)((isAjaxCallMode( ) ? 1 : 0));
         if ( ( gxajaxcallmode == 0 ) && ( GxWebError == 0 ) )
         {
            START5E2( ) ;
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
         context.AddJavascriptSource("gxcfg.js", "?20228181031399", false, true);
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
         context.WriteHtmlTextNl( "<form id=\"MAINFORM\" autocomplete=\"off\" name=\"MAINFORM\" method=\"post\" tabindex=-1  class=\"form-horizontal Form\" data-gx-class=\"form-horizontal Form\" novalidate action=\""+formatLink("ventas.r_antiguedadsaldos.aspx") +"\">") ;
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
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "vVENCOD_DATA", AV50VenCod_Data);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt("vVENCOD_DATA", AV50VenCod_Data);
         }
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "vTIPCOD_DATA", AV44TipCod_Data);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt("vTIPCOD_DATA", AV44TipCod_Data);
         }
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "vZONCOD_DATA", AV52ZonCod_Data);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt("vZONCOD_DATA", AV52ZonCod_Data);
         }
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "vTIPCCOD_DATA", AV42TipCCod_Data);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt("vTIPCCOD_DATA", AV42TipCCod_Data);
         }
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "vMONCOD_DATA", AV31MonCod_Data);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt("vMONCOD_DATA", AV31MonCod_Data);
         }
         GxWebStd.gx_hidden_field( context, "vFHASTA", context.localUtil.DToC( AV22FHasta, 0, "/"));
         GxWebStd.gx_hidden_field( context, "vSERIE", StringUtil.RTrim( AV37Serie));
         GxWebStd.gx_hidden_field( context, "vTIPLETRAS", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV46TipLetras), 1, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "COMBO_VENCOD_Cls", StringUtil.RTrim( Combo_vencod_Cls));
         GxWebStd.gx_hidden_field( context, "COMBO_VENCOD_Selectedvalue_set", StringUtil.RTrim( Combo_vencod_Selectedvalue_set));
         GxWebStd.gx_hidden_field( context, "COMBO_TIPCOD_Cls", StringUtil.RTrim( Combo_tipcod_Cls));
         GxWebStd.gx_hidden_field( context, "COMBO_TIPCOD_Selectedvalue_set", StringUtil.RTrim( Combo_tipcod_Selectedvalue_set));
         GxWebStd.gx_hidden_field( context, "COMBO_ZONCOD_Cls", StringUtil.RTrim( Combo_zoncod_Cls));
         GxWebStd.gx_hidden_field( context, "COMBO_ZONCOD_Selectedvalue_set", StringUtil.RTrim( Combo_zoncod_Selectedvalue_set));
         GxWebStd.gx_hidden_field( context, "COMBO_TIPCCOD_Cls", StringUtil.RTrim( Combo_tipccod_Cls));
         GxWebStd.gx_hidden_field( context, "COMBO_TIPCCOD_Selectedvalue_set", StringUtil.RTrim( Combo_tipccod_Selectedvalue_set));
         GxWebStd.gx_hidden_field( context, "COMBO_MONCOD_Cls", StringUtil.RTrim( Combo_moncod_Cls));
         GxWebStd.gx_hidden_field( context, "COMBO_MONCOD_Selectedvalue_set", StringUtil.RTrim( Combo_moncod_Selectedvalue_set));
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
         GxWebStd.gx_hidden_field( context, "COMBO_MONCOD_Selectedvalue_get", StringUtil.RTrim( Combo_moncod_Selectedvalue_get));
         GxWebStd.gx_hidden_field( context, "COMBO_TIPCCOD_Selectedvalue_get", StringUtil.RTrim( Combo_tipccod_Selectedvalue_get));
         GxWebStd.gx_hidden_field( context, "COMBO_ZONCOD_Selectedvalue_get", StringUtil.RTrim( Combo_zoncod_Selectedvalue_get));
         GxWebStd.gx_hidden_field( context, "COMBO_TIPCOD_Selectedvalue_get", StringUtil.RTrim( Combo_tipcod_Selectedvalue_get));
         GxWebStd.gx_hidden_field( context, "COMBO_VENCOD_Selectedvalue_get", StringUtil.RTrim( Combo_vencod_Selectedvalue_get));
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
            WE5E2( ) ;
            context.WriteHtmlText( "</div>") ;
         }
      }

      public override void DispatchEvents( )
      {
         EVT5E2( ) ;
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
         return formatLink("ventas.r_antiguedadsaldos.aspx")  ;
      }

      public override string GetPgmname( )
      {
         return "Ventas.R_AntiguedadSaldos" ;
      }

      public override string GetPgmdesc( )
      {
         return "Antiguedad de Saldos" ;
      }

      protected void WB5E0( )
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
            GxWebStd.gx_div_start( context, divTablesplittedvencod_Internalname, 1, 0, "px", 0, "px", "Table", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-6 MergeLabelCell CellWidth_12_5", "left", "top", "", "", "div");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblTextblockcombo_vencod_Internalname, "Vendedor", "", "", lblTextblockcombo_vencod_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "Label", 0, "", 1, 1, 0, 0, "HLP_Ventas\\R_AntiguedadSaldos.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-6 CellWidth_87_5", "left", "top", "", "", "div");
            /* User Defined Control */
            ucCombo_vencod.SetProperty("Caption", Combo_vencod_Caption);
            ucCombo_vencod.SetProperty("Cls", Combo_vencod_Cls);
            ucCombo_vencod.SetProperty("DropDownOptionsData", AV50VenCod_Data);
            ucCombo_vencod.Render(context, "dvelop.gxbootstrap.ddoextendedcombo", Combo_vencod_Internalname, "COMBO_VENCODContainer");
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
            GxWebStd.gx_div_start( context, divTablesplittedtipcod_Internalname, 1, 0, "px", 0, "px", "Table", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-6 MergeLabelCell CellWidth_12_5", "left", "top", "", "", "div");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblTextblockcombo_tipcod_Internalname, "Tpo Documentos", "", "", lblTextblockcombo_tipcod_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "Label", 0, "", 1, 1, 0, 0, "HLP_Ventas\\R_AntiguedadSaldos.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-6 CellWidth_87_5", "left", "top", "", "", "div");
            /* User Defined Control */
            ucCombo_tipcod.SetProperty("Caption", Combo_tipcod_Caption);
            ucCombo_tipcod.SetProperty("Cls", Combo_tipcod_Cls);
            ucCombo_tipcod.SetProperty("DropDownOptionsData", AV44TipCod_Data);
            ucCombo_tipcod.Render(context, "dvelop.gxbootstrap.ddoextendedcombo", Combo_tipcod_Internalname, "COMBO_TIPCODContainer");
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
            GxWebStd.gx_label_ctrl( context, lblTextblockcombo_zoncod_Internalname, "Zonas", "", "", lblTextblockcombo_zoncod_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "Label", 0, "", 1, 1, 0, 0, "HLP_Ventas\\R_AntiguedadSaldos.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-6 CellWidth_87_5", "left", "top", "", "", "div");
            /* User Defined Control */
            ucCombo_zoncod.SetProperty("Caption", Combo_zoncod_Caption);
            ucCombo_zoncod.SetProperty("Cls", Combo_zoncod_Cls);
            ucCombo_zoncod.SetProperty("DropDownOptionsData", AV52ZonCod_Data);
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
            GxWebStd.gx_div_start( context, divTablesplittedtipccod_Internalname, 1, 0, "px", 0, "px", "Table", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-6 MergeLabelCell CellWidth_12_5", "left", "top", "", "", "div");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblTextblockcombo_tipccod_Internalname, "Tipo Cliente", "", "", lblTextblockcombo_tipccod_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "Label", 0, "", 1, 1, 0, 0, "HLP_Ventas\\R_AntiguedadSaldos.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-6 CellWidth_87_5", "left", "top", "", "", "div");
            /* User Defined Control */
            ucCombo_tipccod.SetProperty("Caption", Combo_tipccod_Caption);
            ucCombo_tipccod.SetProperty("Cls", Combo_tipccod_Cls);
            ucCombo_tipccod.SetProperty("DropDownOptionsData", AV42TipCCod_Data);
            ucCombo_tipccod.Render(context, "dvelop.gxbootstrap.ddoextendedcombo", Combo_tipccod_Internalname, "COMBO_TIPCCODContainer");
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
            GxWebStd.gx_label_ctrl( context, lblTextblockclicod_Internalname, "Cliente", "", "", lblTextblockclicod_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "Label", 0, "", 1, 1, 0, 0, "HLP_Ventas\\R_AntiguedadSaldos.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-6 CellWidth_87_5", "left", "top", "", "", "div");
            wb_table1_57_5E2( true) ;
         }
         else
         {
            wb_table1_57_5E2( false) ;
         }
         return  ;
      }

      protected void wb_table1_57_5E2e( bool wbgen )
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
            GxWebStd.gx_div_start( context, divTablesplittedmoncod_Internalname, 1, 0, "px", 0, "px", "Table", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-6 MergeLabelCell CellWidth_12_5", "left", "top", "", "", "div");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblTextblockcombo_moncod_Internalname, "Moneda", "", "", lblTextblockcombo_moncod_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "Label", 0, "", 1, 1, 0, 0, "HLP_Ventas\\R_AntiguedadSaldos.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-6 CellWidth_87_5", "left", "top", "", "", "div");
            /* User Defined Control */
            ucCombo_moncod.SetProperty("Caption", Combo_moncod_Caption);
            ucCombo_moncod.SetProperty("Cls", Combo_moncod_Cls);
            ucCombo_moncod.SetProperty("DropDownOptionsData", AV31MonCod_Data);
            ucCombo_moncod.Render(context, "dvelop.gxbootstrap.ddoextendedcombo", Combo_moncod_Internalname, "COMBO_MONCODContainer");
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
            GxWebStd.gx_div_start( context, divUnnamedtableflag2_Internalname, 1, 0, "px", 0, "px", "Table", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-6 MergeLabelCell CellWidth_12_5", "left", "top", "", "", "div");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblTextblockflag2_Internalname, "Agrupa Cliente", "", "", lblTextblockflag2_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "Label", 0, "", 1, 1, 0, 0, "HLP_Ventas\\R_AntiguedadSaldos.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-6 CellWidth_87_5", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "left", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, chkavFlag2_Internalname, "Flag2", "col-sm-3 AttributeCheckBoxLabel", 0, true, "");
            /* Check box */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 83,'',false,'',0)\"";
            ClassString = "AttributeCheckBox";
            StyleString = "";
            GxWebStd.gx_checkbox_ctrl( context, chkavFlag2_Internalname, StringUtil.Str( (decimal)(AV53Flag2), 1, 0), "", "Flag2", 1, chkavFlag2.Enabled, "1", "¿Desea Agrupar por Cliente?", StyleString, ClassString, "", "", TempTags+" onclick="+"\"gx.fn.checkboxClick(83, this, 1, 0,"+"''"+");"+"gx.evt.onchange(this, event);\""+" onblur=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onblur(this,83);\"");
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
            GxWebStd.gx_div_start( context, divUnnamedtableflag_Internalname, 1, 0, "px", 0, "px", "Table", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-6 MergeLabelCell CellWidth_12_5", "left", "top", "", "", "div");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblTextblockflag_Internalname, "Periodo", "", "", lblTextblockflag_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "Label", 0, "", 1, 1, 0, 0, "HLP_Ventas\\R_AntiguedadSaldos.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-6 CellWidth_87_5", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "left", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, "", "Flag", "col-sm-3 AttributeCheckBoxLabel", 0, true, "");
            /* Radio button */
            ClassString = "AttributeCheckBox";
            StyleString = "";
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 92,'',false,'',0)\"";
            GxWebStd.gx_radio_ctrl( context, radavFlag, radavFlag_Internalname, StringUtil.Str( (decimal)(AV23Flag), 1, 0), "", 1, 1, 0, 0, StyleString, ClassString, "", "", 0, radavFlag_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", TempTags+" onclick="+"\""+"gx.evt.onchange(this, event);\""+" onblur=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onblur(this,92);\"", "HLP_Ventas\\R_AntiguedadSaldos.htm");
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
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 97,'',false,'',0)\"";
            ClassString = "ButtonPDF";
            StyleString = "";
            GxWebStd.gx_button_ctrl( context, bttBtnbtnimprimir_Internalname, "", "Imprimir", bttBtnbtnimprimir_Jsonclick, 5, "Imprimir", "", StyleString, ClassString, 1, 1, "standard", "'"+""+"'"+",false,"+"'"+"E\\'DOBTNIMPRIMIR\\'."+"'", TempTags, "", context.GetButtonType( ), "HLP_Ventas\\R_AntiguedadSaldos.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "left", "top", "", "", "div");
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 99,'',false,'',0)\"";
            ClassString = "ButtonColor";
            StyleString = "";
            GxWebStd.gx_button_ctrl( context, bttBtnbtnsalir_Internalname, "", "Salir", bttBtnbtnsalir_Jsonclick, 5, "Imprimir PDF", "", StyleString, ClassString, 1, 1, "standard", "'"+""+"'"+",false,"+"'"+"E\\'DOBTNSALIR\\'."+"'", TempTags, "", context.GetButtonType( ), "HLP_Ventas\\R_AntiguedadSaldos.htm");
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
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 106,'',false,'',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavVencod_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(AV49VenCod), 6, 0, ".", "")), StringUtil.LTrim( context.localUtil.Format( (decimal)(AV49VenCod), "ZZZZZ9")), " inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onblur(this,106);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavVencod_Jsonclick, 0, "Attribute", "", "", "", "", edtavVencod_Visible, 1, 0, "text", "1", 6, "chr", 1, "row", 6, 0, 0, 0, 1, -1, 0, true, "", "right", false, "", "HLP_Ventas\\R_AntiguedadSaldos.htm");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 107,'',false,'',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavTipcod_Internalname, StringUtil.RTrim( AV43TipCod), StringUtil.RTrim( context.localUtil.Format( AV43TipCod, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,107);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavTipcod_Jsonclick, 0, "Attribute", "", "", "", "", edtavTipcod_Visible, 1, 0, "text", "", 3, "chr", 1, "row", 3, 0, 0, 0, 1, -1, -1, true, "", "left", true, "", "HLP_Ventas\\R_AntiguedadSaldos.htm");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 108,'',false,'',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavZoncod_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(AV51ZonCod), 6, 0, ".", "")), StringUtil.LTrim( context.localUtil.Format( (decimal)(AV51ZonCod), "ZZZZZ9")), " inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onblur(this,108);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavZoncod_Jsonclick, 0, "Attribute", "", "", "", "", edtavZoncod_Visible, 1, 0, "text", "1", 6, "chr", 1, "row", 6, 0, 0, 0, 1, -1, 0, true, "", "right", false, "", "HLP_Ventas\\R_AntiguedadSaldos.htm");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 109,'',false,'',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavTipccod_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(AV41TipCCod), 6, 0, ".", "")), StringUtil.LTrim( context.localUtil.Format( (decimal)(AV41TipCCod), "ZZZZZ9")), " inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onblur(this,109);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavTipccod_Jsonclick, 0, "Attribute", "", "", "", "", edtavTipccod_Visible, 1, 0, "text", "1", 6, "chr", 1, "row", 6, 0, 0, 0, 1, -1, 0, true, "", "right", false, "", "HLP_Ventas\\R_AntiguedadSaldos.htm");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 110,'',false,'',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavMoncod_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(AV30MonCod), 6, 0, ".", "")), StringUtil.LTrim( context.localUtil.Format( (decimal)(AV30MonCod), "ZZZZZ9")), " inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onblur(this,110);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavMoncod_Jsonclick, 0, "Attribute", "", "", "", "", edtavMoncod_Visible, 1, 0, "text", "1", 6, "chr", 1, "row", 6, 0, 0, 0, 1, -1, 0, true, "", "right", false, "", "HLP_Ventas\\R_AntiguedadSaldos.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
         }
         wbLoad = true;
      }

      protected void START5E2( )
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
            Form.Meta.addItem("description", "Antiguedad de Saldos", 0) ;
         }
         context.wjLoc = "";
         context.nUserReturn = 0;
         context.wbHandled = 0;
         if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
         {
         }
         wbErr = false;
         STRUP5E0( ) ;
      }

      protected void WS5E2( )
      {
         START5E2( ) ;
         EVT5E2( ) ;
      }

      protected void EVT5E2( )
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
                              E115E2 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "'DOBTNIMPRIMIR'") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              /* Execute user event: 'DoBtnImprimir' */
                              E125E2 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "'DOBTNSALIR'") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              /* Execute user event: 'DoBtnSalir' */
                              E135E2 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "'DOBTNEXCEL'") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              /* Execute user event: 'DoBtnExcel' */
                              E145E2 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "LOAD") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              /* Execute user event: Load */
                              E155E2 ();
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

      protected void WE5E2( )
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

      protected void PA5E2( )
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
         AV53Flag2 = (short)(((StringUtil.StrCmp(StringUtil.LTrim( StringUtil.NToC( (decimal)(AV53Flag2), 1, 0, ".", "")), "1")==0) ? 1 : 0));
         AssignAttri("", false, "AV53Flag2", StringUtil.Str( (decimal)(AV53Flag2), 1, 0));
         AV23Flag = (short)(context.localUtil.CToN( StringUtil.LTrim( StringUtil.NToC( (decimal)(AV23Flag), 1, 0, ".", "")), ".", ","));
         AssignAttri("", false, "AV23Flag", StringUtil.Str( (decimal)(AV23Flag), 1, 0));
      }

      public void Refresh( )
      {
         send_integrity_hashes( ) ;
         RF5E2( ) ;
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
      }

      protected void RF5E2( )
      {
         initialize_formulas( ) ;
         clear_multi_value_controls( ) ;
         gxdyncontrolsrefreshing = true;
         fix_multi_value_controls( ) ;
         gxdyncontrolsrefreshing = false;
         if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
         {
            /* Execute user event: Load */
            E155E2 ();
            WB5E0( ) ;
         }
      }

      protected void send_integrity_lvl_hashes5E2( )
      {
      }

      protected void before_start_formulas( )
      {
         context.Gx_err = 0;
         edtavClidsc_Enabled = 0;
         AssignProp("", false, edtavClidsc_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavClidsc_Enabled), 5, 0), true);
         fix_multi_value_controls( ) ;
      }

      protected void STRUP5E0( )
      {
         /* Before Start, stand alone formulas. */
         before_start_formulas( ) ;
         /* Execute Start event if defined. */
         context.wbGlbDoneStart = 0;
         /* Execute user event: Start */
         E115E2 ();
         context.wbGlbDoneStart = 1;
         /* After Start, stand alone formulas. */
         if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
         {
            /* Read saved SDTs. */
            ajax_req_read_hidden_sdt(cgiGet( "vVENCOD_DATA"), AV50VenCod_Data);
            ajax_req_read_hidden_sdt(cgiGet( "vTIPCOD_DATA"), AV44TipCod_Data);
            ajax_req_read_hidden_sdt(cgiGet( "vZONCOD_DATA"), AV52ZonCod_Data);
            ajax_req_read_hidden_sdt(cgiGet( "vTIPCCOD_DATA"), AV42TipCCod_Data);
            ajax_req_read_hidden_sdt(cgiGet( "vMONCOD_DATA"), AV31MonCod_Data);
            /* Read saved values. */
            Combo_vencod_Cls = cgiGet( "COMBO_VENCOD_Cls");
            Combo_vencod_Selectedvalue_set = cgiGet( "COMBO_VENCOD_Selectedvalue_set");
            Combo_tipcod_Cls = cgiGet( "COMBO_TIPCOD_Cls");
            Combo_tipcod_Selectedvalue_set = cgiGet( "COMBO_TIPCOD_Selectedvalue_set");
            Combo_zoncod_Cls = cgiGet( "COMBO_ZONCOD_Cls");
            Combo_zoncod_Selectedvalue_set = cgiGet( "COMBO_ZONCOD_Selectedvalue_set");
            Combo_tipccod_Cls = cgiGet( "COMBO_TIPCCOD_Cls");
            Combo_tipccod_Selectedvalue_set = cgiGet( "COMBO_TIPCCOD_Selectedvalue_set");
            Combo_moncod_Cls = cgiGet( "COMBO_MONCOD_Cls");
            Combo_moncod_Selectedvalue_set = cgiGet( "COMBO_MONCOD_Selectedvalue_set");
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
            AV6CliCod = cgiGet( edtavClicod_Internalname);
            AssignAttri("", false, "AV6CliCod", AV6CliCod);
            AV8CliDsc = cgiGet( edtavClidsc_Internalname);
            AssignAttri("", false, "AV8CliDsc", AV8CliDsc);
            if ( ( ( ((StringUtil.StrCmp(cgiGet( chkavFlag2_Internalname), "1")==0) ? 1 : 0) < 0 ) ) || ( ( ((StringUtil.StrCmp(cgiGet( chkavFlag2_Internalname), "1")==0) ? 1 : 0) > 9 ) ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "vFLAG2");
               GX_FocusControl = chkavFlag2_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               AV53Flag2 = 0;
               AssignAttri("", false, "AV53Flag2", StringUtil.Str( (decimal)(AV53Flag2), 1, 0));
            }
            else
            {
               AV53Flag2 = (short)(((StringUtil.StrCmp(cgiGet( chkavFlag2_Internalname), "1")==0) ? 1 : 0));
               AssignAttri("", false, "AV53Flag2", StringUtil.Str( (decimal)(AV53Flag2), 1, 0));
            }
            if ( ( ( context.localUtil.CToN( cgiGet( radavFlag_Internalname), ".", ",") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( radavFlag_Internalname), ".", ",") > Convert.ToDecimal( 9 )) ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "vFLAG");
               wbErr = true;
               AV23Flag = 0;
               AssignAttri("", false, "AV23Flag", StringUtil.Str( (decimal)(AV23Flag), 1, 0));
            }
            else
            {
               AV23Flag = (short)(context.localUtil.CToN( cgiGet( radavFlag_Internalname), ".", ","));
               AssignAttri("", false, "AV23Flag", StringUtil.Str( (decimal)(AV23Flag), 1, 0));
            }
            if ( ( ( context.localUtil.CToN( cgiGet( edtavVencod_Internalname), ".", ",") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtavVencod_Internalname), ".", ",") > Convert.ToDecimal( 999999 )) ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "vVENCOD");
               GX_FocusControl = edtavVencod_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               AV49VenCod = 0;
               AssignAttri("", false, "AV49VenCod", StringUtil.LTrimStr( (decimal)(AV49VenCod), 6, 0));
            }
            else
            {
               AV49VenCod = (int)(context.localUtil.CToN( cgiGet( edtavVencod_Internalname), ".", ","));
               AssignAttri("", false, "AV49VenCod", StringUtil.LTrimStr( (decimal)(AV49VenCod), 6, 0));
            }
            AV43TipCod = cgiGet( edtavTipcod_Internalname);
            AssignAttri("", false, "AV43TipCod", AV43TipCod);
            if ( ( ( context.localUtil.CToN( cgiGet( edtavZoncod_Internalname), ".", ",") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtavZoncod_Internalname), ".", ",") > Convert.ToDecimal( 999999 )) ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "vZONCOD");
               GX_FocusControl = edtavZoncod_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               AV51ZonCod = 0;
               AssignAttri("", false, "AV51ZonCod", StringUtil.LTrimStr( (decimal)(AV51ZonCod), 6, 0));
            }
            else
            {
               AV51ZonCod = (int)(context.localUtil.CToN( cgiGet( edtavZoncod_Internalname), ".", ","));
               AssignAttri("", false, "AV51ZonCod", StringUtil.LTrimStr( (decimal)(AV51ZonCod), 6, 0));
            }
            if ( ( ( context.localUtil.CToN( cgiGet( edtavTipccod_Internalname), ".", ",") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtavTipccod_Internalname), ".", ",") > Convert.ToDecimal( 999999 )) ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "vTIPCCOD");
               GX_FocusControl = edtavTipccod_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               AV41TipCCod = 0;
               AssignAttri("", false, "AV41TipCCod", StringUtil.LTrimStr( (decimal)(AV41TipCCod), 6, 0));
            }
            else
            {
               AV41TipCCod = (int)(context.localUtil.CToN( cgiGet( edtavTipccod_Internalname), ".", ","));
               AssignAttri("", false, "AV41TipCCod", StringUtil.LTrimStr( (decimal)(AV41TipCCod), 6, 0));
            }
            if ( ( ( context.localUtil.CToN( cgiGet( edtavMoncod_Internalname), ".", ",") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtavMoncod_Internalname), ".", ",") > Convert.ToDecimal( 999999 )) ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "vMONCOD");
               GX_FocusControl = edtavMoncod_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               AV30MonCod = 0;
               AssignAttri("", false, "AV30MonCod", StringUtil.LTrimStr( (decimal)(AV30MonCod), 6, 0));
            }
            else
            {
               AV30MonCod = (int)(context.localUtil.CToN( cgiGet( edtavMoncod_Internalname), ".", ","));
               AssignAttri("", false, "AV30MonCod", StringUtil.LTrimStr( (decimal)(AV30MonCod), 6, 0));
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
         E115E2 ();
         if (returnInSub) return;
      }

      protected void E115E2( )
      {
         /* Start Routine */
         returnInSub = false;
         edtavMoncod_Visible = 0;
         AssignProp("", false, edtavMoncod_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavMoncod_Visible), 5, 0), true);
         edtavTipccod_Visible = 0;
         AssignProp("", false, edtavTipccod_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavTipccod_Visible), 5, 0), true);
         edtavZoncod_Visible = 0;
         AssignProp("", false, edtavZoncod_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavZoncod_Visible), 5, 0), true);
         edtavTipcod_Visible = 0;
         AssignProp("", false, edtavTipcod_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavTipcod_Visible), 5, 0), true);
         edtavVencod_Visible = 0;
         AssignProp("", false, edtavVencod_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavVencod_Visible), 5, 0), true);
         /* Execute user subroutine: 'LOADCOMBOVENCOD' */
         S112 ();
         if (returnInSub) return;
         /* Execute user subroutine: 'LOADCOMBOTIPCOD' */
         S122 ();
         if (returnInSub) return;
         /* Execute user subroutine: 'LOADCOMBOZONCOD' */
         S132 ();
         if (returnInSub) return;
         /* Execute user subroutine: 'LOADCOMBOTIPCCOD' */
         S142 ();
         if (returnInSub) return;
         /* Execute user subroutine: 'LOADCOMBOMONCOD' */
         S152 ();
         if (returnInSub) return;
         AV23Flag = 1;
         AssignAttri("", false, "AV23Flag", StringUtil.Str( (decimal)(AV23Flag), 1, 0));
      }

      protected void E125E2( )
      {
         /* 'DoBtnImprimir' Routine */
         returnInSub = false;
         GXKey = Crypto.GetSiteKey( );
         GXEncryptionTmp = "rreporteantiguedadsaldos.aspx"+UrlEncode(StringUtil.LTrimStr(AV49VenCod,6,0)) + "," + UrlEncode(StringUtil.RTrim(AV43TipCod)) + "," + UrlEncode(StringUtil.LTrimStr(AV51ZonCod,6,0)) + "," + UrlEncode(StringUtil.LTrimStr(AV41TipCCod,6,0)) + "," + UrlEncode(StringUtil.RTrim(AV6CliCod)) + "," + UrlEncode(StringUtil.LTrimStr(AV30MonCod,6,0)) + "," + UrlEncode(StringUtil.LTrimStr(AV23Flag,1,0)) + "," + UrlEncode(StringUtil.LTrimStr(AV53Flag2,1,0));
         Innewwindow_Target = formatLink("rreporteantiguedadsaldos.aspx") + "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey);
         ucInnewwindow.SendProperty(context, "", false, Innewwindow_Internalname, "Target", Innewwindow_Target);
         this.executeUsercontrolMethod("", false, "INNEWWINDOWContainer", "OpenWindow", "", new Object[] {});
         /*  Sending Event outputs  */
      }

      protected void E135E2( )
      {
         /* 'DoBtnSalir' Routine */
         returnInSub = false;
         CallWebObject(formatLink("wwpbaseobjects.home.aspx") );
         context.wjLocDisableFrm = 1;
      }

      protected void S152( )
      {
         /* 'LOADCOMBOMONCOD' Routine */
         returnInSub = false;
         /* Using cursor H005E2 */
         pr_default.execute(0);
         while ( (pr_default.getStatus(0) != 101) )
         {
            A1235MonSts = H005E2_A1235MonSts[0];
            A180MonCod = H005E2_A180MonCod[0];
            A1234MonDsc = H005E2_A1234MonDsc[0];
            AV9Combo_DataItem = new GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTComboData_Item(context);
            AV9Combo_DataItem.gxTpr_Id = StringUtil.Trim( StringUtil.Str( (decimal)(A180MonCod), 6, 0));
            AV9Combo_DataItem.gxTpr_Title = A1234MonDsc;
            AV31MonCod_Data.Add(AV9Combo_DataItem, 0);
            pr_default.readNext(0);
         }
         pr_default.close(0);
         Combo_moncod_Selectedvalue_set = ((0==AV30MonCod) ? "" : StringUtil.Trim( StringUtil.Str( (decimal)(AV30MonCod), 6, 0)));
         ucCombo_moncod.SendProperty(context, "", false, Combo_moncod_Internalname, "SelectedValue_set", Combo_moncod_Selectedvalue_set);
      }

      protected void S142( )
      {
         /* 'LOADCOMBOTIPCCOD' Routine */
         returnInSub = false;
         /* Using cursor H005E3 */
         pr_default.execute(1);
         while ( (pr_default.getStatus(1) != 101) )
         {
            A1908TipCSts = H005E3_A1908TipCSts[0];
            A159TipCCod = H005E3_A159TipCCod[0];
            A1905TipCDsc = H005E3_A1905TipCDsc[0];
            AV9Combo_DataItem = new GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTComboData_Item(context);
            AV9Combo_DataItem.gxTpr_Id = StringUtil.Trim( StringUtil.Str( (decimal)(A159TipCCod), 6, 0));
            AV9Combo_DataItem.gxTpr_Title = A1905TipCDsc;
            AV42TipCCod_Data.Add(AV9Combo_DataItem, 0);
            pr_default.readNext(1);
         }
         pr_default.close(1);
         Combo_tipccod_Selectedvalue_set = ((0==AV41TipCCod) ? "" : StringUtil.Trim( StringUtil.Str( (decimal)(AV41TipCCod), 6, 0)));
         ucCombo_tipccod.SendProperty(context, "", false, Combo_tipccod_Internalname, "SelectedValue_set", Combo_tipccod_Selectedvalue_set);
      }

      protected void S132( )
      {
         /* 'LOADCOMBOZONCOD' Routine */
         returnInSub = false;
         /* Using cursor H005E4 */
         pr_default.execute(2);
         while ( (pr_default.getStatus(2) != 101) )
         {
            A2095ZonSts = H005E4_A2095ZonSts[0];
            A158ZonCod = H005E4_A158ZonCod[0];
            A2094ZonDsc = H005E4_A2094ZonDsc[0];
            AV9Combo_DataItem = new GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTComboData_Item(context);
            AV9Combo_DataItem.gxTpr_Id = StringUtil.Trim( StringUtil.Str( (decimal)(A158ZonCod), 6, 0));
            AV9Combo_DataItem.gxTpr_Title = A2094ZonDsc;
            AV52ZonCod_Data.Add(AV9Combo_DataItem, 0);
            pr_default.readNext(2);
         }
         pr_default.close(2);
         Combo_zoncod_Selectedvalue_set = ((0==AV51ZonCod) ? "" : StringUtil.Trim( StringUtil.Str( (decimal)(AV51ZonCod), 6, 0)));
         ucCombo_zoncod.SendProperty(context, "", false, Combo_zoncod_Internalname, "SelectedValue_set", Combo_zoncod_Selectedvalue_set);
      }

      protected void S122( )
      {
         /* 'LOADCOMBOTIPCOD' Routine */
         returnInSub = false;
         /* Using cursor H005E5 */
         pr_default.execute(3);
         while ( (pr_default.getStatus(3) != 101) )
         {
            A1919TipSts = H005E5_A1919TipSts[0];
            A149TipCod = H005E5_A149TipCod[0];
            A1910TipDsc = H005E5_A1910TipDsc[0];
            AV9Combo_DataItem = new GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTComboData_Item(context);
            AV9Combo_DataItem.gxTpr_Id = A149TipCod;
            AV9Combo_DataItem.gxTpr_Title = A1910TipDsc;
            AV44TipCod_Data.Add(AV9Combo_DataItem, 0);
            pr_default.readNext(3);
         }
         pr_default.close(3);
         Combo_tipcod_Selectedvalue_set = AV43TipCod;
         ucCombo_tipcod.SendProperty(context, "", false, Combo_tipcod_Internalname, "SelectedValue_set", Combo_tipcod_Selectedvalue_set);
      }

      protected void S112( )
      {
         /* 'LOADCOMBOVENCOD' Routine */
         returnInSub = false;
         /* Using cursor H005E6 */
         pr_default.execute(4);
         while ( (pr_default.getStatus(4) != 101) )
         {
            A2047VenSts = H005E6_A2047VenSts[0];
            A309VenCod = H005E6_A309VenCod[0];
            A2045VenDsc = H005E6_A2045VenDsc[0];
            AV9Combo_DataItem = new GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTComboData_Item(context);
            AV9Combo_DataItem.gxTpr_Id = StringUtil.Trim( StringUtil.Str( (decimal)(A309VenCod), 6, 0));
            AV9Combo_DataItem.gxTpr_Title = A2045VenDsc;
            AV50VenCod_Data.Add(AV9Combo_DataItem, 0);
            pr_default.readNext(4);
         }
         pr_default.close(4);
         Combo_vencod_Selectedvalue_set = ((0==AV49VenCod) ? "" : StringUtil.Trim( StringUtil.Str( (decimal)(AV49VenCod), 6, 0)));
         ucCombo_vencod.SendProperty(context, "", false, Combo_vencod_Internalname, "SelectedValue_set", Combo_vencod_Selectedvalue_set);
      }

      protected void E145E2( )
      {
         /* 'DoBtnExcel' Routine */
         returnInSub = false;
         context.DoAjaxRefresh();
         new pcuentacorrienteexcel(context ).execute( ref  AV41TipCCod, ref  AV6CliCod, ref  AV43TipCod, ref  AV30MonCod, ref  AV22FHasta, ref  AV51ZonCod, ref  AV37Serie, ref  AV46TipLetras, ref  AV49VenCod, out  AV17ExcelFilename, out  AV14ErrorMessage) ;
         AssignAttri("", false, "AV41TipCCod", StringUtil.LTrimStr( (decimal)(AV41TipCCod), 6, 0));
         AssignAttri("", false, "AV6CliCod", AV6CliCod);
         AssignAttri("", false, "AV43TipCod", AV43TipCod);
         AssignAttri("", false, "AV30MonCod", StringUtil.LTrimStr( (decimal)(AV30MonCod), 6, 0));
         AssignAttri("", false, "AV22FHasta", context.localUtil.Format(AV22FHasta, "99/99/99"));
         AssignAttri("", false, "AV51ZonCod", StringUtil.LTrimStr( (decimal)(AV51ZonCod), 6, 0));
         AssignAttri("", false, "AV37Serie", AV37Serie);
         AssignAttri("", false, "AV46TipLetras", StringUtil.Str( (decimal)(AV46TipLetras), 1, 0));
         AssignAttri("", false, "AV49VenCod", StringUtil.LTrimStr( (decimal)(AV49VenCod), 6, 0));
         if ( StringUtil.StrCmp(AV17ExcelFilename, "") != 0 )
         {
            CallWebObject(formatLink(AV17ExcelFilename) );
            context.wjLocDisableFrm = 0;
         }
         else
         {
            GX_msglist.addItem(AV14ErrorMessage);
         }
         /*  Sending Event outputs  */
      }

      protected void nextLoad( )
      {
      }

      protected void E155E2( )
      {
         /* Load Routine */
         returnInSub = false;
      }

      protected void wb_table1_57_5E2( bool wbgen )
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
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 61,'',false,'',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavClicod_Internalname, StringUtil.RTrim( AV6CliCod), StringUtil.RTrim( context.localUtil.Format( AV6CliCod, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,61);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavClicod_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtavClicod_Enabled, 0, "text", "", 20, "chr", 1, "row", 20, 0, 0, 0, 1, -1, -1, true, "", "left", true, "", "HLP_Ventas\\R_AntiguedadSaldos.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "<td class='CellPaddingLeft10'>") ;
            /* Active images/pictures */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 63,'',false,'',0)\"";
            ClassString = "Image";
            StyleString = "";
            sImgUrl = (string)(context.GetImagePath( "f5b04895-0024-488b-8e3b-b687ca4598ee", "", context.GetTheme( )));
            GxWebStd.gx_bitmap( context, imgBtnbuscar_Internalname, sImgUrl, "", "", "", context.GetTheme( ), 1, 1, "", "Buscar Cliente", 0, 0, 0, "px", 0, "px", 0, 0, 7, imgBtnbuscar_Jsonclick, "'"+""+"'"+",false,"+"'"+"e165e1_client"+"'", StyleString, ClassString, "", "", "", "", " "+"data-gx-image"+" "+TempTags, "", "", 1, false, false, context.GetImageSrcSet( sImgUrl), "HLP_Ventas\\R_AntiguedadSaldos.htm");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "<td class='DataContentCell'>") ;
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "left", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavClidsc_Internalname, "Descripción Cliente", "gx-form-item ReadonlyAttributeLabel", 0, true, "width: 25%;");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 66,'',false,'',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavClidsc_Internalname, StringUtil.RTrim( AV8CliDsc), StringUtil.RTrim( context.localUtil.Format( AV8CliDsc, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,66);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavClidsc_Jsonclick, 0, "ReadonlyAttribute", "", "", "", "", 1, edtavClidsc_Enabled, 0, "text", "", 80, "chr", 1, "row", 100, 0, 0, 0, 1, -1, -1, true, "", "left", true, "", "HLP_Ventas\\R_AntiguedadSaldos.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "</tr>") ;
            /* End of table */
            context.WriteHtmlText( "</table>") ;
            wb_table1_57_5E2e( true) ;
         }
         else
         {
            wb_table1_57_5E2e( false) ;
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
         PA5E2( ) ;
         WS5E2( ) ;
         WE5E2( ) ;
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
            context.AddJavascriptSource(StringUtil.RTrim( ((string)Form.Jscriptsrc.Item(idxLst))), "?202281810314153", true, true);
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
         context.AddJavascriptSource("ventas/r_antiguedadsaldos.js", "?202281810314154", false, true);
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
         chkavFlag2.Name = "vFLAG2";
         chkavFlag2.WebTags = "";
         chkavFlag2.Caption = "¿Desea Agrupar por Cliente?";
         AssignProp("", false, chkavFlag2_Internalname, "TitleCaption", chkavFlag2.Caption, true);
         chkavFlag2.CheckedValue = "0";
         AV53Flag2 = (short)(((StringUtil.StrCmp(StringUtil.LTrim( StringUtil.NToC( (decimal)(AV53Flag2), 1, 0, ".", "")), "1")==0) ? 1 : 0));
         AssignAttri("", false, "AV53Flag2", StringUtil.Str( (decimal)(AV53Flag2), 1, 0));
         radavFlag.Name = "vFLAG";
         radavFlag.WebTags = "";
         radavFlag.addItem("1", "Por Semanas", 0);
         radavFlag.addItem("2", "Por Meses", 0);
         /* End function init_web_controls */
      }

      protected void init_default_properties( )
      {
         lblTextblockcombo_vencod_Internalname = "TEXTBLOCKCOMBO_VENCOD";
         Combo_vencod_Internalname = "COMBO_VENCOD";
         divTablesplittedvencod_Internalname = "TABLESPLITTEDVENCOD";
         lblTextblockcombo_tipcod_Internalname = "TEXTBLOCKCOMBO_TIPCOD";
         Combo_tipcod_Internalname = "COMBO_TIPCOD";
         divTablesplittedtipcod_Internalname = "TABLESPLITTEDTIPCOD";
         lblTextblockcombo_zoncod_Internalname = "TEXTBLOCKCOMBO_ZONCOD";
         Combo_zoncod_Internalname = "COMBO_ZONCOD";
         divTablesplittedzoncod_Internalname = "TABLESPLITTEDZONCOD";
         lblTextblockcombo_tipccod_Internalname = "TEXTBLOCKCOMBO_TIPCCOD";
         Combo_tipccod_Internalname = "COMBO_TIPCCOD";
         divTablesplittedtipccod_Internalname = "TABLESPLITTEDTIPCCOD";
         lblTextblockclicod_Internalname = "TEXTBLOCKCLICOD";
         edtavClicod_Internalname = "vCLICOD";
         imgBtnbuscar_Internalname = "BTNBUSCAR";
         edtavClidsc_Internalname = "vCLIDSC";
         tblTablemergedclicod_Internalname = "TABLEMERGEDCLICOD";
         divTablesplittedclicod_Internalname = "TABLESPLITTEDCLICOD";
         lblTextblockcombo_moncod_Internalname = "TEXTBLOCKCOMBO_MONCOD";
         Combo_moncod_Internalname = "COMBO_MONCOD";
         divTablesplittedmoncod_Internalname = "TABLESPLITTEDMONCOD";
         lblTextblockflag2_Internalname = "TEXTBLOCKFLAG2";
         chkavFlag2_Internalname = "vFLAG2";
         divUnnamedtableflag2_Internalname = "UNNAMEDTABLEFLAG2";
         lblTextblockflag_Internalname = "TEXTBLOCKFLAG";
         radavFlag_Internalname = "vFLAG";
         divUnnamedtableflag_Internalname = "UNNAMEDTABLEFLAG";
         divPanel1_Internalname = "PANEL1";
         Dvpanel_panel1_Internalname = "DVPANEL_PANEL1";
         bttBtnbtnimprimir_Internalname = "BTNBTNIMPRIMIR";
         bttBtnbtnsalir_Internalname = "BTNBTNSALIR";
         Innewwindow_Internalname = "INNEWWINDOW";
         divTablecontent_Internalname = "TABLECONTENT";
         divTablemain_Internalname = "TABLEMAIN";
         edtavVencod_Internalname = "vVENCOD";
         edtavTipcod_Internalname = "vTIPCOD";
         edtavZoncod_Internalname = "vZONCOD";
         edtavTipccod_Internalname = "vTIPCCOD";
         edtavMoncod_Internalname = "vMONCOD";
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
         chkavFlag2.Caption = "Flag2";
         edtavClidsc_Jsonclick = "";
         edtavClidsc_Enabled = 1;
         edtavClicod_Jsonclick = "";
         edtavClicod_Enabled = 1;
         edtavMoncod_Jsonclick = "";
         edtavMoncod_Visible = 1;
         edtavTipccod_Jsonclick = "";
         edtavTipccod_Visible = 1;
         edtavZoncod_Jsonclick = "";
         edtavZoncod_Visible = 1;
         edtavTipcod_Jsonclick = "";
         edtavTipcod_Visible = 1;
         edtavVencod_Jsonclick = "";
         edtavVencod_Visible = 1;
         radavFlag_Jsonclick = "";
         chkavFlag2.Enabled = 1;
         Innewwindow_Target = "";
         Dvpanel_panel1_Autoscroll = Convert.ToBoolean( 0);
         Dvpanel_panel1_Iconposition = "Right";
         Dvpanel_panel1_Showcollapseicon = Convert.ToBoolean( 0);
         Dvpanel_panel1_Collapsed = Convert.ToBoolean( 0);
         Dvpanel_panel1_Collapsible = Convert.ToBoolean( -1);
         Dvpanel_panel1_Title = "Reporte de Antiguedad de Saldos";
         Dvpanel_panel1_Cls = "PanelFilled Panel_BaseColor";
         Dvpanel_panel1_Autoheight = Convert.ToBoolean( -1);
         Dvpanel_panel1_Autowidth = Convert.ToBoolean( 0);
         Dvpanel_panel1_Width = "100%";
         Combo_moncod_Cls = "ExtendedCombo AttributeRealWidth50With";
         Combo_tipccod_Cls = "ExtendedCombo AttributeRealWidth50With";
         Combo_zoncod_Cls = "ExtendedCombo AttributeRealWidth50With";
         Combo_tipcod_Cls = "ExtendedCombo AttributeRealWidth50With";
         Combo_vencod_Cls = "ExtendedCombo AttributeRealWidth50With";
         Form.Headerrawhtml = "";
         Form.Background = "";
         Form.Textcolor = 0;
         Form.Backcolor = (int)(0xFFFFFF);
         Form.Caption = "Antiguedad de Saldos";
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
         setEventMetadata("REFRESH","{handler:'Refresh',iparms:[{av:'AV53Flag2',fld:'vFLAG2',pic:'9'},{av:'radavFlag'},{av:'AV23Flag',fld:'vFLAG',pic:'9'}]");
         setEventMetadata("REFRESH",",oparms:[{av:'AV53Flag2',fld:'vFLAG2',pic:'9'},{av:'radavFlag'},{av:'AV23Flag',fld:'vFLAG',pic:'9'}]}");
         setEventMetadata("'DOBTNIMPRIMIR'","{handler:'E125E2',iparms:[{av:'AV49VenCod',fld:'vVENCOD',pic:'ZZZZZ9'},{av:'AV43TipCod',fld:'vTIPCOD',pic:''},{av:'AV51ZonCod',fld:'vZONCOD',pic:'ZZZZZ9'},{av:'AV41TipCCod',fld:'vTIPCCOD',pic:'ZZZZZ9'},{av:'AV6CliCod',fld:'vCLICOD',pic:''},{av:'AV30MonCod',fld:'vMONCOD',pic:'ZZZZZ9'},{av:'AV53Flag2',fld:'vFLAG2',pic:'9'},{av:'radavFlag'},{av:'AV23Flag',fld:'vFLAG',pic:'9'}]");
         setEventMetadata("'DOBTNIMPRIMIR'",",oparms:[{av:'Innewwindow_Target',ctrl:'INNEWWINDOW',prop:'Target'},{av:'AV53Flag2',fld:'vFLAG2',pic:'9'},{av:'radavFlag'},{av:'AV23Flag',fld:'vFLAG',pic:'9'}]}");
         setEventMetadata("'DOBTNSALIR'","{handler:'E135E2',iparms:[{av:'AV53Flag2',fld:'vFLAG2',pic:'9'},{av:'radavFlag'},{av:'AV23Flag',fld:'vFLAG',pic:'9'}]");
         setEventMetadata("'DOBTNSALIR'",",oparms:[{av:'AV53Flag2',fld:'vFLAG2',pic:'9'},{av:'radavFlag'},{av:'AV23Flag',fld:'vFLAG',pic:'9'}]}");
         setEventMetadata("'DOBTNEXCEL'","{handler:'E145E2',iparms:[{av:'AV41TipCCod',fld:'vTIPCCOD',pic:'ZZZZZ9'},{av:'AV6CliCod',fld:'vCLICOD',pic:''},{av:'AV43TipCod',fld:'vTIPCOD',pic:''},{av:'AV30MonCod',fld:'vMONCOD',pic:'ZZZZZ9'},{av:'AV22FHasta',fld:'vFHASTA',pic:''},{av:'AV51ZonCod',fld:'vZONCOD',pic:'ZZZZZ9'},{av:'AV37Serie',fld:'vSERIE',pic:''},{av:'AV46TipLetras',fld:'vTIPLETRAS',pic:'9'},{av:'AV49VenCod',fld:'vVENCOD',pic:'ZZZZZ9'},{av:'AV53Flag2',fld:'vFLAG2',pic:'9'},{av:'radavFlag'},{av:'AV23Flag',fld:'vFLAG',pic:'9'}]");
         setEventMetadata("'DOBTNEXCEL'",",oparms:[{av:'AV49VenCod',fld:'vVENCOD',pic:'ZZZZZ9'},{av:'AV46TipLetras',fld:'vTIPLETRAS',pic:'9'},{av:'AV37Serie',fld:'vSERIE',pic:''},{av:'AV51ZonCod',fld:'vZONCOD',pic:'ZZZZZ9'},{av:'AV22FHasta',fld:'vFHASTA',pic:''},{av:'AV30MonCod',fld:'vMONCOD',pic:'ZZZZZ9'},{av:'AV43TipCod',fld:'vTIPCOD',pic:''},{av:'AV6CliCod',fld:'vCLICOD',pic:''},{av:'AV41TipCCod',fld:'vTIPCCOD',pic:'ZZZZZ9'},{av:'AV53Flag2',fld:'vFLAG2',pic:'9'},{av:'radavFlag'},{av:'AV23Flag',fld:'vFLAG',pic:'9'}]}");
         setEventMetadata("BTNBUSCAR.CLICK","{handler:'E165E1',iparms:[{av:'AV53Flag2',fld:'vFLAG2',pic:'9'},{av:'radavFlag'},{av:'AV23Flag',fld:'vFLAG',pic:'9'}]");
         setEventMetadata("BTNBUSCAR.CLICK",",oparms:[{av:'AV8CliDsc',fld:'vCLIDSC',pic:''},{av:'AV6CliCod',fld:'vCLICOD',pic:''},{av:'AV53Flag2',fld:'vFLAG2',pic:'9'},{av:'radavFlag'},{av:'AV23Flag',fld:'vFLAG',pic:'9'}]}");
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
         Combo_moncod_Selectedvalue_get = "";
         Combo_tipccod_Selectedvalue_get = "";
         Combo_zoncod_Selectedvalue_get = "";
         Combo_tipcod_Selectedvalue_get = "";
         Combo_vencod_Selectedvalue_get = "";
         gxfirstwebparm = "";
         gxfirstwebparm_bkp = "";
         sDynURL = "";
         FormProcess = "";
         bodyStyle = "";
         GXKey = "";
         AV50VenCod_Data = new GXBaseCollection<GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTComboData_Item>( context, "Item", "");
         AV44TipCod_Data = new GXBaseCollection<GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTComboData_Item>( context, "Item", "");
         AV52ZonCod_Data = new GXBaseCollection<GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTComboData_Item>( context, "Item", "");
         AV42TipCCod_Data = new GXBaseCollection<GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTComboData_Item>( context, "Item", "");
         AV31MonCod_Data = new GXBaseCollection<GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTComboData_Item>( context, "Item", "");
         AV22FHasta = DateTime.MinValue;
         AV37Serie = "";
         Combo_vencod_Selectedvalue_set = "";
         Combo_tipcod_Selectedvalue_set = "";
         Combo_zoncod_Selectedvalue_set = "";
         Combo_tipccod_Selectedvalue_set = "";
         Combo_moncod_Selectedvalue_set = "";
         GX_FocusControl = "";
         Form = new GXWebForm();
         sPrefix = "";
         ClassString = "";
         StyleString = "";
         ucDvpanel_panel1 = new GXUserControl();
         lblTextblockcombo_vencod_Jsonclick = "";
         ucCombo_vencod = new GXUserControl();
         Combo_vencod_Caption = "";
         lblTextblockcombo_tipcod_Jsonclick = "";
         ucCombo_tipcod = new GXUserControl();
         Combo_tipcod_Caption = "";
         lblTextblockcombo_zoncod_Jsonclick = "";
         ucCombo_zoncod = new GXUserControl();
         Combo_zoncod_Caption = "";
         lblTextblockcombo_tipccod_Jsonclick = "";
         ucCombo_tipccod = new GXUserControl();
         Combo_tipccod_Caption = "";
         lblTextblockclicod_Jsonclick = "";
         lblTextblockcombo_moncod_Jsonclick = "";
         ucCombo_moncod = new GXUserControl();
         Combo_moncod_Caption = "";
         lblTextblockflag2_Jsonclick = "";
         TempTags = "";
         lblTextblockflag_Jsonclick = "";
         bttBtnbtnimprimir_Jsonclick = "";
         bttBtnbtnsalir_Jsonclick = "";
         ucInnewwindow = new GXUserControl();
         AV43TipCod = "";
         sEvt = "";
         EvtGridId = "";
         EvtRowId = "";
         sEvtType = "";
         AV6CliCod = "";
         AV8CliDsc = "";
         GXEncryptionTmp = "";
         scmdbuf = "";
         H005E2_A1235MonSts = new short[1] ;
         H005E2_A180MonCod = new int[1] ;
         H005E2_A1234MonDsc = new string[] {""} ;
         A1234MonDsc = "";
         AV9Combo_DataItem = new GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTComboData_Item(context);
         H005E3_A1908TipCSts = new short[1] ;
         H005E3_A159TipCCod = new int[1] ;
         H005E3_A1905TipCDsc = new string[] {""} ;
         A1905TipCDsc = "";
         H005E4_A2095ZonSts = new short[1] ;
         H005E4_A158ZonCod = new int[1] ;
         H005E4_A2094ZonDsc = new string[] {""} ;
         A2094ZonDsc = "";
         H005E5_A1919TipSts = new short[1] ;
         H005E5_A149TipCod = new string[] {""} ;
         H005E5_A1910TipDsc = new string[] {""} ;
         A149TipCod = "";
         A1910TipDsc = "";
         H005E6_A2047VenSts = new short[1] ;
         H005E6_A309VenCod = new int[1] ;
         H005E6_A2045VenDsc = new string[] {""} ;
         A2045VenDsc = "";
         AV17ExcelFilename = "";
         AV14ErrorMessage = "";
         sStyleString = "";
         sImgUrl = "";
         imgBtnbuscar_Jsonclick = "";
         BackMsgLst = new msglist();
         LclMsgLst = new msglist();
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.ventas.r_antiguedadsaldos__default(),
            new Object[][] {
                new Object[] {
               H005E2_A1235MonSts, H005E2_A180MonCod, H005E2_A1234MonDsc
               }
               , new Object[] {
               H005E3_A1908TipCSts, H005E3_A159TipCCod, H005E3_A1905TipCDsc
               }
               , new Object[] {
               H005E4_A2095ZonSts, H005E4_A158ZonCod, H005E4_A2094ZonDsc
               }
               , new Object[] {
               H005E5_A1919TipSts, H005E5_A149TipCod, H005E5_A1910TipDsc
               }
               , new Object[] {
               H005E6_A2047VenSts, H005E6_A309VenCod, H005E6_A2045VenDsc
               }
            }
         );
         AV30MonCod = 0;
         /* GeneXus formulas. */
         context.Gx_err = 0;
         edtavClidsc_Enabled = 0;
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
      private short AV46TipLetras ;
      private short wbEnd ;
      private short wbStart ;
      private short AV53Flag2 ;
      private short AV23Flag ;
      private short nDonePA ;
      private short A1235MonSts ;
      private short A1908TipCSts ;
      private short A2095ZonSts ;
      private short A1919TipSts ;
      private short A2047VenSts ;
      private short nGXWrapped ;
      private int AV49VenCod ;
      private int edtavVencod_Visible ;
      private int edtavTipcod_Visible ;
      private int AV51ZonCod ;
      private int edtavZoncod_Visible ;
      private int AV41TipCCod ;
      private int edtavTipccod_Visible ;
      private int AV30MonCod ;
      private int edtavMoncod_Visible ;
      private int edtavClidsc_Enabled ;
      private int A180MonCod ;
      private int A159TipCCod ;
      private int A158ZonCod ;
      private int A309VenCod ;
      private int edtavClicod_Enabled ;
      private int idxLst ;
      private string Combo_moncod_Selectedvalue_get ;
      private string Combo_tipccod_Selectedvalue_get ;
      private string Combo_zoncod_Selectedvalue_get ;
      private string Combo_tipcod_Selectedvalue_get ;
      private string Combo_vencod_Selectedvalue_get ;
      private string gxfirstwebparm ;
      private string gxfirstwebparm_bkp ;
      private string sDynURL ;
      private string FormProcess ;
      private string bodyStyle ;
      private string GXKey ;
      private string AV37Serie ;
      private string Combo_vencod_Cls ;
      private string Combo_vencod_Selectedvalue_set ;
      private string Combo_tipcod_Cls ;
      private string Combo_tipcod_Selectedvalue_set ;
      private string Combo_zoncod_Cls ;
      private string Combo_zoncod_Selectedvalue_set ;
      private string Combo_tipccod_Cls ;
      private string Combo_tipccod_Selectedvalue_set ;
      private string Combo_moncod_Cls ;
      private string Combo_moncod_Selectedvalue_set ;
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
      private string divTablesplittedvencod_Internalname ;
      private string lblTextblockcombo_vencod_Internalname ;
      private string lblTextblockcombo_vencod_Jsonclick ;
      private string Combo_vencod_Caption ;
      private string Combo_vencod_Internalname ;
      private string divTablesplittedtipcod_Internalname ;
      private string lblTextblockcombo_tipcod_Internalname ;
      private string lblTextblockcombo_tipcod_Jsonclick ;
      private string Combo_tipcod_Caption ;
      private string Combo_tipcod_Internalname ;
      private string divTablesplittedzoncod_Internalname ;
      private string lblTextblockcombo_zoncod_Internalname ;
      private string lblTextblockcombo_zoncod_Jsonclick ;
      private string Combo_zoncod_Caption ;
      private string Combo_zoncod_Internalname ;
      private string divTablesplittedtipccod_Internalname ;
      private string lblTextblockcombo_tipccod_Internalname ;
      private string lblTextblockcombo_tipccod_Jsonclick ;
      private string Combo_tipccod_Caption ;
      private string Combo_tipccod_Internalname ;
      private string divTablesplittedclicod_Internalname ;
      private string lblTextblockclicod_Internalname ;
      private string lblTextblockclicod_Jsonclick ;
      private string divTablesplittedmoncod_Internalname ;
      private string lblTextblockcombo_moncod_Internalname ;
      private string lblTextblockcombo_moncod_Jsonclick ;
      private string Combo_moncod_Caption ;
      private string Combo_moncod_Internalname ;
      private string divUnnamedtableflag2_Internalname ;
      private string lblTextblockflag2_Internalname ;
      private string lblTextblockflag2_Jsonclick ;
      private string chkavFlag2_Internalname ;
      private string TempTags ;
      private string divUnnamedtableflag_Internalname ;
      private string lblTextblockflag_Internalname ;
      private string lblTextblockflag_Jsonclick ;
      private string radavFlag_Internalname ;
      private string radavFlag_Jsonclick ;
      private string bttBtnbtnimprimir_Internalname ;
      private string bttBtnbtnimprimir_Jsonclick ;
      private string bttBtnbtnsalir_Internalname ;
      private string bttBtnbtnsalir_Jsonclick ;
      private string Innewwindow_Internalname ;
      private string divHtml_bottomauxiliarcontrols_Internalname ;
      private string edtavVencod_Internalname ;
      private string edtavVencod_Jsonclick ;
      private string edtavTipcod_Internalname ;
      private string AV43TipCod ;
      private string edtavTipcod_Jsonclick ;
      private string edtavZoncod_Internalname ;
      private string edtavZoncod_Jsonclick ;
      private string edtavTipccod_Internalname ;
      private string edtavTipccod_Jsonclick ;
      private string edtavMoncod_Internalname ;
      private string edtavMoncod_Jsonclick ;
      private string sEvt ;
      private string EvtGridId ;
      private string EvtRowId ;
      private string sEvtType ;
      private string edtavClicod_Internalname ;
      private string edtavClidsc_Internalname ;
      private string AV6CliCod ;
      private string AV8CliDsc ;
      private string GXEncryptionTmp ;
      private string scmdbuf ;
      private string A1234MonDsc ;
      private string A1905TipCDsc ;
      private string A2094ZonDsc ;
      private string A149TipCod ;
      private string A1910TipDsc ;
      private string A2045VenDsc ;
      private string sStyleString ;
      private string tblTablemergedclicod_Internalname ;
      private string edtavClicod_Jsonclick ;
      private string sImgUrl ;
      private string imgBtnbuscar_Internalname ;
      private string imgBtnbuscar_Jsonclick ;
      private string edtavClidsc_Jsonclick ;
      private DateTime AV22FHasta ;
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
      private string AV17ExcelFilename ;
      private string AV14ErrorMessage ;
      private GXUserControl ucDvpanel_panel1 ;
      private GXUserControl ucCombo_vencod ;
      private GXUserControl ucCombo_tipcod ;
      private GXUserControl ucCombo_zoncod ;
      private GXUserControl ucCombo_tipccod ;
      private GXUserControl ucCombo_moncod ;
      private GXUserControl ucInnewwindow ;
      private IGxDataStore dsDataStore2 ;
      private IGxDataStore dsDefault ;
      private GXCheckbox chkavFlag2 ;
      private GXRadio radavFlag ;
      private IDataStoreProvider pr_default ;
      private short[] H005E2_A1235MonSts ;
      private int[] H005E2_A180MonCod ;
      private string[] H005E2_A1234MonDsc ;
      private short[] H005E3_A1908TipCSts ;
      private int[] H005E3_A159TipCCod ;
      private string[] H005E3_A1905TipCDsc ;
      private short[] H005E4_A2095ZonSts ;
      private int[] H005E4_A158ZonCod ;
      private string[] H005E4_A2094ZonDsc ;
      private short[] H005E5_A1919TipSts ;
      private string[] H005E5_A149TipCod ;
      private string[] H005E5_A1910TipDsc ;
      private short[] H005E6_A2047VenSts ;
      private int[] H005E6_A309VenCod ;
      private string[] H005E6_A2045VenDsc ;
      private msglist BackMsgLst ;
      private msglist LclMsgLst ;
      private GXBaseCollection<GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTComboData_Item> AV50VenCod_Data ;
      private GXBaseCollection<GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTComboData_Item> AV44TipCod_Data ;
      private GXBaseCollection<GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTComboData_Item> AV52ZonCod_Data ;
      private GXBaseCollection<GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTComboData_Item> AV42TipCCod_Data ;
      private GXBaseCollection<GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTComboData_Item> AV31MonCod_Data ;
      private GXWebForm Form ;
      private GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTComboData_Item AV9Combo_DataItem ;
   }

   public class r_antiguedadsaldos__default : DataStoreHelperBase, IDataStoreHelper
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
          Object[] prmH005E2;
          prmH005E2 = new Object[] {
          };
          Object[] prmH005E3;
          prmH005E3 = new Object[] {
          };
          Object[] prmH005E4;
          prmH005E4 = new Object[] {
          };
          Object[] prmH005E5;
          prmH005E5 = new Object[] {
          };
          Object[] prmH005E6;
          prmH005E6 = new Object[] {
          };
          def= new CursorDef[] {
              new CursorDef("H005E2", "SELECT [MonSts], [MonCod], [MonDsc] FROM [CMONEDAS] WHERE [MonSts] = 1 ORDER BY [MonDsc] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH005E2,100, GxCacheFrequency.OFF ,false,false )
             ,new CursorDef("H005E3", "SELECT [TipCSts], [TipCCod], [TipCDsc] FROM [CTIPOCLIENTE] WHERE [TipCSts] = 1 ORDER BY [TipCDsc] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH005E3,100, GxCacheFrequency.OFF ,false,false )
             ,new CursorDef("H005E4", "SELECT [ZonSts], [ZonCod], [ZonDsc] FROM [CZONAS] WHERE [ZonSts] = 1 ORDER BY [ZonDsc] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH005E4,100, GxCacheFrequency.OFF ,false,false )
             ,new CursorDef("H005E5", "SELECT [TipSts], [TipCod], [TipDsc] FROM [CTIPDOC] WHERE [TipSts] = 1 ORDER BY [TipDsc] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH005E5,100, GxCacheFrequency.OFF ,false,false )
             ,new CursorDef("H005E6", "SELECT [VenSts], [VenCod], [VenDsc] FROM [CVENDEDORES] WHERE [VenSts] = 1 ORDER BY [VenDsc] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH005E6,100, GxCacheFrequency.OFF ,false,false )
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
                ((string[]) buf[1])[0] = rslt.getString(2, 3);
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
