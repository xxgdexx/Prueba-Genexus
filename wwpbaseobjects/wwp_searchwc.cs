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
   public class wwp_searchwc : GXWebComponent
   {
      public wwp_searchwc( )
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

      public wwp_searchwc( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsDataStore2 = context.GetDataStore("DataStore2");
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( string aP0_SearchText )
      {
         this.AV22SearchText = aP0_SearchText;
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
               gxfirstwebparm = GetFirstPar( "SearchText");
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
                  AV22SearchText = GetPar( "SearchText");
                  AssignAttri(sPrefix, false, "AV22SearchText", AV22SearchText);
                  setjustcreated();
                  componentprepare(new Object[] {(string)sCompPrefix,(string)sSFPrefix,(string)AV22SearchText});
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
                  gxfirstwebparm = GetFirstPar( "SearchText");
               }
               else if ( StringUtil.StrCmp(gxfirstwebparm, "gxfullajaxEvt") == 0 )
               {
                  if ( ! IsValidAjaxCall( true) )
                  {
                     GxWebError = 1;
                     return  ;
                  }
                  gxfirstwebparm = GetFirstPar( "SearchText");
               }
               else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxNewRow_"+"Fsresults") == 0 )
               {
                  nRC_GXsfl_29 = (int)(NumberUtil.Val( GetPar( "nRC_GXsfl_29"), "."));
                  nGXsfl_29_idx = (int)(NumberUtil.Val( GetPar( "nGXsfl_29_idx"), "."));
                  sGXsfl_29_idx = GetPar( "sGXsfl_29_idx");
                  sPrefix = GetPar( "sPrefix");
                  edtavUrl_Visible = (int)(NumberUtil.Val( GetNextPar( ), "."));
                  AssignProp(sPrefix, false, edtavUrl_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavUrl_Visible), 5, 0), !bGXsfl_29_Refreshing);
                  setAjaxCallMode();
                  if ( ! IsValidAjaxCall( true) )
                  {
                     GxWebError = 1;
                     return  ;
                  }
                  gxnrFsresults_newrow( ) ;
                  return  ;
               }
               else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxGridRefresh_"+"Fsresults") == 0 )
               {
                  edtavUrl_Visible = (int)(NumberUtil.Val( GetNextPar( ), "."));
                  AssignProp(sPrefix, false, edtavUrl_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavUrl_Visible), 5, 0), !bGXsfl_29_Refreshing);
                  ajax_req_read_hidden_sdt(GetNextPar( ), AV26WWP_SearchResults);
                  sPrefix = GetPar( "sPrefix");
                  init_default_properties( ) ;
                  setAjaxCallMode();
                  if ( ! IsValidAjaxCall( true) )
                  {
                     GxWebError = 1;
                     return  ;
                  }
                  gxgrFsresults_refresh( AV26WWP_SearchResults, sPrefix) ;
                  AddString( context.getJSONResponse( )) ;
                  return  ;
               }
               else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxNewRow_"+"Fsresultcategories") == 0 )
               {
                  nRC_GXsfl_21 = (int)(NumberUtil.Val( GetPar( "nRC_GXsfl_21"), "."));
                  nGXsfl_21_idx = (int)(NumberUtil.Val( GetPar( "nGXsfl_21_idx"), "."));
                  sGXsfl_21_idx = GetPar( "sGXsfl_21_idx");
                  sPrefix = GetPar( "sPrefix");
                  setAjaxCallMode();
                  if ( ! IsValidAjaxCall( true) )
                  {
                     GxWebError = 1;
                     return  ;
                  }
                  gxnrFsresultcategories_newrow( ) ;
                  return  ;
               }
               else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxGridRefresh_"+"Fsresultcategories") == 0 )
               {
                  ajax_req_read_hidden_sdt(GetNextPar( ), AV26WWP_SearchResults);
                  sPrefix = GetPar( "sPrefix");
                  init_default_properties( ) ;
                  setAjaxCallMode();
                  if ( ! IsValidAjaxCall( true) )
                  {
                     GxWebError = 1;
                     return  ;
                  }
                  gxgrFsresultcategories_refresh( AV26WWP_SearchResults, sPrefix) ;
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
            PA3I2( ) ;
            if ( ( GxWebError == 0 ) && ! isAjaxCallMode( ) )
            {
               /* GeneXus formulas. */
               context.Gx_err = 0;
               edtavWwp_searchresults__categoryname_Enabled = 0;
               AssignProp(sPrefix, false, edtavWwp_searchresults__categoryname_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavWwp_searchresults__categoryname_Enabled), 5, 0), !bGXsfl_21_Refreshing);
               edtavDisplaytype1_title_Enabled = 0;
               AssignProp(sPrefix, false, edtavDisplaytype1_title_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavDisplaytype1_title_Enabled), 5, 0), !bGXsfl_29_Refreshing);
               edtavDisplaytype2_title_Enabled = 0;
               AssignProp(sPrefix, false, edtavDisplaytype2_title_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavDisplaytype2_title_Enabled), 5, 0), !bGXsfl_29_Refreshing);
               edtavDisplaytype3_title_Enabled = 0;
               AssignProp(sPrefix, false, edtavDisplaytype3_title_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavDisplaytype3_title_Enabled), 5, 0), !bGXsfl_29_Refreshing);
               edtavDisplaytype3_subtitle_Enabled = 0;
               AssignProp(sPrefix, false, edtavDisplaytype3_subtitle_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavDisplaytype3_subtitle_Enabled), 5, 0), !bGXsfl_29_Refreshing);
               edtavDisplaytype4_title_Enabled = 0;
               AssignProp(sPrefix, false, edtavDisplaytype4_title_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavDisplaytype4_title_Enabled), 5, 0), !bGXsfl_29_Refreshing);
               edtavDisplaytype5_title_Enabled = 0;
               AssignProp(sPrefix, false, edtavDisplaytype5_title_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavDisplaytype5_title_Enabled), 5, 0), !bGXsfl_29_Refreshing);
               edtavDisplaytype5_subtitle_Enabled = 0;
               AssignProp(sPrefix, false, edtavDisplaytype5_subtitle_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavDisplaytype5_subtitle_Enabled), 5, 0), !bGXsfl_29_Refreshing);
               WS3I2( ) ;
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
            context.SendWebValue( "WWP_Search WC") ;
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
         context.AddJavascriptSource("gxcfg.js", "?202281816343430", false, true);
         if ( context.isSpaRequest( ) )
         {
            enableOutput();
         }
         context.AddJavascriptSource("UserControls/WWP_IconButtonRender.js", "", false, true);
         context.AddJavascriptSource("DVelop/Bootstrap/Shared/DVelopBootstrap.js", "", false, true);
         context.AddJavascriptSource("DVelop/Shared/WorkWithPlusCommon.js", "", false, true);
         context.AddJavascriptSource("DVelop/Bootstrap/DropDownOptions/BootstrapDropDownOptionsRender.js", "", false, true);
         context.AddJavascriptSource("UserControls/WWP_IconButtonRender.js", "", false, true);
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
            GXKey = Crypto.GetSiteKey( );
            GXEncryptionTmp = "wwpbaseobjects.wwp_searchwc.aspx"+UrlEncode(StringUtil.RTrim(AV22SearchText));
            context.WriteHtmlTextNl( "<form id=\"MAINFORM\" autocomplete=\"off\" name=\"MAINFORM\" method=\"post\" tabindex=-1  class=\"form-horizontal Form\" data-gx-class=\"form-horizontal Form\" novalidate action=\""+formatLink("wwpbaseobjects.wwp_searchwc.aspx") + "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey)+"\">") ;
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
         GxWebStd.gx_hidden_field( context, sPrefix+"gxhash_vWWP_SEARCHRESULTS", GetSecureSignedToken( sPrefix, AV26WWP_SearchResults, context));
         GXKey = Crypto.GetSiteKey( );
      }

      protected void SendCloseFormHiddens( )
      {
         /* Send hidden variables. */
         /* Send saved values. */
         send_integrity_footer_hashes( ) ;
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri(sPrefix, false, sPrefix+"Wwp_searchresults", AV26WWP_SearchResults);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt(sPrefix+"Wwp_searchresults", AV26WWP_SearchResults);
         }
         GxWebStd.gx_hidden_field( context, sPrefix+"gxhash_Wwp_searchresults", GetSecureSignedToken( sPrefix, AV26WWP_SearchResults, context));
         GxWebStd.gx_hidden_field( context, sPrefix+"nRC_GXsfl_21", StringUtil.LTrim( StringUtil.NToC( (decimal)(nRC_GXsfl_21), 8, 0, ".", "")));
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri(sPrefix, false, sPrefix+"vDDO_TITLESETTINGSICONS", AV9DDO_TitleSettingsIcons);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt(sPrefix+"vDDO_TITLESETTINGSICONS", AV9DDO_TitleSettingsIcons);
         }
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri(sPrefix, false, sPrefix+"vADVFILTERENTITIES_DATA", AV6AdvFilterEntities_Data);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt(sPrefix+"vADVFILTERENTITIES_DATA", AV6AdvFilterEntities_Data);
         }
         GxWebStd.gx_hidden_field( context, sPrefix+"wcpOAV22SearchText", wcpOAV22SearchText);
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri(sPrefix, false, sPrefix+"vWWP_SEARCHRESULTS", AV26WWP_SearchResults);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt(sPrefix+"vWWP_SEARCHRESULTS", AV26WWP_SearchResults);
         }
         GxWebStd.gx_hidden_field( context, sPrefix+"gxhash_vWWP_SEARCHRESULTS", GetSecureSignedToken( sPrefix, AV26WWP_SearchResults, context));
         GxWebStd.gx_hidden_field( context, sPrefix+"vSEARCHTEXT", AV22SearchText);
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri(sPrefix, false, sPrefix+"vADVFILTERENTITIES", AV5AdvFilterEntities);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt(sPrefix+"vADVFILTERENTITIES", AV5AdvFilterEntities);
         }
         GxWebStd.gx_hidden_field( context, sPrefix+"TABLEADVANCEDSEARCHCELL_Class", StringUtil.RTrim( divTableadvancedsearchcell_Class));
         GxWebStd.gx_hidden_field( context, sPrefix+"TABLESIMPLESEARCHCELL_Class", StringUtil.RTrim( divTablesimplesearchcell_Class));
         GxWebStd.gx_hidden_field( context, sPrefix+"COMBO_ADVFILTERENTITIES_Selectedvalue_get", StringUtil.RTrim( Combo_advfilterentities_Selectedvalue_get));
      }

      protected void RenderHtmlCloseForm3I2( )
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
         return "WWPBaseObjects.WWP_SearchWC" ;
      }

      public override string GetPgmdesc( )
      {
         return "WWP_Search WC" ;
      }

      protected void WB3I0( )
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
               GxWebStd.gx_hidden_field( context, sPrefix+"_CMPPGM", "wwpbaseobjects.wwp_searchwc.aspx");
               context.AddJavascriptSource("UserControls/WWP_IconButtonRender.js", "", false, true);
               context.AddJavascriptSource("DVelop/Bootstrap/Shared/DVelopBootstrap.js", "", false, true);
               context.AddJavascriptSource("DVelop/Shared/WorkWithPlusCommon.js", "", false, true);
               context.AddJavascriptSource("DVelop/Bootstrap/DropDownOptions/BootstrapDropDownOptionsRender.js", "", false, true);
               context.AddJavascriptSource("UserControls/WWP_IconButtonRender.js", "", false, true);
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
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 CloseSearchIconCell", "left", "top", "", "", "div");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblClosesearch_Internalname, "<i class=\"fa fa-times\"></i>", "", "", lblClosesearch_Jsonclick, "'"+sPrefix+"'"+",false,"+"'"+sPrefix+"E\\'DOCLOSESEARCH\\'."+"'", "", "TextBlock", 5, "", 1, 1, 0, 1, "HLP_WWPBaseObjects\\WWP_SearchWC.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divShowall_cell_Internalname, 1, 0, "px", 0, "px", divShowall_cell_Class, "left", "top", "", "", "div");
            /* User Defined Control */
            ucBtnshowall.SetProperty("BeforeIconClass", Btnshowall_Beforeiconclass);
            ucBtnshowall.SetProperty("Caption", Btnshowall_Caption);
            ucBtnshowall.SetProperty("Class", Btnshowall_Class);
            ucBtnshowall.Render(context, "wwp_iconbutton", Btnshowall_Internalname, sPrefix+"BTNSHOWALLContainer");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divTxtnoresultscell_Internalname, 1, 0, "px", 0, "px", divTxtnoresultscell_Class, "left", "top", "", "", "div");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblTxtnoresults_Internalname, lblTxtnoresults_Caption, "", "", lblTxtnoresults_Jsonclick, "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "TextBlockShowingOnly", 0, "", 1, 1, 0, 0, "HLP_WWPBaseObjects\\WWP_SearchWC.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divTablesimplesearchcell_Internalname, 1, 0, "px", 0, "px", divTablesimplesearchcell_Class, "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divTablesimplesearch_Internalname, 1, 0, "px", 0, "px", "", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divFsresultcategories_cell_Internalname, 1, 0, "px", 0, "px", divFsresultcategories_cell_Class, "left", "top", "", "", "div");
            /*  Grid Control  */
            FsresultcategoriesContainer.SetIsFreestyle(true);
            FsresultcategoriesContainer.SetWrapped(nGXWrapped);
            if ( FsresultcategoriesContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<div id=\""+sPrefix+"FsresultcategoriesContainer"+"DivS\" data-gxgridid=\"21\">") ;
               sStyleString = "";
               GxWebStd.gx_table_start( context, subFsresultcategories_Internalname, subFsresultcategories_Internalname, "", "FreeStyleGridMPSearch", 0, "", "", 1, 2, sStyleString, "", "", 0);
               FsresultcategoriesContainer.AddObjectProperty("GridName", "Fsresultcategories");
            }
            else
            {
               FsresultcategoriesContainer.AddObjectProperty("GridName", "Fsresultcategories");
               FsresultcategoriesContainer.AddObjectProperty("Header", subFsresultcategories_Header);
               FsresultcategoriesContainer.AddObjectProperty("Class", StringUtil.RTrim( "FreeStyleGridMPSearch"));
               FsresultcategoriesContainer.AddObjectProperty("Class", "FreeStyleGridMPSearch");
               FsresultcategoriesContainer.AddObjectProperty("Cellpadding", StringUtil.LTrim( StringUtil.NToC( (decimal)(1), 4, 0, ".", "")));
               FsresultcategoriesContainer.AddObjectProperty("Cellspacing", StringUtil.LTrim( StringUtil.NToC( (decimal)(2), 4, 0, ".", "")));
               FsresultcategoriesContainer.AddObjectProperty("Backcolorstyle", StringUtil.LTrim( StringUtil.NToC( (decimal)(subFsresultcategories_Backcolorstyle), 1, 0, ".", "")));
               FsresultcategoriesContainer.AddObjectProperty("CmpContext", sPrefix);
               FsresultcategoriesContainer.AddObjectProperty("InMasterPage", "false");
               FsresultcategoriesColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
               FsresultcategoriesContainer.AddColumnProperties(FsresultcategoriesColumn);
               FsresultcategoriesColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
               FsresultcategoriesContainer.AddColumnProperties(FsresultcategoriesColumn);
               FsresultcategoriesColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
               FsresultcategoriesContainer.AddColumnProperties(FsresultcategoriesColumn);
               FsresultcategoriesColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
               FsresultcategoriesContainer.AddColumnProperties(FsresultcategoriesColumn);
               FsresultcategoriesColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
               FsresultcategoriesColumn.AddObjectProperty("Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtavWwp_searchresults__categoryname_Enabled), 5, 0, ".", "")));
               FsresultcategoriesContainer.AddColumnProperties(FsresultcategoriesColumn);
               FsresultcategoriesColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
               FsresultcategoriesContainer.AddColumnProperties(FsresultcategoriesColumn);
               FsresultcategoriesColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
               FsresultcategoriesContainer.AddColumnProperties(FsresultcategoriesColumn);
               FsresultcategoriesColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
               FsresultcategoriesContainer.AddColumnProperties(FsresultcategoriesColumn);
               FsresultcategoriesColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
               FsresultcategoriesContainer.AddColumnProperties(FsresultcategoriesColumn);
               FsresultcategoriesColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
               FsresultcategoriesColumn.AddObjectProperty("Value", lblTxtshowingonly_Caption);
               FsresultcategoriesContainer.AddColumnProperties(FsresultcategoriesColumn);
               FsresultcategoriesContainer.AddObjectProperty("Selectedindex", StringUtil.LTrim( StringUtil.NToC( (decimal)(subFsresultcategories_Selectedindex), 4, 0, ".", "")));
               FsresultcategoriesContainer.AddObjectProperty("Allowselection", StringUtil.LTrim( StringUtil.NToC( (decimal)(subFsresultcategories_Allowselection), 1, 0, ".", "")));
               FsresultcategoriesContainer.AddObjectProperty("Selectioncolor", StringUtil.LTrim( StringUtil.NToC( (decimal)(subFsresultcategories_Selectioncolor), 9, 0, ".", "")));
               FsresultcategoriesContainer.AddObjectProperty("Allowhover", StringUtil.LTrim( StringUtil.NToC( (decimal)(subFsresultcategories_Allowhovering), 1, 0, ".", "")));
               FsresultcategoriesContainer.AddObjectProperty("Hovercolor", StringUtil.LTrim( StringUtil.NToC( (decimal)(subFsresultcategories_Hoveringcolor), 9, 0, ".", "")));
               FsresultcategoriesContainer.AddObjectProperty("Allowcollapsing", StringUtil.LTrim( StringUtil.NToC( (decimal)(subFsresultcategories_Allowcollapsing), 1, 0, ".", "")));
               FsresultcategoriesContainer.AddObjectProperty("Collapsed", StringUtil.LTrim( StringUtil.NToC( (decimal)(subFsresultcategories_Collapsed), 1, 0, ".", "")));
            }
         }
         if ( wbEnd == 21 )
         {
            wbEnd = 0;
            nRC_GXsfl_21 = (int)(nGXsfl_21_idx-1);
            if ( FsresultcategoriesContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "</table>") ;
               context.WriteHtmlText( "</div>") ;
            }
            else
            {
               AV30GXV1 = nGXsfl_21_idx;
               sStyleString = "";
               context.WriteHtmlText( "<div id=\""+sPrefix+"FsresultcategoriesContainer"+"Div\" "+sStyleString+">"+"</div>") ;
               context.httpAjaxContext.ajax_rsp_assign_grid(sPrefix+"_"+"Fsresultcategories", FsresultcategoriesContainer);
               if ( ! isAjaxCallMode( ) && ! context.isSpaRequest( ) )
               {
                  GxWebStd.gx_hidden_field( context, sPrefix+"FsresultcategoriesContainerData", FsresultcategoriesContainer.ToJavascriptSource());
               }
               if ( context.isAjaxRequest( ) || context.isSpaRequest( ) )
               {
                  GxWebStd.gx_hidden_field( context, sPrefix+"FsresultcategoriesContainerData"+"V", FsresultcategoriesContainer.GridValuesHidden());
               }
               else
               {
                  context.WriteHtmlText( "<input type=\"hidden\" "+"name=\""+sPrefix+"FsresultcategoriesContainerData"+"V"+"\" value='"+FsresultcategoriesContainer.GridValuesHidden()+"'/>") ;
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
            GxWebStd.gx_div_start( context, divTableadvancedsearchcell_Internalname, 1, 0, "px", 0, "px", divTableadvancedsearchcell_Class, "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divTableadvancedsearch_Internalname, 1, 0, "px", 0, "px", "", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 DataContentCell", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtavAdvfiltertext_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavAdvfiltertext_Internalname, "Buscar", "col-sm-3 AttributeLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 94,'" + sPrefix + "',false,'" + sGXsfl_21_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavAdvfiltertext_Internalname, AV8AdvFilterText, StringUtil.RTrim( context.localUtil.Format( AV8AdvFilterText, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,94);\"", "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavAdvfiltertext_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtavAdvfiltertext_Enabled, 0, "text", "", 40, "chr", 1, "row", 40, 0, 0, 0, 1, -1, -1, true, "", "left", true, "", "HLP_WWPBaseObjects\\WWP_SearchWC.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 DataContentCell ExtendedComboCell", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divTablesplittedadvfilterentities_Internalname, 1, 0, "px", 0, "px", "Table", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-3 MergeLabelCell", "left", "top", "", "", "div");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblTextblockcombo_advfilterentities_Internalname, "Buscar en", "", "", lblTextblockcombo_advfilterentities_Jsonclick, "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "Label", 0, "", 1, 1, 0, 0, "HLP_WWPBaseObjects\\WWP_SearchWC.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-9", "left", "top", "", "", "div");
            /* User Defined Control */
            ucCombo_advfilterentities.SetProperty("Caption", Combo_advfilterentities_Caption);
            ucCombo_advfilterentities.SetProperty("Cls", Combo_advfilterentities_Cls);
            ucCombo_advfilterentities.SetProperty("AllowMultipleSelection", Combo_advfilterentities_Allowmultipleselection);
            ucCombo_advfilterentities.SetProperty("IncludeOnlySelectedOption", Combo_advfilterentities_Includeonlyselectedoption);
            ucCombo_advfilterentities.SetProperty("EmptyItem", Combo_advfilterentities_Emptyitem);
            ucCombo_advfilterentities.SetProperty("MultipleValuesType", Combo_advfilterentities_Multiplevaluestype);
            ucCombo_advfilterentities.SetProperty("DropDownOptionsTitleSettingsIcons", AV9DDO_TitleSettingsIcons);
            ucCombo_advfilterentities.SetProperty("DropDownOptionsData", AV6AdvFilterEntities_Data);
            ucCombo_advfilterentities.Render(context, "dvelop.gxbootstrap.ddoextendedcombo", Combo_advfilterentities_Internalname, sPrefix+"COMBO_ADVFILTERENTITIESContainer");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "Right", "top", "", "", "div");
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 105,'" + sPrefix + "',false,'',0)\"";
            ClassString = "ButtonMaterial";
            StyleString = "";
            GxWebStd.gx_button_ctrl( context, bttBtnbtnadvsearch_Internalname, "gx.evt.setGridEvt("+StringUtil.Str( (decimal)(21), 2, 0)+","+"null"+");", "Buscar", bttBtnbtnadvsearch_Jsonclick, 5, "Buscar", "", StyleString, ClassString, 1, 1, "standard", "'"+sPrefix+"'"+",false,"+"'"+sPrefix+"E\\'DOBTNADVSEARCH\\'."+"'", TempTags, "", context.GetButtonType( ), "HLP_WWPBaseObjects\\WWP_SearchWC.htm");
            GxWebStd.gx_div_end( context, "Right", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 BtnAdvancedSearchCell", "left", "top", "", "", "div");
            /* User Defined Control */
            ucBtnadvancedsearch.SetProperty("BeforeIconClass", Btnadvancedsearch_Beforeiconclass);
            ucBtnadvancedsearch.SetProperty("Caption", Btnadvancedsearch_Caption);
            ucBtnadvancedsearch.SetProperty("Class", Btnadvancedsearch_Class);
            ucBtnadvancedsearch.Render(context, "wwp_iconbutton", Btnadvancedsearch_Internalname, sPrefix+"BTNADVANCEDSEARCHContainer");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
         }
         if ( wbEnd == 21 )
         {
            wbEnd = 0;
            if ( isFullAjaxMode( ) )
            {
               if ( FsresultcategoriesContainer.GetWrapped() == 1 )
               {
                  context.WriteHtmlText( "</table>") ;
                  context.WriteHtmlText( "</div>") ;
               }
               else
               {
                  AV30GXV1 = nGXsfl_21_idx;
                  sStyleString = "";
                  context.WriteHtmlText( "<div id=\""+sPrefix+"FsresultcategoriesContainer"+"Div\" "+sStyleString+">"+"</div>") ;
                  context.httpAjaxContext.ajax_rsp_assign_grid(sPrefix+"_"+"Fsresultcategories", FsresultcategoriesContainer);
                  if ( ! isAjaxCallMode( ) && ! context.isSpaRequest( ) )
                  {
                     GxWebStd.gx_hidden_field( context, sPrefix+"FsresultcategoriesContainerData", FsresultcategoriesContainer.ToJavascriptSource());
                  }
                  if ( context.isAjaxRequest( ) || context.isSpaRequest( ) )
                  {
                     GxWebStd.gx_hidden_field( context, sPrefix+"FsresultcategoriesContainerData"+"V", FsresultcategoriesContainer.GridValuesHidden());
                  }
                  else
                  {
                     context.WriteHtmlText( "<input type=\"hidden\" "+"name=\""+sPrefix+"FsresultcategoriesContainerData"+"V"+"\" value='"+FsresultcategoriesContainer.GridValuesHidden()+"'/>") ;
                  }
               }
            }
         }
         if ( wbEnd == 29 )
         {
            wbEnd = 0;
            if ( isFullAjaxMode( ) )
            {
               if ( FsresultsContainer.GetWrapped() == 1 )
               {
                  context.WriteHtmlText( "</table>") ;
                  context.WriteHtmlText( "</div>") ;
               }
               else
               {
                  AV32GXV3 = nGXsfl_29_idx;
                  sStyleString = "";
                  context.WriteHtmlText( "<div id=\""+sPrefix+"FsresultsContainer"+"Div\" "+sStyleString+">"+"</div>") ;
                  context.httpAjaxContext.ajax_rsp_assign_grid(sPrefix+"_"+"Fsresults", FsresultsContainer);
                  if ( ! isAjaxCallMode( ) )
                  {
                     GxWebStd.gx_hidden_field( context, sPrefix+"FsresultsContainerData", FsresultsContainer.ToJavascriptSource());
                  }
                  if ( context.isAjaxRequest( ) || context.isSpaRequest( ) )
                  {
                     GxWebStd.gx_hidden_field( context, sPrefix+"FsresultsContainerData"+"V", FsresultsContainer.GridValuesHidden());
                  }
                  else
                  {
                     context.WriteHtmlText( "<input type=\"hidden\" "+"name=\""+sPrefix+"FsresultsContainerData"+"V"+"\" value='"+FsresultsContainer.GridValuesHidden()+"'/>") ;
                  }
               }
            }
         }
         wbLoad = true;
      }

      protected void START3I2( )
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
               Form.Meta.addItem("description", "WWP_Search WC", 0) ;
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
               STRUP3I0( ) ;
            }
         }
      }

      protected void WS3I2( )
      {
         START3I2( ) ;
         EVT3I2( ) ;
      }

      protected void EVT3I2( )
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
                                 STRUP3I0( ) ;
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
                           else if ( StringUtil.StrCmp(sEvt, "'DOCLOSESEARCH'") == 0 )
                           {
                              if ( ( StringUtil.Len( sPrefix) != 0 ) && ( nDoneStart == 0 ) )
                              {
                                 STRUP3I0( ) ;
                              }
                              if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
                              {
                                 context.wbHandled = 1;
                                 if ( ! wbErr )
                                 {
                                    dynload_actions( ) ;
                                    /* Execute user event: 'DoCloseSearch' */
                                    E113I2 ();
                                 }
                              }
                           }
                           else if ( StringUtil.StrCmp(sEvt, "'DOSHOWALL'") == 0 )
                           {
                              if ( ( StringUtil.Len( sPrefix) != 0 ) && ( nDoneStart == 0 ) )
                              {
                                 STRUP3I0( ) ;
                              }
                              if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
                              {
                                 context.wbHandled = 1;
                                 if ( ! wbErr )
                                 {
                                    dynload_actions( ) ;
                                    /* Execute user event: 'DoShowAll' */
                                    E123I2 ();
                                 }
                              }
                           }
                           else if ( StringUtil.StrCmp(sEvt, "'DOBTNADVSEARCH'") == 0 )
                           {
                              if ( ( StringUtil.Len( sPrefix) != 0 ) && ( nDoneStart == 0 ) )
                              {
                                 STRUP3I0( ) ;
                              }
                              if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
                              {
                                 context.wbHandled = 1;
                                 if ( ! wbErr )
                                 {
                                    dynload_actions( ) ;
                                    /* Execute user event: 'DoBtnAdvSearch' */
                                    E133I2 ();
                                 }
                              }
                           }
                           else if ( StringUtil.StrCmp(sEvt, "UNNAMEDTABLEFSFSRESULTS.CLICK") == 0 )
                           {
                              if ( ( StringUtil.Len( sPrefix) != 0 ) && ( nDoneStart == 0 ) )
                              {
                                 STRUP3I0( ) ;
                              }
                              if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
                              {
                                 context.wbHandled = 1;
                                 if ( ! wbErr )
                                 {
                                    dynload_actions( ) ;
                                    E143I2 ();
                                 }
                              }
                           }
                           else if ( StringUtil.StrCmp(sEvt, "LSCR") == 0 )
                           {
                              if ( ( StringUtil.Len( sPrefix) != 0 ) && ( nDoneStart == 0 ) )
                              {
                                 STRUP3I0( ) ;
                              }
                              if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
                              {
                                 context.wbHandled = 1;
                                 if ( ! wbErr )
                                 {
                                    dynload_actions( ) ;
                                    GX_FocusControl = edtavAdvfiltertext_Internalname;
                                    AssignAttri(sPrefix, false, "GX_FocusControl", GX_FocusControl);
                                 }
                              }
                              dynload_actions( ) ;
                           }
                        }
                        else
                        {
                           sEvtType = StringUtil.Right( sEvt, 4);
                           sEvt = StringUtil.Left( sEvt, (short)(StringUtil.Len( sEvt)-4));
                           if ( ( StringUtil.StrCmp(StringUtil.Left( sEvt, 5), "START") == 0 ) || ( StringUtil.StrCmp(StringUtil.Left( sEvt, 23), "FSRESULTCATEGORIES.LOAD") == 0 ) || ( StringUtil.StrCmp(StringUtil.Left( sEvt, 5), "ENTER") == 0 ) || ( StringUtil.StrCmp(StringUtil.Left( sEvt, 6), "CANCEL") == 0 ) || ( StringUtil.StrCmp(StringUtil.Left( sEvt, 14), "FSRESULTS.LOAD") == 0 ) || ( StringUtil.StrCmp(StringUtil.Left( sEvt, 29), "UNNAMEDTABLEFSFSRESULTS.CLICK") == 0 ) )
                           {
                              if ( ( StringUtil.Len( sPrefix) != 0 ) && ( nDoneStart == 0 ) )
                              {
                                 STRUP3I0( ) ;
                              }
                              nGXsfl_21_idx = (int)(NumberUtil.Val( sEvtType, "."));
                              sGXsfl_21_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_21_idx), 4, 0), 4, "0");
                              SubsflControlProps_212( ) ;
                              AV30GXV1 = nGXsfl_21_idx;
                              if ( ( AV26WWP_SearchResults.Count >= AV30GXV1 ) && ( AV30GXV1 > 0 ) )
                              {
                                 AV26WWP_SearchResults.CurrentItem = ((GeneXus.Programs.wwpbaseobjects.SdtWWP_SearchResults_WWP_SearchResultsItem)AV26WWP_SearchResults.Item(AV30GXV1));
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
                                          GX_FocusControl = edtavAdvfiltertext_Internalname;
                                          AssignAttri(sPrefix, false, "GX_FocusControl", GX_FocusControl);
                                          /* Execute user event: Start */
                                          E153I2 ();
                                       }
                                    }
                                 }
                                 else if ( StringUtil.StrCmp(sEvt, "FSRESULTCATEGORIES.LOAD") == 0 )
                                 {
                                    if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
                                    {
                                       context.wbHandled = 1;
                                       if ( ! wbErr )
                                       {
                                          dynload_actions( ) ;
                                          GX_FocusControl = edtavAdvfiltertext_Internalname;
                                          AssignAttri(sPrefix, false, "GX_FocusControl", GX_FocusControl);
                                          E163I2 ();
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
                                       STRUP3I0( ) ;
                                    }
                                    if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
                                    {
                                       context.wbHandled = 1;
                                       if ( ! wbErr )
                                       {
                                          dynload_actions( ) ;
                                          GX_FocusControl = edtavAdvfiltertext_Internalname;
                                          AssignAttri(sPrefix, false, "GX_FocusControl", GX_FocusControl);
                                       }
                                    }
                                 }
                              }
                              else
                              {
                                 sEvtType = StringUtil.Right( sEvt, 4);
                                 sEvt = StringUtil.Left( sEvt, (short)(StringUtil.Len( sEvt)-4));
                                 if ( ( StringUtil.StrCmp(StringUtil.Left( sEvt, 14), "FSRESULTS.LOAD") == 0 ) || ( StringUtil.StrCmp(StringUtil.Left( sEvt, 29), "UNNAMEDTABLEFSFSRESULTS.CLICK") == 0 ) )
                                 {
                                    if ( ( StringUtil.Len( sPrefix) != 0 ) && ( nDoneStart == 0 ) )
                                    {
                                       STRUP3I0( ) ;
                                    }
                                    nGXsfl_29_idx = (int)(NumberUtil.Val( sEvtType, "."));
                                    sGXsfl_29_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_29_idx), 4, 0), 4, "0") + sGXsfl_21_idx;
                                    SubsflControlProps_293( ) ;
                                    AV24Url = cgiGet( edtavUrl_Internalname);
                                    AssignAttri(sPrefix, false, edtavUrl_Internalname, AV24Url);
                                    AV10DisplayType1_Title = cgiGet( edtavDisplaytype1_title_Internalname);
                                    AssignAttri(sPrefix, false, edtavDisplaytype1_title_Internalname, AV10DisplayType1_Title);
                                    AV11DisplayType2_Title = cgiGet( edtavDisplaytype2_title_Internalname);
                                    AssignAttri(sPrefix, false, edtavDisplaytype2_title_Internalname, AV11DisplayType2_Title);
                                    AV13DisplayType3_Title = cgiGet( edtavDisplaytype3_title_Internalname);
                                    AssignAttri(sPrefix, false, edtavDisplaytype3_title_Internalname, AV13DisplayType3_Title);
                                    AV12DisplayType3_Subtitle = cgiGet( edtavDisplaytype3_subtitle_Internalname);
                                    AssignAttri(sPrefix, false, edtavDisplaytype3_subtitle_Internalname, AV12DisplayType3_Subtitle);
                                    AV14DisplayType4_Image = cgiGet( edtavDisplaytype4_image_Internalname);
                                    AssignProp(sPrefix, false, edtavDisplaytype4_image_Internalname, "Bitmap", (String.IsNullOrEmpty(StringUtil.RTrim( AV14DisplayType4_Image)) ? AV33Displaytype4_image_GXI : context.convertURL( context.PathToRelativeUrl( AV14DisplayType4_Image))), !bGXsfl_29_Refreshing);
                                    AssignProp(sPrefix, false, edtavDisplaytype4_image_Internalname, "SrcSet", context.GetImageSrcSet( AV14DisplayType4_Image), true);
                                    AV15DisplayType4_Title = cgiGet( edtavDisplaytype4_title_Internalname);
                                    AssignAttri(sPrefix, false, edtavDisplaytype4_title_Internalname, AV15DisplayType4_Title);
                                    AV17DisplayType5_Title = cgiGet( edtavDisplaytype5_title_Internalname);
                                    AssignAttri(sPrefix, false, edtavDisplaytype5_title_Internalname, AV17DisplayType5_Title);
                                    AV16DisplayType5_Subtitle = cgiGet( edtavDisplaytype5_subtitle_Internalname);
                                    AssignAttri(sPrefix, false, edtavDisplaytype5_subtitle_Internalname, AV16DisplayType5_Subtitle);
                                    sEvtType = StringUtil.Right( sEvt, 1);
                                    if ( StringUtil.StrCmp(sEvtType, ".") == 0 )
                                    {
                                       sEvt = StringUtil.Left( sEvt, (short)(StringUtil.Len( sEvt)-1));
                                       if ( StringUtil.StrCmp(sEvt, "FSRESULTS.LOAD") == 0 )
                                       {
                                          if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
                                          {
                                             context.wbHandled = 1;
                                             if ( ! wbErr )
                                             {
                                                dynload_actions( ) ;
                                                GX_FocusControl = edtavAdvfiltertext_Internalname;
                                                AssignAttri(sPrefix, false, "GX_FocusControl", GX_FocusControl);
                                                E173I3 ();
                                             }
                                          }
                                       }
                                       else if ( StringUtil.StrCmp(sEvt, "UNNAMEDTABLEFSFSRESULTS.CLICK") == 0 )
                                       {
                                          if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
                                          {
                                             context.wbHandled = 1;
                                             if ( ! wbErr )
                                             {
                                                dynload_actions( ) ;
                                                GX_FocusControl = edtavAdvfiltertext_Internalname;
                                                AssignAttri(sPrefix, false, "GX_FocusControl", GX_FocusControl);
                                                E143I2 ();
                                             }
                                          }
                                       }
                                       else if ( StringUtil.StrCmp(sEvt, "LSCR") == 0 )
                                       {
                                          if ( ( StringUtil.Len( sPrefix) != 0 ) && ( nDoneStart == 0 ) )
                                          {
                                             STRUP3I0( ) ;
                                          }
                                          if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
                                          {
                                             context.wbHandled = 1;
                                             if ( ! wbErr )
                                             {
                                                dynload_actions( ) ;
                                                GX_FocusControl = edtavAdvfiltertext_Internalname;
                                                AssignAttri(sPrefix, false, "GX_FocusControl", GX_FocusControl);
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
                        }
                     }
                     context.wbHandled = 1;
                  }
               }
            }
         }
      }

      protected void WE3I2( )
      {
         if ( ! GxWebStd.gx_redirect( context) )
         {
            Rfr0gs = true;
            Refresh( ) ;
            if ( ! GxWebStd.gx_redirect( context) )
            {
               RenderHtmlCloseForm3I2( ) ;
            }
         }
      }

      protected void PA3I2( )
      {
         if ( nDonePA == 0 )
         {
            if ( StringUtil.Len( sPrefix) != 0 )
            {
               initialize_properties( ) ;
            }
            GXKey = Crypto.GetSiteKey( );
            if ( StringUtil.Len( sPrefix) == 0 )
            {
               if ( ( StringUtil.StrCmp(context.GetRequestQueryString( ), "") != 0 ) && ( GxWebError == 0 ) && ! ( isAjaxCallMode( ) || isFullAjaxMode( ) ) )
               {
                  GXDecQS = UriDecrypt64( context.GetRequestQueryString( ), GXKey);
                  if ( ( StringUtil.StrCmp(StringUtil.Right( GXDecQS, 6), Crypto.CheckSum( StringUtil.Left( GXDecQS, (short)(StringUtil.Len( GXDecQS)-6)), 6)) == 0 ) && ( StringUtil.StrCmp(StringUtil.Substring( GXDecQS, 1, StringUtil.Len( "wwpbaseobjects.wwp_searchwc.aspx")), "wwpbaseobjects.wwp_searchwc.aspx") == 0 ) )
                  {
                     SetQueryString( StringUtil.Right( StringUtil.Left( GXDecQS, (short)(StringUtil.Len( GXDecQS)-6)), (short)(StringUtil.Len( StringUtil.Left( GXDecQS, (short)(StringUtil.Len( GXDecQS)-6)))-StringUtil.Len( "wwpbaseobjects.wwp_searchwc.aspx")))) ;
                  }
                  else
                  {
                     GxWebError = 1;
                     context.HttpContext.Response.StatusCode = 403;
                     context.WriteHtmlText( "<title>403 Forbidden</title>") ;
                     context.WriteHtmlText( "<h1>403 Forbidden</h1>") ;
                     context.WriteHtmlText( "<p /><hr />") ;
                     GXUtil.WriteLog("send_http_error_code " + 403.ToString());
                  }
               }
            }
            if ( ! ( isAjaxCallMode( ) || isFullAjaxMode( ) ) )
            {
               if ( StringUtil.Len( sPrefix) == 0 )
               {
                  if ( nGotPars == 0 )
                  {
                     entryPointCalled = false;
                     gxfirstwebparm = GetFirstPar( "SearchText");
                     toggleJsOutput = isJsOutputEnabled( );
                     if ( context.isSpaRequest( ) )
                     {
                        disableJsOutput();
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
            }
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
               GX_FocusControl = edtavAdvfiltertext_Internalname;
               AssignAttri(sPrefix, false, "GX_FocusControl", GX_FocusControl);
            }
            nDonePA = 1;
         }
      }

      protected void dynload_actions( )
      {
         /* End function dynload_actions */
      }

      protected void gxnrFsresultcategories_newrow( )
      {
         GxWebStd.set_html_headers( context, 0, "", "");
         SubsflControlProps_212( ) ;
         while ( nGXsfl_21_idx <= nRC_GXsfl_21 )
         {
            sendrow_212( ) ;
            nGXsfl_21_idx = ((subFsresultcategories_Islastpage==1)&&(nGXsfl_21_idx+1>subFsresultcategories_fnc_Recordsperpage( )) ? 1 : nGXsfl_21_idx+1);
            sGXsfl_21_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_21_idx), 4, 0), 4, "0");
            SubsflControlProps_212( ) ;
         }
         AddString( context.httpAjaxContext.getJSONContainerResponse( FsresultcategoriesContainer)) ;
         /* End function gxnrFsresultcategories_newrow */
      }

      protected void gxnrFsresults_newrow( )
      {
         GxWebStd.set_html_headers( context, 0, "", "");
         SubsflControlProps_293( ) ;
         while ( nGXsfl_29_idx <= nRC_GXsfl_29 )
         {
            sendrow_293( ) ;
            nGXsfl_29_idx = ((subFsresults_Islastpage==1)&&(nGXsfl_29_idx+1>subFsresults_fnc_Recordsperpage( )) ? 1 : nGXsfl_29_idx+1);
            sGXsfl_29_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_29_idx), 4, 0), 4, "0") + sGXsfl_21_idx;
            SubsflControlProps_293( ) ;
         }
         AddString( context.httpAjaxContext.getJSONContainerResponse( FsresultsContainer)) ;
         /* End function gxnrFsresults_newrow */
      }

      protected void gxgrFsresults_refresh( GXBaseCollection<GeneXus.Programs.wwpbaseobjects.SdtWWP_SearchResults_WWP_SearchResultsItem> AV26WWP_SearchResults ,
                                            string sPrefix )
      {
         initialize_formulas( ) ;
         GxWebStd.set_html_headers( context, 0, "", "");
         FSRESULTS_nCurrentRecord = 0;
         RF3I3( ) ;
         GXKey = Crypto.GetSiteKey( );
         send_integrity_footer_hashes( ) ;
         GXKey = Crypto.GetSiteKey( );
         /* End function gxgrFsresults_refresh */
      }

      protected void gxgrFsresultcategories_refresh( GXBaseCollection<GeneXus.Programs.wwpbaseobjects.SdtWWP_SearchResults_WWP_SearchResultsItem> AV26WWP_SearchResults ,
                                                     string sPrefix )
      {
         initialize_formulas( ) ;
         GxWebStd.set_html_headers( context, 0, "", "");
         FSRESULTCATEGORIES_nCurrentRecord = 0;
         RF3I2( ) ;
         GXKey = Crypto.GetSiteKey( );
         send_integrity_footer_hashes( ) ;
         GXKey = Crypto.GetSiteKey( );
         /* End function gxgrFsresultcategories_refresh */
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
         RF3I2( ) ;
         if ( isFullAjaxMode( ) )
         {
            send_integrity_footer_hashes( ) ;
         }
      }

      protected void initialize_formulas( )
      {
         /* GeneXus formulas. */
         context.Gx_err = 0;
         edtavWwp_searchresults__categoryname_Enabled = 0;
         AssignProp(sPrefix, false, edtavWwp_searchresults__categoryname_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavWwp_searchresults__categoryname_Enabled), 5, 0), !bGXsfl_21_Refreshing);
         edtavDisplaytype1_title_Enabled = 0;
         AssignProp(sPrefix, false, edtavDisplaytype1_title_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavDisplaytype1_title_Enabled), 5, 0), !bGXsfl_29_Refreshing);
         edtavDisplaytype2_title_Enabled = 0;
         AssignProp(sPrefix, false, edtavDisplaytype2_title_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavDisplaytype2_title_Enabled), 5, 0), !bGXsfl_29_Refreshing);
         edtavDisplaytype3_title_Enabled = 0;
         AssignProp(sPrefix, false, edtavDisplaytype3_title_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavDisplaytype3_title_Enabled), 5, 0), !bGXsfl_29_Refreshing);
         edtavDisplaytype3_subtitle_Enabled = 0;
         AssignProp(sPrefix, false, edtavDisplaytype3_subtitle_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavDisplaytype3_subtitle_Enabled), 5, 0), !bGXsfl_29_Refreshing);
         edtavDisplaytype4_title_Enabled = 0;
         AssignProp(sPrefix, false, edtavDisplaytype4_title_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavDisplaytype4_title_Enabled), 5, 0), !bGXsfl_29_Refreshing);
         edtavDisplaytype5_title_Enabled = 0;
         AssignProp(sPrefix, false, edtavDisplaytype5_title_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavDisplaytype5_title_Enabled), 5, 0), !bGXsfl_29_Refreshing);
         edtavDisplaytype5_subtitle_Enabled = 0;
         AssignProp(sPrefix, false, edtavDisplaytype5_subtitle_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavDisplaytype5_subtitle_Enabled), 5, 0), !bGXsfl_29_Refreshing);
      }

      protected void RF3I2( )
      {
         initialize_formulas( ) ;
         clear_multi_value_controls( ) ;
         if ( isAjaxCallMode( ) )
         {
            FsresultcategoriesContainer.ClearRows();
         }
         wbStart = 21;
         nGXsfl_21_idx = 1;
         sGXsfl_21_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_21_idx), 4, 0), 4, "0");
         SubsflControlProps_212( ) ;
         bGXsfl_21_Refreshing = true;
         FsresultcategoriesContainer.AddObjectProperty("GridName", "Fsresultcategories");
         FsresultcategoriesContainer.AddObjectProperty("CmpContext", sPrefix);
         FsresultcategoriesContainer.AddObjectProperty("InMasterPage", "false");
         FsresultcategoriesContainer.AddObjectProperty("Class", StringUtil.RTrim( "FreeStyleGridMPSearch"));
         FsresultcategoriesContainer.AddObjectProperty("Class", "FreeStyleGridMPSearch");
         FsresultcategoriesContainer.AddObjectProperty("Cellpadding", StringUtil.LTrim( StringUtil.NToC( (decimal)(1), 4, 0, ".", "")));
         FsresultcategoriesContainer.AddObjectProperty("Cellspacing", StringUtil.LTrim( StringUtil.NToC( (decimal)(2), 4, 0, ".", "")));
         FsresultcategoriesContainer.AddObjectProperty("Backcolorstyle", StringUtil.LTrim( StringUtil.NToC( (decimal)(subFsresultcategories_Backcolorstyle), 1, 0, ".", "")));
         FsresultcategoriesContainer.PageSize = subFsresultcategories_fnc_Recordsperpage( );
         gxdyncontrolsrefreshing = true;
         fix_multi_value_controls( ) ;
         gxdyncontrolsrefreshing = false;
         if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
         {
            SubsflControlProps_212( ) ;
            E163I2 ();
            wbEnd = 21;
            WB3I0( ) ;
         }
         bGXsfl_21_Refreshing = true;
      }

      protected void send_integrity_lvl_hashes3I2( )
      {
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri(sPrefix, false, sPrefix+"vWWP_SEARCHRESULTS", AV26WWP_SearchResults);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt(sPrefix+"vWWP_SEARCHRESULTS", AV26WWP_SearchResults);
         }
         GxWebStd.gx_hidden_field( context, sPrefix+"gxhash_vWWP_SEARCHRESULTS", GetSecureSignedToken( sPrefix, AV26WWP_SearchResults, context));
      }

      protected void RF3I3( )
      {
         initialize_formulas( ) ;
         clear_multi_value_controls( ) ;
         if ( isAjaxCallMode( ) )
         {
            FsresultsContainer.ClearRows();
         }
         wbStart = 29;
         nGXsfl_29_idx = 1;
         sGXsfl_29_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_29_idx), 4, 0), 4, "0") + sGXsfl_21_idx;
         SubsflControlProps_293( ) ;
         bGXsfl_29_Refreshing = true;
         FsresultsContainer.AddObjectProperty("GridName", "Fsresults");
         FsresultsContainer.AddObjectProperty("CmpContext", sPrefix);
         FsresultsContainer.AddObjectProperty("InMasterPage", "false");
         FsresultsContainer.AddObjectProperty("Class", StringUtil.RTrim( "FreeStyleGrid"));
         FsresultsContainer.AddObjectProperty("Class", "FreeStyleGrid");
         FsresultsContainer.AddObjectProperty("Cellpadding", StringUtil.LTrim( StringUtil.NToC( (decimal)(1), 4, 0, ".", "")));
         FsresultsContainer.AddObjectProperty("Cellspacing", StringUtil.LTrim( StringUtil.NToC( (decimal)(2), 4, 0, ".", "")));
         FsresultsContainer.AddObjectProperty("Backcolorstyle", StringUtil.LTrim( StringUtil.NToC( (decimal)(subFsresults_Backcolorstyle), 1, 0, ".", "")));
         FsresultsContainer.PageSize = subFsresults_fnc_Recordsperpage( );
         GXCCtl = "FSRESULTS_nFirstRecordOnPage_" + sGXsfl_21_idx;
         if ( subFsresults_Islastpage != 0 )
         {
            FSRESULTS_nFirstRecordOnPage = (long)(subFsresults_fnc_Recordcount( )-subFsresults_fnc_Recordsperpage( ));
            GxWebStd.gx_hidden_field( context, sPrefix+GXCCtl, StringUtil.LTrim( StringUtil.NToC( (decimal)(FSRESULTS_nFirstRecordOnPage), 15, 0, ".", "")));
            FsresultsContainer.AddObjectProperty("FSRESULTS_nFirstRecordOnPage", FSRESULTS_nFirstRecordOnPage);
         }
         gxdyncontrolsrefreshing = true;
         fix_multi_value_controls( ) ;
         gxdyncontrolsrefreshing = false;
         if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
         {
            SubsflControlProps_293( ) ;
            E173I3 ();
            wbEnd = 29;
            WB3I0( ) ;
         }
         bGXsfl_29_Refreshing = true;
      }

      protected void send_integrity_lvl_hashes3I3( )
      {
      }

      protected int subFsresultcategories_fnc_Pagecount( )
      {
         return (int)(-1) ;
      }

      protected int subFsresultcategories_fnc_Recordcount( )
      {
         return (int)(-1) ;
      }

      protected int subFsresultcategories_fnc_Recordsperpage( )
      {
         return (int)(-1) ;
      }

      protected int subFsresultcategories_fnc_Currentpage( )
      {
         return (int)(-1) ;
      }

      protected int subFsresults_fnc_Pagecount( )
      {
         return (int)(-1) ;
      }

      protected int subFsresults_fnc_Recordcount( )
      {
         return (int)(-1) ;
      }

      protected int subFsresults_fnc_Recordsperpage( )
      {
         return (int)(-1) ;
      }

      protected int subFsresults_fnc_Currentpage( )
      {
         return (int)(-1) ;
      }

      protected void before_start_formulas( )
      {
         context.Gx_err = 0;
         edtavWwp_searchresults__categoryname_Enabled = 0;
         AssignProp(sPrefix, false, edtavWwp_searchresults__categoryname_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavWwp_searchresults__categoryname_Enabled), 5, 0), !bGXsfl_21_Refreshing);
         edtavDisplaytype1_title_Enabled = 0;
         AssignProp(sPrefix, false, edtavDisplaytype1_title_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavDisplaytype1_title_Enabled), 5, 0), !bGXsfl_29_Refreshing);
         edtavDisplaytype2_title_Enabled = 0;
         AssignProp(sPrefix, false, edtavDisplaytype2_title_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavDisplaytype2_title_Enabled), 5, 0), !bGXsfl_29_Refreshing);
         edtavDisplaytype3_title_Enabled = 0;
         AssignProp(sPrefix, false, edtavDisplaytype3_title_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavDisplaytype3_title_Enabled), 5, 0), !bGXsfl_29_Refreshing);
         edtavDisplaytype3_subtitle_Enabled = 0;
         AssignProp(sPrefix, false, edtavDisplaytype3_subtitle_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavDisplaytype3_subtitle_Enabled), 5, 0), !bGXsfl_29_Refreshing);
         edtavDisplaytype4_title_Enabled = 0;
         AssignProp(sPrefix, false, edtavDisplaytype4_title_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavDisplaytype4_title_Enabled), 5, 0), !bGXsfl_29_Refreshing);
         edtavDisplaytype5_title_Enabled = 0;
         AssignProp(sPrefix, false, edtavDisplaytype5_title_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavDisplaytype5_title_Enabled), 5, 0), !bGXsfl_29_Refreshing);
         edtavDisplaytype5_subtitle_Enabled = 0;
         AssignProp(sPrefix, false, edtavDisplaytype5_subtitle_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavDisplaytype5_subtitle_Enabled), 5, 0), !bGXsfl_29_Refreshing);
         fix_multi_value_controls( ) ;
      }

      protected void STRUP3I0( )
      {
         /* Before Start, stand alone formulas. */
         before_start_formulas( ) ;
         /* Execute Start event if defined. */
         context.wbGlbDoneStart = 0;
         /* Execute user event: Start */
         E153I2 ();
         context.wbGlbDoneStart = 1;
         nDoneStart = 1;
         /* After Start, stand alone formulas. */
         sXEvt = cgiGet( "_EventName");
         if ( ! GetJustCreated( ) && ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 ) )
         {
            /* Read saved SDTs. */
            ajax_req_read_hidden_sdt(cgiGet( sPrefix+"Wwp_searchresults"), AV26WWP_SearchResults);
            ajax_req_read_hidden_sdt(cgiGet( sPrefix+"vDDO_TITLESETTINGSICONS"), AV9DDO_TitleSettingsIcons);
            ajax_req_read_hidden_sdt(cgiGet( sPrefix+"vADVFILTERENTITIES_DATA"), AV6AdvFilterEntities_Data);
            ajax_req_read_hidden_sdt(cgiGet( sPrefix+"vADVFILTERENTITIES"), AV5AdvFilterEntities);
            /* Read saved values. */
            nRC_GXsfl_21 = (int)(context.localUtil.CToN( cgiGet( sPrefix+"nRC_GXsfl_21"), ".", ","));
            wcpOAV22SearchText = cgiGet( sPrefix+"wcpOAV22SearchText");
            nRC_GXsfl_21 = (int)(context.localUtil.CToN( cgiGet( sPrefix+"nRC_GXsfl_21"), ".", ","));
            nGXsfl_21_fel_idx = 0;
            while ( nGXsfl_21_fel_idx < nRC_GXsfl_21 )
            {
               nGXsfl_21_fel_idx = ((subFsresultcategories_Islastpage==1)&&(nGXsfl_21_fel_idx+1>subFsresultcategories_fnc_Recordsperpage( )) ? 1 : nGXsfl_21_fel_idx+1);
               sGXsfl_21_fel_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_21_fel_idx), 4, 0), 4, "0");
               SubsflControlProps_fel_212( ) ;
               AV30GXV1 = nGXsfl_21_fel_idx;
               if ( ( AV26WWP_SearchResults.Count >= AV30GXV1 ) && ( AV30GXV1 > 0 ) )
               {
                  AV26WWP_SearchResults.CurrentItem = ((GeneXus.Programs.wwpbaseobjects.SdtWWP_SearchResults_WWP_SearchResultsItem)AV26WWP_SearchResults.Item(AV30GXV1));
               }
            }
            if ( nGXsfl_21_fel_idx == 0 )
            {
               nGXsfl_21_idx = 1;
               sGXsfl_21_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_21_idx), 4, 0), 4, "0");
               SubsflControlProps_212( ) ;
            }
            nGXsfl_21_fel_idx = 1;
            /* Read variables values. */
            AV8AdvFilterText = cgiGet( edtavAdvfiltertext_Internalname);
            AssignAttri(sPrefix, false, "AV8AdvFilterText", AV8AdvFilterText);
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
         E153I2 ();
         if (returnInSub) return;
      }

      protected void E153I2( )
      {
         /* Start Routine */
         returnInSub = false;
         AV20MinimumCharsToSearch = 2;
         AV23ShowingRecents = false;
         if ( StringUtil.Len( StringUtil.Trim( AV22SearchText)) < AV20MinimumCharsToSearch )
         {
            GXt_char1 = AV21RecentSearchResultsJson;
            new GeneXus.Programs.wwpbaseobjects.loaduserkeyvalue(context ).execute(  "WWPRecentSearch", out  GXt_char1) ;
            AV21RecentSearchResultsJson = GXt_char1;
            if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV21RecentSearchResultsJson)) )
            {
               AV26WWP_SearchResults.FromJSonString(AV21RecentSearchResultsJson, null);
               gx_BV21 = true;
               AV23ShowingRecents = (bool)(((AV26WWP_SearchResults.Count>0)));
            }
         }
         else
         {
            GXt_objcol_SdtWWP_SearchResults_WWP_SearchResultsItem2 = AV26WWP_SearchResults;
            new GeneXus.Programs.wwpbaseobjects.wwp_getsearchwcdata(context ).execute(  AV22SearchText,  4,  3, ref  AV5AdvFilterEntities, out  GXt_objcol_SdtWWP_SearchResults_WWP_SearchResultsItem2) ;
            AV26WWP_SearchResults = GXt_objcol_SdtWWP_SearchResults_WWP_SearchResultsItem2;
            gx_BV21 = true;
         }
         if ( AV26WWP_SearchResults.Count == 0 )
         {
            divShowall_cell_Class = "Invisible";
            AssignProp(sPrefix, false, divShowall_cell_Internalname, "Class", divShowall_cell_Class, true);
            divFsresultcategories_cell_Class = "Invisible";
            AssignProp(sPrefix, false, divFsresultcategories_cell_Internalname, "Class", divFsresultcategories_cell_Class, true);
            if ( StringUtil.Len( StringUtil.Trim( AV22SearchText)) < AV20MinimumCharsToSearch )
            {
               lblTxtnoresults_Caption = "Escribe para buscar en la aplicación o el menú";
               AssignProp(sPrefix, false, lblTxtnoresults_Internalname, "Caption", lblTxtnoresults_Caption, true);
            }
            else
            {
               lblTxtnoresults_Caption = StringUtil.Format( "No se encontraron resultados para '%1'.", AV22SearchText, "", "", "", "", "", "", "", "");
               AssignProp(sPrefix, false, lblTxtnoresults_Internalname, "Caption", lblTxtnoresults_Caption, true);
            }
         }
         else
         {
            if ( AV23ShowingRecents )
            {
               divShowall_cell_Class = "Invisible";
               AssignProp(sPrefix, false, divShowall_cell_Internalname, "Class", divShowall_cell_Class, true);
               lblTxtnoresults_Caption = "Mostrando resultados recientes";
               AssignProp(sPrefix, false, lblTxtnoresults_Internalname, "Caption", lblTxtnoresults_Caption, true);
            }
            else
            {
               divTxtnoresultscell_Class = "Invisible";
               AssignProp(sPrefix, false, divTxtnoresultscell_Internalname, "Class", divTxtnoresultscell_Class, true);
            }
         }
         Btnshowall_Caption = StringUtil.Format( "Mostrar todos los resultados para '%1'...", AV22SearchText, "", "", "", "", "", "", "", "");
         ucBtnshowall.SendProperty(context, sPrefix, false, Btnshowall_Internalname, "Caption", Btnshowall_Caption);
         divTableadvancedsearchcell_Class = "Invisible";
         AssignProp(sPrefix, false, divTableadvancedsearchcell_Internalname, "Class", divTableadvancedsearchcell_Class, true);
         AV8AdvFilterText = AV22SearchText;
         AssignAttri(sPrefix, false, "AV8AdvFilterText", AV8AdvFilterText);
         GXt_SdtDVB_SDTDropDownOptionsTitleSettingsIcons3 = AV9DDO_TitleSettingsIcons;
         new GeneXus.Programs.wwpbaseobjects.getwwptitlesettingsicons(context ).execute( out  GXt_SdtDVB_SDTDropDownOptionsTitleSettingsIcons3) ;
         AV9DDO_TitleSettingsIcons = GXt_SdtDVB_SDTDropDownOptionsTitleSettingsIcons3;
         /* Execute user subroutine: 'LOADCOMBOADVFILTERENTITIES' */
         S112 ();
         if (returnInSub) return;
         edtavUrl_Visible = 0;
         AssignProp(sPrefix, false, edtavUrl_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavUrl_Visible), 5, 0), !bGXsfl_29_Refreshing);
      }

      private void E163I2( )
      {
         /* Fsresultcategories_Load Routine */
         returnInSub = false;
         AV30GXV1 = 1;
         while ( AV30GXV1 <= AV26WWP_SearchResults.Count )
         {
            AV26WWP_SearchResults.CurrentItem = ((GeneXus.Programs.wwpbaseobjects.SdtWWP_SearchResults_WWP_SearchResultsItem)AV26WWP_SearchResults.Item(AV30GXV1));
            divShowingonlycell_Visible = ((!((GeneXus.Programs.wwpbaseobjects.SdtWWP_SearchResults_WWP_SearchResultsItem)(AV26WWP_SearchResults.CurrentItem)).gxTpr_Showingallresults) ? 1 : 0);
            AssignProp(sPrefix, false, divShowingonlycell_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(divShowingonlycell_Visible), 5, 0), !bGXsfl_21_Refreshing);
            lblTxtshowingonly_Caption = StringUtil.Format( "Mostrando los primeros %1 resultados", StringUtil.LTrimStr( (decimal)(((GeneXus.Programs.wwpbaseobjects.SdtWWP_SearchResults_WWP_SearchResultsItem)(AV26WWP_SearchResults.CurrentItem)).gxTpr_Result.Count), 9, 0), "", "", "", "", "", "", "", "");
            /* Load Method */
            if ( wbStart != -1 )
            {
               wbStart = 21;
            }
            sendrow_212( ) ;
            if ( isFullAjaxMode( ) && ! bGXsfl_21_Refreshing )
            {
               DoAjaxLoad(21, FsresultcategoriesRow);
            }
            AV30GXV1 = (int)(AV30GXV1+1);
         }
         /*  Sending Event outputs  */
      }

      protected void E113I2( )
      {
         /* 'DoCloseSearch' Routine */
         returnInSub = false;
         this.executeExternalObjectMethod(sPrefix, false, "WWPActions", "Popover_Close", new Object[] {(string)divTablemain_Internalname,(bool)false}, false);
      }

      protected void E123I2( )
      {
         /* 'DoShowAll' Routine */
         returnInSub = false;
         this.executeExternalObjectMethod(sPrefix, false, "WWPActions", "Popover_Close", new Object[] {(string)divTablemain_Internalname,(bool)false}, false);
         GXKey = Crypto.GetSiteKey( );
         GXEncryptionTmp = "wwpbaseobjects.wwp_search.aspx"+UrlEncode(StringUtil.RTrim(AV22SearchText)) + "," + UrlEncode(StringUtil.BoolToStr(false)) + "," + UrlEncode(StringUtil.RTrim(""));
         CallWebObject(formatLink("wwpbaseobjects.wwp_search.aspx") + "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey));
         context.wjLocDisableFrm = 1;
      }

      protected void E133I2( )
      {
         /* 'DoBtnAdvSearch' Routine */
         returnInSub = false;
         this.executeExternalObjectMethod(sPrefix, false, "WWPActions", "Popover_Close", new Object[] {(string)divTablemain_Internalname,(bool)false}, false);
         GXKey = Crypto.GetSiteKey( );
         GXEncryptionTmp = "wwpbaseobjects.wwp_search.aspx"+UrlEncode(StringUtil.RTrim(AV8AdvFilterText)) + "," + UrlEncode(StringUtil.BoolToStr(true)) + "," + UrlEncode(StringUtil.RTrim(AV5AdvFilterEntities.ToJSonString(false)));
         CallWebObject(formatLink("wwpbaseobjects.wwp_search.aspx") + "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey));
         context.wjLocDisableFrm = 1;
      }

      protected void S112( )
      {
         /* 'LOADCOMBOADVFILTERENTITIES' Routine */
         returnInSub = false;
         new GeneXus.Programs.wwpbaseobjects.wwp_getsearchwcdata(context ).execute(  "",  999,  0, ref  AV19EntityDescriptions, out  AV25WWP_SearchResultAux) ;
         AV6AdvFilterEntities_Data = new GXBaseCollection<GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTComboData_Item>( context, "Item", "");
         AV34GXV4 = 1;
         while ( AV34GXV4 <= AV19EntityDescriptions.Count )
         {
            AV18EntityDescription = ((string)AV19EntityDescriptions.Item(AV34GXV4));
            AV7AdvFilterEntities_DataItem = new GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTComboData_Item(context);
            AV7AdvFilterEntities_DataItem.gxTpr_Id = AV18EntityDescription;
            AV7AdvFilterEntities_DataItem.gxTpr_Title = AV18EntityDescription;
            AV6AdvFilterEntities_Data.Add(AV7AdvFilterEntities_DataItem, 0);
            AV34GXV4 = (int)(AV34GXV4+1);
         }
         Combo_advfilterentities_Selectedvalue_set = AV5AdvFilterEntities.ToJSonString(false);
         ucCombo_advfilterentities.SendProperty(context, sPrefix, false, Combo_advfilterentities_Internalname, "SelectedValue_set", Combo_advfilterentities_Selectedvalue_set);
      }

      protected void E143I2( )
      {
         AV30GXV1 = nGXsfl_21_idx;
         if ( ( AV30GXV1 > 0 ) && ( AV26WWP_SearchResults.Count >= AV30GXV1 ) )
         {
            AV26WWP_SearchResults.CurrentItem = ((GeneXus.Programs.wwpbaseobjects.SdtWWP_SearchResults_WWP_SearchResultsItem)AV26WWP_SearchResults.Item(AV30GXV1));
         }
         /* Unnamedtablefsfsresults_Click Routine */
         returnInSub = false;
         this.executeExternalObjectMethod(sPrefix, false, "WWPActions", "Popover_Close", new Object[] {(string)divTablemain_Internalname,(bool)false}, false);
         new GeneXus.Programs.wwpbaseobjects.wwp_addrecentsearch(context ).execute(  AV26WWP_SearchResults,  AV24Url,  4,  3) ;
         CallWebObject(formatLink(AV24Url) );
         context.wjLocDisableFrm = 0;
      }

      private void E173I3( )
      {
         AV30GXV1 = nGXsfl_21_idx;
         if ( AV26WWP_SearchResults.Count < AV30GXV1 )
         {
            return  ;
         }
         /* Fsresults_Load Routine */
         returnInSub = false;
         AV32GXV3 = 1;
         while ( AV32GXV3 <= ((GeneXus.Programs.wwpbaseobjects.SdtWWP_SearchResults_WWP_SearchResultsItem)AV26WWP_SearchResults.Item(AV30GXV1)).gxTpr_Result.Count )
         {
            ((GeneXus.Programs.wwpbaseobjects.SdtWWP_SearchResults_WWP_SearchResultsItem)AV26WWP_SearchResults.Item(AV30GXV1)).gxTpr_Result.CurrentItem = ((GeneXus.Programs.wwpbaseobjects.SdtWWP_SearchResults_WWP_SearchResultsItem_ResultItem)((GeneXus.Programs.wwpbaseobjects.SdtWWP_SearchResults_WWP_SearchResultsItem)AV26WWP_SearchResults.Item(AV30GXV1)).gxTpr_Result.Item(AV32GXV3));
            divDisplaytype1_cell_Visible = 0;
            AssignProp(sPrefix, false, divDisplaytype1_cell_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(divDisplaytype1_cell_Visible), 5, 0), !bGXsfl_29_Refreshing);
            divDisplaytype2_cell_Visible = 0;
            AssignProp(sPrefix, false, divDisplaytype2_cell_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(divDisplaytype2_cell_Visible), 5, 0), !bGXsfl_29_Refreshing);
            divDisplaytype3_cell_Visible = 0;
            AssignProp(sPrefix, false, divDisplaytype3_cell_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(divDisplaytype3_cell_Visible), 5, 0), !bGXsfl_29_Refreshing);
            divDisplaytype4_cell_Visible = 0;
            AssignProp(sPrefix, false, divDisplaytype4_cell_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(divDisplaytype4_cell_Visible), 5, 0), !bGXsfl_29_Refreshing);
            divDisplaytype5_cell_Visible = 0;
            AssignProp(sPrefix, false, divDisplaytype5_cell_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(divDisplaytype5_cell_Visible), 5, 0), !bGXsfl_29_Refreshing);
            if ( StringUtil.StrCmp(((GeneXus.Programs.wwpbaseobjects.SdtWWP_SearchResults_WWP_SearchResultsItem_ResultItem)(((GeneXus.Programs.wwpbaseobjects.SdtWWP_SearchResults_WWP_SearchResultsItem)(AV26WWP_SearchResults.CurrentItem)).gxTpr_Result.CurrentItem)).gxTpr_Displaytype, "Title") == 0 )
            {
               divDisplaytype1_cell_Visible = 1;
               AssignProp(sPrefix, false, divDisplaytype1_cell_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(divDisplaytype1_cell_Visible), 5, 0), !bGXsfl_29_Refreshing);
               AV10DisplayType1_Title = ((GeneXus.Programs.wwpbaseobjects.SdtWWP_SearchResults_WWP_SearchResultsItem_ResultItem)(((GeneXus.Programs.wwpbaseobjects.SdtWWP_SearchResults_WWP_SearchResultsItem)(AV26WWP_SearchResults.CurrentItem)).gxTpr_Result.CurrentItem)).gxTpr_Description;
               AssignAttri(sPrefix, false, edtavDisplaytype1_title_Internalname, AV10DisplayType1_Title);
            }
            else if ( StringUtil.StrCmp(((GeneXus.Programs.wwpbaseobjects.SdtWWP_SearchResults_WWP_SearchResultsItem_ResultItem)(((GeneXus.Programs.wwpbaseobjects.SdtWWP_SearchResults_WWP_SearchResultsItem)(AV26WWP_SearchResults.CurrentItem)).gxTpr_Result.CurrentItem)).gxTpr_Displaytype, "Title and icon image") == 0 )
            {
               divDisplaytype2_cell_Visible = 1;
               AssignProp(sPrefix, false, divDisplaytype2_cell_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(divDisplaytype2_cell_Visible), 5, 0), !bGXsfl_29_Refreshing);
               AV11DisplayType2_Title = ((GeneXus.Programs.wwpbaseobjects.SdtWWP_SearchResults_WWP_SearchResultsItem_ResultItem)(((GeneXus.Programs.wwpbaseobjects.SdtWWP_SearchResults_WWP_SearchResultsItem)(AV26WWP_SearchResults.CurrentItem)).gxTpr_Result.CurrentItem)).gxTpr_Description;
               AssignAttri(sPrefix, false, edtavDisplaytype2_title_Internalname, AV11DisplayType2_Title);
               lblDisplaytype2_icon_Caption = StringUtil.Format( "<i class='SearchResultIcon %1'></i>", ((GeneXus.Programs.wwpbaseobjects.SdtWWP_SearchResults_WWP_SearchResultsItem_ResultItem)(((GeneXus.Programs.wwpbaseobjects.SdtWWP_SearchResults_WWP_SearchResultsItem)(AV26WWP_SearchResults.CurrentItem)).gxTpr_Result.CurrentItem)).gxTpr_Description2, "", "", "", "", "", "", "", "");
            }
            else if ( StringUtil.StrCmp(((GeneXus.Programs.wwpbaseobjects.SdtWWP_SearchResults_WWP_SearchResultsItem_ResultItem)(((GeneXus.Programs.wwpbaseobjects.SdtWWP_SearchResults_WWP_SearchResultsItem)(AV26WWP_SearchResults.CurrentItem)).gxTpr_Result.CurrentItem)).gxTpr_Displaytype, "Title and subtitle") == 0 )
            {
               divDisplaytype3_cell_Visible = 1;
               AssignProp(sPrefix, false, divDisplaytype3_cell_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(divDisplaytype3_cell_Visible), 5, 0), !bGXsfl_29_Refreshing);
               AV13DisplayType3_Title = ((GeneXus.Programs.wwpbaseobjects.SdtWWP_SearchResults_WWP_SearchResultsItem_ResultItem)(((GeneXus.Programs.wwpbaseobjects.SdtWWP_SearchResults_WWP_SearchResultsItem)(AV26WWP_SearchResults.CurrentItem)).gxTpr_Result.CurrentItem)).gxTpr_Description;
               AssignAttri(sPrefix, false, edtavDisplaytype3_title_Internalname, AV13DisplayType3_Title);
               AV12DisplayType3_Subtitle = ((GeneXus.Programs.wwpbaseobjects.SdtWWP_SearchResults_WWP_SearchResultsItem_ResultItem)(((GeneXus.Programs.wwpbaseobjects.SdtWWP_SearchResults_WWP_SearchResultsItem)(AV26WWP_SearchResults.CurrentItem)).gxTpr_Result.CurrentItem)).gxTpr_Description2;
               AssignAttri(sPrefix, false, edtavDisplaytype3_subtitle_Internalname, AV12DisplayType3_Subtitle);
            }
            else if ( StringUtil.StrCmp(((GeneXus.Programs.wwpbaseobjects.SdtWWP_SearchResults_WWP_SearchResultsItem_ResultItem)(((GeneXus.Programs.wwpbaseobjects.SdtWWP_SearchResults_WWP_SearchResultsItem)(AV26WWP_SearchResults.CurrentItem)).gxTpr_Result.CurrentItem)).gxTpr_Displaytype, "Title and image") == 0 )
            {
               divDisplaytype4_cell_Visible = 1;
               AssignProp(sPrefix, false, divDisplaytype4_cell_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(divDisplaytype4_cell_Visible), 5, 0), !bGXsfl_29_Refreshing);
               AV15DisplayType4_Title = ((GeneXus.Programs.wwpbaseobjects.SdtWWP_SearchResults_WWP_SearchResultsItem_ResultItem)(((GeneXus.Programs.wwpbaseobjects.SdtWWP_SearchResults_WWP_SearchResultsItem)(AV26WWP_SearchResults.CurrentItem)).gxTpr_Result.CurrentItem)).gxTpr_Description;
               AssignAttri(sPrefix, false, edtavDisplaytype4_title_Internalname, AV15DisplayType4_Title);
               if ( String.IsNullOrEmpty(StringUtil.RTrim( ((GeneXus.Programs.wwpbaseobjects.SdtWWP_SearchResults_WWP_SearchResultsItem_ResultItem)(((GeneXus.Programs.wwpbaseobjects.SdtWWP_SearchResults_WWP_SearchResultsItem)(AV26WWP_SearchResults.CurrentItem)).gxTpr_Result.CurrentItem)).gxTpr_Description2)) )
               {
                  AV14DisplayType4_Image = "";
                  AssignAttri(sPrefix, false, edtavDisplaytype4_image_Internalname, AV14DisplayType4_Image);
                  AV33Displaytype4_image_GXI = "";
               }
               else
               {
                  AV14DisplayType4_Image = ((GeneXus.Programs.wwpbaseobjects.SdtWWP_SearchResults_WWP_SearchResultsItem_ResultItem)(((GeneXus.Programs.wwpbaseobjects.SdtWWP_SearchResults_WWP_SearchResultsItem)(AV26WWP_SearchResults.CurrentItem)).gxTpr_Result.CurrentItem)).gxTpr_Description2;
                  AssignAttri(sPrefix, false, edtavDisplaytype4_image_Internalname, AV14DisplayType4_Image);
                  AV33Displaytype4_image_GXI = GXDbFile.PathToUrl( ((GeneXus.Programs.wwpbaseobjects.SdtWWP_SearchResults_WWP_SearchResultsItem_ResultItem)(((GeneXus.Programs.wwpbaseobjects.SdtWWP_SearchResults_WWP_SearchResultsItem)(AV26WWP_SearchResults.CurrentItem)).gxTpr_Result.CurrentItem)).gxTpr_Description2);
               }
               edtavDisplaytype4_image_Visible = ((!String.IsNullOrEmpty(StringUtil.RTrim( ((GeneXus.Programs.wwpbaseobjects.SdtWWP_SearchResults_WWP_SearchResultsItem_ResultItem)(((GeneXus.Programs.wwpbaseobjects.SdtWWP_SearchResults_WWP_SearchResultsItem)(AV26WWP_SearchResults.CurrentItem)).gxTpr_Result.CurrentItem)).gxTpr_Description2))) ? 1 : 0);
            }
            else if ( StringUtil.StrCmp(((GeneXus.Programs.wwpbaseobjects.SdtWWP_SearchResults_WWP_SearchResultsItem_ResultItem)(((GeneXus.Programs.wwpbaseobjects.SdtWWP_SearchResults_WWP_SearchResultsItem)(AV26WWP_SearchResults.CurrentItem)).gxTpr_Result.CurrentItem)).gxTpr_Displaytype, "Title, subtitle and icon image") == 0 )
            {
               divDisplaytype5_cell_Visible = 1;
               AssignProp(sPrefix, false, divDisplaytype5_cell_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(divDisplaytype5_cell_Visible), 5, 0), !bGXsfl_29_Refreshing);
               AV17DisplayType5_Title = ((GeneXus.Programs.wwpbaseobjects.SdtWWP_SearchResults_WWP_SearchResultsItem_ResultItem)(((GeneXus.Programs.wwpbaseobjects.SdtWWP_SearchResults_WWP_SearchResultsItem)(AV26WWP_SearchResults.CurrentItem)).gxTpr_Result.CurrentItem)).gxTpr_Description;
               AssignAttri(sPrefix, false, edtavDisplaytype5_title_Internalname, AV17DisplayType5_Title);
               AV16DisplayType5_Subtitle = ((GeneXus.Programs.wwpbaseobjects.SdtWWP_SearchResults_WWP_SearchResultsItem_ResultItem)(((GeneXus.Programs.wwpbaseobjects.SdtWWP_SearchResults_WWP_SearchResultsItem)(AV26WWP_SearchResults.CurrentItem)).gxTpr_Result.CurrentItem)).gxTpr_Description2;
               AssignAttri(sPrefix, false, edtavDisplaytype5_subtitle_Internalname, AV16DisplayType5_Subtitle);
               lblDisplaytype5_icon_Caption = StringUtil.Format( "<i class='SearchResultIconWS %1'></i>", ((GeneXus.Programs.wwpbaseobjects.SdtWWP_SearchResults_WWP_SearchResultsItem_ResultItem)(((GeneXus.Programs.wwpbaseobjects.SdtWWP_SearchResults_WWP_SearchResultsItem)(AV26WWP_SearchResults.CurrentItem)).gxTpr_Result.CurrentItem)).gxTpr_Description3, "", "", "", "", "", "", "", "");
            }
            AV24Url = ((GeneXus.Programs.wwpbaseobjects.SdtWWP_SearchResults_WWP_SearchResultsItem_ResultItem)(((GeneXus.Programs.wwpbaseobjects.SdtWWP_SearchResults_WWP_SearchResultsItem)(AV26WWP_SearchResults.CurrentItem)).gxTpr_Result.CurrentItem)).gxTpr_Url;
            AssignAttri(sPrefix, false, edtavUrl_Internalname, AV24Url);
            /* Load Method */
            if ( wbStart != -1 )
            {
               wbStart = 29;
            }
            sendrow_293( ) ;
            if ( isFullAjaxMode( ) && ! bGXsfl_29_Refreshing )
            {
               DoAjaxLoad(29, FsresultsRow);
            }
            AV32GXV3 = (int)(AV32GXV3+1);
         }
         /*  Sending Event outputs  */
      }

      public override void setparameters( Object[] obj )
      {
         createObjects();
         initialize();
         AV22SearchText = (string)getParm(obj,0);
         AssignAttri(sPrefix, false, "AV22SearchText", AV22SearchText);
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
         PA3I2( ) ;
         WS3I2( ) ;
         WE3I2( ) ;
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
         sCtrlAV22SearchText = (string)((string)getParm(obj,0));
      }

      public override void componentrestorestate( string sPPrefix ,
                                                  string sPSFPrefix )
      {
         sPrefix = sPPrefix + sPSFPrefix;
         PA3I2( ) ;
         WCParametersGet( ) ;
      }

      public override void componentprepare( Object[] obj )
      {
         wbLoad = false;
         sCompPrefix = (string)getParm(obj,0);
         sSFPrefix = (string)getParm(obj,1);
         sPrefix = sCompPrefix + sSFPrefix;
         AddComponentObject(sPrefix, "wwpbaseobjects\\wwp_searchwc", GetJustCreated( ));
         if ( ( nDoneStart == 0 ) && ( nDynComponent == 0 ) )
         {
            INITWEB( ) ;
         }
         else
         {
            init_default_properties( ) ;
            init_web_controls( ) ;
         }
         PA3I2( ) ;
         if ( ! GetJustCreated( ) && ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 ) && ( context.wbGlbDoneStart == 0 ) )
         {
            WCParametersGet( ) ;
         }
         else
         {
            AV22SearchText = (string)getParm(obj,2);
            AssignAttri(sPrefix, false, "AV22SearchText", AV22SearchText);
         }
         wcpOAV22SearchText = cgiGet( sPrefix+"wcpOAV22SearchText");
         if ( ! GetJustCreated( ) && ( ( StringUtil.StrCmp(AV22SearchText, wcpOAV22SearchText) != 0 ) ) )
         {
            setjustcreated();
         }
         wcpOAV22SearchText = AV22SearchText;
      }

      protected void WCParametersGet( )
      {
         /* Read Component Parameters. */
         sCtrlAV22SearchText = cgiGet( sPrefix+"AV22SearchText_CTRL");
         if ( StringUtil.Len( sCtrlAV22SearchText) > 0 )
         {
            AV22SearchText = cgiGet( sCtrlAV22SearchText);
            AssignAttri(sPrefix, false, "AV22SearchText", AV22SearchText);
         }
         else
         {
            AV22SearchText = cgiGet( sPrefix+"AV22SearchText_PARM");
         }
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
         PA3I2( ) ;
         sEvt = sCompEvt;
         WCParametersGet( ) ;
         WS3I2( ) ;
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
         WS3I2( ) ;
         SaveComponentMsgList(sPrefix);
         context.GX_msglist = BackMsgLst;
      }

      protected void WCParametersSet( )
      {
         GxWebStd.gx_hidden_field( context, sPrefix+"AV22SearchText_PARM", AV22SearchText);
         if ( StringUtil.Len( StringUtil.RTrim( sCtrlAV22SearchText)) > 0 )
         {
            GxWebStd.gx_hidden_field( context, sPrefix+"AV22SearchText_CTRL", StringUtil.RTrim( sCtrlAV22SearchText));
         }
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
         WE3I2( ) ;
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
         AddThemeStyleSheetFile("", context.GetTheme( )+".css", "?"+GetCacheInvalidationToken( ));
         bool outputEnabled = isOutputEnabled( );
         if ( context.isSpaRequest( ) )
         {
            enableOutput();
         }
         idxLst = 1;
         while ( idxLst <= Form.Jscriptsrc.Count )
         {
            context.AddJavascriptSource(StringUtil.RTrim( ((string)Form.Jscriptsrc.Item(idxLst))), "?202281816343683", true, true);
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
         context.AddJavascriptSource("wwpbaseobjects/wwp_searchwc.js", "?202281816343683", false, true);
         context.AddJavascriptSource("UserControls/WWP_IconButtonRender.js", "", false, true);
         context.AddJavascriptSource("DVelop/Bootstrap/Shared/DVelopBootstrap.js", "", false, true);
         context.AddJavascriptSource("DVelop/Shared/WorkWithPlusCommon.js", "", false, true);
         context.AddJavascriptSource("DVelop/Bootstrap/DropDownOptions/BootstrapDropDownOptionsRender.js", "", false, true);
         context.AddJavascriptSource("UserControls/WWP_IconButtonRender.js", "", false, true);
         /* End function include_jscripts */
      }

      protected void SubsflControlProps_293( )
      {
         edtavUrl_Internalname = sPrefix+"vURL_"+sGXsfl_29_idx;
         edtavDisplaytype1_title_Internalname = sPrefix+"vDISPLAYTYPE1_TITLE_"+sGXsfl_29_idx;
         lblDisplaytype2_icon_Internalname = sPrefix+"DISPLAYTYPE2_ICON_"+sGXsfl_29_idx;
         edtavDisplaytype2_title_Internalname = sPrefix+"vDISPLAYTYPE2_TITLE_"+sGXsfl_29_idx;
         edtavDisplaytype3_title_Internalname = sPrefix+"vDISPLAYTYPE3_TITLE_"+sGXsfl_29_idx;
         edtavDisplaytype3_subtitle_Internalname = sPrefix+"vDISPLAYTYPE3_SUBTITLE_"+sGXsfl_29_idx;
         edtavDisplaytype4_image_Internalname = sPrefix+"vDISPLAYTYPE4_IMAGE_"+sGXsfl_29_idx;
         edtavDisplaytype4_title_Internalname = sPrefix+"vDISPLAYTYPE4_TITLE_"+sGXsfl_29_idx;
         lblDisplaytype5_icon_Internalname = sPrefix+"DISPLAYTYPE5_ICON_"+sGXsfl_29_idx;
         edtavDisplaytype5_title_Internalname = sPrefix+"vDISPLAYTYPE5_TITLE_"+sGXsfl_29_idx;
         edtavDisplaytype5_subtitle_Internalname = sPrefix+"vDISPLAYTYPE5_SUBTITLE_"+sGXsfl_29_idx;
      }

      protected void SubsflControlProps_fel_293( )
      {
         edtavUrl_Internalname = sPrefix+"vURL_"+sGXsfl_29_fel_idx;
         edtavDisplaytype1_title_Internalname = sPrefix+"vDISPLAYTYPE1_TITLE_"+sGXsfl_29_fel_idx;
         lblDisplaytype2_icon_Internalname = sPrefix+"DISPLAYTYPE2_ICON_"+sGXsfl_29_fel_idx;
         edtavDisplaytype2_title_Internalname = sPrefix+"vDISPLAYTYPE2_TITLE_"+sGXsfl_29_fel_idx;
         edtavDisplaytype3_title_Internalname = sPrefix+"vDISPLAYTYPE3_TITLE_"+sGXsfl_29_fel_idx;
         edtavDisplaytype3_subtitle_Internalname = sPrefix+"vDISPLAYTYPE3_SUBTITLE_"+sGXsfl_29_fel_idx;
         edtavDisplaytype4_image_Internalname = sPrefix+"vDISPLAYTYPE4_IMAGE_"+sGXsfl_29_fel_idx;
         edtavDisplaytype4_title_Internalname = sPrefix+"vDISPLAYTYPE4_TITLE_"+sGXsfl_29_fel_idx;
         lblDisplaytype5_icon_Internalname = sPrefix+"DISPLAYTYPE5_ICON_"+sGXsfl_29_fel_idx;
         edtavDisplaytype5_title_Internalname = sPrefix+"vDISPLAYTYPE5_TITLE_"+sGXsfl_29_fel_idx;
         edtavDisplaytype5_subtitle_Internalname = sPrefix+"vDISPLAYTYPE5_SUBTITLE_"+sGXsfl_29_fel_idx;
      }

      protected void sendrow_293( )
      {
         SubsflControlProps_293( ) ;
         WB3I0( ) ;
         FsresultsRow = GXWebRow.GetNew(context,FsresultsContainer);
         if ( subFsresults_Backcolorstyle == 0 )
         {
            /* None style subfile background logic. */
            subFsresults_Backstyle = 0;
            if ( StringUtil.StrCmp(subFsresults_Class, "") != 0 )
            {
               subFsresults_Linesclass = subFsresults_Class+"Odd";
            }
         }
         else if ( subFsresults_Backcolorstyle == 1 )
         {
            /* Uniform style subfile background logic. */
            subFsresults_Backstyle = 0;
            subFsresults_Backcolor = subFsresults_Allbackcolor;
            if ( StringUtil.StrCmp(subFsresults_Class, "") != 0 )
            {
               subFsresults_Linesclass = subFsresults_Class+"Uniform";
            }
         }
         else if ( subFsresults_Backcolorstyle == 2 )
         {
            /* Header style subfile background logic. */
            subFsresults_Backstyle = 1;
            if ( StringUtil.StrCmp(subFsresults_Class, "") != 0 )
            {
               subFsresults_Linesclass = subFsresults_Class+"Odd";
            }
            subFsresults_Backcolor = (int)(0xFFFFFF);
         }
         else if ( subFsresults_Backcolorstyle == 3 )
         {
            /* Report style subfile background logic. */
            subFsresults_Backstyle = 1;
            if ( ((int)((nGXsfl_29_idx) % (2))) == 0 )
            {
               subFsresults_Backcolor = (int)(0x0);
               if ( StringUtil.StrCmp(subFsresults_Class, "") != 0 )
               {
                  subFsresults_Linesclass = subFsresults_Class+"Even";
               }
            }
            else
            {
               subFsresults_Backcolor = (int)(0xFFFFFF);
               if ( StringUtil.StrCmp(subFsresults_Class, "") != 0 )
               {
                  subFsresults_Linesclass = subFsresults_Class+"Odd";
               }
            }
         }
         /* Start of Columns property logic. */
         if ( FsresultsContainer.GetWrapped() == 1 )
         {
            context.WriteHtmlText( "<tr"+" class=\""+subFsresults_Linesclass+"\" style=\""+""+"\""+" data-gxrow=\""+sGXsfl_29_idx+"\">") ;
         }
         /* Div Control */
         FsresultsRow.AddColumnProperties("div_start", -1, isAjaxCallMode( ), new Object[] {(string)divUnnamedtablefsfsresults_Internalname+"_"+sGXsfl_29_idx,(short)1,(short)0,(string)"px",(short)0,(string)"px",(string)"Flex",(string)"left",(string)"top",(string)" "+"data-gx-flex"+" ",(string)"",(string)"div"});
         /* Div Control */
         FsresultsRow.AddColumnProperties("div_start", -1, isAjaxCallMode( ), new Object[] {(string)"",(short)1,(short)0,(string)"px",(short)0,(string)"px",(string)"Invisible",(string)"left",(string)"top",(string)"",(string)"flex-grow:1;",(string)"div"});
         /* Table start */
         FsresultsRow.AddColumnProperties("table", -1, isAjaxCallMode( ), new Object[] {(string)tblUnnamedtablecontentfsfsresults_Internalname+"_"+sGXsfl_29_idx,(short)1,(string)"Table",(string)"",(string)"",(string)"",(string)"",(string)"",(string)"",(short)1,(short)2,(string)"",(string)"",(string)"",(string)"px",(string)"px",(string)""});
         FsresultsRow.AddColumnProperties("row", -1, isAjaxCallMode( ), new Object[] {(string)"",(string)"",(string)""});
         FsresultsRow.AddColumnProperties("cell", -1, isAjaxCallMode( ), new Object[] {(string)"",(string)"",(string)""});
         /* Div Control */
         FsresultsRow.AddColumnProperties("div_start", -1, isAjaxCallMode( ), new Object[] {(string)"",(short)1,(short)0,(string)"px",(short)0,(string)"px",(string)" gx-attribute",(string)"left",(string)"top",(string)"",(string)"",(string)"div"});
         /* Attribute/Variable Label */
         FsresultsRow.AddColumnProperties("html_label", -1, isAjaxCallMode( ), new Object[] {(string)edtavUrl_Internalname,(string)"Url",(string)"gx-form-item AttributeLabel",(short)0,(bool)true,(string)"width: 25%;"});
         /* Single line edit */
         ROClassString = "Attribute";
         FsresultsRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtavUrl_Internalname,(string)AV24Url,(string)"",(string)"",(string)"'"+sPrefix+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtavUrl_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"",(string)"",(int)edtavUrl_Visible,(short)0,(short)0,(string)"text",(string)"",(short)40,(string)"chr",(short)1,(string)"row",(short)40,(short)0,(short)0,(short)29,(short)1,(short)-1,(short)-1,(bool)true,(string)"",(string)"left",(bool)true,(string)""});
         FsresultsRow.AddColumnProperties("div_end", -1, isAjaxCallMode( ), new Object[] {(string)"left",(string)"top",(string)"div"});
         if ( FsresultsContainer.GetWrapped() == 1 )
         {
            FsresultsContainer.CloseTag("cell");
         }
         if ( FsresultsContainer.GetWrapped() == 1 )
         {
            FsresultsContainer.CloseTag("row");
         }
         if ( FsresultsContainer.GetWrapped() == 1 )
         {
            FsresultsContainer.CloseTag("table");
         }
         /* End of table */
         FsresultsRow.AddColumnProperties("div_end", -1, isAjaxCallMode( ), new Object[] {(string)"left",(string)"top",(string)"div"});
         /* Div Control */
         FsresultsRow.AddColumnProperties("div_start", -1, isAjaxCallMode( ), new Object[] {(string)divDisplaytype1_cell_Internalname+"_"+sGXsfl_29_idx,(int)divDisplaytype1_cell_Visible,(short)0,(string)"px",(short)0,(string)"px",(string)"",(string)"left",(string)"top",(string)"",(string)"flex-grow:1;",(string)"div"});
         /* Div Control */
         FsresultsRow.AddColumnProperties("div_start", -1, isAjaxCallMode( ), new Object[] {(string)divUnnamedtable1_Internalname+"_"+sGXsfl_29_idx,(short)1,(short)0,(string)"px",(short)0,(string)"px",(string)"",(string)"left",(string)"top",(string)"",(string)"",(string)"div"});
         /* Div Control */
         FsresultsRow.AddColumnProperties("div_start", -1, isAjaxCallMode( ), new Object[] {(string)"",(short)1,(short)0,(string)"px",(short)0,(string)"px",(string)"row",(string)"left",(string)"top",(string)"",(string)"",(string)"div"});
         /* Div Control */
         FsresultsRow.AddColumnProperties("div_start", -1, isAjaxCallMode( ), new Object[] {(string)"",(short)1,(short)0,(string)"px",(short)0,(string)"px",(string)"col-xs-12",(string)"left",(string)"top",(string)"",(string)"",(string)"div"});
         /* Div Control */
         FsresultsRow.AddColumnProperties("div_start", -1, isAjaxCallMode( ), new Object[] {(string)"",(short)1,(short)0,(string)"px",(short)0,(string)"px",(string)" gx-attribute",(string)"left",(string)"top",(string)"",(string)"",(string)"div"});
         /* Attribute/Variable Label */
         FsresultsRow.AddColumnProperties("html_label", -1, isAjaxCallMode( ), new Object[] {(string)edtavDisplaytype1_title_Internalname,(string)"Display Type1_Title",(string)"col-sm-3 AttributeSearchResultTitleLabel",(short)0,(bool)true,(string)""});
         /* Single line edit */
         ROClassString = "AttributeSearchResultTitle";
         FsresultsRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtavDisplaytype1_title_Internalname,(string)AV10DisplayType1_Title,(string)"",(string)"",(string)"'"+sPrefix+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtavDisplaytype1_title_Jsonclick,(short)0,(string)"AttributeSearchResultTitle",(string)"",(string)ROClassString,(string)"",(string)"",(short)1,(int)edtavDisplaytype1_title_Enabled,(short)0,(string)"text",(string)"",(short)40,(string)"chr",(short)1,(string)"row",(short)40,(short)0,(short)0,(short)29,(short)1,(short)-1,(short)-1,(bool)true,(string)"",(string)"left",(bool)true,(string)""});
         FsresultsRow.AddColumnProperties("div_end", -1, isAjaxCallMode( ), new Object[] {(string)"left",(string)"top",(string)"div"});
         FsresultsRow.AddColumnProperties("div_end", -1, isAjaxCallMode( ), new Object[] {(string)"left",(string)"top",(string)"div"});
         FsresultsRow.AddColumnProperties("div_end", -1, isAjaxCallMode( ), new Object[] {(string)"left",(string)"top",(string)"div"});
         FsresultsRow.AddColumnProperties("div_end", -1, isAjaxCallMode( ), new Object[] {(string)"left",(string)"top",(string)"div"});
         FsresultsRow.AddColumnProperties("div_end", -1, isAjaxCallMode( ), new Object[] {(string)"left",(string)"top",(string)"div"});
         /* Div Control */
         FsresultsRow.AddColumnProperties("div_start", -1, isAjaxCallMode( ), new Object[] {(string)divDisplaytype2_cell_Internalname+"_"+sGXsfl_29_idx,(int)divDisplaytype2_cell_Visible,(short)0,(string)"px",(short)0,(string)"px",(string)"",(string)"left",(string)"top",(string)"",(string)"flex-grow:1;",(string)"div"});
         /* Table start */
         FsresultsRow.AddColumnProperties("table", -1, isAjaxCallMode( ), new Object[] {(string)tblUnnamedtable2_Internalname+"_"+sGXsfl_29_idx,(short)1,(string)"",(string)"",(string)"",(string)"",(string)"",(string)"",(string)"",(short)1,(short)2,(string)"",(string)"",(string)"",(string)"px",(string)"px",(string)""});
         FsresultsRow.AddColumnProperties("row", -1, isAjaxCallMode( ), new Object[] {(string)"",(string)"",(string)""});
         FsresultsRow.AddColumnProperties("cell", -1, isAjaxCallMode( ), new Object[] {(string)"",(string)"",(string)""});
         /* Text block */
         FsresultsRow.AddColumnProperties("label", 1, isAjaxCallMode( ), new Object[] {(string)lblDisplaytype2_icon_Internalname,(string)lblDisplaytype2_icon_Caption,(string)"",(string)"",(string)lblDisplaytype2_icon_Jsonclick,(string)"'"+sPrefix+"'"+",false,"+"'"+""+"'",(string)"",(string)"TextBlock",(short)0,(string)"",(short)1,(short)1,(short)0,(short)2});
         if ( FsresultsContainer.GetWrapped() == 1 )
         {
            FsresultsContainer.CloseTag("cell");
         }
         FsresultsRow.AddColumnProperties("cell", -1, isAjaxCallMode( ), new Object[] {(string)"",(string)"",(string)""});
         /* Div Control */
         FsresultsRow.AddColumnProperties("div_start", -1, isAjaxCallMode( ), new Object[] {(string)"",(short)1,(short)0,(string)"px",(short)0,(string)"px",(string)" gx-attribute",(string)"left",(string)"top",(string)"",(string)"",(string)"div"});
         /* Attribute/Variable Label */
         FsresultsRow.AddColumnProperties("html_label", -1, isAjaxCallMode( ), new Object[] {(string)edtavDisplaytype2_title_Internalname,(string)"Display Type2_Title",(string)"gx-form-item AttributeSearchResultTitleLabel",(short)0,(bool)true,(string)"width: 25%;"});
         /* Single line edit */
         ROClassString = "AttributeSearchResultTitle";
         FsresultsRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtavDisplaytype2_title_Internalname,(string)AV11DisplayType2_Title,(string)"",(string)"",(string)"'"+sPrefix+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtavDisplaytype2_title_Jsonclick,(short)0,(string)"AttributeSearchResultTitle",(string)"",(string)ROClassString,(string)"",(string)"",(short)1,(int)edtavDisplaytype2_title_Enabled,(short)0,(string)"text",(string)"",(short)40,(string)"chr",(short)1,(string)"row",(short)40,(short)0,(short)0,(short)29,(short)1,(short)-1,(short)-1,(bool)true,(string)"",(string)"left",(bool)true,(string)""});
         FsresultsRow.AddColumnProperties("div_end", -1, isAjaxCallMode( ), new Object[] {(string)"left",(string)"top",(string)"div"});
         if ( FsresultsContainer.GetWrapped() == 1 )
         {
            FsresultsContainer.CloseTag("cell");
         }
         if ( FsresultsContainer.GetWrapped() == 1 )
         {
            FsresultsContainer.CloseTag("row");
         }
         if ( FsresultsContainer.GetWrapped() == 1 )
         {
            FsresultsContainer.CloseTag("table");
         }
         /* End of table */
         FsresultsRow.AddColumnProperties("div_end", -1, isAjaxCallMode( ), new Object[] {(string)"left",(string)"top",(string)"div"});
         /* Div Control */
         FsresultsRow.AddColumnProperties("div_start", -1, isAjaxCallMode( ), new Object[] {(string)divDisplaytype3_cell_Internalname+"_"+sGXsfl_29_idx,(int)divDisplaytype3_cell_Visible,(short)0,(string)"px",(short)0,(string)"px",(string)"",(string)"left",(string)"top",(string)"",(string)"flex-grow:1;",(string)"div"});
         /* Div Control */
         FsresultsRow.AddColumnProperties("div_start", -1, isAjaxCallMode( ), new Object[] {(string)divUnnamedtable3_Internalname+"_"+sGXsfl_29_idx,(short)1,(short)0,(string)"px",(short)0,(string)"px",(string)"",(string)"left",(string)"top",(string)"",(string)"",(string)"div"});
         /* Div Control */
         FsresultsRow.AddColumnProperties("div_start", -1, isAjaxCallMode( ), new Object[] {(string)"",(short)1,(short)0,(string)"px",(short)0,(string)"px",(string)"row",(string)"left",(string)"top",(string)"",(string)"",(string)"div"});
         /* Div Control */
         FsresultsRow.AddColumnProperties("div_start", -1, isAjaxCallMode( ), new Object[] {(string)"",(short)1,(short)0,(string)"px",(short)0,(string)"px",(string)"col-xs-12",(string)"left",(string)"top",(string)"",(string)"",(string)"div"});
         /* Div Control */
         FsresultsRow.AddColumnProperties("div_start", -1, isAjaxCallMode( ), new Object[] {(string)"",(short)1,(short)0,(string)"px",(short)0,(string)"px",(string)" gx-attribute",(string)"left",(string)"top",(string)"",(string)"",(string)"div"});
         /* Attribute/Variable Label */
         FsresultsRow.AddColumnProperties("html_label", -1, isAjaxCallMode( ), new Object[] {(string)edtavDisplaytype3_title_Internalname,(string)"Display Type3_Title",(string)"col-sm-3 AttributeSearchResultTitleLabel",(short)0,(bool)true,(string)""});
         /* Single line edit */
         ROClassString = "AttributeSearchResultTitle";
         FsresultsRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtavDisplaytype3_title_Internalname,(string)AV13DisplayType3_Title,(string)"",(string)"",(string)"'"+sPrefix+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtavDisplaytype3_title_Jsonclick,(short)0,(string)"AttributeSearchResultTitle",(string)"",(string)ROClassString,(string)"",(string)"",(short)1,(int)edtavDisplaytype3_title_Enabled,(short)0,(string)"text",(string)"",(short)40,(string)"chr",(short)1,(string)"row",(short)40,(short)0,(short)0,(short)29,(short)1,(short)-1,(short)-1,(bool)true,(string)"",(string)"left",(bool)true,(string)""});
         FsresultsRow.AddColumnProperties("div_end", -1, isAjaxCallMode( ), new Object[] {(string)"left",(string)"top",(string)"div"});
         FsresultsRow.AddColumnProperties("div_end", -1, isAjaxCallMode( ), new Object[] {(string)"left",(string)"top",(string)"div"});
         FsresultsRow.AddColumnProperties("div_end", -1, isAjaxCallMode( ), new Object[] {(string)"left",(string)"top",(string)"div"});
         /* Div Control */
         FsresultsRow.AddColumnProperties("div_start", -1, isAjaxCallMode( ), new Object[] {(string)"",(short)1,(short)0,(string)"px",(short)0,(string)"px",(string)"row",(string)"left",(string)"top",(string)"",(string)"",(string)"div"});
         /* Div Control */
         FsresultsRow.AddColumnProperties("div_start", -1, isAjaxCallMode( ), new Object[] {(string)"",(short)1,(short)0,(string)"px",(short)0,(string)"px",(string)"col-xs-12",(string)"left",(string)"top",(string)"",(string)"",(string)"div"});
         /* Div Control */
         FsresultsRow.AddColumnProperties("div_start", -1, isAjaxCallMode( ), new Object[] {(string)"",(short)1,(short)0,(string)"px",(short)0,(string)"px",(string)" gx-attribute",(string)"left",(string)"top",(string)"",(string)"",(string)"div"});
         /* Attribute/Variable Label */
         FsresultsRow.AddColumnProperties("html_label", -1, isAjaxCallMode( ), new Object[] {(string)edtavDisplaytype3_subtitle_Internalname,(string)"Display Type3_Subtitle",(string)"col-sm-3 AttributeSearchResultSubtitleLabel",(short)0,(bool)true,(string)""});
         /* Single line edit */
         ROClassString = "AttributeSearchResultSubtitle";
         FsresultsRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtavDisplaytype3_subtitle_Internalname,(string)AV12DisplayType3_Subtitle,(string)"",(string)"",(string)"'"+sPrefix+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtavDisplaytype3_subtitle_Jsonclick,(short)0,(string)"AttributeSearchResultSubtitle",(string)"",(string)ROClassString,(string)"",(string)"",(short)1,(int)edtavDisplaytype3_subtitle_Enabled,(short)0,(string)"text",(string)"",(short)40,(string)"chr",(short)1,(string)"row",(short)40,(short)0,(short)0,(short)29,(short)1,(short)-1,(short)-1,(bool)true,(string)"",(string)"left",(bool)true,(string)""});
         FsresultsRow.AddColumnProperties("div_end", -1, isAjaxCallMode( ), new Object[] {(string)"left",(string)"top",(string)"div"});
         FsresultsRow.AddColumnProperties("div_end", -1, isAjaxCallMode( ), new Object[] {(string)"left",(string)"top",(string)"div"});
         FsresultsRow.AddColumnProperties("div_end", -1, isAjaxCallMode( ), new Object[] {(string)"left",(string)"top",(string)"div"});
         FsresultsRow.AddColumnProperties("div_end", -1, isAjaxCallMode( ), new Object[] {(string)"left",(string)"top",(string)"div"});
         FsresultsRow.AddColumnProperties("div_end", -1, isAjaxCallMode( ), new Object[] {(string)"left",(string)"top",(string)"div"});
         sendrow_29330( ) ;
      }

      protected void sendrow_29330( )
      {
         /* Div Control */
         FsresultsRow.AddColumnProperties("div_start", -1, isAjaxCallMode( ), new Object[] {(string)divDisplaytype4_cell_Internalname+"_"+sGXsfl_29_idx,(int)divDisplaytype4_cell_Visible,(short)0,(string)"px",(short)0,(string)"px",(string)"",(string)"left",(string)"top",(string)"",(string)"flex-grow:1;",(string)"div"});
         /* Div Control */
         FsresultsRow.AddColumnProperties("div_start", -1, isAjaxCallMode( ), new Object[] {(string)divUnnamedtable4_Internalname+"_"+sGXsfl_29_idx,(short)1,(short)0,(string)"px",(short)0,(string)"px",(string)"Flex",(string)"left",(string)"top",(string)" "+"data-gx-flex"+" ",(string)"",(string)"div"});
         /* Div Control */
         FsresultsRow.AddColumnProperties("div_start", -1, isAjaxCallMode( ), new Object[] {(string)"",(short)1,(short)0,(string)"px",(short)0,(string)"px",(string)"AttributeSearchResultImageCell",(string)"left",(string)"top",(string)"",(string)"",(string)"div"});
         /* Div Control */
         FsresultsRow.AddColumnProperties("div_start", -1, isAjaxCallMode( ), new Object[] {(string)"",(short)1,(short)0,(string)"px",(short)0,(string)"px",(string)" gx-attribute",(string)"left",(string)"top",(string)"",(string)"",(string)"div"});
         /* Attribute/Variable Label */
         FsresultsRow.AddColumnProperties("html_label", -1, isAjaxCallMode( ), new Object[] {(string)"",(string)"Display Type4_Image",(string)"gx-form-item AttributeSearchResultImageLabel",(short)0,(bool)true,(string)"width: 25%;"});
         /* Static Bitmap Variable */
         ClassString = "AttributeSearchResultImage";
         StyleString = "";
         AV14DisplayType4_Image_IsBlob = (bool)((String.IsNullOrEmpty(StringUtil.RTrim( AV14DisplayType4_Image))&&String.IsNullOrEmpty(StringUtil.RTrim( AV33Displaytype4_image_GXI)))||!String.IsNullOrEmpty(StringUtil.RTrim( AV14DisplayType4_Image)));
         sImgUrl = (String.IsNullOrEmpty(StringUtil.RTrim( AV14DisplayType4_Image)) ? AV33Displaytype4_image_GXI : context.PathToRelativeUrl( AV14DisplayType4_Image));
         FsresultsRow.AddColumnProperties("bitmap", 1, isAjaxCallMode( ), new Object[] {(string)edtavDisplaytype4_image_Internalname,(string)sImgUrl,(string)"",(string)"",(string)"",context.GetTheme( ),(int)edtavDisplaytype4_image_Visible,(short)0,(string)"",(string)"",(short)1,(short)-1,(short)0,(string)"",(short)0,(string)"",(short)0,(short)0,(short)0,(string)"",(string)"",(string)StyleString,(string)ClassString,(string)"",(string)"",(string)"",(string)"",(string)"",(string)"",(string)"",(short)1,(bool)AV14DisplayType4_Image_IsBlob,(bool)false,context.GetImageSrcSet( sImgUrl)});
         FsresultsRow.AddColumnProperties("div_end", -1, isAjaxCallMode( ), new Object[] {(string)"left",(string)"top",(string)"div"});
         FsresultsRow.AddColumnProperties("div_end", -1, isAjaxCallMode( ), new Object[] {(string)"left",(string)"top",(string)"div"});
         /* Div Control */
         FsresultsRow.AddColumnProperties("div_start", -1, isAjaxCallMode( ), new Object[] {(string)"",(short)1,(short)0,(string)"px",(short)0,(string)"px",(string)"",(string)"left",(string)"top",(string)"",(string)"flex-grow:1;",(string)"div"});
         /* Div Control */
         FsresultsRow.AddColumnProperties("div_start", -1, isAjaxCallMode( ), new Object[] {(string)"",(short)1,(short)0,(string)"px",(short)0,(string)"px",(string)" gx-attribute",(string)"left",(string)"top",(string)"",(string)"",(string)"div"});
         /* Attribute/Variable Label */
         FsresultsRow.AddColumnProperties("html_label", -1, isAjaxCallMode( ), new Object[] {(string)edtavDisplaytype4_title_Internalname,(string)"Display Type4_Title",(string)"gx-form-item AttributeSearchResultTitleLabel",(short)0,(bool)true,(string)"width: 25%;"});
         /* Single line edit */
         ROClassString = "AttributeSearchResultTitle";
         FsresultsRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtavDisplaytype4_title_Internalname,(string)AV15DisplayType4_Title,(string)"",(string)"",(string)"'"+sPrefix+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtavDisplaytype4_title_Jsonclick,(short)0,(string)"AttributeSearchResultTitle",(string)"",(string)ROClassString,(string)"",(string)"",(short)1,(int)edtavDisplaytype4_title_Enabled,(short)0,(string)"text",(string)"",(short)40,(string)"chr",(short)1,(string)"row",(short)40,(short)0,(short)0,(short)29,(short)1,(short)-1,(short)-1,(bool)true,(string)"",(string)"left",(bool)true,(string)""});
         FsresultsRow.AddColumnProperties("div_end", -1, isAjaxCallMode( ), new Object[] {(string)"left",(string)"top",(string)"div"});
         FsresultsRow.AddColumnProperties("div_end", -1, isAjaxCallMode( ), new Object[] {(string)"left",(string)"top",(string)"div"});
         FsresultsRow.AddColumnProperties("div_end", -1, isAjaxCallMode( ), new Object[] {(string)"left",(string)"top",(string)"div"});
         FsresultsRow.AddColumnProperties("div_end", -1, isAjaxCallMode( ), new Object[] {(string)"left",(string)"top",(string)"div"});
         /* Div Control */
         FsresultsRow.AddColumnProperties("div_start", -1, isAjaxCallMode( ), new Object[] {(string)divDisplaytype5_cell_Internalname+"_"+sGXsfl_29_idx,(int)divDisplaytype5_cell_Visible,(short)0,(string)"px",(short)0,(string)"px",(string)"",(string)"left",(string)"top",(string)"",(string)"flex-grow:1;",(string)"div"});
         /* Table start */
         FsresultsRow.AddColumnProperties("table", -1, isAjaxCallMode( ), new Object[] {(string)tblUnnamedtable5_Internalname+"_"+sGXsfl_29_idx,(short)1,(string)"",(string)"",(string)"",(string)"",(string)"",(string)"",(string)"",(short)1,(short)2,(string)"",(string)"",(string)"",(string)"px",(string)"px",(string)""});
         FsresultsRow.AddColumnProperties("row", -1, isAjaxCallMode( ), new Object[] {(string)"",(string)"",(string)""});
         FsresultsRow.AddColumnProperties("cell", -1, isAjaxCallMode( ), new Object[] {(string)"",(string)"",(string)""});
         /* Text block */
         FsresultsRow.AddColumnProperties("label", 1, isAjaxCallMode( ), new Object[] {(string)lblDisplaytype5_icon_Internalname,(string)lblDisplaytype5_icon_Caption,(string)"",(string)"",(string)lblDisplaytype5_icon_Jsonclick,(string)"'"+sPrefix+"'"+",false,"+"'"+""+"'",(string)"",(string)"TextBlock",(short)0,(string)"",(short)1,(short)1,(short)0,(short)2});
         if ( FsresultsContainer.GetWrapped() == 1 )
         {
            FsresultsContainer.CloseTag("cell");
         }
         FsresultsRow.AddColumnProperties("cell", -1, isAjaxCallMode( ), new Object[] {(string)"",(string)"",(string)""});
         /* Div Control */
         FsresultsRow.AddColumnProperties("div_start", -1, isAjaxCallMode( ), new Object[] {(string)divUnnamedtable6_Internalname+"_"+sGXsfl_29_idx,(short)1,(short)0,(string)"px",(short)0,(string)"px",(string)"",(string)"left",(string)"top",(string)"",(string)"",(string)"div"});
         /* Div Control */
         FsresultsRow.AddColumnProperties("div_start", -1, isAjaxCallMode( ), new Object[] {(string)"",(short)1,(short)0,(string)"px",(short)0,(string)"px",(string)"row",(string)"left",(string)"top",(string)"",(string)"",(string)"div"});
         /* Div Control */
         FsresultsRow.AddColumnProperties("div_start", -1, isAjaxCallMode( ), new Object[] {(string)"",(short)1,(short)0,(string)"px",(short)0,(string)"px",(string)"col-xs-12",(string)"left",(string)"top",(string)"",(string)"",(string)"div"});
         /* Div Control */
         FsresultsRow.AddColumnProperties("div_start", -1, isAjaxCallMode( ), new Object[] {(string)"",(short)1,(short)0,(string)"px",(short)0,(string)"px",(string)" gx-attribute",(string)"left",(string)"top",(string)"",(string)"",(string)"div"});
         /* Attribute/Variable Label */
         FsresultsRow.AddColumnProperties("html_label", -1, isAjaxCallMode( ), new Object[] {(string)edtavDisplaytype5_title_Internalname,(string)"Display Type5_Title",(string)"col-sm-3 AttributeSearchResultTitleLabel",(short)0,(bool)true,(string)""});
         /* Single line edit */
         ROClassString = "AttributeSearchResultTitle";
         FsresultsRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtavDisplaytype5_title_Internalname,(string)AV17DisplayType5_Title,(string)"",(string)"",(string)"'"+sPrefix+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtavDisplaytype5_title_Jsonclick,(short)0,(string)"AttributeSearchResultTitle",(string)"",(string)ROClassString,(string)"",(string)"",(short)1,(int)edtavDisplaytype5_title_Enabled,(short)0,(string)"text",(string)"",(short)40,(string)"chr",(short)1,(string)"row",(short)40,(short)0,(short)0,(short)29,(short)1,(short)-1,(short)-1,(bool)true,(string)"",(string)"left",(bool)true,(string)""});
         FsresultsRow.AddColumnProperties("div_end", -1, isAjaxCallMode( ), new Object[] {(string)"left",(string)"top",(string)"div"});
         FsresultsRow.AddColumnProperties("div_end", -1, isAjaxCallMode( ), new Object[] {(string)"left",(string)"top",(string)"div"});
         FsresultsRow.AddColumnProperties("div_end", -1, isAjaxCallMode( ), new Object[] {(string)"left",(string)"top",(string)"div"});
         /* Div Control */
         FsresultsRow.AddColumnProperties("div_start", -1, isAjaxCallMode( ), new Object[] {(string)"",(short)1,(short)0,(string)"px",(short)0,(string)"px",(string)"row",(string)"left",(string)"top",(string)"",(string)"",(string)"div"});
         /* Div Control */
         FsresultsRow.AddColumnProperties("div_start", -1, isAjaxCallMode( ), new Object[] {(string)"",(short)1,(short)0,(string)"px",(short)0,(string)"px",(string)"col-xs-12",(string)"left",(string)"top",(string)"",(string)"",(string)"div"});
         /* Div Control */
         FsresultsRow.AddColumnProperties("div_start", -1, isAjaxCallMode( ), new Object[] {(string)"",(short)1,(short)0,(string)"px",(short)0,(string)"px",(string)" gx-attribute",(string)"left",(string)"top",(string)"",(string)"",(string)"div"});
         /* Attribute/Variable Label */
         FsresultsRow.AddColumnProperties("html_label", -1, isAjaxCallMode( ), new Object[] {(string)edtavDisplaytype5_subtitle_Internalname,(string)"Display Type5_Subtitle",(string)"col-sm-3 AttributeSearchResultSubtitleLabel",(short)0,(bool)true,(string)""});
         /* Single line edit */
         ROClassString = "AttributeSearchResultSubtitle";
         FsresultsRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtavDisplaytype5_subtitle_Internalname,(string)AV16DisplayType5_Subtitle,(string)"",(string)"",(string)"'"+sPrefix+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtavDisplaytype5_subtitle_Jsonclick,(short)0,(string)"AttributeSearchResultSubtitle",(string)"",(string)ROClassString,(string)"",(string)"",(short)1,(int)edtavDisplaytype5_subtitle_Enabled,(short)0,(string)"text",(string)"",(short)40,(string)"chr",(short)1,(string)"row",(short)40,(short)0,(short)0,(short)29,(short)1,(short)-1,(short)-1,(bool)true,(string)"",(string)"left",(bool)true,(string)""});
         FsresultsRow.AddColumnProperties("div_end", -1, isAjaxCallMode( ), new Object[] {(string)"left",(string)"top",(string)"div"});
         FsresultsRow.AddColumnProperties("div_end", -1, isAjaxCallMode( ), new Object[] {(string)"left",(string)"top",(string)"div"});
         FsresultsRow.AddColumnProperties("div_end", -1, isAjaxCallMode( ), new Object[] {(string)"left",(string)"top",(string)"div"});
         FsresultsRow.AddColumnProperties("div_end", -1, isAjaxCallMode( ), new Object[] {(string)"left",(string)"top",(string)"div"});
         if ( FsresultsContainer.GetWrapped() == 1 )
         {
            FsresultsContainer.CloseTag("cell");
         }
         if ( FsresultsContainer.GetWrapped() == 1 )
         {
            FsresultsContainer.CloseTag("row");
         }
         if ( FsresultsContainer.GetWrapped() == 1 )
         {
            FsresultsContainer.CloseTag("table");
         }
         /* End of table */
         FsresultsRow.AddColumnProperties("div_end", -1, isAjaxCallMode( ), new Object[] {(string)"left",(string)"top",(string)"div"});
         FsresultsRow.AddColumnProperties("div_end", -1, isAjaxCallMode( ), new Object[] {(string)"left",(string)"top",(string)"div"});
         send_integrity_lvl_hashes3I3( ) ;
         /* End of Columns property logic. */
         FsresultsContainer.AddRow(FsresultsRow);
         nGXsfl_29_idx = ((subFsresults_Islastpage==1)&&(nGXsfl_29_idx+1>subFsresults_fnc_Recordsperpage( )) ?