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
namespace GeneXus.Programs.wwpbaseobjects {
   public class wwp_masterpagenotifications : GXWebComponent
   {
      public wwp_masterpagenotifications( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDataStore2 = context.GetDataStore("DataStore2");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         if ( StringUtil.Len( (string)(sPrefix)) == 0 )
         {
            context.SetDefaultTheme("WorkWithPlusTheme");
         }
      }

      public wwp_masterpagenotifications( IGxContext context )
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

      public override void SetPrefix( string sPPrefix )
      {
         sPrefix = sPPrefix;
      }

      protected override void createObjects( )
      {
      }

      protected void INITWEB( )
      {
         initialize_properties( ) ;
         if ( StringUtil.Len( (string)(sPrefix)) == 0 )
         {
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
               else if ( StringUtil.StrCmp(gxfirstwebparm, "dyncomponent") == 0 )
               {
                  setAjaxEventMode();
                  if ( ! IsValidAjaxCall( true) )
                  {
                     GxWebError = 1;
                     return  ;
                  }
                  nDynComponent = 1;
                  sCompPrefix = GetPar( "sCompPrefix");
                  sSFPrefix = GetPar( "sSFPrefix");
                  setjustcreated();
                  componentprepare(new Object[] {(string)sCompPrefix,(string)sSFPrefix});
                  componentstart();
                  context.httpAjaxContext.ajax_rspStartCmp(sPrefix);
                  componentdraw();
                  context.httpAjaxContext.ajax_rspEndCmp();
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
               else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxNewRow_"+"Gridsdtnotificationsdatas") == 0 )
               {
                  nRC_GXsfl_15 = (int)(NumberUtil.Val( GetPar( "nRC_GXsfl_15"), "."));
                  nGXsfl_15_idx = (int)(NumberUtil.Val( GetPar( "nGXsfl_15_idx"), "."));
                  sGXsfl_15_idx = GetPar( "sGXsfl_15_idx");
                  sPrefix = GetPar( "sPrefix");
                  setAjaxCallMode();
                  if ( ! IsValidAjaxCall( true) )
                  {
                     GxWebError = 1;
                     return  ;
                  }
                  gxnrGridsdtnotificationsdatas_newrow( ) ;
                  return  ;
               }
               else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxGridRefresh_"+"Gridsdtnotificationsdatas") == 0 )
               {
                  ajax_req_read_hidden_sdt(GetNextPar( ), AV6SDTNotificationsData);
                  sPrefix = GetPar( "sPrefix");
                  init_default_properties( ) ;
                  setAjaxCallMode();
                  if ( ! IsValidAjaxCall( true) )
                  {
                     GxWebError = 1;
                     return  ;
                  }
                  gxgrGridsdtnotificationsdatas_refresh( AV6SDTNotificationsData, sPrefix) ;
                  AddString( context.getJSONResponse( )) ;
                  return  ;
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
         }
         if ( StringUtil.Len( sPrefix) == 0 )
         {
            if ( ! context.IsLocalStorageSupported( ) )
            {
               context.PushCurrentUrl();
            }
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
            if ( StringUtil.Len( sPrefix) == 0 )
            {
               ValidateSpaRequest();
            }
            PA3T2( ) ;
            if ( ( GxWebError == 0 ) && ! isAjaxCallMode( ) )
            {
               /* GeneXus formulas. */
               context.Gx_err = 0;
               edtavSdtnotificationsdata__notificationtitle_Enabled = 0;
               AssignProp(sPrefix, false, edtavSdtnotificationsdata__notificationtitle_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavSdtnotificationsdata__notificationtitle_Enabled), 5, 0), !bGXsfl_15_Refreshing);
               edtavSdtnotificationsdata__notificationdescription_Enabled = 0;
               AssignProp(sPrefix, false, edtavSdtnotificationsdata__notificationdescription_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavSdtnotificationsdata__notificationdescription_Enabled), 5, 0), !bGXsfl_15_Refreshing);
               edtavSdtnotificationsdata__notificationdatetime_Enabled = 0;
               AssignProp(sPrefix, false, edtavSdtnotificationsdata__notificationdatetime_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavSdtnotificationsdata__notificationdatetime_Enabled), 5, 0), !bGXsfl_15_Refreshing);
               WS3T2( ) ;
               if ( ! isAjaxCallMode( ) )
               {
                  if ( nDynComponent == 0 )
                  {
                     throw new System.Net.WebException("WebComponent is not allowed to run") ;
                  }
               }
            }
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

      protected void RenderHtmlHeaders( )
      {
         GxWebStd.gx_html_headers( context, 0, "", "", Form.Meta, Form.Metaequiv, true);
      }

      protected void RenderHtmlOpenForm( )
      {
         if ( StringUtil.Len( sPrefix) == 0 )
         {
            if ( context.isSpaRequest( ) )
            {
               enableOutput();
            }
            context.WriteHtmlText( "<title>") ;
            context.SendWebValue( "Master Page Notifications") ;
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
         }
         if ( ( ( context.GetBrowserType( ) == 1 ) || ( context.GetBrowserType( ) == 5 ) ) && ( StringUtil.StrCmp(context.GetBrowserVersion( ), "7.0") == 0 ) )
         {
            context.AddJavascriptSource("json2.js", "?"+context.GetBuildNumber( 194480), false, true);
         }
         context.AddJavascriptSource("jquery.js", "?"+context.GetBuildNumber( 194480), false, true);
         context.AddJavascriptSource("gxgral.js", "?"+context.GetBuildNumber( 194480), false, true);
         context.AddJavascriptSource("gxcfg.js", "?2022818102713", false, true);
         if ( context.isSpaRequest( ) )
         {
            enableOutput();
         }
         context.AddJavascriptSource("calendar.js", "?"+context.GetBuildNumber( 194480), false, true);
         context.AddJavascriptSource("calendar-setup.js", "?"+context.GetBuildNumber( 194480), false, true);
         context.AddJavascriptSource("calendar-es.js", "?"+context.GetBuildNumber( 194480), false, true);
         if ( StringUtil.Len( sPrefix) == 0 )
         {
            context.CloseHtmlHeader();
            if ( context.isSpaRequest( ) )
            {
               disableOutput();
            }
            FormProcess = " data-HasEnter=\"false\" data-Skiponenter=\"false\"";
            context.WriteHtmlText( "<body ") ;
            bodyStyle = "";
            if ( nGXWrapped == 0 )
            {
               bodyStyle += "-moz-opacity:0;opacity:0;";
            }
            context.WriteHtmlText( " "+"class=\"form-horizontal Form\""+" "+ "style='"+bodyStyle+"'") ;
            context.WriteHtmlText( FormProcess+">") ;
            context.skipLines(1);
            context.WriteHtmlTextNl( "<form id=\"MAINFORM\" autocomplete=\"off\" name=\"MAINFORM\" method=\"post\" tabindex=-1  class=\"form-horizontal Form\" data-gx-class=\"form-horizontal Form\" novalidate action=\""+formatLink("wwpbaseobjects.wwp_masterpagenotifications.aspx") +"\">") ;
            GxWebStd.gx_hidden_field( context, "_EventName", "");
            GxWebStd.gx_hidden_field( context, "_EventGridId", "");
            GxWebStd.gx_hidden_field( context, "_EventRowId", "");
            context.WriteHtmlText( "<input type=\"submit\" title=\"submit\" style=\"display:block;height:0;border:0;padding:0\" disabled>") ;
            AssignProp(sPrefix, false, "FORM", "Class", "form-horizontal Form", true);
         }
         else
         {
            bool toggleHtmlOutput = isOutputEnabled( );
            if ( StringUtil.StringSearch( sPrefix, "MP", 1) == 1 )
            {
               if ( context.isSpaRequest( ) )
               {
                  disableOutput();
               }
            }
            context.WriteHtmlText( "<div") ;
            GxWebStd.ClassAttribute( context, "gxwebcomponent-body"+" "+(String.IsNullOrEmpty(StringUtil.RTrim( Form.Class)) ? "form-horizontal Form" : Form.Class)+"-fx");
            context.WriteHtmlText( ">") ;
            if ( toggleHtmlOutput )
            {
               if ( StringUtil.StringSearch( sPrefix, "MP", 1) == 1 )
               {
                  if ( context.isSpaRequest( ) )
                  {
                     enableOutput();
                  }
               }
            }
            toggleJsOutput = isJsOutputEnabled( );
            if ( context.isSpaRequest( ) )
            {
               disableJsOutput();
            }
         }
         if ( StringUtil.StringSearch( sPrefix, "MP", 1) == 1 )
         {
            if ( context.isSpaRequest( ) )
            {
               disableOutput();
            }
         }
      }

      protected void send_integrity_footer_hashes( )
      {
         GxWebStd.gx_hidden_field( context, sPrefix+"gxhash_vSDTNOTIFICATIONSDATA", GetSecureSignedToken( sPrefix, AV6SDTNotificationsData, context));
         GXKey = Crypto.GetSiteKey( );
      }

      protected void SendCloseFormHiddens( )
      {
         /* Send hidden variables. */
         /* Send saved values. */
         send_integrity_footer_hashes( ) ;
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri(sPrefix, false, sPrefix+"Sdtnotificationsdata", AV6SDTNotificationsData);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt(sPrefix+"Sdtnotificationsdata", AV6SDTNotificationsData);
         }
         GxWebStd.gx_hidden_field( context, sPrefix+"gxhash_Sdtnotificationsdata", GetSecureSignedToken( sPrefix, AV6SDTNotificationsData, context));
         GxWebStd.gx_hidden_field( context, sPrefix+"nRC_GXsfl_15", StringUtil.LTrim( StringUtil.NToC( (decimal)(nRC_GXsfl_15), 8, 0, ".", "")));
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri(sPrefix, false, sPrefix+"vSDTNOTIFICATIONSDATA", AV6SDTNotificationsData);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt(sPrefix+"vSDTNOTIFICATIONSDATA", AV6SDTNotificationsData);
         }
         GxWebStd.gx_hidden_field( context, sPrefix+"gxhash_vSDTNOTIFICATIONSDATA", GetSecureSignedToken( sPrefix, AV6SDTNotificationsData, context));
      }

      protected void RenderHtmlCloseForm3T2( )
      {
         SendCloseFormHiddens( ) ;
         if ( ( StringUtil.Len( sPrefix) != 0 ) && ( context.isAjaxRequest( ) || context.isSpaRequest( ) ) )
         {
            componentjscripts();
         }
         GxWebStd.gx_hidden_field( context, sPrefix+"GX_FocusControl", GX_FocusControl);
         define_styles( ) ;
         SendSecurityToken(sPrefix);
         if ( StringUtil.Len( sPrefix) == 0 )
         {
            SendAjaxEncryptionKey();
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
            context.WriteHtmlTextNl( "</body>") ;
            context.WriteHtmlTextNl( "</html>") ;
            if ( context.isSpaRequest( ) )
            {
               enableOutput();
            }
         }
         else
         {
            SendWebComponentState();
            context.WriteHtmlText( "</div>") ;
            if ( toggleJsOutput )
            {
               if ( context.isSpaRequest( ) )
               {
                  enableJsOutput();
               }
            }
         }
      }

      public override string GetPgmname( )
      {
         return "WWPBaseObjects.WWP_MasterPageNotifications" ;
      }

      public override string GetPgmdesc( )
      {
         return "Master Page Notifications" ;
      }

      protected void WB3T0( )
      {
         if ( context.isAjaxRequest( ) )
         {
            disableOutput();
         }
         if ( ! wbLoad )
         {
            if ( StringUtil.Len( sPrefix) == 0 )
            {
               RenderHtmlHeaders( ) ;
            }
            RenderHtmlOpenForm( ) ;
            if ( StringUtil.Len( sPrefix) != 0 )
            {
               GxWebStd.gx_hidden_field( context, sPrefix+"_CMPPGM", "wwpbaseobjects.wwp_masterpagenotifications.aspx");
            }
            GxWebStd.gx_msg_list( context, "", context.GX_msglist.DisplayMode, "", "", sPrefix, "false");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "Section", "left", "top", " "+"data-gx-base-lib=\"bootstrapv3\""+" "+"data-abstract-form"+" ", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divLayoutmaintable_Internalname, 1, 0, "px", 0, "px", "Table", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divUnnamedtable1_Internalname, 1, 0, "px", 0, "px", "", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divNotificationcontent_Internalname, 1, 0, "px", 0, "px", "NotificationContent", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 CellMarginTop CellMarginBottom15", "left", "top", "", "", "div");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblNotificationtitle_Internalname, lblNotificationtitle_Caption, "", "", lblNotificationtitle_Jsonclick, "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "NotificationTitle", 0, "", 1, 1, 0, 0, "HLP_WWPBaseObjects\\WWP_MasterPageNotifications.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
            /*  Grid Control  */
            GridsdtnotificationsdatasContainer.SetIsFreestyle(true);
            GridsdtnotificationsdatasContainer.SetWrapped(nGXWrapped);
            if ( GridsdtnotificationsdatasContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<div id=\""+sPrefix+"GridsdtnotificationsdatasContainer"+"DivS\" data-gxgridid=\"15\">") ;
               sStyleString = "";
               if ( subGridsdtnotificationsdatas_Visible == 0 )
               {
                  sStyleString += "display:none;";
               }
               GxWebStd.gx_table_start( context, subGridsdtnotificationsdatas_Internalname, subGridsdtnotificationsdatas_Internalname, "", "FreeStyleGrid", 0, "", "", 1, 2, sStyleString, "", "", 0);
               GridsdtnotificationsdatasContainer.AddObjectProperty("GridName", "Gridsdtnotificationsdatas");
            }
            else
            {
               GridsdtnotificationsdatasContainer.AddObjectProperty("GridName", "Gridsdtnotificationsdatas");
               GridsdtnotificationsdatasContainer.AddObjectProperty("Header", subGridsdtnotificationsdatas_Header);
               GridsdtnotificationsdatasContainer.AddObjectProperty("Visible", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGridsdtnotificationsdatas_Visible), 5, 0, ".", "")));
               GridsdtnotificationsdatasContainer.AddObjectProperty("Class", StringUtil.RTrim( "FreeStyleGrid"));
               GridsdtnotificationsdatasContainer.AddObjectProperty("Class", "FreeStyleGrid");
               GridsdtnotificationsdatasContainer.AddObjectProperty("Cellpadding", StringUtil.LTrim( StringUtil.NToC( (decimal)(1), 4, 0, ".", "")));
               GridsdtnotificationsdatasContainer.AddObjectProperty("Cellspacing", StringUtil.LTrim( StringUtil.NToC( (decimal)(2), 4, 0, ".", "")));
               GridsdtnotificationsdatasContainer.AddObjectProperty("Backcolorstyle", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGridsdtnotificationsdatas_Backcolorstyle), 1, 0, ".", "")));
               GridsdtnotificationsdatasContainer.AddObjectProperty("Visible", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGridsdtnotificationsdatas_Visible), 5, 0, ".", "")));
               GridsdtnotificationsdatasContainer.AddObjectProperty("CmpContext", sPrefix);
               GridsdtnotificationsdatasContainer.AddObjectProperty("InMasterPage", "false");
               GridsdtnotificationsdatasColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
               GridsdtnotificationsdatasContainer.AddColumnProperties(GridsdtnotificationsdatasColumn);
               GridsdtnotificationsdatasColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
               GridsdtnotificationsdatasContainer.AddColumnProperties(GridsdtnotificationsdatasColumn);
               GridsdtnotificationsdatasColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
               GridsdtnotificationsdatasContainer.AddColumnProperties(GridsdtnotificationsdatasColumn);
               GridsdtnotificationsdatasColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
               GridsdtnotificationsdatasContainer.AddColumnProperties(GridsdtnotificationsdatasColumn);
               GridsdtnotificationsdatasColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
               GridsdtnotificationsdatasContainer.AddColumnProperties(GridsdtnotificationsdatasColumn);
               GridsdtnotificationsdatasColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
               GridsdtnotificationsdatasColumn.AddObjectProperty("Value", lblNotificationitemicon_Caption);
               GridsdtnotificationsdatasContainer.AddColumnProperties(GridsdtnotificationsdatasColumn);
               GridsdtnotificationsdatasColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
               GridsdtnotificationsdatasContainer.AddColumnProperties(GridsdtnotificationsdatasColumn);
               GridsdtnotificationsdatasColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
               GridsdtnotificationsdatasContainer.AddColumnProperties(GridsdtnotificationsdatasColumn);
               GridsdtnotificationsdatasColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
               GridsdtnotificationsdatasContainer.AddColumnProperties(GridsdtnotificationsdatasColumn);
               GridsdtnotificationsdatasColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
               GridsdtnotificationsdatasContainer.AddColumnProperties(GridsdtnotificationsdatasColumn);
               GridsdtnotificationsdatasColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
               GridsdtnotificationsdatasContainer.AddColumnProperties(GridsdtnotificationsdatasColumn);
               GridsdtnotificationsdatasColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
               GridsdtnotificationsdatasColumn.AddObjectProperty("Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtavSdtnotificationsdata__notificationtitle_Enabled), 5, 0, ".", "")));
               GridsdtnotificationsdatasContainer.AddColumnProperties(GridsdtnotificationsdatasColumn);
               GridsdtnotificationsdatasColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
               GridsdtnotificationsdatasContainer.AddColumnProperties(GridsdtnotificationsdatasColumn);
               GridsdtnotificationsdatasColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
               GridsdtnotificationsdatasContainer.AddColumnProperties(GridsdtnotificationsdatasColumn);
               GridsdtnotificationsdatasColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
               GridsdtnotificationsdatasContainer.AddColumnProperties(GridsdtnotificationsdatasColumn);
               GridsdtnotificationsdatasColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
               GridsdtnotificationsdatasColumn.AddObjectProperty("Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtavSdtnotificationsdata__notificationdescription_Enabled), 5, 0, ".", "")));
               GridsdtnotificationsdatasContainer.AddColumnProperties(GridsdtnotificationsdatasColumn);
               GridsdtnotificationsdatasColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
               GridsdtnotificationsdatasContainer.AddColumnProperties(GridsdtnotificationsdatasColumn);
               GridsdtnotificationsdatasColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
               GridsdtnotificationsdatasContainer.AddColumnProperties(GridsdtnotificationsdatasColumn);
               GridsdtnotificationsdatasColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
               GridsdtnotificationsdatasContainer.AddColumnProperties(GridsdtnotificationsdatasColumn);
               GridsdtnotificationsdatasColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
               GridsdtnotificationsdatasColumn.AddObjectProperty("Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtavSdtnotificationsdata__notificationdatetime_Enabled), 5, 0, ".", "")));
               GridsdtnotificationsdatasContainer.AddColumnProperties(GridsdtnotificationsdatasColumn);
               GridsdtnotificationsdatasColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
               GridsdtnotificationsdatasContainer.AddColumnProperties(GridsdtnotificationsdatasColumn);
               GridsdtnotificationsdatasColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
               GridsdtnotificationsdatasContainer.AddColumnProperties(GridsdtnotificationsdatasColumn);
               GridsdtnotificationsdatasColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
               GridsdtnotificationsdatasContainer.AddColumnProperties(GridsdtnotificationsdatasColumn);
               GridsdtnotificationsdatasColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
               GridsdtnotificationsdatasContainer.AddColumnProperties(GridsdtnotificationsdatasColumn);
               GridsdtnotificationsdatasColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
               GridsdtnotificationsdatasContainer.AddColumnProperties(GridsdtnotificationsdatasColumn);
               GridsdtnotificationsdatasColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
               GridsdtnotificationsdatasContainer.AddColumnProperties(GridsdtnotificationsdatasColumn);
               GridsdtnotificationsdatasColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
               GridsdtnotificationsdatasColumn.AddObjectProperty("Visible", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtavSdtnotificationsdata__notificationid_Visible), 5, 0, ".", "")));
               GridsdtnotificationsdatasContainer.AddColumnProperties(GridsdtnotificationsdatasColumn);
               GridsdtnotificationsdatasContainer.AddObjectProperty("Selectedindex", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGridsdtnotificationsdatas_Selectedindex), 4, 0, ".", "")));
               GridsdtnotificationsdatasContainer.AddObjectProperty("Allowselection", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGridsdtnotificationsdatas_Allowselection), 1, 0, ".", "")));
               GridsdtnotificationsdatasContainer.AddObjectProperty("Selectioncolor", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGridsdtnotificationsdatas_Selectioncolor), 9, 0, ".", "")));
               GridsdtnotificationsdatasContainer.AddObjectProperty("Allowhover", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGridsdtnotificationsdatas_Allowhovering), 1, 0, ".", "")));
               GridsdtnotificationsdatasContainer.AddObjectProperty("Hovercolor", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGridsdtnotificationsdatas_Hoveringcolor), 9, 0, ".", "")));
               GridsdtnotificationsdatasContainer.AddObjectProperty("Allowcollapsing", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGridsdtnotificationsdatas_Allowcollapsing), 1, 0, ".", "")));
               GridsdtnotificationsdatasContainer.AddObjectProperty("Collapsed", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGridsdtnotificationsdatas_Collapsed), 1, 0, ".", "")));
            }
         }
         if ( wbEnd == 15 )
         {
            wbEnd = 0;
            nRC_GXsfl_15 = (int)(nGXsfl_15_idx-1);
            if ( GridsdtnotificationsdatasContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "</table>") ;
               context.WriteHtmlText( "</div>") ;
            }
            else
            {
               AV11GXV1 = nGXsfl_15_idx;
               if ( subGridsdtnotificationsdatas_Visible != 0 )
               {
                  sStyleString = "";
               }
               else
               {
                  sStyleString = " style=\"display:none;\"";
               }
               context.WriteHtmlText( "<div id=\""+sPrefix+"GridsdtnotificationsdatasContainer"+"Div\" "+sStyleString+">"+"</div>") ;
               context.httpAjaxContext.ajax_rsp_assign_grid(sPrefix+"_"+"Gridsdtnotificationsdatas", GridsdtnotificationsdatasContainer);
               if ( ! isAjaxCallMode( ) && ! context.isSpaRequest( ) )
               {
                  GxWebStd.gx_hidden_field( context, sPrefix+"GridsdtnotificationsdatasContainerData", GridsdtnotificationsdatasContainer.ToJavascriptSource());
               }
               if ( context.isAjaxRequest( ) || context.isSpaRequest( ) )
               {
                  GxWebStd.gx_hidden_field( context, sPrefix+"GridsdtnotificationsdatasContainerData"+"V", GridsdtnotificationsdatasContainer.GridValuesHidden());
               }
               else
               {
                  context.WriteHtmlText( "<input type=\"hidden\" "+"name=\""+sPrefix+"GridsdtnotificationsdatasContainerData"+"V"+"\" value='"+GridsdtnotificationsdatasContainer.GridValuesHidden()+"'/>") ;
               }
            }
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 45,'" + sPrefix + "',false,'',0)\"";
            ClassString = "ButtonNotificationCheckAll";
            StyleString = "";
            GxWebStd.gx_button_ctrl( context, bttBtncheckallnotif_Internalname, "gx.evt.setGridEvt("+StringUtil.Str( (decimal)(15), 2, 0)+","+"null"+");", "Verificar todas las notificaciones >", bttBtncheckallnotif_Jsonclick, 5, "Verificar todas las notificaciones >", "", StyleString, ClassString, 1, 1, "standard", "'"+sPrefix+"'"+",false,"+"'"+sPrefix+"E\\'DOCHECKALLNOTIF\\'."+"'", TempTags, "", context.GetButtonType( ), "HLP_WWPBaseObjects\\WWP_MasterPageNotifications.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
         }
         if ( wbEnd == 15 )
         {
            wbEnd = 0;
            if ( isFullAjaxMode( ) )
            {
               if ( GridsdtnotificationsdatasContainer.GetWrapped() == 1 )
               {
                  context.WriteHtmlText( "</table>") ;
                  context.WriteHtmlText( "</div>") ;
               }
               else
               {
                  AV11GXV1 = nGXsfl_15_idx;
                  if ( subGridsdtnotificationsdatas_Visible != 0 )
                  {
                     sStyleString = "";
                  }
                  else
                  {
                     sStyleString = " style=\"display:none;\"";
                  }
                  context.WriteHtmlText( "<div id=\""+sPrefix+"GridsdtnotificationsdatasContainer"+"Div\" "+sStyleString+">"+"</div>") ;
                  context.httpAjaxContext.ajax_rsp_assign_grid(sPrefix+"_"+"Gridsdtnotificationsdatas", GridsdtnotificationsdatasContainer);
                  if ( ! isAjaxCallMode( ) && ! context.isSpaRequest( ) )
                  {
                     GxWebStd.gx_hidden_field( context, sPrefix+"GridsdtnotificationsdatasContainerData", GridsdtnotificationsdatasContainer.ToJavascriptSource());
                  }
                  if ( context.isAjaxRequest( ) || context.isSpaRequest( ) )
                  {
                     GxWebStd.gx_hidden_field( context, sPrefix+"GridsdtnotificationsdatasContainerData"+"V", GridsdtnotificationsdatasContainer.GridValuesHidden());
                  }
                  else
                  {
                     context.WriteHtmlText( "<input type=\"hidden\" "+"name=\""+sPrefix+"GridsdtnotificationsdatasContainerData"+"V"+"\" value='"+GridsdtnotificationsdatasContainer.GridValuesHidden()+"'/>") ;
                  }
               }
            }
         }
         wbLoad = true;
      }

      protected void START3T2( )
      {
         wbLoad = false;
         wbEnd = 0;
         wbStart = 0;
         if ( StringUtil.Len( sPrefix) != 0 )
         {
            GXKey = Crypto.GetSiteKey( );
         }
         if ( StringUtil.Len( sPrefix) == 0 )
         {
            if ( ! context.isSpaRequest( ) )
            {
               if ( context.ExposeMetadata( ) )
               {
                  Form.Meta.addItem("generator", "GeneXus .NET 17_0_9-159740", 0) ;
               }
               Form.Meta.addItem("description", "Master Page Notifications", 0) ;
            }
            context.wjLoc = "";
            context.nUserReturn = 0;
            context.wbHandled = 0;
            if ( StringUtil.Len( sPrefix) == 0 )
            {
               sXEvt = cgiGet( "_EventName");
               if ( ! GetJustCreated( ) && ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 ) )
               {
               }
            }
         }
         wbErr = false;
         if ( ( StringUtil.Len( sPrefix) == 0 ) || ( nDraw == 1 ) )
         {
            if ( nDoneStart == 0 )
            {
               STRUP3T0( ) ;
            }
         }
      }

      protected void WS3T2( )
      {
         START3T2( ) ;
         EVT3T2( ) ;
      }

      protected void EVT3T2( )
      {
         sXEvt = cgiGet( "_EventName");
         if ( ( ( ( StringUtil.Len( sPrefix) == 0 ) ) || ( StringUtil.StringSearch( sXEvt, sPrefix, 1) > 0 ) ) && ! GetJustCreated( ) && ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 ) )
         {
            if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) && ! wbErr )
            {
               /* Read Web Panel buttons. */
               if ( context.wbHandled == 0 )
               {
                  if ( StringUtil.Len( sPrefix) == 0 )
                  {
                     sEvt = cgiGet( "_EventName");
                     EvtGridId = cgiGet( "_EventGridId");
                     EvtRowId = cgiGet( "_EventRowId");
                  }
                  if ( StringUtil.Len( sEvt) > 0 )
                  {
                     sEvtType = StringUtil.Left( sEvt, 1);
                     sEvt = StringUtil.Right( sEvt, (short)(StringUtil.Len( sEvt)-1));
                     if ( StringUtil.StrCmp(sEvtType, "E") == 0 )
                     {
                        sEvtType = StringUtil.Right( sEvt, 1);
                        if ( StringUtil.StrCmp(sEvtType, ".") == 0 )
                        {
                           sEvt = StringUtil.Left( sEvt, (short)(StringUtil.Len( sEvt)-1));
                           if ( StringUtil.StrCmp(sEvt, "RFR") == 0 )
                           {
                              if ( ( StringUtil.Len( sPrefix) != 0 ) && ( nDoneStart == 0 ) )
                              {
                                 STRUP3T0( ) ;
                              }
                              if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
                              {
                                 context.wbHandled = 1;
                                 if ( ! wbErr )
                                 {
                                    dynload_actions( ) ;
                                 }
                              }
                           }
                           else if ( StringUtil.StrCmp(sEvt, "'DOCHECKALLNOTIF'") == 0 )
                           {
                              if ( ( StringUtil.Len( sPrefix) != 0 ) && ( nDoneStart == 0 ) )
                              {
                                 STRUP3T0( ) ;
                              }
                              if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
                              {
                                 context.wbHandled = 1;
                                 if ( ! wbErr )
                                 {
                                    dynload_actions( ) ;
                                    /* Execute user event: 'DoCheckAllNotif' */
                                    E113T2 ();
                                 }
                              }
                           }
                           else if ( StringUtil.StrCmp(sEvt, "NOTIFICATIONITEM.CLICK") == 0 )
                           {
                              if ( ( StringUtil.Len( sPrefix) != 0 ) && ( nDoneStart == 0 ) )
                              {
                                 STRUP3T0( ) ;
                              }
                              if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
                              {
                                 context.wbHandled = 1;
                                 if ( ! wbErr )
                                 {
                                    dynload_actions( ) ;
                                    E123T2 ();
                                 }
                              }
                           }
                           else if ( StringUtil.StrCmp(sEvt, "LSCR") == 0 )
                           {
                              if ( ( StringUtil.Len( sPrefix) != 0 ) && ( nDoneStart == 0 ) )
                              {
                                 STRUP3T0( ) ;
                              }
                              if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
                              {
                                 context.wbHandled = 1;
                                 if ( ! wbErr )
                                 {
                                    dynload_actions( ) ;
                                 }
                              }
                              dynload_actions( ) ;
                           }
                        }
                        else
                        {
                           sEvtType = StringUtil.Right( sEvt, 4);
                           sEvt = StringUtil.Left( sEvt, (short)(StringUtil.Len( sEvt)-4));
                           if ( ( StringUtil.StrCmp(StringUtil.Left( sEvt, 5), "START") == 0 ) || ( StringUtil.StrCmp(StringUtil.Left( sEvt, 30), "GRIDSDTNOTIFICATIONSDATAS.LOAD") == 0 ) || ( StringUtil.StrCmp(StringUtil.Left( sEvt, 7), "REFRESH") == 0 ) || ( StringUtil.StrCmp(StringUtil.Left( sEvt, 22), "NOTIFICATIONITEM.CLICK") == 0 ) || ( StringUtil.StrCmp(StringUtil.Left( sEvt, 5), "ENTER") == 0 ) || ( StringUtil.StrCmp(StringUtil.Left( sEvt, 6), "CANCEL") == 0 ) )
                           {
                              if ( ( StringUtil.Len( sPrefix) != 0 ) && ( nDoneStart == 0 ) )
                              {
                                 STRUP3T0( ) ;
                              }
                              nGXsfl_15_idx = (int)(NumberUtil.Val( sEvtType, "."));
                              sGXsfl_15_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_15_idx), 4, 0), 4, "0");
                              SubsflControlProps_152( ) ;
                              AV11GXV1 = nGXsfl_15_idx;
                              if ( ( AV6SDTNotificationsData.Count >= AV11GXV1 ) && ( AV11GXV1 > 0 ) )
                              {
                                 AV6SDTNotificationsData.CurrentItem = ((GeneXus.Programs.wwpbaseobjects.SdtWWP_SDTNotificationsData_WWP_SDTNotificationsDataItem)AV6SDTNotificationsData.Item(AV11GXV1));
                              }
                              sEvtType = StringUtil.Right( sEvt, 1);
                              if ( StringUtil.StrCmp(sEvtType, ".") == 0 )
                              {
                                 sEvt = StringUtil.Left( sEvt, (short)(StringUtil.Len( sEvt)-1));
                                 if ( StringUtil.StrCmp(sEvt, "START") == 0 )
                                 {
                                    if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
                                    {
                                       context.wbHandled = 1;
                                       if ( ! wbErr )
                                       {
                                          dynload_actions( ) ;
                                          /* Execute user event: Start */
                                          E133T2 ();
                                       }
                                    }
                                 }
                                 else if ( StringUtil.StrCmp(sEvt, "GRIDSDTNOTIFICATIONSDATAS.LOAD") == 0 )
                                 {
                                    if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
                                    {
                                       context.wbHandled = 1;
                                       if ( ! wbErr )
                                       {
                                          dynload_actions( ) ;
                                          E143T2 ();
                                       }
                                    }
                                 }
                                 else if ( StringUtil.StrCmp(sEvt, "REFRESH") == 0 )
                                 {
                                    if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
                                    {
                                       context.wbHandled = 1;
                                       if ( ! wbErr )
                                       {
                                          dynload_actions( ) ;
                                          /* Execute user event: Refresh */
                                          E153T2 ();
                                       }
                                    }
                                 }
                                 else if ( StringUtil.StrCmp(sEvt, "NOTIFICATIONITEM.CLICK") == 0 )
                                 {
                                    if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
                                    {
                                       context.wbHandled = 1;
                                       if ( ! wbErr )
                                       {
                                          dynload_actions( ) ;
                                          E123T2 ();
                                       }
                                    }
                                 }
                                 else if ( StringUtil.StrCmp(sEvt, "ENTER") == 0 )
                                 {
                                    if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
                                    {
                                       context.wbHandled = 1;
                                       if ( ! wbErr )
                                       {
                                          if ( ! wbErr )
                                          {
                                             Rfr0gs = false;
                                             if ( ! Rfr0gs )
                                             {
                                             }
                                             dynload_actions( ) ;
                                          }
                                       }
                                    }
                                    /* No code required for Cancel button. It is implemented as the Reset button. */
                                 }
                                 else if ( StringUtil.StrCmp(sEvt, "LSCR") == 0 )
                                 {
                                    if ( ( StringUtil.Len( sPrefix) != 0 ) && ( nDoneStart == 0 ) )
                                    {
                                       STRUP3T0( ) ;
                                    }
                                    if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
                                    {
                                       context.wbHandled = 1;
                                       if ( ! wbErr )
                                       {
                                          dynload_actions( ) ;
                                       }
                                    }
                                 }
                              }
                              else
                              {
                              }
                           }
                        }
                     }
                     context.wbHandled = 1;
                  }
               }
            }
         }
      }

      protected void WE3T2( )
      {
         if ( ! GxWebStd.gx_redirect( context) )
         {
            Rfr0gs = true;
            Refresh( ) ;
            if ( ! GxWebStd.gx_redirect( context) )
            {
               RenderHtmlCloseForm3T2( ) ;
            }
         }
      }

      protected void PA3T2( )
      {
         if ( nDonePA == 0 )
         {
            if ( StringUtil.Len( sPrefix) != 0 )
            {
               initialize_properties( ) ;
            }
            GXKey = Crypto.GetSiteKey( );
            toggleJsOutput = isJsOutputEnabled( );
            if ( StringUtil.Len( sPrefix) == 0 )
            {
               if ( context.isSpaRequest( ) )
               {
                  disableJsOutput();
               }
            }
            init_web_controls( ) ;
            if ( StringUtil.Len( sPrefix) == 0 )
            {
               if ( toggleJsOutput )
               {
                  if ( context.isSpaRequest( ) )
                  {
                     enableJsOutput();
                  }
               }
            }
            if ( ! context.isAjaxRequest( ) )
            {
            }
            nDonePA = 1;
         }
      }

      protected void dynload_actions( )
      {
         /* End function dynload_actions */
      }

      protected void gxnrGridsdtnotificationsdatas_newrow( )
      {
         GxWebStd.set_html_headers( context, 0, "", "");
         SubsflControlProps_152( ) ;
         while ( nGXsfl_15_idx <= nRC_GXsfl_15 )
         {
            sendrow_152( ) ;
            nGXsfl_15_idx = ((subGridsdtnotificationsdatas_Islastpage==1)&&(nGXsfl_15_idx+1>subGridsdtnotificationsdatas_fnc_Recordsperpage( )) ? 1 : nGXsfl_15_idx+1);
            sGXsfl_15_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_15_idx), 4, 0), 4, "0");
            SubsflControlProps_152( ) ;
         }
         AddString( context.httpAjaxContext.getJSONContainerResponse( GridsdtnotificationsdatasContainer)) ;
         /* End function gxnrGridsdtnotificationsdatas_newrow */
      }

      protected void gxgrGridsdtnotificationsdatas_refresh( GXBaseCollection<GeneXus.Programs.wwpbaseobjects.SdtWWP_SDTNotificationsData_WWP_SDTNotificationsDataItem> AV6SDTNotificationsData ,
                                                            string sPrefix )
      {
         initialize_formulas( ) ;
         GxWebStd.set_html_headers( context, 0, "", "");
         /* Execute user event: Refresh */
         E153T2 ();
         GRIDSDTNOTIFICATIONSDATAS_nCurrentRecord = 0;
         RF3T2( ) ;
         GXKey = Crypto.GetSiteKey( );
         send_integrity_footer_hashes( ) ;
         GXKey = Crypto.GetSiteKey( );
         /* End function gxgrGridsdtnotificationsdatas_refresh */
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
         RF3T2( ) ;
         if ( isFullAjaxMode( ) )
         {
            send_integrity_footer_hashes( ) ;
         }
      }

      protected void initialize_formulas( )
      {
         /* GeneXus formulas. */
         context.Gx_err = 0;
         edtavSdtnotificationsdata__notificationtitle_Enabled = 0;
         AssignProp(sPrefix, false, edtavSdtnotificationsdata__notificationtitle_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavSdtnotificationsdata__notificationtitle_Enabled), 5, 0), !bGXsfl_15_Refreshing);
         edtavSdtnotificationsdata__notificationdescription_Enabled = 0;
         AssignProp(sPrefix, false, edtavSdtnotificationsdata__notificationdescription_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavSdtnotificationsdata__notificationdescription_Enabled), 5, 0), !bGXsfl_15_Refreshing);
         edtavSdtnotificationsdata__notificationdatetime_Enabled = 0;
         AssignProp(sPrefix, false, edtavSdtnotificationsdata__notificationdatetime_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavSdtnotificationsdata__notificationdatetime_Enabled), 5, 0), !bGXsfl_15_Refreshing);
      }

      protected void RF3T2( )
      {
         initialize_formulas( ) ;
         clear_multi_value_controls( ) ;
         if ( isAjaxCallMode( ) )
         {
            GridsdtnotificationsdatasContainer.ClearRows();
         }
         wbStart = 15;
         /* Execute user event: Refresh */
         E153T2 ();
         nGXsfl_15_idx = 1;
         sGXsfl_15_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_15_idx), 4, 0), 4, "0");
         SubsflControlProps_152( ) ;
         bGXsfl_15_Refreshing = true;
         GridsdtnotificationsdatasContainer.AddObjectProperty("GridName", "Gridsdtnotificationsdatas");
         GridsdtnotificationsdatasContainer.AddObjectProperty("CmpContext", sPrefix);
         GridsdtnotificationsdatasContainer.AddObjectProperty("InMasterPage", "false");
         GridsdtnotificationsdatasContainer.AddObjectProperty("Visible", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGridsdtnotificationsdatas_Visible), 5, 0, ".", "")));
         GridsdtnotificationsdatasContainer.AddObjectProperty("Class", StringUtil.RTrim( "FreeStyleGrid"));
         GridsdtnotificationsdatasContainer.AddObjectProperty("Class", "FreeStyleGrid");
         GridsdtnotificationsdatasContainer.AddObjectProperty("Cellpadding", StringUtil.LTrim( StringUtil.NToC( (decimal)(1), 4, 0, ".", "")));
         GridsdtnotificationsdatasContainer.AddObjectProperty("Cellspacing", StringUtil.LTrim( StringUtil.NToC( (decimal)(2), 4, 0, ".", "")));
         GridsdtnotificationsdatasContainer.AddObjectProperty("Backcolorstyle", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGridsdtnotificationsdatas_Backcolorstyle), 1, 0, ".", "")));
         GridsdtnotificationsdatasContainer.AddObjectProperty("Visible", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGridsdtnotificationsdatas_Visible), 5, 0, ".", "")));
         GridsdtnotificationsdatasContainer.PageSize = subGridsdtnotificationsdatas_fnc_Recordsperpage( );
         gxdyncontrolsrefreshing = true;
         fix_multi_value_controls( ) ;
         gxdyncontrolsrefreshing = false;
         if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
         {
            SubsflControlProps_152( ) ;
            E143T2 ();
            wbEnd = 15;
            WB3T0( ) ;
         }
         bGXsfl_15_Refreshing = true;
      }

      protected void send_integrity_lvl_hashes3T2( )
      {
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri(sPrefix, false, sPrefix+"vSDTNOTIFICATIONSDATA", AV6SDTNotificationsData);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt(sPrefix+"vSDTNOTIFICATIONSDATA", AV6SDTNotificationsData);
         }
         GxWebStd.gx_hidden_field( context, sPrefix+"gxhash_vSDTNOTIFICATIONSDATA", GetSecureSignedToken( sPrefix, AV6SDTNotificationsData, context));
      }

      protected int subGridsdtnotificationsdatas_fnc_Pagecount( )
      {
         return (int)(-1) ;
      }

      protected int subGridsdtnotificationsdatas_fnc_Recordcount( )
      {
         return (int)(-1) ;
      }

      protected int subGridsdtnotificationsdatas_fnc_Recordsperpage( )
      {
         return (int)(-1) ;
      }

      protected int subGridsdtnotificationsdatas_fnc_Currentpage( )
      {
         return (int)(-1) ;
      }

      protected void before_start_formulas( )
      {
         context.Gx_err = 0;
         edtavSdtnotificationsdata__notificationtitle_Enabled = 0;
         AssignProp(sPrefix, false, edtavSdtnotificationsdata__notificationtitle_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavSdtnotificationsdata__notificationtitle_Enabled), 5, 0), !bGXsfl_15_Refreshing);
         edtavSdtnotificationsdata__notificationdescription_Enabled = 0;
         AssignProp(sPrefix, false, edtavSdtnotificationsdata__notificationdescription_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavSdtnotificationsdata__notificationdescription_Enabled), 5, 0), !bGXsfl_15_Refreshing);
         edtavSdtnotificationsdata__notificationdatetime_Enabled = 0;
         AssignProp(sPrefix, false, edtavSdtnotificationsdata__notificationdatetime_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavSdtnotificationsdata__notificationdatetime_Enabled), 5, 0), !bGXsfl_15_Refreshing);
         fix_multi_value_controls( ) ;
      }

      protected void STRUP3T0( )
      {
         /* Before Start, stand alone formulas. */
         before_start_formulas( ) ;
         /* Execute Start event if defined. */
         context.wbGlbDoneStart = 0;
         /* Execute user event: Start */
         E133T2 ();
         context.wbGlbDoneStart = 1;
         nDoneStart = 1;
         /* After Start, stand alone formulas. */
         sXEvt = cgiGet( "_EventName");
         if ( ! GetJustCreated( ) && ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 ) )
         {
            /* Read saved SDTs. */
            ajax_req_read_hidden_sdt(cgiGet( sPrefix+"Sdtnotificationsdata"), AV6SDTNotificationsData);
            /* Read saved values. */
            nRC_GXsfl_15 = (int)(context.localUtil.CToN( cgiGet( sPrefix+"nRC_GXsfl_15"), ".", ","));
            nRC_GXsfl_15 = (int)(context.localUtil.CToN( cgiGet( sPrefix+"nRC_GXsfl_15"), ".", ","));
            nGXsfl_15_fel_idx = 0;
            while ( nGXsfl_15_fel_idx < nRC_GXsfl_15 )
            {
               nGXsfl_15_fel_idx = ((subGridsdtnotificationsdatas_Islastpage==1)&&(nGXsfl_15_fel_idx+1>subGridsdtnotificationsdatas_fnc_Recordsperpage( )) ? 1 : nGXsfl_15_fel_idx+1);
               sGXsfl_15_fel_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_15_fel_idx), 4, 0), 4, "0");
               SubsflControlProps_fel_152( ) ;
               AV11GXV1 = nGXsfl_15_fel_idx;
               if ( ( AV6SDTNotificationsData.Count >= AV11GXV1 ) && ( AV11GXV1 > 0 ) )
               {
                  AV6SDTNotificationsData.CurrentItem = ((GeneXus.Programs.wwpbaseobjects.SdtWWP_SDTNotificationsData_WWP_SDTNotificationsDataItem)AV6SDTNotificationsData.Item(AV11GXV1));
               }
            }
            if ( nGXsfl_15_fel_idx == 0 )
            {
               nGXsfl_15_idx = 1;
               sGXsfl_15_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_15_idx), 4, 0), 4, "0");
               SubsflControlProps_152( ) ;
            }
            nGXsfl_15_fel_idx = 1;
            /* Read variables values. */
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
         E133T2 ();
         if (returnInSub) return;
      }

      protected void E133T2( )
      {
         /* Start Routine */
         returnInSub = false;
         edtavSdtnotificationsdata__notificationid_Visible = 0;
         AssignProp(sPrefix, false, edtavSdtnotificationsdata__notificationid_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavSdtnotificationsdata__notificationid_Visible), 5, 0), !bGXsfl_15_Refreshing);
         GXt_objcol_SdtWWP_SDTNotificationsData_WWP_SDTNotificationsDataItem1 = AV6SDTNotificationsData;
         new GeneXus.Programs.wwpbaseobjects.getnotification(context ).execute( out  GXt_objcol_SdtWWP_SDTNotificationsData_WWP_SDTNotificationsDataItem1) ;
         AV6SDTNotificationsData = GXt_objcol_SdtWWP_SDTNotificationsData_WWP_SDTNotificationsDataItem1;
         gx_BV15 = true;
      }

      private void E143T2( )
      {
         /* Gridsdtnotificationsdatas_Load Routine */
         returnInSub = false;
         AV11GXV1 = 1;
         while ( AV11GXV1 <= AV6SDTNotificationsData.Count )
         {
            AV6SDTNotificationsData.CurrentItem = ((GeneXus.Programs.wwpbaseobjects.SdtWWP_SDTNotificationsData_WWP_SDTNotificationsDataItem)AV6SDTNotificationsData.Item(AV11GXV1));
            lblNotificationitemicon_Caption = StringUtil.Format( "<i class='%1'></i>", ((GeneXus.Programs.wwpbaseobjects.SdtWWP_SDTNotificationsData_WWP_SDTNotificationsDataItem)(AV6SDTNotificationsData.CurrentItem)).gxTpr_Notificationiconclass, "", "", "", "", "", "", "", "");
            /* Load Method */
            if ( wbStart != -1 )
            {
               wbStart = 15;
            }
            sendrow_152( ) ;
            if ( isFullAjaxMode( ) && ! bGXsfl_15_Refreshing )
            {
               DoAjaxLoad(15, GridsdtnotificationsdatasRow);
            }
            AV11GXV1 = (int)(AV11GXV1+1);
         }
         /*  Sending Event outputs  */
      }

      protected void E113T2( )
      {
         /* 'DoCheckAllNotif' Routine */
         returnInSub = false;
         this.executeExternalObjectMethod(sPrefix, false, "WWPActions", "DropDownComponent_Close", new Object[] {(string)bttBtncheckallnotif_Internalname}, false);
         CallWebObject(formatLink("wwpbaseobjects.wwp_notificaciones.aspx") );
         context.wjLocDisableFrm = 1;
         this.executeExternalObjectMethod(sPrefix, false, "GlobalEvents", "Master_RefreshHeader", new Object[] {}, true);
         this.executeExternalObjectMethod(sPrefix, false, "WWPActions", "WCPopup_Close", new Object[] {(string)""}, false);
      }

      protected void E153T2( )
      {
         if ( gx_refresh_fired )
         {
            return  ;
         }
         gx_refresh_fired = true;
         /* Refresh Routine */
         returnInSub = false;
         if ( AV6SDTNotificationsData.Count == 0 )
         {
            lblNotificationtitle_Caption = "No tienes nuevas notificaciones";
            AssignProp(sPrefix, false, lblNotificationtitle_Internalname, "Caption", lblNotificationtitle_Caption, true);
            subGridsdtnotificationsdatas_Visible = 0;
            AssignProp(sPrefix, false, sPrefix+"GridsdtnotificationsdatasContainerDiv", "Visible", StringUtil.LTrimStr( (decimal)(subGridsdtnotificationsdatas_Visible), 5, 0), true);
         }
         else if ( AV6SDTNotificationsData.Count == 1 )
         {
            lblNotificationtitle_Caption = "Tienes 1 nueva notificación";
            AssignProp(sPrefix, false, lblNotificationtitle_Internalname, "Caption", lblNotificationtitle_Caption, true);
            subGridsdtnotificationsdatas_Visible = 1;
            AssignProp(sPrefix, false, sPrefix+"GridsdtnotificationsdatasContainerDiv", "Visible", StringUtil.LTrimStr( (decimal)(subGridsdtnotificationsdatas_Visible), 5, 0), true);
         }
         else
         {
            subGridsdtnotificationsdatas_Visible = 1;
            AssignProp(sPrefix, false, sPrefix+"GridsdtnotificationsdatasContainerDiv", "Visible", StringUtil.LTrimStr( (decimal)(subGridsdtnotificationsdatas_Visible), 5, 0), true);
            lblNotificationtitle_Caption = StringUtil.Format( "Tienes %1 nuevas notificaciones", StringUtil.Trim( StringUtil.Str( (decimal)(AV6SDTNotificationsData.Count), 9, 0)), "", "", "", "", "", "", "", "");
            AssignProp(sPrefix, false, lblNotificationtitle_Internalname, "Caption", lblNotificationtitle_Caption, true);
         }
         /*  Sending Event outputs  */
      }

      protected void E123T2( )
      {
         AV11GXV1 = nGXsfl_15_idx;
         if ( ( AV11GXV1 > 0 ) && ( AV6SDTNotificationsData.Count >= AV11GXV1 ) )
         {
            AV6SDTNotificationsData.CurrentItem = ((GeneXus.Programs.wwpbaseobjects.SdtWWP_SDTNotificationsData_WWP_SDTNotificationsDataItem)AV6SDTNotificationsData.Item(AV11GXV1));
         }
         /* Notificationitem_Click Routine */
         returnInSub = false;
         GXKey = Crypto.GetSiteKey( );
         GXEncryptionTmp = "seguridad.notificaciones.aspx"+UrlEncode(StringUtil.RTrim("UPD")) + "," + UrlEncode(StringUtil.LTrimStr(((GeneXus.Programs.wwpbaseobjects.SdtWWP_SDTNotificationsData_WWP_SDTNotificationsDataItem)(AV6SDTNotificationsData.CurrentItem)).gxTpr_Notificationid,5,0));
         CallWebObject(formatLink("seguridad.notificaciones.aspx") + "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey));
         context.wjLocDisableFrm = 1;
         this.executeExternalObjectMethod(sPrefix, false, "GlobalEvents", "Master_RefreshHeader", new Object[] {}, true);
         this.executeExternalObjectMethod(sPrefix, false, "WWPActions", "WCPopup_Close", new Object[] {(string)""}, false);
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
         PA3T2( ) ;
         WS3T2( ) ;
         WE3T2( ) ;
         this.cleanup();
         context.SetWrapped(false);
         SaveComponentMsgList(sPrefix);
         context.GX_msglist = BackMsgLst;
         return "";
      }

      public void responsestatic( string sGXDynURL )
      {
      }

      public override void componentbind( Object[] obj )
      {
         if ( IsUrlCreated( ) )
         {
            return  ;
         }
      }

      public override void componentrestorestate( string sPPrefix ,
                                                  string sPSFPrefix )
      {
         sPrefix = sPPrefix + sPSFPrefix;
         PA3T2( ) ;
         WCParametersGet( ) ;
      }

      public override void componentprepare( Object[] obj )
      {
         wbLoad = false;
         sCompPrefix = (string)getParm(obj,0);
         sSFPrefix = (string)getParm(obj,1);
         sPrefix = sCompPrefix + sSFPrefix;
         AddComponentObject(sPrefix, "wwpbaseobjects\\wwp_masterpagenotifications", GetJustCreated( ));
         if ( ( nDoneStart == 0 ) && ( nDynComponent == 0 ) )
         {
            INITWEB( ) ;
         }
         else
         {
            init_default_properties( ) ;
            init_web_controls( ) ;
         }
         PA3T2( ) ;
         if ( ! GetJustCreated( ) && ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 ) && ( context.wbGlbDoneStart == 0 ) )
         {
            WCParametersGet( ) ;
         }
         else
         {
         }
      }

      protected void WCParametersGet( )
      {
         /* Read Component Parameters. */
      }

      public override void componentprocess( string sPPrefix ,
                                             string sPSFPrefix ,
                                             string sCompEvt )
      {
         sCompPrefix = sPPrefix;
         sSFPrefix = sPSFPrefix;
         sPrefix = sCompPrefix + sSFPrefix;
         BackMsgLst = context.GX_msglist;
         context.GX_msglist = LclMsgLst;
         INITWEB( ) ;
         nDraw = 0;
         PA3T2( ) ;
         sEvt = sCompEvt;
         WCParametersGet( ) ;
         WS3T2( ) ;
         if ( isFullAjaxMode( ) )
         {
            componentdraw();
         }
         SaveComponentMsgList(sPrefix);
         context.GX_msglist = BackMsgLst;
      }

      public override void componentstart( )
      {
         if ( nDoneStart == 0 )
         {
            WCStart( ) ;
         }
      }

      protected void WCStart( )
      {
         nDraw = 1;
         BackMsgLst = context.GX_msglist;
         context.GX_msglist = LclMsgLst;
         WS3T2( ) ;
         SaveComponentMsgList(sPrefix);
         context.GX_msglist = BackMsgLst;
      }

      protected void WCParametersSet( )
      {
      }

      public override void componentdraw( )
      {
         if ( nDoneStart == 0 )
         {
            WCStart( ) ;
         }
         BackMsgLst = context.GX_msglist;
         context.GX_msglist = LclMsgLst;
         WCParametersSet( ) ;
         WE3T2( ) ;
         SaveComponentMsgList(sPrefix);
         context.GX_msglist = BackMsgLst;
      }

      public override string getstring( string sGXControl )
      {
         string sCtrlName;
         if ( StringUtil.StrCmp(StringUtil.Substring( sGXControl, 1, 1), "&") == 0 )
         {
            sCtrlName = StringUtil.Substring( sGXControl, 2, StringUtil.Len( sGXControl)-1);
         }
         else
         {
            sCtrlName = sGXControl;
         }
         return cgiGet( sPrefix+"v"+StringUtil.Upper( sCtrlName)) ;
      }

      public override void componentjscripts( )
      {
         include_jscripts( ) ;
      }

      public override void componentthemes( )
      {
         define_styles( ) ;
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
            context.AddJavascriptSource(StringUtil.RTrim( ((string)Form.Jscriptsrc.Item(idxLst))), "?20228181027152", true, true);
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
         context.AddJavascriptSource("wwpbaseobjects/wwp_masterpagenotifications.js", "?20228181027152", false, true);
         /* End function include_jscripts */
      }

      protected void SubsflControlProps_152( )
      {
         lblNotificationitemicon_Internalname = sPrefix+"NOTIFICATIONITEMICON_"+sGXsfl_15_idx;
         edtavSdtnotificationsdata__notificationtitle_Internalname = sPrefix+"SDTNOTIFICATIONSDATA__NOTIFICATIONTITLE_"+sGXsfl_15_idx;
         edtavSdtnotificationsdata__notificationdescription_Internalname = sPrefix+"SDTNOTIFICATIONSDATA__NOTIFICATIONDESCRIPTION_"+sGXsfl_15_idx;
         edtavSdtnotificationsdata__notificationdatetime_Internalname = sPrefix+"SDTNOTIFICATIONSDATA__NOTIFICATIONDATETIME_"+sGXsfl_15_idx;
         edtavSdtnotificationsdata__notificationid_Internalname = sPrefix+"SDTNOTIFICATIONSDATA__NOTIFICATIONID_"+sGXsfl_15_idx;
      }

      protected void SubsflControlProps_fel_152( )
      {
         lblNotificationitemicon_Internalname = sPrefix+"NOTIFICATIONITEMICON_"+sGXsfl_15_fel_idx;
         edtavSdtnotificationsdata__notificationtitle_Internalname = sPrefix+"SDTNOTIFICATIONSDATA__NOTIFICATIONTITLE_"+sGXsfl_15_fel_idx;
         edtavSdtnotificationsdata__notificationdescription_Internalname = sPrefix+"SDTNOTIFICATIONSDATA__NOTIFICATIONDESCRIPTION_"+sGXsfl_15_fel_idx;
         edtavSdtnotificationsdata__notificationdatetime_Internalname = sPrefix+"SDTNOTIFICATIONSDATA__NOTIFICATIONDATETIME_"+sGXsfl_15_fel_idx;
         edtavSdtnotificationsdata__notificationid_Internalname = sPrefix+"SDTNOTIFICATIONSDATA__NOTIFICATIONID_"+sGXsfl_15_fel_idx;
      }

      protected void sendrow_152( )
      {
         SubsflControlProps_152( ) ;
         WB3T0( ) ;
         GridsdtnotificationsdatasRow = GXWebRow.GetNew(context,GridsdtnotificationsdatasContainer);
         if ( subGridsdtnotificationsdatas_Backcolorstyle == 0 )
         {
            /* None style subfile background logic. */
            subGridsdtnotificationsdatas_Backstyle = 0;
            if ( StringUtil.StrCmp(subGridsdtnotificationsdatas_Class, "") != 0 )
            {
               subGridsdtnotificationsdatas_Linesclass = subGridsdtnotificationsdatas_Class+"Odd";
            }
         }
         else if ( subGridsdtnotificationsdatas_Backcolorstyle == 1 )
         {
            /* Uniform style subfile background logic. */
            subGridsdtnotificationsdatas_Backstyle = 0;
            subGridsdtnotificationsdatas_Backcolor = subGridsdtnotificationsdatas_Allbackcolor;
            if ( StringUtil.StrCmp(subGridsdtnotificationsdatas_Class, "") != 0 )
            {
               subGridsdtnotificationsdatas_Linesclass = subGridsdtnotificationsdatas_Class+"Uniform";
            }
         }
         else if ( subGridsdtnotificationsdatas_Backcolorstyle == 2 )
         {
            /* Header style subfile background logic. */
            subGridsdtnotificationsdatas_Backstyle = 1;
            if ( StringUtil.StrCmp(subGridsdtnotificationsdatas_Class, "") != 0 )
            {
               subGridsdtnotificationsdatas_Linesclass = subGridsdtnotificationsdatas_Class+"Odd";
            }
            subGridsdtnotificationsdatas_Backcolor = (int)(0xFFFFFF);
         }
         else if ( subGridsdtnotificationsdatas_Backcolorstyle == 3 )
         {
            /* Report style subfile background logic. */
            subGridsdtnotificationsdatas_Backstyle = 1;
            if ( ((int)((nGXsfl_15_idx) % (2))) == 0 )
            {
               subGridsdtnotificationsdatas_Backcolor = (int)(0x0);
               if ( StringUtil.StrCmp(subGridsdtnotificationsdatas_Class, "") != 0 )
               {
                  subGridsdtnotificationsdatas_Linesclass = subGridsdtnotificationsdatas_Class+"Even";
               }
            }
            else
            {
               subGridsdtnotificationsdatas_Backcolor = (int)(0xFFFFFF);
               if ( StringUtil.StrCmp(subGridsdtnotificationsdatas_Class, "") != 0 )
               {
                  subGridsdtnotificationsdatas_Linesclass = subGridsdtnotificationsdatas_Class+"Odd";
               }
            }
         }
         /* Start of Columns property logic. */
         if ( GridsdtnotificationsdatasContainer.GetWrapped() == 1 )
         {
            context.WriteHtmlText( "<tr"+" class=\""+subGridsdtnotificationsdatas_Linesclass+"\" style=\""+""+"\""+" data-gxrow=\""+sGXsfl_15_idx+"\">") ;
         }
         /* Div Control */
         GridsdtnotificationsdatasRow.AddColumnProperties("div_start", -1, isAjaxCallMode( ), new Object[] {(string)divUnnamedtablefsgridsdtnotificationsdatas_Internalname+"_"+sGXsfl_15_idx,(short)1,(short)0,(string)"px",(short)0,(string)"px",(string)"Table",(string)"left",(string)"top",(string)"",(string)"",(string)"div"});
         /* Div Control */
         GridsdtnotificationsdatasRow.AddColumnProperties("div_start", -1, isAjaxCallMode( ), new Object[] {(string)"",(short)1,(short)0,(string)"px",(short)0,(string)"px",(string)"row",(string)"left",(string)"top",(string)"",(string)"",(string)"div"});
         /* Div Control */
         GridsdtnotificationsdatasRow.AddColumnProperties("div_start", -1, isAjaxCallMode( ), new Object[] {(string)"",(short)1,(short)0,(string)"px",(short)0,(string)"px",(string)"col-xs-12",(string)"left",(string)"top",(string)"",(string)"",(string)"div"});
         /* Div Control */
         GridsdtnotificationsdatasRow.AddColumnProperties("div_start", -1, isAjaxCallMode( ), new Object[] {(string)divNotificationitem_Internalname+"_"+sGXsfl_15_idx,(short)1,(short)0,(string)"px",(short)0,(string)"px",(string)"NotificationItemContent",(string)"left",(string)"top",(string)" "+"data-gx-flex"+" ",(string)"",(string)"div"});
         /* Div Control */
         GridsdtnotificationsdatasRow.AddColumnProperties("div_start", -1, isAjaxCallMode( ), new Object[] {(string)"",(short)1,(short)0,(string)"px",(short)0,(string)"px",(string)"",(string)"left",(string)"top",(string)"",(string)"align-self:center;",(string)"div"});
         /* Text block */
         GridsdtnotificationsdatasRow.AddColumnProperties("label", 1, isAjaxCallMode( ), new Object[] {(string)lblNotificationitemicon_Internalname,(string)lblNotificationitemicon_Caption,(string)"",(string)"",(string)lblNotificationitemicon_Jsonclick,(string)"'"+sPrefix+"'"+",false,"+"'"+""+"'",(string)"",(string)"TextBlock",(short)0,(string)"",(short)1,(short)1,(short)0,(short)2});
         GridsdtnotificationsdatasRow.AddColumnProperties("div_end", -1, isAjaxCallMode( ), new Object[] {(string)"left",(string)"top",(string)"div"});
         /* Div Control */
         GridsdtnotificationsdatasRow.AddColumnProperties("div_start", -1, isAjaxCallMode( ), new Object[] {(string)"",(short)1,(short)0,(string)"px",(short)0,(string)"px",(string)"",(string)"left",(string)"top",(string)"",(string)"flex-grow:1;",(string)"div"});
         /* Div Control */
         GridsdtnotificationsdatasRow.AddColumnProperties("div_start", -1, isAjaxCallMode( ), new Object[] {(string)divUnnamedtable2_Internalname+"_"+sGXsfl_15_idx,(short)1,(short)0,(string)"px",(short)0,(string)"px",(string)"NotificationItemRight",(string)"left",(string)"top",(string)"",(string)"",(string)"div"});
         /* Div Control */
         GridsdtnotificationsdatasRow.AddColumnProperties("div_start", -1, isAjaxCallMode( ), new Object[] {(string)"",(short)1,(short)0,(string)"px",(short)0,(string)"px",(string)"row",(string)"left",(string)"top",(string)"",(string)"",(string)"div"});
         /* Div Control */
         GridsdtnotificationsdatasRow.AddColumnProperties("div_start", -1, isAjaxCallMode( ), new Object[] {(string)"",(short)1,(short)0,(string)"px",(short)0,(string)"px",(string)"col-xs-12",(string)"left",(string)"top",(string)"",(string)"",(string)"div"});
         /* Div Control */
         GridsdtnotificationsdatasRow.AddColumnProperties("div_start", -1, isAjaxCallMode( ), new Object[] {(string)"",(short)1,(short)0,(string)"px",(short)0,(string)"px",(string)" gx-attribute",(string)"left",(string)"top",(string)"",(string)"",(string)"div"});
         /* Attribute/Variable Label */
         GridsdtnotificationsdatasRow.AddColumnProperties("html_label", -1, isAjaxCallMode( ), new Object[] {(string)edtavSdtnotificationsdata__notificationtitle_Internalname,(string)"Notification Title",(string)"col-sm-3 NotificationItemTitleLabel",(short)0,(bool)true,(string)""});
         /* Multiple line edit */
         ClassString = "NotificationItemTitle";
         StyleString = "";
         ClassString = "NotificationItemTitle";
         StyleString = "";
         GridsdtnotificationsdatasRow.AddColumnProperties("html_textarea", 1, isAjaxCallMode( ), new Object[] {(string)edtavSdtnotificationsdata__notificationtitle_Internalname,((GeneXus.Programs.wwpbaseobjects.SdtWWP_SDTNotificationsData_WWP_SDTNotificationsDataItem)AV6SDTNotificationsData.Item(AV11GXV1)).gxTpr_Notificationtitle,(string)"",(string)"",(short)0,(short)1,(int)edtavSdtnotificationsdata__notificationtitle_Enabled,(short)0,(short)80,(string)"chr",(short)3,(string)"row",(string)StyleString,(string)ClassString,(string)"",(string)"",(string)"200",(short)-1,(short)0,(string)"",(string)"",(short)-1,(bool)true,(string)"",(string)"'"+sPrefix+"'"+",false,"+"'"+""+"'",(short)0});
         GridsdtnotificationsdatasRow.AddColumnProperties("div_end", -1, isAjaxCallMode( ), new Object[] {(string)"left",(string)"top",(string)"div"});
         GridsdtnotificationsdatasRow.AddColumnProperties("div_end", -1, isAjaxCallMode( ), new Object[] {(string)"left",(string)"top",(string)"div"});
         GridsdtnotificationsdatasRow.AddColumnProperties("div_end", -1, isAjaxCallMode( ), new Object[] {(string)"left",(string)"top",(string)"div"});
         /* Div Control */
         GridsdtnotificationsdatasRow.AddColumnProperties("div_start", -1, isAjaxCallMode( ), new Object[] {(string)"",(short)1,(short)0,(string)"px",(short)0,(string)"px",(string)"row",(string)"left",(string)"top",(string)"",(string)"",(string)"div"});
         /* Div Control */
         GridsdtnotificationsdatasRow.AddColumnProperties("div_start", -1, isAjaxCallMode( ), new Object[] {(string)"",(short)1,(short)0,(string)"px",(short)0,(string)"px",(string)"col-xs-12",(string)"left",(string)"top",(string)"",(string)"",(string)"div"});
         /* Div Control */
         GridsdtnotificationsdatasRow.AddColumnProperties("div_start", -1, isAjaxCallMode( ), new Object[] {(string)"",(short)1,(short)0,(string)"px",(short)0,(string)"px",(string)" gx-attribute",(string)"left",(string)"top",(string)"",(string)"",(string)"div"});
         /* Attribute/Variable Label */
         GridsdtnotificationsdatasRow.AddColumnProperties("html_label", -1, isAjaxCallMode( ), new Object[] {(string)edtavSdtnotificationsdata__notificationdescription_Internalname,(string)"Notification Description",(string)"col-sm-3 NotificationItemDescriptionLabel",(short)0,(bool)true,(string)""});
         /* Multiple line edit */
         ClassString = "NotificationItemDescription";
         StyleString = "";
         ClassString = "NotificationItemDescription";
         StyleString = "";
         GridsdtnotificationsdatasRow.AddColumnProperties("html_textarea", 1, isAjaxCallMode( ), new Object[] {(string)edtavSdtnotificationsdata__notificationdescription_Internalname,((GeneXus.Programs.wwpbaseobjects.SdtWWP_SDTNotificationsData_WWP_SDTNotificationsDataItem)AV6SDTNotificationsData.Item(AV11GXV1)).gxTpr_Notificationdescription,(string)"",(string)"",(short)0,(short)1,(int)edtavSdtnotificationsdata__notificationdescription_Enabled,(short)0,(short)80,(string)"chr",(short)3,(string)"row",(string)StyleString,(string)ClassString,(string)"",(string)"",(string)"200",(short)-1,(short)0,(string)"",(string)"",(short)-1,(bool)true,(string)"",(string)"'"+sPrefix+"'"+",false,"+"'"+""+"'",(short)0});
         GridsdtnotificationsdatasRow.AddColumnProperties("div_end", -1, isAjaxCallMode( ), new Object[] {(string)"left",(string)"top",(string)"div"});
         GridsdtnotificationsdatasRow.AddColumnProperties("div_end", -1, isAjaxCallMode( ), new Object[] {(string)"left",(string)"top",(string)"div"});
         GridsdtnotificationsdatasRow.AddColumnProperties("div_end", -1, isAjaxCallMode( ), new Object[] {(string)"left",(string)"top",(string)"div"});
         /* Div Control */
         GridsdtnotificationsdatasRow.AddColumnProperties("div_start", -1, isAjaxCallMode( ), new Object[] {(string)"",(short)1,(short)0,(string)"px",(short)0,(string)"px",(string)"row",(string)"left",(string)"top",(string)"",(string)"",(string)"div"});
         /* Div Control */
         GridsdtnotificationsdatasRow.AddColumnProperties("div_start", -1, isAjaxCallMode( ), new Object[] {(string)"",(short)1,(short)0,(string)"px",(short)0,(string)"px",(string)"col-xs-12",(string)"left",(string)"top",(string)"",(string)"",(string)"div"});
         /* Div Control */
         GridsdtnotificationsdatasRow.AddColumnProperties("div_start", -1, isAjaxCallMode( ), new Object[] {(string)"",(short)1,(short)0,(string)"px",(short)0,(string)"px",(string)" gx-attribute",(string)"left",(string)"top",(string)"",(string)"",(string)"div"});
         /* Attribute/Variable Label */
         GridsdtnotificationsdatasRow.AddColumnProperties("html_label", -1, isAjaxCallMode( ), new Object[] {(string)edtavSdtnotificationsdata__notificationdatetime_Internalname,(string)"Notification Datetime",(string)"col-sm-3 NotificationItemDatetimeLabel",(short)0,(bool)true,(string)""});
         /* Single line edit */
         ROClassString = "NotificationItemDatetime";
         GridsdtnotificationsdatasRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtavSdtnotificationsdata__notificationdatetime_Internalname,context.localUtil.TToC( ((GeneXus.Programs.wwpbaseobjects.SdtWWP_SDTNotificationsData_WWP_SDTNotificationsDataItem)AV6SDTNotificationsData.Item(AV11GXV1)).gxTpr_Notificationdatetime, 10, 8, 0, 3, "/", ":", " "),context.localUtil.Format( ((GeneXus.Programs.wwpbaseobjects.SdtWWP_SDTNotificationsData_WWP_SDTNotificationsDataItem)AV6SDTNotificationsData.Item(AV11GXV1)).gxTpr_Notificationdatetime, "99/99/99 99:99"),(string)"",(string)"'"+sPrefix+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtavSdtnotificationsdata__notificationdatetime_Jsonclick,(short)0,(string)"NotificationItemDatetime",(string)"",(string)ROClassString,(string)"",(string)"",(short)1,(int)edtavSdtnotificationsdata__notificationdatetime_Enabled,(short)0,(string)"text",(string)"",(short)14,(string)"chr",(short)1,(string)"row",(short)14,(short)0,(short)0,(short)15,(short)1,(short)-1,(short)0,(bool)true,(string)"",(string)"right",(bool)false,(string)""});
         GridsdtnotificationsdatasRow.AddColumnProperties("div_end", -1, isAjaxCallMode( ), new Object[] {(string)"left",(string)"top",(string)"div"});
         GridsdtnotificationsdatasRow.AddColumnProperties("div_end", -1, isAjaxCallMode( ), new Object[] {(string)"left",(string)"top",(string)"div"});
         GridsdtnotificationsdatasRow.AddColumnProperties("div_end", -1, isAjaxCallMode( ), new Object[] {(string)"left",(string)"top",(string)"div"});
         GridsdtnotificationsdatasRow.AddColumnProperties("div_end", -1, isAjaxCallMode( ), new Object[] {(string)"left",(string)"top",(string)"div"});
         GridsdtnotificationsdatasRow.AddColumnProperties("div_end", -1, isAjaxCallMode( ), new Object[] {(string)"left",(string)"top",(string)"div"});
         GridsdtnotificationsdatasRow.AddColumnProperties("div_end", -1, isAjaxCallMode( ), new Object[] {(string)"left",(string)"top",(string)"div"});
         GridsdtnotificationsdatasRow.AddColumnProperties("div_end", -1, isAjaxCallMode( ), new Object[] {(string)"left",(string)"top",(string)"div"});
         GridsdtnotificationsdatasRow.AddColumnProperties("div_end", -1, isAjaxCallMode( ), new Object[] {(string)"left",(string)"top",(string)"div"});
         /* Div Control */
         GridsdtnotificationsdatasRow.AddColumnProperties("div_start", -1, isAjaxCallMode( ), new Object[] {(string)"",(short)1,(short)0,(string)"px",(short)0,(string)"px",(string)"row",(string)"left",(string)"top",(string)"",(string)"",(string)"div"});
         /* Div Control */
         GridsdtnotificationsdatasRow.AddColumnProperties("div_start", -1, isAjaxCallMode( ), new Object[] {(string)"",(short)1,(short)0,(string)"px",(short)0,(string)"px",(string)"col-xs-12 Invisible",(string)"left",(string)"top",(string)"",(string)"",(string)"div"});
         /* Table start */
         GridsdtnotificationsdatasRow.AddColumnProperties("table", -1, isAjaxCallMode( ), new Object[] {(string)tblUnnamedtablecontentfsgridsdtnotificationsdatas_Internalname+"_"+sGXsfl_15_idx,(short)1,(string)"Table",(string)"",(string)"",(string)"",(string)"",(string)"",(string)"",(short)1,(short)2,(string)"",(string)"",(string)"",(string)"px",(string)"px",(string)""});
         GridsdtnotificationsdatasRow.AddColumnProperties("row", -1, isAjaxCallMode( ), new Object[] {(string)"",(string)"",(string)""});
         GridsdtnotificationsdatasRow.AddColumnProperties("cell", -1, isAjaxCallMode( ), new Object[] {(string)"",(string)"",(string)""});
         /* Div Control */
         GridsdtnotificationsdatasRow.AddColumnProperties("div_start", -1, isAjaxCallMode( ), new Object[] {(string)"",(short)1,(short)0,(string)"px",(short)0,(string)"px",(string)" gx-attribute",(string)"left",(string)"top",(string)"",(string)"",(string)"div"});
         /* Attribute/Variable Label */
         GridsdtnotificationsdatasRow.AddColumnProperties("html_label", -1, isAjaxCallMode( ), new Object[] {(string)edtavSdtnotificationsdata__notificationid_Internalname,(string)"Notification Id",(string)"gx-form-item AttributeLabel",(short)0,(bool)true,(string)"width: 25%;"});
         /* Single line edit */
         TempTags = " " + ((edtavSdtnotificationsdata__notificationid_Enabled!=0)&&(edtavSdtnotificationsdata__notificationid_Visible!=0) ? " onfocus=\"gx.evt.onfocus(this, 42,'"+sPrefix+"',false,'"+sGXsfl_15_idx+"',15)\"" : " ");
         ROClassString = "Attribute";
         GridsdtnotificationsdatasRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtavSdtnotificationsdata__notificationid_Internalname,StringUtil.LTrim( StringUtil.NToC( (decimal)(((GeneXus.Programs.wwpbaseobjects.SdtWWP_SDTNotificationsData_WWP_SDTNotificationsDataItem)AV6SDTNotificationsData.Item(AV11GXV1)).gxTpr_Notificationid), 5, 0, ".", "")),StringUtil.LTrim( context.localUtil.Format( (decimal)(((GeneXus.Programs.wwpbaseobjects.SdtWWP_SDTNotificationsData_WWP_SDTNotificationsDataItem)AV6SDTNotificationsData.Item(AV11GXV1)).gxTpr_Notificationid), "ZZZZ9"))," inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onchange(this, event)\" "+((edtavSdtnotificationsdata__notificationid_Enabled!=0)&&(edtavSdtnotificationsdata__notificationid_Visible!=0) ? " onblur=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onblur(this,42);\"" : " "),(string)"'"+sPrefix+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtavSdtnotificationsdata__notificationid_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"",(string)"",(int)edtavSdtnotificationsdata__notificationid_Visible,(short)1,(short)0,(string)"text",(string)"1",(short)5,(string)"chr",(short)1,(string)"row",(short)5,(short)0,(short)0,(short)15,(short)1,(short)-1,(short)0,(bool)true,(string)"",(string)"right",(bool)false,(string)""});
         GridsdtnotificationsdatasRow.AddColumnProperties("div_end", -1, isAjaxCallMode( ), new Object[] {(string)"left",(string)"top",(string)"div"});
         if ( GridsdtnotificationsdatasContainer.GetWrapped() == 1 )
         {
            GridsdtnotificationsdatasContainer.CloseTag("cell");
         }
         if ( GridsdtnotificationsdatasContainer.GetWrapped() == 1 )
         {
            GridsdtnotificationsdatasContainer.CloseTag("row");
         }
         if ( GridsdtnotificationsdatasContainer.GetWrapped() == 1 )
         {
            GridsdtnotificationsdatasContainer.CloseTag("table");
         }
         /* End of table */
         GridsdtnotificationsdatasRow.AddColumnProperties("div_end", -1, isAjaxCallMode( ), new Object[] {(string)"left",(string)"top",(string)"div"});
         GridsdtnotificationsdatasRow.AddColumnProperties("div_end", -1, isAjaxCallMode( ), new Object[] {(string)"left",(string)"top",(string)"div"});
         GridsdtnotificationsdatasRow.AddColumnProperties("div_end", -1, isAjaxCallMode( ), new Object[] {(string)"left",(string)"top",(string)"div"});
         send_integrity_lvl_hashes3T2( ) ;
         /* End of Columns property logic. */
         GridsdtnotificationsdatasContainer.AddRow(GridsdtnotificationsdatasRow);
         nGXsfl_15_idx = ((subGridsdtnotificationsdatas_Islastpage==1)&&(nGXsfl_15_idx+1>subGridsdtnotificationsdatas_fnc_Recordsperpage( )) ? 1 : nGXsfl_15_idx+1);
         sGXsfl_15_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_15_idx), 4, 0), 4, "0");
         SubsflControlProps_152( ) ;
         /* End function sendrow_152 */
      }

      protected void init_web_controls( )
      {
         /* End function init_web_controls */
      }

      protected void init_default_properties( )
      {
         lblNotificationtitle_Internalname = sPrefix+"NOTIFICATIONTITLE";
         lblNotificationitemicon_Internalname = sPrefix+"NOTIFICATIONITEMICON";
         edtavSdtnotificationsdata__notificationtitle_Internalname = sPrefix+"SDTNOTIFICATIONSDATA__NOTIFICATIONTITLE";
         edtavSdtnotificationsdata__notificationdescription_Internalname = sPrefix+"SDTNOTIFICATIONSDATA__NOTIFICATIONDESCRIPTION";
         edtavSdtnotificationsdata__notificationdatetime_Internalname = sPrefix+"SDTNOTIFICATIONSDATA__NOTIFICATIONDATETIME";
         divUnnamedtable2_Internalname = sPrefix+"UNNAMEDTABLE2";
         divNotificationitem_Internalname = sPrefix+"NOTIFICATIONITEM";
         edtavSdtnotificationsdata__notificationid_Internalname = sPrefix+"SDTNOTIFICATIONSDATA__NOTIFICATIONID";
         tblUnnamedtablecontentfsgridsdtnotificationsdatas_Internalname = sPrefix+"UNNAMEDTABLECONTENTFSGRIDSDTNOTIFICATIONSDATAS";
         divUnnamedtablefsgridsdtnotificationsdatas_Internalname = sPrefix+"UNNAMEDTABLEFSGRIDSDTNOTIFICATIONSDATAS";
         divNotificationcontent_Internalname = sPrefix+"NOTIFICATIONCONTENT";
         bttBtncheckallnotif_Internalname = sPrefix+"BTNCHECKALLNOTIF";
         divUnnamedtable1_Internalname = sPrefix+"UNNAMEDTABLE1";
         divLayoutmaintable_Internalname = sPrefix+"LAYOUTMAINTABLE";
         Form.Internalname = sPrefix+"FORM";
         subGridsdtnotificationsdatas_Internalname = sPrefix+"GRIDSDTNOTIFICATIONSDATAS";
      }

      public override void initialize_properties( )
      {
         if ( StringUtil.Len( sPrefix) == 0 )
         {
            context.SetDefaultTheme("WorkWithPlusTheme");
         }
         if ( StringUtil.Len( sPrefix) == 0 )
         {
            if ( context.isSpaRequest( ) )
            {
               disableJsOutput();
            }
         }
         init_default_properties( ) ;
         edtavSdtnotificationsdata__notificationid_Jsonclick = "";
         edtavSdtnotificationsdata__notificationid_Enabled = 1;
         edtavSdtnotificationsdata__notificationdatetime_Jsonclick = "";
         lblNotificationitemicon_Caption = "<i class='fas fa-pencil-alt NotificationFontIconSuccess'></i>";
         subGridsdtnotificationsdatas_Class = "FreeStyleGrid";
         subGridsdtnotificationsdatas_Allowcollapsing = 0;
         edtavSdtnotificationsdata__notificationid_Visible = 1;
         edtavSdtnotificationsdata__notificationdatetime_Enabled = 0;
         edtavSdtnotificationsdata__notificationdescription_Enabled = 0;
         edtavSdtnotificationsdata__notificationtitle_Enabled = 0;
         lblNotificationitemicon_Caption = "<i class='fas fa-pencil-alt NotificationFontIconSuccess'></i>";
         subGridsdtnotificationsdatas_Backcolorstyle = 0;
         subGridsdtnotificationsdatas_Visible = 1;
         lblNotificationtitle_Caption = "You have 5 new notifications";
         edtavSdtnotificationsdata__notificationdatetime_Enabled = -1;
         edtavSdtnotificationsdata__notificationdescription_Enabled = -1;
         edtavSdtnotificationsdata__notificationtitle_Enabled = -1;
         if ( StringUtil.Len( sPrefix) == 0 )
         {
            if ( context.isSpaRequest( ) )
            {
               enableJsOutput();
            }
         }
      }

      public override bool SupportAjaxEvent( )
      {
         return true ;
      }

      public override void InitializeDynEvents( )
      {
         setEventMetadata("REFRESH","{handler:'Refresh',iparms:[{av:'GRIDSDTNOTIFICATIONSDATAS_nFirstRecordOnPage'},{av:'GRIDSDTNOTIFICATIONSDATAS_nEOF'},{av:'sPrefix'},{av:'AV6SDTNotificationsData',fld:'vSDTNOTIFICATIONSDATA',grid:15,pic:'',hsh:true},{av:'nGXsfl_15_idx', ctrl: 'GRID', prop:'GridCurrRow', grid:15},{av:'nRC_GXsfl_15',ctrl:'GRIDSDTNOTIFICATIONSDATAS',prop:'GridRC',grid:15}]");
         setEventMetadata("REFRESH",",oparms:[{av:'lblNotificationtitle_Caption',ctrl:'NOTIFICATIONTITLE',prop:'Caption'},{av:'subGridsdtnotificationsdatas_Visible',ctrl:'GRIDSDTNOTIFICATIONSDATAS',prop:'Visible'}]}");
         setEventMetadata("GRIDSDTNOTIFICATIONSDATAS.LOAD","{handler:'E143T2',iparms:[{av:'AV6SDTNotificationsData',fld:'vSDTNOTIFICATIONSDATA',grid:15,pic:'',hsh:true},{av:'nGXsfl_15_idx', ctrl: 'GRID', prop:'GridCurrRow', grid:15},{av:'GRIDSDTNOTIFICATIONSDATAS_nFirstRecordOnPage'},{av:'nRC_GXsfl_15',ctrl:'GRIDSDTNOTIFICATIONSDATAS',prop:'GridRC',grid:15}]");
         setEventMetadata("GRIDSDTNOTIFICATIONSDATAS.LOAD",",oparms:[{av:'lblNotificationitemicon_Caption',ctrl:'NOTIFICATIONITEMICON',prop:'Caption'}]}");
         setEventMetadata("'DOCHECKALLNOTIF'","{handler:'E113T2',iparms:[]");
         setEventMetadata("'DOCHECKALLNOTIF'",",oparms:[]}");
         setEventMetadata("NOTIFICATIONITEM.CLICK","{handler:'E123T2',iparms:[{av:'AV6SDTNotificationsData',fld:'vSDTNOTIFICATIONSDATA',grid:15,pic:'',hsh:true},{av:'nGXsfl_15_idx', ctrl: 'GRID', prop:'GridCurrRow', grid:15},{av:'GRIDSDTNOTIFICATIONSDATAS_nFirstRecordOnPage'},{av:'nRC_GXsfl_15',ctrl:'GRIDSDTNOTIFICATIONSDATAS',prop:'GridRC',grid:15}]");
         setEventMetadata("NOTIFICATIONITEM.CLICK",",oparms:[]}");
         setEventMetadata("NULL","{handler:'Validv_Gxv5',iparms:[]");
         setEventMetadata("NULL",",oparms:[]}");
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
         gxfirstwebparm = "";
         gxfirstwebparm_bkp = "";
         sPrefix = "";
         AV6SDTNotificationsData = new GXBaseCollection<GeneXus.Programs.wwpbaseobjects.SdtWWP_SDTNotificationsData_WWP_SDTNotificationsDataItem>( context, "WWP_SDTNotificationsDataItem", "SIGERP_ADVANCED");
         sDynURL = "";
         FormProcess = "";
         bodyStyle = "";
         GXKey = "";
         GX_FocusControl = "";
         lblNotificationtitle_Jsonclick = "";
         GridsdtnotificationsdatasContainer = new GXWebGrid( context);
         sStyleString = "";
         subGridsdtnotificationsdatas_Header = "";
         GridsdtnotificationsdatasColumn = new GXWebColumn();
         TempTags = "";
         ClassString = "";
         StyleString = "";
         bttBtncheckallnotif_Jsonclick = "";
         Form = new GXWebForm();
         sXEvt = "";
         sEvt = "";
         EvtGridId = "";
         EvtRowId = "";
         sEvtType = "";
         GXt_objcol_SdtWWP_SDTNotificationsData_WWP_SDTNotificationsDataItem1 = new GXBaseCollection<GeneXus.Programs.wwpbaseobjects.SdtWWP_SDTNotificationsData_WWP_SDTNotificationsDataItem>( context, "WWP_SDTNotificationsDataItem", "SIGERP_ADVANCED");
         GridsdtnotificationsdatasRow = new GXWebRow();
         GXEncryptionTmp = "";
         BackMsgLst = new msglist();
         LclMsgLst = new msglist();
         subGridsdtnotificationsdatas_Linesclass = "";
         lblNotificationitemicon_Jsonclick = "";
         ROClassString = "";
         /* GeneXus formulas. */
         context.Gx_err = 0;
         edtavSdtnotificationsdata__notificationtitle_Enabled = 0;
         edtavSdtnotificationsdata__notificationdescription_Enabled = 0;
         edtavSdtnotificationsdata__notificationdatetime_Enabled = 0;
      }

      private short nGotPars ;
      private short GxWebError ;
      private short nDynComponent ;
      private short initialized ;
      private short wbEnd ;
      private short wbStart ;
      private short subGridsdtnotificationsdatas_Backcolorstyle ;
      private short subGridsdtnotificationsdatas_Allowselection ;
      private short subGridsdtnotificationsdatas_Allowhovering ;
      private short subGridsdtnotificationsdatas_Allowcollapsing ;
      private short subGridsdtnotificationsdatas_Collapsed ;
      private short nDraw ;
      private short nDoneStart ;
      private short nDonePA ;
      private short GRIDSDTNOTIFICATIONSDATAS_nEOF ;
      private short nGXWrapped ;
      private short subGridsdtnotificationsdatas_Backstyle ;
      private int nRC_GXsfl_15 ;
      private int nGXsfl_15_idx=1 ;
      private int edtavSdtnotificationsdata__notificationtitle_Enabled ;
      private int edtavSdtnotificationsdata__notificationdescription_Enabled ;
      private int edtavSdtnotificationsdata__notificationdatetime_Enabled ;
      private int subGridsdtnotificationsdatas_Visible ;
      private int edtavSdtnotificationsdata__notificationid_Visible ;
      private int subGridsdtnotificationsdatas_Selectedindex ;
      private int subGridsdtnotificationsdatas_Selectioncolor ;
      private int subGridsdtnotificationsdatas_Hoveringcolor ;
      private int AV11GXV1 ;
      private int subGridsdtnotificationsdatas_Islastpage ;
      private int nGXsfl_15_fel_idx=1 ;
      private int idxLst ;
      private int subGridsdtnotificationsdatas_Backcolor ;
      private int subGridsdtnotificationsdatas_Allbackcolor ;
      private int edtavSdtnotificationsdata__notificationid_Enabled ;
      private long GRIDSDTNOTIFICATIONSDATAS_nCurrentRecord ;
      private long GRIDSDTNOTIFICATIONSDATAS_nFirstRecordOnPage ;
      private string gxfirstwebparm ;
      private string gxfirstwebparm_bkp ;
      private string sPrefix ;
      private string sCompPrefix ;
      private string sSFPrefix ;
      private string sGXsfl_15_idx="0001" ;
      private string edtavSdtnotificationsdata__notificationtitle_Internalname ;
      private string edtavSdtnotificationsdata__notificationdescription_Internalname ;
      private string edtavSdtnotificationsdata__notificationdatetime_Internalname ;
      private string sDynURL ;
      private string FormProcess ;
      private string bodyStyle ;
      private string GXKey ;
      private string GX_FocusControl ;
      private string divLayoutmaintable_Internalname ;
      private string divUnnamedtable1_Internalname ;
      private string divNotificationcontent_Internalname ;
      private string lblNotificationtitle_Internalname ;
      private string lblNotificationtitle_Caption ;
      private string lblNotificationtitle_Jsonclick ;
      private string sStyleString ;
      private string subGridsdtnotificationsdatas_Internalname ;
      private string subGridsdtnotificationsdatas_Header ;
      private string lblNotificationitemicon_Caption ;
      private string TempTags ;
      private string ClassString ;
      private string StyleString ;
      private string bttBtncheckallnotif_Internalname ;
      private string bttBtncheckallnotif_Jsonclick ;
      private string sXEvt ;
      private string sEvt ;
      private string EvtGridId ;
      private string EvtRowId ;
      private string sEvtType ;
      private string sGXsfl_15_fel_idx="0001" ;
      private string edtavSdtnotificationsdata__notificationid_Internalname ;
      private string GXEncryptionTmp ;
      private string lblNotificationitemicon_Internalname ;
      private string subGridsdtnotificationsdatas_Class ;
      private string subGridsdtnotificationsdatas_Linesclass ;
      private string divUnnamedtablefsgridsdtnotificationsdatas_Internalname ;
      private string divNotificationitem_Internalname ;
      private string lblNotificationitemicon_Jsonclick ;
      private string divUnnamedtable2_Internalname ;
      private string ROClassString ;
      private string edtavSdtnotificationsdata__notificationdatetime_Jsonclick ;
      private string tblUnnamedtablecontentfsgridsdtnotificationsdatas_Internalname ;
      private string edtavSdtnotificationsdata__notificationid_Jsonclick ;
      private bool entryPointCalled ;
      private bool toggleJsOutput ;
      private bool bGXsfl_15_Refreshing=false ;
      private bool wbLoad ;
      private bool Rfr0gs ;
      private bool wbErr ;
      private bool gxdyncontrolsrefreshing ;
      private bool returnInSub ;
      private bool gx_BV15 ;
      private bool gx_refresh_fired ;
      private GXWebGrid GridsdtnotificationsdatasContainer ;
      private GXWebRow GridsdtnotificationsdatasRow ;
      private GXWebColumn GridsdtnotificationsdatasColumn ;
      private GXWebForm Form ;
      private IGxDataStore dsDataStore2 ;
      private IGxDataStore dsDefault ;
      private msglist BackMsgLst ;
      private msglist LclMsgLst ;
      private GXBaseCollection<GeneXus.Programs.wwpbaseobjects.SdtWWP_SDTNotificationsData_WWP_SDTNotificationsDataItem> AV6SDTNotificationsData ;
      private GXBaseCollection<GeneXus.Programs.wwpbaseobjects.SdtWWP_SDTNotificationsData_WWP_SDTNotificationsDataItem> GXt_objcol_SdtWWP_SDTNotificationsData_WWP_SDTNotificationsDataItem1 ;
   }

}
