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
using GeneXus.Http.Server;
using System.Xml.Serialization;
using System.Runtime.Serialization;
namespace GeneXus.Programs.produccion {
   public class conceptosordenesproduccionww : GXDataArea
   {
      public conceptosordenesproduccionww( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDataStore2 = context.GetDataStore("DataStore2");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusTheme");
      }

      public conceptosordenesproduccionww( IGxContext context )
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
         cmbavDynamicfiltersselector1 = new GXCombobox();
         cmbavDynamicfiltersoperator1 = new GXCombobox();
         cmbavDynamicfiltersselector2 = new GXCombobox();
         cmbavDynamicfiltersoperator2 = new GXCombobox();
         cmbavDynamicfiltersselector3 = new GXCombobox();
         cmbavDynamicfiltersoperator3 = new GXCombobox();
         cmbavGridactions = new GXCombobox();
         cmbPoConcTip = new GXCombobox();
         cmbPoConcSts = new GXCombobox();
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
               nRC_GXsfl_101 = (int)(NumberUtil.Val( GetPar( "nRC_GXsfl_101"), "."));
               nGXsfl_101_idx = (int)(NumberUtil.Val( GetPar( "nGXsfl_101_idx"), "."));
               sGXsfl_101_idx = GetPar( "sGXsfl_101_idx");
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
               cmbavDynamicfiltersselector1.FromJSonString( GetNextPar( ));
               AV15DynamicFiltersSelector1 = GetPar( "DynamicFiltersSelector1");
               cmbavDynamicfiltersoperator1.FromJSonString( GetNextPar( ));
               AV16DynamicFiltersOperator1 = (short)(NumberUtil.Val( GetPar( "DynamicFiltersOperator1"), "."));
               AV17PoConcDsc1 = GetPar( "PoConcDsc1");
               cmbavDynamicfiltersselector2.FromJSonString( GetNextPar( ));
               AV19DynamicFiltersSelector2 = GetPar( "DynamicFiltersSelector2");
               cmbavDynamicfiltersoperator2.FromJSonString( GetNextPar( ));
               AV20DynamicFiltersOperator2 = (short)(NumberUtil.Val( GetPar( "DynamicFiltersOperator2"), "."));
               AV21PoConcDsc2 = GetPar( "PoConcDsc2");
               cmbavDynamicfiltersselector3.FromJSonString( GetNextPar( ));
               AV23DynamicFiltersSelector3 = GetPar( "DynamicFiltersSelector3");
               cmbavDynamicfiltersoperator3.FromJSonString( GetNextPar( ));
               AV24DynamicFiltersOperator3 = (short)(NumberUtil.Val( GetPar( "DynamicFiltersOperator3"), "."));
               AV25PoConcDsc3 = GetPar( "PoConcDsc3");
               AV51Pgmname = GetPar( "Pgmname");
               AV18DynamicFiltersEnabled2 = StringUtil.StrToBool( GetPar( "DynamicFiltersEnabled2"));
               AV22DynamicFiltersEnabled3 = StringUtil.StrToBool( GetPar( "DynamicFiltersEnabled3"));
               AV31TFPoConcCod = (int)(NumberUtil.Val( GetPar( "TFPoConcCod"), "."));
               AV32TFPoConcCod_To = (int)(NumberUtil.Val( GetPar( "TFPoConcCod_To"), "."));
               AV33TFPoConcDsc = GetPar( "TFPoConcDsc");
               AV34TFPoConcDsc_Sel = GetPar( "TFPoConcDsc_Sel");
               ajax_req_read_hidden_sdt(GetNextPar( ), AV48TFPoConcTip_Sels);
               ajax_req_read_hidden_sdt(GetNextPar( ), AV38TFPoConcSts_Sels);
               AV13OrderedBy = (short)(NumberUtil.Val( GetPar( "OrderedBy"), "."));
               AV14OrderedDsc = StringUtil.StrToBool( GetPar( "OrderedDsc"));
               ajax_req_read_hidden_sdt(GetNextPar( ), AV10GridState);
               AV27DynamicFiltersIgnoreFirst = StringUtil.StrToBool( GetPar( "DynamicFiltersIgnoreFirst"));
               AV26DynamicFiltersRemoving = StringUtil.StrToBool( GetPar( "DynamicFiltersRemoving"));
               setAjaxCallMode();
               if ( ! IsValidAjaxCall( true) )
               {
                  GxWebError = 1;
                  return  ;
               }
               gxgrGrid_refresh( subGrid_Rows, AV15DynamicFiltersSelector1, AV16DynamicFiltersOperator1, AV17PoConcDsc1, AV19DynamicFiltersSelector2, AV20DynamicFiltersOperator2, AV21PoConcDsc2, AV23DynamicFiltersSelector3, AV24DynamicFiltersOperator3, AV25PoConcDsc3, AV51Pgmname, AV18DynamicFiltersEnabled2, AV22DynamicFiltersEnabled3, AV31TFPoConcCod, AV32TFPoConcCod_To, AV33TFPoConcDsc, AV34TFPoConcDsc_Sel, AV48TFPoConcTip_Sels, AV38TFPoConcSts_Sels, AV13OrderedBy, AV14OrderedDsc, AV10GridState, AV27DynamicFiltersIgnoreFirst, AV26DynamicFiltersRemoving) ;
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
         PA272( ) ;
         gxajaxcallmode = (short)((isAjaxCallMode( ) ? 1 : 0));
         if ( ( gxajaxcallmode == 0 ) && ( GxWebError == 0 ) )
         {
            START272( ) ;
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
         context.AddJavascriptSource("gxcfg.js", "?202281810302037", false, true);
         if ( context.isSpaRequest( ) )
         {
            enableOutput();
         }
         context.AddJavascriptSource("DVelop/Bootstrap/Shared/DVelopBootstrap.js", "", false, true);
         context.AddJavascriptSource("DVelop/Shared/WorkWithPlusCommon.js", "", false, true);
         context.AddJavascriptSource("DVelop/Bootstrap/Panel/BootstrapPanelRender.js", "", false, true);
         context.AddJavascriptSource("DVelop/Bootstrap/Shared/DVelopBootstrap.js", "", false, true);
         context.AddJavascriptSource("DVelop/Shared/WorkWithPlusCommon.js", "", false, true);
         context.AddJavascriptSource("DVelop/DVPaginationBar/DVPaginationBarRender.js", "", false, true);
         context.AddJavascriptSource("DVelop/Bootstrap/Shared/DVelopBootstrap.js", "", false, true);
         context.AddJavascriptSource("DVelop/Shared/WorkWithPlusCommon.js", "", false, true);
         context.AddJavascriptSource("DVelop/Bootstrap/DropDownOptions/BootstrapDropDownOptionsRender.js", "", false, true);
         context.AddJavascriptSource("DVelop/Bootstrap/Shared/DVelopBootstrap.js", "", false, true);
         context.AddJavascriptSource("DVelop/Shared/WorkWithPlusCommon.js", "", false, true);
         context.AddJavascriptSource("DVelop/Bootstrap/DropDownOptions/BootstrapDropDownOptionsRender.js", "", false, true);
         context.AddJavascriptSource("Window/InNewWindowRender.js", "", false, true);
         context.AddJavascriptSource("DVelop/Shared/WorkWithPlusCommon.js", "", false, true);
         context.AddJavascriptSource("DVelop/GridEmpowerer/GridEmpowererRender.js", "", false, true);
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
         context.WriteHtmlTextNl( "<form id=\"MAINFORM\" autocomplete=\"off\" name=\"MAINFORM\" method=\"post\" tabindex=-1  class=\"form-horizontal Form\" data-gx-class=\"form-horizontal Form\" novalidate action=\""+formatLink("produccion.conceptosordenesproduccionww.aspx") +"\">") ;
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
         GxWebStd.gx_hidden_field( context, "gxhash_vPGMNAME", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( AV51Pgmname, "")), context));
         GXKey = Crypto.GetSiteKey( );
      }

      protected void SendCloseFormHiddens( )
      {
         /* Send hidden variables. */
         GxWebStd.gx_hidden_field( context, "GXH_vDYNAMICFILTERSSELECTOR1", AV15DynamicFiltersSelector1);
         GxWebStd.gx_hidden_field( context, "GXH_vDYNAMICFILTERSOPERATOR1", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV16DynamicFiltersOperator1), 4, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "GXH_vPOCONCDSC1", StringUtil.RTrim( AV17PoConcDsc1));
         GxWebStd.gx_hidden_field( context, "GXH_vDYNAMICFILTERSSELECTOR2", AV19DynamicFiltersSelector2);
         GxWebStd.gx_hidden_field( context, "GXH_vDYNAMICFILTERSOPERATOR2", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV20DynamicFiltersOperator2), 4, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "GXH_vPOCONCDSC2", StringUtil.RTrim( AV21PoConcDsc2));
         GxWebStd.gx_hidden_field( context, "GXH_vDYNAMICFILTERSSELECTOR3", AV23DynamicFiltersSelector3);
         GxWebStd.gx_hidden_field( context, "GXH_vDYNAMICFILTERSOPERATOR3", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV24DynamicFiltersOperator3), 4, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "GXH_vPOCONCDSC3", StringUtil.RTrim( AV25PoConcDsc3));
         /* Send saved values. */
         send_integrity_footer_hashes( ) ;
         GxWebStd.gx_hidden_field( context, "nRC_GXsfl_101", StringUtil.LTrim( StringUtil.NToC( (decimal)(nRC_GXsfl_101), 8, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "vGRIDCURRENTPAGE", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV41GridCurrentPage), 10, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "vGRIDPAGECOUNT", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV42GridPageCount), 10, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "vGRIDAPPLIEDFILTERS", AV43GridAppliedFilters);
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "vAGEXPORTDATA", AV45AGExportData);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt("vAGEXPORTDATA", AV45AGExportData);
         }
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "vDDO_TITLESETTINGSICONS", AV39DDO_TitleSettingsIcons);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt("vDDO_TITLESETTINGSICONS", AV39DDO_TitleSettingsIcons);
         }
         GxWebStd.gx_hidden_field( context, "vPGMNAME", StringUtil.RTrim( AV51Pgmname));
         GxWebStd.gx_hidden_field( context, "gxhash_vPGMNAME", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( AV51Pgmname, "")), context));
         GxWebStd.gx_boolean_hidden_field( context, "vDYNAMICFILTERSENABLED2", AV18DynamicFiltersEnabled2);
         GxWebStd.gx_boolean_hidden_field( context, "vDYNAMICFILTERSENABLED3", AV22DynamicFiltersEnabled3);
         GxWebStd.gx_hidden_field( context, "vTFPOCONCCOD", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV31TFPoConcCod), 6, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "vTFPOCONCCOD_TO", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV32TFPoConcCod_To), 6, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "vTFPOCONCDSC", StringUtil.RTrim( AV33TFPoConcDsc));
         GxWebStd.gx_hidden_field( context, "vTFPOCONCDSC_SEL", StringUtil.RTrim( AV34TFPoConcDsc_Sel));
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "vTFPOCONCTIP_SELS", AV48TFPoConcTip_Sels);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt("vTFPOCONCTIP_SELS", AV48TFPoConcTip_Sels);
         }
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "vTFPOCONCSTS_SELS", AV38TFPoConcSts_Sels);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt("vTFPOCONCSTS_SELS", AV38TFPoConcSts_Sels);
         }
         GxWebStd.gx_hidden_field( context, "vORDEREDBY", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV13OrderedBy), 4, 0, ".", "")));
         GxWebStd.gx_boolean_hidden_field( context, "vORDEREDDSC", AV14OrderedDsc);
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "vGRIDSTATE", AV10GridState);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt("vGRIDSTATE", AV10GridState);
         }
         GxWebStd.gx_boolean_hidden_field( context, "vDYNAMICFILTERSIGNOREFIRST", AV27DynamicFiltersIgnoreFirst);
         GxWebStd.gx_boolean_hidden_field( context, "vDYNAMICFILTERSREMOVING", AV26DynamicFiltersRemoving);
         GxWebStd.gx_hidden_field( context, "vTFPOCONCTIP_SELSJSON", AV47TFPoConcTip_SelsJson);
         GxWebStd.gx_hidden_field( context, "vTFPOCONCSTS_SELSJSON", AV37TFPoConcSts_SelsJson);
         GxWebStd.gx_hidden_field( context, "GRID_nFirstRecordOnPage", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRID_nFirstRecordOnPage), 15, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "GRID_nEOF", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRID_nEOF), 1, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "GRID_Rows", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid_Rows), 6, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "DVPANEL_TABLEHEADER_Width", StringUtil.RTrim( Dvpanel_tableheader_Width));
         GxWebStd.gx_hidden_field( context, "DVPANEL_TABLEHEADER_Autowidth", StringUtil.BoolToStr( Dvpanel_tableheader_Autowidth));
         GxWebStd.gx_hidden_field( context, "DVPANEL_TABLEHEADER_Autoheight", StringUtil.BoolToStr( Dvpanel_tableheader_Autoheight));
         GxWebStd.gx_hidden_field( context, "DVPANEL_TABLEHEADER_Cls", StringUtil.RTrim( Dvpanel_tableheader_Cls));
         GxWebStd.gx_hidden_field( context, "DVPANEL_TABLEHEADER_Title", StringUtil.RTrim( Dvpanel_tableheader_Title));
         GxWebStd.gx_hidden_field( context, "DVPANEL_TABLEHEADER_Collapsible", StringUtil.BoolToStr( Dvpanel_tableheader_Collapsible));
         GxWebStd.gx_hidden_field( context, "DVPANEL_TABLEHEADER_Collapsed", StringUtil.BoolToStr( Dvpanel_tableheader_Collapsed));
         GxWebStd.gx_hidden_field( context, "DVPANEL_TABLEHEADER_Showcollapseicon", StringUtil.BoolToStr( Dvpanel_tableheader_Showcollapseicon));
         GxWebStd.gx_hidden_field( context, "DVPANEL_TABLEHEADER_Iconposition", StringUtil.RTrim( Dvpanel_tableheader_Iconposition));
         GxWebStd.gx_hidden_field( context, "DVPANEL_TABLEHEADER_Autoscroll", StringUtil.BoolToStr( Dvpanel_tableheader_Autoscroll));
         GxWebStd.gx_hidden_field( context, "GRIDPAGINATIONBAR_Class", StringUtil.RTrim( Gridpaginationbar_Class));
         GxWebStd.gx_hidden_field( context, "GRIDPAGINATIONBAR_Showfirst", StringUtil.BoolToStr( Gridpaginationbar_Showfirst));
         GxWebStd.gx_hidden_field( context, "GRIDPAGINATIONBAR_Showprevious", StringUtil.BoolToStr( Gridpaginationbar_Showprevious));
         GxWebStd.gx_hidden_field( context, "GRIDPAGINATIONBAR_Shownext", StringUtil.BoolToStr( Gridpaginationbar_Shownext));
         GxWebStd.gx_hidden_field( context, "GRIDPAGINATIONBAR_Showlast", StringUtil.BoolToStr( Gridpaginationbar_Showlast));
         GxWebStd.gx_hidden_field( context, "GRIDPAGINATIONBAR_Pagestoshow", StringUtil.LTrim( StringUtil.NToC( (decimal)(Gridpaginationbar_Pagestoshow), 9, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "GRIDPAGINATIONBAR_Pagingbuttonsposition", StringUtil.RTrim( Gridpaginationbar_Pagingbuttonsposition));
         GxWebStd.gx_hidden_field( context, "GRIDPAGINATIONBAR_Pagingcaptionposition", StringUtil.RTrim( Gridpaginationbar_Pagingcaptionposition));
         GxWebStd.gx_hidden_field( context, "GRIDPAGINATIONBAR_Emptygridclass", StringUtil.RTrim( Gridpaginationbar_Emptygridclass));
         GxWebStd.gx_hidden_field( context, "GRIDPAGINATIONBAR_Rowsperpageselector", StringUtil.BoolToStr( Gridpaginationbar_Rowsperpageselector));
         GxWebStd.gx_hidden_field( context, "GRIDPAGINATIONBAR_Rowsperpageselectedvalue", StringUtil.LTrim( StringUtil.NToC( (decimal)(Gridpaginationbar_Rowsperpageselectedvalue), 9, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "GRIDPAGINATIONBAR_Rowsperpageoptions", StringUtil.RTrim( Gridpaginationbar_Rowsperpageoptions));
         GxWebStd.gx_hidden_field( context, "GRIDPAGINATIONBAR_Previous", StringUtil.RTrim( Gridpaginationbar_Previous));
         GxWebStd.gx_hidden_field( context, "GRIDPAGINATIONBAR_Next", StringUtil.RTrim( Gridpaginationbar_Next));
         GxWebStd.gx_hidden_field( context, "GRIDPAGINATIONBAR_Caption", StringUtil.RTrim( Gridpaginationbar_Caption));
         GxWebStd.gx_hidden_field( context, "GRIDPAGINATIONBAR_Emptygridcaption", StringUtil.RTrim( Gridpaginationbar_Emptygridcaption));
         GxWebStd.gx_hidden_field( context, "GRIDPAGINATIONBAR_Rowsperpagecaption", StringUtil.RTrim( Gridpaginationbar_Rowsperpagecaption));
         GxWebStd.gx_hidden_field( context, "DDO_AGEXPORT_Icontype", StringUtil.RTrim( Ddo_agexport_Icontype));
         GxWebStd.gx_hidden_field( context, "DDO_AGEXPORT_Icon", StringUtil.RTrim( Ddo_agexport_Icon));
         GxWebStd.gx_hidden_field( context, "DDO_AGEXPORT_Caption", StringUtil.RTrim( Ddo_agexport_Caption));
         GxWebStd.gx_hidden_field( context, "DDO_AGEXPORT_Cls", StringUtil.RTrim( Ddo_agexport_Cls));
         GxWebStd.gx_hidden_field( context, "DDO_AGEXPORT_Titlecontrolidtoreplace", StringUtil.RTrim( Ddo_agexport_Titlecontrolidtoreplace));
         GxWebStd.gx_hidden_field( context, "DDO_GRID_Caption", StringUtil.RTrim( Ddo_grid_Caption));
         GxWebStd.gx_hidden_field( context, "DDO_GRID_Filteredtext_set", StringUtil.RTrim( Ddo_grid_Filteredtext_set));
         GxWebStd.gx_hidden_field( context, "DDO_GRID_Filteredtextto_set", StringUtil.RTrim( Ddo_grid_Filteredtextto_set));
         GxWebStd.gx_hidden_field( context, "DDO_GRID_Selectedvalue_set", StringUtil.RTrim( Ddo_grid_Selectedvalue_set));
         GxWebStd.gx_hidden_field( context, "DDO_GRID_Gridinternalname", StringUtil.RTrim( Ddo_grid_Gridinternalname));
         GxWebStd.gx_hidden_field( context, "DDO_GRID_Columnids", StringUtil.RTrim( Ddo_grid_Columnids));
         GxWebStd.gx_hidden_field( context, "DDO_GRID_Columnssortvalues", StringUtil.RTrim( Ddo_grid_Columnssortvalues));
         GxWebStd.gx_hidden_field( context, "DDO_GRID_Includesortasc", StringUtil.RTrim( Ddo_grid_Includesortasc));
         GxWebStd.gx_hidden_field( context, "DDO_GRID_Sortedstatus", StringUtil.RTrim( Ddo_grid_Sortedstatus));
         GxWebStd.gx_hidden_field( context, "DDO_GRID_Includefilter", StringUtil.RTrim( Ddo_grid_Includefilter));
         GxWebStd.gx_hidden_field( context, "DDO_GRID_Filtertype", StringUtil.RTrim( Ddo_grid_Filtertype));
         GxWebStd.gx_hidden_field( context, "DDO_GRID_Filterisrange", StringUtil.RTrim( Ddo_grid_Filterisrange));
         GxWebStd.gx_hidden_field( context, "DDO_GRID_Includedatalist", StringUtil.RTrim( Ddo_grid_Includedatalist));
         GxWebStd.gx_hidden_field( context, "DDO_GRID_Datalisttype", StringUtil.RTrim( Ddo_grid_Datalisttype));
         GxWebStd.gx_hidden_field( context, "DDO_GRID_Allowmultipleselection", StringUtil.RTrim( Ddo_grid_Allowmultipleselection));
         GxWebStd.gx_hidden_field( context, "DDO_GRID_Datalistfixedvalues", StringUtil.RTrim( Ddo_grid_Datalistfixedvalues));
         GxWebStd.gx_hidden_field( context, "DDO_GRID_Datalistproc", StringUtil.RTrim( Ddo_grid_Datalistproc));
         GxWebStd.gx_hidden_field( context, "INNEWWINDOW1_Width", StringUtil.RTrim( Innewwindow1_Width));
         GxWebStd.gx_hidden_field( context, "INNEWWINDOW1_Height", StringUtil.RTrim( Innewwindow1_Height));
         GxWebStd.gx_hidden_field( context, "INNEWWINDOW1_Target", StringUtil.RTrim( Innewwindow1_Target));
         GxWebStd.gx_hidden_field( context, "GRID_EMPOWERER_Gridinternalname", StringUtil.RTrim( Grid_empowerer_Gridinternalname));
         GxWebStd.gx_hidden_field( context, "GRID_EMPOWERER_Hastitlesettings", StringUtil.BoolToStr( Grid_empowerer_Hastitlesettings));
         GxWebStd.gx_hidden_field( context, "GRID_Rows", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid_Rows), 6, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "GRIDPAGINATIONBAR_Selectedpage", StringUtil.RTrim( Gridpaginationbar_Selectedpage));
         GxWebStd.gx_hidden_field( context, "GRIDPAGINATIONBAR_Rowsperpageselectedvalue", StringUtil.LTrim( StringUtil.NToC( (decimal)(Gridpaginationbar_Rowsperpageselectedvalue), 9, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "DDO_GRID_Activeeventkey", StringUtil.RTrim( Ddo_grid_Activeeventkey));
         GxWebStd.gx_hidden_field( context, "DDO_GRID_Selectedvalue_get", StringUtil.RTrim( Ddo_grid_Selectedvalue_get));
         GxWebStd.gx_hidden_field( context, "DDO_GRID_Selectedcolumn", StringUtil.RTrim( Ddo_grid_Selectedcolumn));
         GxWebStd.gx_hidden_field( context, "DDO_GRID_Filteredtext_get", StringUtil.RTrim( Ddo_grid_Filteredtext_get));
         GxWebStd.gx_hidden_field( context, "DDO_GRID_Filteredtextto_get", StringUtil.RTrim( Ddo_grid_Filteredtextto_get));
         GxWebStd.gx_hidden_field( context, "DDO_AGEXPORT_Activeeventkey", StringUtil.RTrim( Ddo_agexport_Activeeventkey));
         GxWebStd.gx_hidden_field( context, "GRID_Rows", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid_Rows), 6, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "GRIDPAGINATIONBAR_Selectedpage", StringUtil.RTrim( Gridpaginationbar_Selectedpage));
         GxWebStd.gx_hidden_field( context, "GRIDPAGINATIONBAR_Rowsperpageselectedvalue", StringUtil.LTrim( StringUtil.NToC( (decimal)(Gridpaginationbar_Rowsperpageselectedvalue), 9, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "DDO_GRID_Activeeventkey", StringUtil.RTrim( Ddo_grid_Activeeventkey));
         GxWebStd.gx_hidden_field( context, "DDO_GRID_Selectedvalue_get", StringUtil.RTrim( Ddo_grid_Selectedvalue_get));
         GxWebStd.gx_hidden_field( context, "DDO_GRID_Selectedcolumn", StringUtil.RTrim( Ddo_grid_Selectedcolumn));
         GxWebStd.gx_hidden_field( context, "DDO_GRID_Filteredtext_get", StringUtil.RTrim( Ddo_grid_Filteredtext_get));
         GxWebStd.gx_hidden_field( context, "DDO_GRID_Filteredtextto_get", StringUtil.RTrim( Ddo_grid_Filteredtextto_get));
         GxWebStd.gx_hidden_field( context, "DDO_AGEXPORT_Activeeventkey", StringUtil.RTrim( Ddo_agexport_Activeeventkey));
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
            WE272( ) ;
            context.WriteHtmlText( "</div>") ;
         }
      }

      public override void DispatchEvents( )
      {
         EVT272( ) ;
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
         return formatLink("produccion.conceptosordenesproduccionww.aspx")  ;
      }

      public override string GetPgmname( )
      {
         return "Produccion.ConceptosOrdenesProduccionWW" ;
      }

      public override string GetPgmdesc( )
      {
         return " Conceptos de Ordenes de Produccion" ;
      }

      protected void WB270( )
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
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 WWFiltersCell", "left", "top", "", "", "div");
            /* User Defined Control */
            ucDvpanel_tableheader.SetProperty("Width", Dvpanel_tableheader_Width);
            ucDvpanel_tableheader.SetProperty("AutoWidth", Dvpanel_tableheader_Autowidth);
            ucDvpanel_tableheader.SetProperty("AutoHeight", Dvpanel_tableheader_Autoheight);
            ucDvpanel_tableheader.SetProperty("Cls", Dvpanel_tableheader_Cls);
            ucDvpanel_tableheader.SetProperty("Title", Dvpanel_tableheader_Title);
            ucDvpanel_tableheader.SetProperty("Collapsible", Dvpanel_tableheader_Collapsible);
            ucDvpanel_tableheader.SetProperty("Collapsed", Dvpanel_tableheader_Collapsed);
            ucDvpanel_tableheader.SetProperty("ShowCollapseIcon", Dvpanel_tableheader_Showcollapseicon);
            ucDvpanel_tableheader.SetProperty("IconPosition", Dvpanel_tableheader_Iconposition);
            ucDvpanel_tableheader.SetProperty("AutoScroll", Dvpanel_tableheader_Autoscroll);
            ucDvpanel_tableheader.Render(context, "dvelop.gxbootstrap.panel_al", Dvpanel_tableheader_Internalname, "DVPANEL_TABLEHEADERContainer");
            context.WriteHtmlText( "<div class=\"gx_usercontrol_child\" id=\""+"DVPANEL_TABLEHEADERContainer"+"TableHeader"+"\" style=\"display:none;\">") ;
            /* Div Control */
            GxWebStd.gx_div_start( context, divTableheader_Internalname, 1, 0, "px", 0, "px", "Flex", "left", "top", " "+"data-gx-flex"+" ", "flex-direction:column;", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "", "left", "top", "", "flex-grow:1;", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divTableheadercontent_Internalname, 1, 0, "px", 0, "px", "Flex", "left", "top", " "+"data-gx-flex"+" ", "flex-wrap:wrap;", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "", "left", "top", "", "flex-grow:1;", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divTableactions_Internalname, 1, 0, "px", 0, "px", "Flex", "left", "top", " "+"data-gx-flex"+" ", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-action-group ActionGroupColoredActions", "left", "top", " "+"data-gx-actiongroup-type=\"toolbar\""+" ", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "left", "top", "", "", "div");
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 19,'',false,'',0)\"";
            ClassString = "Button ButtonColor";
            StyleString = "";
            GxWebStd.gx_button_ctrl( context, bttBtninsert_Internalname, "gx.evt.setGridEvt("+StringUtil.Str( (decimal)(101), 3, 0)+","+"null"+");", "Agregar", bttBtninsert_Jsonclick, 5, "Agregar", "", StyleString, ClassString, 1, 1, "standard", "'"+""+"'"+",false,"+"'"+"E\\'DOINSERT\\'."+"'", TempTags, "", context.GetButtonType( ), "HLP_Produccion\\ConceptosOrdenesProduccionWW.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "left", "top", "", "", "div");
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 21,'',false,'',0)\"";
            ClassString = "ColumnsSelector";
            StyleString = "";
            GxWebStd.gx_button_ctrl( context, bttBtnagexport_Internalname, "gx.evt.setGridEvt("+StringUtil.Str( (decimal)(101), 3, 0)+","+"null"+");", "Reportes", bttBtnagexport_Jsonclick, 0, "Reportes", "", StyleString, ClassString, 1, 0, "standard", "'"+""+"'"+",false,"+"'"+""+"'", TempTags, "", context.GetButtonType( ), "HLP_Produccion\\ConceptosOrdenesProduccionWW.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divTablerightheader_Internalname, 1, 0, "px", 0, "px", "Flex", "left", "top", " "+"data-gx-flex"+" ", "flex-wrap:wrap;", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "", "left", "top", "", "flex-grow:1;", "div");
            wb_table1_25_272( true) ;
         }
         else
         {
            wb_table1_25_272( false) ;
         }
         return  ;
      }

      protected void wb_table1_25_272e( bool wbgen )
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
            ClassString = "ErrorViewer";
            StyleString = "";
            GxWebStd.gx_msg_list( context, "", context.GX_msglist.DisplayMode, StyleString, ClassString, "", "false");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 SectionGrid GridNoBorderCell HasGridEmpowerer", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divGridtablewithpaginationbar_Internalname, 1, 0, "px", 0, "px", "Table", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
            /*  Grid Control  */
            GridContainer.SetWrapped(nGXWrapped);
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<div id=\""+"GridContainer"+"DivS\" data-gxgridid=\"101\">") ;
               sStyleString = "";
               GxWebStd.gx_table_start( context, subGrid_Internalname, subGrid_Internalname, "", "GridWithPaginationBar WorkWith", 0, "", "", 1, 2, sStyleString, "", "", 0);
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
               context.WriteHtmlText( "<th align=\""+"right"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"ConvertToDDO"+"\" "+" style=\""+""+""+"\" "+">") ;
               context.SendWebValue( "") ;
               context.WriteHtmlTextNl( "</th>") ;
               context.WriteHtmlText( "<th align=\""+"right"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+""+""+"\" "+">") ;
               context.SendWebValue( "Codigo Concepto") ;
               context.WriteHtmlTextNl( "</th>") ;
               context.WriteHtmlText( "<th align=\""+"left"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+""+""+"\" "+">") ;
               context.SendWebValue( "Concepto") ;
               context.WriteHtmlTextNl( "</th>") ;
               context.WriteHtmlText( "<th align=\""+"left"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+""+""+"\" "+">") ;
               context.SendWebValue( "Tipo de Distribuci?n") ;
               context.WriteHtmlTextNl( "</th>") ;
               context.WriteHtmlText( "<th align=\""+"right"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+""+""+"\" "+">") ;
               context.SendWebValue( "Estado") ;
               context.WriteHtmlTextNl( "</th>") ;
               context.WriteHtmlTextNl( "</tr>") ;
               GridContainer.AddObjectProperty("GridName", "Grid");
            }
            else
            {
               if ( isAjaxCallMode( ) )
               {
                  GridContainer = new GXWebGrid( context);
               }
               else
               {
                  GridContainer.Clear();
               }
               GridContainer.SetWrapped(nGXWrapped);
               GridContainer.AddObjectProperty("GridName", "Grid");
               GridContainer.AddObjectProperty("Header", subGrid_Header);
               GridContainer.AddObjectProperty("Class", "GridWithPaginationBar WorkWith");
               GridContainer.AddObjectProperty("Cellpadding", StringUtil.LTrim( StringUtil.NToC( (decimal)(1), 4, 0, ".", "")));
               GridContainer.AddObjectProperty("Cellspacing", StringUtil.LTrim( StringUtil.NToC( (decimal)(2), 4, 0, ".", "")));
               GridContainer.AddObjectProperty("Backcolorstyle", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid_Backcolorstyle), 1, 0, ".", "")));
               GridContainer.AddObjectProperty("Sortable", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid_Sortable), 1, 0, ".", "")));
               GridContainer.AddObjectProperty("CmpContext", "");
               GridContainer.AddObjectProperty("InMasterPage", "false");
               GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
               GridColumn.AddObjectProperty("Value", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV44GridActions), 4, 0, ".", "")));
               GridContainer.AddColumnProperties(GridColumn);
               GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
               GridColumn.AddObjectProperty("Value", StringUtil.LTrim( StringUtil.NToC( (decimal)(A313PoConcCod), 6, 0, ".", "")));
               GridContainer.AddColumnProperties(GridColumn);
               GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
               GridColumn.AddObjectProperty("Value", StringUtil.RTrim( A1648PoConcDsc));
               GridColumn.AddObjectProperty("Link", StringUtil.RTrim( edtPoConcDsc_Link));
               GridContainer.AddColumnProperties(GridColumn);
               GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
               GridColumn.AddObjectProperty("Value", StringUtil.RTrim( A1650PoConcTip));
               GridContainer.AddColumnProperties(GridColumn);
               GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
               GridColumn.AddObjectProperty("Value", StringUtil.LTrim( StringUtil.NToC( (decimal)(A1649PoConcSts), 1, 0, ".", "")));
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
         if ( wbEnd == 101 )
         {
            wbEnd = 0;
            nRC_GXsfl_101 = (int)(nGXsfl_101_idx-1);
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "</table>") ;
               context.WriteHtmlText( "</div>") ;
            }
            else
            {
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
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
            /* User Defined Control */
            ucGridpaginationbar.SetProperty("Class", Gridpaginationbar_Class);
            ucGridpaginationbar.SetProperty("ShowFirst", Gridpaginationbar_Showfirst);
            ucGridpaginationbar.SetProperty("ShowPrevious", Gridpaginationbar_Showprevious);
            ucGridpaginationbar.SetProperty("ShowNext", Gridpaginationbar_Shownext);
            ucGridpaginationbar.SetProperty("ShowLast", Gridpaginationbar_Showlast);
            ucGridpaginationbar.SetProperty("PagesToShow", Gridpaginationbar_Pagestoshow);
            ucGridpaginationbar.SetProperty("PagingButtonsPosition", Gridpaginationbar_Pagingbuttonsposition);
            ucGridpaginationbar.SetProperty("PagingCaptionPosition", Gridpaginationbar_Pagingcaptionposition);
            ucGridpaginationbar.SetProperty("EmptyGridClass", Gridpaginationbar_Emptygridclass);
            ucGridpaginationbar.SetProperty("RowsPerPageSelector", Gridpaginationbar_Rowsperpageselector);
            ucGridpaginationbar.SetProperty("RowsPerPageOptions", Gridpaginationbar_Rowsperpageoptions);
            ucGridpaginationbar.SetProperty("Previous", Gridpaginationbar_Previous);
            ucGridpaginationbar.SetProperty("Next", Gridpaginationbar_Next);
            ucGridpaginationbar.SetProperty("Caption", Gridpaginationbar_Caption);
            ucGridpaginationbar.SetProperty("EmptyGridCaption", Gridpaginationbar_Emptygridcaption);
            ucGridpaginationbar.SetProperty("RowsPerPageCaption", Gridpaginationbar_Rowsperpagecaption);
            ucGridpaginationbar.SetProperty("CurrentPage", AV41GridCurrentPage);
            ucGridpaginationbar.SetProperty("PageCount", AV42GridPageCount);
            ucGridpaginationbar.SetProperty("AppliedFilters", AV43GridAppliedFilters);
            ucGridpaginationbar.Render(context, "dvelop.dvpaginationbar", Gridpaginationbar_Internalname, "GRIDPAGINATIONBARContainer");
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
            /* User Defined Control */
            ucDdo_agexport.SetProperty("IconType", Ddo_agexport_Icontype);
            ucDdo_agexport.SetProperty("Icon", Ddo_agexport_Icon);
            ucDdo_agexport.SetProperty("Caption", Ddo_agexport_Caption);
            ucDdo_agexport.SetProperty("Cls", Ddo_agexport_Cls);
            ucDdo_agexport.SetProperty("DropDownOptionsData", AV45AGExportData);
            ucDdo_agexport.Render(context, "dvelop.gxbootstrap.ddoregular", Ddo_agexport_Internalname, "DDO_AGEXPORTContainer");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblJsdynamicfilters_Internalname, lblJsdynamicfilters_Caption, "", "", lblJsdynamicfilters_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "", 0, "", 1, 1, 0, 1, "HLP_Produccion\\ConceptosOrdenesProduccionWW.htm");
            /* User Defined Control */
            ucDdo_grid.SetProperty("Caption", Ddo_grid_Caption);
            ucDdo_grid.SetProperty("ColumnIds", Ddo_grid_Columnids);
            ucDdo_grid.SetProperty("ColumnsSortValues", Ddo_grid_Columnssortvalues);
            ucDdo_grid.SetProperty("IncludeSortASC", Ddo_grid_Includesortasc);
            ucDdo_grid.SetProperty("IncludeFilter", Ddo_grid_Includefilter);
            ucDdo_grid.SetProperty("FilterType", Ddo_grid_Filtertype);
            ucDdo_grid.SetProperty("FilterIsRange", Ddo_grid_Filterisrange);
            ucDdo_grid.SetProperty("IncludeDataList", Ddo_grid_Includedatalist);
            ucDdo_grid.SetProperty("DataListType", Ddo_grid_Datalisttype);
            ucDdo_grid.SetProperty("AllowMultipleSelection", Ddo_grid_Allowmultipleselection);
            ucDdo_grid.SetProperty("DataListFixedValues", Ddo_grid_Datalistfixedvalues);
            ucDdo_grid.SetProperty("DataListProc", Ddo_grid_Datalistproc);
            ucDdo_grid.SetProperty("DropDownOptionsTitleSettingsIcons", AV39DDO_TitleSettingsIcons);
            ucDdo_grid.Render(context, "dvelop.gxbootstrap.ddogridtitlesettingsm", Ddo_grid_Internalname, "DDO_GRIDContainer");
            /* User Defined Control */
            ucInnewwindow1.Render(context, "innewwindow", Innewwindow1_Internalname, "INNEWWINDOW1Container");
            /* User Defined Control */
            ucGrid_empowerer.SetProperty("HasTitleSettings", Grid_empowerer_Hastitlesettings);
            ucGrid_empowerer.Render(context, "wwp.gridempowerer", Grid_empowerer_Internalname, "GRID_EMPOWERERContainer");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
         }
         if ( wbEnd == 101 )
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

      protected void START272( )
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
            Form.Meta.addItem("description", " Conceptos de Ordenes de Produccion", 0) ;
         }
         context.wjLoc = "";
         context.nUserReturn = 0;
         context.wbHandled = 0;
         if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
         {
         }
         wbErr = false;
         STRUP270( ) ;
      }

      protected void WS272( )
      {
         START272( ) ;
         EVT272( ) ;
      }

      protected void EVT272( )
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
                           else if ( StringUtil.StrCmp(sEvt, "GRIDPAGINATIONBAR.CHANGEPAGE") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              E11272 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "GRIDPAGINATIONBAR.CHANGEROWSPERPAGE") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              E12272 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "DDO_AGEXPORT.ONOPTIONCLICKED") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              E13272 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "DDO_GRID.ONOPTIONCLICKED") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              E14272 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "'REMOVEDYNAMICFILTERS1'") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              /* Execute user event: 'RemoveDynamicFilters1' */
                              E15272 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "'REMOVEDYNAMICFILTERS2'") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              /* Execute user event: 'RemoveDynamicFilters2' */
                              E16272 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "'REMOVEDYNAMICFILTERS3'") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              /* Execute user event: 'RemoveDynamicFilters3' */
                              E17272 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "'DOINSERT'") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              /* Execute user event: 'DoInsert' */
                              E18272 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "'ADDDYNAMICFILTERS1'") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              /* Execute user event: 'AddDynamicFilters1' */
                              E19272 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "VDYNAMICFILTERSSELECTOR1.CLICK") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              E20272 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "'ADDDYNAMICFILTERS2'") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              /* Execute user event: 'AddDynamicFilters2' */
                              E21272 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "VDYNAMICFILTERSSELECTOR2.CLICK") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              E22272 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "VDYNAMICFILTERSSELECTOR3.CLICK") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              E23272 ();
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
                           sEvtType = StringUtil.Right( sEvt, 4);
                           sEvt = StringUtil.Left( sEvt, (short)(StringUtil.Len( sEvt)-4));
                           if ( ( StringUtil.StrCmp(StringUtil.Left( sEvt, 5), "START") == 0 ) || ( StringUtil.StrCmp(StringUtil.Left( sEvt, 7), "REFRESH") == 0 ) || ( StringUtil.StrCmp(StringUtil.Left( sEvt, 9), "GRID.LOAD") == 0 ) || ( StringUtil.StrCmp(StringUtil.Left( sEvt, 18), "VGRIDACTIONS.CLICK") == 0 ) || ( StringUtil.StrCmp(StringUtil.Left( sEvt, 5), "ENTER") == 0 ) || ( StringUtil.StrCmp(StringUtil.Left( sEvt, 6), "CANCEL") == 0 ) || ( StringUtil.StrCmp(StringUtil.Left( sEvt, 18), "VGRIDACTIONS.CLICK") == 0 ) )
                           {
                              nGXsfl_101_idx = (int)(NumberUtil.Val( sEvtType, "."));
                              sGXsfl_101_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_101_idx), 4, 0), 4, "0");
                              SubsflControlProps_1012( ) ;
                              cmbavGridactions.Name = cmbavGridactions_Internalname;
                              cmbavGridactions.CurrentValue = cgiGet( cmbavGridactions_Internalname);
                              AV44GridActions = (short)(NumberUtil.Val( cgiGet( cmbavGridactions_Internalname), "."));
                              AssignAttri("", false, cmbavGridactions_Internalname, StringUtil.LTrimStr( (decimal)(AV44GridActions), 4, 0));
                              A313PoConcCod = (int)(context.localUtil.CToN( cgiGet( edtPoConcCod_Internalname), ".", ","));
                              A1648PoConcDsc = cgiGet( edtPoConcDsc_Internalname);
                              cmbPoConcTip.Name = cmbPoConcTip_Internalname;
                              cmbPoConcTip.CurrentValue = cgiGet( cmbPoConcTip_Internalname);
                              A1650PoConcTip = cgiGet( cmbPoConcTip_Internalname);
                              cmbPoConcSts.Name = cmbPoConcSts_Internalname;
                              cmbPoConcSts.CurrentValue = cgiGet( cmbPoConcSts_Internalname);
                              A1649PoConcSts = (short)(NumberUtil.Val( cgiGet( cmbPoConcSts_Internalname), "."));
                              sEvtType = StringUtil.Right( sEvt, 1);
                              if ( StringUtil.StrCmp(sEvtType, ".") == 0 )
                              {
                                 sEvt = StringUtil.Left( sEvt, (short)(StringUtil.Len( sEvt)-1));
                                 if ( StringUtil.StrCmp(sEvt, "START") == 0 )
                                 {
                                    context.wbHandled = 1;
                                    dynload_actions( ) ;
                                    /* Execute user event: Start */
                                    E24272 ();
                                 }
                                 else if ( StringUtil.StrCmp(sEvt, "REFRESH") == 0 )
                                 {
                                    context.wbHandled = 1;
                                    dynload_actions( ) ;
                                    /* Execute user event: Refresh */
                                    E25272 ();
                                 }
                                 else if ( StringUtil.StrCmp(sEvt, "GRID.LOAD") == 0 )
                                 {
                                    context.wbHandled = 1;
                                    dynload_actions( ) ;
                                    E26272 ();
                                 }
                                 else if ( StringUtil.StrCmp(sEvt, "VGRIDACTIONS.CLICK") == 0 )
                                 {
                                    context.wbHandled = 1;
                                    dynload_actions( ) ;
                                    E27272 ();
                                 }
                                 else if ( StringUtil.StrCmp(sEvt, "ENTER") == 0 )
                                 {
                                    context.wbHandled = 1;
                                    if ( ! wbErr )
                                    {
                                       Rfr0gs = false;
                                       /* Set Refresh If Dynamicfiltersselector1 Changed */
                                       if ( StringUtil.StrCmp(cgiGet( "GXH_vDYNAMICFILTERSSELECTOR1"), AV15DynamicFiltersSelector1) != 0 )
                                       {
                                          Rfr0gs = true;
                                       }
                                       /* Set Refresh If Dynamicfiltersoperator1 Changed */
                                       if ( ( context.localUtil.CToN( cgiGet( "GXH_vDYNAMICFILTERSOPERATOR1"), ".", ",") != Convert.ToDecimal( AV16DynamicFiltersOperator1 )) )
                                       {
                                          Rfr0gs = true;
                                       }
                                       /* Set Refresh If Poconcdsc1 Changed */
                                       if ( StringUtil.StrCmp(cgiGet( "GXH_vPOCONCDSC1"), AV17PoConcDsc1) != 0 )
                                       {
                                          Rfr0gs = true;
                                       }
                                       /* Set Refresh If Dynamicfiltersselector2 Changed */
                                       if ( StringUtil.StrCmp(cgiGet( "GXH_vDYNAMICFILTERSSELECTOR2"), AV19DynamicFiltersSelector2) != 0 )
                                       {
                                          Rfr0gs = true;
                                       }
                                       /* Set Refresh If Dynamicfiltersoperator2 Changed */
                                       if ( ( context.localUtil.CToN( cgiGet( "GXH_vDYNAMICFILTERSOPERATOR2"), ".", ",") != Convert.ToDecimal( AV20DynamicFiltersOperator2 )) )
                                       {
                                          Rfr0gs = true;
                                       }
                                       /* Set Refresh If Poconcdsc2 Changed */
                                       if ( StringUtil.StrCmp(cgiGet( "GXH_vPOCONCDSC2"), AV21PoConcDsc2) != 0 )
                                       {
                                          Rfr0gs = true;
                                       }
                                       /* Set Refresh If Dynamicfiltersselector3 Changed */
                                       if ( StringUtil.StrCmp(cgiGet( "GXH_vDYNAMICFILTERSSELECTOR3"), AV23DynamicFiltersSelector3) != 0 )
                                       {
                                          Rfr0gs = true;
                                       }
                                       /* Set Refresh If Dynamicfiltersoperator3 Changed */
                                       if ( ( context.localUtil.CToN( cgiGet( "GXH_vDYNAMICFILTERSOPERATOR3"), ".", ",") != Convert.ToDecimal( AV24DynamicFiltersOperator3 )) )
                                       {
                                          Rfr0gs = true;
                                       }
                                       /* Set Refresh If Poconcdsc3 Changed */
                                       if ( StringUtil.StrCmp(cgiGet( "GXH_vPOCONCDSC3"), AV25PoConcDsc3) != 0 )
                                       {
                                          Rfr0gs = true;
                                       }
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

      protected void WE272( )
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

      protected void PA272( )
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
               GX_FocusControl = cmbavDynamicfiltersselector1_Internalname;
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
         SubsflControlProps_1012( ) ;
         while ( nGXsfl_101_idx <= nRC_GXsfl_101 )
         {
            sendrow_1012( ) ;
            nGXsfl_101_idx = ((subGrid_Islastpage==1)&&(nGXsfl_101_idx+1>subGrid_fnc_Recordsperpage( )) ? 1 : nGXsfl_101_idx+1);
            sGXsfl_101_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_101_idx), 4, 0), 4, "0");
            SubsflControlProps_1012( ) ;
         }
         AddString( context.httpAjaxContext.getJSONContainerResponse( GridContainer)) ;
         /* End function gxnrGrid_newrow */
      }

      protected void gxgrGrid_refresh( int subGrid_Rows ,
                                       string AV15DynamicFiltersSelector1 ,
                                       short AV16DynamicFiltersOperator1 ,
                                       string AV17PoConcDsc1 ,
                                       string AV19DynamicFiltersSelector2 ,
                                       short AV20DynamicFiltersOperator2 ,
                                       string AV21PoConcDsc2 ,
                                       string AV23DynamicFiltersSelector3 ,
                                       short AV24DynamicFiltersOperator3 ,
                                       string AV25PoConcDsc3 ,
                                       string AV51Pgmname ,
                                       bool AV18DynamicFiltersEnabled2 ,
                                       bool AV22DynamicFiltersEnabled3 ,
                                       int AV31TFPoConcCod ,
                                       int AV32TFPoConcCod_To ,
                                       string AV33TFPoConcDsc ,
                                       string AV34TFPoConcDsc_Sel ,
                                       GxSimpleCollection<string> AV48TFPoConcTip_Sels ,
                                       GxSimpleCollection<short> AV38TFPoConcSts_Sels ,
                                       short AV13OrderedBy ,
                                       bool AV14OrderedDsc ,
                                       GeneXus.Programs.wwpbaseobjects.SdtWWPGridState AV10GridState ,
                                       bool AV27DynamicFiltersIgnoreFirst ,
                                       bool AV26DynamicFiltersRemoving )
      {
         initialize_formulas( ) ;
         GxWebStd.set_html_headers( context, 0, "", "");
         /* Execute user event: Refresh */
         E25272 ();
         GRID_nCurrentRecord = 0;
         RF272( ) ;
         GXKey = Crypto.GetSiteKey( );
         send_integrity_footer_hashes( ) ;
         GXKey = Crypto.GetSiteKey( );
         /* End function gxgrGrid_refresh */
      }

      protected void send_integrity_hashes( )
      {
         GxWebStd.gx_hidden_field( context, "gxhash_POCONCCOD", GetSecureSignedToken( "", context.localUtil.Format( (decimal)(A313PoConcCod), "ZZZZZ9"), context));
         GxWebStd.gx_hidden_field( context, "POCONCCOD", StringUtil.LTrim( StringUtil.NToC( (decimal)(A313PoConcCod), 6, 0, ".", "")));
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
         if ( cmbavDynamicfiltersselector1.ItemCount > 0 )
         {
            AV15DynamicFiltersSelector1 = cmbavDynamicfiltersselector1.getValidValue(AV15DynamicFiltersSelector1);
            AssignAttri("", false, "AV15DynamicFiltersSelector1", AV15DynamicFiltersSelector1);
         }
         if ( context.isAjaxRequest( ) )
         {
            cmbavDynamicfiltersselector1.CurrentValue = StringUtil.RTrim( AV15DynamicFiltersSelector1);
            AssignProp("", false, cmbavDynamicfiltersselector1_Internalname, "Values", cmbavDynamicfiltersselector1.ToJavascriptSource(), true);
         }
         if ( cmbavDynamicfiltersoperator1.ItemCount > 0 )
         {
            AV16DynamicFiltersOperator1 = (short)(NumberUtil.Val( cmbavDynamicfiltersoperator1.getValidValue(StringUtil.Trim( StringUtil.Str( (decimal)(AV16DynamicFiltersOperator1), 4, 0))), "."));
            AssignAttri("", false, "AV16DynamicFiltersOperator1", StringUtil.LTrimStr( (decimal)(AV16DynamicFiltersOperator1), 4, 0));
         }
         if ( context.isAjaxRequest( ) )
         {
            cmbavDynamicfiltersoperator1.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV16DynamicFiltersOperator1), 4, 0));
            AssignProp("", false, cmbavDynamicfiltersoperator1_Internalname, "Values", cmbavDynamicfiltersoperator1.ToJavascriptSource(), true);
         }
         if ( cmbavDynamicfiltersselector2.ItemCount > 0 )
         {
            AV19DynamicFiltersSelector2 = cmbavDynamicfiltersselector2.getValidValue(AV19DynamicFiltersSelector2);
            AssignAttri("", false, "AV19DynamicFiltersSelector2", AV19DynamicFiltersSelector2);
         }
         if ( context.isAjaxRequest( ) )
         {
            cmbavDynamicfiltersselector2.CurrentValue = StringUtil.RTrim( AV19DynamicFiltersSelector2);
            AssignProp("", false, cmbavDynamicfiltersselector2_Internalname, "Values", cmbavDynamicfiltersselector2.ToJavascriptSource(), true);
         }
         if ( cmbavDynamicfiltersoperator2.ItemCount > 0 )
         {
            AV20DynamicFiltersOperator2 = (short)(NumberUtil.Val( cmbavDynamicfiltersoperator2.getValidValue(StringUtil.Trim( StringUtil.Str( (decimal)(AV20DynamicFiltersOperator2), 4, 0))), "."));
            AssignAttri("", false, "AV20DynamicFiltersOperator2", StringUtil.LTrimStr( (decimal)(AV20DynamicFiltersOperator2), 4, 0));
         }
         if ( context.isAjaxRequest( ) )
         {
            cmbavDynamicfiltersoperator2.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV20DynamicFiltersOperator2), 4, 0));
            AssignProp("", false, cmbavDynamicfiltersoperator2_Internalname, "Values", cmbavDynamicfiltersoperator2.ToJavascriptSource(), true);
         }
         if ( cmbavDynamicfiltersselector3.ItemCount > 0 )
         {
            AV23DynamicFiltersSelector3 = cmbavDynamicfiltersselector3.getValidValue(AV23DynamicFiltersSelector3);
            AssignAttri("", false, "AV23DynamicFiltersSelector3", AV23DynamicFiltersSelector3);
         }
         if ( context.isAjaxRequest( ) )
         {
            cmbavDynamicfiltersselector3.CurrentValue = StringUtil.RTrim( AV23DynamicFiltersSelector3);
            AssignProp("", false, cmbavDynamicfiltersselector3_Internalname, "Values", cmbavDynamicfiltersselector3.ToJavascriptSource(), true);
         }
         if ( cmbavDynamicfiltersoperator3.ItemCount > 0 )
         {
            AV24DynamicFiltersOperator3 = (short)(NumberUtil.Val( cmbavDynamicfiltersoperator3.getValidValue(StringUtil.Trim( StringUtil.Str( (decimal)(AV24DynamicFiltersOperator3), 4, 0))), "."));
            AssignAttri("", false, "AV24DynamicFiltersOperator3", StringUtil.LTrimStr( (decimal)(AV24DynamicFiltersOperator3), 4, 0));
         }
         if ( context.isAjaxRequest( ) )
         {
            cmbavDynamicfiltersoperator3.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV24DynamicFiltersOperator3), 4, 0));
            AssignProp("", false, cmbavDynamicfiltersoperator3_Internalname, "Values", cmbavDynamicfiltersoperator3.ToJavascriptSource(), true);
         }
      }

      public void Refresh( )
      {
         send_integrity_hashes( ) ;
         RF272( ) ;
         if ( isFullAjaxMode( ) )
         {
            send_integrity_footer_hashes( ) ;
         }
      }

      protected void initialize_formulas( )
      {
         /* GeneXus formulas. */
         AV51Pgmname = "Produccion.ConceptosOrdenesProduccionWW";
         context.Gx_err = 0;
      }

      protected void RF272( )
      {
         initialize_formulas( ) ;
         clear_multi_value_controls( ) ;
         if ( isAjaxCallMode( ) )
         {
            GridContainer.ClearRows();
         }
         wbStart = 101;
         /* Execute user event: Refresh */
         E25272 ();
         nGXsfl_101_idx = 1;
         sGXsfl_101_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_101_idx), 4, 0), 4, "0");
         SubsflControlProps_1012( ) ;
         bGXsfl_101_Refreshing = true;
         GridContainer.AddObjectProperty("GridName", "Grid");
         GridContainer.AddObjectProperty("CmpContext", "");
         GridContainer.AddObjectProperty("InMasterPage", "false");
         GridContainer.AddObjectProperty("Class", "GridWithPaginationBar WorkWith");
         GridContainer.AddObjectProperty("Cellpadding", StringUtil.LTrim( StringUtil.NToC( (decimal)(1), 4, 0, ".", "")));
         GridContainer.AddObjectProperty("Cellspacing", StringUtil.LTrim( StringUtil.NToC( (decimal)(2), 4, 0, ".", "")));
         GridContainer.AddObjectProperty("Backcolorstyle", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid_Backcolorstyle), 1, 0, ".", "")));
         GridContainer.AddObjectProperty("Sortable", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid_Sortable), 1, 0, ".", "")));
         GridContainer.PageSize = subGrid_fnc_Recordsperpage( );
         gxdyncontrolsrefreshing = true;
         fix_multi_value_controls( ) ;
         gxdyncontrolsrefreshing = false;
         if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
         {
            SubsflControlProps_1012( ) ;
            GXPagingFrom2 = (int)(((subGrid_Rows==0) ? 0 : GRID_nFirstRecordOnPage));
            GXPagingTo2 = ((subGrid_Rows==0) ? 10000 : subGrid_fnc_Recordsperpage( )+1);
            pr_default.dynParam(0, new Object[]{ new Object[]{
                                                 A1650PoConcTip ,
                                                 AV67Produccion_conceptosordenesproduccionwwds_16_tfpoconctip_sels ,
                                                 A1649PoConcSts ,
                                                 AV68Produccion_conceptosordenesproduccionwwds_17_tfpoconcsts_sels ,
                                                 AV52Produccion_conceptosordenesproduccionwwds_1_dynamicfiltersselector1 ,
                                                 AV53Produccion_conceptosordenesproduccionwwds_2_dynamicfiltersoperator1 ,
                                                 AV54Produccion_conceptosordenesproduccionwwds_3_poconcdsc1 ,
                                                 AV55Produccion_conceptosordenesproduccionwwds_4_dynamicfiltersenabled2 ,
                                                 AV56Produccion_conceptosordenesproduccionwwds_5_dynamicfiltersselector2 ,
                                                 AV57Produccion_conceptosordenesproduccionwwds_6_dynamicfiltersoperator2 ,
                                                 AV58Produccion_conceptosordenesproduccionwwds_7_poconcdsc2 ,
                                                 AV59Produccion_conceptosordenesproduccionwwds_8_dynamicfiltersenabled3 ,
                                                 AV60Produccion_conceptosordenesproduccionwwds_9_dynamicfiltersselector3 ,
                                                 AV61Produccion_conceptosordenesproduccionwwds_10_dynamicfiltersoperator3 ,
                                                 AV62Produccion_conceptosordenesproduccionwwds_11_poconcdsc3 ,
                                                 AV63Produccion_conceptosordenesproduccionwwds_12_tfpoconccod ,
                                                 AV64Produccion_conceptosordenesproduccionwwds_13_tfpoconccod_to ,
                                                 AV66Produccion_conceptosordenesproduccionwwds_15_tfpoconcdsc_sel ,
                                                 AV65Produccion_conceptosordenesproduccionwwds_14_tfpoconcdsc ,
                                                 AV67Produccion_conceptosordenesproduccionwwds_16_tfpoconctip_sels.Count ,
                                                 AV68Produccion_conceptosordenesproduccionwwds_17_tfpoconcsts_sels.Count ,
                                                 A1648PoConcDsc ,
                                                 A313PoConcCod ,
                                                 AV13OrderedBy ,
                                                 AV14OrderedDsc } ,
                                                 new int[]{
                                                 TypeConstants.SHORT, TypeConstants.SHORT, TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.INT, TypeConstants.INT, TypeConstants.INT, TypeConstants.INT,
                                                 TypeConstants.INT, TypeConstants.SHORT, TypeConstants.BOOLEAN
                                                 }
            });
            lV54Produccion_conceptosordenesproduccionwwds_3_poconcdsc1 = StringUtil.PadR( StringUtil.RTrim( AV54Produccion_conceptosordenesproduccionwwds_3_poconcdsc1), 100, "%");
            lV54Produccion_conceptosordenesproduccionwwds_3_poconcdsc1 = StringUtil.PadR( StringUtil.RTrim( AV54Produccion_conceptosordenesproduccionwwds_3_poconcdsc1), 100, "%");
            lV58Produccion_conceptosordenesproduccionwwds_7_poconcdsc2 = StringUtil.PadR( StringUtil.RTrim( AV58Produccion_conceptosordenesproduccionwwds_7_poconcdsc2), 100, "%");
            lV58Produccion_conceptosordenesproduccionwwds_7_poconcdsc2 = StringUtil.PadR( StringUtil.RTrim( AV58Produccion_conceptosordenesproduccionwwds_7_poconcdsc2), 100, "%");
            lV62Produccion_conceptosordenesproduccionwwds_11_poconcdsc3 = StringUtil.PadR( StringUtil.RTrim( AV62Produccion_conceptosordenesproduccionwwds_11_poconcdsc3), 100, "%");
            lV62Produccion_conceptosordenesproduccionwwds_11_poconcdsc3 = StringUtil.PadR( StringUtil.RTrim( AV62Produccion_conceptosordenesproduccionwwds_11_poconcdsc3), 100, "%");
            lV65Produccion_conceptosordenesproduccionwwds_14_tfpoconcdsc = StringUtil.PadR( StringUtil.RTrim( AV65Produccion_conceptosordenesproduccionwwds_14_tfpoconcdsc), 100, "%");
            /* Using cursor H00272 */
            pr_default.execute(0, new Object[] {lV54Produccion_conceptosordenesproduccionwwds_3_poconcdsc1, lV54Produccion_conceptosordenesproduccionwwds_3_poconcdsc1, lV58Produccion_conceptosordenesproduccionwwds_7_poconcdsc2, lV58Produccion_conceptosordenesproduccionwwds_7_poconcdsc2, lV62Produccion_conceptosordenesproduccionwwds_11_poconcdsc3, lV62Produccion_conceptosordenesproduccionwwds_11_poconcdsc3, AV63Produccion_conceptosordenesproduccionwwds_12_tfpoconccod, AV64Produccion_conceptosordenesproduccionwwds_13_tfpoconccod_to, lV65Produccion_conceptosordenesproduccionwwds_14_tfpoconcdsc, AV66Produccion_conceptosordenesproduccionwwds_15_tfpoconcdsc_sel, GXPagingFrom2, GXPagingTo2, GXPagingTo2});
            nGXsfl_101_idx = 1;
            sGXsfl_101_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_101_idx), 4, 0), 4, "0");
            SubsflControlProps_1012( ) ;
            while ( ( (pr_default.getStatus(0) != 101) ) && ( ( ( subGrid_Rows == 0 ) || ( GRID_nCurrentRecord < subGrid_fnc_Recordsperpage( ) ) ) ) )
            {
               A1649PoConcSts = H00272_A1649PoConcSts[0];
               A1650PoConcTip = H00272_A1650PoConcTip[0];
               A1648PoConcDsc = H00272_A1648PoConcDsc[0];
               A313PoConcCod = H00272_A313PoConcCod[0];
               E26272 ();
               pr_default.readNext(0);
            }
            GRID_nEOF = (short)(((pr_default.getStatus(0) == 101) ? 1 : 0));
            GxWebStd.gx_hidden_field( context, "GRID_nEOF", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRID_nEOF), 1, 0, ".", "")));
            pr_default.close(0);
            wbEnd = 101;
            WB270( ) ;
         }
         bGXsfl_101_Refreshing = true;
      }

      protected void send_integrity_lvl_hashes272( )
      {
         GxWebStd.gx_hidden_field( context, "vPGMNAME", StringUtil.RTrim( AV51Pgmname));
         GxWebStd.gx_hidden_field( context, "gxhash_vPGMNAME", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( AV51Pgmname, "")), context));
         GxWebStd.gx_hidden_field( context, "gxhash_POCONCCOD"+"_"+sGXsfl_101_idx, GetSecureSignedToken( sGXsfl_101_idx, context.localUtil.Format( (decimal)(A313PoConcCod), "ZZZZZ9"), context));
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
         AV52Produccion_conceptosordenesproduccionwwds_1_dynamicfiltersselector1 = AV15DynamicFiltersSelector1;
         AV53Produccion_conceptosordenesproduccionwwds_2_dynamicfiltersoperator1 = AV16DynamicFiltersOperator1;
         AV54Produccion_conceptosordenesproduccionwwds_3_poconcdsc1 = AV17PoConcDsc1;
         AV55Produccion_conceptosordenesproduccionwwds_4_dynamicfiltersenabled2 = AV18DynamicFiltersEnabled2;
         AV56Produccion_conceptosordenesproduccionwwds_5_dynamicfiltersselector2 = AV19DynamicFiltersSelector2;
         AV57Produccion_conceptosordenesproduccionwwds_6_dynamicfiltersoperator2 = AV20DynamicFiltersOperator2;
         AV58Produccion_conceptosordenesproduccionwwds_7_poconcdsc2 = AV21PoConcDsc2;
         AV59Produccion_conceptosordenesproduccionwwds_8_dynamicfiltersenabled3 = AV22DynamicFiltersEnabled3;
         AV60Produccion_conceptosordenesproduccionwwds_9_dynamicfiltersselector3 = AV23DynamicFiltersSelector3;
         AV61Produccion_conceptosordenesproduccionwwds_10_dynamicfiltersoperator3 = AV24DynamicFiltersOperator3;
         AV62Produccion_conceptosordenesproduccionwwds_11_poconcdsc3 = AV25PoConcDsc3;
         AV63Produccion_conceptosordenesproduccionwwds_12_tfpoconccod = AV31TFPoConcCod;
         AV64Produccion_conceptosordenesproduccionwwds_13_tfpoconccod_to = AV32TFPoConcCod_To;
         AV65Produccion_conceptosordenesproduccionwwds_14_tfpoconcdsc = AV33TFPoConcDsc;
         AV66Produccion_conceptosordenesproduccionwwds_15_tfpoconcdsc_sel = AV34TFPoConcDsc_Sel;
         AV67Produccion_conceptosordenesproduccionwwds_16_tfpoconctip_sels = AV48TFPoConcTip_Sels;
         AV68Produccion_conceptosordenesproduccionwwds_17_tfpoconcsts_sels = AV38TFPoConcSts_Sels;
         pr_default.dynParam(1, new Object[]{ new Object[]{
                                              A1650PoConcTip ,
                                              AV67Produccion_conceptosordenesproduccionwwds_16_tfpoconctip_sels ,
                                              A1649PoConcSts ,
                                              AV68Produccion_conceptosordenesproduccionwwds_17_tfpoconcsts_sels ,
                                              AV52Produccion_conceptosordenesproduccionwwds_1_dynamicfiltersselector1 ,
                                              AV53Produccion_conceptosordenesproduccionwwds_2_dynamicfiltersoperator1 ,
                                              AV54Produccion_conceptosordenesproduccionwwds_3_poconcdsc1 ,
                                              AV55Produccion_conceptosordenesproduccionwwds_4_dynamicfiltersenabled2 ,
                                              AV56Produccion_conceptosordenesproduccionwwds_5_dynamicfiltersselector2 ,
                                              AV57Produccion_conceptosordenesproduccionwwds_6_dynamicfiltersoperator2 ,
                                              AV58Produccion_conceptosordenesproduccionwwds_7_poconcdsc2 ,
                                              AV59Produccion_conceptosordenesproduccionwwds_8_dynamicfiltersenabled3 ,
                                              AV60Produccion_conceptosordenesproduccionwwds_9_dynamicfiltersselector3 ,
                                              AV61Produccion_conceptosordenesproduccionwwds_10_dynamicfiltersoperator3 ,
                                              AV62Produccion_conceptosordenesproduccionwwds_11_poconcdsc3 ,
                                              AV63Produccion_conceptosordenesproduccionwwds_12_tfpoconccod ,
                                              AV64Produccion_conceptosordenesproduccionwwds_13_tfpoconccod_to ,
                                              AV66Produccion_conceptosordenesproduccionwwds_15_tfpoconcdsc_sel ,
                                              AV65Produccion_conceptosordenesproduccionwwds_14_tfpoconcdsc ,
                                              AV67Produccion_conceptosordenesproduccionwwds_16_tfpoconctip_sels.Count ,
                                              AV68Produccion_conceptosordenesproduccionwwds_17_tfpoconcsts_sels.Count ,
                                              A1648PoConcDsc ,
                                              A313PoConcCod ,
                                              AV13OrderedBy ,
                                              AV14OrderedDsc } ,
                                              new int[]{
                                              TypeConstants.SHORT, TypeConstants.SHORT, TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.INT, TypeConstants.INT, TypeConstants.INT, TypeConstants.INT,
                                              TypeConstants.INT, TypeConstants.SHORT, TypeConstants.BOOLEAN
                                              }
         });
         lV54Produccion_conceptosordenesproduccionwwds_3_poconcdsc1 = StringUtil.PadR( StringUtil.RTrim( AV54Produccion_conceptosordenesproduccionwwds_3_poconcdsc1), 100, "%");
         lV54Produccion_conceptosordenesproduccionwwds_3_poconcdsc1 = StringUtil.PadR( StringUtil.RTrim( AV54Produccion_conceptosordenesproduccionwwds_3_poconcdsc1), 100, "%");
         lV58Produccion_conceptosordenesproduccionwwds_7_poconcdsc2 = StringUtil.PadR( StringUtil.RTrim( AV58Produccion_conceptosordenesproduccionwwds_7_poconcdsc2), 100, "%");
         lV58Produccion_conceptosordenesproduccionwwds_7_poconcdsc2 = StringUtil.PadR( StringUtil.RTrim( AV58Produccion_conceptosordenesproduccionwwds_7_poconcdsc2), 100, "%");
         lV62Produccion_conceptosordenesproduccionwwds_11_poconcdsc3 = StringUtil.PadR( StringUtil.RTrim( AV62Produccion_conceptosordenesproduccionwwds_11_poconcdsc3), 100, "%");
         lV62Produccion_conceptosordenesproduccionwwds_11_poconcdsc3 = StringUtil.PadR( StringUtil.RTrim( AV62Produccion_conceptosordenesproduccionwwds_11_poconcdsc3), 100, "%");
         lV65Produccion_conceptosordenesproduccionwwds_14_tfpoconcdsc = StringUtil.PadR( StringUtil.RTrim( AV65Produccion_conceptosordenesproduccionwwds_14_tfpoconcdsc), 100, "%");
         /* Using cursor H00273 */
         pr_default.execute(1, new Object[] {lV54Produccion_conceptosordenesproduccionwwds_3_poconcdsc1, lV54Produccion_conceptosordenesproduccionwwds_3_poconcdsc1, lV58Produccion_conceptosordenesproduccionwwds_7_poconcdsc2, lV58Produccion_conceptosordenesproduccionwwds_7_poconcdsc2, lV62Produccion_conceptosordenesproduccionwwds_11_poconcdsc3, lV62Produccion_conceptosordenesproduccionwwds_11_poconcdsc3, AV63Produccion_conceptosordenesproduccionwwds_12_tfpoconccod, AV64Produccion_conceptosordenesproduccionwwds_13_tfpoconccod_to, lV65Produccion_conceptosordenesproduccionwwds_14_tfpoconcdsc, AV66Produccion_conceptosordenesproduccionwwds_15_tfpoconcdsc_sel});
         GRID_nRecordCount = H00273_AGRID_nRecordCount[0];
         pr_default.close(1);
         return (int)(GRID_nRecordCount) ;
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
         AV52Produccion_conceptosordenesproduccionwwds_1_dynamicfiltersselector1 = AV15DynamicFiltersSelector1;
         AV53Produccion_conceptosordenesproduccionwwds_2_dynamicfiltersoperator1 = AV16DynamicFiltersOperator1;
         AV54Produccion_conceptosordenesproduccionwwds_3_poconcdsc1 = AV17PoConcDsc1;
         AV55Produccion_conceptosordenesproduccionwwds_4_dynamicfiltersenabled2 = AV18DynamicFiltersEnabled2;
         AV56Produccion_conceptosordenesproduccionwwds_5_dynamicfiltersselector2 = AV19DynamicFiltersSelector2;
         AV57Produccion_conceptosordenesproduccionwwds_6_dynamicfiltersoperator2 = AV20DynamicFiltersOperator2;
         AV58Produccion_conceptosordenesproduccionwwds_7_poconcdsc2 = AV21PoConcDsc2;
         AV59Produccion_conceptosordenesproduccionwwds_8_dynamicfiltersenabled3 = AV22DynamicFiltersEnabled3;
         AV60Produccion_conceptosordenesproduccionwwds_9_dynamicfiltersselector3 = AV23DynamicFiltersSelector3;
         AV61Produccion_conceptosordenesproduccionwwds_10_dynamicfiltersoperator3 = AV24DynamicFiltersOperator3;
         AV62Produccion_conceptosordenesproduccionwwds_11_poconcdsc3 = AV25PoConcDsc3;
         AV63Produccion_conceptosordenesproduccionwwds_12_tfpoconccod = AV31TFPoConcCod;
         AV64Produccion_conceptosordenesproduccionwwds_13_tfpoconccod_to = AV32TFPoConcCod_To;
         AV65Produccion_conceptosordenesproduccionwwds_14_tfpoconcdsc = AV33TFPoConcDsc;
         AV66Produccion_conceptosordenesproduccionwwds_15_tfpoconcdsc_sel = AV34TFPoConcDsc_Sel;
         AV67Produccion_conceptosordenesproduccionwwds_16_tfpoconctip_sels = AV48TFPoConcTip_Sels;
         AV68Produccion_conceptosordenesproduccionwwds_17_tfpoconcsts_sels = AV38TFPoConcSts_Sels;
         GRID_nFirstRecordOnPage = 0;
         GxWebStd.gx_hidden_field( context, "GRID_nFirstRecordOnPage", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRID_nFirstRecordOnPage), 15, 0, ".", "")));
         if ( isFullAjaxMode( ) )
         {
            gxgrGrid_refresh( subGrid_Rows, AV15DynamicFiltersSelector1, AV16DynamicFiltersOperator1, AV17PoConcDsc1, AV19DynamicFiltersSelector2, AV20DynamicFiltersOperator2, AV21PoConcDsc2, AV23DynamicFiltersSelector3, AV24DynamicFiltersOperator3, AV25PoConcDsc3, AV51Pgmname, AV18DynamicFiltersEnabled2, AV22DynamicFiltersEnabled3, AV31TFPoConcCod, AV32TFPoConcCod_To, AV33TFPoConcDsc, AV34TFPoConcDsc_Sel, AV48TFPoConcTip_Sels, AV38TFPoConcSts_Sels, AV13OrderedBy, AV14OrderedDsc, AV10GridState, AV27DynamicFiltersIgnoreFirst, AV26DynamicFiltersRemoving) ;
         }
         send_integrity_footer_hashes( ) ;
         return 0 ;
      }

      protected short subgrid_nextpage( )
      {
         AV52Produccion_conceptosordenesproduccionwwds_1_dynamicfiltersselector1 = AV15DynamicFiltersSelector1;
         AV53Produccion_conceptosordenesproduccionwwds_2_dynamicfiltersoperator1 = AV16DynamicFiltersOperator1;
         AV54Produccion_conceptosordenesproduccionwwds_3_poconcdsc1 = AV17PoConcDsc1;
         AV55Produccion_conceptosordenesproduccionwwds_4_dynamicfiltersenabled2 = AV18DynamicFiltersEnabled2;
         AV56Produccion_conceptosordenesproduccionwwds_5_dynamicfiltersselector2 = AV19DynamicFiltersSelector2;
         AV57Produccion_conceptosordenesproduccionwwds_6_dynamicfiltersoperator2 = AV20DynamicFiltersOperator2;
         AV58Produccion_conceptosordenesproduccionwwds_7_poconcdsc2 = AV21PoConcDsc2;
         AV59Produccion_conceptosordenesproduccionwwds_8_dynamicfiltersenabled3 = AV22DynamicFiltersEnabled3;
         AV60Produccion_conceptosordenesproduccionwwds_9_dynamicfiltersselector3 = AV23DynamicFiltersSelector3;
         AV61Produccion_conceptosordenesproduccionwwds_10_dynamicfiltersoperator3 = AV24DynamicFiltersOperator3;
         AV62Produccion_conceptosordenesproduccionwwds_11_poconcdsc3 = AV25PoConcDsc3;
         AV63Produccion_conceptosordenesproduccionwwds_12_tfpoconccod = AV31TFPoConcCod;
         AV64Produccion_conceptosordenesproduccionwwds_13_tfpoconccod_to = AV32TFPoConcCod_To;
         AV65Produccion_conceptosordenesproduccionwwds_14_tfpoconcdsc = AV33TFPoConcDsc;
         AV66Produccion_conceptosordenesproduccionwwds_15_tfpoconcdsc_sel = AV34TFPoConcDsc_Sel;
         AV67Produccion_conceptosordenesproduccionwwds_16_tfpoconctip_sels = AV48TFPoConcTip_Sels;
         AV68Produccion_conceptosordenesproduccionwwds_17_tfpoconcsts_sels = AV38TFPoConcSts_Sels;
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
            gxgrGrid_refresh( subGrid_Rows, AV15DynamicFiltersSelector1, AV16DynamicFiltersOperator1, AV17PoConcDsc1, AV19DynamicFiltersSelector2, AV20DynamicFiltersOperator2, AV21PoConcDsc2, AV23DynamicFiltersSelector3, AV24DynamicFiltersOperator3, AV25PoConcDsc3, AV51Pgmname, AV18DynamicFiltersEnabled2, AV22DynamicFiltersEnabled3, AV31TFPoConcCod, AV32TFPoConcCod_To, AV33TFPoConcDsc, AV34TFPoConcDsc_Sel, AV48TFPoConcTip_Sels, AV38TFPoConcSts_Sels, AV13OrderedBy, AV14OrderedDsc, AV10GridState, AV27DynamicFiltersIgnoreFirst, AV26DynamicFiltersRemoving) ;
         }
         send_integrity_footer_hashes( ) ;
         return (short)(((GRID_nEOF==0) ? 0 : 2)) ;
      }

      protected short subgrid_previouspage( )
      {
         AV52Produccion_conceptosordenesproduccionwwds_1_dynamicfiltersselector1 = AV15DynamicFiltersSelector1;
         AV53Produccion_conceptosordenesproduccionwwds_2_dynamicfiltersoperator1 = AV16DynamicFiltersOperator1;
         AV54Produccion_conceptosordenesproduccionwwds_3_poconcdsc1 = AV17PoConcDsc1;
         AV55Produccion_conceptosordenesproduccionwwds_4_dynamicfiltersenabled2 = AV18DynamicFiltersEnabled2;
         AV56Produccion_conceptosordenesproduccionwwds_5_dynamicfiltersselector2 = AV19DynamicFiltersSelector2;
         AV57Produccion_conceptosordenesproduccionwwds_6_dynamicfiltersoperator2 = AV20DynamicFiltersOperator2;
         AV58Produccion_conceptosordenesproduccionwwds_7_poconcdsc2 = AV21PoConcDsc2;
         AV59Produccion_conceptosordenesproduccionwwds_8_dynamicfiltersenabled3 = AV22DynamicFiltersEnabled3;
         AV60Produccion_conceptosordenesproduccionwwds_9_dynamicfiltersselector3 = AV23DynamicFiltersSelector3;
         AV61Produccion_conceptosordenesproduccionwwds_10_dynamicfiltersoperator3 = AV24DynamicFiltersOperator3;
         AV62Produccion_conceptosordenesproduccionwwds_11_poconcdsc3 = AV25PoConcDsc3;
         AV63Produccion_conceptosordenesproduccionwwds_12_tfpoconccod = AV31TFPoConcCod;
         AV64Produccion_conceptosordenesproduccionwwds_13_tfpoconccod_to = AV32TFPoConcCod_To;
         AV65Produccion_conceptosordenesproduccionwwds_14_tfpoconcdsc = AV33TFPoConcDsc;
         AV66Produccion_conceptosordenesproduccionwwds_15_tfpoconcdsc_sel = AV34TFPoConcDsc_Sel;
         AV67Produccion_conceptosordenesproduccionwwds_16_tfpoconctip_sels = AV48TFPoConcTip_Sels;
         AV68Produccion_conceptosordenesproduccionwwds_17_tfpoconcsts_sels = AV38TFPoConcSts_Sels;
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
            gxgrGrid_refresh( subGrid_Rows, AV15DynamicFiltersSelector1, AV16DynamicFiltersOperator1, AV17PoConcDsc1, AV19DynamicFiltersSelector2, AV20DynamicFiltersOperator2, AV21PoConcDsc2, AV23DynamicFiltersSelector3, AV24DynamicFiltersOperator3, AV25PoConcDsc3, AV51Pgmname, AV18DynamicFiltersEnabled2, AV22DynamicFiltersEnabled3, AV31TFPoConcCod, AV32TFPoConcCod_To, AV33TFPoConcDsc, AV34TFPoConcDsc_Sel, AV48TFPoConcTip_Sels, AV38TFPoConcSts_Sels, AV13OrderedBy, AV14OrderedDsc, AV10GridState, AV27DynamicFiltersIgnoreFirst, AV26DynamicFiltersRemoving) ;
         }
         send_integrity_footer_hashes( ) ;
         return 0 ;
      }

      protected short subgrid_lastpage( )
      {
         AV52Produccion_conceptosordenesproduccionwwds_1_dynamicfiltersselector1 = AV15DynamicFiltersSelector1;
         AV53Produccion_conceptosordenesproduccionwwds_2_dynamicfiltersoperator1 = AV16DynamicFiltersOperator1;
         AV54Produccion_conceptosordenesproduccionwwds_3_poconcdsc1 = AV17PoConcDsc1;
         AV55Produccion_conceptosordenesproduccionwwds_4_dynamicfiltersenabled2 = AV18DynamicFiltersEnabled2;
         AV56Produccion_conceptosordenesproduccionwwds_5_dynamicfiltersselector2 = AV19DynamicFiltersSelector2;
         AV57Produccion_conceptosordenesproduccionwwds_6_dynamicfiltersoperator2 = AV20DynamicFiltersOperator2;
         AV58Produccion_conceptosordenesproduccionwwds_7_poconcdsc2 = AV21PoConcDsc2;
         AV59Produccion_conceptosordenesproduccionwwds_8_dynamicfiltersenabled3 = AV22DynamicFiltersEnabled3;
         AV60Produccion_conceptosordenesproduccionwwds_9_dynamicfiltersselector3 = AV23DynamicFiltersSelector3;
         AV61Produccion_conceptosordenesproduccionwwds_10_dynamicfiltersoperator3 = AV24DynamicFiltersOperator3;
         AV62Produccion_conceptosordenesproduccionwwds_11_poconcdsc3 = AV25PoConcDsc3;
         AV63Produccion_conceptosordenesproduccionwwds_12_tfpoconccod = AV31TFPoConcCod;
         AV64Produccion_conceptosordenesproduccionwwds_13_tfpoconccod_to = AV32TFPoConcCod_To;
         AV65Produccion_conceptosordenesproduccionwwds_14_tfpoconcdsc = AV33TFPoConcDsc;
         AV66Produccion_conceptosordenesproduccionwwds_15_tfpoconcdsc_sel = AV34TFPoConcDsc_Sel;
         AV67Produccion_conceptosordenesproduccionwwds_16_tfpoconctip_sels = AV48TFPoConcTip_Sels;
         AV68Produccion_conceptosordenesproduccionwwds_17_tfpoconcsts_sels = AV38TFPoConcSts_Sels;
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
            gxgrGrid_refresh( subGrid_Rows, AV15DynamicFiltersSelector1, AV16DynamicFiltersOperator1, AV17PoConcDsc1, AV19DynamicFiltersSelector2, AV20DynamicFiltersOperator2, AV21PoConcDsc2, AV23DynamicFiltersSelector3, AV24DynamicFiltersOperator3, AV25PoConcDsc3, AV51Pgmname, AV18DynamicFiltersEnabled2, AV22DynamicFiltersEnabled3, AV31TFPoConcCod, AV32TFPoConcCod_To, AV33TFPoConcDsc, AV34TFPoConcDsc_Sel, AV48TFPoConcTip_Sels, AV38TFPoConcSts_Sels, AV13OrderedBy, AV14OrderedDsc, AV10GridState, AV27DynamicFiltersIgnoreFirst, AV26DynamicFiltersRemoving) ;
         }
         send_integrity_footer_hashes( ) ;
         return 0 ;
      }

      protected int subgrid_gotopage( int nPageNo )
      {
         AV52Produccion_conceptosordenesproduccionwwds_1_dynamicfiltersselector1 = AV15DynamicFiltersSelector1;
         AV53Produccion_conceptosordenesproduccionwwds_2_dynamicfiltersoperator1 = AV16DynamicFiltersOperator1;
         AV54Produccion_conceptosordenesproduccionwwds_3_poconcdsc1 = AV17PoConcDsc1;
         AV55Produccion_conceptosordenesproduccionwwds_4_dynamicfiltersenabled2 = AV18DynamicFiltersEnabled2;
         AV56Produccion_conceptosordenesproduccionwwds_5_dynamicfiltersselector2 = AV19DynamicFiltersSelector2;
         AV57Produccion_conceptosordenesproduccionwwds_6_dynamicfiltersoperator2 = AV20DynamicFiltersOperator2;
         AV58Produccion_conceptosordenesproduccionwwds_7_poconcdsc2 = AV21PoConcDsc2;
         AV59Produccion_conceptosordenesproduccionwwds_8_dynamicfiltersenabled3 = AV22DynamicFiltersEnabled3;
         AV60Produccion_conceptosordenesproduccionwwds_9_dynamicfiltersselector3 = AV23DynamicFiltersSelector3;
         AV61Produccion_conceptosordenesproduccionwwds_10_dynamicfiltersoperator3 = AV24DynamicFiltersOperator3;
         AV62Produccion_conceptosordenesproduccionwwds_11_poconcdsc3 = AV25PoConcDsc3;
         AV63Produccion_conceptosordenesproduccionwwds_12_tfpoconccod = AV31TFPoConcCod;
         AV64Produccion_conceptosordenesproduccionwwds_13_tfpoconccod_to = AV32TFPoConcCod_To;
         AV65Produccion_conceptosordenesproduccionwwds_14_tfpoconcdsc = AV33TFPoConcDsc;
         AV66Produccion_conceptosordenesproduccionwwds_15_tfpoconcdsc_sel = AV34TFPoConcDsc_Sel;
         AV67Produccion_conceptosordenesproduccionwwds_16_tfpoconctip_sels = AV48TFPoConcTip_Sels;
         AV68Produccion_conceptosordenesproduccionwwds_17_tfpoconcsts_sels = AV38TFPoConcSts_Sels;
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
            gxgrGrid_refresh( subGrid_Rows, AV15DynamicFiltersSelector1, AV16DynamicFiltersOperator1, AV17PoConcDsc1, AV19DynamicFiltersSelector2, AV20DynamicFiltersOperator2, AV21PoConcDsc2, AV23DynamicFiltersSelector3, AV24DynamicFiltersOperator3, AV25PoConcDsc3, AV51Pgmname, AV18DynamicFiltersEnabled2, AV22DynamicFiltersEnabled3, AV31TFPoConcCod, AV32TFPoConcCod_To, AV33TFPoConcDsc, AV34TFPoConcDsc_Sel, AV48TFPoConcTip_Sels, AV38TFPoConcSts_Sels, AV13OrderedBy, AV14OrderedDsc, AV10GridState, AV27DynamicFiltersIgnoreFirst, AV26DynamicFiltersRemoving) ;
         }
         send_integrity_footer_hashes( ) ;
         return (int)(0) ;
      }

      protected void before_start_formulas( )
      {
         AV51Pgmname = "Produccion.ConceptosOrdenesProduccionWW";
         context.Gx_err = 0;
         fix_multi_value_controls( ) ;
      }

      protected void STRUP270( )
      {
         /* Before Start, stand alone formulas. */
         before_start_formulas( ) ;
         /* Execute Start event if defined. */
         context.wbGlbDoneStart = 0;
         /* Execute user event: Start */
         E24272 ();
         context.wbGlbDoneStart = 1;
         /* After Start, stand alone formulas. */
         if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
         {
            /* Read saved SDTs. */
            ajax_req_read_hidden_sdt(cgiGet( "vAGEXPORTDATA"), AV45AGExportData);
            ajax_req_read_hidden_sdt(cgiGet( "vDDO_TITLESETTINGSICONS"), AV39DDO_TitleSettingsIcons);
            /* Read saved values. */
            nRC_GXsfl_101 = (int)(context.localUtil.CToN( cgiGet( "nRC_GXsfl_101"), ".", ","));
            AV41GridCurrentPage = (long)(context.localUtil.CToN( cgiGet( "vGRIDCURRENTPAGE"), ".", ","));
            AV42GridPageCount = (long)(context.localUtil.CToN( cgiGet( "vGRIDPAGECOUNT"), ".", ","));
            AV43GridAppliedFilters = cgiGet( "vGRIDAPPLIEDFILTERS");
            GRID_nFirstRecordOnPage = (long)(context.localUtil.CToN( cgiGet( "GRID_nFirstRecordOnPage"), ".", ","));
            GRID_nEOF = (short)(context.localUtil.CToN( cgiGet( "GRID_nEOF"), ".", ","));
            subGrid_Rows = (int)(context.localUtil.CToN( cgiGet( "GRID_Rows"), ".", ","));
            GxWebStd.gx_hidden_field( context, "GRID_Rows", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid_Rows), 6, 0, ".", "")));
            Dvpanel_tableheader_Width = cgiGet( "DVPANEL_TABLEHEADER_Width");
            Dvpanel_tableheader_Autowidth = StringUtil.StrToBool( cgiGet( "DVPANEL_TABLEHEADER_Autowidth"));
            Dvpanel_tableheader_Autoheight = StringUtil.StrToBool( cgiGet( "DVPANEL_TABLEHEADER_Autoheight"));
            Dvpanel_tableheader_Cls = cgiGet( "DVPANEL_TABLEHEADER_Cls");
            Dvpanel_tableheader_Title = cgiGet( "DVPANEL_TABLEHEADER_Title");
            Dvpanel_tableheader_Collapsible = StringUtil.StrToBool( cgiGet( "DVPANEL_TABLEHEADER_Collapsible"));
            Dvpanel_tableheader_Collapsed = StringUtil.StrToBool( cgiGet( "DVPANEL_TABLEHEADER_Collapsed"));
            Dvpanel_tableheader_Showcollapseicon = StringUtil.StrToBool( cgiGet( "DVPANEL_TABLEHEADER_Showcollapseicon"));
            Dvpanel_tableheader_Iconposition = cgiGet( "DVPANEL_TABLEHEADER_Iconposition");
            Dvpanel_tableheader_Autoscroll = StringUtil.StrToBool( cgiGet( "DVPANEL_TABLEHEADER_Autoscroll"));
            Gridpaginationbar_Class = cgiGet( "GRIDPAGINATIONBAR_Class");
            Gridpaginationbar_Showfirst = StringUtil.StrToBool( cgiGet( "GRIDPAGINATIONBAR_Showfirst"));
            Gridpaginationbar_Showprevious = StringUtil.StrToBool( cgiGet( "GRIDPAGINATIONBAR_Showprevious"));
            Gridpaginationbar_Shownext = StringUtil.StrToBool( cgiGet( "GRIDPAGINATIONBAR_Shownext"));
            Gridpaginationbar_Showlast = StringUtil.StrToBool( cgiGet( "GRIDPAGINATIONBAR_Showlast"));
            Gridpaginationbar_Pagestoshow = (int)(context.localUtil.CToN( cgiGet( "GRIDPAGINATIONBAR_Pagestoshow"), ".", ","));
            Gridpaginationbar_Pagingbuttonsposition = cgiGet( "GRIDPAGINATIONBAR_Pagingbuttonsposition");
            Gridpaginationbar_Pagingcaptionposition = cgiGet( "GRIDPAGINATIONBAR_Pagingcaptionposition");
            Gridpaginationbar_Emptygridclass = cgiGet( "GRIDPAGINATIONBAR_Emptygridclass");
            Gridpaginationbar_Rowsperpageselector = StringUtil.StrToBool( cgiGet( "GRIDPAGINATIONBAR_Rowsperpageselector"));
            Gridpaginationbar_Rowsperpageselectedvalue = (int)(context.localUtil.CToN( cgiGet( "GRIDPAGINATIONBAR_Rowsperpageselectedvalue"), ".", ","));
            Gridpaginationbar_Rowsperpageoptions = cgiGet( "GRIDPAGINATIONBAR_Rowsperpageoptions");
            Gridpaginationbar_Previous = cgiGet( "GRIDPAGINATIONBAR_Previous");
            Gridpaginationbar_Next = cgiGet( "GRIDPAGINATIONBAR_Next");
            Gridpaginationbar_Caption = cgiGet( "GRIDPAGINATIONBAR_Caption");
            Gridpaginationbar_Emptygridcaption = cgiGet( "GRIDPAGINATIONBAR_Emptygridcaption");
            Gridpaginationbar_Rowsperpagecaption = cgiGet( "GRIDPAGINATIONBAR_Rowsperpagecaption");
            Ddo_agexport_Icontype = cgiGet( "DDO_AGEXPORT_Icontype");
            Ddo_agexport_Icon = cgiGet( "DDO_AGEXPORT_Icon");
            Ddo_agexport_Caption = cgiGet( "DDO_AGEXPORT_Caption");
            Ddo_agexport_Cls = cgiGet( "DDO_AGEXPORT_Cls");
            Ddo_agexport_Titlecontrolidtoreplace = cgiGet( "DDO_AGEXPORT_Titlecontrolidtoreplace");
            Ddo_grid_Caption = cgiGet( "DDO_GRID_Caption");
            Ddo_grid_Filteredtext_set = cgiGet( "DDO_GRID_Filteredtext_set");
            Ddo_grid_Filteredtextto_set = cgiGet( "DDO_GRID_Filteredtextto_set");
            Ddo_grid_Selectedvalue_set = cgiGet( "DDO_GRID_Selectedvalue_set");
            Ddo_grid_Gridinternalname = cgiGet( "DDO_GRID_Gridinternalname");
            Ddo_grid_Columnids = cgiGet( "DDO_GRID_Columnids");
            Ddo_grid_Columnssortvalues = cgiGet( "DDO_GRID_Columnssortvalues");
            Ddo_grid_Includesortasc = cgiGet( "DDO_GRID_Includesortasc");
            Ddo_grid_Sortedstatus = cgiGet( "DDO_GRID_Sortedstatus");
            Ddo_grid_Includefilter = cgiGet( "DDO_GRID_Includefilter");
            Ddo_grid_Filtertype = cgiGet( "DDO_GRID_Filtertype");
            Ddo_grid_Filterisrange = cgiGet( "DDO_GRID_Filterisrange");
            Ddo_grid_Includedatalist = cgiGet( "DDO_GRID_Includedatalist");
            Ddo_grid_Datalisttype = cgiGet( "DDO_GRID_Datalisttype");
            Ddo_grid_Allowmultipleselection = cgiGet( "DDO_GRID_Allowmultipleselection");
            Ddo_grid_Datalistfixedvalues = cgiGet( "DDO_GRID_Datalistfixedvalues");
            Ddo_grid_Datalistproc = cgiGet( "DDO_GRID_Datalistproc");
            Innewwindow1_Width = cgiGet( "INNEWWINDOW1_Width");
            Innewwindow1_Height = cgiGet( "INNEWWINDOW1_Height");
            Innewwindow1_Target = cgiGet( "INNEWWINDOW1_Target");
            Grid_empowerer_Gridinternalname = cgiGet( "GRID_EMPOWERER_Gridinternalname");
            Grid_empowerer_Hastitlesettings = StringUtil.StrToBool( cgiGet( "GRID_EMPOWERER_Hastitlesettings"));
            subGrid_Rows = (int)(context.localUtil.CToN( cgiGet( "GRID_Rows"), ".", ","));
            GxWebStd.gx_hidden_field( context, "GRID_Rows", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid_Rows), 6, 0, ".", "")));
            Gridpaginationbar_Selectedpage = cgiGet( "GRIDPAGINATIONBAR_Selectedpage");
            Gridpaginationbar_Rowsperpageselectedvalue = (int)(context.localUtil.CToN( cgiGet( "GRIDPAGINATIONBAR_Rowsperpageselectedvalue"), ".", ","));
            Ddo_grid_Activeeventkey = cgiGet( "DDO_GRID_Activeeventkey");
            Ddo_grid_Selectedvalue_get = cgiGet( "DDO_GRID_Selectedvalue_get");
            Ddo_grid_Selectedcolumn = cgiGet( "DDO_GRID_Selectedcolumn");
            Ddo_grid_Filteredtext_get = cgiGet( "DDO_GRID_Filteredtext_get");
            Ddo_grid_Filteredtextto_get = cgiGet( "DDO_GRID_Filteredtextto_get");
            Ddo_agexport_Activeeventkey = cgiGet( "DDO_AGEXPORT_Activeeventkey");
            /* Read variables values. */
            cmbavDynamicfiltersselector1.Name = cmbavDynamicfiltersselector1_Internalname;
            cmbavDynamicfiltersselector1.CurrentValue = cgiGet( cmbavDynamicfiltersselector1_Internalname);
            AV15DynamicFiltersSelector1 = cgiGet( cmbavDynamicfiltersselector1_Internalname);
            AssignAttri("", false, "AV15DynamicFiltersSelector1", AV15DynamicFiltersSelector1);
            cmbavDynamicfiltersoperator1.Name = cmbavDynamicfiltersoperator1_Internalname;
            cmbavDynamicfiltersoperator1.CurrentValue = cgiGet( cmbavDynamicfiltersoperator1_Internalname);
            AV16DynamicFiltersOperator1 = (short)(NumberUtil.Val( cgiGet( cmbavDynamicfiltersoperator1_Internalname), "."));
            AssignAttri("", false, "AV16DynamicFiltersOperator1", StringUtil.LTrimStr( (decimal)(AV16DynamicFiltersOperator1), 4, 0));
            AV17PoConcDsc1 = cgiGet( edtavPoconcdsc1_Internalname);
            AssignAttri("", false, "AV17PoConcDsc1", AV17PoConcDsc1);
            cmbavDynamicfiltersselector2.Name = cmbavDynamicfiltersselector2_Internalname;
            cmbavDynamicfiltersselector2.CurrentValue = cgiGet( cmbavDynamicfiltersselector2_Internalname);
            AV19DynamicFiltersSelector2 = cgiGet( cmbavDynamicfiltersselector2_Internalname);
            AssignAttri("", false, "AV19DynamicFiltersSelector2", AV19DynamicFiltersSelector2);
            cmbavDynamicfiltersoperator2.Name = cmbavDynamicfiltersoperator2_Internalname;
            cmbavDynamicfiltersoperator2.CurrentValue = cgiGet( cmbavDynamicfiltersoperator2_Internalname);
            AV20DynamicFiltersOperator2 = (short)(NumberUtil.Val( cgiGet( cmbavDynamicfiltersoperator2_Internalname), "."));
            AssignAttri("", false, "AV20DynamicFiltersOperator2", StringUtil.LTrimStr( (decimal)(AV20DynamicFiltersOperator2), 4, 0));
            AV21PoConcDsc2 = cgiGet( edtavPoconcdsc2_Internalname);
            AssignAttri("", false, "AV21PoConcDsc2", AV21PoConcDsc2);
            cmbavDynamicfiltersselector3.Name = cmbavDynamicfiltersselector3_Internalname;
            cmbavDynamicfiltersselector3.CurrentValue = cgiGet( cmbavDynamicfiltersselector3_Internalname);
            AV23DynamicFiltersSelector3 = cgiGet( cmbavDynamicfiltersselector3_Internalname);
            AssignAttri("", false, "AV23DynamicFiltersSelector3", AV23DynamicFiltersSelector3);
            cmbavDynamicfiltersoperator3.Name = cmbavDynamicfiltersoperator3_Internalname;
            cmbavDynamicfiltersoperator3.CurrentValue = cgiGet( cmbavDynamicfiltersoperator3_Internalname);
            AV24DynamicFiltersOperator3 = (short)(NumberUtil.Val( cgiGet( cmbavDynamicfiltersoperator3_Internalname), "."));
            AssignAttri("", false, "AV24DynamicFiltersOperator3", StringUtil.LTrimStr( (decimal)(AV24DynamicFiltersOperator3), 4, 0));
            AV25PoConcDsc3 = cgiGet( edtavPoconcdsc3_Internalname);
            AssignAttri("", false, "AV25PoConcDsc3", AV25PoConcDsc3);
            /* Read subfile selected row values. */
            /* Read hidden variables. */
            GXKey = Crypto.GetSiteKey( );
            /* Check if conditions changed and reset current page numbers */
            if ( StringUtil.StrCmp(cgiGet( "GXH_vDYNAMICFILTERSSELECTOR1"), AV15DynamicFiltersSelector1) != 0 )
            {
               GRID_nFirstRecordOnPage = 0;
            }
            if ( ( context.localUtil.CToN( cgiGet( "GXH_vDYNAMICFILTERSOPERATOR1"), ".", ",") != Convert.ToDecimal( AV16DynamicFiltersOperator1 )) )
            {
               GRID_nFirstRecordOnPage = 0;
            }
            if ( StringUtil.StrCmp(cgiGet( "GXH_vPOCONCDSC1"), AV17PoConcDsc1) != 0 )
            {
               GRID_nFirstRecordOnPage = 0;
            }
            if ( StringUtil.StrCmp(cgiGet( "GXH_vDYNAMICFILTERSSELECTOR2"), AV19DynamicFiltersSelector2) != 0 )
            {
               GRID_nFirstRecordOnPage = 0;
            }
            if ( ( context.localUtil.CToN( cgiGet( "GXH_vDYNAMICFILTERSOPERATOR2"), ".", ",") != Convert.ToDecimal( AV20DynamicFiltersOperator2 )) )
            {
               GRID_nFirstRecordOnPage = 0;
            }
            if ( StringUtil.StrCmp(cgiGet( "GXH_vPOCONCDSC2"), AV21PoConcDsc2) != 0 )
            {
               GRID_nFirstRecordOnPage = 0;
            }
            if ( StringUtil.StrCmp(cgiGet( "GXH_vDYNAMICFILTERSSELECTOR3"), AV23DynamicFiltersSelector3) != 0 )
            {
               GRID_nFirstRecordOnPage = 0;
            }
            if ( ( context.localUtil.CToN( cgiGet( "GXH_vDYNAMICFILTERSOPERATOR3"), ".", ",") != Convert.ToDecimal( AV24DynamicFiltersOperator3 )) )
            {
               GRID_nFirstRecordOnPage = 0;
            }
            if ( StringUtil.StrCmp(cgiGet( "GXH_vPOCONCDSC3"), AV25PoConcDsc3) != 0 )
            {
               GRID_nFirstRecordOnPage = 0;
            }
         }
         else
         {
            dynload_actions( ) ;
         }
      }

      protected void GXStart( )
      {
         /* Execute user event: Start */
         E24272 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
      }

      protected void E24272( )
      {
         /* Start Routine */
         returnInSub = false;
         subGrid_Rows = 10;
         GxWebStd.gx_hidden_field( context, "GRID_Rows", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid_Rows), 6, 0, ".", "")));
         Grid_empowerer_Gridinternalname = subGrid_Internalname;
         ucGrid_empowerer.SendProperty(context, "", false, Grid_empowerer_Internalname, "GridInternalName", Grid_empowerer_Gridinternalname);
         lblJsdynamicfilters_Caption = "";
         AssignProp("", false, lblJsdynamicfilters_Internalname, "Caption", lblJsdynamicfilters_Caption, true);
         AV15DynamicFiltersSelector1 = "POCONCDSC";
         AssignAttri("", false, "AV15DynamicFiltersSelector1", AV15DynamicFiltersSelector1);
         /* Execute user subroutine: 'ENABLEDYNAMICFILTERS1' */
         S112 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
         AV19DynamicFiltersSelector2 = "POCONCDSC";
         AssignAttri("", false, "AV19DynamicFiltersSelector2", AV19DynamicFiltersSelector2);
         /* Execute user subroutine: 'ENABLEDYNAMICFILTERS2' */
         S122 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
         AV23DynamicFiltersSelector3 = "POCONCDSC";
         AssignAttri("", false, "AV23DynamicFiltersSelector3", AV23DynamicFiltersSelector3);
         /* Execute user subroutine: 'ENABLEDYNAMICFILTERS3' */
         S132 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
         imgAdddynamicfilters1_Jsonclick = StringUtil.Format( "WWPDynFilterShow_AL('%1', 2, 0)", divTabledynamicfilters_Internalname, "", "", "", "", "", "", "", "");
         AssignProp("", false, imgAdddynamicfilters1_Internalname, "Jsonclick", imgAdddynamicfilters1_Jsonclick, true);
         imgRemovedynamicfilters1_Jsonclick = StringUtil.Format( "WWPDynFilterHideLast_AL('%1', 3, 0)", divTabledynamicfilters_Internalname, "", "", "", "", "", "", "", "");
         AssignProp("", false, imgRemovedynamicfilters1_Internalname, "Jsonclick", imgRemovedynamicfilters1_Jsonclick, true);
         imgAdddynamicfilters2_Jsonclick = StringUtil.Format( "WWPDynFilterShow_AL('%1', 3, 0)", divTabledynamicfilters_Internalname, "", "", "", "", "", "", "", "");
         AssignProp("", false, imgAdddynamicfilters2_Internalname, "Jsonclick", imgAdddynamicfilters2_Jsonclick, true);
         imgRemovedynamicfilters2_Jsonclick = StringUtil.Format( "WWPDynFilterHideLast_AL('%1', 3, 0)", divTabledynamicfilters_Internalname, "", "", "", "", "", "", "", "");
         AssignProp("", false, imgRemovedynamicfilters2_Internalname, "Jsonclick", imgRemovedynamicfilters2_Jsonclick, true);
         imgRemovedynamicfilters3_Jsonclick = StringUtil.Format( "WWPDynFilterHideLast_AL('%1', 3, 0)", divTabledynamicfilters_Internalname, "", "", "", "", "", "", "", "");
         AssignProp("", false, imgRemovedynamicfilters3_Internalname, "Jsonclick", imgRemovedynamicfilters3_Jsonclick, true);
         Ddo_agexport_Titlecontrolidtoreplace = bttBtnagexport_Internalname;
         ucDdo_agexport.SendProperty(context, "", false, Ddo_agexport_Internalname, "TitleControlIdToReplace", Ddo_agexport_Titlecontrolidtoreplace);
         AV45AGExportData = new GXBaseCollection<GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTDropDownOptionsData_Item>( context, "Item", "");
         AV46AGExportDataItem = new GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTDropDownOptionsData_Item(context);
         AV46AGExportDataItem.gxTpr_Title = "PDF";
         AV46AGExportDataItem.gxTpr_Icon = context.convertURL( (string)(context.GetImagePath( "776fb79c-a0a1-4302-b5e5-d773dbe1a297", "", context.GetTheme( ))));
         AV46AGExportDataItem.gxTpr_Eventkey = "ExportReport";
         AV46AGExportDataItem.gxTpr_Isdivider = false;
         AV45AGExportData.Add(AV46AGExportDataItem, 0);
         AV46AGExportDataItem = new GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTDropDownOptionsData_Item(context);
         AV46AGExportDataItem.gxTpr_Title = "Excel";
         AV46AGExportDataItem.gxTpr_Icon = context.convertURL( (string)(context.GetImagePath( "da69a816-fd11-445b-8aaf-1a2f7f1acc93", "", context.GetTheme( ))));
         AV46AGExportDataItem.gxTpr_Eventkey = "Export";
         AV46AGExportDataItem.gxTpr_Isdivider = false;
         AV45AGExportData.Add(AV46AGExportDataItem, 0);
         Ddo_grid_Gridinternalname = subGrid_Internalname;
         ucDdo_grid.SendProperty(context, "", false, Ddo_grid_Internalname, "GridInternalName", Ddo_grid_Gridinternalname);
         Form.Caption = " Conceptos de Ordenes de Produccion";
         AssignProp("", false, "FORM", "Caption", Form.Caption, true);
         /* Execute user subroutine: 'PREPARETRANSACTION' */
         S142 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
         /* Execute user subroutine: 'LOADGRIDSTATE' */
         S152 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
         if ( AV13OrderedBy < 1 )
         {
            AV13OrderedBy = 1;
            AssignAttri("", false, "AV13OrderedBy", StringUtil.LTrimStr( (decimal)(AV13OrderedBy), 4, 0));
            /* Execute user subroutine: 'SETDDOSORTEDSTATUS' */
            S162 ();
            if ( returnInSub )
            {
               returnInSub = true;
               if (true) return;
            }
         }
         GXt_SdtDVB_SDTDropDownOptionsTitleSettingsIcons1 = AV39DDO_TitleSettingsIcons;
         new GeneXus.Programs.wwpbaseobjects.getwwptitlesettingsicons(context ).execute( out  GXt_SdtDVB_SDTDropDownOptionsTitleSettingsIcons1) ;
         AV39DDO_TitleSettingsIcons = GXt_SdtDVB_SDTDropDownOptionsTitleSettingsIcons1;
         Gridpaginationbar_Rowsperpageselectedvalue = subGrid_Rows;
         ucGridpaginationbar.SendProperty(context, "", false, Gridpaginationbar_Internalname, "RowsPerPageSelectedValue", StringUtil.LTrimStr( (decimal)(Gridpaginationbar_Rowsperpageselectedvalue), 9, 0));
      }

      protected void E25272( )
      {
         if ( gx_refresh_fired )
         {
            return  ;
         }
         gx_refresh_fired = true;
         /* Refresh Routine */
         returnInSub = false;
         new GeneXus.Programs.wwpbaseobjects.loadwwpcontext(context ).execute( out  AV6WWPContext) ;
         /* Execute user subroutine: 'SAVEGRIDSTATE' */
         S172 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
         AV41GridCurrentPage = subGrid_fnc_Currentpage( );
         AssignAttri("", false, "AV41GridCurrentPage", StringUtil.LTrimStr( (decimal)(AV41GridCurrentPage), 10, 0));
         AV42GridPageCount = subGrid_fnc_Pagecount( );
         AssignAttri("", false, "AV42GridPageCount", StringUtil.LTrimStr( (decimal)(AV42GridPageCount), 10, 0));
         GXt_char2 = AV43GridAppliedFilters;
         new GeneXus.Programs.wwpbaseobjects.wwp_getappliedfiltersdescription(context ).execute(  AV51Pgmname, out  GXt_char2) ;
         AV43GridAppliedFilters = GXt_char2;
         AssignAttri("", false, "AV43GridAppliedFilters", AV43GridAppliedFilters);
         AV52Produccion_conceptosordenesproduccionwwds_1_dynamicfiltersselector1 = AV15DynamicFiltersSelector1;
         AV53Produccion_conceptosordenesproduccionwwds_2_dynamicfiltersoperator1 = AV16DynamicFiltersOperator1;
         AV54Produccion_conceptosordenesproduccionwwds_3_poconcdsc1 = AV17PoConcDsc1;
         AV55Produccion_conceptosordenesproduccionwwds_4_dynamicfiltersenabled2 = AV18DynamicFiltersEnabled2;
         AV56Produccion_conceptosordenesproduccionwwds_5_dynamicfiltersselector2 = AV19DynamicFiltersSelector2;
         AV57Produccion_conceptosordenesproduccionwwds_6_dynamicfiltersoperator2 = AV20DynamicFiltersOperator2;
         AV58Produccion_conceptosordenesproduccionwwds_7_poconcdsc2 = AV21PoConcDsc2;
         AV59Produccion_conceptosordenesproduccionwwds_8_dynamicfiltersenabled3 = AV22DynamicFiltersEnabled3;
         AV60Produccion_conceptosordenesproduccionwwds_9_dynamicfiltersselector3 = AV23DynamicFiltersSelector3;
         AV61Produccion_conceptosordenesproduccionwwds_10_dynamicfiltersoperator3 = AV24DynamicFiltersOperator3;
         AV62Produccion_conceptosordenesproduccionwwds_11_poconcdsc3 = AV25PoConcDsc3;
         AV63Produccion_conceptosordenesproduccionwwds_12_tfpoconccod = AV31TFPoConcCod;
         AV64Produccion_conceptosordenesproduccionwwds_13_tfpoconccod_to = AV32TFPoConcCod_To;
         AV65Produccion_conceptosordenesproduccionwwds_14_tfpoconcdsc = AV33TFPoConcDsc;
         AV66Produccion_conceptosordenesproduccionwwds_15_tfpoconcdsc_sel = AV34TFPoConcDsc_Sel;
         AV67Produccion_conceptosordenesproduccionwwds_16_tfpoconctip_sels = AV48TFPoConcTip_Sels;
         AV68Produccion_conceptosordenesproduccionwwds_17_tfpoconcsts_sels = AV38TFPoConcSts_Sels;
         /*  Sending Event outputs  */
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV10GridState", AV10GridState);
      }

      protected void E11272( )
      {
         /* Gridpaginationbar_Changepage Routine */
         returnInSub = false;
         if ( StringUtil.StrCmp(Gridpaginationbar_Selectedpage, "Previous") == 0 )
         {
            subgrid_previouspage( ) ;
         }
         else if ( StringUtil.StrCmp(Gridpaginationbar_Selectedpage, "Next") == 0 )
         {
            subgrid_nextpage( ) ;
         }
         else
         {
            AV40PageToGo = (int)(NumberUtil.Val( Gridpaginationbar_Selectedpage, "."));
            subgrid_gotopage( AV40PageToGo) ;
         }
      }

      protected void E12272( )
      {
         /* Gridpaginationbar_Changerowsperpage Routine */
         returnInSub = false;
         subGrid_Rows = Gridpaginationbar_Rowsperpageselectedvalue;
         GxWebStd.gx_hidden_field( context, "GRID_Rows", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid_Rows), 6, 0, ".", "")));
         subgrid_firstpage( ) ;
         /*  Sending Event outputs  */
      }

      protected void E14272( )
      {
         /* Ddo_grid_Onoptionclicked Routine */
         returnInSub = false;
         if ( ( StringUtil.StrCmp(Ddo_grid_Activeeventkey, "<#OrderASC#>") == 0 ) || ( StringUtil.StrCmp(Ddo_grid_Activeeventkey, "<#OrderDSC#>") == 0 ) )
         {
            AV13OrderedBy = (short)(NumberUtil.Val( Ddo_grid_Selectedvalue_get, "."));
            AssignAttri("", false, "AV13OrderedBy", StringUtil.LTrimStr( (decimal)(AV13OrderedBy), 4, 0));
            AV14OrderedDsc = ((StringUtil.StrCmp(Ddo_grid_Activeeventkey, "<#OrderDSC#>")==0) ? true : false);
            AssignAttri("", false, "AV14OrderedDsc", AV14OrderedDsc);
            /* Execute user subroutine: 'SETDDOSORTEDSTATUS' */
            S162 ();
            if ( returnInSub )
            {
               returnInSub = true;
               if (true) return;
            }
            subgrid_firstpage( ) ;
         }
         else if ( StringUtil.StrCmp(Ddo_grid_Activeeventkey, "<#Filter#>") == 0 )
         {
            if ( StringUtil.StrCmp(Ddo_grid_Selectedcolumn, "PoConcCod") == 0 )
            {
               AV31TFPoConcCod = (int)(NumberUtil.Val( Ddo_grid_Filteredtext_get, "."));
               AssignAttri("", false, "AV31TFPoConcCod", StringUtil.LTrimStr( (decimal)(AV31TFPoConcCod), 6, 0));
               AV32TFPoConcCod_To = (int)(NumberUtil.Val( Ddo_grid_Filteredtextto_get, "."));
               AssignAttri("", false, "AV32TFPoConcCod_To", StringUtil.LTrimStr( (decimal)(AV32TFPoConcCod_To), 6, 0));
            }
            else if ( StringUtil.StrCmp(Ddo_grid_Selectedcolumn, "PoConcDsc") == 0 )
            {
               AV33TFPoConcDsc = Ddo_grid_Filteredtext_get;
               AssignAttri("", false, "AV33TFPoConcDsc", AV33TFPoConcDsc);
               AV34TFPoConcDsc_Sel = Ddo_grid_Selectedvalue_get;
               AssignAttri("", false, "AV34TFPoConcDsc_Sel", AV34TFPoConcDsc_Sel);
            }
            else if ( StringUtil.StrCmp(Ddo_grid_Selectedcolumn, "PoConcTip") == 0 )
            {
               AV47TFPoConcTip_SelsJson = Ddo_grid_Selectedvalue_get;
               AssignAttri("", false, "AV47TFPoConcTip_SelsJson", AV47TFPoConcTip_SelsJson);
               AV48TFPoConcTip_Sels.FromJSonString(AV47TFPoConcTip_SelsJson, null);
            }
            else if ( StringUtil.StrCmp(Ddo_grid_Selectedcolumn, "PoConcSts") == 0 )
            {
               AV37TFPoConcSts_SelsJson = Ddo_grid_Selectedvalue_get;
               AssignAttri("", false, "AV37TFPoConcSts_SelsJson", AV37TFPoConcSts_SelsJson);
               AV38TFPoConcSts_Sels.FromJSonString(StringUtil.StringReplace( AV37TFPoConcSts_SelsJson, "\"", ""), null);
            }
            subgrid_firstpage( ) ;
         }
         /*  Sending Event outputs  */
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV48TFPoConcTip_Sels", AV48TFPoConcTip_Sels);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV38TFPoConcSts_Sels", AV38TFPoConcSts_Sels);
      }

      private void E26272( )
      {
         /* Grid_Load Routine */
         returnInSub = false;
         cmbavGridactions.removeAllItems();
         cmbavGridactions.addItem("0", ";fa fa-bars", 0);
         cmbavGridactions.addItem("1", StringUtil.Format( "%1;%2", "Modificar", "fa fa-pen", "", "", "", "", "", "", ""), 0);
         cmbavGridactions.addItem("2", StringUtil.Format( "%1;%2", "Eliminar", "fa fa-times", "", "", "", "", "", "", ""), 0);
         GXKey = Crypto.GetSiteKey( );
         GXEncryptionTmp = "produccion.conceptosordenesproduccion.aspx"+UrlEncode(StringUtil.RTrim("DSP")) + "," + UrlEncode(StringUtil.LTrimStr(A313PoConcCod,6,0));
         edtPoConcDsc_Link = formatLink("produccion.conceptosordenesproduccion.aspx") + "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey);
         /* Load Method */
         if ( wbStart != -1 )
         {
            wbStart = 101;
         }
         sendrow_1012( ) ;
         GRID_nCurrentRecord = (long)(GRID_nCurrentRecord+1);
         if ( isFullAjaxMode( ) && ! bGXsfl_101_Refreshing )
         {
            DoAjaxLoad(101, GridRow);
         }
         /*  Sending Event outputs  */
         cmbavGridactions.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV44GridActions), 4, 0));
      }

      protected void E19272( )
      {
         /* 'AddDynamicFilters1' Routine */
         returnInSub = false;
         AV18DynamicFiltersEnabled2 = true;
         AssignAttri("", false, "AV18DynamicFiltersEnabled2", AV18DynamicFiltersEnabled2);
         imgAdddynamicfilters1_Visible = 0;
         AssignProp("", false, imgAdddynamicfilters1_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(imgAdddynamicfilters1_Visible), 5, 0), true);
         imgRemovedynamicfilters1_Visible = 1;
         AssignProp("", false, imgRemovedynamicfilters1_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(imgRemovedynamicfilters1_Visible), 5, 0), true);
         /*  Sending Event outputs  */
      }

      protected void E15272( )
      {
         /* 'RemoveDynamicFilters1' Routine */
         returnInSub = false;
         AV26DynamicFiltersRemoving = true;
         AssignAttri("", false, "AV26DynamicFiltersRemoving", AV26DynamicFiltersRemoving);
         AV27DynamicFiltersIgnoreFirst = true;
         AssignAttri("", false, "AV27DynamicFiltersIgnoreFirst", AV27DynamicFiltersIgnoreFirst);
         /* Execute user subroutine: 'SAVEDYNFILTERSSTATE' */
         S182 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
         /* Execute user subroutine: 'RESETDYNFILTERS' */
         S192 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
         /* Execute user subroutine: 'LOADDYNFILTERSSTATE' */
         S202 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
         AV26DynamicFiltersRemoving = false;
         AssignAttri("", false, "AV26DynamicFiltersRemoving", AV26DynamicFiltersRemoving);
         AV27DynamicFiltersIgnoreFirst = false;
         AssignAttri("", false, "AV27DynamicFiltersIgnoreFirst", AV27DynamicFiltersIgnoreFirst);
         gxgrGrid_refresh( subGrid_Rows, AV15DynamicFiltersSelector1, AV16DynamicFiltersOperator1, AV17PoConcDsc1, AV19DynamicFiltersSelector2, AV20DynamicFiltersOperator2, AV21PoConcDsc2, AV23DynamicFiltersSelector3, AV24DynamicFiltersOperator3, AV25PoConcDsc3, AV51Pgmname, AV18DynamicFiltersEnabled2, AV22DynamicFiltersEnabled3, AV31TFPoConcCod, AV32TFPoConcCod_To, AV33TFPoConcDsc, AV34TFPoConcDsc_Sel, AV48TFPoConcTip_Sels, AV38TFPoConcSts_Sels, AV13OrderedBy, AV14OrderedDsc, AV10GridState, AV27DynamicFiltersIgnoreFirst, AV26DynamicFiltersRemoving) ;
         /*  Sending Event outputs  */
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV10GridState", AV10GridState);
         cmbavDynamicfiltersselector2.CurrentValue = StringUtil.RTrim( AV19DynamicFiltersSelector2);
         AssignProp("", false, cmbavDynamicfiltersselector2_Internalname, "Values", cmbavDynamicfiltersselector2.ToJavascriptSource(), true);
         cmbavDynamicfiltersoperator2.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV20DynamicFiltersOperator2), 4, 0));
         AssignProp("", false, cmbavDynamicfiltersoperator2_Internalname, "Values", cmbavDynamicfiltersoperator2.ToJavascriptSource(), true);
         cmbavDynamicfiltersselector3.CurrentValue = StringUtil.RTrim( AV23DynamicFiltersSelector3);
         AssignProp("", false, cmbavDynamicfiltersselector3_Internalname, "Values", cmbavDynamicfiltersselector3.ToJavascriptSource(), true);
         cmbavDynamicfiltersoperator3.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV24DynamicFiltersOperator3), 4, 0));
         AssignProp("", false, cmbavDynamicfiltersoperator3_Internalname, "Values", cmbavDynamicfiltersoperator3.ToJavascriptSource(), true);
         cmbavDynamicfiltersselector1.CurrentValue = StringUtil.RTrim( AV15DynamicFiltersSelector1);
         AssignProp("", false, cmbavDynamicfiltersselector1_Internalname, "Values", cmbavDynamicfiltersselector1.ToJavascriptSource(), true);
         cmbavDynamicfiltersoperator1.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV16DynamicFiltersOperator1), 4, 0));
         AssignProp("", false, cmbavDynamicfiltersoperator1_Internalname, "Values", cmbavDynamicfiltersoperator1.ToJavascriptSource(), true);
      }

      protected void E20272( )
      {
         /* Dynamicfiltersselector1_Click Routine */
         returnInSub = false;
         /* Execute user subroutine: 'ENABLEDYNAMICFILTERS1' */
         S112 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
         /*  Sending Event outputs  */
      }

      protected void E21272( )
      {
         /* 'AddDynamicFilters2' Routine */
         returnInSub = false;
         AV22DynamicFiltersEnabled3 = true;
         AssignAttri("", false, "AV22DynamicFiltersEnabled3", AV22DynamicFiltersEnabled3);
         imgAdddynamicfilters2_Visible = 0;
         AssignProp("", false, imgAdddynamicfilters2_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(imgAdddynamicfilters2_Visible), 5, 0), true);
         imgRemovedynamicfilters2_Visible = 1;
         AssignProp("", false, imgRemovedynamicfilters2_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(imgRemovedynamicfilters2_Visible), 5, 0), true);
         /*  Sending Event outputs  */
      }

      protected void E16272( )
      {
         /* 'RemoveDynamicFilters2' Routine */
         returnInSub = false;
         AV26DynamicFiltersRemoving = true;
         AssignAttri("", false, "AV26DynamicFiltersRemoving", AV26DynamicFiltersRemoving);
         AV18DynamicFiltersEnabled2 = false;
         AssignAttri("", false, "AV18DynamicFiltersEnabled2", AV18DynamicFiltersEnabled2);
         /* Execute user subroutine: 'SAVEDYNFILTERSSTATE' */
         S182 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
         /* Execute user subroutine: 'RESETDYNFILTERS' */
         S192 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
         /* Execute user subroutine: 'LOADDYNFILTERSSTATE' */
         S202 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
         AV26DynamicFiltersRemoving = false;
         AssignAttri("", false, "AV26DynamicFiltersRemoving", AV26DynamicFiltersRemoving);
         gxgrGrid_refresh( subGrid_Rows, AV15DynamicFiltersSelector1, AV16DynamicFiltersOperator1, AV17PoConcDsc1, AV19DynamicFiltersSelector2, AV20DynamicFiltersOperator2, AV21PoConcDsc2, AV23DynamicFiltersSelector3, AV24DynamicFiltersOperator3, AV25PoConcDsc3, AV51Pgmname, AV18DynamicFiltersEnabled2, AV22DynamicFiltersEnabled3, AV31TFPoConcCod, AV32TFPoConcCod_To, AV33TFPoConcDsc, AV34TFPoConcDsc_Sel, AV48TFPoConcTip_Sels, AV38TFPoConcSts_Sels, AV13OrderedBy, AV14OrderedDsc, AV10GridState, AV27DynamicFiltersIgnoreFirst, AV26DynamicFiltersRemoving) ;
         /*  Sending Event outputs  */
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV10GridState", AV10GridState);
         cmbavDynamicfiltersselector2.CurrentValue = StringUtil.RTrim( AV19DynamicFiltersSelector2);
         AssignProp("", false, cmbavDynamicfiltersselector2_Internalname, "Values", cmbavDynamicfiltersselector2.ToJavascriptSource(), true);
         cmbavDynamicfiltersoperator2.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV20DynamicFiltersOperator2), 4, 0));
         AssignProp("", false, cmbavDynamicfiltersoperator2_Internalname, "Values", cmbavDynamicfiltersoperator2.ToJavascriptSource(), true);
         cmbavDynamicfiltersselector3.CurrentValue = StringUtil.RTrim( AV23DynamicFiltersSelector3);
         AssignProp("", false, cmbavDynamicfiltersselector3_Internalname, "Values", cmbavDynamicfiltersselector3.ToJavascriptSource(), true);
         cmbavDynamicfiltersoperator3.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV24DynamicFiltersOperator3), 4, 0));
         AssignProp("", false, cmbavDynamicfiltersoperator3_Internalname, "Values", cmbavDynamicfiltersoperator3.ToJavascriptSource(), true);
         cmbavDynamicfiltersselector1.CurrentValue = StringUtil.RTrim( AV15DynamicFiltersSelector1);
         AssignProp("", false, cmbavDynamicfiltersselector1_Internalname, "Values", cmbavDynamicfiltersselector1.ToJavascriptSource(), true);
         cmbavDynamicfiltersoperator1.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV16DynamicFiltersOperator1), 4, 0));
         AssignProp("", false, cmbavDynamicfiltersoperator1_Internalname, "Values", cmbavDynamicfiltersoperator1.ToJavascriptSource(), true);
      }

      protected void E22272( )
      {
         /* Dynamicfiltersselector2_Click Routine */
         returnInSub = false;
         /* Execute user subroutine: 'ENABLEDYNAMICFILTERS2' */
         S122 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
         /*  Sending Event outputs  */
      }

      protected void E17272( )
      {
         /* 'RemoveDynamicFilters3' Routine */
         returnInSub = false;
         AV26DynamicFiltersRemoving = true;
         AssignAttri("", false, "AV26DynamicFiltersRemoving", AV26DynamicFiltersRemoving);
         AV22DynamicFiltersEnabled3 = false;
         AssignAttri("", false, "AV22DynamicFiltersEnabled3", AV22DynamicFiltersEnabled3);
         /* Execute user subroutine: 'SAVEDYNFILTERSSTATE' */
         S182 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
         /* Execute user subroutine: 'RESETDYNFILTERS' */
         S192 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
         /* Execute user subroutine: 'LOADDYNFILTERSSTATE' */
         S202 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
         AV26DynamicFiltersRemoving = false;
         AssignAttri("", false, "AV26DynamicFiltersRemoving", AV26DynamicFiltersRemoving);
         gxgrGrid_refresh( subGrid_Rows, AV15DynamicFiltersSelector1, AV16DynamicFiltersOperator1, AV17PoConcDsc1, AV19DynamicFiltersSelector2, AV20DynamicFiltersOperator2, AV21PoConcDsc2, AV23DynamicFiltersSelector3, AV24DynamicFiltersOperator3, AV25PoConcDsc3, AV51Pgmname, AV18DynamicFiltersEnabled2, AV22DynamicFiltersEnabled3, AV31TFPoConcCod, AV32TFPoConcCod_To, AV33TFPoConcDsc, AV34TFPoConcDsc_Sel, AV48TFPoConcTip_Sels, AV38TFPoConcSts_Sels, AV13OrderedBy, AV14OrderedDsc, AV10GridState, AV27DynamicFiltersIgnoreFirst, AV26DynamicFiltersRemoving) ;
         /*  Sending Event outputs  */
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV10GridState", AV10GridState);
         cmbavDynamicfiltersselector2.CurrentValue = StringUtil.RTrim( AV19DynamicFiltersSelector2);
         AssignProp("", false, cmbavDynamicfiltersselector2_Internalname, "Values", cmbavDynamicfiltersselector2.ToJavascriptSource(), true);
         cmbavDynamicfiltersoperator2.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV20DynamicFiltersOperator2), 4, 0));
         AssignProp("", false, cmbavDynamicfiltersoperator2_Internalname, "Values", cmbavDynamicfiltersoperator2.ToJavascriptSource(), true);
         cmbavDynamicfiltersselector3.CurrentValue = StringUtil.RTrim( AV23DynamicFiltersSelector3);
         AssignProp("", false, cmbavDynamicfiltersselector3_Internalname, "Values", cmbavDynamicfiltersselector3.ToJavascriptSource(), true);
         cmbavDynamicfiltersoperator3.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV24DynamicFiltersOperator3), 4, 0));
         AssignProp("", false, cmbavDynamicfiltersoperator3_Internalname, "Values", cmbavDynamicfiltersoperator3.ToJavascriptSource(), true);
         cmbavDynamicfiltersselector1.CurrentValue = StringUtil.RTrim( AV15DynamicFiltersSelector1);
         AssignProp("", false, cmbavDynamicfiltersselector1_Internalname, "Values", cmbavDynamicfiltersselector1.ToJavascriptSource(), true);
         cmbavDynamicfiltersoperator1.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV16DynamicFiltersOperator1), 4, 0));
         AssignProp("", false, cmbavDynamicfiltersoperator1_Internalname, "Values", cmbavDynamicfiltersoperator1.ToJavascriptSource(), true);
      }

      protected void E23272( )
      {
         /* Dynamicfiltersselector3_Click Routine */
         returnInSub = false;
         /* Execute user subroutine: 'ENABLEDYNAMICFILTERS3' */
         S132 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
         /*  Sending Event outputs  */
      }

      protected void E27272( )
      {
         /* Gridactions_Click Routine */
         returnInSub = false;
         if ( AV44GridActions == 1 )
         {
            /* Execute user subroutine: 'DO UPDATE' */
            S212 ();
            if ( returnInSub )
            {
               returnInSub = true;
               if (true) return;
            }
         }
         else if ( AV44GridActions == 2 )
         {
            /* Execute user subroutine: 'DO DELETE' */
            S222 ();
            if ( returnInSub )
            {
               returnInSub = true;
               if (true) return;
            }
         }
         AV44GridActions = 0;
         AssignAttri("", false, cmbavGridactions_Internalname, StringUtil.LTrimStr( (decimal)(AV44GridActions), 4, 0));
         /*  Sending Event outputs  */
         cmbavGridactions.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV44GridActions), 4, 0));
         AssignProp("", false, cmbavGridactions_Internalname, "Values", cmbavGridactions.ToJavascriptSource(), true);
      }

      protected void E18272( )
      {
         /* 'DoInsert' Routine */
         returnInSub = false;
         GXKey = Crypto.GetSiteKey( );
         GXEncryptionTmp = "produccion.conceptosordenesproduccion.aspx"+UrlEncode(StringUtil.RTrim("INS")) + "," + UrlEncode(StringUtil.LTrimStr(0,1,0));
         CallWebObject(formatLink("produccion.conceptosordenesproduccion.aspx") + "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey));
         context.wjLocDisableFrm = 1;
      }

      protected void E13272( )
      {
         /* Ddo_agexport_Onoptionclicked Routine */
         returnInSub = false;
         if ( StringUtil.StrCmp(Ddo_agexport_Activeeventkey, "ExportReport") == 0 )
         {
            /* Execute user subroutine: 'DOEXPORTREPORT' */
            S232 ();
            if ( returnInSub )
            {
               returnInSub = true;
               if (true) return;
            }
         }
         else if ( StringUtil.StrCmp(Ddo_agexport_Activeeventkey, "Export") == 0 )
         {
            /* Execute user subroutine: 'DOEXPORT' */
            S242 ();
            if ( returnInSub )
            {
               returnInSub = true;
               if (true) return;
            }
         }
         /*  Sending Event outputs  */
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV10GridState", AV10GridState);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV48TFPoConcTip_Sels", AV48TFPoConcTip_Sels);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV38TFPoConcSts_Sels", AV38TFPoConcSts_Sels);
         cmbavDynamicfiltersselector1.CurrentValue = StringUtil.RTrim( AV15DynamicFiltersSelector1);
         AssignProp("", false, cmbavDynamicfiltersselector1_Internalname, "Values", cmbavDynamicfiltersselector1.ToJavascriptSource(), true);
         cmbavDynamicfiltersoperator1.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV16DynamicFiltersOperator1), 4, 0));
         AssignProp("", false, cmbavDynamicfiltersoperator1_Internalname, "Values", cmbavDynamicfiltersoperator1.ToJavascriptSource(), true);
         cmbavDynamicfiltersselector2.CurrentValue = StringUtil.RTrim( AV19DynamicFiltersSelector2);
         AssignProp("", false, cmbavDynamicfiltersselector2_Internalname, "Values", cmbavDynamicfiltersselector2.ToJavascriptSource(), true);
         cmbavDynamicfiltersoperator2.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV20DynamicFiltersOperator2), 4, 0));
         AssignProp("", false, cmbavDynamicfiltersoperator2_Internalname, "Values", cmbavDynamicfiltersoperator2.ToJavascriptSource(), true);
         cmbavDynamicfiltersselector3.CurrentValue = StringUtil.RTrim( AV23DynamicFiltersSelector3);
         AssignProp("", false, cmbavDynamicfiltersselector3_Internalname, "Values", cmbavDynamicfiltersselector3.ToJavascriptSource(), true);
         cmbavDynamicfiltersoperator3.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV24DynamicFiltersOperator3), 4, 0));
         AssignProp("", false, cmbavDynamicfiltersoperator3_Internalname, "Values", cmbavDynamicfiltersoperator3.ToJavascriptSource(), true);
      }

      protected void S162( )
      {
         /* 'SETDDOSORTEDSTATUS' Routine */
         returnInSub = false;
         Ddo_grid_Sortedstatus = StringUtil.Trim( StringUtil.Str( (decimal)(AV13OrderedBy), 4, 0))+":"+(AV14OrderedDsc ? "DSC" : "ASC");
         ucDdo_grid.SendProperty(context, "", false, Ddo_grid_Internalname, "SortedStatus", Ddo_grid_Sortedstatus);
      }

      protected void S112( )
      {
         /* 'ENABLEDYNAMICFILTERS1' Routine */
         returnInSub = false;
         edtavPoconcdsc1_Visible = 0;
         AssignProp("", false, edtavPoconcdsc1_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavPoconcdsc1_Visible), 5, 0), true);
         cmbavDynamicfiltersoperator1.Visible = 0;
         AssignProp("", false, cmbavDynamicfiltersoperator1_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(cmbavDynamicfiltersoperator1.Visible), 5, 0), true);
         if ( StringUtil.StrCmp(AV15DynamicFiltersSelector1, "POCONCDSC") == 0 )
         {
            edtavPoconcdsc1_Visible = 1;
            AssignProp("", false, edtavPoconcdsc1_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavPoconcdsc1_Visible), 5, 0), true);
            cmbavDynamicfiltersoperator1.Visible = 1;
            AssignProp("", false, cmbavDynamicfiltersoperator1_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(cmbavDynamicfiltersoperator1.Visible), 5, 0), true);
         }
      }

      protected void S122( )
      {
         /* 'ENABLEDYNAMICFILTERS2' Routine */
         returnInSub = false;
         edtavPoconcdsc2_Visible = 0;
         AssignProp("", false, edtavPoconcdsc2_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavPoconcdsc2_Visible), 5, 0), true);
         cmbavDynamicfiltersoperator2.Visible = 0;
         AssignProp("", false, cmbavDynamicfiltersoperator2_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(cmbavDynamicfiltersoperator2.Visible), 5, 0), true);
         if ( StringUtil.StrCmp(AV19DynamicFiltersSelector2, "POCONCDSC") == 0 )
         {
            edtavPoconcdsc2_Visible = 1;
            AssignProp("", false, edtavPoconcdsc2_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavPoconcdsc2_Visible), 5, 0), true);
            cmbavDynamicfiltersoperator2.Visible = 1;
            AssignProp("", false, cmbavDynamicfiltersoperator2_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(cmbavDynamicfiltersoperator2.Visible), 5, 0), true);
         }
      }

      protected void S132( )
      {
         /* 'ENABLEDYNAMICFILTERS3' Routine */
         returnInSub = false;
         edtavPoconcdsc3_Visible = 0;
         AssignProp("", false, edtavPoconcdsc3_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavPoconcdsc3_Visible), 5, 0), true);
         cmbavDynamicfiltersoperator3.Visible = 0;
         AssignProp("", false, cmbavDynamicfiltersoperator3_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(cmbavDynamicfiltersoperator3.Visible), 5, 0), true);
         if ( StringUtil.StrCmp(AV23DynamicFiltersSelector3, "POCONCDSC") == 0 )
         {
            edtavPoconcdsc3_Visible = 1;
            AssignProp("", false, edtavPoconcdsc3_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavPoconcdsc3_Visible), 5, 0), true);
            cmbavDynamicfiltersoperator3.Visible = 1;
            AssignProp("", false, cmbavDynamicfiltersoperator3_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(cmbavDynamicfiltersoperator3.Visible), 5, 0), true);
         }
      }

      protected void S192( )
      {
         /* 'RESETDYNFILTERS' Routine */
         returnInSub = false;
         AV18DynamicFiltersEnabled2 = false;
         AssignAttri("", false, "AV18DynamicFiltersEnabled2", AV18DynamicFiltersEnabled2);
         AV19DynamicFiltersSelector2 = "POCONCDSC";
         AssignAttri("", false, "AV19DynamicFiltersSelector2", AV19DynamicFiltersSelector2);
         AV20DynamicFiltersOperator2 = 0;
         AssignAttri("", false, "AV20DynamicFiltersOperator2", StringUtil.LTrimStr( (decimal)(AV20DynamicFiltersOperator2), 4, 0));
         AV21PoConcDsc2 = "";
         AssignAttri("", false, "AV21PoConcDsc2", AV21PoConcDsc2);
         /* Execute user subroutine: 'ENABLEDYNAMICFILTERS2' */
         S122 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
         AV22DynamicFiltersEnabled3 = false;
         AssignAttri("", false, "AV22DynamicFiltersEnabled3", AV22DynamicFiltersEnabled3);
         AV23DynamicFiltersSelector3 = "POCONCDSC";
         AssignAttri("", false, "AV23DynamicFiltersSelector3", AV23DynamicFiltersSelector3);
         AV24DynamicFiltersOperator3 = 0;
         AssignAttri("", false, "AV24DynamicFiltersOperator3", StringUtil.LTrimStr( (decimal)(AV24DynamicFiltersOperator3), 4, 0));
         AV25PoConcDsc3 = "";
         AssignAttri("", false, "AV25PoConcDsc3", AV25PoConcDsc3);
         /* Execute user subroutine: 'ENABLEDYNAMICFILTERS3' */
         S132 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
      }

      protected void S212( )
      {
         /* 'DO UPDATE' Routine */
         returnInSub = false;
         GXKey = Crypto.GetSiteKey( );
         GXEncryptionTmp = "produccion.conceptosordenesproduccion.aspx"+UrlEncode(StringUtil.RTrim("UPD")) + "," + UrlEncode(StringUtil.LTrimStr(A313PoConcCod,6,0));
         CallWebObject(formatLink("produccion.conceptosordenesproduccion.aspx") + "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey));
         context.wjLocDisableFrm = 1;
      }

      protected void S222( )
      {
         /* 'DO DELETE' Routine */
         returnInSub = false;
         GXKey = Crypto.GetSiteKey( );
         GXEncryptionTmp = "produccion.conceptosordenesproduccion.aspx"+UrlEncode(StringUtil.RTrim("DLT")) + "," + UrlEncode(StringUtil.LTrimStr(A313PoConcCod,6,0));
         CallWebObject(formatLink("produccion.conceptosordenesproduccion.aspx") + "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey));
         context.wjLocDisableFrm = 1;
      }

      protected void S152( )
      {
         /* 'LOADGRIDSTATE' Routine */
         returnInSub = false;
         if ( StringUtil.StrCmp(AV30Session.Get(AV51Pgmname+"GridState"), "") == 0 )
         {
            AV10GridState.FromXml(new GeneXus.Programs.wwpbaseobjects.loadgridstate(context).executeUdp(  AV51Pgmname+"GridState"), null, "", "");
         }
         else
         {
            AV10GridState.FromXml(AV30Session.Get(AV51Pgmname+"GridState"), null, "", "");
         }
         AV13OrderedBy = AV10GridState.gxTpr_Orderedby;
         AssignAttri("", false, "AV13OrderedBy", StringUtil.LTrimStr( (decimal)(AV13OrderedBy), 4, 0));
         AV14OrderedDsc = AV10GridState.gxTpr_Ordereddsc;
         AssignAttri("", false, "AV14OrderedDsc", AV14OrderedDsc);
         /* Execute user subroutine: 'SETDDOSORTEDSTATUS' */
         S162 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
         AV69GXV1 = 1;
         while ( AV69GXV1 <= AV10GridState.gxTpr_Filtervalues.Count )
         {
            AV11GridStateFilterValue = ((GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue)AV10GridState.gxTpr_Filtervalues.Item(AV69GXV1));
            if ( StringUtil.StrCmp(AV11GridStateFilterValue.gxTpr_Name, "TFPOCONCCOD") == 0 )
            {
               AV31TFPoConcCod = (int)(NumberUtil.Val( AV11GridStateFilterValue.gxTpr_Value, "."));
               AssignAttri("", false, "AV31TFPoConcCod", StringUtil.LTrimStr( (decimal)(AV31TFPoConcCod), 6, 0));
               AV32TFPoConcCod_To = (int)(NumberUtil.Val( AV11GridStateFilterValue.gxTpr_Valueto, "."));
               AssignAttri("", false, "AV32TFPoConcCod_To", StringUtil.LTrimStr( (decimal)(AV32TFPoConcCod_To), 6, 0));
            }
            else if ( StringUtil.StrCmp(AV11GridStateFilterValue.gxTpr_Name, "TFPOCONCDSC") == 0 )
            {
               AV33TFPoConcDsc = AV11GridStateFilterValue.gxTpr_Value;
               AssignAttri("", false, "AV33TFPoConcDsc", AV33TFPoConcDsc);
            }
            else if ( StringUtil.StrCmp(AV11GridStateFilterValue.gxTpr_Name, "TFPOCONCDSC_SEL") == 0 )
            {
               AV34TFPoConcDsc_Sel = AV11GridStateFilterValue.gxTpr_Value;
               AssignAttri("", false, "AV34TFPoConcDsc_Sel", AV34TFPoConcDsc_Sel);
            }
            else if ( StringUtil.StrCmp(AV11GridStateFilterValue.gxTpr_Name, "TFPOCONCTIP_SEL") == 0 )
            {
               AV47TFPoConcTip_SelsJson = AV11GridStateFilterValue.gxTpr_Value;
               AssignAttri("", false, "AV47TFPoConcTip_SelsJson", AV47TFPoConcTip_SelsJson);
               AV48TFPoConcTip_Sels.FromJSonString(AV47TFPoConcTip_SelsJson, null);
            }
            else if ( StringUtil.StrCmp(AV11GridStateFilterValue.gxTpr_Name, "TFPOCONCSTS_SEL") == 0 )
            {
               AV37TFPoConcSts_SelsJson = AV11GridStateFilterValue.gxTpr_Value;
               AssignAttri("", false, "AV37TFPoConcSts_SelsJson", AV37TFPoConcSts_SelsJson);
               AV38TFPoConcSts_Sels.FromJSonString(AV37TFPoConcSts_SelsJson, null);
            }
            AV69GXV1 = (int)(AV69GXV1+1);
         }
         GXt_char2 = "";
         new GeneXus.Programs.wwpbaseobjects.wwp_getfilterval(context ).execute(  String.IsNullOrEmpty(StringUtil.RTrim( AV34TFPoConcDsc_Sel)),  AV34TFPoConcDsc_Sel, out  GXt_char2) ;
         GXt_char3 = "";
         new GeneXus.Programs.wwpbaseobjects.wwp_getfilterval(context ).execute(  (AV48TFPoConcTip_Sels.Count==0),  AV47TFPoConcTip_SelsJson, out  GXt_char3) ;
         Ddo_grid_Selectedvalue_set = "|"+GXt_char2+"|"+GXt_char3+"|"+((AV38TFPoConcSts_Sels.Count==0) ? "" : AV37TFPoConcSts_SelsJson);
         ucDdo_grid.SendProperty(context, "", false, Ddo_grid_Internalname, "SelectedValue_set", Ddo_grid_Selectedvalue_set);
         GXt_char3 = "";
         new GeneXus.Programs.wwpbaseobjects.wwp_getfilterval(context ).execute(  String.IsNullOrEmpty(StringUtil.RTrim( AV33TFPoConcDsc)),  AV33TFPoConcDsc, out  GXt_char3) ;
         Ddo_grid_Filteredtext_set = ((0==AV31TFPoConcCod) ? "" : StringUtil.Str( (decimal)(AV31TFPoConcCod), 6, 0))+"|"+GXt_char3+"||";
         ucDdo_grid.SendProperty(context, "", false, Ddo_grid_Internalname, "FilteredText_set", Ddo_grid_Filteredtext_set);
         Ddo_grid_Filteredtextto_set = ((0==AV32TFPoConcCod_To) ? "" : StringUtil.Str( (decimal)(AV32TFPoConcCod_To), 6, 0))+"|||";
         ucDdo_grid.SendProperty(context, "", false, Ddo_grid_Internalname, "FilteredTextTo_set", Ddo_grid_Filteredtextto_set);
         /* Execute user subroutine: 'LOADDYNFILTERSSTATE' */
         S202 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( StringUtil.Trim( AV10GridState.gxTpr_Pagesize))) )
         {
            subGrid_Rows = (int)(NumberUtil.Val( AV10GridState.gxTpr_Pagesize, "."));
            GxWebStd.gx_hidden_field( context, "GRID_Rows", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid_Rows), 6, 0, ".", "")));
         }
         subgrid_gotopage( AV10GridState.gxTpr_Currentpage) ;
      }

      protected void S202( )
      {
         /* 'LOADDYNFILTERSSTATE' Routine */
         returnInSub = false;
         imgAdddynamicfilters1_Visible = 1;
         AssignProp("", false, imgAdddynamicfilters1_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(imgAdddynamicfilters1_Visible), 5, 0), true);
         imgRemovedynamicfilters1_Visible = 0;
         AssignProp("", false, imgRemovedynamicfilters1_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(imgRemovedynamicfilters1_Visible), 5, 0), true);
         imgAdddynamicfilters2_Visible = 1;
         AssignProp("", false, imgAdddynamicfilters2_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(imgAdddynamicfilters2_Visible), 5, 0), true);
         imgRemovedynamicfilters2_Visible = 0;
         AssignProp("", false, imgRemovedynamicfilters2_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(imgRemovedynamicfilters2_Visible), 5, 0), true);
         if ( AV10GridState.gxTpr_Dynamicfilters.Count >= 1 )
         {
            AV12GridStateDynamicFilter = ((GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter)AV10GridState.gxTpr_Dynamicfilters.Item(1));
            AV15DynamicFiltersSelector1 = AV12GridStateDynamicFilter.gxTpr_Selected;
            AssignAttri("", false, "AV15DynamicFiltersSelector1", AV15DynamicFiltersSelector1);
            if ( StringUtil.StrCmp(AV15DynamicFiltersSelector1, "POCONCDSC") == 0 )
            {
               AV16DynamicFiltersOperator1 = AV12GridStateDynamicFilter.gxTpr_Operator;
               AssignAttri("", false, "AV16DynamicFiltersOperator1", StringUtil.LTrimStr( (decimal)(AV16DynamicFiltersOperator1), 4, 0));
               AV17PoConcDsc1 = AV12GridStateDynamicFilter.gxTpr_Value;
               AssignAttri("", false, "AV17PoConcDsc1", AV17PoConcDsc1);
            }
            /* Execute user subroutine: 'ENABLEDYNAMICFILTERS1' */
            S112 ();
            if ( returnInSub )
            {
               returnInSub = true;
               if (true) return;
            }
            if ( AV10GridState.gxTpr_Dynamicfilters.Count >= 2 )
            {
               lblJsdynamicfilters_Caption = "<script type=\"text/javascript\">$(document).ready(function() {";
               AssignProp("", false, lblJsdynamicfilters_Internalname, "Caption", lblJsdynamicfilters_Caption, true);
               lblJsdynamicfilters_Caption = lblJsdynamicfilters_Caption+StringUtil.Format( "WWPDynFilterShow_AL('%1', 2, 0);", divTabledynamicfilters_Internalname, "", "", "", "", "", "", "", "");
               AssignProp("", false, lblJsdynamicfilters_Internalname, "Caption", lblJsdynamicfilters_Caption, true);
               imgAdddynamicfilters1_Visible = 0;
               AssignProp("", false, imgAdddynamicfilters1_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(imgAdddynamicfilters1_Visible), 5, 0), true);
               imgRemovedynamicfilters1_Visible = 1;
               AssignProp("", false, imgRemovedynamicfilters1_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(imgRemovedynamicfilters1_Visible), 5, 0), true);
               AV18DynamicFiltersEnabled2 = true;
               AssignAttri("", false, "AV18DynamicFiltersEnabled2", AV18DynamicFiltersEnabled2);
               AV12GridStateDynamicFilter = ((GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter)AV10GridState.gxTpr_Dynamicfilters.Item(2));
               AV19DynamicFiltersSelector2 = AV12GridStateDynamicFilter.gxTpr_Selected;
               AssignAttri("", false, "AV19DynamicFiltersSelector2", AV19DynamicFiltersSelector2);
               if ( StringUtil.StrCmp(AV19DynamicFiltersSelector2, "POCONCDSC") == 0 )
               {
                  AV20DynamicFiltersOperator2 = AV12GridStateDynamicFilter.gxTpr_Operator;
                  AssignAttri("", false, "AV20DynamicFiltersOperator2", StringUtil.LTrimStr( (decimal)(AV20DynamicFiltersOperator2), 4, 0));
                  AV21PoConcDsc2 = AV12GridStateDynamicFilter.gxTpr_Value;
                  AssignAttri("", false, "AV21PoConcDsc2", AV21PoConcDsc2);
               }
               /* Execute user subroutine: 'ENABLEDYNAMICFILTERS2' */
               S122 ();
               if ( returnInSub )
               {
                  returnInSub = true;
                  if (true) return;
               }
               if ( AV10GridState.gxTpr_Dynamicfilters.Count >= 3 )
               {
                  lblJsdynamicfilters_Caption = lblJsdynamicfilters_Caption+StringUtil.Format( "WWPDynFilterShow_AL('%1', 3, 0);", divTabledynamicfilters_Internalname, "", "", "", "", "", "", "", "");
                  AssignProp("", false, lblJsdynamicfilters_Internalname, "Caption", lblJsdynamicfilters_Caption, true);
                  imgAdddynamicfilters2_Visible = 0;
                  AssignProp("", false, imgAdddynamicfilters2_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(imgAdddynamicfilters2_Visible), 5, 0), true);
                  imgRemovedynamicfilters2_Visible = 1;
                  AssignProp("", false, imgRemovedynamicfilters2_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(imgRemovedynamicfilters2_Visible), 5, 0), true);
                  AV22DynamicFiltersEnabled3 = true;
                  AssignAttri("", false, "AV22DynamicFiltersEnabled3", AV22DynamicFiltersEnabled3);
                  AV12GridStateDynamicFilter = ((GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter)AV10GridState.gxTpr_Dynamicfilters.Item(3));
                  AV23DynamicFiltersSelector3 = AV12GridStateDynamicFilter.gxTpr_Selected;
                  AssignAttri("", false, "AV23DynamicFiltersSelector3", AV23DynamicFiltersSelector3);
                  if ( StringUtil.StrCmp(AV23DynamicFiltersSelector3, "POCONCDSC") == 0 )
                  {
                     AV24DynamicFiltersOperator3 = AV12GridStateDynamicFilter.gxTpr_Operator;
                     AssignAttri("", false, "AV24DynamicFiltersOperator3", StringUtil.LTrimStr( (decimal)(AV24DynamicFiltersOperator3), 4, 0));
                     AV25PoConcDsc3 = AV12GridStateDynamicFilter.gxTpr_Value;
                     AssignAttri("", false, "AV25PoConcDsc3", AV25PoConcDsc3);
                  }
                  /* Execute user subroutine: 'ENABLEDYNAMICFILTERS3' */
                  S132 ();
                  if ( returnInSub )
                  {
                     returnInSub = true;
                     if (true) return;
                  }
               }
               lblJsdynamicfilters_Caption = lblJsdynamicfilters_Caption+"});</script>";
               AssignProp("", false, lblJsdynamicfilters_Internalname, "Caption", lblJsdynamicfilters_Caption, true);
            }
         }
         if ( AV26DynamicFiltersRemoving )
         {
            lblJsdynamicfilters_Caption = "";
            AssignProp("", false, lblJsdynamicfilters_Internalname, "Caption", lblJsdynamicfilters_Caption, true);
         }
      }

      protected void S172( )
      {
         /* 'SAVEGRIDSTATE' Routine */
         returnInSub = false;
         AV10GridState.FromXml(AV30Session.Get(AV51Pgmname+"GridState"), null, "", "");
         AV10GridState.gxTpr_Orderedby = AV13OrderedBy;
         AV10GridState.gxTpr_Ordereddsc = AV14OrderedDsc;
         AV10GridState.gxTpr_Filtervalues.Clear();
         new GeneXus.Programs.wwpbaseobjects.wwp_gridstateaddfiltervalue(context ).execute( ref  AV10GridState,  "TFPOCONCCOD",  "Codigo Concepto",  !((0==AV31TFPoConcCod)&&(0==AV32TFPoConcCod_To)),  0,  StringUtil.Trim( StringUtil.Str( (decimal)(AV31TFPoConcCod), 6, 0)),  StringUtil.Trim( StringUtil.Str( (decimal)(AV32TFPoConcCod_To), 6, 0))) ;
         new GeneXus.Programs.wwpbaseobjects.wwp_gridstateaddfiltervalueandsel(context ).execute( ref  AV10GridState,  "TFPOCONCDSC",  "Concepto",  !String.IsNullOrEmpty(StringUtil.RTrim( AV33TFPoConcDsc)),  0,  AV33TFPoConcDsc,  "",  !String.IsNullOrEmpty(StringUtil.RTrim( AV34TFPoConcDsc_Sel)),  AV34TFPoConcDsc_Sel,  "") ;
         new GeneXus.Programs.wwpbaseobjects.wwp_gridstateaddfiltervalue(context ).execute( ref  AV10GridState,  "TFPOCONCTIP_SEL",  "Tipo de Distribuci?n",  !(AV48TFPoConcTip_Sels.Count==0),  0,  AV48TFPoConcTip_Sels.ToJSonString(false),  "") ;
         new GeneXus.Programs.wwpbaseobjects.wwp_gridstateaddfiltervalue(context ).execute( ref  AV10GridState,  "TFPOCONCSTS_SEL",  "Estado",  !(AV38TFPoConcSts_Sels.Count==0),  0,  AV38TFPoConcSts_Sels.ToJSonString(false),  "") ;
         /* Execute user subroutine: 'SAVEDYNFILTERSSTATE' */
         S182 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
         AV10GridState.gxTpr_Pagesize = StringUtil.Str( (decimal)(subGrid_Rows), 10, 0);
         AV10GridState.gxTpr_Currentpage = (short)(subGrid_fnc_Currentpage( ));
         new GeneXus.Programs.wwpbaseobjects.savegridstate(context ).execute(  AV51Pgmname+"GridState",  AV10GridState.ToXml(false, true, "", "")) ;
      }

      protected void S182( )
      {
         /* 'SAVEDYNFILTERSSTATE' Routine */
         returnInSub = false;
         AV10GridState.gxTpr_Dynamicfilters.Clear();
         if ( ! AV27DynamicFiltersIgnoreFirst )
         {
            AV12GridStateDynamicFilter = new GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter(context);
            AV12GridStateDynamicFilter.gxTpr_Selected = AV15DynamicFiltersSelector1;
            if ( ( StringUtil.StrCmp(AV15DynamicFiltersSelector1, "POCONCDSC") == 0 ) && ! String.IsNullOrEmpty(StringUtil.RTrim( AV17PoConcDsc1)) )
            {
               AV12GridStateDynamicFilter.gxTpr_Dsc = "Concepto";
               AV12GridStateDynamicFilter.gxTpr_Value = AV17PoConcDsc1;
               AV12GridStateDynamicFilter.gxTpr_Operator = AV16DynamicFiltersOperator1;
            }
            if ( AV26DynamicFiltersRemoving || ! String.IsNullOrEmpty(StringUtil.RTrim( AV12GridStateDynamicFilter.gxTpr_Value)) )
            {
               AV10GridState.gxTpr_Dynamicfilters.Add(AV12GridStateDynamicFilter, 0);
            }
         }
         if ( AV18DynamicFiltersEnabled2 )
         {
            AV12GridStateDynamicFilter = new GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter(context);
            AV12GridStateDynamicFilter.gxTpr_Selected = AV19DynamicFiltersSelector2;
            if ( ( StringUtil.StrCmp(AV19DynamicFiltersSelector2, "POCONCDSC") == 0 ) && ! String.IsNullOrEmpty(StringUtil.RTrim( AV21PoConcDsc2)) )
            {
               AV12GridStateDynamicFilter.gxTpr_Dsc = "Concepto";
               AV12GridStateDynamicFilter.gxTpr_Value = AV21PoConcDsc2;
               AV12GridStateDynamicFilter.gxTpr_Operator = AV20DynamicFiltersOperator2;
            }
            if ( AV26DynamicFiltersRemoving || ! String.IsNullOrEmpty(StringUtil.RTrim( AV12GridStateDynamicFilter.gxTpr_Value)) )
            {
               AV10GridState.gxTpr_Dynamicfilters.Add(AV12GridStateDynamicFilter, 0);
            }
         }
         if ( AV22DynamicFiltersEnabled3 )
         {
            AV12GridStateDynamicFilter = new GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter(context);
            AV12GridStateDynamicFilter.gxTpr_Selected = AV23DynamicFiltersSelector3;
            if ( ( StringUtil.StrCmp(AV23DynamicFiltersSelector3, "POCONCDSC") == 0 ) && ! String.IsNullOrEmpty(StringUtil.RTrim( AV25PoConcDsc3)) )
            {
               AV12GridStateDynamicFilter.gxTpr_Dsc = "Concepto";
               AV12GridStateDynamicFilter.gxTpr_Value = AV25PoConcDsc3;
               AV12GridStateDynamicFilter.gxTpr_Operator = AV24DynamicFiltersOperator3;
            }
            if ( AV26DynamicFiltersRemoving || ! String.IsNullOrEmpty(StringUtil.RTrim( AV12GridStateDynamicFilter.gxTpr_Value)) )
            {
               AV10GridState.gxTpr_Dynamicfilters.Add(AV12GridStateDynamicFilter, 0);
            }
         }
      }

      protected void S142( )
      {
         /* 'PREPARETRANSACTION' Routine */
         returnInSub = false;
         AV8TrnContext = new GeneXus.Programs.wwpbaseobjects.SdtWWPTransactionContext(context);
         AV8TrnContext.gxTpr_Callerobject = AV51Pgmname;
         AV8TrnContext.gxTpr_Callerondelete = true;
         AV8TrnContext.gxTpr_Callerurl = AV7HTTPRequest.ScriptName+"?"+AV7HTTPRequest.QueryString;
         AV8TrnContext.gxTpr_Transactionname = "Produccion.ConceptosOrdenesProduccion";
         AV30Session.Set("TrnContext", AV8TrnContext.ToXml(false, true, "", ""));
      }

      protected void S242( )
      {
         /* 'DOEXPORT' Routine */
         returnInSub = false;
         /* Execute user subroutine: 'LOADGRIDSTATE' */
         S152 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
         new GeneXus.Programs.produccion.conceptosordenesproduccionwwexport(context ).execute( out  AV28ExcelFilename, out  AV29ErrorMessage) ;
         if ( StringUtil.StrCmp(AV28ExcelFilename, "") != 0 )
         {
            CallWebObject(formatLink(AV28ExcelFilename) );
            context.wjLocDisableFrm = 0;
         }
         else
         {
            GX_msglist.addItem(AV29ErrorMessage);
         }
      }

      protected void S232( )
      {
         /* 'DOEXPORTREPORT' Routine */
         returnInSub = false;
         /* Execute user subroutine: 'LOADGRIDSTATE' */
         S152 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
         Innewwindow1_Target = formatLink("produccion.conceptosordenesproduccionwwexportreport.aspx") ;
         ucInnewwindow1.SendProperty(context, "", false, Innewwindow1_Internalname, "Target", Innewwindow1_Target);
         Innewwindow1_Height = "600";
         ucInnewwindow1.SendProperty(context, "", false, Innewwindow1_Internalname, "Height", Innewwindow1_Height);
         Innewwindow1_Width = "800";
         ucInnewwindow1.SendProperty(context, "", false, Innewwindow1_Internalname, "Width", Innewwindow1_Width);
         this.executeUsercontrolMethod("", false, "INNEWWINDOW1Container", "OpenWindow", "", new Object[] {});
      }

      protected void wb_table1_25_272( bool wbgen )
      {
         if ( wbgen )
         {
            /* Table start */
            sStyleString = "";
            GxWebStd.gx_table_start( context, tblTablefilters_Internalname, tblTablefilters_Internalname, "", "", 0, "", "", 1, 2, sStyleString, "", "", 0);
            context.WriteHtmlText( "<tr>") ;
            context.WriteHtmlText( "<td>") ;
            /* Div Control */
            GxWebStd.gx_div_start( context, divTabledynamicfilters_Internalname, 1, 0, "px", 0, "px", "TableDynamicFiltersFlex", "left", "top", " "+"data-gx-flex"+" ", "flex-direction:column;", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "DynRowVisible", "left", "top", "", "flex-grow:1;", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divTabledynamicfiltersrow1_Internalname, 1, 0, "px", 0, "px", "Flex", "left", "top", " "+"data-gx-flex"+" ", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "", "left", "top", "", "flex-grow:1;", "div");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblDynamicfiltersprefix1_Internalname, "Buscar en", "", "", lblDynamicfiltersprefix1_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "DataFilterDescriptionPrefix", 0, "", 1, 1, 0, 0, "HLP_Produccion\\ConceptosOrdenesProduccionWW.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "", "left", "top", "", "flex-grow:1;", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "left", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, cmbavDynamicfiltersselector1_Internalname, "Dynamic Filters Selector1", "gx-form-item AttributeLabel", 0, true, "width: 25%;");
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 35,'',false,'" + sGXsfl_101_idx + "',0)\"";
            /* ComboBox */
            GxWebStd.gx_combobox_ctrl1( context, cmbavDynamicfiltersselector1, cmbavDynamicfiltersselector1_Internalname, StringUtil.RTrim( AV15DynamicFiltersSelector1), 1, cmbavDynamicfiltersselector1_Jsonclick, 5, "'"+""+"'"+",false,"+"'"+"EVDYNAMICFILTERSSELECTOR1.CLICK."+"'", "svchar", "", 1, cmbavDynamicfiltersselector1.Enabled, 0, 0, 0, "em", 0, "", "", "Attribute", "", "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,35);\"", "", true, 1, "HLP_Produccion\\ConceptosOrdenesProduccionWW.htm");
            cmbavDynamicfiltersselector1.CurrentValue = StringUtil.RTrim( AV15DynamicFiltersSelector1);
            AssignProp("", false, cmbavDynamicfiltersselector1_Internalname, "Values", (string)(cmbavDynamicfiltersselector1.ToJavascriptSource()), true);
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "", "left", "top", "", "flex-grow:1;", "div");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblDynamicfiltersmiddle1_Internalname, "valor", "", "", lblDynamicfiltersmiddle1_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "DataFilterDescription", 0, "", 1, 1, 0, 0, "HLP_Produccion\\ConceptosOrdenesProduccionWW.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "", "left", "top", "", "flex-grow:1;", "div");
            wb_table2_39_272( true) ;
         }
         else
         {
            wb_table2_39_272( false) ;
         }
         return  ;
      }

      protected void wb_table2_39_272e( bool wbgen )
      {
         if ( wbgen )
         {
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "", "left", "top", "", "flex-grow:1;", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divTabledynamicfiltersrow2_Internalname, 1, 0, "px", 0, "px", "Flex", "left", "top", " "+"data-gx-flex"+" ", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "Invisible", "left", "top", "", "flex-grow:1;", "div");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblDynamicfiltersprefix2_Internalname, "Buscar en", "", "", lblDynamicfiltersprefix2_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "DataFilterDescriptionPrefix", 0, "", 1, 1, 0, 0, "HLP_Produccion\\ConceptosOrdenesProduccionWW.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "Invisible", "left", "top", "", "flex-grow:1;", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "left", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, cmbavDynamicfiltersselector2_Internalname, "Dynamic Filters Selector2", "gx-form-item AttributeLabel", 0, true, "width: 25%;");
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 57,'',false,'" + sGXsfl_101_idx + "',0)\"";
            /* ComboBox */
            GxWebStd.gx_combobox_ctrl1( context, cmbavDynamicfiltersselector2, cmbavDynamicfiltersselector2_Internalname, StringUtil.RTrim( AV19DynamicFiltersSelector2), 1, cmbavDynamicfiltersselector2_Jsonclick, 5, "'"+""+"'"+",false,"+"'"+"EVDYNAMICFILTERSSELECTOR2.CLICK."+"'", "svchar", "", 1, cmbavDynamicfiltersselector2.Enabled, 0, 0, 0, "em", 0, "", "", "Attribute", "", "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,57);\"", "", true, 1, "HLP_Produccion\\ConceptosOrdenesProduccionWW.htm");
            cmbavDynamicfiltersselector2.CurrentValue = StringUtil.RTrim( AV19DynamicFiltersSelector2);
            AssignProp("", false, cmbavDynamicfiltersselector2_Internalname, "Values", (string)(cmbavDynamicfiltersselector2.ToJavascriptSource()), true);
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "Invisible", "left", "top", "", "flex-grow:1;", "div");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblDynamicfiltersmiddle2_Internalname, "valor", "", "", lblDynamicfiltersmiddle2_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "DataFilterDescription", 0, "", 1, 1, 0, 0, "HLP_Produccion\\ConceptosOrdenesProduccionWW.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "Invisible", "left", "top", "", "flex-grow:1;", "div");
            wb_table3_61_272( true) ;
         }
         else
         {
            wb_table3_61_272( false) ;
         }
         return  ;
      }

      protected void wb_table3_61_272e( bool wbgen )
      {
         if ( wbgen )
         {
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "", "left", "top", "", "flex-grow:1;", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divTabledynamicfiltersrow3_Internalname, 1, 0, "px", 0, "px", "Flex", "left", "top", " "+"data-gx-flex"+" ", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "Invisible", "left", "top", "", "flex-grow:1;", "div");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblDynamicfiltersprefix3_Internalname, "Buscar en", "", "", lblDynamicfiltersprefix3_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "DataFilterDescriptionPrefix", 0, "", 1, 1, 0, 0, "HLP_Produccion\\ConceptosOrdenesProduccionWW.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "Invisible", "left", "top", "", "flex-grow:1;", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "left", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, cmbavDynamicfiltersselector3_Internalname, "Dynamic Filters Selector3", "gx-form-item AttributeLabel", 0, true, "width: 25%;");
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 79,'',false,'" + sGXsfl_101_idx + "',0)\"";
            /* ComboBox */
            GxWebStd.gx_combobox_ctrl1( context, cmbavDynamicfiltersselector3, cmbavDynamicfiltersselector3_Internalname, StringUtil.RTrim( AV23DynamicFiltersSelector3), 1, cmbavDynamicfiltersselector3_Jsonclick, 5, "'"+""+"'"+",false,"+"'"+"EVDYNAMICFILTERSSELECTOR3.CLICK."+"'", "svchar", "", 1, cmbavDynamicfiltersselector3.Enabled, 0, 0, 0, "em", 0, "", "", "Attribute", "", "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,79);\"", "", true, 1, "HLP_Produccion\\ConceptosOrdenesProduccionWW.htm");
            cmbavDynamicfiltersselector3.CurrentValue = StringUtil.RTrim( AV23DynamicFiltersSelector3);
            AssignProp("", false, cmbavDynamicfiltersselector3_Internalname, "Values", (string)(cmbavDynamicfiltersselector3.ToJavascriptSource()), true);
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "Invisible", "left", "top", "", "flex-grow:1;", "div");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblDynamicfiltersmiddle3_Internalname, "valor", "", "", lblDynamicfiltersmiddle3_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "DataFilterDescription", 0, "", 1, 1, 0, 0, "HLP_Produccion\\ConceptosOrdenesProduccionWW.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "Invisible", "left", "top", "", "flex-grow:1;", "div");
            wb_table4_83_272( true) ;
         }
         else
         {
            wb_table4_83_272( false) ;
         }
         return  ;
      }

      protected void wb_table4_83_272e( bool wbgen )
      {
         if ( wbgen )
         {
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "</tr>") ;
            /* End of table */
            context.WriteHtmlText( "</table>") ;
            wb_table1_25_272e( true) ;
         }
         else
         {
            wb_table1_25_272e( false) ;
         }
      }

      protected void wb_table4_83_272( bool wbgen )
      {
         if ( wbgen )
         {
            /* Table start */
            sStyleString = "";
            GxWebStd.gx_table_start( context, tblTablemergeddynamicfilters3_Internalname, tblTablemergeddynamicfilters3_Internalname, "", "Table", 0, "", "", 0, 0, sStyleString, "", "", 0);
            context.WriteHtmlText( "<tr>") ;
            context.WriteHtmlText( "<td>") ;
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "left", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, cmbavDynamicfiltersoperator3_Internalname, "Dynamic Filters Operator3", "gx-form-item AttributeLabel", 0, true, "width: 25%;");
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 87,'',false,'" + sGXsfl_101_idx + "',0)\"";
            /* ComboBox */
            GxWebStd.gx_combobox_ctrl1( context, cmbavDynamicfiltersoperator3, cmbavDynamicfiltersoperator3_Internalname, StringUtil.Trim( StringUtil.Str( (decimal)(AV24DynamicFiltersOperator3), 4, 0)), 1, cmbavDynamicfiltersoperator3_Jsonclick, 0, "'"+""+"'"+",false,"+"'"+""+"'", "int", "", cmbavDynamicfiltersoperator3.Visible, cmbavDynamicfiltersoperator3.Enabled, 0, 0, 0, "em", 0, "", "", "Attribute", "", "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,87);\"", "", true, 1, "HLP_Produccion\\ConceptosOrdenesProduccionWW.htm");
            cmbavDynamicfiltersoperator3.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV24DynamicFiltersOperator3), 4, 0));
            AssignProp("", false, cmbavDynamicfiltersoperator3_Internalname, "Values", (string)(cmbavDynamicfiltersoperator3.ToJavascriptSource()), true);
            GxWebStd.gx_div_end( context, "left", "top", "div");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "<td id=\""+cellFilter_poconcdsc3_cell_Internalname+"\"  class=''>") ;
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "left", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavPoconcdsc3_Internalname, "Po Conc Dsc3", "gx-form-item AttributeLabel", 0, true, "width: 25%;");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 90,'',false,'" + sGXsfl_101_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavPoconcdsc3_Internalname, StringUtil.RTrim( AV25PoConcDsc3), StringUtil.RTrim( context.localUtil.Format( AV25PoConcDsc3, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,90);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavPoconcdsc3_Jsonclick, 0, "Attribute", "", "", "", "", edtavPoconcdsc3_Visible, edtavPoconcdsc3_Enabled, 0, "text", "", 80, "chr", 1, "row", 100, 0, 0, 0, 1, -1, -1, true, "", "left", true, "", "HLP_Produccion\\ConceptosOrdenesProduccionWW.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "<td id=\""+cellDynamicfilters_removefilter3_cell_Internalname+"\"  class=''>") ;
            /* Active images/pictures */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 92,'',false,'',0)\"";
            ClassString = "Image";
            StyleString = "";
            sImgUrl = (string)(context.GetImagePath( "11a6ef14-1a5a-4077-91a2-f41ed9a3a662", "", context.GetTheme( )));
            GxWebStd.gx_bitmap( context, imgRemovedynamicfilters3_Internalname, sImgUrl, "", "", "", context.GetTheme( ), 1, 1, "", "Quitar filtro", 0, 0, 0, "px", 0, "px", 0, 0, 5, imgRemovedynamicfilters3_Jsonclick, "'"+""+"'"+",false,"+"'"+"E\\'REMOVEDYNAMICFILTERS3\\'."+"'", StyleString, ClassString, "", "", "", "", " "+"data-gx-image"+" "+TempTags, "", "", 1, false, false, context.GetImageSrcSet( sImgUrl), "HLP_Produccion\\ConceptosOrdenesProduccionWW.htm");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "</tr>") ;
            /* End of table */
            context.WriteHtmlText( "</table>") ;
            wb_table4_83_272e( true) ;
         }
         else
         {
            wb_table4_83_272e( false) ;
         }
      }

      protected void wb_table3_61_272( bool wbgen )
      {
         if ( wbgen )
         {
            /* Table start */
            sStyleString = "";
            GxWebStd.gx_table_start( context, tblTablemergeddynamicfilters2_Internalname, tblTablemergeddynamicfilters2_Internalname, "", "Table", 0, "", "", 0, 0, sStyleString, "", "", 0);
            context.WriteHtmlText( "<tr>") ;
            context.WriteHtmlText( "<td>") ;
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "left", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, cmbavDynamicfiltersoperator2_Internalname, "Dynamic Filters Operator2", "gx-form-item AttributeLabel", 0, true, "width: 25%;");
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 65,'',false,'" + sGXsfl_101_idx + "',0)\"";
            /* ComboBox */
            GxWebStd.gx_combobox_ctrl1( context, cmbavDynamicfiltersoperator2, cmbavDynamicfiltersoperator2_Internalname, StringUtil.Trim( StringUtil.Str( (decimal)(AV20DynamicFiltersOperator2), 4, 0)), 1, cmbavDynamicfiltersoperator2_Jsonclick, 0, "'"+""+"'"+",false,"+"'"+""+"'", "int", "", cmbavDynamicfiltersoperator2.Visible, cmbavDynamicfiltersoperator2.Enabled, 0, 0, 0, "em", 0, "", "", "Attribute", "", "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,65);\"", "", true, 1, "HLP_Produccion\\ConceptosOrdenesProduccionWW.htm");
            cmbavDynamicfiltersoperator2.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV20DynamicFiltersOperator2), 4, 0));
            AssignProp("", false, cmbavDynamicfiltersoperator2_Internalname, "Values", (string)(cmbavDynamicfiltersoperator2.ToJavascriptSource()), true);
            GxWebStd.gx_div_end( context, "left", "top", "div");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "<td id=\""+cellFilter_poconcdsc2_cell_Internalname+"\"  class=''>") ;
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "left", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavPoconcdsc2_Internalname, "Po Conc Dsc2", "gx-form-item AttributeLabel", 0, true, "width: 25%;");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 68,'',false,'" + sGXsfl_101_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavPoconcdsc2_Internalname, StringUtil.RTrim( AV21PoConcDsc2), StringUtil.RTrim( context.localUtil.Format( AV21PoConcDsc2, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,68);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavPoconcdsc2_Jsonclick, 0, "Attribute", "", "", "", "", edtavPoconcdsc2_Visible, edtavPoconcdsc2_Enabled, 0, "text", "", 80, "chr", 1, "row", 100, 0, 0, 0, 1, -1, -1, true, "", "left", true, "", "HLP_Produccion\\ConceptosOrdenesProduccionWW.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "<td id=\""+cellDynamicfilters_addfilter2_cell_Internalname+"\"  class=''>") ;
            /* Active images/pictures */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 70,'',false,'',0)\"";
            ClassString = "Image";
            StyleString = "";
            sImgUrl = (string)(context.GetImagePath( "27283ea5-332f-423b-b880-64b762622df3", "", context.GetTheme( )));
            GxWebStd.gx_bitmap( context, imgAdddynamicfilters2_Internalname, sImgUrl, "", "", "", context.GetTheme( ), imgAdddynamicfilters2_Visible, 1, "", "Agregar filtro", 0, 0, 0, "px", 0, "px", 0, 0, 5, imgAdddynamicfilters2_Jsonclick, "'"+""+"'"+",false,"+"'"+"E\\'ADDDYNAMICFILTERS2\\'."+"'", StyleString, ClassString, "", "", "", "", " "+"data-gx-image"+" "+TempTags, "", "", 1, false, false, context.GetImageSrcSet( sImgUrl), "HLP_Produccion\\ConceptosOrdenesProduccionWW.htm");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "<td id=\""+cellDynamicfilters_removefilter2_cell_Internalname+"\"  class=''>") ;
            /* Active images/pictures */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 72,'',false,'',0)\"";
            ClassString = "Image";
            StyleString = "";
            sImgUrl = (string)(context.GetImagePath( "11a6ef14-1a5a-4077-91a2-f41ed9a3a662", "", context.GetTheme( )));
            GxWebStd.gx_bitmap( context, imgRemovedynamicfilters2_Internalname, sImgUrl, "", "", "", context.GetTheme( ), imgRemovedynamicfilters2_Visible, 1, "", "Quitar filtro", 0, 0, 0, "px", 0, "px", 0, 0, 5, imgRemovedynamicfilters2_Jsonclick, "'"+""+"'"+",false,"+"'"+"E\\'REMOVEDYNAMICFILTERS2\\'."+"'", StyleString, ClassString, "", "", "", "", " "+"data-gx-image"+" "+TempTags, "", "", 1, false, false, context.GetImageSrcSet( sImgUrl), "HLP_Produccion\\ConceptosOrdenesProduccionWW.htm");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "</tr>") ;
            /* End of table */
            context.WriteHtmlText( "</table>") ;
            wb_table3_61_272e( true) ;
         }
         else
         {
            wb_table3_61_272e( false) ;
         }
      }

      protected void wb_table2_39_272( bool wbgen )
      {
         if ( wbgen )
         {
            /* Table start */
            sStyleString = "";
            GxWebStd.gx_table_start( context, tblTablemergeddynamicfilters1_Internalname, tblTablemergeddynamicfilters1_Internalname, "", "Table", 0, "", "", 0, 0, sStyleString, "", "", 0);
            context.WriteHtmlText( "<tr>") ;
            context.WriteHtmlText( "<td>") ;
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "left", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, cmbavDynamicfiltersoperator1_Internalname, "Dynamic Filters Operator1", "gx-form-item AttributeLabel", 0, true, "width: 25%;");
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 43,'',false,'" + sGXsfl_101_idx + "',0)\"";
            /* ComboBox */
            GxWebStd.gx_combobox_ctrl1( context, cmbavDynamicfiltersoperator1, cmbavDynamicfiltersoperator1_Internalname, StringUtil.Trim( StringUtil.Str( (decimal)(AV16DynamicFiltersOperator1), 4, 0)), 1, cmbavDynamicfiltersoperator1_Jsonclick, 0, "'"+""+"'"+",false,"+"'"+""+"'", "int", "", cmbavDynamicfiltersoperator1.Visible, cmbavDynamicfiltersoperator1.Enabled, 0, 0, 0, "em", 0, "", "", "Attribute", "", "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,43);\"", "", true, 1, "HLP_Produccion\\ConceptosOrdenesProduccionWW.htm");
            cmbavDynamicfiltersoperator1.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV16DynamicFiltersOperator1), 4, 0));
            AssignProp("", false, cmbavDynamicfiltersoperator1_Internalname, "Values", (string)(cmbavDynamicfiltersoperator1.ToJavascriptSource()), true);
            GxWebStd.gx_div_end( context, "left", "top", "div");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "<td id=\""+cellFilter_poconcdsc1_cell_Internalname+"\"  class=''>") ;
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "left", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavPoconcdsc1_Internalname, "Po Conc Dsc1", "gx-form-item AttributeLabel", 0, true, "width: 25%;");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 46,'',false,'" + sGXsfl_101_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavPoconcdsc1_Internalname, StringUtil.RTrim( AV17PoConcDsc1), StringUtil.RTrim( context.localUtil.Format( AV17PoConcDsc1, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,46);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavPoconcdsc1_Jsonclick, 0, "Attribute", "", "", "", "", edtavPoconcdsc1_Visible, edtavPoconcdsc1_Enabled, 0, "text", "", 80, "chr", 1, "row", 100, 0, 0, 0, 1, -1, -1, true, "", "left", true, "", "HLP_Produccion\\ConceptosOrdenesProduccionWW.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "<td id=\""+cellDynamicfilters_addfilter1_cell_Internalname+"\"  class=''>") ;
            /* Active images/pictures */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 48,'',false,'',0)\"";
            ClassString = "Image";
            StyleString = "";
            sImgUrl = (string)(context.GetImagePath( "27283ea5-332f-423b-b880-64b762622df3", "", context.GetTheme( )));
            GxWebStd.gx_bitmap( context, imgAdddynamicfilters1_Internalname, sImgUrl, "", "", "", context.GetTheme( ), imgAdddynamicfilters1_Visible, 1, "", "Agregar filtro", 0, 0, 0, "px", 0, "px", 0, 0, 5, imgAdddynamicfilters1_Jsonclick, "'"+""+"'"+",false,"+"'"+"E\\'ADDDYNAMICFILTERS1\\'."+"'", StyleString, ClassString, "", "", "", "", " "+"data-gx-image"+" "+TempTags, "", "", 1, false, false, context.GetImageSrcSet( sImgUrl), "HLP_Produccion\\ConceptosOrdenesProduccionWW.htm");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "<td id=\""+cellDynamicfilters_removefilter1_cell_Internalname+"\"  class=''>") ;
            /* Active images/pictures */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 50,'',false,'',0)\"";
            ClassString = "Image";
            StyleString = "";
            sImgUrl = (string)(context.GetImagePath( "11a6ef14-1a5a-4077-91a2-f41ed9a3a662", "", context.GetTheme( )));
            GxWebStd.gx_bitmap( context, imgRemovedynamicfilters1_Internalname, sImgUrl, "", "", "", context.GetTheme( ), imgRemovedynamicfilters1_Visible, 1, "", "Quitar filtro", 0, 0, 0, "px", 0, "px", 0, 0, 5, imgRemovedynamicfilters1_Jsonclick, "'"+""+"'"+",false,"+"'"+"E\\'REMOVEDYNAMICFILTERS1\\'."+"'", StyleString, ClassString, "", "", "", "", " "+"data-gx-image"+" "+TempTags, "", "", 1, false, false, context.GetImageSrcSet( sImgUrl), "HLP_Produccion\\ConceptosOrdenesProduccionWW.htm");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "</tr>") ;
            /* End of table */
            context.WriteHtmlText( "</table>") ;
            wb_table2_39_272e( true) ;
         }
         else
         {
            wb_table2_39_272e( false) ;
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
         PA272( ) ;
         WS272( ) ;
         WE272( ) ;
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
         AddStyleSheetFile("DVelop/DVPaginationBar/DVPaginationBar.css", "");
         AddThemeStyleSheetFile("", context.GetTheme( )+".css", "?"+GetCacheInvalidationToken( ));
         bool outputEnabled = isOutputEnabled( );
         if ( context.isSpaRequest( ) )
         {
            enableOutput();
         }
         idxLst = 1;
         while ( idxLst <= Form.Jscriptsrc.Count )
         {
            context.AddJavascriptSource(StringUtil.RTrim( ((string)Form.Jscriptsrc.Item(idxLst))), "?202281810302446", true, true);
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
         context.AddJavascriptSource("produccion/conceptosordenesproduccionww.js", "?202281810302447", false, true);
         context.AddJavascriptSource("DVelop/Bootstrap/Shared/DVelopBootstrap.js", "", false, true);
         context.AddJavascriptSource("DVelop/Shared/WorkWithPlusCommon.js", "", false, true);
         context.AddJavascriptSource("DVelop/Bootstrap/Panel/BootstrapPanelRender.js", "", false, true);
         context.AddJavascriptSource("DVelop/Bootstrap/Shared/DVelopBootstrap.js", "", false, true);
         context.AddJavascriptSource("DVelop/Shared/WorkWithPlusCommon.js", "", false, true);
         context.AddJavascriptSource("DVelop/DVPaginationBar/DVPaginationBarRender.js", "", false, true);
         context.AddJavascriptSource("DVelop/Bootstrap/Shared/DVelopBootstrap.js", "", false, true);
         context.AddJavascriptSource("DVelop/Shared/WorkWithPlusCommon.js", "", false, true);
         context.AddJavascriptSource("DVelop/Bootstrap/DropDownOptions/BootstrapDropDownOptionsRender.js", "", false, true);
         context.AddJavascriptSource("DVelop/Bootstrap/Shared/DVelopBootstrap.js", "", false, true);
         context.AddJavascriptSource("DVelop/Shared/WorkWithPlusCommon.js", "", false, true);
         context.AddJavascriptSource("DVelop/Bootstrap/DropDownOptions/BootstrapDropDownOptionsRender.js", "", false, true);
         context.AddJavascriptSource("Window/InNewWindowRender.js", "", false, true);
         context.AddJavascriptSource("DVelop/Shared/WorkWithPlusCommon.js", "", false, true);
         context.AddJavascriptSource("DVelop/GridEmpowerer/GridEmpowererRender.js", "", false, true);
         /* End function include_jscripts */
      }

      protected void SubsflControlProps_1012( )
      {
         cmbavGridactions_Internalname = "vGRIDACTIONS_"+sGXsfl_101_idx;
         edtPoConcCod_Internalname = "POCONCCOD_"+sGXsfl_101_idx;
         edtPoConcDsc_Internalname = "POCONCDSC_"+sGXsfl_101_idx;
         cmbPoConcTip_Internalname = "POCONCTIP_"+sGXsfl_101_idx;
         cmbPoConcSts_Internalname = "POCONCSTS_"+sGXsfl_101_idx;
      }

      protected void SubsflControlProps_fel_1012( )
      {
         cmbavGridactions_Internalname = "vGRIDACTIONS_"+sGXsfl_101_fel_idx;
         edtPoConcCod_Internalname = "POCONCCOD_"+sGXsfl_101_fel_idx;
         edtPoConcDsc_Internalname = "POCONCDSC_"+sGXsfl_101_fel_idx;
         cmbPoConcTip_Internalname = "POCONCTIP_"+sGXsfl_101_fel_idx;
         cmbPoConcSts_Internalname = "POCONCSTS_"+sGXsfl_101_fel_idx;
      }

      protected void sendrow_1012( )
      {
         SubsflControlProps_1012( ) ;
         WB270( ) ;
         if ( ( subGrid_Rows * 1 == 0 ) || ( nGXsfl_101_idx <= subGrid_fnc_Recordsperpage( ) * 1 ) )
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
               if ( ((int)((nGXsfl_101_idx) % (2))) == 0 )
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
               context.WriteHtmlText( " class=\""+"GridWithPaginationBar WorkWith"+"\" style=\""+""+"\"") ;
               context.WriteHtmlText( " gxrow=\""+sGXsfl_101_idx+"\">") ;
            }
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"right"+"\""+" style=\""+""+"\">") ;
            }
            TempTags = " " + ((cmbavGridactions.Enabled!=0)&&(cmbavGridactions.Visible!=0) ? " onfocus=\"gx.evt.onfocus(this, 102,'',false,'"+sGXsfl_101_idx+"',101)\"" : " ");
            if ( ( cmbavGridactions.ItemCount == 0 ) && isAjaxCallMode( ) )
            {
               GXCCtl = "vGRIDACTIONS_" + sGXsfl_101_idx;
               cmbavGridactions.Name = GXCCtl;
               cmbavGridactions.WebTags = "";
               if ( cmbavGridactions.ItemCount > 0 )
               {
                  AV44GridActions = (short)(NumberUtil.Val( cmbavGridactions.getValidValue(StringUtil.Trim( StringUtil.Str( (decimal)(AV44GridActions), 4, 0))), "."));
                  AssignAttri("", false, cmbavGridactions_Internalname, StringUtil.LTrimStr( (decimal)(AV44GridActions), 4, 0));
               }
            }
            /* ComboBox */
            GridRow.AddColumnProperties("combobox", 2, isAjaxCallMode( ), new Object[] {(GXCombobox)cmbavGridactions,(string)cmbavGridactions_Internalname,StringUtil.Trim( StringUtil.Str( (decimal)(AV44GridActions), 4, 0)),(short)1,(string)cmbavGridactions_Jsonclick,(short)5,"'"+""+"'"+",false,"+"'"+"EVGRIDACTIONS.CLICK."+sGXsfl_101_idx+"'",(string)"int",(string)"",(short)-1,(short)1,(short)0,(short)0,(short)0,(string)"px",(short)0,(string)"px",(string)"",(string)"ConvertToDDO",(string)"WWActionGroupColumn",(string)"",TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+((cmbavGridactions.Enabled!=0)&&(cmbavGridactions.Visible!=0) ? " onblur=\""+""+";gx.evt.onblur(this,102);\"" : " "),(string)"",(bool)true,(short)1});
            cmbavGridactions.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV44GridActions), 4, 0));
            AssignProp("", false, cmbavGridactions_Internalname, "Values", (string)(cmbavGridactions.ToJavascriptSource()), !bGXsfl_101_Refreshing);
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"right"+"\""+" style=\""+""+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtPoConcCod_Internalname,StringUtil.LTrim( StringUtil.NToC( (decimal)(A313PoConcCod), 6, 0, ".", "")),StringUtil.LTrim( context.localUtil.Format( (decimal)(A313PoConcCod), "ZZZZZ9")),(string)" inputmode=\"numeric\" pattern=\"[0-9]*\""+"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtPoConcCod_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn hidden-xs",(string)"",(short)-1,(short)0,(short)0,(string)"text",(string)"1",(short)0,(string)"px",(short)17,(string)"px",(short)6,(short)0,(short)0,(short)101,(short)1,(short)-1,(short)0,(bool)true,(string)"",(string)"right",(bool)false,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"left"+"\""+" style=\""+""+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtPoConcDsc_Internalname,StringUtil.RTrim( A1648PoConcDsc),(string)"",(string)"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)edtPoConcDsc_Link,(string)"",(string)"",(string)"",(string)edtPoConcDsc_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn",(string)"",(short)-1,(short)0,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)100,(short)0,(short)0,(short)101,(short)1,(short)-1,(short)-1,(bool)true,(string)"",(string)"left",(bool)true,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"left"+"\""+" style=\""+""+"\">") ;
            }
            if ( ( cmbPoConcTip.ItemCount == 0 ) && isAjaxCallMode( ) )
            {
               GXCCtl = "POCONCTIP_" + sGXsfl_101_idx;
               cmbPoConcTip.Name = GXCCtl;
               cmbPoConcTip.WebTags = "";
               cmbPoConcTip.addItem("C", "Cantidad", 0);
               cmbPoConcTip.addItem("T", "Costo", 0);
               cmbPoConcTip.addItem("H", "Horas", 0);
               cmbPoConcTip.addItem("P", "Peso", 0);
               cmbPoConcTip.addItem("V", "Volumen", 0);
               if ( cmbPoConcTip.ItemCount > 0 )
               {
                  A1650PoConcTip = cmbPoConcTip.getValidValue(A1650PoConcTip);
               }
            }
            /* ComboBox */
            GridRow.AddColumnProperties("combobox", 2, isAjaxCallMode( ), new Object[] {(GXCombobox)cmbPoConcTip,(string)cmbPoConcTip_Internalname,StringUtil.RTrim( A1650PoConcTip),(short)1,(string)cmbPoConcTip_Jsonclick,(short)0,(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"char",(string)"",(short)-1,(short)0,(short)0,(short)0,(short)0,(string)"px",(short)0,(string)"px",(string)"",(string)"Attribute",(string)"WWColumn hidden-xs",(string)"",(string)"",(string)"",(bool)true,(short)1});
            cmbPoConcTip.CurrentValue = StringUtil.RTrim( A1650PoConcTip);
            AssignProp("", false, cmbPoConcTip_Internalname, "Values", (string)(cmbPoConcTip.ToJavascriptSource()), !bGXsfl_101_Refreshing);
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"right"+"\""+" style=\""+""+"\">") ;
            }
            if ( ( cmbPoConcSts.ItemCount == 0 ) && isAjaxCallMode( ) )
            {
               GXCCtl = "POCONCSTS_" + sGXsfl_101_idx;
               cmbPoConcSts.Name = GXCCtl;
               cmbPoConcSts.WebTags = "";
               cmbPoConcSts.addItem("1", "ACTIVO", 0);
               cmbPoConcSts.addItem("0", "INACTIVO", 0);
               if ( cmbPoConcSts.ItemCount > 0 )
               {
                  A1649PoConcSts = (short)(NumberUtil.Val( cmbPoConcSts.getValidValue(StringUtil.Trim( StringUtil.Str( (decimal)(A1649PoConcSts), 1, 0))), "."));
               }
            }
            /* ComboBox */
            GridRow.AddColumnProperties("combobox", 2, isAjaxCallMode( ), new Object[] {(GXCombobox)cmbPoConcSts,(string)cmbPoConcSts_Internalname,StringUtil.Trim( StringUtil.Str( (decimal)(A1649PoConcSts), 1, 0)),(short)1,(string)cmbPoConcSts_Jsonclick,(short)0,(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"int",(string)"",(short)-1,(short)0,(short)0,(short)0,(short)0,(string)"px",(short)0,(string)"px",(string)"",(string)"Attribute",(string)"WWColumn hidden-xs",(string)"",(string)"",(string)"",(bool)true,(short)1});
            cmbPoConcSts.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(A1649PoConcSts), 1, 0));
            AssignProp("", false, cmbPoConcSts_Internalname, "Values", (string)(cmbPoConcSts.ToJavascriptSource()), !bGXsfl_101_Refreshing);
            send_integrity_lvl_hashes272( ) ;
            GridContainer.AddRow(GridRow);
            nGXsfl_101_idx = ((subGrid_Islastpage==1)&&(nGXsfl_101_idx+1>subGrid_fnc_Recordsperpage( )) ? 1 : nGXsfl_101_idx+1);
            sGXsfl_101_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_101_idx), 4, 0), 4, "0");
            SubsflControlProps_1012( ) ;
         }
         /* End function sendrow_1012 */
      }

      protected void init_web_controls( )
      {
         cmbavDynamicfiltersselector1.Name = "vDYNAMICFILTERSSELECTOR1";
         cmbavDynamicfiltersselector1.WebTags = "";
         cmbavDynamicfiltersselector1.addItem("POCONCDSC", "Concepto", 0);
         if ( cmbavDynamicfiltersselector1.ItemCount > 0 )
         {
            AV15DynamicFiltersSelector1 = cmbavDynamicfiltersselector1.getValidValue(AV15DynamicFiltersSelector1);
            AssignAttri("", false, "AV15DynamicFiltersSelector1", AV15DynamicFiltersSelector1);
         }
         cmbavDynamicfiltersoperator1.Name = "vDYNAMICFILTERSOPERATOR1";
         cmbavDynamicfiltersoperator1.WebTags = "";
         cmbavDynamicfiltersoperator1.addItem("0", "Comienza con", 0);
         cmbavDynamicfiltersoperator1.addItem("1", "Contiene", 0);
         if ( cmbavDynamicfiltersoperator1.ItemCount > 0 )
         {
            AV16DynamicFiltersOperator1 = (short)(NumberUtil.Val( cmbavDynamicfiltersoperator1.getValidValue(StringUtil.Trim( StringUtil.Str( (decimal)(AV16DynamicFiltersOperator1), 4, 0))), "."));
            AssignAttri("", false, "AV16DynamicFiltersOperator1", StringUtil.LTrimStr( (decimal)(AV16DynamicFiltersOperator1), 4, 0));
         }
         cmbavDynamicfiltersselector2.Name = "vDYNAMICFILTERSSELECTOR2";
         cmbavDynamicfiltersselector2.WebTags = "";
         cmbavDynamicfiltersselector2.addItem("POCONCDSC", "Concepto", 0);
         if ( cmbavDynamicfiltersselector2.ItemCount > 0 )
         {
            AV19DynamicFiltersSelector2 = cmbavDynamicfiltersselector2.getValidValue(AV19DynamicFiltersSelector2);
            AssignAttri("", false, "AV19DynamicFiltersSelector2", AV19DynamicFiltersSelector2);
         }
         cmbavDynamicfiltersoperator2.Name = "vDYNAMICFILTERSOPERATOR2";
         cmbavDynamicfiltersoperator2.WebTags = "";
         cmbavDynamicfiltersoperator2.addItem("0", "Comienza con", 0);
         cmbavDynamicfiltersoperator2.addItem("1", "Contiene", 0);
         if ( cmbavDynamicfiltersoperator2.ItemCount > 0 )
         {
            AV20DynamicFiltersOperator2 = (short)(NumberUtil.Val( cmbavDynamicfiltersoperator2.getValidValue(StringUtil.Trim( StringUtil.Str( (decimal)(AV20DynamicFiltersOperator2), 4, 0))), "."));
            AssignAttri("", false, "AV20DynamicFiltersOperator2", StringUtil.LTrimStr( (decimal)(AV20DynamicFiltersOperator2), 4, 0));
         }
         cmbavDynamicfiltersselector3.Name = "vDYNAMICFILTERSSELECTOR3";
         cmbavDynamicfiltersselector3.WebTags = "";
         cmbavDynamicfiltersselector3.addItem("POCONCDSC", "Concepto", 0);
         if ( cmbavDynamicfiltersselector3.ItemCount > 0 )
         {
            AV23DynamicFiltersSelector3 = cmbavDynamicfiltersselector3.getValidValue(AV23DynamicFiltersSelector3);
            AssignAttri("", false, "AV23DynamicFiltersSelector3", AV23DynamicFiltersSelector3);
         }
         cmbavDynamicfiltersoperator3.Name = "vDYNAMICFILTERSOPERATOR3";
         cmbavDynamicfiltersoperator3.WebTags = "";
         cmbavDynamicfiltersoperator3.addItem("0", "Comienza con", 0);
         cmbavDynamicfiltersoperator3.addItem("1", "Contiene", 0);
         if ( cmbavDynamicfiltersoperator3.ItemCount > 0 )
         {
            AV24DynamicFiltersOperator3 = (short)(NumberUtil.Val( cmbavDynamicfiltersoperator3.getValidValue(StringUtil.Trim( StringUtil.Str( (decimal)(AV24DynamicFiltersOperator3), 4, 0))), "."));
            AssignAttri("", false, "AV24DynamicFiltersOperator3", StringUtil.LTrimStr( (decimal)(AV24DynamicFiltersOperator3), 4, 0));
         }
         GXCCtl = "vGRIDACTIONS_" + sGXsfl_101_idx;
         cmbavGridactions.Name = GXCCtl;
         cmbavGridactions.WebTags = "";
         if ( cmbavGridactions.ItemCount > 0 )
         {
            AV44GridActions = (short)(NumberUtil.Val( cmbavGridactions.getValidValue(StringUtil.Trim( StringUtil.Str( (decimal)(AV44GridActions), 4, 0))), "."));
            AssignAttri("", false, cmbavGridactions_Internalname, StringUtil.LTrimStr( (decimal)(AV44GridActions), 4, 0));
         }
         GXCCtl = "POCONCTIP_" + sGXsfl_101_idx;
         cmbPoConcTip.Name = GXCCtl;
         cmbPoConcTip.WebTags = "";
         cmbPoConcTip.addItem("C", "Cantidad", 0);
         cmbPoConcTip.addItem("T", "Costo", 0);
         cmbPoConcTip.addItem("H", "Horas", 0);
         cmbPoConcTip.addItem("P", "Peso", 0);
         cmbPoConcTip.addItem("V", "Volumen", 0);
         if ( cmbPoConcTip.ItemCount > 0 )
         {
            A1650PoConcTip = cmbPoConcTip.getValidValue(A1650PoConcTip);
         }
         GXCCtl = "POCONCSTS_" + sGXsfl_101_idx;
         cmbPoConcSts.Name = GXCCtl;
         cmbPoConcSts.WebTags = "";
         cmbPoConcSts.addItem("1", "ACTIVO", 0);
         cmbPoConcSts.addItem("0", "INACTIVO", 0);
         if ( cmbPoConcSts.ItemCount > 0 )
         {
            A1649PoConcSts = (short)(NumberUtil.Val( cmbPoConcSts.getValidValue(StringUtil.Trim( StringUtil.Str( (decimal)(A1649PoConcSts), 1, 0))), "."));
         }
         /* End function init_web_controls */
      }

      protected void init_default_properties( )
      {
         bttBtninsert_Internalname = "BTNINSERT";
         bttBtnagexport_Internalname = "BTNAGEXPORT";
         divTableactions_Internalname = "TABLEACTIONS";
         lblDynamicfiltersprefix1_Internalname = "DYNAMICFILTERSPREFIX1";
         cmbavDynamicfiltersselector1_Internalname = "vDYNAMICFILTERSSELECTOR1";
         lblDynamicfiltersmiddle1_Internalname = "DYNAMICFILTERSMIDDLE1";
         cmbavDynamicfiltersoperator1_Internalname = "vDYNAMICFILTERSOPERATOR1";
         edtavPoconcdsc1_Internalname = "vPOCONCDSC1";
         cellFilter_poconcdsc1_cell_Internalname = "FILTER_POCONCDSC1_CELL";
         imgAdddynamicfilters1_Internalname = "ADDDYNAMICFILTERS1";
         cellDynamicfilters_addfilter1_cell_Internalname = "DYNAMICFILTERS_ADDFILTER1_CELL";
         imgRemovedynamicfilters1_Internalname = "REMOVEDYNAMICFILTERS1";
         cellDynamicfilters_removefilter1_cell_Internalname = "DYNAMICFILTERS_REMOVEFILTER1_CELL";
         tblTablemergeddynamicfilters1_Internalname = "TABLEMERGEDDYNAMICFILTERS1";
         divTabledynamicfiltersrow1_Internalname = "TABLEDYNAMICFILTERSROW1";
         lblDynamicfiltersprefix2_Internalname = "DYNAMICFILTERSPREFIX2";
         cmbavDynamicfiltersselector2_Internalname = "vDYNAMICFILTERSSELECTOR2";
         lblDynamicfiltersmiddle2_Internalname = "DYNAMICFILTERSMIDDLE2";
         cmbavDynamicfiltersoperator2_Internalname = "vDYNAMICFILTERSOPERATOR2";
         edtavPoconcdsc2_Internalname = "vPOCONCDSC2";
         cellFilter_poconcdsc2_cell_Internalname = "FILTER_POCONCDSC2_CELL";
         imgAdddynamicfilters2_Internalname = "ADDDYNAMICFILTERS2";
         cellDynamicfilters_addfilter2_cell_Internalname = "DYNAMICFILTERS_ADDFILTER2_CELL";
         imgRemovedynamicfilters2_Internalname = "REMOVEDYNAMICFILTERS2";
         cellDynamicfilters_removefilter2_cell_Internalname = "DYNAMICFILTERS_REMOVEFILTER2_CELL";
         tblTablemergeddynamicfilters2_Internalname = "TABLEMERGEDDYNAMICFILTERS2";
         divTabledynamicfiltersrow2_Internalname = "TABLEDYNAMICFILTERSROW2";
         lblDynamicfiltersprefix3_Internalname = "DYNAMICFILTERSPREFIX3";
         cmbavDynamicfiltersselector3_Internalname = "vDYNAMICFILTERSSELECTOR3";
         lblDynamicfiltersmiddle3_Internalname = "DYNAMICFILTERSMIDDLE3";
         cmbavDynamicfiltersoperator3_Internalname = "vDYNAMICFILTERSOPERATOR3";
         edtavPoconcdsc3_Internalname = "vPOCONCDSC3";
         cellFilter_poconcdsc3_cell_Internalname = "FILTER_POCONCDSC3_CELL";
         imgRemovedynamicfilters3_Internalname = "REMOVEDYNAMICFILTERS3";
         cellDynamicfilters_removefilter3_cell_Internalname = "DYNAMICFILTERS_REMOVEFILTER3_CELL";
         tblTablemergeddynamicfilters3_Internalname = "TABLEMERGEDDYNAMICFILTERS3";
         divTabledynamicfiltersrow3_Internalname = "TABLEDYNAMICFILTERSROW3";
         divTabledynamicfilters_Internalname = "TABLEDYNAMICFILTERS";
         tblTablefilters_Internalname = "TABLEFILTERS";
         divTablerightheader_Internalname = "TABLERIGHTHEADER";
         divTableheadercontent_Internalname = "TABLEHEADERCONTENT";
         divTableheader_Internalname = "TABLEHEADER";
         Dvpanel_tableheader_Internalname = "DVPANEL_TABLEHEADER";
         cmbavGridactions_Internalname = "vGRIDACTIONS";
         edtPoConcCod_Internalname = "POCONCCOD";
         edtPoConcDsc_Internalname = "POCONCDSC";
         cmbPoConcTip_Internalname = "POCONCTIP";
         cmbPoConcSts_Internalname = "POCONCSTS";
         Gridpaginationbar_Internalname = "GRIDPAGINATIONBAR";
         divGridtablewithpaginationbar_Internalname = "GRIDTABLEWITHPAGINATIONBAR";
         divTablemain_Internalname = "TABLEMAIN";
         Ddo_agexport_Internalname = "DDO_AGEXPORT";
         lblJsdynamicfilters_Internalname = "JSDYNAMICFILTERS";
         Ddo_grid_Internalname = "DDO_GRID";
         Innewwindow1_Internalname = "INNEWWINDOW1";
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
         cmbPoConcSts_Jsonclick = "";
         cmbPoConcTip_Jsonclick = "";
         edtPoConcDsc_Jsonclick = "";
         edtPoConcCod_Jsonclick = "";
         cmbavGridactions_Jsonclick = "";
         cmbavGridactions.Visible = -1;
         cmbavGridactions.Enabled = 1;
         imgRemovedynamicfilters1_Visible = 1;
         imgAdddynamicfilters1_Visible = 1;
         edtavPoconcdsc1_Jsonclick = "";
         edtavPoconcdsc1_Enabled = 1;
         cmbavDynamicfiltersoperator1_Jsonclick = "";
         cmbavDynamicfiltersoperator1.Enabled = 1;
         imgRemovedynamicfilters2_Visible = 1;
         imgAdddynamicfilters2_Visible = 1;
         edtavPoconcdsc2_Jsonclick = "";
         edtavPoconcdsc2_Enabled = 1;
         cmbavDynamicfiltersoperator2_Jsonclick = "";
         cmbavDynamicfiltersoperator2.Enabled = 1;
         edtavPoconcdsc3_Jsonclick = "";
         edtavPoconcdsc3_Enabled = 1;
         cmbavDynamicfiltersoperator3_Jsonclick = "";
         cmbavDynamicfiltersoperator3.Enabled = 1;
         cmbavDynamicfiltersselector3_Jsonclick = "";
         cmbavDynamicfiltersselector3.Enabled = 1;
         cmbavDynamicfiltersselector2_Jsonclick = "";
         cmbavDynamicfiltersselector2.Enabled = 1;
         cmbavDynamicfiltersselector1_Jsonclick = "";
         cmbavDynamicfiltersselector1.Enabled = 1;
         cmbavDynamicfiltersoperator3.Visible = 1;
         edtavPoconcdsc3_Visible = 1;
         cmbavDynamicfiltersoperator2.Visible = 1;
         edtavPoconcdsc2_Visible = 1;
         cmbavDynamicfiltersoperator1.Visible = 1;
         edtavPoconcdsc1_Visible = 1;
         lblJsdynamicfilters_Caption = "JSDynamicFilters";
         subGrid_Allowcollapsing = 0;
         subGrid_Allowselection = 0;
         edtPoConcDsc_Link = "";
         subGrid_Sortable = 0;
         subGrid_Header = "";
         subGrid_Class = "GridWithPaginationBar WorkWith";
         subGrid_Backcolorstyle = 0;
         Grid_empowerer_Hastitlesettings = Convert.ToBoolean( -1);
         Innewwindow1_Target = "";
         Innewwindow1_Height = "50";
         Innewwindow1_Width = "50";
         Ddo_grid_Datalistproc = "Produccion.ConceptosOrdenesProduccionWWGetFilterData";
         Ddo_grid_Datalistfixedvalues = "||C:Cantidad,T:Costo,H:Horas,P:Peso,V:Volumen|1:ACTIVO,0:INACTIVO";
         Ddo_grid_Allowmultipleselection = "||T|T";
         Ddo_grid_Datalisttype = "|Dynamic|FixedValues|FixedValues";
         Ddo_grid_Includedatalist = "|T|T|T";
         Ddo_grid_Filterisrange = "T|||";
         Ddo_grid_Filtertype = "Numeric|Character||";
         Ddo_grid_Includefilter = "T|T||";
         Ddo_grid_Includesortasc = "T";
         Ddo_grid_Columnssortvalues = "2|1|3|4";
         Ddo_grid_Columnids = "1:PoConcCod|2:PoConcDsc|3:PoConcTip|4:PoConcSts";
         Ddo_grid_Gridinternalname = "";
         Ddo_agexport_Titlecontrolidtoreplace = "";
         Ddo_agexport_Cls = "ColumnsSelector";
         Ddo_agexport_Icon = "fas fa-download";
         Ddo_agexport_Icontype = "FontIcon";
         Gridpaginationbar_Rowsperpagecaption = "WWP_PagingRowsPerPage";
         Gridpaginationbar_Emptygridcaption = "WWP_PagingEmptyGridCaption";
         Gridpaginationbar_Caption = "P?gina <CURRENT_PAGE> de <TOTAL_PAGES>";
         Gridpaginationbar_Next = "WWP_PagingNextCaption";
         Gridpaginationbar_Previous = "WWP_PagingPreviousCaption";
         Gridpaginationbar_Rowsperpageoptions = "5:WWP_Rows5,10:WWP_Rows10,20:WWP_Rows20,50:WWP_Rows50";
         Gridpaginationbar_Rowsperpageselectedvalue = 10;
         Gridpaginationbar_Rowsperpageselector = Convert.ToBoolean( -1);
         Gridpaginationbar_Emptygridclass = "PaginationBarEmptyGrid";
         Gridpaginationbar_Pagingcaptionposition = "Left";
         Gridpaginationbar_Pagingbuttonsposition = "Right";
         Gridpaginationbar_Pagestoshow = 5;
         Gridpaginationbar_Showlast = Convert.ToBoolean( 0);
         Gridpaginationbar_Shownext = Convert.ToBoolean( -1);
         Gridpaginationbar_Showprevious = Convert.ToBoolean( -1);
         Gridpaginationbar_Showfirst = Convert.ToBoolean( 0);
         Gridpaginationbar_Class = "PaginationBar";
         Dvpanel_tableheader_Autoscroll = Convert.ToBoolean( 0);
         Dvpanel_tableheader_Iconposition = "Right";
         Dvpanel_tableheader_Showcollapseicon = Convert.ToBoolean( 0);
         Dvpanel_tableheader_Collapsed = Convert.ToBoolean( 0);
         Dvpanel_tableheader_Collapsible = Convert.ToBoolean( -1);
         Dvpanel_tableheader_Title = "Opciones";
         Dvpanel_tableheader_Cls = "PanelNoHeader";
         Dvpanel_tableheader_Autoheight = Convert.ToBoolean( -1);
         Dvpanel_tableheader_Autowidth = Convert.ToBoolean( 0);
         Dvpanel_tableheader_Width = "100%";
         Form.Headerrawhtml = "";
         Form.Background = "";
         Form.Textcolor = 0;
         Form.Backcolor = (int)(0xFFFFFF);
         Form.Caption = " Conceptos de Ordenes de Produccion";
         subGrid_Rows = 0;
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
         setEventMetadata("REFRESH","{handler:'Refresh',iparms:[{av:'GRID_nFirstRecordOnPage'},{av:'GRID_nEOF'},{av:'subGrid_Rows',ctrl:'GRID',prop:'Rows'},{av:'cmbavDynamicfiltersselector1'},{av:'AV15DynamicFiltersSelector1',fld:'vDYNAMICFILTERSSELECTOR1',pic:''},{av:'cmbavDynamicfiltersoperator1'},{av:'AV16DynamicFiltersOperator1',fld:'vDYNAMICFILTERSOPERATOR1',pic:'ZZZ9'},{av:'AV17PoConcDsc1',fld:'vPOCONCDSC1',pic:''},{av:'cmbavDynamicfiltersselector2'},{av:'AV19DynamicFiltersSelector2',fld:'vDYNAMICFILTERSSELECTOR2',pic:''},{av:'cmbavDynamicfiltersoperator2'},{av:'AV20DynamicFiltersOperator2',fld:'vDYNAMICFILTERSOPERATOR2',pic:'ZZZ9'},{av:'AV21PoConcDsc2',fld:'vPOCONCDSC2',pic:''},{av:'cmbavDynamicfiltersselector3'},{av:'AV23DynamicFiltersSelector3',fld:'vDYNAMICFILTERSSELECTOR3',pic:''},{av:'cmbavDynamicfiltersoperator3'},{av:'AV24DynamicFiltersOperator3',fld:'vDYNAMICFILTERSOPERATOR3',pic:'ZZZ9'},{av:'AV25PoConcDsc3',fld:'vPOCONCDSC3',pic:''},{av:'AV51Pgmname',fld:'vPGMNAME',pic:'',hsh:true},{av:'AV18DynamicFiltersEnabled2',fld:'vDYNAMICFILTERSENABLED2',pic:''},{av:'AV22DynamicFiltersEnabled3',fld:'vDYNAMICFILTERSENABLED3',pic:''},{av:'AV31TFPoConcCod',fld:'vTFPOCONCCOD',pic:'ZZZZZ9'},{av:'AV32TFPoConcCod_To',fld:'vTFPOCONCCOD_TO',pic:'ZZZZZ9'},{av:'AV33TFPoConcDsc',fld:'vTFPOCONCDSC',pic:''},{av:'AV34TFPoConcDsc_Sel',fld:'vTFPOCONCDSC_SEL',pic:''},{av:'AV48TFPoConcTip_Sels',fld:'vTFPOCONCTIP_SELS',pic:''},{av:'AV38TFPoConcSts_Sels',fld:'vTFPOCONCSTS_SELS',pic:''},{av:'AV13OrderedBy',fld:'vORDEREDBY',pic:'ZZZ9'},{av:'AV14OrderedDsc',fld:'vORDEREDDSC',pic:''},{av:'AV10GridState',fld:'vGRIDSTATE',pic:''},{av:'AV27DynamicFiltersIgnoreFirst',fld:'vDYNAMICFILTERSIGNOREFIRST',pic:''},{av:'AV26DynamicFiltersRemoving',fld:'vDYNAMICFILTERSREMOVING',pic:''}]");
         setEventMetadata("REFRESH",",oparms:[{av:'AV41GridCurrentPage',fld:'vGRIDCURRENTPAGE',pic:'ZZZZZZZZZ9'},{av:'AV42GridPageCount',fld:'vGRIDPAGECOUNT',pic:'ZZZZZZZZZ9'},{av:'AV43GridAppliedFilters',fld:'vGRIDAPPLIEDFILTERS',pic:''},{av:'AV10GridState',fld:'vGRIDSTATE',pic:''}]}");
         setEventMetadata("GRIDPAGINATIONBAR.CHANGEPAGE","{handler:'E11272',iparms:[{av:'GRID_nFirstRecordOnPage'},{av:'GRID_nEOF'},{av:'subGrid_Rows',ctrl:'GRID',prop:'Rows'},{av:'cmbavDynamicfiltersselector1'},{av:'AV15DynamicFiltersSelector1',fld:'vDYNAMICFILTERSSELECTOR1',pic:''},{av:'cmbavDynamicfiltersoperator1'},{av:'AV16DynamicFiltersOperator1',fld:'vDYNAMICFILTERSOPERATOR1',pic:'ZZZ9'},{av:'AV17PoConcDsc1',fld:'vPOCONCDSC1',pic:''},{av:'cmbavDynamicfiltersselector2'},{av:'AV19DynamicFiltersSelector2',fld:'vDYNAMICFILTERSSELECTOR2',pic:''},{av:'cmbavDynamicfiltersoperator2'},{av:'AV20DynamicFiltersOperator2',fld:'vDYNAMICFILTERSOPERATOR2',pic:'ZZZ9'},{av:'AV21PoConcDsc2',fld:'vPOCONCDSC2',pic:''},{av:'cmbavDynamicfiltersselector3'},{av:'AV23DynamicFiltersSelector3',fld:'vDYNAMICFILTERSSELECTOR3',pic:''},{av:'cmbavDynamicfiltersoperator3'},{av:'AV24DynamicFiltersOperator3',fld:'vDYNAMICFILTERSOPERATOR3',pic:'ZZZ9'},{av:'AV25PoConcDsc3',fld:'vPOCONCDSC3',pic:''},{av:'AV51Pgmname',fld:'vPGMNAME',pic:'',hsh:true},{av:'AV18DynamicFiltersEnabled2',fld:'vDYNAMICFILTERSENABLED2',pic:''},{av:'AV22DynamicFiltersEnabled3',fld:'vDYNAMICFILTERSENABLED3',pic:''},{av:'AV31TFPoConcCod',fld:'vTFPOCONCCOD',pic:'ZZZZZ9'},{av:'AV32TFPoConcCod_To',fld:'vTFPOCONCCOD_TO',pic:'ZZZZZ9'},{av:'AV33TFPoConcDsc',fld:'vTFPOCONCDSC',pic:''},{av:'AV34TFPoConcDsc_Sel',fld:'vTFPOCONCDSC_SEL',pic:''},{av:'AV48TFPoConcTip_Sels',fld:'vTFPOCONCTIP_SELS',pic:''},{av:'AV38TFPoConcSts_Sels',fld:'vTFPOCONCSTS_SELS',pic:''},{av:'AV13OrderedBy',fld:'vORDEREDBY',pic:'ZZZ9'},{av:'AV14OrderedDsc',fld:'vORDEREDDSC',pic:''},{av:'AV10GridState',fld:'vGRIDSTATE',pic:''},{av:'AV27DynamicFiltersIgnoreFirst',fld:'vDYNAMICFILTERSIGNOREFIRST',pic:''},{av:'AV26DynamicFiltersRemoving',fld:'vDYNAMICFILTERSREMOVING',pic:''},{av:'Gridpaginationbar_Selectedpage',ctrl:'GRIDPAGINATIONBAR',prop:'SelectedPage'}]");
         setEventMetadata("GRIDPAGINATIONBAR.CHANGEPAGE",",oparms:[]}");
         setEventMetadata("GRIDPAGINATIONBAR.CHANGEROWSPERPAGE","{handler:'E12272',iparms:[{av:'GRID_nFirstRecordOnPage'},{av:'GRID_nEOF'},{av:'subGrid_Rows',ctrl:'GRID',prop:'Rows'},{av:'cmbavDynamicfiltersselector1'},{av:'AV15DynamicFiltersSelector1',fld:'vDYNAMICFILTERSSELECTOR1',pic:''},{av:'cmbavDynamicfiltersoperator1'},{av:'AV16DynamicFiltersOperator1',fld:'vDYNAMICFILTERSOPERATOR1',pic:'ZZZ9'},{av:'AV17PoConcDsc1',fld:'vPOCONCDSC1',pic:''},{av:'cmbavDynamicfiltersselector2'},{av:'AV19DynamicFiltersSelector2',fld:'vDYNAMICFILTERSSELECTOR2',pic:''},{av:'cmbavDynamicfiltersoperator2'},{av:'AV20DynamicFiltersOperator2',fld:'vDYNAMICFILTERSOPERATOR2',pic:'ZZZ9'},{av:'AV21PoConcDsc2',fld:'vPOCONCDSC2',pic:''},{av:'cmbavDynamicfiltersselector3'},{av:'AV23DynamicFiltersSelector3',fld:'vDYNAMICFILTERSSELECTOR3',pic:''},{av:'cmbavDynamicfiltersoperator3'},{av:'AV24DynamicFiltersOperator3',fld:'vDYNAMICFILTERSOPERATOR3',pic:'ZZZ9'},{av:'AV25PoConcDsc3',fld:'vPOCONCDSC3',pic:''},{av:'AV51Pgmname',fld:'vPGMNAME',pic:'',hsh:true},{av:'AV18DynamicFiltersEnabled2',fld:'vDYNAMICFILTERSENABLED2',pic:''},{av:'AV22DynamicFiltersEnabled3',fld:'vDYNAMICFILTERSENABLED3',pic:''},{av:'AV31TFPoConcCod',fld:'vTFPOCONCCOD',pic:'ZZZZZ9'},{av:'AV32TFPoConcCod_To',fld:'vTFPOCONCCOD_TO',pic:'ZZZZZ9'},{av:'AV33TFPoConcDsc',fld:'vTFPOCONCDSC',pic:''},{av:'AV34TFPoConcDsc_Sel',fld:'vTFPOCONCDSC_SEL',pic:''},{av:'AV48TFPoConcTip_Sels',fld:'vTFPOCONCTIP_SELS',pic:''},{av:'AV38TFPoConcSts_Sels',fld:'vTFPOCONCSTS_SELS',pic:''},{av:'AV13OrderedBy',fld:'vORDEREDBY',pic:'ZZZ9'},{av:'AV14OrderedDsc',fld:'vORDEREDDSC',pic:''},{av:'AV10GridState',fld:'vGRIDSTATE',pic:''},{av:'AV27DynamicFiltersIgnoreFirst',fld:'vDYNAMICFILTERSIGNOREFIRST',pic:''},{av:'AV26DynamicFiltersRemoving',fld:'vDYNAMICFILTERSREMOVING',pic:''},{av:'Gridpaginationbar_Rowsperpageselectedvalue',ctrl:'GRIDPAGINATIONBAR',prop:'RowsPerPageSelectedValue'}]");
         setEventMetadata("GRIDPAGINATIONBAR.CHANGEROWSPERPAGE",",oparms:[{av:'subGrid_Rows',ctrl:'GRID',prop:'Rows'}]}");
         setEventMetadata("DDO_GRID.ONOPTIONCLICKED","{handler:'E14272',iparms:[{av:'GRID_nFirstRecordOnPage'},{av:'GRID_nEOF'},{av:'subGrid_Rows',ctrl:'GRID',prop:'Rows'},{av:'cmbavDynamicfiltersselector1'},{av:'AV15DynamicFiltersSelector1',fld:'vDYNAMICFILTERSSELECTOR1',pic:''},{av:'cmbavDynamicfiltersoperator1'},{av:'AV16DynamicFiltersOperator1',fld:'vDYNAMICFILTERSOPERATOR1',pic:'ZZZ9'},{av:'AV17PoConcDsc1',fld:'vPOCONCDSC1',pic:''},{av:'cmbavDynamicfiltersselector2'},{av:'AV19DynamicFiltersSelector2',fld:'vDYNAMICFILTERSSELECTOR2',pic:''},{av:'cmbavDynamicfiltersoperator2'},{av:'AV20DynamicFiltersOperator2',fld:'vDYNAMICFILTERSOPERATOR2',pic:'ZZZ9'},{av:'AV21PoConcDsc2',fld:'vPOCONCDSC2',pic:''},{av:'cmbavDynamicfiltersselector3'},{av:'AV23DynamicFiltersSelector3',fld:'vDYNAMICFILTERSSELECTOR3',pic:''},{av:'cmbavDynamicfiltersoperator3'},{av:'AV24DynamicFiltersOperator3',fld:'vDYNAMICFILTERSOPERATOR3',pic:'ZZZ9'},{av:'AV25PoConcDsc3',fld:'vPOCONCDSC3',pic:''},{av:'AV51Pgmname',fld:'vPGMNAME',pic:'',hsh:true},{av:'AV18DynamicFiltersEnabled2',fld:'vDYNAMICFILTERSENABLED2',pic:''},{av:'AV22DynamicFiltersEnabled3',fld:'vDYNAMICFILTERSENABLED3',pic:''},{av:'AV31TFPoConcCod',fld:'vTFPOCONCCOD',pic:'ZZZZZ9'},{av:'AV32TFPoConcCod_To',fld:'vTFPOCONCCOD_TO',pic:'ZZZZZ9'},{av:'AV33TFPoConcDsc',fld:'vTFPOCONCDSC',pic:''},{av:'AV34TFPoConcDsc_Sel',fld:'vTFPOCONCDSC_SEL',pic:''},{av:'AV48TFPoConcTip_Sels',fld:'vTFPOCONCTIP_SELS',pic:''},{av:'AV38TFPoConcSts_Sels',fld:'vTFPOCONCSTS_SELS',pic:''},{av:'AV13OrderedBy',fld:'vORDEREDBY',pic:'ZZZ9'},{av:'AV14OrderedDsc',fld:'vORDEREDDSC',pic:''},{av:'AV10GridState',fld:'vGRIDSTATE',pic:''},{av:'AV27DynamicFiltersIgnoreFirst',fld:'vDYNAMICFILTERSIGNOREFIRST',pic:''},{av:'AV26DynamicFiltersRemoving',fld:'vDYNAMICFILTERSREMOVING',pic:''},{av:'Ddo_grid_Activeeventkey',ctrl:'DDO_GRID',prop:'ActiveEventKey'},{av:'Ddo_grid_Selectedvalue_get',ctrl:'DDO_GRID',prop:'SelectedValue_get'},{av:'Ddo_grid_Selectedcolumn',ctrl:'DDO_GRID',prop:'SelectedColumn'},{av:'Ddo_grid_Filteredtext_get',ctrl:'DDO_GRID',prop:'FilteredText_get'},{av:'Ddo_grid_Filteredtextto_get',ctrl:'DDO_GRID',prop:'FilteredTextTo_get'}]");
         setEventMetadata("DDO_GRID.ONOPTIONCLICKED",",oparms:[{av:'AV13OrderedBy',fld:'vORDEREDBY',pic:'ZZZ9'},{av:'AV14OrderedDsc',fld:'vORDEREDDSC',pic:''},{av:'AV31TFPoConcCod',fld:'vTFPOCONCCOD',pic:'ZZZZZ9'},{av:'AV32TFPoConcCod_To',fld:'vTFPOCONCCOD_TO',pic:'ZZZZZ9'},{av:'AV33TFPoConcDsc',fld:'vTFPOCONCDSC',pic:''},{av:'AV34TFPoConcDsc_Sel',fld:'vTFPOCONCDSC_SEL',pic:''},{av:'AV47TFPoConcTip_SelsJson',fld:'vTFPOCONCTIP_SELSJSON',pic:''},{av:'AV48TFPoConcTip_Sels',fld:'vTFPOCONCTIP_SELS',pic:''},{av:'AV37TFPoConcSts_SelsJson',fld:'vTFPOCONCSTS_SELSJSON',pic:''},{av:'AV38TFPoConcSts_Sels',fld:'vTFPOCONCSTS_SELS',pic:''},{av:'Ddo_grid_Sortedstatus',ctrl:'DDO_GRID',prop:'SortedStatus'}]}");
         setEventMetadata("GRID.LOAD","{handler:'E26272',iparms:[{av:'A313PoConcCod',fld:'POCONCCOD',pic:'ZZZZZ9',hsh:true}]");
         setEventMetadata("GRID.LOAD",",oparms:[{av:'cmbavGridactions'},{av:'AV44GridActions',fld:'vGRIDACTIONS',pic:'ZZZ9'},{av:'edtPoConcDsc_Link',ctrl:'POCONCDSC',prop:'Link'}]}");
         setEventMetadata("'ADDDYNAMICFILTERS1'","{handler:'E19272',iparms:[]");
         setEventMetadata("'ADDDYNAMICFILTERS1'",",oparms:[{av:'AV18DynamicFiltersEnabled2',fld:'vDYNAMICFILTERSENABLED2',pic:''},{av:'imgAdddynamicfilters1_Visible',ctrl:'ADDDYNAMICFILTERS1',prop:'Visible'},{av:'imgRemovedynamicfilters1_Visible',ctrl:'REMOVEDYNAMICFILTERS1',prop:'Visible'}]}");
         setEventMetadata("'REMOVEDYNAMICFILTERS1'","{handler:'E15272',iparms:[{av:'GRID_nFirstRecordOnPage'},{av:'GRID_nEOF'},{av:'subGrid_Rows',ctrl:'GRID',prop:'Rows'},{av:'cmbavDynamicfiltersselector1'},{av:'AV15DynamicFiltersSelector1',fld:'vDYNAMICFILTERSSELECTOR1',pic:''},{av:'cmbavDynamicfiltersoperator1'},{av:'AV16DynamicFiltersOperator1',fld:'vDYNAMICFILTERSOPERATOR1',pic:'ZZZ9'},{av:'AV17PoConcDsc1',fld:'vPOCONCDSC1',pic:''},{av:'cmbavDynamicfiltersselector2'},{av:'AV19DynamicFiltersSelector2',fld:'vDYNAMICFILTERSSELECTOR2',pic:''},{av:'cmbavDynamicfiltersoperator2'},{av:'AV20DynamicFiltersOperator2',fld:'vDYNAMICFILTERSOPERATOR2',pic:'ZZZ9'},{av:'AV21PoConcDsc2',fld:'vPOCONCDSC2',pic:''},{av:'cmbavDynamicfiltersselector3'},{av:'AV23DynamicFiltersSelector3',fld:'vDYNAMICFILTERSSELECTOR3',pic:''},{av:'cmbavDynamicfiltersoperator3'},{av:'AV24DynamicFiltersOperator3',fld:'vDYNAMICFILTERSOPERATOR3',pic:'ZZZ9'},{av:'AV25PoConcDsc3',fld:'vPOCONCDSC3',pic:''},{av:'AV51Pgmname',fld:'vPGMNAME',pic:'',hsh:true},{av:'AV18DynamicFiltersEnabled2',fld:'vDYNAMICFILTERSENABLED2',pic:''},{av:'AV22DynamicFiltersEnabled3',fld:'vDYNAMICFILTERSENABLED3',pic:''},{av:'AV31TFPoConcCod',fld:'vTFPOCONCCOD',pic:'ZZZZZ9'},{av:'AV32TFPoConcCod_To',fld:'vTFPOCONCCOD_TO',pic:'ZZZZZ9'},{av:'AV33TFPoConcDsc',fld:'vTFPOCONCDSC',pic:''},{av:'AV34TFPoConcDsc_Sel',fld:'vTFPOCONCDSC_SEL',pic:''},{av:'AV48TFPoConcTip_Sels',fld:'vTFPOCONCTIP_SELS',pic:''},{av:'AV38TFPoConcSts_Sels',fld:'vTFPOCONCSTS_SELS',pic:''},{av:'AV13OrderedBy',fld:'vORDEREDBY',pic:'ZZZ9'},{av:'AV14OrderedDsc',fld:'vORDEREDDSC',pic:''},{av:'AV10GridState',fld:'vGRIDSTATE',pic:''},{av:'AV27DynamicFiltersIgnoreFirst',fld:'vDYNAMICFILTERSIGNOREFIRST',pic:''},{av:'AV26DynamicFiltersRemoving',fld:'vDYNAMICFILTERSREMOVING',pic:''}]");
         setEventMetadata("'REMOVEDYNAMICFILTERS1'",",oparms:[{av:'AV26DynamicFiltersRemoving',fld:'vDYNAMICFILTERSREMOVING',pic:''},{av:'AV27DynamicFiltersIgnoreFirst',fld:'vDYNAMICFILTERSIGNOREFIRST',pic:''},{av:'AV10GridState',fld:'vGRIDSTATE',pic:''},{av:'AV18DynamicFiltersEnabled2',fld:'vDYNAMICFILTERSENABLED2',pic:''},{av:'cmbavDynamicfiltersselector2'},{av:'AV19DynamicFiltersSelector2',fld:'vDYNAMICFILTERSSELECTOR2',pic:''},{av:'cmbavDynamicfiltersoperator2'},{av:'AV20DynamicFiltersOperator2',fld:'vDYNAMICFILTERSOPERATOR2',pic:'ZZZ9'},{av:'AV21PoConcDsc2',fld:'vPOCONCDSC2',pic:''},{av:'AV22DynamicFiltersEnabled3',fld:'vDYNAMICFILTERSENABLED3',pic:''},{av:'cmbavDynamicfiltersselector3'},{av:'AV23DynamicFiltersSelector3',fld:'vDYNAMICFILTERSSELECTOR3',pic:''},{av:'cmbavDynamicfiltersoperator3'},{av:'AV24DynamicFiltersOperator3',fld:'vDYNAMICFILTERSOPERATOR3',pic:'ZZZ9'},{av:'AV25PoConcDsc3',fld:'vPOCONCDSC3',pic:''},{av:'imgAdddynamicfilters1_Visible',ctrl:'ADDDYNAMICFILTERS1',prop:'Visible'},{av:'imgRemovedynamicfilters1_Visible',ctrl:'REMOVEDYNAMICFILTERS1',prop:'Visible'},{av:'imgAdddynamicfilters2_Visible',ctrl:'ADDDYNAMICFILTERS2',prop:'Visible'},{av:'imgRemovedynamicfilters2_Visible',ctrl:'REMOVEDYNAMICFILTERS2',prop:'Visible'},{av:'cmbavDynamicfiltersselector1'},{av:'AV15DynamicFiltersSelector1',fld:'vDYNAMICFILTERSSELECTOR1',pic:''},{av:'cmbavDynamicfiltersoperator1'},{av:'AV16DynamicFiltersOperator1',fld:'vDYNAMICFILTERSOPERATOR1',pic:'ZZZ9'},{av:'AV17PoConcDsc1',fld:'vPOCONCDSC1',pic:''},{av:'lblJsdynamicfilters_Caption',ctrl:'JSDYNAMICFILTERS',prop:'Caption'},{av:'edtavPoconcdsc2_Visible',ctrl:'vPOCONCDSC2',prop:'Visible'},{av:'edtavPoconcdsc3_Visible',ctrl:'vPOCONCDSC3',prop:'Visible'},{av:'edtavPoconcdsc1_Visible',ctrl:'vPOCONCDSC1',prop:'Visible'},{av:'AV41GridCurrentPage',fld:'vGRIDCURRENTPAGE',pic:'ZZZZZZZZZ9'},{av:'AV42GridPageCount',fld:'vGRIDPAGECOUNT',pic:'ZZZZZZZZZ9'},{av:'AV43GridAppliedFilters',fld:'vGRIDAPPLIEDFILTERS',pic:''}]}");
         setEventMetadata("VDYNAMICFILTERSSELECTOR1.CLICK","{handler:'E20272',iparms:[{av:'cmbavDynamicfiltersselector1'},{av:'AV15DynamicFiltersSelector1',fld:'vDYNAMICFILTERSSELECTOR1',pic:''}]");
         setEventMetadata("VDYNAMICFILTERSSELECTOR1.CLICK",",oparms:[{av:'edtavPoconcdsc1_Visible',ctrl:'vPOCONCDSC1',prop:'Visible'},{av:'cmbavDynamicfiltersoperator1'}]}");
         setEventMetadata("'ADDDYNAMICFILTERS2'","{handler:'E21272',iparms:[]");
         setEventMetadata("'ADDDYNAMICFILTERS2'",",oparms:[{av:'AV22DynamicFiltersEnabled3',fld:'vDYNAMICFILTERSENABLED3',pic:''},{av:'imgAdddynamicfilters2_Visible',ctrl:'ADDDYNAMICFILTERS2',prop:'Visible'},{av:'imgRemovedynamicfilters2_Visible',ctrl:'REMOVEDYNAMICFILTERS2',prop:'Visible'}]}");
         setEventMetadata("'REMOVEDYNAMICFILTERS2'","{handler:'E16272',iparms:[{av:'GRID_nFirstRecordOnPage'},{av:'GRID_nEOF'},{av:'subGrid_Rows',ctrl:'GRID',prop:'Rows'},{av:'cmbavDynamicfiltersselector1'},{av:'AV15DynamicFiltersSelector1',fld:'vDYNAMICFILTERSSELECTOR1',pic:''},{av:'cmbavDynamicfiltersoperator1'},{av:'AV16DynamicFiltersOperator1',fld:'vDYNAMICFILTERSOPERATOR1',pic:'ZZZ9'},{av:'AV17PoConcDsc1',fld:'vPOCONCDSC1',pic:''},{av:'cmbavDynamicfiltersselector2'},{av:'AV19DynamicFiltersSelector2',fld:'vDYNAMICFILTERSSELECTOR2',pic:''},{av:'cmbavDynamicfiltersoperator2'},{av:'AV20DynamicFiltersOperator2',fld:'vDYNAMICFILTERSOPERATOR2',pic:'ZZZ9'},{av:'AV21PoConcDsc2',fld:'vPOCONCDSC2',pic:''},{av:'cmbavDynamicfiltersselector3'},{av:'AV23DynamicFiltersSelector3',fld:'vDYNAMICFILTERSSELECTOR3',pic:''},{av:'cmbavDynamicfiltersoperator3'},{av:'AV24DynamicFiltersOperator3',fld:'vDYNAMICFILTERSOPERATOR3',pic:'ZZZ9'},{av:'AV25PoConcDsc3',fld:'vPOCONCDSC3',pic:''},{av:'AV51Pgmname',fld:'vPGMNAME',pic:'',hsh:true},{av:'AV18DynamicFiltersEnabled2',fld:'vDYNAMICFILTERSENABLED2',pic:''},{av:'AV22DynamicFiltersEnabled3',fld:'vDYNAMICFILTERSENABLED3',pic:''},{av:'AV31TFPoConcCod',fld:'vTFPOCONCCOD',pic:'ZZZZZ9'},{av:'AV32TFPoConcCod_To',fld:'vTFPOCONCCOD_TO',pic:'ZZZZZ9'},{av:'AV33TFPoConcDsc',fld:'vTFPOCONCDSC',pic:''},{av:'AV34TFPoConcDsc_Sel',fld:'vTFPOCONCDSC_SEL',pic:''},{av:'AV48TFPoConcTip_Sels',fld:'vTFPOCONCTIP_SELS',pic:''},{av:'AV38TFPoConcSts_Sels',fld:'vTFPOCONCSTS_SELS',pic:''},{av:'AV13OrderedBy',fld:'vORDEREDBY',pic:'ZZZ9'},{av:'AV14OrderedDsc',fld:'vORDEREDDSC',pic:''},{av:'AV10GridState',fld:'vGRIDSTATE',pic:''},{av:'AV27DynamicFiltersIgnoreFirst',fld:'vDYNAMICFILTERSIGNOREFIRST',pic:''},{av:'AV26DynamicFiltersRemoving',fld:'vDYNAMICFILTERSREMOVING',pic:''}]");
         setEventMetadata("'REMOVEDYNAMICFILTERS2'",",oparms:[{av:'AV26DynamicFiltersRemoving',fld:'vDYNAMICFILTERSREMOVING',pic:''},{av:'AV18DynamicFiltersEnabled2',fld:'vDYNAMICFILTERSENABLED2',pic:''},{av:'AV10GridState',fld:'vGRIDSTATE',pic:''},{av:'cmbavDynamicfiltersselector2'},{av:'AV19DynamicFiltersSelector2',fld:'vDYNAMICFILTERSSELECTOR2',pic:''},{av:'cmbavDynamicfiltersoperator2'},{av:'AV20DynamicFiltersOperator2',fld:'vDYNAMICFILTERSOPERATOR2',pic:'ZZZ9'},{av:'AV21PoConcDsc2',fld:'vPOCONCDSC2',pic:''},{av:'AV22DynamicFiltersEnabled3',fld:'vDYNAMICFILTERSENABLED3',pic:''},{av:'cmbavDynamicfiltersselector3'},{av:'AV23DynamicFiltersSelector3',fld:'vDYNAMICFILTERSSELECTOR3',pic:''},{av:'cmbavDynamicfiltersoperator3'},{av:'AV24DynamicFiltersOperator3',fld:'vDYNAMICFILTERSOPERATOR3',pic:'ZZZ9'},{av:'AV25PoConcDsc3',fld:'vPOCONCDSC3',pic:''},{av:'imgAdddynamicfilters1_Visible',ctrl:'ADDDYNAMICFILTERS1',prop:'Visible'},{av:'imgRemovedynamicfilters1_Visible',ctrl:'REMOVEDYNAMICFILTERS1',prop:'Visible'},{av:'imgAdddynamicfilters2_Visible',ctrl:'ADDDYNAMICFILTERS2',prop:'Visible'},{av:'imgRemovedynamicfilters2_Visible',ctrl:'REMOVEDYNAMICFILTERS2',prop:'Visible'},{av:'cmbavDynamicfiltersselector1'},{av:'AV15DynamicFiltersSelector1',fld:'vDYNAMICFILTERSSELECTOR1',pic:''},{av:'cmbavDynamicfiltersoperator1'},{av:'AV16DynamicFiltersOperator1',fld:'vDYNAMICFILTERSOPERATOR1',pic:'ZZZ9'},{av:'AV17PoConcDsc1',fld:'vPOCONCDSC1',pic:''},{av:'lblJsdynamicfilters_Caption',ctrl:'JSDYNAMICFILTERS',prop:'Caption'},{av:'edtavPoconcdsc2_Visible',ctrl:'vPOCONCDSC2',prop:'Visible'},{av:'edtavPoconcdsc3_Visible',ctrl:'vPOCONCDSC3',prop:'Visible'},{av:'edtavPoconcdsc1_Visible',ctrl:'vPOCONCDSC1',prop:'Visible'},{av:'AV41GridCurrentPage',fld:'vGRIDCURRENTPAGE',pic:'ZZZZZZZZZ9'},{av:'AV42GridPageCount',fld:'vGRIDPAGECOUNT',pic:'ZZZZZZZZZ9'},{av:'AV43GridAppliedFilters',fld:'vGRIDAPPLIEDFILTERS',pic:''}]}");
         setEventMetadata("VDYNAMICFILTERSSELECTOR2.CLICK","{handler:'E22272',iparms:[{av:'cmbavDynamicfiltersselector2'},{av:'AV19DynamicFiltersSelector2',fld:'vDYNAMICFILTERSSELECTOR2',pic:''}]");
         setEventMetadata("VDYNAMICFILTERSSELECTOR2.CLICK",",oparms:[{av:'edtavPoconcdsc2_Visible',ctrl:'vPOCONCDSC2',prop:'Visible'},{av:'cmbavDynamicfiltersoperator2'}]}");
         setEventMetadata("'REMOVEDYNAMICFILTERS3'","{handler:'E17272',iparms:[{av:'GRID_nFirstRecordOnPage'},{av:'GRID_nEOF'},{av:'subGrid_Rows',ctrl:'GRID',prop:'Rows'},{av:'cmbavDynamicfiltersselector1'},{av:'AV15DynamicFiltersSelector1',fld:'vDYNAMICFILTERSSELECTOR1',pic:''},{av:'cmbavDynamicfiltersoperator1'},{av:'AV16DynamicFiltersOperator1',fld:'vDYNAMICFILTERSOPERATOR1',pic:'ZZZ9'},{av:'AV17PoConcDsc1',fld:'vPOCONCDSC1',pic:''},{av:'cmbavDynamicfiltersselector2'},{av:'AV19DynamicFiltersSelector2',fld:'vDYNAMICFILTERSSELECTOR2',pic:''},{av:'cmbavDynamicfiltersoperator2'},{av:'AV20DynamicFiltersOperator2',fld:'vDYNAMICFILTERSOPERATOR2',pic:'ZZZ9'},{av:'AV21PoConcDsc2',fld:'vPOCONCDSC2',pic:''},{av:'cmbavDynamicfiltersselector3'},{av:'AV23DynamicFiltersSelector3',fld:'vDYNAMICFILTERSSELECTOR3',pic:''},{av:'cmbavDynamicfiltersoperator3'},{av:'AV24DynamicFiltersOperator3',fld:'vDYNAMICFILTERSOPERATOR3',pic:'ZZZ9'},{av:'AV25PoConcDsc3',fld:'vPOCONCDSC3',pic:''},{av:'AV51Pgmname',fld:'vPGMNAME',pic:'',hsh:true},{av:'AV18DynamicFiltersEnabled2',fld:'vDYNAMICFILTERSENABLED2',pic:''},{av:'AV22DynamicFiltersEnabled3',fld:'vDYNAMICFILTERSENABLED3',pic:''},{av:'AV31TFPoConcCod',fld:'vTFPOCONCCOD',pic:'ZZZZZ9'},{av:'AV32TFPoConcCod_To',fld:'vTFPOCONCCOD_TO',pic:'ZZZZZ9'},{av:'AV33TFPoConcDsc',fld:'vTFPOCONCDSC',pic:''},{av:'AV34TFPoConcDsc_Sel',fld:'vTFPOCONCDSC_SEL',pic:''},{av:'AV48TFPoConcTip_Sels',fld:'vTFPOCONCTIP_SELS',pic:''},{av:'AV38TFPoConcSts_Sels',fld:'vTFPOCONCSTS_SELS',pic:''},{av:'AV13OrderedBy',fld:'vORDEREDBY',pic:'ZZZ9'},{av:'AV14OrderedDsc',fld:'vORDEREDDSC',pic:''},{av:'AV10GridState',fld:'vGRIDSTATE',pic:''},{av:'AV27DynamicFiltersIgnoreFirst',fld:'vDYNAMICFILTERSIGNOREFIRST',pic:''},{av:'AV26DynamicFiltersRemoving',fld:'vDYNAMICFILTERSREMOVING',pic:''}]");
         setEventMetadata("'REMOVEDYNAMICFILTERS3'",",oparms:[{av:'AV26DynamicFiltersRemoving',fld:'vDYNAMICFILTERSREMOVING',pic:''},{av:'AV22DynamicFiltersEnabled3',fld:'vDYNAMICFILTERSENABLED3',pic:''},{av:'AV10GridState',fld:'vGRIDSTATE',pic:''},{av:'AV18DynamicFiltersEnabled2',fld:'vDYNAMICFILTERSENABLED2',pic:''},{av:'cmbavDynamicfiltersselector2'},{av:'AV19DynamicFiltersSelector2',fld:'vDYNAMICFILTERSSELECTOR2',pic:''},{av:'cmbavDynamicfiltersoperator2'},{av:'AV20DynamicFiltersOperator2',fld:'vDYNAMICFILTERSOPERATOR2',pic:'ZZZ9'},{av:'AV21PoConcDsc2',fld:'vPOCONCDSC2',pic:''},{av:'cmbavDynamicfiltersselector3'},{av:'AV23DynamicFiltersSelector3',fld:'vDYNAMICFILTERSSELECTOR3',pic:''},{av:'cmbavDynamicfiltersoperator3'},{av:'AV24DynamicFiltersOperator3',fld:'vDYNAMICFILTERSOPERATOR3',pic:'ZZZ9'},{av:'AV25PoConcDsc3',fld:'vPOCONCDSC3',pic:''},{av:'imgAdddynamicfilters1_Visible',ctrl:'ADDDYNAMICFILTERS1',prop:'Visible'},{av:'imgRemovedynamicfilters1_Visible',ctrl:'REMOVEDYNAMICFILTERS1',prop:'Visible'},{av:'imgAdddynamicfilters2_Visible',ctrl:'ADDDYNAMICFILTERS2',prop:'Visible'},{av:'imgRemovedynamicfilters2_Visible',ctrl:'REMOVEDYNAMICFILTERS2',prop:'Visible'},{av:'cmbavDynamicfiltersselector1'},{av:'AV15DynamicFiltersSelector1',fld:'vDYNAMICFILTERSSELECTOR1',pic:''},{av:'cmbavDynamicfiltersoperator1'},{av:'AV16DynamicFiltersOperator1',fld:'vDYNAMICFILTERSOPERATOR1',pic:'ZZZ9'},{av:'AV17PoConcDsc1',fld:'vPOCONCDSC1',pic:''},{av:'lblJsdynamicfilters_Caption',ctrl:'JSDYNAMICFILTERS',prop:'Caption'},{av:'edtavPoconcdsc2_Visible',ctrl:'vPOCONCDSC2',prop:'Visible'},{av:'edtavPoconcdsc3_Visible',ctrl:'vPOCONCDSC3',prop:'Visible'},{av:'edtavPoconcdsc1_Visible',ctrl:'vPOCONCDSC1',prop:'Visible'},{av:'AV41GridCurrentPage',fld:'vGRIDCURRENTPAGE',pic:'ZZZZZZZZZ9'},{av:'AV42GridPageCount',fld:'vGRIDPAGECOUNT',pic:'ZZZZZZZZZ9'},{av:'AV43GridAppliedFilters',fld:'vGRIDAPPLIEDFILTERS',pic:''}]}");
         setEventMetadata("VDYNAMICFILTERSSELECTOR3.CLICK","{handler:'E23272',iparms:[{av:'cmbavDynamicfiltersselector3'},{av:'AV23DynamicFiltersSelector3',fld:'vDYNAMICFILTERSSELECTOR3',pic:''}]");
         setEventMetadata("VDYNAMICFILTERSSELECTOR3.CLICK",",oparms:[{av:'edtavPoconcdsc3_Visible',ctrl:'vPOCONCDSC3',prop:'Visible'},{av:'cmbavDynamicfiltersoperator3'}]}");
         setEventMetadata("VGRIDACTIONS.CLICK","{handler:'E27272',iparms:[{av:'cmbavGridactions'},{av:'AV44GridActions',fld:'vGRIDACTIONS',pic:'ZZZ9'},{av:'A313PoConcCod',fld:'POCONCCOD',pic:'ZZZZZ9',hsh:true}]");
         setEventMetadata("VGRIDACTIONS.CLICK",",oparms:[{av:'cmbavGridactions'},{av:'AV44GridActions',fld:'vGRIDACTIONS',pic:'ZZZ9'}]}");
         setEventMetadata("'DOINSERT'","{handler:'E18272',iparms:[{av:'A313PoConcCod',fld:'POCONCCOD',pic:'ZZZZZ9',hsh:true}]");
         setEventMetadata("'DOINSERT'",",oparms:[]}");
         setEventMetadata("DDO_AGEXPORT.ONOPTIONCLICKED","{handler:'E13272',iparms:[{av:'Ddo_agexport_Activeeventkey',ctrl:'DDO_AGEXPORT',prop:'ActiveEventKey'},{av:'AV51Pgmname',fld:'vPGMNAME',pic:'',hsh:true},{av:'AV38TFPoConcSts_Sels',fld:'vTFPOCONCSTS_SELS',pic:''},{av:'AV34TFPoConcDsc_Sel',fld:'vTFPOCONCDSC_SEL',pic:''},{av:'AV48TFPoConcTip_Sels',fld:'vTFPOCONCTIP_SELS',pic:''},{av:'AV47TFPoConcTip_SelsJson',fld:'vTFPOCONCTIP_SELSJSON',pic:''},{av:'AV37TFPoConcSts_SelsJson',fld:'vTFPOCONCSTS_SELSJSON',pic:''},{av:'AV31TFPoConcCod',fld:'vTFPOCONCCOD',pic:'ZZZZZ9'},{av:'AV33TFPoConcDsc',fld:'vTFPOCONCDSC',pic:''},{av:'AV32TFPoConcCod_To',fld:'vTFPOCONCCOD_TO',pic:'ZZZZZ9'},{av:'AV13OrderedBy',fld:'vORDEREDBY',pic:'ZZZ9'},{av:'AV14OrderedDsc',fld:'vORDEREDDSC',pic:''},{av:'AV10GridState',fld:'vGRIDSTATE',pic:''},{av:'AV26DynamicFiltersRemoving',fld:'vDYNAMICFILTERSREMOVING',pic:''},{av:'cmbavDynamicfiltersselector1'},{av:'AV15DynamicFiltersSelector1',fld:'vDYNAMICFILTERSSELECTOR1',pic:''},{av:'cmbavDynamicfiltersselector2'},{av:'AV19DynamicFiltersSelector2',fld:'vDYNAMICFILTERSSELECTOR2',pic:''},{av:'cmbavDynamicfiltersselector3'},{av:'AV23DynamicFiltersSelector3',fld:'vDYNAMICFILTERSSELECTOR3',pic:''}]");
         setEventMetadata("DDO_AGEXPORT.ONOPTIONCLICKED",",oparms:[{av:'Innewwindow1_Target',ctrl:'INNEWWINDOW1',prop:'Target'},{av:'Innewwindow1_Height',ctrl:'INNEWWINDOW1',prop:'Height'},{av:'Innewwindow1_Width',ctrl:'INNEWWINDOW1',prop:'Width'},{av:'AV10GridState',fld:'vGRIDSTATE',pic:''},{av:'AV13OrderedBy',fld:'vORDEREDBY',pic:'ZZZ9'},{av:'AV14OrderedDsc',fld:'vORDEREDDSC',pic:''},{av:'AV31TFPoConcCod',fld:'vTFPOCONCCOD',pic:'ZZZZZ9'},{av:'AV32TFPoConcCod_To',fld:'vTFPOCONCCOD_TO',pic:'ZZZZZ9'},{av:'AV33TFPoConcDsc',fld:'vTFPOCONCDSC',pic:''},{av:'AV34TFPoConcDsc_Sel',fld:'vTFPOCONCDSC_SEL',pic:''},{av:'AV47TFPoConcTip_SelsJson',fld:'vTFPOCONCTIP_SELSJSON',pic:''},{av:'AV48TFPoConcTip_Sels',fld:'vTFPOCONCTIP_SELS',pic:''},{av:'AV37TFPoConcSts_SelsJson',fld:'vTFPOCONCSTS_SELSJSON',pic:''},{av:'AV38TFPoConcSts_Sels',fld:'vTFPOCONCSTS_SELS',pic:''},{av:'Ddo_grid_Selectedvalue_set',ctrl:'DDO_GRID',prop:'SelectedValue_set'},{av:'Ddo_grid_Filteredtext_set',ctrl:'DDO_GRID',prop:'FilteredText_set'},{av:'Ddo_grid_Filteredtextto_set',ctrl:'DDO_GRID',prop:'FilteredTextTo_set'},{av:'subGrid_Rows',ctrl:'GRID',prop:'Rows'},{av:'GRID_nFirstRecordOnPage'},{av:'GRID_nEOF'},{av:'cmbavDynamicfiltersselector1'},{av:'AV15DynamicFiltersSelector1',fld:'vDYNAMICFILTERSSELECTOR1',pic:''},{av:'cmbavDynamicfiltersoperator1'},{av:'AV16DynamicFiltersOperator1',fld:'vDYNAMICFILTERSOPERATOR1',pic:'ZZZ9'},{av:'AV17PoConcDsc1',fld:'vPOCONCDSC1',pic:''},{av:'cmbavDynamicfiltersselector2'},{av:'AV19DynamicFiltersSelector2',fld:'vDYNAMICFILTERSSELECTOR2',pic:''},{av:'cmbavDynamicfiltersoperator2'},{av:'AV20DynamicFiltersOperator2',fld:'vDYNAMICFILTERSOPERATOR2',pic:'ZZZ9'},{av:'AV21PoConcDsc2',fld:'vPOCONCDSC2',pic:''},{av:'cmbavDynamicfiltersselector3'},{av:'AV23DynamicFiltersSelector3',fld:'vDYNAMICFILTERSSELECTOR3',pic:''},{av:'cmbavDynamicfiltersoperator3'},{av:'AV24DynamicFiltersOperator3',fld:'vDYNAMICFILTERSOPERATOR3',pic:'ZZZ9'},{av:'AV25PoConcDsc3',fld:'vPOCONCDSC3',pic:''},{av:'AV51Pgmname',fld:'vPGMNAME',pic:'',hsh:true},{av:'AV18DynamicFiltersEnabled2',fld:'vDYNAMICFILTERSENABLED2',pic:''},{av:'AV22DynamicFiltersEnabled3',fld:'vDYNAMICFILTERSENABLED3',pic:''},{av:'AV27DynamicFiltersIgnoreFirst',fld:'vDYNAMICFILTERSIGNOREFIRST',pic:''},{av:'AV26DynamicFiltersRemoving',fld:'vDYNAMICFILTERSREMOVING',pic:''},{av:'Ddo_grid_Sortedstatus',ctrl:'DDO_GRID',prop:'SortedStatus'},{av:'imgAdddynamicfilters1_Visible',ctrl:'ADDDYNAMICFILTERS1',prop:'Visible'},{av:'imgRemovedynamicfilters1_Visible',ctrl:'REMOVEDYNAMICFILTERS1',prop:'Visible'},{av:'imgAdddynamicfilters2_Visible',ctrl:'ADDDYNAMICFILTERS2',prop:'Visible'},{av:'imgRemovedynamicfilters2_Visible',ctrl:'REMOVEDYNAMICFILTERS2',prop:'Visible'},{av:'lblJsdynamicfilters_Caption',ctrl:'JSDYNAMICFILTERS',prop:'Caption'},{av:'edtavPoconcdsc1_Visible',ctrl:'vPOCONCDSC1',prop:'Visible'},{av:'edtavPoconcdsc2_Visible',ctrl:'vPOCONCDSC2',prop:'Visible'},{av:'edtavPoconcdsc3_Visible',ctrl:'vPOCONCDSC3',prop:'Visible'}]}");
         setEventMetadata("NULL","{handler:'Valid_Poconcsts',iparms:[]");
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
         Gridpaginationbar_Selectedpage = "";
         Ddo_grid_Activeeventkey = "";
         Ddo_grid_Selectedvalue_get = "";
         Ddo_grid_Selectedcolumn = "";
         Ddo_grid_Filteredtext_get = "";
         Ddo_grid_Filteredtextto_get = "";
         Ddo_agexport_Activeeventkey = "";
         gxfirstwebparm = "";
         gxfirstwebparm_bkp = "";
         AV15DynamicFiltersSelector1 = "";
         AV17PoConcDsc1 = "";
         AV19DynamicFiltersSelector2 = "";
         AV21PoConcDsc2 = "";
         AV23DynamicFiltersSelector3 = "";
         AV25PoConcDsc3 = "";
         AV51Pgmname = "";
         AV33TFPoConcDsc = "";
         AV34TFPoConcDsc_Sel = "";
         AV48TFPoConcTip_Sels = new GxSimpleCollection<string>();
         AV38TFPoConcSts_Sels = new GxSimpleCollection<short>();
         AV10GridState = new GeneXus.Programs.wwpbaseobjects.SdtWWPGridState(context);
         sDynURL = "";
         FormProcess = "";
         bodyStyle = "";
         GXKey = "";
         AV43GridAppliedFilters = "";
         AV45AGExportData = new GXBaseCollection<GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTDropDownOptionsData_Item>( context, "Item", "");
         AV39DDO_TitleSettingsIcons = new GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTDropDownOptionsTitleSettingsIcons(context);
         AV47TFPoConcTip_SelsJson = "";
         AV37TFPoConcSts_SelsJson = "";
         Ddo_agexport_Caption = "";
         Ddo_grid_Caption = "";
         Ddo_grid_Filteredtext_set = "";
         Ddo_grid_Filteredtextto_set = "";
         Ddo_grid_Selectedvalue_set = "";
         Ddo_grid_Sortedstatus = "";
         Grid_empowerer_Gridinternalname = "";
         GX_FocusControl = "";
         Form = new GXWebForm();
         sPrefix = "";
         ucDvpanel_tableheader = new GXUserControl();
         TempTags = "";
         ClassString = "";
         StyleString = "";
         bttBtninsert_Jsonclick = "";
         bttBtnagexport_Jsonclick = "";
         GridContainer = new GXWebGrid( context);
         sStyleString = "";
         subGrid_Linesclass = "";
         GridColumn = new GXWebColumn();
         A1648PoConcDsc = "";
         A1650PoConcTip = "";
         ucGridpaginationbar = new GXUserControl();
         ucDdo_agexport = new GXUserControl();
         lblJsdynamicfilters_Jsonclick = "";
         ucDdo_grid = new GXUserControl();
         ucInnewwindow1 = new GXUserControl();
         ucGrid_empowerer = new GXUserControl();
         sEvt = "";
         EvtGridId = "";
         EvtRowId = "";
         sEvtType = "";
         AV67Produccion_conceptosordenesproduccionwwds_16_tfpoconctip_sels = new GxSimpleCollection<string>();
         AV68Produccion_conceptosordenesproduccionwwds_17_tfpoconcsts_sels = new GxSimpleCollection<short>();
         scmdbuf = "";
         lV54Produccion_conceptosordenesproduccionwwds_3_poconcdsc1 = "";
         lV58Produccion_conceptosordenesproduccionwwds_7_poconcdsc2 = "";
         lV62Produccion_conceptosordenesproduccionwwds_11_poconcdsc3 = "";
         lV65Produccion_conceptosordenesproduccionwwds_14_tfpoconcdsc = "";
         AV52Produccion_conceptosordenesproduccionwwds_1_dynamicfiltersselector1 = "";
         AV54Produccion_conceptosordenesproduccionwwds_3_poconcdsc1 = "";
         AV56Produccion_conceptosordenesproduccionwwds_5_dynamicfiltersselector2 = "";
         AV58Produccion_conceptosordenesproduccionwwds_7_poconcdsc2 = "";
         AV60Produccion_conceptosordenesproduccionwwds_9_dynamicfiltersselector3 = "";
         AV62Produccion_conceptosordenesproduccionwwds_11_poconcdsc3 = "";
         AV66Produccion_conceptosordenesproduccionwwds_15_tfpoconcdsc_sel = "";
         AV65Produccion_conceptosordenesproduccionwwds_14_tfpoconcdsc = "";
         H00272_A1649PoConcSts = new short[1] ;
         H00272_A1650PoConcTip = new string[] {""} ;
         H00272_A1648PoConcDsc = new string[] {""} ;
         H00272_A313PoConcCod = new int[1] ;
         H00273_AGRID_nRecordCount = new long[1] ;
         imgAdddynamicfilters1_Jsonclick = "";
         imgRemovedynamicfilters1_Jsonclick = "";
         imgAdddynamicfilters2_Jsonclick = "";
         imgRemovedynamicfilters2_Jsonclick = "";
         imgRemovedynamicfilters3_Jsonclick = "";
         AV46AGExportDataItem = new GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTDropDownOptionsData_Item(context);
         GXt_SdtDVB_SDTDropDownOptionsTitleSettingsIcons1 = new GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTDropDownOptionsTitleSettingsIcons(context);
         AV6WWPContext = new GeneXus.Programs.wwpbaseobjects.SdtWWPContext(context);
         GXEncryptionTmp = "";
         GridRow = new GXWebRow();
         AV30Session = context.GetSession();
         AV11GridStateFilterValue = new GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue(context);
         GXt_char2 = "";
         GXt_char3 = "";
         AV12GridStateDynamicFilter = new GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter(context);
         AV8TrnContext = new GeneXus.Programs.wwpbaseobjects.SdtWWPTransactionContext(context);
         AV7HTTPRequest = new GxHttpRequest( context);
         AV28ExcelFilename = "";
         AV29ErrorMessage = "";
         lblDynamicfiltersprefix1_Jsonclick = "";
         lblDynamicfiltersmiddle1_Jsonclick = "";
         lblDynamicfiltersprefix2_Jsonclick = "";
         lblDynamicfiltersmiddle2_Jsonclick = "";
         lblDynamicfiltersprefix3_Jsonclick = "";
         lblDynamicfiltersmiddle3_Jsonclick = "";
         sImgUrl = "";
         BackMsgLst = new msglist();
         LclMsgLst = new msglist();
         GXCCtl = "";
         ROClassString = "";
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.produccion.conceptosordenesproduccionww__default(),
            new Object[][] {
                new Object[] {
               H00272_A1649PoConcSts, H00272_A1650PoConcTip, H00272_A1648PoConcDsc, H00272_A313PoConcCod
               }
               , new Object[] {
               H00273_AGRID_nRecordCount
               }
            }
         );
         AV51Pgmname = "Produccion.ConceptosOrdenesProduccionWW";
         /* GeneXus formulas. */
         AV51Pgmname = "Produccion.ConceptosOrdenesProduccionWW";
         context.Gx_err = 0;
      }

      private short GRID_nEOF ;
      private short nGotPars ;
      private short GxWebError ;
      private short AV16DynamicFiltersOperator1 ;
      private short AV20DynamicFiltersOperator2 ;
      private short AV24DynamicFiltersOperator3 ;
      private short AV13OrderedBy ;
      private short initialized ;
      private short gxajaxcallmode ;
      private short wbEnd ;
      private short wbStart ;
      private short subGrid_Backcolorstyle ;
      private short subGrid_Titlebackstyle ;
      private short subGrid_Sortable ;
      private short AV44GridActions ;
      private short A1649PoConcSts ;
      private short subGrid_Allowselection ;
      private short subGrid_Allowhovering ;
      private short subGrid_Allowcollapsing ;
      private short subGrid_Collapsed ;
      private short nDonePA ;
      private short AV53Produccion_conceptosordenesproduccionwwds_2_dynamicfiltersoperator1 ;
      private short AV57Produccion_conceptosordenesproduccionwwds_6_dynamicfiltersoperator2 ;
      private short AV61Produccion_conceptosordenesproduccionwwds_10_dynamicfiltersoperator3 ;
      private short nGXWrapped ;
      private short subGrid_Backstyle ;
      private int subGrid_Rows ;
      private int Gridpaginationbar_Rowsperpageselectedvalue ;
      private int nRC_GXsfl_101 ;
      private int nGXsfl_101_idx=1 ;
      private int AV31TFPoConcCod ;
      private int AV32TFPoConcCod_To ;
      private int Gridpaginationbar_Pagestoshow ;
      private int subGrid_Titlebackcolor ;
      private int subGrid_Allbackcolor ;
      private int A313PoConcCod ;
      private int subGrid_Selectedindex ;
      private int subGrid_Selectioncolor ;
      private int subGrid_Hoveringcolor ;
      private int subGrid_Islastpage ;
      private int GXPagingFrom2 ;
      private int GXPagingTo2 ;
      private int AV67Produccion_conceptosordenesproduccionwwds_16_tfpoconctip_sels_Count ;
      private int AV68Produccion_conceptosordenesproduccionwwds_17_tfpoconcsts_sels_Count ;
      private int AV63Produccion_conceptosordenesproduccionwwds_12_tfpoconccod ;
      private int AV64Produccion_conceptosordenesproduccionwwds_13_tfpoconccod_to ;
      private int AV40PageToGo ;
      private int imgAdddynamicfilters1_Visible ;
      private int imgRemovedynamicfilters1_Visible ;
      private int imgAdddynamicfilters2_Visible ;
      private int imgRemovedynamicfilters2_Visible ;
      private int edtavPoconcdsc1_Visible ;
      private int edtavPoconcdsc2_Visible ;
      private int edtavPoconcdsc3_Visible ;
      private int AV69GXV1 ;
      private int edtavPoconcdsc3_Enabled ;
      private int edtavPoconcdsc2_Enabled ;
      private int edtavPoconcdsc1_Enabled ;
      private int idxLst ;
      private int subGrid_Backcolor ;
      private long GRID_nFirstRecordOnPage ;
      private long AV41GridCurrentPage ;
      private long AV42GridPageCount ;
      private long GRID_nCurrentRecord ;
      private long GRID_nRecordCount ;
      private string Gridpaginationbar_Selectedpage ;
      private string Ddo_grid_Activeeventkey ;
      private string Ddo_grid_Selectedvalue_get ;
      private string Ddo_grid_Selectedcolumn ;
      private string Ddo_grid_Filteredtext_get ;
      private string Ddo_grid_Filteredtextto_get ;
      private string Ddo_agexport_Activeeventkey ;
      private string gxfirstwebparm ;
      private string gxfirstwebparm_bkp ;
      private string sGXsfl_101_idx="0001" ;
      private string AV17PoConcDsc1 ;
      private string AV21PoConcDsc2 ;
      private string AV25PoConcDsc3 ;
      private string AV51Pgmname ;
      private string AV33TFPoConcDsc ;
      private string AV34TFPoConcDsc_Sel ;
      private string sDynURL ;
      private string FormProcess ;
      private string bodyStyle ;
      private string GXKey ;
      private string Dvpanel_tableheader_Width ;
      private string Dvpanel_tableheader_Cls ;
      private string Dvpanel_tableheader_Title ;
      private string Dvpanel_tableheader_Iconposition ;
      private string Gridpaginationbar_Class ;
      private string Gridpaginationbar_Pagingbuttonsposition ;
      private string Gridpaginationbar_Pagingcaptionposition ;
      private string Gridpaginationbar_Emptygridclass ;
      private string Gridpaginationbar_Rowsperpageoptions ;
      private string Gridpaginationbar_Previous ;
      private string Gridpaginationbar_Next ;
      private string Gridpaginationbar_Caption ;
      private string Gridpaginationbar_Emptygridcaption ;
      private string Gridpaginationbar_Rowsperpagecaption ;
      private string Ddo_agexport_Icontype ;
      private string Ddo_agexport_Icon ;
      private string Ddo_agexport_Caption ;
      private string Ddo_agexport_Cls ;
      private string Ddo_agexport_Titlecontrolidtoreplace ;
      private string Ddo_grid_Caption ;
      private string Ddo_grid_Filteredtext_set ;
      private string Ddo_grid_Filteredtextto_set ;
      private string Ddo_grid_Selectedvalue_set ;
      private string Ddo_grid_Gridinternalname ;
      private string Ddo_grid_Columnids ;
      private string Ddo_grid_Columnssortvalues ;
      private string Ddo_grid_Includesortasc ;
      private string Ddo_grid_Sortedstatus ;
      private string Ddo_grid_Includefilter ;
      private string Ddo_grid_Filtertype ;
      private string Ddo_grid_Filterisrange ;
      private string Ddo_grid_Includedatalist ;
      private string Ddo_grid_Datalisttype ;
      private string Ddo_grid_Allowmultipleselection ;
      private string Ddo_grid_Datalistfixedvalues ;
      private string Ddo_grid_Datalistproc ;
      private string Innewwindow1_Width ;
      private string Innewwindow1_Height ;
      private string Innewwindow1_Target ;
      private string Grid_empowerer_Gridinternalname ;
      private string GX_FocusControl ;
      private string sPrefix ;
      private string divLayoutmaintable_Internalname ;
      private string divTablemain_Internalname ;
      private string Dvpanel_tableheader_Internalname ;
      private string divTableheader_Internalname ;
      private string divTableheadercontent_Internalname ;
      private string divTableactions_Internalname ;
      private string TempTags ;
      private string ClassString ;
      private string StyleString ;
      private string bttBtninsert_Internalname ;
      private string bttBtninsert_Jsonclick ;
      private string bttBtnagexport_Internalname ;
      private string bttBtnagexport_Jsonclick ;
      private string divTablerightheader_Internalname ;
      private string divGridtablewithpaginationbar_Internalname ;
      private string sStyleString ;
      private string subGrid_Internalname ;
      private string subGrid_Class ;
      private string subGrid_Linesclass ;
      private string subGrid_Header ;
      private string A1648PoConcDsc ;
      private string edtPoConcDsc_Link ;
      private string A1650PoConcTip ;
      private string Gridpaginationbar_Internalname ;
      private string divHtml_bottomauxiliarcontrols_Internalname ;
      private string Ddo_agexport_Internalname ;
      private string lblJsdynamicfilters_Internalname ;
      private string lblJsdynamicfilters_Caption ;
      private string lblJsdynamicfilters_Jsonclick ;
      private string Ddo_grid_Internalname ;
      private string Innewwindow1_Internalname ;
      private string Grid_empowerer_Internalname ;
      private string sEvt ;
      private string EvtGridId ;
      private string EvtRowId ;
      private string sEvtType ;
      private string cmbavGridactions_Internalname ;
      private string edtPoConcCod_Internalname ;
      private string edtPoConcDsc_Internalname ;
      private string cmbPoConcTip_Internalname ;
      private string cmbPoConcSts_Internalname ;
      private string cmbavDynamicfiltersselector1_Internalname ;
      private string cmbavDynamicfiltersoperator1_Internalname ;
      private string cmbavDynamicfiltersselector2_Internalname ;
      private string cmbavDynamicfiltersoperator2_Internalname ;
      private string cmbavDynamicfiltersselector3_Internalname ;
      private string cmbavDynamicfiltersoperator3_Internalname ;
      private string scmdbuf ;
      private string lV54Produccion_conceptosordenesproduccionwwds_3_poconcdsc1 ;
      private string lV58Produccion_conceptosordenesproduccionwwds_7_poconcdsc2 ;
      private string lV62Produccion_conceptosordenesproduccionwwds_11_poconcdsc3 ;
      private string lV65Produccion_conceptosordenesproduccionwwds_14_tfpoconcdsc ;
      private string AV54Produccion_conceptosordenesproduccionwwds_3_poconcdsc1 ;
      private string AV58Produccion_conceptosordenesproduccionwwds_7_poconcdsc2 ;
      private string AV62Produccion_conceptosordenesproduccionwwds_11_poconcdsc3 ;
      private string AV66Produccion_conceptosordenesproduccionwwds_15_tfpoconcdsc_sel ;
      private string AV65Produccion_conceptosordenesproduccionwwds_14_tfpoconcdsc ;
      private string edtavPoconcdsc1_Internalname ;
      private string edtavPoconcdsc2_Internalname ;
      private string edtavPoconcdsc3_Internalname ;
      private string imgAdddynamicfilters1_Jsonclick ;
      private string divTabledynamicfilters_Internalname ;
      private string imgAdddynamicfilters1_Internalname ;
      private string imgRemovedynamicfilters1_Jsonclick ;
      private string imgRemovedynamicfilters1_Internalname ;
      private string imgAdddynamicfilters2_Jsonclick ;
      private string imgAdddynamicfilters2_Internalname ;
      private string imgRemovedynamicfilters2_Jsonclick ;
      private string imgRemovedynamicfilters2_Internalname ;
      private string imgRemovedynamicfilters3_Jsonclick ;
      private string imgRemovedynamicfilters3_Internalname ;
      private string GXEncryptionTmp ;
      private string GXt_char2 ;
      private string GXt_char3 ;
      private string tblTablefilters_Internalname ;
      private string divTabledynamicfiltersrow1_Internalname ;
      private string lblDynamicfiltersprefix1_Internalname ;
      private string lblDynamicfiltersprefix1_Jsonclick ;
      private string cmbavDynamicfiltersselector1_Jsonclick ;
      private string lblDynamicfiltersmiddle1_Internalname ;
      private string lblDynamicfiltersmiddle1_Jsonclick ;
      private string divTabledynamicfiltersrow2_Internalname ;
      private string lblDynamicfiltersprefix2_Internalname ;
      private string lblDynamicfiltersprefix2_Jsonclick ;
      private string cmbavDynamicfiltersselector2_Jsonclick ;
      private string lblDynamicfiltersmiddle2_Internalname ;
      private string lblDynamicfiltersmiddle2_Jsonclick ;
      private string divTabledynamicfiltersrow3_Internalname ;
      private string lblDynamicfiltersprefix3_Internalname ;
      private string lblDynamicfiltersprefix3_Jsonclick ;
      private string cmbavDynamicfiltersselector3_Jsonclick ;
      private string lblDynamicfiltersmiddle3_Internalname ;
      private string lblDynamicfiltersmiddle3_Jsonclick ;
      private string tblTablemergeddynamicfilters3_Internalname ;
      private string cmbavDynamicfiltersoperator3_Jsonclick ;
      private string cellFilter_poconcdsc3_cell_Internalname ;
      private string edtavPoconcdsc3_Jsonclick ;
      private string cellDynamicfilters_removefilter3_cell_Internalname ;
      private string sImgUrl ;
      private string tblTablemergeddynamicfilters2_Internalname ;
      private string cmbavDynamicfiltersoperator2_Jsonclick ;
      private string cellFilter_poconcdsc2_cell_Internalname ;
      private string edtavPoconcdsc2_Jsonclick ;
      private string cellDynamicfilters_addfilter2_cell_Internalname ;
      private string cellDynamicfilters_removefilter2_cell_Internalname ;
      private string tblTablemergeddynamicfilters1_Internalname ;
      private string cmbavDynamicfiltersoperator1_Jsonclick ;
      private string cellFilter_poconcdsc1_cell_Internalname ;
      private string edtavPoconcdsc1_Jsonclick ;
      private string cellDynamicfilters_addfilter1_cell_Internalname ;
      private string cellDynamicfilters_removefilter1_cell_Internalname ;
      private string sGXsfl_101_fel_idx="0001" ;
      private string GXCCtl ;
      private string cmbavGridactions_Jsonclick ;
      private string ROClassString ;
      private string edtPoConcCod_Jsonclick ;
      private string edtPoConcDsc_Jsonclick ;
      private string cmbPoConcTip_Jsonclick ;
      private string cmbPoConcSts_Jsonclick ;
      private bool entryPointCalled ;
      private bool toggleJsOutput ;
      private bool AV18DynamicFiltersEnabled2 ;
      private bool AV22DynamicFiltersEnabled3 ;
      private bool AV14OrderedDsc ;
      private bool AV27DynamicFiltersIgnoreFirst ;
      private bool AV26DynamicFiltersRemoving ;
      private bool Dvpanel_tableheader_Autowidth ;
      private bool Dvpanel_tableheader_Autoheight ;
      private bool Dvpanel_tableheader_Collapsible ;
      private bool Dvpanel_tableheader_Collapsed ;
      private bool Dvpanel_tableheader_Showcollapseicon ;
      private bool Dvpanel_tableheader_Autoscroll ;
      private bool Gridpaginationbar_Showfirst ;
      private bool Gridpaginationbar_Showprevious ;
      private bool Gridpaginationbar_Shownext ;
      private bool Gridpaginationbar_Showlast ;
      private bool Gridpaginationbar_Rowsperpageselector ;
      private bool Grid_empowerer_Hastitlesettings ;
      private bool wbLoad ;
      private bool Rfr0gs ;
      private bool wbErr ;
      private bool bGXsfl_101_Refreshing=false ;
      private bool gxdyncontrolsrefreshing ;
      private bool AV55Produccion_conceptosordenesproduccionwwds_4_dynamicfiltersenabled2 ;
      private bool AV59Produccion_conceptosordenesproduccionwwds_8_dynamicfiltersenabled3 ;
      private bool returnInSub ;
      private bool gx_refresh_fired ;
      private string AV47TFPoConcTip_SelsJson ;
      private string AV37TFPoConcSts_SelsJson ;
      private string AV15DynamicFiltersSelector1 ;
      private string AV19DynamicFiltersSelector2 ;
      private string AV23DynamicFiltersSelector3 ;
      private string AV43GridAppliedFilters ;
      private string AV52Produccion_conceptosordenesproduccionwwds_1_dynamicfiltersselector1 ;
      private string AV56Produccion_conceptosordenesproduccionwwds_5_dynamicfiltersselector2 ;
      private string AV60Produccion_conceptosordenesproduccionwwds_9_dynamicfiltersselector3 ;
      private string AV28ExcelFilename ;
      private string AV29ErrorMessage ;
      private GxSimpleCollection<short> AV38TFPoConcSts_Sels ;
      private GxSimpleCollection<short> AV68Produccion_conceptosordenesproduccionwwds_17_tfpoconcsts_sels ;
      private IGxSession AV30Session ;
      private GXWebGrid GridContainer ;
      private GXWebRow GridRow ;
      private GXWebColumn GridColumn ;
      private GXUserControl ucDvpanel_tableheader ;
      private GXUserControl ucGridpaginationbar ;
      private GXUserControl ucDdo_agexport ;
      private GXUserControl ucDdo_grid ;
      private GXUserControl ucInnewwindow1 ;
      private GXUserControl ucGrid_empowerer ;
      private IGxDataStore dsDataStore2 ;
      private IGxDataStore dsDefault ;
      private GXCombobox cmbavDynamicfiltersselector1 ;
      private GXCombobox cmbavDynamicfiltersoperator1 ;
      private GXCombobox cmbavDynamicfiltersselector2 ;
      private GXCombobox cmbavDynamicfiltersoperator2 ;
      private GXCombobox cmbavDynamicfiltersselector3 ;
      private GXCombobox cmbavDynamicfiltersoperator3 ;
      private GXCombobox cmbavGridactions ;
      private GXCombobox cmbPoConcTip ;
      private GXCombobox cmbPoConcSts ;
      private IDataStoreProvider pr_default ;
      private short[] H00272_A1649PoConcSts ;
      private string[] H00272_A1650PoConcTip ;
      private string[] H00272_A1648PoConcDsc ;
      private int[] H00272_A313PoConcCod ;
      private long[] H00273_AGRID_nRecordCount ;
      private msglist BackMsgLst ;
      private msglist LclMsgLst ;
      private GxHttpRequest AV7HTTPRequest ;
      private GxSimpleCollection<string> AV48TFPoConcTip_Sels ;
      private GxSimpleCollection<string> AV67Produccion_conceptosordenesproduccionwwds_16_tfpoconctip_sels ;
      private GXBaseCollection<GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTDropDownOptionsData_Item> AV45AGExportData ;
      private GXWebForm Form ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPContext AV6WWPContext ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPTransactionContext AV8TrnContext ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPGridState AV10GridState ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue AV11GridStateFilterValue ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter AV12GridStateDynamicFilter ;
      private GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTDropDownOptionsTitleSettingsIcons AV39DDO_TitleSettingsIcons ;
      private GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTDropDownOptionsTitleSettingsIcons GXt_SdtDVB_SDTDropDownOptionsTitleSettingsIcons1 ;
      private GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTDropDownOptionsData_Item AV46AGExportDataItem ;
   }

   public class conceptosordenesproduccionww__default : DataStoreHelperBase, IDataStoreHelper
   {
      protected Object[] conditional_H00272( IGxContext context ,
                                             string A1650PoConcTip ,
                                             GxSimpleCollection<string> AV67Produccion_conceptosordenesproduccionwwds_16_tfpoconctip_sels ,
                                             short A1649PoConcSts ,
                                             GxSimpleCollection<short> AV68Produccion_conceptosordenesproduccionwwds_17_tfpoconcsts_sels ,
                                             string AV52Produccion_conceptosordenesproduccionwwds_1_dynamicfiltersselector1 ,
                                             short AV53Produccion_conceptosordenesproduccionwwds_2_dynamicfiltersoperator1 ,
                                             string AV54Produccion_conceptosordenesproduccionwwds_3_poconcdsc1 ,
                                             bool AV55Produccion_conceptosordenesproduccionwwds_4_dynamicfiltersenabled2 ,
                                             string AV56Produccion_conceptosordenesproduccionwwds_5_dynamicfiltersselector2 ,
                                             short AV57Produccion_conceptosordenesproduccionwwds_6_dynamicfiltersoperator2 ,
                                             string AV58Produccion_conceptosordenesproduccionwwds_7_poconcdsc2 ,
                                             bool AV59Produccion_conceptosordenesproduccionwwds_8_dynamicfiltersenabled3 ,
                                             string AV60Produccion_conceptosordenesproduccionwwds_9_dynamicfiltersselector3 ,
                                             short AV61Produccion_conceptosordenesproduccionwwds_10_dynamicfiltersoperator3 ,
                                             string AV62Produccion_conceptosordenesproduccionwwds_11_poconcdsc3 ,
                                             int AV63Produccion_conceptosordenesproduccionwwds_12_tfpoconccod ,
                                             int AV64Produccion_conceptosordenesproduccionwwds_13_tfpoconccod_to ,
                                             string AV66Produccion_conceptosordenesproduccionwwds_15_tfpoconcdsc_sel ,
                                             string AV65Produccion_conceptosordenesproduccionwwds_14_tfpoconcdsc ,
                                             int AV67Produccion_conceptosordenesproduccionwwds_16_tfpoconctip_sels_Count ,
                                             int AV68Produccion_conceptosordenesproduccionwwds_17_tfpoconcsts_sels_Count ,
                                             string A1648PoConcDsc ,
                                             int A313PoConcCod ,
                                             short AV13OrderedBy ,
                                             bool AV14OrderedDsc )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int4 = new short[13];
         Object[] GXv_Object5 = new Object[2];
         string sSelectString;
         string sFromString;
         string sOrderString;
         sSelectString = " [PoConcSts], [PoConcTip], [PoConcDsc], [PoConcCod]";
         sFromString = " FROM [POCONCEPTOS]";
         sOrderString = "";
         if ( ( StringUtil.StrCmp(AV52Produccion_conceptosordenesproduccionwwds_1_dynamicfiltersselector1, "POCONCDSC") == 0 ) && ( AV53Produccion_conceptosordenesproduccionwwds_2_dynamicfiltersoperator1 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV54Produccion_conceptosordenesproduccionwwds_3_poconcdsc1)) ) )
         {
            AddWhere(sWhereString, "([PoConcDsc] like @lV54Produccion_conceptosordenesproduccionwwds_3_poconcdsc1)");
         }
         else
         {
            GXv_int4[0] = 1;
         }
         if ( ( StringUtil.StrCmp(AV52Produccion_conceptosordenesproduccionwwds_1_dynamicfiltersselector1, "POCONCDSC") == 0 ) && ( AV53Produccion_conceptosordenesproduccionwwds_2_dynamicfiltersoperator1 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV54Produccion_conceptosordenesproduccionwwds_3_poconcdsc1)) ) )
         {
            AddWhere(sWhereString, "([PoConcDsc] like '%' + @lV54Produccion_conceptosordenesproduccionwwds_3_poconcdsc1)");
         }
         else
         {
            GXv_int4[1] = 1;
         }
         if ( AV55Produccion_conceptosordenesproduccionwwds_4_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV56Produccion_conceptosordenesproduccionwwds_5_dynamicfiltersselector2, "POCONCDSC") == 0 ) && ( AV57Produccion_conceptosordenesproduccionwwds_6_dynamicfiltersoperator2 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV58Produccion_conceptosordenesproduccionwwds_7_poconcdsc2)) ) )
         {
            AddWhere(sWhereString, "([PoConcDsc] like @lV58Produccion_conceptosordenesproduccionwwds_7_poconcdsc2)");
         }
         else
         {
            GXv_int4[2] = 1;
         }
         if ( AV55Produccion_conceptosordenesproduccionwwds_4_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV56Produccion_conceptosordenesproduccionwwds_5_dynamicfiltersselector2, "POCONCDSC") == 0 ) && ( AV57Produccion_conceptosordenesproduccionwwds_6_dynamicfiltersoperator2 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV58Produccion_conceptosordenesproduccionwwds_7_poconcdsc2)) ) )
         {
            AddWhere(sWhereString, "([PoConcDsc] like '%' + @lV58Produccion_conceptosordenesproduccionwwds_7_poconcdsc2)");
         }
         else
         {
            GXv_int4[3] = 1;
         }
         if ( AV59Produccion_conceptosordenesproduccionwwds_8_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV60Produccion_conceptosordenesproduccionwwds_9_dynamicfiltersselector3, "POCONCDSC") == 0 ) && ( AV61Produccion_conceptosordenesproduccionwwds_10_dynamicfiltersoperator3 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV62Produccion_conceptosordenesproduccionwwds_11_poconcdsc3)) ) )
         {
            AddWhere(sWhereString, "([PoConcDsc] like @lV62Produccion_conceptosordenesproduccionwwds_11_poconcdsc3)");
         }
         else
         {
            GXv_int4[4] = 1;
         }
         if ( AV59Produccion_conceptosordenesproduccionwwds_8_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV60Produccion_conceptosordenesproduccionwwds_9_dynamicfiltersselector3, "POCONCDSC") == 0 ) && ( AV61Produccion_conceptosordenesproduccionwwds_10_dynamicfiltersoperator3 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV62Produccion_conceptosordenesproduccionwwds_11_poconcdsc3)) ) )
         {
            AddWhere(sWhereString, "([PoConcDsc] like '%' + @lV62Produccion_conceptosordenesproduccionwwds_11_poconcdsc3)");
         }
         else
         {
            GXv_int4[5] = 1;
         }
         if ( ! (0==AV63Produccion_conceptosordenesproduccionwwds_12_tfpoconccod) )
         {
            AddWhere(sWhereString, "([PoConcCod] >= @AV63Produccion_conceptosordenesproduccionwwds_12_tfpoconccod)");
         }
         else
         {
            GXv_int4[6] = 1;
         }
         if ( ! (0==AV64Produccion_conceptosordenesproduccionwwds_13_tfpoconccod_to) )
         {
            AddWhere(sWhereString, "([PoConcCod] <= @AV64Produccion_conceptosordenesproduccionwwds_13_tfpoconccod_to)");
         }
         else
         {
            GXv_int4[7] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV66Produccion_conceptosordenesproduccionwwds_15_tfpoconcdsc_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV65Produccion_conceptosordenesproduccionwwds_14_tfpoconcdsc)) ) )
         {
            AddWhere(sWhereString, "([PoConcDsc] like @lV65Produccion_conceptosordenesproduccionwwds_14_tfpoconcdsc)");
         }
         else
         {
            GXv_int4[8] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV66Produccion_conceptosordenesproduccionwwds_15_tfpoconcdsc_sel)) )
         {
            AddWhere(sWhereString, "([PoConcDsc] = @AV66Produccion_conceptosordenesproduccionwwds_15_tfpoconcdsc_sel)");
         }
         else
         {
            GXv_int4[9] = 1;
         }
         if ( AV67Produccion_conceptosordenesproduccionwwds_16_tfpoconctip_sels_Count > 0 )
         {
            AddWhere(sWhereString, "("+new GxDbmsUtils( new GxSqlServer()).ValueList(AV67Produccion_conceptosordenesproduccionwwds_16_tfpoconctip_sels, "[PoConcTip] IN (", ")")+")");
         }
         if ( AV68Produccion_conceptosordenesproduccionwwds_17_tfpoconcsts_sels_Count > 0 )
         {
            AddWhere(sWhereString, "("+new GxDbmsUtils( new GxSqlServer()).ValueList(AV68Produccion_conceptosordenesproduccionwwds_17_tfpoconcsts_sels, "[PoConcSts] IN (", ")")+")");
         }
         if ( ( AV13OrderedBy == 1 ) && ! AV14OrderedDsc )
         {
            sOrderString += " ORDER BY [PoConcDsc]";
         }
         else if ( ( AV13OrderedBy == 1 ) && ( AV14OrderedDsc ) )
         {
            sOrderString += " ORDER BY [PoConcDsc] DESC";
         }
         else if ( ( AV13OrderedBy == 2 ) && ! AV14OrderedDsc )
         {
            sOrderString += " ORDER BY [PoConcCod]";
         }
         else if ( ( AV13OrderedBy == 2 ) && ( AV14OrderedDsc ) )
         {
            sOrderString += " ORDER BY [PoConcCod] DESC";
         }
         else if ( ( AV13OrderedBy == 3 ) && ! AV14OrderedDsc )
         {
            sOrderString += " ORDER BY [PoConcTip]";
         }
         else if ( ( AV13OrderedBy == 3 ) && ( AV14OrderedDsc ) )
         {
            sOrderString += " ORDER BY [PoConcTip] DESC";
         }
         else if ( ( AV13OrderedBy == 4 ) && ! AV14OrderedDsc )
         {
            sOrderString += " ORDER BY [PoConcSts]";
         }
         else if ( ( AV13OrderedBy == 4 ) && ( AV14OrderedDsc ) )
         {
            sOrderString += " ORDER BY [PoConcSts] DESC";
         }
         else if ( true )
         {
            sOrderString += " ORDER BY [PoConcCod]";
         }
         scmdbuf = "SELECT " + sSelectString + sFromString + sWhereString + sOrderString + "" + " OFFSET " + "@GXPagingFrom2" + " ROWS FETCH NEXT CAST((SELECT CASE WHEN " + "@GXPagingTo2" + " > 0 THEN " + "@GXPagingTo2" + " ELSE 1e9 END) AS INTEGER) ROWS ONLY";
         GXv_Object5[0] = scmdbuf;
         GXv_Object5[1] = GXv_int4;
         return GXv_Object5 ;
      }

      protected Object[] conditional_H00273( IGxContext context ,
                                             string A1650PoConcTip ,
                                             GxSimpleCollection<string> AV67Produccion_conceptosordenesproduccionwwds_16_tfpoconctip_sels ,
                                             short A1649PoConcSts ,
                                             GxSimpleCollection<short> AV68Produccion_conceptosordenesproduccionwwds_17_tfpoconcsts_sels ,
                                             string AV52Produccion_conceptosordenesproduccionwwds_1_dynamicfiltersselector1 ,
                                             short AV53Produccion_conceptosordenesproduccionwwds_2_dynamicfiltersoperator1 ,
                                             string AV54Produccion_conceptosordenesproduccionwwds_3_poconcdsc1 ,
                                             bool AV55Produccion_conceptosordenesproduccionwwds_4_dynamicfiltersenabled2 ,
                                             string AV56Produccion_conceptosordenesproduccionwwds_5_dynamicfiltersselector2 ,
                                             short AV57Produccion_conceptosordenesproduccionwwds_6_dynamicfiltersoperator2 ,
                                             string AV58Produccion_conceptosordenesproduccionwwds_7_poconcdsc2 ,
                                             bool AV59Produccion_conceptosordenesproduccionwwds_8_dynamicfiltersenabled3 ,
                                             string AV60Produccion_conceptosordenesproduccionwwds_9_dynamicfiltersselector3 ,
                                             short AV61Produccion_conceptosordenesproduccionwwds_10_dynamicfiltersoperator3 ,
                                             string AV62Produccion_conceptosordenesproduccionwwds_11_poconcdsc3 ,
                                             int AV63Produccion_conceptosordenesproduccionwwds_12_tfpoconccod ,
                                             int AV64Produccion_conceptosordenesproduccionwwds_13_tfpoconccod_to ,
                                             string AV66Produccion_conceptosordenesproduccionwwds_15_tfpoconcdsc_sel ,
                                             string AV65Produccion_conceptosordenesproduccionwwds_14_tfpoconcdsc ,
                                             int AV67Produccion_conceptosordenesproduccionwwds_16_tfpoconctip_sels_Count ,
                                             int AV68Produccion_conceptosordenesproduccionwwds_17_tfpoconcsts_sels_Count ,
                                             string A1648PoConcDsc ,
                                             int A313PoConcCod ,
                                             short AV13OrderedBy ,
                                             bool AV14OrderedDsc )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int6 = new short[10];
         Object[] GXv_Object7 = new Object[2];
         scmdbuf = "SELECT COUNT(*) FROM [POCONCEPTOS]";
         if ( ( StringUtil.StrCmp(AV52Produccion_conceptosordenesproduccionwwds_1_dynamicfiltersselector1, "POCONCDSC") == 0 ) && ( AV53Produccion_conceptosordenesproduccionwwds_2_dynamicfiltersoperator1 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV54Produccion_conceptosordenesproduccionwwds_3_poconcdsc1)) ) )
         {
            AddWhere(sWhereString, "([PoConcDsc] like @lV54Produccion_conceptosordenesproduccionwwds_3_poconcdsc1)");
         }
         else
         {
            GXv_int6[0] = 1;
         }
         if ( ( StringUtil.StrCmp(AV52Produccion_conceptosordenesproduccionwwds_1_dynamicfiltersselector1, "POCONCDSC") == 0 ) && ( AV53Produccion_conceptosordenesproduccionwwds_2_dynamicfiltersoperator1 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV54Produccion_conceptosordenesproduccionwwds_3_poconcdsc1)) ) )
         {
            AddWhere(sWhereString, "([PoConcDsc] like '%' + @lV54Produccion_conceptosordenesproduccionwwds_3_poconcdsc1)");
         }
         else
         {
            GXv_int6[1] = 1;
         }
         if ( AV55Produccion_conceptosordenesproduccionwwds_4_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV56Produccion_conceptosordenesproduccionwwds_5_dynamicfiltersselector2, "POCONCDSC") == 0 ) && ( AV57Produccion_conceptosordenesproduccionwwds_6_dynamicfiltersoperator2 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV58Produccion_conceptosordenesproduccionwwds_7_poconcdsc2)) ) )
         {
            AddWhere(sWhereString, "([PoConcDsc] like @lV58Produccion_conceptosordenesproduccionwwds_7_poconcdsc2)");
         }
         else
         {
            GXv_int6[2] = 1;
         }
         if ( AV55Produccion_conceptosordenesproduccionwwds_4_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV56Produccion_conceptosordenesproduccionwwds_5_dynamicfiltersselector2, "POCONCDSC") == 0 ) && ( AV57Produccion_conceptosordenesproduccionwwds_6_dynamicfiltersoperator2 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV58Produccion_conceptosordenesproduccionwwds_7_poconcdsc2)) ) )
         {
            AddWhere(sWhereString, "([PoConcDsc] like '%' + @lV58Produccion_conceptosordenesproduccionwwds_7_poconcdsc2)");
         }
         else
         {
            GXv_int6[3] = 1;
         }
         if ( AV59Produccion_conceptosordenesproduccionwwds_8_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV60Produccion_conceptosordenesproduccionwwds_9_dynamicfiltersselector3, "POCONCDSC") == 0 ) && ( AV61Produccion_conceptosordenesproduccionwwds_10_dynamicfiltersoperator3 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV62Produccion_conceptosordenesproduccionwwds_11_poconcdsc3)) ) )
         {
            AddWhere(sWhereString, "([PoConcDsc] like @lV62Produccion_conceptosordenesproduccionwwds_11_poconcdsc3)");
         }
         else
         {
            GXv_int6[4] = 1;
         }
         if ( AV59Produccion_conceptosordenesproduccionwwds_8_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV60Produccion_conceptosordenesproduccionwwds_9_dynamicfiltersselector3, "POCONCDSC") == 0 ) && ( AV61Produccion_conceptosordenesproduccionwwds_10_dynamicfiltersoperator3 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV62Produccion_conceptosordenesproduccionwwds_11_poconcdsc3)) ) )
         {
            AddWhere(sWhereString, "([PoConcDsc] like '%' + @lV62Produccion_conceptosordenesproduccionwwds_11_poconcdsc3)");
         }
         else
         {
            GXv_int6[5] = 1;
         }
         if ( ! (0==AV63Produccion_conceptosordenesproduccionwwds_12_tfpoconccod) )
         {
            AddWhere(sWhereString, "([PoConcCod] >= @AV63Produccion_conceptosordenesproduccionwwds_12_tfpoconccod)");
         }
         else
         {
            GXv_int6[6] = 1;
         }
         if ( ! (0==AV64Produccion_conceptosordenesproduccionwwds_13_tfpoconccod_to) )
         {
            AddWhere(sWhereString, "([PoConcCod] <= @AV64Produccion_conceptosordenesproduccionwwds_13_tfpoconccod_to)");
         }
         else
         {
            GXv_int6[7] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV66Produccion_conceptosordenesproduccionwwds_15_tfpoconcdsc_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV65Produccion_conceptosordenesproduccionwwds_14_tfpoconcdsc)) ) )
         {
            AddWhere(sWhereString, "([PoConcDsc] like @lV65Produccion_conceptosordenesproduccionwwds_14_tfpoconcdsc)");
         }
         else
         {
            GXv_int6[8] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV66Produccion_conceptosordenesproduccionwwds_15_tfpoconcdsc_sel)) )
         {
            AddWhere(sWhereString, "([PoConcDsc] = @AV66Produccion_conceptosordenesproduccionwwds_15_tfpoconcdsc_sel)");
         }
         else
         {
            GXv_int6[9] = 1;
         }
         if ( AV67Produccion_conceptosordenesproduccionwwds_16_tfpoconctip_sels_Count > 0 )
         {
            AddWhere(sWhereString, "("+new GxDbmsUtils( new GxSqlServer()).ValueList(AV67Produccion_conceptosordenesproduccionwwds_16_tfpoconctip_sels, "[PoConcTip] IN (", ")")+")");
         }
         if ( AV68Produccion_conceptosordenesproduccionwwds_17_tfpoconcsts_sels_Count > 0 )
         {
            AddWhere(sWhereString, "("+new GxDbmsUtils( new GxSqlServer()).ValueList(AV68Produccion_conceptosordenesproduccionwwds_17_tfpoconcsts_sels, "[PoConcSts] IN (", ")")+")");
         }
         scmdbuf += sWhereString;
         if ( ( AV13OrderedBy == 1 ) && ! AV14OrderedDsc )
         {
            scmdbuf += "";
         }
         else if ( ( AV13OrderedBy == 1 ) && ( AV14OrderedDsc ) )
         {
            scmdbuf += "";
         }
         else if ( ( AV13OrderedBy == 2 ) && ! AV14OrderedDsc )
         {
            scmdbuf += "";
         }
         else if ( ( AV13OrderedBy == 2 ) && ( AV14OrderedDsc ) )
         {
            scmdbuf += "";
         }
         else if ( ( AV13OrderedBy == 3 ) && ! AV14OrderedDsc )
         {
            scmdbuf += "";
         }
         else if ( ( AV13OrderedBy == 3 ) && ( AV14OrderedDsc ) )
         {
            scmdbuf += "";
         }
         else if ( ( AV13OrderedBy == 4 ) && ! AV14OrderedDsc )
         {
            scmdbuf += "";
         }
         else if ( ( AV13OrderedBy == 4 ) && ( AV14OrderedDsc ) )
         {
            scmdbuf += "";
         }
         else if ( true )
         {
            scmdbuf += "";
         }
         GXv_Object7[0] = scmdbuf;
         GXv_Object7[1] = GXv_int6;
         return GXv_Object7 ;
      }

      public override Object [] getDynamicStatement( int cursor ,
                                                     IGxContext context ,
                                                     Object [] dynConstraints )
      {
         switch ( cursor )
         {
               case 0 :
                     return conditional_H00272(context, (string)dynConstraints[0] , (GxSimpleCollection<string>)dynConstraints[1] , (short)dynConstraints[2] , (GxSimpleCollection<short>)dynConstraints[3] , (string)dynConstraints[4] , (short)dynConstraints[5] , (string)dynConstraints[6] , (bool)dynConstraints[7] , (string)dynConstraints[8] , (short)dynConstraints[9] , (string)dynConstraints[10] , (bool)dynConstraints[11] , (string)dynConstraints[12] , (short)dynConstraints[13] , (string)dynConstraints[14] , (int)dynConstraints[15] , (int)dynConstraints[16] , (string)dynConstraints[17] , (string)dynConstraints[18] , (int)dynConstraints[19] , (int)dynConstraints[20] , (string)dynConstraints[21] , (int)dynConstraints[22] , (short)dynConstraints[23] , (bool)dynConstraints[24] );
               case 1 :
                     return conditional_H00273(context, (string)dynConstraints[0] , (GxSimpleCollection<string>)dynConstraints[1] , (short)dynConstraints[2] , (GxSimpleCollection<short>)dynConstraints[3] , (string)dynConstraints[4] , (short)dynConstraints[5] , (string)dynConstraints[6] , (bool)dynConstraints[7] , (string)dynConstraints[8] , (short)dynConstraints[9] , (string)dynConstraints[10] , (bool)dynConstraints[11] , (string)dynConstraints[12] , (short)dynConstraints[13] , (string)dynConstraints[14] , (int)dynConstraints[15] , (int)dynConstraints[16] , (string)dynConstraints[17] , (string)dynConstraints[18] , (int)dynConstraints[19] , (int)dynConstraints[20] , (string)dynConstraints[21] , (int)dynConstraints[22] , (short)dynConstraints[23] , (bool)dynConstraints[24] );
         }
         return base.getDynamicStatement(cursor, context, dynConstraints);
      }

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
          Object[] prmH00272;
          prmH00272 = new Object[] {
          new ParDef("@lV54Produccion_conceptosordenesproduccionwwds_3_poconcdsc1",GXType.NChar,100,0) ,
          new ParDef("@lV54Produccion_conceptosordenesproduccionwwds_3_poconcdsc1",GXType.NChar,100,0) ,
          new ParDef("@lV58Produccion_conceptosordenesproduccionwwds_7_poconcdsc2",GXType.NChar,100,0) ,
          new ParDef("@lV58Produccion_conceptosordenesproduccionwwds_7_poconcdsc2",GXType.NChar,100,0) ,
          new ParDef("@lV62Produccion_conceptosordenesproduccionwwds_11_poconcdsc3",GXType.NChar,100,0) ,
          new ParDef("@lV62Produccion_conceptosordenesproduccionwwds_11_poconcdsc3",GXType.NChar,100,0) ,
          new ParDef("@AV63Produccion_conceptosordenesproduccionwwds_12_tfpoconccod",GXType.Int32,6,0) ,
          new ParDef("@AV64Produccion_conceptosordenesproduccionwwds_13_tfpoconccod_to",GXType.Int32,6,0) ,
          new ParDef("@lV65Produccion_conceptosordenesproduccionwwds_14_tfpoconcdsc",GXType.NChar,100,0) ,
          new ParDef("@AV66Produccion_conceptosordenesproduccionwwds_15_tfpoconcdsc_sel",GXType.NChar,100,0) ,
          new ParDef("@GXPagingFrom2",GXType.Int32,9,0) ,
          new ParDef("@GXPagingTo2",GXType.Int32,9,0) ,
          new ParDef("@GXPagingTo2",GXType.Int32,9,0)
          };
          Object[] prmH00273;
          prmH00273 = new Object[] {
          new ParDef("@lV54Produccion_conceptosordenesproduccionwwds_3_poconcdsc1",GXType.NChar,100,0) ,
          new ParDef("@lV54Produccion_conceptosordenesproduccionwwds_3_poconcdsc1",GXType.NChar,100,0) ,
          new ParDef("@lV58Produccion_conceptosordenesproduccionwwds_7_poconcdsc2",GXType.NChar,100,0) ,
          new ParDef("@lV58Produccion_conceptosordenesproduccionwwds_7_poconcdsc2",GXType.NChar,100,0) ,
          new ParDef("@lV62Produccion_conceptosordenesproduccionwwds_11_poconcdsc3",GXType.NChar,100,0) ,
          new ParDef("@lV62Produccion_conceptosordenesproduccionwwds_11_poconcdsc3",GXType.NChar,100,0) ,
          new ParDef("@AV63Produccion_conceptosordenesproduccionwwds_12_tfpoconccod",GXType.Int32,6,0) ,
          new ParDef("@AV64Produccion_conceptosordenesproduccionwwds_13_tfpoconccod_to",GXType.Int32,6,0) ,
          new ParDef("@lV65Produccion_conceptosordenesproduccionwwds_14_tfpoconcdsc",GXType.NChar,100,0) ,
          new ParDef("@AV66Produccion_conceptosordenesproduccionwwds_15_tfpoconcdsc_sel",GXType.NChar,100,0)
          };
          def= new CursorDef[] {
              new CursorDef("H00272", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH00272,11, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("H00273", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH00273,1, GxCacheFrequency.OFF ,true,false )
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
                ((string[]) buf[1])[0] = rslt.getString(2, 1);
                ((string[]) buf[2])[0] = rslt.getString(3, 100);
                ((int[]) buf[3])[0] = rslt.getInt(4);
                return;
             case 1 :
                ((long[]) buf[0])[0] = rslt.getLong(1);
                return;
       }
    }

 }

}
