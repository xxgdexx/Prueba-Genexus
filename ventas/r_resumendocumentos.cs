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
   public class r_resumendocumentos : GXDataArea
   {
      public r_resumendocumentos( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDataStore2 = context.GetDataStore("DataStore2");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusTheme");
      }

      public r_resumendocumentos( IGxContext context )
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
         cmbavTipo = new GXCombobox();
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
         PA5L2( ) ;
         gxajaxcallmode = (short)((isAjaxCallMode( ) ? 1 : 0));
         if ( ( gxajaxcallmode == 0 ) && ( GxWebError == 0 ) )
         {
            START5L2( ) ;
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
         context.AddJavascriptSource("gxcfg.js", "?202281810314911", false, true);
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
         context.WriteHtmlTextNl( "<form id=\"MAINFORM\" autocomplete=\"off\" name=\"MAINFORM\" method=\"post\" tabindex=-1  class=\"form-horizontal Form\" data-gx-class=\"form-horizontal Form\" novalidate action=\""+formatLink("ventas.r_resumendocumentos.aspx") +"\">") ;
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
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "vTIECOD_DATA", AV48TieCod_Data);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt("vTIECOD_DATA", AV48TieCod_Data);
         }
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "vTIPCOD_DATA", AV35TipCod_Data);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt("vTIPCOD_DATA", AV35TipCod_Data);
         }
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "vTIPCCOD_DATA", AV33TipCcod_Data);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt("vTIPCCOD_DATA", AV33TipCcod_Data);
         }
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "vESTCOD_DATA", AV49EstCod_Data);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt("vESTCOD_DATA", AV49EstCod_Data);
         }
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "vPAICOD_DATA", AV50PaiCod_Data);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt("vPAICOD_DATA", AV50PaiCod_Data);
         }
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "vDOCCONPCOD_DATA", AV51DocConPCod_Data);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt("vDOCCONPCOD_DATA", AV51DocConPCod_Data);
         }
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "vVENCOD_DATA", AV41VenCod_Data);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt("vVENCOD_DATA", AV41VenCod_Data);
         }
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "vMONCOD_DATA", AV24MonCod_Data);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt("vMONCOD_DATA", AV24MonCod_Data);
         }
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "vSERIE_DATA", AV29Serie_Data);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt("vSERIE_DATA", AV29Serie_Data);
         }
         GxWebStd.gx_hidden_field( context, "COMBO_TIECOD_Cls", StringUtil.RTrim( Combo_tiecod_Cls));
         GxWebStd.gx_hidden_field( context, "COMBO_TIECOD_Selectedvalue_set", StringUtil.RTrim( Combo_tiecod_Selectedvalue_set));
         GxWebStd.gx_hidden_field( context, "COMBO_TIPCOD_Cls", StringUtil.RTrim( Combo_tipcod_Cls));
         GxWebStd.gx_hidden_field( context, "COMBO_TIPCOD_Selectedvalue_set", StringUtil.RTrim( Combo_tipcod_Selectedvalue_set));
         GxWebStd.gx_hidden_field( context, "COMBO_TIPCCOD_Cls", StringUtil.RTrim( Combo_tipccod_Cls));
         GxWebStd.gx_hidden_field( context, "COMBO_TIPCCOD_Selectedvalue_set", StringUtil.RTrim( Combo_tipccod_Selectedvalue_set));
         GxWebStd.gx_hidden_field( context, "COMBO_ESTCOD_Cls", StringUtil.RTrim( Combo_estcod_Cls));
         GxWebStd.gx_hidden_field( context, "COMBO_ESTCOD_Selectedvalue_set", StringUtil.RTrim( Combo_estcod_Selectedvalue_set));
         GxWebStd.gx_hidden_field( context, "COMBO_PAICOD_Cls", StringUtil.RTrim( Combo_paicod_Cls));
         GxWebStd.gx_hidden_field( context, "COMBO_PAICOD_Selectedvalue_set", StringUtil.RTrim( Combo_paicod_Selectedvalue_set));
         GxWebStd.gx_hidden_field( context, "COMBO_DOCCONPCOD_Cls", StringUtil.RTrim( Combo_docconpcod_Cls));
         GxWebStd.gx_hidden_field( context, "COMBO_DOCCONPCOD_Selectedvalue_set", StringUtil.RTrim( Combo_docconpcod_Selectedvalue_set));
         GxWebStd.gx_hidden_field( context, "COMBO_VENCOD_Cls", StringUtil.RTrim( Combo_vencod_Cls));
         GxWebStd.gx_hidden_field( context, "COMBO_VENCOD_Selectedvalue_set", StringUtil.RTrim( Combo_vencod_Selectedvalue_set));
         GxWebStd.gx_hidden_field( context, "COMBO_MONCOD_Cls", StringUtil.RTrim( Combo_moncod_Cls));
         GxWebStd.gx_hidden_field( context, "COMBO_MONCOD_Selectedvalue_set", StringUtil.RTrim( Combo_moncod_Selectedvalue_set));
         GxWebStd.gx_hidden_field( context, "COMBO_SERIE_Cls", StringUtil.RTrim( Combo_serie_Cls));
         GxWebStd.gx_hidden_field( context, "COMBO_SERIE_Selectedvalue_set", StringUtil.RTrim( Combo_serie_Selectedvalue_set));
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
         GxWebStd.gx_hidden_field( context, "COMBO_SERIE_Selectedvalue_get", StringUtil.RTrim( Combo_serie_Selectedvalue_get));
         GxWebStd.gx_hidden_field( context, "COMBO_MONCOD_Selectedvalue_get", StringUtil.RTrim( Combo_moncod_Selectedvalue_get));
         GxWebStd.gx_hidden_field( context, "COMBO_VENCOD_Selectedvalue_get", StringUtil.RTrim( Combo_vencod_Selectedvalue_get));
         GxWebStd.gx_hidden_field( context, "COMBO_DOCCONPCOD_Selectedvalue_get", StringUtil.RTrim( Combo_docconpcod_Selectedvalue_get));
         GxWebStd.gx_hidden_field( context, "COMBO_PAICOD_Selectedvalue_get", StringUtil.RTrim( Combo_paicod_Selectedvalue_get));
         GxWebStd.gx_hidden_field( context, "COMBO_ESTCOD_Selectedvalue_get", StringUtil.RTrim( Combo_estcod_Selectedvalue_get));
         GxWebStd.gx_hidden_field( context, "COMBO_TIPCCOD_Selectedvalue_get", StringUtil.RTrim( Combo_tipccod_Selectedvalue_get));
         GxWebStd.gx_hidden_field( context, "COMBO_TIPCOD_Selectedvalue_get", StringUtil.RTrim( Combo_tipcod_Selectedvalue_get));
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
            WE5L2( ) ;
            context.WriteHtmlText( "</div>") ;
         }
      }

      public override void DispatchEvents( )
      {
         EVT5L2( ) ;
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
         return formatLink("ventas.r_resumendocumentos.aspx")  ;
      }

      public override string GetPgmname( )
      {
         return "Ventas.R_ResumenDocumentos" ;
      }

      public override string GetPgmdesc( )
      {
         return "Resumen de Documentos" ;
      }

      protected void WB5L0( )
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
            GxWebStd.gx_div_start( context, divTablesplittedtiecod_Internalname, 1, 0, "px", 0, "px", "Table", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-6 MergeLabelCell CellWidth_12_5", "left", "top", "", "", "div");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblTextblockcombo_tiecod_Internalname, "Local", "", "", lblTextblockcombo_tiecod_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "Label", 0, "", 1, 1, 0, 0, "HLP_Ventas\\R_ResumenDocumentos.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-6 CellWidth_87_5", "left", "top", "", "", "div");
            /* User Defined Control */
            ucCombo_tiecod.SetProperty("Caption", Combo_tiecod_Caption);
            ucCombo_tiecod.SetProperty("Cls", Combo_tiecod_Cls);
            ucCombo_tiecod.SetProperty("DropDownOptionsData", AV48TieCod_Data);
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
            GxWebStd.gx_div_start( context, divTablesplittedtipcod_Internalname, 1, 0, "px", 0, "px", "Table", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-6 MergeLabelCell CellWidth_12_5", "left", "top", "", "", "div");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblTextblockcombo_tipcod_Internalname, "Tipo Documento", "", "", lblTextblockcombo_tipcod_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "Label", 0, "", 1, 1, 0, 0, "HLP_Ventas\\R_ResumenDocumentos.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-6 CellWidth_87_5", "left", "top", "", "", "div");
            /* User Defined Control */
            ucCombo_tipcod.SetProperty("Caption", Combo_tipcod_Caption);
            ucCombo_tipcod.SetProperty("Cls", Combo_tipcod_Cls);
            ucCombo_tipcod.SetProperty("DropDownOptionsData", AV35TipCod_Data);
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
            GxWebStd.gx_div_start( context, divTablesplittedtipccod_Internalname, 1, 0, "px", 0, "px", "Table", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-6 MergeLabelCell CellWidth_12_5", "left", "top", "", "", "div");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblTextblockcombo_tipccod_Internalname, "Tipo Cliente", "", "", lblTextblockcombo_tipccod_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "Label", 0, "", 1, 1, 0, 0, "HLP_Ventas\\R_ResumenDocumentos.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-6 CellWidth_87_5", "left", "top", "", "", "div");
            /* User Defined Control */
            ucCombo_tipccod.SetProperty("Caption", Combo_tipccod_Caption);
            ucCombo_tipccod.SetProperty("Cls", Combo_tipccod_Cls);
            ucCombo_tipccod.SetProperty("DropDownOptionsData", AV33TipCcod_Data);
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
            GxWebStd.gx_div_start( context, divTablesplittedestcod_Internalname, 1, 0, "px", 0, "px", "Table", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-6 MergeLabelCell CellWidth_12_5", "left", "top", "", "", "div");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblTextblockcombo_estcod_Internalname, "Estado", "", "", lblTextblockcombo_estcod_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "Label", 0, "", 1, 1, 0, 0, "HLP_Ventas\\R_ResumenDocumentos.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-6 CellWidth_87_5", "left", "top", "", "", "div");
            /* User Defined Control */
            ucCombo_estcod.SetProperty("Caption", Combo_estcod_Caption);
            ucCombo_estcod.SetProperty("Cls", Combo_estcod_Cls);
            ucCombo_estcod.SetProperty("DropDownOptionsData", AV49EstCod_Data);
            ucCombo_estcod.Render(context, "dvelop.gxbootstrap.ddoextendedcombo", Combo_estcod_Internalname, "COMBO_ESTCODContainer");
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
            GxWebStd.gx_div_start( context, divTablesplittedpaicod_Internalname, 1, 0, "px", 0, "px", "Table", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-6 MergeLabelCell CellWidth_12_5", "left", "top", "", "", "div");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblTextblockcombo_paicod_Internalname, "Pais", "", "", lblTextblockcombo_paicod_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "Label", 0, "", 1, 1, 0, 0, "HLP_Ventas\\R_ResumenDocumentos.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-6 CellWidth_87_5", "left", "top", "", "", "div");
            /* User Defined Control */
            ucCombo_paicod.SetProperty("Caption", Combo_paicod_Caption);
            ucCombo_paicod.SetProperty("Cls", Combo_paicod_Cls);
            ucCombo_paicod.SetProperty("DropDownOptionsData", AV50PaiCod_Data);
            ucCombo_paicod.Render(context, "dvelop.gxbootstrap.ddoextendedcombo", Combo_paicod_Internalname, "COMBO_PAICODContainer");
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
            GxWebStd.gx_div_start( context, divTablesplitteddocconpcod_Internalname, 1, 0, "px", 0, "px", "Table", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-6 MergeLabelCell CellWidth_12_5", "left", "top", "", "", "div");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblTextblockcombo_docconpcod_Internalname, "Condici?n de Pago", "", "", lblTextblockcombo_docconpcod_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "Label", 0, "", 1, 1, 0, 0, "HLP_Ventas\\R_ResumenDocumentos.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-6 CellWidth_87_5", "left", "top", "", "", "div");
            /* User Defined Control */
            ucCombo_docconpcod.SetProperty("Caption", Combo_docconpcod_Caption);
            ucCombo_docconpcod.SetProperty("Cls", Combo_docconpcod_Cls);
            ucCombo_docconpcod.SetProperty("DropDownOptionsData", AV51DocConPCod_Data);
            ucCombo_docconpcod.Render(context, "dvelop.gxbootstrap.ddoextendedcombo", Combo_docconpcod_Internalname, "COMBO_DOCCONPCODContainer");
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
            GxWebStd.gx_label_ctrl( context, lblTextblockcombo_vencod_Internalname, "Vendedor", "", "", lblTextblockcombo_vencod_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "Label", 0, "", 1, 1, 0, 0, "HLP_Ventas\\R_ResumenDocumentos.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-6 CellWidth_87_5", "left", "top", "", "", "div");
            /* User Defined Control */
            ucCombo_vencod.SetProperty("Caption", Combo_vencod_Caption);
            ucCombo_vencod.SetProperty("Cls", Combo_vencod_Cls);
            ucCombo_vencod.SetProperty("DropDownOptionsData", AV41VenCod_Data);
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
            GxWebStd.gx_label_ctrl( context, lblTextblockclicod_Internalname, "Cliente", "", "", lblTextblockclicod_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "Label", 0, "", 1, 1, 0, 0, "HLP_Ventas\\R_ResumenDocumentos.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-6 CellWidth_87_5", "left", "top", "", "", "div");
            wb_table1_81_5L2( true) ;
         }
         else
         {
            wb_table1_81_5L2( false) ;
         }
         return  ;
      }

      protected void wb_table1_81_5L2e( bool wbgen )
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
            GxWebStd.gx_label_ctrl( context, lblTextblockcombo_moncod_Internalname, "Moneda", "", "", lblTextblockcombo_moncod_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "Label", 0, "", 1, 1, 0, 0, "HLP_Ventas\\R_ResumenDocumentos.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-6 CellWidth_87_5", "left", "top", "", "", "div");
            /* User Defined Control */
            ucCombo_moncod.SetProperty("Caption", Combo_moncod_Caption);
            ucCombo_moncod.SetProperty("Cls", Combo_moncod_Cls);
            ucCombo_moncod.SetProperty("DropDownOptionsData", AV24MonCod_Data);
            ucCombo_moncod.Render(context, "dvelop.gxbootstrap.ddoextendedcombo", Combo_moncod_Internalname, "COMBO_MONCODContainer");
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
            GxWebStd.gx_label_ctrl( context, lblTextblocktipo_Internalname, "Tipo de Venta", "", "", lblTextblocktipo_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "Label", 0, "", 1, 1, 0, 0, "HLP_Ventas\\R_ResumenDocumentos.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-6 CellWidth_87_5", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "left", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, cmbavTipo_Internalname, "Tipo", "col-sm-3 AttributeRealWidth50WithLabel", 0, true, "");
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 107,'',false,'',0)\"";
            /* ComboBox */
            GxWebStd.gx_combobox_ctrl1( context, cmbavTipo, cmbavTipo_Internalname, StringUtil.RTrim( AV38Tipo), 1, cmbavTipo_Jsonclick, 0, "'"+""+"'"+",false,"+"'"+""+"'", "svchar", "", 1, cmbavTipo.Enabled, 0, 0, 0, "em", 0, "", "", "AttributeRealWidth50With", "", "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,107);\"", "", true, 1, "HLP_Ventas\\R_ResumenDocumentos.htm");
            cmbavTipo.CurrentValue = StringUtil.RTrim( AV38Tipo);
            AssignProp("", false, cmbavTipo_Internalname, "Values", (string)(cmbavTipo.ToJavascriptSource()), true);
            GxWebStd.gx_div_end( context, "left", "top", "div");
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
            GxWebStd.gx_div_start( context, divTablesplittedserie_Internalname, 1, 0, "px", 0, "px", "Table", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-6 MergeLabelCell CellWidth_12_5", "left", "top", "", "", "div");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblTextblockcombo_serie_Internalname, "Serie", "", "", lblTextblockcombo_serie_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "Label", 0, "", 1, 1, 0, 0, "HLP_Ventas\\R_ResumenDocumentos.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-6 CellWidth_87_5", "left", "top", "", "", "div");
            /* User Defined Control */
            ucCombo_serie.SetProperty("Caption", Combo_serie_Caption);
            ucCombo_serie.SetProperty("Cls", Combo_serie_Cls);
            ucCombo_serie.SetProperty("DropDownOptionsData", AV29Serie_Data);
            ucCombo_serie.Render(context, "dvelop.gxbootstrap.ddoextendedcombo", Combo_serie_Internalname, "COMBO_SERIEContainer");
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
            GxWebStd.gx_label_ctrl( context, lblTextblockfdesde_Internalname, "F.Desde", "", "", lblTextblockfdesde_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "Label", 0, "", 1, 1, 0, 0, "HLP_Ventas\\R_ResumenDocumentos.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-6 CellWidth_87_5", "left", "top", "", "", "div");
            wb_table2_123_5L2( true) ;
         }
         else
         {
            wb_table2_123_5L2( false) ;
         }
         return  ;
      }

      protected void wb_table2_123_5L2e( bool wbgen )
      {
         if ( wbgen )
         {
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
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 136,'',false,'',0)\"";
            ClassString = "ButtonPDF";
            StyleString = "";
            GxWebStd.gx_button_ctrl( context, bttBtnbtnimprimir_Internalname, "", "Imprimir", bttBtnbtnimprimir_Jsonclick, 5, "Imprimir", "", StyleString, ClassString, 1, 1, "standard", "'"+""+"'"+",false,"+"'"+"E\\'DOBTNIMPRIMIR\\'."+"'", TempTags, "", context.GetButtonType( ), "HLP_Ventas\\R_ResumenDocumentos.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "left", "top", "", "", "div");
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 138,'',false,'',0)\"";
            ClassString = "ButtonExcel";
            StyleString = "";
            GxWebStd.gx_button_ctrl( context, bttBtnbtnexcel_Internalname, "", "Excel", bttBtnbtnexcel_Jsonclick, 5, "Exportal a Excel", "", StyleString, ClassString, 1, 1, "standard", "'"+""+"'"+",false,"+"'"+"E\\'DOBTNEXCEL\\'."+"'", TempTags, "", context.GetButtonType( ), "HLP_Ventas\\R_ResumenDocumentos.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "left", "top", "", "", "div");
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 140,'',false,'',0)\"";
            ClassString = "ButtonColor";
            StyleString = "";
            GxWebStd.gx_button_ctrl( context, bttBtnbtnsalir_Internalname, "", "Salir", bttBtnbtnsalir_Jsonclick, 5, "Imprimir PDF", "", StyleString, ClassString, 1, 1, "standard", "'"+""+"'"+",false,"+"'"+"E\\'DOBTNSALIR\\'."+"'", TempTags, "", context.GetButtonType( ), "HLP_Ventas\\R_ResumenDocumentos.htm");
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
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 147,'',false,'',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavTiecod_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(AV44TieCod), 6, 0, ".", "")), StringUtil.LTrim( context.localUtil.Format( (decimal)(AV44TieCod), "ZZZZZ9")), " inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onblur(this,147);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavTiecod_Jsonclick, 0, "Attribute", "", "", "", "", edtavTiecod_Visible, 1, 0, "text", "1", 6, "chr", 1, "row", 6, 0, 0, 0, 1, -1, 0, true, "", "right", false, "", "HLP_Ventas\\R_ResumenDocumentos.htm");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 148,'',false,'',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavTipcod_Internalname, StringUtil.RTrim( AV34TipCod), StringUtil.RTrim( context.localUtil.Format( AV34TipCod, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,148);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavTipcod_Jsonclick, 0, "Attribute", "", "", "", "", edtavTipcod_Visible, 1, 0, "text", "", 3, "chr", 1, "row", 3, 0, 0, 0, 1, -1, -1, true, "", "left", true, "", "HLP_Ventas\\R_ResumenDocumentos.htm");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 149,'',false,'',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavTipccod_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(AV32TipCcod), 6, 0, ".", "")), StringUtil.LTrim( context.localUtil.Format( (decimal)(AV32TipCcod), "ZZZZZ9")), " inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onblur(this,149);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavTipccod_Jsonclick, 0, "Attribute", "", "", "", "", edtavTipccod_Visible, 1, 0, "text", "1", 6, "chr", 1, "row", 6, 0, 0, 0, 1, -1, 0, true, "", "right", false, "", "HLP_Ventas\\R_ResumenDocumentos.htm");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 150,'',false,'',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavEstcod_Internalname, StringUtil.RTrim( AV45EstCod), StringUtil.RTrim( context.localUtil.Format( AV45EstCod, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,150);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavEstcod_Jsonclick, 0, "Attribute", "", "", "", "", edtavEstcod_Visible, 1, 0, "text", "", 4, "chr", 1, "row", 4, 0, 0, 0, 1, -1, -1, true, "", "left", true, "", "HLP_Ventas\\R_ResumenDocumentos.htm");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 151,'',false,'',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavPaicod_Internalname, StringUtil.RTrim( AV46PaiCod), StringUtil.RTrim( context.localUtil.Format( AV46PaiCod, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,151);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavPaicod_Jsonclick, 0, "Attribute", "", "", "", "", edtavPaicod_Visible, 1, 0, "text", "", 4, "chr", 1, "row", 4, 0, 0, 0, 1, -1, -1, true, "", "left", true, "", "HLP_Ventas\\R_ResumenDocumentos.htm");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 152,'',false,'',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavDocconpcod_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(AV47DocConPCod), 6, 0, ".", "")), StringUtil.LTrim( context.localUtil.Format( (decimal)(AV47DocConPCod), "ZZZZZ9")), " inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onblur(this,152);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavDocconpcod_Jsonclick, 0, "Attribute", "", "", "", "", edtavDocconpcod_Visible, 1, 0, "text", "1", 6, "chr", 1, "row", 6, 0, 0, 0, 1, -1, 0, true, "", "right", false, "", "HLP_Ventas\\R_ResumenDocumentos.htm");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 153,'',false,'',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavVencod_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(AV40VenCod), 6, 0, ".", "")), StringUtil.LTrim( context.localUtil.Format( (decimal)(AV40VenCod), "ZZZZZ9")), " inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onblur(this,153);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavVencod_Jsonclick, 0, "Attribute", "", "", "", "", edtavVencod_Visible, 1, 0, "text", "1", 6, "chr", 1, "row", 6, 0, 0, 0, 1, -1, 0, true, "", "right", false, "", "HLP_Ventas\\R_ResumenDocumentos.htm");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 154,'',false,'',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavMoncod_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(AV23MonCod), 6, 0, ".", "")), StringUtil.LTrim( context.localUtil.Format( (decimal)(AV23MonCod), "ZZZZZ9")), " inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onblur(this,154);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavMoncod_Jsonclick, 0, "Attribute", "", "", "", "", edtavMoncod_Visible, 1, 0, "text", "1", 6, "chr", 1, "row", 6, 0, 0, 0, 1, -1, 0, true, "", "right", false, "", "HLP_Ventas\\R_ResumenDocumentos.htm");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 155,'',false,'',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavSerie_Internalname, StringUtil.RTrim( AV28Serie), StringUtil.RTrim( context.localUtil.Format( AV28Serie, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,155);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavSerie_Jsonclick, 0, "Attribute", "", "", "", "", edtavSerie_Visible, 1, 0, "text", "", 4, "chr", 1, "row", 4, 0, 0, 0, 1, -1, -1, true, "", "left", true, "", "HLP_Ventas\\R_ResumenDocumentos.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
         }
         wbLoad = true;
      }

      protected void START5L2( )
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
            Form.Meta.addItem("description", "Resumen de Documentos", 0) ;
         }
         context.wjLoc = "";
         context.nUserReturn = 0;
         context.wbHandled = 0;
         if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
         {
         }
         wbErr = false;
         STRUP5L0( ) ;
      }

      protected void WS5L2( )
      {
         START5L2( ) ;
         EVT5L2( ) ;
      }

      protected void EVT5L2( )
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
                              E115L2 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "'DOBTNIMPRIMIR'") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              /* Execute user event: 'DoBtnImprimir' */
                              E125L2 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "'DOBTNEXCEL'") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              /* Execute user event: 'DoBtnExcel' */
                              E135L2 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "'DOBTNSALIR'") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              /* Execute user event: 'DoBtnSalir' */
                              E145L2 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "LOAD") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              /* Execute user event: Load */
                              E155L2 ();
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

      protected void WE5L2( )
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

      protected void PA5L2( )
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
         if ( cmbavTipo.ItemCount > 0 )
         {
            AV38Tipo = cmbavTipo.getValidValue(AV38Tipo);
            AssignAttri("", false, "AV38Tipo", AV38Tipo);
         }
         if ( context.isAjaxRequest( ) )
         {
            cmbavTipo.CurrentValue = StringUtil.RTrim( AV38Tipo);
            AssignProp("", false, cmbavTipo_Internalname, "Values", cmbavTipo.ToJavascriptSource(), true);
         }
      }

      public void Refresh( )
      {
         send_integrity_hashes( ) ;
         RF5L2( ) ;
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

      protected void RF5L2( )
      {
         initialize_formulas( ) ;
         clear_multi_value_controls( ) ;
         gxdyncontrolsrefreshing = true;
         fix_multi_value_controls( ) ;
         gxdyncontrolsrefreshing = false;
         if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
         {
            /* Execute user event: Load */
            E155L2 ();
            WB5L0( ) ;
         }
      }

      protected void send_integrity_lvl_hashes5L2( )
      {
      }

      protected void before_start_formulas( )
      {
         context.Gx_err = 0;
         edtavClidsc_Enabled = 0;
         AssignProp("", false, edtavClidsc_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavClidsc_Enabled), 5, 0), true);
         fix_multi_value_controls( ) ;
      }

      protected void STRUP5L0( )
      {
         /* Before Start, stand alone formulas. */
         before_start_formulas( ) ;
         /* Execute Start event if defined. */
         context.wbGlbDoneStart = 0;
         /* Execute user event: Start */
         E115L2 ();
         context.wbGlbDoneStart = 1;
         /* After Start, stand alone formulas. */
         if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
         {
            /* Read saved SDTs. */
            ajax_req_read_hidden_sdt(cgiGet( "vTIECOD_DATA"), AV48TieCod_Data);
            ajax_req_read_hidden_sdt(cgiGet( "vTIPCOD_DATA"), AV35TipCod_Data);
            ajax_req_read_hidden_sdt(cgiGet( "vTIPCCOD_DATA"), AV33TipCcod_Data);
            ajax_req_read_hidden_sdt(cgiGet( "vESTCOD_DATA"), AV49EstCod_Data);
            ajax_req_read_hidden_sdt(cgiGet( "vPAICOD_DATA"), AV50PaiCod_Data);
            ajax_req_read_hidden_sdt(cgiGet( "vDOCCONPCOD_DATA"), AV51DocConPCod_Data);
            ajax_req_read_hidden_sdt(cgiGet( "vVENCOD_DATA"), AV41VenCod_Data);
            ajax_req_read_hidden_sdt(cgiGet( "vMONCOD_DATA"), AV24MonCod_Data);
            ajax_req_read_hidden_sdt(cgiGet( "vSERIE_DATA"), AV29Serie_Data);
            /* Read saved values. */
            Combo_tiecod_Cls = cgiGet( "COMBO_TIECOD_Cls");
            Combo_tiecod_Selectedvalue_set = cgiGet( "COMBO_TIECOD_Selectedvalue_set");
            Combo_tipcod_Cls = cgiGet( "COMBO_TIPCOD_Cls");
            Combo_tipcod_Selectedvalue_set = cgiGet( "COMBO_TIPCOD_Selectedvalue_set");
            Combo_tipccod_Cls = cgiGet( "COMBO_TIPCCOD_Cls");
            Combo_tipccod_Selectedvalue_set = cgiGet( "COMBO_TIPCCOD_Selectedvalue_set");
            Combo_estcod_Cls = cgiGet( "COMBO_ESTCOD_Cls");
            Combo_estcod_Selectedvalue_set = cgiGet( "COMBO_ESTCOD_Selectedvalue_set");
            Combo_paicod_Cls = cgiGet( "COMBO_PAICOD_Cls");
            Combo_paicod_Selectedvalue_set = cgiGet( "COMBO_PAICOD_Selectedvalue_set");
            Combo_docconpcod_Cls = cgiGet( "COMBO_DOCCONPCOD_Cls");
            Combo_docconpcod_Selectedvalue_set = cgiGet( "COMBO_DOCCONPCOD_Selectedvalue_set");
            Combo_vencod_Cls = cgiGet( "COMBO_VENCOD_Cls");
            Combo_vencod_Selectedvalue_set = cgiGet( "COMBO_VENCOD_Selectedvalue_set");
            Combo_moncod_Cls = cgiGet( "COMBO_MONCOD_Cls");
            Combo_moncod_Selectedvalue_set = cgiGet( "COMBO_MONCOD_Selectedvalue_set");
            Combo_serie_Cls = cgiGet( "COMBO_SERIE_Cls");
            Combo_serie_Selectedvalue_set = cgiGet( "COMBO_SERIE_Selectedvalue_set");
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
            AV5CliCod = cgiGet( edtavClicod_Internalname);
            AssignAttri("", false, "AV5CliCod", AV5CliCod);
            AV7CliDsc = cgiGet( edtavClidsc_Internalname);
            AssignAttri("", false, "AV7CliDsc", AV7CliDsc);
            cmbavTipo.CurrentValue = cgiGet( cmbavTipo_Internalname);
            AV38Tipo = cgiGet( cmbavTipo_Internalname);
            AssignAttri("", false, "AV38Tipo", AV38Tipo);
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
            if ( ( ( context.localUtil.CToN( cgiGet( edtavTiecod_Internalname), ".", ",") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtavTiecod_Internalname), ".", ",") > Convert.ToDecimal( 999999 )) ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "vTIECOD");
               GX_FocusControl = edtavTiecod_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               AV44TieCod = 0;
               AssignAttri("", false, "AV44TieCod", StringUtil.LTrimStr( (decimal)(AV44TieCod), 6, 0));
            }
            else
            {
               AV44TieCod = (int)(context.localUtil.CToN( cgiGet( edtavTiecod_Internalname), ".", ","));
               AssignAttri("", false, "AV44TieCod", StringUtil.LTrimStr( (decimal)(AV44TieCod), 6, 0));
            }
            AV34TipCod = cgiGet( edtavTipcod_Internalname);
            AssignAttri("", false, "AV34TipCod", AV34TipCod);
            if ( ( ( context.localUtil.CToN( cgiGet( edtavTipccod_Internalname), ".", ",") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtavTipccod_Internalname), ".", ",") > Convert.ToDecimal( 999999 )) ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "vTIPCCOD");
               GX_FocusControl = edtavTipccod_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               AV32TipCcod = 0;
               AssignAttri("", false, "AV32TipCcod", StringUtil.LTrimStr( (decimal)(AV32TipCcod), 6, 0));
            }
            else
            {
               AV32TipCcod = (int)(context.localUtil.CToN( cgiGet( edtavTipccod_Internalname), ".", ","));
               AssignAttri("", false, "AV32TipCcod", StringUtil.LTrimStr( (decimal)(AV32TipCcod), 6, 0));
            }
            AV45EstCod = cgiGet( edtavEstcod_Internalname);
            AssignAttri("", false, "AV45EstCod", AV45EstCod);
            AV46PaiCod = cgiGet( edtavPaicod_Internalname);
            AssignAttri("", false, "AV46PaiCod", AV46PaiCod);
            if ( ( ( context.localUtil.CToN( cgiGet( edtavDocconpcod_Internalname), ".", ",") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtavDocconpcod_Internalname), ".", ",") > Convert.ToDecimal( 999999 )) ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "vDOCCONPCOD");
               GX_FocusControl = edtavDocconpcod_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               AV47DocConPCod = 0;
               AssignAttri("", false, "AV47DocConPCod", StringUtil.LTrimStr( (decimal)(AV47DocConPCod), 6, 0));
            }
            else
            {
               AV47DocConPCod = (int)(context.localUtil.CToN( cgiGet( edtavDocconpcod_Internalname), ".", ","));
               AssignAttri("", false, "AV47DocConPCod", StringUtil.LTrimStr( (decimal)(AV47DocConPCod), 6, 0));
            }
            if ( ( ( context.localUtil.CToN( cgiGet( edtavVencod_Internalname), ".", ",") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtavVencod_Internalname), ".", ",") > Convert.ToDecimal( 999999 )) ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "vVENCOD");
               GX_FocusControl = edtavVencod_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               AV40VenCod = 0;
               AssignAttri("", false, "AV40VenCod", StringUtil.LTrimStr( (decimal)(AV40VenCod), 6, 0));
            }
            else
            {
               AV40VenCod = (int)(context.localUtil.CToN( cgiGet( edtavVencod_Internalname), ".", ","));
               AssignAttri("", false, "AV40VenCod", StringUtil.LTrimStr( (decimal)(AV40VenCod), 6, 0));
            }
            if ( ( ( context.localUtil.CToN( cgiGet( edtavMoncod_Internalname), ".", ",") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtavMoncod_Internalname), ".", ",") > Convert.ToDecimal( 999999 )) ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "vMONCOD");
               GX_FocusControl = edtavMoncod_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               AV23MonCod = 0;
               AssignAttri("", false, "AV23MonCod", StringUtil.LTrimStr( (decimal)(AV23MonCod), 6, 0));
            }
            else
            {
               AV23MonCod = (int)(context.localUtil.CToN( cgiGet( edtavMoncod_Internalname), ".", ","));
               AssignAttri("", false, "AV23MonCod", StringUtil.LTrimStr( (decimal)(AV23MonCod), 6, 0));
            }
            AV28Serie = cgiGet( edtavSerie_Internalname);
            AssignAttri("", false, "AV28Serie", AV28Serie);
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
         E115L2 ();
         if (returnInSub) return;
      }

      protected void E115L2( )
      {
         /* Start Routine */
         returnInSub = false;
         edtavSerie_Visible = 0;
         AssignProp("", false, edtavSerie_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavSerie_Visible), 5, 0), true);
         edtavMoncod_Visible = 0;
         AssignProp("", false, edtavMoncod_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavMoncod_Visible), 5, 0), true);
         edtavVencod_Visible = 0;
         AssignProp("", false, edtavVencod_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavVencod_Visible), 5, 0), true);
         edtavDocconpcod_Visible = 0;
         AssignProp("", false, edtavDocconpcod_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavDocconpcod_Visible), 5, 0), true);
         edtavPaicod_Visible = 0;
         AssignProp("", false, edtavPaicod_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavPaicod_Visible), 5, 0), true);
         edtavEstcod_Visible = 0;
         AssignProp("", false, edtavEstcod_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavEstcod_Visible), 5, 0), true);
         edtavTipccod_Visible = 0;
         AssignProp("", false, edtavTipccod_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavTipccod_Visible), 5, 0), true);
         edtavTipcod_Visible = 0;
         AssignProp("", false, edtavTipcod_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavTipcod_Visible), 5, 0), true);
         edtavTiecod_Visible = 0;
         AssignProp("", false, edtavTiecod_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavTiecod_Visible), 5, 0), true);
         /* Execute user subroutine: 'LOADCOMBOTIECOD' */
         S112 ();
         if (returnInSub) return;
         /* Execute user subroutine: 'LOADCOMBOTIPCOD' */
         S122 ();
         if (returnInSub) return;
         /* Execute user subroutine: 'LOADCOMBOTIPCCOD' */
         S132 ();
         if (returnInSub) return;
         /* Execute user subroutine: 'LOADCOMBOESTCOD' */
         S142 ();
         if (returnInSub) return;
         /* Execute user subroutine: 'LOADCOMBOPAICOD' */
         S152 ();
         if (returnInSub) return;
         /* Execute user subroutine: 'LOADCOMBODOCCONPCOD' */
         S162 ();
         if (returnInSub) return;
         /* Execute user subroutine: 'LOADCOMBOVENCOD' */
         S172 ();
         if (returnInSub) return;
         /* Execute user subroutine: 'LOADCOMBOMONCOD' */
         S182 ();
         if (returnInSub) return;
         /* Execute user subroutine: 'LOADCOMBOSERIE' */
         S192 ();
         if (returnInSub) return;
         AV38Tipo = "";
         AssignAttri("", false, "AV38Tipo", AV38Tipo);
      }

      protected void E125L2( )
      {
         /* 'DoBtnImprimir' Routine */
         returnInSub = false;
         GXKey = Crypto.GetSiteKey( );
         GXEncryptionTmp = "rrresumendocumentos.aspx"+UrlEncode(StringUtil.LTrimStr(AV32TipCcod,6,0)) + "," + UrlEncode(StringUtil.RTrim(AV45EstCod)) + "," + UrlEncode(StringUtil.RTrim(AV5CliCod)) + "," + UrlEncode(StringUtil.RTrim(AV34TipCod)) + "," + UrlEncode(StringUtil.RTrim(AV46PaiCod)) + "," + UrlEncode(DateTimeUtil.FormatDateParm(AV13FDesde)) + "," + UrlEncode(DateTimeUtil.FormatDateParm(AV15FHasta)) + "," + UrlEncode(StringUtil.LTrimStr(AV23MonCod,6,0)) + "," + UrlEncode(StringUtil.LTrimStr(AV47DocConPCod,6,0)) + "," + UrlEncode(StringUtil.RTrim(AV28Serie)) + "," + UrlEncode(StringUtil.RTrim(AV38Tipo)) + "," + UrlEncode(StringUtil.LTrimStr(AV44TieCod,6,0)) + "," + UrlEncode(StringUtil.LTrimStr(AV40VenCod,6,0));
         Innewwindow_Target = formatLink("rrresumendocumentos.aspx") + "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey);
         ucInnewwindow.SendProperty(context, "", false, Innewwindow_Internalname, "Target", Innewwindow_Target);
         this.executeUsercontrolMethod("", false, "INNEWWINDOWContainer", "OpenWindow", "", new Object[] {});
         /*  Sending Event outputs  */
      }

      protected void E135L2( )
      {
         /* 'DoBtnExcel' Routine */
         returnInSub = false;
         context.DoAjaxRefresh();
         new rresumendocumentosexcel(context ).execute( ref  AV32TipCcod, ref  AV45EstCod, ref  AV5CliCod, ref  AV34TipCod, ref  AV46PaiCod, ref  AV13FDesde, ref  AV15FHasta, ref  AV23MonCod, ref  AV47DocConPCod, ref  AV28Serie, ref  AV38Tipo, ref  AV44TieCod, ref  AV40VenCod, out  AV10ExcelFilename, out  AV9ErrorMessage) ;
         AssignAttri("", false, "AV32TipCcod", StringUtil.LTrimStr( (decimal)(AV32TipCcod), 6, 0));
         AssignAttri("", false, "AV45EstCod", AV45EstCod);
         AssignAttri("", false, "AV5CliCod", AV5CliCod);
         AssignAttri("", false, "AV34TipCod", AV34TipCod);
         AssignAttri("", false, "AV46PaiCod", AV46PaiCod);
         AssignAttri("", false, "AV13FDesde", context.localUtil.Format(AV13FDesde, "99/99/99"));
         AssignAttri("", false, "AV15FHasta", context.localUtil.Format(AV15FHasta, "99/99/99"));
         AssignAttri("", false, "AV23MonCod", StringUtil.LTrimStr( (decimal)(AV23MonCod), 6, 0));
         AssignAttri("", false, "AV47DocConPCod", StringUtil.LTrimStr( (decimal)(AV47DocConPCod), 6, 0));
         AssignAttri("", false, "AV28Serie", AV28Serie);
         AssignAttri("", false, "AV38Tipo", AV38Tipo);
         AssignAttri("", false, "AV44TieCod", StringUtil.LTrimStr( (decimal)(AV44TieCod), 6, 0));
         AssignAttri("", false, "AV40VenCod", StringUtil.LTrimStr( (decimal)(AV40VenCod), 6, 0));
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
         cmbavTipo.CurrentValue = StringUtil.RTrim( AV38Tipo);
         AssignProp("", false, cmbavTipo_Internalname, "Values", cmbavTipo.ToJavascriptSource(), true);
      }

      protected void E145L2( )
      {
         /* 'DoBtnSalir' Routine */
         returnInSub = false;
         CallWebObject(formatLink("wwpbaseobjects.home.aspx") );
         context.wjLocDisableFrm = 1;
      }

      protected void S192( )
      {
         /* 'LOADCOMBOSERIE' Routine */
         returnInSub = false;
         /* Using cursor H005L2 */
         pr_default.execute(0);
         while ( (pr_default.getStatus(0) != 101) )
         {
            A340CorSerie = H005L2_A340CorSerie[0];
            A339CorDoc = H005L2_A339CorDoc[0];
            AV8Combo_DataItem = new GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTComboData_Item(context);
            AV8Combo_DataItem.gxTpr_Id = A340CorSerie;
            AV8Combo_DataItem.gxTpr_Title = A339CorDoc;
            AV29Serie_Data.Add(AV8Combo_DataItem, 0);
            pr_default.readNext(0);
         }
         pr_default.close(0);
         Combo_serie_Selectedvalue_set = AV28Serie;
         ucCombo_serie.SendProperty(context, "", false, Combo_serie_Internalname, "SelectedValue_set", Combo_serie_Selectedvalue_set);
      }

      protected void S182( )
      {
         /* 'LOADCOMBOMONCOD' Routine */
         returnInSub = false;
         /* Using cursor H005L3 */
         pr_default.execute(1);
         while ( (pr_default.getStatus(1) != 101) )
         {
            A1235MonSts = H005L3_A1235MonSts[0];
            A180MonCod = H005L3_A180MonCod[0];
            A1234MonDsc = H005L3_A1234MonDsc[0];
            AV8Combo_DataItem = new GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTComboData_Item(context);
            AV8Combo_DataItem.gxTpr_Id = StringUtil.Trim( StringUtil.Str( (decimal)(A180MonCod), 6, 0));
            AV8Combo_DataItem.gxTpr_Title = A1234MonDsc;
            AV24MonCod_Data.Add(AV8Combo_DataItem, 0);
            pr_default.readNext(1);
         }
         pr_default.close(1);
         Combo_moncod_Selectedvalue_set = ((0==AV23MonCod) ? "" : StringUtil.Trim( StringUtil.Str( (decimal)(AV23MonCod), 6, 0)));
         ucCombo_moncod.SendProperty(context, "", false, Combo_moncod_Internalname, "SelectedValue_set", Combo_moncod_Selectedvalue_set);
      }

      protected void S172( )
      {
         /* 'LOADCOMBOVENCOD' Routine */
         returnInSub = false;
         /* Using cursor H005L4 */
         pr_default.execute(2);
         while ( (pr_default.getStatus(2) != 101) )
         {
            A2047VenSts = H005L4_A2047VenSts[0];
            A309VenCod = H005L4_A309VenCod[0];
            A2045VenDsc = H005L4_A2045VenDsc[0];
            AV8Combo_DataItem = new GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTComboData_Item(context);
            AV8Combo_DataItem.gxTpr_Id = StringUtil.Trim( StringUtil.Str( (decimal)(A309VenCod), 6, 0));
            AV8Combo_DataItem.gxTpr_Title = A2045VenDsc;
            AV41VenCod_Data.Add(AV8Combo_DataItem, 0);
            pr_default.readNext(2);
         }
         pr_default.close(2);
         Combo_vencod_Selectedvalue_set = ((0==AV40VenCod) ? "" : StringUtil.Trim( StringUtil.Str( (decimal)(AV40VenCod), 6, 0)));
         ucCombo_vencod.SendProperty(context, "", false, Combo_vencod_Internalname, "SelectedValue_set", Combo_vencod_Selectedvalue_set);
      }

      protected void S162( )
      {
         /* 'LOADCOMBODOCCONPCOD' Routine */
         returnInSub = false;
         /* Using cursor H005L5 */
         pr_default.execute(3);
         while ( (pr_default.getStatus(3) != 101) )
         {
            A754ConpSts = H005L5_A754ConpSts[0];
            A137Conpcod = H005L5_A137Conpcod[0];
            A753ConpDsc = H005L5_A753ConpDsc[0];
            AV8Combo_DataItem = new GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTComboData_Item(context);
            AV8Combo_DataItem.gxTpr_Id = StringUtil.Trim( StringUtil.Str( (decimal)(A137Conpcod), 6, 0));
            AV8Combo_DataItem.gxTpr_Title = A753ConpDsc;
            AV51DocConPCod_Data.Add(AV8Combo_DataItem, 0);
            pr_default.readNext(3);
         }
         pr_default.close(3);
         Combo_docconpcod_Selectedvalue_set = ((0==AV47DocConPCod) ? "" : StringUtil.Trim( StringUtil.Str( (decimal)(AV47DocConPCod), 6, 0)));
         ucCombo_docconpcod.SendProperty(context, "", false, Combo_docconpcod_Internalname, "SelectedValue_set", Combo_docconpcod_Selectedvalue_set);
      }

      protected void S152( )
      {
         /* 'LOADCOMBOPAICOD' Routine */
         returnInSub = false;
         /* Using cursor H005L6 */
         pr_default.execute(4);
         while ( (pr_default.getStatus(4) != 101) )
         {
            A1501PaiSts = H005L6_A1501PaiSts[0];
            A139PaiCod = H005L6_A139PaiCod[0];
            A1500PaiDsc = H005L6_A1500PaiDsc[0];
            AV8Combo_DataItem = new GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTComboData_Item(context);
            AV8Combo_DataItem.gxTpr_Id = A139PaiCod;
            AV8Combo_DataItem.gxTpr_Title = A1500PaiDsc;
            AV50PaiCod_Data.Add(AV8Combo_DataItem, 0);
            pr_default.readNext(4);
         }
         pr_default.close(4);
         Combo_paicod_Selectedvalue_set = AV46PaiCod;
         ucCombo_paicod.SendProperty(context, "", false, Combo_paicod_Internalname, "SelectedValue_set", Combo_paicod_Selectedvalue_set);
      }

      protected void S142( )
      {
         /* 'LOADCOMBOESTCOD' Routine */
         returnInSub = false;
         /* Using cursor H005L7 */
         pr_default.execute(5);
         while ( (pr_default.getStatus(5) != 101) )
         {
            A975EstSts = H005L7_A975EstSts[0];
            A140EstCod = H005L7_A140EstCod[0];
            A602EstDsc = H005L7_A602EstDsc[0];
            AV8Combo_DataItem = new GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTComboData_Item(context);
            AV8Combo_DataItem.gxTpr_Id = A140EstCod;
            AV8Combo_DataItem.gxTpr_Title = A602EstDsc;
            AV49EstCod_Data.Add(AV8Combo_DataItem, 0);
            pr_default.readNext(5);
         }
         pr_default.close(5);
         Combo_estcod_Selectedvalue_set = AV45EstCod;
         ucCombo_estcod.SendProperty(context, "", false, Combo_estcod_Internalname, "SelectedValue_set", Combo_estcod_Selectedvalue_set);
      }

      protected void S132( )
      {
         /* 'LOADCOMBOTIPCCOD' Routine */
         returnInSub = false;
         /* Using cursor H005L8 */
         pr_default.execute(6);
         while ( (pr_default.getStatus(6) != 101) )
         {
            A1908TipCSts = H005L8_A1908TipCSts[0];
            A159TipCCod = H005L8_A159TipCCod[0];
            A1905TipCDsc = H005L8_A1905TipCDsc[0];
            AV8Combo_DataItem = new GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTComboData_Item(context);
            AV8Combo_DataItem.gxTpr_Id = StringUtil.Trim( StringUtil.Str( (decimal)(A159TipCCod), 6, 0));
            AV8Combo_DataItem.gxTpr_Title = A1905TipCDsc;
            AV33TipCcod_Data.Add(AV8Combo_DataItem, 0);
            pr_default.readNext(6);
         }
         pr_default.close(6);
         Combo_tipccod_Selectedvalue_set = ((0==AV32TipCcod) ? "" : StringUtil.Trim( StringUtil.Str( (decimal)(AV32TipCcod), 6, 0)));
         ucCombo_tipccod.SendProperty(context, "", false, Combo_tipccod_Internalname, "SelectedValue_set", Combo_tipccod_Selectedvalue_set);
      }

      protected void S122( )
      {
         /* 'LOADCOMBOTIPCOD' Routine */
         returnInSub = false;
         /* Using cursor H005L9 */
         pr_default.execute(7);
         while ( (pr_default.getStatus(7) != 101) )
         {
            A1919TipSts = H005L9_A1919TipSts[0];
            A149TipCod = H005L9_A149TipCod[0];
            A1910TipDsc = H005L9_A1910TipDsc[0];
            AV8Combo_DataItem = new GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTComboData_Item(context);
            AV8Combo_DataItem.gxTpr_Id = A149TipCod;
            AV8Combo_DataItem.gxTpr_Title = A1910TipDsc;
            AV35TipCod_Data.Add(AV8Combo_DataItem, 0);
            pr_default.readNext(7);
         }
         pr_default.close(7);
         Combo_tipcod_Selectedvalue_set = AV34TipCod;
         ucCombo_tipcod.SendProperty(context, "", false, Combo_tipcod_Internalname, "SelectedValue_set", Combo_tipcod_Selectedvalue_set);
      }

      protected void S112( )
      {
         /* 'LOADCOMBOTIECOD' Routine */
         returnInSub = false;
         /* Using cursor H005L10 */
         pr_default.execute(8);
         while ( (pr_default.getStatus(8) != 101) )
         {
            A1899TieSts = H005L10_A1899TieSts[0];
            A178TieCod = H005L10_A178TieCod[0];
            A1898TieDsc = H005L10_A1898TieDsc[0];
            AV8Combo_DataItem = new GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTComboData_Item(context);
            AV8Combo_DataItem.gxTpr_Id = StringUtil.Trim( StringUtil.Str( (decimal)(A178TieCod), 6, 0));
            AV8Combo_DataItem.gxTpr_Title = A1898TieDsc;
            AV48TieCod_Data.Add(AV8Combo_DataItem, 0);
            pr_default.readNext(8);
         }
         pr_default.close(8);
         Combo_tiecod_Selectedvalue_set = ((0==AV44TieCod) ? "" : StringUtil.Trim( StringUtil.Str( (decimal)(AV44TieCod), 6, 0)));
         ucCombo_tiecod.SendProperty(context, "", false, Combo_tiecod_Internalname, "SelectedValue_set", Combo_tiecod_Selectedvalue_set);
      }

      protected void nextLoad( )
      {
      }

      protected void E155L2( )
      {
         /* Load Routine */
         returnInSub = false;
      }

      protected void wb_table2_123_5L2( bool wbgen )
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
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 127,'',false,'',0)\"";
            context.WriteHtmlText( "<div id=\""+edtavFdesde_Internalname+"_dp_container\" class=\"dp_container\" style=\"white-space:nowrap;display:inline;\">") ;
            GxWebStd.gx_single_line_edit( context, edtavFdesde_Internalname, context.localUtil.Format(AV13FDesde, "99/99/99"), context.localUtil.Format( AV13FDesde, "99/99/99"), TempTags+" onchange=\""+"gx.date.valid_date(this, 8,'DMY',0,24,'spa',false,0);"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.date.valid_date(this, 8,'DMY',0,24,'spa',false,0);"+";gx.evt.onblur(this,127);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavFdesde_Jsonclick, 0, "AttributeDate", "", "", "", "", 1, edtavFdesde_Enabled, 0, "text", "", 8, "chr", 1, "row", 8, 0, 0, 0, 1, -1, 0, true, "", "right", false, "", "HLP_Ventas\\R_ResumenDocumentos.htm");
            GxWebStd.gx_bitmap( context, edtavFdesde_Internalname+"_dp_trigger", context.GetImagePath( "61b9b5d3-dff6-4d59-9b00-da61bc2cbe93", "", context.GetTheme( )), "", "", "", "", ((1==0)||(edtavFdesde_Enabled==0) ? 0 : 1), 0, "Date selector", "Date selector", 0, 1, 0, "", 0, "", 0, 0, 0, "", "", "cursor: pointer;", "", "", "", "", "", "", "", "", 1, false, false, "", "HLP_Ventas\\R_ResumenDocumentos.htm");
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
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 131,'',false,'',0)\"";
            context.WriteHtmlText( "<div id=\""+edtavFhasta_Internalname+"_dp_container\" class=\"dp_container\" style=\"white-space:nowrap;display:inline;\">") ;
            GxWebStd.gx_single_line_edit( context, edtavFhasta_Internalname, context.localUtil.Format(AV15FHasta, "99/99/99"), context.localUtil.Format( AV15FHasta, "99/99/99"), TempTags+" onchange=\""+"gx.date.valid_date(this, 8,'DMY',0,24,'spa',false,0);"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.date.valid_date(this, 8,'DMY',0,24,'spa',false,0);"+";gx.evt.onblur(this,131);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavFhasta_Jsonclick, 0, "AttributeDate", "", "", "", "", 1, edtavFhasta_Enabled, 0, "text", "", 8, "chr", 1, "row", 8, 0, 0, 0, 1, -1, 0, true, "", "right", false, "", "HLP_Ventas\\R_ResumenDocumentos.htm");
            GxWebStd.gx_bitmap( context, edtavFhasta_Internalname+"_dp_trigger", context.GetImagePath( "61b9b5d3-dff6-4d59-9b00-da61bc2cbe93", "", context.GetTheme( )), "", "", "", "", ((1==0)||(edtavFhasta_Enabled==0) ? 0 : 1), 0, "Date selector", "Date selector", 0, 1, 0, "", 0, "", 0, 0, 0, "", "", "cursor: pointer;", "", "", "", "", "", "", "", "", 1, false, false, "", "HLP_Ventas\\R_ResumenDocumentos.htm");
            context.WriteHtmlTextNl( "</div>") ;
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "</tr>") ;
            /* End of table */
            context.WriteHtmlText( "</table>") ;
            wb_table2_123_5L2e( true) ;
         }
         else
         {
            wb_table2_123_5L2e( false) ;
         }
      }

      protected void wb_table1_81_5L2( bool wbgen )
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
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 85,'',false,'',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavClicod_Internalname, StringUtil.RTrim( AV5CliCod), StringUtil.RTrim( context.localUtil.Format( AV5CliCod, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,85);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavClicod_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtavClicod_Enabled, 0, "text", "", 20, "chr", 1, "row", 20, 0, 0, 0, 1, -1, -1, true, "", "left", true, "", "HLP_Ventas\\R_ResumenDocumentos.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "<td class='CellPaddingLeft10'>") ;
            /* Active images/pictures */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 87,'',false,'',0)\"";
            ClassString = "Image";
            StyleString = "";
            sImgUrl = (string)(context.GetImagePath( "f5b04895-0024-488b-8e3b-b687ca4598ee", "", context.GetTheme( )));
            GxWebStd.gx_bitmap( context, imgBtnbuscar_Internalname, sImgUrl, "", "", "", context.GetTheme( ), 1, 1, "", "Buscar Cliente", 0, 0, 0, "px", 0, "px", 0, 0, 7, imgBtnbuscar_Jsonclick, "'"+""+"'"+",false,"+"'"+"e165l1_client"+"'", StyleString, ClassString, "", "", "", "", " "+"data-gx-image"+" "+TempTags, "", "", 1, false, false, context.GetImageSrcSet( sImgUrl), "HLP_Ventas\\R_ResumenDocumentos.htm");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "<td class='DataContentCell'>") ;
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "left", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavClidsc_Internalname, "Descripci?n Cliente", "gx-form-item ReadonlyAttributeLabel", 0, true, "width: 25%;");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 90,'',false,'',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavClidsc_Internalname, StringUtil.RTrim( AV7CliDsc), StringUtil.RTrim( context.localUtil.Format( AV7CliDsc, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,90);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavClidsc_Jsonclick, 0, "ReadonlyAttribute", "", "", "", "", 1, edtavClidsc_Enabled, 0, "text", "", 80, "chr", 1, "row", 100, 0, 0, 0, 1, -1, -1, true, "", "left", true, "", "HLP_Ventas\\R_ResumenDocumentos.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "</tr>") ;
            /* End of table */
            context.WriteHtmlText( "</table>") ;
            wb_table1_81_5L2e( true) ;
         }
         else
         {
            wb_table1_81_5L2e( false) ;
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
         PA5L2( ) ;
         WS5L2( ) ;
         WE5L2( ) ;
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
            context.AddJavascriptSource(StringUtil.RTrim( ((string)Form.Jscriptsrc.Item(idxLst))), "?202281810315355", true, true);
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
         context.AddJavascriptSource("ventas/r_resumendocumentos.js", "?202281810315356", false, true);
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
         cmbavTipo.Name = "vTIPO";
         cmbavTipo.WebTags = "";
         cmbavTipo.addItem("", "Todos", 0);
         cmbavTipo.addItem("", "Pendientes", 0);
         cmbavTipo.addItem("V", "Venta", 0);
         cmbavTipo.addItem("M", "Muestras", 0);
         if ( cmbavTipo.ItemCount > 0 )
         {
            AV38Tipo = cmbavTipo.getValidValue(AV38Tipo);
            AssignAttri("", false, "AV38Tipo", AV38Tipo);
         }
         /* End function init_web_controls */
      }

      protected void init_default_properties( )
      {
         lblTextblockcombo_tiecod_Internalname = "TEXTBLOCKCOMBO_TIECOD";
         Combo_tiecod_Internalname = "COMBO_TIECOD";
         divTablesplittedtiecod_Internalname = "TABLESPLITTEDTIECOD";
         lblTextblockcombo_tipcod_Internalname = "TEXTBLOCKCOMBO_TIPCOD";
         Combo_tipcod_Internalname = "COMBO_TIPCOD";
         divTablesplittedtipcod_Internalname = "TABLESPLITTEDTIPCOD";
         lblTextblockcombo_tipccod_Internalname = "TEXTBLOCKCOMBO_TIPCCOD";
         Combo_tipccod_Internalname = "COMBO_TIPCCOD";
         divTablesplittedtipccod_Internalname = "TABLESPLITTEDTIPCCOD";
         lblTextblockcombo_estcod_Internalname = "TEXTBLOCKCOMBO_ESTCOD";
         Combo_estcod_Internalname = "COMBO_ESTCOD";
         divTablesplittedestcod_Internalname = "TABLESPLITTEDESTCOD";
         lblTextblockcombo_paicod_Internalname = "TEXTBLOCKCOMBO_PAICOD";
         Combo_paicod_Internalname = "COMBO_PAICOD";
         divTablesplittedpaicod_Internalname = "TABLESPLITTEDPAICOD";
         lblTextblockcombo_docconpcod_Internalname = "TEXTBLOCKCOMBO_DOCCONPCOD";
         Combo_docconpcod_Internalname = "COMBO_DOCCONPCOD";
         divTablesplitteddocconpcod_Internalname = "TABLESPLITTEDDOCCONPCOD";
         lblTextblockcombo_vencod_Internalname = "TEXTBLOCKCOMBO_VENCOD";
         Combo_vencod_Internalname = "COMBO_VENCOD";
         divTablesplittedvencod_Internalname = "TABLESPLITTEDVENCOD";
         lblTextblockclicod_Internalname = "TEXTBLOCKCLICOD";
         edtavClicod_Internalname = "vCLICOD";
         imgBtnbuscar_Internalname = "BTNBUSCAR";
         edtavClidsc_Internalname = "vCLIDSC";
         tblTablemergedclicod_Internalname = "TABLEMERGEDCLICOD";
         divTablesplittedclicod_Internalname = "TABLESPLITTEDCLICOD";
         lblTextblockcombo_moncod_Internalname = "TEXTBLOCKCOMBO_MONCOD";
         Combo_moncod_Internalname = "COMBO_MONCOD";
         divTablesplittedmoncod_Internalname = "TABLESPLITTEDMONCOD";
         lblTextblocktipo_Internalname = "TEXTBLOCKTIPO";
         cmbavTipo_Internalname = "vTIPO";
         divUnnamedtabletipo_Internalname = "UNNAMEDTABLETIPO";
         lblTextblockcombo_serie_Internalname = "TEXTBLOCKCOMBO_SERIE";
         Combo_serie_Internalname = "COMBO_SERIE";
         divTablesplittedserie_Internalname = "TABLESPLITTEDSERIE";
         lblTextblockfdesde_Internalname = "TEXTBLOCKFDESDE";
         edtavFdesde_Internalname = "vFDESDE";
         edtavFhasta_Internalname = "vFHASTA";
         tblTablemergedfdesde_Internalname = "TABLEMERGEDFDESDE";
         divTablesplittedfdesde_Internalname = "TABLESPLITTEDFDESDE";
         divPanel1_Internalname = "PANEL1";
         Dvpanel_panel1_Internalname = "DVPANEL_PANEL1";
         bttBtnbtnimprimir_Internalname = "BTNBTNIMPRIMIR";
         bttBtnbtnexcel_Internalname = "BTNBTNEXCEL";
         bttBtnbtnsalir_Internalname = "BTNBTNSALIR";
         Innewwindow_Internalname = "INNEWWINDOW";
         divTablecontent_Internalname = "TABLECONTENT";
         divTablemain_Internalname = "TABLEMAIN";
         edtavTiecod_Internalname = "vTIECOD";
         edtavTipcod_Internalname = "vTIPCOD";
         edtavTipccod_Internalname = "vTIPCCOD";
         edtavEstcod_Internalname = "vESTCOD";
         edtavPaicod_Internalname = "vPAICOD";
         edtavDocconpcod_Internalname = "vDOCCONPCOD";
         edtavVencod_Internalname = "vVENCOD";
         edtavMoncod_Internalname = "vMONCOD";
         edtavSerie_Internalname = "vSERIE";
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
         edtavFhasta_Jsonclick = "";
         edtavFhasta_Enabled = 1;
         edtavFdesde_Jsonclick = "";
         edtavFdesde_Enabled = 1;
         edtavSerie_Jsonclick = "";
         edtavSerie_Visible = 1;
         edtavMoncod_Jsonclick = "";
         edtavMoncod_Visible = 1;
         edtavVencod_Jsonclick = "";
         edtavVencod_Visible = 1;
         edtavDocconpcod_Jsonclick = "";
         edtavDocconpcod_Visible = 1;
         edtavPaicod_Jsonclick = "";
         edtavPaicod_Visible = 1;
         edtavEstcod_Jsonclick = "";
         edtavEstcod_Visible = 1;
         edtavTipccod_Jsonclick = "";
         edtavTipccod_Visible = 1;
         edtavTipcod_Jsonclick = "";
         edtavTipcod_Visible = 1;
         edtavTiecod_Jsonclick = "";
         edtavTiecod_Visible = 1;
         cmbavTipo_Jsonclick = "";
         cmbavTipo.Enabled = 1;
         Innewwindow_Target = "";
         Dvpanel_panel1_Autoscroll = Convert.ToBoolean( 0);
         Dvpanel_panel1_Iconposition = "Right";
         Dvpanel_panel1_Showcollapseicon = Convert.ToBoolean( 0);
         Dvpanel_panel1_Collapsed = Convert.ToBoolean( 0);
         Dvpanel_panel1_Collapsible = Convert.ToBoolean( -1);
         Dvpanel_panel1_Title = "Reporte de Resumen de Documentos";
         Dvpanel_panel1_Cls = "PanelFilled Panel_BaseColor";
         Dvpanel_panel1_Autoheight = Convert.ToBoolean( -1);
         Dvpanel_panel1_Autowidth = Convert.ToBoolean( 0);
         Dvpanel_panel1_Width = "100%";
         Combo_serie_Cls = "ExtendedCombo AttributeRealWidth50With";
         Combo_moncod_Cls = "ExtendedCombo AttributeRealWidth50With";
         Combo_vencod_Cls = "ExtendedCombo AttributeRealWidth50With";
         Combo_docconpcod_Cls = "ExtendedCombo AttributeRealWidth50With";
         Combo_paicod_Cls = "ExtendedCombo AttributeRealWidth50With";
         Combo_estcod_Cls = "ExtendedCombo AttributeRealWidth50With";
         Combo_tipccod_Cls = "ExtendedCombo AttributeRealWidth50With";
         Combo_tipcod_Cls = "ExtendedCombo AttributeRealWidth50With";
         Combo_tiecod_Cls = "ExtendedCombo AttributeRealWidth50With";
         Form.Headerrawhtml = "";
         Form.Background = "";
         Form.Textcolor = 0;
         Form.Backcolor = (int)(0xFFFFFF);
         Form.Caption = "Resumen de Documentos";
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
         setEventMetadata("'DOBTNIMPRIMIR'","{handler:'E125L2',iparms:[{av:'AV32TipCcod',fld:'vTIPCCOD',pic:'ZZZZZ9'},{av:'AV45EstCod',fld:'vESTCOD',pic:''},{av:'AV5CliCod',fld:'vCLICOD',pic:''},{av:'AV34TipCod',fld:'vTIPCOD',pic:''},{av:'AV46PaiCod',fld:'vPAICOD',pic:''},{av:'AV13FDesde',fld:'vFDESDE',pic:''},{av:'AV15FHasta',fld:'vFHASTA',pic:''},{av:'AV23MonCod',fld:'vMONCOD',pic:'ZZZZZ9'},{av:'AV47DocConPCod',fld:'vDOCCONPCOD',pic:'ZZZZZ9'},{av:'AV28Serie',fld:'vSERIE',pic:''},{av:'cmbavTipo'},{av:'AV38Tipo',fld:'vTIPO',pic:''},{av:'AV44TieCod',fld:'vTIECOD',pic:'ZZZZZ9'},{av:'AV40VenCod',fld:'vVENCOD',pic:'ZZZZZ9'}]");
         setEventMetadata("'DOBTNIMPRIMIR'",",oparms:[{av:'Innewwindow_Target',ctrl:'INNEWWINDOW',prop:'Target'}]}");
         setEventMetadata("'DOBTNEXCEL'","{handler:'E135L2',iparms:[{av:'AV32TipCcod',fld:'vTIPCCOD',pic:'ZZZZZ9'},{av:'AV45EstCod',fld:'vESTCOD',pic:''},{av:'AV5CliCod',fld:'vCLICOD',pic:''},{av:'AV34TipCod',fld:'vTIPCOD',pic:''},{av:'AV46PaiCod',fld:'vPAICOD',pic:''},{av:'AV13FDesde',fld:'vFDESDE',pic:''},{av:'AV15FHasta',fld:'vFHASTA',pic:''},{av:'AV23MonCod',fld:'vMONCOD',pic:'ZZZZZ9'},{av:'AV47DocConPCod',fld:'vDOCCONPCOD',pic:'ZZZZZ9'},{av:'AV28Serie',fld:'vSERIE',pic:''},{av:'cmbavTipo'},{av:'AV38Tipo',fld:'vTIPO',pic:''},{av:'AV44TieCod',fld:'vTIECOD',pic:'ZZZZZ9'},{av:'AV40VenCod',fld:'vVENCOD',pic:'ZZZZZ9'}]");
         setEventMetadata("'DOBTNEXCEL'",",oparms:[{av:'AV40VenCod',fld:'vVENCOD',pic:'ZZZZZ9'},{av:'AV44TieCod',fld:'vTIECOD',pic:'ZZZZZ9'},{av:'cmbavTipo'},{av:'AV38Tipo',fld:'vTIPO',pic:''},{av:'AV28Serie',fld:'vSERIE',pic:''},{av:'AV47DocConPCod',fld:'vDOCCONPCOD',pic:'ZZZZZ9'},{av:'AV23MonCod',fld:'vMONCOD',pic:'ZZZZZ9'},{av:'AV15FHasta',fld:'vFHASTA',pic:''},{av:'AV13FDesde',fld:'vFDESDE',pic:''},{av:'AV46PaiCod',fld:'vPAICOD',pic:''},{av:'AV34TipCod',fld:'vTIPCOD',pic:''},{av:'AV5CliCod',fld:'vCLICOD',pic:''},{av:'AV45EstCod',fld:'vESTCOD',pic:''},{av:'AV32TipCcod',fld:'vTIPCCOD',pic:'ZZZZZ9'}]}");
         setEventMetadata("'DOBTNSALIR'","{handler:'E145L2',iparms:[]");
         setEventMetadata("'DOBTNSALIR'",",oparms:[]}");
         setEventMetadata("BTNBUSCAR.CLICK","{handler:'E165L1',iparms:[]");
         setEventMetadata("BTNBUSCAR.CLICK",",oparms:[{av:'AV7CliDsc',fld:'vCLIDSC',pic:''},{av:'AV5CliCod',fld:'vCLICOD',pic:''}]}");
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
         Combo_serie_Selectedvalue_get = "";
         Combo_moncod_Selectedvalue_get = "";
         Combo_vencod_Selectedvalue_get = "";
         Combo_docconpcod_Selectedvalue_get = "";
         Combo_paicod_Selectedvalue_get = "";
         Combo_estcod_Selectedvalue_get = "";
         Combo_tipccod_Selectedvalue_get = "";
         Combo_tipcod_Selectedvalue_get = "";
         Combo_tiecod_Selectedvalue_get = "";
         gxfirstwebparm = "";
         gxfirstwebparm_bkp = "";
         sDynURL = "";
         FormProcess = "";
         bodyStyle = "";
         GXKey = "";
         AV48TieCod_Data = new GXBaseCollection<GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTComboData_Item>( context, "Item", "");
         AV35TipCod_Data = new GXBaseCollection<GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTComboData_Item>( context, "Item", "");
         AV33TipCcod_Data = new GXBaseCollection<GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTComboData_Item>( context, "Item", "");
         AV49EstCod_Data = new GXBaseCollection<GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTComboData_Item>( context, "Item", "");
         AV50PaiCod_Data = new GXBaseCollection<GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTComboData_Item>( context, "Item", "");
         AV51DocConPCod_Data = new GXBaseCollection<GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTComboData_Item>( context, "Item", "");
         AV41VenCod_Data = new GXBaseCollection<GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTComboData_Item>( context, "Item", "");
         AV24MonCod_Data = new GXBaseCollection<GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTComboData_Item>( context, "Item", "");
         AV29Serie_Data = new GXBaseCollection<GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTComboData_Item>( context, "Item", "");
         Combo_tiecod_Selectedvalue_set = "";
         Combo_tipcod_Selectedvalue_set = "";
         Combo_tipccod_Selectedvalue_set = "";
         Combo_estcod_Selectedvalue_set = "";
         Combo_paicod_Selectedvalue_set = "";
         Combo_docconpcod_Selectedvalue_set = "";
         Combo_vencod_Selectedvalue_set = "";
         Combo_moncod_Selectedvalue_set = "";
         Combo_serie_Selectedvalue_set = "";
         GX_FocusControl = "";
         Form = new GXWebForm();
         sPrefix = "";
         ClassString = "";
         StyleString = "";
         ucDvpanel_panel1 = new GXUserControl();
         lblTextblockcombo_tiecod_Jsonclick = "";
         ucCombo_tiecod = new GXUserControl();
         Combo_tiecod_Caption = "";
         lblTextblockcombo_tipcod_Jsonclick = "";
         ucCombo_tipcod = new GXUserControl();
         Combo_tipcod_Caption = "";
         lblTextblockcombo_tipccod_Jsonclick = "";
         ucCombo_tipccod = new GXUserControl();
         Combo_tipccod_Caption = "";
         lblTextblockcombo_estcod_Jsonclick = "";
         ucCombo_estcod = new GXUserControl();
         Combo_estcod_Caption = "";
         lblTextblockcombo_paicod_Jsonclick = "";
         ucCombo_paicod = new GXUserControl();
         Combo_paicod_Caption = "";
         lblTextblockcombo_docconpcod_Jsonclick = "";
         ucCombo_docconpcod = new GXUserControl();
         Combo_docconpcod_Caption = "";
         lblTextblockcombo_vencod_Jsonclick = "";
         ucCombo_vencod = new GXUserControl();
         Combo_vencod_Caption = "";
         lblTextblockclicod_Jsonclick = "";
         lblTextblockcombo_moncod_Jsonclick = "";
         ucCombo_moncod = new GXUserControl();
         Combo_moncod_Caption = "";
         lblTextblocktipo_Jsonclick = "";
         TempTags = "";
         AV38Tipo = "";
         lblTextblockcombo_serie_Jsonclick = "";
         ucCombo_serie = new GXUserControl();
         Combo_serie_Caption = "";
         lblTextblockfdesde_Jsonclick = "";
         bttBtnbtnimprimir_Jsonclick = "";
         bttBtnbtnexcel_Jsonclick = "";
         bttBtnbtnsalir_Jsonclick = "";
         ucInnewwindow = new GXUserControl();
         AV34TipCod = "";
         AV45EstCod = "";
         AV46PaiCod = "";
         AV28Serie = "";
         sEvt = "";
         EvtGridId = "";
         EvtRowId = "";
         sEvtType = "";
         AV5CliCod = "";
         AV7CliDsc = "";
         AV13FDesde = DateTime.MinValue;
         AV15FHasta = DateTime.MinValue;
         GXEncryptionTmp = "";
         AV10ExcelFilename = "";
         AV9ErrorMessage = "";
         scmdbuf = "";
         H005L2_A340CorSerie = new string[] {""} ;
         H005L2_A339CorDoc = new string[] {""} ;
         A340CorSerie = "";
         A339CorDoc = "";
         AV8Combo_DataItem = new GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTComboData_Item(context);
         H005L3_A1235MonSts = new short[1] ;
         H005L3_A180MonCod = new int[1] ;
         H005L3_A1234MonDsc = new string[] {""} ;
         A1234MonDsc = "";
         H005L4_A2047VenSts = new short[1] ;
         H005L4_A309VenCod = new int[1] ;
         H005L4_A2045VenDsc = new string[] {""} ;
         A2045VenDsc = "";
         H005L5_A754ConpSts = new short[1] ;
         H005L5_A137Conpcod = new int[1] ;
         H005L5_A753ConpDsc = new string[] {""} ;
         A753ConpDsc = "";
         H005L6_A1501PaiSts = new short[1] ;
         H005L6_A139PaiCod = new string[] {""} ;
         H005L6_A1500PaiDsc = new string[] {""} ;
         A139PaiCod = "";
         A1500PaiDsc = "";
         H005L7_A139PaiCod = new string[] {""} ;
         H005L7_A975EstSts = new short[1] ;
         H005L7_A140EstCod = new string[] {""} ;
         H005L7_A602EstDsc = new string[] {""} ;
         A140EstCod = "";
         A602EstDsc = "";
         H005L8_A1908TipCSts = new short[1] ;
         H005L8_A159TipCCod = new int[1] ;
         H005L8_A1905TipCDsc = new string[] {""} ;
         A1905TipCDsc = "";
         H005L9_A1919TipSts = new short[1] ;
         H005L9_A149TipCod = new string[] {""} ;
         H005L9_A1910TipDsc = new string[] {""} ;
         A149TipCod = "";
         A1910TipDsc = "";
         H005L10_A1899TieSts = new short[1] ;
         H005L10_A178TieCod = new int[1] ;
         H005L10_A1898TieDsc = new string[] {""} ;
         A1898TieDsc = "";
         sStyleString = "";
         sImgUrl = "";
         imgBtnbuscar_Jsonclick = "";
         BackMsgLst = new msglist();
         LclMsgLst = new msglist();
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.ventas.r_resumendocumentos__default(),
            new Object[][] {
                new Object[] {
               H005L2_A340CorSerie, H005L2_A339CorDoc
               }
               , new Object[] {
               H005L3_A1235MonSts, H005L3_A180MonCod, H005L3_A1234MonDsc
               }
               , new Object[] {
               H005L4_A2047VenSts, H005L4_A309VenCod, H005L4_A2045VenDsc
               }
               , new Object[] {
               H005L5_A754ConpSts, H005L5_A137Conpcod, H005L5_A753ConpDsc
               }
               , new Object[] {
               H005L6_A1501PaiSts, H005L6_A139PaiCod, H005L6_A1500PaiDsc
               }
               , new Object[] {
               H005L7_A139PaiCod, H005L7_A975EstSts, H005L7_A140EstCod, H005L7_A602EstDsc
               }
               , new Object[] {
               H005L8_A1908TipCSts, H005L8_A159TipCCod, H005L8_A1905TipCDsc
               }
               , new Object[] {
               H005L9_A1919TipSts, H005L9_A149TipCod, H005L9_A1910TipDsc
               }
               , new Object[] {
               H005L10_A1899TieSts, H005L10_A178TieCod, H005L10_A1898TieDsc
               }
            }
         );
         AV15FHasta = DateTimeUtil.Today( context);
         AV13FDesde = DateTimeUtil.Today( context);
         AV23MonCod = 0;
         /* GeneXus formulas. */
         context.Gx_err = 0;
         edtavClidsc_Enabled = 0;
      }

      private short nRcdExists_11 ;
      private short nIsMod_11 ;
      private short nRcdExists_10 ;
      private short nIsMod_10 ;
      private short nRcdExists_9 ;
      private short nIsMod_9 ;
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
      private short nDonePA ;
      private short A1235MonSts ;
      private short A2047VenSts ;
      private short A754ConpSts ;
      private short A1501PaiSts ;
      private short A975EstSts ;
      private short A1908TipCSts ;
      private short A1919TipSts ;
      private short A1899TieSts ;
      private short nGXWrapped ;
      private int AV44TieCod ;
      private int edtavTiecod_Visible ;
      private int edtavTipcod_Visible ;
      private int AV32TipCcod ;
      private int edtavTipccod_Visible ;
      private int edtavEstcod_Visible ;
      private int edtavPaicod_Visible ;
      private int AV47DocConPCod ;
      private int edtavDocconpcod_Visible ;
      private int AV40VenCod ;
      private int edtavVencod_Visible ;
      private int AV23MonCod ;
      private int edtavMoncod_Visible ;
      private int edtavSerie_Visible ;
      private int edtavClidsc_Enabled ;
      private int A180MonCod ;
      private int A309VenCod ;
      private int A137Conpcod ;
      private int A159TipCCod ;
      private int A178TieCod ;
      private int edtavFdesde_Enabled ;
      private int edtavFhasta_Enabled ;
      private int edtavClicod_Enabled ;
      private int idxLst ;
      private string Combo_serie_Selectedvalue_get ;
      private string Combo_moncod_Selectedvalue_get ;
      private string Combo_vencod_Selectedvalue_get ;
      private string Combo_docconpcod_Selectedvalue_get ;
      private string Combo_paicod_Selectedvalue_get ;
      private string Combo_estcod_Selectedvalue_get ;
      private string Combo_tipccod_Selectedvalue_get ;
      private string Combo_tipcod_Selectedvalue_get ;
      private string Combo_tiecod_Selectedvalue_get ;
      private string gxfirstwebparm ;
      private string gxfirstwebparm_bkp ;
      private string sDynURL ;
      private string FormProcess ;
      private string bodyStyle ;
      private string GXKey ;
      private string Combo_tiecod_Cls ;
      private string Combo_tiecod_Selectedvalue_set ;
      private string Combo_tipcod_Cls ;
      private string Combo_tipcod_Selectedvalue_set ;
      private string Combo_tipccod_Cls ;
      private string Combo_tipccod_Selectedvalue_set ;
      private string Combo_estcod_Cls ;
      private string Combo_estcod_Selectedvalue_set ;
      private string Combo_paicod_Cls ;
      private string Combo_paicod_Selectedvalue_set ;
      private string Combo_docconpcod_Cls ;
      private string Combo_docconpcod_Selectedvalue_set ;
      private string Combo_vencod_Cls ;
      private string Combo_vencod_Selectedvalue_set ;
      private string Combo_moncod_Cls ;
      private string Combo_moncod_Selectedvalue_set ;
      private string Combo_serie_Cls ;
      private string Combo_serie_Selectedvalue_set ;
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
      private string divTablesplittedtiecod_Internalname ;
      private string lblTextblockcombo_tiecod_Internalname ;
      private string lblTextblockcombo_tiecod_Jsonclick ;
      private string Combo_tiecod_Caption ;
      private string Combo_tiecod_Internalname ;
      private string divTablesplittedtipcod_Internalname ;
      private string lblTextblockcombo_tipcod_Internalname ;
      private string lblTextblockcombo_tipcod_Jsonclick ;
      private string Combo_tipcod_Caption ;
      private string Combo_tipcod_Internalname ;
      private string divTablesplittedtipccod_Internalname ;
      private string lblTextblockcombo_tipccod_Internalname ;
      private string lblTextblockcombo_tipccod_Jsonclick ;
      private string Combo_tipccod_Caption ;
      private string Combo_tipccod_Internalname ;
      private string divTablesplittedestcod_Internalname ;
      private string lblTextblockcombo_estcod_Internalname ;
      private string lblTextblockcombo_estcod_Jsonclick ;
      private string Combo_estcod_Caption ;
      private string Combo_estcod_Internalname ;
      private string divTablesplittedpaicod_Internalname ;
      private string lblTextblockcombo_paicod_Internalname ;
      private string lblTextblockcombo_paicod_Jsonclick ;
      private string Combo_paicod_Caption ;
      private string Combo_paicod_Internalname ;
      private string divTablesplitteddocconpcod_Internalname ;
      private string lblTextblockcombo_docconpcod_Internalname ;
      private string lblTextblockcombo_docconpcod_Jsonclick ;
      private string Combo_docconpcod_Caption ;
      private string Combo_docconpcod_Internalname ;
      private string divTablesplittedvencod_Internalname ;
      private string lblTextblockcombo_vencod_Internalname ;
      private string lblTextblockcombo_vencod_Jsonclick ;
      private string Combo_vencod_Caption ;
      private string Combo_vencod_Internalname ;
      private string divTablesplittedclicod_Internalname ;
      private string lblTextblockclicod_Internalname ;
      private string lblTextblockclicod_Jsonclick ;
      private string divTablesplittedmoncod_Internalname ;
      private string lblTextblockcombo_moncod_Internalname ;
      private string lblTextblockcombo_moncod_Jsonclick ;
      private string Combo_moncod_Caption ;
      private string Combo_moncod_Internalname ;
      private string divUnnamedtabletipo_Internalname ;
      private string lblTextblocktipo_Internalname ;
      private string lblTextblocktipo_Jsonclick ;
      private string cmbavTipo_Internalname ;
      private string TempTags ;
      private string cmbavTipo_Jsonclick ;
      private string divTablesplittedserie_Internalname ;
      private string lblTextblockcombo_serie_Internalname ;
      private string lblTextblockcombo_serie_Jsonclick ;
      private string Combo_serie_Caption ;
      private string Combo_serie_Internalname ;
      private string divTablesplittedfdesde_Internalname ;
      private string lblTextblockfdesde_Internalname ;
      private string lblTextblockfdesde_Jsonclick ;
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
      private string edtavTipcod_Internalname ;
      private string AV34TipCod ;
      private string edtavTipcod_Jsonclick ;
      private string edtavTipccod_Internalname ;
      private string edtavTipccod_Jsonclick ;
      private string edtavEstcod_Internalname ;
      private string AV45EstCod ;
      private string edtavEstcod_Jsonclick ;
      private string edtavPaicod_Internalname ;
      private string AV46PaiCod ;
      private string edtavPaicod_Jsonclick ;
      private string edtavDocconpcod_Internalname ;
      private string edtavDocconpcod_Jsonclick ;
      private string edtavVencod_Internalname ;
      private string edtavVencod_Jsonclick ;
      private string edtavMoncod_Internalname ;
      private string edtavMoncod_Jsonclick ;
      private string edtavSerie_Internalname ;
      private string AV28Serie ;
      private string edtavSerie_Jsonclick ;
      private string sEvt ;
      private string EvtGridId ;
      private string EvtRowId ;
      private string sEvtType ;
      private string edtavClicod_Internalname ;
      private string edtavClidsc_Internalname ;
      private string AV5CliCod ;
      private string AV7CliDsc ;
      private string edtavFdesde_Internalname ;
      private string edtavFhasta_Internalname ;
      private string GXEncryptionTmp ;
      private string scmdbuf ;
      private string A340CorSerie ;
      private string A339CorDoc ;
      private string A1234MonDsc ;
      private string A2045VenDsc ;
      private string A753ConpDsc ;
      private string A139PaiCod ;
      private string A1500PaiDsc ;
      private string A140EstCod ;
      private string A602EstDsc ;
      private string A1905TipCDsc ;
      private string A149TipCod ;
      private string A1910TipDsc ;
      private string A1898TieDsc ;
      private string sStyleString ;
      private string tblTablemergedfdesde_Internalname ;
      private string edtavFdesde_Jsonclick ;
      private string edtavFhasta_Jsonclick ;
      private string tblTablemergedclicod_Internalname ;
      private string edtavClicod_Jsonclick ;
      private string sImgUrl ;
      private string imgBtnbuscar_Internalname ;
      private string imgBtnbuscar_Jsonclick ;
      private string edtavClidsc_Jsonclick ;
      private DateTime AV13FDesde ;
      private DateTime AV15FHasta ;
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
      private string AV38Tipo ;
      private string AV10ExcelFilename ;
      private string AV9ErrorMessage ;
      private GXUserControl ucDvpanel_panel1 ;
      private GXUserControl ucCombo_tiecod ;
      private GXUserControl ucCombo_tipcod ;
      private GXUserControl ucCombo_tipccod ;
      private GXUserControl ucCombo_estcod ;
      private GXUserControl ucCombo_paicod ;
      private GXUserControl ucCombo_docconpcod ;
      private GXUserControl ucCombo_vencod ;
      private GXUserControl ucCombo_moncod ;
      private GXUserControl ucCombo_serie ;
      private GXUserControl ucInnewwindow ;
      private IGxDataStore dsDataStore2 ;
      private IGxDataStore dsDefault ;
      private GXCombobox cmbavTipo ;
      private IDataStoreProvider pr_default ;
      private string[] H005L2_A340CorSerie ;
      private string[] H005L2_A339CorDoc ;
      private short[] H005L3_A1235MonSts ;
      private int[] H005L3_A180MonCod ;
      private string[] H005L3_A1234MonDsc ;
      private short[] H005L4_A2047VenSts ;
      private int[] H005L4_A309VenCod ;
      private string[] H005L4_A2045VenDsc ;
      private short[] H005L5_A754ConpSts ;
      private int[] H005L5_A137Conpcod ;
      private string[] H005L5_A753ConpDsc ;
      private short[] H005L6_A1501PaiSts ;
      private string[] H005L6_A139PaiCod ;
      private string[] H005L6_A1500PaiDsc ;
      private string[] H005L7_A139PaiCod ;
      private short[] H005L7_A975EstSts ;
      private string[] H005L7_A140EstCod ;
      private string[] H005L7_A602EstDsc ;
      private short[] H005L8_A1908TipCSts ;
      private int[] H005L8_A159TipCCod ;
      private string[] H005L8_A1905TipCDsc ;
      private short[] H005L9_A1919TipSts ;
      private string[] H005L9_A149TipCod ;
      private string[] H005L9_A1910TipDsc ;
      private short[] H005L10_A1899TieSts ;
      private int[] H005L10_A178TieCod ;
      private string[] H005L10_A1898TieDsc ;
      private msglist BackMsgLst ;
      private msglist LclMsgLst ;
      private GXBaseCollection<GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTComboData_Item> AV48TieCod_Data ;
      private GXBaseCollection<GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTComboData_Item> AV35TipCod_Data ;
      private GXBaseCollection<GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTComboData_Item> AV33TipCcod_Data ;
      private GXBaseCollection<GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTComboData_Item> AV49EstCod_Data ;
      private GXBaseCollection<GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTComboData_Item> AV50PaiCod_Data ;
      private GXBaseCollection<GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTComboData_Item> AV51DocConPCod_Data ;
      private GXBaseCollection<GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTComboData_Item> AV41VenCod_Data ;
      private GXBaseCollection<GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTComboData_Item> AV24MonCod_Data ;
      private GXBaseCollection<GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTComboData_Item> AV29Serie_Data ;
      private GXWebForm Form ;
      private GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTComboData_Item AV8Combo_DataItem ;
   }

   public class r_resumendocumentos__default : DataStoreHelperBase, IDataStoreHelper
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
         ,new ForEachCursor(def[6])
         ,new ForEachCursor(def[7])
         ,new ForEachCursor(def[8])
       };
    }

    private static CursorDef[] def;
    private void cursorDefinitions( )
    {
       if ( def == null )
       {
          Object[] prmH005L2;
          prmH005L2 = new Object[] {
          };
          Object[] prmH005L3;
          prmH005L3 = new Object[] {
          };
          Object[] prmH005L4;
          prmH005L4 = new Object[] {
          };
          Object[] prmH005L5;
          prmH005L5 = new Object[] {
          };
          Object[] prmH005L6;
          prmH005L6 = new Object[] {
          };
          Object[] prmH005L7;
          prmH005L7 = new Object[] {
          };
          Object[] prmH005L8;
          prmH005L8 = new Object[] {
          };
          Object[] prmH005L9;
          prmH005L9 = new Object[] {
          };
          Object[] prmH005L10;
          prmH005L10 = new Object[] {
          };
          def= new CursorDef[] {
              new CursorDef("H005L2", "SELECT [CorSerie], [CorDoc] FROM [SGCDOCUMENTOS] ORDER BY [CorDoc] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH005L2,100, GxCacheFrequency.OFF ,false,false )
             ,new CursorDef("H005L3", "SELECT [MonSts], [MonCod], [MonDsc] FROM [CMONEDAS] WHERE [MonSts] = 1 ORDER BY [MonDsc] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH005L3,100, GxCacheFrequency.OFF ,false,false )
             ,new CursorDef("H005L4", "SELECT [VenSts], [VenCod], [VenDsc] FROM [CVENDEDORES] WHERE [VenSts] = 1 ORDER BY [VenDsc] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH005L4,100, GxCacheFrequency.OFF ,false,false )
             ,new CursorDef("H005L5", "SELECT [ConpSts], [Conpcod], [ConpDsc] FROM [CCONDICIONPAGO] WHERE [ConpSts] = 1 ORDER BY [ConpDsc] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH005L5,100, GxCacheFrequency.OFF ,false,false )
             ,new CursorDef("H005L6", "SELECT [PaiSts], [PaiCod], [PaiDsc] FROM [CPAISES] WHERE [PaiSts] = 1 ORDER BY [PaiDsc] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH005L6,100, GxCacheFrequency.OFF ,false,false )
             ,new CursorDef("H005L7", "SELECT [PaiCod], [EstSts], [EstCod], [EstDsc] FROM [CESTADOS] WHERE [EstSts] = 1 ORDER BY [EstDsc] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH005L7,100, GxCacheFrequency.OFF ,false,false )
             ,new CursorDef("H005L8", "SELECT [TipCSts], [TipCCod], [TipCDsc] FROM [CTIPOCLIENTE] WHERE [TipCSts] = 1 ORDER BY [TipCDsc] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH005L8,100, GxCacheFrequency.OFF ,false,false )
             ,new CursorDef("H005L9", "SELECT [TipSts], [TipCod], [TipDsc] FROM [CTIPDOC] WHERE [TipSts] = 1 ORDER BY [TipDsc] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH005L9,100, GxCacheFrequency.OFF ,false,false )
             ,new CursorDef("H005L10", "SELECT [TieSts], [TieCod], [TieDsc] FROM [SGTIENDAS] WHERE [TieSts] = 1 ORDER BY [TieDsc] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH005L10,100, GxCacheFrequency.OFF ,false,false )
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
                ((string[]) buf[0])[0] = rslt.getString(1, 4);
                ((string[]) buf[1])[0] = rslt.getString(2, 10);
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
                ((string[]) buf[1])[0] = rslt.getString(2, 4);
                ((string[]) buf[2])[0] = rslt.getString(3, 100);
                return;
             case 5 :
                ((string[]) buf[0])[0] = rslt.getString(1, 4);
                ((short[]) buf[1])[0] = rslt.getShort(2);
                ((string[]) buf[2])[0] = rslt.getString(3, 4);
                ((string[]) buf[3])[0] = rslt.getString(4, 100);
                return;
             case 6 :
                ((short[]) buf[0])[0] = rslt.getShort(1);
                ((int[]) buf[1])[0] = rslt.getInt(2);
                ((string[]) buf[2])[0] = rslt.getString(3, 100);
                return;
             case 7 :
                ((short[]) buf[0])[0] = rslt.getShort(1);
                ((string[]) buf[1])[0] = rslt.getString(2, 3);
                ((string[]) buf[2])[0] = rslt.getString(3, 100);
                return;
             case 8 :
                ((short[]) buf[0])[0] = rslt.getShort(1);
                ((int[]) buf[1])[0] = rslt.getInt(2);
                ((string[]) buf[2])[0] = rslt.getString(3, 100);
                return;
       }
    }

 }

}
