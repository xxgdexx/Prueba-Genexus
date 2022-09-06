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
   public class home : GXDataArea
   {
      public home( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDataStore2 = context.GetDataStore("DataStore2");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusTheme");
      }

      public home( IGxContext context )
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
            else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxNewRow_"+"Grid") == 0 )
            {
               nRC_GXsfl_147 = (int)(NumberUtil.Val( GetPar( "nRC_GXsfl_147"), "."));
               nGXsfl_147_idx = (int)(NumberUtil.Val( GetPar( "nGXsfl_147_idx"), "."));
               sGXsfl_147_idx = GetPar( "sGXsfl_147_idx");
               setAjaxCallMode();
               if ( ! IsValidAjaxCall( true) )
               {
                  GxWebError = 1;
                  return  ;
               }
               gxnrGrid_newrow( ) ;
               return  ;
            }
            else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxGridRefresh_"+"Grid") == 0 )
            {
               subGrid_Rows = (int)(NumberUtil.Val( GetPar( "subGrid_Rows"), "."));
               setAjaxCallMode();
               if ( ! IsValidAjaxCall( true) )
               {
                  GxWebError = 1;
                  return  ;
               }
               gxgrGrid_refresh( subGrid_Rows) ;
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
         PA0K2( ) ;
         gxajaxcallmode = (short)((isAjaxCallMode( ) ? 1 : 0));
         if ( ( gxajaxcallmode == 0 ) && ( GxWebError == 0 ) )
         {
            START0K2( ) ;
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
         context.AddJavascriptSource("gxcfg.js", "?20228181028518", false, true);
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
         context.AddJavascriptSource("DVelop/Bootstrap/Panel/BootstrapPanelRender.js", "", false, true);
         context.AddJavascriptSource("DVelop/Bootstrap/Shared/DVelopBootstrap.js", "", false, true);
         context.AddJavascriptSource("DVelop/Shared/WorkWithPlusCommon.js", "", false, true);
         context.AddJavascriptSource("DVelop/Bootstrap/Panel/BootstrapPanelRender.js", "", false, true);
         context.AddJavascriptSource("QueryViewer/QueryViewerCommon.js", "", false, true);
         context.AddJavascriptSource("QueryViewer/QueryViewerRender.js", "", false, true);
         context.AddJavascriptSource("DVelop/Shared/WorkWithPlusCommon.js", "", false, true);
         context.AddJavascriptSource("DVelop/Bootstrap/DVProgressIndicator/DVProgressIndicatorRender.js", "", false, true);
         context.AddJavascriptSource("DVelop/Shared/WorkWithPlusCommon.js", "", false, true);
         context.AddJavascriptSource("DVelop/Bootstrap/DVProgressIndicator/DVProgressIndicatorRender.js", "", false, true);
         context.AddJavascriptSource("DVelop/Shared/WorkWithPlusCommon.js", "", false, true);
         context.AddJavascriptSource("DVelop/Bootstrap/DVProgressIndicator/DVProgressIndicatorRender.js", "", false, true);
         context.AddJavascriptSource("DVelop/Shared/WorkWithPlusCommon.js", "", false, true);
         context.AddJavascriptSource("DVelop/Bootstrap/DVProgressIndicator/DVProgressIndicatorRender.js", "", false, true);
         context.AddJavascriptSource("DVelop/Bootstrap/Shared/DVelopBootstrap.js", "", false, true);
         context.AddJavascriptSource("DVelop/Shared/WorkWithPlusCommon.js", "", false, true);
         context.AddJavascriptSource("DVelop/Bootstrap/Panel/BootstrapPanelRender.js", "", false, true);
         context.AddJavascriptSource("QueryViewer/QueryViewerCommon.js", "", false, true);
         context.AddJavascriptSource("QueryViewer/QueryViewerRender.js", "", false, true);
         context.AddJavascriptSource("DVelop/Bootstrap/Shared/DVelopBootstrap.js", "", false, true);
         context.AddJavascriptSource("DVelop/Shared/WorkWithPlusCommon.js", "", false, true);
         context.AddJavascriptSource("DVelop/Bootstrap/Panel/BootstrapPanelRender.js", "", false, true);
         context.AddJavascriptSource("QueryViewer/QueryViewerCommon.js", "", false, true);
         context.AddJavascriptSource("QueryViewer/QueryViewerRender.js", "", false, true);
         context.AddJavascriptSource("DVelop/Shared/WorkWithPlusCommon.js", "", false, true);
         context.AddJavascriptSource("DVelop/GridEmpowerer/GridEmpowererRender.js", "", false, true);
         context.WriteHtmlText( Form.Headerrawhtml) ;
         context.CloseHtmlHeader();
         if ( context.isSpaRequest( ) )
         {
            disableOutput();
         }
         FormProcess = ((nGXWrapped==0) ? " data-HasEnter=\"false\" data-Skiponenter=\"false\"" : "");
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
         if ( nGXWrapped != 1 )
         {
            context.WriteHtmlTextNl( "<form id=\"MAINFORM\" autocomplete=\"off\" name=\"MAINFORM\" method=\"post\" tabindex=-1  class=\"form-horizontal Form\" data-gx-class=\"form-horizontal Form\" novalidate action=\""+formatLink("wwpbaseobjects.home.aspx") +"\">") ;
            GxWebStd.gx_hidden_field( context, "_EventName", "");
            GxWebStd.gx_hidden_field( context, "_EventGridId", "");
            GxWebStd.gx_hidden_field( context, "_EventRowId", "");
            context.WriteHtmlText( "<input type=\"submit\" title=\"submit\" style=\"display:block;height:0;border:0;padding:0\" disabled>") ;
            AssignProp("", false, "FORM", "Class", "form-horizontal Form", true);
         }
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
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "Wwp_sdtnotificationsdata", AV24WWP_SDTNotificationsData);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt("Wwp_sdtnotificationsdata", AV24WWP_SDTNotificationsData);
         }
         GxWebStd.gx_hidden_field( context, "nRC_GXsfl_147", StringUtil.LTrim( StringUtil.NToC( (decimal)(nRC_GXsfl_147), 8, 0, ".", "")));
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "vELEMENTS", AV14Elements);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt("vELEMENTS", AV14Elements);
         }
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "vPARAMETERS", AV15Parameters);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt("vPARAMETERS", AV15Parameters);
         }
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "vITEMCLICKDATA", AV16ItemClickData);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt("vITEMCLICKDATA", AV16ItemClickData);
         }
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "vITEMDOUBLECLICKDATA", AV17ItemDoubleClickData);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt("vITEMDOUBLECLICKDATA", AV17ItemDoubleClickData);
         }
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "vDRAGANDDROPDATA", AV18DragAndDropData);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt("vDRAGANDDROPDATA", AV18DragAndDropData);
         }
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "vFILTERCHANGEDDATA", AV19FilterChangedData);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt("vFILTERCHANGEDDATA", AV19FilterChangedData);
         }
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "vITEMEXPANDDATA", AV20ItemExpandData);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt("vITEMEXPANDDATA", AV20ItemExpandData);
         }
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "vITEMCOLLAPSEDATA", AV21ItemCollapseData);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt("vITEMCOLLAPSEDATA", AV21ItemCollapseData);
         }
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "vWWP_SDTNOTIFICATIONSDATA", AV24WWP_SDTNotificationsData);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt("vWWP_SDTNOTIFICATIONSDATA", AV24WWP_SDTNotificationsData);
         }
         GxWebStd.gx_hidden_field( context, "GRID_nFirstRecordOnPage", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRID_nFirstRecordOnPage), 15, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "GRID_nEOF", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRID_nEOF), 1, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "GRID_Rows", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid_Rows), 6, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "DVPANEL_TABLECARDS_Width", StringUtil.RTrim( Dvpanel_tablecards_Width));
         GxWebStd.gx_hidden_field( context, "DVPANEL_TABLECARDS_Autowidth", StringUtil.BoolToStr( Dvpanel_tablecards_Autowidth));
         GxWebStd.gx_hidden_field( context, "DVPANEL_TABLECARDS_Autoheight", StringUtil.BoolToStr( Dvpanel_tablecards_Autoheight));
         GxWebStd.gx_hidden_field( context, "DVPANEL_TABLECARDS_Cls", StringUtil.RTrim( Dvpanel_tablecards_Cls));
         GxWebStd.gx_hidden_field( context, "DVPANEL_TABLECARDS_Title", StringUtil.RTrim( Dvpanel_tablecards_Title));
         GxWebStd.gx_hidden_field( context, "DVPANEL_TABLECARDS_Collapsible", StringUtil.BoolToStr( Dvpanel_tablecards_Collapsible));
         GxWebStd.gx_hidden_field( context, "DVPANEL_TABLECARDS_Collapsed", StringUtil.BoolToStr( Dvpanel_tablecards_Collapsed));
         GxWebStd.gx_hidden_field( context, "DVPANEL_TABLECARDS_Showcollapseicon", StringUtil.BoolToStr( Dvpanel_tablecards_Showcollapseicon));
         GxWebStd.gx_hidden_field( context, "DVPANEL_TABLECARDS_Iconposition", StringUtil.RTrim( Dvpanel_tablecards_Iconposition));
         GxWebStd.gx_hidden_field( context, "DVPANEL_TABLECARDS_Autoscroll", StringUtil.BoolToStr( Dvpanel_tablecards_Autoscroll));
         GxWebStd.gx_hidden_field( context, "DVPANEL_TABLENOTIFICATIONS_Width", StringUtil.RTrim( Dvpanel_tablenotifications_Width));
         GxWebStd.gx_hidden_field( context, "DVPANEL_TABLENOTIFICATIONS_Autowidth", StringUtil.BoolToStr( Dvpanel_tablenotifications_Autowidth));
         GxWebStd.gx_hidden_field( context, "DVPANEL_TABLENOTIFICATIONS_Autoheight", StringUtil.BoolToStr( Dvpanel_tablenotifications_Autoheight));
         GxWebStd.gx_hidden_field( context, "DVPANEL_TABLENOTIFICATIONS_Cls", StringUtil.RTrim( Dvpanel_tablenotifications_Cls));
         GxWebStd.gx_hidden_field( context, "DVPANEL_TABLENOTIFICATIONS_Title", StringUtil.RTrim( Dvpanel_tablenotifications_Title));
         GxWebStd.gx_hidden_field( context, "DVPANEL_TABLENOTIFICATIONS_Collapsible", StringUtil.BoolToStr( Dvpanel_tablenotifications_Collapsible));
         GxWebStd.gx_hidden_field( context, "DVPANEL_TABLENOTIFICATIONS_Collapsed", StringUtil.BoolToStr( Dvpanel_tablenotifications_Collapsed));
         GxWebStd.gx_hidden_field( context, "DVPANEL_TABLENOTIFICATIONS_Showcollapseicon", StringUtil.BoolToStr( Dvpanel_tablenotifications_Showcollapseicon));
         GxWebStd.gx_hidden_field( context, "DVPANEL_TABLENOTIFICATIONS_Iconposition", StringUtil.RTrim( Dvpanel_tablenotifications_Iconposition));
         GxWebStd.gx_hidden_field( context, "DVPANEL_TABLENOTIFICATIONS_Autoscroll", StringUtil.BoolToStr( Dvpanel_tablenotifications_Autoscroll));
         GxWebStd.gx_hidden_field( context, "UTCHARTSMOOTHAREA_Class", StringUtil.RTrim( Utchartsmootharea_Class));
         GxWebStd.gx_hidden_field( context, "UTCHARTSMOOTHAREA_Height", StringUtil.RTrim( Utchartsmootharea_Height));
         GxWebStd.gx_hidden_field( context, "UTCHARTSMOOTHAREA_Type", StringUtil.RTrim( Utchartsmootharea_Type));
         GxWebStd.gx_hidden_field( context, "UTCHARTSMOOTHAREA_Charttype", StringUtil.RTrim( Utchartsmootharea_Charttype));
         GxWebStd.gx_hidden_field( context, "UTCHARTSMOOTHAREA_Xaxistitle", StringUtil.RTrim( Utchartsmootharea_Xaxistitle));
         GxWebStd.gx_hidden_field( context, "PROGRESSBAR1_Type", StringUtil.RTrim( Progressbar1_Type));
         GxWebStd.gx_hidden_field( context, "PROGRESSBAR1_Cls", StringUtil.RTrim( Progressbar1_Cls));
         GxWebStd.gx_hidden_field( context, "PROGRESSBAR1_Percentage", StringUtil.LTrim( StringUtil.NToC( (decimal)(Progressbar1_Percentage), 9, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "PROGRESSBAR2_Type", StringUtil.RTrim( Progressbar2_Type));
         GxWebStd.gx_hidden_field( context, "PROGRESSBAR2_Cls", StringUtil.RTrim( Progressbar2_Cls));
         GxWebStd.gx_hidden_field( context, "PROGRESSBAR2_Percentage", StringUtil.LTrim( StringUtil.NToC( (decimal)(Progressbar2_Percentage), 9, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "PROGRESSBAR3_Type", StringUtil.RTrim( Progressbar3_Type));
         GxWebStd.gx_hidden_field( context, "PROGRESSBAR3_Cls", StringUtil.RTrim( Progressbar3_Cls));
         GxWebStd.gx_hidden_field( context, "PROGRESSBAR3_Percentage", StringUtil.LTrim( StringUtil.NToC( (decimal)(Progressbar3_Percentage), 9, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "PROGRESSBAR4_Type", StringUtil.RTrim( Progressbar4_Type));
         GxWebStd.gx_hidden_field( context, "PROGRESSBAR4_Cls", StringUtil.RTrim( Progressbar4_Cls));
         GxWebStd.gx_hidden_field( context, "PROGRESSBAR4_Percentage", StringUtil.LTrim( StringUtil.NToC( (decimal)(Progressbar4_Percentage), 9, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "DVPANEL_TABLECHART1_Width", StringUtil.RTrim( Dvpanel_tablechart1_Width));
         GxWebStd.gx_hidden_field( context, "DVPANEL_TABLECHART1_Autowidth", StringUtil.BoolToStr( Dvpanel_tablechart1_Autowidth));
         GxWebStd.gx_hidden_field( context, "DVPANEL_TABLECHART1_Autoheight", StringUtil.BoolToStr( Dvpanel_tablechart1_Autoheight));
         GxWebStd.gx_hidden_field( context, "DVPANEL_TABLECHART1_Cls", StringUtil.RTrim( Dvpanel_tablechart1_Cls));
         GxWebStd.gx_hidden_field( context, "DVPANEL_TABLECHART1_Title", StringUtil.RTrim( Dvpanel_tablechart1_Title));
         GxWebStd.gx_hidden_field( context, "DVPANEL_TABLECHART1_Collapsible", StringUtil.BoolToStr( Dvpanel_tablechart1_Collapsible));
         GxWebStd.gx_hidden_field( context, "DVPANEL_TABLECHART1_Collapsed", StringUtil.BoolToStr( Dvpanel_tablechart1_Collapsed));
         GxWebStd.gx_hidden_field( context, "DVPANEL_TABLECHART1_Showcollapseicon", StringUtil.BoolToStr( Dvpanel_tablechart1_Showcollapseicon));
         GxWebStd.gx_hidden_field( context, "DVPANEL_TABLECHART1_Iconposition", StringUtil.RTrim( Dvpanel_tablechart1_Iconposition));
         GxWebStd.gx_hidden_field( context, "DVPANEL_TABLECHART1_Autoscroll", StringUtil.BoolToStr( Dvpanel_tablechart1_Autoscroll));
         GxWebStd.gx_hidden_field( context, "UTCHARTSMOOTHLINE_Height", StringUtil.RTrim( Utchartsmoothline_Height));
         GxWebStd.gx_hidden_field( context, "UTCHARTSMOOTHLINE_Type", StringUtil.RTrim( Utchartsmoothline_Type));
         GxWebStd.gx_hidden_field( context, "UTCHARTSMOOTHLINE_Charttype", StringUtil.RTrim( Utchartsmoothline_Charttype));
         GxWebStd.gx_hidden_field( context, "UTCHARTSMOOTHLINE_Xaxistitle", StringUtil.RTrim( Utchartsmoothline_Xaxistitle));
         GxWebStd.gx_hidden_field( context, "DVPANEL_TABLECHART4_Width", StringUtil.RTrim( Dvpanel_tablechart4_Width));
         GxWebStd.gx_hidden_field( context, "DVPANEL_TABLECHART4_Autowidth", StringUtil.BoolToStr( Dvpanel_tablechart4_Autowidth));
         GxWebStd.gx_hidden_field( context, "DVPANEL_TABLECHART4_Autoheight", StringUtil.BoolToStr( Dvpanel_tablechart4_Autoheight));
         GxWebStd.gx_hidden_field( context, "DVPANEL_TABLECHART4_Cls", StringUtil.RTrim( Dvpanel_tablechart4_Cls));
         GxWebStd.gx_hidden_field( context, "DVPANEL_TABLECHART4_Title", StringUtil.RTrim( Dvpanel_tablechart4_Title));
         GxWebStd.gx_hidden_field( context, "DVPANEL_TABLECHART4_Collapsible", StringUtil.BoolToStr( Dvpanel_tablechart4_Collapsible));
         GxWebStd.gx_hidden_field( context, "DVPANEL_TABLECHART4_Collapsed", StringUtil.BoolToStr( Dvpanel_tablechart4_Collapsed));
         GxWebStd.gx_hidden_field( context, "DVPANEL_TABLECHART4_Showcollapseicon", StringUtil.BoolToStr( Dvpanel_tablechart4_Showcollapseicon));
         GxWebStd.gx_hidden_field( context, "DVPANEL_TABLECHART4_Iconposition", StringUtil.RTrim( Dvpanel_tablechart4_Iconposition));
         GxWebStd.gx_hidden_field( context, "DVPANEL_TABLECHART4_Autoscroll", StringUtil.BoolToStr( Dvpanel_tablechart4_Autoscroll));
         GxWebStd.gx_hidden_field( context, "UTCHARTDOUGHNUT_Height", StringUtil.RTrim( Utchartdoughnut_Height));
         GxWebStd.gx_hidden_field( context, "UTCHARTDOUGHNUT_Type", StringUtil.RTrim( Utchartdoughnut_Type));
         GxWebStd.gx_hidden_field( context, "UTCHARTDOUGHNUT_Showvalues", StringUtil.BoolToStr( Utchartdoughnut_Showvalues));
         GxWebStd.gx_hidden_field( context, "UTCHARTDOUGHNUT_Charttype", StringUtil.RTrim( Utchartdoughnut_Charttype));
         GxWebStd.gx_hidden_field( context, "DVPANEL_TABLECHART3_Width", StringUtil.RTrim( Dvpanel_tablechart3_Width));
         GxWebStd.gx_hidden_field( context, "DVPANEL_TABLECHART3_Autowidth", StringUtil.BoolToStr( Dvpanel_tablechart3_Autowidth));
         GxWebStd.gx_hidden_field( context, "DVPANEL_TABLECHART3_Autoheight", StringUtil.BoolToStr( Dvpanel_tablechart3_Autoheight));
         GxWebStd.gx_hidden_field( context, "DVPANEL_TABLECHART3_Cls", StringUtil.RTrim( Dvpanel_tablechart3_Cls));
         GxWebStd.gx_hidden_field( context, "DVPANEL_TABLECHART3_Title", StringUtil.RTrim( Dvpanel_tablechart3_Title));
         GxWebStd.gx_hidden_field( context, "DVPANEL_TABLECHART3_Collapsible", StringUtil.BoolToStr( Dvpanel_tablechart3_Collapsible));
         GxWebStd.gx_hidden_field( context, "DVPANEL_TABLECHART3_Collapsed", StringUtil.BoolToStr( Dvpanel_tablechart3_Collapsed));
         GxWebStd.gx_hidden_field( context, "DVPANEL_TABLECHART3_Showcollapseicon", StringUtil.BoolToStr( Dvpanel_tablechart3_Showcollapseicon));
         GxWebStd.gx_hidden_field( context, "DVPANEL_TABLECHART3_Iconposition", StringUtil.RTrim( Dvpanel_tablechart3_Iconposition));
         GxWebStd.gx_hidden_field( context, "DVPANEL_TABLECHART3_Autoscroll", StringUtil.BoolToStr( Dvpanel_tablechart3_Autoscroll));
         GxWebStd.gx_hidden_field( context, "GRID_EMPOWERER_Gridinternalname", StringUtil.RTrim( Grid_empowerer_Gridinternalname));
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
         if ( nGXWrapped != 1 )
         {
            context.WriteHtmlTextNl( "</form>") ;
         }
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
            WE0K2( ) ;
            context.WriteHtmlText( "</div>") ;
         }
      }

      public override void DispatchEvents( )
      {
         EVT0K2( ) ;
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
         return formatLink("wwpbaseobjects.home.aspx")  ;
      }

      public override string GetPgmname( )
      {
         return "WWPBaseObjects.Home" ;
      }

      public override string GetPgmdesc( )
      {
         return "Inicio" ;
      }

      protected void WB0K0( )
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
            GxWebStd.gx_msg_list( context, "", context.GX_msglist.DisplayMode, "", "", "", "false");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "Section", "left", "top", " "+"data-gx-base-lib=\"bootstrapv3\""+" "+"data-abstract-form"+" ", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divLayoutmaintable_Internalname, 1, 0, "px", 0, "px", "Table", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divTablemain_Internalname, 1, 0, "px", 0, "px", "", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 CellMarginTop", "left", "top", "", "", "div");
            /* User Defined Control */
            ucDvpanel_tablecards.SetProperty("Width", Dvpanel_tablecards_Width);
            ucDvpanel_tablecards.SetProperty("AutoWidth", Dvpanel_tablecards_Autowidth);
            ucDvpanel_tablecards.SetProperty("AutoHeight", Dvpanel_tablecards_Autoheight);
            ucDvpanel_tablecards.SetProperty("Cls", Dvpanel_tablecards_Cls);
            ucDvpanel_tablecards.SetProperty("Title", Dvpanel_tablecards_Title);
            ucDvpanel_tablecards.SetProperty("Collapsible", Dvpanel_tablecards_Collapsible);
            ucDvpanel_tablecards.SetProperty("Collapsed", Dvpanel_tablecards_Collapsed);
            ucDvpanel_tablecards.SetProperty("ShowCollapseIcon", Dvpanel_tablecards_Showcollapseicon);
            ucDvpanel_tablecards.SetProperty("IconPosition", Dvpanel_tablecards_Iconposition);
            ucDvpanel_tablecards.SetProperty("AutoScroll", Dvpanel_tablecards_Autoscroll);
            ucDvpanel_tablecards.Render(context, "dvelop.gxbootstrap.panel_al", Dvpanel_tablecards_Internalname, "DVPANEL_TABLECARDSContainer");
            context.WriteHtmlText( "<div class=\"gx_usercontrol_child\" id=\""+"DVPANEL_TABLECARDSContainer"+"TableCards"+"\" style=\"display:none;\">") ;
            /* Div Control */
            GxWebStd.gx_div_start( context, divTablecards_Internalname, 1, 0, "px", 0, "px", "PanelCardContainer", "left", "top", " "+"data-gx-flex"+" ", "flex-wrap:wrap;", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "CellPaddingTop", "left", "top", "", "flex-grow:1;", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divCard1_Internalname, 1, 0, "px", 0, "px", "TableCardNumber", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "Center", "top", "", "", "div");
            wb_table1_16_0K2( true) ;
         }
         else
         {
            wb_table1_16_0K2( false) ;
         }
         return  ;
      }

      protected void wb_table1_16_0K2e( bool wbgen )
      {
         if ( wbgen )
         {
            GxWebStd.gx_div_end( context, "Center", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "Center", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "left", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavValuecard1_Internalname, "Value Card1", "col-sm-3 DashboardNumberCardNoBorderLabel", 0, true, "");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 25,'',false,'" + sGXsfl_147_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavValuecard1_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(AV8ValueCard1), 10, 0, ".", "")), StringUtil.LTrim( ((edtavValuecard1_Enabled!=0) ? context.localUtil.Format( (decimal)(AV8ValueCard1), "ZZ,ZZZ,ZZ9") : context.localUtil.Format( (decimal)(AV8ValueCard1), "ZZ,ZZZ,ZZ9"))), TempTags+" onchange=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onblur(this,25);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavValuecard1_Jsonclick, 0, "DashboardNumberCardNoBorder", "", "", "", "", 1, edtavValuecard1_Enabled, 0, "text", "", 10, "chr", 1, "row", 10, 0, 0, 0, 1, -1, 0, true, "KPINumericValue", "right", false, "", "HLP_WWPBaseObjects\\Home.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "Center", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "Center", "top", "", "", "div");
            wb_table2_28_0K2( true) ;
         }
         else
         {
            wb_table2_28_0K2( false) ;
         }
         return  ;
      }

      protected void wb_table2_28_0K2e( bool wbgen )
      {
         if ( wbgen )
         {
            GxWebStd.gx_div_end( context, "Center", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "CellPaddingTop", "left", "top", "", "flex-grow:1;", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divCard2_Internalname, 1, 0, "px", 0, "px", "TableCardNumber", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "Center", "top", "", "", "div");
            wb_table3_41_0K2( true) ;
         }
         else
         {
            wb_table3_41_0K2( false) ;
         }
         return  ;
      }

      protected void wb_table3_41_0K2e( bool wbgen )
      {
         if ( wbgen )
         {
            GxWebStd.gx_div_end( context, "Center", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "Center", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "left", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavValuecard2_Internalname, "Value Card2", "col-sm-3 DashboardNumberCardNoBorderLabel", 0, true, "");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 50,'',false,'" + sGXsfl_147_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavValuecard2_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(AV9ValueCard2), 11, 0, ".", "")), StringUtil.LTrim( ((edtavValuecard2_Enabled!=0) ? context.localUtil.Format( (decimal)(AV9ValueCard2), "$ZZ,ZZZ,ZZ9") : context.localUtil.Format( (decimal)(AV9ValueCard2), "$ZZ,ZZZ,ZZ9"))), TempTags+" onchange=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onblur(this,50);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavValuecard2_Jsonclick, 0, "DashboardNumberCardNoBorder", "", "", "", "", 1, edtavValuecard2_Enabled, 0, "text", "", 11, "chr", 1, "row", 11, 0, 0, 0, 1, -1, 0, true, "KPIPrice", "right", false, "", "HLP_WWPBaseObjects\\Home.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "Center", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "Center", "top", "", "", "div");
            wb_table4_53_0K2( true) ;
         }
         else
         {
            wb_table4_53_0K2( false) ;
         }
         return  ;
      }

      protected void wb_table4_53_0K2e( bool wbgen )
      {
         if ( wbgen )
         {
            GxWebStd.gx_div_end( context, "Center", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "CellPaddingTop", "left", "top", "", "flex-grow:1;", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divCard3_Internalname, 1, 0, "px", 0, "px", "TableCardNumber", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "Center", "top", "", "", "div");
            wb_table5_66_0K2( true) ;
         }
         else
         {
            wb_table5_66_0K2( false) ;
         }
         return  ;
      }

      protected void wb_table5_66_0K2e( bool wbgen )
      {
         if ( wbgen )
         {
            GxWebStd.gx_div_end( context, "Center", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "Center", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "left", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavValuecard3_Internalname, "Value Card3", "col-sm-3 DashboardNumberCardNoBorderLabel", 0, true, "");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 75,'',false,'" + sGXsfl_147_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavValuecard3_Internalname, AV10ValueCard3, StringUtil.RTrim( context.localUtil.Format( AV10ValueCard3, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,75);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavValuecard3_Jsonclick, 0, "DashboardNumberCardNoBorder", "", "", "", "", 1, edtavValuecard3_Enabled, 0, "text", "", 40, "chr", 1, "row", 40, 0, 0, 0, 1, -1, -1, true, "KPIVarchar", "left", true, "", "HLP_WWPBaseObjects\\Home.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "Center", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "Center", "top", "", "", "div");
            wb_table6_78_0K2( true) ;
         }
         else
         {
            wb_table6_78_0K2( false) ;
         }
         return  ;
      }

      protected void wb_table6_78_0K2e( bool wbgen )
      {
         if ( wbgen )
         {
            GxWebStd.gx_div_end( context, "Center", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "CellPaddingTop", "left", "top", "", "flex-grow:1;", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divCard4_Internalname, 1, 0, "px", 0, "px", "TableCardNumber", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "Center", "top", "", "", "div");
            wb_table7_91_0K2( true) ;
         }
         else
         {
            wb_table7_91_0K2( false) ;
         }
         return  ;
      }

      protected void wb_table7_91_0K2e( bool wbgen )
      {
         if ( wbgen )
         {
            GxWebStd.gx_div_end( context, "Center", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "Center", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "left", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavValuecard4_Internalname, "Value Card4", "col-sm-3 DashboardNumberCardNoBorderLabel", 0, true, "");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 100,'',false,'" + sGXsfl_147_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavValuecard4_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(AV11ValueCard4), 10, 0, ".", "")), StringUtil.LTrim( ((edtavValuecard4_Enabled!=0) ? context.localUtil.Format( (decimal)(AV11ValueCard4), "ZZ,ZZZ,ZZ9") : context.localUtil.Format( (decimal)(AV11ValueCard4), "ZZ,ZZZ,ZZ9"))), TempTags+" onchange=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onblur(this,100);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavValuecard4_Jsonclick, 0, "DashboardNumberCardNoBorder", "", "", "", "", 1, edtavValuecard4_Enabled, 0, "text", "", 10, "chr", 1, "row", 10, 0, 0, 0, 1, -1, 0, true, "KPINumericValue", "right", false, "", "HLP_WWPBaseObjects\\Home.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "Center", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "Center", "top", "", "", "div");
            wb_table8_103_0K2( true) ;
         }
         else
         {
            wb_table8_103_0K2( false) ;
         }
         return  ;
      }

      protected void wb_table8_103_0K2e( bool wbgen )
      {
         if ( wbgen )
         {
            GxWebStd.gx_div_end( context, "Center", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "CellPaddingTop", "left", "top", "", "flex-grow:1;", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divCard5_Internalname, 1, 0, "px", 0, "px", "", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "Center", "top", "", "", "div");
            wb_table9_116_0K2( true) ;
         }
         else
         {
            wb_table9_116_0K2( false) ;
         }
         return  ;
      }

      protected void wb_table9_116_0K2e( bool wbgen )
      {
         if ( wbgen )
         {
            GxWebStd.gx_div_end( context, "Center", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "Center", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "left", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavValuecard5_Internalname, "Value Card5", "col-sm-3 DashboardNumberCardNoBorderLabel", 0, true, "");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 125,'',false,'" + sGXsfl_147_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavValuecard5_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(AV33ValueCard5), 10, 0, ".", "")), StringUtil.LTrim( ((edtavValuecard5_Enabled!=0) ? context.localUtil.Format( (decimal)(AV33ValueCard5), "ZZ,ZZZ,ZZ9") : context.localUtil.Format( (decimal)(AV33ValueCard5), "ZZ,ZZZ,ZZ9"))), TempTags+" onchange=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onblur(this,125);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavValuecard5_Jsonclick, 0, "DashboardNumberCardNoBorder", "", "", "", "", 1, edtavValuecard5_Enabled, 0, "text", "", 10, "chr", 1, "row", 10, 0, 0, 0, 1, -1, 0, true, "KPINumericValue", "right", false, "", "HLP_WWPBaseObjects\\Home.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "Center", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "Center", "top", "", "", "div");
            wb_table10_128_0K2( true) ;
         }
         else
         {
            wb_table10_128_0K2( false) ;
         }
         return  ;
      }

      protected void wb_table10_128_0K2e( bool wbgen )
      {
         if ( wbgen )
         {
            GxWebStd.gx_div_end( context, "Center", "top", "div");
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
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-md-5 col-lg-4 CellMarginTop", "left", "top", "", "", "div");
            /* User Defined Control */
            ucDvpanel_tablenotifications.SetProperty("Width", Dvpanel_tablenotifications_Width);
            ucDvpanel_tablenotifications.SetProperty("AutoWidth", Dvpanel_tablenotifications_Autowidth);
            ucDvpanel_tablenotifications.SetProperty("AutoHeight", Dvpanel_tablenotifications_Autoheight);
            ucDvpanel_tablenotifications.SetProperty("Cls", Dvpanel_tablenotifications_Cls);
            ucDvpanel_tablenotifications.SetProperty("Title", Dvpanel_tablenotifications_Title);
            ucDvpanel_tablenotifications.SetProperty("Collapsible", Dvpanel_tablenotifications_Collapsible);
            ucDvpanel_tablenotifications.SetProperty("Collapsed", Dvpanel_tablenotifications_Collapsed);
            ucDvpanel_tablenotifications.SetProperty("ShowCollapseIcon", Dvpanel_tablenotifications_Showcollapseicon);
            ucDvpanel_tablenotifications.SetProperty("IconPosition", Dvpanel_tablenotifications_Iconposition);
            ucDvpanel_tablenotifications.SetProperty("AutoScroll", Dvpanel_tablenotifications_Autoscroll);
            ucDvpanel_tablenotifications.Render(context, "dvelop.gxbootstrap.panel_al", Dvpanel_tablenotifications_Internalname, "DVPANEL_TABLENOTIFICATIONSContainer");
            context.WriteHtmlText( "<div class=\"gx_usercontrol_child\" id=\""+"DVPANEL_TABLENOTIFICATIONSContainer"+"TableNotifications"+"\" style=\"display:none;\">") ;
            /* Div Control */
            GxWebStd.gx_div_start( context, divTablenotifications_Internalname, 1, 0, "px", 0, "px", "", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 NotificationSubtitleCell", "left", "top", "", "", "div");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblNotificationssubtitle_Internalname, "Tienes %1 nuevas notificaciones", "", "", lblNotificationssubtitle_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "TextBlockDashboardDescriptionCard", 0, "", 1, 1, 0, 0, "HLP_WWPBaseObjects\\Home.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 GridNoBorderNoHeader CellMarginTop HasGridEmpowerer", "left", "top", "", "", "div");
            /*  Grid Control  */
            GridContainer.SetWrapped(nGXWrapped);
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<div id=\""+"GridContainer"+"DivS\" data-gxgridid=\"147\">") ;
               sStyleString = "";
               GxWebStd.gx_table_start( context, subGrid_Internalname, subGrid_Internalname, "", "WorkWith", 0, "", "", 1, 2, sStyleString, "", "", 0);
               /* Subfile titles */
               context.WriteHtmlText( "<tr") ;
               context.WriteHtmlTextNl( ">") ;
               if ( subGrid_Backcolorstyle == 0 )
               {
                  subGrid_Titlebackstyle = 0;
                  if ( StringUtil.Len( subGrid_Class) > 0 )
                  {
                     subGrid_Linesclass = subGrid_Class+"Title";
                  }
               }
               else
               {
                  subGrid_Titlebackstyle = 1;
                  if ( subGrid_Backcolorstyle == 1 )
                  {
                     subGrid_Titlebackcolor = subGrid_Allbackcolor;
                     if ( StringUtil.Len( subGrid_Class) > 0 )
                     {
                        subGrid_Linesclass = subGrid_Class+"UniformTitle";
                     }
                  }
                  else
                  {
                     if ( StringUtil.Len( subGrid_Class) > 0 )
                     {
                        subGrid_Linesclass = subGrid_Class+"Title";
                     }
                  }
               }
               context.WriteHtmlText( "<th align=\""+"right"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+"display:none;"+""+"\" "+">") ;
               context.SendWebValue( "Notification Id") ;
               context.WriteHtmlTextNl( "</th>") ;
               context.WriteHtmlText( "<th align=\""+"left"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+""+""+"\" "+">") ;
               context.SendWebValue( "Notification Icon Class") ;
               context.WriteHtmlTextNl( "</th>") ;
               context.WriteHtmlText( "<th align=\""+"left"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+""+""+"\" "+">") ;
               context.SendWebValue( "Notification Title") ;
               context.WriteHtmlTextNl( "</th>") ;
               context.WriteHtmlText( "<th align=\""+"left"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+"display:none;"+""+"\" "+">") ;
               context.SendWebValue( "Notification Description") ;
               context.WriteHtmlTextNl( "</th>") ;
               context.WriteHtmlText( "<th align=\""+"right"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+"display:none;"+""+"\" "+">") ;
               context.SendWebValue( "Notification Datetime") ;
               context.WriteHtmlTextNl( "</th>") ;
               context.WriteHtmlText( "<th align=\""+"left"+"\" "+" width="+StringUtil.LTrimStr( (decimal)(490), 4, 0)+"px"+" class=\""+"Attribute"+"\" "+" style=\""+"display:none;"+""+"\" "+">") ;
               context.SendWebValue( "Notification Link") ;
               context.WriteHtmlTextNl( "</th>") ;
               context.WriteHtmlTextNl( "</tr>") ;
               GridContainer.AddObjectProperty("GridName", "Grid");
            }
            else
            {
               GridContainer.AddObjectProperty("GridName", "Grid");
               GridContainer.AddObjectProperty("Header", subGrid_Header);
               GridContainer.AddObjectProperty("Class", "WorkWith");
               GridContainer.AddObjectProperty("Cellpadding", StringUtil.LTrim( StringUtil.NToC( (decimal)(1), 4, 0, ".", "")));
               GridContainer.AddObjectProperty("Cellspacing", StringUtil.LTrim( StringUtil.NToC( (decimal)(2), 4, 0, ".", "")));
               GridContainer.AddObjectProperty("Backcolorstyle", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid_Backcolorstyle), 1, 0, ".", "")));
               GridContainer.AddObjectProperty("CmpContext", "");
               GridContainer.AddObjectProperty("InMasterPage", "false");
               GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
               GridColumn.AddObjectProperty("Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtavWwp_sdtnotificationsdata__notificationid_Enabled), 5, 0, ".", "")));
               GridContainer.AddColumnProperties(GridColumn);
               GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
               GridColumn.AddObjectProperty("Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtavWwp_sdtnotificationsdata__notificationiconclass_Enabled), 5, 0, ".", "")));
               GridContainer.AddColumnProperties(GridColumn);
               GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
               GridColumn.AddObjectProperty("Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtavWwp_sdtnotificationsdata__notificationtitle_Enabled), 5, 0, ".", "")));
               GridContainer.AddColumnProperties(GridColumn);
               GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
               GridColumn.AddObjectProperty("Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtavWwp_sdtnotificationsdata__notificationdescription_Enabled), 5, 0, ".", "")));
               GridContainer.AddColumnProperties(GridColumn);
               GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
               GridColumn.AddObjectProperty("Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtavWwp_sdtnotificationsdata__notificationdatetime_Enabled), 5, 0, ".", "")));
               GridContainer.AddColumnProperties(GridColumn);
               GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
               GridColumn.AddObjectProperty("Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtavWwp_sdtnotificationsdata__notificationlink_Enabled), 5, 0, ".", "")));
               GridContainer.AddColumnProperties(GridColumn);
               GridContainer.AddObjectProperty("Selectedindex", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid_Selectedindex), 4, 0, ".", "")));
               GridContainer.AddObjectProperty("Allowselection", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid_Allowselection), 1, 0, ".", "")));
               GridContainer.AddObjectProperty("Selectioncolor", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid_Selectioncolor), 9, 0, ".", "")));
               GridContainer.AddObjectProperty("Allowhover", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid_Allowhovering), 1, 0, ".", "")));
               GridContainer.AddObjectProperty("Hovercolor", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid_Hoveringcolor), 9, 0, ".", "")));
               GridContainer.AddObjectProperty("Allowcollapsing", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid_Allowcollapsing), 1, 0, ".", "")));
               GridContainer.AddObjectProperty("Collapsed", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid_Collapsed), 1, 0, ".", "")));
            }
         }
         if ( wbEnd == 147 )
         {
            wbEnd = 0;
            nRC_GXsfl_147 = (int)(nGXsfl_147_idx-1);
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "</table>") ;
               context.WriteHtmlText( "</div>") ;
            }
            else
            {
               GridContainer.AddObjectProperty("GRID_nEOF", GRID_nEOF);
               GridContainer.AddObjectProperty("GRID_nFirstRecordOnPage", GRID_nFirstRecordOnPage);
               AV41GXV1 = nGXsfl_147_idx;
               sStyleString = "";
               context.WriteHtmlText( "<div id=\""+"GridContainer"+"Div\" "+sStyleString+">"+"</div>") ;
               context.httpAjaxContext.ajax_rsp_assign_grid("_"+"Grid", GridContainer);
               if ( ! context.isAjaxRequest( ) && ! context.isSpaRequest( ) )
               {
                  GxWebStd.gx_hidden_field( context, "GridContainerData", GridContainer.ToJavascriptSource());
               }
               if ( context.isAjaxRequest( ) || context.isSpaRequest( ) )
               {
                  GxWebStd.gx_hidden_field( context, "GridContainerData"+"V", GridContainer.GridValuesHidden());
               }
               else
               {
                  context.WriteHtmlText( "<input type=\"hidden\" "+"name=\""+"GridContainerData"+"V"+"\" value='"+GridContainer.GridValuesHidden()+"'/>") ;
               }
            }
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            context.WriteHtmlText( "</div>") ;
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-md-7 col-lg-8 CellMarginTop", "left", "top", "", "", "div");
            /* User Defined Control */
            ucDvpanel_tablechart1.SetProperty("Width", Dvpanel_tablechart1_Width);
            ucDvpanel_tablechart1.SetProperty("AutoWidth", Dvpanel_tablechart1_Autowidth);
            ucDvpanel_tablechart1.SetProperty("AutoHeight", Dvpanel_tablechart1_Autoheight);
            ucDvpanel_tablechart1.SetProperty("Cls", Dvpanel_tablechart1_Cls);
            ucDvpanel_tablechart1.SetProperty("Title", Dvpanel_tablechart1_Title);
            ucDvpanel_tablechart1.SetProperty("Collapsible", Dvpanel_tablechart1_Collapsible);
            ucDvpanel_tablechart1.SetProperty("Collapsed", Dvpanel_tablechart1_Collapsed);
            ucDvpanel_tablechart1.SetProperty("ShowCollapseIcon", Dvpanel_tablechart1_Showcollapseicon);
            ucDvpanel_tablechart1.SetProperty("IconPosition", Dvpanel_tablechart1_Iconposition);
            ucDvpanel_tablechart1.SetProperty("AutoScroll", Dvpanel_tablechart1_Autoscroll);
            ucDvpanel_tablechart1.Render(context, "dvelop.gxbootstrap.panel_al", Dvpanel_tablechart1_Internalname, "DVPANEL_TABLECHART1Container");
            context.WriteHtmlText( "<div class=\"gx_usercontrol_child\" id=\""+"DVPANEL_TABLECHART1Container"+"TableChart1"+"\" style=\"display:none;\">") ;
            /* Div Control */
            GxWebStd.gx_div_start( context, divTablechart1_Internalname, 1, 0, "px", divTablechart1_Height, "px", "", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-lg-7", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divTablereport_Internalname, 1, 0, "px", 0, "px", "", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "Center", "top", "", "", "div");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblCharttitle_Internalname, "Sales: Last Month", "", "", lblCharttitle_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "SimpleCardTitle", 0, "", 1, 1, 0, 0, "HLP_WWPBaseObjects\\Home.htm");
            GxWebStd.gx_div_end( context, "Center", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 CellMarginTop", "left", "top", "", "", "div");
            /* User Defined Control */
            ucUtchartsmootharea.SetProperty("Elements", AV14Elements);
            ucUtchartsmootharea.SetProperty("Parameters", AV15Parameters);
            ucUtchartsmootharea.SetProperty("Class", Utchartsmootharea_Class);
            ucUtchartsmootharea.SetProperty("Height", Utchartsmootharea_Height);
            ucUtchartsmootharea.SetProperty("Type", Utchartsmootharea_Type);
            ucUtchartsmootharea.SetProperty("Title", Utchartsmootharea_Title);
            ucUtchartsmootharea.SetProperty("ChartType", Utchartsmootharea_Charttype);
            ucUtchartsmootharea.SetProperty("XAxisTitle", Utchartsmootharea_Xaxistitle);
            ucUtchartsmootharea.SetProperty("ItemClickData", AV16ItemClickData);
            ucUtchartsmootharea.SetProperty("ItemDoubleClickData", AV17ItemDoubleClickData);
            ucUtchartsmootharea.SetProperty("DragAndDropData", AV18DragAndDropData);
            ucUtchartsmootharea.SetProperty("FilterChangedData", AV19FilterChangedData);
            ucUtchartsmootharea.SetProperty("ItemExpandData", AV20ItemExpandData);
            ucUtchartsmootharea.SetProperty("ItemCollapseData", AV21ItemCollapseData);
            ucUtchartsmootharea.Render(context, "queryviewer", Utchartsmootharea_Internalname, "UTCHARTSMOOTHAREAContainer");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-lg-5 CellPaddingRight30", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divTablereportgoals_Internalname, 1, 0, "px", 0, "px", "", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "Center", "top", "", "", "div");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblIndicatorstitle_Internalname, "Goal Completion", "", "", lblIndicatorstitle_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "SimpleCardTitle", 0, "", 1, 1, 0, 0, "HLP_WWPBaseObjects\\Home.htm");
            GxWebStd.gx_div_end( context, "Center", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 CellMarginTop30", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divTabletitle1_Internalname, 1, 0, "px", 0, "px", "Flex", "left", "top", " "+"data-gx-flex"+" ", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "", "left", "top", "", "flex-grow:1;", "div");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblDescriptionprogressbar1_Internalname, "Added Products", "", "", lblDescriptionprogressbar1_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "TextBlock", 0, "", 1, 1, 0, 0, "HLP_WWPBaseObjects\\Home.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "", "left", "top", "", "", "div");
            wb_table11_178_0K2( true) ;
         }
         else
         {
            wb_table11_178_0K2( false) ;
         }
         return  ;
      }

      protected void wb_table11_178_0K2e( bool wbgen )
      {
         if ( wbgen )
         {
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
            /* User Defined Control */
            ucProgressbar1.SetProperty("Type", Progressbar1_Type);
            ucProgressbar1.SetProperty("Caption", Progressbar1_Caption);
            ucProgressbar1.SetProperty("Cls", Progressbar1_Cls);
            ucProgressbar1.SetProperty("Percentage", Progressbar1_Percentage);
            ucProgressbar1.Render(context, "dvelop.gxbootstrap.dvprogressindicator", Progressbar1_Internalname, "PROGRESSBAR1Container");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divTabletitle2_Internalname, 1, 0, "px", 0, "px", "Flex", "left", "top", " "+"data-gx-flex"+" ", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "", "left", "top", "", "flex-grow:1;", "div");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblDescriptionprogressbar2_Internalname, "Complete Purchase", "", "", lblDescriptionprogressbar2_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "TextBlock", 0, "", 1, 1, 0, 0, "HLP_WWPBaseObjects\\Home.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "", "left", "top", "", "", "div");
            wb_table12_197_0K2( true) ;
         }
         else
         {
            wb_table12_197_0K2( false) ;
         }
         return  ;
      }

      protected void wb_table12_197_0K2e( bool wbgen )
      {
         if ( wbgen )
         {
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
            /* User Defined Control */
            ucProgressbar2.SetProperty("Type", Progressbar2_Type);
            ucProgressbar2.SetProperty("Caption", Progressbar2_Caption);
            ucProgressbar2.SetProperty("Cls", Progressbar2_Cls);
            ucProgressbar2.SetProperty("Percentage", Progressbar2_Percentage);
            ucProgressbar2.Render(context, "dvelop.gxbootstrap.dvprogressindicator", Progressbar2_Internalname, "PROGRESSBAR2Container");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divTabletitle3_Internalname, 1, 0, "px", 0, "px", "Flex", "left", "top", " "+"data-gx-flex"+" ", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "", "left", "top", "", "flex-grow:1;", "div");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblDescriptionprogressbar3_Internalname, "Like to Page", "", "", lblDescriptionprogressbar3_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "TextBlock", 0, "", 1, 1, 0, 0, "HLP_WWPBaseObjects\\Home.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "", "left", "top", "", "", "div");
            wb_table13_216_0K2( true) ;
         }
         else
         {
            wb_table13_216_0K2( false) ;
         }
         return  ;
      }

      protected void wb_table13_216_0K2e( bool wbgen )
      {
         if ( wbgen )
         {
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
            /* User Defined Control */
            ucProgressbar3.SetProperty("Type", Progressbar3_Type);
            ucProgressbar3.SetProperty("Caption", Progressbar3_Caption);
            ucProgressbar3.SetProperty("Cls", Progressbar3_Cls);
            ucProgressbar3.SetProperty("Percentage", Progressbar3_Percentage);
            ucProgressbar3.Render(context, "dvelop.gxbootstrap.dvprogressindicator", Progressbar3_Internalname, "PROGRESSBAR3Container");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divTabletitle4_Internalname, 1, 0, "px", 0, "px", "Flex", "left", "top", " "+"data-gx-flex"+" ", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "", "left", "top", "", "flex-grow:1;", "div");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblDescriptionprogressbar4_Internalname, "Contact us", "", "", lblDescriptionprogressbar4_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "TextBlock", 0, "", 1, 1, 0, 0, "HLP_WWPBaseObjects\\Home.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "", "left", "top", "", "", "div");
            wb_table14_235_0K2( true) ;
         }
         else
         {
            wb_table14_235_0K2( false) ;
         }
         return  ;
      }

      protected void wb_table14_235_0K2e( bool wbgen )
      {
         if ( wbgen )
         {
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
            /* User Defined Control */
            ucProgressbar4.SetProperty("Type", Progressbar4_Type);
            ucProgressbar4.SetProperty("Caption", Progressbar4_Caption);
            ucProgressbar4.SetProperty("Cls", Progressbar4_Cls);
            ucProgressbar4.SetProperty("Percentage", Progressbar4_Percentage);
            ucProgressbar4.Render(context, "dvelop.gxbootstrap.dvprogressindicator", Progressbar4_Internalname, "PROGRESSBAR4Container");
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
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-md-7 CellMarginTop", "left", "top", "", "", "div");
            /* User Defined Control */
            ucDvpanel_tablechart4.SetProperty("Width", Dvpanel_tablechart4_Width);
            ucDvpanel_tablechart4.SetProperty("AutoWidth", Dvpanel_tablechart4_Autowidth);
            ucDvpanel_tablechart4.SetProperty("AutoHeight", Dvpanel_tablechart4_Autoheight);
            ucDvpanel_tablechart4.SetProperty("Cls", Dvpanel_tablechart4_Cls);
            ucDvpanel_tablechart4.SetProperty("Title", Dvpanel_tablechart4_Title);
            ucDvpanel_tablechart4.SetProperty("Collapsible", Dvpanel_tablechart4_Collapsible);
            ucDvpanel_tablechart4.SetProperty("Collapsed", Dvpanel_tablechart4_Collapsed);
            ucDvpanel_tablechart4.SetProperty("ShowCollapseIcon", Dvpanel_tablechart4_Showcollapseicon);
            ucDvpanel_tablechart4.SetProperty("IconPosition", Dvpanel_tablechart4_Iconposition);
            ucDvpanel_tablechart4.SetProperty("AutoScroll", Dvpanel_tablechart4_Autoscroll);
            ucDvpanel_tablechart4.Render(context, "dvelop.gxbootstrap.panel_al", Dvpanel_tablechart4_Internalname, "DVPANEL_TABLECHART4Container");
            context.WriteHtmlText( "<div class=\"gx_usercontrol_child\" id=\""+"DVPANEL_TABLECHART4Container"+"TableChart4"+"\" style=\"display:none;\">") ;
            /* Div Control */
            GxWebStd.gx_div_start( context, divTablechart4_Internalname, 1, 0, "px", divTablechart4_Height, "px", "", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
            /* User Defined Control */
            ucUtchartsmoothline.SetProperty("Elements", AV14Elements);
            ucUtchartsmoothline.SetProperty("Parameters", AV15Parameters);
            ucUtchartsmoothline.SetProperty("Height", Utchartsmoothline_Height);
            ucUtchartsmoothline.SetProperty("Type", Utchartsmoothline_Type);
            ucUtchartsmoothline.SetProperty("Title", Utchartsmoothline_Title);
            ucUtchartsmoothline.SetProperty("ChartType", Utchartsmoothline_Charttype);
            ucUtchartsmoothline.SetProperty("XAxisTitle", Utchartsmoothline_Xaxistitle);
            ucUtchartsmoothline.SetProperty("ItemClickData", AV16ItemClickData);
            ucUtchartsmoothline.SetProperty("ItemDoubleClickData", AV17ItemDoubleClickData);
            ucUtchartsmoothline.SetProperty("DragAndDropData", AV18DragAndDropData);
            ucUtchartsmoothline.SetProperty("FilterChangedData", AV19FilterChangedData);
            ucUtchartsmoothline.SetProperty("ItemExpandData", AV20ItemExpandData);
            ucUtchartsmoothline.SetProperty("ItemCollapseData", AV21ItemCollapseData);
            ucUtchartsmoothline.Render(context, "queryviewer", Utchartsmoothline_Internalname, "UTCHARTSMOOTHLINEContainer");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            context.WriteHtmlText( "</div>") ;
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-md-5 CellMarginTop", "left", "top", "", "", "div");
            /* User Defined Control */
            ucDvpanel_tablechart3.SetProperty("Width", Dvpanel_tablechart3_Width);
            ucDvpanel_tablechart3.SetProperty("AutoWidth", Dvpanel_tablechart3_Autowidth);
            ucDvpanel_tablechart3.SetProperty("AutoHeight", Dvpanel_tablechart3_Autoheight);
            ucDvpanel_tablechart3.SetProperty("Cls", Dvpanel_tablechart3_Cls);
            ucDvpanel_tablechart3.SetProperty("Title", Dvpanel_tablechart3_Title);
            ucDvpanel_tablechart3.SetProperty("Collapsible", Dvpanel_tablechart3_Collapsible);
            ucDvpanel_tablechart3.SetProperty("Collapsed", Dvpanel_tablechart3_Collapsed);
            ucDvpanel_tablechart3.SetProperty("ShowCollapseIcon", Dvpanel_tablechart3_Showcollapseicon);
            ucDvpanel_tablechart3.SetProperty("IconPosition", Dvpanel_tablechart3_Iconposition);
            ucDvpanel_tablechart3.SetProperty("AutoScroll", Dvpanel_tablechart3_Autoscroll);
            ucDvpanel_tablechart3.Render(context, "dvelop.gxbootstrap.panel_al", Dvpanel_tablechart3_Internalname, "DVPANEL_TABLECHART3Container");
            context.WriteHtmlText( "<div class=\"gx_usercontrol_child\" id=\""+"DVPANEL_TABLECHART3Container"+"TableChart3"+"\" style=\"display:none;\">") ;
            /* Div Control */
            GxWebStd.gx_div_start( context, divTablechart3_Internalname, 1, 0, "px", divTablechart3_Height, "px", "", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
            /* User Defined Control */
            ucUtchartdoughnut.SetProperty("Elements", AV14Elements);
            ucUtchartdoughnut.SetProperty("Parameters", AV15Parameters);
            ucUtchartdoughnut.SetProperty("Height", Utchartdoughnut_Height);
            ucUtchartdoughnut.SetProperty("Type", Utchartdoughnut_Type);
            ucUtchartdoughnut.SetProperty("Title", Utchartdoughnut_Title);
            ucUtchartdoughnut.SetProperty("ShowValues", Utchartdoughnut_Showvalues);
            ucUtchartdoughnut.SetProperty("ChartType", Utchartdoughnut_Charttype);
            ucUtchartdoughnut.SetProperty("ItemClickData", AV16ItemClickData);
            ucUtchartdoughnut.SetProperty("ItemDoubleClickData", AV17ItemDoubleClickData);
            ucUtchartdoughnut.SetProperty("DragAndDropData", AV18DragAndDropData);
            ucUtchartdoughnut.SetProperty("FilterChangedData", AV19FilterChangedData);
            ucUtchartdoughnut.SetProperty("ItemExpandData", AV20ItemExpandData);
            ucUtchartdoughnut.SetProperty("ItemCollapseData", AV21ItemCollapseData);
            ucUtchartdoughnut.Render(context, "queryviewer", Utchartdoughnut_Internalname, "UTCHARTDOUGHNUTContainer");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            context.WriteHtmlText( "</div>") ;
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
            /* User Defined Control */
            ucGrid_empowerer.Render(context, "wwp.gridempowerer", Grid_empowerer_Internalname, "GRID_EMPOWERERContainer");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
         }
         if ( wbEnd == 147 )
         {
            wbEnd = 0;
            if ( isFullAjaxMode( ) )
            {
               if ( GridContainer.GetWrapped() == 1 )
               {
                  context.WriteHtmlText( "</table>") ;
                  context.WriteHtmlText( "</div>") ;
               }
               else
               {
                  GridContainer.AddObjectProperty("GRID_nEOF", GRID_nEOF);
                  GridContainer.AddObjectProperty("GRID_nFirstRecordOnPage", GRID_nFirstRecordOnPage);
                  AV41GXV1 = nGXsfl_147_idx;
                  sStyleString = "";
                  context.WriteHtmlText( "<div id=\""+"GridContainer"+"Div\" "+sStyleString+">"+"</div>") ;
                  context.httpAjaxContext.ajax_rsp_assign_grid("_"+"Grid", GridContainer);
                  if ( ! context.isAjaxRequest( ) && ! context.isSpaRequest( ) )
                  {
                     GxWebStd.gx_hidden_field( context, "GridContainerData", GridContainer.ToJavascriptSource());
                  }
                  if ( context.isAjaxRequest( ) || context.isSpaRequest( ) )
                  {
                     GxWebStd.gx_hidden_field( context, "GridContainerData"+"V", GridContainer.GridValuesHidden());
                  }
                  else
                  {
                     context.WriteHtmlText( "<input type=\"hidden\" "+"name=\""+"GridContainerData"+"V"+"\" value='"+GridContainer.GridValuesHidden()+"'/>") ;
                  }
               }
            }
         }
         wbLoad = true;
      }

      protected void START0K2( )
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
            Form.Meta.addItem("description", "Inicio", 0) ;
         }
         context.wjLoc = "";
         context.nUserReturn = 0;
         context.wbHandled = 0;
         if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
         {
         }
         wbErr = false;
         STRUP0K0( ) ;
      }

      protected void WS0K2( )
      {
         START0K2( ) ;
         EVT0K2( ) ;
      }

      protected void EVT0K2( )
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
                           else if ( StringUtil.StrCmp(sEvt, "LSCR") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                           }
                           else if ( StringUtil.StrCmp(sEvt, "GRIDPAGING") == 0 )
                           {
                              context.wbHandled = 1;
                              sEvt = cgiGet( "GRIDPAGING");
                              if ( StringUtil.StrCmp(sEvt, "FIRST") == 0 )
                              {
                                 subgrid_firstpage( ) ;
                              }
                              else if ( StringUtil.StrCmp(sEvt, "PREV") == 0 )
                              {
                                 subgrid_previouspage( ) ;
                              }
                              else if ( StringUtil.StrCmp(sEvt, "NEXT") == 0 )
                              {
                                 subgrid_nextpage( ) ;
                              }
                              else if ( StringUtil.StrCmp(sEvt, "LAST") == 0 )
                              {
                                 subgrid_lastpage( ) ;
                              }
                              dynload_actions( ) ;
                           }
                        }
                        else
                        {
                           sEvtType = StringUtil.Right( sEvt, 4);
                           sEvt = StringUtil.Left( sEvt, (short)(StringUtil.Len( sEvt)-4));
                           if ( ( StringUtil.StrCmp(StringUtil.Left( sEvt, 5), "START") == 0 ) || ( StringUtil.StrCmp(StringUtil.Left( sEvt, 9), "GRID.LOAD") == 0 ) || ( StringUtil.StrCmp(StringUtil.Left( sEvt, 5), "ENTER") == 0 ) || ( StringUtil.StrCmp(StringUtil.Left( sEvt, 6), "CANCEL") == 0 ) )
                           {
                              nGXsfl_147_idx = (int)(NumberUtil.Val( sEvtType, "."));
                              sGXsfl_147_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_147_idx), 4, 0), 4, "0");
                              SubsflControlProps_1472( ) ;
                              AV41GXV1 = (int)(nGXsfl_147_idx+GRID_nFirstRecordOnPage);
                              if ( ( AV24WWP_SDTNotificationsData.Count >= AV41GXV1 ) && ( AV41GXV1 > 0 ) )
                              {
                                 AV24WWP_SDTNotificationsData.CurrentItem = ((GeneXus.Programs.wwpbaseobjects.SdtWWP_SDTNotificationsData_WWP_SDTNotificationsDataItem)AV24WWP_SDTNotificationsData.Item(AV41GXV1));
                              }
                              sEvtType = StringUtil.Right( sEvt, 1);
                              if ( StringUtil.StrCmp(sEvtType, ".") == 0 )
                              {
                                 sEvt = StringUtil.Left( sEvt, (short)(StringUtil.Len( sEvt)-1));
                                 if ( StringUtil.StrCmp(sEvt, "START") == 0 )
                                 {
                                    context.wbHandled = 1;
                                    dynload_actions( ) ;
                                    /* Execute user event: Start */
                                    E110K2 ();
                                 }
                                 else if ( StringUtil.StrCmp(sEvt, "GRID.LOAD") == 0 )
                                 {
                                    context.wbHandled = 1;
                                    dynload_actions( ) ;
                                    E120K2 ();
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

      protected void WE0K2( )
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

      protected void PA0K2( )
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
               GX_FocusControl = edtavValuecard1_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            }
            nDonePA = 1;
         }
      }

      protected void dynload_actions( )
      {
         /* End function dynload_actions */
      }

      protected void gxnrGrid_newrow( )
      {
         GxWebStd.set_html_headers( context, 0, "", "");
         SubsflControlProps_1472( ) ;
         while ( nGXsfl_147_idx <= nRC_GXsfl_147 )
         {
            sendrow_1472( ) ;
            nGXsfl_147_idx = ((subGrid_Islastpage==1)&&(nGXsfl_147_idx+1>subGrid_fnc_Recordsperpage( )) ? 1 : nGXsfl_147_idx+1);
            sGXsfl_147_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_147_idx), 4, 0), 4, "0");
            SubsflControlProps_1472( ) ;
         }
         AddString( context.httpAjaxContext.getJSONContainerResponse( GridContainer)) ;
         /* End function gxnrGrid_newrow */
      }

      protected void gxgrGrid_refresh( int subGrid_Rows )
      {
         initialize_formulas( ) ;
         GxWebStd.set_html_headers( context, 0, "", "");
         GRID_nCurrentRecord = 0;
         RF0K2( ) ;
         GXKey = Crypto.GetSiteKey( );
         send_integrity_footer_hashes( ) ;
         GXKey = Crypto.GetSiteKey( );
         /* End function gxgrGrid_refresh */
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
         RF0K2( ) ;
         if ( isFullAjaxMode( ) )
         {
            send_integrity_footer_hashes( ) ;
         }
      }

      protected void initialize_formulas( )
      {
         /* GeneXus formulas. */
         context.Gx_err = 0;
         edtavValuecard1_Enabled = 0;
         AssignProp("", false, edtavValuecard1_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavValuecard1_Enabled), 5, 0), true);
         edtavNumbersecondaryvalue1_Enabled = 0;
         AssignProp("", false, edtavNumbersecondaryvalue1_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavNumbersecondaryvalue1_Enabled), 5, 0), true);
         edtavValuecard2_Enabled = 0;
         AssignProp("", false, edtavValuecard2_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavValuecard2_Enabled), 5, 0), true);
         edtavNumbersecondaryvalue2_Enabled = 0;
         AssignProp("", false, edtavNumbersecondaryvalue2_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavNumbersecondaryvalue2_Enabled), 5, 0), true);
         edtavValuecard3_Enabled = 0;
         AssignProp("", false, edtavValuecard3_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavValuecard3_Enabled), 5, 0), true);
         edtavNumbersecondaryvalue3_Enabled = 0;
         AssignProp("", false, edtavNumbersecondaryvalue3_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavNumbersecondaryvalue3_Enabled), 5, 0), true);
         edtavValuecard4_Enabled = 0;
         AssignProp("", false, edtavValuecard4_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavValuecard4_Enabled), 5, 0), true);
         edtavNumbersecondaryvalue4_Enabled = 0;
         AssignProp("", false, edtavNumbersecondaryvalue4_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavNumbersecondaryvalue4_Enabled), 5, 0), true);
         edtavValuecard5_Enabled = 0;
         AssignProp("", false, edtavValuecard5_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavValuecard5_Enabled), 5, 0), true);
         edtavNumbersecondaryvalue5_Enabled = 0;
         AssignProp("", false, edtavNumbersecondaryvalue5_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavNumbersecondaryvalue5_Enabled), 5, 0), true);
         edtavWwp_sdtnotificationsdata__notificationid_Enabled = 0;
         AssignProp("", false, edtavWwp_sdtnotificationsdata__notificationid_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavWwp_sdtnotificationsdata__notificationid_Enabled), 5, 0), !bGXsfl_147_Refreshing);
         edtavWwp_sdtnotificationsdata__notificationiconclass_Enabled = 0;
         AssignProp("", false, edtavWwp_sdtnotificationsdata__notificationiconclass_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavWwp_sdtnotificationsdata__notificationiconclass_Enabled), 5, 0), !bGXsfl_147_Refreshing);
         edtavWwp_sdtnotificationsdata__notificationtitle_Enabled = 0;
         AssignProp("", false, edtavWwp_sdtnotificationsdata__notificationtitle_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavWwp_sdtnotificationsdata__notificationtitle_Enabled), 5, 0), !bGXsfl_147_Refreshing);
         edtavWwp_sdtnotificationsdata__notificationdescription_Enabled = 0;
         AssignProp("", false, edtavWwp_sdtnotificationsdata__notificationdescription_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavWwp_sdtnotificationsdata__notificationdescription_Enabled), 5, 0), !bGXsfl_147_Refreshing);
         edtavWwp_sdtnotificationsdata__notificationdatetime_Enabled = 0;
         AssignProp("", false, edtavWwp_sdtnotificationsdata__notificationdatetime_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavWwp_sdtnotificationsdata__notificationdatetime_Enabled), 5, 0), !bGXsfl_147_Refreshing);
         edtavWwp_sdtnotificationsdata__notificationlink_Enabled = 0;
         AssignProp("", false, edtavWwp_sdtnotificationsdata__notificationlink_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavWwp_sdtnotificationsdata__notificationlink_Enabled), 5, 0), !bGXsfl_147_Refreshing);
         edtavValueprogressbar1_Enabled = 0;
         AssignProp("", false, edtavValueprogressbar1_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavValueprogressbar1_Enabled), 5, 0), true);
         edtavTotalvalueprogressbar1_Enabled = 0;
         AssignProp("", false, edtavTotalvalueprogressbar1_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavTotalvalueprogressbar1_Enabled), 5, 0), true);
         edtavValueprogressbar2_Enabled = 0;
         AssignProp("", false, edtavValueprogressbar2_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavValueprogressbar2_Enabled), 5, 0), true);
         edtavTotalvalueprogressbar2_Enabled = 0;
         AssignProp("", false, edtavTotalvalueprogressbar2_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavTotalvalueprogressbar2_Enabled), 5, 0), true);
         edtavValueprogressbar3_Enabled = 0;
         AssignProp("", false, edtavValueprogressbar3_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavValueprogressbar3_Enabled), 5, 0), true);
         edtavTotalvalueprogressbar3_Enabled = 0;
         AssignProp("", false, edtavTotalvalueprogressbar3_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavTotalvalueprogressbar3_Enabled), 5, 0), true);
         edtavValueprogressbar4_Enabled = 0;
         AssignProp("", false, edtavValueprogressbar4_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavValueprogressbar4_Enabled), 5, 0), true);
         edtavTotalvalueprogressbar4_Enabled = 0;
         AssignProp("", false, edtavTotalvalueprogressbar4_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavTotalvalueprogressbar4_Enabled), 5, 0), true);
      }

      protected void RF0K2( )
      {
         initialize_formulas( ) ;
         clear_multi_value_controls( ) ;
         if ( isAjaxCallMode( ) )
         {
            GridContainer.ClearRows();
         }
         wbStart = 147;
         nGXsfl_147_idx = 1;
         sGXsfl_147_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_147_idx), 4, 0), 4, "0");
         SubsflControlProps_1472( ) ;
         bGXsfl_147_Refreshing = true;
         GridContainer.AddObjectProperty("GridName", "Grid");
         GridContainer.AddObjectProperty("CmpContext", "");
         GridContainer.AddObjectProperty("InMasterPage", "false");
         GridContainer.AddObjectProperty("Class", "WorkWith");
         GridContainer.AddObjectProperty("Cellpadding", StringUtil.LTrim( StringUtil.NToC( (decimal)(1), 4, 0, ".", "")));
         GridContainer.AddObjectProperty("Cellspacing", StringUtil.LTrim( StringUtil.NToC( (decimal)(2), 4, 0, ".", "")));
         GridContainer.AddObjectProperty("Backcolorstyle", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid_Backcolorstyle), 1, 0, ".", "")));
         GridContainer.PageSize = subGrid_fnc_Recordsperpage( );
         gxdyncontrolsrefreshing = true;
         fix_multi_value_controls( ) ;
         gxdyncontrolsrefreshing = false;
         if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
         {
            SubsflControlProps_1472( ) ;
            E120K2 ();
            if ( ( GRID_nCurrentRecord > 0 ) && ( GRID_nGridOutOfScope == 0 ) && ( nGXsfl_147_idx == 1 ) )
            {
               GRID_nCurrentRecord = 0;
               GRID_nGridOutOfScope = 1;
               subgrid_firstpage( ) ;
               E120K2 ();
            }
            wbEnd = 147;
            WB0K0( ) ;
         }
         bGXsfl_147_Refreshing = true;
      }

      protected void send_integrity_lvl_hashes0K2( )
      {
      }

      protected int subGrid_fnc_Pagecount( )
      {
         GRID_nRecordCount = subGrid_fnc_Recordcount( );
         if ( ((int)((GRID_nRecordCount) % (subGrid_fnc_Recordsperpage( )))) == 0 )
         {
            return (int)(NumberUtil.Int( (long)(GRID_nRecordCount/ (decimal)(subGrid_fnc_Recordsperpage( ))))) ;
         }
         return (int)(NumberUtil.Int( (long)(GRID_nRecordCount/ (decimal)(subGrid_fnc_Recordsperpage( ))))+1) ;
      }

      protected int subGrid_fnc_Recordcount( )
      {
         return AV24WWP_SDTNotificationsData.Count ;
      }

      protected int subGrid_fnc_Recordsperpage( )
      {
         if ( subGrid_Rows > 0 )
         {
            return subGrid_Rows*1 ;
         }
         else
         {
            return (int)(-1) ;
         }
      }

      protected int subGrid_fnc_Currentpage( )
      {
         return (int)(NumberUtil.Int( (long)(GRID_nFirstRecordOnPage/ (decimal)(subGrid_fnc_Recordsperpage( ))))+1) ;
      }

      protected short subgrid_firstpage( )
      {
         GRID_nFirstRecordOnPage = 0;
         GxWebStd.gx_hidden_field( context, "GRID_nFirstRecordOnPage", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRID_nFirstRecordOnPage), 15, 0, ".", "")));
         if ( isFullAjaxMode( ) )
         {
            gxgrGrid_refresh( subGrid_Rows) ;
         }
         send_integrity_footer_hashes( ) ;
         return 0 ;
      }

      protected short subgrid_nextpage( )
      {
         GRID_nRecordCount = subGrid_fnc_Recordcount( );
         if ( ( GRID_nRecordCount >= subGrid_fnc_Recordsperpage( ) ) && ( GRID_nEOF == 0 ) )
         {
            GRID_nFirstRecordOnPage = (long)(GRID_nFirstRecordOnPage+subGrid_fnc_Recordsperpage( ));
         }
         else
         {
            return 2 ;
         }
         GxWebStd.gx_hidden_field( context, "GRID_nFirstRecordOnPage", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRID_nFirstRecordOnPage), 15, 0, ".", "")));
         GridContainer.AddObjectProperty("GRID_nFirstRecordOnPage", GRID_nFirstRecordOnPage);
         if ( isFullAjaxMode( ) )
         {
            gxgrGrid_refresh( subGrid_Rows) ;
         }
         send_integrity_footer_hashes( ) ;
         return (short)(((GRID_nEOF==0) ? 0 : 2)) ;
      }

      protected short subgrid_previouspage( )
      {
         if ( GRID_nFirstRecordOnPage >= subGrid_fnc_Recordsperpage( ) )
         {
            GRID_nFirstRecordOnPage = (long)(GRID_nFirstRecordOnPage-subGrid_fnc_Recordsperpage( ));
         }
         else
         {
            return 2 ;
         }
         GxWebStd.gx_hidden_field( context, "GRID_nFirstRecordOnPage", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRID_nFirstRecordOnPage), 15, 0, ".", "")));
         if ( isFullAjaxMode( ) )
         {
            gxgrGrid_refresh( subGrid_Rows) ;
         }
         send_integrity_footer_hashes( ) ;
         return 0 ;
      }

      protected short subgrid_lastpage( )
      {
         GRID_nRecordCount = subGrid_fnc_Recordcount( );
         if ( GRID_nRecordCount > subGrid_fnc_Recordsperpage( ) )
         {
            if ( ((int)((GRID_nRecordCount) % (subGrid_fnc_Recordsperpage( )))) == 0 )
            {
               GRID_nFirstRecordOnPage = (long)(GRID_nRecordCount-subGrid_fnc_Recordsperpage( ));
            }
            else
            {
               GRID_nFirstRecordOnPage = (long)(GRID_nRecordCount-((int)((GRID_nRecordCount) % (subGrid_fnc_Recordsperpage( )))));
            }
         }
         else
         {
            GRID_nFirstRecordOnPage = 0;
         }
         GxWebStd.gx_hidden_field( context, "GRID_nFirstRecordOnPage", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRID_nFirstRecordOnPage), 15, 0, ".", "")));
         if ( isFullAjaxMode( ) )
         {
            gxgrGrid_refresh( subGrid_Rows) ;
         }
         send_integrity_footer_hashes( ) ;
         return 0 ;
      }

      protected int subgrid_gotopage( int nPageNo )
      {
         if ( nPageNo > 0 )
         {
            GRID_nFirstRecordOnPage = (long)(subGrid_fnc_Recordsperpage( )*(nPageNo-1));
         }
         else
         {
            GRID_nFirstRecordOnPage = 0;
         }
         GxWebStd.gx_hidden_field( context, "GRID_nFirstRecordOnPage", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRID_nFirstRecordOnPage), 15, 0, ".", "")));
         if ( isFullAjaxMode( ) )
         {
            gxgrGrid_refresh( subGrid_Rows) ;
         }
         send_integrity_footer_hashes( ) ;
         return (int)(0) ;
      }

      protected void before_start_formulas( )
      {
         context.Gx_err = 0;
         edtavValuecard1_Enabled = 0;
         AssignProp("", false, edtavValuecard1_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavValuecard1_Enabled), 5, 0), true);
         edtavNumbersecondaryvalue1_Enabled = 0;
         AssignProp("", false, edtavNumbersecondaryvalue1_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavNumbersecondaryvalue1_Enabled), 5, 0), true);
         edtavValuecard2_Enabled = 0;
         AssignProp("", false, edtavValuecard2_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavValuecard2_Enabled), 5, 0), true);
         edtavNumbersecondaryvalue2_Enabled = 0;
         AssignProp("", false, edtavNumbersecondaryvalue2_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavNumbersecondaryvalue2_Enabled), 5, 0), true);
         edtavValuecard3_Enabled = 0;
         AssignProp("", false, edtavValuecard3_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavValuecard3_Enabled), 5, 0), true);
         edtavNumbersecondaryvalue3_Enabled = 0;
         AssignProp("", false, edtavNumbersecondaryvalue3_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavNumbersecondaryvalue3_Enabled), 5, 0), true);
         edtavValuecard4_Enabled = 0;
         AssignProp("", false, edtavValuecard4_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavValuecard4_Enabled), 5, 0), true);
         edtavNumbersecondaryvalue4_Enabled = 0;
         AssignProp("", false, edtavNumbersecondaryvalue4_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavNumbersecondaryvalue4_Enabled), 5, 0), true);
         edtavValuecard5_Enabled = 0;
         AssignProp("", false, edtavValuecard5_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavValuecard5_Enabled), 5, 0), true);
         edtavNumbersecondaryvalue5_Enabled = 0;
         AssignProp("", false, edtavNumbersecondaryvalue5_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavNumbersecondaryvalue5_Enabled), 5, 0), true);
         edtavWwp_sdtnotificationsdata__notificationid_Enabled = 0;
         AssignProp("", false, edtavWwp_sdtnotificationsdata__notificationid_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavWwp_sdtnotificationsdata__notificationid_Enabled), 5, 0), !bGXsfl_147_Refreshing);
         edtavWwp_sdtnotificationsdata__notificationiconclass_Enabled = 0;
         AssignProp("", false, edtavWwp_sdtnotificationsdata__notificationiconclass_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavWwp_sdtnotificationsdata__notificationiconclass_Enabled), 5, 0), !bGXsfl_147_Refreshing);
         edtavWwp_sdtnotificationsdata__notificationtitle_Enabled = 0;
         AssignProp("", false, edtavWwp_sdtnotificationsdata__notificationtitle_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavWwp_sdtnotificationsdata__notificationtitle_Enabled), 5, 0), !bGXsfl_147_Refreshing);
         edtavWwp_sdtnotificationsdata__notificationdescription_Enabled = 0;
         AssignProp("", false, edtavWwp_sdtnotificationsdata__notificationdescription_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavWwp_sdtnotificationsdata__notificationdescription_Enabled), 5, 0), !bGXsfl_147_Refreshing);
         edtavWwp_sdtnotificationsdata__notificationdatetime_Enabled = 0;
         AssignProp("", false, edtavWwp_sdtnotificationsdata__notificationdatetime_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavWwp_sdtnotificationsdata__notificationdatetime_Enabled), 5, 0), !bGXsfl_147_Refreshing);
         edtavWwp_sdtnotificationsdata__notificationlink_Enabled = 0;
         AssignProp("", false, edtavWwp_sdtnotificationsdata__notificationlink_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavWwp_sdtnotificationsdata__notificationlink_Enabled), 5, 0), !bGXsfl_147_Refreshing);
         edtavValueprogressbar1_Enabled = 0;
         AssignProp("", false, edtavValueprogressbar1_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavValueprogressbar1_Enabled), 5, 0), true);
         edtavTotalvalueprogressbar1_Enabled = 0;
         AssignProp("", false, edtavTotalvalueprogressbar1_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavTotalvalueprogressbar1_Enabled), 5, 0), true);
         edtavValueprogressbar2_Enabled = 0;
         AssignProp("", false, edtavValueprogressbar2_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavValueprogressbar2_Enabled), 5, 0), true);
         edtavTotalvalueprogressbar2_Enabled = 0;
         AssignProp("", false, edtavTotalvalueprogressbar2_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavTotalvalueprogressbar2_Enabled), 5, 0), true);
         edtavValueprogressbar3_Enabled = 0;
         AssignProp("", false, edtavValueprogressbar3_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavValueprogressbar3_Enabled), 5, 0), true);
         edtavTotalvalueprogressbar3_Enabled = 0;
         AssignProp("", false, edtavTotalvalueprogressbar3_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavTotalvalueprogressbar3_Enabled), 5, 0), true);
         edtavValueprogressbar4_Enabled = 0;
         AssignProp("", false, edtavValueprogressbar4_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavValueprogressbar4_Enabled), 5, 0), true);
         edtavTotalvalueprogressbar4_Enabled = 0;
         AssignProp("", false, edtavTotalvalueprogressbar4_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavTotalvalueprogressbar4_Enabled), 5, 0), true);
         fix_multi_value_controls( ) ;
      }

      protected void STRUP0K0( )
      {
         /* Before Start, stand alone formulas. */
         before_start_formulas( ) ;
         /* Execute Start event if defined. */
         context.wbGlbDoneStart = 0;
         /* Execute user event: Start */
         E110K2 ();
         context.wbGlbDoneStart = 1;
         /* After Start, stand alone formulas. */
         if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
         {
            /* Read saved SDTs. */
            ajax_req_read_hidden_sdt(cgiGet( "Wwp_sdtnotificationsdata"), AV24WWP_SDTNotificationsData);
            ajax_req_read_hidden_sdt(cgiGet( "vELEMENTS"), AV14Elements);
            ajax_req_read_hidden_sdt(cgiGet( "vPARAMETERS"), AV15Parameters);
            ajax_req_read_hidden_sdt(cgiGet( "vITEMCLICKDATA"), AV16ItemClickData);
            ajax_req_read_hidden_sdt(cgiGet( "vITEMDOUBLECLICKDATA"), AV17ItemDoubleClickData);
            ajax_req_read_hidden_sdt(cgiGet( "vDRAGANDDROPDATA"), AV18DragAndDropData);
            ajax_req_read_hidden_sdt(cgiGet( "vFILTERCHANGEDDATA"), AV19FilterChangedData);
            ajax_req_read_hidden_sdt(cgiGet( "vITEMEXPANDDATA"), AV20ItemExpandData);
            ajax_req_read_hidden_sdt(cgiGet( "vITEMCOLLAPSEDATA"), AV21ItemCollapseData);
            ajax_req_read_hidden_sdt(cgiGet( "vWWP_SDTNOTIFICATIONSDATA"), AV24WWP_SDTNotificationsData);
            /* Read saved values. */
            nRC_GXsfl_147 = (int)(context.localUtil.CToN( cgiGet( "nRC_GXsfl_147"), ".", ","));
            GRID_nFirstRecordOnPage = (long)(context.localUtil.CToN( cgiGet( "GRID_nFirstRecordOnPage"), ".", ","));
            GRID_nEOF = (short)(context.localUtil.CToN( cgiGet( "GRID_nEOF"), ".", ","));
            subGrid_Rows = (int)(context.localUtil.CToN( cgiGet( "GRID_Rows"), ".", ","));
            GxWebStd.gx_hidden_field( context, "GRID_Rows", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid_Rows), 6, 0, ".", "")));
            Dvpanel_tablecards_Width = cgiGet( "DVPANEL_TABLECARDS_Width");
            Dvpanel_tablecards_Autowidth = StringUtil.StrToBool( cgiGet( "DVPANEL_TABLECARDS_Autowidth"));
            Dvpanel_tablecards_Autoheight = StringUtil.StrToBool( cgiGet( "DVPANEL_TABLECARDS_Autoheight"));
            Dvpanel_tablecards_Cls = cgiGet( "DVPANEL_TABLECARDS_Cls");
            Dvpanel_tablecards_Title = cgiGet( "DVPANEL_TABLECARDS_Title");
            Dvpanel_tablecards_Collapsible = StringUtil.StrToBool( cgiGet( "DVPANEL_TABLECARDS_Collapsible"));
            Dvpanel_tablecards_Collapsed = StringUtil.StrToBool( cgiGet( "DVPANEL_TABLECARDS_Collapsed"));
            Dvpanel_tablecards_Showcollapseicon = StringUtil.StrToBool( cgiGet( "DVPANEL_TABLECARDS_Showcollapseicon"));
            Dvpanel_tablecards_Iconposition = cgiGet( "DVPANEL_TABLECARDS_Iconposition");
            Dvpanel_tablecards_Autoscroll = StringUtil.StrToBool( cgiGet( "DVPANEL_TABLECARDS_Autoscroll"));
            Dvpanel_tablenotifications_Width = cgiGet( "DVPANEL_TABLENOTIFICATIONS_Width");
            Dvpanel_tablenotifications_Autowidth = StringUtil.StrToBool( cgiGet( "DVPANEL_TABLENOTIFICATIONS_Autowidth"));
            Dvpanel_tablenotifications_Autoheight = StringUtil.StrToBool( cgiGet( "DVPANEL_TABLENOTIFICATIONS_Autoheight"));
            Dvpanel_tablenotifications_Cls = cgiGet( "DVPANEL_TABLENOTIFICATIONS_Cls");
            Dvpanel_tablenotifications_Title = cgiGet( "DVPANEL_TABLENOTIFICATIONS_Title");
            Dvpanel_tablenotifications_Collapsible = StringUtil.StrToBool( cgiGet( "DVPANEL_TABLENOTIFICATIONS_Collapsible"));
            Dvpanel_tablenotifications_Collapsed = StringUtil.StrToBool( cgiGet( "DVPANEL_TABLENOTIFICATIONS_Collapsed"));
            Dvpanel_tablenotifications_Showcollapseicon = StringUtil.StrToBool( cgiGet( "DVPANEL_TABLENOTIFICATIONS_Showcollapseicon"));
            Dvpanel_tablenotifications_Iconposition = cgiGet( "DVPANEL_TABLENOTIFICATIONS_Iconposition");
            Dvpanel_tablenotifications_Autoscroll = StringUtil.StrToBool( cgiGet( "DVPANEL_TABLENOTIFICATIONS_Autoscroll"));
            Utchartsmootharea_Class = cgiGet( "UTCHARTSMOOTHAREA_Class");
            Utchartsmootharea_Height = cgiGet( "UTCHARTSMOOTHAREA_Height");
            Utchartsmootharea_Type = cgiGet( "UTCHARTSMOOTHAREA_Type");
            Utchartsmootharea_Charttype = cgiGet( "UTCHARTSMOOTHAREA_Charttype");
            Utchartsmootharea_Xaxistitle = cgiGet( "UTCHARTSMOOTHAREA_Xaxistitle");
            Progressbar1_Type = cgiGet( "PROGRESSBAR1_Type");
            Progressbar1_Cls = cgiGet( "PROGRESSBAR1_Cls");
            Progressbar1_Percentage = (int)(context.localUtil.CToN( cgiGet( "PROGRESSBAR1_Percentage"), ".", ","));
            Progressbar2_Type = cgiGet( "PROGRESSBAR2_Type");
            Progressbar2_Cls = cgiGet( "PROGRESSBAR2_Cls");
            Progressbar2_Percentage = (int)(context.localUtil.CToN( cgiGet( "PROGRESSBAR2_Percentage"), ".", ","));
            Progressbar3_Type = cgiGet( "PROGRESSBAR3_Type");
            Progressbar3_Cls = cgiGet( "PROGRESSBAR3_Cls");
            Progressbar3_Percentage = (int)(context.localUtil.CToN( cgiGet( "PROGRESSBAR3_Percentage"), ".", ","));
            Progressbar4_Type = cgiGet( "PROGRESSBAR4_Type");
            Progressbar4_Cls = cgiGet( "PROGRESSBAR4_Cls");
            Progressbar4_Percentage = (int)(context.localUtil.CToN( cgiGet( "PROGRESSBAR4_Percentage"), ".", ","));
            Dvpanel_tablechart1_Width = cgiGet( "DVPANEL_TABLECHART1_Width");
            Dvpanel_tablechart1_Autowidth = StringUtil.StrToBool( cgiGet( "DVPANEL_TABLECHART1_Autowidth"));
            Dvpanel_tablechart1_Autoheight = StringUtil.StrToBool( cgiGet( "DVPANEL_TABLECHART1_Autoheight"));
            Dvpanel_tablechart1_Cls = cgiGet( "DVPANEL_TABLECHART1_Cls");
            Dvpanel_tablechart1_Title = cgiGet( "DVPANEL_TABLECHART1_Title");
            Dvpanel_tablechart1_Collapsible = StringUtil.StrToBool( cgiGet( "DVPANEL_TABLECHART1_Collapsible"));
            Dvpanel_tablechart1_Collapsed = StringUtil.StrToBool( cgiGet( "DVPANEL_TABLECHART1_Collapsed"));
            Dvpanel_tablechart1_Showcollapseicon = StringUtil.StrToBool( cgiGet( "DVPANEL_TABLECHART1_Showcollapseicon"));
            Dvpanel_tablechart1_Iconposition = cgiGet( "DVPANEL_TABLECHART1_Iconposition");
            Dvpanel_tablechart1_Autoscroll = StringUtil.StrToBool( cgiGet( "DVPANEL_TABLECHART1_Autoscroll"));
            Utchartsmoothline_Height = cgiGet( "UTCHARTSMOOTHLINE_Height");
            Utchartsmoothline_Type = cgiGet( "UTCHARTSMOOTHLINE_Type");
            Utchartsmoothline_Charttype = cgiGet( "UTCHARTSMOOTHLINE_Charttype");
            Utchartsmoothline_Xaxistitle = cgiGet( "UTCHARTSMOOTHLINE_Xaxistitle");
            Dvpanel_tablechart4_Width = cgiGet( "DVPANEL_TABLECHART4_Width");
            Dvpanel_tablechart4_Autowidth = StringUtil.StrToBool( cgiGet( "DVPANEL_TABLECHART4_Autowidth"));
            Dvpanel_tablechart4_Autoheight = StringUtil.StrToBool( cgiGet( "DVPANEL_TABLECHART4_Autoheight"));
            Dvpanel_tablechart4_Cls = cgiGet( "DVPANEL_TABLECHART4_Cls");
            Dvpanel_tablechart4_Title = cgiGet( "DVPANEL_TABLECHART4_Title");
            Dvpanel_tablechart4_Collapsible = StringUtil.StrToBool( cgiGet( "DVPANEL_TABLECHART4_Collapsible"));
            Dvpanel_tablechart4_Collapsed = StringUtil.StrToBool( cgiGet( "DVPANEL_TABLECHART4_Collapsed"));
            Dvpanel_tablechart4_Showcollapseicon = StringUtil.StrToBool( cgiGet( "DVPANEL_TABLECHART4_Showcollapseicon"));
            Dvpanel_tablechart4_Iconposition = cgiGet( "DVPANEL_TABLECHART4_Iconposition");
            Dvpanel_tablechart4_Autoscroll = StringUtil.StrToBool( cgiGet( "DVPANEL_TABLECHART4_Autoscroll"));
            Utchartdoughnut_Height = cgiGet( "UTCHARTDOUGHNUT_Height");
            Utchartdoughnut_Type = cgiGet( "UTCHARTDOUGHNUT_Type");
            Utchartdoughnut_Showvalues = StringUtil.StrToBool( cgiGet( "UTCHARTDOUGHNUT_Showvalues"));
            Utchartdoughnut_Charttype = cgiGet( "UTCHARTDOUGHNUT_Charttype");
            Dvpanel_tablechart3_Width = cgiGet( "DVPANEL_TABLECHART3_Width");
            Dvpanel_tablechart3_Autowidth = StringUtil.StrToBool( cgiGet( "DVPANEL_TABLECHART3_Autowidth"));
            Dvpanel_tablechart3_Autoheight = StringUtil.StrToBool( cgiGet( "DVPANEL_TABLECHART3_Autoheight"));
            Dvpanel_tablechart3_Cls = cgiGet( "DVPANEL_TABLECHART3_Cls");
            Dvpanel_tablechart3_Title = cgiGet( "DVPANEL_TABLECHART3_Title");
            Dvpanel_tablechart3_Collapsible = StringUtil.StrToBool( cgiGet( "DVPANEL_TABLECHART3_Collapsible"));
            Dvpanel_tablechart3_Collapsed = StringUtil.StrToBool( cgiGet( "DVPANEL_TABLECHART3_Collapsed"));
            Dvpanel_tablechart3_Showcollapseicon = StringUtil.StrToBool( cgiGet( "DVPANEL_TABLECHART3_Showcollapseicon"));
            Dvpanel_tablechart3_Iconposition = cgiGet( "DVPANEL_TABLECHART3_Iconposition");
            Dvpanel_tablechart3_Autoscroll = StringUtil.StrToBool( cgiGet( "DVPANEL_TABLECHART3_Autoscroll"));
            Grid_empowerer_Gridinternalname = cgiGet( "GRID_EMPOWERER_Gridinternalname");
            nRC_GXsfl_147 = (int)(context.localUtil.CToN( cgiGet( "nRC_GXsfl_147"), ".", ","));
            nGXsfl_147_fel_idx = 0;
            while ( nGXsfl_147_fel_idx < nRC_GXsfl_147 )
            {
               nGXsfl_147_fel_idx = ((subGrid_Islastpage==1)&&(nGXsfl_147_fel_idx+1>subGrid_fnc_Recordsperpage( )) ? 1 : nGXsfl_147_fel_idx+1);
               sGXsfl_147_fel_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_147_fel_idx), 4, 0), 4, "0");
               SubsflControlProps_fel_1472( ) ;
               AV41GXV1 = (int)(nGXsfl_147_fel_idx+GRID_nFirstRecordOnPage);
               if ( ( AV24WWP_SDTNotificationsData.Count >= AV41GXV1 ) && ( AV41GXV1 > 0 ) )
               {
                  AV24WWP_SDTNotificationsData.CurrentItem = ((GeneXus.Programs.wwpbaseobjects.SdtWWP_SDTNotificationsData_WWP_SDTNotificationsDataItem)AV24WWP_SDTNotificationsData.Item(AV41GXV1));
               }
            }
            if ( nGXsfl_147_fel_idx == 0 )
            {
               nGXsfl_147_idx = 1;
               sGXsfl_147_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_147_idx), 4, 0), 4, "0");
               SubsflControlProps_1472( ) ;
            }
            nGXsfl_147_fel_idx = 1;
            /* Read variables values. */
            if ( ( ( context.localUtil.CToN( cgiGet( edtavValuecard1_Internalname), ".", ",") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtavValuecard1_Internalname), ".", ",") > Convert.ToDecimal( 99999999 )) ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "vVALUECARD1");
               GX_FocusControl = edtavValuecard1_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               AV8ValueCard1 = 0;
               AssignAttri("", false, "AV8ValueCard1", StringUtil.LTrimStr( (decimal)(AV8ValueCard1), 8, 0));
            }
            else
            {
               AV8ValueCard1 = (int)(context.localUtil.CToN( cgiGet( edtavValuecard1_Internalname), ".", ","));
               AssignAttri("", false, "AV8ValueCard1", StringUtil.LTrimStr( (decimal)(AV8ValueCard1), 8, 0));
            }
            if ( ( ( context.localUtil.CToN( cgiGet( edtavNumbersecondaryvalue1_Internalname), ".", ",") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtavNumbersecondaryvalue1_Internalname), ".", ",") > 99.99m ) ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "vNUMBERSECONDARYVALUE1");
               GX_FocusControl = edtavNumbersecondaryvalue1_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               AV38NumberSecondaryValue1 = 0;
               AssignAttri("", false, "AV38NumberSecondaryValue1", StringUtil.LTrimStr( AV38NumberSecondaryValue1, 5, 2));
            }
            else
            {
               AV38NumberSecondaryValue1 = context.localUtil.CToN( cgiGet( edtavNumbersecondaryvalue1_Internalname), ".", ",");
               AssignAttri("", false, "AV38NumberSecondaryValue1", StringUtil.LTrimStr( AV38NumberSecondaryValue1, 5, 2));
            }
            if ( ( ( context.localUtil.CToN( cgiGet( edtavValuecard2_Internalname), ".", ",") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtavValuecard2_Internalname), ".", ",") > Convert.ToDecimal( 99999999 )) ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "vVALUECARD2");
               GX_FocusControl = edtavValuecard2_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               AV9ValueCard2 = 0;
               AssignAttri("", false, "AV9ValueCard2", StringUtil.LTrimStr( (decimal)(AV9ValueCard2), 8, 0));
            }
            else
            {
               AV9ValueCard2 = (int)(context.localUtil.CToN( cgiGet( edtavValuecard2_Internalname), ".", ","));
               AssignAttri("", false, "AV9ValueCard2", StringUtil.LTrimStr( (decimal)(AV9ValueCard2), 8, 0));
            }
            if ( ( ( context.localUtil.CToN( cgiGet( edtavNumbersecondaryvalue2_Internalname), ".", ",") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtavNumbersecondaryvalue2_Internalname), ".", ",") > 99.99m ) ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "vNUMBERSECONDARYVALUE2");
               GX_FocusControl = edtavNumbersecondaryvalue2_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               AV37NumberSecondaryValue2 = 0;
               AssignAttri("", false, "AV37NumberSecondaryValue2", StringUtil.LTrimStr( AV37NumberSecondaryValue2, 5, 2));
            }
            else
            {
               AV37NumberSecondaryValue2 = context.localUtil.CToN( cgiGet( edtavNumbersecondaryvalue2_Internalname), ".", ",");
               AssignAttri("", false, "AV37NumberSecondaryValue2", StringUtil.LTrimStr( AV37NumberSecondaryValue2, 5, 2));
            }
            AV10ValueCard3 = cgiGet( edtavValuecard3_Internalname);
            AssignAttri("", false, "AV10ValueCard3", AV10ValueCard3);
            if ( ( ( context.localUtil.CToN( cgiGet( edtavNumbersecondaryvalue3_Internalname), ".", ",") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtavNumbersecondaryvalue3_Internalname), ".", ",") > 99.99m ) ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "vNUMBERSECONDARYVALUE3");
               GX_FocusControl = edtavNumbersecondaryvalue3_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               AV36NumberSecondaryValue3 = 0;
               AssignAttri("", false, "AV36NumberSecondaryValue3", StringUtil.LTrimStr( AV36NumberSecondaryValue3, 5, 2));
            }
            else
            {
               AV36NumberSecondaryValue3 = context.localUtil.CToN( cgiGet( edtavNumbersecondaryvalue3_Internalname), ".", ",");
               AssignAttri("", false, "AV36NumberSecondaryValue3", StringUtil.LTrimStr( AV36NumberSecondaryValue3, 5, 2));
            }
            if ( ( ( context.localUtil.CToN( cgiGet( edtavValuecard4_Internalname), ".", ",") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtavValuecard4_Internalname), ".", ",") > Convert.ToDecimal( 99999999 )) ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "vVALUECARD4");
               GX_FocusControl = edtavValuecard4_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               AV11ValueCard4 = 0;
               AssignAttri("", false, "AV11ValueCard4", StringUtil.LTrimStr( (decimal)(AV11ValueCard4), 8, 0));
            }
            else
            {
               AV11ValueCard4 = (int)(context.localUtil.CToN( cgiGet( edtavValuecard4_Internalname), ".", ","));
               AssignAttri("", false, "AV11ValueCard4", StringUtil.LTrimStr( (decimal)(AV11ValueCard4), 8, 0));
            }
            if ( ( ( context.localUtil.CToN( cgiGet( edtavNumbersecondaryvalue4_Internalname), ".", ",") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtavNumbersecondaryvalue4_Internalname), ".", ",") > 99.99m ) ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "vNUMBERSECONDARYVALUE4");
               GX_FocusControl = edtavNumbersecondaryvalue4_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               AV35NumberSecondaryValue4 = 0;
               AssignAttri("", false, "AV35NumberSecondaryValue4", StringUtil.LTrimStr( AV35NumberSecondaryValue4, 5, 2));
            }
            else
            {
               AV35NumberSecondaryValue4 = context.localUtil.CToN( cgiGet( edtavNumbersecondaryvalue4_Internalname), ".", ",");
               AssignAttri("", false, "AV35NumberSecondaryValue4", StringUtil.LTrimStr( AV35NumberSecondaryValue4, 5, 2));
            }
            if ( ( ( context.localUtil.CToN( cgiGet( edtavValuecard5_Internalname), ".", ",") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtavValuecard5_Internalname), ".", ",") > Convert.ToDecimal( 99999999 )) ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "vVALUECARD5");
               GX_FocusControl = edtavValuecard5_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               AV33ValueCard5 = 0;
               AssignAttri("", false, "AV33ValueCard5", StringUtil.LTrimStr( (decimal)(AV33ValueCard5), 8, 0));
            }
            else
            {
               AV33ValueCard5 = (int)(context.localUtil.CToN( cgiGet( edtavValuecard5_Internalname), ".", ","));
               AssignAttri("", false, "AV33ValueCard5", StringUtil.LTrimStr( (decimal)(AV33ValueCard5), 8, 0));
            }
            if ( ( ( context.localUtil.CToN( cgiGet( edtavNumbersecondaryvalue5_Internalname), ".", ",") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtavNumbersecondaryvalue5_Internalname), ".", ",") > 99.99m ) ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "vNUMBERSECONDARYVALUE5");
               GX_FocusControl = edtavNumbersecondaryvalue5_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               AV34NumberSecondaryValue5 = 0;
               AssignAttri("", false, "AV34NumberSecondaryValue5", StringUtil.LTrimStr( AV34NumberSecondaryValue5, 5, 2));
            }
            else
            {
               AV34NumberSecondaryValue5 = context.localUtil.CToN( cgiGet( edtavNumbersecondaryvalue5_Internalname), ".", ",");
               AssignAttri("", false, "AV34NumberSecondaryValue5", StringUtil.LTrimStr( AV34NumberSecondaryValue5, 5, 2));
            }
            if ( ( ( context.localUtil.CToN( cgiGet( edtavValueprogressbar1_Internalname), ".", ",") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtavValueprogressbar1_Internalname), ".", ",") > Convert.ToDecimal( 9999 )) ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "vVALUEPROGRESSBAR1");
               GX_FocusControl = edtavValueprogressbar1_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               AV31ValueProgressBar1 = 0;
               AssignAttri("", false, "AV31ValueProgressBar1", StringUtil.LTrimStr( (decimal)(AV31ValueProgressBar1), 4, 0));
            }
            else
            {
               AV31ValueProgressBar1 = (short)(context.localUtil.CToN( cgiGet( edtavValueprogressbar1_Internalname), ".", ","));
               AssignAttri("", false, "AV31ValueProgressBar1", StringUtil.LTrimStr( (decimal)(AV31ValueProgressBar1), 4, 0));
            }
            if ( ( ( context.localUtil.CToN( cgiGet( edtavTotalvalueprogressbar1_Internalname), ".", ",") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtavTotalvalueprogressbar1_Internalname), ".", ",") > Convert.ToDecimal( 9999 )) ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "vTOTALVALUEPROGRESSBAR1");
               GX_FocusControl = edtavTotalvalueprogressbar1_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               AV32TotalValueProgressBar1 = 0;
               AssignAttri("", false, "AV32TotalValueProgressBar1", StringUtil.LTrimStr( (decimal)(AV32TotalValueProgressBar1), 4, 0));
            }
            else
            {
               AV32TotalValueProgressBar1 = (short)(context.localUtil.CToN( cgiGet( edtavTotalvalueprogressbar1_Internalname), ".", ","));
               AssignAttri("", false, "AV32TotalValueProgressBar1", StringUtil.LTrimStr( (decimal)(AV32TotalValueProgressBar1), 4, 0));
            }
            if ( ( ( context.localUtil.CToN( cgiGet( edtavValueprogressbar2_Internalname), ".", ",") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtavValueprogressbar2_Internalname), ".", ",") > Convert.ToDecimal( 9999 )) ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "vVALUEPROGRESSBAR2");
               GX_FocusControl = edtavValueprogressbar2_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               AV29ValueProgressBar2 = 0;
               AssignAttri("", false, "AV29ValueProgressBar2", StringUtil.LTrimStr( (decimal)(AV29ValueProgressBar2), 4, 0));
            }
            else
            {
               AV29ValueProgressBar2 = (short)(context.localUtil.CToN( cgiGet( edtavValueprogressbar2_Internalname), ".", ","));
               AssignAttri("", false, "AV29ValueProgressBar2", StringUtil.LTrimStr( (decimal)(AV29ValueProgressBar2), 4, 0));
            }
            if ( ( ( context.localUtil.CToN( cgiGet( edtavTotalvalueprogressbar2_Internalname), ".", ",") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtavTotalvalueprogressbar2_Internalname), ".", ",") > Convert.ToDecimal( 9999 )) ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "vTOTALVALUEPROGRESSBAR2");
               GX_FocusControl = edtavTotalvalueprogressbar2_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               AV30TotalValueProgressBar2 = 0;
               AssignAttri("", false, "AV30TotalValueProgressBar2", StringUtil.LTrimStr( (decimal)(AV30TotalValueProgressBar2), 4, 0));
            }
            else
            {
               AV30TotalValueProgressBar2 = (short)(context.localUtil.CToN( cgiGet( edtavTotalvalueprogressbar2_Internalname), ".", ","));
               AssignAttri("", false, "AV30TotalValueProgressBar2", StringUtil.LTrimStr( (decimal)(AV30TotalValueProgressBar2), 4, 0));
            }
            if ( ( ( context.localUtil.CToN( cgiGet( edtavValueprogressbar3_Internalname), ".", ",") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtavValueprogressbar3_Internalname), ".", ",") > Convert.ToDecimal( 9999 )) ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "vVALUEPROGRESSBAR3");
               GX_FocusControl = edtavValueprogressbar3_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               AV27ValueProgressBar3 = 0;
               AssignAttri("", false, "AV27ValueProgressBar3", StringUtil.LTrimStr( (decimal)(AV27ValueProgressBar3), 4, 0));
            }
            else
            {
               AV27ValueProgressBar3 = (short)(context.localUtil.CToN( cgiGet( edtavValueprogressbar3_Internalname), ".", ","));
               AssignAttri("", false, "AV27ValueProgressBar3", StringUtil.LTrimStr( (decimal)(AV27ValueProgressBar3), 4, 0));
            }
            if ( ( ( context.localUtil.CToN( cgiGet( edtavTotalvalueprogressbar3_Internalname), ".", ",") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtavTotalvalueprogressbar3_Internalname), ".", ",") > Convert.ToDecimal( 9999 )) ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "vTOTALVALUEPROGRESSBAR3");
               GX_FocusControl = edtavTotalvalueprogressbar3_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               AV28TotalValueProgressBar3 = 0;
               AssignAttri("", false, "AV28TotalValueProgressBar3", StringUtil.LTrimStr( (decimal)(AV28TotalValueProgressBar3), 4, 0));
            }
            else
            {
               AV28TotalValueProgressBar3 = (short)(context.localUtil.CToN( cgiGet( edtavTotalvalueprogressbar3_Internalname), ".", ","));
               AssignAttri("", false, "AV28TotalValueProgressBar3", StringUtil.LTrimStr( (decimal)(AV28TotalValueProgressBar3), 4, 0));
            }
            if ( ( ( context.localUtil.CToN( cgiGet( edtavValueprogressbar4_Internalname), ".", ",") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtavValueprogressbar4_Internalname), ".", ",") > Convert.ToDecimal( 9999 )) ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "vVALUEPROGRESSBAR4");
               GX_FocusControl = edtavValueprogressbar4_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               AV25ValueProgressBar4 = 0;
               AssignAttri("", false, "AV25ValueProgressBar4", StringUtil.LTrimStr( (decimal)(AV25ValueProgressBar4), 4, 0));
            }
            else
            {
               AV25ValueProgressBar4 = (short)(context.localUtil.CToN( cgiGet( edtavValueprogressbar4_Internalname), ".", ","));
               AssignAttri("", false, "AV25ValueProgressBar4", StringUtil.LTrimStr( (decimal)(AV25ValueProgressBar4), 4, 0));
            }
            if ( ( ( context.localUtil.CToN( cgiGet( edtavTotalvalueprogressbar4_Internalname), ".", ",") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtavTotalvalueprogressbar4_Internalname), ".", ",") > Convert.ToDecimal( 9999 )) ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "vTOTALVALUEPROGRESSBAR4");
               GX_FocusControl = edtavTotalvalueprogressbar4_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               AV26TotalValueProgressBar4 = 0;
               AssignAttri("", false, "AV26TotalValueProgressBar4", StringUtil.LTrimStr( (decimal)(AV26TotalValueProgressBar4), 4, 0));
            }
            else
            {
               AV26TotalValueProgressBar4 = (short)(context.localUtil.CToN( cgiGet( edtavTotalvalueprogressbar4_Internalname), ".", ","));
               AssignAttri("", false, "AV26TotalValueProgressBar4", StringUtil.LTrimStr( (decimal)(AV26TotalValueProgressBar4), 4, 0));
            }
            /* Read subfile selected row values. */
            /* Read hidden variables. */
            GXKey = Crypto.GetSiteKey( );
            /* Check if conditions changed and reset current page numbers */
         }
         else
         {
            dynload_actions( ) ;
         }
      }

      protected void GXStart( )
      {
         /* Execute user event: Start */
         E110K2 ();
         if (returnInSub) return;
      }

      protected void E110K2( )
      {
         /* Start Routine */
         returnInSub = false;
         AV8ValueCard1 = 352;
         AssignAttri("", false, "AV8ValueCard1", StringUtil.LTrimStr( (decimal)(AV8ValueCard1), 8, 0));
         AV9ValueCard2 = 75520;
         AssignAttri("", false, "AV9ValueCard2", StringUtil.LTrimStr( (decimal)(AV9ValueCard2), 8, 0));
         AV10ValueCard3 = "+560";
         AssignAttri("", false, "AV10ValueCard3", AV10ValueCard3);
         AV11ValueCard4 = 2540;
         AssignAttri("", false, "AV11ValueCard4", StringUtil.LTrimStr( (decimal)(AV11ValueCard4), 8, 0));
         GXt_objcol_SdtHomeSampleData_HomeSampleDataItem1 = AV5HomeSampleData;
         new GeneXus.Programs.wwpbaseobjects.gethomesampledata(context ).execute( out  GXt_objcol_SdtHomeSampleData_HomeSampleDataItem1) ;
         AV5HomeSampleData = GXt_objcol_SdtHomeSampleData_HomeSampleDataItem1;
         AV13Axis = new SdtQueryViewerElements_Element(context);
         AV13Axis.gxTpr_Name = "ProductStatus";
         AV13Axis.gxTpr_Visible = "No";
         AV12Axes.Add(AV13Axis, 0);
         AV13Axis = new SdtQueryViewerElements_Element(context);
         AV13Axis.gxTpr_Name = "Check";
         AV13Axis.gxTpr_Visible = "No";
         AV12Axes.Add(AV13Axis, 0);
         divTablechart3_Height = 427;
         AssignProp("", false, divTablechart3_Internalname, "Height", StringUtil.LTrimStr( (decimal)(divTablechart3_Height), 9, 0), true);
         divTablechart4_Height = 427;
         AssignProp("", false, divTablechart4_Internalname, "Height", StringUtil.LTrimStr( (decimal)(divTablechart4_Height), 9, 0), true);
         divTablechart1_Height = 326;
         AssignProp("", false, divTablechart1_Internalname, "Height", StringUtil.LTrimStr( (decimal)(divTablechart1_Height), 9, 0), true);
         Grid_empowerer_Gridinternalname = subGrid_Internalname;
         ucGrid_empowerer.SendProperty(context, "", false, Grid_empowerer_Internalname, "GridInternalName", Grid_empowerer_Gridinternalname);
         subGrid_Rows = 0;
         GxWebStd.gx_hidden_field( context, "GRID_Rows", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid_Rows), 6, 0, ".", "")));
      }

      private void E120K2( )
      {
         /* Grid_Load Routine */
         returnInSub = false;
         AV41GXV1 = 1;
         while ( AV41GXV1 <= AV24WWP_SDTNotificationsData.Count )
         {
            AV24WWP_SDTNotificationsData.CurrentItem = ((GeneXus.Programs.wwpbaseobjects.SdtWWP_SDTNotificationsData_WWP_SDTNotificationsDataItem)AV24WWP_SDTNotificationsData.Item(AV41GXV1));
            /* Load Method */
            if ( wbStart != -1 )
            {
               wbStart = 147;
            }
            if ( ( subGrid_Islastpage == 1 ) || ( subGrid_Rows == 0 ) || ( ( GRID_nCurrentRecord >= GRID_nFirstRecordOnPage ) && ( GRID_nCurrentRecord < GRID_nFirstRecordOnPage + subGrid_fnc_Recordsperpage( ) ) ) )
            {
               sendrow_1472( ) ;
               GRID_nEOF = 0;
               GxWebStd.gx_hidden_field( context, "GRID_nEOF", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRID_nEOF), 1, 0, ".", "")));
               if ( GRID_nCurrentRecord + 1 >= subGrid_fnc_Recordcount( ) )
               {
                  GRID_nEOF = 1;
                  GxWebStd.gx_hidden_field( context, "GRID_nEOF", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRID_nEOF), 1, 0, ".", "")));
               }
            }
            GRID_nCurrentRecord = (long)(GRID_nCurrentRecord+1);
            if ( isFullAjaxMode( ) && ! bGXsfl_147_Refreshing )
            {
               DoAjaxLoad(147, GridRow);
            }
            AV41GXV1 = (int)(AV41GXV1+1);
         }
      }

      protected void wb_table14_235_0K2( bool wbgen )
      {
         if ( wbgen )
         {
            /* Table start */
            sStyleString = "";
            GxWebStd.gx_table_start( context, tblTabletotal4_Internalname, tblTabletotal4_Internalname, "", "", 0, "", "", 1, 2, sStyleString, "", "", 0);
            context.WriteHtmlText( "<tr>") ;
            context.WriteHtmlText( "<td>") ;
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "left", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavValueprogressbar4_Internalname, "Value Progress Bar4", "gx-form-item ProgressBarAdminV2NumberLabel", 0, true, "width: 25%;");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 239,'',false,'" + sGXsfl_147_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavValueprogressbar4_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(AV25ValueProgressBar4), 4, 0, ".", "")), StringUtil.LTrim( ((edtavValueprogressbar4_Enabled!=0) ? context.localUtil.Format( (decimal)(AV25ValueProgressBar4), "ZZZ9") : context.localUtil.Format( (decimal)(AV25ValueProgressBar4), "ZZZ9"))), " inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onblur(this,239);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavValueprogressbar4_Jsonclick, 0, "ProgressBarAdminV2Number", "", "", "", "", 1, edtavValueprogressbar4_Enabled, 0, "text", "1", 4, "chr", 1, "row", 4, 0, 0, 0, 1, -1, 0, true, "", "right", false, "", "HLP_WWPBaseObjects\\Home.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "<td>") ;
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblSeparatorprogressbar4_Internalname, "/", "", "", lblSeparatorprogressbar4_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "ProgressBarAdminV2NumberTotal", 0, "", 1, 1, 0, 0, "HLP_WWPBaseObjects\\Home.htm");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "<td>") ;
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "left", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavTotalvalueprogressbar4_Internalname, "Total Value Progress Bar4", "gx-form-item ProgressBarAdminV2NumberTotalLabel", 0, true, "width: 25%;");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 244,'',false,'" + sGXsfl_147_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavTotalvalueprogressbar4_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(AV26TotalValueProgressBar4), 4, 0, ".", "")), StringUtil.LTrim( ((edtavTotalvalueprogressbar4_Enabled!=0) ? context.localUtil.Format( (decimal)(AV26TotalValueProgressBar4), "ZZZ9") : context.localUtil.Format( (decimal)(AV26TotalValueProgressBar4), "ZZZ9"))), " inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onblur(this,244);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavTotalvalueprogressbar4_Jsonclick, 0, "ProgressBarAdminV2NumberTotal", "", "", "", "", 1, edtavTotalvalueprogressbar4_Enabled, 0, "text", "1", 4, "chr", 1, "row", 4, 0, 0, 0, 1, -1, 0, true, "", "right", false, "", "HLP_WWPBaseObjects\\Home.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "</tr>") ;
            /* End of table */
            context.WriteHtmlText( "</table>") ;
            wb_table14_235_0K2e( true) ;
         }
         else
         {
            wb_table14_235_0K2e( false) ;
         }
      }

      protected void wb_table13_216_0K2( bool wbgen )
      {
         if ( wbgen )
         {
            /* Table start */
            sStyleString = "";
            GxWebStd.gx_table_start( context, tblTabletotal3_Internalname, tblTabletotal3_Internalname, "", "", 0, "", "", 1, 2, sStyleString, "", "", 0);
            context.WriteHtmlText( "<tr>") ;
            context.WriteHtmlText( "<td>") ;
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "left", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavValueprogressbar3_Internalname, "Value Progress Bar3", "gx-form-item ProgressBarAdminV2NumberLabel", 0, true, "width: 25%;");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 220,'',false,'" + sGXsfl_147_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavValueprogressbar3_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(AV27ValueProgressBar3), 4, 0, ".", "")), StringUtil.LTrim( ((edtavValueprogressbar3_Enabled!=0) ? context.localUtil.Format( (decimal)(AV27ValueProgressBar3), "ZZZ9") : context.localUtil.Format( (decimal)(AV27ValueProgressBar3), "ZZZ9"))), " inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onblur(this,220);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavValueprogressbar3_Jsonclick, 0, "ProgressBarAdminV2Number", "", "", "", "", 1, edtavValueprogressbar3_Enabled, 0, "text", "1", 4, "chr", 1, "row", 4, 0, 0, 0, 1, -1, 0, true, "", "right", false, "", "HLP_WWPBaseObjects\\Home.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "<td>") ;
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblSeparatorprogressbar3_Internalname, "/", "", "", lblSeparatorprogressbar3_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "ProgressBarAdminV2NumberTotal", 0, "", 1, 1, 0, 0, "HLP_WWPBaseObjects\\Home.htm");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "<td>") ;
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "left", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavTotalvalueprogressbar3_Internalname, "Total Value Progress Bar3", "gx-form-item ProgressBarAdminV2NumberTotalLabel", 0, true, "width: 25%;");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 225,'',false,'" + sGXsfl_147_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavTotalvalueprogressbar3_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(AV28TotalValueProgressBar3), 4, 0, ".", "")), StringUtil.LTrim( ((edtavTotalvalueprogressbar3_Enabled!=0) ? context.localUtil.Format( (decimal)(AV28TotalValueProgressBar3), "ZZZ9") : context.localUtil.Format( (decimal)(AV28TotalValueProgressBar3), "ZZZ9"))), " inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onblur(this,225);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavTotalvalueprogressbar3_Jsonclick, 0, "ProgressBarAdminV2NumberTotal", "", "", "", "", 1, edtavTotalvalueprogressbar3_Enabled, 0, "text", "1", 4, "chr", 1, "row", 4, 0, 0, 0, 1, -1, 0, true, "", "right", false, "", "HLP_WWPBaseObjects\\Home.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "</tr>") ;
            /* End of table */
            context.WriteHtmlText( "</table>") ;
            wb_table13_216_0K2e( true) ;
         }
         else
         {
            wb_table13_216_0K2e( false) ;
         }
      }

      protected void wb_table12_197_0K2( bool wbgen )
      {
         if ( wbgen )
         {
            /* Table start */
            sStyleString = "";
            GxWebStd.gx_table_start( context, tblTabletotal2_Internalname, tblTabletotal2_Internalname, "", "", 0, "", "", 1, 2, sStyleString, "", "", 0);
            context.WriteHtmlText( "<tr>") ;
            context.WriteHtmlText( "<td>") ;
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "left", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavValueprogressbar2_Internalname, "Value Progress Bar2", "gx-form-item ProgressBarAdminV2NumberLabel", 0, true, "width: 25%;");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 201,'',false,'" + sGXsfl_147_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavValueprogressbar2_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(AV29ValueProgressBar2), 4, 0, ".", "")), StringUtil.LTrim( ((edtavValueprogressbar2_Enabled!=0) ? context.localUtil.Format( (decimal)(AV29ValueProgressBar2), "ZZZ9") : context.localUtil.Format( (decimal)(AV29ValueProgressBar2), "ZZZ9"))), " inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onblur(this,201);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavValueprogressbar2_Jsonclick, 0, "ProgressBarAdminV2Number", "", "", "", "", 1, edtavValueprogressbar2_Enabled, 0, "text", "1", 4, "chr", 1, "row", 4, 0, 0, 0, 1, -1, 0, true, "", "right", false, "", "HLP_WWPBaseObjects\\Home.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "<td>") ;
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblSeparatorprogressbar2_Internalname, "/", "", "", lblSeparatorprogressbar2_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "ProgressBarAdminV2NumberTotal", 0, "", 1, 1, 0, 0, "HLP_WWPBaseObjects\\Home.htm");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "<td>") ;
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "left", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavTotalvalueprogressbar2_Internalname, "Total Value Progress Bar2", "gx-form-item ProgressBarAdminV2NumberTotalLabel", 0, true, "width: 25%;");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 206,'',false,'" + sGXsfl_147_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavTotalvalueprogressbar2_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(AV30TotalValueProgressBar2), 4, 0, ".", "")), StringUtil.LTrim( ((edtavTotalvalueprogressbar2_Enabled!=0) ? context.localUtil.Format( (decimal)(AV30TotalValueProgressBar2), "ZZZ9") : context.localUtil.Format( (decimal)(AV30TotalValueProgressBar2), "ZZZ9"))), " inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onblur(this,206);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavTotalvalueprogressbar2_Jsonclick, 0, "ProgressBarAdminV2NumberTotal", "", "", "", "", 1, edtavTotalvalueprogressbar2_Enabled, 0, "text", "1", 4, "chr", 1, "row", 4, 0, 0, 0, 1, -1, 0, true, "", "right", false, "", "HLP_WWPBaseObjects\\Home.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "</tr>") ;
            /* End of table */
            context.WriteHtmlText( "</table>") ;
            wb_table12_197_0K2e( true) ;
         }
         else
         {
            wb_table12_197_0K2e( false) ;
         }
      }

      protected void wb_table11_178_0K2( bool wbgen )
      {
         if ( wbgen )
         {
            /* Table start */
            sStyleString = "";
            GxWebStd.gx_table_start( context, tblTabletotal1_Internalname, tblTabletotal1_Internalname, "", "", 0, "", "", 1, 2, sStyleString, "", "", 0);
            context.WriteHtmlText( "<tr>") ;
            context.WriteHtmlText( "<td>") ;
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "left", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavValueprogressbar1_Internalname, "Value Progress Bar1", "gx-form-item ProgressBarAdminV2NumberLabel", 0, true, "width: 25%;");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 182,'',false,'" + sGXsfl_147_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavValueprogressbar1_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(AV31ValueProgressBar1), 4, 0, ".", "")), StringUtil.LTrim( ((edtavValueprogressbar1_Enabled!=0) ? context.localUtil.Format( (decimal)(AV31ValueProgressBar1), "ZZZ9") : context.localUtil.Format( (decimal)(AV31ValueProgressBar1), "ZZZ9"))), " inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onblur(this,182);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavValueprogressbar1_Jsonclick, 0, "ProgressBarAdminV2Number", "", "", "", "", 1, edtavValueprogressbar1_Enabled, 0, "text", "1", 4, "chr", 1, "row", 4, 0, 0, 0, 1, -1, 0, true, "", "right", false, "", "HLP_WWPBaseObjects\\Home.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "<td>") ;
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblSeparatorprogressbar1_Internalname, "/", "", "", lblSeparatorprogressbar1_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "ProgressBarAdminV2NumberTotal", 0, "", 1, 1, 0, 0, "HLP_WWPBaseObjects\\Home.htm");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "<td>") ;
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "left", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavTotalvalueprogressbar1_Internalname, "Total Value Progress Bar1", "gx-form-item ProgressBarAdminV2NumberTotalLabel", 0, true, "width: 25%;");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 187,'',false,'" + sGXsfl_147_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavTotalvalueprogressbar1_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(AV32TotalValueProgressBar1), 4, 0, ".", "")), StringUtil.LTrim( ((edtavTotalvalueprogressbar1_Enabled!=0) ? context.localUtil.Format( (decimal)(AV32TotalValueProgressBar1), "ZZZ9") : context.localUtil.Format( (decimal)(AV32TotalValueProgressBar1), "ZZZ9"))), " inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onblur(this,187);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavTotalvalueprogressbar1_Jsonclick, 0, "ProgressBarAdminV2NumberTotal", "", "", "", "", 1, edtavTotalvalueprogressbar1_Enabled, 0, "text", "1", 4, "chr", 1, "row", 4, 0, 0, 0, 1, -1, 0, true, "", "right", false, "", "HLP_WWPBaseObjects\\Home.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "</tr>") ;
            /* End of table */
            context.WriteHtmlText( "</table>") ;
            wb_table11_178_0K2e( true) ;
         }
         else
         {
            wb_table11_178_0K2e( false) ;
         }
      }

      protected void wb_table10_128_0K2( bool wbgen )
      {
         if ( wbgen )
         {
            /* Table start */
            sStyleString = "";
            GxWebStd.gx_table_start( context, tblTablemergedmoreinfoiconcard5_Internalname, tblTablemergedmoreinfoiconcard5_Internalname, "", "TableMerged", 0, "", "", 0, 0, sStyleString, "", "", 0);
            context.WriteHtmlText( "<tr>") ;
            context.WriteHtmlText( "<td class='MergeDataCell'>") ;
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblMoreinfoiconcard5_Internalname, "<i class='fas fa-caret-down FontColorIconDanger' style='font-size: 12px'></i>", "", "", lblMoreinfoiconcard5_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "TextBlock", 0, "", 1, 1, 0, 2, "HLP_WWPBaseObjects\\Home.htm");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "<td>") ;
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "left", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavNumbersecondaryvalue5_Internalname, "Number Secondary Value5", "gx-form-item DashboardPercentageDangerLabel", 0, true, "width: 25%;");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 134,'',false,'" + sGXsfl_147_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavNumbersecondaryvalue5_Internalname, StringUtil.LTrim( StringUtil.NToC( AV34NumberSecondaryValue5, 5, 2, ".", "")), StringUtil.LTrim( ((edtavNumbersecondaryvalue5_Enabled!=0) ? context.localUtil.Format( AV34NumberSecondaryValue5, "Z9%") : context.localUtil.Format( AV34NumberSecondaryValue5, "Z9%"))), TempTags+" onchange=\""+"gx.num.valid_decimal( this, ',','.','2');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_decimal( this, ',','.','2');"+";gx.evt.onblur(this,134);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavNumbersecondaryvalue5_Jsonclick, 0, "DashboardPercentageDanger", "", "", "", "", 1, edtavNumbersecondaryvalue5_Enabled, 0, "text", "", 5, "chr", 1, "row", 5, 0, 0, 0, 1, -1, 0, true, "WWPBaseObjects\\WWPPercentage", "right", false, "", "HLP_WWPBaseObjects\\Home.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "<td>") ;
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblMoreinfocard5caption_Internalname, "From last month", "", "", lblMoreinfocard5caption_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "TextBlockMoreInfoCard", 0, "", 1, 1, 0, 0, "HLP_WWPBaseObjects\\Home.htm");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "</tr>") ;
            /* End of table */
            context.WriteHtmlText( "</table>") ;
            wb_table10_128_0K2e( true) ;
         }
         else
         {
            wb_table10_128_0K2e( false) ;
         }
      }

      protected void wb_table9_116_0K2( bool wbgen )
      {
         if ( wbgen )
         {
            /* Table start */
            sStyleString = "";
            GxWebStd.gx_table_start( context, tblTablemergedicon5_Internalname, tblTablemergedicon5_Internalname, "", "TableMerged", 0, "", "", 0, 0, sStyleString, "", "", 0);
            context.WriteHtmlText( "<tr>") ;
            context.WriteHtmlText( "<td class='MergeDataCell'>") ;
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblIcon5_Internalname, "<i class='fas fa-tag ProgressCardIcon' style='font-size: 12px'></i>", "", "", lblIcon5_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "TextBlock", 0, "", 1, 1, 0, 2, "HLP_WWPBaseObjects\\Home.htm");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "<td>") ;
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblDescriptioncard5_Internalname, "Mentions", "", "", lblDescriptioncard5_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "TextBlockDashboardDescriptionCard", 0, "", 1, 1, 0, 0, "HLP_WWPBaseObjects\\Home.htm");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "</tr>") ;
            /* End of table */
            context.WriteHtmlText( "</table>") ;
            wb_table9_116_0K2e( true) ;
         }
         else
         {
            wb_table9_116_0K2e( false) ;
         }
      }

      protected void wb_table8_103_0K2( bool wbgen )
      {
         if ( wbgen )
         {
            /* Table start */
            sStyleString = "";
            GxWebStd.gx_table_start( context, tblTablemergedmoreinfoiconcard4_Internalname, tblTablemergedmoreinfoiconcard4_Internalname, "", "TableMerged", 0, "", "", 0, 0, sStyleString, "", "", 0);
            context.WriteHtmlText( "<tr>") ;
            context.WriteHtmlText( "<td class='MergeDataCell'>") ;
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblMoreinfoiconcard4_Internalname, "<i class='fas fa-caret-down FontColorIconDanger' style='font-size: 12px'></i>", "", "", lblMoreinfoiconcard4_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "TextBlock", 0, "", 1, 1, 0, 2, "HLP_WWPBaseObjects\\Home.htm");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "<td>") ;
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "left", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavNumbersecondaryvalue4_Internalname, "Number Secondary Value4", "gx-form-item DashboardPercentageDangerLabel", 0, true, "width: 25%;");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 109,'',false,'" + sGXsfl_147_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavNumbersecondaryvalue4_Internalname, StringUtil.LTrim( StringUtil.NToC( AV35NumberSecondaryValue4, 5, 2, ".", "")), StringUtil.LTrim( ((edtavNumbersecondaryvalue4_Enabled!=0) ? context.localUtil.Format( AV35NumberSecondaryValue4, "Z9%") : context.localUtil.Format( AV35NumberSecondaryValue4, "Z9%"))), TempTags+" onchange=\""+"gx.num.valid_decimal( this, ',','.','2');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_decimal( this, ',','.','2');"+";gx.evt.onblur(this,109);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavNumbersecondaryvalue4_Jsonclick, 0, "DashboardPercentageDanger", "", "", "", "", 1, edtavNumbersecondaryvalue4_Enabled, 0, "text", "", 5, "chr", 1, "row", 5, 0, 0, 0, 1, -1, 0, true, "WWPBaseObjects\\WWPPercentage", "right", false, "", "HLP_WWPBaseObjects\\Home.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "<td>") ;
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblMoreinfocard4caption_Internalname, "Desde el mes pasado", "", "", lblMoreinfocard4caption_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "TextBlockMoreInfoCard", 0, "", 1, 1, 0, 0, "HLP_WWPBaseObjects\\Home.htm");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "</tr>") ;
            /* End of table */
            context.WriteHtmlText( "</table>") ;
            wb_table8_103_0K2e( true) ;
         }
         else
         {
            wb_table8_103_0K2e( false) ;
         }
      }

      protected void wb_table7_91_0K2( bool wbgen )
      {
         if ( wbgen )
         {
            /* Table start */
            sStyleString = "";
            GxWebStd.gx_table_start( context, tblTablemergedicon4_Internalname, tblTablemergedicon4_Internalname, "", "TableMerged", 0, "", "", 0, 0, sStyleString, "", "", 0);
            context.WriteHtmlText( "<tr>") ;
            context.WriteHtmlText( "<td class='MergeDataCell'>") ;
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblIcon4_Internalname, "<i class='fas fa-heart ProgressCardIcon' style='font-size: 12px'></i>", "", "", lblIcon4_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "TextBlock", 0, "", 1, 1, 0, 2, "HLP_WWPBaseObjects\\Home.htm");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "<td>") ;
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblDescriptioncard4_Internalname, "Views", "", "", lblDescriptioncard4_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "TextBlockDashboardDescriptionCard", 0, "", 1, 1, 0, 0, "HLP_WWPBaseObjects\\Home.htm");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "</tr>") ;
            /* End of table */
            context.WriteHtmlText( "</table>") ;
            wb_table7_91_0K2e( true) ;
         }
         else
         {
            wb_table7_91_0K2e( false) ;
         }
      }

      protected void wb_table6_78_0K2( bool wbgen )
      {
         if ( wbgen )
         {
            /* Table start */
            sStyleString = "";
            GxWebStd.gx_table_start( context, tblTablemergedmoreinfoiconcard3_Internalname, tblTablemergedmoreinfoiconcard3_Internalname, "", "TableMerged", 0, "", "", 0, 0, sStyleString, "", "", 0);
            context.WriteHtmlText( "<tr>") ;
            context.WriteHtmlText( "<td class='MergeDataCell'>") ;
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblMoreinfoiconcard3_Internalname, "<i class='fas fa-caret-down FontColorIconDanger' style='font-size: 12px'></i>", "", "", lblMoreinfoiconcard3_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "TextBlock", 0, "", 1, 1, 0, 2, "HLP_WWPBaseObjects\\Home.htm");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "<td>") ;
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "left", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavNumbersecondaryvalue3_Internalname, "Number Secondary Value3", "gx-form-item DashboardPercentageDangerLabel", 0, true, "width: 25%;");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 84,'',false,'" + sGXsfl_147_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavNumbersecondaryvalue3_Internalname, StringUtil.LTrim( StringUtil.NToC( AV36NumberSecondaryValue3, 5, 2, ".", "")), StringUtil.LTrim( ((edtavNumbersecondaryvalue3_Enabled!=0) ? context.localUtil.Format( AV36NumberSecondaryValue3, "Z9%") : context.localUtil.Format( AV36NumberSecondaryValue3, "Z9%"))), TempTags+" onchange=\""+"gx.num.valid_decimal( this, ',','.','2');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_decimal( this, ',','.','2');"+";gx.evt.onblur(this,84);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavNumbersecondaryvalue3_Jsonclick, 0, "DashboardPercentageDanger", "", "", "", "", 1, edtavNumbersecondaryvalue3_Enabled, 0, "text", "", 5, "chr", 1, "row", 5, 0, 0, 0, 1, -1, 0, true, "WWPBaseObjects\\WWPPercentage", "right", false, "", "HLP_WWPBaseObjects\\Home.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "<td>") ;
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblMoreinfocard3caption_Internalname, "Desde el mes pasado", "", "", lblMoreinfocard3caption_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "TextBlockMoreInfoCard", 0, "", 1, 1, 0, 0, "HLP_WWPBaseObjects\\Home.htm");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "</tr>") ;
            /* End of table */
            context.WriteHtmlText( "</table>") ;
            wb_table6_78_0K2e( true) ;
         }
         else
         {
            wb_table6_78_0K2e( false) ;
         }
      }

      protected void wb_table5_66_0K2( bool wbgen )
      {
         if ( wbgen )
         {
            /* Table start */
            sStyleString = "";
            GxWebStd.gx_table_start( context, tblTablemergedicon3_Internalname, tblTablemergedicon3_Internalname, "", "TableMerged", 0, "", "", 0, 0, sStyleString, "", "", 0);
            context.WriteHtmlText( "<tr>") ;
            context.WriteHtmlText( "<td class='MergeDataCell'>") ;
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblIcon3_Internalname, "<i class='fas fa-user ProgressCardIcon' style='font-size: 12px'></i>", "", "", lblIcon3_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "TextBlock", 0, "", 1, 1, 0, 2, "HLP_WWPBaseObjects\\Home.htm");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "<td>") ;
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblDescriptioncard3_Internalname, "Users", "", "", lblDescriptioncard3_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "TextBlockDashboardDescriptionCard", 0, "", 1, 1, 0, 0, "HLP_WWPBaseObjects\\Home.htm");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "</tr>") ;
            /* End of table */
            context.WriteHtmlText( "</table>") ;
            wb_table5_66_0K2e( true) ;
         }
         else
         {
            wb_table5_66_0K2e( false) ;
         }
      }

      protected void wb_table4_53_0K2( bool wbgen )
      {
         if ( wbgen )
         {
            /* Table start */
            sStyleString = "";
            GxWebStd.gx_table_start( context, tblTablemergedmoreinfoiconcard2_Internalname, tblTablemergedmoreinfoiconcard2_Internalname, "", "TableMerged", 0, "", "", 0, 0, sStyleString, "", "", 0);
            context.WriteHtmlText( "<tr>") ;
            context.WriteHtmlText( "<td class='MergeDataCell'>") ;
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblMoreinfoiconcard2_Internalname, "<i class='fas fa-caret-down FontColorIconDanger' style='font-size: 12px'></i>", "", "", lblMoreinfoiconcard2_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "TextBlock", 0, "", 1, 1, 0, 2, "HLP_WWPBaseObjects\\Home.htm");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "<td>") ;
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "left", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavNumbersecondaryvalue2_Internalname, "Number Secondary Value2", "gx-form-item DashboardPercentageDangerLabel", 0, true, "width: 25%;");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 59,'',false,'" + sGXsfl_147_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavNumbersecondaryvalue2_Internalname, StringUtil.LTrim( StringUtil.NToC( AV37NumberSecondaryValue2, 5, 2, ".", "")), StringUtil.LTrim( ((edtavNumbersecondaryvalue2_Enabled!=0) ? context.localUtil.Format( AV37NumberSecondaryValue2, "Z9%") : context.localUtil.Format( AV37NumberSecondaryValue2, "Z9%"))), TempTags+" onchange=\""+"gx.num.valid_decimal( this, ',','.','2');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_decimal( this, ',','.','2');"+";gx.evt.onblur(this,59);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavNumbersecondaryvalue2_Jsonclick, 0, "DashboardPercentageDanger", "", "", "", "", 1, edtavNumbersecondaryvalue2_Enabled, 0, "text", "", 5, "chr", 1, "row", 5, 0, 0, 0, 1, -1, 0, true, "WWPBaseObjects\\WWPPercentage", "right", false, "", "HLP_WWPBaseObjects\\Home.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "<td>") ;
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblMoreinfocard2caption_Internalname, "Desde el mes pasado", "", "", lblMoreinfocard2caption_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "TextBlockMoreInfoCard", 0, "", 1, 1, 0, 0, "HLP_WWPBaseObjects\\Home.htm");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "</tr>") ;
            /* End of table */
            context.WriteHtmlText( "</table>") ;
            wb_table4_53_0K2e( true) ;
         }
         else
         {
            wb_table4_53_0K2e( false) ;
         }
      }

      protected void wb_table3_41_0K2( bool wbgen )
      {
         if ( wbgen )
         {
            /* Table start */
            sStyleString = "";
            GxWebStd.gx_table_start( context, tblTablemergedicon2_Internalname, tblTablemergedicon2_Internalname, "", "TableMerged", 0, "", "", 0, 0, sStyleString, "", "", 0);
            context.WriteHtmlText( "<tr>") ;
            context.WriteHtmlText( "<td class='MergeDataCell'>") ;
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblIcon2_Internalname, "<i class='fas fa-university ProgressCardIcon' style='font-size: 12px'></i>", "", "", lblIcon2_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "TextBlock", 0, "", 1, 1, 0, 2, "HLP_WWPBaseObjects\\Home.htm");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "<td>") ;
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblDescriptioncard2_Internalname, "Revenue", "", "", lblDescriptioncard2_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "TextBlockDashboardDescriptionCard", 0, "", 1, 1, 0, 0, "HLP_WWPBaseObjects\\Home.htm");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "</tr>") ;
            /* End of table */
            context.WriteHtmlText( "</table>") ;
            wb_table3_41_0K2e( true) ;
         }
         else
         {
            wb_table3_41_0K2e( false) ;
         }
      }

      protected void wb_table2_28_0K2( bool wbgen )
      {
         if ( wbgen )
         {
            /* Table start */
            sStyleString = "";
            GxWebStd.gx_table_start( context, tblTablemergedmoreinfoiconcard1_Internalname, tblTablemergedmoreinfoiconcard1_Internalname, "", "TableMerged", 0, "", "", 0, 0, sStyleString, "", "", 0);
            context.WriteHtmlText( "<tr>") ;
            context.WriteHtmlText( "<td class='MergeDataCell'>") ;
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblMoreinfoiconcard1_Internalname, "<i class='fas fa-caret-up FontColorIconSuccess' style='font-size: 12px'></i>", "", "", lblMoreinfoiconcard1_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "TextBlock", 0, "", 1, 1, 0, 2, "HLP_WWPBaseObjects\\Home.htm");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "<td>") ;
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "left", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavNumbersecondaryvalue1_Internalname, "Number Secondary Value1", "gx-form-item DashboardPercentageSuccessLabel", 0, true, "width: 25%;");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 34,'',false,'" + sGXsfl_147_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavNumbersecondaryvalue1_Internalname, StringUtil.LTrim( StringUtil.NToC( AV38NumberSecondaryValue1, 5, 2, ".", "")), StringUtil.LTrim( ((edtavNumbersecondaryvalue1_Enabled!=0) ? context.localUtil.Format( AV38NumberSecondaryValue1, "Z9%") : context.localUtil.Format( AV38NumberSecondaryValue1, "Z9%"))), TempTags+" onchange=\""+"gx.num.valid_decimal( this, ',','.','2');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_decimal( this, ',','.','2');"+";gx.evt.onblur(this,34);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavNumbersecondaryvalue1_Jsonclick, 0, "DashboardPercentageSuccess", "", "", "", "", 1, edtavNumbersecondaryvalue1_Enabled, 0, "text", "", 5, "chr", 1, "row", 5, 0, 0, 0, 1, -1, 0, true, "WWPBaseObjects\\WWPPercentage", "right", false, "", "HLP_WWPBaseObjects\\Home.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "<td>") ;
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblMoreinfocard1caption_Internalname, "Desde el mes pasado", "", "", lblMoreinfocard1caption_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "TextBlockMoreInfoCard", 0, "", 1, 1, 0, 0, "HLP_WWPBaseObjects\\Home.htm");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "</tr>") ;
            /* End of table */
            context.WriteHtmlText( "</table>") ;
            wb_table2_28_0K2e( true) ;
         }
         else
         {
            wb_table2_28_0K2e( false) ;
         }
      }

      protected void wb_table1_16_0K2( bool wbgen )
      {
         if ( wbgen )
         {
            /* Table start */
            sStyleString = "";
            GxWebStd.gx_table_start( context, tblTablemergedicon1_Internalname, tblTablemergedicon1_Internalname, "", "TableMerged", 0, "", "", 0, 0, sStyleString, "", "", 0);
            context.WriteHtmlText( "<tr>") ;
            context.WriteHtmlText( "<td class='MergeDataCell'>") ;
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblIcon1_Internalname, "<i class='fas fa-calendar-plus ProgressCardIcon' style='font-size: 12px'></i>", "", "", lblIcon1_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "TextBlock", 0, "", 1, 1, 0, 2, "HLP_WWPBaseObjects\\Home.htm");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "<td>") ;
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblDescriptioncard1_Internalname, "Sales", "", "", lblDescriptioncard1_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "TextBlockDashboardDescriptionCard", 0, "", 1, 1, 0, 0, "HLP_WWPBaseObjects\\Home.htm");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "</tr>") ;
            /* End of table */
            context.WriteHtmlText( "</table>") ;
            wb_table1_16_0K2e( true) ;
         }
         else
         {
            wb_table1_16_0K2e( false) ;
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
         PA0K2( ) ;
         WS0K2( ) ;
         WE0K2( ) ;
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
         AddStyleSheetFile("QueryViewer/highcharts/css/highcharts.css", "");
         AddStyleSheetFile("QueryViewer/QueryViewer.css", "");
         AddStyleSheetFile("DVelop/Bootstrap/Shared/DVelopBootstrap.css", "");
         AddStyleSheetFile("DVelop/Bootstrap/Shared/DVelopBootstrap.css", "");
         AddStyleSheetFile("DVelop/Bootstrap/Shared/DVelopBootstrap.css", "");
         AddStyleSheetFile("DVelop/Bootstrap/Shared/DVelopBootstrap.css", "");
         AddStyleSheetFile("QueryViewer/highcharts/css/highcharts.css", "");
         AddStyleSheetFile("QueryViewer/QueryViewer.css", "");
         AddStyleSheetFile("QueryViewer/highcharts/css/highcharts.css", "");
         AddStyleSheetFile("QueryViewer/QueryViewer.css", "");
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
            context.AddJavascriptSource(StringUtil.RTrim( ((string)Form.Jscriptsrc.Item(idxLst))), "?202281810282141", true, true);
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
         if ( nGXWrapped != 1 )
         {
            context.AddJavascriptSource("messages.spa.js", "?"+GetCacheInvalidationToken( ), false, true);
            context.AddJavascriptSource("wwpbaseobjects/home.js", "?202281810282144", false, true);
            context.AddJavascriptSource("DVelop/Bootstrap/Shared/DVelopBootstrap.js", "", false, true);
            context.AddJavascriptSource("DVelop/Shared/WorkWithPlusCommon.js", "", false, true);
            context.AddJavascriptSource("DVelop/Bootstrap/Panel/BootstrapPanelRender.js", "", false, true);
            context.AddJavascriptSource("DVelop/Bootstrap/Shared/DVelopBootstrap.js", "", false, true);
            context.AddJavascriptSource("DVelop/Shared/WorkWithPlusCommon.js", "", false, true);
            context.AddJavascriptSource("DVelop/Bootstrap/Panel/BootstrapPanelRender.js", "", false, true);
            context.AddJavascriptSource("DVelop/Bootstrap/Shared/DVelopBootstrap.js", "", false, true);
            context.AddJavascriptSource("DVelop/Shared/WorkWithPlusCommon.js", "", false, true);
            context.AddJavascriptSource("DVelop/Bootstrap/Panel/BootstrapPanelRender.js", "", false, true);
            context.AddJavascriptSource("QueryViewer/QueryViewerCommon.js", "", false, true);
            context.AddJavascriptSource("QueryViewer/QueryViewerRender.js", "", false, true);
            context.AddJavascriptSource("DVelop/Shared/WorkWithPlusCommon.js", "", false, true);
            context.AddJavascriptSource("DVelop/Bootstrap/DVProgressIndicator/DVProgressIndicatorRender.js", "", false, true);
            context.AddJavascriptSource("DVelop/Shared/WorkWithPlusCommon.js", "", false, true);
            context.AddJavascriptSource("DVelop/Bootstrap/DVProgressIndicator/DVProgressIndicatorRender.js", "", false, true);
            context.AddJavascriptSource("DVelop/Shared/WorkWithPlusCommon.js", "", false, true);
            context.AddJavascriptSource("DVelop/Bootstrap/DVProgressIndicator/DVProgressIndicatorRender.js", "", false, true);
            context.AddJavascriptSource("DVelop/Shared/WorkWithPlusCommon.js", "", false, true);
            context.AddJavascriptSource("DVelop/Bootstrap/DVProgressIndicator/DVProgressIndicatorRender.js", "", false, true);
            context.AddJavascriptSource("DVelop/Bootstrap/Shared/DVelopBootstrap.js", "", false, true);
            context.AddJavascriptSource("DVelop/Shared/WorkWithPlusCommon.js", "", false, true);
            context.AddJavascriptSource("DVelop/Bootstrap/Panel/BootstrapPanelRender.js", "", false, true);
            context.AddJavascriptSource("QueryViewer/QueryViewerCommon.js", "", false, true);
            context.AddJavascriptSource("QueryViewer/QueryViewerRender.js", "", false, true);
            context.AddJavascriptSource("DVelop/Bootstrap/Shared/DVelopBootstrap.js", "", false, true);
            context.AddJavascriptSource("DVelop/Shared/WorkWithPlusCommon.js", "", false, true);
            context.AddJavascriptSource("DVelop/Bootstrap/Panel/BootstrapPanelRender.js", "", false, true);
            context.AddJavascriptSource("QueryViewer/QueryViewerCommon.js", "", false, true);
            context.AddJavascriptSource("QueryViewer/QueryViewerRender.js", "", false, true);
            context.AddJavascriptSource("DVelop/Shared/WorkWithPlusCommon.js", "", false, true);
            context.AddJavascriptSource("DVelop/GridEmpowerer/GridEmpowererRender.js", "", false, true);
         }
         /* End function include_jscripts */
      }

      protected void SubsflControlProps_1472( )
      {
         edtavWwp_sdtnotificationsdata__notificationid_Internalname = "WWP_SDTNOTIFICATIONSDATA__NOTIFICATIONID_"+sGXsfl_147_idx;
         edtavWwp_sdtnotificationsdata__notificationiconclass_Internalname = "WWP_SDTNOTIFICATIONSDATA__NOTIFICATIONICONCLASS_"+sGXsfl_147_idx;
         edtavWwp_sdtnotificationsdata__notificationtitle_Internalname = "WWP_SDTNOTIFICATIONSDATA__NOTIFICATIONTITLE_"+sGXsfl_147_idx;
         edtavWwp_sdtnotificationsdata__notificationdescription_Internalname = "WWP_SDTNOTIFICATIONSDATA__NOTIFICATIONDESCRIPTION_"+sGXsfl_147_idx;
         edtavWwp_sdtnotificationsdata__notificationdatetime_Internalname = "WWP_SDTNOTIFICATIONSDATA__NOTIFICATIONDATETIME_"+sGXsfl_147_idx;
         edtavWwp_sdtnotificationsdata__notificationlink_Internalname = "WWP_SDTNOTIFICATIONSDATA__NOTIFICATIONLINK_"+sGXsfl_147_idx;
      }

      protected void SubsflControlProps_fel_1472( )
      {
         edtavWwp_sdtnotificationsdata__notificationid_Internalname = "WWP_SDTNOTIFICATIONSDATA__NOTIFICATIONID_"+sGXsfl_147_fel_idx;
         edtavWwp_sdtnotificationsdata__notificationiconclass_Internalname = "WWP_SDTNOTIFICATIONSDATA__NOTIFICATIONICONCLASS_"+sGXsfl_147_fel_idx;
         edtavWwp_sdtnotificationsdata__notificationtitle_Internalname = "WWP_SDTNOTIFICATIONSDATA__NOTIFICATIONTITLE_"+sGXsfl_147_fel_idx;
         edtavWwp_sdtnotificationsdata__notificationdescription_Internalname = "WWP_SDTNOTIFICATIONSDATA__NOTIFICATIONDESCRIPTION_"+sGXsfl_147_fel_idx;
         edtavWwp_sdtnotificationsdata__notificationdatetime_Internalname = "WWP_SDTNOTIFICATIONSDATA__NOTIFICATIONDATETIME_"+sGXsfl_147_fel_idx;
         edtavWwp_sdtnotificationsdata__notificationlink_Internalname = "WWP_SDTNOTIFICATIONSDATA__NOTIFICATIONLINK_"+sGXsfl_147_fel_idx;
      }

      protected void sendrow_1472( )
      {
         SubsflControlProps_1472( ) ;
         WB0K0( ) ;
         if ( ( subGrid_Rows * 1 == 0 ) || ( nGXsfl_147_idx <= subGrid_fnc_Recordsperpage( ) * 1 ) )
         {
            GridRow = GXWebRow.GetNew(context,GridContainer);
            if ( subGrid_Backcolorstyle == 0 )
            {
               /* None style subfile background logic. */
               subGrid_Backstyle = 0;
               if ( StringUtil.StrCmp(subGrid_Class, "") != 0 )
               {
                  subGrid_Linesclass = subGrid_Class+"Odd";
               }
            }
            else if ( subGrid_Backcolorstyle == 1 )
            {
               /* Uniform style subfile background logic. */
               subGrid_Backstyle = 0;
               subGrid_Backcolor = subGrid_Allbackcolor;
               if ( StringUtil.StrCmp(subGrid_Class, "") != 0 )
               {
                  subGrid_Linesclass = subGrid_Class+"Uniform";
               }
            }
            else if ( subGrid_Backcolorstyle == 2 )
            {
               /* Header style subfile background logic. */
               subGrid_Backstyle = 1;
               if ( StringUtil.StrCmp(subGrid_Class, "") != 0 )
               {
                  subGrid_Linesclass = subGrid_Class+"Odd";
               }
               subGrid_Backcolor = (int)(0x0);
            }
            else if ( subGrid_Backcolorstyle == 3 )
            {
               /* Report style subfile background logic. */
               subGrid_Backstyle = 1;
               if ( ((int)((nGXsfl_147_idx) % (2))) == 0 )
               {
                  subGrid_Backcolor = (int)(0x0);
                  if ( StringUtil.StrCmp(subGrid_Class, "") != 0 )
                  {
                     subGrid_Linesclass = subGrid_Class+"Even";
                  }
               }
               else
               {
                  subGrid_Backcolor = (int)(0x0);
                  if ( StringUtil.StrCmp(subGrid_Class, "") != 0 )
                  {
                     subGrid_Linesclass = subGrid_Class+"Odd";
                  }
               }
            }
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<tr ") ;
               context.WriteHtmlText( " class=\""+"WorkWith"+"\" style=\""+""+"\"") ;
               context.WriteHtmlText( " gxrow=\""+sGXsfl_147_idx+"\">") ;
            }
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"right"+"\""+" style=\""+"display:none;"+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtavWwp_sdtnotificationsdata__notificationid_Internalname,StringUtil.LTrim( StringUtil.NToC( (decimal)(((GeneXus.Programs.wwpbaseobjects.SdtWWP_SDTNotificationsData_WWP_SDTNotificationsDataItem)AV24WWP_SDTNotificationsData.Item(AV41GXV1)).gxTpr_Notificationid), 5, 0, ".", "")),StringUtil.LTrim( ((edtavWwp_sdtnotificationsdata__notificationid_Enabled!=0) ? context.localUtil.Format( (decimal)(((GeneXus.Programs.wwpbaseobjects.SdtWWP_SDTNotificationsData_WWP_SDTNotificationsDataItem)AV24WWP_SDTNotificationsData.Item(AV41GXV1)).gxTpr_Notificationid), "ZZZZ9") : context.localUtil.Format( (decimal)(((GeneXus.Programs.wwpbaseobjects.SdtWWP_SDTNotificationsData_WWP_SDTNotificationsDataItem)AV24WWP_SDTNotificationsData.Item(AV41GXV1)).gxTpr_Notificationid), "ZZZZ9"))),(string)" inputmode=\"numeric\" pattern=\"[0-9]*\""+"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtavWwp_sdtnotificationsdata__notificationid_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn",(string)"",(short)0,(int)edtavWwp_sdtnotificationsdata__notificationid_Enabled,(short)0,(string)"text",(string)"1",(short)0,(string)"px",(short)17,(string)"px",(short)5,(short)0,(short)0,(short)147,(short)1,(short)-1,(short)0,(bool)true,(string)"",(string)"right",(bool)false,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"left"+"\""+" style=\""+""+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtavWwp_sdtnotificationsdata__notificationiconclass_Internalname,((GeneXus.Programs.wwpbaseobjects.SdtWWP_SDTNotificationsData_WWP_SDTNotificationsDataItem)AV24WWP_SDTNotificationsData.Item(AV41GXV1)).gxTpr_Notificationiconclass,(string)"",(string)"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtavWwp_sdtnotificationsdata__notificationiconclass_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn",(string)"",(short)-1,(int)edtavWwp_sdtnotificationsdata__notificationiconclass_Enabled,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)40,(short)0,(short)0,(short)147,(short)1,(short)-1,(short)-1,(bool)true,(string)"",(string)"left",(bool)true,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"left"+"\""+" style=\""+""+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtavWwp_sdtnotificationsdata__notificationtitle_Internalname,((GeneXus.Programs.wwpbaseobjects.SdtWWP_SDTNotificationsData_WWP_SDTNotificationsDataItem)AV24WWP_SDTNotificationsData.Item(AV41GXV1)).gxTpr_Notificationtitle,(string)"",(string)"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtavWwp_sdtnotificationsdata__notificationtitle_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn",(string)"",(short)-1,(int)edtavWwp_sdtnotificationsdata__notificationtitle_Enabled,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)200,(short)0,(short)0,(short)147,(short)1,(short)-1,(short)-1,(bool)true,(string)"",(string)"left",(bool)true,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"left"+"\""+" style=\""+"display:none;"+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtavWwp_sdtnotificationsdata__notificationdescription_Internalname,((GeneXus.Programs.wwpbaseobjects.SdtWWP_SDTNotificationsData_WWP_SDTNotificationsDataItem)AV24WWP_SDTNotificationsData.Item(AV41GXV1)).gxTpr_Notificationdescription,(string)"",(string)"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtavWwp_sdtnotificationsdata__notificationdescription_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn",(string)"",(short)0,(int)edtavWwp_sdtnotificationsdata__notificationdescription_Enabled,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)200,(short)0,(short)0,(short)147,(short)1,(short)-1,(short)-1,(bool)true,(string)"",(string)"left",(bool)true,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"right"+"\""+" style=\""+"display:none;"+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtavWwp_sdtnotificationsdata__notificationdatetime_Internalname,context.localUtil.TToC( ((GeneXus.Programs.wwpbaseobjects.SdtWWP_SDTNotificationsData_WWP_SDTNotificationsDataItem)AV24WWP_SDTNotificationsData.Item(AV41GXV1)).gxTpr_Notificationdatetime, 10, 8, 0, 3, "/", ":", " "),context.localUtil.Format( ((GeneXus.Programs.wwpbaseobjects.SdtWWP_SDTNotificationsData_WWP_SDTNotificationsDataItem)AV24WWP_SDTNotificationsData.Item(AV41GXV1)).gxTpr_Notificationdatetime, "99/99/99 99:99"),(string)"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtavWwp_sdtnotificationsdata__notificationdatetime_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn",(string)"",(short)0,(int)edtavWwp_sdtnotificationsdata__notificationdatetime_Enabled,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)14,(short)0,(short)0,(short)147,(short)1,(short)-1,(short)0,(bool)true,(string)"",(string)"right",(bool)false,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"left"+"\""+" style=\""+"display:none;"+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtavWwp_sdtnotificationsdata__notificationlink_Internalname,((GeneXus.Programs.wwpbaseobjects.SdtWWP_SDTNotificationsData_WWP_SDTNotificationsDataItem)AV24WWP_SDTNotificationsData.Item(AV41GXV1)).gxTpr_Notificationlink,(string)"",(string)"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtavWwp_sdtnotificationsdata__notificationlink_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn",(string)"",(short)0,(int)edtavWwp_sdtnotificationsdata__notificationlink_Enabled,(short)0,(string)"text",(string)"",(short)490,(string)"px",(short)17,(string)"px",(short)1000,(short)0,(short)0,(short)147,(short)1,(short)-1,(short)0,(bool)true,(string)"",(string)"left",(bool)true,(string)""});
            send_integrity_lvl_hashes0K2( ) ;
            GridContainer.AddRow(GridRow);
            nGXsfl_147_idx = ((subGrid_Islastpage==1)&&(nGXsfl_147_idx+1>subGrid_fnc_Recordsperpage( )) ? 1 : nGXsfl_147_idx+1);
            sGXsfl_147_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_147_idx), 4, 0), 4, "0");
            SubsflControlProps_1472( ) ;
         }
         /* End function sendrow_1472 */
      }

      protected void init_web_controls( )
      {
         /* End function init_web_controls */
      }

      protected void init_default_properties( )
      {
         lblIcon1_Internalname = "ICON1";
         lblDescriptioncard1_Internalname = "DESCRIPTIONCARD1";
         tblTablemergedicon1_Internalname = "TABLEMERGEDICON1";
         edtavValuecard1_Internalname = "vVALUECARD1";
         lblMoreinfoiconcard1_Internalname = "MOREINFOICONCARD1";
         edtavNumbersecondaryvalue1_Internalname = "vNUMBERSECONDARYVALUE1";
         lblMoreinfocard1caption_Internalname = "MOREINFOCARD1CAPTION";
         tblTablemergedmoreinfoiconcard1_Internalname = "TABLEMERGEDMOREINFOICONCARD1";
         divCard1_Internalname = "CARD1";
         lblIcon2_Internalname = "ICON2";
         lblDescriptioncard2_Internalname = "DESCRIPTIONCARD2";
         tblTablemergedicon2_Internalname = "TABLEMERGEDICON2";
         edtavValuecard2_Internalname = "vVALUECARD2";
         lblMoreinfoiconcard2_Internalname = "MOREINFOICONCARD2";
         edtavNumbersecondaryvalue2_Internalname = "vNUMBERSECONDARYVALUE2";
         lblMoreinfocard2caption_Internalname = "MOREINFOCARD2CAPTION";
         tblTablemergedmoreinfoiconcard2_Internalname = "TABLEMERGEDMOREINFOICONCARD2";
         divCard2_Internalname = "CARD2";
         lblIcon3_Internalname = "ICON3";
         lblDescriptioncard3_Internalname = "DESCRIPTIONCARD3";
         tblTablemergedicon3_Internalname = "TABLEMERGEDICON3";
         edtavValuecard3_Internalname = "vVALUECARD3";
         lblMoreinfoiconcard3_Internalname = "MOREINFOICONCARD3";
         edtavNumbersecondaryvalue3_Internalname = "vNUMBERSECONDARYVALUE3";
         lblMoreinfocard3caption_Internalname = "MOREINFOCARD3CAPTION";
         tblTablemergedmoreinfoiconcard3_Internalname = "TABLEMERGEDMOREINFOICONCARD3";
         divCard3_Internalname = "CARD3";
         lblIcon4_Internalname = "ICON4";
         lblDescriptioncard4_Internalname = "DESCRIPTIONCARD4";
         tblTablemergedicon4_Internalname = "TABLEMERGEDICON4";
         edtavValuecard4_Internalname = "vVALUECARD4";
         lblMoreinfoiconcard4_Internalname = "MOREINFOICONCARD4";
         edtavNumbersecondaryvalue4_Internalname = "vNUMBERSECONDARYVALUE4";
         lblMoreinfocard4caption_Internalname = "MOREINFOCARD4CAPTION";
         tblTablemergedmoreinfoiconcard4_Internalname = "TABLEMERGEDMOREINFOICONCARD4";
         divCard4_Internalname = "CARD4";
         lblIcon5_Internalname = "ICON5";
         lblDescriptioncard5_Internalname = "DESCRIPTIONCARD5";
         tblTablemergedicon5_Internalname = "TABLEMERGEDICON5";
         edtavValuecard5_Internalname = "vVALUECARD5";
         lblMoreinfoiconcard5_Internalname = "MOREINFOICONCARD5";
         edtavNumbersecondaryvalue5_Internalname = "vNUMBERSECONDARYVALUE5";
         lblMoreinfocard5caption_Internalname = "MOREINFOCARD5CAPTION";
         tblTablemergedmoreinfoiconcard5_Internalname = "TABLEMERGEDMOREINFOICONCARD5";
         divCard5_Internalname = "CARD5";
         divTablecards_Internalname = "TABLECARDS";
         Dvpanel_tablecards_Internalname = "DVPANEL_TABLECARDS";
         lblNotificationssubtitle_Internalname = "NOTIFICATIONSSUBTITLE";
         edtavWwp_sdtnotificationsdata__notificationid_Internalname = "WWP_SDTNOTIFICATIONSDATA__NOTIFICATIONID";
         edtavWwp_sdtnotificationsdata__notificationiconclass_Internalname = "WWP_SDTNOTIFICATIONSDATA__NOTIFICATIONICONCLASS";
         edtavWwp_sdtnotificationsdata__notificationtitle_Internalname = "WWP_SDTNOTIFICATIONSDATA__NOTIFICATIONTITLE";
         edtavWwp_sdtnotificationsdata__notificationdescription_Internalname = "WWP_SDTNOTIFICATIONSDATA__NOTIFICATIONDESCRIPTION";
         edtavWwp_sdtnotificationsdata__notificationdatetime_Internalname = "WWP_SDTNOTIFICATIONSDATA__NOTIFICATIONDATETIME";
         edtavWwp_sdtnotificationsdata__notificationlink_Internalname = "WWP_SDTNOTIFICATIONSDATA__NOTIFICATIONLINK";
         divTablenotifications_Internalname = "TABLENOTIFICATIONS";
         Dvpanel_tablenotifications_Internalname = "DVPANEL_TABLENOTIFICATIONS";
         lblCharttitle_Internalname = "CHARTTITLE";
         Utchartsmootharea_Internalname = "UTCHARTSMOOTHAREA";
         divTablereport_Internalname = "TABLEREPORT";
         lblIndicatorstitle_Internalname = "INDICATORSTITLE";
         lblDescriptionprogressbar1_Internalname = "DESCRIPTIONPROGRESSBAR1";
         edtavValueprogressbar1_Internalname = "vVALUEPROGRESSBAR1";
         lblSeparatorprogressbar1_Internalname = "SEPARATORPROGRESSBAR1";
         edtavTotalvalueprogressbar1_Internalname = "vTOTALVALUEPROGRESSBAR1";
         tblTabletotal1_Internalname = "TABLETOTAL1";
         divTabletitle1_Internalname = "TABLETITLE1";
         Progressbar1_Internalname = "PROGRESSBAR1";
         lblDescriptionprogressbar2_Internalname = "DESCRIPTIONPROGRESSBAR2";
         edtavValueprogressbar2_Internalname = "vVALUEPROGRESSBAR2";
         lblSeparatorprogressbar2_Internalname = "SEPARATORPROGRESSBAR2";
         edtavTotalvalueprogressbar2_Internalname = "vTOTALVALUEPROGRESSBAR2";
         tblTabletotal2_Internalname = "TABLETOTAL2";
         divTabletitle2_Internalname = "TABLETITLE2";
         Progressbar2_Internalname = "PROGRESSBAR2";
         lblDescriptionprogressbar3_Internalname = "DESCRIPTIONPROGRESSBAR3";
         edtavValueprogressbar3_Internalname = "vVALUEPROGRESSBAR3";
         lblSeparatorprogressbar3_Internalname = "SEPARATORPROGRESSBAR3";
         edtavTotalvalueprogressbar3_Internalname = "vTOTALVALUEPROGRESSBAR3";
         tblTabletotal3_Internalname = "TABLETOTAL3";
         divTabletitle3_Internalname = "TABLETITLE3";
         Progressbar3_Internalname = "PROGRESSBAR3";
         lblDescriptionprogressbar4_Internalname = "DESCRIPTIONPROGRESSBAR4";
         edtavValueprogressbar4_Internalname = "vVALUEPROGRESSBAR4";
         lblSeparatorprogressbar4_Internalname = "SEPARATORPROGRESSBAR4";
         edtavTotalvalueprogressbar4_Internalname = "vTOTALVALUEPROGRESSBAR4";
         tblTabletotal4_Internalname = "TABLETOTAL4";
         divTabletitle4_Internalname = "TABLETITLE4";
         Progressbar4_Internalname = "PROGRESSBAR4";
         divTablereportgoals_Internalname = "TABLEREPORTGOALS";
         divTablechart1_Internalname = "TABLECHART1";
         Dvpanel_tablechart1_Internalname = "DVPANEL_TABLECHART1";
         Utchartsmoothline_Internalname = "UTCHARTSMOOTHLINE";
         divTablechart4_Internalname = "TABLECHART4";
         Dvpanel_tablechart4_Internalname = "DVPANEL_TABLECHART4";
         Utchartdoughnut_Internalname = "UTCHARTDOUGHNUT";
         divTablechart3_Internalname = "TABLECHART3";
         Dvpanel_tablechart3_Internalname = "DVPANEL_TABLECHART3";
         divTablemain_Internalname = "TABLEMAIN";
         Grid_empowerer_Internalname = "GRID_EMPOWERER";
         divHtml_bottomauxiliarcontrols_Internalname = "HTML_BOTTOMAUXILIARCONTROLS";
         divLayoutmaintable_Internalname = "LAYOUTMAINTABLE";
         Form.Internalname = "FORM";
         subGrid_Internalname = "GRID";
      }

      public override void initialize_properties( )
      {
         context.SetDefaultTheme("WorkWithPlusTheme");
         if ( context.isSpaRequest( ) )
         {
            disableJsOutput();
         }
         init_default_properties( ) ;
         edtavWwp_sdtnotificationsdata__notificationlink_Jsonclick = "";
         edtavWwp_sdtnotificationsdata__notificationdatetime_Jsonclick = "";
         edtavWwp_sdtnotificationsdata__notificationdescription_Jsonclick = "";
         edtavWwp_sdtnotificationsdata__notificationtitle_Jsonclick = "";
         edtavWwp_sdtnotificationsdata__notificationiconclass_Jsonclick = "";
         edtavWwp_sdtnotificationsdata__notificationid_Jsonclick = "";
         edtavNumbersecondaryvalue1_Jsonclick = "";
         edtavNumbersecondaryvalue1_Enabled = 1;
         edtavNumbersecondaryvalue2_Jsonclick = "";
         edtavNumbersecondaryvalue2_Enabled = 1;
         edtavNumbersecondaryvalue3_Jsonclick = "";
         edtavNumbersecondaryvalue3_Enabled = 1;
         edtavNumbersecondaryvalue4_Jsonclick = "";
         edtavNumbersecondaryvalue4_Enabled = 1;
         edtavNumbersecondaryvalue5_Jsonclick = "";
         edtavNumbersecondaryvalue5_Enabled = 1;
         edtavTotalvalueprogressbar1_Jsonclick = "";
         edtavTotalvalueprogressbar1_Enabled = 1;
         edtavValueprogressbar1_Jsonclick = "";
         edtavValueprogressbar1_Enabled = 1;
         edtavTotalvalueprogressbar2_Jsonclick = "";
         edtavTotalvalueprogressbar2_Enabled = 1;
         edtavValueprogressbar2_Jsonclick = "";
         edtavValueprogressbar2_Enabled = 1;
         edtavTotalvalueprogressbar3_Jsonclick = "";
         edtavTotalvalueprogressbar3_Enabled = 1;
         edtavValueprogressbar3_Jsonclick = "";
         edtavValueprogressbar3_Enabled = 1;
         edtavTotalvalueprogressbar4_Jsonclick = "";
         edtavTotalvalueprogressbar4_Enabled = 1;
         edtavValueprogressbar4_Jsonclick = "";
         edtavValueprogressbar4_Enabled = 1;
         edtavWwp_sdtnotificationsdata__notificationlink_Enabled = -1;
         edtavWwp_sdtnotificationsdata__notificationdatetime_Enabled = -1;
         edtavWwp_sdtnotificationsdata__notificationdescription_Enabled = -1;
         edtavWwp_sdtnotificationsdata__notificationtitle_Enabled = -1;
         edtavWwp_sdtnotificationsdata__notificationiconclass_Enabled = -1;
         edtavWwp_sdtnotificationsdata__notificationid_Enabled = -1;
         Utchartdoughnut_Title = "";
         divTablechart3_Height = 0;
         Utchartsmoothline_Title = "";
         divTablechart4_Height = 0;
         Progressbar4_Caption = "";
         Progressbar3_Caption = "";
         Progressbar2_Caption = "";
         Progressbar1_Caption = "";
         Utchartsmootharea_Title = "";
         divTablechart1_Height = 0;
         subGrid_Allowcollapsing = 0;
         subGrid_Allowselection = 0;
         edtavWwp_sdtnotificationsdata__notificationlink_Enabled = 0;
         edtavWwp_sdtnotificationsdata__notificationdatetime_Enabled = 0;
         edtavWwp_sdtnotificationsdata__notificationdescription_Enabled = 0;
         edtavWwp_sdtnotificationsdata__notificationtitle_Enabled = 0;
         edtavWwp_sdtnotificationsdata__notificationiconclass_Enabled = 0;
         edtavWwp_sdtnotificationsdata__notificationid_Enabled = 0;
         subGrid_Header = "";
         subGrid_Class = "WorkWith";
         subGrid_Backcolorstyle = 0;
         edtavValuecard5_Jsonclick = "";
         edtavValuecard5_Enabled = 1;
         edtavValuecard4_Jsonclick = "";
         edtavValuecard4_Enabled = 1;
         edtavValuecard3_Jsonclick = "";
         edtavValuecard3_Enabled = 1;
         edtavValuecard2_Jsonclick = "";
         edtavValuecard2_Enabled = 1;
         edtavValuecard1_Jsonclick = "";
         edtavValuecard1_Enabled = 1;
         Dvpanel_tablechart3_Autoscroll = Convert.ToBoolean( 0);
         Dvpanel_tablechart3_Iconposition = "Right";
         Dvpanel_tablechart3_Showcollapseicon = Convert.ToBoolean( 0);
         Dvpanel_tablechart3_Collapsed = Convert.ToBoolean( 0);
         Dvpanel_tablechart3_Collapsible = Convert.ToBoolean( 0);
         Dvpanel_tablechart3_Title = "Orders";
         Dvpanel_tablechart3_Cls = "PanelFilled Panel_BaseColor";
         Dvpanel_tablechart3_Autoheight = Convert.ToBoolean( -1);
         Dvpanel_tablechart3_Autowidth = Convert.ToBoolean( 0);
         Dvpanel_tablechart3_Width = "100%";
         Utchartdoughnut_Charttype = "Doughnut";
         Utchartdoughnut_Showvalues = Convert.ToBoolean( 0);
         Utchartdoughnut_Type = "Chart";
         Utchartdoughnut_Height = "450px";
         Dvpanel_tablechart4_Autoscroll = Convert.ToBoolean( 0);
         Dvpanel_tablechart4_Iconposition = "Right";
         Dvpanel_tablechart4_Showcollapseicon = Convert.ToBoolean( 0);
         Dvpanel_tablechart4_Collapsed = Convert.ToBoolean( 0);
         Dvpanel_tablechart4_Collapsible = Convert.ToBoolean( 0);
         Dvpanel_tablechart4_Title = "Task Board";
         Dvpanel_tablechart4_Cls = "PanelFilled Panel_BaseColor";
         Dvpanel_tablechart4_Autoheight = Convert.ToBoolean( -1);
         Dvpanel_tablechart4_Autowidth = Convert.ToBoolean( 0);
         Dvpanel_tablechart4_Width = "100%";
         Utchartsmoothline_Xaxistitle = " ";
         Utchartsmoothline_Charttype = "Bar";
         Utchartsmoothline_Type = "Chart";
         Utchartsmoothline_Height = "450px";
         Dvpanel_tablechart1_Autoscroll = Convert.ToBoolean( 0);
         Dvpanel_tablechart1_Iconposition = "Right";
         Dvpanel_tablechart1_Showcollapseicon = Convert.ToBoolean( 0);
         Dvpanel_tablechart1_Collapsed = Convert.ToBoolean( 0);
         Dvpanel_tablechart1_Collapsible = Convert.ToBoolean( -1);
         Dvpanel_tablechart1_Title = "";
         Dvpanel_tablechart1_Cls = "PanelNoHeader";
         Dvpanel_tablechart1_Autoheight = Convert.ToBoolean( -1);
         Dvpanel_tablechart1_Autowidth = Convert.ToBoolean( 0);
         Dvpanel_tablechart1_Width = "100%";
         Progressbar4_Percentage = 20;
         Progressbar4_Cls = "ProgressBarMaterial";
         Progressbar4_Type = "Bar";
         Progressbar3_Percentage = 74;
         Progressbar3_Cls = "ProgressBarMaterial";
         Progressbar3_Type = "Bar";
         Progressbar2_Percentage = 56;
         Progressbar2_Cls = "ProgressBarMaterial";
         Progressbar2_Type = "Bar";
         Progressbar1_Percentage = 83;
         Progressbar1_Cls = "ProgressBarMaterial";
         Progressbar1_Type = "Bar";
         Utchartsmootharea_Xaxistitle = " ";
         Utchartsmootharea_Charttype = "SmoothLine";
         Utchartsmootharea_Type = "Chart";
         Utchartsmootharea_Height = "240px";
         Utchartsmootharea_Class = "";
         Dvpanel_tablenotifications_Autoscroll = Convert.ToBoolean( 0);
         Dvpanel_tablenotifications_Iconposition = "Right";
         Dvpanel_tablenotifications_Showcollapseicon = Convert.ToBoolean( 0);
         Dvpanel_tablenotifications_Collapsed = Convert.ToBoolean( 0);
         Dvpanel_tablenotifications_Collapsible = Convert.ToBoolean( 0);
         Dvpanel_tablenotifications_Title = "Notificaciones";
         Dvpanel_tablenotifications_Cls = "PanelFilled Panel_BaseColor";
         Dvpanel_tablenotifications_Autoheight = Convert.ToBoolean( -1);
         Dvpanel_tablenotifications_Autowidth = Convert.ToBoolean( 0);
         Dvpanel_tablenotifications_Width = "100%";
         Dvpanel_tablecards_Autoscroll = Convert.ToBoolean( 0);
         Dvpanel_tablecards_Iconposition = "Right";
         Dvpanel_tablecards_Showcollapseicon = Convert.ToBoolean( 0);
         Dvpanel_tablecards_Collapsed = Convert.ToBoolean( 0);
         Dvpanel_tablecards_Collapsible = Convert.ToBoolean( -1);
         Dvpanel_tablecards_Title = "";
         Dvpanel_tablecards_Cls = "PanelNoHeader";
         Dvpanel_tablecards_Autoheight = Convert.ToBoolean( -1);
         Dvpanel_tablecards_Autowidth = Convert.ToBoolean( 0);
         Dvpanel_tablecards_Width = "100%";
         Form.Headerrawhtml = "";
         Form.Background = "";
         Form.Textcolor = 0;
         Form.Backcolor = (int)(0xFFFFFF);
         Form.Caption = "Inicio";
         subGrid_Rows = 0;
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
         setEventMetadata("REFRESH","{handler:'Refresh',iparms:[{av:'GRID_nFirstRecordOnPage'},{av:'GRID_nEOF'},{av:'AV24WWP_SDTNotificationsData',fld:'vWWP_SDTNOTIFICATIONSDATA',grid:147,pic:''},{av:'nGXsfl_147_idx', ctrl: 'GRID', prop:'GridCurrRow', grid:147},{av:'nRC_GXsfl_147',ctrl:'GRID',prop:'GridRC',grid:147},{av:'subGrid_Rows',ctrl:'GRID',prop:'Rows'}]");
         setEventMetadata("REFRESH",",oparms:[]}");
         setEventMetadata("GRID.LOAD","{handler:'E120K2',iparms:[]");
         setEventMetadata("GRID.LOAD",",oparms:[]}");
         setEventMetadata("GRID_FIRSTPAGE","{handler:'subgrid_firstpage',iparms:[{av:'GRID_nFirstRecordOnPage'},{av:'GRID_nEOF'},{av:'subGrid_Rows',ctrl:'GRID',prop:'Rows'},{av:'AV24WWP_SDTNotificationsData',fld:'vWWP_SDTNOTIFICATIONSDATA',grid:147,pic:''},{av:'nGXsfl_147_idx', ctrl: 'GRID', prop:'GridCurrRow', grid:147},{av:'nRC_GXsfl_147',ctrl:'GRID',prop:'GridRC',grid:147}]");
         setEventMetadata("GRID_FIRSTPAGE",",oparms:[]}");
         setEventMetadata("GRID_PREVPAGE","{handler:'subgrid_previouspage',iparms:[{av:'GRID_nFirstRecordOnPage'},{av:'GRID_nEOF'},{av:'subGrid_Rows',ctrl:'GRID',prop:'Rows'},{av:'AV24WWP_SDTNotificationsData',fld:'vWWP_SDTNOTIFICATIONSDATA',grid:147,pic:''},{av:'nGXsfl_147_idx', ctrl: 'GRID', prop:'GridCurrRow', grid:147},{av:'nRC_GXsfl_147',ctrl:'GRID',prop:'GridRC',grid:147}]");
         setEventMetadata("GRID_PREVPAGE",",oparms:[]}");
         setEventMetadata("GRID_NEXTPAGE","{handler:'subgrid_nextpage',iparms:[{av:'GRID_nFirstRecordOnPage'},{av:'GRID_nEOF'},{av:'subGrid_Rows',ctrl:'GRID',prop:'Rows'},{av:'AV24WWP_SDTNotificationsData',fld:'vWWP_SDTNOTIFICATIONSDATA',grid:147,pic:''},{av:'nGXsfl_147_idx', ctrl: 'GRID', prop:'GridCurrRow', grid:147},{av:'nRC_GXsfl_147',ctrl:'GRID',prop:'GridRC',grid:147}]");
         setEventMetadata("GRID_NEXTPAGE",",oparms:[]}");
         setEventMetadata("GRID_LASTPAGE","{handler:'subgrid_lastpage',iparms:[{av:'GRID_nFirstRecordOnPage'},{av:'GRID_nEOF'},{av:'subGrid_Rows',ctrl:'GRID',prop:'Rows'},{av:'AV24WWP_SDTNotificationsData',fld:'vWWP_SDTNOTIFICATIONSDATA',grid:147,pic:''},{av:'nGXsfl_147_idx', ctrl: 'GRID', prop:'GridCurrRow', grid:147},{av:'nRC_GXsfl_147',ctrl:'GRID',prop:'GridRC',grid:147}]");
         setEventMetadata("GRID_LASTPAGE",",oparms:[]}");
         setEventMetadata("VALIDV_GXV7","{handler:'Validv_Gxv7',iparms:[]");
         setEventMetadata("VALIDV_GXV7",",oparms:[]}");
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
         sDynURL = "";
         FormProcess = "";
         bodyStyle = "";
         GXKey = "";
         AV24WWP_SDTNotificationsData = new GXBaseCollection<GeneXus.Programs.wwpbaseobjects.SdtWWP_SDTNotificationsData_WWP_SDTNotificationsDataItem>( context, "WWP_SDTNotificationsDataItem", "SIGERP_ADVANCED");
         AV14Elements = new GXBaseCollection<SdtQueryViewerElements_Element>( context, "Element", "SIGERP_ADVANCED");
         AV15Parameters = new GXBaseCollection<SdtQueryViewerParameters_Parameter>( context, "Parameter", "SIGERP_ADVANCED");
         AV16ItemClickData = new SdtQueryViewerItemClickData(context);
         AV17ItemDoubleClickData = new SdtQueryViewerItemDoubleClickData(context);
         AV18DragAndDropData = new SdtQueryViewerDragAndDropData(context);
         AV19FilterChangedData = new SdtQueryViewerFilterChangedData(context);
         AV20ItemExpandData = new SdtQueryViewerItemExpandData(context);
         AV21ItemCollapseData = new SdtQueryViewerItemCollapseData(context);
         Grid_empowerer_Gridinternalname = "";
         GX_FocusControl = "";
         Form = new GXWebForm();
         sPrefix = "";
         ucDvpanel_tablecards = new GXUserControl();
         TempTags = "";
         AV10ValueCard3 = "";
         ucDvpanel_tablenotifications = new GXUserControl();
         lblNotificationssubtitle_Jsonclick = "";
         GridContainer = new GXWebGrid( context);
         sStyleString = "";
         subGrid_Linesclass = "";
         GridColumn = new GXWebColumn();
         ucDvpanel_tablechart1 = new GXUserControl();
         lblCharttitle_Jsonclick = "";
         ucUtchartsmootharea = new GXUserControl();
         lblIndicatorstitle_Jsonclick = "";
         lblDescriptionprogressbar1_Jsonclick = "";
         ucProgressbar1 = new GXUserControl();
         lblDescriptionprogressbar2_Jsonclick = "";
         ucProgressbar2 = new GXUserControl();
         lblDescriptionprogressbar3_Jsonclick = "";
         ucProgressbar3 = new GXUserControl();
         lblDescriptionprogressbar4_Jsonclick = "";
         ucProgressbar4 = new GXUserControl();
         ucDvpanel_tablechart4 = new GXUserControl();
         ucUtchartsmoothline = new GXUserControl();
         ucDvpanel_tablechart3 = new GXUserControl();
         ucUtchartdoughnut = new GXUserControl();
         ucGrid_empowerer = new GXUserControl();
         sEvt = "";
         EvtGridId = "";
         EvtRowId = "";
         sEvtType = "";
         AV5HomeSampleData = new GXBaseCollection<GeneXus.Programs.wwpbaseobjects.SdtHomeSampleData_HomeSampleDataItem>( context, "HomeSampleDataItem", "SIGERP_ADVANCED");
         GXt_objcol_SdtHomeSampleData_HomeSampleDataItem1 = new GXBaseCollection<GeneXus.Programs.wwpbaseobjects.SdtHomeSampleData_HomeSampleDataItem>( context, "HomeSampleDataItem", "SIGERP_ADVANCED");
         AV13Axis = new SdtQueryViewerElements_Element(context);
         AV12Axes = new GXBaseCollection<SdtQueryViewerElements_Element>( context, "Element", "SIGERP_ADVANCED");
         GridRow = new GXWebRow();
         lblSeparatorprogressbar4_Jsonclick = "";
         lblSeparatorprogressbar3_Jsonclick = "";
         lblSeparatorprogressbar2_Jsonclick = "";
         lblSeparatorprogressbar1_Jsonclick = "";
         lblMoreinfoiconcard5_Jsonclick = "";
         lblMoreinfocard5caption_Jsonclick = "";
         lblIcon5_Jsonclick = "";
         lblDescriptioncard5_Jsonclick = "";
         lblMoreinfoiconcard4_Jsonclick = "";
         lblMoreinfocard4caption_Jsonclick = "";
         lblIcon4_Jsonclick = "";
         lblDescriptioncard4_Jsonclick = "";
         lblMoreinfoiconcard3_Jsonclick = "";
         lblMoreinfocard3caption_Jsonclick = "";
         lblIcon3_Jsonclick = "";
         lblDescriptioncard3_Jsonclick = "";
         lblMoreinfoiconcard2_Jsonclick = "";
         lblMoreinfocard2caption_Jsonclick = "";
         lblIcon2_Jsonclick = "";
         lblDescriptioncard2_Jsonclick = "";
         lblMoreinfoiconcard1_Jsonclick = "";
         lblMoreinfocard1caption_Jsonclick = "";
         lblIcon1_Jsonclick = "";
         lblDescriptioncard1_Jsonclick = "";
         BackMsgLst = new msglist();
         LclMsgLst = new msglist();
         ROClassString = "";
         /* GeneXus formulas. */
         context.Gx_err = 0;
         edtavValuecard1_Enabled = 0;
         edtavNumbersecondaryvalue1_Enabled = 0;
         edtavValuecard2_Enabled = 0;
         edtavNumbersecondaryvalue2_Enabled = 0;
         edtavValuecard3_Enabled = 0;
         edtavNumbersecondaryvalue3_Enabled = 0;
         edtavValuecard4_Enabled = 0;
         edtavNumbersecondaryvalue4_Enabled = 0;
         edtavValuecard5_Enabled = 0;
         edtavNumbersecondaryvalue5_Enabled = 0;
         edtavWwp_sdtnotificationsdata__notificationid_Enabled = 0;
         edtavWwp_sdtnotificationsdata__notificationiconclass_Enabled = 0;
         edtavWwp_sdtnotificationsdata__notificationtitle_Enabled = 0;
         edtavWwp_sdtnotificationsdata__notificationdescription_Enabled = 0;
         edtavWwp_sdtnotificationsdata__notificationdatetime_Enabled = 0;
         edtavWwp_sdtnotificationsdata__notificationlink_Enabled = 0;
         edtavValueprogressbar1_Enabled = 0;
         edtavTotalvalueprogressbar1_Enabled = 0;
         edtavValueprogressbar2_Enabled = 0;
         edtavTotalvalueprogressbar2_Enabled = 0;
         edtavValueprogressbar3_Enabled = 0;
         edtavTotalvalueprogressbar3_Enabled = 0;
         edtavValueprogressbar4_Enabled = 0;
         edtavTotalvalueprogressbar4_Enabled = 0;
      }

      private short GRID_nEOF ;
      private short nGotPars ;
      private short GxWebError ;
      private short initialized ;
      private short gxajaxcallmode ;
      private short nGXWrapped ;
      private short wbEnd ;
      private short wbStart ;
      private short subGrid_Backcolorstyle ;
      private short subGrid_Titlebackstyle ;
      private short subGrid_Allowselection ;
      private short subGrid_Allowhovering ;
      private short subGrid_Allowcollapsing ;
      private short subGrid_Collapsed ;
      private short nDonePA ;
      private short AV31ValueProgressBar1 ;
      private short AV32TotalValueProgressBar1 ;
      private short AV29ValueProgressBar2 ;
      private short AV30TotalValueProgressBar2 ;
      private short AV27ValueProgressBar3 ;
      private short AV28TotalValueProgressBar3 ;
      private short AV25ValueProgressBar4 ;
      private short AV26TotalValueProgressBar4 ;
      private short subGrid_Backstyle ;
      private int nRC_GXsfl_147 ;
      private int nGXsfl_147_idx=1 ;
      private int subGrid_Rows ;
      private int Progressbar1_Percentage ;
      private int Progressbar2_Percentage ;
      private int Progressbar3_Percentage ;
      private int Progressbar4_Percentage ;
      private int AV8ValueCard1 ;
      private int edtavValuecard1_Enabled ;
      private int AV9ValueCard2 ;
      private int edtavValuecard2_Enabled ;
      private int edtavValuecard3_Enabled ;
      private int AV11ValueCard4 ;
      private int edtavValuecard4_Enabled ;
      private int AV33ValueCard5 ;
      private int edtavValuecard5_Enabled ;
      private int subGrid_Titlebackcolor ;
      private int subGrid_Allbackcolor ;
      private int edtavWwp_sdtnotificationsdata__notificationid_Enabled ;
      private int edtavWwp_sdtnotificationsdata__notificationiconclass_Enabled ;
      private int edtavWwp_sdtnotificationsdata__notificationtitle_Enabled ;
      private int edtavWwp_sdtnotificationsdata__notificationdescription_Enabled ;
      private int edtavWwp_sdtnotificationsdata__notificationdatetime_Enabled ;
      private int edtavWwp_sdtnotificationsdata__notificationlink_Enabled ;
      private int subGrid_Selectedindex ;
      private int subGrid_Selectioncolor ;
      private int subGrid_Hoveringcolor ;
      private int AV41GXV1 ;
      private int divTablechart1_Height ;
      private int divTablechart4_Height ;
      private int divTablechart3_Height ;
      private int subGrid_Islastpage ;
      private int edtavNumbersecondaryvalue1_Enabled ;
      private int edtavNumbersecondaryvalue2_Enabled ;
      private int edtavNumbersecondaryvalue3_Enabled ;
      private int edtavNumbersecondaryvalue4_Enabled ;
      private int edtavNumbersecondaryvalue5_Enabled ;
      private int edtavValueprogressbar1_Enabled ;
      private int edtavTotalvalueprogressbar1_Enabled ;
      private int edtavValueprogressbar2_Enabled ;
      private int edtavTotalvalueprogressbar2_Enabled ;
      private int edtavValueprogressbar3_Enabled ;
      private int edtavTotalvalueprogressbar3_Enabled ;
      private int edtavValueprogressbar4_Enabled ;
      private int edtavTotalvalueprogressbar4_Enabled ;
      private int GRID_nGridOutOfScope ;
      private int nGXsfl_147_fel_idx=1 ;
      private int idxLst ;
      private int subGrid_Backcolor ;
      private long GRID_nFirstRecordOnPage ;
      private long GRID_nCurrentRecord ;
      private long GRID_nRecordCount ;
      private decimal AV38NumberSecondaryValue1 ;
      private decimal AV37NumberSecondaryValue2 ;
      private decimal AV36NumberSecondaryValue3 ;
      private decimal AV35NumberSecondaryValue4 ;
      private decimal AV34NumberSecondaryValue5 ;
      private string gxfirstwebparm ;
      private string gxfirstwebparm_bkp ;
      private string sGXsfl_147_idx="0001" ;
      private string sDynURL ;
      private string FormProcess ;
      private string bodyStyle ;
      private string GXKey ;
      private string Dvpanel_tablecards_Width ;
      private string Dvpanel_tablecards_Cls ;
      private string Dvpanel_tablecards_Title ;
      private string Dvpanel_tablecards_Iconposition ;
      private string Dvpanel_tablenotifications_Width ;
      private string Dvpanel_tablenotifications_Cls ;
      private string Dvpanel_tablenotifications_Title ;
      private string Dvpanel_tablenotifications_Iconposition ;
      private string Utchartsmootharea_Class ;
      private string Utchartsmootharea_Height ;
      private string Utchartsmootharea_Type ;
      private string Utchartsmootharea_Charttype ;
      private string Utchartsmootharea_Xaxistitle ;
      private string Progressbar1_Type ;
      private string Progressbar1_Cls ;
      private string Progressbar2_Type ;
      private string Progressbar2_Cls ;
      private string Progressbar3_Type ;
      private string Progressbar3_Cls ;
      private string Progressbar4_Type ;
      private string Progressbar4_Cls ;
      private string Dvpanel_tablechart1_Width ;
      private string Dvpanel_tablechart1_Cls ;
      private string Dvpanel_tablechart1_Title ;
      private string Dvpanel_tablechart1_Iconposition ;
      private string Utchartsmoothline_Height ;
      private string Utchartsmoothline_Type ;
      private string Utchartsmoothline_Charttype ;
      private string Utchartsmoothline_Xaxistitle ;
      private string Dvpanel_tablechart4_Width ;
      private string Dvpanel_tablechart4_Cls ;
      private string Dvpanel_tablechart4_Title ;
      private string Dvpanel_tablechart4_Iconposition ;
      private string Utchartdoughnut_Height ;
      private string Utchartdoughnut_Type ;
      private string Utchartdoughnut_Charttype ;
      private string Dvpanel_tablechart3_Width ;
      private string Dvpanel_tablechart3_Cls ;
      private string Dvpanel_tablechart3_Title ;
      private string Dvpanel_tablechart3_Iconposition ;
      private string Grid_empowerer_Gridinternalname ;
      private string GX_FocusControl ;
      private string sPrefix ;
      private string divLayoutmaintable_Internalname ;
      private string divTablemain_Internalname ;
      private string Dvpanel_tablecards_Internalname ;
      private string divTablecards_Internalname ;
      private string divCard1_Internalname ;
      private string edtavValuecard1_Internalname ;
      private string TempTags ;
      private string edtavValuecard1_Jsonclick ;
      private string divCard2_Internalname ;
      private string edtavValuecard2_Internalname ;
      private string edtavValuecard2_Jsonclick ;
      private string divCard3_Internalname ;
      private string edtavValuecard3_Internalname ;
      private string edtavValuecard3_Jsonclick ;
      private string divCard4_Internalname ;
      private string edtavValuecard4_Internalname ;
      private string edtavValuecard4_Jsonclick ;
      private string divCard5_Internalname ;
      private string edtavValuecard5_Internalname ;
      private string edtavValuecard5_Jsonclick ;
      private string Dvpanel_tablenotifications_Internalname ;
      private string divTablenotifications_Internalname ;
      private string lblNotificationssubtitle_Internalname ;
      private string lblNotificationssubtitle_Jsonclick ;
      private string sStyleString ;
      private string subGrid_Internalname ;
      private string subGrid_Class ;
      private string subGrid_Linesclass ;
      private string subGrid_Header ;
      private string Dvpanel_tablechart1_Internalname ;
      private string divTablechart1_Internalname ;
      private string divTablereport_Internalname ;
      private string lblCharttitle_Internalname ;
      private string lblCharttitle_Jsonclick ;
      private string Utchartsmootharea_Title ;
      private string Utchartsmootharea_Internalname ;
      private string divTablereportgoals_Internalname ;
      private string lblIndicatorstitle_Internalname ;
      private string lblIndicatorstitle_Jsonclick ;
      private string divTabletitle1_Internalname ;
      private string lblDescriptionprogressbar1_Internalname ;
      private string lblDescriptionprogressbar1_Jsonclick ;
      private string Progressbar1_Caption ;
      private string Progressbar1_Internalname ;
      private string divTabletitle2_Internalname ;
      private string lblDescriptionprogressbar2_Internalname ;
      private string lblDescriptionprogressbar2_Jsonclick ;
      private string Progressbar2_Caption ;
      private string Progressbar2_Internalname ;
      private string divTabletitle3_Internalname ;
      private string lblDescriptionprogressbar3_Internalname ;
      private string lblDescriptionprogressbar3_Jsonclick ;
      private string Progressbar3_Caption ;
      private string Progressbar3_Internalname ;
      private string divTabletitle4_Internalname ;
      private string lblDescriptionprogressbar4_Internalname ;
      private string lblDescriptionprogressbar4_Jsonclick ;
      private string Progressbar4_Caption ;
      private string Progressbar4_Internalname ;
      private string Dvpanel_tablechart4_Internalname ;
      private string divTablechart4_Internalname ;
      private string Utchartsmoothline_Title ;
      private string Utchartsmoothline_Internalname ;
      private string Dvpanel_tablechart3_Internalname ;
      private string divTablechart3_Internalname ;
      private string Utchartdoughnut_Title ;
      private string Utchartdoughnut_Internalname ;
      private string divHtml_bottomauxiliarcontrols_Internalname ;
      private string Grid_empowerer_Internalname ;
      private string sEvt ;
      private string EvtGridId ;
      private string EvtRowId ;
      private string sEvtType ;
      private string edtavNumbersecondaryvalue1_Internalname ;
      private string edtavNumbersecondaryvalue2_Internalname ;
      private string edtavNumbersecondaryvalue3_Internalname ;
      private string edtavNumbersecondaryvalue4_Internalname ;
      private string edtavNumbersecondaryvalue5_Internalname ;
      private string edtavWwp_sdtnotificationsdata__notificationid_Internalname ;
      private string edtavWwp_sdtnotificationsdata__notificationiconclass_Internalname ;
      private string edtavWwp_sdtnotificationsdata__notificationtitle_Internalname ;
      private string edtavWwp_sdtnotificationsdata__notificationdescription_Internalname ;
      private string edtavWwp_sdtnotificationsdata__notificationdatetime_Internalname ;
      private string edtavWwp_sdtnotificationsdata__notificationlink_Internalname ;
      private string edtavValueprogressbar1_Internalname ;
      private string edtavTotalvalueprogressbar1_Internalname ;
      private string edtavValueprogressbar2_Internalname ;
      private string edtavTotalvalueprogressbar2_Internalname ;
      private string edtavValueprogressbar3_Internalname ;
      private string edtavTotalvalueprogressbar3_Internalname ;
      private string edtavValueprogressbar4_Internalname ;
      private string edtavTotalvalueprogressbar4_Internalname ;
      private string sGXsfl_147_fel_idx="0001" ;
      private string tblTabletotal4_Internalname ;
      private string edtavValueprogressbar4_Jsonclick ;
      private string lblSeparatorprogressbar4_Internalname ;
      private string lblSeparatorprogressbar4_Jsonclick ;
      private string edtavTotalvalueprogressbar4_Jsonclick ;
      private string tblTabletotal3_Internalname ;
      private string edtavValueprogressbar3_Jsonclick ;
      private string lblSeparatorprogressbar3_Internalname ;
      private string lblSeparatorprogressbar3_Jsonclick ;
      private string edtavTotalvalueprogressbar3_Jsonclick ;
      private string tblTabletotal2_Internalname ;
      private string edtavValueprogressbar2_Jsonclick ;
      private string lblSeparatorprogressbar2_Internalname ;
      private string lblSeparatorprogressbar2_Jsonclick ;
      private string edtavTotalvalueprogressbar2_Jsonclick ;
      private string tblTabletotal1_Internalname ;
      private string edtavValueprogressbar1_Jsonclick ;
      private string lblSeparatorprogressbar1_Internalname ;
      private string lblSeparatorprogressbar1_Jsonclick ;
      private string edtavTotalvalueprogressbar1_Jsonclick ;
      private string tblTablemergedmoreinfoiconcard5_Internalname ;
      private string lblMoreinfoiconcard5_Internalname ;
      private string lblMoreinfoiconcard5_Jsonclick ;
      private string edtavNumbersecondaryvalue5_Jsonclick ;
      private string lblMoreinfocard5caption_Internalname ;
      private string lblMoreinfocard5caption_Jsonclick ;
      private string tblTablemergedicon5_Internalname ;
      private string lblIcon5_Internalname ;
      private string lblIcon5_Jsonclick ;
      private string lblDescriptioncard5_Internalname ;
      private string lblDescriptioncard5_Jsonclick ;
      private string tblTablemergedmoreinfoiconcard4_Internalname ;
      private string lblMoreinfoiconcard4_Internalname ;
      private string lblMoreinfoiconcard4_Jsonclick ;
      private string edtavNumbersecondaryvalue4_Jsonclick ;
      private string lblMoreinfocard4caption_Internalname ;
      private string lblMoreinfocard4caption_Jsonclick ;
      private string tblTablemergedicon4_Internalname ;
      private string lblIcon4_Internalname ;
      private string lblIcon4_Jsonclick ;
      private string lblDescriptioncard4_Internalname ;
      private string lblDescriptioncard4_Jsonclick ;
      private string tblTablemergedmoreinfoiconcard3_Internalname ;
      private string lblMoreinfoiconcard3_Internalname ;
      private string lblMoreinfoiconcard3_Jsonclick ;
      private string edtavNumbersecondaryvalue3_Jsonclick ;
      private string lblMoreinfocard3caption_Internalname ;
      private string lblMoreinfocard3caption_Jsonclick ;
      private string tblTablemergedicon3_Internalname ;
      private string lblIcon3_Internalname ;
      private string lblIcon3_Jsonclick ;
      private string lblDescriptioncard3_Internalname ;
      private string lblDescriptioncard3_Jsonclick ;
      private string tblTablemergedmoreinfoiconcard2_Internalname ;
      private string lblMoreinfoiconcard2_Internalname ;
      private string lblMoreinfoiconcard2_Jsonclick ;
      private string edtavNumbersecondaryvalue2_Jsonclick ;
      private string lblMoreinfocard2caption_Internalname ;
      private string lblMoreinfocard2caption_Jsonclick ;
      private string tblTablemergedicon2_Internalname ;
      private string lblIcon2_Internalname ;
      private string lblIcon2_Jsonclick ;
      private string lblDescriptioncard2_Internalname ;
      private string lblDescriptioncard2_Jsonclick ;
      private string tblTablemergedmoreinfoiconcard1_Internalname ;
      private string lblMoreinfoiconcard1_Internalname ;
      private string lblMoreinfoiconcard1_Jsonclick ;
      private string edtavNumbersecondaryvalue1_Jsonclick ;
      private string lblMoreinfocard1caption_Internalname ;
      private string lblMoreinfocard1caption_Jsonclick ;
      private string tblTablemergedicon1_Internalname ;
      private string lblIcon1_Internalname ;
      private string lblIcon1_Jsonclick ;
      private string lblDescriptioncard1_Internalname ;
      private string lblDescriptioncard1_Jsonclick ;
      private string ROClassString ;
      private string edtavWwp_sdtnotificationsdata__notificationid_Jsonclick ;
      private string edtavWwp_sdtnotificationsdata__notificationiconclass_Jsonclick ;
      private string edtavWwp_sdtnotificationsdata__notificationtitle_Jsonclick ;
      private string edtavWwp_sdtnotificationsdata__notificationdescription_Jsonclick ;
      private string edtavWwp_sdtnotificationsdata__notificationdatetime_Jsonclick ;
      private string edtavWwp_sdtnotificationsdata__notificationlink_Jsonclick ;
      private bool entryPointCalled ;
      private bool toggleJsOutput ;
      private bool Dvpanel_tablecards_Autowidth ;
      private bool Dvpanel_tablecards_Autoheight ;
      private bool Dvpanel_tablecards_Collapsible ;
      private bool Dvpanel_tablecards_Collapsed ;
      private bool Dvpanel_tablecards_Showcollapseicon ;
      private bool Dvpanel_tablecards_Autoscroll ;
      private bool Dvpanel_tablenotifications_Autowidth ;
      private bool Dvpanel_tablenotifications_Autoheight ;
      private bool Dvpanel_tablenotifications_Collapsible ;
      private bool Dvpanel_tablenotifications_Collapsed ;
      private bool Dvpanel_tablenotifications_Showcollapseicon ;
      private bool Dvpanel_tablenotifications_Autoscroll ;
      private bool Dvpanel_tablechart1_Autowidth ;
      private bool Dvpanel_tablechart1_Autoheight ;
      private bool Dvpanel_tablechart1_Collapsible ;
      private bool Dvpanel_tablechart1_Collapsed ;
      private bool Dvpanel_tablechart1_Showcollapseicon ;
      private bool Dvpanel_tablechart1_Autoscroll ;
      private bool Dvpanel_tablechart4_Autowidth ;
      private bool Dvpanel_tablechart4_Autoheight ;
      private bool Dvpanel_tablechart4_Collapsible ;
      private bool Dvpanel_tablechart4_Collapsed ;
      private bool Dvpanel_tablechart4_Showcollapseicon ;
      private bool Dvpanel_tablechart4_Autoscroll ;
      private bool Utchartdoughnut_Showvalues ;
      private bool Dvpanel_tablechart3_Autowidth ;
      private bool Dvpanel_tablechart3_Autoheight ;
      private bool Dvpanel_tablechart3_Collapsible ;
      private bool Dvpanel_tablechart3_Collapsed ;
      private bool Dvpanel_tablechart3_Showcollapseicon ;
      private bool Dvpanel_tablechart3_Autoscroll ;
      private bool wbLoad ;
      private bool Rfr0gs ;
      private bool wbErr ;
      private bool bGXsfl_147_Refreshing=false ;
      private bool gxdyncontrolsrefreshing ;
      private bool returnInSub ;
      private string AV10ValueCard3 ;
      private GXWebGrid GridContainer ;
      private GXWebRow GridRow ;
      private GXWebColumn GridColumn ;
      private GXUserControl ucDvpanel_tablecards ;
      private GXUserControl ucDvpanel_tablenotifications ;
      private GXUserControl ucDvpanel_tablechart1 ;
      private GXUserControl ucUtchartsmootharea ;
      private GXUserControl ucProgressbar1 ;
      private GXUserControl ucProgressbar2 ;
      private GXUserControl ucProgressbar3 ;
      private GXUserControl ucProgressbar4 ;
      private GXUserControl ucDvpanel_tablechart4 ;
      private GXUserControl ucUtchartsmoothline ;
      private GXUserControl ucDvpanel_tablechart3 ;
      private GXUserControl ucUtchartdoughnut ;
      private GXUserControl ucGrid_empowerer ;
      private IGxDataStore dsDataStore2 ;
      private IGxDataStore dsDefault ;
      private msglist BackMsgLst ;
      private msglist LclMsgLst ;
      private GXBaseCollection<SdtQueryViewerElements_Element> AV14Elements ;
      private GXBaseCollection<SdtQueryViewerElements_Element> AV12Axes ;
      private GXBaseCollection<GeneXus.Programs.wwpbaseobjects.SdtHomeSampleData_HomeSampleDataItem> AV5HomeSampleData ;
      private GXBaseCollection<GeneXus.Programs.wwpbaseobjects.SdtHomeSampleData_HomeSampleDataItem> GXt_objcol_SdtHomeSampleData_HomeSampleDataItem1 ;
      private GXBaseCollection<SdtQueryViewerParameters_Parameter> AV15Parameters ;
      private GXBaseCollection<GeneXus.Programs.wwpbaseobjects.SdtWWP_SDTNotificationsData_WWP_SDTNotificationsDataItem> AV24WWP_SDTNotificationsData ;
      private GXWebForm Form ;
      private SdtQueryViewerElements_Element AV13Axis ;
      private SdtQueryViewerDragAndDropData AV18DragAndDropData ;
      private SdtQueryViewerFilterChangedData AV19FilterChangedData ;
      private SdtQueryViewerItemClickData AV16ItemClickData ;
      private SdtQueryViewerItemCollapseData AV21ItemCollapseData ;
      private SdtQueryViewerItemDoubleClickData AV17ItemDoubleClickData ;
      private SdtQueryViewerItemExpandData AV20ItemExpandData ;
   }

}
