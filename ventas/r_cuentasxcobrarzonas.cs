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
   public class r_cuentasxcobrarzonas : GXDataArea
   {
      public r_cuentasxcobrarzonas( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDataStore2 = context.GetDataStore("DataStore2");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusTheme");
      }

      public r_cuentasxcobrarzonas( IGxContext context )
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
         PA562( ) ;
         gxajaxcallmode = (short)((isAjaxCallMode( ) ? 1 : 0));
         if ( ( gxajaxcallmode == 0 ) && ( GxWebError == 0 ) )
         {
            START562( ) ;
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
         context.AddJavascriptSource("gxcfg.js", "?202281810312829", false, true);
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
         context.WriteHtmlTextNl( "<form id=\"MAINFORM\" autocomplete=\"off\" name=\"MAINFORM\" method=\"post\" tabindex=-1  class=\"form-horizontal Form\" data-gx-class=\"form-horizontal Form\" novalidate action=\""+formatLink("ventas.r_cuentasxcobrarzonas.aspx") +"\">") ;
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
         GxWebStd.gx_hidden_field( context, "gxhash_vAGRUPA", GetSecureSignedToken( "", context.localUtil.Format( (decimal)(AV53Agrupa), "9"), context));
         GxWebStd.gx_hidden_field( context, "gxhash_vDISCOD", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( AV52DisCod, "")), context));
         GXKey = Crypto.GetSiteKey( );
      }

      protected void SendCloseFormHiddens( )
      {
         /* Send hidden variables. */
         /* Send saved values. */
         send_integrity_footer_hashes( ) ;
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "vDDO_TITLESETTINGSICONS", AV47DDO_TitleSettingsIcons);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt("vDDO_TITLESETTINGSICONS", AV47DDO_TitleSettingsIcons);
         }
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "vZONCOD_DATA", AV43ZonCod_Data);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt("vZONCOD_DATA", AV43ZonCod_Data);
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
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "vESTCOD_DATA", AV46EstCod_Data);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt("vESTCOD_DATA", AV46EstCod_Data);
         }
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "vPROVCOD_DATA", AV48ProvCod_Data);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt("vPROVCOD_DATA", AV48ProvCod_Data);
         }
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "vDISCCOD_DATA", AV51DiscCod_Data);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt("vDISCCOD_DATA", AV51DiscCod_Data);
         }
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "vMONCOD_DATA", AV24MonCod_Data);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt("vMONCOD_DATA", AV24MonCod_Data);
         }
         GxWebStd.gx_hidden_field( context, "vAGRUPA", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV53Agrupa), 1, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "gxhash_vAGRUPA", GetSecureSignedToken( "", context.localUtil.Format( (decimal)(AV53Agrupa), "9"), context));
         GxWebStd.gx_hidden_field( context, "vDISCOD", StringUtil.RTrim( AV52DisCod));
         GxWebStd.gx_hidden_field( context, "gxhash_vDISCOD", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( AV52DisCod, "")), context));
         GxWebStd.gx_hidden_field( context, "vTIPCCOD", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV32TipCcod), 6, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "vSERIE", StringUtil.RTrim( AV28Serie));
         GxWebStd.gx_hidden_field( context, "vTIPLETRAS", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV37TipLetras), 1, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "vVENCOD", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV40VenCod), 6, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "COMBO_ZONCOD_Cls", StringUtil.RTrim( Combo_zoncod_Cls));
         GxWebStd.gx_hidden_field( context, "COMBO_ZONCOD_Selectedvalue_set", StringUtil.RTrim( Combo_zoncod_Selectedvalue_set));
         GxWebStd.gx_hidden_field( context, "COMBO_TIPCOD_Cls", StringUtil.RTrim( Combo_tipcod_Cls));
         GxWebStd.gx_hidden_field( context, "COMBO_TIPCOD_Selectedvalue_set", StringUtil.RTrim( Combo_tipcod_Selectedvalue_set));
         GxWebStd.gx_hidden_field( context, "COMBO_ESTCOD_Cls", StringUtil.RTrim( Combo_estcod_Cls));
         GxWebStd.gx_hidden_field( context, "COMBO_ESTCOD_Selectedvalue_set", StringUtil.RTrim( Combo_estcod_Selectedvalue_set));
         GxWebStd.gx_hidden_field( context, "COMBO_PROVCOD_Cls", StringUtil.RTrim( Combo_provcod_Cls));
         GxWebStd.gx_hidden_field( context, "COMBO_PROVCOD_Selectedvalue_set", StringUtil.RTrim( Combo_provcod_Selectedvalue_set));
         GxWebStd.gx_hidden_field( context, "COMBO_PROVCOD_Selectedtext_set", StringUtil.RTrim( Combo_provcod_Selectedtext_set));
         GxWebStd.gx_hidden_field( context, "COMBO_PROVCOD_Datalistproc", StringUtil.RTrim( Combo_provcod_Datalistproc));
         GxWebStd.gx_hidden_field( context, "COMBO_PROVCOD_Datalistprocparametersprefix", StringUtil.RTrim( Combo_provcod_Datalistprocparametersprefix));
         GxWebStd.gx_hidden_field( context, "COMBO_DISCCOD_Cls", StringUtil.RTrim( Combo_disccod_Cls));
         GxWebStd.gx_hidden_field( context, "COMBO_DISCCOD_Selectedvalue_set", StringUtil.RTrim( Combo_disccod_Selectedvalue_set));
         GxWebStd.gx_hidden_field( context, "COMBO_DISCCOD_Selectedtext_set", StringUtil.RTrim( Combo_disccod_Selectedtext_set));
         GxWebStd.gx_hidden_field( context, "COMBO_DISCCOD_Datalistproc", StringUtil.RTrim( Combo_disccod_Datalistproc));
         GxWebStd.gx_hidden_field( context, "COMBO_DISCCOD_Datalistprocparametersprefix", StringUtil.RTrim( Combo_disccod_Datalistprocparametersprefix));
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
         GxWebStd.gx_hidden_field( context, "COMBO_DISCCOD_Selectedvalue_get", StringUtil.RTrim( Combo_disccod_Selectedvalue_get));
         GxWebStd.gx_hidden_field( context, "COMBO_PROVCOD_Selectedvalue_get", StringUtil.RTrim( Combo_provcod_Selectedvalue_get));
         GxWebStd.gx_hidden_field( context, "COMBO_ESTCOD_Selectedvalue_get", StringUtil.RTrim( Combo_estcod_Selectedvalue_get));
         GxWebStd.gx_hidden_field( context, "COMBO_TIPCOD_Selectedvalue_get", StringUtil.RTrim( Combo_tipcod_Selectedvalue_get));
         GxWebStd.gx_hidden_field( context, "COMBO_ZONCOD_Selectedvalue_get", StringUtil.RTrim( Combo_zoncod_Selectedvalue_get));
         GxWebStd.gx_hidden_field( context, "COMBO_DISCCOD_Selectedvalue_get", StringUtil.RTrim( Combo_disccod_Selectedvalue_get));
         GxWebStd.gx_hidden_field( context, "COMBO_PROVCOD_Selectedvalue_get", StringUtil.RTrim( Combo_provcod_Selectedvalue_get));
         GxWebStd.gx_hidden_field( context, "COMBO_ESTCOD_Selectedvalue_get", StringUtil.RTrim( Combo_estcod_Selectedvalue_get));
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
            WE562( ) ;
            context.WriteHtmlText( "</div>") ;
         }
      }

      public override void DispatchEvents( )
      {
         EVT562( ) ;
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
         return formatLink("ventas.r_cuentasxcobrarzonas.aspx")  ;
      }

      public override string GetPgmname( )
      {
         return "Ventas.R_CuentasxCobrarZonas" ;
      }

      public override string GetPgmdesc( )
      {
         return "Cuentas por cobrar por Zonas" ;
      }

      protected void WB560( )
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
            GxWebStd.gx_div_start( context, divTablesplittedzoncod_Internalname, 1, 0, "px", 0, "px", "Table", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-6 MergeLabelCell CellWidth_12_5", "left", "top", "", "", "div");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblTextblockcombo_zoncod_Internalname, "Zonas", "", "", lblTextblockcombo_zoncod_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "Label", 0, "", 1, 1, 0, 0, "HLP_Ventas\\R_CuentasxCobrarZonas.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-6 CellWidth_87_5", "left", "top", "", "", "div");
            /* User Defined Control */
            ucCombo_zoncod.SetProperty("Caption", Combo_zoncod_Caption);
            ucCombo_zoncod.SetProperty("Cls", Combo_zoncod_Cls);
            ucCombo_zoncod.SetProperty("DropDownOptionsTitleSettingsIcons", AV47DDO_TitleSettingsIcons);
            ucCombo_zoncod.SetProperty("DropDownOptionsData", AV43ZonCod_Data);
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
            GxWebStd.gx_div_start( context, divTablesplittedtipcod_Internalname, 1, 0, "px", 0, "px", "Table", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-6 MergeLabelCell CellWidth_12_5", "left", "top", "", "", "div");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblTextblockcombo_tipcod_Internalname, "Tpo Documentos", "", "", lblTextblockcombo_tipcod_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "Label", 0, "", 1, 1, 0, 0, "HLP_Ventas\\R_CuentasxCobrarZonas.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-6 CellWidth_87_5", "left", "top", "", "", "div");
            /* User Defined Control */
            ucCombo_tipcod.SetProperty("Caption", Combo_tipcod_Caption);
            ucCombo_tipcod.SetProperty("Cls", Combo_tipcod_Cls);
            ucCombo_tipcod.SetProperty("DropDownOptionsTitleSettingsIcons", AV47DDO_TitleSettingsIcons);
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
            GxWebStd.gx_div_start( context, divTablesplittedestcod_Internalname, 1, 0, "px", 0, "px", "Table", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-6 MergeLabelCell CellWidth_12_5", "left", "top", "", "", "div");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblTextblockcombo_estcod_Internalname, "Departamento", "", "", lblTextblockcombo_estcod_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "Label", 0, "", 1, 1, 0, 0, "HLP_Ventas\\R_CuentasxCobrarZonas.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-6 CellWidth_87_5", "left", "top", "", "", "div");
            /* User Defined Control */
            ucCombo_estcod.SetProperty("Caption", Combo_estcod_Caption);
            ucCombo_estcod.SetProperty("Cls", Combo_estcod_Cls);
            ucCombo_estcod.SetProperty("DropDownOptionsTitleSettingsIcons", AV47DDO_TitleSettingsIcons);
            ucCombo_estcod.SetProperty("DropDownOptionsData", AV46EstCod_Data);
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
            GxWebStd.gx_div_start( context, divTablesplittedprovcod_Internalname, 1, 0, "px", 0, "px", "Table", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-6 MergeLabelCell CellWidth_12_5", "left", "top", "", "", "div");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblTextblockcombo_provcod_Internalname, "Provincia", "", "", lblTextblockcombo_provcod_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "Label", 0, "", 1, 1, 0, 0, "HLP_Ventas\\R_CuentasxCobrarZonas.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-6 CellWidth_87_5", "left", "top", "", "", "div");
            /* User Defined Control */
            ucCombo_provcod.SetProperty("Caption", Combo_provcod_Caption);
            ucCombo_provcod.SetProperty("Cls", Combo_provcod_Cls);
            ucCombo_provcod.SetProperty("DataListProc", Combo_provcod_Datalistproc);
            ucCombo_provcod.SetProperty("DropDownOptionsTitleSettingsIcons", AV47DDO_TitleSettingsIcons);
            ucCombo_provcod.SetProperty("DropDownOptionsData", AV48ProvCod_Data);
            ucCombo_provcod.Render(context, "dvelop.gxbootstrap.ddoextendedcombo", Combo_provcod_Internalname, "COMBO_PROVCODContainer");
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
            GxWebStd.gx_div_start( context, divTablesplitteddisccod_Internalname, 1, 0, "px", 0, "px", "Table", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-6 MergeLabelCell CellWidth_12_5", "left", "top", "", "", "div");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblTextblockcombo_disccod_Internalname, "Distrito", "", "", lblTextblockcombo_disccod_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "Label", 0, "", 1, 1, 0, 0, "HLP_Ventas\\R_CuentasxCobrarZonas.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-6 CellWidth_87_5", "left", "top", "", "", "div");
            /* User Defined Control */
            ucCombo_disccod.SetProperty("Caption", Combo_disccod_Caption);
            ucCombo_disccod.SetProperty("Cls", Combo_disccod_Cls);
            ucCombo_disccod.SetProperty("DataListProc", Combo_disccod_Datalistproc);
            ucCombo_disccod.SetProperty("DropDownOptionsTitleSettingsIcons", AV47DDO_TitleSettingsIcons);
            ucCombo_disccod.SetProperty("DropDownOptionsData", AV51DiscCod_Data);
            ucCombo_disccod.Render(context, "dvelop.gxbootstrap.ddoextendedcombo", Combo_disccod_Internalname, "COMBO_DISCCODContainer");
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
            GxWebStd.gx_label_ctrl( context, lblTextblockclicod_Internalname, "Cliente", "", "", lblTextblockclicod_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "Label", 0, "", 1, 1, 0, 0, "HLP_Ventas\\R_CuentasxCobrarZonas.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-6 CellWidth_87_5", "left", "top", "", "", "div");
            wb_table1_65_562( true) ;
         }
         else
         {
            wb_table1_65_562( false) ;
         }
         return  ;
      }

      protected void wb_table1_65_562e( bool wbgen )
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
            GxWebStd.gx_label_ctrl( context, lblTextblockcombo_moncod_Internalname, "Moneda", "", "", lblTextblockcombo_moncod_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "Label", 0, "", 1, 1, 0, 0, "HLP_Ventas\\R_CuentasxCobrarZonas.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-6 CellWidth_87_5", "left", "top", "", "", "div");
            /* User Defined Control */
            ucCombo_moncod.SetProperty("Caption", Combo_moncod_Caption);
            ucCombo_moncod.SetProperty("Cls", Combo_moncod_Cls);
            ucCombo_moncod.SetProperty("DropDownOptionsTitleSettingsIcons", AV47DDO_TitleSettingsIcons);
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
            GxWebStd.gx_div_start( context, divUnnamedtablefhasta_Internalname, 1, 0, "px", 0, "px", "Table", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-6 MergeLabelCell CellWidth_12_5", "left", "top", "", "", "div");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblTextblockfhasta_Internalname, "F.Hasta", "", "", lblTextblockfhasta_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "Label", 0, "", 1, 1, 0, 0, "HLP_Ventas\\R_CuentasxCobrarZonas.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-6 CellWidth_87_5", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "left", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavFhasta_Internalname, "FHasta", "col-sm-3 AttributeDateLabel", 0, true, "");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 91,'',false,'',0)\"";
            context.WriteHtmlText( "<div id=\""+edtavFhasta_Internalname+"_dp_container\" class=\"dp_container\" style=\"white-space:nowrap;display:inline;\">") ;
            GxWebStd.gx_single_line_edit( context, edtavFhasta_Internalname, context.localUtil.Format(AV15FHasta, "99/99/99"), context.localUtil.Format( AV15FHasta, "99/99/99"), TempTags+" onchange=\""+"gx.date.valid_date(this, 8,'DMY',0,24,'spa',false,0);"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.date.valid_date(this, 8,'DMY',0,24,'spa',false,0);"+";gx.evt.onblur(this,91);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavFhasta_Jsonclick, 0, "AttributeDate", "", "", "", "", 1, edtavFhasta_Enabled, 0, "text", "", 8, "chr", 1, "row", 8, 0, 0, 0, 1, -1, 0, true, "", "right", false, "", "HLP_Ventas\\R_CuentasxCobrarZonas.htm");
            GxWebStd.gx_bitmap( context, edtavFhasta_Internalname+"_dp_trigger", context.GetImagePath( "61b9b5d3-dff6-4d59-9b00-da61bc2cbe93", "", context.GetTheme( )), "", "", "", "", ((1==0)||(edtavFhasta_Enabled==0) ? 0 : 1), 0, "Date selector", "Date selector", 0, 1, 0, "", 0, "", 0, 0, 0, "", "", "cursor: pointer;", "", "", "", "", "", "", "", "", 1, false, false, "", "HLP_Ventas\\R_CuentasxCobrarZonas.htm");
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
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 96,'',false,'',0)\"";
            ClassString = "ButtonPDF";
            StyleString = "";
            GxWebStd.gx_button_ctrl( context, bttBtnbtnimprimir_Internalname, "", "Imprimir", bttBtnbtnimprimir_Jsonclick, 5, "Imprimir", "", StyleString, ClassString, 1, 1, "standard", "'"+""+"'"+",false,"+"'"+"E\\'DOBTNIMPRIMIR\\'."+"'", TempTags, "", context.GetButtonType( ), "HLP_Ventas\\R_CuentasxCobrarZonas.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "left", "top", "", "", "div");
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 98,'',false,'',0)\"";
            ClassString = "ButtonColor";
            StyleString = "";
            GxWebStd.gx_button_ctrl( context, bttBtnbtnsalir_Internalname, "", "Salir", bttBtnbtnsalir_Jsonclick, 5, "Imprimir PDF", "", StyleString, ClassString, 1, 1, "standard", "'"+""+"'"+",false,"+"'"+"E\\'DOBTNSALIR\\'."+"'", TempTags, "", context.GetButtonType( ), "HLP_Ventas\\R_CuentasxCobrarZonas.htm");
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
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 105,'',false,'',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavZoncod_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(AV42ZonCod), 6, 0, ".", "")), StringUtil.LTrim( context.localUtil.Format( (decimal)(AV42ZonCod), "ZZZZZ9")), " inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onblur(this,105);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavZoncod_Jsonclick, 0, "Attribute", "", "", "", "", edtavZoncod_Visible, 1, 0, "text", "1", 6, "chr", 1, "row", 6, 0, 0, 0, 1, -1, 0, true, "", "right", false, "", "HLP_Ventas\\R_CuentasxCobrarZonas.htm");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 106,'',false,'',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavTipcod_Internalname, StringUtil.RTrim( AV34TipCod), StringUtil.RTrim( context.localUtil.Format( AV34TipCod, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,106);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavTipcod_Jsonclick, 0, "Attribute", "", "", "", "", edtavTipcod_Visible, 1, 0, "text", "", 3, "chr", 1, "row", 3, 0, 0, 0, 1, -1, -1, true, "", "left", true, "", "HLP_Ventas\\R_CuentasxCobrarZonas.htm");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 107,'',false,'',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavEstcod_Internalname, StringUtil.RTrim( AV44EstCod), StringUtil.RTrim( context.localUtil.Format( AV44EstCod, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,107);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavEstcod_Jsonclick, 0, "Attribute", "", "", "", "", edtavEstcod_Visible, 1, 0, "text", "", 4, "chr", 1, "row", 4, 0, 0, 0, 1, -1, -1, true, "", "left", true, "", "HLP_Ventas\\R_CuentasxCobrarZonas.htm");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 108,'',false,'',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavProvcod_Internalname, StringUtil.RTrim( AV45ProvCod), StringUtil.RTrim( context.localUtil.Format( AV45ProvCod, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,108);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavProvcod_Jsonclick, 0, "Attribute", "", "", "", "", edtavProvcod_Visible, 1, 0, "text", "", 4, "chr", 1, "row", 4, 0, 0, 0, 1, -1, -1, true, "", "left", true, "", "HLP_Ventas\\R_CuentasxCobrarZonas.htm");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 109,'',false,'',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavDisccod_Internalname, StringUtil.RTrim( AV50DiscCod), StringUtil.RTrim( context.localUtil.Format( AV50DiscCod, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,109);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavDisccod_Jsonclick, 0, "Attribute", "", "", "", "", edtavDisccod_Visible, 1, 0, "text", "", 4, "chr", 1, "row", 4, 0, 0, 0, 1, -1, -1, true, "", "left", true, "", "HLP_Ventas\\R_CuentasxCobrarZonas.htm");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 110,'',false,'',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavMoncod_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(AV23MonCod), 6, 0, ".", "")), StringUtil.LTrim( context.localUtil.Format( (decimal)(AV23MonCod), "ZZZZZ9")), " inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onblur(this,110);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavMoncod_Jsonclick, 0, "Attribute", "", "", "", "", edtavMoncod_Visible, 1, 0, "text", "1", 6, "chr", 1, "row", 6, 0, 0, 0, 1, -1, 0, true, "", "right", false, "", "HLP_Ventas\\R_CuentasxCobrarZonas.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
         }
         wbLoad = true;
      }

      protected void START562( )
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
            Form.Meta.addItem("description", "Cuentas por cobrar por Zonas", 0) ;
         }
         context.wjLoc = "";
         context.nUserReturn = 0;
         context.wbHandled = 0;
         if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
         {
         }
         wbErr = false;
         STRUP560( ) ;
      }

      protected void WS562( )
      {
         START562( ) ;
         EVT562( ) ;
      }

      protected void EVT562( )
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
                           else if ( StringUtil.StrCmp(sEvt, "COMBO_ESTCOD.ONOPTIONCLICKED") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              E11562 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "COMBO_PROVCOD.ONOPTIONCLICKED") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              E12562 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "COMBO_DISCCOD.ONOPTIONCLICKED") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              E13562 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "START") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              /* Execute user event: Start */
                              E14562 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "'DOBTNIMPRIMIR'") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              /* Execute user event: 'DoBtnImprimir' */
                              E15562 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "'DOBTNSALIR'") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              /* Execute user event: 'DoBtnSalir' */
                              E16562 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "'DOBTNEXCEL'") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              /* Execute user event: 'DoBtnExcel' */
                              E17562 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "LOAD") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              /* Execute user event: Load */
                              E18562 ();
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

      protected void WE562( )
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

      protected void PA562( )
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
         RF562( ) ;
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

      protected void RF562( )
      {
         initialize_formulas( ) ;
         clear_multi_value_controls( ) ;
         gxdyncontrolsrefreshing = true;
         fix_multi_value_controls( ) ;
         gxdyncontrolsrefreshing = false;
         if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
         {
            /* Execute user event: Load */
            E18562 ();
            WB560( ) ;
         }
      }

      protected void send_integrity_lvl_hashes562( )
      {
         GxWebStd.gx_hidden_field( context, "vAGRUPA", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV53Agrupa), 1, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "gxhash_vAGRUPA", GetSecureSignedToken( "", context.localUtil.Format( (decimal)(AV53Agrupa), "9"), context));
         GxWebStd.gx_hidden_field( context, "vDISCOD", StringUtil.RTrim( AV52DisCod));
         GxWebStd.gx_hidden_field( context, "gxhash_vDISCOD", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( AV52DisCod, "")), context));
      }

      protected void before_start_formulas( )
      {
         context.Gx_err = 0;
         edtavClidsc_Enabled = 0;
         AssignProp("", false, edtavClidsc_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavClidsc_Enabled), 5, 0), true);
         fix_multi_value_controls( ) ;
      }

      protected void STRUP560( )
      {
         /* Before Start, stand alone formulas. */
         before_start_formulas( ) ;
         /* Execute Start event if defined. */
         context.wbGlbDoneStart = 0;
         /* Execute user event: Start */
         E14562 ();
         context.wbGlbDoneStart = 1;
         /* After Start, stand alone formulas. */
         if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
         {
            /* Read saved SDTs. */
            ajax_req_read_hidden_sdt(cgiGet( "vDDO_TITLESETTINGSICONS"), AV47DDO_TitleSettingsIcons);
            ajax_req_read_hidden_sdt(cgiGet( "vZONCOD_DATA"), AV43ZonCod_Data);
            ajax_req_read_hidden_sdt(cgiGet( "vTIPCOD_DATA"), AV35TipCod_Data);
            ajax_req_read_hidden_sdt(cgiGet( "vESTCOD_DATA"), AV46EstCod_Data);
            ajax_req_read_hidden_sdt(cgiGet( "vPROVCOD_DATA"), AV48ProvCod_Data);
            ajax_req_read_hidden_sdt(cgiGet( "vDISCCOD_DATA"), AV51DiscCod_Data);
            ajax_req_read_hidden_sdt(cgiGet( "vMONCOD_DATA"), AV24MonCod_Data);
            /* Read saved values. */
            Combo_zoncod_Cls = cgiGet( "COMBO_ZONCOD_Cls");
            Combo_zoncod_Selectedvalue_set = cgiGet( "COMBO_ZONCOD_Selectedvalue_set");
            Combo_tipcod_Cls = cgiGet( "COMBO_TIPCOD_Cls");
            Combo_tipcod_Selectedvalue_set = cgiGet( "COMBO_TIPCOD_Selectedvalue_set");
            Combo_estcod_Cls = cgiGet( "COMBO_ESTCOD_Cls");
            Combo_estcod_Selectedvalue_set = cgiGet( "COMBO_ESTCOD_Selectedvalue_set");
            Combo_provcod_Cls = cgiGet( "COMBO_PROVCOD_Cls");
            Combo_provcod_Selectedvalue_set = cgiGet( "COMBO_PROVCOD_Selectedvalue_set");
            Combo_provcod_Selectedtext_set = cgiGet( "COMBO_PROVCOD_Selectedtext_set");
            Combo_provcod_Datalistproc = cgiGet( "COMBO_PROVCOD_Datalistproc");
            Combo_provcod_Datalistprocparametersprefix = cgiGet( "COMBO_PROVCOD_Datalistprocparametersprefix");
            Combo_disccod_Cls = cgiGet( "COMBO_DISCCOD_Cls");
            Combo_disccod_Selectedvalue_set = cgiGet( "COMBO_DISCCOD_Selectedvalue_set");
            Combo_disccod_Selectedtext_set = cgiGet( "COMBO_DISCCOD_Selectedtext_set");
            Combo_disccod_Datalistproc = cgiGet( "COMBO_DISCCOD_Datalistproc");
            Combo_disccod_Datalistprocparametersprefix = cgiGet( "COMBO_DISCCOD_Datalistprocparametersprefix");
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
            Combo_disccod_Selectedvalue_get = cgiGet( "COMBO_DISCCOD_Selectedvalue_get");
            Combo_provcod_Selectedvalue_get = cgiGet( "COMBO_PROVCOD_Selectedvalue_get");
            Combo_estcod_Selectedvalue_get = cgiGet( "COMBO_ESTCOD_Selectedvalue_get");
            /* Read variables values. */
            AV5CliCod = cgiGet( edtavClicod_Internalname);
            AssignAttri("", false, "AV5CliCod", AV5CliCod);
            AV7CliDsc = cgiGet( edtavClidsc_Internalname);
            AssignAttri("", false, "AV7CliDsc", AV7CliDsc);
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
            if ( ( ( context.localUtil.CToN( cgiGet( edtavZoncod_Internalname), ".", ",") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtavZoncod_Internalname), ".", ",") > Convert.ToDecimal( 999999 )) ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "vZONCOD");
               GX_FocusControl = edtavZoncod_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               AV42ZonCod = 0;
               AssignAttri("", false, "AV42ZonCod", StringUtil.LTrimStr( (decimal)(AV42ZonCod), 6, 0));
            }
            else
            {
               AV42ZonCod = (int)(context.localUtil.CToN( cgiGet( edtavZoncod_Internalname), ".", ","));
               AssignAttri("", false, "AV42ZonCod", StringUtil.LTrimStr( (decimal)(AV42ZonCod), 6, 0));
            }
            AV34TipCod = cgiGet( edtavTipcod_Internalname);
            AssignAttri("", false, "AV34TipCod", AV34TipCod);
            AV44EstCod = cgiGet( edtavEstcod_Internalname);
            AssignAttri("", false, "AV44EstCod", AV44EstCod);
            AV45ProvCod = cgiGet( edtavProvcod_Internalname);
            AssignAttri("", false, "AV45ProvCod", AV45ProvCod);
            AV50DiscCod = cgiGet( edtavDisccod_Internalname);
            AssignAttri("", false, "AV50DiscCod", AV50DiscCod);
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
         E14562 ();
         if (returnInSub) return;
      }

      protected void E14562( )
      {
         /* Start Routine */
         returnInSub = false;
         GXt_SdtDVB_SDTDropDownOptionsTitleSettingsIcons1 = AV47DDO_TitleSettingsIcons;
         new GeneXus.Programs.wwpbaseobjects.getwwptitlesettingsicons(context ).execute( out  GXt_SdtDVB_SDTDropDownOptionsTitleSettingsIcons1) ;
         AV47DDO_TitleSettingsIcons = GXt_SdtDVB_SDTDropDownOptionsTitleSettingsIcons1;
         edtavMoncod_Visible = 0;
         AssignProp("", false, edtavMoncod_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavMoncod_Visible), 5, 0), true);
         edtavDisccod_Visible = 0;
         AssignProp("", false, edtavDisccod_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavDisccod_Visible), 5, 0), true);
         edtavProvcod_Visible = 0;
         AssignProp("", false, edtavProvcod_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavProvcod_Visible), 5, 0), true);
         edtavEstcod_Visible = 0;
         AssignProp("", false, edtavEstcod_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavEstcod_Visible), 5, 0), true);
         edtavTipcod_Visible = 0;
         AssignProp("", false, edtavTipcod_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavTipcod_Visible), 5, 0), true);
         edtavZoncod_Visible = 0;
         AssignProp("", false, edtavZoncod_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavZoncod_Visible), 5, 0), true);
         /* Execute user subroutine: 'LOADCOMBOZONCOD' */
         S112 ();
         if (returnInSub) return;
         /* Execute user subroutine: 'LOADCOMBOTIPCOD' */
         S122 ();
         if (returnInSub) return;
         /* Execute user subroutine: 'LOADCOMBOESTCOD' */
         S132 ();
         if (returnInSub) return;
         /* Execute user subroutine: 'LOADCOMBOPROVCOD' */
         S142 ();
         if (returnInSub) return;
         /* Execute user subroutine: 'LOADCOMBODISCCOD' */
         S152 ();
         if (returnInSub) return;
         /* Execute user subroutine: 'LOADCOMBOMONCOD' */
         S162 ();
         if (returnInSub) return;
         AV15FHasta = DateTimeUtil.Today( context);
         AssignAttri("", false, "AV15FHasta", context.localUtil.Format(AV15FHasta, "99/99/99"));
      }

      protected void E15562( )
      {
         /* 'DoBtnImprimir' Routine */
         returnInSub = false;
         GXKey = Crypto.GetSiteKey( );
         GXEncryptionTmp = "rrcuentasxcobrarzonas.aspx"+UrlEncode(StringUtil.RTrim(AV34TipCod)) + "," + UrlEncode(StringUtil.RTrim(AV5CliCod)) + "," + UrlEncode(StringUtil.LTrimStr(AV23MonCod,6,0)) + "," + UrlEncode(StringUtil.LTrimStr(AV42ZonCod,6,0)) + "," + UrlEncode(StringUtil.LTrimStr(AV53Agrupa,1,0)) + "," + UrlEncode(StringUtil.RTrim(AV52DisCod)) + "," + UrlEncode(DateTimeUtil.FormatDateParm(AV15FHasta));
         Innewwindow_Target = formatLink("rrcuentasxcobrarzonas.aspx") + "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey);
         ucInnewwindow.SendProperty(context, "", false, Innewwindow_Internalname, "Target", Innewwindow_Target);
         this.executeUsercontrolMethod("", false, "INNEWWINDOWContainer", "OpenWindow", "", new Object[] {});
         /*  Sending Event outputs  */
      }

      protected void E16562( )
      {
         /* 'DoBtnSalir' Routine */
         returnInSub = false;
         CallWebObject(formatLink("wwpbaseobjects.home.aspx") );
         context.wjLocDisableFrm = 1;
      }

      protected void E13562( )
      {
         /* Combo_disccod_Onoptionclicked Routine */
         returnInSub = false;
         AV50DiscCod = Combo_disccod_Selectedvalue_get;
         AssignAttri("", false, "AV50DiscCod", AV50DiscCod);
         /*  Sending Event outputs  */
      }

      protected void E12562( )
      {
         /* Combo_provcod_Onoptionclicked Routine */
         returnInSub = false;
         AV45ProvCod = Combo_provcod_Selectedvalue_get;
         AssignAttri("", false, "AV45ProvCod", AV45ProvCod);
         /*  Sending Event outputs  */
      }

      protected void E11562( )
      {
         /* Combo_estcod_Onoptionclicked Routine */
         returnInSub = false;
         AV49Cond_EstCod = AV44EstCod;
         AV44EstCod = Combo_estcod_Selectedvalue_get;
         AssignAttri("", false, "AV44EstCod", AV44EstCod);
         if ( StringUtil.StrCmp(AV49Cond_EstCod, AV44EstCod) != 0 )
         {
            AV45ProvCod = "";
            AssignAttri("", false, "AV45ProvCod", AV45ProvCod);
            Combo_provcod_Selectedvalue_set = "";
            ucCombo_provcod.SendProperty(context, "", false, Combo_provcod_Internalname, "SelectedValue_set", Combo_provcod_Selectedvalue_set);
            Combo_provcod_Selectedtext_set = "";
            ucCombo_provcod.SendProperty(context, "", false, Combo_provcod_Internalname, "SelectedText_set", Combo_provcod_Selectedtext_set);
            AV50DiscCod = "";
            AssignAttri("", false, "AV50DiscCod", AV50DiscCod);
            Combo_disccod_Selectedvalue_set = "";
            ucCombo_disccod.SendProperty(context, "", false, Combo_disccod_Internalname, "SelectedValue_set", Combo_disccod_Selectedvalue_set);
            Combo_disccod_Selectedtext_set = "";
            ucCombo_disccod.SendProperty(context, "", false, Combo_disccod_Internalname, "SelectedText_set", Combo_disccod_Selectedtext_set);
         }
         /*  Sending Event outputs  */
      }

      protected void S162( )
      {
         /* 'LOADCOMBOMONCOD' Routine */
         returnInSub = false;
         /* Using cursor H00562 */
         pr_default.execute(0);
         while ( (pr_default.getStatus(0) != 101) )
         {
            A1235MonSts = H00562_A1235MonSts[0];
            A180MonCod = H00562_A180MonCod[0];
            A1234MonDsc = H00562_A1234MonDsc[0];
            AV8Combo_DataItem = new GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTComboData_Item(context);
            AV8Combo_DataItem.gxTpr_Id = StringUtil.Trim( StringUtil.Str( (decimal)(A180MonCod), 6, 0));
            AV8Combo_DataItem.gxTpr_Title = A1234MonDsc;
            AV24MonCod_Data.Add(AV8Combo_DataItem, 0);
            pr_default.readNext(0);
         }
         pr_default.close(0);
         Combo_moncod_Selectedvalue_set = ((0==AV23MonCod) ? "" : StringUtil.Trim( StringUtil.Str( (decimal)(AV23MonCod), 6, 0)));
         ucCombo_moncod.SendProperty(context, "", false, Combo_moncod_Internalname, "SelectedValue_set", Combo_moncod_Selectedvalue_set);
      }

      protected void S152( )
      {
         /* 'LOADCOMBODISCCOD' Routine */
         returnInSub = false;
         Combo_disccod_Datalistprocparametersprefix = StringUtil.Format( " \"ComboName\": \"DiscCod\", \"Cond_EstCod\": \"#%1#\"", edtavEstcod_Internalname, "", "", "", "", "", "", "", "");
         ucCombo_disccod.SendProperty(context, "", false, Combo_disccod_Internalname, "DataListProcParametersPrefix", Combo_disccod_Datalistprocparametersprefix);
         AV49Cond_EstCod = AV44EstCod;
         AV57GXLvl158 = 0;
         /* Using cursor H00563 */
         pr_default.execute(1, new Object[] {AV50DiscCod});
         while ( (pr_default.getStatus(1) != 101) )
         {
            A878DisSts = H00563_A878DisSts[0];
            A142DisCod = H00563_A142DisCod[0];
            A604DisDsc = H00563_A604DisDsc[0];
            AV57GXLvl158 = 1;
            Combo_disccod_Selectedtext_set = A604DisDsc;
            ucCombo_disccod.SendProperty(context, "", false, Combo_disccod_Internalname, "SelectedText_set", Combo_disccod_Selectedtext_set);
            /* Exit For each command. Update data (if necessary), close cursors & exit. */
            if (true) break;
            pr_default.readNext(1);
         }
         pr_default.close(1);
         if ( AV57GXLvl158 == 0 )
         {
            Combo_disccod_Selectedtext_set = "";
            ucCombo_disccod.SendProperty(context, "", false, Combo_disccod_Internalname, "SelectedText_set", Combo_disccod_Selectedtext_set);
         }
         Combo_disccod_Selectedvalue_set = AV50DiscCod;
         ucCombo_disccod.SendProperty(context, "", false, Combo_disccod_Internalname, "SelectedValue_set", Combo_disccod_Selectedvalue_set);
      }

      protected void S142( )
      {
         /* 'LOADCOMBOPROVCOD' Routine */
         returnInSub = false;
         Combo_provcod_Datalistprocparametersprefix = StringUtil.Format( " \"ComboName\": \"ProvCod\", \"Cond_EstCod\": \"#%1#\"", edtavEstcod_Internalname, "", "", "", "", "", "", "", "");
         ucCombo_provcod.SendProperty(context, "", false, Combo_provcod_Internalname, "DataListProcParametersPrefix", Combo_provcod_Datalistprocparametersprefix);
         AV49Cond_EstCod = AV44EstCod;
         AV58GXLvl179 = 0;
         /* Using cursor H00564 */
         pr_default.execute(2, new Object[] {AV45ProvCod});
         while ( (pr_default.getStatus(2) != 101) )
         {
            A1742ProvSts = H00564_A1742ProvSts[0];
            A141ProvCod = H00564_A141ProvCod[0];
            A603ProvDsc = H00564_A603ProvDsc[0];
            AV58GXLvl179 = 1;
            Combo_provcod_Selectedtext_set = A603ProvDsc;
            ucCombo_provcod.SendProperty(context, "", false, Combo_provcod_Internalname, "SelectedText_set", Combo_provcod_Selectedtext_set);
            /* Exit For each command. Update data (if necessary), close cursors & exit. */
            if (true) break;
            pr_default.readNext(2);
         }
         pr_default.close(2);
         if ( AV58GXLvl179 == 0 )
         {
            Combo_provcod_Selectedtext_set = "";
            ucCombo_provcod.SendProperty(context, "", false, Combo_provcod_Internalname, "SelectedText_set", Combo_provcod_Selectedtext_set);
         }
         Combo_provcod_Selectedvalue_set = AV45ProvCod;
         ucCombo_provcod.SendProperty(context, "", false, Combo_provcod_Internalname, "SelectedValue_set", Combo_provcod_Selectedvalue_set);
      }

      protected void S132( )
      {
         /* 'LOADCOMBOESTCOD' Routine */
         returnInSub = false;
         /* Using cursor H00565 */
         pr_default.execute(3);
         while ( (pr_default.getStatus(3) != 101) )
         {
            A975EstSts = H00565_A975EstSts[0];
            A140EstCod = H00565_A140EstCod[0];
            A602EstDsc = H00565_A602EstDsc[0];
            AV8Combo_DataItem = new GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTComboData_Item(context);
            AV8Combo_DataItem.gxTpr_Id = A140EstCod;
            AV8Combo_DataItem.gxTpr_Title = A602EstDsc;
            AV46EstCod_Data.Add(AV8Combo_DataItem, 0);
            pr_default.readNext(3);
         }
         pr_default.close(3);
         Combo_estcod_Selectedvalue_set = AV44EstCod;
         ucCombo_estcod.SendProperty(context, "", false, Combo_estcod_Internalname, "SelectedValue_set", Combo_estcod_Selectedvalue_set);
      }

      protected void S122( )
      {
         /* 'LOADCOMBOTIPCOD' Routine */
         returnInSub = false;
         /* Using cursor H00566 */
         pr_default.execute(4);
         while ( (pr_default.getStatus(4) != 101) )
         {
            A1919TipSts = H00566_A1919TipSts[0];
            A149TipCod = H00566_A149TipCod[0];
            A1910TipDsc = H00566_A1910TipDsc[0];
            AV8Combo_DataItem = new GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTComboData_Item(context);
            AV8Combo_DataItem.gxTpr_Id = A149TipCod;
            AV8Combo_DataItem.gxTpr_Title = A1910TipDsc;
            AV35TipCod_Data.Add(AV8Combo_DataItem, 0);
            pr_default.readNext(4);
         }
         pr_default.close(4);
         Combo_tipcod_Selectedvalue_set = AV34TipCod;
         ucCombo_tipcod.SendProperty(context, "", false, Combo_tipcod_Internalname, "SelectedValue_set", Combo_tipcod_Selectedvalue_set);
      }

      protected void S112( )
      {
         /* 'LOADCOMBOZONCOD' Routine */
         returnInSub = false;
         /* Using cursor H00567 */
         pr_default.execute(5);
         while ( (pr_default.getStatus(5) != 101) )
         {
            A2095ZonSts = H00567_A2095ZonSts[0];
            A158ZonCod = H00567_A158ZonCod[0];
            A2094ZonDsc = H00567_A2094ZonDsc[0];
            AV8Combo_DataItem = new GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTComboData_Item(context);
            AV8Combo_DataItem.gxTpr_Id = StringUtil.Trim( StringUtil.Str( (decimal)(A158ZonCod), 6, 0));
            AV8Combo_DataItem.gxTpr_Title = A2094ZonDsc;
            AV43ZonCod_Data.Add(AV8Combo_DataItem, 0);
            pr_default.readNext(5);
         }
         pr_default.close(5);
         Combo_zoncod_Selectedvalue_set = ((0==AV42ZonCod) ? "" : StringUtil.Trim( StringUtil.Str( (decimal)(AV42ZonCod), 6, 0)));
         ucCombo_zoncod.SendProperty(context, "", false, Combo_zoncod_Internalname, "SelectedValue_set", Combo_zoncod_Selectedvalue_set);
      }

      protected void E17562( )
      {
         /* 'DoBtnExcel' Routine */
         returnInSub = false;
         context.DoAjaxRefresh();
         new pcuentacorrienteexcel(context ).execute( ref  AV32TipCcod, ref  AV5CliCod, ref  AV34TipCod, ref  AV23MonCod, ref  AV15FHasta, ref  AV42ZonCod, ref  AV28Serie, ref  AV37TipLetras, ref  AV40VenCod, out  AV10ExcelFilename, out  AV9ErrorMessage) ;
         AssignAttri("", false, "AV32TipCcod", StringUtil.LTrimStr( (decimal)(AV32TipCcod), 6, 0));
         AssignAttri("", false, "AV5CliCod", AV5CliCod);
         AssignAttri("", false, "AV34TipCod", AV34TipCod);
         AssignAttri("", false, "AV23MonCod", StringUtil.LTrimStr( (decimal)(AV23MonCod), 6, 0));
         AssignAttri("", false, "AV15FHasta", context.localUtil.Format(AV15FHasta, "99/99/99"));
         AssignAttri("", false, "AV42ZonCod", StringUtil.LTrimStr( (decimal)(AV42ZonCod), 6, 0));
         AssignAttri("", false, "AV28Serie", AV28Serie);
         AssignAttri("", false, "AV37TipLetras", StringUtil.Str( (decimal)(AV37TipLetras), 1, 0));
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
      }

      protected void nextLoad( )
      {
      }

      protected void E18562( )
      {
         /* Load Routine */
         returnInSub = false;
      }

      protected void wb_table1_65_562( bool wbgen )
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
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 69,'',false,'',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavClicod_Internalname, StringUtil.RTrim( AV5CliCod), StringUtil.RTrim( context.localUtil.Format( AV5CliCod, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,69);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavClicod_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtavClicod_Enabled, 0, "text", "", 20, "chr", 1, "row", 20, 0, 0, 0, 1, -1, -1, true, "", "left", true, "", "HLP_Ventas\\R_CuentasxCobrarZonas.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "<td class='CellPaddingLeft10'>") ;
            /* Active images/pictures */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 71,'',false,'',0)\"";
            ClassString = "Image";
            StyleString = "";
            sImgUrl = (string)(context.GetImagePath( "f5b04895-0024-488b-8e3b-b687ca4598ee", "", context.GetTheme( )));
            GxWebStd.gx_bitmap( context, imgBtnbuscar_Internalname, sImgUrl, "", "", "", context.GetTheme( ), 1, 1, "", "Buscar Cliente", 0, 0, 0, "px", 0, "px", 0, 0, 7, imgBtnbuscar_Jsonclick, "'"+""+"'"+",false,"+"'"+"e19561_client"+"'", StyleString, ClassString, "", "", "", "", " "+"data-gx-image"+" "+TempTags, "", "", 1, false, false, context.GetImageSrcSet( sImgUrl), "HLP_Ventas\\R_CuentasxCobrarZonas.htm");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "<td class='DataContentCell'>") ;
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "left", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavClidsc_Internalname, "Descripción Cliente", "gx-form-item ReadonlyAttributeLabel", 0, true, "width: 25%;");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 74,'',false,'',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavClidsc_Internalname, StringUtil.RTrim( AV7CliDsc), StringUtil.RTrim( context.localUtil.Format( AV7CliDsc, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,74);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavClidsc_Jsonclick, 0, "ReadonlyAttribute", "", "", "", "", 1, edtavClidsc_Enabled, 0, "text", "", 80, "chr", 1, "row", 100, 0, 0, 0, 1, -1, -1, true, "", "left", true, "", "HLP_Ventas\\R_CuentasxCobrarZonas.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "</tr>") ;
            /* End of table */
            context.WriteHtmlText( "</table>") ;
            wb_table1_65_562e( true) ;
         }
         else
         {
            wb_table1_65_562e( false) ;
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
         PA562( ) ;
         WS562( ) ;
         WE562( ) ;
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
            context.AddJavascriptSource(StringUtil.RTrim( ((string)Form.Jscriptsrc.Item(idxLst))), "?202281810313125", true, true);
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
         context.AddJavascriptSource("ventas/r_cuentasxcobrarzonas.js", "?202281810313125", false, true);
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
         /* End function init_web_controls */
      }

      protected void init_default_properties( )
      {
         lblTextblockcombo_zoncod_Internalname = "TEXTBLOCKCOMBO_ZONCOD";
         Combo_zoncod_Internalname = "COMBO_ZONCOD";
         divTablesplittedzoncod_Internalname = "TABLESPLITTEDZONCOD";
         lblTextblockcombo_tipcod_Internalname = "TEXTBLOCKCOMBO_TIPCOD";
         Combo_tipcod_Internalname = "COMBO_TIPCOD";
         divTablesplittedtipcod_Internalname = "TABLESPLITTEDTIPCOD";
         lblTextblockcombo_estcod_Internalname = "TEXTBLOCKCOMBO_ESTCOD";
         Combo_estcod_Internalname = "COMBO_ESTCOD";
         divTablesplittedestcod_Internalname = "TABLESPLITTEDESTCOD";
         lblTextblockcombo_provcod_Internalname = "TEXTBLOCKCOMBO_PROVCOD";
         Combo_provcod_Internalname = "COMBO_PROVCOD";
         divTablesplittedprovcod_Internalname = "TABLESPLITTEDPROVCOD";
         lblTextblockcombo_disccod_Internalname = "TEXTBLOCKCOMBO_DISCCOD";
         Combo_disccod_Internalname = "COMBO_DISCCOD";
         divTablesplitteddisccod_Internalname = "TABLESPLITTEDDISCCOD";
         lblTextblockclicod_Internalname = "TEXTBLOCKCLICOD";
         edtavClicod_Internalname = "vCLICOD";
         imgBtnbuscar_Internalname = "BTNBUSCAR";
         edtavClidsc_Internalname = "vCLIDSC";
         tblTablemergedclicod_Internalname = "TABLEMERGEDCLICOD";
         divTablesplittedclicod_Internalname = "TABLESPLITTEDCLICOD";
         lblTextblockcombo_moncod_Internalname = "TEXTBLOCKCOMBO_MONCOD";
         Combo_moncod_Internalname = "COMBO_MONCOD";
         divTablesplittedmoncod_Internalname = "TABLESPLITTEDMONCOD";
         lblTextblockfhasta_Internalname = "TEXTBLOCKFHASTA";
         edtavFhasta_Internalname = "vFHASTA";
         divUnnamedtablefhasta_Internalname = "UNNAMEDTABLEFHASTA";
         divPanel1_Internalname = "PANEL1";
         Dvpanel_panel1_Internalname = "DVPANEL_PANEL1";
         bttBtnbtnimprimir_Internalname = "BTNBTNIMPRIMIR";
         bttBtnbtnsalir_Internalname = "BTNBTNSALIR";
         Innewwindow_Internalname = "INNEWWINDOW";
         divTablecontent_Internalname = "TABLECONTENT";
         divTablemain_Internalname = "TABLEMAIN";
         edtavZoncod_Internalname = "vZONCOD";
         edtavTipcod_Internalname = "vTIPCOD";
         edtavEstcod_Internalname = "vESTCOD";
         edtavProvcod_Internalname = "vPROVCOD";
         edtavDisccod_Internalname = "vDISCCOD";
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
         edtavClidsc_Jsonclick = "";
         edtavClidsc_Enabled = 1;
         edtavClicod_Jsonclick = "";
         edtavClicod_Enabled = 1;
         edtavMoncod_Jsonclick = "";
         edtavMoncod_Visible = 1;
         edtavDisccod_Jsonclick = "";
         edtavDisccod_Visible = 1;
         edtavProvcod_Jsonclick = "";
         edtavProvcod_Visible = 1;
         edtavEstcod_Jsonclick = "";
         edtavEstcod_Visible = 1;
         edtavTipcod_Jsonclick = "";
         edtavTipcod_Visible = 1;
         edtavZoncod_Jsonclick = "";
         edtavZoncod_Visible = 1;
         edtavFhasta_Jsonclick = "";
         edtavFhasta_Enabled = 1;
         Combo_moncod_Caption = "";
         Combo_disccod_Caption = "";
         Combo_provcod_Caption = "";
         Combo_estcod_Caption = "";
         Combo_tipcod_Caption = "";
         Combo_zoncod_Caption = "";
         Innewwindow_Target = "";
         Dvpanel_panel1_Autoscroll = Convert.ToBoolean( 0);
         Dvpanel_panel1_Iconposition = "Right";
         Dvpanel_panel1_Showcollapseicon = Convert.ToBoolean( 0);
         Dvpanel_panel1_Collapsed = Convert.ToBoolean( 0);
         Dvpanel_panel1_Collapsible = Convert.ToBoolean( -1);
         Dvpanel_panel1_Title = "Reporte de Cuentas por cobrar por Zonas";
         Dvpanel_panel1_Cls = "PanelFilled Panel_BaseColor";
         Dvpanel_panel1_Autoheight = Convert.ToBoolean( -1);
         Dvpanel_panel1_Autowidth = Convert.ToBoolean( 0);
         Dvpanel_panel1_Width = "100%";
         Combo_moncod_Cls = "ExtendedCombo AttributeRealWidth50With";
         Combo_disccod_Datalistprocparametersprefix = "";
         Combo_disccod_Datalistproc = "Ventas.R_CuentasxCobrarZonasLoadDVCombo";
         Combo_disccod_Cls = "ExtendedCombo AttributeRealWidth50With";
         Combo_provcod_Datalistprocparametersprefix = "";
         Combo_provcod_Datalistproc = "Ventas.R_CuentasxCobrarZonasLoadDVCombo";
         Combo_provcod_Cls = "ExtendedCombo AttributeRealWidth50With";
         Combo_estcod_Cls = "ExtendedCombo AttributeRealWidth50With";
         Combo_tipcod_Cls = "ExtendedCombo AttributeRealWidth50With";
         Combo_zoncod_Cls = "ExtendedCombo AttributeRealWidth50With";
         Form.Headerrawhtml = "";
         Form.Background = "";
         Form.Textcolor = 0;
         Form.Backcolor = (int)(0xFFFFFF);
         Form.Caption = "Cuentas por cobrar por Zonas";
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
         setEventMetadata("REFRESH","{handler:'Refresh',iparms:[{av:'AV53Agrupa',fld:'vAGRUPA',pic:'9',hsh:true},{av:'AV52DisCod',fld:'vDISCOD',pic:'',hsh:true}]");
         setEventMetadata("REFRESH",",oparms:[]}");
         setEventMetadata("'DOBTNIMPRIMIR'","{handler:'E15562',iparms:[{av:'AV34TipCod',fld:'vTIPCOD',pic:''},{av:'AV5CliCod',fld:'vCLICOD',pic:''},{av:'AV23MonCod',fld:'vMONCOD',pic:'ZZZZZ9'},{av:'AV42ZonCod',fld:'vZONCOD',pic:'ZZZZZ9'},{av:'AV53Agrupa',fld:'vAGRUPA',pic:'9',hsh:true},{av:'AV52DisCod',fld:'vDISCOD',pic:'',hsh:true},{av:'AV15FHasta',fld:'vFHASTA',pic:''}]");
         setEventMetadata("'DOBTNIMPRIMIR'",",oparms:[{av:'Innewwindow_Target',ctrl:'INNEWWINDOW',prop:'Target'}]}");
         setEventMetadata("'DOBTNSALIR'","{handler:'E16562',iparms:[]");
         setEventMetadata("'DOBTNSALIR'",",oparms:[]}");
         setEventMetadata("COMBO_DISCCOD.ONOPTIONCLICKED","{handler:'E13562',iparms:[{av:'Combo_disccod_Selectedvalue_get',ctrl:'COMBO_DISCCOD',prop:'SelectedValue_get'}]");
         setEventMetadata("COMBO_DISCCOD.ONOPTIONCLICKED",",oparms:[{av:'AV50DiscCod',fld:'vDISCCOD',pic:''}]}");
         setEventMetadata("COMBO_PROVCOD.ONOPTIONCLICKED","{handler:'E12562',iparms:[{av:'Combo_provcod_Selectedvalue_get',ctrl:'COMBO_PROVCOD',prop:'SelectedValue_get'}]");
         setEventMetadata("COMBO_PROVCOD.ONOPTIONCLICKED",",oparms:[{av:'AV45ProvCod',fld:'vPROVCOD',pic:''}]}");
         setEventMetadata("COMBO_ESTCOD.ONOPTIONCLICKED","{handler:'E11562',iparms:[{av:'AV44EstCod',fld:'vESTCOD',pic:''},{av:'Combo_estcod_Selectedvalue_get',ctrl:'COMBO_ESTCOD',prop:'SelectedValue_get'}]");
         setEventMetadata("COMBO_ESTCOD.ONOPTIONCLICKED",",oparms:[{av:'AV44EstCod',fld:'vESTCOD',pic:''},{av:'AV45ProvCod',fld:'vPROVCOD',pic:''},{av:'Combo_provcod_Selectedvalue_set',ctrl:'COMBO_PROVCOD',prop:'SelectedValue_set'},{av:'Combo_provcod_Selectedtext_set',ctrl:'COMBO_PROVCOD',prop:'SelectedText_set'},{av:'AV50DiscCod',fld:'vDISCCOD',pic:''},{av:'Combo_disccod_Selectedvalue_set',ctrl:'COMBO_DISCCOD',prop:'SelectedValue_set'},{av:'Combo_disccod_Selectedtext_set',ctrl:'COMBO_DISCCOD',prop:'SelectedText_set'}]}");
         setEventMetadata("'DOBTNEXCEL'","{handler:'E17562',iparms:[{av:'AV32TipCcod',fld:'vTIPCCOD',pic:'ZZZZZ9'},{av:'AV5CliCod',fld:'vCLICOD',pic:''},{av:'AV34TipCod',fld:'vTIPCOD',pic:''},{av:'AV23MonCod',fld:'vMONCOD',pic:'ZZZZZ9'},{av:'AV15FHasta',fld:'vFHASTA',pic:''},{av:'AV42ZonCod',fld:'vZONCOD',pic:'ZZZZZ9'},{av:'AV28Serie',fld:'vSERIE',pic:''},{av:'AV37TipLetras',fld:'vTIPLETRAS',pic:'9'},{av:'AV40VenCod',fld:'vVENCOD',pic:'ZZZZZ9'}]");
         setEventMetadata("'DOBTNEXCEL'",",oparms:[{av:'AV40VenCod',fld:'vVENCOD',pic:'ZZZZZ9'},{av:'AV37TipLetras',fld:'vTIPLETRAS',pic:'9'},{av:'AV28Serie',fld:'vSERIE',pic:''},{av:'AV42ZonCod',fld:'vZONCOD',pic:'ZZZZZ9'},{av:'AV15FHasta',fld:'vFHASTA',pic:''},{av:'AV23MonCod',fld:'vMONCOD',pic:'ZZZZZ9'},{av:'AV34TipCod',fld:'vTIPCOD',pic:''},{av:'AV5CliCod',fld:'vCLICOD',pic:''},{av:'AV32TipCcod',fld:'vTIPCCOD',pic:'ZZZZZ9'}]}");
         setEventMetadata("BTNBUSCAR.CLICK","{handler:'E19561',iparms:[]");
         setEventMetadata("BTNBUSCAR.CLICK",",oparms:[{av:'AV7CliDsc',fld:'vCLIDSC',pic:''},{av:'AV5CliCod',fld:'vCLICOD',pic:''}]}");
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
         Combo_moncod_Selectedvalue_get = "";
         Combo_disccod_Selectedvalue_get = "";
         Combo_provcod_Selectedvalue_get = "";
         Combo_estcod_Selectedvalue_get = "";
         Combo_tipcod_Selectedvalue_get = "";
         Combo_zoncod_Selectedvalue_get = "";
         gxfirstwebparm = "";
         gxfirstwebparm_bkp = "";
         sDynURL = "";
         FormProcess = "";
         bodyStyle = "";
         AV52DisCod = "";
         GXKey = "";
         AV47DDO_TitleSettingsIcons = new GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTDropDownOptionsTitleSettingsIcons(context);
         AV43ZonCod_Data = new GXBaseCollection<GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTComboData_Item>( context, "Item", "");
         AV35TipCod_Data = new GXBaseCollection<GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTComboData_Item>( context, "Item", "");
         AV46EstCod_Data = new GXBaseCollection<GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTComboData_Item>( context, "Item", "");
         AV48ProvCod_Data = new GXBaseCollection<GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTComboData_Item>( context, "Item", "");
         AV51DiscCod_Data = new GXBaseCollection<GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTComboData_Item>( context, "Item", "");
         AV24MonCod_Data = new GXBaseCollection<GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTComboData_Item>( context, "Item", "");
         AV28Serie = "";
         Combo_zoncod_Selectedvalue_set = "";
         Combo_tipcod_Selectedvalue_set = "";
         Combo_estcod_Selectedvalue_set = "";
         Combo_provcod_Selectedvalue_set = "";
         Combo_provcod_Selectedtext_set = "";
         Combo_disccod_Selectedvalue_set = "";
         Combo_disccod_Selectedtext_set = "";
         Combo_moncod_Selectedvalue_set = "";
         GX_FocusControl = "";
         Form = new GXWebForm();
         sPrefix = "";
         ClassString = "";
         StyleString = "";
         ucDvpanel_panel1 = new GXUserControl();
         lblTextblockcombo_zoncod_Jsonclick = "";
         ucCombo_zoncod = new GXUserControl();
         lblTextblockcombo_tipcod_Jsonclick = "";
         ucCombo_tipcod = new GXUserControl();
         lblTextblockcombo_estcod_Jsonclick = "";
         ucCombo_estcod = new GXUserControl();
         lblTextblockcombo_provcod_Jsonclick = "";
         ucCombo_provcod = new GXUserControl();
         lblTextblockcombo_disccod_Jsonclick = "";
         ucCombo_disccod = new GXUserControl();
         lblTextblockclicod_Jsonclick = "";
         lblTextblockcombo_moncod_Jsonclick = "";
         ucCombo_moncod = new GXUserControl();
         lblTextblockfhasta_Jsonclick = "";
         TempTags = "";
         AV15FHasta = DateTime.MinValue;
         bttBtnbtnimprimir_Jsonclick = "";
         bttBtnbtnsalir_Jsonclick = "";
         ucInnewwindow = new GXUserControl();
         AV34TipCod = "";
         AV44EstCod = "";
         AV45ProvCod = "";
         AV50DiscCod = "";
         sEvt = "";
         EvtGridId = "";
         EvtRowId = "";
         sEvtType = "";
         AV5CliCod = "";
         AV7CliDsc = "";
         GXt_SdtDVB_SDTDropDownOptionsTitleSettingsIcons1 = new GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTDropDownOptionsTitleSettingsIcons(context);
         GXEncryptionTmp = "";
         AV49Cond_EstCod = "";
         scmdbuf = "";
         H00562_A1235MonSts = new short[1] ;
         H00562_A180MonCod = new int[1] ;
         H00562_A1234MonDsc = new string[] {""} ;
         A1234MonDsc = "";
         AV8Combo_DataItem = new GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTComboData_Item(context);
         H00563_A139PaiCod = new string[] {""} ;
         H00563_A140EstCod = new string[] {""} ;
         H00563_A141ProvCod = new string[] {""} ;
         H00563_A878DisSts = new short[1] ;
         H00563_A142DisCod = new string[] {""} ;
         H00563_A604DisDsc = new string[] {""} ;
         A142DisCod = "";
         A604DisDsc = "";
         H00564_A139PaiCod = new string[] {""} ;
         H00564_A140EstCod = new string[] {""} ;
         H00564_A1742ProvSts = new short[1] ;
         H00564_A141ProvCod = new string[] {""} ;
         H00564_A603ProvDsc = new string[] {""} ;
         A141ProvCod = "";
         A603ProvDsc = "";
         H00565_A139PaiCod = new string[] {""} ;
         H00565_A975EstSts = new short[1] ;
         H00565_A140EstCod = new string[] {""} ;
         H00565_A602EstDsc = new string[] {""} ;
         A140EstCod = "";
         A602EstDsc = "";
         H00566_A1919TipSts = new short[1] ;
         H00566_A149TipCod = new string[] {""} ;
         H00566_A1910TipDsc = new string[] {""} ;
         A149TipCod = "";
         A1910TipDsc = "";
         H00567_A2095ZonSts = new short[1] ;
         H00567_A158ZonCod = new int[1] ;
         H00567_A2094ZonDsc = new string[] {""} ;
         A2094ZonDsc = "";
         AV10ExcelFilename = "";
         AV9ErrorMessage = "";
         sStyleString = "";
         sImgUrl = "";
         imgBtnbuscar_Jsonclick = "";
         BackMsgLst = new msglist();
         LclMsgLst = new msglist();
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.ventas.r_cuentasxcobrarzonas__default(),
            new Object[][] {
                new Object[] {
               H00562_A1235MonSts, H00562_A180MonCod, H00562_A1234MonDsc
               }
               , new Object[] {
               H00563_A139PaiCod, H00563_A140EstCod, H00563_A141ProvCod, H00563_A878DisSts, H00563_A142DisCod, H00563_A604DisDsc
               }
               , new Object[] {
               H00564_A139PaiCod, H00564_A140EstCod, H00564_A1742ProvSts, H00564_A141ProvCod, H00564_A603ProvDsc
               }
               , new Object[] {
               H00565_A139PaiCod, H00565_A975EstSts, H00565_A140EstCod, H00565_A602EstDsc
               }
               , new Object[] {
               H00566_A1919TipSts, H00566_A149TipCod, H00566_A1910TipDsc
               }
               , new Object[] {
               H00567_A2095ZonSts, H00567_A158ZonCod, H00567_A2094ZonDsc
               }
            }
         );
         AV23MonCod = 0;
         /* GeneXus formulas. */
         context.Gx_err = 0;
         edtavClidsc_Enabled = 0;
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
      private short AV53Agrupa ;
      private short AV37TipLetras ;
      private short wbEnd ;
      private short wbStart ;
      private short nDonePA ;
      private short A1235MonSts ;
      private short AV57GXLvl158 ;
      private short A878DisSts ;
      private short AV58GXLvl179 ;
      private short A1742ProvSts ;
      private short A975EstSts ;
      private short A1919TipSts ;
      private short A2095ZonSts ;
      private short nGXWrapped ;
      private int AV32TipCcod ;
      private int AV40VenCod ;
      private int edtavFhasta_Enabled ;
      private int AV42ZonCod ;
      private int edtavZoncod_Visible ;
      private int edtavTipcod_Visible ;
      private int edtavEstcod_Visible ;
      private int edtavProvcod_Visible ;
      private int edtavDisccod_Visible ;
      private int AV23MonCod ;
      private int edtavMoncod_Visible ;
      private int edtavClidsc_Enabled ;
      private int A180MonCod ;
      private int A158ZonCod ;
      private int edtavClicod_Enabled ;
      private int idxLst ;
      private string Combo_moncod_Selectedvalue_get ;
      private string Combo_disccod_Selectedvalue_get ;
      private string Combo_provcod_Selectedvalue_get ;
      private string Combo_estcod_Selectedvalue_get ;
      private string Combo_tipcod_Selectedvalue_get ;
      private string Combo_zoncod_Selectedvalue_get ;
      private string gxfirstwebparm ;
      private string gxfirstwebparm_bkp ;
      private string sDynURL ;
      private string FormProcess ;
      private string bodyStyle ;
      private string AV52DisCod ;
      private string GXKey ;
      private string AV28Serie ;
      private string Combo_zoncod_Cls ;
      private string Combo_zoncod_Selectedvalue_set ;
      private string Combo_tipcod_Cls ;
      private string Combo_tipcod_Selectedvalue_set ;
      private string Combo_estcod_Cls ;
      private string Combo_estcod_Selectedvalue_set ;
      private string Combo_provcod_Cls ;
      private string Combo_provcod_Selectedvalue_set ;
      private string Combo_provcod_Selectedtext_set ;
      private string Combo_provcod_Datalistproc ;
      private string Combo_provcod_Datalistprocparametersprefix ;
      private string Combo_disccod_Cls ;
      private string Combo_disccod_Selectedvalue_set ;
      private string Combo_disccod_Selectedtext_set ;
      private string Combo_disccod_Datalistproc ;
      private string Combo_disccod_Datalistprocparametersprefix ;
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
      private string divTablesplittedzoncod_Internalname ;
      private string lblTextblockcombo_zoncod_Internalname ;
      private string lblTextblockcombo_zoncod_Jsonclick ;
      private string Combo_zoncod_Caption ;
      private string Combo_zoncod_Internalname ;
      private string divTablesplittedtipcod_Internalname ;
      private string lblTextblockcombo_tipcod_Internalname ;
      private string lblTextblockcombo_tipcod_Jsonclick ;
      private string Combo_tipcod_Caption ;
      private string Combo_tipcod_Internalname ;
      private string divTablesplittedestcod_Internalname ;
      private string lblTextblockcombo_estcod_Internalname ;
      private string lblTextblockcombo_estcod_Jsonclick ;
      private string Combo_estcod_Caption ;
      private string Combo_estcod_Internalname ;
      private string divTablesplittedprovcod_Internalname ;
      private string lblTextblockcombo_provcod_Internalname ;
      private string lblTextblockcombo_provcod_Jsonclick ;
      private string Combo_provcod_Caption ;
      private string Combo_provcod_Internalname ;
      private string divTablesplitteddisccod_Internalname ;
      private string lblTextblockcombo_disccod_Internalname ;
      private string lblTextblockcombo_disccod_Jsonclick ;
      private string Combo_disccod_Caption ;
      private string Combo_disccod_Internalname ;
      private string divTablesplittedclicod_Internalname ;
      private string lblTextblockclicod_Internalname ;
      private string lblTextblockclicod_Jsonclick ;
      private string divTablesplittedmoncod_Internalname ;
      private string lblTextblockcombo_moncod_Internalname ;
      private string lblTextblockcombo_moncod_Jsonclick ;
      private string Combo_moncod_Caption ;
      private string Combo_moncod_Internalname ;
      private string divUnnamedtablefhasta_Internalname ;
      private string lblTextblockfhasta_Internalname ;
      private string lblTextblockfhasta_Jsonclick ;
      private string edtavFhasta_Internalname ;
      private string TempTags ;
      private string edtavFhasta_Jsonclick ;
      private string bttBtnbtnimprimir_Internalname ;
      private string bttBtnbtnimprimir_Jsonclick ;
      private string bttBtnbtnsalir_Internalname ;
      private string bttBtnbtnsalir_Jsonclick ;
      private string Innewwindow_Internalname ;
      private string divHtml_bottomauxiliarcontrols_Internalname ;
      private string edtavZoncod_Internalname ;
      private string edtavZoncod_Jsonclick ;
      private string edtavTipcod_Internalname ;
      private string AV34TipCod ;
      private string edtavTipcod_Jsonclick ;
      private string edtavEstcod_Internalname ;
      private string AV44EstCod ;
      private string edtavEstcod_Jsonclick ;
      private string edtavProvcod_Internalname ;
      private string AV45ProvCod ;
      private string edtavProvcod_Jsonclick ;
      private string edtavDisccod_Internalname ;
      private string AV50DiscCod ;
      private string edtavDisccod_Jsonclick ;
      private string edtavMoncod_Internalname ;
      private string edtavMoncod_Jsonclick ;
      private string sEvt ;
      private string EvtGridId ;
      private string EvtRowId ;
      private string sEvtType ;
      private string edtavClicod_Internalname ;
      private string edtavClidsc_Internalname ;
      private string AV5CliCod ;
      private string AV7CliDsc ;
      private string GXEncryptionTmp ;
      private string AV49Cond_EstCod ;
      private string scmdbuf ;
      private string A1234MonDsc ;
      private string A142DisCod ;
      private string A604DisDsc ;
      private string A141ProvCod ;
      private string A603ProvDsc ;
      private string A140EstCod ;
      private string A602EstDsc ;
      private string A149TipCod ;
      private string A1910TipDsc ;
      private string A2094ZonDsc ;
      private string sStyleString ;
      private string tblTablemergedclicod_Internalname ;
      private string edtavClicod_Jsonclick ;
      private string sImgUrl ;
      private string imgBtnbuscar_Internalname ;
      private string imgBtnbuscar_Jsonclick ;
      private string edtavClidsc_Jsonclick ;
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
      private string AV10ExcelFilename ;
      private string AV9ErrorMessage ;
      private GXUserControl ucDvpanel_panel1 ;
      private GXUserControl ucCombo_zoncod ;
      private GXUserControl ucCombo_tipcod ;
      private GXUserControl ucCombo_estcod ;
      private GXUserControl ucCombo_provcod ;
      private GXUserControl ucCombo_disccod ;
      private GXUserControl ucCombo_moncod ;
      private GXUserControl ucInnewwindow ;
      private IGxDataStore dsDataStore2 ;
      private IGxDataStore dsDefault ;
      private IDataStoreProvider pr_default ;
      private short[] H00562_A1235MonSts ;
      private int[] H00562_A180MonCod ;
      private string[] H00562_A1234MonDsc ;
      private string[] H00563_A139PaiCod ;
      private string[] H00563_A140EstCod ;
      private string[] H00563_A141ProvCod ;
      private short[] H00563_A878DisSts ;
      private string[] H00563_A142DisCod ;
      private string[] H00563_A604DisDsc ;
      private string[] H00564_A139PaiCod ;
      private string[] H00564_A140EstCod ;
      private short[] H00564_A1742ProvSts ;
      private string[] H00564_A141ProvCod ;
      private string[] H00564_A603ProvDsc ;
      private string[] H00565_A139PaiCod ;
      private short[] H00565_A975EstSts ;
      private string[] H00565_A140EstCod ;
      private string[] H00565_A602EstDsc ;
      private short[] H00566_A1919TipSts ;
      private string[] H00566_A149TipCod ;
      private string[] H00566_A1910TipDsc ;
      private short[] H00567_A2095ZonSts ;
      private int[] H00567_A158ZonCod ;
      private string[] H00567_A2094ZonDsc ;
      private msglist BackMsgLst ;
      private msglist LclMsgLst ;
      private GXBaseCollection<GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTComboData_Item> AV43ZonCod_Data ;
      private GXBaseCollection<GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTComboData_Item> AV35TipCod_Data ;
      private GXBaseCollection<GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTComboData_Item> AV46EstCod_Data ;
      private GXBaseCollection<GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTComboData_Item> AV48ProvCod_Data ;
      private GXBaseCollection<GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTComboData_Item> AV51DiscCod_Data ;
      private GXBaseCollection<GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTComboData_Item> AV24MonCod_Data ;
      private GXWebForm Form ;
      private GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTComboData_Item AV8Combo_DataItem ;
      private GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTDropDownOptionsTitleSettingsIcons AV47DDO_TitleSettingsIcons ;
      private GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTDropDownOptionsTitleSettingsIcons GXt_SdtDVB_SDTDropDownOptionsTitleSettingsIcons1 ;
   }

   public class r_cuentasxcobrarzonas__default : DataStoreHelperBase, IDataStoreHelper
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
          Object[] prmH00562;
          prmH00562 = new Object[] {
          };
          Object[] prmH00563;
          prmH00563 = new Object[] {
          new ParDef("@AV50DiscCod",GXType.NChar,4,0)
          };
          Object[] prmH00564;
          prmH00564 = new Object[] {
          new ParDef("@AV45ProvCod",GXType.NChar,4,0)
          };
          Object[] prmH00565;
          prmH00565 = new Object[] {
          };
          Object[] prmH00566;
          prmH00566 = new Object[] {
          };
          Object[] prmH00567;
          prmH00567 = new Object[] {
          };
          def= new CursorDef[] {
              new CursorDef("H00562", "SELECT [MonSts], [MonCod], [MonDsc] FROM [CMONEDAS] WHERE [MonSts] = 1 ORDER BY [MonDsc] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH00562,100, GxCacheFrequency.OFF ,false,false )
             ,new CursorDef("H00563", "SELECT TOP 1 [PaiCod], [EstCod], [ProvCod], [DisSts], [DisCod], [DisDsc] FROM [CDISTRITOS] WHERE ([DisCod] = @AV50DiscCod) AND ([DisSts] = 1) ORDER BY [PaiCod], [EstCod], [ProvCod], [DisCod] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH00563,1, GxCacheFrequency.OFF ,false,true )
             ,new CursorDef("H00564", "SELECT TOP 1 [PaiCod], [EstCod], [ProvSts], [ProvCod], [ProvDsc] FROM [CPROVINCIA] WHERE ([ProvCod] = @AV45ProvCod) AND ([ProvSts] = 1) ORDER BY [PaiCod], [EstCod], [ProvCod] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH00564,1, GxCacheFrequency.OFF ,false,true )
             ,new CursorDef("H00565", "SELECT [PaiCod], [EstSts], [EstCod], [EstDsc] FROM [CESTADOS] WHERE [EstSts] = 1 ORDER BY [EstDsc] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH00565,100, GxCacheFrequency.OFF ,false,false )
             ,new CursorDef("H00566", "SELECT [TipSts], [TipCod], [TipDsc] FROM [CTIPDOC] WHERE [TipSts] = 1 ORDER BY [TipDsc] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH00566,100, GxCacheFrequency.OFF ,false,false )
             ,new CursorDef("H00567", "SELECT [ZonSts], [ZonCod], [ZonDsc] FROM [CZONAS] WHERE [ZonSts] = 1 ORDER BY [ZonDsc] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH00567,100, GxCacheFrequency.OFF ,false,false )
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
                ((string[]) buf[0])[0] = rslt.getString(1, 4);
                ((string[]) buf[1])[0] = rslt.getString(2, 4);
                ((string[]) buf[2])[0] = rslt.getString(3, 4);
                ((short[]) buf[3])[0] = rslt.getShort(4);
                ((string[]) buf[4])[0] = rslt.getString(5, 4);
                ((string[]) buf[5])[0] = rslt.getString(6, 100);
                return;
             case 2 :
                ((string[]) buf[0])[0] = rslt.getString(1, 4);
                ((string[]) buf[1])[0] = rslt.getString(2, 4);
                ((short[]) buf[2])[0] = rslt.getShort(3);
                ((string[]) buf[3])[0] = rslt.getString(4, 4);
                ((string[]) buf[4])[0] = rslt.getString(5, 100);
                return;
             case 3 :
                ((string[]) buf[0])[0] = rslt.getString(1, 4);
                ((short[]) buf[1])[0] = rslt.getShort(2);
                ((string[]) buf[2])[0] = rslt.getString(3, 4);
                ((string[]) buf[3])[0] = rslt.getString(4, 100);
                return;
             case 4 :
                ((short[]) buf[0])[0] = rslt.getShort(1);
                ((string[]) buf[1])[0] = rslt.getString(2, 3);
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
