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
namespace GeneXus.Programs.configuracion {
   public class movimientoventaww : GXDataArea
   {
      public movimientoventaww( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDataStore2 = context.GetDataStore("DataStore2");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusTheme");
      }

      public movimientoventaww( IGxContext context )
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
         cmbavMovvtip1 = new GXCombobox();
         cmbavDynamicfiltersselector2 = new GXCombobox();
         cmbavDynamicfiltersoperator2 = new GXCombobox();
         cmbavMovvtip2 = new GXCombobox();
         cmbavDynamicfiltersselector3 = new GXCombobox();
         cmbavDynamicfiltersoperator3 = new GXCombobox();
         cmbavMovvtip3 = new GXCombobox();
         cmbavGridactions = new GXCombobox();
         cmbMovVTip = new GXCombobox();
         cmbMovVSts = new GXCombobox();
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
               AV17MovVDsc1 = GetPar( "MovVDsc1");
               cmbavMovvtip1.FromJSonString( GetNextPar( ));
               AV49MovVTip1 = GetPar( "MovVTip1");
               cmbavDynamicfiltersselector2.FromJSonString( GetNextPar( ));
               AV19DynamicFiltersSelector2 = GetPar( "DynamicFiltersSelector2");
               cmbavDynamicfiltersoperator2.FromJSonString( GetNextPar( ));
               AV20DynamicFiltersOperator2 = (short)(NumberUtil.Val( GetPar( "DynamicFiltersOperator2"), "."));
               AV21MovVDsc2 = GetPar( "MovVDsc2");
               cmbavMovvtip2.FromJSonString( GetNextPar( ));
               AV50MovVTip2 = GetPar( "MovVTip2");
               cmbavDynamicfiltersselector3.FromJSonString( GetNextPar( ));
               AV23DynamicFiltersSelector3 = GetPar( "DynamicFiltersSelector3");
               cmbavDynamicfiltersoperator3.FromJSonString( GetNextPar( ));
               AV24DynamicFiltersOperator3 = (short)(NumberUtil.Val( GetPar( "DynamicFiltersOperator3"), "."));
               AV25MovVDsc3 = GetPar( "MovVDsc3");
               cmbavMovvtip3.FromJSonString( GetNextPar( ));
               AV51MovVTip3 = GetPar( "MovVTip3");
               AV54Pgmname = GetPar( "Pgmname");
               AV18DynamicFiltersEnabled2 = StringUtil.StrToBool( GetPar( "DynamicFiltersEnabled2"));
               AV22DynamicFiltersEnabled3 = StringUtil.StrToBool( GetPar( "DynamicFiltersEnabled3"));
               AV31TFMovVCod = (int)(NumberUtil.Val( GetPar( "TFMovVCod"), "."));
               AV32TFMovVCod_To = (int)(NumberUtil.Val( GetPar( "TFMovVCod_To"), "."));
               AV33TFMovVDsc = GetPar( "TFMovVDsc");
               AV34TFMovVDsc_Sel = GetPar( "TFMovVDsc_Sel");
               ajax_req_read_hidden_sdt(GetNextPar( ), AV36TFMovVAbr_Sels);
               ajax_req_read_hidden_sdt(GetNextPar( ), AV38TFMovVTip_Sels);
               ajax_req_read_hidden_sdt(GetNextPar( ), AV40TFMovVSts_Sels);
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
               gxgrGrid_refresh( subGrid_Rows, AV15DynamicFiltersSelector1, AV16DynamicFiltersOperator1, AV17MovVDsc1, AV49MovVTip1, AV19DynamicFiltersSelector2, AV20DynamicFiltersOperator2, AV21MovVDsc2, AV50MovVTip2, AV23DynamicFiltersSelector3, AV24DynamicFiltersOperator3, AV25MovVDsc3, AV51MovVTip3, AV54Pgmname, AV18DynamicFiltersEnabled2, AV22DynamicFiltersEnabled3, AV31TFMovVCod, AV32TFMovVCod_To, AV33TFMovVDsc, AV34TFMovVDsc_Sel, AV36TFMovVAbr_Sels, AV38TFMovVTip_Sels, AV40TFMovVSts_Sels, AV13OrderedBy, AV14OrderedDsc, AV10GridState, AV27DynamicFiltersIgnoreFirst, AV26DynamicFiltersRemoving) ;
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
         PA1F2( ) ;
         gxajaxcallmode = (short)((isAjaxCallMode( ) ? 1 : 0));
         if ( ( gxajaxcallmode == 0 ) && ( GxWebError == 0 ) )
         {
            START1F2( ) ;
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
         context.AddJavascriptSource("gxcfg.js", "?202281810285946", false, true);
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
         context.WriteHtmlTextNl( "<form id=\"MAINFORM\" autocomplete=\"off\" name=\"MAINFORM\" method=\"post\" tabindex=-1  class=\"form-horizontal Form\" data-gx-class=\"form-horizontal Form\" novalidate action=\""+formatLink("configuracion.movimientoventaww.aspx") +"\">") ;
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
         GxWebStd.gx_hidden_field( context, "GXH_vMOVVDSC1", StringUtil.RTrim( AV17MovVDsc1));
         GxWebStd.gx_hidden_field( context, "GXH_vMOVVTIP1", StringUtil.RTrim( AV49MovVTip1));
         GxWebStd.gx_hidden_field( context, "GXH_vDYNAMICFILTERSSELECTOR2", AV19DynamicFiltersSelector2);
         GxWebStd.gx_hidden_field( context, "GXH_vDYNAMICFILTERSOPERATOR2", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV20DynamicFiltersOperator2), 4, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "GXH_vMOVVDSC2", StringUtil.RTrim( AV21MovVDsc2));
         GxWebStd.gx_hidden_field( context, "GXH_vMOVVTIP2", StringUtil.RTrim( AV50MovVTip2));
         GxWebStd.gx_hidden_field( context, "GXH_vDYNAMICFILTERSSELECTOR3", AV23DynamicFiltersSelector3);
         GxWebStd.gx_hidden_field( context, "GXH_vDYNAMICFILTERSOPERATOR3", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV24DynamicFiltersOperator3), 4, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "GXH_vMOVVDSC3", StringUtil.RTrim( AV25MovVDsc3));
         GxWebStd.gx_hidden_field( context, "GXH_vMOVVTIP3", StringUtil.RTrim( AV51MovVTip3));
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
         GxWebStd.gx_hidden_field( context, "vPGMNAME", StringUtil.RTrim( AV54Pgmname));
         GxWebStd.gx_hidden_field( context, "gxhash_vPGMNAME", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( AV54Pgmname, "")), context));
         GxWebStd.gx_boolean_hidden_field( context, "vDYNAMICFILTERSENABLED2", AV18DynamicFiltersEnabled2);
         GxWebStd.gx_boolean_hidden_field( context, "vDYNAMICFILTERSENABLED3", AV22DynamicFiltersEnabled3);
         GxWebStd.gx_hidden_field( context, "vTFMOVVCOD", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV31TFMovVCod), 6, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "vTFMOVVCOD_TO", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV32TFMovVCod_To), 6, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "vTFMOVVDSC", StringUtil.RTrim( AV33TFMovVDsc));
         GxWebStd.gx_hidden_field( context, "vTFMOVVDSC_SEL", StringUtil.RTrim( AV34TFMovVDsc_Sel));
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "vTFMOVVABR_SELS", AV36TFMovVAbr_Sels);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt("vTFMOVVABR_SELS", AV36TFMovVAbr_Sels);
         }
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "vTFMOVVTIP_SELS", AV38TFMovVTip_Sels);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt("vTFMOVVTIP_SELS", AV38TFMovVTip_Sels);
         }
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "vTFMOVVSTS_SELS", AV40TFMovVSts_Sels);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt("vTFMOVVSTS_SELS", AV40TFMovVSts_Sels);
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
         GxWebStd.gx_hidden_field( context, "vTFMOVVABR_SELSJSON", AV35TFMovVAbr_SelsJson);
         GxWebStd.gx_hidden_field( context, "vTFMOVVTIP_SELSJSON", AV37TFMovVTip_SelsJson);
         GxWebStd.gx_hidden_field( context, "vTFMOVVSTS_SELSJSON", AV39TFMovVSts_SelsJson);
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
            WE1F2( ) ;
            context.WriteHtmlText( "</div>") ;
         }
      }

      public override void DispatchEvents( )
      {
         EVT1F2( ) ;
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
         return formatLink("configuracion.movimientoventaww.aspx")  ;
      }

      public override string GetPgmname( )
      {
         return "Configuracion.MovimientoVentaWW" ;
      }

      public override string GetPgmdesc( )
      {
         return " Movimientos de Credito / Debito" ;
      }

      protected void WB1F0( )
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
            GxWebStd.gx_button_ctrl( context, bttBtninsert_Internalname, "gx.evt.setGridEvt("+StringUtil.Str( (decimal)(110), 3, 0)+","+"null"+");", "Agregar", bttBtninsert_Jsonclick, 5, "Agregar", "", StyleString, ClassString, 1, 1, "standard", "'"+""+"'"+",false,"+"'"+"E\\'DOINSERT\\'."+"'", TempTags, "", context.GetButtonType( ), "HLP_Configuracion\\MovimientoVentaWW.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "left", "top", "", "", "div");
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 21,'',false,'',0)\"";
            ClassString = "ColumnsSelector";
            StyleString = "";
            GxWebStd.gx_button_ctrl( context, bttBtnagexport_Internalname, "gx.evt.setGridEvt("+StringUtil.Str( (decimal)(110), 3, 0)+","+"null"+");", "Reportes", bttBtnagexport_Jsonclick, 0, "Reportes", "", StyleString, ClassString, 1, 0, "standard", "'"+""+"'"+",false,"+"'"+""+"'", TempTags, "", context.GetButtonType( ), "HLP_Configuracion\\MovimientoVentaWW.htm");
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
            wb_table1_25_1F2( true) ;
         }
         else
         {
            wb_table1_25_1F2( false) ;
         }
         return  ;
      }

      protected void wb_table1_25_1F2e( bool wbgen )
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
               context.SendWebValue( "Movimiento de Venta") ;
               context.WriteHtmlTextNl( "</th>") ;
               context.WriteHtmlText( "<th align=\""+"left"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+""+""+"\" "+">") ;
               context.SendWebValue( "Afecta Unidades") ;
               context.WriteHtmlTextNl( "</th>") ;
               context.WriteHtmlText( "<th align=\""+"left"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+""+""+"\" "+">") ;
               context.SendWebValue( "Cargo / Abono") ;
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
               GridColumn.AddObjectProperty("Value", StringUtil.LTrim( StringUtil.NToC( (decimal)(A235MovVCod), 6, 0, ".", "")));
               GridContainer.AddColumnProperties(GridColumn);
               GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
               GridColumn.AddObjectProperty("Value", StringUtil.RTrim( A1243MovVDsc));
               GridColumn.AddObjectProperty("Link", StringUtil.RTrim( edtMovVDsc_Link));
               GridContainer.AddColumnProperties(GridColumn);
               GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
               GridColumn.AddObjectProperty("Value", StringUtil.RTrim( A1242MovVAbr));
               GridContainer.AddColumnProperties(GridColumn);
               GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
               GridColumn.AddObjectProperty("Value", StringUtil.RTrim( A1245MovVTip));
               GridContainer.AddColumnProperties(GridColumn);
               GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
               GridColumn.AddObjectProperty("Value", StringUtil.LTrim( StringUtil.NToC( (decimal)(A1244MovVSts), 1, 0, ".", "")));
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
            GxWebStd.gx_label_ctrl( context, lblJsdynamicfilters_Internalname, lblJsdynamicfilters_Caption, "", "", lblJsdynamicfilters_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "", 0, "", 1, 1, 0, 1, "HLP_Configuracion\\MovimientoVentaWW.htm");
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

      protected void START1F2( )
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
            Form.Meta.addItem("description", " Movimientos de Credito / Debito", 0) ;
         }
         context.wjLoc = "";
         context.nUserReturn = 0;
         context.wbHandled = 0;
         if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
         {
         }
         wbErr = false;
         STRUP1F0( ) ;
      }

      protected void WS1F2( )
      {
         START1F2( ) ;
         EVT1F2( ) ;
      }

      protected void EVT1F2( )
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
                              E111F2 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "GRIDPAGINATIONBAR.CHANGEROWSPERPAGE") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              E121F2 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "DDO_AGEXPORT.ONOPTIONCLICKED") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              E131F2 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "DDO_GRID.ONOPTIONCLICKED") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              E141F2 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "'REMOVEDYNAMICFILTERS1'") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              /* Execute user event: 'RemoveDynamicFilters1' */
                              E151F2 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "'REMOVEDYNAMICFILTERS2'") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              /* Execute user event: 'RemoveDynamicFilters2' */
                              E161F2 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "'REMOVEDYNAMICFILTERS3'") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              /* Execute user event: 'RemoveDynamicFilters3' */
                              E171F2 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "'DOINSERT'") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              /* Execute user event: 'DoInsert' */
                              E181F2 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "'ADDDYNAMICFILTERS1'") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              /* Execute user event: 'AddDynamicFilters1' */
                              E191F2 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "VDYNAMICFILTERSSELECTOR1.CLICK") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              E201F2 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "'ADDDYNAMICFILTERS2'") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              /* Execute user event: 'AddDynamicFilters2' */
                              E211F2 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "VDYNAMICFILTERSSELECTOR2.CLICK") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              E221F2 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "VDYNAMICFILTERSSELECTOR3.CLICK") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              E231F2 ();
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
                              A235MovVCod = (int)(context.localUtil.CToN( cgiGet( edtMovVCod_Internalname), ".", ","));
                              A1243MovVDsc = cgiGet( edtMovVDsc_Internalname);
                              A1242MovVAbr = cgiGet( edtMovVAbr_Internalname);
                              cmbMovVTip.Name = cmbMovVTip_Internalname;
                              cmbMovVTip.CurrentValue = cgiGet( cmbMovVTip_Internalname);
                              A1245MovVTip = cgiGet( cmbMovVTip_Internalname);
                              cmbMovVSts.Name = cmbMovVSts_Internalname;
                              cmbMovVSts.CurrentValue = cgiGet( cmbMovVSts_Internalname);
                              A1244MovVSts = (short)(NumberUtil.Val( cgiGet( cmbMovVSts_Internalname), "."));
                              sEvtType = StringUtil.Right( sEvt, 1);
                              if ( StringUtil.StrCmp(sEvtType, ".") == 0 )
                              {
                                 sEvt = StringUtil.Left( sEvt, (short)(StringUtil.Len( sEvt)-1));
                                 if ( StringUtil.StrCmp(sEvt, "START") == 0 )
                                 {
                                    context.wbHandled = 1;
                                    dynload_actions( ) ;
                                    /* Execute user event: Start */
                                    E241F2 ();
                                 }
                                 else if ( StringUtil.StrCmp(sEvt, "REFRESH") == 0 )
                                 {
                                    context.wbHandled = 1;
                                    dynload_actions( ) ;
                                    /* Execute user event: Refresh */
                                    E251F2 ();
                                 }
                                 else if ( StringUtil.StrCmp(sEvt, "GRID.LOAD") == 0 )
                                 {
                                    context.wbHandled = 1;
                                    dynload_actions( ) ;
                                    E261F2 ();
                                 }
                                 else if ( StringUtil.StrCmp(sEvt, "VGRIDACTIONS.CLICK") == 0 )
                                 {
                                    context.wbHandled = 1;
                                    dynload_actions( ) ;
                                    E271F2 ();
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
                                       /* Set Refresh If Movvdsc1 Changed */
                                       if ( StringUtil.StrCmp(cgiGet( "GXH_vMOVVDSC1"), AV17MovVDsc1) != 0 )
                                       {
                                          Rfr0gs = true;
                                       }
                                       /* Set Refresh If Movvtip1 Changed */
                                       if ( StringUtil.StrCmp(cgiGet( "GXH_vMOVVTIP1"), AV49MovVTip1) != 0 )
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
                                       /* Set Refresh If Movvdsc2 Changed */
                                       if ( StringUtil.StrCmp(cgiGet( "GXH_vMOVVDSC2"), AV21MovVDsc2) != 0 )
                                       {
                                          Rfr0gs = true;
                                       }
                                       /* Set Refresh If Movvtip2 Changed */
                                       if ( StringUtil.StrCmp(cgiGet( "GXH_vMOVVTIP2"), AV50MovVTip2) != 0 )
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
                                       /* Set Refresh If Movvdsc3 Changed */
                                       if ( StringUtil.StrCmp(cgiGet( "GXH_vMOVVDSC3"), AV25MovVDsc3) != 0 )
                                       {
                                          Rfr0gs = true;
                                       }
                                       /* Set Refresh If Movvtip3 Changed */
                                       if ( StringUtil.StrCmp(cgiGet( "GXH_vMOVVTIP3"), AV51MovVTip3) != 0 )
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

      protected void WE1F2( )
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

      protected void PA1F2( )
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
                                       string AV17MovVDsc1 ,
                                       string AV49MovVTip1 ,
                                       string AV19DynamicFiltersSelector2 ,
                                       short AV20DynamicFiltersOperator2 ,
                                       string AV21MovVDsc2 ,
                                       string AV50MovVTip2 ,
                                       string AV23DynamicFiltersSelector3 ,
                                       short AV24DynamicFiltersOperator3 ,
                                       string AV25MovVDsc3 ,
                                       string AV51MovVTip3 ,
                                       string AV54Pgmname ,
                                       bool AV18DynamicFiltersEnabled2 ,
                                       bool AV22DynamicFiltersEnabled3 ,
                                       int AV31TFMovVCod ,
                                       int AV32TFMovVCod_To ,
                                       string AV33TFMovVDsc ,
                                       string AV34TFMovVDsc_Sel ,
                                       GxSimpleCollection<string> AV36TFMovVAbr_Sels ,
                                       GxSimpleCollection<string> AV38TFMovVTip_Sels ,
                                       GxSimpleCollection<short> AV40TFMovVSts_Sels ,
                                       short AV13OrderedBy ,
                                       bool AV14OrderedDsc ,
                                       GeneXus.Programs.wwpbaseobjects.SdtWWPGridState AV10GridState ,
                                       bool AV27DynamicFiltersIgnoreFirst ,
                                       bool AV26DynamicFiltersRemoving )
      {
         initialize_formulas( ) ;
         GxWebStd.set_html_headers( context, 0, "", "");
         /* Execute user event: Refresh */
         E251F2 ();
         GRID_nCurrentRecord = 0;
         RF1F2( ) ;
         GXKey = Crypto.GetSiteKey( );
         send_integrity_footer_hashes( ) ;
         GXKey = Crypto.GetSiteKey( );
         /* End function gxgrGrid_refresh */
      }

      protected void send_integrity_hashes( )
      {
         GxWebStd.gx_hidden_field( context, "gxhash_MOVVCOD", GetSecureSignedToken( "", context.localUtil.Format( (decimal)(A235MovVCod), "ZZZZZ9"), context));
         GxWebStd.gx_hidden_field( context, "MOVVCOD", StringUtil.LTrim( StringUtil.NToC( (decimal)(A235MovVCod), 6, 0, ".", "")));
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
         if ( cmbavMovvtip1.ItemCount > 0 )
         {
            AV49MovVTip1 = cmbavMovvtip1.getValidValue(AV49MovVTip1);
            AssignAttri("", false, "AV49MovVTip1", AV49MovVTip1);
         }
         if ( context.isAjaxRequest( ) )
         {
            cmbavMovvtip1.CurrentValue = StringUtil.RTrim( AV49MovVTip1);
            AssignProp("", false, cmbavMovvtip1_Internalname, "Values", cmbavMovvtip1.ToJavascriptSource(), true);
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
         if ( cmbavMovvtip2.ItemCount > 0 )
         {
            AV50MovVTip2 = cmbavMovvtip2.getValidValue(AV50MovVTip2);
            AssignAttri("", false, "AV50MovVTip2", AV50MovVTip2);
         }
         if ( context.isAjaxRequest( ) )
         {
            cmbavMovvtip2.CurrentValue = StringUtil.RTrim( AV50MovVTip2);
            AssignProp("", false, cmbavMovvtip2_Internalname, "Values", cmbavMovvtip2.ToJavascriptSource(), true);
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
         if ( cmbavMovvtip3.ItemCount > 0 )
         {
            AV51MovVTip3 = cmbavMovvtip3.getValidValue(AV51MovVTip3);
            AssignAttri("", false, "AV51MovVTip3", AV51MovVTip3);
         }
         if ( context.isAjaxRequest( ) )
         {
            cmbavMovvtip3.CurrentValue = StringUtil.RTrim( AV51MovVTip3);
            AssignProp("", false, cmbavMovvtip3_Internalname, "Values", cmbavMovvtip3.ToJavascriptSource(), true);
         }
      }

      public void Refresh( )
      {
         send_integrity_hashes( ) ;
         RF1F2( ) ;
         if ( isFullAjaxMode( ) )
         {
            send_integrity_footer_hashes( ) ;
         }
      }

      protected void initialize_formulas( )
      {
         /* GeneXus formulas. */
         AV54Pgmname = "Configuracion.MovimientoVentaWW";
         context.Gx_err = 0;
      }

      protected void RF1F2( )
      {
         initialize_formulas( ) ;
         clear_multi_value_controls( ) ;
         if ( isAjaxCallMode( ) )
         {
            GridContainer.ClearRows();
         }
         wbStart = 110;
         /* Execute user event: Refresh */
         E251F2 ();
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
                                                 A1242MovVAbr ,
                                                 AV73Configuracion_movimientoventawwds_19_tfmovvabr_sels ,
                                                 A1245MovVTip ,
                                                 AV74Configuracion_movimientoventawwds_20_tfmovvtip_sels ,
                                                 A1244MovVSts ,
                                                 AV75Configuracion_movimientoventawwds_21_tfmovvsts_sels ,
                                                 AV55Configuracion_movimientoventawwds_1_dynamicfiltersselector1 ,
                                                 AV56Configuracion_movimientoventawwds_2_dynamicfiltersoperator1 ,
                                                 AV57Configuracion_movimientoventawwds_3_movvdsc1 ,
                                                 AV58Configuracion_movimientoventawwds_4_movvtip1 ,
                                                 AV59Configuracion_movimientoventawwds_5_dynamicfiltersenabled2 ,
                                                 AV60Configuracion_movimientoventawwds_6_dynamicfiltersselector2 ,
                                                 AV61Configuracion_movimientoventawwds_7_dynamicfiltersoperator2 ,
                                                 AV62Configuracion_movimientoventawwds_8_movvdsc2 ,
                                                 AV63Configuracion_movimientoventawwds_9_movvtip2 ,
                                                 AV64Configuracion_movimientoventawwds_10_dynamicfiltersenabled3 ,
                                                 AV65Configuracion_movimientoventawwds_11_dynamicfiltersselector3 ,
                                                 AV66Configuracion_movimientoventawwds_12_dynamicfiltersoperator3 ,
                                                 AV67Configuracion_movimientoventawwds_13_movvdsc3 ,
                                                 AV68Configuracion_movimientoventawwds_14_movvtip3 ,
                                                 AV69Configuracion_movimientoventawwds_15_tfmovvcod ,
                                                 AV70Configuracion_movimientoventawwds_16_tfmovvcod_to ,
                                                 AV72Configuracion_movimientoventawwds_18_tfmovvdsc_sel ,
                                                 AV71Configuracion_movimientoventawwds_17_tfmovvdsc ,
                                                 AV73Configuracion_movimientoventawwds_19_tfmovvabr_sels.Count ,
                                                 AV74Configuracion_movimientoventawwds_20_tfmovvtip_sels.Count ,
                                                 AV75Configuracion_movimientoventawwds_21_tfmovvsts_sels.Count ,
                                                 A1243MovVDsc ,
                                                 A235MovVCod ,
                                                 AV13OrderedBy ,
                                                 AV14OrderedDsc } ,
                                                 new int[]{
                                                 TypeConstants.SHORT, TypeConstants.SHORT, TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.INT, TypeConstants.INT, TypeConstants.INT, TypeConstants.INT,
                                                 TypeConstants.INT, TypeConstants.INT, TypeConstants.SHORT, TypeConstants.BOOLEAN
                                                 }
            });
            lV57Configuracion_movimientoventawwds_3_movvdsc1 = StringUtil.PadR( StringUtil.RTrim( AV57Configuracion_movimientoventawwds_3_movvdsc1), 100, "%");
            lV57Configuracion_movimientoventawwds_3_movvdsc1 = StringUtil.PadR( StringUtil.RTrim( AV57Configuracion_movimientoventawwds_3_movvdsc1), 100, "%");
            lV62Configuracion_movimientoventawwds_8_movvdsc2 = StringUtil.PadR( StringUtil.RTrim( AV62Configuracion_movimientoventawwds_8_movvdsc2), 100, "%");
            lV62Configuracion_movimientoventawwds_8_movvdsc2 = StringUtil.PadR( StringUtil.RTrim( AV62Configuracion_movimientoventawwds_8_movvdsc2), 100, "%");
            lV67Configuracion_movimientoventawwds_13_movvdsc3 = StringUtil.PadR( StringUtil.RTrim( AV67Configuracion_movimientoventawwds_13_movvdsc3), 100, "%");
            lV67Configuracion_movimientoventawwds_13_movvdsc3 = StringUtil.PadR( StringUtil.RTrim( AV67Configuracion_movimientoventawwds_13_movvdsc3), 100, "%");
            lV71Configuracion_movimientoventawwds_17_tfmovvdsc = StringUtil.PadR( StringUtil.RTrim( AV71Configuracion_movimientoventawwds_17_tfmovvdsc), 100, "%");
            /* Using cursor H001F2 */
            pr_default.execute(0, new Object[] {lV57Configuracion_movimientoventawwds_3_movvdsc1, lV57Configuracion_movimientoventawwds_3_movvdsc1, AV58Configuracion_movimientoventawwds_4_movvtip1, lV62Configuracion_movimientoventawwds_8_movvdsc2, lV62Configuracion_movimientoventawwds_8_movvdsc2, AV63Configuracion_movimientoventawwds_9_movvtip2, lV67Configuracion_movimientoventawwds_13_movvdsc3, lV67Configuracion_movimientoventawwds_13_movvdsc3, AV68Configuracion_movimientoventawwds_14_movvtip3, AV69Configuracion_movimientoventawwds_15_tfmovvcod, AV70Configuracion_movimientoventawwds_16_tfmovvcod_to, lV71Configuracion_movimientoventawwds_17_tfmovvdsc, AV72Configuracion_movimientoventawwds_18_tfmovvdsc_sel, GXPagingFrom2, GXPagingTo2, GXPagingTo2});
            nGXsfl_110_idx = 1;
            sGXsfl_110_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_110_idx), 4, 0), 4, "0");
            SubsflControlProps_1102( ) ;
            while ( ( (pr_default.getStatus(0) != 101) ) && ( ( ( subGrid_Rows == 0 ) || ( GRID_nCurrentRecord < subGrid_fnc_Recordsperpage( ) ) ) ) )
            {
               A1244MovVSts = H001F2_A1244MovVSts[0];
               A1245MovVTip = H001F2_A1245MovVTip[0];
               A1242MovVAbr = H001F2_A1242MovVAbr[0];
               A1243MovVDsc = H001F2_A1243MovVDsc[0];
               A235MovVCod = H001F2_A235MovVCod[0];
               E261F2 ();
               pr_default.readNext(0);
            }
            GRID_nEOF = (short)(((pr_default.getStatus(0) == 101) ? 1 : 0));
            GxWebStd.gx_hidden_field( context, "GRID_nEOF", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRID_nEOF), 1, 0, ".", "")));
            pr_default.close(0);
            wbEnd = 110;
            WB1F0( ) ;
         }
         bGXsfl_110_Refreshing = true;
      }

      protected void send_integrity_lvl_hashes1F2( )
      {
         GxWebStd.gx_hidden_field( context, "vPGMNAME", StringUtil.RTrim( AV54Pgmname));
         GxWebStd.gx_hidden_field( context, "gxhash_vPGMNAME", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( AV54Pgmname, "")), context));
         GxWebStd.gx_hidden_field( context, "gxhash_MOVVCOD"+"_"+sGXsfl_110_idx, GetSecureSignedToken( sGXsfl_110_idx, context.localUtil.Format( (decimal)(A235MovVCod), "ZZZZZ9"), context));
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
         AV55Configuracion_movimientoventawwds_1_dynamicfiltersselector1 = AV15DynamicFiltersSelector1;
         AV56Configuracion_movimientoventawwds_2_dynamicfiltersoperator1 = AV16DynamicFiltersOperator1;
         AV57Configuracion_movimientoventawwds_3_movvdsc1 = AV17MovVDsc1;
         AV58Configuracion_movimientoventawwds_4_movvtip1 = AV49MovVTip1;
         AV59Configuracion_movimientoventawwds_5_dynamicfiltersenabled2 = AV18DynamicFiltersEnabled2;
         AV60Configuracion_movimientoventawwds_6_dynamicfiltersselector2 = AV19DynamicFiltersSelector2;
         AV61Configuracion_movimientoventawwds_7_dynamicfiltersoperator2 = AV20DynamicFiltersOperator2;
         AV62Configuracion_movimientoventawwds_8_movvdsc2 = AV21MovVDsc2;
         AV63Configuracion_movimientoventawwds_9_movvtip2 = AV50MovVTip2;
         AV64Configuracion_movimientoventawwds_10_dynamicfiltersenabled3 = AV22DynamicFiltersEnabled3;
         AV65Configuracion_movimientoventawwds_11_dynamicfiltersselector3 = AV23DynamicFiltersSelector3;
         AV66Configuracion_movimientoventawwds_12_dynamicfiltersoperator3 = AV24DynamicFiltersOperator3;
         AV67Configuracion_movimientoventawwds_13_movvdsc3 = AV25MovVDsc3;
         AV68Configuracion_movimientoventawwds_14_movvtip3 = AV51MovVTip3;
         AV69Configuracion_movimientoventawwds_15_tfmovvcod = AV31TFMovVCod;
         AV70Configuracion_movimientoventawwds_16_tfmovvcod_to = AV32TFMovVCod_To;
         AV71Configuracion_movimientoventawwds_17_tfmovvdsc = AV33TFMovVDsc;
         AV72Configuracion_movimientoventawwds_18_tfmovvdsc_sel = AV34TFMovVDsc_Sel;
         AV73Configuracion_movimientoventawwds_19_tfmovvabr_sels = AV36TFMovVAbr_Sels;
         AV74Configuracion_movimientoventawwds_20_tfmovvtip_sels = AV38TFMovVTip_Sels;
         AV75Configuracion_movimientoventawwds_21_tfmovvsts_sels = AV40TFMovVSts_Sels;
         pr_default.dynParam(1, new Object[]{ new Object[]{
                                              A1242MovVAbr ,
                                              AV73Configuracion_movimientoventawwds_19_tfmovvabr_sels ,
                                              A1245MovVTip ,
                                              AV74Configuracion_movimientoventawwds_20_tfmovvtip_sels ,
                                              A1244MovVSts ,
                                              AV75Configuracion_movimientoventawwds_21_tfmovvsts_sels ,
                                              AV55Configuracion_movimientoventawwds_1_dynamicfiltersselector1 ,
                                              AV56Configuracion_movimientoventawwds_2_dynamicfiltersoperator1 ,
                                              AV57Configuracion_movimientoventawwds_3_movvdsc1 ,
                                              AV58Configuracion_movimientoventawwds_4_movvtip1 ,
                                              AV59Configuracion_movimientoventawwds_5_dynamicfiltersenabled2 ,
                                              AV60Configuracion_movimientoventawwds_6_dynamicfiltersselector2 ,
                                              AV61Configuracion_movimientoventawwds_7_dynamicfiltersoperator2 ,
                                              AV62Configuracion_movimientoventawwds_8_movvdsc2 ,
                                              AV63Configuracion_movimientoventawwds_9_movvtip2 ,
                                              AV64Configuracion_movimientoventawwds_10_dynamicfiltersenabled3 ,
                                              AV65Configuracion_movimientoventawwds_11_dynamicfiltersselector3 ,
                                              AV66Configuracion_movimientoventawwds_12_dynamicfiltersoperator3 ,
                                              AV67Configuracion_movimientoventawwds_13_movvdsc3 ,
                                              AV68Configuracion_movimientoventawwds_14_movvtip3 ,
                                              AV69Configuracion_movimientoventawwds_15_tfmovvcod ,
                                              AV70Configuracion_movimientoventawwds_16_tfmovvcod_to ,
                                              AV72Configuracion_movimientoventawwds_18_tfmovvdsc_sel ,
                                              AV71Configuracion_movimientoventawwds_17_tfmovvdsc ,
                                              AV73Configuracion_movimientoventawwds_19_tfmovvabr_sels.Count ,
                                              AV74Configuracion_movimientoventawwds_20_tfmovvtip_sels.Count ,
                                              AV75Configuracion_movimientoventawwds_21_tfmovvsts_sels.Count ,
                                              A1243MovVDsc ,
                                              A235MovVCod ,
                                              AV13OrderedBy ,
                                              AV14OrderedDsc } ,
                                              new int[]{
                                              TypeConstants.SHORT, TypeConstants.SHORT, TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.INT, TypeConstants.INT, TypeConstants.INT, TypeConstants.INT,
                                              TypeConstants.INT, TypeConstants.INT, TypeConstants.SHORT, TypeConstants.BOOLEAN
                                              }
         });
         lV57Configuracion_movimientoventawwds_3_movvdsc1 = StringUtil.PadR( StringUtil.RTrim( AV57Configuracion_movimientoventawwds_3_movvdsc1), 100, "%");
         lV57Configuracion_movimientoventawwds_3_movvdsc1 = StringUtil.PadR( StringUtil.RTrim( AV57Configuracion_movimientoventawwds_3_movvdsc1), 100, "%");
         lV62Configuracion_movimientoventawwds_8_movvdsc2 = StringUtil.PadR( StringUtil.RTrim( AV62Configuracion_movimientoventawwds_8_movvdsc2), 100, "%");
         lV62Configuracion_movimientoventawwds_8_movvdsc2 = StringUtil.PadR( StringUtil.RTrim( AV62Configuracion_movimientoventawwds_8_movvdsc2), 100, "%");
         lV67Configuracion_movimientoventawwds_13_movvdsc3 = StringUtil.PadR( StringUtil.RTrim( AV67Configuracion_movimientoventawwds_13_movvdsc3), 100, "%");
         lV67Configuracion_movimientoventawwds_13_movvdsc3 = StringUtil.PadR( StringUtil.RTrim( AV67Configuracion_movimientoventawwds_13_movvdsc3), 100, "%");
         lV71Configuracion_movimientoventawwds_17_tfmovvdsc = StringUtil.PadR( StringUtil.RTrim( AV71Configuracion_movimientoventawwds_17_tfmovvdsc), 100, "%");
         /* Using cursor H001F3 */
         pr_default.execute(1, new Object[] {lV57Configuracion_movimientoventawwds_3_movvdsc1, lV57Configuracion_movimientoventawwds_3_movvdsc1, AV58Configuracion_movimientoventawwds_4_movvtip1, lV62Configuracion_movimientoventawwds_8_movvdsc2, lV62Configuracion_movimientoventawwds_8_movvdsc2, AV63Configuracion_movimientoventawwds_9_movvtip2, lV67Configuracion_movimientoventawwds_13_movvdsc3, lV67Configuracion_movimientoventawwds_13_movvdsc3, AV68Configuracion_movimientoventawwds_14_movvtip3, AV69Configuracion_movimientoventawwds_15_tfmovvcod, AV70Configuracion_movimientoventawwds_16_tfmovvcod_to, lV71Configuracion_movimientoventawwds_17_tfmovvdsc, AV72Configuracion_movimientoventawwds_18_tfmovvdsc_sel});
         GRID_nRecordCount = H001F3_AGRID_nRecordCount[0];
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
         AV55Configuracion_movimientoventawwds_1_dynamicfiltersselector1 = AV15DynamicFiltersSelector1;
         AV56Configuracion_movimientoventawwds_2_dynamicfiltersoperator1 = AV16DynamicFiltersOperator1;
         AV57Configuracion_movimientoventawwds_3_movvdsc1 = AV17MovVDsc1;
         AV58Configuracion_movimientoventawwds_4_movvtip1 = AV49MovVTip1;
         AV59Configuracion_movimientoventawwds_5_dynamicfiltersenabled2 = AV18DynamicFiltersEnabled2;
         AV60Configuracion_movimientoventawwds_6_dynamicfiltersselector2 = AV19DynamicFiltersSelector2;
         AV61Configuracion_movimientoventawwds_7_dynamicfiltersoperator2 = AV20DynamicFiltersOperator2;
         AV62Configuracion_movimientoventawwds_8_movvdsc2 = AV21MovVDsc2;
         AV63Configuracion_movimientoventawwds_9_movvtip2 = AV50MovVTip2;
         AV64Configuracion_movimientoventawwds_10_dynamicfiltersenabled3 = AV22DynamicFiltersEnabled3;
         AV65Configuracion_movimientoventawwds_11_dynamicfiltersselector3 = AV23DynamicFiltersSelector3;
         AV66Configuracion_movimientoventawwds_12_dynamicfiltersoperator3 = AV24DynamicFiltersOperator3;
         AV67Configuracion_movimientoventawwds_13_movvdsc3 = AV25MovVDsc3;
         AV68Configuracion_movimientoventawwds_14_movvtip3 = AV51MovVTip3;
         AV69Configuracion_movimientoventawwds_15_tfmovvcod = AV31TFMovVCod;
         AV70Configuracion_movimientoventawwds_16_tfmovvcod_to = AV32TFMovVCod_To;
         AV71Configuracion_movimientoventawwds_17_tfmovvdsc = AV33TFMovVDsc;
         AV72Configuracion_movimientoventawwds_18_tfmovvdsc_sel = AV34TFMovVDsc_Sel;
         AV73Configuracion_movimientoventawwds_19_tfmovvabr_sels = AV36TFMovVAbr_Sels;
         AV74Configuracion_movimientoventawwds_20_tfmovvtip_sels = AV38TFMovVTip_Sels;
         AV75Configuracion_movimientoventawwds_21_tfmovvsts_sels = AV40TFMovVSts_Sels;
         GRID_nFirstRecordOnPage = 0;
         GxWebStd.gx_hidden_field( context, "GRID_nFirstRecordOnPage", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRID_nFirstRecordOnPage), 15, 0, ".", "")));
         if ( isFullAjaxMode( ) )
         {
            gxgrGrid_refresh( subGrid_Rows, AV15DynamicFiltersSelector1, AV16DynamicFiltersOperator1, AV17MovVDsc1, AV49MovVTip1, AV19DynamicFiltersSelector2, AV20DynamicFiltersOperator2, AV21MovVDsc2, AV50MovVTip2, AV23DynamicFiltersSelector3, AV24DynamicFiltersOperator3, AV25MovVDsc3, AV51MovVTip3, AV54Pgmname, AV18DynamicFiltersEnabled2, AV22DynamicFiltersEnabled3, AV31TFMovVCod, AV32TFMovVCod_To, AV33TFMovVDsc, AV34TFMovVDsc_Sel, AV36TFMovVAbr_Sels, AV38TFMovVTip_Sels, AV40TFMovVSts_Sels, AV13OrderedBy, AV14OrderedDsc, AV10GridState, AV27DynamicFiltersIgnoreFirst, AV26DynamicFiltersRemoving) ;
         }
         send_integrity_footer_hashes( ) ;
         return 0 ;
      }

      protected short subgrid_nextpage( )
      {
         AV55Configuracion_movimientoventawwds_1_dynamicfiltersselector1 = AV15DynamicFiltersSelector1;
         AV56Configuracion_movimientoventawwds_2_dynamicfiltersoperator1 = AV16DynamicFiltersOperator1;
         AV57Configuracion_movimientoventawwds_3_movvdsc1 = AV17MovVDsc1;
         AV58Configuracion_movimientoventawwds_4_movvtip1 = AV49MovVTip1;
         AV59Configuracion_movimientoventawwds_5_dynamicfiltersenabled2 = AV18DynamicFiltersEnabled2;
         AV60Configuracion_movimientoventawwds_6_dynamicfiltersselector2 = AV19DynamicFiltersSelector2;
         AV61Configuracion_movimientoventawwds_7_dynamicfiltersoperator2 = AV20DynamicFiltersOperator2;
         AV62Configuracion_movimientoventawwds_8_movvdsc2 = AV21MovVDsc2;
         AV63Configuracion_movimientoventawwds_9_movvtip2 = AV50MovVTip2;
         AV64Configuracion_movimientoventawwds_10_dynamicfiltersenabled3 = AV22DynamicFiltersEnabled3;
         AV65Configuracion_movimientoventawwds_11_dynamicfiltersselector3 = AV23DynamicFiltersSelector3;
         AV66Configuracion_movimientoventawwds_12_dynamicfiltersoperator3 = AV24DynamicFiltersOperator3;
         AV67Configuracion_movimientoventawwds_13_movvdsc3 = AV25MovVDsc3;
         AV68Configuracion_movimientoventawwds_14_movvtip3 = AV51MovVTip3;
         AV69Configuracion_movimientoventawwds_15_tfmovvcod = AV31TFMovVCod;
         AV70Configuracion_movimientoventawwds_16_tfmovvcod_to = AV32TFMovVCod_To;
         AV71Configuracion_movimientoventawwds_17_tfmovvdsc = AV33TFMovVDsc;
         AV72Configuracion_movimientoventawwds_18_tfmovvdsc_sel = AV34TFMovVDsc_Sel;
         AV73Configuracion_movimientoventawwds_19_tfmovvabr_sels = AV36TFMovVAbr_Sels;
         AV74Configuracion_movimientoventawwds_20_tfmovvtip_sels = AV38TFMovVTip_Sels;
         AV75Configuracion_movimientoventawwds_21_tfmovvsts_sels = AV40TFMovVSts_Sels;
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
            gxgrGrid_refresh( subGrid_Rows, AV15DynamicFiltersSelector1, AV16DynamicFiltersOperator1, AV17MovVDsc1, AV49MovVTip1, AV19DynamicFiltersSelector2, AV20DynamicFiltersOperator2, AV21MovVDsc2, AV50MovVTip2, AV23DynamicFiltersSelector3, AV24DynamicFiltersOperator3, AV25MovVDsc3, AV51MovVTip3, AV54Pgmname, AV18DynamicFiltersEnabled2, AV22DynamicFiltersEnabled3, AV31TFMovVCod, AV32TFMovVCod_To, AV33TFMovVDsc, AV34TFMovVDsc_Sel, AV36TFMovVAbr_Sels, AV38TFMovVTip_Sels, AV40TFMovVSts_Sels, AV13OrderedBy, AV14OrderedDsc, AV10GridState, AV27DynamicFiltersIgnoreFirst, AV26DynamicFiltersRemoving) ;
         }
         send_integrity_footer_hashes( ) ;
         return (short)(((GRID_nEOF==0) ? 0 : 2)) ;
      }

      protected short subgrid_previouspage( )
      {
         AV55Configuracion_movimientoventawwds_1_dynamicfiltersselector1 = AV15DynamicFiltersSelector1;
         AV56Configuracion_movimientoventawwds_2_dynamicfiltersoperator1 = AV16DynamicFiltersOperator1;
         AV57Configuracion_movimientoventawwds_3_movvdsc1 = AV17MovVDsc1;
         AV58Configuracion_movimientoventawwds_4_movvtip1 = AV49MovVTip1;
         AV59Configuracion_movimientoventawwds_5_dynamicfiltersenabled2 = AV18DynamicFiltersEnabled2;
         AV60Configuracion_movimientoventawwds_6_dynamicfiltersselector2 = AV19DynamicFiltersSelector2;
         AV61Configuracion_movimientoventawwds_7_dynamicfiltersoperator2 = AV20DynamicFiltersOperator2;
         AV62Configuracion_movimientoventawwds_8_movvdsc2 = AV21MovVDsc2;
         AV63Configuracion_movimientoventawwds_9_movvtip2 = AV50MovVTip2;
         AV64Configuracion_movimientoventawwds_10_dynamicfiltersenabled3 = AV22DynamicFiltersEnabled3;
         AV65Configuracion_movimientoventawwds_11_dynamicfiltersselector3 = AV23DynamicFiltersSelector3;
         AV66Configuracion_movimientoventawwds_12_dynamicfiltersoperator3 = AV24DynamicFiltersOperator3;
         AV67Configuracion_movimientoventawwds_13_movvdsc3 = AV25MovVDsc3;
         AV68Configuracion_movimientoventawwds_14_movvtip3 = AV51MovVTip3;
         AV69Configuracion_movimientoventawwds_15_tfmovvcod = AV31TFMovVCod;
         AV70Configuracion_movimientoventawwds_16_tfmovvcod_to = AV32TFMovVCod_To;
         AV71Configuracion_movimientoventawwds_17_tfmovvdsc = AV33TFMovVDsc;
         AV72Configuracion_movimientoventawwds_18_tfmovvdsc_sel = AV34TFMovVDsc_Sel;
         AV73Configuracion_movimientoventawwds_19_tfmovvabr_sels = AV36TFMovVAbr_Sels;
         AV74Configuracion_movimientoventawwds_20_tfmovvtip_sels = AV38TFMovVTip_Sels;
         AV75Configuracion_movimientoventawwds_21_tfmovvsts_sels = AV40TFMovVSts_Sels;
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
            gxgrGrid_refresh( subGrid_Rows, AV15DynamicFiltersSelector1, AV16DynamicFiltersOperator1, AV17MovVDsc1, AV49MovVTip1, AV19DynamicFiltersSelector2, AV20DynamicFiltersOperator2, AV21MovVDsc2, AV50MovVTip2, AV23DynamicFiltersSelector3, AV24DynamicFiltersOperator3, AV25MovVDsc3, AV51MovVTip3, AV54Pgmname, AV18DynamicFiltersEnabled2, AV22DynamicFiltersEnabled3, AV31TFMovVCod, AV32TFMovVCod_To, AV33TFMovVDsc, AV34TFMovVDsc_Sel, AV36TFMovVAbr_Sels, AV38TFMovVTip_Sels, AV40TFMovVSts_Sels, AV13OrderedBy, AV14OrderedDsc, AV10GridState, AV27DynamicFiltersIgnoreFirst, AV26DynamicFiltersRemoving) ;
         }
         send_integrity_footer_hashes( ) ;
         return 0 ;
      }

      protected short subgrid_lastpage( )
      {
         AV55Configuracion_movimientoventawwds_1_dynamicfiltersselector1 = AV15DynamicFiltersSelector1;
         AV56Configuracion_movimientoventawwds_2_dynamicfiltersoperator1 = AV16DynamicFiltersOperator1;
         AV57Configuracion_movimientoventawwds_3_movvdsc1 = AV17MovVDsc1;
         AV58Configuracion_movimientoventawwds_4_movvtip1 = AV49MovVTip1;
         AV59Configuracion_movimientoventawwds_5_dynamicfiltersenabled2 = AV18DynamicFiltersEnabled2;
         AV60Configuracion_movimientoventawwds_6_dynamicfiltersselector2 = AV19DynamicFiltersSelector2;
         AV61Configuracion_movimientoventawwds_7_dynamicfiltersoperator2 = AV20DynamicFiltersOperator2;
         AV62Configuracion_movimientoventawwds_8_movvdsc2 = AV21MovVDsc2;
         AV63Configuracion_movimientoventawwds_9_movvtip2 = AV50MovVTip2;
         AV64Configuracion_movimientoventawwds_10_dynamicfiltersenabled3 = AV22DynamicFiltersEnabled3;
         AV65Configuracion_movimientoventawwds_11_dynamicfiltersselector3 = AV23DynamicFiltersSelector3;
         AV66Configuracion_movimientoventawwds_12_dynamicfiltersoperator3 = AV24DynamicFiltersOperator3;
         AV67Configuracion_movimientoventawwds_13_movvdsc3 = AV25MovVDsc3;
         AV68Configuracion_movimientoventawwds_14_movvtip3 = AV51MovVTip3;
         AV69Configuracion_movimientoventawwds_15_tfmovvcod = AV31TFMovVCod;
         AV70Configuracion_movimientoventawwds_16_tfmovvcod_to = AV32TFMovVCod_To;
         AV71Configuracion_movimientoventawwds_17_tfmovvdsc = AV33TFMovVDsc;
         AV72Configuracion_movimientoventawwds_18_tfmovvdsc_sel = AV34TFMovVDsc_Sel;
         AV73Configuracion_movimientoventawwds_19_tfmovvabr_sels = AV36TFMovVAbr_Sels;
         AV74Configuracion_movimientoventawwds_20_tfmovvtip_sels = AV38TFMovVTip_Sels;
         AV75Configuracion_movimientoventawwds_21_tfmovvsts_sels = AV40TFMovVSts_Sels;
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
            gxgrGrid_refresh( subGrid_Rows, AV15DynamicFiltersSelector1, AV16DynamicFiltersOperator1, AV17MovVDsc1, AV49MovVTip1, AV19DynamicFiltersSelector2, AV20DynamicFiltersOperator2, AV21MovVDsc2, AV50MovVTip2, AV23DynamicFiltersSelector3, AV24DynamicFiltersOperator3, AV25MovVDsc3, AV51MovVTip3, AV54Pgmname, AV18DynamicFiltersEnabled2, AV22DynamicFiltersEnabled3, AV31TFMovVCod, AV32TFMovVCod_To, AV33TFMovVDsc, AV34TFMovVDsc_Sel, AV36TFMovVAbr_Sels, AV38TFMovVTip_Sels, AV40TFMovVSts_Sels, AV13OrderedBy, AV14OrderedDsc, AV10GridState, AV27DynamicFiltersIgnoreFirst, AV26DynamicFiltersRemoving) ;
         }
         send_integrity_footer_hashes( ) ;
         return 0 ;
      }

      protected int subgrid_gotopage( int nPageNo )
      {
         AV55Configuracion_movimientoventawwds_1_dynamicfiltersselector1 = AV15DynamicFiltersSelector1;
         AV56Configuracion_movimientoventawwds_2_dynamicfiltersoperator1 = AV16DynamicFiltersOperator1;
         AV57Configuracion_movimientoventawwds_3_movvdsc1 = AV17MovVDsc1;
         AV58Configuracion_movimientoventawwds_4_movvtip1 = AV49MovVTip1;
         AV59Configuracion_movimientoventawwds_5_dynamicfiltersenabled2 = AV18DynamicFiltersEnabled2;
         AV60Configuracion_movimientoventawwds_6_dynamicfiltersselector2 = AV19DynamicFiltersSelector2;
         AV61Configuracion_movimientoventawwds_7_dynamicfiltersoperator2 = AV20DynamicFiltersOperator2;
         AV62Configuracion_movimientoventawwds_8_movvdsc2 = AV21MovVDsc2;
         AV63Configuracion_movimientoventawwds_9_movvtip2 = AV50MovVTip2;
         AV64Configuracion_movimientoventawwds_10_dynamicfiltersenabled3 = AV22DynamicFiltersEnabled3;
         AV65Configuracion_movimientoventawwds_11_dynamicfiltersselector3 = AV23DynamicFiltersSelector3;
         AV66Configuracion_movimientoventawwds_12_dynamicfiltersoperator3 = AV24DynamicFiltersOperator3;
         AV67Configuracion_movimientoventawwds_13_movvdsc3 = AV25MovVDsc3;
         AV68Configuracion_movimientoventawwds_14_movvtip3 = AV51MovVTip3;
         AV69Configuracion_movimientoventawwds_15_tfmovvcod = AV31TFMovVCod;
         AV70Configuracion_movimientoventawwds_16_tfmovvcod_to = AV32TFMovVCod_To;
         AV71Configuracion_movimientoventawwds_17_tfmovvdsc = AV33TFMovVDsc;
         AV72Configuracion_movimientoventawwds_18_tfmovvdsc_sel = AV34TFMovVDsc_Sel;
         AV73Configuracion_movimientoventawwds_19_tfmovvabr_sels = AV36TFMovVAbr_Sels;
         AV74Configuracion_movimientoventawwds_20_tfmovvtip_sels = AV38TFMovVTip_Sels;
         AV75Configuracion_movimientoventawwds_21_tfmovvsts_sels = AV40TFMovVSts_Sels;
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
            gxgrGrid_refresh( subGrid_Rows, AV15DynamicFiltersSelector1, AV16DynamicFiltersOperator1, AV17MovVDsc1, AV49MovVTip1, AV19DynamicFiltersSelector2, AV20DynamicFiltersOperator2, AV21MovVDsc2, AV50MovVTip2, AV23DynamicFiltersSelector3, AV24DynamicFiltersOperator3, AV25MovVDsc3, AV51MovVTip3, AV54Pgmname, AV18DynamicFiltersEnabled2, AV22DynamicFiltersEnabled3, AV31TFMovVCod, AV32TFMovVCod_To, AV33TFMovVDsc, AV34TFMovVDsc_Sel, AV36TFMovVAbr_Sels, AV38TFMovVTip_Sels, AV40TFMovVSts_Sels, AV13OrderedBy, AV14OrderedDsc, AV10GridState, AV27DynamicFiltersIgnoreFirst, AV26DynamicFiltersRemoving) ;
         }
         send_integrity_footer_hashes( ) ;
         return (int)(0) ;
      }

      protected void before_start_formulas( )
      {
         AV54Pgmname = "Configuracion.MovimientoVentaWW";
         context.Gx_err = 0;
         fix_multi_value_controls( ) ;
      }

      protected void STRUP1F0( )
      {
         /* Before Start, stand alone formulas. */
         before_start_formulas( ) ;
         /* Execute Start event if defined. */
         context.wbGlbDoneStart = 0;
         /* Execute user event: Start */
         E241F2 ();
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
            AV17MovVDsc1 = cgiGet( edtavMovvdsc1_Internalname);
            AssignAttri("", false, "AV17MovVDsc1", AV17MovVDsc1);
            cmbavMovvtip1.Name = cmbavMovvtip1_Internalname;
            cmbavMovvtip1.CurrentValue = cgiGet( cmbavMovvtip1_Internalname);
            AV49MovVTip1 = cgiGet( cmbavMovvtip1_Internalname);
            AssignAttri("", false, "AV49MovVTip1", AV49MovVTip1);
            cmbavDynamicfiltersselector2.Name = cmbavDynamicfiltersselector2_Internalname;
            cmbavDynamicfiltersselector2.CurrentValue = cgiGet( cmbavDynamicfiltersselector2_Internalname);
            AV19DynamicFiltersSelector2 = cgiGet( cmbavDynamicfiltersselector2_Internalname);
            AssignAttri("", false, "AV19DynamicFiltersSelector2", AV19DynamicFiltersSelector2);
            cmbavDynamicfiltersoperator2.Name = cmbavDynamicfiltersoperator2_Internalname;
            cmbavDynamicfiltersoperator2.CurrentValue = cgiGet( cmbavDynamicfiltersoperator2_Internalname);
            AV20DynamicFiltersOperator2 = (short)(NumberUtil.Val( cgiGet( cmbavDynamicfiltersoperator2_Internalname), "."));
            AssignAttri("", false, "AV20DynamicFiltersOperator2", StringUtil.LTrimStr( (decimal)(AV20DynamicFiltersOperator2), 4, 0));
            AV21MovVDsc2 = cgiGet( edtavMovvdsc2_Internalname);
            AssignAttri("", false, "AV21MovVDsc2", AV21MovVDsc2);
            cmbavMovvtip2.Name = cmbavMovvtip2_Internalname;
            cmbavMovvtip2.CurrentValue = cgiGet( cmbavMovvtip2_Internalname);
            AV50MovVTip2 = cgiGet( cmbavMovvtip2_Internalname);
            AssignAttri("", false, "AV50MovVTip2", AV50MovVTip2);
            cmbavDynamicfiltersselector3.Name = cmbavDynamicfiltersselector3_Internalname;
            cmbavDynamicfiltersselector3.CurrentValue = cgiGet( cmbavDynamicfiltersselector3_Internalname);
            AV23DynamicFiltersSelector3 = cgiGet( cmbavDynamicfiltersselector3_Internalname);
            AssignAttri("", false, "AV23DynamicFiltersSelector3", AV23DynamicFiltersSelector3);
            cmbavDynamicfiltersoperator3.Name = cmbavDynamicfiltersoperator3_Internalname;
            cmbavDynamicfiltersoperator3.CurrentValue = cgiGet( cmbavDynamicfiltersoperator3_Internalname);
            AV24DynamicFiltersOperator3 = (short)(NumberUtil.Val( cgiGet( cmbavDynamicfiltersoperator3_Internalname), "."));
            AssignAttri("", false, "AV24DynamicFiltersOperator3", StringUtil.LTrimStr( (decimal)(AV24DynamicFiltersOperator3), 4, 0));
            AV25MovVDsc3 = cgiGet( edtavMovvdsc3_Internalname);
            AssignAttri("", false, "AV25MovVDsc3", AV25MovVDsc3);
            cmbavMovvtip3.Name = cmbavMovvtip3_Internalname;
            cmbavMovvtip3.CurrentValue = cgiGet( cmbavMovvtip3_Internalname);
            AV51MovVTip3 = cgiGet( cmbavMovvtip3_Internalname);
            AssignAttri("", false, "AV51MovVTip3", AV51MovVTip3);
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
            if ( StringUtil.StrCmp(cgiGet( "GXH_vMOVVDSC1"), AV17MovVDsc1) != 0 )
            {
               GRID_nFirstRecordOnPage = 0;
            }
            if ( StringUtil.StrCmp(cgiGet( "GXH_vMOVVTIP1"), AV49MovVTip1) != 0 )
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
            if ( StringUtil.StrCmp(cgiGet( "GXH_vMOVVDSC2"), AV21MovVDsc2) != 0 )
            {
               GRID_nFirstRecordOnPage = 0;
            }
            if ( StringUtil.StrCmp(cgiGet( "GXH_vMOVVTIP2"), AV50MovVTip2) != 0 )
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
            if ( StringUtil.StrCmp(cgiGet( "GXH_vMOVVDSC3"), AV25MovVDsc3) != 0 )
            {
               GRID_nFirstRecordOnPage = 0;
            }
            if ( StringUtil.StrCmp(cgiGet( "GXH_vMOVVTIP3"), AV51MovVTip3) != 0 )
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
         E241F2 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
      }

      protected void E241F2( )
      {
         /* Start Routine */
         returnInSub = false;
         subGrid_Rows = 10;
         GxWebStd.gx_hidden_field( context, "GRID_Rows", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid_Rows), 6, 0, ".", "")));
         Grid_empowerer_Gridinternalname = subGrid_Internalname;
         ucGrid_empowerer.SendProperty(context, "", false, Grid_empowerer_Internalname, "GridInternalName", Grid_empowerer_Gridinternalname);
         lblJsdynamicfilters_Caption = "";
         AssignProp("", false, lblJsdynamicfilters_Internalname, "Caption", lblJsdynamicfilters_Caption, true);
         AV49MovVTip1 = "";
         AssignAttri("", false, "AV49MovVTip1", AV49MovVTip1);
         AV15DynamicFiltersSelector1 = "MOVVDSC";
         AssignAttri("", false, "AV15DynamicFiltersSelector1", AV15DynamicFiltersSelector1);
         /* Execute user subroutine: 'ENABLEDYNAMICFILTERS1' */
         S112 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
         AV50MovVTip2 = "";
         AssignAttri("", false, "AV50MovVTip2", AV50MovVTip2);
         AV19DynamicFiltersSelector2 = "MOVVDSC";
         AssignAttri("", false, "AV19DynamicFiltersSelector2", AV19DynamicFiltersSelector2);
         /* Execute user subroutine: 'ENABLEDYNAMICFILTERS2' */
         S122 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
         AV51MovVTip3 = "";
         AssignAttri("", false, "AV51MovVTip3", AV51MovVTip3);
         AV23DynamicFiltersSelector3 = "MOVVDSC";
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
         Form.Caption = " Movimientos de Credito / Debito";
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

      protected void E251F2( )
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
         AV43GridCurrentPage = subGrid_fnc_Currentpage( );
         AssignAttri("", false, "AV43GridCurrentPage", StringUtil.LTrimStr( (decimal)(AV43GridCurrentPage), 10, 0));
         AV44GridPageCount = subGrid_fnc_Pagecount( );
         AssignAttri("", false, "AV44GridPageCount", StringUtil.LTrimStr( (decimal)(AV44GridPageCount), 10, 0));
         GXt_char2 = AV45GridAppliedFilters;
         new GeneXus.Programs.wwpbaseobjects.wwp_getappliedfiltersdescription(context ).execute(  AV54Pgmname, out  GXt_char2) ;
         AV45GridAppliedFilters = GXt_char2;
         AssignAttri("", false, "AV45GridAppliedFilters", AV45GridAppliedFilters);
         AV55Configuracion_movimientoventawwds_1_dynamicfiltersselector1 = AV15DynamicFiltersSelector1;
         AV56Configuracion_movimientoventawwds_2_dynamicfiltersoperator1 = AV16DynamicFiltersOperator1;
         AV57Configuracion_movimientoventawwds_3_movvdsc1 = AV17MovVDsc1;
         AV58Configuracion_movimientoventawwds_4_movvtip1 = AV49MovVTip1;
         AV59Configuracion_movimientoventawwds_5_dynamicfiltersenabled2 = AV18DynamicFiltersEnabled2;
         AV60Configuracion_movimientoventawwds_6_dynamicfiltersselector2 = AV19DynamicFiltersSelector2;
         AV61Configuracion_movimientoventawwds_7_dynamicfiltersoperator2 = AV20DynamicFiltersOperator2;
         AV62Configuracion_movimientoventawwds_8_movvdsc2 = AV21MovVDsc2;
         AV63Configuracion_movimientoventawwds_9_movvtip2 = AV50MovVTip2;
         AV64Configuracion_movimientoventawwds_10_dynamicfiltersenabled3 = AV22DynamicFiltersEnabled3;
         AV65Configuracion_movimientoventawwds_11_dynamicfiltersselector3 = AV23DynamicFiltersSelector3;
         AV66Configuracion_movimientoventawwds_12_dynamicfiltersoperator3 = AV24DynamicFiltersOperator3;
         AV67Configuracion_movimientoventawwds_13_movvdsc3 = AV25MovVDsc3;
         AV68Configuracion_movimientoventawwds_14_movvtip3 = AV51MovVTip3;
         AV69Configuracion_movimientoventawwds_15_tfmovvcod = AV31TFMovVCod;
         AV70Configuracion_movimientoventawwds_16_tfmovvcod_to = AV32TFMovVCod_To;
         AV71Configuracion_movimientoventawwds_17_tfmovvdsc = AV33TFMovVDsc;
         AV72Configuracion_movimientoventawwds_18_tfmovvdsc_sel = AV34TFMovVDsc_Sel;
         AV73Configuracion_movimientoventawwds_19_tfmovvabr_sels = AV36TFMovVAbr_Sels;
         AV74Configuracion_movimientoventawwds_20_tfmovvtip_sels = AV38TFMovVTip_Sels;
         AV75Configuracion_movimientoventawwds_21_tfmovvsts_sels = AV40TFMovVSts_Sels;
         /*  Sending Event outputs  */
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV10GridState", AV10GridState);
      }

      protected void E111F2( )
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

      protected void E121F2( )
      {
         /* Gridpaginationbar_Changerowsperpage Routine */
         returnInSub = false;
         subGrid_Rows = Gridpaginationbar_Rowsperpageselectedvalue;
         GxWebStd.gx_hidden_field( context, "GRID_Rows", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid_Rows), 6, 0, ".", "")));
         subgrid_firstpage( ) ;
         /*  Sending Event outputs  */
      }

      protected void E141F2( )
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
            if ( StringUtil.StrCmp(Ddo_grid_Selectedcolumn, "MovVCod") == 0 )
            {
               AV31TFMovVCod = (int)(NumberUtil.Val( Ddo_grid_Filteredtext_get, "."));
               AssignAttri("", false, "AV31TFMovVCod", StringUtil.LTrimStr( (decimal)(AV31TFMovVCod), 6, 0));
               AV32TFMovVCod_To = (int)(NumberUtil.Val( Ddo_grid_Filteredtextto_get, "."));
               AssignAttri("", false, "AV32TFMovVCod_To", StringUtil.LTrimStr( (decimal)(AV32TFMovVCod_To), 6, 0));
            }
            else if ( StringUtil.StrCmp(Ddo_grid_Selectedcolumn, "MovVDsc") == 0 )
            {
               AV33TFMovVDsc = Ddo_grid_Filteredtext_get;
               AssignAttri("", false, "AV33TFMovVDsc", AV33TFMovVDsc);
               AV34TFMovVDsc_Sel = Ddo_grid_Selectedvalue_get;
               AssignAttri("", false, "AV34TFMovVDsc_Sel", AV34TFMovVDsc_Sel);
            }
            else if ( StringUtil.StrCmp(Ddo_grid_Selectedcolumn, "MovVAbr") == 0 )
            {
               AV35TFMovVAbr_SelsJson = Ddo_grid_Selectedvalue_get;
               AssignAttri("", false, "AV35TFMovVAbr_SelsJson", AV35TFMovVAbr_SelsJson);
               AV36TFMovVAbr_Sels.FromJSonString(AV35TFMovVAbr_SelsJson, null);
            }
            else if ( StringUtil.StrCmp(Ddo_grid_Selectedcolumn, "MovVTip") == 0 )
            {
               AV37TFMovVTip_SelsJson = Ddo_grid_Selectedvalue_get;
               AssignAttri("", false, "AV37TFMovVTip_SelsJson", AV37TFMovVTip_SelsJson);
               AV38TFMovVTip_Sels.FromJSonString(AV37TFMovVTip_SelsJson, null);
            }
            else if ( StringUtil.StrCmp(Ddo_grid_Selectedcolumn, "MovVSts") == 0 )
            {
               AV39TFMovVSts_SelsJson = Ddo_grid_Selectedvalue_get;
               AssignAttri("", false, "AV39TFMovVSts_SelsJson", AV39TFMovVSts_SelsJson);
               AV40TFMovVSts_Sels.FromJSonString(StringUtil.StringReplace( AV39TFMovVSts_SelsJson, "\"", ""), null);
            }
            subgrid_firstpage( ) ;
         }
         /*  Sending Event outputs  */
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV36TFMovVAbr_Sels", AV36TFMovVAbr_Sels);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV38TFMovVTip_Sels", AV38TFMovVTip_Sels);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV40TFMovVSts_Sels", AV40TFMovVSts_Sels);
      }

      private void E261F2( )
      {
         /* Grid_Load Routine */
         returnInSub = false;
         cmbavGridactions.removeAllItems();
         cmbavGridactions.addItem("0", ";fa fa-bars", 0);
         cmbavGridactions.addItem("1", StringUtil.Format( "%1;%2", "Modificar", "fa fa-pen", "", "", "", "", "", "", ""), 0);
         cmbavGridactions.addItem("2", StringUtil.Format( "%1;%2", "Eliminar", "fa fa-times", "", "", "", "", "", "", ""), 0);
         GXKey = Crypto.GetSiteKey( );
         GXEncryptionTmp = "configuracion.movimientoventa.aspx"+UrlEncode(StringUtil.RTrim("DSP")) + "," + UrlEncode(StringUtil.LTrimStr(A235MovVCod,6,0));
         edtMovVDsc_Link = formatLink("configuracion.movimientoventa.aspx") + "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey);
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

      protected void E191F2( )
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

      protected void E151F2( )
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
         gxgrGrid_refresh( subGrid_Rows, AV15DynamicFiltersSelector1, AV16DynamicFiltersOperator1, AV17MovVDsc1, AV49MovVTip1, AV19DynamicFiltersSelector2, AV20DynamicFiltersOperator2, AV21MovVDsc2, AV50MovVTip2, AV23DynamicFiltersSelector3, AV24DynamicFiltersOperator3, AV25MovVDsc3, AV51MovVTip3, AV54Pgmname, AV18DynamicFiltersEnabled2, AV22DynamicFiltersEnabled3, AV31TFMovVCod, AV32TFMovVCod_To, AV33TFMovVDsc, AV34TFMovVDsc_Sel, AV36TFMovVAbr_Sels, AV38TFMovVTip_Sels, AV40TFMovVSts_Sels, AV13OrderedBy, AV14OrderedDsc, AV10GridState, AV27DynamicFiltersIgnoreFirst, AV26DynamicFiltersRemoving) ;
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
         cmbavMovvtip1.CurrentValue = StringUtil.RTrim( AV49MovVTip1);
         AssignProp("", false, cmbavMovvtip1_Internalname, "Values", cmbavMovvtip1.ToJavascriptSource(), true);
         cmbavMovvtip2.CurrentValue = StringUtil.RTrim( AV50MovVTip2);
         AssignProp("", false, cmbavMovvtip2_Internalname, "Values", cmbavMovvtip2.ToJavascriptSource(), true);
         cmbavMovvtip3.CurrentValue = StringUtil.RTrim( AV51MovVTip3);
         AssignProp("", false, cmbavMovvtip3_Internalname, "Values", cmbavMovvtip3.ToJavascriptSource(), true);
      }

      protected void E201F2( )
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

      protected void E211F2( )
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

      protected void E161F2( )
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
         gxgrGrid_refresh( subGrid_Rows, AV15DynamicFiltersSelector1, AV16DynamicFiltersOperator1, AV17MovVDsc1, AV49MovVTip1, AV19DynamicFiltersSelector2, AV20DynamicFiltersOperator2, AV21MovVDsc2, AV50MovVTip2, AV23DynamicFiltersSelector3, AV24DynamicFiltersOperator3, AV25MovVDsc3, AV51MovVTip3, AV54Pgmname, AV18DynamicFiltersEnabled2, AV22DynamicFiltersEnabled3, AV31TFMovVCod, AV32TFMovVCod_To, AV33TFMovVDsc, AV34TFMovVDsc_Sel, AV36TFMovVAbr_Sels, AV38TFMovVTip_Sels, AV40TFMovVSts_Sels, AV13OrderedBy, AV14OrderedDsc, AV10GridState, AV27DynamicFiltersIgnoreFirst, AV26DynamicFiltersRemoving) ;
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
         cmbavMovvtip1.CurrentValue = StringUtil.RTrim( AV49MovVTip1);
         AssignProp("", false, cmbavMovvtip1_Internalname, "Values", cmbavMovvtip1.ToJavascriptSource(), true);
         cmbavMovvtip2.CurrentValue = StringUtil.RTrim( AV50MovVTip2);
         AssignProp("", false, cmbavMovvtip2_Internalname, "Values", cmbavMovvtip2.ToJavascriptSource(), true);
         cmbavMovvtip3.CurrentValue = StringUtil.RTrim( AV51MovVTip3);
         AssignProp("", false, cmbavMovvtip3_Internalname, "Values", cmbavMovvtip3.ToJavascriptSource(), true);
      }

      protected void E221F2( )
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

      protected void E171F2( )
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
         gxgrGrid_refresh( subGrid_Rows, AV15DynamicFiltersSelector1, AV16DynamicFiltersOperator1, AV17MovVDsc1, AV49MovVTip1, AV19DynamicFiltersSelector2, AV20DynamicFiltersOperator2, AV21MovVDsc2, AV50MovVTip2, AV23DynamicFiltersSelector3, AV24DynamicFiltersOperator3, AV25MovVDsc3, AV51MovVTip3, AV54Pgmname, AV18DynamicFiltersEnabled2, AV22DynamicFiltersEnabled3, AV31TFMovVCod, AV32TFMovVCod_To, AV33TFMovVDsc, AV34TFMovVDsc_Sel, AV36TFMovVAbr_Sels, AV38TFMovVTip_Sels, AV40TFMovVSts_Sels, AV13OrderedBy, AV14OrderedDsc, AV10GridState, AV27DynamicFiltersIgnoreFirst, AV26DynamicFiltersRemoving) ;
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
         cmbavMovvtip1.CurrentValue = StringUtil.RTrim( AV49MovVTip1);
         AssignProp("", false, cmbavMovvtip1_Internalname, "Values", cmbavMovvtip1.ToJavascriptSource(), true);
         cmbavMovvtip2.CurrentValue = StringUtil.RTrim( AV50MovVTip2);
         AssignProp("", false, cmbavMovvtip2_Internalname, "Values", cmbavMovvtip2.ToJavascriptSource(), true);
         cmbavMovvtip3.CurrentValue = StringUtil.RTrim( AV51MovVTip3);
         AssignProp("", false, cmbavMovvtip3_Internalname, "Values", cmbavMovvtip3.ToJavascriptSource(), true);
      }

      protected void E231F2( )
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

      protected void E271F2( )
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

      protected void E181F2( )
      {
         /* 'DoInsert' Routine */
         returnInSub = false;
         GXKey = Crypto.GetSiteKey( );
         GXEncryptionTmp = "configuracion.movimientoventa.aspx"+UrlEncode(StringUtil.RTrim("INS")) + "," + UrlEncode(StringUtil.LTrimStr(0,1,0));
         CallWebObject(formatLink("configuracion.movimientoventa.aspx") + "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey));
         context.wjLocDisableFrm = 1;
      }

      protected void E131F2( )
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
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV40TFMovVSts_Sels", AV40TFMovVSts_Sels);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV38TFMovVTip_Sels", AV38TFMovVTip_Sels);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV36TFMovVAbr_Sels", AV36TFMovVAbr_Sels);
         cmbavDynamicfiltersselector1.CurrentValue = StringUtil.RTrim( AV15DynamicFiltersSelector1);
         AssignProp("", false, cmbavDynamicfiltersselector1_Internalname, "Values", cmbavDynamicfiltersselector1.ToJavascriptSource(), true);
         cmbavDynamicfiltersoperator1.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV16DynamicFiltersOperator1), 4, 0));
         AssignProp("", false, cmbavDynamicfiltersoperator1_Internalname, "Values", cmbavDynamicfiltersoperator1.ToJavascriptSource(), true);
         cmbavMovvtip1.CurrentValue = StringUtil.RTrim( AV49MovVTip1);
         AssignProp("", false, cmbavMovvtip1_Internalname, "Values", cmbavMovvtip1.ToJavascriptSource(), true);
         cmbavDynamicfiltersselector2.CurrentValue = StringUtil.RTrim( AV19DynamicFiltersSelector2);
         AssignProp("", false, cmbavDynamicfiltersselector2_Internalname, "Values", cmbavDynamicfiltersselector2.ToJavascriptSource(), true);
         cmbavDynamicfiltersoperator2.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV20DynamicFiltersOperator2), 4, 0));
         AssignProp("", false, cmbavDynamicfiltersoperator2_Internalname, "Values", cmbavDynamicfiltersoperator2.ToJavascriptSource(), true);
         cmbavMovvtip2.CurrentValue = StringUtil.RTrim( AV50MovVTip2);
         AssignProp("", false, cmbavMovvtip2_Internalname, "Values", cmbavMovvtip2.ToJavascriptSource(), true);
         cmbavDynamicfiltersselector3.CurrentValue = StringUtil.RTrim( AV23DynamicFiltersSelector3);
         AssignProp("", false, cmbavDynamicfiltersselector3_Internalname, "Values", cmbavDynamicfiltersselector3.ToJavascriptSource(), true);
         cmbavDynamicfiltersoperator3.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV24DynamicFiltersOperator3), 4, 0));
         AssignProp("", false, cmbavDynamicfiltersoperator3_Internalname, "Values", cmbavDynamicfiltersoperator3.ToJavascriptSource(), true);
         cmbavMovvtip3.CurrentValue = StringUtil.RTrim( AV51MovVTip3);
         AssignProp("", false, cmbavMovvtip3_Internalname, "Values", cmbavMovvtip3.ToJavascriptSource(), true);
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
         edtavMovvdsc1_Visible = 0;
         AssignProp("", false, edtavMovvdsc1_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavMovvdsc1_Visible), 5, 0), true);
         cmbavMovvtip1.Visible = 0;
         AssignProp("", false, cmbavMovvtip1_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(cmbavMovvtip1.Visible), 5, 0), true);
         cmbavDynamicfiltersoperator1.Visible = 0;
         AssignProp("", false, cmbavDynamicfiltersoperator1_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(cmbavDynamicfiltersoperator1.Visible), 5, 0), true);
         if ( StringUtil.StrCmp(AV15DynamicFiltersSelector1, "MOVVDSC") == 0 )
         {
            edtavMovvdsc1_Visible = 1;
            AssignProp("", false, edtavMovvdsc1_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavMovvdsc1_Visible), 5, 0), true);
            cmbavDynamicfiltersoperator1.Visible = 1;
            AssignProp("", false, cmbavDynamicfiltersoperator1_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(cmbavDynamicfiltersoperator1.Visible), 5, 0), true);
         }
         else if ( StringUtil.StrCmp(AV15DynamicFiltersSelector1, "MOVVTIP") == 0 )
         {
            cmbavMovvtip1.Visible = 1;
            AssignProp("", false, cmbavMovvtip1_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(cmbavMovvtip1.Visible), 5, 0), true);
         }
      }

      protected void S122( )
      {
         /* 'ENABLEDYNAMICFILTERS2' Routine */
         returnInSub = false;
         edtavMovvdsc2_Visible = 0;
         AssignProp("", false, edtavMovvdsc2_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavMovvdsc2_Visible), 5, 0), true);
         cmbavMovvtip2.Visible = 0;
         AssignProp("", false, cmbavMovvtip2_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(cmbavMovvtip2.Visible), 5, 0), true);
         cmbavDynamicfiltersoperator2.Visible = 0;
         AssignProp("", false, cmbavDynamicfiltersoperator2_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(cmbavDynamicfiltersoperator2.Visible), 5, 0), true);
         if ( StringUtil.StrCmp(AV19DynamicFiltersSelector2, "MOVVDSC") == 0 )
         {
            edtavMovvdsc2_Visible = 1;
            AssignProp("", false, edtavMovvdsc2_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavMovvdsc2_Visible), 5, 0), true);
            cmbavDynamicfiltersoperator2.Visible = 1;
            AssignProp("", false, cmbavDynamicfiltersoperator2_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(cmbavDynamicfiltersoperator2.Visible), 5, 0), true);
         }
         else if ( StringUtil.StrCmp(AV19DynamicFiltersSelector2, "MOVVTIP") == 0 )
         {
            cmbavMovvtip2.Visible = 1;
            AssignProp("", false, cmbavMovvtip2_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(cmbavMovvtip2.Visible), 5, 0), true);
         }
      }

      protected void S132( )
      {
         /* 'ENABLEDYNAMICFILTERS3' Routine */
         returnInSub = false;
         edtavMovvdsc3_Visible = 0;
         AssignProp("", false, edtavMovvdsc3_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavMovvdsc3_Visible), 5, 0), true);
         cmbavMovvtip3.Visible = 0;
         AssignProp("", false, cmbavMovvtip3_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(cmbavMovvtip3.Visible), 5, 0), true);
         cmbavDynamicfiltersoperator3.Visible = 0;
         AssignProp("", false, cmbavDynamicfiltersoperator3_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(cmbavDynamicfiltersoperator3.Visible), 5, 0), true);
         if ( StringUtil.StrCmp(AV23DynamicFiltersSelector3, "MOVVDSC") == 0 )
         {
            edtavMovvdsc3_Visible = 1;
            AssignProp("", false, edtavMovvdsc3_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavMovvdsc3_Visible), 5, 0), true);
            cmbavDynamicfiltersoperator3.Visible = 1;
            AssignProp("", false, cmbavDynamicfiltersoperator3_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(cmbavDynamicfiltersoperator3.Visible), 5, 0), true);
         }
         else if ( StringUtil.StrCmp(AV23DynamicFiltersSelector3, "MOVVTIP") == 0 )
         {
            cmbavMovvtip3.Visible = 1;
            AssignProp("", false, cmbavMovvtip3_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(cmbavMovvtip3.Visible), 5, 0), true);
         }
      }

      protected void S192( )
      {
         /* 'RESETDYNFILTERS' Routine */
         returnInSub = false;
         AV18DynamicFiltersEnabled2 = false;
         AssignAttri("", false, "AV18DynamicFiltersEnabled2", AV18DynamicFiltersEnabled2);
         AV19DynamicFiltersSelector2 = "MOVVDSC";
         AssignAttri("", false, "AV19DynamicFiltersSelector2", AV19DynamicFiltersSelector2);
         AV20DynamicFiltersOperator2 = 0;
         AssignAttri("", false, "AV20DynamicFiltersOperator2", StringUtil.LTrimStr( (decimal)(AV20DynamicFiltersOperator2), 4, 0));
         AV21MovVDsc2 = "";
         AssignAttri("", false, "AV21MovVDsc2", AV21MovVDsc2);
         /* Execute user subroutine: 'ENABLEDYNAMICFILTERS2' */
         S122 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
         AV22DynamicFiltersEnabled3 = false;
         AssignAttri("", false, "AV22DynamicFiltersEnabled3", AV22DynamicFiltersEnabled3);
         AV23DynamicFiltersSelector3 = "MOVVDSC";
         AssignAttri("", false, "AV23DynamicFiltersSelector3", AV23DynamicFiltersSelector3);
         AV24DynamicFiltersOperator3 = 0;
         AssignAttri("", false, "AV24DynamicFiltersOperator3", StringUtil.LTrimStr( (decimal)(AV24DynamicFiltersOperator3), 4, 0));
         AV25MovVDsc3 = "";
         AssignAttri("", false, "AV25MovVDsc3", AV25MovVDsc3);
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
         GXEncryptionTmp = "configuracion.movimientoventa.aspx"+UrlEncode(StringUtil.RTrim("UPD")) + "," + UrlEncode(StringUtil.LTrimStr(A235MovVCod,6,0));
         CallWebObject(formatLink("configuracion.movimientoventa.aspx") + "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey));
         context.wjLocDisableFrm = 1;
      }

      protected void S222( )
      {
         /* 'DO DELETE' Routine */
         returnInSub = false;
         GXKey = Crypto.GetSiteKey( );
         GXEncryptionTmp = "configuracion.movimientoventa.aspx"+UrlEncode(StringUtil.RTrim("DLT")) + "," + UrlEncode(StringUtil.LTrimStr(A235MovVCod,6,0));
         CallWebObject(formatLink("configuracion.movimientoventa.aspx") + "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey));
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
            if ( StringUtil.StrCmp(AV11GridStateFilterValue.gxTpr_Name, "TFMOVVCOD") == 0 )
            {
               AV31TFMovVCod = (int)(NumberUtil.Val( AV11GridStateFilterValue.gxTpr_Value, "."));
               AssignAttri("", false, "AV31TFMovVCod", StringUtil.LTrimStr( (decimal)(AV31TFMovVCod), 6, 0));
               AV32TFMovVCod_To = (int)(NumberUtil.Val( AV11GridStateFilterValue.gxTpr_Valueto, "."));
               AssignAttri("", false, "AV32TFMovVCod_To", StringUtil.LTrimStr( (decimal)(AV32TFMovVCod_To), 6, 0));
            }
            else if ( StringUtil.StrCmp(AV11GridStateFilterValue.gxTpr_Name, "TFMOVVDSC") == 0 )
            {
               AV33TFMovVDsc = AV11GridStateFilterValue.gxTpr_Value;
               AssignAttri("", false, "AV33TFMovVDsc", AV33TFMovVDsc);
            }
            else if ( StringUtil.StrCmp(AV11GridStateFilterValue.gxTpr_Name, "TFMOVVDSC_SEL") == 0 )
            {
               AV34TFMovVDsc_Sel = AV11GridStateFilterValue.gxTpr_Value;
               AssignAttri("", false, "AV34TFMovVDsc_Sel", AV34TFMovVDsc_Sel);
            }
            else if ( StringUtil.StrCmp(AV11GridStateFilterValue.gxTpr_Name, "TFMOVVABR_SEL") == 0 )
            {
               AV35TFMovVAbr_SelsJson = AV11GridStateFilterValue.gxTpr_Value;
               AssignAttri("", false, "AV35TFMovVAbr_SelsJson", AV35TFMovVAbr_SelsJson);
               AV36TFMovVAbr_Sels.FromJSonString(AV35TFMovVAbr_SelsJson, null);
            }
            else if ( StringUtil.StrCmp(AV11GridStateFilterValue.gxTpr_Name, "TFMOVVTIP_SEL") == 0 )
            {
               AV37TFMovVTip_SelsJson = AV11GridStateFilterValue.gxTpr_Value;
               AssignAttri("", false, "AV37TFMovVTip_SelsJson", AV37TFMovVTip_SelsJson);
               AV38TFMovVTip_Sels.FromJSonString(AV37TFMovVTip_SelsJson, null);
            }
            else if ( StringUtil.StrCmp(AV11GridStateFilterValue.gxTpr_Name, "TFMOVVSTS_SEL") == 0 )
            {
               AV39TFMovVSts_SelsJson = AV11GridStateFilterValue.gxTpr_Value;
               AssignAttri("", false, "AV39TFMovVSts_SelsJson", AV39TFMovVSts_SelsJson);
               AV40TFMovVSts_Sels.FromJSonString(AV39TFMovVSts_SelsJson, null);
            }
            AV76GXV1 = (int)(AV76GXV1+1);
         }
         GXt_char2 = "";
         new GeneXus.Programs.wwpbaseobjects.wwp_getfilterval(context ).execute(  String.IsNullOrEmpty(StringUtil.RTrim( AV34TFMovVDsc_Sel)),  AV34TFMovVDsc_Sel, out  GXt_char2) ;
         GXt_char3 = "";
         new GeneXus.Programs.wwpbaseobjects.wwp_getfilterval(context ).execute(  (AV36TFMovVAbr_Sels.Count==0),  AV35TFMovVAbr_SelsJson, out  GXt_char3) ;
         GXt_char4 = "";
         new GeneXus.Programs.wwpbaseobjects.wwp_getfilterval(context ).execute(  (AV38TFMovVTip_Sels.Count==0),  AV37TFMovVTip_SelsJson, out  GXt_char4) ;
         Ddo_grid_Selectedvalue_set = "|"+GXt_char2+"|"+GXt_char3+"|"+GXt_char4+"|"+((AV40TFMovVSts_Sels.Count==0) ? "" : AV39TFMovVSts_SelsJson);
         ucDdo_grid.SendProperty(context, "", false, Ddo_grid_Internalname, "SelectedValue_set", Ddo_grid_Selectedvalue_set);
         GXt_char4 = "";
         new GeneXus.Programs.wwpbaseobjects.wwp_getfilterval(context ).execute(  String.IsNullOrEmpty(StringUtil.RTrim( AV33TFMovVDsc)),  AV33TFMovVDsc, out  GXt_char4) ;
         Ddo_grid_Filteredtext_set = ((0==AV31TFMovVCod) ? "" : StringUtil.Str( (decimal)(AV31TFMovVCod), 6, 0))+"|"+GXt_char4+"|||";
         ucDdo_grid.SendProperty(context, "", false, Ddo_grid_Internalname, "FilteredText_set", Ddo_grid_Filteredtext_set);
         Ddo_grid_Filteredtextto_set = ((0==AV32TFMovVCod_To) ? "" : StringUtil.Str( (decimal)(AV32TFMovVCod_To), 6, 0))+"||||";
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
            if ( StringUtil.StrCmp(AV15DynamicFiltersSelector1, "MOVVDSC") == 0 )
            {
               AV16DynamicFiltersOperator1 = AV12GridStateDynamicFilter.gxTpr_Operator;
               AssignAttri("", false, "AV16DynamicFiltersOperator1", StringUtil.LTrimStr( (decimal)(AV16DynamicFiltersOperator1), 4, 0));
               AV17MovVDsc1 = AV12GridStateDynamicFilter.gxTpr_Value;
               AssignAttri("", false, "AV17MovVDsc1", AV17MovVDsc1);
            }
            else if ( StringUtil.StrCmp(AV15DynamicFiltersSelector1, "MOVVTIP") == 0 )
            {
               AV49MovVTip1 = AV12GridStateDynamicFilter.gxTpr_Value;
               AssignAttri("", false, "AV49MovVTip1", AV49MovVTip1);
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
               if ( StringUtil.StrCmp(AV19DynamicFiltersSelector2, "MOVVDSC") == 0 )
               {
                  AV20DynamicFiltersOperator2 = AV12GridStateDynamicFilter.gxTpr_Operator;
                  AssignAttri("", false, "AV20DynamicFiltersOperator2", StringUtil.LTrimStr( (decimal)(AV20DynamicFiltersOperator2), 4, 0));
                  AV21MovVDsc2 = AV12GridStateDynamicFilter.gxTpr_Value;
                  AssignAttri("", false, "AV21MovVDsc2", AV21MovVDsc2);
               }
               else if ( StringUtil.StrCmp(AV19DynamicFiltersSelector2, "MOVVTIP") == 0 )
               {
                  AV50MovVTip2 = AV12GridStateDynamicFilter.gxTpr_Value;
                  AssignAttri("", false, "AV50MovVTip2", AV50MovVTip2);
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
                  if ( StringUtil.StrCmp(AV23DynamicFiltersSelector3, "MOVVDSC") == 0 )
                  {
                     AV24DynamicFiltersOperator3 = AV12GridStateDynamicFilter.gxTpr_Operator;
                     AssignAttri("", false, "AV24DynamicFiltersOperator3", StringUtil.LTrimStr( (decimal)(AV24DynamicFiltersOperator3), 4, 0));
                     AV25MovVDsc3 = AV12GridStateDynamicFilter.gxTpr_Value;
                     AssignAttri("", false, "AV25MovVDsc3", AV25MovVDsc3);
                  }
                  else if ( StringUtil.StrCmp(AV23DynamicFiltersSelector3, "MOVVTIP") == 0 )
                  {
                     AV51MovVTip3 = AV12GridStateDynamicFilter.gxTpr_Value;
                     AssignAttri("", false, "AV51MovVTip3", AV51MovVTip3);
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
         new GeneXus.Programs.wwpbaseobjects.wwp_gridstateaddfiltervalue(context ).execute( ref  AV10GridState,  "TFMOVVCOD",  "Codigo",  !((0==AV31TFMovVCod)&&(0==AV32TFMovVCod_To)),  0,  StringUtil.Trim( StringUtil.Str( (decimal)(AV31TFMovVCod), 6, 0)),  StringUtil.Trim( StringUtil.Str( (decimal)(AV32TFMovVCod_To), 6, 0))) ;
         new GeneXus.Programs.wwpbaseobjects.wwp_gridstateaddfiltervalueandsel(context ).execute( ref  AV10GridState,  "TFMOVVDSC",  "Movimiento de Venta",  !String.IsNullOrEmpty(StringUtil.RTrim( AV33TFMovVDsc)),  0,  AV33TFMovVDsc,  "",  !String.IsNullOrEmpty(StringUtil.RTrim( AV34TFMovVDsc_Sel)),  AV34TFMovVDsc_Sel,  "") ;
         new GeneXus.Programs.wwpbaseobjects.wwp_gridstateaddfiltervalue(context ).execute( ref  AV10GridState,  "TFMOVVABR_SEL",  "Afecta Unidades",  !(AV36TFMovVAbr_Sels.Count==0),  0,  AV36TFMovVAbr_Sels.ToJSonString(false),  "") ;
         new GeneXus.Programs.wwpbaseobjects.wwp_gridstateaddfiltervalue(context ).execute( ref  AV10GridState,  "TFMOVVTIP_SEL",  "Cargo / Abono",  !(AV38TFMovVTip_Sels.Count==0),  0,  AV38TFMovVTip_Sels.ToJSonString(false),  "") ;
         new GeneXus.Programs.wwpbaseobjects.wwp_gridstateaddfiltervalue(context ).execute( ref  AV10GridState,  "TFMOVVSTS_SEL",  "Estado",  !(AV40TFMovVSts_Sels.Count==0),  0,  AV40TFMovVSts_Sels.ToJSonString(false),  "") ;
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
            if ( ( StringUtil.StrCmp(AV15DynamicFiltersSelector1, "MOVVDSC") == 0 ) && ! String.IsNullOrEmpty(StringUtil.RTrim( AV17MovVDsc1)) )
            {
               AV12GridStateDynamicFilter.gxTpr_Dsc = "Movimiento de Venta";
               AV12GridStateDynamicFilter.gxTpr_Value = AV17MovVDsc1;
               AV12GridStateDynamicFilter.gxTpr_Operator = AV16DynamicFiltersOperator1;
            }
            else if ( ( StringUtil.StrCmp(AV15DynamicFiltersSelector1, "MOVVTIP") == 0 ) && ! String.IsNullOrEmpty(StringUtil.RTrim( AV49MovVTip1)) )
            {
               AV12GridStateDynamicFilter.gxTpr_Dsc = "Tipo de Credito / Debito";
               AV12GridStateDynamicFilter.gxTpr_Value = AV49MovVTip1;
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
            if ( ( StringUtil.StrCmp(AV19DynamicFiltersSelector2, "MOVVDSC") == 0 ) && ! String.IsNullOrEmpty(StringUtil.RTrim( AV21MovVDsc2)) )
            {
               AV12GridStateDynamicFilter.gxTpr_Dsc = "Movimiento de Venta";
               AV12GridStateDynamicFilter.gxTpr_Value = AV21MovVDsc2;
               AV12GridStateDynamicFilter.gxTpr_Operator = AV20DynamicFiltersOperator2;
            }
            else if ( ( StringUtil.StrCmp(AV19DynamicFiltersSelector2, "MOVVTIP") == 0 ) && ! String.IsNullOrEmpty(StringUtil.RTrim( AV50MovVTip2)) )
            {
               AV12GridStateDynamicFilter.gxTpr_Dsc = "Tipo de Credito / Debito";
               AV12GridStateDynamicFilter.gxTpr_Value = AV50MovVTip2;
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
            if ( ( StringUtil.StrCmp(AV23DynamicFiltersSelector3, "MOVVDSC") == 0 ) && ! String.IsNullOrEmpty(StringUtil.RTrim( AV25MovVDsc3)) )
            {
               AV12GridStateDynamicFilter.gxTpr_Dsc = "Movimiento de Venta";
               AV12GridStateDynamicFilter.gxTpr_Value = AV25MovVDsc3;
               AV12GridStateDynamicFilter.gxTpr_Operator = AV24DynamicFiltersOperator3;
            }
            else if ( ( StringUtil.StrCmp(AV23DynamicFiltersSelector3, "MOVVTIP") == 0 ) && ! String.IsNullOrEmpty(StringUtil.RTrim( AV51MovVTip3)) )
            {
               AV12GridStateDynamicFilter.gxTpr_Dsc = "Tipo de Credito / Debito";
               AV12GridStateDynamicFilter.gxTpr_Value = AV51MovVTip3;
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
         AV8TrnContext.gxTpr_Transactionname = "Configuracion.MovimientoVenta";
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
         new GeneXus.Programs.configuracion.movimientoventawwexport(context ).execute( out  AV28ExcelFilename, out  AV29ErrorMessage) ;
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
         Innewwindow1_Target = formatLink("configuracion.movimientoventawwexportreport.aspx") ;
         ucInnewwindow1.SendProperty(context, "", false, Innewwindow1_Internalname, "Target", Innewwindow1_Target);
         Innewwindow1_Height = "600";
         ucInnewwindow1.SendProperty(context, "", false, Innewwindow1_Internalname, "Height", Innewwindow1_Height);
         Innewwindow1_Width = "800";
         ucInnewwindow1.SendProperty(context, "", false, Innewwindow1_Internalname, "Width", Innewwindow1_Width);
         this.executeUsercontrolMethod("", false, "INNEWWINDOW1Container", "OpenWindow", "", new Object[] {});
      }

      protected void wb_table1_25_1F2( bool wbgen )
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
            GxWebStd.gx_label_ctrl( context, lblDynamicfiltersprefix1_Internalname, "Buscar en", "", "", lblDynamicfiltersprefix1_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "DataFilterDescriptionPrefix", 0, "", 1, 1, 0, 0, "HLP_Configuracion\\MovimientoVentaWW.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "", "left", "top", "", "flex-grow:1;", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "left", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, cmbavDynamicfiltersselector1_Internalname, "Dynamic Filters Selector1", "gx-form-item AttributeLabel", 0, true, "width: 25%;");
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 35,'',false,'" + sGXsfl_110_idx + "',0)\"";
            /* ComboBox */
            GxWebStd.gx_combobox_ctrl1( context, cmbavDynamicfiltersselector1, cmbavDynamicfiltersselector1_Internalname, StringUtil.RTrim( AV15DynamicFiltersSelector1), 1, cmbavDynamicfiltersselector1_Jsonclick, 5, "'"+""+"'"+",false,"+"'"+"EVDYNAMICFILTERSSELECTOR1.CLICK."+"'", "svchar", "", 1, cmbavDynamicfiltersselector1.Enabled, 0, 0, 0, "em", 0, "", "", "Attribute", "", "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,35);\"", "", true, 1, "HLP_Configuracion\\MovimientoVentaWW.htm");
            cmbavDynamicfiltersselector1.CurrentValue = StringUtil.RTrim( AV15DynamicFiltersSelector1);
            AssignProp("", false, cmbavDynamicfiltersselector1_Internalname, "Values", (string)(cmbavDynamicfiltersselector1.ToJavascriptSource()), true);
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "", "left", "top", "", "flex-grow:1;", "div");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblDynamicfiltersmiddle1_Internalname, "valor", "", "", lblDynamicfiltersmiddle1_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "DataFilterDescription", 0, "", 1, 1, 0, 0, "HLP_Configuracion\\MovimientoVentaWW.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "", "left", "top", "", "flex-grow:1;", "div");
            wb_table2_39_1F2( true) ;
         }
         else
         {
            wb_table2_39_1F2( false) ;
         }
         return  ;
      }

      protected void wb_table2_39_1F2e( bool wbgen )
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
            GxWebStd.gx_label_ctrl( context, lblDynamicfiltersprefix2_Internalname, "Buscar en", "", "", lblDynamicfiltersprefix2_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "DataFilterDescriptionPrefix", 0, "", 1, 1, 0, 0, "HLP_Configuracion\\MovimientoVentaWW.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "Invisible", "left", "top", "", "flex-grow:1;", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "left", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, cmbavDynamicfiltersselector2_Internalname, "Dynamic Filters Selector2", "gx-form-item AttributeLabel", 0, true, "width: 25%;");
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 60,'',false,'" + sGXsfl_110_idx + "',0)\"";
            /* ComboBox */
            GxWebStd.gx_combobox_ctrl1( context, cmbavDynamicfiltersselector2, cmbavDynamicfiltersselector2_Internalname, StringUtil.RTrim( AV19DynamicFiltersSelector2), 1, cmbavDynamicfiltersselector2_Jsonclick, 5, "'"+""+"'"+",false,"+"'"+"EVDYNAMICFILTERSSELECTOR2.CLICK."+"'", "svchar", "", 1, cmbavDynamicfiltersselector2.Enabled, 0, 0, 0, "em", 0, "", "", "Attribute", "", "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,60);\"", "", true, 1, "HLP_Configuracion\\MovimientoVentaWW.htm");
            cmbavDynamicfiltersselector2.CurrentValue = StringUtil.RTrim( AV19DynamicFiltersSelector2);
            AssignProp("", false, cmbavDynamicfiltersselector2_Internalname, "Values", (string)(cmbavDynamicfiltersselector2.ToJavascriptSource()), true);
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "Invisible", "left", "top", "", "flex-grow:1;", "div");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblDynamicfiltersmiddle2_Internalname, "valor", "", "", lblDynamicfiltersmiddle2_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "DataFilterDescription", 0, "", 1, 1, 0, 0, "HLP_Configuracion\\MovimientoVentaWW.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "Invisible", "left", "top", "", "flex-grow:1;", "div");
            wb_table3_64_1F2( true) ;
         }
         else
         {
            wb_table3_64_1F2( false) ;
         }
         return  ;
      }

      protected void wb_table3_64_1F2e( bool wbgen )
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
            GxWebStd.gx_label_ctrl( context, lblDynamicfiltersprefix3_Internalname, "Buscar en", "", "", lblDynamicfiltersprefix3_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "DataFilterDescriptionPrefix", 0, "", 1, 1, 0, 0, "HLP_Configuracion\\MovimientoVentaWW.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "Invisible", "left", "top", "", "flex-grow:1;", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "left", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, cmbavDynamicfiltersselector3_Internalname, "Dynamic Filters Selector3", "gx-form-item AttributeLabel", 0, true, "width: 25%;");
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 85,'',false,'" + sGXsfl_110_idx + "',0)\"";
            /* ComboBox */
            GxWebStd.gx_combobox_ctrl1( context, cmbavDynamicfiltersselector3, cmbavDynamicfiltersselector3_Internalname, StringUtil.RTrim( AV23DynamicFiltersSelector3), 1, cmbavDynamicfiltersselector3_Jsonclick, 5, "'"+""+"'"+",false,"+"'"+"EVDYNAMICFILTERSSELECTOR3.CLICK."+"'", "svchar", "", 1, cmbavDynamicfiltersselector3.Enabled, 0, 0, 0, "em", 0, "", "", "Attribute", "", "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,85);\"", "", true, 1, "HLP_Configuracion\\MovimientoVentaWW.htm");
            cmbavDynamicfiltersselector3.CurrentValue = StringUtil.RTrim( AV23DynamicFiltersSelector3);
            AssignProp("", false, cmbavDynamicfiltersselector3_Internalname, "Values", (string)(cmbavDynamicfiltersselector3.ToJavascriptSource()), true);
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "Invisible", "left", "top", "", "flex-grow:1;", "div");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblDynamicfiltersmiddle3_Internalname, "valor", "", "", lblDynamicfiltersmiddle3_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "DataFilterDescription", 0, "", 1, 1, 0, 0, "HLP_Configuracion\\MovimientoVentaWW.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "Invisible", "left", "top", "", "flex-grow:1;", "div");
            wb_table4_89_1F2( true) ;
         }
         else
         {
            wb_table4_89_1F2( false) ;
         }
         return  ;
      }

      protected void wb_table4_89_1F2e( bool wbgen )
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
            wb_table1_25_1F2e( true) ;
         }
         else
         {
            wb_table1_25_1F2e( false) ;
         }
      }

      protected void wb_table4_89_1F2( bool wbgen )
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
            GxWebStd.gx_combobox_ctrl1( context, cmbavDynamicfiltersoperator3, cmbavDynamicfiltersoperator3_Internalname, StringUtil.Trim( StringUtil.Str( (decimal)(AV24DynamicFiltersOperator3), 4, 0)), 1, cmbavDynamicfiltersoperator3_Jsonclick, 0, "'"+""+"'"+",false,"+"'"+""+"'", "int", "", cmbavDynamicfiltersoperator3.Visible, cmbavDynamicfiltersoperator3.Enabled, 0, 0, 0, "em", 0, "", "", "Attribute", "", "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,93);\"", "", true, 1, "HLP_Configuracion\\MovimientoVentaWW.htm");
            cmbavDynamicfiltersoperator3.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV24DynamicFiltersOperator3), 4, 0));
            AssignProp("", false, cmbavDynamicfiltersoperator3_Internalname, "Values", (string)(cmbavDynamicfiltersoperator3.ToJavascriptSource()), true);
            GxWebStd.gx_div_end( context, "left", "top", "div");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "<td id=\""+cellFilter_movvdsc3_cell_Internalname+"\"  class=''>") ;
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "left", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavMovvdsc3_Internalname, "Mov VDsc3", "gx-form-item AttributeLabel", 0, true, "width: 25%;");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 96,'',false,'" + sGXsfl_110_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavMovvdsc3_Internalname, StringUtil.RTrim( AV25MovVDsc3), StringUtil.RTrim( context.localUtil.Format( AV25MovVDsc3, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,96);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavMovvdsc3_Jsonclick, 0, "Attribute", "", "", "", "", edtavMovvdsc3_Visible, edtavMovvdsc3_Enabled, 0, "text", "", 80, "chr", 1, "row", 100, 0, 0, 0, 1, -1, -1, true, "", "left", true, "", "HLP_Configuracion\\MovimientoVentaWW.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "<td id=\""+cellFilter_movvtip3_cell_Internalname+"\"  class=''>") ;
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "left", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, cmbavMovvtip3_Internalname, "Mov VTip3", "gx-form-item AttributeLabel", 0, true, "width: 25%;");
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 99,'',false,'" + sGXsfl_110_idx + "',0)\"";
            /* ComboBox */
            GxWebStd.gx_combobox_ctrl1( context, cmbavMovvtip3, cmbavMovvtip3_Internalname, StringUtil.RTrim( AV51MovVTip3), 1, cmbavMovvtip3_Jsonclick, 0, "'"+""+"'"+",false,"+"'"+""+"'", "char", "", cmbavMovvtip3.Visible, cmbavMovvtip3.Enabled, 0, 0, 0, "em", 0, "", "", "Attribute", "", "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,99);\"", "", true, 1, "HLP_Configuracion\\MovimientoVentaWW.htm");
            cmbavMovvtip3.CurrentValue = StringUtil.RTrim( AV51MovVTip3);
            AssignProp("", false, cmbavMovvtip3_Internalname, "Values", (string)(cmbavMovvtip3.ToJavascriptSource()), true);
            GxWebStd.gx_div_end( context, "left", "top", "div");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "<td id=\""+cellDynamicfilters_removefilter3_cell_Internalname+"\"  class=''>") ;
            /* Active images/pictures */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 101,'',false,'',0)\"";
            ClassString = "Image";
            StyleString = "";
            sImgUrl = (string)(context.GetImagePath( "11a6ef14-1a5a-4077-91a2-f41ed9a3a662", "", context.GetTheme( )));
            GxWebStd.gx_bitmap( context, imgRemovedynamicfilters3_Internalname, sImgUrl, "", "", "", context.GetTheme( ), 1, 1, "", "Quitar filtro", 0, 0, 0, "px", 0, "px", 0, 0, 5, imgRemovedynamicfilters3_Jsonclick, "'"+""+"'"+",false,"+"'"+"E\\'REMOVEDYNAMICFILTERS3\\'."+"'", StyleString, ClassString, "", "", "", "", " "+"data-gx-image"+" "+TempTags, "", "", 1, false, false, context.GetImageSrcSet( sImgUrl), "HLP_Configuracion\\MovimientoVentaWW.htm");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "</tr>") ;
            /* End of table */
            context.WriteHtmlText( "</table>") ;
            wb_table4_89_1F2e( true) ;
         }
         else
         {
            wb_table4_89_1F2e( false) ;
         }
      }

      protected void wb_table3_64_1F2( bool wbgen )
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
            GxWebStd.gx_combobox_ctrl1( context, cmbavDynamicfiltersoperator2, cmbavDynamicfiltersoperator2_Internalname, StringUtil.Trim( StringUtil.Str( (decimal)(AV20DynamicFiltersOperator2), 4, 0)), 1, cmbavDynamicfiltersoperator2_Jsonclick, 0, "'"+""+"'"+",false,"+"'"+""+"'", "int", "", cmbavDynamicfiltersoperator2.Visible, cmbavDynamicfiltersoperator2.Enabled, 0, 0, 0, "em", 0, "", "", "Attribute", "", "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,68);\"", "", true, 1, "HLP_Configuracion\\MovimientoVentaWW.htm");
            cmbavDynamicfiltersoperator2.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV20DynamicFiltersOperator2), 4, 0));
            AssignProp("", false, cmbavDynamicfiltersoperator2_Internalname, "Values", (string)(cmbavDynamicfiltersoperator2.ToJavascriptSource()), true);
            GxWebStd.gx_div_end( context, "left", "top", "div");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "<td id=\""+cellFilter_movvdsc2_cell_Internalname+"\"  class=''>") ;
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "left", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavMovvdsc2_Internalname, "Mov VDsc2", "gx-form-item AttributeLabel", 0, true, "width: 25%;");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 71,'',false,'" + sGXsfl_110_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavMovvdsc2_Internalname, StringUtil.RTrim( AV21MovVDsc2), StringUtil.RTrim( context.localUtil.Format( AV21MovVDsc2, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,71);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavMovvdsc2_Jsonclick, 0, "Attribute", "", "", "", "", edtavMovvdsc2_Visible, edtavMovvdsc2_Enabled, 0, "text", "", 80, "chr", 1, "row", 100, 0, 0, 0, 1, -1, -1, true, "", "left", true, "", "HLP_Configuracion\\MovimientoVentaWW.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "<td id=\""+cellFilter_movvtip2_cell_Internalname+"\"  class=''>") ;
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "left", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, cmbavMovvtip2_Internalname, "Mov VTip2", "gx-form-item AttributeLabel", 0, true, "width: 25%;");
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 74,'',false,'" + sGXsfl_110_idx + "',0)\"";
            /* ComboBox */
            GxWebStd.gx_combobox_ctrl1( context, cmbavMovvtip2, cmbavMovvtip2_Internalname, StringUtil.RTrim( AV50MovVTip2), 1, cmbavMovvtip2_Jsonclick, 0, "'"+""+"'"+",false,"+"'"+""+"'", "char", "", cmbavMovvtip2.Visible, cmbavMovvtip2.Enabled, 0, 0, 0, "em", 0, "", "", "Attribute", "", "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,74);\"", "", true, 1, "HLP_Configuracion\\MovimientoVentaWW.htm");
            cmbavMovvtip2.CurrentValue = StringUtil.RTrim( AV50MovVTip2);
            AssignProp("", false, cmbavMovvtip2_Internalname, "Values", (string)(cmbavMovvtip2.ToJavascriptSource()), true);
            GxWebStd.gx_div_end( context, "left", "top", "div");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "<td id=\""+cellDynamicfilters_addfilter2_cell_Internalname+"\"  class=''>") ;
            /* Active images/pictures */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 76,'',false,'',0)\"";
            ClassString = "Image";
            StyleString = "";
            sImgUrl = (string)(context.GetImagePath( "27283ea5-332f-423b-b880-64b762622df3", "", context.GetTheme( )));
            GxWebStd.gx_bitmap( context, imgAdddynamicfilters2_Internalname, sImgUrl, "", "", "", context.GetTheme( ), imgAdddynamicfilters2_Visible, 1, "", "Agregar filtro", 0, 0, 0, "px", 0, "px", 0, 0, 5, imgAdddynamicfilters2_Jsonclick, "'"+""+"'"+",false,"+"'"+"E\\'ADDDYNAMICFILTERS2\\'."+"'", StyleString, ClassString, "", "", "", "", " "+"data-gx-image"+" "+TempTags, "", "", 1, false, false, context.GetImageSrcSet( sImgUrl), "HLP_Configuracion\\MovimientoVentaWW.htm");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "<td id=\""+cellDynamicfilters_removefilter2_cell_Internalname+"\"  class=''>") ;
            /* Active images/pictures */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 78,'',false,'',0)\"";
            ClassString = "Image";
            StyleString = "";
            sImgUrl = (string)(context.GetImagePath( "11a6ef14-1a5a-4077-91a2-f41ed9a3a662", "", context.GetTheme( )));
            GxWebStd.gx_bitmap( context, imgRemovedynamicfilters2_Internalname, sImgUrl, "", "", "", context.GetTheme( ), imgRemovedynamicfilters2_Visible, 1, "", "Quitar filtro", 0, 0, 0, "px", 0, "px", 0, 0, 5, imgRemovedynamicfilters2_Jsonclick, "'"+""+"'"+",false,"+"'"+"E\\'REMOVEDYNAMICFILTERS2\\'."+"'", StyleString, ClassString, "", "", "", "", " "+"data-gx-image"+" "+TempTags, "", "", 1, false, false, context.GetImageSrcSet( sImgUrl), "HLP_Configuracion\\MovimientoVentaWW.htm");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "</tr>") ;
            /* End of table */
            context.WriteHtmlText( "</table>") ;
            wb_table3_64_1F2e( true) ;
         }
         else
         {
            wb_table3_64_1F2e( false) ;
         }
      }

      protected void wb_table2_39_1F2( bool wbgen )
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
            GxWebStd.gx_combobox_ctrl1( context, cmbavDynamicfiltersoperator1, cmbavDynamicfiltersoperator1_Internalname, StringUtil.Trim( StringUtil.Str( (decimal)(AV16DynamicFiltersOperator1), 4, 0)), 1, cmbavDynamicfiltersoperator1_Jsonclick, 0, "'"+""+"'"+",false,"+"'"+""+"'", "int", "", cmbavDynamicfiltersoperator1.Visible, cmbavDynamicfiltersoperator1.Enabled, 0, 0, 0, "em", 0, "", "", "Attribute", "", "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,43);\"", "", true, 1, "HLP_Configuracion\\MovimientoVentaWW.htm");
            cmbavDynamicfiltersoperator1.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV16DynamicFiltersOperator1), 4, 0));
            AssignProp("", false, cmbavDynamicfiltersoperator1_Internalname, "Values", (string)(cmbavDynamicfiltersoperator1.ToJavascriptSource()), true);
            GxWebStd.gx_div_end( context, "left", "top", "div");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "<td id=\""+cellFilter_movvdsc1_cell_Internalname+"\"  class=''>") ;
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "left", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavMovvdsc1_Internalname, "Mov VDsc1", "gx-form-item AttributeLabel", 0, true, "width: 25%;");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 46,'',false,'" + sGXsfl_110_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavMovvdsc1_Internalname, StringUtil.RTrim( AV17MovVDsc1), StringUtil.RTrim( context.localUtil.Format( AV17MovVDsc1, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,46);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavMovvdsc1_Jsonclick, 0, "Attribute", "", "", "", "", edtavMovvdsc1_Visible, edtavMovvdsc1_Enabled, 0, "text", "", 80, "chr", 1, "row", 100, 0, 0, 0, 1, -1, -1, true, "", "left", true, "", "HLP_Configuracion\\MovimientoVentaWW.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "<td id=\""+cellFilter_movvtip1_cell_Internalname+"\"  class=''>") ;
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "left", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, cmbavMovvtip1_Internalname, "Mov VTip1", "gx-form-item AttributeLabel", 0, true, "width: 25%;");
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 49,'',false,'" + sGXsfl_110_idx + "',0)\"";
            /* ComboBox */
            GxWebStd.gx_combobox_ctrl1( context, cmbavMovvtip1, cmbavMovvtip1_Internalname, StringUtil.RTrim( AV49MovVTip1), 1, cmbavMovvtip1_Jsonclick, 0, "'"+""+"'"+",false,"+"'"+""+"'", "char", "", cmbavMovvtip1.Visible, cmbavMovvtip1.Enabled, 0, 0, 0, "em", 0, "", "", "Attribute", "", "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,49);\"", "", true, 1, "HLP_Configuracion\\MovimientoVentaWW.htm");
            cmbavMovvtip1.CurrentValue = StringUtil.RTrim( AV49MovVTip1);
            AssignProp("", false, cmbavMovvtip1_Internalname, "Values", (string)(cmbavMovvtip1.ToJavascriptSource()), true);
            GxWebStd.gx_div_end( context, "left", "top", "div");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "<td id=\""+cellDynamicfilters_addfilter1_cell_Internalname+"\"  class=''>") ;
            /* Active images/pictures */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 51,'',false,'',0)\"";
            ClassString = "Image";
            StyleString = "";
            sImgUrl = (string)(context.GetImagePath( "27283ea5-332f-423b-b880-64b762622df3", "", context.GetTheme( )));
            GxWebStd.gx_bitmap( context, imgAdddynamicfilters1_Internalname, sImgUrl, "", "", "", context.GetTheme( ), imgAdddynamicfilters1_Visible, 1, "", "Agregar filtro", 0, 0, 0, "px", 0, "px", 0, 0, 5, imgAdddynamicfilters1_Jsonclick, "'"+""+"'"+",false,"+"'"+"E\\'ADDDYNAMICFILTERS1\\'."+"'", StyleString, ClassString, "", "", "", "", " "+"data-gx-image"+" "+TempTags, "", "", 1, false, false, context.GetImageSrcSet( sImgUrl), "HLP_Configuracion\\MovimientoVentaWW.htm");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "<td id=\""+cellDynamicfilters_removefilter1_cell_Internalname+"\"  class=''>") ;
            /* Active images/pictures */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 53,'',false,'',0)\"";
            ClassString = "Image";
            StyleString = "";
            sImgUrl = (string)(context.GetImagePath( "11a6ef14-1a5a-4077-91a2-f41ed9a3a662", "", context.GetTheme( )));
            GxWebStd.gx_bitmap( context, imgRemovedynamicfilters1_Internalname, sImgUrl, "", "", "", context.GetTheme( ), imgRemovedynamicfilters1_Visible, 1, "", "Quitar filtro", 0, 0, 0, "px", 0, "px", 0, 0, 5, imgRemovedynamicfilters1_Jsonclick, "'"+""+"'"+",false,"+"'"+"E\\'REMOVEDYNAMICFILTERS1\\'."+"'", StyleString, ClassString, "", "", "", "", " "+"data-gx-image"+" "+TempTags, "", "", 1, false, false, context.GetImageSrcSet( sImgUrl), "HLP_Configuracion\\MovimientoVentaWW.htm");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "</tr>") ;
            /* End of table */
            context.WriteHtmlText( "</table>") ;
            wb_table2_39_1F2e( true) ;
         }
         else
         {
            wb_table2_39_1F2e( false) ;
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
         PA1F2( ) ;
         WS1F2( ) ;
         WE1F2( ) ;
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
            context.AddJavascriptSource(StringUtil.RTrim( ((string)Form.Jscriptsrc.Item(idxLst))), "?20228181029711", true, true);
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
         context.AddJavascriptSource("configuracion/movimientoventaww.js", "?20228181029711", false, true);
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
         edtMovVCod_Internalname = "MOVVCOD_"+sGXsfl_110_idx;
         edtMovVDsc_Internalname = "MOVVDSC_"+sGXsfl_110_idx;
         edtMovVAbr_Internalname = "MOVVABR_"+sGXsfl_110_idx;
         cmbMovVTip_Internalname = "MOVVTIP_"+sGXsfl_110_idx;
         cmbMovVSts_Internalname = "MOVVSTS_"+sGXsfl_110_idx;
      }

      protected void SubsflControlProps_fel_1102( )
      {
         cmbavGridactions_Internalname = "vGRIDACTIONS_"+sGXsfl_110_fel_idx;
         edtMovVCod_Internalname = "MOVVCOD_"+sGXsfl_110_fel_idx;
         edtMovVDsc_Internalname = "MOVVDSC_"+sGXsfl_110_fel_idx;
         edtMovVAbr_Internalname = "MOVVABR_"+sGXsfl_110_fel_idx;
         cmbMovVTip_Internalname = "MOVVTIP_"+sGXsfl_110_fel_idx;
         cmbMovVSts_Internalname = "MOVVSTS_"+sGXsfl_110_fel_idx;
      }

      protected void sendrow_1102( )
      {
         SubsflControlProps_1102( ) ;
         WB1F0( ) ;
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
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtMovVCod_Internalname,StringUtil.LTrim( StringUtil.NToC( (decimal)(A235MovVCod), 6, 0, ".", "")),StringUtil.LTrim( context.localUtil.Format( (decimal)(A235MovVCod), "ZZZZZ9")),(string)" inputmode=\"numeric\" pattern=\"[0-9]*\""+"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtMovVCod_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn hidden-xs",(string)"",(short)-1,(short)0,(short)0,(string)"text",(string)"1",(short)0,(string)"px",(short)17,(string)"px",(short)6,(short)0,(short)0,(short)110,(short)1,(short)-1,(short)0,(bool)true,(string)"",(string)"right",(bool)false,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"left"+"\""+" style=\""+""+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtMovVDsc_Internalname,StringUtil.RTrim( A1243MovVDsc),(string)"",(string)"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)edtMovVDsc_Link,(string)"",(string)"",(string)"",(string)edtMovVDsc_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn",(string)"",(short)-1,(short)0,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)100,(short)0,(short)0,(short)110,(short)1,(short)-1,(short)-1,(bool)true,(string)"",(string)"left",(bool)true,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"left"+"\""+" style=\""+""+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtMovVAbr_Internalname,StringUtil.RTrim( A1242MovVAbr),(string)"",(string)"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtMovVAbr_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn hidden-xs",(string)"",(short)-1,(short)0,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)5,(short)0,(short)0,(short)110,(short)1,(short)-1,(short)-1,(bool)true,(string)"",(string)"left",(bool)true,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"left"+"\""+" style=\""+""+"\">") ;
            }
            if ( ( cmbMovVTip.ItemCount == 0 ) && isAjaxCallMode( ) )
            {
               GXCCtl = "MOVVTIP_" + sGXsfl_110_idx;
               cmbMovVTip.Name = GXCCtl;
               cmbMovVTip.WebTags = "";
               cmbMovVTip.addItem("C", "Credito", 0);
               cmbMovVTip.addItem("D", "Debito", 0);
               if ( cmbMovVTip.ItemCount > 0 )
               {
                  A1245MovVTip = cmbMovVTip.getValidValue(A1245MovVTip);
               }
            }
            /* ComboBox */
            GridRow.AddColumnProperties("combobox", 2, isAjaxCallMode( ), new Object[] {(GXCombobox)cmbMovVTip,(string)cmbMovVTip_Internalname,StringUtil.RTrim( A1245MovVTip),(short)1,(string)cmbMovVTip_Jsonclick,(short)0,(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"char",(string)"",(short)-1,(short)0,(short)0,(short)0,(short)0,(string)"px",(short)0,(string)"px",(string)"",(string)"Attribute",(string)"WWColumn hidden-xs",(string)"",(string)"",(string)"",(bool)true,(short)1});
            cmbMovVTip.CurrentValue = StringUtil.RTrim( A1245MovVTip);
            AssignProp("", false, cmbMovVTip_Internalname, "Values", (string)(cmbMovVTip.ToJavascriptSource()), !bGXsfl_110_Refreshing);
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"right"+"\""+" style=\""+""+"\">") ;
            }
            if ( ( cmbMovVSts.ItemCount == 0 ) && isAjaxCallMode( ) )
            {
               GXCCtl = "MOVVSTS_" + sGXsfl_110_idx;
               cmbMovVSts.Name = GXCCtl;
               cmbMovVSts.WebTags = "";
               cmbMovVSts.addItem("1", "ACTIVO", 0);
               cmbMovVSts.addItem("0", "INACTIVO", 0);
               if ( cmbMovVSts.ItemCount > 0 )
               {
                  A1244MovVSts = (short)(NumberUtil.Val( cmbMovVSts.getValidValue(StringUtil.Trim( StringUtil.Str( (decimal)(A1244MovVSts), 1, 0))), "."));
               }
            }
            /* ComboBox */
            GridRow.AddColumnProperties("combobox", 2, isAjaxCallMode( ), new Object[] {(GXCombobox)cmbMovVSts,(string)cmbMovVSts_Internalname,StringUtil.Trim( StringUtil.Str( (decimal)(A1244MovVSts), 1, 0)),(short)1,(string)cmbMovVSts_Jsonclick,(short)0,(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"int",(string)"",(short)-1,(short)0,(short)0,(short)0,(short)0,(string)"px",(short)0,(string)"px",(string)"",(string)"Attribute",(string)"WWColumn hidden-xs",(string)"",(string)"",(string)"",(bool)true,(short)1});
            cmbMovVSts.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(A1244MovVSts), 1, 0));
            AssignProp("", false, cmbMovVSts_Internalname, "Values", (string)(cmbMovVSts.ToJavascriptSource()), !bGXsfl_110_Refreshing);
            send_integrity_lvl_hashes1F2( ) ;
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
         cmbavDynamicfiltersselector1.addItem("MOVVDSC", "Movimiento de Venta", 0);
         cmbavDynamicfiltersselector1.addItem("MOVVTIP", "Tipo de Credito / Debito", 0);
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
         cmbavMovvtip1.Name = "vMOVVTIP1";
         cmbavMovvtip1.WebTags = "";
         cmbavMovvtip1.addItem("", "Todos", 0);
         cmbavMovvtip1.addItem("C", "Credito", 0);
         cmbavMovvtip1.addItem("D", "Debito", 0);
         if ( cmbavMovvtip1.ItemCount > 0 )
         {
            AV49MovVTip1 = cmbavMovvtip1.getValidValue(AV49MovVTip1);
            AssignAttri("", false, "AV49MovVTip1", AV49MovVTip1);
         }
         cmbavDynamicfiltersselector2.Name = "vDYNAMICFILTERSSELECTOR2";
         cmbavDynamicfiltersselector2.WebTags = "";
         cmbavDynamicfiltersselector2.addItem("MOVVDSC", "Movimiento de Venta", 0);
         cmbavDynamicfiltersselector2.addItem("MOVVTIP", "Tipo de Credito / Debito", 0);
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
         cmbavMovvtip2.Name = "vMOVVTIP2";
         cmbavMovvtip2.WebTags = "";
         cmbavMovvtip2.addItem("", "Todos", 0);
         cmbavMovvtip2.addItem("C", "Credito", 0);
         cmbavMovvtip2.addItem("D", "Debito", 0);
         if ( cmbavMovvtip2.ItemCount > 0 )
         {
            AV50MovVTip2 = cmbavMovvtip2.getValidValue(AV50MovVTip2);
            AssignAttri("", false, "AV50MovVTip2", AV50MovVTip2);
         }
         cmbavDynamicfiltersselector3.Name = "vDYNAMICFILTERSSELECTOR3";
         cmbavDynamicfiltersselector3.WebTags = "";
         cmbavDynamicfiltersselector3.addItem("MOVVDSC", "Movimiento de Venta", 0);
         cmbavDynamicfiltersselector3.addItem("MOVVTIP", "Tipo de Credito / Debito", 0);
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
         cmbavMovvtip3.Name = "vMOVVTIP3";
         cmbavMovvtip3.WebTags = "";
         cmbavMovvtip3.addItem("", "Todos", 0);
         cmbavMovvtip3.addItem("C", "Credito", 0);
         cmbavMovvtip3.addItem("D", "Debito", 0);
         if ( cmbavMovvtip3.ItemCount > 0 )
         {
            AV51MovVTip3 = cmbavMovvtip3.getValidValue(AV51MovVTip3);
            AssignAttri("", false, "AV51MovVTip3", AV51MovVTip3);
         }
         GXCCtl = "vGRIDACTIONS_" + sGXsfl_110_idx;
         cmbavGridactions.Name = GXCCtl;
         cmbavGridactions.WebTags = "";
         if ( cmbavGridactions.ItemCount > 0 )
         {
            AV46GridActions = (short)(NumberUtil.Val( cmbavGridactions.getValidValue(StringUtil.Trim( StringUtil.Str( (decimal)(AV46GridActions), 4, 0))), "."));
            AssignAttri("", false, cmbavGridactions_Internalname, StringUtil.LTrimStr( (decimal)(AV46GridActions), 4, 0));
         }
         GXCCtl = "MOVVTIP_" + sGXsfl_110_idx;
         cmbMovVTip.Name = GXCCtl;
         cmbMovVTip.WebTags = "";
         cmbMovVTip.addItem("C", "Credito", 0);
         cmbMovVTip.addItem("D", "Debito", 0);
         if ( cmbMovVTip.ItemCount > 0 )
         {
            A1245MovVTip = cmbMovVTip.getValidValue(A1245MovVTip);
         }
         GXCCtl = "MOVVSTS_" + sGXsfl_110_idx;
         cmbMovVSts.Name = GXCCtl;
         cmbMovVSts.WebTags = "";
         cmbMovVSts.addItem("1", "ACTIVO", 0);
         cmbMovVSts.addItem("0", "INACTIVO", 0);
         if ( cmbMovVSts.ItemCount > 0 )
         {
            A1244MovVSts = (short)(NumberUtil.Val( cmbMovVSts.getValidValue(StringUtil.Trim( StringUtil.Str( (decimal)(A1244MovVSts), 1, 0))), "."));
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
         edtavMovvdsc1_Internalname = "vMOVVDSC1";
         cellFilter_movvdsc1_cell_Internalname = "FILTER_MOVVDSC1_CELL";
         cmbavMovvtip1_Internalname = "vMOVVTIP1";
         cellFilter_movvtip1_cell_Internalname = "FILTER_MOVVTIP1_CELL";
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
         edtavMovvdsc2_Internalname = "vMOVVDSC2";
         cellFilter_movvdsc2_cell_Internalname = "FILTER_MOVVDSC2_CELL";
         cmbavMovvtip2_Internalname = "vMOVVTIP2";
         cellFilter_movvtip2_cell_Internalname = "FILTER_MOVVTIP2_CELL";
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
         edtavMovvdsc3_Internalname = "vMOVVDSC3";
         cellFilter_movvdsc3_cell_Internalname = "FILTER_MOVVDSC3_CELL";
         cmbavMovvtip3_Internalname = "vMOVVTIP3";
         cellFilter_movvtip3_cell_Internalname = "FILTER_MOVVTIP3_CELL";
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
         edtMovVCod_Internalname = "MOVVCOD";
         edtMovVDsc_Internalname = "MOVVDSC";
         edtMovVAbr_Internalname = "MOVVABR";
         cmbMovVTip_Internalname = "MOVVTIP";
         cmbMovVSts_Internalname = "MOVVSTS";
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
         cmbMovVSts_Jsonclick = "";
         cmbMovVTip_Jsonclick = "";
         edtMovVAbr_Jsonclick = "";
         edtMovVDsc_Jsonclick = "";
         edtMovVCod_Jsonclick = "";
         cmbavGridactions_Jsonclick = "";
         cmbavGridactions.Visible = -1;
         cmbavGridactions.Enabled = 1;
         imgRemovedynamicfilters1_Visible = 1;
         imgAdddynamicfilters1_Visible = 1;
         cmbavMovvtip1_Jsonclick = "";
         cmbavMovvtip1.Enabled = 1;
         edtavMovvdsc1_Jsonclick = "";
         edtavMovvdsc1_Enabled = 1;
         cmbavDynamicfiltersoperator1_Jsonclick = "";
         cmbavDynamicfiltersoperator1.Enabled = 1;
         imgRemovedynamicfilters2_Visible = 1;
         imgAdddynamicfilters2_Visible = 1;
         cmbavMovvtip2_Jsonclick = "";
         cmbavMovvtip2.Enabled = 1;
         edtavMovvdsc2_Jsonclick = "";
         edtavMovvdsc2_Enabled = 1;
         cmbavDynamicfiltersoperator2_Jsonclick = "";
         cmbavDynamicfiltersoperator2.Enabled = 1;
         cmbavMovvtip3_Jsonclick = "";
         cmbavMovvtip3.Enabled = 1;
         edtavMovvdsc3_Jsonclick = "";
         edtavMovvdsc3_Enabled = 1;
         cmbavDynamicfiltersoperator3_Jsonclick = "";
         cmbavDynamicfiltersoperator3.Enabled = 1;
         cmbavDynamicfiltersselector3_Jsonclick = "";
         cmbavDynamicfiltersselector3.Enabled = 1;
         cmbavDynamicfiltersselector2_Jsonclick = "";
         cmbavDynamicfiltersselector2.Enabled = 1;
         cmbavDynamicfiltersselector1_Jsonclick = "";
         cmbavDynamicfiltersselector1.Enabled = 1;
         cmbavDynamicfiltersoperator3.Visible = 1;
         cmbavMovvtip3.Visible = 1;
         edtavMovvdsc3_Visible = 1;
         cmbavDynamicfiltersoperator2.Visible = 1;
         cmbavMovvtip2.Visible = 1;
         edtavMovvdsc2_Visible = 1;
         cmbavDynamicfiltersoperator1.Visible = 1;
         cmbavMovvtip1.Visible = 1;
         edtavMovvdsc1_Visible = 1;
         lblJsdynamicfilters_Caption = "JSDynamicFilters";
         subGrid_Allowcollapsing = 0;
         subGrid_Allowselection = 0;
         edtMovVDsc_Link = "";
         subGrid_Sortable = 0;
         subGrid_Header = "";
         subGrid_Class = "GridWithPaginationBar WorkWith";
         subGrid_Backcolorstyle = 0;
         Grid_empowerer_Hastitlesettings = Convert.ToBoolean( -1);
         Innewwindow1_Target = "";
         Innewwindow1_Height = "50";
         Innewwindow1_Width = "50";
         Ddo_grid_Datalistproc = "Configuracion.MovimientoVentaWWGetFilterData";
         Ddo_grid_Datalistfixedvalues = "||SI:SI,NO:NO|C:Credito,D:Debito|1:ACTIVO,0:INACTIVO";
         Ddo_grid_Allowmultipleselection = "||T|T|T";
         Ddo_grid_Datalisttype = "|Dynamic|FixedValues|FixedValues|FixedValues";
         Ddo_grid_Includedatalist = "|T|T|T|T";
         Ddo_grid_Filterisrange = "T||||";
         Ddo_grid_Filtertype = "Numeric|Character|||";
         Ddo_grid_Includefilter = "T|T|||";
         Ddo_grid_Includesortasc = "T";
         Ddo_grid_Columnssortvalues = "1|2|3|4|5";
         Ddo_grid_Columnids = "1:MovVCod|2:MovVDsc|3:MovVAbr|4:MovVTip|5:MovVSts";
         Ddo_grid_Gridinternalname = "";
         Ddo_agexport_Titlecontrolidtoreplace = "";
         Ddo_agexport_Cls = "ColumnsSelector";
         Ddo_agexport_Icon = "fas fa-download";
         Ddo_agexport_Icontype = "FontIcon";
         Gridpaginationbar_Rowsperpagecaption = "WWP_PagingRowsPerPage";
         Gridpaginationbar_Emptygridcaption = "WWP_PagingEmptyGridCaption";
         Gridpaginationbar_Caption = "P�gina <CURRENT_PAGE> de <TOTAL_PAGES>";
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
         Form.Caption = " Movimientos de Credito / Debito";
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
         setEventMetadata("REFRESH","{handler:'Refresh',iparms:[{av:'GRID_nFirstRecordOnPage'},{av:'GRID_nEOF'},{av:'subGrid_Rows',ctrl:'GRID',prop:'Rows'},{av:'cmbavDynamicfiltersselector1'},{av:'AV15DynamicFiltersSelector1',fld:'vDYNAMICFILTERSSELECTOR1',pic:''},{av:'cmbavDynamicfiltersoperator1'},{av:'AV16DynamicFiltersOperator1',fld:'vDYNAMICFILTERSOPERATOR1',pic:'ZZZ9'},{av:'AV17MovVDsc1',fld:'vMOVVDSC1',pic:''},{av:'cmbavMovvtip1'},{av:'AV49MovVTip1',fld:'vMOVVTIP1',pic:''},{av:'cmbavDynamicfiltersselector2'},{av:'AV19DynamicFiltersSelector2',fld:'vDYNAMICFILTERSSELECTOR2',pic:''},{av:'cmbavDynamicfiltersoperator2'},{av:'AV20DynamicFiltersOperator2',fld:'vDYNAMICFILTERSOPERATOR2',pic:'ZZZ9'},{av:'AV21MovVDsc2',fld:'vMOVVDSC2',pic:''},{av:'cmbavMovvtip2'},{av:'AV50MovVTip2',fld:'vMOVVTIP2',pic:''},{av:'cmbavDynamicfiltersselector3'},{av:'AV23DynamicFiltersSelector3',fld:'vDYNAMICFILTERSSELECTOR3',pic:''},{av:'cmbavDynamicfiltersoperator3'},{av:'AV24DynamicFiltersOperator3',fld:'vDYNAMICFILTERSOPERATOR3',pic:'ZZZ9'},{av:'AV25MovVDsc3',fld:'vMOVVDSC3',pic:''},{av:'cmbavMovvtip3'},{av:'AV51MovVTip3',fld:'vMOVVTIP3',pic:''},{av:'AV54Pgmname',fld:'vPGMNAME',pic:'',hsh:true},{av:'AV18DynamicFiltersEnabled2',fld:'vDYNAMICFILTERSENABLED2',pic:''},{av:'AV22DynamicFiltersEnabled3',fld:'vDYNAMICFILTERSENABLED3',pic:''},{av:'AV31TFMovVCod',fld:'vTFMOVVCOD',pic:'ZZZZZ9'},{av:'AV32TFMovVCod_To',fld:'vTFMOVVCOD_TO',pic:'ZZZZZ9'},{av:'AV33TFMovVDsc',fld:'vTFMOVVDSC',pic:''},{av:'AV34TFMovVDsc_Sel',fld:'vTFMOVVDSC_SEL',pic:''},{av:'AV36TFMovVAbr_Sels',fld:'vTFMOVVABR_SELS',pic:''},{av:'AV38TFMovVTip_Sels',fld:'vTFMOVVTIP_SELS',pic:''},{av:'AV40TFMovVSts_Sels',fld:'vTFMOVVSTS_SELS',pic:''},{av:'AV13OrderedBy',fld:'vORDEREDBY',pic:'ZZZ9'},{av:'AV14OrderedDsc',fld:'vORDEREDDSC',pic:''},{av:'AV10GridState',fld:'vGRIDSTATE',pic:''},{av:'AV27DynamicFiltersIgnoreFirst',fld:'vDYNAMICFILTERSIGNOREFIRST',pic:''},{av:'AV26DynamicFiltersRemoving',fld:'vDYNAMICFILTERSREMOVING',pic:''}]");
         setEventMetadata("REFRESH",",oparms:[{av:'AV43GridCurrentPage',fld:'vGRIDCURRENTPAGE',pic:'ZZZZZZZZZ9'},{av:'AV44GridPageCount',fld:'vGRIDPAGECOUNT',pic:'ZZZZZZZZZ9'},{av:'AV45GridAppliedFilters',fld:'vGRIDAPPLIEDFILTERS',pic:''},{av:'AV10GridState',fld:'vGRIDSTATE',pic:''}]}");
         setEventMetadata("GRIDPAGINATIONBAR.CHANGEPAGE","{handler:'E111F2',iparms:[{av:'GRID_nFirstRecordOnPage'},{av:'GRID_nEOF'},{av:'subGrid_Rows',ctrl:'GRID',prop:'Rows'},{av:'cmbavDynamicfiltersselector1'},{av:'AV15DynamicFiltersSelector1',fld:'vDYNAMICFILTERSSELECTOR1',pic:''},{av:'cmbavDynamicfiltersoperator1'},{av:'AV16DynamicFiltersOperator1',fld:'vDYNAMICFILTERSOPERATOR1',pic:'ZZZ9'},{av:'AV17MovVDsc1',fld:'vMOVVDSC1',pic:''},{av:'cmbavMovvtip1'},{av:'AV49MovVTip1',fld:'vMOVVTIP1',pic:''},{av:'cmbavDynamicfiltersselector2'},{av:'AV19DynamicFiltersSelector2',fld:'vDYNAMICFILTERSSELECTOR2',pic:''},{av:'cmbavDynamicfiltersoperator2'},{av:'AV20DynamicFiltersOperator2',fld:'vDYNAMICFILTERSOPERATOR2',pic:'ZZZ9'},{av:'AV21MovVDsc2',fld:'vMOVVDSC2',pic:''},{av:'cmbavMovvtip2'},{av:'AV50MovVTip2',fld:'vMOVVTIP2',pic:''},{av:'cmbavDynamicfiltersselector3'},{av:'AV23DynamicFiltersSelector3',fld:'vDYNAMICFILTERSSELECTOR3',pic:''},{av:'cmbavDynamicfiltersoperator3'},{av:'AV24DynamicFiltersOperator3',fld:'vDYNAMICFILTERSOPERATOR3',pic:'ZZZ9'},{av:'AV25MovVDsc3',fld:'vMOVVDSC3',pic:''},{av:'cmbavMovvtip3'},{av:'AV51MovVTip3',fld:'vMOVVTIP3',pic:''},{av:'AV54Pgmname',fld:'vPGMNAME',pic:'',hsh:true},{av:'AV18DynamicFiltersEnabled2',fld:'vDYNAMICFILTERSENABLED2',pic:''},{av:'AV22DynamicFiltersEnabled3',fld:'vDYNAMICFILTERSENABLED3',pic:''},{av:'AV31TFMovVCod',fld:'vTFMOVVCOD',pic:'ZZZZZ9'},{av:'AV32TFMovVCod_To',fld:'vTFMOVVCOD_TO',pic:'ZZZZZ9'},{av:'AV33TFMovVDsc',fld:'vTFMOVVDSC',pic:''},{av:'AV34TFMovVDsc_Sel',fld:'vTFMOVVDSC_SEL',pic:''},{av:'AV36TFMovVAbr_Sels',fld:'vTFMOVVABR_SELS',pic:''},{av:'AV38TFMovVTip_Sels',fld:'vTFMOVVTIP_SELS',pic:''},{av:'AV40TFMovVSts_Sels',fld:'vTFMOVVSTS_SELS',pic:''},{av:'AV13OrderedBy',fld:'vORDEREDBY',pic:'ZZZ9'},{av:'AV14OrderedDsc',fld:'vORDEREDDSC',pic:''},{av:'AV10GridState',fld:'vGRIDSTATE',pic:''},{av:'AV27DynamicFiltersIgnoreFirst',fld:'vDYNAMICFILTERSIGNOREFIRST',pic:''},{av:'AV26DynamicFiltersRemoving',fld:'vDYNAMICFILTERSREMOVING',pic:''},{av:'Gridpaginationbar_Selectedpage',ctrl:'GRIDPAGINATIONBAR',prop:'SelectedPage'}]");
         setEventMetadata("GRIDPAGINATIONBAR.CHANGEPAGE",",oparms:[]}");
         setEventMetadata("GRIDPAGINATIONBAR.CHANGEROWSPERPAGE","{handler:'E121F2',iparms:[{av:'GRID_nFirstRecordOnPage'},{av:'GRID_nEOF'},{av:'subGrid_Rows',ctrl:'GRID',prop:'Rows'},{av:'cmbavDynamicfiltersselector1'},{av:'AV15DynamicFiltersSelector1',fld:'vDYNAMICFILTERSSELECTOR1',pic:''},{av:'cmbavDynamicfiltersoperator1'},{av:'AV16DynamicFiltersOperator1',fld:'vDYNAMICFILTERSOPERATOR1',pic:'ZZZ9'},{av:'AV17MovVDsc1',fld:'vMOVVDSC1',pic:''},{av:'cmbavMovvtip1'},{av:'AV49MovVTip1',fld:'vMOVVTIP1',pic:''},{av:'cmbavDynamicfiltersselector2'},{av:'AV19DynamicFiltersSelector2',fld:'vDYNAMICFILTERSSELECTOR2',pic:''},{av:'cmbavDynamicfiltersoperator2'},{av:'AV20DynamicFiltersOperator2',fld:'vDYNAMICFILTERSOPERATOR2',pic:'ZZZ9'},{av:'AV21MovVDsc2',fld:'vMOVVDSC2',pic:''},{av:'cmbavMovvtip2'},{av:'AV50MovVTip2',fld:'vMOVVTIP2',pic:''},{av:'cmbavDynamicfiltersselector3'},{av:'AV23DynamicFiltersSelector3',fld:'vDYNAMICFILTERSSELECTOR3',pic:''},{av:'cmbavDynamicfiltersoperator3'},{av:'AV24DynamicFiltersOperator3',fld:'vDYNAMICFILTERSOPERATOR3',pic:'ZZZ9'},{av:'AV25MovVDsc3',fld:'vMOVVDSC3',pic:''},{av:'cmbavMovvtip3'},{av:'AV51MovVTip3',fld:'vMOVVTIP3',pic:''},{av:'AV54Pgmname',fld:'vPGMNAME',pic:'',hsh:true},{av:'AV18DynamicFiltersEnabled2',fld:'vDYNAMICFILTERSENABLED2',pic:''},{av:'AV22DynamicFiltersEnabled3',fld:'vDYNAMICFILTERSENABLED3',pic:''},{av:'AV31TFMovVCod',fld:'vTFMOVVCOD',pic:'ZZZZZ9'},{av:'AV32TFMovVCod_To',fld:'vTFMOVVCOD_TO',pic:'ZZZZZ9'},{av:'AV33TFMovVDsc',fld:'vTFMOVVDSC',pic:''},{av:'AV34TFMovVDsc_Sel',fld:'vTFMOVVDSC_SEL',pic:''},{av:'AV36TFMovVAbr_Sels',fld:'vTFMOVVABR_SELS',pic:''},{av:'AV38TFMovVTip_Sels',fld:'vTFMOVVTIP_SELS',pic:''},{av:'AV40TFMovVSts_Sels',fld:'vTFMOVVSTS_SELS',pic:''},{av:'AV13OrderedBy',fld:'vORDEREDBY',pic:'ZZZ9'},{av:'AV14OrderedDsc',fld:'vORDEREDDSC',pic:''},{av:'AV10GridState',fld:'vGRIDSTATE',pic:''},{av:'AV27DynamicFiltersIgnoreFirst',fld:'vDYNAMICFILTERSIGNOREFIRST',pic:''},{av:'AV26DynamicFiltersRemoving',fld:'vDYNAMICFILTERSREMOVING',pic:''},{av:'Gridpaginationbar_Rowsperpageselectedvalue',ctrl:'GRIDPAGINATIONBAR',prop:'RowsPerPageSelectedValue'}]");
         setEventMetadata("GRIDPAGINATIONBAR.CHANGEROWSPERPAGE",",oparms:[{av:'subGrid_Rows',ctrl:'GRID',prop:'Rows'}]}");
         setEventMetadata("DDO_GRID.ONOPTIONCLICKED","{handler:'E141F2',iparms:[{av:'GRID_nFirstRecordOnPage'},{av:'GRID_nEOF'},{av:'subGrid_Rows',ctrl:'GRID',prop:'Rows'},{av:'cmbavDynamicfiltersselector1'},{av:'AV15DynamicFiltersSelector1',fld:'vDYNAMICFILTERSSELECTOR1',pic:''},{av:'cmbavDynamicfiltersoperator1'},{av:'AV16DynamicFiltersOperator1',fld:'vDYNAMICFILTERSOPERATOR1',pic:'ZZZ9'},{av:'AV17MovVDsc1',fld:'vMOVVDSC1',pic:''},{av:'cmbavMovvtip1'},{av:'AV49MovVTip1',fld:'vMOVVTIP1',pic:''},{av:'cmbavDynamicfiltersselector2'},{av:'AV19DynamicFiltersSelector2',fld:'vDYNAMICFILTERSSELECTOR2',pic:''},{av:'cmbavDynamicfiltersoperator2'},{av:'AV20DynamicFiltersOperator2',fld:'vDYNAMICFILTERSOPERATOR2',pic:'ZZZ9'},{av:'AV21MovVDsc2',fld:'vMOVVDSC2',pic:''},{av:'cmbavMovvtip2'},{av:'AV50MovVTip2',fld:'vMOVVTIP2',pic:''},{av:'cmbavDynamicfiltersselector3'},{av:'AV23DynamicFiltersSelector3',fld:'vDYNAMICFILTERSSELECTOR3',pic:''},{av:'cmbavDynamicfiltersoperator3'},{av:'AV24DynamicFiltersOperator3',fld:'vDYNAMICFILTERSOPERATOR3',pic:'ZZZ9'},{av:'AV25MovVDsc3',fld:'vMOVVDSC3',pic:''},{av:'cmbavMovvtip3'},{av:'AV51MovVTip3',fld:'vMOVVTIP3',pic:''},{av:'AV54Pgmname',fld:'vPGMNAME',pic:'',hsh:true},{av:'AV18DynamicFiltersEnabled2',fld:'vDYNAMICFILTERSENABLED2',pic:''},{av:'AV22DynamicFiltersEnabled3',fld:'vDYNAMICFILTERSENABLED3',pic:''},{av:'AV31TFMovVCod',fld:'vTFMOVVCOD',pic:'ZZZZZ9'},{av:'AV32TFMovVCod_To',fld:'vTFMOVVCOD_TO',pic:'ZZZZZ9'},{av:'AV33TFMovVDsc',fld:'vTFMOVVDSC',pic:''},{av:'AV34TFMovVDsc_Sel',fld:'vTFMOVVDSC_SEL',pic:''},{av:'AV36TFMovVAbr_Sels',fld:'vTFMOVVABR_SELS',pic:''},{av:'AV38TFMovVTip_Sels',fld:'vTFMOVVTIP_SELS',pic:''},{av:'AV40TFMovVSts_Sels',fld:'vTFMOVVSTS_SELS',pic:''},{av:'AV13OrderedBy',fld:'vORDEREDBY',pic:'ZZZ9'},{av:'AV14OrderedDsc',fld:'vORDEREDDSC',pic:''},{av:'AV10GridState',fld:'vGRIDSTATE',pic:''},{av:'AV27DynamicFiltersIgnoreFirst',fld:'vDYNAMICFILTERSIGNOREFIRST',pic:''},{av:'AV26DynamicFiltersRemoving',fld:'vDYNAMICFILTERSREMOVING',pic:''},{av:'Ddo_grid_Activeeventkey',ctrl:'DDO_GRID',prop:'ActiveEventKey'},{av:'Ddo_grid_Selectedvalue_get',ctrl:'DDO_GRID',prop:'SelectedValue_get'},{av:'Ddo_grid_Selectedcolumn',ctrl:'DDO_GRID',prop:'SelectedColumn'},{av:'Ddo_grid_Filteredtext_get',ctrl:'DDO_GRID',prop:'FilteredText_get'},{av:'Ddo_grid_Filteredtextto_get',ctrl:'DDO_GRID',prop:'FilteredTextTo_get'}]");
         setEventMetadata("DDO_GRID.ONOPTIONCLICKED",",oparms:[{av:'AV13OrderedBy',fld:'vORDEREDBY',pic:'ZZZ9'},{av:'AV14OrderedDsc',fld:'vORDEREDDSC',pic:''},{av:'AV31TFMovVCod',fld:'vTFMOVVCOD',pic:'ZZZZZ9'},{av:'AV32TFMovVCod_To',fld:'vTFMOVVCOD_TO',pic:'ZZZZZ9'},{av:'AV33TFMovVDsc',fld:'vTFMOVVDSC',pic:''},{av:'AV34TFMovVDsc_Sel',fld:'vTFMOVVDSC_SEL',pic:''},{av:'AV35TFMovVAbr_SelsJson',fld:'vTFMOVVABR_SELSJSON',pic:''},{av:'AV36TFMovVAbr_Sels',fld:'vTFMOVVABR_SELS',pic:''},{av:'AV37TFMovVTip_SelsJson',fld:'vTFMOVVTIP_SELSJSON',pic:''},{av:'AV38TFMovVTip_Sels',fld:'vTFMOVVTIP_SELS',pic:''},{av:'AV39TFMovVSts_SelsJson',fld:'vTFMOVVSTS_SELSJSON',pic:''},{av:'AV40TFMovVSts_Sels',fld:'vTFMOVVSTS_SELS',pic:''},{av:'Ddo_grid_Sortedstatus',ctrl:'DDO_GRID',prop:'SortedStatus'}]}");
         setEventMetadata("GRID.LOAD","{handler:'E261F2',iparms:[{av:'A235MovVCod',fld:'MOVVCOD',pic:'ZZZZZ9',hsh:true}]");
         setEventMetadata("GRID.LOAD",",oparms:[{av:'cmbavGridactions'},{av:'AV46GridActions',fld:'vGRIDACTIONS',pic:'ZZZ9'},{av:'edtMovVDsc_Link',ctrl:'MOVVDSC',prop:'Link'}]}");
         setEventMetadata("'ADDDYNAMICFILTERS1'","{handler:'E191F2',iparms:[]");
         setEventMetadata("'ADDDYNAMICFILTERS1'",",oparms:[{av:'AV18DynamicFiltersEnabled2',fld:'vDYNAMICFILTERSENABLED2',pic:''},{av:'imgAdddynamicfilters1_Visible',ctrl:'ADDDYNAMICFILTERS1',prop:'Visible'},{av:'imgRemovedynamicfilters1_Visible',ctrl:'REMOVEDYNAMICFILTERS1',prop:'Visible'}]}");
         setEventMetadata("'REMOVEDYNAMICFILTERS1'","{handler:'E151F2',iparms:[{av:'GRID_nFirstRecordOnPage'},{av:'GRID_nEOF'},{av:'subGrid_Rows',ctrl:'GRID',prop:'Rows'},{av:'cmbavDynamicfiltersselector1'},{av:'AV15DynamicFiltersSelector1',fld:'vDYNAMICFILTERSSELECTOR1',pic:''},{av:'cmbavDynamicfiltersoperator1'},{av:'AV16DynamicFiltersOperator1',fld:'vDYNAMICFILTERSOPERATOR1',pic:'ZZZ9'},{av:'AV17MovVDsc1',fld:'vMOVVDSC1',pic:''},{av:'cmbavMovvtip1'},{av:'AV49MovVTip1',fld:'vMOVVTIP1',pic:''},{av:'cmbavDynamicfiltersselector2'},{av:'AV19DynamicFiltersSelector2',fld:'vDYNAMICFILTERSSELECTOR2',pic:''},{av:'cmbavDynamicfiltersoperator2'},{av:'AV20DynamicFiltersOperator2',fld:'vDYNAMICFILTERSOPERATOR2',pic:'ZZZ9'},{av:'AV21MovVDsc2',fld:'vMOVVDSC2',pic:''},{av:'cmbavMovvtip2'},{av:'AV50MovVTip2',fld:'vMOVVTIP2',pic:''},{av:'cmbavDynamicfiltersselector3'},{av:'AV23DynamicFiltersSelector3',fld:'vDYNAMICFILTERSSELECTOR3',pic:''},{av:'cmbavDynamicfiltersoperator3'},{av:'AV24DynamicFiltersOperator3',fld:'vDYNAMICFILTERSOPERATOR3',pic:'ZZZ9'},{av:'AV25MovVDsc3',fld:'vMOVVDSC3',pic:''},{av:'cmbavMovvtip3'},{av:'AV51MovVTip3',fld:'vMOVVTIP3',pic:''},{av:'AV54Pgmname',fld:'vPGMNAME',pic:'',hsh:true},{av:'AV18DynamicFiltersEnabled2',fld:'vDYNAMICFILTERSENABLED2',pic:''},{av:'AV22DynamicFiltersEnabled3',fld:'vDYNAMICFILTERSENABLED3',pic:''},{av:'AV31TFMovVCod',fld:'vTFMOVVCOD',pic:'ZZZZZ9'},{av:'AV32TFMovVCod_To',fld:'vTFMOVVCOD_TO',pic:'ZZZZZ9'},{av:'AV33TFMovVDsc',fld:'vTFMOVVDSC',pic:''},{av:'AV34TFMovVDsc_Sel',fld:'vTFMOVVDSC_SEL',pic:''},{av:'AV36TFMovVAbr_Sels',fld:'vTFMOVVABR_SELS',pic:''},{av:'AV38TFMovVTip_Sels',fld:'vTFMOVVTIP_SELS',pic:''},{av:'AV40TFMovVSts_Sels',fld:'vTFMOVVSTS_SELS',pic:''},{av:'AV13OrderedBy',fld:'vORDEREDBY',pic:'ZZZ9'},{av:'AV14OrderedDsc',fld:'vORDEREDDSC',pic:''},{av:'AV10GridState',fld:'vGRIDSTATE',pic:''},{av:'AV27DynamicFiltersIgnoreFirst',fld:'vDYNAMICFILTERSIGNOREFIRST',pic:''},{av:'AV26DynamicFiltersRemoving',fld:'vDYNAMICFILTERSREMOVING',pic:''}]");
         setEventMetadata("'REMOVEDYNAMICFILTERS1'",",oparms:[{av:'AV26DynamicFiltersRemoving',fld:'vDYNAMICFILTERSREMOVING',pic:''},{av:'AV27DynamicFiltersIgnoreFirst',fld:'vDYNAMICFILTERSIGNOREFIRST',pic:''},{av:'AV10GridState',fld:'vGRIDSTATE',pic:''},{av:'AV18DynamicFiltersEnabled2',fld:'vDYNAMICFILTERSENABLED2',pic:''},{av:'cmbavDynamicfiltersselector2'},{av:'AV19DynamicFiltersSelector2',fld:'vDYNAMICFILTERSSELECTOR2',pic:''},{av:'cmbavDynamicfiltersoperator2'},{av:'AV20DynamicFiltersOperator2',fld:'vDYNAMICFILTERSOPERATOR2',pic:'ZZZ9'},{av:'AV21MovVDsc2',fld:'vMOVVDSC2',pic:''},{av:'AV22DynamicFiltersEnabled3',fld:'vDYNAMICFILTERSENABLED3',pic:''},{av:'cmbavDynamicfiltersselector3'},{av:'AV23DynamicFiltersSelector3',fld:'vDYNAMICFILTERSSELECTOR3',pic:''},{av:'cmbavDynamicfiltersoperator3'},{av:'AV24DynamicFiltersOperator3',fld:'vDYNAMICFILTERSOPERATOR3',pic:'ZZZ9'},{av:'AV25MovVDsc3',fld:'vMOVVDSC3',pic:''},{av:'imgAdddynamicfilters1_Visible',ctrl:'ADDDYNAMICFILTERS1',prop:'Visible'},{av:'imgRemovedynamicfilters1_Visible',ctrl:'REMOVEDYNAMICFILTERS1',prop:'Visible'},{av:'imgAdddynamicfilters2_Visible',ctrl:'ADDDYNAMICFILTERS2',prop:'Visible'},{av:'imgRemovedynamicfilters2_Visible',ctrl:'REMOVEDYNAMICFILTERS2',prop:'Visible'},{av:'cmbavDynamicfiltersselector1'},{av:'AV15DynamicFiltersSelector1',fld:'vDYNAMICFILTERSSELECTOR1',pic:''},{av:'cmbavDynamicfiltersoperator1'},{av:'AV16DynamicFiltersOperator1',fld:'vDYNAMICFILTERSOPERATOR1',pic:'ZZZ9'},{av:'AV17MovVDsc1',fld:'vMOVVDSC1',pic:''},{av:'cmbavMovvtip1'},{av:'AV49MovVTip1',fld:'vMOVVTIP1',pic:''},{av:'lblJsdynamicfilters_Caption',ctrl:'JSDYNAMICFILTERS',prop:'Caption'},{av:'cmbavMovvtip2'},{av:'AV50MovVTip2',fld:'vMOVVTIP2',pic:''},{av:'cmbavMovvtip3'},{av:'AV51MovVTip3',fld:'vMOVVTIP3',pic:''},{av:'edtavMovvdsc2_Visible',ctrl:'vMOVVDSC2',prop:'Visible'},{av:'edtavMovvdsc3_Visible',ctrl:'vMOVVDSC3',prop:'Visible'},{av:'edtavMovvdsc1_Visible',ctrl:'vMOVVDSC1',prop:'Visible'},{av:'AV43GridCurrentPage',fld:'vGRIDCURRENTPAGE',pic:'ZZZZZZZZZ9'},{av:'AV44GridPageCount',fld:'vGRIDPAGECOUNT',pic:'ZZZZZZZZZ9'},{av:'AV45GridAppliedFilters',fld:'vGRIDAPPLIEDFILTERS',pic:''}]}");
         setEventMetadata("VDYNAMICFILTERSSELECTOR1.CLICK","{handler:'E201F2',iparms:[{av:'cmbavDynamicfiltersselector1'},{av:'AV15DynamicFiltersSelector1',fld:'vDYNAMICFILTERSSELECTOR1',pic:''}]");
         setEventMetadata("VDYNAMICFILTERSSELECTOR1.CLICK",",oparms:[{av:'edtavMovvdsc1_Visible',ctrl:'vMOVVDSC1',prop:'Visible'},{av:'cmbavMovvtip1'},{av:'cmbavDynamicfiltersoperator1'}]}");
         setEventMetadata("'ADDDYNAMICFILTERS2'","{handler:'E211F2',iparms:[]");
         setEventMetadata("'ADDDYNAMICFILTERS2'",",oparms:[{av:'AV22DynamicFiltersEnabled3',fld:'vDYNAMICFILTERSENABLED3',pic:''},{av:'imgAdddynamicfilters2_Visible',ctrl:'ADDDYNAMICFILTERS2',prop:'Visible'},{av:'imgRemovedynamicfilters2_Visible',ctrl:'REMOVEDYNAMICFILTERS2',prop:'Visible'}]}");
         setEventMetadata("'REMOVEDYNAMICFILTERS2'","{handler:'E161F2',iparms:[{av:'GRID_nFirstRecordOnPage'},{av:'GRID_nEOF'},{av:'subGrid_Rows',ctrl:'GRID',prop:'Rows'},{av:'cmbavDynamicfiltersselector1'},{av:'AV15DynamicFiltersSelector1',fld:'vDYNAMICFILTERSSELECTOR1',pic:''},{av:'cmbavDynamicfiltersoperator1'},{av:'AV16DynamicFiltersOperator1',fld:'vDYNAMICFILTERSOPERATOR1',pic:'ZZZ9'},{av:'AV17MovVDsc1',fld:'vMOVVDSC1',pic:''},{av:'cmbavMovvtip1'},{av:'AV49MovVTip1',fld:'vMOVVTIP1',pic:''},{av:'cmbavDynamicfiltersselector2'},{av:'AV19DynamicFiltersSelector2',fld:'vDYNAMICFILTERSSELECTOR2',pic:''},{av:'cmbavDynamicfiltersoperator2'},{av:'AV20DynamicFiltersOperator2',fld:'vDYNAMICFILTERSOPERATOR2',pic:'ZZZ9'},{av:'AV21MovVDsc2',fld:'vMOVVDSC2',pic:''},{av:'cmbavMovvtip2'},{av:'AV50MovVTip2',fld:'vMOVVTIP2',pic:''},{av:'cmbavDynamicfiltersselector3'},{av:'AV23DynamicFiltersSelector3',fld:'vDYNAMICFILTERSSELECTOR3',pic:''},{av:'cmbavDynamicfiltersoperator3'},{av:'AV24DynamicFiltersOperator3',fld:'vDYNAMICFILTERSOPERATOR3',pic:'ZZZ9'},{av:'AV25MovVDsc3',fld:'vMOVVDSC3',pic:''},{av:'cmbavMovvtip3'},{av:'AV51MovVTip3',fld:'vMOVVTIP3',pic:''},{av:'AV54Pgmname',fld:'vPGMNAME',pic:'',hsh:true},{av:'AV18DynamicFiltersEnabled2',fld:'vDYNAMICFILTERSENABLED2',pic:''},{av:'AV22DynamicFiltersEnabled3',fld:'vDYNAMICFILTERSENABLED3',pic:''},{av:'AV31TFMovVCod',fld:'vTFMOVVCOD',pic:'ZZZZZ9'},{av:'AV32TFMovVCod_To',fld:'vTFMOVVCOD_TO',pic:'ZZZZZ9'},{av:'AV33TFMovVDsc',fld:'vTFMOVVDSC',pic:''},{av:'AV34TFMovVDsc_Sel',fld:'vTFMOVVDSC_SEL',pic:''},{av:'AV36TFMovVAbr_Sels',fld:'vTFMOVVABR_SELS',pic:''},{av:'AV38TFMovVTip_Sels',fld:'vTFMOVVTIP_SELS',pic:''},{av:'AV40TFMovVSts_Sels',fld:'vTFMOVVSTS_SELS',pic:''},{av:'AV13OrderedBy',fld:'vORDEREDBY',pic:'ZZZ9'},{av:'AV14OrderedDsc',fld:'vORDEREDDSC',pic:''},{av:'AV10GridState',fld:'vGRIDSTATE',pic:''},{av:'AV27DynamicFiltersIgnoreFirst',fld:'vDYNAMICFILTERSIGNOREFIRST',pic:''},{av:'AV26DynamicFiltersRemoving',fld:'vDYNAMICFILTERSREMOVING',pic:''}]");
         setEventMetadata("'REMOVEDYNAMICFILTERS2'",",oparms:[{av:'AV26DynamicFiltersRemoving',fld:'vDYNAMICFILTERSREMOVING',pic:''},{av:'AV18DynamicFiltersEnabled2',fld:'vDYNAMICFILTERSENABLED2',pic:''},{av:'AV10GridState',fld:'vGRIDSTATE',pic:''},{av:'cmbavDynamicfiltersselector2'},{av:'AV19DynamicFiltersSelector2',fld:'vDYNAMICFILTERSSELECTOR2',pic:''},{av:'cmbavDynamicfiltersoperator2'},{av:'AV20DynamicFiltersOperator2',fld:'vDYNAMICFILTERSOPERATOR2',pic:'ZZZ9'},{av:'AV21MovVDsc2',fld:'vMOVVDSC2',pic:''},{av:'AV22DynamicFiltersEnabled3',fld:'vDYNAMICFILTERSENABLED3',pic:''},{av:'cmbavDynamicfiltersselector3'},{av:'AV23DynamicFiltersSelector3',fld:'vDYNAMICFILTERSSELECTOR3',pic:''},{av:'cmbavDynamicfiltersoperator3'},{av:'AV24DynamicFiltersOperator3',fld:'vDYNAMICFILTERSOPERATOR3',pic:'ZZZ9'},{av:'AV25MovVDsc3',fld:'vMOVVDSC3',pic:''},{av:'imgAdddynamicfilters1_Visible',ctrl:'ADDDYNAMICFILTERS1',prop:'Visible'},{av:'imgRemovedynamicfilters1_Visible',ctrl:'REMOVEDYNAMICFILTERS1',prop:'Visible'},{av:'imgAdddynamicfilters2_Visible',ctrl:'ADDDYNAMICFILTERS2',prop:'Visible'},{av:'imgRemovedynamicfilters2_Visible',ctrl:'REMOVEDYNAMICFILTERS2',prop:'Visible'},{av:'cmbavDynamicfiltersselector1'},{av:'AV15DynamicFiltersSelector1',fld:'vDYNAMICFILTERSSELECTOR1',pic:''},{av:'cmbavDynamicfiltersoperator1'},{av:'AV16DynamicFiltersOperator1',fld:'vDYNAMICFILTERSOPERATOR1',pic:'ZZZ9'},{av:'AV17MovVDsc1',fld:'vMOVVDSC1',pic:''},{av:'cmbavMovvtip1'},{av:'AV49MovVTip1',fld:'vMOVVTIP1',pic:''},{av:'lblJsdynamicfilters_Caption',ctrl:'JSDYNAMICFILTERS',prop:'Caption'},{av:'cmbavMovvtip2'},{av:'AV50MovVTip2',fld:'vMOVVTIP2',pic:''},{av:'cmbavMovvtip3'},{av:'AV51MovVTip3',fld:'vMOVVTIP3',pic:''},{av:'edtavMovvdsc2_Visible',ctrl:'vMOVVDSC2',prop:'Visible'},{av:'edtavMovvdsc3_Visible',ctrl:'vMOVVDSC3',prop:'Visible'},{av:'edtavMovvdsc1_Visible',ctrl:'vMOVVDSC1',prop:'Visible'},{av:'AV43GridCurrentPage',fld:'vGRIDCURRENTPAGE',pic:'ZZZZZZZZZ9'},{av:'AV44GridPageCount',fld:'vGRIDPAGECOUNT',pic:'ZZZZZZZZZ9'},{av:'AV45GridAppliedFilters',fld:'vGRIDAPPLIEDFILTERS',pic:''}]}");
         setEventMetadata("VDYNAMICFILTERSSELECTOR2.CLICK","{handler:'E221F2',iparms:[{av:'cmbavDynamicfiltersselector2'},{av:'AV19DynamicFiltersSelector2',fld:'vDYNAMICFILTERSSELECTOR2',pic:''}]");
         setEventMetadata("VDYNAMICFILTERSSELECTOR2.CLICK",",oparms:[{av:'edtavMovvdsc2_Visible',ctrl:'vMOVVDSC2',prop:'Visible'},{av:'cmbavMovvtip2'},{av:'cmbavDynamicfiltersoperator2'}]}");
         setEventMetadata("'REMOVEDYNAMICFILTERS3'","{handler:'E171F2',iparms:[{av:'GRID_nFirstRecordOnPage'},{av:'GRID_nEOF'},{av:'subGrid_Rows',ctrl:'GRID',prop:'Rows'},{av:'cmbavDynamicfiltersselector1'},{av:'AV15DynamicFiltersSelector1',fld:'vDYNAMICFILTERSSELECTOR1',pic:''},{av:'cmbavDynamicfiltersoperator1'},{av:'AV16DynamicFiltersOperator1',fld:'vDYNAMICFILTERSOPERATOR1',pic:'ZZZ9'},{av:'AV17MovVDsc1',fld:'vMOVVDSC1',pic:''},{av:'cmbavMovvtip1'},{av:'AV49MovVTip1',fld:'vMOVVTIP1',pic:''},{av:'cmbavDynamicfiltersselector2'},{av:'AV19DynamicFiltersSelector2',fld:'vDYNAMICFILTERSSELECTOR2',pic:''},{av:'cmbavDynamicfiltersoperator2'},{av:'AV20DynamicFiltersOperator2',fld:'vDYNAMICFILTERSOPERATOR2',pic:'ZZZ9'},{av:'AV21MovVDsc2',fld:'vMOVVDSC2',pic:''},{av:'cmbavMovvtip2'},{av:'AV50MovVTip2',fld:'vMOVVTIP2',pic:''},{av:'cmbavDynamicfiltersselector3'},{av:'AV23DynamicFiltersSelector3',fld:'vDYNAMICFILTERSSELECTOR3',pic:''},{av:'cmbavDynamicfiltersoperator3'},{av:'AV24DynamicFiltersOperator3',fld:'vDYNAMICFILTERSOPERATOR3',pic:'ZZZ9'},{av:'AV25MovVDsc3',fld:'vMOVVDSC3',pic:''},{av:'cmbavMovvtip3'},{av:'AV51MovVTip3',fld:'vMOVVTIP3',pic:''},{av:'AV54Pgmname',fld:'vPGMNAME',pic:'',hsh:true},{av:'AV18DynamicFiltersEnabled2',fld:'vDYNAMICFILTERSENABLED2',pic:''},{av:'AV22DynamicFiltersEnabled3',fld:'vDYNAMICFILTERSENABLED3',pic:''},{av:'AV31TFMovVCod',fld:'vTFMOVVCOD',pic:'ZZZZZ9'},{av:'AV32TFMovVCod_To',fld:'vTFMOVVCOD_TO',pic:'ZZZZZ9'},{av:'AV33TFMovVDsc',fld:'vTFMOVVDSC',pic:''},{av:'AV34TFMovVDsc_Sel',fld:'vTFMOVVDSC_SEL',pic:''},{av:'AV36TFMovVAbr_Sels',fld:'vTFMOVVABR_SELS',pic:''},{av:'AV38TFMovVTip_Sels',fld:'vTFMOVVTIP_SELS',pic:''},{av:'AV40TFMovVSts_Sels',fld:'vTFMOVVSTS_SELS',pic:''},{av:'AV13OrderedBy',fld:'vORDEREDBY',pic:'ZZZ9'},{av:'AV14OrderedDsc',fld:'vORDEREDDSC',pic:''},{av:'AV10GridState',fld:'vGRIDSTATE',pic:''},{av:'AV27DynamicFiltersIgnoreFirst',fld:'vDYNAMICFILTERSIGNOREFIRST',pic:''},{av:'AV26DynamicFiltersRemoving',fld:'vDYNAMICFILTERSREMOVING',pic:''}]");
         setEventMetadata("'REMOVEDYNAMICFILTERS3'",",oparms:[{av:'AV26DynamicFiltersRemoving',fld:'vDYNAMICFILTERSREMOVING',pic:''},{av:'AV22DynamicFiltersEnabled3',fld:'vDYNAMICFILTERSENABLED3',pic:''},{av:'AV10GridState',fld:'vGRIDSTATE',pic:''},{av:'AV18DynamicFiltersEnabled2',fld:'vDYNAMICFILTERSENABLED2',pic:''},{av:'cmbavDynamicfiltersselector2'},{av:'AV19DynamicFiltersSelector2',fld:'vDYNAMICFILTERSSELECTOR2',pic:''},{av:'cmbavDynamicfiltersoperator2'},{av:'AV20DynamicFiltersOperator2',fld:'vDYNAMICFILTERSOPERATOR2',pic:'ZZZ9'},{av:'AV21MovVDsc2',fld:'vMOVVDSC2',pic:''},{av:'cmbavDynamicfiltersselector3'},{av:'AV23DynamicFiltersSelector3',fld:'vDYNAMICFILTERSSELECTOR3',pic:''},{av:'cmbavDynamicfiltersoperator3'},{av:'AV24DynamicFiltersOperator3',fld:'vDYNAMICFILTERSOPERATOR3',pic:'ZZZ9'},{av:'AV25MovVDsc3',fld:'vMOVVDSC3',pic:''},{av:'imgAdddynamicfilters1_Visible',ctrl:'ADDDYNAMICFILTERS1',prop:'Visible'},{av:'imgRemovedynamicfilters1_Visible',ctrl:'REMOVEDYNAMICFILTERS1',prop:'Visible'},{av:'imgAdddynamicfilters2_Visible',ctrl:'ADDDYNAMICFILTERS2',prop:'Visible'},{av:'imgRemovedynamicfilters2_Visible',ctrl:'REMOVEDYNAMICFILTERS2',prop:'Visible'},{av:'cmbavDynamicfiltersselector1'},{av:'AV15DynamicFiltersSelector1',fld:'vDYNAMICFILTERSSELECTOR1',pic:''},{av:'cmbavDynamicfiltersoperator1'},{av:'AV16DynamicFiltersOperator1',fld:'vDYNAMICFILTERSOPERATOR1',pic:'ZZZ9'},{av:'AV17MovVDsc1',fld:'vMOVVDSC1',pic:''},{av:'cmbavMovvtip1'},{av:'AV49MovVTip1',fld:'vMOVVTIP1',pic:''},{av:'lblJsdynamicfilters_Caption',ctrl:'JSDYNAMICFILTERS',prop:'Caption'},{av:'cmbavMovvtip2'},{av:'AV50MovVTip2',fld:'vMOVVTIP2',pic:''},{av:'cmbavMovvtip3'},{av:'AV51MovVTip3',fld:'vMOVVTIP3',pic:''},{av:'edtavMovvdsc2_Visible',ctrl:'vMOVVDSC2',prop:'Visible'},{av:'edtavMovvdsc3_Visible',ctrl:'vMOVVDSC3',prop:'Visible'},{av:'edtavMovvdsc1_Visible',ctrl:'vMOVVDSC1',prop:'Visible'},{av:'AV43GridCurrentPage',fld:'vGRIDCURRENTPAGE',pic:'ZZZZZZZZZ9'},{av:'AV44GridPageCount',fld:'vGRIDPAGECOUNT',pic:'ZZZZZZZZZ9'},{av:'AV45GridAppliedFilters',fld:'vGRIDAPPLIEDFILTERS',pic:''}]}");
         setEventMetadata("VDYNAMICFILTERSSELECTOR3.CLICK","{handler:'E231F2',iparms:[{av:'cmbavDynamicfiltersselector3'},{av:'AV23DynamicFiltersSelector3',fld:'vDYNAMICFILTERSSELECTOR3',pic:''}]");
         setEventMetadata("VDYNAMICFILTERSSELECTOR3.CLICK",",oparms:[{av:'edtavMovvdsc3_Visible',ctrl:'vMOVVDSC3',prop:'Visible'},{av:'cmbavMovvtip3'},{av:'cmbavDynamicfiltersoperator3'}]}");
         setEventMetadata("VGRIDACTIONS.CLICK","{handler:'E271F2',iparms:[{av:'cmbavGridactions'},{av:'AV46GridActions',fld:'vGRIDACTIONS',pic:'ZZZ9'},{av:'A235MovVCod',fld:'MOVVCOD',pic:'ZZZZZ9',hsh:true}]");
         setEventMetadata("VGRIDACTIONS.CLICK",",oparms:[{av:'cmbavGridactions'},{av:'AV46GridActions',fld:'vGRIDACTIONS',pic:'ZZZ9'}]}");
         setEventMetadata("'DOINSERT'","{handler:'E181F2',iparms:[{av:'A235MovVCod',fld:'MOVVCOD',pic:'ZZZZZ9',hsh:true}]");
         setEventMetadata("'DOINSERT'",",oparms:[]}");
         setEventMetadata("DDO_AGEXPORT.ONOPTIONCLICKED","{handler:'E131F2',iparms:[{av:'Ddo_agexport_Activeeventkey',ctrl:'DDO_AGEXPORT',prop:'ActiveEventKey'},{av:'AV54Pgmname',fld:'vPGMNAME',pic:'',hsh:true},{av:'AV40TFMovVSts_Sels',fld:'vTFMOVVSTS_SELS',pic:''},{av:'AV34TFMovVDsc_Sel',fld:'vTFMOVVDSC_SEL',pic:''},{av:'AV36TFMovVAbr_Sels',fld:'vTFMOVVABR_SELS',pic:''},{av:'AV35TFMovVAbr_SelsJson',fld:'vTFMOVVABR_SELSJSON',pic:''},{av:'AV38TFMovVTip_Sels',fld:'vTFMOVVTIP_SELS',pic:''},{av:'AV37TFMovVTip_SelsJson',fld:'vTFMOVVTIP_SELSJSON',pic:''},{av:'AV39TFMovVSts_SelsJson',fld:'vTFMOVVSTS_SELSJSON',pic:''},{av:'AV31TFMovVCod',fld:'vTFMOVVCOD',pic:'ZZZZZ9'},{av:'AV33TFMovVDsc',fld:'vTFMOVVDSC',pic:''},{av:'AV32TFMovVCod_To',fld:'vTFMOVVCOD_TO',pic:'ZZZZZ9'},{av:'AV13OrderedBy',fld:'vORDEREDBY',pic:'ZZZ9'},{av:'AV14OrderedDsc',fld:'vORDEREDDSC',pic:''},{av:'AV10GridState',fld:'vGRIDSTATE',pic:''},{av:'AV26DynamicFiltersRemoving',fld:'vDYNAMICFILTERSREMOVING',pic:''},{av:'cmbavDynamicfiltersselector1'},{av:'AV15DynamicFiltersSelector1',fld:'vDYNAMICFILTERSSELECTOR1',pic:''},{av:'cmbavDynamicfiltersselector2'},{av:'AV19DynamicFiltersSelector2',fld:'vDYNAMICFILTERSSELECTOR2',pic:''},{av:'cmbavDynamicfiltersselector3'},{av:'AV23DynamicFiltersSelector3',fld:'vDYNAMICFILTERSSELECTOR3',pic:''}]");
         setEventMetadata("DDO_AGEXPORT.ONOPTIONCLICKED",",oparms:[{av:'Innewwindow1_Target',ctrl:'INNEWWINDOW1',prop:'Target'},{av:'Innewwindow1_Height',ctrl:'INNEWWINDOW1',prop:'Height'},{av:'Innewwindow1_Width',ctrl:'INNEWWINDOW1',prop:'Width'},{av:'AV10GridState',fld:'vGRIDSTATE',pic:''},{av:'AV13OrderedBy',fld:'vORDEREDBY',pic:'ZZZ9'},{av:'AV14OrderedDsc',fld:'vORDEREDDSC',pic:''},{av:'AV39TFMovVSts_SelsJson',fld:'vTFMOVVSTS_SELSJSON',pic:''},{av:'AV40TFMovVSts_Sels',fld:'vTFMOVVSTS_SELS',pic:''},{av:'AV37TFMovVTip_SelsJson',fld:'vTFMOVVTIP_SELSJSON',pic:''},{av:'AV38TFMovVTip_Sels',fld:'vTFMOVVTIP_SELS',pic:''},{av:'AV35TFMovVAbr_SelsJson',fld:'vTFMOVVABR_SELSJSON',pic:''},{av:'AV36TFMovVAbr_Sels',fld:'vTFMOVVABR_SELS',pic:''},{av:'AV34TFMovVDsc_Sel',fld:'vTFMOVVDSC_SEL',pic:''},{av:'AV33TFMovVDsc',fld:'vTFMOVVDSC',pic:''},{av:'AV31TFMovVCod',fld:'vTFMOVVCOD',pic:'ZZZZZ9'},{av:'AV32TFMovVCod_To',fld:'vTFMOVVCOD_TO',pic:'ZZZZZ9'},{av:'Ddo_grid_Selectedvalue_set',ctrl:'DDO_GRID',prop:'SelectedValue_set'},{av:'Ddo_grid_Filteredtext_set',ctrl:'DDO_GRID',prop:'FilteredText_set'},{av:'Ddo_grid_Filteredtextto_set',ctrl:'DDO_GRID',prop:'FilteredTextTo_set'},{av:'subGrid_Rows',ctrl:'GRID',prop:'Rows'},{av:'GRID_nFirstRecordOnPage'},{av:'GRID_nEOF'},{av:'cmbavDynamicfiltersselector1'},{av:'AV15DynamicFiltersSelector1',fld:'vDYNAMICFILTERSSELECTOR1',pic:''},{av:'cmbavDynamicfiltersoperator1'},{av:'AV16DynamicFiltersOperator1',fld:'vDYNAMICFILTERSOPERATOR1',pic:'ZZZ9'},{av:'AV17MovVDsc1',fld:'vMOVVDSC1',pic:''},{av:'cmbavMovvtip1'},{av:'AV49MovVTip1',fld:'vMOVVTIP1',pic:''},{av:'cmbavDynamicfiltersselector2'},{av:'AV19DynamicFiltersSelector2',fld:'vDYNAMICFILTERSSELECTOR2',pic:''},{av:'cmbavDynamicfiltersoperator2'},{av:'AV20DynamicFiltersOperator2',fld:'vDYNAMICFILTERSOPERATOR2',pic:'ZZZ9'},{av:'AV21MovVDsc2',fld:'vMOVVDSC2',pic:''},{av:'cmbavMovvtip2'},{av:'AV50MovVTip2',fld:'vMOVVTIP2',pic:''},{av:'cmbavDynamicfiltersselector3'},{av:'AV23DynamicFiltersSelector3',fld:'vDYNAMICFILTERSSELECTOR3',pic:''},{av:'cmbavDynamicfiltersoperator3'},{av:'AV24DynamicFiltersOperator3',fld:'vDYNAMICFILTERSOPERATOR3',pic:'ZZZ9'},{av:'AV25MovVDsc3',fld:'vMOVVDSC3',pic:''},{av:'cmbavMovvtip3'},{av:'AV51MovVTip3',fld:'vMOVVTIP3',pic:''},{av:'AV54Pgmname',fld:'vPGMNAME',pic:'',hsh:true},{av:'AV18DynamicFiltersEnabled2',fld:'vDYNAMICFILTERSENABLED2',pic:''},{av:'AV22DynamicFiltersEnabled3',fld:'vDYNAMICFILTERSENABLED3',pic:''},{av:'AV27DynamicFiltersIgnoreFirst',fld:'vDYNAMICFILTERSIGNOREFIRST',pic:''},{av:'AV26DynamicFiltersRemoving',fld:'vDYNAMICFILTERSREMOVING',pic:''},{av:'Ddo_grid_Sortedstatus',ctrl:'DDO_GRID',prop:'SortedStatus'},{av:'imgAdddynamicfilters1_Visible',ctrl:'ADDDYNAMICFILTERS1',prop:'Visible'},{av:'imgRemovedynamicfilters1_Visible',ctrl:'REMOVEDYNAMICFILTERS1',prop:'Visible'},{av:'imgAdddynamicfilters2_Visible',ctrl:'ADDDYNAMICFILTERS2',prop:'Visible'},{av:'imgRemovedynamicfilters2_Visible',ctrl:'REMOVEDYNAMICFILTERS2',prop:'Visible'},{av:'lblJsdynamicfilters_Caption',ctrl:'JSDYNAMICFILTERS',prop:'Caption'},{av:'edtavMovvdsc1_Visible',ctrl:'vMOVVDSC1',prop:'Visible'},{av:'edtavMovvdsc2_Visible',ctrl:'vMOVVDSC2',prop:'Visible'},{av:'edtavMovvdsc3_Visible',ctrl:'vMOVVDSC3',prop:'Visible'}]}");
         setEventMetadata("NULL","{handler:'Valid_Movvsts',iparms:[]");
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
         AV17MovVDsc1 = "";
         AV49MovVTip1 = "";
         AV19DynamicFiltersSelector2 = "";
         AV21MovVDsc2 = "";
         AV50MovVTip2 = "";
         AV23DynamicFiltersSelector3 = "";
         AV25MovVDsc3 = "";
         AV51MovVTip3 = "";
         AV54Pgmname = "";
         AV33TFMovVDsc = "";
         AV34TFMovVDsc_Sel = "";
         AV36TFMovVAbr_Sels = new GxSimpleCollection<string>();
         AV38TFMovVTip_Sels = new GxSimpleCollection<string>();
         AV40TFMovVSts_Sels = new GxSimpleCollection<short>();
         AV10GridState = new GeneXus.Programs.wwpbaseobjects.SdtWWPGridState(context);
         sDynURL = "";
         FormProcess = "";
         bodyStyle = "";
         GXKey = "";
         AV45GridAppliedFilters = "";
         AV47AGExportData = new GXBaseCollection<GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTDropDownOptionsData_Item>( context, "Item", "");
         AV41DDO_TitleSettingsIcons = new GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTDropDownOptionsTitleSettingsIcons(context);
         AV35TFMovVAbr_SelsJson = "";
         AV37TFMovVTip_SelsJson = "";
         AV39TFMovVSts_SelsJson = "";
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
         A1243MovVDsc = "";
         A1242MovVAbr = "";
         A1245MovVTip = "";
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
         AV73Configuracion_movimientoventawwds_19_tfmovvabr_sels = new GxSimpleCollection<string>();
         AV74Configuracion_movimientoventawwds_20_tfmovvtip_sels = new GxSimpleCollection<string>();
         AV75Configuracion_movimientoventawwds_21_tfmovvsts_sels = new GxSimpleCollection<short>();
         scmdbuf = "";
         lV57Configuracion_movimientoventawwds_3_movvdsc1 = "";
         lV62Configuracion_movimientoventawwds_8_movvdsc2 = "";
         lV67Configuracion_movimientoventawwds_13_movvdsc3 = "";
         lV71Configuracion_movimientoventawwds_17_tfmovvdsc = "";
         AV55Configuracion_movimientoventawwds_1_dynamicfiltersselector1 = "";
         AV57Configuracion_movimientoventawwds_3_movvdsc1 = "";
         AV58Configuracion_movimientoventawwds_4_movvtip1 = "";
         AV60Configuracion_movimientoventawwds_6_dynamicfiltersselector2 = "";
         AV62Configuracion_movimientoventawwds_8_movvdsc2 = "";
         AV63Configuracion_movimientoventawwds_9_movvtip2 = "";
         AV65Configuracion_movimientoventawwds_11_dynamicfiltersselector3 = "";
         AV67Configuracion_movimientoventawwds_13_movvdsc3 = "";
         AV68Configuracion_movimientoventawwds_14_movvtip3 = "";
         AV72Configuracion_movimientoventawwds_18_tfmovvdsc_sel = "";
         AV71Configuracion_movimientoventawwds_17_tfmovvdsc = "";
         H001F2_A1244MovVSts = new short[1] ;
         H001F2_A1245MovVTip = new string[] {""} ;
         H001F2_A1242MovVAbr = new string[] {""} ;
         H001F2_A1243MovVDsc = new string[] {""} ;
         H001F2_A235MovVCod = new int[1] ;
         H001F3_AGRID_nRecordCount = new long[1] ;
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
         GXt_char2 = "";
         GXt_char3 = "";
         GXt_char4 = "";
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
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.configuracion.movimientoventaww__default(),
            new Object[][] {
                new Object[] {
               H001F2_A1244MovVSts, H001F2_A1245MovVTip, H001F2_A1242MovVAbr, H001F2_A1243MovVDsc, H001F2_A235MovVCod
               }
               , new Object[] {
               H001F3_AGRID_nRecordCount
               }
            }
         );
         AV54Pgmname = "Configuracion.MovimientoVentaWW";
         /* GeneXus formulas. */
         AV54Pgmname = "Configuracion.MovimientoVentaWW";
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
      private short A1244MovVSts ;
      private short subGrid_Allowselection ;
      private short subGrid_Allowhovering ;
      private short subGrid_Allowcollapsing ;
      private short subGrid_Collapsed ;
      private short nDonePA ;
      private short AV56Configuracion_movimientoventawwds_2_dynamicfiltersoperator1 ;
      private short AV61Configuracion_movimientoventawwds_7_dynamicfiltersoperator2 ;
      private short AV66Configuracion_movimientoventawwds_12_dynamicfiltersoperator3 ;
      private short nGXWrapped ;
      private short subGrid_Backstyle ;
      private int subGrid_Rows ;
      private int Gridpaginationbar_Rowsperpageselectedvalue ;
      private int nRC_GXsfl_110 ;
      private int nGXsfl_110_idx=1 ;
      private int AV31TFMovVCod ;
      private int AV32TFMovVCod_To ;
      private int Gridpaginationbar_Pagestoshow ;
      private int subGrid_Titlebackcolor ;
      private int subGrid_Allbackcolor ;
      private int A235MovVCod ;
      private int subGrid_Selectedindex ;
      private int subGrid_Selectioncolor ;
      private int subGrid_Hoveringcolor ;
      private int subGrid_Islastpage ;
      private int GXPagingFrom2 ;
      private int GXPagingTo2 ;
      private int AV73Configuracion_movimientoventawwds_19_tfmovvabr_sels_Count ;
      private int AV74Configuracion_movimientoventawwds_20_tfmovvtip_sels_Count ;
      private int AV75Configuracion_movimientoventawwds_21_tfmovvsts_sels_Count ;
      private int AV69Configuracion_movimientoventawwds_15_tfmovvcod ;
      private int AV70Configuracion_movimientoventawwds_16_tfmovvcod_to ;
      private int AV42PageToGo ;
      private int imgAdddynamicfilters1_Visible ;
      private int imgRemovedynamicfilters1_Visible ;
      private int imgAdddynamicfilters2_Visible ;
      private int imgRemovedynamicfilters2_Visible ;
      private int edtavMovvdsc1_Visible ;
      private int edtavMovvdsc2_Visible ;
      private int edtavMovvdsc3_Visible ;
      private int AV76GXV1 ;
      private int edtavMovvdsc3_Enabled ;
      private int edtavMovvdsc2_Enabled ;
      private int edtavMovvdsc1_Enabled ;
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
      private string AV17MovVDsc1 ;
      private string AV49MovVTip1 ;
      private string AV21MovVDsc2 ;
      private string AV50MovVTip2 ;
      private string AV25MovVDsc3 ;
      private string AV51MovVTip3 ;
      private string AV54Pgmname ;
      private string AV33TFMovVDsc ;
      private string AV34TFMovVDsc_Sel ;
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
      private string A1243MovVDsc ;
      private string edtMovVDsc_Link ;
      private string A1242MovVAbr ;
      private string A1245MovVTip ;
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
      private string edtMovVCod_Internalname ;
      private string edtMovVDsc_Internalname ;
      private string edtMovVAbr_Internalname ;
      private string cmbMovVTip_Internalname ;
      private string cmbMovVSts_Internalname ;
      private string cmbavDynamicfiltersselector1_Internalname ;
      private string cmbavDynamicfiltersoperator1_Internalname ;
      private string cmbavMovvtip1_Internalname ;
      private string cmbavDynamicfiltersselector2_Internalname ;
      private string cmbavDynamicfiltersoperator2_Internalname ;
      private string cmbavMovvtip2_Internalname ;
      private string cmbavDynamicfiltersselector3_Internalname ;
      private string cmbavDynamicfiltersoperator3_Internalname ;
      private string cmbavMovvtip3_Internalname ;
      private string scmdbuf ;
      private string lV57Configuracion_movimientoventawwds_3_movvdsc1 ;
      private string lV62Configuracion_movimientoventawwds_8_movvdsc2 ;
      private string lV67Configuracion_movimientoventawwds_13_movvdsc3 ;
      private string lV71Configuracion_movimientoventawwds_17_tfmovvdsc ;
      private string AV57Configuracion_movimientoventawwds_3_movvdsc1 ;
      private string AV58Configuracion_movimientoventawwds_4_movvtip1 ;
      private string AV62Configuracion_movimientoventawwds_8_movvdsc2 ;
      private string AV63Configuracion_movimientoventawwds_9_movvtip2 ;
      private string AV67Configuracion_movimientoventawwds_13_movvdsc3 ;
      private string AV68Configuracion_movimientoventawwds_14_movvtip3 ;
      private string AV72Configuracion_movimientoventawwds_18_tfmovvdsc_sel ;
      private string AV71Configuracion_movimientoventawwds_17_tfmovvdsc ;
      private string edtavMovvdsc1_Internalname ;
      private string edtavMovvdsc2_Internalname ;
      private string edtavMovvdsc3_Internalname ;
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
      private string GXt_char4 ;
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
      private string cellFilter_movvdsc3_cell_Internalname ;
      private string edtavMovvdsc3_Jsonclick ;
      private string cellFilter_movvtip3_cell_Internalname ;
      private string cmbavMovvtip3_Jsonclick ;
      private string cellDynamicfilters_removefilter3_cell_Internalname ;
      private string sImgUrl ;
      private string tblTablemergeddynamicfilters2_Internalname ;
      private string cmbavDynamicfiltersoperator2_Jsonclick ;
      private string cellFilter_movvdsc2_cell_Internalname ;
      private string edtavMovvdsc2_Jsonclick ;
      private string cellFilter_movvtip2_cell_Internalname ;
      private string cmbavMovvtip2_Jsonclick ;
      private string cellDynamicfilters_addfilter2_cell_Internalname ;
      private string cellDynamicfilters_removefilter2_cell_Internalname ;
      private string tblTablemergeddynamicfilters1_Internalname ;
      private string cmbavDynamicfiltersoperator1_Jsonclick ;
      private string cellFilter_movvdsc1_cell_Internalname ;
      private string edtavMovvdsc1_Jsonclick ;
      private string cellFilter_movvtip1_cell_Internalname ;
      private string cmbavMovvtip1_Jsonclick ;
      private string cellDynamicfilters_addfilter1_cell_Internalname ;
      private string cellDynamicfilters_removefilter1_cell_Internalname ;
      private string sGXsfl_110_fel_idx="0001" ;
      private string GXCCtl ;
      private string cmbavGridactions_Jsonclick ;
      private string ROClassString ;
      private string edtMovVCod_Jsonclick ;
      private string edtMovVDsc_Jsonclick ;
      private string edtMovVAbr_Jsonclick ;
      private string cmbMovVTip_Jsonclick ;
      private string cmbMovVSts_Jsonclick ;
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
      private bool AV59Configuracion_movimientoventawwds_5_dynamicfiltersenabled2 ;
      private bool AV64Configuracion_movimientoventawwds_10_dynamicfiltersenabled3 ;
      private bool returnInSub ;
      private bool gx_refresh_fired ;
      private string AV35TFMovVAbr_SelsJson ;
      private string AV37TFMovVTip_SelsJson ;
      private string AV39TFMovVSts_SelsJson ;
      private string AV15DynamicFiltersSelector1 ;
      private string AV19DynamicFiltersSelector2 ;
      private string AV23DynamicFiltersSelector3 ;
      private string AV45GridAppliedFilters ;
      private string AV55Configuracion_movimientoventawwds_1_dynamicfiltersselector1 ;
      private string AV60Configuracion_movimientoventawwds_6_dynamicfiltersselector2 ;
      private string AV65Configuracion_movimientoventawwds_11_dynamicfiltersselector3 ;
      private string AV28ExcelFilename ;
      private string AV29ErrorMessage ;
      private GxSimpleCollection<short> AV40TFMovVSts_Sels ;
      private GxSimpleCollection<short> AV75Configuracion_movimientoventawwds_21_tfmovvsts_sels ;
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
      private GXCombobox cmbavMovvtip1 ;
      private GXCombobox cmbavDynamicfiltersselector2 ;
      private GXCombobox cmbavDynamicfiltersoperator2 ;
      private GXCombobox cmbavMovvtip2 ;
      private GXCombobox cmbavDynamicfiltersselector3 ;
      private GXCombobox cmbavDynamicfiltersoperator3 ;
      private GXCombobox cmbavMovvtip3 ;
      private GXCombobox cmbavGridactions ;
      private GXCombobox cmbMovVTip ;
      private GXCombobox cmbMovVSts ;
      private IDataStoreProvider pr_default ;
      private short[] H001F2_A1244MovVSts ;
      private string[] H001F2_A1245MovVTip ;
      private string[] H001F2_A1242MovVAbr ;
      private string[] H001F2_A1243MovVDsc ;
      private int[] H001F2_A235MovVCod ;
      private long[] H001F3_AGRID_nRecordCount ;
      private msglist BackMsgLst ;
      private msglist LclMsgLst ;
      private GxHttpRequest AV7HTTPRequest ;
      private GxSimpleCollection<string> AV36TFMovVAbr_Sels ;
      private GxSimpleCollection<string> AV38TFMovVTip_Sels ;
      private GxSimpleCollection<string> AV73Configuracion_movimientoventawwds_19_tfmovvabr_sels ;
      private GxSimpleCollection<string> AV74Configuracion_movimientoventawwds_20_tfmovvtip_sels ;
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

   public class movimientoventaww__default : DataStoreHelperBase, IDataStoreHelper
   {
      protected Object[] conditional_H001F2( IGxContext context ,
                                             string A1242MovVAbr ,
                                             GxSimpleCollection<string> AV73Configuracion_movimientoventawwds_19_tfmovvabr_sels ,
                                             string A1245MovVTip ,
                                             GxSimpleCollection<string> AV74Configuracion_movimientoventawwds_20_tfmovvtip_sels ,
                                             short A1244MovVSts ,
                                             GxSimpleCollection<short> AV75Configuracion_movimientoventawwds_21_tfmovvsts_sels ,
                                             string AV55Configuracion_movimientoventawwds_1_dynamicfiltersselector1 ,
                                             short AV56Configuracion_movimientoventawwds_2_dynamicfiltersoperator1 ,
                                             string AV57Configuracion_movimientoventawwds_3_movvdsc1 ,
                                             string AV58Configuracion_movimientoventawwds_4_movvtip1 ,
                                             bool AV59Configuracion_movimientoventawwds_5_dynamicfiltersenabled2 ,
                                             string AV60Configuracion_movimientoventawwds_6_dynamicfiltersselector2 ,
                                             short AV61Configuracion_movimientoventawwds_7_dynamicfiltersoperator2 ,
                                             string AV62Configuracion_movimientoventawwds_8_movvdsc2 ,
                                             string AV63Configuracion_movimientoventawwds_9_movvtip2 ,
                                             bool AV64Configuracion_movimientoventawwds_10_dynamicfiltersenabled3 ,
                                             string AV65Configuracion_movimientoventawwds_11_dynamicfiltersselector3 ,
                                             short AV66Configuracion_movimientoventawwds_12_dynamicfiltersoperator3 ,
                                             string AV67Configuracion_movimientoventawwds_13_movvdsc3 ,
                                             string AV68Configuracion_movimientoventawwds_14_movvtip3 ,
                                             int AV69Configuracion_movimientoventawwds_15_tfmovvcod ,
                                             int AV70Configuracion_movimientoventawwds_16_tfmovvcod_to ,
                                             string AV72Configuracion_movimientoventawwds_18_tfmovvdsc_sel ,
                                             string AV71Configuracion_movimientoventawwds_17_tfmovvdsc ,
                                             int AV73Configuracion_movimientoventawwds_19_tfmovvabr_sels_Count ,
                                             int AV74Configuracion_movimientoventawwds_20_tfmovvtip_sels_Count ,
                                             int AV75Configuracion_movimientoventawwds_21_tfmovvsts_sels_Count ,
                                             string A1243MovVDsc ,
                                             int A235MovVCod ,
                                             short AV13OrderedBy ,
                                             bool AV14OrderedDsc )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int5 = new short[16];
         Object[] GXv_Object6 = new Object[2];
         string sSelectString;
         string sFromString;
         string sOrderString;
         sSelectString = " [MovVSts], [MovVTip], [MovVAbr], [MovVDsc], [MovVCod]";
         sFromString = " FROM [CMOVVENTAS]";
         sOrderString = "";
         if ( ( StringUtil.StrCmp(AV55Configuracion_movimientoventawwds_1_dynamicfiltersselector1, "MOVVDSC") == 0 ) && ( AV56Configuracion_movimientoventawwds_2_dynamicfiltersoperator1 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV57Configuracion_movimientoventawwds_3_movvdsc1)) ) )
         {
            AddWhere(sWhereString, "([MovVDsc] like @lV57Configuracion_movimientoventawwds_3_movvdsc1)");
         }
         else
         {
            GXv_int5[0] = 1;
         }
         if ( ( StringUtil.StrCmp(AV55Configuracion_movimientoventawwds_1_dynamicfiltersselector1, "MOVVDSC") == 0 ) && ( AV56Configuracion_movimientoventawwds_2_dynamicfiltersoperator1 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV57Configuracion_movimientoventawwds_3_movvdsc1)) ) )
         {
            AddWhere(sWhereString, "([MovVDsc] like '%' + @lV57Configuracion_movimientoventawwds_3_movvdsc1)");
         }
         else
         {
            GXv_int5[1] = 1;
         }
         if ( ( StringUtil.StrCmp(AV55Configuracion_movimientoventawwds_1_dynamicfiltersselector1, "MOVVTIP") == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV58Configuracion_movimientoventawwds_4_movvtip1)) ) )
         {
            AddWhere(sWhereString, "([MovVTip] = @AV58Configuracion_movimientoventawwds_4_movvtip1)");
         }
         else
         {
            GXv_int5[2] = 1;
         }
         if ( AV59Configuracion_movimientoventawwds_5_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV60Configuracion_movimientoventawwds_6_dynamicfiltersselector2, "MOVVDSC") == 0 ) && ( AV61Configuracion_movimientoventawwds_7_dynamicfiltersoperator2 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV62Configuracion_movimientoventawwds_8_movvdsc2)) ) )
         {
            AddWhere(sWhereString, "([MovVDsc] like @lV62Configuracion_movimientoventawwds_8_movvdsc2)");
         }
         else
         {
            GXv_int5[3] = 1;
         }
         if ( AV59Configuracion_movimientoventawwds_5_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV60Configuracion_movimientoventawwds_6_dynamicfiltersselector2, "MOVVDSC") == 0 ) && ( AV61Configuracion_movimientoventawwds_7_dynamicfiltersoperator2 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV62Configuracion_movimientoventawwds_8_movvdsc2)) ) )
         {
            AddWhere(sWhereString, "([MovVDsc] like '%' + @lV62Configuracion_movimientoventawwds_8_movvdsc2)");
         }
         else
         {
            GXv_int5[4] = 1;
         }
         if ( AV59Configuracion_movimientoventawwds_5_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV60Configuracion_movimientoventawwds_6_dynamicfiltersselector2, "MOVVTIP") == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV63Configuracion_movimientoventawwds_9_movvtip2)) ) )
         {
            AddWhere(sWhereString, "([MovVTip] = @AV63Configuracion_movimientoventawwds_9_movvtip2)");
         }
         else
         {
            GXv_int5[5] = 1;
         }
         if ( AV64Configuracion_movimientoventawwds_10_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV65Configuracion_movimientoventawwds_11_dynamicfiltersselector3, "MOVVDSC") == 0 ) && ( AV66Configuracion_movimientoventawwds_12_dynamicfiltersoperator3 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV67Configuracion_movimientoventawwds_13_movvdsc3)) ) )
         {
            AddWhere(sWhereString, "([MovVDsc] like @lV67Configuracion_movimientoventawwds_13_movvdsc3)");
         }
         else
         {
            GXv_int5[6] = 1;
         }
         if ( AV64Configuracion_movimientoventawwds_10_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV65Configuracion_movimientoventawwds_11_dynamicfiltersselector3, "MOVVDSC") == 0 ) && ( AV66Configuracion_movimientoventawwds_12_dynamicfiltersoperator3 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV67Configuracion_movimientoventawwds_13_movvdsc3)) ) )
         {
            AddWhere(sWhereString, "([MovVDsc] like '%' + @lV67Configuracion_movimientoventawwds_13_movvdsc3)");
         }
         else
         {
            GXv_int5[7] = 1;
         }
         if ( AV64Configuracion_movimientoventawwds_10_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV65Configuracion_movimientoventawwds_11_dynamicfiltersselector3, "MOVVTIP") == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV68Configuracion_movimientoventawwds_14_movvtip3)) ) )
         {
            AddWhere(sWhereString, "([MovVTip] = @AV68Configuracion_movimientoventawwds_14_movvtip3)");
         }
         else
         {
            GXv_int5[8] = 1;
         }
         if ( ! (0==AV69Configuracion_movimientoventawwds_15_tfmovvcod) )
         {
            AddWhere(sWhereString, "([MovVCod] >= @AV69Configuracion_movimientoventawwds_15_tfmovvcod)");
         }
         else
         {
            GXv_int5[9] = 1;
         }
         if ( ! (0==AV70Configuracion_movimientoventawwds_16_tfmovvcod_to) )
         {
            AddWhere(sWhereString, "([MovVCod] <= @AV70Configuracion_movimientoventawwds_16_tfmovvcod_to)");
         }
         else
         {
            GXv_int5[10] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV72Configuracion_movimientoventawwds_18_tfmovvdsc_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV71Configuracion_movimientoventawwds_17_tfmovvdsc)) ) )
         {
            AddWhere(sWhereString, "([MovVDsc] like @lV71Configuracion_movimientoventawwds_17_tfmovvdsc)");
         }
         else
         {
            GXv_int5[11] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV72Configuracion_movimientoventawwds_18_tfmovvdsc_sel)) )
         {
            AddWhere(sWhereString, "([MovVDsc] = @AV72Configuracion_movimientoventawwds_18_tfmovvdsc_sel)");
         }
         else
         {
            GXv_int5[12] = 1;
         }
         if ( AV73Configuracion_movimientoventawwds_19_tfmovvabr_sels_Count > 0 )
         {
            AddWhere(sWhereString, "("+new GxDbmsUtils( new GxSqlServer()).ValueList(AV73Configuracion_movimientoventawwds_19_tfmovvabr_sels, "[MovVAbr] IN (", ")")+")");
         }
         if ( AV74Configuracion_movimientoventawwds_20_tfmovvtip_sels_Count > 0 )
         {
            AddWhere(sWhereString, "("+new GxDbmsUtils( new GxSqlServer()).ValueList(AV74Configuracion_movimientoventawwds_20_tfmovvtip_sels, "[MovVTip] IN (", ")")+")");
         }
         if ( AV75Configuracion_movimientoventawwds_21_tfmovvsts_sels_Count > 0 )
         {
            AddWhere(sWhereString, "("+new GxDbmsUtils( new GxSqlServer()).ValueList(AV75Configuracion_movimientoventawwds_21_tfmovvsts_sels, "[MovVSts] IN (", ")")+")");
         }
         if ( ( AV13OrderedBy == 1 ) && ! AV14OrderedDsc )
         {
            sOrderString += " ORDER BY [MovVCod]";
         }
         else if ( ( AV13OrderedBy == 1 ) && ( AV14OrderedDsc ) )
         {
            sOrderString += " ORDER BY [MovVCod] DESC";
         }
         else if ( ( AV13OrderedBy == 2 ) && ! AV14OrderedDsc )
         {
            sOrderString += " ORDER BY [MovVDsc]";
         }
         else if ( ( AV13OrderedBy == 2 ) && ( AV14OrderedDsc ) )
         {
            sOrderString += " ORDER BY [MovVDsc] DESC";
         }
         else if ( ( AV13OrderedBy == 3 ) && ! AV14OrderedDsc )
         {
            sOrderString += " ORDER BY [MovVAbr]";
         }
         else if ( ( AV13OrderedBy == 3 ) && ( AV14OrderedDsc ) )
         {
            sOrderString += " ORDER BY [MovVAbr] DESC";
         }
         else if ( ( AV13OrderedBy == 4 ) && ! AV14OrderedDsc )
         {
            sOrderString += " ORDER BY [MovVTip]";
         }
         else if ( ( AV13OrderedBy == 4 ) && ( AV14OrderedDsc ) )
         {
            sOrderString += " ORDER BY [MovVTip] DESC";
         }
         else if ( ( AV13OrderedBy == 5 ) && ! AV14OrderedDsc )
         {
            sOrderString += " ORDER BY [MovVSts]";
         }
         else if ( ( AV13OrderedBy == 5 ) && ( AV14OrderedDsc ) )
         {
            sOrderString += " ORDER BY [MovVSts] DESC";
         }
         else if ( true )
         {
            sOrderString += " ORDER BY [MovVCod]";
         }
         scmdbuf = "SELECT " + sSelectString + sFromString + sWhereString + sOrderString + "" + " OFFSET " + "@GXPagingFrom2" + " ROWS FETCH NEXT CAST((SELECT CASE WHEN " + "@GXPagingTo2" + " > 0 THEN " + "@GXPagingTo2" + " ELSE 1e9 END) AS INTEGER) ROWS ONLY";
         GXv_Object6[0] = scmdbuf;
         GXv_Object6[1] = GXv_int5;
         return GXv_Object6 ;
      }

      protected Object[] conditional_H001F3( IGxContext context ,
                                             string A1242MovVAbr ,
                                             GxSimpleCollection<string> AV73Configuracion_movimientoventawwds_19_tfmovvabr_sels ,
                                             string A1245MovVTip ,
                                             GxSimpleCollection<string> AV74Configuracion_movimientoventawwds_20_tfmovvtip_sels ,
                                             short A1244MovVSts ,
                                             GxSimpleCollection<short> AV75Configuracion_movimientoventawwds_21_tfmovvsts_sels ,
                                             string AV55Configuracion_movimientoventawwds_1_dynamicfiltersselector1 ,
                                             short AV56Configuracion_movimientoventawwds_2_dynamicfiltersoperator1 ,
                                             string AV57Configuracion_movimientoventawwds_3_movvdsc1 ,
                                             string AV58Configuracion_movimientoventawwds_4_movvtip1 ,
                                             bool AV59Configuracion_movimientoventawwds_5_dynamicfiltersenabled2 ,
                                             string AV60Configuracion_movimientoventawwds_6_dynamicfiltersselector2 ,
                                             short AV61Configuracion_movimientoventawwds_7_dynamicfiltersoperator2 ,
                                             string AV62Configuracion_movimientoventawwds_8_movvdsc2 ,
                                             string AV63Configuracion_movimientoventawwds_9_movvtip2 ,
                                             bool AV64Configuracion_movimientoventawwds_10_dynamicfiltersenabled3 ,
                                             string AV65Configuracion_movimientoventawwds_11_dynamicfiltersselector3 ,
                                             short AV66Configuracion_movimientoventawwds_12_dynamicfiltersoperator3 ,
                                             string AV67Configuracion_movimientoventawwds_13_movvdsc3 ,
                                             string AV68Configuracion_movimientoventawwds_14_movvtip3 ,
                                             int AV69Configuracion_movimientoventawwds_15_tfmovvcod ,
                                             int AV70Configuracion_movimientoventawwds_16_tfmovvcod_to ,
                                             string AV72Configuracion_movimientoventawwds_18_tfmovvdsc_sel ,
                                             string AV71Configuracion_movimientoventawwds_17_tfmovvdsc ,
                                             int AV73Configuracion_movimientoventawwds_19_tfmovvabr_sels_Count ,
                                             int AV74Configuracion_movimientoventawwds_20_tfmovvtip_sels_Count ,
                                             int AV75Configuracion_movimientoventawwds_21_tfmovvsts_sels_Count ,
                                             string A1243MovVDsc ,
                                             int A235MovVCod ,
                                             short AV13OrderedBy ,
                                             bool AV14OrderedDsc )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int7 = new short[13];
         Object[] GXv_Object8 = new Object[2];
         scmdbuf = "SELECT COUNT(*) FROM [CMOVVENTAS]";
         if ( ( StringUtil.StrCmp(AV55Configuracion_movimientoventawwds_1_dynamicfiltersselector1, "MOVVDSC") == 0 ) && ( AV56Configuracion_movimientoventawwds_2_dynamicfiltersoperator1 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV57Configuracion_movimientoventawwds_3_movvdsc1)) ) )
         {
            AddWhere(sWhereString, "([MovVDsc] like @lV57Configuracion_movimientoventawwds_3_movvdsc1)");
         }
         else
         {
            GXv_int7[0] = 1;
         }
         if ( ( StringUtil.StrCmp(AV55Configuracion_movimientoventawwds_1_dynamicfiltersselector1, "MOVVDSC") == 0 ) && ( AV56Configuracion_movimientoventawwds_2_dynamicfiltersoperator1 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV57Configuracion_movimientoventawwds_3_movvdsc1)) ) )
         {
            AddWhere(sWhereString, "([MovVDsc] like '%' + @lV57Configuracion_movimientoventawwds_3_movvdsc1)");
         }
         else
         {
            GXv_int7[1] = 1;
         }
         if ( ( StringUtil.StrCmp(AV55Configuracion_movimientoventawwds_1_dynamicfiltersselector1, "MOVVTIP") == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV58Configuracion_movimientoventawwds_4_movvtip1)) ) )
         {
            AddWhere(sWhereString, "([MovVTip] = @AV58Configuracion_movimientoventawwds_4_movvtip1)");
         }
         else
         {
            GXv_int7[2] = 1;
         }
         if ( AV59Configuracion_movimientoventawwds_5_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV60Configuracion_movimientoventawwds_6_dynamicfiltersselector2, "MOVVDSC") == 0 ) && ( AV61Configuracion_movimientoventawwds_7_dynamicfiltersoperator2 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV62Configuracion_movimientoventawwds_8_movvdsc2)) ) )
         {
            AddWhere(sWhereString, "([MovVDsc] like @lV62Configuracion_movimientoventawwds_8_movvdsc2)");
         }
         else
         {
            GXv_int7[3] = 1;
         }
         if ( AV59Configuracion_movimientoventawwds_5_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV60Configuracion_movimientoventawwds_6_dynamicfiltersselector2, "MOVVDSC") == 0 ) && ( AV61Configuracion_movimientoventawwds_7_dynamicfiltersoperator2 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV62Configuracion_movimientoventawwds_8_movvdsc2)) ) )
         {
            AddWhere(sWhereString, "([MovVDsc] like '%' + @lV62Configuracion_movimientoventawwds_8_movvdsc2)");
         }
         else
         {
            GXv_int7[4] = 1;
         }
         if ( AV59Configuracion_movimientoventawwds_5_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV60Configuracion_movimientoventawwds_6_dynamicfiltersselector2, "MOVVTIP") == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV63Configuracion_movimientoventawwds_9_movvtip2)) ) )
         {
            AddWhere(sWhereString, "([MovVTip] = @AV63Configuracion_movimientoventawwds_9_movvtip2)");
         }
         else
         {
            GXv_int7[5] = 1;
         }
         if ( AV64Configuracion_movimientoventawwds_10_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV65Configuracion_movimientoventawwds_11_dynamicfiltersselector3, "MOVVDSC") == 0 ) && ( AV66Configuracion_movimientoventawwds_12_dynamicfiltersoperator3 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV67Configuracion_movimientoventawwds_13_movvdsc3)) ) )
         {
            AddWhere(sWhereString, "([MovVDsc] like @lV67Configuracion_movimientoventawwds_13_movvdsc3)");
         }
         else
         {
            GXv_int7[6] = 1;
         }
         if ( AV64Configuracion_movimientoventawwds_10_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV65Configuracion_movimientoventawwds_11_dynamicfiltersselector3, "MOVVDSC") == 0 ) && ( AV66Configuracion_movimientoventawwds_12_dynamicfiltersoperator3 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV67Configuracion_movimientoventawwds_13_movvdsc3)) ) )
         {
            AddWhere(sWhereString, "([MovVDsc] like '%' + @lV67Configuracion_movimientoventawwds_13_movvdsc3)");
         }
         else
         {
            GXv_int7[7] = 1;
         }
         if ( AV64Configuracion_movimientoventawwds_10_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV65Configuracion_movimientoventawwds_11_dynamicfiltersselector3, "MOVVTIP") == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV68Configuracion_movimientoventawwds_14_movvtip3)) ) )
         {
            AddWhere(sWhereString, "([MovVTip] = @AV68Configuracion_movimientoventawwds_14_movvtip3)");
         }
         else
         {
            GXv_int7[8] = 1;
         }
         if ( ! (0==AV69Configuracion_movimientoventawwds_15_tfmovvcod) )
         {
            AddWhere(sWhereString, "([MovVCod] >= @AV69Configuracion_movimientoventawwds_15_tfmovvcod)");
         }
         else
         {
            GXv_int7[9] = 1;
         }
         if ( ! (0==AV70Configuracion_movimientoventawwds_16_tfmovvcod_to) )
         {
            AddWhere(sWhereString, "([MovVCod] <= @AV70Configuracion_movimientoventawwds_16_tfmovvcod_to)");
         }
         else
         {
            GXv_int7[10] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV72Configuracion_movimientoventawwds_18_tfmovvdsc_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV71Configuracion_movimientoventawwds_17_tfmovvdsc)) ) )
         {
            AddWhere(sWhereString, "([MovVDsc] like @lV71Configuracion_movimientoventawwds_17_tfmovvdsc)");
         }
         else
         {
            GXv_int7[11] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV72Configuracion_movimientoventawwds_18_tfmovvdsc_sel)) )
         {
            AddWhere(sWhereString, "([MovVDsc] = @AV72Configuracion_movimientoventawwds_18_tfmovvdsc_sel)");
         }
         else
         {
            GXv_int7[12] = 1;
         }
         if ( AV73Configuracion_movimientoventawwds_19_tfmovvabr_sels_Count > 0 )
         {
            AddWhere(sWhereString, "("+new GxDbmsUtils( new GxSqlServer()).ValueList(AV73Configuracion_movimientoventawwds_19_tfmovvabr_sels, "[MovVAbr] IN (", ")")+")");
         }
         if ( AV74Configuracion_movimientoventawwds_20_tfmovvtip_sels_Count > 0 )
         {
            AddWhere(sWhereString, "("+new GxDbmsUtils( new GxSqlServer()).ValueList(AV74Configuracion_movimientoventawwds_20_tfmovvtip_sels, "[MovVTip] IN (", ")")+")");
         }
         if ( AV75Configuracion_movimientoventawwds_21_tfmovvsts_sels_Count > 0 )
         {
            AddWhere(sWhereString, "("+new GxDbmsUtils( new GxSqlServer()).ValueList(AV75Configuracion_movimientoventawwds_21_tfmovvsts_sels, "[MovVSts] IN (", ")")+")");
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
                     return conditional_H001F2(context, (string)dynConstraints[0] , (GxSimpleCollection<string>)dynConstraints[1] , (string)dynConstraints[2] , (GxSimpleCollection<string>)dynConstraints[3] , (short)dynConstraints[4] , (GxSimpleCollection<short>)dynConstraints[5] , (string)dynConstraints[6] , (short)dynConstraints[7] , (string)dynConstraints[8] , (string)dynConstraints[9] , (bool)dynConstraints[10] , (string)dynConstraints[11] , (short)dynConstraints[12] , (string)dynConstraints[13] , (string)dynConstraints[14] , (bool)dynConstraints[15] , (string)dynConstraints[16] , (short)dynConstraints[17] , (string)dynConstraints[18] , (string)dynConstraints[19] , (int)dynConstraints[20] , (int)dynConstraints[21] , (string)dynConstraints[22] , (string)dynConstraints[23] , (int)dynConstraints[24] , (int)dynConstraints[25] , (int)dynConstraints[26] , (string)dynConstraints[27] , (int)dynConstraints[28] , (short)dynConstraints[29] , (bool)dynConstraints[30] );
               case 1 :
                     return conditional_H001F3(context, (string)dynConstraints[0] , (GxSimpleCollection<string>)dynConstraints[1] , (string)dynConstraints[2] , (GxSimpleCollection<string>)dynConstraints[3] , (short)dynConstraints[4] , (GxSimpleCollection<short>)dynConstraints[5] , (string)dynConstraints[6] , (short)dynConstraints[7] , (string)dynConstraints[8] , (string)dynConstraints[9] , (bool)dynConstraints[10] , (string)dynConstraints[11] , (short)dynConstraints[12] , (string)dynConstraints[13] , (string)dynConstraints[14] , (bool)dynConstraints[15] , (string)dynConstraints[16] , (short)dynConstraints[17] , (string)dynConstraints[18] , (string)dynConstraints[19] , (int)dynConstraints[20] , (int)dynConstraints[21] , (string)dynConstraints[22] , (string)dynConstraints[23] , (int)dynConstraints[24] , (int)dynConstraints[25] , (int)dynConstraints[26] , (string)dynConstraints[27] , (int)dynConstraints[28] , (short)dynConstraints[29] , (bool)dynConstraints[30] );
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
          Object[] prmH001F2;
          prmH001F2 = new Object[] {
          new ParDef("@lV57Configuracion_movimientoventawwds_3_movvdsc1",GXType.NChar,100,0) ,
          new ParDef("@lV57Configuracion_movimientoventawwds_3_movvdsc1",GXType.NChar,100,0) ,
          new ParDef("@AV58Configuracion_movimientoventawwds_4_movvtip1",GXType.NChar,1,0) ,
          new ParDef("@lV62Configuracion_movimientoventawwds_8_movvdsc2",GXType.NChar,100,0) ,
          new ParDef("@lV62Configuracion_movimientoventawwds_8_movvdsc2",GXType.NChar,100,0) ,
          new ParDef("@AV63Configuracion_movimientoventawwds_9_movvtip2",GXType.NChar,1,0) ,
          new ParDef("@lV67Configuracion_movimientoventawwds_13_movvdsc3",GXType.NChar,100,0) ,
          new ParDef("@lV67Configuracion_movimientoventawwds_13_movvdsc3",GXType.NChar,100,0) ,
          new ParDef("@AV68Configuracion_movimientoventawwds_14_movvtip3",GXType.NChar,1,0) ,
          new ParDef("@AV69Configuracion_movimientoventawwds_15_tfmovvcod",GXType.Int32,6,0) ,
          new ParDef("@AV70Configuracion_movimientoventawwds_16_tfmovvcod_to",GXType.Int32,6,0) ,
          new ParDef("@lV71Configuracion_movimientoventawwds_17_tfmovvdsc",GXType.NChar,100,0) ,
          new ParDef("@AV72Configuracion_movimientoventawwds_18_tfmovvdsc_sel",GXType.NChar,100,0) ,
          new ParDef("@GXPagingFrom2",GXType.Int32,9,0) ,
          new ParDef("@GXPagingTo2",GXType.Int32,9,0) ,
          new ParDef("@GXPagingTo2",GXType.Int32,9,0)
          };
          Object[] prmH001F3;
          prmH001F3 = new Object[] {
          new ParDef("@lV57Configuracion_movimientoventawwds_3_movvdsc1",GXType.NChar,100,0) ,
          new ParDef("@lV57Configuracion_movimientoventawwds_3_movvdsc1",GXType.NChar,100,0) ,
          new ParDef("@AV58Configuracion_movimientoventawwds_4_movvtip1",GXType.NChar,1,0) ,
          new ParDef("@lV62Configuracion_movimientoventawwds_8_movvdsc2",GXType.NChar,100,0) ,
          new ParDef("@lV62Configuracion_movimientoventawwds_8_movvdsc2",GXType.NChar,100,0) ,
          new ParDef("@AV63Configuracion_movimientoventawwds_9_movvtip2",GXType.NChar,1,0) ,
          new ParDef("@lV67Configuracion_movimientoventawwds_13_movvdsc3",GXType.NChar,100,0) ,
          new ParDef("@lV67Configuracion_movimientoventawwds_13_movvdsc3",GXType.NChar,100,0) ,
          new ParDef("@AV68Configuracion_movimientoventawwds_14_movvtip3",GXType.NChar,1,0) ,
          new ParDef("@AV69Configuracion_movimientoventawwds_15_tfmovvcod",GXType.Int32,6,0) ,
          new ParDef("@AV70Configuracion_movimientoventawwds_16_tfmovvcod_to",GXType.Int32,6,0) ,
          new ParDef("@lV71Configuracion_movimientoventawwds_17_tfmovvdsc",GXType.NChar,100,0) ,
          new ParDef("@AV72Configuracion_movimientoventawwds_18_tfmovvdsc_sel",GXType.NChar,100,0)
          };
          def= new CursorDef[] {
              new CursorDef("H001F2", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH001F2,11, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("H001F3", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH001F3,1, GxCacheFrequency.OFF ,true,false )
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
                ((string[]) buf[2])[0] = rslt.getString(3, 5);
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
