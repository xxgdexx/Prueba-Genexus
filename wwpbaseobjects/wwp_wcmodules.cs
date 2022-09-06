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
   public class wwp_wcmodules : GXWebComponent
   {
      public wwp_wcmodules( )
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

      public wwp_wcmodules( IGxContext context )
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
               else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxNewRow_"+"Gridhomemodulessdts") == 0 )
               {
                  nRC_GXsfl_12 = (int)(NumberUtil.Val( GetPar( "nRC_GXsfl_12"), "."));
                  nGXsfl_12_idx = (int)(NumberUtil.Val( GetPar( "nGXsfl_12_idx"), "."));
                  sGXsfl_12_idx = GetPar( "sGXsfl_12_idx");
                  sPrefix = GetPar( "sPrefix");
                  edtavOptionlink_Visible = (int)(NumberUtil.Val( GetNextPar( ), "."));
                  AssignProp(sPrefix, false, edtavOptionlink_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavOptionlink_Visible), 5, 0), !bGXsfl_12_Refreshing);
                  setAjaxCallMode();
                  if ( ! IsValidAjaxCall( true) )
                  {
                     GxWebError = 1;
                     return  ;
                  }
                  gxnrGridhomemodulessdts_newrow( ) ;
                  return  ;
               }
               else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxGridRefresh_"+"Gridhomemodulessdts") == 0 )
               {
                  edtavOptionlink_Visible = (int)(NumberUtil.Val( GetNextPar( ), "."));
                  AssignProp(sPrefix, false, edtavOptionlink_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavOptionlink_Visible), 5, 0), !bGXsfl_12_Refreshing);
                  ajax_req_read_hidden_sdt(GetNextPar( ), AV5HomeModulesSDT);
                  AV9WCLink = GetPar( "WCLink");
                  sPrefix = GetPar( "sPrefix");
                  init_default_properties( ) ;
                  setAjaxCallMode();
                  if ( ! IsValidAjaxCall( true) )
                  {
                     GxWebError = 1;
                     return  ;
                  }
                  gxgrGridhomemodulessdts_refresh( AV5HomeModulesSDT, AV9WCLink, sPrefix) ;
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
            PA0X2( ) ;
            if ( ( GxWebError == 0 ) && ! isAjaxCallMode( ) )
            {
               /* GeneXus formulas. */
               context.Gx_err = 0;
               edtavOptiontitle_Enabled = 0;
               AssignProp(sPrefix, false, edtavOptiontitle_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavOptiontitle_Enabled), 5, 0), !bGXsfl_12_Refreshing);
               WS0X2( ) ;
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
            context.SendWebValue( "WWP_WCModules") ;
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
         context.AddJavascriptSource("gxcfg.js", "?202281811383697", false, true);
         if ( context.isSpaRequest( ) )
         {
            enableOutput();
         }
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
            context.WriteHtmlTextNl( "<form id=\"MAINFORM\" autocomplete=\"off\" name=\"MAINFORM\" method=\"post\" tabindex=-1  class=\"form-horizontal Form\" data-gx-class=\"form-horizontal Form\" novalidate action=\""+formatLink("wwpbaseobjects.wwp_wcmodules.aspx") +"\">") ;
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
         GxWebStd.gx_hidden_field( context, sPrefix+"gxhash_vHOMEMODULESSDT", GetSecureSignedToken( sPrefix, AV5HomeModulesSDT, context));
         GxWebStd.gx_hidden_field( context, sPrefix+"gxhash_vWCLINK", GetSecureSignedToken( sPrefix, StringUtil.RTrim( context.localUtil.Format( AV9WCLink, "")), context));
         GXKey = Crypto.GetSiteKey( );
      }

      protected void SendCloseFormHiddens( )
      {
         /* Send hidden variables. */
         /* Send saved values. */
         send_integrity_footer_hashes( ) ;
         GxWebStd.gx_hidden_field( context, sPrefix+"nRC_GXsfl_12", StringUtil.LTrim( StringUtil.NToC( (decimal)(nRC_GXsfl_12), 8, 0, ".", "")));
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri(sPrefix, false, sPrefix+"vHOMEMODULESSDT", AV5HomeModulesSDT);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt(sPrefix+"vHOMEMODULESSDT", AV5HomeModulesSDT);
         }
         GxWebStd.gx_hidden_field( context, sPrefix+"gxhash_vHOMEMODULESSDT", GetSecureSignedToken( sPrefix, AV5HomeModulesSDT, context));
         GxWebStd.gx_hidden_field( context, sPrefix+"vWCLINK", AV9WCLink);
         GxWebStd.gx_hidden_field( context, sPrefix+"gxhash_vWCLINK", GetSecureSignedToken( sPrefix, StringUtil.RTrim( context.localUtil.Format( AV9WCLink, "")), context));
         GxWebStd.gx_hidden_field( context, sPrefix+"GRIDHOMEMODULESSDTS_Class", StringUtil.RTrim( subGridhomemodulessdts_Class));
         GxWebStd.gx_hidden_field( context, sPrefix+"GRIDHOMEMODULESSDTS_Flexwrap", StringUtil.RTrim( subGridhomemodulessdts_Flexwrap));
         GxWebStd.gx_hidden_field( context, sPrefix+"vOPTIONLINK_Visible", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtavOptionlink_Visible), 5, 0, ".", "")));
      }

      protected void RenderHtmlCloseForm0X2( )
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
            if ( ! ( WebComp_Wc == null ) )
            {
               WebComp_Wc.componentjscripts();
            }
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
         return "WWPBaseObjects.WWP_WCModules" ;
      }

      public override string GetPgmdesc( )
      {
         return "WWP_WCModules" ;
      }

      protected void WB0X0( )
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
               GxWebStd.gx_hidden_field( context, sPrefix+"_CMPPGM", "wwpbaseobjects.wwp_wcmodules.aspx");
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
            GxWebStd.gx_div_start( context, divTablemain_Internalname, 1, 0, "px", 0, "px", "TableMain", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divTablecontent_Internalname, 1, 0, "px", 0, "px", "", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
            /*  Grid Control  */
            GridhomemodulessdtsContainer.SetIsFreestyle(true);
            GridhomemodulessdtsContainer.SetWrapped(nGXWrapped);
            if ( GridhomemodulessdtsContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<div id=\""+sPrefix+"GridhomemodulessdtsContainer"+"DivS\" data-gxgridid=\"12\">") ;
               sStyleString = "";
               GxWebStd.gx_table_start( context, subGridhomemodulessdts_Internalname, subGridhomemodulessdts_Internalname, "", "FreeStyleGrid", 0, "", "", 1, 2, sStyleString, "", "", 0);
               GridhomemodulessdtsContainer.AddObjectProperty("GridName", "Gridhomemodulessdts");
            }
            else
            {
               GridhomemodulessdtsContainer.AddObjectProperty("GridName", "Gridhomemodulessdts");
               GridhomemodulessdtsContainer.AddObjectProperty("Header", subGridhomemodulessdts_Header);
               GridhomemodulessdtsContainer.AddObjectProperty("Class", StringUtil.RTrim( "FreeStyleGrid"));
               GridhomemodulessdtsContainer.AddObjectProperty("Class", "FreeStyleGrid");
               GridhomemodulessdtsContainer.AddObjectProperty("Cellpadding", StringUtil.LTrim( StringUtil.NToC( (decimal)(1), 4, 0, ".", "")));
               GridhomemodulessdtsContainer.AddObjectProperty("Cellspacing", StringUtil.LTrim( StringUtil.NToC( (decimal)(2), 4, 0, ".", "")));
               GridhomemodulessdtsContainer.AddObjectProperty("Backcolorstyle", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGridhomemodulessdts_Backcolorstyle), 1, 0, ".", "")));
               GridhomemodulessdtsContainer.AddObjectProperty("CmpContext", sPrefix);
               GridhomemodulessdtsContainer.AddObjectProperty("InMasterPage", "false");
               GridhomemodulessdtsColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
               GridhomemodulessdtsContainer.AddColumnProperties(GridhomemodulessdtsColumn);
               GridhomemodulessdtsColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
               GridhomemodulessdtsContainer.AddColumnProperties(GridhomemodulessdtsColumn);
               GridhomemodulessdtsColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
               GridhomemodulessdtsContainer.AddColumnProperties(GridhomemodulessdtsColumn);
               GridhomemodulessdtsColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
               GridhomemodulessdtsContainer.AddColumnProperties(GridhomemodulessdtsColumn);
               GridhomemodulessdtsColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
               GridhomemodulessdtsContainer.AddColumnProperties(GridhomemodulessdtsColumn);
               GridhomemodulessdtsColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
               GridhomemodulessdtsContainer.AddColumnProperties(GridhomemodulessdtsColumn);
               GridhomemodulessdtsColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
               GridhomemodulessdtsColumn.AddObjectProperty("Value", AV6OptionLink);
               GridhomemodulessdtsColumn.AddObjectProperty("Visible", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtavOptionlink_Visible), 5, 0, ".", "")));
               GridhomemodulessdtsContainer.AddColumnProperties(GridhomemodulessdtsColumn);
               GridhomemodulessdtsColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
               GridhomemodulessdtsContainer.AddColumnProperties(GridhomemodulessdtsColumn);
               GridhomemodulessdtsColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
               GridhomemodulessdtsContainer.AddColumnProperties(GridhomemodulessdtsColumn);
               GridhomemodulessdtsColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
               GridhomemodulessdtsContainer.AddColumnProperties(GridhomemodulessdtsColumn);
               GridhomemodulessdtsColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
               GridhomemodulessdtsContainer.AddColumnProperties(GridhomemodulessdtsColumn);
               GridhomemodulessdtsColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
               GridhomemodulessdtsColumn.AddObjectProperty("Value", lblOptionicon_Caption);
               GridhomemodulessdtsContainer.AddColumnProperties(GridhomemodulessdtsColumn);
               GridhomemodulessdtsColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
               GridhomemodulessdtsContainer.AddColumnProperties(GridhomemodulessdtsColumn);
               GridhomemodulessdtsColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
               GridhomemodulessdtsContainer.AddColumnProperties(GridhomemodulessdtsColumn);
               GridhomemodulessdtsColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
               GridhomemodulessdtsContainer.AddColumnProperties(GridhomemodulessdtsColumn);
               GridhomemodulessdtsColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
               GridhomemodulessdtsColumn.AddObjectProperty("Value", AV7OptionTitle);
               GridhomemodulessdtsColumn.AddObjectProperty("Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtavOptiontitle_Enabled), 5, 0, ".", "")));
               GridhomemodulessdtsContainer.AddColumnProperties(GridhomemodulessdtsColumn);
               GridhomemodulessdtsColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
               GridhomemodulessdtsContainer.AddColumnProperties(GridhomemodulessdtsColumn);
               GridhomemodulessdtsColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
               GridhomemodulessdtsContainer.AddColumnProperties(GridhomemodulessdtsColumn);
               GridhomemodulessdtsColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
               GridhomemodulessdtsContainer.AddColumnProperties(GridhomemodulessdtsColumn);
               GridhomemodulessdtsColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
               GridhomemodulessdtsContainer.AddColumnProperties(GridhomemodulessdtsColumn);
               GridhomemodulessdtsColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
               GridhomemodulessdtsContainer.AddColumnProperties(GridhomemodulessdtsColumn);
               GridhomemodulessdtsContainer.AddObjectProperty("Selectedindex", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGridhomemodulessdts_Selectedindex), 4, 0, ".", "")));
               GridhomemodulessdtsContainer.AddObjectProperty("Allowselection", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGridhomemodulessdts_Allowselection), 1, 0, ".", "")));
               GridhomemodulessdtsContainer.AddObjectProperty("Selectioncolor", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGridhomemodulessdts_Selectioncolor), 9, 0, ".", "")));
               GridhomemodulessdtsContainer.AddObjectProperty("Allowhover", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGridhomemodulessdts_Allowhovering), 1, 0, ".", "")));
               GridhomemodulessdtsContainer.AddObjectProperty("Hovercolor", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGridhomemodulessdts_Hoveringcolor), 9, 0, ".", "")));
               GridhomemodulessdtsContainer.AddObjectProperty("Allowcollapsing", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGridhomemodulessdts_Allowcollapsing), 1, 0, ".", "")));
               GridhomemodulessdtsContainer.AddObjectProperty("Collapsed", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGridhomemodulessdts_Collapsed), 1, 0, ".", "")));
            }
         }
         if ( wbEnd == 12 )
         {
            wbEnd = 0;
            nRC_GXsfl_12 = (int)(nGXsfl_12_idx-1);
            if ( GridhomemodulessdtsContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "</table>") ;
               context.WriteHtmlText( "</div>") ;
            }
            else
            {
               AV13GXV1 = nGXsfl_12_idx;
               sStyleString = "";
               context.WriteHtmlText( "<div id=\""+sPrefix+"GridhomemodulessdtsContainer"+"Div\" "+sStyleString+">"+"</div>") ;
               context.httpAjaxContext.ajax_rsp_assign_grid(sPrefix+"_"+"Gridhomemodulessdts", GridhomemodulessdtsContainer);
               if ( ! isAjaxCallMode( ) && ! context.isSpaRequest( ) )
               {
                  GxWebStd.gx_hidden_field( context, sPrefix+"GridhomemodulessdtsContainerData", GridhomemodulessdtsContainer.ToJavascriptSource());
               }
               if ( context.isAjaxRequest( ) || context.isSpaRequest( ) )
               {
                  GxWebStd.gx_hidden_field( context, sPrefix+"GridhomemodulessdtsContainerData"+"V", GridhomemodulessdtsContainer.GridValuesHidden());
               }
               else
               {
                  context.WriteHtmlText( "<input type=\"hidden\" "+"name=\""+sPrefix+"GridhomemodulessdtsContainerData"+"V"+"\" value='"+GridhomemodulessdtsContainer.GridValuesHidden()+"'/>") ;
               }
            }
            GxWebStd.gx_div_end( context, "left", "top", "div");
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
         if ( wbEnd == 12 )
         {
            wbEnd = 0;
            if ( isFullAjaxMode( ) )
            {
               if ( GridhomemodulessdtsContainer.GetWrapped() == 1 )
               {
                  context.WriteHtmlText( "</table>") ;
                  context.WriteHtmlText( "</div>") ;
               }
               else
               {
                  AV13GXV1 = nGXsfl_12_idx;
                  sStyleString = "";
                  context.WriteHtmlText( "<div id=\""+sPrefix+"GridhomemodulessdtsContainer"+"Div\" "+sStyleString+">"+"</div>") ;
                  context.httpAjaxContext.ajax_rsp_assign_grid(sPrefix+"_"+"Gridhomemodulessdts", GridhomemodulessdtsContainer);
                  if ( ! isAjaxCallMode( ) && ! context.isSpaRequest( ) )
                  {
                     GxWebStd.gx_hidden_field( context, sPrefix+"GridhomemodulessdtsContainerData", GridhomemodulessdtsContainer.ToJavascriptSource());
                  }
                  if ( context.isAjaxRequest( ) || context.isSpaRequest( ) )
                  {
                     GxWebStd.gx_hidden_field( context, sPrefix+"GridhomemodulessdtsContainerData"+"V", GridhomemodulessdtsContainer.GridValuesHidden());
                  }
                  else
                  {
                     context.WriteHtmlText( "<input type=\"hidden\" "+"name=\""+sPrefix+"GridhomemodulessdtsContainerData"+"V"+"\" value='"+GridhomemodulessdtsContainer.GridValuesHidden()+"'/>") ;
                  }
               }
            }
         }
         wbLoad = true;
      }

      protected void START0X2( )
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
               Form.Meta.addItem("description", "WWP_WCModules", 0) ;
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
               STRUP0X0( ) ;
            }
         }
      }

      protected void WS0X2( )
      {
         START0X2( ) ;
         EVT0X2( ) ;
      }

      protected void EVT0X2( )
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
                                 STRUP0X0( ) ;
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
                           else if ( StringUtil.StrCmp(sEvt, "LSCR") == 0 )
                           {
                              if ( ( StringUtil.Len( sPrefix) != 0 ) && ( nDoneStart == 0 ) )
                              {
                                 STRUP0X0( ) ;
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
                           if ( ( StringUtil.StrCmp(StringUtil.Left( sEvt, 5), "START") == 0 ) || ( StringUtil.StrCmp(StringUtil.Left( sEvt, 24), "GRIDHOMEMODULESSDTS.LOAD") == 0 ) || ( StringUtil.StrCmp(StringUtil.Left( sEvt, 5), "ENTER") == 0 ) || ( StringUtil.StrCmp(StringUtil.Left( sEvt, 6), "CANCEL") == 0 ) )
                           {
                              if ( ( StringUtil.Len( sPrefix) != 0 ) && ( nDoneStart == 0 ) )
                              {
                                 STRUP0X0( ) ;
                              }
                              nGXsfl_12_idx = (int)(NumberUtil.Val( sEvtType, "."));
                              sGXsfl_12_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_12_idx), 4, 0), 4, "0");
                              SubsflControlProps_122( ) ;
                              AV6OptionLink = cgiGet( edtavOptionlink_Internalname);
                              AssignAttri(sPrefix, false, edtavOptionlink_Internalname, AV6OptionLink);
                              AV7OptionTitle = cgiGet( edtavOptiontitle_Internalname);
                              AssignAttri(sPrefix, false, edtavOptiontitle_Internalname, AV7OptionTitle);
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
                                          E110X2 ();
                                       }
                                    }
                                 }
                                 else if ( StringUtil.StrCmp(sEvt, "GRIDHOMEMODULESSDTS.LOAD") == 0 )
                                 {
                                    if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
                                    {
                                       context.wbHandled = 1;
                                       if ( ! wbErr )
                                       {
                                          dynload_actions( ) ;
                                          E120X2 ();
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
                                       STRUP0X0( ) ;
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
                     else if ( StringUtil.StrCmp(sEvtType, "W") == 0 )
                     {
                        sEvtType = StringUtil.Left( sEvt, 4);
                        sEvt = StringUtil.Right( sEvt, (short)(StringUtil.Len( sEvt)-4));
                        nCmpId = (short)(NumberUtil.Val( sEvtType, "."));
                        if ( nCmpId == 33 )
                        {
                           sEvtType = StringUtil.Left( sEvt, 4);
                           sEvt = StringUtil.Right( sEvt, (short)(StringUtil.Len( sEvt)-4));
                           sCmpCtrl = "W0033" + sEvtType;
                           OldWc = cgiGet( sPrefix+sCmpCtrl);
                           if ( ( StringUtil.Len( OldWc) == 0 ) || ( StringUtil.StrCmp(OldWc, WebComp_GX_Process_Component) != 0 ) )
                           {
                              WebComp_GX_Process = getWebComponent(GetType(), "GeneXus.Programs", OldWc, new Object[] {context} );
                              WebComp_GX_Process.ComponentInit();
                              WebComp_GX_Process.Name = "OldWc";
                              WebComp_GX_Process_Component = OldWc;
                           }
                           if ( StringUtil.Len( WebComp_GX_Process_Component) != 0 )
                           {
                              WebComp_GX_Process.componentprocess(sPrefix+"W0033", sEvtType, sEvt);
                           }
                           nGXsfl_12_webc_idx = (int)(NumberUtil.Val( sEvtType, "."));
                           WebCompHandler = "Wc";
                           WebComp_GX_Process_Component = OldWc;
                        }
                     }
                     context.wbHandled = 1;
                  }
               }
            }
         }
      }

      protected void WE0X2( )
      {
         if ( ! GxWebStd.gx_redirect( context) )
         {
            Rfr0gs = true;
            Refresh( ) ;
            if ( ! GxWebStd.gx_redirect( context) )
            {
               RenderHtmlCloseForm0X2( ) ;
            }
         }
      }

      protected void PA0X2( )
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

      protected void gxnrGridhomemodulessdts_newrow( )
      {
         GxWebStd.set_html_headers( context, 0, "", "");
         SubsflControlProps_122( ) ;
         while ( nGXsfl_12_idx <= nRC_GXsfl_12 )
         {
            sendrow_122( ) ;
            nGXsfl_12_idx = ((subGridhomemodulessdts_Islastpage==1)&&(nGXsfl_12_idx+1>subGridhomemodulessdts_fnc_Recordsperpage( )) ? 1 : nGXsfl_12_idx+1);
            sGXsfl_12_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_12_idx), 4, 0), 4, "0");
            SubsflControlProps_122( ) ;
         }
         AddString( context.httpAjaxContext.getJSONContainerResponse( GridhomemodulessdtsContainer)) ;
         /* End function gxnrGridhomemodulessdts_newrow */
      }

      protected void gxgrGridhomemodulessdts_refresh( GXBaseCollection<GeneXus.Programs.wwpbaseobjects.SdtHomeModulesSDT_HomeModulesSDTItem> AV5HomeModulesSDT ,
                                                      string AV9WCLink ,
                                                      string sPrefix )
      {
         initialize_formulas( ) ;
         GxWebStd.set_html_headers( context, 0, "", "");
         GRIDHOMEMODULESSDTS_nCurrentRecord = 0;
         RF0X2( ) ;
         GXKey = Crypto.GetSiteKey( );
         send_integrity_footer_hashes( ) ;
         GXKey = Crypto.GetSiteKey( );
         /* End function gxgrGridhomemodulessdts_refresh */
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
         RF0X2( ) ;
         if ( isFullAjaxMode( ) )
         {
            send_integrity_footer_hashes( ) ;
         }
      }

      protected void initialize_formulas( )
      {
         /* GeneXus formulas. */
         context.Gx_err = 0;
         edtavOptiontitle_Enabled = 0;
         AssignProp(sPrefix, false, edtavOptiontitle_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavOptiontitle_Enabled), 5, 0), !bGXsfl_12_Refreshing);
      }

      protected void RF0X2( )
      {
         initialize_formulas( ) ;
         clear_multi_value_controls( ) ;
         if ( isAjaxCallMode( ) )
         {
            GridhomemodulessdtsContainer.ClearRows();
         }
         wbStart = 12;
         nGXsfl_12_idx = 1;
         sGXsfl_12_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_12_idx), 4, 0), 4, "0");
         SubsflControlProps_122( ) ;
         bGXsfl_12_Refreshing = true;
         GridhomemodulessdtsContainer.AddObjectProperty("GridName", "Gridhomemodulessdts");
         GridhomemodulessdtsContainer.AddObjectProperty("CmpContext", sPrefix);
         GridhomemodulessdtsContainer.AddObjectProperty("InMasterPage", "false");
         GridhomemodulessdtsContainer.AddObjectProperty("Class", StringUtil.RTrim( "FreeStyleGrid"));
         GridhomemodulessdtsContainer.AddObjectProperty("Class", "FreeStyleGrid");
         GridhomemodulessdtsContainer.AddObjectProperty("Cellpadding", StringUtil.LTrim( StringUtil.NToC( (decimal)(1), 4, 0, ".", "")));
         GridhomemodulessdtsContainer.AddObjectProperty("Cellspacing", StringUtil.LTrim( StringUtil.NToC( (decimal)(2), 4, 0, ".", "")));
         GridhomemodulessdtsContainer.AddObjectProperty("Backcolorstyle", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGridhomemodulessdts_Backcolorstyle), 1, 0, ".", "")));
         GridhomemodulessdtsContainer.PageSize = subGridhomemodulessdts_fnc_Recordsperpage( );
         if ( subGridhomemodulessdts_Islastpage != 0 )
         {
            GRIDHOMEMODULESSDTS_nFirstRecordOnPage = (long)(subGridhomemodulessdts_fnc_Recordcount( )-subGridhomemodulessdts_fnc_Recordsperpage( ));
            GxWebStd.gx_hidden_field( context, sPrefix+"GRIDHOMEMODULESSDTS_nFirstRecordOnPage", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRIDHOMEMODULESSDTS_nFirstRecordOnPage), 15, 0, ".", "")));
            GridhomemodulessdtsContainer.AddObjectProperty("GRIDHOMEMODULESSDTS_nFirstRecordOnPage", GRIDHOMEMODULESSDTS_nFirstRecordOnPage);
         }
         if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
         {
            if ( 1 != 0 )
            {
               if ( StringUtil.Len( WebComp_GX_Process_Component) != 0 )
               {
                  WebComp_GX_Process.componentstart();
               }
            }
         }
         if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
         {
            if ( 1 != 0 )
            {
               if ( StringUtil.Len( WebComp_Wc_Component) != 0 )
               {
                  WebComp_Wc.componentstart();
               }
            }
         }
         gxdyncontrolsrefreshing = true;
         fix_multi_value_controls( ) ;
         gxdyncontrolsrefreshing = false;
         if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
         {
            SubsflControlProps_122( ) ;
            E120X2 ();
            wbEnd = 12;
            WB0X0( ) ;
         }
         bGXsfl_12_Refreshing = true;
      }

      protected void send_integrity_lvl_hashes0X2( )
      {
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri(sPrefix, false, sPrefix+"vHOMEMODULESSDT", AV5HomeModulesSDT);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt(sPrefix+"vHOMEMODULESSDT", AV5HomeModulesSDT);
         }
         GxWebStd.gx_hidden_field( context, sPrefix+"gxhash_vHOMEMODULESSDT", GetSecureSignedToken( sPrefix, AV5HomeModulesSDT, context));
         GxWebStd.gx_hidden_field( context, sPrefix+"vWCLINK", AV9WCLink);
         GxWebStd.gx_hidden_field( context, sPrefix+"gxhash_vWCLINK", GetSecureSignedToken( sPrefix, StringUtil.RTrim( context.localUtil.Format( AV9WCLink, "")), context));
      }

      protected int subGridhomemodulessdts_fnc_Pagecount( )
      {
         return (int)(-1) ;
      }

      protected int subGridhomemodulessdts_fnc_Recordcount( )
      {
         return (int)(-1) ;
      }

      protected int subGridhomemodulessdts_fnc_Recordsperpage( )
      {
         return (int)(-1) ;
      }

      protected int subGridhomemodulessdts_fnc_Currentpage( )
      {
         return (int)(-1) ;
      }

      protected void before_start_formulas( )
      {
         context.Gx_err = 0;
         edtavOptiontitle_Enabled = 0;
         AssignProp(sPrefix, false, edtavOptiontitle_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavOptiontitle_Enabled), 5, 0), !bGXsfl_12_Refreshing);
         fix_multi_value_controls( ) ;
      }

      protected void STRUP0X0( )
      {
         /* Before Start, stand alone formulas. */
         before_start_formulas( ) ;
         /* Execute Start event if defined. */
         context.wbGlbDoneStart = 0;
         /* Execute user event: Start */
         E110X2 ();
         context.wbGlbDoneStart = 1;
         nDoneStart = 1;
         /* After Start, stand alone formulas. */
         sXEvt = cgiGet( "_EventName");
         if ( ! GetJustCreated( ) && ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 ) )
         {
            /* Read saved SDTs. */
            /* Read saved values. */
            nRC_GXsfl_12 = (int)(context.localUtil.CToN( cgiGet( sPrefix+"nRC_GXsfl_12"), ".", ","));
            subGridhomemodulessdts_Class = cgiGet( sPrefix+"GRIDHOMEMODULESSDTS_Class");
            subGridhomemodulessdts_Flexwrap = cgiGet( sPrefix+"GRIDHOMEMODULESSDTS_Flexwrap");
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
         E110X2 ();
         if (returnInSub) return;
      }

      protected void E110X2( )
      {
         /* Start Routine */
         returnInSub = false;
         edtavOptionlink_Visible = 0;
         AssignProp(sPrefix, false, edtavOptionlink_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavOptionlink_Visible), 5, 0), !bGXsfl_12_Refreshing);
         AV5HomeModulesSDT = new GXBaseCollection<GeneXus.Programs.wwpbaseobjects.SdtHomeModulesSDT_HomeModulesSDTItem>( context, "HomeModulesSDTItem", "SIGERP_ADVANCED");
         AV8HomeModulesSDTItem = new GeneXus.Programs.wwpbaseobjects.SdtHomeModulesSDT_HomeModulesSDTItem(context);
         AV8HomeModulesSDTItem.gxTpr_Optiontitle = "Sales and Distribution";
         AV8HomeModulesSDTItem.gxTpr_Optioniconthemeclass = "fa fa-credit-card";
         AV8HomeModulesSDTItem.gxTpr_Optiontype = 1;
         AV8HomeModulesSDTItem.gxTpr_Optionsize = 1;
         AV5HomeModulesSDT.Add(AV8HomeModulesSDTItem, 0);
         AV8HomeModulesSDTItem = new GeneXus.Programs.wwpbaseobjects.SdtHomeModulesSDT_HomeModulesSDTItem(context);
         AV8HomeModulesSDTItem.gxTpr_Optiontitle = "Inventory";
         AV8HomeModulesSDTItem.gxTpr_Optioniconthemeclass = "fa fa-tasks";
         AV8HomeModulesSDTItem.gxTpr_Optiontype = 1;
         AV8HomeModulesSDTItem.gxTpr_Optionsize = 1;
         AV5HomeModulesSDT.Add(AV8HomeModulesSDTItem, 0);
         AV8HomeModulesSDTItem = new GeneXus.Programs.wwpbaseobjects.SdtHomeModulesSDT_HomeModulesSDTItem(context);
         AV8HomeModulesSDTItem.gxTpr_Optiontitle = "Security";
         AV8HomeModulesSDTItem.gxTpr_Optioniconthemeclass = "fa fa-key";
         AV8HomeModulesSDTItem.gxTpr_Optiontype = 1;
         AV8HomeModulesSDTItem.gxTpr_Optionsize = 1;
         AV5HomeModulesSDT.Add(AV8HomeModulesSDTItem, 0);
         AV8HomeModulesSDTItem = new GeneXus.Programs.wwpbaseobjects.SdtHomeModulesSDT_HomeModulesSDTItem(context);
         AV8HomeModulesSDTItem.gxTpr_Optiontitle = "Notifications";
         AV8HomeModulesSDTItem.gxTpr_Optioniconthemeclass = "fas fa-bell";
         AV8HomeModulesSDTItem.gxTpr_Optiontype = 1;
         AV8HomeModulesSDTItem.gxTpr_Optionsize = 1;
         AV8HomeModulesSDTItem.gxTpr_Optionwclink = formatLink("seguridad.notificacionesww.aspx") ;
         AV5HomeModulesSDT.Add(AV8HomeModulesSDTItem, 0);
         AV8HomeModulesSDTItem = new GeneXus.Programs.wwpbaseobjects.SdtHomeModulesSDT_HomeModulesSDTItem(context);
         AV8HomeModulesSDTItem.gxTpr_Optiontitle = "Configurations";
         AV8HomeModulesSDTItem.gxTpr_Optioniconthemeclass = "fa fa-cog";
         AV8HomeModulesSDTItem.gxTpr_Optiontype = 1;
         AV8HomeModulesSDTItem.gxTpr_Optionsize = 1;
         AV5HomeModulesSDT.Add(AV8HomeModulesSDTItem, 0);
         AV8HomeModulesSDTItem = new GeneXus.Programs.wwpbaseobjects.SdtHomeModulesSDT_HomeModulesSDTItem(context);
         AV8HomeModulesSDTItem.gxTpr_Optiontitle = "Inventory management";
         AV8HomeModulesSDTItem.gxTpr_Optioniconthemeclass = "fa fa-tasks";
         AV8HomeModulesSDTItem.gxTpr_Optiontype = 1;
         AV8HomeModulesSDTItem.gxTpr_Optionsize = 1;
         AV5HomeModulesSDT.Add(AV8HomeModulesSDTItem, 0);
         AV8HomeModulesSDTItem = new GeneXus.Programs.wwpbaseobjects.SdtHomeModulesSDT_HomeModulesSDTItem(context);
         AV8HomeModulesSDTItem.gxTpr_Optiontitle = "Security";
         AV8HomeModulesSDTItem.gxTpr_Optioniconthemeclass = "fa fa-key";
         AV8HomeModulesSDTItem.gxTpr_Optiontype = 1;
         AV8HomeModulesSDTItem.gxTpr_Optionsize = 1;
         AV5HomeModulesSDT.Add(AV8HomeModulesSDTItem, 0);
         AV8HomeModulesSDTItem = new GeneXus.Programs.wwpbaseobjects.SdtHomeModulesSDT_HomeModulesSDTItem(context);
         AV8HomeModulesSDTItem.gxTpr_Optiontitle = "Notifications";
         AV8HomeModulesSDTItem.gxTpr_Optioniconthemeclass = "fas fa-bell";
         AV8HomeModulesSDTItem.gxTpr_Optiontype = 1;
         AV8HomeModulesSDTItem.gxTpr_Optionsize = 1;
         AV5HomeModulesSDT.Add(AV8HomeModulesSDTItem, 0);
         AV8HomeModulesSDTItem = new GeneXus.Programs.wwpbaseobjects.SdtHomeModulesSDT_HomeModulesSDTItem(context);
         AV8HomeModulesSDTItem.gxTpr_Optiontitle = "Configurations";
         AV8HomeModulesSDTItem.gxTpr_Optioniconthemeclass = "fa fa-cog";
         AV8HomeModulesSDTItem.gxTpr_Optiontype = 1;
         AV8HomeModulesSDTItem.gxTpr_Optionsize = 1;
         AV5HomeModulesSDT.Add(AV8HomeModulesSDTItem, 0);
         AV8HomeModulesSDTItem = new GeneXus.Programs.wwpbaseobjects.SdtHomeModulesSDT_HomeModulesSDTItem(context);
         AV8HomeModulesSDTItem.gxTpr_Optiontitle = "Sales and Distribution";
         AV8HomeModulesSDTItem.gxTpr_Optioniconthemeclass = "fa fa-credit-card";
         AV8HomeModulesSDTItem.gxTpr_Optiontype = 1;
         AV8HomeModulesSDTItem.gxTpr_Optionsize = 1;
         AV5HomeModulesSDT.Add(AV8HomeModulesSDTItem, 0);
      }

      private void E120X2( )
      {
         /* Gridhomemodulessdts_Load Routine */
         returnInSub = false;
         AV13GXV1 = 1;
         while ( AV13GXV1 <= AV5HomeModulesSDT.Count )
         {
            AV5HomeModulesSDT.CurrentItem = ((GeneXus.Programs.wwpbaseobjects.SdtHomeModulesSDT_HomeModulesSDTItem)AV5HomeModulesSDT.Item(AV13GXV1));
            if ( ((GeneXus.Programs.wwpbaseobjects.SdtHomeModulesSDT_HomeModulesSDTItem)(AV5HomeModulesSDT.CurrentItem)).gxTpr_Optiontype == 1 )
            {
               AV7OptionTitle = ((GeneXus.Programs.wwpbaseobjects.SdtHomeModulesSDT_HomeModulesSDTItem)(AV5HomeModulesSDT.CurrentItem)).gxTpr_Optiontitle;
               AssignAttri(sPrefix, false, edtavOptiontitle_Internalname, AV7OptionTitle);
               lblOptionicon_Caption = StringUtil.Format( "<i class='%2 %1' style='font-size: 40px'></i>", ((GeneXus.Programs.wwpbaseobjects.SdtHomeModulesSDT_HomeModulesSDTItem)(AV5HomeModulesSDT.CurrentItem)).gxTpr_Optioniconthemeclass, "CardsMenuIcon", "", "", "", "", "", "", "");
               divTableoptioniconandtitle_Class = ((((GeneXus.Programs.wwpbaseobjects.SdtHomeModulesSDT_HomeModulesSDTItem)(AV5HomeModulesSDT.CurrentItem)).gxTpr_Optionsize==1) ? "TableCardsMenu" : "TableCardsMenu2x");
               AssignProp(sPrefix, false, divTableoptioniconandtitle_Internalname, "Class", divTableoptioniconandtitle_Class, !bGXsfl_12_Refreshing);
               divTableoptioniconandtitle_Visible = 1;
               AssignProp(sPrefix, false, divTableoptioniconandtitle_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(divTableoptioniconandtitle_Visible), 5, 0), !bGXsfl_12_Refreshing);
               divTableoptionwc_Visible = 0;
               AssignProp(sPrefix, false, divTableoptionwc_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(divTableoptionwc_Visible), 5, 0), !bGXsfl_12_Refreshing);
            }
            else
            {
               divTableoptionwc_Class = ((((GeneXus.Programs.wwpbaseobjects.SdtHomeModulesSDT_HomeModulesSDTItem)(AV5HomeModulesSDT.CurrentItem)).gxTpr_Optionsize==1) ? "TableCardsMenu" : "TableCardsMenu2x");
               AssignProp(sPrefix, false, divTableoptionwc_Internalname, "Class", divTableoptionwc_Class, !bGXsfl_12_Refreshing);
               divTableoptioniconandtitle_Visible = 0;
               AssignProp(sPrefix, false, divTableoptioniconandtitle_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(divTableoptioniconandtitle_Visible), 5, 0), !bGXsfl_12_Refreshing);
               divTableoptionwc_Visible = 1;
               AssignProp(sPrefix, false, divTableoptionwc_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(divTableoptionwc_Visible), 5, 0), !bGXsfl_12_Refreshing);
               if ( ((GeneXus.Programs.wwpbaseobjects.SdtHomeModulesSDT_HomeModulesSDTItem)(AV5HomeModulesSDT.CurrentItem)).gxTpr_Optiontype == 2 )
               {
                  GXKey = Crypto.GetSiteKey( );
                  GXEncryptionTmp = "wwpbaseobjects.homeprogressbarwc.aspx"+UrlEncode(StringUtil.RTrim(((GeneXus.Programs.wwpbaseobjects.SdtHomeModulesSDT_HomeModulesSDTItem)(AV5HomeModulesSDT.CurrentItem)).gxTpr_Optiontitle)) + "," + UrlEncode(StringUtil.RTrim(((GeneXus.Programs.wwpbaseobjects.SdtHomeModulesSDT_HomeModulesSDTItem)(AV5HomeModulesSDT.CurrentItem)).gxTpr_Optiondescription)) + "," + UrlEncode(StringUtil.LTrimStr(((GeneXus.Programs.wwpbaseobjects.SdtHomeModulesSDT_HomeModulesSDTItem)(AV5HomeModulesSDT.CurrentItem)).gxTpr_Optionprogressvalue,2,0));
                  AV9WCLink = formatLink("wwpbaseobjects.homeprogressbarwc.aspx") + "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey);
                  AssignAttri(sPrefix, false, "AV9WCLink", AV9WCLink);
                  GxWebStd.gx_hidden_field( context, sPrefix+"gxhash_vWCLINK", GetSecureSignedToken( sPrefix, StringUtil.RTrim( context.localUtil.Format( AV9WCLink, "")), context));
               }
               else if ( ((GeneXus.Programs.wwpbaseobjects.SdtHomeModulesSDT_HomeModulesSDTItem)(AV5HomeModulesSDT.CurrentItem)).gxTpr_Optiontype == 3 )
               {
                  GXKey = Crypto.GetSiteKey( );
                  GXEncryptionTmp = "wwpbaseobjects.homeprogressbarcirclewc.aspx"+UrlEncode(StringUtil.RTrim(((GeneXus.Programs.wwpbaseobjects.SdtHomeModulesSDT_HomeModulesSDTItem)(AV5HomeModulesSDT.CurrentItem)).gxTpr_Optiontitle)) + "," + UrlEncode(StringUtil.LTrimStr(((GeneXus.Programs.wwpbaseobjects.SdtHomeModulesSDT_HomeModulesSDTItem)(AV5HomeModulesSDT.CurrentItem)).gxTpr_Optionprogressvalue,2,0));
                  AV9WCLink = formatLink("wwpbaseobjects.homeprogressbarcirclewc.aspx") + "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey);
                  AssignAttri(sPrefix, false, "AV9WCLink", AV9WCLink);
                  GxWebStd.gx_hidden_field( context, sPrefix+"gxhash_vWCLINK", GetSecureSignedToken( sPrefix, StringUtil.RTrim( context.localUtil.Format( AV9WCLink, "")), context));
               }
               else if ( ((GeneXus.Programs.wwpbaseobjects.SdtHomeModulesSDT_HomeModulesSDTItem)(AV5HomeModulesSDT.CurrentItem)).gxTpr_Optiontype == 4 )
               {
                  AV9WCLink = ((GeneXus.Programs.wwpbaseobjects.SdtHomeModulesSDT_HomeModulesSDTItem)(AV5HomeModulesSDT.CurrentItem)).gxTpr_Optionwclink;
                  AssignAttri(sPrefix, false, "AV9WCLink", AV9WCLink);
                  GxWebStd.gx_hidden_field( context, sPrefix+"gxhash_vWCLINK", GetSecureSignedToken( sPrefix, StringUtil.RTrim( context.localUtil.Format( AV9WCLink, "")), context));
               }
               /* Object Property */
               if ( StringUtil.Len( sPrefix) == 0 )
               {
                  bDynCreated_Wc = true;
               }
               if ( ! IsSameComponent( WebComp_Wc_Component, AV9WCLink) )
               {
                  WebComp_Wc = getWebComponent(GetType(), "GeneXus.Programs", AV9WCLink, new Object[] {context} );
                  WebComp_Wc.ComponentInit();
                  WebComp_Wc.Name = "AV9WCLink";
                  WebComp_Wc_Component = AV9WCLink;
               }
               if ( StringUtil.Len( WebComp_Wc_Component) != 0 )
               {
                  WebComp_Wc.setjustcreated();
                  WebComp_Wc.componentprepare(new Object[] {(string)sPrefix+"W0033",(string)sGXsfl_12_idx});
                  WebComp_Wc.componentbind(new Object[] {});
               }
            }
            AV6OptionLink = ((GeneXus.Programs.wwpbaseobjects.SdtHomeModulesSDT_HomeModulesSDTItem)(AV5HomeModulesSDT.CurrentItem)).gxTpr_Optionwclink;
            AssignAttri(sPrefix, false, edtavOptionlink_Internalname, AV6OptionLink);
            /* Load Method */
            if ( wbStart != -1 )
            {
               wbStart = 12;
            }
            sendrow_122( ) ;
            if ( isFullAjaxMode( ) && ! bGXsfl_12_Refreshing )
            {
               DoAjaxLoad(12, GridhomemodulessdtsRow);
            }
            AV13GXV1 = (int)(AV13GXV1+1);
         }
         /*  Sending Event outputs  */
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
         PA0X2( ) ;
         WS0X2( ) ;
         WE0X2( ) ;
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
         PA0X2( ) ;
         WCParametersGet( ) ;
      }

      public override void componentprepare( Object[] obj )
      {
         wbLoad = false;
         sCompPrefix = (string)getParm(obj,0);
         sSFPrefix = (string)getParm(obj,1);
         sPrefix = sCompPrefix + sSFPrefix;
         AddComponentObject(sPrefix, "wwpbaseobjects\\wwp_wcmodules", GetJustCreated( ));
         if ( ( nDoneStart == 0 ) && ( nDynComponent == 0 ) )
         {
            INITWEB( ) ;
         }
         else
         {
            init_default_properties( ) ;
            init_web_controls( ) ;
         }
         PA0X2( ) ;
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
         PA0X2( ) ;
         sEvt = sCompEvt;
         WCParametersGet( ) ;
         WS0X2( ) ;
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
         WS0X2( ) ;
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
         WE0X2( ) ;
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
         if ( ! ( WebComp_GX_Process == null ) )
         {
            WebComp_GX_Process.componentjscripts();
         }
         if ( ! ( WebComp_Wc == null ) )
         {
            WebComp_Wc.componentjscripts();
         }
      }

      public override void componentthemes( )
      {
         define_styles( ) ;
      }

      protected void define_styles( )
      {
         AddThemeStyleSheetFile("", context.GetTheme( )+".css", "?"+GetCacheInvalidationToken( ));
         if ( ! ( WebComp_Wc == null ) )
         {
            if ( StringUtil.Len( WebComp_Wc_Component) != 0 )
            {
               WebComp_Wc.componentthemes();
            }
         }
         bool outputEnabled = isOutputEnabled( );
         if ( context.isSpaRequest( ) )
         {
            enableOutput();
         }
         idxLst = 1;
         while ( idxLst <= Form.Jscriptsrc.Count )
         {
            context.AddJavascriptSource(StringUtil.RTrim( ((string)Form.Jscriptsrc.Item(idxLst))), "?202281811383749", true, true);
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
         context.AddJavascriptSource("wwpbaseobjects/wwp_wcmodules.js", "?202281811383749", false, true);
         /* End function include_jscripts */
      }

      protected void SubsflControlProps_122( )
      {
         edtavOptionlink_Internalname = sPrefix+"vOPTIONLINK_"+sGXsfl_12_idx;
         lblOptionicon_Internalname = sPrefix+"OPTIONICON_"+sGXsfl_12_idx;
         edtavOptiontitle_Internalname = sPrefix+"vOPTIONTITLE_"+sGXsfl_12_idx;
      }

      protected void SubsflControlProps_fel_122( )
      {
         edtavOptionlink_Internalname = sPrefix+"vOPTIONLINK_"+sGXsfl_12_fel_idx;
         lblOptionicon_Internalname = sPrefix+"OPTIONICON_"+sGXsfl_12_fel_idx;
         edtavOptiontitle_Internalname = sPrefix+"vOPTIONTITLE_"+sGXsfl_12_fel_idx;
      }

      protected void sendrow_122( )
      {
         SubsflControlProps_122( ) ;
         WB0X0( ) ;
         GridhomemodulessdtsRow = GXWebRow.GetNew(context,GridhomemodulessdtsContainer);
         if ( subGridhomemodulessdts_Backcolorstyle == 0 )
         {
            /* None style subfile background logic. */
            subGridhomemodulessdts_Backstyle = 0;
            if ( StringUtil.StrCmp(subGridhomemodulessdts_Class, "") != 0 )
            {
               subGridhomemodulessdts_Linesclass = subGridhomemodulessdts_Class+"Odd";
            }
         }
         else if ( subGridhomemodulessdts_Backcolorstyle == 1 )
         {
            /* Uniform style subfile background logic. */
            subGridhomemodulessdts_Backstyle = 0;
            subGridhomemodulessdts_Backcolor = subGridhomemodulessdts_Allbackcolor;
            if ( StringUtil.StrCmp(subGridhomemodulessdts_Class, "") != 0 )
            {
               subGridhomemodulessdts_Linesclass = subGridhomemodulessdts_Class+"Uniform";
            }
         }
         else if ( subGridhomemodulessdts_Backcolorstyle == 2 )
         {
            /* Header style subfile background logic. */
            subGridhomemodulessdts_Backstyle = 1;
            if ( StringUtil.StrCmp(subGridhomemodulessdts_Class, "") != 0 )
            {
               subGridhomemodulessdts_Linesclass = subGridhomemodulessdts_Class+"Odd";
            }
            subGridhomemodulessdts_Backcolor = (int)(0xFFFFFF);
         }
         else if ( subGridhomemodulessdts_Backcolorstyle == 3 )
         {
            /* Report style subfile background logic. */
            subGridhomemodulessdts_Backstyle = 1;
            subGridhomemodulessdts_Backcolor = (int)(0xFFFFFF);
            if ( StringUtil.StrCmp(subGridhomemodulessdts_Class, "") != 0 )
            {
               subGridhomemodulessdts_Linesclass = subGridhomemodulessdts_Class+"Odd";
            }
         }
         /* Start of Columns property logic. */
         /* Div Control */
         GridhomemodulessdtsRow.AddColumnProperties("div_start", -1, isAjaxCallMode( ), new Object[] {(string)divUnnamedtablefsgridhomemodulessdts_Internalname+"_"+sGXsfl_12_idx,(short)1,(short)0,(string)"px",(short)0,(string)"px",(string)"Flex",(string)"left",(string)"top",(string)" "+"data-gx-flex"+" ",(string)"",(string)"div"});
         GridhomemodulessdtsColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
         GridhomemodulessdtsRow.AddRenderProperties(GridhomemodulessdtsColumn);
         /* Div Control */
         GridhomemodulessdtsRow.AddColumnProperties("div_start", -1, isAjaxCallMode( ), new Object[] {(string)"",(short)1,(short)0,(string)"px",(short)0,(string)"px",(string)"Invisible",(string)"left",(string)"top",(string)"",(string)"flex-grow:1;",(string)"div"});
         GridhomemodulessdtsColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
         GridhomemodulessdtsRow.AddRenderProperties(GridhomemodulessdtsColumn);
         /* Table start */
         GridhomemodulessdtsRow.AddColumnProperties("table", -1, isAjaxCallMode( ), new Object[] {(string)tblUnnamedtablecontentfsgridhomemodulessdts_Internalname+"_"+sGXsfl_12_idx,(short)1,(string)"Table",(string)"",(string)"",(string)"",(string)"",(string)"",(string)"",(short)1,(short)2,(string)"",(string)"",(string)"",(string)"px",(string)"px",(string)""});
         GridhomemodulessdtsColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
         GridhomemodulessdtsRow.AddRenderProperties(GridhomemodulessdtsColumn);
         GridhomemodulessdtsRow.AddColumnProperties("row", -1, isAjaxCallMode( ), new Object[] {(string)"",(string)"",(string)""});
         GridhomemodulessdtsColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
         GridhomemodulessdtsRow.AddRenderProperties(GridhomemodulessdtsColumn);
         GridhomemodulessdtsRow.AddColumnProperties("cell", -1, isAjaxCallMode( ), new Object[] {(string)"",(string)"",(string)""});
         GridhomemodulessdtsColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
         GridhomemodulessdtsRow.AddRenderProperties(GridhomemodulessdtsColumn);
         /* Div Control */
         GridhomemodulessdtsRow.AddColumnProperties("div_start", -1, isAjaxCallMode( ), new Object[] {(string)"",(short)1,(short)0,(string)"px",(short)0,(string)"px",(string)" gx-attribute",(string)"left",(string)"top",(string)"",(string)"",(string)"div"});
         GridhomemodulessdtsColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
         GridhomemodulessdtsRow.AddRenderProperties(GridhomemodulessdtsColumn);
         /* Attribute/Variable Label */
         GridhomemodulessdtsRow.AddColumnProperties("html_label", -1, isAjaxCallMode( ), new Object[] {(string)edtavOptionlink_Internalname,(string)"Option Link",(string)"gx-form-item AttributeLabel",(short)0,(bool)true,(string)"width: 25%;"});
         GridhomemodulessdtsColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
         GridhomemodulessdtsRow.AddRenderProperties(GridhomemodulessdtsColumn);
         /* Multiple line edit */
         ClassString = "Attribute";
         StyleString = "";
         ClassString = "Attribute";
         StyleString = "";
         GridhomemodulessdtsRow.AddColumnProperties("html_textarea", 1, isAjaxCallMode( ), new Object[] {(string)edtavOptionlink_Internalname,(string)AV6OptionLink,(string)"",(string)"",(short)0,(int)edtavOptionlink_Visible,(short)0,(short)0,(short)80,(string)"chr",(short)3,(string)"row",(string)StyleString,(string)ClassString,(string)"",(string)"",(string)"200",(short)-1,(short)0,(string)"",(string)"",(short)-1,(bool)true,(string)"",(string)"'"+sPrefix+"'"+",false,"+"'"+""+"'",(short)0});
         GridhomemodulessdtsColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
         GridhomemodulessdtsRow.AddRenderProperties(GridhomemodulessdtsColumn);
         GridhomemodulessdtsRow.AddColumnProperties("div_end", -1, isAjaxCallMode( ), new Object[] {(string)"left",(string)"top",(string)"div"});
         GridhomemodulessdtsColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
         GridhomemodulessdtsRow.AddRenderProperties(GridhomemodulessdtsColumn);
         if ( GridhomemodulessdtsContainer.GetWrapped() == 1 )
         {
            GridhomemodulessdtsContainer.CloseTag("cell");
         }
         if ( GridhomemodulessdtsContainer.GetWrapped() == 1 )
         {
            GridhomemodulessdtsContainer.CloseTag("row");
         }
         if ( GridhomemodulessdtsContainer.GetWrapped() == 1 )
         {
            GridhomemodulessdtsContainer.CloseTag("table");
         }
         /* End of table */
         GridhomemodulessdtsRow.AddColumnProperties("div_end", -1, isAjaxCallMode( ), new Object[] {(string)"left",(string)"top",(string)"div"});
         GridhomemodulessdtsColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
         GridhomemodulessdtsRow.AddRenderProperties(GridhomemodulessdtsColumn);
         /* Div Control */
         GridhomemodulessdtsRow.AddColumnProperties("div_start", -1, isAjaxCallMode( ), new Object[] {(string)"",(short)1,(short)0,(string)"px",(short)0,(string)"px",(string)"",(string)"left",(string)"top",(string)"",(string)"flex-grow:1;",(string)"div"});
         GridhomemodulessdtsColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
         GridhomemodulessdtsRow.AddRenderProperties(GridhomemodulessdtsColumn);
         /* Div Control */
         GridhomemodulessdtsRow.AddColumnProperties("div_start", -1, isAjaxCallMode( ), new Object[] {(string)divTableoptioniconandtitle_Internalname+"_"+sGXsfl_12_idx,(int)divTableoptioniconandtitle_Visible,(short)0,(string)"px",(short)0,(string)"px",(string)divTableoptioniconandtitle_Class,(string)"left",(string)"top",(string)"",(string)"",(string)"div"});
         GridhomemodulessdtsColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
         GridhomemodulessdtsRow.AddRenderProperties(GridhomemodulessdtsColumn);
         /* Div Control */
         GridhomemodulessdtsRow.AddColumnProperties("div_start", -1, isAjaxCallMode( ), new Object[] {(string)"",(short)1,(short)0,(string)"px",(short)0,(string)"px",(string)"row",(string)"left",(string)"top",(string)"",(string)"",(string)"div"});
         GridhomemodulessdtsColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
         GridhomemodulessdtsRow.AddRenderProperties(GridhomemodulessdtsColumn);
         /* Div Control */
         GridhomemodulessdtsRow.AddColumnProperties("div_start", -1, isAjaxCallMode( ), new Object[] {(string)"",(short)1,(short)0,(string)"px",(short)0,(string)"px",(string)"col-xs-12",(string)"Center",(string)"top",(string)"",(string)"",(string)"div"});
         GridhomemodulessdtsColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
         GridhomemodulessdtsRow.AddRenderProperties(GridhomemodulessdtsColumn);
         /* Text block */
         GridhomemodulessdtsRow.AddColumnProperties("label", 1, isAjaxCallMode( ), new Object[] {(string)lblOptionicon_Internalname,(string)lblOptionicon_Caption,(string)"",(string)"",(string)lblOptionicon_Jsonclick,(string)"'"+sPrefix+"'"+",false,"+"'"+""+"'",(string)"",(string)"TextBlock",(short)0,(string)"",(short)1,(short)1,(short)0,(short)2});
         GridhomemodulessdtsColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
         GridhomemodulessdtsRow.AddRenderProperties(GridhomemodulessdtsColumn);
         GridhomemodulessdtsRow.AddColumnProperties("div_end", -1, isAjaxCallMode( ), new Object[] {(string)"Center",(string)"top",(string)"div"});
         GridhomemodulessdtsColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
         GridhomemodulessdtsRow.AddRenderProperties(GridhomemodulessdtsColumn);
         GridhomemodulessdtsRow.AddColumnProperties("div_end", -1, isAjaxCallMode( ), new Object[] {(string)"left",(string)"top",(string)"div"});
         GridhomemodulessdtsColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
         GridhomemodulessdtsRow.AddRenderProperties(GridhomemodulessdtsColumn);
         /* Div Control */
         GridhomemodulessdtsRow.AddColumnProperties("div_start", -1, isAjaxCallMode( ), new Object[] {(string)"",(short)1,(short)0,(string)"px",(short)0,(string)"px",(string)"row",(string)"left",(string)"top",(string)"",(string)"",(string)"div"});
         GridhomemodulessdtsColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
         GridhomemodulessdtsRow.AddRenderProperties(GridhomemodulessdtsColumn);
         /* Div Control */
         GridhomemodulessdtsRow.AddColumnProperties("div_start", -1, isAjaxCallMode( ), new Object[] {(string)"",(short)1,(short)0,(string)"px",(short)0,(string)"px",(string)"col-xs-12 AttributeCardsMenuTitleCell",(string)"Center",(string)"top",(string)"",(string)"",(string)"div"});
         GridhomemodulessdtsColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
         GridhomemodulessdtsRow.AddRenderProperties(GridhomemodulessdtsColumn);
         /* Div Control */
         GridhomemodulessdtsRow.AddColumnProperties("div_start", -1, isAjaxCallMode( ), new Object[] {(string)"",(short)1,(short)0,(string)"px",(short)0,(string)"px",(string)" gx-attribute",(string)"left",(string)"top",(string)"",(string)"",(string)"div"});
         GridhomemodulessdtsColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
         GridhomemodulessdtsRow.AddRenderProperties(GridhomemodulessdtsColumn);
         /* Attribute/Variable Label */
         GridhomemodulessdtsRow.AddColumnProperties("html_label", -1, isAjaxCallMode( ), new Object[] {(string)edtavOptiontitle_Internalname,(string)"Option Title",(string)"col-sm-3 AttributeCardsMenuTitleLabel",(short)0,(bool)true,(string)""});
         GridhomemodulessdtsColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
         GridhomemodulessdtsRow.AddRenderProperties(GridhomemodulessdtsColumn);
         /* Single line edit */
         ROClassString = "AttributeCardsMenuTitle";
         GridhomemodulessdtsRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtavOptiontitle_Internalname,(string)AV7OptionTitle,(string)"",(string)"",(string)"'"+sPrefix+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtavOptiontitle_Jsonclick,(short)0,(string)"AttributeCardsMenuTitle",(string)"",(string)ROClassString,(string)"",(string)"",(short)1,(int)edtavOptiontitle_Enabled,(short)0,(string)"text",(string)"",(short)40,(string)"chr",(short)1,(string)"row",(short)40,(short)0,(short)0,(short)12,(short)1,(short)-1,(short)-1,(bool)true,(string)"",(string)"left",(bool)true,(string)""});
         GridhomemodulessdtsColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
         GridhomemodulessdtsRow.AddRenderProperties(GridhomemodulessdtsColumn);
         GridhomemodulessdtsRow.AddColumnProperties("div_end", -1, isAjaxCallMode( ), new Object[] {(string)"left",(string)"top",(string)"div"});
         GridhomemodulessdtsColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
         GridhomemodulessdtsRow.AddRenderProperties(GridhomemodulessdtsColumn);
         GridhomemodulessdtsRow.AddColumnProperties("div_end", -1, isAjaxCallMode( ), new Object[] {(string)"Center",(string)"top",(string)"div"});
         GridhomemodulessdtsColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
         GridhomemodulessdtsRow.AddRenderProperties(GridhomemodulessdtsColumn);
         GridhomemodulessdtsRow.AddColumnProperties("div_end", -1, isAjaxCallMode( ), new Object[] {(string)"left",(string)"top",(string)"div"});
         GridhomemodulessdtsColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
         GridhomemodulessdtsRow.AddRenderProperties(GridhomemodulessdtsColumn);
         GridhomemodulessdtsRow.AddColumnProperties("div_end", -1, isAjaxCallMode( ), new Object[] {(string)"left",(string)"top",(string)"div"});
         GridhomemodulessdtsColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
         GridhomemodulessdtsRow.AddRenderProperties(GridhomemodulessdtsColumn);
         GridhomemodulessdtsRow.AddColumnProperties("div_end", -1, isAjaxCallMode( ), new Object[] {(string)"left",(string)"top",(string)"div"});
         GridhomemodulessdtsColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
         GridhomemodulessdtsRow.AddRenderProperties(GridhomemodulessdtsColumn);
         /* Div Control */
         GridhomemodulessdtsRow.AddColumnProperties("div_start", -1, isAjaxCallMode( ), new Object[] {(string)"",(short)1,(short)0,(string)"px",(short)0,(string)"px",(string)"",(string)"left",(string)"top",(string)"",(string)"flex-grow:1;",(string)"div"});
         GridhomemodulessdtsColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
         GridhomemodulessdtsRow.AddRenderProperties(GridhomemodulessdtsColumn);
         /* Div Control */
         GridhomemodulessdtsRow.AddColumnProperties("div_start", -1, isAjaxCallMode( ), new Object[] {(string)divTableoptionwc_Internalname+"_"+sGXsfl_12_idx,(int)divTableoptionwc_Visible,(short)0,(string)"px",(short)0,(string)"px",(string)divTableoptionwc_Class,(string)"left",(string)"top",(string)"",(string)"",(string)"div"});
         GridhomemodulessdtsColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
         GridhomemodulessdtsRow.AddRenderProperties(GridhomemodulessdtsColumn);
         /* Div Control */
         GridhomemodulessdtsRow.AddColumnProperties("div_start", -1, isAjaxCallMode( ), new Object[] {(string)"",(short)1,(short)0,(string)"px",(short)0,(string)"px",(string)"row",(string)"left",(string)"top",(string)"",(string)"",(string)"div"});
         GridhomemodulessdtsColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
         GridhomemodulessdtsRow.AddRenderProperties(GridhomemodulessdtsColumn);
         /* Div Control */
         GridhomemodulessdtsRow.AddColumnProperties("div_start", -1, isAjaxCallMode( ), new Object[] {(string)"",(short)1,(short)0,(string)"px",(short)0,(string)"px",(string)"col-xs-12",(string)"left",(string)"top",(string)"",(string)"",(string)"div"});
         GridhomemodulessdtsColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
         GridhomemodulessdtsRow.AddRenderProperties(GridhomemodulessdtsColumn);
         /* WebComponent */
         GxWebStd.gx_hidden_field( context, sPrefix+"W0033"+sGXsfl_12_idx, StringUtil.RTrim( WebComp_Wc_Component));
         context.WriteHtmlText( "<div") ;
         GxWebStd.ClassAttribute( context, "gxwebcomponent"+" gxwebcomponent-loading");
         context.WriteHtmlText( " id=\""+sPrefix+"gxHTMLWrpW0033"+sGXsfl_12_idx+"\""+"") ;
         context.WriteHtmlText( ">") ;
         if ( bGXsfl_12_Refreshing )
         {
            if ( StringUtil.Len( WebComp_Wc_Component) != 0 )
            {
               if ( ! context.isAjaxRequest( ) || ( StringUtil.StringSearch( sPrefix+"W0033"+sGXsfl_12_idx, cgiGet( "_EventName"), 1) != 0 ) )
               {
                  if ( 1 != 0 )
                  {
                     if ( StringUtil.Len( WebComp_Wc_Component) != 0 )
                     {
                        WebComp_Wc.componentstart();
                     }
                  }
               }
               if ( ! context.isAjaxRequest( ) || ( StringUtil.StrCmp(StringUtil.Lower( OldWc), StringUtil.Lower( WebComp_Wc_Component)) != 0 ) )
               {
                  context.httpAjaxContext.ajax_rspStartCmp(sPrefix+"gxHTMLWrpW0033"+sGXsfl_12_idx);
               }
               WebComp_Wc.componentdraw();
               if ( ! context.isAjaxRequest( ) || ( StringUtil.StrCmp(StringUtil.Lower( OldWc), StringUtil.Lower( WebComp_Wc_Component)) != 0 ) )
               {
                  context.httpAjaxContext.ajax_rspEndCmp();
               }
            }
         }
         context.WriteHtmlText( "</div>") ;
         WebComp_Wc_Component = "";
         WebComp_Wc.componentjscripts();
         GridhomemodulessdtsRow.AddColumnProperties("webcomp", -1, isAjaxCallMode( ), new Object[] {(string)"Wc"});
         GridhomemodulessdtsColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
         GridhomemodulessdtsRow.AddRenderProperties(GridhomemodulessdtsColumn);
         GridhomemodulessdtsRow.AddColumnProperties("div_end", -1, isAjaxCallMode( ), new Object[] {(string)"left",(string)"top",(string)"div"});
         GridhomemodulessdtsColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
         GridhomemodulessdtsRow.AddRenderProperties(GridhomemodulessdtsColumn);
         GridhomemodulessdtsRow.AddColumnProperties("div_end", -1, isAjaxCallMode( ), new Object[] {(string)"left",(string)"top",(string)"div"});
         GridhomemodulessdtsColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
         GridhomemodulessdtsRow.AddRenderProperties(GridhomemodulessdtsColumn);
         GridhomemodulessdtsRow.AddColumnProperties("div_end", -1, isAjaxCallMode( ), new Object[] {(string)"left",(string)"top",(string)"div"});
         GridhomemodulessdtsColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
         GridhomemodulessdtsRow.AddRenderProperties(GridhomemodulessdtsColumn);
         GridhomemodulessdtsRow.AddColumnProperties("div_end", -1, isAjaxCallMode( ), new Object[] {(string)"left",(string)"top",(string)"div"});
         GridhomemodulessdtsColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
         GridhomemodulessdtsRow.AddRenderProperties(GridhomemodulessdtsColumn);
         GridhomemodulessdtsRow.AddColumnProperties("div_end", -1, isAjaxCallMode( ), new Object[] {(string)"left",(string)"top",(string)"div"});
         GridhomemodulessdtsColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
         GridhomemodulessdtsRow.AddRenderProperties(GridhomemodulessdtsColumn);
         send_integrity_lvl_hashes0X2( ) ;
         /* End of Columns property logic. */
         GridhomemodulessdtsContainer.AddRow(GridhomemodulessdtsRow);
         nGXsfl_12_idx = ((subGridhomemodulessdts_Islastpage==1)&&(nGXsfl_12_idx+1>subGridhomemodulessdts_fnc_Recordsperpage( )) ? 1 : nGXsfl_12_idx+1);
         sGXsfl_12_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_12_idx), 4, 0), 4, "0");
         SubsflControlProps_122( ) ;
         /* End function sendrow_122 */
      }

      protected void init_web_controls( )
      {
         /* End function init_web_controls */
      }

      protected void init_default_properties( )
      {
         edtavOptionlink_Internalname = sPrefix+"vOPTIONLINK";
         tblUnnamedtablecontentfsgridhomemodulessdts_Internalname = sPrefix+"UNNAMEDTABLECONTENTFSGRIDHOMEMODULESSDTS";
         lblOptionicon_Internalname = sPrefix+"OPTIONICON";
         edtavOptiontitle_Internalname = sPrefix+"vOPTIONTITLE";
         divTableoptioniconandtitle_Internalname = sPrefix+"TABLEOPTIONICONANDTITLE";
         divTableoptionwc_Internalname = sPrefix+"TABLEOPTIONWC";
         divUnnamedtablefsgridhomemodulessdts_Internalname = sPrefix+"UNNAMEDTABLEFSGRIDHOMEMODULESSDTS";
         divTablecontent_Internalname = sPrefix+"TABLECONTENT";
         divTablemain_Internalname = sPrefix+"TABLEMAIN";
         divLayoutmaintable_Internalname = sPrefix+"LAYOUTMAINTABLE";
         Form.Internalname = sPrefix+"FORM";
         subGridhomemodulessdts_Internalname = sPrefix+"GRIDHOMEMODULESSDTS";
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
         divTableoptionwc_Visible = 1;
         edtavOptiontitle_Jsonclick = "";
         lblOptionicon_Caption = "<i class='CardsMenuIcon fa fa-home' style='font-size: 40px'></i>";
         divTableoptioniconandtitle_Visible = 1;
         divTableoptionwc_Class = "TableCardsMenu Invisible";
         divTableoptioniconandtitle_Class = "TableCardsMenu";
         subGridhomemodulessdts_Allowcollapsing = 0;
         edtavOptiontitle_Enabled = 0;
         lblOptionicon_Caption = "<i class='CardsMenuIcon fa fa-home' style='font-size: 40px'></i>";
         subGridhomemodulessdts_Backcolorstyle = 0;
         subGridhomemodulessdts_Flexwrap = "wrap";
         subGridhomemodulessdts_Class = "FreeStyleGrid";
         edtavOptionlink_Visible = 1;
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
         setEventMetadata("REFRESH","{handler:'Refresh',iparms:[{av:'GRIDHOMEMODULESSDTS_nFirstRecordOnPage'},{av:'GRIDHOMEMODULESSDTS_nEOF'},{av:'edtavOptionlink_Visible',ctrl:'vOPTIONLINK',prop:'Visible'},{av:'sPrefix'},{av:'AV5HomeModulesSDT',fld:'vHOMEMODULESSDT',pic:'',hsh:true},{av:'AV9WCLink',fld:'vWCLINK',pic:'',hsh:true}]");
         setEventMetadata("REFRESH",",oparms:[]}");
         setEventMetadata("GRIDHOMEMODULESSDTS.LOAD","{handler:'E120X2',iparms:[{av:'AV5HomeModulesSDT',fld:'vHOMEMODULESSDT',pic:'',hsh:true},{av:'AV9WCLink',fld:'vWCLINK',pic:'',hsh:true}]");
         setEventMetadata("GRIDHOMEMODULESSDTS.LOAD",",oparms:[{av:'AV7OptionTitle',fld:'vOPTIONTITLE',pic:''},{av:'lblOptionicon_Caption',ctrl:'OPTIONICON',prop:'Caption'},{av:'divTableoptioniconandtitle_Class',ctrl:'TABLEOPTIONICONANDTITLE',prop:'Class'},{av:'divTableoptionwc_Class',ctrl:'TABLEOPTIONWC',prop:'Class'},{av:'AV9WCLink',fld:'vWCLINK',pic:'',hsh:true},{ctrl:'WC'},{av:'divTableoptioniconandtitle_Visible',ctrl:'TABLEOPTIONICONANDTITLE',prop:'Visible'},{av:'divTableoptionwc_Visible',ctrl:'TABLEOPTIONWC',prop:'Visible'},{av:'AV6OptionLink',fld:'vOPTIONLINK',pic:''}]}");
         setEventMetadata("NULL","{handler:'Validv_Optiontitle',iparms:[]");
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
         AV5HomeModulesSDT = new GXBaseCollection<GeneXus.Programs.wwpbaseobjects.SdtHomeModulesSDT_HomeModulesSDTItem>( context, "HomeModulesSDTItem", "SIGERP_ADVANCED");
         AV9WCLink = "";
         sDynURL = "";
         FormProcess = "";
         bodyStyle = "";
         GXKey = "";
         GX_FocusControl = "";
         GridhomemodulessdtsContainer = new GXWebGrid( context);
         sStyleString = "";
         subGridhomemodulessdts_Header = "";
         GridhomemodulessdtsColumn = new GXWebColumn();
         AV6OptionLink = "";
         AV7OptionTitle = "";
         Form = new GXWebForm();
         sXEvt = "";
         sEvt = "";
         EvtGridId = "";
         EvtRowId = "";
         sEvtType = "";
         OldWc = "";
         sCmpCtrl = "";
         WebComp_GX_Process_Component = "";
         WebComp_Wc_Component = "";
         AV8HomeModulesSDTItem = new GeneXus.Programs.wwpbaseobjects.SdtHomeModulesSDT_HomeModulesSDTItem(context);
         GXEncryptionTmp = "";
         GridhomemodulessdtsRow = new GXWebRow();
         BackMsgLst = new msglist();
         LclMsgLst = new msglist();
         subGridhomemodulessdts_Linesclass = "";
         ClassString = "";
         StyleString = "";
         lblOptionicon_Jsonclick = "";
         ROClassString = "";
         WebComp_GX_Process = new GeneXus.Http.GXNullWebComponent();
         WebComp_Wc = new GeneXus.Http.GXNullWebComponent();
         /* GeneXus formulas. */
         context.Gx_err = 0;
         edtavOptiontitle_Enabled = 0;
      }

      private short nGotPars ;
      private short GxWebError ;
      private short nDynComponent ;
      private short initialized ;
      private short wbEnd ;
      private short wbStart ;
      private short subGridhomemodulessdts_Backcolorstyle ;
      private short subGridhomemodulessdts_Allowselection ;
      private short subGridhomemodulessdts_Allowhovering ;
      private short subGridhomemodulessdts_Allowcollapsing ;
      private short subGridhomemodulessdts_Collapsed ;
      private short nDraw ;
      private short nDoneStart ;
      private short nCmpId ;
      private short nDonePA ;
      private short nGXWrapped ;
      private short subGridhomemodulessdts_Backstyle ;
      private short GRIDHOMEMODULESSDTS_nEOF ;
      private int edtavOptionlink_Visible ;
      private int nRC_GXsfl_12 ;
      private int nGXsfl_12_idx=1 ;
      private int edtavOptiontitle_Enabled ;
      private int subGridhomemodulessdts_Selectedindex ;
      private int subGridhomemodulessdts_Selectioncolor ;
      private int subGridhomemodulessdts_Hoveringcolor ;
      private int AV13GXV1 ;
      private int nGXsfl_12_webc_idx=0 ;
      private int subGridhomemodulessdts_Islastpage ;
      private int divTableoptioniconandtitle_Visible ;
      private int divTableoptionwc_Visible ;
      private int idxLst ;
      private int subGridhomemodulessdts_Backcolor ;
      private int subGridhomemodulessdts_Allbackcolor ;
      private long GRIDHOMEMODULESSDTS_nCurrentRecord ;
      private long GRIDHOMEMODULESSDTS_nFirstRecordOnPage ;
      private string gxfirstwebparm ;
      private string gxfirstwebparm_bkp ;
      private string sPrefix ;
      private string sCompPrefix ;
      private string sSFPrefix ;
      private string sGXsfl_12_idx="0001" ;
      private string edtavOptionlink_Internalname ;
      private string edtavOptiontitle_Internalname ;
      private string sDynURL ;
      private string FormProcess ;
      private string bodyStyle ;
      private string GXKey ;
      private string subGridhomemodulessdts_Class ;
      private string subGridhomemodulessdts_Flexwrap ;
      private string GX_FocusControl ;
      private string divLayoutmaintable_Internalname ;
      private string divTablemain_Internalname ;
      private string divTablecontent_Internalname ;
      private string sStyleString ;
      private string subGridhomemodulessdts_Internalname ;
      private string subGridhomemodulessdts_Header ;
      private string lblOptionicon_Caption ;
      private string sXEvt ;
      private string sEvt ;
      private string EvtGridId ;
      private string EvtRowId ;
      private string sEvtType ;
      private string OldWc ;
      private string sCmpCtrl ;
      private string WebComp_GX_Process_Component ;
      private string WebCompHandler="" ;
      private string WebComp_Wc_Component ;
      private string divTableoptioniconandtitle_Class ;
      private string divTableoptioniconandtitle_Internalname ;
      private string divTableoptionwc_Internalname ;
      private string divTableoptionwc_Class ;
      private string GXEncryptionTmp ;
      private string lblOptionicon_Internalname ;
      private string sGXsfl_12_fel_idx="0001" ;
      private string subGridhomemodulessdts_Linesclass ;
      private string divUnnamedtablefsgridhomemodulessdts_Internalname ;
      private string tblUnnamedtablecontentfsgridhomemodulessdts_Internalname ;
      private string ClassString ;
      private string StyleString ;
      private string lblOptionicon_Jsonclick ;
      private string ROClassString ;
      private string edtavOptiontitle_Jsonclick ;
      private bool entryPointCalled ;
      private bool toggleJsOutput ;
      private bool bGXsfl_12_Refreshing=false ;
      private bool wbLoad ;
      private bool Rfr0gs ;
      private bool wbErr ;
      private bool gxdyncontrolsrefreshing ;
      private bool returnInSub ;
      private bool bDynCreated_Wc ;
      private string AV9WCLink ;
      private string AV6OptionLink ;
      private string AV7OptionTitle ;
      private GXWebComponent WebComp_Wc ;
      private GXWebGrid GridhomemodulessdtsContainer ;
      private GXWebRow GridhomemodulessdtsRow ;
      private GXWebColumn GridhomemodulessdtsColumn ;
      private GXWebForm Form ;
      private IGxDataStore dsDataStore2 ;
      private IGxDataStore dsDefault ;
      private GXWebComponent WebComp_GX_Process ;
      private msglist BackMsgLst ;
      private msglist LclMsgLst ;
      private GXBaseCollection<GeneXus.Programs.wwpbaseobjects.SdtHomeModulesSDT_HomeModulesSDTItem> AV5HomeModulesSDT ;
      private GeneXus.Programs.wwpbaseobjects.SdtHomeModulesSDT_HomeModulesSDTItem AV8HomeModulesSDTItem ;
   }

}
