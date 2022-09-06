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
   public class listapreciosww : GXDataArea
   {
      public listapreciosww( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDataStore2 = context.GetDataStore("DataStore2");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusTheme");
      }

      public listapreciosww( IGxContext context )
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
               AV17TipLProdDsc1 = GetPar( "TipLProdDsc1");
               AV18TipLDsc1 = GetPar( "TipLDsc1");
               cmbavDynamicfiltersselector2.FromJSonString( GetNextPar( ));
               AV20DynamicFiltersSelector2 = GetPar( "DynamicFiltersSelector2");
               cmbavDynamicfiltersoperator2.FromJSonString( GetNextPar( ));
               AV21DynamicFiltersOperator2 = (short)(NumberUtil.Val( GetPar( "DynamicFiltersOperator2"), "."));
               AV22TipLProdDsc2 = GetPar( "TipLProdDsc2");
               AV23TipLDsc2 = GetPar( "TipLDsc2");
               cmbavDynamicfiltersselector3.FromJSonString( GetNextPar( ));
               AV25DynamicFiltersSelector3 = GetPar( "DynamicFiltersSelector3");
               cmbavDynamicfiltersoperator3.FromJSonString( GetNextPar( ));
               AV26DynamicFiltersOperator3 = (short)(NumberUtil.Val( GetPar( "DynamicFiltersOperator3"), "."));
               AV27TipLProdDsc3 = GetPar( "TipLProdDsc3");
               AV28TipLDsc3 = GetPar( "TipLDsc3");
               AV19DynamicFiltersEnabled2 = StringUtil.StrToBool( GetPar( "DynamicFiltersEnabled2"));
               AV24DynamicFiltersEnabled3 = StringUtil.StrToBool( GetPar( "DynamicFiltersEnabled3"));
               AV67Pgmname = GetPar( "Pgmname");
               AV42TFTipLDsc = GetPar( "TFTipLDsc");
               AV43TFTipLDsc_Sel = GetPar( "TFTipLDsc_Sel");
               AV38TFProdCod = GetPar( "TFProdCod");
               AV39TFProdCod_Sel = GetPar( "TFProdCod_Sel");
               AV40TFTipLProdDsc = GetPar( "TFTipLProdDsc");
               AV41TFTipLProdDsc_Sel = GetPar( "TFTipLProdDsc_Sel");
               AV46TFCliCod = GetPar( "TFCliCod");
               AV47TFCliCod_Sel = GetPar( "TFCliCod_Sel");
               AV44TFPreLis = NumberUtil.Val( GetPar( "TFPreLis"), ".");
               AV45TFPreLis_To = NumberUtil.Val( GetPar( "TFPreLis_To"), ".");
               AV50TFLisFech = context.localUtil.ParseDateParm( GetPar( "TFLisFech"));
               AV51TFLisFech_To = context.localUtil.ParseDateParm( GetPar( "TFLisFech_To"));
               AV13OrderedBy = (short)(NumberUtil.Val( GetPar( "OrderedBy"), "."));
               AV14OrderedDsc = StringUtil.StrToBool( GetPar( "OrderedDsc"));
               ajax_req_read_hidden_sdt(GetNextPar( ), AV10GridState);
               AV30DynamicFiltersIgnoreFirst = StringUtil.StrToBool( GetPar( "DynamicFiltersIgnoreFirst"));
               AV29DynamicFiltersRemoving = StringUtil.StrToBool( GetPar( "DynamicFiltersRemoving"));
               setAjaxCallMode();
               if ( ! IsValidAjaxCall( true) )
               {
                  GxWebError = 1;
                  return  ;
               }
               gxgrGrid_refresh( subGrid_Rows, AV15DynamicFiltersSelector1, AV16DynamicFiltersOperator1, AV17TipLProdDsc1, AV18TipLDsc1, AV20DynamicFiltersSelector2, AV21DynamicFiltersOperator2, AV22TipLProdDsc2, AV23TipLDsc2, AV25DynamicFiltersSelector3, AV26DynamicFiltersOperator3, AV27TipLProdDsc3, AV28TipLDsc3, AV19DynamicFiltersEnabled2, AV24DynamicFiltersEnabled3, AV67Pgmname, AV42TFTipLDsc, AV43TFTipLDsc_Sel, AV38TFProdCod, AV39TFProdCod_Sel, AV40TFTipLProdDsc, AV41TFTipLProdDsc_Sel, AV46TFCliCod, AV47TFCliCod_Sel, AV44TFPreLis, AV45TFPreLis_To, AV50TFLisFech, AV51TFLisFech_To, AV13OrderedBy, AV14OrderedDsc, AV10GridState, AV30DynamicFiltersIgnoreFirst, AV29DynamicFiltersRemoving) ;
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
         PA1R2( ) ;
         gxajaxcallmode = (short)((isAjaxCallMode( ) ? 1 : 0));
         if ( ( gxajaxcallmode == 0 ) && ( GxWebError == 0 ) )
         {
            START1R2( ) ;
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
         context.AddJavascriptSource("gxcfg.js", "?202281810294895", false, true);
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
         context.AddJavascriptSource("DVelop/Shared/daterangepicker/locales.js", "", false, true);
         context.AddJavascriptSource("DVelop/Shared/daterangepicker/wwp-daterangepicker.js", "", false, true);
         context.AddJavascriptSource("DVelop/Shared/daterangepicker/moment.min.js", "", false, true);
         context.AddJavascriptSource("DVelop/Shared/daterangepicker/daterangepicker.min.js", "", false, true);
         context.AddJavascriptSource("DVelop/Shared/WorkWithPlusCommon.js", "", false, true);
         context.AddJavascriptSource("DVelop/DateRangePicker/DateRangePickerRender.js", "", false, true);
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
         context.WriteHtmlTextNl( "<form id=\"MAINFORM\" autocomplete=\"off\" name=\"MAINFORM\" method=\"post\" tabindex=-1  class=\"form-horizontal Form\" data-gx-class=\"form-horizontal Form\" novalidate action=\""+formatLink("configuracion.listapreciosww.aspx") +"\">") ;
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
         GxWebStd.gx_hidden_field( context, "gxhash_vPGMNAME", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( AV67Pgmname, "")), context));
         GXKey = Crypto.GetSiteKey( );
      }

      protected void SendCloseFormHiddens( )
      {
         /* Send hidden variables. */
         GxWebStd.gx_hidden_field( context, "GXH_vDYNAMICFILTERSSELECTOR1", AV15DynamicFiltersSelector1);
         GxWebStd.gx_hidden_field( context, "GXH_vDYNAMICFILTERSOPERATOR1", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV16DynamicFiltersOperator1), 4, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "GXH_vTIPLPRODDSC1", StringUtil.RTrim( AV17TipLProdDsc1));
         GxWebStd.gx_hidden_field( context, "GXH_vTIPLDSC1", StringUtil.RTrim( AV18TipLDsc1));
         GxWebStd.gx_hidden_field( context, "GXH_vDYNAMICFILTERSSELECTOR2", AV20DynamicFiltersSelector2);
         GxWebStd.gx_hidden_field( context, "GXH_vDYNAMICFILTERSOPERATOR2", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV21DynamicFiltersOperator2), 4, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "GXH_vTIPLPRODDSC2", StringUtil.RTrim( AV22TipLProdDsc2));
         GxWebStd.gx_hidden_field( context, "GXH_vTIPLDSC2", StringUtil.RTrim( AV23TipLDsc2));
         GxWebStd.gx_hidden_field( context, "GXH_vDYNAMICFILTERSSELECTOR3", AV25DynamicFiltersSelector3);
         GxWebStd.gx_hidden_field( context, "GXH_vDYNAMICFILTERSOPERATOR3", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV26DynamicFiltersOperator3), 4, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "GXH_vTIPLPRODDSC3", StringUtil.RTrim( AV27TipLProdDsc3));
         GxWebStd.gx_hidden_field( context, "GXH_vTIPLDSC3", StringUtil.RTrim( AV28TipLDsc3));
         /* Send saved values. */
         send_integrity_footer_hashes( ) ;
         GxWebStd.gx_hidden_field( context, "nRC_GXsfl_110", StringUtil.LTrim( StringUtil.NToC( (decimal)(nRC_GXsfl_110), 8, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "vGRIDCURRENTPAGE", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV59GridCurrentPage), 10, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "vGRIDPAGECOUNT", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV60GridPageCount), 10, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "vGRIDAPPLIEDFILTERS", AV61GridAppliedFilters);
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "vAGEXPORTDATA", AV63AGExportData);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt("vAGEXPORTDATA", AV63AGExportData);
         }
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "vDDO_TITLESETTINGSICONS", AV57DDO_TitleSettingsIcons);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt("vDDO_TITLESETTINGSICONS", AV57DDO_TitleSettingsIcons);
         }
         GxWebStd.gx_hidden_field( context, "vDDO_LISFECHAUXDATETO", context.localUtil.DToC( AV53DDO_LisFechAuxDateTo, 0, "/"));
         GxWebStd.gx_boolean_hidden_field( context, "vDYNAMICFILTERSENABLED2", AV19DynamicFiltersEnabled2);
         GxWebStd.gx_boolean_hidden_field( context, "vDYNAMICFILTERSENABLED3", AV24DynamicFiltersEnabled3);
         GxWebStd.gx_hidden_field( context, "vPGMNAME", StringUtil.RTrim( AV67Pgmname));
         GxWebStd.gx_hidden_field( context, "gxhash_vPGMNAME", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( AV67Pgmname, "")), context));
         GxWebStd.gx_hidden_field( context, "vTFTIPLDSC", StringUtil.RTrim( AV42TFTipLDsc));
         GxWebStd.gx_hidden_field( context, "vTFTIPLDSC_SEL", StringUtil.RTrim( AV43TFTipLDsc_Sel));
         GxWebStd.gx_hidden_field( context, "vTFPRODCOD", StringUtil.RTrim( AV38TFProdCod));
         GxWebStd.gx_hidden_field( context, "vTFPRODCOD_SEL", StringUtil.RTrim( AV39TFProdCod_Sel));
         GxWebStd.gx_hidden_field( context, "vTFTIPLPRODDSC", StringUtil.RTrim( AV40TFTipLProdDsc));
         GxWebStd.gx_hidden_field( context, "vTFTIPLPRODDSC_SEL", StringUtil.RTrim( AV41TFTipLProdDsc_Sel));
         GxWebStd.gx_hidden_field( context, "vTFCLICOD", StringUtil.RTrim( AV46TFCliCod));
         GxWebStd.gx_hidden_field( context, "vTFCLICOD_SEL", StringUtil.RTrim( AV47TFCliCod_Sel));
         GxWebStd.gx_hidden_field( context, "vTFPRELIS", StringUtil.LTrim( StringUtil.NToC( AV44TFPreLis, 15, 4, ".", "")));
         GxWebStd.gx_hidden_field( context, "vTFPRELIS_TO", StringUtil.LTrim( StringUtil.NToC( AV45TFPreLis_To, 15, 4, ".", "")));
         GxWebStd.gx_hidden_field( context, "vTFLISFECH", context.localUtil.DToC( AV50TFLisFech, 0, "/"));
         GxWebStd.gx_hidden_field( context, "vTFLISFECH_TO", context.localUtil.DToC( AV51TFLisFech_To, 0, "/"));
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
         GxWebStd.gx_boolean_hidden_field( context, "vDYNAMICFILTERSIGNOREFIRST", AV30DynamicFiltersIgnoreFirst);
         GxWebStd.gx_boolean_hidden_field( context, "vDYNAMICFILTERSREMOVING", AV29DynamicFiltersRemoving);
         GxWebStd.gx_hidden_field( context, "GRID_nFirstRecordOnPage", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRID_nFirstRecordOnPage), 15, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "GRID_nEOF", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRID_nEOF), 1, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "vDDO_LISFECHAUXDATE", context.localUtil.DToC( AV52DDO_LisFechAuxDate, 0, "/"));
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
            WE1R2( ) ;
            context.WriteHtmlText( "</div>") ;
         }
      }

      public override void DispatchEvents( )
      {
         EVT1R2( ) ;
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
         return formatLink("configuracion.listapreciosww.aspx")  ;
      }

      public override string GetPgmname( )
      {
         return "Configuracion.ListaPreciosWW" ;
      }

      public override string GetPgmdesc( )
      {
         return " Lista de Precios" ;
      }

      protected void WB1R0( )
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
            GxWebStd.gx_button_ctrl( context, bttBtninsert_Internalname, "gx.evt.setGridEvt("+StringUtil.Str( (decimal)(110), 3, 0)+","+"null"+");", "Agregar", bttBtninsert_Jsonclick, 5, "Agregar", "", StyleString, ClassString, 1, 1, "standard", "'"+""+"'"+",false,"+"'"+"E\\'DOINSERT\\'."+"'", TempTags, "", context.GetButtonType( ), "HLP_Configuracion\\ListaPreciosWW.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "left", "top", "", "", "div");
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 21,'',false,'',0)\"";
            ClassString = "ColumnsSelector";
            StyleString = "";
            GxWebStd.gx_button_ctrl( context, bttBtnagexport_Internalname, "gx.evt.setGridEvt("+StringUtil.Str( (decimal)(110), 3, 0)+","+"null"+");", "Reportes", bttBtnagexport_Jsonclick, 0, "Reportes", "", StyleString, ClassString, 1, 0, "standard", "'"+""+"'"+",false,"+"'"+""+"'", TempTags, "", context.GetButtonType( ), "HLP_Configuracion\\ListaPreciosWW.htm");
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
            wb_table1_25_1R2( true) ;
         }
         else
         {
            wb_table1_25_1R2( false) ;
         }
         return  ;
      }

      protected void wb_table1_25_1R2e( bool wbgen )
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
               context.WriteHtmlText( "<th align=\""+"right"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+"display:none;"+""+"\" "+">") ;
               context.SendWebValue( "Codigo Tipo de Lista") ;
               context.WriteHtmlTextNl( "</th>") ;
               context.WriteHtmlText( "<th align=\""+"right"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+"display:none;"+""+"\" "+">") ;
               context.SendWebValue( "Item") ;
               context.WriteHtmlTextNl( "</th>") ;
               context.WriteHtmlText( "<th align=\""+"left"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+""+""+"\" "+">") ;
               context.SendWebValue( "Tipo de Lista") ;
               context.WriteHtmlTextNl( "</th>") ;
               context.WriteHtmlText( "<th align=\""+"left"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+""+""+"\" "+">") ;
               context.SendWebValue( "Codigo") ;
               context.WriteHtmlTextNl( "</th>") ;
               context.WriteHtmlText( "<th align=\""+"left"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+""+""+"\" "+">") ;
               context.SendWebValue( "Producto") ;
               context.WriteHtmlTextNl( "</th>") ;
               context.WriteHtmlText( "<th align=\""+"left"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+""+""+"\" "+">") ;
               context.SendWebValue( "R.U.C. Cliente") ;
               context.WriteHtmlTextNl( "</th>") ;
               context.WriteHtmlText( "<th align=\""+"right"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+""+""+"\" "+">") ;
               context.SendWebValue( "Precio") ;
               context.WriteHtmlTextNl( "</th>") ;
               context.WriteHtmlText( "<th align=\""+"right"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+""+""+"\" "+">") ;
               context.SendWebValue( "Fecha") ;
               context.WriteHtmlTextNl( "</th>") ;
               context.WriteHtmlText( "<th align=\""+"left"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+"display:none;"+""+"\" "+">") ;
               context.SendWebValue( "Nombre Cliente") ;
               context.WriteHtmlTextNl( "</th>") ;
               context.WriteHtmlText( "<th align=\""+"right"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+"display:none;"+""+"\" "+">") ;
               context.SendWebValue( "Precio Credito") ;
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
               GridColumn.AddObjectProperty("Value", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV62GridActions), 4, 0, ".", "")));
               GridContainer.AddColumnProperties(GridColumn);
               GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
               GridColumn.AddObjectProperty("Value", StringUtil.LTrim( StringUtil.NToC( (decimal)(A202TipLCod), 6, 0, ".", "")));
               GridContainer.AddColumnProperties(GridColumn);
               GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
               GridColumn.AddObjectProperty("Value", StringUtil.LTrim( StringUtil.NToC( (decimal)(A203TipLItem), 6, 0, ".", "")));
               GridContainer.AddColumnProperties(GridColumn);
               GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
               GridColumn.AddObjectProperty("Value", StringUtil.RTrim( A1912TipLDsc));
               GridColumn.AddObjectProperty("Link", StringUtil.RTrim( edtTipLDsc_Link));
               GridContainer.AddColumnProperties(GridColumn);
               GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
               GridColumn.AddObjectProperty("Value", StringUtil.RTrim( A28ProdCod));
               GridContainer.AddColumnProperties(GridColumn);
               GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
               GridColumn.AddObjectProperty("Value", StringUtil.RTrim( A1913TipLProdDsc));
               GridColumn.AddObjectProperty("Link", StringUtil.RTrim( edtTipLProdDsc_Link));
               GridContainer.AddColumnProperties(GridColumn);
               GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
               GridColumn.AddObjectProperty("Value", StringUtil.RTrim( A45CliCod));
               GridContainer.AddColumnProperties(GridColumn);
               GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
               GridColumn.AddObjectProperty("Value", StringUtil.LTrim( StringUtil.NToC( A1651PreLis, 17, 4, ".", "")));
               GridContainer.AddColumnProperties(GridColumn);
               GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
               GridColumn.AddObjectProperty("Value", context.localUtil.Format(A1205LisFech, "99/99/99"));
               GridContainer.AddColumnProperties(GridColumn);
               GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
               GridColumn.AddObjectProperty("Value", StringUtil.RTrim( A161CliDsc));
               GridContainer.AddColumnProperties(GridColumn);
               GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
               GridColumn.AddObjectProperty("Value", StringUtil.LTrim( StringUtil.NToC( A1652PreLisCred, 17, 4, ".", "")));
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
            ucGridpaginationbar.SetProperty("CurrentPage", AV59GridCurrentPage);
            ucGridpaginationbar.SetProperty("PageCount", AV60GridPageCount);
            ucGridpaginationbar.SetProperty("AppliedFilters", AV61GridAppliedFilters);
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
            ucDdo_agexport.SetProperty("DropDownOptionsData", AV63AGExportData);
            ucDdo_agexport.Render(context, "dvelop.gxbootstrap.ddoregular", Ddo_agexport_Internalname, "DDO_AGEXPORTContainer");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblJsdynamicfilters_Internalname, lblJsdynamicfilters_Caption, "", "", lblJsdynamicfilters_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "", 0, "", 1, 1, 0, 1, "HLP_Configuracion\\ListaPreciosWW.htm");
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
            ucDdo_grid.SetProperty("DataListProc", Ddo_grid_Datalistproc);
            ucDdo_grid.SetProperty("DropDownOptionsTitleSettingsIcons", AV57DDO_TitleSettingsIcons);
            ucDdo_grid.Render(context, "dvelop.gxbootstrap.ddogridtitlesettingsm", Ddo_grid_Internalname, "DDO_GRIDContainer");
            /* User Defined Control */
            ucInnewwindow1.Render(context, "innewwindow", Innewwindow1_Internalname, "INNEWWINDOW1Container");
            /* User Defined Control */
            ucGrid_empowerer.SetProperty("HasTitleSettings", Grid_empowerer_Hastitlesettings);
            ucGrid_empowerer.Render(context, "wwp.gridempowerer", Grid_empowerer_Internalname, "GRID_EMPOWERERContainer");
            /* Div Control */
            GxWebStd.gx_div_start( context, divDdo_lisfechauxdates_Internalname, 1, 0, "px", 0, "px", "Invisible", "left", "top", "", "", "div");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 134,'',false,'" + sGXsfl_110_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavDdo_lisfechauxdatetext_Internalname, AV54DDO_LisFechAuxDateText, StringUtil.RTrim( context.localUtil.Format( AV54DDO_LisFechAuxDateText, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,134);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavDdo_lisfechauxdatetext_Jsonclick, 0, "Attribute", "", "", "", "", 1, 1, 0, "text", "", 40, "chr", 1, "row", 40, 0, 0, 0, 1, -1, -1, true, "", "left", true, "", "HLP_Configuracion\\ListaPreciosWW.htm");
            /* User Defined Control */
            ucTflisfech_rangepicker.SetProperty("Start Date", AV52DDO_LisFechAuxDate);
            ucTflisfech_rangepicker.SetProperty("End Date", AV53DDO_LisFechAuxDateTo);
            ucTflisfech_rangepicker.Render(context, "wwp.daterangepicker", Tflisfech_rangepicker_Internalname, "TFLISFECH_RANGEPICKERContainer");
            GxWebStd.gx_div_end( context, "left", "top", "div");
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

      protected void START1R2( )
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
            Form.Meta.addItem("description", " Lista de Precios", 0) ;
         }
         context.wjLoc = "";
         context.nUserReturn = 0;
         context.wbHandled = 0;
         if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
         {
         }
         wbErr = false;
         STRUP1R0( ) ;
      }

      protected void WS1R2( )
      {
         START1R2( ) ;
         EVT1R2( ) ;
      }

      protected void EVT1R2( )
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
                              E111R2 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "GRIDPAGINATIONBAR.CHANGEROWSPERPAGE") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              E121R2 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "DDO_AGEXPORT.ONOPTIONCLICKED") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              E131R2 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "DDO_GRID.ONOPTIONCLICKED") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              E141R2 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "'REMOVEDYNAMICFILTERS1'") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              /* Execute user event: 'RemoveDynamicFilters1' */
                              E151R2 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "'REMOVEDYNAMICFILTERS2'") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              /* Execute user event: 'RemoveDynamicFilters2' */
                              E161R2 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "'REMOVEDYNAMICFILTERS3'") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              /* Execute user event: 'RemoveDynamicFilters3' */
                              E171R2 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "'DOINSERT'") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              /* Execute user event: 'DoInsert' */
                              E181R2 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "'ADDDYNAMICFILTERS1'") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              /* Execute user event: 'AddDynamicFilters1' */
                              E191R2 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "VDYNAMICFILTERSSELECTOR1.CLICK") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              E201R2 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "'ADDDYNAMICFILTERS2'") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              /* Execute user event: 'AddDynamicFilters2' */
                              E211R2 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "VDYNAMICFILTERSSELECTOR2.CLICK") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              E221R2 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "VDYNAMICFILTERSSELECTOR3.CLICK") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              E231R2 ();
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
                              AV62GridActions = (short)(NumberUtil.Val( cgiGet( cmbavGridactions_Internalname), "."));
                              AssignAttri("", false, cmbavGridactions_Internalname, StringUtil.LTrimStr( (decimal)(AV62GridActions), 4, 0));
                              A202TipLCod = (int)(context.localUtil.CToN( cgiGet( edtTipLCod_Internalname), ".", ","));
                              A203TipLItem = (int)(context.localUtil.CToN( cgiGet( edtTipLItem_Internalname), ".", ","));
                              A1912TipLDsc = cgiGet( edtTipLDsc_Internalname);
                              A28ProdCod = StringUtil.Upper( cgiGet( edtProdCod_Internalname));
                              A1913TipLProdDsc = cgiGet( edtTipLProdDsc_Internalname);
                              A45CliCod = cgiGet( edtCliCod_Internalname);
                              n45CliCod = false;
                              A1651PreLis = context.localUtil.CToN( cgiGet( edtPreLis_Internalname), ".", ",");
                              A1205LisFech = DateTimeUtil.ResetTime(context.localUtil.CToT( cgiGet( edtLisFech_Internalname), 0));
                              A161CliDsc = cgiGet( edtCliDsc_Internalname);
                              n161CliDsc = false;
                              A1652PreLisCred = context.localUtil.CToN( cgiGet( edtPreLisCred_Internalname), ".", ",");
                              sEvtType = StringUtil.Right( sEvt, 1);
                              if ( StringUtil.StrCmp(sEvtType, ".") == 0 )
                              {
                                 sEvt = StringUtil.Left( sEvt, (short)(StringUtil.Len( sEvt)-1));
                                 if ( StringUtil.StrCmp(sEvt, "START") == 0 )
                                 {
                                    context.wbHandled = 1;
                                    dynload_actions( ) ;
                                    /* Execute user event: Start */
                                    E241R2 ();
                                 }
                                 else if ( StringUtil.StrCmp(sEvt, "REFRESH") == 0 )
                                 {
                                    context.wbHandled = 1;
                                    dynload_actions( ) ;
                                    /* Execute user event: Refresh */
                                    E251R2 ();
                                 }
                                 else if ( StringUtil.StrCmp(sEvt, "GRID.LOAD") == 0 )
                                 {
                                    context.wbHandled = 1;
                                    dynload_actions( ) ;
                                    E261R2 ();
                                 }
                                 else if ( StringUtil.StrCmp(sEvt, "VGRIDACTIONS.CLICK") == 0 )
                                 {
                                    context.wbHandled = 1;
                                    dynload_actions( ) ;
                                    E271R2 ();
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
                                       /* Set Refresh If Tiplproddsc1 Changed */
                                       if ( StringUtil.StrCmp(cgiGet( "GXH_vTIPLPRODDSC1"), AV17TipLProdDsc1) != 0 )
                                       {
                                          Rfr0gs = true;
                                       }
                                       /* Set Refresh If Tipldsc1 Changed */
                                       if ( StringUtil.StrCmp(cgiGet( "GXH_vTIPLDSC1"), AV18TipLDsc1) != 0 )
                                       {
                                          Rfr0gs = true;
                                       }
                                       /* Set Refresh If Dynamicfiltersselector2 Changed */
                                       if ( StringUtil.StrCmp(cgiGet( "GXH_vDYNAMICFILTERSSELECTOR2"), AV20DynamicFiltersSelector2) != 0 )
                                       {
                                          Rfr0gs = true;
                                       }
                                       /* Set Refresh If Dynamicfiltersoperator2 Changed */
                                       if ( ( context.localUtil.CToN( cgiGet( "GXH_vDYNAMICFILTERSOPERATOR2"), ".", ",") != Convert.ToDecimal( AV21DynamicFiltersOperator2 )) )
                                       {
                                          Rfr0gs = true;
                                       }
                                       /* Set Refresh If Tiplproddsc2 Changed */
                                       if ( StringUtil.StrCmp(cgiGet( "GXH_vTIPLPRODDSC2"), AV22TipLProdDsc2) != 0 )
                                       {
                                          Rfr0gs = true;
                                       }
                                       /* Set Refresh If Tipldsc2 Changed */
                                       if ( StringUtil.StrCmp(cgiGet( "GXH_vTIPLDSC2"), AV23TipLDsc2) != 0 )
                                       {
                                          Rfr0gs = true;
                                       }
                                       /* Set Refresh If Dynamicfiltersselector3 Changed */
                                       if ( StringUtil.StrCmp(cgiGet( "GXH_vDYNAMICFILTERSSELECTOR3"), AV25DynamicFiltersSelector3) != 0 )
                                       {
                                          Rfr0gs = true;
                                       }
                                       /* Set Refresh If Dynamicfiltersoperator3 Changed */
                                       if ( ( context.localUtil.CToN( cgiGet( "GXH_vDYNAMICFILTERSOPERATOR3"), ".", ",") != Convert.ToDecimal( AV26DynamicFiltersOperator3 )) )
                                       {
                                          Rfr0gs = true;
                                       }
                                       /* Set Refresh If Tiplproddsc3 Changed */
                                       if ( StringUtil.StrCmp(cgiGet( "GXH_vTIPLPRODDSC3"), AV27TipLProdDsc3) != 0 )
                                       {
                                          Rfr0gs = true;
                                       }
                                       /* Set Refresh If Tipldsc3 Changed */
                                       if ( StringUtil.StrCmp(cgiGet( "GXH_vTIPLDSC3"), AV28TipLDsc3) != 0 )
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

      protected void WE1R2( )
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

      protected void PA1R2( )
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
                                       string AV17TipLProdDsc1 ,
                                       string AV18TipLDsc1 ,
                                       string AV20DynamicFiltersSelector2 ,
                                       short AV21DynamicFiltersOperator2 ,
                                       string AV22TipLProdDsc2 ,
                                       string AV23TipLDsc2 ,
                                       string AV25DynamicFiltersSelector3 ,
                                       short AV26DynamicFiltersOperator3 ,
                                       string AV27TipLProdDsc3 ,
                                       string AV28TipLDsc3 ,
                                       bool AV19DynamicFiltersEnabled2 ,
                                       bool AV24DynamicFiltersEnabled3 ,
                                       string AV67Pgmname ,
                                       string AV42TFTipLDsc ,
                                       string AV43TFTipLDsc_Sel ,
                                       string AV38TFProdCod ,
                                       string AV39TFProdCod_Sel ,
                                       string AV40TFTipLProdDsc ,
                                       string AV41TFTipLProdDsc_Sel ,
                                       string AV46TFCliCod ,
                                       string AV47TFCliCod_Sel ,
                                       decimal AV44TFPreLis ,
                                       decimal AV45TFPreLis_To ,
                                       DateTime AV50TFLisFech ,
                                       DateTime AV51TFLisFech_To ,
                                       short AV13OrderedBy ,
                                       bool AV14OrderedDsc ,
                                       GeneXus.Programs.wwpbaseobjects.SdtWWPGridState AV10GridState ,
                                       bool AV30DynamicFiltersIgnoreFirst ,
                                       bool AV29DynamicFiltersRemoving )
      {
         initialize_formulas( ) ;
         GxWebStd.set_html_headers( context, 0, "", "");
         /* Execute user event: Refresh */
         E251R2 ();
         GRID_nCurrentRecord = 0;
         RF1R2( ) ;
         GXKey = Crypto.GetSiteKey( );
         send_integrity_footer_hashes( ) ;
         GXKey = Crypto.GetSiteKey( );
         /* End function gxgrGrid_refresh */
      }

      protected void send_integrity_hashes( )
      {
         GxWebStd.gx_hidden_field( context, "gxhash_TIPLCOD", GetSecureSignedToken( "", context.localUtil.Format( (decimal)(A202TipLCod), "ZZZZZ9"), context));
         GxWebStd.gx_hidden_field( context, "TIPLCOD", StringUtil.LTrim( StringUtil.NToC( (decimal)(A202TipLCod), 6, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "gxhash_TIPLITEM", GetSecureSignedToken( "", context.localUtil.Format( (decimal)(A203TipLItem), "ZZZZZ9"), context));
         GxWebStd.gx_hidden_field( context, "TIPLITEM", StringUtil.LTrim( StringUtil.NToC( (decimal)(A203TipLItem), 6, 0, ".", "")));
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
            AV20DynamicFiltersSelector2 = cmbavDynamicfiltersselector2.getValidValue(AV20DynamicFiltersSelector2);
            AssignAttri("", false, "AV20DynamicFiltersSelector2", AV20DynamicFiltersSelector2);
         }
         if ( context.isAjaxRequest( ) )
         {
            cmbavDynamicfiltersselector2.CurrentValue = StringUtil.RTrim( AV20DynamicFiltersSelector2);
            AssignProp("", false, cmbavDynamicfiltersselector2_Internalname, "Values", cmbavDynamicfiltersselector2.ToJavascriptSource(), true);
         }
         if ( cmbavDynamicfiltersoperator2.ItemCount > 0 )
         {
            AV21DynamicFiltersOperator2 = (short)(NumberUtil.Val( cmbavDynamicfiltersoperator2.getValidValue(StringUtil.Trim( StringUtil.Str( (decimal)(AV21DynamicFiltersOperator2), 4, 0))), "."));
            AssignAttri("", false, "AV21DynamicFiltersOperator2", StringUtil.LTrimStr( (decimal)(AV21DynamicFiltersOperator2), 4, 0));
         }
         if ( context.isAjaxRequest( ) )
         {
            cmbavDynamicfiltersoperator2.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV21DynamicFiltersOperator2), 4, 0));
            AssignProp("", false, cmbavDynamicfiltersoperator2_Internalname, "Values", cmbavDynamicfiltersoperator2.ToJavascriptSource(), true);
         }
         if ( cmbavDynamicfiltersselector3.ItemCount > 0 )
         {
            AV25DynamicFiltersSelector3 = cmbavDynamicfiltersselector3.getValidValue(AV25DynamicFiltersSelector3);
            AssignAttri("", false, "AV25DynamicFiltersSelector3", AV25DynamicFiltersSelector3);
         }
         if ( context.isAjaxRequest( ) )
         {
            cmbavDynamicfiltersselector3.CurrentValue = StringUtil.RTrim( AV25DynamicFiltersSelector3);
            AssignProp("", false, cmbavDynamicfiltersselector3_Internalname, "Values", cmbavDynamicfiltersselector3.ToJavascriptSource(), true);
         }
         if ( cmbavDynamicfiltersoperator3.ItemCount > 0 )
         {
            AV26DynamicFiltersOperator3 = (short)(NumberUtil.Val( cmbavDynamicfiltersoperator3.getValidValue(StringUtil.Trim( StringUtil.Str( (decimal)(AV26DynamicFiltersOperator3), 4, 0))), "."));
            AssignAttri("", false, "AV26DynamicFiltersOperator3", StringUtil.LTrimStr( (decimal)(AV26DynamicFiltersOperator3), 4, 0));
         }
         if ( context.isAjaxRequest( ) )
         {
            cmbavDynamicfiltersoperator3.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV26DynamicFiltersOperator3), 4, 0));
            AssignProp("", false, cmbavDynamicfiltersoperator3_Internalname, "Values", cmbavDynamicfiltersoperator3.ToJavascriptSource(), true);
         }
      }

      public void Refresh( )
      {
         send_integrity_hashes( ) ;
         RF1R2( ) ;
         if ( isFullAjaxMode( ) )
         {
            send_integrity_footer_hashes( ) ;
         }
      }

      protected void initialize_formulas( )
      {
         /* GeneXus formulas. */
         AV67Pgmname = "Configuracion.ListaPreciosWW";
         context.Gx_err = 0;
      }

      protected void RF1R2( )
      {
         initialize_formulas( ) ;
         clear_multi_value_controls( ) ;
         if ( isAjaxCallMode( ) )
         {
            GridContainer.ClearRows();
         }
         wbStart = 110;
         /* Execute user event: Refresh */
         E251R2 ();
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
                                                 AV68Configuracion_listaprecioswwds_1_dynamicfiltersselector1 ,
                                                 AV69Configuracion_listaprecioswwds_2_dynamicfiltersoperator1 ,
                                                 AV70Configuracion_listaprecioswwds_3_tiplproddsc1 ,
                                                 AV71Configuracion_listaprecioswwds_4_tipldsc1 ,
                                                 AV72Configuracion_listaprecioswwds_5_dynamicfiltersenabled2 ,
                                                 AV73Configuracion_listaprecioswwds_6_dynamicfiltersselector2 ,
                                                 AV74Configuracion_listaprecioswwds_7_dynamicfiltersoperator2 ,
                                                 AV75Configuracion_listaprecioswwds_8_tiplproddsc2 ,
                                                 AV76Configuracion_listaprecioswwds_9_tipldsc2 ,
                                                 AV77Configuracion_listaprecioswwds_10_dynamicfiltersenabled3 ,
                                                 AV78Configuracion_listaprecioswwds_11_dynamicfiltersselector3 ,
                                                 AV79Configuracion_listaprecioswwds_12_dynamicfiltersoperator3 ,
                                                 AV80Configuracion_listaprecioswwds_13_tiplproddsc3 ,
                                                 AV81Configuracion_listaprecioswwds_14_tipldsc3 ,
                                                 AV83Configuracion_listaprecioswwds_16_tftipldsc_sel ,
                                                 AV82Configuracion_listaprecioswwds_15_tftipldsc ,
                                                 AV85Configuracion_listaprecioswwds_18_tfprodcod_sel ,
                                                 AV84Configuracion_listaprecioswwds_17_tfprodcod ,
                                                 AV87Configuracion_listaprecioswwds_20_tftiplproddsc_sel ,
                                                 AV86Configuracion_listaprecioswwds_19_tftiplproddsc ,
                                                 AV89Configuracion_listaprecioswwds_22_tfclicod_sel ,
                                                 AV88Configuracion_listaprecioswwds_21_tfclicod ,
                                                 AV90Configuracion_listaprecioswwds_23_tfprelis ,
                                                 AV91Configuracion_listaprecioswwds_24_tfprelis_to ,
                                                 AV92Configuracion_listaprecioswwds_25_tflisfech ,
                                                 AV93Configuracion_listaprecioswwds_26_tflisfech_to ,
                                                 A1913TipLProdDsc ,
                                                 A1912TipLDsc ,
                                                 A28ProdCod ,
                                                 A45CliCod ,
                                                 A1651PreLis ,
                                                 A1205LisFech ,
                                                 AV13OrderedBy ,
                                                 AV14OrderedDsc } ,
                                                 new int[]{
                                                 TypeConstants.SHORT, TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.DECIMAL, TypeConstants.DECIMAL, TypeConstants.DATE, TypeConstants.DATE, TypeConstants.BOOLEAN,
                                                 TypeConstants.DECIMAL, TypeConstants.DATE, TypeConstants.SHORT, TypeConstants.BOOLEAN
                                                 }
            });
            lV70Configuracion_listaprecioswwds_3_tiplproddsc1 = StringUtil.PadR( StringUtil.RTrim( AV70Configuracion_listaprecioswwds_3_tiplproddsc1), 100, "%");
            lV70Configuracion_listaprecioswwds_3_tiplproddsc1 = StringUtil.PadR( StringUtil.RTrim( AV70Configuracion_listaprecioswwds_3_tiplproddsc1), 100, "%");
            lV71Configuracion_listaprecioswwds_4_tipldsc1 = StringUtil.PadR( StringUtil.RTrim( AV71Configuracion_listaprecioswwds_4_tipldsc1), 100, "%");
            lV71Configuracion_listaprecioswwds_4_tipldsc1 = StringUtil.PadR( StringUtil.RTrim( AV71Configuracion_listaprecioswwds_4_tipldsc1), 100, "%");
            lV75Configuracion_listaprecioswwds_8_tiplproddsc2 = StringUtil.PadR( StringUtil.RTrim( AV75Configuracion_listaprecioswwds_8_tiplproddsc2), 100, "%");
            lV75Configuracion_listaprecioswwds_8_tiplproddsc2 = StringUtil.PadR( StringUtil.RTrim( AV75Configuracion_listaprecioswwds_8_tiplproddsc2), 100, "%");
            lV76Configuracion_listaprecioswwds_9_tipldsc2 = StringUtil.PadR( StringUtil.RTrim( AV76Configuracion_listaprecioswwds_9_tipldsc2), 100, "%");
            lV76Configuracion_listaprecioswwds_9_tipldsc2 = StringUtil.PadR( StringUtil.RTrim( AV76Configuracion_listaprecioswwds_9_tipldsc2), 100, "%");
            lV80Configuracion_listaprecioswwds_13_tiplproddsc3 = StringUtil.PadR( StringUtil.RTrim( AV80Configuracion_listaprecioswwds_13_tiplproddsc3), 100, "%");
            lV80Configuracion_listaprecioswwds_13_tiplproddsc3 = StringUtil.PadR( StringUtil.RTrim( AV80Configuracion_listaprecioswwds_13_tiplproddsc3), 100, "%");
            lV81Configuracion_listaprecioswwds_14_tipldsc3 = StringUtil.PadR( StringUtil.RTrim( AV81Configuracion_listaprecioswwds_14_tipldsc3), 100, "%");
            lV81Configuracion_listaprecioswwds_14_tipldsc3 = StringUtil.PadR( StringUtil.RTrim( AV81Configuracion_listaprecioswwds_14_tipldsc3), 100, "%");
            lV82Configuracion_listaprecioswwds_15_tftipldsc = StringUtil.PadR( StringUtil.RTrim( AV82Configuracion_listaprecioswwds_15_tftipldsc), 100, "%");
            lV84Configuracion_listaprecioswwds_17_tfprodcod = StringUtil.PadR( StringUtil.RTrim( AV84Configuracion_listaprecioswwds_17_tfprodcod), 15, "%");
            lV86Configuracion_listaprecioswwds_19_tftiplproddsc = StringUtil.PadR( StringUtil.RTrim( AV86Configuracion_listaprecioswwds_19_tftiplproddsc), 100, "%");
            lV88Configuracion_listaprecioswwds_21_tfclicod = StringUtil.PadR( StringUtil.RTrim( AV88Configuracion_listaprecioswwds_21_tfclicod), 20, "%");
            /* Using cursor H001R2 */
            pr_default.execute(0, new Object[] {lV70Configuracion_listaprecioswwds_3_tiplproddsc1, lV70Configuracion_listaprecioswwds_3_tiplproddsc1, lV71Configuracion_listaprecioswwds_4_tipldsc1, lV71Configuracion_listaprecioswwds_4_tipldsc1, lV75Configuracion_listaprecioswwds_8_tiplproddsc2, lV75Configuracion_listaprecioswwds_8_tiplproddsc2, lV76Configuracion_listaprecioswwds_9_tipldsc2, lV76Configuracion_listaprecioswwds_9_tipldsc2, lV80Configuracion_listaprecioswwds_13_tiplproddsc3, lV80Configuracion_listaprecioswwds_13_tiplproddsc3, lV81Configuracion_listaprecioswwds_14_tipldsc3, lV81Configuracion_listaprecioswwds_14_tipldsc3, lV82Configuracion_listaprecioswwds_15_tftipldsc, AV83Configuracion_listaprecioswwds_16_tftipldsc_sel, lV84Configuracion_listaprecioswwds_17_tfprodcod, AV85Configuracion_listaprecioswwds_18_tfprodcod_sel, lV86Configuracion_listaprecioswwds_19_tftiplproddsc, AV87Configuracion_listaprecioswwds_20_tftiplproddsc_sel, lV88Configuracion_listaprecioswwds_21_tfclicod, AV89Configuracion_listaprecioswwds_22_tfclicod_sel, AV90Configuracion_listaprecioswwds_23_tfprelis, AV91Configuracion_listaprecioswwds_24_tfprelis_to, AV92Configuracion_listaprecioswwds_25_tflisfech, AV93Configuracion_listaprecioswwds_26_tflisfech_to, GXPagingFrom2, GXPagingTo2, GXPagingTo2});
            nGXsfl_110_idx = 1;
            sGXsfl_110_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_110_idx), 4, 0), 4, "0");
            SubsflControlProps_1102( ) ;
            while ( ( (pr_default.getStatus(0) != 101) ) && ( ( ( subGrid_Rows == 0 ) || ( GRID_nCurrentRecord < subGrid_fnc_Recordsperpage( ) ) ) ) )
            {
               A1652PreLisCred = H001R2_A1652PreLisCred[0];
               A161CliDsc = H001R2_A161CliDsc[0];
               n161CliDsc = H001R2_n161CliDsc[0];
               A1205LisFech = H001R2_A1205LisFech[0];
               A1651PreLis = H001R2_A1651PreLis[0];
               A45CliCod = H001R2_A45CliCod[0];
               n45CliCod = H001R2_n45CliCod[0];
               A1913TipLProdDsc = H001R2_A1913TipLProdDsc[0];
               A28ProdCod = H001R2_A28ProdCod[0];
               A1912TipLDsc = H001R2_A1912TipLDsc[0];
               A203TipLItem = H001R2_A203TipLItem[0];
               A202TipLCod = H001R2_A202TipLCod[0];
               A1912TipLDsc = H001R2_A1912TipLDsc[0];
               E261R2 ();
               pr_default.readNext(0);
            }
            GRID_nEOF = (short)(((pr_default.getStatus(0) == 101) ? 1 : 0));
            GxWebStd.gx_hidden_field( context, "GRID_nEOF", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRID_nEOF), 1, 0, ".", "")));
            pr_default.close(0);
            wbEnd = 110;
            WB1R0( ) ;
         }
         bGXsfl_110_Refreshing = true;
      }

      protected void send_integrity_lvl_hashes1R2( )
      {
         GxWebStd.gx_hidden_field( context, "vPGMNAME", StringUtil.RTrim( AV67Pgmname));
         GxWebStd.gx_hidden_field( context, "gxhash_vPGMNAME", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( AV67Pgmname, "")), context));
         GxWebStd.gx_hidden_field( context, "gxhash_TIPLCOD"+"_"+sGXsfl_110_idx, GetSecureSignedToken( sGXsfl_110_idx, context.localUtil.Format( (decimal)(A202TipLCod), "ZZZZZ9"), context));
         GxWebStd.gx_hidden_field( context, "gxhash_TIPLITEM"+"_"+sGXsfl_110_idx, GetSecureSignedToken( sGXsfl_110_idx, context.localUtil.Format( (decimal)(A203TipLItem), "ZZZZZ9"), context));
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
         AV68Configuracion_listaprecioswwds_1_dynamicfiltersselector1 = AV15DynamicFiltersSelector1;
         AV69Configuracion_listaprecioswwds_2_dynamicfiltersoperator1 = AV16DynamicFiltersOperator1;
         AV70Configuracion_listaprecioswwds_3_tiplproddsc1 = AV17TipLProdDsc1;
         AV71Configuracion_listaprecioswwds_4_tipldsc1 = AV18TipLDsc1;
         AV72Configuracion_listaprecioswwds_5_dynamicfiltersenabled2 = AV19DynamicFiltersEnabled2;
         AV73Configuracion_listaprecioswwds_6_dynamicfiltersselector2 = AV20DynamicFiltersSelector2;
         AV74Configuracion_listaprecioswwds_7_dynamicfiltersoperator2 = AV21DynamicFiltersOperator2;
         AV75Configuracion_listaprecioswwds_8_tiplproddsc2 = AV22TipLProdDsc2;
         AV76Configuracion_listaprecioswwds_9_tipldsc2 = AV23TipLDsc2;
         AV77Configuracion_listaprecioswwds_10_dynamicfiltersenabled3 = AV24DynamicFiltersEnabled3;
         AV78Configuracion_listaprecioswwds_11_dynamicfiltersselector3 = AV25DynamicFiltersSelector3;
         AV79Configuracion_listaprecioswwds_12_dynamicfiltersoperator3 = AV26DynamicFiltersOperator3;
         AV80Configuracion_listaprecioswwds_13_tiplproddsc3 = AV27TipLProdDsc3;
         AV81Configuracion_listaprecioswwds_14_tipldsc3 = AV28TipLDsc3;
         AV82Configuracion_listaprecioswwds_15_tftipldsc = AV42TFTipLDsc;
         AV83Configuracion_listaprecioswwds_16_tftipldsc_sel = AV43TFTipLDsc_Sel;
         AV84Configuracion_listaprecioswwds_17_tfprodcod = AV38TFProdCod;
         AV85Configuracion_listaprecioswwds_18_tfprodcod_sel = AV39TFProdCod_Sel;
         AV86Configuracion_listaprecioswwds_19_tftiplproddsc = AV40TFTipLProdDsc;
         AV87Configuracion_listaprecioswwds_20_tftiplproddsc_sel = AV41TFTipLProdDsc_Sel;
         AV88Configuracion_listaprecioswwds_21_tfclicod = AV46TFCliCod;
         AV89Configuracion_listaprecioswwds_22_tfclicod_sel = AV47TFCliCod_Sel;
         AV90Configuracion_listaprecioswwds_23_tfprelis = AV44TFPreLis;
         AV91Configuracion_listaprecioswwds_24_tfprelis_to = AV45TFPreLis_To;
         AV92Configuracion_listaprecioswwds_25_tflisfech = AV50TFLisFech;
         AV93Configuracion_listaprecioswwds_26_tflisfech_to = AV51TFLisFech_To;
         pr_default.dynParam(1, new Object[]{ new Object[]{
                                              AV68Configuracion_listaprecioswwds_1_dynamicfiltersselector1 ,
                                              AV69Configuracion_listaprecioswwds_2_dynamicfiltersoperator1 ,
                                              AV70Configuracion_listaprecioswwds_3_tiplproddsc1 ,
                                              AV71Configuracion_listaprecioswwds_4_tipldsc1 ,
                                              AV72Configuracion_listaprecioswwds_5_dynamicfiltersenabled2 ,
                                              AV73Configuracion_listaprecioswwds_6_dynamicfiltersselector2 ,
                                              AV74Configuracion_listaprecioswwds_7_dynamicfiltersoperator2 ,
                                              AV75Configuracion_listaprecioswwds_8_tiplproddsc2 ,
                                              AV76Configuracion_listaprecioswwds_9_tipldsc2 ,
                                              AV77Configuracion_listaprecioswwds_10_dynamicfiltersenabled3 ,
                                              AV78Configuracion_listaprecioswwds_11_dynamicfiltersselector3 ,
                                              AV79Configuracion_listaprecioswwds_12_dynamicfiltersoperator3 ,
                                              AV80Configuracion_listaprecioswwds_13_tiplproddsc3 ,
                                              AV81Configuracion_listaprecioswwds_14_tipldsc3 ,
                                              AV83Configuracion_listaprecioswwds_16_tftipldsc_sel ,
                                              AV82Configuracion_listaprecioswwds_15_tftipldsc ,
                                              AV85Configuracion_listaprecioswwds_18_tfprodcod_sel ,
                                              AV84Configuracion_listaprecioswwds_17_tfprodcod ,
                                              AV87Configuracion_listaprecioswwds_20_tftiplproddsc_sel ,
                                              AV86Configuracion_listaprecioswwds_19_tftiplproddsc ,
                                              AV89Configuracion_listaprecioswwds_22_tfclicod_sel ,
                                              AV88Configuracion_listaprecioswwds_21_tfclicod ,
                                              AV90Configuracion_listaprecioswwds_23_tfprelis ,
                                              AV91Configuracion_listaprecioswwds_24_tfprelis_to ,
                                              AV92Configuracion_listaprecioswwds_25_tflisfech ,
                                              AV93Configuracion_listaprecioswwds_26_tflisfech_to ,
                                              A1913TipLProdDsc ,
                                              A1912TipLDsc ,
                                              A28ProdCod ,
                                              A45CliCod ,
                                              A1651PreLis ,
                                              A1205LisFech ,
                                              AV13OrderedBy ,
                                              AV14OrderedDsc } ,
                                              new int[]{
                                              TypeConstants.SHORT, TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.DECIMAL, TypeConstants.DECIMAL, TypeConstants.DATE, TypeConstants.DATE, TypeConstants.BOOLEAN,
                                              TypeConstants.DECIMAL, TypeConstants.DATE, TypeConstants.SHORT, TypeConstants.BOOLEAN
                                              }
         });
         lV70Configuracion_listaprecioswwds_3_tiplproddsc1 = StringUtil.PadR( StringUtil.RTrim( AV70Configuracion_listaprecioswwds_3_tiplproddsc1), 100, "%");
         lV70Configuracion_listaprecioswwds_3_tiplproddsc1 = StringUtil.PadR( StringUtil.RTrim( AV70Configuracion_listaprecioswwds_3_tiplproddsc1), 100, "%");
         lV71Configuracion_listaprecioswwds_4_tipldsc1 = StringUtil.PadR( StringUtil.RTrim( AV71Configuracion_listaprecioswwds_4_tipldsc1), 100, "%");
         lV71Configuracion_listaprecioswwds_4_tipldsc1 = StringUtil.PadR( StringUtil.RTrim( AV71Configuracion_listaprecioswwds_4_tipldsc1), 100, "%");
         lV75Configuracion_listaprecioswwds_8_tiplproddsc2 = StringUtil.PadR( StringUtil.RTrim( AV75Configuracion_listaprecioswwds_8_tiplproddsc2), 100, "%");
         lV75Configuracion_listaprecioswwds_8_tiplproddsc2 = StringUtil.PadR( StringUtil.RTrim( AV75Configuracion_listaprecioswwds_8_tiplproddsc2), 100, "%");
         lV76Configuracion_listaprecioswwds_9_tipldsc2 = StringUtil.PadR( StringUtil.RTrim( AV76Configuracion_listaprecioswwds_9_tipldsc2), 100, "%");
         lV76Configuracion_listaprecioswwds_9_tipldsc2 = StringUtil.PadR( StringUtil.RTrim( AV76Configuracion_listaprecioswwds_9_tipldsc2), 100, "%");
         lV80Configuracion_listaprecioswwds_13_tiplproddsc3 = StringUtil.PadR( StringUtil.RTrim( AV80Configuracion_listaprecioswwds_13_tiplproddsc3), 100, "%");
         lV80Configuracion_listaprecioswwds_13_tiplproddsc3 = StringUtil.PadR( StringUtil.RTrim( AV80Configuracion_listaprecioswwds_13_tiplproddsc3), 100, "%");
         lV81Configuracion_listaprecioswwds_14_tipldsc3 = StringUtil.PadR( StringUtil.RTrim( AV81Configuracion_listaprecioswwds_14_tipldsc3), 100, "%");
         lV81Configuracion_listaprecioswwds_14_tipldsc3 = StringUtil.PadR( StringUtil.RTrim( AV81Configuracion_listaprecioswwds_14_tipldsc3), 100, "%");
         lV82Configuracion_listaprecioswwds_15_tftipldsc = StringUtil.PadR( StringUtil.RTrim( AV82Configuracion_listaprecioswwds_15_tftipldsc), 100, "%");
         lV84Configuracion_listaprecioswwds_17_tfprodcod = StringUtil.PadR( StringUtil.RTrim( AV84Configuracion_listaprecioswwds_17_tfprodcod), 15, "%");
         lV86Configuracion_listaprecioswwds_19_tftiplproddsc = StringUtil.PadR( StringUtil.RTrim( AV86Configuracion_listaprecioswwds_19_tftiplproddsc), 100, "%");
         lV88Configuracion_listaprecioswwds_21_tfclicod = StringUtil.PadR( StringUtil.RTrim( AV88Configuracion_listaprecioswwds_21_tfclicod), 20, "%");
         /* Using cursor H001R3 */
         pr_default.execute(1, new Object[] {lV70Configuracion_listaprecioswwds_3_tiplproddsc1, lV70Configuracion_listaprecioswwds_3_tiplproddsc1, lV71Configuracion_listaprecioswwds_4_tipldsc1, lV71Configuracion_listaprecioswwds_4_tipldsc1, lV75Configuracion_listaprecioswwds_8_tiplproddsc2, lV75Configuracion_listaprecioswwds_8_tiplproddsc2, lV76Configuracion_listaprecioswwds_9_tipldsc2, lV76Configuracion_listaprecioswwds_9_tipldsc2, lV80Configuracion_listaprecioswwds_13_tiplproddsc3, lV80Configuracion_listaprecioswwds_13_tiplproddsc3, lV81Configuracion_listaprecioswwds_14_tipldsc3, lV81Configuracion_listaprecioswwds_14_tipldsc3, lV82Configuracion_listaprecioswwds_15_tftipldsc, AV83Configuracion_listaprecioswwds_16_tftipldsc_sel, lV84Configuracion_listaprecioswwds_17_tfprodcod, AV85Configuracion_listaprecioswwds_18_tfprodcod_sel, lV86Configuracion_listaprecioswwds_19_tftiplproddsc, AV87Configuracion_listaprecioswwds_20_tftiplproddsc_sel, lV88Configuracion_listaprecioswwds_21_tfclicod, AV89Configuracion_listaprecioswwds_22_tfclicod_sel, AV90Configuracion_listaprecioswwds_23_tfprelis, AV91Configuracion_listaprecioswwds_24_tfprelis_to, AV92Configuracion_listaprecioswwds_25_tflisfech, AV93Configuracion_listaprecioswwds_26_tflisfech_to});
         GRID_nRecordCount = H001R3_AGRID_nRecordCount[0];
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
         AV68Configuracion_listaprecioswwds_1_dynamicfiltersselector1 = AV15DynamicFiltersSelector1;
         AV69Configuracion_listaprecioswwds_2_dynamicfiltersoperator1 = AV16DynamicFiltersOperator1;
         AV70Configuracion_listaprecioswwds_3_tiplproddsc1 = AV17TipLProdDsc1;
         AV71Configuracion_listaprecioswwds_4_tipldsc1 = AV18TipLDsc1;
         AV72Configuracion_listaprecioswwds_5_dynamicfiltersenabled2 = AV19DynamicFiltersEnabled2;
         AV73Configuracion_listaprecioswwds_6_dynamicfiltersselector2 = AV20DynamicFiltersSelector2;
         AV74Configuracion_listaprecioswwds_7_dynamicfiltersoperator2 = AV21DynamicFiltersOperator2;
         AV75Configuracion_listaprecioswwds_8_tiplproddsc2 = AV22TipLProdDsc2;
         AV76Configuracion_listaprecioswwds_9_tipldsc2 = AV23TipLDsc2;
         AV77Configuracion_listaprecioswwds_10_dynamicfiltersenabled3 = AV24DynamicFiltersEnabled3;
         AV78Configuracion_listaprecioswwds_11_dynamicfiltersselector3 = AV25DynamicFiltersSelector3;
         AV79Configuracion_listaprecioswwds_12_dynamicfiltersoperator3 = AV26DynamicFiltersOperator3;
         AV80Configuracion_listaprecioswwds_13_tiplproddsc3 = AV27TipLProdDsc3;
         AV81Configuracion_listaprecioswwds_14_tipldsc3 = AV28TipLDsc3;
         AV82Configuracion_listaprecioswwds_15_tftipldsc = AV42TFTipLDsc;
         AV83Configuracion_listaprecioswwds_16_tftipldsc_sel = AV43TFTipLDsc_Sel;
         AV84Configuracion_listaprecioswwds_17_tfprodcod = AV38TFProdCod;
         AV85Configuracion_listaprecioswwds_18_tfprodcod_sel = AV39TFProdCod_Sel;
         AV86Configuracion_listaprecioswwds_19_tftiplproddsc = AV40TFTipLProdDsc;
         AV87Configuracion_listaprecioswwds_20_tftiplproddsc_sel = AV41TFTipLProdDsc_Sel;
         AV88Configuracion_listaprecioswwds_21_tfclicod = AV46TFCliCod;
         AV89Configuracion_listaprecioswwds_22_tfclicod_sel = AV47TFCliCod_Sel;
         AV90Configuracion_listaprecioswwds_23_tfprelis = AV44TFPreLis;
         AV91Configuracion_listaprecioswwds_24_tfprelis_to = AV45TFPreLis_To;
         AV92Configuracion_listaprecioswwds_25_tflisfech = AV50TFLisFech;
         AV93Configuracion_listaprecioswwds_26_tflisfech_to = AV51TFLisFech_To;
         GRID_nFirstRecordOnPage = 0;
         GxWebStd.gx_hidden_field( context, "GRID_nFirstRecordOnPage", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRID_nFirstRecordOnPage), 15, 0, ".", "")));
         if ( isFullAjaxMode( ) )
         {
            gxgrGrid_refresh( subGrid_Rows, AV15DynamicFiltersSelector1, AV16DynamicFiltersOperator1, AV17TipLProdDsc1, AV18TipLDsc1, AV20DynamicFiltersSelector2, AV21DynamicFiltersOperator2, AV22TipLProdDsc2, AV23TipLDsc2, AV25DynamicFiltersSelector3, AV26DynamicFiltersOperator3, AV27TipLProdDsc3, AV28TipLDsc3, AV19DynamicFiltersEnabled2, AV24DynamicFiltersEnabled3, AV67Pgmname, AV42TFTipLDsc, AV43TFTipLDsc_Sel, AV38TFProdCod, AV39TFProdCod_Sel, AV40TFTipLProdDsc, AV41TFTipLProdDsc_Sel, AV46TFCliCod, AV47TFCliCod_Sel, AV44TFPreLis, AV45TFPreLis_To, AV50TFLisFech, AV51TFLisFech_To, AV13OrderedBy, AV14OrderedDsc, AV10GridState, AV30DynamicFiltersIgnoreFirst, AV29DynamicFiltersRemoving) ;
         }
         send_integrity_footer_hashes( ) ;
         return 0 ;
      }

      protected short subgrid_nextpage( )
      {
         AV68Configuracion_listaprecioswwds_1_dynamicfiltersselector1 = AV15DynamicFiltersSelector1;
         AV69Configuracion_listaprecioswwds_2_dynamicfiltersoperator1 = AV16DynamicFiltersOperator1;
         AV70Configuracion_listaprecioswwds_3_tiplproddsc1 = AV17TipLProdDsc1;
         AV71Configuracion_listaprecioswwds_4_tipldsc1 = AV18TipLDsc1;
         AV72Configuracion_listaprecioswwds_5_dynamicfiltersenabled2 = AV19DynamicFiltersEnabled2;
         AV73Configuracion_listaprecioswwds_6_dynamicfiltersselector2 = AV20DynamicFiltersSelector2;
         AV74Configuracion_listaprecioswwds_7_dynamicfiltersoperator2 = AV21DynamicFiltersOperator2;
         AV75Configuracion_listaprecioswwds_8_tiplproddsc2 = AV22TipLProdDsc2;
         AV76Configuracion_listaprecioswwds_9_tipldsc2 = AV23TipLDsc2;
         AV77Configuracion_listaprecioswwds_10_dynamicfiltersenabled3 = AV24DynamicFiltersEnabled3;
         AV78Configuracion_listaprecioswwds_11_dynamicfiltersselector3 = AV25DynamicFiltersSelector3;
         AV79Configuracion_listaprecioswwds_12_dynamicfiltersoperator3 = AV26DynamicFiltersOperator3;
         AV80Configuracion_listaprecioswwds_13_tiplproddsc3 = AV27TipLProdDsc3;
         AV81Configuracion_listaprecioswwds_14_tipldsc3 = AV28TipLDsc3;
         AV82Configuracion_listaprecioswwds_15_tftipldsc = AV42TFTipLDsc;
         AV83Configuracion_listaprecioswwds_16_tftipldsc_sel = AV43TFTipLDsc_Sel;
         AV84Configuracion_listaprecioswwds_17_tfprodcod = AV38TFProdCod;
         AV85Configuracion_listaprecioswwds_18_tfprodcod_sel = AV39TFProdCod_Sel;
         AV86Configuracion_listaprecioswwds_19_tftiplproddsc = AV40TFTipLProdDsc;
         AV87Configuracion_listaprecioswwds_20_tftiplproddsc_sel = AV41TFTipLProdDsc_Sel;
         AV88Configuracion_listaprecioswwds_21_tfclicod = AV46TFCliCod;
         AV89Configuracion_listaprecioswwds_22_tfclicod_sel = AV47TFCliCod_Sel;
         AV90Configuracion_listaprecioswwds_23_tfprelis = AV44TFPreLis;
         AV91Configuracion_listaprecioswwds_24_tfprelis_to = AV45TFPreLis_To;
         AV92Configuracion_listaprecioswwds_25_tflisfech = AV50TFLisFech;
         AV93Configuracion_listaprecioswwds_26_tflisfech_to = AV51TFLisFech_To;
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
            gxgrGrid_refresh( subGrid_Rows, AV15DynamicFiltersSelector1, AV16DynamicFiltersOperator1, AV17TipLProdDsc1, AV18TipLDsc1, AV20DynamicFiltersSelector2, AV21DynamicFiltersOperator2, AV22TipLProdDsc2, AV23TipLDsc2, AV25DynamicFiltersSelector3, AV26DynamicFiltersOperator3, AV27TipLProdDsc3, AV28TipLDsc3, AV19DynamicFiltersEnabled2, AV24DynamicFiltersEnabled3, AV67Pgmname, AV42TFTipLDsc, AV43TFTipLDsc_Sel, AV38TFProdCod, AV39TFProdCod_Sel, AV40TFTipLProdDsc, AV41TFTipLProdDsc_Sel, AV46TFCliCod, AV47TFCliCod_Sel, AV44TFPreLis, AV45TFPreLis_To, AV50TFLisFech, AV51TFLisFech_To, AV13OrderedBy, AV14OrderedDsc, AV10GridState, AV30DynamicFiltersIgnoreFirst, AV29DynamicFiltersRemoving) ;
         }
         send_integrity_footer_hashes( ) ;
         return (short)(((GRID_nEOF==0) ? 0 : 2)) ;
      }

      protected short subgrid_previouspage( )
      {
         AV68Configuracion_listaprecioswwds_1_dynamicfiltersselector1 = AV15DynamicFiltersSelector1;
         AV69Configuracion_listaprecioswwds_2_dynamicfiltersoperator1 = AV16DynamicFiltersOperator1;
         AV70Configuracion_listaprecioswwds_3_tiplproddsc1 = AV17TipLProdDsc1;
         AV71Configuracion_listaprecioswwds_4_tipldsc1 = AV18TipLDsc1;
         AV72Configuracion_listaprecioswwds_5_dynamicfiltersenabled2 = AV19DynamicFiltersEnabled2;
         AV73Configuracion_listaprecioswwds_6_dynamicfiltersselector2 = AV20DynamicFiltersSelector2;
         AV74Configuracion_listaprecioswwds_7_dynamicfiltersoperator2 = AV21DynamicFiltersOperator2;
         AV75Configuracion_listaprecioswwds_8_tiplproddsc2 = AV22TipLProdDsc2;
         AV76Configuracion_listaprecioswwds_9_tipldsc2 = AV23TipLDsc2;
         AV77Configuracion_listaprecioswwds_10_dynamicfiltersenabled3 = AV24DynamicFiltersEnabled3;
         AV78Configuracion_listaprecioswwds_11_dynamicfiltersselector3 = AV25DynamicFiltersSelector3;
         AV79Configuracion_listaprecioswwds_12_dynamicfiltersoperator3 = AV26DynamicFiltersOperator3;
         AV80Configuracion_listaprecioswwds_13_tiplproddsc3 = AV27TipLProdDsc3;
         AV81Configuracion_listaprecioswwds_14_tipldsc3 = AV28TipLDsc3;
         AV82Configuracion_listaprecioswwds_15_tftipldsc = AV42TFTipLDsc;
         AV83Configuracion_listaprecioswwds_16_tftipldsc_sel = AV43TFTipLDsc_Sel;
         AV84Configuracion_listaprecioswwds_17_tfprodcod = AV38TFProdCod;
         AV85Configuracion_listaprecioswwds_18_tfprodcod_sel = AV39TFProdCod_Sel;
         AV86Configuracion_listaprecioswwds_19_tftiplproddsc = AV40TFTipLProdDsc;
         AV87Configuracion_listaprecioswwds_20_tftiplproddsc_sel = AV41TFTipLProdDsc_Sel;
         AV88Configuracion_listaprecioswwds_21_tfclicod = AV46TFCliCod;
         AV89Configuracion_listaprecioswwds_22_tfclicod_sel = AV47TFCliCod_Sel;
         AV90Configuracion_listaprecioswwds_23_tfprelis = AV44TFPreLis;
         AV91Configuracion_listaprecioswwds_24_tfprelis_to = AV45TFPreLis_To;
         AV92Configuracion_listaprecioswwds_25_tflisfech = AV50TFLisFech;
         AV93Configuracion_listaprecioswwds_26_tflisfech_to = AV51TFLisFech_To;
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
            gxgrGrid_refresh( subGrid_Rows, AV15DynamicFiltersSelector1, AV16DynamicFiltersOperator1, AV17TipLProdDsc1, AV18TipLDsc1, AV20DynamicFiltersSelector2, AV21DynamicFiltersOperator2, AV22TipLProdDsc2, AV23TipLDsc2, AV25DynamicFiltersSelector3, AV26DynamicFiltersOperator3, AV27TipLProdDsc3, AV28TipLDsc3, AV19DynamicFiltersEnabled2, AV24DynamicFiltersEnabled3, AV67Pgmname, AV42TFTipLDsc, AV43TFTipLDsc_Sel, AV38TFProdCod, AV39TFProdCod_Sel, AV40TFTipLProdDsc, AV41TFTipLProdDsc_Sel, AV46TFCliCod, AV47TFCliCod_Sel, AV44TFPreLis, AV45TFPreLis_To, AV50TFLisFech, AV51TFLisFech_To, AV13OrderedBy, AV14OrderedDsc, AV10GridState, AV30DynamicFiltersIgnoreFirst, AV29DynamicFiltersRemoving) ;
         }
         send_integrity_footer_hashes( ) ;
         return 0 ;
      }

      protected short subgrid_lastpage( )
      {
         AV68Configuracion_listaprecioswwds_1_dynamicfiltersselector1 = AV15DynamicFiltersSelector1;
         AV69Configuracion_listaprecioswwds_2_dynamicfiltersoperator1 = AV16DynamicFiltersOperator1;
         AV70Configuracion_listaprecioswwds_3_tiplproddsc1 = AV17TipLProdDsc1;
         AV71Configuracion_listaprecioswwds_4_tipldsc1 = AV18TipLDsc1;
         AV72Configuracion_listaprecioswwds_5_dynamicfiltersenabled2 = AV19DynamicFiltersEnabled2;
         AV73Configuracion_listaprecioswwds_6_dynamicfiltersselector2 = AV20DynamicFiltersSelector2;
         AV74Configuracion_listaprecioswwds_7_dynamicfiltersoperator2 = AV21DynamicFiltersOperator2;
         AV75Configuracion_listaprecioswwds_8_tiplproddsc2 = AV22TipLProdDsc2;
         AV76Configuracion_listaprecioswwds_9_tipldsc2 = AV23TipLDsc2;
         AV77Configuracion_listaprecioswwds_10_dynamicfiltersenabled3 = AV24DynamicFiltersEnabled3;
         AV78Configuracion_listaprecioswwds_11_dynamicfiltersselector3 = AV25DynamicFiltersSelector3;
         AV79Configuracion_listaprecioswwds_12_dynamicfiltersoperator3 = AV26DynamicFiltersOperator3;
         AV80Configuracion_listaprecioswwds_13_tiplproddsc3 = AV27TipLProdDsc3;
         AV81Configuracion_listaprecioswwds_14_tipldsc3 = AV28TipLDsc3;
         AV82Configuracion_listaprecioswwds_15_tftipldsc = AV42TFTipLDsc;
         AV83Configuracion_listaprecioswwds_16_tftipldsc_sel = AV43TFTipLDsc_Sel;
         AV84Configuracion_listaprecioswwds_17_tfprodcod = AV38TFProdCod;
         AV85Configuracion_listaprecioswwds_18_tfprodcod_sel = AV39TFProdCod_Sel;
         AV86Configuracion_listaprecioswwds_19_tftiplproddsc = AV40TFTipLProdDsc;
         AV87Configuracion_listaprecioswwds_20_tftiplproddsc_sel = AV41TFTipLProdDsc_Sel;
         AV88Configuracion_listaprecioswwds_21_tfclicod = AV46TFCliCod;
         AV89Configuracion_listaprecioswwds_22_tfclicod_sel = AV47TFCliCod_Sel;
         AV90Configuracion_listaprecioswwds_23_tfprelis = AV44TFPreLis;
         AV91Configuracion_listaprecioswwds_24_tfprelis_to = AV45TFPreLis_To;
         AV92Configuracion_listaprecioswwds_25_tflisfech = AV50TFLisFech;
         AV93Configuracion_listaprecioswwds_26_tflisfech_to = AV51TFLisFech_To;
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
            gxgrGrid_refresh( subGrid_Rows, AV15DynamicFiltersSelector1, AV16DynamicFiltersOperator1, AV17TipLProdDsc1, AV18TipLDsc1, AV20DynamicFiltersSelector2, AV21DynamicFiltersOperator2, AV22TipLProdDsc2, AV23TipLDsc2, AV25DynamicFiltersSelector3, AV26DynamicFiltersOperator3, AV27TipLProdDsc3, AV28TipLDsc3, AV19DynamicFiltersEnabled2, AV24DynamicFiltersEnabled3, AV67Pgmname, AV42TFTipLDsc, AV43TFTipLDsc_Sel, AV38TFProdCod, AV39TFProdCod_Sel, AV40TFTipLProdDsc, AV41TFTipLProdDsc_Sel, AV46TFCliCod, AV47TFCliCod_Sel, AV44TFPreLis, AV45TFPreLis_To, AV50TFLisFech, AV51TFLisFech_To, AV13OrderedBy, AV14OrderedDsc, AV10GridState, AV30DynamicFiltersIgnoreFirst, AV29DynamicFiltersRemoving) ;
         }
         send_integrity_footer_hashes( ) ;
         return 0 ;
      }

      protected int subgrid_gotopage( int nPageNo )
      {
         AV68Configuracion_listaprecioswwds_1_dynamicfiltersselector1 = AV15DynamicFiltersSelector1;
         AV69Configuracion_listaprecioswwds_2_dynamicfiltersoperator1 = AV16DynamicFiltersOperator1;
         AV70Configuracion_listaprecioswwds_3_tiplproddsc1 = AV17TipLProdDsc1;
         AV71Configuracion_listaprecioswwds_4_tipldsc1 = AV18TipLDsc1;
         AV72Configuracion_listaprecioswwds_5_dynamicfiltersenabled2 = AV19DynamicFiltersEnabled2;
         AV73Configuracion_listaprecioswwds_6_dynamicfiltersselector2 = AV20DynamicFiltersSelector2;
         AV74Configuracion_listaprecioswwds_7_dynamicfiltersoperator2 = AV21DynamicFiltersOperator2;
         AV75Configuracion_listaprecioswwds_8_tiplproddsc2 = AV22TipLProdDsc2;
         AV76Configuracion_listaprecioswwds_9_tipldsc2 = AV23TipLDsc2;
         AV77Configuracion_listaprecioswwds_10_dynamicfiltersenabled3 = AV24DynamicFiltersEnabled3;
         AV78Configuracion_listaprecioswwds_11_dynamicfiltersselector3 = AV25DynamicFiltersSelector3;
         AV79Configuracion_listaprecioswwds_12_dynamicfiltersoperator3 = AV26DynamicFiltersOperator3;
         AV80Configuracion_listaprecioswwds_13_tiplproddsc3 = AV27TipLProdDsc3;
         AV81Configuracion_listaprecioswwds_14_tipldsc3 = AV28TipLDsc3;
         AV82Configuracion_listaprecioswwds_15_tftipldsc = AV42TFTipLDsc;
         AV83Configuracion_listaprecioswwds_16_tftipldsc_sel = AV43TFTipLDsc_Sel;
         AV84Configuracion_listaprecioswwds_17_tfprodcod = AV38TFProdCod;
         AV85Configuracion_listaprecioswwds_18_tfprodcod_sel = AV39TFProdCod_Sel;
         AV86Configuracion_listaprecioswwds_19_tftiplproddsc = AV40TFTipLProdDsc;
         AV87Configuracion_listaprecioswwds_20_tftiplproddsc_sel = AV41TFTipLProdDsc_Sel;
         AV88Configuracion_listaprecioswwds_21_tfclicod = AV46TFCliCod;
         AV89Configuracion_listaprecioswwds_22_tfclicod_sel = AV47TFCliCod_Sel;
         AV90Configuracion_listaprecioswwds_23_tfprelis = AV44TFPreLis;
         AV91Configuracion_listaprecioswwds_24_tfprelis_to = AV45TFPreLis_To;
         AV92Configuracion_listaprecioswwds_25_tflisfech = AV50TFLisFech;
         AV93Configuracion_listaprecioswwds_26_tflisfech_to = AV51TFLisFech_To;
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
            gxgrGrid_refresh( subGrid_Rows, AV15DynamicFiltersSelector1, AV16DynamicFiltersOperator1, AV17TipLProdDsc1, AV18TipLDsc1, AV20DynamicFiltersSelector2, AV21DynamicFiltersOperator2, AV22TipLProdDsc2, AV23TipLDsc2, AV25DynamicFiltersSelector3, AV26DynamicFiltersOperator3, AV27TipLProdDsc3, AV28TipLDsc3, AV19DynamicFiltersEnabled2, AV24DynamicFiltersEnabled3, AV67Pgmname, AV42TFTipLDsc, AV43TFTipLDsc_Sel, AV38TFProdCod, AV39TFProdCod_Sel, AV40TFTipLProdDsc, AV41TFTipLProdDsc_Sel, AV46TFCliCod, AV47TFCliCod_Sel, AV44TFPreLis, AV45TFPreLis_To, AV50TFLisFech, AV51TFLisFech_To, AV13OrderedBy, AV14OrderedDsc, AV10GridState, AV30DynamicFiltersIgnoreFirst, AV29DynamicFiltersRemoving) ;
         }
         send_integrity_footer_hashes( ) ;
         return (int)(0) ;
      }

      protected void before_start_formulas( )
      {
         AV67Pgmname = "Configuracion.ListaPreciosWW";
         context.Gx_err = 0;
         fix_multi_value_controls( ) ;
      }

      protected void STRUP1R0( )
      {
         /* Before Start, stand alone formulas. */
         before_start_formulas( ) ;
         /* Execute Start event if defined. */
         context.wbGlbDoneStart = 0;
         /* Execute user event: Start */
         E241R2 ();
         context.wbGlbDoneStart = 1;
         /* After Start, stand alone formulas. */
         if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
         {
            /* Read saved SDTs. */
            ajax_req_read_hidden_sdt(cgiGet( "vAGEXPORTDATA"), AV63AGExportData);
            ajax_req_read_hidden_sdt(cgiGet( "vDDO_TITLESETTINGSICONS"), AV57DDO_TitleSettingsIcons);
            /* Read saved values. */
            nRC_GXsfl_110 = (int)(context.localUtil.CToN( cgiGet( "nRC_GXsfl_110"), ".", ","));
            AV59GridCurrentPage = (long)(context.localUtil.CToN( cgiGet( "vGRIDCURRENTPAGE"), ".", ","));
            AV60GridPageCount = (long)(context.localUtil.CToN( cgiGet( "vGRIDPAGECOUNT"), ".", ","));
            AV61GridAppliedFilters = cgiGet( "vGRIDAPPLIEDFILTERS");
            AV52DDO_LisFechAuxDate = context.localUtil.CToD( cgiGet( "vDDO_LISFECHAUXDATE"), 0);
            AV53DDO_LisFechAuxDateTo = context.localUtil.CToD( cgiGet( "vDDO_LISFECHAUXDATETO"), 0);
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
            cmbavDynamicfiltersoperator1.Name = cmbavDynamicfiltersoperator1_Internalname;
            cmbavDynamicfiltersoperator1.CurrentValue = cgiGet( cmbavDynamicfiltersoperator1_Internalname);
            AV16DynamicFiltersOperator1 = (short)(NumberUtil.Val( cgiGet( cmbavDynamicfiltersoperator1_Internalname), "."));
            AssignAttri("", false, "AV16DynamicFiltersOperator1", StringUtil.LTrimStr( (decimal)(AV16DynamicFiltersOperator1), 4, 0));
            AV17TipLProdDsc1 = cgiGet( edtavTiplproddsc1_Internalname);
            AssignAttri("", false, "AV17TipLProdDsc1", AV17TipLProdDsc1);
            AV18TipLDsc1 = cgiGet( edtavTipldsc1_Internalname);
            AssignAttri("", false, "AV18TipLDsc1", AV18TipLDsc1);
            cmbavDynamicfiltersselector2.Name = cmbavDynamicfiltersselector2_Internalname;
            cmbavDynamicfiltersselector2.CurrentValue = cgiGet( cmbavDynamicfiltersselector2_Internalname);
            AV20DynamicFiltersSelector2 = cgiGet( cmbavDynamicfiltersselector2_Internalname);
            AssignAttri("", false, "AV20DynamicFiltersSelector2", AV20DynamicFiltersSelector2);
            cmbavDynamicfiltersoperator2.Name = cmbavDynamicfiltersoperator2_Internalname;
            cmbavDynamicfiltersoperator2.CurrentValue = cgiGet( cmbavDynamicfiltersoperator2_Internalname);
            AV21DynamicFiltersOperator2 = (short)(NumberUtil.Val( cgiGet( cmbavDynamicfiltersoperator2_Internalname), "."));
            AssignAttri("", false, "AV21DynamicFiltersOperator2", StringUtil.LTrimStr( (decimal)(AV21DynamicFiltersOperator2), 4, 0));
            AV22TipLProdDsc2 = cgiGet( edtavTiplproddsc2_Internalname);
            AssignAttri("", false, "AV22TipLProdDsc2", AV22TipLProdDsc2);
            AV23TipLDsc2 = cgiGet( edtavTipldsc2_Internalname);
            AssignAttri("", false, "AV23TipLDsc2", AV23TipLDsc2);
            cmbavDynamicfiltersselector3.Name = cmbavDynamicfiltersselector3_Internalname;
            cmbavDynamicfiltersselector3.CurrentValue = cgiGet( cmbavDynamicfiltersselector3_Internalname);
            AV25DynamicFiltersSelector3 = cgiGet( cmbavDynamicfiltersselector3_Internalname);
            AssignAttri("", false, "AV25DynamicFiltersSelector3", AV25DynamicFiltersSelector3);
            cmbavDynamicfiltersoperator3.Name = cmbavDynamicfiltersoperator3_Internalname;
            cmbavDynamicfiltersoperator3.CurrentValue = cgiGet( cmbavDynamicfiltersoperator3_Internalname);
            AV26DynamicFiltersOperator3 = (short)(NumberUtil.Val( cgiGet( cmbavDynamicfiltersoperator3_Internalname), "."));
            AssignAttri("", false, "AV26DynamicFiltersOperator3", StringUtil.LTrimStr( (decimal)(AV26DynamicFiltersOperator3), 4, 0));
            AV27TipLProdDsc3 = cgiGet( edtavTiplproddsc3_Internalname);
            AssignAttri("", false, "AV27TipLProdDsc3", AV27TipLProdDsc3);
            AV28TipLDsc3 = cgiGet( edtavTipldsc3_Internalname);
            AssignAttri("", false, "AV28TipLDsc3", AV28TipLDsc3);
            AV54DDO_LisFechAuxDateText = cgiGet( edtavDdo_lisfechauxdatetext_Internalname);
            AssignAttri("", false, "AV54DDO_LisFechAuxDateText", AV54DDO_LisFechAuxDateText);
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
            if ( StringUtil.StrCmp(cgiGet( "GXH_vTIPLPRODDSC1"), AV17TipLProdDsc1) != 0 )
            {
               GRID_nFirstRecordOnPage = 0;
            }
            if ( StringUtil.StrCmp(cgiGet( "GXH_vTIPLDSC1"), AV18TipLDsc1) != 0 )
            {
               GRID_nFirstRecordOnPage = 0;
            }
            if ( StringUtil.StrCmp(cgiGet( "GXH_vDYNAMICFILTERSSELECTOR2"), AV20DynamicFiltersSelector2) != 0 )
            {
               GRID_nFirstRecordOnPage = 0;
            }
            if ( ( context.localUtil.CToN( cgiGet( "GXH_vDYNAMICFILTERSOPERATOR2"), ".", ",") != Convert.ToDecimal( AV21DynamicFiltersOperator2 )) )
            {
               GRID_nFirstRecordOnPage = 0;
            }
            if ( StringUtil.StrCmp(cgiGet( "GXH_vTIPLPRODDSC2"), AV22TipLProdDsc2) != 0 )
            {
               GRID_nFirstRecordOnPage = 0;
            }
            if ( StringUtil.StrCmp(cgiGet( "GXH_vTIPLDSC2"), AV23TipLDsc2) != 0 )
            {
               GRID_nFirstRecordOnPage = 0;
            }
            if ( StringUtil.StrCmp(cgiGet( "GXH_vDYNAMICFILTERSSELECTOR3"), AV25DynamicFiltersSelector3) != 0 )
            {
               GRID_nFirstRecordOnPage = 0;
            }
            if ( ( context.localUtil.CToN( cgiGet( "GXH_vDYNAMICFILTERSOPERATOR3"), ".", ",") != Convert.ToDecimal( AV26DynamicFiltersOperator3 )) )
            {
               GRID_nFirstRecordOnPage = 0;
            }
            if ( StringUtil.StrCmp(cgiGet( "GXH_vTIPLPRODDSC3"), AV27TipLProdDsc3) != 0 )
            {
               GRID_nFirstRecordOnPage = 0;
            }
            if ( StringUtil.StrCmp(cgiGet( "GXH_vTIPLDSC3"), AV28TipLDsc3) != 0 )
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
         E241R2 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
      }

      protected void E241R2( )
      {
         /* Start Routine */
         returnInSub = false;
         this.executeUsercontrolMethod("", false, "TFLISFECH_RANGEPICKERContainer", "Attach", "", new Object[] {(string)edtavDdo_lisfechauxdatetext_Internalname});
         subGrid_Rows = 10;
         GxWebStd.gx_hidden_field( context, "GRID_Rows", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid_Rows), 6, 0, ".", "")));
         Grid_empowerer_Gridinternalname = subGrid_Internalname;
         ucGrid_empowerer.SendProperty(context, "", false, Grid_empowerer_Internalname, "GridInternalName", Grid_empowerer_Gridinternalname);
         lblJsdynamicfilters_Caption = "";
         AssignProp("", false, lblJsdynamicfilters_Internalname, "Caption", lblJsdynamicfilters_Caption, true);
         AV15DynamicFiltersSelector1 = "TIPLPRODDSC";
         AssignAttri("", false, "AV15DynamicFiltersSelector1", AV15DynamicFiltersSelector1);
         /* Execute user subroutine: 'ENABLEDYNAMICFILTERS1' */
         S112 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
         AV20DynamicFiltersSelector2 = "TIPLPRODDSC";
         AssignAttri("", false, "AV20DynamicFiltersSelector2", AV20DynamicFiltersSelector2);
         /* Execute user subroutine: 'ENABLEDYNAMICFILTERS2' */
         S122 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
         AV25DynamicFiltersSelector3 = "TIPLPRODDSC";
         AssignAttri("", false, "AV25DynamicFiltersSelector3", AV25DynamicFiltersSelector3);
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
         AV63AGExportData = new GXBaseCollection<GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTDropDownOptionsData_Item>( context, "Item", "");
         AV64AGExportDataItem = new GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTDropDownOptionsData_Item(context);
         AV64AGExportDataItem.gxTpr_Title = "PDF";
         AV64AGExportDataItem.gxTpr_Icon = context.convertURL( (string)(context.GetImagePath( "776fb79c-a0a1-4302-b5e5-d773dbe1a297", "", context.GetTheme( ))));
         AV64AGExportDataItem.gxTpr_Eventkey = "ExportReport";
         AV64AGExportDataItem.gxTpr_Isdivider = false;
         AV63AGExportData.Add(AV64AGExportDataItem, 0);
         AV64AGExportDataItem = new GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTDropDownOptionsData_Item(context);
         AV64AGExportDataItem.gxTpr_Title = "Excel";
         AV64AGExportDataItem.gxTpr_Icon = context.convertURL( (string)(context.GetImagePath( "da69a816-fd11-445b-8aaf-1a2f7f1acc93", "", context.GetTheme( ))));
         AV64AGExportDataItem.gxTpr_Eventkey = "Export";
         AV64AGExportDataItem.gxTpr_Isdivider = false;
         AV63AGExportData.Add(AV64AGExportDataItem, 0);
         Ddo_grid_Gridinternalname = subGrid_Internalname;
         ucDdo_grid.SendProperty(context, "", false, Ddo_grid_Internalname, "GridInternalName", Ddo_grid_Gridinternalname);
         Form.Caption = " Lista de Precios";
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
         GXt_SdtDVB_SDTDropDownOptionsTitleSettingsIcons1 = AV57DDO_TitleSettingsIcons;
         new GeneXus.Programs.wwpbaseobjects.getwwptitlesettingsicons(context ).execute( out  GXt_SdtDVB_SDTDropDownOptionsTitleSettingsIcons1) ;
         AV57DDO_TitleSettingsIcons = GXt_SdtDVB_SDTDropDownOptionsTitleSettingsIcons1;
         Gridpaginationbar_Rowsperpageselectedvalue = subGrid_Rows;
         ucGridpaginationbar.SendProperty(context, "", false, Gridpaginationbar_Internalname, "RowsPerPageSelectedValue", StringUtil.LTrimStr( (decimal)(Gridpaginationbar_Rowsperpageselectedvalue), 9, 0));
      }

      protected void E251R2( )
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
         if ( StringUtil.StrCmp(AV15DynamicFiltersSelector1, "TIPLPRODDSC") == 0 )
         {
            cmbavDynamicfiltersoperator1.addItem("0", "Comienza con", 0);
            cmbavDynamicfiltersoperator1.addItem("1", "Contiene", 0);
         }
         else if ( StringUtil.StrCmp(AV15DynamicFiltersSelector1, "TIPLDSC") == 0 )
         {
            cmbavDynamicfiltersoperator1.addItem("0", "Comienza con", 0);
            cmbavDynamicfiltersoperator1.addItem("1", "Contiene", 0);
         }
         if ( AV19DynamicFiltersEnabled2 )
         {
            cmbavDynamicfiltersoperator2.removeAllItems();
            if ( StringUtil.StrCmp(AV20DynamicFiltersSelector2, "TIPLPRODDSC") == 0 )
            {
               cmbavDynamicfiltersoperator2.addItem("0", "Comienza con", 0);
               cmbavDynamicfiltersoperator2.addItem("1", "Contiene", 0);
            }
            else if ( StringUtil.StrCmp(AV20DynamicFiltersSelector2, "TIPLDSC") == 0 )
            {
               cmbavDynamicfiltersoperator2.addItem("0", "Comienza con", 0);
               cmbavDynamicfiltersoperator2.addItem("1", "Contiene", 0);
            }
            if ( AV24DynamicFiltersEnabled3 )
            {
               cmbavDynamicfiltersoperator3.removeAllItems();
               if ( StringUtil.StrCmp(AV25DynamicFiltersSelector3, "TIPLPRODDSC") == 0 )
               {
                  cmbavDynamicfiltersoperator3.addItem("0", "Comienza con", 0);
                  cmbavDynamicfiltersoperator3.addItem("1", "Contiene", 0);
               }
               else if ( StringUtil.StrCmp(AV25DynamicFiltersSelector3, "TIPLDSC") == 0 )
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
         AV59GridCurrentPage = subGrid_fnc_Currentpage( );
         AssignAttri("", false, "AV59GridCurrentPage", StringUtil.LTrimStr( (decimal)(AV59GridCurrentPage), 10, 0));
         AV60GridPageCount = subGrid_fnc_Pagecount( );
         AssignAttri("", false, "AV60GridPageCount", StringUtil.LTrimStr( (decimal)(AV60GridPageCount), 10, 0));
         GXt_char2 = AV61GridAppliedFilters;
         new GeneXus.Programs.wwpbaseobjects.wwp_getappliedfiltersdescription(context ).execute(  AV67Pgmname, out  GXt_char2) ;
         AV61GridAppliedFilters = GXt_char2;
         AssignAttri("", false, "AV61GridAppliedFilters", AV61GridAppliedFilters);
         AV68Configuracion_listaprecioswwds_1_dynamicfiltersselector1 = AV15DynamicFiltersSelector1;
         AV69Configuracion_listaprecioswwds_2_dynamicfiltersoperator1 = AV16DynamicFiltersOperator1;
         AV70Configuracion_listaprecioswwds_3_tiplproddsc1 = AV17TipLProdDsc1;
         AV71Configuracion_listaprecioswwds_4_tipldsc1 = AV18TipLDsc1;
         AV72Configuracion_listaprecioswwds_5_dynamicfiltersenabled2 = AV19DynamicFiltersEnabled2;
         AV73Configuracion_listaprecioswwds_6_dynamicfiltersselector2 = AV20DynamicFiltersSelector2;
         AV74Configuracion_listaprecioswwds_7_dynamicfiltersoperator2 = AV21DynamicFiltersOperator2;
         AV75Configuracion_listaprecioswwds_8_tiplproddsc2 = AV22TipLProdDsc2;
         AV76Configuracion_listaprecioswwds_9_tipldsc2 = AV23TipLDsc2;
         AV77Configuracion_listaprecioswwds_10_dynamicfiltersenabled3 = AV24DynamicFiltersEnabled3;
         AV78Configuracion_listaprecioswwds_11_dynamicfiltersselector3 = AV25DynamicFiltersSelector3;
         AV79Configuracion_listaprecioswwds_12_dynamicfiltersoperator3 = AV26DynamicFiltersOperator3;
         AV80Configuracion_listaprecioswwds_13_tiplproddsc3 = AV27TipLProdDsc3;
         AV81Configuracion_listaprecioswwds_14_tipldsc3 = AV28TipLDsc3;
         AV82Configuracion_listaprecioswwds_15_tftipldsc = AV42TFTipLDsc;
         AV83Configuracion_listaprecioswwds_16_tftipldsc_sel = AV43TFTipLDsc_Sel;
         AV84Configuracion_listaprecioswwds_17_tfprodcod = AV38TFProdCod;
         AV85Configuracion_listaprecioswwds_18_tfprodcod_sel = AV39TFProdCod_Sel;
         AV86Configuracion_listaprecioswwds_19_tftiplproddsc = AV40TFTipLProdDsc;
         AV87Configuracion_listaprecioswwds_20_tftiplproddsc_sel = AV41TFTipLProdDsc_Sel;
         AV88Configuracion_listaprecioswwds_21_tfclicod = AV46TFCliCod;
         AV89Configuracion_listaprecioswwds_22_tfclicod_sel = AV47TFCliCod_Sel;
         AV90Configuracion_listaprecioswwds_23_tfprelis = AV44TFPreLis;
         AV91Configuracion_listaprecioswwds_24_tfprelis_to = AV45TFPreLis_To;
         AV92Configuracion_listaprecioswwds_25_tflisfech = AV50TFLisFech;
         AV93Configuracion_listaprecioswwds_26_tflisfech_to = AV51TFLisFech_To;
         /*  Sending Event outputs  */
         cmbavDynamicfiltersoperator1.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV16DynamicFiltersOperator1), 4, 0));
         AssignProp("", false, cmbavDynamicfiltersoperator1_Internalname, "Values", cmbavDynamicfiltersoperator1.ToJavascriptSource(), true);
         cmbavDynamicfiltersoperator2.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV21DynamicFiltersOperator2), 4, 0));
         AssignProp("", false, cmbavDynamicfiltersoperator2_Internalname, "Values", cmbavDynamicfiltersoperator2.ToJavascriptSource(), true);
         cmbavDynamicfiltersoperator3.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV26DynamicFiltersOperator3), 4, 0));
         AssignProp("", false, cmbavDynamicfiltersoperator3_Internalname, "Values", cmbavDynamicfiltersoperator3.ToJavascriptSource(), true);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV10GridState", AV10GridState);
      }

      protected void E111R2( )
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
            AV58PageToGo = (int)(NumberUtil.Val( Gridpaginationbar_Selectedpage, "."));
            subgrid_gotopage( AV58PageToGo) ;
         }
      }

      protected void E121R2( )
      {
         /* Gridpaginationbar_Changerowsperpage Routine */
         returnInSub = false;
         subGrid_Rows = Gridpaginationbar_Rowsperpageselectedvalue;
         GxWebStd.gx_hidden_field( context, "GRID_Rows", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid_Rows), 6, 0, ".", "")));
         subgrid_firstpage( ) ;
         /*  Sending Event outputs  */
      }

      protected void E141R2( )
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
            if ( StringUtil.StrCmp(Ddo_grid_Selectedcolumn, "TipLDsc") == 0 )
            {
               AV42TFTipLDsc = Ddo_grid_Filteredtext_get;
               AssignAttri("", false, "AV42TFTipLDsc", AV42TFTipLDsc);
               AV43TFTipLDsc_Sel = Ddo_grid_Selectedvalue_get;
               AssignAttri("", false, "AV43TFTipLDsc_Sel", AV43TFTipLDsc_Sel);
            }
            else if ( StringUtil.StrCmp(Ddo_grid_Selectedcolumn, "ProdCod") == 0 )
            {
               AV38TFProdCod = Ddo_grid_Filteredtext_get;
               AssignAttri("", false, "AV38TFProdCod", AV38TFProdCod);
               AV39TFProdCod_Sel = Ddo_grid_Selectedvalue_get;
               AssignAttri("", false, "AV39TFProdCod_Sel", AV39TFProdCod_Sel);
            }
            else if ( StringUtil.StrCmp(Ddo_grid_Selectedcolumn, "TipLProdDsc") == 0 )
            {
               AV40TFTipLProdDsc = Ddo_grid_Filteredtext_get;
               AssignAttri("", false, "AV40TFTipLProdDsc", AV40TFTipLProdDsc);
               AV41TFTipLProdDsc_Sel = Ddo_grid_Selectedvalue_get;
               AssignAttri("", false, "AV41TFTipLProdDsc_Sel", AV41TFTipLProdDsc_Sel);
            }
            else if ( StringUtil.StrCmp(Ddo_grid_Selectedcolumn, "CliCod") == 0 )
            {
               AV46TFCliCod = Ddo_grid_Filteredtext_get;
               AssignAttri("", false, "AV46TFCliCod", AV46TFCliCod);
               AV47TFCliCod_Sel = Ddo_grid_Selectedvalue_get;
               AssignAttri("", false, "AV47TFCliCod_Sel", AV47TFCliCod_Sel);
            }
            else if ( StringUtil.StrCmp(Ddo_grid_Selectedcolumn, "PreLis") == 0 )
            {
               AV44TFPreLis = NumberUtil.Val( Ddo_grid_Filteredtext_get, ".");
               AssignAttri("", false, "AV44TFPreLis", StringUtil.LTrimStr( AV44TFPreLis, 15, 4));
               AV45TFPreLis_To = NumberUtil.Val( Ddo_grid_Filteredtextto_get, ".");
               AssignAttri("", false, "AV45TFPreLis_To", StringUtil.LTrimStr( AV45TFPreLis_To, 15, 4));
            }
            else if ( StringUtil.StrCmp(Ddo_grid_Selectedcolumn, "LisFech") == 0 )
            {
               AV50TFLisFech = context.localUtil.CToD( Ddo_grid_Filteredtext_get, 2);
               AssignAttri("", false, "AV50TFLisFech", context.localUtil.Format(AV50TFLisFech, "99/99/99"));
               AV51TFLisFech_To = context.localUtil.CToD( Ddo_grid_Filteredtextto_get, 2);
               AssignAttri("", false, "AV51TFLisFech_To", context.localUtil.Format(AV51TFLisFech_To, "99/99/99"));
            }
            subgrid_firstpage( ) ;
         }
         /*  Sending Event outputs  */
      }

      private void E261R2( )
      {
         /* Grid_Load Routine */
         returnInSub = false;
         cmbavGridactions.removeAllItems();
         cmbavGridactions.addItem("0", ";fa fa-bars", 0);
         cmbavGridactions.addItem("1", StringUtil.Format( "%1;%2", "Modificar", "fa fa-pen", "", "", "", "", "", "", ""), 0);
         cmbavGridactions.addItem("2", StringUtil.Format( "%1;%2", "Eliminar", "fa fa-times", "", "", "", "", "", "", ""), 0);
         GXKey = Crypto.GetSiteKey( );
         GXEncryptionTmp = "configuracion.tipolistaprecio.aspx"+UrlEncode(StringUtil.RTrim("DSP")) + "," + UrlEncode(StringUtil.LTrimStr(A202TipLCod,6,0));
         edtTipLDsc_Link = formatLink("configuracion.tipolistaprecio.aspx") + "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey);
         GXKey = Crypto.GetSiteKey( );
         GXEncryptionTmp = "configuracion.listaprecios.aspx"+UrlEncode(StringUtil.RTrim("DSP")) + "," + UrlEncode(StringUtil.LTrimStr(A202TipLCod,6,0)) + "," + UrlEncode(StringUtil.LTrimStr(A203TipLItem,6,0));
         edtTipLProdDsc_Link = formatLink("configuracion.listaprecios.aspx") + "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey);
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
         cmbavGridactions.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV62GridActions), 4, 0));
      }

      protected void E191R2( )
      {
         /* 'AddDynamicFilters1' Routine */
         returnInSub = false;
         AV19DynamicFiltersEnabled2 = true;
         AssignAttri("", false, "AV19DynamicFiltersEnabled2", AV19DynamicFiltersEnabled2);
         imgAdddynamicfilters1_Visible = 0;
         AssignProp("", false, imgAdddynamicfilters1_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(imgAdddynamicfilters1_Visible), 5, 0), true);
         imgRemovedynamicfilters1_Visible = 1;
         AssignProp("", false, imgRemovedynamicfilters1_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(imgRemovedynamicfilters1_Visible), 5, 0), true);
         gxgrGrid_refresh( subGrid_Rows, AV15DynamicFiltersSelector1, AV16DynamicFiltersOperator1, AV17TipLProdDsc1, AV18TipLDsc1, AV20DynamicFiltersSelector2, AV21DynamicFiltersOperator2, AV22TipLProdDsc2, AV23TipLDsc2, AV25DynamicFiltersSelector3, AV26DynamicFiltersOperator3, AV27TipLProdDsc3, AV28TipLDsc3, AV19DynamicFiltersEnabled2, AV24DynamicFiltersEnabled3, AV67Pgmname, AV42TFTipLDsc, AV43TFTipLDsc_Sel, AV38TFProdCod, AV39TFProdCod_Sel, AV40TFTipLProdDsc, AV41TFTipLProdDsc_Sel, AV46TFCliCod, AV47TFCliCod_Sel, AV44TFPreLis, AV45TFPreLis_To, AV50TFLisFech, AV51TFLisFech_To, AV13OrderedBy, AV14OrderedDsc, AV10GridState, AV30DynamicFiltersIgnoreFirst, AV29DynamicFiltersRemoving) ;
         /*  Sending Event outputs  */
         cmbavDynamicfiltersoperator1.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV16DynamicFiltersOperator1), 4, 0));
         AssignProp("", false, cmbavDynamicfiltersoperator1_Internalname, "Values", cmbavDynamicfiltersoperator1.ToJavascriptSource(), true);
         cmbavDynamicfiltersoperator2.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV21DynamicFiltersOperator2), 4, 0));
         AssignProp("", false, cmbavDynamicfiltersoperator2_Internalname, "Values", cmbavDynamicfiltersoperator2.ToJavascriptSource(), true);
         cmbavDynamicfiltersoperator3.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV26DynamicFiltersOperator3), 4, 0));
         AssignProp("", false, cmbavDynamicfiltersoperator3_Internalname, "Values", cmbavDynamicfiltersoperator3.ToJavascriptSource(), true);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV10GridState", AV10GridState);
      }

      protected void E151R2( )
      {
         /* 'RemoveDynamicFilters1' Routine */
         returnInSub = false;
         AV29DynamicFiltersRemoving = true;
         AssignAttri("", false, "AV29DynamicFiltersRemoving", AV29DynamicFiltersRemoving);
         AV30DynamicFiltersIgnoreFirst = true;
         AssignAttri("", false, "AV30DynamicFiltersIgnoreFirst", AV30DynamicFiltersIgnoreFirst);
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
         AV29DynamicFiltersRemoving = false;
         AssignAttri("", false, "AV29DynamicFiltersRemoving", AV29DynamicFiltersRemoving);
         AV30DynamicFiltersIgnoreFirst = false;
         AssignAttri("", false, "AV30DynamicFiltersIgnoreFirst", AV30DynamicFiltersIgnoreFirst);
         gxgrGrid_refresh( subGrid_Rows, AV15DynamicFiltersSelector1, AV16DynamicFiltersOperator1, AV17TipLProdDsc1, AV18TipLDsc1, AV20DynamicFiltersSelector2, AV21DynamicFiltersOperator2, AV22TipLProdDsc2, AV23TipLDsc2, AV25DynamicFiltersSelector3, AV26DynamicFiltersOperator3, AV27TipLProdDsc3, AV28TipLDsc3, AV19DynamicFiltersEnabled2, AV24DynamicFiltersEnabled3, AV67Pgmname, AV42TFTipLDsc, AV43TFTipLDsc_Sel, AV38TFProdCod, AV39TFProdCod_Sel, AV40TFTipLProdDsc, AV41TFTipLProdDsc_Sel, AV46TFCliCod, AV47TFCliCod_Sel, AV44TFPreLis, AV45TFPreLis_To, AV50TFLisFech, AV51TFLisFech_To, AV13OrderedBy, AV14OrderedDsc, AV10GridState, AV30DynamicFiltersIgnoreFirst, AV29DynamicFiltersRemoving) ;
         /*  Sending Event outputs  */
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV10GridState", AV10GridState);
         cmbavDynamicfiltersselector2.CurrentValue = StringUtil.RTrim( AV20DynamicFiltersSelector2);
         AssignProp("", false, cmbavDynamicfiltersselector2_Internalname, "Values", cmbavDynamicfiltersselector2.ToJavascriptSource(), true);
         cmbavDynamicfiltersoperator2.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV21DynamicFiltersOperator2), 4, 0));
         AssignProp("", false, cmbavDynamicfiltersoperator2_Internalname, "Values", cmbavDynamicfiltersoperator2.ToJavascriptSource(), true);
         cmbavDynamicfiltersselector3.CurrentValue = StringUtil.RTrim( AV25DynamicFiltersSelector3);
         AssignProp("", false, cmbavDynamicfiltersselector3_Internalname, "Values", cmbavDynamicfiltersselector3.ToJavascriptSource(), true);
         cmbavDynamicfiltersoperator3.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV26DynamicFiltersOperator3), 4, 0));
         AssignProp("", false, cmbavDynamicfiltersoperator3_Internalname, "Values", cmbavDynamicfiltersoperator3.ToJavascriptSource(), true);
         cmbavDynamicfiltersselector1.CurrentValue = StringUtil.RTrim( AV15DynamicFiltersSelector1);
         AssignProp("", false, cmbavDynamicfiltersselector1_Internalname, "Values", cmbavDynamicfiltersselector1.ToJavascriptSource(), true);
         cmbavDynamicfiltersoperator1.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV16DynamicFiltersOperator1), 4, 0));
         AssignProp("", false, cmbavDynamicfiltersoperator1_Internalname, "Values", cmbavDynamicfiltersoperator1.ToJavascriptSource(), true);
      }

      protected void E201R2( )
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

      protected void E211R2( )
      {
         /* 'AddDynamicFilters2' Routine */
         returnInSub = false;
         AV24DynamicFiltersEnabled3 = true;
         AssignAttri("", false, "AV24DynamicFiltersEnabled3", AV24DynamicFiltersEnabled3);
         imgAdddynamicfilters2_Visible = 0;
         AssignProp("", false, imgAdddynamicfilters2_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(imgAdddynamicfilters2_Visible), 5, 0), true);
         imgRemovedynamicfilters2_Visible = 1;
         AssignProp("", false, imgRemovedynamicfilters2_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(imgRemovedynamicfilters2_Visible), 5, 0), true);
         gxgrGrid_refresh( subGrid_Rows, AV15DynamicFiltersSelector1, AV16DynamicFiltersOperator1, AV17TipLProdDsc1, AV18TipLDsc1, AV20DynamicFiltersSelector2, AV21DynamicFiltersOperator2, AV22TipLProdDsc2, AV23TipLDsc2, AV25DynamicFiltersSelector3, AV26DynamicFiltersOperator3, AV27TipLProdDsc3, AV28TipLDsc3, AV19DynamicFiltersEnabled2, AV24DynamicFiltersEnabled3, AV67Pgmname, AV42TFTipLDsc, AV43TFTipLDsc_Sel, AV38TFProdCod, AV39TFProdCod_Sel, AV40TFTipLProdDsc, AV41TFTipLProdDsc_Sel, AV46TFCliCod, AV47TFCliCod_Sel, AV44TFPreLis, AV45TFPreLis_To, AV50TFLisFech, AV51TFLisFech_To, AV13OrderedBy, AV14OrderedDsc, AV10GridState, AV30DynamicFiltersIgnoreFirst, AV29DynamicFiltersRemoving) ;
         /*  Sending Event outputs  */
         cmbavDynamicfiltersoperator1.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV16DynamicFiltersOperator1), 4, 0));
         AssignProp("", false, cmbavDynamicfiltersoperator1_Internalname, "Values", cmbavDynamicfiltersoperator1.ToJavascriptSource(), true);
         cmbavDynamicfiltersoperator2.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV21DynamicFiltersOperator2), 4, 0));
         AssignProp("", false, cmbavDynamicfiltersoperator2_Internalname, "Values", cmbavDynamicfiltersoperator2.ToJavascriptSource(), true);
         cmbavDynamicfiltersoperator3.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV26DynamicFiltersOperator3), 4, 0));
         AssignProp("", false, cmbavDynamicfiltersoperator3_Internalname, "Values", cmbavDynamicfiltersoperator3.ToJavascriptSource(), true);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV10GridState", AV10GridState);
      }

      protected void E161R2( )
      {
         /* 'RemoveDynamicFilters2' Routine */
         returnInSub = false;
         AV29DynamicFiltersRemoving = true;
         AssignAttri("", false, "AV29DynamicFiltersRemoving", AV29DynamicFiltersRemoving);
         AV19DynamicFiltersEnabled2 = false;
         AssignAttri("", false, "AV19DynamicFiltersEnabled2", AV19DynamicFiltersEnabled2);
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
         AV29DynamicFiltersRemoving = false;
         AssignAttri("", false, "AV29DynamicFiltersRemoving", AV29DynamicFiltersRemoving);
         gxgrGrid_refresh( subGrid_Rows, AV15DynamicFiltersSelector1, AV16DynamicFiltersOperator1, AV17TipLProdDsc1, AV18TipLDsc1, AV20DynamicFiltersSelector2, AV21DynamicFiltersOperator2, AV22TipLProdDsc2, AV23TipLDsc2, AV25DynamicFiltersSelector3, AV26DynamicFiltersOperator3, AV27TipLProdDsc3, AV28TipLDsc3, AV19DynamicFiltersEnabled2, AV24DynamicFiltersEnabled3, AV67Pgmname, AV42TFTipLDsc, AV43TFTipLDsc_Sel, AV38TFProdCod, AV39TFProdCod_Sel, AV40TFTipLProdDsc, AV41TFTipLProdDsc_Sel, AV46TFCliCod, AV47TFCliCod_Sel, AV44TFPreLis, AV45TFPreLis_To, AV50TFLisFech, AV51TFLisFech_To, AV13OrderedBy, AV14OrderedDsc, AV10GridState, AV30DynamicFiltersIgnoreFirst, AV29DynamicFiltersRemoving) ;
         /*  Sending Event outputs  */
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV10GridState", AV10GridState);
         cmbavDynamicfiltersselector2.CurrentValue = StringUtil.RTrim( AV20DynamicFiltersSelector2);
         AssignProp("", false, cmbavDynamicfiltersselector2_Internalname, "Values", cmbavDynamicfiltersselector2.ToJavascriptSource(), true);
         cmbavDynamicfiltersoperator2.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV21DynamicFiltersOperator2), 4, 0));
         AssignProp("", false, cmbavDynamicfiltersoperator2_Internalname, "Values", cmbavDynamicfiltersoperator2.ToJavascriptSource(), true);
         cmbavDynamicfiltersselector3.CurrentValue = StringUtil.RTrim( AV25DynamicFiltersSelector3);
         AssignProp("", false, cmbavDynamicfiltersselector3_Internalname, "Values", cmbavDynamicfiltersselector3.ToJavascriptSource(), true);
         cmbavDynamicfiltersoperator3.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV26DynamicFiltersOperator3), 4, 0));
         AssignProp("", false, cmbavDynamicfiltersoperator3_Internalname, "Values", cmbavDynamicfiltersoperator3.ToJavascriptSource(), true);
         cmbavDynamicfiltersselector1.CurrentValue = StringUtil.RTrim( AV15DynamicFiltersSelector1);
         AssignProp("", false, cmbavDynamicfiltersselector1_Internalname, "Values", cmbavDynamicfiltersselector1.ToJavascriptSource(), true);
         cmbavDynamicfiltersoperator1.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV16DynamicFiltersOperator1), 4, 0));
         AssignProp("", false, cmbavDynamicfiltersoperator1_Internalname, "Values", cmbavDynamicfiltersoperator1.ToJavascriptSource(), true);
      }

      protected void E221R2( )
      {
         /* Dynamicfiltersselector2_Click Routine */
         returnInSub = false;
         AV21DynamicFiltersOperator2 = 0;
         AssignAttri("", false, "AV21DynamicFiltersOperator2", StringUtil.LTrimStr( (decimal)(AV21DynamicFiltersOperator2), 4, 0));
         /* Execute user subroutine: 'ENABLEDYNAMICFILTERS2' */
         S122 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
         /*  Sending Event outputs  */
         cmbavDynamicfiltersoperator2.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV21DynamicFiltersOperator2), 4, 0));
         AssignProp("", false, cmbavDynamicfiltersoperator2_Internalname, "Values", cmbavDynamicfiltersoperator2.ToJavascriptSource(), true);
      }

      protected void E171R2( )
      {
         /* 'RemoveDynamicFilters3' Routine */
         returnInSub = false;
         AV29DynamicFiltersRemoving = true;
         AssignAttri("", false, "AV29DynamicFiltersRemoving", AV29DynamicFiltersRemoving);
         AV24DynamicFiltersEnabled3 = false;
         AssignAttri("", false, "AV24DynamicFiltersEnabled3", AV24DynamicFiltersEnabled3);
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
         AV29DynamicFiltersRemoving = false;
         AssignAttri("", false, "AV29DynamicFiltersRemoving", AV29DynamicFiltersRemoving);
         gxgrGrid_refresh( subGrid_Rows, AV15DynamicFiltersSelector1, AV16DynamicFiltersOperator1, AV17TipLProdDsc1, AV18TipLDsc1, AV20DynamicFiltersSelector2, AV21DynamicFiltersOperator2, AV22TipLProdDsc2, AV23TipLDsc2, AV25DynamicFiltersSelector3, AV26DynamicFiltersOperator3, AV27TipLProdDsc3, AV28TipLDsc3, AV19DynamicFiltersEnabled2, AV24DynamicFiltersEnabled3, AV67Pgmname, AV42TFTipLDsc, AV43TFTipLDsc_Sel, AV38TFProdCod, AV39TFProdCod_Sel, AV40TFTipLProdDsc, AV41TFTipLProdDsc_Sel, AV46TFCliCod, AV47TFCliCod_Sel, AV44TFPreLis, AV45TFPreLis_To, AV50TFLisFech, AV51TFLisFech_To, AV13OrderedBy, AV14OrderedDsc, AV10GridState, AV30DynamicFiltersIgnoreFirst, AV29DynamicFiltersRemoving) ;
         /*  Sending Event outputs  */
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV10GridState", AV10GridState);
         cmbavDynamicfiltersselector2.CurrentValue = StringUtil.RTrim( AV20DynamicFiltersSelector2);
         AssignProp("", false, cmbavDynamicfiltersselector2_Internalname, "Values", cmbavDynamicfiltersselector2.ToJavascriptSource(), true);
         cmbavDynamicfiltersoperator2.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV21DynamicFiltersOperator2), 4, 0));
         AssignProp("", false, cmbavDynamicfiltersoperator2_Internalname, "Values", cmbavDynamicfiltersoperator2.ToJavascriptSource(), true);
         cmbavDynamicfiltersselector3.CurrentValue = StringUtil.RTrim( AV25DynamicFiltersSelector3);
         AssignProp("", false, cmbavDynamicfiltersselector3_Internalname, "Values", cmbavDynamicfiltersselector3.ToJavascriptSource(), true);
         cmbavDynamicfiltersoperator3.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV26DynamicFiltersOperator3), 4, 0));
         AssignProp("", false, cmbavDynamicfiltersoperator3_Internalname, "Values", cmbavDynamicfiltersoperator3.ToJavascriptSource(), true);
         cmbavDynamicfiltersselector1.CurrentValue = StringUtil.RTrim( AV15DynamicFiltersSelector1);
         AssignProp("", false, cmbavDynamicfiltersselector1_Internalname, "Values", cmbavDynamicfiltersselector1.ToJavascriptSource(), true);
         cmbavDynamicfiltersoperator1.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV16DynamicFiltersOperator1), 4, 0));
         AssignProp("", false, cmbavDynamicfiltersoperator1_Internalname, "Values", cmbavDynamicfiltersoperator1.ToJavascriptSource(), true);
      }

      protected void E231R2( )
      {
         /* Dynamicfiltersselector3_Click Routine */
         returnInSub = false;
         AV26DynamicFiltersOperator3 = 0;
         AssignAttri("", false, "AV26DynamicFiltersOperator3", StringUtil.LTrimStr( (decimal)(AV26DynamicFiltersOperator3), 4, 0));
         /* Execute user subroutine: 'ENABLEDYNAMICFILTERS3' */
         S132 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
         /*  Sending Event outputs  */
         cmbavDynamicfiltersoperator3.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV26DynamicFiltersOperator3), 4, 0));
         AssignProp("", false, cmbavDynamicfiltersoperator3_Internalname, "Values", cmbavDynamicfiltersoperator3.ToJavascriptSource(), true);
      }

      protected void E271R2( )
      {
         /* Gridactions_Click Routine */
         returnInSub = false;
         if ( AV62GridActions == 1 )
         {
            /* Execute user subroutine: 'DO UPDATE' */
            S212 ();
            if ( returnInSub )
            {
               returnInSub = true;
               if (true) return;
            }
         }
         else if ( AV62GridActions == 2 )
         {
            /* Execute user subroutine: 'DO DELETE' */
            S222 ();
            if ( returnInSub )
            {
               returnInSub = true;
               if (true) return;
            }
         }
         AV62GridActions = 0;
         AssignAttri("", false, cmbavGridactions_Internalname, StringUtil.LTrimStr( (decimal)(AV62GridActions), 4, 0));
         /*  Sending Event outputs  */
         cmbavGridactions.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV62GridActions), 4, 0));
         AssignProp("", false, cmbavGridactions_Internalname, "Values", cmbavGridactions.ToJavascriptSource(), true);
      }

      protected void E181R2( )
      {
         /* 'DoInsert' Routine */
         returnInSub = false;
         GXKey = Crypto.GetSiteKey( );
         GXEncryptionTmp = "configuracion.listaprecios.aspx"+UrlEncode(StringUtil.RTrim("INS")) + "," + UrlEncode(StringUtil.LTrimStr(0,1,0)) + "," + UrlEncode(StringUtil.LTrimStr(0,1,0));
         CallWebObject(formatLink("configuracion.listaprecios.aspx") + "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey));
         context.wjLocDisableFrm = 1;
      }

      protected void E131R2( )
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
         cmbavDynamicfiltersselector1.CurrentValue = StringUtil.RTrim( AV15DynamicFiltersSelector1);
         AssignProp("", false, cmbavDynamicfiltersselector1_Internalname, "Values", cmbavDynamicfiltersselector1.ToJavascriptSource(), true);
         cmbavDynamicfiltersoperator1.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV16DynamicFiltersOperator1), 4, 0));
         AssignProp("", false, cmbavDynamicfiltersoperator1_Internalname, "Values", cmbavDynamicfiltersoperator1.ToJavascriptSource(), true);
         cmbavDynamicfiltersselector2.CurrentValue = StringUtil.RTrim( AV20DynamicFiltersSelector2);
         AssignProp("", false, cmbavDynamicfiltersselector2_Internalname, "Values", cmbavDynamicfiltersselector2.ToJavascriptSource(), true);
         cmbavDynamicfiltersoperator2.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV21DynamicFiltersOperator2), 4, 0));
         AssignProp("", false, cmbavDynamicfiltersoperator2_Internalname, "Values", cmbavDynamicfiltersoperator2.ToJavascriptSource(), true);
         cmbavDynamicfiltersselector3.CurrentValue = StringUtil.RTrim( AV25DynamicFiltersSelector3);
         AssignProp("", false, cmbavDynamicfiltersselector3_Internalname, "Values", cmbavDynamicfiltersselector3.ToJavascriptSource(), true);
         cmbavDynamicfiltersoperator3.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV26DynamicFiltersOperator3), 4, 0));
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
         edtavTiplproddsc1_Visible = 0;
         AssignProp("", false, edtavTiplproddsc1_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavTiplproddsc1_Visible), 5, 0), true);
         edtavTipldsc1_Visible = 0;
         AssignProp("", false, edtavTipldsc1_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavTipldsc1_Visible), 5, 0), true);
         cmbavDynamicfiltersoperator1.Visible = 0;
         AssignProp("", false, cmbavDynamicfiltersoperator1_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(cmbavDynamicfiltersoperator1.Visible), 5, 0), true);
         if ( StringUtil.StrCmp(AV15DynamicFiltersSelector1, "TIPLPRODDSC") == 0 )
         {
            edtavTiplproddsc1_Visible = 1;
            AssignProp("", false, edtavTiplproddsc1_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavTiplproddsc1_Visible), 5, 0), true);
            cmbavDynamicfiltersoperator1.Visible = 1;
            AssignProp("", false, cmbavDynamicfiltersoperator1_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(cmbavDynamicfiltersoperator1.Visible), 5, 0), true);
         }
         else if ( StringUtil.StrCmp(AV15DynamicFiltersSelector1, "TIPLDSC") == 0 )
         {
            edtavTipldsc1_Visible = 1;
            AssignProp("", false, edtavTipldsc1_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavTipldsc1_Visible), 5, 0), true);
            cmbavDynamicfiltersoperator1.Visible = 1;
            AssignProp("", false, cmbavDynamicfiltersoperator1_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(cmbavDynamicfiltersoperator1.Visible), 5, 0), true);
         }
      }

      protected void S122( )
      {
         /* 'ENABLEDYNAMICFILTERS2' Routine */
         returnInSub = false;
         edtavTiplproddsc2_Visible = 0;
         AssignProp("", false, edtavTiplproddsc2_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavTiplproddsc2_Visible), 5, 0), true);
         edtavTipldsc2_Visible = 0;
         AssignProp("", false, edtavTipldsc2_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavTipldsc2_Visible), 5, 0), true);
         cmbavDynamicfiltersoperator2.Visible = 0;
         AssignProp("", false, cmbavDynamicfiltersoperator2_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(cmbavDynamicfiltersoperator2.Visible), 5, 0), true);
         if ( StringUtil.StrCmp(AV20DynamicFiltersSelector2, "TIPLPRODDSC") == 0 )
         {
            edtavTiplproddsc2_Visible = 1;
            AssignProp("", false, edtavTiplproddsc2_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavTiplproddsc2_Visible), 5, 0), true);
            cmbavDynamicfiltersoperator2.Visible = 1;
            AssignProp("", false, cmbavDynamicfiltersoperator2_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(cmbavDynamicfiltersoperator2.Visible), 5, 0), true);
         }
         else if ( StringUtil.StrCmp(AV20DynamicFiltersSelector2, "TIPLDSC") == 0 )
         {
            edtavTipldsc2_Visible = 1;
            AssignProp("", false, edtavTipldsc2_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavTipldsc2_Visible), 5, 0), true);
            cmbavDynamicfiltersoperator2.Visible = 1;
            AssignProp("", false, cmbavDynamicfiltersoperator2_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(cmbavDynamicfiltersoperator2.Visible), 5, 0), true);
         }
      }

      protected void S132( )
      {
         /* 'ENABLEDYNAMICFILTERS3' Routine */
         returnInSub = false;
         edtavTiplproddsc3_Visible = 0;
         AssignProp("", false, edtavTiplproddsc3_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavTiplproddsc3_Visible), 5, 0), true);
         edtavTipldsc3_Visible = 0;
         AssignProp("", false, edtavTipldsc3_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavTipldsc3_Visible), 5, 0), true);
         cmbavDynamicfiltersoperator3.Visible = 0;
         AssignProp("", false, cmbavDynamicfiltersoperator3_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(cmbavDynamicfiltersoperator3.Visible), 5, 0), true);
         if ( StringUtil.StrCmp(AV25DynamicFiltersSelector3, "TIPLPRODDSC") == 0 )
         {
            edtavTiplproddsc3_Visible = 1;
            AssignProp("", false, edtavTiplproddsc3_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavTiplproddsc3_Visible), 5, 0), true);
            cmbavDynamicfiltersoperator3.Visible = 1;
            AssignProp("", false, cmbavDynamicfiltersoperator3_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(cmbavDynamicfiltersoperator3.Visible), 5, 0), true);
         }
         else if ( StringUtil.StrCmp(AV25DynamicFiltersSelector3, "TIPLDSC") == 0 )
         {
            edtavTipldsc3_Visible = 1;
            AssignProp("", false, edtavTipldsc3_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavTipldsc3_Visible), 5, 0), true);
            cmbavDynamicfiltersoperator3.Visible = 1;
            AssignProp("", false, cmbavDynamicfiltersoperator3_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(cmbavDynamicfiltersoperator3.Visible), 5, 0), true);
         }
      }

      protected void S192( )
      {
         /* 'RESETDYNFILTERS' Routine */
         returnInSub = false;
         AV19DynamicFiltersEnabled2 = false;
         AssignAttri("", false, "AV19DynamicFiltersEnabled2", AV19DynamicFiltersEnabled2);
         AV20DynamicFiltersSelector2 = "TIPLPRODDSC";
         AssignAttri("", false, "AV20DynamicFiltersSelector2", AV20DynamicFiltersSelector2);
         AV21DynamicFiltersOperator2 = 0;
         AssignAttri("", false, "AV21DynamicFiltersOperator2", StringUtil.LTrimStr( (decimal)(AV21DynamicFiltersOperator2), 4, 0));
         AV22TipLProdDsc2 = "";
         AssignAttri("", false, "AV22TipLProdDsc2", AV22TipLProdDsc2);
         /* Execute user subroutine: 'ENABLEDYNAMICFILTERS2' */
         S122 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
         AV24DynamicFiltersEnabled3 = false;
         AssignAttri("", false, "AV24DynamicFiltersEnabled3", AV24DynamicFiltersEnabled3);
         AV25DynamicFiltersSelector3 = "TIPLPRODDSC";
         AssignAttri("", false, "AV25DynamicFiltersSelector3", AV25DynamicFiltersSelector3);
         AV26DynamicFiltersOperator3 = 0;
         AssignAttri("", false, "AV26DynamicFiltersOperator3", StringUtil.LTrimStr( (decimal)(AV26DynamicFiltersOperator3), 4, 0));
         AV27TipLProdDsc3 = "";
         AssignAttri("", false, "AV27TipLProdDsc3", AV27TipLProdDsc3);
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
         GXEncryptionTmp = "configuracion.listaprecios.aspx"+UrlEncode(StringUtil.RTrim("UPD")) + "," + UrlEncode(StringUtil.LTrimStr(A202TipLCod,6,0)) + "," + UrlEncode(StringUtil.LTrimStr(A203TipLItem,6,0));
         CallWebObject(formatLink("configuracion.listaprecios.aspx") + "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey));
         context.wjLocDisableFrm = 1;
      }

      protected void S222( )
      {
         /* 'DO DELETE' Routine */
         returnInSub = false;
         GXKey = Crypto.GetSiteKey( );
         GXEncryptionTmp = "configuracion.listaprecios.aspx"+UrlEncode(StringUtil.RTrim("DLT")) + "," + UrlEncode(StringUtil.LTrimStr(A202TipLCod,6,0)) + "," + UrlEncode(StringUtil.LTrimStr(A203TipLItem,6,0));
         CallWebObject(formatLink("configuracion.listaprecios.aspx") + "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey));
         context.wjLocDisableFrm = 1;
      }

      protected void S152( )
      {
         /* 'LOADGRIDSTATE' Routine */
         returnInSub = false;
         if ( StringUtil.StrCmp(AV33Session.Get(AV67Pgmname+"GridState"), "") == 0 )
         {
            AV10GridState.FromXml(new GeneXus.Programs.wwpbaseobjects.loadgridstate(context).executeUdp(  AV67Pgmname+"GridState"), null, "", "");
         }
         else
         {
            AV10GridState.FromXml(AV33Session.Get(AV67Pgmname+"GridState"), null, "", "");
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
         AV94GXV1 = 1;
         while ( AV94GXV1 <= AV10GridState.gxTpr_Filtervalues.Count )
         {
            AV11GridStateFilterValue = ((GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue)AV10GridState.gxTpr_Filtervalues.Item(AV94GXV1));
            if ( StringUtil.StrCmp(AV11GridStateFilterValue.gxTpr_Name, "TFTIPLDSC") == 0 )
            {
               AV42TFTipLDsc = AV11GridStateFilterValue.gxTpr_Value;
               AssignAttri("", false, "AV42TFTipLDsc", AV42TFTipLDsc);
            }
            else if ( StringUtil.StrCmp(AV11GridStateFilterValue.gxTpr_Name, "TFTIPLDSC_SEL") == 0 )
            {
               AV43TFTipLDsc_Sel = AV11GridStateFilterValue.gxTpr_Value;
               AssignAttri("", false, "AV43TFTipLDsc_Sel", AV43TFTipLDsc_Sel);
            }
            else if ( StringUtil.StrCmp(AV11GridStateFilterValue.gxTpr_Name, "TFPRODCOD") == 0 )
            {
               AV38TFProdCod = AV11GridStateFilterValue.gxTpr_Value;
               AssignAttri("", false, "AV38TFProdCod", AV38TFProdCod);
            }
            else if ( StringUtil.StrCmp(AV11GridStateFilterValue.gxTpr_Name, "TFPRODCOD_SEL") == 0 )
            {
               AV39TFProdCod_Sel = AV11GridStateFilterValue.gxTpr_Value;
               AssignAttri("", false, "AV39TFProdCod_Sel", AV39TFProdCod_Sel);
            }
            else if ( StringUtil.StrCmp(AV11GridStateFilterValue.gxTpr_Name, "TFTIPLPRODDSC") == 0 )
            {
               AV40TFTipLProdDsc = AV11GridStateFilterValue.gxTpr_Value;
               AssignAttri("", false, "AV40TFTipLProdDsc", AV40TFTipLProdDsc);
            }
            else if ( StringUtil.StrCmp(AV11GridStateFilterValue.gxTpr_Name, "TFTIPLPRODDSC_SEL") == 0 )
            {
               AV41TFTipLProdDsc_Sel = AV11GridStateFilterValue.gxTpr_Value;
               AssignAttri("", false, "AV41TFTipLProdDsc_Sel", AV41TFTipLProdDsc_Sel);
            }
            else if ( StringUtil.StrCmp(AV11GridStateFilterValue.gxTpr_Name, "TFCLICOD") == 0 )
            {
               AV46TFCliCod = AV11GridStateFilterValue.gxTpr_Value;
               AssignAttri("", false, "AV46TFCliCod", AV46TFCliCod);
            }
            else if ( StringUtil.StrCmp(AV11GridStateFilterValue.gxTpr_Name, "TFCLICOD_SEL") == 0 )
            {
               AV47TFCliCod_Sel = AV11GridStateFilterValue.gxTpr_Value;
               AssignAttri("", false, "AV47TFCliCod_Sel", AV47TFCliCod_Sel);
            }
            else if ( StringUtil.StrCmp(AV11GridStateFilterValue.gxTpr_Name, "TFPRELIS") == 0 )
            {
               AV44TFPreLis = NumberUtil.Val( AV11GridStateFilterValue.gxTpr_Value, ".");
               AssignAttri("", false, "AV44TFPreLis", StringUtil.LTrimStr( AV44TFPreLis, 15, 4));
               AV45TFPreLis_To = NumberUtil.Val( AV11GridStateFilterValue.gxTpr_Valueto, ".");
               AssignAttri("", false, "AV45TFPreLis_To", StringUtil.LTrimStr( AV45TFPreLis_To, 15, 4));
            }
            else if ( StringUtil.StrCmp(AV11GridStateFilterValue.gxTpr_Name, "TFLISFECH") == 0 )
            {
               AV50TFLisFech = context.localUtil.CToD( AV11GridStateFilterValue.gxTpr_Value, 2);
               AssignAttri("", false, "AV50TFLisFech", context.localUtil.Format(AV50TFLisFech, "99/99/99"));
               AV51TFLisFech_To = context.localUtil.CToD( AV11GridStateFilterValue.gxTpr_Valueto, 2);
               AssignAttri("", false, "AV51TFLisFech_To", context.localUtil.Format(AV51TFLisFech_To, "99/99/99"));
            }
            AV94GXV1 = (int)(AV94GXV1+1);
         }
         GXt_char2 = "";
         new GeneXus.Programs.wwpbaseobjects.wwp_getfilterval(context ).execute(  String.IsNullOrEmpty(StringUtil.RTrim( AV43TFTipLDsc_Sel)),  AV43TFTipLDsc_Sel, out  GXt_char2) ;
         GXt_char3 = "";
         new GeneXus.Programs.wwpbaseobjects.wwp_getfilterval(context ).execute(  String.IsNullOrEmpty(StringUtil.RTrim( AV39TFProdCod_Sel)),  AV39TFProdCod_Sel, out  GXt_char3) ;
         GXt_char4 = "";
         new GeneXus.Programs.wwpbaseobjects.wwp_getfilterval(context ).execute(  String.IsNullOrEmpty(StringUtil.RTrim( AV41TFTipLProdDsc_Sel)),  AV41TFTipLProdDsc_Sel, out  GXt_char4) ;
         GXt_char5 = "";
         new GeneXus.Programs.wwpbaseobjects.wwp_getfilterval(context ).execute(  String.IsNullOrEmpty(StringUtil.RTrim( AV47TFCliCod_Sel)),  AV47TFCliCod_Sel, out  GXt_char5) ;
         Ddo_grid_Selectedvalue_set = GXt_char2+"|"+GXt_char3+"|"+GXt_char4+"|"+GXt_char5+"||";
         ucDdo_grid.SendProperty(context, "", false, Ddo_grid_Internalname, "SelectedValue_set", Ddo_grid_Selectedvalue_set);
         GXt_char5 = "";
         new GeneXus.Programs.wwpbaseobjects.wwp_getfilterval(context ).execute(  String.IsNullOrEmpty(StringUtil.RTrim( AV42TFTipLDsc)),  AV42TFTipLDsc, out  GXt_char5) ;
         GXt_char4 = "";
         new GeneXus.Programs.wwpbaseobjects.wwp_getfilterval(context ).execute(  String.IsNullOrEmpty(StringUtil.RTrim( AV38TFProdCod)),  AV38TFProdCod, out  GXt_char4) ;
         GXt_char3 = "";
         new GeneXus.Programs.wwpbaseobjects.wwp_getfilterval(context ).execute(  String.IsNullOrEmpty(StringUtil.RTrim( AV40TFTipLProdDsc)),  AV40TFTipLProdDsc, out  GXt_char3) ;
         GXt_char2 = "";
         new GeneXus.Programs.wwpbaseobjects.wwp_getfilterval(context ).execute(  String.IsNullOrEmpty(StringUtil.RTrim( AV46TFCliCod)),  AV46TFCliCod, out  GXt_char2) ;
         Ddo_grid_Filteredtext_set = GXt_char5+"|"+GXt_char4+"|"+GXt_char3+"|"+GXt_char2+"|"+((Convert.ToDecimal(0)==AV44TFPreLis) ? "" : StringUtil.Str( AV44TFPreLis, 15, 4))+"|"+((DateTime.MinValue==AV50TFLisFech) ? "" : context.localUtil.DToC( AV50TFLisFech, 2, "/"));
         ucDdo_grid.SendProperty(context, "", false, Ddo_grid_Internalname, "FilteredText_set", Ddo_grid_Filteredtext_set);
         Ddo_grid_Filteredtextto_set = "||||"+((Convert.ToDecimal(0)==AV45TFPreLis_To) ? "" : StringUtil.Str( AV45TFPreLis_To, 15, 4))+"|"+((DateTime.MinValue==AV51TFLisFech_To) ? "" : context.localUtil.DToC( AV51TFLisFech_To, 2, "/"));
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
            if ( StringUtil.StrCmp(AV15DynamicFiltersSelector1, "TIPLPRODDSC") == 0 )
            {
               AV16DynamicFiltersOperator1 = AV12GridStateDynamicFilter.gxTpr_Operator;
               AssignAttri("", false, "AV16DynamicFiltersOperator1", StringUtil.LTrimStr( (decimal)(AV16DynamicFiltersOperator1), 4, 0));
               AV17TipLProdDsc1 = AV12GridStateDynamicFilter.gxTpr_Value;
               AssignAttri("", false, "AV17TipLProdDsc1", AV17TipLProdDsc1);
            }
            else if ( StringUtil.StrCmp(AV15DynamicFiltersSelector1, "TIPLDSC") == 0 )
            {
               AV16DynamicFiltersOperator1 = AV12GridStateDynamicFilter.gxTpr_Operator;
               AssignAttri("", false, "AV16DynamicFiltersOperator1", StringUtil.LTrimStr( (decimal)(AV16DynamicFiltersOperator1), 4, 0));
               AV18TipLDsc1 = AV12GridStateDynamicFilter.gxTpr_Value;
               AssignAttri("", false, "AV18TipLDsc1", AV18TipLDsc1);
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
               AV19DynamicFiltersEnabled2 = true;
               AssignAttri("", false, "AV19DynamicFiltersEnabled2", AV19DynamicFiltersEnabled2);
               AV12GridStateDynamicFilter = ((GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter)AV10GridState.gxTpr_Dynamicfilters.Item(2));
               AV20DynamicFiltersSelector2 = AV12GridStateDynamicFilter.gxTpr_Selected;
               AssignAttri("", false, "AV20DynamicFiltersSelector2", AV20DynamicFiltersSelector2);
               if ( StringUtil.StrCmp(AV20DynamicFiltersSelector2, "TIPLPRODDSC") == 0 )
               {
                  AV21DynamicFiltersOperator2 = AV12GridStateDynamicFilter.gxTpr_Operator;
                  AssignAttri("", false, "AV21DynamicFiltersOperator2", StringUtil.LTrimStr( (decimal)(AV21DynamicFiltersOperator2), 4, 0));
                  AV22TipLProdDsc2 = AV12GridStateDynamicFilter.gxTpr_Value;
                  AssignAttri("", false, "AV22TipLProdDsc2", AV22TipLProdDsc2);
               }
               else if ( StringUtil.StrCmp(AV20DynamicFiltersSelector2, "TIPLDSC") == 0 )
               {
                  AV21DynamicFiltersOperator2 = AV12GridStateDynamicFilter.gxTpr_Operator;
                  AssignAttri("", false, "AV21DynamicFiltersOperator2", StringUtil.LTrimStr( (decimal)(AV21DynamicFiltersOperator2), 4, 0));
                  AV23TipLDsc2 = AV12GridStateDynamicFilter.gxTpr_Value;
                  AssignAttri("", false, "AV23TipLDsc2", AV23TipLDsc2);
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
                  AV24DynamicFiltersEnabled3 = true;
                  AssignAttri("", false, "AV24DynamicFiltersEnabled3", AV24DynamicFiltersEnabled3);
                  AV12GridStateDynamicFilter = ((GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter)AV10GridState.gxTpr_Dynamicfilters.Item(3));
                  AV25DynamicFiltersSelector3 = AV12GridStateDynamicFilter.gxTpr_Selected;
                  AssignAttri("", false, "AV25DynamicFiltersSelector3", AV25DynamicFiltersSelector3);
                  if ( StringUtil.StrCmp(AV25DynamicFiltersSelector3, "TIPLPRODDSC") == 0 )
                  {
                     AV26DynamicFiltersOperator3 = AV12GridStateDynamicFilter.gxTpr_Operator;
                     AssignAttri("", false, "AV26DynamicFiltersOperator3", StringUtil.LTrimStr( (decimal)(AV26DynamicFiltersOperator3), 4, 0));
                     AV27TipLProdDsc3 = AV12GridStateDynamicFilter.gxTpr_Value;
                     AssignAttri("", false, "AV27TipLProdDsc3", AV27TipLProdDsc3);
                  }
                  else if ( StringUtil.StrCmp(AV25DynamicFiltersSelector3, "TIPLDSC") == 0 )
                  {
                     AV26DynamicFiltersOperator3 = AV12GridStateDynamicFilter.gxTpr_Operator;
                     AssignAttri("", false, "AV26DynamicFiltersOperator3", StringUtil.LTrimStr( (decimal)(AV26DynamicFiltersOperator3), 4, 0));
                     AV28TipLDsc3 = AV12GridStateDynamicFilter.gxTpr_Value;
                     AssignAttri("", false, "AV28TipLDsc3", AV28TipLDsc3);
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
         if ( AV29DynamicFiltersRemoving )
         {
            lblJsdynamicfilters_Caption = "";
            AssignProp("", false, lblJsdynamicfilters_Internalname, "Caption", lblJsdynamicfilters_Caption, true);
         }
      }

      protected void S172( )
      {
         /* 'SAVEGRIDSTATE' Routine */
         returnInSub = false;
         AV10GridState.FromXml(AV33Session.Get(AV67Pgmname+"GridState"), null, "", "");
         AV10GridState.gxTpr_Orderedby = AV13OrderedBy;
         AV10GridState.gxTpr_Ordereddsc = AV14OrderedDsc;
         AV10GridState.gxTpr_Filtervalues.Clear();
         new GeneXus.Programs.wwpbaseobjects.wwp_gridstateaddfiltervalueandsel(context ).execute( ref  AV10GridState,  "TFTIPLDSC",  "Tipo de Lista",  !String.IsNullOrEmpty(StringUtil.RTrim( AV42TFTipLDsc)),  0,  AV42TFTipLDsc,  "",  !String.IsNullOrEmpty(StringUtil.RTrim( AV43TFTipLDsc_Sel)),  AV43TFTipLDsc_Sel,  "") ;
         new GeneXus.Programs.wwpbaseobjects.wwp_gridstateaddfiltervalueandsel(context ).execute( ref  AV10GridState,  "TFPRODCOD",  "Codigo",  !String.IsNullOrEmpty(StringUtil.RTrim( AV38TFProdCod)),  0,  AV38TFProdCod,  "",  !String.IsNullOrEmpty(StringUtil.RTrim( AV39TFProdCod_Sel)),  AV39TFProdCod_Sel,  "") ;
         new GeneXus.Programs.wwpbaseobjects.wwp_gridstateaddfiltervalueandsel(context ).execute( ref  AV10GridState,  "TFTIPLPRODDSC",  "Producto",  !String.IsNullOrEmpty(StringUtil.RTrim( AV40TFTipLProdDsc)),  0,  AV40TFTipLProdDsc,  "",  !String.IsNullOrEmpty(StringUtil.RTrim( AV41TFTipLProdDsc_Sel)),  AV41TFTipLProdDsc_Sel,  "") ;
         new GeneXus.Programs.wwpbaseobjects.wwp_gridstateaddfiltervalueandsel(context ).execute( ref  AV10GridState,  "TFCLICOD",  "R.U.C. Cliente",  !String.IsNullOrEmpty(StringUtil.RTrim( AV46TFCliCod)),  0,  AV46TFCliCod,  "",  !String.IsNullOrEmpty(StringUtil.RTrim( AV47TFCliCod_Sel)),  AV47TFCliCod_Sel,  "") ;
         new GeneXus.Programs.wwpbaseobjects.wwp_gridstateaddfiltervalue(context ).execute( ref  AV10GridState,  "TFPRELIS",  "Precio",  !((Convert.ToDecimal(0)==AV44TFPreLis)&&(Convert.ToDecimal(0)==AV45TFPreLis_To)),  0,  StringUtil.Trim( StringUtil.Str( AV44TFPreLis, 15, 4)),  StringUtil.Trim( StringUtil.Str( AV45TFPreLis_To, 15, 4))) ;
         new GeneXus.Programs.wwpbaseobjects.wwp_gridstateaddfiltervalue(context ).execute( ref  AV10GridState,  "TFLISFECH",  "Fecha",  !((DateTime.MinValue==AV50TFLisFech)&&(DateTime.MinValue==AV51TFLisFech_To)),  0,  StringUtil.Trim( context.localUtil.DToC( AV50TFLisFech, 2, "/")),  StringUtil.Trim( context.localUtil.DToC( AV51TFLisFech_To, 2, "/"))) ;
         /* Execute user subroutine: 'SAVEDYNFILTERSSTATE' */
         S182 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
         AV10GridState.gxTpr_Pagesize = StringUtil.Str( (decimal)(subGrid_Rows), 10, 0);
         AV10GridState.gxTpr_Currentpage = (short)(subGrid_fnc_Currentpage( ));
         new GeneXus.Programs.wwpbaseobjects.savegridstate(context ).execute(  AV67Pgmname+"GridState",  AV10GridState.ToXml(false, true, "", "")) ;
      }

      protected void S182( )
      {
         /* 'SAVEDYNFILTERSSTATE' Routine */
         returnInSub = false;
         AV10GridState.gxTpr_Dynamicfilters.Clear();
         if ( ! AV30DynamicFiltersIgnoreFirst )
         {
            AV12GridStateDynamicFilter = new GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter(context);
            AV12GridStateDynamicFilter.gxTpr_Selected = AV15DynamicFiltersSelector1;
            if ( ( StringUtil.StrCmp(AV15DynamicFiltersSelector1, "TIPLPRODDSC") == 0 ) && ! String.IsNullOrEmpty(StringUtil.RTrim( AV17TipLProdDsc1)) )
            {
               AV12GridStateDynamicFilter.gxTpr_Dsc = "Producto";
               AV12GridStateDynamicFilter.gxTpr_Value = AV17TipLProdDsc1;
               AV12GridStateDynamicFilter.gxTpr_Operator = AV16DynamicFiltersOperator1;
            }
            else if ( ( StringUtil.StrCmp(AV15DynamicFiltersSelector1, "TIPLDSC") == 0 ) && ! String.IsNullOrEmpty(StringUtil.RTrim( AV18TipLDsc1)) )
            {
               AV12GridStateDynamicFilter.gxTpr_Dsc = "Tipo de Lista";
               AV12GridStateDynamicFilter.gxTpr_Value = AV18TipLDsc1;
               AV12GridStateDynamicFilter.gxTpr_Operator = AV16DynamicFiltersOperator1;
            }
            if ( AV29DynamicFiltersRemoving || ! String.IsNullOrEmpty(StringUtil.RTrim( AV12GridStateDynamicFilter.gxTpr_Value)) )
            {
               AV10GridState.gxTpr_Dynamicfilters.Add(AV12GridStateDynamicFilter, 0);
            }
         }
         if ( AV19DynamicFiltersEnabled2 )
         {
            AV12GridStateDynamicFilter = new GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter(context);
            AV12GridStateDynamicFilter.gxTpr_Selected = AV20DynamicFiltersSelector2;
            if ( ( StringUtil.StrCmp(AV20DynamicFiltersSelector2, "TIPLPRODDSC") == 0 ) && ! String.IsNullOrEmpty(StringUtil.RTrim( AV22TipLProdDsc2)) )
            {
               AV12GridStateDynamicFilter.gxTpr_Dsc = "Producto";
               AV12GridStateDynamicFilter.gxTpr_Value = AV22TipLProdDsc2;
               AV12GridStateDynamicFilter.gxTpr_Operator = AV21DynamicFiltersOperator2;
            }
            else if ( ( StringUtil.StrCmp(AV20DynamicFiltersSelector2, "TIPLDSC") == 0 ) && ! String.IsNullOrEmpty(StringUtil.RTrim( AV23TipLDsc2)) )
            {
               AV12GridStateDynamicFilter.gxTpr_Dsc = "Tipo de Lista";
               AV12GridStateDynamicFilter.gxTpr_Value = AV23TipLDsc2;
               AV12GridStateDynamicFilter.gxTpr_Operator = AV21DynamicFiltersOperator2;
            }
            if ( AV29DynamicFiltersRemoving || ! String.IsNullOrEmpty(StringUtil.RTrim( AV12GridStateDynamicFilter.gxTpr_Value)) )
            {
               AV10GridState.gxTpr_Dynamicfilters.Add(AV12GridStateDynamicFilter, 0);
            }
         }
         if ( AV24DynamicFiltersEnabled3 )
         {
            AV12GridStateDynamicFilter = new GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter(context);
            AV12GridStateDynamicFilter.gxTpr_Selected = AV25DynamicFiltersSelector3;
            if ( ( StringUtil.StrCmp(AV25DynamicFiltersSelector3, "TIPLPRODDSC") == 0 ) && ! String.IsNullOrEmpty(StringUtil.RTrim( AV27TipLProdDsc3)) )
            {
               AV12GridStateDynamicFilter.gxTpr_Dsc = "Producto";
               AV12GridStateDynamicFilter.gxTpr_Value = AV27TipLProdDsc3;
               AV12GridStateDynamicFilter.gxTpr_Operator = AV26DynamicFiltersOperator3;
            }
            else if ( ( StringUtil.StrCmp(AV25DynamicFiltersSelector3, "TIPLDSC") == 0 ) && ! String.IsNullOrEmpty(StringUtil.RTrim( AV28TipLDsc3)) )
            {
               AV12GridStateDynamicFilter.gxTpr_Dsc = "Tipo de Lista";
               AV12GridStateDynamicFilter.gxTpr_Value = AV28TipLDsc3;
               AV12GridStateDynamicFilter.gxTpr_Operator = AV26DynamicFiltersOperator3;
            }
            if ( AV29DynamicFiltersRemoving || ! String.IsNullOrEmpty(StringUtil.RTrim( AV12GridStateDynamicFilter.gxTpr_Value)) )
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
         AV8TrnContext.gxTpr_Callerobject = AV67Pgmname;
         AV8TrnContext.gxTpr_Callerondelete = true;
         AV8TrnContext.gxTpr_Callerurl = AV7HTTPRequest.ScriptName+"?"+AV7HTTPRequest.QueryString;
         AV8TrnContext.gxTpr_Transactionname = "Configuracion.ListaPrecios";
         AV33Session.Set("TrnContext", AV8TrnContext.ToXml(false, true, "", ""));
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
         new GeneXus.Programs.configuracion.listaprecioswwexport(context ).execute( out  AV31ExcelFilename, out  AV32ErrorMessage) ;
         if ( StringUtil.StrCmp(AV31ExcelFilename, "") != 0 )
         {
            CallWebObject(formatLink(AV31ExcelFilename) );
            context.wjLocDisableFrm = 0;
         }
         else
         {
            GX_msglist.addItem(AV32ErrorMessage);
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
         Innewwindow1_Target = formatLink("configuracion.listaprecioswwexportreport.aspx") ;
         ucInnewwindow1.SendProperty(context, "", false, Innewwindow1_Internalname, "Target", Innewwindow1_Target);
         Innewwindow1_Height = "600";
         ucInnewwindow1.SendProperty(context, "", false, Innewwindow1_Internalname, "Height", Innewwindow1_Height);
         Innewwindow1_Width = "800";
         ucInnewwindow1.SendProperty(context, "", false, Innewwindow1_Internalname, "Width", Innewwindow1_Width);
         this.executeUsercontrolMethod("", false, "INNEWWINDOW1Container", "OpenWindow", "", new Object[] {});
      }

      protected void wb_table1_25_1R2( bool wbgen )
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
            GxWebStd.gx_label_ctrl( context, lblDynamicfiltersprefix1_Internalname, "Buscar en", "", "", lblDynamicfiltersprefix1_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "DataFilterDescriptionPrefix", 0, "", 1, 1, 0, 0, "HLP_Configuracion\\ListaPreciosWW.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "", "left", "top", "", "flex-grow:1;", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "left", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, cmbavDynamicfiltersselector1_Internalname, "Dynamic Filters Selector1", "gx-form-item AttributeLabel", 0, true, "width: 25%;");
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 35,'',false,'" + sGXsfl_110_idx + "',0)\"";
            /* ComboBox */
            GxWebStd.gx_combobox_ctrl1( context, cmbavDynamicfiltersselector1, cmbavDynamicfiltersselector1_Internalname, StringUtil.RTrim( AV15DynamicFiltersSelector1), 1, cmbavDynamicfiltersselector1_Jsonclick, 5, "'"+""+"'"+",false,"+"'"+"EVDYNAMICFILTERSSELECTOR1.CLICK."+"'", "svchar", "", 1, cmbavDynamicfiltersselector1.Enabled, 0, 0, 0, "em", 0, "", "", "Attribute", "", "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,35);\"", "", true, 1, "HLP_Configuracion\\ListaPreciosWW.htm");
            cmbavDynamicfiltersselector1.CurrentValue = StringUtil.RTrim( AV15DynamicFiltersSelector1);
            AssignProp("", false, cmbavDynamicfiltersselector1_Internalname, "Values", (string)(cmbavDynamicfiltersselector1.ToJavascriptSource()), true);
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "", "left", "top", "", "flex-grow:1;", "div");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblDynamicfiltersmiddle1_Internalname, "valor", "", "", lblDynamicfiltersmiddle1_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "DataFilterDescription", 0, "", 1, 1, 0, 0, "HLP_Configuracion\\ListaPreciosWW.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "", "left", "top", "", "flex-grow:1;", "div");
            wb_table2_39_1R2( true) ;
         }
         else
         {
            wb_table2_39_1R2( false) ;
         }
         return  ;
      }

      protected void wb_table2_39_1R2e( bool wbgen )
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
            GxWebStd.gx_label_ctrl( context, lblDynamicfiltersprefix2_Internalname, "Buscar en", "", "", lblDynamicfiltersprefix2_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "DataFilterDescriptionPrefix", 0, "", 1, 1, 0, 0, "HLP_Configuracion\\ListaPreciosWW.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "Invisible", "left", "top", "", "flex-grow:1;", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "left", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, cmbavDynamicfiltersselector2_Internalname, "Dynamic Filters Selector2", "gx-form-item AttributeLabel", 0, true, "width: 25%;");
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 60,'',false,'" + sGXsfl_110_idx + "',0)\"";
            /* ComboBox */
            GxWebStd.gx_combobox_ctrl1( context, cmbavDynamicfiltersselector2, cmbavDynamicfiltersselector2_Internalname, StringUtil.RTrim( AV20DynamicFiltersSelector2), 1, cmbavDynamicfiltersselector2_Jsonclick, 5, "'"+""+"'"+",false,"+"'"+"EVDYNAMICFILTERSSELECTOR2.CLICK."+"'", "svchar", "", 1, cmbavDynamicfiltersselector2.Enabled, 0, 0, 0, "em", 0, "", "", "Attribute", "", "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,60);\"", "", true, 1, "HLP_Configuracion\\ListaPreciosWW.htm");
            cmbavDynamicfiltersselector2.CurrentValue = StringUtil.RTrim( AV20DynamicFiltersSelector2);
            AssignProp("", false, cmbavDynamicfiltersselector2_Internalname, "Values", (string)(cmbavDynamicfiltersselector2.ToJavascriptSource()), true);
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "Invisible", "left", "top", "", "flex-grow:1;", "div");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblDynamicfiltersmiddle2_Internalname, "valor", "", "", lblDynamicfiltersmiddle2_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "DataFilterDescription", 0, "", 1, 1, 0, 0, "HLP_Configuracion\\ListaPreciosWW.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "Invisible", "left", "top", "", "flex-grow:1;", "div");
            wb_table3_64_1R2( true) ;
         }
         else
         {
            wb_table3_64_1R2( false) ;
         }
         return  ;
      }

      protected void wb_table3_64_1R2e( bool wbgen )
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
            GxWebStd.gx_label_ctrl( context, lblDynamicfiltersprefix3_Internalname, "Buscar en", "", "", lblDynamicfiltersprefix3_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "DataFilterDescriptionPrefix", 0, "", 1, 1, 0, 0, "HLP_Configuracion\\ListaPreciosWW.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "Invisible", "left", "top", "", "flex-grow:1;", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "left", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, cmbavDynamicfiltersselector3_Internalname, "Dynamic Filters Selector3", "gx-form-item AttributeLabel", 0, true, "width: 25%;");
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 85,'',false,'" + sGXsfl_110_idx + "',0)\"";
            /* ComboBox */
            GxWebStd.gx_combobox_ctrl1( context, cmbavDynamicfiltersselector3, cmbavDynamicfiltersselector3_Internalname, StringUtil.RTrim( AV25DynamicFiltersSelector3), 1, cmbavDynamicfiltersselector3_Jsonclick, 5, "'"+""+"'"+",false,"+"'"+"EVDYNAMICFILTERSSELECTOR3.CLICK."+"'", "svchar", "", 1, cmbavDynamicfiltersselector3.Enabled, 0, 0, 0, "em", 0, "", "", "Attribute", "", "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,85);\"", "", true, 1, "HLP_Configuracion\\ListaPreciosWW.htm");
            cmbavDynamicfiltersselector3.CurrentValue = StringUtil.RTrim( AV25DynamicFiltersSelector3);
            AssignProp("", false, cmbavDynamicfiltersselector3_Internalname, "Values", (string)(cmbavDynamicfiltersselector3.ToJavascriptSource()), true);
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "Invisible", "left", "top", "", "flex-grow:1;", "div");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblDynamicfiltersmiddle3_Internalname, "valor", "", "", lblDynamicfiltersmiddle3_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "DataFilterDescription", 0, "", 1, 1, 0, 0, "HLP_Configuracion\\ListaPreciosWW.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "Invisible", "left", "top", "", "flex-grow:1;", "div");
            wb_table4_89_1R2( true) ;
         }
         else
         {
            wb_table4_89_1R2( false) ;
         }
         return  ;
      }

      protected void wb_table4_89_1R2e( bool wbgen )
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
            wb_table1_25_1R2e( true) ;
         }
         else
         {
            wb_table1_25_1R2e( false) ;
         }
      }

      protected void wb_table4_89_1R2( bool wbgen )
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
            GxWebStd.gx_combobox_ctrl1( context, cmbavDynamicfiltersoperator3, cmbavDynamicfiltersoperator3_Internalname, StringUtil.Trim( StringUtil.Str( (decimal)(AV26DynamicFiltersOperator3), 4, 0)), 1, cmbavDynamicfiltersoperator3_Jsonclick, 0, "'"+""+"'"+",false,"+"'"+""+"'", "int", "", cmbavDynamicfiltersoperator3.Visible, cmbavDynamicfiltersoperator3.Enabled, 0, 0, 0, "em", 0, "", "", "Attribute", "", "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,93);\"", "", true, 1, "HLP_Configuracion\\ListaPreciosWW.htm");
            cmbavDynamicfiltersoperator3.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV26DynamicFiltersOperator3), 4, 0));
            AssignProp("", false, cmbavDynamicfiltersoperator3_Internalname, "Values", (string)(cmbavDynamicfiltersoperator3.ToJavascriptSource()), true);
            GxWebStd.gx_div_end( context, "left", "top", "div");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "<td id=\""+cellFilter_tiplproddsc3_cell_Internalname+"\"  class=''>") ;
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "left", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavTiplproddsc3_Internalname, "Tip LProd Dsc3", "gx-form-item AttributeLabel", 0, true, "width: 25%;");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 96,'',false,'" + sGXsfl_110_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavTiplproddsc3_Internalname, StringUtil.RTrim( AV27TipLProdDsc3), StringUtil.RTrim( context.localUtil.Format( AV27TipLProdDsc3, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,96);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavTiplproddsc3_Jsonclick, 0, "Attribute", "", "", "", "", edtavTiplproddsc3_Visible, edtavTiplproddsc3_Enabled, 0, "text", "", 80, "chr", 1, "row", 100, 0, 0, 0, 1, -1, -1, true, "", "left", true, "", "HLP_Configuracion\\ListaPreciosWW.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "<td id=\""+cellFilter_tipldsc3_cell_Internalname+"\"  class=''>") ;
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "left", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavTipldsc3_Internalname, "Tip LDsc3", "gx-form-item AttributeLabel", 0, true, "width: 25%;");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 99,'',false,'" + sGXsfl_110_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavTipldsc3_Internalname, StringUtil.RTrim( AV28TipLDsc3), StringUtil.RTrim( context.localUtil.Format( AV28TipLDsc3, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,99);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavTipldsc3_Jsonclick, 0, "Attribute", "", "", "", "", edtavTipldsc3_Visible, edtavTipldsc3_Enabled, 0, "text", "", 80, "chr", 1, "row", 100, 0, 0, 0, 1, -1, -1, true, "", "left", true, "", "HLP_Configuracion\\ListaPreciosWW.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "<td id=\""+cellDynamicfilters_removefilter3_cell_Internalname+"\"  class=''>") ;
            /* Active images/pictures */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 101,'',false,'',0)\"";
            ClassString = "Image";
            StyleString = "";
            sImgUrl = (string)(context.GetImagePath( "11a6ef14-1a5a-4077-91a2-f41ed9a3a662", "", context.GetTheme( )));
            GxWebStd.gx_bitmap( context, imgRemovedynamicfilters3_Internalname, sImgUrl, "", "", "", context.GetTheme( ), 1, 1, "", "Quitar filtro", 0, 0, 0, "px", 0, "px", 0, 0, 5, imgRemovedynamicfilters3_Jsonclick, "'"+""+"'"+",false,"+"'"+"E\\'REMOVEDYNAMICFILTERS3\\'."+"'", StyleString, ClassString, "", "", "", "", " "+"data-gx-image"+" "+TempTags, "", "", 1, false, false, context.GetImageSrcSet( sImgUrl), "HLP_Configuracion\\ListaPreciosWW.htm");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "</tr>") ;
            /* End of table */
            context.WriteHtmlText( "</table>") ;
            wb_table4_89_1R2e( true) ;
         }
         else
         {
            wb_table4_89_1R2e( false) ;
         }
      }

      protected void wb_table3_64_1R2( bool wbgen )
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
            GxWebStd.gx_combobox_ctrl1( context, cmbavDynamicfiltersoperator2, cmbavDynamicfiltersoperator2_Internalname, StringUtil.Trim( StringUtil.Str( (decimal)(AV21DynamicFiltersOperator2), 4, 0)), 1, cmbavDynamicfiltersoperator2_Jsonclick, 0, "'"+""+"'"+",false,"+"'"+""+"'", "int", "", cmbavDynamicfiltersoperator2.Visible, cmbavDynamicfiltersoperator2.Enabled, 0, 0, 0, "em", 0, "", "", "Attribute", "", "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,68);\"", "", true, 1, "HLP_Configuracion\\ListaPreciosWW.htm");
            cmbavDynamicfiltersoperator2.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV21DynamicFiltersOperator2), 4, 0));
            AssignProp("", false, cmbavDynamicfiltersoperator2_Internalname, "Values", (string)(cmbavDynamicfiltersoperator2.ToJavascriptSource()), true);
            GxWebStd.gx_div_end( context, "left", "top", "div");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "<td id=\""+cellFilter_tiplproddsc2_cell_Internalname+"\"  class=''>") ;
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "left", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavTiplproddsc2_Internalname, "Tip LProd Dsc2", "gx-form-item AttributeLabel", 0, true, "width: 25%;");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 71,'',false,'" + sGXsfl_110_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavTiplproddsc2_Internalname, StringUtil.RTrim( AV22TipLProdDsc2), StringUtil.RTrim( context.localUtil.Format( AV22TipLProdDsc2, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,71);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavTiplproddsc2_Jsonclick, 0, "Attribute", "", "", "", "", edtavTiplproddsc2_Visible, edtavTiplproddsc2_Enabled, 0, "text", "", 80, "chr", 1, "row", 100, 0, 0, 0, 1, -1, -1, true, "", "left", true, "", "HLP_Configuracion\\ListaPreciosWW.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "<td id=\""+cellFilter_tipldsc2_cell_Internalname+"\"  class=''>") ;
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "left", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavTipldsc2_Internalname, "Tip LDsc2", "gx-form-item AttributeLabel", 0, true, "width: 25%;");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 74,'',false,'" + sGXsfl_110_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavTipldsc2_Internalname, StringUtil.RTrim( AV23TipLDsc2), StringUtil.RTrim( context.localUtil.Format( AV23TipLDsc2, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,74);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavTipldsc2_Jsonclick, 0, "Attribute", "", "", "", "", edtavTipldsc2_Visible, edtavTipldsc2_Enabled, 0, "text", "", 80, "chr", 1, "row", 100, 0, 0, 0, 1, -1, -1, true, "", "left", true, "", "HLP_Configuracion\\ListaPreciosWW.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "<td id=\""+cellDynamicfilters_addfilter2_cell_Internalname+"\"  class=''>") ;
            /* Active images/pictures */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 76,'',false,'',0)\"";
            ClassString = "Image";
            StyleString = "";
            sImgUrl = (string)(context.GetImagePath( "27283ea5-332f-423b-b880-64b762622df3", "", context.GetTheme( )));
            GxWebStd.gx_bitmap( context, imgAdddynamicfilters2_Internalname, sImgUrl, "", "", "", context.GetTheme( ), imgAdddynamicfilters2_Visible, 1, "", "Agregar filtro", 0, 0, 0, "px", 0, "px", 0, 0, 5, imgAdddynamicfilters2_Jsonclick, "'"+""+"'"+",false,"+"'"+"E\\'ADDDYNAMICFILTERS2\\'."+"'", StyleString, ClassString, "", "", "", "", " "+"data-gx-image"+" "+TempTags, "", "", 1, false, false, context.GetImageSrcSet( sImgUrl), "HLP_Configuracion\\ListaPreciosWW.htm");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "<td id=\""+cellDynamicfilters_removefilter2_cell_Internalname+"\"  class=''>") ;
            /* Active images/pictures */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 78,'',false,'',0)\"";
            ClassString = "Image";
            StyleString = "";
            sImgUrl = (string)(context.GetImagePath( "11a6ef14-1a5a-4077-91a2-f41ed9a3a662", "", context.GetTheme( )));
            GxWebStd.gx_bitmap( context, imgRemovedynamicfilters2_Internalname, sImgUrl, "", "", "", context.GetTheme( ), imgRemovedynamicfilters2_Visible, 1, "", "Quitar filtro", 0, 0, 0, "px", 0, "px", 0, 0, 5, imgRemovedynamicfilters2_Jsonclick, "'"+""+"'"+",false,"+"'"+"E\\'REMOVEDYNAMICFILTERS2\\'."+"'", StyleString, ClassString, "", "", "", "", " "+"data-gx-image"+" "+TempTags, "", "", 1, false, false, context.GetImageSrcSet( sImgUrl), "HLP_Configuracion\\ListaPreciosWW.htm");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "</tr>") ;
            /* End of table */
            context.WriteHtmlText( "</table>") ;
            wb_table3_64_1R2e( true) ;
         }
         else
         {
            wb_table3_64_1R2e( false) ;
         }
      }

      protected void wb_table2_39_1R2( bool wbgen )
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
            GxWebStd.gx_combobox_ctrl1( context, cmbavDynamicfiltersoperator1, cmbavDynamicfiltersoperator1_Internalname, StringUtil.Trim( StringUtil.Str( (decimal)(AV16DynamicFiltersOperator1), 4, 0)), 1, cmbavDynamicfiltersoperator1_Jsonclick, 0, "'"+""+"'"+",false,"+"'"+""+"'", "int", "", cmbavDynamicfiltersoperator1.Visible, cmbavDynamicfiltersoperator1.Enabled, 0, 0, 0, "em", 0, "", "", "Attribute", "", "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,43);\"", "", true, 1, "HLP_Configuracion\\ListaPreciosWW.htm");
            cmbavDynamicfiltersoperator1.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV16DynamicFiltersOperator1), 4, 0));
            AssignProp("", false, cmbavDynamicfiltersoperator1_Internalname, "Values", (string)(cmbavDynamicfiltersoperator1.ToJavascriptSource()), true);
            GxWebStd.gx_div_end( context, "left", "top", "div");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "<td id=\""+cellFilter_tiplproddsc1_cell_Internalname+"\"  class=''>") ;
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "left", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavTiplproddsc1_Internalname, "Tip LProd Dsc1", "gx-form-item AttributeLabel", 0, true, "width: 25%;");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 46,'',false,'" + sGXsfl_110_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavTiplproddsc1_Internalname, StringUtil.RTrim( AV17TipLProdDsc1), StringUtil.RTrim( context.localUtil.Format( AV17TipLProdDsc1, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,46);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavTiplproddsc1_Jsonclick, 0, "Attribute", "", "", "", "", edtavTiplproddsc1_Visible, edtavTiplproddsc1_Enabled, 0, "text", "", 80, "chr", 1, "row", 100, 0, 0, 0, 1, -1, -1, true, "", "left", true, "", "HLP_Configuracion\\ListaPreciosWW.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "<td id=\""+cellFilter_tipldsc1_cell_Internalname+"\"  class=''>") ;
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "left", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavTipldsc1_Internalname, "Tip LDsc1", "gx-form-item AttributeLabel", 0, true, "width: 25%;");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 49,'',false,'" + sGXsfl_110_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavTipldsc1_Internalname, StringUtil.RTrim( AV18TipLDsc1), StringUtil.RTrim( context.localUtil.Format( AV18TipLDsc1, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,49);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavTipldsc1_Jsonclick, 0, "Attribute", "", "", "", "", edtavTipldsc1_Visible, edtavTipldsc1_Enabled, 0, "text", "", 80, "chr", 1, "row", 100, 0, 0, 0, 1, -1, -1, true, "", "left", true, "", "HLP_Configuracion\\ListaPreciosWW.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "<td id=\""+cellDynamicfilters_addfilter1_cell_Internalname+"\"  class=''>") ;
            /* Active images/pictures */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 51,'',false,'',0)\"";
            ClassString = "Image";
            StyleString = "";
            sImgUrl = (string)(context.GetImagePath( "27283ea5-332f-423b-b880-64b762622df3", "", context.GetTheme( )));
            GxWebStd.gx_bitmap( context, imgAdddynamicfilters1_Internalname, sImgUrl, "", "", "", context.GetTheme( ), imgAdddynamicfilters1_Visible, 1, "", "Agregar filtro", 0, 0, 0, "px", 0, "px", 0, 0, 5, imgAdddynamicfilters1_Jsonclick, "'"+""+"'"+",false,"+"'"+"E\\'ADDDYNAMICFILTERS1\\'."+"'", StyleString, ClassString, "", "", "", "", " "+"data-gx-image"+" "+TempTags, "", "", 1, false, false, context.GetImageSrcSet( sImgUrl), "HLP_Configuracion\\ListaPreciosWW.htm");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "<td id=\""+cellDynamicfilters_removefilter1_cell_Internalname+"\"  class=''>") ;
            /* Active images/pictures */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 53,'',false,'',0)\"";
            ClassString = "Image";
            StyleString = "";
            sImgUrl = (string)(context.GetImagePath( "11a6ef14-1a5a-4077-91a2-f41ed9a3a662", "", context.GetTheme( )));
            GxWebStd.gx_bitmap( context, imgRemovedynamicfilters1_Internalname, sImgUrl, "", "", "", context.GetTheme( ), imgRemovedynamicfilters1_Visible, 1, "", "Quitar filtro", 0, 0, 0, "px", 0, "px", 0, 0, 5, imgRemovedynamicfilters1_Jsonclick, "'"+""+"'"+",false,"+"'"+"E\\'REMOVEDYNAMICFILTERS1\\'."+"'", StyleString, ClassString, "", "", "", "", " "+"data-gx-image"+" "+TempTags, "", "", 1, false, false, context.GetImageSrcSet( sImgUrl), "HLP_Configuracion\\ListaPreciosWW.htm");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "</tr>") ;
            /* End of table */
            context.WriteHtmlText( "</table>") ;
            wb_table2_39_1R2e( true) ;
         }
         else
         {
            wb_table2_39_1R2e( false) ;
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
         PA1R2( ) ;
         WS1R2( ) ;
         WE1R2( ) ;
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
         AddStyleSheetFile("DVelop/Shared/daterangepicker/daterangepicker.css", "");
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
            context.AddJavascriptSource(StringUtil.RTrim( ((string)Form.Jscriptsrc.Item(idxLst))), "?202281810295480", true, true);
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
         context.AddJavascriptSource("configuracion/listapreciosww.js", "?202281810295481", false, true);
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
         context.AddJavascriptSource("DVelop/Shared/daterangepicker/locales.js", "", false, true);
         context.AddJavascriptSource("DVelop/Shared/daterangepicker/wwp-daterangepicker.js", "", false, true);
         context.AddJavascriptSource("DVelop/Shared/daterangepicker/moment.min.js", "", false, true);
         context.AddJavascriptSource("DVelop/Shared/daterangepicker/daterangepicker.min.js", "", false, true);
         context.AddJavascriptSource("DVelop/Shared/WorkWithPlusCommon.js", "", false, true);
         context.AddJavascriptSource("DVelop/DateRangePicker/DateRangePickerRender.js", "", false, true);
         /* End function include_jscripts */
      }

      protected void SubsflControlProps_1102( )
      {
         cmbavGridactions_Internalname = "vGRIDACTIONS_"+sGXsfl_110_idx;
         edtTipLCod_Internalname = "TIPLCOD_"+sGXsfl_110_idx;
         edtTipLItem_Internalname = "TIPLITEM_"+sGXsfl_110_idx;
         edtTipLDsc_Internalname = "TIPLDSC_"+sGXsfl_110_idx;
         edtProdCod_Internalname = "PRODCOD_"+sGXsfl_110_idx;
         edtTipLProdDsc_Internalname = "TIPLPRODDSC_"+sGXsfl_110_idx;
         edtCliCod_Internalname = "CLICOD_"+sGXsfl_110_idx;
         edtPreLis_Internalname = "PRELIS_"+sGXsfl_110_idx;
         edtLisFech_Internalname = "LISFECH_"+sGXsfl_110_idx;
         edtCliDsc_Internalname = "CLIDSC_"+sGXsfl_110_idx;
         edtPreLisCred_Internalname = "PRELISCRED_"+sGXsfl_110_idx;
      }

      protected void SubsflControlProps_fel_1102( )
      {
         cmbavGridactions_Internalname = "vGRIDACTIONS_"+sGXsfl_110_fel_idx;
         edtTipLCod_Internalname = "TIPLCOD_"+sGXsfl_110_fel_idx;
         edtTipLItem_Internalname = "TIPLITEM_"+sGXsfl_110_fel_idx;
         edtTipLDsc_Internalname = "TIPLDSC_"+sGXsfl_110_fel_idx;
         edtProdCod_Internalname = "PRODCOD_"+sGXsfl_110_fel_idx;
         edtTipLProdDsc_Internalname = "TIPLPRODDSC_"+sGXsfl_110_fel_idx;
         edtCliCod_Internalname = "CLICOD_"+sGXsfl_110_fel_idx;
         edtPreLis_Internalname = "PRELIS_"+sGXsfl_110_fel_idx;
         edtLisFech_Internalname = "LISFECH_"+sGXsfl_110_fel_idx;
         edtCliDsc_Internalname = "CLIDSC_"+sGXsfl_110_fel_idx;
         edtPreLisCred_Internalname = "PRELISCRED_"+sGXsfl_110_fel_idx;
      }

      protected void sendrow_1102( )
      {
         SubsflControlProps_1102( ) ;
         WB1R0( ) ;
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
                  AV62GridActions = (short)(NumberUtil.Val( cmbavGridactions.getValidValue(StringUtil.Trim( StringUtil.Str( (decimal)(AV62GridActions), 4, 0))), "."));
                  AssignAttri("", false, cmbavGridactions_Internalname, StringUtil.LTrimStr( (decimal)(AV62GridActions), 4, 0));
               }
            }
            /* ComboBox */
            GridRow.AddColumnProperties("combobox", 2, isAjaxCallMode( ), new Object[] {(GXCombobox)cmbavGridactions,(string)cmbavGridactions_Internalname,StringUtil.Trim( StringUtil.Str( (decimal)(AV62GridActions), 4, 0)),(short)1,(string)cmbavGridactions_Jsonclick,(short)5,"'"+""+"'"+",false,"+"'"+"EVGRIDACTIONS.CLICK."+sGXsfl_110_idx+"'",(string)"int",(string)"",(short)-1,(short)1,(short)0,(short)0,(short)0,(string)"px",(short)0,(string)"px",(string)"",(string)"ConvertToDDO",(string)"WWActionGroupColumn",(string)"",TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+((cmbavGridactions.Enabled!=0)&&(cmbavGridactions.Visible!=0) ? " onblur=\""+""+";gx.evt.onblur(this,111);\"" : " "),(string)"",(bool)true,(short)1});
            cmbavGridactions.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV62GridActions), 4, 0));
            AssignProp("", false, cmbavGridactions_Internalname, "Values", (string)(cmbavGridactions.ToJavascriptSource()), !bGXsfl_110_Refreshing);
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"right"+"\""+" style=\""+"display:none;"+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtTipLCod_Internalname,StringUtil.LTrim( StringUtil.NToC( (decimal)(A202TipLCod), 6, 0, ".", "")),StringUtil.LTrim( context.localUtil.Format( (decimal)(A202TipLCod), "ZZZZZ9")),(string)" inputmode=\"numeric\" pattern=\"[0-9]*\""+"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtTipLCod_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn hidden-xs",(string)"",(short)0,(short)0,(short)0,(string)"text",(string)"1",(short)0,(string)"px",(short)17,(string)"px",(short)6,(short)0,(short)0,(short)110,(short)1,(short)-1,(short)0,(bool)true,(string)"",(string)"right",(bool)false,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"right"+"\""+" style=\""+"display:none;"+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtTipLItem_Internalname,StringUtil.LTrim( StringUtil.NToC( (decimal)(A203TipLItem), 6, 0, ".", "")),StringUtil.LTrim( context.localUtil.Format( (decimal)(A203TipLItem), "ZZZZZ9")),(string)" inputmode=\"numeric\" pattern=\"[0-9]*\""+"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtTipLItem_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn hidden-xs",(string)"",(short)0,(short)0,(short)0,(string)"text",(string)"1",(short)0,(string)"px",(short)17,(string)"px",(short)6,(short)0,(short)0,(short)110,(short)1,(short)-1,(short)0,(bool)true,(string)"",(string)"right",(bool)false,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"left"+"\""+" style=\""+""+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtTipLDsc_Internalname,StringUtil.RTrim( A1912TipLDsc),(string)"",(string)"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)edtTipLDsc_Link,(string)"",(string)"",(string)"",(string)edtTipLDsc_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn hidden-xs",(string)"",(short)-1,(short)0,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)100,(short)0,(short)0,(short)110,(short)1,(short)-1,(short)-1,(bool)true,(string)"",(string)"left",(bool)true,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"left"+"\""+" style=\""+""+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtProdCod_Internalname,StringUtil.RTrim( A28ProdCod),StringUtil.RTrim( context.localUtil.Format( A28ProdCod, "@!")),(string)"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtProdCod_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn hidden-xs",(string)"",(short)-1,(short)0,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)15,(short)0,(short)0,(short)110,(short)1,(short)-1,(short)-1,(bool)true,(string)"",(string)"left",(bool)true,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"left"+"\""+" style=\""+""+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtTipLProdDsc_Internalname,StringUtil.RTrim( A1913TipLProdDsc),(string)"",(string)"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)edtTipLProdDsc_Link,(string)"",(string)"",(string)"",(string)edtTipLProdDsc_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn",(string)"",(short)-1,(short)0,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)100,(short)0,(short)0,(short)110,(short)1,(short)-1,(short)-1,(bool)true,(string)"",(string)"left",(bool)true,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"left"+"\""+" style=\""+""+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtCliCod_Internalname,StringUtil.RTrim( A45CliCod),(string)"",(string)"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtCliCod_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn hidden-xs",(string)"",(short)-1,(short)0,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)20,(short)0,(short)0,(short)110,(short)1,(short)-1,(short)-1,(bool)true,(string)"",(string)"left",(bool)true,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"right"+"\""+" style=\""+""+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtPreLis_Internalname,StringUtil.LTrim( StringUtil.NToC( A1651PreLis, 17, 4, ".", "")),StringUtil.LTrim( context.localUtil.Format( A1651PreLis, "ZZZZ,ZZZ,ZZ9.9999")),(string)"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtPreLis_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn hidden-xs",(string)"",(short)-1,(short)0,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)17,(short)0,(short)0,(short)110,(short)1,(short)-1,(short)0,(bool)true,(string)"CantidadPrecio",(string)"right",(bool)false,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"right"+"\""+" style=\""+""+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtLisFech_Internalname,context.localUtil.Format(A1205LisFech, "99/99/99"),context.localUtil.Format( A1205LisFech, "99/99/99"),(string)"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtLisFech_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn hidden-xs",(string)"",(short)-1,(short)0,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)8,(short)0,(short)0,(short)110,(short)1,(short)-1,(short)0,(bool)true,(string)"",(string)"right",(bool)false,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"left"+"\""+" style=\""+"display:none;"+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtCliDsc_Internalname,StringUtil.RTrim( A161CliDsc),(string)"",(string)"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtCliDsc_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn hidden-xs",(string)"",(short)0,(short)0,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)100,(short)0,(short)0,(short)110,(short)1,(short)-1,(short)-1,(bool)true,(string)"",(string)"left",(bool)true,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"right"+"\""+" style=\""+"display:none;"+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtPreLisCred_Internalname,StringUtil.LTrim( StringUtil.NToC( A1652PreLisCred, 17, 4, ".", "")),StringUtil.LTrim( context.localUtil.Format( A1652PreLisCred, "ZZZZ,ZZZ,ZZ9.9999")),(string)"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtPreLisCred_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn hidden-xs",(string)"",(short)0,(short)0,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)17,(short)0,(short)0,(short)110,(short)1,(short)-1,(short)0,(bool)true,(string)"CantidadPrecio",(string)"right",(bool)false,(string)""});
            send_integrity_lvl_hashes1R2( ) ;
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
         cmbavDynamicfiltersselector1.addItem("TIPLPRODDSC", "Producto", 0);
         cmbavDynamicfiltersselector1.addItem("TIPLDSC", "Tipo de Lista", 0);
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
         cmbavDynamicfiltersselector2.addItem("TIPLPRODDSC", "Producto", 0);
         cmbavDynamicfiltersselector2.addItem("TIPLDSC", "Tipo de Lista", 0);
         if ( cmbavDynamicfiltersselector2.ItemCount > 0 )
         {
            AV20DynamicFiltersSelector2 = cmbavDynamicfiltersselector2.getValidValue(AV20DynamicFiltersSelector2);
            AssignAttri("", false, "AV20DynamicFiltersSelector2", AV20DynamicFiltersSelector2);
         }
         cmbavDynamicfiltersoperator2.Name = "vDYNAMICFILTERSOPERATOR2";
         cmbavDynamicfiltersoperator2.WebTags = "";
         cmbavDynamicfiltersoperator2.addItem("0", "Comienza con", 0);
         cmbavDynamicfiltersoperator2.addItem("1", "Contiene", 0);
         if ( cmbavDynamicfiltersoperator2.ItemCount > 0 )
         {
            AV21DynamicFiltersOperator2 = (short)(NumberUtil.Val( cmbavDynamicfiltersoperator2.getValidValue(StringUtil.Trim( StringUtil.Str( (decimal)(AV21DynamicFiltersOperator2), 4, 0))), "."));
            AssignAttri("", false, "AV21DynamicFiltersOperator2", StringUtil.LTrimStr( (decimal)(AV21DynamicFiltersOperator2), 4, 0));
         }
         cmbavDynamicfiltersselector3.Name = "vDYNAMICFILTERSSELECTOR3";
         cmbavDynamicfiltersselector3.WebTags = "";
         cmbavDynamicfiltersselector3.addItem("TIPLPRODDSC", "Producto", 0);
         cmbavDynamicfiltersselector3.addItem("TIPLDSC", "Tipo de Lista", 0);
         if ( cmbavDynamicfiltersselector3.ItemCount > 0 )
         {
            AV25DynamicFiltersSelector3 = cmbavDynamicfiltersselector3.getValidValue(AV25DynamicFiltersSelector3);
            AssignAttri("", false, "AV25DynamicFiltersSelector3", AV25DynamicFiltersSelector3);
         }
         cmbavDynamicfiltersoperator3.Name = "vDYNAMICFILTERSOPERATOR3";
         cmbavDynamicfiltersoperator3.WebTags = "";
         cmbavDynamicfiltersoperator3.addItem("0", "Comienza con", 0);
         cmbavDynamicfiltersoperator3.addItem("1", "Contiene", 0);
         if ( cmbavDynamicfiltersoperator3.ItemCount > 0 )
         {
            AV26DynamicFiltersOperator3 = (short)(NumberUtil.Val( cmbavDynamicfiltersoperator3.getValidValue(StringUtil.Trim( StringUtil.Str( (decimal)(AV26DynamicFiltersOperator3), 4, 0))), "."));
            AssignAttri("", false, "AV26DynamicFiltersOperator3", StringUtil.LTrimStr( (decimal)(AV26DynamicFiltersOperator3), 4, 0));
         }
         GXCCtl = "vGRIDACTIONS_" + sGXsfl_110_idx;
         cmbavGridactions.Name = GXCCtl;
         cmbavGridactions.WebTags = "";
         if ( cmbavGridactions.ItemCount > 0 )
         {
            AV62GridActions = (short)(NumberUtil.Val( cmbavGridactions.getValidValue(StringUtil.Trim( StringUtil.Str( (decimal)(AV62GridActions), 4, 0))), "."));
            AssignAttri("", false, cmbavGridactions_Internalname, StringUtil.LTrimStr( (decimal)(AV62GridActions), 4, 0));
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
         edtavTiplproddsc1_Internalname = "vTIPLPRODDSC1";
         cellFilter_tiplproddsc1_cell_Internalname = "FILTER_TIPLPRODDSC1_CELL";
         edtavTipldsc1_Internalname = "vTIPLDSC1";
         cellFilter_tipldsc1_cell_Internalname = "FILTER_TIPLDSC1_CELL";
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
         edtavTiplproddsc2_Internalname = "vTIPLPRODDSC2";
         cellFilter_tiplproddsc2_cell_Internalname = "FILTER_TIPLPRODDSC2_CELL";
         edtavTipldsc2_Internalname = "vTIPLDSC2";
         cellFilter_tipldsc2_cell_Internalname = "FILTER_TIPLDSC2_CELL";
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
         edtavTiplproddsc3_Internalname = "vTIPLPRODDSC3";
         cellFilter_tiplproddsc3_cell_Internalname = "FILTER_TIPLPRODDSC3_CELL";
         edtavTipldsc3_Internalname = "vTIPLDSC3";
         cellFilter_tipldsc3_cell_Internalname = "FILTER_TIPLDSC3_CELL";
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
         edtTipLCod_Internalname = "TIPLCOD";
         edtTipLItem_Internalname = "TIPLITEM";
         edtTipLDsc_Internalname = "TIPLDSC";
         edtProdCod_Internalname = "PRODCOD";
         edtTipLProdDsc_Internalname = "TIPLPRODDSC";
         edtCliCod_Internalname = "CLICOD";
         edtPreLis_Internalname = "PRELIS";
         edtLisFech_Internalname = "LISFECH";
         edtCliDsc_Internalname = "CLIDSC";
         edtPreLisCred_Internalname = "PRELISCRED";
         Gridpaginationbar_Internalname = "GRIDPAGINATIONBAR";
         divGridtablewithpaginationbar_Internalname = "GRIDTABLEWITHPAGINATIONBAR";
         divTablemain_Internalname = "TABLEMAIN";
         Ddo_agexport_Internalname = "DDO_AGEXPORT";
         lblJsdynamicfilters_Internalname = "JSDYNAMICFILTERS";
         Ddo_grid_Internalname = "DDO_GRID";
         Innewwindow1_Internalname = "INNEWWINDOW1";
         Grid_empowerer_Internalname = "GRID_EMPOWERER";
         edtavDdo_lisfechauxdatetext_Internalname = "vDDO_LISFECHAUXDATETEXT";
         Tflisfech_rangepicker_Internalname = "TFLISFECH_RANGEPICKER";
         divDdo_lisfechauxdates_Internalname = "DDO_LISFECHAUXDATES";
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
         edtPreLisCred_Jsonclick = "";
         edtCliDsc_Jsonclick = "";
         edtLisFech_Jsonclick = "";
         edtPreLis_Jsonclick = "";
         edtCliCod_Jsonclick = "";
         edtTipLProdDsc_Jsonclick = "";
         edtProdCod_Jsonclick = "";
         edtTipLDsc_Jsonclick = "";
         edtTipLItem_Jsonclick = "";
         edtTipLCod_Jsonclick = "";
         cmbavGridactions_Jsonclick = "";
         cmbavGridactions.Visible = -1;
         cmbavGridactions.Enabled = 1;
         imgRemovedynamicfilters1_Visible = 1;
         imgAdddynamicfilters1_Visible = 1;
         edtavTipldsc1_Jsonclick = "";
         edtavTipldsc1_Enabled = 1;
         edtavTiplproddsc1_Jsonclick = "";
         edtavTiplproddsc1_Enabled = 1;
         cmbavDynamicfiltersoperator1_Jsonclick = "";
         cmbavDynamicfiltersoperator1.Enabled = 1;
         imgRemovedynamicfilters2_Visible = 1;
         imgAdddynamicfilters2_Visible = 1;
         edtavTipldsc2_Jsonclick = "";
         edtavTipldsc2_Enabled = 1;
         edtavTiplproddsc2_Jsonclick = "";
         edtavTiplproddsc2_Enabled = 1;
         cmbavDynamicfiltersoperator2_Jsonclick = "";
         cmbavDynamicfiltersoperator2.Enabled = 1;
         edtavTipldsc3_Jsonclick = "";
         edtavTipldsc3_Enabled = 1;
         edtavTiplproddsc3_Jsonclick = "";
         edtavTiplproddsc3_Enabled = 1;
         cmbavDynamicfiltersoperator3_Jsonclick = "";
         cmbavDynamicfiltersoperator3.Enabled = 1;
         cmbavDynamicfiltersselector3_Jsonclick = "";
         cmbavDynamicfiltersselector3.Enabled = 1;
         cmbavDynamicfiltersselector2_Jsonclick = "";
         cmbavDynamicfiltersselector2.Enabled = 1;
         cmbavDynamicfiltersselector1_Jsonclick = "";
         cmbavDynamicfiltersselector1.Enabled = 1;
         cmbavDynamicfiltersoperator3.Visible = 1;
         edtavTipldsc3_Visible = 1;
         edtavTiplproddsc3_Visible = 1;
         cmbavDynamicfiltersoperator2.Visible = 1;
         edtavTipldsc2_Visible = 1;
         edtavTiplproddsc2_Visible = 1;
         cmbavDynamicfiltersoperator1.Visible = 1;
         edtavTipldsc1_Visible = 1;
         edtavTiplproddsc1_Visible = 1;
         edtavDdo_lisfechauxdatetext_Jsonclick = "";
         lblJsdynamicfilters_Caption = "JSDynamicFilters";
         subGrid_Allowcollapsing = 0;
         subGrid_Allowselection = 0;
         edtTipLProdDsc_Link = "";
         edtTipLDsc_Link = "";
         subGrid_Sortable = 0;
         subGrid_Header = "";
         subGrid_Class = "GridWithPaginationBar WorkWith";
         subGrid_Backcolorstyle = 0;
         Grid_empowerer_Hastitlesettings = Convert.ToBoolean( -1);
         Innewwindow1_Target = "";
         Innewwindow1_Height = "50";
         Innewwindow1_Width = "50";
         Ddo_grid_Datalistproc = "Configuracion.ListaPreciosWWGetFilterData";
         Ddo_grid_Datalisttype = "Dynamic|Dynamic|Dynamic|Dynamic||";
         Ddo_grid_Includedatalist = "T|T|T|T||";
         Ddo_grid_Filterisrange = "||||T|P";
         Ddo_grid_Filtertype = "Character|Character|Character|Character|Numeric|Date";
         Ddo_grid_Includefilter = "T";
         Ddo_grid_Includesortasc = "T";
         Ddo_grid_Columnssortvalues = "2|3|4|5|6|7";
         Ddo_grid_Columnids = "3:TipLDsc|4:ProdCod|5:TipLProdDsc|6:CliCod|7:PreLis|8:LisFech";
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
         Form.Caption = " Lista de Precios";
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
         setEventMetadata("REFRESH","{handler:'Refresh',iparms:[{av:'GRID_nFirstRecordOnPage'},{av:'GRID_nEOF'},{av:'cmbavDynamicfiltersselector1'},{av:'AV15DynamicFiltersSelector1',fld:'vDYNAMICFILTERSSELECTOR1',pic:''},{av:'AV19DynamicFiltersEnabled2',fld:'vDYNAMICFILTERSENABLED2',pic:''},{av:'cmbavDynamicfiltersselector2'},{av:'AV20DynamicFiltersSelector2',fld:'vDYNAMICFILTERSSELECTOR2',pic:''},{av:'AV24DynamicFiltersEnabled3',fld:'vDYNAMICFILTERSENABLED3',pic:''},{av:'cmbavDynamicfiltersselector3'},{av:'AV25DynamicFiltersSelector3',fld:'vDYNAMICFILTERSSELECTOR3',pic:''},{av:'subGrid_Rows',ctrl:'GRID',prop:'Rows'},{av:'cmbavDynamicfiltersoperator1'},{av:'AV16DynamicFiltersOperator1',fld:'vDYNAMICFILTERSOPERATOR1',pic:'ZZZ9'},{av:'AV17TipLProdDsc1',fld:'vTIPLPRODDSC1',pic:''},{av:'AV18TipLDsc1',fld:'vTIPLDSC1',pic:''},{av:'cmbavDynamicfiltersoperator2'},{av:'AV21DynamicFiltersOperator2',fld:'vDYNAMICFILTERSOPERATOR2',pic:'ZZZ9'},{av:'AV22TipLProdDsc2',fld:'vTIPLPRODDSC2',pic:''},{av:'AV23TipLDsc2',fld:'vTIPLDSC2',pic:''},{av:'cmbavDynamicfiltersoperator3'},{av:'AV26DynamicFiltersOperator3',fld:'vDYNAMICFILTERSOPERATOR3',pic:'ZZZ9'},{av:'AV27TipLProdDsc3',fld:'vTIPLPRODDSC3',pic:''},{av:'AV28TipLDsc3',fld:'vTIPLDSC3',pic:''},{av:'AV67Pgmname',fld:'vPGMNAME',pic:'',hsh:true},{av:'AV42TFTipLDsc',fld:'vTFTIPLDSC',pic:''},{av:'AV43TFTipLDsc_Sel',fld:'vTFTIPLDSC_SEL',pic:''},{av:'AV38TFProdCod',fld:'vTFPRODCOD',pic:'@!'},{av:'AV39TFProdCod_Sel',fld:'vTFPRODCOD_SEL',pic:'@!'},{av:'AV40TFTipLProdDsc',fld:'vTFTIPLPRODDSC',pic:''},{av:'AV41TFTipLProdDsc_Sel',fld:'vTFTIPLPRODDSC_SEL',pic:''},{av:'AV46TFCliCod',fld:'vTFCLICOD',pic:''},{av:'AV47TFCliCod_Sel',fld:'vTFCLICOD_SEL',pic:''},{av:'AV44TFPreLis',fld:'vTFPRELIS',pic:'ZZZZ,ZZZ,ZZ9.9999'},{av:'AV45TFPreLis_To',fld:'vTFPRELIS_TO',pic:'ZZZZ,ZZZ,ZZ9.9999'},{av:'AV50TFLisFech',fld:'vTFLISFECH',pic:''},{av:'AV51TFLisFech_To',fld:'vTFLISFECH_TO',pic:''},{av:'AV13OrderedBy',fld:'vORDEREDBY',pic:'ZZZ9'},{av:'AV14OrderedDsc',fld:'vORDEREDDSC',pic:''},{av:'AV10GridState',fld:'vGRIDSTATE',pic:''},{av:'AV30DynamicFiltersIgnoreFirst',fld:'vDYNAMICFILTERSIGNOREFIRST',pic:''},{av:'AV29DynamicFiltersRemoving',fld:'vDYNAMICFILTERSREMOVING',pic:''}]");
         setEventMetadata("REFRESH",",oparms:[{av:'cmbavDynamicfiltersoperator1'},{av:'AV16DynamicFiltersOperator1',fld:'vDYNAMICFILTERSOPERATOR1',pic:'ZZZ9'},{av:'cmbavDynamicfiltersoperator2'},{av:'AV21DynamicFiltersOperator2',fld:'vDYNAMICFILTERSOPERATOR2',pic:'ZZZ9'},{av:'cmbavDynamicfiltersoperator3'},{av:'AV26DynamicFiltersOperator3',fld:'vDYNAMICFILTERSOPERATOR3',pic:'ZZZ9'},{av:'AV59GridCurrentPage',fld:'vGRIDCURRENTPAGE',pic:'ZZZZZZZZZ9'},{av:'AV60GridPageCount',fld:'vGRIDPAGECOUNT',pic:'ZZZZZZZZZ9'},{av:'AV61GridAppliedFilters',fld:'vGRIDAPPLIEDFILTERS',pic:''},{av:'AV10GridState',fld:'vGRIDSTATE',pic:''}]}");
         setEventMetadata("GRIDPAGINATIONBAR.CHANGEPAGE","{handler:'E111R2',iparms:[{av:'GRID_nFirstRecordOnPage'},{av:'GRID_nEOF'},{av:'subGrid_Rows',ctrl:'GRID',prop:'Rows'},{av:'cmbavDynamicfiltersselector1'},{av:'AV15DynamicFiltersSelector1',fld:'vDYNAMICFILTERSSELECTOR1',pic:''},{av:'cmbavDynamicfiltersoperator1'},{av:'AV16DynamicFiltersOperator1',fld:'vDYNAMICFILTERSOPERATOR1',pic:'ZZZ9'},{av:'AV17TipLProdDsc1',fld:'vTIPLPRODDSC1',pic:''},{av:'AV18TipLDsc1',fld:'vTIPLDSC1',pic:''},{av:'cmbavDynamicfiltersselector2'},{av:'AV20DynamicFiltersSelector2',fld:'vDYNAMICFILTERSSELECTOR2',pic:''},{av:'cmbavDynamicfiltersoperator2'},{av:'AV21DynamicFiltersOperator2',fld:'vDYNAMICFILTERSOPERATOR2',pic:'ZZZ9'},{av:'AV22TipLProdDsc2',fld:'vTIPLPRODDSC2',pic:''},{av:'AV23TipLDsc2',fld:'vTIPLDSC2',pic:''},{av:'cmbavDynamicfiltersselector3'},{av:'AV25DynamicFiltersSelector3',fld:'vDYNAMICFILTERSSELECTOR3',pic:''},{av:'cmbavDynamicfiltersoperator3'},{av:'AV26DynamicFiltersOperator3',fld:'vDYNAMICFILTERSOPERATOR3',pic:'ZZZ9'},{av:'AV27TipLProdDsc3',fld:'vTIPLPRODDSC3',pic:''},{av:'AV28TipLDsc3',fld:'vTIPLDSC3',pic:''},{av:'AV19DynamicFiltersEnabled2',fld:'vDYNAMICFILTERSENABLED2',pic:''},{av:'AV24DynamicFiltersEnabled3',fld:'vDYNAMICFILTERSENABLED3',pic:''},{av:'AV67Pgmname',fld:'vPGMNAME',pic:'',hsh:true},{av:'AV42TFTipLDsc',fld:'vTFTIPLDSC',pic:''},{av:'AV43TFTipLDsc_Sel',fld:'vTFTIPLDSC_SEL',pic:''},{av:'AV38TFProdCod',fld:'vTFPRODCOD',pic:'@!'},{av:'AV39TFProdCod_Sel',fld:'vTFPRODCOD_SEL',pic:'@!'},{av:'AV40TFTipLProdDsc',fld:'vTFTIPLPRODDSC',pic:''},{av:'AV41TFTipLProdDsc_Sel',fld:'vTFTIPLPRODDSC_SEL',pic:''},{av:'AV46TFCliCod',fld:'vTFCLICOD',pic:''},{av:'AV47TFCliCod_Sel',fld:'vTFCLICOD_SEL',pic:''},{av:'AV44TFPreLis',fld:'vTFPRELIS',pic:'ZZZZ,ZZZ,ZZ9.9999'},{av:'AV45TFPreLis_To',fld:'vTFPRELIS_TO',pic:'ZZZZ,ZZZ,ZZ9.9999'},{av:'AV50TFLisFech',fld:'vTFLISFECH',pic:''},{av:'AV51TFLisFech_To',fld:'vTFLISFECH_TO',pic:''},{av:'AV13OrderedBy',fld:'vORDEREDBY',pic:'ZZZ9'},{av:'AV14OrderedDsc',fld:'vORDEREDDSC',pic:''},{av:'AV10GridState',fld:'vGRIDSTATE',pic:''},{av:'AV30DynamicFiltersIgnoreFirst',fld:'vDYNAMICFILTERSIGNOREFIRST',pic:''},{av:'AV29DynamicFiltersRemoving',fld:'vDYNAMICFILTERSREMOVING',pic:''},{av:'Gridpaginationbar_Selectedpage',ctrl:'GRIDPAGINATIONBAR',prop:'SelectedPage'}]");
         setEventMetadata("GRIDPAGINATIONBAR.CHANGEPAGE",",oparms:[]}");
         setEventMetadata("GRIDPAGINATIONBAR.CHANGEROWSPERPAGE","{handler:'E121R2',iparms:[{av:'GRID_nFirstRecordOnPage'},{av:'GRID_nEOF'},{av:'subGrid_Rows',ctrl:'GRID',prop:'Rows'},{av:'cmbavDynamicfiltersselector1'},{av:'AV15DynamicFiltersSelector1',fld:'vDYNAMICFILTERSSELECTOR1',pic:''},{av:'cmbavDynamicfiltersoperator1'},{av:'AV16DynamicFiltersOperator1',fld:'vDYNAMICFILTERSOPERATOR1',pic:'ZZZ9'},{av:'AV17TipLProdDsc1',fld:'vTIPLPRODDSC1',pic:''},{av:'AV18TipLDsc1',fld:'vTIPLDSC1',pic:''},{av:'cmbavDynamicfiltersselector2'},{av:'AV20DynamicFiltersSelector2',fld:'vDYNAMICFILTERSSELECTOR2',pic:''},{av:'cmbavDynamicfiltersoperator2'},{av:'AV21DynamicFiltersOperator2',fld:'vDYNAMICFILTERSOPERATOR2',pic:'ZZZ9'},{av:'AV22TipLProdDsc2',fld:'vTIPLPRODDSC2',pic:''},{av:'AV23TipLDsc2',fld:'vTIPLDSC2',pic:''},{av:'cmbavDynamicfiltersselector3'},{av:'AV25DynamicFiltersSelector3',fld:'vDYNAMICFILTERSSELECTOR3',pic:''},{av:'cmbavDynamicfiltersoperator3'},{av:'AV26DynamicFiltersOperator3',fld:'vDYNAMICFILTERSOPERATOR3',pic:'ZZZ9'},{av:'AV27TipLProdDsc3',fld:'vTIPLPRODDSC3',pic:''},{av:'AV28TipLDsc3',fld:'vTIPLDSC3',pic:''},{av:'AV19DynamicFiltersEnabled2',fld:'vDYNAMICFILTERSENABLED2',pic:''},{av:'AV24DynamicFiltersEnabled3',fld:'vDYNAMICFILTERSENABLED3',pic:''},{av:'AV67Pgmname',fld:'vPGMNAME',pic:'',hsh:true},{av:'AV42TFTipLDsc',fld:'vTFTIPLDSC',pic:''},{av:'AV43TFTipLDsc_Sel',fld:'vTFTIPLDSC_SEL',pic:''},{av:'AV38TFProdCod',fld:'vTFPRODCOD',pic:'@!'},{av:'AV39TFProdCod_Sel',fld:'vTFPRODCOD_SEL',pic:'@!'},{av:'AV40TFTipLProdDsc',fld:'vTFTIPLPRODDSC',pic:''},{av:'AV41TFTipLProdDsc_Sel',fld:'vTFTIPLPRODDSC_SEL',pic:''},{av:'AV46TFCliCod',fld:'vTFCLICOD',pic:''},{av:'AV47TFCliCod_Sel',fld:'vTFCLICOD_SEL',pic:''},{av:'AV44TFPreLis',fld:'vTFPRELIS',pic:'ZZZZ,ZZZ,ZZ9.9999'},{av:'AV45TFPreLis_To',fld:'vTFPRELIS_TO',pic:'ZZZZ,ZZZ,ZZ9.9999'},{av:'AV50TFLisFech',fld:'vTFLISFECH',pic:''},{av:'AV51TFLisFech_To',fld:'vTFLISFECH_TO',pic:''},{av:'AV13OrderedBy',fld:'vORDEREDBY',pic:'ZZZ9'},{av:'AV14OrderedDsc',fld:'vORDEREDDSC',pic:''},{av:'AV10GridState',fld:'vGRIDSTATE',pic:''},{av:'AV30DynamicFiltersIgnoreFirst',fld:'vDYNAMICFILTERSIGNOREFIRST',pic:''},{av:'AV29DynamicFiltersRemoving',fld:'vDYNAMICFILTERSREMOVING',pic:''},{av:'Gridpaginationbar_Rowsperpageselectedvalue',ctrl:'GRIDPAGINATIONBAR',prop:'RowsPerPageSelectedValue'}]");
         setEventMetadata("GRIDPAGINATIONBAR.CHANGEROWSPERPAGE",",oparms:[{av:'subGrid_Rows',ctrl:'GRID',prop:'Rows'}]}");
         setEventMetadata("DDO_GRID.ONOPTIONCLICKED","{handler:'E141R2',iparms:[{av:'GRID_nFirstRecordOnPage'},{av:'GRID_nEOF'},{av:'subGrid_Rows',ctrl:'GRID',prop:'Rows'},{av:'cmbavDynamicfiltersselector1'},{av:'AV15DynamicFiltersSelector1',fld:'vDYNAMICFILTERSSELECTOR1',pic:''},{av:'cmbavDynamicfiltersoperator1'},{av:'AV16DynamicFiltersOperator1',fld:'vDYNAMICFILTERSOPERATOR1',pic:'ZZZ9'},{av:'AV17TipLProdDsc1',fld:'vTIPLPRODDSC1',pic:''},{av:'AV18TipLDsc1',fld:'vTIPLDSC1',pic:''},{av:'cmbavDynamicfiltersselector2'},{av:'AV20DynamicFiltersSelector2',fld:'vDYNAMICFILTERSSELECTOR2',pic:''},{av:'cmbavDynamicfiltersoperator2'},{av:'AV21DynamicFiltersOperator2',fld:'vDYNAMICFILTERSOPERATOR2',pic:'ZZZ9'},{av:'AV22TipLProdDsc2',fld:'vTIPLPRODDSC2',pic:''},{av:'AV23TipLDsc2',fld:'vTIPLDSC2',pic:''},{av:'cmbavDynamicfiltersselector3'},{av:'AV25DynamicFiltersSelector3',fld:'vDYNAMICFILTERSSELECTOR3',pic:''},{av:'cmbavDynamicfiltersoperator3'},{av:'AV26DynamicFiltersOperator3',fld:'vDYNAMICFILTERSOPERATOR3',pic:'ZZZ9'},{av:'AV27TipLProdDsc3',fld:'vTIPLPRODDSC3',pic:''},{av:'AV28TipLDsc3',fld:'vTIPLDSC3',pic:''},{av:'AV19DynamicFiltersEnabled2',fld:'vDYNAMICFILTERSENABLED2',pic:''},{av:'AV24DynamicFiltersEnabled3',fld:'vDYNAMICFILTERSENABLED3',pic:''},{av:'AV67Pgmname',fld:'vPGMNAME',pic:'',hsh:true},{av:'AV42TFTipLDsc',fld:'vTFTIPLDSC',pic:''},{av:'AV43TFTipLDsc_Sel',fld:'vTFTIPLDSC_SEL',pic:''},{av:'AV38TFProdCod',fld:'vTFPRODCOD',pic:'@!'},{av:'AV39TFProdCod_Sel',fld:'vTFPRODCOD_SEL',pic:'@!'},{av:'AV40TFTipLProdDsc',fld:'vTFTIPLPRODDSC',pic:''},{av:'AV41TFTipLProdDsc_Sel',fld:'vTFTIPLPRODDSC_SEL',pic:''},{av:'AV46TFCliCod',fld:'vTFCLICOD',pic:''},{av:'AV47TFCliCod_Sel',fld:'vTFCLICOD_SEL',pic:''},{av:'AV44TFPreLis',fld:'vTFPRELIS',pic:'ZZZZ,ZZZ,ZZ9.9999'},{av:'AV45TFPreLis_To',fld:'vTFPRELIS_TO',pic:'ZZZZ,ZZZ,ZZ9.9999'},{av:'AV50TFLisFech',fld:'vTFLISFECH',pic:''},{av:'AV51TFLisFech_To',fld:'vTFLISFECH_TO',pic:''},{av:'AV13OrderedBy',fld:'vORDEREDBY',pic:'ZZZ9'},{av:'AV14OrderedDsc',fld:'vORDEREDDSC',pic:''},{av:'AV10GridState',fld:'vGRIDSTATE',pic:''},{av:'AV30DynamicFiltersIgnoreFirst',fld:'vDYNAMICFILTERSIGNOREFIRST',pic:''},{av:'AV29DynamicFiltersRemoving',fld:'vDYNAMICFILTERSREMOVING',pic:''},{av:'Ddo_grid_Activeeventkey',ctrl:'DDO_GRID',prop:'ActiveEventKey'},{av:'Ddo_grid_Selectedvalue_get',ctrl:'DDO_GRID',prop:'SelectedValue_get'},{av:'Ddo_grid_Filteredtextto_get',ctrl:'DDO_GRID',prop:'FilteredTextTo_get'},{av:'Ddo_grid_Filteredtext_get',ctrl:'DDO_GRID',prop:'FilteredText_get'},{av:'Ddo_grid_Selectedcolumn',ctrl:'DDO_GRID',prop:'SelectedColumn'}]");
         setEventMetadata("DDO_GRID.ONOPTIONCLICKED",",oparms:[{av:'AV13OrderedBy',fld:'vORDEREDBY',pic:'ZZZ9'},{av:'AV14OrderedDsc',fld:'vORDEREDDSC',pic:''},{av:'AV50TFLisFech',fld:'vTFLISFECH',pic:''},{av:'AV51TFLisFech_To',fld:'vTFLISFECH_TO',pic:''},{av:'AV44TFPreLis',fld:'vTFPRELIS',pic:'ZZZZ,ZZZ,ZZ9.9999'},{av:'AV45TFPreLis_To',fld:'vTFPRELIS_TO',pic:'ZZZZ,ZZZ,ZZ9.9999'},{av:'AV46TFCliCod',fld:'vTFCLICOD',pic:''},{av:'AV47TFCliCod_Sel',fld:'vTFCLICOD_SEL',pic:''},{av:'AV40TFTipLProdDsc',fld:'vTFTIPLPRODDSC',pic:''},{av:'AV41TFTipLProdDsc_Sel',fld:'vTFTIPLPRODDSC_SEL',pic:''},{av:'AV38TFProdCod',fld:'vTFPRODCOD',pic:'@!'},{av:'AV39TFProdCod_Sel',fld:'vTFPRODCOD_SEL',pic:'@!'},{av:'AV42TFTipLDsc',fld:'vTFTIPLDSC',pic:''},{av:'AV43TFTipLDsc_Sel',fld:'vTFTIPLDSC_SEL',pic:''},{av:'Ddo_grid_Sortedstatus',ctrl:'DDO_GRID',prop:'SortedStatus'}]}");
         setEventMetadata("GRID.LOAD","{handler:'E261R2',iparms:[{av:'A202TipLCod',fld:'TIPLCOD',pic:'ZZZZZ9',hsh:true},{av:'A203TipLItem',fld:'TIPLITEM',pic:'ZZZZZ9',hsh:true}]");
         setEventMetadata("GRID.LOAD",",oparms:[{av:'cmbavGridactions'},{av:'AV62GridActions',fld:'vGRIDACTIONS',pic:'ZZZ9'},{av:'edtTipLDsc_Link',ctrl:'TIPLDSC',prop:'Link'},{av:'edtTipLProdDsc_Link',ctrl:'TIPLPRODDSC',prop:'Link'}]}");
         setEventMetadata("'ADDDYNAMICFILTERS1'","{handler:'E191R2',iparms:[{av:'GRID_nFirstRecordOnPage'},{av:'GRID_nEOF'},{av:'subGrid_Rows',ctrl:'GRID',prop:'Rows'},{av:'cmbavDynamicfiltersselector1'},{av:'AV15DynamicFiltersSelector1',fld:'vDYNAMICFILTERSSELECTOR1',pic:''},{av:'cmbavDynamicfiltersoperator1'},{av:'AV16DynamicFiltersOperator1',fld:'vDYNAMICFILTERSOPERATOR1',pic:'ZZZ9'},{av:'AV17TipLProdDsc1',fld:'vTIPLPRODDSC1',pic:''},{av:'AV18TipLDsc1',fld:'vTIPLDSC1',pic:''},{av:'cmbavDynamicfiltersselector2'},{av:'AV20DynamicFiltersSelector2',fld:'vDYNAMICFILTERSSELECTOR2',pic:''},{av:'cmbavDynamicfiltersoperator2'},{av:'AV21DynamicFiltersOperator2',fld:'vDYNAMICFILTERSOPERATOR2',pic:'ZZZ9'},{av:'AV22TipLProdDsc2',fld:'vTIPLPRODDSC2',pic:''},{av:'AV23TipLDsc2',fld:'vTIPLDSC2',pic:''},{av:'cmbavDynamicfiltersselector3'},{av:'AV25DynamicFiltersSelector3',fld:'vDYNAMICFILTERSSELECTOR3',pic:''},{av:'cmbavDynamicfiltersoperator3'},{av:'AV26DynamicFiltersOperator3',fld:'vDYNAMICFILTERSOPERATOR3',pic:'ZZZ9'},{av:'AV27TipLProdDsc3',fld:'vTIPLPRODDSC3',pic:''},{av:'AV28TipLDsc3',fld:'vTIPLDSC3',pic:''},{av:'AV19DynamicFiltersEnabled2',fld:'vDYNAMICFILTERSENABLED2',pic:''},{av:'AV24DynamicFiltersEnabled3',fld:'vDYNAMICFILTERSENABLED3',pic:''},{av:'AV67Pgmname',fld:'vPGMNAME',pic:'',hsh:true},{av:'AV42TFTipLDsc',fld:'vTFTIPLDSC',pic:''},{av:'AV43TFTipLDsc_Sel',fld:'vTFTIPLDSC_SEL',pic:''},{av:'AV38TFProdCod',fld:'vTFPRODCOD',pic:'@!'},{av:'AV39TFProdCod_Sel',fld:'vTFPRODCOD_SEL',pic:'@!'},{av:'AV40TFTipLProdDsc',fld:'vTFTIPLPRODDSC',pic:''},{av:'AV41TFTipLProdDsc_Sel',fld:'vTFTIPLPRODDSC_SEL',pic:''},{av:'AV46TFCliCod',fld:'vTFCLICOD',pic:''},{av:'AV47TFCliCod_Sel',fld:'vTFCLICOD_SEL',pic:''},{av:'AV44TFPreLis',fld:'vTFPRELIS',pic:'ZZZZ,ZZZ,ZZ9.9999'},{av:'AV45TFPreLis_To',fld:'vTFPRELIS_TO',pic:'ZZZZ,ZZZ,ZZ9.9999'},{av:'AV50TFLisFech',fld:'vTFLISFECH',pic:''},{av:'AV51TFLisFech_To',fld:'vTFLISFECH_TO',pic:''},{av:'AV13OrderedBy',fld:'vORDEREDBY',pic:'ZZZ9'},{av:'AV14OrderedDsc',fld:'vORDEREDDSC',pic:''},{av:'AV10GridState',fld:'vGRIDSTATE',pic:''},{av:'AV30DynamicFiltersIgnoreFirst',fld:'vDYNAMICFILTERSIGNOREFIRST',pic:''},{av:'AV29DynamicFiltersRemoving',fld:'vDYNAMICFILTERSREMOVING',pic:''}]");
         setEventMetadata("'ADDDYNAMICFILTERS1'",",oparms:[{av:'AV19DynamicFiltersEnabled2',fld:'vDYNAMICFILTERSENABLED2',pic:''},{av:'imgAdddynamicfilters1_Visible',ctrl:'ADDDYNAMICFILTERS1',prop:'Visible'},{av:'imgRemovedynamicfilters1_Visible',ctrl:'REMOVEDYNAMICFILTERS1',prop:'Visible'},{av:'cmbavDynamicfiltersoperator1'},{av:'AV16DynamicFiltersOperator1',fld:'vDYNAMICFILTERSOPERATOR1',pic:'ZZZ9'},{av:'cmbavDynamicfiltersoperator2'},{av:'AV21DynamicFiltersOperator2',fld:'vDYNAMICFILTERSOPERATOR2',pic:'ZZZ9'},{av:'cmbavDynamicfiltersoperator3'},{av:'AV26DynamicFiltersOperator3',fld:'vDYNAMICFILTERSOPERATOR3',pic:'ZZZ9'},{av:'AV59GridCurrentPage',fld:'vGRIDCURRENTPAGE',pic:'ZZZZZZZZZ9'},{av:'AV60GridPageCount',fld:'vGRIDPAGECOUNT',pic:'ZZZZZZZZZ9'},{av:'AV61GridAppliedFilters',fld:'vGRIDAPPLIEDFILTERS',pic:''},{av:'AV10GridState',fld:'vGRIDSTATE',pic:''}]}");
         setEventMetadata("'REMOVEDYNAMICFILTERS1'","{handler:'E151R2',iparms:[{av:'GRID_nFirstRecordOnPage'},{av:'GRID_nEOF'},{av:'subGrid_Rows',ctrl:'GRID',prop:'Rows'},{av:'cmbavDynamicfiltersselector1'},{av:'AV15DynamicFiltersSelector1',fld:'vDYNAMICFILTERSSELECTOR1',pic:''},{av:'cmbavDynamicfiltersoperator1'},{av:'AV16DynamicFiltersOperator1',fld:'vDYNAMICFILTERSOPERATOR1',pic:'ZZZ9'},{av:'AV17TipLProdDsc1',fld:'vTIPLPRODDSC1',pic:''},{av:'AV18TipLDsc1',fld:'vTIPLDSC1',pic:''},{av:'cmbavDynamicfiltersselector2'},{av:'AV20DynamicFiltersSelector2',fld:'vDYNAMICFILTERSSELECTOR2',pic:''},{av:'cmbavDynamicfiltersoperator2'},{av:'AV21DynamicFiltersOperator2',fld:'vDYNAMICFILTERSOPERATOR2',pic:'ZZZ9'},{av:'AV22TipLProdDsc2',fld:'vTIPLPRODDSC2',pic:''},{av:'AV23TipLDsc2',fld:'vTIPLDSC2',pic:''},{av:'cmbavDynamicfiltersselector3'},{av:'AV25DynamicFiltersSelector3',fld:'vDYNAMICFILTERSSELECTOR3',pic:''},{av:'cmbavDynamicfiltersoperator3'},{av:'AV26DynamicFiltersOperator3',fld:'vDYNAMICFILTERSOPERATOR3',pic:'ZZZ9'},{av:'AV27TipLProdDsc3',fld:'vTIPLPRODDSC3',pic:''},{av:'AV28TipLDsc3',fld:'vTIPLDSC3',pic:''},{av:'AV19DynamicFiltersEnabled2',fld:'vDYNAMICFILTERSENABLED2',pic:''},{av:'AV24DynamicFiltersEnabled3',fld:'vDYNAMICFILTERSENABLED3',pic:''},{av:'AV67Pgmname',fld:'vPGMNAME',pic:'',hsh:true},{av:'AV42TFTipLDsc',fld:'vTFTIPLDSC',pic:''},{av:'AV43TFTipLDsc_Sel',fld:'vTFTIPLDSC_SEL',pic:''},{av:'AV38TFProdCod',fld:'vTFPRODCOD',pic:'@!'},{av:'AV39TFProdCod_Sel',fld:'vTFPRODCOD_SEL',pic:'@!'},{av:'AV40TFTipLProdDsc',fld:'vTFTIPLPRODDSC',pic:''},{av:'AV41TFTipLProdDsc_Sel',fld:'vTFTIPLPRODDSC_SEL',pic:''},{av:'AV46TFCliCod',fld:'vTFCLICOD',pic:''},{av:'AV47TFCliCod_Sel',fld:'vTFCLICOD_SEL',pic:''},{av:'AV44TFPreLis',fld:'vTFPRELIS',pic:'ZZZZ,ZZZ,ZZ9.9999'},{av:'AV45TFPreLis_To',fld:'vTFPRELIS_TO',pic:'ZZZZ,ZZZ,ZZ9.9999'},{av:'AV50TFLisFech',fld:'vTFLISFECH',pic:''},{av:'AV51TFLisFech_To',fld:'vTFLISFECH_TO',pic:''},{av:'AV13OrderedBy',fld:'vORDEREDBY',pic:'ZZZ9'},{av:'AV14OrderedDsc',fld:'vORDEREDDSC',pic:''},{av:'AV10GridState',fld:'vGRIDSTATE',pic:''},{av:'AV30DynamicFiltersIgnoreFirst',fld:'vDYNAMICFILTERSIGNOREFIRST',pic:''},{av:'AV29DynamicFiltersRemoving',fld:'vDYNAMICFILTERSREMOVING',pic:''}]");
         setEventMetadata("'REMOVEDYNAMICFILTERS1'",",oparms:[{av:'AV29DynamicFiltersRemoving',fld:'vDYNAMICFILTERSREMOVING',pic:''},{av:'AV30DynamicFiltersIgnoreFirst',fld:'vDYNAMICFILTERSIGNOREFIRST',pic:''},{av:'AV10GridState',fld:'vGRIDSTATE',pic:''},{av:'AV19DynamicFiltersEnabled2',fld:'vDYNAMICFILTERSENABLED2',pic:''},{av:'cmbavDynamicfiltersselector2'},{av:'AV20DynamicFiltersSelector2',fld:'vDYNAMICFILTERSSELECTOR2',pic:''},{av:'cmbavDynamicfiltersoperator2'},{av:'AV21DynamicFiltersOperator2',fld:'vDYNAMICFILTERSOPERATOR2',pic:'ZZZ9'},{av:'AV22TipLProdDsc2',fld:'vTIPLPRODDSC2',pic:''},{av:'AV24DynamicFiltersEnabled3',fld:'vDYNAMICFILTERSENABLED3',pic:''},{av:'cmbavDynamicfiltersselector3'},{av:'AV25DynamicFiltersSelector3',fld:'vDYNAMICFILTERSSELECTOR3',pic:''},{av:'cmbavDynamicfiltersoperator3'},{av:'AV26DynamicFiltersOperator3',fld:'vDYNAMICFILTERSOPERATOR3',pic:'ZZZ9'},{av:'AV27TipLProdDsc3',fld:'vTIPLPRODDSC3',pic:''},{av:'imgAdddynamicfilters1_Visible',ctrl:'ADDDYNAMICFILTERS1',prop:'Visible'},{av:'imgRemovedynamicfilters1_Visible',ctrl:'REMOVEDYNAMICFILTERS1',prop:'Visible'},{av:'imgAdddynamicfilters2_Visible',ctrl:'ADDDYNAMICFILTERS2',prop:'Visible'},{av:'imgRemovedynamicfilters2_Visible',ctrl:'REMOVEDYNAMICFILTERS2',prop:'Visible'},{av:'cmbavDynamicfiltersselector1'},{av:'AV15DynamicFiltersSelector1',fld:'vDYNAMICFILTERSSELECTOR1',pic:''},{av:'cmbavDynamicfiltersoperator1'},{av:'AV16DynamicFiltersOperator1',fld:'vDYNAMICFILTERSOPERATOR1',pic:'ZZZ9'},{av:'AV17TipLProdDsc1',fld:'vTIPLPRODDSC1',pic:''},{av:'AV18TipLDsc1',fld:'vTIPLDSC1',pic:''},{av:'lblJsdynamicfilters_Caption',ctrl:'JSDYNAMICFILTERS',prop:'Caption'},{av:'AV23TipLDsc2',fld:'vTIPLDSC2',pic:''},{av:'AV28TipLDsc3',fld:'vTIPLDSC3',pic:''},{av:'edtavTiplproddsc2_Visible',ctrl:'vTIPLPRODDSC2',prop:'Visible'},{av:'edtavTipldsc2_Visible',ctrl:'vTIPLDSC2',prop:'Visible'},{av:'edtavTiplproddsc3_Visible',ctrl:'vTIPLPRODDSC3',prop:'Visible'},{av:'edtavTipldsc3_Visible',ctrl:'vTIPLDSC3',prop:'Visible'},{av:'edtavTiplproddsc1_Visible',ctrl:'vTIPLPRODDSC1',prop:'Visible'},{av:'edtavTipldsc1_Visible',ctrl:'vTIPLDSC1',prop:'Visible'},{av:'AV59GridCurrentPage',fld:'vGRIDCURRENTPAGE',pic:'ZZZZZZZZZ9'},{av:'AV60GridPageCount',fld:'vGRIDPAGECOUNT',pic:'ZZZZZZZZZ9'},{av:'AV61GridAppliedFilters',fld:'vGRIDAPPLIEDFILTERS',pic:''}]}");
         setEventMetadata("VDYNAMICFILTERSSELECTOR1.CLICK","{handler:'E201R2',iparms:[{av:'cmbavDynamicfiltersselector1'},{av:'AV15DynamicFiltersSelector1',fld:'vDYNAMICFILTERSSELECTOR1',pic:''}]");
         setEventMetadata("VDYNAMICFILTERSSELECTOR1.CLICK",",oparms:[{av:'cmbavDynamicfiltersoperator1'},{av:'AV16DynamicFiltersOperator1',fld:'vDYNAMICFILTERSOPERATOR1',pic:'ZZZ9'},{av:'edtavTiplproddsc1_Visible',ctrl:'vTIPLPRODDSC1',prop:'Visible'},{av:'edtavTipldsc1_Visible',ctrl:'vTIPLDSC1',prop:'Visible'}]}");
         setEventMetadata("'ADDDYNAMICFILTERS2'","{handler:'E211R2',iparms:[{av:'GRID_nFirstRecordOnPage'},{av:'GRID_nEOF'},{av:'subGrid_Rows',ctrl:'GRID',prop:'Rows'},{av:'cmbavDynamicfiltersselector1'},{av:'AV15DynamicFiltersSelector1',fld:'vDYNAMICFILTERSSELECTOR1',pic:''},{av:'cmbavDynamicfiltersoperator1'},{av:'AV16DynamicFiltersOperator1',fld:'vDYNAMICFILTERSOPERATOR1',pic:'ZZZ9'},{av:'AV17TipLProdDsc1',fld:'vTIPLPRODDSC1',pic:''},{av:'AV18TipLDsc1',fld:'vTIPLDSC1',pic:''},{av:'cmbavDynamicfiltersselector2'},{av:'AV20DynamicFiltersSelector2',fld:'vDYNAMICFILTERSSELECTOR2',pic:''},{av:'cmbavDynamicfiltersoperator2'},{av:'AV21DynamicFiltersOperator2',fld:'vDYNAMICFILTERSOPERATOR2',pic:'ZZZ9'},{av:'AV22TipLProdDsc2',fld:'vTIPLPRODDSC2',pic:''},{av:'AV23TipLDsc2',fld:'vTIPLDSC2',pic:''},{av:'cmbavDynamicfiltersselector3'},{av:'AV25DynamicFiltersSelector3',fld:'vDYNAMICFILTERSSELECTOR3',pic:''},{av:'cmbavDynamicfiltersoperator3'},{av:'AV26DynamicFiltersOperator3',fld:'vDYNAMICFILTERSOPERATOR3',pic:'ZZZ9'},{av:'AV27TipLProdDsc3',fld:'vTIPLPRODDSC3',pic:''},{av:'AV28TipLDsc3',fld:'vTIPLDSC3',pic:''},{av:'AV19DynamicFiltersEnabled2',fld:'vDYNAMICFILTERSENABLED2',pic:''},{av:'AV24DynamicFiltersEnabled3',fld:'vDYNAMICFILTERSENABLED3',pic:''},{av:'AV67Pgmname',fld:'vPGMNAME',pic:'',hsh:true},{av:'AV42TFTipLDsc',fld:'vTFTIPLDSC',pic:''},{av:'AV43TFTipLDsc_Sel',fld:'vTFTIPLDSC_SEL',pic:''},{av:'AV38TFProdCod',fld:'vTFPRODCOD',pic:'@!'},{av:'AV39TFProdCod_Sel',fld:'vTFPRODCOD_SEL',pic:'@!'},{av:'AV40TFTipLProdDsc',fld:'vTFTIPLPRODDSC',pic:''},{av:'AV41TFTipLProdDsc_Sel',fld:'vTFTIPLPRODDSC_SEL',pic:''},{av:'AV46TFCliCod',fld:'vTFCLICOD',pic:''},{av:'AV47TFCliCod_Sel',fld:'vTFCLICOD_SEL',pic:''},{av:'AV44TFPreLis',fld:'vTFPRELIS',pic:'ZZZZ,ZZZ,ZZ9.9999'},{av:'AV45TFPreLis_To',fld:'vTFPRELIS_TO',pic:'ZZZZ,ZZZ,ZZ9.9999'},{av:'AV50TFLisFech',fld:'vTFLISFECH',pic:''},{av:'AV51TFLisFech_To',fld:'vTFLISFECH_TO',pic:''},{av:'AV13OrderedBy',fld:'vORDEREDBY',pic:'ZZZ9'},{av:'AV14OrderedDsc',fld:'vORDEREDDSC',pic:''},{av:'AV10GridState',fld:'vGRIDSTATE',pic:''},{av:'AV30DynamicFiltersIgnoreFirst',fld:'vDYNAMICFILTERSIGNOREFIRST',pic:''},{av:'AV29DynamicFiltersRemoving',fld:'vDYNAMICFILTERSREMOVING',pic:''}]");
         setEventMetadata("'ADDDYNAMICFILTERS2'",",oparms:[{av:'AV24DynamicFiltersEnabled3',fld:'vDYNAMICFILTERSENABLED3',pic:''},{av:'imgAdddynamicfilters2_Visible',ctrl:'ADDDYNAMICFILTERS2',prop:'Visible'},{av:'imgRemovedynamicfilters2_Visible',ctrl:'REMOVEDYNAMICFILTERS2',prop:'Visible'},{av:'cmbavDynamicfiltersoperator1'},{av:'AV16DynamicFiltersOperator1',fld:'vDYNAMICFILTERSOPERATOR1',pic:'ZZZ9'},{av:'cmbavDynamicfiltersoperator2'},{av:'AV21DynamicFiltersOperator2',fld:'vDYNAMICFILTERSOPERATOR2',pic:'ZZZ9'},{av:'cmbavDynamicfiltersoperator3'},{av:'AV26DynamicFiltersOperator3',fld:'vDYNAMICFILTERSOPERATOR3',pic:'ZZZ9'},{av:'AV59GridCurrentPage',fld:'vGRIDCURRENTPAGE',pic:'ZZZZZZZZZ9'},{av:'AV60GridPageCount',fld:'vGRIDPAGECOUNT',pic:'ZZZZZZZZZ9'},{av:'AV61GridAppliedFilters',fld:'vGRIDAPPLIEDFILTERS',pic:''},{av:'AV10GridState',fld:'vGRIDSTATE',pic:''}]}");
         setEventMetadata("'REMOVEDYNAMICFILTERS2'","{handler:'E161R2',iparms:[{av:'GRID_nFirstRecordOnPage'},{av:'GRID_nEOF'},{av:'subGrid_Rows',ctrl:'GRID',prop:'Rows'},{av:'cmbavDynamicfiltersselector1'},{av:'AV15DynamicFiltersSelector1',fld:'vDYNAMICFILTERSSELECTOR1',pic:''},{av:'cmbavDynamicfiltersoperator1'},{av:'AV16DynamicFiltersOperator1',fld:'vDYNAMICFILTERSOPERATOR1',pic:'ZZZ9'},{av:'AV17TipLProdDsc1',fld:'vTIPLPRODDSC1',pic:''},{av:'AV18TipLDsc1',fld:'vTIPLDSC1',pic:''},{av:'cmbavDynamicfiltersselector2'},{av:'AV20DynamicFiltersSelector2',fld:'vDYNAMICFILTERSSELECTOR2',pic:''},{av:'cmbavDynamicfiltersoperator2'},{av:'AV21DynamicFiltersOperator2',fld:'vDYNAMICFILTERSOPERATOR2',pic:'ZZZ9'},{av:'AV22TipLProdDsc2',fld:'vTIPLPRODDSC2',pic:''},{av:'AV23TipLDsc2',fld:'vTIPLDSC2',pic:''},{av:'cmbavDynamicfiltersselector3'},{av:'AV25DynamicFiltersSelector3',fld:'vDYNAMICFILTERSSELECTOR3',pic:''},{av:'cmbavDynamicfiltersoperator3'},{av:'AV26DynamicFiltersOperator3',fld:'vDYNAMICFILTERSOPERATOR3',pic:'ZZZ9'},{av:'AV27TipLProdDsc3',fld:'vTIPLPRODDSC3',pic:''},{av:'AV28TipLDsc3',fld:'vTIPLDSC3',pic:''},{av:'AV19DynamicFiltersEnabled2',fld:'vDYNAMICFILTERSENABLED2',pic:''},{av:'AV24DynamicFiltersEnabled3',fld:'vDYNAMICFILTERSENABLED3',pic:''},{av:'AV67Pgmname',fld:'vPGMNAME',pic:'',hsh:true},{av:'AV42TFTipLDsc',fld:'vTFTIPLDSC',pic:''},{av:'AV43TFTipLDsc_Sel',fld:'vTFTIPLDSC_SEL',pic:''},{av:'AV38TFProdCod',fld:'vTFPRODCOD',pic:'@!'},{av:'AV39TFProdCod_Sel',fld:'vTFPRODCOD_SEL',pic:'@!'},{av:'AV40TFTipLProdDsc',fld:'vTFTIPLPRODDSC',pic:''},{av:'AV41TFTipLProdDsc_Sel',fld:'vTFTIPLPRODDSC_SEL',pic:''},{av:'AV46TFCliCod',fld:'vTFCLICOD',pic:''},{av:'AV47TFCliCod_Sel',fld:'vTFCLICOD_SEL',pic:''},{av:'AV44TFPreLis',fld:'vTFPRELIS',pic:'ZZZZ,ZZZ,ZZ9.9999'},{av:'AV45TFPreLis_To',fld:'vTFPRELIS_TO',pic:'ZZZZ,ZZZ,ZZ9.9999'},{av:'AV50TFLisFech',fld:'vTFLISFECH',pic:''},{av:'AV51TFLisFech_To',fld:'vTFLISFECH_TO',pic:''},{av:'AV13OrderedBy',fld:'vORDEREDBY',pic:'ZZZ9'},{av:'AV14OrderedDsc',fld:'vORDEREDDSC',pic:''},{av:'AV10GridState',fld:'vGRIDSTATE',pic:''},{av:'AV30DynamicFiltersIgnoreFirst',fld:'vDYNAMICFILTERSIGNOREFIRST',pic:''},{av:'AV29DynamicFiltersRemoving',fld:'vDYNAMICFILTERSREMOVING',pic:''}]");
         setEventMetadata("'REMOVEDYNAMICFILTERS2'",",oparms:[{av:'AV29DynamicFiltersRemoving',fld:'vDYNAMICFILTERSREMOVING',pic:''},{av:'AV19DynamicFiltersEnabled2',fld:'vDYNAMICFILTERSENABLED2',pic:''},{av:'AV10GridState',fld:'vGRIDSTATE',pic:''},{av:'cmbavDynamicfiltersselector2'},{av:'AV20DynamicFiltersSelector2',fld:'vDYNAMICFILTERSSELECTOR2',pic:''},{av:'cmbavDynamicfiltersoperator2'},{av:'AV21DynamicFiltersOperator2',fld:'vDYNAMICFILTERSOPERATOR2',pic:'ZZZ9'},{av:'AV22TipLProdDsc2',fld:'vTIPLPRODDSC2',pic:''},{av:'AV24DynamicFiltersEnabled3',fld:'vDYNAMICFILTERSENABLED3',pic:''},{av:'cmbavDynamicfiltersselector3'},{av:'AV25DynamicFiltersSelector3',fld:'vDYNAMICFILTERSSELECTOR3',pic:''},{av:'cmbavDynamicfiltersoperator3'},{av:'AV26DynamicFiltersOperator3',fld:'vDYNAMICFILTERSOPERATOR3',pic:'ZZZ9'},{av:'AV27TipLProdDsc3',fld:'vTIPLPRODDSC3',pic:''},{av:'imgAdddynamicfilters1_Visible',ctrl:'ADDDYNAMICFILTERS1',prop:'Visible'},{av:'imgRemovedynamicfilters1_Visible',ctrl:'REMOVEDYNAMICFILTERS1',prop:'Visible'},{av:'imgAdddynamicfilters2_Visible',ctrl:'ADDDYNAMICFILTERS2',prop:'Visible'},{av:'imgRemovedynamicfilters2_Visible',ctrl:'REMOVEDYNAMICFILTERS2',prop:'Visible'},{av:'cmbavDynamicfiltersselector1'},{av:'AV15DynamicFiltersSelector1',fld:'vDYNAMICFILTERSSELECTOR1',pic:''},{av:'cmbavDynamicfiltersoperator1'},{av:'AV16DynamicFiltersOperator1',fld:'vDYNAMICFILTERSOPERATOR1',pic:'ZZZ9'},{av:'AV17TipLProdDsc1',fld:'vTIPLPRODDSC1',pic:''},{av:'AV18TipLDsc1',fld:'vTIPLDSC1',pic:''},{av:'lblJsdynamicfilters_Caption',ctrl:'JSDYNAMICFILTERS',prop:'Caption'},{av:'AV23TipLDsc2',fld:'vTIPLDSC2',pic:''},{av:'AV28TipLDsc3',fld:'vTIPLDSC3',pic:''},{av:'edtavTiplproddsc2_Visible',ctrl:'vTIPLPRODDSC2',prop:'Visible'},{av:'edtavTipldsc2_Visible',ctrl:'vTIPLDSC2',prop:'Visible'},{av:'edtavTiplproddsc3_Visible',ctrl:'vTIPLPRODDSC3',prop:'Visible'},{av:'edtavTipldsc3_Visible',ctrl:'vTIPLDSC3',prop:'Visible'},{av:'edtavTiplproddsc1_Visible',ctrl:'vTIPLPRODDSC1',prop:'Visible'},{av:'edtavTipldsc1_Visible',ctrl:'vTIPLDSC1',prop:'Visible'},{av:'AV59GridCurrentPage',fld:'vGRIDCURRENTPAGE',pic:'ZZZZZZZZZ9'},{av:'AV60GridPageCount',fld:'vGRIDPAGECOUNT',pic:'ZZZZZZZZZ9'},{av:'AV61GridAppliedFilters',fld:'vGRIDAPPLIEDFILTERS',pic:''}]}");
         setEventMetadata("VDYNAMICFILTERSSELECTOR2.CLICK","{handler:'E221R2',iparms:[{av:'cmbavDynamicfiltersselector2'},{av:'AV20DynamicFiltersSelector2',fld:'vDYNAMICFILTERSSELECTOR2',pic:''}]");
         setEventMetadata("VDYNAMICFILTERSSELECTOR2.CLICK",",oparms:[{av:'cmbavDynamicfiltersoperator2'},{av:'AV21DynamicFiltersOperator2',fld:'vDYNAMICFILTERSOPERATOR2',pic:'ZZZ9'},{av:'edtavTiplproddsc2_Visible',ctrl:'vTIPLPRODDSC2',prop:'Visible'},{av:'edtavTipldsc2_Visible',ctrl:'vTIPLDSC2',prop:'Visible'}]}");
         setEventMetadata("'REMOVEDYNAMICFILTERS3'","{handler:'E171R2',iparms:[{av:'GRID_nFirstRecordOnPage'},{av:'GRID_nEOF'},{av:'subGrid_Rows',ctrl:'GRID',prop:'Rows'},{av:'cmbavDynamicfiltersselector1'},{av:'AV15DynamicFiltersSelector1',fld:'vDYNAMICFILTERSSELECTOR1',pic:''},{av:'cmbavDynamicfiltersoperator1'},{av:'AV16DynamicFiltersOperator1',fld:'vDYNAMICFILTERSOPERATOR1',pic:'ZZZ9'},{av:'AV17TipLProdDsc1',fld:'vTIPLPRODDSC1',pic:''},{av:'AV18TipLDsc1',fld:'vTIPLDSC1',pic:''},{av:'cmbavDynamicfiltersselector2'},{av:'AV20DynamicFiltersSelector2',fld:'vDYNAMICFILTERSSELECTOR2',pic:''},{av:'cmbavDynamicfiltersoperator2'},{av:'AV21DynamicFiltersOperator2',fld:'vDYNAMICFILTERSOPERATOR2',pic:'ZZZ9'},{av:'AV22TipLProdDsc2',fld:'vTIPLPRODDSC2',pic:''},{av:'AV23TipLDsc2',fld:'vTIPLDSC2',pic:''},{av:'cmbavDynamicfiltersselector3'},{av:'AV25DynamicFiltersSelector3',fld:'vDYNAMICFILTERSSELECTOR3',pic:''},{av:'cmbavDynamicfiltersoperator3'},{av:'AV26DynamicFiltersOperator3',fld:'vDYNAMICFILTERSOPERATOR3',pic:'ZZZ9'},{av:'AV27TipLProdDsc3',fld:'vTIPLPRODDSC3',pic:''},{av:'AV28TipLDsc3',fld:'vTIPLDSC3',pic:''},{av:'AV19DynamicFiltersEnabled2',fld:'vDYNAMICFILTERSENABLED2',pic:''},{av:'AV24DynamicFiltersEnabled3',fld:'vDYNAMICFILTERSENABLED3',pic:''},{av:'AV67Pgmname',fld:'vPGMNAME',pic:'',hsh:true},{av:'AV42TFTipLDsc',fld:'vTFTIPLDSC',pic:''},{av:'AV43TFTipLDsc_Sel',fld:'vTFTIPLDSC_SEL',pic:''},{av:'AV38TFProdCod',fld:'vTFPRODCOD',pic:'@!'},{av:'AV39TFProdCod_Sel',fld:'vTFPRODCOD_SEL',pic:'@!'},{av:'AV40TFTipLProdDsc',fld:'vTFTIPLPRODDSC',pic:''},{av:'AV41TFTipLProdDsc_Sel',fld:'vTFTIPLPRODDSC_SEL',pic:''},{av:'AV46TFCliCod',fld:'vTFCLICOD',pic:''},{av:'AV47TFCliCod_Sel',fld:'vTFCLICOD_SEL',pic:''},{av:'AV44TFPreLis',fld:'vTFPRELIS',pic:'ZZZZ,ZZZ,ZZ9.9999'},{av:'AV45TFPreLis_To',fld:'vTFPRELIS_TO',pic:'ZZZZ,ZZZ,ZZ9.9999'},{av:'AV50TFLisFech',fld:'vTFLISFECH',pic:''},{av:'AV51TFLisFech_To',fld:'vTFLISFECH_TO',pic:''},{av:'AV13OrderedBy',fld:'vORDEREDBY',pic:'ZZZ9'},{av:'AV14OrderedDsc',fld:'vORDEREDDSC',pic:''},{av:'AV10GridState',fld:'vGRIDSTATE',pic:''},{av:'AV30DynamicFiltersIgnoreFirst',fld:'vDYNAMICFILTERSIGNOREFIRST',pic:''},{av:'AV29DynamicFiltersRemoving',fld:'vDYNAMICFILTERSREMOVING',pic:''}]");
         setEventMetadata("'REMOVEDYNAMICFILTERS3'",",oparms:[{av:'AV29DynamicFiltersRemoving',fld:'vDYNAMICFILTERSREMOVING',pic:''},{av:'AV24DynamicFiltersEnabled3',fld:'vDYNAMICFILTERSENABLED3',pic:''},{av:'AV10GridState',fld:'vGRIDSTATE',pic:''},{av:'AV19DynamicFiltersEnabled2',fld:'vDYNAMICFILTERSENABLED2',pic:''},{av:'cmbavDynamicfiltersselector2'},{av:'AV20DynamicFiltersSelector2',fld:'vDYNAMICFILTERSSELECTOR2',pic:''},{av:'cmbavDynamicfiltersoperator2'},{av:'AV21DynamicFiltersOperator2',fld:'vDYNAMICFILTERSOPERATOR2',pic:'ZZZ9'},{av:'AV22TipLProdDsc2',fld:'vTIPLPRODDSC2',pic:''},{av:'cmbavDynamicfiltersselector3'},{av:'AV25DynamicFiltersSelector3',fld:'vDYNAMICFILTERSSELECTOR3',pic:''},{av:'cmbavDynamicfiltersoperator3'},{av:'AV26DynamicFiltersOperator3',fld:'vDYNAMICFILTERSOPERATOR3',pic:'ZZZ9'},{av:'AV27TipLProdDsc3',fld:'vTIPLPRODDSC3',pic:''},{av:'imgAdddynamicfilters1_Visible',ctrl:'ADDDYNAMICFILTERS1',prop:'Visible'},{av:'imgRemovedynamicfilters1_Visible',ctrl:'REMOVEDYNAMICFILTERS1',prop:'Visible'},{av:'imgAdddynamicfilters2_Visible',ctrl:'ADDDYNAMICFILTERS2',prop:'Visible'},{av:'imgRemovedynamicfilters2_Visible',ctrl:'REMOVEDYNAMICFILTERS2',prop:'Visible'},{av:'cmbavDynamicfiltersselector1'},{av:'AV15DynamicFiltersSelector1',fld:'vDYNAMICFILTERSSELECTOR1',pic:''},{av:'cmbavDynamicfiltersoperator1'},{av:'AV16DynamicFiltersOperator1',fld:'vDYNAMICFILTERSOPERATOR1',pic:'ZZZ9'},{av:'AV17TipLProdDsc1',fld:'vTIPLPRODDSC1',pic:''},{av:'AV18TipLDsc1',fld:'vTIPLDSC1',pic:''},{av:'lblJsdynamicfilters_Caption',ctrl:'JSDYNAMICFILTERS',prop:'Caption'},{av:'AV23TipLDsc2',fld:'vTIPLDSC2',pic:''},{av:'AV28TipLDsc3',fld:'vTIPLDSC3',pic:''},{av:'edtavTiplproddsc2_Visible',ctrl:'vTIPLPRODDSC2',prop:'Visible'},{av:'edtavTipldsc2_Visible',ctrl:'vTIPLDSC2',prop:'Visible'},{av:'edtavTiplproddsc3_Visible',ctrl:'vTIPLPRODDSC3',prop:'Visible'},{av:'edtavTipldsc3_Visible',ctrl:'vTIPLDSC3',prop:'Visible'},{av:'edtavTiplproddsc1_Visible',ctrl:'vTIPLPRODDSC1',prop:'Visible'},{av:'edtavTipldsc1_Visible',ctrl:'vTIPLDSC1',prop:'Visible'},{av:'AV59GridCurrentPage',fld:'vGRIDCURRENTPAGE',pic:'ZZZZZZZZZ9'},{av:'AV60GridPageCount',fld:'vGRIDPAGECOUNT',pic:'ZZZZZZZZZ9'},{av:'AV61GridAppliedFilters',fld:'vGRIDAPPLIEDFILTERS',pic:''}]}");
         setEventMetadata("VDYNAMICFILTERSSELECTOR3.CLICK","{handler:'E231R2',iparms:[{av:'cmbavDynamicfiltersselector3'},{av:'AV25DynamicFiltersSelector3',fld:'vDYNAMICFILTERSSELECTOR3',pic:''}]");
         setEventMetadata("VDYNAMICFILTERSSELECTOR3.CLICK",",oparms:[{av:'cmbavDynamicfiltersoperator3'},{av:'AV26DynamicFiltersOperator3',fld:'vDYNAMICFILTERSOPERATOR3',pic:'ZZZ9'},{av:'edtavTiplproddsc3_Visible',ctrl:'vTIPLPRODDSC3',prop:'Visible'},{av:'edtavTipldsc3_Visible',ctrl:'vTIPLDSC3',prop:'Visible'}]}");
         setEventMetadata("VGRIDACTIONS.CLICK","{handler:'E271R2',iparms:[{av:'cmbavGridactions'},{av:'AV62GridActions',fld:'vGRIDACTIONS',pic:'ZZZ9'},{av:'A202TipLCod',fld:'TIPLCOD',pic:'ZZZZZ9',hsh:true},{av:'A203TipLItem',fld:'TIPLITEM',pic:'ZZZZZ9',hsh:true}]");
         setEventMetadata("VGRIDACTIONS.CLICK",",oparms:[{av:'cmbavGridactions'},{av:'AV62GridActions',fld:'vGRIDACTIONS',pic:'ZZZ9'}]}");
         setEventMetadata("'DOINSERT'","{handler:'E181R2',iparms:[{av:'A202TipLCod',fld:'TIPLCOD',pic:'ZZZZZ9',hsh:true},{av:'A203TipLItem',fld:'TIPLITEM',pic:'ZZZZZ9',hsh:true}]");
         setEventMetadata("'DOINSERT'",",oparms:[]}");
         setEventMetadata("DDO_AGEXPORT.ONOPTIONCLICKED","{handler:'E131R2',iparms:[{av:'Ddo_agexport_Activeeventkey',ctrl:'DDO_AGEXPORT',prop:'ActiveEventKey'},{av:'AV67Pgmname',fld:'vPGMNAME',pic:'',hsh:true},{av:'AV43TFTipLDsc_Sel',fld:'vTFTIPLDSC_SEL',pic:''},{av:'AV39TFProdCod_Sel',fld:'vTFPRODCOD_SEL',pic:'@!'},{av:'AV41TFTipLProdDsc_Sel',fld:'vTFTIPLPRODDSC_SEL',pic:''},{av:'AV47TFCliCod_Sel',fld:'vTFCLICOD_SEL',pic:''},{av:'AV42TFTipLDsc',fld:'vTFTIPLDSC',pic:''},{av:'AV38TFProdCod',fld:'vTFPRODCOD',pic:'@!'},{av:'AV40TFTipLProdDsc',fld:'vTFTIPLPRODDSC',pic:''},{av:'AV46TFCliCod',fld:'vTFCLICOD',pic:''},{av:'AV44TFPreLis',fld:'vTFPRELIS',pic:'ZZZZ,ZZZ,ZZ9.9999'},{av:'AV50TFLisFech',fld:'vTFLISFECH',pic:''},{av:'AV45TFPreLis_To',fld:'vTFPRELIS_TO',pic:'ZZZZ,ZZZ,ZZ9.9999'},{av:'AV51TFLisFech_To',fld:'vTFLISFECH_TO',pic:''},{av:'AV13OrderedBy',fld:'vORDEREDBY',pic:'ZZZ9'},{av:'AV14OrderedDsc',fld:'vORDEREDDSC',pic:''},{av:'AV10GridState',fld:'vGRIDSTATE',pic:''},{av:'AV29DynamicFiltersRemoving',fld:'vDYNAMICFILTERSREMOVING',pic:''},{av:'cmbavDynamicfiltersselector1'},{av:'AV15DynamicFiltersSelector1',fld:'vDYNAMICFILTERSSELECTOR1',pic:''},{av:'cmbavDynamicfiltersselector2'},{av:'AV20DynamicFiltersSelector2',fld:'vDYNAMICFILTERSSELECTOR2',pic:''},{av:'cmbavDynamicfiltersselector3'},{av:'AV25DynamicFiltersSelector3',fld:'vDYNAMICFILTERSSELECTOR3',pic:''}]");
         setEventMetadata("DDO_AGEXPORT.ONOPTIONCLICKED",",oparms:[{av:'Innewwindow1_Target',ctrl:'INNEWWINDOW1',prop:'Target'},{av:'Innewwindow1_Height',ctrl:'INNEWWINDOW1',prop:'Height'},{av:'Innewwindow1_Width',ctrl:'INNEWWINDOW1',prop:'Width'},{av:'AV10GridState',fld:'vGRIDSTATE',pic:''},{av:'AV13OrderedBy',fld:'vORDEREDBY',pic:'ZZZ9'},{av:'AV14OrderedDsc',fld:'vORDEREDDSC',pic:''},{av:'AV50TFLisFech',fld:'vTFLISFECH',pic:''},{av:'AV51TFLisFech_To',fld:'vTFLISFECH_TO',pic:''},{av:'AV44TFPreLis',fld:'vTFPRELIS',pic:'ZZZZ,ZZZ,ZZ9.9999'},{av:'AV45TFPreLis_To',fld:'vTFPRELIS_TO',pic:'ZZZZ,ZZZ,ZZ9.9999'},{av:'AV47TFCliCod_Sel',fld:'vTFCLICOD_SEL',pic:''},{av:'AV46TFCliCod',fld:'vTFCLICOD',pic:''},{av:'AV41TFTipLProdDsc_Sel',fld:'vTFTIPLPRODDSC_SEL',pic:''},{av:'AV40TFTipLProdDsc',fld:'vTFTIPLPRODDSC',pic:''},{av:'AV39TFProdCod_Sel',fld:'vTFPRODCOD_SEL',pic:'@!'},{av:'AV38TFProdCod',fld:'vTFPRODCOD',pic:'@!'},{av:'AV43TFTipLDsc_Sel',fld:'vTFTIPLDSC_SEL',pic:''},{av:'AV42TFTipLDsc',fld:'vTFTIPLDSC',pic:''},{av:'Ddo_grid_Selectedvalue_set',ctrl:'DDO_GRID',prop:'SelectedValue_set'},{av:'Ddo_grid_Filteredtext_set',ctrl:'DDO_GRID',prop:'FilteredText_set'},{av:'Ddo_grid_Filteredtextto_set',ctrl:'DDO_GRID',prop:'FilteredTextTo_set'},{av:'subGrid_Rows',ctrl:'GRID',prop:'Rows'},{av:'GRID_nFirstRecordOnPage'},{av:'GRID_nEOF'},{av:'cmbavDynamicfiltersselector1'},{av:'AV15DynamicFiltersSelector1',fld:'vDYNAMICFILTERSSELECTOR1',pic:''},{av:'cmbavDynamicfiltersoperator1'},{av:'AV16DynamicFiltersOperator1',fld:'vDYNAMICFILTERSOPERATOR1',pic:'ZZZ9'},{av:'AV17TipLProdDsc1',fld:'vTIPLPRODDSC1',pic:''},{av:'AV18TipLDsc1',fld:'vTIPLDSC1',pic:''},{av:'cmbavDynamicfiltersselector2'},{av:'AV20DynamicFiltersSelector2',fld:'vDYNAMICFILTERSSELECTOR2',pic:''},{av:'cmbavDynamicfiltersoperator2'},{av:'AV21DynamicFiltersOperator2',fld:'vDYNAMICFILTERSOPERATOR2',pic:'ZZZ9'},{av:'AV22TipLProdDsc2',fld:'vTIPLPRODDSC2',pic:''},{av:'AV23TipLDsc2',fld:'vTIPLDSC2',pic:''},{av:'cmbavDynamicfiltersselector3'},{av:'AV25DynamicFiltersSelector3',fld:'vDYNAMICFILTERSSELECTOR3',pic:''},{av:'cmbavDynamicfiltersoperator3'},{av:'AV26DynamicFiltersOperator3',fld:'vDYNAMICFILTERSOPERATOR3',pic:'ZZZ9'},{av:'AV27TipLProdDsc3',fld:'vTIPLPRODDSC3',pic:''},{av:'AV28TipLDsc3',fld:'vTIPLDSC3',pic:''},{av:'AV19DynamicFiltersEnabled2',fld:'vDYNAMICFILTERSENABLED2',pic:''},{av:'AV24DynamicFiltersEnabled3',fld:'vDYNAMICFILTERSENABLED3',pic:''},{av:'AV67Pgmname',fld:'vPGMNAME',pic:'',hsh:true},{av:'AV30DynamicFiltersIgnoreFirst',fld:'vDYNAMICFILTERSIGNOREFIRST',pic:''},{av:'AV29DynamicFiltersRemoving',fld:'vDYNAMICFILTERSREMOVING',pic:''},{av:'Ddo_grid_Sortedstatus',ctrl:'DDO_GRID',prop:'SortedStatus'},{av:'imgAdddynamicfilters1_Visible',ctrl:'ADDDYNAMICFILTERS1',prop:'Visible'},{av:'imgRemovedynamicfilters1_Visible',ctrl:'REMOVEDYNAMICFILTERS1',prop:'Visible'},{av:'imgAdddynamicfilters2_Visible',ctrl:'ADDDYNAMICFILTERS2',prop:'Visible'},{av:'imgRemovedynamicfilters2_Visible',ctrl:'REMOVEDYNAMICFILTERS2',prop:'Visible'},{av:'lblJsdynamicfilters_Caption',ctrl:'JSDYNAMICFILTERS',prop:'Caption'},{av:'edtavTiplproddsc1_Visible',ctrl:'vTIPLPRODDSC1',prop:'Visible'},{av:'edtavTipldsc1_Visible',ctrl:'vTIPLDSC1',prop:'Visible'},{av:'edtavTiplproddsc2_Visible',ctrl:'vTIPLPRODDSC2',prop:'Visible'},{av:'edtavTipldsc2_Visible',ctrl:'vTIPLDSC2',prop:'Visible'},{av:'edtavTiplproddsc3_Visible',ctrl:'vTIPLPRODDSC3',prop:'Visible'},{av:'edtavTipldsc3_Visible',ctrl:'vTIPLDSC3',prop:'Visible'}]}");
         setEventMetadata("VALID_TIPLCOD","{handler:'Valid_Tiplcod',iparms:[]");
         setEventMetadata("VALID_TIPLCOD",",oparms:[]}");
         setEventMetadata("NULL","{handler:'Valid_Preliscred',iparms:[]");
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
         AV17TipLProdDsc1 = "";
         AV18TipLDsc1 = "";
         AV20DynamicFiltersSelector2 = "";
         AV22TipLProdDsc2 = "";
         AV23TipLDsc2 = "";
         AV25DynamicFiltersSelector3 = "";
         AV27TipLProdDsc3 = "";
         AV28TipLDsc3 = "";
         AV67Pgmname = "";
         AV42TFTipLDsc = "";
         AV43TFTipLDsc_Sel = "";
         AV38TFProdCod = "";
         AV39TFProdCod_Sel = "";
         AV40TFTipLProdDsc = "";
         AV41TFTipLProdDsc_Sel = "";
         AV46TFCliCod = "";
         AV47TFCliCod_Sel = "";
         AV50TFLisFech = DateTime.MinValue;
         AV51TFLisFech_To = DateTime.MinValue;
         AV10GridState = new GeneXus.Programs.wwpbaseobjects.SdtWWPGridState(context);
         sDynURL = "";
         FormProcess = "";
         bodyStyle = "";
         GXKey = "";
         AV61GridAppliedFilters = "";
         AV63AGExportData = new GXBaseCollection<GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTDropDownOptionsData_Item>( context, "Item", "");
         AV57DDO_TitleSettingsIcons = new GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTDropDownOptionsTitleSettingsIcons(context);
         AV53DDO_LisFechAuxDateTo = DateTime.MinValue;
         AV52DDO_LisFechAuxDate = DateTime.MinValue;
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
         A1912TipLDsc = "";
         A28ProdCod = "";
         A1913TipLProdDsc = "";
         A45CliCod = "";
         A1205LisFech = DateTime.MinValue;
         A161CliDsc = "";
         ucGridpaginationbar = new GXUserControl();
         ucDdo_agexport = new GXUserControl();
         lblJsdynamicfilters_Jsonclick = "";
         ucDdo_grid = new GXUserControl();
         ucInnewwindow1 = new GXUserControl();
         ucGrid_empowerer = new GXUserControl();
         AV54DDO_LisFechAuxDateText = "";
         ucTflisfech_rangepicker = new GXUserControl();
         sEvt = "";
         EvtGridId = "";
         EvtRowId = "";
         sEvtType = "";
         scmdbuf = "";
         lV70Configuracion_listaprecioswwds_3_tiplproddsc1 = "";
         lV71Configuracion_listaprecioswwds_4_tipldsc1 = "";
         lV75Configuracion_listaprecioswwds_8_tiplproddsc2 = "";
         lV76Configuracion_listaprecioswwds_9_tipldsc2 = "";
         lV80Configuracion_listaprecioswwds_13_tiplproddsc3 = "";
         lV81Configuracion_listaprecioswwds_14_tipldsc3 = "";
         lV82Configuracion_listaprecioswwds_15_tftipldsc = "";
         lV84Configuracion_listaprecioswwds_17_tfprodcod = "";
         lV86Configuracion_listaprecioswwds_19_tftiplproddsc = "";
         lV88Configuracion_listaprecioswwds_21_tfclicod = "";
         AV68Configuracion_listaprecioswwds_1_dynamicfiltersselector1 = "";
         AV70Configuracion_listaprecioswwds_3_tiplproddsc1 = "";
         AV71Configuracion_listaprecioswwds_4_tipldsc1 = "";
         AV73Configuracion_listaprecioswwds_6_dynamicfiltersselector2 = "";
         AV75Configuracion_listaprecioswwds_8_tiplproddsc2 = "";
         AV76Configuracion_listaprecioswwds_9_tipldsc2 = "";
         AV78Configuracion_listaprecioswwds_11_dynamicfiltersselector3 = "";
         AV80Configuracion_listaprecioswwds_13_tiplproddsc3 = "";
         AV81Configuracion_listaprecioswwds_14_tipldsc3 = "";
         AV83Configuracion_listaprecioswwds_16_tftipldsc_sel = "";
         AV82Configuracion_listaprecioswwds_15_tftipldsc = "";
         AV85Configuracion_listaprecioswwds_18_tfprodcod_sel = "";
         AV84Configuracion_listaprecioswwds_17_tfprodcod = "";
         AV87Configuracion_listaprecioswwds_20_tftiplproddsc_sel = "";
         AV86Configuracion_listaprecioswwds_19_tftiplproddsc = "";
         AV89Configuracion_listaprecioswwds_22_tfclicod_sel = "";
         AV88Configuracion_listaprecioswwds_21_tfclicod = "";
         AV92Configuracion_listaprecioswwds_25_tflisfech = DateTime.MinValue;
         AV93Configuracion_listaprecioswwds_26_tflisfech_to = DateTime.MinValue;
         H001R2_A1652PreLisCred = new decimal[1] ;
         H001R2_A161CliDsc = new string[] {""} ;
         H001R2_n161CliDsc = new bool[] {false} ;
         H001R2_A1205LisFech = new DateTime[] {DateTime.MinValue} ;
         H001R2_A1651PreLis = new decimal[1] ;
         H001R2_A45CliCod = new string[] {""} ;
         H001R2_n45CliCod = new bool[] {false} ;
         H001R2_A1913TipLProdDsc = new string[] {""} ;
         H001R2_A28ProdCod = new string[] {""} ;
         H001R2_A1912TipLDsc = new string[] {""} ;
         H001R2_A203TipLItem = new int[1] ;
         H001R2_A202TipLCod = new int[1] ;
         H001R3_AGRID_nRecordCount = new long[1] ;
         imgAdddynamicfilters1_Jsonclick = "";
         imgRemovedynamicfilters1_Jsonclick = "";
         imgAdddynamicfilters2_Jsonclick = "";
         imgRemovedynamicfilters2_Jsonclick = "";
         imgRemovedynamicfilters3_Jsonclick = "";
         AV64AGExportDataItem = new GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTDropDownOptionsData_Item(context);
         GXt_SdtDVB_SDTDropDownOptionsTitleSettingsIcons1 = new GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTDropDownOptionsTitleSettingsIcons(context);
         AV6WWPContext = new GeneXus.Programs.wwpbaseobjects.SdtWWPContext(context);
         GXEncryptionTmp = "";
         GridRow = new GXWebRow();
         AV33Session = context.GetSession();
         AV11GridStateFilterValue = new GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue(context);
         GXt_char5 = "";
         GXt_char4 = "";
         GXt_char3 = "";
         GXt_char2 = "";
         AV12GridStateDynamicFilter = new GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter(context);
         AV8TrnContext = new GeneXus.Programs.wwpbaseobjects.SdtWWPTransactionContext(context);
         AV7HTTPRequest = new GxHttpRequest( context);
         AV31ExcelFilename = "";
         AV32ErrorMessage = "";
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
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.configuracion.listapreciosww__default(),
            new Object[][] {
                new Object[] {
               H001R2_A1652PreLisCred, H001R2_A161CliDsc, H001R2_n161CliDsc, H001R2_A1205LisFech, H001R2_A1651PreLis, H001R2_A45CliCod, H001R2_n45CliCod, H001R2_A1913TipLProdDsc, H001R2_A28ProdCod, H001R2_A1912TipLDsc,
               H001R2_A203TipLItem, H001R2_A202TipLCod
               }
               , new Object[] {
               H001R3_AGRID_nRecordCount
               }
            }
         );
         AV67Pgmname = "Configuracion.ListaPreciosWW";
         /* GeneXus formulas. */
         AV67Pgmname = "Configuracion.ListaPreciosWW";
         context.Gx_err = 0;
      }

      private short GRID_nEOF ;
      private short nGotPars ;
      private short GxWebError ;
      private short AV16DynamicFiltersOperator1 ;
      private short AV21DynamicFiltersOperator2 ;
      private short AV26DynamicFiltersOperator3 ;
      private short AV13OrderedBy ;
      private short initialized ;
      private short gxajaxcallmode ;
      private short wbEnd ;
      private short wbStart ;
      private short subGrid_Backcolorstyle ;
      private short subGrid_Titlebackstyle ;
      private short subGrid_Sortable ;
      private short AV62GridActions ;
      private short subGrid_Allowselection ;
      private short subGrid_Allowhovering ;
      private short subGrid_Allowcollapsing ;
      private short subGrid_Collapsed ;
      private short nDonePA ;
      private short AV69Configuracion_listaprecioswwds_2_dynamicfiltersoperator1 ;
      private short AV74Configuracion_listaprecioswwds_7_dynamicfiltersoperator2 ;
      private short AV79Configuracion_listaprecioswwds_12_dynamicfiltersoperator3 ;
      private short nGXWrapped ;
      private short subGrid_Backstyle ;
      private int subGrid_Rows ;
      private int Gridpaginationbar_Rowsperpageselectedvalue ;
      private int nRC_GXsfl_110 ;
      private int nGXsfl_110_idx=1 ;
      private int Gridpaginationbar_Pagestoshow ;
      private int subGrid_Titlebackcolor ;
      private int subGrid_Allbackcolor ;
      private int A202TipLCod ;
      private int A203TipLItem ;
      private int subGrid_Selectedindex ;
      private int subGrid_Selectioncolor ;
      private int subGrid_Hoveringcolor ;
      private int subGrid_Islastpage ;
      private int GXPagingFrom2 ;
      private int GXPagingTo2 ;
      private int AV58PageToGo ;
      private int imgAdddynamicfilters1_Visible ;
      private int imgRemovedynamicfilters1_Visible ;
      private int imgAdddynamicfilters2_Visible ;
      private int imgRemovedynamicfilters2_Visible ;
      private int edtavTiplproddsc1_Visible ;
      private int edtavTipldsc1_Visible ;
      private int edtavTiplproddsc2_Visible ;
      private int edtavTipldsc2_Visible ;
      private int edtavTiplproddsc3_Visible ;
      private int edtavTipldsc3_Visible ;
      private int AV94GXV1 ;
      private int edtavTiplproddsc3_Enabled ;
      private int edtavTipldsc3_Enabled ;
      private int edtavTiplproddsc2_Enabled ;
      private int edtavTipldsc2_Enabled ;
      private int edtavTiplproddsc1_Enabled ;
      private int edtavTipldsc1_Enabled ;
      private int idxLst ;
      private int subGrid_Backcolor ;
      private long GRID_nFirstRecordOnPage ;
      private long AV59GridCurrentPage ;
      private long AV60GridPageCount ;
      private long GRID_nCurrentRecord ;
      private long GRID_nRecordCount ;
      private decimal AV44TFPreLis ;
      private decimal AV45TFPreLis_To ;
      private decimal A1651PreLis ;
      private decimal A1652PreLisCred ;
      private decimal AV90Configuracion_listaprecioswwds_23_tfprelis ;
      private decimal AV91Configuracion_listaprecioswwds_24_tfprelis_to ;
      private string Gridpaginationbar_Selectedpage ;
      private string Ddo_grid_Activeeventkey ;
      private string Ddo_grid_Selectedvalue_get ;
      private string Ddo_grid_Filteredtextto_get ;
      private string Ddo_grid_Filteredtext_get ;
      private string Ddo_grid_Selectedcolumn ;
      private string Ddo_agexport_Activeeventkey ;
      private string gxfirstwebparm ;
      private string gxfirstwebparm_bkp ;
      private string sGXsfl_110_idx="0001" ;
      private string AV17TipLProdDsc1 ;
      private string AV18TipLDsc1 ;
      private string AV22TipLProdDsc2 ;
      private string AV23TipLDsc2 ;
      private string AV27TipLProdDsc3 ;
      private string AV28TipLDsc3 ;
      private string AV67Pgmname ;
      private string AV42TFTipLDsc ;
      private string AV43TFTipLDsc_Sel ;
      private string AV38TFProdCod ;
      private string AV39TFProdCod_Sel ;
      private string AV40TFTipLProdDsc ;
      private string AV41TFTipLProdDsc_Sel ;
      private string AV46TFCliCod ;
      private string AV47TFCliCod_Sel ;
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
      private string A1912TipLDsc ;
      private string edtTipLDsc_Link ;
      private string A28ProdCod ;
      private string A1913TipLProdDsc ;
      private string edtTipLProdDsc_Link ;
      private string A45CliCod ;
      private string A161CliDsc ;
      private string Gridpaginationbar_Internalname ;
      private string divHtml_bottomauxiliarcontrols_Internalname ;
      private string Ddo_agexport_Internalname ;
      private string lblJsdynamicfilters_Internalname ;
      private string lblJsdynamicfilters_Caption ;
      private string lblJsdynamicfilters_Jsonclick ;
      private string Ddo_grid_Internalname ;
      private string Innewwindow1_Internalname ;
      private string Grid_empowerer_Internalname ;
      private string divDdo_lisfechauxdates_Internalname ;
      private string edtavDdo_lisfechauxdatetext_Internalname ;
      private string edtavDdo_lisfechauxdatetext_Jsonclick ;
      private string Tflisfech_rangepicker_Internalname ;
      private string sEvt ;
      private string EvtGridId ;
      private string EvtRowId ;
      private string sEvtType ;
      private string cmbavGridactions_Internalname ;
      private string edtTipLCod_Internalname ;
      private string edtTipLItem_Internalname ;
      private string edtTipLDsc_Internalname ;
      private string edtProdCod_Internalname ;
      private string edtTipLProdDsc_Internalname ;
      private string edtCliCod_Internalname ;
      private string edtPreLis_Internalname ;
      private string edtLisFech_Internalname ;
      private string edtCliDsc_Internalname ;
      private string edtPreLisCred_Internalname ;
      private string cmbavDynamicfiltersselector1_Internalname ;
      private string cmbavDynamicfiltersoperator1_Internalname ;
      private string cmbavDynamicfiltersselector2_Internalname ;
      private string cmbavDynamicfiltersoperator2_Internalname ;
      private string cmbavDynamicfiltersselector3_Internalname ;
      private string cmbavDynamicfiltersoperator3_Internalname ;
      private string scmdbuf ;
      private string lV70Configuracion_listaprecioswwds_3_tiplproddsc1 ;
      private string lV71Configuracion_listaprecioswwds_4_tipldsc1 ;
      private string lV75Configuracion_listaprecioswwds_8_tiplproddsc2 ;
      private string lV76Configuracion_listaprecioswwds_9_tipldsc2 ;
      private string lV80Configuracion_listaprecioswwds_13_tiplproddsc3 ;
      private string lV81Configuracion_listaprecioswwds_14_tipldsc3 ;
      private string lV82Configuracion_listaprecioswwds_15_tftipldsc ;
      private string lV84Configuracion_listaprecioswwds_17_tfprodcod ;
      private string lV86Configuracion_listaprecioswwds_19_tftiplproddsc ;
      private string lV88Configuracion_listaprecioswwds_21_tfclicod ;
      private string AV70Configuracion_listaprecioswwds_3_tiplproddsc1 ;
      private string AV71Configuracion_listaprecioswwds_4_tipldsc1 ;
      private string AV75Configuracion_listaprecioswwds_8_tiplproddsc2 ;
      private string AV76Configuracion_listaprecioswwds_9_tipldsc2 ;
      private string AV80Configuracion_listaprecioswwds_13_tiplproddsc3 ;
      private string AV81Configuracion_listaprecioswwds_14_tipldsc3 ;
      private string AV83Configuracion_listaprecioswwds_16_tftipldsc_sel ;
      private string AV82Configuracion_listaprecioswwds_15_tftipldsc ;
      private string AV85Configuracion_listaprecioswwds_18_tfprodcod_sel ;
      private string AV84Configuracion_listaprecioswwds_17_tfprodcod ;
      private string AV87Configuracion_listaprecioswwds_20_tftiplproddsc_sel ;
      private string AV86Configuracion_listaprecioswwds_19_tftiplproddsc ;
      private string AV89Configuracion_listaprecioswwds_22_tfclicod_sel ;
      private string AV88Configuracion_listaprecioswwds_21_tfclicod ;
      private string edtavTiplproddsc1_Internalname ;
      private string edtavTipldsc1_Internalname ;
      private string edtavTiplproddsc2_Internalname ;
      private string edtavTipldsc2_Internalname ;
      private string edtavTiplproddsc3_Internalname ;
      private string edtavTipldsc3_Internalname ;
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
      private string GXt_char5 ;
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
      private string cellFilter_tiplproddsc3_cell_Internalname ;
      private string edtavTiplproddsc3_Jsonclick ;
      private string cellFilter_tipldsc3_cell_Internalname ;
      private string edtavTipldsc3_Jsonclick ;
      private string cellDynamicfilters_removefilter3_cell_Internalname ;
      private string sImgUrl ;
      private string tblTablemergeddynamicfilters2_Internalname ;
      private string cmbavDynamicfiltersoperator2_Jsonclick ;
      private string cellFilter_tiplproddsc2_cell_Internalname ;
      private string edtavTiplproddsc2_Jsonclick ;
      private string cellFilter_tipldsc2_cell_Internalname ;
      private string edtavTipldsc2_Jsonclick ;
      private string cellDynamicfilters_addfilter2_cell_Internalname ;
      private string cellDynamicfilters_removefilter2_cell_Internalname ;
      private string tblTablemergeddynamicfilters1_Internalname ;
      private string cmbavDynamicfiltersoperator1_Jsonclick ;
      private string cellFilter_tiplproddsc1_cell_Internalname ;
      private string edtavTiplproddsc1_Jsonclick ;
      private string cellFilter_tipldsc1_cell_Internalname ;
      private string edtavTipldsc1_Jsonclick ;
      private string cellDynamicfilters_addfilter1_cell_Internalname ;
      private string cellDynamicfilters_removefilter1_cell_Internalname ;
      private string sGXsfl_110_fel_idx="0001" ;
      private string GXCCtl ;
      private string cmbavGridactions_Jsonclick ;
      private string ROClassString ;
      private string edtTipLCod_Jsonclick ;
      private string edtTipLItem_Jsonclick ;
      private string edtTipLDsc_Jsonclick ;
      private string edtProdCod_Jsonclick ;
      private string edtTipLProdDsc_Jsonclick ;
      private string edtCliCod_Jsonclick ;
      private string edtPreLis_Jsonclick ;
      private string edtLisFech_Jsonclick ;
      private string edtCliDsc_Jsonclick ;
      private string edtPreLisCred_Jsonclick ;
      private DateTime AV50TFLisFech ;
      private DateTime AV51TFLisFech_To ;
      private DateTime AV53DDO_LisFechAuxDateTo ;
      private DateTime AV52DDO_LisFechAuxDate ;
      private DateTime A1205LisFech ;
      private DateTime AV92Configuracion_listaprecioswwds_25_tflisfech ;
      private DateTime AV93Configuracion_listaprecioswwds_26_tflisfech_to ;
      private bool entryPointCalled ;
      private bool toggleJsOutput ;
      private bool AV19DynamicFiltersEnabled2 ;
      private bool AV24DynamicFiltersEnabled3 ;
      private bool AV14OrderedDsc ;
      private bool AV30DynamicFiltersIgnoreFirst ;
      private bool AV29DynamicFiltersRemoving ;
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
      private bool n45CliCod ;
      private bool n161CliDsc ;
      private bool bGXsfl_110_Refreshing=false ;
      private bool gxdyncontrolsrefreshing ;
      private bool AV72Configuracion_listaprecioswwds_5_dynamicfiltersenabled2 ;
      private bool AV77Configuracion_listaprecioswwds_10_dynamicfiltersenabled3 ;
      private bool returnInSub ;
      private bool gx_refresh_fired ;
      private string AV15DynamicFiltersSelector1 ;
      private string AV20DynamicFiltersSelector2 ;
      private string AV25DynamicFiltersSelector3 ;
      private string AV61GridAppliedFilters ;
      private string AV54DDO_LisFechAuxDateText ;
      private string AV68Configuracion_listaprecioswwds_1_dynamicfiltersselector1 ;
      private string AV73Configuracion_listaprecioswwds_6_dynamicfiltersselector2 ;
      private string AV78Configuracion_listaprecioswwds_11_dynamicfiltersselector3 ;
      private string AV31ExcelFilename ;
      private string AV32ErrorMessage ;
      private IGxSession AV33Session ;
      private GXWebGrid GridContainer ;
      private GXWebRow GridRow ;
      private GXWebColumn GridColumn ;
      private GXUserControl ucDvpanel_tableheader ;
      private GXUserControl ucGridpaginationbar ;
      private GXUserControl ucDdo_agexport ;
      private GXUserControl ucDdo_grid ;
      private GXUserControl ucInnewwindow1 ;
      private GXUserControl ucGrid_empowerer ;
      private GXUserControl ucTflisfech_rangepicker ;
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
      private decimal[] H001R2_A1652PreLisCred ;
      private string[] H001R2_A161CliDsc ;
      private bool[] H001R2_n161CliDsc ;
      private DateTime[] H001R2_A1205LisFech ;
      private decimal[] H001R2_A1651PreLis ;
      private string[] H001R2_A45CliCod ;
      private bool[] H001R2_n45CliCod ;
      private string[] H001R2_A1913TipLProdDsc ;
      private string[] H001R2_A28ProdCod ;
      private string[] H001R2_A1912TipLDsc ;
      private int[] H001R2_A203TipLItem ;
      private int[] H001R2_A202TipLCod ;
      private long[] H001R3_AGRID_nRecordCount ;
      private msglist BackMsgLst ;
      private msglist LclMsgLst ;
      private GxHttpRequest AV7HTTPRequest ;
      private GXBaseCollection<GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTDropDownOptionsData_Item> AV63AGExportData ;
      private GXWebForm Form ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPContext AV6WWPContext ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPTransactionContext AV8TrnContext ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPGridState AV10GridState ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue AV11GridStateFilterValue ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter AV12GridStateDynamicFilter ;
      private GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTDropDownOptionsTitleSettingsIcons AV57DDO_TitleSettingsIcons ;
      private GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTDropDownOptionsTitleSettingsIcons GXt_SdtDVB_SDTDropDownOptionsTitleSettingsIcons1 ;
      private GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTDropDownOptionsData_Item AV64AGExportDataItem ;
   }

   public class listapreciosww__default : DataStoreHelperBase, IDataStoreHelper
   {
      protected Object[] conditional_H001R2( IGxContext context ,
                                             string AV68Configuracion_listaprecioswwds_1_dynamicfiltersselector1 ,
                                             short AV69Configuracion_listaprecioswwds_2_dynamicfiltersoperator1 ,
                                             string AV70Configuracion_listaprecioswwds_3_tiplproddsc1 ,
                                             string AV71Configuracion_listaprecioswwds_4_tipldsc1 ,
                                             bool AV72Configuracion_listaprecioswwds_5_dynamicfiltersenabled2 ,
                                             string AV73Configuracion_listaprecioswwds_6_dynamicfiltersselector2 ,
                                             short AV74Configuracion_listaprecioswwds_7_dynamicfiltersoperator2 ,
                                             string AV75Configuracion_listaprecioswwds_8_tiplproddsc2 ,
                                             string AV76Configuracion_listaprecioswwds_9_tipldsc2 ,
                                             bool AV77Configuracion_listaprecioswwds_10_dynamicfiltersenabled3 ,
                                             string AV78Configuracion_listaprecioswwds_11_dynamicfiltersselector3 ,
                                             short AV79Configuracion_listaprecioswwds_12_dynamicfiltersoperator3 ,
                                             string AV80Configuracion_listaprecioswwds_13_tiplproddsc3 ,
                                             string AV81Configuracion_listaprecioswwds_14_tipldsc3 ,
                                             string AV83Configuracion_listaprecioswwds_16_tftipldsc_sel ,
                                             string AV82Configuracion_listaprecioswwds_15_tftipldsc ,
                                             string AV85Configuracion_listaprecioswwds_18_tfprodcod_sel ,
                                             string AV84Configuracion_listaprecioswwds_17_tfprodcod ,
                                             string AV87Configuracion_listaprecioswwds_20_tftiplproddsc_sel ,
                                             string AV86Configuracion_listaprecioswwds_19_tftiplproddsc ,
                                             string AV89Configuracion_listaprecioswwds_22_tfclicod_sel ,
                                             string AV88Configuracion_listaprecioswwds_21_tfclicod ,
                                             decimal AV90Configuracion_listaprecioswwds_23_tfprelis ,
                                             decimal AV91Configuracion_listaprecioswwds_24_tfprelis_to ,
                                             DateTime AV92Configuracion_listaprecioswwds_25_tflisfech ,
                                             DateTime AV93Configuracion_listaprecioswwds_26_tflisfech_to ,
                                             string A1913TipLProdDsc ,
                                             string A1912TipLDsc ,
                                             string A28ProdCod ,
                                             string A45CliCod ,
                                             decimal A1651PreLis ,
                                             DateTime A1205LisFech ,
                                             short AV13OrderedBy ,
                                             bool AV14OrderedDsc )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int6 = new short[27];
         Object[] GXv_Object7 = new Object[2];
         string sSelectString;
         string sFromString;
         string sOrderString;
         sSelectString = " T1.[PreLisCred], T1.[CliDsc], T1.[LisFech], T1.[PreLis], T1.[CliCod], T1.[TipLProdDsc], T1.[ProdCod], T2.[TipLDsc], T1.[TipLItem], T1.[TipLCod]";
         sFromString = " FROM ([CLISTAPRECIOS] T1 INNER JOIN [CTIPOSLISTAS] T2 ON T2.[TipLCod] = T1.[TipLCod])";
         sOrderString = "";
         if ( ( StringUtil.StrCmp(AV68Configuracion_listaprecioswwds_1_dynamicfiltersselector1, "TIPLPRODDSC") == 0 ) && ( AV69Configuracion_listaprecioswwds_2_dynamicfiltersoperator1 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV70Configuracion_listaprecioswwds_3_tiplproddsc1)) ) )
         {
            AddWhere(sWhereString, "(T1.[TipLProdDsc] like @lV70Configuracion_listaprecioswwds_3_tiplproddsc1)");
         }
         else
         {
            GXv_int6[0] = 1;
         }
         if ( ( StringUtil.StrCmp(AV68Configuracion_listaprecioswwds_1_dynamicfiltersselector1, "TIPLPRODDSC") == 0 ) && ( AV69Configuracion_listaprecioswwds_2_dynamicfiltersoperator1 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV70Configuracion_listaprecioswwds_3_tiplproddsc1)) ) )
         {
            AddWhere(sWhereString, "(T1.[TipLProdDsc] like '%' + @lV70Configuracion_listaprecioswwds_3_tiplproddsc1)");
         }
         else
         {
            GXv_int6[1] = 1;
         }
         if ( ( StringUtil.StrCmp(AV68Configuracion_listaprecioswwds_1_dynamicfiltersselector1, "TIPLDSC") == 0 ) && ( AV69Configuracion_listaprecioswwds_2_dynamicfiltersoperator1 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV71Configuracion_listaprecioswwds_4_tipldsc1)) ) )
         {
            AddWhere(sWhereString, "(T2.[TipLDsc] like @lV71Configuracion_listaprecioswwds_4_tipldsc1)");
         }
         else
         {
            GXv_int6[2] = 1;
         }
         if ( ( StringUtil.StrCmp(AV68Configuracion_listaprecioswwds_1_dynamicfiltersselector1, "TIPLDSC") == 0 ) && ( AV69Configuracion_listaprecioswwds_2_dynamicfiltersoperator1 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV71Configuracion_listaprecioswwds_4_tipldsc1)) ) )
         {
            AddWhere(sWhereString, "(T2.[TipLDsc] like '%' + @lV71Configuracion_listaprecioswwds_4_tipldsc1)");
         }
         else
         {
            GXv_int6[3] = 1;
         }
         if ( AV72Configuracion_listaprecioswwds_5_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV73Configuracion_listaprecioswwds_6_dynamicfiltersselector2, "TIPLPRODDSC") == 0 ) && ( AV74Configuracion_listaprecioswwds_7_dynamicfiltersoperator2 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV75Configuracion_listaprecioswwds_8_tiplproddsc2)) ) )
         {
            AddWhere(sWhereString, "(T1.[TipLProdDsc] like @lV75Configuracion_listaprecioswwds_8_tiplproddsc2)");
         }
         else
         {
            GXv_int6[4] = 1;
         }
         if ( AV72Configuracion_listaprecioswwds_5_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV73Configuracion_listaprecioswwds_6_dynamicfiltersselector2, "TIPLPRODDSC") == 0 ) && ( AV74Configuracion_listaprecioswwds_7_dynamicfiltersoperator2 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV75Configuracion_listaprecioswwds_8_tiplproddsc2)) ) )
         {
            AddWhere(sWhereString, "(T1.[TipLProdDsc] like '%' + @lV75Configuracion_listaprecioswwds_8_tiplproddsc2)");
         }
         else
         {
            GXv_int6[5] = 1;
         }
         if ( AV72Configuracion_listaprecioswwds_5_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV73Configuracion_listaprecioswwds_6_dynamicfiltersselector2, "TIPLDSC") == 0 ) && ( AV74Configuracion_listaprecioswwds_7_dynamicfiltersoperator2 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV76Configuracion_listaprecioswwds_9_tipldsc2)) ) )
         {
            AddWhere(sWhereString, "(T2.[TipLDsc] like @lV76Configuracion_listaprecioswwds_9_tipldsc2)");
         }
         else
         {
            GXv_int6[6] = 1;
         }
         if ( AV72Configuracion_listaprecioswwds_5_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV73Configuracion_listaprecioswwds_6_dynamicfiltersselector2, "TIPLDSC") == 0 ) && ( AV74Configuracion_listaprecioswwds_7_dynamicfiltersoperator2 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV76Configuracion_listaprecioswwds_9_tipldsc2)) ) )
         {
            AddWhere(sWhereString, "(T2.[TipLDsc] like '%' + @lV76Configuracion_listaprecioswwds_9_tipldsc2)");
         }
         else
         {
            GXv_int6[7] = 1;
         }
         if ( AV77Configuracion_listaprecioswwds_10_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV78Configuracion_listaprecioswwds_11_dynamicfiltersselector3, "TIPLPRODDSC") == 0 ) && ( AV79Configuracion_listaprecioswwds_12_dynamicfiltersoperator3 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV80Configuracion_listaprecioswwds_13_tiplproddsc3)) ) )
         {
            AddWhere(sWhereString, "(T1.[TipLProdDsc] like @lV80Configuracion_listaprecioswwds_13_tiplproddsc3)");
         }
         else
         {
            GXv_int6[8] = 1;
         }
         if ( AV77Configuracion_listaprecioswwds_10_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV78Configuracion_listaprecioswwds_11_dynamicfiltersselector3, "TIPLPRODDSC") == 0 ) && ( AV79Configuracion_listaprecioswwds_12_dynamicfiltersoperator3 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV80Configuracion_listaprecioswwds_13_tiplproddsc3)) ) )
         {
            AddWhere(sWhereString, "(T1.[TipLProdDsc] like '%' + @lV80Configuracion_listaprecioswwds_13_tiplproddsc3)");
         }
         else
         {
            GXv_int6[9] = 1;
         }
         if ( AV77Configuracion_listaprecioswwds_10_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV78Configuracion_listaprecioswwds_11_dynamicfiltersselector3, "TIPLDSC") == 0 ) && ( AV79Configuracion_listaprecioswwds_12_dynamicfiltersoperator3 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV81Configuracion_listaprecioswwds_14_tipldsc3)) ) )
         {
            AddWhere(sWhereString, "(T2.[TipLDsc] like @lV81Configuracion_listaprecioswwds_14_tipldsc3)");
         }
         else
         {
            GXv_int6[10] = 1;
         }
         if ( AV77Configuracion_listaprecioswwds_10_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV78Configuracion_listaprecioswwds_11_dynamicfiltersselector3, "TIPLDSC") == 0 ) && ( AV79Configuracion_listaprecioswwds_12_dynamicfiltersoperator3 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV81Configuracion_listaprecioswwds_14_tipldsc3)) ) )
         {
            AddWhere(sWhereString, "(T2.[TipLDsc] like '%' + @lV81Configuracion_listaprecioswwds_14_tipldsc3)");
         }
         else
         {
            GXv_int6[11] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV83Configuracion_listaprecioswwds_16_tftipldsc_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV82Configuracion_listaprecioswwds_15_tftipldsc)) ) )
         {
            AddWhere(sWhereString, "(T2.[TipLDsc] like @lV82Configuracion_listaprecioswwds_15_tftipldsc)");
         }
         else
         {
            GXv_int6[12] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV83Configuracion_listaprecioswwds_16_tftipldsc_sel)) )
         {
            AddWhere(sWhereString, "(T2.[TipLDsc] = @AV83Configuracion_listaprecioswwds_16_tftipldsc_sel)");
         }
         else
         {
            GXv_int6[13] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV85Configuracion_listaprecioswwds_18_tfprodcod_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV84Configuracion_listaprecioswwds_17_tfprodcod)) ) )
         {
            AddWhere(sWhereString, "(T1.[ProdCod] like @lV84Configuracion_listaprecioswwds_17_tfprodcod)");
         }
         else
         {
            GXv_int6[14] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV85Configuracion_listaprecioswwds_18_tfprodcod_sel)) )
         {
            AddWhere(sWhereString, "(T1.[ProdCod] = @AV85Configuracion_listaprecioswwds_18_tfprodcod_sel)");
         }
         else
         {
            GXv_int6[15] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV87Configuracion_listaprecioswwds_20_tftiplproddsc_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV86Configuracion_listaprecioswwds_19_tftiplproddsc)) ) )
         {
            AddWhere(sWhereString, "(T1.[TipLProdDsc] like @lV86Configuracion_listaprecioswwds_19_tftiplproddsc)");
         }
         else
         {
            GXv_int6[16] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV87Configuracion_listaprecioswwds_20_tftiplproddsc_sel)) )
         {
            AddWhere(sWhereString, "(T1.[TipLProdDsc] = @AV87Configuracion_listaprecioswwds_20_tftiplproddsc_sel)");
         }
         else
         {
            GXv_int6[17] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV89Configuracion_listaprecioswwds_22_tfclicod_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV88Configuracion_listaprecioswwds_21_tfclicod)) ) )
         {
            AddWhere(sWhereString, "(T1.[CliCod] like @lV88Configuracion_listaprecioswwds_21_tfclicod)");
         }
         else
         {
            GXv_int6[18] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV89Configuracion_listaprecioswwds_22_tfclicod_sel)) )
         {
            AddWhere(sWhereString, "(T1.[CliCod] = @AV89Configuracion_listaprecioswwds_22_tfclicod_sel)");
         }
         else
         {
            GXv_int6[19] = 1;
         }
         if ( ! (Convert.ToDecimal(0)==AV90Configuracion_listaprecioswwds_23_tfprelis) )
         {
            AddWhere(sWhereString, "(T1.[PreLis] >= @AV90Configuracion_listaprecioswwds_23_tfprelis)");
         }
         else
         {
            GXv_int6[20] = 1;
         }
         if ( ! (Convert.ToDecimal(0)==AV91Configuracion_listaprecioswwds_24_tfprelis_to) )
         {
            AddWhere(sWhereString, "(T1.[PreLis] <= @AV91Configuracion_listaprecioswwds_24_tfprelis_to)");
         }
         else
         {
            GXv_int6[21] = 1;
         }
         if ( ! (DateTime.MinValue==AV92Configuracion_listaprecioswwds_25_tflisfech) )
         {
            AddWhere(sWhereString, "(T1.[LisFech] >= @AV92Configuracion_listaprecioswwds_25_tflisfech)");
         }
         else
         {
            GXv_int6[22] = 1;
         }
         if ( ! (DateTime.MinValue==AV93Configuracion_listaprecioswwds_26_tflisfech_to) )
         {
            AddWhere(sWhereString, "(T1.[LisFech] <= @AV93Configuracion_listaprecioswwds_26_tflisfech_to)");
         }
         else
         {
            GXv_int6[23] = 1;
         }
         if ( AV13OrderedBy == 1 )
         {
            sOrderString += " ORDER BY T1.[TipLCod], T1.[ProdCod]";
         }
         else if ( ( AV13OrderedBy == 2 ) && ! AV14OrderedDsc )
         {
            sOrderString += " ORDER BY T2.[TipLDsc]";
         }
         else if ( ( AV13OrderedBy == 2 ) && ( AV14OrderedDsc ) )
         {
            sOrderString += " ORDER BY T2.[TipLDsc] DESC";
         }
         else if ( ( AV13OrderedBy == 3 ) && ! AV14OrderedDsc )
         {
            sOrderString += " ORDER BY T1.[ProdCod]";
         }
         else if ( ( AV13OrderedBy == 3 ) && ( AV14OrderedDsc ) )
         {
            sOrderString += " ORDER BY T1.[ProdCod] DESC";
         }
         else if ( ( AV13OrderedBy == 4 ) && ! AV14OrderedDsc )
         {
            sOrderString += " ORDER BY T1.[TipLProdDsc]";
         }
         else if ( ( AV13OrderedBy == 4 ) && ( AV14OrderedDsc ) )
         {
            sOrderString += " ORDER BY T1.[TipLProdDsc] DESC";
         }
         else if ( ( AV13OrderedBy == 5 ) && ! AV14OrderedDsc )
         {
            sOrderString += " ORDER BY T1.[CliCod]";
         }
         else if ( ( AV13OrderedBy == 5 ) && ( AV14OrderedDsc ) )
         {
            sOrderString += " ORDER BY T1.[CliCod] DESC";
         }
         else if ( ( AV13OrderedBy == 6 ) && ! AV14OrderedDsc )
         {
            sOrderString += " ORDER BY T1.[PreLis]";
         }
         else if ( ( AV13OrderedBy == 6 ) && ( AV14OrderedDsc ) )
         {
            sOrderString += " ORDER BY T1.[PreLis] DESC";
         }
         else if ( ( AV13OrderedBy == 7 ) && ! AV14OrderedDsc )
         {
            sOrderString += " ORDER BY T1.[LisFech]";
         }
         else if ( ( AV13OrderedBy == 7 ) && ( AV14OrderedDsc ) )
         {
            sOrderString += " ORDER BY T1.[LisFech] DESC";
         }
         else if ( true )
         {
            sOrderString += " ORDER BY T1.[TipLCod], T1.[TipLItem]";
         }
         scmdbuf = "SELECT " + sSelectString + sFromString + sWhereString + sOrderString + "" + " OFFSET " + "@GXPagingFrom2" + " ROWS FETCH NEXT CAST((SELECT CASE WHEN " + "@GXPagingTo2" + " > 0 THEN " + "@GXPagingTo2" + " ELSE 1e9 END) AS INTEGER) ROWS ONLY";
         GXv_Object7[0] = scmdbuf;
         GXv_Object7[1] = GXv_int6;
         return GXv_Object7 ;
      }

      protected Object[] conditional_H001R3( IGxContext context ,
                                             string AV68Configuracion_listaprecioswwds_1_dynamicfiltersselector1 ,
                                             short AV69Configuracion_listaprecioswwds_2_dynamicfiltersoperator1 ,
                                             string AV70Configuracion_listaprecioswwds_3_tiplproddsc1 ,
                                             string AV71Configuracion_listaprecioswwds_4_tipldsc1 ,
                                             bool AV72Configuracion_listaprecioswwds_5_dynamicfiltersenabled2 ,
                                             string AV73Configuracion_listaprecioswwds_6_dynamicfiltersselector2 ,
                                             short AV74Configuracion_listaprecioswwds_7_dynamicfiltersoperator2 ,
                                             string AV75Configuracion_listaprecioswwds_8_tiplproddsc2 ,
                                             string AV76Configuracion_listaprecioswwds_9_tipldsc2 ,
                                             bool AV77Configuracion_listaprecioswwds_10_dynamicfiltersenabled3 ,
                                             string AV78Configuracion_listaprecioswwds_11_dynamicfiltersselector3 ,
                                             short AV79Configuracion_listaprecioswwds_12_dynamicfiltersoperator3 ,
                                             string AV80Configuracion_listaprecioswwds_13_tiplproddsc3 ,
                                             string AV81Configuracion_listaprecioswwds_14_tipldsc3 ,
                                             string AV83Configuracion_listaprecioswwds_16_tftipldsc_sel ,
                                             string AV82Configuracion_listaprecioswwds_15_tftipldsc ,
                                             string AV85Configuracion_listaprecioswwds_18_tfprodcod_sel ,
                                             string AV84Configuracion_listaprecioswwds_17_tfprodcod ,
                                             string AV87Configuracion_listaprecioswwds_20_tftiplproddsc_sel ,
                                             string AV86Configuracion_listaprecioswwds_19_tftiplproddsc ,
                                             string AV89Configuracion_listaprecioswwds_22_tfclicod_sel ,
                                             string AV88Configuracion_listaprecioswwds_21_tfclicod ,
                                             decimal AV90Configuracion_listaprecioswwds_23_tfprelis ,
                                             decimal AV91Configuracion_listaprecioswwds_24_tfprelis_to ,
                                             DateTime AV92Configuracion_listaprecioswwds_25_tflisfech ,
                                             DateTime AV93Configuracion_listaprecioswwds_26_tflisfech_to ,
                                             string A1913TipLProdDsc ,
                                             string A1912TipLDsc ,
                                             string A28ProdCod ,
                                             string A45CliCod ,
                                             decimal A1651PreLis ,
                                             DateTime A1205LisFech ,
                                             short AV13OrderedBy ,
                                             bool AV14OrderedDsc )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int8 = new short[24];
         Object[] GXv_Object9 = new Object[2];
         scmdbuf = "SELECT COUNT(*) FROM ([CLISTAPRECIOS] T1 INNER JOIN [CTIPOSLISTAS] T2 ON T2.[TipLCod] = T1.[TipLCod])";
         if ( ( StringUtil.StrCmp(AV68Configuracion_listaprecioswwds_1_dynamicfiltersselector1, "TIPLPRODDSC") == 0 ) && ( AV69Configuracion_listaprecioswwds_2_dynamicfiltersoperator1 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV70Configuracion_listaprecioswwds_3_tiplproddsc1)) ) )
         {
            AddWhere(sWhereString, "(T1.[TipLProdDsc] like @lV70Configuracion_listaprecioswwds_3_tiplproddsc1)");
         }
         else
         {
            GXv_int8[0] = 1;
         }
         if ( ( StringUtil.StrCmp(AV68Configuracion_listaprecioswwds_1_dynamicfiltersselector1, "TIPLPRODDSC") == 0 ) && ( AV69Configuracion_listaprecioswwds_2_dynamicfiltersoperator1 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV70Configuracion_listaprecioswwds_3_tiplproddsc1)) ) )
         {
            AddWhere(sWhereString, "(T1.[TipLProdDsc] like '%' + @lV70Configuracion_listaprecioswwds_3_tiplproddsc1)");
         }
         else
         {
            GXv_int8[1] = 1;
         }
         if ( ( StringUtil.StrCmp(AV68Configuracion_listaprecioswwds_1_dynamicfiltersselector1, "TIPLDSC") == 0 ) && ( AV69Configuracion_listaprecioswwds_2_dynamicfiltersoperator1 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV71Configuracion_listaprecioswwds_4_tipldsc1)) ) )
         {
            AddWhere(sWhereString, "(T2.[TipLDsc] like @lV71Configuracion_listaprecioswwds_4_tipldsc1)");
         }
         else
         {
            GXv_int8[2] = 1;
         }
         if ( ( StringUtil.StrCmp(AV68Configuracion_listaprecioswwds_1_dynamicfiltersselector1, "TIPLDSC") == 0 ) && ( AV69Configuracion_listaprecioswwds_2_dynamicfiltersoperator1 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV71Configuracion_listaprecioswwds_4_tipldsc1)) ) )
         {
            AddWhere(sWhereString, "(T2.[TipLDsc] like '%' + @lV71Configuracion_listaprecioswwds_4_tipldsc1)");
         }
         else
         {
            GXv_int8[3] = 1;
         }
         if ( AV72Configuracion_listaprecioswwds_5_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV73Configuracion_listaprecioswwds_6_dynamicfiltersselector2, "TIPLPRODDSC") == 0 ) && ( AV74Configuracion_listaprecioswwds_7_dynamicfiltersoperator2 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV75Configuracion_listaprecioswwds_8_tiplproddsc2)) ) )
         {
            AddWhere(sWhereString, "(T1.[TipLProdDsc] like @lV75Configuracion_listaprecioswwds_8_tiplproddsc2)");
         }
         else
         {
            GXv_int8[4] = 1;
         }
         if ( AV72Configuracion_listaprecioswwds_5_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV73Configuracion_listaprecioswwds_6_dynamicfiltersselector2, "TIPLPRODDSC") == 0 ) && ( AV74Configuracion_listaprecioswwds_7_dynamicfiltersoperator2 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV75Configuracion_listaprecioswwds_8_tiplproddsc2)) ) )
         {
            AddWhere(sWhereString, "(T1.[TipLProdDsc] like '%' + @lV75Configuracion_listaprecioswwds_8_tiplproddsc2)");
         }
         else
         {
            GXv_int8[5] = 1;
         }
         if ( AV72Configuracion_listaprecioswwds_5_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV73Configuracion_listaprecioswwds_6_dynamicfiltersselector2, "TIPLDSC") == 0 ) && ( AV74Configuracion_listaprecioswwds_7_dynamicfiltersoperator2 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV76Configuracion_listaprecioswwds_9_tipldsc2)) ) )
         {
            AddWhere(sWhereString, "(T2.[TipLDsc] like @lV76Configuracion_listaprecioswwds_9_tipldsc2)");
         }
         else
         {
            GXv_int8[6] = 1;
         }
         if ( AV72Configuracion_listaprecioswwds_5_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV73Configuracion_listaprecioswwds_6_dynamicfiltersselector2, "TIPLDSC") == 0 ) && ( AV74Configuracion_listaprecioswwds_7_dynamicfiltersoperator2 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV76Configuracion_listaprecioswwds_9_tipldsc2)) ) )
         {
            AddWhere(sWhereString, "(T2.[TipLDsc] like '%' + @lV76Configuracion_listaprecioswwds_9_tipldsc2)");
         }
         else
         {
            GXv_int8[7] = 1;
         }
         if ( AV77Configuracion_listaprecioswwds_10_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV78Configuracion_listaprecioswwds_11_dynamicfiltersselector3, "TIPLPRODDSC") == 0 ) && ( AV79Configuracion_listaprecioswwds_12_dynamicfiltersoperator3 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV80Configuracion_listaprecioswwds_13_tiplproddsc3)) ) )
         {
            AddWhere(sWhereString, "(T1.[TipLProdDsc] like @lV80Configuracion_listaprecioswwds_13_tiplproddsc3)");
         }
         else
         {
            GXv_int8[8] = 1;
         }
         if ( AV77Configuracion_listaprecioswwds_10_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV78Configuracion_listaprecioswwds_11_dynamicfiltersselector3, "TIPLPRODDSC") == 0 ) && ( AV79Configuracion_listaprecioswwds_12_dynamicfiltersoperator3 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV80Configuracion_listaprecioswwds_13_tiplproddsc3)) ) )
         {
            AddWhere(sWhereString, "(T1.[TipLProdDsc] like '%' + @lV80Configuracion_listaprecioswwds_13_tiplproddsc3)");
         }
         else
         {
            GXv_int8[9] = 1;
         }
         if ( AV77Configuracion_listaprecioswwds_10_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV78Configuracion_listaprecioswwds_11_dynamicfiltersselector3, "TIPLDSC") == 0 ) && ( AV79Configuracion_listaprecioswwds_12_dynamicfiltersoperator3 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV81Configuracion_listaprecioswwds_14_tipldsc3)) ) )
         {
            AddWhere(sWhereString, "(T2.[TipLDsc] like @lV81Configuracion_listaprecioswwds_14_tipldsc3)");
         }
         else
         {
            GXv_int8[10] = 1;
         }
         if ( AV77Configuracion_listaprecioswwds_10_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV78Configuracion_listaprecioswwds_11_dynamicfiltersselector3, "TIPLDSC") == 0 ) && ( AV79Configuracion_listaprecioswwds_12_dynamicfiltersoperator3 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV81Configuracion_listaprecioswwds_14_tipldsc3)) ) )
         {
            AddWhere(sWhereString, "(T2.[TipLDsc] like '%' + @lV81Configuracion_listaprecioswwds_14_tipldsc3)");
         }
         else
         {
            GXv_int8[11] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV83Configuracion_listaprecioswwds_16_tftipldsc_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV82Configuracion_listaprecioswwds_15_tftipldsc)) ) )
         {
            AddWhere(sWhereString, "(T2.[TipLDsc] like @lV82Configuracion_listaprecioswwds_15_tftipldsc)");
         }
         else
         {
            GXv_int8[12] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV83Configuracion_listaprecioswwds_16_tftipldsc_sel)) )
         {
            AddWhere(sWhereString, "(T2.[TipLDsc] = @AV83Configuracion_listaprecioswwds_16_tftipldsc_sel)");
         }
         else
         {
            GXv_int8[13] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV85Configuracion_listaprecioswwds_18_tfprodcod_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV84Configuracion_listaprecioswwds_17_tfprodcod)) ) )
         {
            AddWhere(sWhereString, "(T1.[ProdCod] like @lV84Configuracion_listaprecioswwds_17_tfprodcod)");
         }
         else
         {
            GXv_int8[14] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV85Configuracion_listaprecioswwds_18_tfprodcod_sel)) )
         {
            AddWhere(sWhereString, "(T1.[ProdCod] = @AV85Configuracion_listaprecioswwds_18_tfprodcod_sel)");
         }
         else
         {
            GXv_int8[15] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV87Configuracion_listaprecioswwds_20_tftiplproddsc_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV86Configuracion_listaprecioswwds_19_tftiplproddsc)) ) )
         {
            AddWhere(sWhereString, "(T1.[TipLProdDsc] like @lV86Configuracion_listaprecioswwds_19_tftiplproddsc)");
         }
         else
         {
            GXv_int8[16] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV87Configuracion_listaprecioswwds_20_tftiplproddsc_sel)) )
         {
            AddWhere(sWhereString, "(T1.[TipLProdDsc] = @AV87Configuracion_listaprecioswwds_20_tftiplproddsc_sel)");
         }
         else
         {
            GXv_int8[17] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV89Configuracion_listaprecioswwds_22_tfclicod_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV88Configuracion_listaprecioswwds_21_tfclicod)) ) )
         {
            AddWhere(sWhereString, "(T1.[CliCod] like @lV88Configuracion_listaprecioswwds_21_tfclicod)");
         }
         else
         {
            GXv_int8[18] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV89Configuracion_listaprecioswwds_22_tfclicod_sel)) )
         {
            AddWhere(sWhereString, "(T1.[CliCod] = @AV89Configuracion_listaprecioswwds_22_tfclicod_sel)");
         }
         else
         {
            GXv_int8[19] = 1;
         }
         if ( ! (Convert.ToDecimal(0)==AV90Configuracion_listaprecioswwds_23_tfprelis) )
         {
            AddWhere(sWhereString, "(T1.[PreLis] >= @AV90Configuracion_listaprecioswwds_23_tfprelis)");
         }
         else
         {
            GXv_int8[20] = 1;
         }
         if ( ! (Convert.ToDecimal(0)==AV91Configuracion_listaprecioswwds_24_tfprelis_to) )
         {
            AddWhere(sWhereString, "(T1.[PreLis] <= @AV91Configuracion_listaprecioswwds_24_tfprelis_to)");
         }
         else
         {
            GXv_int8[21] = 1;
         }
         if ( ! (DateTime.MinValue==AV92Configuracion_listaprecioswwds_25_tflisfech) )
         {
            AddWhere(sWhereString, "(T1.[LisFech] >= @AV92Configuracion_listaprecioswwds_25_tflisfech)");
         }
         else
         {
            GXv_int8[22] = 1;
         }
         if ( ! (DateTime.MinValue==AV93Configuracion_listaprecioswwds_26_tflisfech_to) )
         {
            AddWhere(sWhereString, "(T1.[LisFech] <= @AV93Configuracion_listaprecioswwds_26_tflisfech_to)");
         }
         else
         {
            GXv_int8[23] = 1;
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
         else if ( true )
         {
            scmdbuf += "";
         }
         GXv_Object9[0] = scmdbuf;
         GXv_Object9[1] = GXv_int8;
         return GXv_Object9 ;
      }

      public override Object [] getDynamicStatement( int cursor ,
                                                     IGxContext context ,
                                                     Object [] dynConstraints )
      {
         switch ( cursor )
         {
               case 0 :
                     return conditional_H001R2(context, (string)dynConstraints[0] , (short)dynConstraints[1] , (string)dynConstraints[2] , (string)dynConstraints[3] , (bool)dynConstraints[4] , (string)dynConstraints[5] , (short)dynConstraints[6] , (string)dynConstraints[7] , (string)dynConstraints[8] , (bool)dynConstraints[9] , (string)dynConstraints[10] , (short)dynConstraints[11] , (string)dynConstraints[12] , (string)dynConstraints[13] , (string)dynConstraints[14] , (string)dynConstraints[15] , (string)dynConstraints[16] , (string)dynConstraints[17] , (string)dynConstraints[18] , (string)dynConstraints[19] , (string)dynConstraints[20] , (string)dynConstraints[21] , (decimal)dynConstraints[22] , (decimal)dynConstraints[23] , (DateTime)dynConstraints[24] , (DateTime)dynConstraints[25] , (string)dynConstraints[26] , (string)dynConstraints[27] , (string)dynConstraints[28] , (string)dynConstraints[29] , (decimal)dynConstraints[30] , (DateTime)dynConstraints[31] , (short)dynConstraints[32] , (bool)dynConstraints[33] );
               case 1 :
                     return conditional_H001R3(context, (string)dynConstraints[0] , (short)dynConstraints[1] , (string)dynConstraints[2] , (string)dynConstraints[3] , (bool)dynConstraints[4] , (string)dynConstraints[5] , (short)dynConstraints[6] , (string)dynConstraints[7] , (string)dynConstraints[8] , (bool)dynConstraints[9] , (string)dynConstraints[10] , (short)dynConstraints[11] , (string)dynConstraints[12] , (string)dynConstraints[13] , (string)dynConstraints[14] , (string)dynConstraints[15] , (string)dynConstraints[16] , (string)dynConstraints[17] , (string)dynConstraints[18] , (string)dynConstraints[19] , (string)dynConstraints[20] , (string)dynConstraints[21] , (decimal)dynConstraints[22] , (decimal)dynConstraints[23] , (DateTime)dynConstraints[24] , (DateTime)dynConstraints[25] , (string)dynConstraints[26] , (string)dynConstraints[27] , (string)dynConstraints[28] , (string)dynConstraints[29] , (decimal)dynConstraints[30] , (DateTime)dynConstraints[31] , (short)dynConstraints[32] , (bool)dynConstraints[33] );
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
          Object[] prmH001R2;
          prmH001R2 = new Object[] {
          new ParDef("@lV70Configuracion_listaprecioswwds_3_tiplproddsc1",GXType.NChar,100,0) ,
          new ParDef("@lV70Configuracion_listaprecioswwds_3_tiplproddsc1",GXType.NChar,100,0) ,
          new ParDef("@lV71Configuracion_listaprecioswwds_4_tipldsc1",GXType.NChar,100,0) ,
          new ParDef("@lV71Configuracion_listaprecioswwds_4_tipldsc1",GXType.NChar,100,0) ,
          new ParDef("@lV75Configuracion_listaprecioswwds_8_tiplproddsc2",GXType.NChar,100,0) ,
          new ParDef("@lV75Configuracion_listaprecioswwds_8_tiplproddsc2",GXType.NChar,100,0) ,
          new ParDef("@lV76Configuracion_listaprecioswwds_9_tipldsc2",GXType.NChar,100,0) ,
          new ParDef("@lV76Configuracion_listaprecioswwds_9_tipldsc2",GXType.NChar,100,0) ,
          new ParDef("@lV80Configuracion_listaprecioswwds_13_tiplproddsc3",GXType.NChar,100,0) ,
          new ParDef("@lV80Configuracion_listaprecioswwds_13_tiplproddsc3",GXType.NChar,100,0) ,
          new ParDef("@lV81Configuracion_listaprecioswwds_14_tipldsc3",GXType.NChar,100,0) ,
          new ParDef("@lV81Configuracion_listaprecioswwds_14_tipldsc3",GXType.NChar,100,0) ,
          new ParDef("@lV82Configuracion_listaprecioswwds_15_tftipldsc",GXType.NChar,100,0) ,
          new ParDef("@AV83Configuracion_listaprecioswwds_16_tftipldsc_sel",GXType.NChar,100,0) ,
          new ParDef("@lV84Configuracion_listaprecioswwds_17_tfprodcod",GXType.NChar,15,0) ,
          new ParDef("@AV85Configuracion_listaprecioswwds_18_tfprodcod_sel",GXType.NChar,15,0) ,
          new ParDef("@lV86Configuracion_listaprecioswwds_19_tftiplproddsc",GXType.NChar,100,0) ,
          new ParDef("@AV87Configuracion_listaprecioswwds_20_tftiplproddsc_sel",GXType.NChar,100,0) ,
          new ParDef("@lV88Configuracion_listaprecioswwds_21_tfclicod",GXType.NChar,20,0) ,
          new ParDef("@AV89Configuracion_listaprecioswwds_22_tfclicod_sel",GXType.NChar,20,0) ,
          new ParDef("@AV90Configuracion_listaprecioswwds_23_tfprelis",GXType.Decimal,15,4) ,
          new ParDef("@AV91Configuracion_listaprecioswwds_24_tfprelis_to",GXType.Decimal,15,4) ,
          new ParDef("@AV92Configuracion_listaprecioswwds_25_tflisfech",GXType.Date,8,0) ,
          new ParDef("@AV93Configuracion_listaprecioswwds_26_tflisfech_to",GXType.Date,8,0) ,
          new ParDef("@GXPagingFrom2",GXType.Int32,9,0) ,
          new ParDef("@GXPagingTo2",GXType.Int32,9,0) ,
          new ParDef("@GXPagingTo2",GXType.Int32,9,0)
          };
          Object[] prmH001R3;
          prmH001R3 = new Object[] {
          new ParDef("@lV70Configuracion_listaprecioswwds_3_tiplproddsc1",GXType.NChar,100,0) ,
          new ParDef("@lV70Configuracion_listaprecioswwds_3_tiplproddsc1",GXType.NChar,100,0) ,
          new ParDef("@lV71Configuracion_listaprecioswwds_4_tipldsc1",GXType.NChar,100,0) ,
          new ParDef("@lV71Configuracion_listaprecioswwds_4_tipldsc1",GXType.NChar,100,0) ,
          new ParDef("@lV75Configuracion_listaprecioswwds_8_tiplproddsc2",GXType.NChar,100,0) ,
          new ParDef("@lV75Configuracion_listaprecioswwds_8_tiplproddsc2",GXType.NChar,100,0) ,
          new ParDef("@lV76Configuracion_listaprecioswwds_9_tipldsc2",GXType.NChar,100,0) ,
          new ParDef("@lV76Configuracion_listaprecioswwds_9_tipldsc2",GXType.NChar,100,0) ,
          new ParDef("@lV80Configuracion_listaprecioswwds_13_tiplproddsc3",GXType.NChar,100,0) ,
          new ParDef("@lV80Configuracion_listaprecioswwds_13_tiplproddsc3",GXType.NChar,100,0) ,
          new ParDef("@lV81Configuracion_listaprecioswwds_14_tipldsc3",GXType.NChar,100,0) ,
          new ParDef("@lV81Configuracion_listaprecioswwds_14_tipldsc3",GXType.NChar,100,0) ,
          new ParDef("@lV82Configuracion_listaprecioswwds_15_tftipldsc",GXType.NChar,100,0) ,
          new ParDef("@AV83Configuracion_listaprecioswwds_16_tftipldsc_sel",GXType.NChar,100,0) ,
          new ParDef("@lV84Configuracion_listaprecioswwds_17_tfprodcod",GXType.NChar,15,0) ,
          new ParDef("@AV85Configuracion_listaprecioswwds_18_tfprodcod_sel",GXType.NChar,15,0) ,
          new ParDef("@lV86Configuracion_listaprecioswwds_19_tftiplproddsc",GXType.NChar,100,0) ,
          new ParDef("@AV87Configuracion_listaprecioswwds_20_tftiplproddsc_sel",GXType.NChar,100,0) ,
          new ParDef("@lV88Configuracion_listaprecioswwds_21_tfclicod",GXType.NChar,20,0) ,
          new ParDef("@AV89Configuracion_listaprecioswwds_22_tfclicod_sel",GXType.NChar,20,0) ,
          new ParDef("@AV90Configuracion_listaprecioswwds_23_tfprelis",GXType.Decimal,15,4) ,
          new ParDef("@AV91Configuracion_listaprecioswwds_24_tfprelis_to",GXType.Decimal,15,4) ,
          new ParDef("@AV92Configuracion_listaprecioswwds_25_tflisfech",GXType.Date,8,0) ,
          new ParDef("@AV93Configuracion_listaprecioswwds_26_tflisfech_to",GXType.Date,8,0)
          };
          def= new CursorDef[] {
              new CursorDef("H001R2", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH001R2,11, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("H001R3", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH001R3,1, GxCacheFrequency.OFF ,true,false )
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
                ((decimal[]) buf[0])[0] = rslt.getDecimal(1);
                ((string[]) buf[1])[0] = rslt.getString(2, 100);
                ((bool[]) buf[2])[0] = rslt.wasNull(2);
                ((DateTime[]) buf[3])[0] = rslt.getGXDate(3);
                ((decimal[]) buf[4])[0] = rslt.getDecimal(4);
                ((string[]) buf[5])[0] = rslt.getString(5, 20);
                ((bool[]) buf[6])[0] = rslt.wasNull(5);
                ((string[]) buf[7])[0] = rslt.getString(6, 100);
                ((string[]) buf[8])[0] = rslt.getString(7, 15);
                ((string[]) buf[9])[0] = rslt.getString(8, 100);
                ((int[]) buf[10])[0] = rslt.getInt(9);
                ((int[]) buf[11])[0] = rslt.getInt(10);
                return;
             case 1 :
                ((long[]) buf[0])[0] = rslt.getLong(1);
                return;
       }
    }

 }

}
