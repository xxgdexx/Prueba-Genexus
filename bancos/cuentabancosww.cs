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
   public class cuentabancosww : GXDataArea
   {
      public cuentabancosww( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDataStore2 = context.GetDataStore("DataStore2");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusTheme");
      }

      public cuentabancosww( IGxContext context )
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
         dynavMoncod1 = new GXCombobox();
         cmbavDynamicfiltersselector2 = new GXCombobox();
         cmbavDynamicfiltersoperator2 = new GXCombobox();
         dynavMoncod2 = new GXCombobox();
         cmbavDynamicfiltersselector3 = new GXCombobox();
         cmbavDynamicfiltersoperator3 = new GXCombobox();
         dynavMoncod3 = new GXCombobox();
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
            else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxCallCrl"+"_"+"vMONCOD1") == 0 )
            {
               setAjaxCallMode();
               if ( ! IsValidAjaxCall( true) )
               {
                  GxWebError = 1;
                  return  ;
               }
               GXDLVvMONCOD11Z2( ) ;
               return  ;
            }
            else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxCallCrl"+"_"+"vMONCOD2") == 0 )
            {
               setAjaxCallMode();
               if ( ! IsValidAjaxCall( true) )
               {
                  GxWebError = 1;
                  return  ;
               }
               GXDLVvMONCOD21Z2( ) ;
               return  ;
            }
            else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxCallCrl"+"_"+"vMONCOD3") == 0 )
            {
               setAjaxCallMode();
               if ( ! IsValidAjaxCall( true) )
               {
                  GxWebError = 1;
                  return  ;
               }
               GXDLVvMONCOD31Z2( ) ;
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
               AV60BanDsc1 = GetPar( "BanDsc1");
               dynavMoncod1.FromJSonString( GetNextPar( ));
               AV61MonCod1 = (int)(NumberUtil.Val( GetPar( "MonCod1"), "."));
               cmbavDynamicfiltersselector2.FromJSonString( GetNextPar( ));
               AV20DynamicFiltersSelector2 = GetPar( "DynamicFiltersSelector2");
               cmbavDynamicfiltersoperator2.FromJSonString( GetNextPar( ));
               AV21DynamicFiltersOperator2 = (short)(NumberUtil.Val( GetPar( "DynamicFiltersOperator2"), "."));
               AV62BanDsc2 = GetPar( "BanDsc2");
               dynavMoncod2.FromJSonString( GetNextPar( ));
               AV63MonCod2 = (int)(NumberUtil.Val( GetPar( "MonCod2"), "."));
               cmbavDynamicfiltersselector3.FromJSonString( GetNextPar( ));
               AV25DynamicFiltersSelector3 = GetPar( "DynamicFiltersSelector3");
               cmbavDynamicfiltersoperator3.FromJSonString( GetNextPar( ));
               AV26DynamicFiltersOperator3 = (short)(NumberUtil.Val( GetPar( "DynamicFiltersOperator3"), "."));
               AV64BanDsc3 = GetPar( "BanDsc3");
               dynavMoncod3.FromJSonString( GetNextPar( ));
               AV65MonCod3 = (int)(NumberUtil.Val( GetPar( "MonCod3"), "."));
               AV74Pgmname = GetPar( "Pgmname");
               AV19DynamicFiltersEnabled2 = StringUtil.StrToBool( GetPar( "DynamicFiltersEnabled2"));
               AV24DynamicFiltersEnabled3 = StringUtil.StrToBool( GetPar( "DynamicFiltersEnabled3"));
               AV66TFBanDsc = GetPar( "TFBanDsc");
               AV67TFBanDsc_Sel = GetPar( "TFBanDsc_Sel");
               AV36TFCBCod = GetPar( "TFCBCod");
               AV37TFCBCod_Sel = GetPar( "TFCBCod_Sel");
               AV68TFMonDsc = GetPar( "TFMonDsc");
               AV69TFMonDsc_Sel = GetPar( "TFMonDsc_Sel");
               AV42TFCBSts = (short)(NumberUtil.Val( GetPar( "TFCBSts"), "."));
               AV43TFCBSts_To = (short)(NumberUtil.Val( GetPar( "TFCBSts_To"), "."));
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
               gxgrGrid_refresh( subGrid_Rows, AV15DynamicFiltersSelector1, AV16DynamicFiltersOperator1, AV60BanDsc1, AV61MonCod1, AV20DynamicFiltersSelector2, AV21DynamicFiltersOperator2, AV62BanDsc2, AV63MonCod2, AV25DynamicFiltersSelector3, AV26DynamicFiltersOperator3, AV64BanDsc3, AV65MonCod3, AV74Pgmname, AV19DynamicFiltersEnabled2, AV24DynamicFiltersEnabled3, AV66TFBanDsc, AV67TFBanDsc_Sel, AV36TFCBCod, AV37TFCBCod_Sel, AV68TFMonDsc, AV69TFMonDsc_Sel, AV42TFCBSts, AV43TFCBSts_To, AV13OrderedBy, AV14OrderedDsc, AV10GridState, AV30DynamicFiltersIgnoreFirst, AV29DynamicFiltersRemoving) ;
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
         PA1Z2( ) ;
         gxajaxcallmode = (short)((isAjaxCallMode( ) ? 1 : 0));
         if ( ( gxajaxcallmode == 0 ) && ( GxWebError == 0 ) )
         {
            START1Z2( ) ;
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
         context.AddJavascriptSource("gxcfg.js", "?202281810295769", false, true);
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
         context.WriteHtmlTextNl( "<form id=\"MAINFORM\" autocomplete=\"off\" name=\"MAINFORM\" method=\"post\" tabindex=-1  class=\"form-horizontal Form\" data-gx-class=\"form-horizontal Form\" novalidate action=\""+formatLink("bancos.cuentabancosww.aspx") +"\">") ;
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
         GxWebStd.gx_hidden_field( context, "gxhash_vPGMNAME", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( AV74Pgmname, "")), context));
         GXKey = Crypto.GetSiteKey( );
      }

      protected void SendCloseFormHiddens( )
      {
         /* Send hidden variables. */
         GxWebStd.gx_hidden_field( context, "GXH_vDYNAMICFILTERSSELECTOR1", AV15DynamicFiltersSelector1);
         GxWebStd.gx_hidden_field( context, "GXH_vDYNAMICFILTERSOPERATOR1", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV16DynamicFiltersOperator1), 4, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "GXH_vBANDSC1", StringUtil.RTrim( AV60BanDsc1));
         GxWebStd.gx_hidden_field( context, "GXH_vMONCOD1", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV61MonCod1), 6, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "GXH_vDYNAMICFILTERSSELECTOR2", AV20DynamicFiltersSelector2);
         GxWebStd.gx_hidden_field( context, "GXH_vDYNAMICFILTERSOPERATOR2", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV21DynamicFiltersOperator2), 4, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "GXH_vBANDSC2", StringUtil.RTrim( AV62BanDsc2));
         GxWebStd.gx_hidden_field( context, "GXH_vMONCOD2", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV63MonCod2), 6, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "GXH_vDYNAMICFILTERSSELECTOR3", AV25DynamicFiltersSelector3);
         GxWebStd.gx_hidden_field( context, "GXH_vDYNAMICFILTERSOPERATOR3", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV26DynamicFiltersOperator3), 4, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "GXH_vBANDSC3", StringUtil.RTrim( AV64BanDsc3));
         GxWebStd.gx_hidden_field( context, "GXH_vMONCOD3", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV65MonCod3), 6, 0, ".", "")));
         /* Send saved values. */
         send_integrity_footer_hashes( ) ;
         GxWebStd.gx_hidden_field( context, "nRC_GXsfl_110", StringUtil.LTrim( StringUtil.NToC( (decimal)(nRC_GXsfl_110), 8, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "vGRIDCURRENTPAGE", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV54GridCurrentPage), 10, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "vGRIDPAGECOUNT", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV55GridPageCount), 10, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "vGRIDAPPLIEDFILTERS", AV56GridAppliedFilters);
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "vAGEXPORTDATA", AV58AGExportData);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt("vAGEXPORTDATA", AV58AGExportData);
         }
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "vDDO_TITLESETTINGSICONS", AV52DDO_TitleSettingsIcons);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt("vDDO_TITLESETTINGSICONS", AV52DDO_TitleSettingsIcons);
         }
         GxWebStd.gx_hidden_field( context, "vPGMNAME", StringUtil.RTrim( AV74Pgmname));
         GxWebStd.gx_hidden_field( context, "gxhash_vPGMNAME", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( AV74Pgmname, "")), context));
         GxWebStd.gx_boolean_hidden_field( context, "vDYNAMICFILTERSENABLED2", AV19DynamicFiltersEnabled2);
         GxWebStd.gx_boolean_hidden_field( context, "vDYNAMICFILTERSENABLED3", AV24DynamicFiltersEnabled3);
         GxWebStd.gx_hidden_field( context, "vTFBANDSC", StringUtil.RTrim( AV66TFBanDsc));
         GxWebStd.gx_hidden_field( context, "vTFBANDSC_SEL", StringUtil.RTrim( AV67TFBanDsc_Sel));
         GxWebStd.gx_hidden_field( context, "vTFCBCOD", StringUtil.RTrim( AV36TFCBCod));
         GxWebStd.gx_hidden_field( context, "vTFCBCOD_SEL", StringUtil.RTrim( AV37TFCBCod_Sel));
         GxWebStd.gx_hidden_field( context, "vTFMONDSC", StringUtil.RTrim( AV68TFMonDsc));
         GxWebStd.gx_hidden_field( context, "vTFMONDSC_SEL", StringUtil.RTrim( AV69TFMonDsc_Sel));
         GxWebStd.gx_hidden_field( context, "vTFCBSTS", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV42TFCBSts), 1, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "vTFCBSTS_TO", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV43TFCBSts_To), 1, 0, ".", "")));
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
            WE1Z2( ) ;
            context.WriteHtmlText( "</div>") ;
         }
      }

      public override void DispatchEvents( )
      {
         EVT1Z2( ) ;
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
         return formatLink("bancos.cuentabancosww.aspx")  ;
      }

      public override string GetPgmname( )
      {
         return "Bancos.CuentaBancosWW" ;
      }

      public override string GetPgmdesc( )
      {
         return " Cuenta Bancos" ;
      }

      protected void WB1Z0( )
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
            GxWebStd.gx_button_ctrl( context, bttBtninsert_Internalname, "gx.evt.setGridEvt("+StringUtil.Str( (decimal)(110), 3, 0)+","+"null"+");", "Agregar", bttBtninsert_Jsonclick, 5, "Agregar", "", StyleString, ClassString, 1, 1, "standard", "'"+""+"'"+",false,"+"'"+"E\\'DOINSERT\\'."+"'", TempTags, "", context.GetButtonType( ), "HLP_Bancos\\CuentaBancosWW.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "left", "top", "", "", "div");
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 21,'',false,'',0)\"";
            ClassString = "ColumnsSelector";
            StyleString = "";
            GxWebStd.gx_button_ctrl( context, bttBtnagexport_Internalname, "gx.evt.setGridEvt("+StringUtil.Str( (decimal)(110), 3, 0)+","+"null"+");", "Reportes", bttBtnagexport_Jsonclick, 0, "Reportes", "", StyleString, ClassString, 1, 0, "standard", "'"+""+"'"+",false,"+"'"+""+"'", TempTags, "", context.GetButtonType( ), "HLP_Bancos\\CuentaBancosWW.htm");
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
            wb_table1_25_1Z2( true) ;
         }
         else
         {
            wb_table1_25_1Z2( false) ;
         }
         return  ;
      }

      protected void wb_table1_25_1Z2e( bool wbgen )
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
               context.SendWebValue( "Banco") ;
               context.WriteHtmlTextNl( "</th>") ;
               context.WriteHtmlText( "<th align=\""+"left"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+""+""+"\" "+">") ;
               context.SendWebValue( "N° de Cuenta") ;
               context.WriteHtmlTextNl( "</th>") ;
               context.WriteHtmlText( "<th align=\""+"left"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+""+""+"\" "+">") ;
               context.SendWebValue( "Moneda") ;
               context.WriteHtmlTextNl( "</th>") ;
               context.WriteHtmlText( "<th align=\""+"right"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+""+""+"\" "+">") ;
               context.SendWebValue( "Estado") ;
               context.WriteHtmlTextNl( "</th>") ;
               context.WriteHtmlText( "<th align=\""+"right"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+"display:none;"+""+"\" "+">") ;
               context.SendWebValue( "Codigo Banco") ;
               context.WriteHtmlTextNl( "</th>") ;
               context.WriteHtmlText( "<th align=\""+"right"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+"display:none;"+""+"\" "+">") ;
               context.SendWebValue( "Codigo Moneda") ;
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
               GridColumn.AddObjectProperty("Value", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV57GridActions), 4, 0, ".", "")));
               GridContainer.AddColumnProperties(GridColumn);
               GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
               GridColumn.AddObjectProperty("Value", StringUtil.RTrim( A482BanDsc));
               GridColumn.AddObjectProperty("Link", StringUtil.RTrim( edtBanDsc_Link));
               GridContainer.AddColumnProperties(GridColumn);
               GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
               GridColumn.AddObjectProperty("Value", StringUtil.RTrim( A377CBCod));
               GridContainer.AddColumnProperties(GridColumn);
               GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
               GridColumn.AddObjectProperty("Value", StringUtil.RTrim( A1234MonDsc));
               GridColumn.AddObjectProperty("Link", StringUtil.RTrim( edtMonDsc_Link));
               GridContainer.AddColumnProperties(GridColumn);
               GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
               GridColumn.AddObjectProperty("Value", StringUtil.LTrim( StringUtil.NToC( (decimal)(A504CBSts), 1, 0, ".", "")));
               GridColumn.AddObjectProperty("Link", StringUtil.RTrim( edtCBSts_Link));
               GridContainer.AddColumnProperties(GridColumn);
               GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
               GridColumn.AddObjectProperty("Value", StringUtil.LTrim( StringUtil.NToC( (decimal)(A372BanCod), 6, 0, ".", "")));
               GridContainer.AddColumnProperties(GridColumn);
               GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
               GridColumn.AddObjectProperty("Value", StringUtil.LTrim( StringUtil.NToC( (decimal)(A180MonCod), 6, 0, ".", "")));
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
            ucGridpaginationbar.SetProperty("CurrentPage", AV54GridCurrentPage);
            ucGridpaginationbar.SetProperty("PageCount", AV55GridPageCount);
            ucGridpaginationbar.SetProperty("AppliedFilters", AV56GridAppliedFilters);
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
            ucDdo_agexport.SetProperty("DropDownOptionsData", AV58AGExportData);
            ucDdo_agexport.Render(context, "dvelop.gxbootstrap.ddoregular", Ddo_agexport_Internalname, "DDO_AGEXPORTContainer");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblJsdynamicfilters_Internalname, lblJsdynamicfilters_Caption, "", "", lblJsdynamicfilters_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "", 0, "", 1, 1, 0, 1, "HLP_Bancos\\CuentaBancosWW.htm");
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
            ucDdo_grid.SetProperty("DropDownOptionsTitleSettingsIcons", AV52DDO_TitleSettingsIcons);
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

      protected void START1Z2( )
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
            Form.Meta.addItem("description", " Cuenta Bancos", 0) ;
         }
         context.wjLoc = "";
         context.nUserReturn = 0;
         context.wbHandled = 0;
         if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
         {
         }
         wbErr = false;
         STRUP1Z0( ) ;
      }

      protected void WS1Z2( )
      {
         START1Z2( ) ;
         EVT1Z2( ) ;
      }

      protected void EVT1Z2( )
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
                              E111Z2 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "GRIDPAGINATIONBAR.CHANGEROWSPERPAGE") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              E121Z2 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "DDO_AGEXPORT.ONOPTIONCLICKED") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              E131Z2 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "DDO_GRID.ONOPTIONCLICKED") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              E141Z2 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "'REMOVEDYNAMICFILTERS1'") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              /* Execute user event: 'RemoveDynamicFilters1' */
                              E151Z2 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "'REMOVEDYNAMICFILTERS2'") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              /* Execute user event: 'RemoveDynamicFilters2' */
                              E161Z2 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "'REMOVEDYNAMICFILTERS3'") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              /* Execute user event: 'RemoveDynamicFilters3' */
                              E171Z2 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "'DOINSERT'") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              /* Execute user event: 'DoInsert' */
                              E181Z2 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "'ADDDYNAMICFILTERS1'") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              /* Execute user event: 'AddDynamicFilters1' */
                              E191Z2 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "VDYNAMICFILTERSSELECTOR1.CLICK") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              E201Z2 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "'ADDDYNAMICFILTERS2'") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              /* Execute user event: 'AddDynamicFilters2' */
                              E211Z2 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "VDYNAMICFILTERSSELECTOR2.CLICK") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              E221Z2 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "VDYNAMICFILTERSSELECTOR3.CLICK") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              E231Z2 ();
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
                              AV57GridActions = (short)(NumberUtil.Val( cgiGet( cmbavGridactions_Internalname), "."));
                              AssignAttri("", false, cmbavGridactions_Internalname, StringUtil.LTrimStr( (decimal)(AV57GridActions), 4, 0));
                              A482BanDsc = cgiGet( edtBanDsc_Internalname);
                              A377CBCod = cgiGet( edtCBCod_Internalname);
                              A1234MonDsc = cgiGet( edtMonDsc_Internalname);
                              A504CBSts = (short)(context.localUtil.CToN( cgiGet( edtCBSts_Internalname), ".", ","));
                              A372BanCod = (int)(context.localUtil.CToN( cgiGet( edtBanCod_Internalname), ".", ","));
                              A180MonCod = (int)(context.localUtil.CToN( cgiGet( edtMonCod_Internalname), ".", ","));
                              sEvtType = StringUtil.Right( sEvt, 1);
                              if ( StringUtil.StrCmp(sEvtType, ".") == 0 )
                              {
                                 sEvt = StringUtil.Left( sEvt, (short)(StringUtil.Len( sEvt)-1));
                                 if ( StringUtil.StrCmp(sEvt, "START") == 0 )
                                 {
                                    context.wbHandled = 1;
                                    dynload_actions( ) ;
                                    /* Execute user event: Start */
                                    E241Z2 ();
                                 }
                                 else if ( StringUtil.StrCmp(sEvt, "REFRESH") == 0 )
                                 {
                                    context.wbHandled = 1;
                                    dynload_actions( ) ;
                                    /* Execute user event: Refresh */
                                    E251Z2 ();
                                 }
                                 else if ( StringUtil.StrCmp(sEvt, "GRID.LOAD") == 0 )
                                 {
                                    context.wbHandled = 1;
                                    dynload_actions( ) ;
                                    E261Z2 ();
                                 }
                                 else if ( StringUtil.StrCmp(sEvt, "VGRIDACTIONS.CLICK") == 0 )
                                 {
                                    context.wbHandled = 1;
                                    dynload_actions( ) ;
                                    E271Z2 ();
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
                                       /* Set Refresh If Bandsc1 Changed */
                                       if ( StringUtil.StrCmp(cgiGet( "GXH_vBANDSC1"), AV60BanDsc1) != 0 )
                                       {
                                          Rfr0gs = true;
                                       }
                                       /* Set Refresh If Moncod1 Changed */
                                       if ( ( context.localUtil.CToN( cgiGet( "GXH_vMONCOD1"), ".", ",") != Convert.ToDecimal( AV61MonCod1 )) )
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
                                       /* Set Refresh If Bandsc2 Changed */
                                       if ( StringUtil.StrCmp(cgiGet( "GXH_vBANDSC2"), AV62BanDsc2) != 0 )
                                       {
                                          Rfr0gs = true;
                                       }
                                       /* Set Refresh If Moncod2 Changed */
                                       if ( ( context.localUtil.CToN( cgiGet( "GXH_vMONCOD2"), ".", ",") != Convert.ToDecimal( AV63MonCod2 )) )
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
                                       /* Set Refresh If Bandsc3 Changed */
                                       if ( StringUtil.StrCmp(cgiGet( "GXH_vBANDSC3"), AV64BanDsc3) != 0 )
                                       {
                                          Rfr0gs = true;
                                       }
                                       /* Set Refresh If Moncod3 Changed */
                                       if ( ( context.localUtil.CToN( cgiGet( "GXH_vMONCOD3"), ".", ",") != Convert.ToDecimal( AV65MonCod3 )) )
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

      protected void WE1Z2( )
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

      protected void PA1Z2( )
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

      protected void GXDLVvMONCOD11Z2( )
      {
         if ( ! context.isAjaxRequest( ) )
         {
            context.GX_webresponse.AppendHeader("Cache-Control", "no-store");
         }
         AddString( "[[") ;
         GXDLVvMONCOD1_data1Z2( ) ;
         gxdynajaxindex = 1;
         while ( gxdynajaxindex <= gxdynajaxctrlcodr.Count )
         {
            AddString( gxwrpcisep+"{\"c\":\""+GXUtil.EncodeJSConstant( ((string)gxdynajaxctrlcodr.Item(gxdynajaxindex)))+"\",\"d\":\""+GXUtil.EncodeJSConstant( ((string)gxdynajaxctrldescr.Item(gxdynajaxindex)))+"\"}") ;
            gxdynajaxindex = (int)(gxdynajaxindex+1);
            gxwrpcisep = ",";
         }
         AddString( "]") ;
         if ( gxdynajaxctrlcodr.Count == 0 )
         {
            AddString( ",101") ;
         }
         AddString( "]") ;
      }

      protected void GXVvMONCOD1_html1Z2( )
      {
         int gxdynajaxvalue;
         GXDLVvMONCOD1_data1Z2( ) ;
         gxdynajaxindex = 1;
         if ( ! ( gxdyncontrolsrefreshing && context.isAjaxRequest( ) ) )
         {
            dynavMoncod1.removeAllItems();
         }
         while ( gxdynajaxindex <= gxdynajaxctrlcodr.Count )
         {
            gxdynajaxvalue = (int)(NumberUtil.Val( ((string)gxdynajaxctrlcodr.Item(gxdynajaxindex)), "."));
            dynavMoncod1.addItem(StringUtil.Trim( StringUtil.Str( (decimal)(gxdynajaxvalue), 6, 0)), ((string)gxdynajaxctrldescr.Item(gxdynajaxindex)), 0);
            gxdynajaxindex = (int)(gxdynajaxindex+1);
         }
      }

      protected void GXDLVvMONCOD1_data1Z2( )
      {
         gxdynajaxctrlcodr.Clear();
         gxdynajaxctrldescr.Clear();
         gxdynajaxctrlcodr.Add(StringUtil.Str( (decimal)(0), 1, 0));
         gxdynajaxctrldescr.Add("(Ninguno)");
         /* Using cursor H001Z2 */
         pr_default.execute(0);
         while ( (pr_default.getStatus(0) != 101) )
         {
            gxdynajaxctrlcodr.Add(StringUtil.LTrim( StringUtil.NToC( (decimal)(H001Z2_A180MonCod[0]), 6, 0, ".", "")));
            gxdynajaxctrldescr.Add(StringUtil.RTrim( H001Z2_A1234MonDsc[0]));
            pr_default.readNext(0);
         }
         pr_default.close(0);
      }

      protected void GXDLVvMONCOD21Z2( )
      {
         if ( ! context.isAjaxRequest( ) )
         {
            context.GX_webresponse.AppendHeader("Cache-Control", "no-store");
         }
         AddString( "[[") ;
         GXDLVvMONCOD2_data1Z2( ) ;
         gxdynajaxindex = 1;
         while ( gxdynajaxindex <= gxdynajaxctrlcodr.Count )
         {
            AddString( gxwrpcisep+"{\"c\":\""+GXUtil.EncodeJSConstant( ((string)gxdynajaxctrlcodr.Item(gxdynajaxindex)))+"\",\"d\":\""+GXUtil.EncodeJSConstant( ((string)gxdynajaxctrldescr.Item(gxdynajaxindex)))+"\"}") ;
            gxdynajaxindex = (int)(gxdynajaxindex+1);
            gxwrpcisep = ",";
         }
         AddString( "]") ;
         if ( gxdynajaxctrlcodr.Count == 0 )
         {
            AddString( ",101") ;
         }
         AddString( "]") ;
      }

      protected void GXVvMONCOD2_html1Z2( )
      {
         int gxdynajaxvalue;
         GXDLVvMONCOD2_data1Z2( ) ;
         gxdynajaxindex = 1;
         if ( ! ( gxdyncontrolsrefreshing && context.isAjaxRequest( ) ) )
         {
            dynavMoncod2.removeAllItems();
         }
         while ( gxdynajaxindex <= gxdynajaxctrlcodr.Count )
         {
            gxdynajaxvalue = (int)(NumberUtil.Val( ((string)gxdynajaxctrlcodr.Item(gxdynajaxindex)), "."));
            dynavMoncod2.addItem(StringUtil.Trim( StringUtil.Str( (decimal)(gxdynajaxvalue), 6, 0)), ((string)gxdynajaxctrldescr.Item(gxdynajaxindex)), 0);
            gxdynajaxindex = (int)(gxdynajaxindex+1);
         }
      }

      protected void GXDLVvMONCOD2_data1Z2( )
      {
         gxdynajaxctrlcodr.Clear();
         gxdynajaxctrldescr.Clear();
         gxdynajaxctrlcodr.Add(StringUtil.Str( (decimal)(0), 1, 0));
         gxdynajaxctrldescr.Add("(Ninguno)");
         /* Using cursor H001Z3 */
         pr_default.execute(1);
         while ( (pr_default.getStatus(1) != 101) )
         {
            gxdynajaxctrlcodr.Add(StringUtil.LTrim( StringUtil.NToC( (decimal)(H001Z3_A180MonCod[0]), 6, 0, ".", "")));
            gxdynajaxctrldescr.Add(StringUtil.RTrim( H001Z3_A1234MonDsc[0]));
            pr_default.readNext(1);
         }
         pr_default.close(1);
      }

      protected void GXDLVvMONCOD31Z2( )
      {
         if ( ! context.isAjaxRequest( ) )
         {
            context.GX_webresponse.AppendHeader("Cache-Control", "no-store");
         }
         AddString( "[[") ;
         GXDLVvMONCOD3_data1Z2( ) ;
         gxdynajaxindex = 1;
         while ( gxdynajaxindex <= gxdynajaxctrlcodr.Count )
         {
            AddString( gxwrpcisep+"{\"c\":\""+GXUtil.EncodeJSConstant( ((string)gxdynajaxctrlcodr.Item(gxdynajaxindex)))+"\",\"d\":\""+GXUtil.EncodeJSConstant( ((string)gxdynajaxctrldescr.Item(gxdynajaxindex)))+"\"}") ;
            gxdynajaxindex = (int)(gxdynajaxindex+1);
            gxwrpcisep = ",";
         }
         AddString( "]") ;
         if ( gxdynajaxctrlcodr.Count == 0 )
         {
            AddString( ",101") ;
         }
         AddString( "]") ;
      }

      protected void GXVvMONCOD3_html1Z2( )
      {
         int gxdynajaxvalue;
         GXDLVvMONCOD3_data1Z2( ) ;
         gxdynajaxindex = 1;
         if ( ! ( gxdyncontrolsrefreshing && context.isAjaxRequest( ) ) )
         {
            dynavMoncod3.removeAllItems();
         }
         while ( gxdynajaxindex <= gxdynajaxctrlcodr.Count )
         {
            gxdynajaxvalue = (int)(NumberUtil.Val( ((string)gxdynajaxctrlcodr.Item(gxdynajaxindex)), "."));
            dynavMoncod3.addItem(StringUtil.Trim( StringUtil.Str( (decimal)(gxdynajaxvalue), 6, 0)), ((string)gxdynajaxctrldescr.Item(gxdynajaxindex)), 0);
            gxdynajaxindex = (int)(gxdynajaxindex+1);
         }
      }

      protected void GXDLVvMONCOD3_data1Z2( )
      {
         gxdynajaxctrlcodr.Clear();
         gxdynajaxctrldescr.Clear();
         gxdynajaxctrlcodr.Add(StringUtil.Str( (decimal)(0), 1, 0));
         gxdynajaxctrldescr.Add("(Ninguno)");
         /* Using cursor H001Z4 */
         pr_default.execute(2);
         while ( (pr_default.getStatus(2) != 101) )
         {
            gxdynajaxctrlcodr.Add(StringUtil.LTrim( StringUtil.NToC( (decimal)(H001Z4_A180MonCod[0]), 6, 0, ".", "")));
            gxdynajaxctrldescr.Add(StringUtil.RTrim( H001Z4_A1234MonDsc[0]));
            pr_default.readNext(2);
         }
         pr_default.close(2);
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
                                       string AV60BanDsc1 ,
                                       int AV61MonCod1 ,
                                       string AV20DynamicFiltersSelector2 ,
                                       short AV21DynamicFiltersOperator2 ,
                                       string AV62BanDsc2 ,
                                       int AV63MonCod2 ,
                                       string AV25DynamicFiltersSelector3 ,
                                       short AV26DynamicFiltersOperator3 ,
                                       string AV64BanDsc3 ,
                                       int AV65MonCod3 ,
                                       string AV74Pgmname ,
                                       bool AV19DynamicFiltersEnabled2 ,
                                       bool AV24DynamicFiltersEnabled3 ,
                                       string AV66TFBanDsc ,
                                       string AV67TFBanDsc_Sel ,
                                       string AV36TFCBCod ,
                                       string AV37TFCBCod_Sel ,
                                       string AV68TFMonDsc ,
                                       string AV69TFMonDsc_Sel ,
                                       short AV42TFCBSts ,
                                       short AV43TFCBSts_To ,
                                       short AV13OrderedBy ,
                                       bool AV14OrderedDsc ,
                                       GeneXus.Programs.wwpbaseobjects.SdtWWPGridState AV10GridState ,
                                       bool AV30DynamicFiltersIgnoreFirst ,
                                       bool AV29DynamicFiltersRemoving )
      {
         initialize_formulas( ) ;
         GxWebStd.set_html_headers( context, 0, "", "");
         /* Execute user event: Refresh */
         E251Z2 ();
         GRID_nCurrentRecord = 0;
         RF1Z2( ) ;
         GXKey = Crypto.GetSiteKey( );
         send_integrity_footer_hashes( ) ;
         GXKey = Crypto.GetSiteKey( );
         /* End function gxgrGrid_refresh */
      }

      protected void send_integrity_hashes( )
      {
         GxWebStd.gx_hidden_field( context, "gxhash_BANCOD", GetSecureSignedToken( "", context.localUtil.Format( (decimal)(A372BanCod), "ZZZZZ9"), context));
         GxWebStd.gx_hidden_field( context, "BANCOD", StringUtil.LTrim( StringUtil.NToC( (decimal)(A372BanCod), 6, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "gxhash_CBCOD", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( A377CBCod, "")), context));
         GxWebStd.gx_hidden_field( context, "CBCOD", StringUtil.RTrim( A377CBCod));
      }

      protected void clear_multi_value_controls( )
      {
         if ( context.isAjaxRequest( ) )
         {
            GXVvMONCOD1_html1Z2( ) ;
            GXVvMONCOD2_html1Z2( ) ;
            GXVvMONCOD3_html1Z2( ) ;
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
         if ( dynavMoncod1.ItemCount > 0 )
         {
            AV61MonCod1 = (int)(NumberUtil.Val( dynavMoncod1.getValidValue(StringUtil.Trim( StringUtil.Str( (decimal)(AV61MonCod1), 6, 0))), "."));
            AssignAttri("", false, "AV61MonCod1", StringUtil.LTrimStr( (decimal)(AV61MonCod1), 6, 0));
         }
         if ( context.isAjaxRequest( ) )
         {
            dynavMoncod1.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV61MonCod1), 6, 0));
            AssignProp("", false, dynavMoncod1_Internalname, "Values", dynavMoncod1.ToJavascriptSource(), true);
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
         if ( dynavMoncod2.ItemCount > 0 )
         {
            AV63MonCod2 = (int)(NumberUtil.Val( dynavMoncod2.getValidValue(StringUtil.Trim( StringUtil.Str( (decimal)(AV63MonCod2), 6, 0))), "."));
            AssignAttri("", false, "AV63MonCod2", StringUtil.LTrimStr( (decimal)(AV63MonCod2), 6, 0));
         }
         if ( context.isAjaxRequest( ) )
         {
            dynavMoncod2.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV63MonCod2), 6, 0));
            AssignProp("", false, dynavMoncod2_Internalname, "Values", dynavMoncod2.ToJavascriptSource(), true);
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
         if ( dynavMoncod3.ItemCount > 0 )
         {
            AV65MonCod3 = (int)(NumberUtil.Val( dynavMoncod3.getValidValue(StringUtil.Trim( StringUtil.Str( (decimal)(AV65MonCod3), 6, 0))), "."));
            AssignAttri("", false, "AV65MonCod3", StringUtil.LTrimStr( (decimal)(AV65MonCod3), 6, 0));
         }
         if ( context.isAjaxRequest( ) )
         {
            dynavMoncod3.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV65MonCod3), 6, 0));
            AssignProp("", false, dynavMoncod3_Internalname, "Values", dynavMoncod3.ToJavascriptSource(), true);
         }
      }

      public void Refresh( )
      {
         send_integrity_hashes( ) ;
         RF1Z2( ) ;
         if ( isFullAjaxMode( ) )
         {
            send_integrity_footer_hashes( ) ;
         }
      }

      protected void initialize_formulas( )
      {
         /* GeneXus formulas. */
         AV74Pgmname = "Bancos.CuentaBancosWW";
         context.Gx_err = 0;
      }

      protected void RF1Z2( )
      {
         initialize_formulas( ) ;
         clear_multi_value_controls( ) ;
         if ( isAjaxCallMode( ) )
         {
            GridContainer.ClearRows();
         }
         wbStart = 110;
         /* Execute user event: Refresh */
         E251Z2 ();
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
            pr_default.dynParam(3, new Object[]{ new Object[]{
                                                 AV75Bancos_cuentabancoswwds_1_dynamicfiltersselector1 ,
                                                 AV76Bancos_cuentabancoswwds_2_dynamicfiltersoperator1 ,
                                                 AV77Bancos_cuentabancoswwds_3_bandsc1 ,
                                                 AV78Bancos_cuentabancoswwds_4_moncod1 ,
                                                 AV79Bancos_cuentabancoswwds_5_dynamicfiltersenabled2 ,
                                                 AV80Bancos_cuentabancoswwds_6_dynamicfiltersselector2 ,
                                                 AV81Bancos_cuentabancoswwds_7_dynamicfiltersoperator2 ,
                                                 AV82Bancos_cuentabancoswwds_8_bandsc2 ,
                                                 AV83Bancos_cuentabancoswwds_9_moncod2 ,
                                                 AV84Bancos_cuentabancoswwds_10_dynamicfiltersenabled3 ,
                                                 AV85Bancos_cuentabancoswwds_11_dynamicfiltersselector3 ,
                                                 AV86Bancos_cuentabancoswwds_12_dynamicfiltersoperator3 ,
                                                 AV87Bancos_cuentabancoswwds_13_bandsc3 ,
                                                 AV88Bancos_cuentabancoswwds_14_moncod3 ,
                                                 AV90Bancos_cuentabancoswwds_16_tfbandsc_sel ,
                                                 AV89Bancos_cuentabancoswwds_15_tfbandsc ,
                                                 AV92Bancos_cuentabancoswwds_18_tfcbcod_sel ,
                                                 AV91Bancos_cuentabancoswwds_17_tfcbcod ,
                                                 AV94Bancos_cuentabancoswwds_20_tfmondsc_sel ,
                                                 AV93Bancos_cuentabancoswwds_19_tfmondsc ,
                                                 AV95Bancos_cuentabancoswwds_21_tfcbsts ,
                                                 AV96Bancos_cuentabancoswwds_22_tfcbsts_to ,
                                                 A482BanDsc ,
                                                 A180MonCod ,
                                                 A377CBCod ,
                                                 A1234MonDsc ,
                                                 A504CBSts ,
                                                 AV13OrderedBy ,
                                                 AV14OrderedDsc } ,
                                                 new int[]{
                                                 TypeConstants.SHORT, TypeConstants.INT, TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.INT, TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.INT, TypeConstants.SHORT, TypeConstants.SHORT,
                                                 TypeConstants.INT, TypeConstants.SHORT, TypeConstants.SHORT, TypeConstants.BOOLEAN
                                                 }
            });
            lV77Bancos_cuentabancoswwds_3_bandsc1 = StringUtil.PadR( StringUtil.RTrim( AV77Bancos_cuentabancoswwds_3_bandsc1), 100, "%");
            lV77Bancos_cuentabancoswwds_3_bandsc1 = StringUtil.PadR( StringUtil.RTrim( AV77Bancos_cuentabancoswwds_3_bandsc1), 100, "%");
            lV82Bancos_cuentabancoswwds_8_bandsc2 = StringUtil.PadR( StringUtil.RTrim( AV82Bancos_cuentabancoswwds_8_bandsc2), 100, "%");
            lV82Bancos_cuentabancoswwds_8_bandsc2 = StringUtil.PadR( StringUtil.RTrim( AV82Bancos_cuentabancoswwds_8_bandsc2), 100, "%");
            lV87Bancos_cuentabancoswwds_13_bandsc3 = StringUtil.PadR( StringUtil.RTrim( AV87Bancos_cuentabancoswwds_13_bandsc3), 100, "%");
            lV87Bancos_cuentabancoswwds_13_bandsc3 = StringUtil.PadR( StringUtil.RTrim( AV87Bancos_cuentabancoswwds_13_bandsc3), 100, "%");
            lV89Bancos_cuentabancoswwds_15_tfbandsc = StringUtil.PadR( StringUtil.RTrim( AV89Bancos_cuentabancoswwds_15_tfbandsc), 100, "%");
            lV91Bancos_cuentabancoswwds_17_tfcbcod = StringUtil.PadR( StringUtil.RTrim( AV91Bancos_cuentabancoswwds_17_tfcbcod), 20, "%");
            lV93Bancos_cuentabancoswwds_19_tfmondsc = StringUtil.PadR( StringUtil.RTrim( AV93Bancos_cuentabancoswwds_19_tfmondsc), 100, "%");
            /* Using cursor H001Z5 */
            pr_default.execute(3, new Object[] {lV77Bancos_cuentabancoswwds_3_bandsc1, lV77Bancos_cuentabancoswwds_3_bandsc1, AV78Bancos_cuentabancoswwds_4_moncod1, lV82Bancos_cuentabancoswwds_8_bandsc2, lV82Bancos_cuentabancoswwds_8_bandsc2, AV83Bancos_cuentabancoswwds_9_moncod2, lV87Bancos_cuentabancoswwds_13_bandsc3, lV87Bancos_cuentabancoswwds_13_bandsc3, AV88Bancos_cuentabancoswwds_14_moncod3, lV89Bancos_cuentabancoswwds_15_tfbandsc, AV90Bancos_cuentabancoswwds_16_tfbandsc_sel, lV91Bancos_cuentabancoswwds_17_tfcbcod, AV92Bancos_cuentabancoswwds_18_tfcbcod_sel, lV93Bancos_cuentabancoswwds_19_tfmondsc, AV94Bancos_cuentabancoswwds_20_tfmondsc_sel, AV95Bancos_cuentabancoswwds_21_tfcbsts, AV96Bancos_cuentabancoswwds_22_tfcbsts_to, GXPagingFrom2, GXPagingTo2, GXPagingTo2});
            nGXsfl_110_idx = 1;
            sGXsfl_110_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_110_idx), 4, 0), 4, "0");
            SubsflControlProps_1102( ) ;
            while ( ( (pr_default.getStatus(3) != 101) ) && ( ( ( subGrid_Rows == 0 ) || ( GRID_nCurrentRecord < subGrid_fnc_Recordsperpage( ) ) ) ) )
            {
               A180MonCod = H001Z5_A180MonCod[0];
               A372BanCod = H001Z5_A372BanCod[0];
               A504CBSts = H001Z5_A504CBSts[0];
               A1234MonDsc = H001Z5_A1234MonDsc[0];
               A377CBCod = H001Z5_A377CBCod[0];
               A482BanDsc = H001Z5_A482BanDsc[0];
               A1234MonDsc = H001Z5_A1234MonDsc[0];
               A482BanDsc = H001Z5_A482BanDsc[0];
               E261Z2 ();
               pr_default.readNext(3);
            }
            GRID_nEOF = (short)(((pr_default.getStatus(3) == 101) ? 1 : 0));
            GxWebStd.gx_hidden_field( context, "GRID_nEOF", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRID_nEOF), 1, 0, ".", "")));
            pr_default.close(3);
            wbEnd = 110;
            WB1Z0( ) ;
         }
         bGXsfl_110_Refreshing = true;
      }

      protected void send_integrity_lvl_hashes1Z2( )
      {
         GxWebStd.gx_hidden_field( context, "vPGMNAME", StringUtil.RTrim( AV74Pgmname));
         GxWebStd.gx_hidden_field( context, "gxhash_vPGMNAME", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( AV74Pgmname, "")), context));
         GxWebStd.gx_hidden_field( context, "gxhash_BANCOD"+"_"+sGXsfl_110_idx, GetSecureSignedToken( sGXsfl_110_idx, context.localUtil.Format( (decimal)(A372BanCod), "ZZZZZ9"), context));
         GxWebStd.gx_hidden_field( context, "gxhash_CBCOD"+"_"+sGXsfl_110_idx, GetSecureSignedToken( sGXsfl_110_idx, StringUtil.RTrim( context.localUtil.Format( A377CBCod, "")), context));
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
         AV75Bancos_cuentabancoswwds_1_dynamicfiltersselector1 = AV15DynamicFiltersSelector1;
         AV76Bancos_cuentabancoswwds_2_dynamicfiltersoperator1 = AV16DynamicFiltersOperator1;
         AV77Bancos_cuentabancoswwds_3_bandsc1 = AV60BanDsc1;
         AV78Bancos_cuentabancoswwds_4_moncod1 = AV61MonCod1;
         AV79Bancos_cuentabancoswwds_5_dynamicfiltersenabled2 = AV19DynamicFiltersEnabled2;
         AV80Bancos_cuentabancoswwds_6_dynamicfiltersselector2 = AV20DynamicFiltersSelector2;
         AV81Bancos_cuentabancoswwds_7_dynamicfiltersoperator2 = AV21DynamicFiltersOperator2;
         AV82Bancos_cuentabancoswwds_8_bandsc2 = AV62BanDsc2;
         AV83Bancos_cuentabancoswwds_9_moncod2 = AV63MonCod2;
         AV84Bancos_cuentabancoswwds_10_dynamicfiltersenabled3 = AV24DynamicFiltersEnabled3;
         AV85Bancos_cuentabancoswwds_11_dynamicfiltersselector3 = AV25DynamicFiltersSelector3;
         AV86Bancos_cuentabancoswwds_12_dynamicfiltersoperator3 = AV26DynamicFiltersOperator3;
         AV87Bancos_cuentabancoswwds_13_bandsc3 = AV64BanDsc3;
         AV88Bancos_cuentabancoswwds_14_moncod3 = AV65MonCod3;
         AV89Bancos_cuentabancoswwds_15_tfbandsc = AV66TFBanDsc;
         AV90Bancos_cuentabancoswwds_16_tfbandsc_sel = AV67TFBanDsc_Sel;
         AV91Bancos_cuentabancoswwds_17_tfcbcod = AV36TFCBCod;
         AV92Bancos_cuentabancoswwds_18_tfcbcod_sel = AV37TFCBCod_Sel;
         AV93Bancos_cuentabancoswwds_19_tfmondsc = AV68TFMonDsc;
         AV94Bancos_cuentabancoswwds_20_tfmondsc_sel = AV69TFMonDsc_Sel;
         AV95Bancos_cuentabancoswwds_21_tfcbsts = AV42TFCBSts;
         AV96Bancos_cuentabancoswwds_22_tfcbsts_to = AV43TFCBSts_To;
         pr_default.dynParam(4, new Object[]{ new Object[]{
                                              AV75Bancos_cuentabancoswwds_1_dynamicfiltersselector1 ,
                                              AV76Bancos_cuentabancoswwds_2_dynamicfiltersoperator1 ,
                                              AV77Bancos_cuentabancoswwds_3_bandsc1 ,
                                              AV78Bancos_cuentabancoswwds_4_moncod1 ,
                                              AV79Bancos_cuentabancoswwds_5_dynamicfiltersenabled2 ,
                                              AV80Bancos_cuentabancoswwds_6_dynamicfiltersselector2 ,
                                              AV81Bancos_cuentabancoswwds_7_dynamicfiltersoperator2 ,
                                              AV82Bancos_cuentabancoswwds_8_bandsc2 ,
                                              AV83Bancos_cuentabancoswwds_9_moncod2 ,
                                              AV84Bancos_cuentabancoswwds_10_dynamicfiltersenabled3 ,
                                              AV85Bancos_cuentabancoswwds_11_dynamicfiltersselector3 ,
                                              AV86Bancos_cuentabancoswwds_12_dynamicfiltersoperator3 ,
                                              AV87Bancos_cuentabancoswwds_13_bandsc3 ,
                                              AV88Bancos_cuentabancoswwds_14_moncod3 ,
                                              AV90Bancos_cuentabancoswwds_16_tfbandsc_sel ,
                                              AV89Bancos_cuentabancoswwds_15_tfbandsc ,
                                              AV92Bancos_cuentabancoswwds_18_tfcbcod_sel ,
                                              AV91Bancos_cuentabancoswwds_17_tfcbcod ,
                                              AV94Bancos_cuentabancoswwds_20_tfmondsc_sel ,
                                              AV93Bancos_cuentabancoswwds_19_tfmondsc ,
                                              AV95Bancos_cuentabancoswwds_21_tfcbsts ,
                                              AV96Bancos_cuentabancoswwds_22_tfcbsts_to ,
                                              A482BanDsc ,
                                              A180MonCod ,
                                              A377CBCod ,
                                              A1234MonDsc ,
                                              A504CBSts ,
                                              AV13OrderedBy ,
                                              AV14OrderedDsc } ,
                                              new int[]{
                                              TypeConstants.SHORT, TypeConstants.INT, TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.INT, TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.INT, TypeConstants.SHORT, TypeConstants.SHORT,
                                              TypeConstants.INT, TypeConstants.SHORT, TypeConstants.SHORT, TypeConstants.BOOLEAN
                                              }
         });
         lV77Bancos_cuentabancoswwds_3_bandsc1 = StringUtil.PadR( StringUtil.RTrim( AV77Bancos_cuentabancoswwds_3_bandsc1), 100, "%");
         lV77Bancos_cuentabancoswwds_3_bandsc1 = StringUtil.PadR( StringUtil.RTrim( AV77Bancos_cuentabancoswwds_3_bandsc1), 100, "%");
         lV82Bancos_cuentabancoswwds_8_bandsc2 = StringUtil.PadR( StringUtil.RTrim( AV82Bancos_cuentabancoswwds_8_bandsc2), 100, "%");
         lV82Bancos_cuentabancoswwds_8_bandsc2 = StringUtil.PadR( StringUtil.RTrim( AV82Bancos_cuentabancoswwds_8_bandsc2), 100, "%");
         lV87Bancos_cuentabancoswwds_13_bandsc3 = StringUtil.PadR( StringUtil.RTrim( AV87Bancos_cuentabancoswwds_13_bandsc3), 100, "%");
         lV87Bancos_cuentabancoswwds_13_bandsc3 = StringUtil.PadR( StringUtil.RTrim( AV87Bancos_cuentabancoswwds_13_bandsc3), 100, "%");
         lV89Bancos_cuentabancoswwds_15_tfbandsc = StringUtil.PadR( StringUtil.RTrim( AV89Bancos_cuentabancoswwds_15_tfbandsc), 100, "%");
         lV91Bancos_cuentabancoswwds_17_tfcbcod = StringUtil.PadR( StringUtil.RTrim( AV91Bancos_cuentabancoswwds_17_tfcbcod), 20, "%");
         lV93Bancos_cuentabancoswwds_19_tfmondsc = StringUtil.PadR( StringUtil.RTrim( AV93Bancos_cuentabancoswwds_19_tfmondsc), 100, "%");
         /* Using cursor H001Z6 */
         pr_default.execute(4, new Object[] {lV77Bancos_cuentabancoswwds_3_bandsc1, lV77Bancos_cuentabancoswwds_3_bandsc1, AV78Bancos_cuentabancoswwds_4_moncod1, lV82Bancos_cuentabancoswwds_8_bandsc2, lV82Bancos_cuentabancoswwds_8_bandsc2, AV83Bancos_cuentabancoswwds_9_moncod2, lV87Bancos_cuentabancoswwds_13_bandsc3, lV87Bancos_cuentabancoswwds_13_bandsc3, AV88Bancos_cuentabancoswwds_14_moncod3, lV89Bancos_cuentabancoswwds_15_tfbandsc, AV90Bancos_cuentabancoswwds_16_tfbandsc_sel, lV91Bancos_cuentabancoswwds_17_tfcbcod, AV92Bancos_cuentabancoswwds_18_tfcbcod_sel, lV93Bancos_cuentabancoswwds_19_tfmondsc, AV94Bancos_cuentabancoswwds_20_tfmondsc_sel, AV95Bancos_cuentabancoswwds_21_tfcbsts, AV96Bancos_cuentabancoswwds_22_tfcbsts_to});
         GRID_nRecordCount = H001Z6_AGRID_nRecordCount[0];
         pr_default.close(4);
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
         AV75Bancos_cuentabancoswwds_1_dynamicfiltersselector1 = AV15DynamicFiltersSelector1;
         AV76Bancos_cuentabancoswwds_2_dynamicfiltersoperator1 = AV16DynamicFiltersOperator1;
         AV77Bancos_cuentabancoswwds_3_bandsc1 = AV60BanDsc1;
         AV78Bancos_cuentabancoswwds_4_moncod1 = AV61MonCod1;
         AV79Bancos_cuentabancoswwds_5_dynamicfiltersenabled2 = AV19DynamicFiltersEnabled2;
         AV80Bancos_cuentabancoswwds_6_dynamicfiltersselector2 = AV20DynamicFiltersSelector2;
         AV81Bancos_cuentabancoswwds_7_dynamicfiltersoperator2 = AV21DynamicFiltersOperator2;
         AV82Bancos_cuentabancoswwds_8_bandsc2 = AV62BanDsc2;
         AV83Bancos_cuentabancoswwds_9_moncod2 = AV63MonCod2;
         AV84Bancos_cuentabancoswwds_10_dynamicfiltersenabled3 = AV24DynamicFiltersEnabled3;
         AV85Bancos_cuentabancoswwds_11_dynamicfiltersselector3 = AV25DynamicFiltersSelector3;
         AV86Bancos_cuentabancoswwds_12_dynamicfiltersoperator3 = AV26DynamicFiltersOperator3;
         AV87Bancos_cuentabancoswwds_13_bandsc3 = AV64BanDsc3;
         AV88Bancos_cuentabancoswwds_14_moncod3 = AV65MonCod3;
         AV89Bancos_cuentabancoswwds_15_tfbandsc = AV66TFBanDsc;
         AV90Bancos_cuentabancoswwds_16_tfbandsc_sel = AV67TFBanDsc_Sel;
         AV91Bancos_cuentabancoswwds_17_tfcbcod = AV36TFCBCod;
         AV92Bancos_cuentabancoswwds_18_tfcbcod_sel = AV37TFCBCod_Sel;
         AV93Bancos_cuentabancoswwds_19_tfmondsc = AV68TFMonDsc;
         AV94Bancos_cuentabancoswwds_20_tfmondsc_sel = AV69TFMonDsc_Sel;
         AV95Bancos_cuentabancoswwds_21_tfcbsts = AV42TFCBSts;
         AV96Bancos_cuentabancoswwds_22_tfcbsts_to = AV43TFCBSts_To;
         GRID_nFirstRecordOnPage = 0;
         GxWebStd.gx_hidden_field( context, "GRID_nFirstRecordOnPage", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRID_nFirstRecordOnPage), 15, 0, ".", "")));
         if ( isFullAjaxMode( ) )
         {
            gxgrGrid_refresh( subGrid_Rows, AV15DynamicFiltersSelector1, AV16DynamicFiltersOperator1, AV60BanDsc1, AV61MonCod1, AV20DynamicFiltersSelector2, AV21DynamicFiltersOperator2, AV62BanDsc2, AV63MonCod2, AV25DynamicFiltersSelector3, AV26DynamicFiltersOperator3, AV64BanDsc3, AV65MonCod3, AV74Pgmname, AV19DynamicFiltersEnabled2, AV24DynamicFiltersEnabled3, AV66TFBanDsc, AV67TFBanDsc_Sel, AV36TFCBCod, AV37TFCBCod_Sel, AV68TFMonDsc, AV69TFMonDsc_Sel, AV42TFCBSts, AV43TFCBSts_To, AV13OrderedBy, AV14OrderedDsc, AV10GridState, AV30DynamicFiltersIgnoreFirst, AV29DynamicFiltersRemoving) ;
         }
         send_integrity_footer_hashes( ) ;
         return 0 ;
      }

      protected short subgrid_nextpage( )
      {
         AV75Bancos_cuentabancoswwds_1_dynamicfiltersselector1 = AV15DynamicFiltersSelector1;
         AV76Bancos_cuentabancoswwds_2_dynamicfiltersoperator1 = AV16DynamicFiltersOperator1;
         AV77Bancos_cuentabancoswwds_3_bandsc1 = AV60BanDsc1;
         AV78Bancos_cuentabancoswwds_4_moncod1 = AV61MonCod1;
         AV79Bancos_cuentabancoswwds_5_dynamicfiltersenabled2 = AV19DynamicFiltersEnabled2;
         AV80Bancos_cuentabancoswwds_6_dynamicfiltersselector2 = AV20DynamicFiltersSelector2;
         AV81Bancos_cuentabancoswwds_7_dynamicfiltersoperator2 = AV21DynamicFiltersOperator2;
         AV82Bancos_cuentabancoswwds_8_bandsc2 = AV62BanDsc2;
         AV83Bancos_cuentabancoswwds_9_moncod2 = AV63MonCod2;
         AV84Bancos_cuentabancoswwds_10_dynamicfiltersenabled3 = AV24DynamicFiltersEnabled3;
         AV85Bancos_cuentabancoswwds_11_dynamicfiltersselector3 = AV25DynamicFiltersSelector3;
         AV86Bancos_cuentabancoswwds_12_dynamicfiltersoperator3 = AV26DynamicFiltersOperator3;
         AV87Bancos_cuentabancoswwds_13_bandsc3 = AV64BanDsc3;
         AV88Bancos_cuentabancoswwds_14_moncod3 = AV65MonCod3;
         AV89Bancos_cuentabancoswwds_15_tfbandsc = AV66TFBanDsc;
         AV90Bancos_cuentabancoswwds_16_tfbandsc_sel = AV67TFBanDsc_Sel;
         AV91Bancos_cuentabancoswwds_17_tfcbcod = AV36TFCBCod;
         AV92Bancos_cuentabancoswwds_18_tfcbcod_sel = AV37TFCBCod_Sel;
         AV93Bancos_cuentabancoswwds_19_tfmondsc = AV68TFMonDsc;
         AV94Bancos_cuentabancoswwds_20_tfmondsc_sel = AV69TFMonDsc_Sel;
         AV95Bancos_cuentabancoswwds_21_tfcbsts = AV42TFCBSts;
         AV96Bancos_cuentabancoswwds_22_tfcbsts_to = AV43TFCBSts_To;
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
            gxgrGrid_refresh( subGrid_Rows, AV15DynamicFiltersSelector1, AV16DynamicFiltersOperator1, AV60BanDsc1, AV61MonCod1, AV20DynamicFiltersSelector2, AV21DynamicFiltersOperator2, AV62BanDsc2, AV63MonCod2, AV25DynamicFiltersSelector3, AV26DynamicFiltersOperator3, AV64BanDsc3, AV65MonCod3, AV74Pgmname, AV19DynamicFiltersEnabled2, AV24DynamicFiltersEnabled3, AV66TFBanDsc, AV67TFBanDsc_Sel, AV36TFCBCod, AV37TFCBCod_Sel, AV68TFMonDsc, AV69TFMonDsc_Sel, AV42TFCBSts, AV43TFCBSts_To, AV13OrderedBy, AV14OrderedDsc, AV10GridState, AV30DynamicFiltersIgnoreFirst, AV29DynamicFiltersRemoving) ;
         }
         send_integrity_footer_hashes( ) ;
         return (short)(((GRID_nEOF==0) ? 0 : 2)) ;
      }

      protected short subgrid_previouspage( )
      {
         AV75Bancos_cuentabancoswwds_1_dynamicfiltersselector1 = AV15DynamicFiltersSelector1;
         AV76Bancos_cuentabancoswwds_2_dynamicfiltersoperator1 = AV16DynamicFiltersOperator1;
         AV77Bancos_cuentabancoswwds_3_bandsc1 = AV60BanDsc1;
         AV78Bancos_cuentabancoswwds_4_moncod1 = AV61MonCod1;
         AV79Bancos_cuentabancoswwds_5_dynamicfiltersenabled2 = AV19DynamicFiltersEnabled2;
         AV80Bancos_cuentabancoswwds_6_dynamicfiltersselector2 = AV20DynamicFiltersSelector2;
         AV81Bancos_cuentabancoswwds_7_dynamicfiltersoperator2 = AV21DynamicFiltersOperator2;
         AV82Bancos_cuentabancoswwds_8_bandsc2 = AV62BanDsc2;
         AV83Bancos_cuentabancoswwds_9_moncod2 = AV63MonCod2;
         AV84Bancos_cuentabancoswwds_10_dynamicfiltersenabled3 = AV24DynamicFiltersEnabled3;
         AV85Bancos_cuentabancoswwds_11_dynamicfiltersselector3 = AV25DynamicFiltersSelector3;
         AV86Bancos_cuentabancoswwds_12_dynamicfiltersoperator3 = AV26DynamicFiltersOperator3;
         AV87Bancos_cuentabancoswwds_13_bandsc3 = AV64BanDsc3;
         AV88Bancos_cuentabancoswwds_14_moncod3 = AV65MonCod3;
         AV89Bancos_cuentabancoswwds_15_tfbandsc = AV66TFBanDsc;
         AV90Bancos_cuentabancoswwds_16_tfbandsc_sel = AV67TFBanDsc_Sel;
         AV91Bancos_cuentabancoswwds_17_tfcbcod = AV36TFCBCod;
         AV92Bancos_cuentabancoswwds_18_tfcbcod_sel = AV37TFCBCod_Sel;
         AV93Bancos_cuentabancoswwds_19_tfmondsc = AV68TFMonDsc;
         AV94Bancos_cuentabancoswwds_20_tfmondsc_sel = AV69TFMonDsc_Sel;
         AV95Bancos_cuentabancoswwds_21_tfcbsts = AV42TFCBSts;
         AV96Bancos_cuentabancoswwds_22_tfcbsts_to = AV43TFCBSts_To;
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
            gxgrGrid_refresh( subGrid_Rows, AV15DynamicFiltersSelector1, AV16DynamicFiltersOperator1, AV60BanDsc1, AV61MonCod1, AV20DynamicFiltersSelector2, AV21DynamicFiltersOperator2, AV62BanDsc2, AV63MonCod2, AV25DynamicFiltersSelector3, AV26DynamicFiltersOperator3, AV64BanDsc3, AV65MonCod3, AV74Pgmname, AV19DynamicFiltersEnabled2, AV24DynamicFiltersEnabled3, AV66TFBanDsc, AV67TFBanDsc_Sel, AV36TFCBCod, AV37TFCBCod_Sel, AV68TFMonDsc, AV69TFMonDsc_Sel, AV42TFCBSts, AV43TFCBSts_To, AV13OrderedBy, AV14OrderedDsc, AV10GridState, AV30DynamicFiltersIgnoreFirst, AV29DynamicFiltersRemoving) ;
         }
         send_integrity_footer_hashes( ) ;
         return 0 ;
      }

      protected short subgrid_lastpage( )
      {
         AV75Bancos_cuentabancoswwds_1_dynamicfiltersselector1 = AV15DynamicFiltersSelector1;
         AV76Bancos_cuentabancoswwds_2_dynamicfiltersoperator1 = AV16DynamicFiltersOperator1;
         AV77Bancos_cuentabancoswwds_3_bandsc1 = AV60BanDsc1;
         AV78Bancos_cuentabancoswwds_4_moncod1 = AV61MonCod1;
         AV79Bancos_cuentabancoswwds_5_dynamicfiltersenabled2 = AV19DynamicFiltersEnabled2;
         AV80Bancos_cuentabancoswwds_6_dynamicfiltersselector2 = AV20DynamicFiltersSelector2;
         AV81Bancos_cuentabancoswwds_7_dynamicfiltersoperator2 = AV21DynamicFiltersOperator2;
         AV82Bancos_cuentabancoswwds_8_bandsc2 = AV62BanDsc2;
         AV83Bancos_cuentabancoswwds_9_moncod2 = AV63MonCod2;
         AV84Bancos_cuentabancoswwds_10_dynamicfiltersenabled3 = AV24DynamicFiltersEnabled3;
         AV85Bancos_cuentabancoswwds_11_dynamicfiltersselector3 = AV25DynamicFiltersSelector3;
         AV86Bancos_cuentabancoswwds_12_dynamicfiltersoperator3 = AV26DynamicFiltersOperator3;
         AV87Bancos_cuentabancoswwds_13_bandsc3 = AV64BanDsc3;
         AV88Bancos_cuentabancoswwds_14_moncod3 = AV65MonCod3;
         AV89Bancos_cuentabancoswwds_15_tfbandsc = AV66TFBanDsc;
         AV90Bancos_cuentabancoswwds_16_tfbandsc_sel = AV67TFBanDsc_Sel;
         AV91Bancos_cuentabancoswwds_17_tfcbcod = AV36TFCBCod;
         AV92Bancos_cuentabancoswwds_18_tfcbcod_sel = AV37TFCBCod_Sel;
         AV93Bancos_cuentabancoswwds_19_tfmondsc = AV68TFMonDsc;
         AV94Bancos_cuentabancoswwds_20_tfmondsc_sel = AV69TFMonDsc_Sel;
         AV95Bancos_cuentabancoswwds_21_tfcbsts = AV42TFCBSts;
         AV96Bancos_cuentabancoswwds_22_tfcbsts_to = AV43TFCBSts_To;
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
            gxgrGrid_refresh( subGrid_Rows, AV15DynamicFiltersSelector1, AV16DynamicFiltersOperator1, AV60BanDsc1, AV61MonCod1, AV20DynamicFiltersSelector2, AV21DynamicFiltersOperator2, AV62BanDsc2, AV63MonCod2, AV25DynamicFiltersSelector3, AV26DynamicFiltersOperator3, AV64BanDsc3, AV65MonCod3, AV74Pgmname, AV19DynamicFiltersEnabled2, AV24DynamicFiltersEnabled3, AV66TFBanDsc, AV67TFBanDsc_Sel, AV36TFCBCod, AV37TFCBCod_Sel, AV68TFMonDsc, AV69TFMonDsc_Sel, AV42TFCBSts, AV43TFCBSts_To, AV13OrderedBy, AV14OrderedDsc, AV10GridState, AV30DynamicFiltersIgnoreFirst, AV29DynamicFiltersRemoving) ;
         }
         send_integrity_footer_hashes( ) ;
         return 0 ;
      }

      protected int subgrid_gotopage( int nPageNo )
      {
         AV75Bancos_cuentabancoswwds_1_dynamicfiltersselector1 = AV15DynamicFiltersSelector1;
         AV76Bancos_cuentabancoswwds_2_dynamicfiltersoperator1 = AV16DynamicFiltersOperator1;
         AV77Bancos_cuentabancoswwds_3_bandsc1 = AV60BanDsc1;
         AV78Bancos_cuentabancoswwds_4_moncod1 = AV61MonCod1;
         AV79Bancos_cuentabancoswwds_5_dynamicfiltersenabled2 = AV19DynamicFiltersEnabled2;
         AV80Bancos_cuentabancoswwds_6_dynamicfiltersselector2 = AV20DynamicFiltersSelector2;
         AV81Bancos_cuentabancoswwds_7_dynamicfiltersoperator2 = AV21DynamicFiltersOperator2;
         AV82Bancos_cuentabancoswwds_8_bandsc2 = AV62BanDsc2;
         AV83Bancos_cuentabancoswwds_9_moncod2 = AV63MonCod2;
         AV84Bancos_cuentabancoswwds_10_dynamicfiltersenabled3 = AV24DynamicFiltersEnabled3;
         AV85Bancos_cuentabancoswwds_11_dynamicfiltersselector3 = AV25DynamicFiltersSelector3;
         AV86Bancos_cuentabancoswwds_12_dynamicfiltersoperator3 = AV26DynamicFiltersOperator3;
         AV87Bancos_cuentabancoswwds_13_bandsc3 = AV64BanDsc3;
         AV88Bancos_cuentabancoswwds_14_moncod3 = AV65MonCod3;
         AV89Bancos_cuentabancoswwds_15_tfbandsc = AV66TFBanDsc;
         AV90Bancos_cuentabancoswwds_16_tfbandsc_sel = AV67TFBanDsc_Sel;
         AV91Bancos_cuentabancoswwds_17_tfcbcod = AV36TFCBCod;
         AV92Bancos_cuentabancoswwds_18_tfcbcod_sel = AV37TFCBCod_Sel;
         AV93Bancos_cuentabancoswwds_19_tfmondsc = AV68TFMonDsc;
         AV94Bancos_cuentabancoswwds_20_tfmondsc_sel = AV69TFMonDsc_Sel;
         AV95Bancos_cuentabancoswwds_21_tfcbsts = AV42TFCBSts;
         AV96Bancos_cuentabancoswwds_22_tfcbsts_to = AV43TFCBSts_To;
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
            gxgrGrid_refresh( subGrid_Rows, AV15DynamicFiltersSelector1, AV16DynamicFiltersOperator1, AV60BanDsc1, AV61MonCod1, AV20DynamicFiltersSelector2, AV21DynamicFiltersOperator2, AV62BanDsc2, AV63MonCod2, AV25DynamicFiltersSelector3, AV26DynamicFiltersOperator3, AV64BanDsc3, AV65MonCod3, AV74Pgmname, AV19DynamicFiltersEnabled2, AV24DynamicFiltersEnabled3, AV66TFBanDsc, AV67TFBanDsc_Sel, AV36TFCBCod, AV37TFCBCod_Sel, AV68TFMonDsc, AV69TFMonDsc_Sel, AV42TFCBSts, AV43TFCBSts_To, AV13OrderedBy, AV14OrderedDsc, AV10GridState, AV30DynamicFiltersIgnoreFirst, AV29DynamicFiltersRemoving) ;
         }
         send_integrity_footer_hashes( ) ;
         return (int)(0) ;
      }

      protected void before_start_formulas( )
      {
         AV74Pgmname = "Bancos.CuentaBancosWW";
         context.Gx_err = 0;
         GXVvMONCOD1_html1Z2( ) ;
         GXVvMONCOD2_html1Z2( ) ;
         GXVvMONCOD3_html1Z2( ) ;
         fix_multi_value_controls( ) ;
      }

      protected void STRUP1Z0( )
      {
         /* Before Start, stand alone formulas. */
         before_start_formulas( ) ;
         /* Execute Start event if defined. */
         context.wbGlbDoneStart = 0;
         /* Execute user event: Start */
         E241Z2 ();
         context.wbGlbDoneStart = 1;
         /* After Start, stand alone formulas. */
         if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
         {
            /* Read saved SDTs. */
            ajax_req_read_hidden_sdt(cgiGet( "vAGEXPORTDATA"), AV58AGExportData);
            ajax_req_read_hidden_sdt(cgiGet( "vDDO_TITLESETTINGSICONS"), AV52DDO_TitleSettingsIcons);
            /* Read saved values. */
            nRC_GXsfl_110 = (int)(context.localUtil.CToN( cgiGet( "nRC_GXsfl_110"), ".", ","));
            AV54GridCurrentPage = (long)(context.localUtil.CToN( cgiGet( "vGRIDCURRENTPAGE"), ".", ","));
            AV55GridPageCount = (long)(context.localUtil.CToN( cgiGet( "vGRIDPAGECOUNT"), ".", ","));
            AV56GridAppliedFilters = cgiGet( "vGRIDAPPLIEDFILTERS");
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
            AV60BanDsc1 = cgiGet( edtavBandsc1_Internalname);
            AssignAttri("", false, "AV60BanDsc1", AV60BanDsc1);
            dynavMoncod1.Name = dynavMoncod1_Internalname;
            dynavMoncod1.CurrentValue = cgiGet( dynavMoncod1_Internalname);
            AV61MonCod1 = (int)(NumberUtil.Val( cgiGet( dynavMoncod1_Internalname), "."));
            AssignAttri("", false, "AV61MonCod1", StringUtil.LTrimStr( (decimal)(AV61MonCod1), 6, 0));
            cmbavDynamicfiltersselector2.Name = cmbavDynamicfiltersselector2_Internalname;
            cmbavDynamicfiltersselector2.CurrentValue = cgiGet( cmbavDynamicfiltersselector2_Internalname);
            AV20DynamicFiltersSelector2 = cgiGet( cmbavDynamicfiltersselector2_Internalname);
            AssignAttri("", false, "AV20DynamicFiltersSelector2", AV20DynamicFiltersSelector2);
            cmbavDynamicfiltersoperator2.Name = cmbavDynamicfiltersoperator2_Internalname;
            cmbavDynamicfiltersoperator2.CurrentValue = cgiGet( cmbavDynamicfiltersoperator2_Internalname);
            AV21DynamicFiltersOperator2 = (short)(NumberUtil.Val( cgiGet( cmbavDynamicfiltersoperator2_Internalname), "."));
            AssignAttri("", false, "AV21DynamicFiltersOperator2", StringUtil.LTrimStr( (decimal)(AV21DynamicFiltersOperator2), 4, 0));
            AV62BanDsc2 = cgiGet( edtavBandsc2_Internalname);
            AssignAttri("", false, "AV62BanDsc2", AV62BanDsc2);
            dynavMoncod2.Name = dynavMoncod2_Internalname;
            dynavMoncod2.CurrentValue = cgiGet( dynavMoncod2_Internalname);
            AV63MonCod2 = (int)(NumberUtil.Val( cgiGet( dynavMoncod2_Internalname), "."));
            AssignAttri("", false, "AV63MonCod2", StringUtil.LTrimStr( (decimal)(AV63MonCod2), 6, 0));
            cmbavDynamicfiltersselector3.Name = cmbavDynamicfiltersselector3_Internalname;
            cmbavDynamicfiltersselector3.CurrentValue = cgiGet( cmbavDynamicfiltersselector3_Internalname);
            AV25DynamicFiltersSelector3 = cgiGet( cmbavDynamicfiltersselector3_Internalname);
            AssignAttri("", false, "AV25DynamicFiltersSelector3", AV25DynamicFiltersSelector3);
            cmbavDynamicfiltersoperator3.Name = cmbavDynamicfiltersoperator3_Internalname;
            cmbavDynamicfiltersoperator3.CurrentValue = cgiGet( cmbavDynamicfiltersoperator3_Internalname);
            AV26DynamicFiltersOperator3 = (short)(NumberUtil.Val( cgiGet( cmbavDynamicfiltersoperator3_Internalname), "."));
            AssignAttri("", false, "AV26DynamicFiltersOperator3", StringUtil.LTrimStr( (decimal)(AV26DynamicFiltersOperator3), 4, 0));
            AV64BanDsc3 = cgiGet( edtavBandsc3_Internalname);
            AssignAttri("", false, "AV64BanDsc3", AV64BanDsc3);
            dynavMoncod3.Name = dynavMoncod3_Internalname;
            dynavMoncod3.CurrentValue = cgiGet( dynavMoncod3_Internalname);
            AV65MonCod3 = (int)(NumberUtil.Val( cgiGet( dynavMoncod3_Internalname), "."));
            AssignAttri("", false, "AV65MonCod3", StringUtil.LTrimStr( (decimal)(AV65MonCod3), 6, 0));
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
            if ( StringUtil.StrCmp(cgiGet( "GXH_vBANDSC1"), AV60BanDsc1) != 0 )
            {
               GRID_nFirstRecordOnPage = 0;
            }
            if ( ( context.localUtil.CToN( cgiGet( "GXH_vMONCOD1"), ".", ",") != Convert.ToDecimal( AV61MonCod1 )) )
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
            if ( StringUtil.StrCmp(cgiGet( "GXH_vBANDSC2"), AV62BanDsc2) != 0 )
            {
               GRID_nFirstRecordOnPage = 0;
            }
            if ( ( context.localUtil.CToN( cgiGet( "GXH_vMONCOD2"), ".", ",") != Convert.ToDecimal( AV63MonCod2 )) )
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
            if ( StringUtil.StrCmp(cgiGet( "GXH_vBANDSC3"), AV64BanDsc3) != 0 )
            {
               GRID_nFirstRecordOnPage = 0;
            }
            if ( ( context.localUtil.CToN( cgiGet( "GXH_vMONCOD3"), ".", ",") != Convert.ToDecimal( AV65MonCod3 )) )
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
         E241Z2 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
      }

      protected void E241Z2( )
      {
         /* Start Routine */
         returnInSub = false;
         subGrid_Rows = 10;
         GxWebStd.gx_hidden_field( context, "GRID_Rows", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid_Rows), 6, 0, ".", "")));
         Grid_empowerer_Gridinternalname = subGrid_Internalname;
         ucGrid_empowerer.SendProperty(context, "", false, Grid_empowerer_Internalname, "GridInternalName", Grid_empowerer_Gridinternalname);
         lblJsdynamicfilters_Caption = "";
         AssignProp("", false, lblJsdynamicfilters_Internalname, "Caption", lblJsdynamicfilters_Caption, true);
         AV15DynamicFiltersSelector1 = "BANDSC";
         AssignAttri("", false, "AV15DynamicFiltersSelector1", AV15DynamicFiltersSelector1);
         /* Execute user subroutine: 'ENABLEDYNAMICFILTERS1' */
         S112 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
         AV20DynamicFiltersSelector2 = "BANDSC";
         AssignAttri("", false, "AV20DynamicFiltersSelector2", AV20DynamicFiltersSelector2);
         /* Execute user subroutine: 'ENABLEDYNAMICFILTERS2' */
         S122 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
         AV25DynamicFiltersSelector3 = "BANDSC";
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
         AV58AGExportData = new GXBaseCollection<GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTDropDownOptionsData_Item>( context, "Item", "");
         AV59AGExportDataItem = new GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTDropDownOptionsData_Item(context);
         AV59AGExportDataItem.gxTpr_Title = "PDF";
         AV59AGExportDataItem.gxTpr_Icon = context.convertURL( (string)(context.GetImagePath( "776fb79c-a0a1-4302-b5e5-d773dbe1a297", "", context.GetTheme( ))));
         AV59AGExportDataItem.gxTpr_Eventkey = "ExportReport";
         AV59AGExportDataItem.gxTpr_Isdivider = false;
         AV58AGExportData.Add(AV59AGExportDataItem, 0);
         AV59AGExportDataItem = new GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTDropDownOptionsData_Item(context);
         AV59AGExportDataItem.gxTpr_Title = "Excel";
         AV59AGExportDataItem.gxTpr_Icon = context.convertURL( (string)(context.GetImagePath( "da69a816-fd11-445b-8aaf-1a2f7f1acc93", "", context.GetTheme( ))));
         AV59AGExportDataItem.gxTpr_Eventkey = "Export";
         AV59AGExportDataItem.gxTpr_Isdivider = false;
         AV58AGExportData.Add(AV59AGExportDataItem, 0);
         Ddo_grid_Gridinternalname = subGrid_Internalname;
         ucDdo_grid.SendProperty(context, "", false, Ddo_grid_Internalname, "GridInternalName", Ddo_grid_Gridinternalname);
         Form.Caption = " Cuenta Bancos";
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
         GXt_SdtDVB_SDTDropDownOptionsTitleSettingsIcons1 = AV52DDO_TitleSettingsIcons;
         new GeneXus.Programs.wwpbaseobjects.getwwptitlesettingsicons(context ).execute( out  GXt_SdtDVB_SDTDropDownOptionsTitleSettingsIcons1) ;
         AV52DDO_TitleSettingsIcons = GXt_SdtDVB_SDTDropDownOptionsTitleSettingsIcons1;
         Gridpaginationbar_Rowsperpageselectedvalue = subGrid_Rows;
         ucGridpaginationbar.SendProperty(context, "", false, Gridpaginationbar_Internalname, "RowsPerPageSelectedValue", StringUtil.LTrimStr( (decimal)(Gridpaginationbar_Rowsperpageselectedvalue), 9, 0));
      }

      protected void E251Z2( )
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
         AV54GridCurrentPage = subGrid_fnc_Currentpage( );
         AssignAttri("", false, "AV54GridCurrentPage", StringUtil.LTrimStr( (decimal)(AV54GridCurrentPage), 10, 0));
         AV55GridPageCount = subGrid_fnc_Pagecount( );
         AssignAttri("", false, "AV55GridPageCount", StringUtil.LTrimStr( (decimal)(AV55GridPageCount), 10, 0));
         GXt_char2 = AV56GridAppliedFilters;
         new GeneXus.Programs.wwpbaseobjects.wwp_getappliedfiltersdescription(context ).execute(  AV74Pgmname, out  GXt_char2) ;
         AV56GridAppliedFilters = GXt_char2;
         AssignAttri("", false, "AV56GridAppliedFilters", AV56GridAppliedFilters);
         AV75Bancos_cuentabancoswwds_1_dynamicfiltersselector1 = AV15DynamicFiltersSelector1;
         AV76Bancos_cuentabancoswwds_2_dynamicfiltersoperator1 = AV16DynamicFiltersOperator1;
         AV77Bancos_cuentabancoswwds_3_bandsc1 = AV60BanDsc1;
         AV78Bancos_cuentabancoswwds_4_moncod1 = AV61MonCod1;
         AV79Bancos_cuentabancoswwds_5_dynamicfiltersenabled2 = AV19DynamicFiltersEnabled2;
         AV80Bancos_cuentabancoswwds_6_dynamicfiltersselector2 = AV20DynamicFiltersSelector2;
         AV81Bancos_cuentabancoswwds_7_dynamicfiltersoperator2 = AV21DynamicFiltersOperator2;
         AV82Bancos_cuentabancoswwds_8_bandsc2 = AV62BanDsc2;
         AV83Bancos_cuentabancoswwds_9_moncod2 = AV63MonCod2;
         AV84Bancos_cuentabancoswwds_10_dynamicfiltersenabled3 = AV24DynamicFiltersEnabled3;
         AV85Bancos_cuentabancoswwds_11_dynamicfiltersselector3 = AV25DynamicFiltersSelector3;
         AV86Bancos_cuentabancoswwds_12_dynamicfiltersoperator3 = AV26DynamicFiltersOperator3;
         AV87Bancos_cuentabancoswwds_13_bandsc3 = AV64BanDsc3;
         AV88Bancos_cuentabancoswwds_14_moncod3 = AV65MonCod3;
         AV89Bancos_cuentabancoswwds_15_tfbandsc = AV66TFBanDsc;
         AV90Bancos_cuentabancoswwds_16_tfbandsc_sel = AV67TFBanDsc_Sel;
         AV91Bancos_cuentabancoswwds_17_tfcbcod = AV36TFCBCod;
         AV92Bancos_cuentabancoswwds_18_tfcbcod_sel = AV37TFCBCod_Sel;
         AV93Bancos_cuentabancoswwds_19_tfmondsc = AV68TFMonDsc;
         AV94Bancos_cuentabancoswwds_20_tfmondsc_sel = AV69TFMonDsc_Sel;
         AV95Bancos_cuentabancoswwds_21_tfcbsts = AV42TFCBSts;
         AV96Bancos_cuentabancoswwds_22_tfcbsts_to = AV43TFCBSts_To;
         /*  Sending Event outputs  */
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV10GridState", AV10GridState);
      }

      protected void E111Z2( )
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
            AV53PageToGo = (int)(NumberUtil.Val( Gridpaginationbar_Selectedpage, "."));
            subgrid_gotopage( AV53PageToGo) ;
         }
      }

      protected void E121Z2( )
      {
         /* Gridpaginationbar_Changerowsperpage Routine */
         returnInSub = false;
         subGrid_Rows = Gridpaginationbar_Rowsperpageselectedvalue;
         GxWebStd.gx_hidden_field( context, "GRID_Rows", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid_Rows), 6, 0, ".", "")));
         subgrid_firstpage( ) ;
         /*  Sending Event outputs  */
      }

      protected void E141Z2( )
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
            if ( StringUtil.StrCmp(Ddo_grid_Selectedcolumn, "BanDsc") == 0 )
            {
               AV66TFBanDsc = Ddo_grid_Filteredtext_get;
               AssignAttri("", false, "AV66TFBanDsc", AV66TFBanDsc);
               AV67TFBanDsc_Sel = Ddo_grid_Selectedvalue_get;
               AssignAttri("", false, "AV67TFBanDsc_Sel", AV67TFBanDsc_Sel);
            }
            else if ( StringUtil.StrCmp(Ddo_grid_Selectedcolumn, "CBCod") == 0 )
            {
               AV36TFCBCod = Ddo_grid_Filteredtext_get;
               AssignAttri("", false, "AV36TFCBCod", AV36TFCBCod);
               AV37TFCBCod_Sel = Ddo_grid_Selectedvalue_get;
               AssignAttri("", false, "AV37TFCBCod_Sel", AV37TFCBCod_Sel);
            }
            else if ( StringUtil.StrCmp(Ddo_grid_Selectedcolumn, "MonDsc") == 0 )
            {
               AV68TFMonDsc = Ddo_grid_Filteredtext_get;
               AssignAttri("", false, "AV68TFMonDsc", AV68TFMonDsc);
               AV69TFMonDsc_Sel = Ddo_grid_Selectedvalue_get;
               AssignAttri("", false, "AV69TFMonDsc_Sel", AV69TFMonDsc_Sel);
            }
            else if ( StringUtil.StrCmp(Ddo_grid_Selectedcolumn, "CBSts") == 0 )
            {
               AV42TFCBSts = (short)(NumberUtil.Val( Ddo_grid_Filteredtext_get, "."));
               AssignAttri("", false, "AV42TFCBSts", StringUtil.Str( (decimal)(AV42TFCBSts), 1, 0));
               AV43TFCBSts_To = (short)(NumberUtil.Val( Ddo_grid_Filteredtextto_get, "."));
               AssignAttri("", false, "AV43TFCBSts_To", StringUtil.Str( (decimal)(AV43TFCBSts_To), 1, 0));
            }
            subgrid_firstpage( ) ;
         }
         /*  Sending Event outputs  */
      }

      private void E261Z2( )
      {
         /* Grid_Load Routine */
         returnInSub = false;
         cmbavGridactions.removeAllItems();
         cmbavGridactions.addItem("0", ";fa fa-bars", 0);
         cmbavGridactions.addItem("1", StringUtil.Format( "%1;%2", "Modificar", "fa fa-pen", "", "", "", "", "", "", ""), 0);
         cmbavGridactions.addItem("2", StringUtil.Format( "%1;%2", "Eliminar", "fa fa-times", "", "", "", "", "", "", ""), 0);
         GXKey = Crypto.GetSiteKey( );
         GXEncryptionTmp = "bancos.bancos.aspx"+UrlEncode(StringUtil.RTrim("DSP")) + "," + UrlEncode(StringUtil.LTrimStr(A372BanCod,6,0));
         edtBanDsc_Link = formatLink("bancos.bancos.aspx") + "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey);
         GXKey = Crypto.GetSiteKey( );
         GXEncryptionTmp = "configuracion.monedas.aspx"+UrlEncode(StringUtil.RTrim("DSP")) + "," + UrlEncode(StringUtil.LTrimStr(A180MonCod,6,0));
         edtMonDsc_Link = formatLink("configuracion.monedas.aspx") + "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey);
         GXKey = Crypto.GetSiteKey( );
         GXEncryptionTmp = "bancos.cuentabancos.aspx"+UrlEncode(StringUtil.RTrim("DSP")) + "," + UrlEncode(StringUtil.LTrimStr(A372BanCod,6,0)) + "," + UrlEncode(StringUtil.RTrim(A377CBCod));
         edtCBSts_Link = formatLink("bancos.cuentabancos.aspx") + "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey);
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
         cmbavGridactions.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV57GridActions), 4, 0));
      }

      protected void E191Z2( )
      {
         /* 'AddDynamicFilters1' Routine */
         returnInSub = false;
         AV19DynamicFiltersEnabled2 = true;
         AssignAttri("", false, "AV19DynamicFiltersEnabled2", AV19DynamicFiltersEnabled2);
         imgAdddynamicfilters1_Visible = 0;
         AssignProp("", false, imgAdddynamicfilters1_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(imgAdddynamicfilters1_Visible), 5, 0), true);
         imgRemovedynamicfilters1_Visible = 1;
         AssignProp("", false, imgRemovedynamicfilters1_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(imgRemovedynamicfilters1_Visible), 5, 0), true);
         /*  Sending Event outputs  */
      }

      protected void E151Z2( )
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
         gxgrGrid_refresh( subGrid_Rows, AV15DynamicFiltersSelector1, AV16DynamicFiltersOperator1, AV60BanDsc1, AV61MonCod1, AV20DynamicFiltersSelector2, AV21DynamicFiltersOperator2, AV62BanDsc2, AV63MonCod2, AV25DynamicFiltersSelector3, AV26DynamicFiltersOperator3, AV64BanDsc3, AV65MonCod3, AV74Pgmname, AV19DynamicFiltersEnabled2, AV24DynamicFiltersEnabled3, AV66TFBanDsc, AV67TFBanDsc_Sel, AV36TFCBCod, AV37TFCBCod_Sel, AV68TFMonDsc, AV69TFMonDsc_Sel, AV42TFCBSts, AV43TFCBSts_To, AV13OrderedBy, AV14OrderedDsc, AV10GridState, AV30DynamicFiltersIgnoreFirst, AV29DynamicFiltersRemoving) ;
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
         dynavMoncod1.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV61MonCod1), 6, 0));
         AssignProp("", false, dynavMoncod1_Internalname, "Values", dynavMoncod1.ToJavascriptSource(), true);
         dynavMoncod2.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV63MonCod2), 6, 0));
         AssignProp("", false, dynavMoncod2_Internalname, "Values", dynavMoncod2.ToJavascriptSource(), true);
         dynavMoncod3.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV65MonCod3), 6, 0));
         AssignProp("", false, dynavMoncod3_Internalname, "Values", dynavMoncod3.ToJavascriptSource(), true);
      }

      protected void E201Z2( )
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

      protected void E211Z2( )
      {
         /* 'AddDynamicFilters2' Routine */
         returnInSub = false;
         AV24DynamicFiltersEnabled3 = true;
         AssignAttri("", false, "AV24DynamicFiltersEnabled3", AV24DynamicFiltersEnabled3);
         imgAdddynamicfilters2_Visible = 0;
         AssignProp("", false, imgAdddynamicfilters2_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(imgAdddynamicfilters2_Visible), 5, 0), true);
         imgRemovedynamicfilters2_Visible = 1;
         AssignProp("", false, imgRemovedynamicfilters2_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(imgRemovedynamicfilters2_Visible), 5, 0), true);
         /*  Sending Event outputs  */
      }

      protected void E161Z2( )
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
         gxgrGrid_refresh( subGrid_Rows, AV15DynamicFiltersSelector1, AV16DynamicFiltersOperator1, AV60BanDsc1, AV61MonCod1, AV20DynamicFiltersSelector2, AV21DynamicFiltersOperator2, AV62BanDsc2, AV63MonCod2, AV25DynamicFiltersSelector3, AV26DynamicFiltersOperator3, AV64BanDsc3, AV65MonCod3, AV74Pgmname, AV19DynamicFiltersEnabled2, AV24DynamicFiltersEnabled3, AV66TFBanDsc, AV67TFBanDsc_Sel, AV36TFCBCod, AV37TFCBCod_Sel, AV68TFMonDsc, AV69TFMonDsc_Sel, AV42TFCBSts, AV43TFCBSts_To, AV13OrderedBy, AV14OrderedDsc, AV10GridState, AV30DynamicFiltersIgnoreFirst, AV29DynamicFiltersRemoving) ;
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
         dynavMoncod1.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV61MonCod1), 6, 0));
         AssignProp("", false, dynavMoncod1_Internalname, "Values", dynavMoncod1.ToJavascriptSource(), true);
         dynavMoncod2.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV63MonCod2), 6, 0));
         AssignProp("", false, dynavMoncod2_Internalname, "Values", dynavMoncod2.ToJavascriptSource(), true);
         dynavMoncod3.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV65MonCod3), 6, 0));
         AssignProp("", false, dynavMoncod3_Internalname, "Values", dynavMoncod3.ToJavascriptSource(), true);
      }

      protected void E221Z2( )
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

      protected void E171Z2( )
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
         gxgrGrid_refresh( subGrid_Rows, AV15DynamicFiltersSelector1, AV16DynamicFiltersOperator1, AV60BanDsc1, AV61MonCod1, AV20DynamicFiltersSelector2, AV21DynamicFiltersOperator2, AV62BanDsc2, AV63MonCod2, AV25DynamicFiltersSelector3, AV26DynamicFiltersOperator3, AV64BanDsc3, AV65MonCod3, AV74Pgmname, AV19DynamicFiltersEnabled2, AV24DynamicFiltersEnabled3, AV66TFBanDsc, AV67TFBanDsc_Sel, AV36TFCBCod, AV37TFCBCod_Sel, AV68TFMonDsc, AV69TFMonDsc_Sel, AV42TFCBSts, AV43TFCBSts_To, AV13OrderedBy, AV14OrderedDsc, AV10GridState, AV30DynamicFiltersIgnoreFirst, AV29DynamicFiltersRemoving) ;
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
         dynavMoncod1.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV61MonCod1), 6, 0));
         AssignProp("", false, dynavMoncod1_Internalname, "Values", dynavMoncod1.ToJavascriptSource(), true);
         dynavMoncod2.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV63MonCod2), 6, 0));
         AssignProp("", false, dynavMoncod2_Internalname, "Values", dynavMoncod2.ToJavascriptSource(), true);
         dynavMoncod3.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV65MonCod3), 6, 0));
         AssignProp("", false, dynavMoncod3_Internalname, "Values", dynavMoncod3.ToJavascriptSource(), true);
      }

      protected void E231Z2( )
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

      protected void E271Z2( )
      {
         /* Gridactions_Click Routine */
         returnInSub = false;
         if ( AV57GridActions == 1 )
         {
            /* Execute user subroutine: 'DO UPDATE' */
            S212 ();
            if ( returnInSub )
            {
               returnInSub = true;
               if (true) return;
            }
         }
         else if ( AV57GridActions == 2 )
         {
            /* Execute user subroutine: 'DO DELETE' */
            S222 ();
            if ( returnInSub )
            {
               returnInSub = true;
               if (true) return;
            }
         }
         AV57GridActions = 0;
         AssignAttri("", false, cmbavGridactions_Internalname, StringUtil.LTrimStr( (decimal)(AV57GridActions), 4, 0));
         /*  Sending Event outputs  */
         cmbavGridactions.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV57GridActions), 4, 0));
         AssignProp("", false, cmbavGridactions_Internalname, "Values", cmbavGridactions.ToJavascriptSource(), true);
      }

      protected void E181Z2( )
      {
         /* 'DoInsert' Routine */
         returnInSub = false;
         GXKey = Crypto.GetSiteKey( );
         GXEncryptionTmp = "bancos.cuentabancos.aspx"+UrlEncode(StringUtil.RTrim("INS")) + "," + UrlEncode(StringUtil.LTrimStr(0,1,0)) + "," + UrlEncode(StringUtil.RTrim(""));
         CallWebObject(formatLink("bancos.cuentabancos.aspx") + "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey));
         context.wjLocDisableFrm = 1;
      }

      protected void E131Z2( )
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
         dynavMoncod1.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV61MonCod1), 6, 0));
         AssignProp("", false, dynavMoncod1_Internalname, "Values", dynavMoncod1.ToJavascriptSource(), true);
         cmbavDynamicfiltersselector2.CurrentValue = StringUtil.RTrim( AV20DynamicFiltersSelector2);
         AssignProp("", false, cmbavDynamicfiltersselector2_Internalname, "Values", cmbavDynamicfiltersselector2.ToJavascriptSource(), true);
         cmbavDynamicfiltersoperator2.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV21DynamicFiltersOperator2), 4, 0));
         AssignProp("", false, cmbavDynamicfiltersoperator2_Internalname, "Values", cmbavDynamicfiltersoperator2.ToJavascriptSource(), true);
         dynavMoncod2.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV63MonCod2), 6, 0));
         AssignProp("", false, dynavMoncod2_Internalname, "Values", dynavMoncod2.ToJavascriptSource(), true);
         cmbavDynamicfiltersselector3.CurrentValue = StringUtil.RTrim( AV25DynamicFiltersSelector3);
         AssignProp("", false, cmbavDynamicfiltersselector3_Internalname, "Values", cmbavDynamicfiltersselector3.ToJavascriptSource(), true);
         cmbavDynamicfiltersoperator3.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV26DynamicFiltersOperator3), 4, 0));
         AssignProp("", false, cmbavDynamicfiltersoperator3_Internalname, "Values", cmbavDynamicfiltersoperator3.ToJavascriptSource(), true);
         dynavMoncod3.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV65MonCod3), 6, 0));
         AssignProp("", false, dynavMoncod3_Internalname, "Values", dynavMoncod3.ToJavascriptSource(), true);
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
         edtavBandsc1_Visible = 0;
         AssignProp("", false, edtavBandsc1_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavBandsc1_Visible), 5, 0), true);
         dynavMoncod1.Visible = 0;
         AssignProp("", false, dynavMoncod1_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(dynavMoncod1.Visible), 5, 0), true);
         cmbavDynamicfiltersoperator1.Visible = 0;
         AssignProp("", false, cmbavDynamicfiltersoperator1_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(cmbavDynamicfiltersoperator1.Visible), 5, 0), true);
         if ( StringUtil.StrCmp(AV15DynamicFiltersSelector1, "BANDSC") == 0 )
         {
            edtavBandsc1_Visible = 1;
            AssignProp("", false, edtavBandsc1_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavBandsc1_Visible), 5, 0), true);
            cmbavDynamicfiltersoperator1.Visible = 1;
            AssignProp("", false, cmbavDynamicfiltersoperator1_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(cmbavDynamicfiltersoperator1.Visible), 5, 0), true);
         }
         else if ( StringUtil.StrCmp(AV15DynamicFiltersSelector1, "MONCOD") == 0 )
         {
            dynavMoncod1.Visible = 1;
            AssignProp("", false, dynavMoncod1_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(dynavMoncod1.Visible), 5, 0), true);
         }
      }

      protected void S122( )
      {
         /* 'ENABLEDYNAMICFILTERS2' Routine */
         returnInSub = false;
         edtavBandsc2_Visible = 0;
         AssignProp("", false, edtavBandsc2_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavBandsc2_Visible), 5, 0), true);
         dynavMoncod2.Visible = 0;
         AssignProp("", false, dynavMoncod2_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(dynavMoncod2.Visible), 5, 0), true);
         cmbavDynamicfiltersoperator2.Visible = 0;
         AssignProp("", false, cmbavDynamicfiltersoperator2_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(cmbavDynamicfiltersoperator2.Visible), 5, 0), true);
         if ( StringUtil.StrCmp(AV20DynamicFiltersSelector2, "BANDSC") == 0 )
         {
            edtavBandsc2_Visible = 1;
            AssignProp("", false, edtavBandsc2_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavBandsc2_Visible), 5, 0), true);
            cmbavDynamicfiltersoperator2.Visible = 1;
            AssignProp("", false, cmbavDynamicfiltersoperator2_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(cmbavDynamicfiltersoperator2.Visible), 5, 0), true);
         }
         else if ( StringUtil.StrCmp(AV20DynamicFiltersSelector2, "MONCOD") == 0 )
         {
            dynavMoncod2.Visible = 1;
            AssignProp("", false, dynavMoncod2_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(dynavMoncod2.Visible), 5, 0), true);
         }
      }

      protected void S132( )
      {
         /* 'ENABLEDYNAMICFILTERS3' Routine */
         returnInSub = false;
         edtavBandsc3_Visible = 0;
         AssignProp("", false, edtavBandsc3_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavBandsc3_Visible), 5, 0), true);
         dynavMoncod3.Visible = 0;
         AssignProp("", false, dynavMoncod3_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(dynavMoncod3.Visible), 5, 0), true);
         cmbavDynamicfiltersoperator3.Visible = 0;
         AssignProp("", false, cmbavDynamicfiltersoperator3_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(cmbavDynamicfiltersoperator3.Visible), 5, 0), true);
         if ( StringUtil.StrCmp(AV25DynamicFiltersSelector3, "BANDSC") == 0 )
         {
            edtavBandsc3_Visible = 1;
            AssignProp("", false, edtavBandsc3_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavBandsc3_Visible), 5, 0), true);
            cmbavDynamicfiltersoperator3.Visible = 1;
            AssignProp("", false, cmbavDynamicfiltersoperator3_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(cmbavDynamicfiltersoperator3.Visible), 5, 0), true);
         }
         else if ( StringUtil.StrCmp(AV25DynamicFiltersSelector3, "MONCOD") == 0 )
         {
            dynavMoncod3.Visible = 1;
            AssignProp("", false, dynavMoncod3_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(dynavMoncod3.Visible), 5, 0), true);
         }
      }

      protected void S192( )
      {
         /* 'RESETDYNFILTERS' Routine */
         returnInSub = false;
         AV19DynamicFiltersEnabled2 = false;
         AssignAttri("", false, "AV19DynamicFiltersEnabled2", AV19DynamicFiltersEnabled2);
         AV20DynamicFiltersSelector2 = "BANDSC";
         AssignAttri("", false, "AV20DynamicFiltersSelector2", AV20DynamicFiltersSelector2);
         AV21DynamicFiltersOperator2 = 0;
         AssignAttri("", false, "AV21DynamicFiltersOperator2", StringUtil.LTrimStr( (decimal)(AV21DynamicFiltersOperator2), 4, 0));
         AV62BanDsc2 = "";
         AssignAttri("", false, "AV62BanDsc2", AV62BanDsc2);
         /* Execute user subroutine: 'ENABLEDYNAMICFILTERS2' */
         S122 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
         AV24DynamicFiltersEnabled3 = false;
         AssignAttri("", false, "AV24DynamicFiltersEnabled3", AV24DynamicFiltersEnabled3);
         AV25DynamicFiltersSelector3 = "BANDSC";
         AssignAttri("", false, "AV25DynamicFiltersSelector3", AV25DynamicFiltersSelector3);
         AV26DynamicFiltersOperator3 = 0;
         AssignAttri("", false, "AV26DynamicFiltersOperator3", StringUtil.LTrimStr( (decimal)(AV26DynamicFiltersOperator3), 4, 0));
         AV64BanDsc3 = "";
         AssignAttri("", false, "AV64BanDsc3", AV64BanDsc3);
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
         GXEncryptionTmp = "bancos.cuentabancos.aspx"+UrlEncode(StringUtil.RTrim("UPD")) + "," + UrlEncode(StringUtil.LTrimStr(A372BanCod,6,0)) + "," + UrlEncode(StringUtil.RTrim(A377CBCod));
         CallWebObject(formatLink("bancos.cuentabancos.aspx") + "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey));
         context.wjLocDisableFrm = 1;
      }

      protected void S222( )
      {
         /* 'DO DELETE' Routine */
         returnInSub = false;
         GXKey = Crypto.GetSiteKey( );
         GXEncryptionTmp = "bancos.cuentabancos.aspx"+UrlEncode(StringUtil.RTrim("DLT")) + "," + UrlEncode(StringUtil.LTrimStr(A372BanCod,6,0)) + "," + UrlEncode(StringUtil.RTrim(A377CBCod));
         CallWebObject(formatLink("bancos.cuentabancos.aspx") + "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey));
         context.wjLocDisableFrm = 1;
      }

      protected void S152( )
      {
         /* 'LOADGRIDSTATE' Routine */
         returnInSub = false;
         if ( StringUtil.StrCmp(AV33Session.Get(AV74Pgmname+"GridState"), "") == 0 )
         {
            AV10GridState.FromXml(new GeneXus.Programs.wwpbaseobjects.loadgridstate(context).executeUdp(  AV74Pgmname+"GridState"), null, "", "");
         }
         else
         {
            AV10GridState.FromXml(AV33Session.Get(AV74Pgmname+"GridState"), null, "", "");
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
         AV97GXV1 = 1;
         while ( AV97GXV1 <= AV10GridState.gxTpr_Filtervalues.Count )
         {
            AV11GridStateFilterValue = ((GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue)AV10GridState.gxTpr_Filtervalues.Item(AV97GXV1));
            if ( StringUtil.StrCmp(AV11GridStateFilterValue.gxTpr_Name, "TFBANDSC") == 0 )
            {
               AV66TFBanDsc = AV11GridStateFilterValue.gxTpr_Value;
               AssignAttri("", false, "AV66TFBanDsc", AV66TFBanDsc);
            }
            else if ( StringUtil.StrCmp(AV11GridStateFilterValue.gxTpr_Name, "TFBANDSC_SEL") == 0 )
            {
               AV67TFBanDsc_Sel = AV11GridStateFilterValue.gxTpr_Value;
               AssignAttri("", false, "AV67TFBanDsc_Sel", AV67TFBanDsc_Sel);
            }
            else if ( StringUtil.StrCmp(AV11GridStateFilterValue.gxTpr_Name, "TFCBCOD") == 0 )
            {
               AV36TFCBCod = AV11GridStateFilterValue.gxTpr_Value;
               AssignAttri("", false, "AV36TFCBCod", AV36TFCBCod);
            }
            else if ( StringUtil.StrCmp(AV11GridStateFilterValue.gxTpr_Name, "TFCBCOD_SEL") == 0 )
            {
               AV37TFCBCod_Sel = AV11GridStateFilterValue.gxTpr_Value;
               AssignAttri("", false, "AV37TFCBCod_Sel", AV37TFCBCod_Sel);
            }
            else if ( StringUtil.StrCmp(AV11GridStateFilterValue.gxTpr_Name, "TFMONDSC") == 0 )
            {
               AV68TFMonDsc = AV11GridStateFilterValue.gxTpr_Value;
               AssignAttri("", false, "AV68TFMonDsc", AV68TFMonDsc);
            }
            else if ( StringUtil.StrCmp(AV11GridStateFilterValue.gxTpr_Name, "TFMONDSC_SEL") == 0 )
            {
               AV69TFMonDsc_Sel = AV11GridStateFilterValue.gxTpr_Value;
               AssignAttri("", false, "AV69TFMonDsc_Sel", AV69TFMonDsc_Sel);
            }
            else if ( StringUtil.StrCmp(AV11GridStateFilterValue.gxTpr_Name, "TFCBSTS") == 0 )
            {
               AV42TFCBSts = (short)(NumberUtil.Val( AV11GridStateFilterValue.gxTpr_Value, "."));
               AssignAttri("", false, "AV42TFCBSts", StringUtil.Str( (decimal)(AV42TFCBSts), 1, 0));
               AV43TFCBSts_To = (short)(NumberUtil.Val( AV11GridStateFilterValue.gxTpr_Valueto, "."));
               AssignAttri("", false, "AV43TFCBSts_To", StringUtil.Str( (decimal)(AV43TFCBSts_To), 1, 0));
            }
            AV97GXV1 = (int)(AV97GXV1+1);
         }
         GXt_char2 = "";
         new GeneXus.Programs.wwpbaseobjects.wwp_getfilterval(context ).execute(  String.IsNullOrEmpty(StringUtil.RTrim( AV67TFBanDsc_Sel)),  AV67TFBanDsc_Sel, out  GXt_char2) ;
         GXt_char3 = "";
         new GeneXus.Programs.wwpbaseobjects.wwp_getfilterval(context ).execute(  String.IsNullOrEmpty(StringUtil.RTrim( AV37TFCBCod_Sel)),  AV37TFCBCod_Sel, out  GXt_char3) ;
         GXt_char4 = "";
         new GeneXus.Programs.wwpbaseobjects.wwp_getfilterval(context ).execute(  String.IsNullOrEmpty(StringUtil.RTrim( AV69TFMonDsc_Sel)),  AV69TFMonDsc_Sel, out  GXt_char4) ;
         Ddo_grid_Selectedvalue_set = GXt_char2+"|"+GXt_char3+"|"+GXt_char4+"|";
         ucDdo_grid.SendProperty(context, "", false, Ddo_grid_Internalname, "SelectedValue_set", Ddo_grid_Selectedvalue_set);
         GXt_char4 = "";
         new GeneXus.Programs.wwpbaseobjects.wwp_getfilterval(context ).execute(  String.IsNullOrEmpty(StringUtil.RTrim( AV66TFBanDsc)),  AV66TFBanDsc, out  GXt_char4) ;
         GXt_char3 = "";
         new GeneXus.Programs.wwpbaseobjects.wwp_getfilterval(context ).execute(  String.IsNullOrEmpty(StringUtil.RTrim( AV36TFCBCod)),  AV36TFCBCod, out  GXt_char3) ;
         GXt_char2 = "";
         new GeneXus.Programs.wwpbaseobjects.wwp_getfilterval(context ).execute(  String.IsNullOrEmpty(StringUtil.RTrim( AV68TFMonDsc)),  AV68TFMonDsc, out  GXt_char2) ;
         Ddo_grid_Filteredtext_set = GXt_char4+"|"+GXt_char3+"|"+GXt_char2+"|"+((0==AV42TFCBSts) ? "" : StringUtil.Str( (decimal)(AV42TFCBSts), 1, 0));
         ucDdo_grid.SendProperty(context, "", false, Ddo_grid_Internalname, "FilteredText_set", Ddo_grid_Filteredtext_set);
         Ddo_grid_Filteredtextto_set = "|||"+((0==AV43TFCBSts_To) ? "" : StringUtil.Str( (decimal)(AV43TFCBSts_To), 1, 0));
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
            if ( StringUtil.StrCmp(AV15DynamicFiltersSelector1, "BANDSC") == 0 )
            {
               AV16DynamicFiltersOperator1 = AV12GridStateDynamicFilter.gxTpr_Operator;
               AssignAttri("", false, "AV16DynamicFiltersOperator1", StringUtil.LTrimStr( (decimal)(AV16DynamicFiltersOperator1), 4, 0));
               AV60BanDsc1 = AV12GridStateDynamicFilter.gxTpr_Value;
               AssignAttri("", false, "AV60BanDsc1", AV60BanDsc1);
            }
            else if ( StringUtil.StrCmp(AV15DynamicFiltersSelector1, "MONCOD") == 0 )
            {
               AV61MonCod1 = (int)(NumberUtil.Val( AV12GridStateDynamicFilter.gxTpr_Value, "."));
               AssignAttri("", false, "AV61MonCod1", StringUtil.LTrimStr( (decimal)(AV61MonCod1), 6, 0));
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
               if ( StringUtil.StrCmp(AV20DynamicFiltersSelector2, "BANDSC") == 0 )
               {
                  AV21DynamicFiltersOperator2 = AV12GridStateDynamicFilter.gxTpr_Operator;
                  AssignAttri("", false, "AV21DynamicFiltersOperator2", StringUtil.LTrimStr( (decimal)(AV21DynamicFiltersOperator2), 4, 0));
                  AV62BanDsc2 = AV12GridStateDynamicFilter.gxTpr_Value;
                  AssignAttri("", false, "AV62BanDsc2", AV62BanDsc2);
               }
               else if ( StringUtil.StrCmp(AV20DynamicFiltersSelector2, "MONCOD") == 0 )
               {
                  AV63MonCod2 = (int)(NumberUtil.Val( AV12GridStateDynamicFilter.gxTpr_Value, "."));
                  AssignAttri("", false, "AV63MonCod2", StringUtil.LTrimStr( (decimal)(AV63MonCod2), 6, 0));
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
                  if ( StringUtil.StrCmp(AV25DynamicFiltersSelector3, "BANDSC") == 0 )
                  {
                     AV26DynamicFiltersOperator3 = AV12GridStateDynamicFilter.gxTpr_Operator;
                     AssignAttri("", false, "AV26DynamicFiltersOperator3", StringUtil.LTrimStr( (decimal)(AV26DynamicFiltersOperator3), 4, 0));
                     AV64BanDsc3 = AV12GridStateDynamicFilter.gxTpr_Value;
                     AssignAttri("", false, "AV64BanDsc3", AV64BanDsc3);
                  }
                  else if ( StringUtil.StrCmp(AV25DynamicFiltersSelector3, "MONCOD") == 0 )
                  {
                     AV65MonCod3 = (int)(NumberUtil.Val( AV12GridStateDynamicFilter.gxTpr_Value, "."));
                     AssignAttri("", false, "AV65MonCod3", StringUtil.LTrimStr( (decimal)(AV65MonCod3), 6, 0));
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
         AV10GridState.FromXml(AV33Session.Get(AV74Pgmname+"GridState"), null, "", "");
         AV10GridState.gxTpr_Orderedby = AV13OrderedBy;
         AV10GridState.gxTpr_Ordereddsc = AV14OrderedDsc;
         AV10GridState.gxTpr_Filtervalues.Clear();
         new GeneXus.Programs.wwpbaseobjects.wwp_gridstateaddfiltervalueandsel(context ).execute( ref  AV10GridState,  "TFBANDSC",  "Banco",  !String.IsNullOrEmpty(StringUtil.RTrim( AV66TFBanDsc)),  0,  AV66TFBanDsc,  "",  !String.IsNullOrEmpty(StringUtil.RTrim( AV67TFBanDsc_Sel)),  AV67TFBanDsc_Sel,  "") ;
         new GeneXus.Programs.wwpbaseobjects.wwp_gridstateaddfiltervalueandsel(context ).execute( ref  AV10GridState,  "TFCBCOD",  "N° de Cuenta",  !String.IsNullOrEmpty(StringUtil.RTrim( AV36TFCBCod)),  0,  AV36TFCBCod,  "",  !String.IsNullOrEmpty(StringUtil.RTrim( AV37TFCBCod_Sel)),  AV37TFCBCod_Sel,  "") ;
         new GeneXus.Programs.wwpbaseobjects.wwp_gridstateaddfiltervalueandsel(context ).execute( ref  AV10GridState,  "TFMONDSC",  "Moneda",  !String.IsNullOrEmpty(StringUtil.RTrim( AV68TFMonDsc)),  0,  AV68TFMonDsc,  "",  !String.IsNullOrEmpty(StringUtil.RTrim( AV69TFMonDsc_Sel)),  AV69TFMonDsc_Sel,  "") ;
         new GeneXus.Programs.wwpbaseobjects.wwp_gridstateaddfiltervalue(context ).execute( ref  AV10GridState,  "TFCBSTS",  "Estado",  !((0==AV42TFCBSts)&&(0==AV43TFCBSts_To)),  0,  StringUtil.Trim( StringUtil.Str( (decimal)(AV42TFCBSts), 1, 0)),  StringUtil.Trim( StringUtil.Str( (decimal)(AV43TFCBSts_To), 1, 0))) ;
         /* Execute user subroutine: 'SAVEDYNFILTERSSTATE' */
         S182 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
         AV10GridState.gxTpr_Pagesize = StringUtil.Str( (decimal)(subGrid_Rows), 10, 0);
         AV10GridState.gxTpr_Currentpage = (short)(subGrid_fnc_Currentpage( ));
         new GeneXus.Programs.wwpbaseobjects.savegridstate(context ).execute(  AV74Pgmname+"GridState",  AV10GridState.ToXml(false, true, "", "")) ;
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
            if ( ( StringUtil.StrCmp(AV15DynamicFiltersSelector1, "BANDSC") == 0 ) && ! String.IsNullOrEmpty(StringUtil.RTrim( AV60BanDsc1)) )
            {
               AV12GridStateDynamicFilter.gxTpr_Dsc = "Banco";
               AV12GridStateDynamicFilter.gxTpr_Value = AV60BanDsc1;
               AV12GridStateDynamicFilter.gxTpr_Operator = AV16DynamicFiltersOperator1;
            }
            else if ( ( StringUtil.StrCmp(AV15DynamicFiltersSelector1, "MONCOD") == 0 ) && ! (0==AV61MonCod1) )
            {
               AV12GridStateDynamicFilter.gxTpr_Dsc = "Moneda";
               AV12GridStateDynamicFilter.gxTpr_Value = StringUtil.Str( (decimal)(AV61MonCod1), 6, 0);
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
            if ( ( StringUtil.StrCmp(AV20DynamicFiltersSelector2, "BANDSC") == 0 ) && ! String.IsNullOrEmpty(StringUtil.RTrim( AV62BanDsc2)) )
            {
               AV12GridStateDynamicFilter.gxTpr_Dsc = "Banco";
               AV12GridStateDynamicFilter.gxTpr_Value = AV62BanDsc2;
               AV12GridStateDynamicFilter.gxTpr_Operator = AV21DynamicFiltersOperator2;
            }
            else if ( ( StringUtil.StrCmp(AV20DynamicFiltersSelector2, "MONCOD") == 0 ) && ! (0==AV63MonCod2) )
            {
               AV12GridStateDynamicFilter.gxTpr_Dsc = "Moneda";
               AV12GridStateDynamicFilter.gxTpr_Value = StringUtil.Str( (decimal)(AV63MonCod2), 6, 0);
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
            if ( ( StringUtil.StrCmp(AV25DynamicFiltersSelector3, "BANDSC") == 0 ) && ! String.IsNullOrEmpty(StringUtil.RTrim( AV64BanDsc3)) )
            {
               AV12GridStateDynamicFilter.gxTpr_Dsc = "Banco";
               AV12GridStateDynamicFilter.gxTpr_Value = AV64BanDsc3;
               AV12GridStateDynamicFilter.gxTpr_Operator = AV26DynamicFiltersOperator3;
            }
            else if ( ( StringUtil.StrCmp(AV25DynamicFiltersSelector3, "MONCOD") == 0 ) && ! (0==AV65MonCod3) )
            {
               AV12GridStateDynamicFilter.gxTpr_Dsc = "Moneda";
               AV12GridStateDynamicFilter.gxTpr_Value = StringUtil.Str( (decimal)(AV65MonCod3), 6, 0);
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
         AV8TrnContext.gxTpr_Callerobject = AV74Pgmname;
         AV8TrnContext.gxTpr_Callerondelete = true;
         AV8TrnContext.gxTpr_Callerurl = AV7HTTPRequest.ScriptName+"?"+AV7HTTPRequest.QueryString;
         AV8TrnContext.gxTpr_Transactionname = "Bancos.CuentaBancos";
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
         new GeneXus.Programs.bancos.cuentabancoswwexport(context ).execute( out  AV31ExcelFilename, out  AV32ErrorMessage) ;
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
         Innewwindow1_Target = formatLink("bancos.cuentabancoswwexportreport.aspx") ;
         ucInnewwindow1.SendProperty(context, "", false, Innewwindow1_Internalname, "Target", Innewwindow1_Target);
         Innewwindow1_Height = "600";
         ucInnewwindow1.SendProperty(context, "", false, Innewwindow1_Internalname, "Height", Innewwindow1_Height);
         Innewwindow1_Width = "800";
         ucInnewwindow1.SendProperty(context, "", false, Innewwindow1_Internalname, "Width", Innewwindow1_Width);
         this.executeUsercontrolMethod("", false, "INNEWWINDOW1Container", "OpenWindow", "", new Object[] {});
      }

      protected void wb_table1_25_1Z2( bool wbgen )
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
            GxWebStd.gx_label_ctrl( context, lblDynamicfiltersprefix1_Internalname, "Buscar en", "", "", lblDynamicfiltersprefix1_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "DataFilterDescriptionPrefix", 0, "", 1, 1, 0, 0, "HLP_Bancos\\CuentaBancosWW.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "", "left", "top", "", "flex-grow:1;", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "left", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, cmbavDynamicfiltersselector1_Internalname, "Dynamic Filters Selector1", "gx-form-item AttributeLabel", 0, true, "width: 25%;");
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 35,'',false,'" + sGXsfl_110_idx + "',0)\"";
            /* ComboBox */
            GxWebStd.gx_combobox_ctrl1( context, cmbavDynamicfiltersselector1, cmbavDynamicfiltersselector1_Internalname, StringUtil.RTrim( AV15DynamicFiltersSelector1), 1, cmbavDynamicfiltersselector1_Jsonclick, 5, "'"+""+"'"+",false,"+"'"+"EVDYNAMICFILTERSSELECTOR1.CLICK."+"'", "svchar", "", 1, cmbavDynamicfiltersselector1.Enabled, 0, 0, 0, "em", 0, "", "", "Attribute", "", "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,35);\"", "", true, 1, "HLP_Bancos\\CuentaBancosWW.htm");
            cmbavDynamicfiltersselector1.CurrentValue = StringUtil.RTrim( AV15DynamicFiltersSelector1);
            AssignProp("", false, cmbavDynamicfiltersselector1_Internalname, "Values", (string)(cmbavDynamicfiltersselector1.ToJavascriptSource()), true);
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "", "left", "top", "", "flex-grow:1;", "div");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblDynamicfiltersmiddle1_Internalname, "valor", "", "", lblDynamicfiltersmiddle1_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "DataFilterDescription", 0, "", 1, 1, 0, 0, "HLP_Bancos\\CuentaBancosWW.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "", "left", "top", "", "flex-grow:1;", "div");
            wb_table2_39_1Z2( true) ;
         }
         else
         {
            wb_table2_39_1Z2( false) ;
         }
         return  ;
      }

      protected void wb_table2_39_1Z2e( bool wbgen )
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
            GxWebStd.gx_label_ctrl( context, lblDynamicfiltersprefix2_Internalname, "Buscar en", "", "", lblDynamicfiltersprefix2_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "DataFilterDescriptionPrefix", 0, "", 1, 1, 0, 0, "HLP_Bancos\\CuentaBancosWW.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "Invisible", "left", "top", "", "flex-grow:1;", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "left", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, cmbavDynamicfiltersselector2_Internalname, "Dynamic Filters Selector2", "gx-form-item AttributeLabel", 0, true, "width: 25%;");
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 60,'',false,'" + sGXsfl_110_idx + "',0)\"";
            /* ComboBox */
            GxWebStd.gx_combobox_ctrl1( context, cmbavDynamicfiltersselector2, cmbavDynamicfiltersselector2_Internalname, StringUtil.RTrim( AV20DynamicFiltersSelector2), 1, cmbavDynamicfiltersselector2_Jsonclick, 5, "'"+""+"'"+",false,"+"'"+"EVDYNAMICFILTERSSELECTOR2.CLICK."+"'", "svchar", "", 1, cmbavDynamicfiltersselector2.Enabled, 0, 0, 0, "em", 0, "", "", "Attribute", "", "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,60);\"", "", true, 1, "HLP_Bancos\\CuentaBancosWW.htm");
            cmbavDynamicfiltersselector2.CurrentValue = StringUtil.RTrim( AV20DynamicFiltersSelector2);
            AssignProp("", false, cmbavDynamicfiltersselector2_Internalname, "Values", (string)(cmbavDynamicfiltersselector2.ToJavascriptSource()), true);
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "Invisible", "left", "top", "", "flex-grow:1;", "div");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblDynamicfiltersmiddle2_Internalname, "valor", "", "", lblDynamicfiltersmiddle2_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "DataFilterDescription", 0, "", 1, 1, 0, 0, "HLP_Bancos\\CuentaBancosWW.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "Invisible", "left", "top", "", "flex-grow:1;", "div");
            wb_table3_64_1Z2( true) ;
         }
         else
         {
            wb_table3_64_1Z2( false) ;
         }
         return  ;
      }

      protected void wb_table3_64_1Z2e( bool wbgen )
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
            GxWebStd.gx_label_ctrl( context, lblDynamicfiltersprefix3_Internalname, "Buscar en", "", "", lblDynamicfiltersprefix3_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "DataFilterDescriptionPrefix", 0, "", 1, 1, 0, 0, "HLP_Bancos\\CuentaBancosWW.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "Invisible", "left", "top", "", "flex-grow:1;", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "left", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, cmbavDynamicfiltersselector3_Internalname, "Dynamic Filters Selector3", "gx-form-item AttributeLabel", 0, true, "width: 25%;");
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 85,'',false,'" + sGXsfl_110_idx + "',0)\"";
            /* ComboBox */
            GxWebStd.gx_combobox_ctrl1( context, cmbavDynamicfiltersselector3, cmbavDynamicfiltersselector3_Internalname, StringUtil.RTrim( AV25DynamicFiltersSelector3), 1, cmbavDynamicfiltersselector3_Jsonclick, 5, "'"+""+"'"+",false,"+"'"+"EVDYNAMICFILTERSSELECTOR3.CLICK."+"'", "svchar", "", 1, cmbavDynamicfiltersselector3.Enabled, 0, 0, 0, "em", 0, "", "", "Attribute", "", "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,85);\"", "", true, 1, "HLP_Bancos\\CuentaBancosWW.htm");
            cmbavDynamicfiltersselector3.CurrentValue = StringUtil.RTrim( AV25DynamicFiltersSelector3);
            AssignProp("", false, cmbavDynamicfiltersselector3_Internalname, "Values", (string)(cmbavDynamicfiltersselector3.ToJavascriptSource()), true);
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "Invisible", "left", "top", "", "flex-grow:1;", "div");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblDynamicfiltersmiddle3_Internalname, "valor", "", "", lblDynamicfiltersmiddle3_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "DataFilterDescription", 0, "", 1, 1, 0, 0, "HLP_Bancos\\CuentaBancosWW.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "Invisible", "left", "top", "", "flex-grow:1;", "div");
            wb_table4_89_1Z2( true) ;
         }
         else
         {
            wb_table4_89_1Z2( false) ;
         }
         return  ;
      }

      protected void wb_table4_89_1Z2e( bool wbgen )
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
            wb_table1_25_1Z2e( true) ;
         }
         else
         {
            wb_table1_25_1Z2e( false) ;
         }
      }

      protected void wb_table4_89_1Z2( bool wbgen )
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
            GxWebStd.gx_combobox_ctrl1( context, cmbavDynamicfiltersoperator3, cmbavDynamicfiltersoperator3_Internalname, StringUtil.Trim( StringUtil.Str( (decimal)(AV26DynamicFiltersOperator3), 4, 0)), 1, cmbavDynamicfiltersoperator3_Jsonclick, 0, "'"+""+"'"+",false,"+"'"+""+"'", "int", "", cmbavDynamicfiltersoperator3.Visible, cmbavDynamicfiltersoperator3.Enabled, 0, 0, 0, "em", 0, "", "", "Attribute", "", "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,93);\"", "", true, 1, "HLP_Bancos\\CuentaBancosWW.htm");
            cmbavDynamicfiltersoperator3.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV26DynamicFiltersOperator3), 4, 0));
            AssignProp("", false, cmbavDynamicfiltersoperator3_Internalname, "Values", (string)(cmbavDynamicfiltersoperator3.ToJavascriptSource()), true);
            GxWebStd.gx_div_end( context, "left", "top", "div");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "<td id=\""+cellFilter_bandsc3_cell_Internalname+"\"  class=''>") ;
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "left", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavBandsc3_Internalname, "Ban Dsc3", "gx-form-item AttributeLabel", 0, true, "width: 25%;");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 96,'',false,'" + sGXsfl_110_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavBandsc3_Internalname, StringUtil.RTrim( AV64BanDsc3), StringUtil.RTrim( context.localUtil.Format( AV64BanDsc3, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,96);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavBandsc3_Jsonclick, 0, "Attribute", "", "", "", "", edtavBandsc3_Visible, edtavBandsc3_Enabled, 0, "text", "", 80, "chr", 1, "row", 100, 0, 0, 0, 1, -1, -1, true, "", "left", true, "", "HLP_Bancos\\CuentaBancosWW.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "<td id=\""+cellFilter_moncod3_cell_Internalname+"\"  class=''>") ;
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "left", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, dynavMoncod3_Internalname, "Mon Cod3", "gx-form-item AttributeLabel", 0, true, "width: 25%;");
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 99,'',false,'" + sGXsfl_110_idx + "',0)\"";
            /* ComboBox */
            GxWebStd.gx_combobox_ctrl1( context, dynavMoncod3, dynavMoncod3_Internalname, StringUtil.Trim( StringUtil.Str( (decimal)(AV65MonCod3), 6, 0)), 1, dynavMoncod3_Jsonclick, 0, "'"+""+"'"+",false,"+"'"+""+"'", "int", "", dynavMoncod3.Visible, dynavMoncod3.Enabled, 0, 0, 0, "em", 0, "", "", "Attribute", "", "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,99);\"", "", true, 1, "HLP_Bancos\\CuentaBancosWW.htm");
            dynavMoncod3.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV65MonCod3), 6, 0));
            AssignProp("", false, dynavMoncod3_Internalname, "Values", (string)(dynavMoncod3.ToJavascriptSource()), true);
            GxWebStd.gx_div_end( context, "left", "top", "div");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "<td id=\""+cellDynamicfilters_removefilter3_cell_Internalname+"\"  class=''>") ;
            /* Active images/pictures */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 101,'',false,'',0)\"";
            ClassString = "Image";
            StyleString = "";
            sImgUrl = (string)(context.GetImagePath( "11a6ef14-1a5a-4077-91a2-f41ed9a3a662", "", context.GetTheme( )));
            GxWebStd.gx_bitmap( context, imgRemovedynamicfilters3_Internalname, sImgUrl, "", "", "", context.GetTheme( ), 1, 1, "", "Quitar filtro", 0, 0, 0, "px", 0, "px", 0, 0, 5, imgRemovedynamicfilters3_Jsonclick, "'"+""+"'"+",false,"+"'"+"E\\'REMOVEDYNAMICFILTERS3\\'."+"'", StyleString, ClassString, "", "", "", "", " "+"data-gx-image"+" "+TempTags, "", "", 1, false, false, context.GetImageSrcSet( sImgUrl), "HLP_Bancos\\CuentaBancosWW.htm");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "</tr>") ;
            /* End of table */
            context.WriteHtmlText( "</table>") ;
            wb_table4_89_1Z2e( true) ;
         }
         else
         {
            wb_table4_89_1Z2e( false) ;
         }
      }

      protected void wb_table3_64_1Z2( bool wbgen )
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
            GxWebStd.gx_combobox_ctrl1( context, cmbavDynamicfiltersoperator2, cmbavDynamicfiltersoperator2_Internalname, StringUtil.Trim( StringUtil.Str( (decimal)(AV21DynamicFiltersOperator2), 4, 0)), 1, cmbavDynamicfiltersoperator2_Jsonclick, 0, "'"+""+"'"+",false,"+"'"+""+"'", "int", "", cmbavDynamicfiltersoperator2.Visible, cmbavDynamicfiltersoperator2.Enabled, 0, 0, 0, "em", 0, "", "", "Attribute", "", "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,68);\"", "", true, 1, "HLP_Bancos\\CuentaBancosWW.htm");
            cmbavDynamicfiltersoperator2.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV21DynamicFiltersOperator2), 4, 0));
            AssignProp("", false, cmbavDynamicfiltersoperator2_Internalname, "Values", (string)(cmbavDynamicfiltersoperator2.ToJavascriptSource()), true);
            GxWebStd.gx_div_end( context, "left", "top", "div");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "<td id=\""+cellFilter_bandsc2_cell_Internalname+"\"  class=''>") ;
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "left", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavBandsc2_Internalname, "Ban Dsc2", "gx-form-item AttributeLabel", 0, true, "width: 25%;");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 71,'',false,'" + sGXsfl_110_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavBandsc2_Internalname, StringUtil.RTrim( AV62BanDsc2), StringUtil.RTrim( context.localUtil.Format( AV62BanDsc2, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,71);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavBandsc2_Jsonclick, 0, "Attribute", "", "", "", "", edtavBandsc2_Visible, edtavBandsc2_Enabled, 0, "text", "", 80, "chr", 1, "row", 100, 0, 0, 0, 1, -1, -1, true, "", "left", true, "", "HLP_Bancos\\CuentaBancosWW.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "<td id=\""+cellFilter_moncod2_cell_Internalname+"\"  class=''>") ;
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "left", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, dynavMoncod2_Internalname, "Mon Cod2", "gx-form-item AttributeLabel", 0, true, "width: 25%;");
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 74,'',false,'" + sGXsfl_110_idx + "',0)\"";
            /* ComboBox */
            GxWebStd.gx_combobox_ctrl1( context, dynavMoncod2, dynavMoncod2_Internalname, StringUtil.Trim( StringUtil.Str( (decimal)(AV63MonCod2), 6, 0)), 1, dynavMoncod2_Jsonclick, 0, "'"+""+"'"+",false,"+"'"+""+"'", "int", "", dynavMoncod2.Visible, dynavMoncod2.Enabled, 0, 0, 0, "em", 0, "", "", "Attribute", "", "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,74);\"", "", true, 1, "HLP_Bancos\\CuentaBancosWW.htm");
            dynavMoncod2.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV63MonCod2), 6, 0));
            AssignProp("", false, dynavMoncod2_Internalname, "Values", (string)(dynavMoncod2.ToJavascriptSource()), true);
            GxWebStd.gx_div_end( context, "left", "top", "div");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "<td id=\""+cellDynamicfilters_addfilter2_cell_Internalname+"\"  class=''>") ;
            /* Active images/pictures */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 76,'',false,'',0)\"";
            ClassString = "Image";
            StyleString = "";
            sImgUrl = (string)(context.GetImagePath( "27283ea5-332f-423b-b880-64b762622df3", "", context.GetTheme( )));
            GxWebStd.gx_bitmap( context, imgAdddynamicfilters2_Internalname, sImgUrl, "", "", "", context.GetTheme( ), imgAdddynamicfilters2_Visible, 1, "", "Agregar filtro", 0, 0, 0, "px", 0, "px", 0, 0, 5, imgAdddynamicfilters2_Jsonclick, "'"+""+"'"+",false,"+"'"+"E\\'ADDDYNAMICFILTERS2\\'."+"'", StyleString, ClassString, "", "", "", "", " "+"data-gx-image"+" "+TempTags, "", "", 1, false, false, context.GetImageSrcSet( sImgUrl), "HLP_Bancos\\CuentaBancosWW.htm");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "<td id=\""+cellDynamicfilters_removefilter2_cell_Internalname+"\"  class=''>") ;
            /* Active images/pictures */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 78,'',false,'',0)\"";
            ClassString = "Image";
            StyleString = "";
            sImgUrl = (string)(context.GetImagePath( "11a6ef14-1a5a-4077-91a2-f41ed9a3a662", "", context.GetTheme( )));
            GxWebStd.gx_bitmap( context, imgRemovedynamicfilters2_Internalname, sImgUrl, "", "", "", context.GetTheme( ), imgRemovedynamicfilters2_Visible, 1, "", "Quitar filtro", 0, 0, 0, "px", 0, "px", 0, 0, 5, imgRemovedynamicfilters2_Jsonclick, "'"+""+"'"+",false,"+"'"+"E\\'REMOVEDYNAMICFILTERS2\\'."+"'", StyleString, ClassString, "", "", "", "", " "+"data-gx-image"+" "+TempTags, "", "", 1, false, false, context.GetImageSrcSet( sImgUrl), "HLP_Bancos\\CuentaBancosWW.htm");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "</tr>") ;
            /* End of table */
            context.WriteHtmlText( "</table>") ;
            wb_table3_64_1Z2e( true) ;
         }
         else
         {
            wb_table3_64_1Z2e( false) ;
         }
      }

      protected void wb_table2_39_1Z2( bool wbgen )
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
            GxWebStd.gx_combobox_ctrl1( context, cmbavDynamicfiltersoperator1, cmbavDynamicfiltersoperator1_Internalname, StringUtil.Trim( StringUtil.Str( (decimal)(AV16DynamicFiltersOperator1), 4, 0)), 1, cmbavDynamicfiltersoperator1_Jsonclick, 0, "'"+""+"'"+",false,"+"'"+""+"'", "int", "", cmbavDynamicfiltersoperator1.Visible, cmbavDynamicfiltersoperator1.Enabled, 0, 0, 0, "em", 0, "", "", "Attribute", "", "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,43);\"", "", true, 1, "HLP_Bancos\\CuentaBancosWW.htm");
            cmbavDynamicfiltersoperator1.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV16DynamicFiltersOperator1), 4, 0));
            AssignProp("", false, cmbavDynamicfiltersoperator1_Internalname, "Values", (string)(cmbavDynamicfiltersoperator1.ToJavascriptSource()), true);
            GxWebStd.gx_div_end( context, "left", "top", "div");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "<td id=\""+cellFilter_bandsc1_cell_Internalname+"\"  class=''>") ;
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "left", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavBandsc1_Internalname, "Ban Dsc1", "gx-form-item AttributeLabel", 0, true, "width: 25%;");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 46,'',false,'" + sGXsfl_110_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavBandsc1_Internalname, StringUtil.RTrim( AV60BanDsc1), StringUtil.RTrim( context.localUtil.Format( AV60BanDsc1, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,46);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavBandsc1_Jsonclick, 0, "Attribute", "", "", "", "", edtavBandsc1_Visible, edtavBandsc1_Enabled, 0, "text", "", 80, "chr", 1, "row", 100, 0, 0, 0, 1, -1, -1, true, "", "left", true, "", "HLP_Bancos\\CuentaBancosWW.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "<td id=\""+cellFilter_moncod1_cell_Internalname+"\"  class=''>") ;
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "left", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, dynavMoncod1_Internalname, "Mon Cod1", "gx-form-item AttributeLabel", 0, true, "width: 25%;");
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 49,'',false,'" + sGXsfl_110_idx + "',0)\"";
            /* ComboBox */
            GxWebStd.gx_combobox_ctrl1( context, dynavMoncod1, dynavMoncod1_Internalname, StringUtil.Trim( StringUtil.Str( (decimal)(AV61MonCod1), 6, 0)), 1, dynavMoncod1_Jsonclick, 0, "'"+""+"'"+",false,"+"'"+""+"'", "int", "", dynavMoncod1.Visible, dynavMoncod1.Enabled, 0, 0, 0, "em", 0, "", "", "Attribute", "", "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,49);\"", "", true, 1, "HLP_Bancos\\CuentaBancosWW.htm");
            dynavMoncod1.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV61MonCod1), 6, 0));
            AssignProp("", false, dynavMoncod1_Internalname, "Values", (string)(dynavMoncod1.ToJavascriptSource()), true);
            GxWebStd.gx_div_end( context, "left", "top", "div");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "<td id=\""+cellDynamicfilters_addfilter1_cell_Internalname+"\"  class=''>") ;
            /* Active images/pictures */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 51,'',false,'',0)\"";
            ClassString = "Image";
            StyleString = "";
            sImgUrl = (string)(context.GetImagePath( "27283ea5-332f-423b-b880-64b762622df3", "", context.GetTheme( )));
            GxWebStd.gx_bitmap( context, imgAdddynamicfilters1_Internalname, sImgUrl, "", "", "", context.GetTheme( ), imgAdddynamicfilters1_Visible, 1, "", "Agregar filtro", 0, 0, 0, "px", 0, "px", 0, 0, 5, imgAdddynamicfilters1_Jsonclick, "'"+""+"'"+",false,"+"'"+"E\\'ADDDYNAMICFILTERS1\\'."+"'", StyleString, ClassString, "", "", "", "", " "+"data-gx-image"+" "+TempTags, "", "", 1, false, false, context.GetImageSrcSet( sImgUrl), "HLP_Bancos\\CuentaBancosWW.htm");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "<td id=\""+cellDynamicfilters_removefilter1_cell_Internalname+"\"  class=''>") ;
            /* Active images/pictures */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 53,'',false,'',0)\"";
            ClassString = "Image";
            StyleString = "";
            sImgUrl = (string)(context.GetImagePath( "11a6ef14-1a5a-4077-91a2-f41ed9a3a662", "", context.GetTheme( )));
            GxWebStd.gx_bitmap( context, imgRemovedynamicfilters1_Internalname, sImgUrl, "", "", "", context.GetTheme( ), imgRemovedynamicfilters1_Visible, 1, "", "Quitar filtro", 0, 0, 0, "px", 0, "px", 0, 0, 5, imgRemovedynamicfilters1_Jsonclick, "'"+""+"'"+",false,"+"'"+"E\\'REMOVEDYNAMICFILTERS1\\'."+"'", StyleString, ClassString, "", "", "", "", " "+"data-gx-image"+" "+TempTags, "", "", 1, false, false, context.GetImageSrcSet( sImgUrl), "HLP_Bancos\\CuentaBancosWW.htm");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "</tr>") ;
            /* End of table */
            context.WriteHtmlText( "</table>") ;
            wb_table2_39_1Z2e( true) ;
         }
         else
         {
            wb_table2_39_1Z2e( false) ;
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
         PA1Z2( ) ;
         WS1Z2( ) ;
         WE1Z2( ) ;
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
            context.AddJavascriptSource(StringUtil.RTrim( ((string)Form.Jscriptsrc.Item(idxLst))), "?20228181030269", true, true);
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
         context.AddJavascriptSource("bancos/cuentabancosww.js", "?20228181030269", false, true);
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
         edtBanDsc_Internalname = "BANDSC_"+sGXsfl_110_idx;
         edtCBCod_Internalname = "CBCOD_"+sGXsfl_110_idx;
         edtMonDsc_Internalname = "MONDSC_"+sGXsfl_110_idx;
         edtCBSts_Internalname = "CBSTS_"+sGXsfl_110_idx;
         edtBanCod_Internalname = "BANCOD_"+sGXsfl_110_idx;
         edtMonCod_Internalname = "MONCOD_"+sGXsfl_110_idx;
      }

      protected void SubsflControlProps_fel_1102( )
      {
         cmbavGridactions_Internalname = "vGRIDACTIONS_"+sGXsfl_110_fel_idx;
         edtBanDsc_Internalname = "BANDSC_"+sGXsfl_110_fel_idx;
         edtCBCod_Internalname = "CBCOD_"+sGXsfl_110_fel_idx;
         edtMonDsc_Internalname = "MONDSC_"+sGXsfl_110_fel_idx;
         edtCBSts_Internalname = "CBSTS_"+sGXsfl_110_fel_idx;
         edtBanCod_Internalname = "BANCOD_"+sGXsfl_110_fel_idx;
         edtMonCod_Internalname = "MONCOD_"+sGXsfl_110_fel_idx;
      }

      protected void sendrow_1102( )
      {
         SubsflControlProps_1102( ) ;
         WB1Z0( ) ;
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
                  AV57GridActions = (short)(NumberUtil.Val( cmbavGridactions.getValidValue(StringUtil.Trim( StringUtil.Str( (decimal)(AV57GridActions), 4, 0))), "."));
                  AssignAttri("", false, cmbavGridactions_Internalname, StringUtil.LTrimStr( (decimal)(AV57GridActions), 4, 0));
               }
            }
            /* ComboBox */
            GridRow.AddColumnProperties("combobox", 2, isAjaxCallMode( ), new Object[] {(GXCombobox)cmbavGridactions,(string)cmbavGridactions_Internalname,StringUtil.Trim( StringUtil.Str( (decimal)(AV57GridActions), 4, 0)),(short)1,(string)cmbavGridactions_Jsonclick,(short)5,"'"+""+"'"+",false,"+"'"+"EVGRIDACTIONS.CLICK."+sGXsfl_110_idx+"'",(string)"int",(string)"",(short)-1,(short)1,(short)0,(short)0,(short)0,(string)"px",(short)0,(string)"px",(string)"",(string)"ConvertToDDO",(string)"WWActionGroupColumn",(string)"",TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+((cmbavGridactions.Enabled!=0)&&(cmbavGridactions.Visible!=0) ? " onblur=\""+""+";gx.evt.onblur(this,111);\"" : " "),(string)"",(bool)true,(short)1});
            cmbavGridactions.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV57GridActions), 4, 0));
            AssignProp("", false, cmbavGridactions_Internalname, "Values", (string)(cmbavGridactions.ToJavascriptSource()), !bGXsfl_110_Refreshing);
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"left"+"\""+" style=\""+""+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtBanDsc_Internalname,StringUtil.RTrim( A482BanDsc),(string)"",(string)"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)edtBanDsc_Link,(string)"",(string)"",(string)"",(string)edtBanDsc_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn",(string)"",(short)-1,(short)0,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)100,(short)0,(short)0,(short)110,(short)1,(short)-1,(short)-1,(bool)true,(string)"",(string)"left",(bool)true,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"left"+"\""+" style=\""+""+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtCBCod_Internalname,StringUtil.RTrim( A377CBCod),(string)"",(string)"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtCBCod_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn hidden-xs",(string)"",(short)-1,(short)0,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)20,(short)0,(short)0,(short)110,(short)1,(short)-1,(short)-1,(bool)true,(string)"",(string)"left",(bool)true,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"left"+"\""+" style=\""+""+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtMonDsc_Internalname,StringUtil.RTrim( A1234MonDsc),(string)"",(string)"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)edtMonDsc_Link,(string)"",(string)"",(string)"",(string)edtMonDsc_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn",(string)"",(short)-1,(short)0,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)100,(short)0,(short)0,(short)110,(short)1,(short)-1,(short)-1,(bool)true,(string)"",(string)"left",(bool)true,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"right"+"\""+" style=\""+""+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtCBSts_Internalname,StringUtil.LTrim( StringUtil.NToC( (decimal)(A504CBSts), 1, 0, ".", "")),StringUtil.LTrim( context.localUtil.Format( (decimal)(A504CBSts), "9")),(string)" inputmode=\"numeric\" pattern=\"[0-9]*\""+"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)edtCBSts_Link,(string)"",(string)"",(string)"",(string)edtCBSts_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn",(string)"",(short)-1,(short)0,(short)0,(string)"text",(string)"1",(short)0,(string)"px",(short)17,(string)"px",(short)1,(short)0,(short)0,(short)110,(short)1,(short)-1,(short)0,(bool)true,(string)"",(string)"right",(bool)false,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"right"+"\""+" style=\""+"display:none;"+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtBanCod_Internalname,StringUtil.LTrim( StringUtil.NToC( (decimal)(A372BanCod), 6, 0, ".", "")),StringUtil.LTrim( context.localUtil.Format( (decimal)(A372BanCod), "ZZZZZ9")),(string)" inputmode=\"numeric\" pattern=\"[0-9]*\""+"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtBanCod_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn hidden-xs",(string)"",(short)0,(short)0,(short)0,(string)"text",(string)"1",(short)0,(string)"px",(short)17,(string)"px",(short)6,(short)0,(short)0,(short)110,(short)1,(short)-1,(short)0,(bool)true,(string)"",(string)"right",(bool)false,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"right"+"\""+" style=\""+"display:none;"+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtMonCod_Internalname,StringUtil.LTrim( StringUtil.NToC( (decimal)(A180MonCod), 6, 0, ".", "")),StringUtil.LTrim( context.localUtil.Format( (decimal)(A180MonCod), "ZZZZZ9")),(string)" inputmode=\"numeric\" pattern=\"[0-9]*\""+"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtMonCod_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn hidden-xs",(string)"",(short)0,(short)0,(short)0,(string)"text",(string)"1",(short)0,(string)"px",(short)17,(string)"px",(short)6,(short)0,(short)0,(short)110,(short)1,(short)-1,(short)0,(bool)true,(string)"",(string)"right",(bool)false,(string)""});
            send_integrity_lvl_hashes1Z2( ) ;
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
         cmbavDynamicfiltersselector1.addItem("BANDSC", "Banco", 0);
         cmbavDynamicfiltersselector1.addItem("MONCOD", "Moneda", 0);
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
         dynavMoncod1.Name = "vMONCOD1";
         dynavMoncod1.WebTags = "";
         cmbavDynamicfiltersselector2.Name = "vDYNAMICFILTERSSELECTOR2";
         cmbavDynamicfiltersselector2.WebTags = "";
         cmbavDynamicfiltersselector2.addItem("BANDSC", "Banco", 0);
         cmbavDynamicfiltersselector2.addItem("MONCOD", "Moneda", 0);
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
         dynavMoncod2.Name = "vMONCOD2";
         dynavMoncod2.WebTags = "";
         cmbavDynamicfiltersselector3.Name = "vDYNAMICFILTERSSELECTOR3";
         cmbavDynamicfiltersselector3.WebTags = "";
         cmbavDynamicfiltersselector3.addItem("BANDSC", "Banco", 0);
         cmbavDynamicfiltersselector3.addItem("MONCOD", "Moneda", 0);
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
         dynavMoncod3.Name = "vMONCOD3";
         dynavMoncod3.WebTags = "";
         GXCCtl = "vGRIDACTIONS_" + sGXsfl_110_idx;
         cmbavGridactions.Name = GXCCtl;
         cmbavGridactions.WebTags = "";
         if ( cmbavGridactions.ItemCount > 0 )
         {
            AV57GridActions = (short)(NumberUtil.Val( cmbavGridactions.getValidValue(StringUtil.Trim( StringUtil.Str( (decimal)(AV57GridActions), 4, 0))), "."));
            AssignAttri("", false, cmbavGridactions_Internalname, StringUtil.LTrimStr( (decimal)(AV57GridActions), 4, 0));
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
         edtavBandsc1_Internalname = "vBANDSC1";
         cellFilter_bandsc1_cell_Internalname = "FILTER_BANDSC1_CELL";
         dynavMoncod1_Internalname = "vMONCOD1";
         cellFilter_moncod1_cell_Internalname = "FILTER_MONCOD1_CELL";
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
         edtavBandsc2_Internalname = "vBANDSC2";
         cellFilter_bandsc2_cell_Internalname = "FILTER_BANDSC2_CELL";
         dynavMoncod2_Internalname = "vMONCOD2";
         cellFilter_moncod2_cell_Internalname = "FILTER_MONCOD2_CELL";
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
         edtavBandsc3_Internalname = "vBANDSC3";
         cellFilter_bandsc3_cell_Internalname = "FILTER_BANDSC3_CELL";
         dynavMoncod3_Internalname = "vMONCOD3";
         cellFilter_moncod3_cell_Internalname = "FILTER_MONCOD3_CELL";
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
         edtBanDsc_Internalname = "BANDSC";
         edtCBCod_Internalname = "CBCOD";
         edtMonDsc_Internalname = "MONDSC";
         edtCBSts_Internalname = "CBSTS";
         edtBanCod_Internalname = "BANCOD";
         edtMonCod_Internalname = "MONCOD";
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
         edtMonCod_Jsonclick = "";
         edtBanCod_Jsonclick = "";
         edtCBSts_Jsonclick = "";
         edtMonDsc_Jsonclick = "";
         edtCBCod_Jsonclick = "";
         edtBanDsc_Jsonclick = "";
         cmbavGridactions_Jsonclick = "";
         cmbavGridactions.Visible = -1;
         cmbavGridactions.Enabled = 1;
         imgRemovedynamicfilters1_Visible = 1;
         imgAdddynamicfilters1_Visible = 1;
         dynavMoncod1_Jsonclick = "";
         dynavMoncod1.Enabled = 1;
         edtavBandsc1_Jsonclick = "";
         edtavBandsc1_Enabled = 1;
         cmbavDynamicfiltersoperator1_Jsonclick = "";
         cmbavDynamicfiltersoperator1.Enabled = 1;
         imgRemovedynamicfilters2_Visible = 1;
         imgAdddynamicfilters2_Visible = 1;
         dynavMoncod2_Jsonclick = "";
         dynavMoncod2.Enabled = 1;
         edtavBandsc2_Jsonclick = "";
         edtavBandsc2_Enabled = 1;
         cmbavDynamicfiltersoperator2_Jsonclick = "";
         cmbavDynamicfiltersoperator2.Enabled = 1;
         dynavMoncod3_Jsonclick = "";
         dynavMoncod3.Enabled = 1;
         edtavBandsc3_Jsonclick = "";
         edtavBandsc3_Enabled = 1;
         cmbavDynamicfiltersoperator3_Jsonclick = "";
         cmbavDynamicfiltersoperator3.Enabled = 1;
         cmbavDynamicfiltersselector3_Jsonclick = "";
         cmbavDynamicfiltersselector3.Enabled = 1;
         cmbavDynamicfiltersselector2_Jsonclick = "";
         cmbavDynamicfiltersselector2.Enabled = 1;
         cmbavDynamicfiltersselector1_Jsonclick = "";
         cmbavDynamicfiltersselector1.Enabled = 1;
         cmbavDynamicfiltersoperator3.Visible = 1;
         dynavMoncod3.Visible = 1;
         edtavBandsc3_Visible = 1;
         cmbavDynamicfiltersoperator2.Visible = 1;
         dynavMoncod2.Visible = 1;
         edtavBandsc2_Visible = 1;
         cmbavDynamicfiltersoperator1.Visible = 1;
         dynavMoncod1.Visible = 1;
         edtavBandsc1_Visible = 1;
         lblJsdynamicfilters_Caption = "JSDynamicFilters";
         subGrid_Allowcollapsing = 0;
         subGrid_Allowselection = 0;
         edtCBSts_Link = "";
         edtMonDsc_Link = "";
         edtBanDsc_Link = "";
         subGrid_Sortable = 0;
         subGrid_Header = "";
         subGrid_Class = "GridWithPaginationBar WorkWith";
         subGrid_Backcolorstyle = 0;
         Grid_empowerer_Hastitlesettings = Convert.ToBoolean( -1);
         Innewwindow1_Target = "";
         Innewwindow1_Height = "50";
         Innewwindow1_Width = "50";
         Ddo_grid_Datalistproc = "Bancos.CuentaBancosWWGetFilterData";
         Ddo_grid_Datalisttype = "Dynamic|Dynamic|Dynamic|";
         Ddo_grid_Includedatalist = "T|T|T|";
         Ddo_grid_Filterisrange = "|||T";
         Ddo_grid_Filtertype = "Character|Character|Character|Numeric";
         Ddo_grid_Includefilter = "T";
         Ddo_grid_Includesortasc = "T";
         Ddo_grid_Columnssortvalues = "2|3|4|5";
         Ddo_grid_Columnids = "1:BanDsc|2:CBCod|3:MonDsc|4:CBSts";
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
         Form.Caption = " Cuenta Bancos";
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
         setEventMetadata("REFRESH","{handler:'Refresh',iparms:[{av:'GRID_nFirstRecordOnPage'},{av:'GRID_nEOF'},{av:'subGrid_Rows',ctrl:'GRID',prop:'Rows'},{av:'cmbavDynamicfiltersselector1'},{av:'AV15DynamicFiltersSelector1',fld:'vDYNAMICFILTERSSELECTOR1',pic:''},{av:'cmbavDynamicfiltersoperator1'},{av:'AV16DynamicFiltersOperator1',fld:'vDYNAMICFILTERSOPERATOR1',pic:'ZZZ9'},{av:'AV60BanDsc1',fld:'vBANDSC1',pic:''},{av:'cmbavDynamicfiltersselector2'},{av:'AV20DynamicFiltersSelector2',fld:'vDYNAMICFILTERSSELECTOR2',pic:''},{av:'cmbavDynamicfiltersoperator2'},{av:'AV21DynamicFiltersOperator2',fld:'vDYNAMICFILTERSOPERATOR2',pic:'ZZZ9'},{av:'AV62BanDsc2',fld:'vBANDSC2',pic:''},{av:'cmbavDynamicfiltersselector3'},{av:'AV25DynamicFiltersSelector3',fld:'vDYNAMICFILTERSSELECTOR3',pic:''},{av:'cmbavDynamicfiltersoperator3'},{av:'AV26DynamicFiltersOperator3',fld:'vDYNAMICFILTERSOPERATOR3',pic:'ZZZ9'},{av:'AV64BanDsc3',fld:'vBANDSC3',pic:''},{av:'AV74Pgmname',fld:'vPGMNAME',pic:'',hsh:true},{av:'AV19DynamicFiltersEnabled2',fld:'vDYNAMICFILTERSENABLED2',pic:''},{av:'AV24DynamicFiltersEnabled3',fld:'vDYNAMICFILTERSENABLED3',pic:''},{av:'AV66TFBanDsc',fld:'vTFBANDSC',pic:''},{av:'AV67TFBanDsc_Sel',fld:'vTFBANDSC_SEL',pic:''},{av:'AV36TFCBCod',fld:'vTFCBCOD',pic:''},{av:'AV37TFCBCod_Sel',fld:'vTFCBCOD_SEL',pic:''},{av:'AV68TFMonDsc',fld:'vTFMONDSC',pic:''},{av:'AV69TFMonDsc_Sel',fld:'vTFMONDSC_SEL',pic:''},{av:'AV42TFCBSts',fld:'vTFCBSTS',pic:'9'},{av:'AV43TFCBSts_To',fld:'vTFCBSTS_TO',pic:'9'},{av:'AV13OrderedBy',fld:'vORDEREDBY',pic:'ZZZ9'},{av:'AV14OrderedDsc',fld:'vORDEREDDSC',pic:''},{av:'AV10GridState',fld:'vGRIDSTATE',pic:''},{av:'AV30DynamicFiltersIgnoreFirst',fld:'vDYNAMICFILTERSIGNOREFIRST',pic:''},{av:'AV29DynamicFiltersRemoving',fld:'vDYNAMICFILTERSREMOVING',pic:''},{av:'dynavMoncod1'},{av:'AV61MonCod1',fld:'vMONCOD1',pic:'ZZZZZ9'},{av:'dynavMoncod2'},{av:'AV63MonCod2',fld:'vMONCOD2',pic:'ZZZZZ9'},{av:'dynavMoncod3'},{av:'AV65MonCod3',fld:'vMONCOD3',pic:'ZZZZZ9'}]");
         setEventMetadata("REFRESH",",oparms:[{av:'AV54GridCurrentPage',fld:'vGRIDCURRENTPAGE',pic:'ZZZZZZZZZ9'},{av:'AV55GridPageCount',fld:'vGRIDPAGECOUNT',pic:'ZZZZZZZZZ9'},{av:'AV56GridAppliedFilters',fld:'vGRIDAPPLIEDFILTERS',pic:''},{av:'AV10GridState',fld:'vGRIDSTATE',pic:''},{av:'dynavMoncod1'},{av:'AV61MonCod1',fld:'vMONCOD1',pic:'ZZZZZ9'},{av:'dynavMoncod2'},{av:'AV63MonCod2',fld:'vMONCOD2',pic:'ZZZZZ9'},{av:'dynavMoncod3'},{av:'AV65MonCod3',fld:'vMONCOD3',pic:'ZZZZZ9'}]}");
         setEventMetadata("GRIDPAGINATIONBAR.CHANGEPAGE","{handler:'E111Z2',iparms:[{av:'GRID_nFirstRecordOnPage'},{av:'GRID_nEOF'},{av:'subGrid_Rows',ctrl:'GRID',prop:'Rows'},{av:'cmbavDynamicfiltersselector1'},{av:'AV15DynamicFiltersSelector1',fld:'vDYNAMICFILTERSSELECTOR1',pic:''},{av:'cmbavDynamicfiltersoperator1'},{av:'AV16DynamicFiltersOperator1',fld:'vDYNAMICFILTERSOPERATOR1',pic:'ZZZ9'},{av:'AV60BanDsc1',fld:'vBANDSC1',pic:''},{av:'cmbavDynamicfiltersselector2'},{av:'AV20DynamicFiltersSelector2',fld:'vDYNAMICFILTERSSELECTOR2',pic:''},{av:'cmbavDynamicfiltersoperator2'},{av:'AV21DynamicFiltersOperator2',fld:'vDYNAMICFILTERSOPERATOR2',pic:'ZZZ9'},{av:'AV62BanDsc2',fld:'vBANDSC2',pic:''},{av:'cmbavDynamicfiltersselector3'},{av:'AV25DynamicFiltersSelector3',fld:'vDYNAMICFILTERSSELECTOR3',pic:''},{av:'cmbavDynamicfiltersoperator3'},{av:'AV26DynamicFiltersOperator3',fld:'vDYNAMICFILTERSOPERATOR3',pic:'ZZZ9'},{av:'AV64BanDsc3',fld:'vBANDSC3',pic:''},{av:'AV74Pgmname',fld:'vPGMNAME',pic:'',hsh:true},{av:'AV19DynamicFiltersEnabled2',fld:'vDYNAMICFILTERSENABLED2',pic:''},{av:'AV24DynamicFiltersEnabled3',fld:'vDYNAMICFILTERSENABLED3',pic:''},{av:'AV66TFBanDsc',fld:'vTFBANDSC',pic:''},{av:'AV67TFBanDsc_Sel',fld:'vTFBANDSC_SEL',pic:''},{av:'AV36TFCBCod',fld:'vTFCBCOD',pic:''},{av:'AV37TFCBCod_Sel',fld:'vTFCBCOD_SEL',pic:''},{av:'AV68TFMonDsc',fld:'vTFMONDSC',pic:''},{av:'AV69TFMonDsc_Sel',fld:'vTFMONDSC_SEL',pic:''},{av:'AV42TFCBSts',fld:'vTFCBSTS',pic:'9'},{av:'AV43TFCBSts_To',fld:'vTFCBSTS_TO',pic:'9'},{av:'AV13OrderedBy',fld:'vORDEREDBY',pic:'ZZZ9'},{av:'AV14OrderedDsc',fld:'vORDEREDDSC',pic:''},{av:'AV10GridState',fld:'vGRIDSTATE',pic:''},{av:'AV30DynamicFiltersIgnoreFirst',fld:'vDYNAMICFILTERSIGNOREFIRST',pic:''},{av:'AV29DynamicFiltersRemoving',fld:'vDYNAMICFILTERSREMOVING',pic:''},{av:'Gridpaginationbar_Selectedpage',ctrl:'GRIDPAGINATIONBAR',prop:'SelectedPage'},{av:'dynavMoncod1'},{av:'AV61MonCod1',fld:'vMONCOD1',pic:'ZZZZZ9'},{av:'dynavMoncod2'},{av:'AV63MonCod2',fld:'vMONCOD2',pic:'ZZZZZ9'},{av:'dynavMoncod3'},{av:'AV65MonCod3',fld:'vMONCOD3',pic:'ZZZZZ9'}]");
         setEventMetadata("GRIDPAGINATIONBAR.CHANGEPAGE",",oparms:[{av:'dynavMoncod1'},{av:'AV61MonCod1',fld:'vMONCOD1',pic:'ZZZZZ9'},{av:'dynavMoncod2'},{av:'AV63MonCod2',fld:'vMONCOD2',pic:'ZZZZZ9'},{av:'dynavMoncod3'},{av:'AV65MonCod3',fld:'vMONCOD3',pic:'ZZZZZ9'}]}");
         setEventMetadata("GRIDPAGINATIONBAR.CHANGEROWSPERPAGE","{handler:'E121Z2',iparms:[{av:'GRID_nFirstRecordOnPage'},{av:'GRID_nEOF'},{av:'subGrid_Rows',ctrl:'GRID',prop:'Rows'},{av:'cmbavDynamicfiltersselector1'},{av:'AV15DynamicFiltersSelector1',fld:'vDYNAMICFILTERSSELECTOR1',pic:''},{av:'cmbavDynamicfiltersoperator1'},{av:'AV16DynamicFiltersOperator1',fld:'vDYNAMICFILTERSOPERATOR1',pic:'ZZZ9'},{av:'AV60BanDsc1',fld:'vBANDSC1',pic:''},{av:'cmbavDynamicfiltersselector2'},{av:'AV20DynamicFiltersSelector2',fld:'vDYNAMICFILTERSSELECTOR2',pic:''},{av:'cmbavDynamicfiltersoperator2'},{av:'AV21DynamicFiltersOperator2',fld:'vDYNAMICFILTERSOPERATOR2',pic:'ZZZ9'},{av:'AV62BanDsc2',fld:'vBANDSC2',pic:''},{av:'cmbavDynamicfiltersselector3'},{av:'AV25DynamicFiltersSelector3',fld:'vDYNAMICFILTERSSELECTOR3',pic:''},{av:'cmbavDynamicfiltersoperator3'},{av:'AV26DynamicFiltersOperator3',fld:'vDYNAMICFILTERSOPERATOR3',pic:'ZZZ9'},{av:'AV64BanDsc3',fld:'vBANDSC3',pic:''},{av:'AV74Pgmname',fld:'vPGMNAME',pic:'',hsh:true},{av:'AV19DynamicFiltersEnabled2',fld:'vDYNAMICFILTERSENABLED2',pic:''},{av:'AV24DynamicFiltersEnabled3',fld:'vDYNAMICFILTERSENABLED3',pic:''},{av:'AV66TFBanDsc',fld:'vTFBANDSC',pic:''},{av:'AV67TFBanDsc_Sel',fld:'vTFBANDSC_SEL',pic:''},{av:'AV36TFCBCod',fld:'vTFCBCOD',pic:''},{av:'AV37TFCBCod_Sel',fld:'vTFCBCOD_SEL',pic:''},{av:'AV68TFMonDsc',fld:'vTFMONDSC',pic:''},{av:'AV69TFMonDsc_Sel',fld:'vTFMONDSC_SEL',pic:''},{av:'AV42TFCBSts',fld:'vTFCBSTS',pic:'9'},{av:'AV43TFCBSts_To',fld:'vTFCBSTS_TO',pic:'9'},{av:'AV13OrderedBy',fld:'vORDEREDBY',pic:'ZZZ9'},{av:'AV14OrderedDsc',fld:'vORDEREDDSC',pic:''},{av:'AV10GridState',fld:'vGRIDSTATE',pic:''},{av:'AV30DynamicFiltersIgnoreFirst',fld:'vDYNAMICFILTERSIGNOREFIRST',pic:''},{av:'AV29DynamicFiltersRemoving',fld:'vDYNAMICFILTERSREMOVING',pic:''},{av:'Gridpaginationbar_Rowsperpageselectedvalue',ctrl:'GRIDPAGINATIONBAR',prop:'RowsPerPageSelectedValue'},{av:'dynavMoncod1'},{av:'AV61MonCod1',fld:'vMONCOD1',pic:'ZZZZZ9'},{av:'dynavMoncod2'},{av:'AV63MonCod2',fld:'vMONCOD2',pic:'ZZZZZ9'},{av:'dynavMoncod3'},{av:'AV65MonCod3',fld:'vMONCOD3',pic:'ZZZZZ9'}]");
         setEventMetadata("GRIDPAGINATIONBAR.CHANGEROWSPERPAGE",",oparms:[{av:'subGrid_Rows',ctrl:'GRID',prop:'Rows'},{av:'dynavMoncod1'},{av:'AV61MonCod1',fld:'vMONCOD1',pic:'ZZZZZ9'},{av:'dynavMoncod2'},{av:'AV63MonCod2',fld:'vMONCOD2',pic:'ZZZZZ9'},{av:'dynavMoncod3'},{av:'AV65MonCod3',fld:'vMONCOD3',pic:'ZZZZZ9'}]}");
         setEventMetadata("DDO_GRID.ONOPTIONCLICKED","{handler:'E141Z2',iparms:[{av:'GRID_nFirstRecordOnPage'},{av:'GRID_nEOF'},{av:'subGrid_Rows',ctrl:'GRID',prop:'Rows'},{av:'cmbavDynamicfiltersselector1'},{av:'AV15DynamicFiltersSelector1',fld:'vDYNAMICFILTERSSELECTOR1',pic:''},{av:'cmbavDynamicfiltersoperator1'},{av:'AV16DynamicFiltersOperator1',fld:'vDYNAMICFILTERSOPERATOR1',pic:'ZZZ9'},{av:'AV60BanDsc1',fld:'vBANDSC1',pic:''},{av:'cmbavDynamicfiltersselector2'},{av:'AV20DynamicFiltersSelector2',fld:'vDYNAMICFILTERSSELECTOR2',pic:''},{av:'cmbavDynamicfiltersoperator2'},{av:'AV21DynamicFiltersOperator2',fld:'vDYNAMICFILTERSOPERATOR2',pic:'ZZZ9'},{av:'AV62BanDsc2',fld:'vBANDSC2',pic:''},{av:'cmbavDynamicfiltersselector3'},{av:'AV25DynamicFiltersSelector3',fld:'vDYNAMICFILTERSSELECTOR3',pic:''},{av:'cmbavDynamicfiltersoperator3'},{av:'AV26DynamicFiltersOperator3',fld:'vDYNAMICFILTERSOPERATOR3',pic:'ZZZ9'},{av:'AV64BanDsc3',fld:'vBANDSC3',pic:''},{av:'AV74Pgmname',fld:'vPGMNAME',pic:'',hsh:true},{av:'AV19DynamicFiltersEnabled2',fld:'vDYNAMICFILTERSENABLED2',pic:''},{av:'AV24DynamicFiltersEnabled3',fld:'vDYNAMICFILTERSENABLED3',pic:''},{av:'AV66TFBanDsc',fld:'vTFBANDSC',pic:''},{av:'AV67TFBanDsc_Sel',fld:'vTFBANDSC_SEL',pic:''},{av:'AV36TFCBCod',fld:'vTFCBCOD',pic:''},{av:'AV37TFCBCod_Sel',fld:'vTFCBCOD_SEL',pic:''},{av:'AV68TFMonDsc',fld:'vTFMONDSC',pic:''},{av:'AV69TFMonDsc_Sel',fld:'vTFMONDSC_SEL',pic:''},{av:'AV42TFCBSts',fld:'vTFCBSTS',pic:'9'},{av:'AV43TFCBSts_To',fld:'vTFCBSTS_TO',pic:'9'},{av:'AV13OrderedBy',fld:'vORDEREDBY',pic:'ZZZ9'},{av:'AV14OrderedDsc',fld:'vORDEREDDSC',pic:''},{av:'AV10GridState',fld:'vGRIDSTATE',pic:''},{av:'AV30DynamicFiltersIgnoreFirst',fld:'vDYNAMICFILTERSIGNOREFIRST',pic:''},{av:'AV29DynamicFiltersRemoving',fld:'vDYNAMICFILTERSREMOVING',pic:''},{av:'Ddo_grid_Activeeventkey',ctrl:'DDO_GRID',prop:'ActiveEventKey'},{av:'Ddo_grid_Selectedvalue_get',ctrl:'DDO_GRID',prop:'SelectedValue_get'},{av:'Ddo_grid_Selectedcolumn',ctrl:'DDO_GRID',prop:'SelectedColumn'},{av:'Ddo_grid_Filteredtext_get',ctrl:'DDO_GRID',prop:'FilteredText_get'},{av:'Ddo_grid_Filteredtextto_get',ctrl:'DDO_GRID',prop:'FilteredTextTo_get'},{av:'dynavMoncod1'},{av:'AV61MonCod1',fld:'vMONCOD1',pic:'ZZZZZ9'},{av:'dynavMoncod2'},{av:'AV63MonCod2',fld:'vMONCOD2',pic:'ZZZZZ9'},{av:'dynavMoncod3'},{av:'AV65MonCod3',fld:'vMONCOD3',pic:'ZZZZZ9'}]");
         setEventMetadata("DDO_GRID.ONOPTIONCLICKED",",oparms:[{av:'AV13OrderedBy',fld:'vORDEREDBY',pic:'ZZZ9'},{av:'AV14OrderedDsc',fld:'vORDEREDDSC',pic:''},{av:'AV66TFBanDsc',fld:'vTFBANDSC',pic:''},{av:'AV67TFBanDsc_Sel',fld:'vTFBANDSC_SEL',pic:''},{av:'AV36TFCBCod',fld:'vTFCBCOD',pic:''},{av:'AV37TFCBCod_Sel',fld:'vTFCBCOD_SEL',pic:''},{av:'AV68TFMonDsc',fld:'vTFMONDSC',pic:''},{av:'AV69TFMonDsc_Sel',fld:'vTFMONDSC_SEL',pic:''},{av:'AV42TFCBSts',fld:'vTFCBSTS',pic:'9'},{av:'AV43TFCBSts_To',fld:'vTFCBSTS_TO',pic:'9'},{av:'Ddo_grid_Sortedstatus',ctrl:'DDO_GRID',prop:'SortedStatus'},{av:'dynavMoncod1'},{av:'AV61MonCod1',fld:'vMONCOD1',pic:'ZZZZZ9'},{av:'dynavMoncod2'},{av:'AV63MonCod2',fld:'vMONCOD2',pic:'ZZZZZ9'},{av:'dynavMoncod3'},{av:'AV65MonCod3',fld:'vMONCOD3',pic:'ZZZZZ9'}]}");
         setEventMetadata("GRID.LOAD","{handler:'E261Z2',iparms:[{av:'A372BanCod',fld:'BANCOD',pic:'ZZZZZ9',hsh:true},{av:'A180MonCod',fld:'MONCOD',pic:'ZZZZZ9'},{av:'A377CBCod',fld:'CBCOD',pic:'',hsh:true},{av:'dynavMoncod1'},{av:'AV61MonCod1',fld:'vMONCOD1',pic:'ZZZZZ9'},{av:'dynavMoncod2'},{av:'AV63MonCod2',fld:'vMONCOD2',pic:'ZZZZZ9'},{av:'dynavMoncod3'},{av:'AV65MonCod3',fld:'vMONCOD3',pic:'ZZZZZ9'}]");
         setEventMetadata("GRID.LOAD",",oparms:[{av:'cmbavGridactions'},{av:'AV57GridActions',fld:'vGRIDACTIONS',pic:'ZZZ9'},{av:'edtBanDsc_Link',ctrl:'BANDSC',prop:'Link'},{av:'edtMonDsc_Link',ctrl:'MONDSC',prop:'Link'},{av:'edtCBSts_Link',ctrl:'CBSTS',prop:'Link'},{av:'dynavMoncod1'},{av:'AV61MonCod1',fld:'vMONCOD1',pic:'ZZZZZ9'},{av:'dynavMoncod2'},{av:'AV63MonCod2',fld:'vMONCOD2',pic:'ZZZZZ9'},{av:'dynavMoncod3'},{av:'AV65MonCod3',fld:'vMONCOD3',pic:'ZZZZZ9'}]}");
         setEventMetadata("'ADDDYNAMICFILTERS1'","{handler:'E191Z2',iparms:[{av:'dynavMoncod1'},{av:'AV61MonCod1',fld:'vMONCOD1',pic:'ZZZZZ9'},{av:'dynavMoncod2'},{av:'AV63MonCod2',fld:'vMONCOD2',pic:'ZZZZZ9'},{av:'dynavMoncod3'},{av:'AV65MonCod3',fld:'vMONCOD3',pic:'ZZZZZ9'}]");
         setEventMetadata("'ADDDYNAMICFILTERS1'",",oparms:[{av:'AV19DynamicFiltersEnabled2',fld:'vDYNAMICFILTERSENABLED2',pic:''},{av:'imgAdddynamicfilters1_Visible',ctrl:'ADDDYNAMICFILTERS1',prop:'Visible'},{av:'imgRemovedynamicfilters1_Visible',ctrl:'REMOVEDYNAMICFILTERS1',prop:'Visible'},{av:'dynavMoncod1'},{av:'AV61MonCod1',fld:'vMONCOD1',pic:'ZZZZZ9'},{av:'dynavMoncod2'},{av:'AV63MonCod2',fld:'vMONCOD2',pic:'ZZZZZ9'},{av:'dynavMoncod3'},{av:'AV65MonCod3',fld:'vMONCOD3',pic:'ZZZZZ9'}]}");
         setEventMetadata("'REMOVEDYNAMICFILTERS1'","{handler:'E151Z2',iparms:[{av:'GRID_nFirstRecordOnPage'},{av:'GRID_nEOF'},{av:'subGrid_Rows',ctrl:'GRID',prop:'Rows'},{av:'cmbavDynamicfiltersselector1'},{av:'AV15DynamicFiltersSelector1',fld:'vDYNAMICFILTERSSELECTOR1',pic:''},{av:'cmbavDynamicfiltersoperator1'},{av:'AV16DynamicFiltersOperator1',fld:'vDYNAMICFILTERSOPERATOR1',pic:'ZZZ9'},{av:'AV60BanDsc1',fld:'vBANDSC1',pic:''},{av:'cmbavDynamicfiltersselector2'},{av:'AV20DynamicFiltersSelector2',fld:'vDYNAMICFILTERSSELECTOR2',pic:''},{av:'cmbavDynamicfiltersoperator2'},{av:'AV21DynamicFiltersOperator2',fld:'vDYNAMICFILTERSOPERATOR2',pic:'ZZZ9'},{av:'AV62BanDsc2',fld:'vBANDSC2',pic:''},{av:'cmbavDynamicfiltersselector3'},{av:'AV25DynamicFiltersSelector3',fld:'vDYNAMICFILTERSSELECTOR3',pic:''},{av:'cmbavDynamicfiltersoperator3'},{av:'AV26DynamicFiltersOperator3',fld:'vDYNAMICFILTERSOPERATOR3',pic:'ZZZ9'},{av:'AV64BanDsc3',fld:'vBANDSC3',pic:''},{av:'AV74Pgmname',fld:'vPGMNAME',pic:'',hsh:true},{av:'AV19DynamicFiltersEnabled2',fld:'vDYNAMICFILTERSENABLED2',pic:''},{av:'AV24DynamicFiltersEnabled3',fld:'vDYNAMICFILTERSENABLED3',pic:''},{av:'AV66TFBanDsc',fld:'vTFBANDSC',pic:''},{av:'AV67TFBanDsc_Sel',fld:'vTFBANDSC_SEL',pic:''},{av:'AV36TFCBCod',fld:'vTFCBCOD',pic:''},{av:'AV37TFCBCod_Sel',fld:'vTFCBCOD_SEL',pic:''},{av:'AV68TFMonDsc',fld:'vTFMONDSC',pic:''},{av:'AV69TFMonDsc_Sel',fld:'vTFMONDSC_SEL',pic:''},{av:'AV42TFCBSts',fld:'vTFCBSTS',pic:'9'},{av:'AV43TFCBSts_To',fld:'vTFCBSTS_TO',pic:'9'},{av:'AV13OrderedBy',fld:'vORDEREDBY',pic:'ZZZ9'},{av:'AV14OrderedDsc',fld:'vORDEREDDSC',pic:''},{av:'AV10GridState',fld:'vGRIDSTATE',pic:''},{av:'AV30DynamicFiltersIgnoreFirst',fld:'vDYNAMICFILTERSIGNOREFIRST',pic:''},{av:'AV29DynamicFiltersRemoving',fld:'vDYNAMICFILTERSREMOVING',pic:''},{av:'dynavMoncod1'},{av:'AV61MonCod1',fld:'vMONCOD1',pic:'ZZZZZ9'},{av:'dynavMoncod2'},{av:'AV63MonCod2',fld:'vMONCOD2',pic:'ZZZZZ9'},{av:'dynavMoncod3'},{av:'AV65MonCod3',fld:'vMONCOD3',pic:'ZZZZZ9'}]");
         setEventMetadata("'REMOVEDYNAMICFILTERS1'",",oparms:[{av:'AV29DynamicFiltersRemoving',fld:'vDYNAMICFILTERSREMOVING',pic:''},{av:'AV30DynamicFiltersIgnoreFirst',fld:'vDYNAMICFILTERSIGNOREFIRST',pic:''},{av:'AV10GridState',fld:'vGRIDSTATE',pic:''},{av:'AV19DynamicFiltersEnabled2',fld:'vDYNAMICFILTERSENABLED2',pic:''},{av:'cmbavDynamicfiltersselector2'},{av:'AV20DynamicFiltersSelector2',fld:'vDYNAMICFILTERSSELECTOR2',pic:''},{av:'cmbavDynamicfiltersoperator2'},{av:'AV21DynamicFiltersOperator2',fld:'vDYNAMICFILTERSOPERATOR2',pic:'ZZZ9'},{av:'AV62BanDsc2',fld:'vBANDSC2',pic:''},{av:'AV24DynamicFiltersEnabled3',fld:'vDYNAMICFILTERSENABLED3',pic:''},{av:'cmbavDynamicfiltersselector3'},{av:'AV25DynamicFiltersSelector3',fld:'vDYNAMICFILTERSSELECTOR3',pic:''},{av:'cmbavDynamicfiltersoperator3'},{av:'AV26DynamicFiltersOperator3',fld:'vDYNAMICFILTERSOPERATOR3',pic:'ZZZ9'},{av:'AV64BanDsc3',fld:'vBANDSC3',pic:''},{av:'imgAdddynamicfilters1_Visible',ctrl:'ADDDYNAMICFILTERS1',prop:'Visible'},{av:'imgRemovedynamicfilters1_Visible',ctrl:'REMOVEDYNAMICFILTERS1',prop:'Visible'},{av:'imgAdddynamicfilters2_Visible',ctrl:'ADDDYNAMICFILTERS2',prop:'Visible'},{av:'imgRemovedynamicfilters2_Visible',ctrl:'REMOVEDYNAMICFILTERS2',prop:'Visible'},{av:'cmbavDynamicfiltersselector1'},{av:'AV15DynamicFiltersSelector1',fld:'vDYNAMICFILTERSSELECTOR1',pic:''},{av:'cmbavDynamicfiltersoperator1'},{av:'AV16DynamicFiltersOperator1',fld:'vDYNAMICFILTERSOPERATOR1',pic:'ZZZ9'},{av:'AV60BanDsc1',fld:'vBANDSC1',pic:''},{av:'lblJsdynamicfilters_Caption',ctrl:'JSDYNAMICFILTERS',prop:'Caption'},{av:'edtavBandsc2_Visible',ctrl:'vBANDSC2',prop:'Visible'},{av:'edtavBandsc3_Visible',ctrl:'vBANDSC3',prop:'Visible'},{av:'edtavBandsc1_Visible',ctrl:'vBANDSC1',prop:'Visible'},{av:'AV54GridCurrentPage',fld:'vGRIDCURRENTPAGE',pic:'ZZZZZZZZZ9'},{av:'AV55GridPageCount',fld:'vGRIDPAGECOUNT',pic:'ZZZZZZZZZ9'},{av:'AV56GridAppliedFilters',fld:'vGRIDAPPLIEDFILTERS',pic:''},{av:'dynavMoncod1'},{av:'AV61MonCod1',fld:'vMONCOD1',pic:'ZZZZZ9'},{av:'dynavMoncod2'},{av:'AV63MonCod2',fld:'vMONCOD2',pic:'ZZZZZ9'},{av:'dynavMoncod3'},{av:'AV65MonCod3',fld:'vMONCOD3',pic:'ZZZZZ9'}]}");
         setEventMetadata("VDYNAMICFILTERSSELECTOR1.CLICK","{handler:'E201Z2',iparms:[{av:'cmbavDynamicfiltersselector1'},{av:'AV15DynamicFiltersSelector1',fld:'vDYNAMICFILTERSSELECTOR1',pic:''},{av:'dynavMoncod1'},{av:'AV61MonCod1',fld:'vMONCOD1',pic:'ZZZZZ9'},{av:'dynavMoncod2'},{av:'AV63MonCod2',fld:'vMONCOD2',pic:'ZZZZZ9'},{av:'dynavMoncod3'},{av:'AV65MonCod3',fld:'vMONCOD3',pic:'ZZZZZ9'}]");
         setEventMetadata("VDYNAMICFILTERSSELECTOR1.CLICK",",oparms:[{av:'edtavBandsc1_Visible',ctrl:'vBANDSC1',prop:'Visible'},{av:'cmbavDynamicfiltersoperator1'},{av:'dynavMoncod1'},{av:'AV61MonCod1',fld:'vMONCOD1',pic:'ZZZZZ9'},{av:'dynavMoncod2'},{av:'AV63MonCod2',fld:'vMONCOD2',pic:'ZZZZZ9'},{av:'dynavMoncod3'},{av:'AV65MonCod3',fld:'vMONCOD3',pic:'ZZZZZ9'}]}");
         setEventMetadata("'ADDDYNAMICFILTERS2'","{handler:'E211Z2',iparms:[{av:'dynavMoncod1'},{av:'AV61MonCod1',fld:'vMONCOD1',pic:'ZZZZZ9'},{av:'dynavMoncod2'},{av:'AV63MonCod2',fld:'vMONCOD2',pic:'ZZZZZ9'},{av:'dynavMoncod3'},{av:'AV65MonCod3',fld:'vMONCOD3',pic:'ZZZZZ9'}]");
         setEventMetadata("'ADDDYNAMICFILTERS2'",",oparms:[{av:'AV24DynamicFiltersEnabled3',fld:'vDYNAMICFILTERSENABLED3',pic:''},{av:'imgAdddynamicfilters2_Visible',ctrl:'ADDDYNAMICFILTERS2',prop:'Visible'},{av:'imgRemovedynamicfilters2_Visible',ctrl:'REMOVEDYNAMICFILTERS2',prop:'Visible'},{av:'dynavMoncod1'},{av:'AV61MonCod1',fld:'vMONCOD1',pic:'ZZZZZ9'},{av:'dynavMoncod2'},{av:'AV63MonCod2',fld:'vMONCOD2',pic:'ZZZZZ9'},{av:'dynavMoncod3'},{av:'AV65MonCod3',fld:'vMONCOD3',pic:'ZZZZZ9'}]}");
         setEventMetadata("'REMOVEDYNAMICFILTERS2'","{handler:'E161Z2',iparms:[{av:'GRID_nFirstRecordOnPage'},{av:'GRID_nEOF'},{av:'subGrid_Rows',ctrl:'GRID',prop:'Rows'},{av:'cmbavDynamicfiltersselector1'},{av:'AV15DynamicFiltersSelector1',fld:'vDYNAMICFILTERSSELECTOR1',pic:''},{av:'cmbavDynamicfiltersoperator1'},{av:'AV16DynamicFiltersOperator1',fld:'vDYNAMICFILTERSOPERATOR1',pic:'ZZZ9'},{av:'AV60BanDsc1',fld:'vBANDSC1',pic:''},{av:'cmbavDynamicfiltersselector2'},{av:'AV20DynamicFiltersSelector2',fld:'vDYNAMICFILTERSSELECTOR2',pic:''},{av:'cmbavDynamicfiltersoperator2'},{av:'AV21DynamicFiltersOperator2',fld:'vDYNAMICFILTERSOPERATOR2',pic:'ZZZ9'},{av:'AV62BanDsc2',fld:'vBANDSC2',pic:''},{av:'cmbavDynamicfiltersselector3'},{av:'AV25DynamicFiltersSelector3',fld:'vDYNAMICFILTERSSELECTOR3',pic:''},{av:'cmbavDynamicfiltersoperator3'},{av:'AV26DynamicFiltersOperator3',fld:'vDYNAMICFILTERSOPERATOR3',pic:'ZZZ9'},{av:'AV64BanDsc3',fld:'vBANDSC3',pic:''},{av:'AV74Pgmname',fld:'vPGMNAME',pic:'',hsh:true},{av:'AV19DynamicFiltersEnabled2',fld:'vDYNAMICFILTERSENABLED2',pic:''},{av:'AV24DynamicFiltersEnabled3',fld:'vDYNAMICFILTERSENABLED3',pic:''},{av:'AV66TFBanDsc',fld:'vTFBANDSC',pic:''},{av:'AV67TFBanDsc_Sel',fld:'vTFBANDSC_SEL',pic:''},{av:'AV36TFCBCod',fld:'vTFCBCOD',pic:''},{av:'AV37TFCBCod_Sel',fld:'vTFCBCOD_SEL',pic:''},{av:'AV68TFMonDsc',fld:'vTFMONDSC',pic:''},{av:'AV69TFMonDsc_Sel',fld:'vTFMONDSC_SEL',pic:''},{av:'AV42TFCBSts',fld:'vTFCBSTS',pic:'9'},{av:'AV43TFCBSts_To',fld:'vTFCBSTS_TO',pic:'9'},{av:'AV13OrderedBy',fld:'vORDEREDBY',pic:'ZZZ9'},{av:'AV14OrderedDsc',fld:'vORDEREDDSC',pic:''},{av:'AV10GridState',fld:'vGRIDSTATE',pic:''},{av:'AV30DynamicFiltersIgnoreFirst',fld:'vDYNAMICFILTERSIGNOREFIRST',pic:''},{av:'AV29DynamicFiltersRemoving',fld:'vDYNAMICFILTERSREMOVING',pic:''},{av:'dynavMoncod1'},{av:'AV61MonCod1',fld:'vMONCOD1',pic:'ZZZZZ9'},{av:'dynavMoncod2'},{av:'AV63MonCod2',fld:'vMONCOD2',pic:'ZZZZZ9'},{av:'dynavMoncod3'},{av:'AV65MonCod3',fld:'vMONCOD3',pic:'ZZZZZ9'}]");
         setEventMetadata("'REMOVEDYNAMICFILTERS2'",",oparms:[{av:'AV29DynamicFiltersRemoving',fld:'vDYNAMICFILTERSREMOVING',pic:''},{av:'AV19DynamicFiltersEnabled2',fld:'vDYNAMICFILTERSENABLED2',pic:''},{av:'AV10GridState',fld:'vGRIDSTATE',pic:''},{av:'cmbavDynamicfiltersselector2'},{av:'AV20DynamicFiltersSelector2',fld:'vDYNAMICFILTERSSELECTOR2',pic:''},{av:'cmbavDynamicfiltersoperator2'},{av:'AV21DynamicFiltersOperator2',fld:'vDYNAMICFILTERSOPERATOR2',pic:'ZZZ9'},{av:'AV62BanDsc2',fld:'vBANDSC2',pic:''},{av:'AV24DynamicFiltersEnabled3',fld:'vDYNAMICFILTERSENABLED3',pic:''},{av:'cmbavDynamicfiltersselector3'},{av:'AV25DynamicFiltersSelector3',fld:'vDYNAMICFILTERSSELECTOR3',pic:''},{av:'cmbavDynamicfiltersoperator3'},{av:'AV26DynamicFiltersOperator3',fld:'vDYNAMICFILTERSOPERATOR3',pic:'ZZZ9'},{av:'AV64BanDsc3',fld:'vBANDSC3',pic:''},{av:'imgAdddynamicfilters1_Visible',ctrl:'ADDDYNAMICFILTERS1',prop:'Visible'},{av:'imgRemovedynamicfilters1_Visible',ctrl:'REMOVEDYNAMICFILTERS1',prop:'Visible'},{av:'imgAdddynamicfilters2_Visible',ctrl:'ADDDYNAMICFILTERS2',prop:'Visible'},{av:'imgRemovedynamicfilters2_Visible',ctrl:'REMOVEDYNAMICFILTERS2',prop:'Visible'},{av:'cmbavDynamicfiltersselector1'},{av:'AV15DynamicFiltersSelector1',fld:'vDYNAMICFILTERSSELECTOR1',pic:''},{av:'cmbavDynamicfiltersoperator1'},{av:'AV16DynamicFiltersOperator1',fld:'vDYNAMICFILTERSOPERATOR1',pic:'ZZZ9'},{av:'AV60BanDsc1',fld:'vBANDSC1',pic:''},{av:'lblJsdynamicfilters_Caption',ctrl:'JSDYNAMICFILTERS',prop:'Caption'},{av:'edtavBandsc2_Visible',ctrl:'vBANDSC2',prop:'Visible'},{av:'edtavBandsc3_Visible',ctrl:'vBANDSC3',prop:'Visible'},{av:'edtavBandsc1_Visible',ctrl:'vBANDSC1',prop:'Visible'},{av:'AV54GridCurrentPage',fld:'vGRIDCURRENTPAGE',pic:'ZZZZZZZZZ9'},{av:'AV55GridPageCount',fld:'vGRIDPAGECOUNT',pic:'ZZZZZZZZZ9'},{av:'AV56GridAppliedFilters',fld:'vGRIDAPPLIEDFILTERS',pic:''},{av:'dynavMoncod1'},{av:'AV61MonCod1',fld:'vMONCOD1',pic:'ZZZZZ9'},{av:'dynavMoncod2'},{av:'AV63MonCod2',fld:'vMONCOD2',pic:'ZZZZZ9'},{av:'dynavMoncod3'},{av:'AV65MonCod3',fld:'vMONCOD3',pic:'ZZZZZ9'}]}");
         setEventMetadata("VDYNAMICFILTERSSELECTOR2.CLICK","{handler:'E221Z2',iparms:[{av:'cmbavDynamicfiltersselector2'},{av:'AV20DynamicFiltersSelector2',fld:'vDYNAMICFILTERSSELECTOR2',pic:''},{av:'dynavMoncod1'},{av:'AV61MonCod1',fld:'vMONCOD1',pic:'ZZZZZ9'},{av:'dynavMoncod2'},{av:'AV63MonCod2',fld:'vMONCOD2',pic:'ZZZZZ9'},{av:'dynavMoncod3'},{av:'AV65MonCod3',fld:'vMONCOD3',pic:'ZZZZZ9'}]");
         setEventMetadata("VDYNAMICFILTERSSELECTOR2.CLICK",",oparms:[{av:'edtavBandsc2_Visible',ctrl:'vBANDSC2',prop:'Visible'},{av:'cmbavDynamicfiltersoperator2'},{av:'dynavMoncod1'},{av:'AV61MonCod1',fld:'vMONCOD1',pic:'ZZZZZ9'},{av:'dynavMoncod2'},{av:'AV63MonCod2',fld:'vMONCOD2',pic:'ZZZZZ9'},{av:'dynavMoncod3'},{av:'AV65MonCod3',fld:'vMONCOD3',pic:'ZZZZZ9'}]}");
         setEventMetadata("'REMOVEDYNAMICFILTERS3'","{handler:'E171Z2',iparms:[{av:'GRID_nFirstRecordOnPage'},{av:'GRID_nEOF'},{av:'subGrid_Rows',ctrl:'GRID',prop:'Rows'},{av:'cmbavDynamicfiltersselector1'},{av:'AV15DynamicFiltersSelector1',fld:'vDYNAMICFILTERSSELECTOR1',pic:''},{av:'cmbavDynamicfiltersoperator1'},{av:'AV16DynamicFiltersOperator1',fld:'vDYNAMICFILTERSOPERATOR1',pic:'ZZZ9'},{av:'AV60BanDsc1',fld:'vBANDSC1',pic:''},{av:'cmbavDynamicfiltersselector2'},{av:'AV20DynamicFiltersSelector2',fld:'vDYNAMICFILTERSSELECTOR2',pic:''},{av:'cmbavDynamicfiltersoperator2'},{av:'AV21DynamicFiltersOperator2',fld:'vDYNAMICFILTERSOPERATOR2',pic:'ZZZ9'},{av:'AV62BanDsc2',fld:'vBANDSC2',pic:''},{av:'cmbavDynamicfiltersselector3'},{av:'AV25DynamicFiltersSelector3',fld:'vDYNAMICFILTERSSELECTOR3',pic:''},{av:'cmbavDynamicfiltersoperator3'},{av:'AV26DynamicFiltersOperator3',fld:'vDYNAMICFILTERSOPERATOR3',pic:'ZZZ9'},{av:'AV64BanDsc3',fld:'vBANDSC3',pic:''},{av:'AV74Pgmname',fld:'vPGMNAME',pic:'',hsh:true},{av:'AV19DynamicFiltersEnabled2',fld:'vDYNAMICFILTERSENABLED2',pic:''},{av:'AV24DynamicFiltersEnabled3',fld:'vDYNAMICFILTERSENABLED3',pic:''},{av:'AV66TFBanDsc',fld:'vTFBANDSC',pic:''},{av:'AV67TFBanDsc_Sel',fld:'vTFBANDSC_SEL',pic:''},{av:'AV36TFCBCod',fld:'vTFCBCOD',pic:''},{av:'AV37TFCBCod_Sel',fld:'vTFCBCOD_SEL',pic:''},{av:'AV68TFMonDsc',fld:'vTFMONDSC',pic:''},{av:'AV69TFMonDsc_Sel',fld:'vTFMONDSC_SEL',pic:''},{av:'AV42TFCBSts',fld:'vTFCBSTS',pic:'9'},{av:'AV43TFCBSts_To',fld:'vTFCBSTS_TO',pic:'9'},{av:'AV13OrderedBy',fld:'vORDEREDBY',pic:'ZZZ9'},{av:'AV14OrderedDsc',fld:'vORDEREDDSC',pic:''},{av:'AV10GridState',fld:'vGRIDSTATE',pic:''},{av:'AV30DynamicFiltersIgnoreFirst',fld:'vDYNAMICFILTERSIGNOREFIRST',pic:''},{av:'AV29DynamicFiltersRemoving',fld:'vDYNAMICFILTERSREMOVING',pic:''},{av:'dynavMoncod1'},{av:'AV61MonCod1',fld:'vMONCOD1',pic:'ZZZZZ9'},{av:'dynavMoncod2'},{av:'AV63MonCod2',fld:'vMONCOD2',pic:'ZZZZZ9'},{av:'dynavMoncod3'},{av:'AV65MonCod3',fld:'vMONCOD3',pic:'ZZZZZ9'}]");
         setEventMetadata("'REMOVEDYNAMICFILTERS3'",",oparms:[{av:'AV29DynamicFiltersRemoving',fld:'vDYNAMICFILTERSREMOVING',pic:''},{av:'AV24DynamicFiltersEnabled3',fld:'vDYNAMICFILTERSENABLED3',pic:''},{av:'AV10GridState',fld:'vGRIDSTATE',pic:''},{av:'AV19DynamicFiltersEnabled2',fld:'vDYNAMICFILTERSENABLED2',pic:''},{av:'cmbavDynamicfiltersselector2'},{av:'AV20DynamicFiltersSelector2',fld:'vDYNAMICFILTERSSELECTOR2',pic:''},{av:'cmbavDynamicfiltersoperator2'},{av:'AV21DynamicFiltersOperator2',fld:'vDYNAMICFILTERSOPERATOR2',pic:'ZZZ9'},{av:'AV62BanDsc2',fld:'vBANDSC2',pic:''},{av:'cmbavDynamicfiltersselector3'},{av:'AV25DynamicFiltersSelector3',fld:'vDYNAMICFILTERSSELECTOR3',pic:''},{av:'cmbavDynamicfiltersoperator3'},{av:'AV26DynamicFiltersOperator3',fld:'vDYNAMICFILTERSOPERATOR3',pic:'ZZZ9'},{av:'AV64BanDsc3',fld:'vBANDSC3',pic:''},{av:'imgAdddynamicfilters1_Visible',ctrl:'ADDDYNAMICFILTERS1',prop:'Visible'},{av:'imgRemovedynamicfilters1_Visible',ctrl:'REMOVEDYNAMICFILTERS1',prop:'Visible'},{av:'imgAdddynamicfilters2_Visible',ctrl:'ADDDYNAMICFILTERS2',prop:'Visible'},{av:'imgRemovedynamicfilters2_Visible',ctrl:'REMOVEDYNAMICFILTERS2',prop:'Visible'},{av:'cmbavDynamicfiltersselector1'},{av:'AV15DynamicFiltersSelector1',fld:'vDYNAMICFILTERSSELECTOR1',pic:''},{av:'cmbavDynamicfiltersoperator1'},{av:'AV16DynamicFiltersOperator1',fld:'vDYNAMICFILTERSOPERATOR1',pic:'ZZZ9'},{av:'AV60BanDsc1',fld:'vBANDSC1',pic:''},{av:'lblJsdynamicfilters_Caption',ctrl:'JSDYNAMICFILTERS',prop:'Caption'},{av:'edtavBandsc2_Visible',ctrl:'vBANDSC2',prop:'Visible'},{av:'edtavBandsc3_Visible',ctrl:'vBANDSC3',prop:'Visible'},{av:'edtavBandsc1_Visible',ctrl:'vBANDSC1',prop:'Visible'},{av:'AV54GridCurrentPage',fld:'vGRIDCURRENTPAGE',pic:'ZZZZZZZZZ9'},{av:'AV55GridPageCount',fld:'vGRIDPAGECOUNT',pic:'ZZZZZZZZZ9'},{av:'AV56GridAppliedFilters',fld:'vGRIDAPPLIEDFILTERS',pic:''},{av:'dynavMoncod1'},{av:'AV61MonCod1',fld:'vMONCOD1',pic:'ZZZZZ9'},{av:'dynavMoncod2'},{av:'AV63MonCod2',fld:'vMONCOD2',pic:'ZZZZZ9'},{av:'dynavMoncod3'},{av:'AV65MonCod3',fld:'vMONCOD3',pic:'ZZZZZ9'}]}");
         setEventMetadata("VDYNAMICFILTERSSELECTOR3.CLICK","{handler:'E231Z2',iparms:[{av:'cmbavDynamicfiltersselector3'},{av:'AV25DynamicFiltersSelector3',fld:'vDYNAMICFILTERSSELECTOR3',pic:''},{av:'dynavMoncod1'},{av:'AV61MonCod1',fld:'vMONCOD1',pic:'ZZZZZ9'},{av:'dynavMoncod2'},{av:'AV63MonCod2',fld:'vMONCOD2',pic:'ZZZZZ9'},{av:'dynavMoncod3'},{av:'AV65MonCod3',fld:'vMONCOD3',pic:'ZZZZZ9'}]");
         setEventMetadata("VDYNAMICFILTERSSELECTOR3.CLICK",",oparms:[{av:'edtavBandsc3_Visible',ctrl:'vBANDSC3',prop:'Visible'},{av:'cmbavDynamicfiltersoperator3'},{av:'dynavMoncod1'},{av:'AV61MonCod1',fld:'vMONCOD1',pic:'ZZZZZ9'},{av:'dynavMoncod2'},{av:'AV63MonCod2',fld:'vMONCOD2',pic:'ZZZZZ9'},{av:'dynavMoncod3'},{av:'AV65MonCod3',fld:'vMONCOD3',pic:'ZZZZZ9'}]}");
         setEventMetadata("VGRIDACTIONS.CLICK","{handler:'E271Z2',iparms:[{av:'cmbavGridactions'},{av:'AV57GridActions',fld:'vGRIDACTIONS',pic:'ZZZ9'},{av:'A372BanCod',fld:'BANCOD',pic:'ZZZZZ9',hsh:true},{av:'A377CBCod',fld:'CBCOD',pic:'',hsh:true},{av:'dynavMoncod1'},{av:'AV61MonCod1',fld:'vMONCOD1',pic:'ZZZZZ9'},{av:'dynavMoncod2'},{av:'AV63MonCod2',fld:'vMONCOD2',pic:'ZZZZZ9'},{av:'dynavMoncod3'},{av:'AV65MonCod3',fld:'vMONCOD3',pic:'ZZZZZ9'}]");
         setEventMetadata("VGRIDACTIONS.CLICK",",oparms:[{av:'cmbavGridactions'},{av:'AV57GridActions',fld:'vGRIDACTIONS',pic:'ZZZ9'},{av:'dynavMoncod1'},{av:'AV61MonCod1',fld:'vMONCOD1',pic:'ZZZZZ9'},{av:'dynavMoncod2'},{av:'AV63MonCod2',fld:'vMONCOD2',pic:'ZZZZZ9'},{av:'dynavMoncod3'},{av:'AV65MonCod3',fld:'vMONCOD3',pic:'ZZZZZ9'}]}");
         setEventMetadata("'DOINSERT'","{handler:'E181Z2',iparms:[{av:'A372BanCod',fld:'BANCOD',pic:'ZZZZZ9',hsh:true},{av:'A377CBCod',fld:'CBCOD',pic:'',hsh:true},{av:'dynavMoncod1'},{av:'AV61MonCod1',fld:'vMONCOD1',pic:'ZZZZZ9'},{av:'dynavMoncod2'},{av:'AV63MonCod2',fld:'vMONCOD2',pic:'ZZZZZ9'},{av:'dynavMoncod3'},{av:'AV65MonCod3',fld:'vMONCOD3',pic:'ZZZZZ9'}]");
         setEventMetadata("'DOINSERT'",",oparms:[{av:'dynavMoncod1'},{av:'AV61MonCod1',fld:'vMONCOD1',pic:'ZZZZZ9'},{av:'dynavMoncod2'},{av:'AV63MonCod2',fld:'vMONCOD2',pic:'ZZZZZ9'},{av:'dynavMoncod3'},{av:'AV65MonCod3',fld:'vMONCOD3',pic:'ZZZZZ9'}]}");
         setEventMetadata("DDO_AGEXPORT.ONOPTIONCLICKED","{handler:'E131Z2',iparms:[{av:'Ddo_agexport_Activeeventkey',ctrl:'DDO_AGEXPORT',prop:'ActiveEventKey'},{av:'AV74Pgmname',fld:'vPGMNAME',pic:'',hsh:true},{av:'AV67TFBanDsc_Sel',fld:'vTFBANDSC_SEL',pic:''},{av:'AV37TFCBCod_Sel',fld:'vTFCBCOD_SEL',pic:''},{av:'AV69TFMonDsc_Sel',fld:'vTFMONDSC_SEL',pic:''},{av:'AV66TFBanDsc',fld:'vTFBANDSC',pic:''},{av:'AV36TFCBCod',fld:'vTFCBCOD',pic:''},{av:'AV68TFMonDsc',fld:'vTFMONDSC',pic:''},{av:'AV42TFCBSts',fld:'vTFCBSTS',pic:'9'},{av:'AV43TFCBSts_To',fld:'vTFCBSTS_TO',pic:'9'},{av:'AV13OrderedBy',fld:'vORDEREDBY',pic:'ZZZ9'},{av:'AV14OrderedDsc',fld:'vORDEREDDSC',pic:''},{av:'AV10GridState',fld:'vGRIDSTATE',pic:''},{av:'AV29DynamicFiltersRemoving',fld:'vDYNAMICFILTERSREMOVING',pic:''},{av:'cmbavDynamicfiltersselector1'},{av:'AV15DynamicFiltersSelector1',fld:'vDYNAMICFILTERSSELECTOR1',pic:''},{av:'cmbavDynamicfiltersselector2'},{av:'AV20DynamicFiltersSelector2',fld:'vDYNAMICFILTERSSELECTOR2',pic:''},{av:'cmbavDynamicfiltersselector3'},{av:'AV25DynamicFiltersSelector3',fld:'vDYNAMICFILTERSSELECTOR3',pic:''},{av:'dynavMoncod1'},{av:'AV61MonCod1',fld:'vMONCOD1',pic:'ZZZZZ9'},{av:'dynavMoncod2'},{av:'AV63MonCod2',fld:'vMONCOD2',pic:'ZZZZZ9'},{av:'dynavMoncod3'},{av:'AV65MonCod3',fld:'vMONCOD3',pic:'ZZZZZ9'}]");
         setEventMetadata("DDO_AGEXPORT.ONOPTIONCLICKED",",oparms:[{av:'Innewwindow1_Target',ctrl:'INNEWWINDOW1',prop:'Target'},{av:'Innewwindow1_Height',ctrl:'INNEWWINDOW1',prop:'Height'},{av:'Innewwindow1_Width',ctrl:'INNEWWINDOW1',prop:'Width'},{av:'AV10GridState',fld:'vGRIDSTATE',pic:''},{av:'AV13OrderedBy',fld:'vORDEREDBY',pic:'ZZZ9'},{av:'AV14OrderedDsc',fld:'vORDEREDDSC',pic:''},{av:'AV42TFCBSts',fld:'vTFCBSTS',pic:'9'},{av:'AV43TFCBSts_To',fld:'vTFCBSTS_TO',pic:'9'},{av:'AV69TFMonDsc_Sel',fld:'vTFMONDSC_SEL',pic:''},{av:'AV68TFMonDsc',fld:'vTFMONDSC',pic:''},{av:'AV37TFCBCod_Sel',fld:'vTFCBCOD_SEL',pic:''},{av:'AV36TFCBCod',fld:'vTFCBCOD',pic:''},{av:'AV67TFBanDsc_Sel',fld:'vTFBANDSC_SEL',pic:''},{av:'AV66TFBanDsc',fld:'vTFBANDSC',pic:''},{av:'Ddo_grid_Selectedvalue_set',ctrl:'DDO_GRID',prop:'SelectedValue_set'},{av:'Ddo_grid_Filteredtext_set',ctrl:'DDO_GRID',prop:'FilteredText_set'},{av:'Ddo_grid_Filteredtextto_set',ctrl:'DDO_GRID',prop:'FilteredTextTo_set'},{av:'subGrid_Rows',ctrl:'GRID',prop:'Rows'},{av:'GRID_nFirstRecordOnPage'},{av:'GRID_nEOF'},{av:'cmbavDynamicfiltersselector1'},{av:'AV15DynamicFiltersSelector1',fld:'vDYNAMICFILTERSSELECTOR1',pic:''},{av:'cmbavDynamicfiltersoperator1'},{av:'AV16DynamicFiltersOperator1',fld:'vDYNAMICFILTERSOPERATOR1',pic:'ZZZ9'},{av:'AV60BanDsc1',fld:'vBANDSC1',pic:''},{av:'cmbavDynamicfiltersselector2'},{av:'AV20DynamicFiltersSelector2',fld:'vDYNAMICFILTERSSELECTOR2',pic:''},{av:'cmbavDynamicfiltersoperator2'},{av:'AV21DynamicFiltersOperator2',fld:'vDYNAMICFILTERSOPERATOR2',pic:'ZZZ9'},{av:'AV62BanDsc2',fld:'vBANDSC2',pic:''},{av:'cmbavDynamicfiltersselector3'},{av:'AV25DynamicFiltersSelector3',fld:'vDYNAMICFILTERSSELECTOR3',pic:''},{av:'cmbavDynamicfiltersoperator3'},{av:'AV26DynamicFiltersOperator3',fld:'vDYNAMICFILTERSOPERATOR3',pic:'ZZZ9'},{av:'AV64BanDsc3',fld:'vBANDSC3',pic:''},{av:'AV74Pgmname',fld:'vPGMNAME',pic:'',hsh:true},{av:'AV19DynamicFiltersEnabled2',fld:'vDYNAMICFILTERSENABLED2',pic:''},{av:'AV24DynamicFiltersEnabled3',fld:'vDYNAMICFILTERSENABLED3',pic:''},{av:'AV30DynamicFiltersIgnoreFirst',fld:'vDYNAMICFILTERSIGNOREFIRST',pic:''},{av:'AV29DynamicFiltersRemoving',fld:'vDYNAMICFILTERSREMOVING',pic:''},{av:'Ddo_grid_Sortedstatus',ctrl:'DDO_GRID',prop:'SortedStatus'},{av:'imgAdddynamicfilters1_Visible',ctrl:'ADDDYNAMICFILTERS1',prop:'Visible'},{av:'imgRemovedynamicfilters1_Visible',ctrl:'REMOVEDYNAMICFILTERS1',prop:'Visible'},{av:'imgAdddynamicfilters2_Visible',ctrl:'ADDDYNAMICFILTERS2',prop:'Visible'},{av:'imgRemovedynamicfilters2_Visible',ctrl:'REMOVEDYNAMICFILTERS2',prop:'Visible'},{av:'lblJsdynamicfilters_Caption',ctrl:'JSDYNAMICFILTERS',prop:'Caption'},{av:'edtavBandsc1_Visible',ctrl:'vBANDSC1',prop:'Visible'},{av:'edtavBandsc2_Visible',ctrl:'vBANDSC2',prop:'Visible'},{av:'edtavBandsc3_Visible',ctrl:'vBANDSC3',prop:'Visible'},{av:'dynavMoncod1'},{av:'AV61MonCod1',fld:'vMONCOD1',pic:'ZZZZZ9'},{av:'dynavMoncod2'},{av:'AV63MonCod2',fld:'vMONCOD2',pic:'ZZZZZ9'},{av:'dynavMoncod3'},{av:'AV65MonCod3',fld:'vMONCOD3',pic:'ZZZZZ9'}]}");
         setEventMetadata("VALID_BANCOD","{handler:'Valid_Bancod',iparms:[{av:'dynavMoncod1'},{av:'AV61MonCod1',fld:'vMONCOD1',pic:'ZZZZZ9'},{av:'dynavMoncod2'},{av:'AV63MonCod2',fld:'vMONCOD2',pic:'ZZZZZ9'},{av:'dynavMoncod3'},{av:'AV65MonCod3',fld:'vMONCOD3',pic:'ZZZZZ9'}]");
         setEventMetadata("VALID_BANCOD",",oparms:[{av:'dynavMoncod1'},{av:'AV61MonCod1',fld:'vMONCOD1',pic:'ZZZZZ9'},{av:'dynavMoncod2'},{av:'AV63MonCod2',fld:'vMONCOD2',pic:'ZZZZZ9'},{av:'dynavMoncod3'},{av:'AV65MonCod3',fld:'vMONCOD3',pic:'ZZZZZ9'}]}");
         setEventMetadata("VALID_MONCOD","{handler:'Valid_Moncod',iparms:[{av:'dynavMoncod1'},{av:'AV61MonCod1',fld:'vMONCOD1',pic:'ZZZZZ9'},{av:'dynavMoncod2'},{av:'AV63MonCod2',fld:'vMONCOD2',pic:'ZZZZZ9'},{av:'dynavMoncod3'},{av:'AV65MonCod3',fld:'vMONCOD3',pic:'ZZZZZ9'}]");
         setEventMetadata("VALID_MONCOD",",oparms:[{av:'dynavMoncod1'},{av:'AV61MonCod1',fld:'vMONCOD1',pic:'ZZZZZ9'},{av:'dynavMoncod2'},{av:'AV63MonCod2',fld:'vMONCOD2',pic:'ZZZZZ9'},{av:'dynavMoncod3'},{av:'AV65MonCod3',fld:'vMONCOD3',pic:'ZZZZZ9'}]}");
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
         AV60BanDsc1 = "";
         AV20DynamicFiltersSelector2 = "";
         AV62BanDsc2 = "";
         AV25DynamicFiltersSelector3 = "";
         AV64BanDsc3 = "";
         AV74Pgmname = "";
         AV66TFBanDsc = "";
         AV67TFBanDsc_Sel = "";
         AV36TFCBCod = "";
         AV37TFCBCod_Sel = "";
         AV68TFMonDsc = "";
         AV69TFMonDsc_Sel = "";
         AV10GridState = new GeneXus.Programs.wwpbaseobjects.SdtWWPGridState(context);
         sDynURL = "";
         FormProcess = "";
         bodyStyle = "";
         GXKey = "";
         AV56GridAppliedFilters = "";
         AV58AGExportData = new GXBaseCollection<GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTDropDownOptionsData_Item>( context, "Item", "");
         AV52DDO_TitleSettingsIcons = new GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTDropDownOptionsTitleSettingsIcons(context);
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
         A482BanDsc = "";
         A377CBCod = "";
         A1234MonDsc = "";
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
         gxdynajaxctrlcodr = new GeneXus.Utils.GxStringCollection();
         gxdynajaxctrldescr = new GeneXus.Utils.GxStringCollection();
         gxwrpcisep = "";
         scmdbuf = "";
         H001Z2_A180MonCod = new int[1] ;
         H001Z2_A1234MonDsc = new string[] {""} ;
         H001Z2_A1235MonSts = new short[1] ;
         H001Z3_A180MonCod = new int[1] ;
         H001Z3_A1234MonDsc = new string[] {""} ;
         H001Z3_A1235MonSts = new short[1] ;
         H001Z4_A180MonCod = new int[1] ;
         H001Z4_A1234MonDsc = new string[] {""} ;
         H001Z4_A1235MonSts = new short[1] ;
         lV77Bancos_cuentabancoswwds_3_bandsc1 = "";
         lV82Bancos_cuentabancoswwds_8_bandsc2 = "";
         lV87Bancos_cuentabancoswwds_13_bandsc3 = "";
         lV89Bancos_cuentabancoswwds_15_tfbandsc = "";
         lV91Bancos_cuentabancoswwds_17_tfcbcod = "";
         lV93Bancos_cuentabancoswwds_19_tfmondsc = "";
         AV75Bancos_cuentabancoswwds_1_dynamicfiltersselector1 = "";
         AV77Bancos_cuentabancoswwds_3_bandsc1 = "";
         AV80Bancos_cuentabancoswwds_6_dynamicfiltersselector2 = "";
         AV82Bancos_cuentabancoswwds_8_bandsc2 = "";
         AV85Bancos_cuentabancoswwds_11_dynamicfiltersselector3 = "";
         AV87Bancos_cuentabancoswwds_13_bandsc3 = "";
         AV90Bancos_cuentabancoswwds_16_tfbandsc_sel = "";
         AV89Bancos_cuentabancoswwds_15_tfbandsc = "";
         AV92Bancos_cuentabancoswwds_18_tfcbcod_sel = "";
         AV91Bancos_cuentabancoswwds_17_tfcbcod = "";
         AV94Bancos_cuentabancoswwds_20_tfmondsc_sel = "";
         AV93Bancos_cuentabancoswwds_19_tfmondsc = "";
         H001Z5_A180MonCod = new int[1] ;
         H001Z5_A372BanCod = new int[1] ;
         H001Z5_A504CBSts = new short[1] ;
         H001Z5_A1234MonDsc = new string[] {""} ;
         H001Z5_A377CBCod = new string[] {""} ;
         H001Z5_A482BanDsc = new string[] {""} ;
         H001Z6_AGRID_nRecordCount = new long[1] ;
         imgAdddynamicfilters1_Jsonclick = "";
         imgRemovedynamicfilters1_Jsonclick = "";
         imgAdddynamicfilters2_Jsonclick = "";
         imgRemovedynamicfilters2_Jsonclick = "";
         imgRemovedynamicfilters3_Jsonclick = "";
         AV59AGExportDataItem = new GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTDropDownOptionsData_Item(context);
         GXt_SdtDVB_SDTDropDownOptionsTitleSettingsIcons1 = new GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTDropDownOptionsTitleSettingsIcons(context);
         AV6WWPContext = new GeneXus.Programs.wwpbaseobjects.SdtWWPContext(context);
         GXEncryptionTmp = "";
         GridRow = new GXWebRow();
         AV33Session = context.GetSession();
         AV11GridStateFilterValue = new GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue(context);
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
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.bancos.cuentabancosww__default(),
            new Object[][] {
                new Object[] {
               H001Z2_A180MonCod, H001Z2_A1234MonDsc, H001Z2_A1235MonSts
               }
               , new Object[] {
               H001Z3_A180MonCod, H001Z3_A1234MonDsc, H001Z3_A1235MonSts
               }
               , new Object[] {
               H001Z4_A180MonCod, H001Z4_A1234MonDsc, H001Z4_A1235MonSts
               }
               , new Object[] {
               H001Z5_A180MonCod, H001Z5_A372BanCod, H001Z5_A504CBSts, H001Z5_A1234MonDsc, H001Z5_A377CBCod, H001Z5_A482BanDsc
               }
               , new Object[] {
               H001Z6_AGRID_nRecordCount
               }
            }
         );
         AV74Pgmname = "Bancos.CuentaBancosWW";
         /* GeneXus formulas. */
         AV74Pgmname = "Bancos.CuentaBancosWW";
         context.Gx_err = 0;
      }

      private short GRID_nEOF ;
      private short nGotPars ;
      private short GxWebError ;
      private short AV16DynamicFiltersOperator1 ;
      private short AV21DynamicFiltersOperator2 ;
      private short AV26DynamicFiltersOperator3 ;
      private short AV42TFCBSts ;
      private short AV43TFCBSts_To ;
      private short AV13OrderedBy ;
      private short initialized ;
      private short gxajaxcallmode ;
      private short wbEnd ;
      private short wbStart ;
      private short subGrid_Backcolorstyle ;
      private short subGrid_Titlebackstyle ;
      private short subGrid_Sortable ;
      private short AV57GridActions ;
      private short A504CBSts ;
      private short subGrid_Allowselection ;
      private short subGrid_Allowhovering ;
      private short subGrid_Allowcollapsing ;
      private short subGrid_Collapsed ;
      private short nDonePA ;
      private short AV76Bancos_cuentabancoswwds_2_dynamicfiltersoperator1 ;
      private short AV81Bancos_cuentabancoswwds_7_dynamicfiltersoperator2 ;
      private short AV86Bancos_cuentabancoswwds_12_dynamicfiltersoperator3 ;
      private short AV95Bancos_cuentabancoswwds_21_tfcbsts ;
      private short AV96Bancos_cuentabancoswwds_22_tfcbsts_to ;
      private short nGXWrapped ;
      private short subGrid_Backstyle ;
      private int subGrid_Rows ;
      private int Gridpaginationbar_Rowsperpageselectedvalue ;
      private int nRC_GXsfl_110 ;
      private int nGXsfl_110_idx=1 ;
      private int AV61MonCod1 ;
      private int AV63MonCod2 ;
      private int AV65MonCod3 ;
      private int Gridpaginationbar_Pagestoshow ;
      private int subGrid_Titlebackcolor ;
      private int subGrid_Allbackcolor ;
      private int A372BanCod ;
      private int A180MonCod ;
      private int subGrid_Selectedindex ;
      private int subGrid_Selectioncolor ;
      private int subGrid_Hoveringcolor ;
      private int gxdynajaxindex ;
      private int subGrid_Islastpage ;
      private int GXPagingFrom2 ;
      private int GXPagingTo2 ;
      private int AV78Bancos_cuentabancoswwds_4_moncod1 ;
      private int AV83Bancos_cuentabancoswwds_9_moncod2 ;
      private int AV88Bancos_cuentabancoswwds_14_moncod3 ;
      private int AV53PageToGo ;
      private int imgAdddynamicfilters1_Visible ;
      private int imgRemovedynamicfilters1_Visible ;
      private int imgAdddynamicfilters2_Visible ;
      private int imgRemovedynamicfilters2_Visible ;
      private int edtavBandsc1_Visible ;
      private int edtavBandsc2_Visible ;
      private int edtavBandsc3_Visible ;
      private int AV97GXV1 ;
      private int edtavBandsc3_Enabled ;
      private int edtavBandsc2_Enabled ;
      private int edtavBandsc1_Enabled ;
      private int idxLst ;
      private int subGrid_Backcolor ;
      private long GRID_nFirstRecordOnPage ;
      private long AV54GridCurrentPage ;
      private long AV55GridPageCount ;
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
      private string AV60BanDsc1 ;
      private string AV62BanDsc2 ;
      private string AV64BanDsc3 ;
      private string AV74Pgmname ;
      private string AV66TFBanDsc ;
      private string AV67TFBanDsc_Sel ;
      private string AV36TFCBCod ;
      private string AV37TFCBCod_Sel ;
      private string AV68TFMonDsc ;
      private string AV69TFMonDsc_Sel ;
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
      private string A482BanDsc ;
      private string edtBanDsc_Link ;
      private string A377CBCod ;
      private string A1234MonDsc ;
      private string edtMonDsc_Link ;
      private string edtCBSts_Link ;
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
      private string edtBanDsc_Internalname ;
      private string edtCBCod_Internalname ;
      private string edtMonDsc_Internalname ;
      private string edtCBSts_Internalname ;
      private string edtBanCod_Internalname ;
      private string edtMonCod_Internalname ;
      private string cmbavDynamicfiltersselector1_Internalname ;
      private string gxwrpcisep ;
      private string scmdbuf ;
      private string cmbavDynamicfiltersoperator1_Internalname ;
      private string dynavMoncod1_Internalname ;
      private string cmbavDynamicfiltersselector2_Internalname ;
      private string cmbavDynamicfiltersoperator2_Internalname ;
      private string dynavMoncod2_Internalname ;
      private string cmbavDynamicfiltersselector3_Internalname ;
      private string cmbavDynamicfiltersoperator3_Internalname ;
      private string dynavMoncod3_Internalname ;
      private string lV77Bancos_cuentabancoswwds_3_bandsc1 ;
      private string lV82Bancos_cuentabancoswwds_8_bandsc2 ;
      private string lV87Bancos_cuentabancoswwds_13_bandsc3 ;
      private string lV89Bancos_cuentabancoswwds_15_tfbandsc ;
      private string lV91Bancos_cuentabancoswwds_17_tfcbcod ;
      private string lV93Bancos_cuentabancoswwds_19_tfmondsc ;
      private string AV77Bancos_cuentabancoswwds_3_bandsc1 ;
      private string AV82Bancos_cuentabancoswwds_8_bandsc2 ;
      private string AV87Bancos_cuentabancoswwds_13_bandsc3 ;
      private string AV90Bancos_cuentabancoswwds_16_tfbandsc_sel ;
      private string AV89Bancos_cuentabancoswwds_15_tfbandsc ;
      private string AV92Bancos_cuentabancoswwds_18_tfcbcod_sel ;
      private string AV91Bancos_cuentabancoswwds_17_tfcbcod ;
      private string AV94Bancos_cuentabancoswwds_20_tfmondsc_sel ;
      private string AV93Bancos_cuentabancoswwds_19_tfmondsc ;
      private string edtavBandsc1_Internalname ;
      private string edtavBandsc2_Internalname ;
      private string edtavBandsc3_Internalname ;
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
      private string cellFilter_bandsc3_cell_Internalname ;
      private string edtavBandsc3_Jsonclick ;
      private string cellFilter_moncod3_cell_Internalname ;
      private string dynavMoncod3_Jsonclick ;
      private string cellDynamicfilters_removefilter3_cell_Internalname ;
      private string sImgUrl ;
      private string tblTablemergeddynamicfilters2_Internalname ;
      private string cmbavDynamicfiltersoperator2_Jsonclick ;
      private string cellFilter_bandsc2_cell_Internalname ;
      private string edtavBandsc2_Jsonclick ;
      private string cellFilter_moncod2_cell_Internalname ;
      private string dynavMoncod2_Jsonclick ;
      private string cellDynamicfilters_addfilter2_cell_Internalname ;
      private string cellDynamicfilters_removefilter2_cell_Internalname ;
      private string tblTablemergeddynamicfilters1_Internalname ;
      private string cmbavDynamicfiltersoperator1_Jsonclick ;
      private string cellFilter_bandsc1_cell_Internalname ;
      private string edtavBandsc1_Jsonclick ;
      private string cellFilter_moncod1_cell_Internalname ;
      private string dynavMoncod1_Jsonclick ;
      private string cellDynamicfilters_addfilter1_cell_Internalname ;
      private string cellDynamicfilters_removefilter1_cell_Internalname ;
      private string sGXsfl_110_fel_idx="0001" ;
      private string GXCCtl ;
      private string cmbavGridactions_Jsonclick ;
      private string ROClassString ;
      private string edtBanDsc_Jsonclick ;
      private string edtCBCod_Jsonclick ;
      private string edtMonDsc_Jsonclick ;
      private string edtCBSts_Jsonclick ;
      private string edtBanCod_Jsonclick ;
      private string edtMonCod_Jsonclick ;
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
      private bool gxdyncontrolsrefreshing ;
      private bool bGXsfl_110_Refreshing=false ;
      private bool AV79Bancos_cuentabancoswwds_5_dynamicfiltersenabled2 ;
      private bool AV84Bancos_cuentabancoswwds_10_dynamicfiltersenabled3 ;
      private bool returnInSub ;
      private bool gx_refresh_fired ;
      private string AV15DynamicFiltersSelector1 ;
      private string AV20DynamicFiltersSelector2 ;
      private string AV25DynamicFiltersSelector3 ;
      private string AV56GridAppliedFilters ;
      private string AV75Bancos_cuentabancoswwds_1_dynamicfiltersselector1 ;
      private string AV80Bancos_cuentabancoswwds_6_dynamicfiltersselector2 ;
      private string AV85Bancos_cuentabancoswwds_11_dynamicfiltersselector3 ;
      private string AV31ExcelFilename ;
      private string AV32ErrorMessage ;
      private IGxSession AV33Session ;
      private GeneXus.Utils.GxStringCollection gxdynajaxctrlcodr ;
      private GeneXus.Utils.GxStringCollection gxdynajaxctrldescr ;
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
      private GXCombobox dynavMoncod1 ;
      private GXCombobox cmbavDynamicfiltersselector2 ;
      private GXCombobox cmbavDynamicfiltersoperator2 ;
      private GXCombobox dynavMoncod2 ;
      private GXCombobox cmbavDynamicfiltersselector3 ;
      private GXCombobox cmbavDynamicfiltersoperator3 ;
      private GXCombobox dynavMoncod3 ;
      private GXCombobox cmbavGridactions ;
      private IDataStoreProvider pr_default ;
      private int[] H001Z2_A180MonCod ;
      private string[] H001Z2_A1234MonDsc ;
      private short[] H001Z2_A1235MonSts ;
      private int[] H001Z3_A180MonCod ;
      private string[] H001Z3_A1234MonDsc ;
      private short[] H001Z3_A1235MonSts ;
      private int[] H001Z4_A180MonCod ;
      private string[] H001Z4_A1234MonDsc ;
      private short[] H001Z4_A1235MonSts ;
      private int[] H001Z5_A180MonCod ;
      private int[] H001Z5_A372BanCod ;
      private short[] H001Z5_A504CBSts ;
      private string[] H001Z5_A1234MonDsc ;
      private string[] H001Z5_A377CBCod ;
      private string[] H001Z5_A482BanDsc ;
      private long[] H001Z6_AGRID_nRecordCount ;
      private msglist BackMsgLst ;
      private msglist LclMsgLst ;
      private GxHttpRequest AV7HTTPRequest ;
      private GXBaseCollection<GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTDropDownOptionsData_Item> AV58AGExportData ;
      private GXWebForm Form ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPContext AV6WWPContext ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPTransactionContext AV8TrnContext ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPGridState AV10GridState ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue AV11GridStateFilterValue ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter AV12GridStateDynamicFilter ;
      private GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTDropDownOptionsTitleSettingsIcons AV52DDO_TitleSettingsIcons ;
      private GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTDropDownOptionsTitleSettingsIcons GXt_SdtDVB_SDTDropDownOptionsTitleSettingsIcons1 ;
      private GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTDropDownOptionsData_Item AV59AGExportDataItem ;
   }

   public class cuentabancosww__default : DataStoreHelperBase, IDataStoreHelper
   {
      protected Object[] conditional_H001Z5( IGxContext context ,
                                             string AV75Bancos_cuentabancoswwds_1_dynamicfiltersselector1 ,
                                             short AV76Bancos_cuentabancoswwds_2_dynamicfiltersoperator1 ,
                                             string AV77Bancos_cuentabancoswwds_3_bandsc1 ,
                                             int AV78Bancos_cuentabancoswwds_4_moncod1 ,
                                             bool AV79Bancos_cuentabancoswwds_5_dynamicfiltersenabled2 ,
                                             string AV80Bancos_cuentabancoswwds_6_dynamicfiltersselector2 ,
                                             short AV81Bancos_cuentabancoswwds_7_dynamicfiltersoperator2 ,
                                             string AV82Bancos_cuentabancoswwds_8_bandsc2 ,
                                             int AV83Bancos_cuentabancoswwds_9_moncod2 ,
                                             bool AV84Bancos_cuentabancoswwds_10_dynamicfiltersenabled3 ,
                                             string AV85Bancos_cuentabancoswwds_11_dynamicfiltersselector3 ,
                                             short AV86Bancos_cuentabancoswwds_12_dynamicfiltersoperator3 ,
                                             string AV87Bancos_cuentabancoswwds_13_bandsc3 ,
                                             int AV88Bancos_cuentabancoswwds_14_moncod3 ,
                                             string AV90Bancos_cuentabancoswwds_16_tfbandsc_sel ,
                                             string AV89Bancos_cuentabancoswwds_15_tfbandsc ,
                                             string AV92Bancos_cuentabancoswwds_18_tfcbcod_sel ,
                                             string AV91Bancos_cuentabancoswwds_17_tfcbcod ,
                                             string AV94Bancos_cuentabancoswwds_20_tfmondsc_sel ,
                                             string AV93Bancos_cuentabancoswwds_19_tfmondsc ,
                                             short AV95Bancos_cuentabancoswwds_21_tfcbsts ,
                                             short AV96Bancos_cuentabancoswwds_22_tfcbsts_to ,
                                             string A482BanDsc ,
                                             int A180MonCod ,
                                             string A377CBCod ,
                                             string A1234MonDsc ,
                                             short A504CBSts ,
                                             short AV13OrderedBy ,
                                             bool AV14OrderedDsc )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int5 = new short[20];
         Object[] GXv_Object6 = new Object[2];
         string sSelectString;
         string sFromString;
         string sOrderString;
         sSelectString = " T1.[MonCod], T1.[BanCod], T1.[CBSts], T2.[MonDsc], T1.[CBCod], T3.[BanDsc]";
         sFromString = " FROM (([TSCUENTABANCO] T1 INNER JOIN [CMONEDAS] T2 ON T2.[MonCod] = T1.[MonCod]) INNER JOIN [TSBANCOS] T3 ON T3.[BanCod] = T1.[BanCod])";
         sOrderString = "";
         if ( ( StringUtil.StrCmp(AV75Bancos_cuentabancoswwds_1_dynamicfiltersselector1, "BANDSC") == 0 ) && ( AV76Bancos_cuentabancoswwds_2_dynamicfiltersoperator1 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV77Bancos_cuentabancoswwds_3_bandsc1)) ) )
         {
            AddWhere(sWhereString, "(T3.[BanDsc] like @lV77Bancos_cuentabancoswwds_3_bandsc1)");
         }
         else
         {
            GXv_int5[0] = 1;
         }
         if ( ( StringUtil.StrCmp(AV75Bancos_cuentabancoswwds_1_dynamicfiltersselector1, "BANDSC") == 0 ) && ( AV76Bancos_cuentabancoswwds_2_dynamicfiltersoperator1 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV77Bancos_cuentabancoswwds_3_bandsc1)) ) )
         {
            AddWhere(sWhereString, "(T3.[BanDsc] like '%' + @lV77Bancos_cuentabancoswwds_3_bandsc1)");
         }
         else
         {
            GXv_int5[1] = 1;
         }
         if ( ( StringUtil.StrCmp(AV75Bancos_cuentabancoswwds_1_dynamicfiltersselector1, "MONCOD") == 0 ) && ( ! (0==AV78Bancos_cuentabancoswwds_4_moncod1) ) )
         {
            AddWhere(sWhereString, "(T1.[MonCod] = @AV78Bancos_cuentabancoswwds_4_moncod1)");
         }
         else
         {
            GXv_int5[2] = 1;
         }
         if ( AV79Bancos_cuentabancoswwds_5_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV80Bancos_cuentabancoswwds_6_dynamicfiltersselector2, "BANDSC") == 0 ) && ( AV81Bancos_cuentabancoswwds_7_dynamicfiltersoperator2 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV82Bancos_cuentabancoswwds_8_bandsc2)) ) )
         {
            AddWhere(sWhereString, "(T3.[BanDsc] like @lV82Bancos_cuentabancoswwds_8_bandsc2)");
         }
         else
         {
            GXv_int5[3] = 1;
         }
         if ( AV79Bancos_cuentabancoswwds_5_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV80Bancos_cuentabancoswwds_6_dynamicfiltersselector2, "BANDSC") == 0 ) && ( AV81Bancos_cuentabancoswwds_7_dynamicfiltersoperator2 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV82Bancos_cuentabancoswwds_8_bandsc2)) ) )
         {
            AddWhere(sWhereString, "(T3.[BanDsc] like '%' + @lV82Bancos_cuentabancoswwds_8_bandsc2)");
         }
         else
         {
            GXv_int5[4] = 1;
         }
         if ( AV79Bancos_cuentabancoswwds_5_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV80Bancos_cuentabancoswwds_6_dynamicfiltersselector2, "MONCOD") == 0 ) && ( ! (0==AV83Bancos_cuentabancoswwds_9_moncod2) ) )
         {
            AddWhere(sWhereString, "(T1.[MonCod] = @AV83Bancos_cuentabancoswwds_9_moncod2)");
         }
         else
         {
            GXv_int5[5] = 1;
         }
         if ( AV84Bancos_cuentabancoswwds_10_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV85Bancos_cuentabancoswwds_11_dynamicfiltersselector3, "BANDSC") == 0 ) && ( AV86Bancos_cuentabancoswwds_12_dynamicfiltersoperator3 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV87Bancos_cuentabancoswwds_13_bandsc3)) ) )
         {
            AddWhere(sWhereString, "(T3.[BanDsc] like @lV87Bancos_cuentabancoswwds_13_bandsc3)");
         }
         else
         {
            GXv_int5[6] = 1;
         }
         if ( AV84Bancos_cuentabancoswwds_10_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV85Bancos_cuentabancoswwds_11_dynamicfiltersselector3, "BANDSC") == 0 ) && ( AV86Bancos_cuentabancoswwds_12_dynamicfiltersoperator3 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV87Bancos_cuentabancoswwds_13_bandsc3)) ) )
         {
            AddWhere(sWhereString, "(T3.[BanDsc] like '%' + @lV87Bancos_cuentabancoswwds_13_bandsc3)");
         }
         else
         {
            GXv_int5[7] = 1;
         }
         if ( AV84Bancos_cuentabancoswwds_10_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV85Bancos_cuentabancoswwds_11_dynamicfiltersselector3, "MONCOD") == 0 ) && ( ! (0==AV88Bancos_cuentabancoswwds_14_moncod3) ) )
         {
            AddWhere(sWhereString, "(T1.[MonCod] = @AV88Bancos_cuentabancoswwds_14_moncod3)");
         }
         else
         {
            GXv_int5[8] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV90Bancos_cuentabancoswwds_16_tfbandsc_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV89Bancos_cuentabancoswwds_15_tfbandsc)) ) )
         {
            AddWhere(sWhereString, "(T3.[BanDsc] like @lV89Bancos_cuentabancoswwds_15_tfbandsc)");
         }
         else
         {
            GXv_int5[9] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV90Bancos_cuentabancoswwds_16_tfbandsc_sel)) )
         {
            AddWhere(sWhereString, "(T3.[BanDsc] = @AV90Bancos_cuentabancoswwds_16_tfbandsc_sel)");
         }
         else
         {
            GXv_int5[10] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV92Bancos_cuentabancoswwds_18_tfcbcod_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV91Bancos_cuentabancoswwds_17_tfcbcod)) ) )
         {
            AddWhere(sWhereString, "(T1.[CBCod] like @lV91Bancos_cuentabancoswwds_17_tfcbcod)");
         }
         else
         {
            GXv_int5[11] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV92Bancos_cuentabancoswwds_18_tfcbcod_sel)) )
         {
            AddWhere(sWhereString, "(T1.[CBCod] = @AV92Bancos_cuentabancoswwds_18_tfcbcod_sel)");
         }
         else
         {
            GXv_int5[12] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV94Bancos_cuentabancoswwds_20_tfmondsc_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV93Bancos_cuentabancoswwds_19_tfmondsc)) ) )
         {
            AddWhere(sWhereString, "(T2.[MonDsc] like @lV93Bancos_cuentabancoswwds_19_tfmondsc)");
         }
         else
         {
            GXv_int5[13] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV94Bancos_cuentabancoswwds_20_tfmondsc_sel)) )
         {
            AddWhere(sWhereString, "(T2.[MonDsc] = @AV94Bancos_cuentabancoswwds_20_tfmondsc_sel)");
         }
         else
         {
            GXv_int5[14] = 1;
         }
         if ( ! (0==AV95Bancos_cuentabancoswwds_21_tfcbsts) )
         {
            AddWhere(sWhereString, "(T1.[CBSts] >= @AV95Bancos_cuentabancoswwds_21_tfcbsts)");
         }
         else
         {
            GXv_int5[15] = 1;
         }
         if ( ! (0==AV96Bancos_cuentabancoswwds_22_tfcbsts_to) )
         {
            AddWhere(sWhereString, "(T1.[CBSts] <= @AV96Bancos_cuentabancoswwds_22_tfcbsts_to)");
         }
         else
         {
            GXv_int5[16] = 1;
         }
         if ( AV13OrderedBy == 1 )
         {
            sOrderString += " ORDER BY T1.[BanCod], T1.[CBCod]";
         }
         else if ( ( AV13OrderedBy == 2 ) && ! AV14OrderedDsc )
         {
            sOrderString += " ORDER BY T3.[BanDsc]";
         }
         else if ( ( AV13OrderedBy == 2 ) && ( AV14OrderedDsc ) )
         {
            sOrderString += " ORDER BY T3.[BanDsc] DESC";
         }
         else if ( ( AV13OrderedBy == 3 ) && ! AV14OrderedDsc )
         {
            sOrderString += " ORDER BY T1.[CBCod]";
         }
         else if ( ( AV13OrderedBy == 3 ) && ( AV14OrderedDsc ) )
         {
            sOrderString += " ORDER BY T1.[CBCod] DESC";
         }
         else if ( ( AV13OrderedBy == 4 ) && ! AV14OrderedDsc )
         {
            sOrderString += " ORDER BY T2.[MonDsc]";
         }
         else if ( ( AV13OrderedBy == 4 ) && ( AV14OrderedDsc ) )
         {
            sOrderString += " ORDER BY T2.[MonDsc] DESC";
         }
         else if ( ( AV13OrderedBy == 5 ) && ! AV14OrderedDsc )
         {
            sOrderString += " ORDER BY T1.[CBSts]";
         }
         else if ( ( AV13OrderedBy == 5 ) && ( AV14OrderedDsc ) )
         {
            sOrderString += " ORDER BY T1.[CBSts] DESC";
         }
         else if ( true )
         {
            sOrderString += " ORDER BY T1.[BanCod], T1.[CBCod]";
         }
         scmdbuf = "SELECT " + sSelectString + sFromString + sWhereString + sOrderString + "" + " OFFSET " + "@GXPagingFrom2" + " ROWS FETCH NEXT CAST((SELECT CASE WHEN " + "@GXPagingTo2" + " > 0 THEN " + "@GXPagingTo2" + " ELSE 1e9 END) AS INTEGER) ROWS ONLY";
         GXv_Object6[0] = scmdbuf;
         GXv_Object6[1] = GXv_int5;
         return GXv_Object6 ;
      }

      protected Object[] conditional_H001Z6( IGxContext context ,
                                             string AV75Bancos_cuentabancoswwds_1_dynamicfiltersselector1 ,
                                             short AV76Bancos_cuentabancoswwds_2_dynamicfiltersoperator1 ,
                                             string AV77Bancos_cuentabancoswwds_3_bandsc1 ,
                                             int AV78Bancos_cuentabancoswwds_4_moncod1 ,
                                             bool AV79Bancos_cuentabancoswwds_5_dynamicfiltersenabled2 ,
                                             string AV80Bancos_cuentabancoswwds_6_dynamicfiltersselector2 ,
                                             short AV81Bancos_cuentabancoswwds_7_dynamicfiltersoperator2 ,
                                             string AV82Bancos_cuentabancoswwds_8_bandsc2 ,
                                             int AV83Bancos_cuentabancoswwds_9_moncod2 ,
                                             bool AV84Bancos_cuentabancoswwds_10_dynamicfiltersenabled3 ,
                                             string AV85Bancos_cuentabancoswwds_11_dynamicfiltersselector3 ,
                                             short AV86Bancos_cuentabancoswwds_12_dynamicfiltersoperator3 ,
                                             string AV87Bancos_cuentabancoswwds_13_bandsc3 ,
                                             int AV88Bancos_cuentabancoswwds_14_moncod3 ,
                                             string AV90Bancos_cuentabancoswwds_16_tfbandsc_sel ,
                                             string AV89Bancos_cuentabancoswwds_15_tfbandsc ,
                                             string AV92Bancos_cuentabancoswwds_18_tfcbcod_sel ,
                                             string AV91Bancos_cuentabancoswwds_17_tfcbcod ,
                                             string AV94Bancos_cuentabancoswwds_20_tfmondsc_sel ,
                                             string AV93Bancos_cuentabancoswwds_19_tfmondsc ,
                                             short AV95Bancos_cuentabancoswwds_21_tfcbsts ,
                                             short AV96Bancos_cuentabancoswwds_22_tfcbsts_to ,
                                             string A482BanDsc ,
                                             int A180MonCod ,
                                             string A377CBCod ,
                                             string A1234MonDsc ,
                                             short A504CBSts ,
                                             short AV13OrderedBy ,
                                             bool AV14OrderedDsc )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int7 = new short[17];
         Object[] GXv_Object8 = new Object[2];
         scmdbuf = "SELECT COUNT(*) FROM (([TSCUENTABANCO] T1 INNER JOIN [CMONEDAS] T3 ON T3.[MonCod] = T1.[MonCod]) INNER JOIN [TSBANCOS] T2 ON T2.[BanCod] = T1.[BanCod])";
         if ( ( StringUtil.StrCmp(AV75Bancos_cuentabancoswwds_1_dynamicfiltersselector1, "BANDSC") == 0 ) && ( AV76Bancos_cuentabancoswwds_2_dynamicfiltersoperator1 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV77Bancos_cuentabancoswwds_3_bandsc1)) ) )
         {
            AddWhere(sWhereString, "(T2.[BanDsc] like @lV77Bancos_cuentabancoswwds_3_bandsc1)");
         }
         else
         {
            GXv_int7[0] = 1;
         }
         if ( ( StringUtil.StrCmp(AV75Bancos_cuentabancoswwds_1_dynamicfiltersselector1, "BANDSC") == 0 ) && ( AV76Bancos_cuentabancoswwds_2_dynamicfiltersoperator1 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV77Bancos_cuentabancoswwds_3_bandsc1)) ) )
         {
            AddWhere(sWhereString, "(T2.[BanDsc] like '%' + @lV77Bancos_cuentabancoswwds_3_bandsc1)");
         }
         else
         {
            GXv_int7[1] = 1;
         }
         if ( ( StringUtil.StrCmp(AV75Bancos_cuentabancoswwds_1_dynamicfiltersselector1, "MONCOD") == 0 ) && ( ! (0==AV78Bancos_cuentabancoswwds_4_moncod1) ) )
         {
            AddWhere(sWhereString, "(T1.[MonCod] = @AV78Bancos_cuentabancoswwds_4_moncod1)");
         }
         else
         {
            GXv_int7[2] = 1;
         }
         if ( AV79Bancos_cuentabancoswwds_5_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV80Bancos_cuentabancoswwds_6_dynamicfiltersselector2, "BANDSC") == 0 ) && ( AV81Bancos_cuentabancoswwds_7_dynamicfiltersoperator2 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV82Bancos_cuentabancoswwds_8_bandsc2)) ) )
         {
            AddWhere(sWhereString, "(T2.[BanDsc] like @lV82Bancos_cuentabancoswwds_8_bandsc2)");
         }
         else
         {
            GXv_int7[3] = 1;
         }
         if ( AV79Bancos_cuentabancoswwds_5_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV80Bancos_cuentabancoswwds_6_dynamicfiltersselector2, "BANDSC") == 0 ) && ( AV81Bancos_cuentabancoswwds_7_dynamicfiltersoperator2 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV82Bancos_cuentabancoswwds_8_bandsc2)) ) )
         {
            AddWhere(sWhereString, "(T2.[BanDsc] like '%' + @lV82Bancos_cuentabancoswwds_8_bandsc2)");
         }
         else
         {
            GXv_int7[4] = 1;
         }
         if ( AV79Bancos_cuentabancoswwds_5_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV80Bancos_cuentabancoswwds_6_dynamicfiltersselector2, "MONCOD") == 0 ) && ( ! (0==AV83Bancos_cuentabancoswwds_9_moncod2) ) )
         {
            AddWhere(sWhereString, "(T1.[MonCod] = @AV83Bancos_cuentabancoswwds_9_moncod2)");
         }
         else
         {
            GXv_int7[5] = 1;
         }
         if ( AV84Bancos_cuentabancoswwds_10_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV85Bancos_cuentabancoswwds_11_dynamicfiltersselector3, "BANDSC") == 0 ) && ( AV86Bancos_cuentabancoswwds_12_dynamicfiltersoperator3 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV87Bancos_cuentabancoswwds_13_bandsc3)) ) )
         {
            AddWhere(sWhereString, "(T2.[BanDsc] like @lV87Bancos_cuentabancoswwds_13_bandsc3)");
         }
         else
         {
            GXv_int7[6] = 1;
         }
         if ( AV84Bancos_cuentabancoswwds_10_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV85Bancos_cuentabancoswwds_11_dynamicfiltersselector3, "BANDSC") == 0 ) && ( AV86Bancos_cuentabancoswwds_12_dynamicfiltersoperator3 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV87Bancos_cuentabancoswwds_13_bandsc3)) ) )
         {
            AddWhere(sWhereString, "(T2.[BanDsc] like '%' + @lV87Bancos_cuentabancoswwds_13_bandsc3)");
         }
         else
         {
            GXv_int7[7] = 1;
         }
         if ( AV84Bancos_cuentabancoswwds_10_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV85Bancos_cuentabancoswwds_11_dynamicfiltersselector3, "MONCOD") == 0 ) && ( ! (0==AV88Bancos_cuentabancoswwds_14_moncod3) ) )
         {
            AddWhere(sWhereString, "(T1.[MonCod] = @AV88Bancos_cuentabancoswwds_14_moncod3)");
         }
         else
         {
            GXv_int7[8] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV90Bancos_cuentabancoswwds_16_tfbandsc_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV89Bancos_cuentabancoswwds_15_tfbandsc)) ) )
         {
            AddWhere(sWhereString, "(T2.[BanDsc] like @lV89Bancos_cuentabancoswwds_15_tfbandsc)");
         }
         else
         {
            GXv_int7[9] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV90Bancos_cuentabancoswwds_16_tfbandsc_sel)) )
         {
            AddWhere(sWhereString, "(T2.[BanDsc] = @AV90Bancos_cuentabancoswwds_16_tfbandsc_sel)");
         }
         else
         {
            GXv_int7[10] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV92Bancos_cuentabancoswwds_18_tfcbcod_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV91Bancos_cuentabancoswwds_17_tfcbcod)) ) )
         {
            AddWhere(sWhereString, "(T1.[CBCod] like @lV91Bancos_cuentabancoswwds_17_tfcbcod)");
         }
         else
         {
            GXv_int7[11] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV92Bancos_cuentabancoswwds_18_tfcbcod_sel)) )
         {
            AddWhere(sWhereString, "(T1.[CBCod] = @AV92Bancos_cuentabancoswwds_18_tfcbcod_sel)");
         }
         else
         {
            GXv_int7[12] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV94Bancos_cuentabancoswwds_20_tfmondsc_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV93Bancos_cuentabancoswwds_19_tfmondsc)) ) )
         {
            AddWhere(sWhereString, "(T3.[MonDsc] like @lV93Bancos_cuentabancoswwds_19_tfmondsc)");
         }
         else
         {
            GXv_int7[13] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV94Bancos_cuentabancoswwds_20_tfmondsc_sel)) )
         {
            AddWhere(sWhereString, "(T3.[MonDsc] = @AV94Bancos_cuentabancoswwds_20_tfmondsc_sel)");
         }
         else
         {
            GXv_int7[14] = 1;
         }
         if ( ! (0==AV95Bancos_cuentabancoswwds_21_tfcbsts) )
         {
            AddWhere(sWhereString, "(T1.[CBSts] >= @AV95Bancos_cuentabancoswwds_21_tfcbsts)");
         }
         else
         {
            GXv_int7[15] = 1;
         }
         if ( ! (0==AV96Bancos_cuentabancoswwds_22_tfcbsts_to) )
         {
            AddWhere(sWhereString, "(T1.[CBSts] <= @AV96Bancos_cuentabancoswwds_22_tfcbsts_to)");
         }
         else
         {
            GXv_int7[16] = 1;
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
               case 3 :
                     return conditional_H001Z5(context, (string)dynConstraints[0] , (short)dynConstraints[1] , (string)dynConstraints[2] , (int)dynConstraints[3] , (bool)dynConstraints[4] , (string)dynConstraints[5] , (short)dynConstraints[6] , (string)dynConstraints[7] , (int)dynConstraints[8] , (bool)dynConstraints[9] , (string)dynConstraints[10] , (short)dynConstraints[11] , (string)dynConstraints[12] , (int)dynConstraints[13] , (string)dynConstraints[14] , (string)dynConstraints[15] , (string)dynConstraints[16] , (string)dynConstraints[17] , (string)dynConstraints[18] , (string)dynConstraints[19] , (short)dynConstraints[20] , (short)dynConstraints[21] , (string)dynConstraints[22] , (int)dynConstraints[23] , (string)dynConstraints[24] , (string)dynConstraints[25] , (short)dynConstraints[26] , (short)dynConstraints[27] , (bool)dynConstraints[28] );
               case 4 :
                     return conditional_H001Z6(context, (string)dynConstraints[0] , (short)dynConstraints[1] , (string)dynConstraints[2] , (int)dynConstraints[3] , (bool)dynConstraints[4] , (string)dynConstraints[5] , (short)dynConstraints[6] , (string)dynConstraints[7] , (int)dynConstraints[8] , (bool)dynConstraints[9] , (string)dynConstraints[10] , (short)dynConstraints[11] , (string)dynConstraints[12] , (int)dynConstraints[13] , (string)dynConstraints[14] , (string)dynConstraints[15] , (string)dynConstraints[16] , (string)dynConstraints[17] , (string)dynConstraints[18] , (string)dynConstraints[19] , (short)dynConstraints[20] , (short)dynConstraints[21] , (string)dynConstraints[22] , (int)dynConstraints[23] , (string)dynConstraints[24] , (string)dynConstraints[25] , (short)dynConstraints[26] , (short)dynConstraints[27] , (bool)dynConstraints[28] );
         }
         return base.getDynamicStatement(cursor, context, dynConstraints);
      }

      public ICursor[] getCursors( )
      {
         cursorDefinitions();
         return new Cursor[] {
          new ForEachCursor(def[0])
         ,new ForEachCursor(def[1])
         ,new ForEachCursor(def[2])
         ,new ForEachCursor(def[3])
         ,new ForEachCursor(def[4])
       };
    }

    private static CursorDef[] def;
    private void cursorDefinitions( )
    {
       if ( def == null )
       {
          Object[] prmH001Z2;
          prmH001Z2 = new Object[] {
          };
          Object[] prmH001Z3;
          prmH001Z3 = new Object[] {
          };
          Object[] prmH001Z4;
          prmH001Z4 = new Object[] {
          };
          Object[] prmH001Z5;
          prmH001Z5 = new Object[] {
          new ParDef("@lV77Bancos_cuentabancoswwds_3_bandsc1",GXType.NChar,100,0) ,
          new ParDef("@lV77Bancos_cuentabancoswwds_3_bandsc1",GXType.NChar,100,0) ,
          new ParDef("@AV78Bancos_cuentabancoswwds_4_moncod1",GXType.Int32,6,0) ,
          new ParDef("@lV82Bancos_cuentabancoswwds_8_bandsc2",GXType.NChar,100,0) ,
          new ParDef("@lV82Bancos_cuentabancoswwds_8_bandsc2",GXType.NChar,100,0) ,
          new ParDef("@AV83Bancos_cuentabancoswwds_9_moncod2",GXType.Int32,6,0) ,
          new ParDef("@lV87Bancos_cuentabancoswwds_13_bandsc3",GXType.NChar,100,0) ,
          new ParDef("@lV87Bancos_cuentabancoswwds_13_bandsc3",GXType.NChar,100,0) ,
          new ParDef("@AV88Bancos_cuentabancoswwds_14_moncod3",GXType.Int32,6,0) ,
          new ParDef("@lV89Bancos_cuentabancoswwds_15_tfbandsc",GXType.NChar,100,0) ,
          new ParDef("@AV90Bancos_cuentabancoswwds_16_tfbandsc_sel",GXType.NChar,100,0) ,
          new ParDef("@lV91Bancos_cuentabancoswwds_17_tfcbcod",GXType.NChar,20,0) ,
          new ParDef("@AV92Bancos_cuentabancoswwds_18_tfcbcod_sel",GXType.NChar,20,0) ,
          new ParDef("@lV93Bancos_cuentabancoswwds_19_tfmondsc",GXType.NChar,100,0) ,
          new ParDef("@AV94Bancos_cuentabancoswwds_20_tfmondsc_sel",GXType.NChar,100,0) ,
          new ParDef("@AV95Bancos_cuentabancoswwds_21_tfcbsts",GXType.Int16,1,0) ,
          new ParDef("@AV96Bancos_cuentabancoswwds_22_tfcbsts_to",GXType.Int16,1,0) ,
          new ParDef("@GXPagingFrom2",GXType.Int32,9,0) ,
          new ParDef("@GXPagingTo2",GXType.Int32,9,0) ,
          new ParDef("@GXPagingTo2",GXType.Int32,9,0)
          };
          Object[] prmH001Z6;
          prmH001Z6 = new Object[] {
          new ParDef("@lV77Bancos_cuentabancoswwds_3_bandsc1",GXType.NChar,100,0) ,
          new ParDef("@lV77Bancos_cuentabancoswwds_3_bandsc1",GXType.NChar,100,0) ,
          new ParDef("@AV78Bancos_cuentabancoswwds_4_moncod1",GXType.Int32,6,0) ,
          new ParDef("@lV82Bancos_cuentabancoswwds_8_bandsc2",GXType.NChar,100,0) ,
          new ParDef("@lV82Bancos_cuentabancoswwds_8_bandsc2",GXType.NChar,100,0) ,
          new ParDef("@AV83Bancos_cuentabancoswwds_9_moncod2",GXType.Int32,6,0) ,
          new ParDef("@lV87Bancos_cuentabancoswwds_13_bandsc3",GXType.NChar,100,0) ,
          new ParDef("@lV87Bancos_cuentabancoswwds_13_bandsc3",GXType.NChar,100,0) ,
          new ParDef("@AV88Bancos_cuentabancoswwds_14_moncod3",GXType.Int32,6,0) ,
          new ParDef("@lV89Bancos_cuentabancoswwds_15_tfbandsc",GXType.NChar,100,0) ,
          new ParDef("@AV90Bancos_cuentabancoswwds_16_tfbandsc_sel",GXType.NChar,100,0) ,
          new ParDef("@lV91Bancos_cuentabancoswwds_17_tfcbcod",GXType.NChar,20,0) ,
          new ParDef("@AV92Bancos_cuentabancoswwds_18_tfcbcod_sel",GXType.NChar,20,0) ,
          new ParDef("@lV93Bancos_cuentabancoswwds_19_tfmondsc",GXType.NChar,100,0) ,
          new ParDef("@AV94Bancos_cuentabancoswwds_20_tfmondsc_sel",GXType.NChar,100,0) ,
          new ParDef("@AV95Bancos_cuentabancoswwds_21_tfcbsts",GXType.Int16,1,0) ,
          new ParDef("@AV96Bancos_cuentabancoswwds_22_tfcbsts_to",GXType.Int16,1,0)
          };
          def= new CursorDef[] {
              new CursorDef("H001Z2", "SELECT [MonCod], [MonDsc], [MonSts] FROM [CMONEDAS] WHERE [MonSts] = 1 ORDER BY [MonDsc] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH001Z2,0, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("H001Z3", "SELECT [MonCod], [MonDsc], [MonSts] FROM [CMONEDAS] WHERE [MonSts] = 1 ORDER BY [MonDsc] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH001Z3,0, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("H001Z4", "SELECT [MonCod], [MonDsc], [MonSts] FROM [CMONEDAS] WHERE [MonSts] = 1 ORDER BY [MonDsc] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH001Z4,0, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("H001Z5", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH001Z5,11, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("H001Z6", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH001Z6,1, GxCacheFrequency.OFF ,true,false )
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
                ((int[]) buf[0])[0] = rslt.getInt(1);
                ((string[]) buf[1])[0] = rslt.getString(2, 100);
                ((short[]) buf[2])[0] = rslt.getShort(3);
                return;
             case 1 :
                ((int[]) buf[0])[0] = rslt.getInt(1);
                ((string[]) buf[1])[0] = rslt.getString(2, 100);
                ((short[]) buf[2])[0] = rslt.getShort(3);
                return;
             case 2 :
                ((int[]) buf[0])[0] = rslt.getInt(1);
                ((string[]) buf[1])[0] = rslt.getString(2, 100);
                ((short[]) buf[2])[0] = rslt.getShort(3);
                return;
             case 3 :
                ((int[]) buf[0])[0] = rslt.getInt(1);
                ((int[]) buf[1])[0] = rslt.getInt(2);
                ((short[]) buf[2])[0] = rslt.getShort(3);
                ((string[]) buf[3])[0] = rslt.getString(4, 100);
                ((string[]) buf[4])[0] = rslt.getString(5, 20);
                ((string[]) buf[5])[0] = rslt.getString(6, 100);
                return;
             case 4 :
                ((long[]) buf[0])[0] = rslt.getLong(1);
                return;
       }
    }

 }

}
