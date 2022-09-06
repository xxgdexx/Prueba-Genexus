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
   public class tipocambioww : GXDataArea
   {
      public tipocambioww( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDataStore2 = context.GetDataStore("DataStore2");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusTheme");
      }

      public tipocambioww( IGxContext context )
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
               nRC_GXsfl_121 = (int)(NumberUtil.Val( GetPar( "nRC_GXsfl_121"), "."));
               nGXsfl_121_idx = (int)(NumberUtil.Val( GetPar( "nGXsfl_121_idx"), "."));
               sGXsfl_121_idx = GetPar( "sGXsfl_121_idx");
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
               AV50MonDsc1 = GetPar( "MonDsc1");
               cmbavDynamicfiltersselector2.FromJSonString( GetNextPar( ));
               AV19DynamicFiltersSelector2 = GetPar( "DynamicFiltersSelector2");
               cmbavDynamicfiltersoperator2.FromJSonString( GetNextPar( ));
               AV20DynamicFiltersOperator2 = (short)(NumberUtil.Val( GetPar( "DynamicFiltersOperator2"), "."));
               AV53MonDsc2 = GetPar( "MonDsc2");
               cmbavDynamicfiltersselector3.FromJSonString( GetNextPar( ));
               AV23DynamicFiltersSelector3 = GetPar( "DynamicFiltersSelector3");
               cmbavDynamicfiltersoperator3.FromJSonString( GetNextPar( ));
               AV24DynamicFiltersOperator3 = (short)(NumberUtil.Val( GetPar( "DynamicFiltersOperator3"), "."));
               AV56MonDsc3 = GetPar( "MonDsc3");
               AV51TipFech1 = context.localUtil.ParseDateParm( GetPar( "TipFech1"));
               AV54TipFech2 = context.localUtil.ParseDateParm( GetPar( "TipFech2"));
               AV57TipFech3 = context.localUtil.ParseDateParm( GetPar( "TipFech3"));
               AV18DynamicFiltersEnabled2 = StringUtil.StrToBool( GetPar( "DynamicFiltersEnabled2"));
               AV22DynamicFiltersEnabled3 = StringUtil.StrToBool( GetPar( "DynamicFiltersEnabled3"));
               AV64Pgmname = GetPar( "Pgmname");
               AV52TipFech_To1 = context.localUtil.ParseDateParm( GetPar( "TipFech_To1"));
               AV55TipFech_To2 = context.localUtil.ParseDateParm( GetPar( "TipFech_To2"));
               AV58TipFech_To3 = context.localUtil.ParseDateParm( GetPar( "TipFech_To3"));
               AV48TFMonDsc = GetPar( "TFMonDsc");
               AV49TFMonDsc_Sel = GetPar( "TFMonDsc_Sel");
               AV31TFTipFech = context.localUtil.ParseDateParm( GetPar( "TFTipFech"));
               AV32TFTipFech_To = context.localUtil.ParseDateParm( GetPar( "TFTipFech_To"));
               AV36TFTipCompra = NumberUtil.Val( GetPar( "TFTipCompra"), ".");
               AV37TFTipCompra_To = NumberUtil.Val( GetPar( "TFTipCompra_To"), ".");
               AV38TFTipVenta = NumberUtil.Val( GetPar( "TFTipVenta"), ".");
               AV39TFTipVenta_To = NumberUtil.Val( GetPar( "TFTipVenta_To"), ".");
               AV13OrderedBy = (short)(NumberUtil.Val( GetPar( "OrderedBy"), "."));
               AV14OrderedDsc = StringUtil.StrToBool( GetPar( "OrderedDsc"));
               ajax_req_read_hidden_sdt(GetNextPar( ), AV10GridState);
               AV27DynamicFiltersIgnoreFirst = StringUtil.StrToBool( GetPar( "DynamicFiltersIgnoreFirst"));
               AV26DynamicFiltersRemoving = StringUtil.StrToBool( GetPar( "DynamicFiltersRemoving"));
               A180MonCod = (int)(NumberUtil.Val( GetPar( "MonCod"), "."));
               Gx_date = context.localUtil.ParseDateParm( GetPar( "Gx_date"));
               setAjaxCallMode();
               if ( ! IsValidAjaxCall( true) )
               {
                  GxWebError = 1;
                  return  ;
               }
               gxgrGrid_refresh( subGrid_Rows, AV15DynamicFiltersSelector1, AV16DynamicFiltersOperator1, AV50MonDsc1, AV19DynamicFiltersSelector2, AV20DynamicFiltersOperator2, AV53MonDsc2, AV23DynamicFiltersSelector3, AV24DynamicFiltersOperator3, AV56MonDsc3, AV51TipFech1, AV54TipFech2, AV57TipFech3, AV18DynamicFiltersEnabled2, AV22DynamicFiltersEnabled3, AV64Pgmname, AV52TipFech_To1, AV55TipFech_To2, AV58TipFech_To3, AV48TFMonDsc, AV49TFMonDsc_Sel, AV31TFTipFech, AV32TFTipFech_To, AV36TFTipCompra, AV37TFTipCompra_To, AV38TFTipVenta, AV39TFTipVenta_To, AV13OrderedBy, AV14OrderedDsc, AV10GridState, AV27DynamicFiltersIgnoreFirst, AV26DynamicFiltersRemoving, A180MonCod, Gx_date) ;
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
         PA1W2( ) ;
         gxajaxcallmode = (short)((isAjaxCallMode( ) ? 1 : 0));
         if ( ( gxajaxcallmode == 0 ) && ( GxWebError == 0 ) )
         {
            START1W2( ) ;
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
         context.AddJavascriptSource("gxcfg.js", "?202281810295497", false, true);
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
         context.AddJavascriptSource("Window/InNewWindowRender.js", "", false, true);
         context.AddJavascriptSource("DVelop/Bootstrap/Shared/DVelopBootstrap.js", "", false, true);
         context.AddJavascriptSource("DVelop/Shared/WorkWithPlusCommon.js", "", false, true);
         context.AddJavascriptSource("DVelop/Bootstrap/DropDownOptions/BootstrapDropDownOptionsRender.js", "", false, true);
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
         context.AddJavascriptSource("DVelop/Shared/daterangepicker/locales.js", "", false, true);
         context.AddJavascriptSource("DVelop/Shared/daterangepicker/wwp-daterangepicker.js", "", false, true);
         context.AddJavascriptSource("DVelop/Shared/daterangepicker/moment.min.js", "", false, true);
         context.AddJavascriptSource("DVelop/Shared/daterangepicker/daterangepicker.min.js", "", false, true);
         context.AddJavascriptSource("DVelop/Shared/WorkWithPlusCommon.js", "", false, true);
         context.AddJavascriptSource("DVelop/DateRangePicker/DateRangePickerRender.js", "", false, true);
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
         context.WriteHtmlTextNl( "<form id=\"MAINFORM\" autocomplete=\"off\" name=\"MAINFORM\" method=\"post\" tabindex=-1  class=\"form-horizontal Form\" data-gx-class=\"form-horizontal Form\" novalidate action=\""+formatLink("configuracion.tipocambioww.aspx") +"\">") ;
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
         GxWebStd.gx_hidden_field( context, "gxhash_vPGMNAME", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( AV64Pgmname, "")), context));
         GxWebStd.gx_hidden_field( context, "gxhash_vTODAY", GetSecureSignedToken( "", Gx_date, context));
         GXKey = Crypto.GetSiteKey( );
      }

      protected void SendCloseFormHiddens( )
      {
         /* Send hidden variables. */
         GxWebStd.gx_hidden_field( context, "GXH_vDYNAMICFILTERSSELECTOR1", AV15DynamicFiltersSelector1);
         GxWebStd.gx_hidden_field( context, "GXH_vDYNAMICFILTERSOPERATOR1", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV16DynamicFiltersOperator1), 4, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "GXH_vMONDSC1", StringUtil.RTrim( AV50MonDsc1));
         GxWebStd.gx_hidden_field( context, "GXH_vDYNAMICFILTERSSELECTOR2", AV19DynamicFiltersSelector2);
         GxWebStd.gx_hidden_field( context, "GXH_vDYNAMICFILTERSOPERATOR2", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV20DynamicFiltersOperator2), 4, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "GXH_vMONDSC2", StringUtil.RTrim( AV53MonDsc2));
         GxWebStd.gx_hidden_field( context, "GXH_vDYNAMICFILTERSSELECTOR3", AV23DynamicFiltersSelector3);
         GxWebStd.gx_hidden_field( context, "GXH_vDYNAMICFILTERSOPERATOR3", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV24DynamicFiltersOperator3), 4, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "GXH_vMONDSC3", StringUtil.RTrim( AV56MonDsc3));
         GxWebStd.gx_hidden_field( context, "GXH_vTIPFECH1", context.localUtil.Format(AV51TipFech1, "99/99/99"));
         GxWebStd.gx_hidden_field( context, "GXH_vTIPFECH2", context.localUtil.Format(AV54TipFech2, "99/99/99"));
         GxWebStd.gx_hidden_field( context, "GXH_vTIPFECH3", context.localUtil.Format(AV57TipFech3, "99/99/99"));
         /* Send saved values. */
         send_integrity_footer_hashes( ) ;
         GxWebStd.gx_hidden_field( context, "nRC_GXsfl_121", StringUtil.LTrim( StringUtil.NToC( (decimal)(nRC_GXsfl_121), 8, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "vGRIDCURRENTPAGE", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV42GridCurrentPage), 10, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "vGRIDPAGECOUNT", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV43GridPageCount), 10, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "vGRIDAPPLIEDFILTERS", AV44GridAppliedFilters);
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "vAGEXPORTDATA", AV46AGExportData);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt("vAGEXPORTDATA", AV46AGExportData);
         }
         GxWebStd.gx_hidden_field( context, "vTIPFECH_TO1", context.localUtil.DToC( AV52TipFech_To1, 0, "/"));
         GxWebStd.gx_hidden_field( context, "vTIPFECH_TO2", context.localUtil.DToC( AV55TipFech_To2, 0, "/"));
         GxWebStd.gx_hidden_field( context, "vTIPFECH_TO3", context.localUtil.DToC( AV58TipFech_To3, 0, "/"));
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "vDDO_TITLESETTINGSICONS", AV40DDO_TitleSettingsIcons);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt("vDDO_TITLESETTINGSICONS", AV40DDO_TitleSettingsIcons);
         }
         GxWebStd.gx_hidden_field( context, "vDDO_TIPFECHAUXDATETO", context.localUtil.DToC( AV34DDO_TipFechAuxDateTo, 0, "/"));
         GxWebStd.gx_boolean_hidden_field( context, "vDYNAMICFILTERSENABLED2", AV18DynamicFiltersEnabled2);
         GxWebStd.gx_boolean_hidden_field( context, "vDYNAMICFILTERSENABLED3", AV22DynamicFiltersEnabled3);
         GxWebStd.gx_hidden_field( context, "vPGMNAME", StringUtil.RTrim( AV64Pgmname));
         GxWebStd.gx_hidden_field( context, "gxhash_vPGMNAME", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( AV64Pgmname, "")), context));
         GxWebStd.gx_hidden_field( context, "vTFMONDSC", StringUtil.RTrim( AV48TFMonDsc));
         GxWebStd.gx_hidden_field( context, "vTFMONDSC_SEL", StringUtil.RTrim( AV49TFMonDsc_Sel));
         GxWebStd.gx_hidden_field( context, "vTFTIPFECH", context.localUtil.DToC( AV31TFTipFech, 0, "/"));
         GxWebStd.gx_hidden_field( context, "vTFTIPFECH_TO", context.localUtil.DToC( AV32TFTipFech_To, 0, "/"));
         GxWebStd.gx_hidden_field( context, "vTFTIPCOMPRA", StringUtil.LTrim( StringUtil.NToC( AV36TFTipCompra, 15, 5, ".", "")));
         GxWebStd.gx_hidden_field( context, "vTFTIPCOMPRA_TO", StringUtil.LTrim( StringUtil.NToC( AV37TFTipCompra_To, 15, 5, ".", "")));
         GxWebStd.gx_hidden_field( context, "vTFTIPVENTA", StringUtil.LTrim( StringUtil.NToC( AV38TFTipVenta, 15, 5, ".", "")));
         GxWebStd.gx_hidden_field( context, "vTFTIPVENTA_TO", StringUtil.LTrim( StringUtil.NToC( AV39TFTipVenta_To, 15, 5, ".", "")));
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
         GxWebStd.gx_hidden_field( context, "MONCOD", StringUtil.LTrim( StringUtil.NToC( (decimal)(A180MonCod), 6, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "vTODAY", context.localUtil.DToC( Gx_date, 0, "/"));
         GxWebStd.gx_hidden_field( context, "gxhash_vTODAY", GetSecureSignedToken( "", Gx_date, context));
         GxWebStd.gx_hidden_field( context, "GRID_nFirstRecordOnPage", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRID_nFirstRecordOnPage), 15, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "GRID_nEOF", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRID_nEOF), 1, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "vTIPFECH1", context.localUtil.DToC( AV51TipFech1, 0, "/"));
         GxWebStd.gx_hidden_field( context, "vTIPFECH2", context.localUtil.DToC( AV54TipFech2, 0, "/"));
         GxWebStd.gx_hidden_field( context, "vTIPFECH3", context.localUtil.DToC( AV57TipFech3, 0, "/"));
         GxWebStd.gx_hidden_field( context, "vDDO_TIPFECHAUXDATE", context.localUtil.DToC( AV33DDO_TipFechAuxDate, 0, "/"));
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
         GxWebStd.gx_hidden_field( context, "INNEWWINDOW_Target", StringUtil.RTrim( Innewwindow_Target));
         GxWebStd.gx_hidden_field( context, "INNEWWINDOW_Fullscreen", StringUtil.BoolToStr( Innewwindow_Fullscreen));
         GxWebStd.gx_hidden_field( context, "INNEWWINDOW_Toolbar", StringUtil.BoolToStr( Innewwindow_Toolbar));
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
            WE1W2( ) ;
            context.WriteHtmlText( "</div>") ;
         }
      }

      public override void DispatchEvents( )
      {
         EVT1W2( ) ;
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
         return formatLink("configuracion.tipocambioww.aspx")  ;
      }

      public override string GetPgmname( )
      {
         return "Configuracion.TipoCambioWW" ;
      }

      public override string GetPgmdesc( )
      {
         return "Tipos de Cambio" ;
      }

      protected void WB1W0( )
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
            GxWebStd.gx_button_ctrl( context, bttBtninsert_Internalname, "gx.evt.setGridEvt("+StringUtil.Str( (decimal)(121), 3, 0)+","+"null"+");", "Agregar", bttBtninsert_Jsonclick, 5, "Agregar", "", StyleString, ClassString, 1, 1, "standard", "'"+""+"'"+",false,"+"'"+"E\\'DOINSERT\\'."+"'", TempTags, "", context.GetButtonType( ), "HLP_Configuracion\\TipoCambioWW.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "left", "top", "", "", "div");
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 21,'',false,'',0)\"";
            ClassString = "ColumnsSelector";
            StyleString = "";
            GxWebStd.gx_button_ctrl( context, bttBtnagexport_Internalname, "gx.evt.setGridEvt("+StringUtil.Str( (decimal)(121), 3, 0)+","+"null"+");", "Reportes", bttBtnagexport_Jsonclick, 0, "Reportes", "", StyleString, ClassString, 1, 0, "standard", "'"+""+"'"+",false,"+"'"+""+"'", TempTags, "", context.GetButtonType( ), "HLP_Configuracion\\TipoCambioWW.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "DataContentCellLogin CellPaddingLogin", "left", "top", "", "", "div");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblLinktipocambio_Internalname, "Link Ver tipos de Cambio Sunat", "", "", lblLinktipocambio_Jsonclick, "'"+""+"'"+",false,"+"'"+"e111w1_client"+"'", "", "DataDescriptionLogin", 7, "", 1, 1, 0, 1, "HLP_Configuracion\\TipoCambioWW.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divTablerightheader_Internalname, 1, 0, "px", 0, "px", "Flex", "left", "top", " "+"data-gx-flex"+" ", "flex-wrap:wrap;", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "", "left", "top", "", "flex-grow:1;", "div");
            wb_table1_27_1W2( true) ;
         }
         else
         {
            wb_table1_27_1W2( false) ;
         }
         return  ;
      }

      protected void wb_table1_27_1W2e( bool wbgen )
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
               context.WriteHtmlText( "<div id=\""+"GridContainer"+"DivS\" data-gxgridid=\"121\">") ;
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
               context.SendWebValue( "Tipo de Cambio Moneda") ;
               context.WriteHtmlTextNl( "</th>") ;
               context.WriteHtmlText( "<th align=\""+"left"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+""+""+"\" "+">") ;
               context.SendWebValue( "Moneda") ;
               context.WriteHtmlTextNl( "</th>") ;
               context.WriteHtmlText( "<th align=\""+"right"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+""+""+"\" "+">") ;
               context.SendWebValue( "Fecha") ;
               context.WriteHtmlTextNl( "</th>") ;
               context.WriteHtmlText( "<th align=\""+"right"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+""+""+"\" "+">") ;
               context.SendWebValue( "Compra") ;
               context.WriteHtmlTextNl( "</th>") ;
               context.WriteHtmlText( "<th align=\""+"right"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+""+""+"\" "+">") ;
               context.SendWebValue( "Venta") ;
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
               GridColumn.AddObjectProperty("Value", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV45GridActions), 4, 0, ".", "")));
               GridContainer.AddColumnProperties(GridColumn);
               GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
               GridColumn.AddObjectProperty("Value", StringUtil.LTrim( StringUtil.NToC( (decimal)(A307TipMonCod), 6, 0, ".", "")));
               GridContainer.AddColumnProperties(GridColumn);
               GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
               GridColumn.AddObjectProperty("Value", StringUtil.RTrim( A1234MonDsc));
               GridColumn.AddObjectProperty("Link", StringUtil.RTrim( edtMonDsc_Link));
               GridContainer.AddColumnProperties(GridColumn);
               GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
               GridColumn.AddObjectProperty("Value", context.localUtil.Format(A308TipFech, "99/99/99"));
               GridContainer.AddColumnProperties(GridColumn);
               GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
               GridColumn.AddObjectProperty("Value", StringUtil.LTrim( StringUtil.NToC( A1907TipCompra, 15, 5, ".", "")));
               GridColumn.AddObjectProperty("Link", StringUtil.RTrim( edtTipCompra_Link));
               GridContainer.AddColumnProperties(GridColumn);
               GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
               GridColumn.AddObjectProperty("Value", StringUtil.LTrim( StringUtil.NToC( A1920TipVenta, 15, 5, ".", "")));
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
         if ( wbEnd == 121 )
         {
            wbEnd = 0;
            nRC_GXsfl_121 = (int)(nGXsfl_121_idx-1);
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
            ucGridpaginationbar.SetProperty("CurrentPage", AV42GridCurrentPage);
            ucGridpaginationbar.SetProperty("PageCount", AV43GridPageCount);
            ucGridpaginationbar.SetProperty("AppliedFilters", AV44GridAppliedFilters);
            ucGridpaginationbar.Render(context, "dvelop.dvpaginationbar", Gridpaginationbar_Internalname, "GRIDPAGINATIONBARContainer");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
            /* User Defined Control */
            ucInnewwindow.Render(context, "innewwindow", Innewwindow_Internalname, "INNEWWINDOWContainer");
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
            ucDdo_agexport.SetProperty("DropDownOptionsData", AV46AGExportData);
            ucDdo_agexport.Render(context, "dvelop.gxbootstrap.ddoregular", Ddo_agexport_Internalname, "DDO_AGEXPORTContainer");
            /* User Defined Control */
            ucTipfech_rangepicker1.SetProperty("Start Date", AV51TipFech1);
            ucTipfech_rangepicker1.SetProperty("End Date", AV52TipFech_To1);
            ucTipfech_rangepicker1.Render(context, "wwp.daterangepicker", Tipfech_rangepicker1_Internalname, "TIPFECH_RANGEPICKER1Container");
            /* User Defined Control */
            ucTipfech_rangepicker2.SetProperty("Start Date", AV54TipFech2);
            ucTipfech_rangepicker2.SetProperty("End Date", AV55TipFech_To2);
            ucTipfech_rangepicker2.Render(context, "wwp.daterangepicker", Tipfech_rangepicker2_Internalname, "TIPFECH_RANGEPICKER2Container");
            /* User Defined Control */
            ucTipfech_rangepicker3.SetProperty("Start Date", AV57TipFech3);
            ucTipfech_rangepicker3.SetProperty("End Date", AV58TipFech_To3);
            ucTipfech_rangepicker3.Render(context, "wwp.daterangepicker", Tipfech_rangepicker3_Internalname, "TIPFECH_RANGEPICKER3Container");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblJsdynamicfilters_Internalname, lblJsdynamicfilters_Caption, "", "", lblJsdynamicfilters_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "", 0, "", 1, 1, 0, 1, "HLP_Configuracion\\TipoCambioWW.htm");
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
            ucDdo_grid.SetProperty("DropDownOptionsTitleSettingsIcons", AV40DDO_TitleSettingsIcons);
            ucDdo_grid.Render(context, "dvelop.gxbootstrap.ddogridtitlesettingsm", Ddo_grid_Internalname, "DDO_GRIDContainer");
            /* User Defined Control */
            ucInnewwindow1.Render(context, "innewwindow", Innewwindow1_Internalname, "INNEWWINDOW1Container");
            /* User Defined Control */
            ucGrid_empowerer.SetProperty("HasTitleSettings", Grid_empowerer_Hastitlesettings);
            ucGrid_empowerer.Render(context, "wwp.gridempowerer", Grid_empowerer_Internalname, "GRID_EMPOWERERContainer");
            /* Div Control */
            GxWebStd.gx_div_start( context, divDdo_tipfechauxdates_Internalname, 1, 0, "px", 0, "px", "Invisible", "left", "top", "", "", "div");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 146,'',false,'" + sGXsfl_121_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavDdo_tipfechauxdatetext_Internalname, AV35DDO_TipFechAuxDateText, StringUtil.RTrim( context.localUtil.Format( AV35DDO_TipFechAuxDateText, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,146);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavDdo_tipfechauxdatetext_Jsonclick, 0, "Attribute", "", "", "", "", 1, 1, 0, "text", "", 40, "chr", 1, "row", 40, 0, 0, 0, 1, -1, -1, true, "", "left", true, "", "HLP_Configuracion\\TipoCambioWW.htm");
            /* User Defined Control */
            ucTftipfech_rangepicker.SetProperty("Start Date", AV33DDO_TipFechAuxDate);
            ucTftipfech_rangepicker.SetProperty("End Date", AV34DDO_TipFechAuxDateTo);
            ucTftipfech_rangepicker.Render(context, "wwp.daterangepicker", Tftipfech_rangepicker_Internalname, "TFTIPFECH_RANGEPICKERContainer");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
         }
         if ( wbEnd == 121 )
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

      protected void START1W2( )
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
            Form.Meta.addItem("description", "Tipos de Cambio", 0) ;
         }
         context.wjLoc = "";
         context.nUserReturn = 0;
         context.wbHandled = 0;
         if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
         {
         }
         wbErr = false;
         STRUP1W0( ) ;
      }

      protected void WS1W2( )
      {
         START1W2( ) ;
         EVT1W2( ) ;
      }

      protected void EVT1W2( )
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
                              E121W2 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "GRIDPAGINATIONBAR.CHANGEROWSPERPAGE") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              E131W2 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "DDO_AGEXPORT.ONOPTIONCLICKED") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              E141W2 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "TIPFECH_RANGEPICKER1.DATERANGECHANGED") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              E151W2 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "TIPFECH_RANGEPICKER2.DATERANGECHANGED") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              E161W2 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "TIPFECH_RANGEPICKER3.DATERANGECHANGED") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              E171W2 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "DDO_GRID.ONOPTIONCLICKED") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              E181W2 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "'REMOVEDYNAMICFILTERS1'") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              /* Execute user event: 'RemoveDynamicFilters1' */
                              E191W2 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "'REMOVEDYNAMICFILTERS2'") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              /* Execute user event: 'RemoveDynamicFilters2' */
                              E201W2 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "'REMOVEDYNAMICFILTERS3'") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              /* Execute user event: 'RemoveDynamicFilters3' */
                              E211W2 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "'DOINSERT'") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              /* Execute user event: 'DoInsert' */
                              E221W2 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "'ADDDYNAMICFILTERS1'") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              /* Execute user event: 'AddDynamicFilters1' */
                              E231W2 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "VDYNAMICFILTERSSELECTOR1.CLICK") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              E241W2 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "VDYNAMICFILTERSOPERATOR1.CLICK") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              E251W2 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "'ADDDYNAMICFILTERS2'") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              /* Execute user event: 'AddDynamicFilters2' */
                              E261W2 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "VDYNAMICFILTERSSELECTOR2.CLICK") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              E271W2 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "VDYNAMICFILTERSOPERATOR2.CLICK") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              E281W2 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "VDYNAMICFILTERSSELECTOR3.CLICK") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              E291W2 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "VDYNAMICFILTERSOPERATOR3.CLICK") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              E301W2 ();
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
                              nGXsfl_121_idx = (int)(NumberUtil.Val( sEvtType, "."));
                              sGXsfl_121_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_121_idx), 4, 0), 4, "0");
                              SubsflControlProps_1212( ) ;
                              cmbavGridactions.Name = cmbavGridactions_Internalname;
                              cmbavGridactions.CurrentValue = cgiGet( cmbavGridactions_Internalname);
                              AV45GridActions = (short)(NumberUtil.Val( cgiGet( cmbavGridactions_Internalname), "."));
                              AssignAttri("", false, cmbavGridactions_Internalname, StringUtil.LTrimStr( (decimal)(AV45GridActions), 4, 0));
                              A307TipMonCod = (int)(context.localUtil.CToN( cgiGet( edtTipMonCod_Internalname), ".", ","));
                              A1234MonDsc = cgiGet( edtMonDsc_Internalname);
                              n1234MonDsc = false;
                              A308TipFech = DateTimeUtil.ResetTime(context.localUtil.CToT( cgiGet( edtTipFech_Internalname), 0));
                              A1907TipCompra = context.localUtil.CToN( cgiGet( edtTipCompra_Internalname), ".", ",");
                              A1920TipVenta = context.localUtil.CToN( cgiGet( edtTipVenta_Internalname), ".", ",");
                              sEvtType = StringUtil.Right( sEvt, 1);
                              if ( StringUtil.StrCmp(sEvtType, ".") == 0 )
                              {
                                 sEvt = StringUtil.Left( sEvt, (short)(StringUtil.Len( sEvt)-1));
                                 if ( StringUtil.StrCmp(sEvt, "START") == 0 )
                                 {
                                    context.wbHandled = 1;
                                    dynload_actions( ) ;
                                    /* Execute user event: Start */
                                    E311W2 ();
                                 }
                                 else if ( StringUtil.StrCmp(sEvt, "REFRESH") == 0 )
                                 {
                                    context.wbHandled = 1;
                                    dynload_actions( ) ;
                                    /* Execute user event: Refresh */
                                    E321W2 ();
                                 }
                                 else if ( StringUtil.StrCmp(sEvt, "GRID.LOAD") == 0 )
                                 {
                                    context.wbHandled = 1;
                                    dynload_actions( ) ;
                                    E331W2 ();
                                 }
                                 else if ( StringUtil.StrCmp(sEvt, "VGRIDACTIONS.CLICK") == 0 )
                                 {
                                    context.wbHandled = 1;
                                    dynload_actions( ) ;
                                    E341W2 ();
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
                                       /* Set Refresh If Mondsc1 Changed */
                                       if ( StringUtil.StrCmp(cgiGet( "GXH_vMONDSC1"), AV50MonDsc1) != 0 )
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
                                       /* Set Refresh If Mondsc2 Changed */
                                       if ( StringUtil.StrCmp(cgiGet( "GXH_vMONDSC2"), AV53MonDsc2) != 0 )
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
                                       /* Set Refresh If Mondsc3 Changed */
                                       if ( StringUtil.StrCmp(cgiGet( "GXH_vMONDSC3"), AV56MonDsc3) != 0 )
                                       {
                                          Rfr0gs = true;
                                       }
                                       /* Set Refresh If Tipfech1 Changed */
                                       if ( context.localUtil.CToT( cgiGet( "GXH_vTIPFECH1"), 0) != AV51TipFech1 )
                                       {
                                          Rfr0gs = true;
                                       }
                                       /* Set Refresh If Tipfech2 Changed */
                                       if ( context.localUtil.CToT( cgiGet( "GXH_vTIPFECH2"), 0) != AV54TipFech2 )
                                       {
                                          Rfr0gs = true;
                                       }
                                       /* Set Refresh If Tipfech3 Changed */
                                       if ( context.localUtil.CToT( cgiGet( "GXH_vTIPFECH3"), 0) != AV57TipFech3 )
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

      protected void WE1W2( )
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

      protected void PA1W2( )
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
         SubsflControlProps_1212( ) ;
         while ( nGXsfl_121_idx <= nRC_GXsfl_121 )
         {
            sendrow_1212( ) ;
            nGXsfl_121_idx = ((subGrid_Islastpage==1)&&(nGXsfl_121_idx+1>subGrid_fnc_Recordsperpage( )) ? 1 : nGXsfl_121_idx+1);
            sGXsfl_121_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_121_idx), 4, 0), 4, "0");
            SubsflControlProps_1212( ) ;
         }
         AddString( context.httpAjaxContext.getJSONContainerResponse( GridContainer)) ;
         /* End function gxnrGrid_newrow */
      }

      protected void gxgrGrid_refresh( int subGrid_Rows ,
                                       string AV15DynamicFiltersSelector1 ,
                                       short AV16DynamicFiltersOperator1 ,
                                       string AV50MonDsc1 ,
                                       string AV19DynamicFiltersSelector2 ,
                                       short AV20DynamicFiltersOperator2 ,
                                       string AV53MonDsc2 ,
                                       string AV23DynamicFiltersSelector3 ,
                                       short AV24DynamicFiltersOperator3 ,
                                       string AV56MonDsc3 ,
                                       DateTime AV51TipFech1 ,
                                       DateTime AV54TipFech2 ,
                                       DateTime AV57TipFech3 ,
                                       bool AV18DynamicFiltersEnabled2 ,
                                       bool AV22DynamicFiltersEnabled3 ,
                                       string AV64Pgmname ,
                                       DateTime AV52TipFech_To1 ,
                                       DateTime AV55TipFech_To2 ,
                                       DateTime AV58TipFech_To3 ,
                                       string AV48TFMonDsc ,
                                       string AV49TFMonDsc_Sel ,
                                       DateTime AV31TFTipFech ,
                                       DateTime AV32TFTipFech_To ,
                                       decimal AV36TFTipCompra ,
                                       decimal AV37TFTipCompra_To ,
                                       decimal AV38TFTipVenta ,
                                       decimal AV39TFTipVenta_To ,
                                       short AV13OrderedBy ,
                                       bool AV14OrderedDsc ,
                                       GeneXus.Programs.wwpbaseobjects.SdtWWPGridState AV10GridState ,
                                       bool AV27DynamicFiltersIgnoreFirst ,
                                       bool AV26DynamicFiltersRemoving ,
                                       int A180MonCod ,
                                       DateTime Gx_date )
      {
         initialize_formulas( ) ;
         GxWebStd.set_html_headers( context, 0, "", "");
         /* Execute user event: Refresh */
         E321W2 ();
         GRID_nCurrentRecord = 0;
         RF1W2( ) ;
         GXKey = Crypto.GetSiteKey( );
         send_integrity_footer_hashes( ) ;
         GXKey = Crypto.GetSiteKey( );
         /* End function gxgrGrid_refresh */
      }

      protected void send_integrity_hashes( )
      {
         GxWebStd.gx_hidden_field( context, "gxhash_TIPMONCOD", GetSecureSignedToken( "", context.localUtil.Format( (decimal)(A307TipMonCod), "ZZZZZ9"), context));
         GxWebStd.gx_hidden_field( context, "TIPMONCOD", StringUtil.LTrim( StringUtil.NToC( (decimal)(A307TipMonCod), 6, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "gxhash_TIPFECH", GetSecureSignedToken( "", A308TipFech, context));
         GxWebStd.gx_hidden_field( context, "TIPFECH", context.localUtil.Format(A308TipFech, "99/99/99"));
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
         RF1W2( ) ;
         if ( isFullAjaxMode( ) )
         {
            send_integrity_footer_hashes( ) ;
         }
      }

      protected void initialize_formulas( )
      {
         /* GeneXus formulas. */
         Gx_date = DateTimeUtil.Today( context);
         AV64Pgmname = "Configuracion.TipoCambioWW";
         context.Gx_err = 0;
      }

      protected void RF1W2( )
      {
         initialize_formulas( ) ;
         clear_multi_value_controls( ) ;
         if ( isAjaxCallMode( ) )
         {
            GridContainer.ClearRows();
         }
         wbStart = 121;
         /* Execute user event: Refresh */
         E321W2 ();
         nGXsfl_121_idx = 1;
         sGXsfl_121_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_121_idx), 4, 0), 4, "0");
         SubsflControlProps_1212( ) ;
         bGXsfl_121_Refreshing = true;
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
            SubsflControlProps_1212( ) ;
            GXPagingFrom2 = (int)(((subGrid_Rows==0) ? 0 : GRID_nFirstRecordOnPage));
            GXPagingTo2 = ((subGrid_Rows==0) ? 10000 : subGrid_fnc_Recordsperpage( )+1);
            pr_default.dynParam(0, new Object[]{ new Object[]{
                                                 AV65Configuracion_tipocambiowwds_1_dynamicfiltersselector1 ,
                                                 AV66Configuracion_tipocambiowwds_2_dynamicfiltersoperator1 ,
                                                 AV67Configuracion_tipocambiowwds_3_mondsc1 ,
                                                 AV68Configuracion_tipocambiowwds_4_tipfech1 ,
                                                 AV69Configuracion_tipocambiowwds_5_tipfech_to1 ,
                                                 AV70Configuracion_tipocambiowwds_6_dynamicfiltersenabled2 ,
                                                 AV71Configuracion_tipocambiowwds_7_dynamicfiltersselector2 ,
                                                 AV72Configuracion_tipocambiowwds_8_dynamicfiltersoperator2 ,
                                                 AV73Configuracion_tipocambiowwds_9_mondsc2 ,
                                                 AV74Configuracion_tipocambiowwds_10_tipfech2 ,
                                                 AV75Configuracion_tipocambiowwds_11_tipfech_to2 ,
                                                 AV76Configuracion_tipocambiowwds_12_dynamicfiltersenabled3 ,
                                                 AV77Configuracion_tipocambiowwds_13_dynamicfiltersselector3 ,
                                                 AV78Configuracion_tipocambiowwds_14_dynamicfiltersoperator3 ,
                                                 AV79Configuracion_tipocambiowwds_15_mondsc3 ,
                                                 AV80Configuracion_tipocambiowwds_16_tipfech3 ,
                                                 AV81Configuracion_tipocambiowwds_17_tipfech_to3 ,
                                                 AV83Configuracion_tipocambiowwds_19_tfmondsc_sel ,
                                                 AV82Configuracion_tipocambiowwds_18_tfmondsc ,
                                                 AV84Configuracion_tipocambiowwds_20_tftipfech ,
                                                 AV85Configuracion_tipocambiowwds_21_tftipfech_to ,
                                                 AV86Configuracion_tipocambiowwds_22_tftipcompra ,
                                                 AV87Configuracion_tipocambiowwds_23_tftipcompra_to ,
                                                 AV88Configuracion_tipocambiowwds_24_tftipventa ,
                                                 AV89Configuracion_tipocambiowwds_25_tftipventa_to ,
                                                 A1234MonDsc ,
                                                 A308TipFech ,
                                                 A1907TipCompra ,
                                                 A1920TipVenta ,
                                                 AV13OrderedBy ,
                                                 AV14OrderedDsc } ,
                                                 new int[]{
                                                 TypeConstants.SHORT, TypeConstants.DATE, TypeConstants.DATE, TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.DATE, TypeConstants.DATE, TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.DATE,
                                                 TypeConstants.DATE, TypeConstants.DATE, TypeConstants.DATE, TypeConstants.DECIMAL, TypeConstants.DECIMAL, TypeConstants.DECIMAL, TypeConstants.DECIMAL, TypeConstants.BOOLEAN, TypeConstants.DATE, TypeConstants.DECIMAL,
                                                 TypeConstants.DECIMAL, TypeConstants.SHORT, TypeConstants.BOOLEAN
                                                 }
            });
            lV67Configuracion_tipocambiowwds_3_mondsc1 = StringUtil.PadR( StringUtil.RTrim( AV67Configuracion_tipocambiowwds_3_mondsc1), 100, "%");
            lV67Configuracion_tipocambiowwds_3_mondsc1 = StringUtil.PadR( StringUtil.RTrim( AV67Configuracion_tipocambiowwds_3_mondsc1), 100, "%");
            lV73Configuracion_tipocambiowwds_9_mondsc2 = StringUtil.PadR( StringUtil.RTrim( AV73Configuracion_tipocambiowwds_9_mondsc2), 100, "%");
            lV73Configuracion_tipocambiowwds_9_mondsc2 = StringUtil.PadR( StringUtil.RTrim( AV73Configuracion_tipocambiowwds_9_mondsc2), 100, "%");
            lV79Configuracion_tipocambiowwds_15_mondsc3 = StringUtil.PadR( StringUtil.RTrim( AV79Configuracion_tipocambiowwds_15_mondsc3), 100, "%");
            lV79Configuracion_tipocambiowwds_15_mondsc3 = StringUtil.PadR( StringUtil.RTrim( AV79Configuracion_tipocambiowwds_15_mondsc3), 100, "%");
            lV82Configuracion_tipocambiowwds_18_tfmondsc = StringUtil.PadR( StringUtil.RTrim( AV82Configuracion_tipocambiowwds_18_tfmondsc), 100, "%");
            /* Using cursor H001W2 */
            pr_default.execute(0, new Object[] {lV67Configuracion_tipocambiowwds_3_mondsc1, lV67Configuracion_tipocambiowwds_3_mondsc1, AV68Configuracion_tipocambiowwds_4_tipfech1, AV68Configuracion_tipocambiowwds_4_tipfech1, AV68Configuracion_tipocambiowwds_4_tipfech1, AV68Configuracion_tipocambiowwds_4_tipfech1, AV69Configuracion_tipocambiowwds_5_tipfech_to1, lV73Configuracion_tipocambiowwds_9_mondsc2, lV73Configuracion_tipocambiowwds_9_mondsc2, AV74Configuracion_tipocambiowwds_10_tipfech2, AV74Configuracion_tipocambiowwds_10_tipfech2, AV74Configuracion_tipocambiowwds_10_tipfech2, AV74Configuracion_tipocambiowwds_10_tipfech2, AV75Configuracion_tipocambiowwds_11_tipfech_to2, lV79Configuracion_tipocambiowwds_15_mondsc3, lV79Configuracion_tipocambiowwds_15_mondsc3, AV80Configuracion_tipocambiowwds_16_tipfech3, AV80Configuracion_tipocambiowwds_16_tipfech3, AV80Configuracion_tipocambiowwds_16_tipfech3, AV80Configuracion_tipocambiowwds_16_tipfech3, AV81Configuracion_tipocambiowwds_17_tipfech_to3, lV82Configuracion_tipocambiowwds_18_tfmondsc, AV83Configuracion_tipocambiowwds_19_tfmondsc_sel, AV84Configuracion_tipocambiowwds_20_tftipfech, AV85Configuracion_tipocambiowwds_21_tftipfech_to, AV86Configuracion_tipocambiowwds_22_tftipcompra, AV87Configuracion_tipocambiowwds_23_tftipcompra_to, AV88Configuracion_tipocambiowwds_24_tftipventa, AV89Configuracion_tipocambiowwds_25_tftipventa_to, GXPagingFrom2, GXPagingTo2, GXPagingTo2});
            nGXsfl_121_idx = 1;
            sGXsfl_121_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_121_idx), 4, 0), 4, "0");
            SubsflControlProps_1212( ) ;
            while ( ( (pr_default.getStatus(0) != 101) ) && ( ( ( subGrid_Rows == 0 ) || ( GRID_nCurrentRecord < subGrid_fnc_Recordsperpage( ) ) ) ) )
            {
               A1920TipVenta = H001W2_A1920TipVenta[0];
               A1907TipCompra = H001W2_A1907TipCompra[0];
               A308TipFech = H001W2_A308TipFech[0];
               A1234MonDsc = H001W2_A1234MonDsc[0];
               n1234MonDsc = H001W2_n1234MonDsc[0];
               A307TipMonCod = H001W2_A307TipMonCod[0];
               A1234MonDsc = H001W2_A1234MonDsc[0];
               n1234MonDsc = H001W2_n1234MonDsc[0];
               E331W2 ();
               pr_default.readNext(0);
            }
            GRID_nEOF = (short)(((pr_default.getStatus(0) == 101) ? 1 : 0));
            GxWebStd.gx_hidden_field( context, "GRID_nEOF", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRID_nEOF), 1, 0, ".", "")));
            pr_default.close(0);
            wbEnd = 121;
            WB1W0( ) ;
         }
         bGXsfl_121_Refreshing = true;
      }

      protected void send_integrity_lvl_hashes1W2( )
      {
         GxWebStd.gx_hidden_field( context, "vPGMNAME", StringUtil.RTrim( AV64Pgmname));
         GxWebStd.gx_hidden_field( context, "gxhash_vPGMNAME", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( AV64Pgmname, "")), context));
         GxWebStd.gx_hidden_field( context, "vTODAY", context.localUtil.DToC( Gx_date, 0, "/"));
         GxWebStd.gx_hidden_field( context, "gxhash_vTODAY", GetSecureSignedToken( "", Gx_date, context));
         GxWebStd.gx_hidden_field( context, "gxhash_TIPMONCOD"+"_"+sGXsfl_121_idx, GetSecureSignedToken( sGXsfl_121_idx, context.localUtil.Format( (decimal)(A307TipMonCod), "ZZZZZ9"), context));
         GxWebStd.gx_hidden_field( context, "gxhash_TIPFECH"+"_"+sGXsfl_121_idx, GetSecureSignedToken( sGXsfl_121_idx, A308TipFech, context));
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
         AV65Configuracion_tipocambiowwds_1_dynamicfiltersselector1 = AV15DynamicFiltersSelector1;
         AV66Configuracion_tipocambiowwds_2_dynamicfiltersoperator1 = AV16DynamicFiltersOperator1;
         AV67Configuracion_tipocambiowwds_3_mondsc1 = AV50MonDsc1;
         AV68Configuracion_tipocambiowwds_4_tipfech1 = AV51TipFech1;
         AV69Configuracion_tipocambiowwds_5_tipfech_to1 = AV52TipFech_To1;
         AV70Configuracion_tipocambiowwds_6_dynamicfiltersenabled2 = AV18DynamicFiltersEnabled2;
         AV71Configuracion_tipocambiowwds_7_dynamicfiltersselector2 = AV19DynamicFiltersSelector2;
         AV72Configuracion_tipocambiowwds_8_dynamicfiltersoperator2 = AV20DynamicFiltersOperator2;
         AV73Configuracion_tipocambiowwds_9_mondsc2 = AV53MonDsc2;
         AV74Configuracion_tipocambiowwds_10_tipfech2 = AV54TipFech2;
         AV75Configuracion_tipocambiowwds_11_tipfech_to2 = AV55TipFech_To2;
         AV76Configuracion_tipocambiowwds_12_dynamicfiltersenabled3 = AV22DynamicFiltersEnabled3;
         AV77Configuracion_tipocambiowwds_13_dynamicfiltersselector3 = AV23DynamicFiltersSelector3;
         AV78Configuracion_tipocambiowwds_14_dynamicfiltersoperator3 = AV24DynamicFiltersOperator3;
         AV79Configuracion_tipocambiowwds_15_mondsc3 = AV56MonDsc3;
         AV80Configuracion_tipocambiowwds_16_tipfech3 = AV57TipFech3;
         AV81Configuracion_tipocambiowwds_17_tipfech_to3 = AV58TipFech_To3;
         AV82Configuracion_tipocambiowwds_18_tfmondsc = AV48TFMonDsc;
         AV83Configuracion_tipocambiowwds_19_tfmondsc_sel = AV49TFMonDsc_Sel;
         AV84Configuracion_tipocambiowwds_20_tftipfech = AV31TFTipFech;
         AV85Configuracion_tipocambiowwds_21_tftipfech_to = AV32TFTipFech_To;
         AV86Configuracion_tipocambiowwds_22_tftipcompra = AV36TFTipCompra;
         AV87Configuracion_tipocambiowwds_23_tftipcompra_to = AV37TFTipCompra_To;
         AV88Configuracion_tipocambiowwds_24_tftipventa = AV38TFTipVenta;
         AV89Configuracion_tipocambiowwds_25_tftipventa_to = AV39TFTipVenta_To;
         pr_default.dynParam(1, new Object[]{ new Object[]{
                                              AV65Configuracion_tipocambiowwds_1_dynamicfiltersselector1 ,
                                              AV66Configuracion_tipocambiowwds_2_dynamicfiltersoperator1 ,
                                              AV67Configuracion_tipocambiowwds_3_mondsc1 ,
                                              AV68Configuracion_tipocambiowwds_4_tipfech1 ,
                                              AV69Configuracion_tipocambiowwds_5_tipfech_to1 ,
                                              AV70Configuracion_tipocambiowwds_6_dynamicfiltersenabled2 ,
                                              AV71Configuracion_tipocambiowwds_7_dynamicfiltersselector2 ,
                                              AV72Configuracion_tipocambiowwds_8_dynamicfiltersoperator2 ,
                                              AV73Configuracion_tipocambiowwds_9_mondsc2 ,
                                              AV74Configuracion_tipocambiowwds_10_tipfech2 ,
                                              AV75Configuracion_tipocambiowwds_11_tipfech_to2 ,
                                              AV76Configuracion_tipocambiowwds_12_dynamicfiltersenabled3 ,
                                              AV77Configuracion_tipocambiowwds_13_dynamicfiltersselector3 ,
                                              AV78Configuracion_tipocambiowwds_14_dynamicfiltersoperator3 ,
                                              AV79Configuracion_tipocambiowwds_15_mondsc3 ,
                                              AV80Configuracion_tipocambiowwds_16_tipfech3 ,
                                              AV81Configuracion_tipocambiowwds_17_tipfech_to3 ,
                                              AV83Configuracion_tipocambiowwds_19_tfmondsc_sel ,
                                              AV82Configuracion_tipocambiowwds_18_tfmondsc ,
                                              AV84Configuracion_tipocambiowwds_20_tftipfech ,
                                              AV85Configuracion_tipocambiowwds_21_tftipfech_to ,
                                              AV86Configuracion_tipocambiowwds_22_tftipcompra ,
                                              AV87Configuracion_tipocambiowwds_23_tftipcompra_to ,
                                              AV88Configuracion_tipocambiowwds_24_tftipventa ,
                                              AV89Configuracion_tipocambiowwds_25_tftipventa_to ,
                                              A1234MonDsc ,
                                              A308TipFech ,
                                              A1907TipCompra ,
                                              A1920TipVenta ,
                                              AV13OrderedBy ,
                                              AV14OrderedDsc } ,
                                              new int[]{
                                              TypeConstants.SHORT, TypeConstants.DATE, TypeConstants.DATE, TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.DATE, TypeConstants.DATE, TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.DATE,
                                              TypeConstants.DATE, TypeConstants.DATE, TypeConstants.DATE, TypeConstants.DECIMAL, TypeConstants.DECIMAL, TypeConstants.DECIMAL, TypeConstants.DECIMAL, TypeConstants.BOOLEAN, TypeConstants.DATE, TypeConstants.DECIMAL,
                                              TypeConstants.DECIMAL, TypeConstants.SHORT, TypeConstants.BOOLEAN
                                              }
         });
         lV67Configuracion_tipocambiowwds_3_mondsc1 = StringUtil.PadR( StringUtil.RTrim( AV67Configuracion_tipocambiowwds_3_mondsc1), 100, "%");
         lV67Configuracion_tipocambiowwds_3_mondsc1 = StringUtil.PadR( StringUtil.RTrim( AV67Configuracion_tipocambiowwds_3_mondsc1), 100, "%");
         lV73Configuracion_tipocambiowwds_9_mondsc2 = StringUtil.PadR( StringUtil.RTrim( AV73Configuracion_tipocambiowwds_9_mondsc2), 100, "%");
         lV73Configuracion_tipocambiowwds_9_mondsc2 = StringUtil.PadR( StringUtil.RTrim( AV73Configuracion_tipocambiowwds_9_mondsc2), 100, "%");
         lV79Configuracion_tipocambiowwds_15_mondsc3 = StringUtil.PadR( StringUtil.RTrim( AV79Configuracion_tipocambiowwds_15_mondsc3), 100, "%");
         lV79Configuracion_tipocambiowwds_15_mondsc3 = StringUtil.PadR( StringUtil.RTrim( AV79Configuracion_tipocambiowwds_15_mondsc3), 100, "%");
         lV82Configuracion_tipocambiowwds_18_tfmondsc = StringUtil.PadR( StringUtil.RTrim( AV82Configuracion_tipocambiowwds_18_tfmondsc), 100, "%");
         /* Using cursor H001W3 */
         pr_default.execute(1, new Object[] {lV67Configuracion_tipocambiowwds_3_mondsc1, lV67Configuracion_tipocambiowwds_3_mondsc1, AV68Configuracion_tipocambiowwds_4_tipfech1, AV68Configuracion_tipocambiowwds_4_tipfech1, AV68Configuracion_tipocambiowwds_4_tipfech1, AV68Configuracion_tipocambiowwds_4_tipfech1, AV69Configuracion_tipocambiowwds_5_tipfech_to1, lV73Configuracion_tipocambiowwds_9_mondsc2, lV73Configuracion_tipocambiowwds_9_mondsc2, AV74Configuracion_tipocambiowwds_10_tipfech2, AV74Configuracion_tipocambiowwds_10_tipfech2, AV74Configuracion_tipocambiowwds_10_tipfech2, AV74Configuracion_tipocambiowwds_10_tipfech2, AV75Configuracion_tipocambiowwds_11_tipfech_to2, lV79Configuracion_tipocambiowwds_15_mondsc3, lV79Configuracion_tipocambiowwds_15_mondsc3, AV80Configuracion_tipocambiowwds_16_tipfech3, AV80Configuracion_tipocambiowwds_16_tipfech3, AV80Configuracion_tipocambiowwds_16_tipfech3, AV80Configuracion_tipocambiowwds_16_tipfech3, AV81Configuracion_tipocambiowwds_17_tipfech_to3, lV82Configuracion_tipocambiowwds_18_tfmondsc, AV83Configuracion_tipocambiowwds_19_tfmondsc_sel, AV84Configuracion_tipocambiowwds_20_tftipfech, AV85Configuracion_tipocambiowwds_21_tftipfech_to, AV86Configuracion_tipocambiowwds_22_tftipcompra, AV87Configuracion_tipocambiowwds_23_tftipcompra_to, AV88Configuracion_tipocambiowwds_24_tftipventa, AV89Configuracion_tipocambiowwds_25_tftipventa_to});
         GRID_nRecordCount = H001W3_AGRID_nRecordCount[0];
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
         AV65Configuracion_tipocambiowwds_1_dynamicfiltersselector1 = AV15DynamicFiltersSelector1;
         AV66Configuracion_tipocambiowwds_2_dynamicfiltersoperator1 = AV16DynamicFiltersOperator1;
         AV67Configuracion_tipocambiowwds_3_mondsc1 = AV50MonDsc1;
         AV68Configuracion_tipocambiowwds_4_tipfech1 = AV51TipFech1;
         AV69Configuracion_tipocambiowwds_5_tipfech_to1 = AV52TipFech_To1;
         AV70Configuracion_tipocambiowwds_6_dynamicfiltersenabled2 = AV18DynamicFiltersEnabled2;
         AV71Configuracion_tipocambiowwds_7_dynamicfiltersselector2 = AV19DynamicFiltersSelector2;
         AV72Configuracion_tipocambiowwds_8_dynamicfiltersoperator2 = AV20DynamicFiltersOperator2;
         AV73Configuracion_tipocambiowwds_9_mondsc2 = AV53MonDsc2;
         AV74Configuracion_tipocambiowwds_10_tipfech2 = AV54TipFech2;
         AV75Configuracion_tipocambiowwds_11_tipfech_to2 = AV55TipFech_To2;
         AV76Configuracion_tipocambiowwds_12_dynamicfiltersenabled3 = AV22DynamicFiltersEnabled3;
         AV77Configuracion_tipocambiowwds_13_dynamicfiltersselector3 = AV23DynamicFiltersSelector3;
         AV78Configuracion_tipocambiowwds_14_dynamicfiltersoperator3 = AV24DynamicFiltersOperator3;
         AV79Configuracion_tipocambiowwds_15_mondsc3 = AV56MonDsc3;
         AV80Configuracion_tipocambiowwds_16_tipfech3 = AV57TipFech3;
         AV81Configuracion_tipocambiowwds_17_tipfech_to3 = AV58TipFech_To3;
         AV82Configuracion_tipocambiowwds_18_tfmondsc = AV48TFMonDsc;
         AV83Configuracion_tipocambiowwds_19_tfmondsc_sel = AV49TFMonDsc_Sel;
         AV84Configuracion_tipocambiowwds_20_tftipfech = AV31TFTipFech;
         AV85Configuracion_tipocambiowwds_21_tftipfech_to = AV32TFTipFech_To;
         AV86Configuracion_tipocambiowwds_22_tftipcompra = AV36TFTipCompra;
         AV87Configuracion_tipocambiowwds_23_tftipcompra_to = AV37TFTipCompra_To;
         AV88Configuracion_tipocambiowwds_24_tftipventa = AV38TFTipVenta;
         AV89Configuracion_tipocambiowwds_25_tftipventa_to = AV39TFTipVenta_To;
         GRID_nFirstRecordOnPage = 0;
         GxWebStd.gx_hidden_field( context, "GRID_nFirstRecordOnPage", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRID_nFirstRecordOnPage), 15, 0, ".", "")));
         if ( isFullAjaxMode( ) )
         {
            gxgrGrid_refresh( subGrid_Rows, AV15DynamicFiltersSelector1, AV16DynamicFiltersOperator1, AV50MonDsc1, AV19DynamicFiltersSelector2, AV20DynamicFiltersOperator2, AV53MonDsc2, AV23DynamicFiltersSelector3, AV24DynamicFiltersOperator3, AV56MonDsc3, AV51TipFech1, AV54TipFech2, AV57TipFech3, AV18DynamicFiltersEnabled2, AV22DynamicFiltersEnabled3, AV64Pgmname, AV52TipFech_To1, AV55TipFech_To2, AV58TipFech_To3, AV48TFMonDsc, AV49TFMonDsc_Sel, AV31TFTipFech, AV32TFTipFech_To, AV36TFTipCompra, AV37TFTipCompra_To, AV38TFTipVenta, AV39TFTipVenta_To, AV13OrderedBy, AV14OrderedDsc, AV10GridState, AV27DynamicFiltersIgnoreFirst, AV26DynamicFiltersRemoving, A180MonCod, Gx_date) ;
         }
         send_integrity_footer_hashes( ) ;
         return 0 ;
      }

      protected short subgrid_nextpage( )
      {
         AV65Configuracion_tipocambiowwds_1_dynamicfiltersselector1 = AV15DynamicFiltersSelector1;
         AV66Configuracion_tipocambiowwds_2_dynamicfiltersoperator1 = AV16DynamicFiltersOperator1;
         AV67Configuracion_tipocambiowwds_3_mondsc1 = AV50MonDsc1;
         AV68Configuracion_tipocambiowwds_4_tipfech1 = AV51TipFech1;
         AV69Configuracion_tipocambiowwds_5_tipfech_to1 = AV52TipFech_To1;
         AV70Configuracion_tipocambiowwds_6_dynamicfiltersenabled2 = AV18DynamicFiltersEnabled2;
         AV71Configuracion_tipocambiowwds_7_dynamicfiltersselector2 = AV19DynamicFiltersSelector2;
         AV72Configuracion_tipocambiowwds_8_dynamicfiltersoperator2 = AV20DynamicFiltersOperator2;
         AV73Configuracion_tipocambiowwds_9_mondsc2 = AV53MonDsc2;
         AV74Configuracion_tipocambiowwds_10_tipfech2 = AV54TipFech2;
         AV75Configuracion_tipocambiowwds_11_tipfech_to2 = AV55TipFech_To2;
         AV76Configuracion_tipocambiowwds_12_dynamicfiltersenabled3 = AV22DynamicFiltersEnabled3;
         AV77Configuracion_tipocambiowwds_13_dynamicfiltersselector3 = AV23DynamicFiltersSelector3;
         AV78Configuracion_tipocambiowwds_14_dynamicfiltersoperator3 = AV24DynamicFiltersOperator3;
         AV79Configuracion_tipocambiowwds_15_mondsc3 = AV56MonDsc3;
         AV80Configuracion_tipocambiowwds_16_tipfech3 = AV57TipFech3;
         AV81Configuracion_tipocambiowwds_17_tipfech_to3 = AV58TipFech_To3;
         AV82Configuracion_tipocambiowwds_18_tfmondsc = AV48TFMonDsc;
         AV83Configuracion_tipocambiowwds_19_tfmondsc_sel = AV49TFMonDsc_Sel;
         AV84Configuracion_tipocambiowwds_20_tftipfech = AV31TFTipFech;
         AV85Configuracion_tipocambiowwds_21_tftipfech_to = AV32TFTipFech_To;
         AV86Configuracion_tipocambiowwds_22_tftipcompra = AV36TFTipCompra;
         AV87Configuracion_tipocambiowwds_23_tftipcompra_to = AV37TFTipCompra_To;
         AV88Configuracion_tipocambiowwds_24_tftipventa = AV38TFTipVenta;
         AV89Configuracion_tipocambiowwds_25_tftipventa_to = AV39TFTipVenta_To;
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
            gxgrGrid_refresh( subGrid_Rows, AV15DynamicFiltersSelector1, AV16DynamicFiltersOperator1, AV50MonDsc1, AV19DynamicFiltersSelector2, AV20DynamicFiltersOperator2, AV53MonDsc2, AV23DynamicFiltersSelector3, AV24DynamicFiltersOperator3, AV56MonDsc3, AV51TipFech1, AV54TipFech2, AV57TipFech3, AV18DynamicFiltersEnabled2, AV22DynamicFiltersEnabled3, AV64Pgmname, AV52TipFech_To1, AV55TipFech_To2, AV58TipFech_To3, AV48TFMonDsc, AV49TFMonDsc_Sel, AV31TFTipFech, AV32TFTipFech_To, AV36TFTipCompra, AV37TFTipCompra_To, AV38TFTipVenta, AV39TFTipVenta_To, AV13OrderedBy, AV14OrderedDsc, AV10GridState, AV27DynamicFiltersIgnoreFirst, AV26DynamicFiltersRemoving, A180MonCod, Gx_date) ;
         }
         send_integrity_footer_hashes( ) ;
         return (short)(((GRID_nEOF==0) ? 0 : 2)) ;
      }

      protected short subgrid_previouspage( )
      {
         AV65Configuracion_tipocambiowwds_1_dynamicfiltersselector1 = AV15DynamicFiltersSelector1;
         AV66Configuracion_tipocambiowwds_2_dynamicfiltersoperator1 = AV16DynamicFiltersOperator1;
         AV67Configuracion_tipocambiowwds_3_mondsc1 = AV50MonDsc1;
         AV68Configuracion_tipocambiowwds_4_tipfech1 = AV51TipFech1;
         AV69Configuracion_tipocambiowwds_5_tipfech_to1 = AV52TipFech_To1;
         AV70Configuracion_tipocambiowwds_6_dynamicfiltersenabled2 = AV18DynamicFiltersEnabled2;
         AV71Configuracion_tipocambiowwds_7_dynamicfiltersselector2 = AV19DynamicFiltersSelector2;
         AV72Configuracion_tipocambiowwds_8_dynamicfiltersoperator2 = AV20DynamicFiltersOperator2;
         AV73Configuracion_tipocambiowwds_9_mondsc2 = AV53MonDsc2;
         AV74Configuracion_tipocambiowwds_10_tipfech2 = AV54TipFech2;
         AV75Configuracion_tipocambiowwds_11_tipfech_to2 = AV55TipFech_To2;
         AV76Configuracion_tipocambiowwds_12_dynamicfiltersenabled3 = AV22DynamicFiltersEnabled3;
         AV77Configuracion_tipocambiowwds_13_dynamicfiltersselector3 = AV23DynamicFiltersSelector3;
         AV78Configuracion_tipocambiowwds_14_dynamicfiltersoperator3 = AV24DynamicFiltersOperator3;
         AV79Configuracion_tipocambiowwds_15_mondsc3 = AV56MonDsc3;
         AV80Configuracion_tipocambiowwds_16_tipfech3 = AV57TipFech3;
         AV81Configuracion_tipocambiowwds_17_tipfech_to3 = AV58TipFech_To3;
         AV82Configuracion_tipocambiowwds_18_tfmondsc = AV48TFMonDsc;
         AV83Configuracion_tipocambiowwds_19_tfmondsc_sel = AV49TFMonDsc_Sel;
         AV84Configuracion_tipocambiowwds_20_tftipfech = AV31TFTipFech;
         AV85Configuracion_tipocambiowwds_21_tftipfech_to = AV32TFTipFech_To;
         AV86Configuracion_tipocambiowwds_22_tftipcompra = AV36TFTipCompra;
         AV87Configuracion_tipocambiowwds_23_tftipcompra_to = AV37TFTipCompra_To;
         AV88Configuracion_tipocambiowwds_24_tftipventa = AV38TFTipVenta;
         AV89Configuracion_tipocambiowwds_25_tftipventa_to = AV39TFTipVenta_To;
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
            gxgrGrid_refresh( subGrid_Rows, AV15DynamicFiltersSelector1, AV16DynamicFiltersOperator1, AV50MonDsc1, AV19DynamicFiltersSelector2, AV20DynamicFiltersOperator2, AV53MonDsc2, AV23DynamicFiltersSelector3, AV24DynamicFiltersOperator3, AV56MonDsc3, AV51TipFech1, AV54TipFech2, AV57TipFech3, AV18DynamicFiltersEnabled2, AV22DynamicFiltersEnabled3, AV64Pgmname, AV52TipFech_To1, AV55TipFech_To2, AV58TipFech_To3, AV48TFMonDsc, AV49TFMonDsc_Sel, AV31TFTipFech, AV32TFTipFech_To, AV36TFTipCompra, AV37TFTipCompra_To, AV38TFTipVenta, AV39TFTipVenta_To, AV13OrderedBy, AV14OrderedDsc, AV10GridState, AV27DynamicFiltersIgnoreFirst, AV26DynamicFiltersRemoving, A180MonCod, Gx_date) ;
         }
         send_integrity_footer_hashes( ) ;
         return 0 ;
      }

      protected short subgrid_lastpage( )
      {
         AV65Configuracion_tipocambiowwds_1_dynamicfiltersselector1 = AV15DynamicFiltersSelector1;
         AV66Configuracion_tipocambiowwds_2_dynamicfiltersoperator1 = AV16DynamicFiltersOperator1;
         AV67Configuracion_tipocambiowwds_3_mondsc1 = AV50MonDsc1;
         AV68Configuracion_tipocambiowwds_4_tipfech1 = AV51TipFech1;
         AV69Configuracion_tipocambiowwds_5_tipfech_to1 = AV52TipFech_To1;
         AV70Configuracion_tipocambiowwds_6_dynamicfiltersenabled2 = AV18DynamicFiltersEnabled2;
         AV71Configuracion_tipocambiowwds_7_dynamicfiltersselector2 = AV19DynamicFiltersSelector2;
         AV72Configuracion_tipocambiowwds_8_dynamicfiltersoperator2 = AV20DynamicFiltersOperator2;
         AV73Configuracion_tipocambiowwds_9_mondsc2 = AV53MonDsc2;
         AV74Configuracion_tipocambiowwds_10_tipfech2 = AV54TipFech2;
         AV75Configuracion_tipocambiowwds_11_tipfech_to2 = AV55TipFech_To2;
         AV76Configuracion_tipocambiowwds_12_dynamicfiltersenabled3 = AV22DynamicFiltersEnabled3;
         AV77Configuracion_tipocambiowwds_13_dynamicfiltersselector3 = AV23DynamicFiltersSelector3;
         AV78Configuracion_tipocambiowwds_14_dynamicfiltersoperator3 = AV24DynamicFiltersOperator3;
         AV79Configuracion_tipocambiowwds_15_mondsc3 = AV56MonDsc3;
         AV80Configuracion_tipocambiowwds_16_tipfech3 = AV57TipFech3;
         AV81Configuracion_tipocambiowwds_17_tipfech_to3 = AV58TipFech_To3;
         AV82Configuracion_tipocambiowwds_18_tfmondsc = AV48TFMonDsc;
         AV83Configuracion_tipocambiowwds_19_tfmondsc_sel = AV49TFMonDsc_Sel;
         AV84Configuracion_tipocambiowwds_20_tftipfech = AV31TFTipFech;
         AV85Configuracion_tipocambiowwds_21_tftipfech_to = AV32TFTipFech_To;
         AV86Configuracion_tipocambiowwds_22_tftipcompra = AV36TFTipCompra;
         AV87Configuracion_tipocambiowwds_23_tftipcompra_to = AV37TFTipCompra_To;
         AV88Configuracion_tipocambiowwds_24_tftipventa = AV38TFTipVenta;
         AV89Configuracion_tipocambiowwds_25_tftipventa_to = AV39TFTipVenta_To;
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
            gxgrGrid_refresh( subGrid_Rows, AV15DynamicFiltersSelector1, AV16DynamicFiltersOperator1, AV50MonDsc1, AV19DynamicFiltersSelector2, AV20DynamicFiltersOperator2, AV53MonDsc2, AV23DynamicFiltersSelector3, AV24DynamicFiltersOperator3, AV56MonDsc3, AV51TipFech1, AV54TipFech2, AV57TipFech3, AV18DynamicFiltersEnabled2, AV22DynamicFiltersEnabled3, AV64Pgmname, AV52TipFech_To1, AV55TipFech_To2, AV58TipFech_To3, AV48TFMonDsc, AV49TFMonDsc_Sel, AV31TFTipFech, AV32TFTipFech_To, AV36TFTipCompra, AV37TFTipCompra_To, AV38TFTipVenta, AV39TFTipVenta_To, AV13OrderedBy, AV14OrderedDsc, AV10GridState, AV27DynamicFiltersIgnoreFirst, AV26DynamicFiltersRemoving, A180MonCod, Gx_date) ;
         }
         send_integrity_footer_hashes( ) ;
         return 0 ;
      }

      protected int subgrid_gotopage( int nPageNo )
      {
         AV65Configuracion_tipocambiowwds_1_dynamicfiltersselector1 = AV15DynamicFiltersSelector1;
         AV66Configuracion_tipocambiowwds_2_dynamicfiltersoperator1 = AV16DynamicFiltersOperator1;
         AV67Configuracion_tipocambiowwds_3_mondsc1 = AV50MonDsc1;
         AV68Configuracion_tipocambiowwds_4_tipfech1 = AV51TipFech1;
         AV69Configuracion_tipocambiowwds_5_tipfech_to1 = AV52TipFech_To1;
         AV70Configuracion_tipocambiowwds_6_dynamicfiltersenabled2 = AV18DynamicFiltersEnabled2;
         AV71Configuracion_tipocambiowwds_7_dynamicfiltersselector2 = AV19DynamicFiltersSelector2;
         AV72Configuracion_tipocambiowwds_8_dynamicfiltersoperator2 = AV20DynamicFiltersOperator2;
         AV73Configuracion_tipocambiowwds_9_mondsc2 = AV53MonDsc2;
         AV74Configuracion_tipocambiowwds_10_tipfech2 = AV54TipFech2;
         AV75Configuracion_tipocambiowwds_11_tipfech_to2 = AV55TipFech_To2;
         AV76Configuracion_tipocambiowwds_12_dynamicfiltersenabled3 = AV22DynamicFiltersEnabled3;
         AV77Configuracion_tipocambiowwds_13_dynamicfiltersselector3 = AV23DynamicFiltersSelector3;
         AV78Configuracion_tipocambiowwds_14_dynamicfiltersoperator3 = AV24DynamicFiltersOperator3;
         AV79Configuracion_tipocambiowwds_15_mondsc3 = AV56MonDsc3;
         AV80Configuracion_tipocambiowwds_16_tipfech3 = AV57TipFech3;
         AV81Configuracion_tipocambiowwds_17_tipfech_to3 = AV58TipFech_To3;
         AV82Configuracion_tipocambiowwds_18_tfmondsc = AV48TFMonDsc;
         AV83Configuracion_tipocambiowwds_19_tfmondsc_sel = AV49TFMonDsc_Sel;
         AV84Configuracion_tipocambiowwds_20_tftipfech = AV31TFTipFech;
         AV85Configuracion_tipocambiowwds_21_tftipfech_to = AV32TFTipFech_To;
         AV86Configuracion_tipocambiowwds_22_tftipcompra = AV36TFTipCompra;
         AV87Configuracion_tipocambiowwds_23_tftipcompra_to = AV37TFTipCompra_To;
         AV88Configuracion_tipocambiowwds_24_tftipventa = AV38TFTipVenta;
         AV89Configuracion_tipocambiowwds_25_tftipventa_to = AV39TFTipVenta_To;
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
            gxgrGrid_refresh( subGrid_Rows, AV15DynamicFiltersSelector1, AV16DynamicFiltersOperator1, AV50MonDsc1, AV19DynamicFiltersSelector2, AV20DynamicFiltersOperator2, AV53MonDsc2, AV23DynamicFiltersSelector3, AV24DynamicFiltersOperator3, AV56MonDsc3, AV51TipFech1, AV54TipFech2, AV57TipFech3, AV18DynamicFiltersEnabled2, AV22DynamicFiltersEnabled3, AV64Pgmname, AV52TipFech_To1, AV55TipFech_To2, AV58TipFech_To3, AV48TFMonDsc, AV49TFMonDsc_Sel, AV31TFTipFech, AV32TFTipFech_To, AV36TFTipCompra, AV37TFTipCompra_To, AV38TFTipVenta, AV39TFTipVenta_To, AV13OrderedBy, AV14OrderedDsc, AV10GridState, AV27DynamicFiltersIgnoreFirst, AV26DynamicFiltersRemoving, A180MonCod, Gx_date) ;
         }
         send_integrity_footer_hashes( ) ;
         return (int)(0) ;
      }

      protected void before_start_formulas( )
      {
         Gx_date = DateTimeUtil.Today( context);
         AV64Pgmname = "Configuracion.TipoCambioWW";
         context.Gx_err = 0;
         fix_multi_value_controls( ) ;
      }

      protected void STRUP1W0( )
      {
         /* Before Start, stand alone formulas. */
         before_start_formulas( ) ;
         /* Execute Start event if defined. */
         context.wbGlbDoneStart = 0;
         /* Execute user event: Start */
         E311W2 ();
         context.wbGlbDoneStart = 1;
         /* After Start, stand alone formulas. */
         if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
         {
            /* Read saved SDTs. */
            ajax_req_read_hidden_sdt(cgiGet( "vAGEXPORTDATA"), AV46AGExportData);
            ajax_req_read_hidden_sdt(cgiGet( "vDDO_TITLESETTINGSICONS"), AV40DDO_TitleSettingsIcons);
            /* Read saved values. */
            nRC_GXsfl_121 = (int)(context.localUtil.CToN( cgiGet( "nRC_GXsfl_121"), ".", ","));
            AV42GridCurrentPage = (long)(context.localUtil.CToN( cgiGet( "vGRIDCURRENTPAGE"), ".", ","));
            AV43GridPageCount = (long)(context.localUtil.CToN( cgiGet( "vGRIDPAGECOUNT"), ".", ","));
            AV44GridAppliedFilters = cgiGet( "vGRIDAPPLIEDFILTERS");
            AV51TipFech1 = context.localUtil.CToD( cgiGet( "vTIPFECH1"), 0);
            AV52TipFech_To1 = context.localUtil.CToD( cgiGet( "vTIPFECH_TO1"), 0);
            AV54TipFech2 = context.localUtil.CToD( cgiGet( "vTIPFECH2"), 0);
            AV55TipFech_To2 = context.localUtil.CToD( cgiGet( "vTIPFECH_TO2"), 0);
            AV57TipFech3 = context.localUtil.CToD( cgiGet( "vTIPFECH3"), 0);
            AV58TipFech_To3 = context.localUtil.CToD( cgiGet( "vTIPFECH_TO3"), 0);
            AV33DDO_TipFechAuxDate = context.localUtil.CToD( cgiGet( "vDDO_TIPFECHAUXDATE"), 0);
            AV34DDO_TipFechAuxDateTo = context.localUtil.CToD( cgiGet( "vDDO_TIPFECHAUXDATETO"), 0);
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
            Innewwindow_Target = cgiGet( "INNEWWINDOW_Target");
            Innewwindow_Fullscreen = StringUtil.StrToBool( cgiGet( "INNEWWINDOW_Fullscreen"));
            Innewwindow_Toolbar = StringUtil.StrToBool( cgiGet( "INNEWWINDOW_Toolbar"));
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
            AV50MonDsc1 = cgiGet( edtavMondsc1_Internalname);
            AssignAttri("", false, "AV50MonDsc1", AV50MonDsc1);
            AV59TipFech_RangeText1 = cgiGet( edtavTipfech_rangetext1_Internalname);
            AssignAttri("", false, "AV59TipFech_RangeText1", AV59TipFech_RangeText1);
            cmbavDynamicfiltersselector2.Name = cmbavDynamicfiltersselector2_Internalname;
            cmbavDynamicfiltersselector2.CurrentValue = cgiGet( cmbavDynamicfiltersselector2_Internalname);
            AV19DynamicFiltersSelector2 = cgiGet( cmbavDynamicfiltersselector2_Internalname);
            AssignAttri("", false, "AV19DynamicFiltersSelector2", AV19DynamicFiltersSelector2);
            cmbavDynamicfiltersoperator2.Name = cmbavDynamicfiltersoperator2_Internalname;
            cmbavDynamicfiltersoperator2.CurrentValue = cgiGet( cmbavDynamicfiltersoperator2_Internalname);
            AV20DynamicFiltersOperator2 = (short)(NumberUtil.Val( cgiGet( cmbavDynamicfiltersoperator2_Internalname), "."));
            AssignAttri("", false, "AV20DynamicFiltersOperator2", StringUtil.LTrimStr( (decimal)(AV20DynamicFiltersOperator2), 4, 0));
            AV53MonDsc2 = cgiGet( edtavMondsc2_Internalname);
            AssignAttri("", false, "AV53MonDsc2", AV53MonDsc2);
            AV60TipFech_RangeText2 = cgiGet( edtavTipfech_rangetext2_Internalname);
            AssignAttri("", false, "AV60TipFech_RangeText2", AV60TipFech_RangeText2);
            cmbavDynamicfiltersselector3.Name = cmbavDynamicfiltersselector3_Internalname;
            cmbavDynamicfiltersselector3.CurrentValue = cgiGet( cmbavDynamicfiltersselector3_Internalname);
            AV23DynamicFiltersSelector3 = cgiGet( cmbavDynamicfiltersselector3_Internalname);
            AssignAttri("", false, "AV23DynamicFiltersSelector3", AV23DynamicFiltersSelector3);
            cmbavDynamicfiltersoperator3.Name = cmbavDynamicfiltersoperator3_Internalname;
            cmbavDynamicfiltersoperator3.CurrentValue = cgiGet( cmbavDynamicfiltersoperator3_Internalname);
            AV24DynamicFiltersOperator3 = (short)(NumberUtil.Val( cgiGet( cmbavDynamicfiltersoperator3_Internalname), "."));
            AssignAttri("", false, "AV24DynamicFiltersOperator3", StringUtil.LTrimStr( (decimal)(AV24DynamicFiltersOperator3), 4, 0));
            AV56MonDsc3 = cgiGet( edtavMondsc3_Internalname);
            AssignAttri("", false, "AV56MonDsc3", AV56MonDsc3);
            AV61TipFech_RangeText3 = cgiGet( edtavTipfech_rangetext3_Internalname);
            AssignAttri("", false, "AV61TipFech_RangeText3", AV61TipFech_RangeText3);
            AV35DDO_TipFechAuxDateText = cgiGet( edtavDdo_tipfechauxdatetext_Internalname);
            AssignAttri("", false, "AV35DDO_TipFechAuxDateText", AV35DDO_TipFechAuxDateText);
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
            if ( StringUtil.StrCmp(cgiGet( "GXH_vMONDSC1"), AV50MonDsc1) != 0 )
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
            if ( StringUtil.StrCmp(cgiGet( "GXH_vMONDSC2"), AV53MonDsc2) != 0 )
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
            if ( StringUtil.StrCmp(cgiGet( "GXH_vMONDSC3"), AV56MonDsc3) != 0 )
            {
               GRID_nFirstRecordOnPage = 0;
            }
            if ( DateTimeUtil.ResetTime ( context.localUtil.CToD( cgiGet( "GXH_vTIPFECH1"), 2) ) != DateTimeUtil.ResetTime ( AV51TipFech1 ) )
            {
               GRID_nFirstRecordOnPage = 0;
            }
            if ( DateTimeUtil.ResetTime ( context.localUtil.CToD( cgiGet( "GXH_vTIPFECH2"), 2) ) != DateTimeUtil.ResetTime ( AV54TipFech2 ) )
            {
               GRID_nFirstRecordOnPage = 0;
            }
            if ( DateTimeUtil.ResetTime ( context.localUtil.CToD( cgiGet( "GXH_vTIPFECH3"), 2) ) != DateTimeUtil.ResetTime ( AV57TipFech3 ) )
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
         E311W2 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
      }

      protected void E311W2( )
      {
         /* Start Routine */
         returnInSub = false;
         this.executeUsercontrolMethod("", false, "TFTIPFECH_RANGEPICKERContainer", "Attach", "", new Object[] {(string)edtavDdo_tipfechauxdatetext_Internalname});
         subGrid_Rows = 10;
         GxWebStd.gx_hidden_field( context, "GRID_Rows", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid_Rows), 6, 0, ".", "")));
         Grid_empowerer_Gridinternalname = subGrid_Internalname;
         ucGrid_empowerer.SendProperty(context, "", false, Grid_empowerer_Internalname, "GridInternalName", Grid_empowerer_Gridinternalname);
         lblJsdynamicfilters_Caption = "";
         AssignProp("", false, lblJsdynamicfilters_Internalname, "Caption", lblJsdynamicfilters_Caption, true);
         this.executeUsercontrolMethod("", false, "TIPFECH_RANGEPICKER1Container", "Attach", "", new Object[] {(string)edtavTipfech_rangetext1_Internalname});
         AV15DynamicFiltersSelector1 = "MONDSC";
         AssignAttri("", false, "AV15DynamicFiltersSelector1", AV15DynamicFiltersSelector1);
         /* Execute user subroutine: 'ENABLEDYNAMICFILTERS1' */
         S112 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
         this.executeUsercontrolMethod("", false, "TIPFECH_RANGEPICKER2Container", "Attach", "", new Object[] {(string)edtavTipfech_rangetext2_Internalname});
         AV19DynamicFiltersSelector2 = "MONDSC";
         AssignAttri("", false, "AV19DynamicFiltersSelector2", AV19DynamicFiltersSelector2);
         /* Execute user subroutine: 'ENABLEDYNAMICFILTERS2' */
         S122 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
         this.executeUsercontrolMethod("", false, "TIPFECH_RANGEPICKER3Container", "Attach", "", new Object[] {(string)edtavTipfech_rangetext3_Internalname});
         AV23DynamicFiltersSelector3 = "MONDSC";
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
         AV46AGExportData = new GXBaseCollection<GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTDropDownOptionsData_Item>( context, "Item", "");
         AV47AGExportDataItem = new GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTDropDownOptionsData_Item(context);
         AV47AGExportDataItem.gxTpr_Title = "PDF";
         AV47AGExportDataItem.gxTpr_Icon = context.convertURL( (string)(context.GetImagePath( "776fb79c-a0a1-4302-b5e5-d773dbe1a297", "", context.GetTheme( ))));
         AV47AGExportDataItem.gxTpr_Eventkey = "ExportReport";
         AV47AGExportDataItem.gxTpr_Isdivider = false;
         AV46AGExportData.Add(AV47AGExportDataItem, 0);
         AV47AGExportDataItem = new GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTDropDownOptionsData_Item(context);
         AV47AGExportDataItem.gxTpr_Title = "Excel";
         AV47AGExportDataItem.gxTpr_Icon = context.convertURL( (string)(context.GetImagePath( "da69a816-fd11-445b-8aaf-1a2f7f1acc93", "", context.GetTheme( ))));
         AV47AGExportDataItem.gxTpr_Eventkey = "Export";
         AV47AGExportDataItem.gxTpr_Isdivider = false;
         AV46AGExportData.Add(AV47AGExportDataItem, 0);
         Ddo_grid_Gridinternalname = subGrid_Internalname;
         ucDdo_grid.SendProperty(context, "", false, Ddo_grid_Internalname, "GridInternalName", Ddo_grid_Gridinternalname);
         Form.Caption = "Tipos de Cambio";
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
         GXt_SdtDVB_SDTDropDownOptionsTitleSettingsIcons1 = AV40DDO_TitleSettingsIcons;
         new GeneXus.Programs.wwpbaseobjects.getwwptitlesettingsicons(context ).execute( out  GXt_SdtDVB_SDTDropDownOptionsTitleSettingsIcons1) ;
         AV40DDO_TitleSettingsIcons = GXt_SdtDVB_SDTDropDownOptionsTitleSettingsIcons1;
         Gridpaginationbar_Rowsperpageselectedvalue = subGrid_Rows;
         ucGridpaginationbar.SendProperty(context, "", false, Gridpaginationbar_Internalname, "RowsPerPageSelectedValue", StringUtil.LTrimStr( (decimal)(Gridpaginationbar_Rowsperpageselectedvalue), 9, 0));
      }

      protected void E321W2( )
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
         if ( StringUtil.StrCmp(AV15DynamicFiltersSelector1, "MONDSC") == 0 )
         {
            cmbavDynamicfiltersoperator1.addItem("0", "Comienza con", 0);
            cmbavDynamicfiltersoperator1.addItem("1", "Contiene", 0);
         }
         else if ( StringUtil.StrCmp(AV15DynamicFiltersSelector1, "TIPFECH") == 0 )
         {
            cmbavDynamicfiltersoperator1.addItem("0", "Pasado", 0);
            cmbavDynamicfiltersoperator1.addItem("1", "Hoy", 0);
            cmbavDynamicfiltersoperator1.addItem("2", "En el futuro", 0);
            cmbavDynamicfiltersoperator1.addItem("3", "Período", 0);
         }
         if ( AV18DynamicFiltersEnabled2 )
         {
            cmbavDynamicfiltersoperator2.removeAllItems();
            if ( StringUtil.StrCmp(AV19DynamicFiltersSelector2, "MONDSC") == 0 )
            {
               cmbavDynamicfiltersoperator2.addItem("0", "Comienza con", 0);
               cmbavDynamicfiltersoperator2.addItem("1", "Contiene", 0);
            }
            else if ( StringUtil.StrCmp(AV19DynamicFiltersSelector2, "TIPFECH") == 0 )
            {
               cmbavDynamicfiltersoperator2.addItem("0", "Pasado", 0);
               cmbavDynamicfiltersoperator2.addItem("1", "Hoy", 0);
               cmbavDynamicfiltersoperator2.addItem("2", "En el futuro", 0);
               cmbavDynamicfiltersoperator2.addItem("3", "Período", 0);
            }
            if ( AV22DynamicFiltersEnabled3 )
            {
               cmbavDynamicfiltersoperator3.removeAllItems();
               if ( StringUtil.StrCmp(AV23DynamicFiltersSelector3, "MONDSC") == 0 )
               {
                  cmbavDynamicfiltersoperator3.addItem("0", "Comienza con", 0);
                  cmbavDynamicfiltersoperator3.addItem("1", "Contiene", 0);
               }
               else if ( StringUtil.StrCmp(AV23DynamicFiltersSelector3, "TIPFECH") == 0 )
               {
                  cmbavDynamicfiltersoperator3.addItem("0", "Pasado", 0);
                  cmbavDynamicfiltersoperator3.addItem("1", "Hoy", 0);
                  cmbavDynamicfiltersoperator3.addItem("2", "En el futuro", 0);
                  cmbavDynamicfiltersoperator3.addItem("3", "Período", 0);
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
         AV42GridCurrentPage = subGrid_fnc_Currentpage( );
         AssignAttri("", false, "AV42GridCurrentPage", StringUtil.LTrimStr( (decimal)(AV42GridCurrentPage), 10, 0));
         AV43GridPageCount = subGrid_fnc_Pagecount( );
         AssignAttri("", false, "AV43GridPageCount", StringUtil.LTrimStr( (decimal)(AV43GridPageCount), 10, 0));
         GXt_char2 = AV44GridAppliedFilters;
         new GeneXus.Programs.wwpbaseobjects.wwp_getappliedfiltersdescription(context ).execute(  AV64Pgmname, out  GXt_char2) ;
         AV44GridAppliedFilters = GXt_char2;
         AssignAttri("", false, "AV44GridAppliedFilters", AV44GridAppliedFilters);
         AV65Configuracion_tipocambiowwds_1_dynamicfiltersselector1 = AV15DynamicFiltersSelector1;
         AV66Configuracion_tipocambiowwds_2_dynamicfiltersoperator1 = AV16DynamicFiltersOperator1;
         AV67Configuracion_tipocambiowwds_3_mondsc1 = AV50MonDsc1;
         AV68Configuracion_tipocambiowwds_4_tipfech1 = AV51TipFech1;
         AV69Configuracion_tipocambiowwds_5_tipfech_to1 = AV52TipFech_To1;
         AV70Configuracion_tipocambiowwds_6_dynamicfiltersenabled2 = AV18DynamicFiltersEnabled2;
         AV71Configuracion_tipocambiowwds_7_dynamicfiltersselector2 = AV19DynamicFiltersSelector2;
         AV72Configuracion_tipocambiowwds_8_dynamicfiltersoperator2 = AV20DynamicFiltersOperator2;
         AV73Configuracion_tipocambiowwds_9_mondsc2 = AV53MonDsc2;
         AV74Configuracion_tipocambiowwds_10_tipfech2 = AV54TipFech2;
         AV75Configuracion_tipocambiowwds_11_tipfech_to2 = AV55TipFech_To2;
         AV76Configuracion_tipocambiowwds_12_dynamicfiltersenabled3 = AV22DynamicFiltersEnabled3;
         AV77Configuracion_tipocambiowwds_13_dynamicfiltersselector3 = AV23DynamicFiltersSelector3;
         AV78Configuracion_tipocambiowwds_14_dynamicfiltersoperator3 = AV24DynamicFiltersOperator3;
         AV79Configuracion_tipocambiowwds_15_mondsc3 = AV56MonDsc3;
         AV80Configuracion_tipocambiowwds_16_tipfech3 = AV57TipFech3;
         AV81Configuracion_tipocambiowwds_17_tipfech_to3 = AV58TipFech_To3;
         AV82Configuracion_tipocambiowwds_18_tfmondsc = AV48TFMonDsc;
         AV83Configuracion_tipocambiowwds_19_tfmondsc_sel = AV49TFMonDsc_Sel;
         AV84Configuracion_tipocambiowwds_20_tftipfech = AV31TFTipFech;
         AV85Configuracion_tipocambiowwds_21_tftipfech_to = AV32TFTipFech_To;
         AV86Configuracion_tipocambiowwds_22_tftipcompra = AV36TFTipCompra;
         AV87Configuracion_tipocambiowwds_23_tftipcompra_to = AV37TFTipCompra_To;
         AV88Configuracion_tipocambiowwds_24_tftipventa = AV38TFTipVenta;
         AV89Configuracion_tipocambiowwds_25_tftipventa_to = AV39TFTipVenta_To;
         /*  Sending Event outputs  */
         cmbavDynamicfiltersoperator1.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV16DynamicFiltersOperator1), 4, 0));
         AssignProp("", false, cmbavDynamicfiltersoperator1_Internalname, "Values", cmbavDynamicfiltersoperator1.ToJavascriptSource(), true);
         cmbavDynamicfiltersoperator2.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV20DynamicFiltersOperator2), 4, 0));
         AssignProp("", false, cmbavDynamicfiltersoperator2_Internalname, "Values", cmbavDynamicfiltersoperator2.ToJavascriptSource(), true);
         cmbavDynamicfiltersoperator3.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV24DynamicFiltersOperator3), 4, 0));
         AssignProp("", false, cmbavDynamicfiltersoperator3_Internalname, "Values", cmbavDynamicfiltersoperator3.ToJavascriptSource(), true);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV10GridState", AV10GridState);
      }

      protected void E121W2( )
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
            AV41PageToGo = (int)(NumberUtil.Val( Gridpaginationbar_Selectedpage, "."));
            subgrid_gotopage( AV41PageToGo) ;
         }
      }

      protected void E131W2( )
      {
         /* Gridpaginationbar_Changerowsperpage Routine */
         returnInSub = false;
         subGrid_Rows = Gridpaginationbar_Rowsperpageselectedvalue;
         GxWebStd.gx_hidden_field( context, "GRID_Rows", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid_Rows), 6, 0, ".", "")));
         subgrid_firstpage( ) ;
         /*  Sending Event outputs  */
      }

      protected void E181W2( )
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
            if ( StringUtil.StrCmp(Ddo_grid_Selectedcolumn, "MonDsc") == 0 )
            {
               AV48TFMonDsc = Ddo_grid_Filteredtext_get;
               AssignAttri("", false, "AV48TFMonDsc", AV48TFMonDsc);
               AV49TFMonDsc_Sel = Ddo_grid_Selectedvalue_get;
               AssignAttri("", false, "AV49TFMonDsc_Sel", AV49TFMonDsc_Sel);
            }
            else if ( StringUtil.StrCmp(Ddo_grid_Selectedcolumn, "TipFech") == 0 )
            {
               AV31TFTipFech = context.localUtil.CToD( Ddo_grid_Filteredtext_get, 2);
               AssignAttri("", false, "AV31TFTipFech", context.localUtil.Format(AV31TFTipFech, "99/99/99"));
               AV32TFTipFech_To = context.localUtil.CToD( Ddo_grid_Filteredtextto_get, 2);
               AssignAttri("", false, "AV32TFTipFech_To", context.localUtil.Format(AV32TFTipFech_To, "99/99/99"));
            }
            else if ( StringUtil.StrCmp(Ddo_grid_Selectedcolumn, "TipCompra") == 0 )
            {
               AV36TFTipCompra = NumberUtil.Val( Ddo_grid_Filteredtext_get, ".");
               AssignAttri("", false, "AV36TFTipCompra", StringUtil.LTrimStr( AV36TFTipCompra, 15, 5));
               AV37TFTipCompra_To = NumberUtil.Val( Ddo_grid_Filteredtextto_get, ".");
               AssignAttri("", false, "AV37TFTipCompra_To", StringUtil.LTrimStr( AV37TFTipCompra_To, 15, 5));
            }
            else if ( StringUtil.StrCmp(Ddo_grid_Selectedcolumn, "TipVenta") == 0 )
            {
               AV38TFTipVenta = NumberUtil.Val( Ddo_grid_Filteredtext_get, ".");
               AssignAttri("", false, "AV38TFTipVenta", StringUtil.LTrimStr( AV38TFTipVenta, 15, 5));
               AV39TFTipVenta_To = NumberUtil.Val( Ddo_grid_Filteredtextto_get, ".");
               AssignAttri("", false, "AV39TFTipVenta_To", StringUtil.LTrimStr( AV39TFTipVenta_To, 15, 5));
            }
            subgrid_firstpage( ) ;
         }
         /*  Sending Event outputs  */
      }

      private void E331W2( )
      {
         /* Grid_Load Routine */
         returnInSub = false;
         cmbavGridactions.removeAllItems();
         cmbavGridactions.addItem("0", ";fa fa-bars", 0);
         cmbavGridactions.addItem("1", StringUtil.Format( "%1;%2", "Modificar", "fa fa-pen", "", "", "", "", "", "", ""), 0);
         cmbavGridactions.addItem("2", StringUtil.Format( "%1;%2", "Eliminar", "fa fa-times", "", "", "", "", "", "", ""), 0);
         GXKey = Crypto.GetSiteKey( );
         GXEncryptionTmp = "configuracion.monedas.aspx"+UrlEncode(StringUtil.RTrim("DSP")) + "," + UrlEncode(StringUtil.LTrimStr(A180MonCod,6,0));
         edtMonDsc_Link = formatLink("configuracion.monedas.aspx") + "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey);
         GXKey = Crypto.GetSiteKey( );
         GXEncryptionTmp = "configuracion.tipocambio.aspx"+UrlEncode(StringUtil.RTrim("DSP")) + "," + UrlEncode(StringUtil.LTrimStr(A307TipMonCod,6,0)) + "," + UrlEncode(DateTimeUtil.FormatDateParm(A308TipFech));
         edtTipCompra_Link = formatLink("configuracion.tipocambio.aspx") + "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey);
         /* Load Method */
         if ( wbStart != -1 )
         {
            wbStart = 121;
         }
         sendrow_1212( ) ;
         GRID_nCurrentRecord = (long)(GRID_nCurrentRecord+1);
         if ( isFullAjaxMode( ) && ! bGXsfl_121_Refreshing )
         {
            DoAjaxLoad(121, GridRow);
         }
         /*  Sending Event outputs  */
         cmbavGridactions.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV45GridActions), 4, 0));
      }

      protected void E231W2( )
      {
         /* 'AddDynamicFilters1' Routine */
         returnInSub = false;
         AV18DynamicFiltersEnabled2 = true;
         AssignAttri("", false, "AV18DynamicFiltersEnabled2", AV18DynamicFiltersEnabled2);
         imgAdddynamicfilters1_Visible = 0;
         AssignProp("", false, imgAdddynamicfilters1_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(imgAdddynamicfilters1_Visible), 5, 0), true);
         imgRemovedynamicfilters1_Visible = 1;
         AssignProp("", false, imgRemovedynamicfilters1_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(imgRemovedynamicfilters1_Visible), 5, 0), true);
         gxgrGrid_refresh( subGrid_Rows, AV15DynamicFiltersSelector1, AV16DynamicFiltersOperator1, AV50MonDsc1, AV19DynamicFiltersSelector2, AV20DynamicFiltersOperator2, AV53MonDsc2, AV23DynamicFiltersSelector3, AV24DynamicFiltersOperator3, AV56MonDsc3, AV51TipFech1, AV54TipFech2, AV57TipFech3, AV18DynamicFiltersEnabled2, AV22DynamicFiltersEnabled3, AV64Pgmname, AV52TipFech_To1, AV55TipFech_To2, AV58TipFech_To3, AV48TFMonDsc, AV49TFMonDsc_Sel, AV31TFTipFech, AV32TFTipFech_To, AV36TFTipCompra, AV37TFTipCompra_To, AV38TFTipVenta, AV39TFTipVenta_To, AV13OrderedBy, AV14OrderedDsc, AV10GridState, AV27DynamicFiltersIgnoreFirst, AV26DynamicFiltersRemoving, A180MonCod, Gx_date) ;
         /*  Sending Event outputs  */
         cmbavDynamicfiltersoperator1.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV16DynamicFiltersOperator1), 4, 0));
         AssignProp("", false, cmbavDynamicfiltersoperator1_Internalname, "Values", cmbavDynamicfiltersoperator1.ToJavascriptSource(), true);
         cmbavDynamicfiltersoperator2.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV20DynamicFiltersOperator2), 4, 0));
         AssignProp("", false, cmbavDynamicfiltersoperator2_Internalname, "Values", cmbavDynamicfiltersoperator2.ToJavascriptSource(), true);
         cmbavDynamicfiltersoperator3.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV24DynamicFiltersOperator3), 4, 0));
         AssignProp("", false, cmbavDynamicfiltersoperator3_Internalname, "Values", cmbavDynamicfiltersoperator3.ToJavascriptSource(), true);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV10GridState", AV10GridState);
      }

      protected void E191W2( )
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
         gxgrGrid_refresh( subGrid_Rows, AV15DynamicFiltersSelector1, AV16DynamicFiltersOperator1, AV50MonDsc1, AV19DynamicFiltersSelector2, AV20DynamicFiltersOperator2, AV53MonDsc2, AV23DynamicFiltersSelector3, AV24DynamicFiltersOperator3, AV56MonDsc3, AV51TipFech1, AV54TipFech2, AV57TipFech3, AV18DynamicFiltersEnabled2, AV22DynamicFiltersEnabled3, AV64Pgmname, AV52TipFech_To1, AV55TipFech_To2, AV58TipFech_To3, AV48TFMonDsc, AV49TFMonDsc_Sel, AV31TFTipFech, AV32TFTipFech_To, AV36TFTipCompra, AV37TFTipCompra_To, AV38TFTipVenta, AV39TFTipVenta_To, AV13OrderedBy, AV14OrderedDsc, AV10GridState, AV27DynamicFiltersIgnoreFirst, AV26DynamicFiltersRemoving, A180MonCod, Gx_date) ;
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

      protected void E241W2( )
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

      protected void E151W2( )
      {
         /* Tipfech_rangepicker1_Daterangechanged Routine */
         returnInSub = false;
         AssignAttri("", false, "AV51TipFech1", context.localUtil.Format(AV51TipFech1, "99/99/99"));
         AssignAttri("", false, "AV52TipFech_To1", context.localUtil.Format(AV52TipFech_To1, "99/99/99"));
         gxgrGrid_refresh( subGrid_Rows, AV15DynamicFiltersSelector1, AV16DynamicFiltersOperator1, AV50MonDsc1, AV19DynamicFiltersSelector2, AV20DynamicFiltersOperator2, AV53MonDsc2, AV23DynamicFiltersSelector3, AV24DynamicFiltersOperator3, AV56MonDsc3, AV51TipFech1, AV54TipFech2, AV57TipFech3, AV18DynamicFiltersEnabled2, AV22DynamicFiltersEnabled3, AV64Pgmname, AV52TipFech_To1, AV55TipFech_To2, AV58TipFech_To3, AV48TFMonDsc, AV49TFMonDsc_Sel, AV31TFTipFech, AV32TFTipFech_To, AV36TFTipCompra, AV37TFTipCompra_To, AV38TFTipVenta, AV39TFTipVenta_To, AV13OrderedBy, AV14OrderedDsc, AV10GridState, AV27DynamicFiltersIgnoreFirst, AV26DynamicFiltersRemoving, A180MonCod, Gx_date) ;
         /*  Sending Event outputs  */
         cmbavDynamicfiltersoperator1.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV16DynamicFiltersOperator1), 4, 0));
         AssignProp("", false, cmbavDynamicfiltersoperator1_Internalname, "Values", cmbavDynamicfiltersoperator1.ToJavascriptSource(), true);
         cmbavDynamicfiltersoperator2.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV20DynamicFiltersOperator2), 4, 0));
         AssignProp("", false, cmbavDynamicfiltersoperator2_Internalname, "Values", cmbavDynamicfiltersoperator2.ToJavascriptSource(), true);
         cmbavDynamicfiltersoperator3.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV24DynamicFiltersOperator3), 4, 0));
         AssignProp("", false, cmbavDynamicfiltersoperator3_Internalname, "Values", cmbavDynamicfiltersoperator3.ToJavascriptSource(), true);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV10GridState", AV10GridState);
      }

      protected void E251W2( )
      {
         /* Dynamicfiltersoperator1_Click Routine */
         returnInSub = false;
         if ( StringUtil.StrCmp(AV15DynamicFiltersSelector1, "TIPFECH") == 0 )
         {
            AV51TipFech1 = DateTime.MinValue;
            AssignAttri("", false, "AV51TipFech1", context.localUtil.Format(AV51TipFech1, "99/99/99"));
            AV52TipFech_To1 = DateTime.MinValue;
            AssignAttri("", false, "AV52TipFech_To1", context.localUtil.Format(AV52TipFech_To1, "99/99/99"));
            /* Execute user subroutine: 'UPDATETIPFECH1OPERATORVALUES' */
            S212 ();
            if ( returnInSub )
            {
               returnInSub = true;
               if (true) return;
            }
            gxgrGrid_refresh( subGrid_Rows, AV15DynamicFiltersSelector1, AV16DynamicFiltersOperator1, AV50MonDsc1, AV19DynamicFiltersSelector2, AV20DynamicFiltersOperator2, AV53MonDsc2, AV23DynamicFiltersSelector3, AV24DynamicFiltersOperator3, AV56MonDsc3, AV51TipFech1, AV54TipFech2, AV57TipFech3, AV18DynamicFiltersEnabled2, AV22DynamicFiltersEnabled3, AV64Pgmname, AV52TipFech_To1, AV55TipFech_To2, AV58TipFech_To3, AV48TFMonDsc, AV49TFMonDsc_Sel, AV31TFTipFech, AV32TFTipFech_To, AV36TFTipCompra, AV37TFTipCompra_To, AV38TFTipVenta, AV39TFTipVenta_To, AV13OrderedBy, AV14OrderedDsc, AV10GridState, AV27DynamicFiltersIgnoreFirst, AV26DynamicFiltersRemoving, A180MonCod, Gx_date) ;
         }
         /*  Sending Event outputs  */
         cmbavDynamicfiltersoperator1.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV16DynamicFiltersOperator1), 4, 0));
         AssignProp("", false, cmbavDynamicfiltersoperator1_Internalname, "Values", cmbavDynamicfiltersoperator1.ToJavascriptSource(), true);
         cmbavDynamicfiltersoperator2.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV20DynamicFiltersOperator2), 4, 0));
         AssignProp("", false, cmbavDynamicfiltersoperator2_Internalname, "Values", cmbavDynamicfiltersoperator2.ToJavascriptSource(), true);
         cmbavDynamicfiltersoperator3.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV24DynamicFiltersOperator3), 4, 0));
         AssignProp("", false, cmbavDynamicfiltersoperator3_Internalname, "Values", cmbavDynamicfiltersoperator3.ToJavascriptSource(), true);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV10GridState", AV10GridState);
      }

      protected void E261W2( )
      {
         /* 'AddDynamicFilters2' Routine */
         returnInSub = false;
         AV22DynamicFiltersEnabled3 = true;
         AssignAttri("", false, "AV22DynamicFiltersEnabled3", AV22DynamicFiltersEnabled3);
         imgAdddynamicfilters2_Visible = 0;
         AssignProp("", false, imgAdddynamicfilters2_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(imgAdddynamicfilters2_Visible), 5, 0), true);
         imgRemovedynamicfilters2_Visible = 1;
         AssignProp("", false, imgRemovedynamicfilters2_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(imgRemovedynamicfilters2_Visible), 5, 0), true);
         gxgrGrid_refresh( subGrid_Rows, AV15DynamicFiltersSelector1, AV16DynamicFiltersOperator1, AV50MonDsc1, AV19DynamicFiltersSelector2, AV20DynamicFiltersOperator2, AV53MonDsc2, AV23DynamicFiltersSelector3, AV24DynamicFiltersOperator3, AV56MonDsc3, AV51TipFech1, AV54TipFech2, AV57TipFech3, AV18DynamicFiltersEnabled2, AV22DynamicFiltersEnabled3, AV64Pgmname, AV52TipFech_To1, AV55TipFech_To2, AV58TipFech_To3, AV48TFMonDsc, AV49TFMonDsc_Sel, AV31TFTipFech, AV32TFTipFech_To, AV36TFTipCompra, AV37TFTipCompra_To, AV38TFTipVenta, AV39TFTipVenta_To, AV13OrderedBy, AV14OrderedDsc, AV10GridState, AV27DynamicFiltersIgnoreFirst, AV26DynamicFiltersRemoving, A180MonCod, Gx_date) ;
         /*  Sending Event outputs  */
         cmbavDynamicfiltersoperator1.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV16DynamicFiltersOperator1), 4, 0));
         AssignProp("", false, cmbavDynamicfiltersoperator1_Internalname, "Values", cmbavDynamicfiltersoperator1.ToJavascriptSource(), true);
         cmbavDynamicfiltersoperator2.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV20DynamicFiltersOperator2), 4, 0));
         AssignProp("", false, cmbavDynamicfiltersoperator2_Internalname, "Values", cmbavDynamicfiltersoperator2.ToJavascriptSource(), true);
         cmbavDynamicfiltersoperator3.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV24DynamicFiltersOperator3), 4, 0));
         AssignProp("", false, cmbavDynamicfiltersoperator3_Internalname, "Values", cmbavDynamicfiltersoperator3.ToJavascriptSource(), true);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV10GridState", AV10GridState);
      }

      protected void E201W2( )
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
         gxgrGrid_refresh( subGrid_Rows, AV15DynamicFiltersSelector1, AV16DynamicFiltersOperator1, AV50MonDsc1, AV19DynamicFiltersSelector2, AV20DynamicFiltersOperator2, AV53MonDsc2, AV23DynamicFiltersSelector3, AV24DynamicFiltersOperator3, AV56MonDsc3, AV51TipFech1, AV54TipFech2, AV57TipFech3, AV18DynamicFiltersEnabled2, AV22DynamicFiltersEnabled3, AV64Pgmname, AV52TipFech_To1, AV55TipFech_To2, AV58TipFech_To3, AV48TFMonDsc, AV49TFMonDsc_Sel, AV31TFTipFech, AV32TFTipFech_To, AV36TFTipCompra, AV37TFTipCompra_To, AV38TFTipVenta, AV39TFTipVenta_To, AV13OrderedBy, AV14OrderedDsc, AV10GridState, AV27DynamicFiltersIgnoreFirst, AV26DynamicFiltersRemoving, A180MonCod, Gx_date) ;
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

      protected void E271W2( )
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

      protected void E161W2( )
      {
         /* Tipfech_rangepicker2_Daterangechanged Routine */
         returnInSub = false;
         AssignAttri("", false, "AV54TipFech2", context.localUtil.Format(AV54TipFech2, "99/99/99"));
         AssignAttri("", false, "AV55TipFech_To2", context.localUtil.Format(AV55TipFech_To2, "99/99/99"));
         gxgrGrid_refresh( subGrid_Rows, AV15DynamicFiltersSelector1, AV16DynamicFiltersOperator1, AV50MonDsc1, AV19DynamicFiltersSelector2, AV20DynamicFiltersOperator2, AV53MonDsc2, AV23DynamicFiltersSelector3, AV24DynamicFiltersOperator3, AV56MonDsc3, AV51TipFech1, AV54TipFech2, AV57TipFech3, AV18DynamicFiltersEnabled2, AV22DynamicFiltersEnabled3, AV64Pgmname, AV52TipFech_To1, AV55TipFech_To2, AV58TipFech_To3, AV48TFMonDsc, AV49TFMonDsc_Sel, AV31TFTipFech, AV32TFTipFech_To, AV36TFTipCompra, AV37TFTipCompra_To, AV38TFTipVenta, AV39TFTipVenta_To, AV13OrderedBy, AV14OrderedDsc, AV10GridState, AV27DynamicFiltersIgnoreFirst, AV26DynamicFiltersRemoving, A180MonCod, Gx_date) ;
         /*  Sending Event outputs  */
         cmbavDynamicfiltersoperator1.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV16DynamicFiltersOperator1), 4, 0));
         AssignProp("", false, cmbavDynamicfiltersoperator1_Internalname, "Values", cmbavDynamicfiltersoperator1.ToJavascriptSource(), true);
         cmbavDynamicfiltersoperator2.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV20DynamicFiltersOperator2), 4, 0));
         AssignProp("", false, cmbavDynamicfiltersoperator2_Internalname, "Values", cmbavDynamicfiltersoperator2.ToJavascriptSource(), true);
         cmbavDynamicfiltersoperator3.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV24DynamicFiltersOperator3), 4, 0));
         AssignProp("", false, cmbavDynamicfiltersoperator3_Internalname, "Values", cmbavDynamicfiltersoperator3.ToJavascriptSource(), true);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV10GridState", AV10GridState);
      }

      protected void E281W2( )
      {
         /* Dynamicfiltersoperator2_Click Routine */
         returnInSub = false;
         if ( StringUtil.StrCmp(AV19DynamicFiltersSelector2, "TIPFECH") == 0 )
         {
            AV54TipFech2 = DateTime.MinValue;
            AssignAttri("", false, "AV54TipFech2", context.localUtil.Format(AV54TipFech2, "99/99/99"));
            AV55TipFech_To2 = DateTime.MinValue;
            AssignAttri("", false, "AV55TipFech_To2", context.localUtil.Format(AV55TipFech_To2, "99/99/99"));
            /* Execute user subroutine: 'UPDATETIPFECH2OPERATORVALUES' */
            S222 ();
            if ( returnInSub )
            {
               returnInSub = true;
               if (true) return;
            }
            gxgrGrid_refresh( subGrid_Rows, AV15DynamicFiltersSelector1, AV16DynamicFiltersOperator1, AV50MonDsc1, AV19DynamicFiltersSelector2, AV20DynamicFiltersOperator2, AV53MonDsc2, AV23DynamicFiltersSelector3, AV24DynamicFiltersOperator3, AV56MonDsc3, AV51TipFech1, AV54TipFech2, AV57TipFech3, AV18DynamicFiltersEnabled2, AV22DynamicFiltersEnabled3, AV64Pgmname, AV52TipFech_To1, AV55TipFech_To2, AV58TipFech_To3, AV48TFMonDsc, AV49TFMonDsc_Sel, AV31TFTipFech, AV32TFTipFech_To, AV36TFTipCompra, AV37TFTipCompra_To, AV38TFTipVenta, AV39TFTipVenta_To, AV13OrderedBy, AV14OrderedDsc, AV10GridState, AV27DynamicFiltersIgnoreFirst, AV26DynamicFiltersRemoving, A180MonCod, Gx_date) ;
         }
         /*  Sending Event outputs  */
         cmbavDynamicfiltersoperator1.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV16DynamicFiltersOperator1), 4, 0));
         AssignProp("", false, cmbavDynamicfiltersoperator1_Internalname, "Values", cmbavDynamicfiltersoperator1.ToJavascriptSource(), true);
         cmbavDynamicfiltersoperator2.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV20DynamicFiltersOperator2), 4, 0));
         AssignProp("", false, cmbavDynamicfiltersoperator2_Internalname, "Values", cmbavDynamicfiltersoperator2.ToJavascriptSource(), true);
         cmbavDynamicfiltersoperator3.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV24DynamicFiltersOperator3), 4, 0));
         AssignProp("", false, cmbavDynamicfiltersoperator3_Internalname, "Values", cmbavDynamicfiltersoperator3.ToJavascriptSource(), true);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV10GridState", AV10GridState);
      }

      protected void E211W2( )
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
         gxgrGrid_refresh( subGrid_Rows, AV15DynamicFiltersSelector1, AV16DynamicFiltersOperator1, AV50MonDsc1, AV19DynamicFiltersSelector2, AV20DynamicFiltersOperator2, AV53MonDsc2, AV23DynamicFiltersSelector3, AV24DynamicFiltersOperator3, AV56MonDsc3, AV51TipFech1, AV54TipFech2, AV57TipFech3, AV18DynamicFiltersEnabled2, AV22DynamicFiltersEnabled3, AV64Pgmname, AV52TipFech_To1, AV55TipFech_To2, AV58TipFech_To3, AV48TFMonDsc, AV49TFMonDsc_Sel, AV31TFTipFech, AV32TFTipFech_To, AV36TFTipCompra, AV37TFTipCompra_To, AV38TFTipVenta, AV39TFTipVenta_To, AV13OrderedBy, AV14OrderedDsc, AV10GridState, AV27DynamicFiltersIgnoreFirst, AV26DynamicFiltersRemoving, A180MonCod, Gx_date) ;
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

      protected void E291W2( )
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

      protected void E171W2( )
      {
         /* Tipfech_rangepicker3_Daterangechanged Routine */
         returnInSub = false;
         AssignAttri("", false, "AV57TipFech3", context.localUtil.Format(AV57TipFech3, "99/99/99"));
         AssignAttri("", false, "AV58TipFech_To3", context.localUtil.Format(AV58TipFech_To3, "99/99/99"));
         gxgrGrid_refresh( subGrid_Rows, AV15DynamicFiltersSelector1, AV16DynamicFiltersOperator1, AV50MonDsc1, AV19DynamicFiltersSelector2, AV20DynamicFiltersOperator2, AV53MonDsc2, AV23DynamicFiltersSelector3, AV24DynamicFiltersOperator3, AV56MonDsc3, AV51TipFech1, AV54TipFech2, AV57TipFech3, AV18DynamicFiltersEnabled2, AV22DynamicFiltersEnabled3, AV64Pgmname, AV52TipFech_To1, AV55TipFech_To2, AV58TipFech_To3, AV48TFMonDsc, AV49TFMonDsc_Sel, AV31TFTipFech, AV32TFTipFech_To, AV36TFTipCompra, AV37TFTipCompra_To, AV38TFTipVenta, AV39TFTipVenta_To, AV13OrderedBy, AV14OrderedDsc, AV10GridState, AV27DynamicFiltersIgnoreFirst, AV26DynamicFiltersRemoving, A180MonCod, Gx_date) ;
         /*  Sending Event outputs  */
         cmbavDynamicfiltersoperator1.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV16DynamicFiltersOperator1), 4, 0));
         AssignProp("", false, cmbavDynamicfiltersoperator1_Internalname, "Values", cmbavDynamicfiltersoperator1.ToJavascriptSource(), true);
         cmbavDynamicfiltersoperator2.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV20DynamicFiltersOperator2), 4, 0));
         AssignProp("", false, cmbavDynamicfiltersoperator2_Internalname, "Values", cmbavDynamicfiltersoperator2.ToJavascriptSource(), true);
         cmbavDynamicfiltersoperator3.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV24DynamicFiltersOperator3), 4, 0));
         AssignProp("", false, cmbavDynamicfiltersoperator3_Internalname, "Values", cmbavDynamicfiltersoperator3.ToJavascriptSource(), true);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV10GridState", AV10GridState);
      }

      protected void E301W2( )
      {
         /* Dynamicfiltersoperator3_Click Routine */
         returnInSub = false;
         if ( StringUtil.StrCmp(AV23DynamicFiltersSelector3, "TIPFECH") == 0 )
         {
            AV57TipFech3 = DateTime.MinValue;
            AssignAttri("", false, "AV57TipFech3", context.localUtil.Format(AV57TipFech3, "99/99/99"));
            AV58TipFech_To3 = DateTime.MinValue;
            AssignAttri("", false, "AV58TipFech_To3", context.localUtil.Format(AV58TipFech_To3, "99/99/99"));
            /* Execute user subroutine: 'UPDATETIPFECH3OPERATORVALUES' */
            S232 ();
            if ( returnInSub )
            {
               returnInSub = true;
               if (true) return;
            }
            gxgrGrid_refresh( subGrid_Rows, AV15DynamicFiltersSelector1, AV16DynamicFiltersOperator1, AV50MonDsc1, AV19DynamicFiltersSelector2, AV20DynamicFiltersOperator2, AV53MonDsc2, AV23DynamicFiltersSelector3, AV24DynamicFiltersOperator3, AV56MonDsc3, AV51TipFech1, AV54TipFech2, AV57TipFech3, AV18DynamicFiltersEnabled2, AV22DynamicFiltersEnabled3, AV64Pgmname, AV52TipFech_To1, AV55TipFech_To2, AV58TipFech_To3, AV48TFMonDsc, AV49TFMonDsc_Sel, AV31TFTipFech, AV32TFTipFech_To, AV36TFTipCompra, AV37TFTipCompra_To, AV38TFTipVenta, AV39TFTipVenta_To, AV13OrderedBy, AV14OrderedDsc, AV10GridState, AV27DynamicFiltersIgnoreFirst, AV26DynamicFiltersRemoving, A180MonCod, Gx_date) ;
         }
         /*  Sending Event outputs  */
         cmbavDynamicfiltersoperator1.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV16DynamicFiltersOperator1), 4, 0));
         AssignProp("", false, cmbavDynamicfiltersoperator1_Internalname, "Values", cmbavDynamicfiltersoperator1.ToJavascriptSource(), true);
         cmbavDynamicfiltersoperator2.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV20DynamicFiltersOperator2), 4, 0));
         AssignProp("", false, cmbavDynamicfiltersoperator2_Internalname, "Values", cmbavDynamicfiltersoperator2.ToJavascriptSource(), true);
         cmbavDynamicfiltersoperator3.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV24DynamicFiltersOperator3), 4, 0));
         AssignProp("", false, cmbavDynamicfiltersoperator3_Internalname, "Values", cmbavDynamicfiltersoperator3.ToJavascriptSource(), true);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV10GridState", AV10GridState);
      }

      protected void E341W2( )
      {
         /* Gridactions_Click Routine */
         returnInSub = false;
         if ( AV45GridActions == 1 )
         {
            /* Execute user subroutine: 'DO UPDATE' */
            S242 ();
            if ( returnInSub )
            {
               returnInSub = true;
               if (true) return;
            }
         }
         else if ( AV45GridActions == 2 )
         {
            /* Execute user subroutine: 'DO DELETE' */
            S252 ();
            if ( returnInSub )
            {
               returnInSub = true;
               if (true) return;
            }
         }
         AV45GridActions = 0;
         AssignAttri("", false, cmbavGridactions_Internalname, StringUtil.LTrimStr( (decimal)(AV45GridActions), 4, 0));
         /*  Sending Event outputs  */
         cmbavGridactions.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV45GridActions), 4, 0));
         AssignProp("", false, cmbavGridactions_Internalname, "Values", cmbavGridactions.ToJavascriptSource(), true);
      }

      protected void E221W2( )
      {
         /* 'DoInsert' Routine */
         returnInSub = false;
         GXKey = Crypto.GetSiteKey( );
         GXEncryptionTmp = "configuracion.tipocambio.aspx"+UrlEncode(StringUtil.RTrim("INS")) + "," + UrlEncode(StringUtil.LTrimStr(0,1,0)) + "," + UrlEncode(DateTimeUtil.FormatDateParm(DateTime.MinValue));
         CallWebObject(formatLink("configuracion.tipocambio.aspx") + "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey));
         context.wjLocDisableFrm = 1;
      }

      protected void E141W2( )
      {
         /* Ddo_agexport_Onoptionclicked Routine */
         returnInSub = false;
         if ( StringUtil.StrCmp(Ddo_agexport_Activeeventkey, "ExportReport") == 0 )
         {
            /* Execute user subroutine: 'DOEXPORTREPORT' */
            S262 ();
            if ( returnInSub )
            {
               returnInSub = true;
               if (true) return;
            }
         }
         else if ( StringUtil.StrCmp(Ddo_agexport_Activeeventkey, "Export") == 0 )
         {
            /* Execute user subroutine: 'DOEXPORT' */
            S272 ();
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
         edtavMondsc1_Visible = 0;
         AssignProp("", false, edtavMondsc1_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavMondsc1_Visible), 5, 0), true);
         tblTablemergeddynamicfilterstipfech1_Visible = 0;
         AssignProp("", false, tblTablemergeddynamicfilterstipfech1_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(tblTablemergeddynamicfilterstipfech1_Visible), 5, 0), true);
         cmbavDynamicfiltersoperator1.Visible = 0;
         AssignProp("", false, cmbavDynamicfiltersoperator1_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(cmbavDynamicfiltersoperator1.Visible), 5, 0), true);
         if ( StringUtil.StrCmp(AV15DynamicFiltersSelector1, "MONDSC") == 0 )
         {
            edtavMondsc1_Visible = 1;
            AssignProp("", false, edtavMondsc1_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavMondsc1_Visible), 5, 0), true);
            cmbavDynamicfiltersoperator1.Visible = 1;
            AssignProp("", false, cmbavDynamicfiltersoperator1_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(cmbavDynamicfiltersoperator1.Visible), 5, 0), true);
         }
         else if ( StringUtil.StrCmp(AV15DynamicFiltersSelector1, "TIPFECH") == 0 )
         {
            tblTablemergeddynamicfilterstipfech1_Visible = 1;
            AssignProp("", false, tblTablemergeddynamicfilterstipfech1_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(tblTablemergeddynamicfilterstipfech1_Visible), 5, 0), true);
            cmbavDynamicfiltersoperator1.Visible = 1;
            AssignProp("", false, cmbavDynamicfiltersoperator1_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(cmbavDynamicfiltersoperator1.Visible), 5, 0), true);
            /* Execute user subroutine: 'UPDATETIPFECH1OPERATORVALUES' */
            S212 ();
            if ( returnInSub )
            {
               returnInSub = true;
               if (true) return;
            }
         }
      }

      protected void S212( )
      {
         /* 'UPDATETIPFECH1OPERATORVALUES' Routine */
         returnInSub = false;
         cellTipfech_range_cell1_Class = "Invisible";
         AssignProp("", false, cellTipfech_range_cell1_Internalname, "Class", cellTipfech_range_cell1_Class, true);
         if ( AV16DynamicFiltersOperator1 == 0 )
         {
            AV51TipFech1 = Gx_date;
            AssignAttri("", false, "AV51TipFech1", context.localUtil.Format(AV51TipFech1, "99/99/99"));
         }
         else if ( AV16DynamicFiltersOperator1 == 1 )
         {
            AV51TipFech1 = Gx_date;
            AssignAttri("", false, "AV51TipFech1", context.localUtil.Format(AV51TipFech1, "99/99/99"));
         }
         else if ( AV16DynamicFiltersOperator1 == 2 )
         {
            AV51TipFech1 = Gx_date;
            AssignAttri("", false, "AV51TipFech1", context.localUtil.Format(AV51TipFech1, "99/99/99"));
         }
         else if ( AV16DynamicFiltersOperator1 == 3 )
         {
            cellTipfech_range_cell1_Class = "";
            AssignProp("", false, cellTipfech_range_cell1_Internalname, "Class", cellTipfech_range_cell1_Class, true);
         }
      }

      protected void S122( )
      {
         /* 'ENABLEDYNAMICFILTERS2' Routine */
         returnInSub = false;
         edtavMondsc2_Visible = 0;
         AssignProp("", false, edtavMondsc2_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavMondsc2_Visible), 5, 0), true);
         tblTablemergeddynamicfilterstipfech2_Visible = 0;
         AssignProp("", false, tblTablemergeddynamicfilterstipfech2_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(tblTablemergeddynamicfilterstipfech2_Visible), 5, 0), true);
         cmbavDynamicfiltersoperator2.Visible = 0;
         AssignProp("", false, cmbavDynamicfiltersoperator2_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(cmbavDynamicfiltersoperator2.Visible), 5, 0), true);
         if ( StringUtil.StrCmp(AV19DynamicFiltersSelector2, "MONDSC") == 0 )
         {
            edtavMondsc2_Visible = 1;
            AssignProp("", false, edtavMondsc2_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavMondsc2_Visible), 5, 0), true);
            cmbavDynamicfiltersoperator2.Visible = 1;
            AssignProp("", false, cmbavDynamicfiltersoperator2_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(cmbavDynamicfiltersoperator2.Visible), 5, 0), true);
         }
         else if ( StringUtil.StrCmp(AV19DynamicFiltersSelector2, "TIPFECH") == 0 )
         {
            tblTablemergeddynamicfilterstipfech2_Visible = 1;
            AssignProp("", false, tblTablemergeddynamicfilterstipfech2_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(tblTablemergeddynamicfilterstipfech2_Visible), 5, 0), true);
            cmbavDynamicfiltersoperator2.Visible = 1;
            AssignProp("", false, cmbavDynamicfiltersoperator2_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(cmbavDynamicfiltersoperator2.Visible), 5, 0), true);
            /* Execute user subroutine: 'UPDATETIPFECH2OPERATORVALUES' */
            S222 ();
            if ( returnInSub )
            {
               returnInSub = true;
               if (true) return;
            }
         }
      }

      protected void S222( )
      {
         /* 'UPDATETIPFECH2OPERATORVALUES' Routine */
         returnInSub = false;
         cellTipfech_range_cell2_Class = "Invisible";
         AssignProp("", false, cellTipfech_range_cell2_Internalname, "Class", cellTipfech_range_cell2_Class, true);
         if ( AV20DynamicFiltersOperator2 == 0 )
         {
            AV54TipFech2 = Gx_date;
            AssignAttri("", false, "AV54TipFech2", context.localUtil.Format(AV54TipFech2, "99/99/99"));
         }
         else if ( AV20DynamicFiltersOperator2 == 1 )
         {
            AV54TipFech2 = Gx_date;
            AssignAttri("", false, "AV54TipFech2", context.localUtil.Format(AV54TipFech2, "99/99/99"));
         }
         else if ( AV20DynamicFiltersOperator2 == 2 )
         {
            AV54TipFech2 = Gx_date;
            AssignAttri("", false, "AV54TipFech2", context.localUtil.Format(AV54TipFech2, "99/99/99"));
         }
         else if ( AV20DynamicFiltersOperator2 == 3 )
         {
            cellTipfech_range_cell2_Class = "";
            AssignProp("", false, cellTipfech_range_cell2_Internalname, "Class", cellTipfech_range_cell2_Class, true);
         }
      }

      protected void S132( )
      {
         /* 'ENABLEDYNAMICFILTERS3' Routine */
         returnInSub = false;
         edtavMondsc3_Visible = 0;
         AssignProp("", false, edtavMondsc3_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavMondsc3_Visible), 5, 0), true);
         tblTablemergeddynamicfilterstipfech3_Visible = 0;
         AssignProp("", false, tblTablemergeddynamicfilterstipfech3_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(tblTablemergeddynamicfilterstipfech3_Visible), 5, 0), true);
         cmbavDynamicfiltersoperator3.Visible = 0;
         AssignProp("", false, cmbavDynamicfiltersoperator3_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(cmbavDynamicfiltersoperator3.Visible), 5, 0), true);
         if ( StringUtil.StrCmp(AV23DynamicFiltersSelector3, "MONDSC") == 0 )
         {
            edtavMondsc3_Visible = 1;
            AssignProp("", false, edtavMondsc3_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavMondsc3_Visible), 5, 0), true);
            cmbavDynamicfiltersoperator3.Visible = 1;
            AssignProp("", false, cmbavDynamicfiltersoperator3_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(cmbavDynamicfiltersoperator3.Visible), 5, 0), true);
         }
         else if ( StringUtil.StrCmp(AV23DynamicFiltersSelector3, "TIPFECH") == 0 )
         {
            tblTablemergeddynamicfilterstipfech3_Visible = 1;
            AssignProp("", false, tblTablemergeddynamicfilterstipfech3_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(tblTablemergeddynamicfilterstipfech3_Visible), 5, 0), true);
            cmbavDynamicfiltersoperator3.Visible = 1;
            AssignProp("", false, cmbavDynamicfiltersoperator3_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(cmbavDynamicfiltersoperator3.Visible), 5, 0), true);
            /* Execute user subroutine: 'UPDATETIPFECH3OPERATORVALUES' */
            S232 ();
            if ( returnInSub )
            {
               returnInSub = true;
               if (true) return;
            }
         }
      }

      protected void S232( )
      {
         /* 'UPDATETIPFECH3OPERATORVALUES' Routine */
         returnInSub = false;
         cellTipfech_range_cell3_Class = "Invisible";
         AssignProp("", false, cellTipfech_range_cell3_Internalname, "Class", cellTipfech_range_cell3_Class, true);
         if ( AV24DynamicFiltersOperator3 == 0 )
         {
            AV57TipFech3 = Gx_date;
            AssignAttri("", false, "AV57TipFech3", context.localUtil.Format(AV57TipFech3, "99/99/99"));
         }
         else if ( AV24DynamicFiltersOperator3 == 1 )
         {
            AV57TipFech3 = Gx_date;
            AssignAttri("", false, "AV57TipFech3", context.localUtil.Format(AV57TipFech3, "99/99/99"));
         }
         else if ( AV24DynamicFiltersOperator3 == 2 )
         {
            AV57TipFech3 = Gx_date;
            AssignAttri("", false, "AV57TipFech3", context.localUtil.Format(AV57TipFech3, "99/99/99"));
         }
         else if ( AV24DynamicFiltersOperator3 == 3 )
         {
            cellTipfech_range_cell3_Class = "";
            AssignProp("", false, cellTipfech_range_cell3_Internalname, "Class", cellTipfech_range_cell3_Class, true);
         }
      }

      protected void S192( )
      {
         /* 'RESETDYNFILTERS' Routine */
         returnInSub = false;
         AV18DynamicFiltersEnabled2 = false;
         AssignAttri("", false, "AV18DynamicFiltersEnabled2", AV18DynamicFiltersEnabled2);
         AV19DynamicFiltersSelector2 = "MONDSC";
         AssignAttri("", false, "AV19DynamicFiltersSelector2", AV19DynamicFiltersSelector2);
         AV20DynamicFiltersOperator2 = 0;
         AssignAttri("", false, "AV20DynamicFiltersOperator2", StringUtil.LTrimStr( (decimal)(AV20DynamicFiltersOperator2), 4, 0));
         AV53MonDsc2 = "";
         AssignAttri("", false, "AV53MonDsc2", AV53MonDsc2);
         /* Execute user subroutine: 'ENABLEDYNAMICFILTERS2' */
         S122 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
         AV22DynamicFiltersEnabled3 = false;
         AssignAttri("", false, "AV22DynamicFiltersEnabled3", AV22DynamicFiltersEnabled3);
         AV23DynamicFiltersSelector3 = "MONDSC";
         AssignAttri("", false, "AV23DynamicFiltersSelector3", AV23DynamicFiltersSelector3);
         AV24DynamicFiltersOperator3 = 0;
         AssignAttri("", false, "AV24DynamicFiltersOperator3", StringUtil.LTrimStr( (decimal)(AV24DynamicFiltersOperator3), 4, 0));
         AV56MonDsc3 = "";
         AssignAttri("", false, "AV56MonDsc3", AV56MonDsc3);
         /* Execute user subroutine: 'ENABLEDYNAMICFILTERS3' */
         S132 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
      }

      protected void S242( )
      {
         /* 'DO UPDATE' Routine */
         returnInSub = false;
         GXKey = Crypto.GetSiteKey( );
         GXEncryptionTmp = "configuracion.tipocambio.aspx"+UrlEncode(StringUtil.RTrim("UPD")) + "," + UrlEncode(StringUtil.LTrimStr(A307TipMonCod,6,0)) + "," + UrlEncode(DateTimeUtil.FormatDateParm(A308TipFech));
         CallWebObject(formatLink("configuracion.tipocambio.aspx") + "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey));
         context.wjLocDisableFrm = 1;
      }

      protected void S252( )
      {
         /* 'DO DELETE' Routine */
         returnInSub = false;
         GXKey = Crypto.GetSiteKey( );
         GXEncryptionTmp = "configuracion.tipocambio.aspx"+UrlEncode(StringUtil.RTrim("DLT")) + "," + UrlEncode(StringUtil.LTrimStr(A307TipMonCod,6,0)) + "," + UrlEncode(DateTimeUtil.FormatDateParm(A308TipFech));
         CallWebObject(formatLink("configuracion.tipocambio.aspx") + "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey));
         context.wjLocDisableFrm = 1;
      }

      protected void S152( )
      {
         /* 'LOADGRIDSTATE' Routine */
         returnInSub = false;
         if ( StringUtil.StrCmp(AV30Session.Get(AV64Pgmname+"GridState"), "") == 0 )
         {
            AV10GridState.FromXml(new GeneXus.Programs.wwpbaseobjects.loadgridstate(context).executeUdp(  AV64Pgmname+"GridState"), null, "", "");
         }
         else
         {
            AV10GridState.FromXml(AV30Session.Get(AV64Pgmname+"GridState"), null, "", "");
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
         AV91GXV1 = 1;
         while ( AV91GXV1 <= AV10GridState.gxTpr_Filtervalues.Count )
         {
            AV11GridStateFilterValue = ((GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue)AV10GridState.gxTpr_Filtervalues.Item(AV91GXV1));
            if ( StringUtil.StrCmp(AV11GridStateFilterValue.gxTpr_Name, "TFMONDSC") == 0 )
            {
               AV48TFMonDsc = AV11GridStateFilterValue.gxTpr_Value;
               AssignAttri("", false, "AV48TFMonDsc", AV48TFMonDsc);
            }
            else if ( StringUtil.StrCmp(AV11GridStateFilterValue.gxTpr_Name, "TFMONDSC_SEL") == 0 )
            {
               AV49TFMonDsc_Sel = AV11GridStateFilterValue.gxTpr_Value;
               AssignAttri("", false, "AV49TFMonDsc_Sel", AV49TFMonDsc_Sel);
            }
            else if ( StringUtil.StrCmp(AV11GridStateFilterValue.gxTpr_Name, "TFTIPFECH") == 0 )
            {
               AV31TFTipFech = context.localUtil.CToD( AV11GridStateFilterValue.gxTpr_Value, 2);
               AssignAttri("", false, "AV31TFTipFech", context.localUtil.Format(AV31TFTipFech, "99/99/99"));
               AV32TFTipFech_To = context.localUtil.CToD( AV11GridStateFilterValue.gxTpr_Valueto, 2);
               AssignAttri("", false, "AV32TFTipFech_To", context.localUtil.Format(AV32TFTipFech_To, "99/99/99"));
            }
            else if ( StringUtil.StrCmp(AV11GridStateFilterValue.gxTpr_Name, "TFTIPCOMPRA") == 0 )
            {
               AV36TFTipCompra = NumberUtil.Val( AV11GridStateFilterValue.gxTpr_Value, ".");
               AssignAttri("", false, "AV36TFTipCompra", StringUtil.LTrimStr( AV36TFTipCompra, 15, 5));
               AV37TFTipCompra_To = NumberUtil.Val( AV11GridStateFilterValue.gxTpr_Valueto, ".");
               AssignAttri("", false, "AV37TFTipCompra_To", StringUtil.LTrimStr( AV37TFTipCompra_To, 15, 5));
            }
            else if ( StringUtil.StrCmp(AV11GridStateFilterValue.gxTpr_Name, "TFTIPVENTA") == 0 )
            {
               AV38TFTipVenta = NumberUtil.Val( AV11GridStateFilterValue.gxTpr_Value, ".");
               AssignAttri("", false, "AV38TFTipVenta", StringUtil.LTrimStr( AV38TFTipVenta, 15, 5));
               AV39TFTipVenta_To = NumberUtil.Val( AV11GridStateFilterValue.gxTpr_Valueto, ".");
               AssignAttri("", false, "AV39TFTipVenta_To", StringUtil.LTrimStr( AV39TFTipVenta_To, 15, 5));
            }
            AV91GXV1 = (int)(AV91GXV1+1);
         }
         GXt_char2 = "";
         new GeneXus.Programs.wwpbaseobjects.wwp_getfilterval(context ).execute(  String.IsNullOrEmpty(StringUtil.RTrim( AV49TFMonDsc_Sel)),  AV49TFMonDsc_Sel, out  GXt_char2) ;
         Ddo_grid_Selectedvalue_set = GXt_char2+"|||";
         ucDdo_grid.SendProperty(context, "", false, Ddo_grid_Internalname, "SelectedValue_set", Ddo_grid_Selectedvalue_set);
         GXt_char2 = "";
         new GeneXus.Programs.wwpbaseobjects.wwp_getfilterval(context ).execute(  String.IsNullOrEmpty(StringUtil.RTrim( AV48TFMonDsc)),  AV48TFMonDsc, out  GXt_char2) ;
         Ddo_grid_Filteredtext_set = GXt_char2+"|"+((DateTime.MinValue==AV31TFTipFech) ? "" : context.localUtil.DToC( AV31TFTipFech, 2, "/"))+"|"+((Convert.ToDecimal(0)==AV36TFTipCompra) ? "" : StringUtil.Str( AV36TFTipCompra, 15, 5))+"|"+((Convert.ToDecimal(0)==AV38TFTipVenta) ? "" : StringUtil.Str( AV38TFTipVenta, 15, 5));
         ucDdo_grid.SendProperty(context, "", false, Ddo_grid_Internalname, "FilteredText_set", Ddo_grid_Filteredtext_set);
         Ddo_grid_Filteredtextto_set = "|"+((DateTime.MinValue==AV32TFTipFech_To) ? "" : context.localUtil.DToC( AV32TFTipFech_To, 2, "/"))+"|"+((Convert.ToDecimal(0)==AV37TFTipCompra_To) ? "" : StringUtil.Str( AV37TFTipCompra_To, 15, 5))+"|"+((Convert.ToDecimal(0)==AV39TFTipVenta_To) ? "" : StringUtil.Str( AV39TFTipVenta_To, 15, 5));
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
            if ( StringUtil.StrCmp(AV15DynamicFiltersSelector1, "MONDSC") == 0 )
            {
               AV16DynamicFiltersOperator1 = AV12GridStateDynamicFilter.gxTpr_Operator;
               AssignAttri("", false, "AV16DynamicFiltersOperator1", StringUtil.LTrimStr( (decimal)(AV16DynamicFiltersOperator1), 4, 0));
               AV50MonDsc1 = AV12GridStateDynamicFilter.gxTpr_Value;
               AssignAttri("", false, "AV50MonDsc1", AV50MonDsc1);
            }
            else if ( StringUtil.StrCmp(AV15DynamicFiltersSelector1, "TIPFECH") == 0 )
            {
               AV16DynamicFiltersOperator1 = AV12GridStateDynamicFilter.gxTpr_Operator;
               AssignAttri("", false, "AV16DynamicFiltersOperator1", StringUtil.LTrimStr( (decimal)(AV16DynamicFiltersOperator1), 4, 0));
               AV51TipFech1 = context.localUtil.CToD( AV12GridStateDynamicFilter.gxTpr_Value, 2);
               AssignAttri("", false, "AV51TipFech1", context.localUtil.Format(AV51TipFech1, "99/99/99"));
               AV52TipFech_To1 = context.localUtil.CToD( AV12GridStateDynamicFilter.gxTpr_Valueto, 2);
               AssignAttri("", false, "AV52TipFech_To1", context.localUtil.Format(AV52TipFech_To1, "99/99/99"));
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
               if ( StringUtil.StrCmp(AV19DynamicFiltersSelector2, "MONDSC") == 0 )
               {
                  AV20DynamicFiltersOperator2 = AV12GridStateDynamicFilter.gxTpr_Operator;
                  AssignAttri("", false, "AV20DynamicFiltersOperator2", StringUtil.LTrimStr( (decimal)(AV20DynamicFiltersOperator2), 4, 0));
                  AV53MonDsc2 = AV12GridStateDynamicFilter.gxTpr_Value;
                  AssignAttri("", false, "AV53MonDsc2", AV53MonDsc2);
               }
               else if ( StringUtil.StrCmp(AV19DynamicFiltersSelector2, "TIPFECH") == 0 )
               {
                  AV20DynamicFiltersOperator2 = AV12GridStateDynamicFilter.gxTpr_Operator;
                  AssignAttri("", false, "AV20DynamicFiltersOperator2", StringUtil.LTrimStr( (decimal)(AV20DynamicFiltersOperator2), 4, 0));
                  AV54TipFech2 = context.localUtil.CToD( AV12GridStateDynamicFilter.gxTpr_Value, 2);
                  AssignAttri("", false, "AV54TipFech2", context.localUtil.Format(AV54TipFech2, "99/99/99"));
                  AV55TipFech_To2 = context.localUtil.CToD( AV12GridStateDynamicFilter.gxTpr_Valueto, 2);
                  AssignAttri("", false, "AV55TipFech_To2", context.localUtil.Format(AV55TipFech_To2, "99/99/99"));
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
                  if ( StringUtil.StrCmp(AV23DynamicFiltersSelector3, "MONDSC") == 0 )
                  {
                     AV24DynamicFiltersOperator3 = AV12GridStateDynamicFilter.gxTpr_Operator;
                     AssignAttri("", false, "AV24DynamicFiltersOperator3", StringUtil.LTrimStr( (decimal)(AV24DynamicFiltersOperator3), 4, 0));
                     AV56MonDsc3 = AV12GridStateDynamicFilter.gxTpr_Value;
                     AssignAttri("", false, "AV56MonDsc3", AV56MonDsc3);
                  }
                  else if ( StringUtil.StrCmp(AV23DynamicFiltersSelector3, "TIPFECH") == 0 )
                  {
                     AV24DynamicFiltersOperator3 = AV12GridStateDynamicFilter.gxTpr_Operator;
                     AssignAttri("", false, "AV24DynamicFiltersOperator3", StringUtil.LTrimStr( (decimal)(AV24DynamicFiltersOperator3), 4, 0));
                     AV57TipFech3 = context.localUtil.CToD( AV12GridStateDynamicFilter.gxTpr_Value, 2);
                     AssignAttri("", false, "AV57TipFech3", context.localUtil.Format(AV57TipFech3, "99/99/99"));
                     AV58TipFech_To3 = context.localUtil.CToD( AV12GridStateDynamicFilter.gxTpr_Valueto, 2);
                     AssignAttri("", false, "AV58TipFech_To3", context.localUtil.Format(AV58TipFech_To3, "99/99/99"));
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
         AV10GridState.FromXml(AV30Session.Get(AV64Pgmname+"GridState"), null, "", "");
         AV10GridState.gxTpr_Orderedby = AV13OrderedBy;
         AV10GridState.gxTpr_Ordereddsc = AV14OrderedDsc;
         AV10GridState.gxTpr_Filtervalues.Clear();
         new GeneXus.Programs.wwpbaseobjects.wwp_gridstateaddfiltervalueandsel(context ).execute( ref  AV10GridState,  "TFMONDSC",  "Moneda",  !String.IsNullOrEmpty(StringUtil.RTrim( AV48TFMonDsc)),  0,  AV48TFMonDsc,  "",  !String.IsNullOrEmpty(StringUtil.RTrim( AV49TFMonDsc_Sel)),  AV49TFMonDsc_Sel,  "") ;
         new GeneXus.Programs.wwpbaseobjects.wwp_gridstateaddfiltervalue(context ).execute( ref  AV10GridState,  "TFTIPFECH",  "Fecha",  !((DateTime.MinValue==AV31TFTipFech)&&(DateTime.MinValue==AV32TFTipFech_To)),  0,  StringUtil.Trim( context.localUtil.DToC( AV31TFTipFech, 2, "/")),  StringUtil.Trim( context.localUtil.DToC( AV32TFTipFech_To, 2, "/"))) ;
         new GeneXus.Programs.wwpbaseobjects.wwp_gridstateaddfiltervalue(context ).execute( ref  AV10GridState,  "TFTIPCOMPRA",  "Compra",  !((Convert.ToDecimal(0)==AV36TFTipCompra)&&(Convert.ToDecimal(0)==AV37TFTipCompra_To)),  0,  StringUtil.Trim( StringUtil.Str( AV36TFTipCompra, 15, 5)),  StringUtil.Trim( StringUtil.Str( AV37TFTipCompra_To, 15, 5))) ;
         new GeneXus.Programs.wwpbaseobjects.wwp_gridstateaddfiltervalue(context ).execute( ref  AV10GridState,  "TFTIPVENTA",  "Venta",  !((Convert.ToDecimal(0)==AV38TFTipVenta)&&(Convert.ToDecimal(0)==AV39TFTipVenta_To)),  0,  StringUtil.Trim( StringUtil.Str( AV38TFTipVenta, 15, 5)),  StringUtil.Trim( StringUtil.Str( AV39TFTipVenta_To, 15, 5))) ;
         /* Execute user subroutine: 'SAVEDYNFILTERSSTATE' */
         S182 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
         AV10GridState.gxTpr_Pagesize = StringUtil.Str( (decimal)(subGrid_Rows), 10, 0);
         AV10GridState.gxTpr_Currentpage = (short)(subGrid_fnc_Currentpage( ));
         new GeneXus.Programs.wwpbaseobjects.savegridstate(context ).execute(  AV64Pgmname+"GridState",  AV10GridState.ToXml(false, true, "", "")) ;
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
            if ( ( StringUtil.StrCmp(AV15DynamicFiltersSelector1, "MONDSC") == 0 ) && ! String.IsNullOrEmpty(StringUtil.RTrim( AV50MonDsc1)) )
            {
               AV12GridStateDynamicFilter.gxTpr_Dsc = "Moneda";
               AV12GridStateDynamicFilter.gxTpr_Value = AV50MonDsc1;
               AV12GridStateDynamicFilter.gxTpr_Operator = AV16DynamicFiltersOperator1;
            }
            else if ( ( StringUtil.StrCmp(AV15DynamicFiltersSelector1, "TIPFECH") == 0 ) && ! ( (DateTime.MinValue==AV51TipFech1) && (DateTime.MinValue==AV52TipFech_To1) ) )
            {
               AV12GridStateDynamicFilter.gxTpr_Dsc = "Fecha";
               AV12GridStateDynamicFilter.gxTpr_Value = context.localUtil.DToC( AV51TipFech1, 2, "/");
               AV12GridStateDynamicFilter.gxTpr_Operator = AV16DynamicFiltersOperator1;
               AV12GridStateDynamicFilter.gxTpr_Valueto = context.localUtil.DToC( AV52TipFech_To1, 2, "/");
            }
            if ( AV26DynamicFiltersRemoving || ! String.IsNullOrEmpty(StringUtil.RTrim( AV12GridStateDynamicFilter.gxTpr_Value)) || ! String.IsNullOrEmpty(StringUtil.RTrim( AV12GridStateDynamicFilter.gxTpr_Valueto)) )
            {
               AV10GridState.gxTpr_Dynamicfilters.Add(AV12GridStateDynamicFilter, 0);
            }
         }
         if ( AV18DynamicFiltersEnabled2 )
         {
            AV12GridStateDynamicFilter = new GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter(context);
            AV12GridStateDynamicFilter.gxTpr_Selected = AV19DynamicFiltersSelector2;
            if ( ( StringUtil.StrCmp(AV19DynamicFiltersSelector2, "MONDSC") == 0 ) && ! String.IsNullOrEmpty(StringUtil.RTrim( AV53MonDsc2)) )
            {
               AV12GridStateDynamicFilter.gxTpr_Dsc = "Moneda";
               AV12GridStateDynamicFilter.gxTpr_Value = AV53MonDsc2;
               AV12GridStateDynamicFilter.gxTpr_Operator = AV20DynamicFiltersOperator2;
            }
            else if ( ( StringUtil.StrCmp(AV19DynamicFiltersSelector2, "TIPFECH") == 0 ) && ! ( (DateTime.MinValue==AV54TipFech2) && (DateTime.MinValue==AV55TipFech_To2) ) )
            {
               AV12GridStateDynamicFilter.gxTpr_Dsc = "Fecha";
               AV12GridStateDynamicFilter.gxTpr_Value = context.localUtil.DToC( AV54TipFech2, 2, "/");
               AV12GridStateDynamicFilter.gxTpr_Operator = AV20DynamicFiltersOperator2;
               AV12GridStateDynamicFilter.gxTpr_Valueto = context.localUtil.DToC( AV55TipFech_To2, 2, "/");
            }
            if ( AV26DynamicFiltersRemoving || ! String.IsNullOrEmpty(StringUtil.RTrim( AV12GridStateDynamicFilter.gxTpr_Value)) || ! String.IsNullOrEmpty(StringUtil.RTrim( AV12GridStateDynamicFilter.gxTpr_Valueto)) )
            {
               AV10GridState.gxTpr_Dynamicfilters.Add(AV12GridStateDynamicFilter, 0);
            }
         }
         if ( AV22DynamicFiltersEnabled3 )
         {
            AV12GridStateDynamicFilter = new GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter(context);
            AV12GridStateDynamicFilter.gxTpr_Selected = AV23DynamicFiltersSelector3;
            if ( ( StringUtil.StrCmp(AV23DynamicFiltersSelector3, "MONDSC") == 0 ) && ! String.IsNullOrEmpty(StringUtil.RTrim( AV56MonDsc3)) )
            {
               AV12GridStateDynamicFilter.gxTpr_Dsc = "Moneda";
               AV12GridStateDynamicFilter.gxTpr_Value = AV56MonDsc3;
               AV12GridStateDynamicFilter.gxTpr_Operator = AV24DynamicFiltersOperator3;
            }
            else if ( ( StringUtil.StrCmp(AV23DynamicFiltersSelector3, "TIPFECH") == 0 ) && ! ( (DateTime.MinValue==AV57TipFech3) && (DateTime.MinValue==AV58TipFech_To3) ) )
            {
               AV12GridStateDynamicFilter.gxTpr_Dsc = "Fecha";
               AV12GridStateDynamicFilter.gxTpr_Value = context.localUtil.DToC( AV57TipFech3, 2, "/");
               AV12GridStateDynamicFilter.gxTpr_Operator = AV24DynamicFiltersOperator3;
               AV12GridStateDynamicFilter.gxTpr_Valueto = context.localUtil.DToC( AV58TipFech_To3, 2, "/");
            }
            if ( AV26DynamicFiltersRemoving || ! String.IsNullOrEmpty(StringUtil.RTrim( AV12GridStateDynamicFilter.gxTpr_Value)) || ! String.IsNullOrEmpty(StringUtil.RTrim( AV12GridStateDynamicFilter.gxTpr_Valueto)) )
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
         AV8TrnContext.gxTpr_Callerobject = AV64Pgmname;
         AV8TrnContext.gxTpr_Callerondelete = true;
         AV8TrnContext.gxTpr_Callerurl = AV7HTTPRequest.ScriptName+"?"+AV7HTTPRequest.QueryString;
         AV8TrnContext.gxTpr_Transactionname = "Configuracion.TipoCambio";
         AV30Session.Set("TrnContext", AV8TrnContext.ToXml(false, true, "", ""));
      }

      protected void S272( )
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
         new GeneXus.Programs.configuracion.tipocambiowwexport(context ).execute( out  AV28ExcelFilename, out  AV29ErrorMessage) ;
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

      protected void S262( )
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
         Innewwindow1_Target = formatLink("configuracion.tipocambiowwexportreport.aspx") ;
         ucInnewwindow1.SendProperty(context, "", false, Innewwindow1_Internalname, "Target", Innewwindow1_Target);
         Innewwindow1_Height = "600";
         ucInnewwindow1.SendProperty(context, "", false, Innewwindow1_Internalname, "Height", Innewwindow1_Height);
         Innewwindow1_Width = "800";
         ucInnewwindow1.SendProperty(context, "", false, Innewwindow1_Internalname, "Width", Innewwindow1_Width);
         this.executeUsercontrolMethod("", false, "INNEWWINDOW1Container", "OpenWindow", "", new Object[] {});
      }

      protected void wb_table1_27_1W2( bool wbgen )
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
            GxWebStd.gx_label_ctrl( context, lblDynamicfiltersprefix1_Internalname, "Buscar en", "", "", lblDynamicfiltersprefix1_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "DataFilterDescriptionPrefix", 0, "", 1, 1, 0, 0, "HLP_Configuracion\\TipoCambioWW.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "", "left", "top", "", "flex-grow:1;", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "left", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, cmbavDynamicfiltersselector1_Internalname, "Dynamic Filters Selector1", "gx-form-item AttributeLabel", 0, true, "width: 25%;");
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 37,'',false,'" + sGXsfl_121_idx + "',0)\"";
            /* ComboBox */
            GxWebStd.gx_combobox_ctrl1( context, cmbavDynamicfiltersselector1, cmbavDynamicfiltersselector1_Internalname, StringUtil.RTrim( AV15DynamicFiltersSelector1), 1, cmbavDynamicfiltersselector1_Jsonclick, 5, "'"+""+"'"+",false,"+"'"+"EVDYNAMICFILTERSSELECTOR1.CLICK."+"'", "svchar", "", 1, cmbavDynamicfiltersselector1.Enabled, 0, 0, 0, "em", 0, "", "", "Attribute", "", "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,37);\"", "", true, 1, "HLP_Configuracion\\TipoCambioWW.htm");
            cmbavDynamicfiltersselector1.CurrentValue = StringUtil.RTrim( AV15DynamicFiltersSelector1);
            AssignProp("", false, cmbavDynamicfiltersselector1_Internalname, "Values", (string)(cmbavDynamicfiltersselector1.ToJavascriptSource()), true);
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "", "left", "top", "", "flex-grow:1;", "div");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblDynamicfiltersmiddle1_Internalname, "valor", "", "", lblDynamicfiltersmiddle1_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "DataFilterDescription", 0, "", 1, 1, 0, 0, "HLP_Configuracion\\TipoCambioWW.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "", "left", "top", "", "flex-grow:1;", "div");
            wb_table2_41_1W2( true) ;
         }
         else
         {
            wb_table2_41_1W2( false) ;
         }
         return  ;
      }

      protected void wb_table2_41_1W2e( bool wbgen )
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
            GxWebStd.gx_label_ctrl( context, lblDynamicfiltersprefix2_Internalname, "Buscar en", "", "", lblDynamicfiltersprefix2_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "DataFilterDescriptionPrefix", 0, "", 1, 1, 0, 0, "HLP_Configuracion\\TipoCambioWW.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "Invisible", "left", "top", "", "flex-grow:1;", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "left", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, cmbavDynamicfiltersselector2_Internalname, "Dynamic Filters Selector2", "gx-form-item AttributeLabel", 0, true, "width: 25%;");
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 65,'',false,'" + sGXsfl_121_idx + "',0)\"";
            /* ComboBox */
            GxWebStd.gx_combobox_ctrl1( context, cmbavDynamicfiltersselector2, cmbavDynamicfiltersselector2_Internalname, StringUtil.RTrim( AV19DynamicFiltersSelector2), 1, cmbavDynamicfiltersselector2_Jsonclick, 5, "'"+""+"'"+",false,"+"'"+"EVDYNAMICFILTERSSELECTOR2.CLICK."+"'", "svchar", "", 1, cmbavDynamicfiltersselector2.Enabled, 0, 0, 0, "em", 0, "", "", "Attribute", "", "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,65);\"", "", true, 1, "HLP_Configuracion\\TipoCambioWW.htm");
            cmbavDynamicfiltersselector2.CurrentValue = StringUtil.RTrim( AV19DynamicFiltersSelector2);
            AssignProp("", false, cmbavDynamicfiltersselector2_Internalname, "Values", (string)(cmbavDynamicfiltersselector2.ToJavascriptSource()), true);
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "Invisible", "left", "top", "", "flex-grow:1;", "div");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblDynamicfiltersmiddle2_Internalname, "valor", "", "", lblDynamicfiltersmiddle2_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "DataFilterDescription", 0, "", 1, 1, 0, 0, "HLP_Configuracion\\TipoCambioWW.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "Invisible", "left", "top", "", "flex-grow:1;", "div");
            wb_table3_69_1W2( true) ;
         }
         else
         {
            wb_table3_69_1W2( false) ;
         }
         return  ;
      }

      protected void wb_table3_69_1W2e( bool wbgen )
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
            GxWebStd.gx_label_ctrl( context, lblDynamicfiltersprefix3_Internalname, "Buscar en", "", "", lblDynamicfiltersprefix3_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "DataFilterDescriptionPrefix", 0, "", 1, 1, 0, 0, "HLP_Configuracion\\TipoCambioWW.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "Invisible", "left", "top", "", "flex-grow:1;", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "left", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, cmbavDynamicfiltersselector3_Internalname, "Dynamic Filters Selector3", "gx-form-item AttributeLabel", 0, true, "width: 25%;");
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 93,'',false,'" + sGXsfl_121_idx + "',0)\"";
            /* ComboBox */
            GxWebStd.gx_combobox_ctrl1( context, cmbavDynamicfiltersselector3, cmbavDynamicfiltersselector3_Internalname, StringUtil.RTrim( AV23DynamicFiltersSelector3), 1, cmbavDynamicfiltersselector3_Jsonclick, 5, "'"+""+"'"+",false,"+"'"+"EVDYNAMICFILTERSSELECTOR3.CLICK."+"'", "svchar", "", 1, cmbavDynamicfiltersselector3.Enabled, 0, 0, 0, "em", 0, "", "", "Attribute", "", "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,93);\"", "", true, 1, "HLP_Configuracion\\TipoCambioWW.htm");
            cmbavDynamicfiltersselector3.CurrentValue = StringUtil.RTrim( AV23DynamicFiltersSelector3);
            AssignProp("", false, cmbavDynamicfiltersselector3_Internalname, "Values", (string)(cmbavDynamicfiltersselector3.ToJavascriptSource()), true);
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "Invisible", "left", "top", "", "flex-grow:1;", "div");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblDynamicfiltersmiddle3_Internalname, "valor", "", "", lblDynamicfiltersmiddle3_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "DataFilterDescription", 0, "", 1, 1, 0, 0, "HLP_Configuracion\\TipoCambioWW.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "Invisible", "left", "top", "", "flex-grow:1;", "div");
            wb_table4_97_1W2( true) ;
         }
         else
         {
            wb_table4_97_1W2( false) ;
         }
         return  ;
      }

      protected void wb_table4_97_1W2e( bool wbgen )
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
            wb_table1_27_1W2e( true) ;
         }
         else
         {
            wb_table1_27_1W2e( false) ;
         }
      }

      protected void wb_table4_97_1W2( bool wbgen )
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
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 101,'',false,'" + sGXsfl_121_idx + "',0)\"";
            /* ComboBox */
            GxWebStd.gx_combobox_ctrl1( context, cmbavDynamicfiltersoperator3, cmbavDynamicfiltersoperator3_Internalname, StringUtil.Trim( StringUtil.Str( (decimal)(AV24DynamicFiltersOperator3), 4, 0)), 1, cmbavDynamicfiltersoperator3_Jsonclick, 5, "'"+""+"'"+",false,"+"'"+"EVDYNAMICFILTERSOPERATOR3.CLICK."+"'", "int", "", cmbavDynamicfiltersoperator3.Visible, cmbavDynamicfiltersoperator3.Enabled, 0, 0, 0, "em", 0, "", "", "Attribute", "", "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,101);\"", "", true, 1, "HLP_Configuracion\\TipoCambioWW.htm");
            cmbavDynamicfiltersoperator3.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV24DynamicFiltersOperator3), 4, 0));
            AssignProp("", false, cmbavDynamicfiltersoperator3_Internalname, "Values", (string)(cmbavDynamicfiltersoperator3.ToJavascriptSource()), true);
            GxWebStd.gx_div_end( context, "left", "top", "div");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "<td id=\""+cellFilter_mondsc3_cell_Internalname+"\"  class=''>") ;
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "left", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavMondsc3_Internalname, "Mon Dsc3", "gx-form-item AttributeLabel", 0, true, "width: 25%;");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 104,'',false,'" + sGXsfl_121_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavMondsc3_Internalname, StringUtil.RTrim( AV56MonDsc3), StringUtil.RTrim( context.localUtil.Format( AV56MonDsc3, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,104);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavMondsc3_Jsonclick, 0, "Attribute", "", "", "", "", edtavMondsc3_Visible, edtavMondsc3_Enabled, 0, "text", "", 80, "chr", 1, "row", 100, 0, 0, 0, 1, -1, -1, true, "", "left", true, "", "HLP_Configuracion\\TipoCambioWW.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "<td id=\""+cellFilter_tipfech3_cell_Internalname+"\"  class=''>") ;
            wb_table5_106_1W2( true) ;
         }
         else
         {
            wb_table5_106_1W2( false) ;
         }
         return  ;
      }

      protected void wb_table5_106_1W2e( bool wbgen )
      {
         if ( wbgen )
         {
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "<td id=\""+cellDynamicfilters_removefilter3_cell_Internalname+"\"  class=''>") ;
            /* Active images/pictures */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 112,'',false,'',0)\"";
            ClassString = "Image";
            StyleString = "";
            sImgUrl = (string)(context.GetImagePath( "11a6ef14-1a5a-4077-91a2-f41ed9a3a662", "", context.GetTheme( )));
            GxWebStd.gx_bitmap( context, imgRemovedynamicfilters3_Internalname, sImgUrl, "", "", "", context.GetTheme( ), 1, 1, "", "Quitar filtro", 0, 0, 0, "px", 0, "px", 0, 0, 5, imgRemovedynamicfilters3_Jsonclick, "'"+""+"'"+",false,"+"'"+"E\\'REMOVEDYNAMICFILTERS3\\'."+"'", StyleString, ClassString, "", "", "", "", " "+"data-gx-image"+" "+TempTags, "", "", 1, false, false, context.GetImageSrcSet( sImgUrl), "HLP_Configuracion\\TipoCambioWW.htm");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "</tr>") ;
            /* End of table */
            context.WriteHtmlText( "</table>") ;
            wb_table4_97_1W2e( true) ;
         }
         else
         {
            wb_table4_97_1W2e( false) ;
         }
      }

      protected void wb_table5_106_1W2( bool wbgen )
      {
         if ( wbgen )
         {
            /* Table start */
            sStyleString = "";
            if ( tblTablemergeddynamicfilterstipfech3_Visible == 0 )
            {
               sStyleString += "display:none;";
            }
            GxWebStd.gx_table_start( context, tblTablemergeddynamicfilterstipfech3_Internalname, tblTablemergeddynamicfilterstipfech3_Internalname, "", "TableMerged", 0, "", "", 0, 0, sStyleString, "", "", 0);
            context.WriteHtmlText( "<tr>") ;
            context.WriteHtmlText( "<td id=\""+cellTipfech_range_cell3_Internalname+"\"  class='"+cellTipfech_range_cell3_Class+"'>") ;
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "left", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavTipfech_rangetext3_Internalname, "Tip Fech_Range Text3", "gx-form-item AttributeLabel", 0, true, "width: 25%;");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 110,'',false,'" + sGXsfl_121_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavTipfech_rangetext3_Internalname, AV61TipFech_RangeText3, StringUtil.RTrim( context.localUtil.Format( AV61TipFech_RangeText3, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,110);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavTipfech_rangetext3_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtavTipfech_rangetext3_Enabled, 0, "text", "", 40, "chr", 1, "row", 40, 0, 0, 0, 1, -1, -1, true, "", "left", true, "", "HLP_Configuracion\\TipoCambioWW.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "</tr>") ;
            /* End of table */
            context.WriteHtmlText( "</table>") ;
            wb_table5_106_1W2e( true) ;
         }
         else
         {
            wb_table5_106_1W2e( false) ;
         }
      }

      protected void wb_table3_69_1W2( bool wbgen )
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
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 73,'',false,'" + sGXsfl_121_idx + "',0)\"";
            /* ComboBox */
            GxWebStd.gx_combobox_ctrl1( context, cmbavDynamicfiltersoperator2, cmbavDynamicfiltersoperator2_Internalname, StringUtil.Trim( StringUtil.Str( (decimal)(AV20DynamicFiltersOperator2), 4, 0)), 1, cmbavDynamicfiltersoperator2_Jsonclick, 5, "'"+""+"'"+",false,"+"'"+"EVDYNAMICFILTERSOPERATOR2.CLICK."+"'", "int", "", cmbavDynamicfiltersoperator2.Visible, cmbavDynamicfiltersoperator2.Enabled, 0, 0, 0, "em", 0, "", "", "Attribute", "", "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,73);\"", "", true, 1, "HLP_Configuracion\\TipoCambioWW.htm");
            cmbavDynamicfiltersoperator2.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV20DynamicFiltersOperator2), 4, 0));
            AssignProp("", false, cmbavDynamicfiltersoperator2_Internalname, "Values", (string)(cmbavDynamicfiltersoperator2.ToJavascriptSource()), true);
            GxWebStd.gx_div_end( context, "left", "top", "div");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "<td id=\""+cellFilter_mondsc2_cell_Internalname+"\"  class=''>") ;
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "left", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavMondsc2_Internalname, "Mon Dsc2", "gx-form-item AttributeLabel", 0, true, "width: 25%;");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 76,'',false,'" + sGXsfl_121_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavMondsc2_Internalname, StringUtil.RTrim( AV53MonDsc2), StringUtil.RTrim( context.localUtil.Format( AV53MonDsc2, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,76);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavMondsc2_Jsonclick, 0, "Attribute", "", "", "", "", edtavMondsc2_Visible, edtavMondsc2_Enabled, 0, "text", "", 80, "chr", 1, "row", 100, 0, 0, 0, 1, -1, -1, true, "", "left", true, "", "HLP_Configuracion\\TipoCambioWW.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "<td id=\""+cellFilter_tipfech2_cell_Internalname+"\"  class=''>") ;
            wb_table6_78_1W2( true) ;
         }
         else
         {
            wb_table6_78_1W2( false) ;
         }
         return  ;
      }

      protected void wb_table6_78_1W2e( bool wbgen )
      {
         if ( wbgen )
         {
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "<td id=\""+cellDynamicfilters_addfilter2_cell_Internalname+"\"  class=''>") ;
            /* Active images/pictures */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 84,'',false,'',0)\"";
            ClassString = "Image";
            StyleString = "";
            sImgUrl = (string)(context.GetImagePath( "27283ea5-332f-423b-b880-64b762622df3", "", context.GetTheme( )));
            GxWebStd.gx_bitmap( context, imgAdddynamicfilters2_Internalname, sImgUrl, "", "", "", context.GetTheme( ), imgAdddynamicfilters2_Visible, 1, "", "Agregar filtro", 0, 0, 0, "px", 0, "px", 0, 0, 5, imgAdddynamicfilters2_Jsonclick, "'"+""+"'"+",false,"+"'"+"E\\'ADDDYNAMICFILTERS2\\'."+"'", StyleString, ClassString, "", "", "", "", " "+"data-gx-image"+" "+TempTags, "", "", 1, false, false, context.GetImageSrcSet( sImgUrl), "HLP_Configuracion\\TipoCambioWW.htm");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "<td id=\""+cellDynamicfilters_removefilter2_cell_Internalname+"\"  class=''>") ;
            /* Active images/pictures */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 86,'',false,'',0)\"";
            ClassString = "Image";
            StyleString = "";
            sImgUrl = (string)(context.GetImagePath( "11a6ef14-1a5a-4077-91a2-f41ed9a3a662", "", context.GetTheme( )));
            GxWebStd.gx_bitmap( context, imgRemovedynamicfilters2_Internalname, sImgUrl, "", "", "", context.GetTheme( ), imgRemovedynamicfilters2_Visible, 1, "", "Quitar filtro", 0, 0, 0, "px", 0, "px", 0, 0, 5, imgRemovedynamicfilters2_Jsonclick, "'"+""+"'"+",false,"+"'"+"E\\'REMOVEDYNAMICFILTERS2\\'."+"'", StyleString, ClassString, "", "", "", "", " "+"data-gx-image"+" "+TempTags, "", "", 1, false, false, context.GetImageSrcSet( sImgUrl), "HLP_Configuracion\\TipoCambioWW.htm");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "</tr>") ;
            /* End of table */
            context.WriteHtmlText( "</table>") ;
            wb_table3_69_1W2e( true) ;
         }
         else
         {
            wb_table3_69_1W2e( false) ;
         }
      }

      protected void wb_table6_78_1W2( bool wbgen )
      {
         if ( wbgen )
         {
            /* Table start */
            sStyleString = "";
            if ( tblTablemergeddynamicfilterstipfech2_Visible == 0 )
            {
               sStyleString += "display:none;";
            }
            GxWebStd.gx_table_start( context, tblTablemergeddynamicfilterstipfech2_Internalname, tblTablemergeddynamicfilterstipfech2_Internalname, "", "TableMerged", 0, "", "", 0, 0, sStyleString, "", "", 0);
            context.WriteHtmlText( "<tr>") ;
            context.WriteHtmlText( "<td id=\""+cellTipfech_range_cell2_Internalname+"\"  class='"+cellTipfech_range_cell2_Class+"'>") ;
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "left", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavTipfech_rangetext2_Internalname, "Tip Fech_Range Text2", "gx-form-item AttributeLabel", 0, true, "width: 25%;");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 82,'',false,'" + sGXsfl_121_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavTipfech_rangetext2_Internalname, AV60TipFech_RangeText2, StringUtil.RTrim( context.localUtil.Format( AV60TipFech_RangeText2, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,82);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavTipfech_rangetext2_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtavTipfech_rangetext2_Enabled, 0, "text", "", 40, "chr", 1, "row", 40, 0, 0, 0, 1, -1, -1, true, "", "left", true, "", "HLP_Configuracion\\TipoCambioWW.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "</tr>") ;
            /* End of table */
            context.WriteHtmlText( "</table>") ;
            wb_table6_78_1W2e( true) ;
         }
         else
         {
            wb_table6_78_1W2e( false) ;
         }
      }

      protected void wb_table2_41_1W2( bool wbgen )
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
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 45,'',false,'" + sGXsfl_121_idx + "',0)\"";
            /* ComboBox */
            GxWebStd.gx_combobox_ctrl1( context, cmbavDynamicfiltersoperator1, cmbavDynamicfiltersoperator1_Internalname, StringUtil.Trim( StringUtil.Str( (decimal)(AV16DynamicFiltersOperator1), 4, 0)), 1, cmbavDynamicfiltersoperator1_Jsonclick, 5, "'"+""+"'"+",false,"+"'"+"EVDYNAMICFILTERSOPERATOR1.CLICK."+"'", "int", "", cmbavDynamicfiltersoperator1.Visible, cmbavDynamicfiltersoperator1.Enabled, 0, 0, 0, "em", 0, "", "", "Attribute", "", "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,45);\"", "", true, 1, "HLP_Configuracion\\TipoCambioWW.htm");
            cmbavDynamicfiltersoperator1.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV16DynamicFiltersOperator1), 4, 0));
            AssignProp("", false, cmbavDynamicfiltersoperator1_Internalname, "Values", (string)(cmbavDynamicfiltersoperator1.ToJavascriptSource()), true);
            GxWebStd.gx_div_end( context, "left", "top", "div");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "<td id=\""+cellFilter_mondsc1_cell_Internalname+"\"  class=''>") ;
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "left", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavMondsc1_Internalname, "Mon Dsc1", "gx-form-item AttributeLabel", 0, true, "width: 25%;");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 48,'',false,'" + sGXsfl_121_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavMondsc1_Internalname, StringUtil.RTrim( AV50MonDsc1), StringUtil.RTrim( context.localUtil.Format( AV50MonDsc1, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,48);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavMondsc1_Jsonclick, 0, "Attribute", "", "", "", "", edtavMondsc1_Visible, edtavMondsc1_Enabled, 0, "text", "", 80, "chr", 1, "row", 100, 0, 0, 0, 1, -1, -1, true, "", "left", true, "", "HLP_Configuracion\\TipoCambioWW.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "<td id=\""+cellFilter_tipfech1_cell_Internalname+"\"  class=''>") ;
            wb_table7_50_1W2( true) ;
         }
         else
         {
            wb_table7_50_1W2( false) ;
         }
         return  ;
      }

      protected void wb_table7_50_1W2e( bool wbgen )
      {
         if ( wbgen )
         {
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "<td id=\""+cellDynamicfilters_addfilter1_cell_Internalname+"\"  class=''>") ;
            /* Active images/pictures */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 56,'',false,'',0)\"";
            ClassString = "Image";
            StyleString = "";
            sImgUrl = (string)(context.GetImagePath( "27283ea5-332f-423b-b880-64b762622df3", "", context.GetTheme( )));
            GxWebStd.gx_bitmap( context, imgAdddynamicfilters1_Internalname, sImgUrl, "", "", "", context.GetTheme( ), imgAdddynamicfilters1_Visible, 1, "", "Agregar filtro", 0, 0, 0, "px", 0, "px", 0, 0, 5, imgAdddynamicfilters1_Jsonclick, "'"+""+"'"+",false,"+"'"+"E\\'ADDDYNAMICFILTERS1\\'."+"'", StyleString, ClassString, "", "", "", "", " "+"data-gx-image"+" "+TempTags, "", "", 1, false, false, context.GetImageSrcSet( sImgUrl), "HLP_Configuracion\\TipoCambioWW.htm");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "<td id=\""+cellDynamicfilters_removefilter1_cell_Internalname+"\"  class=''>") ;
            /* Active images/pictures */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 58,'',false,'',0)\"";
            ClassString = "Image";
            StyleString = "";
            sImgUrl = (string)(context.GetImagePath( "11a6ef14-1a5a-4077-91a2-f41ed9a3a662", "", context.GetTheme( )));
            GxWebStd.gx_bitmap( context, imgRemovedynamicfilters1_Internalname, sImgUrl, "", "", "", context.GetTheme( ), imgRemovedynamicfilters1_Visible, 1, "", "Quitar filtro", 0, 0, 0, "px", 0, "px", 0, 0, 5, imgRemovedynamicfilters1_Jsonclick, "'"+""+"'"+",false,"+"'"+"E\\'REMOVEDYNAMICFILTERS1\\'."+"'", StyleString, ClassString, "", "", "", "", " "+"data-gx-image"+" "+TempTags, "", "", 1, false, false, context.GetImageSrcSet( sImgUrl), "HLP_Configuracion\\TipoCambioWW.htm");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "</tr>") ;
            /* End of table */
            context.WriteHtmlText( "</table>") ;
            wb_table2_41_1W2e( true) ;
         }
         else
         {
            wb_table2_41_1W2e( false) ;
         }
      }

      protected void wb_table7_50_1W2( bool wbgen )
      {
         if ( wbgen )
         {
            /* Table start */
            sStyleString = "";
            if ( tblTablemergeddynamicfilterstipfech1_Visible == 0 )
            {
               sStyleString += "display:none;";
            }
            GxWebStd.gx_table_start( context, tblTablemergeddynamicfilterstipfech1_Internalname, tblTablemergeddynamicfilterstipfech1_Internalname, "", "TableMerged", 0, "", "", 0, 0, sStyleString, "", "", 0);
            context.WriteHtmlText( "<tr>") ;
            context.WriteHtmlText( "<td id=\""+cellTipfech_range_cell1_Internalname+"\"  class='"+cellTipfech_range_cell1_Class+"'>") ;
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "left", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavTipfech_rangetext1_Internalname, "Tip Fech_Range Text1", "gx-form-item AttributeLabel", 0, true, "width: 25%;");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 54,'',false,'" + sGXsfl_121_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavTipfech_rangetext1_Internalname, AV59TipFech_RangeText1, StringUtil.RTrim( context.localUtil.Format( AV59TipFech_RangeText1, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,54);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavTipfech_rangetext1_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtavTipfech_rangetext1_Enabled, 0, "text", "", 40, "chr", 1, "row", 40, 0, 0, 0, 1, -1, -1, true, "", "left", true, "", "HLP_Configuracion\\TipoCambioWW.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "</tr>") ;
            /* End of table */
            context.WriteHtmlText( "</table>") ;
            wb_table7_50_1W2e( true) ;
         }
         else
         {
            wb_table7_50_1W2e( false) ;
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
         PA1W2( ) ;
         WS1W2( ) ;
         WE1W2( ) ;
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
            context.AddJavascriptSource(StringUtil.RTrim( ((string)Form.Jscriptsrc.Item(idxLst))), "?20228181030153", true, true);
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
         context.AddJavascriptSource("configuracion/tipocambioww.js", "?20228181030153", false, true);
         context.AddJavascriptSource("DVelop/Bootstrap/Shared/DVelopBootstrap.js", "", false, true);
         context.AddJavascriptSource("DVelop/Shared/WorkWithPlusCommon.js", "", false, true);
         context.AddJavascriptSource("DVelop/Bootstrap/Panel/BootstrapPanelRender.js", "", false, true);
         context.AddJavascriptSource("DVelop/Bootstrap/Shared/DVelopBootstrap.js", "", false, true);
         context.AddJavascriptSource("DVelop/Shared/WorkWithPlusCommon.js", "", false, true);
         context.AddJavascriptSource("DVelop/DVPaginationBar/DVPaginationBarRender.js", "", false, true);
         context.AddJavascriptSource("Window/InNewWindowRender.js", "", false, true);
         context.AddJavascriptSource("DVelop/Bootstrap/Shared/DVelopBootstrap.js", "", false, true);
         context.AddJavascriptSource("DVelop/Shared/WorkWithPlusCommon.js", "", false, true);
         context.AddJavascriptSource("DVelop/Bootstrap/DropDownOptions/BootstrapDropDownOptionsRender.js", "", false, true);
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
         context.AddJavascriptSource("DVelop/Shared/daterangepicker/locales.js", "", false, true);
         context.AddJavascriptSource("DVelop/Shared/daterangepicker/wwp-daterangepicker.js", "", false, true);
         context.AddJavascriptSource("DVelop/Shared/daterangepicker/moment.min.js", "", false, true);
         context.AddJavascriptSource("DVelop/Shared/daterangepicker/daterangepicker.min.js", "", false, true);
         context.AddJavascriptSource("DVelop/Shared/WorkWithPlusCommon.js", "", false, true);
         context.AddJavascriptSource("DVelop/DateRangePicker/DateRangePickerRender.js", "", false, true);
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

      protected void SubsflControlProps_1212( )
      {
         cmbavGridactions_Internalname = "vGRIDACTIONS_"+sGXsfl_121_idx;
         edtTipMonCod_Internalname = "TIPMONCOD_"+sGXsfl_121_idx;
         edtMonDsc_Internalname = "MONDSC_"+sGXsfl_121_idx;
         edtTipFech_Internalname = "TIPFECH_"+sGXsfl_121_idx;
         edtTipCompra_Internalname = "TIPCOMPRA_"+sGXsfl_121_idx;
         edtTipVenta_Internalname = "TIPVENTA_"+sGXsfl_121_idx;
      }

      protected void SubsflControlProps_fel_1212( )
      {
         cmbavGridactions_Internalname = "vGRIDACTIONS_"+sGXsfl_121_fel_idx;
         edtTipMonCod_Internalname = "TIPMONCOD_"+sGXsfl_121_fel_idx;
         edtMonDsc_Internalname = "MONDSC_"+sGXsfl_121_fel_idx;
         edtTipFech_Internalname = "TIPFECH_"+sGXsfl_121_fel_idx;
         edtTipCompra_Internalname = "TIPCOMPRA_"+sGXsfl_121_fel_idx;
         edtTipVenta_Internalname = "TIPVENTA_"+sGXsfl_121_fel_idx;
      }

      protected void sendrow_1212( )
      {
         SubsflControlProps_1212( ) ;
         WB1W0( ) ;
         if ( ( subGrid_Rows * 1 == 0 ) || ( nGXsfl_121_idx <= subGrid_fnc_Recordsperpage( ) * 1 ) )
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
               if ( ((int)((nGXsfl_121_idx) % (2))) == 0 )
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
               context.WriteHtmlText( " gxrow=\""+sGXsfl_121_idx+"\">") ;
            }
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"right"+"\""+" style=\""+""+"\">") ;
            }
            TempTags = " " + ((cmbavGridactions.Enabled!=0)&&(cmbavGridactions.Visible!=0) ? " onfocus=\"gx.evt.onfocus(this, 122,'',false,'"+sGXsfl_121_idx+"',121)\"" : " ");
            if ( ( cmbavGridactions.ItemCount == 0 ) && isAjaxCallMode( ) )
            {
               GXCCtl = "vGRIDACTIONS_" + sGXsfl_121_idx;
               cmbavGridactions.Name = GXCCtl;
               cmbavGridactions.WebTags = "";
               if ( cmbavGridactions.ItemCount > 0 )
               {
                  AV45GridActions = (short)(NumberUtil.Val( cmbavGridactions.getValidValue(StringUtil.Trim( StringUtil.Str( (decimal)(AV45GridActions), 4, 0))), "."));
                  AssignAttri("", false, cmbavGridactions_Internalname, StringUtil.LTrimStr( (decimal)(AV45GridActions), 4, 0));
               }
            }
            /* ComboBox */
            GridRow.AddColumnProperties("combobox", 2, isAjaxCallMode( ), new Object[] {(GXCombobox)cmbavGridactions,(string)cmbavGridactions_Internalname,StringUtil.Trim( StringUtil.Str( (decimal)(AV45GridActions), 4, 0)),(short)1,(string)cmbavGridactions_Jsonclick,(short)5,"'"+""+"'"+",false,"+"'"+"EVGRIDACTIONS.CLICK."+sGXsfl_121_idx+"'",(string)"int",(string)"",(short)-1,(short)1,(short)0,(short)0,(short)0,(string)"px",(short)0,(string)"px",(string)"",(string)"ConvertToDDO",(string)"WWActionGroupColumn",(string)"",TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+((cmbavGridactions.Enabled!=0)&&(cmbavGridactions.Visible!=0) ? " onblur=\""+""+";gx.evt.onblur(this,122);\"" : " "),(string)"",(bool)true,(short)1});
            cmbavGridactions.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV45GridActions), 4, 0));
            AssignProp("", false, cmbavGridactions_Internalname, "Values", (string)(cmbavGridactions.ToJavascriptSource()), !bGXsfl_121_Refreshing);
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"right"+"\""+" style=\""+"display:none;"+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtTipMonCod_Internalname,StringUtil.LTrim( StringUtil.NToC( (decimal)(A307TipMonCod), 6, 0, ".", "")),StringUtil.LTrim( context.localUtil.Format( (decimal)(A307TipMonCod), "ZZZZZ9")),(string)" inputmode=\"numeric\" pattern=\"[0-9]*\""+"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtTipMonCod_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn hidden-xs",(string)"",(short)0,(short)0,(short)0,(string)"text",(string)"1",(short)0,(string)"px",(short)17,(string)"px",(short)6,(short)0,(short)0,(short)121,(short)1,(short)-1,(short)0,(bool)true,(string)"",(string)"right",(bool)false,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"left"+"\""+" style=\""+""+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtMonDsc_Internalname,StringUtil.RTrim( A1234MonDsc),(string)"",(string)"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)edtMonDsc_Link,(string)"",(string)"",(string)"",(string)edtMonDsc_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn",(string)"",(short)-1,(short)0,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)100,(short)0,(short)0,(short)121,(short)1,(short)-1,(short)-1,(bool)true,(string)"",(string)"left",(bool)true,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"right"+"\""+" style=\""+""+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtTipFech_Internalname,context.localUtil.Format(A308TipFech, "99/99/99"),context.localUtil.Format( A308TipFech, "99/99/99"),(string)"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtTipFech_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn hidden-xs",(string)"",(short)-1,(short)0,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)8,(short)0,(short)0,(short)121,(short)1,(short)-1,(short)0,(bool)true,(string)"",(string)"right",(bool)false,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"right"+"\""+" style=\""+""+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtTipCompra_Internalname,StringUtil.LTrim( StringUtil.NToC( A1907TipCompra, 15, 5, ".", "")),StringUtil.LTrim( context.localUtil.Format( A1907TipCompra, "ZZZZZZZZ9.99999")),(string)"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)edtTipCompra_Link,(string)"",(string)"",(string)"",(string)edtTipCompra_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn",(string)"",(short)-1,(short)0,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)15,(short)0,(short)0,(short)121,(short)1,(short)-1,(short)0,(bool)true,(string)"",(string)"right",(bool)false,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"right"+"\""+" style=\""+""+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtTipVenta_Internalname,StringUtil.LTrim( StringUtil.NToC( A1920TipVenta, 15, 5, ".", "")),StringUtil.LTrim( context.localUtil.Format( A1920TipVenta, "ZZZZZZZZ9.99999")),(string)"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtTipVenta_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn hidden-xs",(string)"",(short)-1,(short)0,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)15,(short)0,(short)0,(short)121,(short)1,(short)-1,(short)0,(bool)true,(string)"",(string)"right",(bool)false,(string)""});
            send_integrity_lvl_hashes1W2( ) ;
            GridContainer.AddRow(GridRow);
            nGXsfl_121_idx = ((subGrid_Islastpage==1)&&(nGXsfl_121_idx+1>subGrid_fnc_Recordsperpage( )) ? 1 : nGXsfl_121_idx+1);
            sGXsfl_121_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_121_idx), 4, 0), 4, "0");
            SubsflControlProps_1212( ) ;
         }
         /* End function sendrow_1212 */
      }

      protected void init_web_controls( )
      {
         cmbavDynamicfiltersselector1.Name = "vDYNAMICFILTERSSELECTOR1";
         cmbavDynamicfiltersselector1.WebTags = "";
         cmbavDynamicfiltersselector1.addItem("MONDSC", "Moneda", 0);
         cmbavDynamicfiltersselector1.addItem("TIPFECH", "Fecha", 0);
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
         cmbavDynamicfiltersselector2.addItem("MONDSC", "Moneda", 0);
         cmbavDynamicfiltersselector2.addItem("TIPFECH", "Fecha", 0);
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
         cmbavDynamicfiltersselector3.addItem("MONDSC", "Moneda", 0);
         cmbavDynamicfiltersselector3.addItem("TIPFECH", "Fecha", 0);
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
         GXCCtl = "vGRIDACTIONS_" + sGXsfl_121_idx;
         cmbavGridactions.Name = GXCCtl;
         cmbavGridactions.WebTags = "";
         if ( cmbavGridactions.ItemCount > 0 )
         {
            AV45GridActions = (short)(NumberUtil.Val( cmbavGridactions.getValidValue(StringUtil.Trim( StringUtil.Str( (decimal)(AV45GridActions), 4, 0))), "."));
            AssignAttri("", false, cmbavGridactions_Internalname, StringUtil.LTrimStr( (decimal)(AV45GridActions), 4, 0));
         }
         /* End function init_web_controls */
      }

      protected void init_default_properties( )
      {
         bttBtninsert_Internalname = "BTNINSERT";
         bttBtnagexport_Internalname = "BTNAGEXPORT";
         lblLinktipocambio_Internalname = "LINKTIPOCAMBIO";
         divTableactions_Internalname = "TABLEACTIONS";
         lblDynamicfiltersprefix1_Internalname = "DYNAMICFILTERSPREFIX1";
         cmbavDynamicfiltersselector1_Internalname = "vDYNAMICFILTERSSELECTOR1";
         lblDynamicfiltersmiddle1_Internalname = "DYNAMICFILTERSMIDDLE1";
         cmbavDynamicfiltersoperator1_Internalname = "vDYNAMICFILTERSOPERATOR1";
         edtavMondsc1_Internalname = "vMONDSC1";
         cellFilter_mondsc1_cell_Internalname = "FILTER_MONDSC1_CELL";
         edtavTipfech_rangetext1_Internalname = "vTIPFECH_RANGETEXT1";
         cellTipfech_range_cell1_Internalname = "TIPFECH_RANGE_CELL1";
         tblTablemergeddynamicfilterstipfech1_Internalname = "TABLEMERGEDDYNAMICFILTERSTIPFECH1";
         cellFilter_tipfech1_cell_Internalname = "FILTER_TIPFECH1_CELL";
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
         edtavMondsc2_Internalname = "vMONDSC2";
         cellFilter_mondsc2_cell_Internalname = "FILTER_MONDSC2_CELL";
         edtavTipfech_rangetext2_Internalname = "vTIPFECH_RANGETEXT2";
         cellTipfech_range_cell2_Internalname = "TIPFECH_RANGE_CELL2";
         tblTablemergeddynamicfilterstipfech2_Internalname = "TABLEMERGEDDYNAMICFILTERSTIPFECH2";
         cellFilter_tipfech2_cell_Internalname = "FILTER_TIPFECH2_CELL";
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
         edtavMondsc3_Internalname = "vMONDSC3";
         cellFilter_mondsc3_cell_Internalname = "FILTER_MONDSC3_CELL";
         edtavTipfech_rangetext3_Internalname = "vTIPFECH_RANGETEXT3";
         cellTipfech_range_cell3_Internalname = "TIPFECH_RANGE_CELL3";
         tblTablemergeddynamicfilterstipfech3_Internalname = "TABLEMERGEDDYNAMICFILTERSTIPFECH3";
         cellFilter_tipfech3_cell_Internalname = "FILTER_TIPFECH3_CELL";
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
         edtTipMonCod_Internalname = "TIPMONCOD";
         edtMonDsc_Internalname = "MONDSC";
         edtTipFech_Internalname = "TIPFECH";
         edtTipCompra_Internalname = "TIPCOMPRA";
         edtTipVenta_Internalname = "TIPVENTA";
         Gridpaginationbar_Internalname = "GRIDPAGINATIONBAR";
         divGridtablewithpaginationbar_Internalname = "GRIDTABLEWITHPAGINATIONBAR";
         Innewwindow_Internalname = "INNEWWINDOW";
         divTablemain_Internalname = "TABLEMAIN";
         Ddo_agexport_Internalname = "DDO_AGEXPORT";
         Tipfech_rangepicker1_Internalname = "TIPFECH_RANGEPICKER1";
         Tipfech_rangepicker2_Internalname = "TIPFECH_RANGEPICKER2";
         Tipfech_rangepicker3_Internalname = "TIPFECH_RANGEPICKER3";
         lblJsdynamicfilters_Internalname = "JSDYNAMICFILTERS";
         Ddo_grid_Internalname = "DDO_GRID";
         Innewwindow1_Internalname = "INNEWWINDOW1";
         Grid_empowerer_Internalname = "GRID_EMPOWERER";
         edtavDdo_tipfechauxdatetext_Internalname = "vDDO_TIPFECHAUXDATETEXT";
         Tftipfech_rangepicker_Internalname = "TFTIPFECH_RANGEPICKER";
         divDdo_tipfechauxdates_Internalname = "DDO_TIPFECHAUXDATES";
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
         edtTipVenta_Jsonclick = "";
         edtTipCompra_Jsonclick = "";
         edtTipFech_Jsonclick = "";
         edtMonDsc_Jsonclick = "";
         edtTipMonCod_Jsonclick = "";
         cmbavGridactions_Jsonclick = "";
         cmbavGridactions.Visible = -1;
         cmbavGridactions.Enabled = 1;
         edtavTipfech_rangetext1_Jsonclick = "";
         edtavTipfech_rangetext1_Enabled = 1;
         imgRemovedynamicfilters1_Visible = 1;
         imgAdddynamicfilters1_Visible = 1;
         edtavMondsc1_Jsonclick = "";
         edtavMondsc1_Enabled = 1;
         cmbavDynamicfiltersoperator1_Jsonclick = "";
         cmbavDynamicfiltersoperator1.Enabled = 1;
         edtavTipfech_rangetext2_Jsonclick = "";
         edtavTipfech_rangetext2_Enabled = 1;
         imgRemovedynamicfilters2_Visible = 1;
         imgAdddynamicfilters2_Visible = 1;
         edtavMondsc2_Jsonclick = "";
         edtavMondsc2_Enabled = 1;
         cmbavDynamicfiltersoperator2_Jsonclick = "";
         cmbavDynamicfiltersoperator2.Enabled = 1;
         edtavTipfech_rangetext3_Jsonclick = "";
         edtavTipfech_rangetext3_Enabled = 1;
         edtavMondsc3_Jsonclick = "";
         edtavMondsc3_Enabled = 1;
         cmbavDynamicfiltersoperator3_Jsonclick = "";
         cmbavDynamicfiltersoperator3.Enabled = 1;
         cmbavDynamicfiltersselector3_Jsonclick = "";
         cmbavDynamicfiltersselector3.Enabled = 1;
         cmbavDynamicfiltersselector2_Jsonclick = "";
         cmbavDynamicfiltersselector2.Enabled = 1;
         cmbavDynamicfiltersselector1_Jsonclick = "";
         cmbavDynamicfiltersselector1.Enabled = 1;
         cellTipfech_range_cell3_Class = "MergeDataCell";
         cmbavDynamicfiltersoperator3.Visible = 1;
         tblTablemergeddynamicfilterstipfech3_Visible = 1;
         edtavMondsc3_Visible = 1;
         cellTipfech_range_cell2_Class = "MergeDataCell";
         cmbavDynamicfiltersoperator2.Visible = 1;
         tblTablemergeddynamicfilterstipfech2_Visible = 1;
         edtavMondsc2_Visible = 1;
         cellTipfech_range_cell1_Class = "MergeDataCell";
         cmbavDynamicfiltersoperator1.Visible = 1;
         tblTablemergeddynamicfilterstipfech1_Visible = 1;
         edtavMondsc1_Visible = 1;
         edtavDdo_tipfechauxdatetext_Jsonclick = "";
         lblJsdynamicfilters_Caption = "JSDynamicFilters";
         subGrid_Allowcollapsing = 0;
         subGrid_Allowselection = 0;
         edtTipCompra_Link = "";
         edtMonDsc_Link = "";
         subGrid_Sortable = 0;
         subGrid_Header = "";
         subGrid_Class = "GridWithPaginationBar WorkWith";
         subGrid_Backcolorstyle = 0;
         Grid_empowerer_Hastitlesettings = Convert.ToBoolean( -1);
         Innewwindow1_Target = "";
         Innewwindow1_Height = "50";
         Innewwindow1_Width = "50";
         Ddo_grid_Datalistproc = "Configuracion.TipoCambioWWGetFilterData";
         Ddo_grid_Datalisttype = "Dynamic|||";
         Ddo_grid_Includedatalist = "T|||";
         Ddo_grid_Filterisrange = "|P|T|T";
         Ddo_grid_Filtertype = "Character|Date|Numeric|Numeric";
         Ddo_grid_Includefilter = "T";
         Ddo_grid_Includesortasc = "T";
         Ddo_grid_Columnssortvalues = "2|1|3|4";
         Ddo_grid_Columnids = "2:MonDsc|3:TipFech|4:TipCompra|5:TipVenta";
         Ddo_grid_Gridinternalname = "";
         Ddo_agexport_Titlecontrolidtoreplace = "";
         Ddo_agexport_Cls = "ColumnsSelector";
         Ddo_agexport_Icon = "fas fa-download";
         Ddo_agexport_Icontype = "FontIcon";
         Innewwindow_Toolbar = Convert.ToBoolean( -1);
         Innewwindow_Fullscreen = Convert.ToBoolean( 0);
         Innewwindow_Target = "";
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
         Form.Caption = "Tipos de Cambio";
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
         setEventMetadata("REFRESH","{handler:'Refresh',iparms:[{av:'GRID_nFirstRecordOnPage'},{av:'GRID_nEOF'},{av:'A180MonCod',fld:'MONCOD',pic:'ZZZZZ9'},{av:'cmbavDynamicfiltersselector1'},{av:'AV15DynamicFiltersSelector1',fld:'vDYNAMICFILTERSSELECTOR1',pic:''},{av:'AV18DynamicFiltersEnabled2',fld:'vDYNAMICFILTERSENABLED2',pic:''},{av:'cmbavDynamicfiltersselector2'},{av:'AV19DynamicFiltersSelector2',fld:'vDYNAMICFILTERSSELECTOR2',pic:''},{av:'AV22DynamicFiltersEnabled3',fld:'vDYNAMICFILTERSENABLED3',pic:''},{av:'cmbavDynamicfiltersselector3'},{av:'AV23DynamicFiltersSelector3',fld:'vDYNAMICFILTERSSELECTOR3',pic:''},{av:'subGrid_Rows',ctrl:'GRID',prop:'Rows'},{av:'cmbavDynamicfiltersoperator1'},{av:'AV16DynamicFiltersOperator1',fld:'vDYNAMICFILTERSOPERATOR1',pic:'ZZZ9'},{av:'AV50MonDsc1',fld:'vMONDSC1',pic:''},{av:'cmbavDynamicfiltersoperator2'},{av:'AV20DynamicFiltersOperator2',fld:'vDYNAMICFILTERSOPERATOR2',pic:'ZZZ9'},{av:'AV53MonDsc2',fld:'vMONDSC2',pic:''},{av:'cmbavDynamicfiltersoperator3'},{av:'AV24DynamicFiltersOperator3',fld:'vDYNAMICFILTERSOPERATOR3',pic:'ZZZ9'},{av:'AV56MonDsc3',fld:'vMONDSC3',pic:''},{av:'AV51TipFech1',fld:'vTIPFECH1',pic:''},{av:'AV54TipFech2',fld:'vTIPFECH2',pic:''},{av:'AV57TipFech3',fld:'vTIPFECH3',pic:''},{av:'AV64Pgmname',fld:'vPGMNAME',pic:'',hsh:true},{av:'AV52TipFech_To1',fld:'vTIPFECH_TO1',pic:''},{av:'AV55TipFech_To2',fld:'vTIPFECH_TO2',pic:''},{av:'AV58TipFech_To3',fld:'vTIPFECH_TO3',pic:''},{av:'AV48TFMonDsc',fld:'vTFMONDSC',pic:''},{av:'AV49TFMonDsc_Sel',fld:'vTFMONDSC_SEL',pic:''},{av:'AV31TFTipFech',fld:'vTFTIPFECH',pic:''},{av:'AV32TFTipFech_To',fld:'vTFTIPFECH_TO',pic:''},{av:'AV36TFTipCompra',fld:'vTFTIPCOMPRA',pic:'ZZZZZZZZ9.99999'},{av:'AV37TFTipCompra_To',fld:'vTFTIPCOMPRA_TO',pic:'ZZZZZZZZ9.99999'},{av:'AV38TFTipVenta',fld:'vTFTIPVENTA',pic:'ZZZZZZZZ9.99999'},{av:'AV39TFTipVenta_To',fld:'vTFTIPVENTA_TO',pic:'ZZZZZZZZ9.99999'},{av:'AV13OrderedBy',fld:'vORDEREDBY',pic:'ZZZ9'},{av:'AV14OrderedDsc',fld:'vORDEREDDSC',pic:''},{av:'AV10GridState',fld:'vGRIDSTATE',pic:''},{av:'AV27DynamicFiltersIgnoreFirst',fld:'vDYNAMICFILTERSIGNOREFIRST',pic:''},{av:'AV26DynamicFiltersRemoving',fld:'vDYNAMICFILTERSREMOVING',pic:''},{av:'Gx_date',fld:'vTODAY',pic:'',hsh:true}]");
         setEventMetadata("REFRESH",",oparms:[{av:'cmbavDynamicfiltersoperator1'},{av:'AV16DynamicFiltersOperator1',fld:'vDYNAMICFILTERSOPERATOR1',pic:'ZZZ9'},{av:'cmbavDynamicfiltersoperator2'},{av:'AV20DynamicFiltersOperator2',fld:'vDYNAMICFILTERSOPERATOR2',pic:'ZZZ9'},{av:'cmbavDynamicfiltersoperator3'},{av:'AV24DynamicFiltersOperator3',fld:'vDYNAMICFILTERSOPERATOR3',pic:'ZZZ9'},{av:'AV42GridCurrentPage',fld:'vGRIDCURRENTPAGE',pic:'ZZZZZZZZZ9'},{av:'AV43GridPageCount',fld:'vGRIDPAGECOUNT',pic:'ZZZZZZZZZ9'},{av:'AV44GridAppliedFilters',fld:'vGRIDAPPLIEDFILTERS',pic:''},{av:'AV10GridState',fld:'vGRIDSTATE',pic:''}]}");
         setEventMetadata("GRIDPAGINATIONBAR.CHANGEPAGE","{handler:'E121W2',iparms:[{av:'GRID_nFirstRecordOnPage'},{av:'GRID_nEOF'},{av:'subGrid_Rows',ctrl:'GRID',prop:'Rows'},{av:'cmbavDynamicfiltersselector1'},{av:'AV15DynamicFiltersSelector1',fld:'vDYNAMICFILTERSSELECTOR1',pic:''},{av:'cmbavDynamicfiltersoperator1'},{av:'AV16DynamicFiltersOperator1',fld:'vDYNAMICFILTERSOPERATOR1',pic:'ZZZ9'},{av:'AV50MonDsc1',fld:'vMONDSC1',pic:''},{av:'cmbavDynamicfiltersselector2'},{av:'AV19DynamicFiltersSelector2',fld:'vDYNAMICFILTERSSELECTOR2',pic:''},{av:'cmbavDynamicfiltersoperator2'},{av:'AV20DynamicFiltersOperator2',fld:'vDYNAMICFILTERSOPERATOR2',pic:'ZZZ9'},{av:'AV53MonDsc2',fld:'vMONDSC2',pic:''},{av:'cmbavDynamicfiltersselector3'},{av:'AV23DynamicFiltersSelector3',fld:'vDYNAMICFILTERSSELECTOR3',pic:''},{av:'cmbavDynamicfiltersoperator3'},{av:'AV24DynamicFiltersOperator3',fld:'vDYNAMICFILTERSOPERATOR3',pic:'ZZZ9'},{av:'AV56MonDsc3',fld:'vMONDSC3',pic:''},{av:'AV51TipFech1',fld:'vTIPFECH1',pic:''},{av:'AV54TipFech2',fld:'vTIPFECH2',pic:''},{av:'AV57TipFech3',fld:'vTIPFECH3',pic:''},{av:'AV18DynamicFiltersEnabled2',fld:'vDYNAMICFILTERSENABLED2',pic:''},{av:'AV22DynamicFiltersEnabled3',fld:'vDYNAMICFILTERSENABLED3',pic:''},{av:'AV64Pgmname',fld:'vPGMNAME',pic:'',hsh:true},{av:'AV52TipFech_To1',fld:'vTIPFECH_TO1',pic:''},{av:'AV55TipFech_To2',fld:'vTIPFECH_TO2',pic:''},{av:'AV58TipFech_To3',fld:'vTIPFECH_TO3',pic:''},{av:'AV48TFMonDsc',fld:'vTFMONDSC',pic:''},{av:'AV49TFMonDsc_Sel',fld:'vTFMONDSC_SEL',pic:''},{av:'AV31TFTipFech',fld:'vTFTIPFECH',pic:''},{av:'AV32TFTipFech_To',fld:'vTFTIPFECH_TO',pic:''},{av:'AV36TFTipCompra',fld:'vTFTIPCOMPRA',pic:'ZZZZZZZZ9.99999'},{av:'AV37TFTipCompra_To',fld:'vTFTIPCOMPRA_TO',pic:'ZZZZZZZZ9.99999'},{av:'AV38TFTipVenta',fld:'vTFTIPVENTA',pic:'ZZZZZZZZ9.99999'},{av:'AV39TFTipVenta_To',fld:'vTFTIPVENTA_TO',pic:'ZZZZZZZZ9.99999'},{av:'AV13OrderedBy',fld:'vORDEREDBY',pic:'ZZZ9'},{av:'AV14OrderedDsc',fld:'vORDEREDDSC',pic:''},{av:'AV10GridState',fld:'vGRIDSTATE',pic:''},{av:'AV27DynamicFiltersIgnoreFirst',fld:'vDYNAMICFILTERSIGNOREFIRST',pic:''},{av:'AV26DynamicFiltersRemoving',fld:'vDYNAMICFILTERSREMOVING',pic:''},{av:'A180MonCod',fld:'MONCOD',pic:'ZZZZZ9'},{av:'Gx_date',fld:'vTODAY',pic:'',hsh:true},{av:'Gridpaginationbar_Selectedpage',ctrl:'GRIDPAGINATIONBAR',prop:'SelectedPage'}]");
         setEventMetadata("GRIDPAGINATIONBAR.CHANGEPAGE",",oparms:[]}");
         setEventMetadata("GRIDPAGINATIONBAR.CHANGEROWSPERPAGE","{handler:'E131W2',iparms:[{av:'GRID_nFirstRecordOnPage'},{av:'GRID_nEOF'},{av:'subGrid_Rows',ctrl:'GRID',prop:'Rows'},{av:'cmbavDynamicfiltersselector1'},{av:'AV15DynamicFiltersSelector1',fld:'vDYNAMICFILTERSSELECTOR1',pic:''},{av:'cmbavDynamicfiltersoperator1'},{av:'AV16DynamicFiltersOperator1',fld:'vDYNAMICFILTERSOPERATOR1',pic:'ZZZ9'},{av:'AV50MonDsc1',fld:'vMONDSC1',pic:''},{av:'cmbavDynamicfiltersselector2'},{av:'AV19DynamicFiltersSelector2',fld:'vDYNAMICFILTERSSELECTOR2',pic:''},{av:'cmbavDynamicfiltersoperator2'},{av:'AV20DynamicFiltersOperator2',fld:'vDYNAMICFILTERSOPERATOR2',pic:'ZZZ9'},{av:'AV53MonDsc2',fld:'vMONDSC2',pic:''},{av:'cmbavDynamicfiltersselector3'},{av:'AV23DynamicFiltersSelector3',fld:'vDYNAMICFILTERSSELECTOR3',pic:''},{av:'cmbavDynamicfiltersoperator3'},{av:'AV24DynamicFiltersOperator3',fld:'vDYNAMICFILTERSOPERATOR3',pic:'ZZZ9'},{av:'AV56MonDsc3',fld:'vMONDSC3',pic:''},{av:'AV51TipFech1',fld:'vTIPFECH1',pic:''},{av:'AV54TipFech2',fld:'vTIPFECH2',pic:''},{av:'AV57TipFech3',fld:'vTIPFECH3',pic:''},{av:'AV18DynamicFiltersEnabled2',fld:'vDYNAMICFILTERSENABLED2',pic:''},{av:'AV22DynamicFiltersEnabled3',fld:'vDYNAMICFILTERSENABLED3',pic:''},{av:'AV64Pgmname',fld:'vPGMNAME',pic:'',hsh:true},{av:'AV52TipFech_To1',fld:'vTIPFECH_TO1',pic:''},{av:'AV55TipFech_To2',fld:'vTIPFECH_TO2',pic:''},{av:'AV58TipFech_To3',fld:'vTIPFECH_TO3',pic:''},{av:'AV48TFMonDsc',fld:'vTFMONDSC',pic:''},{av:'AV49TFMonDsc_Sel',fld:'vTFMONDSC_SEL',pic:''},{av:'AV31TFTipFech',fld:'vTFTIPFECH',pic:''},{av:'AV32TFTipFech_To',fld:'vTFTIPFECH_TO',pic:''},{av:'AV36TFTipCompra',fld:'vTFTIPCOMPRA',pic:'ZZZZZZZZ9.99999'},{av:'AV37TFTipCompra_To',fld:'vTFTIPCOMPRA_TO',pic:'ZZZZZZZZ9.99999'},{av:'AV38TFTipVenta',fld:'vTFTIPVENTA',pic:'ZZZZZZZZ9.99999'},{av:'AV39TFTipVenta_To',fld:'vTFTIPVENTA_TO',pic:'ZZZZZZZZ9.99999'},{av:'AV13OrderedBy',fld:'vORDEREDBY',pic:'ZZZ9'},{av:'AV14OrderedDsc',fld:'vORDEREDDSC',pic:''},{av:'AV10GridState',fld:'vGRIDSTATE',pic:''},{av:'AV27DynamicFiltersIgnoreFirst',fld:'vDYNAMICFILTERSIGNOREFIRST',pic:''},{av:'AV26DynamicFiltersRemoving',fld:'vDYNAMICFILTERSREMOVING',pic:''},{av:'A180MonCod',fld:'MONCOD',pic:'ZZZZZ9'},{av:'Gx_date',fld:'vTODAY',pic:'',hsh:true},{av:'Gridpaginationbar_Rowsperpageselectedvalue',ctrl:'GRIDPAGINATIONBAR',prop:'RowsPerPageSelectedValue'}]");
         setEventMetadata("GRIDPAGINATIONBAR.CHANGEROWSPERPAGE",",oparms:[{av:'subGrid_Rows',ctrl:'GRID',prop:'Rows'}]}");
         setEventMetadata("DDO_GRID.ONOPTIONCLICKED","{handler:'E181W2',iparms:[{av:'GRID_nFirstRecordOnPage'},{av:'GRID_nEOF'},{av:'subGrid_Rows',ctrl:'GRID',prop:'Rows'},{av:'cmbavDynamicfiltersselector1'},{av:'AV15DynamicFiltersSelector1',fld:'vDYNAMICFILTERSSELECTOR1',pic:''},{av:'cmbavDynamicfiltersoperator1'},{av:'AV16DynamicFiltersOperator1',fld:'vDYNAMICFILTERSOPERATOR1',pic:'ZZZ9'},{av:'AV50MonDsc1',fld:'vMONDSC1',pic:''},{av:'cmbavDynamicfiltersselector2'},{av:'AV19DynamicFiltersSelector2',fld:'vDYNAMICFILTERSSELECTOR2',pic:''},{av:'cmbavDynamicfiltersoperator2'},{av:'AV20DynamicFiltersOperator2',fld:'vDYNAMICFILTERSOPERATOR2',pic:'ZZZ9'},{av:'AV53MonDsc2',fld:'vMONDSC2',pic:''},{av:'cmbavDynamicfiltersselector3'},{av:'AV23DynamicFiltersSelector3',fld:'vDYNAMICFILTERSSELECTOR3',pic:''},{av:'cmbavDynamicfiltersoperator3'},{av:'AV24DynamicFiltersOperator3',fld:'vDYNAMICFILTERSOPERATOR3',pic:'ZZZ9'},{av:'AV56MonDsc3',fld:'vMONDSC3',pic:''},{av:'AV51TipFech1',fld:'vTIPFECH1',pic:''},{av:'AV54TipFech2',fld:'vTIPFECH2',pic:''},{av:'AV57TipFech3',fld:'vTIPFECH3',pic:''},{av:'AV18DynamicFiltersEnabled2',fld:'vDYNAMICFILTERSENABLED2',pic:''},{av:'AV22DynamicFiltersEnabled3',fld:'vDYNAMICFILTERSENABLED3',pic:''},{av:'AV64Pgmname',fld:'vPGMNAME',pic:'',hsh:true},{av:'AV52TipFech_To1',fld:'vTIPFECH_TO1',pic:''},{av:'AV55TipFech_To2',fld:'vTIPFECH_TO2',pic:''},{av:'AV58TipFech_To3',fld:'vTIPFECH_TO3',pic:''},{av:'AV48TFMonDsc',fld:'vTFMONDSC',pic:''},{av:'AV49TFMonDsc_Sel',fld:'vTFMONDSC_SEL',pic:''},{av:'AV31TFTipFech',fld:'vTFTIPFECH',pic:''},{av:'AV32TFTipFech_To',fld:'vTFTIPFECH_TO',pic:''},{av:'AV36TFTipCompra',fld:'vTFTIPCOMPRA',pic:'ZZZZZZZZ9.99999'},{av:'AV37TFTipCompra_To',fld:'vTFTIPCOMPRA_TO',pic:'ZZZZZZZZ9.99999'},{av:'AV38TFTipVenta',fld:'vTFTIPVENTA',pic:'ZZZZZZZZ9.99999'},{av:'AV39TFTipVenta_To',fld:'vTFTIPVENTA_TO',pic:'ZZZZZZZZ9.99999'},{av:'AV13OrderedBy',fld:'vORDEREDBY',pic:'ZZZ9'},{av:'AV14OrderedDsc',fld:'vORDEREDDSC',pic:''},{av:'AV10GridState',fld:'vGRIDSTATE',pic:''},{av:'AV27DynamicFiltersIgnoreFirst',fld:'vDYNAMICFILTERSIGNOREFIRST',pic:''},{av:'AV26DynamicFiltersRemoving',fld:'vDYNAMICFILTERSREMOVING',pic:''},{av:'A180MonCod',fld:'MONCOD',pic:'ZZZZZ9'},{av:'Gx_date',fld:'vTODAY',pic:'',hsh:true},{av:'Ddo_grid_Activeeventkey',ctrl:'DDO_GRID',prop:'ActiveEventKey'},{av:'Ddo_grid_Selectedvalue_get',ctrl:'DDO_GRID',prop:'SelectedValue_get'},{av:'Ddo_grid_Selectedcolumn',ctrl:'DDO_GRID',prop:'SelectedColumn'},{av:'Ddo_grid_Filteredtext_get',ctrl:'DDO_GRID',prop:'FilteredText_get'},{av:'Ddo_grid_Filteredtextto_get',ctrl:'DDO_GRID',prop:'FilteredTextTo_get'}]");
         setEventMetadata("DDO_GRID.ONOPTIONCLICKED",",oparms:[{av:'AV13OrderedBy',fld:'vORDEREDBY',pic:'ZZZ9'},{av:'AV14OrderedDsc',fld:'vORDEREDDSC',pic:''},{av:'AV48TFMonDsc',fld:'vTFMONDSC',pic:''},{av:'AV49TFMonDsc_Sel',fld:'vTFMONDSC_SEL',pic:''},{av:'AV31TFTipFech',fld:'vTFTIPFECH',pic:''},{av:'AV32TFTipFech_To',fld:'vTFTIPFECH_TO',pic:''},{av:'AV36TFTipCompra',fld:'vTFTIPCOMPRA',pic:'ZZZZZZZZ9.99999'},{av:'AV37TFTipCompra_To',fld:'vTFTIPCOMPRA_TO',pic:'ZZZZZZZZ9.99999'},{av:'AV38TFTipVenta',fld:'vTFTIPVENTA',pic:'ZZZZZZZZ9.99999'},{av:'AV39TFTipVenta_To',fld:'vTFTIPVENTA_TO',pic:'ZZZZZZZZ9.99999'},{av:'Ddo_grid_Sortedstatus',ctrl:'DDO_GRID',prop:'SortedStatus'}]}");
         setEventMetadata("GRID.LOAD","{handler:'E331W2',iparms:[{av:'A180MonCod',fld:'MONCOD',pic:'ZZZZZ9'},{av:'A307TipMonCod',fld:'TIPMONCOD',pic:'ZZZZZ9',hsh:true},{av:'A308TipFech',fld:'TIPFECH',pic:'',hsh:true}]");
         setEventMetadata("GRID.LOAD",",oparms:[{av:'cmbavGridactions'},{av:'AV45GridActions',fld:'vGRIDACTIONS',pic:'ZZZ9'},{av:'edtMonDsc_Link',ctrl:'MONDSC',prop:'Link'},{av:'edtTipCompra_Link',ctrl:'TIPCOMPRA',prop:'Link'}]}");
         setEventMetadata("'ADDDYNAMICFILTERS1'","{handler:'E231W2',iparms:[{av:'GRID_nFirstRecordOnPage'},{av:'GRID_nEOF'},{av:'subGrid_Rows',ctrl:'GRID',prop:'Rows'},{av:'cmbavDynamicfiltersselector1'},{av:'AV15DynamicFiltersSelector1',fld:'vDYNAMICFILTERSSELECTOR1',pic:''},{av:'cmbavDynamicfiltersoperator1'},{av:'AV16DynamicFiltersOperator1',fld:'vDYNAMICFILTERSOPERATOR1',pic:'ZZZ9'},{av:'AV50MonDsc1',fld:'vMONDSC1',pic:''},{av:'cmbavDynamicfiltersselector2'},{av:'AV19DynamicFiltersSelector2',fld:'vDYNAMICFILTERSSELECTOR2',pic:''},{av:'cmbavDynamicfiltersoperator2'},{av:'AV20DynamicFiltersOperator2',fld:'vDYNAMICFILTERSOPERATOR2',pic:'ZZZ9'},{av:'AV53MonDsc2',fld:'vMONDSC2',pic:''},{av:'cmbavDynamicfiltersselector3'},{av:'AV23DynamicFiltersSelector3',fld:'vDYNAMICFILTERSSELECTOR3',pic:''},{av:'cmbavDynamicfiltersoperator3'},{av:'AV24DynamicFiltersOperator3',fld:'vDYNAMICFILTERSOPERATOR3',pic:'ZZZ9'},{av:'AV56MonDsc3',fld:'vMONDSC3',pic:''},{av:'AV51TipFech1',fld:'vTIPFECH1',pic:''},{av:'AV54TipFech2',fld:'vTIPFECH2',pic:''},{av:'AV57TipFech3',fld:'vTIPFECH3',pic:''},{av:'AV18DynamicFiltersEnabled2',fld:'vDYNAMICFILTERSENABLED2',pic:''},{av:'AV22DynamicFiltersEnabled3',fld:'vDYNAMICFILTERSENABLED3',pic:''},{av:'AV64Pgmname',fld:'vPGMNAME',pic:'',hsh:true},{av:'AV52TipFech_To1',fld:'vTIPFECH_TO1',pic:''},{av:'AV55TipFech_To2',fld:'vTIPFECH_TO2',pic:''},{av:'AV58TipFech_To3',fld:'vTIPFECH_TO3',pic:''},{av:'AV48TFMonDsc',fld:'vTFMONDSC',pic:''},{av:'AV49TFMonDsc_Sel',fld:'vTFMONDSC_SEL',pic:''},{av:'AV31TFTipFech',fld:'vTFTIPFECH',pic:''},{av:'AV32TFTipFech_To',fld:'vTFTIPFECH_TO',pic:''},{av:'AV36TFTipCompra',fld:'vTFTIPCOMPRA',pic:'ZZZZZZZZ9.99999'},{av:'AV37TFTipCompra_To',fld:'vTFTIPCOMPRA_TO',pic:'ZZZZZZZZ9.99999'},{av:'AV38TFTipVenta',fld:'vTFTIPVENTA',pic:'ZZZZZZZZ9.99999'},{av:'AV39TFTipVenta_To',fld:'vTFTIPVENTA_TO',pic:'ZZZZZZZZ9.99999'},{av:'AV13OrderedBy',fld:'vORDEREDBY',pic:'ZZZ9'},{av:'AV14OrderedDsc',fld:'vORDEREDDSC',pic:''},{av:'AV10GridState',fld:'vGRIDSTATE',pic:''},{av:'AV27DynamicFiltersIgnoreFirst',fld:'vDYNAMICFILTERSIGNOREFIRST',pic:''},{av:'AV26DynamicFiltersRemoving',fld:'vDYNAMICFILTERSREMOVING',pic:''},{av:'A180MonCod',fld:'MONCOD',pic:'ZZZZZ9'},{av:'Gx_date',fld:'vTODAY',pic:'',hsh:true}]");
         setEventMetadata("'ADDDYNAMICFILTERS1'",",oparms:[{av:'AV18DynamicFiltersEnabled2',fld:'vDYNAMICFILTERSENABLED2',pic:''},{av:'imgAdddynamicfilters1_Visible',ctrl:'ADDDYNAMICFILTERS1',prop:'Visible'},{av:'imgRemovedynamicfilters1_Visible',ctrl:'REMOVEDYNAMICFILTERS1',prop:'Visible'},{av:'cmbavDynamicfiltersoperator1'},{av:'AV16DynamicFiltersOperator1',fld:'vDYNAMICFILTERSOPERATOR1',pic:'ZZZ9'},{av:'cmbavDynamicfiltersoperator2'},{av:'AV20DynamicFiltersOperator2',fld:'vDYNAMICFILTERSOPERATOR2',pic:'ZZZ9'},{av:'cmbavDynamicfiltersoperator3'},{av:'AV24DynamicFiltersOperator3',fld:'vDYNAMICFILTERSOPERATOR3',pic:'ZZZ9'},{av:'AV42GridCurrentPage',fld:'vGRIDCURRENTPAGE',pic:'ZZZZZZZZZ9'},{av:'AV43GridPageCount',fld:'vGRIDPAGECOUNT',pic:'ZZZZZZZZZ9'},{av:'AV44GridAppliedFilters',fld:'vGRIDAPPLIEDFILTERS',pic:''},{av:'AV10GridState',fld:'vGRIDSTATE',pic:''}]}");
         setEventMetadata("'REMOVEDYNAMICFILTERS1'","{handler:'E191W2',iparms:[{av:'GRID_nFirstRecordOnPage'},{av:'GRID_nEOF'},{av:'subGrid_Rows',ctrl:'GRID',prop:'Rows'},{av:'cmbavDynamicfiltersselector1'},{av:'AV15DynamicFiltersSelector1',fld:'vDYNAMICFILTERSSELECTOR1',pic:''},{av:'cmbavDynamicfiltersoperator1'},{av:'AV16DynamicFiltersOperator1',fld:'vDYNAMICFILTERSOPERATOR1',pic:'ZZZ9'},{av:'AV50MonDsc1',fld:'vMONDSC1',pic:''},{av:'cmbavDynamicfiltersselector2'},{av:'AV19DynamicFiltersSelector2',fld:'vDYNAMICFILTERSSELECTOR2',pic:''},{av:'cmbavDynamicfiltersoperator2'},{av:'AV20DynamicFiltersOperator2',fld:'vDYNAMICFILTERSOPERATOR2',pic:'ZZZ9'},{av:'AV53MonDsc2',fld:'vMONDSC2',pic:''},{av:'cmbavDynamicfiltersselector3'},{av:'AV23DynamicFiltersSelector3',fld:'vDYNAMICFILTERSSELECTOR3',pic:''},{av:'cmbavDynamicfiltersoperator3'},{av:'AV24DynamicFiltersOperator3',fld:'vDYNAMICFILTERSOPERATOR3',pic:'ZZZ9'},{av:'AV56MonDsc3',fld:'vMONDSC3',pic:''},{av:'AV51TipFech1',fld:'vTIPFECH1',pic:''},{av:'AV54TipFech2',fld:'vTIPFECH2',pic:''},{av:'AV57TipFech3',fld:'vTIPFECH3',pic:''},{av:'AV18DynamicFiltersEnabled2',fld:'vDYNAMICFILTERSENABLED2',pic:''},{av:'AV22DynamicFiltersEnabled3',fld:'vDYNAMICFILTERSENABLED3',pic:''},{av:'AV64Pgmname',fld:'vPGMNAME',pic:'',hsh:true},{av:'AV52TipFech_To1',fld:'vTIPFECH_TO1',pic:''},{av:'AV55TipFech_To2',fld:'vTIPFECH_TO2',pic:''},{av:'AV58TipFech_To3',fld:'vTIPFECH_TO3',pic:''},{av:'AV48TFMonDsc',fld:'vTFMONDSC',pic:''},{av:'AV49TFMonDsc_Sel',fld:'vTFMONDSC_SEL',pic:''},{av:'AV31TFTipFech',fld:'vTFTIPFECH',pic:''},{av:'AV32TFTipFech_To',fld:'vTFTIPFECH_TO',pic:''},{av:'AV36TFTipCompra',fld:'vTFTIPCOMPRA',pic:'ZZZZZZZZ9.99999'},{av:'AV37TFTipCompra_To',fld:'vTFTIPCOMPRA_TO',pic:'ZZZZZZZZ9.99999'},{av:'AV38TFTipVenta',fld:'vTFTIPVENTA',pic:'ZZZZZZZZ9.99999'},{av:'AV39TFTipVenta_To',fld:'vTFTIPVENTA_TO',pic:'ZZZZZZZZ9.99999'},{av:'AV13OrderedBy',fld:'vORDEREDBY',pic:'ZZZ9'},{av:'AV14OrderedDsc',fld:'vORDEREDDSC',pic:''},{av:'AV10GridState',fld:'vGRIDSTATE',pic:''},{av:'AV27DynamicFiltersIgnoreFirst',fld:'vDYNAMICFILTERSIGNOREFIRST',pic:''},{av:'AV26DynamicFiltersRemoving',fld:'vDYNAMICFILTERSREMOVING',pic:''},{av:'A180MonCod',fld:'MONCOD',pic:'ZZZZZ9'},{av:'Gx_date',fld:'vTODAY',pic:'',hsh:true}]");
         setEventMetadata("'REMOVEDYNAMICFILTERS1'",",oparms:[{av:'AV26DynamicFiltersRemoving',fld:'vDYNAMICFILTERSREMOVING',pic:''},{av:'AV27DynamicFiltersIgnoreFirst',fld:'vDYNAMICFILTERSIGNOREFIRST',pic:''},{av:'AV10GridState',fld:'vGRIDSTATE',pic:''},{av:'AV18DynamicFiltersEnabled2',fld:'vDYNAMICFILTERSENABLED2',pic:''},{av:'cmbavDynamicfiltersselector2'},{av:'AV19DynamicFiltersSelector2',fld:'vDYNAMICFILTERSSELECTOR2',pic:''},{av:'cmbavDynamicfiltersoperator2'},{av:'AV20DynamicFiltersOperator2',fld:'vDYNAMICFILTERSOPERATOR2',pic:'ZZZ9'},{av:'AV53MonDsc2',fld:'vMONDSC2',pic:''},{av:'AV22DynamicFiltersEnabled3',fld:'vDYNAMICFILTERSENABLED3',pic:''},{av:'cmbavDynamicfiltersselector3'},{av:'AV23DynamicFiltersSelector3',fld:'vDYNAMICFILTERSSELECTOR3',pic:''},{av:'cmbavDynamicfiltersoperator3'},{av:'AV24DynamicFiltersOperator3',fld:'vDYNAMICFILTERSOPERATOR3',pic:'ZZZ9'},{av:'AV56MonDsc3',fld:'vMONDSC3',pic:''},{av:'imgAdddynamicfilters1_Visible',ctrl:'ADDDYNAMICFILTERS1',prop:'Visible'},{av:'imgRemovedynamicfilters1_Visible',ctrl:'REMOVEDYNAMICFILTERS1',prop:'Visible'},{av:'imgAdddynamicfilters2_Visible',ctrl:'ADDDYNAMICFILTERS2',prop:'Visible'},{av:'imgRemovedynamicfilters2_Visible',ctrl:'REMOVEDYNAMICFILTERS2',prop:'Visible'},{av:'cmbavDynamicfiltersselector1'},{av:'AV15DynamicFiltersSelector1',fld:'vDYNAMICFILTERSSELECTOR1',pic:''},{av:'cmbavDynamicfiltersoperator1'},{av:'AV16DynamicFiltersOperator1',fld:'vDYNAMICFILTERSOPERATOR1',pic:'ZZZ9'},{av:'AV50MonDsc1',fld:'vMONDSC1',pic:''},{av:'AV51TipFech1',fld:'vTIPFECH1',pic:''},{av:'AV52TipFech_To1',fld:'vTIPFECH_TO1',pic:''},{av:'lblJsdynamicfilters_Caption',ctrl:'JSDYNAMICFILTERS',prop:'Caption'},{av:'AV54TipFech2',fld:'vTIPFECH2',pic:''},{av:'AV55TipFech_To2',fld:'vTIPFECH_TO2',pic:''},{av:'AV57TipFech3',fld:'vTIPFECH3',pic:''},{av:'AV58TipFech_To3',fld:'vTIPFECH_TO3',pic:''},{av:'edtavMondsc2_Visible',ctrl:'vMONDSC2',prop:'Visible'},{av:'tblTablemergeddynamicfilterstipfech2_Visible',ctrl:'TABLEMERGEDDYNAMICFILTERSTIPFECH2',prop:'Visible'},{av:'edtavMondsc3_Visible',ctrl:'vMONDSC3',prop:'Visible'},{av:'tblTablemergeddynamicfilterstipfech3_Visible',ctrl:'TABLEMERGEDDYNAMICFILTERSTIPFECH3',prop:'Visible'},{av:'edtavMondsc1_Visible',ctrl:'vMONDSC1',prop:'Visible'},{av:'tblTablemergeddynamicfilterstipfech1_Visible',ctrl:'TABLEMERGEDDYNAMICFILTERSTIPFECH1',prop:'Visible'},{av:'cellTipfech_range_cell2_Class',ctrl:'TIPFECH_RANGE_CELL2',prop:'Class'},{av:'cellTipfech_range_cell3_Class',ctrl:'TIPFECH_RANGE_CELL3',prop:'Class'},{av:'cellTipfech_range_cell1_Class',ctrl:'TIPFECH_RANGE_CELL1',prop:'Class'},{av:'AV42GridCurrentPage',fld:'vGRIDCURRENTPAGE',pic:'ZZZZZZZZZ9'},{av:'AV43GridPageCount',fld:'vGRIDPAGECOUNT',pic:'ZZZZZZZZZ9'},{av:'AV44GridAppliedFilters',fld:'vGRIDAPPLIEDFILTERS',pic:''}]}");
         setEventMetadata("VDYNAMICFILTERSSELECTOR1.CLICK","{handler:'E241W2',iparms:[{av:'cmbavDynamicfiltersselector1'},{av:'AV15DynamicFiltersSelector1',fld:'vDYNAMICFILTERSSELECTOR1',pic:''},{av:'cmbavDynamicfiltersoperator1'},{av:'AV16DynamicFiltersOperator1',fld:'vDYNAMICFILTERSOPERATOR1',pic:'ZZZ9'},{av:'Gx_date',fld:'vTODAY',pic:'',hsh:true}]");
         setEventMetadata("VDYNAMICFILTERSSELECTOR1.CLICK",",oparms:[{av:'cmbavDynamicfiltersoperator1'},{av:'AV16DynamicFiltersOperator1',fld:'vDYNAMICFILTERSOPERATOR1',pic:'ZZZ9'},{av:'edtavMondsc1_Visible',ctrl:'vMONDSC1',prop:'Visible'},{av:'tblTablemergeddynamicfilterstipfech1_Visible',ctrl:'TABLEMERGEDDYNAMICFILTERSTIPFECH1',prop:'Visible'},{av:'cellTipfech_range_cell1_Class',ctrl:'TIPFECH_RANGE_CELL1',prop:'Class'},{av:'AV51TipFech1',fld:'vTIPFECH1',pic:''}]}");
         setEventMetadata("TIPFECH_RANGEPICKER1.DATERANGECHANGED","{handler:'E151W2',iparms:[{av:'GRID_nFirstRecordOnPage'},{av:'GRID_nEOF'},{av:'subGrid_Rows',ctrl:'GRID',prop:'Rows'},{av:'cmbavDynamicfiltersselector1'},{av:'AV15DynamicFiltersSelector1',fld:'vDYNAMICFILTERSSELECTOR1',pic:''},{av:'cmbavDynamicfiltersoperator1'},{av:'AV16DynamicFiltersOperator1',fld:'vDYNAMICFILTERSOPERATOR1',pic:'ZZZ9'},{av:'AV50MonDsc1',fld:'vMONDSC1',pic:''},{av:'cmbavDynamicfiltersselector2'},{av:'AV19DynamicFiltersSelector2',fld:'vDYNAMICFILTERSSELECTOR2',pic:''},{av:'cmbavDynamicfiltersoperator2'},{av:'AV20DynamicFiltersOperator2',fld:'vDYNAMICFILTERSOPERATOR2',pic:'ZZZ9'},{av:'AV53MonDsc2',fld:'vMONDSC2',pic:''},{av:'cmbavDynamicfiltersselector3'},{av:'AV23DynamicFiltersSelector3',fld:'vDYNAMICFILTERSSELECTOR3',pic:''},{av:'cmbavDynamicfiltersoperator3'},{av:'AV24DynamicFiltersOperator3',fld:'vDYNAMICFILTERSOPERATOR3',pic:'ZZZ9'},{av:'AV56MonDsc3',fld:'vMONDSC3',pic:''},{av:'AV51TipFech1',fld:'vTIPFECH1',pic:''},{av:'AV54TipFech2',fld:'vTIPFECH2',pic:''},{av:'AV57TipFech3',fld:'vTIPFECH3',pic:''},{av:'AV18DynamicFiltersEnabled2',fld:'vDYNAMICFILTERSENABLED2',pic:''},{av:'AV22DynamicFiltersEnabled3',fld:'vDYNAMICFILTERSENABLED3',pic:''},{av:'AV64Pgmname',fld:'vPGMNAME',pic:'',hsh:true},{av:'AV52TipFech_To1',fld:'vTIPFECH_TO1',pic:''},{av:'AV55TipFech_To2',fld:'vTIPFECH_TO2',pic:''},{av:'AV58TipFech_To3',fld:'vTIPFECH_TO3',pic:''},{av:'AV48TFMonDsc',fld:'vTFMONDSC',pic:''},{av:'AV49TFMonDsc_Sel',fld:'vTFMONDSC_SEL',pic:''},{av:'AV31TFTipFech',fld:'vTFTIPFECH',pic:''},{av:'AV32TFTipFech_To',fld:'vTFTIPFECH_TO',pic:''},{av:'AV36TFTipCompra',fld:'vTFTIPCOMPRA',pic:'ZZZZZZZZ9.99999'},{av:'AV37TFTipCompra_To',fld:'vTFTIPCOMPRA_TO',pic:'ZZZZZZZZ9.99999'},{av:'AV38TFTipVenta',fld:'vTFTIPVENTA',pic:'ZZZZZZZZ9.99999'},{av:'AV39TFTipVenta_To',fld:'vTFTIPVENTA_TO',pic:'ZZZZZZZZ9.99999'},{av:'AV13OrderedBy',fld:'vORDEREDBY',pic:'ZZZ9'},{av:'AV14OrderedDsc',fld:'vORDEREDDSC',pic:''},{av:'AV10GridState',fld:'vGRIDSTATE',pic:''},{av:'AV27DynamicFiltersIgnoreFirst',fld:'vDYNAMICFILTERSIGNOREFIRST',pic:''},{av:'AV26DynamicFiltersRemoving',fld:'vDYNAMICFILTERSREMOVING',pic:''},{av:'A180MonCod',fld:'MONCOD',pic:'ZZZZZ9'},{av:'Gx_date',fld:'vTODAY',pic:'',hsh:true}]");
         setEventMetadata("TIPFECH_RANGEPICKER1.DATERANGECHANGED",",oparms:[{av:'AV51TipFech1',fld:'vTIPFECH1',pic:''},{av:'AV52TipFech_To1',fld:'vTIPFECH_TO1',pic:''},{av:'cmbavDynamicfiltersoperator1'},{av:'AV16DynamicFiltersOperator1',fld:'vDYNAMICFILTERSOPERATOR1',pic:'ZZZ9'},{av:'cmbavDynamicfiltersoperator2'},{av:'AV20DynamicFiltersOperator2',fld:'vDYNAMICFILTERSOPERATOR2',pic:'ZZZ9'},{av:'cmbavDynamicfiltersoperator3'},{av:'AV24DynamicFiltersOperator3',fld:'vDYNAMICFILTERSOPERATOR3',pic:'ZZZ9'},{av:'AV42GridCurrentPage',fld:'vGRIDCURRENTPAGE',pic:'ZZZZZZZZZ9'},{av:'AV43GridPageCount',fld:'vGRIDPAGECOUNT',pic:'ZZZZZZZZZ9'},{av:'AV44GridAppliedFilters',fld:'vGRIDAPPLIEDFILTERS',pic:''},{av:'AV10GridState',fld:'vGRIDSTATE',pic:''}]}");
         setEventMetadata("VDYNAMICFILTERSOPERATOR1.CLICK","{handler:'E251W2',iparms:[{av:'GRID_nFirstRecordOnPage'},{av:'GRID_nEOF'},{av:'subGrid_Rows',ctrl:'GRID',prop:'Rows'},{av:'cmbavDynamicfiltersselector1'},{av:'AV15DynamicFiltersSelector1',fld:'vDYNAMICFILTERSSELECTOR1',pic:''},{av:'cmbavDynamicfiltersoperator1'},{av:'AV16DynamicFiltersOperator1',fld:'vDYNAMICFILTERSOPERATOR1',pic:'ZZZ9'},{av:'AV50MonDsc1',fld:'vMONDSC1',pic:''},{av:'cmbavDynamicfiltersselector2'},{av:'AV19DynamicFiltersSelector2',fld:'vDYNAMICFILTERSSELECTOR2',pic:''},{av:'cmbavDynamicfiltersoperator2'},{av:'AV20DynamicFiltersOperator2',fld:'vDYNAMICFILTERSOPERATOR2',pic:'ZZZ9'},{av:'AV53MonDsc2',fld:'vMONDSC2',pic:''},{av:'cmbavDynamicfiltersselector3'},{av:'AV23DynamicFiltersSelector3',fld:'vDYNAMICFILTERSSELECTOR3',pic:''},{av:'cmbavDynamicfiltersoperator3'},{av:'AV24DynamicFiltersOperator3',fld:'vDYNAMICFILTERSOPERATOR3',pic:'ZZZ9'},{av:'AV56MonDsc3',fld:'vMONDSC3',pic:''},{av:'AV51TipFech1',fld:'vTIPFECH1',pic:''},{av:'AV54TipFech2',fld:'vTIPFECH2',pic:''},{av:'AV57TipFech3',fld:'vTIPFECH3',pic:''},{av:'AV18DynamicFiltersEnabled2',fld:'vDYNAMICFILTERSENABLED2',pic:''},{av:'AV22DynamicFiltersEnabled3',fld:'vDYNAMICFILTERSENABLED3',pic:''},{av:'AV64Pgmname',fld:'vPGMNAME',pic:'',hsh:true},{av:'AV52TipFech_To1',fld:'vTIPFECH_TO1',pic:''},{av:'AV55TipFech_To2',fld:'vTIPFECH_TO2',pic:''},{av:'AV58TipFech_To3',fld:'vTIPFECH_TO3',pic:''},{av:'AV48TFMonDsc',fld:'vTFMONDSC',pic:''},{av:'AV49TFMonDsc_Sel',fld:'vTFMONDSC_SEL',pic:''},{av:'AV31TFTipFech',fld:'vTFTIPFECH',pic:''},{av:'AV32TFTipFech_To',fld:'vTFTIPFECH_TO',pic:''},{av:'AV36TFTipCompra',fld:'vTFTIPCOMPRA',pic:'ZZZZZZZZ9.99999'},{av:'AV37TFTipCompra_To',fld:'vTFTIPCOMPRA_TO',pic:'ZZZZZZZZ9.99999'},{av:'AV38TFTipVenta',fld:'vTFTIPVENTA',pic:'ZZZZZZZZ9.99999'},{av:'AV39TFTipVenta_To',fld:'vTFTIPVENTA_TO',pic:'ZZZZZZZZ9.99999'},{av:'AV13OrderedBy',fld:'vORDEREDBY',pic:'ZZZ9'},{av:'AV14OrderedDsc',fld:'vORDEREDDSC',pic:''},{av:'AV10GridState',fld:'vGRIDSTATE',pic:''},{av:'AV27DynamicFiltersIgnoreFirst',fld:'vDYNAMICFILTERSIGNOREFIRST',pic:''},{av:'AV26DynamicFiltersRemoving',fld:'vDYNAMICFILTERSREMOVING',pic:''},{av:'A180MonCod',fld:'MONCOD',pic:'ZZZZZ9'},{av:'Gx_date',fld:'vTODAY',pic:'',hsh:true}]");
         setEventMetadata("VDYNAMICFILTERSOPERATOR1.CLICK",",oparms:[{av:'AV51TipFech1',fld:'vTIPFECH1',pic:''},{av:'AV52TipFech_To1',fld:'vTIPFECH_TO1',pic:''},{av:'cellTipfech_range_cell1_Class',ctrl:'TIPFECH_RANGE_CELL1',prop:'Class'},{av:'cmbavDynamicfiltersoperator1'},{av:'AV16DynamicFiltersOperator1',fld:'vDYNAMICFILTERSOPERATOR1',pic:'ZZZ9'},{av:'cmbavDynamicfiltersoperator2'},{av:'AV20DynamicFiltersOperator2',fld:'vDYNAMICFILTERSOPERATOR2',pic:'ZZZ9'},{av:'cmbavDynamicfiltersoperator3'},{av:'AV24DynamicFiltersOperator3',fld:'vDYNAMICFILTERSOPERATOR3',pic:'ZZZ9'},{av:'AV42GridCurrentPage',fld:'vGRIDCURRENTPAGE',pic:'ZZZZZZZZZ9'},{av:'AV43GridPageCount',fld:'vGRIDPAGECOUNT',pic:'ZZZZZZZZZ9'},{av:'AV44GridAppliedFilters',fld:'vGRIDAPPLIEDFILTERS',pic:''},{av:'AV10GridState',fld:'vGRIDSTATE',pic:''}]}");
         setEventMetadata("'ADDDYNAMICFILTERS2'","{handler:'E261W2',iparms:[{av:'GRID_nFirstRecordOnPage'},{av:'GRID_nEOF'},{av:'subGrid_Rows',ctrl:'GRID',prop:'Rows'},{av:'cmbavDynamicfiltersselector1'},{av:'AV15DynamicFiltersSelector1',fld:'vDYNAMICFILTERSSELECTOR1',pic:''},{av:'cmbavDynamicfiltersoperator1'},{av:'AV16DynamicFiltersOperator1',fld:'vDYNAMICFILTERSOPERATOR1',pic:'ZZZ9'},{av:'AV50MonDsc1',fld:'vMONDSC1',pic:''},{av:'cmbavDynamicfiltersselector2'},{av:'AV19DynamicFiltersSelector2',fld:'vDYNAMICFILTERSSELECTOR2',pic:''},{av:'cmbavDynamicfiltersoperator2'},{av:'AV20DynamicFiltersOperator2',fld:'vDYNAMICFILTERSOPERATOR2',pic:'ZZZ9'},{av:'AV53MonDsc2',fld:'vMONDSC2',pic:''},{av:'cmbavDynamicfiltersselector3'},{av:'AV23DynamicFiltersSelector3',fld:'vDYNAMICFILTERSSELECTOR3',pic:''},{av:'cmbavDynamicfiltersoperator3'},{av:'AV24DynamicFiltersOperator3',fld:'vDYNAMICFILTERSOPERATOR3',pic:'ZZZ9'},{av:'AV56MonDsc3',fld:'vMONDSC3',pic:''},{av:'AV51TipFech1',fld:'vTIPFECH1',pic:''},{av:'AV54TipFech2',fld:'vTIPFECH2',pic:''},{av:'AV57TipFech3',fld:'vTIPFECH3',pic:''},{av:'AV18DynamicFiltersEnabled2',fld:'vDYNAMICFILTERSENABLED2',pic:''},{av:'AV22DynamicFiltersEnabled3',fld:'vDYNAMICFILTERSENABLED3',pic:''},{av:'AV64Pgmname',fld:'vPGMNAME',pic:'',hsh:true},{av:'AV52TipFech_To1',fld:'vTIPFECH_TO1',pic:''},{av:'AV55TipFech_To2',fld:'vTIPFECH_TO2',pic:''},{av:'AV58TipFech_To3',fld:'vTIPFECH_TO3',pic:''},{av:'AV48TFMonDsc',fld:'vTFMONDSC',pic:''},{av:'AV49TFMonDsc_Sel',fld:'vTFMONDSC_SEL',pic:''},{av:'AV31TFTipFech',fld:'vTFTIPFECH',pic:''},{av:'AV32TFTipFech_To',fld:'vTFTIPFECH_TO',pic:''},{av:'AV36TFTipCompra',fld:'vTFTIPCOMPRA',pic:'ZZZZZZZZ9.99999'},{av:'AV37TFTipCompra_To',fld:'vTFTIPCOMPRA_TO',pic:'ZZZZZZZZ9.99999'},{av:'AV38TFTipVenta',fld:'vTFTIPVENTA',pic:'ZZZZZZZZ9.99999'},{av:'AV39TFTipVenta_To',fld:'vTFTIPVENTA_TO',pic:'ZZZZZZZZ9.99999'},{av:'AV13OrderedBy',fld:'vORDEREDBY',pic:'ZZZ9'},{av:'AV14OrderedDsc',fld:'vORDEREDDSC',pic:''},{av:'AV10GridState',fld:'vGRIDSTATE',pic:''},{av:'AV27DynamicFiltersIgnoreFirst',fld:'vDYNAMICFILTERSIGNOREFIRST',pic:''},{av:'AV26DynamicFiltersRemoving',fld:'vDYNAMICFILTERSREMOVING',pic:''},{av:'A180MonCod',fld:'MONCOD',pic:'ZZZZZ9'},{av:'Gx_date',fld:'vTODAY',pic:'',hsh:true}]");
         setEventMetadata("'ADDDYNAMICFILTERS2'",",oparms:[{av:'AV22DynamicFiltersEnabled3',fld:'vDYNAMICFILTERSENABLED3',pic:''},{av:'imgAdddynamicfilters2_Visible',ctrl:'ADDDYNAMICFILTERS2',prop:'Visible'},{av:'imgRemovedynamicfilters2_Visible',ctrl:'REMOVEDYNAMICFILTERS2',prop:'Visible'},{av:'cmbavDynamicfiltersoperator1'},{av:'AV16DynamicFiltersOperator1',fld:'vDYNAMICFILTERSOPERATOR1',pic:'ZZZ9'},{av:'cmbavDynamicfiltersoperator2'},{av:'AV20DynamicFiltersOperator2',fld:'vDYNAMICFILTERSOPERATOR2',pic:'ZZZ9'},{av:'cmbavDynamicfiltersoperator3'},{av:'AV24DynamicFiltersOperator3',fld:'vDYNAMICFILTERSOPERATOR3',pic:'ZZZ9'},{av:'AV42GridCurrentPage',fld:'vGRIDCURRENTPAGE',pic:'ZZZZZZZZZ9'},{av:'AV43GridPageCount',fld:'vGRIDPAGECOUNT',pic:'ZZZZZZZZZ9'},{av:'AV44GridAppliedFilters',fld:'vGRIDAPPLIEDFILTERS',pic:''},{av:'AV10GridState',fld:'vGRIDSTATE',pic:''}]}");
         setEventMetadata("'REMOVEDYNAMICFILTERS2'","{handler:'E201W2',iparms:[{av:'GRID_nFirstRecordOnPage'},{av:'GRID_nEOF'},{av:'subGrid_Rows',ctrl:'GRID',prop:'Rows'},{av:'cmbavDynamicfiltersselector1'},{av:'AV15DynamicFiltersSelector1',fld:'vDYNAMICFILTERSSELECTOR1',pic:''},{av:'cmbavDynamicfiltersoperator1'},{av:'AV16DynamicFiltersOperator1',fld:'vDYNAMICFILTERSOPERATOR1',pic:'ZZZ9'},{av:'AV50MonDsc1',fld:'vMONDSC1',pic:''},{av:'cmbavDynamicfiltersselector2'},{av:'AV19DynamicFiltersSelector2',fld:'vDYNAMICFILTERSSELECTOR2',pic:''},{av:'cmbavDynamicfiltersoperator2'},{av:'AV20DynamicFiltersOperator2',fld:'vDYNAMICFILTERSOPERATOR2',pic:'ZZZ9'},{av:'AV53MonDsc2',fld:'vMONDSC2',pic:''},{av:'cmbavDynamicfiltersselector3'},{av:'AV23DynamicFiltersSelector3',fld:'vDYNAMICFILTERSSELECTOR3',pic:''},{av:'cmbavDynamicfiltersoperator3'},{av:'AV24DynamicFiltersOperator3',fld:'vDYNAMICFILTERSOPERATOR3',pic:'ZZZ9'},{av:'AV56MonDsc3',fld:'vMONDSC3',pic:''},{av:'AV51TipFech1',fld:'vTIPFECH1',pic:''},{av:'AV54TipFech2',fld:'vTIPFECH2',pic:''},{av:'AV57TipFech3',fld:'vTIPFECH3',pic:''},{av:'AV18DynamicFiltersEnabled2',fld:'vDYNAMICFILTERSENABLED2',pic:''},{av:'AV22DynamicFiltersEnabled3',fld:'vDYNAMICFILTERSENABLED3',pic:''},{av:'AV64Pgmname',fld:'vPGMNAME',pic:'',hsh:true},{av:'AV52TipFech_To1',fld:'vTIPFECH_TO1',pic:''},{av:'AV55TipFech_To2',fld:'vTIPFECH_TO2',pic:''},{av:'AV58TipFech_To3',fld:'vTIPFECH_TO3',pic:''},{av:'AV48TFMonDsc',fld:'vTFMONDSC',pic:''},{av:'AV49TFMonDsc_Sel',fld:'vTFMONDSC_SEL',pic:''},{av:'AV31TFTipFech',fld:'vTFTIPFECH',pic:''},{av:'AV32TFTipFech_To',fld:'vTFTIPFECH_TO',pic:''},{av:'AV36TFTipCompra',fld:'vTFTIPCOMPRA',pic:'ZZZZZZZZ9.99999'},{av:'AV37TFTipCompra_To',fld:'vTFTIPCOMPRA_TO',pic:'ZZZZZZZZ9.99999'},{av:'AV38TFTipVenta',fld:'vTFTIPVENTA',pic:'ZZZZZZZZ9.99999'},{av:'AV39TFTipVenta_To',fld:'vTFTIPVENTA_TO',pic:'ZZZZZZZZ9.99999'},{av:'AV13OrderedBy',fld:'vORDEREDBY',pic:'ZZZ9'},{av:'AV14OrderedDsc',fld:'vORDEREDDSC',pic:''},{av:'AV10GridState',fld:'vGRIDSTATE',pic:''},{av:'AV27DynamicFiltersIgnoreFirst',fld:'vDYNAMICFILTERSIGNOREFIRST',pic:''},{av:'AV26DynamicFiltersRemoving',fld:'vDYNAMICFILTERSREMOVING',pic:''},{av:'A180MonCod',fld:'MONCOD',pic:'ZZZZZ9'},{av:'Gx_date',fld:'vTODAY',pic:'',hsh:true}]");
         setEventMetadata("'REMOVEDYNAMICFILTERS2'",",oparms:[{av:'AV26DynamicFiltersRemoving',fld:'vDYNAMICFILTERSREMOVING',pic:''},{av:'AV18DynamicFiltersEnabled2',fld:'vDYNAMICFILTERSENABLED2',pic:''},{av:'AV10GridState',fld:'vGRIDSTATE',pic:''},{av:'cmbavDynamicfiltersselector2'},{av:'AV19DynamicFiltersSelector2',fld:'vDYNAMICFILTERSSELECTOR2',pic:''},{av:'cmbavDynamicfiltersoperator2'},{av:'AV20DynamicFiltersOperator2',fld:'vDYNAMICFILTERSOPERATOR2',pic:'ZZZ9'},{av:'AV53MonDsc2',fld:'vMONDSC2',pic:''},{av:'AV22DynamicFiltersEnabled3',fld:'vDYNAMICFILTERSENABLED3',pic:''},{av:'cmbavDynamicfiltersselector3'},{av:'AV23DynamicFiltersSelector3',fld:'vDYNAMICFILTERSSELECTOR3',pic:''},{av:'cmbavDynamicfiltersoperator3'},{av:'AV24DynamicFiltersOperator3',fld:'vDYNAMICFILTERSOPERATOR3',pic:'ZZZ9'},{av:'AV56MonDsc3',fld:'vMONDSC3',pic:''},{av:'imgAdddynamicfilters1_Visible',ctrl:'ADDDYNAMICFILTERS1',prop:'Visible'},{av:'imgRemovedynamicfilters1_Visible',ctrl:'REMOVEDYNAMICFILTERS1',prop:'Visible'},{av:'imgAdddynamicfilters2_Visible',ctrl:'ADDDYNAMICFILTERS2',prop:'Visible'},{av:'imgRemovedynamicfilters2_Visible',ctrl:'REMOVEDYNAMICFILTERS2',prop:'Visible'},{av:'cmbavDynamicfiltersselector1'},{av:'AV15DynamicFiltersSelector1',fld:'vDYNAMICFILTERSSELECTOR1',pic:''},{av:'cmbavDynamicfiltersoperator1'},{av:'AV16DynamicFiltersOperator1',fld:'vDYNAMICFILTERSOPERATOR1',pic:'ZZZ9'},{av:'AV50MonDsc1',fld:'vMONDSC1',pic:''},{av:'AV51TipFech1',fld:'vTIPFECH1',pic:''},{av:'AV52TipFech_To1',fld:'vTIPFECH_TO1',pic:''},{av:'lblJsdynamicfilters_Caption',ctrl:'JSDYNAMICFILTERS',prop:'Caption'},{av:'AV54TipFech2',fld:'vTIPFECH2',pic:''},{av:'AV55TipFech_To2',fld:'vTIPFECH_TO2',pic:''},{av:'AV57TipFech3',fld:'vTIPFECH3',pic:''},{av:'AV58TipFech_To3',fld:'vTIPFECH_TO3',pic:''},{av:'edtavMondsc2_Visible',ctrl:'vMONDSC2',prop:'Visible'},{av:'tblTablemergeddynamicfilterstipfech2_Visible',ctrl:'TABLEMERGEDDYNAMICFILTERSTIPFECH2',prop:'Visible'},{av:'edtavMondsc3_Visible',ctrl:'vMONDSC3',prop:'Visible'},{av:'tblTablemergeddynamicfilterstipfech3_Visible',ctrl:'TABLEMERGEDDYNAMICFILTERSTIPFECH3',prop:'Visible'},{av:'edtavMondsc1_Visible',ctrl:'vMONDSC1',prop:'Visible'},{av:'tblTablemergeddynamicfilterstipfech1_Visible',ctrl:'TABLEMERGEDDYNAMICFILTERSTIPFECH1',prop:'Visible'},{av:'cellTipfech_range_cell2_Class',ctrl:'TIPFECH_RANGE_CELL2',prop:'Class'},{av:'cellTipfech_range_cell3_Class',ctrl:'TIPFECH_RANGE_CELL3',prop:'Class'},{av:'cellTipfech_range_cell1_Class',ctrl:'TIPFECH_RANGE_CELL1',prop:'Class'},{av:'AV42GridCurrentPage',fld:'vGRIDCURRENTPAGE',pic:'ZZZZZZZZZ9'},{av:'AV43GridPageCount',fld:'vGRIDPAGECOUNT',pic:'ZZZZZZZZZ9'},{av:'AV44GridAppliedFilters',fld:'vGRIDAPPLIEDFILTERS',pic:''}]}");
         setEventMetadata("VDYNAMICFILTERSSELECTOR2.CLICK","{handler:'E271W2',iparms:[{av:'cmbavDynamicfiltersselector2'},{av:'AV19DynamicFiltersSelector2',fld:'vDYNAMICFILTERSSELECTOR2',pic:''},{av:'cmbavDynamicfiltersoperator2'},{av:'AV20DynamicFiltersOperator2',fld:'vDYNAMICFILTERSOPERATOR2',pic:'ZZZ9'},{av:'Gx_date',fld:'vTODAY',pic:'',hsh:true}]");
         setEventMetadata("VDYNAMICFILTERSSELECTOR2.CLICK",",oparms:[{av:'cmbavDynamicfiltersoperator2'},{av:'AV20DynamicFiltersOperator2',fld:'vDYNAMICFILTERSOPERATOR2',pic:'ZZZ9'},{av:'edtavMondsc2_Visible',ctrl:'vMONDSC2',prop:'Visible'},{av:'tblTablemergeddynamicfilterstipfech2_Visible',ctrl:'TABLEMERGEDDYNAMICFILTERSTIPFECH2',prop:'Visible'},{av:'cellTipfech_range_cell2_Class',ctrl:'TIPFECH_RANGE_CELL2',prop:'Class'},{av:'AV54TipFech2',fld:'vTIPFECH2',pic:''}]}");
         setEventMetadata("TIPFECH_RANGEPICKER2.DATERANGECHANGED","{handler:'E161W2',iparms:[{av:'GRID_nFirstRecordOnPage'},{av:'GRID_nEOF'},{av:'subGrid_Rows',ctrl:'GRID',prop:'Rows'},{av:'cmbavDynamicfiltersselector1'},{av:'AV15DynamicFiltersSelector1',fld:'vDYNAMICFILTERSSELECTOR1',pic:''},{av:'cmbavDynamicfiltersoperator1'},{av:'AV16DynamicFiltersOperator1',fld:'vDYNAMICFILTERSOPERATOR1',pic:'ZZZ9'},{av:'AV50MonDsc1',fld:'vMONDSC1',pic:''},{av:'cmbavDynamicfiltersselector2'},{av:'AV19DynamicFiltersSelector2',fld:'vDYNAMICFILTERSSELECTOR2',pic:''},{av:'cmbavDynamicfiltersoperator2'},{av:'AV20DynamicFiltersOperator2',fld:'vDYNAMICFILTERSOPERATOR2',pic:'ZZZ9'},{av:'AV53MonDsc2',fld:'vMONDSC2',pic:''},{av:'cmbavDynamicfiltersselector3'},{av:'AV23DynamicFiltersSelector3',fld:'vDYNAMICFILTERSSELECTOR3',pic:''},{av:'cmbavDynamicfiltersoperator3'},{av:'AV24DynamicFiltersOperator3',fld:'vDYNAMICFILTERSOPERATOR3',pic:'ZZZ9'},{av:'AV56MonDsc3',fld:'vMONDSC3',pic:''},{av:'AV51TipFech1',fld:'vTIPFECH1',pic:''},{av:'AV54TipFech2',fld:'vTIPFECH2',pic:''},{av:'AV57TipFech3',fld:'vTIPFECH3',pic:''},{av:'AV18DynamicFiltersEnabled2',fld:'vDYNAMICFILTERSENABLED2',pic:''},{av:'AV22DynamicFiltersEnabled3',fld:'vDYNAMICFILTERSENABLED3',pic:''},{av:'AV64Pgmname',fld:'vPGMNAME',pic:'',hsh:true},{av:'AV52TipFech_To1',fld:'vTIPFECH_TO1',pic:''},{av:'AV55TipFech_To2',fld:'vTIPFECH_TO2',pic:''},{av:'AV58TipFech_To3',fld:'vTIPFECH_TO3',pic:''},{av:'AV48TFMonDsc',fld:'vTFMONDSC',pic:''},{av:'AV49TFMonDsc_Sel',fld:'vTFMONDSC_SEL',pic:''},{av:'AV31TFTipFech',fld:'vTFTIPFECH',pic:''},{av:'AV32TFTipFech_To',fld:'vTFTIPFECH_TO',pic:''},{av:'AV36TFTipCompra',fld:'vTFTIPCOMPRA',pic:'ZZZZZZZZ9.99999'},{av:'AV37TFTipCompra_To',fld:'vTFTIPCOMPRA_TO',pic:'ZZZZZZZZ9.99999'},{av:'AV38TFTipVenta',fld:'vTFTIPVENTA',pic:'ZZZZZZZZ9.99999'},{av:'AV39TFTipVenta_To',fld:'vTFTIPVENTA_TO',pic:'ZZZZZZZZ9.99999'},{av:'AV13OrderedBy',fld:'vORDEREDBY',pic:'ZZZ9'},{av:'AV14OrderedDsc',fld:'vORDEREDDSC',pic:''},{av:'AV10GridState',fld:'vGRIDSTATE',pic:''},{av:'AV27DynamicFiltersIgnoreFirst',fld:'vDYNAMICFILTERSIGNOREFIRST',pic:''},{av:'AV26DynamicFiltersRemoving',fld:'vDYNAMICFILTERSREMOVING',pic:''},{av:'A180MonCod',fld:'MONCOD',pic:'ZZZZZ9'},{av:'Gx_date',fld:'vTODAY',pic:'',hsh:true}]");
         setEventMetadata("TIPFECH_RANGEPICKER2.DATERANGECHANGED",",oparms:[{av:'AV54TipFech2',fld:'vTIPFECH2',pic:''},{av:'AV55TipFech_To2',fld:'vTIPFECH_TO2',pic:''},{av:'cmbavDynamicfiltersoperator1'},{av:'AV16DynamicFiltersOperator1',fld:'vDYNAMICFILTERSOPERATOR1',pic:'ZZZ9'},{av:'cmbavDynamicfiltersoperator2'},{av:'AV20DynamicFiltersOperator2',fld:'vDYNAMICFILTERSOPERATOR2',pic:'ZZZ9'},{av:'cmbavDynamicfiltersoperator3'},{av:'AV24DynamicFiltersOperator3',fld:'vDYNAMICFILTERSOPERATOR3',pic:'ZZZ9'},{av:'AV42GridCurrentPage',fld:'vGRIDCURRENTPAGE',pic:'ZZZZZZZZZ9'},{av:'AV43GridPageCount',fld:'vGRIDPAGECOUNT',pic:'ZZZZZZZZZ9'},{av:'AV44GridAppliedFilters',fld:'vGRIDAPPLIEDFILTERS',pic:''},{av:'AV10GridState',fld:'vGRIDSTATE',pic:''}]}");
         setEventMetadata("VDYNAMICFILTERSOPERATOR2.CLICK","{handler:'E281W2',iparms:[{av:'GRID_nFirstRecordOnPage'},{av:'GRID_nEOF'},{av:'subGrid_Rows',ctrl:'GRID',prop:'Rows'},{av:'cmbavDynamicfiltersselector1'},{av:'AV15DynamicFiltersSelector1',fld:'vDYNAMICFILTERSSELECTOR1',pic:''},{av:'cmbavDynamicfiltersoperator1'},{av:'AV16DynamicFiltersOperator1',fld:'vDYNAMICFILTERSOPERATOR1',pic:'ZZZ9'},{av:'AV50MonDsc1',fld:'vMONDSC1',pic:''},{av:'cmbavDynamicfiltersselector2'},{av:'AV19DynamicFiltersSelector2',fld:'vDYNAMICFILTERSSELECTOR2',pic:''},{av:'cmbavDynamicfiltersoperator2'},{av:'AV20DynamicFiltersOperator2',fld:'vDYNAMICFILTERSOPERATOR2',pic:'ZZZ9'},{av:'AV53MonDsc2',fld:'vMONDSC2',pic:''},{av:'cmbavDynamicfiltersselector3'},{av:'AV23DynamicFiltersSelector3',fld:'vDYNAMICFILTERSSELECTOR3',pic:''},{av:'cmbavDynamicfiltersoperator3'},{av:'AV24DynamicFiltersOperator3',fld:'vDYNAMICFILTERSOPERATOR3',pic:'ZZZ9'},{av:'AV56MonDsc3',fld:'vMONDSC3',pic:''},{av:'AV51TipFech1',fld:'vTIPFECH1',pic:''},{av:'AV54TipFech2',fld:'vTIPFECH2',pic:''},{av:'AV57TipFech3',fld:'vTIPFECH3',pic:''},{av:'AV18DynamicFiltersEnabled2',fld:'vDYNAMICFILTERSENABLED2',pic:''},{av:'AV22DynamicFiltersEnabled3',fld:'vDYNAMICFILTERSENABLED3',pic:''},{av:'AV64Pgmname',fld:'vPGMNAME',pic:'',hsh:true},{av:'AV52TipFech_To1',fld:'vTIPFECH_TO1',pic:''},{av:'AV55TipFech_To2',fld:'vTIPFECH_TO2',pic:''},{av:'AV58TipFech_To3',fld:'vTIPFECH_TO3',pic:''},{av:'AV48TFMonDsc',fld:'vTFMONDSC',pic:''},{av:'AV49TFMonDsc_Sel',fld:'vTFMONDSC_SEL',pic:''},{av:'AV31TFTipFech',fld:'vTFTIPFECH',pic:''},{av:'AV32TFTipFech_To',fld:'vTFTIPFECH_TO',pic:''},{av:'AV36TFTipCompra',fld:'vTFTIPCOMPRA',pic:'ZZZZZZZZ9.99999'},{av:'AV37TFTipCompra_To',fld:'vTFTIPCOMPRA_TO',pic:'ZZZZZZZZ9.99999'},{av:'AV38TFTipVenta',fld:'vTFTIPVENTA',pic:'ZZZZZZZZ9.99999'},{av:'AV39TFTipVenta_To',fld:'vTFTIPVENTA_TO',pic:'ZZZZZZZZ9.99999'},{av:'AV13OrderedBy',fld:'vORDEREDBY',pic:'ZZZ9'},{av:'AV14OrderedDsc',fld:'vORDEREDDSC',pic:''},{av:'AV10GridState',fld:'vGRIDSTATE',pic:''},{av:'AV27DynamicFiltersIgnoreFirst',fld:'vDYNAMICFILTERSIGNOREFIRST',pic:''},{av:'AV26DynamicFiltersRemoving',fld:'vDYNAMICFILTERSREMOVING',pic:''},{av:'A180MonCod',fld:'MONCOD',pic:'ZZZZZ9'},{av:'Gx_date',fld:'vTODAY',pic:'',hsh:true}]");
         setEventMetadata("VDYNAMICFILTERSOPERATOR2.CLICK",",oparms:[{av:'AV54TipFech2',fld:'vTIPFECH2',pic:''},{av:'AV55TipFech_To2',fld:'vTIPFECH_TO2',pic:''},{av:'cellTipfech_range_cell2_Class',ctrl:'TIPFECH_RANGE_CELL2',prop:'Class'},{av:'cmbavDynamicfiltersoperator1'},{av:'AV16DynamicFiltersOperator1',fld:'vDYNAMICFILTERSOPERATOR1',pic:'ZZZ9'},{av:'cmbavDynamicfiltersoperator2'},{av:'AV20DynamicFiltersOperator2',fld:'vDYNAMICFILTERSOPERATOR2',pic:'ZZZ9'},{av:'cmbavDynamicfiltersoperator3'},{av:'AV24DynamicFiltersOperator3',fld:'vDYNAMICFILTERSOPERATOR3',pic:'ZZZ9'},{av:'AV42GridCurrentPage',fld:'vGRIDCURRENTPAGE',pic:'ZZZZZZZZZ9'},{av:'AV43GridPageCount',fld:'vGRIDPAGECOUNT',pic:'ZZZZZZZZZ9'},{av:'AV44GridAppliedFilters',fld:'vGRIDAPPLIEDFILTERS',pic:''},{av:'AV10GridState',fld:'vGRIDSTATE',pic:''}]}");
         setEventMetadata("'REMOVEDYNAMICFILTERS3'","{handler:'E211W2',iparms:[{av:'GRID_nFirstRecordOnPage'},{av:'GRID_nEOF'},{av:'subGrid_Rows',ctrl:'GRID',prop:'Rows'},{av:'cmbavDynamicfiltersselector1'},{av:'AV15DynamicFiltersSelector1',fld:'vDYNAMICFILTERSSELECTOR1',pic:''},{av:'cmbavDynamicfiltersoperator1'},{av:'AV16DynamicFiltersOperator1',fld:'vDYNAMICFILTERSOPERATOR1',pic:'ZZZ9'},{av:'AV50MonDsc1',fld:'vMONDSC1',pic:''},{av:'cmbavDynamicfiltersselector2'},{av:'AV19DynamicFiltersSelector2',fld:'vDYNAMICFILTERSSELECTOR2',pic:''},{av:'cmbavDynamicfiltersoperator2'},{av:'AV20DynamicFiltersOperator2',fld:'vDYNAMICFILTERSOPERATOR2',pic:'ZZZ9'},{av:'AV53MonDsc2',fld:'vMONDSC2',pic:''},{av:'cmbavDynamicfiltersselector3'},{av:'AV23DynamicFiltersSelector3',fld:'vDYNAMICFILTERSSELECTOR3',pic:''},{av:'cmbavDynamicfiltersoperator3'},{av:'AV24DynamicFiltersOperator3',fld:'vDYNAMICFILTERSOPERATOR3',pic:'ZZZ9'},{av:'AV56MonDsc3',fld:'vMONDSC3',pic:''},{av:'AV51TipFech1',fld:'vTIPFECH1',pic:''},{av:'AV54TipFech2',fld:'vTIPFECH2',pic:''},{av:'AV57TipFech3',fld:'vTIPFECH3',pic:''},{av:'AV18DynamicFiltersEnabled2',fld:'vDYNAMICFILTERSENABLED2',pic:''},{av:'AV22DynamicFiltersEnabled3',fld:'vDYNAMICFILTERSENABLED3',pic:''},{av:'AV64Pgmname',fld:'vPGMNAME',pic:'',hsh:true},{av:'AV52TipFech_To1',fld:'vTIPFECH_TO1',pic:''},{av:'AV55TipFech_To2',fld:'vTIPFECH_TO2',pic:''},{av:'AV58TipFech_To3',fld:'vTIPFECH_TO3',pic:''},{av:'AV48TFMonDsc',fld:'vTFMONDSC',pic:''},{av:'AV49TFMonDsc_Sel',fld:'vTFMONDSC_SEL',pic:''},{av:'AV31TFTipFech',fld:'vTFTIPFECH',pic:''},{av:'AV32TFTipFech_To',fld:'vTFTIPFECH_TO',pic:''},{av:'AV36TFTipCompra',fld:'vTFTIPCOMPRA',pic:'ZZZZZZZZ9.99999'},{av:'AV37TFTipCompra_To',fld:'vTFTIPCOMPRA_TO',pic:'ZZZZZZZZ9.99999'},{av:'AV38TFTipVenta',fld:'vTFTIPVENTA',pic:'ZZZZZZZZ9.99999'},{av:'AV39TFTipVenta_To',fld:'vTFTIPVENTA_TO',pic:'ZZZZZZZZ9.99999'},{av:'AV13OrderedBy',fld:'vORDEREDBY',pic:'ZZZ9'},{av:'AV14OrderedDsc',fld:'vORDEREDDSC',pic:''},{av:'AV10GridState',fld:'vGRIDSTATE',pic:''},{av:'AV27DynamicFiltersIgnoreFirst',fld:'vDYNAMICFILTERSIGNOREFIRST',pic:''},{av:'AV26DynamicFiltersRemoving',fld:'vDYNAMICFILTERSREMOVING',pic:''},{av:'A180MonCod',fld:'MONCOD',pic:'ZZZZZ9'},{av:'Gx_date',fld:'vTODAY',pic:'',hsh:true}]");
         setEventMetadata("'REMOVEDYNAMICFILTERS3'",",oparms:[{av:'AV26DynamicFiltersRemoving',fld:'vDYNAMICFILTERSREMOVING',pic:''},{av:'AV22DynamicFiltersEnabled3',fld:'vDYNAMICFILTERSENABLED3',pic:''},{av:'AV10GridState',fld:'vGRIDSTATE',pic:''},{av:'AV18DynamicFiltersEnabled2',fld:'vDYNAMICFILTERSENABLED2',pic:''},{av:'cmbavDynamicfiltersselector2'},{av:'AV19DynamicFiltersSelector2',fld:'vDYNAMICFILTERSSELECTOR2',pic:''},{av:'cmbavDynamicfiltersoperator2'},{av:'AV20DynamicFiltersOperator2',fld:'vDYNAMICFILTERSOPERATOR2',pic:'ZZZ9'},{av:'AV53MonDsc2',fld:'vMONDSC2',pic:''},{av:'cmbavDynamicfiltersselector3'},{av:'AV23DynamicFiltersSelector3',fld:'vDYNAMICFILTERSSELECTOR3',pic:''},{av:'cmbavDynamicfiltersoperator3'},{av:'AV24DynamicFiltersOperator3',fld:'vDYNAMICFILTERSOPERATOR3',pic:'ZZZ9'},{av:'AV56MonDsc3',fld:'vMONDSC3',pic:''},{av:'imgAdddynamicfilters1_Visible',ctrl:'ADDDYNAMICFILTERS1',prop:'Visible'},{av:'imgRemovedynamicfilters1_Visible',ctrl:'REMOVEDYNAMICFILTERS1',prop:'Visible'},{av:'imgAdddynamicfilters2_Visible',ctrl:'ADDDYNAMICFILTERS2',prop:'Visible'},{av:'imgRemovedynamicfilters2_Visible',ctrl:'REMOVEDYNAMICFILTERS2',prop:'Visible'},{av:'cmbavDynamicfiltersselector1'},{av:'AV15DynamicFiltersSelector1',fld:'vDYNAMICFILTERSSELECTOR1',pic:''},{av:'cmbavDynamicfiltersoperator1'},{av:'AV16DynamicFiltersOperator1',fld:'vDYNAMICFILTERSOPERATOR1',pic:'ZZZ9'},{av:'AV50MonDsc1',fld:'vMONDSC1',pic:''},{av:'AV51TipFech1',fld:'vTIPFECH1',pic:''},{av:'AV52TipFech_To1',fld:'vTIPFECH_TO1',pic:''},{av:'lblJsdynamicfilters_Caption',ctrl:'JSDYNAMICFILTERS',prop:'Caption'},{av:'AV54TipFech2',fld:'vTIPFECH2',pic:''},{av:'AV55TipFech_To2',fld:'vTIPFECH_TO2',pic:''},{av:'AV57TipFech3',fld:'vTIPFECH3',pic:''},{av:'AV58TipFech_To3',fld:'vTIPFECH_TO3',pic:''},{av:'edtavMondsc2_Visible',ctrl:'vMONDSC2',prop:'Visible'},{av:'tblTablemergeddynamicfilterstipfech2_Visible',ctrl:'TABLEMERGEDDYNAMICFILTERSTIPFECH2',prop:'Visible'},{av:'edtavMondsc3_Visible',ctrl:'vMONDSC3',prop:'Visible'},{av:'tblTablemergeddynamicfilterstipfech3_Visible',ctrl:'TABLEMERGEDDYNAMICFILTERSTIPFECH3',prop:'Visible'},{av:'edtavMondsc1_Visible',ctrl:'vMONDSC1',prop:'Visible'},{av:'tblTablemergeddynamicfilterstipfech1_Visible',ctrl:'TABLEMERGEDDYNAMICFILTERSTIPFECH1',prop:'Visible'},{av:'cellTipfech_range_cell2_Class',ctrl:'TIPFECH_RANGE_CELL2',prop:'Class'},{av:'cellTipfech_range_cell3_Class',ctrl:'TIPFECH_RANGE_CELL3',prop:'Class'},{av:'cellTipfech_range_cell1_Class',ctrl:'TIPFECH_RANGE_CELL1',prop:'Class'},{av:'AV42GridCurrentPage',fld:'vGRIDCURRENTPAGE',pic:'ZZZZZZZZZ9'},{av:'AV43GridPageCount',fld:'vGRIDPAGECOUNT',pic:'ZZZZZZZZZ9'},{av:'AV44GridAppliedFilters',fld:'vGRIDAPPLIEDFILTERS',pic:''}]}");
         setEventMetadata("VDYNAMICFILTERSSELECTOR3.CLICK","{handler:'E291W2',iparms:[{av:'cmbavDynamicfiltersselector3'},{av:'AV23DynamicFiltersSelector3',fld:'vDYNAMICFILTERSSELECTOR3',pic:''},{av:'cmbavDynamicfiltersoperator3'},{av:'AV24DynamicFiltersOperator3',fld:'vDYNAMICFILTERSOPERATOR3',pic:'ZZZ9'},{av:'Gx_date',fld:'vTODAY',pic:'',hsh:true}]");
         setEventMetadata("VDYNAMICFILTERSSELECTOR3.CLICK",",oparms:[{av:'cmbavDynamicfiltersoperator3'},{av:'AV24DynamicFiltersOperator3',fld:'vDYNAMICFILTERSOPERATOR3',pic:'ZZZ9'},{av:'edtavMondsc3_Visible',ctrl:'vMONDSC3',prop:'Visible'},{av:'tblTablemergeddynamicfilterstipfech3_Visible',ctrl:'TABLEMERGEDDYNAMICFILTERSTIPFECH3',prop:'Visible'},{av:'cellTipfech_range_cell3_Class',ctrl:'TIPFECH_RANGE_CELL3',prop:'Class'},{av:'AV57TipFech3',fld:'vTIPFECH3',pic:''}]}");
         setEventMetadata("TIPFECH_RANGEPICKER3.DATERANGECHANGED","{handler:'E171W2',iparms:[{av:'GRID_nFirstRecordOnPage'},{av:'GRID_nEOF'},{av:'subGrid_Rows',ctrl:'GRID',prop:'Rows'},{av:'cmbavDynamicfiltersselector1'},{av:'AV15DynamicFiltersSelector1',fld:'vDYNAMICFILTERSSELECTOR1',pic:''},{av:'cmbavDynamicfiltersoperator1'},{av:'AV16DynamicFiltersOperator1',fld:'vDYNAMICFILTERSOPERATOR1',pic:'ZZZ9'},{av:'AV50MonDsc1',fld:'vMONDSC1',pic:''},{av:'cmbavDynamicfiltersselector2'},{av:'AV19DynamicFiltersSelector2',fld:'vDYNAMICFILTERSSELECTOR2',pic:''},{av:'cmbavDynamicfiltersoperator2'},{av:'AV20DynamicFiltersOperator2',fld:'vDYNAMICFILTERSOPERATOR2',pic:'ZZZ9'},{av:'AV53MonDsc2',fld:'vMONDSC2',pic:''},{av:'cmbavDynamicfiltersselector3'},{av:'AV23DynamicFiltersSelector3',fld:'vDYNAMICFILTERSSELECTOR3',pic:''},{av:'cmbavDynamicfiltersoperator3'},{av:'AV24DynamicFiltersOperator3',fld:'vDYNAMICFILTERSOPERATOR3',pic:'ZZZ9'},{av:'AV56MonDsc3',fld:'vMONDSC3',pic:''},{av:'AV51TipFech1',fld:'vTIPFECH1',pic:''},{av:'AV54TipFech2',fld:'vTIPFECH2',pic:''},{av:'AV57TipFech3',fld:'vTIPFECH3',pic:''},{av:'AV18DynamicFiltersEnabled2',fld:'vDYNAMICFILTERSENABLED2',pic:''},{av:'AV22DynamicFiltersEnabled3',fld:'vDYNAMICFILTERSENABLED3',pic:''},{av:'AV64Pgmname',fld:'vPGMNAME',pic:'',hsh:true},{av:'AV52TipFech_To1',fld:'vTIPFECH_TO1',pic:''},{av:'AV55TipFech_To2',fld:'vTIPFECH_TO2',pic:''},{av:'AV58TipFech_To3',fld:'vTIPFECH_TO3',pic:''},{av:'AV48TFMonDsc',fld:'vTFMONDSC',pic:''},{av:'AV49TFMonDsc_Sel',fld:'vTFMONDSC_SEL',pic:''},{av:'AV31TFTipFech',fld:'vTFTIPFECH',pic:''},{av:'AV32TFTipFech_To',fld:'vTFTIPFECH_TO',pic:''},{av:'AV36TFTipCompra',fld:'vTFTIPCOMPRA',pic:'ZZZZZZZZ9.99999'},{av:'AV37TFTipCompra_To',fld:'vTFTIPCOMPRA_TO',pic:'ZZZZZZZZ9.99999'},{av:'AV38TFTipVenta',fld:'vTFTIPVENTA',pic:'ZZZZZZZZ9.99999'},{av:'AV39TFTipVenta_To',fld:'vTFTIPVENTA_TO',pic:'ZZZZZZZZ9.99999'},{av:'AV13OrderedBy',fld:'vORDEREDBY',pic:'ZZZ9'},{av:'AV14OrderedDsc',fld:'vORDEREDDSC',pic:''},{av:'AV10GridState',fld:'vGRIDSTATE',pic:''},{av:'AV27DynamicFiltersIgnoreFirst',fld:'vDYNAMICFILTERSIGNOREFIRST',pic:''},{av:'AV26DynamicFiltersRemoving',fld:'vDYNAMICFILTERSREMOVING',pic:''},{av:'A180MonCod',fld:'MONCOD',pic:'ZZZZZ9'},{av:'Gx_date',fld:'vTODAY',pic:'',hsh:true}]");
         setEventMetadata("TIPFECH_RANGEPICKER3.DATERANGECHANGED",",oparms:[{av:'AV57TipFech3',fld:'vTIPFECH3',pic:''},{av:'AV58TipFech_To3',fld:'vTIPFECH_TO3',pic:''},{av:'cmbavDynamicfiltersoperator1'},{av:'AV16DynamicFiltersOperator1',fld:'vDYNAMICFILTERSOPERATOR1',pic:'ZZZ9'},{av:'cmbavDynamicfiltersoperator2'},{av:'AV20DynamicFiltersOperator2',fld:'vDYNAMICFILTERSOPERATOR2',pic:'ZZZ9'},{av:'cmbavDynamicfiltersoperator3'},{av:'AV24DynamicFiltersOperator3',fld:'vDYNAMICFILTERSOPERATOR3',pic:'ZZZ9'},{av:'AV42GridCurrentPage',fld:'vGRIDCURRENTPAGE',pic:'ZZZZZZZZZ9'},{av:'AV43GridPageCount',fld:'vGRIDPAGECOUNT',pic:'ZZZZZZZZZ9'},{av:'AV44GridAppliedFilters',fld:'vGRIDAPPLIEDFILTERS',pic:''},{av:'AV10GridState',fld:'vGRIDSTATE',pic:''}]}");
         setEventMetadata("VDYNAMICFILTERSOPERATOR3.CLICK","{handler:'E301W2',iparms:[{av:'GRID_nFirstRecordOnPage'},{av:'GRID_nEOF'},{av:'subGrid_Rows',ctrl:'GRID',prop:'Rows'},{av:'cmbavDynamicfiltersselector1'},{av:'AV15DynamicFiltersSelector1',fld:'vDYNAMICFILTERSSELECTOR1',pic:''},{av:'cmbavDynamicfiltersoperator1'},{av:'AV16DynamicFiltersOperator1',fld:'vDYNAMICFILTERSOPERATOR1',pic:'ZZZ9'},{av:'AV50MonDsc1',fld:'vMONDSC1',pic:''},{av:'cmbavDynamicfiltersselector2'},{av:'AV19DynamicFiltersSelector2',fld:'vDYNAMICFILTERSSELECTOR2',pic:''},{av:'cmbavDynamicfiltersoperator2'},{av:'AV20DynamicFiltersOperator2',fld:'vDYNAMICFILTERSOPERATOR2',pic:'ZZZ9'},{av:'AV53MonDsc2',fld:'vMONDSC2',pic:''},{av:'cmbavDynamicfiltersselector3'},{av:'AV23DynamicFiltersSelector3',fld:'vDYNAMICFILTERSSELECTOR3',pic:''},{av:'cmbavDynamicfiltersoperator3'},{av:'AV24DynamicFiltersOperator3',fld:'vDYNAMICFILTERSOPERATOR3',pic:'ZZZ9'},{av:'AV56MonDsc3',fld:'vMONDSC3',pic:''},{av:'AV51TipFech1',fld:'vTIPFECH1',pic:''},{av:'AV54TipFech2',fld:'vTIPFECH2',pic:''},{av:'AV57TipFech3',fld:'vTIPFECH3',pic:''},{av:'AV18DynamicFiltersEnabled2',fld:'vDYNAMICFILTERSENABLED2',pic:''},{av:'AV22DynamicFiltersEnabled3',fld:'vDYNAMICFILTERSENABLED3',pic:''},{av:'AV64Pgmname',fld:'vPGMNAME',pic:'',hsh:true},{av:'AV52TipFech_To1',fld:'vTIPFECH_TO1',pic:''},{av:'AV55TipFech_To2',fld:'vTIPFECH_TO2',pic:''},{av:'AV58TipFech_To3',fld:'vTIPFECH_TO3',pic:''},{av:'AV48TFMonDsc',fld:'vTFMONDSC',pic:''},{av:'AV49TFMonDsc_Sel',fld:'vTFMONDSC_SEL',pic:''},{av:'AV31TFTipFech',fld:'vTFTIPFECH',pic:''},{av:'AV32TFTipFech_To',fld:'vTFTIPFECH_TO',pic:''},{av:'AV36TFTipCompra',fld:'vTFTIPCOMPRA',pic:'ZZZZZZZZ9.99999'},{av:'AV37TFTipCompra_To',fld:'vTFTIPCOMPRA_TO',pic:'ZZZZZZZZ9.99999'},{av:'AV38TFTipVenta',fld:'vTFTIPVENTA',pic:'ZZZZZZZZ9.99999'},{av:'AV39TFTipVenta_To',fld:'vTFTIPVENTA_TO',pic:'ZZZZZZZZ9.99999'},{av:'AV13OrderedBy',fld:'vORDEREDBY',pic:'ZZZ9'},{av:'AV14OrderedDsc',fld:'vORDEREDDSC',pic:''},{av:'AV10GridState',fld:'vGRIDSTATE',pic:''},{av:'AV27DynamicFiltersIgnoreFirst',fld:'vDYNAMICFILTERSIGNOREFIRST',pic:''},{av:'AV26DynamicFiltersRemoving',fld:'vDYNAMICFILTERSREMOVING',pic:''},{av:'A180MonCod',fld:'MONCOD',pic:'ZZZZZ9'},{av:'Gx_date',fld:'vTODAY',pic:'',hsh:true}]");
         setEventMetadata("VDYNAMICFILTERSOPERATOR3.CLICK",",oparms:[{av:'AV57TipFech3',fld:'vTIPFECH3',pic:''},{av:'AV58TipFech_To3',fld:'vTIPFECH_TO3',pic:''},{av:'cellTipfech_range_cell3_Class',ctrl:'TIPFECH_RANGE_CELL3',prop:'Class'},{av:'cmbavDynamicfiltersoperator1'},{av:'AV16DynamicFiltersOperator1',fld:'vDYNAMICFILTERSOPERATOR1',pic:'ZZZ9'},{av:'cmbavDynamicfiltersoperator2'},{av:'AV20DynamicFiltersOperator2',fld:'vDYNAMICFILTERSOPERATOR2',pic:'ZZZ9'},{av:'cmbavDynamicfiltersoperator3'},{av:'AV24DynamicFiltersOperator3',fld:'vDYNAMICFILTERSOPERATOR3',pic:'ZZZ9'},{av:'AV42GridCurrentPage',fld:'vGRIDCURRENTPAGE',pic:'ZZZZZZZZZ9'},{av:'AV43GridPageCount',fld:'vGRIDPAGECOUNT',pic:'ZZZZZZZZZ9'},{av:'AV44GridAppliedFilters',fld:'vGRIDAPPLIEDFILTERS',pic:''},{av:'AV10GridState',fld:'vGRIDSTATE',pic:''}]}");
         setEventMetadata("VGRIDACTIONS.CLICK","{handler:'E341W2',iparms:[{av:'cmbavGridactions'},{av:'AV45GridActions',fld:'vGRIDACTIONS',pic:'ZZZ9'},{av:'A307TipMonCod',fld:'TIPMONCOD',pic:'ZZZZZ9',hsh:true},{av:'A308TipFech',fld:'TIPFECH',pic:'',hsh:true}]");
         setEventMetadata("VGRIDACTIONS.CLICK",",oparms:[{av:'cmbavGridactions'},{av:'AV45GridActions',fld:'vGRIDACTIONS',pic:'ZZZ9'}]}");
         setEventMetadata("'DOINSERT'","{handler:'E221W2',iparms:[{av:'A307TipMonCod',fld:'TIPMONCOD',pic:'ZZZZZ9',hsh:true},{av:'A308TipFech',fld:'TIPFECH',pic:'',hsh:true}]");
         setEventMetadata("'DOINSERT'",",oparms:[]}");
         setEventMetadata("DDO_AGEXPORT.ONOPTIONCLICKED","{handler:'E141W2',iparms:[{av:'Ddo_agexport_Activeeventkey',ctrl:'DDO_AGEXPORT',prop:'ActiveEventKey'},{av:'AV64Pgmname',fld:'vPGMNAME',pic:'',hsh:true},{av:'AV49TFMonDsc_Sel',fld:'vTFMONDSC_SEL',pic:''},{av:'AV48TFMonDsc',fld:'vTFMONDSC',pic:''},{av:'AV31TFTipFech',fld:'vTFTIPFECH',pic:''},{av:'AV36TFTipCompra',fld:'vTFTIPCOMPRA',pic:'ZZZZZZZZ9.99999'},{av:'AV38TFTipVenta',fld:'vTFTIPVENTA',pic:'ZZZZZZZZ9.99999'},{av:'AV32TFTipFech_To',fld:'vTFTIPFECH_TO',pic:''},{av:'AV37TFTipCompra_To',fld:'vTFTIPCOMPRA_TO',pic:'ZZZZZZZZ9.99999'},{av:'AV39TFTipVenta_To',fld:'vTFTIPVENTA_TO',pic:'ZZZZZZZZ9.99999'},{av:'AV13OrderedBy',fld:'vORDEREDBY',pic:'ZZZ9'},{av:'AV14OrderedDsc',fld:'vORDEREDDSC',pic:''},{av:'AV10GridState',fld:'vGRIDSTATE',pic:''},{av:'AV26DynamicFiltersRemoving',fld:'vDYNAMICFILTERSREMOVING',pic:''},{av:'cmbavDynamicfiltersselector1'},{av:'AV15DynamicFiltersSelector1',fld:'vDYNAMICFILTERSSELECTOR1',pic:''},{av:'cmbavDynamicfiltersselector2'},{av:'AV19DynamicFiltersSelector2',fld:'vDYNAMICFILTERSSELECTOR2',pic:''},{av:'cmbavDynamicfiltersselector3'},{av:'AV23DynamicFiltersSelector3',fld:'vDYNAMICFILTERSSELECTOR3',pic:''},{av:'cmbavDynamicfiltersoperator1'},{av:'AV16DynamicFiltersOperator1',fld:'vDYNAMICFILTERSOPERATOR1',pic:'ZZZ9'},{av:'Gx_date',fld:'vTODAY',pic:'',hsh:true},{av:'cmbavDynamicfiltersoperator2'},{av:'AV20DynamicFiltersOperator2',fld:'vDYNAMICFILTERSOPERATOR2',pic:'ZZZ9'},{av:'cmbavDynamicfiltersoperator3'},{av:'AV24DynamicFiltersOperator3',fld:'vDYNAMICFILTERSOPERATOR3',pic:'ZZZ9'}]");
         setEventMetadata("DDO_AGEXPORT.ONOPTIONCLICKED",",oparms:[{av:'Innewwindow1_Target',ctrl:'INNEWWINDOW1',prop:'Target'},{av:'Innewwindow1_Height',ctrl:'INNEWWINDOW1',prop:'Height'},{av:'Innewwindow1_Width',ctrl:'INNEWWINDOW1',prop:'Width'},{av:'AV10GridState',fld:'vGRIDSTATE',pic:''},{av:'AV13OrderedBy',fld:'vORDEREDBY',pic:'ZZZ9'},{av:'AV14OrderedDsc',fld:'vORDEREDDSC',pic:''},{av:'AV48TFMonDsc',fld:'vTFMONDSC',pic:''},{av:'AV49TFMonDsc_Sel',fld:'vTFMONDSC_SEL',pic:''},{av:'AV31TFTipFech',fld:'vTFTIPFECH',pic:''},{av:'AV32TFTipFech_To',fld:'vTFTIPFECH_TO',pic:''},{av:'AV36TFTipCompra',fld:'vTFTIPCOMPRA',pic:'ZZZZZZZZ9.99999'},{av:'AV37TFTipCompra_To',fld:'vTFTIPCOMPRA_TO',pic:'ZZZZZZZZ9.99999'},{av:'AV38TFTipVenta',fld:'vTFTIPVENTA',pic:'ZZZZZZZZ9.99999'},{av:'AV39TFTipVenta_To',fld:'vTFTIPVENTA_TO',pic:'ZZZZZZZZ9.99999'},{av:'Ddo_grid_Selectedvalue_set',ctrl:'DDO_GRID',prop:'SelectedValue_set'},{av:'Ddo_grid_Filteredtext_set',ctrl:'DDO_GRID',prop:'FilteredText_set'},{av:'Ddo_grid_Filteredtextto_set',ctrl:'DDO_GRID',prop:'FilteredTextTo_set'},{av:'subGrid_Rows',ctrl:'GRID',prop:'Rows'},{av:'GRID_nFirstRecordOnPage'},{av:'GRID_nEOF'},{av:'cmbavDynamicfiltersselector1'},{av:'AV15DynamicFiltersSelector1',fld:'vDYNAMICFILTERSSELECTOR1',pic:''},{av:'cmbavDynamicfiltersoperator1'},{av:'AV16DynamicFiltersOperator1',fld:'vDYNAMICFILTERSOPERATOR1',pic:'ZZZ9'},{av:'AV50MonDsc1',fld:'vMONDSC1',pic:''},{av:'cmbavDynamicfiltersselector2'},{av:'AV19DynamicFiltersSelector2',fld:'vDYNAMICFILTERSSELECTOR2',pic:''},{av:'cmbavDynamicfiltersoperator2'},{av:'AV20DynamicFiltersOperator2',fld:'vDYNAMICFILTERSOPERATOR2',pic:'ZZZ9'},{av:'AV53MonDsc2',fld:'vMONDSC2',pic:''},{av:'cmbavDynamicfiltersselector3'},{av:'AV23DynamicFiltersSelector3',fld:'vDYNAMICFILTERSSELECTOR3',pic:''},{av:'cmbavDynamicfiltersoperator3'},{av:'AV24DynamicFiltersOperator3',fld:'vDYNAMICFILTERSOPERATOR3',pic:'ZZZ9'},{av:'AV56MonDsc3',fld:'vMONDSC3',pic:''},{av:'AV51TipFech1',fld:'vTIPFECH1',pic:''},{av:'AV54TipFech2',fld:'vTIPFECH2',pic:''},{av:'AV57TipFech3',fld:'vTIPFECH3',pic:''},{av:'AV18DynamicFiltersEnabled2',fld:'vDYNAMICFILTERSENABLED2',pic:''},{av:'AV22DynamicFiltersEnabled3',fld:'vDYNAMICFILTERSENABLED3',pic:''},{av:'AV64Pgmname',fld:'vPGMNAME',pic:'',hsh:true},{av:'AV52TipFech_To1',fld:'vTIPFECH_TO1',pic:''},{av:'AV55TipFech_To2',fld:'vTIPFECH_TO2',pic:''},{av:'AV58TipFech_To3',fld:'vTIPFECH_TO3',pic:''},{av:'AV27DynamicFiltersIgnoreFirst',fld:'vDYNAMICFILTERSIGNOREFIRST',pic:''},{av:'AV26DynamicFiltersRemoving',fld:'vDYNAMICFILTERSREMOVING',pic:''},{av:'A180MonCod',fld:'MONCOD',pic:'ZZZZZ9'},{av:'Gx_date',fld:'vTODAY',pic:'',hsh:true},{av:'Ddo_grid_Sortedstatus',ctrl:'DDO_GRID',prop:'SortedStatus'},{av:'imgAdddynamicfilters1_Visible',ctrl:'ADDDYNAMICFILTERS1',prop:'Visible'},{av:'imgRemovedynamicfilters1_Visible',ctrl:'REMOVEDYNAMICFILTERS1',prop:'Visible'},{av:'imgAdddynamicfilters2_Visible',ctrl:'ADDDYNAMICFILTERS2',prop:'Visible'},{av:'imgRemovedynamicfilters2_Visible',ctrl:'REMOVEDYNAMICFILTERS2',prop:'Visible'},{av:'lblJsdynamicfilters_Caption',ctrl:'JSDYNAMICFILTERS',prop:'Caption'},{av:'edtavMondsc1_Visible',ctrl:'vMONDSC1',prop:'Visible'},{av:'tblTablemergeddynamicfilterstipfech1_Visible',ctrl:'TABLEMERGEDDYNAMICFILTERSTIPFECH1',prop:'Visible'},{av:'edtavMondsc2_Visible',ctrl:'vMONDSC2',prop:'Visible'},{av:'tblTablemergeddynamicfilterstipfech2_Visible',ctrl:'TABLEMERGEDDYNAMICFILTERSTIPFECH2',prop:'Visible'},{av:'edtavMondsc3_Visible',ctrl:'vMONDSC3',prop:'Visible'},{av:'tblTablemergeddynamicfilterstipfech3_Visible',ctrl:'TABLEMERGEDDYNAMICFILTERSTIPFECH3',prop:'Visible'},{av:'cellTipfech_range_cell1_Class',ctrl:'TIPFECH_RANGE_CELL1',prop:'Class'},{av:'cellTipfech_range_cell2_Class',ctrl:'TIPFECH_RANGE_CELL2',prop:'Class'},{av:'cellTipfech_range_cell3_Class',ctrl:'TIPFECH_RANGE_CELL3',prop:'Class'}]}");
         setEventMetadata("LINKTIPOCAMBIO.CLICK","{handler:'E111W1',iparms:[]");
         setEventMetadata("LINKTIPOCAMBIO.CLICK",",oparms:[{av:'Innewwindow_Target',ctrl:'INNEWWINDOW',prop:'Target'},{av:'Innewwindow_Fullscreen',ctrl:'INNEWWINDOW',prop:'Fullscreen'},{av:'Innewwindow_Toolbar',ctrl:'INNEWWINDOW',prop:'ToolBar'}]}");
         setEventMetadata("VALID_TIPMONCOD","{handler:'Valid_Tipmoncod',iparms:[]");
         setEventMetadata("VALID_TIPMONCOD",",oparms:[]}");
         setEventMetadata("NULL","{handler:'Valid_Tipventa',iparms:[]");
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
         AV50MonDsc1 = "";
         AV19DynamicFiltersSelector2 = "";
         AV53MonDsc2 = "";
         AV23DynamicFiltersSelector3 = "";
         AV56MonDsc3 = "";
         AV51TipFech1 = DateTime.MinValue;
         AV54TipFech2 = DateTime.MinValue;
         AV57TipFech3 = DateTime.MinValue;
         AV64Pgmname = "";
         AV52TipFech_To1 = DateTime.MinValue;
         AV55TipFech_To2 = DateTime.MinValue;
         AV58TipFech_To3 = DateTime.MinValue;
         AV48TFMonDsc = "";
         AV49TFMonDsc_Sel = "";
         AV31TFTipFech = DateTime.MinValue;
         AV32TFTipFech_To = DateTime.MinValue;
         AV10GridState = new GeneXus.Programs.wwpbaseobjects.SdtWWPGridState(context);
         Gx_date = DateTime.MinValue;
         sDynURL = "";
         FormProcess = "";
         bodyStyle = "";
         GXKey = "";
         AV44GridAppliedFilters = "";
         AV46AGExportData = new GXBaseCollection<GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTDropDownOptionsData_Item>( context, "Item", "");
         AV40DDO_TitleSettingsIcons = new GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTDropDownOptionsTitleSettingsIcons(context);
         AV34DDO_TipFechAuxDateTo = DateTime.MinValue;
         AV33DDO_TipFechAuxDate = DateTime.MinValue;
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
         lblLinktipocambio_Jsonclick = "";
         GridContainer = new GXWebGrid( context);
         sStyleString = "";
         subGrid_Linesclass = "";
         GridColumn = new GXWebColumn();
         A1234MonDsc = "";
         A308TipFech = DateTime.MinValue;
         ucGridpaginationbar = new GXUserControl();
         ucInnewwindow = new GXUserControl();
         ucDdo_agexport = new GXUserControl();
         ucTipfech_rangepicker1 = new GXUserControl();
         ucTipfech_rangepicker2 = new GXUserControl();
         ucTipfech_rangepicker3 = new GXUserControl();
         lblJsdynamicfilters_Jsonclick = "";
         ucDdo_grid = new GXUserControl();
         ucInnewwindow1 = new GXUserControl();
         ucGrid_empowerer = new GXUserControl();
         AV35DDO_TipFechAuxDateText = "";
         ucTftipfech_rangepicker = new GXUserControl();
         sEvt = "";
         EvtGridId = "";
         EvtRowId = "";
         sEvtType = "";
         scmdbuf = "";
         lV67Configuracion_tipocambiowwds_3_mondsc1 = "";
         lV73Configuracion_tipocambiowwds_9_mondsc2 = "";
         lV79Configuracion_tipocambiowwds_15_mondsc3 = "";
         lV82Configuracion_tipocambiowwds_18_tfmondsc = "";
         AV65Configuracion_tipocambiowwds_1_dynamicfiltersselector1 = "";
         AV67Configuracion_tipocambiowwds_3_mondsc1 = "";
         AV68Configuracion_tipocambiowwds_4_tipfech1 = DateTime.MinValue;
         AV69Configuracion_tipocambiowwds_5_tipfech_to1 = DateTime.MinValue;
         AV71Configuracion_tipocambiowwds_7_dynamicfiltersselector2 = "";
         AV73Configuracion_tipocambiowwds_9_mondsc2 = "";
         AV74Configuracion_tipocambiowwds_10_tipfech2 = DateTime.MinValue;
         AV75Configuracion_tipocambiowwds_11_tipfech_to2 = DateTime.MinValue;
         AV77Configuracion_tipocambiowwds_13_dynamicfiltersselector3 = "";
         AV79Configuracion_tipocambiowwds_15_mondsc3 = "";
         AV80Configuracion_tipocambiowwds_16_tipfech3 = DateTime.MinValue;
         AV81Configuracion_tipocambiowwds_17_tipfech_to3 = DateTime.MinValue;
         AV83Configuracion_tipocambiowwds_19_tfmondsc_sel = "";
         AV82Configuracion_tipocambiowwds_18_tfmondsc = "";
         AV84Configuracion_tipocambiowwds_20_tftipfech = DateTime.MinValue;
         AV85Configuracion_tipocambiowwds_21_tftipfech_to = DateTime.MinValue;
         H001W2_A1920TipVenta = new decimal[1] ;
         H001W2_A1907TipCompra = new decimal[1] ;
         H001W2_A308TipFech = new DateTime[] {DateTime.MinValue} ;
         H001W2_A1234MonDsc = new string[] {""} ;
         H001W2_n1234MonDsc = new bool[] {false} ;
         H001W2_A307TipMonCod = new int[1] ;
         H001W3_AGRID_nRecordCount = new long[1] ;
         AV59TipFech_RangeText1 = "";
         AV60TipFech_RangeText2 = "";
         AV61TipFech_RangeText3 = "";
         imgAdddynamicfilters1_Jsonclick = "";
         imgRemovedynamicfilters1_Jsonclick = "";
         imgAdddynamicfilters2_Jsonclick = "";
         imgRemovedynamicfilters2_Jsonclick = "";
         imgRemovedynamicfilters3_Jsonclick = "";
         AV47AGExportDataItem = new GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTDropDownOptionsData_Item(context);
         GXt_SdtDVB_SDTDropDownOptionsTitleSettingsIcons1 = new GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTDropDownOptionsTitleSettingsIcons(context);
         AV6WWPContext = new GeneXus.Programs.wwpbaseobjects.SdtWWPContext(context);
         GXEncryptionTmp = "";
         GridRow = new GXWebRow();
         AV30Session = context.GetSession();
         AV11GridStateFilterValue = new GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue(context);
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
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.configuracion.tipocambioww__default(),
            new Object[][] {
                new Object[] {
               H001W2_A1920TipVenta, H001W2_A1907TipCompra, H001W2_A308TipFech, H001W2_A1234MonDsc, H001W2_n1234MonDsc, H001W2_A307TipMonCod
               }
               , new Object[] {
               H001W3_AGRID_nRecordCount
               }
            }
         );
         Gx_date = DateTimeUtil.Today( context);
         AV64Pgmname = "Configuracion.TipoCambioWW";
         /* GeneXus formulas. */
         Gx_date = DateTimeUtil.Today( context);
         AV64Pgmname = "Configuracion.TipoCambioWW";
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
      private short AV45GridActions ;
      private short subGrid_Allowselection ;
      private short subGrid_Allowhovering ;
      private short subGrid_Allowcollapsing ;
      private short subGrid_Collapsed ;
      private short nDonePA ;
      private short AV66Configuracion_tipocambiowwds_2_dynamicfiltersoperator1 ;
      private short AV72Configuracion_tipocambiowwds_8_dynamicfiltersoperator2 ;
      private short AV78Configuracion_tipocambiowwds_14_dynamicfiltersoperator3 ;
      private short nGXWrapped ;
      private short subGrid_Backstyle ;
      private int subGrid_Rows ;
      private int Gridpaginationbar_Rowsperpageselectedvalue ;
      private int nRC_GXsfl_121 ;
      private int nGXsfl_121_idx=1 ;
      private int A180MonCod ;
      private int Gridpaginationbar_Pagestoshow ;
      private int subGrid_Titlebackcolor ;
      private int subGrid_Allbackcolor ;
      private int A307TipMonCod ;
      private int subGrid_Selectedindex ;
      private int subGrid_Selectioncolor ;
      private int subGrid_Hoveringcolor ;
      private int subGrid_Islastpage ;
      private int GXPagingFrom2 ;
      private int GXPagingTo2 ;
      private int AV41PageToGo ;
      private int imgAdddynamicfilters1_Visible ;
      private int imgRemovedynamicfilters1_Visible ;
      private int imgAdddynamicfilters2_Visible ;
      private int imgRemovedynamicfilters2_Visible ;
      private int edtavMondsc1_Visible ;
      private int tblTablemergeddynamicfilterstipfech1_Visible ;
      private int edtavMondsc2_Visible ;
      private int tblTablemergeddynamicfilterstipfech2_Visible ;
      private int edtavMondsc3_Visible ;
      private int tblTablemergeddynamicfilterstipfech3_Visible ;
      private int AV91GXV1 ;
      private int edtavMondsc3_Enabled ;
      private int edtavTipfech_rangetext3_Enabled ;
      private int edtavMondsc2_Enabled ;
      private int edtavTipfech_rangetext2_Enabled ;
      private int edtavMondsc1_Enabled ;
      private int edtavTipfech_rangetext1_Enabled ;
      private int idxLst ;
      private int subGrid_Backcolor ;
      private long GRID_nFirstRecordOnPage ;
      private long AV42GridCurrentPage ;
      private long AV43GridPageCount ;
      private long GRID_nCurrentRecord ;
      private long GRID_nRecordCount ;
      private decimal AV36TFTipCompra ;
      private decimal AV37TFTipCompra_To ;
      private decimal AV38TFTipVenta ;
      private decimal AV39TFTipVenta_To ;
      private decimal A1907TipCompra ;
      private decimal A1920TipVenta ;
      private decimal AV86Configuracion_tipocambiowwds_22_tftipcompra ;
      private decimal AV87Configuracion_tipocambiowwds_23_tftipcompra_to ;
      private decimal AV88Configuracion_tipocambiowwds_24_tftipventa ;
      private decimal AV89Configuracion_tipocambiowwds_25_tftipventa_to ;
      private string Gridpaginationbar_Selectedpage ;
      private string Ddo_grid_Activeeventkey ;
      private string Ddo_grid_Selectedvalue_get ;
      private string Ddo_grid_Selectedcolumn ;
      private string Ddo_grid_Filteredtext_get ;
      private string Ddo_grid_Filteredtextto_get ;
      private string Ddo_agexport_Activeeventkey ;
      private string gxfirstwebparm ;
      private string gxfirstwebparm_bkp ;
      private string sGXsfl_121_idx="0001" ;
      private string AV50MonDsc1 ;
      private string AV53MonDsc2 ;
      private string AV56MonDsc3 ;
      private string AV64Pgmname ;
      private string AV48TFMonDsc ;
      private string AV49TFMonDsc_Sel ;
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
      private string Innewwindow_Target ;
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
      private string lblLinktipocambio_Internalname ;
      private string lblLinktipocambio_Jsonclick ;
      private string divTablerightheader_Internalname ;
      private string divGridtablewithpaginationbar_Internalname ;
      private string sStyleString ;
      private string subGrid_Internalname ;
      private string subGrid_Class ;
      private string subGrid_Linesclass ;
      private string subGrid_Header ;
      private string A1234MonDsc ;
      private string edtMonDsc_Link ;
      private string edtTipCompra_Link ;
      private string Gridpaginationbar_Internalname ;
      private string Innewwindow_Internalname ;
      private string divHtml_bottomauxiliarcontrols_Internalname ;
      private string Ddo_agexport_Internalname ;
      private string Tipfech_rangepicker1_Internalname ;
      private string Tipfech_rangepicker2_Internalname ;
      private string Tipfech_rangepicker3_Internalname ;
      private string lblJsdynamicfilters_Internalname ;
      private string lblJsdynamicfilters_Caption ;
      private string lblJsdynamicfilters_Jsonclick ;
      private string Ddo_grid_Internalname ;
      private string Innewwindow1_Internalname ;
      private string Grid_empowerer_Internalname ;
      private string divDdo_tipfechauxdates_Internalname ;
      private string edtavDdo_tipfechauxdatetext_Internalname ;
      private string edtavDdo_tipfechauxdatetext_Jsonclick ;
      private string Tftipfech_rangepicker_Internalname ;
      private string sEvt ;
      private string EvtGridId ;
      private string EvtRowId ;
      private string sEvtType ;
      private string cmbavGridactions_Internalname ;
      private string edtTipMonCod_Internalname ;
      private string edtMonDsc_Internalname ;
      private string edtTipFech_Internalname ;
      private string edtTipCompra_Internalname ;
      private string edtTipVenta_Internalname ;
      private string cmbavDynamicfiltersselector1_Internalname ;
      private string cmbavDynamicfiltersoperator1_Internalname ;
      private string cmbavDynamicfiltersselector2_Internalname ;
      private string cmbavDynamicfiltersoperator2_Internalname ;
      private string cmbavDynamicfiltersselector3_Internalname ;
      private string cmbavDynamicfiltersoperator3_Internalname ;
      private string scmdbuf ;
      private string lV67Configuracion_tipocambiowwds_3_mondsc1 ;
      private string lV73Configuracion_tipocambiowwds_9_mondsc2 ;
      private string lV79Configuracion_tipocambiowwds_15_mondsc3 ;
      private string lV82Configuracion_tipocambiowwds_18_tfmondsc ;
      private string AV67Configuracion_tipocambiowwds_3_mondsc1 ;
      private string AV73Configuracion_tipocambiowwds_9_mondsc2 ;
      private string AV79Configuracion_tipocambiowwds_15_mondsc3 ;
      private string AV83Configuracion_tipocambiowwds_19_tfmondsc_sel ;
      private string AV82Configuracion_tipocambiowwds_18_tfmondsc ;
      private string edtavMondsc1_Internalname ;
      private string edtavTipfech_rangetext1_Internalname ;
      private string edtavMondsc2_Internalname ;
      private string edtavTipfech_rangetext2_Internalname ;
      private string edtavMondsc3_Internalname ;
      private string edtavTipfech_rangetext3_Internalname ;
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
      private string tblTablemergeddynamicfilterstipfech1_Internalname ;
      private string cellTipfech_range_cell1_Class ;
      private string cellTipfech_range_cell1_Internalname ;
      private string tblTablemergeddynamicfilterstipfech2_Internalname ;
      private string cellTipfech_range_cell2_Class ;
      private string cellTipfech_range_cell2_Internalname ;
      private string tblTablemergeddynamicfilterstipfech3_Internalname ;
      private string cellTipfech_range_cell3_Class ;
      private string cellTipfech_range_cell3_Internalname ;
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
      private string cellFilter_mondsc3_cell_Internalname ;
      private string edtavMondsc3_Jsonclick ;
      private string cellFilter_tipfech3_cell_Internalname ;
      private string cellDynamicfilters_removefilter3_cell_Internalname ;
      private string sImgUrl ;
      private string edtavTipfech_rangetext3_Jsonclick ;
      private string tblTablemergeddynamicfilters2_Internalname ;
      private string cmbavDynamicfiltersoperator2_Jsonclick ;
      private string cellFilter_mondsc2_cell_Internalname ;
      private string edtavMondsc2_Jsonclick ;
      private string cellFilter_tipfech2_cell_Internalname ;
      private string cellDynamicfilters_addfilter2_cell_Internalname ;
      private string cellDynamicfilters_removefilter2_cell_Internalname ;
      private string edtavTipfech_rangetext2_Jsonclick ;
      private string tblTablemergeddynamicfilters1_Internalname ;
      private string cmbavDynamicfiltersoperator1_Jsonclick ;
      private string cellFilter_mondsc1_cell_Internalname ;
      private string edtavMondsc1_Jsonclick ;
      private string cellFilter_tipfech1_cell_Internalname ;
      private string cellDynamicfilters_addfilter1_cell_Internalname ;
      private string cellDynamicfilters_removefilter1_cell_Internalname ;
      private string edtavTipfech_rangetext1_Jsonclick ;
      private string sGXsfl_121_fel_idx="0001" ;
      private string GXCCtl ;
      private string cmbavGridactions_Jsonclick ;
      private string ROClassString ;
      private string edtTipMonCod_Jsonclick ;
      private string edtMonDsc_Jsonclick ;
      private string edtTipFech_Jsonclick ;
      private string edtTipCompra_Jsonclick ;
      private string edtTipVenta_Jsonclick ;
      private DateTime AV51TipFech1 ;
      private DateTime AV54TipFech2 ;
      private DateTime AV57TipFech3 ;
      private DateTime AV52TipFech_To1 ;
      private DateTime AV55TipFech_To2 ;
      private DateTime AV58TipFech_To3 ;
      private DateTime AV31TFTipFech ;
      private DateTime AV32TFTipFech_To ;
      private DateTime Gx_date ;
      private DateTime AV34DDO_TipFechAuxDateTo ;
      private DateTime AV33DDO_TipFechAuxDate ;
      private DateTime A308TipFech ;
      private DateTime AV68Configuracion_tipocambiowwds_4_tipfech1 ;
      private DateTime AV69Configuracion_tipocambiowwds_5_tipfech_to1 ;
      private DateTime AV74Configuracion_tipocambiowwds_10_tipfech2 ;
      private DateTime AV75Configuracion_tipocambiowwds_11_tipfech_to2 ;
      private DateTime AV80Configuracion_tipocambiowwds_16_tipfech3 ;
      private DateTime AV81Configuracion_tipocambiowwds_17_tipfech_to3 ;
      private DateTime AV84Configuracion_tipocambiowwds_20_tftipfech ;
      private DateTime AV85Configuracion_tipocambiowwds_21_tftipfech_to ;
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
      private bool Innewwindow_Fullscreen ;
      private bool Innewwindow_Toolbar ;
      private bool Grid_empowerer_Hastitlesettings ;
      private bool wbLoad ;
      private bool Rfr0gs ;
      private bool wbErr ;
      private bool n1234MonDsc ;
      private bool bGXsfl_121_Refreshing=false ;
      private bool gxdyncontrolsrefreshing ;
      private bool AV70Configuracion_tipocambiowwds_6_dynamicfiltersenabled2 ;
      private bool AV76Configuracion_tipocambiowwds_12_dynamicfiltersenabled3 ;
      private bool returnInSub ;
      private bool gx_refresh_fired ;
      private string AV15DynamicFiltersSelector1 ;
      private string AV19DynamicFiltersSelector2 ;
      private string AV23DynamicFiltersSelector3 ;
      private string AV44GridAppliedFilters ;
      private string AV35DDO_TipFechAuxDateText ;
      private string AV65Configuracion_tipocambiowwds_1_dynamicfiltersselector1 ;
      private string AV71Configuracion_tipocambiowwds_7_dynamicfiltersselector2 ;
      private string AV77Configuracion_tipocambiowwds_13_dynamicfiltersselector3 ;
      private string AV59TipFech_RangeText1 ;
      private string AV60TipFech_RangeText2 ;
      private string AV61TipFech_RangeText3 ;
      private string AV28ExcelFilename ;
      private string AV29ErrorMessage ;
      private IGxSession AV30Session ;
      private GXWebGrid GridContainer ;
      private GXWebRow GridRow ;
      private GXWebColumn GridColumn ;
      private GXUserControl ucDvpanel_tableheader ;
      private GXUserControl ucGridpaginationbar ;
      private GXUserControl ucInnewwindow ;
      private GXUserControl ucDdo_agexport ;
      private GXUserControl ucTipfech_rangepicker1 ;
      private GXUserControl ucTipfech_rangepicker2 ;
      private GXUserControl ucTipfech_rangepicker3 ;
      private GXUserControl ucDdo_grid ;
      private GXUserControl ucInnewwindow1 ;
      private GXUserControl ucGrid_empowerer ;
      private GXUserControl ucTftipfech_rangepicker ;
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
      private decimal[] H001W2_A1920TipVenta ;
      private decimal[] H001W2_A1907TipCompra ;
      private DateTime[] H001W2_A308TipFech ;
      private string[] H001W2_A1234MonDsc ;
      private bool[] H001W2_n1234MonDsc ;
      private int[] H001W2_A307TipMonCod ;
      private long[] H001W3_AGRID_nRecordCount ;
      private msglist BackMsgLst ;
      private msglist LclMsgLst ;
      private GxHttpRequest AV7HTTPRequest ;
      private GXBaseCollection<GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTDropDownOptionsData_Item> AV46AGExportData ;
      private GXWebForm Form ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPContext AV6WWPContext ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPTransactionContext AV8TrnContext ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPGridState AV10GridState ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue AV11GridStateFilterValue ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter AV12GridStateDynamicFilter ;
      private GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTDropDownOptionsTitleSettingsIcons AV40DDO_TitleSettingsIcons ;
      private GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTDropDownOptionsTitleSettingsIcons GXt_SdtDVB_SDTDropDownOptionsTitleSettingsIcons1 ;
      private GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTDropDownOptionsData_Item AV47AGExportDataItem ;
   }

   public class tipocambioww__default : DataStoreHelperBase, IDataStoreHelper
   {
      protected Object[] conditional_H001W2( IGxContext context ,
                                             string AV65Configuracion_tipocambiowwds_1_dynamicfiltersselector1 ,
                                             short AV66Configuracion_tipocambiowwds_2_dynamicfiltersoperator1 ,
                                             string AV67Configuracion_tipocambiowwds_3_mondsc1 ,
                                             DateTime AV68Configuracion_tipocambiowwds_4_tipfech1 ,
                                             DateTime AV69Configuracion_tipocambiowwds_5_tipfech_to1 ,
                                             bool AV70Configuracion_tipocambiowwds_6_dynamicfiltersenabled2 ,
                                             string AV71Configuracion_tipocambiowwds_7_dynamicfiltersselector2 ,
                                             short AV72Configuracion_tipocambiowwds_8_dynamicfiltersoperator2 ,
                                             string AV73Configuracion_tipocambiowwds_9_mondsc2 ,
                                             DateTime AV74Configuracion_tipocambiowwds_10_tipfech2 ,
                                             DateTime AV75Configuracion_tipocambiowwds_11_tipfech_to2 ,
                                             bool AV76Configuracion_tipocambiowwds_12_dynamicfiltersenabled3 ,
                                             string AV77Configuracion_tipocambiowwds_13_dynamicfiltersselector3 ,
                                             short AV78Configuracion_tipocambiowwds_14_dynamicfiltersoperator3 ,
                                             string AV79Configuracion_tipocambiowwds_15_mondsc3 ,
                                             DateTime AV80Configuracion_tipocambiowwds_16_tipfech3 ,
                                             DateTime AV81Configuracion_tipocambiowwds_17_tipfech_to3 ,
                                             string AV83Configuracion_tipocambiowwds_19_tfmondsc_sel ,
                                             string AV82Configuracion_tipocambiowwds_18_tfmondsc ,
                                             DateTime AV84Configuracion_tipocambiowwds_20_tftipfech ,
                                             DateTime AV85Configuracion_tipocambiowwds_21_tftipfech_to ,
                                             decimal AV86Configuracion_tipocambiowwds_22_tftipcompra ,
                                             decimal AV87Configuracion_tipocambiowwds_23_tftipcompra_to ,
                                             decimal AV88Configuracion_tipocambiowwds_24_tftipventa ,
                                             decimal AV89Configuracion_tipocambiowwds_25_tftipventa_to ,
                                             string A1234MonDsc ,
                                             DateTime A308TipFech ,
                                             decimal A1907TipCompra ,
                                             decimal A1920TipVenta ,
                                             short AV13OrderedBy ,
                                             bool AV14OrderedDsc )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int3 = new short[32];
         Object[] GXv_Object4 = new Object[2];
         string sSelectString;
         string sFromString;
         string sOrderString;
         sSelectString = " T1.[TipVenta], T1.[TipCompra], T1.[TipFech], T2.[MonDsc], T1.[TipMonCod] AS TipMonCod";
         sFromString = " FROM ([CTIPOCAMBIO] T1 INNER JOIN [CMONEDAS] T2 ON T2.[MonCod] = T1.[TipMonCod])";
         sOrderString = "";
         if ( ( StringUtil.StrCmp(AV65Configuracion_tipocambiowwds_1_dynamicfiltersselector1, "MONDSC") == 0 ) && ( AV66Configuracion_tipocambiowwds_2_dynamicfiltersoperator1 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV67Configuracion_tipocambiowwds_3_mondsc1)) ) )
         {
            AddWhere(sWhereString, "(T2.[MonDsc] like @lV67Configuracion_tipocambiowwds_3_mondsc1)");
         }
         else
         {
            GXv_int3[0] = 1;
         }
         if ( ( StringUtil.StrCmp(AV65Configuracion_tipocambiowwds_1_dynamicfiltersselector1, "MONDSC") == 0 ) && ( AV66Configuracion_tipocambiowwds_2_dynamicfiltersoperator1 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV67Configuracion_tipocambiowwds_3_mondsc1)) ) )
         {
            AddWhere(sWhereString, "(T2.[MonDsc] like '%' + @lV67Configuracion_tipocambiowwds_3_mondsc1)");
         }
         else
         {
            GXv_int3[1] = 1;
         }
         if ( ( StringUtil.StrCmp(AV65Configuracion_tipocambiowwds_1_dynamicfiltersselector1, "TIPFECH") == 0 ) && ( AV66Configuracion_tipocambiowwds_2_dynamicfiltersoperator1 == 0 ) && ( ! (DateTime.MinValue==AV68Configuracion_tipocambiowwds_4_tipfech1) ) )
         {
            AddWhere(sWhereString, "(T1.[TipFech] < @AV68Configuracion_tipocambiowwds_4_tipfech1)");
         }
         else
         {
            GXv_int3[2] = 1;
         }
         if ( ( StringUtil.StrCmp(AV65Configuracion_tipocambiowwds_1_dynamicfiltersselector1, "TIPFECH") == 0 ) && ( AV66Configuracion_tipocambiowwds_2_dynamicfiltersoperator1 == 1 ) && ( ! (DateTime.MinValue==AV68Configuracion_tipocambiowwds_4_tipfech1) ) )
         {
            AddWhere(sWhereString, "(T1.[TipFech] = @AV68Configuracion_tipocambiowwds_4_tipfech1)");
         }
         else
         {
            GXv_int3[3] = 1;
         }
         if ( ( StringUtil.StrCmp(AV65Configuracion_tipocambiowwds_1_dynamicfiltersselector1, "TIPFECH") == 0 ) && ( AV66Configuracion_tipocambiowwds_2_dynamicfiltersoperator1 == 2 ) && ( ! (DateTime.MinValue==AV68Configuracion_tipocambiowwds_4_tipfech1) ) )
         {
            AddWhere(sWhereString, "(T1.[TipFech] > @AV68Configuracion_tipocambiowwds_4_tipfech1)");
         }
         else
         {
            GXv_int3[4] = 1;
         }
         if ( ( StringUtil.StrCmp(AV65Configuracion_tipocambiowwds_1_dynamicfiltersselector1, "TIPFECH") == 0 ) && ( AV66Configuracion_tipocambiowwds_2_dynamicfiltersoperator1 == 3 ) && ( ! (DateTime.MinValue==AV68Configuracion_tipocambiowwds_4_tipfech1) ) )
         {
            AddWhere(sWhereString, "(T1.[TipFech] >= @AV68Configuracion_tipocambiowwds_4_tipfech1)");
         }
         else
         {
            GXv_int3[5] = 1;
         }
         if ( ( StringUtil.StrCmp(AV65Configuracion_tipocambiowwds_1_dynamicfiltersselector1, "TIPFECH") == 0 ) && ( AV66Configuracion_tipocambiowwds_2_dynamicfiltersoperator1 == 3 ) && ( ! (DateTime.MinValue==AV69Configuracion_tipocambiowwds_5_tipfech_to1) ) )
         {
            AddWhere(sWhereString, "(T1.[TipFech] <= @AV69Configuracion_tipocambiowwds_5_tipfech_to1)");
         }
         else
         {
            GXv_int3[6] = 1;
         }
         if ( AV70Configuracion_tipocambiowwds_6_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV71Configuracion_tipocambiowwds_7_dynamicfiltersselector2, "MONDSC") == 0 ) && ( AV72Configuracion_tipocambiowwds_8_dynamicfiltersoperator2 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV73Configuracion_tipocambiowwds_9_mondsc2)) ) )
         {
            AddWhere(sWhereString, "(T2.[MonDsc] like @lV73Configuracion_tipocambiowwds_9_mondsc2)");
         }
         else
         {
            GXv_int3[7] = 1;
         }
         if ( AV70Configuracion_tipocambiowwds_6_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV71Configuracion_tipocambiowwds_7_dynamicfiltersselector2, "MONDSC") == 0 ) && ( AV72Configuracion_tipocambiowwds_8_dynamicfiltersoperator2 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV73Configuracion_tipocambiowwds_9_mondsc2)) ) )
         {
            AddWhere(sWhereString, "(T2.[MonDsc] like '%' + @lV73Configuracion_tipocambiowwds_9_mondsc2)");
         }
         else
         {
            GXv_int3[8] = 1;
         }
         if ( AV70Configuracion_tipocambiowwds_6_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV71Configuracion_tipocambiowwds_7_dynamicfiltersselector2, "TIPFECH") == 0 ) && ( AV72Configuracion_tipocambiowwds_8_dynamicfiltersoperator2 == 0 ) && ( ! (DateTime.MinValue==AV74Configuracion_tipocambiowwds_10_tipfech2) ) )
         {
            AddWhere(sWhereString, "(T1.[TipFech] < @AV74Configuracion_tipocambiowwds_10_tipfech2)");
         }
         else
         {
            GXv_int3[9] = 1;
         }
         if ( AV70Configuracion_tipocambiowwds_6_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV71Configuracion_tipocambiowwds_7_dynamicfiltersselector2, "TIPFECH") == 0 ) && ( AV72Configuracion_tipocambiowwds_8_dynamicfiltersoperator2 == 1 ) && ( ! (DateTime.MinValue==AV74Configuracion_tipocambiowwds_10_tipfech2) ) )
         {
            AddWhere(sWhereString, "(T1.[TipFech] = @AV74Configuracion_tipocambiowwds_10_tipfech2)");
         }
         else
         {
            GXv_int3[10] = 1;
         }
         if ( AV70Configuracion_tipocambiowwds_6_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV71Configuracion_tipocambiowwds_7_dynamicfiltersselector2, "TIPFECH") == 0 ) && ( AV72Configuracion_tipocambiowwds_8_dynamicfiltersoperator2 == 2 ) && ( ! (DateTime.MinValue==AV74Configuracion_tipocambiowwds_10_tipfech2) ) )
         {
            AddWhere(sWhereString, "(T1.[TipFech] > @AV74Configuracion_tipocambiowwds_10_tipfech2)");
         }
         else
         {
            GXv_int3[11] = 1;
         }
         if ( AV70Configuracion_tipocambiowwds_6_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV71Configuracion_tipocambiowwds_7_dynamicfiltersselector2, "TIPFECH") == 0 ) && ( AV72Configuracion_tipocambiowwds_8_dynamicfiltersoperator2 == 3 ) && ( ! (DateTime.MinValue==AV74Configuracion_tipocambiowwds_10_tipfech2) ) )
         {
            AddWhere(sWhereString, "(T1.[TipFech] >= @AV74Configuracion_tipocambiowwds_10_tipfech2)");
         }
         else
         {
            GXv_int3[12] = 1;
         }
         if ( AV70Configuracion_tipocambiowwds_6_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV71Configuracion_tipocambiowwds_7_dynamicfiltersselector2, "TIPFECH") == 0 ) && ( AV72Configuracion_tipocambiowwds_8_dynamicfiltersoperator2 == 3 ) && ( ! (DateTime.MinValue==AV75Configuracion_tipocambiowwds_11_tipfech_to2) ) )
         {
            AddWhere(sWhereString, "(T1.[TipFech] <= @AV75Configuracion_tipocambiowwds_11_tipfech_to2)");
         }
         else
         {
            GXv_int3[13] = 1;
         }
         if ( AV76Configuracion_tipocambiowwds_12_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV77Configuracion_tipocambiowwds_13_dynamicfiltersselector3, "MONDSC") == 0 ) && ( AV78Configuracion_tipocambiowwds_14_dynamicfiltersoperator3 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV79Configuracion_tipocambiowwds_15_mondsc3)) ) )
         {
            AddWhere(sWhereString, "(T2.[MonDsc] like @lV79Configuracion_tipocambiowwds_15_mondsc3)");
         }
         else
         {
            GXv_int3[14] = 1;
         }
         if ( AV76Configuracion_tipocambiowwds_12_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV77Configuracion_tipocambiowwds_13_dynamicfiltersselector3, "MONDSC") == 0 ) && ( AV78Configuracion_tipocambiowwds_14_dynamicfiltersoperator3 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV79Configuracion_tipocambiowwds_15_mondsc3)) ) )
         {
            AddWhere(sWhereString, "(T2.[MonDsc] like '%' + @lV79Configuracion_tipocambiowwds_15_mondsc3)");
         }
         else
         {
            GXv_int3[15] = 1;
         }
         if ( AV76Configuracion_tipocambiowwds_12_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV77Configuracion_tipocambiowwds_13_dynamicfiltersselector3, "TIPFECH") == 0 ) && ( AV78Configuracion_tipocambiowwds_14_dynamicfiltersoperator3 == 0 ) && ( ! (DateTime.MinValue==AV80Configuracion_tipocambiowwds_16_tipfech3) ) )
         {
            AddWhere(sWhereString, "(T1.[TipFech] < @AV80Configuracion_tipocambiowwds_16_tipfech3)");
         }
         else
         {
            GXv_int3[16] = 1;
         }
         if ( AV76Configuracion_tipocambiowwds_12_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV77Configuracion_tipocambiowwds_13_dynamicfiltersselector3, "TIPFECH") == 0 ) && ( AV78Configuracion_tipocambiowwds_14_dynamicfiltersoperator3 == 1 ) && ( ! (DateTime.MinValue==AV80Configuracion_tipocambiowwds_16_tipfech3) ) )
         {
            AddWhere(sWhereString, "(T1.[TipFech] = @AV80Configuracion_tipocambiowwds_16_tipfech3)");
         }
         else
         {
            GXv_int3[17] = 1;
         }
         if ( AV76Configuracion_tipocambiowwds_12_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV77Configuracion_tipocambiowwds_13_dynamicfiltersselector3, "TIPFECH") == 0 ) && ( AV78Configuracion_tipocambiowwds_14_dynamicfiltersoperator3 == 2 ) && ( ! (DateTime.MinValue==AV80Configuracion_tipocambiowwds_16_tipfech3) ) )
         {
            AddWhere(sWhereString, "(T1.[TipFech] > @AV80Configuracion_tipocambiowwds_16_tipfech3)");
         }
         else
         {
            GXv_int3[18] = 1;
         }
         if ( AV76Configuracion_tipocambiowwds_12_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV77Configuracion_tipocambiowwds_13_dynamicfiltersselector3, "TIPFECH") == 0 ) && ( AV78Configuracion_tipocambiowwds_14_dynamicfiltersoperator3 == 3 ) && ( ! (DateTime.MinValue==AV80Configuracion_tipocambiowwds_16_tipfech3) ) )
         {
            AddWhere(sWhereString, "(T1.[TipFech] >= @AV80Configuracion_tipocambiowwds_16_tipfech3)");
         }
         else
         {
            GXv_int3[19] = 1;
         }
         if ( AV76Configuracion_tipocambiowwds_12_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV77Configuracion_tipocambiowwds_13_dynamicfiltersselector3, "TIPFECH") == 0 ) && ( AV78Configuracion_tipocambiowwds_14_dynamicfiltersoperator3 == 3 ) && ( ! (DateTime.MinValue==AV81Configuracion_tipocambiowwds_17_tipfech_to3) ) )
         {
            AddWhere(sWhereString, "(T1.[TipFech] <= @AV81Configuracion_tipocambiowwds_17_tipfech_to3)");
         }
         else
         {
            GXv_int3[20] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV83Configuracion_tipocambiowwds_19_tfmondsc_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV82Configuracion_tipocambiowwds_18_tfmondsc)) ) )
         {
            AddWhere(sWhereString, "(T2.[MonDsc] like @lV82Configuracion_tipocambiowwds_18_tfmondsc)");
         }
         else
         {
            GXv_int3[21] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV83Configuracion_tipocambiowwds_19_tfmondsc_sel)) )
         {
            AddWhere(sWhereString, "(T2.[MonDsc] = @AV83Configuracion_tipocambiowwds_19_tfmondsc_sel)");
         }
         else
         {
            GXv_int3[22] = 1;
         }
         if ( ! (DateTime.MinValue==AV84Configuracion_tipocambiowwds_20_tftipfech) )
         {
            AddWhere(sWhereString, "(T1.[TipFech] >= @AV84Configuracion_tipocambiowwds_20_tftipfech)");
         }
         else
         {
            GXv_int3[23] = 1;
         }
         if ( ! (DateTime.MinValue==AV85Configuracion_tipocambiowwds_21_tftipfech_to) )
         {
            AddWhere(sWhereString, "(T1.[TipFech] <= @AV85Configuracion_tipocambiowwds_21_tftipfech_to)");
         }
         else
         {
            GXv_int3[24] = 1;
         }
         if ( ! (Convert.ToDecimal(0)==AV86Configuracion_tipocambiowwds_22_tftipcompra) )
         {
            AddWhere(sWhereString, "(T1.[TipCompra] >= @AV86Configuracion_tipocambiowwds_22_tftipcompra)");
         }
         else
         {
            GXv_int3[25] = 1;
         }
         if ( ! (Convert.ToDecimal(0)==AV87Configuracion_tipocambiowwds_23_tftipcompra_to) )
         {
            AddWhere(sWhereString, "(T1.[TipCompra] <= @AV87Configuracion_tipocambiowwds_23_tftipcompra_to)");
         }
         else
         {
            GXv_int3[26] = 1;
         }
         if ( ! (Convert.ToDecimal(0)==AV88Configuracion_tipocambiowwds_24_tftipventa) )
         {
            AddWhere(sWhereString, "(T1.[TipVenta] >= @AV88Configuracion_tipocambiowwds_24_tftipventa)");
         }
         else
         {
            GXv_int3[27] = 1;
         }
         if ( ! (Convert.ToDecimal(0)==AV89Configuracion_tipocambiowwds_25_tftipventa_to) )
         {
            AddWhere(sWhereString, "(T1.[TipVenta] <= @AV89Configuracion_tipocambiowwds_25_tftipventa_to)");
         }
         else
         {
            GXv_int3[28] = 1;
         }
         if ( ( AV13OrderedBy == 1 ) && ! AV14OrderedDsc )
         {
            sOrderString += " ORDER BY T1.[TipFech]";
         }
         else if ( ( AV13OrderedBy == 1 ) && ( AV14OrderedDsc ) )
         {
            sOrderString += " ORDER BY T1.[TipFech] DESC";
         }
         else if ( ( AV13OrderedBy == 2 ) && ! AV14OrderedDsc )
         {
            sOrderString += " ORDER BY T2.[MonDsc]";
         }
         else if ( ( AV13OrderedBy == 2 ) && ( AV14OrderedDsc ) )
         {
            sOrderString += " ORDER BY T2.[MonDsc] DESC";
         }
         else if ( ( AV13OrderedBy == 3 ) && ! AV14OrderedDsc )
         {
            sOrderString += " ORDER BY T1.[TipCompra]";
         }
         else if ( ( AV13OrderedBy == 3 ) && ( AV14OrderedDsc ) )
         {
            sOrderString += " ORDER BY T1.[TipCompra] DESC";
         }
         else if ( ( AV13OrderedBy == 4 ) && ! AV14OrderedDsc )
         {
            sOrderString += " ORDER BY T1.[TipVenta]";
         }
         else if ( ( AV13OrderedBy == 4 ) && ( AV14OrderedDsc ) )
         {
            sOrderString += " ORDER BY T1.[TipVenta] DESC";
         }
         else if ( true )
         {
            sOrderString += " ORDER BY T1.[TipMonCod], T1.[TipFech]";
         }
         scmdbuf = "SELECT " + sSelectString + sFromString + sWhereString + sOrderString + "" + " OFFSET " + "@GXPagingFrom2" + " ROWS FETCH NEXT CAST((SELECT CASE WHEN " + "@GXPagingTo2" + " > 0 THEN " + "@GXPagingTo2" + " ELSE 1e9 END) AS INTEGER) ROWS ONLY";
         GXv_Object4[0] = scmdbuf;
         GXv_Object4[1] = GXv_int3;
         return GXv_Object4 ;
      }

      protected Object[] conditional_H001W3( IGxContext context ,
                                             string AV65Configuracion_tipocambiowwds_1_dynamicfiltersselector1 ,
                                             short AV66Configuracion_tipocambiowwds_2_dynamicfiltersoperator1 ,
                                             string AV67Configuracion_tipocambiowwds_3_mondsc1 ,
                                             DateTime AV68Configuracion_tipocambiowwds_4_tipfech1 ,
                                             DateTime AV69Configuracion_tipocambiowwds_5_tipfech_to1 ,
                                             bool AV70Configuracion_tipocambiowwds_6_dynamicfiltersenabled2 ,
                                             string AV71Configuracion_tipocambiowwds_7_dynamicfiltersselector2 ,
                                             short AV72Configuracion_tipocambiowwds_8_dynamicfiltersoperator2 ,
                                             string AV73Configuracion_tipocambiowwds_9_mondsc2 ,
                                             DateTime AV74Configuracion_tipocambiowwds_10_tipfech2 ,
                                             DateTime AV75Configuracion_tipocambiowwds_11_tipfech_to2 ,
                                             bool AV76Configuracion_tipocambiowwds_12_dynamicfiltersenabled3 ,
                                             string AV77Configuracion_tipocambiowwds_13_dynamicfiltersselector3 ,
                                             short AV78Configuracion_tipocambiowwds_14_dynamicfiltersoperator3 ,
                                             string AV79Configuracion_tipocambiowwds_15_mondsc3 ,
                                             DateTime AV80Configuracion_tipocambiowwds_16_tipfech3 ,
                                             DateTime AV81Configuracion_tipocambiowwds_17_tipfech_to3 ,
                                             string AV83Configuracion_tipocambiowwds_19_tfmondsc_sel ,
                                             string AV82Configuracion_tipocambiowwds_18_tfmondsc ,
                                             DateTime AV84Configuracion_tipocambiowwds_20_tftipfech ,
                                             DateTime AV85Configuracion_tipocambiowwds_21_tftipfech_to ,
                                             decimal AV86Configuracion_tipocambiowwds_22_tftipcompra ,
                                             decimal AV87Configuracion_tipocambiowwds_23_tftipcompra_to ,
                                             decimal AV88Configuracion_tipocambiowwds_24_tftipventa ,
                                             decimal AV89Configuracion_tipocambiowwds_25_tftipventa_to ,
                                             string A1234MonDsc ,
                                             DateTime A308TipFech ,
                                             decimal A1907TipCompra ,
                                             decimal A1920TipVenta ,
                                             short AV13OrderedBy ,
                                             bool AV14OrderedDsc )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int5 = new short[29];
         Object[] GXv_Object6 = new Object[2];
         scmdbuf = "SELECT COUNT(*) FROM ([CTIPOCAMBIO] T1 INNER JOIN [CMONEDAS] T2 ON T2.[MonCod] = T1.[TipMonCod])";
         if ( ( StringUtil.StrCmp(AV65Configuracion_tipocambiowwds_1_dynamicfiltersselector1, "MONDSC") == 0 ) && ( AV66Configuracion_tipocambiowwds_2_dynamicfiltersoperator1 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV67Configuracion_tipocambiowwds_3_mondsc1)) ) )
         {
            AddWhere(sWhereString, "(T2.[MonDsc] like @lV67Configuracion_tipocambiowwds_3_mondsc1)");
         }
         else
         {
            GXv_int5[0] = 1;
         }
         if ( ( StringUtil.StrCmp(AV65Configuracion_tipocambiowwds_1_dynamicfiltersselector1, "MONDSC") == 0 ) && ( AV66Configuracion_tipocambiowwds_2_dynamicfiltersoperator1 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV67Configuracion_tipocambiowwds_3_mondsc1)) ) )
         {
            AddWhere(sWhereString, "(T2.[MonDsc] like '%' + @lV67Configuracion_tipocambiowwds_3_mondsc1)");
         }
         else
         {
            GXv_int5[1] = 1;
         }
         if ( ( StringUtil.StrCmp(AV65Configuracion_tipocambiowwds_1_dynamicfiltersselector1, "TIPFECH") == 0 ) && ( AV66Configuracion_tipocambiowwds_2_dynamicfiltersoperator1 == 0 ) && ( ! (DateTime.MinValue==AV68Configuracion_tipocambiowwds_4_tipfech1) ) )
         {
            AddWhere(sWhereString, "(T1.[TipFech] < @AV68Configuracion_tipocambiowwds_4_tipfech1)");
         }
         else
         {
            GXv_int5[2] = 1;
         }
         if ( ( StringUtil.StrCmp(AV65Configuracion_tipocambiowwds_1_dynamicfiltersselector1, "TIPFECH") == 0 ) && ( AV66Configuracion_tipocambiowwds_2_dynamicfiltersoperator1 == 1 ) && ( ! (DateTime.MinValue==AV68Configuracion_tipocambiowwds_4_tipfech1) ) )
         {
            AddWhere(sWhereString, "(T1.[TipFech] = @AV68Configuracion_tipocambiowwds_4_tipfech1)");
         }
         else
         {
            GXv_int5[3] = 1;
         }
         if ( ( StringUtil.StrCmp(AV65Configuracion_tipocambiowwds_1_dynamicfiltersselector1, "TIPFECH") == 0 ) && ( AV66Configuracion_tipocambiowwds_2_dynamicfiltersoperator1 == 2 ) && ( ! (DateTime.MinValue==AV68Configuracion_tipocambiowwds_4_tipfech1) ) )
         {
            AddWhere(sWhereString, "(T1.[TipFech] > @AV68Configuracion_tipocambiowwds_4_tipfech1)");
         }
         else
         {
            GXv_int5[4] = 1;
         }
         if ( ( StringUtil.StrCmp(AV65Configuracion_tipocambiowwds_1_dynamicfiltersselector1, "TIPFECH") == 0 ) && ( AV66Configuracion_tipocambiowwds_2_dynamicfiltersoperator1 == 3 ) && ( ! (DateTime.MinValue==AV68Configuracion_tipocambiowwds_4_tipfech1) ) )
         {
            AddWhere(sWhereString, "(T1.[TipFech] >= @AV68Configuracion_tipocambiowwds_4_tipfech1)");
         }
         else
         {
            GXv_int5[5] = 1;
         }
         if ( ( StringUtil.StrCmp(AV65Configuracion_tipocambiowwds_1_dynamicfiltersselector1, "TIPFECH") == 0 ) && ( AV66Configuracion_tipocambiowwds_2_dynamicfiltersoperator1 == 3 ) && ( ! (DateTime.MinValue==AV69Configuracion_tipocambiowwds_5_tipfech_to1) ) )
         {
            AddWhere(sWhereString, "(T1.[TipFech] <= @AV69Configuracion_tipocambiowwds_5_tipfech_to1)");
         }
         else
         {
            GXv_int5[6] = 1;
         }
         if ( AV70Configuracion_tipocambiowwds_6_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV71Configuracion_tipocambiowwds_7_dynamicfiltersselector2, "MONDSC") == 0 ) && ( AV72Configuracion_tipocambiowwds_8_dynamicfiltersoperator2 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV73Configuracion_tipocambiowwds_9_mondsc2)) ) )
         {
            AddWhere(sWhereString, "(T2.[MonDsc] like @lV73Configuracion_tipocambiowwds_9_mondsc2)");
         }
         else
         {
            GXv_int5[7] = 1;
         }
         if ( AV70Configuracion_tipocambiowwds_6_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV71Configuracion_tipocambiowwds_7_dynamicfiltersselector2, "MONDSC") == 0 ) && ( AV72Configuracion_tipocambiowwds_8_dynamicfiltersoperator2 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV73Configuracion_tipocambiowwds_9_mondsc2)) ) )
         {
            AddWhere(sWhereString, "(T2.[MonDsc] like '%' + @lV73Configuracion_tipocambiowwds_9_mondsc2)");
         }
         else
         {
            GXv_int5[8] = 1;
         }
         if ( AV70Configuracion_tipocambiowwds_6_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV71Configuracion_tipocambiowwds_7_dynamicfiltersselector2, "TIPFECH") == 0 ) && ( AV72Configuracion_tipocambiowwds_8_dynamicfiltersoperator2 == 0 ) && ( ! (DateTime.MinValue==AV74Configuracion_tipocambiowwds_10_tipfech2) ) )
         {
            AddWhere(sWhereString, "(T1.[TipFech] < @AV74Configuracion_tipocambiowwds_10_tipfech2)");
         }
         else
         {
            GXv_int5[9] = 1;
         }
         if ( AV70Configuracion_tipocambiowwds_6_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV71Configuracion_tipocambiowwds_7_dynamicfiltersselector2, "TIPFECH") == 0 ) && ( AV72Configuracion_tipocambiowwds_8_dynamicfiltersoperator2 == 1 ) && ( ! (DateTime.MinValue==AV74Configuracion_tipocambiowwds_10_tipfech2) ) )
         {
            AddWhere(sWhereString, "(T1.[TipFech] = @AV74Configuracion_tipocambiowwds_10_tipfech2)");
         }
         else
         {
            GXv_int5[10] = 1;
         }
         if ( AV70Configuracion_tipocambiowwds_6_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV71Configuracion_tipocambiowwds_7_dynamicfiltersselector2, "TIPFECH") == 0 ) && ( AV72Configuracion_tipocambiowwds_8_dynamicfiltersoperator2 == 2 ) && ( ! (DateTime.MinValue==AV74Configuracion_tipocambiowwds_10_tipfech2) ) )
         {
            AddWhere(sWhereString, "(T1.[TipFech] > @AV74Configuracion_tipocambiowwds_10_tipfech2)");
         }
         else
         {
            GXv_int5[11] = 1;
         }
         if ( AV70Configuracion_tipocambiowwds_6_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV71Configuracion_tipocambiowwds_7_dynamicfiltersselector2, "TIPFECH") == 0 ) && ( AV72Configuracion_tipocambiowwds_8_dynamicfiltersoperator2 == 3 ) && ( ! (DateTime.MinValue==AV74Configuracion_tipocambiowwds_10_tipfech2) ) )
         {
            AddWhere(sWhereString, "(T1.[TipFech] >= @AV74Configuracion_tipocambiowwds_10_tipfech2)");
         }
         else
         {
            GXv_int5[12] = 1;
         }
         if ( AV70Configuracion_tipocambiowwds_6_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV71Configuracion_tipocambiowwds_7_dynamicfiltersselector2, "TIPFECH") == 0 ) && ( AV72Configuracion_tipocambiowwds_8_dynamicfiltersoperator2 == 3 ) && ( ! (DateTime.MinValue==AV75Configuracion_tipocambiowwds_11_tipfech_to2) ) )
         {
            AddWhere(sWhereString, "(T1.[TipFech] <= @AV75Configuracion_tipocambiowwds_11_tipfech_to2)");
         }
         else
         {
            GXv_int5[13] = 1;
         }
         if ( AV76Configuracion_tipocambiowwds_12_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV77Configuracion_tipocambiowwds_13_dynamicfiltersselector3, "MONDSC") == 0 ) && ( AV78Configuracion_tipocambiowwds_14_dynamicfiltersoperator3 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV79Configuracion_tipocambiowwds_15_mondsc3)) ) )
         {
            AddWhere(sWhereString, "(T2.[MonDsc] like @lV79Configuracion_tipocambiowwds_15_mondsc3)");
         }
         else
         {
            GXv_int5[14] = 1;
         }
         if ( AV76Configuracion_tipocambiowwds_12_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV77Configuracion_tipocambiowwds_13_dynamicfiltersselector3, "MONDSC") == 0 ) && ( AV78Configuracion_tipocambiowwds_14_dynamicfiltersoperator3 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV79Configuracion_tipocambiowwds_15_mondsc3)) ) )
         {
            AddWhere(sWhereString, "(T2.[MonDsc] like '%' + @lV79Configuracion_tipocambiowwds_15_mondsc3)");
         }
         else
         {
            GXv_int5[15] = 1;
         }
         if ( AV76Configuracion_tipocambiowwds_12_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV77Configuracion_tipocambiowwds_13_dynamicfiltersselector3, "TIPFECH") == 0 ) && ( AV78Configuracion_tipocambiowwds_14_dynamicfiltersoperator3 == 0 ) && ( ! (DateTime.MinValue==AV80Configuracion_tipocambiowwds_16_tipfech3) ) )
         {
            AddWhere(sWhereString, "(T1.[TipFech] < @AV80Configuracion_tipocambiowwds_16_tipfech3)");
         }
         else
         {
            GXv_int5[16] = 1;
         }
         if ( AV76Configuracion_tipocambiowwds_12_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV77Configuracion_tipocambiowwds_13_dynamicfiltersselector3, "TIPFECH") == 0 ) && ( AV78Configuracion_tipocambiowwds_14_dynamicfiltersoperator3 == 1 ) && ( ! (DateTime.MinValue==AV80Configuracion_tipocambiowwds_16_tipfech3) ) )
         {
            AddWhere(sWhereString, "(T1.[TipFech] = @AV80Configuracion_tipocambiowwds_16_tipfech3)");
         }
         else
         {
            GXv_int5[17] = 1;
         }
         if ( AV76Configuracion_tipocambiowwds_12_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV77Configuracion_tipocambiowwds_13_dynamicfiltersselector3, "TIPFECH") == 0 ) && ( AV78Configuracion_tipocambiowwds_14_dynamicfiltersoperator3 == 2 ) && ( ! (DateTime.MinValue==AV80Configuracion_tipocambiowwds_16_tipfech3) ) )
         {
            AddWhere(sWhereString, "(T1.[TipFech] > @AV80Configuracion_tipocambiowwds_16_tipfech3)");
         }
         else
         {
            GXv_int5[18] = 1;
         }
         if ( AV76Configuracion_tipocambiowwds_12_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV77Configuracion_tipocambiowwds_13_dynamicfiltersselector3, "TIPFECH") == 0 ) && ( AV78Configuracion_tipocambiowwds_14_dynamicfiltersoperator3 == 3 ) && ( ! (DateTime.MinValue==AV80Configuracion_tipocambiowwds_16_tipfech3) ) )
         {
            AddWhere(sWhereString, "(T1.[TipFech] >= @AV80Configuracion_tipocambiowwds_16_tipfech3)");
         }
         else
         {
            GXv_int5[19] = 1;
         }
         if ( AV76Configuracion_tipocambiowwds_12_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV77Configuracion_tipocambiowwds_13_dynamicfiltersselector3, "TIPFECH") == 0 ) && ( AV78Configuracion_tipocambiowwds_14_dynamicfiltersoperator3 == 3 ) && ( ! (DateTime.MinValue==AV81Configuracion_tipocambiowwds_17_tipfech_to3) ) )
         {
            AddWhere(sWhereString, "(T1.[TipFech] <= @AV81Configuracion_tipocambiowwds_17_tipfech_to3)");
         }
         else
         {
            GXv_int5[20] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV83Configuracion_tipocambiowwds_19_tfmondsc_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV82Configuracion_tipocambiowwds_18_tfmondsc)) ) )
         {
            AddWhere(sWhereString, "(T2.[MonDsc] like @lV82Configuracion_tipocambiowwds_18_tfmondsc)");
         }
         else
         {
            GXv_int5[21] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV83Configuracion_tipocambiowwds_19_tfmondsc_sel)) )
         {
            AddWhere(sWhereString, "(T2.[MonDsc] = @AV83Configuracion_tipocambiowwds_19_tfmondsc_sel)");
         }
         else
         {
            GXv_int5[22] = 1;
         }
         if ( ! (DateTime.MinValue==AV84Configuracion_tipocambiowwds_20_tftipfech) )
         {
            AddWhere(sWhereString, "(T1.[TipFech] >= @AV84Configuracion_tipocambiowwds_20_tftipfech)");
         }
         else
         {
            GXv_int5[23] = 1;
         }
         if ( ! (DateTime.MinValue==AV85Configuracion_tipocambiowwds_21_tftipfech_to) )
         {
            AddWhere(sWhereString, "(T1.[TipFech] <= @AV85Configuracion_tipocambiowwds_21_tftipfech_to)");
         }
         else
         {
            GXv_int5[24] = 1;
         }
         if ( ! (Convert.ToDecimal(0)==AV86Configuracion_tipocambiowwds_22_tftipcompra) )
         {
            AddWhere(sWhereString, "(T1.[TipCompra] >= @AV86Configuracion_tipocambiowwds_22_tftipcompra)");
         }
         else
         {
            GXv_int5[25] = 1;
         }
         if ( ! (Convert.ToDecimal(0)==AV87Configuracion_tipocambiowwds_23_tftipcompra_to) )
         {
            AddWhere(sWhereString, "(T1.[TipCompra] <= @AV87Configuracion_tipocambiowwds_23_tftipcompra_to)");
         }
         else
         {
            GXv_int5[26] = 1;
         }
         if ( ! (Convert.ToDecimal(0)==AV88Configuracion_tipocambiowwds_24_tftipventa) )
         {
            AddWhere(sWhereString, "(T1.[TipVenta] >= @AV88Configuracion_tipocambiowwds_24_tftipventa)");
         }
         else
         {
            GXv_int5[27] = 1;
         }
         if ( ! (Convert.ToDecimal(0)==AV89Configuracion_tipocambiowwds_25_tftipventa_to) )
         {
            AddWhere(sWhereString, "(T1.[TipVenta] <= @AV89Configuracion_tipocambiowwds_25_tftipventa_to)");
         }
         else
         {
            GXv_int5[28] = 1;
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
         GXv_Object6[0] = scmdbuf;
         GXv_Object6[1] = GXv_int5;
         return GXv_Object6 ;
      }

      public override Object [] getDynamicStatement( int cursor ,
                                                     IGxContext context ,
                                                     Object [] dynConstraints )
      {
         switch ( cursor )
         {
               case 0 :
                     return conditional_H001W2(context, (string)dynConstraints[0] , (short)dynConstraints[1] , (string)dynConstraints[2] , (DateTime)dynConstraints[3] , (DateTime)dynConstraints[4] , (bool)dynConstraints[5] , (string)dynConstraints[6] , (short)dynConstraints[7] , (string)dynConstraints[8] , (DateTime)dynConstraints[9] , (DateTime)dynConstraints[10] , (bool)dynConstraints[11] , (string)dynConstraints[12] , (short)dynConstraints[13] , (string)dynConstraints[14] , (DateTime)dynConstraints[15] , (DateTime)dynConstraints[16] , (string)dynConstraints[17] , (string)dynConstraints[18] , (DateTime)dynConstraints[19] , (DateTime)dynConstraints[20] , (decimal)dynConstraints[21] , (decimal)dynConstraints[22] , (decimal)dynConstraints[23] , (decimal)dynConstraints[24] , (string)dynConstraints[25] , (DateTime)dynConstraints[26] , (decimal)dynConstraints[27] , (decimal)dynConstraints[28] , (short)dynConstraints[29] , (bool)dynConstraints[30] );
               case 1 :
                     return conditional_H001W3(context, (string)dynConstraints[0] , (short)dynConstraints[1] , (string)dynConstraints[2] , (DateTime)dynConstraints[3] , (DateTime)dynConstraints[4] , (bool)dynConstraints[5] , (string)dynConstraints[6] , (short)dynConstraints[7] , (string)dynConstraints[8] , (DateTime)dynConstraints[9] , (DateTime)dynConstraints[10] , (bool)dynConstraints[11] , (string)dynConstraints[12] , (short)dynConstraints[13] , (string)dynConstraints[14] , (DateTime)dynConstraints[15] , (DateTime)dynConstraints[16] , (string)dynConstraints[17] , (string)dynConstraints[18] , (DateTime)dynConstraints[19] , (DateTime)dynConstraints[20] , (decimal)dynConstraints[21] , (decimal)dynConstraints[22] , (decimal)dynConstraints[23] , (decimal)dynConstraints[24] , (string)dynConstraints[25] , (DateTime)dynConstraints[26] , (decimal)dynConstraints[27] , (decimal)dynConstraints[28] , (short)dynConstraints[29] , (bool)dynConstraints[30] );
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
          Object[] prmH001W2;
          prmH001W2 = new Object[] {
          new ParDef("@lV67Configuracion_tipocambiowwds_3_mondsc1",GXType.NChar,100,0) ,
          new ParDef("@lV67Configuracion_tipocambiowwds_3_mondsc1",GXType.NChar,100,0) ,
          new ParDef("@AV68Configuracion_tipocambiowwds_4_tipfech1",GXType.Date,8,0) ,
          new ParDef("@AV68Configuracion_tipocambiowwds_4_tipfech1",GXType.Date,8,0) ,
          new ParDef("@AV68Configuracion_tipocambiowwds_4_tipfech1",GXType.Date,8,0) ,
          new ParDef("@AV68Configuracion_tipocambiowwds_4_tipfech1",GXType.Date,8,0) ,
          new ParDef("@AV69Configuracion_tipocambiowwds_5_tipfech_to1",GXType.Date,8,0) ,
          new ParDef("@lV73Configuracion_tipocambiowwds_9_mondsc2",GXType.NChar,100,0) ,
          new ParDef("@lV73Configuracion_tipocambiowwds_9_mondsc2",GXType.NChar,100,0) ,
          new ParDef("@AV74Configuracion_tipocambiowwds_10_tipfech2",GXType.Date,8,0) ,
          new ParDef("@AV74Configuracion_tipocambiowwds_10_tipfech2",GXType.Date,8,0) ,
          new ParDef("@AV74Configuracion_tipocambiowwds_10_tipfech2",GXType.Date,8,0) ,
          new ParDef("@AV74Configuracion_tipocambiowwds_10_tipfech2",GXType.Date,8,0) ,
          new ParDef("@AV75Configuracion_tipocambiowwds_11_tipfech_to2",GXType.Date,8,0) ,
          new ParDef("@lV79Configuracion_tipocambiowwds_15_mondsc3",GXType.NChar,100,0) ,
          new ParDef("@lV79Configuracion_tipocambiowwds_15_mondsc3",GXType.NChar,100,0) ,
          new ParDef("@AV80Configuracion_tipocambiowwds_16_tipfech3",GXType.Date,8,0) ,
          new ParDef("@AV80Configuracion_tipocambiowwds_16_tipfech3",GXType.Date,8,0) ,
          new ParDef("@AV80Configuracion_tipocambiowwds_16_tipfech3",GXType.Date,8,0) ,
          new ParDef("@AV80Configuracion_tipocambiowwds_16_tipfech3",GXType.Date,8,0) ,
          new ParDef("@AV81Configuracion_tipocambiowwds_17_tipfech_to3",GXType.Date,8,0) ,
          new ParDef("@lV82Configuracion_tipocambiowwds_18_tfmondsc",GXType.NChar,100,0) ,
          new ParDef("@AV83Configuracion_tipocambiowwds_19_tfmondsc_sel",GXType.NChar,100,0) ,
          new ParDef("@AV84Configuracion_tipocambiowwds_20_tftipfech",GXType.Date,8,0) ,
          new ParDef("@AV85Configuracion_tipocambiowwds_21_tftipfech_to",GXType.Date,8,0) ,
          new ParDef("@AV86Configuracion_tipocambiowwds_22_tftipcompra",GXType.Decimal,15,5) ,
          new ParDef("@AV87Configuracion_tipocambiowwds_23_tftipcompra_to",GXType.Decimal,15,5) ,
          new ParDef("@AV88Configuracion_tipocambiowwds_24_tftipventa",GXType.Decimal,15,5) ,
          new ParDef("@AV89Configuracion_tipocambiowwds_25_tftipventa_to",GXType.Decimal,15,5) ,
          new ParDef("@GXPagingFrom2",GXType.Int32,9,0) ,
          new ParDef("@GXPagingTo2",GXType.Int32,9,0) ,
          new ParDef("@GXPagingTo2",GXType.Int32,9,0)
          };
          Object[] prmH001W3;
          prmH001W3 = new Object[] {
          new ParDef("@lV67Configuracion_tipocambiowwds_3_mondsc1",GXType.NChar,100,0) ,
          new ParDef("@lV67Configuracion_tipocambiowwds_3_mondsc1",GXType.NChar,100,0) ,
          new ParDef("@AV68Configuracion_tipocambiowwds_4_tipfech1",GXType.Date,8,0) ,
          new ParDef("@AV68Configuracion_tipocambiowwds_4_tipfech1",GXType.Date,8,0) ,
          new ParDef("@AV68Configuracion_tipocambiowwds_4_tipfech1",GXType.Date,8,0) ,
          new ParDef("@AV68Configuracion_tipocambiowwds_4_tipfech1",GXType.Date,8,0) ,
          new ParDef("@AV69Configuracion_tipocambiowwds_5_tipfech_to1",GXType.Date,8,0) ,
          new ParDef("@lV73Configuracion_tipocambiowwds_9_mondsc2",GXType.NChar,100,0) ,
          new ParDef("@lV73Configuracion_tipocambiowwds_9_mondsc2",GXType.NChar,100,0) ,
          new ParDef("@AV74Configuracion_tipocambiowwds_10_tipfech2",GXType.Date,8,0) ,
          new ParDef("@AV74Configuracion_tipocambiowwds_10_tipfech2",GXType.Date,8,0) ,
          new ParDef("@AV74Configuracion_tipocambiowwds_10_tipfech2",GXType.Date,8,0) ,
          new ParDef("@AV74Configuracion_tipocambiowwds_10_tipfech2",GXType.Date,8,0) ,
          new ParDef("@AV75Configuracion_tipocambiowwds_11_tipfech_to2",GXType.Date,8,0) ,
          new ParDef("@lV79Configuracion_tipocambiowwds_15_mondsc3",GXType.NChar,100,0) ,
          new ParDef("@lV79Configuracion_tipocambiowwds_15_mondsc3",GXType.NChar,100,0) ,
          new ParDef("@AV80Configuracion_tipocambiowwds_16_tipfech3",GXType.Date,8,0) ,
          new ParDef("@AV80Configuracion_tipocambiowwds_16_tipfech3",GXType.Date,8,0) ,
          new ParDef("@AV80Configuracion_tipocambiowwds_16_tipfech3",GXType.Date,8,0) ,
          new ParDef("@AV80Configuracion_tipocambiowwds_16_tipfech3",GXType.Date,8,0) ,
          new ParDef("@AV81Configuracion_tipocambiowwds_17_tipfech_to3",GXType.Date,8,0) ,
          new ParDef("@lV82Configuracion_tipocambiowwds_18_tfmondsc",GXType.NChar,100,0) ,
          new ParDef("@AV83Configuracion_tipocambiowwds_19_tfmondsc_sel",GXType.NChar,100,0) ,
          new ParDef("@AV84Configuracion_tipocambiowwds_20_tftipfech",GXType.Date,8,0) ,
          new ParDef("@AV85Configuracion_tipocambiowwds_21_tftipfech_to",GXType.Date,8,0) ,
          new ParDef("@AV86Configuracion_tipocambiowwds_22_tftipcompra",GXType.Decimal,15,5) ,
          new ParDef("@AV87Configuracion_tipocambiowwds_23_tftipcompra_to",GXType.Decimal,15,5) ,
          new ParDef("@AV88Configuracion_tipocambiowwds_24_tftipventa",GXType.Decimal,15,5) ,
          new ParDef("@AV89Configuracion_tipocambiowwds_25_tftipventa_to",GXType.Decimal,15,5)
          };
          def= new CursorDef[] {
              new CursorDef("H001W2", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH001W2,11, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("H001W3", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH001W3,1, GxCacheFrequency.OFF ,true,false )
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
                ((decimal[]) buf[1])[0] = rslt.getDecimal(2);
                ((DateTime[]) buf[2])[0] = rslt.getGXDate(3);
                ((string[]) buf[3])[0] = rslt.getString(4, 100);
                ((bool[]) buf[4])[0] = rslt.wasNull(4);
                ((int[]) buf[5])[0] = rslt.getInt(5);
                return;
             case 1 :
                ((long[]) buf[0])[0] = rslt.getLong(1);
                return;
       }
    }

 }

}
