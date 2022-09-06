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
   public class lineasww : GXDataArea
   {
      public lineasww( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDataStore2 = context.GetDataStore("DataStore2");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusTheme");
      }

      public lineasww( IGxContext context )
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
         cmbavDynamicfiltersselector2 = new GXCombobox();
         cmbavDynamicfiltersselector3 = new GXCombobox();
         cmbavGridactions = new GXCombobox();
         cmbRubLinSts = new GXCombobox();
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
               nRC_GXsfl_92 = (int)(NumberUtil.Val( GetPar( "nRC_GXsfl_92"), "."));
               nGXsfl_92_idx = (int)(NumberUtil.Val( GetPar( "nGXsfl_92_idx"), "."));
               sGXsfl_92_idx = GetPar( "sGXsfl_92_idx");
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
               AV55TotTipo1 = GetPar( "TotTipo1");
               cmbavDynamicfiltersselector2.FromJSonString( GetNextPar( ));
               AV19DynamicFiltersSelector2 = GetPar( "DynamicFiltersSelector2");
               AV56TotTipo2 = GetPar( "TotTipo2");
               cmbavDynamicfiltersselector3.FromJSonString( GetNextPar( ));
               AV23DynamicFiltersSelector3 = GetPar( "DynamicFiltersSelector3");
               AV57TotTipo3 = GetPar( "TotTipo3");
               AV60Pgmname = GetPar( "Pgmname");
               AV18DynamicFiltersEnabled2 = StringUtil.StrToBool( GetPar( "DynamicFiltersEnabled2"));
               AV22DynamicFiltersEnabled3 = StringUtil.StrToBool( GetPar( "DynamicFiltersEnabled3"));
               ajax_req_read_hidden_sdt(GetNextPar( ), AV32TFTotTipo_Sels);
               AV33TFTotRub = (int)(NumberUtil.Val( GetPar( "TFTotRub"), "."));
               AV34TFTotRub_To = (int)(NumberUtil.Val( GetPar( "TFTotRub_To"), "."));
               AV35TFRubCod = (int)(NumberUtil.Val( GetPar( "TFRubCod"), "."));
               AV36TFRubCod_To = (int)(NumberUtil.Val( GetPar( "TFRubCod_To"), "."));
               AV37TFRubLinCod = (int)(NumberUtil.Val( GetPar( "TFRubLinCod"), "."));
               AV38TFRubLinCod_To = (int)(NumberUtil.Val( GetPar( "TFRubLinCod_To"), "."));
               AV39TFRubLinDsc = GetPar( "TFRubLinDsc");
               AV40TFRubLinDsc_Sel = GetPar( "TFRubLinDsc_Sel");
               AV41TFRubLinDscTot = GetPar( "TFRubLinDscTot");
               AV42TFRubLinDscTot_Sel = GetPar( "TFRubLinDscTot_Sel");
               AV43TFRubLinOrd = (short)(NumberUtil.Val( GetPar( "TFRubLinOrd"), "."));
               AV44TFRubLinOrd_To = (short)(NumberUtil.Val( GetPar( "TFRubLinOrd_To"), "."));
               ajax_req_read_hidden_sdt(GetNextPar( ), AV46TFRubLinSts_Sels);
               AV13OrderedBy = (short)(NumberUtil.Val( GetPar( "OrderedBy"), "."));
               AV14OrderedDsc = StringUtil.StrToBool( GetPar( "OrderedDsc"));
               ajax_req_read_hidden_sdt(GetNextPar( ), AV10GridState);
               AV27DynamicFiltersIgnoreFirst = StringUtil.StrToBool( GetPar( "DynamicFiltersIgnoreFirst"));
               setAjaxCallMode();
               if ( ! IsValidAjaxCall( true) )
               {
                  GxWebError = 1;
                  return  ;
               }
               gxgrGrid_refresh( subGrid_Rows, AV15DynamicFiltersSelector1, AV55TotTipo1, AV19DynamicFiltersSelector2, AV56TotTipo2, AV23DynamicFiltersSelector3, AV57TotTipo3, AV60Pgmname, AV18DynamicFiltersEnabled2, AV22DynamicFiltersEnabled3, AV32TFTotTipo_Sels, AV33TFTotRub, AV34TFTotRub_To, AV35TFRubCod, AV36TFRubCod_To, AV37TFRubLinCod, AV38TFRubLinCod_To, AV39TFRubLinDsc, AV40TFRubLinDsc_Sel, AV41TFRubLinDscTot, AV42TFRubLinDscTot_Sel, AV43TFRubLinOrd, AV44TFRubLinOrd_To, AV46TFRubLinSts_Sels, AV13OrderedBy, AV14OrderedDsc, AV10GridState, AV27DynamicFiltersIgnoreFirst) ;
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
         PA2G2( ) ;
         gxajaxcallmode = (short)((isAjaxCallMode( ) ? 1 : 0));
         if ( ( gxajaxcallmode == 0 ) && ( GxWebError == 0 ) )
         {
            START2G2( ) ;
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
         context.AddJavascriptSource("gxcfg.js", "?202281810303739", false, true);
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
         context.WriteHtmlTextNl( "<form id=\"MAINFORM\" autocomplete=\"off\" name=\"MAINFORM\" method=\"post\" tabindex=-1  class=\"form-horizontal Form\" data-gx-class=\"form-horizontal Form\" novalidate action=\""+formatLink("contabilidad.lineasww.aspx") +"\">") ;
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
         GxWebStd.gx_hidden_field( context, "gxhash_vPGMNAME", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( AV60Pgmname, "")), context));
         GXKey = Crypto.GetSiteKey( );
      }

      protected void SendCloseFormHiddens( )
      {
         /* Send hidden variables. */
         GxWebStd.gx_hidden_field( context, "GXH_vDYNAMICFILTERSSELECTOR1", AV15DynamicFiltersSelector1);
         GxWebStd.gx_hidden_field( context, "GXH_vTOTTIPO1", StringUtil.RTrim( AV55TotTipo1));
         GxWebStd.gx_hidden_field( context, "GXH_vDYNAMICFILTERSSELECTOR2", AV19DynamicFiltersSelector2);
         GxWebStd.gx_hidden_field( context, "GXH_vTOTTIPO2", StringUtil.RTrim( AV56TotTipo2));
         GxWebStd.gx_hidden_field( context, "GXH_vDYNAMICFILTERSSELECTOR3", AV23DynamicFiltersSelector3);
         GxWebStd.gx_hidden_field( context, "GXH_vTOTTIPO3", StringUtil.RTrim( AV57TotTipo3));
         /* Send saved values. */
         send_integrity_footer_hashes( ) ;
         GxWebStd.gx_hidden_field( context, "nRC_GXsfl_92", StringUtil.LTrim( StringUtil.NToC( (decimal)(nRC_GXsfl_92), 8, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "vGRIDCURRENTPAGE", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV49GridCurrentPage), 10, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "vGRIDPAGECOUNT", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV50GridPageCount), 10, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "vGRIDAPPLIEDFILTERS", AV51GridAppliedFilters);
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "vAGEXPORTDATA", AV53AGExportData);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt("vAGEXPORTDATA", AV53AGExportData);
         }
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "vDDO_TITLESETTINGSICONS", AV47DDO_TitleSettingsIcons);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt("vDDO_TITLESETTINGSICONS", AV47DDO_TitleSettingsIcons);
         }
         GxWebStd.gx_hidden_field( context, "vPGMNAME", StringUtil.RTrim( AV60Pgmname));
         GxWebStd.gx_hidden_field( context, "gxhash_vPGMNAME", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( AV60Pgmname, "")), context));
         GxWebStd.gx_boolean_hidden_field( context, "vDYNAMICFILTERSENABLED2", AV18DynamicFiltersEnabled2);
         GxWebStd.gx_boolean_hidden_field( context, "vDYNAMICFILTERSENABLED3", AV22DynamicFiltersEnabled3);
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "vTFTOTTIPO_SELS", AV32TFTotTipo_Sels);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt("vTFTOTTIPO_SELS", AV32TFTotTipo_Sels);
         }
         GxWebStd.gx_hidden_field( context, "vTFTOTRUB", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV33TFTotRub), 6, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "vTFTOTRUB_TO", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV34TFTotRub_To), 6, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "vTFRUBCOD", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV35TFRubCod), 6, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "vTFRUBCOD_TO", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV36TFRubCod_To), 6, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "vTFRUBLINCOD", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV37TFRubLinCod), 6, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "vTFRUBLINCOD_TO", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV38TFRubLinCod_To), 6, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "vTFRUBLINDSC", StringUtil.RTrim( AV39TFRubLinDsc));
         GxWebStd.gx_hidden_field( context, "vTFRUBLINDSC_SEL", StringUtil.RTrim( AV40TFRubLinDsc_Sel));
         GxWebStd.gx_hidden_field( context, "vTFRUBLINDSCTOT", StringUtil.RTrim( AV41TFRubLinDscTot));
         GxWebStd.gx_hidden_field( context, "vTFRUBLINDSCTOT_SEL", StringUtil.RTrim( AV42TFRubLinDscTot_Sel));
         GxWebStd.gx_hidden_field( context, "vTFRUBLINORD", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV43TFRubLinOrd), 2, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "vTFRUBLINORD_TO", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV44TFRubLinOrd_To), 2, 0, ".", "")));
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "vTFRUBLINSTS_SELS", AV46TFRubLinSts_Sels);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt("vTFRUBLINSTS_SELS", AV46TFRubLinSts_Sels);
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
         GxWebStd.gx_hidden_field( context, "vTFTOTTIPO_SELSJSON", AV31TFTotTipo_SelsJson);
         GxWebStd.gx_hidden_field( context, "vTFRUBLINSTS_SELSJSON", AV45TFRubLinSts_SelsJson);
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
         GxWebStd.gx_hidden_field( context, "DDO_GRID_Filteredtextto_get", StringUtil.RTrim( Ddo_grid_Filteredtextto_get));
         GxWebStd.gx_hidden_field( context, "DDO_GRID_Filteredtext_get", StringUtil.RTrim( Ddo_grid_Filteredtext_get));
         GxWebStd.gx_hidden_field( context, "DDO_GRID_Selectedcolumn", StringUtil.RTrim( Ddo_grid_Selectedcolumn));
         GxWebStd.gx_hidden_field( context, "DDO_AGEXPORT_Activeeventkey", StringUtil.RTrim( Ddo_agexport_Activeeventkey));
         GxWebStd.gx_hidden_field( context, "GRID_Rows", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid_Rows), 6, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "GRIDPAGINATIONBAR_Selectedpage", StringUtil.RTrim( Gridpaginationbar_Selectedpage));
         GxWebStd.gx_hidden_field( context, "GRIDPAGINATIONBAR_Rowsperpageselectedvalue", StringUtil.LTrim( StringUtil.NToC( (decimal)(Gridpaginationbar_Rowsperpageselectedvalue), 9, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "DDO_GRID_Activeeventkey", StringUtil.RTrim( Ddo_grid_Activeeventkey));
         GxWebStd.gx_hidden_field( context, "DDO_GRID_Selectedvalue_get", StringUtil.RTrim( Ddo_grid_Selectedvalue_get));
         GxWebStd.gx_hidden_field( context, "DDO_GRID_Filteredtextto_get", StringUtil.RTrim( Ddo_grid_Filteredtextto_get));
         GxWebStd.gx_hidden_field( context, "DDO_GRID_Filteredtext_get", StringUtil.RTrim( Ddo_grid_Filteredtext_get));
         GxWebStd.gx_hidden_field( context, "DDO_GRID_Selectedcolumn", StringUtil.RTrim( Ddo_grid_Selectedcolumn));
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
            WE2G2( ) ;
            context.WriteHtmlText( "</div>") ;
         }
      }

      public override void DispatchEvents( )
      {
         EVT2G2( ) ;
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
         return formatLink("contabilidad.lineasww.aspx")  ;
      }

      public override string GetPgmname( )
      {
         return "Contabilidad.LineasWW" ;
      }

      public override string GetPgmdesc( )
      {
         return " Lineas" ;
      }

      protected void WB2G0( )
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
            GxWebStd.gx_button_ctrl( context, bttBtninsert_Internalname, "gx.evt.setGridEvt("+StringUtil.Str( (decimal)(92), 2, 0)+","+"null"+");", "Agregar", bttBtninsert_Jsonclick, 5, "Agregar", "", StyleString, ClassString, 1, 1, "standard", "'"+""+"'"+",false,"+"'"+"E\\'DOINSERT\\'."+"'", TempTags, "", context.GetButtonType( ), "HLP_Contabilidad\\LineasWW.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "left", "top", "", "", "div");
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 21,'',false,'',0)\"";
            ClassString = "ColumnsSelector";
            StyleString = "";
            GxWebStd.gx_button_ctrl( context, bttBtnagexport_Internalname, "gx.evt.setGridEvt("+StringUtil.Str( (decimal)(92), 2, 0)+","+"null"+");", "Reportes", bttBtnagexport_Jsonclick, 0, "Reportes", "", StyleString, ClassString, 1, 0, "standard", "'"+""+"'"+",false,"+"'"+""+"'", TempTags, "", context.GetButtonType( ), "HLP_Contabilidad\\LineasWW.htm");
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
            wb_table1_25_2G2( true) ;
         }
         else
         {
            wb_table1_25_2G2( false) ;
         }
         return  ;
      }

      protected void wb_table1_25_2G2e( bool wbgen )
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
               context.WriteHtmlText( "<div id=\""+"GridContainer"+"DivS\" data-gxgridid=\"92\">") ;
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
               context.SendWebValue( "Tipo de Reporte") ;
               context.WriteHtmlTextNl( "</th>") ;
               context.WriteHtmlText( "<th align=\""+"right"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+""+""+"\" "+">") ;
               context.SendWebValue( "Codigo Rubro Totales") ;
               context.WriteHtmlTextNl( "</th>") ;
               context.WriteHtmlText( "<th align=\""+"right"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+""+""+"\" "+">") ;
               context.SendWebValue( "Codigo Rubro") ;
               context.WriteHtmlTextNl( "</th>") ;
               context.WriteHtmlText( "<th align=\""+"right"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+""+""+"\" "+">") ;
               context.SendWebValue( "Codigo Linea") ;
               context.WriteHtmlTextNl( "</th>") ;
               context.WriteHtmlText( "<th align=\""+"left"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+""+""+"\" "+">") ;
               context.SendWebValue( "Linea") ;
               context.WriteHtmlTextNl( "</th>") ;
               context.WriteHtmlText( "<th align=\""+"left"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+""+""+"\" "+">") ;
               context.SendWebValue( "Totales Linea") ;
               context.WriteHtmlTextNl( "</th>") ;
               context.WriteHtmlText( "<th align=\""+"right"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+""+""+"\" "+">") ;
               context.SendWebValue( "N° Orden") ;
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
               GridColumn.AddObjectProperty("Value", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV52GridActions), 4, 0, ".", "")));
               GridContainer.AddColumnProperties(GridColumn);
               GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
               GridColumn.AddObjectProperty("Value", StringUtil.RTrim( A114TotTipo));
               GridContainer.AddColumnProperties(GridColumn);
               GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
               GridColumn.AddObjectProperty("Value", StringUtil.LTrim( StringUtil.NToC( (decimal)(A115TotRub), 6, 0, ".", "")));
               GridContainer.AddColumnProperties(GridColumn);
               GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
               GridColumn.AddObjectProperty("Value", StringUtil.LTrim( StringUtil.NToC( (decimal)(A116RubCod), 6, 0, ".", "")));
               GridContainer.AddColumnProperties(GridColumn);
               GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
               GridColumn.AddObjectProperty("Value", StringUtil.LTrim( StringUtil.NToC( (decimal)(A118RubLinCod), 6, 0, ".", "")));
               GridContainer.AddColumnProperties(GridColumn);
               GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
               GridColumn.AddObjectProperty("Value", StringUtil.RTrim( A1826RubLinDsc));
               GridColumn.AddObjectProperty("Link", StringUtil.RTrim( edtRubLinDsc_Link));
               GridContainer.AddColumnProperties(GridColumn);
               GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
               GridColumn.AddObjectProperty("Value", StringUtil.RTrim( A1827RubLinDscTot));
               GridContainer.AddColumnProperties(GridColumn);
               GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
               GridColumn.AddObjectProperty("Value", StringUtil.LTrim( StringUtil.NToC( (decimal)(A119RubLinOrd), 2, 0, ".", "")));
               GridContainer.AddColumnProperties(GridColumn);
               GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
               GridColumn.AddObjectProperty("Value", StringUtil.LTrim( StringUtil.NToC( (decimal)(A1828RubLinSts), 1, 0, ".", "")));
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
         if ( wbEnd == 92 )
         {
            wbEnd = 0;
            nRC_GXsfl_92 = (int)(nGXsfl_92_idx-1);
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
            ucGridpaginationbar.SetProperty("CurrentPage", AV49GridCurrentPage);
            ucGridpaginationbar.SetProperty("PageCount", AV50GridPageCount);
            ucGridpaginationbar.SetProperty("AppliedFilters", AV51GridAppliedFilters);
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
            ucDdo_agexport.SetProperty("DropDownOptionsData", AV53AGExportData);
            ucDdo_agexport.Render(context, "dvelop.gxbootstrap.ddoregular", Ddo_agexport_Internalname, "DDO_AGEXPORTContainer");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblJsdynamicfilters_Internalname, lblJsdynamicfilters_Caption, "", "", lblJsdynamicfilters_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "", 0, "", 1, 1, 0, 1, "HLP_Contabilidad\\LineasWW.htm");
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
            ucDdo_grid.SetProperty("DropDownOptionsTitleSettingsIcons", AV47DDO_TitleSettingsIcons);
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
         if ( wbEnd == 92 )
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

      protected void START2G2( )
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
            Form.Meta.addItem("description", " Lineas", 0) ;
         }
         context.wjLoc = "";
         context.nUserReturn = 0;
         context.wbHandled = 0;
         if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
         {
         }
         wbErr = false;
         STRUP2G0( ) ;
      }

      protected void WS2G2( )
      {
         START2G2( ) ;
         EVT2G2( ) ;
      }

      protected void EVT2G2( )
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
                              E112G2 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "GRIDPAGINATIONBAR.CHANGEROWSPERPAGE") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              E122G2 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "DDO_AGEXPORT.ONOPTIONCLICKED") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              E132G2 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "DDO_GRID.ONOPTIONCLICKED") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              E142G2 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "'REMOVEDYNAMICFILTERS1'") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              /* Execute user event: 'RemoveDynamicFilters1' */
                              E152G2 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "'REMOVEDYNAMICFILTERS2'") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              /* Execute user event: 'RemoveDynamicFilters2' */
                              E162G2 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "'REMOVEDYNAMICFILTERS3'") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              /* Execute user event: 'RemoveDynamicFilters3' */
                              E172G2 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "'DOINSERT'") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              /* Execute user event: 'DoInsert' */
                              E182G2 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "'ADDDYNAMICFILTERS1'") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              /* Execute user event: 'AddDynamicFilters1' */
                              E192G2 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "VDYNAMICFILTERSSELECTOR1.CLICK") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              E202G2 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "'ADDDYNAMICFILTERS2'") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              /* Execute user event: 'AddDynamicFilters2' */
                              E212G2 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "VDYNAMICFILTERSSELECTOR2.CLICK") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              E222G2 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "VDYNAMICFILTERSSELECTOR3.CLICK") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              E232G2 ();
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
                              nGXsfl_92_idx = (int)(NumberUtil.Val( sEvtType, "."));
                              sGXsfl_92_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_92_idx), 4, 0), 4, "0");
                              SubsflControlProps_922( ) ;
                              cmbavGridactions.Name = cmbavGridactions_Internalname;
                              cmbavGridactions.CurrentValue = cgiGet( cmbavGridactions_Internalname);
                              AV52GridActions = (short)(NumberUtil.Val( cgiGet( cmbavGridactions_Internalname), "."));
                              AssignAttri("", false, cmbavGridactions_Internalname, StringUtil.LTrimStr( (decimal)(AV52GridActions), 4, 0));
                              A114TotTipo = cgiGet( edtTotTipo_Internalname);
                              A115TotRub = (int)(context.localUtil.CToN( cgiGet( edtTotRub_Internalname), ".", ","));
                              A116RubCod = (int)(context.localUtil.CToN( cgiGet( edtRubCod_Internalname), ".", ","));
                              A118RubLinCod = (int)(context.localUtil.CToN( cgiGet( edtRubLinCod_Internalname), ".", ","));
                              A1826RubLinDsc = cgiGet( edtRubLinDsc_Internalname);
                              A1827RubLinDscTot = cgiGet( edtRubLinDscTot_Internalname);
                              A119RubLinOrd = (short)(context.localUtil.CToN( cgiGet( edtRubLinOrd_Internalname), ".", ","));
                              cmbRubLinSts.Name = cmbRubLinSts_Internalname;
                              cmbRubLinSts.CurrentValue = cgiGet( cmbRubLinSts_Internalname);
                              A1828RubLinSts = (short)(NumberUtil.Val( cgiGet( cmbRubLinSts_Internalname), "."));
                              sEvtType = StringUtil.Right( sEvt, 1);
                              if ( StringUtil.StrCmp(sEvtType, ".") == 0 )
                              {
                                 sEvt = StringUtil.Left( sEvt, (short)(StringUtil.Len( sEvt)-1));
                                 if ( StringUtil.StrCmp(sEvt, "START") == 0 )
                                 {
                                    context.wbHandled = 1;
                                    dynload_actions( ) ;
                                    /* Execute user event: Start */
                                    E242G2 ();
                                 }
                                 else if ( StringUtil.StrCmp(sEvt, "REFRESH") == 0 )
                                 {
                                    context.wbHandled = 1;
                                    dynload_actions( ) ;
                                    /* Execute user event: Refresh */
                                    E252G2 ();
                                 }
                                 else if ( StringUtil.StrCmp(sEvt, "GRID.LOAD") == 0 )
                                 {
                                    context.wbHandled = 1;
                                    dynload_actions( ) ;
                                    E262G2 ();
                                 }
                                 else if ( StringUtil.StrCmp(sEvt, "VGRIDACTIONS.CLICK") == 0 )
                                 {
                                    context.wbHandled = 1;
                                    dynload_actions( ) ;
                                    E272G2 ();
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
                                       /* Set Refresh If Tottipo1 Changed */
                                       if ( StringUtil.StrCmp(cgiGet( "GXH_vTOTTIPO1"), AV55TotTipo1) != 0 )
                                       {
                                          Rfr0gs = true;
                                       }
                                       /* Set Refresh If Dynamicfiltersselector2 Changed */
                                       if ( StringUtil.StrCmp(cgiGet( "GXH_vDYNAMICFILTERSSELECTOR2"), AV19DynamicFiltersSelector2) != 0 )
                                       {
                                          Rfr0gs = true;
                                       }
                                       /* Set Refresh If Tottipo2 Changed */
                                       if ( StringUtil.StrCmp(cgiGet( "GXH_vTOTTIPO2"), AV56TotTipo2) != 0 )
                                       {
                                          Rfr0gs = true;
                                       }
                                       /* Set Refresh If Dynamicfiltersselector3 Changed */
                                       if ( StringUtil.StrCmp(cgiGet( "GXH_vDYNAMICFILTERSSELECTOR3"), AV23DynamicFiltersSelector3) != 0 )
                                       {
                                          Rfr0gs = true;
                                       }
                                       /* Set Refresh If Tottipo3 Changed */
                                       if ( StringUtil.StrCmp(cgiGet( "GXH_vTOTTIPO3"), AV57TotTipo3) != 0 )
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

      protected void WE2G2( )
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

      protected void PA2G2( )
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
         SubsflControlProps_922( ) ;
         while ( nGXsfl_92_idx <= nRC_GXsfl_92 )
         {
            sendrow_922( ) ;
            nGXsfl_92_idx = ((subGrid_Islastpage==1)&&(nGXsfl_92_idx+1>subGrid_fnc_Recordsperpage( )) ? 1 : nGXsfl_92_idx+1);
            sGXsfl_92_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_92_idx), 4, 0), 4, "0");
            SubsflControlProps_922( ) ;
         }
         AddString( context.httpAjaxContext.getJSONContainerResponse( GridContainer)) ;
         /* End function gxnrGrid_newrow */
      }

      protected void gxgrGrid_refresh( int subGrid_Rows ,
                                       string AV15DynamicFiltersSelector1 ,
                                       string AV55TotTipo1 ,
                                       string AV19DynamicFiltersSelector2 ,
                                       string AV56TotTipo2 ,
                                       string AV23DynamicFiltersSelector3 ,
                                       string AV57TotTipo3 ,
                                       string AV60Pgmname ,
                                       bool AV18DynamicFiltersEnabled2 ,
                                       bool AV22DynamicFiltersEnabled3 ,
                                       GxSimpleCollection<string> AV32TFTotTipo_Sels ,
                                       int AV33TFTotRub ,
                                       int AV34TFTotRub_To ,
                                       int AV35TFRubCod ,
                                       int AV36TFRubCod_To ,
                                       int AV37TFRubLinCod ,
                                       int AV38TFRubLinCod_To ,
                                       string AV39TFRubLinDsc ,
                                       string AV40TFRubLinDsc_Sel ,
                                       string AV41TFRubLinDscTot ,
                                       string AV42TFRubLinDscTot_Sel ,
                                       short AV43TFRubLinOrd ,
                                       short AV44TFRubLinOrd_To ,
                                       GxSimpleCollection<short> AV46TFRubLinSts_Sels ,
                                       short AV13OrderedBy ,
                                       bool AV14OrderedDsc ,
                                       GeneXus.Programs.wwpbaseobjects.SdtWWPGridState AV10GridState ,
                                       bool AV27DynamicFiltersIgnoreFirst )
      {
         initialize_formulas( ) ;
         GxWebStd.set_html_headers( context, 0, "", "");
         /* Execute user event: Refresh */
         E252G2 ();
         GRID_nCurrentRecord = 0;
         RF2G2( ) ;
         GXKey = Crypto.GetSiteKey( );
         send_integrity_footer_hashes( ) ;
         GXKey = Crypto.GetSiteKey( );
         /* End function gxgrGrid_refresh */
      }

      protected void send_integrity_hashes( )
      {
         GxWebStd.gx_hidden_field( context, "gxhash_TOTTIPO", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( A114TotTipo, "")), context));
         GxWebStd.gx_hidden_field( context, "TOTTIPO", StringUtil.RTrim( A114TotTipo));
         GxWebStd.gx_hidden_field( context, "gxhash_TOTRUB", GetSecureSignedToken( "", context.localUtil.Format( (decimal)(A115TotRub), "ZZZZZ9"), context));
         GxWebStd.gx_hidden_field( context, "TOTRUB", StringUtil.LTrim( StringUtil.NToC( (decimal)(A115TotRub), 6, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "gxhash_RUBCOD", GetSecureSignedToken( "", context.localUtil.Format( (decimal)(A116RubCod), "ZZZZZ9"), context));
         GxWebStd.gx_hidden_field( context, "RUBCOD", StringUtil.LTrim( StringUtil.NToC( (decimal)(A116RubCod), 6, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "gxhash_RUBLINCOD", GetSecureSignedToken( "", context.localUtil.Format( (decimal)(A118RubLinCod), "ZZZZZ9"), context));
         GxWebStd.gx_hidden_field( context, "RUBLINCOD", StringUtil.LTrim( StringUtil.NToC( (decimal)(A118RubLinCod), 6, 0, ".", "")));
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
      }

      public void Refresh( )
      {
         send_integrity_hashes( ) ;
         RF2G2( ) ;
         if ( isFullAjaxMode( ) )
         {
            send_integrity_footer_hashes( ) ;
         }
      }

      protected void initialize_formulas( )
      {
         /* GeneXus formulas. */
         AV60Pgmname = "Contabilidad.LineasWW";
         context.Gx_err = 0;
      }

      protected void RF2G2( )
      {
         initialize_formulas( ) ;
         clear_multi_value_controls( ) ;
         if ( isAjaxCallMode( ) )
         {
            GridContainer.ClearRows();
         }
         wbStart = 92;
         /* Execute user event: Refresh */
         E252G2 ();
         nGXsfl_92_idx = 1;
         sGXsfl_92_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_92_idx), 4, 0), 4, "0");
         SubsflControlProps_922( ) ;
         bGXsfl_92_Refreshing = true;
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
            SubsflControlProps_922( ) ;
            GXPagingFrom2 = (int)(((subGrid_Rows==0) ? 0 : GRID_nFirstRecordOnPage));
            GXPagingTo2 = ((subGrid_Rows==0) ? 10000 : subGrid_fnc_Recordsperpage( )+1);
            pr_default.dynParam(0, new Object[]{ new Object[]{
                                                 A114TotTipo ,
                                                 AV69Contabilidad_lineaswwds_9_tftottipo_sels ,
                                                 A1828RubLinSts ,
                                                 AV82Contabilidad_lineaswwds_22_tfrublinsts_sels ,
                                                 AV61Contabilidad_lineaswwds_1_dynamicfiltersselector1 ,
                                                 AV62Contabilidad_lineaswwds_2_tottipo1 ,
                                                 AV63Contabilidad_lineaswwds_3_dynamicfiltersenabled2 ,
                                                 AV64Contabilidad_lineaswwds_4_dynamicfiltersselector2 ,
                                                 AV65Contabilidad_lineaswwds_5_tottipo2 ,
                                                 AV66Contabilidad_lineaswwds_6_dynamicfiltersenabled3 ,
                                                 AV67Contabilidad_lineaswwds_7_dynamicfiltersselector3 ,
                                                 AV68Contabilidad_lineaswwds_8_tottipo3 ,
                                                 AV69Contabilidad_lineaswwds_9_tftottipo_sels.Count ,
                                                 AV70Contabilidad_lineaswwds_10_tftotrub ,
                                                 AV71Contabilidad_lineaswwds_11_tftotrub_to ,
                                                 AV72Contabilidad_lineaswwds_12_tfrubcod ,
                                                 AV73Contabilidad_lineaswwds_13_tfrubcod_to ,
                                                 AV74Contabilidad_lineaswwds_14_tfrublincod ,
                                                 AV75Contabilidad_lineaswwds_15_tfrublincod_to ,
                                                 AV77Contabilidad_lineaswwds_17_tfrublindsc_sel ,
                                                 AV76Contabilidad_lineaswwds_16_tfrublindsc ,
                                                 AV79Contabilidad_lineaswwds_19_tfrublindsctot_sel ,
                                                 AV78Contabilidad_lineaswwds_18_tfrublindsctot ,
                                                 AV80Contabilidad_lineaswwds_20_tfrublinord ,
                                                 AV81Contabilidad_lineaswwds_21_tfrublinord_to ,
                                                 AV82Contabilidad_lineaswwds_22_tfrublinsts_sels.Count ,
                                                 A115TotRub ,
                                                 A116RubCod ,
                                                 A118RubLinCod ,
                                                 A1826RubLinDsc ,
                                                 A1827RubLinDscTot ,
                                                 A119RubLinOrd ,
                                                 AV13OrderedBy ,
                                                 AV14OrderedDsc } ,
                                                 new int[]{
                                                 TypeConstants.SHORT, TypeConstants.BOOLEAN, TypeConstants.BOOLEAN, TypeConstants.INT, TypeConstants.INT, TypeConstants.INT, TypeConstants.INT, TypeConstants.INT, TypeConstants.INT, TypeConstants.INT,
                                                 TypeConstants.SHORT, TypeConstants.SHORT, TypeConstants.INT, TypeConstants.INT, TypeConstants.INT, TypeConstants.INT, TypeConstants.SHORT, TypeConstants.SHORT, TypeConstants.BOOLEAN
                                                 }
            });
            lV76Contabilidad_lineaswwds_16_tfrublindsc = StringUtil.PadR( StringUtil.RTrim( AV76Contabilidad_lineaswwds_16_tfrublindsc), 100, "%");
            lV78Contabilidad_lineaswwds_18_tfrublindsctot = StringUtil.PadR( StringUtil.RTrim( AV78Contabilidad_lineaswwds_18_tfrublindsctot), 100, "%");
            /* Using cursor H002G2 */
            pr_default.execute(0, new Object[] {AV62Contabilidad_lineaswwds_2_tottipo1, AV65Contabilidad_lineaswwds_5_tottipo2, AV68Contabilidad_lineaswwds_8_tottipo3, AV70Contabilidad_lineaswwds_10_tftotrub, AV71Contabilidad_lineaswwds_11_tftotrub_to, AV72Contabilidad_lineaswwds_12_tfrubcod, AV73Contabilidad_lineaswwds_13_tfrubcod_to, AV74Contabilidad_lineaswwds_14_tfrublincod, AV75Contabilidad_lineaswwds_15_tfrublincod_to, lV76Contabilidad_lineaswwds_16_tfrublindsc, AV77Contabilidad_lineaswwds_17_tfrublindsc_sel, lV78Contabilidad_lineaswwds_18_tfrublindsctot, AV79Contabilidad_lineaswwds_19_tfrublindsctot_sel, AV80Contabilidad_lineaswwds_20_tfrublinord, AV81Contabilidad_lineaswwds_21_tfrublinord_to, GXPagingFrom2, GXPagingTo2, GXPagingTo2});
            nGXsfl_92_idx = 1;
            sGXsfl_92_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_92_idx), 4, 0), 4, "0");
            SubsflControlProps_922( ) ;
            while ( ( (pr_default.getStatus(0) != 101) ) && ( ( ( subGrid_Rows == 0 ) || ( GRID_nCurrentRecord < subGrid_fnc_Recordsperpage( ) ) ) ) )
            {
               A1828RubLinSts = H002G2_A1828RubLinSts[0];
               A119RubLinOrd = H002G2_A119RubLinOrd[0];
               A1827RubLinDscTot = H002G2_A1827RubLinDscTot[0];
               A1826RubLinDsc = H002G2_A1826RubLinDsc[0];
               A118RubLinCod = H002G2_A118RubLinCod[0];
               A116RubCod = H002G2_A116RubCod[0];
               A115TotRub = H002G2_A115TotRub[0];
               A114TotTipo = H002G2_A114TotTipo[0];
               E262G2 ();
               pr_default.readNext(0);
            }
            GRID_nEOF = (short)(((pr_default.getStatus(0) == 101) ? 1 : 0));
            GxWebStd.gx_hidden_field( context, "GRID_nEOF", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRID_nEOF), 1, 0, ".", "")));
            pr_default.close(0);
            wbEnd = 92;
            WB2G0( ) ;
         }
         bGXsfl_92_Refreshing = true;
      }

      protected void send_integrity_lvl_hashes2G2( )
      {
         GxWebStd.gx_hidden_field( context, "vPGMNAME", StringUtil.RTrim( AV60Pgmname));
         GxWebStd.gx_hidden_field( context, "gxhash_vPGMNAME", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( AV60Pgmname, "")), context));
         GxWebStd.gx_hidden_field( context, "gxhash_TOTTIPO"+"_"+sGXsfl_92_idx, GetSecureSignedToken( sGXsfl_92_idx, StringUtil.RTrim( context.localUtil.Format( A114TotTipo, "")), context));
         GxWebStd.gx_hidden_field( context, "gxhash_TOTRUB"+"_"+sGXsfl_92_idx, GetSecureSignedToken( sGXsfl_92_idx, context.localUtil.Format( (decimal)(A115TotRub), "ZZZZZ9"), context));
         GxWebStd.gx_hidden_field( context, "gxhash_RUBCOD"+"_"+sGXsfl_92_idx, GetSecureSignedToken( sGXsfl_92_idx, context.localUtil.Format( (decimal)(A116RubCod), "ZZZZZ9"), context));
         GxWebStd.gx_hidden_field( context, "gxhash_RUBLINCOD"+"_"+sGXsfl_92_idx, GetSecureSignedToken( sGXsfl_92_idx, context.localUtil.Format( (decimal)(A118RubLinCod), "ZZZZZ9"), context));
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
         AV61Contabilidad_lineaswwds_1_dynamicfiltersselector1 = AV15DynamicFiltersSelector1;
         AV62Contabilidad_lineaswwds_2_tottipo1 = AV55TotTipo1;
         AV63Contabilidad_lineaswwds_3_dynamicfiltersenabled2 = AV18DynamicFiltersEnabled2;
         AV64Contabilidad_lineaswwds_4_dynamicfiltersselector2 = AV19DynamicFiltersSelector2;
         AV65Contabilidad_lineaswwds_5_tottipo2 = AV56TotTipo2;
         AV66Contabilidad_lineaswwds_6_dynamicfiltersenabled3 = AV22DynamicFiltersEnabled3;
         AV67Contabilidad_lineaswwds_7_dynamicfiltersselector3 = AV23DynamicFiltersSelector3;
         AV68Contabilidad_lineaswwds_8_tottipo3 = AV57TotTipo3;
         AV69Contabilidad_lineaswwds_9_tftottipo_sels = AV32TFTotTipo_Sels;
         AV70Contabilidad_lineaswwds_10_tftotrub = AV33TFTotRub;
         AV71Contabilidad_lineaswwds_11_tftotrub_to = AV34TFTotRub_To;
         AV72Contabilidad_lineaswwds_12_tfrubcod = AV35TFRubCod;
         AV73Contabilidad_lineaswwds_13_tfrubcod_to = AV36TFRubCod_To;
         AV74Contabilidad_lineaswwds_14_tfrublincod = AV37TFRubLinCod;
         AV75Contabilidad_lineaswwds_15_tfrublincod_to = AV38TFRubLinCod_To;
         AV76Contabilidad_lineaswwds_16_tfrublindsc = AV39TFRubLinDsc;
         AV77Contabilidad_lineaswwds_17_tfrublindsc_sel = AV40TFRubLinDsc_Sel;
         AV78Contabilidad_lineaswwds_18_tfrublindsctot = AV41TFRubLinDscTot;
         AV79Contabilidad_lineaswwds_19_tfrublindsctot_sel = AV42TFRubLinDscTot_Sel;
         AV80Contabilidad_lineaswwds_20_tfrublinord = AV43TFRubLinOrd;
         AV81Contabilidad_lineaswwds_21_tfrublinord_to = AV44TFRubLinOrd_To;
         AV82Contabilidad_lineaswwds_22_tfrublinsts_sels = AV46TFRubLinSts_Sels;
         pr_default.dynParam(1, new Object[]{ new Object[]{
                                              A114TotTipo ,
                                              AV69Contabilidad_lineaswwds_9_tftottipo_sels ,
                                              A1828RubLinSts ,
                                              AV82Contabilidad_lineaswwds_22_tfrublinsts_sels ,
                                              AV61Contabilidad_lineaswwds_1_dynamicfiltersselector1 ,
                                              AV62Contabilidad_lineaswwds_2_tottipo1 ,
                                              AV63Contabilidad_lineaswwds_3_dynamicfiltersenabled2 ,
                                              AV64Contabilidad_lineaswwds_4_dynamicfiltersselector2 ,
                                              AV65Contabilidad_lineaswwds_5_tottipo2 ,
                                              AV66Contabilidad_lineaswwds_6_dynamicfiltersenabled3 ,
                                              AV67Contabilidad_lineaswwds_7_dynamicfiltersselector3 ,
                                              AV68Contabilidad_lineaswwds_8_tottipo3 ,
                                              AV69Contabilidad_lineaswwds_9_tftottipo_sels.Count ,
                                              AV70Contabilidad_lineaswwds_10_tftotrub ,
                                              AV71Contabilidad_lineaswwds_11_tftotrub_to ,
                                              AV72Contabilidad_lineaswwds_12_tfrubcod ,
                                              AV73Contabilidad_lineaswwds_13_tfrubcod_to ,
                                              AV74Contabilidad_lineaswwds_14_tfrublincod ,
                                              AV75Contabilidad_lineaswwds_15_tfrublincod_to ,
                                              AV77Contabilidad_lineaswwds_17_tfrublindsc_sel ,
                                              AV76Contabilidad_lineaswwds_16_tfrublindsc ,
                                              AV79Contabilidad_lineaswwds_19_tfrublindsctot_sel ,
                                              AV78Contabilidad_lineaswwds_18_tfrublindsctot ,
                                              AV80Contabilidad_lineaswwds_20_tfrublinord ,
                                              AV81Contabilidad_lineaswwds_21_tfrublinord_to ,
                                              AV82Contabilidad_lineaswwds_22_tfrublinsts_sels.Count ,
                                              A115TotRub ,
                                              A116RubCod ,
                                              A118RubLinCod ,
                                              A1826RubLinDsc ,
                                              A1827RubLinDscTot ,
                                              A119RubLinOrd ,
                                              AV13OrderedBy ,
                                              AV14OrderedDsc } ,
                                              new int[]{
                                              TypeConstants.SHORT, TypeConstants.BOOLEAN, TypeConstants.BOOLEAN, TypeConstants.INT, TypeConstants.INT, TypeConstants.INT, TypeConstants.INT, TypeConstants.INT, TypeConstants.INT, TypeConstants.INT,
                                              TypeConstants.SHORT, TypeConstants.SHORT, TypeConstants.INT, TypeConstants.INT, TypeConstants.INT, TypeConstants.INT, TypeConstants.SHORT, TypeConstants.SHORT, TypeConstants.BOOLEAN
                                              }
         });
         lV76Contabilidad_lineaswwds_16_tfrublindsc = StringUtil.PadR( StringUtil.RTrim( AV76Contabilidad_lineaswwds_16_tfrublindsc), 100, "%");
         lV78Contabilidad_lineaswwds_18_tfrublindsctot = StringUtil.PadR( StringUtil.RTrim( AV78Contabilidad_lineaswwds_18_tfrublindsctot), 100, "%");
         /* Using cursor H002G3 */
         pr_default.execute(1, new Object[] {AV62Contabilidad_lineaswwds_2_tottipo1, AV65Contabilidad_lineaswwds_5_tottipo2, AV68Contabilidad_lineaswwds_8_tottipo3, AV70Contabilidad_lineaswwds_10_tftotrub, AV71Contabilidad_lineaswwds_11_tftotrub_to, AV72Contabilidad_lineaswwds_12_tfrubcod, AV73Contabilidad_lineaswwds_13_tfrubcod_to, AV74Contabilidad_lineaswwds_14_tfrublincod, AV75Contabilidad_lineaswwds_15_tfrublincod_to, lV76Contabilidad_lineaswwds_16_tfrublindsc, AV77Contabilidad_lineaswwds_17_tfrublindsc_sel, lV78Contabilidad_lineaswwds_18_tfrublindsctot, AV79Contabilidad_lineaswwds_19_tfrublindsctot_sel, AV80Contabilidad_lineaswwds_20_tfrublinord, AV81Contabilidad_lineaswwds_21_tfrublinord_to});
         GRID_nRecordCount = H002G3_AGRID_nRecordCount[0];
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
         AV61Contabilidad_lineaswwds_1_dynamicfiltersselector1 = AV15DynamicFiltersSelector1;
         AV62Contabilidad_lineaswwds_2_tottipo1 = AV55TotTipo1;
         AV63Contabilidad_lineaswwds_3_dynamicfiltersenabled2 = AV18DynamicFiltersEnabled2;
         AV64Contabilidad_lineaswwds_4_dynamicfiltersselector2 = AV19DynamicFiltersSelector2;
         AV65Contabilidad_lineaswwds_5_tottipo2 = AV56TotTipo2;
         AV66Contabilidad_lineaswwds_6_dynamicfiltersenabled3 = AV22DynamicFiltersEnabled3;
         AV67Contabilidad_lineaswwds_7_dynamicfiltersselector3 = AV23DynamicFiltersSelector3;
         AV68Contabilidad_lineaswwds_8_tottipo3 = AV57TotTipo3;
         AV69Contabilidad_lineaswwds_9_tftottipo_sels = AV32TFTotTipo_Sels;
         AV70Contabilidad_lineaswwds_10_tftotrub = AV33TFTotRub;
         AV71Contabilidad_lineaswwds_11_tftotrub_to = AV34TFTotRub_To;
         AV72Contabilidad_lineaswwds_12_tfrubcod = AV35TFRubCod;
         AV73Contabilidad_lineaswwds_13_tfrubcod_to = AV36TFRubCod_To;
         AV74Contabilidad_lineaswwds_14_tfrublincod = AV37TFRubLinCod;
         AV75Contabilidad_lineaswwds_15_tfrublincod_to = AV38TFRubLinCod_To;
         AV76Contabilidad_lineaswwds_16_tfrublindsc = AV39TFRubLinDsc;
         AV77Contabilidad_lineaswwds_17_tfrublindsc_sel = AV40TFRubLinDsc_Sel;
         AV78Contabilidad_lineaswwds_18_tfrublindsctot = AV41TFRubLinDscTot;
         AV79Contabilidad_lineaswwds_19_tfrublindsctot_sel = AV42TFRubLinDscTot_Sel;
         AV80Contabilidad_lineaswwds_20_tfrublinord = AV43TFRubLinOrd;
         AV81Contabilidad_lineaswwds_21_tfrublinord_to = AV44TFRubLinOrd_To;
         AV82Contabilidad_lineaswwds_22_tfrublinsts_sels = AV46TFRubLinSts_Sels;
         GRID_nFirstRecordOnPage = 0;
         GxWebStd.gx_hidden_field( context, "GRID_nFirstRecordOnPage", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRID_nFirstRecordOnPage), 15, 0, ".", "")));
         if ( isFullAjaxMode( ) )
         {
            gxgrGrid_refresh( subGrid_Rows, AV15DynamicFiltersSelector1, AV55TotTipo1, AV19DynamicFiltersSelector2, AV56TotTipo2, AV23DynamicFiltersSelector3, AV57TotTipo3, AV60Pgmname, AV18DynamicFiltersEnabled2, AV22DynamicFiltersEnabled3, AV32TFTotTipo_Sels, AV33TFTotRub, AV34TFTotRub_To, AV35TFRubCod, AV36TFRubCod_To, AV37TFRubLinCod, AV38TFRubLinCod_To, AV39TFRubLinDsc, AV40TFRubLinDsc_Sel, AV41TFRubLinDscTot, AV42TFRubLinDscTot_Sel, AV43TFRubLinOrd, AV44TFRubLinOrd_To, AV46TFRubLinSts_Sels, AV13OrderedBy, AV14OrderedDsc, AV10GridState, AV27DynamicFiltersIgnoreFirst) ;
         }
         send_integrity_footer_hashes( ) ;
         return 0 ;
      }

      protected short subgrid_nextpage( )
      {
         AV61Contabilidad_lineaswwds_1_dynamicfiltersselector1 = AV15DynamicFiltersSelector1;
         AV62Contabilidad_lineaswwds_2_tottipo1 = AV55TotTipo1;
         AV63Contabilidad_lineaswwds_3_dynamicfiltersenabled2 = AV18DynamicFiltersEnabled2;
         AV64Contabilidad_lineaswwds_4_dynamicfiltersselector2 = AV19DynamicFiltersSelector2;
         AV65Contabilidad_lineaswwds_5_tottipo2 = AV56TotTipo2;
         AV66Contabilidad_lineaswwds_6_dynamicfiltersenabled3 = AV22DynamicFiltersEnabled3;
         AV67Contabilidad_lineaswwds_7_dynamicfiltersselector3 = AV23DynamicFiltersSelector3;
         AV68Contabilidad_lineaswwds_8_tottipo3 = AV57TotTipo3;
         AV69Contabilidad_lineaswwds_9_tftottipo_sels = AV32TFTotTipo_Sels;
         AV70Contabilidad_lineaswwds_10_tftotrub = AV33TFTotRub;
         AV71Contabilidad_lineaswwds_11_tftotrub_to = AV34TFTotRub_To;
         AV72Contabilidad_lineaswwds_12_tfrubcod = AV35TFRubCod;
         AV73Contabilidad_lineaswwds_13_tfrubcod_to = AV36TFRubCod_To;
         AV74Contabilidad_lineaswwds_14_tfrublincod = AV37TFRubLinCod;
         AV75Contabilidad_lineaswwds_15_tfrublincod_to = AV38TFRubLinCod_To;
         AV76Contabilidad_lineaswwds_16_tfrublindsc = AV39TFRubLinDsc;
         AV77Contabilidad_lineaswwds_17_tfrublindsc_sel = AV40TFRubLinDsc_Sel;
         AV78Contabilidad_lineaswwds_18_tfrublindsctot = AV41TFRubLinDscTot;
         AV79Contabilidad_lineaswwds_19_tfrublindsctot_sel = AV42TFRubLinDscTot_Sel;
         AV80Contabilidad_lineaswwds_20_tfrublinord = AV43TFRubLinOrd;
         AV81Contabilidad_lineaswwds_21_tfrublinord_to = AV44TFRubLinOrd_To;
         AV82Contabilidad_lineaswwds_22_tfrublinsts_sels = AV46TFRubLinSts_Sels;
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
            gxgrGrid_refresh( subGrid_Rows, AV15DynamicFiltersSelector1, AV55TotTipo1, AV19DynamicFiltersSelector2, AV56TotTipo2, AV23DynamicFiltersSelector3, AV57TotTipo3, AV60Pgmname, AV18DynamicFiltersEnabled2, AV22DynamicFiltersEnabled3, AV32TFTotTipo_Sels, AV33TFTotRub, AV34TFTotRub_To, AV35TFRubCod, AV36TFRubCod_To, AV37TFRubLinCod, AV38TFRubLinCod_To, AV39TFRubLinDsc, AV40TFRubLinDsc_Sel, AV41TFRubLinDscTot, AV42TFRubLinDscTot_Sel, AV43TFRubLinOrd, AV44TFRubLinOrd_To, AV46TFRubLinSts_Sels, AV13OrderedBy, AV14OrderedDsc, AV10GridState, AV27DynamicFiltersIgnoreFirst) ;
         }
         send_integrity_footer_hashes( ) ;
         return (short)(((GRID_nEOF==0) ? 0 : 2)) ;
      }

      protected short subgrid_previouspage( )
      {
         AV61Contabilidad_lineaswwds_1_dynamicfiltersselector1 = AV15DynamicFiltersSelector1;
         AV62Contabilidad_lineaswwds_2_tottipo1 = AV55TotTipo1;
         AV63Contabilidad_lineaswwds_3_dynamicfiltersenabled2 = AV18DynamicFiltersEnabled2;
         AV64Contabilidad_lineaswwds_4_dynamicfiltersselector2 = AV19DynamicFiltersSelector2;
         AV65Contabilidad_lineaswwds_5_tottipo2 = AV56TotTipo2;
         AV66Contabilidad_lineaswwds_6_dynamicfiltersenabled3 = AV22DynamicFiltersEnabled3;
         AV67Contabilidad_lineaswwds_7_dynamicfiltersselector3 = AV23DynamicFiltersSelector3;
         AV68Contabilidad_lineaswwds_8_tottipo3 = AV57TotTipo3;
         AV69Contabilidad_lineaswwds_9_tftottipo_sels = AV32TFTotTipo_Sels;
         AV70Contabilidad_lineaswwds_10_tftotrub = AV33TFTotRub;
         AV71Contabilidad_lineaswwds_11_tftotrub_to = AV34TFTotRub_To;
         AV72Contabilidad_lineaswwds_12_tfrubcod = AV35TFRubCod;
         AV73Contabilidad_lineaswwds_13_tfrubcod_to = AV36TFRubCod_To;
         AV74Contabilidad_lineaswwds_14_tfrublincod = AV37TFRubLinCod;
         AV75Contabilidad_lineaswwds_15_tfrublincod_to = AV38TFRubLinCod_To;
         AV76Contabilidad_lineaswwds_16_tfrublindsc = AV39TFRubLinDsc;
         AV77Contabilidad_lineaswwds_17_tfrublindsc_sel = AV40TFRubLinDsc_Sel;
         AV78Contabilidad_lineaswwds_18_tfrublindsctot = AV41TFRubLinDscTot;
         AV79Contabilidad_lineaswwds_19_tfrublindsctot_sel = AV42TFRubLinDscTot_Sel;
         AV80Contabilidad_lineaswwds_20_tfrublinord = AV43TFRubLinOrd;
         AV81Contabilidad_lineaswwds_21_tfrublinord_to = AV44TFRubLinOrd_To;
         AV82Contabilidad_lineaswwds_22_tfrublinsts_sels = AV46TFRubLinSts_Sels;
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
            gxgrGrid_refresh( subGrid_Rows, AV15DynamicFiltersSelector1, AV55TotTipo1, AV19DynamicFiltersSelector2, AV56TotTipo2, AV23DynamicFiltersSelector3, AV57TotTipo3, AV60Pgmname, AV18DynamicFiltersEnabled2, AV22DynamicFiltersEnabled3, AV32TFTotTipo_Sels, AV33TFTotRub, AV34TFTotRub_To, AV35TFRubCod, AV36TFRubCod_To, AV37TFRubLinCod, AV38TFRubLinCod_To, AV39TFRubLinDsc, AV40TFRubLinDsc_Sel, AV41TFRubLinDscTot, AV42TFRubLinDscTot_Sel, AV43TFRubLinOrd, AV44TFRubLinOrd_To, AV46TFRubLinSts_Sels, AV13OrderedBy, AV14OrderedDsc, AV10GridState, AV27DynamicFiltersIgnoreFirst) ;
         }
         send_integrity_footer_hashes( ) ;
         return 0 ;
      }

      protected short subgrid_lastpage( )
      {
         AV61Contabilidad_lineaswwds_1_dynamicfiltersselector1 = AV15DynamicFiltersSelector1;
         AV62Contabilidad_lineaswwds_2_tottipo1 = AV55TotTipo1;
         AV63Contabilidad_lineaswwds_3_dynamicfiltersenabled2 = AV18DynamicFiltersEnabled2;
         AV64Contabilidad_lineaswwds_4_dynamicfiltersselector2 = AV19DynamicFiltersSelector2;
         AV65Contabilidad_lineaswwds_5_tottipo2 = AV56TotTipo2;
         AV66Contabilidad_lineaswwds_6_dynamicfiltersenabled3 = AV22DynamicFiltersEnabled3;
         AV67Contabilidad_lineaswwds_7_dynamicfiltersselector3 = AV23DynamicFiltersSelector3;
         AV68Contabilidad_lineaswwds_8_tottipo3 = AV57TotTipo3;
         AV69Contabilidad_lineaswwds_9_tftottipo_sels = AV32TFTotTipo_Sels;
         AV70Contabilidad_lineaswwds_10_tftotrub = AV33TFTotRub;
         AV71Contabilidad_lineaswwds_11_tftotrub_to = AV34TFTotRub_To;
         AV72Contabilidad_lineaswwds_12_tfrubcod = AV35TFRubCod;
         AV73Contabilidad_lineaswwds_13_tfrubcod_to = AV36TFRubCod_To;
         AV74Contabilidad_lineaswwds_14_tfrublincod = AV37TFRubLinCod;
         AV75Contabilidad_lineaswwds_15_tfrublincod_to = AV38TFRubLinCod_To;
         AV76Contabilidad_lineaswwds_16_tfrublindsc = AV39TFRubLinDsc;
         AV77Contabilidad_lineaswwds_17_tfrublindsc_sel = AV40TFRubLinDsc_Sel;
         AV78Contabilidad_lineaswwds_18_tfrublindsctot = AV41TFRubLinDscTot;
         AV79Contabilidad_lineaswwds_19_tfrublindsctot_sel = AV42TFRubLinDscTot_Sel;
         AV80Contabilidad_lineaswwds_20_tfrublinord = AV43TFRubLinOrd;
         AV81Contabilidad_lineaswwds_21_tfrublinord_to = AV44TFRubLinOrd_To;
         AV82Contabilidad_lineaswwds_22_tfrublinsts_sels = AV46TFRubLinSts_Sels;
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
            gxgrGrid_refresh( subGrid_Rows, AV15DynamicFiltersSelector1, AV55TotTipo1, AV19DynamicFiltersSelector2, AV56TotTipo2, AV23DynamicFiltersSelector3, AV57TotTipo3, AV60Pgmname, AV18DynamicFiltersEnabled2, AV22DynamicFiltersEnabled3, AV32TFTotTipo_Sels, AV33TFTotRub, AV34TFTotRub_To, AV35TFRubCod, AV36TFRubCod_To, AV37TFRubLinCod, AV38TFRubLinCod_To, AV39TFRubLinDsc, AV40TFRubLinDsc_Sel, AV41TFRubLinDscTot, AV42TFRubLinDscTot_Sel, AV43TFRubLinOrd, AV44TFRubLinOrd_To, AV46TFRubLinSts_Sels, AV13OrderedBy, AV14OrderedDsc, AV10GridState, AV27DynamicFiltersIgnoreFirst) ;
         }
         send_integrity_footer_hashes( ) ;
         return 0 ;
      }

      protected int subgrid_gotopage( int nPageNo )
      {
         AV61Contabilidad_lineaswwds_1_dynamicfiltersselector1 = AV15DynamicFiltersSelector1;
         AV62Contabilidad_lineaswwds_2_tottipo1 = AV55TotTipo1;
         AV63Contabilidad_lineaswwds_3_dynamicfiltersenabled2 = AV18DynamicFiltersEnabled2;
         AV64Contabilidad_lineaswwds_4_dynamicfiltersselector2 = AV19DynamicFiltersSelector2;
         AV65Contabilidad_lineaswwds_5_tottipo2 = AV56TotTipo2;
         AV66Contabilidad_lineaswwds_6_dynamicfiltersenabled3 = AV22DynamicFiltersEnabled3;
         AV67Contabilidad_lineaswwds_7_dynamicfiltersselector3 = AV23DynamicFiltersSelector3;
         AV68Contabilidad_lineaswwds_8_tottipo3 = AV57TotTipo3;
         AV69Contabilidad_lineaswwds_9_tftottipo_sels = AV32TFTotTipo_Sels;
         AV70Contabilidad_lineaswwds_10_tftotrub = AV33TFTotRub;
         AV71Contabilidad_lineaswwds_11_tftotrub_to = AV34TFTotRub_To;
         AV72Contabilidad_lineaswwds_12_tfrubcod = AV35TFRubCod;
         AV73Contabilidad_lineaswwds_13_tfrubcod_to = AV36TFRubCod_To;
         AV74Contabilidad_lineaswwds_14_tfrublincod = AV37TFRubLinCod;
         AV75Contabilidad_lineaswwds_15_tfrublincod_to = AV38TFRubLinCod_To;
         AV76Contabilidad_lineaswwds_16_tfrublindsc = AV39TFRubLinDsc;
         AV77Contabilidad_lineaswwds_17_tfrublindsc_sel = AV40TFRubLinDsc_Sel;
         AV78Contabilidad_lineaswwds_18_tfrublindsctot = AV41TFRubLinDscTot;
         AV79Contabilidad_lineaswwds_19_tfrublindsctot_sel = AV42TFRubLinDscTot_Sel;
         AV80Contabilidad_lineaswwds_20_tfrublinord = AV43TFRubLinOrd;
         AV81Contabilidad_lineaswwds_21_tfrublinord_to = AV44TFRubLinOrd_To;
         AV82Contabilidad_lineaswwds_22_tfrublinsts_sels = AV46TFRubLinSts_Sels;
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
            gxgrGrid_refresh( subGrid_Rows, AV15DynamicFiltersSelector1, AV55TotTipo1, AV19DynamicFiltersSelector2, AV56TotTipo2, AV23DynamicFiltersSelector3, AV57TotTipo3, AV60Pgmname, AV18DynamicFiltersEnabled2, AV22DynamicFiltersEnabled3, AV32TFTotTipo_Sels, AV33TFTotRub, AV34TFTotRub_To, AV35TFRubCod, AV36TFRubCod_To, AV37TFRubLinCod, AV38TFRubLinCod_To, AV39TFRubLinDsc, AV40TFRubLinDsc_Sel, AV41TFRubLinDscTot, AV42TFRubLinDscTot_Sel, AV43TFRubLinOrd, AV44TFRubLinOrd_To, AV46TFRubLinSts_Sels, AV13OrderedBy, AV14OrderedDsc, AV10GridState, AV27DynamicFiltersIgnoreFirst) ;
         }
         send_integrity_footer_hashes( ) ;
         return (int)(0) ;
      }

      protected void before_start_formulas( )
      {
         AV60Pgmname = "Contabilidad.LineasWW";
         context.Gx_err = 0;
         fix_multi_value_controls( ) ;
      }

      protected void STRUP2G0( )
      {
         /* Before Start, stand alone formulas. */
         before_start_formulas( ) ;
         /* Execute Start event if defined. */
         context.wbGlbDoneStart = 0;
         /* Execute user event: Start */
         E242G2 ();
         context.wbGlbDoneStart = 1;
         /* After Start, stand alone formulas. */
         if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
         {
            /* Read saved SDTs. */
            ajax_req_read_hidden_sdt(cgiGet( "vAGEXPORTDATA"), AV53AGExportData);
            ajax_req_read_hidden_sdt(cgiGet( "vDDO_TITLESETTINGSICONS"), AV47DDO_TitleSettingsIcons);
            /* Read saved values. */
            nRC_GXsfl_92 = (int)(context.localUtil.CToN( cgiGet( "nRC_GXsfl_92"), ".", ","));
            AV49GridCurrentPage = (long)(context.localUtil.CToN( cgiGet( "vGRIDCURRENTPAGE"), ".", ","));
            AV50GridPageCount = (long)(context.localUtil.CToN( cgiGet( "vGRIDPAGECOUNT"), ".", ","));
            AV51GridAppliedFilters = cgiGet( "vGRIDAPPLIEDFILTERS");
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
            Ddo_grid_Filteredtextto_get = cgiGet( "DDO_GRID_Filteredtextto_get");
            Ddo_grid_Filteredtext_get = cgiGet( "DDO_GRID_Filteredtext_get");
            Ddo_grid_Selectedcolumn = cgiGet( "DDO_GRID_Selectedcolumn");
            Ddo_agexport_Activeeventkey = cgiGet( "DDO_AGEXPORT_Activeeventkey");
            /* Read variables values. */
            cmbavDynamicfiltersselector1.Name = cmbavDynamicfiltersselector1_Internalname;
            cmbavDynamicfiltersselector1.CurrentValue = cgiGet( cmbavDynamicfiltersselector1_Internalname);
            AV15DynamicFiltersSelector1 = cgiGet( cmbavDynamicfiltersselector1_Internalname);
            AssignAttri("", false, "AV15DynamicFiltersSelector1", AV15DynamicFiltersSelector1);
            AV55TotTipo1 = cgiGet( edtavTottipo1_Internalname);
            AssignAttri("", false, "AV55TotTipo1", AV55TotTipo1);
            cmbavDynamicfiltersselector2.Name = cmbavDynamicfiltersselector2_Internalname;
            cmbavDynamicfiltersselector2.CurrentValue = cgiGet( cmbavDynamicfiltersselector2_Internalname);
            AV19DynamicFiltersSelector2 = cgiGet( cmbavDynamicfiltersselector2_Internalname);
            AssignAttri("", false, "AV19DynamicFiltersSelector2", AV19DynamicFiltersSelector2);
            AV56TotTipo2 = cgiGet( edtavTottipo2_Internalname);
            AssignAttri("", false, "AV56TotTipo2", AV56TotTipo2);
            cmbavDynamicfiltersselector3.Name = cmbavDynamicfiltersselector3_Internalname;
            cmbavDynamicfiltersselector3.CurrentValue = cgiGet( cmbavDynamicfiltersselector3_Internalname);
            AV23DynamicFiltersSelector3 = cgiGet( cmbavDynamicfiltersselector3_Internalname);
            AssignAttri("", false, "AV23DynamicFiltersSelector3", AV23DynamicFiltersSelector3);
            AV57TotTipo3 = cgiGet( edtavTottipo3_Internalname);
            AssignAttri("", false, "AV57TotTipo3", AV57TotTipo3);
            /* Read subfile selected row values. */
            /* Read hidden variables. */
            GXKey = Crypto.GetSiteKey( );
            /* Check if conditions changed and reset current page numbers */
            if ( StringUtil.StrCmp(cgiGet( "GXH_vDYNAMICFILTERSSELECTOR1"), AV15DynamicFiltersSelector1) != 0 )
            {
               GRID_nFirstRecordOnPage = 0;
            }
            if ( StringUtil.StrCmp(cgiGet( "GXH_vTOTTIPO1"), AV55TotTipo1) != 0 )
            {
               GRID_nFirstRecordOnPage = 0;
            }
            if ( StringUtil.StrCmp(cgiGet( "GXH_vDYNAMICFILTERSSELECTOR2"), AV19DynamicFiltersSelector2) != 0 )
            {
               GRID_nFirstRecordOnPage = 0;
            }
            if ( StringUtil.StrCmp(cgiGet( "GXH_vTOTTIPO2"), AV56TotTipo2) != 0 )
            {
               GRID_nFirstRecordOnPage = 0;
            }
            if ( StringUtil.StrCmp(cgiGet( "GXH_vDYNAMICFILTERSSELECTOR3"), AV23DynamicFiltersSelector3) != 0 )
            {
               GRID_nFirstRecordOnPage = 0;
            }
            if ( StringUtil.StrCmp(cgiGet( "GXH_vTOTTIPO3"), AV57TotTipo3) != 0 )
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
         E242G2 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
      }

      protected void E242G2( )
      {
         /* Start Routine */
         returnInSub = false;
         subGrid_Rows = 10;
         GxWebStd.gx_hidden_field( context, "GRID_Rows", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid_Rows), 6, 0, ".", "")));
         Grid_empowerer_Gridinternalname = subGrid_Internalname;
         ucGrid_empowerer.SendProperty(context, "", false, Grid_empowerer_Internalname, "GridInternalName", Grid_empowerer_Gridinternalname);
         lblJsdynamicfilters_Caption = "";
         AssignProp("", false, lblJsdynamicfilters_Internalname, "Caption", lblJsdynamicfilters_Caption, true);
         AV55TotTipo1 = "BAL";
         AssignAttri("", false, "AV55TotTipo1", AV55TotTipo1);
         AV15DynamicFiltersSelector1 = "TOTTIPO";
         AssignAttri("", false, "AV15DynamicFiltersSelector1", AV15DynamicFiltersSelector1);
         /* Execute user subroutine: 'ENABLEDYNAMICFILTERS1' */
         S112 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
         AV56TotTipo2 = "BAL";
         AssignAttri("", false, "AV56TotTipo2", AV56TotTipo2);
         AV19DynamicFiltersSelector2 = "TOTTIPO";
         AssignAttri("", false, "AV19DynamicFiltersSelector2", AV19DynamicFiltersSelector2);
         /* Execute user subroutine: 'ENABLEDYNAMICFILTERS2' */
         S122 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
         AV57TotTipo3 = "BAL";
         AssignAttri("", false, "AV57TotTipo3", AV57TotTipo3);
         AV23DynamicFiltersSelector3 = "TOTTIPO";
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
         AV53AGExportData = new GXBaseCollection<GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTDropDownOptionsData_Item>( context, "Item", "");
         AV54AGExportDataItem = new GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTDropDownOptionsData_Item(context);
         AV54AGExportDataItem.gxTpr_Title = "PDF";
         AV54AGExportDataItem.gxTpr_Icon = context.convertURL( (string)(context.GetImagePath( "776fb79c-a0a1-4302-b5e5-d773dbe1a297", "", context.GetTheme( ))));
         AV54AGExportDataItem.gxTpr_Eventkey = "ExportReport";
         AV54AGExportDataItem.gxTpr_Isdivider = false;
         AV53AGExportData.Add(AV54AGExportDataItem, 0);
         AV54AGExportDataItem = new GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTDropDownOptionsData_Item(context);
         AV54AGExportDataItem.gxTpr_Title = "Excel";
         AV54AGExportDataItem.gxTpr_Icon = context.convertURL( (string)(context.GetImagePath( "da69a816-fd11-445b-8aaf-1a2f7f1acc93", "", context.GetTheme( ))));
         AV54AGExportDataItem.gxTpr_Eventkey = "Export";
         AV54AGExportDataItem.gxTpr_Isdivider = false;
         AV53AGExportData.Add(AV54AGExportDataItem, 0);
         Ddo_grid_Gridinternalname = subGrid_Internalname;
         ucDdo_grid.SendProperty(context, "", false, Ddo_grid_Internalname, "GridInternalName", Ddo_grid_Gridinternalname);
         Form.Caption = " Lineas";
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
         GXt_SdtDVB_SDTDropDownOptionsTitleSettingsIcons1 = AV47DDO_TitleSettingsIcons;
         new GeneXus.Programs.wwpbaseobjects.getwwptitlesettingsicons(context ).execute( out  GXt_SdtDVB_SDTDropDownOptionsTitleSettingsIcons1) ;
         AV47DDO_TitleSettingsIcons = GXt_SdtDVB_SDTDropDownOptionsTitleSettingsIcons1;
         Gridpaginationbar_Rowsperpageselectedvalue = subGrid_Rows;
         ucGridpaginationbar.SendProperty(context, "", false, Gridpaginationbar_Internalname, "RowsPerPageSelectedValue", StringUtil.LTrimStr( (decimal)(Gridpaginationbar_Rowsperpageselectedvalue), 9, 0));
      }

      protected void E252G2( )
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
         AV49GridCurrentPage = subGrid_fnc_Currentpage( );
         AssignAttri("", false, "AV49GridCurrentPage", StringUtil.LTrimStr( (decimal)(AV49GridCurrentPage), 10, 0));
         AV50GridPageCount = subGrid_fnc_Pagecount( );
         AssignAttri("", false, "AV50GridPageCount", StringUtil.LTrimStr( (decimal)(AV50GridPageCount), 10, 0));
         GXt_char2 = AV51GridAppliedFilters;
         new GeneXus.Programs.wwpbaseobjects.wwp_getappliedfiltersdescription(context ).execute(  AV60Pgmname, out  GXt_char2) ;
         AV51GridAppliedFilters = GXt_char2;
         AssignAttri("", false, "AV51GridAppliedFilters", AV51GridAppliedFilters);
         AV61Contabilidad_lineaswwds_1_dynamicfiltersselector1 = AV15DynamicFiltersSelector1;
         AV62Contabilidad_lineaswwds_2_tottipo1 = AV55TotTipo1;
         AV63Contabilidad_lineaswwds_3_dynamicfiltersenabled2 = AV18DynamicFiltersEnabled2;
         AV64Contabilidad_lineaswwds_4_dynamicfiltersselector2 = AV19DynamicFiltersSelector2;
         AV65Contabilidad_lineaswwds_5_tottipo2 = AV56TotTipo2;
         AV66Contabilidad_lineaswwds_6_dynamicfiltersenabled3 = AV22DynamicFiltersEnabled3;
         AV67Contabilidad_lineaswwds_7_dynamicfiltersselector3 = AV23DynamicFiltersSelector3;
         AV68Contabilidad_lineaswwds_8_tottipo3 = AV57TotTipo3;
         AV69Contabilidad_lineaswwds_9_tftottipo_sels = AV32TFTotTipo_Sels;
         AV70Contabilidad_lineaswwds_10_tftotrub = AV33TFTotRub;
         AV71Contabilidad_lineaswwds_11_tftotrub_to = AV34TFTotRub_To;
         AV72Contabilidad_lineaswwds_12_tfrubcod = AV35TFRubCod;
         AV73Contabilidad_lineaswwds_13_tfrubcod_to = AV36TFRubCod_To;
         AV74Contabilidad_lineaswwds_14_tfrublincod = AV37TFRubLinCod;
         AV75Contabilidad_lineaswwds_15_tfrublincod_to = AV38TFRubLinCod_To;
         AV76Contabilidad_lineaswwds_16_tfrublindsc = AV39TFRubLinDsc;
         AV77Contabilidad_lineaswwds_17_tfrublindsc_sel = AV40TFRubLinDsc_Sel;
         AV78Contabilidad_lineaswwds_18_tfrublindsctot = AV41TFRubLinDscTot;
         AV79Contabilidad_lineaswwds_19_tfrublindsctot_sel = AV42TFRubLinDscTot_Sel;
         AV80Contabilidad_lineaswwds_20_tfrublinord = AV43TFRubLinOrd;
         AV81Contabilidad_lineaswwds_21_tfrublinord_to = AV44TFRubLinOrd_To;
         AV82Contabilidad_lineaswwds_22_tfrublinsts_sels = AV46TFRubLinSts_Sels;
         /*  Sending Event outputs  */
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV10GridState", AV10GridState);
      }

      protected void E112G2( )
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
            AV48PageToGo = (int)(NumberUtil.Val( Gridpaginationbar_Selectedpage, "."));
            subgrid_gotopage( AV48PageToGo) ;
         }
      }

      protected void E122G2( )
      {
         /* Gridpaginationbar_Changerowsperpage Routine */
         returnInSub = false;
         subGrid_Rows = Gridpaginationbar_Rowsperpageselectedvalue;
         GxWebStd.gx_hidden_field( context, "GRID_Rows", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid_Rows), 6, 0, ".", "")));
         subgrid_firstpage( ) ;
         /*  Sending Event outputs  */
      }

      protected void E142G2( )
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
            if ( StringUtil.StrCmp(Ddo_grid_Selectedcolumn, "TotTipo") == 0 )
            {
               AV31TFTotTipo_SelsJson = Ddo_grid_Selectedvalue_get;
               AssignAttri("", false, "AV31TFTotTipo_SelsJson", AV31TFTotTipo_SelsJson);
               AV32TFTotTipo_Sels.FromJSonString(AV31TFTotTipo_SelsJson, null);
            }
            else if ( StringUtil.StrCmp(Ddo_grid_Selectedcolumn, "TotRub") == 0 )
            {
               AV33TFTotRub = (int)(NumberUtil.Val( Ddo_grid_Filteredtext_get, "."));
               AssignAttri("", false, "AV33TFTotRub", StringUtil.LTrimStr( (decimal)(AV33TFTotRub), 6, 0));
               AV34TFTotRub_To = (int)(NumberUtil.Val( Ddo_grid_Filteredtextto_get, "."));
               AssignAttri("", false, "AV34TFTotRub_To", StringUtil.LTrimStr( (decimal)(AV34TFTotRub_To), 6, 0));
            }
            else if ( StringUtil.StrCmp(Ddo_grid_Selectedcolumn, "RubCod") == 0 )
            {
               AV35TFRubCod = (int)(NumberUtil.Val( Ddo_grid_Filteredtext_get, "."));
               AssignAttri("", false, "AV35TFRubCod", StringUtil.LTrimStr( (decimal)(AV35TFRubCod), 6, 0));
               AV36TFRubCod_To = (int)(NumberUtil.Val( Ddo_grid_Filteredtextto_get, "."));
               AssignAttri("", false, "AV36TFRubCod_To", StringUtil.LTrimStr( (decimal)(AV36TFRubCod_To), 6, 0));
            }
            else if ( StringUtil.StrCmp(Ddo_grid_Selectedcolumn, "RubLinCod") == 0 )
            {
               AV37TFRubLinCod = (int)(NumberUtil.Val( Ddo_grid_Filteredtext_get, "."));
               AssignAttri("", false, "AV37TFRubLinCod", StringUtil.LTrimStr( (decimal)(AV37TFRubLinCod), 6, 0));
               AV38TFRubLinCod_To = (int)(NumberUtil.Val( Ddo_grid_Filteredtextto_get, "."));
               AssignAttri("", false, "AV38TFRubLinCod_To", StringUtil.LTrimStr( (decimal)(AV38TFRubLinCod_To), 6, 0));
            }
            else if ( StringUtil.StrCmp(Ddo_grid_Selectedcolumn, "RubLinDsc") == 0 )
            {
               AV39TFRubLinDsc = Ddo_grid_Filteredtext_get;
               AssignAttri("", false, "AV39TFRubLinDsc", AV39TFRubLinDsc);
               AV40TFRubLinDsc_Sel = Ddo_grid_Selectedvalue_get;
               AssignAttri("", false, "AV40TFRubLinDsc_Sel", AV40TFRubLinDsc_Sel);
            }
            else if ( StringUtil.StrCmp(Ddo_grid_Selectedcolumn, "RubLinDscTot") == 0 )
            {
               AV41TFRubLinDscTot = Ddo_grid_Filteredtext_get;
               AssignAttri("", false, "AV41TFRubLinDscTot", AV41TFRubLinDscTot);
               AV42TFRubLinDscTot_Sel = Ddo_grid_Selectedvalue_get;
               AssignAttri("", false, "AV42TFRubLinDscTot_Sel", AV42TFRubLinDscTot_Sel);
            }
            else if ( StringUtil.StrCmp(Ddo_grid_Selectedcolumn, "RubLinOrd") == 0 )
            {
               AV43TFRubLinOrd = (short)(NumberUtil.Val( Ddo_grid_Filteredtext_get, "."));
               AssignAttri("", false, "AV43TFRubLinOrd", StringUtil.LTrimStr( (decimal)(AV43TFRubLinOrd), 2, 0));
               AV44TFRubLinOrd_To = (short)(NumberUtil.Val( Ddo_grid_Filteredtextto_get, "."));
               AssignAttri("", false, "AV44TFRubLinOrd_To", StringUtil.LTrimStr( (decimal)(AV44TFRubLinOrd_To), 2, 0));
            }
            else if ( StringUtil.StrCmp(Ddo_grid_Selectedcolumn, "RubLinSts") == 0 )
            {
               AV45TFRubLinSts_SelsJson = Ddo_grid_Selectedvalue_get;
               AssignAttri("", false, "AV45TFRubLinSts_SelsJson", AV45TFRubLinSts_SelsJson);
               AV46TFRubLinSts_Sels.FromJSonString(StringUtil.StringReplace( AV45TFRubLinSts_SelsJson, "\"", ""), null);
            }
            subgrid_firstpage( ) ;
         }
         /*  Sending Event outputs  */
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV46TFRubLinSts_Sels", AV46TFRubLinSts_Sels);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV32TFTotTipo_Sels", AV32TFTotTipo_Sels);
      }

      private void E262G2( )
      {
         /* Grid_Load Routine */
         returnInSub = false;
         cmbavGridactions.removeAllItems();
         cmbavGridactions.addItem("0", ";fa fa-bars", 0);
         cmbavGridactions.addItem("1", StringUtil.Format( "%1;%2", "Modificar", "fa fa-pen", "", "", "", "", "", "", ""), 0);
         cmbavGridactions.addItem("2", StringUtil.Format( "%1;%2", "Eliminar", "fa fa-times", "", "", "", "", "", "", ""), 0);
         GXKey = Crypto.GetSiteKey( );
         GXEncryptionTmp = "contabilidad.lineas.aspx"+UrlEncode(StringUtil.RTrim("DSP")) + "," + UrlEncode(StringUtil.RTrim(A114TotTipo)) + "," + UrlEncode(StringUtil.LTrimStr(A115TotRub,6,0)) + "," + UrlEncode(StringUtil.LTrimStr(A116RubCod,6,0)) + "," + UrlEncode(StringUtil.LTrimStr(A118RubLinCod,6,0));
         edtRubLinDsc_Link = formatLink("contabilidad.lineas.aspx") + "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey);
         /* Load Method */
         if ( wbStart != -1 )
         {
            wbStart = 92;
         }
         sendrow_922( ) ;
         GRID_nCurrentRecord = (long)(GRID_nCurrentRecord+1);
         if ( isFullAjaxMode( ) && ! bGXsfl_92_Refreshing )
         {
            DoAjaxLoad(92, GridRow);
         }
         /*  Sending Event outputs  */
         cmbavGridactions.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV52GridActions), 4, 0));
      }

      protected void E192G2( )
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

      protected void E152G2( )
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
         gxgrGrid_refresh( subGrid_Rows, AV15DynamicFiltersSelector1, AV55TotTipo1, AV19DynamicFiltersSelector2, AV56TotTipo2, AV23DynamicFiltersSelector3, AV57TotTipo3, AV60Pgmname, AV18DynamicFiltersEnabled2, AV22DynamicFiltersEnabled3, AV32TFTotTipo_Sels, AV33TFTotRub, AV34TFTotRub_To, AV35TFRubCod, AV36TFRubCod_To, AV37TFRubLinCod, AV38TFRubLinCod_To, AV39TFRubLinDsc, AV40TFRubLinDsc_Sel, AV41TFRubLinDscTot, AV42TFRubLinDscTot_Sel, AV43TFRubLinOrd, AV44TFRubLinOrd_To, AV46TFRubLinSts_Sels, AV13OrderedBy, AV14OrderedDsc, AV10GridState, AV27DynamicFiltersIgnoreFirst) ;
         /*  Sending Event outputs  */
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV10GridState", AV10GridState);
         cmbavDynamicfiltersselector2.CurrentValue = StringUtil.RTrim( AV19DynamicFiltersSelector2);
         AssignProp("", false, cmbavDynamicfiltersselector2_Internalname, "Values", cmbavDynamicfiltersselector2.ToJavascriptSource(), true);
         cmbavDynamicfiltersselector3.CurrentValue = StringUtil.RTrim( AV23DynamicFiltersSelector3);
         AssignProp("", false, cmbavDynamicfiltersselector3_Internalname, "Values", cmbavDynamicfiltersselector3.ToJavascriptSource(), true);
         cmbavDynamicfiltersselector1.CurrentValue = StringUtil.RTrim( AV15DynamicFiltersSelector1);
         AssignProp("", false, cmbavDynamicfiltersselector1_Internalname, "Values", cmbavDynamicfiltersselector1.ToJavascriptSource(), true);
      }

      protected void E202G2( )
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

      protected void E212G2( )
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

      protected void E162G2( )
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
         gxgrGrid_refresh( subGrid_Rows, AV15DynamicFiltersSelector1, AV55TotTipo1, AV19DynamicFiltersSelector2, AV56TotTipo2, AV23DynamicFiltersSelector3, AV57TotTipo3, AV60Pgmname, AV18DynamicFiltersEnabled2, AV22DynamicFiltersEnabled3, AV32TFTotTipo_Sels, AV33TFTotRub, AV34TFTotRub_To, AV35TFRubCod, AV36TFRubCod_To, AV37TFRubLinCod, AV38TFRubLinCod_To, AV39TFRubLinDsc, AV40TFRubLinDsc_Sel, AV41TFRubLinDscTot, AV42TFRubLinDscTot_Sel, AV43TFRubLinOrd, AV44TFRubLinOrd_To, AV46TFRubLinSts_Sels, AV13OrderedBy, AV14OrderedDsc, AV10GridState, AV27DynamicFiltersIgnoreFirst) ;
         /*  Sending Event outputs  */
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV10GridState", AV10GridState);
         cmbavDynamicfiltersselector2.CurrentValue = StringUtil.RTrim( AV19DynamicFiltersSelector2);
         AssignProp("", false, cmbavDynamicfiltersselector2_Internalname, "Values", cmbavDynamicfiltersselector2.ToJavascriptSource(), true);
         cmbavDynamicfiltersselector3.CurrentValue = StringUtil.RTrim( AV23DynamicFiltersSelector3);
         AssignProp("", false, cmbavDynamicfiltersselector3_Internalname, "Values", cmbavDynamicfiltersselector3.ToJavascriptSource(), true);
         cmbavDynamicfiltersselector1.CurrentValue = StringUtil.RTrim( AV15DynamicFiltersSelector1);
         AssignProp("", false, cmbavDynamicfiltersselector1_Internalname, "Values", cmbavDynamicfiltersselector1.ToJavascriptSource(), true);
      }

      protected void E222G2( )
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

      protected void E172G2( )
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
         gxgrGrid_refresh( subGrid_Rows, AV15DynamicFiltersSelector1, AV55TotTipo1, AV19DynamicFiltersSelector2, AV56TotTipo2, AV23DynamicFiltersSelector3, AV57TotTipo3, AV60Pgmname, AV18DynamicFiltersEnabled2, AV22DynamicFiltersEnabled3, AV32TFTotTipo_Sels, AV33TFTotRub, AV34TFTotRub_To, AV35TFRubCod, AV36TFRubCod_To, AV37TFRubLinCod, AV38TFRubLinCod_To, AV39TFRubLinDsc, AV40TFRubLinDsc_Sel, AV41TFRubLinDscTot, AV42TFRubLinDscTot_Sel, AV43TFRubLinOrd, AV44TFRubLinOrd_To, AV46TFRubLinSts_Sels, AV13OrderedBy, AV14OrderedDsc, AV10GridState, AV27DynamicFiltersIgnoreFirst) ;
         /*  Sending Event outputs  */
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV10GridState", AV10GridState);
         cmbavDynamicfiltersselector2.CurrentValue = StringUtil.RTrim( AV19DynamicFiltersSelector2);
         AssignProp("", false, cmbavDynamicfiltersselector2_Internalname, "Values", cmbavDynamicfiltersselector2.ToJavascriptSource(), true);
         cmbavDynamicfiltersselector3.CurrentValue = StringUtil.RTrim( AV23DynamicFiltersSelector3);
         AssignProp("", false, cmbavDynamicfiltersselector3_Internalname, "Values", cmbavDynamicfiltersselector3.ToJavascriptSource(), true);
         cmbavDynamicfiltersselector1.CurrentValue = StringUtil.RTrim( AV15DynamicFiltersSelector1);
         AssignProp("", false, cmbavDynamicfiltersselector1_Internalname, "Values", cmbavDynamicfiltersselector1.ToJavascriptSource(), true);
      }

      protected void E232G2( )
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

      protected void E272G2( )
      {
         /* Gridactions_Click Routine */
         returnInSub = false;
         if ( AV52GridActions == 1 )
         {
            /* Execute user subroutine: 'DO UPDATE' */
            S212 ();
            if ( returnInSub )
            {
               returnInSub = true;
               if (true) return;
            }
         }
         else if ( AV52GridActions == 2 )
         {
            /* Execute user subroutine: 'DO DELETE' */
            S222 ();
            if ( returnInSub )
            {
               returnInSub = true;
               if (true) return;
            }
         }
         AV52GridActions = 0;
         AssignAttri("", false, cmbavGridactions_Internalname, StringUtil.LTrimStr( (decimal)(AV52GridActions), 4, 0));
         /*  Sending Event outputs  */
         cmbavGridactions.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV52GridActions), 4, 0));
         AssignProp("", false, cmbavGridactions_Internalname, "Values", cmbavGridactions.ToJavascriptSource(), true);
      }

      protected void E182G2( )
      {
         /* 'DoInsert' Routine */
         returnInSub = false;
         GXKey = Crypto.GetSiteKey( );
         GXEncryptionTmp = "contabilidad.lineas.aspx"+UrlEncode(StringUtil.RTrim("INS")) + "," + UrlEncode(StringUtil.RTrim("")) + "," + UrlEncode(StringUtil.LTrimStr(0,1,0)) + "," + UrlEncode(StringUtil.LTrimStr(0,1,0)) + "," + UrlEncode(StringUtil.LTrimStr(0,1,0));
         CallWebObject(formatLink("contabilidad.lineas.aspx") + "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey));
         context.wjLocDisableFrm = 1;
      }

      protected void E132G2( )
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
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV46TFRubLinSts_Sels", AV46TFRubLinSts_Sels);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV32TFTotTipo_Sels", AV32TFTotTipo_Sels);
         cmbavDynamicfiltersselector1.CurrentValue = StringUtil.RTrim( AV15DynamicFiltersSelector1);
         AssignProp("", false, cmbavDynamicfiltersselector1_Internalname, "Values", cmbavDynamicfiltersselector1.ToJavascriptSource(), true);
         cmbavDynamicfiltersselector2.CurrentValue = StringUtil.RTrim( AV19DynamicFiltersSelector2);
         AssignProp("", false, cmbavDynamicfiltersselector2_Internalname, "Values", cmbavDynamicfiltersselector2.ToJavascriptSource(), true);
         cmbavDynamicfiltersselector3.CurrentValue = StringUtil.RTrim( AV23DynamicFiltersSelector3);
         AssignProp("", false, cmbavDynamicfiltersselector3_Internalname, "Values", cmbavDynamicfiltersselector3.ToJavascriptSource(), true);
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
         edtavTottipo1_Visible = 0;
         AssignProp("", false, edtavTottipo1_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavTottipo1_Visible), 5, 0), true);
         if ( StringUtil.StrCmp(AV15DynamicFiltersSelector1, "TOTTIPO") == 0 )
         {
            edtavTottipo1_Visible = 1;
            AssignProp("", false, edtavTottipo1_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavTottipo1_Visible), 5, 0), true);
         }
      }

      protected void S122( )
      {
         /* 'ENABLEDYNAMICFILTERS2' Routine */
         returnInSub = false;
         edtavTottipo2_Visible = 0;
         AssignProp("", false, edtavTottipo2_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavTottipo2_Visible), 5, 0), true);
         if ( StringUtil.StrCmp(AV19DynamicFiltersSelector2, "TOTTIPO") == 0 )
         {
            edtavTottipo2_Visible = 1;
            AssignProp("", false, edtavTottipo2_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavTottipo2_Visible), 5, 0), true);
         }
      }

      protected void S132( )
      {
         /* 'ENABLEDYNAMICFILTERS3' Routine */
         returnInSub = false;
         edtavTottipo3_Visible = 0;
         AssignProp("", false, edtavTottipo3_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavTottipo3_Visible), 5, 0), true);
         if ( StringUtil.StrCmp(AV23DynamicFiltersSelector3, "TOTTIPO") == 0 )
         {
            edtavTottipo3_Visible = 1;
            AssignProp("", false, edtavTottipo3_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavTottipo3_Visible), 5, 0), true);
         }
      }

      protected void S192( )
      {
         /* 'RESETDYNFILTERS' Routine */
         returnInSub = false;
         AV18DynamicFiltersEnabled2 = false;
         AssignAttri("", false, "AV18DynamicFiltersEnabled2", AV18DynamicFiltersEnabled2);
         AV19DynamicFiltersSelector2 = "TOTTIPO";
         AssignAttri("", false, "AV19DynamicFiltersSelector2", AV19DynamicFiltersSelector2);
         AV56TotTipo2 = "BAL";
         AssignAttri("", false, "AV56TotTipo2", AV56TotTipo2);
         /* Execute user subroutine: 'ENABLEDYNAMICFILTERS2' */
         S122 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
         AV22DynamicFiltersEnabled3 = false;
         AssignAttri("", false, "AV22DynamicFiltersEnabled3", AV22DynamicFiltersEnabled3);
         AV23DynamicFiltersSelector3 = "TOTTIPO";
         AssignAttri("", false, "AV23DynamicFiltersSelector3", AV23DynamicFiltersSelector3);
         AV57TotTipo3 = "BAL";
         AssignAttri("", false, "AV57TotTipo3", AV57TotTipo3);
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
         GXEncryptionTmp = "contabilidad.lineas.aspx"+UrlEncode(StringUtil.RTrim("UPD")) + "," + UrlEncode(StringUtil.RTrim(A114TotTipo)) + "," + UrlEncode(StringUtil.LTrimStr(A115TotRub,6,0)) + "," + UrlEncode(StringUtil.LTrimStr(A116RubCod,6,0)) + "," + UrlEncode(StringUtil.LTrimStr(A118RubLinCod,6,0));
         CallWebObject(formatLink("contabilidad.lineas.aspx") + "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey));
         context.wjLocDisableFrm = 1;
      }

      protected void S222( )
      {
         /* 'DO DELETE' Routine */
         returnInSub = false;
         GXKey = Crypto.GetSiteKey( );
         GXEncryptionTmp = "contabilidad.lineas.aspx"+UrlEncode(StringUtil.RTrim("DLT")) + "," + UrlEncode(StringUtil.RTrim(A114TotTipo)) + "," + UrlEncode(StringUtil.LTrimStr(A115TotRub,6,0)) + "," + UrlEncode(StringUtil.LTrimStr(A116RubCod,6,0)) + "," + UrlEncode(StringUtil.LTrimStr(A118RubLinCod,6,0));
         CallWebObject(formatLink("contabilidad.lineas.aspx") + "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey));
         context.wjLocDisableFrm = 1;
      }

      protected void S152( )
      {
         /* 'LOADGRIDSTATE' Routine */
         returnInSub = false;
         if ( StringUtil.StrCmp(AV30Session.Get(AV60Pgmname+"GridState"), "") == 0 )
         {
            AV10GridState.FromXml(new GeneXus.Programs.wwpbaseobjects.loadgridstate(context).executeUdp(  AV60Pgmname+"GridState"), null, "", "");
         }
         else
         {
            AV10GridState.FromXml(AV30Session.Get(AV60Pgmname+"GridState"), null, "", "");
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
         AV83GXV1 = 1;
         while ( AV83GXV1 <= AV10GridState.gxTpr_Filtervalues.Count )
         {
            AV11GridStateFilterValue = ((GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue)AV10GridState.gxTpr_Filtervalues.Item(AV83GXV1));
            if ( StringUtil.StrCmp(AV11GridStateFilterValue.gxTpr_Name, "TFTOTTIPO_SEL") == 0 )
            {
               AV31TFTotTipo_SelsJson = AV11GridStateFilterValue.gxTpr_Value;
               AssignAttri("", false, "AV31TFTotTipo_SelsJson", AV31TFTotTipo_SelsJson);
               AV32TFTotTipo_Sels.FromJSonString(AV31TFTotTipo_SelsJson, null);
            }
            else if ( StringUtil.StrCmp(AV11GridStateFilterValue.gxTpr_Name, "TFTOTRUB") == 0 )
            {
               AV33TFTotRub = (int)(NumberUtil.Val( AV11GridStateFilterValue.gxTpr_Value, "."));
               AssignAttri("", false, "AV33TFTotRub", StringUtil.LTrimStr( (decimal)(AV33TFTotRub), 6, 0));
               AV34TFTotRub_To = (int)(NumberUtil.Val( AV11GridStateFilterValue.gxTpr_Valueto, "."));
               AssignAttri("", false, "AV34TFTotRub_To", StringUtil.LTrimStr( (decimal)(AV34TFTotRub_To), 6, 0));
            }
            else if ( StringUtil.StrCmp(AV11GridStateFilterValue.gxTpr_Name, "TFRUBCOD") == 0 )
            {
               AV35TFRubCod = (int)(NumberUtil.Val( AV11GridStateFilterValue.gxTpr_Value, "."));
               AssignAttri("", false, "AV35TFRubCod", StringUtil.LTrimStr( (decimal)(AV35TFRubCod), 6, 0));
               AV36TFRubCod_To = (int)(NumberUtil.Val( AV11GridStateFilterValue.gxTpr_Valueto, "."));
               AssignAttri("", false, "AV36TFRubCod_To", StringUtil.LTrimStr( (decimal)(AV36TFRubCod_To), 6, 0));
            }
            else if ( StringUtil.StrCmp(AV11GridStateFilterValue.gxTpr_Name, "TFRUBLINCOD") == 0 )
            {
               AV37TFRubLinCod = (int)(NumberUtil.Val( AV11GridStateFilterValue.gxTpr_Value, "."));
               AssignAttri("", false, "AV37TFRubLinCod", StringUtil.LTrimStr( (decimal)(AV37TFRubLinCod), 6, 0));
               AV38TFRubLinCod_To = (int)(NumberUtil.Val( AV11GridStateFilterValue.gxTpr_Valueto, "."));
               AssignAttri("", false, "AV38TFRubLinCod_To", StringUtil.LTrimStr( (decimal)(AV38TFRubLinCod_To), 6, 0));
            }
            else if ( StringUtil.StrCmp(AV11GridStateFilterValue.gxTpr_Name, "TFRUBLINDSC") == 0 )
            {
               AV39TFRubLinDsc = AV11GridStateFilterValue.gxTpr_Value;
               AssignAttri("", false, "AV39TFRubLinDsc", AV39TFRubLinDsc);
            }
            else if ( StringUtil.StrCmp(AV11GridStateFilterValue.gxTpr_Name, "TFRUBLINDSC_SEL") == 0 )
            {
               AV40TFRubLinDsc_Sel = AV11GridStateFilterValue.gxTpr_Value;
               AssignAttri("", false, "AV40TFRubLinDsc_Sel", AV40TFRubLinDsc_Sel);
            }
            else if ( StringUtil.StrCmp(AV11GridStateFilterValue.gxTpr_Name, "TFRUBLINDSCTOT") == 0 )
            {
               AV41TFRubLinDscTot = AV11GridStateFilterValue.gxTpr_Value;
               AssignAttri("", false, "AV41TFRubLinDscTot", AV41TFRubLinDscTot);
            }
            else if ( StringUtil.StrCmp(AV11GridStateFilterValue.gxTpr_Name, "TFRUBLINDSCTOT_SEL") == 0 )
            {
               AV42TFRubLinDscTot_Sel = AV11GridStateFilterValue.gxTpr_Value;
               AssignAttri("", false, "AV42TFRubLinDscTot_Sel", AV42TFRubLinDscTot_Sel);
            }
            else if ( StringUtil.StrCmp(AV11GridStateFilterValue.gxTpr_Name, "TFRUBLINORD") == 0 )
            {
               AV43TFRubLinOrd = (short)(NumberUtil.Val( AV11GridStateFilterValue.gxTpr_Value, "."));
               AssignAttri("", false, "AV43TFRubLinOrd", StringUtil.LTrimStr( (decimal)(AV43TFRubLinOrd), 2, 0));
               AV44TFRubLinOrd_To = (short)(NumberUtil.Val( AV11GridStateFilterValue.gxTpr_Valueto, "."));
               AssignAttri("", false, "AV44TFRubLinOrd_To", StringUtil.LTrimStr( (decimal)(AV44TFRubLinOrd_To), 2, 0));
            }
            else if ( StringUtil.StrCmp(AV11GridStateFilterValue.gxTpr_Name, "TFRUBLINSTS_SEL") == 0 )
            {
               AV45TFRubLinSts_SelsJson = AV11GridStateFilterValue.gxTpr_Value;
               AssignAttri("", false, "AV45TFRubLinSts_SelsJson", AV45TFRubLinSts_SelsJson);
               AV46TFRubLinSts_Sels.FromJSonString(AV45TFRubLinSts_SelsJson, null);
            }
            AV83GXV1 = (int)(AV83GXV1+1);
         }
         GXt_char2 = "";
         new GeneXus.Programs.wwpbaseobjects.wwp_getfilterval(context ).execute(  (AV32TFTotTipo_Sels.Count==0),  AV31TFTotTipo_SelsJson, out  GXt_char2) ;
         GXt_char3 = "";
         new GeneXus.Programs.wwpbaseobjects.wwp_getfilterval(context ).execute(  String.IsNullOrEmpty(StringUtil.RTrim( AV40TFRubLinDsc_Sel)),  AV40TFRubLinDsc_Sel, out  GXt_char3) ;
         GXt_char4 = "";
         new GeneXus.Programs.wwpbaseobjects.wwp_getfilterval(context ).execute(  String.IsNullOrEmpty(StringUtil.RTrim( AV42TFRubLinDscTot_Sel)),  AV42TFRubLinDscTot_Sel, out  GXt_char4) ;
         Ddo_grid_Selectedvalue_set = GXt_char2+"||||"+GXt_char3+"|"+GXt_char4+"||"+((AV46TFRubLinSts_Sels.Count==0) ? "" : AV45TFRubLinSts_SelsJson);
         ucDdo_grid.SendProperty(context, "", false, Ddo_grid_Internalname, "SelectedValue_set", Ddo_grid_Selectedvalue_set);
         GXt_char4 = "";
         new GeneXus.Programs.wwpbaseobjects.wwp_getfilterval(context ).execute(  String.IsNullOrEmpty(StringUtil.RTrim( AV39TFRubLinDsc)),  AV39TFRubLinDsc, out  GXt_char4) ;
         GXt_char3 = "";
         new GeneXus.Programs.wwpbaseobjects.wwp_getfilterval(context ).execute(  String.IsNullOrEmpty(StringUtil.RTrim( AV41TFRubLinDscTot)),  AV41TFRubLinDscTot, out  GXt_char3) ;
         Ddo_grid_Filteredtext_set = "|"+((0==AV33TFTotRub) ? "" : StringUtil.Str( (decimal)(AV33TFTotRub), 6, 0))+"|"+((0==AV35TFRubCod) ? "" : StringUtil.Str( (decimal)(AV35TFRubCod), 6, 0))+"|"+((0==AV37TFRubLinCod) ? "" : StringUtil.Str( (decimal)(AV37TFRubLinCod), 6, 0))+"|"+GXt_char4+"|"+GXt_char3+"|"+((0==AV43TFRubLinOrd) ? "" : StringUtil.Str( (decimal)(AV43TFRubLinOrd), 2, 0))+"|";
         ucDdo_grid.SendProperty(context, "", false, Ddo_grid_Internalname, "FilteredText_set", Ddo_grid_Filteredtext_set);
         Ddo_grid_Filteredtextto_set = "|"+((0==AV34TFTotRub_To) ? "" : StringUtil.Str( (decimal)(AV34TFTotRub_To), 6, 0))+"|"+((0==AV36TFRubCod_To) ? "" : StringUtil.Str( (decimal)(AV36TFRubCod_To), 6, 0))+"|"+((0==AV38TFRubLinCod_To) ? "" : StringUtil.Str( (decimal)(AV38TFRubLinCod_To), 6, 0))+"|||"+((0==AV44TFRubLinOrd_To) ? "" : StringUtil.Str( (decimal)(AV44TFRubLinOrd_To), 2, 0))+"|";
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
            if ( StringUtil.StrCmp(AV15DynamicFiltersSelector1, "TOTTIPO") == 0 )
            {
               AV55TotTipo1 = AV12GridStateDynamicFilter.gxTpr_Value;
               AssignAttri("", false, "AV55TotTipo1", AV55TotTipo1);
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
               if ( StringUtil.StrCmp(AV19DynamicFiltersSelector2, "TOTTIPO") == 0 )
               {
                  AV56TotTipo2 = AV12GridStateDynamicFilter.gxTpr_Value;
                  AssignAttri("", false, "AV56TotTipo2", AV56TotTipo2);
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
                  if ( StringUtil.StrCmp(AV23DynamicFiltersSelector3, "TOTTIPO") == 0 )
                  {
                     AV57TotTipo3 = AV12GridStateDynamicFilter.gxTpr_Value;
                     AssignAttri("", false, "AV57TotTipo3", AV57TotTipo3);
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
         AV10GridState.FromXml(AV30Session.Get(AV60Pgmname+"GridState"), null, "", "");
         AV10GridState.gxTpr_Orderedby = AV13OrderedBy;
         AV10GridState.gxTpr_Ordereddsc = AV14OrderedDsc;
         AV10GridState.gxTpr_Filtervalues.Clear();
         new GeneXus.Programs.wwpbaseobjects.wwp_gridstateaddfiltervalue(context ).execute( ref  AV10GridState,  "TFTOTTIPO_SEL",  "Tipo de Reporte",  !(AV32TFTotTipo_Sels.Count==0),  0,  AV32TFTotTipo_Sels.ToJSonString(false),  "") ;
         new GeneXus.Programs.wwpbaseobjects.wwp_gridstateaddfiltervalue(context ).execute( ref  AV10GridState,  "TFTOTRUB",  "Codigo Rubro Totales",  !((0==AV33TFTotRub)&&(0==AV34TFTotRub_To)),  0,  StringUtil.Trim( StringUtil.Str( (decimal)(AV33TFTotRub), 6, 0)),  StringUtil.Trim( StringUtil.Str( (decimal)(AV34TFTotRub_To), 6, 0))) ;
         new GeneXus.Programs.wwpbaseobjects.wwp_gridstateaddfiltervalue(context ).execute( ref  AV10GridState,  "TFRUBCOD",  "Codigo Rubro",  !((0==AV35TFRubCod)&&(0==AV36TFRubCod_To)),  0,  StringUtil.Trim( StringUtil.Str( (decimal)(AV35TFRubCod), 6, 0)),  StringUtil.Trim( StringUtil.Str( (decimal)(AV36TFRubCod_To), 6, 0))) ;
         new GeneXus.Programs.wwpbaseobjects.wwp_gridstateaddfiltervalue(context ).execute( ref  AV10GridState,  "TFRUBLINCOD",  "Codigo Linea",  !((0==AV37TFRubLinCod)&&(0==AV38TFRubLinCod_To)),  0,  StringUtil.Trim( StringUtil.Str( (decimal)(AV37TFRubLinCod), 6, 0)),  StringUtil.Trim( StringUtil.Str( (decimal)(AV38TFRubLinCod_To), 6, 0))) ;
         new GeneXus.Programs.wwpbaseobjects.wwp_gridstateaddfiltervalueandsel(context ).execute( ref  AV10GridState,  "TFRUBLINDSC",  "Linea",  !String.IsNullOrEmpty(StringUtil.RTrim( AV39TFRubLinDsc)),  0,  AV39TFRubLinDsc,  "",  !String.IsNullOrEmpty(StringUtil.RTrim( AV40TFRubLinDsc_Sel)),  AV40TFRubLinDsc_Sel,  "") ;
         new GeneXus.Programs.wwpbaseobjects.wwp_gridstateaddfiltervalueandsel(context ).execute( ref  AV10GridState,  "TFRUBLINDSCTOT",  "Totales Linea",  !String.IsNullOrEmpty(StringUtil.RTrim( AV41TFRubLinDscTot)),  0,  AV41TFRubLinDscTot,  "",  !String.IsNullOrEmpty(StringUtil.RTrim( AV42TFRubLinDscTot_Sel)),  AV42TFRubLinDscTot_Sel,  "") ;
         new GeneXus.Programs.wwpbaseobjects.wwp_gridstateaddfiltervalue(context ).execute( ref  AV10GridState,  "TFRUBLINORD",  "N° Orden",  !((0==AV43TFRubLinOrd)&&(0==AV44TFRubLinOrd_To)),  0,  StringUtil.Trim( StringUtil.Str( (decimal)(AV43TFRubLinOrd), 2, 0)),  StringUtil.Trim( StringUtil.Str( (decimal)(AV44TFRubLinOrd_To), 2, 0))) ;
         new GeneXus.Programs.wwpbaseobjects.wwp_gridstateaddfiltervalue(context ).execute( ref  AV10GridState,  "TFRUBLINSTS_SEL",  "Estado",  !(AV46TFRubLinSts_Sels.Count==0),  0,  AV46TFRubLinSts_Sels.ToJSonString(false),  "") ;
         /* Execute user subroutine: 'SAVEDYNFILTERSSTATE' */
         S182 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
         AV10GridState.gxTpr_Pagesize = StringUtil.Str( (decimal)(subGrid_Rows), 10, 0);
         AV10GridState.gxTpr_Currentpage = (short)(subGrid_fnc_Currentpage( ));
         new GeneXus.Programs.wwpbaseobjects.savegridstate(context ).execute(  AV60Pgmname+"GridState",  AV10GridState.ToXml(false, true, "", "")) ;
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
            if ( StringUtil.StrCmp(AV15DynamicFiltersSelector1, "TOTTIPO") == 0 )
            {
               AV12GridStateDynamicFilter.gxTpr_Dsc = "Tipo de Reporte";
               AV12GridStateDynamicFilter.gxTpr_Value = AV55TotTipo1;
            }
            AV10GridState.gxTpr_Dynamicfilters.Add(AV12GridStateDynamicFilter, 0);
         }
         if ( AV18DynamicFiltersEnabled2 )
         {
            AV12GridStateDynamicFilter = new GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter(context);
            AV12GridStateDynamicFilter.gxTpr_Selected = AV19DynamicFiltersSelector2;
            if ( StringUtil.StrCmp(AV19DynamicFiltersSelector2, "TOTTIPO") == 0 )
            {
               AV12GridStateDynamicFilter.gxTpr_Dsc = "Tipo de Reporte";
               AV12GridStateDynamicFilter.gxTpr_Value = AV56TotTipo2;
            }
            AV10GridState.gxTpr_Dynamicfilters.Add(AV12GridStateDynamicFilter, 0);
         }
         if ( AV22DynamicFiltersEnabled3 )
         {
            AV12GridStateDynamicFilter = new GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter(context);
            AV12GridStateDynamicFilter.gxTpr_Selected = AV23DynamicFiltersSelector3;
            if ( StringUtil.StrCmp(AV23DynamicFiltersSelector3, "TOTTIPO") == 0 )
            {
               AV12GridStateDynamicFilter.gxTpr_Dsc = "Tipo de Reporte";
               AV12GridStateDynamicFilter.gxTpr_Value = AV57TotTipo3;
            }
            AV10GridState.gxTpr_Dynamicfilters.Add(AV12GridStateDynamicFilter, 0);
         }
      }

      protected void S142( )
      {
         /* 'PREPARETRANSACTION' Routine */
         returnInSub = false;
         AV8TrnContext = new GeneXus.Programs.wwpbaseobjects.SdtWWPTransactionContext(context);
         AV8TrnContext.gxTpr_Callerobject = AV60Pgmname;
         AV8TrnContext.gxTpr_Callerondelete = true;
         AV8TrnContext.gxTpr_Callerurl = AV7HTTPRequest.ScriptName+"?"+AV7HTTPRequest.QueryString;
         AV8TrnContext.gxTpr_Transactionname = "Contabilidad.Lineas";
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
         new GeneXus.Programs.contabilidad.lineaswwexport(context ).execute( out  AV28ExcelFilename, out  AV29ErrorMessage) ;
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
         Innewwindow1_Target = formatLink("contabilidad.lineaswwexportreport.aspx") ;
         ucInnewwindow1.SendProperty(context, "", false, Innewwindow1_Internalname, "Target", Innewwindow1_Target);
         Innewwindow1_Height = "600";
         ucInnewwindow1.SendProperty(context, "", false, Innewwindow1_Internalname, "Height", Innewwindow1_Height);
         Innewwindow1_Width = "800";
         ucInnewwindow1.SendProperty(context, "", false, Innewwindow1_Internalname, "Width", Innewwindow1_Width);
         this.executeUsercontrolMethod("", false, "INNEWWINDOW1Container", "OpenWindow", "", new Object[] {});
      }

      protected void wb_table1_25_2G2( bool wbgen )
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
            GxWebStd.gx_label_ctrl( context, lblDynamicfiltersprefix1_Internalname, "Buscar en", "", "", lblDynamicfiltersprefix1_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "DataFilterDescriptionPrefix", 0, "", 1, 1, 0, 0, "HLP_Contabilidad\\LineasWW.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "", "left", "top", "", "flex-grow:1;", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "left", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, cmbavDynamicfiltersselector1_Internalname, "Dynamic Filters Selector1", "gx-form-item AttributeLabel", 0, true, "width: 25%;");
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 35,'',false,'" + sGXsfl_92_idx + "',0)\"";
            /* ComboBox */
            GxWebStd.gx_combobox_ctrl1( context, cmbavDynamicfiltersselector1, cmbavDynamicfiltersselector1_Internalname, StringUtil.RTrim( AV15DynamicFiltersSelector1), 1, cmbavDynamicfiltersselector1_Jsonclick, 5, "'"+""+"'"+",false,"+"'"+"EVDYNAMICFILTERSSELECTOR1.CLICK."+"'", "svchar", "", 1, cmbavDynamicfiltersselector1.Enabled, 0, 0, 0, "em", 0, "", "", "Attribute", "", "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,35);\"", "", true, 1, "HLP_Contabilidad\\LineasWW.htm");
            cmbavDynamicfiltersselector1.CurrentValue = StringUtil.RTrim( AV15DynamicFiltersSelector1);
            AssignProp("", false, cmbavDynamicfiltersselector1_Internalname, "Values", (string)(cmbavDynamicfiltersselector1.ToJavascriptSource()), true);
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "", "left", "top", "", "flex-grow:1;", "div");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblDynamicfiltersmiddle1_Internalname, "valor", "", "", lblDynamicfiltersmiddle1_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "DataFilterDescription", 0, "", 1, 1, 0, 0, "HLP_Contabilidad\\LineasWW.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "", "left", "top", "", "flex-grow:1;", "div");
            wb_table2_39_2G2( true) ;
         }
         else
         {
            wb_table2_39_2G2( false) ;
         }
         return  ;
      }

      protected void wb_table2_39_2G2e( bool wbgen )
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
            GxWebStd.gx_label_ctrl( context, lblDynamicfiltersprefix2_Internalname, "Buscar en", "", "", lblDynamicfiltersprefix2_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "DataFilterDescriptionPrefix", 0, "", 1, 1, 0, 0, "HLP_Contabilidad\\LineasWW.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "Invisible", "left", "top", "", "flex-grow:1;", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "left", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, cmbavDynamicfiltersselector2_Internalname, "Dynamic Filters Selector2", "gx-form-item AttributeLabel", 0, true, "width: 25%;");
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 54,'',false,'" + sGXsfl_92_idx + "',0)\"";
            /* ComboBox */
            GxWebStd.gx_combobox_ctrl1( context, cmbavDynamicfiltersselector2, cmbavDynamicfiltersselector2_Internalname, StringUtil.RTrim( AV19DynamicFiltersSelector2), 1, cmbavDynamicfiltersselector2_Jsonclick, 5, "'"+""+"'"+",false,"+"'"+"EVDYNAMICFILTERSSELECTOR2.CLICK."+"'", "svchar", "", 1, cmbavDynamicfiltersselector2.Enabled, 0, 0, 0, "em", 0, "", "", "Attribute", "", "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,54);\"", "", true, 1, "HLP_Contabilidad\\LineasWW.htm");
            cmbavDynamicfiltersselector2.CurrentValue = StringUtil.RTrim( AV19DynamicFiltersSelector2);
            AssignProp("", false, cmbavDynamicfiltersselector2_Internalname, "Values", (string)(cmbavDynamicfiltersselector2.ToJavascriptSource()), true);
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "Invisible", "left", "top", "", "flex-grow:1;", "div");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblDynamicfiltersmiddle2_Internalname, "valor", "", "", lblDynamicfiltersmiddle2_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "DataFilterDescription", 0, "", 1, 1, 0, 0, "HLP_Contabilidad\\LineasWW.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "Invisible", "left", "top", "", "flex-grow:1;", "div");
            wb_table3_58_2G2( true) ;
         }
         else
         {
            wb_table3_58_2G2( false) ;
         }
         return  ;
      }

      protected void wb_table3_58_2G2e( bool wbgen )
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
            GxWebStd.gx_label_ctrl( context, lblDynamicfiltersprefix3_Internalname, "Buscar en", "", "", lblDynamicfiltersprefix3_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "DataFilterDescriptionPrefix", 0, "", 1, 1, 0, 0, "HLP_Contabilidad\\LineasWW.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "Invisible", "left", "top", "", "flex-grow:1;", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "left", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, cmbavDynamicfiltersselector3_Internalname, "Dynamic Filters Selector3", "gx-form-item AttributeLabel", 0, true, "width: 25%;");
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 73,'',false,'" + sGXsfl_92_idx + "',0)\"";
            /* ComboBox */
            GxWebStd.gx_combobox_ctrl1( context, cmbavDynamicfiltersselector3, cmbavDynamicfiltersselector3_Internalname, StringUtil.RTrim( AV23DynamicFiltersSelector3), 1, cmbavDynamicfiltersselector3_Jsonclick, 5, "'"+""+"'"+",false,"+"'"+"EVDYNAMICFILTERSSELECTOR3.CLICK."+"'", "svchar", "", 1, cmbavDynamicfiltersselector3.Enabled, 0, 0, 0, "em", 0, "", "", "Attribute", "", "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,73);\"", "", true, 1, "HLP_Contabilidad\\LineasWW.htm");
            cmbavDynamicfiltersselector3.CurrentValue = StringUtil.RTrim( AV23DynamicFiltersSelector3);
            AssignProp("", false, cmbavDynamicfiltersselector3_Internalname, "Values", (string)(cmbavDynamicfiltersselector3.ToJavascriptSource()), true);
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "Invisible", "left", "top", "", "flex-grow:1;", "div");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblDynamicfiltersmiddle3_Internalname, "valor", "", "", lblDynamicfiltersmiddle3_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "DataFilterDescription", 0, "", 1, 1, 0, 0, "HLP_Contabilidad\\LineasWW.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "Invisible", "left", "top", "", "flex-grow:1;", "div");
            wb_table4_77_2G2( true) ;
         }
         else
         {
            wb_table4_77_2G2( false) ;
         }
         return  ;
      }

      protected void wb_table4_77_2G2e( bool wbgen )
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
            wb_table1_25_2G2e( true) ;
         }
         else
         {
            wb_table1_25_2G2e( false) ;
         }
      }

      protected void wb_table4_77_2G2( bool wbgen )
      {
         if ( wbgen )
         {
            /* Table start */
            sStyleString = "";
            GxWebStd.gx_table_start( context, tblUnnamedtabledynamicfilters_3_Internalname, tblUnnamedtabledynamicfilters_3_Internalname, "", "Table", 0, "", "", 1, 2, sStyleString, "", "", 0);
            context.WriteHtmlText( "<tr>") ;
            context.WriteHtmlText( "<td id=\""+cellFilter_tottipo3_cell_Internalname+"\"  class=''>") ;
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "left", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavTottipo3_Internalname, "Tot Tipo3", "gx-form-item AttributeLabel", 0, true, "width: 25%;");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 81,'',false,'" + sGXsfl_92_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavTottipo3_Internalname, StringUtil.RTrim( AV57TotTipo3), StringUtil.RTrim( context.localUtil.Format( AV57TotTipo3, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,81);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavTottipo3_Jsonclick, 0, "Attribute", "", "", "", "", edtavTottipo3_Visible, edtavTottipo3_Enabled, 0, "text", "", 3, "chr", 1, "row", 3, 0, 0, 0, 1, -1, -1, true, "", "left", true, "", "HLP_Contabilidad\\LineasWW.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "<td id=\""+cellDynamicfilters_removefilter3_cell_Internalname+"\"  class=''>") ;
            /* Active images/pictures */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 83,'',false,'',0)\"";
            ClassString = "Image";
            StyleString = "";
            sImgUrl = (string)(context.GetImagePath( "11a6ef14-1a5a-4077-91a2-f41ed9a3a662", "", context.GetTheme( )));
            GxWebStd.gx_bitmap( context, imgRemovedynamicfilters3_Internalname, sImgUrl, "", "", "", context.GetTheme( ), 1, 1, "", "Quitar filtro", 0, 0, 0, "px", 0, "px", 0, 0, 5, imgRemovedynamicfilters3_Jsonclick, "'"+""+"'"+",false,"+"'"+"E\\'REMOVEDYNAMICFILTERS3\\'."+"'", StyleString, ClassString, "", "", "", "", " "+"data-gx-image"+" "+TempTags, "", "", 1, false, false, context.GetImageSrcSet( sImgUrl), "HLP_Contabilidad\\LineasWW.htm");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "</tr>") ;
            /* End of table */
            context.WriteHtmlText( "</table>") ;
            wb_table4_77_2G2e( true) ;
         }
         else
         {
            wb_table4_77_2G2e( false) ;
         }
      }

      protected void wb_table3_58_2G2( bool wbgen )
      {
         if ( wbgen )
         {
            /* Table start */
            sStyleString = "";
            GxWebStd.gx_table_start( context, tblUnnamedtabledynamicfilters_2_Internalname, tblUnnamedtabledynamicfilters_2_Internalname, "", "Table", 0, "", "", 1, 2, sStyleString, "", "", 0);
            context.WriteHtmlText( "<tr>") ;
            context.WriteHtmlText( "<td id=\""+cellFilter_tottipo2_cell_Internalname+"\"  class=''>") ;
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "left", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavTottipo2_Internalname, "Tot Tipo2", "gx-form-item AttributeLabel", 0, true, "width: 25%;");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 62,'',false,'" + sGXsfl_92_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavTottipo2_Internalname, StringUtil.RTrim( AV56TotTipo2), StringUtil.RTrim( context.localUtil.Format( AV56TotTipo2, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,62);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavTottipo2_Jsonclick, 0, "Attribute", "", "", "", "", edtavTottipo2_Visible, edtavTottipo2_Enabled, 0, "text", "", 3, "chr", 1, "row", 3, 0, 0, 0, 1, -1, -1, true, "", "left", true, "", "HLP_Contabilidad\\LineasWW.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "<td id=\""+cellDynamicfilters_addfilter2_cell_Internalname+"\"  class=''>") ;
            /* Active images/pictures */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 64,'',false,'',0)\"";
            ClassString = "Image";
            StyleString = "";
            sImgUrl = (string)(context.GetImagePath( "27283ea5-332f-423b-b880-64b762622df3", "", context.GetTheme( )));
            GxWebStd.gx_bitmap( context, imgAdddynamicfilters2_Internalname, sImgUrl, "", "", "", context.GetTheme( ), imgAdddynamicfilters2_Visible, 1, "", "Agregar filtro", 0, 0, 0, "px", 0, "px", 0, 0, 5, imgAdddynamicfilters2_Jsonclick, "'"+""+"'"+",false,"+"'"+"E\\'ADDDYNAMICFILTERS2\\'."+"'", StyleString, ClassString, "", "", "", "", " "+"data-gx-image"+" "+TempTags, "", "", 1, false, false, context.GetImageSrcSet( sImgUrl), "HLP_Contabilidad\\LineasWW.htm");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "<td id=\""+cellDynamicfilters_removefilter2_cell_Internalname+"\"  class=''>") ;
            /* Active images/pictures */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 66,'',false,'',0)\"";
            ClassString = "Image";
            StyleString = "";
            sImgUrl = (string)(context.GetImagePath( "11a6ef14-1a5a-4077-91a2-f41ed9a3a662", "", context.GetTheme( )));
            GxWebStd.gx_bitmap( context, imgRemovedynamicfilters2_Internalname, sImgUrl, "", "", "", context.GetTheme( ), imgRemovedynamicfilters2_Visible, 1, "", "Quitar filtro", 0, 0, 0, "px", 0, "px", 0, 0, 5, imgRemovedynamicfilters2_Jsonclick, "'"+""+"'"+",false,"+"'"+"E\\'REMOVEDYNAMICFILTERS2\\'."+"'", StyleString, ClassString, "", "", "", "", " "+"data-gx-image"+" "+TempTags, "", "", 1, false, false, context.GetImageSrcSet( sImgUrl), "HLP_Contabilidad\\LineasWW.htm");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "</tr>") ;
            /* End of table */
            context.WriteHtmlText( "</table>") ;
            wb_table3_58_2G2e( true) ;
         }
         else
         {
            wb_table3_58_2G2e( false) ;
         }
      }

      protected void wb_table2_39_2G2( bool wbgen )
      {
         if ( wbgen )
         {
            /* Table start */
            sStyleString = "";
            GxWebStd.gx_table_start( context, tblUnnamedtabledynamicfilters_1_Internalname, tblUnnamedtabledynamicfilters_1_Internalname, "", "Table", 0, "", "", 1, 2, sStyleString, "", "", 0);
            context.WriteHtmlText( "<tr>") ;
            context.WriteHtmlText( "<td id=\""+cellFilter_tottipo1_cell_Internalname+"\"  class=''>") ;
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "left", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavTottipo1_Internalname, "Tot Tipo1", "gx-form-item AttributeLabel", 0, true, "width: 25%;");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 43,'',false,'" + sGXsfl_92_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavTottipo1_Internalname, StringUtil.RTrim( AV55TotTipo1), StringUtil.RTrim( context.localUtil.Format( AV55TotTipo1, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,43);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavTottipo1_Jsonclick, 0, "Attribute", "", "", "", "", edtavTottipo1_Visible, edtavTottipo1_Enabled, 0, "text", "", 3, "chr", 1, "row", 3, 0, 0, 0, 1, -1, -1, true, "", "left", true, "", "HLP_Contabilidad\\LineasWW.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "<td id=\""+cellDynamicfilters_addfilter1_cell_Internalname+"\"  class=''>") ;
            /* Active images/pictures */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 45,'',false,'',0)\"";
            ClassString = "Image";
            StyleString = "";
            sImgUrl = (string)(context.GetImagePath( "27283ea5-332f-423b-b880-64b762622df3", "", context.GetTheme( )));
            GxWebStd.gx_bitmap( context, imgAdddynamicfilters1_Internalname, sImgUrl, "", "", "", context.GetTheme( ), imgAdddynamicfilters1_Visible, 1, "", "Agregar filtro", 0, 0, 0, "px", 0, "px", 0, 0, 5, imgAdddynamicfilters1_Jsonclick, "'"+""+"'"+",false,"+"'"+"E\\'ADDDYNAMICFILTERS1\\'."+"'", StyleString, ClassString, "", "", "", "", " "+"data-gx-image"+" "+TempTags, "", "", 1, false, false, context.GetImageSrcSet( sImgUrl), "HLP_Contabilidad\\LineasWW.htm");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "<td id=\""+cellDynamicfilters_removefilter1_cell_Internalname+"\"  class=''>") ;
            /* Active images/pictures */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 47,'',false,'',0)\"";
            ClassString = "Image";
            StyleString = "";
            sImgUrl = (string)(context.GetImagePath( "11a6ef14-1a5a-4077-91a2-f41ed9a3a662", "", context.GetTheme( )));
            GxWebStd.gx_bitmap( context, imgRemovedynamicfilters1_Internalname, sImgUrl, "", "", "", context.GetTheme( ), imgRemovedynamicfilters1_Visible, 1, "", "Quitar filtro", 0, 0, 0, "px", 0, "px", 0, 0, 5, imgRemovedynamicfilters1_Jsonclick, "'"+""+"'"+",false,"+"'"+"E\\'REMOVEDYNAMICFILTERS1\\'."+"'", StyleString, ClassString, "", "", "", "", " "+"data-gx-image"+" "+TempTags, "", "", 1, false, false, context.GetImageSrcSet( sImgUrl), "HLP_Contabilidad\\LineasWW.htm");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "</tr>") ;
            /* End of table */
            context.WriteHtmlText( "</table>") ;
            wb_table2_39_2G2e( true) ;
         }
         else
         {
            wb_table2_39_2G2e( false) ;
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
         PA2G2( ) ;
         WS2G2( ) ;
         WE2G2( ) ;
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
            context.AddJavascriptSource(StringUtil.RTrim( ((string)Form.Jscriptsrc.Item(idxLst))), "?202281810304170", true, true);
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
         context.AddJavascriptSource("contabilidad/lineasww.js", "?202281810304170", false, true);
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

      protected void SubsflControlProps_922( )
      {
         cmbavGridactions_Internalname = "vGRIDACTIONS_"+sGXsfl_92_idx;
         edtTotTipo_Internalname = "TOTTIPO_"+sGXsfl_92_idx;
         edtTotRub_Internalname = "TOTRUB_"+sGXsfl_92_idx;
         edtRubCod_Internalname = "RUBCOD_"+sGXsfl_92_idx;
         edtRubLinCod_Internalname = "RUBLINCOD_"+sGXsfl_92_idx;
         edtRubLinDsc_Internalname = "RUBLINDSC_"+sGXsfl_92_idx;
         edtRubLinDscTot_Internalname = "RUBLINDSCTOT_"+sGXsfl_92_idx;
         edtRubLinOrd_Internalname = "RUBLINORD_"+sGXsfl_92_idx;
         cmbRubLinSts_Internalname = "RUBLINSTS_"+sGXsfl_92_idx;
      }

      protected void SubsflControlProps_fel_922( )
      {
         cmbavGridactions_Internalname = "vGRIDACTIONS_"+sGXsfl_92_fel_idx;
         edtTotTipo_Internalname = "TOTTIPO_"+sGXsfl_92_fel_idx;
         edtTotRub_Internalname = "TOTRUB_"+sGXsfl_92_fel_idx;
         edtRubCod_Internalname = "RUBCOD_"+sGXsfl_92_fel_idx;
         edtRubLinCod_Internalname = "RUBLINCOD_"+sGXsfl_92_fel_idx;
         edtRubLinDsc_Internalname = "RUBLINDSC_"+sGXsfl_92_fel_idx;
         edtRubLinDscTot_Internalname = "RUBLINDSCTOT_"+sGXsfl_92_fel_idx;
         edtRubLinOrd_Internalname = "RUBLINORD_"+sGXsfl_92_fel_idx;
         cmbRubLinSts_Internalname = "RUBLINSTS_"+sGXsfl_92_fel_idx;
      }

      protected void sendrow_922( )
      {
         SubsflControlProps_922( ) ;
         WB2G0( ) ;
         if ( ( subGrid_Rows * 1 == 0 ) || ( nGXsfl_92_idx <= subGrid_fnc_Recordsperpage( ) * 1 ) )
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
               if ( ((int)((nGXsfl_92_idx) % (2))) == 0 )
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
               context.WriteHtmlText( " gxrow=\""+sGXsfl_92_idx+"\">") ;
            }
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"right"+"\""+" style=\""+""+"\">") ;
            }
            TempTags = " " + ((cmbavGridactions.Enabled!=0)&&(cmbavGridactions.Visible!=0) ? " onfocus=\"gx.evt.onfocus(this, 93,'',false,'"+sGXsfl_92_idx+"',92)\"" : " ");
            if ( ( cmbavGridactions.ItemCount == 0 ) && isAjaxCallMode( ) )
            {
               GXCCtl = "vGRIDACTIONS_" + sGXsfl_92_idx;
               cmbavGridactions.Name = GXCCtl;
               cmbavGridactions.WebTags = "";
               if ( cmbavGridactions.ItemCount > 0 )
               {
                  AV52GridActions = (short)(NumberUtil.Val( cmbavGridactions.getValidValue(StringUtil.Trim( StringUtil.Str( (decimal)(AV52GridActions), 4, 0))), "."));
                  AssignAttri("", false, cmbavGridactions_Internalname, StringUtil.LTrimStr( (decimal)(AV52GridActions), 4, 0));
               }
            }
            /* ComboBox */
            GridRow.AddColumnProperties("combobox", 2, isAjaxCallMode( ), new Object[] {(GXCombobox)cmbavGridactions,(string)cmbavGridactions_Internalname,StringUtil.Trim( StringUtil.Str( (decimal)(AV52GridActions), 4, 0)),(short)1,(string)cmbavGridactions_Jsonclick,(short)5,"'"+""+"'"+",false,"+"'"+"EVGRIDACTIONS.CLICK."+sGXsfl_92_idx+"'",(string)"int",(string)"",(short)-1,(short)1,(short)0,(short)0,(short)0,(string)"px",(short)0,(string)"px",(string)"",(string)"ConvertToDDO",(string)"WWActionGroupColumn",(string)"",TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+((cmbavGridactions.Enabled!=0)&&(cmbavGridactions.Visible!=0) ? " onblur=\""+""+";gx.evt.onblur(this,93);\"" : " "),(string)"",(bool)true,(short)1});
            cmbavGridactions.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV52GridActions), 4, 0));
            AssignProp("", false, cmbavGridactions_Internalname, "Values", (string)(cmbavGridactions.ToJavascriptSource()), !bGXsfl_92_Refreshing);
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"left"+"\""+" style=\""+""+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtTotTipo_Internalname,StringUtil.RTrim( A114TotTipo),(string)"",(string)"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtTotTipo_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn hidden-xs",(string)"",(short)-1,(short)0,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)3,(short)0,(short)0,(short)92,(short)1,(short)-1,(short)-1,(bool)true,(string)"",(string)"left",(bool)true,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"right"+"\""+" style=\""+""+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtTotRub_Internalname,StringUtil.LTrim( StringUtil.NToC( (decimal)(A115TotRub), 6, 0, ".", "")),StringUtil.LTrim( context.localUtil.Format( (decimal)(A115TotRub), "ZZZZZ9")),(string)" inputmode=\"numeric\" pattern=\"[0-9]*\""+"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtTotRub_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn hidden-xs",(string)"",(short)-1,(short)0,(short)0,(string)"text",(string)"1",(short)0,(string)"px",(short)17,(string)"px",(short)6,(short)0,(short)0,(short)92,(short)1,(short)-1,(short)0,(bool)true,(string)"",(string)"right",(bool)false,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"right"+"\""+" style=\""+""+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtRubCod_Internalname,StringUtil.LTrim( StringUtil.NToC( (decimal)(A116RubCod), 6, 0, ".", "")),StringUtil.LTrim( context.localUtil.Format( (decimal)(A116RubCod), "ZZZZZ9")),(string)" inputmode=\"numeric\" pattern=\"[0-9]*\""+"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtRubCod_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn hidden-xs",(string)"",(short)-1,(short)0,(short)0,(string)"text",(string)"1",(short)0,(string)"px",(short)17,(string)"px",(short)6,(short)0,(short)0,(short)92,(short)1,(short)-1,(short)0,(bool)true,(string)"",(string)"right",(bool)false,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"right"+"\""+" style=\""+""+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtRubLinCod_Internalname,StringUtil.LTrim( StringUtil.NToC( (decimal)(A118RubLinCod), 6, 0, ".", "")),StringUtil.LTrim( context.localUtil.Format( (decimal)(A118RubLinCod), "ZZZZZ9")),(string)" inputmode=\"numeric\" pattern=\"[0-9]*\""+"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtRubLinCod_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn hidden-xs",(string)"",(short)-1,(short)0,(short)0,(string)"text",(string)"1",(short)0,(string)"px",(short)17,(string)"px",(short)6,(short)0,(short)0,(short)92,(short)1,(short)-1,(short)0,(bool)true,(string)"",(string)"right",(bool)false,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"left"+"\""+" style=\""+""+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtRubLinDsc_Internalname,StringUtil.RTrim( A1826RubLinDsc),(string)"",(string)"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)edtRubLinDsc_Link,(string)"",(string)"",(string)"",(string)edtRubLinDsc_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn",(string)"",(short)-1,(short)0,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)100,(short)0,(short)0,(short)92,(short)1,(short)-1,(short)-1,(bool)true,(string)"",(string)"left",(bool)true,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"left"+"\""+" style=\""+""+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtRubLinDscTot_Internalname,StringUtil.RTrim( A1827RubLinDscTot),(string)"",(string)"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtRubLinDscTot_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn hidden-xs",(string)"",(short)-1,(short)0,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)100,(short)0,(short)0,(short)92,(short)1,(short)-1,(short)-1,(bool)true,(string)"",(string)"left",(bool)true,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"right"+"\""+" style=\""+""+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtRubLinOrd_Internalname,StringUtil.LTrim( StringUtil.NToC( (decimal)(A119RubLinOrd), 2, 0, ".", "")),StringUtil.LTrim( context.localUtil.Format( (decimal)(A119RubLinOrd), "Z9")),(string)" inputmode=\"numeric\" pattern=\"[0-9]*\""+"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtRubLinOrd_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn hidden-xs",(string)"",(short)-1,(short)0,(short)0,(string)"text",(string)"1",(short)0,(string)"px",(short)17,(string)"px",(short)2,(short)0,(short)0,(short)92,(short)1,(short)-1,(short)0,(bool)true,(string)"",(string)"right",(bool)false,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"right"+"\""+" style=\""+""+"\">") ;
            }
            if ( ( cmbRubLinSts.ItemCount == 0 ) && isAjaxCallMode( ) )
            {
               GXCCtl = "RUBLINSTS_" + sGXsfl_92_idx;
               cmbRubLinSts.Name = GXCCtl;
               cmbRubLinSts.WebTags = "";
               cmbRubLinSts.addItem("1", "ACTIVO", 0);
               cmbRubLinSts.addItem("0", "INACTIVO", 0);
               if ( cmbRubLinSts.ItemCount > 0 )
               {
                  A1828RubLinSts = (short)(NumberUtil.Val( cmbRubLinSts.getValidValue(StringUtil.Trim( StringUtil.Str( (decimal)(A1828RubLinSts), 1, 0))), "."));
               }
            }
            /* ComboBox */
            GridRow.AddColumnProperties("combobox", 2, isAjaxCallMode( ), new Object[] {(GXCombobox)cmbRubLinSts,(string)cmbRubLinSts_Internalname,StringUtil.Trim( StringUtil.Str( (decimal)(A1828RubLinSts), 1, 0)),(short)1,(string)cmbRubLinSts_Jsonclick,(short)0,(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"int",(string)"",(short)-1,(short)0,(short)0,(short)0,(short)0,(string)"px",(short)0,(string)"px",(string)"",(string)"Attribute",(string)"WWColumn hidden-xs",(string)"",(string)"",(string)"",(bool)true,(short)1});
            cmbRubLinSts.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(A1828RubLinSts), 1, 0));
            AssignProp("", false, cmbRubLinSts_Internalname, "Values", (string)(cmbRubLinSts.ToJavascriptSource()), !bGXsfl_92_Refreshing);
            send_integrity_lvl_hashes2G2( ) ;
            GridContainer.AddRow(GridRow);
            nGXsfl_92_idx = ((subGrid_Islastpage==1)&&(nGXsfl_92_idx+1>subGrid_fnc_Recordsperpage( )) ? 1 : nGXsfl_92_idx+1);
            sGXsfl_92_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_92_idx), 4, 0), 4, "0");
            SubsflControlProps_922( ) ;
         }
         /* End function sendrow_922 */
      }

      protected void init_web_controls( )
      {
         cmbavDynamicfiltersselector1.Name = "vDYNAMICFILTERSSELECTOR1";
         cmbavDynamicfiltersselector1.WebTags = "";
         cmbavDynamicfiltersselector1.addItem("TOTTIPO", "Tipo de Reporte", 0);
         if ( cmbavDynamicfiltersselector1.ItemCount > 0 )
         {
            AV15DynamicFiltersSelector1 = cmbavDynamicfiltersselector1.getValidValue(AV15DynamicFiltersSelector1);
            AssignAttri("", false, "AV15DynamicFiltersSelector1", AV15DynamicFiltersSelector1);
         }
         cmbavDynamicfiltersselector2.Name = "vDYNAMICFILTERSSELECTOR2";
         cmbavDynamicfiltersselector2.WebTags = "";
         cmbavDynamicfiltersselector2.addItem("TOTTIPO", "Tipo de Reporte", 0);
         if ( cmbavDynamicfiltersselector2.ItemCount > 0 )
         {
            AV19DynamicFiltersSelector2 = cmbavDynamicfiltersselector2.getValidValue(AV19DynamicFiltersSelector2);
            AssignAttri("", false, "AV19DynamicFiltersSelector2", AV19DynamicFiltersSelector2);
         }
         cmbavDynamicfiltersselector3.Name = "vDYNAMICFILTERSSELECTOR3";
         cmbavDynamicfiltersselector3.WebTags = "";
         cmbavDynamicfiltersselector3.addItem("TOTTIPO", "Tipo de Reporte", 0);
         if ( cmbavDynamicfiltersselector3.ItemCount > 0 )
         {
            AV23DynamicFiltersSelector3 = cmbavDynamicfiltersselector3.getValidValue(AV23DynamicFiltersSelector3);
            AssignAttri("", false, "AV23DynamicFiltersSelector3", AV23DynamicFiltersSelector3);
         }
         GXCCtl = "vGRIDACTIONS_" + sGXsfl_92_idx;
         cmbavGridactions.Name = GXCCtl;
         cmbavGridactions.WebTags = "";
         if ( cmbavGridactions.ItemCount > 0 )
         {
            AV52GridActions = (short)(NumberUtil.Val( cmbavGridactions.getValidValue(StringUtil.Trim( StringUtil.Str( (decimal)(AV52GridActions), 4, 0))), "."));
            AssignAttri("", false, cmbavGridactions_Internalname, StringUtil.LTrimStr( (decimal)(AV52GridActions), 4, 0));
         }
         GXCCtl = "RUBLINSTS_" + sGXsfl_92_idx;
         cmbRubLinSts.Name = GXCCtl;
         cmbRubLinSts.WebTags = "";
         cmbRubLinSts.addItem("1", "ACTIVO", 0);
         cmbRubLinSts.addItem("0", "INACTIVO", 0);
         if ( cmbRubLinSts.ItemCount > 0 )
         {
            A1828RubLinSts = (short)(NumberUtil.Val( cmbRubLinSts.getValidValue(StringUtil.Trim( StringUtil.Str( (decimal)(A1828RubLinSts), 1, 0))), "."));
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
         edtavTottipo1_Internalname = "vTOTTIPO1";
         cellFilter_tottipo1_cell_Internalname = "FILTER_TOTTIPO1_CELL";
         imgAdddynamicfilters1_Internalname = "ADDDYNAMICFILTERS1";
         cellDynamicfilters_addfilter1_cell_Internalname = "DYNAMICFILTERS_ADDFILTER1_CELL";
         imgRemovedynamicfilters1_Internalname = "REMOVEDYNAMICFILTERS1";
         cellDynamicfilters_removefilter1_cell_Internalname = "DYNAMICFILTERS_REMOVEFILTER1_CELL";
         tblUnnamedtabledynamicfilters_1_Internalname = "UNNAMEDTABLEDYNAMICFILTERS_1";
         divTabledynamicfiltersrow1_Internalname = "TABLEDYNAMICFILTERSROW1";
         lblDynamicfiltersprefix2_Internalname = "DYNAMICFILTERSPREFIX2";
         cmbavDynamicfiltersselector2_Internalname = "vDYNAMICFILTERSSELECTOR2";
         lblDynamicfiltersmiddle2_Internalname = "DYNAMICFILTERSMIDDLE2";
         edtavTottipo2_Internalname = "vTOTTIPO2";
         cellFilter_tottipo2_cell_Internalname = "FILTER_TOTTIPO2_CELL";
         imgAdddynamicfilters2_Internalname = "ADDDYNAMICFILTERS2";
         cellDynamicfilters_addfilter2_cell_Internalname = "DYNAMICFILTERS_ADDFILTER2_CELL";
         imgRemovedynamicfilters2_Internalname = "REMOVEDYNAMICFILTERS2";
         cellDynamicfilters_removefilter2_cell_Internalname = "DYNAMICFILTERS_REMOVEFILTER2_CELL";
         tblUnnamedtabledynamicfilters_2_Internalname = "UNNAMEDTABLEDYNAMICFILTERS_2";
         divTabledynamicfiltersrow2_Internalname = "TABLEDYNAMICFILTERSROW2";
         lblDynamicfiltersprefix3_Internalname = "DYNAMICFILTERSPREFIX3";
         cmbavDynamicfiltersselector3_Internalname = "vDYNAMICFILTERSSELECTOR3";
         lblDynamicfiltersmiddle3_Internalname = "DYNAMICFILTERSMIDDLE3";
         edtavTottipo3_Internalname = "vTOTTIPO3";
         cellFilter_tottipo3_cell_Internalname = "FILTER_TOTTIPO3_CELL";
         imgRemovedynamicfilters3_Internalname = "REMOVEDYNAMICFILTERS3";
         cellDynamicfilters_removefilter3_cell_Internalname = "DYNAMICFILTERS_REMOVEFILTER3_CELL";
         tblUnnamedtabledynamicfilters_3_Internalname = "UNNAMEDTABLEDYNAMICFILTERS_3";
         divTabledynamicfiltersrow3_Internalname = "TABLEDYNAMICFILTERSROW3";
         divTabledynamicfilters_Internalname = "TABLEDYNAMICFILTERS";
         tblTablefilters_Internalname = "TABLEFILTERS";
         divTablerightheader_Internalname = "TABLERIGHTHEADER";
         divTableheadercontent_Internalname = "TABLEHEADERCONTENT";
         divTableheader_Internalname = "TABLEHEADER";
         Dvpanel_tableheader_Internalname = "DVPANEL_TABLEHEADER";
         cmbavGridactions_Internalname = "vGRIDACTIONS";
         edtTotTipo_Internalname = "TOTTIPO";
         edtTotRub_Internalname = "TOTRUB";
         edtRubCod_Internalname = "RUBCOD";
         edtRubLinCod_Internalname = "RUBLINCOD";
         edtRubLinDsc_Internalname = "RUBLINDSC";
         edtRubLinDscTot_Internalname = "RUBLINDSCTOT";
         edtRubLinOrd_Internalname = "RUBLINORD";
         cmbRubLinSts_Internalname = "RUBLINSTS";
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
         cmbRubLinSts_Jsonclick = "";
         edtRubLinOrd_Jsonclick = "";
         edtRubLinDscTot_Jsonclick = "";
         edtRubLinDsc_Jsonclick = "";
         edtRubLinCod_Jsonclick = "";
         edtRubCod_Jsonclick = "";
         edtTotRub_Jsonclick = "";
         edtTotTipo_Jsonclick = "";
         cmbavGridactions_Jsonclick = "";
         cmbavGridactions.Visible = -1;
         cmbavGridactions.Enabled = 1;
         imgRemovedynamicfilters1_Visible = 1;
         imgAdddynamicfilters1_Visible = 1;
         edtavTottipo1_Jsonclick = "";
         edtavTottipo1_Enabled = 1;
         imgRemovedynamicfilters2_Visible = 1;
         imgAdddynamicfilters2_Visible = 1;
         edtavTottipo2_Jsonclick = "";
         edtavTottipo2_Enabled = 1;
         edtavTottipo3_Jsonclick = "";
         edtavTottipo3_Enabled = 1;
         cmbavDynamicfiltersselector3_Jsonclick = "";
         cmbavDynamicfiltersselector3.Enabled = 1;
         cmbavDynamicfiltersselector2_Jsonclick = "";
         cmbavDynamicfiltersselector2.Enabled = 1;
         cmbavDynamicfiltersselector1_Jsonclick = "";
         cmbavDynamicfiltersselector1.Enabled = 1;
         edtavTottipo3_Visible = 1;
         edtavTottipo2_Visible = 1;
         edtavTottipo1_Visible = 1;
         lblJsdynamicfilters_Caption = "JSDynamicFilters";
         subGrid_Allowcollapsing = 0;
         subGrid_Allowselection = 0;
         edtRubLinDsc_Link = "";
         subGrid_Sortable = 0;
         subGrid_Header = "";
         subGrid_Class = "GridWithPaginationBar WorkWith";
         subGrid_Backcolorstyle = 0;
         Grid_empowerer_Hastitlesettings = Convert.ToBoolean( -1);
         Innewwindow1_Target = "";
         Innewwindow1_Height = "50";
         Innewwindow1_Width = "50";
         Ddo_grid_Datalistproc = "Contabilidad.LineasWWGetFilterData";
         Ddo_grid_Datalistfixedvalues = "BAL:Estado de Situación Financiera,FUN:Estado de Resultados Integrales,NAT:Estado de Ganancia y Perdidad,COS:Registro de Costos,RCC:Registro de Costos / Centro de Costos|||||||1:ACTIVO,0:INACTIVO";
         Ddo_grid_Allowmultipleselection = "T|||||||T";
         Ddo_grid_Datalisttype = "FixedValues||||Dynamic|Dynamic||FixedValues";
         Ddo_grid_Includedatalist = "T||||T|T||T";
         Ddo_grid_Filterisrange = "|T|T|T|||T|";
         Ddo_grid_Filtertype = "|Numeric|Numeric|Numeric|Character|Character|Numeric|";
         Ddo_grid_Includefilter = "|T|T|T|T|T|T|";
         Ddo_grid_Includesortasc = "T";
         Ddo_grid_Columnssortvalues = "2|3|4|5|6|7|8|9";
         Ddo_grid_Columnids = "1:TotTipo|2:TotRub|3:RubCod|4:RubLinCod|5:RubLinDsc|6:RubLinDscTot|7:RubLinOrd|8:RubLinSts";
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
         Form.Caption = " Lineas";
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
         setEventMetadata("REFRESH","{handler:'Refresh',iparms:[{av:'GRID_nFirstRecordOnPage'},{av:'GRID_nEOF'},{av:'subGrid_Rows',ctrl:'GRID',prop:'Rows'},{av:'cmbavDynamicfiltersselector1'},{av:'AV15DynamicFiltersSelector1',fld:'vDYNAMICFILTERSSELECTOR1',pic:''},{av:'AV55TotTipo1',fld:'vTOTTIPO1',pic:''},{av:'cmbavDynamicfiltersselector2'},{av:'AV19DynamicFiltersSelector2',fld:'vDYNAMICFILTERSSELECTOR2',pic:''},{av:'AV56TotTipo2',fld:'vTOTTIPO2',pic:''},{av:'cmbavDynamicfiltersselector3'},{av:'AV23DynamicFiltersSelector3',fld:'vDYNAMICFILTERSSELECTOR3',pic:''},{av:'AV57TotTipo3',fld:'vTOTTIPO3',pic:''},{av:'AV60Pgmname',fld:'vPGMNAME',pic:'',hsh:true},{av:'AV18DynamicFiltersEnabled2',fld:'vDYNAMICFILTERSENABLED2',pic:''},{av:'AV22DynamicFiltersEnabled3',fld:'vDYNAMICFILTERSENABLED3',pic:''},{av:'AV32TFTotTipo_Sels',fld:'vTFTOTTIPO_SELS',pic:''},{av:'AV33TFTotRub',fld:'vTFTOTRUB',pic:'ZZZZZ9'},{av:'AV34TFTotRub_To',fld:'vTFTOTRUB_TO',pic:'ZZZZZ9'},{av:'AV35TFRubCod',fld:'vTFRUBCOD',pic:'ZZZZZ9'},{av:'AV36TFRubCod_To',fld:'vTFRUBCOD_TO',pic:'ZZZZZ9'},{av:'AV37TFRubLinCod',fld:'vTFRUBLINCOD',pic:'ZZZZZ9'},{av:'AV38TFRubLinCod_To',fld:'vTFRUBLINCOD_TO',pic:'ZZZZZ9'},{av:'AV39TFRubLinDsc',fld:'vTFRUBLINDSC',pic:''},{av:'AV40TFRubLinDsc_Sel',fld:'vTFRUBLINDSC_SEL',pic:''},{av:'AV41TFRubLinDscTot',fld:'vTFRUBLINDSCTOT',pic:''},{av:'AV42TFRubLinDscTot_Sel',fld:'vTFRUBLINDSCTOT_SEL',pic:''},{av:'AV43TFRubLinOrd',fld:'vTFRUBLINORD',pic:'Z9'},{av:'AV44TFRubLinOrd_To',fld:'vTFRUBLINORD_TO',pic:'Z9'},{av:'AV46TFRubLinSts_Sels',fld:'vTFRUBLINSTS_SELS',pic:''},{av:'AV13OrderedBy',fld:'vORDEREDBY',pic:'ZZZ9'},{av:'AV14OrderedDsc',fld:'vORDEREDDSC',pic:''},{av:'AV10GridState',fld:'vGRIDSTATE',pic:''},{av:'AV27DynamicFiltersIgnoreFirst',fld:'vDYNAMICFILTERSIGNOREFIRST',pic:''}]");
         setEventMetadata("REFRESH",",oparms:[{av:'AV49GridCurrentPage',fld:'vGRIDCURRENTPAGE',pic:'ZZZZZZZZZ9'},{av:'AV50GridPageCount',fld:'vGRIDPAGECOUNT',pic:'ZZZZZZZZZ9'},{av:'AV51GridAppliedFilters',fld:'vGRIDAPPLIEDFILTERS',pic:''},{av:'AV10GridState',fld:'vGRIDSTATE',pic:''}]}");
         setEventMetadata("GRIDPAGINATIONBAR.CHANGEPAGE","{handler:'E112G2',iparms:[{av:'GRID_nFirstRecordOnPage'},{av:'GRID_nEOF'},{av:'subGrid_Rows',ctrl:'GRID',prop:'Rows'},{av:'cmbavDynamicfiltersselector1'},{av:'AV15DynamicFiltersSelector1',fld:'vDYNAMICFILTERSSELECTOR1',pic:''},{av:'AV55TotTipo1',fld:'vTOTTIPO1',pic:''},{av:'cmbavDynamicfiltersselector2'},{av:'AV19DynamicFiltersSelector2',fld:'vDYNAMICFILTERSSELECTOR2',pic:''},{av:'AV56TotTipo2',fld:'vTOTTIPO2',pic:''},{av:'cmbavDynamicfiltersselector3'},{av:'AV23DynamicFiltersSelector3',fld:'vDYNAMICFILTERSSELECTOR3',pic:''},{av:'AV57TotTipo3',fld:'vTOTTIPO3',pic:''},{av:'AV60Pgmname',fld:'vPGMNAME',pic:'',hsh:true},{av:'AV18DynamicFiltersEnabled2',fld:'vDYNAMICFILTERSENABLED2',pic:''},{av:'AV22DynamicFiltersEnabled3',fld:'vDYNAMICFILTERSENABLED3',pic:''},{av:'AV32TFTotTipo_Sels',fld:'vTFTOTTIPO_SELS',pic:''},{av:'AV33TFTotRub',fld:'vTFTOTRUB',pic:'ZZZZZ9'},{av:'AV34TFTotRub_To',fld:'vTFTOTRUB_TO',pic:'ZZZZZ9'},{av:'AV35TFRubCod',fld:'vTFRUBCOD',pic:'ZZZZZ9'},{av:'AV36TFRubCod_To',fld:'vTFRUBCOD_TO',pic:'ZZZZZ9'},{av:'AV37TFRubLinCod',fld:'vTFRUBLINCOD',pic:'ZZZZZ9'},{av:'AV38TFRubLinCod_To',fld:'vTFRUBLINCOD_TO',pic:'ZZZZZ9'},{av:'AV39TFRubLinDsc',fld:'vTFRUBLINDSC',pic:''},{av:'AV40TFRubLinDsc_Sel',fld:'vTFRUBLINDSC_SEL',pic:''},{av:'AV41TFRubLinDscTot',fld:'vTFRUBLINDSCTOT',pic:''},{av:'AV42TFRubLinDscTot_Sel',fld:'vTFRUBLINDSCTOT_SEL',pic:''},{av:'AV43TFRubLinOrd',fld:'vTFRUBLINORD',pic:'Z9'},{av:'AV44TFRubLinOrd_To',fld:'vTFRUBLINORD_TO',pic:'Z9'},{av:'AV46TFRubLinSts_Sels',fld:'vTFRUBLINSTS_SELS',pic:''},{av:'AV13OrderedBy',fld:'vORDEREDBY',pic:'ZZZ9'},{av:'AV14OrderedDsc',fld:'vORDEREDDSC',pic:''},{av:'AV10GridState',fld:'vGRIDSTATE',pic:''},{av:'AV27DynamicFiltersIgnoreFirst',fld:'vDYNAMICFILTERSIGNOREFIRST',pic:''},{av:'Gridpaginationbar_Selectedpage',ctrl:'GRIDPAGINATIONBAR',prop:'SelectedPage'}]");
         setEventMetadata("GRIDPAGINATIONBAR.CHANGEPAGE",",oparms:[]}");
         setEventMetadata("GRIDPAGINATIONBAR.CHANGEROWSPERPAGE","{handler:'E122G2',iparms:[{av:'GRID_nFirstRecordOnPage'},{av:'GRID_nEOF'},{av:'subGrid_Rows',ctrl:'GRID',prop:'Rows'},{av:'cmbavDynamicfiltersselector1'},{av:'AV15DynamicFiltersSelector1',fld:'vDYNAMICFILTERSSELECTOR1',pic:''},{av:'AV55TotTipo1',fld:'vTOTTIPO1',pic:''},{av:'cmbavDynamicfiltersselector2'},{av:'AV19DynamicFiltersSelector2',fld:'vDYNAMICFILTERSSELECTOR2',pic:''},{av:'AV56TotTipo2',fld:'vTOTTIPO2',pic:''},{av:'cmbavDynamicfiltersselector3'},{av:'AV23DynamicFiltersSelector3',fld:'vDYNAMICFILTERSSELECTOR3',pic:''},{av:'AV57TotTipo3',fld:'vTOTTIPO3',pic:''},{av:'AV60Pgmname',fld:'vPGMNAME',pic:'',hsh:true},{av:'AV18DynamicFiltersEnabled2',fld:'vDYNAMICFILTERSENABLED2',pic:''},{av:'AV22DynamicFiltersEnabled3',fld:'vDYNAMICFILTERSENABLED3',pic:''},{av:'AV32TFTotTipo_Sels',fld:'vTFTOTTIPO_SELS',pic:''},{av:'AV33TFTotRub',fld:'vTFTOTRUB',pic:'ZZZZZ9'},{av:'AV34TFTotRub_To',fld:'vTFTOTRUB_TO',pic:'ZZZZZ9'},{av:'AV35TFRubCod',fld:'vTFRUBCOD',pic:'ZZZZZ9'},{av:'AV36TFRubCod_To',fld:'vTFRUBCOD_TO',pic:'ZZZZZ9'},{av:'AV37TFRubLinCod',fld:'vTFRUBLINCOD',pic:'ZZZZZ9'},{av:'AV38TFRubLinCod_To',fld:'vTFRUBLINCOD_TO',pic:'ZZZZZ9'},{av:'AV39TFRubLinDsc',fld:'vTFRUBLINDSC',pic:''},{av:'AV40TFRubLinDsc_Sel',fld:'vTFRUBLINDSC_SEL',pic:''},{av:'AV41TFRubLinDscTot',fld:'vTFRUBLINDSCTOT',pic:''},{av:'AV42TFRubLinDscTot_Sel',fld:'vTFRUBLINDSCTOT_SEL',pic:''},{av:'AV43TFRubLinOrd',fld:'vTFRUBLINORD',pic:'Z9'},{av:'AV44TFRubLinOrd_To',fld:'vTFRUBLINORD_TO',pic:'Z9'},{av:'AV46TFRubLinSts_Sels',fld:'vTFRUBLINSTS_SELS',pic:''},{av:'AV13OrderedBy',fld:'vORDEREDBY',pic:'ZZZ9'},{av:'AV14OrderedDsc',fld:'vORDEREDDSC',pic:''},{av:'AV10GridState',fld:'vGRIDSTATE',pic:''},{av:'AV27DynamicFiltersIgnoreFirst',fld:'vDYNAMICFILTERSIGNOREFIRST',pic:''},{av:'Gridpaginationbar_Rowsperpageselectedvalue',ctrl:'GRIDPAGINATIONBAR',prop:'RowsPerPageSelectedValue'}]");
         setEventMetadata("GRIDPAGINATIONBAR.CHANGEROWSPERPAGE",",oparms:[{av:'subGrid_Rows',ctrl:'GRID',prop:'Rows'}]}");
         setEventMetadata("DDO_GRID.ONOPTIONCLICKED","{handler:'E142G2',iparms:[{av:'GRID_nFirstRecordOnPage'},{av:'GRID_nEOF'},{av:'subGrid_Rows',ctrl:'GRID',prop:'Rows'},{av:'cmbavDynamicfiltersselector1'},{av:'AV15DynamicFiltersSelector1',fld:'vDYNAMICFILTERSSELECTOR1',pic:''},{av:'AV55TotTipo1',fld:'vTOTTIPO1',pic:''},{av:'cmbavDynamicfiltersselector2'},{av:'AV19DynamicFiltersSelector2',fld:'vDYNAMICFILTERSSELECTOR2',pic:''},{av:'AV56TotTipo2',fld:'vTOTTIPO2',pic:''},{av:'cmbavDynamicfiltersselector3'},{av:'AV23DynamicFiltersSelector3',fld:'vDYNAMICFILTERSSELECTOR3',pic:''},{av:'AV57TotTipo3',fld:'vTOTTIPO3',pic:''},{av:'AV60Pgmname',fld:'vPGMNAME',pic:'',hsh:true},{av:'AV18DynamicFiltersEnabled2',fld:'vDYNAMICFILTERSENABLED2',pic:''},{av:'AV22DynamicFiltersEnabled3',fld:'vDYNAMICFILTERSENABLED3',pic:''},{av:'AV32TFTotTipo_Sels',fld:'vTFTOTTIPO_SELS',pic:''},{av:'AV33TFTotRub',fld:'vTFTOTRUB',pic:'ZZZZZ9'},{av:'AV34TFTotRub_To',fld:'vTFTOTRUB_TO',pic:'ZZZZZ9'},{av:'AV35TFRubCod',fld:'vTFRUBCOD',pic:'ZZZZZ9'},{av:'AV36TFRubCod_To',fld:'vTFRUBCOD_TO',pic:'ZZZZZ9'},{av:'AV37TFRubLinCod',fld:'vTFRUBLINCOD',pic:'ZZZZZ9'},{av:'AV38TFRubLinCod_To',fld:'vTFRUBLINCOD_TO',pic:'ZZZZZ9'},{av:'AV39TFRubLinDsc',fld:'vTFRUBLINDSC',pic:''},{av:'AV40TFRubLinDsc_Sel',fld:'vTFRUBLINDSC_SEL',pic:''},{av:'AV41TFRubLinDscTot',fld:'vTFRUBLINDSCTOT',pic:''},{av:'AV42TFRubLinDscTot_Sel',fld:'vTFRUBLINDSCTOT_SEL',pic:''},{av:'AV43TFRubLinOrd',fld:'vTFRUBLINORD',pic:'Z9'},{av:'AV44TFRubLinOrd_To',fld:'vTFRUBLINORD_TO',pic:'Z9'},{av:'AV46TFRubLinSts_Sels',fld:'vTFRUBLINSTS_SELS',pic:''},{av:'AV13OrderedBy',fld:'vORDEREDBY',pic:'ZZZ9'},{av:'AV14OrderedDsc',fld:'vORDEREDDSC',pic:''},{av:'AV10GridState',fld:'vGRIDSTATE',pic:''},{av:'AV27DynamicFiltersIgnoreFirst',fld:'vDYNAMICFILTERSIGNOREFIRST',pic:''},{av:'Ddo_grid_Activeeventkey',ctrl:'DDO_GRID',prop:'ActiveEventKey'},{av:'Ddo_grid_Selectedvalue_get',ctrl:'DDO_GRID',prop:'SelectedValue_get'},{av:'Ddo_grid_Filteredtextto_get',ctrl:'DDO_GRID',prop:'FilteredTextTo_get'},{av:'Ddo_grid_Filteredtext_get',ctrl:'DDO_GRID',prop:'FilteredText_get'},{av:'Ddo_grid_Selectedcolumn',ctrl:'DDO_GRID',prop:'SelectedColumn'}]");
         setEventMetadata("DDO_GRID.ONOPTIONCLICKED",",oparms:[{av:'AV13OrderedBy',fld:'vORDEREDBY',pic:'ZZZ9'},{av:'AV14OrderedDsc',fld:'vORDEREDDSC',pic:''},{av:'AV45TFRubLinSts_SelsJson',fld:'vTFRUBLINSTS_SELSJSON',pic:''},{av:'AV46TFRubLinSts_Sels',fld:'vTFRUBLINSTS_SELS',pic:''},{av:'AV43TFRubLinOrd',fld:'vTFRUBLINORD',pic:'Z9'},{av:'AV44TFRubLinOrd_To',fld:'vTFRUBLINORD_TO',pic:'Z9'},{av:'AV41TFRubLinDscTot',fld:'vTFRUBLINDSCTOT',pic:''},{av:'AV42TFRubLinDscTot_Sel',fld:'vTFRUBLINDSCTOT_SEL',pic:''},{av:'AV39TFRubLinDsc',fld:'vTFRUBLINDSC',pic:''},{av:'AV40TFRubLinDsc_Sel',fld:'vTFRUBLINDSC_SEL',pic:''},{av:'AV37TFRubLinCod',fld:'vTFRUBLINCOD',pic:'ZZZZZ9'},{av:'AV38TFRubLinCod_To',fld:'vTFRUBLINCOD_TO',pic:'ZZZZZ9'},{av:'AV35TFRubCod',fld:'vTFRUBCOD',pic:'ZZZZZ9'},{av:'AV36TFRubCod_To',fld:'vTFRUBCOD_TO',pic:'ZZZZZ9'},{av:'AV33TFTotRub',fld:'vTFTOTRUB',pic:'ZZZZZ9'},{av:'AV34TFTotRub_To',fld:'vTFTOTRUB_TO',pic:'ZZZZZ9'},{av:'AV31TFTotTipo_SelsJson',fld:'vTFTOTTIPO_SELSJSON',pic:''},{av:'AV32TFTotTipo_Sels',fld:'vTFTOTTIPO_SELS',pic:''},{av:'Ddo_grid_Sortedstatus',ctrl:'DDO_GRID',prop:'SortedStatus'}]}");
         setEventMetadata("GRID.LOAD","{handler:'E262G2',iparms:[{av:'A114TotTipo',fld:'TOTTIPO',pic:'',hsh:true},{av:'A115TotRub',fld:'TOTRUB',pic:'ZZZZZ9',hsh:true},{av:'A116RubCod',fld:'RUBCOD',pic:'ZZZZZ9',hsh:true},{av:'A118RubLinCod',fld:'RUBLINCOD',pic:'ZZZZZ9',hsh:true}]");
         setEventMetadata("GRID.LOAD",",oparms:[{av:'cmbavGridactions'},{av:'AV52GridActions',fld:'vGRIDACTIONS',pic:'ZZZ9'},{av:'edtRubLinDsc_Link',ctrl:'RUBLINDSC',prop:'Link'}]}");
         setEventMetadata("'ADDDYNAMICFILTERS1'","{handler:'E192G2',iparms:[]");
         setEventMetadata("'ADDDYNAMICFILTERS1'",",oparms:[{av:'AV18DynamicFiltersEnabled2',fld:'vDYNAMICFILTERSENABLED2',pic:''},{av:'imgAdddynamicfilters1_Visible',ctrl:'ADDDYNAMICFILTERS1',prop:'Visible'},{av:'imgRemovedynamicfilters1_Visible',ctrl:'REMOVEDYNAMICFILTERS1',prop:'Visible'}]}");
         setEventMetadata("'REMOVEDYNAMICFILTERS1'","{handler:'E152G2',iparms:[{av:'GRID_nFirstRecordOnPage'},{av:'GRID_nEOF'},{av:'subGrid_Rows',ctrl:'GRID',prop:'Rows'},{av:'cmbavDynamicfiltersselector1'},{av:'AV15DynamicFiltersSelector1',fld:'vDYNAMICFILTERSSELECTOR1',pic:''},{av:'AV55TotTipo1',fld:'vTOTTIPO1',pic:''},{av:'cmbavDynamicfiltersselector2'},{av:'AV19DynamicFiltersSelector2',fld:'vDYNAMICFILTERSSELECTOR2',pic:''},{av:'AV56TotTipo2',fld:'vTOTTIPO2',pic:''},{av:'cmbavDynamicfiltersselector3'},{av:'AV23DynamicFiltersSelector3',fld:'vDYNAMICFILTERSSELECTOR3',pic:''},{av:'AV57TotTipo3',fld:'vTOTTIPO3',pic:''},{av:'AV60Pgmname',fld:'vPGMNAME',pic:'',hsh:true},{av:'AV18DynamicFiltersEnabled2',fld:'vDYNAMICFILTERSENABLED2',pic:''},{av:'AV22DynamicFiltersEnabled3',fld:'vDYNAMICFILTERSENABLED3',pic:''},{av:'AV32TFTotTipo_Sels',fld:'vTFTOTTIPO_SELS',pic:''},{av:'AV33TFTotRub',fld:'vTFTOTRUB',pic:'ZZZZZ9'},{av:'AV34TFTotRub_To',fld:'vTFTOTRUB_TO',pic:'ZZZZZ9'},{av:'AV35TFRubCod',fld:'vTFRUBCOD',pic:'ZZZZZ9'},{av:'AV36TFRubCod_To',fld:'vTFRUBCOD_TO',pic:'ZZZZZ9'},{av:'AV37TFRubLinCod',fld:'vTFRUBLINCOD',pic:'ZZZZZ9'},{av:'AV38TFRubLinCod_To',fld:'vTFRUBLINCOD_TO',pic:'ZZZZZ9'},{av:'AV39TFRubLinDsc',fld:'vTFRUBLINDSC',pic:''},{av:'AV40TFRubLinDsc_Sel',fld:'vTFRUBLINDSC_SEL',pic:''},{av:'AV41TFRubLinDscTot',fld:'vTFRUBLINDSCTOT',pic:''},{av:'AV42TFRubLinDscTot_Sel',fld:'vTFRUBLINDSCTOT_SEL',pic:''},{av:'AV43TFRubLinOrd',fld:'vTFRUBLINORD',pic:'Z9'},{av:'AV44TFRubLinOrd_To',fld:'vTFRUBLINORD_TO',pic:'Z9'},{av:'AV46TFRubLinSts_Sels',fld:'vTFRUBLINSTS_SELS',pic:''},{av:'AV13OrderedBy',fld:'vORDEREDBY',pic:'ZZZ9'},{av:'AV14OrderedDsc',fld:'vORDEREDDSC',pic:''},{av:'AV10GridState',fld:'vGRIDSTATE',pic:''},{av:'AV27DynamicFiltersIgnoreFirst',fld:'vDYNAMICFILTERSIGNOREFIRST',pic:''},{av:'AV26DynamicFiltersRemoving',fld:'vDYNAMICFILTERSREMOVING',pic:''}]");
         setEventMetadata("'REMOVEDYNAMICFILTERS1'",",oparms:[{av:'AV26DynamicFiltersRemoving',fld:'vDYNAMICFILTERSREMOVING',pic:''},{av:'AV27DynamicFiltersIgnoreFirst',fld:'vDYNAMICFILTERSIGNOREFIRST',pic:''},{av:'AV10GridState',fld:'vGRIDSTATE',pic:''},{av:'AV18DynamicFiltersEnabled2',fld:'vDYNAMICFILTERSENABLED2',pic:''},{av:'cmbavDynamicfiltersselector2'},{av:'AV19DynamicFiltersSelector2',fld:'vDYNAMICFILTERSSELECTOR2',pic:''},{av:'AV56TotTipo2',fld:'vTOTTIPO2',pic:''},{av:'AV22DynamicFiltersEnabled3',fld:'vDYNAMICFILTERSENABLED3',pic:''},{av:'cmbavDynamicfiltersselector3'},{av:'AV23DynamicFiltersSelector3',fld:'vDYNAMICFILTERSSELECTOR3',pic:''},{av:'AV57TotTipo3',fld:'vTOTTIPO3',pic:''},{av:'imgAdddynamicfilters1_Visible',ctrl:'ADDDYNAMICFILTERS1',prop:'Visible'},{av:'imgRemovedynamicfilters1_Visible',ctrl:'REMOVEDYNAMICFILTERS1',prop:'Visible'},{av:'imgAdddynamicfilters2_Visible',ctrl:'ADDDYNAMICFILTERS2',prop:'Visible'},{av:'imgRemovedynamicfilters2_Visible',ctrl:'REMOVEDYNAMICFILTERS2',prop:'Visible'},{av:'cmbavDynamicfiltersselector1'},{av:'AV15DynamicFiltersSelector1',fld:'vDYNAMICFILTERSSELECTOR1',pic:''},{av:'AV55TotTipo1',fld:'vTOTTIPO1',pic:''},{av:'lblJsdynamicfilters_Caption',ctrl:'JSDYNAMICFILTERS',prop:'Caption'},{av:'edtavTottipo2_Visible',ctrl:'vTOTTIPO2',prop:'Visible'},{av:'edtavTottipo3_Visible',ctrl:'vTOTTIPO3',prop:'Visible'},{av:'edtavTottipo1_Visible',ctrl:'vTOTTIPO1',prop:'Visible'},{av:'AV49GridCurrentPage',fld:'vGRIDCURRENTPAGE',pic:'ZZZZZZZZZ9'},{av:'AV50GridPageCount',fld:'vGRIDPAGECOUNT',pic:'ZZZZZZZZZ9'},{av:'AV51GridAppliedFilters',fld:'vGRIDAPPLIEDFILTERS',pic:''}]}");
         setEventMetadata("VDYNAMICFILTERSSELECTOR1.CLICK","{handler:'E202G2',iparms:[{av:'cmbavDynamicfiltersselector1'},{av:'AV15DynamicFiltersSelector1',fld:'vDYNAMICFILTERSSELECTOR1',pic:''}]");
         setEventMetadata("VDYNAMICFILTERSSELECTOR1.CLICK",",oparms:[{av:'edtavTottipo1_Visible',ctrl:'vTOTTIPO1',prop:'Visible'}]}");
         setEventMetadata("'ADDDYNAMICFILTERS2'","{handler:'E212G2',iparms:[]");
         setEventMetadata("'ADDDYNAMICFILTERS2'",",oparms:[{av:'AV22DynamicFiltersEnabled3',fld:'vDYNAMICFILTERSENABLED3',pic:''},{av:'imgAdddynamicfilters2_Visible',ctrl:'ADDDYNAMICFILTERS2',prop:'Visible'},{av:'imgRemovedynamicfilters2_Visible',ctrl:'REMOVEDYNAMICFILTERS2',prop:'Visible'}]}");
         setEventMetadata("'REMOVEDYNAMICFILTERS2'","{handler:'E162G2',iparms:[{av:'GRID_nFirstRecordOnPage'},{av:'GRID_nEOF'},{av:'subGrid_Rows',ctrl:'GRID',prop:'Rows'},{av:'cmbavDynamicfiltersselector1'},{av:'AV15DynamicFiltersSelector1',fld:'vDYNAMICFILTERSSELECTOR1',pic:''},{av:'AV55TotTipo1',fld:'vTOTTIPO1',pic:''},{av:'cmbavDynamicfiltersselector2'},{av:'AV19DynamicFiltersSelector2',fld:'vDYNAMICFILTERSSELECTOR2',pic:''},{av:'AV56TotTipo2',fld:'vTOTTIPO2',pic:''},{av:'cmbavDynamicfiltersselector3'},{av:'AV23DynamicFiltersSelector3',fld:'vDYNAMICFILTERSSELECTOR3',pic:''},{av:'AV57TotTipo3',fld:'vTOTTIPO3',pic:''},{av:'AV60Pgmname',fld:'vPGMNAME',pic:'',hsh:true},{av:'AV18DynamicFiltersEnabled2',fld:'vDYNAMICFILTERSENABLED2',pic:''},{av:'AV22DynamicFiltersEnabled3',fld:'vDYNAMICFILTERSENABLED3',pic:''},{av:'AV32TFTotTipo_Sels',fld:'vTFTOTTIPO_SELS',pic:''},{av:'AV33TFTotRub',fld:'vTFTOTRUB',pic:'ZZZZZ9'},{av:'AV34TFTotRub_To',fld:'vTFTOTRUB_TO',pic:'ZZZZZ9'},{av:'AV35TFRubCod',fld:'vTFRUBCOD',pic:'ZZZZZ9'},{av:'AV36TFRubCod_To',fld:'vTFRUBCOD_TO',pic:'ZZZZZ9'},{av:'AV37TFRubLinCod',fld:'vTFRUBLINCOD',pic:'ZZZZZ9'},{av:'AV38TFRubLinCod_To',fld:'vTFRUBLINCOD_TO',pic:'ZZZZZ9'},{av:'AV39TFRubLinDsc',fld:'vTFRUBLINDSC',pic:''},{av:'AV40TFRubLinDsc_Sel',fld:'vTFRUBLINDSC_SEL',pic:''},{av:'AV41TFRubLinDscTot',fld:'vTFRUBLINDSCTOT',pic:''},{av:'AV42TFRubLinDscTot_Sel',fld:'vTFRUBLINDSCTOT_SEL',pic:''},{av:'AV43TFRubLinOrd',fld:'vTFRUBLINORD',pic:'Z9'},{av:'AV44TFRubLinOrd_To',fld:'vTFRUBLINORD_TO',pic:'Z9'},{av:'AV46TFRubLinSts_Sels',fld:'vTFRUBLINSTS_SELS',pic:''},{av:'AV13OrderedBy',fld:'vORDEREDBY',pic:'ZZZ9'},{av:'AV14OrderedDsc',fld:'vORDEREDDSC',pic:''},{av:'AV10GridState',fld:'vGRIDSTATE',pic:''},{av:'AV27DynamicFiltersIgnoreFirst',fld:'vDYNAMICFILTERSIGNOREFIRST',pic:''},{av:'AV26DynamicFiltersRemoving',fld:'vDYNAMICFILTERSREMOVING',pic:''}]");
         setEventMetadata("'REMOVEDYNAMICFILTERS2'",",oparms:[{av:'AV26DynamicFiltersRemoving',fld:'vDYNAMICFILTERSREMOVING',pic:''},{av:'AV18DynamicFiltersEnabled2',fld:'vDYNAMICFILTERSENABLED2',pic:''},{av:'AV10GridState',fld:'vGRIDSTATE',pic:''},{av:'cmbavDynamicfiltersselector2'},{av:'AV19DynamicFiltersSelector2',fld:'vDYNAMICFILTERSSELECTOR2',pic:''},{av:'AV56TotTipo2',fld:'vTOTTIPO2',pic:''},{av:'AV22DynamicFiltersEnabled3',fld:'vDYNAMICFILTERSENABLED3',pic:''},{av:'cmbavDynamicfiltersselector3'},{av:'AV23DynamicFiltersSelector3',fld:'vDYNAMICFILTERSSELECTOR3',pic:''},{av:'AV57TotTipo3',fld:'vTOTTIPO3',pic:''},{av:'imgAdddynamicfilters1_Visible',ctrl:'ADDDYNAMICFILTERS1',prop:'Visible'},{av:'imgRemovedynamicfilters1_Visible',ctrl:'REMOVEDYNAMICFILTERS1',prop:'Visible'},{av:'imgAdddynamicfilters2_Visible',ctrl:'ADDDYNAMICFILTERS2',prop:'Visible'},{av:'imgRemovedynamicfilters2_Visible',ctrl:'REMOVEDYNAMICFILTERS2',prop:'Visible'},{av:'cmbavDynamicfiltersselector1'},{av:'AV15DynamicFiltersSelector1',fld:'vDYNAMICFILTERSSELECTOR1',pic:''},{av:'AV55TotTipo1',fld:'vTOTTIPO1',pic:''},{av:'lblJsdynamicfilters_Caption',ctrl:'JSDYNAMICFILTERS',prop:'Caption'},{av:'edtavTottipo2_Visible',ctrl:'vTOTTIPO2',prop:'Visible'},{av:'edtavTottipo3_Visible',ctrl:'vTOTTIPO3',prop:'Visible'},{av:'edtavTottipo1_Visible',ctrl:'vTOTTIPO1',prop:'Visible'},{av:'AV49GridCurrentPage',fld:'vGRIDCURRENTPAGE',pic:'ZZZZZZZZZ9'},{av:'AV50GridPageCount',fld:'vGRIDPAGECOUNT',pic:'ZZZZZZZZZ9'},{av:'AV51GridAppliedFilters',fld:'vGRIDAPPLIEDFILTERS',pic:''}]}");
         setEventMetadata("VDYNAMICFILTERSSELECTOR2.CLICK","{handler:'E222G2',iparms:[{av:'cmbavDynamicfiltersselector2'},{av:'AV19DynamicFiltersSelector2',fld:'vDYNAMICFILTERSSELECTOR2',pic:''}]");
         setEventMetadata("VDYNAMICFILTERSSELECTOR2.CLICK",",oparms:[{av:'edtavTottipo2_Visible',ctrl:'vTOTTIPO2',prop:'Visible'}]}");
         setEventMetadata("'REMOVEDYNAMICFILTERS3'","{handler:'E172G2',iparms:[{av:'GRID_nFirstRecordOnPage'},{av:'GRID_nEOF'},{av:'subGrid_Rows',ctrl:'GRID',prop:'Rows'},{av:'cmbavDynamicfiltersselector1'},{av:'AV15DynamicFiltersSelector1',fld:'vDYNAMICFILTERSSELECTOR1',pic:''},{av:'AV55TotTipo1',fld:'vTOTTIPO1',pic:''},{av:'cmbavDynamicfiltersselector2'},{av:'AV19DynamicFiltersSelector2',fld:'vDYNAMICFILTERSSELECTOR2',pic:''},{av:'AV56TotTipo2',fld:'vTOTTIPO2',pic:''},{av:'cmbavDynamicfiltersselector3'},{av:'AV23DynamicFiltersSelector3',fld:'vDYNAMICFILTERSSELECTOR3',pic:''},{av:'AV57TotTipo3',fld:'vTOTTIPO3',pic:''},{av:'AV60Pgmname',fld:'vPGMNAME',pic:'',hsh:true},{av:'AV18DynamicFiltersEnabled2',fld:'vDYNAMICFILTERSENABLED2',pic:''},{av:'AV22DynamicFiltersEnabled3',fld:'vDYNAMICFILTERSENABLED3',pic:''},{av:'AV32TFTotTipo_Sels',fld:'vTFTOTTIPO_SELS',pic:''},{av:'AV33TFTotRub',fld:'vTFTOTRUB',pic:'ZZZZZ9'},{av:'AV34TFTotRub_To',fld:'vTFTOTRUB_TO',pic:'ZZZZZ9'},{av:'AV35TFRubCod',fld:'vTFRUBCOD',pic:'ZZZZZ9'},{av:'AV36TFRubCod_To',fld:'vTFRUBCOD_TO',pic:'ZZZZZ9'},{av:'AV37TFRubLinCod',fld:'vTFRUBLINCOD',pic:'ZZZZZ9'},{av:'AV38TFRubLinCod_To',fld:'vTFRUBLINCOD_TO',pic:'ZZZZZ9'},{av:'AV39TFRubLinDsc',fld:'vTFRUBLINDSC',pic:''},{av:'AV40TFRubLinDsc_Sel',fld:'vTFRUBLINDSC_SEL',pic:''},{av:'AV41TFRubLinDscTot',fld:'vTFRUBLINDSCTOT',pic:''},{av:'AV42TFRubLinDscTot_Sel',fld:'vTFRUBLINDSCTOT_SEL',pic:''},{av:'AV43TFRubLinOrd',fld:'vTFRUBLINORD',pic:'Z9'},{av:'AV44TFRubLinOrd_To',fld:'vTFRUBLINORD_TO',pic:'Z9'},{av:'AV46TFRubLinSts_Sels',fld:'vTFRUBLINSTS_SELS',pic:''},{av:'AV13OrderedBy',fld:'vORDEREDBY',pic:'ZZZ9'},{av:'AV14OrderedDsc',fld:'vORDEREDDSC',pic:''},{av:'AV10GridState',fld:'vGRIDSTATE',pic:''},{av:'AV27DynamicFiltersIgnoreFirst',fld:'vDYNAMICFILTERSIGNOREFIRST',pic:''},{av:'AV26DynamicFiltersRemoving',fld:'vDYNAMICFILTERSREMOVING',pic:''}]");
         setEventMetadata("'REMOVEDYNAMICFILTERS3'",",oparms:[{av:'AV26DynamicFiltersRemoving',fld:'vDYNAMICFILTERSREMOVING',pic:''},{av:'AV22DynamicFiltersEnabled3',fld:'vDYNAMICFILTERSENABLED3',pic:''},{av:'AV10GridState',fld:'vGRIDSTATE',pic:''},{av:'AV18DynamicFiltersEnabled2',fld:'vDYNAMICFILTERSENABLED2',pic:''},{av:'cmbavDynamicfiltersselector2'},{av:'AV19DynamicFiltersSelector2',fld:'vDYNAMICFILTERSSELECTOR2',pic:''},{av:'AV56TotTipo2',fld:'vTOTTIPO2',pic:''},{av:'cmbavDynamicfiltersselector3'},{av:'AV23DynamicFiltersSelector3',fld:'vDYNAMICFILTERSSELECTOR3',pic:''},{av:'AV57TotTipo3',fld:'vTOTTIPO3',pic:''},{av:'imgAdddynamicfilters1_Visible',ctrl:'ADDDYNAMICFILTERS1',prop:'Visible'},{av:'imgRemovedynamicfilters1_Visible',ctrl:'REMOVEDYNAMICFILTERS1',prop:'Visible'},{av:'imgAdddynamicfilters2_Visible',ctrl:'ADDDYNAMICFILTERS2',prop:'Visible'},{av:'imgRemovedynamicfilters2_Visible',ctrl:'REMOVEDYNAMICFILTERS2',prop:'Visible'},{av:'cmbavDynamicfiltersselector1'},{av:'AV15DynamicFiltersSelector1',fld:'vDYNAMICFILTERSSELECTOR1',pic:''},{av:'AV55TotTipo1',fld:'vTOTTIPO1',pic:''},{av:'lblJsdynamicfilters_Caption',ctrl:'JSDYNAMICFILTERS',prop:'Caption'},{av:'edtavTottipo2_Visible',ctrl:'vTOTTIPO2',prop:'Visible'},{av:'edtavTottipo3_Visible',ctrl:'vTOTTIPO3',prop:'Visible'},{av:'edtavTottipo1_Visible',ctrl:'vTOTTIPO1',prop:'Visible'},{av:'AV49GridCurrentPage',fld:'vGRIDCURRENTPAGE',pic:'ZZZZZZZZZ9'},{av:'AV50GridPageCount',fld:'vGRIDPAGECOUNT',pic:'ZZZZZZZZZ9'},{av:'AV51GridAppliedFilters',fld:'vGRIDAPPLIEDFILTERS',pic:''}]}");
         setEventMetadata("VDYNAMICFILTERSSELECTOR3.CLICK","{handler:'E232G2',iparms:[{av:'cmbavDynamicfiltersselector3'},{av:'AV23DynamicFiltersSelector3',fld:'vDYNAMICFILTERSSELECTOR3',pic:''}]");
         setEventMetadata("VDYNAMICFILTERSSELECTOR3.CLICK",",oparms:[{av:'edtavTottipo3_Visible',ctrl:'vTOTTIPO3',prop:'Visible'}]}");
         setEventMetadata("VGRIDACTIONS.CLICK","{handler:'E272G2',iparms:[{av:'cmbavGridactions'},{av:'AV52GridActions',fld:'vGRIDACTIONS',pic:'ZZZ9'},{av:'A114TotTipo',fld:'TOTTIPO',pic:'',hsh:true},{av:'A115TotRub',fld:'TOTRUB',pic:'ZZZZZ9',hsh:true},{av:'A116RubCod',fld:'RUBCOD',pic:'ZZZZZ9',hsh:true},{av:'A118RubLinCod',fld:'RUBLINCOD',pic:'ZZZZZ9',hsh:true}]");
         setEventMetadata("VGRIDACTIONS.CLICK",",oparms:[{av:'cmbavGridactions'},{av:'AV52GridActions',fld:'vGRIDACTIONS',pic:'ZZZ9'}]}");
         setEventMetadata("'DOINSERT'","{handler:'E182G2',iparms:[{av:'A114TotTipo',fld:'TOTTIPO',pic:'',hsh:true},{av:'A115TotRub',fld:'TOTRUB',pic:'ZZZZZ9',hsh:true},{av:'A116RubCod',fld:'RUBCOD',pic:'ZZZZZ9',hsh:true},{av:'A118RubLinCod',fld:'RUBLINCOD',pic:'ZZZZZ9',hsh:true}]");
         setEventMetadata("'DOINSERT'",",oparms:[]}");
         setEventMetadata("DDO_AGEXPORT.ONOPTIONCLICKED","{handler:'E132G2',iparms:[{av:'Ddo_agexport_Activeeventkey',ctrl:'DDO_AGEXPORT',prop:'ActiveEventKey'},{av:'AV60Pgmname',fld:'vPGMNAME',pic:'',hsh:true},{av:'AV46TFRubLinSts_Sels',fld:'vTFRUBLINSTS_SELS',pic:''},{av:'AV32TFTotTipo_Sels',fld:'vTFTOTTIPO_SELS',pic:''},{av:'AV31TFTotTipo_SelsJson',fld:'vTFTOTTIPO_SELSJSON',pic:''},{av:'AV40TFRubLinDsc_Sel',fld:'vTFRUBLINDSC_SEL',pic:''},{av:'AV42TFRubLinDscTot_Sel',fld:'vTFRUBLINDSCTOT_SEL',pic:''},{av:'AV45TFRubLinSts_SelsJson',fld:'vTFRUBLINSTS_SELSJSON',pic:''},{av:'AV33TFTotRub',fld:'vTFTOTRUB',pic:'ZZZZZ9'},{av:'AV35TFRubCod',fld:'vTFRUBCOD',pic:'ZZZZZ9'},{av:'AV37TFRubLinCod',fld:'vTFRUBLINCOD',pic:'ZZZZZ9'},{av:'AV39TFRubLinDsc',fld:'vTFRUBLINDSC',pic:''},{av:'AV41TFRubLinDscTot',fld:'vTFRUBLINDSCTOT',pic:''},{av:'AV43TFRubLinOrd',fld:'vTFRUBLINORD',pic:'Z9'},{av:'AV34TFTotRub_To',fld:'vTFTOTRUB_TO',pic:'ZZZZZ9'},{av:'AV36TFRubCod_To',fld:'vTFRUBCOD_TO',pic:'ZZZZZ9'},{av:'AV38TFRubLinCod_To',fld:'vTFRUBLINCOD_TO',pic:'ZZZZZ9'},{av:'AV44TFRubLinOrd_To',fld:'vTFRUBLINORD_TO',pic:'Z9'},{av:'AV13OrderedBy',fld:'vORDEREDBY',pic:'ZZZ9'},{av:'AV14OrderedDsc',fld:'vORDEREDDSC',pic:''},{av:'AV10GridState',fld:'vGRIDSTATE',pic:''},{av:'AV26DynamicFiltersRemoving',fld:'vDYNAMICFILTERSREMOVING',pic:''},{av:'cmbavDynamicfiltersselector1'},{av:'AV15DynamicFiltersSelector1',fld:'vDYNAMICFILTERSSELECTOR1',pic:''},{av:'cmbavDynamicfiltersselector2'},{av:'AV19DynamicFiltersSelector2',fld:'vDYNAMICFILTERSSELECTOR2',pic:''},{av:'cmbavDynamicfiltersselector3'},{av:'AV23DynamicFiltersSelector3',fld:'vDYNAMICFILTERSSELECTOR3',pic:''}]");
         setEventMetadata("DDO_AGEXPORT.ONOPTIONCLICKED",",oparms:[{av:'Innewwindow1_Target',ctrl:'INNEWWINDOW1',prop:'Target'},{av:'Innewwindow1_Height',ctrl:'INNEWWINDOW1',prop:'Height'},{av:'Innewwindow1_Width',ctrl:'INNEWWINDOW1',prop:'Width'},{av:'AV10GridState',fld:'vGRIDSTATE',pic:''},{av:'AV13OrderedBy',fld:'vORDEREDBY',pic:'ZZZ9'},{av:'AV14OrderedDsc',fld:'vORDEREDDSC',pic:''},{av:'AV45TFRubLinSts_SelsJson',fld:'vTFRUBLINSTS_SELSJSON',pic:''},{av:'AV46TFRubLinSts_Sels',fld:'vTFRUBLINSTS_SELS',pic:''},{av:'AV43TFRubLinOrd',fld:'vTFRUBLINORD',pic:'Z9'},{av:'AV44TFRubLinOrd_To',fld:'vTFRUBLINORD_TO',pic:'Z9'},{av:'AV42TFRubLinDscTot_Sel',fld:'vTFRUBLINDSCTOT_SEL',pic:''},{av:'AV41TFRubLinDscTot',fld:'vTFRUBLINDSCTOT',pic:''},{av:'AV40TFRubLinDsc_Sel',fld:'vTFRUBLINDSC_SEL',pic:''},{av:'AV39TFRubLinDsc',fld:'vTFRUBLINDSC',pic:''},{av:'AV37TFRubLinCod',fld:'vTFRUBLINCOD',pic:'ZZZZZ9'},{av:'AV38TFRubLinCod_To',fld:'vTFRUBLINCOD_TO',pic:'ZZZZZ9'},{av:'AV35TFRubCod',fld:'vTFRUBCOD',pic:'ZZZZZ9'},{av:'AV36TFRubCod_To',fld:'vTFRUBCOD_TO',pic:'ZZZZZ9'},{av:'AV33TFTotRub',fld:'vTFTOTRUB',pic:'ZZZZZ9'},{av:'AV34TFTotRub_To',fld:'vTFTOTRUB_TO',pic:'ZZZZZ9'},{av:'AV31TFTotTipo_SelsJson',fld:'vTFTOTTIPO_SELSJSON',pic:''},{av:'AV32TFTotTipo_Sels',fld:'vTFTOTTIPO_SELS',pic:''},{av:'Ddo_grid_Selectedvalue_set',ctrl:'DDO_GRID',prop:'SelectedValue_set'},{av:'Ddo_grid_Filteredtext_set',ctrl:'DDO_GRID',prop:'FilteredText_set'},{av:'Ddo_grid_Filteredtextto_set',ctrl:'DDO_GRID',prop:'FilteredTextTo_set'},{av:'subGrid_Rows',ctrl:'GRID',prop:'Rows'},{av:'GRID_nFirstRecordOnPage'},{av:'GRID_nEOF'},{av:'cmbavDynamicfiltersselector1'},{av:'AV15DynamicFiltersSelector1',fld:'vDYNAMICFILTERSSELECTOR1',pic:''},{av:'AV55TotTipo1',fld:'vTOTTIPO1',pic:''},{av:'cmbavDynamicfiltersselector2'},{av:'AV19DynamicFiltersSelector2',fld:'vDYNAMICFILTERSSELECTOR2',pic:''},{av:'AV56TotTipo2',fld:'vTOTTIPO2',pic:''},{av:'cmbavDynamicfiltersselector3'},{av:'AV23DynamicFiltersSelector3',fld:'vDYNAMICFILTERSSELECTOR3',pic:''},{av:'AV57TotTipo3',fld:'vTOTTIPO3',pic:''},{av:'AV60Pgmname',fld:'vPGMNAME',pic:'',hsh:true},{av:'AV18DynamicFiltersEnabled2',fld:'vDYNAMICFILTERSENABLED2',pic:''},{av:'AV22DynamicFiltersEnabled3',fld:'vDYNAMICFILTERSENABLED3',pic:''},{av:'AV27DynamicFiltersIgnoreFirst',fld:'vDYNAMICFILTERSIGNOREFIRST',pic:''},{av:'Ddo_grid_Sortedstatus',ctrl:'DDO_GRID',prop:'SortedStatus'},{av:'imgAdddynamicfilters1_Visible',ctrl:'ADDDYNAMICFILTERS1',prop:'Visible'},{av:'imgRemovedynamicfilters1_Visible',ctrl:'REMOVEDYNAMICFILTERS1',prop:'Visible'},{av:'imgAdddynamicfilters2_Visible',ctrl:'ADDDYNAMICFILTERS2',prop:'Visible'},{av:'imgRemovedynamicfilters2_Visible',ctrl:'REMOVEDYNAMICFILTERS2',prop:'Visible'},{av:'lblJsdynamicfilters_Caption',ctrl:'JSDYNAMICFILTERS',prop:'Caption'},{av:'edtavTottipo1_Visible',ctrl:'vTOTTIPO1',prop:'Visible'},{av:'edtavTottipo2_Visible',ctrl:'vTOTTIPO2',prop:'Visible'},{av:'edtavTottipo3_Visible',ctrl:'vTOTTIPO3',prop:'Visible'}]}");
         setEventMetadata("NULL","{handler:'Valid_Rublinsts',iparms:[]");
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
         Ddo_grid_Filteredtextto_get = "";
         Ddo_grid_Filteredtext_get = "";
         Ddo_grid_Selectedcolumn = "";
         Ddo_agexport_Activeeventkey = "";
         gxfirstwebparm = "";
         gxfirstwebparm_bkp = "";
         AV15DynamicFiltersSelector1 = "";
         AV55TotTipo1 = "";
         AV19DynamicFiltersSelector2 = "";
         AV56TotTipo2 = "";
         AV23DynamicFiltersSelector3 = "";
         AV57TotTipo3 = "";
         AV60Pgmname = "";
         AV32TFTotTipo_Sels = new GxSimpleCollection<string>();
         AV39TFRubLinDsc = "";
         AV40TFRubLinDsc_Sel = "";
         AV41TFRubLinDscTot = "";
         AV42TFRubLinDscTot_Sel = "";
         AV46TFRubLinSts_Sels = new GxSimpleCollection<short>();
         AV10GridState = new GeneXus.Programs.wwpbaseobjects.SdtWWPGridState(context);
         sDynURL = "";
         FormProcess = "";
         bodyStyle = "";
         GXKey = "";
         AV51GridAppliedFilters = "";
         AV53AGExportData = new GXBaseCollection<GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTDropDownOptionsData_Item>( context, "Item", "");
         AV47DDO_TitleSettingsIcons = new GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTDropDownOptionsTitleSettingsIcons(context);
         AV31TFTotTipo_SelsJson = "";
         AV45TFRubLinSts_SelsJson = "";
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
         A114TotTipo = "";
         A1826RubLinDsc = "";
         A1827RubLinDscTot = "";
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
         AV69Contabilidad_lineaswwds_9_tftottipo_sels = new GxSimpleCollection<string>();
         AV82Contabilidad_lineaswwds_22_tfrublinsts_sels = new GxSimpleCollection<short>();
         scmdbuf = "";
         lV76Contabilidad_lineaswwds_16_tfrublindsc = "";
         lV78Contabilidad_lineaswwds_18_tfrublindsctot = "";
         AV61Contabilidad_lineaswwds_1_dynamicfiltersselector1 = "";
         AV62Contabilidad_lineaswwds_2_tottipo1 = "";
         AV64Contabilidad_lineaswwds_4_dynamicfiltersselector2 = "";
         AV65Contabilidad_lineaswwds_5_tottipo2 = "";
         AV67Contabilidad_lineaswwds_7_dynamicfiltersselector3 = "";
         AV68Contabilidad_lineaswwds_8_tottipo3 = "";
         AV77Contabilidad_lineaswwds_17_tfrublindsc_sel = "";
         AV76Contabilidad_lineaswwds_16_tfrublindsc = "";
         AV79Contabilidad_lineaswwds_19_tfrublindsctot_sel = "";
         AV78Contabilidad_lineaswwds_18_tfrublindsctot = "";
         H002G2_A1828RubLinSts = new short[1] ;
         H002G2_A119RubLinOrd = new short[1] ;
         H002G2_A1827RubLinDscTot = new string[] {""} ;
         H002G2_A1826RubLinDsc = new string[] {""} ;
         H002G2_A118RubLinCod = new int[1] ;
         H002G2_A116RubCod = new int[1] ;
         H002G2_A115TotRub = new int[1] ;
         H002G2_A114TotTipo = new string[] {""} ;
         H002G3_AGRID_nRecordCount = new long[1] ;
         imgAdddynamicfilters1_Jsonclick = "";
         imgRemovedynamicfilters1_Jsonclick = "";
         imgAdddynamicfilters2_Jsonclick = "";
         imgRemovedynamicfilters2_Jsonclick = "";
         imgRemovedynamicfilters3_Jsonclick = "";
         AV54AGExportDataItem = new GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTDropDownOptionsData_Item(context);
         GXt_SdtDVB_SDTDropDownOptionsTitleSettingsIcons1 = new GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTDropDownOptionsTitleSettingsIcons(context);
         AV6WWPContext = new GeneXus.Programs.wwpbaseobjects.SdtWWPContext(context);
         GXEncryptionTmp = "";
         GridRow = new GXWebRow();
         AV30Session = context.GetSession();
         AV11GridStateFilterValue = new GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue(context);
         GXt_char2 = "";
         GXt_char4 = "";
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
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.contabilidad.lineasww__default(),
            new Object[][] {
                new Object[] {
               H002G2_A1828RubLinSts, H002G2_A119RubLinOrd, H002G2_A1827RubLinDscTot, H002G2_A1826RubLinDsc, H002G2_A118RubLinCod, H002G2_A116RubCod, H002G2_A115TotRub, H002G2_A114TotTipo
               }
               , new Object[] {
               H002G3_AGRID_nRecordCount
               }
            }
         );
         AV60Pgmname = "Contabilidad.LineasWW";
         /* GeneXus formulas. */
         AV60Pgmname = "Contabilidad.LineasWW";
         context.Gx_err = 0;
      }

      private short GRID_nEOF ;
      private short nGotPars ;
      private short GxWebError ;
      private short AV43TFRubLinOrd ;
      private short AV44TFRubLinOrd_To ;
      private short AV13OrderedBy ;
      private short initialized ;
      private short gxajaxcallmode ;
      private short wbEnd ;
      private short wbStart ;
      private short subGrid_Backcolorstyle ;
      private short subGrid_Titlebackstyle ;
      private short subGrid_Sortable ;
      private short AV52GridActions ;
      private short A119RubLinOrd ;
      private short A1828RubLinSts ;
      private short subGrid_Allowselection ;
      private short subGrid_Allowhovering ;
      private short subGrid_Allowcollapsing ;
      private short subGrid_Collapsed ;
      private short nDonePA ;
      private short AV80Contabilidad_lineaswwds_20_tfrublinord ;
      private short AV81Contabilidad_lineaswwds_21_tfrublinord_to ;
      private short nGXWrapped ;
      private short subGrid_Backstyle ;
      private int subGrid_Rows ;
      private int Gridpaginationbar_Rowsperpageselectedvalue ;
      private int nRC_GXsfl_92 ;
      private int nGXsfl_92_idx=1 ;
      private int AV33TFTotRub ;
      private int AV34TFTotRub_To ;
      private int AV35TFRubCod ;
      private int AV36TFRubCod_To ;
      private int AV37TFRubLinCod ;
      private int AV38TFRubLinCod_To ;
      private int Gridpaginationbar_Pagestoshow ;
      private int subGrid_Titlebackcolor ;
      private int subGrid_Allbackcolor ;
      private int A115TotRub ;
      private int A116RubCod ;
      private int A118RubLinCod ;
      private int subGrid_Selectedindex ;
      private int subGrid_Selectioncolor ;
      private int subGrid_Hoveringcolor ;
      private int subGrid_Islastpage ;
      private int GXPagingFrom2 ;
      private int GXPagingTo2 ;
      private int AV69Contabilidad_lineaswwds_9_tftottipo_sels_Count ;
      private int AV82Contabilidad_lineaswwds_22_tfrublinsts_sels_Count ;
      private int AV70Contabilidad_lineaswwds_10_tftotrub ;
      private int AV71Contabilidad_lineaswwds_11_tftotrub_to ;
      private int AV72Contabilidad_lineaswwds_12_tfrubcod ;
      private int AV73Contabilidad_lineaswwds_13_tfrubcod_to ;
      private int AV74Contabilidad_lineaswwds_14_tfrublincod ;
      private int AV75Contabilidad_lineaswwds_15_tfrublincod_to ;
      private int AV48PageToGo ;
      private int imgAdddynamicfilters1_Visible ;
      private int imgRemovedynamicfilters1_Visible ;
      private int imgAdddynamicfilters2_Visible ;
      private int imgRemovedynamicfilters2_Visible ;
      private int edtavTottipo1_Visible ;
      private int edtavTottipo2_Visible ;
      private int edtavTottipo3_Visible ;
      private int AV83GXV1 ;
      private int edtavTottipo3_Enabled ;
      private int edtavTottipo2_Enabled ;
      private int edtavTottipo1_Enabled ;
      private int idxLst ;
      private int subGrid_Backcolor ;
      private long GRID_nFirstRecordOnPage ;
      private long AV49GridCurrentPage ;
      private long AV50GridPageCount ;
      private long GRID_nCurrentRecord ;
      private long GRID_nRecordCount ;
      private string Gridpaginationbar_Selectedpage ;
      private string Ddo_grid_Activeeventkey ;
      private string Ddo_grid_Selectedvalue_get ;
      private string Ddo_grid_Filteredtextto_get ;
      private string Ddo_grid_Filteredtext_get ;
      private string Ddo_grid_Selectedcolumn ;
      private string Ddo_agexport_Activeeventkey ;
      private string gxfirstwebparm ;
      private string gxfirstwebparm_bkp ;
      private string sGXsfl_92_idx="0001" ;
      private string AV55TotTipo1 ;
      private string AV56TotTipo2 ;
      private string AV57TotTipo3 ;
      private string AV60Pgmname ;
      private string AV39TFRubLinDsc ;
      private string AV40TFRubLinDsc_Sel ;
      private string AV41TFRubLinDscTot ;
      private string AV42TFRubLinDscTot_Sel ;
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
      private string A114TotTipo ;
      private string A1826RubLinDsc ;
      private string edtRubLinDsc_Link ;
      private string A1827RubLinDscTot ;
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
      private string edtTotTipo_Internalname ;
      private string edtTotRub_Internalname ;
      private string edtRubCod_Internalname ;
      private string edtRubLinCod_Internalname ;
      private string edtRubLinDsc_Internalname ;
      private string edtRubLinDscTot_Internalname ;
      private string edtRubLinOrd_Internalname ;
      private string cmbRubLinSts_Internalname ;
      private string cmbavDynamicfiltersselector1_Internalname ;
      private string cmbavDynamicfiltersselector2_Internalname ;
      private string cmbavDynamicfiltersselector3_Internalname ;
      private string scmdbuf ;
      private string lV76Contabilidad_lineaswwds_16_tfrublindsc ;
      private string lV78Contabilidad_lineaswwds_18_tfrublindsctot ;
      private string AV62Contabilidad_lineaswwds_2_tottipo1 ;
      private string AV65Contabilidad_lineaswwds_5_tottipo2 ;
      private string AV68Contabilidad_lineaswwds_8_tottipo3 ;
      private string AV77Contabilidad_lineaswwds_17_tfrublindsc_sel ;
      private string AV76Contabilidad_lineaswwds_16_tfrublindsc ;
      private string AV79Contabilidad_lineaswwds_19_tfrublindsctot_sel ;
      private string AV78Contabilidad_lineaswwds_18_tfrublindsctot ;
      private string edtavTottipo1_Internalname ;
      private string edtavTottipo2_Internalname ;
      private string edtavTottipo3_Internalname ;
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
      private string GXt_char4 ;
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
      private string tblUnnamedtabledynamicfilters_3_Internalname ;
      private string cellFilter_tottipo3_cell_Internalname ;
      private string edtavTottipo3_Jsonclick ;
      private string cellDynamicfilters_removefilter3_cell_Internalname ;
      private string sImgUrl ;
      private string tblUnnamedtabledynamicfilters_2_Internalname ;
      private string cellFilter_tottipo2_cell_Internalname ;
      private string edtavTottipo2_Jsonclick ;
      private string cellDynamicfilters_addfilter2_cell_Internalname ;
      private string cellDynamicfilters_removefilter2_cell_Internalname ;
      private string tblUnnamedtabledynamicfilters_1_Internalname ;
      private string cellFilter_tottipo1_cell_Internalname ;
      private string edtavTottipo1_Jsonclick ;
      private string cellDynamicfilters_addfilter1_cell_Internalname ;
      private string cellDynamicfilters_removefilter1_cell_Internalname ;
      private string sGXsfl_92_fel_idx="0001" ;
      private string GXCCtl ;
      private string cmbavGridactions_Jsonclick ;
      private string ROClassString ;
      private string edtTotTipo_Jsonclick ;
      private string edtTotRub_Jsonclick ;
      private string edtRubCod_Jsonclick ;
      private string edtRubLinCod_Jsonclick ;
      private string edtRubLinDsc_Jsonclick ;
      private string edtRubLinDscTot_Jsonclick ;
      private string edtRubLinOrd_Jsonclick ;
      private string cmbRubLinSts_Jsonclick ;
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
      private bool bGXsfl_92_Refreshing=false ;
      private bool gxdyncontrolsrefreshing ;
      private bool AV63Contabilidad_lineaswwds_3_dynamicfiltersenabled2 ;
      private bool AV66Contabilidad_lineaswwds_6_dynamicfiltersenabled3 ;
      private bool returnInSub ;
      private bool gx_refresh_fired ;
      private string AV31TFTotTipo_SelsJson ;
      private string AV45TFRubLinSts_SelsJson ;
      private string AV15DynamicFiltersSelector1 ;
      private string AV19DynamicFiltersSelector2 ;
      private string AV23DynamicFiltersSelector3 ;
      private string AV51GridAppliedFilters ;
      private string AV61Contabilidad_lineaswwds_1_dynamicfiltersselector1 ;
      private string AV64Contabilidad_lineaswwds_4_dynamicfiltersselector2 ;
      private string AV67Contabilidad_lineaswwds_7_dynamicfiltersselector3 ;
      private string AV28ExcelFilename ;
      private string AV29ErrorMessage ;
      private GxSimpleCollection<short> AV46TFRubLinSts_Sels ;
      private GxSimpleCollection<short> AV82Contabilidad_lineaswwds_22_tfrublinsts_sels ;
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
      private GXCombobox cmbavDynamicfiltersselector2 ;
      private GXCombobox cmbavDynamicfiltersselector3 ;
      private GXCombobox cmbavGridactions ;
      private GXCombobox cmbRubLinSts ;
      private IDataStoreProvider pr_default ;
      private short[] H002G2_A1828RubLinSts ;
      private short[] H002G2_A119RubLinOrd ;
      private string[] H002G2_A1827RubLinDscTot ;
      private string[] H002G2_A1826RubLinDsc ;
      private int[] H002G2_A118RubLinCod ;
      private int[] H002G2_A116RubCod ;
      private int[] H002G2_A115TotRub ;
      private string[] H002G2_A114TotTipo ;
      private long[] H002G3_AGRID_nRecordCount ;
      private msglist BackMsgLst ;
      private msglist LclMsgLst ;
      private GxHttpRequest AV7HTTPRequest ;
      private GxSimpleCollection<string> AV32TFTotTipo_Sels ;
      private GxSimpleCollection<string> AV69Contabilidad_lineaswwds_9_tftottipo_sels ;
      private GXBaseCollection<GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTDropDownOptionsData_Item> AV53AGExportData ;
      private GXWebForm Form ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPContext AV6WWPContext ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPTransactionContext AV8TrnContext ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPGridState AV10GridState ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue AV11GridStateFilterValue ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter AV12GridStateDynamicFilter ;
      private GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTDropDownOptionsTitleSettingsIcons AV47DDO_TitleSettingsIcons ;
      private GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTDropDownOptionsTitleSettingsIcons GXt_SdtDVB_SDTDropDownOptionsTitleSettingsIcons1 ;
      private GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTDropDownOptionsData_Item AV54AGExportDataItem ;
   }

   public class lineasww__default : DataStoreHelperBase, IDataStoreHelper
   {
      protected Object[] conditional_H002G2( IGxContext context ,
                                             string A114TotTipo ,
                                             GxSimpleCollection<string> AV69Contabilidad_lineaswwds_9_tftottipo_sels ,
                                             short A1828RubLinSts ,
                                             GxSimpleCollection<short> AV82Contabilidad_lineaswwds_22_tfrublinsts_sels ,
                                             string AV61Contabilidad_lineaswwds_1_dynamicfiltersselector1 ,
                                             string AV62Contabilidad_lineaswwds_2_tottipo1 ,
                                             bool AV63Contabilidad_lineaswwds_3_dynamicfiltersenabled2 ,
                                             string AV64Contabilidad_lineaswwds_4_dynamicfiltersselector2 ,
                                             string AV65Contabilidad_lineaswwds_5_tottipo2 ,
                                             bool AV66Contabilidad_lineaswwds_6_dynamicfiltersenabled3 ,
                                             string AV67Contabilidad_lineaswwds_7_dynamicfiltersselector3 ,
                                             string AV68Contabilidad_lineaswwds_8_tottipo3 ,
                                             int AV69Contabilidad_lineaswwds_9_tftottipo_sels_Count ,
                                             int AV70Contabilidad_lineaswwds_10_tftotrub ,
                                             int AV71Contabilidad_lineaswwds_11_tftotrub_to ,
                                             int AV72Contabilidad_lineaswwds_12_tfrubcod ,
                                             int AV73Contabilidad_lineaswwds_13_tfrubcod_to ,
                                             int AV74Contabilidad_lineaswwds_14_tfrublincod ,
                                             int AV75Contabilidad_lineaswwds_15_tfrublincod_to ,
                                             string AV77Contabilidad_lineaswwds_17_tfrublindsc_sel ,
                                             string AV76Contabilidad_lineaswwds_16_tfrublindsc ,
                                             string AV79Contabilidad_lineaswwds_19_tfrublindsctot_sel ,
                                             string AV78Contabilidad_lineaswwds_18_tfrublindsctot ,
                                             short AV80Contabilidad_lineaswwds_20_tfrublinord ,
                                             short AV81Contabilidad_lineaswwds_21_tfrublinord_to ,
                                             int AV82Contabilidad_lineaswwds_22_tfrublinsts_sels_Count ,
                                             int A115TotRub ,
                                             int A116RubCod ,
                                             int A118RubLinCod ,
                                             string A1826RubLinDsc ,
                                             string A1827RubLinDscTot ,
                                             short A119RubLinOrd ,
                                             short AV13OrderedBy ,
                                             bool AV14OrderedDsc )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int5 = new short[18];
         Object[] GXv_Object6 = new Object[2];
         string sSelectString;
         string sFromString;
         string sOrderString;
         sSelectString = " [RubLinSts], [RubLinOrd], [RubLinDscTot], [RubLinDsc], [RubLinCod], [RubCod], [TotRub], [TotTipo]";
         sFromString = " FROM [CBRUBROSL]";
         sOrderString = "";
         if ( ( StringUtil.StrCmp(AV61Contabilidad_lineaswwds_1_dynamicfiltersselector1, "TOTTIPO") == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV62Contabilidad_lineaswwds_2_tottipo1)) ) )
         {
            AddWhere(sWhereString, "([TotTipo] = @AV62Contabilidad_lineaswwds_2_tottipo1)");
         }
         else
         {
            GXv_int5[0] = 1;
         }
         if ( AV63Contabilidad_lineaswwds_3_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV64Contabilidad_lineaswwds_4_dynamicfiltersselector2, "TOTTIPO") == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV65Contabilidad_lineaswwds_5_tottipo2)) ) )
         {
            AddWhere(sWhereString, "([TotTipo] = @AV65Contabilidad_lineaswwds_5_tottipo2)");
         }
         else
         {
            GXv_int5[1] = 1;
         }
         if ( AV66Contabilidad_lineaswwds_6_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV67Contabilidad_lineaswwds_7_dynamicfiltersselector3, "TOTTIPO") == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV68Contabilidad_lineaswwds_8_tottipo3)) ) )
         {
            AddWhere(sWhereString, "([TotTipo] = @AV68Contabilidad_lineaswwds_8_tottipo3)");
         }
         else
         {
            GXv_int5[2] = 1;
         }
         if ( AV69Contabilidad_lineaswwds_9_tftottipo_sels_Count > 0 )
         {
            AddWhere(sWhereString, "("+new GxDbmsUtils( new GxSqlServer()).ValueList(AV69Contabilidad_lineaswwds_9_tftottipo_sels, "[TotTipo] IN (", ")")+")");
         }
         if ( ! (0==AV70Contabilidad_lineaswwds_10_tftotrub) )
         {
            AddWhere(sWhereString, "([TotRub] >= @AV70Contabilidad_lineaswwds_10_tftotrub)");
         }
         else
         {
            GXv_int5[3] = 1;
         }
         if ( ! (0==AV71Contabilidad_lineaswwds_11_tftotrub_to) )
         {
            AddWhere(sWhereString, "([TotRub] <= @AV71Contabilidad_lineaswwds_11_tftotrub_to)");
         }
         else
         {
            GXv_int5[4] = 1;
         }
         if ( ! (0==AV72Contabilidad_lineaswwds_12_tfrubcod) )
         {
            AddWhere(sWhereString, "([RubCod] >= @AV72Contabilidad_lineaswwds_12_tfrubcod)");
         }
         else
         {
            GXv_int5[5] = 1;
         }
         if ( ! (0==AV73Contabilidad_lineaswwds_13_tfrubcod_to) )
         {
            AddWhere(sWhereString, "([RubCod] <= @AV73Contabilidad_lineaswwds_13_tfrubcod_to)");
         }
         else
         {
            GXv_int5[6] = 1;
         }
         if ( ! (0==AV74Contabilidad_lineaswwds_14_tfrublincod) )
         {
            AddWhere(sWhereString, "([RubLinCod] >= @AV74Contabilidad_lineaswwds_14_tfrublincod)");
         }
         else
         {
            GXv_int5[7] = 1;
         }
         if ( ! (0==AV75Contabilidad_lineaswwds_15_tfrublincod_to) )
         {
            AddWhere(sWhereString, "([RubLinCod] <= @AV75Contabilidad_lineaswwds_15_tfrublincod_to)");
         }
         else
         {
            GXv_int5[8] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV77Contabilidad_lineaswwds_17_tfrublindsc_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV76Contabilidad_lineaswwds_16_tfrublindsc)) ) )
         {
            AddWhere(sWhereString, "([RubLinDsc] like @lV76Contabilidad_lineaswwds_16_tfrublindsc)");
         }
         else
         {
            GXv_int5[9] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV77Contabilidad_lineaswwds_17_tfrublindsc_sel)) )
         {
            AddWhere(sWhereString, "([RubLinDsc] = @AV77Contabilidad_lineaswwds_17_tfrublindsc_sel)");
         }
         else
         {
            GXv_int5[10] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV79Contabilidad_lineaswwds_19_tfrublindsctot_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV78Contabilidad_lineaswwds_18_tfrublindsctot)) ) )
         {
            AddWhere(sWhereString, "([RubLinDscTot] like @lV78Contabilidad_lineaswwds_18_tfrublindsctot)");
         }
         else
         {
            GXv_int5[11] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV79Contabilidad_lineaswwds_19_tfrublindsctot_sel)) )
         {
            AddWhere(sWhereString, "([RubLinDscTot] = @AV79Contabilidad_lineaswwds_19_tfrublindsctot_sel)");
         }
         else
         {
            GXv_int5[12] = 1;
         }
         if ( ! (0==AV80Contabilidad_lineaswwds_20_tfrublinord) )
         {
            AddWhere(sWhereString, "([RubLinOrd] >= @AV80Contabilidad_lineaswwds_20_tfrublinord)");
         }
         else
         {
            GXv_int5[13] = 1;
         }
         if ( ! (0==AV81Contabilidad_lineaswwds_21_tfrublinord_to) )
         {
            AddWhere(sWhereString, "([RubLinOrd] <= @AV81Contabilidad_lineaswwds_21_tfrublinord_to)");
         }
         else
         {
            GXv_int5[14] = 1;
         }
         if ( AV82Contabilidad_lineaswwds_22_tfrublinsts_sels_Count > 0 )
         {
            AddWhere(sWhereString, "("+new GxDbmsUtils( new GxSqlServer()).ValueList(AV82Contabilidad_lineaswwds_22_tfrublinsts_sels, "[RubLinSts] IN (", ")")+")");
         }
         if ( AV13OrderedBy == 1 )
         {
            sOrderString += " ORDER BY [TotTipo], [TotRub], [RubCod], [RubLinCod]";
         }
         else if ( ( AV13OrderedBy == 2 ) && ! AV14OrderedDsc )
         {
            sOrderString += " ORDER BY [TotTipo]";
         }
         else if ( ( AV13OrderedBy == 2 ) && ( AV14OrderedDsc ) )
         {
            sOrderString += " ORDER BY [TotTipo] DESC";
         }
         else if ( ( AV13OrderedBy == 3 ) && ! AV14OrderedDsc )
         {
            sOrderString += " ORDER BY [TotRub]";
         }
         else if ( ( AV13OrderedBy == 3 ) && ( AV14OrderedDsc ) )
         {
            sOrderString += " ORDER BY [TotRub] DESC";
         }
         else if ( ( AV13OrderedBy == 4 ) && ! AV14OrderedDsc )
         {
            sOrderString += " ORDER BY [RubCod]";
         }
         else if ( ( AV13OrderedBy == 4 ) && ( AV14OrderedDsc ) )
         {
            sOrderString += " ORDER BY [RubCod] DESC";
         }
         else if ( ( AV13OrderedBy == 5 ) && ! AV14OrderedDsc )
         {
            sOrderString += " ORDER BY [RubLinCod]";
         }
         else if ( ( AV13OrderedBy == 5 ) && ( AV14OrderedDsc ) )
         {
            sOrderString += " ORDER BY [RubLinCod] DESC";
         }
         else if ( ( AV13OrderedBy == 6 ) && ! AV14OrderedDsc )
         {
            sOrderString += " ORDER BY [RubLinDsc]";
         }
         else if ( ( AV13OrderedBy == 6 ) && ( AV14OrderedDsc ) )
         {
            sOrderString += " ORDER BY [RubLinDsc] DESC";
         }
         else if ( ( AV13OrderedBy == 7 ) && ! AV14OrderedDsc )
         {
            sOrderString += " ORDER BY [RubLinDscTot]";
         }
         else if ( ( AV13OrderedBy == 7 ) && ( AV14OrderedDsc ) )
         {
            sOrderString += " ORDER BY [RubLinDscTot] DESC";
         }
         else if ( ( AV13OrderedBy == 8 ) && ! AV14OrderedDsc )
         {
            sOrderString += " ORDER BY [RubLinOrd]";
         }
         else if ( ( AV13OrderedBy == 8 ) && ( AV14OrderedDsc ) )
         {
            sOrderString += " ORDER BY [RubLinOrd] DESC";
         }
         else if ( ( AV13OrderedBy == 9 ) && ! AV14OrderedDsc )
         {
            sOrderString += " ORDER BY [RubLinSts]";
         }
         else if ( ( AV13OrderedBy == 9 ) && ( AV14OrderedDsc ) )
         {
            sOrderString += " ORDER BY [RubLinSts] DESC";
         }
         else if ( true )
         {
            sOrderString += " ORDER BY [TotTipo], [TotRub], [RubCod], [RubLinCod]";
         }
         scmdbuf = "SELECT " + sSelectString + sFromString + sWhereString + sOrderString + "" + " OFFSET " + "@GXPagingFrom2" + " ROWS FETCH NEXT CAST((SELECT CASE WHEN " + "@GXPagingTo2" + " > 0 THEN " + "@GXPagingTo2" + " ELSE 1e9 END) AS INTEGER) ROWS ONLY";
         GXv_Object6[0] = scmdbuf;
         GXv_Object6[1] = GXv_int5;
         return GXv_Object6 ;
      }

      protected Object[] conditional_H002G3( IGxContext context ,
                                             string A114TotTipo ,
                                             GxSimpleCollection<string> AV69Contabilidad_lineaswwds_9_tftottipo_sels ,
                                             short A1828RubLinSts ,
                                             GxSimpleCollection<short> AV82Contabilidad_lineaswwds_22_tfrublinsts_sels ,
                                             string AV61Contabilidad_lineaswwds_1_dynamicfiltersselector1 ,
                                             string AV62Contabilidad_lineaswwds_2_tottipo1 ,
                                             bool AV63Contabilidad_lineaswwds_3_dynamicfiltersenabled2 ,
                                             string AV64Contabilidad_lineaswwds_4_dynamicfiltersselector2 ,
                                             string AV65Contabilidad_lineaswwds_5_tottipo2 ,
                                             bool AV66Contabilidad_lineaswwds_6_dynamicfiltersenabled3 ,
                                             string AV67Contabilidad_lineaswwds_7_dynamicfiltersselector3 ,
                                             string AV68Contabilidad_lineaswwds_8_tottipo3 ,
                                             int AV69Contabilidad_lineaswwds_9_tftottipo_sels_Count ,
                                             int AV70Contabilidad_lineaswwds_10_tftotrub ,
                                             int AV71Contabilidad_lineaswwds_11_tftotrub_to ,
                                             int AV72Contabilidad_lineaswwds_12_tfrubcod ,
                                             int AV73Contabilidad_lineaswwds_13_tfrubcod_to ,
                                             int AV74Contabilidad_lineaswwds_14_tfrublincod ,
                                             int AV75Contabilidad_lineaswwds_15_tfrublincod_to ,
                                             string AV77Contabilidad_lineaswwds_17_tfrublindsc_sel ,
                                             string AV76Contabilidad_lineaswwds_16_tfrublindsc ,
                                             string AV79Contabilidad_lineaswwds_19_tfrublindsctot_sel ,
                                             string AV78Contabilidad_lineaswwds_18_tfrublindsctot ,
                                             short AV80Contabilidad_lineaswwds_20_tfrublinord ,
                                             short AV81Contabilidad_lineaswwds_21_tfrublinord_to ,
                                             int AV82Contabilidad_lineaswwds_22_tfrublinsts_sels_Count ,
                                             int A115TotRub ,
                                             int A116RubCod ,
                                             int A118RubLinCod ,
                                             string A1826RubLinDsc ,
                                             string A1827RubLinDscTot ,
                                             short A119RubLinOrd ,
                                             short AV13OrderedBy ,
                                             bool AV14OrderedDsc )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int7 = new short[15];
         Object[] GXv_Object8 = new Object[2];
         scmdbuf = "SELECT COUNT(*) FROM [CBRUBROSL]";
         if ( ( StringUtil.StrCmp(AV61Contabilidad_lineaswwds_1_dynamicfiltersselector1, "TOTTIPO") == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV62Contabilidad_lineaswwds_2_tottipo1)) ) )
         {
            AddWhere(sWhereString, "([TotTipo] = @AV62Contabilidad_lineaswwds_2_tottipo1)");
         }
         else
         {
            GXv_int7[0] = 1;
         }
         if ( AV63Contabilidad_lineaswwds_3_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV64Contabilidad_lineaswwds_4_dynamicfiltersselector2, "TOTTIPO") == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV65Contabilidad_lineaswwds_5_tottipo2)) ) )
         {
            AddWhere(sWhereString, "([TotTipo] = @AV65Contabilidad_lineaswwds_5_tottipo2)");
         }
         else
         {
            GXv_int7[1] = 1;
         }
         if ( AV66Contabilidad_lineaswwds_6_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV67Contabilidad_lineaswwds_7_dynamicfiltersselector3, "TOTTIPO") == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV68Contabilidad_lineaswwds_8_tottipo3)) ) )
         {
            AddWhere(sWhereString, "([TotTipo] = @AV68Contabilidad_lineaswwds_8_tottipo3)");
         }
         else
         {
            GXv_int7[2] = 1;
         }
         if ( AV69Contabilidad_lineaswwds_9_tftottipo_sels_Count > 0 )
         {
            AddWhere(sWhereString, "("+new GxDbmsUtils( new GxSqlServer()).ValueList(AV69Contabilidad_lineaswwds_9_tftottipo_sels, "[TotTipo] IN (", ")")+")");
         }
         if ( ! (0==AV70Contabilidad_lineaswwds_10_tftotrub) )
         {
            AddWhere(sWhereString, "([TotRub] >= @AV70Contabilidad_lineaswwds_10_tftotrub)");
         }
         else
         {
            GXv_int7[3] = 1;
         }
         if ( ! (0==AV71Contabilidad_lineaswwds_11_tftotrub_to) )
         {
            AddWhere(sWhereString, "([TotRub] <= @AV71Contabilidad_lineaswwds_11_tftotrub_to)");
         }
         else
         {
            GXv_int7[4] = 1;
         }
         if ( ! (0==AV72Contabilidad_lineaswwds_12_tfrubcod) )
         {
            AddWhere(sWhereString, "([RubCod] >= @AV72Contabilidad_lineaswwds_12_tfrubcod)");
         }
         else
         {
            GXv_int7[5] = 1;
         }
         if ( ! (0==AV73Contabilidad_lineaswwds_13_tfrubcod_to) )
         {
            AddWhere(sWhereString, "([RubCod] <= @AV73Contabilidad_lineaswwds_13_tfrubcod_to)");
         }
         else
         {
            GXv_int7[6] = 1;
         }
         if ( ! (0==AV74Contabilidad_lineaswwds_14_tfrublincod) )
         {
            AddWhere(sWhereString, "([RubLinCod] >= @AV74Contabilidad_lineaswwds_14_tfrublincod)");
         }
         else
         {
            GXv_int7[7] = 1;
         }
         if ( ! (0==AV75Contabilidad_lineaswwds_15_tfrublincod_to) )
         {
            AddWhere(sWhereString, "([RubLinCod] <= @AV75Contabilidad_lineaswwds_15_tfrublincod_to)");
         }
         else
         {
            GXv_int7[8] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV77Contabilidad_lineaswwds_17_tfrublindsc_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV76Contabilidad_lineaswwds_16_tfrublindsc)) ) )
         {
            AddWhere(sWhereString, "([RubLinDsc] like @lV76Contabilidad_lineaswwds_16_tfrublindsc)");
         }
         else
         {
            GXv_int7[9] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV77Contabilidad_lineaswwds_17_tfrublindsc_sel)) )
         {
            AddWhere(sWhereString, "([RubLinDsc] = @AV77Contabilidad_lineaswwds_17_tfrublindsc_sel)");
         }
         else
         {
            GXv_int7[10] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV79Contabilidad_lineaswwds_19_tfrublindsctot_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV78Contabilidad_lineaswwds_18_tfrublindsctot)) ) )
         {
            AddWhere(sWhereString, "([RubLinDscTot] like @lV78Contabilidad_lineaswwds_18_tfrublindsctot)");
         }
         else
         {
            GXv_int7[11] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV79Contabilidad_lineaswwds_19_tfrublindsctot_sel)) )
         {
            AddWhere(sWhereString, "([RubLinDscTot] = @AV79Contabilidad_lineaswwds_19_tfrublindsctot_sel)");
         }
         else
         {
            GXv_int7[12] = 1;
         }
         if ( ! (0==AV80Contabilidad_lineaswwds_20_tfrublinord) )
         {
            AddWhere(sWhereString, "([RubLinOrd] >= @AV80Contabilidad_lineaswwds_20_tfrublinord)");
         }
         else
         {
            GXv_int7[13] = 1;
         }
         if ( ! (0==AV81Contabilidad_lineaswwds_21_tfrublinord_to) )
         {
            AddWhere(sWhereString, "([RubLinOrd] <= @AV81Contabilidad_lineaswwds_21_tfrublinord_to)");
         }
         else
         {
            GXv_int7[14] = 1;
         }
         if ( AV82Contabilidad_lineaswwds_22_tfrublinsts_sels_Count > 0 )
         {
            AddWhere(sWhereString, "("+new GxDbmsUtils( new GxSqlServer()).ValueList(AV82Contabilidad_lineaswwds_22_tfrublinsts_sels, "[RubLinSts] IN (", ")")+")");
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
         else if ( ( AV13OrderedBy == 6 ) && ! AV14OrderedDsc )
         {
            scmdbuf += "";
         }
         else if ( ( AV13OrderedBy == 6 ) && ( AV14OrderedDsc ) )
         {
            scmdbuf += "";
         }
         else if ( ( AV13OrderedBy == 7 ) && ! AV14OrderedDsc )
         {
            scmdbuf += "";
         }
         else if ( ( AV13OrderedBy == 7 ) && ( AV14OrderedDsc ) )
         {
            scmdbuf += "";
         }
         else if ( ( AV13OrderedBy == 8 ) && ! AV14OrderedDsc )
         {
            scmdbuf += "";
         }
         else if ( ( AV13OrderedBy == 8 ) && ( AV14OrderedDsc ) )
         {
            scmdbuf += "";
         }
         else if ( ( AV13OrderedBy == 9 ) && ! AV14OrderedDsc )
         {
            scmdbuf += "";
         }
         else if ( ( AV13OrderedBy == 9 ) && ( AV14OrderedDsc ) )
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
                     return conditional_H002G2(context, (string)dynConstraints[0] , (GxSimpleCollection<string>)dynConstraints[1] , (short)dynConstraints[2] , (GxSimpleCollection<short>)dynConstraints[3] , (string)dynConstraints[4] , (string)dynConstraints[5] , (bool)dynConstraints[6] , (string)dynConstraints[7] , (string)dynConstraints[8] , (bool)dynConstraints[9] , (string)dynConstraints[10] , (string)dynConstraints[11] , (int)dynConstraints[12] , (int)dynConstraints[13] , (int)dynConstraints[14] , (int)dynConstraints[15] , (int)dynConstraints[16] , (int)dynConstraints[17] , (int)dynConstraints[18] , (string)dynConstraints[19] , (string)dynConstraints[20] , (string)dynConstraints[21] , (string)dynConstraints[22] , (short)dynConstraints[23] , (short)dynConstraints[24] , (int)dynConstraints[25] , (int)dynConstraints[26] , (int)dynConstraints[27] , (int)dynConstraints[28] , (string)dynConstraints[29] , (string)dynConstraints[30] , (short)dynConstraints[31] , (short)dynConstraints[32] , (bool)dynConstraints[33] );
               case 1 :
                     return conditional_H002G3(context, (string)dynConstraints[0] , (GxSimpleCollection<string>)dynConstraints[1] , (short)dynConstraints[2] , (GxSimpleCollection<short>)dynConstraints[3] , (string)dynConstraints[4] , (string)dynConstraints[5] , (bool)dynConstraints[6] , (string)dynConstraints[7] , (string)dynConstraints[8] , (bool)dynConstraints[9] , (string)dynConstraints[10] , (string)dynConstraints[11] , (int)dynConstraints[12] , (int)dynConstraints[13] , (int)dynConstraints[14] , (int)dynConstraints[15] , (int)dynConstraints[16] , (int)dynConstraints[17] , (int)dynConstraints[18] , (string)dynConstraints[19] , (string)dynConstraints[20] , (string)dynConstraints[21] , (string)dynConstraints[22] , (short)dynConstraints[23] , (short)dynConstraints[24] , (int)dynConstraints[25] , (int)dynConstraints[26] , (int)dynConstraints[27] , (int)dynConstraints[28] , (string)dynConstraints[29] , (string)dynConstraints[30] , (short)dynConstraints[31] , (short)dynConstraints[32] , (bool)dynConstraints[33] );
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
          Object[] prmH002G2;
          prmH002G2 = new Object[] {
          new ParDef("@AV62Contabilidad_lineaswwds_2_tottipo1",GXType.NChar,3,0) ,
          new ParDef("@AV65Contabilidad_lineaswwds_5_tottipo2",GXType.NChar,3,0) ,
          new ParDef("@AV68Contabilidad_lineaswwds_8_tottipo3",GXType.NChar,3,0) ,
          new ParDef("@AV70Contabilidad_lineaswwds_10_tftotrub",GXType.Int32,6,0) ,
          new ParDef("@AV71Contabilidad_lineaswwds_11_tftotrub_to",GXType.Int32,6,0) ,
          new ParDef("@AV72Contabilidad_lineaswwds_12_tfrubcod",GXType.Int32,6,0) ,
          new ParDef("@AV73Contabilidad_lineaswwds_13_tfrubcod_to",GXType.Int32,6,0) ,
          new ParDef("@AV74Contabilidad_lineaswwds_14_tfrublincod",GXType.Int32,6,0) ,
          new ParDef("@AV75Contabilidad_lineaswwds_15_tfrublincod_to",GXType.Int32,6,0) ,
          new ParDef("@lV76Contabilidad_lineaswwds_16_tfrublindsc",GXType.NChar,100,0) ,
          new ParDef("@AV77Contabilidad_lineaswwds_17_tfrublindsc_sel",GXType.NChar,100,0) ,
          new ParDef("@lV78Contabilidad_lineaswwds_18_tfrublindsctot",GXType.NChar,100,0) ,
          new ParDef("@AV79Contabilidad_lineaswwds_19_tfrublindsctot_sel",GXType.NChar,100,0) ,
          new ParDef("@AV80Contabilidad_lineaswwds_20_tfrublinord",GXType.Int16,2,0) ,
          new ParDef("@AV81Contabilidad_lineaswwds_21_tfrublinord_to",GXType.Int16,2,0) ,
          new ParDef("@GXPagingFrom2",GXType.Int32,9,0) ,
          new ParDef("@GXPagingTo2",GXType.Int32,9,0) ,
          new ParDef("@GXPagingTo2",GXType.Int32,9,0)
          };
          Object[] prmH002G3;
          prmH002G3 = new Object[] {
          new ParDef("@AV62Contabilidad_lineaswwds_2_tottipo1",GXType.NChar,3,0) ,
          new ParDef("@AV65Contabilidad_lineaswwds_5_tottipo2",GXType.NChar,3,0) ,
          new ParDef("@AV68Contabilidad_lineaswwds_8_tottipo3",GXType.NChar,3,0) ,
          new ParDef("@AV70Contabilidad_lineaswwds_10_tftotrub",GXType.Int32,6,0) ,
          new ParDef("@AV71Contabilidad_lineaswwds_11_tftotrub_to",GXType.Int32,6,0) ,
          new ParDef("@AV72Contabilidad_lineaswwds_12_tfrubcod",GXType.Int32,6,0) ,
          new ParDef("@AV73Contabilidad_lineaswwds_13_tfrubcod_to",GXType.Int32,6,0) ,
          new ParDef("@AV74Contabilidad_lineaswwds_14_tfrublincod",GXType.Int32,6,0) ,
          new ParDef("@AV75Contabilidad_lineaswwds_15_tfrublincod_to",GXType.Int32,6,0) ,
          new ParDef("@lV76Contabilidad_lineaswwds_16_tfrublindsc",GXType.NChar,100,0) ,
          new ParDef("@AV77Contabilidad_lineaswwds_17_tfrublindsc_sel",GXType.NChar,100,0) ,
          new ParDef("@lV78Contabilidad_lineaswwds_18_tfrublindsctot",GXType.NChar,100,0) ,
          new ParDef("@AV79Contabilidad_lineaswwds_19_tfrublindsctot_sel",GXType.NChar,100,0) ,
          new ParDef("@AV80Contabilidad_lineaswwds_20_tfrublinord",GXType.Int16,2,0) ,
          new ParDef("@AV81Contabilidad_lineaswwds_21_tfrublinord_to",GXType.Int16,2,0)
          };
          def= new CursorDef[] {
              new CursorDef("H002G2", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH002G2,11, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("H002G3", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH002G3,1, GxCacheFrequency.OFF ,true,false )
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
                ((short[]) buf[1])[0] = rslt.getShort(2);
                ((string[]) buf[2])[0] = rslt.getString(3, 100);
                ((string[]) buf[3])[0] = rslt.getString(4, 100);
                ((int[]) buf[4])[0] = rslt.getInt(5);
                ((int[]) buf[5])[0] = rslt.getInt(6);
                ((int[]) buf[6])[0] = rslt.getInt(7);
                ((string[]) buf[7])[0] = rslt.getString(8, 3);
                return;
             case 1 :
                ((long[]) buf[0])[0] = rslt.getLong(1);
                return;
       }
    }

 }

}
