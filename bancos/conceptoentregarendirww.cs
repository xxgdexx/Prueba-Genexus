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
namespace GeneXus.Programs.bancos {
   public class conceptoentregarendirww : GXDataArea
   {
      public conceptoentregarendirww( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDataStore2 = context.GetDataStore("DataStore2");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusTheme");
      }

      public conceptoentregarendirww( IGxContext context )
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
         cmbConEntSts = new GXCombobox();
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
               AV17ConEntDsc1 = GetPar( "ConEntDsc1");
               AV49CueCod1 = GetPar( "CueCod1");
               cmbavDynamicfiltersselector2.FromJSonString( GetNextPar( ));
               AV19DynamicFiltersSelector2 = GetPar( "DynamicFiltersSelector2");
               cmbavDynamicfiltersoperator2.FromJSonString( GetNextPar( ));
               AV20DynamicFiltersOperator2 = (short)(NumberUtil.Val( GetPar( "DynamicFiltersOperator2"), "."));
               AV21ConEntDsc2 = GetPar( "ConEntDsc2");
               AV50CueCod2 = GetPar( "CueCod2");
               cmbavDynamicfiltersselector3.FromJSonString( GetNextPar( ));
               AV23DynamicFiltersSelector3 = GetPar( "DynamicFiltersSelector3");
               cmbavDynamicfiltersoperator3.FromJSonString( GetNextPar( ));
               AV24DynamicFiltersOperator3 = (short)(NumberUtil.Val( GetPar( "DynamicFiltersOperator3"), "."));
               AV25ConEntDsc3 = GetPar( "ConEntDsc3");
               AV51CueCod3 = GetPar( "CueCod3");
               AV18DynamicFiltersEnabled2 = StringUtil.StrToBool( GetPar( "DynamicFiltersEnabled2"));
               AV22DynamicFiltersEnabled3 = StringUtil.StrToBool( GetPar( "DynamicFiltersEnabled3"));
               AV56Pgmname = GetPar( "Pgmname");
               AV31TFConEntCod = (int)(NumberUtil.Val( GetPar( "TFConEntCod"), "."));
               AV32TFConEntCod_To = (int)(NumberUtil.Val( GetPar( "TFConEntCod_To"), "."));
               AV33TFConEntDsc = GetPar( "TFConEntDsc");
               AV34TFConEntDsc_Sel = GetPar( "TFConEntDsc_Sel");
               AV35TFCueCod = GetPar( "TFCueCod");
               AV36TFCueCod_Sel = GetPar( "TFCueCod_Sel");
               AV37TFCueDsc = GetPar( "TFCueDsc");
               AV38TFCueDsc_Sel = GetPar( "TFCueDsc_Sel");
               ajax_req_read_hidden_sdt(GetNextPar( ), AV53TFConEntSts_Sels);
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
               gxgrGrid_refresh( subGrid_Rows, AV15DynamicFiltersSelector1, AV16DynamicFiltersOperator1, AV17ConEntDsc1, AV49CueCod1, AV19DynamicFiltersSelector2, AV20DynamicFiltersOperator2, AV21ConEntDsc2, AV50CueCod2, AV23DynamicFiltersSelector3, AV24DynamicFiltersOperator3, AV25ConEntDsc3, AV51CueCod3, AV18DynamicFiltersEnabled2, AV22DynamicFiltersEnabled3, AV56Pgmname, AV31TFConEntCod, AV32TFConEntCod_To, AV33TFConEntDsc, AV34TFConEntDsc_Sel, AV35TFCueCod, AV36TFCueCod_Sel, AV37TFCueDsc, AV38TFCueDsc_Sel, AV53TFConEntSts_Sels, AV13OrderedBy, AV14OrderedDsc, AV10GridState, AV27DynamicFiltersIgnoreFirst, AV26DynamicFiltersRemoving) ;
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
         PA242( ) ;
         gxajaxcallmode = (short)((isAjaxCallMode( ) ? 1 : 0));
         if ( ( gxajaxcallmode == 0 ) && ( GxWebError == 0 ) )
         {
            START242( ) ;
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
         context.AddJavascriptSource("gxcfg.js", "?202281810301496", false, true);
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
         context.WriteHtmlTextNl( "<form id=\"MAINFORM\" autocomplete=\"off\" name=\"MAINFORM\" method=\"post\" tabindex=-1  class=\"form-horizontal Form\" data-gx-class=\"form-horizontal Form\" novalidate action=\""+formatLink("bancos.conceptoentregarendirww.aspx") +"\">") ;
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
         GxWebStd.gx_hidden_field( context, "gxhash_vPGMNAME", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( AV56Pgmname, "")), context));
         GXKey = Crypto.GetSiteKey( );
      }

      protected void SendCloseFormHiddens( )
      {
         /* Send hidden variables. */
         GxWebStd.gx_hidden_field( context, "GXH_vDYNAMICFILTERSSELECTOR1", AV15DynamicFiltersSelector1);
         GxWebStd.gx_hidden_field( context, "GXH_vDYNAMICFILTERSOPERATOR1", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV16DynamicFiltersOperator1), 4, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "GXH_vCONENTDSC1", StringUtil.RTrim( AV17ConEntDsc1));
         GxWebStd.gx_hidden_field( context, "GXH_vCUECOD1", StringUtil.RTrim( AV49CueCod1));
         GxWebStd.gx_hidden_field( context, "GXH_vDYNAMICFILTERSSELECTOR2", AV19DynamicFiltersSelector2);
         GxWebStd.gx_hidden_field( context, "GXH_vDYNAMICFILTERSOPERATOR2", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV20DynamicFiltersOperator2), 4, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "GXH_vCONENTDSC2", StringUtil.RTrim( AV21ConEntDsc2));
         GxWebStd.gx_hidden_field( context, "GXH_vCUECOD2", StringUtil.RTrim( AV50CueCod2));
         GxWebStd.gx_hidden_field( context, "GXH_vDYNAMICFILTERSSELECTOR3", AV23DynamicFiltersSelector3);
         GxWebStd.gx_hidden_field( context, "GXH_vDYNAMICFILTERSOPERATOR3", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV24DynamicFiltersOperator3), 4, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "GXH_vCONENTDSC3", StringUtil.RTrim( AV25ConEntDsc3));
         GxWebStd.gx_hidden_field( context, "GXH_vCUECOD3", StringUtil.RTrim( AV51CueCod3));
         /* Send saved values. */
         send_integrity_footer_hashes( ) ;
         GxWebStd.gx_hidden_field( context, "nRC_GXsfl_110", StringUtil.LTrim( StringUtil.NToC( (decimal)(nRC_GXsfl_110), 8, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "vGRIDCURRENTPAGE", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV43GridCurrentPage), 10, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "vGRIDPAGECOUNT", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV44GridPageCount), 10, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "vGRIDAPPLIEDFILTERS", AV45GridAppliedFilters);
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "vAGEXPORTDATA", AV47AGExportData);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt("vAGEXPORTDATA", AV47AGExportData);
         }
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "vDDO_TITLESETTINGSICONS", AV41DDO_TitleSettingsIcons);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt("vDDO_TITLESETTINGSICONS", AV41DDO_TitleSettingsIcons);
         }
         GxWebStd.gx_boolean_hidden_field( context, "vDYNAMICFILTERSENABLED2", AV18DynamicFiltersEnabled2);
         GxWebStd.gx_boolean_hidden_field( context, "vDYNAMICFILTERSENABLED3", AV22DynamicFiltersEnabled3);
         GxWebStd.gx_hidden_field( context, "vPGMNAME", StringUtil.RTrim( AV56Pgmname));
         GxWebStd.gx_hidden_field( context, "gxhash_vPGMNAME", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( AV56Pgmname, "")), context));
         GxWebStd.gx_hidden_field( context, "vTFCONENTCOD", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV31TFConEntCod), 6, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "vTFCONENTCOD_TO", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV32TFConEntCod_To), 6, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "vTFCONENTDSC", StringUtil.RTrim( AV33TFConEntDsc));
         GxWebStd.gx_hidden_field( context, "vTFCONENTDSC_SEL", StringUtil.RTrim( AV34TFConEntDsc_Sel));
         GxWebStd.gx_hidden_field( context, "vTFCUECOD", StringUtil.RTrim( AV35TFCueCod));
         GxWebStd.gx_hidden_field( context, "vTFCUECOD_SEL", StringUtil.RTrim( AV36TFCueCod_Sel));
         GxWebStd.gx_hidden_field( context, "vTFCUEDSC", StringUtil.RTrim( AV37TFCueDsc));
         GxWebStd.gx_hidden_field( context, "vTFCUEDSC_SEL", StringUtil.RTrim( AV38TFCueDsc_Sel));
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "vTFCONENTSTS_SELS", AV53TFConEntSts_Sels);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt("vTFCONENTSTS_SELS", AV53TFConEntSts_Sels);
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
         GxWebStd.gx_hidden_field( context, "vTFCONENTSTS_SELSJSON", AV52TFConEntSts_SelsJson);
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
            WE242( ) ;
            context.WriteHtmlText( "</div>") ;
         }
      }

      public override void DispatchEvents( )
      {
         EVT242( ) ;
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
         return formatLink("bancos.conceptoentregarendirww.aspx")  ;
      }

      public override string GetPgmname( )
      {
         return "Bancos.ConceptoEntregaRendirWW" ;
      }

      public override string GetPgmdesc( )
      {
         return " Conceptos Entrega Rendir Cuenta" ;
      }

      protected void WB240( )
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
            GxWebStd.gx_button_ctrl( context, bttBtninsert_Internalname, "gx.evt.setGridEvt("+StringUtil.Str( (decimal)(110), 3, 0)+","+"null"+");", "Agregar", bttBtninsert_Jsonclick, 5, "Agregar", "", StyleString, ClassString, 1, 1, "standard", "'"+""+"'"+",false,"+"'"+"E\\'DOINSERT\\'."+"'", TempTags, "", context.GetButtonType( ), "HLP_Bancos\\ConceptoEntregaRendirWW.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "left", "top", "", "", "div");
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 21,'',false,'',0)\"";
            ClassString = "ColumnsSelector";
            StyleString = "";
            GxWebStd.gx_button_ctrl( context, bttBtnagexport_Internalname, "gx.evt.setGridEvt("+StringUtil.Str( (decimal)(110), 3, 0)+","+"null"+");", "Reportes", bttBtnagexport_Jsonclick, 0, "Reportes", "", StyleString, ClassString, 1, 0, "standard", "'"+""+"'"+",false,"+"'"+""+"'", TempTags, "", context.GetButtonType( ), "HLP_Bancos\\ConceptoEntregaRendirWW.htm");
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
            wb_table1_25_242( true) ;
         }
         else
         {
            wb_table1_25_242( false) ;
         }
         return  ;
      }

      protected void wb_table1_25_242e( bool wbgen )
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
               context.WriteHtmlText( "<th align=\""+"right"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+""+""+"\" "+">") ;
               context.SendWebValue( "Codigo") ;
               context.WriteHtmlTextNl( "</th>") ;
               context.WriteHtmlText( "<th align=\""+"left"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+""+""+"\" "+">") ;
               context.SendWebValue( "Concepto Entrega Rendir") ;
               context.WriteHtmlTextNl( "</th>") ;
               context.WriteHtmlText( "<th align=\""+"left"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+""+""+"\" "+">") ;
               context.SendWebValue( "Cuenta Contable") ;
               context.WriteHtmlTextNl( "</th>") ;
               context.WriteHtmlText( "<th align=\""+"left"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+""+""+"\" "+">") ;
               context.SendWebValue( "Descripci?n de Cuenta") ;
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
               GridColumn.AddObjectProperty("Value", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV46GridActions), 4, 0, ".", "")));
               GridContainer.AddColumnProperties(GridColumn);
               GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
               GridColumn.AddObjectProperty("Value", StringUtil.LTrim( StringUtil.NToC( (decimal)(A376ConEntCod), 6, 0, ".", "")));
               GridContainer.AddColumnProperties(GridColumn);
               GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
               GridColumn.AddObjectProperty("Value", StringUtil.RTrim( A749ConEntDsc));
               GridColumn.AddObjectProperty("Link", StringUtil.RTrim( edtConEntDsc_Link));
               GridContainer.AddColumnProperties(GridColumn);
               GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
               GridColumn.AddObjectProperty("Value", StringUtil.RTrim( A91CueCod));
               GridContainer.AddColumnProperties(GridColumn);
               GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
               GridColumn.AddObjectProperty("Value", StringUtil.RTrim( A860CueDsc));
               GridColumn.AddObjectProperty("Link", StringUtil.RTrim( edtCueDsc_Link));
               GridContainer.AddColumnProperties(GridColumn);
               GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
               GridColumn.AddObjectProperty("Value", StringUtil.LTrim( StringUtil.NToC( (decimal)(A750ConEntSts), 1, 0, ".", "")));
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
            ucGridpaginationbar.SetProperty("CurrentPage", AV43GridCurrentPage);
            ucGridpaginationbar.SetProperty("PageCount", AV44GridPageCount);
            ucGridpaginationbar.SetProperty("AppliedFilters", AV45GridAppliedFilters);
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
            ucDdo_agexport.SetProperty("DropDownOptionsData", AV47AGExportData);
            ucDdo_agexport.Render(context, "dvelop.gxbootstrap.ddoregular", Ddo_agexport_Internalname, "DDO_AGEXPORTContainer");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblJsdynamicfilters_Internalname, lblJsdynamicfilters_Caption, "", "", lblJsdynamicfilters_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "", 0, "", 1, 1, 0, 1, "HLP_Bancos\\ConceptoEntregaRendirWW.htm");
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
            ucDdo_grid.SetProperty("DropDownOptionsTitleSettingsIcons", AV41DDO_TitleSettingsIcons);
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

      protected void START242( )
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
            Form.Meta.addItem("description", " Conceptos Entrega Rendir Cuenta", 0) ;
         }
         context.wjLoc = "";
         context.nUserReturn = 0;
         context.wbHandled = 0;
         if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
         {
         }
         wbErr = false;
         STRUP240( ) ;
      }

      protected void WS242( )
      {
         START242( ) ;
         EVT242( ) ;
      }

      protected void EVT242( )
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
                              E11242 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "GRIDPAGINATIONBAR.CHANGEROWSPERPAGE") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              E12242 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "DDO_AGEXPORT.ONOPTIONCLICKED") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              E13242 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "DDO_GRID.ONOPTIONCLICKED") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              E14242 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "'REMOVEDYNAMICFILTERS1'") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              /* Execute user event: 'RemoveDynamicFilters1' */
                              E15242 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "'REMOVEDYNAMICFILTERS2'") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              /* Execute user event: 'RemoveDynamicFilters2' */
                              E16242 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "'REMOVEDYNAMICFILTERS3'") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              /* Execute user event: 'RemoveDynamicFilters3' */
                              E17242 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "'DOINSERT'") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              /* Execute user event: 'DoInsert' */
                              E18242 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "'ADDDYNAMICFILTERS1'") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              /* Execute user event: 'AddDynamicFilters1' */
                              E19242 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "VDYNAMICFILTERSSELECTOR1.CLICK") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              E20242 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "'ADDDYNAMICFILTERS2'") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              /* Execute user event: 'AddDynamicFilters2' */
                              E21242 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "VDYNAMICFILTERSSELECTOR2.CLICK") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              E22242 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "VDYNAMICFILTERSSELECTOR3.CLICK") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              E23242 ();
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
                              AV46GridActions = (short)(NumberUtil.Val( cgiGet( cmbavGridactions_Internalname), "."));
                              AssignAttri("", false, cmbavGridactions_Internalname, StringUtil.LTrimStr( (decimal)(AV46GridActions), 4, 0));
                              A376ConEntCod = (int)(context.localUtil.CToN( cgiGet( edtConEntCod_Internalname), ".", ","));
                              A749ConEntDsc = cgiGet( edtConEntDsc_Internalname);
                              A91CueCod = cgiGet( edtCueCod_Internalname);
                              A860CueDsc = cgiGet( edtCueDsc_Internalname);
                              cmbConEntSts.Name = cmbConEntSts_Internalname;
                              cmbConEntSts.CurrentValue = cgiGet( cmbConEntSts_Internalname);
                              A750ConEntSts = (short)(NumberUtil.Val( cgiGet( cmbConEntSts_Internalname), "."));
                              sEvtType = StringUtil.Right( sEvt, 1);
                              if ( StringUtil.StrCmp(sEvtType, ".") == 0 )
                              {
                                 sEvt = StringUtil.Left( sEvt, (short)(StringUtil.Len( sEvt)-1));
                                 if ( StringUtil.StrCmp(sEvt, "START") == 0 )
                                 {
                                    context.wbHandled = 1;
                                    dynload_actions( ) ;
                                    /* Execute user event: Start */
                                    E24242 ();
                                 }
                                 else if ( StringUtil.StrCmp(sEvt, "REFRESH") == 0 )
                                 {
                                    context.wbHandled = 1;
                                    dynload_actions( ) ;
                                    /* Execute user event: Refresh */
                                    E25242 ();
                                 }
                                 else if ( StringUtil.StrCmp(sEvt, "GRID.LOAD") == 0 )
                                 {
                                    context.wbHandled = 1;
                                    dynload_actions( ) ;
                                    E26242 ();
                                 }
                                 else if ( StringUtil.StrCmp(sEvt, "VGRIDACTIONS.CLICK") == 0 )
                                 {
                                    context.wbHandled = 1;
                                    dynload_actions( ) ;
                                    E27242 ();
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
                                       /* Set Refresh If Conentdsc1 Changed */
                                       if ( StringUtil.StrCmp(cgiGet( "GXH_vCONENTDSC1"), AV17ConEntDsc1) != 0 )
                                       {
                                          Rfr0gs = true;
                                       }
                                       /* Set Refresh If Cuecod1 Changed */
                                       if ( StringUtil.StrCmp(cgiGet( "GXH_vCUECOD1"), AV49CueCod1) != 0 )
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
                                       /* Set Refresh If Conentdsc2 Changed */
                                       if ( StringUtil.StrCmp(cgiGet( "GXH_vCONENTDSC2"), AV21ConEntDsc2) != 0 )
                                       {
                                          Rfr0gs = true;
                                       }
                                       /* Set Refresh If Cuecod2 Changed */
                                       if ( StringUtil.StrCmp(cgiGet( "GXH_vCUECOD2"), AV50CueCod2) != 0 )
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
                                       /* Set Refresh If Conentdsc3 Changed */
                                       if ( StringUtil.StrCmp(cgiGet( "GXH_vCONENTDSC3"), AV25ConEntDsc3) != 0 )
                                       {
                                          Rfr0gs = true;
                                       }
                                       /* Set Refresh If Cuecod3 Changed */
                                       if ( StringUtil.StrCmp(cgiGet( "GXH_vCUECOD3"), AV51CueCod3) != 0 )
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

      protected void WE242( )
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

      protected void PA242( )
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
                                       string AV17ConEntDsc1 ,
                                       string AV49CueCod1 ,
                                       string AV19DynamicFiltersSelector2 ,
                                       short AV20DynamicFiltersOperator2 ,
                                       string AV21ConEntDsc2 ,
                                       string AV50CueCod2 ,
                                       string AV23DynamicFiltersSelector3 ,
                                       short AV24DynamicFiltersOperator3 ,
                                       string AV25ConEntDsc3 ,
                                       string AV51CueCod3 ,
                                       bool AV18DynamicFiltersEnabled2 ,
                                       bool AV22DynamicFiltersEnabled3 ,
                                       string AV56Pgmname ,
                                       int AV31TFConEntCod ,
                                       int AV32TFConEntCod_To ,
                                       string AV33TFConEntDsc ,
                                       string AV34TFConEntDsc_Sel ,
                                       string AV35TFCueCod ,
                                       string AV36TFCueCod_Sel ,
                                       string AV37TFCueDsc ,
                                       string AV38TFCueDsc_Sel ,
                                       GxSimpleCollection<short> AV53TFConEntSts_Sels ,
                                       short AV13OrderedBy ,
                                       bool AV14OrderedDsc ,
                                       GeneXus.Programs.wwpbaseobjects.SdtWWPGridState AV10GridState ,
                                       bool AV27DynamicFiltersIgnoreFirst ,
                                       bool AV26DynamicFiltersRemoving )
      {
         initialize_formulas( ) ;
         GxWebStd.set_html_headers( context, 0, "", "");
         /* Execute user event: Refresh */
         E25242 ();
         GRID_nCurrentRecord = 0;
         RF242( ) ;
         GXKey = Crypto.GetSiteKey( );
         send_integrity_footer_hashes( ) ;
         GXKey = Crypto.GetSiteKey( );
         /* End function gxgrGrid_refresh */
      }

      protected void send_integrity_hashes( )
      {
         GxWebStd.gx_hidden_field( context, "gxhash_CONENTCOD", GetSecureSignedToken( "", context.localUtil.Format( (decimal)(A376ConEntCod), "ZZZZZ9"), context));
         GxWebStd.gx_hidden_field( context, "CONENTCOD", StringUtil.LTrim( StringUtil.NToC( (decimal)(A376ConEntCod), 6, 0, ".", "")));
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
         RF242( ) ;
         if ( isFullAjaxMode( ) )
         {
            send_integrity_footer_hashes( ) ;
         }
      }

      protected void initialize_formulas( )
      {
         /* GeneXus formulas. */
         AV56Pgmname = "Bancos.ConceptoEntregaRendirWW";
         context.Gx_err = 0;
      }

      protected void RF242( )
      {
         initialize_formulas( ) ;
         clear_multi_value_controls( ) ;
         if ( isAjaxCallMode( ) )
         {
            GridContainer.ClearRows();
         }
         wbStart = 110;
         /* Execute user event: Refresh */
         E25242 ();
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
                                                 A750ConEntSts ,
                                                 AV79Bancos_conceptoentregarendirwwds_23_tfconentsts_sels ,
                                                 AV57Bancos_conceptoentregarendirwwds_1_dynamicfiltersselector1 ,
                                                 AV58Bancos_conceptoentregarendirwwds_2_dynamicfiltersoperator1 ,
                                                 AV59Bancos_conceptoentregarendirwwds_3_conentdsc1 ,
                                                 AV60Bancos_conceptoentregarendirwwds_4_cuecod1 ,
                                                 AV61Bancos_conceptoentregarendirwwds_5_dynamicfiltersenabled2 ,
                                                 AV62Bancos_conceptoentregarendirwwds_6_dynamicfiltersselector2 ,
                                                 AV63Bancos_conceptoentregarendirwwds_7_dynamicfiltersoperator2 ,
                                                 AV64Bancos_conceptoentregarendirwwds_8_conentdsc2 ,
                                                 AV65Bancos_conceptoentregarendirwwds_9_cuecod2 ,
                                                 AV66Bancos_conceptoentregarendirwwds_10_dynamicfiltersenabled3 ,
                                                 AV67Bancos_conceptoentregarendirwwds_11_dynamicfiltersselector3 ,
                                                 AV68Bancos_conceptoentregarendirwwds_12_dynamicfiltersoperator3 ,
                                                 AV69Bancos_conceptoentregarendirwwds_13_conentdsc3 ,
                                                 AV70Bancos_conceptoentregarendirwwds_14_cuecod3 ,
                                                 AV71Bancos_conceptoentregarendirwwds_15_tfconentcod ,
                                                 AV72Bancos_conceptoentregarendirwwds_16_tfconentcod_to ,
                                                 AV74Bancos_conceptoentregarendirwwds_18_tfconentdsc_sel ,
                                                 AV73Bancos_conceptoentregarendirwwds_17_tfconentdsc ,
                                                 AV76Bancos_conceptoentregarendirwwds_20_tfcuecod_sel ,
                                                 AV75Bancos_conceptoentregarendirwwds_19_tfcuecod ,
                                                 AV78Bancos_conceptoentregarendirwwds_22_tfcuedsc_sel ,
                                                 AV77Bancos_conceptoentregarendirwwds_21_tfcuedsc ,
                                                 AV79Bancos_conceptoentregarendirwwds_23_tfconentsts_sels.Count ,
                                                 A749ConEntDsc ,
                                                 A91CueCod ,
                                                 A376ConEntCod ,
                                                 A860CueDsc ,
                                                 AV13OrderedBy ,
                                                 AV14OrderedDsc } ,
                                                 new int[]{
                                                 TypeConstants.SHORT, TypeConstants.SHORT, TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.INT, TypeConstants.INT, TypeConstants.INT, TypeConstants.INT,
                                                 TypeConstants.SHORT, TypeConstants.BOOLEAN
                                                 }
            });
            lV59Bancos_conceptoentregarendirwwds_3_conentdsc1 = StringUtil.PadR( StringUtil.RTrim( AV59Bancos_conceptoentregarendirwwds_3_conentdsc1), 100, "%");
            lV59Bancos_conceptoentregarendirwwds_3_conentdsc1 = StringUtil.PadR( StringUtil.RTrim( AV59Bancos_conceptoentregarendirwwds_3_conentdsc1), 100, "%");
            lV60Bancos_conceptoentregarendirwwds_4_cuecod1 = StringUtil.PadR( StringUtil.RTrim( AV60Bancos_conceptoentregarendirwwds_4_cuecod1), 15, "%");
            lV60Bancos_conceptoentregarendirwwds_4_cuecod1 = StringUtil.PadR( StringUtil.RTrim( AV60Bancos_conceptoentregarendirwwds_4_cuecod1), 15, "%");
            lV64Bancos_conceptoentregarendirwwds_8_conentdsc2 = StringUtil.PadR( StringUtil.RTrim( AV64Bancos_conceptoentregarendirwwds_8_conentdsc2), 100, "%");
            lV64Bancos_conceptoentregarendirwwds_8_conentdsc2 = StringUtil.PadR( StringUtil.RTrim( AV64Bancos_conceptoentregarendirwwds_8_conentdsc2), 100, "%");
            lV65Bancos_conceptoentregarendirwwds_9_cuecod2 = StringUtil.PadR( StringUtil.RTrim( AV65Bancos_conceptoentregarendirwwds_9_cuecod2), 15, "%");
            lV65Bancos_conceptoentregarendirwwds_9_cuecod2 = StringUtil.PadR( StringUtil.RTrim( AV65Bancos_conceptoentregarendirwwds_9_cuecod2), 15, "%");
            lV69Bancos_conceptoentregarendirwwds_13_conentdsc3 = StringUtil.PadR( StringUtil.RTrim( AV69Bancos_conceptoentregarendirwwds_13_conentdsc3), 100, "%");
            lV69Bancos_conceptoentregarendirwwds_13_conentdsc3 = StringUtil.PadR( StringUtil.RTrim( AV69Bancos_conceptoentregarendirwwds_13_conentdsc3), 100, "%");
            lV70Bancos_conceptoentregarendirwwds_14_cuecod3 = StringUtil.PadR( StringUtil.RTrim( AV70Bancos_conceptoentregarendirwwds_14_cuecod3), 15, "%");
            lV70Bancos_conceptoentregarendirwwds_14_cuecod3 = StringUtil.PadR( StringUtil.RTrim( AV70Bancos_conceptoentregarendirwwds_14_cuecod3), 15, "%");
            lV73Bancos_conceptoentregarendirwwds_17_tfconentdsc = StringUtil.PadR( StringUtil.RTrim( AV73Bancos_conceptoentregarendirwwds_17_tfconentdsc), 100, "%");
            lV75Bancos_conceptoentregarendirwwds_19_tfcuecod = StringUtil.PadR( StringUtil.RTrim( AV75Bancos_conceptoentregarendirwwds_19_tfcuecod), 15, "%");
            lV77Bancos_conceptoentregarendirwwds_21_tfcuedsc = StringUtil.PadR( StringUtil.RTrim( AV77Bancos_conceptoentregarendirwwds_21_tfcuedsc), 100, "%");
            /* Using cursor H00242 */
            pr_default.execute(0, new Object[] {lV59Bancos_conceptoentregarendirwwds_3_conentdsc1, lV59Bancos_conceptoentregarendirwwds_3_conentdsc1, lV60Bancos_conceptoentregarendirwwds_4_cuecod1, lV60Bancos_conceptoentregarendirwwds_4_cuecod1, lV64Bancos_conceptoentregarendirwwds_8_conentdsc2, lV64Bancos_conceptoentregarendirwwds_8_conentdsc2, lV65Bancos_conceptoentregarendirwwds_9_cuecod2, lV65Bancos_conceptoentregarendirwwds_9_cuecod2, lV69Bancos_conceptoentregarendirwwds_13_conentdsc3, lV69Bancos_conceptoentregarendirwwds_13_conentdsc3, lV70Bancos_conceptoentregarendirwwds_14_cuecod3, lV70Bancos_conceptoentregarendirwwds_14_cuecod3, AV71Bancos_conceptoentregarendirwwds_15_tfconentcod, AV72Bancos_conceptoentregarendirwwds_16_tfconentcod_to, lV73Bancos_conceptoentregarendirwwds_17_tfconentdsc, AV74Bancos_conceptoentregarendirwwds_18_tfconentdsc_sel, lV75Bancos_conceptoentregarendirwwds_19_tfcuecod, AV76Bancos_conceptoentregarendirwwds_20_tfcuecod_sel, lV77Bancos_conceptoentregarendirwwds_21_tfcuedsc, AV78Bancos_conceptoentregarendirwwds_22_tfcuedsc_sel, GXPagingFrom2, GXPagingTo2, GXPagingTo2});
            nGXsfl_110_idx = 1;
            sGXsfl_110_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_110_idx), 4, 0), 4, "0");
            SubsflControlProps_1102( ) ;
            while ( ( (pr_default.getStatus(0) != 101) ) && ( ( ( subGrid_Rows == 0 ) || ( GRID_nCurrentRecord < subGrid_fnc_Recordsperpage( ) ) ) ) )
            {
               A750ConEntSts = H00242_A750ConEntSts[0];
               A860CueDsc = H00242_A860CueDsc[0];
               A91CueCod = H00242_A91CueCod[0];
               A749ConEntDsc = H00242_A749ConEntDsc[0];
               A376ConEntCod = H00242_A376ConEntCod[0];
               A860CueDsc = H00242_A860CueDsc[0];
               E26242 ();
               pr_default.readNext(0);
            }
            GRID_nEOF = (short)(((pr_default.getStatus(0) == 101) ? 1 : 0));
            GxWebStd.gx_hidden_field( context, "GRID_nEOF", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRID_nEOF), 1, 0, ".", "")));
            pr_default.close(0);
            wbEnd = 110;
            WB240( ) ;
         }
         bGXsfl_110_Refreshing = true;
      }

      protected void send_integrity_lvl_hashes242( )
      {
         GxWebStd.gx_hidden_field( context, "vPGMNAME", StringUtil.RTrim( AV56Pgmname));
         GxWebStd.gx_hidden_field( context, "gxhash_vPGMNAME", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( AV56Pgmname, "")), context));
         GxWebStd.gx_hidden_field( context, "gxhash_CONENTCOD"+"_"+sGXsfl_110_idx, GetSecureSignedToken( sGXsfl_110_idx, context.localUtil.Format( (decimal)(A376ConEntCod), "ZZZZZ9"), context));
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
         AV57Bancos_conceptoentregarendirwwds_1_dynamicfiltersselector1 = AV15DynamicFiltersSelector1;
         AV58Bancos_conceptoentregarendirwwds_2_dynamicfiltersoperator1 = AV16DynamicFiltersOperator1;
         AV59Bancos_conceptoentregarendirwwds_3_conentdsc1 = AV17ConEntDsc1;
         AV60Bancos_conceptoentregarendirwwds_4_cuecod1 = AV49CueCod1;
         AV61Bancos_conceptoentregarendirwwds_5_dynamicfiltersenabled2 = AV18DynamicFiltersEnabled2;
         AV62Bancos_conceptoentregarendirwwds_6_dynamicfiltersselector2 = AV19DynamicFiltersSelector2;
         AV63Bancos_conceptoentregarendirwwds_7_dynamicfiltersoperator2 = AV20DynamicFiltersOperator2;
         AV64Bancos_conceptoentregarendirwwds_8_conentdsc2 = AV21ConEntDsc2;
         AV65Bancos_conceptoentregarendirwwds_9_cuecod2 = AV50CueCod2;
         AV66Bancos_conceptoentregarendirwwds_10_dynamicfiltersenabled3 = AV22DynamicFiltersEnabled3;
         AV67Bancos_conceptoentregarendirwwds_11_dynamicfiltersselector3 = AV23DynamicFiltersSelector3;
         AV68Bancos_conceptoentregarendirwwds_12_dynamicfiltersoperator3 = AV24DynamicFiltersOperator3;
         AV69Bancos_conceptoentregarendirwwds_13_conentdsc3 = AV25ConEntDsc3;
         AV70Bancos_conceptoentregarendirwwds_14_cuecod3 = AV51CueCod3;
         AV71Bancos_conceptoentregarendirwwds_15_tfconentcod = AV31TFConEntCod;
         AV72Bancos_conceptoentregarendirwwds_16_tfconentcod_to = AV32TFConEntCod_To;
         AV73Bancos_conceptoentregarendirwwds_17_tfconentdsc = AV33TFConEntDsc;
         AV74Bancos_conceptoentregarendirwwds_18_tfconentdsc_sel = AV34TFConEntDsc_Sel;
         AV75Bancos_conceptoentregarendirwwds_19_tfcuecod = AV35TFCueCod;
         AV76Bancos_conceptoentregarendirwwds_20_tfcuecod_sel = AV36TFCueCod_Sel;
         AV77Bancos_conceptoentregarendirwwds_21_tfcuedsc = AV37TFCueDsc;
         AV78Bancos_conceptoentregarendirwwds_22_tfcuedsc_sel = AV38TFCueDsc_Sel;
         AV79Bancos_conceptoentregarendirwwds_23_tfconentsts_sels = AV53TFConEntSts_Sels;
         pr_default.dynParam(1, new Object[]{ new Object[]{
                                              A750ConEntSts ,
                                              AV79Bancos_conceptoentregarendirwwds_23_tfconentsts_sels ,
                                              AV57Bancos_conceptoentregarendirwwds_1_dynamicfiltersselector1 ,
                                              AV58Bancos_conceptoentregarendirwwds_2_dynamicfiltersoperator1 ,
                                              AV59Bancos_conceptoentregarendirwwds_3_conentdsc1 ,
                                              AV60Bancos_conceptoentregarendirwwds_4_cuecod1 ,
                                              AV61Bancos_conceptoentregarendirwwds_5_dynamicfiltersenabled2 ,
                                              AV62Bancos_conceptoentregarendirwwds_6_dynamicfiltersselector2 ,
                                              AV63Bancos_conceptoentregarendirwwds_7_dynamicfiltersoperator2 ,
                                              AV64Bancos_conceptoentregarendirwwds_8_conentdsc2 ,
                                              AV65Bancos_conceptoentregarendirwwds_9_cuecod2 ,
                                              AV66Bancos_conceptoentregarendirwwds_10_dynamicfiltersenabled3 ,
                                              AV67Bancos_conceptoentregarendirwwds_11_dynamicfiltersselector3 ,
                                              AV68Bancos_conceptoentregarendirwwds_12_dynamicfiltersoperator3 ,
                                              AV69Bancos_conceptoentregarendirwwds_13_conentdsc3 ,
                                              AV70Bancos_conceptoentregarendirwwds_14_cuecod3 ,
                                              AV71Bancos_conceptoentregarendirwwds_15_tfconentcod ,
                                              AV72Bancos_conceptoentregarendirwwds_16_tfconentcod_to ,
                                              AV74Bancos_conceptoentregarendirwwds_18_tfconentdsc_sel ,
                                              AV73Bancos_conceptoentregarendirwwds_17_tfconentdsc ,
                                              AV76Bancos_conceptoentregarendirwwds_20_tfcuecod_sel ,
                                              AV75Bancos_conceptoentregarendirwwds_19_tfcuecod ,
                                              AV78Bancos_conceptoentregarendirwwds_22_tfcuedsc_sel ,
                                              AV77Bancos_conceptoentregarendirwwds_21_tfcuedsc ,
                                              AV79Bancos_conceptoentregarendirwwds_23_tfconentsts_sels.Count ,
                                              A749ConEntDsc ,
                                              A91CueCod ,
                                              A376ConEntCod ,
                                              A860CueDsc ,
                                              AV13OrderedBy ,
                                              AV14OrderedDsc } ,
                                              new int[]{
                                              TypeConstants.SHORT, TypeConstants.SHORT, TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.INT, TypeConstants.INT, TypeConstants.INT, TypeConstants.INT,
                                              TypeConstants.SHORT, TypeConstants.BOOLEAN
                                              }
         });
         lV59Bancos_conceptoentregarendirwwds_3_conentdsc1 = StringUtil.PadR( StringUtil.RTrim( AV59Bancos_conceptoentregarendirwwds_3_conentdsc1), 100, "%");
         lV59Bancos_conceptoentregarendirwwds_3_conentdsc1 = StringUtil.PadR( StringUtil.RTrim( AV59Bancos_conceptoentregarendirwwds_3_conentdsc1), 100, "%");
         lV60Bancos_conceptoentregarendirwwds_4_cuecod1 = StringUtil.PadR( StringUtil.RTrim( AV60Bancos_conceptoentregarendirwwds_4_cuecod1), 15, "%");
         lV60Bancos_conceptoentregarendirwwds_4_cuecod1 = StringUtil.PadR( StringUtil.RTrim( AV60Bancos_conceptoentregarendirwwds_4_cuecod1), 15, "%");
         lV64Bancos_conceptoentregarendirwwds_8_conentdsc2 = StringUtil.PadR( StringUtil.RTrim( AV64Bancos_conceptoentregarendirwwds_8_conentdsc2), 100, "%");
         lV64Bancos_conceptoentregarendirwwds_8_conentdsc2 = StringUtil.PadR( StringUtil.RTrim( AV64Bancos_conceptoentregarendirwwds_8_conentdsc2), 100, "%");
         lV65Bancos_conceptoentregarendirwwds_9_cuecod2 = StringUtil.PadR( StringUtil.RTrim( AV65Bancos_conceptoentregarendirwwds_9_cuecod2), 15, "%");
         lV65Bancos_conceptoentregarendirwwds_9_cuecod2 = StringUtil.PadR( StringUtil.RTrim( AV65Bancos_conceptoentregarendirwwds_9_cuecod2), 15, "%");
         lV69Bancos_conceptoentregarendirwwds_13_conentdsc3 = StringUtil.PadR( StringUtil.RTrim( AV69Bancos_conceptoentregarendirwwds_13_conentdsc3), 100, "%");
         lV69Bancos_conceptoentregarendirwwds_13_conentdsc3 = StringUtil.PadR( StringUtil.RTrim( AV69Bancos_conceptoentregarendirwwds_13_conentdsc3), 100, "%");
         lV70Bancos_conceptoentregarendirwwds_14_cuecod3 = StringUtil.PadR( StringUtil.RTrim( AV70Bancos_conceptoentregarendirwwds_14_cuecod3), 15, "%");
         lV70Bancos_conceptoentregarendirwwds_14_cuecod3 = StringUtil.PadR( StringUtil.RTrim( AV70Bancos_conceptoentregarendirwwds_14_cuecod3), 15, "%");
         lV73Bancos_conceptoentregarendirwwds_17_tfconentdsc = StringUtil.PadR( StringUtil.RTrim( AV73Bancos_conceptoentregarendirwwds_17_tfconentdsc), 100, "%");
         lV75Bancos_conceptoentregarendirwwds_19_tfcuecod = StringUtil.PadR( StringUtil.RTrim( AV75Bancos_conceptoentregarendirwwds_19_tfcuecod), 15, "%");
         lV77Bancos_conceptoentregarendirwwds_21_tfcuedsc = StringUtil.PadR( StringUtil.RTrim( AV77Bancos_conceptoentregarendirwwds_21_tfcuedsc), 100, "%");
         /* Using cursor H00243 */
         pr_default.execute(1, new Object[] {lV59Bancos_conceptoentregarendirwwds_3_conentdsc1, lV59Bancos_conceptoentregarendirwwds_3_conentdsc1, lV60Bancos_conceptoentregarendirwwds_4_cuecod1, lV60Bancos_conceptoentregarendirwwds_4_cuecod1, lV64Bancos_conceptoentregarendirwwds_8_conentdsc2, lV64Bancos_conceptoentregarendirwwds_8_conentdsc2, lV65Bancos_conceptoentregarendirwwds_9_cuecod2, lV65Bancos_conceptoentregarendirwwds_9_cuecod2, lV69Bancos_conceptoentregarendirwwds_13_conentdsc3, lV69Bancos_conceptoentregarendirwwds_13_conentdsc3, lV70Bancos_conceptoentregarendirwwds_14_cuecod3, lV70Bancos_conceptoentregarendirwwds_14_cuecod3, AV71Bancos_conceptoentregarendirwwds_15_tfconentcod, AV72Bancos_conceptoentregarendirwwds_16_tfconentcod_to, lV73Bancos_conceptoentregarendirwwds_17_tfconentdsc, AV74Bancos_conceptoentregarendirwwds_18_tfconentdsc_sel, lV75Bancos_conceptoentregarendirwwds_19_tfcuecod, AV76Bancos_conceptoentregarendirwwds_20_tfcuecod_sel, lV77Bancos_conceptoentregarendirwwds_21_tfcuedsc, AV78Bancos_conceptoentregarendirwwds_22_tfcuedsc_sel});
         GRID_nRecordCount = H00243_AGRID_nRecordCount[0];
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
         AV57Bancos_conceptoentregarendirwwds_1_dynamicfiltersselector1 = AV15DynamicFiltersSelector1;
         AV58Bancos_conceptoentregarendirwwds_2_dynamicfiltersoperator1 = AV16DynamicFiltersOperator1;
         AV59Bancos_conceptoentregarendirwwds_3_conentdsc1 = AV17ConEntDsc1;
         AV60Bancos_conceptoentregarendirwwds_4_cuecod1 = AV49CueCod1;
         AV61Bancos_conceptoentregarendirwwds_5_dynamicfiltersenabled2 = AV18DynamicFiltersEnabled2;
         AV62Bancos_conceptoentregarendirwwds_6_dynamicfiltersselector2 = AV19DynamicFiltersSelector2;
         AV63Bancos_conceptoentregarendirwwds_7_dynamicfiltersoperator2 = AV20DynamicFiltersOperator2;
         AV64Bancos_conceptoentregarendirwwds_8_conentdsc2 = AV21ConEntDsc2;
         AV65Bancos_conceptoentregarendirwwds_9_cuecod2 = AV50CueCod2;
         AV66Bancos_conceptoentregarendirwwds_10_dynamicfiltersenabled3 = AV22DynamicFiltersEnabled3;
         AV67Bancos_conceptoentregarendirwwds_11_dynamicfiltersselector3 = AV23DynamicFiltersSelector3;
         AV68Bancos_conceptoentregarendirwwds_12_dynamicfiltersoperator3 = AV24DynamicFiltersOperator3;
         AV69Bancos_conceptoentregarendirwwds_13_conentdsc3 = AV25ConEntDsc3;
         AV70Bancos_conceptoentregarendirwwds_14_cuecod3 = AV51CueCod3;
         AV71Bancos_conceptoentregarendirwwds_15_tfconentcod = AV31TFConEntCod;
         AV72Bancos_conceptoentregarendirwwds_16_tfconentcod_to = AV32TFConEntCod_To;
         AV73Bancos_conceptoentregarendirwwds_17_tfconentdsc = AV33TFConEntDsc;
         AV74Bancos_conceptoentregarendirwwds_18_tfconentdsc_sel = AV34TFConEntDsc_Sel;
         AV75Bancos_conceptoentregarendirwwds_19_tfcuecod = AV35TFCueCod;
         AV76Bancos_conceptoentregarendirwwds_20_tfcuecod_sel = AV36TFCueCod_Sel;
         AV77Bancos_conceptoentregarendirwwds_21_tfcuedsc = AV37TFCueDsc;
         AV78Bancos_conceptoentregarendirwwds_22_tfcuedsc_sel = AV38TFCueDsc_Sel;
         AV79Bancos_conceptoentregarendirwwds_23_tfconentsts_sels = AV53TFConEntSts_Sels;
         GRID_nFirstRecordOnPage = 0;
         GxWebStd.gx_hidden_field( context, "GRID_nFirstRecordOnPage", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRID_nFirstRecordOnPage), 15, 0, ".", "")));
         if ( isFullAjaxMode( ) )
         {
            gxgrGrid_refresh( subGrid_Rows, AV15DynamicFiltersSelector1, AV16DynamicFiltersOperator1, AV17ConEntDsc1, AV49CueCod1, AV19DynamicFiltersSelector2, AV20DynamicFiltersOperator2, AV21ConEntDsc2, AV50CueCod2, AV23DynamicFiltersSelector3, AV24DynamicFiltersOperator3, AV25ConEntDsc3, AV51CueCod3, AV18DynamicFiltersEnabled2, AV22DynamicFiltersEnabled3, AV56Pgmname, AV31TFConEntCod, AV32TFConEntCod_To, AV33TFConEntDsc, AV34TFConEntDsc_Sel, AV35TFCueCod, AV36TFCueCod_Sel, AV37TFCueDsc, AV38TFCueDsc_Sel, AV53TFConEntSts_Sels, AV13OrderedBy, AV14OrderedDsc, AV10GridState, AV27DynamicFiltersIgnoreFirst, AV26DynamicFiltersRemoving) ;
         }
         send_integrity_footer_hashes( ) ;
         return 0 ;
      }

      protected short subgrid_nextpage( )
      {
         AV57Bancos_conceptoentregarendirwwds_1_dynamicfiltersselector1 = AV15DynamicFiltersSelector1;
         AV58Bancos_conceptoentregarendirwwds_2_dynamicfiltersoperator1 = AV16DynamicFiltersOperator1;
         AV59Bancos_conceptoentregarendirwwds_3_conentdsc1 = AV17ConEntDsc1;
         AV60Bancos_conceptoentregarendirwwds_4_cuecod1 = AV49CueCod1;
         AV61Bancos_conceptoentregarendirwwds_5_dynamicfiltersenabled2 = AV18DynamicFiltersEnabled2;
         AV62Bancos_conceptoentregarendirwwds_6_dynamicfiltersselector2 = AV19DynamicFiltersSelector2;
         AV63Bancos_conceptoentregarendirwwds_7_dynamicfiltersoperator2 = AV20DynamicFiltersOperator2;
         AV64Bancos_conceptoentregarendirwwds_8_conentdsc2 = AV21ConEntDsc2;
         AV65Bancos_conceptoentregarendirwwds_9_cuecod2 = AV50CueCod2;
         AV66Bancos_conceptoentregarendirwwds_10_dynamicfiltersenabled3 = AV22DynamicFiltersEnabled3;
         AV67Bancos_conceptoentregarendirwwds_11_dynamicfiltersselector3 = AV23DynamicFiltersSelector3;
         AV68Bancos_conceptoentregarendirwwds_12_dynamicfiltersoperator3 = AV24DynamicFiltersOperator3;
         AV69Bancos_conceptoentregarendirwwds_13_conentdsc3 = AV25ConEntDsc3;
         AV70Bancos_conceptoentregarendirwwds_14_cuecod3 = AV51CueCod3;
         AV71Bancos_conceptoentregarendirwwds_15_tfconentcod = AV31TFConEntCod;
         AV72Bancos_conceptoentregarendirwwds_16_tfconentcod_to = AV32TFConEntCod_To;
         AV73Bancos_conceptoentregarendirwwds_17_tfconentdsc = AV33TFConEntDsc;
         AV74Bancos_conceptoentregarendirwwds_18_tfconentdsc_sel = AV34TFConEntDsc_Sel;
         AV75Bancos_conceptoentregarendirwwds_19_tfcuecod = AV35TFCueCod;
         AV76Bancos_conceptoentregarendirwwds_20_tfcuecod_sel = AV36TFCueCod_Sel;
         AV77Bancos_conceptoentregarendirwwds_21_tfcuedsc = AV37TFCueDsc;
         AV78Bancos_conceptoentregarendirwwds_22_tfcuedsc_sel = AV38TFCueDsc_Sel;
         AV79Bancos_conceptoentregarendirwwds_23_tfconentsts_sels = AV53TFConEntSts_Sels;
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
            gxgrGrid_refresh( subGrid_Rows, AV15DynamicFiltersSelector1, AV16DynamicFiltersOperator1, AV17ConEntDsc1, AV49CueCod1, AV19DynamicFiltersSelector2, AV20DynamicFiltersOperator2, AV21ConEntDsc2, AV50CueCod2, AV23DynamicFiltersSelector3, AV24DynamicFiltersOperator3, AV25ConEntDsc3, AV51CueCod3, AV18DynamicFiltersEnabled2, AV22DynamicFiltersEnabled3, AV56Pgmname, AV31TFConEntCod, AV32TFConEntCod_To, AV33TFConEntDsc, AV34TFConEntDsc_Sel, AV35TFCueCod, AV36TFCueCod_Sel, AV37TFCueDsc, AV38TFCueDsc_Sel, AV53TFConEntSts_Sels, AV13OrderedBy, AV14OrderedDsc, AV10GridState, AV27DynamicFiltersIgnoreFirst, AV26DynamicFiltersRemoving) ;
         }
         send_integrity_footer_hashes( ) ;
         return (short)(((GRID_nEOF==0) ? 0 : 2)) ;
      }

      protected short subgrid_previouspage( )
      {
         AV57Bancos_conceptoentregarendirwwds_1_dynamicfiltersselector1 = AV15DynamicFiltersSelector1;
         AV58Bancos_conceptoentregarendirwwds_2_dynamicfiltersoperator1 = AV16DynamicFiltersOperator1;
         AV59Bancos_conceptoentregarendirwwds_3_conentdsc1 = AV17ConEntDsc1;
         AV60Bancos_conceptoentregarendirwwds_4_cuecod1 = AV49CueCod1;
         AV61Bancos_conceptoentregarendirwwds_5_dynamicfiltersenabled2 = AV18DynamicFiltersEnabled2;
         AV62Bancos_conceptoentregarendirwwds_6_dynamicfiltersselector2 = AV19DynamicFiltersSelector2;
         AV63Bancos_conceptoentregarendirwwds_7_dynamicfiltersoperator2 = AV20DynamicFiltersOperator2;
         AV64Bancos_conceptoentregarendirwwds_8_conentdsc2 = AV21ConEntDsc2;
         AV65Bancos_conceptoentregarendirwwds_9_cuecod2 = AV50CueCod2;
         AV66Bancos_conceptoentregarendirwwds_10_dynamicfiltersenabled3 = AV22DynamicFiltersEnabled3;
         AV67Bancos_conceptoentregarendirwwds_11_dynamicfiltersselector3 = AV23DynamicFiltersSelector3;
         AV68Bancos_conceptoentregarendirwwds_12_dynamicfiltersoperator3 = AV24DynamicFiltersOperator3;
         AV69Bancos_conceptoentregarendirwwds_13_conentdsc3 = AV25ConEntDsc3;
         AV70Bancos_conceptoentregarendirwwds_14_cuecod3 = AV51CueCod3;
         AV71Bancos_conceptoentregarendirwwds_15_tfconentcod = AV31TFConEntCod;
         AV72Bancos_conceptoentregarendirwwds_16_tfconentcod_to = AV32TFConEntCod_To;
         AV73Bancos_conceptoentregarendirwwds_17_tfconentdsc = AV33TFConEntDsc;
         AV74Bancos_conceptoentregarendirwwds_18_tfconentdsc_sel = AV34TFConEntDsc_Sel;
         AV75Bancos_conceptoentregarendirwwds_19_tfcuecod = AV35TFCueCod;
         AV76Bancos_conceptoentregarendirwwds_20_tfcuecod_sel = AV36TFCueCod_Sel;
         AV77Bancos_conceptoentregarendirwwds_21_tfcuedsc = AV37TFCueDsc;
         AV78Bancos_conceptoentregarendirwwds_22_tfcuedsc_sel = AV38TFCueDsc_Sel;
         AV79Bancos_conceptoentregarendirwwds_23_tfconentsts_sels = AV53TFConEntSts_Sels;
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
            gxgrGrid_refresh( subGrid_Rows, AV15DynamicFiltersSelector1, AV16DynamicFiltersOperator1, AV17ConEntDsc1, AV49CueCod1, AV19DynamicFiltersSelector2, AV20DynamicFiltersOperator2, AV21ConEntDsc2, AV50CueCod2, AV23DynamicFiltersSelector3, AV24DynamicFiltersOperator3, AV25ConEntDsc3, AV51CueCod3, AV18DynamicFiltersEnabled2, AV22DynamicFiltersEnabled3, AV56Pgmname, AV31TFConEntCod, AV32TFConEntCod_To, AV33TFConEntDsc, AV34TFConEntDsc_Sel, AV35TFCueCod, AV36TFCueCod_Sel, AV37TFCueDsc, AV38TFCueDsc_Sel, AV53TFConEntSts_Sels, AV13OrderedBy, AV14OrderedDsc, AV10GridState, AV27DynamicFiltersIgnoreFirst, AV26DynamicFiltersRemoving) ;
         }
         send_integrity_footer_hashes( ) ;
         return 0 ;
      }

      protected short subgrid_lastpage( )
      {
         AV57Bancos_conceptoentregarendirwwds_1_dynamicfiltersselector1 = AV15DynamicFiltersSelector1;
         AV58Bancos_conceptoentregarendirwwds_2_dynamicfiltersoperator1 = AV16DynamicFiltersOperator1;
         AV59Bancos_conceptoentregarendirwwds_3_conentdsc1 = AV17ConEntDsc1;
         AV60Bancos_conceptoentregarendirwwds_4_cuecod1 = AV49CueCod1;
         AV61Bancos_conceptoentregarendirwwds_5_dynamicfiltersenabled2 = AV18DynamicFiltersEnabled2;
         AV62Bancos_conceptoentregarendirwwds_6_dynamicfiltersselector2 = AV19DynamicFiltersSelector2;
         AV63Bancos_conceptoentregarendirwwds_7_dynamicfiltersoperator2 = AV20DynamicFiltersOperator2;
         AV64Bancos_conceptoentregarendirwwds_8_conentdsc2 = AV21ConEntDsc2;
         AV65Bancos_conceptoentregarendirwwds_9_cuecod2 = AV50CueCod2;
         AV66Bancos_conceptoentregarendirwwds_10_dynamicfiltersenabled3 = AV22DynamicFiltersEnabled3;
         AV67Bancos_conceptoentregarendirwwds_11_dynamicfiltersselector3 = AV23DynamicFiltersSelector3;
         AV68Bancos_conceptoentregarendirwwds_12_dynamicfiltersoperator3 = AV24DynamicFiltersOperator3;
         AV69Bancos_conceptoentregarendirwwds_13_conentdsc3 = AV25ConEntDsc3;
         AV70Bancos_conceptoentregarendirwwds_14_cuecod3 = AV51CueCod3;
         AV71Bancos_conceptoentregarendirwwds_15_tfconentcod = AV31TFConEntCod;
         AV72Bancos_conceptoentregarendirwwds_16_tfconentcod_to = AV32TFConEntCod_To;
         AV73Bancos_conceptoentregarendirwwds_17_tfconentdsc = AV33TFConEntDsc;
         AV74Bancos_conceptoentregarendirwwds_18_tfconentdsc_sel = AV34TFConEntDsc_Sel;
         AV75Bancos_conceptoentregarendirwwds_19_tfcuecod = AV35TFCueCod;
         AV76Bancos_conceptoentregarendirwwds_20_tfcuecod_sel = AV36TFCueCod_Sel;
         AV77Bancos_conceptoentregarendirwwds_21_tfcuedsc = AV37TFCueDsc;
         AV78Bancos_conceptoentregarendirwwds_22_tfcuedsc_sel = AV38TFCueDsc_Sel;
         AV79Bancos_conceptoentregarendirwwds_23_tfconentsts_sels = AV53TFConEntSts_Sels;
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
            gxgrGrid_refresh( subGrid_Rows, AV15DynamicFiltersSelector1, AV16DynamicFiltersOperator1, AV17ConEntDsc1, AV49CueCod1, AV19DynamicFiltersSelector2, AV20DynamicFiltersOperator2, AV21ConEntDsc2, AV50CueCod2, AV23DynamicFiltersSelector3, AV24DynamicFiltersOperator3, AV25ConEntDsc3, AV51CueCod3, AV18DynamicFiltersEnabled2, AV22DynamicFiltersEnabled3, AV56Pgmname, AV31TFConEntCod, AV32TFConEntCod_To, AV33TFConEntDsc, AV34TFConEntDsc_Sel, AV35TFCueCod, AV36TFCueCod_Sel, AV37TFCueDsc, AV38TFCueDsc_Sel, AV53TFConEntSts_Sels, AV13OrderedBy, AV14OrderedDsc, AV10GridState, AV27DynamicFiltersIgnoreFirst, AV26DynamicFiltersRemoving) ;
         }
         send_integrity_footer_hashes( ) ;
         return 0 ;
      }

      protected int subgrid_gotopage( int nPageNo )
      {
         AV57Bancos_conceptoentregarendirwwds_1_dynamicfiltersselector1 = AV15DynamicFiltersSelector1;
         AV58Bancos_conceptoentregarendirwwds_2_dynamicfiltersoperator1 = AV16DynamicFiltersOperator1;
         AV59Bancos_conceptoentregarendirwwds_3_conentdsc1 = AV17ConEntDsc1;
         AV60Bancos_conceptoentregarendirwwds_4_cuecod1 = AV49CueCod1;
         AV61Bancos_conceptoentregarendirwwds_5_dynamicfiltersenabled2 = AV18DynamicFiltersEnabled2;
         AV62Bancos_conceptoentregarendirwwds_6_dynamicfiltersselector2 = AV19DynamicFiltersSelector2;
         AV63Bancos_conceptoentregarendirwwds_7_dynamicfiltersoperator2 = AV20DynamicFiltersOperator2;
         AV64Bancos_conceptoentregarendirwwds_8_conentdsc2 = AV21ConEntDsc2;
         AV65Bancos_conceptoentregarendirwwds_9_cuecod2 = AV50CueCod2;
         AV66Bancos_conceptoentregarendirwwds_10_dynamicfiltersenabled3 = AV22DynamicFiltersEnabled3;
         AV67Bancos_conceptoentregarendirwwds_11_dynamicfiltersselector3 = AV23DynamicFiltersSelector3;
         AV68Bancos_conceptoentregarendirwwds_12_dynamicfiltersoperator3 = AV24DynamicFiltersOperator3;
         AV69Bancos_conceptoentregarendirwwds_13_conentdsc3 = AV25ConEntDsc3;
         AV70Bancos_conceptoentregarendirwwds_14_cuecod3 = AV51CueCod3;
         AV71Bancos_conceptoentregarendirwwds_15_tfconentcod = AV31TFConEntCod;
         AV72Bancos_conceptoentregarendirwwds_16_tfconentcod_to = AV32TFConEntCod_To;
         AV73Bancos_conceptoentregarendirwwds_17_tfconentdsc = AV33TFConEntDsc;
         AV74Bancos_conceptoentregarendirwwds_18_tfconentdsc_sel = AV34TFConEntDsc_Sel;
         AV75Bancos_conceptoentregarendirwwds_19_tfcuecod = AV35TFCueCod;
         AV76Bancos_conceptoentregarendirwwds_20_tfcuecod_sel = AV36TFCueCod_Sel;
         AV77Bancos_conceptoentregarendirwwds_21_tfcuedsc = AV37TFCueDsc;
         AV78Bancos_conceptoentregarendirwwds_22_tfcuedsc_sel = AV38TFCueDsc_Sel;
         AV79Bancos_conceptoentregarendirwwds_23_tfconentsts_sels = AV53TFConEntSts_Sels;
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
            gxgrGrid_refresh( subGrid_Rows, AV15DynamicFiltersSelector1, AV16DynamicFiltersOperator1, AV17ConEntDsc1, AV49CueCod1, AV19DynamicFiltersSelector2, AV20DynamicFiltersOperator2, AV21ConEntDsc2, AV50CueCod2, AV23DynamicFiltersSelector3, AV24DynamicFiltersOperator3, AV25ConEntDsc3, AV51CueCod3, AV18DynamicFiltersEnabled2, AV22DynamicFiltersEnabled3, AV56Pgmname, AV31TFConEntCod, AV32TFConEntCod_To, AV33TFConEntDsc, AV34TFConEntDsc_Sel, AV35TFCueCod, AV36TFCueCod_Sel, AV37TFCueDsc, AV38TFCueDsc_Sel, AV53TFConEntSts_Sels, AV13OrderedBy, AV14OrderedDsc, AV10GridState, AV27DynamicFiltersIgnoreFirst, AV26DynamicFiltersRemoving) ;
         }
         send_integrity_footer_hashes( ) ;
         return (int)(0) ;
      }

      protected void before_start_formulas( )
      {
         AV56Pgmname = "Bancos.ConceptoEntregaRendirWW";
         context.Gx_err = 0;
         fix_multi_value_controls( ) ;
      }

      protected void STRUP240( )
      {
         /* Before Start, stand alone formulas. */
         before_start_formulas( ) ;
         /* Execute Start event if defined. */
         context.wbGlbDoneStart = 0;
         /* Execute user event: Start */
         E24242 ();
         context.wbGlbDoneStart = 1;
         /* After Start, stand alone formulas. */
         if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
         {
            /* Read saved SDTs. */
            ajax_req_read_hidden_sdt(cgiGet( "vAGEXPORTDATA"), AV47AGExportData);
            ajax_req_read_hidden_sdt(cgiGet( "vDDO_TITLESETTINGSICONS"), AV41DDO_TitleSettingsIcons);
            /* Read saved values. */
            nRC_GXsfl_110 = (int)(context.localUtil.CToN( cgiGet( "nRC_GXsfl_110"), ".", ","));
            AV43GridCurrentPage = (long)(context.localUtil.CToN( cgiGet( "vGRIDCURRENTPAGE"), ".", ","));
            AV44GridPageCount = (long)(context.localUtil.CToN( cgiGet( "vGRIDPAGECOUNT"), ".", ","));
            AV45GridAppliedFilters = cgiGet( "vGRIDAPPLIEDFILTERS");
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
            AV17ConEntDsc1 = cgiGet( edtavConentdsc1_Internalname);
            AssignAttri("", false, "AV17ConEntDsc1", AV17ConEntDsc1);
            AV49CueCod1 = cgiGet( edtavCuecod1_Internalname);
            AssignAttri("", false, "AV49CueCod1", AV49CueCod1);
            cmbavDynamicfiltersselector2.Name = cmbavDynamicfiltersselector2_Internalname;
            cmbavDynamicfiltersselector2.CurrentValue = cgiGet( cmbavDynamicfiltersselector2_Internalname);
            AV19DynamicFiltersSelector2 = cgiGet( cmbavDynamicfiltersselector2_Internalname);
            AssignAttri("", false, "AV19DynamicFiltersSelector2", AV19DynamicFiltersSelector2);
            cmbavDynamicfiltersoperator2.Name = cmbavDynamicfiltersoperator2_Internalname;
            cmbavDynamicfiltersoperator2.CurrentValue = cgiGet( cmbavDynamicfiltersoperator2_Internalname);
            AV20DynamicFiltersOperator2 = (short)(NumberUtil.Val( cgiGet( cmbavDynamicfiltersoperator2_Internalname), "."));
            AssignAttri("", false, "AV20DynamicFiltersOperator2", StringUtil.LTrimStr( (decimal)(AV20DynamicFiltersOperator2), 4, 0));
            AV21ConEntDsc2 = cgiGet( edtavConentdsc2_Internalname);
            AssignAttri("", false, "AV21ConEntDsc2", AV21ConEntDsc2);
            AV50CueCod2 = cgiGet( edtavCuecod2_Internalname);
            AssignAttri("", false, "AV50CueCod2", AV50CueCod2);
            cmbavDynamicfiltersselector3.Name = cmbavDynamicfiltersselector3_Internalname;
            cmbavDynamicfiltersselector3.CurrentValue = cgiGet( cmbavDynamicfiltersselector3_Internalname);
            AV23DynamicFiltersSelector3 = cgiGet( cmbavDynamicfiltersselector3_Internalname);
            AssignAttri("", false, "AV23DynamicFiltersSelector3", AV23DynamicFiltersSelector3);
            cmbavDynamicfiltersoperator3.Name = cmbavDynamicfiltersoperator3_Internalname;
            cmbavDynamicfiltersoperator3.CurrentValue = cgiGet( cmbavDynamicfiltersoperator3_Internalname);
            AV24DynamicFiltersOperator3 = (short)(NumberUtil.Val( cgiGet( cmbavDynamicfiltersoperator3_Internalname), "."));
            AssignAttri("", false, "AV24DynamicFiltersOperator3", StringUtil.LTrimStr( (decimal)(AV24DynamicFiltersOperator3), 4, 0));
            AV25ConEntDsc3 = cgiGet( edtavConentdsc3_Internalname);
            AssignAttri("", false, "AV25ConEntDsc3", AV25ConEntDsc3);
            AV51CueCod3 = cgiGet( edtavCuecod3_Internalname);
            AssignAttri("", false, "AV51CueCod3", AV51CueCod3);
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
            if ( StringUtil.StrCmp(cgiGet( "GXH_vCONENTDSC1"), AV17ConEntDsc1) != 0 )
            {
               GRID_nFirstRecordOnPage = 0;
            }
            if ( StringUtil.StrCmp(cgiGet( "GXH_vCUECOD1"), AV49CueCod1) != 0 )
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
            if ( StringUtil.StrCmp(cgiGet( "GXH_vCONENTDSC2"), AV21ConEntDsc2) != 0 )
            {
               GRID_nFirstRecordOnPage = 0;
            }
            if ( StringUtil.StrCmp(cgiGet( "GXH_vCUECOD2"), AV50CueCod2) != 0 )
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
            if ( StringUtil.StrCmp(cgiGet( "GXH_vCONENTDSC3"), AV25ConEntDsc3) != 0 )
            {
               GRID_nFirstRecordOnPage = 0;
            }
            if ( StringUtil.StrCmp(cgiGet( "GXH_vCUECOD3"), AV51CueCod3) != 0 )
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
         E24242 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
      }

      protected void E24242( )
      {
         /* Start Routine */
         returnInSub = false;
         subGrid_Rows = 10;
         GxWebStd.gx_hidden_field( context, "GRID_Rows", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid_Rows), 6, 0, ".", "")));
         Grid_empowerer_Gridinternalname = subGrid_Internalname;
         ucGrid_empowerer.SendProperty(context, "", false, Grid_empowerer_Internalname, "GridInternalName", Grid_empowerer_Gridinternalname);
         lblJsdynamicfilters_Caption = "";
         AssignProp("", false, lblJsdynamicfilters_Internalname, "Caption", lblJsdynamicfilters_Caption, true);
         AV15DynamicFiltersSelector1 = "CONENTDSC";
         AssignAttri("", false, "AV15DynamicFiltersSelector1", AV15DynamicFiltersSelector1);
         /* Execute user subroutine: 'ENABLEDYNAMICFILTERS1' */
         S112 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
         AV19DynamicFiltersSelector2 = "CONENTDSC";
         AssignAttri("", false, "AV19DynamicFiltersSelector2", AV19DynamicFiltersSelector2);
         /* Execute user subroutine: 'ENABLEDYNAMICFILTERS2' */
         S122 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
         AV23DynamicFiltersSelector3 = "CONENTDSC";
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
         AV47AGExportData = new GXBaseCollection<GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTDropDownOptionsData_Item>( context, "Item", "");
         AV48AGExportDataItem = new GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTDropDownOptionsData_Item(context);
         AV48AGExportDataItem.gxTpr_Title = "PDF";
         AV48AGExportDataItem.gxTpr_Icon = context.convertURL( (string)(context.GetImagePath( "776fb79c-a0a1-4302-b5e5-d773dbe1a297", "", context.GetTheme( ))));
         AV48AGExportDataItem.gxTpr_Eventkey = "ExportReport";
         AV48AGExportDataItem.gxTpr_Isdivider = false;
         AV47AGExportData.Add(AV48AGExportDataItem, 0);
         AV48AGExportDataItem = new GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTDropDownOptionsData_Item(context);
         AV48AGExportDataItem.gxTpr_Title = "Excel";
         AV48AGExportDataItem.gxTpr_Icon = context.convertURL( (string)(context.GetImagePath( "da69a816-fd11-445b-8aaf-1a2f7f1acc93", "", context.GetTheme( ))));
         AV48AGExportDataItem.gxTpr_Eventkey = "Export";
         AV48AGExportDataItem.gxTpr_Isdivider = false;
         AV47AGExportData.Add(AV48AGExportDataItem, 0);
         Ddo_grid_Gridinternalname = subGrid_Internalname;
         ucDdo_grid.SendProperty(context, "", false, Ddo_grid_Internalname, "GridInternalName", Ddo_grid_Gridinternalname);
         Form.Caption = " Conceptos Entrega Rendir Cuenta";
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
         GXt_SdtDVB_SDTDropDownOptionsTitleSettingsIcons1 = AV41DDO_TitleSettingsIcons;
         new GeneXus.Programs.wwpbaseobjects.getwwptitlesettingsicons(context ).execute( out  GXt_SdtDVB_SDTDropDownOptionsTitleSettingsIcons1) ;
         AV41DDO_TitleSettingsIcons = GXt_SdtDVB_SDTDropDownOptionsTitleSettingsIcons1;
         Gridpaginationbar_Rowsperpageselectedvalue = subGrid_Rows;
         ucGridpaginationbar.SendProperty(context, "", false, Gridpaginationbar_Internalname, "RowsPerPageSelectedValue", StringUtil.LTrimStr( (decimal)(Gridpaginationbar_Rowsperpageselectedvalue), 9, 0));
      }

      protected void E25242( )
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
         if ( StringUtil.StrCmp(AV15DynamicFiltersSelector1, "CONENTDSC") == 0 )
         {
            cmbavDynamicfiltersoperator1.addItem("0", "Comienza con", 0);
            cmbavDynamicfiltersoperator1.addItem("1", "Contiene", 0);
         }
         else if ( StringUtil.StrCmp(AV15DynamicFiltersSelector1, "CUECOD") == 0 )
         {
            cmbavDynamicfiltersoperator1.addItem("0", "Comienza con", 0);
            cmbavDynamicfiltersoperator1.addItem("1", "Contiene", 0);
         }
         if ( AV18DynamicFiltersEnabled2 )
         {
            cmbavDynamicfiltersoperator2.removeAllItems();
            if ( StringUtil.StrCmp(AV19DynamicFiltersSelector2, "CONENTDSC") == 0 )
            {
               cmbavDynamicfiltersoperator2.addItem("0", "Comienza con", 0);
               cmbavDynamicfiltersoperator2.addItem("1", "Contiene", 0);
            }
            else if ( StringUtil.StrCmp(AV19DynamicFiltersSelector2, "CUECOD") == 0 )
            {
               cmbavDynamicfiltersoperator2.addItem("0", "Comienza con", 0);
               cmbavDynamicfiltersoperator2.addItem("1", "Contiene", 0);
            }
            if ( AV22DynamicFiltersEnabled3 )
            {
               cmbavDynamicfiltersoperator3.removeAllItems();
               if ( StringUtil.StrCmp(AV23DynamicFiltersSelector3, "CONENTDSC") == 0 )
               {
                  cmbavDynamicfiltersoperator3.addItem("0", "Comienza con", 0);
                  cmbavDynamicfiltersoperator3.addItem("1", "Contiene", 0);
               }
               else if ( StringUtil.StrCmp(AV23DynamicFiltersSelector3, "CUECOD") == 0 )
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
         AV43GridCurrentPage = subGrid_fnc_Currentpage( );
         AssignAttri("", false, "AV43GridCurrentPage", StringUtil.LTrimStr( (decimal)(AV43GridCurrentPage), 10, 0));
         AV44GridPageCount = subGrid_fnc_Pagecount( );
         AssignAttri("", false, "AV44GridPageCount", StringUtil.LTrimStr( (decimal)(AV44GridPageCount), 10, 0));
         GXt_char2 = AV45GridAppliedFilters;
         new GeneXus.Programs.wwpbaseobjects.wwp_getappliedfiltersdescription(context ).execute(  AV56Pgmname, out  GXt_char2) ;
         AV45GridAppliedFilters = GXt_char2;
         AssignAttri("", false, "AV45GridAppliedFilters", AV45GridAppliedFilters);
         AV57Bancos_conceptoentregarendirwwds_1_dynamicfiltersselector1 = AV15DynamicFiltersSelector1;
         AV58Bancos_conceptoentregarendirwwds_2_dynamicfiltersoperator1 = AV16DynamicFiltersOperator1;
         AV59Bancos_conceptoentregarendirwwds_3_conentdsc1 = AV17ConEntDsc1;
         AV60Bancos_conceptoentregarendirwwds_4_cuecod1 = AV49CueCod1;
         AV61Bancos_conceptoentregarendirwwds_5_dynamicfiltersenabled2 = AV18DynamicFiltersEnabled2;
         AV62Bancos_conceptoentregarendirwwds_6_dynamicfiltersselector2 = AV19DynamicFiltersSelector2;
         AV63Bancos_conceptoentregarendirwwds_7_dynamicfiltersoperator2 = AV20DynamicFiltersOperator2;
         AV64Bancos_conceptoentregarendirwwds_8_conentdsc2 = AV21ConEntDsc2;
         AV65Bancos_conceptoentregarendirwwds_9_cuecod2 = AV50CueCod2;
         AV66Bancos_conceptoentregarendirwwds_10_dynamicfiltersenabled3 = AV22DynamicFiltersEnabled3;
         AV67Bancos_conceptoentregarendirwwds_11_dynamicfiltersselector3 = AV23DynamicFiltersSelector3;
         AV68Bancos_conceptoentregarendirwwds_12_dynamicfiltersoperator3 = AV24DynamicFiltersOperator3;
         AV69Bancos_conceptoentregarendirwwds_13_conentdsc3 = AV25ConEntDsc3;
         AV70Bancos_conceptoentregarendirwwds_14_cuecod3 = AV51CueCod3;
         AV71Bancos_conceptoentregarendirwwds_15_tfconentcod = AV31TFConEntCod;
         AV72Bancos_conceptoentregarendirwwds_16_tfconentcod_to = AV32TFConEntCod_To;
         AV73Bancos_conceptoentregarendirwwds_17_tfconentdsc = AV33TFConEntDsc;
         AV74Bancos_conceptoentregarendirwwds_18_tfconentdsc_sel = AV34TFConEntDsc_Sel;
         AV75Bancos_conceptoentregarendirwwds_19_tfcuecod = AV35TFCueCod;
         AV76Bancos_conceptoentregarendirwwds_20_tfcuecod_sel = AV36TFCueCod_Sel;
         AV77Bancos_conceptoentregarendirwwds_21_tfcuedsc = AV37TFCueDsc;
         AV78Bancos_conceptoentregarendirwwds_22_tfcuedsc_sel = AV38TFCueDsc_Sel;
         AV79Bancos_conceptoentregarendirwwds_23_tfconentsts_sels = AV53TFConEntSts_Sels;
         /*  Sending Event outputs  */
         cmbavDynamicfiltersoperator1.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV16DynamicFiltersOperator1), 4, 0));
         AssignProp("", false, cmbavDynamicfiltersoperator1_Internalname, "Values", cmbavDynamicfiltersoperator1.ToJavascriptSource(), true);
         cmbavDynamicfiltersoperator2.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV20DynamicFiltersOperator2), 4, 0));
         AssignProp("", false, cmbavDynamicfiltersoperator2_Internalname, "Values", cmbavDynamicfiltersoperator2.ToJavascriptSource(), true);
         cmbavDynamicfiltersoperator3.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV24DynamicFiltersOperator3), 4, 0));
         AssignProp("", false, cmbavDynamicfiltersoperator3_Internalname, "Values", cmbavDynamicfiltersoperator3.ToJavascriptSource(), true);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV10GridState", AV10GridState);
      }

      protected void E11242( )
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
            AV42PageToGo = (int)(NumberUtil.Val( Gridpaginationbar_Selectedpage, "."));
            subgrid_gotopage( AV42PageToGo) ;
         }
      }

      protected void E12242( )
      {
         /* Gridpaginationbar_Changerowsperpage Routine */
         returnInSub = false;
         subGrid_Rows = Gridpaginationbar_Rowsperpageselectedvalue;
         GxWebStd.gx_hidden_field( context, "GRID_Rows", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid_Rows), 6, 0, ".", "")));
         subgrid_firstpage( ) ;
         /*  Sending Event outputs  */
      }

      protected void E14242( )
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
            if ( StringUtil.StrCmp(Ddo_grid_Selectedcolumn, "ConEntCod") == 0 )
            {
               AV31TFConEntCod = (int)(NumberUtil.Val( Ddo_grid_Filteredtext_get, "."));
               AssignAttri("", false, "AV31TFConEntCod", StringUtil.LTrimStr( (decimal)(AV31TFConEntCod), 6, 0));
               AV32TFConEntCod_To = (int)(NumberUtil.Val( Ddo_grid_Filteredtextto_get, "."));
               AssignAttri("", false, "AV32TFConEntCod_To", StringUtil.LTrimStr( (decimal)(AV32TFConEntCod_To), 6, 0));
            }
            else if ( StringUtil.StrCmp(Ddo_grid_Selectedcolumn, "ConEntDsc") == 0 )
            {
               AV33TFConEntDsc = Ddo_grid_Filteredtext_get;
               AssignAttri("", false, "AV33TFConEntDsc", AV33TFConEntDsc);
               AV34TFConEntDsc_Sel = Ddo_grid_Selectedvalue_get;
               AssignAttri("", false, "AV34TFConEntDsc_Sel", AV34TFConEntDsc_Sel);
            }
            else if ( StringUtil.StrCmp(Ddo_grid_Selectedcolumn, "CueCod") == 0 )
            {
               AV35TFCueCod = Ddo_grid_Filteredtext_get;
               AssignAttri("", false, "AV35TFCueCod", AV35TFCueCod);
               AV36TFCueCod_Sel = Ddo_grid_Selectedvalue_get;
               AssignAttri("", false, "AV36TFCueCod_Sel", AV36TFCueCod_Sel);
            }
            else if ( StringUtil.StrCmp(Ddo_grid_Selectedcolumn, "CueDsc") == 0 )
            {
               AV37TFCueDsc = Ddo_grid_Filteredtext_get;
               AssignAttri("", false, "AV37TFCueDsc", AV37TFCueDsc);
               AV38TFCueDsc_Sel = Ddo_grid_Selectedvalue_get;
               AssignAttri("", false, "AV38TFCueDsc_Sel", AV38TFCueDsc_Sel);
            }
            else if ( StringUtil.StrCmp(Ddo_grid_Selectedcolumn, "ConEntSts") == 0 )
            {
               AV52TFConEntSts_SelsJson = Ddo_grid_Selectedvalue_get;
               AssignAttri("", false, "AV52TFConEntSts_SelsJson", AV52TFConEntSts_SelsJson);
               AV53TFConEntSts_Sels.FromJSonString(StringUtil.StringReplace( AV52TFConEntSts_SelsJson, "\"", ""), null);
            }
            subgrid_firstpage( ) ;
         }
         /*  Sending Event outputs  */
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV53TFConEntSts_Sels", AV53TFConEntSts_Sels);
      }

      private void E26242( )
      {
         /* Grid_Load Routine */
         returnInSub = false;
         cmbavGridactions.removeAllItems();
         cmbavGridactions.addItem("0", ";fa fa-bars", 0);
         cmbavGridactions.addItem("1", StringUtil.Format( "%1;%2", "Modificar", "fa fa-pen", "", "", "", "", "", "", ""), 0);
         cmbavGridactions.addItem("2", StringUtil.Format( "%1;%2", "Eliminar", "fa fa-times", "", "", "", "", "", "", ""), 0);
         GXKey = Crypto.GetSiteKey( );
         GXEncryptionTmp = "bancos.conceptoentregarendir.aspx"+UrlEncode(StringUtil.RTrim("DSP")) + "," + UrlEncode(StringUtil.LTrimStr(A376ConEntCod,6,0));
         edtConEntDsc_Link = formatLink("bancos.conceptoentregarendir.aspx") + "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey);
         GXKey = Crypto.GetSiteKey( );
         GXEncryptionTmp = "contabilidad.plancuentas.aspx"+UrlEncode(StringUtil.RTrim("DSP")) + "," + UrlEncode(StringUtil.RTrim(A91CueCod));
         edtCueDsc_Link = formatLink("contabilidad.plancuentas.aspx") + "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey);
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
         cmbavGridactions.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV46GridActions), 4, 0));
      }

      protected void E19242( )
      {
         /* 'AddDynamicFilters1' Routine */
         returnInSub = false;
         AV18DynamicFiltersEnabled2 = true;
         AssignAttri("", false, "AV18DynamicFiltersEnabled2", AV18DynamicFiltersEnabled2);
         imgAdddynamicfilters1_Visible = 0;
         AssignProp("", false, imgAdddynamicfilters1_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(imgAdddynamicfilters1_Visible), 5, 0), true);
         imgRemovedynamicfilters1_Visible = 1;
         AssignProp("", false, imgRemovedynamicfilters1_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(imgRemovedynamicfilters1_Visible), 5, 0), true);
         gxgrGrid_refresh( subGrid_Rows, AV15DynamicFiltersSelector1, AV16DynamicFiltersOperator1, AV17ConEntDsc1, AV49CueCod1, AV19DynamicFiltersSelector2, AV20DynamicFiltersOperator2, AV21ConEntDsc2, AV50CueCod2, AV23DynamicFiltersSelector3, AV24DynamicFiltersOperator3, AV25ConEntDsc3, AV51CueCod3, AV18DynamicFiltersEnabled2, AV22DynamicFiltersEnabled3, AV56Pgmname, AV31TFConEntCod, AV32TFConEntCod_To, AV33TFConEntDsc, AV34TFConEntDsc_Sel, AV35TFCueCod, AV36TFCueCod_Sel, AV37TFCueDsc, AV38TFCueDsc_Sel, AV53TFConEntSts_Sels, AV13OrderedBy, AV14OrderedDsc, AV10GridState, AV27DynamicFiltersIgnoreFirst, AV26DynamicFiltersRemoving) ;
         /*  Sending Event outputs  */
         cmbavDynamicfiltersoperator1.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV16DynamicFiltersOperator1), 4, 0));
         AssignProp("", false, cmbavDynamicfiltersoperator1_Internalname, "Values", cmbavDynamicfiltersoperator1.ToJavascriptSource(), true);
         cmbavDynamicfiltersoperator2.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV20DynamicFiltersOperator2), 4, 0));
         AssignProp("", false, cmbavDynamicfiltersoperator2_Internalname, "Values", cmbavDynamicfiltersoperator2.ToJavascriptSource(), true);
         cmbavDynamicfiltersoperator3.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV24DynamicFiltersOperator3), 4, 0));
         AssignProp("", false, cmbavDynamicfiltersoperator3_Internalname, "Values", cmbavDynamicfiltersoperator3.ToJavascriptSource(), true);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV10GridState", AV10GridState);
      }

      protected void E15242( )
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
         gxgrGrid_refresh( subGrid_Rows, AV15DynamicFiltersSelector1, AV16DynamicFiltersOperator1, AV17ConEntDsc1, AV49CueCod1, AV19DynamicFiltersSelector2, AV20DynamicFiltersOperator2, AV21ConEntDsc2, AV50CueCod2, AV23DynamicFiltersSelector3, AV24DynamicFiltersOperator3, AV25ConEntDsc3, AV51CueCod3, AV18DynamicFiltersEnabled2, AV22DynamicFiltersEnabled3, AV56Pgmname, AV31TFConEntCod, AV32TFConEntCod_To, AV33TFConEntDsc, AV34TFConEntDsc_Sel, AV35TFCueCod, AV36TFCueCod_Sel, AV37TFCueDsc, AV38TFCueDsc_Sel, AV53TFConEntSts_Sels, AV13OrderedBy, AV14OrderedDsc, AV10GridState, AV27DynamicFiltersIgnoreFirst, AV26DynamicFiltersRemoving) ;
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

      protected void E20242( )
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

      protected void E21242( )
      {
         /* 'AddDynamicFilters2' Routine */
         returnInSub = false;
         AV22DynamicFiltersEnabled3 = true;
         AssignAttri("", false, "AV22DynamicFiltersEnabled3", AV22DynamicFiltersEnabled3);
         imgAdddynamicfilters2_Visible = 0;
         AssignProp("", false, imgAdddynamicfilters2_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(imgAdddynamicfilters2_Visible), 5, 0), true);
         imgRemovedynamicfilters2_Visible = 1;
         AssignProp("", false, imgRemovedynamicfilters2_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(imgRemovedynamicfilters2_Visible), 5, 0), true);
         gxgrGrid_refresh( subGrid_Rows, AV15DynamicFiltersSelector1, AV16DynamicFiltersOperator1, AV17ConEntDsc1, AV49CueCod1, AV19DynamicFiltersSelector2, AV20DynamicFiltersOperator2, AV21ConEntDsc2, AV50CueCod2, AV23DynamicFiltersSelector3, AV24DynamicFiltersOperator3, AV25ConEntDsc3, AV51CueCod3, AV18DynamicFiltersEnabled2, AV22DynamicFiltersEnabled3, AV56Pgmname, AV31TFConEntCod, AV32TFConEntCod_To, AV33TFConEntDsc, AV34TFConEntDsc_Sel, AV35TFCueCod, AV36TFCueCod_Sel, AV37TFCueDsc, AV38TFCueDsc_Sel, AV53TFConEntSts_Sels, AV13OrderedBy, AV14OrderedDsc, AV10GridState, AV27DynamicFiltersIgnoreFirst, AV26DynamicFiltersRemoving) ;
         /*  Sending Event outputs  */
         cmbavDynamicfiltersoperator1.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV16DynamicFiltersOperator1), 4, 0));
         AssignProp("", false, cmbavDynamicfiltersoperator1_Internalname, "Values", cmbavDynamicfiltersoperator1.ToJavascriptSource(), true);
         cmbavDynamicfiltersoperator2.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV20DynamicFiltersOperator2), 4, 0));
         AssignProp("", false, cmbavDynamicfiltersoperator2_Internalname, "Values", cmbavDynamicfiltersoperator2.ToJavascriptSource(), true);
         cmbavDynamicfiltersoperator3.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV24DynamicFiltersOperator3), 4, 0));
         AssignProp("", false, cmbavDynamicfiltersoperator3_Internalname, "Values", cmbavDynamicfiltersoperator3.ToJavascriptSource(), true);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV10GridState", AV10GridState);
      }

      protected void E16242( )
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
         gxgrGrid_refresh( subGrid_Rows, AV15DynamicFiltersSelector1, AV16DynamicFiltersOperator1, AV17ConEntDsc1, AV49CueCod1, AV19DynamicFiltersSelector2, AV20DynamicFiltersOperator2, AV21ConEntDsc2, AV50CueCod2, AV23DynamicFiltersSelector3, AV24DynamicFiltersOperator3, AV25ConEntDsc3, AV51CueCod3, AV18DynamicFiltersEnabled2, AV22DynamicFiltersEnabled3, AV56Pgmname, AV31TFConEntCod, AV32TFConEntCod_To, AV33TFConEntDsc, AV34TFConEntDsc_Sel, AV35TFCueCod, AV36TFCueCod_Sel, AV37TFCueDsc, AV38TFCueDsc_Sel, AV53TFConEntSts_Sels, AV13OrderedBy, AV14OrderedDsc, AV10GridState, AV27DynamicFiltersIgnoreFirst, AV26DynamicFiltersRemoving) ;
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

      protected void E22242( )
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

      protected void E17242( )
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
         gxgrGrid_refresh( subGrid_Rows, AV15DynamicFiltersSelector1, AV16DynamicFiltersOperator1, AV17ConEntDsc1, AV49CueCod1, AV19DynamicFiltersSelector2, AV20DynamicFiltersOperator2, AV21ConEntDsc2, AV50CueCod2, AV23DynamicFiltersSelector3, AV24DynamicFiltersOperator3, AV25ConEntDsc3, AV51CueCod3, AV18DynamicFiltersEnabled2, AV22DynamicFiltersEnabled3, AV56Pgmname, AV31TFConEntCod, AV32TFConEntCod_To, AV33TFConEntDsc, AV34TFConEntDsc_Sel, AV35TFCueCod, AV36TFCueCod_Sel, AV37TFCueDsc, AV38TFCueDsc_Sel, AV53TFConEntSts_Sels, AV13OrderedBy, AV14OrderedDsc, AV10GridState, AV27DynamicFiltersIgnoreFirst, AV26DynamicFiltersRemoving) ;
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

      protected void E23242( )
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

      protected void E27242( )
      {
         /* Gridactions_Click Routine */
         returnInSub = false;
         if ( AV46GridActions == 1 )
         {
            /* Execute user subroutine: 'DO UPDATE' */
            S212 ();
            if ( returnInSub )
            {
               returnInSub = true;
               if (true) return;
            }
         }
         else if ( AV46GridActions == 2 )
         {
            /* Execute user subroutine: 'DO DELETE' */
            S222 ();
            if ( returnInSub )
            {
               returnInSub = true;
               if (true) return;
            }
         }
         AV46GridActions = 0;
         AssignAttri("", false, cmbavGridactions_Internalname, StringUtil.LTrimStr( (decimal)(AV46GridActions), 4, 0));
         /*  Sending Event outputs  */
         cmbavGridactions.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV46GridActions), 4, 0));
         AssignProp("", false, cmbavGridactions_Internalname, "Values", cmbavGridactions.ToJavascriptSource(), true);
      }

      protected void E18242( )
      {
         /* 'DoInsert' Routine */
         returnInSub = false;
         GXKey = Crypto.GetSiteKey( );
         GXEncryptionTmp = "bancos.conceptoentregarendir.aspx"+UrlEncode(StringUtil.RTrim("INS")) + "," + UrlEncode(StringUtil.LTrimStr(0,1,0));
         CallWebObject(formatLink("bancos.conceptoentregarendir.aspx") + "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey));
         context.wjLocDisableFrm = 1;
      }

      protected void E13242( )
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
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV53TFConEntSts_Sels", AV53TFConEntSts_Sels);
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
         edtavConentdsc1_Visible = 0;
         AssignProp("", false, edtavConentdsc1_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavConentdsc1_Visible), 5, 0), true);
         edtavCuecod1_Visible = 0;
         AssignProp("", false, edtavCuecod1_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavCuecod1_Visible), 5, 0), true);
         cmbavDynamicfiltersoperator1.Visible = 0;
         AssignProp("", false, cmbavDynamicfiltersoperator1_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(cmbavDynamicfiltersoperator1.Visible), 5, 0), true);
         if ( StringUtil.StrCmp(AV15DynamicFiltersSelector1, "CONENTDSC") == 0 )
         {
            edtavConentdsc1_Visible = 1;
            AssignProp("", false, edtavConentdsc1_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavConentdsc1_Visible), 5, 0), true);
            cmbavDynamicfiltersoperator1.Visible = 1;
            AssignProp("", false, cmbavDynamicfiltersoperator1_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(cmbavDynamicfiltersoperator1.Visible), 5, 0), true);
         }
         else if ( StringUtil.StrCmp(AV15DynamicFiltersSelector1, "CUECOD") == 0 )
         {
            edtavCuecod1_Visible = 1;
            AssignProp("", false, edtavCuecod1_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavCuecod1_Visible), 5, 0), true);
            cmbavDynamicfiltersoperator1.Visible = 1;
            AssignProp("", false, cmbavDynamicfiltersoperator1_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(cmbavDynamicfiltersoperator1.Visible), 5, 0), true);
         }
      }

      protected void S122( )
      {
         /* 'ENABLEDYNAMICFILTERS2' Routine */
         returnInSub = false;
         edtavConentdsc2_Visible = 0;
         AssignProp("", false, edtavConentdsc2_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavConentdsc2_Visible), 5, 0), true);
         edtavCuecod2_Visible = 0;
         AssignProp("", false, edtavCuecod2_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavCuecod2_Visible), 5, 0), true);
         cmbavDynamicfiltersoperator2.Visible = 0;
         AssignProp("", false, cmbavDynamicfiltersoperator2_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(cmbavDynamicfiltersoperator2.Visible), 5, 0), true);
         if ( StringUtil.StrCmp(AV19DynamicFiltersSelector2, "CONENTDSC") == 0 )
         {
            edtavConentdsc2_Visible = 1;
            AssignProp("", false, edtavConentdsc2_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavConentdsc2_Visible), 5, 0), true);
            cmbavDynamicfiltersoperator2.Visible = 1;
            AssignProp("", false, cmbavDynamicfiltersoperator2_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(cmbavDynamicfiltersoperator2.Visible), 5, 0), true);
         }
         else if ( StringUtil.StrCmp(AV19DynamicFiltersSelector2, "CUECOD") == 0 )
         {
            edtavCuecod2_Visible = 1;
            AssignProp("", false, edtavCuecod2_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavCuecod2_Visible), 5, 0), true);
            cmbavDynamicfiltersoperator2.Visible = 1;
            AssignProp("", false, cmbavDynamicfiltersoperator2_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(cmbavDynamicfiltersoperator2.Visible), 5, 0), true);
         }
      }

      protected void S132( )
      {
         /* 'ENABLEDYNAMICFILTERS3' Routine */
         returnInSub = false;
         edtavConentdsc3_Visible = 0;
         AssignProp("", false, edtavConentdsc3_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavConentdsc3_Visible), 5, 0), true);
         edtavCuecod3_Visible = 0;
         AssignProp("", false, edtavCuecod3_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavCuecod3_Visible), 5, 0), true);
         cmbavDynamicfiltersoperator3.Visible = 0;
         AssignProp("", false, cmbavDynamicfiltersoperator3_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(cmbavDynamicfiltersoperator3.Visible), 5, 0), true);
         if ( StringUtil.StrCmp(AV23DynamicFiltersSelector3, "CONENTDSC") == 0 )
         {
            edtavConentdsc3_Visible = 1;
            AssignProp("", false, edtavConentdsc3_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavConentdsc3_Visible), 5, 0), true);
            cmbavDynamicfiltersoperator3.Visible = 1;
            AssignProp("", false, cmbavDynamicfiltersoperator3_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(cmbavDynamicfiltersoperator3.Visible), 5, 0), true);
         }
         else if ( StringUtil.StrCmp(AV23DynamicFiltersSelector3, "CUECOD") == 0 )
         {
            edtavCuecod3_Visible = 1;
            AssignProp("", false, edtavCuecod3_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavCuecod3_Visible), 5, 0), true);
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
         AV19DynamicFiltersSelector2 = "CONENTDSC";
         AssignAttri("", false, "AV19DynamicFiltersSelector2", AV19DynamicFiltersSelector2);
         AV20DynamicFiltersOperator2 = 0;
         AssignAttri("", false, "AV20DynamicFiltersOperator2", StringUtil.LTrimStr( (decimal)(AV20DynamicFiltersOperator2), 4, 0));
         AV21ConEntDsc2 = "";
         AssignAttri("", false, "AV21ConEntDsc2", AV21ConEntDsc2);
         /* Execute user subroutine: 'ENABLEDYNAMICFILTERS2' */
         S122 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
         AV22DynamicFiltersEnabled3 = false;
         AssignAttri("", false, "AV22DynamicFiltersEnabled3", AV22DynamicFiltersEnabled3);
         AV23DynamicFiltersSelector3 = "CONENTDSC";
         AssignAttri("", false, "AV23DynamicFiltersSelector3", AV23DynamicFiltersSelector3);
         AV24DynamicFiltersOperator3 = 0;
         AssignAttri("", false, "AV24DynamicFiltersOperator3", StringUtil.LTrimStr( (decimal)(AV24DynamicFiltersOperator3), 4, 0));
         AV25ConEntDsc3 = "";
         AssignAttri("", false, "AV25ConEntDsc3", AV25ConEntDsc3);
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
         GXEncryptionTmp = "bancos.conceptoentregarendir.aspx"+UrlEncode(StringUtil.RTrim("UPD")) + "," + UrlEncode(StringUtil.LTrimStr(A376ConEntCod,6,0));
         CallWebObject(formatLink("bancos.conceptoentregarendir.aspx") + "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey));
         context.wjLocDisableFrm = 1;
      }

      protected void S222( )
      {
         /* 'DO DELETE' Routine */
         returnInSub = false;
         GXKey = Crypto.GetSiteKey( );
         GXEncryptionTmp = "bancos.conceptoentregarendir.aspx"+UrlEncode(StringUtil.RTrim("DLT")) + "," + UrlEncode(StringUtil.LTrimStr(A376ConEntCod,6,0));
         CallWebObject(formatLink("bancos.conceptoentregarendir.aspx") + "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey));
         context.wjLocDisableFrm = 1;
      }

      protected void S152( )
      {
         /* 'LOADGRIDSTATE' Routine */
         returnInSub = false;
         if ( StringUtil.StrCmp(AV30Session.Get(AV56Pgmname+"GridState"), "") == 0 )
         {
            AV10GridState.FromXml(new GeneXus.Programs.wwpbaseobjects.loadgridstate(context).executeUdp(  AV56Pgmname+"GridState"), null, "", "");
         }
         else
         {
            AV10GridState.FromXml(AV30Session.Get(AV56Pgmname+"GridState"), null, "", "");
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
         AV80GXV1 = 1;
         while ( AV80GXV1 <= AV10GridState.gxTpr_Filtervalues.Count )
         {
            AV11GridStateFilterValue = ((GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue)AV10GridState.gxTpr_Filtervalues.Item(AV80GXV1));
            if ( StringUtil.StrCmp(AV11GridStateFilterValue.gxTpr_Name, "TFCONENTCOD") == 0 )
            {
               AV31TFConEntCod = (int)(NumberUtil.Val( AV11GridStateFilterValue.gxTpr_Value, "."));
               AssignAttri("", false, "AV31TFConEntCod", StringUtil.LTrimStr( (decimal)(AV31TFConEntCod), 6, 0));
               AV32TFConEntCod_To = (int)(NumberUtil.Val( AV11GridStateFilterValue.gxTpr_Valueto, "."));
               AssignAttri("", false, "AV32TFConEntCod_To", StringUtil.LTrimStr( (decimal)(AV32TFConEntCod_To), 6, 0));
            }
            else if ( StringUtil.StrCmp(AV11GridStateFilterValue.gxTpr_Name, "TFCONENTDSC") == 0 )
            {
               AV33TFConEntDsc = AV11GridStateFilterValue.gxTpr_Value;
               AssignAttri("", false, "AV33TFConEntDsc", AV33TFConEntDsc);
            }
            else if ( StringUtil.StrCmp(AV11GridStateFilterValue.gxTpr_Name, "TFCONENTDSC_SEL") == 0 )
            {
               AV34TFConEntDsc_Sel = AV11GridStateFilterValue.gxTpr_Value;
               AssignAttri("", false, "AV34TFConEntDsc_Sel", AV34TFConEntDsc_Sel);
            }
            else if ( StringUtil.StrCmp(AV11GridStateFilterValue.gxTpr_Name, "TFCUECOD") == 0 )
            {
               AV35TFCueCod = AV11GridStateFilterValue.gxTpr_Value;
               AssignAttri("", false, "AV35TFCueCod", AV35TFCueCod);
            }
            else if ( StringUtil.StrCmp(AV11GridStateFilterValue.gxTpr_Name, "TFCUECOD_SEL") == 0 )
            {
               AV36TFCueCod_Sel = AV11GridStateFilterValue.gxTpr_Value;
               AssignAttri("", false, "AV36TFCueCod_Sel", AV36TFCueCod_Sel);
            }
            else if ( StringUtil.StrCmp(AV11GridStateFilterValue.gxTpr_Name, "TFCUEDSC") == 0 )
            {
               AV37TFCueDsc = AV11GridStateFilterValue.gxTpr_Value;
               AssignAttri("", false, "AV37TFCueDsc", AV37TFCueDsc);
            }
            else if ( StringUtil.StrCmp(AV11GridStateFilterValue.gxTpr_Name, "TFCUEDSC_SEL") == 0 )
            {
               AV38TFCueDsc_Sel = AV11GridStateFilterValue.gxTpr_Value;
               AssignAttri("", false, "AV38TFCueDsc_Sel", AV38TFCueDsc_Sel);
            }
            else if ( StringUtil.StrCmp(AV11GridStateFilterValue.gxTpr_Name, "TFCONENTSTS_SEL") == 0 )
            {
               AV52TFConEntSts_SelsJson = AV11GridStateFilterValue.gxTpr_Value;
               AssignAttri("", false, "AV52TFConEntSts_SelsJson", AV52TFConEntSts_SelsJson);
               AV53TFConEntSts_Sels.FromJSonString(AV52TFConEntSts_SelsJson, null);
            }
            AV80GXV1 = (int)(AV80GXV1+1);
         }
         GXt_char2 = "";
         new GeneXus.Programs.wwpbaseobjects.wwp_getfilterval(context ).execute(  String.IsNullOrEmpty(StringUtil.RTrim( AV34TFConEntDsc_Sel)),  AV34TFConEntDsc_Sel, out  GXt_char2) ;
         GXt_char3 = "";
         new GeneXus.Programs.wwpbaseobjects.wwp_getfilterval(context ).execute(  String.IsNullOrEmpty(StringUtil.RTrim( AV36TFCueCod_Sel)),  AV36TFCueCod_Sel, out  GXt_char3) ;
         GXt_char4 = "";
         new GeneXus.Programs.wwpbaseobjects.wwp_getfilterval(context ).execute(  String.IsNullOrEmpty(StringUtil.RTrim( AV38TFCueDsc_Sel)),  AV38TFCueDsc_Sel, out  GXt_char4) ;
         Ddo_grid_Selectedvalue_set = "|"+GXt_char2+"|"+GXt_char3+"|"+GXt_char4+"|"+((AV53TFConEntSts_Sels.Count==0) ? "" : AV52TFConEntSts_SelsJson);
         ucDdo_grid.SendProperty(context, "", false, Ddo_grid_Internalname, "SelectedValue_set", Ddo_grid_Selectedvalue_set);
         GXt_char4 = "";
         new GeneXus.Programs.wwpbaseobjects.wwp_getfilterval(context ).execute(  String.IsNullOrEmpty(StringUtil.RTrim( AV33TFConEntDsc)),  AV33TFConEntDsc, out  GXt_char4) ;
         GXt_char3 = "";
         new GeneXus.Programs.wwpbaseobjects.wwp_getfilterval(context ).execute(  String.IsNullOrEmpty(StringUtil.RTrim( AV35TFCueCod)),  AV35TFCueCod, out  GXt_char3) ;
         GXt_char2 = "";
         new GeneXus.Programs.wwpbaseobjects.wwp_getfilterval(context ).execute(  String.IsNullOrEmpty(StringUtil.RTrim( AV37TFCueDsc)),  AV37TFCueDsc, out  GXt_char2) ;
         Ddo_grid_Filteredtext_set = ((0==AV31TFConEntCod) ? "" : StringUtil.Str( (decimal)(AV31TFConEntCod), 6, 0))+"|"+GXt_char4+"|"+GXt_char3+"|"+GXt_char2+"|";
         ucDdo_grid.SendProperty(context, "", false, Ddo_grid_Internalname, "FilteredText_set", Ddo_grid_Filteredtext_set);
         Ddo_grid_Filteredtextto_set = ((0==AV32TFConEntCod_To) ? "" : StringUtil.Str( (decimal)(AV32TFConEntCod_To), 6, 0))+"||||";
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
            if ( StringUtil.StrCmp(AV15DynamicFiltersSelector1, "CONENTDSC") == 0 )
            {
               AV16DynamicFiltersOperator1 = AV12GridStateDynamicFilter.gxTpr_Operator;
               AssignAttri("", false, "AV16DynamicFiltersOperator1", StringUtil.LTrimStr( (decimal)(AV16DynamicFiltersOperator1), 4, 0));
               AV17ConEntDsc1 = AV12GridStateDynamicFilter.gxTpr_Value;
               AssignAttri("", false, "AV17ConEntDsc1", AV17ConEntDsc1);
            }
            else if ( StringUtil.StrCmp(AV15DynamicFiltersSelector1, "CUECOD") == 0 )
            {
               AV16DynamicFiltersOperator1 = AV12GridStateDynamicFilter.gxTpr_Operator;
               AssignAttri("", false, "AV16DynamicFiltersOperator1", StringUtil.LTrimStr( (decimal)(AV16DynamicFiltersOperator1), 4, 0));
               AV49CueCod1 = AV12GridStateDynamicFilter.gxTpr_Value;
               AssignAttri("", false, "AV49CueCod1", AV49CueCod1);
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
               if ( StringUtil.StrCmp(AV19DynamicFiltersSelector2, "CONENTDSC") == 0 )
               {
                  AV20DynamicFiltersOperator2 = AV12GridStateDynamicFilter.gxTpr_Operator;
                  AssignAttri("", false, "AV20DynamicFiltersOperator2", StringUtil.LTrimStr( (decimal)(AV20DynamicFiltersOperator2), 4, 0));
                  AV21ConEntDsc2 = AV12GridStateDynamicFilter.gxTpr_Value;
                  AssignAttri("", false, "AV21ConEntDsc2", AV21ConEntDsc2);
               }
               else if ( StringUtil.StrCmp(AV19DynamicFiltersSelector2, "CUECOD") == 0 )
               {
                  AV20DynamicFiltersOperator2 = AV12GridStateDynamicFilter.gxTpr_Operator;
                  AssignAttri("", false, "AV20DynamicFiltersOperator2", StringUtil.LTrimStr( (decimal)(AV20DynamicFiltersOperator2), 4, 0));
                  AV50CueCod2 = AV12GridStateDynamicFilter.gxTpr_Value;
                  AssignAttri("", false, "AV50CueCod2", AV50CueCod2);
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
                  if ( StringUtil.StrCmp(AV23DynamicFiltersSelector3, "CONENTDSC") == 0 )
                  {
                     AV24DynamicFiltersOperator3 = AV12GridStateDynamicFilter.gxTpr_Operator;
                     AssignAttri("", false, "AV24DynamicFiltersOperator3", StringUtil.LTrimStr( (decimal)(AV24DynamicFiltersOperator3), 4, 0));
                     AV25ConEntDsc3 = AV12GridStateDynamicFilter.gxTpr_Value;
                     AssignAttri("", false, "AV25ConEntDsc3", AV25ConEntDsc3);
                  }
                  else if ( StringUtil.StrCmp(AV23DynamicFiltersSelector3, "CUECOD") == 0 )
                  {
                     AV24DynamicFiltersOperator3 = AV12GridStateDynamicFilter.gxTpr_Operator;
                     AssignAttri("", false, "AV24DynamicFiltersOperator3", StringUtil.LTrimStr( (decimal)(AV24DynamicFiltersOperator3), 4, 0));
                     AV51CueCod3 = AV12GridStateDynamicFilter.gxTpr_Value;
                     AssignAttri("", false, "AV51CueCod3", AV51CueCod3);
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
         AV10GridState.FromXml(AV30Session.Get(AV56Pgmname+"GridState"), null, "", "");
         AV10GridState.gxTpr_Orderedby = AV13OrderedBy;
         AV10GridState.gxTpr_Ordereddsc = AV14OrderedDsc;
         AV10GridState.gxTpr_Filtervalues.Clear();
         new GeneXus.Programs.wwpbaseobjects.wwp_gridstateaddfiltervalue(context ).execute( ref  AV10GridState,  "TFCONENTCOD",  "Codigo",  !((0==AV31TFConEntCod)&&(0==AV32TFConEntCod_To)),  0,  StringUtil.Trim( StringUtil.Str( (decimal)(AV31TFConEntCod), 6, 0)),  StringUtil.Trim( StringUtil.Str( (decimal)(AV32TFConEntCod_To), 6, 0))) ;
         new GeneXus.Programs.wwpbaseobjects.wwp_gridstateaddfiltervalueandsel(context ).execute( ref  AV10GridState,  "TFCONENTDSC",  "Concepto Entrega Rendir",  !String.IsNullOrEmpty(StringUtil.RTrim( AV33TFConEntDsc)),  0,  AV33TFConEntDsc,  "",  !String.IsNullOrEmpty(StringUtil.RTrim( AV34TFConEntDsc_Sel)),  AV34TFConEntDsc_Sel,  "") ;
         new GeneXus.Programs.wwpbaseobjects.wwp_gridstateaddfiltervalueandsel(context ).execute( ref  AV10GridState,  "TFCUECOD",  "Cuenta Contable",  !String.IsNullOrEmpty(StringUtil.RTrim( AV35TFCueCod)),  0,  AV35TFCueCod,  "",  !String.IsNullOrEmpty(StringUtil.RTrim( AV36TFCueCod_Sel)),  AV36TFCueCod_Sel,  "") ;
         new GeneXus.Programs.wwpbaseobjects.wwp_gridstateaddfiltervalueandsel(context ).execute( ref  AV10GridState,  "TFCUEDSC",  "Descripci?n de Cuenta",  !String.IsNullOrEmpty(StringUtil.RTrim( AV37TFCueDsc)),  0,  AV37TFCueDsc,  "",  !String.IsNullOrEmpty(StringUtil.RTrim( AV38TFCueDsc_Sel)),  AV38TFCueDsc_Sel,  "") ;
         new GeneXus.Programs.wwpbaseobjects.wwp_gridstateaddfiltervalue(context ).execute( ref  AV10GridState,  "TFCONENTSTS_SEL",  "Estado",  !(AV53TFConEntSts_Sels.Count==0),  0,  AV53TFConEntSts_Sels.ToJSonString(false),  "") ;
         /* Execute user subroutine: 'SAVEDYNFILTERSSTATE' */
         S182 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
         AV10GridState.gxTpr_Pagesize = StringUtil.Str( (decimal)(subGrid_Rows), 10, 0);
         AV10GridState.gxTpr_Currentpage = (short)(subGrid_fnc_Currentpage( ));
         new GeneXus.Programs.wwpbaseobjects.savegridstate(context ).execute(  AV56Pgmname+"GridState",  AV10GridState.ToXml(false, true, "", "")) ;
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
            if ( ( StringUtil.StrCmp(AV15DynamicFiltersSelector1, "CONENTDSC") == 0 ) && ! String.IsNullOrEmpty(StringUtil.RTrim( AV17ConEntDsc1)) )
            {
               AV12GridStateDynamicFilter.gxTpr_Dsc = "Concepto de Entrega";
               AV12GridStateDynamicFilter.gxTpr_Value = AV17ConEntDsc1;
               AV12GridStateDynamicFilter.gxTpr_Operator = AV16DynamicFiltersOperator1;
            }
            else if ( ( StringUtil.StrCmp(AV15DynamicFiltersSelector1, "CUECOD") == 0 ) && ! String.IsNullOrEmpty(StringUtil.RTrim( AV49CueCod1)) )
            {
               AV12GridStateDynamicFilter.gxTpr_Dsc = "Cuenta Contable";
               AV12GridStateDynamicFilter.gxTpr_Value = AV49CueCod1;
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
            if ( ( StringUtil.StrCmp(AV19DynamicFiltersSelector2, "CONENTDSC") == 0 ) && ! String.IsNullOrEmpty(StringUtil.RTrim( AV21ConEntDsc2)) )
            {
               AV12GridStateDynamicFilter.gxTpr_Dsc = "Concepto de Entrega";
               AV12GridStateDynamicFilter.gxTpr_Value = AV21ConEntDsc2;
               AV12GridStateDynamicFilter.gxTpr_Operator = AV20DynamicFiltersOperator2;
            }
            else if ( ( StringUtil.StrCmp(AV19DynamicFiltersSelector2, "CUECOD") == 0 ) && ! String.IsNullOrEmpty(StringUtil.RTrim( AV50CueCod2)) )
            {
               AV12GridStateDynamicFilter.gxTpr_Dsc = "Cuenta Contable";
               AV12GridStateDynamicFilter.gxTpr_Value = AV50CueCod2;
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
            if ( ( StringUtil.StrCmp(AV23DynamicFiltersSelector3, "CONENTDSC") == 0 ) && ! String.IsNullOrEmpty(StringUtil.RTrim( AV25ConEntDsc3)) )
            {
               AV12GridStateDynamicFilter.gxTpr_Dsc = "Concepto de Entrega";
               AV12GridStateDynamicFilter.gxTpr_Value = AV25ConEntDsc3;
               AV12GridStateDynamicFilter.gxTpr_Operator = AV24DynamicFiltersOperator3;
            }
            else if ( ( StringUtil.StrCmp(AV23DynamicFiltersSelector3, "CUECOD") == 0 ) && ! String.IsNullOrEmpty(StringUtil.RTrim( AV51CueCod3)) )
            {
               AV12GridStateDynamicFilter.gxTpr_Dsc = "Cuenta Contable";
               AV12GridStateDynamicFilter.gxTpr_Value = AV51CueCod3;
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
         AV8TrnContext.gxTpr_Callerobject = AV56Pgmname;
         AV8TrnContext.gxTpr_Callerondelete = true;
         AV8TrnContext.gxTpr_Callerurl = AV7HTTPRequest.ScriptName+"?"+AV7HTTPRequest.QueryString;
         AV8TrnContext.gxTpr_Transactionname = "Bancos.ConceptoEntregaRendir";
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
         new GeneXus.Programs.bancos.conceptoentregarendirwwexport(context ).execute( out  AV28ExcelFilename, out  AV29ErrorMessage) ;
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
         Innewwindow1_Target = formatLink("bancos.conceptoentregarendirwwexportreport.aspx") ;
         ucInnewwindow1.SendProperty(context, "", false, Innewwindow1_Internalname, "Target", Innewwindow1_Target);
         Innewwindow1_Height = "600";
         ucInnewwindow1.SendProperty(context, "", false, Innewwindow1_Internalname, "Height", Innewwindow1_Height);
         Innewwindow1_Width = "800";
         ucInnewwindow1.SendProperty(context, "", false, Innewwindow1_Internalname, "Width", Innewwindow1_Width);
         this.executeUsercontrolMethod("", false, "INNEWWINDOW1Container", "OpenWindow", "", new Object[] {});
      }

      protected void wb_table1_25_242( bool wbgen )
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
            GxWebStd.gx_label_ctrl( context, lblDynamicfiltersprefix1_Internalname, "Buscar en", "", "", lblDynamicfiltersprefix1_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "DataFilterDescriptionPrefix", 0, "", 1, 1, 0, 0, "HLP_Bancos\\ConceptoEntregaRendirWW.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "", "left", "top", "", "flex-grow:1;", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "left", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, cmbavDynamicfiltersselector1_Internalname, "Dynamic Filters Selector1", "gx-form-item AttributeLabel", 0, true, "width: 25%;");
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 35,'',false,'" + sGXsfl_110_idx + "',0)\"";
            /* ComboBox */
            GxWebStd.gx_combobox_ctrl1( context, cmbavDynamicfiltersselector1, cmbavDynamicfiltersselector1_Internalname, StringUtil.RTrim( AV15DynamicFiltersSelector1), 1, cmbavDynamicfiltersselector1_Jsonclick, 5, "'"+""+"'"+",false,"+"'"+"EVDYNAMICFILTERSSELECTOR1.CLICK."+"'", "svchar", "", 1, cmbavDynamicfiltersselector1.Enabled, 0, 0, 0, "em", 0, "", "", "Attribute", "", "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,35);\"", "", true, 1, "HLP_Bancos\\ConceptoEntregaRendirWW.htm");
            cmbavDynamicfiltersselector1.CurrentValue = StringUtil.RTrim( AV15DynamicFiltersSelector1);
            AssignProp("", false, cmbavDynamicfiltersselector1_Internalname, "Values", (string)(cmbavDynamicfiltersselector1.ToJavascriptSource()), true);
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "", "left", "top", "", "flex-grow:1;", "div");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblDynamicfiltersmiddle1_Internalname, "valor", "", "", lblDynamicfiltersmiddle1_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "DataFilterDescription", 0, "", 1, 1, 0, 0, "HLP_Bancos\\ConceptoEntregaRendirWW.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "", "left", "top", "", "flex-grow:1;", "div");
            wb_table2_39_242( true) ;
         }
         else
         {
            wb_table2_39_242( false) ;
         }
         return  ;
      }

      protected void wb_table2_39_242e( bool wbgen )
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
            GxWebStd.gx_label_ctrl( context, lblDynamicfiltersprefix2_Internalname, "Buscar en", "", "", lblDynamicfiltersprefix2_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "DataFilterDescriptionPrefix", 0, "", 1, 1, 0, 0, "HLP_Bancos\\ConceptoEntregaRendirWW.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "Invisible", "left", "top", "", "flex-grow:1;", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "left", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, cmbavDynamicfiltersselector2_Internalname, "Dynamic Filters Selector2", "gx-form-item AttributeLabel", 0, true, "width: 25%;");
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 60,'',false,'" + sGXsfl_110_idx + "',0)\"";
            /* ComboBox */
            GxWebStd.gx_combobox_ctrl1( context, cmbavDynamicfiltersselector2, cmbavDynamicfiltersselector2_Internalname, StringUtil.RTrim( AV19DynamicFiltersSelector2), 1, cmbavDynamicfiltersselector2_Jsonclick, 5, "'"+""+"'"+",false,"+"'"+"EVDYNAMICFILTERSSELECTOR2.CLICK."+"'", "svchar", "", 1, cmbavDynamicfiltersselector2.Enabled, 0, 0, 0, "em", 0, "", "", "Attribute", "", "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,60);\"", "", true, 1, "HLP_Bancos\\ConceptoEntregaRendirWW.htm");
            cmbavDynamicfiltersselector2.CurrentValue = StringUtil.RTrim( AV19DynamicFiltersSelector2);
            AssignProp("", false, cmbavDynamicfiltersselector2_Internalname, "Values", (string)(cmbavDynamicfiltersselector2.ToJavascriptSource()), true);
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "Invisible", "left", "top", "", "flex-grow:1;", "div");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblDynamicfiltersmiddle2_Internalname, "valor", "", "", lblDynamicfiltersmiddle2_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "DataFilterDescription", 0, "", 1, 1, 0, 0, "HLP_Bancos\\ConceptoEntregaRendirWW.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "Invisible", "left", "top", "", "flex-grow:1;", "div");
            wb_table3_64_242( true) ;
         }
         else
         {
            wb_table3_64_242( false) ;
         }
         return  ;
      }

      protected void wb_table3_64_242e( bool wbgen )
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
            GxWebStd.gx_label_ctrl( context, lblDynamicfiltersprefix3_Internalname, "Buscar en", "", "", lblDynamicfiltersprefix3_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "DataFilterDescriptionPrefix", 0, "", 1, 1, 0, 0, "HLP_Bancos\\ConceptoEntregaRendirWW.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "Invisible", "left", "top", "", "flex-grow:1;", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "left", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, cmbavDynamicfiltersselector3_Internalname, "Dynamic Filters Selector3", "gx-form-item AttributeLabel", 0, true, "width: 25%;");
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 85,'',false,'" + sGXsfl_110_idx + "',0)\"";
            /* ComboBox */
            GxWebStd.gx_combobox_ctrl1( context, cmbavDynamicfiltersselector3, cmbavDynamicfiltersselector3_Internalname, StringUtil.RTrim( AV23DynamicFiltersSelector3), 1, cmbavDynamicfiltersselector3_Jsonclick, 5, "'"+""+"'"+",false,"+"'"+"EVDYNAMICFILTERSSELECTOR3.CLICK."+"'", "svchar", "", 1, cmbavDynamicfiltersselector3.Enabled, 0, 0, 0, "em", 0, "", "", "Attribute", "", "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,85);\"", "", true, 1, "HLP_Bancos\\ConceptoEntregaRendirWW.htm");
            cmbavDynamicfiltersselector3.CurrentValue = StringUtil.RTrim( AV23DynamicFiltersSelector3);
            AssignProp("", false, cmbavDynamicfiltersselector3_Internalname, "Values", (string)(cmbavDynamicfiltersselector3.ToJavascriptSource()), true);
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "Invisible", "left", "top", "", "flex-grow:1;", "div");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblDynamicfiltersmiddle3_Internalname, "valor", "", "", lblDynamicfiltersmiddle3_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "DataFilterDescription", 0, "", 1, 1, 0, 0, "HLP_Bancos\\ConceptoEntregaRendirWW.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "Invisible", "left", "top", "", "flex-grow:1;", "div");
            wb_table4_89_242( true) ;
         }
         else
         {
            wb_table4_89_242( false) ;
         }
         return  ;
      }

      protected void wb_table4_89_242e( bool wbgen )
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
            wb_table1_25_242e( true) ;
         }
         else
         {
            wb_table1_25_242e( false) ;
         }
      }

      protected void wb_table4_89_242( bool wbgen )
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
            GxWebStd.gx_combobox_ctrl1( context, cmbavDynamicfiltersoperator3, cmbavDynamicfiltersoperator3_Internalname, StringUtil.Trim( StringUtil.Str( (decimal)(AV24DynamicFiltersOperator3), 4, 0)), 1, cmbavDynamicfiltersoperator3_Jsonclick, 0, "'"+""+"'"+",false,"+"'"+""+"'", "int", "", cmbavDynamicfiltersoperator3.Visible, cmbavDynamicfiltersoperator3.Enabled, 0, 0, 0, "em", 0, "", "", "Attribute", "", "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,93);\"", "", true, 1, "HLP_Bancos\\ConceptoEntregaRendirWW.htm");
            cmbavDynamicfiltersoperator3.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV24DynamicFiltersOperator3), 4, 0));
            AssignProp("", false, cmbavDynamicfiltersoperator3_Internalname, "Values", (string)(cmbavDynamicfiltersoperator3.ToJavascriptSource()), true);
            GxWebStd.gx_div_end( context, "left", "top", "div");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "<td id=\""+cellFilter_conentdsc3_cell_Internalname+"\"  class=''>") ;
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "left", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavConentdsc3_Internalname, "Con Ent Dsc3", "gx-form-item AttributeLabel", 0, true, "width: 25%;");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 96,'',false,'" + sGXsfl_110_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavConentdsc3_Internalname, StringUtil.RTrim( AV25ConEntDsc3), StringUtil.RTrim( context.localUtil.Format( AV25ConEntDsc3, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,96);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavConentdsc3_Jsonclick, 0, "Attribute", "", "", "", "", edtavConentdsc3_Visible, edtavConentdsc3_Enabled, 0, "text", "", 80, "chr", 1, "row", 100, 0, 0, 0, 1, -1, -1, true, "", "left", true, "", "HLP_Bancos\\ConceptoEntregaRendirWW.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "<td id=\""+cellFilter_cuecod3_cell_Internalname+"\"  class=''>") ;
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "left", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavCuecod3_Internalname, "Cue Cod3", "gx-form-item AttributeLabel", 0, true, "width: 25%;");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 99,'',false,'" + sGXsfl_110_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavCuecod3_Internalname, StringUtil.RTrim( AV51CueCod3), StringUtil.RTrim( context.localUtil.Format( AV51CueCod3, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,99);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavCuecod3_Jsonclick, 0, "Attribute", "", "", "", "", edtavCuecod3_Visible, edtavCuecod3_Enabled, 0, "text", "", 15, "chr", 1, "row", 15, 0, 0, 0, 1, -1, -1, true, "", "left", true, "", "HLP_Bancos\\ConceptoEntregaRendirWW.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "<td id=\""+cellDynamicfilters_removefilter3_cell_Internalname+"\"  class=''>") ;
            /* Active images/pictures */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 101,'',false,'',0)\"";
            ClassString = "Image";
            StyleString = "";
            sImgUrl = (string)(context.GetImagePath( "11a6ef14-1a5a-4077-91a2-f41ed9a3a662", "", context.GetTheme( )));
            GxWebStd.gx_bitmap( context, imgRemovedynamicfilters3_Internalname, sImgUrl, "", "", "", context.GetTheme( ), 1, 1, "", "Quitar filtro", 0, 0, 0, "px", 0, "px", 0, 0, 5, imgRemovedynamicfilters3_Jsonclick, "'"+""+"'"+",false,"+"'"+"E\\'REMOVEDYNAMICFILTERS3\\'."+"'", StyleString, ClassString, "", "", "", "", " "+"data-gx-image"+" "+TempTags, "", "", 1, false, false, context.GetImageSrcSet( sImgUrl), "HLP_Bancos\\ConceptoEntregaRendirWW.htm");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "</tr>") ;
            /* End of table */
            context.WriteHtmlText( "</table>") ;
            wb_table4_89_242e( true) ;
         }
         else
         {
            wb_table4_89_242e( false) ;
         }
      }

      protected void wb_table3_64_242( bool wbgen )
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
            GxWebStd.gx_combobox_ctrl1( context, cmbavDynamicfiltersoperator2, cmbavDynamicfiltersoperator2_Internalname, StringUtil.Trim( StringUtil.Str( (decimal)(AV20DynamicFiltersOperator2), 4, 0)), 1, cmbavDynamicfiltersoperator2_Jsonclick, 0, "'"+""+"'"+",false,"+"'"+""+"'", "int", "", cmbavDynamicfiltersoperator2.Visible, cmbavDynamicfiltersoperator2.Enabled, 0, 0, 0, "em", 0, "", "", "Attribute", "", "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,68);\"", "", true, 1, "HLP_Bancos\\ConceptoEntregaRendirWW.htm");
            cmbavDynamicfiltersoperator2.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV20DynamicFiltersOperator2), 4, 0));
            AssignProp("", false, cmbavDynamicfiltersoperator2_Internalname, "Values", (string)(cmbavDynamicfiltersoperator2.ToJavascriptSource()), true);
            GxWebStd.gx_div_end( context, "left", "top", "div");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "<td id=\""+cellFilter_conentdsc2_cell_Internalname+"\"  class=''>") ;
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "left", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavConentdsc2_Internalname, "Con Ent Dsc2", "gx-form-item AttributeLabel", 0, true, "width: 25%;");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 71,'',false,'" + sGXsfl_110_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavConentdsc2_Internalname, StringUtil.RTrim( AV21ConEntDsc2), StringUtil.RTrim( context.localUtil.Format( AV21ConEntDsc2, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,71);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavConentdsc2_Jsonclick, 0, "Attribute", "", "", "", "", edtavConentdsc2_Visible, edtavConentdsc2_Enabled, 0, "text", "", 80, "chr", 1, "row", 100, 0, 0, 0, 1, -1, -1, true, "", "left", true, "", "HLP_Bancos\\ConceptoEntregaRendirWW.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "<td id=\""+cellFilter_cuecod2_cell_Internalname+"\"  class=''>") ;
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "left", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavCuecod2_Internalname, "Cue Cod2", "gx-form-item AttributeLabel", 0, true, "width: 25%;");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 74,'',false,'" + sGXsfl_110_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavCuecod2_Internalname, StringUtil.RTrim( AV50CueCod2), StringUtil.RTrim( context.localUtil.Format( AV50CueCod2, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,74);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavCuecod2_Jsonclick, 0, "Attribute", "", "", "", "", edtavCuecod2_Visible, edtavCuecod2_Enabled, 0, "text", "", 15, "chr", 1, "row", 15, 0, 0, 0, 1, -1, -1, true, "", "left", true, "", "HLP_Bancos\\ConceptoEntregaRendirWW.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "<td id=\""+cellDynamicfilters_addfilter2_cell_Internalname+"\"  class=''>") ;
            /* Active images/pictures */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 76,'',false,'',0)\"";
            ClassString = "Image";
            StyleString = "";
            sImgUrl = (string)(context.GetImagePath( "27283ea5-332f-423b-b880-64b762622df3", "", context.GetTheme( )));
            GxWebStd.gx_bitmap( context, imgAdddynamicfilters2_Internalname, sImgUrl, "", "", "", context.GetTheme( ), imgAdddynamicfilters2_Visible, 1, "", "Agregar filtro", 0, 0, 0, "px", 0, "px", 0, 0, 5, imgAdddynamicfilters2_Jsonclick, "'"+""+"'"+",false,"+"'"+"E\\'ADDDYNAMICFILTERS2\\'."+"'", StyleString, ClassString, "", "", "", "", " "+"data-gx-image"+" "+TempTags, "", "", 1, false, false, context.GetImageSrcSet( sImgUrl), "HLP_Bancos\\ConceptoEntregaRendirWW.htm");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "<td id=\""+cellDynamicfilters_removefilter2_cell_Internalname+"\"  class=''>") ;
            /* Active images/pictures */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 78,'',false,'',0)\"";
            ClassString = "Image";
            StyleString = "";
            sImgUrl = (string)(context.GetImagePath( "11a6ef14-1a5a-4077-91a2-f41ed9a3a662", "", context.GetTheme( )));
            GxWebStd.gx_bitmap( context, imgRemovedynamicfilters2_Internalname, sImgUrl, "", "", "", context.GetTheme( ), imgRemovedynamicfilters2_Visible, 1, "", "Quitar filtro", 0, 0, 0, "px", 0, "px", 0, 0, 5, imgRemovedynamicfilters2_Jsonclick, "'"+""+"'"+",false,"+"'"+"E\\'REMOVEDYNAMICFILTERS2\\'."+"'", StyleString, ClassString, "", "", "", "", " "+"data-gx-image"+" "+TempTags, "", "", 1, false, false, context.GetImageSrcSet( sImgUrl), "HLP_Bancos\\ConceptoEntregaRendirWW.htm");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "</tr>") ;
            /* End of table */
            context.WriteHtmlText( "</table>") ;
            wb_table3_64_242e( true) ;
         }
         else
         {
            wb_table3_64_242e( false) ;
         }
      }

      protected void wb_table2_39_242( bool wbgen )
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
            GxWebStd.gx_combobox_ctrl1( context, cmbavDynamicfiltersoperator1, cmbavDynamicfiltersoperator1_Internalname, StringUtil.Trim( StringUtil.Str( (decimal)(AV16DynamicFiltersOperator1), 4, 0)), 1, cmbavDynamicfiltersoperator1_Jsonclick, 0, "'"+""+"'"+",false,"+"'"+""+"'", "int", "", cmbavDynamicfiltersoperator1.Visible, cmbavDynamicfiltersoperator1.Enabled, 0, 0, 0, "em", 0, "", "", "Attribute", "", "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,43);\"", "", true, 1, "HLP_Bancos\\ConceptoEntregaRendirWW.htm");
            cmbavDynamicfiltersoperator1.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV16DynamicFiltersOperator1), 4, 0));
            AssignProp("", false, cmbavDynamicfiltersoperator1_Internalname, "Values", (string)(cmbavDynamicfiltersoperator1.ToJavascriptSource()), true);
            GxWebStd.gx_div_end( context, "left", "top", "div");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "<td id=\""+cellFilter_conentdsc1_cell_Internalname+"\"  class=''>") ;
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "left", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavConentdsc1_Internalname, "Con Ent Dsc1", "gx-form-item AttributeLabel", 0, true, "width: 25%;");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 46,'',false,'" + sGXsfl_110_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavConentdsc1_Internalname, StringUtil.RTrim( AV17ConEntDsc1), StringUtil.RTrim( context.localUtil.Format( AV17ConEntDsc1, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,46);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavConentdsc1_Jsonclick, 0, "Attribute", "", "", "", "", edtavConentdsc1_Visible, edtavConentdsc1_Enabled, 0, "text", "", 80, "chr", 1, "row", 100, 0, 0, 0, 1, -1, -1, true, "", "left", true, "", "HLP_Bancos\\ConceptoEntregaRendirWW.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "<td id=\""+cellFilter_cuecod1_cell_Internalname+"\"  class=''>") ;
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "left", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavCuecod1_Internalname, "Cue Cod1", "gx-form-item AttributeLabel", 0, true, "width: 25%;");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 49,'',false,'" + sGXsfl_110_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavCuecod1_Internalname, StringUtil.RTrim( AV49CueCod1), StringUtil.RTrim( context.localUtil.Format( AV49CueCod1, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,49);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavCuecod1_Jsonclick, 0, "Attribute", "", "", "", "", edtavCuecod1_Visible, edtavCuecod1_Enabled, 0, "text", "", 15, "chr", 1, "row", 15, 0, 0, 0, 1, -1, -1, true, "", "left", true, "", "HLP_Bancos\\ConceptoEntregaRendirWW.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "<td id=\""+cellDynamicfilters_addfilter1_cell_Internalname+"\"  class=''>") ;
            /* Active images/pictures */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 51,'',false,'',0)\"";
            ClassString = "Image";
            StyleString = "";
            sImgUrl = (string)(context.GetImagePath( "27283ea5-332f-423b-b880-64b762622df3", "", context.GetTheme( )));
            GxWebStd.gx_bitmap( context, imgAdddynamicfilters1_Internalname, sImgUrl, "", "", "", context.GetTheme( ), imgAdddynamicfilters1_Visible, 1, "", "Agregar filtro", 0, 0, 0, "px", 0, "px", 0, 0, 5, imgAdddynamicfilters1_Jsonclick, "'"+""+"'"+",false,"+"'"+"E\\'ADDDYNAMICFILTERS1\\'."+"'", StyleString, ClassString, "", "", "", "", " "+"data-gx-image"+" "+TempTags, "", "", 1, false, false, context.GetImageSrcSet( sImgUrl), "HLP_Bancos\\ConceptoEntregaRendirWW.htm");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "<td id=\""+cellDynamicfilters_removefilter1_cell_Internalname+"\"  class=''>") ;
            /* Active images/pictures */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 53,'',false,'',0)\"";
            ClassString = "Image";
            StyleString = "";
            sImgUrl = (string)(context.GetImagePath( "11a6ef14-1a5a-4077-91a2-f41ed9a3a662", "", context.GetTheme( )));
            GxWebStd.gx_bitmap( context, imgRemovedynamicfilters1_Internalname, sImgUrl, "", "", "", context.GetTheme( ), imgRemovedynamicfilters1_Visible, 1, "", "Quitar filtro", 0, 0, 0, "px", 0, "px", 0, 0, 5, imgRemovedynamicfilters1_Jsonclick, "'"+""+"'"+",false,"+"'"+"E\\'REMOVEDYNAMICFILTERS1\\'."+"'", StyleString, ClassString, "", "", "", "", " "+"data-gx-image"+" "+TempTags, "", "", 1, false, false, context.GetImageSrcSet( sImgUrl), "HLP_Bancos\\ConceptoEntregaRendirWW.htm");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "</tr>") ;
            /* End of table */
            context.WriteHtmlText( "</table>") ;
            wb_table2_39_242e( true) ;
         }
         else
         {
            wb_table2_39_242e( false) ;
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
         PA242( ) ;
         WS242( ) ;
         WE242( ) ;
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
            context.AddJavascriptSource(StringUtil.RTrim( ((string)Form.Jscriptsrc.Item(idxLst))), "?202281810301991", true, true);
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
         context.AddJavascriptSource("bancos/conceptoentregarendirww.js", "?202281810301992", false, true);
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
         edtConEntCod_Internalname = "CONENTCOD_"+sGXsfl_110_idx;
         edtConEntDsc_Internalname = "CONENTDSC_"+sGXsfl_110_idx;
         edtCueCod_Internalname = "CUECOD_"+sGXsfl_110_idx;
         edtCueDsc_Internalname = "CUEDSC_"+sGXsfl_110_idx;
         cmbConEntSts_Internalname = "CONENTSTS_"+sGXsfl_110_idx;
      }

      protected void SubsflControlProps_fel_1102( )
      {
         cmbavGridactions_Internalname = "vGRIDACTIONS_"+sGXsfl_110_fel_idx;
         edtConEntCod_Internalname = "CONENTCOD_"+sGXsfl_110_fel_idx;
         edtConEntDsc_Internalname = "CONENTDSC_"+sGXsfl_110_fel_idx;
         edtCueCod_Internalname = "CUECOD_"+sGXsfl_110_fel_idx;
         edtCueDsc_Internalname = "CUEDSC_"+sGXsfl_110_fel_idx;
         cmbConEntSts_Internalname = "CONENTSTS_"+sGXsfl_110_fel_idx;
      }

      protected void sendrow_1102( )
      {
         SubsflControlProps_1102( ) ;
         WB240( ) ;
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
                  AV46GridActions = (short)(NumberUtil.Val( cmbavGridactions.getValidValue(StringUtil.Trim( StringUtil.Str( (decimal)(AV46GridActions), 4, 0))), "."));
                  AssignAttri("", false, cmbavGridactions_Internalname, StringUtil.LTrimStr( (decimal)(AV46GridActions), 4, 0));
               }
            }
            /* ComboBox */
            GridRow.AddColumnProperties("combobox", 2, isAjaxCallMode( ), new Object[] {(GXCombobox)cmbavGridactions,(string)cmbavGridactions_Internalname,StringUtil.Trim( StringUtil.Str( (decimal)(AV46GridActions), 4, 0)),(short)1,(string)cmbavGridactions_Jsonclick,(short)5,"'"+""+"'"+",false,"+"'"+"EVGRIDACTIONS.CLICK."+sGXsfl_110_idx+"'",(string)"int",(string)"",(short)-1,(short)1,(short)0,(short)0,(short)0,(string)"px",(short)0,(string)"px",(string)"",(string)"ConvertToDDO",(string)"WWActionGroupColumn",(string)"",TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+((cmbavGridactions.Enabled!=0)&&(cmbavGridactions.Visible!=0) ? " onblur=\""+""+";gx.evt.onblur(this,111);\"" : " "),(string)"",(bool)true,(short)1});
            cmbavGridactions.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV46GridActions), 4, 0));
            AssignProp("", false, cmbavGridactions_Internalname, "Values", (string)(cmbavGridactions.ToJavascriptSource()), !bGXsfl_110_Refreshing);
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"right"+"\""+" style=\""+""+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtConEntCod_Internalname,StringUtil.LTrim( StringUtil.NToC( (decimal)(A376ConEntCod), 6, 0, ".", "")),StringUtil.LTrim( context.localUtil.Format( (decimal)(A376ConEntCod), "ZZZZZ9")),(string)" inputmode=\"numeric\" pattern=\"[0-9]*\""+"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtConEntCod_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn hidden-xs",(string)"",(short)-1,(short)0,(short)0,(string)"text",(string)"1",(short)0,(string)"px",(short)17,(string)"px",(short)6,(short)0,(short)0,(short)110,(short)1,(short)-1,(short)0,(bool)true,(string)"",(string)"right",(bool)false,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"left"+"\""+" style=\""+""+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtConEntDsc_Internalname,StringUtil.RTrim( A749ConEntDsc),(string)"",(string)"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)edtConEntDsc_Link,(string)"",(string)"",(string)"",(string)edtConEntDsc_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn",(string)"",(short)-1,(short)0,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)100,(short)0,(short)0,(short)110,(short)1,(short)-1,(short)-1,(bool)true,(string)"",(string)"left",(bool)true,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"left"+"\""+" style=\""+""+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtCueCod_Internalname,StringUtil.RTrim( A91CueCod),(string)"",(string)"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtCueCod_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn hidden-xs",(string)"",(short)-1,(short)0,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)15,(short)0,(short)0,(short)110,(short)1,(short)-1,(short)-1,(bool)true,(string)"",(string)"left",(bool)true,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"left"+"\""+" style=\""+""+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtCueDsc_Internalname,StringUtil.RTrim( A860CueDsc),(string)"",(string)"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)edtCueDsc_Link,(string)"",(string)"",(string)"",(string)edtCueDsc_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn",(string)"",(short)-1,(short)0,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)100,(short)0,(short)0,(short)110,(short)1,(short)-1,(short)-1,(bool)true,(string)"",(string)"left",(bool)true,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"right"+"\""+" style=\""+""+"\">") ;
            }
            if ( ( cmbConEntSts.ItemCount == 0 ) && isAjaxCallMode( ) )
            {
               GXCCtl = "CONENTSTS_" + sGXsfl_110_idx;
               cmbConEntSts.Name = GXCCtl;
               cmbConEntSts.WebTags = "";
               cmbConEntSts.addItem("1", "ACTIVO", 0);
               cmbConEntSts.addItem("0", "INACTIVO", 0);
               if ( cmbConEntSts.ItemCount > 0 )
               {
                  A750ConEntSts = (short)(NumberUtil.Val( cmbConEntSts.getValidValue(StringUtil.Trim( StringUtil.Str( (decimal)(A750ConEntSts), 1, 0))), "."));
               }
            }
            /* ComboBox */
            GridRow.AddColumnProperties("combobox", 2, isAjaxCallMode( ), new Object[] {(GXCombobox)cmbConEntSts,(string)cmbConEntSts_Internalname,StringUtil.Trim( StringUtil.Str( (decimal)(A750ConEntSts), 1, 0)),(short)1,(string)cmbConEntSts_Jsonclick,(short)0,(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"int",(string)"",(short)-1,(short)0,(short)0,(short)0,(short)0,(string)"px",(short)0,(string)"px",(string)"",(string)"Attribute",(string)"WWColumn hidden-xs",(string)"",(string)"",(string)"",(bool)true,(short)1});
            cmbConEntSts.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(A750ConEntSts), 1, 0));
            AssignProp("", false, cmbConEntSts_Internalname, "Values", (string)(cmbConEntSts.ToJavascriptSource()), !bGXsfl_110_Refreshing);
            send_integrity_lvl_hashes242( ) ;
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
         cmbavDynamicfiltersselector1.addItem("CONENTDSC", "Concepto de Entrega", 0);
         cmbavDynamicfiltersselector1.addItem("CUECOD", "Cuenta Contable", 0);
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
         cmbavDynamicfiltersselector2.addItem("CONENTDSC", "Concepto de Entrega", 0);
         cmbavDynamicfiltersselector2.addItem("CUECOD", "Cuenta Contable", 0);
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
         cmbavDynamicfiltersselector3.addItem("CONENTDSC", "Concepto de Entrega", 0);
         cmbavDynamicfiltersselector3.addItem("CUECOD", "Cuenta Contable", 0);
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
            AV46GridActions = (short)(NumberUtil.Val( cmbavGridactions.getValidValue(StringUtil.Trim( StringUtil.Str( (decimal)(AV46GridActions), 4, 0))), "."));
            AssignAttri("", false, cmbavGridactions_Internalname, StringUtil.LTrimStr( (decimal)(AV46GridActions), 4, 0));
         }
         GXCCtl = "CONENTSTS_" + sGXsfl_110_idx;
         cmbConEntSts.Name = GXCCtl;
         cmbConEntSts.WebTags = "";
         cmbConEntSts.addItem("1", "ACTIVO", 0);
         cmbConEntSts.addItem("0", "INACTIVO", 0);
         if ( cmbConEntSts.ItemCount > 0 )
         {
            A750ConEntSts = (short)(NumberUtil.Val( cmbConEntSts.getValidValue(StringUtil.Trim( StringUtil.Str( (decimal)(A750ConEntSts), 1, 0))), "."));
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
         edtavConentdsc1_Internalname = "vCONENTDSC1";
         cellFilter_conentdsc1_cell_Internalname = "FILTER_CONENTDSC1_CELL";
         edtavCuecod1_Internalname = "vCUECOD1";
         cellFilter_cuecod1_cell_Internalname = "FILTER_CUECOD1_CELL";
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
         edtavConentdsc2_Internalname = "vCONENTDSC2";
         cellFilter_conentdsc2_cell_Internalname = "FILTER_CONENTDSC2_CELL";
         edtavCuecod2_Internalname = "vCUECOD2";
         cellFilter_cuecod2_cell_Internalname = "FILTER_CUECOD2_CELL";
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
         edtavConentdsc3_Internalname = "vCONENTDSC3";
         cellFilter_conentdsc3_cell_Internalname = "FILTER_CONENTDSC3_CELL";
         edtavCuecod3_Internalname = "vCUECOD3";
         cellFilter_cuecod3_cell_Internalname = "FILTER_CUECOD3_CELL";
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
         edtConEntCod_Internalname = "CONENTCOD";
         edtConEntDsc_Internalname = "CONENTDSC";
         edtCueCod_Internalname = "CUECOD";
         edtCueDsc_Internalname = "CUEDSC";
         cmbConEntSts_Internalname = "CONENTSTS";
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
         cmbConEntSts_Jsonclick = "";
         edtCueDsc_Jsonclick = "";
         edtCueCod_Jsonclick = "";
         edtConEntDsc_Jsonclick = "";
         edtConEntCod_Jsonclick = "";
         cmbavGridactions_Jsonclick = "";
         cmbavGridactions.Visible = -1;
         cmbavGridactions.Enabled = 1;
         imgRemovedynamicfilters1_Visible = 1;
         imgAdddynamicfilters1_Visible = 1;
         edtavCuecod1_Jsonclick = "";
         edtavCuecod1_Enabled = 1;
         edtavConentdsc1_Jsonclick = "";
         edtavConentdsc1_Enabled = 1;
         cmbavDynamicfiltersoperator1_Jsonclick = "";
         cmbavDynamicfiltersoperator1.Enabled = 1;
         imgRemovedynamicfilters2_Visible = 1;
         imgAdddynamicfilters2_Visible = 1;
         edtavCuecod2_Jsonclick = "";
         edtavCuecod2_Enabled = 1;
         edtavConentdsc2_Jsonclick = "";
         edtavConentdsc2_Enabled = 1;
         cmbavDynamicfiltersoperator2_Jsonclick = "";
         cmbavDynamicfiltersoperator2.Enabled = 1;
         edtavCuecod3_Jsonclick = "";
         edtavCuecod3_Enabled = 1;
         edtavConentdsc3_Jsonclick = "";
         edtavConentdsc3_Enabled = 1;
         cmbavDynamicfiltersoperator3_Jsonclick = "";
         cmbavDynamicfiltersoperator3.Enabled = 1;
         cmbavDynamicfiltersselector3_Jsonclick = "";
         cmbavDynamicfiltersselector3.Enabled = 1;
         cmbavDynamicfiltersselector2_Jsonclick = "";
         cmbavDynamicfiltersselector2.Enabled = 1;
         cmbavDynamicfiltersselector1_Jsonclick = "";
         cmbavDynamicfiltersselector1.Enabled = 1;
         cmbavDynamicfiltersoperator3.Visible = 1;
         edtavCuecod3_Visible = 1;
         edtavConentdsc3_Visible = 1;
         cmbavDynamicfiltersoperator2.Visible = 1;
         edtavCuecod2_Visible = 1;
         edtavConentdsc2_Visible = 1;
         cmbavDynamicfiltersoperator1.Visible = 1;
         edtavCuecod1_Visible = 1;
         edtavConentdsc1_Visible = 1;
         lblJsdynamicfilters_Caption = "JSDynamicFilters";
         subGrid_Allowcollapsing = 0;
         subGrid_Allowselection = 0;
         edtCueDsc_Link = "";
         edtConEntDsc_Link = "";
         subGrid_Sortable = 0;
         subGrid_Header = "";
         subGrid_Class = "GridWithPaginationBar WorkWith";
         subGrid_Backcolorstyle = 0;
         Grid_empowerer_Hastitlesettings = Convert.ToBoolean( -1);
         Innewwindow1_Target = "";
         Innewwindow1_Height = "50";
         Innewwindow1_Width = "50";
         Ddo_grid_Datalistproc = "Bancos.ConceptoEntregaRendirWWGetFilterData";
         Ddo_grid_Datalistfixedvalues = "||||1:ACTIVO,0:INACTIVO";
         Ddo_grid_Allowmultipleselection = "||||T";
         Ddo_grid_Datalisttype = "|Dynamic|Dynamic|Dynamic|FixedValues";
         Ddo_grid_Includedatalist = "|T|T|T|T";
         Ddo_grid_Filterisrange = "T||||";
         Ddo_grid_Filtertype = "Numeric|Character|Character|Character|";
         Ddo_grid_Includefilter = "T|T|T|T|";
         Ddo_grid_Includesortasc = "T";
         Ddo_grid_Columnssortvalues = "1|2|3|4|5";
         Ddo_grid_Columnids = "1:ConEntCod|2:ConEntDsc|3:CueCod|4:CueDsc|5:ConEntSts";
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
         Form.Caption = " Conceptos Entrega Rendir Cuenta";
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
         setEventMetadata("REFRESH","{handler:'Refresh',iparms:[{av:'GRID_nFirstRecordOnPage'},{av:'GRID_nEOF'},{av:'cmbavDynamicfiltersselector1'},{av:'AV15DynamicFiltersSelector1',fld:'vDYNAMICFILTERSSELECTOR1',pic:''},{av:'AV18DynamicFiltersEnabled2',fld:'vDYNAMICFILTERSENABLED2',pic:''},{av:'cmbavDynamicfiltersselector2'},{av:'AV19DynamicFiltersSelector2',fld:'vDYNAMICFILTERSSELECTOR2',pic:''},{av:'AV22DynamicFiltersEnabled3',fld:'vDYNAMICFILTERSENABLED3',pic:''},{av:'cmbavDynamicfiltersselector3'},{av:'AV23DynamicFiltersSelector3',fld:'vDYNAMICFILTERSSELECTOR3',pic:''},{av:'subGrid_Rows',ctrl:'GRID',prop:'Rows'},{av:'cmbavDynamicfiltersoperator1'},{av:'AV16DynamicFiltersOperator1',fld:'vDYNAMICFILTERSOPERATOR1',pic:'ZZZ9'},{av:'AV17ConEntDsc1',fld:'vCONENTDSC1',pic:''},{av:'AV49CueCod1',fld:'vCUECOD1',pic:''},{av:'cmbavDynamicfiltersoperator2'},{av:'AV20DynamicFiltersOperator2',fld:'vDYNAMICFILTERSOPERATOR2',pic:'ZZZ9'},{av:'AV21ConEntDsc2',fld:'vCONENTDSC2',pic:''},{av:'AV50CueCod2',fld:'vCUECOD2',pic:''},{av:'cmbavDynamicfiltersoperator3'},{av:'AV24DynamicFiltersOperator3',fld:'vDYNAMICFILTERSOPERATOR3',pic:'ZZZ9'},{av:'AV25ConEntDsc3',fld:'vCONENTDSC3',pic:''},{av:'AV51CueCod3',fld:'vCUECOD3',pic:''},{av:'AV56Pgmname',fld:'vPGMNAME',pic:'',hsh:true},{av:'AV31TFConEntCod',fld:'vTFCONENTCOD',pic:'ZZZZZ9'},{av:'AV32TFConEntCod_To',fld:'vTFCONENTCOD_TO',pic:'ZZZZZ9'},{av:'AV33TFConEntDsc',fld:'vTFCONENTDSC',pic:''},{av:'AV34TFConEntDsc_Sel',fld:'vTFCONENTDSC_SEL',pic:''},{av:'AV35TFCueCod',fld:'vTFCUECOD',pic:''},{av:'AV36TFCueCod_Sel',fld:'vTFCUECOD_SEL',pic:''},{av:'AV37TFCueDsc',fld:'vTFCUEDSC',pic:''},{av:'AV38TFCueDsc_Sel',fld:'vTFCUEDSC_SEL',pic:''},{av:'AV53TFConEntSts_Sels',fld:'vTFCONENTSTS_SELS',pic:''},{av:'AV13OrderedBy',fld:'vORDEREDBY',pic:'ZZZ9'},{av:'AV14OrderedDsc',fld:'vORDEREDDSC',pic:''},{av:'AV10GridState',fld:'vGRIDSTATE',pic:''},{av:'AV27DynamicFiltersIgnoreFirst',fld:'vDYNAMICFILTERSIGNOREFIRST',pic:''},{av:'AV26DynamicFiltersRemoving',fld:'vDYNAMICFILTERSREMOVING',pic:''}]");
         setEventMetadata("REFRESH",",oparms:[{av:'cmbavDynamicfiltersoperator1'},{av:'AV16DynamicFiltersOperator1',fld:'vDYNAMICFILTERSOPERATOR1',pic:'ZZZ9'},{av:'cmbavDynamicfiltersoperator2'},{av:'AV20DynamicFiltersOperator2',fld:'vDYNAMICFILTERSOPERATOR2',pic:'ZZZ9'},{av:'cmbavDynamicfiltersoperator3'},{av:'AV24DynamicFiltersOperator3',fld:'vDYNAMICFILTERSOPERATOR3',pic:'ZZZ9'},{av:'AV43GridCurrentPage',fld:'vGRIDCURRENTPAGE',pic:'ZZZZZZZZZ9'},{av:'AV44GridPageCount',fld:'vGRIDPAGECOUNT',pic:'ZZZZZZZZZ9'},{av:'AV45GridAppliedFilters',fld:'vGRIDAPPLIEDFILTERS',pic:''},{av:'AV10GridState',fld:'vGRIDSTATE',pic:''}]}");
         setEventMetadata("GRIDPAGINATIONBAR.CHANGEPAGE","{handler:'E11242',iparms:[{av:'GRID_nFirstRecordOnPage'},{av:'GRID_nEOF'},{av:'subGrid_Rows',ctrl:'GRID',prop:'Rows'},{av:'cmbavDynamicfiltersselector1'},{av:'AV15DynamicFiltersSelector1',fld:'vDYNAMICFILTERSSELECTOR1',pic:''},{av:'cmbavDynamicfiltersoperator1'},{av:'AV16DynamicFiltersOperator1',fld:'vDYNAMICFILTERSOPERATOR1',pic:'ZZZ9'},{av:'AV17ConEntDsc1',fld:'vCONENTDSC1',pic:''},{av:'AV49CueCod1',fld:'vCUECOD1',pic:''},{av:'cmbavDynamicfiltersselector2'},{av:'AV19DynamicFiltersSelector2',fld:'vDYNAMICFILTERSSELECTOR2',pic:''},{av:'cmbavDynamicfiltersoperator2'},{av:'AV20DynamicFiltersOperator2',fld:'vDYNAMICFILTERSOPERATOR2',pic:'ZZZ9'},{av:'AV21ConEntDsc2',fld:'vCONENTDSC2',pic:''},{av:'AV50CueCod2',fld:'vCUECOD2',pic:''},{av:'cmbavDynamicfiltersselector3'},{av:'AV23DynamicFiltersSelector3',fld:'vDYNAMICFILTERSSELECTOR3',pic:''},{av:'cmbavDynamicfiltersoperator3'},{av:'AV24DynamicFiltersOperator3',fld:'vDYNAMICFILTERSOPERATOR3',pic:'ZZZ9'},{av:'AV25ConEntDsc3',fld:'vCONENTDSC3',pic:''},{av:'AV51CueCod3',fld:'vCUECOD3',pic:''},{av:'AV18DynamicFiltersEnabled2',fld:'vDYNAMICFILTERSENABLED2',pic:''},{av:'AV22DynamicFiltersEnabled3',fld:'vDYNAMICFILTERSENABLED3',pic:''},{av:'AV56Pgmname',fld:'vPGMNAME',pic:'',hsh:true},{av:'AV31TFConEntCod',fld:'vTFCONENTCOD',pic:'ZZZZZ9'},{av:'AV32TFConEntCod_To',fld:'vTFCONENTCOD_TO',pic:'ZZZZZ9'},{av:'AV33TFConEntDsc',fld:'vTFCONENTDSC',pic:''},{av:'AV34TFConEntDsc_Sel',fld:'vTFCONENTDSC_SEL',pic:''},{av:'AV35TFCueCod',fld:'vTFCUECOD',pic:''},{av:'AV36TFCueCod_Sel',fld:'vTFCUECOD_SEL',pic:''},{av:'AV37TFCueDsc',fld:'vTFCUEDSC',pic:''},{av:'AV38TFCueDsc_Sel',fld:'vTFCUEDSC_SEL',pic:''},{av:'AV53TFConEntSts_Sels',fld:'vTFCONENTSTS_SELS',pic:''},{av:'AV13OrderedBy',fld:'vORDEREDBY',pic:'ZZZ9'},{av:'AV14OrderedDsc',fld:'vORDEREDDSC',pic:''},{av:'AV10GridState',fld:'vGRIDSTATE',pic:''},{av:'AV27DynamicFiltersIgnoreFirst',fld:'vDYNAMICFILTERSIGNOREFIRST',pic:''},{av:'AV26DynamicFiltersRemoving',fld:'vDYNAMICFILTERSREMOVING',pic:''},{av:'Gridpaginationbar_Selectedpage',ctrl:'GRIDPAGINATIONBAR',prop:'SelectedPage'}]");
         setEventMetadata("GRIDPAGINATIONBAR.CHANGEPAGE",",oparms:[]}");
         setEventMetadata("GRIDPAGINATIONBAR.CHANGEROWSPERPAGE","{handler:'E12242',iparms:[{av:'GRID_nFirstRecordOnPage'},{av:'GRID_nEOF'},{av:'subGrid_Rows',ctrl:'GRID',prop:'Rows'},{av:'cmbavDynamicfiltersselector1'},{av:'AV15DynamicFiltersSelector1',fld:'vDYNAMICFILTERSSELECTOR1',pic:''},{av:'cmbavDynamicfiltersoperator1'},{av:'AV16DynamicFiltersOperator1',fld:'vDYNAMICFILTERSOPERATOR1',pic:'ZZZ9'},{av:'AV17ConEntDsc1',fld:'vCONENTDSC1',pic:''},{av:'AV49CueCod1',fld:'vCUECOD1',pic:''},{av:'cmbavDynamicfiltersselector2'},{av:'AV19DynamicFiltersSelector2',fld:'vDYNAMICFILTERSSELECTOR2',pic:''},{av:'cmbavDynamicfiltersoperator2'},{av:'AV20DynamicFiltersOperator2',fld:'vDYNAMICFILTERSOPERATOR2',pic:'ZZZ9'},{av:'AV21ConEntDsc2',fld:'vCONENTDSC2',pic:''},{av:'AV50CueCod2',fld:'vCUECOD2',pic:''},{av:'cmbavDynamicfiltersselector3'},{av:'AV23DynamicFiltersSelector3',fld:'vDYNAMICFILTERSSELECTOR3',pic:''},{av:'cmbavDynamicfiltersoperator3'},{av:'AV24DynamicFiltersOperator3',fld:'vDYNAMICFILTERSOPERATOR3',pic:'ZZZ9'},{av:'AV25ConEntDsc3',fld:'vCONENTDSC3',pic:''},{av:'AV51CueCod3',fld:'vCUECOD3',pic:''},{av:'AV18DynamicFiltersEnabled2',fld:'vDYNAMICFILTERSENABLED2',pic:''},{av:'AV22DynamicFiltersEnabled3',fld:'vDYNAMICFILTERSENABLED3',pic:''},{av:'AV56Pgmname',fld:'vPGMNAME',pic:'',hsh:true},{av:'AV31TFConEntCod',fld:'vTFCONENTCOD',pic:'ZZZZZ9'},{av:'AV32TFConEntCod_To',fld:'vTFCONENTCOD_TO',pic:'ZZZZZ9'},{av:'AV33TFConEntDsc',fld:'vTFCONENTDSC',pic:''},{av:'AV34TFConEntDsc_Sel',fld:'vTFCONENTDSC_SEL',pic:''},{av:'AV35TFCueCod',fld:'vTFCUECOD',pic:''},{av:'AV36TFCueCod_Sel',fld:'vTFCUECOD_SEL',pic:''},{av:'AV37TFCueDsc',fld:'vTFCUEDSC',pic:''},{av:'AV38TFCueDsc_Sel',fld:'vTFCUEDSC_SEL',pic:''},{av:'AV53TFConEntSts_Sels',fld:'vTFCONENTSTS_SELS',pic:''},{av:'AV13OrderedBy',fld:'vORDEREDBY',pic:'ZZZ9'},{av:'AV14OrderedDsc',fld:'vORDEREDDSC',pic:''},{av:'AV10GridState',fld:'vGRIDSTATE',pic:''},{av:'AV27DynamicFiltersIgnoreFirst',fld:'vDYNAMICFILTERSIGNOREFIRST',pic:''},{av:'AV26DynamicFiltersRemoving',fld:'vDYNAMICFILTERSREMOVING',pic:''},{av:'Gridpaginationbar_Rowsperpageselectedvalue',ctrl:'GRIDPAGINATIONBAR',prop:'RowsPerPageSelectedValue'}]");
         setEventMetadata("GRIDPAGINATIONBAR.CHANGEROWSPERPAGE",",oparms:[{av:'subGrid_Rows',ctrl:'GRID',prop:'Rows'}]}");
         setEventMetadata("DDO_GRID.ONOPTIONCLICKED","{handler:'E14242',iparms:[{av:'GRID_nFirstRecordOnPage'},{av:'GRID_nEOF'},{av:'subGrid_Rows',ctrl:'GRID',prop:'Rows'},{av:'cmbavDynamicfiltersselector1'},{av:'AV15DynamicFiltersSelector1',fld:'vDYNAMICFILTERSSELECTOR1',pic:''},{av:'cmbavDynamicfiltersoperator1'},{av:'AV16DynamicFiltersOperator1',fld:'vDYNAMICFILTERSOPERATOR1',pic:'ZZZ9'},{av:'AV17ConEntDsc1',fld:'vCONENTDSC1',pic:''},{av:'AV49CueCod1',fld:'vCUECOD1',pic:''},{av:'cmbavDynamicfiltersselector2'},{av:'AV19DynamicFiltersSelector2',fld:'vDYNAMICFILTERSSELECTOR2',pic:''},{av:'cmbavDynamicfiltersoperator2'},{av:'AV20DynamicFiltersOperator2',fld:'vDYNAMICFILTERSOPERATOR2',pic:'ZZZ9'},{av:'AV21ConEntDsc2',fld:'vCONENTDSC2',pic:''},{av:'AV50CueCod2',fld:'vCUECOD2',pic:''},{av:'cmbavDynamicfiltersselector3'},{av:'AV23DynamicFiltersSelector3',fld:'vDYNAMICFILTERSSELECTOR3',pic:''},{av:'cmbavDynamicfiltersoperator3'},{av:'AV24DynamicFiltersOperator3',fld:'vDYNAMICFILTERSOPERATOR3',pic:'ZZZ9'},{av:'AV25ConEntDsc3',fld:'vCONENTDSC3',pic:''},{av:'AV51CueCod3',fld:'vCUECOD3',pic:''},{av:'AV18DynamicFiltersEnabled2',fld:'vDYNAMICFILTERSENABLED2',pic:''},{av:'AV22DynamicFiltersEnabled3',fld:'vDYNAMICFILTERSENABLED3',pic:''},{av:'AV56Pgmname',fld:'vPGMNAME',pic:'',hsh:true},{av:'AV31TFConEntCod',fld:'vTFCONENTCOD',pic:'ZZZZZ9'},{av:'AV32TFConEntCod_To',fld:'vTFCONENTCOD_TO',pic:'ZZZZZ9'},{av:'AV33TFConEntDsc',fld:'vTFCONENTDSC',pic:''},{av:'AV34TFConEntDsc_Sel',fld:'vTFCONENTDSC_SEL',pic:''},{av:'AV35TFCueCod',fld:'vTFCUECOD',pic:''},{av:'AV36TFCueCod_Sel',fld:'vTFCUECOD_SEL',pic:''},{av:'AV37TFCueDsc',fld:'vTFCUEDSC',pic:''},{av:'AV38TFCueDsc_Sel',fld:'vTFCUEDSC_SEL',pic:''},{av:'AV53TFConEntSts_Sels',fld:'vTFCONENTSTS_SELS',pic:''},{av:'AV13OrderedBy',fld:'vORDEREDBY',pic:'ZZZ9'},{av:'AV14OrderedDsc',fld:'vORDEREDDSC',pic:''},{av:'AV10GridState',fld:'vGRIDSTATE',pic:''},{av:'AV27DynamicFiltersIgnoreFirst',fld:'vDYNAMICFILTERSIGNOREFIRST',pic:''},{av:'AV26DynamicFiltersRemoving',fld:'vDYNAMICFILTERSREMOVING',pic:''},{av:'Ddo_grid_Activeeventkey',ctrl:'DDO_GRID',prop:'ActiveEventKey'},{av:'Ddo_grid_Selectedvalue_get',ctrl:'DDO_GRID',prop:'SelectedValue_get'},{av:'Ddo_grid_Selectedcolumn',ctrl:'DDO_GRID',prop:'SelectedColumn'},{av:'Ddo_grid_Filteredtext_get',ctrl:'DDO_GRID',prop:'FilteredText_get'},{av:'Ddo_grid_Filteredtextto_get',ctrl:'DDO_GRID',prop:'FilteredTextTo_get'}]");
         setEventMetadata("DDO_GRID.ONOPTIONCLICKED",",oparms:[{av:'AV13OrderedBy',fld:'vORDEREDBY',pic:'ZZZ9'},{av:'AV14OrderedDsc',fld:'vORDEREDDSC',pic:''},{av:'AV31TFConEntCod',fld:'vTFCONENTCOD',pic:'ZZZZZ9'},{av:'AV32TFConEntCod_To',fld:'vTFCONENTCOD_TO',pic:'ZZZZZ9'},{av:'AV33TFConEntDsc',fld:'vTFCONENTDSC',pic:''},{av:'AV34TFConEntDsc_Sel',fld:'vTFCONENTDSC_SEL',pic:''},{av:'AV35TFCueCod',fld:'vTFCUECOD',pic:''},{av:'AV36TFCueCod_Sel',fld:'vTFCUECOD_SEL',pic:''},{av:'AV37TFCueDsc',fld:'vTFCUEDSC',pic:''},{av:'AV38TFCueDsc_Sel',fld:'vTFCUEDSC_SEL',pic:''},{av:'AV52TFConEntSts_SelsJson',fld:'vTFCONENTSTS_SELSJSON',pic:''},{av:'AV53TFConEntSts_Sels',fld:'vTFCONENTSTS_SELS',pic:''},{av:'Ddo_grid_Sortedstatus',ctrl:'DDO_GRID',prop:'SortedStatus'}]}");
         setEventMetadata("GRID.LOAD","{handler:'E26242',iparms:[{av:'A376ConEntCod',fld:'CONENTCOD',pic:'ZZZZZ9',hsh:true},{av:'A91CueCod',fld:'CUECOD',pic:''}]");
         setEventMetadata("GRID.LOAD",",oparms:[{av:'cmbavGridactions'},{av:'AV46GridActions',fld:'vGRIDACTIONS',pic:'ZZZ9'},{av:'edtConEntDsc_Link',ctrl:'CONENTDSC',prop:'Link'},{av:'edtCueDsc_Link',ctrl:'CUEDSC',prop:'Link'}]}");
         setEventMetadata("'ADDDYNAMICFILTERS1'","{handler:'E19242',iparms:[{av:'GRID_nFirstRecordOnPage'},{av:'GRID_nEOF'},{av:'subGrid_Rows',ctrl:'GRID',prop:'Rows'},{av:'cmbavDynamicfiltersselector1'},{av:'AV15DynamicFiltersSelector1',fld:'vDYNAMICFILTERSSELECTOR1',pic:''},{av:'cmbavDynamicfiltersoperator1'},{av:'AV16DynamicFiltersOperator1',fld:'vDYNAMICFILTERSOPERATOR1',pic:'ZZZ9'},{av:'AV17ConEntDsc1',fld:'vCONENTDSC1',pic:''},{av:'AV49CueCod1',fld:'vCUECOD1',pic:''},{av:'cmbavDynamicfiltersselector2'},{av:'AV19DynamicFiltersSelector2',fld:'vDYNAMICFILTERSSELECTOR2',pic:''},{av:'cmbavDynamicfiltersoperator2'},{av:'AV20DynamicFiltersOperator2',fld:'vDYNAMICFILTERSOPERATOR2',pic:'ZZZ9'},{av:'AV21ConEntDsc2',fld:'vCONENTDSC2',pic:''},{av:'AV50CueCod2',fld:'vCUECOD2',pic:''},{av:'cmbavDynamicfiltersselector3'},{av:'AV23DynamicFiltersSelector3',fld:'vDYNAMICFILTERSSELECTOR3',pic:''},{av:'cmbavDynamicfiltersoperator3'},{av:'AV24DynamicFiltersOperator3',fld:'vDYNAMICFILTERSOPERATOR3',pic:'ZZZ9'},{av:'AV25ConEntDsc3',fld:'vCONENTDSC3',pic:''},{av:'AV51CueCod3',fld:'vCUECOD3',pic:''},{av:'AV18DynamicFiltersEnabled2',fld:'vDYNAMICFILTERSENABLED2',pic:''},{av:'AV22DynamicFiltersEnabled3',fld:'vDYNAMICFILTERSENABLED3',pic:''},{av:'AV56Pgmname',fld:'vPGMNAME',pic:'',hsh:true},{av:'AV31TFConEntCod',fld:'vTFCONENTCOD',pic:'ZZZZZ9'},{av:'AV32TFConEntCod_To',fld:'vTFCONENTCOD_TO',pic:'ZZZZZ9'},{av:'AV33TFConEntDsc',fld:'vTFCONENTDSC',pic:''},{av:'AV34TFConEntDsc_Sel',fld:'vTFCONENTDSC_SEL',pic:''},{av:'AV35TFCueCod',fld:'vTFCUECOD',pic:''},{av:'AV36TFCueCod_Sel',fld:'vTFCUECOD_SEL',pic:''},{av:'AV37TFCueDsc',fld:'vTFCUEDSC',pic:''},{av:'AV38TFCueDsc_Sel',fld:'vTFCUEDSC_SEL',pic:''},{av:'AV53TFConEntSts_Sels',fld:'vTFCONENTSTS_SELS',pic:''},{av:'AV13OrderedBy',fld:'vORDEREDBY',pic:'ZZZ9'},{av:'AV14OrderedDsc',fld:'vORDEREDDSC',pic:''},{av:'AV10GridState',fld:'vGRIDSTATE',pic:''},{av:'AV27DynamicFiltersIgnoreFirst',fld:'vDYNAMICFILTERSIGNOREFIRST',pic:''},{av:'AV26DynamicFiltersRemoving',fld:'vDYNAMICFILTERSREMOVING',pic:''}]");
         setEventMetadata("'ADDDYNAMICFILTERS1'",",oparms:[{av:'AV18DynamicFiltersEnabled2',fld:'vDYNAMICFILTERSENABLED2',pic:''},{av:'imgAdddynamicfilters1_Visible',ctrl:'ADDDYNAMICFILTERS1',prop:'Visible'},{av:'imgRemovedynamicfilters1_Visible',ctrl:'REMOVEDYNAMICFILTERS1',prop:'Visible'},{av:'cmbavDynamicfiltersoperator1'},{av:'AV16DynamicFiltersOperator1',fld:'vDYNAMICFILTERSOPERATOR1',pic:'ZZZ9'},{av:'cmbavDynamicfiltersoperator2'},{av:'AV20DynamicFiltersOperator2',fld:'vDYNAMICFILTERSOPERATOR2',pic:'ZZZ9'},{av:'cmbavDynamicfiltersoperator3'},{av:'AV24DynamicFiltersOperator3',fld:'vDYNAMICFILTERSOPERATOR3',pic:'ZZZ9'},{av:'AV43GridCurrentPage',fld:'vGRIDCURRENTPAGE',pic:'ZZZZZZZZZ9'},{av:'AV44GridPageCount',fld:'vGRIDPAGECOUNT',pic:'ZZZZZZZZZ9'},{av:'AV45GridAppliedFilters',fld:'vGRIDAPPLIEDFILTERS',pic:''},{av:'AV10GridState',fld:'vGRIDSTATE',pic:''}]}");
         setEventMetadata("'REMOVEDYNAMICFILTERS1'","{handler:'E15242',iparms:[{av:'GRID_nFirstRecordOnPage'},{av:'GRID_nEOF'},{av:'subGrid_Rows',ctrl:'GRID',prop:'Rows'},{av:'cmbavDynamicfiltersselector1'},{av:'AV15DynamicFiltersSelector1',fld:'vDYNAMICFILTERSSELECTOR1',pic:''},{av:'cmbavDynamicfiltersoperator1'},{av:'AV16DynamicFiltersOperator1',fld:'vDYNAMICFILTERSOPERATOR1',pic:'ZZZ9'},{av:'AV17ConEntDsc1',fld:'vCONENTDSC1',pic:''},{av:'AV49CueCod1',fld:'vCUECOD1',pic:''},{av:'cmbavDynamicfiltersselector2'},{av:'AV19DynamicFiltersSelector2',fld:'vDYNAMICFILTERSSELECTOR2',pic:''},{av:'cmbavDynamicfiltersoperator2'},{av:'AV20DynamicFiltersOperator2',fld:'vDYNAMICFILTERSOPERATOR2',pic:'ZZZ9'},{av:'AV21ConEntDsc2',fld:'vCONENTDSC2',pic:''},{av:'AV50CueCod2',fld:'vCUECOD2',pic:''},{av:'cmbavDynamicfiltersselector3'},{av:'AV23DynamicFiltersSelector3',fld:'vDYNAMICFILTERSSELECTOR3',pic:''},{av:'cmbavDynamicfiltersoperator3'},{av:'AV24DynamicFiltersOperator3',fld:'vDYNAMICFILTERSOPERATOR3',pic:'ZZZ9'},{av:'AV25ConEntDsc3',fld:'vCONENTDSC3',pic:''},{av:'AV51CueCod3',fld:'vCUECOD3',pic:''},{av:'AV18DynamicFiltersEnabled2',fld:'vDYNAMICFILTERSENABLED2',pic:''},{av:'AV22DynamicFiltersEnabled3',fld:'vDYNAMICFILTERSENABLED3',pic:''},{av:'AV56Pgmname',fld:'vPGMNAME',pic:'',hsh:true},{av:'AV31TFConEntCod',fld:'vTFCONENTCOD',pic:'ZZZZZ9'},{av:'AV32TFConEntCod_To',fld:'vTFCONENTCOD_TO',pic:'ZZZZZ9'},{av:'AV33TFConEntDsc',fld:'vTFCONENTDSC',pic:''},{av:'AV34TFConEntDsc_Sel',fld:'vTFCONENTDSC_SEL',pic:''},{av:'AV35TFCueCod',fld:'vTFCUECOD',pic:''},{av:'AV36TFCueCod_Sel',fld:'vTFCUECOD_SEL',pic:''},{av:'AV37TFCueDsc',fld:'vTFCUEDSC',pic:''},{av:'AV38TFCueDsc_Sel',fld:'vTFCUEDSC_SEL',pic:''},{av:'AV53TFConEntSts_Sels',fld:'vTFCONENTSTS_SELS',pic:''},{av:'AV13OrderedBy',fld:'vORDEREDBY',pic:'ZZZ9'},{av:'AV14OrderedDsc',fld:'vORDEREDDSC',pic:''},{av:'AV10GridState',fld:'vGRIDSTATE',pic:''},{av:'AV27DynamicFiltersIgnoreFirst',fld:'vDYNAMICFILTERSIGNOREFIRST',pic:''},{av:'AV26DynamicFiltersRemoving',fld:'vDYNAMICFILTERSREMOVING',pic:''}]");
         setEventMetadata("'REMOVEDYNAMICFILTERS1'",",oparms:[{av:'AV26DynamicFiltersRemoving',fld:'vDYNAMICFILTERSREMOVING',pic:''},{av:'AV27DynamicFiltersIgnoreFirst',fld:'vDYNAMICFILTERSIGNOREFIRST',pic:''},{av:'AV10GridState',fld:'vGRIDSTATE',pic:''},{av:'AV18DynamicFiltersEnabled2',fld:'vDYNAMICFILTERSENABLED2',pic:''},{av:'cmbavDynamicfiltersselector2'},{av:'AV19DynamicFiltersSelector2',fld:'vDYNAMICFILTERSSELECTOR2',pic:''},{av:'cmbavDynamicfiltersoperator2'},{av:'AV20DynamicFiltersOperator2',fld:'vDYNAMICFILTERSOPERATOR2',pic:'ZZZ9'},{av:'AV21ConEntDsc2',fld:'vCONENTDSC2',pic:''},{av:'AV22DynamicFiltersEnabled3',fld:'vDYNAMICFILTERSENABLED3',pic:''},{av:'cmbavDynamicfiltersselector3'},{av:'AV23DynamicFiltersSelector3',fld:'vDYNAMICFILTERSSELECTOR3',pic:''},{av:'cmbavDynamicfiltersoperator3'},{av:'AV24DynamicFiltersOperator3',fld:'vDYNAMICFILTERSOPERATOR3',pic:'ZZZ9'},{av:'AV25ConEntDsc3',fld:'vCONENTDSC3',pic:''},{av:'imgAdddynamicfilters1_Visible',ctrl:'ADDDYNAMICFILTERS1',prop:'Visible'},{av:'imgRemovedynamicfilters1_Visible',ctrl:'REMOVEDYNAMICFILTERS1',prop:'Visible'},{av:'imgAdddynamicfilters2_Visible',ctrl:'ADDDYNAMICFILTERS2',prop:'Visible'},{av:'imgRemovedynamicfilters2_Visible',ctrl:'REMOVEDYNAMICFILTERS2',prop:'Visible'},{av:'cmbavDynamicfiltersselector1'},{av:'AV15DynamicFiltersSelector1',fld:'vDYNAMICFILTERSSELECTOR1',pic:''},{av:'cmbavDynamicfiltersoperator1'},{av:'AV16DynamicFiltersOperator1',fld:'vDYNAMICFILTERSOPERATOR1',pic:'ZZZ9'},{av:'AV17ConEntDsc1',fld:'vCONENTDSC1',pic:''},{av:'AV49CueCod1',fld:'vCUECOD1',pic:''},{av:'lblJsdynamicfilters_Caption',ctrl:'JSDYNAMICFILTERS',prop:'Caption'},{av:'AV50CueCod2',fld:'vCUECOD2',pic:''},{av:'AV51CueCod3',fld:'vCUECOD3',pic:''},{av:'edtavConentdsc2_Visible',ctrl:'vCONENTDSC2',prop:'Visible'},{av:'edtavCuecod2_Visible',ctrl:'vCUECOD2',prop:'Visible'},{av:'edtavConentdsc3_Visible',ctrl:'vCONENTDSC3',prop:'Visible'},{av:'edtavCuecod3_Visible',ctrl:'vCUECOD3',prop:'Visible'},{av:'edtavConentdsc1_Visible',ctrl:'vCONENTDSC1',prop:'Visible'},{av:'edtavCuecod1_Visible',ctrl:'vCUECOD1',prop:'Visible'},{av:'AV43GridCurrentPage',fld:'vGRIDCURRENTPAGE',pic:'ZZZZZZZZZ9'},{av:'AV44GridPageCount',fld:'vGRIDPAGECOUNT',pic:'ZZZZZZZZZ9'},{av:'AV45GridAppliedFilters',fld:'vGRIDAPPLIEDFILTERS',pic:''}]}");
         setEventMetadata("VDYNAMICFILTERSSELECTOR1.CLICK","{handler:'E20242',iparms:[{av:'cmbavDynamicfiltersselector1'},{av:'AV15DynamicFiltersSelector1',fld:'vDYNAMICFILTERSSELECTOR1',pic:''}]");
         setEventMetadata("VDYNAMICFILTERSSELECTOR1.CLICK",",oparms:[{av:'cmbavDynamicfiltersoperator1'},{av:'AV16DynamicFiltersOperator1',fld:'vDYNAMICFILTERSOPERATOR1',pic:'ZZZ9'},{av:'edtavConentdsc1_Visible',ctrl:'vCONENTDSC1',prop:'Visible'},{av:'edtavCuecod1_Visible',ctrl:'vCUECOD1',prop:'Visible'}]}");
         setEventMetadata("'ADDDYNAMICFILTERS2'","{handler:'E21242',iparms:[{av:'GRID_nFirstRecordOnPage'},{av:'GRID_nEOF'},{av:'subGrid_Rows',ctrl:'GRID',prop:'Rows'},{av:'cmbavDynamicfiltersselector1'},{av:'AV15DynamicFiltersSelector1',fld:'vDYNAMICFILTERSSELECTOR1',pic:''},{av:'cmbavDynamicfiltersoperator1'},{av:'AV16DynamicFiltersOperator1',fld:'vDYNAMICFILTERSOPERATOR1',pic:'ZZZ9'},{av:'AV17ConEntDsc1',fld:'vCONENTDSC1',pic:''},{av:'AV49CueCod1',fld:'vCUECOD1',pic:''},{av:'cmbavDynamicfiltersselector2'},{av:'AV19DynamicFiltersSelector2',fld:'vDYNAMICFILTERSSELECTOR2',pic:''},{av:'cmbavDynamicfiltersoperator2'},{av:'AV20DynamicFiltersOperator2',fld:'vDYNAMICFILTERSOPERATOR2',pic:'ZZZ9'},{av:'AV21ConEntDsc2',fld:'vCONENTDSC2',pic:''},{av:'AV50CueCod2',fld:'vCUECOD2',pic:''},{av:'cmbavDynamicfiltersselector3'},{av:'AV23DynamicFiltersSelector3',fld:'vDYNAMICFILTERSSELECTOR3',pic:''},{av:'cmbavDynamicfiltersoperator3'},{av:'AV24DynamicFiltersOperator3',fld:'vDYNAMICFILTERSOPERATOR3',pic:'ZZZ9'},{av:'AV25ConEntDsc3',fld:'vCONENTDSC3',pic:''},{av:'AV51CueCod3',fld:'vCUECOD3',pic:''},{av:'AV18DynamicFiltersEnabled2',fld:'vDYNAMICFILTERSENABLED2',pic:''},{av:'AV22DynamicFiltersEnabled3',fld:'vDYNAMICFILTERSENABLED3',pic:''},{av:'AV56Pgmname',fld:'vPGMNAME',pic:'',hsh:true},{av:'AV31TFConEntCod',fld:'vTFCONENTCOD',pic:'ZZZZZ9'},{av:'AV32TFConEntCod_To',fld:'vTFCONENTCOD_TO',pic:'ZZZZZ9'},{av:'AV33TFConEntDsc',fld:'vTFCONENTDSC',pic:''},{av:'AV34TFConEntDsc_Sel',fld:'vTFCONENTDSC_SEL',pic:''},{av:'AV35TFCueCod',fld:'vTFCUECOD',pic:''},{av:'AV36TFCueCod_Sel',fld:'vTFCUECOD_SEL',pic:''},{av:'AV37TFCueDsc',fld:'vTFCUEDSC',pic:''},{av:'AV38TFCueDsc_Sel',fld:'vTFCUEDSC_SEL',pic:''},{av:'AV53TFConEntSts_Sels',fld:'vTFCONENTSTS_SELS',pic:''},{av:'AV13OrderedBy',fld:'vORDEREDBY',pic:'ZZZ9'},{av:'AV14OrderedDsc',fld:'vORDEREDDSC',pic:''},{av:'AV10GridState',fld:'vGRIDSTATE',pic:''},{av:'AV27DynamicFiltersIgnoreFirst',fld:'vDYNAMICFILTERSIGNOREFIRST',pic:''},{av:'AV26DynamicFiltersRemoving',fld:'vDYNAMICFILTERSREMOVING',pic:''}]");
         setEventMetadata("'ADDDYNAMICFILTERS2'",",oparms:[{av:'AV22DynamicFiltersEnabled3',fld:'vDYNAMICFILTERSENABLED3',pic:''},{av:'imgAdddynamicfilters2_Visible',ctrl:'ADDDYNAMICFILTERS2',prop:'Visible'},{av:'imgRemovedynamicfilters2_Visible',ctrl:'REMOVEDYNAMICFILTERS2',prop:'Visible'},{av:'cmbavDynamicfiltersoperator1'},{av:'AV16DynamicFiltersOperator1',fld:'vDYNAMICFILTERSOPERATOR1',pic:'ZZZ9'},{av:'cmbavDynamicfiltersoperator2'},{av:'AV20DynamicFiltersOperator2',fld:'vDYNAMICFILTERSOPERATOR2',pic:'ZZZ9'},{av:'cmbavDynamicfiltersoperator3'},{av:'AV24DynamicFiltersOperator3',fld:'vDYNAMICFILTERSOPERATOR3',pic:'ZZZ9'},{av:'AV43GridCurrentPage',fld:'vGRIDCURRENTPAGE',pic:'ZZZZZZZZZ9'},{av:'AV44GridPageCount',fld:'vGRIDPAGECOUNT',pic:'ZZZZZZZZZ9'},{av:'AV45GridAppliedFilters',fld:'vGRIDAPPLIEDFILTERS',pic:''},{av:'AV10GridState',fld:'vGRIDSTATE',pic:''}]}");
         setEventMetadata("'REMOVEDYNAMICFILTERS2'","{handler:'E16242',iparms:[{av:'GRID_nFirstRecordOnPage'},{av:'GRID_nEOF'},{av:'subGrid_Rows',ctrl:'GRID',prop:'Rows'},{av:'cmbavDynamicfiltersselector1'},{av:'AV15DynamicFiltersSelector1',fld:'vDYNAMICFILTERSSELECTOR1',pic:''},{av:'cmbavDynamicfiltersoperator1'},{av:'AV16DynamicFiltersOperator1',fld:'vDYNAMICFILTERSOPERATOR1',pic:'ZZZ9'},{av:'AV17ConEntDsc1',fld:'vCONENTDSC1',pic:''},{av:'AV49CueCod1',fld:'vCUECOD1',pic:''},{av:'cmbavDynamicfiltersselector2'},{av:'AV19DynamicFiltersSelector2',fld:'vDYNAMICFILTERSSELECTOR2',pic:''},{av:'cmbavDynamicfiltersoperator2'},{av:'AV20DynamicFiltersOperator2',fld:'vDYNAMICFILTERSOPERATOR2',pic:'ZZZ9'},{av:'AV21ConEntDsc2',fld:'vCONENTDSC2',pic:''},{av:'AV50CueCod2',fld:'vCUECOD2',pic:''},{av:'cmbavDynamicfiltersselector3'},{av:'AV23DynamicFiltersSelector3',fld:'vDYNAMICFILTERSSELECTOR3',pic:''},{av:'cmbavDynamicfiltersoperator3'},{av:'AV24DynamicFiltersOperator3',fld:'vDYNAMICFILTERSOPERATOR3',pic:'ZZZ9'},{av:'AV25ConEntDsc3',fld:'vCONENTDSC3',pic:''},{av:'AV51CueCod3',fld:'vCUECOD3',pic:''},{av:'AV18DynamicFiltersEnabled2',fld:'vDYNAMICFILTERSENABLED2',pic:''},{av:'AV22DynamicFiltersEnabled3',fld:'vDYNAMICFILTERSENABLED3',pic:''},{av:'AV56Pgmname',fld:'vPGMNAME',pic:'',hsh:true},{av:'AV31TFConEntCod',fld:'vTFCONENTCOD',pic:'ZZZZZ9'},{av:'AV32TFConEntCod_To',fld:'vTFCONENTCOD_TO',pic:'ZZZZZ9'},{av:'AV33TFConEntDsc',fld:'vTFCONENTDSC',pic:''},{av:'AV34TFConEntDsc_Sel',fld:'vTFCONENTDSC_SEL',pic:''},{av:'AV35TFCueCod',fld:'vTFCUECOD',pic:''},{av:'AV36TFCueCod_Sel',fld:'vTFCUECOD_SEL',pic:''},{av:'AV37TFCueDsc',fld:'vTFCUEDSC',pic:''},{av:'AV38TFCueDsc_Sel',fld:'vTFCUEDSC_SEL',pic:''},{av:'AV53TFConEntSts_Sels',fld:'vTFCONENTSTS_SELS',pic:''},{av:'AV13OrderedBy',fld:'vORDEREDBY',pic:'ZZZ9'},{av:'AV14OrderedDsc',fld:'vORDEREDDSC',pic:''},{av:'AV10GridState',fld:'vGRIDSTATE',pic:''},{av:'AV27DynamicFiltersIgnoreFirst',fld:'vDYNAMICFILTERSIGNOREFIRST',pic:''},{av:'AV26DynamicFiltersRemoving',fld:'vDYNAMICFILTERSREMOVING',pic:''}]");
         setEventMetadata("'REMOVEDYNAMICFILTERS2'",",oparms:[{av:'AV26DynamicFiltersRemoving',fld:'vDYNAMICFILTERSREMOVING',pic:''},{av:'AV18DynamicFiltersEnabled2',fld:'vDYNAMICFILTERSENABLED2',pic:''},{av:'AV10GridState',fld:'vGRIDSTATE',pic:''},{av:'cmbavDynamicfiltersselector2'},{av:'AV19DynamicFiltersSelector2',fld:'vDYNAMICFILTERSSELECTOR2',pic:''},{av:'cmbavDynamicfiltersoperator2'},{av:'AV20DynamicFiltersOperator2',fld:'vDYNAMICFILTERSOPERATOR2',pic:'ZZZ9'},{av:'AV21ConEntDsc2',fld:'vCONENTDSC2',pic:''},{av:'AV22DynamicFiltersEnabled3',fld:'vDYNAMICFILTERSENABLED3',pic:''},{av:'cmbavDynamicfiltersselector3'},{av:'AV23DynamicFiltersSelector3',fld:'vDYNAMICFILTERSSELECTOR3',pic:''},{av:'cmbavDynamicfiltersoperator3'},{av:'AV24DynamicFiltersOperator3',fld:'vDYNAMICFILTERSOPERATOR3',pic:'ZZZ9'},{av:'AV25ConEntDsc3',fld:'vCONENTDSC3',pic:''},{av:'imgAdddynamicfilters1_Visible',ctrl:'ADDDYNAMICFILTERS1',prop:'Visible'},{av:'imgRemovedynamicfilters1_Visible',ctrl:'REMOVEDYNAMICFILTERS1',prop:'Visible'},{av:'imgAdddynamicfilters2_Visible',ctrl:'ADDDYNAMICFILTERS2',prop:'Visible'},{av:'imgRemovedynamicfilters2_Visible',ctrl:'REMOVEDYNAMICFILTERS2',prop:'Visible'},{av:'cmbavDynamicfiltersselector1'},{av:'AV15DynamicFiltersSelector1',fld:'vDYNAMICFILTERSSELECTOR1',pic:''},{av:'cmbavDynamicfiltersoperator1'},{av:'AV16DynamicFiltersOperator1',fld:'vDYNAMICFILTERSOPERATOR1',pic:'ZZZ9'},{av:'AV17ConEntDsc1',fld:'vCONENTDSC1',pic:''},{av:'AV49CueCod1',fld:'vCUECOD1',pic:''},{av:'lblJsdynamicfilters_Caption',ctrl:'JSDYNAMICFILTERS',prop:'Caption'},{av:'AV50CueCod2',fld:'vCUECOD2',pic:''},{av:'AV51CueCod3',fld:'vCUECOD3',pic:''},{av:'edtavConentdsc2_Visible',ctrl:'vCONENTDSC2',prop:'Visible'},{av:'edtavCuecod2_Visible',ctrl:'vCUECOD2',prop:'Visible'},{av:'edtavConentdsc3_Visible',ctrl:'vCONENTDSC3',prop:'Visible'},{av:'edtavCuecod3_Visible',ctrl:'vCUECOD3',prop:'Visible'},{av:'edtavConentdsc1_Visible',ctrl:'vCONENTDSC1',prop:'Visible'},{av:'edtavCuecod1_Visible',ctrl:'vCUECOD1',prop:'Visible'},{av:'AV43GridCurrentPage',fld:'vGRIDCURRENTPAGE',pic:'ZZZZZZZZZ9'},{av:'AV44GridPageCount',fld:'vGRIDPAGECOUNT',pic:'ZZZZZZZZZ9'},{av:'AV45GridAppliedFilters',fld:'vGRIDAPPLIEDFILTERS',pic:''}]}");
         setEventMetadata("VDYNAMICFILTERSSELECTOR2.CLICK","{handler:'E22242',iparms:[{av:'cmbavDynamicfiltersselector2'},{av:'AV19DynamicFiltersSelector2',fld:'vDYNAMICFILTERSSELECTOR2',pic:''}]");
         setEventMetadata("VDYNAMICFILTERSSELECTOR2.CLICK",",oparms:[{av:'cmbavDynamicfiltersoperator2'},{av:'AV20DynamicFiltersOperator2',fld:'vDYNAMICFILTERSOPERATOR2',pic:'ZZZ9'},{av:'edtavConentdsc2_Visible',ctrl:'vCONENTDSC2',prop:'Visible'},{av:'edtavCuecod2_Visible',ctrl:'vCUECOD2',prop:'Visible'}]}");
         setEventMetadata("'REMOVEDYNAMICFILTERS3'","{handler:'E17242',iparms:[{av:'GRID_nFirstRecordOnPage'},{av:'GRID_nEOF'},{av:'subGrid_Rows',ctrl:'GRID',prop:'Rows'},{av:'cmbavDynamicfiltersselector1'},{av:'AV15DynamicFiltersSelector1',fld:'vDYNAMICFILTERSSELECTOR1',pic:''},{av:'cmbavDynamicfiltersoperator1'},{av:'AV16DynamicFiltersOperator1',fld:'vDYNAMICFILTERSOPERATOR1',pic:'ZZZ9'},{av:'AV17ConEntDsc1',fld:'vCONENTDSC1',pic:''},{av:'AV49CueCod1',fld:'vCUECOD1',pic:''},{av:'cmbavDynamicfiltersselector2'},{av:'AV19DynamicFiltersSelector2',fld:'vDYNAMICFILTERSSELECTOR2',pic:''},{av:'cmbavDynamicfiltersoperator2'},{av:'AV20DynamicFiltersOperator2',fld:'vDYNAMICFILTERSOPERATOR2',pic:'ZZZ9'},{av:'AV21ConEntDsc2',fld:'vCONENTDSC2',pic:''},{av:'AV50CueCod2',fld:'vCUECOD2',pic:''},{av:'cmbavDynamicfiltersselector3'},{av:'AV23DynamicFiltersSelector3',fld:'vDYNAMICFILTERSSELECTOR3',pic:''},{av:'cmbavDynamicfiltersoperator3'},{av:'AV24DynamicFiltersOperator3',fld:'vDYNAMICFILTERSOPERATOR3',pic:'ZZZ9'},{av:'AV25ConEntDsc3',fld:'vCONENTDSC3',pic:''},{av:'AV51CueCod3',fld:'vCUECOD3',pic:''},{av:'AV18DynamicFiltersEnabled2',fld:'vDYNAMICFILTERSENABLED2',pic:''},{av:'AV22DynamicFiltersEnabled3',fld:'vDYNAMICFILTERSENABLED3',pic:''},{av:'AV56Pgmname',fld:'vPGMNAME',pic:'',hsh:true},{av:'AV31TFConEntCod',fld:'vTFCONENTCOD',pic:'ZZZZZ9'},{av:'AV32TFConEntCod_To',fld:'vTFCONENTCOD_TO',pic:'ZZZZZ9'},{av:'AV33TFConEntDsc',fld:'vTFCONENTDSC',pic:''},{av:'AV34TFConEntDsc_Sel',fld:'vTFCONENTDSC_SEL',pic:''},{av:'AV35TFCueCod',fld:'vTFCUECOD',pic:''},{av:'AV36TFCueCod_Sel',fld:'vTFCUECOD_SEL',pic:''},{av:'AV37TFCueDsc',fld:'vTFCUEDSC',pic:''},{av:'AV38TFCueDsc_Sel',fld:'vTFCUEDSC_SEL',pic:''},{av:'AV53TFConEntSts_Sels',fld:'vTFCONENTSTS_SELS',pic:''},{av:'AV13OrderedBy',fld:'vORDEREDBY',pic:'ZZZ9'},{av:'AV14OrderedDsc',fld:'vORDEREDDSC',pic:''},{av:'AV10GridState',fld:'vGRIDSTATE',pic:''},{av:'AV27DynamicFiltersIgnoreFirst',fld:'vDYNAMICFILTERSIGNOREFIRST',pic:''},{av:'AV26DynamicFiltersRemoving',fld:'vDYNAMICFILTERSREMOVING',pic:''}]");
         setEventMetadata("'REMOVEDYNAMICFILTERS3'",",oparms:[{av:'AV26DynamicFiltersRemoving',fld:'vDYNAMICFILTERSREMOVING',pic:''},{av:'AV22DynamicFiltersEnabled3',fld:'vDYNAMICFILTERSENABLED3',pic:''},{av:'AV10GridState',fld:'vGRIDSTATE',pic:''},{av:'AV18DynamicFiltersEnabled2',fld:'vDYNAMICFILTERSENABLED2',pic:''},{av:'cmbavDynamicfiltersselector2'},{av:'AV19DynamicFiltersSelector2',fld:'vDYNAMICFILTERSSELECTOR2',pic:''},{av:'cmbavDynamicfiltersoperator2'},{av:'AV20DynamicFiltersOperator2',fld:'vDYNAMICFILTERSOPERATOR2',pic:'ZZZ9'},{av:'AV21ConEntDsc2',fld:'vCONENTDSC2',pic:''},{av:'cmbavDynamicfiltersselector3'},{av:'AV23DynamicFiltersSelector3',fld:'vDYNAMICFILTERSSELECTOR3',pic:''},{av:'cmbavDynamicfiltersoperator3'},{av:'AV24DynamicFiltersOperator3',fld:'vDYNAMICFILTERSOPERATOR3',pic:'ZZZ9'},{av:'AV25ConEntDsc3',fld:'vCONENTDSC3',pic:''},{av:'imgAdddynamicfilters1_Visible',ctrl:'ADDDYNAMICFILTERS1',prop:'Visible'},{av:'imgRemovedynamicfilters1_Visible',ctrl:'REMOVEDYNAMICFILTERS1',prop:'Visible'},{av:'imgAdddynamicfilters2_Visible',ctrl:'ADDDYNAMICFILTERS2',prop:'Visible'},{av:'imgRemovedynamicfilters2_Visible',ctrl:'REMOVEDYNAMICFILTERS2',prop:'Visible'},{av:'cmbavDynamicfiltersselector1'},{av:'AV15DynamicFiltersSelector1',fld:'vDYNAMICFILTERSSELECTOR1',pic:''},{av:'cmbavDynamicfiltersoperator1'},{av:'AV16DynamicFiltersOperator1',fld:'vDYNAMICFILTERSOPERATOR1',pic:'ZZZ9'},{av:'AV17ConEntDsc1',fld:'vCONENTDSC1',pic:''},{av:'AV49CueCod1',fld:'vCUECOD1',pic:''},{av:'lblJsdynamicfilters_Caption',ctrl:'JSDYNAMICFILTERS',prop:'Caption'},{av:'AV50CueCod2',fld:'vCUECOD2',pic:''},{av:'AV51CueCod3',fld:'vCUECOD3',pic:''},{av:'edtavConentdsc2_Visible',ctrl:'vCONENTDSC2',prop:'Visible'},{av:'edtavCuecod2_Visible',ctrl:'vCUECOD2',prop:'Visible'},{av:'edtavConentdsc3_Visible',ctrl:'vCONENTDSC3',prop:'Visible'},{av:'edtavCuecod3_Visible',ctrl:'vCUECOD3',prop:'Visible'},{av:'edtavConentdsc1_Visible',ctrl:'vCONENTDSC1',prop:'Visible'},{av:'edtavCuecod1_Visible',ctrl:'vCUECOD1',prop:'Visible'},{av:'AV43GridCurrentPage',fld:'vGRIDCURRENTPAGE',pic:'ZZZZZZZZZ9'},{av:'AV44GridPageCount',fld:'vGRIDPAGECOUNT',pic:'ZZZZZZZZZ9'},{av:'AV45GridAppliedFilters',fld:'vGRIDAPPLIEDFILTERS',pic:''}]}");
         setEventMetadata("VDYNAMICFILTERSSELECTOR3.CLICK","{handler:'E23242',iparms:[{av:'cmbavDynamicfiltersselector3'},{av:'AV23DynamicFiltersSelector3',fld:'vDYNAMICFILTERSSELECTOR3',pic:''}]");
         setEventMetadata("VDYNAMICFILTERSSELECTOR3.CLICK",",oparms:[{av:'cmbavDynamicfiltersoperator3'},{av:'AV24DynamicFiltersOperator3',fld:'vDYNAMICFILTERSOPERATOR3',pic:'ZZZ9'},{av:'edtavConentdsc3_Visible',ctrl:'vCONENTDSC3',prop:'Visible'},{av:'edtavCuecod3_Visible',ctrl:'vCUECOD3',prop:'Visible'}]}");
         setEventMetadata("VGRIDACTIONS.CLICK","{handler:'E27242',iparms:[{av:'cmbavGridactions'},{av:'AV46GridActions',fld:'vGRIDACTIONS',pic:'ZZZ9'},{av:'A376ConEntCod',fld:'CONENTCOD',pic:'ZZZZZ9',hsh:true}]");
         setEventMetadata("VGRIDACTIONS.CLICK",",oparms:[{av:'cmbavGridactions'},{av:'AV46GridActions',fld:'vGRIDACTIONS',pic:'ZZZ9'}]}");
         setEventMetadata("'DOINSERT'","{handler:'E18242',iparms:[{av:'A376ConEntCod',fld:'CONENTCOD',pic:'ZZZZZ9',hsh:true}]");
         setEventMetadata("'DOINSERT'",",oparms:[]}");
         setEventMetadata("DDO_AGEXPORT.ONOPTIONCLICKED","{handler:'E13242',iparms:[{av:'Ddo_agexport_Activeeventkey',ctrl:'DDO_AGEXPORT',prop:'ActiveEventKey'},{av:'AV56Pgmname',fld:'vPGMNAME',pic:'',hsh:true},{av:'AV53TFConEntSts_Sels',fld:'vTFCONENTSTS_SELS',pic:''},{av:'AV34TFConEntDsc_Sel',fld:'vTFCONENTDSC_SEL',pic:''},{av:'AV36TFCueCod_Sel',fld:'vTFCUECOD_SEL',pic:''},{av:'AV38TFCueDsc_Sel',fld:'vTFCUEDSC_SEL',pic:''},{av:'AV52TFConEntSts_SelsJson',fld:'vTFCONENTSTS_SELSJSON',pic:''},{av:'AV31TFConEntCod',fld:'vTFCONENTCOD',pic:'ZZZZZ9'},{av:'AV33TFConEntDsc',fld:'vTFCONENTDSC',pic:''},{av:'AV35TFCueCod',fld:'vTFCUECOD',pic:''},{av:'AV37TFCueDsc',fld:'vTFCUEDSC',pic:''},{av:'AV32TFConEntCod_To',fld:'vTFCONENTCOD_TO',pic:'ZZZZZ9'},{av:'AV13OrderedBy',fld:'vORDEREDBY',pic:'ZZZ9'},{av:'AV14OrderedDsc',fld:'vORDEREDDSC',pic:''},{av:'AV10GridState',fld:'vGRIDSTATE',pic:''},{av:'AV26DynamicFiltersRemoving',fld:'vDYNAMICFILTERSREMOVING',pic:''},{av:'cmbavDynamicfiltersselector1'},{av:'AV15DynamicFiltersSelector1',fld:'vDYNAMICFILTERSSELECTOR1',pic:''},{av:'cmbavDynamicfiltersselector2'},{av:'AV19DynamicFiltersSelector2',fld:'vDYNAMICFILTERSSELECTOR2',pic:''},{av:'cmbavDynamicfiltersselector3'},{av:'AV23DynamicFiltersSelector3',fld:'vDYNAMICFILTERSSELECTOR3',pic:''}]");
         setEventMetadata("DDO_AGEXPORT.ONOPTIONCLICKED",",oparms:[{av:'Innewwindow1_Target',ctrl:'INNEWWINDOW1',prop:'Target'},{av:'Innewwindow1_Height',ctrl:'INNEWWINDOW1',prop:'Height'},{av:'Innewwindow1_Width',ctrl:'INNEWWINDOW1',prop:'Width'},{av:'AV10GridState',fld:'vGRIDSTATE',pic:''},{av:'AV13OrderedBy',fld:'vORDEREDBY',pic:'ZZZ9'},{av:'AV14OrderedDsc',fld:'vORDEREDDSC',pic:''},{av:'AV52TFConEntSts_SelsJson',fld:'vTFCONENTSTS_SELSJSON',pic:''},{av:'AV53TFConEntSts_Sels',fld:'vTFCONENTSTS_SELS',pic:''},{av:'AV38TFCueDsc_Sel',fld:'vTFCUEDSC_SEL',pic:''},{av:'AV37TFCueDsc',fld:'vTFCUEDSC',pic:''},{av:'AV36TFCueCod_Sel',fld:'vTFCUECOD_SEL',pic:''},{av:'AV35TFCueCod',fld:'vTFCUECOD',pic:''},{av:'AV34TFConEntDsc_Sel',fld:'vTFCONENTDSC_SEL',pic:''},{av:'AV33TFConEntDsc',fld:'vTFCONENTDSC',pic:''},{av:'AV31TFConEntCod',fld:'vTFCONENTCOD',pic:'ZZZZZ9'},{av:'AV32TFConEntCod_To',fld:'vTFCONENTCOD_TO',pic:'ZZZZZ9'},{av:'Ddo_grid_Selectedvalue_set',ctrl:'DDO_GRID',prop:'SelectedValue_set'},{av:'Ddo_grid_Filteredtext_set',ctrl:'DDO_GRID',prop:'FilteredText_set'},{av:'Ddo_grid_Filteredtextto_set',ctrl:'DDO_GRID',prop:'FilteredTextTo_set'},{av:'subGrid_Rows',ctrl:'GRID',prop:'Rows'},{av:'GRID_nFirstRecordOnPage'},{av:'GRID_nEOF'},{av:'cmbavDynamicfiltersselector1'},{av:'AV15DynamicFiltersSelector1',fld:'vDYNAMICFILTERSSELECTOR1',pic:''},{av:'cmbavDynamicfiltersoperator1'},{av:'AV16DynamicFiltersOperator1',fld:'vDYNAMICFILTERSOPERATOR1',pic:'ZZZ9'},{av:'AV17ConEntDsc1',fld:'vCONENTDSC1',pic:''},{av:'AV49CueCod1',fld:'vCUECOD1',pic:''},{av:'cmbavDynamicfiltersselector2'},{av:'AV19DynamicFiltersSelector2',fld:'vDYNAMICFILTERSSELECTOR2',pic:''},{av:'cmbavDynamicfiltersoperator2'},{av:'AV20DynamicFiltersOperator2',fld:'vDYNAMICFILTERSOPERATOR2',pic:'ZZZ9'},{av:'AV21ConEntDsc2',fld:'vCONENTDSC2',pic:''},{av:'AV50CueCod2',fld:'vCUECOD2',pic:''},{av:'cmbavDynamicfiltersselector3'},{av:'AV23DynamicFiltersSelector3',fld:'vDYNAMICFILTERSSELECTOR3',pic:''},{av:'cmbavDynamicfiltersoperator3'},{av:'AV24DynamicFiltersOperator3',fld:'vDYNAMICFILTERSOPERATOR3',pic:'ZZZ9'},{av:'AV25ConEntDsc3',fld:'vCONENTDSC3',pic:''},{av:'AV51CueCod3',fld:'vCUECOD3',pic:''},{av:'AV18DynamicFiltersEnabled2',fld:'vDYNAMICFILTERSENABLED2',pic:''},{av:'AV22DynamicFiltersEnabled3',fld:'vDYNAMICFILTERSENABLED3',pic:''},{av:'AV56Pgmname',fld:'vPGMNAME',pic:'',hsh:true},{av:'AV27DynamicFiltersIgnoreFirst',fld:'vDYNAMICFILTERSIGNOREFIRST',pic:''},{av:'AV26DynamicFiltersRemoving',fld:'vDYNAMICFILTERSREMOVING',pic:''},{av:'Ddo_grid_Sortedstatus',ctrl:'DDO_GRID',prop:'SortedStatus'},{av:'imgAdddynamicfilters1_Visible',ctrl:'ADDDYNAMICFILTERS1',prop:'Visible'},{av:'imgRemovedynamicfilters1_Visible',ctrl:'REMOVEDYNAMICFILTERS1',prop:'Visible'},{av:'imgAdddynamicfilters2_Visible',ctrl:'ADDDYNAMICFILTERS2',prop:'Visible'},{av:'imgRemovedynamicfilters2_Visible',ctrl:'REMOVEDYNAMICFILTERS2',prop:'Visible'},{av:'lblJsdynamicfilters_Caption',ctrl:'JSDYNAMICFILTERS',prop:'Caption'},{av:'edtavConentdsc1_Visible',ctrl:'vCONENTDSC1',prop:'Visible'},{av:'edtavCuecod1_Visible',ctrl:'vCUECOD1',prop:'Visible'},{av:'edtavConentdsc2_Visible',ctrl:'vCONENTDSC2',prop:'Visible'},{av:'edtavCuecod2_Visible',ctrl:'vCUECOD2',prop:'Visible'},{av:'edtavConentdsc3_Visible',ctrl:'vCONENTDSC3',prop:'Visible'},{av:'edtavCuecod3_Visible',ctrl:'vCUECOD3',prop:'Visible'}]}");
         setEventMetadata("VALID_CUECOD","{handler:'Valid_Cuecod',iparms:[]");
         setEventMetadata("VALID_CUECOD",",oparms:[]}");
         setEventMetadata("NULL","{handler:'Valid_Conentsts',iparms:[]");
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
         AV17ConEntDsc1 = "";
         AV49CueCod1 = "";
         AV19DynamicFiltersSelector2 = "";
         AV21ConEntDsc2 = "";
         AV50CueCod2 = "";
         AV23DynamicFiltersSelector3 = "";
         AV25ConEntDsc3 = "";
         AV51CueCod3 = "";
         AV56Pgmname = "";
         AV33TFConEntDsc = "";
         AV34TFConEntDsc_Sel = "";
         AV35TFCueCod = "";
         AV36TFCueCod_Sel = "";
         AV37TFCueDsc = "";
         AV38TFCueDsc_Sel = "";
         AV53TFConEntSts_Sels = new GxSimpleCollection<short>();
         AV10GridState = new GeneXus.Programs.wwpbaseobjects.SdtWWPGridState(context);
         sDynURL = "";
         FormProcess = "";
         bodyStyle = "";
         GXKey = "";
         AV45GridAppliedFilters = "";
         AV47AGExportData = new GXBaseCollection<GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTDropDownOptionsData_Item>( context, "Item", "");
         AV41DDO_TitleSettingsIcons = new GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTDropDownOptionsTitleSettingsIcons(context);
         AV52TFConEntSts_SelsJson = "";
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
         A749ConEntDsc = "";
         A91CueCod = "";
         A860CueDsc = "";
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
         AV79Bancos_conceptoentregarendirwwds_23_tfconentsts_sels = new GxSimpleCollection<short>();
         scmdbuf = "";
         lV59Bancos_conceptoentregarendirwwds_3_conentdsc1 = "";
         lV60Bancos_conceptoentregarendirwwds_4_cuecod1 = "";
         lV64Bancos_conceptoentregarendirwwds_8_conentdsc2 = "";
         lV65Bancos_conceptoentregarendirwwds_9_cuecod2 = "";
         lV69Bancos_conceptoentregarendirwwds_13_conentdsc3 = "";
         lV70Bancos_conceptoentregarendirwwds_14_cuecod3 = "";
         lV73Bancos_conceptoentregarendirwwds_17_tfconentdsc = "";
         lV75Bancos_conceptoentregarendirwwds_19_tfcuecod = "";
         lV77Bancos_conceptoentregarendirwwds_21_tfcuedsc = "";
         AV57Bancos_conceptoentregarendirwwds_1_dynamicfiltersselector1 = "";
         AV59Bancos_conceptoentregarendirwwds_3_conentdsc1 = "";
         AV60Bancos_conceptoentregarendirwwds_4_cuecod1 = "";
         AV62Bancos_conceptoentregarendirwwds_6_dynamicfiltersselector2 = "";
         AV64Bancos_conceptoentregarendirwwds_8_conentdsc2 = "";
         AV65Bancos_conceptoentregarendirwwds_9_cuecod2 = "";
         AV67Bancos_conceptoentregarendirwwds_11_dynamicfiltersselector3 = "";
         AV69Bancos_conceptoentregarendirwwds_13_conentdsc3 = "";
         AV70Bancos_conceptoentregarendirwwds_14_cuecod3 = "";
         AV74Bancos_conceptoentregarendirwwds_18_tfconentdsc_sel = "";
         AV73Bancos_conceptoentregarendirwwds_17_tfconentdsc = "";
         AV76Bancos_conceptoentregarendirwwds_20_tfcuecod_sel = "";
         AV75Bancos_conceptoentregarendirwwds_19_tfcuecod = "";
         AV78Bancos_conceptoentregarendirwwds_22_tfcuedsc_sel = "";
         AV77Bancos_conceptoentregarendirwwds_21_tfcuedsc = "";
         H00242_A750ConEntSts = new short[1] ;
         H00242_A860CueDsc = new string[] {""} ;
         H00242_A91CueCod = new string[] {""} ;
         H00242_A749ConEntDsc = new string[] {""} ;
         H00242_A376ConEntCod = new int[1] ;
         H00243_AGRID_nRecordCount = new long[1] ;
         imgAdddynamicfilters1_Jsonclick = "";
         imgRemovedynamicfilters1_Jsonclick = "";
         imgAdddynamicfilters2_Jsonclick = "";
         imgRemovedynamicfilters2_Jsonclick = "";
         imgRemovedynamicfilters3_Jsonclick = "";
         AV48AGExportDataItem = new GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTDropDownOptionsData_Item(context);
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
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.bancos.conceptoentregarendirww__default(),
            new Object[][] {
                new Object[] {
               H00242_A750ConEntSts, H00242_A860CueDsc, H00242_A91CueCod, H00242_A749ConEntDsc, H00242_A376ConEntCod
               }
               , new Object[] {
               H00243_AGRID_nRecordCount
               }
            }
         );
         AV56Pgmname = "Bancos.ConceptoEntregaRendirWW";
         /* GeneXus formulas. */
         AV56Pgmname = "Bancos.ConceptoEntregaRendirWW";
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
      private short AV46GridActions ;
      private short A750ConEntSts ;
      private short subGrid_Allowselection ;
      private short subGrid_Allowhovering ;
      private short subGrid_Allowcollapsing ;
      private short subGrid_Collapsed ;
      private short nDonePA ;
      private short AV58Bancos_conceptoentregarendirwwds_2_dynamicfiltersoperator1 ;
      private short AV63Bancos_conceptoentregarendirwwds_7_dynamicfiltersoperator2 ;
      private short AV68Bancos_conceptoentregarendirwwds_12_dynamicfiltersoperator3 ;
      private short nGXWrapped ;
      private short subGrid_Backstyle ;
      private int subGrid_Rows ;
      private int Gridpaginationbar_Rowsperpageselectedvalue ;
      private int nRC_GXsfl_110 ;
      private int nGXsfl_110_idx=1 ;
      private int AV31TFConEntCod ;
      private int AV32TFConEntCod_To ;
      private int Gridpaginationbar_Pagestoshow ;
      private int subGrid_Titlebackcolor ;
      private int subGrid_Allbackcolor ;
      private int A376ConEntCod ;
      private int subGrid_Selectedindex ;
      private int subGrid_Selectioncolor ;
      private int subGrid_Hoveringcolor ;
      private int subGrid_Islastpage ;
      private int GXPagingFrom2 ;
      private int GXPagingTo2 ;
      private int AV79Bancos_conceptoentregarendirwwds_23_tfconentsts_sels_Count ;
      private int AV71Bancos_conceptoentregarendirwwds_15_tfconentcod ;
      private int AV72Bancos_conceptoentregarendirwwds_16_tfconentcod_to ;
      private int AV42PageToGo ;
      private int imgAdddynamicfilters1_Visible ;
      private int imgRemovedynamicfilters1_Visible ;
      private int imgAdddynamicfilters2_Visible ;
      private int imgRemovedynamicfilters2_Visible ;
      private int edtavConentdsc1_Visible ;
      private int edtavCuecod1_Visible ;
      private int edtavConentdsc2_Visible ;
      private int edtavCuecod2_Visible ;
      private int edtavConentdsc3_Visible ;
      private int edtavCuecod3_Visible ;
      private int AV80GXV1 ;
      private int edtavConentdsc3_Enabled ;
      private int edtavCuecod3_Enabled ;
      private int edtavConentdsc2_Enabled ;
      private int edtavCuecod2_Enabled ;
      private int edtavConentdsc1_Enabled ;
      private int edtavCuecod1_Enabled ;
      private int idxLst ;
      private int subGrid_Backcolor ;
      private long GRID_nFirstRecordOnPage ;
      private long AV43GridCurrentPage ;
      private long AV44GridPageCount ;
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
      private string sGXsfl_110_idx="0001" ;
      private string AV17ConEntDsc1 ;
      private string AV49CueCod1 ;
      private string AV21ConEntDsc2 ;
      private string AV50CueCod2 ;
      private string AV25ConEntDsc3 ;
      private string AV51CueCod3 ;
      private string AV56Pgmname ;
      private string AV33TFConEntDsc ;
      private string AV34TFConEntDsc_Sel ;
      private string AV35TFCueCod ;
      private string AV36TFCueCod_Sel ;
      private string AV37TFCueDsc ;
      private string AV38TFCueDsc_Sel ;
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
      private string A749ConEntDsc ;
      private string edtConEntDsc_Link ;
      private string A91CueCod ;
      private string A860CueDsc ;
      private string edtCueDsc_Link ;
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
      private string edtConEntCod_Internalname ;
      private string edtConEntDsc_Internalname ;
      private string edtCueCod_Internalname ;
      private string edtCueDsc_Internalname ;
      private string cmbConEntSts_Internalname ;
      private string cmbavDynamicfiltersselector1_Internalname ;
      private string cmbavDynamicfiltersoperator1_Internalname ;
      private string cmbavDynamicfiltersselector2_Internalname ;
      private string cmbavDynamicfiltersoperator2_Internalname ;
      private string cmbavDynamicfiltersselector3_Internalname ;
      private string cmbavDynamicfiltersoperator3_Internalname ;
      private string scmdbuf ;
      private string lV59Bancos_conceptoentregarendirwwds_3_conentdsc1 ;
      private string lV60Bancos_conceptoentregarendirwwds_4_cuecod1 ;
      private string lV64Bancos_conceptoentregarendirwwds_8_conentdsc2 ;
      private string lV65Bancos_conceptoentregarendirwwds_9_cuecod2 ;
      private string lV69Bancos_conceptoentregarendirwwds_13_conentdsc3 ;
      private string lV70Bancos_conceptoentregarendirwwds_14_cuecod3 ;
      private string lV73Bancos_conceptoentregarendirwwds_17_tfconentdsc ;
      private string lV75Bancos_conceptoentregarendirwwds_19_tfcuecod ;
      private string lV77Bancos_conceptoentregarendirwwds_21_tfcuedsc ;
      private string AV59Bancos_conceptoentregarendirwwds_3_conentdsc1 ;
      private string AV60Bancos_conceptoentregarendirwwds_4_cuecod1 ;
      private string AV64Bancos_conceptoentregarendirwwds_8_conentdsc2 ;
      private string AV65Bancos_conceptoentregarendirwwds_9_cuecod2 ;
      private string AV69Bancos_conceptoentregarendirwwds_13_conentdsc3 ;
      private string AV70Bancos_conceptoentregarendirwwds_14_cuecod3 ;
      private string AV74Bancos_conceptoentregarendirwwds_18_tfconentdsc_sel ;
      private string AV73Bancos_conceptoentregarendirwwds_17_tfconentdsc ;
      private string AV76Bancos_conceptoentregarendirwwds_20_tfcuecod_sel ;
      private string AV75Bancos_conceptoentregarendirwwds_19_tfcuecod ;
      private string AV78Bancos_conceptoentregarendirwwds_22_tfcuedsc_sel ;
      private string AV77Bancos_conceptoentregarendirwwds_21_tfcuedsc ;
      private string edtavConentdsc1_Internalname ;
      private string edtavCuecod1_Internalname ;
      private string edtavConentdsc2_Internalname ;
      private string edtavCuecod2_Internalname ;
      private string edtavConentdsc3_Internalname ;
      private string edtavCuecod3_Internalname ;
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
      private string cellFilter_conentdsc3_cell_Internalname ;
      private string edtavConentdsc3_Jsonclick ;
      private string cellFilter_cuecod3_cell_Internalname ;
      private string edtavCuecod3_Jsonclick ;
      private string cellDynamicfilters_removefilter3_cell_Internalname ;
      private string sImgUrl ;
      private string tblTablemergeddynamicfilters2_Internalname ;
      private string cmbavDynamicfiltersoperator2_Jsonclick ;
      private string cellFilter_conentdsc2_cell_Internalname ;
      private string edtavConentdsc2_Jsonclick ;
      private string cellFilter_cuecod2_cell_Internalname ;
      private string edtavCuecod2_Jsonclick ;
      private string cellDynamicfilters_addfilter2_cell_Internalname ;
      private string cellDynamicfilters_removefilter2_cell_Internalname ;
      private string tblTablemergeddynamicfilters1_Internalname ;
      private string cmbavDynamicfiltersoperator1_Jsonclick ;
      private string cellFilter_conentdsc1_cell_Internalname ;
      private string edtavConentdsc1_Jsonclick ;
      private string cellFilter_cuecod1_cell_Internalname ;
      private string edtavCuecod1_Jsonclick ;
      private string cellDynamicfilters_addfilter1_cell_Internalname ;
      private string cellDynamicfilters_removefilter1_cell_Internalname ;
      private string sGXsfl_110_fel_idx="0001" ;
      private string GXCCtl ;
      private string cmbavGridactions_Jsonclick ;
      private string ROClassString ;
      private string edtConEntCod_Jsonclick ;
      private string edtConEntDsc_Jsonclick ;
      private string edtCueCod_Jsonclick ;
      private string edtCueDsc_Jsonclick ;
      private string cmbConEntSts_Jsonclick ;
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
      private bool AV61Bancos_conceptoentregarendirwwds_5_dynamicfiltersenabled2 ;
      private bool AV66Bancos_conceptoentregarendirwwds_10_dynamicfiltersenabled3 ;
      private bool returnInSub ;
      private bool gx_refresh_fired ;
      private string AV52TFConEntSts_SelsJson ;
      private string AV15DynamicFiltersSelector1 ;
      private string AV19DynamicFiltersSelector2 ;
      private string AV23DynamicFiltersSelector3 ;
      private string AV45GridAppliedFilters ;
      private string AV57Bancos_conceptoentregarendirwwds_1_dynamicfiltersselector1 ;
      private string AV62Bancos_conceptoentregarendirwwds_6_dynamicfiltersselector2 ;
      private string AV67Bancos_conceptoentregarendirwwds_11_dynamicfiltersselector3 ;
      private string AV28ExcelFilename ;
      private string AV29ErrorMessage ;
      private GxSimpleCollection<short> AV53TFConEntSts_Sels ;
      private GxSimpleCollection<short> AV79Bancos_conceptoentregarendirwwds_23_tfconentsts_sels ;
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
      private GXCombobox cmbConEntSts ;
      private IDataStoreProvider pr_default ;
      private short[] H00242_A750ConEntSts ;
      private string[] H00242_A860CueDsc ;
      private string[] H00242_A91CueCod ;
      private string[] H00242_A749ConEntDsc ;
      private int[] H00242_A376ConEntCod ;
      private long[] H00243_AGRID_nRecordCount ;
      private msglist BackMsgLst ;
      private msglist LclMsgLst ;
      private GxHttpRequest AV7HTTPRequest ;
      private GXBaseCollection<GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTDropDownOptionsData_Item> AV47AGExportData ;
      private GXWebForm Form ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPContext AV6WWPContext ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPTransactionContext AV8TrnContext ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPGridState AV10GridState ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue AV11GridStateFilterValue ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter AV12GridStateDynamicFilter ;
      private GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTDropDownOptionsTitleSettingsIcons AV41DDO_TitleSettingsIcons ;
      private GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTDropDownOptionsTitleSettingsIcons GXt_SdtDVB_SDTDropDownOptionsTitleSettingsIcons1 ;
      private GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTDropDownOptionsData_Item AV48AGExportDataItem ;
   }

   public class conceptoentregarendirww__default : DataStoreHelperBase, IDataStoreHelper
   {
      protected Object[] conditional_H00242( IGxContext context ,
                                             short A750ConEntSts ,
                                             GxSimpleCollection<short> AV79Bancos_conceptoentregarendirwwds_23_tfconentsts_sels ,
                                             string AV57Bancos_conceptoentregarendirwwds_1_dynamicfiltersselector1 ,
                                             short AV58Bancos_conceptoentregarendirwwds_2_dynamicfiltersoperator1 ,
                                             string AV59Bancos_conceptoentregarendirwwds_3_conentdsc1 ,
                                             string AV60Bancos_conceptoentregarendirwwds_4_cuecod1 ,
                                             bool AV61Bancos_conceptoentregarendirwwds_5_dynamicfiltersenabled2 ,
                                             string AV62Bancos_conceptoentregarendirwwds_6_dynamicfiltersselector2 ,
                                             short AV63Bancos_conceptoentregarendirwwds_7_dynamicfiltersoperator2 ,
                                             string AV64Bancos_conceptoentregarendirwwds_8_conentdsc2 ,
                                             string AV65Bancos_conceptoentregarendirwwds_9_cuecod2 ,
                                             bool AV66Bancos_conceptoentregarendirwwds_10_dynamicfiltersenabled3 ,
                                             string AV67Bancos_conceptoentregarendirwwds_11_dynamicfiltersselector3 ,
                                             short AV68Bancos_conceptoentregarendirwwds_12_dynamicfiltersoperator3 ,
                                             string AV69Bancos_conceptoentregarendirwwds_13_conentdsc3 ,
                                             string AV70Bancos_conceptoentregarendirwwds_14_cuecod3 ,
                                             int AV71Bancos_conceptoentregarendirwwds_15_tfconentcod ,
                                             int AV72Bancos_conceptoentregarendirwwds_16_tfconentcod_to ,
                                             string AV74Bancos_conceptoentregarendirwwds_18_tfconentdsc_sel ,
                                             string AV73Bancos_conceptoentregarendirwwds_17_tfconentdsc ,
                                             string AV76Bancos_conceptoentregarendirwwds_20_tfcuecod_sel ,
                                             string AV75Bancos_conceptoentregarendirwwds_19_tfcuecod ,
                                             string AV78Bancos_conceptoentregarendirwwds_22_tfcuedsc_sel ,
                                             string AV77Bancos_conceptoentregarendirwwds_21_tfcuedsc ,
                                             int AV79Bancos_conceptoentregarendirwwds_23_tfconentsts_sels_Count ,
                                             string A749ConEntDsc ,
                                             string A91CueCod ,
                                             int A376ConEntCod ,
                                             string A860CueDsc ,
                                             short AV13OrderedBy ,
                                             bool AV14OrderedDsc )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int5 = new short[23];
         Object[] GXv_Object6 = new Object[2];
         string sSelectString;
         string sFromString;
         string sOrderString;
         sSelectString = " T1.[ConEntSts], T2.[CueDsc], T1.[CueCod], T1.[ConEntDsc], T1.[ConEntCod]";
         sFromString = " FROM ([TSCONCEPTOENTREGA] T1 INNER JOIN [CBPLANCUENTA] T2 ON T2.[CueCod] = T1.[CueCod])";
         sOrderString = "";
         if ( ( StringUtil.StrCmp(AV57Bancos_conceptoentregarendirwwds_1_dynamicfiltersselector1, "CONENTDSC") == 0 ) && ( AV58Bancos_conceptoentregarendirwwds_2_dynamicfiltersoperator1 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV59Bancos_conceptoentregarendirwwds_3_conentdsc1)) ) )
         {
            AddWhere(sWhereString, "(T1.[ConEntDsc] like @lV59Bancos_conceptoentregarendirwwds_3_conentdsc1)");
         }
         else
         {
            GXv_int5[0] = 1;
         }
         if ( ( StringUtil.StrCmp(AV57Bancos_conceptoentregarendirwwds_1_dynamicfiltersselector1, "CONENTDSC") == 0 ) && ( AV58Bancos_conceptoentregarendirwwds_2_dynamicfiltersoperator1 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV59Bancos_conceptoentregarendirwwds_3_conentdsc1)) ) )
         {
            AddWhere(sWhereString, "(T1.[ConEntDsc] like '%' + @lV59Bancos_conceptoentregarendirwwds_3_conentdsc1)");
         }
         else
         {
            GXv_int5[1] = 1;
         }
         if ( ( StringUtil.StrCmp(AV57Bancos_conceptoentregarendirwwds_1_dynamicfiltersselector1, "CUECOD") == 0 ) && ( AV58Bancos_conceptoentregarendirwwds_2_dynamicfiltersoperator1 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV60Bancos_conceptoentregarendirwwds_4_cuecod1)) ) )
         {
            AddWhere(sWhereString, "(T1.[CueCod] like @lV60Bancos_conceptoentregarendirwwds_4_cuecod1)");
         }
         else
         {
            GXv_int5[2] = 1;
         }
         if ( ( StringUtil.StrCmp(AV57Bancos_conceptoentregarendirwwds_1_dynamicfiltersselector1, "CUECOD") == 0 ) && ( AV58Bancos_conceptoentregarendirwwds_2_dynamicfiltersoperator1 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV60Bancos_conceptoentregarendirwwds_4_cuecod1)) ) )
         {
            AddWhere(sWhereString, "(T1.[CueCod] like '%' + @lV60Bancos_conceptoentregarendirwwds_4_cuecod1)");
         }
         else
         {
            GXv_int5[3] = 1;
         }
         if ( AV61Bancos_conceptoentregarendirwwds_5_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV62Bancos_conceptoentregarendirwwds_6_dynamicfiltersselector2, "CONENTDSC") == 0 ) && ( AV63Bancos_conceptoentregarendirwwds_7_dynamicfiltersoperator2 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV64Bancos_conceptoentregarendirwwds_8_conentdsc2)) ) )
         {
            AddWhere(sWhereString, "(T1.[ConEntDsc] like @lV64Bancos_conceptoentregarendirwwds_8_conentdsc2)");
         }
         else
         {
            GXv_int5[4] = 1;
         }
         if ( AV61Bancos_conceptoentregarendirwwds_5_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV62Bancos_conceptoentregarendirwwds_6_dynamicfiltersselector2, "CONENTDSC") == 0 ) && ( AV63Bancos_conceptoentregarendirwwds_7_dynamicfiltersoperator2 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV64Bancos_conceptoentregarendirwwds_8_conentdsc2)) ) )
         {
            AddWhere(sWhereString, "(T1.[ConEntDsc] like '%' + @lV64Bancos_conceptoentregarendirwwds_8_conentdsc2)");
         }
         else
         {
            GXv_int5[5] = 1;
         }
         if ( AV61Bancos_conceptoentregarendirwwds_5_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV62Bancos_conceptoentregarendirwwds_6_dynamicfiltersselector2, "CUECOD") == 0 ) && ( AV63Bancos_conceptoentregarendirwwds_7_dynamicfiltersoperator2 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV65Bancos_conceptoentregarendirwwds_9_cuecod2)) ) )
         {
            AddWhere(sWhereString, "(T1.[CueCod] like @lV65Bancos_conceptoentregarendirwwds_9_cuecod2)");
         }
         else
         {
            GXv_int5[6] = 1;
         }
         if ( AV61Bancos_conceptoentregarendirwwds_5_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV62Bancos_conceptoentregarendirwwds_6_dynamicfiltersselector2, "CUECOD") == 0 ) && ( AV63Bancos_conceptoentregarendirwwds_7_dynamicfiltersoperator2 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV65Bancos_conceptoentregarendirwwds_9_cuecod2)) ) )
         {
            AddWhere(sWhereString, "(T1.[CueCod] like '%' + @lV65Bancos_conceptoentregarendirwwds_9_cuecod2)");
         }
         else
         {
            GXv_int5[7] = 1;
         }
         if ( AV66Bancos_conceptoentregarendirwwds_10_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV67Bancos_conceptoentregarendirwwds_11_dynamicfiltersselector3, "CONENTDSC") == 0 ) && ( AV68Bancos_conceptoentregarendirwwds_12_dynamicfiltersoperator3 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV69Bancos_conceptoentregarendirwwds_13_conentdsc3)) ) )
         {
            AddWhere(sWhereString, "(T1.[ConEntDsc] like @lV69Bancos_conceptoentregarendirwwds_13_conentdsc3)");
         }
         else
         {
            GXv_int5[8] = 1;
         }
         if ( AV66Bancos_conceptoentregarendirwwds_10_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV67Bancos_conceptoentregarendirwwds_11_dynamicfiltersselector3, "CONENTDSC") == 0 ) && ( AV68Bancos_conceptoentregarendirwwds_12_dynamicfiltersoperator3 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV69Bancos_conceptoentregarendirwwds_13_conentdsc3)) ) )
         {
            AddWhere(sWhereString, "(T1.[ConEntDsc] like '%' + @lV69Bancos_conceptoentregarendirwwds_13_conentdsc3)");
         }
         else
         {
            GXv_int5[9] = 1;
         }
         if ( AV66Bancos_conceptoentregarendirwwds_10_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV67Bancos_conceptoentregarendirwwds_11_dynamicfiltersselector3, "CUECOD") == 0 ) && ( AV68Bancos_conceptoentregarendirwwds_12_dynamicfiltersoperator3 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV70Bancos_conceptoentregarendirwwds_14_cuecod3)) ) )
         {
            AddWhere(sWhereString, "(T1.[CueCod] like @lV70Bancos_conceptoentregarendirwwds_14_cuecod3)");
         }
         else
         {
            GXv_int5[10] = 1;
         }
         if ( AV66Bancos_conceptoentregarendirwwds_10_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV67Bancos_conceptoentregarendirwwds_11_dynamicfiltersselector3, "CUECOD") == 0 ) && ( AV68Bancos_conceptoentregarendirwwds_12_dynamicfiltersoperator3 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV70Bancos_conceptoentregarendirwwds_14_cuecod3)) ) )
         {
            AddWhere(sWhereString, "(T1.[CueCod] like '%' + @lV70Bancos_conceptoentregarendirwwds_14_cuecod3)");
         }
         else
         {
            GXv_int5[11] = 1;
         }
         if ( ! (0==AV71Bancos_conceptoentregarendirwwds_15_tfconentcod) )
         {
            AddWhere(sWhereString, "(T1.[ConEntCod] >= @AV71Bancos_conceptoentregarendirwwds_15_tfconentcod)");
         }
         else
         {
            GXv_int5[12] = 1;
         }
         if ( ! (0==AV72Bancos_conceptoentregarendirwwds_16_tfconentcod_to) )
         {
            AddWhere(sWhereString, "(T1.[ConEntCod] <= @AV72Bancos_conceptoentregarendirwwds_16_tfconentcod_to)");
         }
         else
         {
            GXv_int5[13] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV74Bancos_conceptoentregarendirwwds_18_tfconentdsc_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV73Bancos_conceptoentregarendirwwds_17_tfconentdsc)) ) )
         {
            AddWhere(sWhereString, "(T1.[ConEntDsc] like @lV73Bancos_conceptoentregarendirwwds_17_tfconentdsc)");
         }
         else
         {
            GXv_int5[14] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV74Bancos_conceptoentregarendirwwds_18_tfconentdsc_sel)) )
         {
            AddWhere(sWhereString, "(T1.[ConEntDsc] = @AV74Bancos_conceptoentregarendirwwds_18_tfconentdsc_sel)");
         }
         else
         {
            GXv_int5[15] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV76Bancos_conceptoentregarendirwwds_20_tfcuecod_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV75Bancos_conceptoentregarendirwwds_19_tfcuecod)) ) )
         {
            AddWhere(sWhereString, "(T1.[CueCod] like @lV75Bancos_conceptoentregarendirwwds_19_tfcuecod)");
         }
         else
         {
            GXv_int5[16] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV76Bancos_conceptoentregarendirwwds_20_tfcuecod_sel)) )
         {
            AddWhere(sWhereString, "(T1.[CueCod] = @AV76Bancos_conceptoentregarendirwwds_20_tfcuecod_sel)");
         }
         else
         {
            GXv_int5[17] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV78Bancos_conceptoentregarendirwwds_22_tfcuedsc_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV77Bancos_conceptoentregarendirwwds_21_tfcuedsc)) ) )
         {
            AddWhere(sWhereString, "(T2.[CueDsc] like @lV77Bancos_conceptoentregarendirwwds_21_tfcuedsc)");
         }
         else
         {
            GXv_int5[18] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV78Bancos_conceptoentregarendirwwds_22_tfcuedsc_sel)) )
         {
            AddWhere(sWhereString, "(T2.[CueDsc] = @AV78Bancos_conceptoentregarendirwwds_22_tfcuedsc_sel)");
         }
         else
         {
            GXv_int5[19] = 1;
         }
         if ( AV79Bancos_conceptoentregarendirwwds_23_tfconentsts_sels_Count > 0 )
         {
            AddWhere(sWhereString, "("+new GxDbmsUtils( new GxSqlServer()).ValueList(AV79Bancos_conceptoentregarendirwwds_23_tfconentsts_sels, "T1.[ConEntSts] IN (", ")")+")");
         }
         if ( ( AV13OrderedBy == 1 ) && ! AV14OrderedDsc )
         {
            sOrderString += " ORDER BY T1.[ConEntCod]";
         }
         else if ( ( AV13OrderedBy == 1 ) && ( AV14OrderedDsc ) )
         {
            sOrderString += " ORDER BY T1.[ConEntCod] DESC";
         }
         else if ( ( AV13OrderedBy == 2 ) && ! AV14OrderedDsc )
         {
            sOrderString += " ORDER BY T1.[ConEntDsc]";
         }
         else if ( ( AV13OrderedBy == 2 ) && ( AV14OrderedDsc ) )
         {
            sOrderString += " ORDER BY T1.[ConEntDsc] DESC";
         }
         else if ( ( AV13OrderedBy == 3 ) && ! AV14OrderedDsc )
         {
            sOrderString += " ORDER BY T1.[CueCod]";
         }
         else if ( ( AV13OrderedBy == 3 ) && ( AV14OrderedDsc ) )
         {
            sOrderString += " ORDER BY T1.[CueCod] DESC";
         }
         else if ( ( AV13OrderedBy == 4 ) && ! AV14OrderedDsc )
         {
            sOrderString += " ORDER BY T2.[CueDsc]";
         }
         else if ( ( AV13OrderedBy == 4 ) && ( AV14OrderedDsc ) )
         {
            sOrderString += " ORDER BY T2.[CueDsc] DESC";
         }
         else if ( ( AV13OrderedBy == 5 ) && ! AV14OrderedDsc )
         {
            sOrderString += " ORDER BY T1.[ConEntSts]";
         }
         else if ( ( AV13OrderedBy == 5 ) && ( AV14OrderedDsc ) )
         {
            sOrderString += " ORDER BY T1.[ConEntSts] DESC";
         }
         else if ( true )
         {
            sOrderString += " ORDER BY T1.[ConEntCod]";
         }
         scmdbuf = "SELECT " + sSelectString + sFromString + sWhereString + sOrderString + "" + " OFFSET " + "@GXPagingFrom2" + " ROWS FETCH NEXT CAST((SELECT CASE WHEN " + "@GXPagingTo2" + " > 0 THEN " + "@GXPagingTo2" + " ELSE 1e9 END) AS INTEGER) ROWS ONLY";
         GXv_Object6[0] = scmdbuf;
         GXv_Object6[1] = GXv_int5;
         return GXv_Object6 ;
      }

      protected Object[] conditional_H00243( IGxContext context ,
                                             short A750ConEntSts ,
                                             GxSimpleCollection<short> AV79Bancos_conceptoentregarendirwwds_23_tfconentsts_sels ,
                                             string AV57Bancos_conceptoentregarendirwwds_1_dynamicfiltersselector1 ,
                                             short AV58Bancos_conceptoentregarendirwwds_2_dynamicfiltersoperator1 ,
                                             string AV59Bancos_conceptoentregarendirwwds_3_conentdsc1 ,
                                             string AV60Bancos_conceptoentregarendirwwds_4_cuecod1 ,
                                             bool AV61Bancos_conceptoentregarendirwwds_5_dynamicfiltersenabled2 ,
                                             string AV62Bancos_conceptoentregarendirwwds_6_dynamicfiltersselector2 ,
                                             short AV63Bancos_conceptoentregarendirwwds_7_dynamicfiltersoperator2 ,
                                             string AV64Bancos_conceptoentregarendirwwds_8_conentdsc2 ,
                                             string AV65Bancos_conceptoentregarendirwwds_9_cuecod2 ,
                                             bool AV66Bancos_conceptoentregarendirwwds_10_dynamicfiltersenabled3 ,
                                             string AV67Bancos_conceptoentregarendirwwds_11_dynamicfiltersselector3 ,
                                             short AV68Bancos_conceptoentregarendirwwds_12_dynamicfiltersoperator3 ,
                                             string AV69Bancos_conceptoentregarendirwwds_13_conentdsc3 ,
                                             string AV70Bancos_conceptoentregarendirwwds_14_cuecod3 ,
                                             int AV71Bancos_conceptoentregarendirwwds_15_tfconentcod ,
                                             int AV72Bancos_conceptoentregarendirwwds_16_tfconentcod_to ,
                                             string AV74Bancos_conceptoentregarendirwwds_18_tfconentdsc_sel ,
                                             string AV73Bancos_conceptoentregarendirwwds_17_tfconentdsc ,
                                             string AV76Bancos_conceptoentregarendirwwds_20_tfcuecod_sel ,
                                             string AV75Bancos_conceptoentregarendirwwds_19_tfcuecod ,
                                             string AV78Bancos_conceptoentregarendirwwds_22_tfcuedsc_sel ,
                                             string AV77Bancos_conceptoentregarendirwwds_21_tfcuedsc ,
                                             int AV79Bancos_conceptoentregarendirwwds_23_tfconentsts_sels_Count ,
                                             string A749ConEntDsc ,
                                             string A91CueCod ,
                                             int A376ConEntCod ,
                                             string A860CueDsc ,
                                             short AV13OrderedBy ,
                                             bool AV14OrderedDsc )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int7 = new short[20];
         Object[] GXv_Object8 = new Object[2];
         scmdbuf = "SELECT COUNT(*) FROM ([TSCONCEPTOENTREGA] T1 INNER JOIN [CBPLANCUENTA] T2 ON T2.[CueCod] = T1.[CueCod])";
         if ( ( StringUtil.StrCmp(AV57Bancos_conceptoentregarendirwwds_1_dynamicfiltersselector1, "CONENTDSC") == 0 ) && ( AV58Bancos_conceptoentregarendirwwds_2_dynamicfiltersoperator1 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV59Bancos_conceptoentregarendirwwds_3_conentdsc1)) ) )
         {
            AddWhere(sWhereString, "(T1.[ConEntDsc] like @lV59Bancos_conceptoentregarendirwwds_3_conentdsc1)");
         }
         else
         {
            GXv_int7[0] = 1;
         }
         if ( ( StringUtil.StrCmp(AV57Bancos_conceptoentregarendirwwds_1_dynamicfiltersselector1, "CONENTDSC") == 0 ) && ( AV58Bancos_conceptoentregarendirwwds_2_dynamicfiltersoperator1 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV59Bancos_conceptoentregarendirwwds_3_conentdsc1)) ) )
         {
            AddWhere(sWhereString, "(T1.[ConEntDsc] like '%' + @lV59Bancos_conceptoentregarendirwwds_3_conentdsc1)");
         }
         else
         {
            GXv_int7[1] = 1;
         }
         if ( ( StringUtil.StrCmp(AV57Bancos_conceptoentregarendirwwds_1_dynamicfiltersselector1, "CUECOD") == 0 ) && ( AV58Bancos_conceptoentregarendirwwds_2_dynamicfiltersoperator1 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV60Bancos_conceptoentregarendirwwds_4_cuecod1)) ) )
         {
            AddWhere(sWhereString, "(T1.[CueCod] like @lV60Bancos_conceptoentregarendirwwds_4_cuecod1)");
         }
         else
         {
            GXv_int7[2] = 1;
         }
         if ( ( StringUtil.StrCmp(AV57Bancos_conceptoentregarendirwwds_1_dynamicfiltersselector1, "CUECOD") == 0 ) && ( AV58Bancos_conceptoentregarendirwwds_2_dynamicfiltersoperator1 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV60Bancos_conceptoentregarendirwwds_4_cuecod1)) ) )
         {
            AddWhere(sWhereString, "(T1.[CueCod] like '%' + @lV60Bancos_conceptoentregarendirwwds_4_cuecod1)");
         }
         else
         {
            GXv_int7[3] = 1;
         }
         if ( AV61Bancos_conceptoentregarendirwwds_5_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV62Bancos_conceptoentregarendirwwds_6_dynamicfiltersselector2, "CONENTDSC") == 0 ) && ( AV63Bancos_conceptoentregarendirwwds_7_dynamicfiltersoperator2 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV64Bancos_conceptoentregarendirwwds_8_conentdsc2)) ) )
         {
            AddWhere(sWhereString, "(T1.[ConEntDsc] like @lV64Bancos_conceptoentregarendirwwds_8_conentdsc2)");
         }
         else
         {
            GXv_int7[4] = 1;
         }
         if ( AV61Bancos_conceptoentregarendirwwds_5_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV62Bancos_conceptoentregarendirwwds_6_dynamicfiltersselector2, "CONENTDSC") == 0 ) && ( AV63Bancos_conceptoentregarendirwwds_7_dynamicfiltersoperator2 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV64Bancos_conceptoentregarendirwwds_8_conentdsc2)) ) )
         {
            AddWhere(sWhereString, "(T1.[ConEntDsc] like '%' + @lV64Bancos_conceptoentregarendirwwds_8_conentdsc2)");
         }
         else
         {
            GXv_int7[5] = 1;
         }
         if ( AV61Bancos_conceptoentregarendirwwds_5_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV62Bancos_conceptoentregarendirwwds_6_dynamicfiltersselector2, "CUECOD") == 0 ) && ( AV63Bancos_conceptoentregarendirwwds_7_dynamicfiltersoperator2 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV65Bancos_conceptoentregarendirwwds_9_cuecod2)) ) )
         {
            AddWhere(sWhereString, "(T1.[CueCod] like @lV65Bancos_conceptoentregarendirwwds_9_cuecod2)");
         }
         else
         {
            GXv_int7[6] = 1;
         }
         if ( AV61Bancos_conceptoentregarendirwwds_5_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV62Bancos_conceptoentregarendirwwds_6_dynamicfiltersselector2, "CUECOD") == 0 ) && ( AV63Bancos_conceptoentregarendirwwds_7_dynamicfiltersoperator2 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV65Bancos_conceptoentregarendirwwds_9_cuecod2)) ) )
         {
            AddWhere(sWhereString, "(T1.[CueCod] like '%' + @lV65Bancos_conceptoentregarendirwwds_9_cuecod2)");
         }
         else
         {
            GXv_int7[7] = 1;
         }
         if ( AV66Bancos_conceptoentregarendirwwds_10_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV67Bancos_conceptoentregarendirwwds_11_dynamicfiltersselector3, "CONENTDSC") == 0 ) && ( AV68Bancos_conceptoentregarendirwwds_12_dynamicfiltersoperator3 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV69Bancos_conceptoentregarendirwwds_13_conentdsc3)) ) )
         {
            AddWhere(sWhereString, "(T1.[ConEntDsc] like @lV69Bancos_conceptoentregarendirwwds_13_conentdsc3)");
         }
         else
         {
            GXv_int7[8] = 1;
         }
         if ( AV66Bancos_conceptoentregarendirwwds_10_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV67Bancos_conceptoentregarendirwwds_11_dynamicfiltersselector3, "CONENTDSC") == 0 ) && ( AV68Bancos_conceptoentregarendirwwds_12_dynamicfiltersoperator3 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV69Bancos_conceptoentregarendirwwds_13_conentdsc3)) ) )
         {
            AddWhere(sWhereString, "(T1.[ConEntDsc] like '%' + @lV69Bancos_conceptoentregarendirwwds_13_conentdsc3)");
         }
         else
         {
            GXv_int7[9] = 1;
         }
         if ( AV66Bancos_conceptoentregarendirwwds_10_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV67Bancos_conceptoentregarendirwwds_11_dynamicfiltersselector3, "CUECOD") == 0 ) && ( AV68Bancos_conceptoentregarendirwwds_12_dynamicfiltersoperator3 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV70Bancos_conceptoentregarendirwwds_14_cuecod3)) ) )
         {
            AddWhere(sWhereString, "(T1.[CueCod] like @lV70Bancos_conceptoentregarendirwwds_14_cuecod3)");
         }
         else
         {
            GXv_int7[10] = 1;
         }
         if ( AV66Bancos_conceptoentregarendirwwds_10_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV67Bancos_conceptoentregarendirwwds_11_dynamicfiltersselector3, "CUECOD") == 0 ) && ( AV68Bancos_conceptoentregarendirwwds_12_dynamicfiltersoperator3 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV70Bancos_conceptoentregarendirwwds_14_cuecod3)) ) )
         {
            AddWhere(sWhereString, "(T1.[CueCod] like '%' + @lV70Bancos_conceptoentregarendirwwds_14_cuecod3)");
         }
         else
         {
            GXv_int7[11] = 1;
         }
         if ( ! (0==AV71Bancos_conceptoentregarendirwwds_15_tfconentcod) )
         {
            AddWhere(sWhereString, "(T1.[ConEntCod] >= @AV71Bancos_conceptoentregarendirwwds_15_tfconentcod)");
         }
         else
         {
            GXv_int7[12] = 1;
         }
         if ( ! (0==AV72Bancos_conceptoentregarendirwwds_16_tfconentcod_to) )
         {
            AddWhere(sWhereString, "(T1.[ConEntCod] <= @AV72Bancos_conceptoentregarendirwwds_16_tfconentcod_to)");
         }
         else
         {
            GXv_int7[13] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV74Bancos_conceptoentregarendirwwds_18_tfconentdsc_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV73Bancos_conceptoentregarendirwwds_17_tfconentdsc)) ) )
         {
            AddWhere(sWhereString, "(T1.[ConEntDsc] like @lV73Bancos_conceptoentregarendirwwds_17_tfconentdsc)");
         }
         else
         {
            GXv_int7[14] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV74Bancos_conceptoentregarendirwwds_18_tfconentdsc_sel)) )
         {
            AddWhere(sWhereString, "(T1.[ConEntDsc] = @AV74Bancos_conceptoentregarendirwwds_18_tfconentdsc_sel)");
         }
         else
         {
            GXv_int7[15] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV76Bancos_conceptoentregarendirwwds_20_tfcuecod_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV75Bancos_conceptoentregarendirwwds_19_tfcuecod)) ) )
         {
            AddWhere(sWhereString, "(T1.[CueCod] like @lV75Bancos_conceptoentregarendirwwds_19_tfcuecod)");
         }
         else
         {
            GXv_int7[16] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV76Bancos_conceptoentregarendirwwds_20_tfcuecod_sel)) )
         {
            AddWhere(sWhereString, "(T1.[CueCod] = @AV76Bancos_conceptoentregarendirwwds_20_tfcuecod_sel)");
         }
         else
         {
            GXv_int7[17] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV78Bancos_conceptoentregarendirwwds_22_tfcuedsc_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV77Bancos_conceptoentregarendirwwds_21_tfcuedsc)) ) )
         {
            AddWhere(sWhereString, "(T2.[CueDsc] like @lV77Bancos_conceptoentregarendirwwds_21_tfcuedsc)");
         }
         else
         {
            GXv_int7[18] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV78Bancos_conceptoentregarendirwwds_22_tfcuedsc_sel)) )
         {
            AddWhere(sWhereString, "(T2.[CueDsc] = @AV78Bancos_conceptoentregarendirwwds_22_tfcuedsc_sel)");
         }
         else
         {
            GXv_int7[19] = 1;
         }
         if ( AV79Bancos_conceptoentregarendirwwds_23_tfconentsts_sels_Count > 0 )
         {
            AddWhere(sWhereString, "("+new GxDbmsUtils( new GxSqlServer()).ValueList(AV79Bancos_conceptoentregarendirwwds_23_tfconentsts_sels, "T1.[ConEntSts] IN (", ")")+")");
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
                     return conditional_H00242(context, (short)dynConstraints[0] , (GxSimpleCollection<short>)dynConstraints[1] , (string)dynConstraints[2] , (short)dynConstraints[3] , (string)dynConstraints[4] , (string)dynConstraints[5] , (bool)dynConstraints[6] , (string)dynConstraints[7] , (short)dynConstraints[8] , (string)dynConstraints[9] , (string)dynConstraints[10] , (bool)dynConstraints[11] , (string)dynConstraints[12] , (short)dynConstraints[13] , (string)dynConstraints[14] , (string)dynConstraints[15] , (int)dynConstraints[16] , (int)dynConstraints[17] , (string)dynConstraints[18] , (string)dynConstraints[19] , (string)dynConstraints[20] , (string)dynConstraints[21] , (string)dynConstraints[22] , (string)dynConstraints[23] , (int)dynConstraints[24] , (string)dynConstraints[25] , (string)dynConstraints[26] , (int)dynConstraints[27] , (string)dynConstraints[28] , (short)dynConstraints[29] , (bool)dynConstraints[30] );
               case 1 :
                     return conditional_H00243(context, (short)dynConstraints[0] , (GxSimpleCollection<short>)dynConstraints[1] , (string)dynConstraints[2] , (short)dynConstraints[3] , (string)dynConstraints[4] , (string)dynConstraints[5] , (bool)dynConstraints[6] , (string)dynConstraints[7] , (short)dynConstraints[8] , (string)dynConstraints[9] , (string)dynConstraints[10] , (bool)dynConstraints[11] , (string)dynConstraints[12] , (short)dynConstraints[13] , (string)dynConstraints[14] , (string)dynConstraints[15] , (int)dynConstraints[16] , (int)dynConstraints[17] , (string)dynConstraints[18] , (string)dynConstraints[19] , (string)dynConstraints[20] , (string)dynConstraints[21] , (string)dynConstraints[22] , (string)dynConstraints[23] , (int)dynConstraints[24] , (string)dynConstraints[25] , (string)dynConstraints[26] , (int)dynConstraints[27] , (string)dynConstraints[28] , (short)dynConstraints[29] , (bool)dynConstraints[30] );
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
          Object[] prmH00242;
          prmH00242 = new Object[] {
          new ParDef("@lV59Bancos_conceptoentregarendirwwds_3_conentdsc1",GXType.NChar,100,0) ,
          new ParDef("@lV59Bancos_conceptoentregarendirwwds_3_conentdsc1",GXType.NChar,100,0) ,
          new ParDef("@lV60Bancos_conceptoentregarendirwwds_4_cuecod1",GXType.NChar,15,0) ,
          new ParDef("@lV60Bancos_conceptoentregarendirwwds_4_cuecod1",GXType.NChar,15,0) ,
          new ParDef("@lV64Bancos_conceptoentregarendirwwds_8_conentdsc2",GXType.NChar,100,0) ,
          new ParDef("@lV64Bancos_conceptoentregarendirwwds_8_conentdsc2",GXType.NChar,100,0) ,
          new ParDef("@lV65Bancos_conceptoentregarendirwwds_9_cuecod2",GXType.NChar,15,0) ,
          new ParDef("@lV65Bancos_conceptoentregarendirwwds_9_cuecod2",GXType.NChar,15,0) ,
          new ParDef("@lV69Bancos_conceptoentregarendirwwds_13_conentdsc3",GXType.NChar,100,0) ,
          new ParDef("@lV69Bancos_conceptoentregarendirwwds_13_conentdsc3",GXType.NChar,100,0) ,
          new ParDef("@lV70Bancos_conceptoentregarendirwwds_14_cuecod3",GXType.NChar,15,0) ,
          new ParDef("@lV70Bancos_conceptoentregarendirwwds_14_cuecod3",GXType.NChar,15,0) ,
          new ParDef("@AV71Bancos_conceptoentregarendirwwds_15_tfconentcod",GXType.Int32,6,0) ,
          new ParDef("@AV72Bancos_conceptoentregarendirwwds_16_tfconentcod_to",GXType.Int32,6,0) ,
          new ParDef("@lV73Bancos_conceptoentregarendirwwds_17_tfconentdsc",GXType.NChar,100,0) ,
          new ParDef("@AV74Bancos_conceptoentregarendirwwds_18_tfconentdsc_sel",GXType.NChar,100,0) ,
          new ParDef("@lV75Bancos_conceptoentregarendirwwds_19_tfcuecod",GXType.NChar,15,0) ,
          new ParDef("@AV76Bancos_conceptoentregarendirwwds_20_tfcuecod_sel",GXType.NChar,15,0) ,
          new ParDef("@lV77Bancos_conceptoentregarendirwwds_21_tfcuedsc",GXType.NChar,100,0) ,
          new ParDef("@AV78Bancos_conceptoentregarendirwwds_22_tfcuedsc_sel",GXType.NChar,100,0) ,
          new ParDef("@GXPagingFrom2",GXType.Int32,9,0) ,
          new ParDef("@GXPagingTo2",GXType.Int32,9,0) ,
          new ParDef("@GXPagingTo2",GXType.Int32,9,0)
          };
          Object[] prmH00243;
          prmH00243 = new Object[] {
          new ParDef("@lV59Bancos_conceptoentregarendirwwds_3_conentdsc1",GXType.NChar,100,0) ,
          new ParDef("@lV59Bancos_conceptoentregarendirwwds_3_conentdsc1",GXType.NChar,100,0) ,
          new ParDef("@lV60Bancos_conceptoentregarendirwwds_4_cuecod1",GXType.NChar,15,0) ,
          new ParDef("@lV60Bancos_conceptoentregarendirwwds_4_cuecod1",GXType.NChar,15,0) ,
          new ParDef("@lV64Bancos_conceptoentregarendirwwds_8_conentdsc2",GXType.NChar,100,0) ,
          new ParDef("@lV64Bancos_conceptoentregarendirwwds_8_conentdsc2",GXType.NChar,100,0) ,
          new ParDef("@lV65Bancos_conceptoentregarendirwwds_9_cuecod2",GXType.NChar,15,0) ,
          new ParDef("@lV65Bancos_conceptoentregarendirwwds_9_cuecod2",GXType.NChar,15,0) ,
          new ParDef("@lV69Bancos_conceptoentregarendirwwds_13_conentdsc3",GXType.NChar,100,0) ,
          new ParDef("@lV69Bancos_conceptoentregarendirwwds_13_conentdsc3",GXType.NChar,100,0) ,
          new ParDef("@lV70Bancos_conceptoentregarendirwwds_14_cuecod3",GXType.NChar,15,0) ,
          new ParDef("@lV70Bancos_conceptoentregarendirwwds_14_cuecod3",GXType.NChar,15,0) ,
          new ParDef("@AV71Bancos_conceptoentregarendirwwds_15_tfconentcod",GXType.Int32,6,0) ,
          new ParDef("@AV72Bancos_conceptoentregarendirwwds_16_tfconentcod_to",GXType.Int32,6,0) ,
          new ParDef("@lV73Bancos_conceptoentregarendirwwds_17_tfconentdsc",GXType.NChar,100,0) ,
          new ParDef("@AV74Bancos_conceptoentregarendirwwds_18_tfconentdsc_sel",GXType.NChar,100,0) ,
          new ParDef("@lV75Bancos_conceptoentregarendirwwds_19_tfcuecod",GXType.NChar,15,0) ,
          new ParDef("@AV76Bancos_conceptoentregarendirwwds_20_tfcuecod_sel",GXType.NChar,15,0) ,
          new ParDef("@lV77Bancos_conceptoentregarendirwwds_21_tfcuedsc",GXType.NChar,100,0) ,
          new ParDef("@AV78Bancos_conceptoentregarendirwwds_22_tfcuedsc_sel",GXType.NChar,100,0)
          };
          def= new CursorDef[] {
              new CursorDef("H00242", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH00242,11, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("H00243", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH00243,1, GxCacheFrequency.OFF ,true,false )
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
                ((string[]) buf[2])[0] = rslt.getString(3, 15);
                ((string[]) buf[3])[0] = rslt.getString(4, 100);
                ((int[]) buf[4])[0] = rslt.getInt(5);
                return;
             case 1 :
                ((long[]) buf[0])[0] = rslt.getLong(1);
                return;
       }
    }

 }

}
