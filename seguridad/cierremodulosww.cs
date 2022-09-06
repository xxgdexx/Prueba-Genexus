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
namespace GeneXus.Programs.seguridad {
   public class cierremodulosww : GXDataArea
   {
      public cierremodulosww( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDataStore2 = context.GetDataStore("DataStore2");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusTheme");
      }

      public cierremodulosww( IGxContext context )
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
         cmbavCmmodmes = new GXCombobox();
         cmbavGridactions = new GXCombobox();
         cmbCMModMes = new GXCombobox();
         cmbCMModCod = new GXCombobox();
         cmbCMModSts = new GXCombobox();
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
               nRC_GXsfl_38 = (int)(NumberUtil.Val( GetPar( "nRC_GXsfl_38"), "."));
               nGXsfl_38_idx = (int)(NumberUtil.Val( GetPar( "nGXsfl_38_idx"), "."));
               sGXsfl_38_idx = GetPar( "sGXsfl_38_idx");
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
               AV61CMModAno = (short)(NumberUtil.Val( GetPar( "CMModAno"), "."));
               cmbavCmmodmes.FromJSonString( GetNextPar( ));
               AV62CMModMes = (short)(NumberUtil.Val( GetPar( "CMModMes"), "."));
               AV71Pgmname = GetPar( "Pgmname");
               AV33TFCMModAno = (short)(NumberUtil.Val( GetPar( "TFCMModAno"), "."));
               AV34TFCMModAno_To = (short)(NumberUtil.Val( GetPar( "TFCMModAno_To"), "."));
               ajax_req_read_hidden_sdt(GetNextPar( ), AV64TFCMModMes_Sels);
               ajax_req_read_hidden_sdt(GetNextPar( ), AV66TFCMModCod_Sels);
               ajax_req_read_hidden_sdt(GetNextPar( ), AV68TFCMModSts_Sels);
               AV39TFCMModUsuC = GetPar( "TFCMModUsuC");
               AV40TFCMModUsuC_Sel = GetPar( "TFCMModUsuC_Sel");
               AV41TFCMModFecC = context.localUtil.ParseDateParm( GetPar( "TFCMModFecC"));
               AV42TFCMModFecC_To = context.localUtil.ParseDateParm( GetPar( "TFCMModFecC_To"));
               AV46TFCMModUsuM = GetPar( "TFCMModUsuM");
               AV47TFCMModUsuM_Sel = GetPar( "TFCMModUsuM_Sel");
               AV48TFCMModFecM = context.localUtil.ParseDateParm( GetPar( "TFCMModFecM"));
               AV49TFCMModFecM_To = context.localUtil.ParseDateParm( GetPar( "TFCMModFecM_To"));
               AV13OrderedBy = (short)(NumberUtil.Val( GetPar( "OrderedBy"), "."));
               AV14OrderedDsc = StringUtil.StrToBool( GetPar( "OrderedDsc"));
               setAjaxCallMode();
               if ( ! IsValidAjaxCall( true) )
               {
                  GxWebError = 1;
                  return  ;
               }
               gxgrGrid_refresh( subGrid_Rows, AV61CMModAno, AV62CMModMes, AV71Pgmname, AV33TFCMModAno, AV34TFCMModAno_To, AV64TFCMModMes_Sels, AV66TFCMModCod_Sels, AV68TFCMModSts_Sels, AV39TFCMModUsuC, AV40TFCMModUsuC_Sel, AV41TFCMModFecC, AV42TFCMModFecC_To, AV46TFCMModUsuM, AV47TFCMModUsuM_Sel, AV48TFCMModFecM, AV49TFCMModFecM_To, AV13OrderedBy, AV14OrderedDsc) ;
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
         PA0C2( ) ;
         gxajaxcallmode = (short)((isAjaxCallMode( ) ? 1 : 0));
         if ( ( gxajaxcallmode == 0 ) && ( GxWebError == 0 ) )
         {
            START0C2( ) ;
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
         context.AddJavascriptSource("gxcfg.js", "?202281810272651", false, true);
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
         context.WriteHtmlTextNl( "<form id=\"MAINFORM\" autocomplete=\"off\" name=\"MAINFORM\" method=\"post\" tabindex=-1  class=\"form-horizontal Form\" data-gx-class=\"form-horizontal Form\" novalidate action=\""+formatLink("seguridad.cierremodulosww.aspx") +"\">") ;
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
         GxWebStd.gx_hidden_field( context, "gxhash_vPGMNAME", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( AV71Pgmname, "")), context));
         GXKey = Crypto.GetSiteKey( );
      }

      protected void SendCloseFormHiddens( )
      {
         /* Send hidden variables. */
         GxWebStd.gx_hidden_field( context, "GXH_vCMMODANO", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV61CMModAno), 4, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "GXH_vCMMODMES", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV62CMModMes), 2, 0, ".", "")));
         /* Send saved values. */
         send_integrity_footer_hashes( ) ;
         GxWebStd.gx_hidden_field( context, "nRC_GXsfl_38", StringUtil.LTrim( StringUtil.NToC( (decimal)(nRC_GXsfl_38), 8, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "vGRIDCURRENTPAGE", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV55GridCurrentPage), 10, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "vGRIDPAGECOUNT", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV56GridPageCount), 10, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "vGRIDAPPLIEDFILTERS", AV57GridAppliedFilters);
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "vAGEXPORTDATA", AV59AGExportData);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt("vAGEXPORTDATA", AV59AGExportData);
         }
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "vDDO_TITLESETTINGSICONS", AV53DDO_TitleSettingsIcons);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt("vDDO_TITLESETTINGSICONS", AV53DDO_TitleSettingsIcons);
         }
         GxWebStd.gx_hidden_field( context, "vDDO_CMMODFECCAUXDATETO", context.localUtil.DToC( AV44DDO_CMModFecCAuxDateTo, 0, "/"));
         GxWebStd.gx_hidden_field( context, "vDDO_CMMODFECMAUXDATETO", context.localUtil.DToC( AV51DDO_CMModFecMAuxDateTo, 0, "/"));
         GxWebStd.gx_hidden_field( context, "vPGMNAME", StringUtil.RTrim( AV71Pgmname));
         GxWebStd.gx_hidden_field( context, "gxhash_vPGMNAME", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( AV71Pgmname, "")), context));
         GxWebStd.gx_hidden_field( context, "vTFCMMODANO", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV33TFCMModAno), 4, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "vTFCMMODANO_TO", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV34TFCMModAno_To), 4, 0, ".", "")));
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "vTFCMMODMES_SELS", AV64TFCMModMes_Sels);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt("vTFCMMODMES_SELS", AV64TFCMModMes_Sels);
         }
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "vTFCMMODCOD_SELS", AV66TFCMModCod_Sels);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt("vTFCMMODCOD_SELS", AV66TFCMModCod_Sels);
         }
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "vTFCMMODSTS_SELS", AV68TFCMModSts_Sels);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt("vTFCMMODSTS_SELS", AV68TFCMModSts_Sels);
         }
         GxWebStd.gx_hidden_field( context, "vTFCMMODUSUC", StringUtil.RTrim( AV39TFCMModUsuC));
         GxWebStd.gx_hidden_field( context, "vTFCMMODUSUC_SEL", StringUtil.RTrim( AV40TFCMModUsuC_Sel));
         GxWebStd.gx_hidden_field( context, "vTFCMMODFECC", context.localUtil.DToC( AV41TFCMModFecC, 0, "/"));
         GxWebStd.gx_hidden_field( context, "vTFCMMODFECC_TO", context.localUtil.DToC( AV42TFCMModFecC_To, 0, "/"));
         GxWebStd.gx_hidden_field( context, "vTFCMMODUSUM", StringUtil.RTrim( AV46TFCMModUsuM));
         GxWebStd.gx_hidden_field( context, "vTFCMMODUSUM_SEL", StringUtil.RTrim( AV47TFCMModUsuM_Sel));
         GxWebStd.gx_hidden_field( context, "vTFCMMODFECM", context.localUtil.DToC( AV48TFCMModFecM, 0, "/"));
         GxWebStd.gx_hidden_field( context, "vTFCMMODFECM_TO", context.localUtil.DToC( AV49TFCMModFecM_To, 0, "/"));
         GxWebStd.gx_hidden_field( context, "vORDEREDBY", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV13OrderedBy), 4, 0, ".", "")));
         GxWebStd.gx_boolean_hidden_field( context, "vORDEREDDSC", AV14OrderedDsc);
         GxWebStd.gx_hidden_field( context, "vTFCMMODMES_SELSJSON", AV63TFCMModMes_SelsJson);
         GxWebStd.gx_hidden_field( context, "vTFCMMODCOD_SELSJSON", AV65TFCMModCod_SelsJson);
         GxWebStd.gx_hidden_field( context, "vTFCMMODSTS_SELSJSON", AV67TFCMModSts_SelsJson);
         GxWebStd.gx_hidden_field( context, "GRID_nFirstRecordOnPage", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRID_nFirstRecordOnPage), 15, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "GRID_nEOF", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRID_nEOF), 1, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "vDDO_CMMODFECCAUXDATE", context.localUtil.DToC( AV43DDO_CMModFecCAuxDate, 0, "/"));
         GxWebStd.gx_hidden_field( context, "vDDO_CMMODFECMAUXDATE", context.localUtil.DToC( AV50DDO_CMModFecMAuxDate, 0, "/"));
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
            WE0C2( ) ;
            context.WriteHtmlText( "</div>") ;
         }
      }

      public override void DispatchEvents( )
      {
         EVT0C2( ) ;
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
         return formatLink("seguridad.cierremodulosww.aspx")  ;
      }

      public override string GetPgmname( )
      {
         return "Seguridad.CierreModulosWW" ;
      }

      public override string GetPgmdesc( )
      {
         return " Cierre Modulos" ;
      }

      protected void WB0C0( )
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
            GxWebStd.gx_button_ctrl( context, bttBtninsert_Internalname, "gx.evt.setGridEvt("+StringUtil.Str( (decimal)(38), 2, 0)+","+"null"+");", "Agregar", bttBtninsert_Jsonclick, 5, "Agregar", "", StyleString, ClassString, 1, 1, "standard", "'"+""+"'"+",false,"+"'"+"E\\'DOINSERT\\'."+"'", TempTags, "", context.GetButtonType( ), "HLP_Seguridad\\CierreModulosWW.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "left", "top", "", "", "div");
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 21,'',false,'',0)\"";
            ClassString = "ColumnsSelector";
            StyleString = "";
            GxWebStd.gx_button_ctrl( context, bttBtnagexport_Internalname, "gx.evt.setGridEvt("+StringUtil.Str( (decimal)(38), 2, 0)+","+"null"+");", "Reportes", bttBtnagexport_Jsonclick, 0, "Reportes", "", StyleString, ClassString, 1, 0, "standard", "'"+""+"'"+",false,"+"'"+""+"'", TempTags, "", context.GetButtonType( ), "HLP_Seguridad\\CierreModulosWW.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "", "left", "top", "", "flex-grow:1;", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group gx-default-form-group", "left", "top", ""+" data-gx-for=\""+edtavCmmodano_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavCmmodano_Internalname, "Año", "gx-form-item AttributeLabel", 1, true, "width: 25%;");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 75, "%", 0, "px", "gx-form-item gx-attribute", "left", "top", "", "", "div");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 25,'',false,'" + sGXsfl_38_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavCmmodano_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(AV61CMModAno), 4, 0, ".", "")), StringUtil.LTrim( ((edtavCmmodano_Enabled!=0) ? context.localUtil.Format( (decimal)(AV61CMModAno), "ZZZ9") : context.localUtil.Format( (decimal)(AV61CMModAno), "ZZZ9"))), " inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onblur(this,25);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavCmmodano_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtavCmmodano_Enabled, 0, "text", "1", 4, "chr", 1, "row", 4, 0, 0, 0, 1, -1, 0, true, "", "right", false, "", "HLP_Seguridad\\CierreModulosWW.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "", "left", "top", "", "flex-grow:1;", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group gx-default-form-group", "left", "top", ""+" data-gx-for=\""+cmbavCmmodmes_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, cmbavCmmodmes_Internalname, "Mes", "gx-form-item AttributeLabel", 1, true, "width: 25%;");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 75, "%", 0, "px", "gx-form-item gx-attribute", "left", "top", "", "", "div");
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 29,'',false,'" + sGXsfl_38_idx + "',0)\"";
            /* ComboBox */
            GxWebStd.gx_combobox_ctrl1( context, cmbavCmmodmes, cmbavCmmodmes_Internalname, StringUtil.Trim( StringUtil.Str( (decimal)(AV62CMModMes), 2, 0)), 1, cmbavCmmodmes_Jsonclick, 0, "'"+""+"'"+",false,"+"'"+""+"'", "int", "", 1, cmbavCmmodmes.Enabled, 0, 0, 0, "em", 0, "", "", "Attribute", "", "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,29);\"", "", true, 1, "HLP_Seguridad\\CierreModulosWW.htm");
            cmbavCmmodmes.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV62CMModMes), 2, 0));
            AssignProp("", false, cmbavCmmodmes_Internalname, "Values", (string)(cmbavCmmodmes.ToJavascriptSource()), true);
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
               context.WriteHtmlText( "<div id=\""+"GridContainer"+"DivS\" data-gxgridid=\"38\">") ;
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
               context.SendWebValue( "Año") ;
               context.WriteHtmlTextNl( "</th>") ;
               context.WriteHtmlText( "<th align=\""+"right"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+""+""+"\" "+">") ;
               context.SendWebValue( "Mes") ;
               context.WriteHtmlTextNl( "</th>") ;
               context.WriteHtmlText( "<th align=\""+"left"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+""+""+"\" "+">") ;
               context.SendWebValue( "Modulo") ;
               context.WriteHtmlTextNl( "</th>") ;
               context.WriteHtmlText( "<th align=\""+"right"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+""+""+"\" "+">") ;
               context.SendWebValue( "Estado") ;
               context.WriteHtmlTextNl( "</th>") ;
               context.WriteHtmlText( "<th align=\""+"left"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+""+""+"\" "+">") ;
               context.SendWebValue( "Usuario Creación") ;
               context.WriteHtmlTextNl( "</th>") ;
               context.WriteHtmlText( "<th align=\""+"right"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+""+""+"\" "+">") ;
               context.SendWebValue( "Fecha Creación") ;
               context.WriteHtmlTextNl( "</th>") ;
               context.WriteHtmlText( "<th align=\""+"left"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+""+""+"\" "+">") ;
               context.SendWebValue( "Usuario Modificación") ;
               context.WriteHtmlTextNl( "</th>") ;
               context.WriteHtmlText( "<th align=\""+"right"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+""+""+"\" "+">") ;
               context.SendWebValue( "Fecha Modificación") ;
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
               GridColumn.AddObjectProperty("Value", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV58GridActions), 4, 0, ".", "")));
               GridContainer.AddColumnProperties(GridColumn);
               GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
               GridColumn.AddObjectProperty("Value", StringUtil.LTrim( StringUtil.NToC( (decimal)(A74CMModAno), 4, 0, ".", "")));
               GridContainer.AddColumnProperties(GridColumn);
               GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
               GridColumn.AddObjectProperty("Value", StringUtil.LTrim( StringUtil.NToC( (decimal)(A75CMModMes), 2, 0, ".", "")));
               GridContainer.AddColumnProperties(GridColumn);
               GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
               GridColumn.AddObjectProperty("Value", StringUtil.RTrim( A73CMModCod));
               GridContainer.AddColumnProperties(GridColumn);
               GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
               GridColumn.AddObjectProperty("Value", StringUtil.LTrim( StringUtil.NToC( (decimal)(A640CMModSts), 1, 0, ".", "")));
               GridContainer.AddColumnProperties(GridColumn);
               GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
               GridColumn.AddObjectProperty("Value", StringUtil.RTrim( A641CMModUsuC));
               GridContainer.AddColumnProperties(GridColumn);
               GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
               GridColumn.AddObjectProperty("Value", context.localUtil.Format(A638CMModFecC, "99/99/99"));
               GridContainer.AddColumnProperties(GridColumn);
               GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
               GridColumn.AddObjectProperty("Value", StringUtil.RTrim( A642CMModUsuM));
               GridContainer.AddColumnProperties(GridColumn);
               GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
               GridColumn.AddObjectProperty("Value", context.localUtil.Format(A639CMModFecM, "99/99/99"));
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
         if ( wbEnd == 38 )
         {
            wbEnd = 0;
            nRC_GXsfl_38 = (int)(nGXsfl_38_idx-1);
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
            ucGridpaginationbar.SetProperty("CurrentPage", AV55GridCurrentPage);
            ucGridpaginationbar.SetProperty("PageCount", AV56GridPageCount);
            ucGridpaginationbar.SetProperty("AppliedFilters", AV57GridAppliedFilters);
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
            ucDdo_agexport.SetProperty("DropDownOptionsData", AV59AGExportData);
            ucDdo_agexport.Render(context, "dvelop.gxbootstrap.ddoregular", Ddo_agexport_Internalname, "DDO_AGEXPORTContainer");
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
            ucDdo_grid.SetProperty("DropDownOptionsTitleSettingsIcons", AV53DDO_TitleSettingsIcons);
            ucDdo_grid.Render(context, "dvelop.gxbootstrap.ddogridtitlesettingsm", Ddo_grid_Internalname, "DDO_GRIDContainer");
            /* User Defined Control */
            ucInnewwindow1.Render(context, "innewwindow", Innewwindow1_Internalname, "INNEWWINDOW1Container");
            /* User Defined Control */
            ucGrid_empowerer.SetProperty("HasTitleSettings", Grid_empowerer_Hastitlesettings);
            ucGrid_empowerer.Render(context, "wwp.gridempowerer", Grid_empowerer_Internalname, "GRID_EMPOWERERContainer");
            /* Div Control */
            GxWebStd.gx_div_start( context, divDdo_cmmodfeccauxdates_Internalname, 1, 0, "px", 0, "px", "Invisible", "left", "top", "", "", "div");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 59,'',false,'" + sGXsfl_38_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavDdo_cmmodfeccauxdatetext_Internalname, AV45DDO_CMModFecCAuxDateText, StringUtil.RTrim( context.localUtil.Format( AV45DDO_CMModFecCAuxDateText, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,59);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavDdo_cmmodfeccauxdatetext_Jsonclick, 0, "Attribute", "", "", "", "", 1, 1, 0, "text", "", 40, "chr", 1, "row", 40, 0, 0, 0, 1, -1, -1, true, "", "left", true, "", "HLP_Seguridad\\CierreModulosWW.htm");
            /* User Defined Control */
            ucTfcmmodfecc_rangepicker.SetProperty("Start Date", AV43DDO_CMModFecCAuxDate);
            ucTfcmmodfecc_rangepicker.SetProperty("End Date", AV44DDO_CMModFecCAuxDateTo);
            ucTfcmmodfecc_rangepicker.Render(context, "wwp.daterangepicker", Tfcmmodfecc_rangepicker_Internalname, "TFCMMODFECC_RANGEPICKERContainer");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divDdo_cmmodfecmauxdates_Internalname, 1, 0, "px", 0, "px", "Invisible", "left", "top", "", "", "div");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 62,'',false,'" + sGXsfl_38_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavDdo_cmmodfecmauxdatetext_Internalname, AV52DDO_CMModFecMAuxDateText, StringUtil.RTrim( context.localUtil.Format( AV52DDO_CMModFecMAuxDateText, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,62);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavDdo_cmmodfecmauxdatetext_Jsonclick, 0, "Attribute", "", "", "", "", 1, 1, 0, "text", "", 40, "chr", 1, "row", 40, 0, 0, 0, 1, -1, -1, true, "", "left", true, "", "HLP_Seguridad\\CierreModulosWW.htm");
            /* User Defined Control */
            ucTfcmmodfecm_rangepicker.SetProperty("Start Date", AV50DDO_CMModFecMAuxDate);
            ucTfcmmodfecm_rangepicker.SetProperty("End Date", AV51DDO_CMModFecMAuxDateTo);
            ucTfcmmodfecm_rangepicker.Render(context, "wwp.daterangepicker", Tfcmmodfecm_rangepicker_Internalname, "TFCMMODFECM_RANGEPICKERContainer");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
         }
         if ( wbEnd == 38 )
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

      protected void START0C2( )
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
            Form.Meta.addItem("description", " Cierre Modulos", 0) ;
         }
         context.wjLoc = "";
         context.nUserReturn = 0;
         context.wbHandled = 0;
         if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
         {
         }
         wbErr = false;
         STRUP0C0( ) ;
      }

      protected void WS0C2( )
      {
         START0C2( ) ;
         EVT0C2( ) ;
      }

      protected void EVT0C2( )
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
                              E110C2 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "GRIDPAGINATIONBAR.CHANGEROWSPERPAGE") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              E120C2 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "DDO_AGEXPORT.ONOPTIONCLICKED") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              E130C2 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "DDO_GRID.ONOPTIONCLICKED") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              E140C2 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "'DOINSERT'") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              /* Execute user event: 'DoInsert' */
                              E150C2 ();
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
                              nGXsfl_38_idx = (int)(NumberUtil.Val( sEvtType, "."));
                              sGXsfl_38_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_38_idx), 4, 0), 4, "0");
                              SubsflControlProps_382( ) ;
                              cmbavGridactions.Name = cmbavGridactions_Internalname;
                              cmbavGridactions.CurrentValue = cgiGet( cmbavGridactions_Internalname);
                              AV58GridActions = (short)(NumberUtil.Val( cgiGet( cmbavGridactions_Internalname), "."));
                              AssignAttri("", false, cmbavGridactions_Internalname, StringUtil.LTrimStr( (decimal)(AV58GridActions), 4, 0));
                              A74CMModAno = (short)(context.localUtil.CToN( cgiGet( edtCMModAno_Internalname), ".", ","));
                              cmbCMModMes.Name = cmbCMModMes_Internalname;
                              cmbCMModMes.CurrentValue = cgiGet( cmbCMModMes_Internalname);
                              A75CMModMes = (short)(NumberUtil.Val( cgiGet( cmbCMModMes_Internalname), "."));
                              cmbCMModCod.Name = cmbCMModCod_Internalname;
                              cmbCMModCod.CurrentValue = cgiGet( cmbCMModCod_Internalname);
                              A73CMModCod = cgiGet( cmbCMModCod_Internalname);
                              cmbCMModSts.Name = cmbCMModSts_Internalname;
                              cmbCMModSts.CurrentValue = cgiGet( cmbCMModSts_Internalname);
                              A640CMModSts = (short)(NumberUtil.Val( cgiGet( cmbCMModSts_Internalname), "."));
                              A641CMModUsuC = cgiGet( edtCMModUsuC_Internalname);
                              A638CMModFecC = DateTimeUtil.ResetTime(context.localUtil.CToT( cgiGet( edtCMModFecC_Internalname), 0));
                              A642CMModUsuM = cgiGet( edtCMModUsuM_Internalname);
                              A639CMModFecM = DateTimeUtil.ResetTime(context.localUtil.CToT( cgiGet( edtCMModFecM_Internalname), 0));
                              sEvtType = StringUtil.Right( sEvt, 1);
                              if ( StringUtil.StrCmp(sEvtType, ".") == 0 )
                              {
                                 sEvt = StringUtil.Left( sEvt, (short)(StringUtil.Len( sEvt)-1));
                                 if ( StringUtil.StrCmp(sEvt, "START") == 0 )
                                 {
                                    context.wbHandled = 1;
                                    dynload_actions( ) ;
                                    /* Execute user event: Start */
                                    E160C2 ();
                                 }
                                 else if ( StringUtil.StrCmp(sEvt, "REFRESH") == 0 )
                                 {
                                    context.wbHandled = 1;
                                    dynload_actions( ) ;
                                    /* Execute user event: Refresh */
                                    E170C2 ();
                                 }
                                 else if ( StringUtil.StrCmp(sEvt, "GRID.LOAD") == 0 )
                                 {
                                    context.wbHandled = 1;
                                    dynload_actions( ) ;
                                    E180C2 ();
                                 }
                                 else if ( StringUtil.StrCmp(sEvt, "VGRIDACTIONS.CLICK") == 0 )
                                 {
                                    context.wbHandled = 1;
                                    dynload_actions( ) ;
                                    E190C2 ();
                                 }
                                 else if ( StringUtil.StrCmp(sEvt, "ENTER") == 0 )
                                 {
                                    context.wbHandled = 1;
                                    if ( ! wbErr )
                                    {
                                       Rfr0gs = false;
                                       /* Set Refresh If Cmmodano Changed */
                                       if ( ( context.localUtil.CToN( cgiGet( "GXH_vCMMODANO"), ".", ",") != Convert.ToDecimal( AV61CMModAno )) )
                                       {
                                          Rfr0gs = true;
                                       }
                                       /* Set Refresh If Cmmodmes Changed */
                                       if ( ( context.localUtil.CToN( cgiGet( "GXH_vCMMODMES"), ".", ",") != Convert.ToDecimal( AV62CMModMes )) )
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

      protected void WE0C2( )
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

      protected void PA0C2( )
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
               GX_FocusControl = edtavCmmodano_Internalname;
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
         SubsflControlProps_382( ) ;
         while ( nGXsfl_38_idx <= nRC_GXsfl_38 )
         {
            sendrow_382( ) ;
            nGXsfl_38_idx = ((subGrid_Islastpage==1)&&(nGXsfl_38_idx+1>subGrid_fnc_Recordsperpage( )) ? 1 : nGXsfl_38_idx+1);
            sGXsfl_38_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_38_idx), 4, 0), 4, "0");
            SubsflControlProps_382( ) ;
         }
         AddString( context.httpAjaxContext.getJSONContainerResponse( GridContainer)) ;
         /* End function gxnrGrid_newrow */
      }

      protected void gxgrGrid_refresh( int subGrid_Rows ,
                                       short AV61CMModAno ,
                                       short AV62CMModMes ,
                                       string AV71Pgmname ,
                                       short AV33TFCMModAno ,
                                       short AV34TFCMModAno_To ,
                                       GxSimpleCollection<short> AV64TFCMModMes_Sels ,
                                       GxSimpleCollection<string> AV66TFCMModCod_Sels ,
                                       GxSimpleCollection<short> AV68TFCMModSts_Sels ,
                                       string AV39TFCMModUsuC ,
                                       string AV40TFCMModUsuC_Sel ,
                                       DateTime AV41TFCMModFecC ,
                                       DateTime AV42TFCMModFecC_To ,
                                       string AV46TFCMModUsuM ,
                                       string AV47TFCMModUsuM_Sel ,
                                       DateTime AV48TFCMModFecM ,
                                       DateTime AV49TFCMModFecM_To ,
                                       short AV13OrderedBy ,
                                       bool AV14OrderedDsc )
      {
         initialize_formulas( ) ;
         GxWebStd.set_html_headers( context, 0, "", "");
         /* Execute user event: Refresh */
         E170C2 ();
         GRID_nCurrentRecord = 0;
         RF0C2( ) ;
         GXKey = Crypto.GetSiteKey( );
         send_integrity_footer_hashes( ) ;
         GXKey = Crypto.GetSiteKey( );
         /* End function gxgrGrid_refresh */
      }

      protected void send_integrity_hashes( )
      {
         GxWebStd.gx_hidden_field( context, "gxhash_CMMODCOD", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( A73CMModCod, "")), context));
         GxWebStd.gx_hidden_field( context, "CMMODCOD", StringUtil.RTrim( A73CMModCod));
         GxWebStd.gx_hidden_field( context, "gxhash_CMMODANO", GetSecureSignedToken( "", context.localUtil.Format( (decimal)(A74CMModAno), "ZZZ9"), context));
         GxWebStd.gx_hidden_field( context, "CMMODANO", StringUtil.LTrim( StringUtil.NToC( (decimal)(A74CMModAno), 4, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "gxhash_CMMODMES", GetSecureSignedToken( "", context.localUtil.Format( (decimal)(A75CMModMes), "Z9"), context));
         GxWebStd.gx_hidden_field( context, "CMMODMES", StringUtil.LTrim( StringUtil.NToC( (decimal)(A75CMModMes), 2, 0, ".", "")));
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
         if ( cmbavCmmodmes.ItemCount > 0 )
         {
            AV62CMModMes = (short)(NumberUtil.Val( cmbavCmmodmes.getValidValue(StringUtil.Trim( StringUtil.Str( (decimal)(AV62CMModMes), 2, 0))), "."));
            AssignAttri("", false, "AV62CMModMes", StringUtil.LTrimStr( (decimal)(AV62CMModMes), 2, 0));
         }
         if ( context.isAjaxRequest( ) )
         {
            cmbavCmmodmes.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV62CMModMes), 2, 0));
            AssignProp("", false, cmbavCmmodmes_Internalname, "Values", cmbavCmmodmes.ToJavascriptSource(), true);
         }
      }

      public void Refresh( )
      {
         send_integrity_hashes( ) ;
         RF0C2( ) ;
         if ( isFullAjaxMode( ) )
         {
            send_integrity_footer_hashes( ) ;
         }
      }

      protected void initialize_formulas( )
      {
         /* GeneXus formulas. */
         AV71Pgmname = "Seguridad.CierreModulosWW";
         context.Gx_err = 0;
      }

      protected void RF0C2( )
      {
         initialize_formulas( ) ;
         clear_multi_value_controls( ) ;
         if ( isAjaxCallMode( ) )
         {
            GridContainer.ClearRows();
         }
         wbStart = 38;
         /* Execute user event: Refresh */
         E170C2 ();
         nGXsfl_38_idx = 1;
         sGXsfl_38_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_38_idx), 4, 0), 4, "0");
         SubsflControlProps_382( ) ;
         bGXsfl_38_Refreshing = true;
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
            SubsflControlProps_382( ) ;
            GXPagingFrom2 = (int)(((subGrid_Rows==0) ? 0 : GRID_nFirstRecordOnPage));
            GXPagingTo2 = ((subGrid_Rows==0) ? 10000 : subGrid_fnc_Recordsperpage( )+1);
            pr_default.dynParam(0, new Object[]{ new Object[]{
                                                 A75CMModMes ,
                                                 AV76Seguridad_cierremoduloswwds_5_tfcmmodmes_sels ,
                                                 A73CMModCod ,
                                                 AV77Seguridad_cierremoduloswwds_6_tfcmmodcod_sels ,
                                                 A640CMModSts ,
                                                 AV78Seguridad_cierremoduloswwds_7_tfcmmodsts_sels ,
                                                 AV72Seguridad_cierremoduloswwds_1_cmmodano ,
                                                 AV73Seguridad_cierremoduloswwds_2_cmmodmes ,
                                                 AV74Seguridad_cierremoduloswwds_3_tfcmmodano ,
                                                 AV75Seguridad_cierremoduloswwds_4_tfcmmodano_to ,
                                                 AV76Seguridad_cierremoduloswwds_5_tfcmmodmes_sels.Count ,
                                                 AV77Seguridad_cierremoduloswwds_6_tfcmmodcod_sels.Count ,
                                                 AV78Seguridad_cierremoduloswwds_7_tfcmmodsts_sels.Count ,
                                                 AV80Seguridad_cierremoduloswwds_9_tfcmmodusuc_sel ,
                                                 AV79Seguridad_cierremoduloswwds_8_tfcmmodusuc ,
                                                 AV81Seguridad_cierremoduloswwds_10_tfcmmodfecc ,
                                                 AV82Seguridad_cierremoduloswwds_11_tfcmmodfecc_to ,
                                                 AV84Seguridad_cierremoduloswwds_13_tfcmmodusum_sel ,
                                                 AV83Seguridad_cierremoduloswwds_12_tfcmmodusum ,
                                                 AV85Seguridad_cierremoduloswwds_14_tfcmmodfecm ,
                                                 AV86Seguridad_cierremoduloswwds_15_tfcmmodfecm_to ,
                                                 A74CMModAno ,
                                                 A641CMModUsuC ,
                                                 A638CMModFecC ,
                                                 A642CMModUsuM ,
                                                 A639CMModFecM ,
                                                 AV13OrderedBy ,
                                                 AV14OrderedDsc } ,
                                                 new int[]{
                                                 TypeConstants.SHORT, TypeConstants.SHORT, TypeConstants.SHORT, TypeConstants.SHORT, TypeConstants.SHORT, TypeConstants.SHORT, TypeConstants.INT, TypeConstants.INT, TypeConstants.INT, TypeConstants.DATE,
                                                 TypeConstants.DATE, TypeConstants.DATE, TypeConstants.DATE, TypeConstants.SHORT, TypeConstants.DATE, TypeConstants.DATE, TypeConstants.SHORT, TypeConstants.BOOLEAN
                                                 }
            });
            lV79Seguridad_cierremoduloswwds_8_tfcmmodusuc = StringUtil.PadR( StringUtil.RTrim( AV79Seguridad_cierremoduloswwds_8_tfcmmodusuc), 10, "%");
            lV83Seguridad_cierremoduloswwds_12_tfcmmodusum = StringUtil.PadR( StringUtil.RTrim( AV83Seguridad_cierremoduloswwds_12_tfcmmodusum), 10, "%");
            /* Using cursor H000C2 */
            pr_default.execute(0, new Object[] {AV72Seguridad_cierremoduloswwds_1_cmmodano, AV73Seguridad_cierremoduloswwds_2_cmmodmes, AV74Seguridad_cierremoduloswwds_3_tfcmmodano, AV75Seguridad_cierremoduloswwds_4_tfcmmodano_to, lV79Seguridad_cierremoduloswwds_8_tfcmmodusuc, AV80Seguridad_cierremoduloswwds_9_tfcmmodusuc_sel, AV81Seguridad_cierremoduloswwds_10_tfcmmodfecc, AV82Seguridad_cierremoduloswwds_11_tfcmmodfecc_to, lV83Seguridad_cierremoduloswwds_12_tfcmmodusum, AV84Seguridad_cierremoduloswwds_13_tfcmmodusum_sel, AV85Seguridad_cierremoduloswwds_14_tfcmmodfecm, AV86Seguridad_cierremoduloswwds_15_tfcmmodfecm_to, GXPagingFrom2, GXPagingTo2, GXPagingTo2});
            nGXsfl_38_idx = 1;
            sGXsfl_38_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_38_idx), 4, 0), 4, "0");
            SubsflControlProps_382( ) ;
            while ( ( (pr_default.getStatus(0) != 101) ) && ( ( ( subGrid_Rows == 0 ) || ( GRID_nCurrentRecord < subGrid_fnc_Recordsperpage( ) ) ) ) )
            {
               A639CMModFecM = H000C2_A639CMModFecM[0];
               A642CMModUsuM = H000C2_A642CMModUsuM[0];
               A638CMModFecC = H000C2_A638CMModFecC[0];
               A641CMModUsuC = H000C2_A641CMModUsuC[0];
               A640CMModSts = H000C2_A640CMModSts[0];
               A73CMModCod = H000C2_A73CMModCod[0];
               A75CMModMes = H000C2_A75CMModMes[0];
               A74CMModAno = H000C2_A74CMModAno[0];
               E180C2 ();
               pr_default.readNext(0);
            }
            GRID_nEOF = (short)(((pr_default.getStatus(0) == 101) ? 1 : 0));
            GxWebStd.gx_hidden_field( context, "GRID_nEOF", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRID_nEOF), 1, 0, ".", "")));
            pr_default.close(0);
            wbEnd = 38;
            WB0C0( ) ;
         }
         bGXsfl_38_Refreshing = true;
      }

      protected void send_integrity_lvl_hashes0C2( )
      {
         GxWebStd.gx_hidden_field( context, "vPGMNAME", StringUtil.RTrim( AV71Pgmname));
         GxWebStd.gx_hidden_field( context, "gxhash_vPGMNAME", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( AV71Pgmname, "")), context));
         GxWebStd.gx_hidden_field( context, "gxhash_CMMODCOD"+"_"+sGXsfl_38_idx, GetSecureSignedToken( sGXsfl_38_idx, StringUtil.RTrim( context.localUtil.Format( A73CMModCod, "")), context));
         GxWebStd.gx_hidden_field( context, "gxhash_CMMODANO"+"_"+sGXsfl_38_idx, GetSecureSignedToken( sGXsfl_38_idx, context.localUtil.Format( (decimal)(A74CMModAno), "ZZZ9"), context));
         GxWebStd.gx_hidden_field( context, "gxhash_CMMODMES"+"_"+sGXsfl_38_idx, GetSecureSignedToken( sGXsfl_38_idx, context.localUtil.Format( (decimal)(A75CMModMes), "Z9"), context));
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
         AV72Seguridad_cierremoduloswwds_1_cmmodano = AV61CMModAno;
         AV73Seguridad_cierremoduloswwds_2_cmmodmes = AV62CMModMes;
         AV74Seguridad_cierremoduloswwds_3_tfcmmodano = AV33TFCMModAno;
         AV75Seguridad_cierremoduloswwds_4_tfcmmodano_to = AV34TFCMModAno_To;
         AV76Seguridad_cierremoduloswwds_5_tfcmmodmes_sels = AV64TFCMModMes_Sels;
         AV77Seguridad_cierremoduloswwds_6_tfcmmodcod_sels = AV66TFCMModCod_Sels;
         AV78Seguridad_cierremoduloswwds_7_tfcmmodsts_sels = AV68TFCMModSts_Sels;
         AV79Seguridad_cierremoduloswwds_8_tfcmmodusuc = AV39TFCMModUsuC;
         AV80Seguridad_cierremoduloswwds_9_tfcmmodusuc_sel = AV40TFCMModUsuC_Sel;
         AV81Seguridad_cierremoduloswwds_10_tfcmmodfecc = AV41TFCMModFecC;
         AV82Seguridad_cierremoduloswwds_11_tfcmmodfecc_to = AV42TFCMModFecC_To;
         AV83Seguridad_cierremoduloswwds_12_tfcmmodusum = AV46TFCMModUsuM;
         AV84Seguridad_cierremoduloswwds_13_tfcmmodusum_sel = AV47TFCMModUsuM_Sel;
         AV85Seguridad_cierremoduloswwds_14_tfcmmodfecm = AV48TFCMModFecM;
         AV86Seguridad_cierremoduloswwds_15_tfcmmodfecm_to = AV49TFCMModFecM_To;
         pr_default.dynParam(1, new Object[]{ new Object[]{
                                              A75CMModMes ,
                                              AV76Seguridad_cierremoduloswwds_5_tfcmmodmes_sels ,
                                              A73CMModCod ,
                                              AV77Seguridad_cierremoduloswwds_6_tfcmmodcod_sels ,
                                              A640CMModSts ,
                                              AV78Seguridad_cierremoduloswwds_7_tfcmmodsts_sels ,
                                              AV72Seguridad_cierremoduloswwds_1_cmmodano ,
                                              AV73Seguridad_cierremoduloswwds_2_cmmodmes ,
                                              AV74Seguridad_cierremoduloswwds_3_tfcmmodano ,
                                              AV75Seguridad_cierremoduloswwds_4_tfcmmodano_to ,
                                              AV76Seguridad_cierremoduloswwds_5_tfcmmodmes_sels.Count ,
                                              AV77Seguridad_cierremoduloswwds_6_tfcmmodcod_sels.Count ,
                                              AV78Seguridad_cierremoduloswwds_7_tfcmmodsts_sels.Count ,
                                              AV80Seguridad_cierremoduloswwds_9_tfcmmodusuc_sel ,
                                              AV79Seguridad_cierremoduloswwds_8_tfcmmodusuc ,
                                              AV81Seguridad_cierremoduloswwds_10_tfcmmodfecc ,
                                              AV82Seguridad_cierremoduloswwds_11_tfcmmodfecc_to ,
                                              AV84Seguridad_cierremoduloswwds_13_tfcmmodusum_sel ,
                                              AV83Seguridad_cierremoduloswwds_12_tfcmmodusum ,
                                              AV85Seguridad_cierremoduloswwds_14_tfcmmodfecm ,
                                              AV86Seguridad_cierremoduloswwds_15_tfcmmodfecm_to ,
                                              A74CMModAno ,
                                              A641CMModUsuC ,
                                              A638CMModFecC ,
                                              A642CMModUsuM ,
                                              A639CMModFecM ,
                                              AV13OrderedBy ,
                                              AV14OrderedDsc } ,
                                              new int[]{
                                              TypeConstants.SHORT, TypeConstants.SHORT, TypeConstants.SHORT, TypeConstants.SHORT, TypeConstants.SHORT, TypeConstants.SHORT, TypeConstants.INT, TypeConstants.INT, TypeConstants.INT, TypeConstants.DATE,
                                              TypeConstants.DATE, TypeConstants.DATE, TypeConstants.DATE, TypeConstants.SHORT, TypeConstants.DATE, TypeConstants.DATE, TypeConstants.SHORT, TypeConstants.BOOLEAN
                                              }
         });
         lV79Seguridad_cierremoduloswwds_8_tfcmmodusuc = StringUtil.PadR( StringUtil.RTrim( AV79Seguridad_cierremoduloswwds_8_tfcmmodusuc), 10, "%");
         lV83Seguridad_cierremoduloswwds_12_tfcmmodusum = StringUtil.PadR( StringUtil.RTrim( AV83Seguridad_cierremoduloswwds_12_tfcmmodusum), 10, "%");
         /* Using cursor H000C3 */
         pr_default.execute(1, new Object[] {AV72Seguridad_cierremoduloswwds_1_cmmodano, AV73Seguridad_cierremoduloswwds_2_cmmodmes, AV74Seguridad_cierremoduloswwds_3_tfcmmodano, AV75Seguridad_cierremoduloswwds_4_tfcmmodano_to, lV79Seguridad_cierremoduloswwds_8_tfcmmodusuc, AV80Seguridad_cierremoduloswwds_9_tfcmmodusuc_sel, AV81Seguridad_cierremoduloswwds_10_tfcmmodfecc, AV82Seguridad_cierremoduloswwds_11_tfcmmodfecc_to, lV83Seguridad_cierremoduloswwds_12_tfcmmodusum, AV84Seguridad_cierremoduloswwds_13_tfcmmodusum_sel, AV85Seguridad_cierremoduloswwds_14_tfcmmodfecm, AV86Seguridad_cierremoduloswwds_15_tfcmmodfecm_to});
         GRID_nRecordCount = H000C3_AGRID_nRecordCount[0];
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
         AV72Seguridad_cierremoduloswwds_1_cmmodano = AV61CMModAno;
         AV73Seguridad_cierremoduloswwds_2_cmmodmes = AV62CMModMes;
         AV74Seguridad_cierremoduloswwds_3_tfcmmodano = AV33TFCMModAno;
         AV75Seguridad_cierremoduloswwds_4_tfcmmodano_to = AV34TFCMModAno_To;
         AV76Seguridad_cierremoduloswwds_5_tfcmmodmes_sels = AV64TFCMModMes_Sels;
         AV77Seguridad_cierremoduloswwds_6_tfcmmodcod_sels = AV66TFCMModCod_Sels;
         AV78Seguridad_cierremoduloswwds_7_tfcmmodsts_sels = AV68TFCMModSts_Sels;
         AV79Seguridad_cierremoduloswwds_8_tfcmmodusuc = AV39TFCMModUsuC;
         AV80Seguridad_cierremoduloswwds_9_tfcmmodusuc_sel = AV40TFCMModUsuC_Sel;
         AV81Seguridad_cierremoduloswwds_10_tfcmmodfecc = AV41TFCMModFecC;
         AV82Seguridad_cierremoduloswwds_11_tfcmmodfecc_to = AV42TFCMModFecC_To;
         AV83Seguridad_cierremoduloswwds_12_tfcmmodusum = AV46TFCMModUsuM;
         AV84Seguridad_cierremoduloswwds_13_tfcmmodusum_sel = AV47TFCMModUsuM_Sel;
         AV85Seguridad_cierremoduloswwds_14_tfcmmodfecm = AV48TFCMModFecM;
         AV86Seguridad_cierremoduloswwds_15_tfcmmodfecm_to = AV49TFCMModFecM_To;
         GRID_nFirstRecordOnPage = 0;
         GxWebStd.gx_hidden_field( context, "GRID_nFirstRecordOnPage", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRID_nFirstRecordOnPage), 15, 0, ".", "")));
         if ( isFullAjaxMode( ) )
         {
            gxgrGrid_refresh( subGrid_Rows, AV61CMModAno, AV62CMModMes, AV71Pgmname, AV33TFCMModAno, AV34TFCMModAno_To, AV64TFCMModMes_Sels, AV66TFCMModCod_Sels, AV68TFCMModSts_Sels, AV39TFCMModUsuC, AV40TFCMModUsuC_Sel, AV41TFCMModFecC, AV42TFCMModFecC_To, AV46TFCMModUsuM, AV47TFCMModUsuM_Sel, AV48TFCMModFecM, AV49TFCMModFecM_To, AV13OrderedBy, AV14OrderedDsc) ;
         }
         send_integrity_footer_hashes( ) ;
         return 0 ;
      }

      protected short subgrid_nextpage( )
      {
         AV72Seguridad_cierremoduloswwds_1_cmmodano = AV61CMModAno;
         AV73Seguridad_cierremoduloswwds_2_cmmodmes = AV62CMModMes;
         AV74Seguridad_cierremoduloswwds_3_tfcmmodano = AV33TFCMModAno;
         AV75Seguridad_cierremoduloswwds_4_tfcmmodano_to = AV34TFCMModAno_To;
         AV76Seguridad_cierremoduloswwds_5_tfcmmodmes_sels = AV64TFCMModMes_Sels;
         AV77Seguridad_cierremoduloswwds_6_tfcmmodcod_sels = AV66TFCMModCod_Sels;
         AV78Seguridad_cierremoduloswwds_7_tfcmmodsts_sels = AV68TFCMModSts_Sels;
         AV79Seguridad_cierremoduloswwds_8_tfcmmodusuc = AV39TFCMModUsuC;
         AV80Seguridad_cierremoduloswwds_9_tfcmmodusuc_sel = AV40TFCMModUsuC_Sel;
         AV81Seguridad_cierremoduloswwds_10_tfcmmodfecc = AV41TFCMModFecC;
         AV82Seguridad_cierremoduloswwds_11_tfcmmodfecc_to = AV42TFCMModFecC_To;
         AV83Seguridad_cierremoduloswwds_12_tfcmmodusum = AV46TFCMModUsuM;
         AV84Seguridad_cierremoduloswwds_13_tfcmmodusum_sel = AV47TFCMModUsuM_Sel;
         AV85Seguridad_cierremoduloswwds_14_tfcmmodfecm = AV48TFCMModFecM;
         AV86Seguridad_cierremoduloswwds_15_tfcmmodfecm_to = AV49TFCMModFecM_To;
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
            gxgrGrid_refresh( subGrid_Rows, AV61CMModAno, AV62CMModMes, AV71Pgmname, AV33TFCMModAno, AV34TFCMModAno_To, AV64TFCMModMes_Sels, AV66TFCMModCod_Sels, AV68TFCMModSts_Sels, AV39TFCMModUsuC, AV40TFCMModUsuC_Sel, AV41TFCMModFecC, AV42TFCMModFecC_To, AV46TFCMModUsuM, AV47TFCMModUsuM_Sel, AV48TFCMModFecM, AV49TFCMModFecM_To, AV13OrderedBy, AV14OrderedDsc) ;
         }
         send_integrity_footer_hashes( ) ;
         return (short)(((GRID_nEOF==0) ? 0 : 2)) ;
      }

      protected short subgrid_previouspage( )
      {
         AV72Seguridad_cierremoduloswwds_1_cmmodano = AV61CMModAno;
         AV73Seguridad_cierremoduloswwds_2_cmmodmes = AV62CMModMes;
         AV74Seguridad_cierremoduloswwds_3_tfcmmodano = AV33TFCMModAno;
         AV75Seguridad_cierremoduloswwds_4_tfcmmodano_to = AV34TFCMModAno_To;
         AV76Seguridad_cierremoduloswwds_5_tfcmmodmes_sels = AV64TFCMModMes_Sels;
         AV77Seguridad_cierremoduloswwds_6_tfcmmodcod_sels = AV66TFCMModCod_Sels;
         AV78Seguridad_cierremoduloswwds_7_tfcmmodsts_sels = AV68TFCMModSts_Sels;
         AV79Seguridad_cierremoduloswwds_8_tfcmmodusuc = AV39TFCMModUsuC;
         AV80Seguridad_cierremoduloswwds_9_tfcmmodusuc_sel = AV40TFCMModUsuC_Sel;
         AV81Seguridad_cierremoduloswwds_10_tfcmmodfecc = AV41TFCMModFecC;
         AV82Seguridad_cierremoduloswwds_11_tfcmmodfecc_to = AV42TFCMModFecC_To;
         AV83Seguridad_cierremoduloswwds_12_tfcmmodusum = AV46TFCMModUsuM;
         AV84Seguridad_cierremoduloswwds_13_tfcmmodusum_sel = AV47TFCMModUsuM_Sel;
         AV85Seguridad_cierremoduloswwds_14_tfcmmodfecm = AV48TFCMModFecM;
         AV86Seguridad_cierremoduloswwds_15_tfcmmodfecm_to = AV49TFCMModFecM_To;
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
            gxgrGrid_refresh( subGrid_Rows, AV61CMModAno, AV62CMModMes, AV71Pgmname, AV33TFCMModAno, AV34TFCMModAno_To, AV64TFCMModMes_Sels, AV66TFCMModCod_Sels, AV68TFCMModSts_Sels, AV39TFCMModUsuC, AV40TFCMModUsuC_Sel, AV41TFCMModFecC, AV42TFCMModFecC_To, AV46TFCMModUsuM, AV47TFCMModUsuM_Sel, AV48TFCMModFecM, AV49TFCMModFecM_To, AV13OrderedBy, AV14OrderedDsc) ;
         }
         send_integrity_footer_hashes( ) ;
         return 0 ;
      }

      protected short subgrid_lastpage( )
      {
         AV72Seguridad_cierremoduloswwds_1_cmmodano = AV61CMModAno;
         AV73Seguridad_cierremoduloswwds_2_cmmodmes = AV62CMModMes;
         AV74Seguridad_cierremoduloswwds_3_tfcmmodano = AV33TFCMModAno;
         AV75Seguridad_cierremoduloswwds_4_tfcmmodano_to = AV34TFCMModAno_To;
         AV76Seguridad_cierremoduloswwds_5_tfcmmodmes_sels = AV64TFCMModMes_Sels;
         AV77Seguridad_cierremoduloswwds_6_tfcmmodcod_sels = AV66TFCMModCod_Sels;
         AV78Seguridad_cierremoduloswwds_7_tfcmmodsts_sels = AV68TFCMModSts_Sels;
         AV79Seguridad_cierremoduloswwds_8_tfcmmodusuc = AV39TFCMModUsuC;
         AV80Seguridad_cierremoduloswwds_9_tfcmmodusuc_sel = AV40TFCMModUsuC_Sel;
         AV81Seguridad_cierremoduloswwds_10_tfcmmodfecc = AV41TFCMModFecC;
         AV82Seguridad_cierremoduloswwds_11_tfcmmodfecc_to = AV42TFCMModFecC_To;
         AV83Seguridad_cierremoduloswwds_12_tfcmmodusum = AV46TFCMModUsuM;
         AV84Seguridad_cierremoduloswwds_13_tfcmmodusum_sel = AV47TFCMModUsuM_Sel;
         AV85Seguridad_cierremoduloswwds_14_tfcmmodfecm = AV48TFCMModFecM;
         AV86Seguridad_cierremoduloswwds_15_tfcmmodfecm_to = AV49TFCMModFecM_To;
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
            gxgrGrid_refresh( subGrid_Rows, AV61CMModAno, AV62CMModMes, AV71Pgmname, AV33TFCMModAno, AV34TFCMModAno_To, AV64TFCMModMes_Sels, AV66TFCMModCod_Sels, AV68TFCMModSts_Sels, AV39TFCMModUsuC, AV40TFCMModUsuC_Sel, AV41TFCMModFecC, AV42TFCMModFecC_To, AV46TFCMModUsuM, AV47TFCMModUsuM_Sel, AV48TFCMModFecM, AV49TFCMModFecM_To, AV13OrderedBy, AV14OrderedDsc) ;
         }
         send_integrity_footer_hashes( ) ;
         return 0 ;
      }

      protected int subgrid_gotopage( int nPageNo )
      {
         AV72Seguridad_cierremoduloswwds_1_cmmodano = AV61CMModAno;
         AV73Seguridad_cierremoduloswwds_2_cmmodmes = AV62CMModMes;
         AV74Seguridad_cierremoduloswwds_3_tfcmmodano = AV33TFCMModAno;
         AV75Seguridad_cierremoduloswwds_4_tfcmmodano_to = AV34TFCMModAno_To;
         AV76Seguridad_cierremoduloswwds_5_tfcmmodmes_sels = AV64TFCMModMes_Sels;
         AV77Seguridad_cierremoduloswwds_6_tfcmmodcod_sels = AV66TFCMModCod_Sels;
         AV78Seguridad_cierremoduloswwds_7_tfcmmodsts_sels = AV68TFCMModSts_Sels;
         AV79Seguridad_cierremoduloswwds_8_tfcmmodusuc = AV39TFCMModUsuC;
         AV80Seguridad_cierremoduloswwds_9_tfcmmodusuc_sel = AV40TFCMModUsuC_Sel;
         AV81Seguridad_cierremoduloswwds_10_tfcmmodfecc = AV41TFCMModFecC;
         AV82Seguridad_cierremoduloswwds_11_tfcmmodfecc_to = AV42TFCMModFecC_To;
         AV83Seguridad_cierremoduloswwds_12_tfcmmodusum = AV46TFCMModUsuM;
         AV84Seguridad_cierremoduloswwds_13_tfcmmodusum_sel = AV47TFCMModUsuM_Sel;
         AV85Seguridad_cierremoduloswwds_14_tfcmmodfecm = AV48TFCMModFecM;
         AV86Seguridad_cierremoduloswwds_15_tfcmmodfecm_to = AV49TFCMModFecM_To;
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
            gxgrGrid_refresh( subGrid_Rows, AV61CMModAno, AV62CMModMes, AV71Pgmname, AV33TFCMModAno, AV34TFCMModAno_To, AV64TFCMModMes_Sels, AV66TFCMModCod_Sels, AV68TFCMModSts_Sels, AV39TFCMModUsuC, AV40TFCMModUsuC_Sel, AV41TFCMModFecC, AV42TFCMModFecC_To, AV46TFCMModUsuM, AV47TFCMModUsuM_Sel, AV48TFCMModFecM, AV49TFCMModFecM_To, AV13OrderedBy, AV14OrderedDsc) ;
         }
         send_integrity_footer_hashes( ) ;
         return (int)(0) ;
      }

      protected void before_start_formulas( )
      {
         AV71Pgmname = "Seguridad.CierreModulosWW";
         context.Gx_err = 0;
         fix_multi_value_controls( ) ;
      }

      protected void STRUP0C0( )
      {
         /* Before Start, stand alone formulas. */
         before_start_formulas( ) ;
         /* Execute Start event if defined. */
         context.wbGlbDoneStart = 0;
         /* Execute user event: Start */
         E160C2 ();
         context.wbGlbDoneStart = 1;
         /* After Start, stand alone formulas. */
         if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
         {
            /* Read saved SDTs. */
            ajax_req_read_hidden_sdt(cgiGet( "vAGEXPORTDATA"), AV59AGExportData);
            ajax_req_read_hidden_sdt(cgiGet( "vDDO_TITLESETTINGSICONS"), AV53DDO_TitleSettingsIcons);
            /* Read saved values. */
            nRC_GXsfl_38 = (int)(context.localUtil.CToN( cgiGet( "nRC_GXsfl_38"), ".", ","));
            AV55GridCurrentPage = (long)(context.localUtil.CToN( cgiGet( "vGRIDCURRENTPAGE"), ".", ","));
            AV56GridPageCount = (long)(context.localUtil.CToN( cgiGet( "vGRIDPAGECOUNT"), ".", ","));
            AV57GridAppliedFilters = cgiGet( "vGRIDAPPLIEDFILTERS");
            AV43DDO_CMModFecCAuxDate = context.localUtil.CToD( cgiGet( "vDDO_CMMODFECCAUXDATE"), 0);
            AV44DDO_CMModFecCAuxDateTo = context.localUtil.CToD( cgiGet( "vDDO_CMMODFECCAUXDATETO"), 0);
            AV50DDO_CMModFecMAuxDate = context.localUtil.CToD( cgiGet( "vDDO_CMMODFECMAUXDATE"), 0);
            AV51DDO_CMModFecMAuxDateTo = context.localUtil.CToD( cgiGet( "vDDO_CMMODFECMAUXDATETO"), 0);
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
            if ( ( ( context.localUtil.CToN( cgiGet( edtavCmmodano_Internalname), ".", ",") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtavCmmodano_Internalname), ".", ",") > Convert.ToDecimal( 9999 )) ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "vCMMODANO");
               GX_FocusControl = edtavCmmodano_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               AV61CMModAno = 0;
               AssignAttri("", false, "AV61CMModAno", StringUtil.LTrimStr( (decimal)(AV61CMModAno), 4, 0));
            }
            else
            {
               AV61CMModAno = (short)(context.localUtil.CToN( cgiGet( edtavCmmodano_Internalname), ".", ","));
               AssignAttri("", false, "AV61CMModAno", StringUtil.LTrimStr( (decimal)(AV61CMModAno), 4, 0));
            }
            cmbavCmmodmes.Name = cmbavCmmodmes_Internalname;
            cmbavCmmodmes.CurrentValue = cgiGet( cmbavCmmodmes_Internalname);
            AV62CMModMes = (short)(NumberUtil.Val( cgiGet( cmbavCmmodmes_Internalname), "."));
            AssignAttri("", false, "AV62CMModMes", StringUtil.LTrimStr( (decimal)(AV62CMModMes), 2, 0));
            AV45DDO_CMModFecCAuxDateText = cgiGet( edtavDdo_cmmodfeccauxdatetext_Internalname);
            AssignAttri("", false, "AV45DDO_CMModFecCAuxDateText", AV45DDO_CMModFecCAuxDateText);
            AV52DDO_CMModFecMAuxDateText = cgiGet( edtavDdo_cmmodfecmauxdatetext_Internalname);
            AssignAttri("", false, "AV52DDO_CMModFecMAuxDateText", AV52DDO_CMModFecMAuxDateText);
            /* Read subfile selected row values. */
            /* Read hidden variables. */
            GXKey = Crypto.GetSiteKey( );
            /* Check if conditions changed and reset current page numbers */
            if ( ( context.localUtil.CToN( cgiGet( "GXH_vCMMODANO"), ".", ",") != Convert.ToDecimal( AV61CMModAno )) )
            {
               GRID_nFirstRecordOnPage = 0;
            }
            if ( ( context.localUtil.CToN( cgiGet( "GXH_vCMMODMES"), ".", ",") != Convert.ToDecimal( AV62CMModMes )) )
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
         E160C2 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
      }

      protected void E160C2( )
      {
         /* Start Routine */
         returnInSub = false;
         this.executeUsercontrolMethod("", false, "TFCMMODFECM_RANGEPICKERContainer", "Attach", "", new Object[] {(string)edtavDdo_cmmodfecmauxdatetext_Internalname});
         this.executeUsercontrolMethod("", false, "TFCMMODFECC_RANGEPICKERContainer", "Attach", "", new Object[] {(string)edtavDdo_cmmodfeccauxdatetext_Internalname});
         subGrid_Rows = 10;
         GxWebStd.gx_hidden_field( context, "GRID_Rows", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid_Rows), 6, 0, ".", "")));
         Grid_empowerer_Gridinternalname = subGrid_Internalname;
         ucGrid_empowerer.SendProperty(context, "", false, Grid_empowerer_Internalname, "GridInternalName", Grid_empowerer_Gridinternalname);
         Ddo_agexport_Titlecontrolidtoreplace = bttBtnagexport_Internalname;
         ucDdo_agexport.SendProperty(context, "", false, Ddo_agexport_Internalname, "TitleControlIdToReplace", Ddo_agexport_Titlecontrolidtoreplace);
         AV59AGExportData = new GXBaseCollection<GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTDropDownOptionsData_Item>( context, "Item", "");
         AV60AGExportDataItem = new GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTDropDownOptionsData_Item(context);
         AV60AGExportDataItem.gxTpr_Title = "PDF";
         AV60AGExportDataItem.gxTpr_Icon = context.convertURL( (string)(context.GetImagePath( "776fb79c-a0a1-4302-b5e5-d773dbe1a297", "", context.GetTheme( ))));
         AV60AGExportDataItem.gxTpr_Eventkey = "ExportReport";
         AV60AGExportDataItem.gxTpr_Isdivider = false;
         AV59AGExportData.Add(AV60AGExportDataItem, 0);
         AV60AGExportDataItem = new GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTDropDownOptionsData_Item(context);
         AV60AGExportDataItem.gxTpr_Title = "Excel";
         AV60AGExportDataItem.gxTpr_Icon = context.convertURL( (string)(context.GetImagePath( "da69a816-fd11-445b-8aaf-1a2f7f1acc93", "", context.GetTheme( ))));
         AV60AGExportDataItem.gxTpr_Eventkey = "Export";
         AV60AGExportDataItem.gxTpr_Isdivider = false;
         AV59AGExportData.Add(AV60AGExportDataItem, 0);
         AV61CMModAno = (short)(DateTimeUtil.Year( DateTimeUtil.Today( context)));
         AssignAttri("", false, "AV61CMModAno", StringUtil.LTrimStr( (decimal)(AV61CMModAno), 4, 0));
         AV62CMModMes = (short)(DateTimeUtil.Month( DateTimeUtil.Today( context)));
         AssignAttri("", false, "AV62CMModMes", StringUtil.LTrimStr( (decimal)(AV62CMModMes), 2, 0));
         Ddo_grid_Gridinternalname = subGrid_Internalname;
         ucDdo_grid.SendProperty(context, "", false, Ddo_grid_Internalname, "GridInternalName", Ddo_grid_Gridinternalname);
         Form.Caption = " Cierre Modulos";
         AssignProp("", false, "FORM", "Caption", Form.Caption, true);
         /* Execute user subroutine: 'PREPARETRANSACTION' */
         S112 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
         /* Execute user subroutine: 'LOADGRIDSTATE' */
         S122 ();
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
            S132 ();
            if ( returnInSub )
            {
               returnInSub = true;
               if (true) return;
            }
         }
         GXt_SdtDVB_SDTDropDownOptionsTitleSettingsIcons1 = AV53DDO_TitleSettingsIcons;
         new GeneXus.Programs.wwpbaseobjects.getwwptitlesettingsicons(context ).execute( out  GXt_SdtDVB_SDTDropDownOptionsTitleSettingsIcons1) ;
         AV53DDO_TitleSettingsIcons = GXt_SdtDVB_SDTDropDownOptionsTitleSettingsIcons1;
         Gridpaginationbar_Rowsperpageselectedvalue = subGrid_Rows;
         ucGridpaginationbar.SendProperty(context, "", false, Gridpaginationbar_Internalname, "RowsPerPageSelectedValue", StringUtil.LTrimStr( (decimal)(Gridpaginationbar_Rowsperpageselectedvalue), 9, 0));
      }

      protected void E170C2( )
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
         S142 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
         AV55GridCurrentPage = subGrid_fnc_Currentpage( );
         AssignAttri("", false, "AV55GridCurrentPage", StringUtil.LTrimStr( (decimal)(AV55GridCurrentPage), 10, 0));
         AV56GridPageCount = subGrid_fnc_Pagecount( );
         AssignAttri("", false, "AV56GridPageCount", StringUtil.LTrimStr( (decimal)(AV56GridPageCount), 10, 0));
         GXt_char2 = AV57GridAppliedFilters;
         new GeneXus.Programs.wwpbaseobjects.wwp_getappliedfiltersdescription(context ).execute(  AV71Pgmname, out  GXt_char2) ;
         AV57GridAppliedFilters = GXt_char2;
         AssignAttri("", false, "AV57GridAppliedFilters", AV57GridAppliedFilters);
         AV72Seguridad_cierremoduloswwds_1_cmmodano = AV61CMModAno;
         AV73Seguridad_cierremoduloswwds_2_cmmodmes = AV62CMModMes;
         AV74Seguridad_cierremoduloswwds_3_tfcmmodano = AV33TFCMModAno;
         AV75Seguridad_cierremoduloswwds_4_tfcmmodano_to = AV34TFCMModAno_To;
         AV76Seguridad_cierremoduloswwds_5_tfcmmodmes_sels = AV64TFCMModMes_Sels;
         AV77Seguridad_cierremoduloswwds_6_tfcmmodcod_sels = AV66TFCMModCod_Sels;
         AV78Seguridad_cierremoduloswwds_7_tfcmmodsts_sels = AV68TFCMModSts_Sels;
         AV79Seguridad_cierremoduloswwds_8_tfcmmodusuc = AV39TFCMModUsuC;
         AV80Seguridad_cierremoduloswwds_9_tfcmmodusuc_sel = AV40TFCMModUsuC_Sel;
         AV81Seguridad_cierremoduloswwds_10_tfcmmodfecc = AV41TFCMModFecC;
         AV82Seguridad_cierremoduloswwds_11_tfcmmodfecc_to = AV42TFCMModFecC_To;
         AV83Seguridad_cierremoduloswwds_12_tfcmmodusum = AV46TFCMModUsuM;
         AV84Seguridad_cierremoduloswwds_13_tfcmmodusum_sel = AV47TFCMModUsuM_Sel;
         AV85Seguridad_cierremoduloswwds_14_tfcmmodfecm = AV48TFCMModFecM;
         AV86Seguridad_cierremoduloswwds_15_tfcmmodfecm_to = AV49TFCMModFecM_To;
         /*  Sending Event outputs  */
      }

      protected void E110C2( )
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
            AV54PageToGo = (int)(NumberUtil.Val( Gridpaginationbar_Selectedpage, "."));
            subgrid_gotopage( AV54PageToGo) ;
         }
      }

      protected void E120C2( )
      {
         /* Gridpaginationbar_Changerowsperpage Routine */
         returnInSub = false;
         subGrid_Rows = Gridpaginationbar_Rowsperpageselectedvalue;
         GxWebStd.gx_hidden_field( context, "GRID_Rows", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid_Rows), 6, 0, ".", "")));
         subgrid_firstpage( ) ;
         /*  Sending Event outputs  */
      }

      protected void E140C2( )
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
            S132 ();
            if ( returnInSub )
            {
               returnInSub = true;
               if (true) return;
            }
            subgrid_firstpage( ) ;
         }
         else if ( StringUtil.StrCmp(Ddo_grid_Activeeventkey, "<#Filter#>") == 0 )
         {
            if ( StringUtil.StrCmp(Ddo_grid_Selectedcolumn, "CMModAno") == 0 )
            {
               AV33TFCMModAno = (short)(NumberUtil.Val( Ddo_grid_Filteredtext_get, "."));
               AssignAttri("", false, "AV33TFCMModAno", StringUtil.LTrimStr( (decimal)(AV33TFCMModAno), 4, 0));
               AV34TFCMModAno_To = (short)(NumberUtil.Val( Ddo_grid_Filteredtextto_get, "."));
               AssignAttri("", false, "AV34TFCMModAno_To", StringUtil.LTrimStr( (decimal)(AV34TFCMModAno_To), 4, 0));
            }
            else if ( StringUtil.StrCmp(Ddo_grid_Selectedcolumn, "CMModMes") == 0 )
            {
               AV63TFCMModMes_SelsJson = Ddo_grid_Selectedvalue_get;
               AssignAttri("", false, "AV63TFCMModMes_SelsJson", AV63TFCMModMes_SelsJson);
               AV64TFCMModMes_Sels.FromJSonString(StringUtil.StringReplace( AV63TFCMModMes_SelsJson, "\"", ""), null);
            }
            else if ( StringUtil.StrCmp(Ddo_grid_Selectedcolumn, "CMModCod") == 0 )
            {
               AV65TFCMModCod_SelsJson = Ddo_grid_Selectedvalue_get;
               AssignAttri("", false, "AV65TFCMModCod_SelsJson", AV65TFCMModCod_SelsJson);
               AV66TFCMModCod_Sels.FromJSonString(AV65TFCMModCod_SelsJson, null);
            }
            else if ( StringUtil.StrCmp(Ddo_grid_Selectedcolumn, "CMModSts") == 0 )
            {
               AV67TFCMModSts_SelsJson = Ddo_grid_Selectedvalue_get;
               AssignAttri("", false, "AV67TFCMModSts_SelsJson", AV67TFCMModSts_SelsJson);
               AV68TFCMModSts_Sels.FromJSonString(StringUtil.StringReplace( AV67TFCMModSts_SelsJson, "\"", ""), null);
            }
            else if ( StringUtil.StrCmp(Ddo_grid_Selectedcolumn, "CMModUsuC") == 0 )
            {
               AV39TFCMModUsuC = Ddo_grid_Filteredtext_get;
               AssignAttri("", false, "AV39TFCMModUsuC", AV39TFCMModUsuC);
               AV40TFCMModUsuC_Sel = Ddo_grid_Selectedvalue_get;
               AssignAttri("", false, "AV40TFCMModUsuC_Sel", AV40TFCMModUsuC_Sel);
            }
            else if ( StringUtil.StrCmp(Ddo_grid_Selectedcolumn, "CMModFecC") == 0 )
            {
               AV41TFCMModFecC = context.localUtil.CToD( Ddo_grid_Filteredtext_get, 2);
               AssignAttri("", false, "AV41TFCMModFecC", context.localUtil.Format(AV41TFCMModFecC, "99/99/99"));
               AV42TFCMModFecC_To = context.localUtil.CToD( Ddo_grid_Filteredtextto_get, 2);
               AssignAttri("", false, "AV42TFCMModFecC_To", context.localUtil.Format(AV42TFCMModFecC_To, "99/99/99"));
            }
            else if ( StringUtil.StrCmp(Ddo_grid_Selectedcolumn, "CMModUsuM") == 0 )
            {
               AV46TFCMModUsuM = Ddo_grid_Filteredtext_get;
               AssignAttri("", false, "AV46TFCMModUsuM", AV46TFCMModUsuM);
               AV47TFCMModUsuM_Sel = Ddo_grid_Selectedvalue_get;
               AssignAttri("", false, "AV47TFCMModUsuM_Sel", AV47TFCMModUsuM_Sel);
            }
            else if ( StringUtil.StrCmp(Ddo_grid_Selectedcolumn, "CMModFecM") == 0 )
            {
               AV48TFCMModFecM = context.localUtil.CToD( Ddo_grid_Filteredtext_get, 2);
               AssignAttri("", false, "AV48TFCMModFecM", context.localUtil.Format(AV48TFCMModFecM, "99/99/99"));
               AV49TFCMModFecM_To = context.localUtil.CToD( Ddo_grid_Filteredtextto_get, 2);
               AssignAttri("", false, "AV49TFCMModFecM_To", context.localUtil.Format(AV49TFCMModFecM_To, "99/99/99"));
            }
            subgrid_firstpage( ) ;
         }
         /*  Sending Event outputs  */
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV68TFCMModSts_Sels", AV68TFCMModSts_Sels);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV66TFCMModCod_Sels", AV66TFCMModCod_Sels);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV64TFCMModMes_Sels", AV64TFCMModMes_Sels);
      }

      private void E180C2( )
      {
         /* Grid_Load Routine */
         returnInSub = false;
         cmbavGridactions.removeAllItems();
         cmbavGridactions.addItem("0", ";fa fa-bars", 0);
         cmbavGridactions.addItem("1", StringUtil.Format( "%1;%2", "Modificar", "fa fa-pen", "", "", "", "", "", "", ""), 0);
         cmbavGridactions.addItem("2", StringUtil.Format( "%1;%2", "Eliminar", "fa fa-times", "", "", "", "", "", "", ""), 0);
         /* Load Method */
         if ( wbStart != -1 )
         {
            wbStart = 38;
         }
         sendrow_382( ) ;
         GRID_nCurrentRecord = (long)(GRID_nCurrentRecord+1);
         if ( isFullAjaxMode( ) && ! bGXsfl_38_Refreshing )
         {
            DoAjaxLoad(38, GridRow);
         }
         /*  Sending Event outputs  */
         cmbavGridactions.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV58GridActions), 4, 0));
      }

      protected void E190C2( )
      {
         /* Gridactions_Click Routine */
         returnInSub = false;
         if ( AV58GridActions == 1 )
         {
            /* Execute user subroutine: 'DO UPDATE' */
            S152 ();
            if ( returnInSub )
            {
               returnInSub = true;
               if (true) return;
            }
         }
         else if ( AV58GridActions == 2 )
         {
            /* Execute user subroutine: 'DO DELETE' */
            S162 ();
            if ( returnInSub )
            {
               returnInSub = true;
               if (true) return;
            }
         }
         AV58GridActions = 0;
         AssignAttri("", false, cmbavGridactions_Internalname, StringUtil.LTrimStr( (decimal)(AV58GridActions), 4, 0));
         /*  Sending Event outputs  */
         cmbavGridactions.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV58GridActions), 4, 0));
         AssignProp("", false, cmbavGridactions_Internalname, "Values", cmbavGridactions.ToJavascriptSource(), true);
      }

      protected void E150C2( )
      {
         /* 'DoInsert' Routine */
         returnInSub = false;
         GXKey = Crypto.GetSiteKey( );
         GXEncryptionTmp = "seguridad.cierremodulos.aspx"+UrlEncode(StringUtil.RTrim("INS")) + "," + UrlEncode(StringUtil.RTrim("")) + "," + UrlEncode(StringUtil.LTrimStr(0,1,0)) + "," + UrlEncode(StringUtil.LTrimStr(0,1,0));
         CallWebObject(formatLink("seguridad.cierremodulos.aspx") + "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey));
         context.wjLocDisableFrm = 1;
      }

      protected void E130C2( )
      {
         /* Ddo_agexport_Onoptionclicked Routine */
         returnInSub = false;
         if ( StringUtil.StrCmp(Ddo_agexport_Activeeventkey, "ExportReport") == 0 )
         {
            /* Execute user subroutine: 'DOEXPORTREPORT' */
            S172 ();
            if ( returnInSub )
            {
               returnInSub = true;
               if (true) return;
            }
         }
         else if ( StringUtil.StrCmp(Ddo_agexport_Activeeventkey, "Export") == 0 )
         {
            /* Execute user subroutine: 'DOEXPORT' */
            S182 ();
            if ( returnInSub )
            {
               returnInSub = true;
               if (true) return;
            }
         }
         /*  Sending Event outputs  */
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV68TFCMModSts_Sels", AV68TFCMModSts_Sels);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV66TFCMModCod_Sels", AV66TFCMModCod_Sels);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV64TFCMModMes_Sels", AV64TFCMModMes_Sels);
         cmbavCmmodmes.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV62CMModMes), 2, 0));
         AssignProp("", false, cmbavCmmodmes_Internalname, "Values", cmbavCmmodmes.ToJavascriptSource(), true);
      }

      protected void S132( )
      {
         /* 'SETDDOSORTEDSTATUS' Routine */
         returnInSub = false;
         Ddo_grid_Sortedstatus = StringUtil.Trim( StringUtil.Str( (decimal)(AV13OrderedBy), 4, 0))+":"+(AV14OrderedDsc ? "DSC" : "ASC");
         ucDdo_grid.SendProperty(context, "", false, Ddo_grid_Internalname, "SortedStatus", Ddo_grid_Sortedstatus);
      }

      protected void S152( )
      {
         /* 'DO UPDATE' Routine */
         returnInSub = false;
         GXKey = Crypto.GetSiteKey( );
         GXEncryptionTmp = "seguridad.cierremodulos.aspx"+UrlEncode(StringUtil.RTrim("UPD")) + "," + UrlEncode(StringUtil.RTrim(A73CMModCod)) + "," + UrlEncode(StringUtil.LTrimStr(A74CMModAno,4,0)) + "," + UrlEncode(StringUtil.LTrimStr(A75CMModMes,2,0));
         CallWebObject(formatLink("seguridad.cierremodulos.aspx") + "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey));
         context.wjLocDisableFrm = 1;
      }

      protected void S162( )
      {
         /* 'DO DELETE' Routine */
         returnInSub = false;
         GXKey = Crypto.GetSiteKey( );
         GXEncryptionTmp = "seguridad.cierremodulos.aspx"+UrlEncode(StringUtil.RTrim("DLT")) + "," + UrlEncode(StringUtil.RTrim(A73CMModCod)) + "," + UrlEncode(StringUtil.LTrimStr(A74CMModAno,4,0)) + "," + UrlEncode(StringUtil.LTrimStr(A75CMModMes,2,0));
         CallWebObject(formatLink("seguridad.cierremodulos.aspx") + "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey));
         context.wjLocDisableFrm = 1;
      }

      protected void S122( )
      {
         /* 'LOADGRIDSTATE' Routine */
         returnInSub = false;
         if ( StringUtil.StrCmp(AV30Session.Get(AV71Pgmname+"GridState"), "") == 0 )
         {
            AV10GridState.FromXml(new GeneXus.Programs.wwpbaseobjects.loadgridstate(context).executeUdp(  AV71Pgmname+"GridState"), null, "", "");
         }
         else
         {
            AV10GridState.FromXml(AV30Session.Get(AV71Pgmname+"GridState"), null, "", "");
         }
         AV13OrderedBy = AV10GridState.gxTpr_Orderedby;
         AssignAttri("", false, "AV13OrderedBy", StringUtil.LTrimStr( (decimal)(AV13OrderedBy), 4, 0));
         AV14OrderedDsc = AV10GridState.gxTpr_Ordereddsc;
         AssignAttri("", false, "AV14OrderedDsc", AV14OrderedDsc);
         /* Execute user subroutine: 'SETDDOSORTEDSTATUS' */
         S132 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
         AV87GXV1 = 1;
         while ( AV87GXV1 <= AV10GridState.gxTpr_Filtervalues.Count )
         {
            AV11GridStateFilterValue = ((GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue)AV10GridState.gxTpr_Filtervalues.Item(AV87GXV1));
            if ( StringUtil.StrCmp(AV11GridStateFilterValue.gxTpr_Name, "CMMODANO") == 0 )
            {
               AV61CMModAno = (short)(NumberUtil.Val( AV11GridStateFilterValue.gxTpr_Value, "."));
               AssignAttri("", false, "AV61CMModAno", StringUtil.LTrimStr( (decimal)(AV61CMModAno), 4, 0));
            }
            else if ( StringUtil.StrCmp(AV11GridStateFilterValue.gxTpr_Name, "CMMODMES") == 0 )
            {
               AV62CMModMes = (short)(NumberUtil.Val( AV11GridStateFilterValue.gxTpr_Value, "."));
               AssignAttri("", false, "AV62CMModMes", StringUtil.LTrimStr( (decimal)(AV62CMModMes), 2, 0));
            }
            else if ( StringUtil.StrCmp(AV11GridStateFilterValue.gxTpr_Name, "TFCMMODANO") == 0 )
            {
               AV33TFCMModAno = (short)(NumberUtil.Val( AV11GridStateFilterValue.gxTpr_Value, "."));
               AssignAttri("", false, "AV33TFCMModAno", StringUtil.LTrimStr( (decimal)(AV33TFCMModAno), 4, 0));
               AV34TFCMModAno_To = (short)(NumberUtil.Val( AV11GridStateFilterValue.gxTpr_Valueto, "."));
               AssignAttri("", false, "AV34TFCMModAno_To", StringUtil.LTrimStr( (decimal)(AV34TFCMModAno_To), 4, 0));
            }
            else if ( StringUtil.StrCmp(AV11GridStateFilterValue.gxTpr_Name, "TFCMMODMES_SEL") == 0 )
            {
               AV63TFCMModMes_SelsJson = AV11GridStateFilterValue.gxTpr_Value;
               AssignAttri("", false, "AV63TFCMModMes_SelsJson", AV63TFCMModMes_SelsJson);
               AV64TFCMModMes_Sels.FromJSonString(AV63TFCMModMes_SelsJson, null);
            }
            else if ( StringUtil.StrCmp(AV11GridStateFilterValue.gxTpr_Name, "TFCMMODCOD_SEL") == 0 )
            {
               AV65TFCMModCod_SelsJson = AV11GridStateFilterValue.gxTpr_Value;
               AssignAttri("", false, "AV65TFCMModCod_SelsJson", AV65TFCMModCod_SelsJson);
               AV66TFCMModCod_Sels.FromJSonString(AV65TFCMModCod_SelsJson, null);
            }
            else if ( StringUtil.StrCmp(AV11GridStateFilterValue.gxTpr_Name, "TFCMMODSTS_SEL") == 0 )
            {
               AV67TFCMModSts_SelsJson = AV11GridStateFilterValue.gxTpr_Value;
               AssignAttri("", false, "AV67TFCMModSts_SelsJson", AV67TFCMModSts_SelsJson);
               AV68TFCMModSts_Sels.FromJSonString(AV67TFCMModSts_SelsJson, null);
            }
            else if ( StringUtil.StrCmp(AV11GridStateFilterValue.gxTpr_Name, "TFCMMODUSUC") == 0 )
            {
               AV39TFCMModUsuC = AV11GridStateFilterValue.gxTpr_Value;
               AssignAttri("", false, "AV39TFCMModUsuC", AV39TFCMModUsuC);
            }
            else if ( StringUtil.StrCmp(AV11GridStateFilterValue.gxTpr_Name, "TFCMMODUSUC_SEL") == 0 )
            {
               AV40TFCMModUsuC_Sel = AV11GridStateFilterValue.gxTpr_Value;
               AssignAttri("", false, "AV40TFCMModUsuC_Sel", AV40TFCMModUsuC_Sel);
            }
            else if ( StringUtil.StrCmp(AV11GridStateFilterValue.gxTpr_Name, "TFCMMODFECC") == 0 )
            {
               AV41TFCMModFecC = context.localUtil.CToD( AV11GridStateFilterValue.gxTpr_Value, 2);
               AssignAttri("", false, "AV41TFCMModFecC", context.localUtil.Format(AV41TFCMModFecC, "99/99/99"));
               AV42TFCMModFecC_To = context.localUtil.CToD( AV11GridStateFilterValue.gxTpr_Valueto, 2);
               AssignAttri("", false, "AV42TFCMModFecC_To", context.localUtil.Format(AV42TFCMModFecC_To, "99/99/99"));
            }
            else if ( StringUtil.StrCmp(AV11GridStateFilterValue.gxTpr_Name, "TFCMMODUSUM") == 0 )
            {
               AV46TFCMModUsuM = AV11GridStateFilterValue.gxTpr_Value;
               AssignAttri("", false, "AV46TFCMModUsuM", AV46TFCMModUsuM);
            }
            else if ( StringUtil.StrCmp(AV11GridStateFilterValue.gxTpr_Name, "TFCMMODUSUM_SEL") == 0 )
            {
               AV47TFCMModUsuM_Sel = AV11GridStateFilterValue.gxTpr_Value;
               AssignAttri("", false, "AV47TFCMModUsuM_Sel", AV47TFCMModUsuM_Sel);
            }
            else if ( StringUtil.StrCmp(AV11GridStateFilterValue.gxTpr_Name, "TFCMMODFECM") == 0 )
            {
               AV48TFCMModFecM = context.localUtil.CToD( AV11GridStateFilterValue.gxTpr_Value, 2);
               AssignAttri("", false, "AV48TFCMModFecM", context.localUtil.Format(AV48TFCMModFecM, "99/99/99"));
               AV49TFCMModFecM_To = context.localUtil.CToD( AV11GridStateFilterValue.gxTpr_Valueto, 2);
               AssignAttri("", false, "AV49TFCMModFecM_To", context.localUtil.Format(AV49TFCMModFecM_To, "99/99/99"));
            }
            AV87GXV1 = (int)(AV87GXV1+1);
         }
         GXt_char2 = "";
         new GeneXus.Programs.wwpbaseobjects.wwp_getfilterval(context ).execute(  (AV66TFCMModCod_Sels.Count==0),  AV65TFCMModCod_SelsJson, out  GXt_char2) ;
         GXt_char3 = "";
         new GeneXus.Programs.wwpbaseobjects.wwp_getfilterval(context ).execute(  String.IsNullOrEmpty(StringUtil.RTrim( AV40TFCMModUsuC_Sel)),  AV40TFCMModUsuC_Sel, out  GXt_char3) ;
         GXt_char4 = "";
         new GeneXus.Programs.wwpbaseobjects.wwp_getfilterval(context ).execute(  String.IsNullOrEmpty(StringUtil.RTrim( AV47TFCMModUsuM_Sel)),  AV47TFCMModUsuM_Sel, out  GXt_char4) ;
         Ddo_grid_Selectedvalue_set = "|"+((AV64TFCMModMes_Sels.Count==0) ? "" : AV63TFCMModMes_SelsJson)+"|"+GXt_char2+"|"+((AV68TFCMModSts_Sels.Count==0) ? "" : AV67TFCMModSts_SelsJson)+"|"+GXt_char3+"||"+GXt_char4+"|";
         ucDdo_grid.SendProperty(context, "", false, Ddo_grid_Internalname, "SelectedValue_set", Ddo_grid_Selectedvalue_set);
         GXt_char4 = "";
         new GeneXus.Programs.wwpbaseobjects.wwp_getfilterval(context ).execute(  String.IsNullOrEmpty(StringUtil.RTrim( AV39TFCMModUsuC)),  AV39TFCMModUsuC, out  GXt_char4) ;
         GXt_char3 = "";
         new GeneXus.Programs.wwpbaseobjects.wwp_getfilterval(context ).execute(  String.IsNullOrEmpty(StringUtil.RTrim( AV46TFCMModUsuM)),  AV46TFCMModUsuM, out  GXt_char3) ;
         Ddo_grid_Filteredtext_set = ((0==AV33TFCMModAno) ? "" : StringUtil.Str( (decimal)(AV33TFCMModAno), 4, 0))+"||||"+GXt_char4+"|"+((DateTime.MinValue==AV41TFCMModFecC) ? "" : context.localUtil.DToC( AV41TFCMModFecC, 2, "/"))+"|"+GXt_char3+"|"+((DateTime.MinValue==AV48TFCMModFecM) ? "" : context.localUtil.DToC( AV48TFCMModFecM, 2, "/"));
         ucDdo_grid.SendProperty(context, "", false, Ddo_grid_Internalname, "FilteredText_set", Ddo_grid_Filteredtext_set);
         Ddo_grid_Filteredtextto_set = ((0==AV34TFCMModAno_To) ? "" : StringUtil.Str( (decimal)(AV34TFCMModAno_To), 4, 0))+"|||||"+((DateTime.MinValue==AV42TFCMModFecC_To) ? "" : context.localUtil.DToC( AV42TFCMModFecC_To, 2, "/"))+"||"+((DateTime.MinValue==AV49TFCMModFecM_To) ? "" : context.localUtil.DToC( AV49TFCMModFecM_To, 2, "/"));
         ucDdo_grid.SendProperty(context, "", false, Ddo_grid_Internalname, "FilteredTextTo_set", Ddo_grid_Filteredtextto_set);
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( StringUtil.Trim( AV10GridState.gxTpr_Pagesize))) )
         {
            subGrid_Rows = (int)(NumberUtil.Val( AV10GridState.gxTpr_Pagesize, "."));
            GxWebStd.gx_hidden_field( context, "GRID_Rows", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid_Rows), 6, 0, ".", "")));
         }
         subgrid_gotopage( AV10GridState.gxTpr_Currentpage) ;
      }

      protected void S142( )
      {
         /* 'SAVEGRIDSTATE' Routine */
         returnInSub = false;
         AV10GridState.FromXml(AV30Session.Get(AV71Pgmname+"GridState"), null, "", "");
         AV10GridState.gxTpr_Orderedby = AV13OrderedBy;
         AV10GridState.gxTpr_Ordereddsc = AV14OrderedDsc;
         AV10GridState.gxTpr_Filtervalues.Clear();
         new GeneXus.Programs.wwpbaseobjects.wwp_gridstateaddfiltervalue(context ).execute( ref  AV10GridState,  "CMMODANO",  "Año",  true,  0,  StringUtil.Trim( StringUtil.Str( (decimal)(AV61CMModAno), 4, 0)),  "") ;
         new GeneXus.Programs.wwpbaseobjects.wwp_gridstateaddfiltervalue(context ).execute( ref  AV10GridState,  "CMMODMES",  "Mes",  true,  0,  StringUtil.Trim( StringUtil.Str( (decimal)(AV62CMModMes), 2, 0)),  "") ;
         new GeneXus.Programs.wwpbaseobjects.wwp_gridstateaddfiltervalue(context ).execute( ref  AV10GridState,  "TFCMMODANO",  "Año",  !((0==AV33TFCMModAno)&&(0==AV34TFCMModAno_To)),  0,  StringUtil.Trim( StringUtil.Str( (decimal)(AV33TFCMModAno), 4, 0)),  StringUtil.Trim( StringUtil.Str( (decimal)(AV34TFCMModAno_To), 4, 0))) ;
         new GeneXus.Programs.wwpbaseobjects.wwp_gridstateaddfiltervalue(context ).execute( ref  AV10GridState,  "TFCMMODMES_SEL",  "Mes",  !(AV64TFCMModMes_Sels.Count==0),  0,  AV64TFCMModMes_Sels.ToJSonString(false),  "") ;
         new GeneXus.Programs.wwpbaseobjects.wwp_gridstateaddfiltervalue(context ).execute( ref  AV10GridState,  "TFCMMODCOD_SEL",  "Modulo",  !(AV66TFCMModCod_Sels.Count==0),  0,  AV66TFCMModCod_Sels.ToJSonString(false),  "") ;
         new GeneXus.Programs.wwpbaseobjects.wwp_gridstateaddfiltervalue(context ).execute( ref  AV10GridState,  "TFCMMODSTS_SEL",  "Estado",  !(AV68TFCMModSts_Sels.Count==0),  0,  AV68TFCMModSts_Sels.ToJSonString(false),  "") ;
         new GeneXus.Programs.wwpbaseobjects.wwp_gridstateaddfiltervalueandsel(context ).execute( ref  AV10GridState,  "TFCMMODUSUC",  "Usuario Creación",  !String.IsNullOrEmpty(StringUtil.RTrim( AV39TFCMModUsuC)),  0,  AV39TFCMModUsuC,  "",  !String.IsNullOrEmpty(StringUtil.RTrim( AV40TFCMModUsuC_Sel)),  AV40TFCMModUsuC_Sel,  "") ;
         new GeneXus.Programs.wwpbaseobjects.wwp_gridstateaddfiltervalue(context ).execute( ref  AV10GridState,  "TFCMMODFECC",  "Fecha Creación",  !((DateTime.MinValue==AV41TFCMModFecC)&&(DateTime.MinValue==AV42TFCMModFecC_To)),  0,  StringUtil.Trim( context.localUtil.DToC( AV41TFCMModFecC, 2, "/")),  StringUtil.Trim( context.localUtil.DToC( AV42TFCMModFecC_To, 2, "/"))) ;
         new GeneXus.Programs.wwpbaseobjects.wwp_gridstateaddfiltervalueandsel(context ).execute( ref  AV10GridState,  "TFCMMODUSUM",  "Usuario Modificación",  !String.IsNullOrEmpty(StringUtil.RTrim( AV46TFCMModUsuM)),  0,  AV46TFCMModUsuM,  "",  !String.IsNullOrEmpty(StringUtil.RTrim( AV47TFCMModUsuM_Sel)),  AV47TFCMModUsuM_Sel,  "") ;
         new GeneXus.Programs.wwpbaseobjects.wwp_gridstateaddfiltervalue(context ).execute( ref  AV10GridState,  "TFCMMODFECM",  "Fecha Modificación",  !((DateTime.MinValue==AV48TFCMModFecM)&&(DateTime.MinValue==AV49TFCMModFecM_To)),  0,  StringUtil.Trim( context.localUtil.DToC( AV48TFCMModFecM, 2, "/")),  StringUtil.Trim( context.localUtil.DToC( AV49TFCMModFecM_To, 2, "/"))) ;
         AV10GridState.gxTpr_Pagesize = StringUtil.Str( (decimal)(subGrid_Rows), 10, 0);
         AV10GridState.gxTpr_Currentpage = (short)(subGrid_fnc_Currentpage( ));
         new GeneXus.Programs.wwpbaseobjects.savegridstate(context ).execute(  AV71Pgmname+"GridState",  AV10GridState.ToXml(false, true, "", "")) ;
      }

      protected void S112( )
      {
         /* 'PREPARETRANSACTION' Routine */
         returnInSub = false;
         AV8TrnContext = new GeneXus.Programs.wwpbaseobjects.SdtWWPTransactionContext(context);
         AV8TrnContext.gxTpr_Callerobject = AV71Pgmname;
         AV8TrnContext.gxTpr_Callerondelete = true;
         AV8TrnContext.gxTpr_Callerurl = AV7HTTPRequest.ScriptName+"?"+AV7HTTPRequest.QueryString;
         AV8TrnContext.gxTpr_Transactionname = "Seguridad.CierreModulos";
         AV30Session.Set("TrnContext", AV8TrnContext.ToXml(false, true, "", ""));
      }

      protected void S182( )
      {
         /* 'DOEXPORT' Routine */
         returnInSub = false;
         /* Execute user subroutine: 'LOADGRIDSTATE' */
         S122 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
         new GeneXus.Programs.seguridad.cierremoduloswwexport(context ).execute( out  AV28ExcelFilename, out  AV29ErrorMessage) ;
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

      protected void S172( )
      {
         /* 'DOEXPORTREPORT' Routine */
         returnInSub = false;
         /* Execute user subroutine: 'LOADGRIDSTATE' */
         S122 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
         Innewwindow1_Target = formatLink("seguridad.cierremoduloswwexportreport.aspx") ;
         ucInnewwindow1.SendProperty(context, "", false, Innewwindow1_Internalname, "Target", Innewwindow1_Target);
         Innewwindow1_Height = "600";
         ucInnewwindow1.SendProperty(context, "", false, Innewwindow1_Internalname, "Height", Innewwindow1_Height);
         Innewwindow1_Width = "800";
         ucInnewwindow1.SendProperty(context, "", false, Innewwindow1_Internalname, "Width", Innewwindow1_Width);
         this.executeUsercontrolMethod("", false, "INNEWWINDOW1Container", "OpenWindow", "", new Object[] {});
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
         PA0C2( ) ;
         WS0C2( ) ;
         WE0C2( ) ;
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
            context.AddJavascriptSource(StringUtil.RTrim( ((string)Form.Jscriptsrc.Item(idxLst))), "?202281810273091", true, true);
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
         context.AddJavascriptSource("seguridad/cierremodulosww.js", "?202281810273092", false, true);
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
         context.AddJavascriptSource("DVelop/Shared/daterangepicker/locales.js", "", false, true);
         context.AddJavascriptSource("DVelop/Shared/daterangepicker/wwp-daterangepicker.js", "", false, true);
         context.AddJavascriptSource("DVelop/Shared/daterangepicker/moment.min.js", "", false, true);
         context.AddJavascriptSource("DVelop/Shared/daterangepicker/daterangepicker.min.js", "", false, true);
         context.AddJavascriptSource("DVelop/Shared/WorkWithPlusCommon.js", "", false, true);
         context.AddJavascriptSource("DVelop/DateRangePicker/DateRangePickerRender.js", "", false, true);
         /* End function include_jscripts */
      }

      protected void SubsflControlProps_382( )
      {
         cmbavGridactions_Internalname = "vGRIDACTIONS_"+sGXsfl_38_idx;
         edtCMModAno_Internalname = "CMMODANO_"+sGXsfl_38_idx;
         cmbCMModMes_Internalname = "CMMODMES_"+sGXsfl_38_idx;
         cmbCMModCod_Internalname = "CMMODCOD_"+sGXsfl_38_idx;
         cmbCMModSts_Internalname = "CMMODSTS_"+sGXsfl_38_idx;
         edtCMModUsuC_Internalname = "CMMODUSUC_"+sGXsfl_38_idx;
         edtCMModFecC_Internalname = "CMMODFECC_"+sGXsfl_38_idx;
         edtCMModUsuM_Internalname = "CMMODUSUM_"+sGXsfl_38_idx;
         edtCMModFecM_Internalname = "CMMODFECM_"+sGXsfl_38_idx;
      }

      protected void SubsflControlProps_fel_382( )
      {
         cmbavGridactions_Internalname = "vGRIDACTIONS_"+sGXsfl_38_fel_idx;
         edtCMModAno_Internalname = "CMMODANO_"+sGXsfl_38_fel_idx;
         cmbCMModMes_Internalname = "CMMODMES_"+sGXsfl_38_fel_idx;
         cmbCMModCod_Internalname = "CMMODCOD_"+sGXsfl_38_fel_idx;
         cmbCMModSts_Internalname = "CMMODSTS_"+sGXsfl_38_fel_idx;
         edtCMModUsuC_Internalname = "CMMODUSUC_"+sGXsfl_38_fel_idx;
         edtCMModFecC_Internalname = "CMMODFECC_"+sGXsfl_38_fel_idx;
         edtCMModUsuM_Internalname = "CMMODUSUM_"+sGXsfl_38_fel_idx;
         edtCMModFecM_Internalname = "CMMODFECM_"+sGXsfl_38_fel_idx;
      }

      protected void sendrow_382( )
      {
         SubsflControlProps_382( ) ;
         WB0C0( ) ;
         if ( ( subGrid_Rows * 1 == 0 ) || ( nGXsfl_38_idx <= subGrid_fnc_Recordsperpage( ) * 1 ) )
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
               if ( ((int)((nGXsfl_38_idx) % (2))) == 0 )
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
               context.WriteHtmlText( " gxrow=\""+sGXsfl_38_idx+"\">") ;
            }
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"right"+"\""+" style=\""+""+"\">") ;
            }
            TempTags = " " + ((cmbavGridactions.Enabled!=0)&&(cmbavGridactions.Visible!=0) ? " onfocus=\"gx.evt.onfocus(this, 39,'',false,'"+sGXsfl_38_idx+"',38)\"" : " ");
            if ( ( cmbavGridactions.ItemCount == 0 ) && isAjaxCallMode( ) )
            {
               GXCCtl = "vGRIDACTIONS_" + sGXsfl_38_idx;
               cmbavGridactions.Name = GXCCtl;
               cmbavGridactions.WebTags = "";
               if ( cmbavGridactions.ItemCount > 0 )
               {
                  AV58GridActions = (short)(NumberUtil.Val( cmbavGridactions.getValidValue(StringUtil.Trim( StringUtil.Str( (decimal)(AV58GridActions), 4, 0))), "."));
                  AssignAttri("", false, cmbavGridactions_Internalname, StringUtil.LTrimStr( (decimal)(AV58GridActions), 4, 0));
               }
            }
            /* ComboBox */
            GridRow.AddColumnProperties("combobox", 2, isAjaxCallMode( ), new Object[] {(GXCombobox)cmbavGridactions,(string)cmbavGridactions_Internalname,StringUtil.Trim( StringUtil.Str( (decimal)(AV58GridActions), 4, 0)),(short)1,(string)cmbavGridactions_Jsonclick,(short)5,"'"+""+"'"+",false,"+"'"+"EVGRIDACTIONS.CLICK."+sGXsfl_38_idx+"'",(string)"int",(string)"",(short)-1,(short)1,(short)0,(short)0,(short)0,(string)"px",(short)0,(string)"px",(string)"",(string)"ConvertToDDO",(string)"WWActionGroupColumn",(string)"",TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+((cmbavGridactions.Enabled!=0)&&(cmbavGridactions.Visible!=0) ? " onblur=\""+""+";gx.evt.onblur(this,39);\"" : " "),(string)"",(bool)true,(short)1});
            cmbavGridactions.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV58GridActions), 4, 0));
            AssignProp("", false, cmbavGridactions_Internalname, "Values", (string)(cmbavGridactions.ToJavascriptSource()), !bGXsfl_38_Refreshing);
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"right"+"\""+" style=\""+""+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtCMModAno_Internalname,StringUtil.LTrim( StringUtil.NToC( (decimal)(A74CMModAno), 4, 0, ".", "")),StringUtil.LTrim( context.localUtil.Format( (decimal)(A74CMModAno), "ZZZ9")),(string)" inputmode=\"numeric\" pattern=\"[0-9]*\""+"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtCMModAno_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn hidden-xs",(string)"",(short)-1,(short)0,(short)0,(string)"text",(string)"1",(short)0,(string)"px",(short)17,(string)"px",(short)4,(short)0,(short)0,(short)38,(short)1,(short)-1,(short)0,(bool)true,(string)"",(string)"right",(bool)false,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"right"+"\""+" style=\""+""+"\">") ;
            }
            if ( ( cmbCMModMes.ItemCount == 0 ) && isAjaxCallMode( ) )
            {
               GXCCtl = "CMMODMES_" + sGXsfl_38_idx;
               cmbCMModMes.Name = GXCCtl;
               cmbCMModMes.WebTags = "";
               cmbCMModMes.addItem("1", "Enero", 0);
               cmbCMModMes.addItem("2", "Febrero", 0);
               cmbCMModMes.addItem("3", "Marzo", 0);
               cmbCMModMes.addItem("4", "Abril", 0);
               cmbCMModMes.addItem("5", "Mayo", 0);
               cmbCMModMes.addItem("6", "Junio", 0);
               cmbCMModMes.addItem("7", "Julio", 0);
               cmbCMModMes.addItem("8", "Agosto", 0);
               cmbCMModMes.addItem("9", "Setiembre", 0);
               cmbCMModMes.addItem("10", "Octubre", 0);
               cmbCMModMes.addItem("11", "Noviembre", 0);
               cmbCMModMes.addItem("12", "Diciembre", 0);
               if ( cmbCMModMes.ItemCount > 0 )
               {
                  A75CMModMes = (short)(NumberUtil.Val( cmbCMModMes.getValidValue(StringUtil.Trim( StringUtil.Str( (decimal)(A75CMModMes), 2, 0))), "."));
               }
            }
            /* ComboBox */
            GridRow.AddColumnProperties("combobox", 2, isAjaxCallMode( ), new Object[] {(GXCombobox)cmbCMModMes,(string)cmbCMModMes_Internalname,StringUtil.Trim( StringUtil.Str( (decimal)(A75CMModMes), 2, 0)),(short)1,(string)cmbCMModMes_Jsonclick,(short)0,(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"int",(string)"",(short)-1,(short)0,(short)0,(short)0,(short)0,(string)"px",(short)0,(string)"px",(string)"",(string)"Attribute",(string)"WWColumn hidden-xs",(string)"",(string)"",(string)"",(bool)true,(short)1});
            cmbCMModMes.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(A75CMModMes), 2, 0));
            AssignProp("", false, cmbCMModMes_Internalname, "Values", (string)(cmbCMModMes.ToJavascriptSource()), !bGXsfl_38_Refreshing);
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"left"+"\""+" style=\""+""+"\">") ;
            }
            if ( ( cmbCMModCod.ItemCount == 0 ) && isAjaxCallMode( ) )
            {
               GXCCtl = "CMMODCOD_" + sGXsfl_38_idx;
               cmbCMModCod.Name = GXCCtl;
               cmbCMModCod.WebTags = "";
               cmbCMModCod.addItem("ALM", "Almacenes", 0);
               cmbCMModCod.addItem("CLI", "Ventas", 0);
               cmbCMModCod.addItem("PRV", "Compras", 0);
               cmbCMModCod.addItem("TES", "Bancos", 0);
               cmbCMModCod.addItem("CON", "Contabilidad", 0);
               cmbCMModCod.addItem("PRO", "Produccion", 0);
               cmbCMModCod.addItem("PLA", "Planilla", 0);
               cmbCMModCod.addItem("ACT", "Activos Fijos", 0);
               if ( cmbCMModCod.ItemCount > 0 )
               {
                  A73CMModCod = cmbCMModCod.getValidValue(A73CMModCod);
               }
            }
            /* ComboBox */
            GridRow.AddColumnProperties("combobox", 2, isAjaxCallMode( ), new Object[] {(GXCombobox)cmbCMModCod,(string)cmbCMModCod_Internalname,StringUtil.RTrim( A73CMModCod),(short)1,(string)cmbCMModCod_Jsonclick,(short)0,(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"char",(string)"",(short)-1,(short)0,(short)0,(short)0,(short)0,(string)"px",(short)0,(string)"px",(string)"",(string)"Attribute",(string)"WWColumn",(string)"",(string)"",(string)"",(bool)true,(short)1});
            cmbCMModCod.CurrentValue = StringUtil.RTrim( A73CMModCod);
            AssignProp("", false, cmbCMModCod_Internalname, "Values", (string)(cmbCMModCod.ToJavascriptSource()), !bGXsfl_38_Refreshing);
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"right"+"\""+" style=\""+""+"\">") ;
            }
            if ( ( cmbCMModSts.ItemCount == 0 ) && isAjaxCallMode( ) )
            {
               GXCCtl = "CMMODSTS_" + sGXsfl_38_idx;
               cmbCMModSts.Name = GXCCtl;
               cmbCMModSts.WebTags = "";
               cmbCMModSts.addItem("1", "Abierto", 0);
               cmbCMModSts.addItem("2", "Cerrado", 0);
               if ( cmbCMModSts.ItemCount > 0 )
               {
                  A640CMModSts = (short)(NumberUtil.Val( cmbCMModSts.getValidValue(StringUtil.Trim( StringUtil.Str( (decimal)(A640CMModSts), 1, 0))), "."));
               }
            }
            /* ComboBox */
            GridRow.AddColumnProperties("combobox", 2, isAjaxCallMode( ), new Object[] {(GXCombobox)cmbCMModSts,(string)cmbCMModSts_Internalname,StringUtil.Trim( StringUtil.Str( (decimal)(A640CMModSts), 1, 0)),(short)1,(string)cmbCMModSts_Jsonclick,(short)0,(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"int",(string)"",(short)-1,(short)0,(short)0,(short)0,(short)0,(string)"px",(short)0,(string)"px",(string)"",(string)"Attribute",(string)"WWColumn",(string)"",(string)"",(string)"",(bool)true,(short)1});
            cmbCMModSts.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(A640CMModSts), 1, 0));
            AssignProp("", false, cmbCMModSts_Internalname, "Values", (string)(cmbCMModSts.ToJavascriptSource()), !bGXsfl_38_Refreshing);
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"left"+"\""+" style=\""+""+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtCMModUsuC_Internalname,StringUtil.RTrim( A641CMModUsuC),(string)"",(string)"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtCMModUsuC_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn hidden-xs",(string)"",(short)-1,(short)0,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)10,(short)0,(short)0,(short)38,(short)1,(short)-1,(short)-1,(bool)true,(string)"",(string)"left",(bool)true,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"right"+"\""+" style=\""+""+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtCMModFecC_Internalname,context.localUtil.Format(A638CMModFecC, "99/99/99"),context.localUtil.Format( A638CMModFecC, "99/99/99"),(string)"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtCMModFecC_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn hidden-xs",(string)"",(short)-1,(short)0,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)8,(short)0,(short)0,(short)38,(short)1,(short)-1,(short)0,(bool)true,(string)"",(string)"right",(bool)false,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"left"+"\""+" style=\""+""+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtCMModUsuM_Internalname,StringUtil.RTrim( A642CMModUsuM),(string)"",(string)"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtCMModUsuM_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn hidden-xs",(string)"",(short)-1,(short)0,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)10,(short)0,(short)0,(short)38,(short)1,(short)-1,(short)-1,(bool)true,(string)"",(string)"left",(bool)true,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"right"+"\""+" style=\""+""+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtCMModFecM_Internalname,context.localUtil.Format(A639CMModFecM, "99/99/99"),context.localUtil.Format( A639CMModFecM, "99/99/99"),(string)"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtCMModFecM_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn hidden-xs",(string)"",(short)-1,(short)0,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)8,(short)0,(short)0,(short)38,(short)1,(short)-1,(short)0,(bool)true,(string)"",(string)"right",(bool)false,(string)""});
            send_integrity_lvl_hashes0C2( ) ;
            GridContainer.AddRow(GridRow);
            nGXsfl_38_idx = ((subGrid_Islastpage==1)&&(nGXsfl_38_idx+1>subGrid_fnc_Recordsperpage( )) ? 1 : nGXsfl_38_idx+1);
            sGXsfl_38_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_38_idx), 4, 0), 4, "0");
            SubsflControlProps_382( ) ;
         }
         /* End function sendrow_382 */
      }

      protected void init_web_controls( )
      {
         cmbavCmmodmes.Name = "vCMMODMES";
         cmbavCmmodmes.WebTags = "";
         cmbavCmmodmes.addItem("1", "Enero", 0);
         cmbavCmmodmes.addItem("2", "Febrero", 0);
         cmbavCmmodmes.addItem("3", "Marzo", 0);
         cmbavCmmodmes.addItem("4", "Abril", 0);
         cmbavCmmodmes.addItem("5", "Mayo", 0);
         cmbavCmmodmes.addItem("6", "Junio", 0);
         cmbavCmmodmes.addItem("7", "Julio", 0);
         cmbavCmmodmes.addItem("8", "Agosto", 0);
         cmbavCmmodmes.addItem("9", "Setiembre", 0);
         cmbavCmmodmes.addItem("10", "Octubre", 0);
         cmbavCmmodmes.addItem("11", "Noviembre", 0);
         cmbavCmmodmes.addItem("12", "Diciembre", 0);
         if ( cmbavCmmodmes.ItemCount > 0 )
         {
            AV62CMModMes = (short)(NumberUtil.Val( cmbavCmmodmes.getValidValue(StringUtil.Trim( StringUtil.Str( (decimal)(AV62CMModMes), 2, 0))), "."));
            AssignAttri("", false, "AV62CMModMes", StringUtil.LTrimStr( (decimal)(AV62CMModMes), 2, 0));
         }
         GXCCtl = "vGRIDACTIONS_" + sGXsfl_38_idx;
         cmbavGridactions.Name = GXCCtl;
         cmbavGridactions.WebTags = "";
         if ( cmbavGridactions.ItemCount > 0 )
         {
            AV58GridActions = (short)(NumberUtil.Val( cmbavGridactions.getValidValue(StringUtil.Trim( StringUtil.Str( (decimal)(AV58GridActions), 4, 0))), "."));
            AssignAttri("", false, cmbavGridactions_Internalname, StringUtil.LTrimStr( (decimal)(AV58GridActions), 4, 0));
         }
         GXCCtl = "CMMODMES_" + sGXsfl_38_idx;
         cmbCMModMes.Name = GXCCtl;
         cmbCMModMes.WebTags = "";
         cmbCMModMes.addItem("1", "Enero", 0);
         cmbCMModMes.addItem("2", "Febrero", 0);
         cmbCMModMes.addItem("3", "Marzo", 0);
         cmbCMModMes.addItem("4", "Abril", 0);
         cmbCMModMes.addItem("5", "Mayo", 0);
         cmbCMModMes.addItem("6", "Junio", 0);
         cmbCMModMes.addItem("7", "Julio", 0);
         cmbCMModMes.addItem("8", "Agosto", 0);
         cmbCMModMes.addItem("9", "Setiembre", 0);
         cmbCMModMes.addItem("10", "Octubre", 0);
         cmbCMModMes.addItem("11", "Noviembre", 0);
         cmbCMModMes.addItem("12", "Diciembre", 0);
         if ( cmbCMModMes.ItemCount > 0 )
         {
            A75CMModMes = (short)(NumberUtil.Val( cmbCMModMes.getValidValue(StringUtil.Trim( StringUtil.Str( (decimal)(A75CMModMes), 2, 0))), "."));
         }
         GXCCtl = "CMMODCOD_" + sGXsfl_38_idx;
         cmbCMModCod.Name = GXCCtl;
         cmbCMModCod.WebTags = "";
         cmbCMModCod.addItem("ALM", "Almacenes", 0);
         cmbCMModCod.addItem("CLI", "Ventas", 0);
         cmbCMModCod.addItem("PRV", "Compras", 0);
         cmbCMModCod.addItem("TES", "Bancos", 0);
         cmbCMModCod.addItem("CON", "Contabilidad", 0);
         cmbCMModCod.addItem("PRO", "Produccion", 0);
         cmbCMModCod.addItem("PLA", "Planilla", 0);
         cmbCMModCod.addItem("ACT", "Activos Fijos", 0);
         if ( cmbCMModCod.ItemCount > 0 )
         {
            A73CMModCod = cmbCMModCod.getValidValue(A73CMModCod);
         }
         GXCCtl = "CMMODSTS_" + sGXsfl_38_idx;
         cmbCMModSts.Name = GXCCtl;
         cmbCMModSts.WebTags = "";
         cmbCMModSts.addItem("1", "Abierto", 0);
         cmbCMModSts.addItem("2", "Cerrado", 0);
         if ( cmbCMModSts.ItemCount > 0 )
         {
            A640CMModSts = (short)(NumberUtil.Val( cmbCMModSts.getValidValue(StringUtil.Trim( StringUtil.Str( (decimal)(A640CMModSts), 1, 0))), "."));
         }
         /* End function init_web_controls */
      }

      protected void init_default_properties( )
      {
         bttBtninsert_Internalname = "BTNINSERT";
         bttBtnagexport_Internalname = "BTNAGEXPORT";
         divTableactions_Internalname = "TABLEACTIONS";
         edtavCmmodano_Internalname = "vCMMODANO";
         cmbavCmmodmes_Internalname = "vCMMODMES";
         divTableheadercontent_Internalname = "TABLEHEADERCONTENT";
         divTableheader_Internalname = "TABLEHEADER";
         Dvpanel_tableheader_Internalname = "DVPANEL_TABLEHEADER";
         cmbavGridactions_Internalname = "vGRIDACTIONS";
         edtCMModAno_Internalname = "CMMODANO";
         cmbCMModMes_Internalname = "CMMODMES";
         cmbCMModCod_Internalname = "CMMODCOD";
         cmbCMModSts_Internalname = "CMMODSTS";
         edtCMModUsuC_Internalname = "CMMODUSUC";
         edtCMModFecC_Internalname = "CMMODFECC";
         edtCMModUsuM_Internalname = "CMMODUSUM";
         edtCMModFecM_Internalname = "CMMODFECM";
         Gridpaginationbar_Internalname = "GRIDPAGINATIONBAR";
         divGridtablewithpaginationbar_Internalname = "GRIDTABLEWITHPAGINATIONBAR";
         divTablemain_Internalname = "TABLEMAIN";
         Ddo_agexport_Internalname = "DDO_AGEXPORT";
         Ddo_grid_Internalname = "DDO_GRID";
         Innewwindow1_Internalname = "INNEWWINDOW1";
         Grid_empowerer_Internalname = "GRID_EMPOWERER";
         edtavDdo_cmmodfeccauxdatetext_Internalname = "vDDO_CMMODFECCAUXDATETEXT";
         Tfcmmodfecc_rangepicker_Internalname = "TFCMMODFECC_RANGEPICKER";
         divDdo_cmmodfeccauxdates_Internalname = "DDO_CMMODFECCAUXDATES";
         edtavDdo_cmmodfecmauxdatetext_Internalname = "vDDO_CMMODFECMAUXDATETEXT";
         Tfcmmodfecm_rangepicker_Internalname = "TFCMMODFECM_RANGEPICKER";
         divDdo_cmmodfecmauxdates_Internalname = "DDO_CMMODFECMAUXDATES";
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
         edtCMModFecM_Jsonclick = "";
         edtCMModUsuM_Jsonclick = "";
         edtCMModFecC_Jsonclick = "";
         edtCMModUsuC_Jsonclick = "";
         cmbCMModSts_Jsonclick = "";
         cmbCMModCod_Jsonclick = "";
         cmbCMModMes_Jsonclick = "";
         edtCMModAno_Jsonclick = "";
         cmbavGridactions_Jsonclick = "";
         cmbavGridactions.Visible = -1;
         cmbavGridactions.Enabled = 1;
         edtavDdo_cmmodfecmauxdatetext_Jsonclick = "";
         edtavDdo_cmmodfeccauxdatetext_Jsonclick = "";
         subGrid_Allowcollapsing = 0;
         subGrid_Allowselection = 0;
         subGrid_Sortable = 0;
         subGrid_Header = "";
         subGrid_Class = "GridWithPaginationBar WorkWith";
         subGrid_Backcolorstyle = 0;
         cmbavCmmodmes_Jsonclick = "";
         cmbavCmmodmes.Enabled = 1;
         edtavCmmodano_Jsonclick = "";
         edtavCmmodano_Enabled = 1;
         Grid_empowerer_Hastitlesettings = Convert.ToBoolean( -1);
         Innewwindow1_Target = "";
         Innewwindow1_Height = "50";
         Innewwindow1_Width = "50";
         Ddo_grid_Datalistproc = "Seguridad.CierreModulosWWGetFilterData";
         Ddo_grid_Datalistfixedvalues = "|1:Enero,2:Febrero,3:Marzo,4:Abril,5:Mayo,6:Junio,7:Julio,8:Agosto,9:Setiembre,10:Octubre,11:Noviembre,12:Diciembre|ALM:Almacenes,CLI:Ventas,PRV:Compras,TES:Bancos,CON:Contabilidad,PRO:Produccion,PLA:Planilla,ACT:Activos Fijos|1:Abierto,2:Cerrado||||";
         Ddo_grid_Allowmultipleselection = "|T|T|T||||";
         Ddo_grid_Datalisttype = "|FixedValues|FixedValues|FixedValues|Dynamic||Dynamic|";
         Ddo_grid_Includedatalist = "|T|T|T|T||T|";
         Ddo_grid_Filterisrange = "T|||||P||P";
         Ddo_grid_Filtertype = "Numeric||||Character|Date|Character|Date";
         Ddo_grid_Includefilter = "T||||T|T|T|T";
         Ddo_grid_Includesortasc = "T";
         Ddo_grid_Columnssortvalues = "1|2|3|4|5|6|7|8";
         Ddo_grid_Columnids = "1:CMModAno|2:CMModMes|3:CMModCod|4:CMModSts|5:CMModUsuC|6:CMModFecC|7:CMModUsuM|8:CMModFecM";
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
         Form.Caption = " Cierre Modulos";
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
         setEventMetadata("REFRESH","{handler:'Refresh',iparms:[{av:'GRID_nFirstRecordOnPage'},{av:'GRID_nEOF'},{av:'subGrid_Rows',ctrl:'GRID',prop:'Rows'},{av:'AV61CMModAno',fld:'vCMMODANO',pic:'ZZZ9'},{av:'cmbavCmmodmes'},{av:'AV62CMModMes',fld:'vCMMODMES',pic:'Z9'},{av:'AV71Pgmname',fld:'vPGMNAME',pic:'',hsh:true},{av:'AV33TFCMModAno',fld:'vTFCMMODANO',pic:'ZZZ9'},{av:'AV34TFCMModAno_To',fld:'vTFCMMODANO_TO',pic:'ZZZ9'},{av:'AV64TFCMModMes_Sels',fld:'vTFCMMODMES_SELS',pic:''},{av:'AV66TFCMModCod_Sels',fld:'vTFCMMODCOD_SELS',pic:''},{av:'AV68TFCMModSts_Sels',fld:'vTFCMMODSTS_SELS',pic:''},{av:'AV39TFCMModUsuC',fld:'vTFCMMODUSUC',pic:''},{av:'AV40TFCMModUsuC_Sel',fld:'vTFCMMODUSUC_SEL',pic:''},{av:'AV41TFCMModFecC',fld:'vTFCMMODFECC',pic:''},{av:'AV42TFCMModFecC_To',fld:'vTFCMMODFECC_TO',pic:''},{av:'AV46TFCMModUsuM',fld:'vTFCMMODUSUM',pic:''},{av:'AV47TFCMModUsuM_Sel',fld:'vTFCMMODUSUM_SEL',pic:''},{av:'AV48TFCMModFecM',fld:'vTFCMMODFECM',pic:''},{av:'AV49TFCMModFecM_To',fld:'vTFCMMODFECM_TO',pic:''},{av:'AV13OrderedBy',fld:'vORDEREDBY',pic:'ZZZ9'},{av:'AV14OrderedDsc',fld:'vORDEREDDSC',pic:''}]");
         setEventMetadata("REFRESH",",oparms:[{av:'AV55GridCurrentPage',fld:'vGRIDCURRENTPAGE',pic:'ZZZZZZZZZ9'},{av:'AV56GridPageCount',fld:'vGRIDPAGECOUNT',pic:'ZZZZZZZZZ9'},{av:'AV57GridAppliedFilters',fld:'vGRIDAPPLIEDFILTERS',pic:''}]}");
         setEventMetadata("GRIDPAGINATIONBAR.CHANGEPAGE","{handler:'E110C2',iparms:[{av:'GRID_nFirstRecordOnPage'},{av:'GRID_nEOF'},{av:'subGrid_Rows',ctrl:'GRID',prop:'Rows'},{av:'AV61CMModAno',fld:'vCMMODANO',pic:'ZZZ9'},{av:'cmbavCmmodmes'},{av:'AV62CMModMes',fld:'vCMMODMES',pic:'Z9'},{av:'AV71Pgmname',fld:'vPGMNAME',pic:'',hsh:true},{av:'AV33TFCMModAno',fld:'vTFCMMODANO',pic:'ZZZ9'},{av:'AV34TFCMModAno_To',fld:'vTFCMMODANO_TO',pic:'ZZZ9'},{av:'AV64TFCMModMes_Sels',fld:'vTFCMMODMES_SELS',pic:''},{av:'AV66TFCMModCod_Sels',fld:'vTFCMMODCOD_SELS',pic:''},{av:'AV68TFCMModSts_Sels',fld:'vTFCMMODSTS_SELS',pic:''},{av:'AV39TFCMModUsuC',fld:'vTFCMMODUSUC',pic:''},{av:'AV40TFCMModUsuC_Sel',fld:'vTFCMMODUSUC_SEL',pic:''},{av:'AV41TFCMModFecC',fld:'vTFCMMODFECC',pic:''},{av:'AV42TFCMModFecC_To',fld:'vTFCMMODFECC_TO',pic:''},{av:'AV46TFCMModUsuM',fld:'vTFCMMODUSUM',pic:''},{av:'AV47TFCMModUsuM_Sel',fld:'vTFCMMODUSUM_SEL',pic:''},{av:'AV48TFCMModFecM',fld:'vTFCMMODFECM',pic:''},{av:'AV49TFCMModFecM_To',fld:'vTFCMMODFECM_TO',pic:''},{av:'AV13OrderedBy',fld:'vORDEREDBY',pic:'ZZZ9'},{av:'AV14OrderedDsc',fld:'vORDEREDDSC',pic:''},{av:'Gridpaginationbar_Selectedpage',ctrl:'GRIDPAGINATIONBAR',prop:'SelectedPage'}]");
         setEventMetadata("GRIDPAGINATIONBAR.CHANGEPAGE",",oparms:[]}");
         setEventMetadata("GRIDPAGINATIONBAR.CHANGEROWSPERPAGE","{handler:'E120C2',iparms:[{av:'GRID_nFirstRecordOnPage'},{av:'GRID_nEOF'},{av:'subGrid_Rows',ctrl:'GRID',prop:'Rows'},{av:'AV61CMModAno',fld:'vCMMODANO',pic:'ZZZ9'},{av:'cmbavCmmodmes'},{av:'AV62CMModMes',fld:'vCMMODMES',pic:'Z9'},{av:'AV71Pgmname',fld:'vPGMNAME',pic:'',hsh:true},{av:'AV33TFCMModAno',fld:'vTFCMMODANO',pic:'ZZZ9'},{av:'AV34TFCMModAno_To',fld:'vTFCMMODANO_TO',pic:'ZZZ9'},{av:'AV64TFCMModMes_Sels',fld:'vTFCMMODMES_SELS',pic:''},{av:'AV66TFCMModCod_Sels',fld:'vTFCMMODCOD_SELS',pic:''},{av:'AV68TFCMModSts_Sels',fld:'vTFCMMODSTS_SELS',pic:''},{av:'AV39TFCMModUsuC',fld:'vTFCMMODUSUC',pic:''},{av:'AV40TFCMModUsuC_Sel',fld:'vTFCMMODUSUC_SEL',pic:''},{av:'AV41TFCMModFecC',fld:'vTFCMMODFECC',pic:''},{av:'AV42TFCMModFecC_To',fld:'vTFCMMODFECC_TO',pic:''},{av:'AV46TFCMModUsuM',fld:'vTFCMMODUSUM',pic:''},{av:'AV47TFCMModUsuM_Sel',fld:'vTFCMMODUSUM_SEL',pic:''},{av:'AV48TFCMModFecM',fld:'vTFCMMODFECM',pic:''},{av:'AV49TFCMModFecM_To',fld:'vTFCMMODFECM_TO',pic:''},{av:'AV13OrderedBy',fld:'vORDEREDBY',pic:'ZZZ9'},{av:'AV14OrderedDsc',fld:'vORDEREDDSC',pic:''},{av:'Gridpaginationbar_Rowsperpageselectedvalue',ctrl:'GRIDPAGINATIONBAR',prop:'RowsPerPageSelectedValue'}]");
         setEventMetadata("GRIDPAGINATIONBAR.CHANGEROWSPERPAGE",",oparms:[{av:'subGrid_Rows',ctrl:'GRID',prop:'Rows'}]}");
         setEventMetadata("DDO_GRID.ONOPTIONCLICKED","{handler:'E140C2',iparms:[{av:'GRID_nFirstRecordOnPage'},{av:'GRID_nEOF'},{av:'subGrid_Rows',ctrl:'GRID',prop:'Rows'},{av:'AV61CMModAno',fld:'vCMMODANO',pic:'ZZZ9'},{av:'cmbavCmmodmes'},{av:'AV62CMModMes',fld:'vCMMODMES',pic:'Z9'},{av:'AV71Pgmname',fld:'vPGMNAME',pic:'',hsh:true},{av:'AV33TFCMModAno',fld:'vTFCMMODANO',pic:'ZZZ9'},{av:'AV34TFCMModAno_To',fld:'vTFCMMODANO_TO',pic:'ZZZ9'},{av:'AV64TFCMModMes_Sels',fld:'vTFCMMODMES_SELS',pic:''},{av:'AV66TFCMModCod_Sels',fld:'vTFCMMODCOD_SELS',pic:''},{av:'AV68TFCMModSts_Sels',fld:'vTFCMMODSTS_SELS',pic:''},{av:'AV39TFCMModUsuC',fld:'vTFCMMODUSUC',pic:''},{av:'AV40TFCMModUsuC_Sel',fld:'vTFCMMODUSUC_SEL',pic:''},{av:'AV41TFCMModFecC',fld:'vTFCMMODFECC',pic:''},{av:'AV42TFCMModFecC_To',fld:'vTFCMMODFECC_TO',pic:''},{av:'AV46TFCMModUsuM',fld:'vTFCMMODUSUM',pic:''},{av:'AV47TFCMModUsuM_Sel',fld:'vTFCMMODUSUM_SEL',pic:''},{av:'AV48TFCMModFecM',fld:'vTFCMMODFECM',pic:''},{av:'AV49TFCMModFecM_To',fld:'vTFCMMODFECM_TO',pic:''},{av:'AV13OrderedBy',fld:'vORDEREDBY',pic:'ZZZ9'},{av:'AV14OrderedDsc',fld:'vORDEREDDSC',pic:''},{av:'Ddo_grid_Activeeventkey',ctrl:'DDO_GRID',prop:'ActiveEventKey'},{av:'Ddo_grid_Selectedvalue_get',ctrl:'DDO_GRID',prop:'SelectedValue_get'},{av:'Ddo_grid_Filteredtextto_get',ctrl:'DDO_GRID',prop:'FilteredTextTo_get'},{av:'Ddo_grid_Filteredtext_get',ctrl:'DDO_GRID',prop:'FilteredText_get'},{av:'Ddo_grid_Selectedcolumn',ctrl:'DDO_GRID',prop:'SelectedColumn'}]");
         setEventMetadata("DDO_GRID.ONOPTIONCLICKED",",oparms:[{av:'AV13OrderedBy',fld:'vORDEREDBY',pic:'ZZZ9'},{av:'AV14OrderedDsc',fld:'vORDEREDDSC',pic:''},{av:'AV48TFCMModFecM',fld:'vTFCMMODFECM',pic:''},{av:'AV49TFCMModFecM_To',fld:'vTFCMMODFECM_TO',pic:''},{av:'AV46TFCMModUsuM',fld:'vTFCMMODUSUM',pic:''},{av:'AV47TFCMModUsuM_Sel',fld:'vTFCMMODUSUM_SEL',pic:''},{av:'AV41TFCMModFecC',fld:'vTFCMMODFECC',pic:''},{av:'AV42TFCMModFecC_To',fld:'vTFCMMODFECC_TO',pic:''},{av:'AV39TFCMModUsuC',fld:'vTFCMMODUSUC',pic:''},{av:'AV40TFCMModUsuC_Sel',fld:'vTFCMMODUSUC_SEL',pic:''},{av:'AV67TFCMModSts_SelsJson',fld:'vTFCMMODSTS_SELSJSON',pic:''},{av:'AV68TFCMModSts_Sels',fld:'vTFCMMODSTS_SELS',pic:''},{av:'AV65TFCMModCod_SelsJson',fld:'vTFCMMODCOD_SELSJSON',pic:''},{av:'AV66TFCMModCod_Sels',fld:'vTFCMMODCOD_SELS',pic:''},{av:'AV63TFCMModMes_SelsJson',fld:'vTFCMMODMES_SELSJSON',pic:''},{av:'AV64TFCMModMes_Sels',fld:'vTFCMMODMES_SELS',pic:''},{av:'AV33TFCMModAno',fld:'vTFCMMODANO',pic:'ZZZ9'},{av:'AV34TFCMModAno_To',fld:'vTFCMMODANO_TO',pic:'ZZZ9'},{av:'Ddo_grid_Sortedstatus',ctrl:'DDO_GRID',prop:'SortedStatus'}]}");
         setEventMetadata("GRID.LOAD","{handler:'E180C2',iparms:[]");
         setEventMetadata("GRID.LOAD",",oparms:[{av:'cmbavGridactions'},{av:'AV58GridActions',fld:'vGRIDACTIONS',pic:'ZZZ9'}]}");
         setEventMetadata("VGRIDACTIONS.CLICK","{handler:'E190C2',iparms:[{av:'cmbavGridactions'},{av:'AV58GridActions',fld:'vGRIDACTIONS',pic:'ZZZ9'},{av:'cmbCMModCod'},{av:'A73CMModCod',fld:'CMMODCOD',pic:'',hsh:true},{av:'A74CMModAno',fld:'CMMODANO',pic:'ZZZ9',hsh:true},{av:'cmbCMModMes'},{av:'A75CMModMes',fld:'CMMODMES',pic:'Z9',hsh:true}]");
         setEventMetadata("VGRIDACTIONS.CLICK",",oparms:[{av:'cmbavGridactions'},{av:'AV58GridActions',fld:'vGRIDACTIONS',pic:'ZZZ9'}]}");
         setEventMetadata("'DOINSERT'","{handler:'E150C2',iparms:[{av:'cmbCMModCod'},{av:'A73CMModCod',fld:'CMMODCOD',pic:'',hsh:true},{av:'A74CMModAno',fld:'CMMODANO',pic:'ZZZ9',hsh:true},{av:'cmbCMModMes'},{av:'A75CMModMes',fld:'CMMODMES',pic:'Z9',hsh:true}]");
         setEventMetadata("'DOINSERT'",",oparms:[]}");
         setEventMetadata("DDO_AGEXPORT.ONOPTIONCLICKED","{handler:'E130C2',iparms:[{av:'Ddo_agexport_Activeeventkey',ctrl:'DDO_AGEXPORT',prop:'ActiveEventKey'},{av:'AV71Pgmname',fld:'vPGMNAME',pic:'',hsh:true},{av:'AV68TFCMModSts_Sels',fld:'vTFCMMODSTS_SELS',pic:''},{av:'AV64TFCMModMes_Sels',fld:'vTFCMMODMES_SELS',pic:''},{av:'AV63TFCMModMes_SelsJson',fld:'vTFCMMODMES_SELSJSON',pic:''},{av:'AV66TFCMModCod_Sels',fld:'vTFCMMODCOD_SELS',pic:''},{av:'AV65TFCMModCod_SelsJson',fld:'vTFCMMODCOD_SELSJSON',pic:''},{av:'AV67TFCMModSts_SelsJson',fld:'vTFCMMODSTS_SELSJSON',pic:''},{av:'AV40TFCMModUsuC_Sel',fld:'vTFCMMODUSUC_SEL',pic:''},{av:'AV47TFCMModUsuM_Sel',fld:'vTFCMMODUSUM_SEL',pic:''},{av:'AV33TFCMModAno',fld:'vTFCMMODANO',pic:'ZZZ9'},{av:'AV39TFCMModUsuC',fld:'vTFCMMODUSUC',pic:''},{av:'AV41TFCMModFecC',fld:'vTFCMMODFECC',pic:''},{av:'AV46TFCMModUsuM',fld:'vTFCMMODUSUM',pic:''},{av:'AV48TFCMModFecM',fld:'vTFCMMODFECM',pic:''},{av:'AV34TFCMModAno_To',fld:'vTFCMMODANO_TO',pic:'ZZZ9'},{av:'AV42TFCMModFecC_To',fld:'vTFCMMODFECC_TO',pic:''},{av:'AV49TFCMModFecM_To',fld:'vTFCMMODFECM_TO',pic:''},{av:'AV13OrderedBy',fld:'vORDEREDBY',pic:'ZZZ9'},{av:'AV14OrderedDsc',fld:'vORDEREDDSC',pic:''}]");
         setEventMetadata("DDO_AGEXPORT.ONOPTIONCLICKED",",oparms:[{av:'Innewwindow1_Target',ctrl:'INNEWWINDOW1',prop:'Target'},{av:'Innewwindow1_Height',ctrl:'INNEWWINDOW1',prop:'Height'},{av:'Innewwindow1_Width',ctrl:'INNEWWINDOW1',prop:'Width'},{av:'AV13OrderedBy',fld:'vORDEREDBY',pic:'ZZZ9'},{av:'AV14OrderedDsc',fld:'vORDEREDDSC',pic:''},{av:'AV48TFCMModFecM',fld:'vTFCMMODFECM',pic:''},{av:'AV49TFCMModFecM_To',fld:'vTFCMMODFECM_TO',pic:''},{av:'AV47TFCMModUsuM_Sel',fld:'vTFCMMODUSUM_SEL',pic:''},{av:'AV46TFCMModUsuM',fld:'vTFCMMODUSUM',pic:''},{av:'AV41TFCMModFecC',fld:'vTFCMMODFECC',pic:''},{av:'AV42TFCMModFecC_To',fld:'vTFCMMODFECC_TO',pic:''},{av:'AV40TFCMModUsuC_Sel',fld:'vTFCMMODUSUC_SEL',pic:''},{av:'AV39TFCMModUsuC',fld:'vTFCMMODUSUC',pic:''},{av:'AV67TFCMModSts_SelsJson',fld:'vTFCMMODSTS_SELSJSON',pic:''},{av:'AV68TFCMModSts_Sels',fld:'vTFCMMODSTS_SELS',pic:''},{av:'AV65TFCMModCod_SelsJson',fld:'vTFCMMODCOD_SELSJSON',pic:''},{av:'AV66TFCMModCod_Sels',fld:'vTFCMMODCOD_SELS',pic:''},{av:'AV63TFCMModMes_SelsJson',fld:'vTFCMMODMES_SELSJSON',pic:''},{av:'AV64TFCMModMes_Sels',fld:'vTFCMMODMES_SELS',pic:''},{av:'AV33TFCMModAno',fld:'vTFCMMODANO',pic:'ZZZ9'},{av:'AV34TFCMModAno_To',fld:'vTFCMMODANO_TO',pic:'ZZZ9'},{av:'cmbavCmmodmes'},{av:'AV62CMModMes',fld:'vCMMODMES',pic:'Z9'},{av:'AV61CMModAno',fld:'vCMMODANO',pic:'ZZZ9'},{av:'Ddo_grid_Selectedvalue_set',ctrl:'DDO_GRID',prop:'SelectedValue_set'},{av:'Ddo_grid_Filteredtext_set',ctrl:'DDO_GRID',prop:'FilteredText_set'},{av:'Ddo_grid_Filteredtextto_set',ctrl:'DDO_GRID',prop:'FilteredTextTo_set'},{av:'subGrid_Rows',ctrl:'GRID',prop:'Rows'},{av:'GRID_nFirstRecordOnPage'},{av:'GRID_nEOF'},{av:'AV71Pgmname',fld:'vPGMNAME',pic:'',hsh:true},{av:'Ddo_grid_Sortedstatus',ctrl:'DDO_GRID',prop:'SortedStatus'}]}");
         setEventMetadata("NULL","{handler:'Valid_Cmmodfecm',iparms:[]");
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
         AV71Pgmname = "";
         AV64TFCMModMes_Sels = new GxSimpleCollection<short>();
         AV66TFCMModCod_Sels = new GxSimpleCollection<string>();
         AV68TFCMModSts_Sels = new GxSimpleCollection<short>();
         AV39TFCMModUsuC = "";
         AV40TFCMModUsuC_Sel = "";
         AV41TFCMModFecC = DateTime.MinValue;
         AV42TFCMModFecC_To = DateTime.MinValue;
         AV46TFCMModUsuM = "";
         AV47TFCMModUsuM_Sel = "";
         AV48TFCMModFecM = DateTime.MinValue;
         AV49TFCMModFecM_To = DateTime.MinValue;
         sDynURL = "";
         FormProcess = "";
         bodyStyle = "";
         GXKey = "";
         AV57GridAppliedFilters = "";
         AV59AGExportData = new GXBaseCollection<GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTDropDownOptionsData_Item>( context, "Item", "");
         AV53DDO_TitleSettingsIcons = new GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTDropDownOptionsTitleSettingsIcons(context);
         AV44DDO_CMModFecCAuxDateTo = DateTime.MinValue;
         AV51DDO_CMModFecMAuxDateTo = DateTime.MinValue;
         AV63TFCMModMes_SelsJson = "";
         AV65TFCMModCod_SelsJson = "";
         AV67TFCMModSts_SelsJson = "";
         AV43DDO_CMModFecCAuxDate = DateTime.MinValue;
         AV50DDO_CMModFecMAuxDate = DateTime.MinValue;
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
         A73CMModCod = "";
         A641CMModUsuC = "";
         A638CMModFecC = DateTime.MinValue;
         A642CMModUsuM = "";
         A639CMModFecM = DateTime.MinValue;
         ucGridpaginationbar = new GXUserControl();
         ucDdo_agexport = new GXUserControl();
         ucDdo_grid = new GXUserControl();
         ucInnewwindow1 = new GXUserControl();
         ucGrid_empowerer = new GXUserControl();
         AV45DDO_CMModFecCAuxDateText = "";
         ucTfcmmodfecc_rangepicker = new GXUserControl();
         AV52DDO_CMModFecMAuxDateText = "";
         ucTfcmmodfecm_rangepicker = new GXUserControl();
         sEvt = "";
         EvtGridId = "";
         EvtRowId = "";
         sEvtType = "";
         AV76Seguridad_cierremoduloswwds_5_tfcmmodmes_sels = new GxSimpleCollection<short>();
         AV77Seguridad_cierremoduloswwds_6_tfcmmodcod_sels = new GxSimpleCollection<string>();
         AV78Seguridad_cierremoduloswwds_7_tfcmmodsts_sels = new GxSimpleCollection<short>();
         scmdbuf = "";
         lV79Seguridad_cierremoduloswwds_8_tfcmmodusuc = "";
         lV83Seguridad_cierremoduloswwds_12_tfcmmodusum = "";
         AV80Seguridad_cierremoduloswwds_9_tfcmmodusuc_sel = "";
         AV79Seguridad_cierremoduloswwds_8_tfcmmodusuc = "";
         AV81Seguridad_cierremoduloswwds_10_tfcmmodfecc = DateTime.MinValue;
         AV82Seguridad_cierremoduloswwds_11_tfcmmodfecc_to = DateTime.MinValue;
         AV84Seguridad_cierremoduloswwds_13_tfcmmodusum_sel = "";
         AV83Seguridad_cierremoduloswwds_12_tfcmmodusum = "";
         AV85Seguridad_cierremoduloswwds_14_tfcmmodfecm = DateTime.MinValue;
         AV86Seguridad_cierremoduloswwds_15_tfcmmodfecm_to = DateTime.MinValue;
         H000C2_A639CMModFecM = new DateTime[] {DateTime.MinValue} ;
         H000C2_A642CMModUsuM = new string[] {""} ;
         H000C2_A638CMModFecC = new DateTime[] {DateTime.MinValue} ;
         H000C2_A641CMModUsuC = new string[] {""} ;
         H000C2_A640CMModSts = new short[1] ;
         H000C2_A73CMModCod = new string[] {""} ;
         H000C2_A75CMModMes = new short[1] ;
         H000C2_A74CMModAno = new short[1] ;
         H000C3_AGRID_nRecordCount = new long[1] ;
         AV60AGExportDataItem = new GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTDropDownOptionsData_Item(context);
         GXt_SdtDVB_SDTDropDownOptionsTitleSettingsIcons1 = new GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTDropDownOptionsTitleSettingsIcons(context);
         AV6WWPContext = new GeneXus.Programs.wwpbaseobjects.SdtWWPContext(context);
         GridRow = new GXWebRow();
         GXEncryptionTmp = "";
         AV30Session = context.GetSession();
         AV10GridState = new GeneXus.Programs.wwpbaseobjects.SdtWWPGridState(context);
         AV11GridStateFilterValue = new GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue(context);
         GXt_char2 = "";
         GXt_char4 = "";
         GXt_char3 = "";
         AV8TrnContext = new GeneXus.Programs.wwpbaseobjects.SdtWWPTransactionContext(context);
         AV7HTTPRequest = new GxHttpRequest( context);
         AV28ExcelFilename = "";
         AV29ErrorMessage = "";
         BackMsgLst = new msglist();
         LclMsgLst = new msglist();
         GXCCtl = "";
         ROClassString = "";
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.seguridad.cierremodulosww__default(),
            new Object[][] {
                new Object[] {
               H000C2_A639CMModFecM, H000C2_A642CMModUsuM, H000C2_A638CMModFecC, H000C2_A641CMModUsuC, H000C2_A640CMModSts, H000C2_A73CMModCod, H000C2_A75CMModMes, H000C2_A74CMModAno
               }
               , new Object[] {
               H000C3_AGRID_nRecordCount
               }
            }
         );
         AV71Pgmname = "Seguridad.CierreModulosWW";
         /* GeneXus formulas. */
         AV71Pgmname = "Seguridad.CierreModulosWW";
         context.Gx_err = 0;
      }

      private short GRID_nEOF ;
      private short nGotPars ;
      private short GxWebError ;
      private short AV61CMModAno ;
      private short AV62CMModMes ;
      private short AV33TFCMModAno ;
      private short AV34TFCMModAno_To ;
      private short AV13OrderedBy ;
      private short initialized ;
      private short gxajaxcallmode ;
      private short wbEnd ;
      private short wbStart ;
      private short subGrid_Backcolorstyle ;
      private short subGrid_Titlebackstyle ;
      private short subGrid_Sortable ;
      private short AV58GridActions ;
      private short A74CMModAno ;
      private short A75CMModMes ;
      private short A640CMModSts ;
      private short subGrid_Allowselection ;
      private short subGrid_Allowhovering ;
      private short subGrid_Allowcollapsing ;
      private short subGrid_Collapsed ;
      private short nDonePA ;
      private short AV72Seguridad_cierremoduloswwds_1_cmmodano ;
      private short AV73Seguridad_cierremoduloswwds_2_cmmodmes ;
      private short AV74Seguridad_cierremoduloswwds_3_tfcmmodano ;
      private short AV75Seguridad_cierremoduloswwds_4_tfcmmodano_to ;
      private short nGXWrapped ;
      private short subGrid_Backstyle ;
      private int subGrid_Rows ;
      private int Gridpaginationbar_Rowsperpageselectedvalue ;
      private int nRC_GXsfl_38 ;
      private int nGXsfl_38_idx=1 ;
      private int Gridpaginationbar_Pagestoshow ;
      private int edtavCmmodano_Enabled ;
      private int subGrid_Titlebackcolor ;
      private int subGrid_Allbackcolor ;
      private int subGrid_Selectedindex ;
      private int subGrid_Selectioncolor ;
      private int subGrid_Hoveringcolor ;
      private int subGrid_Islastpage ;
      private int GXPagingFrom2 ;
      private int GXPagingTo2 ;
      private int AV76Seguridad_cierremoduloswwds_5_tfcmmodmes_sels_Count ;
      private int AV77Seguridad_cierremoduloswwds_6_tfcmmodcod_sels_Count ;
      private int AV78Seguridad_cierremoduloswwds_7_tfcmmodsts_sels_Count ;
      private int AV54PageToGo ;
      private int AV87GXV1 ;
      private int idxLst ;
      private int subGrid_Backcolor ;
      private long GRID_nFirstRecordOnPage ;
      private long AV55GridCurrentPage ;
      private long AV56GridPageCount ;
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
      private string sGXsfl_38_idx="0001" ;
      private string AV71Pgmname ;
      private string AV39TFCMModUsuC ;
      private string AV40TFCMModUsuC_Sel ;
      private string AV46TFCMModUsuM ;
      private string AV47TFCMModUsuM_Sel ;
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
      private string edtavCmmodano_Internalname ;
      private string edtavCmmodano_Jsonclick ;
      private string cmbavCmmodmes_Internalname ;
      private string cmbavCmmodmes_Jsonclick ;
      private string divGridtablewithpaginationbar_Internalname ;
      private string sStyleString ;
      private string subGrid_Internalname ;
      private string subGrid_Class ;
      private string subGrid_Linesclass ;
      private string subGrid_Header ;
      private string A73CMModCod ;
      private string A641CMModUsuC ;
      private string A642CMModUsuM ;
      private string Gridpaginationbar_Internalname ;
      private string divHtml_bottomauxiliarcontrols_Internalname ;
      private string Ddo_agexport_Internalname ;
      private string Ddo_grid_Internalname ;
      private string Innewwindow1_Internalname ;
      private string Grid_empowerer_Internalname ;
      private string divDdo_cmmodfeccauxdates_Internalname ;
      private string edtavDdo_cmmodfeccauxdatetext_Internalname ;
      private string edtavDdo_cmmodfeccauxdatetext_Jsonclick ;
      private string Tfcmmodfecc_rangepicker_Internalname ;
      private string divDdo_cmmodfecmauxdates_Internalname ;
      private string edtavDdo_cmmodfecmauxdatetext_Internalname ;
      private string edtavDdo_cmmodfecmauxdatetext_Jsonclick ;
      private string Tfcmmodfecm_rangepicker_Internalname ;
      private string sEvt ;
      private string EvtGridId ;
      private string EvtRowId ;
      private string sEvtType ;
      private string cmbavGridactions_Internalname ;
      private string edtCMModAno_Internalname ;
      private string cmbCMModMes_Internalname ;
      private string cmbCMModCod_Internalname ;
      private string cmbCMModSts_Internalname ;
      private string edtCMModUsuC_Internalname ;
      private string edtCMModFecC_Internalname ;
      private string edtCMModUsuM_Internalname ;
      private string edtCMModFecM_Internalname ;
      private string scmdbuf ;
      private string lV79Seguridad_cierremoduloswwds_8_tfcmmodusuc ;
      private string lV83Seguridad_cierremoduloswwds_12_tfcmmodusum ;
      private string AV80Seguridad_cierremoduloswwds_9_tfcmmodusuc_sel ;
      private string AV79Seguridad_cierremoduloswwds_8_tfcmmodusuc ;
      private string AV84Seguridad_cierremoduloswwds_13_tfcmmodusum_sel ;
      private string AV83Seguridad_cierremoduloswwds_12_tfcmmodusum ;
      private string GXEncryptionTmp ;
      private string GXt_char2 ;
      private string GXt_char4 ;
      private string GXt_char3 ;
      private string sGXsfl_38_fel_idx="0001" ;
      private string GXCCtl ;
      private string cmbavGridactions_Jsonclick ;
      private string ROClassString ;
      private string edtCMModAno_Jsonclick ;
      private string cmbCMModMes_Jsonclick ;
      private string cmbCMModCod_Jsonclick ;
      private string cmbCMModSts_Jsonclick ;
      private string edtCMModUsuC_Jsonclick ;
      private string edtCMModFecC_Jsonclick ;
      private string edtCMModUsuM_Jsonclick ;
      private string edtCMModFecM_Jsonclick ;
      private DateTime AV41TFCMModFecC ;
      private DateTime AV42TFCMModFecC_To ;
      private DateTime AV48TFCMModFecM ;
      private DateTime AV49TFCMModFecM_To ;
      private DateTime AV44DDO_CMModFecCAuxDateTo ;
      private DateTime AV51DDO_CMModFecMAuxDateTo ;
      private DateTime AV43DDO_CMModFecCAuxDate ;
      private DateTime AV50DDO_CMModFecMAuxDate ;
      private DateTime A638CMModFecC ;
      private DateTime A639CMModFecM ;
      private DateTime AV81Seguridad_cierremoduloswwds_10_tfcmmodfecc ;
      private DateTime AV82Seguridad_cierremoduloswwds_11_tfcmmodfecc_to ;
      private DateTime AV85Seguridad_cierremoduloswwds_14_tfcmmodfecm ;
      private DateTime AV86Seguridad_cierremoduloswwds_15_tfcmmodfecm_to ;
      private bool entryPointCalled ;
      private bool toggleJsOutput ;
      private bool AV14OrderedDsc ;
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
      private bool bGXsfl_38_Refreshing=false ;
      private bool gxdyncontrolsrefreshing ;
      private bool returnInSub ;
      private bool gx_refresh_fired ;
      private string AV63TFCMModMes_SelsJson ;
      private string AV65TFCMModCod_SelsJson ;
      private string AV67TFCMModSts_SelsJson ;
      private string AV57GridAppliedFilters ;
      private string AV45DDO_CMModFecCAuxDateText ;
      private string AV52DDO_CMModFecMAuxDateText ;
      private string AV28ExcelFilename ;
      private string AV29ErrorMessage ;
      private GxSimpleCollection<short> AV64TFCMModMes_Sels ;
      private GxSimpleCollection<short> AV68TFCMModSts_Sels ;
      private GxSimpleCollection<short> AV76Seguridad_cierremoduloswwds_5_tfcmmodmes_sels ;
      private GxSimpleCollection<short> AV78Seguridad_cierremoduloswwds_7_tfcmmodsts_sels ;
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
      private GXUserControl ucTfcmmodfecc_rangepicker ;
      private GXUserControl ucTfcmmodfecm_rangepicker ;
      private IGxDataStore dsDataStore2 ;
      private IGxDataStore dsDefault ;
      private GXCombobox cmbavCmmodmes ;
      private GXCombobox cmbavGridactions ;
      private GXCombobox cmbCMModMes ;
      private GXCombobox cmbCMModCod ;
      private GXCombobox cmbCMModSts ;
      private IDataStoreProvider pr_default ;
      private DateTime[] H000C2_A639CMModFecM ;
      private string[] H000C2_A642CMModUsuM ;
      private DateTime[] H000C2_A638CMModFecC ;
      private string[] H000C2_A641CMModUsuC ;
      private short[] H000C2_A640CMModSts ;
      private string[] H000C2_A73CMModCod ;
      private short[] H000C2_A75CMModMes ;
      private short[] H000C2_A74CMModAno ;
      private long[] H000C3_AGRID_nRecordCount ;
      private msglist BackMsgLst ;
      private msglist LclMsgLst ;
      private GxHttpRequest AV7HTTPRequest ;
      private GxSimpleCollection<string> AV66TFCMModCod_Sels ;
      private GxSimpleCollection<string> AV77Seguridad_cierremoduloswwds_6_tfcmmodcod_sels ;
      private GXBaseCollection<GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTDropDownOptionsData_Item> AV59AGExportData ;
      private GXWebForm Form ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPContext AV6WWPContext ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPTransactionContext AV8TrnContext ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPGridState AV10GridState ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue AV11GridStateFilterValue ;
      private GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTDropDownOptionsTitleSettingsIcons AV53DDO_TitleSettingsIcons ;
      private GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTDropDownOptionsTitleSettingsIcons GXt_SdtDVB_SDTDropDownOptionsTitleSettingsIcons1 ;
      private GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTDropDownOptionsData_Item AV60AGExportDataItem ;
   }

   public class cierremodulosww__default : DataStoreHelperBase, IDataStoreHelper
   {
      protected Object[] conditional_H000C2( IGxContext context ,
                                             short A75CMModMes ,
                                             GxSimpleCollection<short> AV76Seguridad_cierremoduloswwds_5_tfcmmodmes_sels ,
                                             string A73CMModCod ,
                                             GxSimpleCollection<string> AV77Seguridad_cierremoduloswwds_6_tfcmmodcod_sels ,
                                             short A640CMModSts ,
                                             GxSimpleCollection<short> AV78Seguridad_cierremoduloswwds_7_tfcmmodsts_sels ,
                                             short AV72Seguridad_cierremoduloswwds_1_cmmodano ,
                                             short AV73Seguridad_cierremoduloswwds_2_cmmodmes ,
                                             short AV74Seguridad_cierremoduloswwds_3_tfcmmodano ,
                                             short AV75Seguridad_cierremoduloswwds_4_tfcmmodano_to ,
                                             int AV76Seguridad_cierremoduloswwds_5_tfcmmodmes_sels_Count ,
                                             int AV77Seguridad_cierremoduloswwds_6_tfcmmodcod_sels_Count ,
                                             int AV78Seguridad_cierremoduloswwds_7_tfcmmodsts_sels_Count ,
                                             string AV80Seguridad_cierremoduloswwds_9_tfcmmodusuc_sel ,
                                             string AV79Seguridad_cierremoduloswwds_8_tfcmmodusuc ,
                                             DateTime AV81Seguridad_cierremoduloswwds_10_tfcmmodfecc ,
                                             DateTime AV82Seguridad_cierremoduloswwds_11_tfcmmodfecc_to ,
                                             string AV84Seguridad_cierremoduloswwds_13_tfcmmodusum_sel ,
                                             string AV83Seguridad_cierremoduloswwds_12_tfcmmodusum ,
                                             DateTime AV85Seguridad_cierremoduloswwds_14_tfcmmodfecm ,
                                             DateTime AV86Seguridad_cierremoduloswwds_15_tfcmmodfecm_to ,
                                             short A74CMModAno ,
                                             string A641CMModUsuC ,
                                             DateTime A638CMModFecC ,
                                             string A642CMModUsuM ,
                                             DateTime A639CMModFecM ,
                                             short AV13OrderedBy ,
                                             bool AV14OrderedDsc )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int5 = new short[15];
         Object[] GXv_Object6 = new Object[2];
         string sSelectString;
         string sFromString;
         string sOrderString;
         sSelectString = " [CMModFecM], [CMModUsuM], [CMModFecC], [CMModUsuC], [CMModSts], [CMModCod], [CMModMes], [CMModAno]";
         sFromString = " FROM [CBCIERREMODULO]";
         sOrderString = "";
         if ( ! (0==AV72Seguridad_cierremoduloswwds_1_cmmodano) )
         {
            AddWhere(sWhereString, "([CMModAno] = @AV72Seguridad_cierremoduloswwds_1_cmmodano)");
         }
         else
         {
            GXv_int5[0] = 1;
         }
         if ( ! (0==AV73Seguridad_cierremoduloswwds_2_cmmodmes) )
         {
            AddWhere(sWhereString, "([CMModMes] = @AV73Seguridad_cierremoduloswwds_2_cmmodmes)");
         }
         else
         {
            GXv_int5[1] = 1;
         }
         if ( ! (0==AV74Seguridad_cierremoduloswwds_3_tfcmmodano) )
         {
            AddWhere(sWhereString, "([CMModAno] >= @AV74Seguridad_cierremoduloswwds_3_tfcmmodano)");
         }
         else
         {
            GXv_int5[2] = 1;
         }
         if ( ! (0==AV75Seguridad_cierremoduloswwds_4_tfcmmodano_to) )
         {
            AddWhere(sWhereString, "([CMModAno] <= @AV75Seguridad_cierremoduloswwds_4_tfcmmodano_to)");
         }
         else
         {
            GXv_int5[3] = 1;
         }
         if ( AV76Seguridad_cierremoduloswwds_5_tfcmmodmes_sels_Count > 0 )
         {
            AddWhere(sWhereString, "("+new GxDbmsUtils( new GxSqlServer()).ValueList(AV76Seguridad_cierremoduloswwds_5_tfcmmodmes_sels, "[CMModMes] IN (", ")")+")");
         }
         if ( AV77Seguridad_cierremoduloswwds_6_tfcmmodcod_sels_Count > 0 )
         {
            AddWhere(sWhereString, "("+new GxDbmsUtils( new GxSqlServer()).ValueList(AV77Seguridad_cierremoduloswwds_6_tfcmmodcod_sels, "[CMModCod] IN (", ")")+")");
         }
         if ( AV78Seguridad_cierremoduloswwds_7_tfcmmodsts_sels_Count > 0 )
         {
            AddWhere(sWhereString, "("+new GxDbmsUtils( new GxSqlServer()).ValueList(AV78Seguridad_cierremoduloswwds_7_tfcmmodsts_sels, "[CMModSts] IN (", ")")+")");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV80Seguridad_cierremoduloswwds_9_tfcmmodusuc_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV79Seguridad_cierremoduloswwds_8_tfcmmodusuc)) ) )
         {
            AddWhere(sWhereString, "([CMModUsuC] like @lV79Seguridad_cierremoduloswwds_8_tfcmmodusuc)");
         }
         else
         {
            GXv_int5[4] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV80Seguridad_cierremoduloswwds_9_tfcmmodusuc_sel)) )
         {
            AddWhere(sWhereString, "([CMModUsuC] = @AV80Seguridad_cierremoduloswwds_9_tfcmmodusuc_sel)");
         }
         else
         {
            GXv_int5[5] = 1;
         }
         if ( ! (DateTime.MinValue==AV81Seguridad_cierremoduloswwds_10_tfcmmodfecc) )
         {
            AddWhere(sWhereString, "([CMModFecC] >= @AV81Seguridad_cierremoduloswwds_10_tfcmmodfecc)");
         }
         else
         {
            GXv_int5[6] = 1;
         }
         if ( ! (DateTime.MinValue==AV82Seguridad_cierremoduloswwds_11_tfcmmodfecc_to) )
         {
            AddWhere(sWhereString, "([CMModFecC] <= @AV82Seguridad_cierremoduloswwds_11_tfcmmodfecc_to)");
         }
         else
         {
            GXv_int5[7] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV84Seguridad_cierremoduloswwds_13_tfcmmodusum_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV83Seguridad_cierremoduloswwds_12_tfcmmodusum)) ) )
         {
            AddWhere(sWhereString, "([CMModUsuM] like @lV83Seguridad_cierremoduloswwds_12_tfcmmodusum)");
         }
         else
         {
            GXv_int5[8] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV84Seguridad_cierremoduloswwds_13_tfcmmodusum_sel)) )
         {
            AddWhere(sWhereString, "([CMModUsuM] = @AV84Seguridad_cierremoduloswwds_13_tfcmmodusum_sel)");
         }
         else
         {
            GXv_int5[9] = 1;
         }
         if ( ! (DateTime.MinValue==AV85Seguridad_cierremoduloswwds_14_tfcmmodfecm) )
         {
            AddWhere(sWhereString, "([CMModFecM] >= @AV85Seguridad_cierremoduloswwds_14_tfcmmodfecm)");
         }
         else
         {
            GXv_int5[10] = 1;
         }
         if ( ! (DateTime.MinValue==AV86Seguridad_cierremoduloswwds_15_tfcmmodfecm_to) )
         {
            AddWhere(sWhereString, "([CMModFecM] <= @AV86Seguridad_cierremoduloswwds_15_tfcmmodfecm_to)");
         }
         else
         {
            GXv_int5[11] = 1;
         }
         if ( ( AV13OrderedBy == 1 ) && ! AV14OrderedDsc )
         {
            sOrderString += " ORDER BY [CMModAno]";
         }
         else if ( ( AV13OrderedBy == 1 ) && ( AV14OrderedDsc ) )
         {
            sOrderString += " ORDER BY [CMModAno] DESC";
         }
         else if ( ( AV13OrderedBy == 2 ) && ! AV14OrderedDsc )
         {
            sOrderString += " ORDER BY [CMModMes]";
         }
         else if ( ( AV13OrderedBy == 2 ) && ( AV14OrderedDsc ) )
         {
            sOrderString += " ORDER BY [CMModMes] DESC";
         }
         else if ( ( AV13OrderedBy == 3 ) && ! AV14OrderedDsc )
         {
            sOrderString += " ORDER BY [CMModCod]";
         }
         else if ( ( AV13OrderedBy == 3 ) && ( AV14OrderedDsc ) )
         {
            sOrderString += " ORDER BY [CMModCod] DESC";
         }
         else if ( ( AV13OrderedBy == 4 ) && ! AV14OrderedDsc )
         {
            sOrderString += " ORDER BY [CMModSts]";
         }
         else if ( ( AV13OrderedBy == 4 ) && ( AV14OrderedDsc ) )
         {
            sOrderString += " ORDER BY [CMModSts] DESC";
         }
         else if ( ( AV13OrderedBy == 5 ) && ! AV14OrderedDsc )
         {
            sOrderString += " ORDER BY [CMModUsuC]";
         }
         else if ( ( AV13OrderedBy == 5 ) && ( AV14OrderedDsc ) )
         {
            sOrderString += " ORDER BY [CMModUsuC] DESC";
         }
         else if ( ( AV13OrderedBy == 6 ) && ! AV14OrderedDsc )
         {
            sOrderString += " ORDER BY [CMModFecC]";
         }
         else if ( ( AV13OrderedBy == 6 ) && ( AV14OrderedDsc ) )
         {
            sOrderString += " ORDER BY [CMModFecC] DESC";
         }
         else if ( ( AV13OrderedBy == 7 ) && ! AV14OrderedDsc )
         {
            sOrderString += " ORDER BY [CMModUsuM]";
         }
         else if ( ( AV13OrderedBy == 7 ) && ( AV14OrderedDsc ) )
         {
            sOrderString += " ORDER BY [CMModUsuM] DESC";
         }
         else if ( ( AV13OrderedBy == 8 ) && ! AV14OrderedDsc )
         {
            sOrderString += " ORDER BY [CMModFecM]";
         }
         else if ( ( AV13OrderedBy == 8 ) && ( AV14OrderedDsc ) )
         {
            sOrderString += " ORDER BY [CMModFecM] DESC";
         }
         else if ( true )
         {
            sOrderString += " ORDER BY [CMModCod], [CMModAno], [CMModMes]";
         }
         scmdbuf = "SELECT " + sSelectString + sFromString + sWhereString + sOrderString + "" + " OFFSET " + "@GXPagingFrom2" + " ROWS FETCH NEXT CAST((SELECT CASE WHEN " + "@GXPagingTo2" + " > 0 THEN " + "@GXPagingTo2" + " ELSE 1e9 END) AS INTEGER) ROWS ONLY";
         GXv_Object6[0] = scmdbuf;
         GXv_Object6[1] = GXv_int5;
         return GXv_Object6 ;
      }

      protected Object[] conditional_H000C3( IGxContext context ,
                                             short A75CMModMes ,
                                             GxSimpleCollection<short> AV76Seguridad_cierremoduloswwds_5_tfcmmodmes_sels ,
                                             string A73CMModCod ,
                                             GxSimpleCollection<string> AV77Seguridad_cierremoduloswwds_6_tfcmmodcod_sels ,
                                             short A640CMModSts ,
                                             GxSimpleCollection<short> AV78Seguridad_cierremoduloswwds_7_tfcmmodsts_sels ,
                                             short AV72Seguridad_cierremoduloswwds_1_cmmodano ,
                                             short AV73Seguridad_cierremoduloswwds_2_cmmodmes ,
                                             short AV74Seguridad_cierremoduloswwds_3_tfcmmodano ,
                                             short AV75Seguridad_cierremoduloswwds_4_tfcmmodano_to ,
                                             int AV76Seguridad_cierremoduloswwds_5_tfcmmodmes_sels_Count ,
                                             int AV77Seguridad_cierremoduloswwds_6_tfcmmodcod_sels_Count ,
                                             int AV78Seguridad_cierremoduloswwds_7_tfcmmodsts_sels_Count ,
                                             string AV80Seguridad_cierremoduloswwds_9_tfcmmodusuc_sel ,
                                             string AV79Seguridad_cierremoduloswwds_8_tfcmmodusuc ,
                                             DateTime AV81Seguridad_cierremoduloswwds_10_tfcmmodfecc ,
                                             DateTime AV82Seguridad_cierremoduloswwds_11_tfcmmodfecc_to ,
                                             string AV84Seguridad_cierremoduloswwds_13_tfcmmodusum_sel ,
                                             string AV83Seguridad_cierremoduloswwds_12_tfcmmodusum ,
                                             DateTime AV85Seguridad_cierremoduloswwds_14_tfcmmodfecm ,
                                             DateTime AV86Seguridad_cierremoduloswwds_15_tfcmmodfecm_to ,
                                             short A74CMModAno ,
                                             string A641CMModUsuC ,
                                             DateTime A638CMModFecC ,
                                             string A642CMModUsuM ,
                                             DateTime A639CMModFecM ,
                                             short AV13OrderedBy ,
                                             bool AV14OrderedDsc )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int7 = new short[12];
         Object[] GXv_Object8 = new Object[2];
         scmdbuf = "SELECT COUNT(*) FROM [CBCIERREMODULO]";
         if ( ! (0==AV72Seguridad_cierremoduloswwds_1_cmmodano) )
         {
            AddWhere(sWhereString, "([CMModAno] = @AV72Seguridad_cierremoduloswwds_1_cmmodano)");
         }
         else
         {
            GXv_int7[0] = 1;
         }
         if ( ! (0==AV73Seguridad_cierremoduloswwds_2_cmmodmes) )
         {
            AddWhere(sWhereString, "([CMModMes] = @AV73Seguridad_cierremoduloswwds_2_cmmodmes)");
         }
         else
         {
            GXv_int7[1] = 1;
         }
         if ( ! (0==AV74Seguridad_cierremoduloswwds_3_tfcmmodano) )
         {
            AddWhere(sWhereString, "([CMModAno] >= @AV74Seguridad_cierremoduloswwds_3_tfcmmodano)");
         }
         else
         {
            GXv_int7[2] = 1;
         }
         if ( ! (0==AV75Seguridad_cierremoduloswwds_4_tfcmmodano_to) )
         {
            AddWhere(sWhereString, "([CMModAno] <= @AV75Seguridad_cierremoduloswwds_4_tfcmmodano_to)");
         }
         else
         {
            GXv_int7[3] = 1;
         }
         if ( AV76Seguridad_cierremoduloswwds_5_tfcmmodmes_sels_Count > 0 )
         {
            AddWhere(sWhereString, "("+new GxDbmsUtils( new GxSqlServer()).ValueList(AV76Seguridad_cierremoduloswwds_5_tfcmmodmes_sels, "[CMModMes] IN (", ")")+")");
         }
         if ( AV77Seguridad_cierremoduloswwds_6_tfcmmodcod_sels_Count > 0 )
         {
            AddWhere(sWhereString, "("+new GxDbmsUtils( new GxSqlServer()).ValueList(AV77Seguridad_cierremoduloswwds_6_tfcmmodcod_sels, "[CMModCod] IN (", ")")+")");
         }
         if ( AV78Seguridad_cierremoduloswwds_7_tfcmmodsts_sels_Count > 0 )
         {
            AddWhere(sWhereString, "("+new GxDbmsUtils( new GxSqlServer()).ValueList(AV78Seguridad_cierremoduloswwds_7_tfcmmodsts_sels, "[CMModSts] IN (", ")")+")");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV80Seguridad_cierremoduloswwds_9_tfcmmodusuc_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV79Seguridad_cierremoduloswwds_8_tfcmmodusuc)) ) )
         {
            AddWhere(sWhereString, "([CMModUsuC] like @lV79Seguridad_cierremoduloswwds_8_tfcmmodusuc)");
         }
         else
         {
            GXv_int7[4] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV80Seguridad_cierremoduloswwds_9_tfcmmodusuc_sel)) )
         {
            AddWhere(sWhereString, "([CMModUsuC] = @AV80Seguridad_cierremoduloswwds_9_tfcmmodusuc_sel)");
         }
         else
         {
            GXv_int7[5] = 1;
         }
         if ( ! (DateTime.MinValue==AV81Seguridad_cierremoduloswwds_10_tfcmmodfecc) )
         {
            AddWhere(sWhereString, "([CMModFecC] >= @AV81Seguridad_cierremoduloswwds_10_tfcmmodfecc)");
         }
         else
         {
            GXv_int7[6] = 1;
         }
         if ( ! (DateTime.MinValue==AV82Seguridad_cierremoduloswwds_11_tfcmmodfecc_to) )
         {
            AddWhere(sWhereString, "([CMModFecC] <= @AV82Seguridad_cierremoduloswwds_11_tfcmmodfecc_to)");
         }
         else
         {
            GXv_int7[7] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV84Seguridad_cierremoduloswwds_13_tfcmmodusum_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV83Seguridad_cierremoduloswwds_12_tfcmmodusum)) ) )
         {
            AddWhere(sWhereString, "([CMModUsuM] like @lV83Seguridad_cierremoduloswwds_12_tfcmmodusum)");
         }
         else
         {
            GXv_int7[8] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV84Seguridad_cierremoduloswwds_13_tfcmmodusum_sel)) )
         {
            AddWhere(sWhereString, "([CMModUsuM] = @AV84Seguridad_cierremoduloswwds_13_tfcmmodusum_sel)");
         }
         else
         {
            GXv_int7[9] = 1;
         }
         if ( ! (DateTime.MinValue==AV85Seguridad_cierremoduloswwds_14_tfcmmodfecm) )
         {
            AddWhere(sWhereString, "([CMModFecM] >= @AV85Seguridad_cierremoduloswwds_14_tfcmmodfecm)");
         }
         else
         {
            GXv_int7[10] = 1;
         }
         if ( ! (DateTime.MinValue==AV86Seguridad_cierremoduloswwds_15_tfcmmodfecm_to) )
         {
            AddWhere(sWhereString, "([CMModFecM] <= @AV86Seguridad_cierremoduloswwds_15_tfcmmodfecm_to)");
         }
         else
         {
            GXv_int7[11] = 1;
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
                     return conditional_H000C2(context, (short)dynConstraints[0] , (GxSimpleCollection<short>)dynConstraints[1] , (string)dynConstraints[2] , (GxSimpleCollection<string>)dynConstraints[3] , (short)dynConstraints[4] , (GxSimpleCollection<short>)dynConstraints[5] , (short)dynConstraints[6] , (short)dynConstraints[7] , (short)dynConstraints[8] , (short)dynConstraints[9] , (int)dynConstraints[10] , (int)dynConstraints[11] , (int)dynConstraints[12] , (string)dynConstraints[13] , (string)dynConstraints[14] , (DateTime)dynConstraints[15] , (DateTime)dynConstraints[16] , (string)dynConstraints[17] , (string)dynConstraints[18] , (DateTime)dynConstraints[19] , (DateTime)dynConstraints[20] , (short)dynConstraints[21] , (string)dynConstraints[22] , (DateTime)dynConstraints[23] , (string)dynConstraints[24] , (DateTime)dynConstraints[25] , (short)dynConstraints[26] , (bool)dynConstraints[27] );
               case 1 :
                     return conditional_H000C3(context, (short)dynConstraints[0] , (GxSimpleCollection<short>)dynConstraints[1] , (string)dynConstraints[2] , (GxSimpleCollection<string>)dynConstraints[3] , (short)dynConstraints[4] , (GxSimpleCollection<short>)dynConstraints[5] , (short)dynConstraints[6] , (short)dynConstraints[7] , (short)dynConstraints[8] , (short)dynConstraints[9] , (int)dynConstraints[10] , (int)dynConstraints[11] , (int)dynConstraints[12] , (string)dynConstraints[13] , (string)dynConstraints[14] , (DateTime)dynConstraints[15] , (DateTime)dynConstraints[16] , (string)dynConstraints[17] , (string)dynConstraints[18] , (DateTime)dynConstraints[19] , (DateTime)dynConstraints[20] , (short)dynConstraints[21] , (string)dynConstraints[22] , (DateTime)dynConstraints[23] , (string)dynConstraints[24] , (DateTime)dynConstraints[25] , (short)dynConstraints[26] , (bool)dynConstraints[27] );
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
          Object[] prmH000C2;
          prmH000C2 = new Object[] {
          new ParDef("@AV72Seguridad_cierremoduloswwds_1_cmmodano",GXType.Int16,4,0) ,
          new ParDef("@AV73Seguridad_cierremoduloswwds_2_cmmodmes",GXType.Int16,2,0) ,
          new ParDef("@AV74Seguridad_cierremoduloswwds_3_tfcmmodano",GXType.Int16,4,0) ,
          new ParDef("@AV75Seguridad_cierremoduloswwds_4_tfcmmodano_to",GXType.Int16,4,0) ,
          new ParDef("@lV79Seguridad_cierremoduloswwds_8_tfcmmodusuc",GXType.NChar,10,0) ,
          new ParDef("@AV80Seguridad_cierremoduloswwds_9_tfcmmodusuc_sel",GXType.NChar,10,0) ,
          new ParDef("@AV81Seguridad_cierremoduloswwds_10_tfcmmodfecc",GXType.Date,8,0) ,
          new ParDef("@AV82Seguridad_cierremoduloswwds_11_tfcmmodfecc_to",GXType.Date,8,0) ,
          new ParDef("@lV83Seguridad_cierremoduloswwds_12_tfcmmodusum",GXType.NChar,10,0) ,
          new ParDef("@AV84Seguridad_cierremoduloswwds_13_tfcmmodusum_sel",GXType.NChar,10,0) ,
          new ParDef("@AV85Seguridad_cierremoduloswwds_14_tfcmmodfecm",GXType.Date,8,0) ,
          new ParDef("@AV86Seguridad_cierremoduloswwds_15_tfcmmodfecm_to",GXType.Date,8,0) ,
          new ParDef("@GXPagingFrom2",GXType.Int32,9,0) ,
          new ParDef("@GXPagingTo2",GXType.Int32,9,0) ,
          new ParDef("@GXPagingTo2",GXType.Int32,9,0)
          };
          Object[] prmH000C3;
          prmH000C3 = new Object[] {
          new ParDef("@AV72Seguridad_cierremoduloswwds_1_cmmodano",GXType.Int16,4,0) ,
          new ParDef("@AV73Seguridad_cierremoduloswwds_2_cmmodmes",GXType.Int16,2,0) ,
          new ParDef("@AV74Seguridad_cierremoduloswwds_3_tfcmmodano",GXType.Int16,4,0) ,
          new ParDef("@AV75Seguridad_cierremoduloswwds_4_tfcmmodano_to",GXType.Int16,4,0) ,
          new ParDef("@lV79Seguridad_cierremoduloswwds_8_tfcmmodusuc",GXType.NChar,10,0) ,
          new ParDef("@AV80Seguridad_cierremoduloswwds_9_tfcmmodusuc_sel",GXType.NChar,10,0) ,
          new ParDef("@AV81Seguridad_cierremoduloswwds_10_tfcmmodfecc",GXType.Date,8,0) ,
          new ParDef("@AV82Seguridad_cierremoduloswwds_11_tfcmmodfecc_to",GXType.Date,8,0) ,
          new ParDef("@lV83Seguridad_cierremoduloswwds_12_tfcmmodusum",GXType.NChar,10,0) ,
          new ParDef("@AV84Seguridad_cierremoduloswwds_13_tfcmmodusum_sel",GXType.NChar,10,0) ,
          new ParDef("@AV85Seguridad_cierremoduloswwds_14_tfcmmodfecm",GXType.Date,8,0) ,
          new ParDef("@AV86Seguridad_cierremoduloswwds_15_tfcmmodfecm_to",GXType.Date,8,0)
          };
          def= new CursorDef[] {
              new CursorDef("H000C2", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH000C2,11, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("H000C3", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH000C3,1, GxCacheFrequency.OFF ,true,false )
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
                ((DateTime[]) buf[0])[0] = rslt.getGXDate(1);
                ((string[]) buf[1])[0] = rslt.getString(2, 10);
                ((DateTime[]) buf[2])[0] = rslt.getGXDate(3);
                ((string[]) buf[3])[0] = rslt.getString(4, 10);
                ((short[]) buf[4])[0] = rslt.getShort(5);
                ((string[]) buf[5])[0] = rslt.getString(6, 3);
                ((short[]) buf[6])[0] = rslt.getShort(7);
                ((short[]) buf[7])[0] = rslt.getShort(8);
                return;
             case 1 :
                ((long[]) buf[0])[0] = rslt.getLong(1);
                return;
       }
    }

 }

}
