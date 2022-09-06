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
namespace GeneXus.Programs.contabilidad {
   public class auxiliaresww : GXDataArea
   {
      public auxiliaresww( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDataStore2 = context.GetDataStore("DataStore2");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusTheme");
      }

      public auxiliaresww( IGxContext context )
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
               nRC_GXsfl_110 = (int)(NumberUtil.Val( GetPar( "nRC_GXsfl_110"), "."));
               nGXsfl_110_idx = (int)(NumberUtil.Val( GetPar( "nGXsfl_110_idx"), "."));
               sGXsfl_110_idx = GetPar( "sGXsfl_110_idx");
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
               AV17TipADDsc1 = GetPar( "TipADDsc1");
               AV47TipADCod1 = GetPar( "TipADCod1");
               cmbavDynamicfiltersselector2.FromJSonString( GetNextPar( ));
               AV19DynamicFiltersSelector2 = GetPar( "DynamicFiltersSelector2");
               cmbavDynamicfiltersoperator2.FromJSonString( GetNextPar( ));
               AV20DynamicFiltersOperator2 = (short)(NumberUtil.Val( GetPar( "DynamicFiltersOperator2"), "."));
               AV21TipADDsc2 = GetPar( "TipADDsc2");
               AV48TipADCod2 = GetPar( "TipADCod2");
               cmbavDynamicfiltersselector3.FromJSonString( GetNextPar( ));
               AV23DynamicFiltersSelector3 = GetPar( "DynamicFiltersSelector3");
               cmbavDynamicfiltersoperator3.FromJSonString( GetNextPar( ));
               AV24DynamicFiltersOperator3 = (short)(NumberUtil.Val( GetPar( "DynamicFiltersOperator3"), "."));
               AV25TipADDsc3 = GetPar( "TipADDsc3");
               AV49TipADCod3 = GetPar( "TipADCod3");
               AV18DynamicFiltersEnabled2 = StringUtil.StrToBool( GetPar( "DynamicFiltersEnabled2"));
               AV22DynamicFiltersEnabled3 = StringUtil.StrToBool( GetPar( "DynamicFiltersEnabled3"));
               AV54Pgmname = GetPar( "Pgmname");
               AV50TFTipADsc = GetPar( "TFTipADsc");
               AV51TFTipADsc_Sel = GetPar( "TFTipADsc_Sel");
               AV33TFTipADCod = GetPar( "TFTipADCod");
               AV34TFTipADCod_Sel = GetPar( "TFTipADCod_Sel");
               AV35TFTipADDsc = GetPar( "TFTipADDsc");
               AV36TFTipADDsc_Sel = GetPar( "TFTipADDsc_Sel");
               ajax_req_read_hidden_sdt(GetNextPar( ), AV38TFTipADSts_Sels);
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
               gxgrGrid_refresh( subGrid_Rows, AV15DynamicFiltersSelector1, AV16DynamicFiltersOperator1, AV17TipADDsc1, AV47TipADCod1, AV19DynamicFiltersSelector2, AV20DynamicFiltersOperator2, AV21TipADDsc2, AV48TipADCod2, AV23DynamicFiltersSelector3, AV24DynamicFiltersOperator3, AV25TipADDsc3, AV49TipADCod3, AV18DynamicFiltersEnabled2, AV22DynamicFiltersEnabled3, AV54Pgmname, AV50TFTipADsc, AV51TFTipADsc_Sel, AV33TFTipADCod, AV34TFTipADCod_Sel, AV35TFTipADDsc, AV36TFTipADDsc_Sel, AV38TFTipADSts_Sels, AV13OrderedBy, AV14OrderedDsc, AV10GridState, AV27DynamicFiltersIgnoreFirst, AV26DynamicFiltersRemoving) ;
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
         PA2B2( ) ;
         gxajaxcallmode = (short)((isAjaxCallMode( ) ? 1 : 0));
         if ( ( gxajaxcallmode == 0 ) && ( GxWebError == 0 ) )
         {
            START2B2( ) ;
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
         context.AddJavascriptSource("gxcfg.js", "?20228181030324", false, true);
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
         context.WriteHtmlTextNl( "<form id=\"MAINFORM\" autocomplete=\"off\" name=\"MAINFORM\" method=\"post\" tabindex=-1  class=\"form-horizontal Form\" data-gx-class=\"form-horizontal Form\" novalidate action=\""+formatLink("contabilidad.auxiliaresww.aspx") +"\">") ;
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
         GxWebStd.gx_hidden_field( context, "gxhash_vPGMNAME", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( AV54Pgmname, "")), context));
         GXKey = Crypto.GetSiteKey( );
      }

      protected void SendCloseFormHiddens( )
      {
         /* Send hidden variables. */
         GxWebStd.gx_hidden_field( context, "GXH_vDYNAMICFILTERSSELECTOR1", AV15DynamicFiltersSelector1);
         GxWebStd.gx_hidden_field( context, "GXH_vDYNAMICFILTERSOPERATOR1", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV16DynamicFiltersOperator1), 4, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "GXH_vTIPADDSC1", StringUtil.RTrim( AV17TipADDsc1));
         GxWebStd.gx_hidden_field( context, "GXH_vTIPADCOD1", StringUtil.RTrim( AV47TipADCod1));
         GxWebStd.gx_hidden_field( context, "GXH_vDYNAMICFILTERSSELECTOR2", AV19DynamicFiltersSelector2);
         GxWebStd.gx_hidden_field( context, "GXH_vDYNAMICFILTERSOPERATOR2", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV20DynamicFiltersOperator2), 4, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "GXH_vTIPADDSC2", StringUtil.RTrim( AV21TipADDsc2));
         GxWebStd.gx_hidden_field( context, "GXH_vTIPADCOD2", StringUtil.RTrim( AV48TipADCod2));
         GxWebStd.gx_hidden_field( context, "GXH_vDYNAMICFILTERSSELECTOR3", AV23DynamicFiltersSelector3);
         GxWebStd.gx_hidden_field( context, "GXH_vDYNAMICFILTERSOPERATOR3", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV24DynamicFiltersOperator3), 4, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "GXH_vTIPADDSC3", StringUtil.RTrim( AV25TipADDsc3));
         GxWebStd.gx_hidden_field( context, "GXH_vTIPADCOD3", StringUtil.RTrim( AV49TipADCod3));
         /* Send saved values. */
         send_integrity_footer_hashes( ) ;
         GxWebStd.gx_hidden_field( context, "nRC_GXsfl_110", StringUtil.LTrim( StringUtil.NToC( (decimal)(nRC_GXsfl_110), 8, 0, ".", "")));
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
         GxWebStd.gx_boolean_hidden_field( context, "vDYNAMICFILTERSENABLED2", AV18DynamicFiltersEnabled2);
         GxWebStd.gx_boolean_hidden_field( context, "vDYNAMICFILTERSENABLED3", AV22DynamicFiltersEnabled3);
         GxWebStd.gx_hidden_field( context, "vPGMNAME", StringUtil.RTrim( AV54Pgmname));
         GxWebStd.gx_hidden_field( context, "gxhash_vPGMNAME", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( AV54Pgmname, "")), context));
         GxWebStd.gx_hidden_field( context, "vTFTIPADSC", StringUtil.RTrim( AV50TFTipADsc));
         GxWebStd.gx_hidden_field( context, "vTFTIPADSC_SEL", StringUtil.RTrim( AV51TFTipADsc_Sel));
         GxWebStd.gx_hidden_field( context, "vTFTIPADCOD", StringUtil.RTrim( AV33TFTipADCod));
         GxWebStd.gx_hidden_field( context, "vTFTIPADCOD_SEL", StringUtil.RTrim( AV34TFTipADCod_Sel));
         GxWebStd.gx_hidden_field( context, "vTFTIPADDSC", StringUtil.RTrim( AV35TFTipADDsc));
         GxWebStd.gx_hidden_field( context, "vTFTIPADDSC_SEL", StringUtil.RTrim( AV36TFTipADDsc_Sel));
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "vTFTIPADSTS_SELS", AV38TFTipADSts_Sels);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt("vTFTIPADSTS_SELS", AV38TFTipADSts_Sels);
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
         GxWebStd.gx_hidden_field( context, "vTFTIPADSTS_SELSJSON", AV37TFTipADSts_SelsJson);
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
         GxWebStd.gx_hidden_field( context, "DDO_GRID_Selectedvalue_set", StringUtil.RTrim( Ddo_grid_Selectedvalue_set));
         GxWebStd.gx_hidden_field( context, "DDO_GRID_Gridinternalname", StringUtil.RTrim( Ddo_grid_Gridinternalname));
         GxWebStd.gx_hidden_field( context, "DDO_GRID_Columnids", StringUtil.RTrim( Ddo_grid_Columnids));
         GxWebStd.gx_hidden_field( context, "DDO_GRID_Columnssortvalues", StringUtil.RTrim( Ddo_grid_Columnssortvalues));
         GxWebStd.gx_hidden_field( context, "DDO_GRID_Includesortasc", StringUtil.RTrim( Ddo_grid_Includesortasc));
         GxWebStd.gx_hidden_field( context, "DDO_GRID_Sortedstatus", StringUtil.RTrim( Ddo_grid_Sortedstatus));
         GxWebStd.gx_hidden_field( context, "DDO_GRID_Includefilter", StringUtil.RTrim( Ddo_grid_Includefilter));
         GxWebStd.gx_hidden_field( context, "DDO_GRID_Filtertype", StringUtil.RTrim( Ddo_grid_Filtertype));
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
         GxWebStd.gx_hidden_field( context, "DDO_AGEXPORT_Activeeventkey", StringUtil.RTrim( Ddo_agexport_Activeeventkey));
         GxWebStd.gx_hidden_field( context, "GRID_Rows", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid_Rows), 6, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "GRIDPAGINATIONBAR_Selectedpage", StringUtil.RTrim( Gridpaginationbar_Selectedpage));
         GxWebStd.gx_hidden_field( context, "GRIDPAGINATIONBAR_Rowsperpageselectedvalue", StringUtil.LTrim( StringUtil.NToC( (decimal)(Gridpaginationbar_Rowsperpageselectedvalue), 9, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "DDO_GRID_Activeeventkey", StringUtil.RTrim( Ddo_grid_Activeeventkey));
         GxWebStd.gx_hidden_field( context, "DDO_GRID_Selectedvalue_get", StringUtil.RTrim( Ddo_grid_Selectedvalue_get));
         GxWebStd.gx_hidden_field( context, "DDO_GRID_Selectedcolumn", StringUtil.RTrim( Ddo_grid_Selectedcolumn));
         GxWebStd.gx_hidden_field( context, "DDO_GRID_Filteredtext_get", StringUtil.RTrim( Ddo_grid_Filteredtext_get));
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
            WE2B2( ) ;
            context.WriteHtmlText( "</div>") ;
         }
      }

      public override void DispatchEvents( )
      {
         EVT2B2( ) ;
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
         return formatLink("contabilidad.auxiliaresww.aspx")  ;
      }

      public override string GetPgmname( )
      {
         return "Contabilidad.AuxiliaresWW" ;
      }

      public override string GetPgmdesc( )
      {
         return " Auxiliares" ;
      }

      protected void WB2B0( )
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
            GxWebStd.gx_button_ctrl( context, bttBtninsert_Internalname, "gx.evt.setGridEvt("+StringUtil.Str( (decimal)(110), 3, 0)+","+"null"+");", "Agregar", bttBtninsert_Jsonclick, 5, "Agregar", "", StyleString, ClassString, 1, 1, "standard", "'"+""+"'"+",false,"+"'"+"E\\'DOINSERT\\'."+"'", TempTags, "", context.GetButtonType( ), "HLP_Contabilidad\\AuxiliaresWW.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "left", "top", "", "", "div");
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 21,'',false,'',0)\"";
            ClassString = "ColumnsSelector";
            StyleString = "";
            GxWebStd.gx_button_ctrl( context, bttBtnagexport_Internalname, "gx.evt.setGridEvt("+StringUtil.Str( (decimal)(110), 3, 0)+","+"null"+");", "Reportes", bttBtnagexport_Jsonclick, 0, "Reportes", "", StyleString, ClassString, 1, 0, "standard", "'"+""+"'"+",false,"+"'"+""+"'", TempTags, "", context.GetButtonType( ), "HLP_Contabilidad\\AuxiliaresWW.htm");
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
            wb_table1_25_2B2( true) ;
         }
         else
         {
            wb_table1_25_2B2( false) ;
         }
         return  ;
      }

      protected void wb_table1_25_2B2e( bool wbgen )
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
               context.WriteHtmlText( "<div id=\""+"GridContainer"+"DivS\" data-gxgridid=\"110\">") ;
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
               context.WriteHtmlText( "<th align=\""+"left"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+""+""+"\" "+">") ;
               context.SendWebValue( "Tipo de Auxiliar") ;
               context.WriteHtmlTextNl( "</th>") ;
               context.WriteHtmlText( "<th align=\""+"right"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+"display:none;"+""+"\" "+">") ;
               context.SendWebValue( "Tipo de Auxiliar") ;
               context.WriteHtmlTextNl( "</th>") ;
               context.WriteHtmlText( "<th align=\""+"left"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+""+""+"\" "+">") ;
               context.SendWebValue( "Codigo") ;
               context.WriteHtmlTextNl( "</th>") ;
               context.WriteHtmlText( "<th align=\""+"left"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+""+""+"\" "+">") ;
               context.SendWebValue( "Auxiliar") ;
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
               GridColumn.AddObjectProperty("Value", StringUtil.RTrim( A1900TipADsc));
               GridColumn.AddObjectProperty("Link", StringUtil.RTrim( edtTipADsc_Link));
               GridContainer.AddColumnProperties(GridColumn);
               GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
               GridColumn.AddObjectProperty("Value", StringUtil.LTrim( StringUtil.NToC( (decimal)(A70TipACod), 6, 0, ".", "")));
               GridContainer.AddColumnProperties(GridColumn);
               GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
               GridColumn.AddObjectProperty("Value", StringUtil.RTrim( A71TipADCod));
               GridContainer.AddColumnProperties(GridColumn);
               GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
               GridColumn.AddObjectProperty("Value", StringUtil.RTrim( A72TipADDsc));
               GridColumn.AddObjectProperty("Link", StringUtil.RTrim( edtTipADDsc_Link));
               GridContainer.AddColumnProperties(GridColumn);
               GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
               GridColumn.AddObjectProperty("Value", StringUtil.LTrim( StringUtil.NToC( (decimal)(A1901TipADSts), 1, 0, ".", "")));
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
         if ( wbEnd == 110 )
         {
            wbEnd = 0;
            nRC_GXsfl_110 = (int)(nGXsfl_110_idx-1);
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
            GxWebStd.gx_label_ctrl( context, lblJsdynamicfilters_Internalname, lblJsdynamicfilters_Caption, "", "", lblJsdynamicfilters_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "", 0, "", 1, 1, 0, 1, "HLP_Contabilidad\\AuxiliaresWW.htm");
            /* User Defined Control */
            ucDdo_grid.SetProperty("Caption", Ddo_grid_Caption);
            ucDdo_grid.SetProperty("ColumnIds", Ddo_grid_Columnids);
            ucDdo_grid.SetProperty("ColumnsSortValues", Ddo_grid_Columnssortvalues);
            ucDdo_grid.SetProperty("IncludeSortASC", Ddo_grid_Includesortasc);
            ucDdo_grid.SetProperty("IncludeFilter", Ddo_grid_Includefilter);
            ucDdo_grid.SetProperty("FilterType", Ddo_grid_Filtertype);
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
         if ( wbEnd == 110 )
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

      protected void START2B2( )
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
            Form.Meta.addItem("description", " Auxiliares", 0) ;
         }
         context.wjLoc = "";
         context.nUserReturn = 0;
         context.wbHandled = 0;
         if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
         {
         }
         wbErr = false;
         STRUP2B0( ) ;
      }

      protected void WS2B2( )
      {
         START2B2( ) ;
         EVT2B2( ) ;
      }

      protected void EVT2B2( )
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
                              E112B2 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "GRIDPAGINATIONBAR.CHANGEROWSPERPAGE") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              E122B2 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "DDO_AGEXPORT.ONOPTIONCLICKED") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              E132B2 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "DDO_GRID.ONOPTIONCLICKED") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              E142B2 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "'REMOVEDYNAMICFILTERS1'") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              /* Execute user event: 'RemoveDynamicFilters1' */
                              E152B2 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "'REMOVEDYNAMICFILTERS2'") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              /* Execute user event: 'RemoveDynamicFilters2' */
                              E162B2 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "'REMOVEDYNAMICFILTERS3'") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              /* Execute user event: 'RemoveDynamicFilters3' */
                              E172B2 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "'DOINSERT'") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              /* Execute user event: 'DoInsert' */
                              E182B2 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "'ADDDYNAMICFILTERS1'") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              /* Execute user event: 'AddDynamicFilters1' */
                              E192B2 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "VDYNAMICFILTERSSELECTOR1.CLICK") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              E202B2 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "'ADDDYNAMICFILTERS2'") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              /* Execute user event: 'AddDynamicFilters2' */
                              E212B2 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "VDYNAMICFILTERSSELECTOR2.CLICK") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              E222B2 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "VDYNAMICFILTERSSELECTOR3.CLICK") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              E232B2 ();
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
                              nGXsfl_110_idx = (int)(NumberUtil.Val( sEvtType, "."));
                              sGXsfl_110_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_110_idx), 4, 0), 4, "0");
                              SubsflControlProps_1102( ) ;
                              cmbavGridactions.Name = cmbavGridactions_Internalname;
                              cmbavGridactions.CurrentValue = cgiGet( cmbavGridactions_Internalname);
                              AV44GridActions = (short)(NumberUtil.Val( cgiGet( cmbavGridactions_Internalname), "."));
                              AssignAttri("", false, cmbavGridactions_Internalname, StringUtil.LTrimStr( (decimal)(AV44GridActions), 4, 0));
                              A1900TipADsc = cgiGet( edtTipADsc_Internalname);
                              A70TipACod = (int)(context.localUtil.CToN( cgiGet( edtTipACod_Internalname), ".", ","));
                              A71TipADCod = cgiGet( edtTipADCod_Internalname);
                              A72TipADDsc = cgiGet( edtTipADDsc_Internalname);
                              A1901TipADSts = (short)(context.localUtil.CToN( cgiGet( edtTipADSts_Internalname), ".", ","));
                              sEvtType = StringUtil.Right( sEvt, 1);
                              if ( StringUtil.StrCmp(sEvtType, ".") == 0 )
                              {
                                 sEvt = StringUtil.Left( sEvt, (short)(StringUtil.Len( sEvt)-1));
                                 if ( StringUtil.StrCmp(sEvt, "START") == 0 )
                                 {
                                    context.wbHandled = 1;
                                    dynload_actions( ) ;
                                    /* Execute user event: Start */
                                    E242B2 ();
                                 }
                                 else if ( StringUtil.StrCmp(sEvt, "REFRESH") == 0 )
                                 {
                                    context.wbHandled = 1;
                                    dynload_actions( ) ;
                                    /* Execute user event: Refresh */
                                    E252B2 ();
                                 }
                                 else if ( StringUtil.StrCmp(sEvt, "GRID.LOAD") == 0 )
                                 {
                                    context.wbHandled = 1;
                                    dynload_actions( ) ;
                                    E262B2 ();
                                 }
                                 else if ( StringUtil.StrCmp(sEvt, "VGRIDACTIONS.CLICK") == 0 )
                                 {
                                    context.wbHandled = 1;
                                    dynload_actions( ) ;
                                    E272B2 ();
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
                                       /* Set Refresh If Tipaddsc1 Changed */
                                       if ( StringUtil.StrCmp(cgiGet( "GXH_vTIPADDSC1"), AV17TipADDsc1) != 0 )
                                       {
                                          Rfr0gs = true;
                                       }
                                       /* Set Refresh If Tipadcod1 Changed */
                                       if ( StringUtil.StrCmp(cgiGet( "GXH_vTIPADCOD1"), AV47TipADCod1) != 0 )
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
                                       /* Set Refresh If Tipaddsc2 Changed */
                                       if ( StringUtil.StrCmp(cgiGet( "GXH_vTIPADDSC2"), AV21TipADDsc2) != 0 )
                                       {
                                          Rfr0gs = true;
                                       }
                                       /* Set Refresh If Tipadcod2 Changed */
                                       if ( StringUtil.StrCmp(cgiGet( "GXH_vTIPADCOD2"), AV48TipADCod2) != 0 )
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
                                       /* Set Refresh If Tipaddsc3 Changed */
                                       if ( StringUtil.StrCmp(cgiGet( "GXH_vTIPADDSC3"), AV25TipADDsc3) != 0 )
                                       {
                                          Rfr0gs = true;
                                       }
                                       /* Set Refresh If Tipadcod3 Changed */
                                       if ( StringUtil.StrCmp(cgiGet( "GXH_vTIPADCOD3"), AV49TipADCod3) != 0 )
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

      protected void WE2B2( )
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

      protected void PA2B2( )
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
         SubsflControlProps_1102( ) ;
         while ( nGXsfl_110_idx <= nRC_GXsfl_110 )
         {
            sendrow_1102( ) ;
            nGXsfl_110_idx = ((subGrid_Islastpage==1)&&(nGXsfl_110_idx+1>subGrid_fnc_Recordsperpage( )) ? 1 : nGXsfl_110_idx+1);
            sGXsfl_110_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_110_idx), 4, 0), 4, "0");
            SubsflControlProps_1102( ) ;
         }
         AddString( context.httpAjaxContext.getJSONContainerResponse( GridContainer)) ;
         /* End function gxnrGrid_newrow */
      }

      protected void gxgrGrid_refresh( int subGrid_Rows ,
                                       string AV15DynamicFiltersSelector1 ,
                                       short AV16DynamicFiltersOperator1 ,
                                       string AV17TipADDsc1 ,
                                       string AV47TipADCod1 ,
                                       string AV19DynamicFiltersSelector2 ,
                                       short AV20DynamicFiltersOperator2 ,
                                       string AV21TipADDsc2 ,
                                       string AV48TipADCod2 ,
                                       string AV23DynamicFiltersSelector3 ,
                                       short AV24DynamicFiltersOperator3 ,
                                       string AV25TipADDsc3 ,
                                       string AV49TipADCod3 ,
                                       bool AV18DynamicFiltersEnabled2 ,
                                       bool AV22DynamicFiltersEnabled3 ,
                                       string AV54Pgmname ,
                                       string AV50TFTipADsc ,
                                       string AV51TFTipADsc_Sel ,
                                       string AV33TFTipADCod ,
                                       string AV34TFTipADCod_Sel ,
                                       string AV35TFTipADDsc ,
                                       string AV36TFTipADDsc_Sel ,
                                       GxSimpleCollection<short> AV38TFTipADSts_Sels ,
                                       short AV13OrderedBy ,
                                       bool AV14OrderedDsc ,
                                       GeneXus.Programs.wwpbaseobjects.SdtWWPGridState AV10GridState ,
                                       bool AV27DynamicFiltersIgnoreFirst ,
                                       bool AV26DynamicFiltersRemoving )
      {
         initialize_formulas( ) ;
         GxWebStd.set_html_headers( context, 0, "", "");
         /* Execute user event: Refresh */
         E252B2 ();
         GRID_nCurrentRecord = 0;
         RF2B2( ) ;
         GXKey = Crypto.GetSiteKey( );
         send_integrity_footer_hashes( ) ;
         GXKey = Crypto.GetSiteKey( );
         /* End function gxgrGrid_refresh */
      }

      protected void send_integrity_hashes( )
      {
         GxWebStd.gx_hidden_field( context, "gxhash_TIPACOD", GetSecureSignedToken( "", context.localUtil.Format( (decimal)(A70TipACod), "ZZZZZ9"), context));
         GxWebStd.gx_hidden_field( context, "TIPACOD", StringUtil.LTrim( StringUtil.NToC( (decimal)(A70TipACod), 6, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "gxhash_TIPADCOD", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( A71TipADCod, "")), context));
         GxWebStd.gx_hidden_field( context, "TIPADCOD", StringUtil.RTrim( A71TipADCod));
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
         RF2B2( ) ;
         if ( isFullAjaxMode( ) )
         {
            send_integrity_footer_hashes( ) ;
         }
      }

      protected void initialize_formulas( )
      {
         /* GeneXus formulas. */
         AV54Pgmname = "Contabilidad.AuxiliaresWW";
         context.Gx_err = 0;
      }

      protected void RF2B2( )
      {
         initialize_formulas( ) ;
         clear_multi_value_controls( ) ;
         if ( isAjaxCallMode( ) )
         {
            GridContainer.ClearRows();
         }
         wbStart = 110;
         /* Execute user event: Refresh */
         E252B2 ();
         nGXsfl_110_idx = 1;
         sGXsfl_110_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_110_idx), 4, 0), 4, "0");
         SubsflControlProps_1102( ) ;
         bGXsfl_110_Refreshing = true;
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
            SubsflControlProps_1102( ) ;
            GXPagingFrom2 = (int)(((subGrid_Rows==0) ? 0 : GRID_nFirstRecordOnPage));
            GXPagingTo2 = ((subGrid_Rows==0) ? 10000 : subGrid_fnc_Recordsperpage( )+1);
            pr_default.dynParam(0, new Object[]{ new Object[]{
                                                 A1901TipADSts ,
                                                 AV75Contabilidad_auxiliareswwds_21_tftipadsts_sels ,
                                                 AV55Contabilidad_auxiliareswwds_1_dynamicfiltersselector1 ,
                                                 AV56Contabilidad_auxiliareswwds_2_dynamicfiltersoperator1 ,
                                                 AV57Contabilidad_auxiliareswwds_3_tipaddsc1 ,
                                                 AV58Contabilidad_auxiliareswwds_4_tipadcod1 ,
                                                 AV59Contabilidad_auxiliareswwds_5_dynamicfiltersenabled2 ,
                                                 AV60Contabilidad_auxiliareswwds_6_dynamicfiltersselector2 ,
                                                 AV61Contabilidad_auxiliareswwds_7_dynamicfiltersoperator2 ,
                                                 AV62Contabilidad_auxiliareswwds_8_tipaddsc2 ,
                                                 AV63Contabilidad_auxiliareswwds_9_tipadcod2 ,
                                                 AV64Contabilidad_auxiliareswwds_10_dynamicfiltersenabled3 ,
                                                 AV65Contabilidad_auxiliareswwds_11_dynamicfiltersselector3 ,
                                                 AV66Contabilidad_auxiliareswwds_12_dynamicfiltersoperator3 ,
                                                 AV67Contabilidad_auxiliareswwds_13_tipaddsc3 ,
                                                 AV68Contabilidad_auxiliareswwds_14_tipadcod3 ,
                                                 AV70Contabilidad_auxiliareswwds_16_tftipadsc_sel ,
                                                 AV69Contabilidad_auxiliareswwds_15_tftipadsc ,
                                                 AV72Contabilidad_auxiliareswwds_18_tftipadcod_sel ,
                                                 AV71Contabilidad_auxiliareswwds_17_tftipadcod ,
                                                 AV74Contabilidad_auxiliareswwds_20_tftipaddsc_sel ,
                                                 AV73Contabilidad_auxiliareswwds_19_tftipaddsc ,
                                                 AV75Contabilidad_auxiliareswwds_21_tftipadsts_sels.Count ,
                                                 A72TipADDsc ,
                                                 A71TipADCod ,
                                                 A1900TipADsc ,
                                                 AV13OrderedBy ,
                                                 AV14OrderedDsc } ,
                                                 new int[]{
                                                 TypeConstants.SHORT, TypeConstants.SHORT, TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.INT, TypeConstants.SHORT, TypeConstants.BOOLEAN
                                                 }
            });
            lV57Contabilidad_auxiliareswwds_3_tipaddsc1 = StringUtil.PadR( StringUtil.RTrim( AV57Contabilidad_auxiliareswwds_3_tipaddsc1), 100, "%");
            lV57Contabilidad_auxiliareswwds_3_tipaddsc1 = StringUtil.PadR( StringUtil.RTrim( AV57Contabilidad_auxiliareswwds_3_tipaddsc1), 100, "%");
            lV58Contabilidad_auxiliareswwds_4_tipadcod1 = StringUtil.PadR( StringUtil.RTrim( AV58Contabilidad_auxiliareswwds_4_tipadcod1), 20, "%");
            lV58Contabilidad_auxiliareswwds_4_tipadcod1 = StringUtil.PadR( StringUtil.RTrim( AV58Contabilidad_auxiliareswwds_4_tipadcod1), 20, "%");
            lV62Contabilidad_auxiliareswwds_8_tipaddsc2 = StringUtil.PadR( StringUtil.RTrim( AV62Contabilidad_auxiliareswwds_8_tipaddsc2), 100, "%");
            lV62Contabilidad_auxiliareswwds_8_tipaddsc2 = StringUtil.PadR( StringUtil.RTrim( AV62Contabilidad_auxiliareswwds_8_tipaddsc2), 100, "%");
            lV63Contabilidad_auxiliareswwds_9_tipadcod2 = StringUtil.PadR( StringUtil.RTrim( AV63Contabilidad_auxiliareswwds_9_tipadcod2), 20, "%");
            lV63Contabilidad_auxiliareswwds_9_tipadcod2 = StringUtil.PadR( StringUtil.RTrim( AV63Contabilidad_auxiliareswwds_9_tipadcod2), 20, "%");
            lV67Contabilidad_auxiliareswwds_13_tipaddsc3 = StringUtil.PadR( StringUtil.RTrim( AV67Contabilidad_auxiliareswwds_13_tipaddsc3), 100, "%");
            lV67Contabilidad_auxiliareswwds_13_tipaddsc3 = StringUtil.PadR( StringUtil.RTrim( AV67Contabilidad_auxiliareswwds_13_tipaddsc3), 100, "%");
            lV68Contabilidad_auxiliareswwds_14_tipadcod3 = StringUtil.PadR( StringUtil.RTrim( AV68Contabilidad_auxiliareswwds_14_tipadcod3), 20, "%");
            lV68Contabilidad_auxiliareswwds_14_tipadcod3 = StringUtil.PadR( StringUtil.RTrim( AV68Contabilidad_auxiliareswwds_14_tipadcod3), 20, "%");
            lV69Contabilidad_auxiliareswwds_15_tftipadsc = StringUtil.PadR( StringUtil.RTrim( AV69Contabilidad_auxiliareswwds_15_tftipadsc), 100, "%");
            lV71Contabilidad_auxiliareswwds_17_tftipadcod = StringUtil.PadR( StringUtil.RTrim( AV71Contabilidad_auxiliareswwds_17_tftipadcod), 20, "%");
            lV73Contabilidad_auxiliareswwds_19_tftipaddsc = StringUtil.PadR( StringUtil.RTrim( AV73Contabilidad_auxiliareswwds_19_tftipaddsc), 100, "%");
            /* Using cursor H002B2 */
            pr_default.execute(0, new Object[] {lV57Contabilidad_auxiliareswwds_3_tipaddsc1, lV57Contabilidad_auxiliareswwds_3_tipaddsc1, lV58Contabilidad_auxiliareswwds_4_tipadcod1, lV58Contabilidad_auxiliareswwds_4_tipadcod1, lV62Contabilidad_auxiliareswwds_8_tipaddsc2, lV62Contabilidad_auxiliareswwds_8_tipaddsc2, lV63Contabilidad_auxiliareswwds_9_tipadcod2, lV63Contabilidad_auxiliareswwds_9_tipadcod2, lV67Contabilidad_auxiliareswwds_13_tipaddsc3, lV67Contabilidad_auxiliareswwds_13_tipaddsc3, lV68Contabilidad_auxiliareswwds_14_tipadcod3, lV68Contabilidad_auxiliareswwds_14_tipadcod3, lV69Contabilidad_auxiliareswwds_15_tftipadsc, AV70Contabilidad_auxiliareswwds_16_tftipadsc_sel, lV71Contabilidad_auxiliareswwds_17_tftipadcod, AV72Contabilidad_auxiliareswwds_18_tftipadcod_sel, lV73Contabilidad_auxiliareswwds_19_tftipaddsc, AV74Contabilidad_auxiliareswwds_20_tftipaddsc_sel, GXPagingFrom2, GXPagingTo2, GXPagingTo2});
            nGXsfl_110_idx = 1;
            sGXsfl_110_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_110_idx), 4, 0), 4, "0");
            SubsflControlProps_1102( ) ;
            while ( ( (pr_default.getStatus(0) != 101) ) && ( ( ( subGrid_Rows == 0 ) || ( GRID_nCurrentRecord < subGrid_fnc_Recordsperpage( ) ) ) ) )
            {
               A1901TipADSts = H002B2_A1901TipADSts[0];
               A72TipADDsc = H002B2_A72TipADDsc[0];
               A71TipADCod = H002B2_A71TipADCod[0];
               A70TipACod = H002B2_A70TipACod[0];
               A1900TipADsc = H002B2_A1900TipADsc[0];
               A1900TipADsc = H002B2_A1900TipADsc[0];
               E262B2 ();
               pr_default.readNext(0);
            }
            GRID_nEOF = (short)(((pr_default.getStatus(0) == 101) ? 1 : 0));
            GxWebStd.gx_hidden_field( context, "GRID_nEOF", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRID_nEOF), 1, 0, ".", "")));
            pr_default.close(0);
            wbEnd = 110;
            WB2B0( ) ;
         }
         bGXsfl_110_Refreshing = true;
      }

      protected void send_integrity_lvl_hashes2B2( )
      {
         GxWebStd.gx_hidden_field( context, "vPGMNAME", StringUtil.RTrim( AV54Pgmname));
         GxWebStd.gx_hidden_field( context, "gxhash_vPGMNAME", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( AV54Pgmname, "")), context));
         GxWebStd.gx_hidden_field( context, "gxhash_TIPACOD"+"_"+sGXsfl_110_idx, GetSecureSignedToken( sGXsfl_110_idx, context.localUtil.Format( (decimal)(A70TipACod), "ZZZZZ9"), context));
         GxWebStd.gx_hidden_field( context, "gxhash_TIPADCOD"+"_"+sGXsfl_110_idx, GetSecureSignedToken( sGXsfl_110_idx, StringUtil.RTrim( context.localUtil.Format( A71TipADCod, "")), context));
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
         AV55Contabilidad_auxiliareswwds_1_dynamicfiltersselector1 = AV15DynamicFiltersSelector1;
         AV56Contabilidad_auxiliareswwds_2_dynamicfiltersoperator1 = AV16DynamicFiltersOperator1;
         AV57Contabilidad_auxiliareswwds_3_tipaddsc1 = AV17TipADDsc1;
         AV58Contabilidad_auxiliareswwds_4_tipadcod1 = AV47TipADCod1;
         AV59Contabilidad_auxiliareswwds_5_dynamicfiltersenabled2 = AV18DynamicFiltersEnabled2;
         AV60Contabilidad_auxiliareswwds_6_dynamicfiltersselector2 = AV19DynamicFiltersSelector2;
         AV61Contabilidad_auxiliareswwds_7_dynamicfiltersoperator2 = AV20DynamicFiltersOperator2;
         AV62Contabilidad_auxiliareswwds_8_tipaddsc2 = AV21TipADDsc2;
         AV63Contabilidad_auxiliareswwds_9_tipadcod2 = AV48TipADCod2;
         AV64Contabilidad_auxiliareswwds_10_dynamicfiltersenabled3 = AV22DynamicFiltersEnabled3;
         AV65Contabilidad_auxiliareswwds_11_dynamicfiltersselector3 = AV23DynamicFiltersSelector3;
         AV66Contabilidad_auxiliareswwds_12_dynamicfiltersoperator3 = AV24DynamicFiltersOperator3;
         AV67Contabilidad_auxiliareswwds_13_tipaddsc3 = AV25TipADDsc3;
         AV68Contabilidad_auxiliareswwds_14_tipadcod3 = AV49TipADCod3;
         AV69Contabilidad_auxiliareswwds_15_tftipadsc = AV50TFTipADsc;
         AV70Contabilidad_auxiliareswwds_16_tftipadsc_sel = AV51TFTipADsc_Sel;
         AV71Contabilidad_auxiliareswwds_17_tftipadcod = AV33TFTipADCod;
         AV72Contabilidad_auxiliareswwds_18_tftipadcod_sel = AV34TFTipADCod_Sel;
         AV73Contabilidad_auxiliareswwds_19_tftipaddsc = AV35TFTipADDsc;
         AV74Contabilidad_auxiliareswwds_20_tftipaddsc_sel = AV36TFTipADDsc_Sel;
         AV75Contabilidad_auxiliareswwds_21_tftipadsts_sels = AV38TFTipADSts_Sels;
         pr_default.dynParam(1, new Object[]{ new Object[]{
                                              A1901TipADSts ,
                                              AV75Contabilidad_auxiliareswwds_21_tftipadsts_sels ,
                                              AV55Contabilidad_auxiliareswwds_1_dynamicfiltersselector1 ,
                                              AV56Contabilidad_auxiliareswwds_2_dynamicfiltersoperator1 ,
                                              AV57Contabilidad_auxiliareswwds_3_tipaddsc1 ,
                                              AV58Contabilidad_auxiliareswwds_4_tipadcod1 ,
                                              AV59Contabilidad_auxiliareswwds_5_dynamicfiltersenabled2 ,
                                              AV60Contabilidad_auxiliareswwds_6_dynamicfiltersselector2 ,
                                              AV61Contabilidad_auxiliareswwds_7_dynamicfiltersoperator2 ,
                                              AV62Contabilidad_auxiliareswwds_8_tipaddsc2 ,
                                              AV63Contabilidad_auxiliareswwds_9_tipadcod2 ,
                                              AV64Contabilidad_auxiliareswwds_10_dynamicfiltersenabled3 ,
                                              AV65Contabilidad_auxiliareswwds_11_dynamicfiltersselector3 ,
                                              AV66Contabilidad_auxiliareswwds_12_dynamicfiltersoperator3 ,
                                              AV67Contabilidad_auxiliareswwds_13_tipaddsc3 ,
                                              AV68Contabilidad_auxiliareswwds_14_tipadcod3 ,
                                              AV70Contabilidad_auxiliareswwds_16_tftipadsc_sel ,
                                              AV69Contabilidad_auxiliareswwds_15_tftipadsc ,
                                              AV72Contabilidad_auxiliareswwds_18_tftipadcod_sel ,
                                              AV71Contabilidad_auxiliareswwds_17_tftipadcod ,
                                              AV74Contabilidad_auxiliareswwds_20_tftipaddsc_sel ,
                                              AV73Contabilidad_auxiliareswwds_19_tftipaddsc ,
                                              AV75Contabilidad_auxiliareswwds_21_tftipadsts_sels.Count ,
                                              A72TipADDsc ,
                                              A71TipADCod ,
                                              A1900TipADsc ,
                                              AV13OrderedBy ,
                                              AV14OrderedDsc } ,
                                              new int[]{
                                              TypeConstants.SHORT, TypeConstants.SHORT, TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.INT, TypeConstants.SHORT, TypeConstants.BOOLEAN
                                              }
         });
         lV57Contabilidad_auxiliareswwds_3_tipaddsc1 = StringUtil.PadR( StringUtil.RTrim( AV57Contabilidad_auxiliareswwds_3_tipaddsc1), 100, "%");
         lV57Contabilidad_auxiliareswwds_3_tipaddsc1 = StringUtil.PadR( StringUtil.RTrim( AV57Contabilidad_auxiliareswwds_3_tipaddsc1), 100, "%");
         lV58Contabilidad_auxiliareswwds_4_tipadcod1 = StringUtil.PadR( StringUtil.RTrim( AV58Contabilidad_auxiliareswwds_4_tipadcod1), 20, "%");
         lV58Contabilidad_auxiliareswwds_4_tipadcod1 = StringUtil.PadR( StringUtil.RTrim( AV58Contabilidad_auxiliareswwds_4_tipadcod1), 20, "%");
         lV62Contabilidad_auxiliareswwds_8_tipaddsc2 = StringUtil.PadR( StringUtil.RTrim( AV62Contabilidad_auxiliareswwds_8_tipaddsc2), 100, "%");
         lV62Contabilidad_auxiliareswwds_8_tipaddsc2 = StringUtil.PadR( StringUtil.RTrim( AV62Contabilidad_auxiliareswwds_8_tipaddsc2), 100, "%");
         lV63Contabilidad_auxiliareswwds_9_tipadcod2 = StringUtil.PadR( StringUtil.RTrim( AV63Contabilidad_auxiliareswwds_9_tipadcod2), 20, "%");
         lV63Contabilidad_auxiliareswwds_9_tipadcod2 = StringUtil.PadR( StringUtil.RTrim( AV63Contabilidad_auxiliareswwds_9_tipadcod2), 20, "%");
         lV67Contabilidad_auxiliareswwds_13_tipaddsc3 = StringUtil.PadR( StringUtil.RTrim( AV67Contabilidad_auxiliareswwds_13_tipaddsc3), 100, "%");
         lV67Contabilidad_auxiliareswwds_13_tipaddsc3 = StringUtil.PadR( StringUtil.RTrim( AV67Contabilidad_auxiliareswwds_13_tipaddsc3), 100, "%");
         lV68Contabilidad_auxiliareswwds_14_tipadcod3 = StringUtil.PadR( StringUtil.RTrim( AV68Contabilidad_auxiliareswwds_14_tipadcod3), 20, "%");
         lV68Contabilidad_auxiliareswwds_14_tipadcod3 = StringUtil.PadR( StringUtil.RTrim( AV68Contabilidad_auxiliareswwds_14_tipadcod3), 20, "%");
         lV69Contabilidad_auxiliareswwds_15_tftipadsc = StringUtil.PadR( StringUtil.RTrim( AV69Contabilidad_auxiliareswwds_15_tftipadsc), 100, "%");
         lV71Contabilidad_auxiliareswwds_17_tftipadcod = StringUtil.PadR( StringUtil.RTrim( AV71Contabilidad_auxiliareswwds_17_tftipadcod), 20, "%");
         lV73Contabilidad_auxiliareswwds_19_tftipaddsc = StringUtil.PadR( StringUtil.RTrim( AV73Contabilidad_auxiliareswwds_19_tftipaddsc), 100, "%");
         /* Using cursor H002B3 */
         pr_default.execute(1, new Object[] {lV57Contabilidad_auxiliareswwds_3_tipaddsc1, lV57Contabilidad_auxiliareswwds_3_tipaddsc1, lV58Contabilidad_auxiliareswwds_4_tipadcod1, lV58Contabilidad_auxiliareswwds_4_tipadcod1, lV62Contabilidad_auxiliareswwds_8_tipaddsc2, lV62Contabilidad_auxiliareswwds_8_tipaddsc2, lV63Contabilidad_auxiliareswwds_9_tipadcod2, lV63Contabilidad_auxiliareswwds_9_tipadcod2, lV67Contabilidad_auxiliareswwds_13_tipaddsc3, lV67Contabilidad_auxiliareswwds_13_tipaddsc3, lV68Contabilidad_auxiliareswwds_14_tipadcod3, lV68Contabilidad_auxiliareswwds_14_tipadcod3, lV69Contabilidad_auxiliareswwds_15_tftipadsc, AV70Contabilidad_auxiliareswwds_16_tftipadsc_sel, lV71Contabilidad_auxiliareswwds_17_tftipadcod, AV72Contabilidad_auxiliareswwds_18_tftipadcod_sel, lV73Contabilidad_auxiliareswwds_19_tftipaddsc, AV74Contabilidad_auxiliareswwds_20_tftipaddsc_sel});
         GRID_nRecordCount = H002B3_AGRID_nRecordCount[0];
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
         AV55Contabilidad_auxiliareswwds_1_dynamicfiltersselector1 = AV15DynamicFiltersSelector1;
         AV56Contabilidad_auxiliareswwds_2_dynamicfiltersoperator1 = AV16DynamicFiltersOperator1;
         AV57Contabilidad_auxiliareswwds_3_tipaddsc1 = AV17TipADDsc1;
         AV58Contabilidad_auxiliareswwds_4_tipadcod1 = AV47TipADCod1;
         AV59Contabilidad_auxiliareswwds_5_dynamicfiltersenabled2 = AV18DynamicFiltersEnabled2;
         AV60Contabilidad_auxiliareswwds_6_dynamicfiltersselector2 = AV19DynamicFiltersSelector2;
         AV61Contabilidad_auxiliareswwds_7_dynamicfiltersoperator2 = AV20DynamicFiltersOperator2;
         AV62Contabilidad_auxiliareswwds_8_tipaddsc2 = AV21TipADDsc2;
         AV63Contabilidad_auxiliareswwds_9_tipadcod2 = AV48TipADCod2;
         AV64Contabilidad_auxiliareswwds_10_dynamicfiltersenabled3 = AV22DynamicFiltersEnabled3;
         AV65Contabilidad_auxiliareswwds_11_dynamicfiltersselector3 = AV23DynamicFiltersSelector3;
         AV66Contabilidad_auxiliareswwds_12_dynamicfiltersoperator3 = AV24DynamicFiltersOperator3;
         AV67Contabilidad_auxiliareswwds_13_tipaddsc3 = AV25TipADDsc3;
         AV68Contabilidad_auxiliareswwds_14_tipadcod3 = AV49TipADCod3;
         AV69Contabilidad_auxiliareswwds_15_tftipadsc = AV50TFTipADsc;
         AV70Contabilidad_auxiliareswwds_16_tftipadsc_sel = AV51TFTipADsc_Sel;
         AV71Contabilidad_auxiliareswwds_17_tftipadcod = AV33TFTipADCod;
         AV72Contabilidad_auxiliareswwds_18_tftipadcod_sel = AV34TFTipADCod_Sel;
         AV73Contabilidad_auxiliareswwds_19_tftipaddsc = AV35TFTipADDsc;
         AV74Contabilidad_auxiliareswwds_20_tftipaddsc_sel = AV36TFTipADDsc_Sel;
         AV75Contabilidad_auxiliareswwds_21_tftipadsts_sels = AV38TFTipADSts_Sels;
         GRID_nFirstRecordOnPage = 0;
         GxWebStd.gx_hidden_field( context, "GRID_nFirstRecordOnPage", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRID_nFirstRecordOnPage), 15, 0, ".", "")));
         if ( isFullAjaxMode( ) )
         {
            gxgrGrid_refresh( subGrid_Rows, AV15DynamicFiltersSelector1, AV16DynamicFiltersOperator1, AV17TipADDsc1, AV47TipADCod1, AV19DynamicFiltersSelector2, AV20DynamicFiltersOperator2, AV21TipADDsc2, AV48TipADCod2, AV23DynamicFiltersSelector3, AV24DynamicFiltersOperator3, AV25TipADDsc3, AV49TipADCod3, AV18DynamicFiltersEnabled2, AV22DynamicFiltersEnabled3, AV54Pgmname, AV50TFTipADsc, AV51TFTipADsc_Sel, AV33TFTipADCod, AV34TFTipADCod_Sel, AV35TFTipADDsc, AV36TFTipADDsc_Sel, AV38TFTipADSts_Sels, AV13OrderedBy, AV14OrderedDsc, AV10GridState, AV27DynamicFiltersIgnoreFirst, AV26DynamicFiltersRemoving) ;
         }
         send_integrity_footer_hashes( ) ;
         return 0 ;
      }

      protected short subgrid_nextpage( )
      {
         AV55Contabilidad_auxiliareswwds_1_dynamicfiltersselector1 = AV15DynamicFiltersSelector1;
         AV56Contabilidad_auxiliareswwds_2_dynamicfiltersoperator1 = AV16DynamicFiltersOperator1;
         AV57Contabilidad_auxiliareswwds_3_tipaddsc1 = AV17TipADDsc1;
         AV58Contabilidad_auxiliareswwds_4_tipadcod1 = AV47TipADCod1;
         AV59Contabilidad_auxiliareswwds_5_dynamicfiltersenabled2 = AV18DynamicFiltersEnabled2;
         AV60Contabilidad_auxiliareswwds_6_dynamicfiltersselector2 = AV19DynamicFiltersSelector2;
         AV61Contabilidad_auxiliareswwds_7_dynamicfiltersoperator2 = AV20DynamicFiltersOperator2;
         AV62Contabilidad_auxiliareswwds_8_tipaddsc2 = AV21TipADDsc2;
         AV63Contabilidad_auxiliareswwds_9_tipadcod2 = AV48TipADCod2;
         AV64Contabilidad_auxiliareswwds_10_dynamicfiltersenabled3 = AV22DynamicFiltersEnabled3;
         AV65Contabilidad_auxiliareswwds_11_dynamicfiltersselector3 = AV23DynamicFiltersSelector3;
         AV66Contabilidad_auxiliareswwds_12_dynamicfiltersoperator3 = AV24DynamicFiltersOperator3;
         AV67Contabilidad_auxiliareswwds_13_tipaddsc3 = AV25TipADDsc3;
         AV68Contabilidad_auxiliareswwds_14_tipadcod3 = AV49TipADCod3;
         AV69Contabilidad_auxiliareswwds_15_tftipadsc = AV50TFTipADsc;
         AV70Contabilidad_auxiliareswwds_16_tftipadsc_sel = AV51TFTipADsc_Sel;
         AV71Contabilidad_auxiliareswwds_17_tftipadcod = AV33TFTipADCod;
         AV72Contabilidad_auxiliareswwds_18_tftipadcod_sel = AV34TFTipADCod_Sel;
         AV73Contabilidad_auxiliareswwds_19_tftipaddsc = AV35TFTipADDsc;
         AV74Contabilidad_auxiliareswwds_20_tftipaddsc_sel = AV36TFTipADDsc_Sel;
         AV75Contabilidad_auxiliareswwds_21_tftipadsts_sels = AV38TFTipADSts_Sels;
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
            gxgrGrid_refresh( subGrid_Rows, AV15DynamicFiltersSelector1, AV16DynamicFiltersOperator1, AV17TipADDsc1, AV47TipADCod1, AV19DynamicFiltersSelector2, AV20DynamicFiltersOperator2, AV21TipADDsc2, AV48TipADCod2, AV23DynamicFiltersSelector3, AV24DynamicFiltersOperator3, AV25TipADDsc3, AV49TipADCod3, AV18DynamicFiltersEnabled2, AV22DynamicFiltersEnabled3, AV54Pgmname, AV50TFTipADsc, AV51TFTipADsc_Sel, AV33TFTipADCod, AV34TFTipADCod_Sel, AV35TFTipADDsc, AV36TFTipADDsc_Sel, AV38TFTipADSts_Sels, AV13OrderedBy, AV14OrderedDsc, AV10GridState, AV27DynamicFiltersIgnoreFirst, AV26DynamicFiltersRemoving) ;
         }
         send_integrity_footer_hashes( ) ;
         return (short)(((GRID_nEOF==0) ? 0 : 2)) ;
      }

      protected short subgrid_previouspage( )
      {
         AV55Contabilidad_auxiliareswwds_1_dynamicfiltersselector1 = AV15DynamicFiltersSelector1;
         AV56Contabilidad_auxiliareswwds_2_dynamicfiltersoperator1 = AV16DynamicFiltersOperator1;
         AV57Contabilidad_auxiliareswwds_3_tipaddsc1 = AV17TipADDsc1;
         AV58Contabilidad_auxiliareswwds_4_tipadcod1 = AV47TipADCod1;
         AV59Contabilidad_auxiliareswwds_5_dynamicfiltersenabled2 = AV18DynamicFiltersEnabled2;
         AV60Contabilidad_auxiliareswwds_6_dynamicfiltersselector2 = AV19DynamicFiltersSelector2;
         AV61Contabilidad_auxiliareswwds_7_dynamicfiltersoperator2 = AV20DynamicFiltersOperator2;
         AV62Contabilidad_auxiliareswwds_8_tipaddsc2 = AV21TipADDsc2;
         AV63Contabilidad_auxiliareswwds_9_tipadcod2 = AV48TipADCod2;
         AV64Contabilidad_auxiliareswwds_10_dynamicfiltersenabled3 = AV22DynamicFiltersEnabled3;
         AV65Contabilidad_auxiliareswwds_11_dynamicfiltersselector3 = AV23DynamicFiltersSelector3;
         AV66Contabilidad_auxiliareswwds_12_dynamicfiltersoperator3 = AV24DynamicFiltersOperator3;
         AV67Contabilidad_auxiliareswwds_13_tipaddsc3 = AV25TipADDsc3;
         AV68Contabilidad_auxiliareswwds_14_tipadcod3 = AV49TipADCod3;
         AV69Contabilidad_auxiliareswwds_15_tftipadsc = AV50TFTipADsc;
         AV70Contabilidad_auxiliareswwds_16_tftipadsc_sel = AV51TFTipADsc_Sel;
         AV71Contabilidad_auxiliareswwds_17_tftipadcod = AV33TFTipADCod;
         AV72Contabilidad_auxiliareswwds_18_tftipadcod_sel = AV34TFTipADCod_Sel;
         AV73Contabilidad_auxiliareswwds_19_tftipaddsc = AV35TFTipADDsc;
         AV74Contabilidad_auxiliareswwds_20_tftipaddsc_sel = AV36TFTipADDsc_Sel;
         AV75Contabilidad_auxiliareswwds_21_tftipadsts_sels = AV38TFTipADSts_Sels;
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
            gxgrGrid_refresh( subGrid_Rows, AV15DynamicFiltersSelector1, AV16DynamicFiltersOperator1, AV17TipADDsc1, AV47TipADCod1, AV19DynamicFiltersSelector2, AV20DynamicFiltersOperator2, AV21TipADDsc2, AV48TipADCod2, AV23DynamicFiltersSelector3, AV24DynamicFiltersOperator3, AV25TipADDsc3, AV49TipADCod3, AV18DynamicFiltersEnabled2, AV22DynamicFiltersEnabled3, AV54Pgmname, AV50TFTipADsc, AV51TFTipADsc_Sel, AV33TFTipADCod, AV34TFTipADCod_Sel, AV35TFTipADDsc, AV36TFTipADDsc_Sel, AV38TFTipADSts_Sels, AV13OrderedBy, AV14OrderedDsc, AV10GridState, AV27DynamicFiltersIgnoreFirst, AV26DynamicFiltersRemoving) ;
         }
         send_integrity_footer_hashes( ) ;
         return 0 ;
      }

      protected short subgrid_lastpage( )
      {
         AV55Contabilidad_auxiliareswwds_1_dynamicfiltersselector1 = AV15DynamicFiltersSelector1;
         AV56Contabilidad_auxiliareswwds_2_dynamicfiltersoperator1 = AV16DynamicFiltersOperator1;
         AV57Contabilidad_auxiliareswwds_3_tipaddsc1 = AV17TipADDsc1;
         AV58Contabilidad_auxiliareswwds_4_tipadcod1 = AV47TipADCod1;
         AV59Contabilidad_auxiliareswwds_5_dynamicfiltersenabled2 = AV18DynamicFiltersEnabled2;
         AV60Contabilidad_auxiliareswwds_6_dynamicfiltersselector2 = AV19DynamicFiltersSelector2;
         AV61Contabilidad_auxiliareswwds_7_dynamicfiltersoperator2 = AV20DynamicFiltersOperator2;
         AV62Contabilidad_auxiliareswwds_8_tipaddsc2 = AV21TipADDsc2;
         AV63Contabilidad_auxiliareswwds_9_tipadcod2 = AV48TipADCod2;
         AV64Contabilidad_auxiliareswwds_10_dynamicfiltersenabled3 = AV22DynamicFiltersEnabled3;
         AV65Contabilidad_auxiliareswwds_11_dynamicfiltersselector3 = AV23DynamicFiltersSelector3;
         AV66Contabilidad_auxiliareswwds_12_dynamicfiltersoperator3 = AV24DynamicFiltersOperator3;
         AV67Contabilidad_auxiliareswwds_13_tipaddsc3 = AV25TipADDsc3;
         AV68Contabilidad_auxiliareswwds_14_tipadcod3 = AV49TipADCod3;
         AV69Contabilidad_auxiliareswwds_15_tftipadsc = AV50TFTipADsc;
         AV70Contabilidad_auxiliareswwds_16_tftipadsc_sel = AV51TFTipADsc_Sel;
         AV71Contabilidad_auxiliareswwds_17_tftipadcod = AV33TFTipADCod;
         AV72Contabilidad_auxiliareswwds_18_tftipadcod_sel = AV34TFTipADCod_Sel;
         AV73Contabilidad_auxiliareswwds_19_tftipaddsc = AV35TFTipADDsc;
         AV74Contabilidad_auxiliareswwds_20_tftipaddsc_sel = AV36TFTipADDsc_Sel;
         AV75Contabilidad_auxiliareswwds_21_tftipadsts_sels = AV38TFTipADSts_Sels;
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
            gxgrGrid_refresh( subGrid_Rows, AV15DynamicFiltersSelector1, AV16DynamicFiltersOperator1, AV17TipADDsc1, AV47TipADCod1, AV19DynamicFiltersSelector2, AV20DynamicFiltersOperator2, AV21TipADDsc2, AV48TipADCod2, AV23DynamicFiltersSelector3, AV24DynamicFiltersOperator3, AV25TipADDsc3, AV49TipADCod3, AV18DynamicFiltersEnabled2, AV22DynamicFiltersEnabled3, AV54Pgmname, AV50TFTipADsc, AV51TFTipADsc_Sel, AV33TFTipADCod, AV34TFTipADCod_Sel, AV35TFTipADDsc, AV36TFTipADDsc_Sel, AV38TFTipADSts_Sels, AV13OrderedBy, AV14OrderedDsc, AV10GridState, AV27DynamicFiltersIgnoreFirst, AV26DynamicFiltersRemoving) ;
         }
         send_integrity_footer_hashes( ) ;
         return 0 ;
      }

      protected int subgrid_gotopage( int nPageNo )
      {
         AV55Contabilidad_auxiliareswwds_1_dynamicfiltersselector1 = AV15DynamicFiltersSelector1;
         AV56Contabilidad_auxiliareswwds_2_dynamicfiltersoperator1 = AV16DynamicFiltersOperator1;
         AV57Contabilidad_auxiliareswwds_3_tipaddsc1 = AV17TipADDsc1;
         AV58Contabilidad_auxiliareswwds_4_tipadcod1 = AV47TipADCod1;
         AV59Contabilidad_auxiliareswwds_5_dynamicfiltersenabled2 = AV18DynamicFiltersEnabled2;
         AV60Contabilidad_auxiliareswwds_6_dynamicfiltersselector2 = AV19DynamicFiltersSelector2;
         AV61Contabilidad_auxiliareswwds_7_dynamicfiltersoperator2 = AV20DynamicFiltersOperator2;
         AV62Contabilidad_auxiliareswwds_8_tipaddsc2 = AV21TipADDsc2;
         AV63Contabilidad_auxiliareswwds_9_tipadcod2 = AV48TipADCod2;
         AV64Contabilidad_auxiliareswwds_10_dynamicfiltersenabled3 = AV22DynamicFiltersEnabled3;
         AV65Contabilidad_auxiliareswwds_11_dynamicfiltersselector3 = AV23DynamicFiltersSelector3;
         AV66Contabilidad_auxiliareswwds_12_dynamicfiltersoperator3 = AV24DynamicFiltersOperator3;
         AV67Contabilidad_auxiliareswwds_13_tipaddsc3 = AV25TipADDsc3;
         AV68Contabilidad_auxiliareswwds_14_tipadcod3 = AV49TipADCod3;
         AV69Contabilidad_auxiliareswwds_15_tftipadsc = AV50TFTipADsc;
         AV70Contabilidad_auxiliareswwds_16_tftipadsc_sel = AV51TFTipADsc_Sel;
         AV71Contabilidad_auxiliareswwds_17_tftipadcod = AV33TFTipADCod;
         AV72Contabilidad_auxiliareswwds_18_tftipadcod_sel = AV34TFTipADCod_Sel;
         AV73Contabilidad_auxiliareswwds_19_tftipaddsc = AV35TFTipADDsc;
         AV74Contabilidad_auxiliareswwds_20_tftipaddsc_sel = AV36TFTipADDsc_Sel;
         AV75Contabilidad_auxiliareswwds_21_tftipadsts_sels = AV38TFTipADSts_Sels;
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
            gxgrGrid_refresh( subGrid_Rows, AV15DynamicFiltersSelector1, AV16DynamicFiltersOperator1, AV17TipADDsc1, AV47TipADCod1, AV19DynamicFiltersSelector2, AV20DynamicFiltersOperator2, AV21TipADDsc2, AV48TipADCod2, AV23DynamicFiltersSelector3, AV24DynamicFiltersOperator3, AV25TipADDsc3, AV49TipADCod3, AV18DynamicFiltersEnabled2, AV22DynamicFiltersEnabled3, AV54Pgmname, AV50TFTipADsc, AV51TFTipADsc_Sel, AV33TFTipADCod, AV34TFTipADCod_Sel, AV35TFTipADDsc, AV36TFTipADDsc_Sel, AV38TFTipADSts_Sels, AV13OrderedBy, AV14OrderedDsc, AV10GridState, AV27DynamicFiltersIgnoreFirst, AV26DynamicFiltersRemoving) ;
         }
         send_integrity_footer_hashes( ) ;
         return (int)(0) ;
      }

      protected void before_start_formulas( )
      {
         AV54Pgmname = "Contabilidad.AuxiliaresWW";
         context.Gx_err = 0;
         fix_multi_value_controls( ) ;
      }

      protected void STRUP2B0( )
      {
         /* Before Start, stand alone formulas. */
         before_start_formulas( ) ;
         /* Execute Start event if defined. */
         context.wbGlbDoneStart = 0;
         /* Execute user event: Start */
         E242B2 ();
         context.wbGlbDoneStart = 1;
         /* After Start, stand alone formulas. */
         if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
         {
            /* Read saved SDTs. */
            ajax_req_read_hidden_sdt(cgiGet( "vAGEXPORTDATA"), AV45AGExportData);
            ajax_req_read_hidden_sdt(cgiGet( "vDDO_TITLESETTINGSICONS"), AV39DDO_TitleSettingsIcons);
            /* Read saved values. */
            nRC_GXsfl_110 = (int)(context.localUtil.CToN( cgiGet( "nRC_GXsfl_110"), ".", ","));
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
            Ddo_grid_Selectedvalue_set = cgiGet( "DDO_GRID_Selectedvalue_set");
            Ddo_grid_Gridinternalname = cgiGet( "DDO_GRID_Gridinternalname");
            Ddo_grid_Columnids = cgiGet( "DDO_GRID_Columnids");
            Ddo_grid_Columnssortvalues = cgiGet( "DDO_GRID_Columnssortvalues");
            Ddo_grid_Includesortasc = cgiGet( "DDO_GRID_Includesortasc");
            Ddo_grid_Sortedstatus = cgiGet( "DDO_GRID_Sortedstatus");
            Ddo_grid_Includefilter = cgiGet( "DDO_GRID_Includefilter");
            Ddo_grid_Filtertype = cgiGet( "DDO_GRID_Filtertype");
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
            AV17TipADDsc1 = cgiGet( edtavTipaddsc1_Internalname);
            AssignAttri("", false, "AV17TipADDsc1", AV17TipADDsc1);
            AV47TipADCod1 = cgiGet( edtavTipadcod1_Internalname);
            AssignAttri("", false, "AV47TipADCod1", AV47TipADCod1);
            cmbavDynamicfiltersselector2.Name = cmbavDynamicfiltersselector2_Internalname;
            cmbavDynamicfiltersselector2.CurrentValue = cgiGet( cmbavDynamicfiltersselector2_Internalname);
            AV19DynamicFiltersSelector2 = cgiGet( cmbavDynamicfiltersselector2_Internalname);
            AssignAttri("", false, "AV19DynamicFiltersSelector2", AV19DynamicFiltersSelector2);
            cmbavDynamicfiltersoperator2.Name = cmbavDynamicfiltersoperator2_Internalname;
            cmbavDynamicfiltersoperator2.CurrentValue = cgiGet( cmbavDynamicfiltersoperator2_Internalname);
            AV20DynamicFiltersOperator2 = (short)(NumberUtil.Val( cgiGet( cmbavDynamicfiltersoperator2_Internalname), "."));
            AssignAttri("", false, "AV20DynamicFiltersOperator2", StringUtil.LTrimStr( (decimal)(AV20DynamicFiltersOperator2), 4, 0));
            AV21TipADDsc2 = cgiGet( edtavTipaddsc2_Internalname);
            AssignAttri("", false, "AV21TipADDsc2", AV21TipADDsc2);
            AV48TipADCod2 = cgiGet( edtavTipadcod2_Internalname);
            AssignAttri("", false, "AV48TipADCod2", AV48TipADCod2);
            cmbavDynamicfiltersselector3.Name = cmbavDynamicfiltersselector3_Internalname;
            cmbavDynamicfiltersselector3.CurrentValue = cgiGet( cmbavDynamicfiltersselector3_Internalname);
            AV23DynamicFiltersSelector3 = cgiGet( cmbavDynamicfiltersselector3_Internalname);
            AssignAttri("", false, "AV23DynamicFiltersSelector3", AV23DynamicFiltersSelector3);
            cmbavDynamicfiltersoperator3.Name = cmbavDynamicfiltersoperator3_Internalname;
            cmbavDynamicfiltersoperator3.CurrentValue = cgiGet( cmbavDynamicfiltersoperator3_Internalname);
            AV24DynamicFiltersOperator3 = (short)(NumberUtil.Val( cgiGet( cmbavDynamicfiltersoperator3_Internalname), "."));
            AssignAttri("", false, "AV24DynamicFiltersOperator3", StringUtil.LTrimStr( (decimal)(AV24DynamicFiltersOperator3), 4, 0));
            AV25TipADDsc3 = cgiGet( edtavTipaddsc3_Internalname);
            AssignAttri("", false, "AV25TipADDsc3", AV25TipADDsc3);
            AV49TipADCod3 = cgiGet( edtavTipadcod3_Internalname);
            AssignAttri("", false, "AV49TipADCod3", AV49TipADCod3);
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
            if ( StringUtil.StrCmp(cgiGet( "GXH_vTIPADDSC1"), AV17TipADDsc1) != 0 )
            {
               GRID_nFirstRecordOnPage = 0;
            }
            if ( StringUtil.StrCmp(cgiGet( "GXH_vTIPADCOD1"), AV47TipADCod1) != 0 )
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
            if ( StringUtil.StrCmp(cgiGet( "GXH_vTIPADDSC2"), AV21TipADDsc2) != 0 )
            {
               GRID_nFirstRecordOnPage = 0;
            }
            if ( StringUtil.StrCmp(cgiGet( "GXH_vTIPADCOD2"), AV48TipADCod2) != 0 )
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
            if ( StringUtil.StrCmp(cgiGet( "GXH_vTIPADDSC3"), AV25TipADDsc3) != 0 )
            {
               GRID_nFirstRecordOnPage = 0;
            }
            if ( StringUtil.StrCmp(cgiGet( "GXH_vTIPADCOD3"), AV49TipADCod3) != 0 )
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
         E242B2 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
      }

      protected void E242B2( )
      {
         /* Start Routine */
         returnInSub = false;
         subGrid_Rows = 10;
         GxWebStd.gx_hidden_field( context, "GRID_Rows", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid_Rows), 6, 0, ".", "")));
         Grid_empowerer_Gridinternalname = subGrid_Internalname;
         ucGrid_empowerer.SendProperty(context, "", false, Grid_empowerer_Internalname, "GridInternalName", Grid_empowerer_Gridinternalname);
         lblJsdynamicfilters_Caption = "";
         AssignProp("", false, lblJsdynamicfilters_Internalname, "Caption", lblJsdynamicfilters_Caption, true);
         AV15DynamicFiltersSelector1 = "TIPADDSC";
         AssignAttri("", false, "AV15DynamicFiltersSelector1", AV15DynamicFiltersSelector1);
         /* Execute user subroutine: 'ENABLEDYNAMICFILTERS1' */
         S112 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
         AV19DynamicFiltersSelector2 = "TIPADDSC";
         AssignAttri("", false, "AV19DynamicFiltersSelector2", AV19DynamicFiltersSelector2);
         /* Execute user subroutine: 'ENABLEDYNAMICFILTERS2' */
         S122 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
         AV23DynamicFiltersSelector3 = "TIPADDSC";
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
         Form.Caption = " Auxiliares";
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

      protected void E252B2( )
      {
         if ( gx_refresh_fired )
         {
            return  ;
         }
         gx_refresh_fired = true;
         /* Refresh Routine */
         returnInSub = false;
         new GeneXus.Programs.wwpbaseobjects.loadwwpcontext(context ).execute( out  AV6WWPContext) ;
         cmbavDynamicfiltersoperator1.removeAllItems();
         if ( StringUtil.StrCmp(AV15DynamicFiltersSelector1, "TIPADDSC") == 0 )
         {
            cmbavDynamicfiltersoperator1.addItem("0", "Comienza con", 0);
            cmbavDynamicfiltersoperator1.addItem("1", "Contiene", 0);
         }
         else if ( StringUtil.StrCmp(AV15DynamicFiltersSelector1, "TIPADCOD") == 0 )
         {
            cmbavDynamicfiltersoperator1.addItem("0", "Comienza con", 0);
            cmbavDynamicfiltersoperator1.addItem("1", "Contiene", 0);
         }
         if ( AV18DynamicFiltersEnabled2 )
         {
            cmbavDynamicfiltersoperator2.removeAllItems();
            if ( StringUtil.StrCmp(AV19DynamicFiltersSelector2, "TIPADDSC") == 0 )
            {
               cmbavDynamicfiltersoperator2.addItem("0", "Comienza con", 0);
               cmbavDynamicfiltersoperator2.addItem("1", "Contiene", 0);
            }
            else if ( StringUtil.StrCmp(AV19DynamicFiltersSelector2, "TIPADCOD") == 0 )
            {
               cmbavDynamicfiltersoperator2.addItem("0", "Comienza con", 0);
               cmbavDynamicfiltersoperator2.addItem("1", "Contiene", 0);
            }
            if ( AV22DynamicFiltersEnabled3 )
            {
               cmbavDynamicfiltersoperator3.removeAllItems();
               if ( StringUtil.StrCmp(AV23DynamicFiltersSelector3, "TIPADDSC") == 0 )
               {
                  cmbavDynamicfiltersoperator3.addItem("0", "Comienza con", 0);
                  cmbavDynamicfiltersoperator3.addItem("1", "Contiene", 0);
               }
               else if ( StringUtil.StrCmp(AV23DynamicFiltersSelector3, "TIPADCOD") == 0 )
               {
                  cmbavDynamicfiltersoperator3.addItem("0", "Comienza con", 0);
                  cmbavDynamicfiltersoperator3.addItem("1", "Contiene", 0);
               }
            }
         }
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
         new GeneXus.Programs.wwpbaseobjects.wwp_getappliedfiltersdescription(context ).execute(  AV54Pgmname, out  GXt_char2) ;
         AV43GridAppliedFilters = GXt_char2;
         AssignAttri("", false, "AV43GridAppliedFilters", AV43GridAppliedFilters);
         AV55Contabilidad_auxiliareswwds_1_dynamicfiltersselector1 = AV15DynamicFiltersSelector1;
         AV56Contabilidad_auxiliareswwds_2_dynamicfiltersoperator1 = AV16DynamicFiltersOperator1;
         AV57Contabilidad_auxiliareswwds_3_tipaddsc1 = AV17TipADDsc1;
         AV58Contabilidad_auxiliareswwds_4_tipadcod1 = AV47TipADCod1;
         AV59Contabilidad_auxiliareswwds_5_dynamicfiltersenabled2 = AV18DynamicFiltersEnabled2;
         AV60Contabilidad_auxiliareswwds_6_dynamicfiltersselector2 = AV19DynamicFiltersSelector2;
         AV61Contabilidad_auxiliareswwds_7_dynamicfiltersoperator2 = AV20DynamicFiltersOperator2;
         AV62Contabilidad_auxiliareswwds_8_tipaddsc2 = AV21TipADDsc2;
         AV63Contabilidad_auxiliareswwds_9_tipadcod2 = AV48TipADCod2;
         AV64Contabilidad_auxiliareswwds_10_dynamicfiltersenabled3 = AV22DynamicFiltersEnabled3;
         AV65Contabilidad_auxiliareswwds_11_dynamicfiltersselector3 = AV23DynamicFiltersSelector3;
         AV66Contabilidad_auxiliareswwds_12_dynamicfiltersoperator3 = AV24DynamicFiltersOperator3;
         AV67Contabilidad_auxiliareswwds_13_tipaddsc3 = AV25TipADDsc3;
         AV68Contabilidad_auxiliareswwds_14_tipadcod3 = AV49TipADCod3;
         AV69Contabilidad_auxiliareswwds_15_tftipadsc = AV50TFTipADsc;
         AV70Contabilidad_auxiliareswwds_16_tftipadsc_sel = AV51TFTipADsc_Sel;
         AV71Contabilidad_auxiliareswwds_17_tftipadcod = AV33TFTipADCod;
         AV72Contabilidad_auxiliareswwds_18_tftipadcod_sel = AV34TFTipADCod_Sel;
         AV73Contabilidad_auxiliareswwds_19_tftipaddsc = AV35TFTipADDsc;
         AV74Contabilidad_auxiliareswwds_20_tftipaddsc_sel = AV36TFTipADDsc_Sel;
         AV75Contabilidad_auxiliareswwds_21_tftipadsts_sels = AV38TFTipADSts_Sels;
         /*  Sending Event outputs  */
         cmbavDynamicfiltersoperator1.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV16DynamicFiltersOperator1), 4, 0));
         AssignProp("", false, cmbavDynamicfiltersoperator1_Internalname, "Values", cmbavDynamicfiltersoperator1.ToJavascriptSource(), true);
         cmbavDynamicfiltersoperator2.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV20DynamicFiltersOperator2), 4, 0));
         AssignProp("", false, cmbavDynamicfiltersoperator2_Internalname, "Values", cmbavDynamicfiltersoperator2.ToJavascriptSource(), true);
         cmbavDynamicfiltersoperator3.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV24DynamicFiltersOperator3), 4, 0));
         AssignProp("", false, cmbavDynamicfiltersoperator3_Internalname, "Values", cmbavDynamicfiltersoperator3.ToJavascriptSource(), true);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV10GridState", AV10GridState);
      }

      protected void E112B2( )
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

      protected void E122B2( )
      {
         /* Gridpaginationbar_Changerowsperpage Routine */
         returnInSub = false;
         subGrid_Rows = Gridpaginationbar_Rowsperpageselectedvalue;
         GxWebStd.gx_hidden_field( context, "GRID_Rows", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid_Rows), 6, 0, ".", "")));
         subgrid_firstpage( ) ;
         /*  Sending Event outputs  */
      }

      protected void E142B2( )
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
            if ( StringUtil.StrCmp(Ddo_grid_Selectedcolumn, "TipADsc") == 0 )
            {
               AV50TFTipADsc = Ddo_grid_Filteredtext_get;
               AssignAttri("", false, "AV50TFTipADsc", AV50TFTipADsc);
               AV51TFTipADsc_Sel = Ddo_grid_Selectedvalue_get;
               AssignAttri("", false, "AV51TFTipADsc_Sel", AV51TFTipADsc_Sel);
            }
            else if ( StringUtil.StrCmp(Ddo_grid_Selectedcolumn, "TipADCod") == 0 )
            {
               AV33TFTipADCod = Ddo_grid_Filteredtext_get;
               AssignAttri("", false, "AV33TFTipADCod", AV33TFTipADCod);
               AV34TFTipADCod_Sel = Ddo_grid_Selectedvalue_get;
               AssignAttri("", false, "AV34TFTipADCod_Sel", AV34TFTipADCod_Sel);
            }
            else if ( StringUtil.StrCmp(Ddo_grid_Selectedcolumn, "TipADDsc") == 0 )
            {
               AV35TFTipADDsc = Ddo_grid_Filteredtext_get;
               AssignAttri("", false, "AV35TFTipADDsc", AV35TFTipADDsc);
               AV36TFTipADDsc_Sel = Ddo_grid_Selectedvalue_get;
               AssignAttri("", false, "AV36TFTipADDsc_Sel", AV36TFTipADDsc_Sel);
            }
            else if ( StringUtil.StrCmp(Ddo_grid_Selectedcolumn, "TipADSts") == 0 )
            {
               AV37TFTipADSts_SelsJson = Ddo_grid_Selectedvalue_get;
               AssignAttri("", false, "AV37TFTipADSts_SelsJson", AV37TFTipADSts_SelsJson);
               AV38TFTipADSts_Sels.FromJSonString(StringUtil.StringReplace( AV37TFTipADSts_SelsJson, "\"", ""), null);
            }
            subgrid_firstpage( ) ;
         }
         /*  Sending Event outputs  */
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV38TFTipADSts_Sels", AV38TFTipADSts_Sels);
      }

      private void E262B2( )
      {
         /* Grid_Load Routine */
         returnInSub = false;
         cmbavGridactions.removeAllItems();
         cmbavGridactions.addItem("0", ";fa fa-bars", 0);
         cmbavGridactions.addItem("1", StringUtil.Format( "%1;%2", "Modificar", "fa fa-pen", "", "", "", "", "", "", ""), 0);
         cmbavGridactions.addItem("2", StringUtil.Format( "%1;%2", "Eliminar", "fa fa-times", "", "", "", "", "", "", ""), 0);
         GXKey = Crypto.GetSiteKey( );
         GXEncryptionTmp = "contabilidad.tipoauxiliar.aspx"+UrlEncode(StringUtil.RTrim("DSP")) + "," + UrlEncode(StringUtil.LTrimStr(A70TipACod,6,0));
         edtTipADsc_Link = formatLink("contabilidad.tipoauxiliar.aspx") + "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey);
         GXKey = Crypto.GetSiteKey( );
         GXEncryptionTmp = "contabilidad.auxiliares.aspx"+UrlEncode(StringUtil.RTrim("DSP")) + "," + UrlEncode(StringUtil.LTrimStr(A70TipACod,6,0)) + "," + UrlEncode(StringUtil.RTrim(A71TipADCod));
         edtTipADDsc_Link = formatLink("contabilidad.auxiliares.aspx") + "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey);
         /* Load Method */
         if ( wbStart != -1 )
         {
            wbStart = 110;
         }
         sendrow_1102( ) ;
         GRID_nCurrentRecord = (long)(GRID_nCurrentRecord+1);
         if ( isFullAjaxMode( ) && ! bGXsfl_110_Refreshing )
         {
            DoAjaxLoad(110, GridRow);
         }
         /*  Sending Event outputs  */
         cmbavGridactions.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV44GridActions), 4, 0));
      }

      protected void E192B2( )
      {
         /* 'AddDynamicFilters1' Routine */
         returnInSub = false;
         AV18DynamicFiltersEnabled2 = true;
         AssignAttri("", false, "AV18DynamicFiltersEnabled2", AV18DynamicFiltersEnabled2);
         imgAdddynamicfilters1_Visible = 0;
         AssignProp("", false, imgAdddynamicfilters1_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(imgAdddynamicfilters1_Visible), 5, 0), true);
         imgRemovedynamicfilters1_Visible = 1;
         AssignProp("", false, imgRemovedynamicfilters1_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(imgRemovedynamicfilters1_Visible), 5, 0), true);
         gxgrGrid_refresh( subGrid_Rows, AV15DynamicFiltersSelector1, AV16DynamicFiltersOperator1, AV17TipADDsc1, AV47TipADCod1, AV19DynamicFiltersSelector2, AV20DynamicFiltersOperator2, AV21TipADDsc2, AV48TipADCod2, AV23DynamicFiltersSelector3, AV24DynamicFiltersOperator3, AV25TipADDsc3, AV49TipADCod3, AV18DynamicFiltersEnabled2, AV22DynamicFiltersEnabled3, AV54Pgmname, AV50TFTipADsc, AV51TFTipADsc_Sel, AV33TFTipADCod, AV34TFTipADCod_Sel, AV35TFTipADDsc, AV36TFTipADDsc_Sel, AV38TFTipADSts_Sels, AV13OrderedBy, AV14OrderedDsc, AV10GridState, AV27DynamicFiltersIgnoreFirst, AV26DynamicFiltersRemoving) ;
         /*  Sending Event outputs  */
         cmbavDynamicfiltersoperator1.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV16DynamicFiltersOperator1), 4, 0));
         AssignProp("", false, cmbavDynamicfiltersoperator1_Internalname, "Values", cmbavDynamicfiltersoperator1.ToJavascriptSource(), true);
         cmbavDynamicfiltersoperator2.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV20DynamicFiltersOperator2), 4, 0));
         AssignProp("", false, cmbavDynamicfiltersoperator2_Internalname, "Values", cmbavDynamicfiltersoperator2.ToJavascriptSource(), true);
         cmbavDynamicfiltersoperator3.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV24DynamicFiltersOperator3), 4, 0));
         AssignProp("", false, cmbavDynamicfiltersoperator3_Internalname, "Values", cmbavDynamicfiltersoperator3.ToJavascriptSource(), true);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV10GridState", AV10GridState);
      }

      protected void E152B2( )
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
         gxgrGrid_refresh( subGrid_Rows, AV15DynamicFiltersSelector1, AV16DynamicFiltersOperator1, AV17TipADDsc1, AV47TipADCod1, AV19DynamicFiltersSelector2, AV20DynamicFiltersOperator2, AV21TipADDsc2, AV48TipADCod2, AV23DynamicFiltersSelector3, AV24DynamicFiltersOperator3, AV25TipADDsc3, AV49TipADCod3, AV18DynamicFiltersEnabled2, AV22DynamicFiltersEnabled3, AV54Pgmname, AV50TFTipADsc, AV51TFTipADsc_Sel, AV33TFTipADCod, AV34TFTipADCod_Sel, AV35TFTipADDsc, AV36TFTipADDsc_Sel, AV38TFTipADSts_Sels, AV13OrderedBy, AV14OrderedDsc, AV10GridState, AV27DynamicFiltersIgnoreFirst, AV26DynamicFiltersRemoving) ;
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

      protected void E202B2( )
      {
         /* Dynamicfiltersselector1_Click Routine */
         returnInSub = false;
         AV16DynamicFiltersOperator1 = 0;
         AssignAttri("", false, "AV16DynamicFiltersOperator1", StringUtil.LTrimStr( (decimal)(AV16DynamicFiltersOperator1), 4, 0));
         /* Execute user subroutine: 'ENABLEDYNAMICFILTERS1' */
         S112 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
         /*  Sending Event outputs  */
         cmbavDynamicfiltersoperator1.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV16DynamicFiltersOperator1), 4, 0));
         AssignProp("", false, cmbavDynamicfiltersoperator1_Internalname, "Values", cmbavDynamicfiltersoperator1.ToJavascriptSource(), true);
      }

      protected void E212B2( )
      {
         /* 'AddDynamicFilters2' Routine */
         returnInSub = false;
         AV22DynamicFiltersEnabled3 = true;
         AssignAttri("", false, "AV22DynamicFiltersEnabled3", AV22DynamicFiltersEnabled3);
         imgAdddynamicfilters2_Visible = 0;
         AssignProp("", false, imgAdddynamicfilters2_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(imgAdddynamicfilters2_Visible), 5, 0), true);
         imgRemovedynamicfilters2_Visible = 1;
         AssignProp("", false, imgRemovedynamicfilters2_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(imgRemovedynamicfilters2_Visible), 5, 0), true);
         gxgrGrid_refresh( subGrid_Rows, AV15DynamicFiltersSelector1, AV16DynamicFiltersOperator1, AV17TipADDsc1, AV47TipADCod1, AV19DynamicFiltersSelector2, AV20DynamicFiltersOperator2, AV21TipADDsc2, AV48TipADCod2, AV23DynamicFiltersSelector3, AV24DynamicFiltersOperator3, AV25TipADDsc3, AV49TipADCod3, AV18DynamicFiltersEnabled2, AV22DynamicFiltersEnabled3, AV54Pgmname, AV50TFTipADsc, AV51TFTipADsc_Sel, AV33TFTipADCod, AV34TFTipADCod_Sel, AV35TFTipADDsc, AV36TFTipADDsc_Sel, AV38TFTipADSts_Sels, AV13OrderedBy, AV14OrderedDsc, AV10GridState, AV27DynamicFiltersIgnoreFirst, AV26DynamicFiltersRemoving) ;
         /*  Sending Event outputs  */
         cmbavDynamicfiltersoperator1.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV16DynamicFiltersOperator1), 4, 0));
         AssignProp("", false, cmbavDynamicfiltersoperator1_Internalname, "Values", cmbavDynamicfiltersoperator1.ToJavascriptSource(), true);
         cmbavDynamicfiltersoperator2.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV20DynamicFiltersOperator2), 4, 0));
         AssignProp("", false, cmbavDynamicfiltersoperator2_Internalname, "Values", cmbavDynamicfiltersoperator2.ToJavascriptSource(), true);
         cmbavDynamicfiltersoperator3.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV24DynamicFiltersOperator3), 4, 0));
         AssignProp("", false, cmbavDynamicfiltersoperator3_Internalname, "Values", cmbavDynamicfiltersoperator3.ToJavascriptSource(), true);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV10GridState", AV10GridState);
      }

      protected void E162B2( )
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
         gxgrGrid_refresh( subGrid_Rows, AV15DynamicFiltersSelector1, AV16DynamicFiltersOperator1, AV17TipADDsc1, AV47TipADCod1, AV19DynamicFiltersSelector2, AV20DynamicFiltersOperator2, AV21TipADDsc2, AV48TipADCod2, AV23DynamicFiltersSelector3, AV24DynamicFiltersOperator3, AV25TipADDsc3, AV49TipADCod3, AV18DynamicFiltersEnabled2, AV22DynamicFiltersEnabled3, AV54Pgmname, AV50TFTipADsc, AV51TFTipADsc_Sel, AV33TFTipADCod, AV34TFTipADCod_Sel, AV35TFTipADDsc, AV36TFTipADDsc_Sel, AV38TFTipADSts_Sels, AV13OrderedBy, AV14OrderedDsc, AV10GridState, AV27DynamicFiltersIgnoreFirst, AV26DynamicFiltersRemoving) ;
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

      protected void E222B2( )
      {
         /* Dynamicfiltersselector2_Click Routine */
         returnInSub = false;
         AV20DynamicFiltersOperator2 = 0;
         AssignAttri("", false, "AV20DynamicFiltersOperator2", StringUtil.LTrimStr( (decimal)(AV20DynamicFiltersOperator2), 4, 0));
         /* Execute user subroutine: 'ENABLEDYNAMICFILTERS2' */
         S122 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
         /*  Sending Event outputs  */
         cmbavDynamicfiltersoperator2.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV20DynamicFiltersOperator2), 4, 0));
         AssignProp("", false, cmbavDynamicfiltersoperator2_Internalname, "Values", cmbavDynamicfiltersoperator2.ToJavascriptSource(), true);
      }

      protected void E172B2( )
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
         gxgrGrid_refresh( subGrid_Rows, AV15DynamicFiltersSelector1, AV16DynamicFiltersOperator1, AV17TipADDsc1, AV47TipADCod1, AV19DynamicFiltersSelector2, AV20DynamicFiltersOperator2, AV21TipADDsc2, AV48TipADCod2, AV23DynamicFiltersSelector3, AV24DynamicFiltersOperator3, AV25TipADDsc3, AV49TipADCod3, AV18DynamicFiltersEnabled2, AV22DynamicFiltersEnabled3, AV54Pgmname, AV50TFTipADsc, AV51TFTipADsc_Sel, AV33TFTipADCod, AV34TFTipADCod_Sel, AV35TFTipADDsc, AV36TFTipADDsc_Sel, AV38TFTipADSts_Sels, AV13OrderedBy, AV14OrderedDsc, AV10GridState, AV27DynamicFiltersIgnoreFirst, AV26DynamicFiltersRemoving) ;
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

      protected void E232B2( )
      {
         /* Dynamicfiltersselector3_Click Routine */
         returnInSub = false;
         AV24DynamicFiltersOperator3 = 0;
         AssignAttri("", false, "AV24DynamicFiltersOperator3", StringUtil.LTrimStr( (decimal)(AV24DynamicFiltersOperator3), 4, 0));
         /* Execute user subroutine: 'ENABLEDYNAMICFILTERS3' */
         S132 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
         /*  Sending Event outputs  */
         cmbavDynamicfiltersoperator3.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV24DynamicFiltersOperator3), 4, 0));
         AssignProp("", false, cmbavDynamicfiltersoperator3_Internalname, "Values", cmbavDynamicfiltersoperator3.ToJavascriptSource(), true);
      }

      protected void E272B2( )
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

      protected void E182B2( )
      {
         /* 'DoInsert' Routine */
         returnInSub = false;
         GXKey = Crypto.GetSiteKey( );
         GXEncryptionTmp = "contabilidad.auxiliares.aspx"+UrlEncode(StringUtil.RTrim("INS")) + "," + UrlEncode(StringUtil.LTrimStr(0,1,0)) + "," + UrlEncode(StringUtil.RTrim(""));
         CallWebObject(formatLink("contabilidad.auxiliares.aspx") + "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey));
         context.wjLocDisableFrm = 1;
      }

      protected void E132B2( )
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
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV38TFTipADSts_Sels", AV38TFTipADSts_Sels);
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
         edtavTipaddsc1_Visible = 0;
         AssignProp("", false, edtavTipaddsc1_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavTipaddsc1_Visible), 5, 0), true);
         edtavTipadcod1_Visible = 0;
         AssignProp("", false, edtavTipadcod1_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavTipadcod1_Visible), 5, 0), true);
         cmbavDynamicfiltersoperator1.Visible = 0;
         AssignProp("", false, cmbavDynamicfiltersoperator1_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(cmbavDynamicfiltersoperator1.Visible), 5, 0), true);
         if ( StringUtil.StrCmp(AV15DynamicFiltersSelector1, "TIPADDSC") == 0 )
         {
            edtavTipaddsc1_Visible = 1;
            AssignProp("", false, edtavTipaddsc1_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavTipaddsc1_Visible), 5, 0), true);
            cmbavDynamicfiltersoperator1.Visible = 1;
            AssignProp("", false, cmbavDynamicfiltersoperator1_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(cmbavDynamicfiltersoperator1.Visible), 5, 0), true);
         }
         else if ( StringUtil.StrCmp(AV15DynamicFiltersSelector1, "TIPADCOD") == 0 )
         {
            edtavTipadcod1_Visible = 1;
            AssignProp("", false, edtavTipadcod1_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavTipadcod1_Visible), 5, 0), true);
            cmbavDynamicfiltersoperator1.Visible = 1;
            AssignProp("", false, cmbavDynamicfiltersoperator1_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(cmbavDynamicfiltersoperator1.Visible), 5, 0), true);
         }
      }

      protected void S122( )
      {
         /* 'ENABLEDYNAMICFILTERS2' Routine */
         returnInSub = false;
         edtavTipaddsc2_Visible = 0;
         AssignProp("", false, edtavTipaddsc2_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavTipaddsc2_Visible), 5, 0), true);
         edtavTipadcod2_Visible = 0;
         AssignProp("", false, edtavTipadcod2_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavTipadcod2_Visible), 5, 0), true);
         cmbavDynamicfiltersoperator2.Visible = 0;
         AssignProp("", false, cmbavDynamicfiltersoperator2_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(cmbavDynamicfiltersoperator2.Visible), 5, 0), true);
         if ( StringUtil.StrCmp(AV19DynamicFiltersSelector2, "TIPADDSC") == 0 )
         {
            edtavTipaddsc2_Visible = 1;
            AssignProp("", false, edtavTipaddsc2_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavTipaddsc2_Visible), 5, 0), true);
            cmbavDynamicfiltersoperator2.Visible = 1;
            AssignProp("", false, cmbavDynamicfiltersoperator2_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(cmbavDynamicfiltersoperator2.Visible), 5, 0), true);
         }
         else if ( StringUtil.StrCmp(AV19DynamicFiltersSelector2, "TIPADCOD") == 0 )
         {
            edtavTipadcod2_Visible = 1;
            AssignProp("", false, edtavTipadcod2_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavTipadcod2_Visible), 5, 0), true);
            cmbavDynamicfiltersoperator2.Visible = 1;
            AssignProp("", false, cmbavDynamicfiltersoperator2_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(cmbavDynamicfiltersoperator2.Visible), 5, 0), true);
         }
      }

      protected void S132( )
      {
         /* 'ENABLEDYNAMICFILTERS3' Routine */
         returnInSub = false;
         edtavTipaddsc3_Visible = 0;
         AssignProp("", false, edtavTipaddsc3_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavTipaddsc3_Visible), 5, 0), true);
         edtavTipadcod3_Visible = 0;
         AssignProp("", false, edtavTipadcod3_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavTipadcod3_Visible), 5, 0), true);
         cmbavDynamicfiltersoperator3.Visible = 0;
         AssignProp("", false, cmbavDynamicfiltersoperator3_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(cmbavDynamicfiltersoperator3.Visible), 5, 0), true);
         if ( StringUtil.StrCmp(AV23DynamicFiltersSelector3, "TIPADDSC") == 0 )
         {
            edtavTipaddsc3_Visible = 1;
            AssignProp("", false, edtavTipaddsc3_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavTipaddsc3_Visible), 5, 0), true);
            cmbavDynamicfiltersoperator3.Visible = 1;
            AssignProp("", false, cmbavDynamicfiltersoperator3_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(cmbavDynamicfiltersoperator3.Visible), 5, 0), true);
         }
         else if ( StringUtil.StrCmp(AV23DynamicFiltersSelector3, "TIPADCOD") == 0 )
         {
            edtavTipadcod3_Visible = 1;
            AssignProp("", false, edtavTipadcod3_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavTipadcod3_Visible), 5, 0), true);
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
         AV19DynamicFiltersSelector2 = "TIPADDSC";
         AssignAttri("", false, "AV19DynamicFiltersSelector2", AV19DynamicFiltersSelector2);
         AV20DynamicFiltersOperator2 = 0;
         AssignAttri("", false, "AV20DynamicFiltersOperator2", StringUtil.LTrimStr( (decimal)(AV20DynamicFiltersOperator2), 4, 0));
         AV21TipADDsc2 = "";
         AssignAttri("", false, "AV21TipADDsc2", AV21TipADDsc2);
         /* Execute user subroutine: 'ENABLEDYNAMICFILTERS2' */
         S122 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
         AV22DynamicFiltersEnabled3 = false;
         AssignAttri("", false, "AV22DynamicFiltersEnabled3", AV22DynamicFiltersEnabled3);
         AV23DynamicFiltersSelector3 = "TIPADDSC";
         AssignAttri("", false, "AV23DynamicFiltersSelector3", AV23DynamicFiltersSelector3);
         AV24DynamicFiltersOperator3 = 0;
         AssignAttri("", false, "AV24DynamicFiltersOperator3", StringUtil.LTrimStr( (decimal)(AV24DynamicFiltersOperator3), 4, 0));
         AV25TipADDsc3 = "";
         AssignAttri("", false, "AV25TipADDsc3", AV25TipADDsc3);
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
         GXEncryptionTmp = "contabilidad.auxiliares.aspx"+UrlEncode(StringUtil.RTrim("UPD")) + "," + UrlEncode(StringUtil.LTrimStr(A70TipACod,6,0)) + "," + UrlEncode(StringUtil.RTrim(A71TipADCod));
         CallWebObject(formatLink("contabilidad.auxiliares.aspx") + "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey));
         context.wjLocDisableFrm = 1;
      }

      protected void S222( )
      {
         /* 'DO DELETE' Routine */
         returnInSub = false;
         GXKey = Crypto.GetSiteKey( );
         GXEncryptionTmp = "contabilidad.auxiliares.aspx"+UrlEncode(StringUtil.RTrim("DLT")) + "," + UrlEncode(StringUtil.LTrimStr(A70TipACod,6,0)) + "," + UrlEncode(StringUtil.RTrim(A71TipADCod));
         CallWebObject(formatLink("contabilidad.auxiliares.aspx") + "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey));
         context.wjLocDisableFrm = 1;
      }

      protected void S152( )
      {
         /* 'LOADGRIDSTATE' Routine */
         returnInSub = false;
         if ( StringUtil.StrCmp(AV30Session.Get(AV54Pgmname+"GridState"), "") == 0 )
         {
            AV10GridState.FromXml(new GeneXus.Programs.wwpbaseobjects.loadgridstate(context).executeUdp(  AV54Pgmname+"GridState"), null, "", "");
         }
         else
         {
            AV10GridState.FromXml(AV30Session.Get(AV54Pgmname+"GridState"), null, "", "");
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
         AV76GXV1 = 1;
         while ( AV76GXV1 <= AV10GridState.gxTpr_Filtervalues.Count )
         {
            AV11GridStateFilterValue = ((GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue)AV10GridState.gxTpr_Filtervalues.Item(AV76GXV1));
            if ( StringUtil.StrCmp(AV11GridStateFilterValue.gxTpr_Name, "TFTIPADSC") == 0 )
            {
               AV50TFTipADsc = AV11GridStateFilterValue.gxTpr_Value;
               AssignAttri("", false, "AV50TFTipADsc", AV50TFTipADsc);
            }
            else if ( StringUtil.StrCmp(AV11GridStateFilterValue.gxTpr_Name, "TFTIPADSC_SEL") == 0 )
            {
               AV51TFTipADsc_Sel = AV11GridStateFilterValue.gxTpr_Value;
               AssignAttri("", false, "AV51TFTipADsc_Sel", AV51TFTipADsc_Sel);
            }
            else if ( StringUtil.StrCmp(AV11GridStateFilterValue.gxTpr_Name, "TFTIPADCOD") == 0 )
            {
               AV33TFTipADCod = AV11GridStateFilterValue.gxTpr_Value;
               AssignAttri("", false, "AV33TFTipADCod", AV33TFTipADCod);
            }
            else if ( StringUtil.StrCmp(AV11GridStateFilterValue.gxTpr_Name, "TFTIPADCOD_SEL") == 0 )
            {
               AV34TFTipADCod_Sel = AV11GridStateFilterValue.gxTpr_Value;
               AssignAttri("", false, "AV34TFTipADCod_Sel", AV34TFTipADCod_Sel);
            }
            else if ( StringUtil.StrCmp(AV11GridStateFilterValue.gxTpr_Name, "TFTIPADDSC") == 0 )
            {
               AV35TFTipADDsc = AV11GridStateFilterValue.gxTpr_Value;
               AssignAttri("", false, "AV35TFTipADDsc", AV35TFTipADDsc);
            }
            else if ( StringUtil.StrCmp(AV11GridStateFilterValue.gxTpr_Name, "TFTIPADDSC_SEL") == 0 )
            {
               AV36TFTipADDsc_Sel = AV11GridStateFilterValue.gxTpr_Value;
               AssignAttri("", false, "AV36TFTipADDsc_Sel", AV36TFTipADDsc_Sel);
            }
            else if ( StringUtil.StrCmp(AV11GridStateFilterValue.gxTpr_Name, "TFTIPADSTS_SEL") == 0 )
            {
               AV37TFTipADSts_SelsJson = AV11GridStateFilterValue.gxTpr_Value;
               AssignAttri("", false, "AV37TFTipADSts_SelsJson", AV37TFTipADSts_SelsJson);
               AV38TFTipADSts_Sels.FromJSonString(AV37TFTipADSts_SelsJson, null);
            }
            AV76GXV1 = (int)(AV76GXV1+1);
         }
         GXt_char2 = "";
         new GeneXus.Programs.wwpbaseobjects.wwp_getfilterval(context ).execute(  String.IsNullOrEmpty(StringUtil.RTrim( AV51TFTipADsc_Sel)),  AV51TFTipADsc_Sel, out  GXt_char2) ;
         GXt_char3 = "";
         new GeneXus.Programs.wwpbaseobjects.wwp_getfilterval(context ).execute(  String.IsNullOrEmpty(StringUtil.RTrim( AV34TFTipADCod_Sel)),  AV34TFTipADCod_Sel, out  GXt_char3) ;
         GXt_char4 = "";
         new GeneXus.Programs.wwpbaseobjects.wwp_getfilterval(context ).execute(  String.IsNullOrEmpty(StringUtil.RTrim( AV36TFTipADDsc_Sel)),  AV36TFTipADDsc_Sel, out  GXt_char4) ;
         Ddo_grid_Selectedvalue_set = GXt_char2+"|"+GXt_char3+"|"+GXt_char4+"|"+((AV38TFTipADSts_Sels.Count==0) ? "" : AV37TFTipADSts_SelsJson);
         ucDdo_grid.SendProperty(context, "", false, Ddo_grid_Internalname, "SelectedValue_set", Ddo_grid_Selectedvalue_set);
         GXt_char4 = "";
         new GeneXus.Programs.wwpbaseobjects.wwp_getfilterval(context ).execute(  String.IsNullOrEmpty(StringUtil.RTrim( AV50TFTipADsc)),  AV50TFTipADsc, out  GXt_char4) ;
         GXt_char3 = "";
         new GeneXus.Programs.wwpbaseobjects.wwp_getfilterval(context ).execute(  String.IsNullOrEmpty(StringUtil.RTrim( AV33TFTipADCod)),  AV33TFTipADCod, out  GXt_char3) ;
         GXt_char2 = "";
         new GeneXus.Programs.wwpbaseobjects.wwp_getfilterval(context ).execute(  String.IsNullOrEmpty(StringUtil.RTrim( AV35TFTipADDsc)),  AV35TFTipADDsc, out  GXt_char2) ;
         Ddo_grid_Filteredtext_set = GXt_char4+"|"+GXt_char3+"|"+GXt_char2+"|";
         ucDdo_grid.SendProperty(context, "", false, Ddo_grid_Internalname, "FilteredText_set", Ddo_grid_Filteredtext_set);
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
            if ( StringUtil.StrCmp(AV15DynamicFiltersSelector1, "TIPADDSC") == 0 )
            {
               AV16DynamicFiltersOperator1 = AV12GridStateDynamicFilter.gxTpr_Operator;
               AssignAttri("", false, "AV16DynamicFiltersOperator1", StringUtil.LTrimStr( (decimal)(AV16DynamicFiltersOperator1), 4, 0));
               AV17TipADDsc1 = AV12GridStateDynamicFilter.gxTpr_Value;
               AssignAttri("", false, "AV17TipADDsc1", AV17TipADDsc1);
            }
            else if ( StringUtil.StrCmp(AV15DynamicFiltersSelector1, "TIPADCOD") == 0 )
            {
               AV16DynamicFiltersOperator1 = AV12GridStateDynamicFilter.gxTpr_Operator;
               AssignAttri("", false, "AV16DynamicFiltersOperator1", StringUtil.LTrimStr( (decimal)(AV16DynamicFiltersOperator1), 4, 0));
               AV47TipADCod1 = AV12GridStateDynamicFilter.gxTpr_Value;
               AssignAttri("", false, "AV47TipADCod1", AV47TipADCod1);
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
               if ( StringUtil.StrCmp(AV19DynamicFiltersSelector2, "TIPADDSC") == 0 )
               {
                  AV20DynamicFiltersOperator2 = AV12GridStateDynamicFilter.gxTpr_Operator;
                  AssignAttri("", false, "AV20DynamicFiltersOperator2", StringUtil.LTrimStr( (decimal)(AV20DynamicFiltersOperator2), 4, 0));
                  AV21TipADDsc2 = AV12GridStateDynamicFilter.gxTpr_Value;
                  AssignAttri("", false, "AV21TipADDsc2", AV21TipADDsc2);
               }
               else if ( StringUtil.StrCmp(AV19DynamicFiltersSelector2, "TIPADCOD") == 0 )
               {
                  AV20DynamicFiltersOperator2 = AV12GridStateDynamicFilter.gxTpr_Operator;
                  AssignAttri("", false, "AV20DynamicFiltersOperator2", StringUtil.LTrimStr( (decimal)(AV20DynamicFiltersOperator2), 4, 0));
                  AV48TipADCod2 = AV12GridStateDynamicFilter.gxTpr_Value;
                  AssignAttri("", false, "AV48TipADCod2", AV48TipADCod2);
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
                  if ( StringUtil.StrCmp(AV23DynamicFiltersSelector3, "TIPADDSC") == 0 )
                  {
                     AV24DynamicFiltersOperator3 = AV12GridStateDynamicFilter.gxTpr_Operator;
                     AssignAttri("", false, "AV24DynamicFiltersOperator3", StringUtil.LTrimStr( (decimal)(AV24DynamicFiltersOperator3), 4, 0));
                     AV25TipADDsc3 = AV12GridStateDynamicFilter.gxTpr_Value;
                     AssignAttri("", false, "AV25TipADDsc3", AV25TipADDsc3);
                  }
                  else if ( StringUtil.StrCmp(AV23DynamicFiltersSelector3, "TIPADCOD") == 0 )
                  {
                     AV24DynamicFiltersOperator3 = AV12GridStateDynamicFilter.gxTpr_Operator;
                     AssignAttri("", false, "AV24DynamicFiltersOperator3", StringUtil.LTrimStr( (decimal)(AV24DynamicFiltersOperator3), 4, 0));
                     AV49TipADCod3 = AV12GridStateDynamicFilter.gxTpr_Value;
                     AssignAttri("", false, "AV49TipADCod3", AV49TipADCod3);
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
         AV10GridState.FromXml(AV30Session.Get(AV54Pgmname+"GridState"), null, "", "");
         AV10GridState.gxTpr_Orderedby = AV13OrderedBy;
         AV10GridState.gxTpr_Ordereddsc = AV14OrderedDsc;
         AV10GridState.gxTpr_Filtervalues.Clear();
         new GeneXus.Programs.wwpbaseobjects.wwp_gridstateaddfiltervalueandsel(context ).execute( ref  AV10GridState,  "TFTIPADSC",  "Tipo de Auxiliar",  !String.IsNullOrEmpty(StringUtil.RTrim( AV50TFTipADsc)),  0,  AV50TFTipADsc,  "",  !String.IsNullOrEmpty(StringUtil.RTrim( AV51TFTipADsc_Sel)),  AV51TFTipADsc_Sel,  "") ;
         new GeneXus.Programs.wwpbaseobjects.wwp_gridstateaddfiltervalueandsel(context ).execute( ref  AV10GridState,  "TFTIPADCOD",  "Codigo",  !String.IsNullOrEmpty(StringUtil.RTrim( AV33TFTipADCod)),  0,  AV33TFTipADCod,  "",  !String.IsNullOrEmpty(StringUtil.RTrim( AV34TFTipADCod_Sel)),  AV34TFTipADCod_Sel,  "") ;
         new GeneXus.Programs.wwpbaseobjects.wwp_gridstateaddfiltervalueandsel(context ).execute( ref  AV10GridState,  "TFTIPADDSC",  "Auxiliar",  !String.IsNullOrEmpty(StringUtil.RTrim( AV35TFTipADDsc)),  0,  AV35TFTipADDsc,  "",  !String.IsNullOrEmpty(StringUtil.RTrim( AV36TFTipADDsc_Sel)),  AV36TFTipADDsc_Sel,  "") ;
         new GeneXus.Programs.wwpbaseobjects.wwp_gridstateaddfiltervalue(context ).execute( ref  AV10GridState,  "TFTIPADSTS_SEL",  "Estado",  !(AV38TFTipADSts_Sels.Count==0),  0,  AV38TFTipADSts_Sels.ToJSonString(false),  "") ;
         /* Execute user subroutine: 'SAVEDYNFILTERSSTATE' */
         S182 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
         AV10GridState.gxTpr_Pagesize = StringUtil.Str( (decimal)(subGrid_Rows), 10, 0);
         AV10GridState.gxTpr_Currentpage = (short)(subGrid_fnc_Currentpage( ));
         new GeneXus.Programs.wwpbaseobjects.savegridstate(context ).execute(  AV54Pgmname+"GridState",  AV10GridState.ToXml(false, true, "", "")) ;
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
            if ( ( StringUtil.StrCmp(AV15DynamicFiltersSelector1, "TIPADDSC") == 0 ) && ! String.IsNullOrEmpty(StringUtil.RTrim( AV17TipADDsc1)) )
            {
               AV12GridStateDynamicFilter.gxTpr_Dsc = "Auxiliar";
               AV12GridStateDynamicFilter.gxTpr_Value = AV17TipADDsc1;
               AV12GridStateDynamicFilter.gxTpr_Operator = AV16DynamicFiltersOperator1;
            }
            else if ( ( StringUtil.StrCmp(AV15DynamicFiltersSelector1, "TIPADCOD") == 0 ) && ! String.IsNullOrEmpty(StringUtil.RTrim( AV47TipADCod1)) )
            {
               AV12GridStateDynamicFilter.gxTpr_Dsc = "Codigo Auxiliar";
               AV12GridStateDynamicFilter.gxTpr_Value = AV47TipADCod1;
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
            if ( ( StringUtil.StrCmp(AV19DynamicFiltersSelector2, "TIPADDSC") == 0 ) && ! String.IsNullOrEmpty(StringUtil.RTrim( AV21TipADDsc2)) )
            {
               AV12GridStateDynamicFilter.gxTpr_Dsc = "Auxiliar";
               AV12GridStateDynamicFilter.gxTpr_Value = AV21TipADDsc2;
               AV12GridStateDynamicFilter.gxTpr_Operator = AV20DynamicFiltersOperator2;
            }
            else if ( ( StringUtil.StrCmp(AV19DynamicFiltersSelector2, "TIPADCOD") == 0 ) && ! String.IsNullOrEmpty(StringUtil.RTrim( AV48TipADCod2)) )
            {
               AV12GridStateDynamicFilter.gxTpr_Dsc = "Codigo Auxiliar";
               AV12GridStateDynamicFilter.gxTpr_Value = AV48TipADCod2;
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
            if ( ( StringUtil.StrCmp(AV23DynamicFiltersSelector3, "TIPADDSC") == 0 ) && ! String.IsNullOrEmpty(StringUtil.RTrim( AV25TipADDsc3)) )
            {
               AV12GridStateDynamicFilter.gxTpr_Dsc = "Auxiliar";
               AV12GridStateDynamicFilter.gxTpr_Value = AV25TipADDsc3;
               AV12GridStateDynamicFilter.gxTpr_Operator = AV24DynamicFiltersOperator3;
            }
            else if ( ( StringUtil.StrCmp(AV23DynamicFiltersSelector3, "TIPADCOD") == 0 ) && ! String.IsNullOrEmpty(StringUtil.RTrim( AV49TipADCod3)) )
            {
               AV12GridStateDynamicFilter.gxTpr_Dsc = "Codigo Auxiliar";
               AV12GridStateDynamicFilter.gxTpr_Value = AV49TipADCod3;
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
         AV8TrnContext.gxTpr_Callerobject = AV54Pgmname;
         AV8TrnContext.gxTpr_Callerondelete = true;
         AV8TrnContext.gxTpr_Callerurl = AV7HTTPRequest.ScriptName+"?"+AV7HTTPRequest.QueryString;
         AV8TrnContext.gxTpr_Transactionname = "Contabilidad.Auxiliares";
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
         new GeneXus.Programs.contabilidad.auxiliareswwexport(context ).execute( out  AV28ExcelFilename, out  AV29ErrorMessage) ;
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
         Innewwindow1_Target = formatLink("contabilidad.auxiliareswwexportreport.aspx") ;
         ucInnewwindow1.SendProperty(context, "", false, Innewwindow1_Internalname, "Target", Innewwindow1_Target);
         Innewwindow1_Height = "600";
         ucInnewwindow1.SendProperty(context, "", false, Innewwindow1_Internalname, "Height", Innewwindow1_Height);
         Innewwindow1_Width = "800";
         ucInnewwindow1.SendProperty(context, "", false, Innewwindow1_Internalname, "Width", Innewwindow1_Width);
         this.executeUsercontrolMethod("", false, "INNEWWINDOW1Container", "OpenWindow", "", new Object[] {});
      }

      protected void wb_table1_25_2B2( bool wbgen )
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
            GxWebStd.gx_label_ctrl( context, lblDynamicfiltersprefix1_Internalname, "Buscar en", "", "", lblDynamicfiltersprefix1_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "DataFilterDescriptionPrefix", 0, "", 1, 1, 0, 0, "HLP_Contabilidad\\AuxiliaresWW.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "", "left", "top", "", "flex-grow:1;", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "left", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, cmbavDynamicfiltersselector1_Internalname, "Dynamic Filters Selector1", "gx-form-item AttributeLabel", 0, true, "width: 25%;");
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 35,'',false,'" + sGXsfl_110_idx + "',0)\"";
            /* ComboBox */
            GxWebStd.gx_combobox_ctrl1( context, cmbavDynamicfiltersselector1, cmbavDynamicfiltersselector1_Internalname, StringUtil.RTrim( AV15DynamicFiltersSelector1), 1, cmbavDynamicfiltersselector1_Jsonclick, 5, "'"+""+"'"+",false,"+"'"+"EVDYNAMICFILTERSSELECTOR1.CLICK."+"'", "svchar", "", 1, cmbavDynamicfiltersselector1.Enabled, 0, 0, 0, "em", 0, "", "", "Attribute", "", "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,35);\"", "", true, 1, "HLP_Contabilidad\\AuxiliaresWW.htm");
            cmbavDynamicfiltersselector1.CurrentValue = StringUtil.RTrim( AV15DynamicFiltersSelector1);
            AssignProp("", false, cmbavDynamicfiltersselector1_Internalname, "Values", (string)(cmbavDynamicfiltersselector1.ToJavascriptSource()), true);
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "", "left", "top", "", "flex-grow:1;", "div");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblDynamicfiltersmiddle1_Internalname, "valor", "", "", lblDynamicfiltersmiddle1_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "DataFilterDescription", 0, "", 1, 1, 0, 0, "HLP_Contabilidad\\AuxiliaresWW.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "", "left", "top", "", "flex-grow:1;", "div");
            wb_table2_39_2B2( true) ;
         }
         else
         {
            wb_table2_39_2B2( false) ;
         }
         return  ;
      }

      protected void wb_table2_39_2B2e( bool wbgen )
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
            GxWebStd.gx_label_ctrl( context, lblDynamicfiltersprefix2_Internalname, "Buscar en", "", "", lblDynamicfiltersprefix2_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "DataFilterDescriptionPrefix", 0, "", 1, 1, 0, 0, "HLP_Contabilidad\\AuxiliaresWW.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "Invisible", "left", "top", "", "flex-grow:1;", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "left", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, cmbavDynamicfiltersselector2_Internalname, "Dynamic Filters Selector2", "gx-form-item AttributeLabel", 0, true, "width: 25%;");
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 60,'',false,'" + sGXsfl_110_idx + "',0)\"";
            /* ComboBox */
            GxWebStd.gx_combobox_ctrl1( context, cmbavDynamicfiltersselector2, cmbavDynamicfiltersselector2_Internalname, StringUtil.RTrim( AV19DynamicFiltersSelector2), 1, cmbavDynamicfiltersselector2_Jsonclick, 5, "'"+""+"'"+",false,"+"'"+"EVDYNAMICFILTERSSELECTOR2.CLICK."+"'", "svchar", "", 1, cmbavDynamicfiltersselector2.Enabled, 0, 0, 0, "em", 0, "", "", "Attribute", "", "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,60);\"", "", true, 1, "HLP_Contabilidad\\AuxiliaresWW.htm");
            cmbavDynamicfiltersselector2.CurrentValue = StringUtil.RTrim( AV19DynamicFiltersSelector2);
            AssignProp("", false, cmbavDynamicfiltersselector2_Internalname, "Values", (string)(cmbavDynamicfiltersselector2.ToJavascriptSource()), true);
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "Invisible", "left", "top", "", "flex-grow:1;", "div");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblDynamicfiltersmiddle2_Internalname, "valor", "", "", lblDynamicfiltersmiddle2_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "DataFilterDescription", 0, "", 1, 1, 0, 0, "HLP_Contabilidad\\AuxiliaresWW.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "Invisible", "left", "top", "", "flex-grow:1;", "div");
            wb_table3_64_2B2( true) ;
         }
         else
         {
            wb_table3_64_2B2( false) ;
         }
         return  ;
      }

      protected void wb_table3_64_2B2e( bool wbgen )
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
            GxWebStd.gx_label_ctrl( context, lblDynamicfiltersprefix3_Internalname, "Buscar en", "", "", lblDynamicfiltersprefix3_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "DataFilterDescriptionPrefix", 0, "", 1, 1, 0, 0, "HLP_Contabilidad\\AuxiliaresWW.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "Invisible", "left", "top", "", "flex-grow:1;", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "left", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, cmbavDynamicfiltersselector3_Internalname, "Dynamic Filters Selector3", "gx-form-item AttributeLabel", 0, true, "width: 25%;");
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 85,'',false,'" + sGXsfl_110_idx + "',0)\"";
            /* ComboBox */
            GxWebStd.gx_combobox_ctrl1( context, cmbavDynamicfiltersselector3, cmbavDynamicfiltersselector3_Internalname, StringUtil.RTrim( AV23DynamicFiltersSelector3), 1, cmbavDynamicfiltersselector3_Jsonclick, 5, "'"+""+"'"+",false,"+"'"+"EVDYNAMICFILTERSSELECTOR3.CLICK."+"'", "svchar", "", 1, cmbavDynamicfiltersselector3.Enabled, 0, 0, 0, "em", 0, "", "", "Attribute", "", "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,85);\"", "", true, 1, "HLP_Contabilidad\\AuxiliaresWW.htm");
            cmbavDynamicfiltersselector3.CurrentValue = StringUtil.RTrim( AV23DynamicFiltersSelector3);
            AssignProp("", false, cmbavDynamicfiltersselector3_Internalname, "Values", (string)(cmbavDynamicfiltersselector3.ToJavascriptSource()), true);
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "Invisible", "left", "top", "", "flex-grow:1;", "div");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblDynamicfiltersmiddle3_Internalname, "valor", "", "", lblDynamicfiltersmiddle3_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "DataFilterDescription", 0, "", 1, 1, 0, 0, "HLP_Contabilidad\\AuxiliaresWW.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "Invisible", "left", "top", "", "flex-grow:1;", "div");
            wb_table4_89_2B2( true) ;
         }
         else
         {
            wb_table4_89_2B2( false) ;
         }
         return  ;
      }

      protected void wb_table4_89_2B2e( bool wbgen )
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
            wb_table1_25_2B2e( true) ;
         }
         else
         {
            wb_table1_25_2B2e( false) ;
         }
      }

      protected void wb_table4_89_2B2( bool wbgen )
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
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 93,'',false,'" + sGXsfl_110_idx + "',0)\"";
            /* ComboBox */
            GxWebStd.gx_combobox_ctrl1( context, cmbavDynamicfiltersoperator3, cmbavDynamicfiltersoperator3_Internalname, StringUtil.Trim( StringUtil.Str( (decimal)(AV24DynamicFiltersOperator3), 4, 0)), 1, cmbavDynamicfiltersoperator3_Jsonclick, 0, "'"+""+"'"+",false,"+"'"+""+"'", "int", "", cmbavDynamicfiltersoperator3.Visible, cmbavDynamicfiltersoperator3.Enabled, 0, 0, 0, "em", 0, "", "", "Attribute", "", "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,93);\"", "", true, 1, "HLP_Contabilidad\\AuxiliaresWW.htm");
            cmbavDynamicfiltersoperator3.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV24DynamicFiltersOperator3), 4, 0));
            AssignProp("", false, cmbavDynamicfiltersoperator3_Internalname, "Values", (string)(cmbavDynamicfiltersoperator3.ToJavascriptSource()), true);
            GxWebStd.gx_div_end( context, "left", "top", "div");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "<td id=\""+cellFilter_tipaddsc3_cell_Internalname+"\"  class=''>") ;
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "left", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavTipaddsc3_Internalname, "Tip ADDsc3", "gx-form-item AttributeLabel", 0, true, "width: 25%;");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 96,'',false,'" + sGXsfl_110_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavTipaddsc3_Internalname, StringUtil.RTrim( AV25TipADDsc3), StringUtil.RTrim( context.localUtil.Format( AV25TipADDsc3, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,96);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavTipaddsc3_Jsonclick, 0, "Attribute", "", "", "", "", edtavTipaddsc3_Visible, edtavTipaddsc3_Enabled, 0, "text", "", 80, "chr", 1, "row", 100, 0, 0, 0, 1, -1, -1, true, "", "left", true, "", "HLP_Contabilidad\\AuxiliaresWW.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "<td id=\""+cellFilter_tipadcod3_cell_Internalname+"\"  class=''>") ;
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "left", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavTipadcod3_Internalname, "Tip ADCod3", "gx-form-item AttributeLabel", 0, true, "width: 25%;");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 99,'',false,'" + sGXsfl_110_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavTipadcod3_Internalname, StringUtil.RTrim( AV49TipADCod3), StringUtil.RTrim( context.localUtil.Format( AV49TipADCod3, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,99);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavTipadcod3_Jsonclick, 0, "Attribute", "", "", "", "", edtavTipadcod3_Visible, edtavTipadcod3_Enabled, 0, "text", "", 20, "chr", 1, "row", 20, 0, 0, 0, 1, -1, -1, true, "", "left", true, "", "HLP_Contabilidad\\AuxiliaresWW.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "<td id=\""+cellDynamicfilters_removefilter3_cell_Internalname+"\"  class=''>") ;
            /* Active images/pictures */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 101,'',false,'',0)\"";
            ClassString = "Image";
            StyleString = "";
            sImgUrl = (string)(context.GetImagePath( "11a6ef14-1a5a-4077-91a2-f41ed9a3a662", "", context.GetTheme( )));
            GxWebStd.gx_bitmap( context, imgRemovedynamicfilters3_Internalname, sImgUrl, "", "", "", context.GetTheme( ), 1, 1, "", "Quitar filtro", 0, 0, 0, "px", 0, "px", 0, 0, 5, imgRemovedynamicfilters3_Jsonclick, "'"+""+"'"+",false,"+"'"+"E\\'REMOVEDYNAMICFILTERS3\\'."+"'", StyleString, ClassString, "", "", "", "", " "+"data-gx-image"+" "+TempTags, "", "", 1, false, false, context.GetImageSrcSet( sImgUrl), "HLP_Contabilidad\\AuxiliaresWW.htm");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "</tr>") ;
            /* End of table */
            context.WriteHtmlText( "</table>") ;
            wb_table4_89_2B2e( true) ;
         }
         else
         {
            wb_table4_89_2B2e( false) ;
         }
      }

      protected void wb_table3_64_2B2( bool wbgen )
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
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 68,'',false,'" + sGXsfl_110_idx + "',0)\"";
            /* ComboBox */
            GxWebStd.gx_combobox_ctrl1( context, cmbavDynamicfiltersoperator2, cmbavDynamicfiltersoperator2_Internalname, StringUtil.Trim( StringUtil.Str( (decimal)(AV20DynamicFiltersOperator2), 4, 0)), 1, cmbavDynamicfiltersoperator2_Jsonclick, 0, "'"+""+"'"+",false,"+"'"+""+"'", "int", "", cmbavDynamicfiltersoperator2.Visible, cmbavDynamicfiltersoperator2.Enabled, 0, 0, 0, "em", 0, "", "", "Attribute", "", "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,68);\"", "", true, 1, "HLP_Contabilidad\\AuxiliaresWW.htm");
            cmbavDynamicfiltersoperator2.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV20DynamicFiltersOperator2), 4, 0));
            AssignProp("", false, cmbavDynamicfiltersoperator2_Internalname, "Values", (string)(cmbavDynamicfiltersoperator2.ToJavascriptSource()), true);
            GxWebStd.gx_div_end( context, "left", "top", "div");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "<td id=\""+cellFilter_tipaddsc2_cell_Internalname+"\"  class=''>") ;
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "left", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavTipaddsc2_Internalname, "Tip ADDsc2", "gx-form-item AttributeLabel", 0, true, "width: 25%;");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 71,'',false,'" + sGXsfl_110_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavTipaddsc2_Internalname, StringUtil.RTrim( AV21TipADDsc2), StringUtil.RTrim( context.localUtil.Format( AV21TipADDsc2, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,71);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavTipaddsc2_Jsonclick, 0, "Attribute", "", "", "", "", edtavTipaddsc2_Visible, edtavTipaddsc2_Enabled, 0, "text", "", 80, "chr", 1, "row", 100, 0, 0, 0, 1, -1, -1, true, "", "left", true, "", "HLP_Contabilidad\\AuxiliaresWW.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "<td id=\""+cellFilter_tipadcod2_cell_Internalname+"\"  class=''>") ;
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "left", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavTipadcod2_Internalname, "Tip ADCod2", "gx-form-item AttributeLabel", 0, true, "width: 25%;");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 74,'',false,'" + sGXsfl_110_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavTipadcod2_Internalname, StringUtil.RTrim( AV48TipADCod2), StringUtil.RTrim( context.localUtil.Format( AV48TipADCod2, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,74);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavTipadcod2_Jsonclick, 0, "Attribute", "", "", "", "", edtavTipadcod2_Visible, edtavTipadcod2_Enabled, 0, "text", "", 20, "chr", 1, "row", 20, 0, 0, 0, 1, -1, -1, true, "", "left", true, "", "HLP_Contabilidad\\AuxiliaresWW.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "<td id=\""+cellDynamicfilters_addfilter2_cell_Internalname+"\"  class=''>") ;
            /* Active images/pictures */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 76,'',false,'',0)\"";
            ClassString = "Image";
            StyleString = "";
            sImgUrl = (string)(context.GetImagePath( "27283ea5-332f-423b-b880-64b762622df3", "", context.GetTheme( )));
            GxWebStd.gx_bitmap( context, imgAdddynamicfilters2_Internalname, sImgUrl, "", "", "", context.GetTheme( ), imgAdddynamicfilters2_Visible, 1, "", "Agregar filtro", 0, 0, 0, "px", 0, "px", 0, 0, 5, imgAdddynamicfilters2_Jsonclick, "'"+""+"'"+",false,"+"'"+"E\\'ADDDYNAMICFILTERS2\\'."+"'", StyleString, ClassString, "", "", "", "", " "+"data-gx-image"+" "+TempTags, "", "", 1, false, false, context.GetImageSrcSet( sImgUrl), "HLP_Contabilidad\\AuxiliaresWW.htm");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "<td id=\""+cellDynamicfilters_removefilter2_cell_Internalname+"\"  class=''>") ;
            /* Active images/pictures */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 78,'',false,'',0)\"";
            ClassString = "Image";
            StyleString = "";
            sImgUrl = (string)(context.GetImagePath( "11a6ef14-1a5a-4077-91a2-f41ed9a3a662", "", context.GetTheme( )));
            GxWebStd.gx_bitmap( context, imgRemovedynamicfilters2_Internalname, sImgUrl, "", "", "", context.GetTheme( ), imgRemovedynamicfilters2_Visible, 1, "", "Quitar filtro", 0, 0, 0, "px", 0, "px", 0, 0, 5, imgRemovedynamicfilters2_Jsonclick, "'"+""+"'"+",false,"+"'"+"E\\'REMOVEDYNAMICFILTERS2\\'."+"'", StyleString, ClassString, "", "", "", "", " "+"data-gx-image"+" "+TempTags, "", "", 1, false, false, context.GetImageSrcSet( sImgUrl), "HLP_Contabilidad\\AuxiliaresWW.htm");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "</tr>") ;
            /* End of table */
            context.WriteHtmlText( "</table>") ;
            wb_table3_64_2B2e( true) ;
         }
         else
         {
            wb_table3_64_2B2e( false) ;
         }
      }

      protected void wb_table2_39_2B2( bool wbgen )
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
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 43,'',false,'" + sGXsfl_110_idx + "',0)\"";
            /* ComboBox */
            GxWebStd.gx_combobox_ctrl1( context, cmbavDynamicfiltersoperator1, cmbavDynamicfiltersoperator1_Internalname, StringUtil.Trim( StringUtil.Str( (decimal)(AV16DynamicFiltersOperator1), 4, 0)), 1, cmbavDynamicfiltersoperator1_Jsonclick, 0, "'"+""+"'"+",false,"+"'"+""+"'", "int", "", cmbavDynamicfiltersoperator1.Visible, cmbavDynamicfiltersoperator1.Enabled, 0, 0, 0, "em", 0, "", "", "Attribute", "", "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,43);\"", "", true, 1, "HLP_Contabilidad\\AuxiliaresWW.htm");
            cmbavDynamicfiltersoperator1.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV16DynamicFiltersOperator1), 4, 0));
            AssignProp("", false, cmbavDynamicfiltersoperator1_Internalname, "Values", (string)(cmbavDynamicfiltersoperator1.ToJavascriptSource()), true);
            GxWebStd.gx_div_end( context, "left", "top", "div");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "<td id=\""+cellFilter_tipaddsc1_cell_Internalname+"\"  class=''>") ;
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "left", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavTipaddsc1_Internalname, "Tip ADDsc1", "gx-form-item AttributeLabel", 0, true, "width: 25%;");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 46,'',false,'" + sGXsfl_110_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavTipaddsc1_Internalname, StringUtil.RTrim( AV17TipADDsc1), StringUtil.RTrim( context.localUtil.Format( AV17TipADDsc1, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,46);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavTipaddsc1_Jsonclick, 0, "Attribute", "", "", "", "", edtavTipaddsc1_Visible, edtavTipaddsc1_Enabled, 0, "text", "", 80, "chr", 1, "row", 100, 0, 0, 0, 1, -1, -1, true, "", "left", true, "", "HLP_Contabilidad\\AuxiliaresWW.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "<td id=\""+cellFilter_tipadcod1_cell_Internalname+"\"  class=''>") ;
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "left", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavTipadcod1_Internalname, "Tip ADCod1", "gx-form-item AttributeLabel", 0, true, "width: 25%;");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 49,'',false,'" + sGXsfl_110_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavTipadcod1_Internalname, StringUtil.RTrim( AV47TipADCod1), StringUtil.RTrim( context.localUtil.Format( AV47TipADCod1, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,49);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavTipadcod1_Jsonclick, 0, "Attribute", "", "", "", "", edtavTipadcod1_Visible, edtavTipadcod1_Enabled, 0, "text", "", 20, "chr", 1, "row", 20, 0, 0, 0, 1, -1, -1, true, "", "left", true, "", "HLP_Contabilidad\\AuxiliaresWW.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "<td id=\""+cellDynamicfilters_addfilter1_cell_Internalname+"\"  class=''>") ;
            /* Active images/pictures */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 51,'',false,'',0)\"";
            ClassString = "Image";
            StyleString = "";
            sImgUrl = (string)(context.GetImagePath( "27283ea5-332f-423b-b880-64b762622df3", "", context.GetTheme( )));
            GxWebStd.gx_bitmap( context, imgAdddynamicfilters1_Internalname, sImgUrl, "", "", "", context.GetTheme( ), imgAdddynamicfilters1_Visible, 1, "", "Agregar filtro", 0, 0, 0, "px", 0, "px", 0, 0, 5, imgAdddynamicfilters1_Jsonclick, "'"+""+"'"+",false,"+"'"+"E\\'ADDDYNAMICFILTERS1\\'."+"'", StyleString, ClassString, "", "", "", "", " "+"data-gx-image"+" "+TempTags, "", "", 1, false, false, context.GetImageSrcSet( sImgUrl), "HLP_Contabilidad\\AuxiliaresWW.htm");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "<td id=\""+cellDynamicfilters_removefilter1_cell_Internalname+"\"  class=''>") ;
            /* Active images/pictures */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 53,'',false,'',0)\"";
            ClassString = "Image";
            StyleString = "";
            sImgUrl = (string)(context.GetImagePath( "11a6ef14-1a5a-4077-91a2-f41ed9a3a662", "", context.GetTheme( )));
            GxWebStd.gx_bitmap( context, imgRemovedynamicfilters1_Internalname, sImgUrl, "", "", "", context.GetTheme( ), imgRemovedynamicfilters1_Visible, 1, "", "Quitar filtro", 0, 0, 0, "px", 0, "px", 0, 0, 5, imgRemovedynamicfilters1_Jsonclick, "'"+""+"'"+",false,"+"'"+"E\\'REMOVEDYNAMICFILTERS1\\'."+"'", StyleString, ClassString, "", "", "", "", " "+"data-gx-image"+" "+TempTags, "", "", 1, false, false, context.GetImageSrcSet( sImgUrl), "HLP_Contabilidad\\AuxiliaresWW.htm");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "</tr>") ;
            /* End of table */
            context.WriteHtmlText( "</table>") ;
            wb_table2_39_2B2e( true) ;
         }
         else
         {
            wb_table2_39_2B2e( false) ;
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
         PA2B2( ) ;
         WS2B2( ) ;
         WE2B2( ) ;
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
            context.AddJavascriptSource(StringUtil.RTrim( ((string)Form.Jscriptsrc.Item(idxLst))), "?202281810303661", true, true);
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
         context.AddJavascriptSource("contabilidad/auxiliaresww.js", "?202281810303661", false, true);
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

      protected void SubsflControlProps_1102( )
      {
         cmbavGridactions_Internalname = "vGRIDACTIONS_"+sGXsfl_110_idx;
         edtTipADsc_Internalname = "TIPADSC_"+sGXsfl_110_idx;
         edtTipACod_Internalname = "TIPACOD_"+sGXsfl_110_idx;
         edtTipADCod_Internalname = "TIPADCOD_"+sGXsfl_110_idx;
         edtTipADDsc_Internalname = "TIPADDSC_"+sGXsfl_110_idx;
         edtTipADSts_Internalname = "TIPADSTS_"+sGXsfl_110_idx;
      }

      protected void SubsflControlProps_fel_1102( )
      {
         cmbavGridactions_Internalname = "vGRIDACTIONS_"+sGXsfl_110_fel_idx;
         edtTipADsc_Internalname = "TIPADSC_"+sGXsfl_110_fel_idx;
         edtTipACod_Internalname = "TIPACOD_"+sGXsfl_110_fel_idx;
         edtTipADCod_Internalname = "TIPADCOD_"+sGXsfl_110_fel_idx;
         edtTipADDsc_Internalname = "TIPADDSC_"+sGXsfl_110_fel_idx;
         edtTipADSts_Internalname = "TIPADSTS_"+sGXsfl_110_fel_idx;
      }

      protected void sendrow_1102( )
      {
         SubsflControlProps_1102( ) ;
         WB2B0( ) ;
         if ( ( subGrid_Rows * 1 == 0 ) || ( nGXsfl_110_idx <= subGrid_fnc_Recordsperpage( ) * 1 ) )
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
               if ( ((int)((nGXsfl_110_idx) % (2))) == 0 )
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
               context.WriteHtmlText( " gxrow=\""+sGXsfl_110_idx+"\">") ;
            }
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"right"+"\""+" style=\""+""+"\">") ;
            }
            TempTags = " " + ((cmbavGridactions.Enabled!=0)&&(cmbavGridactions.Visible!=0) ? " onfocus=\"gx.evt.onfocus(this, 111,'',false,'"+sGXsfl_110_idx+"',110)\"" : " ");
            if ( ( cmbavGridactions.ItemCount == 0 ) && isAjaxCallMode( ) )
            {
               GXCCtl = "vGRIDACTIONS_" + sGXsfl_110_idx;
               cmbavGridactions.Name = GXCCtl;
               cmbavGridactions.WebTags = "";
               if ( cmbavGridactions.ItemCount > 0 )
               {
                  AV44GridActions = (short)(NumberUtil.Val( cmbavGridactions.getValidValue(StringUtil.Trim( StringUtil.Str( (decimal)(AV44GridActions), 4, 0))), "."));
                  AssignAttri("", false, cmbavGridactions_Internalname, StringUtil.LTrimStr( (decimal)(AV44GridActions), 4, 0));
               }
            }
            /* ComboBox */
            GridRow.AddColumnProperties("combobox", 2, isAjaxCallMode( ), new Object[] {(GXCombobox)cmbavGridactions,(string)cmbavGridactions_Internalname,StringUtil.Trim( StringUtil.Str( (decimal)(AV44GridActions), 4, 0)),(short)1,(string)cmbavGridactions_Jsonclick,(short)5,"'"+""+"'"+",false,"+"'"+"EVGRIDACTIONS.CLICK."+sGXsfl_110_idx+"'",(string)"int",(string)"",(short)-1,(short)1,(short)0,(short)0,(short)0,(string)"px",(short)0,(string)"px",(string)"",(string)"ConvertToDDO",(string)"WWActionGroupColumn",(string)"",TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+((cmbavGridactions.Enabled!=0)&&(cmbavGridactions.Visible!=0) ? " onblur=\""+""+";gx.evt.onblur(this,111);\"" : " "),(string)"",(bool)true,(short)1});
            cmbavGridactions.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV44GridActions), 4, 0));
            AssignProp("", false, cmbavGridactions_Internalname, "Values", (string)(cmbavGridactions.ToJavascriptSource()), !bGXsfl_110_Refreshing);
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"left"+"\""+" style=\""+""+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtTipADsc_Internalname,StringUtil.RTrim( A1900TipADsc),(string)"",(string)"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)edtTipADsc_Link,(string)"",(string)"",(string)"",(string)edtTipADsc_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn",(string)"",(short)-1,(short)0,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)100,(short)0,(short)0,(short)110,(short)1,(short)-1,(short)-1,(bool)true,(string)"",(string)"left",(bool)true,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"right"+"\""+" style=\""+"display:none;"+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtTipACod_Internalname,StringUtil.LTrim( StringUtil.NToC( (decimal)(A70TipACod), 6, 0, ".", "")),StringUtil.LTrim( context.localUtil.Format( (decimal)(A70TipACod), "ZZZZZ9")),(string)" inputmode=\"numeric\" pattern=\"[0-9]*\""+"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtTipACod_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn hidden-xs",(string)"",(short)0,(short)0,(short)0,(string)"text",(string)"1",(short)0,(string)"px",(short)17,(string)"px",(short)6,(short)0,(short)0,(short)110,(short)1,(short)-1,(short)0,(bool)true,(string)"",(string)"right",(bool)false,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"left"+"\""+" style=\""+""+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtTipADCod_Internalname,StringUtil.RTrim( A71TipADCod),(string)"",(string)"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtTipADCod_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn hidden-xs",(string)"",(short)-1,(short)0,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)20,(short)0,(short)0,(short)110,(short)1,(short)-1,(short)-1,(bool)true,(string)"",(string)"left",(bool)true,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"left"+"\""+" style=\""+""+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtTipADDsc_Internalname,StringUtil.RTrim( A72TipADDsc),(string)"",(string)"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)edtTipADDsc_Link,(string)"",(string)"",(string)"",(string)edtTipADDsc_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn",(string)"",(short)-1,(short)0,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)100,(short)0,(short)0,(short)110,(short)1,(short)-1,(short)-1,(bool)true,(string)"",(string)"left",(bool)true,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"right"+"\""+" style=\""+""+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtTipADSts_Internalname,StringUtil.LTrim( StringUtil.NToC( (decimal)(A1901TipADSts), 1, 0, ".", "")),StringUtil.LTrim( context.localUtil.Format( (decimal)(A1901TipADSts), "9")),(string)" inputmode=\"numeric\" pattern=\"[0-9]*\""+"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtTipADSts_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn hidden-xs",(string)"",(short)-1,(short)0,(short)0,(string)"text",(string)"1",(short)0,(string)"px",(short)17,(string)"px",(short)1,(short)0,(short)0,(short)110,(short)1,(short)-1,(short)0,(bool)true,(string)"",(string)"right",(bool)false,(string)""});
            send_integrity_lvl_hashes2B2( ) ;
            GridContainer.AddRow(GridRow);
            nGXsfl_110_idx = ((subGrid_Islastpage==1)&&(nGXsfl_110_idx+1>subGrid_fnc_Recordsperpage( )) ? 1 : nGXsfl_110_idx+1);
            sGXsfl_110_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_110_idx), 4, 0), 4, "0");
            SubsflControlProps_1102( ) ;
         }
         /* End function sendrow_1102 */
      }

      protected void init_web_controls( )
      {
         cmbavDynamicfiltersselector1.Name = "vDYNAMICFILTERSSELECTOR1";
         cmbavDynamicfiltersselector1.WebTags = "";
         cmbavDynamicfiltersselector1.addItem("TIPADDSC", "Auxiliar", 0);
         cmbavDynamicfiltersselector1.addItem("TIPADCOD", "Codigo Auxiliar", 0);
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
         cmbavDynamicfiltersselector2.addItem("TIPADDSC", "Auxiliar", 0);
         cmbavDynamicfiltersselector2.addItem("TIPADCOD", "Codigo Auxiliar", 0);
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
         cmbavDynamicfiltersselector3.addItem("TIPADDSC", "Auxiliar", 0);
         cmbavDynamicfiltersselector3.addItem("TIPADCOD", "Codigo Auxiliar", 0);
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
         GXCCtl = "vGRIDACTIONS_" + sGXsfl_110_idx;
         cmbavGridactions.Name = GXCCtl;
         cmbavGridactions.WebTags = "";
         if ( cmbavGridactions.ItemCount > 0 )
         {
            AV44GridActions = (short)(NumberUtil.Val( cmbavGridactions.getValidValue(StringUtil.Trim( StringUtil.Str( (decimal)(AV44GridActions), 4, 0))), "."));
            AssignAttri("", false, cmbavGridactions_Internalname, StringUtil.LTrimStr( (decimal)(AV44GridActions), 4, 0));
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
         edtavTipaddsc1_Internalname = "vTIPADDSC1";
         cellFilter_tipaddsc1_cell_Internalname = "FILTER_TIPADDSC1_CELL";
         edtavTipadcod1_Internalname = "vTIPADCOD1";
         cellFilter_tipadcod1_cell_Internalname = "FILTER_TIPADCOD1_CELL";
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
         edtavTipaddsc2_Internalname = "vTIPADDSC2";
         cellFilter_tipaddsc2_cell_Internalname = "FILTER_TIPADDSC2_CELL";
         edtavTipadcod2_Internalname = "vTIPADCOD2";
         cellFilter_tipadcod2_cell_Internalname = "FILTER_TIPADCOD2_CELL";
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
         edtavTipaddsc3_Internalname = "vTIPADDSC3";
         cellFilter_tipaddsc3_cell_Internalname = "FILTER_TIPADDSC3_CELL";
         edtavTipadcod3_Internalname = "vTIPADCOD3";
         cellFilter_tipadcod3_cell_Internalname = "FILTER_TIPADCOD3_CELL";
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
         edtTipADsc_Internalname = "TIPADSC";
         edtTipACod_Internalname = "TIPACOD";
         edtTipADCod_Internalname = "TIPADCOD";
         edtTipADDsc_Internalname = "TIPADDSC";
         edtTipADSts_Internalname = "TIPADSTS";
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
         edtTipADSts_Jsonclick = "";
         edtTipADDsc_Jsonclick = "";
         edtTipADCod_Jsonclick = "";
         edtTipACod_Jsonclick = "";
         edtTipADsc_Jsonclick = "";
         cmbavGridactions_Jsonclick = "";
         cmbavGridactions.Visible = -1;
         cmbavGridactions.Enabled = 1;
         imgRemovedynamicfilters1_Visible = 1;
         imgAdddynamicfilters1_Visible = 1;
         edtavTipadcod1_Jsonclick = "";
         edtavTipadcod1_Enabled = 1;
         edtavTipaddsc1_Jsonclick = "";
         edtavTipaddsc1_Enabled = 1;
         cmbavDynamicfiltersoperator1_Jsonclick = "";
         cmbavDynamicfiltersoperator1.Enabled = 1;
         imgRemovedynamicfilters2_Visible = 1;
         imgAdddynamicfilters2_Visible = 1;
         edtavTipadcod2_Jsonclick = "";
         edtavTipadcod2_Enabled = 1;
         edtavTipaddsc2_Jsonclick = "";
         edtavTipaddsc2_Enabled = 1;
         cmbavDynamicfiltersoperator2_Jsonclick = "";
         cmbavDynamicfiltersoperator2.Enabled = 1;
         edtavTipadcod3_Jsonclick = "";
         edtavTipadcod3_Enabled = 1;
         edtavTipaddsc3_Jsonclick = "";
         edtavTipaddsc3_Enabled = 1;
         cmbavDynamicfiltersoperator3_Jsonclick = "";
         cmbavDynamicfiltersoperator3.Enabled = 1;
         cmbavDynamicfiltersselector3_Jsonclick = "";
         cmbavDynamicfiltersselector3.Enabled = 1;
         cmbavDynamicfiltersselector2_Jsonclick = "";
         cmbavDynamicfiltersselector2.Enabled = 1;
         cmbavDynamicfiltersselector1_Jsonclick = "";
         cmbavDynamicfiltersselector1.Enabled = 1;
         cmbavDynamicfiltersoperator3.Visible = 1;
         edtavTipadcod3_Visible = 1;
         edtavTipaddsc3_Visible = 1;
         cmbavDynamicfiltersoperator2.Visible = 1;
         edtavTipadcod2_Visible = 1;
         edtavTipaddsc2_Visible = 1;
         cmbavDynamicfiltersoperator1.Visible = 1;
         edtavTipadcod1_Visible = 1;
         edtavTipaddsc1_Visible = 1;
         lblJsdynamicfilters_Caption = "JSDynamicFilters";
         subGrid_Allowcollapsing = 0;
         subGrid_Allowselection = 0;
         edtTipADDsc_Link = "";
         edtTipADsc_Link = "";
         subGrid_Sortable = 0;
         subGrid_Header = "";
         subGrid_Class = "GridWithPaginationBar WorkWith";
         subGrid_Backcolorstyle = 0;
         Grid_empowerer_Hastitlesettings = Convert.ToBoolean( -1);
         Innewwindow1_Target = "";
         Innewwindow1_Height = "50";
         Innewwindow1_Width = "50";
         Ddo_grid_Datalistproc = "Contabilidad.AuxiliaresWWGetFilterData";
         Ddo_grid_Datalistfixedvalues = "|||1:ACTIVO,0:INACTIVO";
         Ddo_grid_Allowmultipleselection = "|||T";
         Ddo_grid_Datalisttype = "Dynamic|Dynamic|Dynamic|FixedValues";
         Ddo_grid_Includedatalist = "T";
         Ddo_grid_Filtertype = "Character|Character|Character|";
         Ddo_grid_Includefilter = "T|T|T|";
         Ddo_grid_Includesortasc = "T";
         Ddo_grid_Columnssortvalues = "2|3|4|5";
         Ddo_grid_Columnids = "1:TipADsc|3:TipADCod|4:TipADDsc|5:TipADSts";
         Ddo_grid_Gridinternalname = "";
         Ddo_agexport_Titlecontrolidtoreplace = "";
         Ddo_agexport_Cls = "ColumnsSelector";
         Ddo_agexport_Icon = "fas fa-download";
         Ddo_agexport_Icontype = "FontIcon";
         Gridpaginationbar_Rowsperpagecaption = "WWP_PagingRowsPerPage";
         Gridpaginationbar_Emptygridcaption = "WWP_PagingEmptyGridCaption";
         Gridpaginationbar_Caption = "Página <CURRENT_PAGE> de <TOTAL_PAGES>";
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
         Form.Caption = " Auxiliares";
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
         setEventMetadata("REFRESH","{handler:'Refresh',iparms:[{av:'GRID_nFirstRecordOnPage'},{av:'GRID_nEOF'},{av:'cmbavDynamicfiltersselector1'},{av:'AV15DynamicFiltersSelector1',fld:'vDYNAMICFILTERSSELECTOR1',pic:''},{av:'AV18DynamicFiltersEnabled2',fld:'vDYNAMICFILTERSENABLED2',pic:''},{av:'cmbavDynamicfiltersselector2'},{av:'AV19DynamicFiltersSelector2',fld:'vDYNAMICFILTERSSELECTOR2',pic:''},{av:'AV22DynamicFiltersEnabled3',fld:'vDYNAMICFILTERSENABLED3',pic:''},{av:'cmbavDynamicfiltersselector3'},{av:'AV23DynamicFiltersSelector3',fld:'vDYNAMICFILTERSSELECTOR3',pic:''},{av:'subGrid_Rows',ctrl:'GRID',prop:'Rows'},{av:'cmbavDynamicfiltersoperator1'},{av:'AV16DynamicFiltersOperator1',fld:'vDYNAMICFILTERSOPERATOR1',pic:'ZZZ9'},{av:'AV17TipADDsc1',fld:'vTIPADDSC1',pic:''},{av:'AV47TipADCod1',fld:'vTIPADCOD1',pic:''},{av:'cmbavDynamicfiltersoperator2'},{av:'AV20DynamicFiltersOperator2',fld:'vDYNAMICFILTERSOPERATOR2',pic:'ZZZ9'},{av:'AV21TipADDsc2',fld:'vTIPADDSC2',pic:''},{av:'AV48TipADCod2',fld:'vTIPADCOD2',pic:''},{av:'cmbavDynamicfiltersoperator3'},{av:'AV24DynamicFiltersOperator3',fld:'vDYNAMICFILTERSOPERATOR3',pic:'ZZZ9'},{av:'AV25TipADDsc3',fld:'vTIPADDSC3',pic:''},{av:'AV49TipADCod3',fld:'vTIPADCOD3',pic:''},{av:'AV54Pgmname',fld:'vPGMNAME',pic:'',hsh:true},{av:'AV50TFTipADsc',fld:'vTFTIPADSC',pic:''},{av:'AV51TFTipADsc_Sel',fld:'vTFTIPADSC_SEL',pic:''},{av:'AV33TFTipADCod',fld:'vTFTIPADCOD',pic:''},{av:'AV34TFTipADCod_Sel',fld:'vTFTIPADCOD_SEL',pic:''},{av:'AV35TFTipADDsc',fld:'vTFTIPADDSC',pic:''},{av:'AV36TFTipADDsc_Sel',fld:'vTFTIPADDSC_SEL',pic:''},{av:'AV38TFTipADSts_Sels',fld:'vTFTIPADSTS_SELS',pic:''},{av:'AV13OrderedBy',fld:'vORDEREDBY',pic:'ZZZ9'},{av:'AV14OrderedDsc',fld:'vORDEREDDSC',pic:''},{av:'AV10GridState',fld:'vGRIDSTATE',pic:''},{av:'AV27DynamicFiltersIgnoreFirst',fld:'vDYNAMICFILTERSIGNOREFIRST',pic:''},{av:'AV26DynamicFiltersRemoving',fld:'vDYNAMICFILTERSREMOVING',pic:''}]");
         setEventMetadata("REFRESH",",oparms:[{av:'cmbavDynamicfiltersoperator1'},{av:'AV16DynamicFiltersOperator1',fld:'vDYNAMICFILTERSOPERATOR1',pic:'ZZZ9'},{av:'cmbavDynamicfiltersoperator2'},{av:'AV20DynamicFiltersOperator2',fld:'vDYNAMICFILTERSOPERATOR2',pic:'ZZZ9'},{av:'cmbavDynamicfiltersoperator3'},{av:'AV24DynamicFiltersOperator3',fld:'vDYNAMICFILTERSOPERATOR3',pic:'ZZZ9'},{av:'AV41GridCurrentPage',fld:'vGRIDCURRENTPAGE',pic:'ZZZZZZZZZ9'},{av:'AV42GridPageCount',fld:'vGRIDPAGECOUNT',pic:'ZZZZZZZZZ9'},{av:'AV43GridAppliedFilters',fld:'vGRIDAPPLIEDFILTERS',pic:''},{av:'AV10GridState',fld:'vGRIDSTATE',pic:''}]}");
         setEventMetadata("GRIDPAGINATIONBAR.CHANGEPAGE","{handler:'E112B2',iparms:[{av:'GRID_nFirstRecordOnPage'},{av:'GRID_nEOF'},{av:'subGrid_Rows',ctrl:'GRID',prop:'Rows'},{av:'cmbavDynamicfiltersselector1'},{av:'AV15DynamicFiltersSelector1',fld:'vDYNAMICFILTERSSELECTOR1',pic:''},{av:'cmbavDynamicfiltersoperator1'},{av:'AV16DynamicFiltersOperator1',fld:'vDYNAMICFILTERSOPERATOR1',pic:'ZZZ9'},{av:'AV17TipADDsc1',fld:'vTIPADDSC1',pic:''},{av:'AV47TipADCod1',fld:'vTIPADCOD1',pic:''},{av:'cmbavDynamicfiltersselector2'},{av:'AV19DynamicFiltersSelector2',fld:'vDYNAMICFILTERSSELECTOR2',pic:''},{av:'cmbavDynamicfiltersoperator2'},{av:'AV20DynamicFiltersOperator2',fld:'vDYNAMICFILTERSOPERATOR2',pic:'ZZZ9'},{av:'AV21TipADDsc2',fld:'vTIPADDSC2',pic:''},{av:'AV48TipADCod2',fld:'vTIPADCOD2',pic:''},{av:'cmbavDynamicfiltersselector3'},{av:'AV23DynamicFiltersSelector3',fld:'vDYNAMICFILTERSSELECTOR3',pic:''},{av:'cmbavDynamicfiltersoperator3'},{av:'AV24DynamicFiltersOperator3',fld:'vDYNAMICFILTERSOPERATOR3',pic:'ZZZ9'},{av:'AV25TipADDsc3',fld:'vTIPADDSC3',pic:''},{av:'AV49TipADCod3',fld:'vTIPADCOD3',pic:''},{av:'AV18DynamicFiltersEnabled2',fld:'vDYNAMICFILTERSENABLED2',pic:''},{av:'AV22DynamicFiltersEnabled3',fld:'vDYNAMICFILTERSENABLED3',pic:''},{av:'AV54Pgmname',fld:'vPGMNAME',pic:'',hsh:true},{av:'AV50TFTipADsc',fld:'vTFTIPADSC',pic:''},{av:'AV51TFTipADsc_Sel',fld:'vTFTIPADSC_SEL',pic:''},{av:'AV33TFTipADCod',fld:'vTFTIPADCOD',pic:''},{av:'AV34TFTipADCod_Sel',fld:'vTFTIPADCOD_SEL',pic:''},{av:'AV35TFTipADDsc',fld:'vTFTIPADDSC',pic:''},{av:'AV36TFTipADDsc_Sel',fld:'vTFTIPADDSC_SEL',pic:''},{av:'AV38TFTipADSts_Sels',fld:'vTFTIPADSTS_SELS',pic:''},{av:'AV13OrderedBy',fld:'vORDEREDBY',pic:'ZZZ9'},{av:'AV14OrderedDsc',fld:'vORDEREDDSC',pic:''},{av:'AV10GridState',fld:'vGRIDSTATE',pic:''},{av:'AV27DynamicFiltersIgnoreFirst',fld:'vDYNAMICFILTERSIGNOREFIRST',pic:''},{av:'AV26DynamicFiltersRemoving',fld:'vDYNAMICFILTERSREMOVING',pic:''},{av:'Gridpaginationbar_Selectedpage',ctrl:'GRIDPAGINATIONBAR',prop:'SelectedPage'}]");
         setEventMetadata("GRIDPAGINATIONBAR.CHANGEPAGE",",oparms:[]}");
         setEventMetadata("GRIDPAGINATIONBAR.CHANGEROWSPERPAGE","{handler:'E122B2',iparms:[{av:'GRID_nFirstRecordOnPage'},{av:'GRID_nEOF'},{av:'subGrid_Rows',ctrl:'GRID',prop:'Rows'},{av:'cmbavDynamicfiltersselector1'},{av:'AV15DynamicFiltersSelector1',fld:'vDYNAMICFILTERSSELECTOR1',pic:''},{av:'cmbavDynamicfiltersoperator1'},{av:'AV16DynamicFiltersOperator1',fld:'vDYNAMICFILTERSOPERATOR1',pic:'ZZZ9'},{av:'AV17TipADDsc1',fld:'vTIPADDSC1',pic:''},{av:'AV47TipADCod1',fld:'vTIPADCOD1',pic:''},{av:'cmbavDynamicfiltersselector2'},{av:'AV19DynamicFiltersSelector2',fld:'vDYNAMICFILTERSSELECTOR2',pic:''},{av:'cmbavDynamicfiltersoperator2'},{av:'AV20DynamicFiltersOperator2',fld:'vDYNAMICFILTERSOPERATOR2',pic:'ZZZ9'},{av:'AV21TipADDsc2',fld:'vTIPADDSC2',pic:''},{av:'AV48TipADCod2',fld:'vTIPADCOD2',pic:''},{av:'cmbavDynamicfiltersselector3'},{av:'AV23DynamicFiltersSelector3',fld:'vDYNAMICFILTERSSELECTOR3',pic:''},{av:'cmbavDynamicfiltersoperator3'},{av:'AV24DynamicFiltersOperator3',fld:'vDYNAMICFILTERSOPERATOR3',pic:'ZZZ9'},{av:'AV25TipADDsc3',fld:'vTIPADDSC3',pic:''},{av:'AV49TipADCod3',fld:'vTIPADCOD3',pic:''},{av:'AV18DynamicFiltersEnabled2',fld:'vDYNAMICFILTERSENABLED2',pic:''},{av:'AV22DynamicFiltersEnabled3',fld:'vDYNAMICFILTERSENABLED3',pic:''},{av:'AV54Pgmname',fld:'vPGMNAME',pic:'',hsh:true},{av:'AV50TFTipADsc',fld:'vTFTIPADSC',pic:''},{av:'AV51TFTipADsc_Sel',fld:'vTFTIPADSC_SEL',pic:''},{av:'AV33TFTipADCod',fld:'vTFTIPADCOD',pic:''},{av:'AV34TFTipADCod_Sel',fld:'vTFTIPADCOD_SEL',pic:''},{av:'AV35TFTipADDsc',fld:'vTFTIPADDSC',pic:''},{av:'AV36TFTipADDsc_Sel',fld:'vTFTIPADDSC_SEL',pic:''},{av:'AV38TFTipADSts_Sels',fld:'vTFTIPADSTS_SELS',pic:''},{av:'AV13OrderedBy',fld:'vORDEREDBY',pic:'ZZZ9'},{av:'AV14OrderedDsc',fld:'vORDEREDDSC',pic:''},{av:'AV10GridState',fld:'vGRIDSTATE',pic:''},{av:'AV27DynamicFiltersIgnoreFirst',fld:'vDYNAMICFILTERSIGNOREFIRST',pic:''},{av:'AV26DynamicFiltersRemoving',fld:'vDYNAMICFILTERSREMOVING',pic:''},{av:'Gridpaginationbar_Rowsperpageselectedvalue',ctrl:'GRIDPAGINATIONBAR',prop:'RowsPerPageSelectedValue'}]");
         setEventMetadata("GRIDPAGINATIONBAR.CHANGEROWSPERPAGE",",oparms:[{av:'subGrid_Rows',ctrl:'GRID',prop:'Rows'}]}");
         setEventMetadata("DDO_GRID.ONOPTIONCLICKED","{handler:'E142B2',iparms:[{av:'GRID_nFirstRecordOnPage'},{av:'GRID_nEOF'},{av:'subGrid_Rows',ctrl:'GRID',prop:'Rows'},{av:'cmbavDynamicfiltersselector1'},{av:'AV15DynamicFiltersSelector1',fld:'vDYNAMICFILTERSSELECTOR1',pic:''},{av:'cmbavDynamicfiltersoperator1'},{av:'AV16DynamicFiltersOperator1',fld:'vDYNAMICFILTERSOPERATOR1',pic:'ZZZ9'},{av:'AV17TipADDsc1',fld:'vTIPADDSC1',pic:''},{av:'AV47TipADCod1',fld:'vTIPADCOD1',pic:''},{av:'cmbavDynamicfiltersselector2'},{av:'AV19DynamicFiltersSelector2',fld:'vDYNAMICFILTERSSELECTOR2',pic:''},{av:'cmbavDynamicfiltersoperator2'},{av:'AV20DynamicFiltersOperator2',fld:'vDYNAMICFILTERSOPERATOR2',pic:'ZZZ9'},{av:'AV21TipADDsc2',fld:'vTIPADDSC2',pic:''},{av:'AV48TipADCod2',fld:'vTIPADCOD2',pic:''},{av:'cmbavDynamicfiltersselector3'},{av:'AV23DynamicFiltersSelector3',fld:'vDYNAMICFILTERSSELECTOR3',pic:''},{av:'cmbavDynamicfiltersoperator3'},{av:'AV24DynamicFiltersOperator3',fld:'vDYNAMICFILTERSOPERATOR3',pic:'ZZZ9'},{av:'AV25TipADDsc3',fld:'vTIPADDSC3',pic:''},{av:'AV49TipADCod3',fld:'vTIPADCOD3',pic:''},{av:'AV18DynamicFiltersEnabled2',fld:'vDYNAMICFILTERSENABLED2',pic:''},{av:'AV22DynamicFiltersEnabled3',fld:'vDYNAMICFILTERSENABLED3',pic:''},{av:'AV54Pgmname',fld:'vPGMNAME',pic:'',hsh:true},{av:'AV50TFTipADsc',fld:'vTFTIPADSC',pic:''},{av:'AV51TFTipADsc_Sel',fld:'vTFTIPADSC_SEL',pic:''},{av:'AV33TFTipADCod',fld:'vTFTIPADCOD',pic:''},{av:'AV34TFTipADCod_Sel',fld:'vTFTIPADCOD_SEL',pic:''},{av:'AV35TFTipADDsc',fld:'vTFTIPADDSC',pic:''},{av:'AV36TFTipADDsc_Sel',fld:'vTFTIPADDSC_SEL',pic:''},{av:'AV38TFTipADSts_Sels',fld:'vTFTIPADSTS_SELS',pic:''},{av:'AV13OrderedBy',fld:'vORDEREDBY',pic:'ZZZ9'},{av:'AV14OrderedDsc',fld:'vORDEREDDSC',pic:''},{av:'AV10GridState',fld:'vGRIDSTATE',pic:''},{av:'AV27DynamicFiltersIgnoreFirst',fld:'vDYNAMICFILTERSIGNOREFIRST',pic:''},{av:'AV26DynamicFiltersRemoving',fld:'vDYNAMICFILTERSREMOVING',pic:''},{av:'Ddo_grid_Activeeventkey',ctrl:'DDO_GRID',prop:'ActiveEventKey'},{av:'Ddo_grid_Selectedvalue_get',ctrl:'DDO_GRID',prop:'SelectedValue_get'},{av:'Ddo_grid_Selectedcolumn',ctrl:'DDO_GRID',prop:'SelectedColumn'},{av:'Ddo_grid_Filteredtext_get',ctrl:'DDO_GRID',prop:'FilteredText_get'}]");
         setEventMetadata("DDO_GRID.ONOPTIONCLICKED",",oparms:[{av:'AV13OrderedBy',fld:'vORDEREDBY',pic:'ZZZ9'},{av:'AV14OrderedDsc',fld:'vORDEREDDSC',pic:''},{av:'AV50TFTipADsc',fld:'vTFTIPADSC',pic:''},{av:'AV51TFTipADsc_Sel',fld:'vTFTIPADSC_SEL',pic:''},{av:'AV33TFTipADCod',fld:'vTFTIPADCOD',pic:''},{av:'AV34TFTipADCod_Sel',fld:'vTFTIPADCOD_SEL',pic:''},{av:'AV35TFTipADDsc',fld:'vTFTIPADDSC',pic:''},{av:'AV36TFTipADDsc_Sel',fld:'vTFTIPADDSC_SEL',pic:''},{av:'AV37TFTipADSts_SelsJson',fld:'vTFTIPADSTS_SELSJSON',pic:''},{av:'AV38TFTipADSts_Sels',fld:'vTFTIPADSTS_SELS',pic:''},{av:'Ddo_grid_Sortedstatus',ctrl:'DDO_GRID',prop:'SortedStatus'}]}");
         setEventMetadata("GRID.LOAD","{handler:'E262B2',iparms:[{av:'A70TipACod',fld:'TIPACOD',pic:'ZZZZZ9',hsh:true},{av:'A71TipADCod',fld:'TIPADCOD',pic:'',hsh:true}]");
         setEventMetadata("GRID.LOAD",",oparms:[{av:'cmbavGridactions'},{av:'AV44GridActions',fld:'vGRIDACTIONS',pic:'ZZZ9'},{av:'edtTipADsc_Link',ctrl:'TIPADSC',prop:'Link'},{av:'edtTipADDsc_Link',ctrl:'TIPADDSC',prop:'Link'}]}");
         setEventMetadata("'ADDDYNAMICFILTERS1'","{handler:'E192B2',iparms:[{av:'GRID_nFirstRecordOnPage'},{av:'GRID_nEOF'},{av:'subGrid_Rows',ctrl:'GRID',prop:'Rows'},{av:'cmbavDynamicfiltersselector1'},{av:'AV15DynamicFiltersSelector1',fld:'vDYNAMICFILTERSSELECTOR1',pic:''},{av:'cmbavDynamicfiltersoperator1'},{av:'AV16DynamicFiltersOperator1',fld:'vDYNAMICFILTERSOPERATOR1',pic:'ZZZ9'},{av:'AV17TipADDsc1',fld:'vTIPADDSC1',pic:''},{av:'AV47TipADCod1',fld:'vTIPADCOD1',pic:''},{av:'cmbavDynamicfiltersselector2'},{av:'AV19DynamicFiltersSelector2',fld:'vDYNAMICFILTERSSELECTOR2',pic:''},{av:'cmbavDynamicfiltersoperator2'},{av:'AV20DynamicFiltersOperator2',fld:'vDYNAMICFILTERSOPERATOR2',pic:'ZZZ9'},{av:'AV21TipADDsc2',fld:'vTIPADDSC2',pic:''},{av:'AV48TipADCod2',fld:'vTIPADCOD2',pic:''},{av:'cmbavDynamicfiltersselector3'},{av:'AV23DynamicFiltersSelector3',fld:'vDYNAMICFILTERSSELECTOR3',pic:''},{av:'cmbavDynamicfiltersoperator3'},{av:'AV24DynamicFiltersOperator3',fld:'vDYNAMICFILTERSOPERATOR3',pic:'ZZZ9'},{av:'AV25TipADDsc3',fld:'vTIPADDSC3',pic:''},{av:'AV49TipADCod3',fld:'vTIPADCOD3',pic:''},{av:'AV18DynamicFiltersEnabled2',fld:'vDYNAMICFILTERSENABLED2',pic:''},{av:'AV22DynamicFiltersEnabled3',fld:'vDYNAMICFILTERSENABLED3',pic:''},{av:'AV54Pgmname',fld:'vPGMNAME',pic:'',hsh:true},{av:'AV50TFTipADsc',fld:'vTFTIPADSC',pic:''},{av:'AV51TFTipADsc_Sel',fld:'vTFTIPADSC_SEL',pic:''},{av:'AV33TFTipADCod',fld:'vTFTIPADCOD',pic:''},{av:'AV34TFTipADCod_Sel',fld:'vTFTIPADCOD_SEL',pic:''},{av:'AV35TFTipADDsc',fld:'vTFTIPADDSC',pic:''},{av:'AV36TFTipADDsc_Sel',fld:'vTFTIPADDSC_SEL',pic:''},{av:'AV38TFTipADSts_Sels',fld:'vTFTIPADSTS_SELS',pic:''},{av:'AV13OrderedBy',fld:'vORDEREDBY',pic:'ZZZ9'},{av:'AV14OrderedDsc',fld:'vORDEREDDSC',pic:''},{av:'AV10GridState',fld:'vGRIDSTATE',pic:''},{av:'AV27DynamicFiltersIgnoreFirst',fld:'vDYNAMICFILTERSIGNOREFIRST',pic:''},{av:'AV26DynamicFiltersRemoving',fld:'vDYNAMICFILTERSREMOVING',pic:''}]");
         setEventMetadata("'ADDDYNAMICFILTERS1'",",oparms:[{av:'AV18DynamicFiltersEnabled2',fld:'vDYNAMICFILTERSENABLED2',pic:''},{av:'imgAdddynamicfilters1_Visible',ctrl:'ADDDYNAMICFILTERS1',prop:'Visible'},{av:'imgRemovedynamicfilters1_Visible',ctrl:'REMOVEDYNAMICFILTERS1',prop:'Visible'},{av:'cmbavDynamicfiltersoperator1'},{av:'AV16DynamicFiltersOperator1',fld:'vDYNAMICFILTERSOPERATOR1',pic:'ZZZ9'},{av:'cmbavDynamicfiltersoperator2'},{av:'AV20DynamicFiltersOperator2',fld:'vDYNAMICFILTERSOPERATOR2',pic:'ZZZ9'},{av:'cmbavDynamicfiltersoperator3'},{av:'AV24DynamicFiltersOperator3',fld:'vDYNAMICFILTERSOPERATOR3',pic:'ZZZ9'},{av:'AV41GridCurrentPage',fld:'vGRIDCURRENTPAGE',pic:'ZZZZZZZZZ9'},{av:'AV42GridPageCount',fld:'vGRIDPAGECOUNT',pic:'ZZZZZZZZZ9'},{av:'AV43GridAppliedFilters',fld:'vGRIDAPPLIEDFILTERS',pic:''},{av:'AV10GridState',fld:'vGRIDSTATE',pic:''}]}");
         setEventMetadata("'REMOVEDYNAMICFILTERS1'","{handler:'E152B2',iparms:[{av:'GRID_nFirstRecordOnPage'},{av:'GRID_nEOF'},{av:'subGrid_Rows',ctrl:'GRID',prop:'Rows'},{av:'cmbavDynamicfiltersselector1'},{av:'AV15DynamicFiltersSelector1',fld:'vDYNAMICFILTERSSELECTOR1',pic:''},{av:'cmbavDynamicfiltersoperator1'},{av:'AV16DynamicFiltersOperator1',fld:'vDYNAMICFILTERSOPERATOR1',pic:'ZZZ9'},{av:'AV17TipADDsc1',fld:'vTIPADDSC1',pic:''},{av:'AV47TipADCod1',fld:'vTIPADCOD1',pic:''},{av:'cmbavDynamicfiltersselector2'},{av:'AV19DynamicFiltersSelector2',fld:'vDYNAMICFILTERSSELECTOR2',pic:''},{av:'cmbavDynamicfiltersoperator2'},{av:'AV20DynamicFiltersOperator2',fld:'vDYNAMICFILTERSOPERATOR2',pic:'ZZZ9'},{av:'AV21TipADDsc2',fld:'vTIPADDSC2',pic:''},{av:'AV48TipADCod2',fld:'vTIPADCOD2',pic:''},{av:'cmbavDynamicfiltersselector3'},{av:'AV23DynamicFiltersSelector3',fld:'vDYNAMICFILTERSSELECTOR3',pic:''},{av:'cmbavDynamicfiltersoperator3'},{av:'AV24DynamicFiltersOperator3',fld:'vDYNAMICFILTERSOPERATOR3',pic:'ZZZ9'},{av:'AV25TipADDsc3',fld:'vTIPADDSC3',pic:''},{av:'AV49TipADCod3',fld:'vTIPADCOD3',pic:''},{av:'AV18DynamicFiltersEnabled2',fld:'vDYNAMICFILTERSENABLED2',pic:''},{av:'AV22DynamicFiltersEnabled3',fld:'vDYNAMICFILTERSENABLED3',pic:''},{av:'AV54Pgmname',fld:'vPGMNAME',pic:'',hsh:true},{av:'AV50TFTipADsc',fld:'vTFTIPADSC',pic:''},{av:'AV51TFTipADsc_Sel',fld:'vTFTIPADSC_SEL',pic:''},{av:'AV33TFTipADCod',fld:'vTFTIPADCOD',pic:''},{av:'AV34TFTipADCod_Sel',fld:'vTFTIPADCOD_SEL',pic:''},{av:'AV35TFTipADDsc',fld:'vTFTIPADDSC',pic:''},{av:'AV36TFTipADDsc_Sel',fld:'vTFTIPADDSC_SEL',pic:''},{av:'AV38TFTipADSts_Sels',fld:'vTFTIPADSTS_SELS',pic:''},{av:'AV13OrderedBy',fld:'vORDEREDBY',pic:'ZZZ9'},{av:'AV14OrderedDsc',fld:'vORDEREDDSC',pic:''},{av:'AV10GridState',fld:'vGRIDSTATE',pic:''},{av:'AV27DynamicFiltersIgnoreFirst',fld:'vDYNAMICFILTERSIGNOREFIRST',pic:''},{av:'AV26DynamicFiltersRemoving',fld:'vDYNAMICFILTERSREMOVING',pic:''}]");
         setEventMetadata("'REMOVEDYNAMICFILTERS1'",",oparms:[{av:'AV26DynamicFiltersRemoving',fld:'vDYNAMICFILTERSREMOVING',pic:''},{av:'AV27DynamicFiltersIgnoreFirst',fld:'vDYNAMICFILTERSIGNOREFIRST',pic:''},{av:'AV10GridState',fld:'vGRIDSTATE',pic:''},{av:'AV18DynamicFiltersEnabled2',fld:'vDYNAMICFILTERSENABLED2',pic:''},{av:'cmbavDynamicfiltersselector2'},{av:'AV19DynamicFiltersSelector2',fld:'vDYNAMICFILTERSSELECTOR2',pic:''},{av:'cmbavDynamicfiltersoperator2'},{av:'AV20DynamicFiltersOperator2',fld:'vDYNAMICFILTERSOPERATOR2',pic:'ZZZ9'},{av:'AV21TipADDsc2',fld:'vTIPADDSC2',pic:''},{av:'AV22DynamicFiltersEnabled3',fld:'vDYNAMICFILTERSENABLED3',pic:''},{av:'cmbavDynamicfiltersselector3'},{av:'AV23DynamicFiltersSelector3',fld:'vDYNAMICFILTERSSELECTOR3',pic:''},{av:'cmbavDynamicfiltersoperator3'},{av:'AV24DynamicFiltersOperator3',fld:'vDYNAMICFILTERSOPERATOR3',pic:'ZZZ9'},{av:'AV25TipADDsc3',fld:'vTIPADDSC3',pic:''},{av:'imgAdddynamicfilters1_Visible',ctrl:'ADDDYNAMICFILTERS1',prop:'Visible'},{av:'imgRemovedynamicfilters1_Visible',ctrl:'REMOVEDYNAMICFILTERS1',prop:'Visible'},{av:'imgAdddynamicfilters2_Visible',ctrl:'ADDDYNAMICFILTERS2',prop:'Visible'},{av:'imgRemovedynamicfilters2_Visible',ctrl:'REMOVEDYNAMICFILTERS2',prop:'Visible'},{av:'cmbavDynamicfiltersselector1'},{av:'AV15DynamicFiltersSelector1',fld:'vDYNAMICFILTERSSELECTOR1',pic:''},{av:'cmbavDynamicfiltersoperator1'},{av:'AV16DynamicFiltersOperator1',fld:'vDYNAMICFILTERSOPERATOR1',pic:'ZZZ9'},{av:'AV17TipADDsc1',fld:'vTIPADDSC1',pic:''},{av:'AV47TipADCod1',fld:'vTIPADCOD1',pic:''},{av:'lblJsdynamicfilters_Caption',ctrl:'JSDYNAMICFILTERS',prop:'Caption'},{av:'AV48TipADCod2',fld:'vTIPADCOD2',pic:''},{av:'AV49TipADCod3',fld:'vTIPADCOD3',pic:''},{av:'edtavTipaddsc2_Visible',ctrl:'vTIPADDSC2',prop:'Visible'},{av:'edtavTipadcod2_Visible',ctrl:'vTIPADCOD2',prop:'Visible'},{av:'edtavTipaddsc3_Visible',ctrl:'vTIPADDSC3',prop:'Visible'},{av:'edtavTipadcod3_Visible',ctrl:'vTIPADCOD3',prop:'Visible'},{av:'edtavTipaddsc1_Visible',ctrl:'vTIPADDSC1',prop:'Visible'},{av:'edtavTipadcod1_Visible',ctrl:'vTIPADCOD1',prop:'Visible'},{av:'AV41GridCurrentPage',fld:'vGRIDCURRENTPAGE',pic:'ZZZZZZZZZ9'},{av:'AV42GridPageCount',fld:'vGRIDPAGECOUNT',pic:'ZZZZZZZZZ9'},{av:'AV43GridAppliedFilters',fld:'vGRIDAPPLIEDFILTERS',pic:''}]}");
         setEventMetadata("VDYNAMICFILTERSSELECTOR1.CLICK","{handler:'E202B2',iparms:[{av:'cmbavDynamicfiltersselector1'},{av:'AV15DynamicFiltersSelector1',fld:'vDYNAMICFILTERSSELECTOR1',pic:''}]");
         setEventMetadata("VDYNAMICFILTERSSELECTOR1.CLICK",",oparms:[{av:'cmbavDynamicfiltersoperator1'},{av:'AV16DynamicFiltersOperator1',fld:'vDYNAMICFILTERSOPERATOR1',pic:'ZZZ9'},{av:'edtavTipaddsc1_Visible',ctrl:'vTIPADDSC1',prop:'Visible'},{av:'edtavTipadcod1_Visible',ctrl:'vTIPADCOD1',prop:'Visible'}]}");
         setEventMetadata("'ADDDYNAMICFILTERS2'","{handler:'E212B2',iparms:[{av:'GRID_nFirstRecordOnPage'},{av:'GRID_nEOF'},{av:'subGrid_Rows',ctrl:'GRID',prop:'Rows'},{av:'cmbavDynamicfiltersselector1'},{av:'AV15DynamicFiltersSelector1',fld:'vDYNAMICFILTERSSELECTOR1',pic:''},{av:'cmbavDynamicfiltersoperator1'},{av:'AV16DynamicFiltersOperator1',fld:'vDYNAMICFILTERSOPERATOR1',pic:'ZZZ9'},{av:'AV17TipADDsc1',fld:'vTIPADDSC1',pic:''},{av:'AV47TipADCod1',fld:'vTIPADCOD1',pic:''},{av:'cmbavDynamicfiltersselector2'},{av:'AV19DynamicFiltersSelector2',fld:'vDYNAMICFILTERSSELECTOR2',pic:''},{av:'cmbavDynamicfiltersoperator2'},{av:'AV20DynamicFiltersOperator2',fld:'vDYNAMICFILTERSOPERATOR2',pic:'ZZZ9'},{av:'AV21TipADDsc2',fld:'vTIPADDSC2',pic:''},{av:'AV48TipADCod2',fld:'vTIPADCOD2',pic:''},{av:'cmbavDynamicfiltersselector3'},{av:'AV23DynamicFiltersSelector3',fld:'vDYNAMICFILTERSSELECTOR3',pic:''},{av:'cmbavDynamicfiltersoperator3'},{av:'AV24DynamicFiltersOperator3',fld:'vDYNAMICFILTERSOPERATOR3',pic:'ZZZ9'},{av:'AV25TipADDsc3',fld:'vTIPADDSC3',pic:''},{av:'AV49TipADCod3',fld:'vTIPADCOD3',pic:''},{av:'AV18DynamicFiltersEnabled2',fld:'vDYNAMICFILTERSENABLED2',pic:''},{av:'AV22DynamicFiltersEnabled3',fld:'vDYNAMICFILTERSENABLED3',pic:''},{av:'AV54Pgmname',fld:'vPGMNAME',pic:'',hsh:true},{av:'AV50TFTipADsc',fld:'vTFTIPADSC',pic:''},{av:'AV51TFTipADsc_Sel',fld:'vTFTIPADSC_SEL',pic:''},{av:'AV33TFTipADCod',fld:'vTFTIPADCOD',pic:''},{av:'AV34TFTipADCod_Sel',fld:'vTFTIPADCOD_SEL',pic:''},{av:'AV35TFTipADDsc',fld:'vTFTIPADDSC',pic:''},{av:'AV36TFTipADDsc_Sel',fld:'vTFTIPADDSC_SEL',pic:''},{av:'AV38TFTipADSts_Sels',fld:'vTFTIPADSTS_SELS',pic:''},{av:'AV13OrderedBy',fld:'vORDEREDBY',pic:'ZZZ9'},{av:'AV14OrderedDsc',fld:'vORDEREDDSC',pic:''},{av:'AV10GridState',fld:'vGRIDSTATE',pic:''},{av:'AV27DynamicFiltersIgnoreFirst',fld:'vDYNAMICFILTERSIGNOREFIRST',pic:''},{av:'AV26DynamicFiltersRemoving',fld:'vDYNAMICFILTERSREMOVING',pic:''}]");
         setEventMetadata("'ADDDYNAMICFILTERS2'",",oparms:[{av:'AV22DynamicFiltersEnabled3',fld:'vDYNAMICFILTERSENABLED3',pic:''},{av:'imgAdddynamicfilters2_Visible',ctrl:'ADDDYNAMICFILTERS2',prop:'Visible'},{av:'imgRemovedynamicfilters2_Visible',ctrl:'REMOVEDYNAMICFILTERS2',prop:'Visible'},{av:'cmbavDynamicfiltersoperator1'},{av:'AV16DynamicFiltersOperator1',fld:'vDYNAMICFILTERSOPERATOR1',pic:'ZZZ9'},{av:'cmbavDynamicfiltersoperator2'},{av:'AV20DynamicFiltersOperator2',fld:'vDYNAMICFILTERSOPERATOR2',pic:'ZZZ9'},{av:'cmbavDynamicfiltersoperator3'},{av:'AV24DynamicFiltersOperator3',fld:'vDYNAMICFILTERSOPERATOR3',pic:'ZZZ9'},{av:'AV41GridCurrentPage',fld:'vGRIDCURRENTPAGE',pic:'ZZZZZZZZZ9'},{av:'AV42GridPageCount',fld:'vGRIDPAGECOUNT',pic:'ZZZZZZZZZ9'},{av:'AV43GridAppliedFilters',fld:'vGRIDAPPLIEDFILTERS',pic:''},{av:'AV10GridState',fld:'vGRIDSTATE',pic:''}]}");
         setEventMetadata("'REMOVEDYNAMICFILTERS2'","{handler:'E162B2',iparms:[{av:'GRID_nFirstRecordOnPage'},{av:'GRID_nEOF'},{av:'subGrid_Rows',ctrl:'GRID',prop:'Rows'},{av:'cmbavDynamicfiltersselector1'},{av:'AV15DynamicFiltersSelector1',fld:'vDYNAMICFILTERSSELECTOR1',pic:''},{av:'cmbavDynamicfiltersoperator1'},{av:'AV16DynamicFiltersOperator1',fld:'vDYNAMICFILTERSOPERATOR1',pic:'ZZZ9'},{av:'AV17TipADDsc1',fld:'vTIPADDSC1',pic:''},{av:'AV47TipADCod1',fld:'vTIPADCOD1',pic:''},{av:'cmbavDynamicfiltersselector2'},{av:'AV19DynamicFiltersSelector2',fld:'vDYNAMICFILTERSSELECTOR2',pic:''},{av:'cmbavDynamicfiltersoperator2'},{av:'AV20DynamicFiltersOperator2',fld:'vDYNAMICFILTERSOPERATOR2',pic:'ZZZ9'},{av:'AV21TipADDsc2',fld:'vTIPADDSC2',pic:''},{av:'AV48TipADCod2',fld:'vTIPADCOD2',pic:''},{av:'cmbavDynamicfiltersselector3'},{av:'AV23DynamicFiltersSelector3',fld:'vDYNAMICFILTERSSELECTOR3',pic:''},{av:'cmbavDynamicfiltersoperator3'},{av:'AV24DynamicFiltersOperator3',fld:'vDYNAMICFILTERSOPERATOR3',pic:'ZZZ9'},{av:'AV25TipADDsc3',fld:'vTIPADDSC3',pic:''},{av:'AV49TipADCod3',fld:'vTIPADCOD3',pic:''},{av:'AV18DynamicFiltersEnabled2',fld:'vDYNAMICFILTERSENABLED2',pic:''},{av:'AV22DynamicFiltersEnabled3',fld:'vDYNAMICFILTERSENABLED3',pic:''},{av:'AV54Pgmname',fld:'vPGMNAME',pic:'',hsh:true},{av:'AV50TFTipADsc',fld:'vTFTIPADSC',pic:''},{av:'AV51TFTipADsc_Sel',fld:'vTFTIPADSC_SEL',pic:''},{av:'AV33TFTipADCod',fld:'vTFTIPADCOD',pic:''},{av:'AV34TFTipADCod_Sel',fld:'vTFTIPADCOD_SEL',pic:''},{av:'AV35TFTipADDsc',fld:'vTFTIPADDSC',pic:''},{av:'AV36TFTipADDsc_Sel',fld:'vTFTIPADDSC_SEL',pic:''},{av:'AV38TFTipADSts_Sels',fld:'vTFTIPADSTS_SELS',pic:''},{av:'AV13OrderedBy',fld:'vORDEREDBY',pic:'ZZZ9'},{av:'AV14OrderedDsc',fld:'vORDEREDDSC',pic:''},{av:'AV10GridState',fld:'vGRIDSTATE',pic:''},{av:'AV27DynamicFiltersIgnoreFirst',fld:'vDYNAMICFILTERSIGNOREFIRST',pic:''},{av:'AV26DynamicFiltersRemoving',fld:'vDYNAMICFILTERSREMOVING',pic:''}]");
         setEventMetadata("'REMOVEDYNAMICFILTERS2'",",oparms:[{av:'AV26DynamicFiltersRemoving',fld:'vDYNAMICFILTERSREMOVING',pic:''},{av:'AV18DynamicFiltersEnabled2',fld:'vDYNAMICFILTERSENABLED2',pic:''},{av:'AV10GridState',fld:'vGRIDSTATE',pic:''},{av:'cmbavDynamicfiltersselector2'},{av:'AV19DynamicFiltersSelector2',fld:'vDYNAMICFILTERSSELECTOR2',pic:''},{av:'cmbavDynamicfiltersoperator2'},{av:'AV20DynamicFiltersOperator2',fld:'vDYNAMICFILTERSOPERATOR2',pic:'ZZZ9'},{av:'AV21TipADDsc2',fld:'vTIPADDSC2',pic:''},{av:'AV22DynamicFiltersEnabled3',fld:'vDYNAMICFILTERSENABLED3',pic:''},{av:'cmbavDynamicfiltersselector3'},{av:'AV23DynamicFiltersSelector3',fld:'vDYNAMICFILTERSSELECTOR3',pic:''},{av:'cmbavDynamicfiltersoperator3'},{av:'AV24DynamicFiltersOperator3',fld:'vDYNAMICFILTERSOPERATOR3',pic:'ZZZ9'},{av:'AV25TipADDsc3',fld:'vTIPADDSC3',pic:''},{av:'imgAdddynamicfilters1_Visible',ctrl:'ADDDYNAMICFILTERS1',prop:'Visible'},{av:'imgRemovedynamicfilters1_Visible',ctrl:'REMOVEDYNAMICFILTERS1',prop:'Visible'},{av:'imgAdddynamicfilters2_Visible',ctrl:'ADDDYNAMICFILTERS2',prop:'Visible'},{av:'imgRemovedynamicfilters2_Visible',ctrl:'REMOVEDYNAMICFILTERS2',prop:'Visible'},{av:'cmbavDynamicfiltersselector1'},{av:'AV15DynamicFiltersSelector1',fld:'vDYNAMICFILTERSSELECTOR1',pic:''},{av:'cmbavDynamicfiltersoperator1'},{av:'AV16DynamicFiltersOperator1',fld:'vDYNAMICFILTERSOPERATOR1',pic:'ZZZ9'},{av:'AV17TipADDsc1',fld:'vTIPADDSC1',pic:''},{av:'AV47TipADCod1',fld:'vTIPADCOD1',pic:''},{av:'lblJsdynamicfilters_Caption',ctrl:'JSDYNAMICFILTERS',prop:'Caption'},{av:'AV48TipADCod2',fld:'vTIPADCOD2',pic:''},{av:'AV49TipADCod3',fld:'vTIPADCOD3',pic:''},{av:'edtavTipaddsc2_Visible',ctrl:'vTIPADDSC2',prop:'Visible'},{av:'edtavTipadcod2_Visible',ctrl:'vTIPADCOD2',prop:'Visible'},{av:'edtavTipaddsc3_Visible',ctrl:'vTIPADDSC3',prop:'Visible'},{av:'edtavTipadcod3_Visible',ctrl:'vTIPADCOD3',prop:'Visible'},{av:'edtavTipaddsc1_Visible',ctrl:'vTIPADDSC1',prop:'Visible'},{av:'edtavTipadcod1_Visible',ctrl:'vTIPADCOD1',prop:'Visible'},{av:'AV41GridCurrentPage',fld:'vGRIDCURRENTPAGE',pic:'ZZZZZZZZZ9'},{av:'AV42GridPageCount',fld:'vGRIDPAGECOUNT',pic:'ZZZZZZZZZ9'},{av:'AV43GridAppliedFilters',fld:'vGRIDAPPLIEDFILTERS',pic:''}]}");
         setEventMetadata("VDYNAMICFILTERSSELECTOR2.CLICK","{handler:'E222B2',iparms:[{av:'cmbavDynamicfiltersselector2'},{av:'AV19DynamicFiltersSelector2',fld:'vDYNAMICFILTERSSELECTOR2',pic:''}]");
         setEventMetadata("VDYNAMICFILTERSSELECTOR2.CLICK",",oparms:[{av:'cmbavDynamicfiltersoperator2'},{av:'AV20DynamicFiltersOperator2',fld:'vDYNAMICFILTERSOPERATOR2',pic:'ZZZ9'},{av:'edtavTipaddsc2_Visible',ctrl:'vTIPADDSC2',prop:'Visible'},{av:'edtavTipadcod2_Visible',ctrl:'vTIPADCOD2',prop:'Visible'}]}");
         setEventMetadata("'REMOVEDYNAMICFILTERS3'","{handler:'E172B2',iparms:[{av:'GRID_nFirstRecordOnPage'},{av:'GRID_nEOF'},{av:'subGrid_Rows',ctrl:'GRID',prop:'Rows'},{av:'cmbavDynamicfiltersselector1'},{av:'AV15DynamicFiltersSelector1',fld:'vDYNAMICFILTERSSELECTOR1',pic:''},{av:'cmbavDynamicfiltersoperator1'},{av:'AV16DynamicFiltersOperator1',fld:'vDYNAMICFILTERSOPERATOR1',pic:'ZZZ9'},{av:'AV17TipADDsc1',fld:'vTIPADDSC1',pic:''},{av:'AV47TipADCod1',fld:'vTIPADCOD1',pic:''},{av:'cmbavDynamicfiltersselector2'},{av:'AV19DynamicFiltersSelector2',fld:'vDYNAMICFILTERSSELECTOR2',pic:''},{av:'cmbavDynamicfiltersoperator2'},{av:'AV20DynamicFiltersOperator2',fld:'vDYNAMICFILTERSOPERATOR2',pic:'ZZZ9'},{av:'AV21TipADDsc2',fld:'vTIPADDSC2',pic:''},{av:'AV48TipADCod2',fld:'vTIPADCOD2',pic:''},{av:'cmbavDynamicfiltersselector3'},{av:'AV23DynamicFiltersSelector3',fld:'vDYNAMICFILTERSSELECTOR3',pic:''},{av:'cmbavDynamicfiltersoperator3'},{av:'AV24DynamicFiltersOperator3',fld:'vDYNAMICFILTERSOPERATOR3',pic:'ZZZ9'},{av:'AV25TipADDsc3',fld:'vTIPADDSC3',pic:''},{av:'AV49TipADCod3',fld:'vTIPADCOD3',pic:''},{av:'AV18DynamicFiltersEnabled2',fld:'vDYNAMICFILTERSENABLED2',pic:''},{av:'AV22DynamicFiltersEnabled3',fld:'vDYNAMICFILTERSENABLED3',pic:''},{av:'AV54Pgmname',fld:'vPGMNAME',pic:'',hsh:true},{av:'AV50TFTipADsc',fld:'vTFTIPADSC',pic:''},{av:'AV51TFTipADsc_Sel',fld:'vTFTIPADSC_SEL',pic:''},{av:'AV33TFTipADCod',fld:'vTFTIPADCOD',pic:''},{av:'AV34TFTipADCod_Sel',fld:'vTFTIPADCOD_SEL',pic:''},{av:'AV35TFTipADDsc',fld:'vTFTIPADDSC',pic:''},{av:'AV36TFTipADDsc_Sel',fld:'vTFTIPADDSC_SEL',pic:''},{av:'AV38TFTipADSts_Sels',fld:'vTFTIPADSTS_SELS',pic:''},{av:'AV13OrderedBy',fld:'vORDEREDBY',pic:'ZZZ9'},{av:'AV14OrderedDsc',fld:'vORDEREDDSC',pic:''},{av:'AV10GridState',fld:'vGRIDSTATE',pic:''},{av:'AV27DynamicFiltersIgnoreFirst',fld:'vDYNAMICFILTERSIGNOREFIRST',pic:''},{av:'AV26DynamicFiltersRemoving',fld:'vDYNAMICFILTERSREMOVING',pic:''}]");
         setEventMetadata("'REMOVEDYNAMICFILTERS3'",",oparms:[{av:'AV26DynamicFiltersRemoving',fld:'vDYNAMICFILTERSREMOVING',pic:''},{av:'AV22DynamicFiltersEnabled3',fld:'vDYNAMICFILTERSENABLED3',pic:''},{av:'AV10GridState',fld:'vGRIDSTATE',pic:''},{av:'AV18DynamicFiltersEnabled2',fld:'vDYNAMICFILTERSENABLED2',pic:''},{av:'cmbavDynamicfiltersselector2'},{av:'AV19DynamicFiltersSelector2',fld:'vDYNAMICFILTERSSELECTOR2',pic:''},{av:'cmbavDynamicfiltersoperator2'},{av:'AV20DynamicFiltersOperator2',fld:'vDYNAMICFILTERSOPERATOR2',pic:'ZZZ9'},{av:'AV21TipADDsc2',fld:'vTIPADDSC2',pic:''},{av:'cmbavDynamicfiltersselector3'},{av:'AV23DynamicFiltersSelector3',fld:'vDYNAMICFILTERSSELECTOR3',pic:''},{av:'cmbavDynamicfiltersoperator3'},{av:'AV24DynamicFiltersOperator3',fld:'vDYNAMICFILTERSOPERATOR3',pic:'ZZZ9'},{av:'AV25TipADDsc3',fld:'vTIPADDSC3',pic:''},{av:'imgAdddynamicfilters1_Visible',ctrl:'ADDDYNAMICFILTERS1',prop:'Visible'},{av:'imgRemovedynamicfilters1_Visible',ctrl:'REMOVEDYNAMICFILTERS1',prop:'Visible'},{av:'imgAdddynamicfilters2_Visible',ctrl:'ADDDYNAMICFILTERS2',prop:'Visible'},{av:'imgRemovedynamicfilters2_Visible',ctrl:'REMOVEDYNAMICFILTERS2',prop:'Visible'},{av:'cmbavDynamicfiltersselector1'},{av:'AV15DynamicFiltersSelector1',fld:'vDYNAMICFILTERSSELECTOR1',pic:''},{av:'cmbavDynamicfiltersoperator1'},{av:'AV16DynamicFiltersOperator1',fld:'vDYNAMICFILTERSOPERATOR1',pic:'ZZZ9'},{av:'AV17TipADDsc1',fld:'vTIPADDSC1',pic:''},{av:'AV47TipADCod1',fld:'vTIPADCOD1',pic:''},{av:'lblJsdynamicfilters_Caption',ctrl:'JSDYNAMICFILTERS',prop:'Caption'},{av:'AV48TipADCod2',fld:'vTIPADCOD2',pic:''},{av:'AV49TipADCod3',fld:'vTIPADCOD3',pic:''},{av:'edtavTipaddsc2_Visible',ctrl:'vTIPADDSC2',prop:'Visible'},{av:'edtavTipadcod2_Visible',ctrl:'vTIPADCOD2',prop:'Visible'},{av:'edtavTipaddsc3_Visible',ctrl:'vTIPADDSC3',prop:'Visible'},{av:'edtavTipadcod3_Visible',ctrl:'vTIPADCOD3',prop:'Visible'},{av:'edtavTipaddsc1_Visible',ctrl:'vTIPADDSC1',prop:'Visible'},{av:'edtavTipadcod1_Visible',ctrl:'vTIPADCOD1',prop:'Visible'},{av:'AV41GridCurrentPage',fld:'vGRIDCURRENTPAGE',pic:'ZZZZZZZZZ9'},{av:'AV42GridPageCount',fld:'vGRIDPAGECOUNT',pic:'ZZZZZZZZZ9'},{av:'AV43GridAppliedFilters',fld:'vGRIDAPPLIEDFILTERS',pic:''}]}");
         setEventMetadata("VDYNAMICFILTERSSELECTOR3.CLICK","{handler:'E232B2',iparms:[{av:'cmbavDynamicfiltersselector3'},{av:'AV23DynamicFiltersSelector3',fld:'vDYNAMICFILTERSSELECTOR3',pic:''}]");
         setEventMetadata("VDYNAMICFILTERSSELECTOR3.CLICK",",oparms:[{av:'cmbavDynamicfiltersoperator3'},{av:'AV24DynamicFiltersOperator3',fld:'vDYNAMICFILTERSOPERATOR3',pic:'ZZZ9'},{av:'edtavTipaddsc3_Visible',ctrl:'vTIPADDSC3',prop:'Visible'},{av:'edtavTipadcod3_Visible',ctrl:'vTIPADCOD3',prop:'Visible'}]}");
         setEventMetadata("VGRIDACTIONS.CLICK","{handler:'E272B2',iparms:[{av:'cmbavGridactions'},{av:'AV44GridActions',fld:'vGRIDACTIONS',pic:'ZZZ9'},{av:'A70TipACod',fld:'TIPACOD',pic:'ZZZZZ9',hsh:true},{av:'A71TipADCod',fld:'TIPADCOD',pic:'',hsh:true}]");
         setEventMetadata("VGRIDACTIONS.CLICK",",oparms:[{av:'cmbavGridactions'},{av:'AV44GridActions',fld:'vGRIDACTIONS',pic:'ZZZ9'}]}");
         setEventMetadata("'DOINSERT'","{handler:'E182B2',iparms:[{av:'A70TipACod',fld:'TIPACOD',pic:'ZZZZZ9',hsh:true},{av:'A71TipADCod',fld:'TIPADCOD',pic:'',hsh:true}]");
         setEventMetadata("'DOINSERT'",",oparms:[]}");
         setEventMetadata("DDO_AGEXPORT.ONOPTIONCLICKED","{handler:'E132B2',iparms:[{av:'Ddo_agexport_Activeeventkey',ctrl:'DDO_AGEXPORT',prop:'ActiveEventKey'},{av:'AV54Pgmname',fld:'vPGMNAME',pic:'',hsh:true},{av:'AV38TFTipADSts_Sels',fld:'vTFTIPADSTS_SELS',pic:''},{av:'AV51TFTipADsc_Sel',fld:'vTFTIPADSC_SEL',pic:''},{av:'AV34TFTipADCod_Sel',fld:'vTFTIPADCOD_SEL',pic:''},{av:'AV36TFTipADDsc_Sel',fld:'vTFTIPADDSC_SEL',pic:''},{av:'AV37TFTipADSts_SelsJson',fld:'vTFTIPADSTS_SELSJSON',pic:''},{av:'AV50TFTipADsc',fld:'vTFTIPADSC',pic:''},{av:'AV33TFTipADCod',fld:'vTFTIPADCOD',pic:''},{av:'AV35TFTipADDsc',fld:'vTFTIPADDSC',pic:''},{av:'AV13OrderedBy',fld:'vORDEREDBY',pic:'ZZZ9'},{av:'AV14OrderedDsc',fld:'vORDEREDDSC',pic:''},{av:'AV10GridState',fld:'vGRIDSTATE',pic:''},{av:'AV26DynamicFiltersRemoving',fld:'vDYNAMICFILTERSREMOVING',pic:''},{av:'cmbavDynamicfiltersselector1'},{av:'AV15DynamicFiltersSelector1',fld:'vDYNAMICFILTERSSELECTOR1',pic:''},{av:'cmbavDynamicfiltersselector2'},{av:'AV19DynamicFiltersSelector2',fld:'vDYNAMICFILTERSSELECTOR2',pic:''},{av:'cmbavDynamicfiltersselector3'},{av:'AV23DynamicFiltersSelector3',fld:'vDYNAMICFILTERSSELECTOR3',pic:''}]");
         setEventMetadata("DDO_AGEXPORT.ONOPTIONCLICKED",",oparms:[{av:'Innewwindow1_Target',ctrl:'INNEWWINDOW1',prop:'Target'},{av:'Innewwindow1_Height',ctrl:'INNEWWINDOW1',prop:'Height'},{av:'Innewwindow1_Width',ctrl:'INNEWWINDOW1',prop:'Width'},{av:'AV10GridState',fld:'vGRIDSTATE',pic:''},{av:'AV13OrderedBy',fld:'vORDEREDBY',pic:'ZZZ9'},{av:'AV14OrderedDsc',fld:'vORDEREDDSC',pic:''},{av:'AV37TFTipADSts_SelsJson',fld:'vTFTIPADSTS_SELSJSON',pic:''},{av:'AV38TFTipADSts_Sels',fld:'vTFTIPADSTS_SELS',pic:''},{av:'AV36TFTipADDsc_Sel',fld:'vTFTIPADDSC_SEL',pic:''},{av:'AV35TFTipADDsc',fld:'vTFTIPADDSC',pic:''},{av:'AV34TFTipADCod_Sel',fld:'vTFTIPADCOD_SEL',pic:''},{av:'AV33TFTipADCod',fld:'vTFTIPADCOD',pic:''},{av:'AV51TFTipADsc_Sel',fld:'vTFTIPADSC_SEL',pic:''},{av:'AV50TFTipADsc',fld:'vTFTIPADSC',pic:''},{av:'Ddo_grid_Selectedvalue_set',ctrl:'DDO_GRID',prop:'SelectedValue_set'},{av:'Ddo_grid_Filteredtext_set',ctrl:'DDO_GRID',prop:'FilteredText_set'},{av:'subGrid_Rows',ctrl:'GRID',prop:'Rows'},{av:'GRID_nFirstRecordOnPage'},{av:'GRID_nEOF'},{av:'cmbavDynamicfiltersselector1'},{av:'AV15DynamicFiltersSelector1',fld:'vDYNAMICFILTERSSELECTOR1',pic:''},{av:'cmbavDynamicfiltersoperator1'},{av:'AV16DynamicFiltersOperator1',fld:'vDYNAMICFILTERSOPERATOR1',pic:'ZZZ9'},{av:'AV17TipADDsc1',fld:'vTIPADDSC1',pic:''},{av:'AV47TipADCod1',fld:'vTIPADCOD1',pic:''},{av:'cmbavDynamicfiltersselector2'},{av:'AV19DynamicFiltersSelector2',fld:'vDYNAMICFILTERSSELECTOR2',pic:''},{av:'cmbavDynamicfiltersoperator2'},{av:'AV20DynamicFiltersOperator2',fld:'vDYNAMICFILTERSOPERATOR2',pic:'ZZZ9'},{av:'AV21TipADDsc2',fld:'vTIPADDSC2',pic:''},{av:'AV48TipADCod2',fld:'vTIPADCOD2',pic:''},{av:'cmbavDynamicfiltersselector3'},{av:'AV23DynamicFiltersSelector3',fld:'vDYNAMICFILTERSSELECTOR3',pic:''},{av:'cmbavDynamicfiltersoperator3'},{av:'AV24DynamicFiltersOperator3',fld:'vDYNAMICFILTERSOPERATOR3',pic:'ZZZ9'},{av:'AV25TipADDsc3',fld:'vTIPADDSC3',pic:''},{av:'AV49TipADCod3',fld:'vTIPADCOD3',pic:''},{av:'AV18DynamicFiltersEnabled2',fld:'vDYNAMICFILTERSENABLED2',pic:''},{av:'AV22DynamicFiltersEnabled3',fld:'vDYNAMICFILTERSENABLED3',pic:''},{av:'AV54Pgmname',fld:'vPGMNAME',pic:'',hsh:true},{av:'AV27DynamicFiltersIgnoreFirst',fld:'vDYNAMICFILTERSIGNOREFIRST',pic:''},{av:'AV26DynamicFiltersRemoving',fld:'vDYNAMICFILTERSREMOVING',pic:''},{av:'Ddo_grid_Sortedstatus',ctrl:'DDO_GRID',prop:'SortedStatus'},{av:'imgAdddynamicfilters1_Visible',ctrl:'ADDDYNAMICFILTERS1',prop:'Visible'},{av:'imgRemovedynamicfilters1_Visible',ctrl:'REMOVEDYNAMICFILTERS1',prop:'Visible'},{av:'imgAdddynamicfilters2_Visible',ctrl:'ADDDYNAMICFILTERS2',prop:'Visible'},{av:'imgRemovedynamicfilters2_Visible',ctrl:'REMOVEDYNAMICFILTERS2',prop:'Visible'},{av:'lblJsdynamicfilters_Caption',ctrl:'JSDYNAMICFILTERS',prop:'Caption'},{av:'edtavTipaddsc1_Visible',ctrl:'vTIPADDSC1',prop:'Visible'},{av:'edtavTipadcod1_Visible',ctrl:'vTIPADCOD1',prop:'Visible'},{av:'edtavTipaddsc2_Visible',ctrl:'vTIPADDSC2',prop:'Visible'},{av:'edtavTipadcod2_Visible',ctrl:'vTIPADCOD2',prop:'Visible'},{av:'edtavTipaddsc3_Visible',ctrl:'vTIPADDSC3',prop:'Visible'},{av:'edtavTipadcod3_Visible',ctrl:'vTIPADCOD3',prop:'Visible'}]}");
         setEventMetadata("VALID_TIPACOD","{handler:'Valid_Tipacod',iparms:[]");
         setEventMetadata("VALID_TIPACOD",",oparms:[]}");
         setEventMetadata("NULL","{handler:'Valid_Tipadsts',iparms:[]");
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
         Ddo_agexport_Activeeventkey = "";
         gxfirstwebparm = "";
         gxfirstwebparm_bkp = "";
         AV15DynamicFiltersSelector1 = "";
         AV17TipADDsc1 = "";
         AV47TipADCod1 = "";
         AV19DynamicFiltersSelector2 = "";
         AV21TipADDsc2 = "";
         AV48TipADCod2 = "";
         AV23DynamicFiltersSelector3 = "";
         AV25TipADDsc3 = "";
         AV49TipADCod3 = "";
         AV54Pgmname = "";
         AV50TFTipADsc = "";
         AV51TFTipADsc_Sel = "";
         AV33TFTipADCod = "";
         AV34TFTipADCod_Sel = "";
         AV35TFTipADDsc = "";
         AV36TFTipADDsc_Sel = "";
         AV38TFTipADSts_Sels = new GxSimpleCollection<short>();
         AV10GridState = new GeneXus.Programs.wwpbaseobjects.SdtWWPGridState(context);
         sDynURL = "";
         FormProcess = "";
         bodyStyle = "";
         GXKey = "";
         AV43GridAppliedFilters = "";
         AV45AGExportData = new GXBaseCollection<GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTDropDownOptionsData_Item>( context, "Item", "");
         AV39DDO_TitleSettingsIcons = new GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTDropDownOptionsTitleSettingsIcons(context);
         AV37TFTipADSts_SelsJson = "";
         Ddo_agexport_Caption = "";
         Ddo_grid_Caption = "";
         Ddo_grid_Filteredtext_set = "";
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
         A1900TipADsc = "";
         A71TipADCod = "";
         A72TipADDsc = "";
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
         AV75Contabilidad_auxiliareswwds_21_tftipadsts_sels = new GxSimpleCollection<short>();
         scmdbuf = "";
         lV57Contabilidad_auxiliareswwds_3_tipaddsc1 = "";
         lV58Contabilidad_auxiliareswwds_4_tipadcod1 = "";
         lV62Contabilidad_auxiliareswwds_8_tipaddsc2 = "";
         lV63Contabilidad_auxiliareswwds_9_tipadcod2 = "";
         lV67Contabilidad_auxiliareswwds_13_tipaddsc3 = "";
         lV68Contabilidad_auxiliareswwds_14_tipadcod3 = "";
         lV69Contabilidad_auxiliareswwds_15_tftipadsc = "";
         lV71Contabilidad_auxiliareswwds_17_tftipadcod = "";
         lV73Contabilidad_auxiliareswwds_19_tftipaddsc = "";
         AV55Contabilidad_auxiliareswwds_1_dynamicfiltersselector1 = "";
         AV57Contabilidad_auxiliareswwds_3_tipaddsc1 = "";
         AV58Contabilidad_auxiliareswwds_4_tipadcod1 = "";
         AV60Contabilidad_auxiliareswwds_6_dynamicfiltersselector2 = "";
         AV62Contabilidad_auxiliareswwds_8_tipaddsc2 = "";
         AV63Contabilidad_auxiliareswwds_9_tipadcod2 = "";
         AV65Contabilidad_auxiliareswwds_11_dynamicfiltersselector3 = "";
         AV67Contabilidad_auxiliareswwds_13_tipaddsc3 = "";
         AV68Contabilidad_auxiliareswwds_14_tipadcod3 = "";
         AV70Contabilidad_auxiliareswwds_16_tftipadsc_sel = "";
         AV69Contabilidad_auxiliareswwds_15_tftipadsc = "";
         AV72Contabilidad_auxiliareswwds_18_tftipadcod_sel = "";
         AV71Contabilidad_auxiliareswwds_17_tftipadcod = "";
         AV74Contabilidad_auxiliareswwds_20_tftipaddsc_sel = "";
         AV73Contabilidad_auxiliareswwds_19_tftipaddsc = "";
         H002B2_A1901TipADSts = new short[1] ;
         H002B2_A72TipADDsc = new string[] {""} ;
         H002B2_A71TipADCod = new string[] {""} ;
         H002B2_A70TipACod = new int[1] ;
         H002B2_A1900TipADsc = new string[] {""} ;
         H002B3_AGRID_nRecordCount = new long[1] ;
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
         GXt_char4 = "";
         GXt_char3 = "";
         GXt_char2 = "";
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
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.contabilidad.auxiliaresww__default(),
            new Object[][] {
                new Object[] {
               H002B2_A1901TipADSts, H002B2_A72TipADDsc, H002B2_A71TipADCod, H002B2_A70TipACod, H002B2_A1900TipADsc
               }
               , new Object[] {
               H002B3_AGRID_nRecordCount
               }
            }
         );
         AV54Pgmname = "Contabilidad.AuxiliaresWW";
         /* GeneXus formulas. */
         AV54Pgmname = "Contabilidad.AuxiliaresWW";
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
      private short A1901TipADSts ;
      private short subGrid_Allowselection ;
      private short subGrid_Allowhovering ;
      private short subGrid_Allowcollapsing ;
      private short subGrid_Collapsed ;
      private short nDonePA ;
      private short AV56Contabilidad_auxiliareswwds_2_dynamicfiltersoperator1 ;
      private short AV61Contabilidad_auxiliareswwds_7_dynamicfiltersoperator2 ;
      private short AV66Contabilidad_auxiliareswwds_12_dynamicfiltersoperator3 ;
      private short nGXWrapped ;
      private short subGrid_Backstyle ;
      private int subGrid_Rows ;
      private int Gridpaginationbar_Rowsperpageselectedvalue ;
      private int nRC_GXsfl_110 ;
      private int nGXsfl_110_idx=1 ;
      private int Gridpaginationbar_Pagestoshow ;
      private int subGrid_Titlebackcolor ;
      private int subGrid_Allbackcolor ;
      private int A70TipACod ;
      private int subGrid_Selectedindex ;
      private int subGrid_Selectioncolor ;
      private int subGrid_Hoveringcolor ;
      private int subGrid_Islastpage ;
      private int GXPagingFrom2 ;
      private int GXPagingTo2 ;
      private int AV75Contabilidad_auxiliareswwds_21_tftipadsts_sels_Count ;
      private int AV40PageToGo ;
      private int imgAdddynamicfilters1_Visible ;
      private int imgRemovedynamicfilters1_Visible ;
      private int imgAdddynamicfilters2_Visible ;
      private int imgRemovedynamicfilters2_Visible ;
      private int edtavTipaddsc1_Visible ;
      private int edtavTipadcod1_Visible ;
      private int edtavTipaddsc2_Visible ;
      private int edtavTipadcod2_Visible ;
      private int edtavTipaddsc3_Visible ;
      private int edtavTipadcod3_Visible ;
      private int AV76GXV1 ;
      private int edtavTipaddsc3_Enabled ;
      private int edtavTipadcod3_Enabled ;
      private int edtavTipaddsc2_Enabled ;
      private int edtavTipadcod2_Enabled ;
      private int edtavTipaddsc1_Enabled ;
      private int edtavTipadcod1_Enabled ;
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
      private string Ddo_agexport_Activeeventkey ;
      private string gxfirstwebparm ;
      private string gxfirstwebparm_bkp ;
      private string sGXsfl_110_idx="0001" ;
      private string AV17TipADDsc1 ;
      private string AV47TipADCod1 ;
      private string AV21TipADDsc2 ;
      private string AV48TipADCod2 ;
      private string AV25TipADDsc3 ;
      private string AV49TipADCod3 ;
      private string AV54Pgmname ;
      private string AV50TFTipADsc ;
      private string AV51TFTipADsc_Sel ;
      private string AV33TFTipADCod ;
      private string AV34TFTipADCod_Sel ;
      private string AV35TFTipADDsc ;
      private string AV36TFTipADDsc_Sel ;
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
      private string Ddo_grid_Selectedvalue_set ;
      private string Ddo_grid_Gridinternalname ;
      private string Ddo_grid_Columnids ;
      private string Ddo_grid_Columnssortvalues ;
      private string Ddo_grid_Includesortasc ;
      private string Ddo_grid_Sortedstatus ;
      private string Ddo_grid_Includefilter ;
      private string Ddo_grid_Filtertype ;
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
      private string A1900TipADsc ;
      private string edtTipADsc_Link ;
      private string A71TipADCod ;
      private string A72TipADDsc ;
      private string edtTipADDsc_Link ;
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
      private string edtTipADsc_Internalname ;
      private string edtTipACod_Internalname ;
      private string edtTipADCod_Internalname ;
      private string edtTipADDsc_Internalname ;
      private string edtTipADSts_Internalname ;
      private string cmbavDynamicfiltersselector1_Internalname ;
      private string cmbavDynamicfiltersoperator1_Internalname ;
      private string cmbavDynamicfiltersselector2_Internalname ;
      private string cmbavDynamicfiltersoperator2_Internalname ;
      private string cmbavDynamicfiltersselector3_Internalname ;
      private string cmbavDynamicfiltersoperator3_Internalname ;
      private string scmdbuf ;
      private string lV57Contabilidad_auxiliareswwds_3_tipaddsc1 ;
      private string lV58Contabilidad_auxiliareswwds_4_tipadcod1 ;
      private string lV62Contabilidad_auxiliareswwds_8_tipaddsc2 ;
      private string lV63Contabilidad_auxiliareswwds_9_tipadcod2 ;
      private string lV67Contabilidad_auxiliareswwds_13_tipaddsc3 ;
      private string lV68Contabilidad_auxiliareswwds_14_tipadcod3 ;
      private string lV69Contabilidad_auxiliareswwds_15_tftipadsc ;
      private string lV71Contabilidad_auxiliareswwds_17_tftipadcod ;
      private string lV73Contabilidad_auxiliareswwds_19_tftipaddsc ;
      private string AV57Contabilidad_auxiliareswwds_3_tipaddsc1 ;
      private string AV58Contabilidad_auxiliareswwds_4_tipadcod1 ;
      private string AV62Contabilidad_auxiliareswwds_8_tipaddsc2 ;
      private string AV63Contabilidad_auxiliareswwds_9_tipadcod2 ;
      private string AV67Contabilidad_auxiliareswwds_13_tipaddsc3 ;
      private string AV68Contabilidad_auxiliareswwds_14_tipadcod3 ;
      private string AV70Contabilidad_auxiliareswwds_16_tftipadsc_sel ;
      private string AV69Contabilidad_auxiliareswwds_15_tftipadsc ;
      private string AV72Contabilidad_auxiliareswwds_18_tftipadcod_sel ;
      private string AV71Contabilidad_auxiliareswwds_17_tftipadcod ;
      private string AV74Contabilidad_auxiliareswwds_20_tftipaddsc_sel ;
      private string AV73Contabilidad_auxiliareswwds_19_tftipaddsc ;
      private string edtavTipaddsc1_Internalname ;
      private string edtavTipadcod1_Internalname ;
      private string edtavTipaddsc2_Internalname ;
      private string edtavTipadcod2_Internalname ;
      private string edtavTipaddsc3_Internalname ;
      private string edtavTipadcod3_Internalname ;
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
      private string GXt_char4 ;
      private string GXt_char3 ;
      private string GXt_char2 ;
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
      private string cellFilter_tipaddsc3_cell_Internalname ;
      private string edtavTipaddsc3_Jsonclick ;
      private string cellFilter_tipadcod3_cell_Internalname ;
      private string edtavTipadcod3_Jsonclick ;
      private string cellDynamicfilters_removefilter3_cell_Internalname ;
      private string sImgUrl ;
      private string tblTablemergeddynamicfilters2_Internalname ;
      private string cmbavDynamicfiltersoperator2_Jsonclick ;
      private string cellFilter_tipaddsc2_cell_Internalname ;
      private string edtavTipaddsc2_Jsonclick ;
      private string cellFilter_tipadcod2_cell_Internalname ;
      private string edtavTipadcod2_Jsonclick ;
      private string cellDynamicfilters_addfilter2_cell_Internalname ;
      private string cellDynamicfilters_removefilter2_cell_Internalname ;
      private string tblTablemergeddynamicfilters1_Internalname ;
      private string cmbavDynamicfiltersoperator1_Jsonclick ;
      private string cellFilter_tipaddsc1_cell_Internalname ;
      private string edtavTipaddsc1_Jsonclick ;
      private string cellFilter_tipadcod1_cell_Internalname ;
      private string edtavTipadcod1_Jsonclick ;
      private string cellDynamicfilters_addfilter1_cell_Internalname ;
      private string cellDynamicfilters_removefilter1_cell_Internalname ;
      private string sGXsfl_110_fel_idx="0001" ;
      private string GXCCtl ;
      private string cmbavGridactions_Jsonclick ;
      private string ROClassString ;
      private string edtTipADsc_Jsonclick ;
      private string edtTipACod_Jsonclick ;
      private string edtTipADCod_Jsonclick ;
      private string edtTipADDsc_Jsonclick ;
      private string edtTipADSts_Jsonclick ;
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
      private bool bGXsfl_110_Refreshing=false ;
      private bool gxdyncontrolsrefreshing ;
      private bool AV59Contabilidad_auxiliareswwds_5_dynamicfiltersenabled2 ;
      private bool AV64Contabilidad_auxiliareswwds_10_dynamicfiltersenabled3 ;
      private bool returnInSub ;
      private bool gx_refresh_fired ;
      private string AV37TFTipADSts_SelsJson ;
      private string AV15DynamicFiltersSelector1 ;
      private string AV19DynamicFiltersSelector2 ;
      private string AV23DynamicFiltersSelector3 ;
      private string AV43GridAppliedFilters ;
      private string AV55Contabilidad_auxiliareswwds_1_dynamicfiltersselector1 ;
      private string AV60Contabilidad_auxiliareswwds_6_dynamicfiltersselector2 ;
      private string AV65Contabilidad_auxiliareswwds_11_dynamicfiltersselector3 ;
      private string AV28ExcelFilename ;
      private string AV29ErrorMessage ;
      private GxSimpleCollection<short> AV38TFTipADSts_Sels ;
      private GxSimpleCollection<short> AV75Contabilidad_auxiliareswwds_21_tftipadsts_sels ;
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
      private IDataStoreProvider pr_default ;
      private short[] H002B2_A1901TipADSts ;
      private string[] H002B2_A72TipADDsc ;
      private string[] H002B2_A71TipADCod ;
      private int[] H002B2_A70TipACod ;
      private string[] H002B2_A1900TipADsc ;
      private long[] H002B3_AGRID_nRecordCount ;
      private msglist BackMsgLst ;
      private msglist LclMsgLst ;
      private GxHttpRequest AV7HTTPRequest ;
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

   public class auxiliaresww__default : DataStoreHelperBase, IDataStoreHelper
   {
      protected Object[] conditional_H002B2( IGxContext context ,
                                             short A1901TipADSts ,
                                             GxSimpleCollection<short> AV75Contabilidad_auxiliareswwds_21_tftipadsts_sels ,
                                             string AV55Contabilidad_auxiliareswwds_1_dynamicfiltersselector1 ,
                                             short AV56Contabilidad_auxiliareswwds_2_dynamicfiltersoperator1 ,
                                             string AV57Contabilidad_auxiliareswwds_3_tipaddsc1 ,
                                             string AV58Contabilidad_auxiliareswwds_4_tipadcod1 ,
                                             bool AV59Contabilidad_auxiliareswwds_5_dynamicfiltersenabled2 ,
                                             string AV60Contabilidad_auxiliareswwds_6_dynamicfiltersselector2 ,
                                             short AV61Contabilidad_auxiliareswwds_7_dynamicfiltersoperator2 ,
                                             string AV62Contabilidad_auxiliareswwds_8_tipaddsc2 ,
                                             string AV63Contabilidad_auxiliareswwds_9_tipadcod2 ,
                                             bool AV64Contabilidad_auxiliareswwds_10_dynamicfiltersenabled3 ,
                                             string AV65Contabilidad_auxiliareswwds_11_dynamicfiltersselector3 ,
                                             short AV66Contabilidad_auxiliareswwds_12_dynamicfiltersoperator3 ,
                                             string AV67Contabilidad_auxiliareswwds_13_tipaddsc3 ,
                                             string AV68Contabilidad_auxiliareswwds_14_tipadcod3 ,
                                             string AV70Contabilidad_auxiliareswwds_16_tftipadsc_sel ,
                                             string AV69Contabilidad_auxiliareswwds_15_tftipadsc ,
                                             string AV72Contabilidad_auxiliareswwds_18_tftipadcod_sel ,
                                             string AV71Contabilidad_auxiliareswwds_17_tftipadcod ,
                                             string AV74Contabilidad_auxiliareswwds_20_tftipaddsc_sel ,
                                             string AV73Contabilidad_auxiliareswwds_19_tftipaddsc ,
                                             int AV75Contabilidad_auxiliareswwds_21_tftipadsts_sels_Count ,
                                             string A72TipADDsc ,
                                             string A71TipADCod ,
                                             string A1900TipADsc ,
                                             short AV13OrderedBy ,
                                             bool AV14OrderedDsc )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int5 = new short[21];
         Object[] GXv_Object6 = new Object[2];
         string sSelectString;
         string sFromString;
         string sOrderString;
         sSelectString = " T1.[TipADSts], T1.[TipADDsc], T1.[TipADCod], T1.[TipACod], T2.[TipADsc]";
         sFromString = " FROM ([CBAUXILIARES] T1 INNER JOIN [CBTIPAUXILIAR] T2 ON T2.[TipACod] = T1.[TipACod])";
         sOrderString = "";
         if ( ( StringUtil.StrCmp(AV55Contabilidad_auxiliareswwds_1_dynamicfiltersselector1, "TIPADDSC") == 0 ) && ( AV56Contabilidad_auxiliareswwds_2_dynamicfiltersoperator1 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV57Contabilidad_auxiliareswwds_3_tipaddsc1)) ) )
         {
            AddWhere(sWhereString, "(T1.[TipADDsc] like @lV57Contabilidad_auxiliareswwds_3_tipaddsc1)");
         }
         else
         {
            GXv_int5[0] = 1;
         }
         if ( ( StringUtil.StrCmp(AV55Contabilidad_auxiliareswwds_1_dynamicfiltersselector1, "TIPADDSC") == 0 ) && ( AV56Contabilidad_auxiliareswwds_2_dynamicfiltersoperator1 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV57Contabilidad_auxiliareswwds_3_tipaddsc1)) ) )
         {
            AddWhere(sWhereString, "(T1.[TipADDsc] like '%' + @lV57Contabilidad_auxiliareswwds_3_tipaddsc1)");
         }
         else
         {
            GXv_int5[1] = 1;
         }
         if ( ( StringUtil.StrCmp(AV55Contabilidad_auxiliareswwds_1_dynamicfiltersselector1, "TIPADCOD") == 0 ) && ( AV56Contabilidad_auxiliareswwds_2_dynamicfiltersoperator1 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV58Contabilidad_auxiliareswwds_4_tipadcod1)) ) )
         {
            AddWhere(sWhereString, "(T1.[TipADCod] like @lV58Contabilidad_auxiliareswwds_4_tipadcod1)");
         }
         else
         {
            GXv_int5[2] = 1;
         }
         if ( ( StringUtil.StrCmp(AV55Contabilidad_auxiliareswwds_1_dynamicfiltersselector1, "TIPADCOD") == 0 ) && ( AV56Contabilidad_auxiliareswwds_2_dynamicfiltersoperator1 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV58Contabilidad_auxiliareswwds_4_tipadcod1)) ) )
         {
            AddWhere(sWhereString, "(T1.[TipADCod] like '%' + @lV58Contabilidad_auxiliareswwds_4_tipadcod1)");
         }
         else
         {
            GXv_int5[3] = 1;
         }
         if ( AV59Contabilidad_auxiliareswwds_5_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV60Contabilidad_auxiliareswwds_6_dynamicfiltersselector2, "TIPADDSC") == 0 ) && ( AV61Contabilidad_auxiliareswwds_7_dynamicfiltersoperator2 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV62Contabilidad_auxiliareswwds_8_tipaddsc2)) ) )
         {
            AddWhere(sWhereString, "(T1.[TipADDsc] like @lV62Contabilidad_auxiliareswwds_8_tipaddsc2)");
         }
         else
         {
            GXv_int5[4] = 1;
         }
         if ( AV59Contabilidad_auxiliareswwds_5_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV60Contabilidad_auxiliareswwds_6_dynamicfiltersselector2, "TIPADDSC") == 0 ) && ( AV61Contabilidad_auxiliareswwds_7_dynamicfiltersoperator2 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV62Contabilidad_auxiliareswwds_8_tipaddsc2)) ) )
         {
            AddWhere(sWhereString, "(T1.[TipADDsc] like '%' + @lV62Contabilidad_auxiliareswwds_8_tipaddsc2)");
         }
         else
         {
            GXv_int5[5] = 1;
         }
         if ( AV59Contabilidad_auxiliareswwds_5_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV60Contabilidad_auxiliareswwds_6_dynamicfiltersselector2, "TIPADCOD") == 0 ) && ( AV61Contabilidad_auxiliareswwds_7_dynamicfiltersoperator2 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV63Contabilidad_auxiliareswwds_9_tipadcod2)) ) )
         {
            AddWhere(sWhereString, "(T1.[TipADCod] like @lV63Contabilidad_auxiliareswwds_9_tipadcod2)");
         }
         else
         {
            GXv_int5[6] = 1;
         }
         if ( AV59Contabilidad_auxiliareswwds_5_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV60Contabilidad_auxiliareswwds_6_dynamicfiltersselector2, "TIPADCOD") == 0 ) && ( AV61Contabilidad_auxiliareswwds_7_dynamicfiltersoperator2 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV63Contabilidad_auxiliareswwds_9_tipadcod2)) ) )
         {
            AddWhere(sWhereString, "(T1.[TipADCod] like '%' + @lV63Contabilidad_auxiliareswwds_9_tipadcod2)");
         }
         else
         {
            GXv_int5[7] = 1;
         }
         if ( AV64Contabilidad_auxiliareswwds_10_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV65Contabilidad_auxiliareswwds_11_dynamicfiltersselector3, "TIPADDSC") == 0 ) && ( AV66Contabilidad_auxiliareswwds_12_dynamicfiltersoperator3 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV67Contabilidad_auxiliareswwds_13_tipaddsc3)) ) )
         {
            AddWhere(sWhereString, "(T1.[TipADDsc] like @lV67Contabilidad_auxiliareswwds_13_tipaddsc3)");
         }
         else
         {
            GXv_int5[8] = 1;
         }
         if ( AV64Contabilidad_auxiliareswwds_10_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV65Contabilidad_auxiliareswwds_11_dynamicfiltersselector3, "TIPADDSC") == 0 ) && ( AV66Contabilidad_auxiliareswwds_12_dynamicfiltersoperator3 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV67Contabilidad_auxiliareswwds_13_tipaddsc3)) ) )
         {
            AddWhere(sWhereString, "(T1.[TipADDsc] like '%' + @lV67Contabilidad_auxiliareswwds_13_tipaddsc3)");
         }
         else
         {
            GXv_int5[9] = 1;
         }
         if ( AV64Contabilidad_auxiliareswwds_10_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV65Contabilidad_auxiliareswwds_11_dynamicfiltersselector3, "TIPADCOD") == 0 ) && ( AV66Contabilidad_auxiliareswwds_12_dynamicfiltersoperator3 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV68Contabilidad_auxiliareswwds_14_tipadcod3)) ) )
         {
            AddWhere(sWhereString, "(T1.[TipADCod] like @lV68Contabilidad_auxiliareswwds_14_tipadcod3)");
         }
         else
         {
            GXv_int5[10] = 1;
         }
         if ( AV64Contabilidad_auxiliareswwds_10_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV65Contabilidad_auxiliareswwds_11_dynamicfiltersselector3, "TIPADCOD") == 0 ) && ( AV66Contabilidad_auxiliareswwds_12_dynamicfiltersoperator3 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV68Contabilidad_auxiliareswwds_14_tipadcod3)) ) )
         {
            AddWhere(sWhereString, "(T1.[TipADCod] like '%' + @lV68Contabilidad_auxiliareswwds_14_tipadcod3)");
         }
         else
         {
            GXv_int5[11] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV70Contabilidad_auxiliareswwds_16_tftipadsc_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV69Contabilidad_auxiliareswwds_15_tftipadsc)) ) )
         {
            AddWhere(sWhereString, "(T2.[TipADsc] like @lV69Contabilidad_auxiliareswwds_15_tftipadsc)");
         }
         else
         {
            GXv_int5[12] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV70Contabilidad_auxiliareswwds_16_tftipadsc_sel)) )
         {
            AddWhere(sWhereString, "(T2.[TipADsc] = @AV70Contabilidad_auxiliareswwds_16_tftipadsc_sel)");
         }
         else
         {
            GXv_int5[13] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV72Contabilidad_auxiliareswwds_18_tftipadcod_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV71Contabilidad_auxiliareswwds_17_tftipadcod)) ) )
         {
            AddWhere(sWhereString, "(T1.[TipADCod] like @lV71Contabilidad_auxiliareswwds_17_tftipadcod)");
         }
         else
         {
            GXv_int5[14] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV72Contabilidad_auxiliareswwds_18_tftipadcod_sel)) )
         {
            AddWhere(sWhereString, "(T1.[TipADCod] = @AV72Contabilidad_auxiliareswwds_18_tftipadcod_sel)");
         }
         else
         {
            GXv_int5[15] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV74Contabilidad_auxiliareswwds_20_tftipaddsc_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV73Contabilidad_auxiliareswwds_19_tftipaddsc)) ) )
         {
            AddWhere(sWhereString, "(T1.[TipADDsc] like @lV73Contabilidad_auxiliareswwds_19_tftipaddsc)");
         }
         else
         {
            GXv_int5[16] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV74Contabilidad_auxiliareswwds_20_tftipaddsc_sel)) )
         {
            AddWhere(sWhereString, "(T1.[TipADDsc] = @AV74Contabilidad_auxiliareswwds_20_tftipaddsc_sel)");
         }
         else
         {
            GXv_int5[17] = 1;
         }
         if ( AV75Contabilidad_auxiliareswwds_21_tftipadsts_sels_Count > 0 )
         {
            AddWhere(sWhereString, "("+new GxDbmsUtils( new GxSqlServer()).ValueList(AV75Contabilidad_auxiliareswwds_21_tftipadsts_sels, "T1.[TipADSts] IN (", ")")+")");
         }
         if ( AV13OrderedBy == 1 )
         {
            sOrderString += " ORDER BY T1.[TipACod], T1.[TipADCod]";
         }
         else if ( ( AV13OrderedBy == 2 ) && ! AV14OrderedDsc )
         {
            sOrderString += " ORDER BY T2.[TipADsc]";
         }
         else if ( ( AV13OrderedBy == 2 ) && ( AV14OrderedDsc ) )
         {
            sOrderString += " ORDER BY T2.[TipADsc] DESC";
         }
         else if ( ( AV13OrderedBy == 3 ) && ! AV14OrderedDsc )
         {
            sOrderString += " ORDER BY T1.[TipADCod]";
         }
         else if ( ( AV13OrderedBy == 3 ) && ( AV14OrderedDsc ) )
         {
            sOrderString += " ORDER BY T1.[TipADCod] DESC";
         }
         else if ( ( AV13OrderedBy == 4 ) && ! AV14OrderedDsc )
         {
            sOrderString += " ORDER BY T1.[TipADDsc]";
         }
         else if ( ( AV13OrderedBy == 4 ) && ( AV14OrderedDsc ) )
         {
            sOrderString += " ORDER BY T1.[TipADDsc] DESC";
         }
         else if ( ( AV13OrderedBy == 5 ) && ! AV14OrderedDsc )
         {
            sOrderString += " ORDER BY T1.[TipADSts]";
         }
         else if ( ( AV13OrderedBy == 5 ) && ( AV14OrderedDsc ) )
         {
            sOrderString += " ORDER BY T1.[TipADSts] DESC";
         }
         else if ( true )
         {
            sOrderString += " ORDER BY T1.[TipACod], T1.[TipADCod]";
         }
         scmdbuf = "SELECT " + sSelectString + sFromString + sWhereString + sOrderString + "" + " OFFSET " + "@GXPagingFrom2" + " ROWS FETCH NEXT CAST((SELECT CASE WHEN " + "@GXPagingTo2" + " > 0 THEN " + "@GXPagingTo2" + " ELSE 1e9 END) AS INTEGER) ROWS ONLY";
         GXv_Object6[0] = scmdbuf;
         GXv_Object6[1] = GXv_int5;
         return GXv_Object6 ;
      }

      protected Object[] conditional_H002B3( IGxContext context ,
                                             short A1901TipADSts ,
                                             GxSimpleCollection<short> AV75Contabilidad_auxiliareswwds_21_tftipadsts_sels ,
                                             string AV55Contabilidad_auxiliareswwds_1_dynamicfiltersselector1 ,
                                             short AV56Contabilidad_auxiliareswwds_2_dynamicfiltersoperator1 ,
                                             string AV57Contabilidad_auxiliareswwds_3_tipaddsc1 ,
                                             string AV58Contabilidad_auxiliareswwds_4_tipadcod1 ,
                                             bool AV59Contabilidad_auxiliareswwds_5_dynamicfiltersenabled2 ,
                                             string AV60Contabilidad_auxiliareswwds_6_dynamicfiltersselector2 ,
                                             short AV61Contabilidad_auxiliareswwds_7_dynamicfiltersoperator2 ,
                                             string AV62Contabilidad_auxiliareswwds_8_tipaddsc2 ,
                                             string AV63Contabilidad_auxiliareswwds_9_tipadcod2 ,
                                             bool AV64Contabilidad_auxiliareswwds_10_dynamicfiltersenabled3 ,
                                             string AV65Contabilidad_auxiliareswwds_11_dynamicfiltersselector3 ,
                                             short AV66Contabilidad_auxiliareswwds_12_dynamicfiltersoperator3 ,
                                             string AV67Contabilidad_auxiliareswwds_13_tipaddsc3 ,
                                             string AV68Contabilidad_auxiliareswwds_14_tipadcod3 ,
                                             string AV70Contabilidad_auxiliareswwds_16_tftipadsc_sel ,
                                             string AV69Contabilidad_auxiliareswwds_15_tftipadsc ,
                                             string AV72Contabilidad_auxiliareswwds_18_tftipadcod_sel ,
                                             string AV71Contabilidad_auxiliareswwds_17_tftipadcod ,
                                             string AV74Contabilidad_auxiliareswwds_20_tftipaddsc_sel ,
                                             string AV73Contabilidad_auxiliareswwds_19_tftipaddsc ,
                                             int AV75Contabilidad_auxiliareswwds_21_tftipadsts_sels_Count ,
                                             string A72TipADDsc ,
                                             string A71TipADCod ,
                                             string A1900TipADsc ,
                                             short AV13OrderedBy ,
                                             bool AV14OrderedDsc )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int7 = new short[18];
         Object[] GXv_Object8 = new Object[2];
         scmdbuf = "SELECT COUNT(*) FROM ([CBAUXILIARES] T1 INNER JOIN [CBTIPAUXILIAR] T2 ON T2.[TipACod] = T1.[TipACod])";
         if ( ( StringUtil.StrCmp(AV55Contabilidad_auxiliareswwds_1_dynamicfiltersselector1, "TIPADDSC") == 0 ) && ( AV56Contabilidad_auxiliareswwds_2_dynamicfiltersoperator1 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV57Contabilidad_auxiliareswwds_3_tipaddsc1)) ) )
         {
            AddWhere(sWhereString, "(T1.[TipADDsc] like @lV57Contabilidad_auxiliareswwds_3_tipaddsc1)");
         }
         else
         {
            GXv_int7[0] = 1;
         }
         if ( ( StringUtil.StrCmp(AV55Contabilidad_auxiliareswwds_1_dynamicfiltersselector1, "TIPADDSC") == 0 ) && ( AV56Contabilidad_auxiliareswwds_2_dynamicfiltersoperator1 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV57Contabilidad_auxiliareswwds_3_tipaddsc1)) ) )
         {
            AddWhere(sWhereString, "(T1.[TipADDsc] like '%' + @lV57Contabilidad_auxiliareswwds_3_tipaddsc1)");
         }
         else
         {
            GXv_int7[1] = 1;
         }
         if ( ( StringUtil.StrCmp(AV55Contabilidad_auxiliareswwds_1_dynamicfiltersselector1, "TIPADCOD") == 0 ) && ( AV56Contabilidad_auxiliareswwds_2_dynamicfiltersoperator1 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV58Contabilidad_auxiliareswwds_4_tipadcod1)) ) )
         {
            AddWhere(sWhereString, "(T1.[TipADCod] like @lV58Contabilidad_auxiliareswwds_4_tipadcod1)");
         }
         else
         {
            GXv_int7[2] = 1;
         }
         if ( ( StringUtil.StrCmp(AV55Contabilidad_auxiliareswwds_1_dynamicfiltersselector1, "TIPADCOD") == 0 ) && ( AV56Contabilidad_auxiliareswwds_2_dynamicfiltersoperator1 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV58Contabilidad_auxiliareswwds_4_tipadcod1)) ) )
         {
            AddWhere(sWhereString, "(T1.[TipADCod] like '%' + @lV58Contabilidad_auxiliareswwds_4_tipadcod1)");
         }
         else
         {
            GXv_int7[3] = 1;
         }
         if ( AV59Contabilidad_auxiliareswwds_5_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV60Contabilidad_auxiliareswwds_6_dynamicfiltersselector2, "TIPADDSC") == 0 ) && ( AV61Contabilidad_auxiliareswwds_7_dynamicfiltersoperator2 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV62Contabilidad_auxiliareswwds_8_tipaddsc2)) ) )
         {
            AddWhere(sWhereString, "(T1.[TipADDsc] like @lV62Contabilidad_auxiliareswwds_8_tipaddsc2)");
         }
         else
         {
            GXv_int7[4] = 1;
         }
         if ( AV59Contabilidad_auxiliareswwds_5_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV60Contabilidad_auxiliareswwds_6_dynamicfiltersselector2, "TIPADDSC") == 0 ) && ( AV61Contabilidad_auxiliareswwds_7_dynamicfiltersoperator2 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV62Contabilidad_auxiliareswwds_8_tipaddsc2)) ) )
         {
            AddWhere(sWhereString, "(T1.[TipADDsc] like '%' + @lV62Contabilidad_auxiliareswwds_8_tipaddsc2)");
         }
         else
         {
            GXv_int7[5] = 1;
         }
         if ( AV59Contabilidad_auxiliareswwds_5_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV60Contabilidad_auxiliareswwds_6_dynamicfiltersselector2, "TIPADCOD") == 0 ) && ( AV61Contabilidad_auxiliareswwds_7_dynamicfiltersoperator2 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV63Contabilidad_auxiliareswwds_9_tipadcod2)) ) )
         {
            AddWhere(sWhereString, "(T1.[TipADCod] like @lV63Contabilidad_auxiliareswwds_9_tipadcod2)");
         }
         else
         {
            GXv_int7[6] = 1;
         }
         if ( AV59Contabilidad_auxiliareswwds_5_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV60Contabilidad_auxiliareswwds_6_dynamicfiltersselector2, "TIPADCOD") == 0 ) && ( AV61Contabilidad_auxiliareswwds_7_dynamicfiltersoperator2 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV63Contabilidad_auxiliareswwds_9_tipadcod2)) ) )
         {
            AddWhere(sWhereString, "(T1.[TipADCod] like '%' + @lV63Contabilidad_auxiliareswwds_9_tipadcod2)");
         }
         else
         {
            GXv_int7[7] = 1;
         }
         if ( AV64Contabilidad_auxiliareswwds_10_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV65Contabilidad_auxiliareswwds_11_dynamicfiltersselector3, "TIPADDSC") == 0 ) && ( AV66Contabilidad_auxiliareswwds_12_dynamicfiltersoperator3 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV67Contabilidad_auxiliareswwds_13_tipaddsc3)) ) )
         {
            AddWhere(sWhereString, "(T1.[TipADDsc] like @lV67Contabilidad_auxiliareswwds_13_tipaddsc3)");
         }
         else
         {
            GXv_int7[8] = 1;
         }
         if ( AV64Contabilidad_auxiliareswwds_10_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV65Contabilidad_auxiliareswwds_11_dynamicfiltersselector3, "TIPADDSC") == 0 ) && ( AV66Contabilidad_auxiliareswwds_12_dynamicfiltersoperator3 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV67Contabilidad_auxiliareswwds_13_tipaddsc3)) ) )
         {
            AddWhere(sWhereString, "(T1.[TipADDsc] like '%' + @lV67Contabilidad_auxiliareswwds_13_tipaddsc3)");
         }
         else
         {
            GXv_int7[9] = 1;
         }
         if ( AV64Contabilidad_auxiliareswwds_10_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV65Contabilidad_auxiliareswwds_11_dynamicfiltersselector3, "TIPADCOD") == 0 ) && ( AV66Contabilidad_auxiliareswwds_12_dynamicfiltersoperator3 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV68Contabilidad_auxiliareswwds_14_tipadcod3)) ) )
         {
            AddWhere(sWhereString, "(T1.[TipADCod] like @lV68Contabilidad_auxiliareswwds_14_tipadcod3)");
         }
         else
         {
            GXv_int7[10] = 1;
         }
         if ( AV64Contabilidad_auxiliareswwds_10_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV65Contabilidad_auxiliareswwds_11_dynamicfiltersselector3, "TIPADCOD") == 0 ) && ( AV66Contabilidad_auxiliareswwds_12_dynamicfiltersoperator3 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV68Contabilidad_auxiliareswwds_14_tipadcod3)) ) )
         {
            AddWhere(sWhereString, "(T1.[TipADCod] like '%' + @lV68Contabilidad_auxiliareswwds_14_tipadcod3)");
         }
         else
         {
            GXv_int7[11] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV70Contabilidad_auxiliareswwds_16_tftipadsc_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV69Contabilidad_auxiliareswwds_15_tftipadsc)) ) )
         {
            AddWhere(sWhereString, "(T2.[TipADsc] like @lV69Contabilidad_auxiliareswwds_15_tftipadsc)");
         }
         else
         {
            GXv_int7[12] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV70Contabilidad_auxiliareswwds_16_tftipadsc_sel)) )
         {
            AddWhere(sWhereString, "(T2.[TipADsc] = @AV70Contabilidad_auxiliareswwds_16_tftipadsc_sel)");
         }
         else
         {
            GXv_int7[13] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV72Contabilidad_auxiliareswwds_18_tftipadcod_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV71Contabilidad_auxiliareswwds_17_tftipadcod)) ) )
         {
            AddWhere(sWhereString, "(T1.[TipADCod] like @lV71Contabilidad_auxiliareswwds_17_tftipadcod)");
         }
         else
         {
            GXv_int7[14] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV72Contabilidad_auxiliareswwds_18_tftipadcod_sel)) )
         {
            AddWhere(sWhereString, "(T1.[TipADCod] = @AV72Contabilidad_auxiliareswwds_18_tftipadcod_sel)");
         }
         else
         {
            GXv_int7[15] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV74Contabilidad_auxiliareswwds_20_tftipaddsc_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV73Contabilidad_auxiliareswwds_19_tftipaddsc)) ) )
         {
            AddWhere(sWhereString, "(T1.[TipADDsc] like @lV73Contabilidad_auxiliareswwds_19_tftipaddsc)");
         }
         else
         {
            GXv_int7[16] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV74Contabilidad_auxiliareswwds_20_tftipaddsc_sel)) )
         {
            AddWhere(sWhereString, "(T1.[TipADDsc] = @AV74Contabilidad_auxiliareswwds_20_tftipaddsc_sel)");
         }
         else
         {
            GXv_int7[17] = 1;
         }
         if ( AV75Contabilidad_auxiliareswwds_21_tftipadsts_sels_Count > 0 )
         {
            AddWhere(sWhereString, "("+new GxDbmsUtils( new GxSqlServer()).ValueList(AV75Contabilidad_auxiliareswwds_21_tftipadsts_sels, "T1.[TipADSts] IN (", ")")+")");
         }
         scmdbuf += sWhereString;
         if ( AV13OrderedBy == 1 )
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
         else if ( ( AV13OrderedBy == 5 ) && ! AV14OrderedDsc )
         {
            scmdbuf += "";
         }
         else if ( ( AV13OrderedBy == 5 ) && ( AV14OrderedDsc ) )
         {
            scmdbuf += "";
         }
         else if ( true )
         {
            scmdbuf += "";
         }
         GXv_Object8[0] = scmdbuf;
         GXv_Object8[1] = GXv_int7;
         return GXv_Object8 ;
      }

      public override Object [] getDynamicStatement( int cursor ,
                                                     IGxContext context ,
                                                     Object [] dynConstraints )
      {
         switch ( cursor )
         {
               case 0 :
                     return conditional_H002B2(context, (short)dynConstraints[0] , (GxSimpleCollection<short>)dynConstraints[1] , (string)dynConstraints[2] , (short)dynConstraints[3] , (string)dynConstraints[4] , (string)dynConstraints[5] , (bool)dynConstraints[6] , (string)dynConstraints[7] , (short)dynConstraints[8] , (string)dynConstraints[9] , (string)dynConstraints[10] , (bool)dynConstraints[11] , (string)dynConstraints[12] , (short)dynConstraints[13] , (string)dynConstraints[14] , (string)dynConstraints[15] , (string)dynConstraints[16] , (string)dynConstraints[17] , (string)dynConstraints[18] , (string)dynConstraints[19] , (string)dynConstraints[20] , (string)dynConstraints[21] , (int)dynConstraints[22] , (string)dynConstraints[23] , (string)dynConstraints[24] , (string)dynConstraints[25] , (short)dynConstraints[26] , (bool)dynConstraints[27] );
               case 1 :
                     return conditional_H002B3(context, (short)dynConstraints[0] , (GxSimpleCollection<short>)dynConstraints[1] , (string)dynConstraints[2] , (short)dynConstraints[3] , (string)dynConstraints[4] , (string)dynConstraints[5] , (bool)dynConstraints[6] , (string)dynConstraints[7] , (short)dynConstraints[8] , (string)dynConstraints[9] , (string)dynConstraints[10] , (bool)dynConstraints[11] , (string)dynConstraints[12] , (short)dynConstraints[13] , (string)dynConstraints[14] , (string)dynConstraints[15] , (string)dynConstraints[16] , (string)dynConstraints[17] , (string)dynConstraints[18] , (string)dynConstraints[19] , (string)dynConstraints[20] , (string)dynConstraints[21] , (int)dynConstraints[22] , (string)dynConstraints[23] , (string)dynConstraints[24] , (string)dynConstraints[25] , (short)dynConstraints[26] , (bool)dynConstraints[27] );
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
          Object[] prmH002B2;
          prmH002B2 = new Object[] {
          new ParDef("@lV57Contabilidad_auxiliareswwds_3_tipaddsc1",GXType.NChar,100,0) ,
          new ParDef("@lV57Contabilidad_auxiliareswwds_3_tipaddsc1",GXType.NChar,100,0) ,
          new ParDef("@lV58Contabilidad_auxiliareswwds_4_tipadcod1",GXType.NChar,20,0) ,
          new ParDef("@lV58Contabilidad_auxiliareswwds_4_tipadcod1",GXType.NChar,20,0) ,
          new ParDef("@lV62Contabilidad_auxiliareswwds_8_tipaddsc2",GXType.NChar,100,0) ,
          new ParDef("@lV62Contabilidad_auxiliareswwds_8_tipaddsc2",GXType.NChar,100,0) ,
          new ParDef("@lV63Contabilidad_auxiliareswwds_9_tipadcod2",GXType.NChar,20,0) ,
          new ParDef("@lV63Contabilidad_auxiliareswwds_9_tipadcod2",GXType.NChar,20,0) ,
          new ParDef("@lV67Contabilidad_auxiliareswwds_13_tipaddsc3",GXType.NChar,100,0) ,
          new ParDef("@lV67Contabilidad_auxiliareswwds_13_tipaddsc3",GXType.NChar,100,0) ,
          new ParDef("@lV68Contabilidad_auxiliareswwds_14_tipadcod3",GXType.NChar,20,0) ,
          new ParDef("@lV68Contabilidad_auxiliareswwds_14_tipadcod3",GXType.NChar,20,0) ,
          new ParDef("@lV69Contabilidad_auxiliareswwds_15_tftipadsc",GXType.NChar,100,0) ,
          new ParDef("@AV70Contabilidad_auxiliareswwds_16_tftipadsc_sel",GXType.NChar,100,0) ,
          new ParDef("@lV71Contabilidad_auxiliareswwds_17_tftipadcod",GXType.NChar,20,0) ,
          new ParDef("@AV72Contabilidad_auxiliareswwds_18_tftipadcod_sel",GXType.NChar,20,0) ,
          new ParDef("@lV73Contabilidad_auxiliareswwds_19_tftipaddsc",GXType.NChar,100,0) ,
          new ParDef("@AV74Contabilidad_auxiliareswwds_20_tftipaddsc_sel",GXType.NChar,100,0) ,
          new ParDef("@GXPagingFrom2",GXType.Int32,9,0) ,
          new ParDef("@GXPagingTo2",GXType.Int32,9,0) ,
          new ParDef("@GXPagingTo2",GXType.Int32,9,0)
          };
          Object[] prmH002B3;
          prmH002B3 = new Object[] {
          new ParDef("@lV57Contabilidad_auxiliareswwds_3_tipaddsc1",GXType.NChar,100,0) ,
          new ParDef("@lV57Contabilidad_auxiliareswwds_3_tipaddsc1",GXType.NChar,100,0) ,
          new ParDef("@lV58Contabilidad_auxiliareswwds_4_tipadcod1",GXType.NChar,20,0) ,
          new ParDef("@lV58Contabilidad_auxiliareswwds_4_tipadcod1",GXType.NChar,20,0) ,
          new ParDef("@lV62Contabilidad_auxiliareswwds_8_tipaddsc2",GXType.NChar,100,0) ,
          new ParDef("@lV62Contabilidad_auxiliareswwds_8_tipaddsc2",GXType.NChar,100,0) ,
          new ParDef("@lV63Contabilidad_auxiliareswwds_9_tipadcod2",GXType.NChar,20,0) ,
          new ParDef("@lV63Contabilidad_auxiliareswwds_9_tipadcod2",GXType.NChar,20,0) ,
          new ParDef("@lV67Contabilidad_auxiliareswwds_13_tipaddsc3",GXType.NChar,100,0) ,
          new ParDef("@lV67Contabilidad_auxiliareswwds_13_tipaddsc3",GXType.NChar,100,0) ,
          new ParDef("@lV68Contabilidad_auxiliareswwds_14_tipadcod3",GXType.NChar,20,0) ,
          new ParDef("@lV68Contabilidad_auxiliareswwds_14_tipadcod3",GXType.NChar,20,0) ,
          new ParDef("@lV69Contabilidad_auxiliareswwds_15_tftipadsc",GXType.NChar,100,0) ,
          new ParDef("@AV70Contabilidad_auxiliareswwds_16_tftipadsc_sel",GXType.NChar,100,0) ,
          new ParDef("@lV71Contabilidad_auxiliareswwds_17_tftipadcod",GXType.NChar,20,0) ,
          new ParDef("@AV72Contabilidad_auxiliareswwds_18_tftipadcod_sel",GXType.NChar,20,0) ,
          new ParDef("@lV73Contabilidad_auxiliareswwds_19_tftipaddsc",GXType.NChar,100,0) ,
          new ParDef("@AV74Contabilidad_auxiliareswwds_20_tftipaddsc_sel",GXType.NChar,100,0)
          };
          def= new CursorDef[] {
              new CursorDef("H002B2", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH002B2,11, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("H002B3", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH002B3,1, GxCacheFrequency.OFF ,true,false )
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
                ((string[]) buf[1])[0] = rslt.getString(2, 100);
                ((string[]) buf[2])[0] = rslt.getString(3, 20);
                ((int[]) buf[3])[0] = rslt.getInt(4);
                ((string[]) buf[4])[0] = rslt.getString(5, 100);
                return;
             case 1 :
                ((long[]) buf[0])[0] = rslt.getLong(1);
                return;
       }
    }

 }

}
