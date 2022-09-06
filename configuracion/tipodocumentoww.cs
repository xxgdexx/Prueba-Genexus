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
   public class tipodocumentoww : GXDataArea
   {
      public tipodocumentoww( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDataStore2 = context.GetDataStore("DataStore2");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusTheme");
      }

      public tipodocumentoww( IGxContext context )
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
         chkTipCxP = new GXCheckbox();
         chkTipBan = new GXCheckbox();
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
               AV17TipDsc1 = GetPar( "TipDsc1");
               AV66TipAbr1 = GetPar( "TipAbr1");
               cmbavDynamicfiltersselector2.FromJSonString( GetNextPar( ));
               AV19DynamicFiltersSelector2 = GetPar( "DynamicFiltersSelector2");
               cmbavDynamicfiltersoperator2.FromJSonString( GetNextPar( ));
               AV20DynamicFiltersOperator2 = (short)(NumberUtil.Val( GetPar( "DynamicFiltersOperator2"), "."));
               AV21TipDsc2 = GetPar( "TipDsc2");
               AV67TipAbr2 = GetPar( "TipAbr2");
               cmbavDynamicfiltersselector3.FromJSonString( GetNextPar( ));
               AV23DynamicFiltersSelector3 = GetPar( "DynamicFiltersSelector3");
               cmbavDynamicfiltersoperator3.FromJSonString( GetNextPar( ));
               AV24DynamicFiltersOperator3 = (short)(NumberUtil.Val( GetPar( "DynamicFiltersOperator3"), "."));
               AV25TipDsc3 = GetPar( "TipDsc3");
               AV68TipAbr3 = GetPar( "TipAbr3");
               AV18DynamicFiltersEnabled2 = StringUtil.StrToBool( GetPar( "DynamicFiltersEnabled2"));
               AV22DynamicFiltersEnabled3 = StringUtil.StrToBool( GetPar( "DynamicFiltersEnabled3"));
               AV71Pgmname = GetPar( "Pgmname");
               AV35TFTipAbr = GetPar( "TFTipAbr");
               AV36TFTipAbr_Sel = GetPar( "TFTipAbr_Sel");
               AV33TFTipDsc = GetPar( "TFTipDsc");
               AV34TFTipDsc_Sel = GetPar( "TFTipDsc_Sel");
               AV59TFTipVta_Sel = (short)(NumberUtil.Val( GetPar( "TFTipVta_Sel"), "."));
               AV60TFTipCmp_Sel = (short)(NumberUtil.Val( GetPar( "TFTipCmp_Sel"), "."));
               AV61TFTipRHo_Sel = (short)(NumberUtil.Val( GetPar( "TFTipRHo_Sel"), "."));
               AV62TFTipCxP_Sel = (short)(NumberUtil.Val( GetPar( "TFTipCxP_Sel"), "."));
               AV63TFTipBan_Sel = (short)(NumberUtil.Val( GetPar( "TFTipBan_Sel"), "."));
               ajax_req_read_hidden_sdt(GetNextPar( ), AV65TFTipSts_Sels);
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
               gxgrGrid_refresh( subGrid_Rows, AV15DynamicFiltersSelector1, AV16DynamicFiltersOperator1, AV17TipDsc1, AV66TipAbr1, AV19DynamicFiltersSelector2, AV20DynamicFiltersOperator2, AV21TipDsc2, AV67TipAbr2, AV23DynamicFiltersSelector3, AV24DynamicFiltersOperator3, AV25TipDsc3, AV68TipAbr3, AV18DynamicFiltersEnabled2, AV22DynamicFiltersEnabled3, AV71Pgmname, AV35TFTipAbr, AV36TFTipAbr_Sel, AV33TFTipDsc, AV34TFTipDsc_Sel, AV59TFTipVta_Sel, AV60TFTipCmp_Sel, AV61TFTipRHo_Sel, AV62TFTipCxP_Sel, AV63TFTipBan_Sel, AV65TFTipSts_Sels, AV13OrderedBy, AV14OrderedDsc, AV10GridState, AV27DynamicFiltersIgnoreFirst, AV26DynamicFiltersRemoving) ;
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
         PA1O2( ) ;
         gxajaxcallmode = (short)((isAjaxCallMode( ) ? 1 : 0));
         if ( ( gxajaxcallmode == 0 ) && ( GxWebError == 0 ) )
         {
            START1O2( ) ;
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
         context.AddJavascriptSource("gxcfg.js", "?20228181029307", false, true);
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
         context.WriteHtmlTextNl( "<form id=\"MAINFORM\" autocomplete=\"off\" name=\"MAINFORM\" method=\"post\" tabindex=-1  class=\"form-horizontal Form\" data-gx-class=\"form-horizontal Form\" novalidate action=\""+formatLink("configuracion.tipodocumentoww.aspx") +"\">") ;
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
         GxWebStd.gx_hidden_field( context, "GXH_vDYNAMICFILTERSSELECTOR1", AV15DynamicFiltersSelector1);
         GxWebStd.gx_hidden_field( context, "GXH_vDYNAMICFILTERSOPERATOR1", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV16DynamicFiltersOperator1), 4, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "GXH_vTIPDSC1", StringUtil.RTrim( AV17TipDsc1));
         GxWebStd.gx_hidden_field( context, "GXH_vTIPABR1", StringUtil.RTrim( AV66TipAbr1));
         GxWebStd.gx_hidden_field( context, "GXH_vDYNAMICFILTERSSELECTOR2", AV19DynamicFiltersSelector2);
         GxWebStd.gx_hidden_field( context, "GXH_vDYNAMICFILTERSOPERATOR2", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV20DynamicFiltersOperator2), 4, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "GXH_vTIPDSC2", StringUtil.RTrim( AV21TipDsc2));
         GxWebStd.gx_hidden_field( context, "GXH_vTIPABR2", StringUtil.RTrim( AV67TipAbr2));
         GxWebStd.gx_hidden_field( context, "GXH_vDYNAMICFILTERSSELECTOR3", AV23DynamicFiltersSelector3);
         GxWebStd.gx_hidden_field( context, "GXH_vDYNAMICFILTERSOPERATOR3", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV24DynamicFiltersOperator3), 4, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "GXH_vTIPDSC3", StringUtil.RTrim( AV25TipDsc3));
         GxWebStd.gx_hidden_field( context, "GXH_vTIPABR3", StringUtil.RTrim( AV68TipAbr3));
         /* Send saved values. */
         send_integrity_footer_hashes( ) ;
         GxWebStd.gx_hidden_field( context, "nRC_GXsfl_110", StringUtil.LTrim( StringUtil.NToC( (decimal)(nRC_GXsfl_110), 8, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "vGRIDCURRENTPAGE", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV53GridCurrentPage), 10, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "vGRIDPAGECOUNT", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV54GridPageCount), 10, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "vGRIDAPPLIEDFILTERS", AV55GridAppliedFilters);
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "vAGEXPORTDATA", AV57AGExportData);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt("vAGEXPORTDATA", AV57AGExportData);
         }
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "vDDO_TITLESETTINGSICONS", AV51DDO_TitleSettingsIcons);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt("vDDO_TITLESETTINGSICONS", AV51DDO_TitleSettingsIcons);
         }
         GxWebStd.gx_boolean_hidden_field( context, "vDYNAMICFILTERSENABLED2", AV18DynamicFiltersEnabled2);
         GxWebStd.gx_boolean_hidden_field( context, "vDYNAMICFILTERSENABLED3", AV22DynamicFiltersEnabled3);
         GxWebStd.gx_hidden_field( context, "vPGMNAME", StringUtil.RTrim( AV71Pgmname));
         GxWebStd.gx_hidden_field( context, "gxhash_vPGMNAME", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( AV71Pgmname, "")), context));
         GxWebStd.gx_hidden_field( context, "vTFTIPABR", StringUtil.RTrim( AV35TFTipAbr));
         GxWebStd.gx_hidden_field( context, "vTFTIPABR_SEL", StringUtil.RTrim( AV36TFTipAbr_Sel));
         GxWebStd.gx_hidden_field( context, "vTFTIPDSC", StringUtil.RTrim( AV33TFTipDsc));
         GxWebStd.gx_hidden_field( context, "vTFTIPDSC_SEL", StringUtil.RTrim( AV34TFTipDsc_Sel));
         GxWebStd.gx_hidden_field( context, "vTFTIPVTA_SEL", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV59TFTipVta_Sel), 1, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "vTFTIPCMP_SEL", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV60TFTipCmp_Sel), 1, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "vTFTIPRHO_SEL", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV61TFTipRHo_Sel), 1, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "vTFTIPCXP_SEL", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV62TFTipCxP_Sel), 1, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "vTFTIPBAN_SEL", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV63TFTipBan_Sel), 1, 0, ".", "")));
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "vTFTIPSTS_SELS", AV65TFTipSts_Sels);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt("vTFTIPSTS_SELS", AV65TFTipSts_Sels);
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
         GxWebStd.gx_hidden_field( context, "vTFTIPSTS_SELSJSON", AV64TFTipSts_SelsJson);
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
         GxWebStd.gx_hidden_field( context, "DDO_GRID_Filteredtext_get", StringUtil.RTrim( Ddo_grid_Filteredtext_get));
         GxWebStd.gx_hidden_field( context, "DDO_GRID_Selectedcolumn", StringUtil.RTrim( Ddo_grid_Selectedcolumn));
         GxWebStd.gx_hidden_field( context, "DDO_AGEXPORT_Activeeventkey", StringUtil.RTrim( Ddo_agexport_Activeeventkey));
         GxWebStd.gx_hidden_field( context, "GRID_Rows", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid_Rows), 6, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "GRIDPAGINATIONBAR_Selectedpage", StringUtil.RTrim( Gridpaginationbar_Selectedpage));
         GxWebStd.gx_hidden_field( context, "GRIDPAGINATIONBAR_Rowsperpageselectedvalue", StringUtil.LTrim( StringUtil.NToC( (decimal)(Gridpaginationbar_Rowsperpageselectedvalue), 9, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "DDO_GRID_Activeeventkey", StringUtil.RTrim( Ddo_grid_Activeeventkey));
         GxWebStd.gx_hidden_field( context, "DDO_GRID_Selectedvalue_get", StringUtil.RTrim( Ddo_grid_Selectedvalue_get));
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
            WE1O2( ) ;
            context.WriteHtmlText( "</div>") ;
         }
      }

      public override void DispatchEvents( )
      {
         EVT1O2( ) ;
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
         return formatLink("configuracion.tipodocumentoww.aspx")  ;
      }

      public override string GetPgmname( )
      {
         return "Configuracion.TipoDocumentoWW" ;
      }

      public override string GetPgmdesc( )
      {
         return "Tipo de Documentos" ;
      }

      protected void WB1O0( )
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
            GxWebStd.gx_button_ctrl( context, bttBtninsert_Internalname, "gx.evt.setGridEvt("+StringUtil.Str( (decimal)(110), 3, 0)+","+"null"+");", "Agregar", bttBtninsert_Jsonclick, 5, "Agregar", "", StyleString, ClassString, 1, 1, "standard", "'"+""+"'"+",false,"+"'"+"E\\'DOINSERT\\'."+"'", TempTags, "", context.GetButtonType( ), "HLP_Configuracion\\TipoDocumentoWW.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "left", "top", "", "", "div");
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 21,'',false,'',0)\"";
            ClassString = "ColumnsSelector";
            StyleString = "";
            GxWebStd.gx_button_ctrl( context, bttBtnagexport_Internalname, "gx.evt.setGridEvt("+StringUtil.Str( (decimal)(110), 3, 0)+","+"null"+");", "Reportes", bttBtnagexport_Jsonclick, 0, "Reportes", "", StyleString, ClassString, 1, 0, "standard", "'"+""+"'"+",false,"+"'"+""+"'", TempTags, "", context.GetButtonType( ), "HLP_Configuracion\\TipoDocumentoWW.htm");
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
            wb_table1_25_1O2( true) ;
         }
         else
         {
            wb_table1_25_1O2( false) ;
         }
         return  ;
      }

      protected void wb_table1_25_1O2e( bool wbgen )
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
               context.WriteHtmlText( "<th align=\""+"left"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+"display:none;"+""+"\" "+">") ;
               context.SendWebValue( "Codigo T. Documento") ;
               context.WriteHtmlTextNl( "</th>") ;
               context.WriteHtmlText( "<th align=\""+"left"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+""+""+"\" "+">") ;
               context.SendWebValue( "Codigo Sunat") ;
               context.WriteHtmlTextNl( "</th>") ;
               context.WriteHtmlText( "<th align=\""+"left"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+""+""+"\" "+">") ;
               context.SendWebValue( "Tipo de Documento") ;
               context.WriteHtmlTextNl( "</th>") ;
               context.WriteHtmlText( "<th align=\""+"right"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"AttributeCheckBox"+"\" "+" style=\""+""+""+"\" "+">") ;
               context.SendWebValue( "Afecta Registro Venta") ;
               context.WriteHtmlTextNl( "</th>") ;
               context.WriteHtmlText( "<th align=\""+"right"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"AttributeCheckBox"+"\" "+" style=\""+""+""+"\" "+">") ;
               context.SendWebValue( "Afecta Registro Compra") ;
               context.WriteHtmlTextNl( "</th>") ;
               context.WriteHtmlText( "<th align=\""+"right"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"AttributeCheckBox"+"\" "+" style=\""+""+""+"\" "+">") ;
               context.SendWebValue( "Afecta Honorarios") ;
               context.WriteHtmlTextNl( "</th>") ;
               context.WriteHtmlText( "<th align=\""+""+"\" "+" nowrap=\"nowrap\" "+" class=\""+"AttributeCheckBox"+"\" "+" style=\""+""+""+"\" "+">") ;
               context.SendWebValue( "Afecta Cuenta x Pagar") ;
               context.WriteHtmlTextNl( "</th>") ;
               context.WriteHtmlText( "<th align=\""+""+"\" "+" nowrap=\"nowrap\" "+" class=\""+"AttributeCheckBox"+"\" "+" style=\""+""+""+"\" "+">") ;
               context.SendWebValue( "Afecta Bancos") ;
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
               GridColumn.AddObjectProperty("Value", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV56GridActions), 4, 0, ".", "")));
               GridContainer.AddColumnProperties(GridColumn);
               GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
               GridColumn.AddObjectProperty("Value", StringUtil.RTrim( A149TipCod));
               GridContainer.AddColumnProperties(GridColumn);
               GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
               GridColumn.AddObjectProperty("Value", StringUtil.RTrim( A306TipAbr));
               GridContainer.AddColumnProperties(GridColumn);
               GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
               GridColumn.AddObjectProperty("Value", StringUtil.RTrim( A1910TipDsc));
               GridColumn.AddObjectProperty("Link", StringUtil.RTrim( edtTipDsc_Link));
               GridContainer.AddColumnProperties(GridColumn);
               GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
               GridColumn.AddObjectProperty("Value", StringUtil.LTrim( StringUtil.NToC( (decimal)(A1921TipVta), 1, 0, ".", "")));
               GridContainer.AddColumnProperties(GridColumn);
               GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
               GridColumn.AddObjectProperty("Value", StringUtil.LTrim( StringUtil.NToC( (decimal)(A1906TipCmp), 1, 0, ".", "")));
               GridContainer.AddColumnProperties(GridColumn);
               GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
               GridColumn.AddObjectProperty("Value", StringUtil.LTrim( StringUtil.NToC( (decimal)(A1915TipRHo), 1, 0, ".", "")));
               GridContainer.AddColumnProperties(GridColumn);
               GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
               GridColumn.AddObjectProperty("Value", StringUtil.LTrim( StringUtil.NToC( (decimal)(A1909TipCxP), 1, 0, ".", "")));
               GridContainer.AddColumnProperties(GridColumn);
               GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
               GridColumn.AddObjectProperty("Value", StringUtil.LTrim( StringUtil.NToC( (decimal)(A1903TipBan), 1, 0, ".", "")));
               GridContainer.AddColumnProperties(GridColumn);
               GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
               GridColumn.AddObjectProperty("Value", StringUtil.LTrim( StringUtil.NToC( (decimal)(A1919TipSts), 1, 0, ".", "")));
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
            ucGridpaginationbar.SetProperty("CurrentPage", AV53GridCurrentPage);
            ucGridpaginationbar.SetProperty("PageCount", AV54GridPageCount);
            ucGridpaginationbar.SetProperty("AppliedFilters", AV55GridAppliedFilters);
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
            ucDdo_agexport.SetProperty("DropDownOptionsData", AV57AGExportData);
            ucDdo_agexport.Render(context, "dvelop.gxbootstrap.ddoregular", Ddo_agexport_Internalname, "DDO_AGEXPORTContainer");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblJsdynamicfilters_Internalname, lblJsdynamicfilters_Caption, "", "", lblJsdynamicfilters_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "", 0, "", 1, 1, 0, 1, "HLP_Configuracion\\TipoDocumentoWW.htm");
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
            ucDdo_grid.SetProperty("DropDownOptionsTitleSettingsIcons", AV51DDO_TitleSettingsIcons);
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

      protected void START1O2( )
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
            Form.Meta.addItem("description", "Tipo de Documentos", 0) ;
         }
         context.wjLoc = "";
         context.nUserReturn = 0;
         context.wbHandled = 0;
         if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
         {
         }
         wbErr = false;
         STRUP1O0( ) ;
      }

      protected void WS1O2( )
      {
         START1O2( ) ;
         EVT1O2( ) ;
      }

      protected void EVT1O2( )
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
                              E111O2 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "GRIDPAGINATIONBAR.CHANGEROWSPERPAGE") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              E121O2 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "DDO_AGEXPORT.ONOPTIONCLICKED") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              E131O2 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "DDO_GRID.ONOPTIONCLICKED") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              E141O2 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "'REMOVEDYNAMICFILTERS1'") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              /* Execute user event: 'RemoveDynamicFilters1' */
                              E151O2 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "'REMOVEDYNAMICFILTERS2'") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              /* Execute user event: 'RemoveDynamicFilters2' */
                              E161O2 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "'REMOVEDYNAMICFILTERS3'") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              /* Execute user event: 'RemoveDynamicFilters3' */
                              E171O2 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "'DOINSERT'") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              /* Execute user event: 'DoInsert' */
                              E181O2 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "'ADDDYNAMICFILTERS1'") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              /* Execute user event: 'AddDynamicFilters1' */
                              E191O2 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "VDYNAMICFILTERSSELECTOR1.CLICK") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              E201O2 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "'ADDDYNAMICFILTERS2'") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              /* Execute user event: 'AddDynamicFilters2' */
                              E211O2 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "VDYNAMICFILTERSSELECTOR2.CLICK") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              E221O2 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "VDYNAMICFILTERSSELECTOR3.CLICK") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              E231O2 ();
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
                              AV56GridActions = (short)(NumberUtil.Val( cgiGet( cmbavGridactions_Internalname), "."));
                              AssignAttri("", false, cmbavGridactions_Internalname, StringUtil.LTrimStr( (decimal)(AV56GridActions), 4, 0));
                              A149TipCod = cgiGet( edtTipCod_Internalname);
                              A306TipAbr = cgiGet( edtTipAbr_Internalname);
                              A1910TipDsc = cgiGet( edtTipDsc_Internalname);
                              A1921TipVta = (short)(context.localUtil.CToN( cgiGet( edtTipVta_Internalname), ".", ","));
                              A1906TipCmp = (short)(context.localUtil.CToN( cgiGet( edtTipCmp_Internalname), ".", ","));
                              A1915TipRHo = (short)(context.localUtil.CToN( cgiGet( edtTipRHo_Internalname), ".", ","));
                              A1909TipCxP = (short)(((StringUtil.StrCmp(cgiGet( chkTipCxP_Internalname), "1")==0) ? 1 : 0));
                              A1903TipBan = (short)(((StringUtil.StrCmp(cgiGet( chkTipBan_Internalname), "1")==0) ? 1 : 0));
                              A1919TipSts = (short)(context.localUtil.CToN( cgiGet( edtTipSts_Internalname), ".", ","));
                              sEvtType = StringUtil.Right( sEvt, 1);
                              if ( StringUtil.StrCmp(sEvtType, ".") == 0 )
                              {
                                 sEvt = StringUtil.Left( sEvt, (short)(StringUtil.Len( sEvt)-1));
                                 if ( StringUtil.StrCmp(sEvt, "START") == 0 )
                                 {
                                    context.wbHandled = 1;
                                    dynload_actions( ) ;
                                    /* Execute user event: Start */
                                    E241O2 ();
                                 }
                                 else if ( StringUtil.StrCmp(sEvt, "REFRESH") == 0 )
                                 {
                                    context.wbHandled = 1;
                                    dynload_actions( ) ;
                                    /* Execute user event: Refresh */
                                    E251O2 ();
                                 }
                                 else if ( StringUtil.StrCmp(sEvt, "GRID.LOAD") == 0 )
                                 {
                                    context.wbHandled = 1;
                                    dynload_actions( ) ;
                                    E261O2 ();
                                 }
                                 else if ( StringUtil.StrCmp(sEvt, "VGRIDACTIONS.CLICK") == 0 )
                                 {
                                    context.wbHandled = 1;
                                    dynload_actions( ) ;
                                    E271O2 ();
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
                                       /* Set Refresh If Tipdsc1 Changed */
                                       if ( StringUtil.StrCmp(cgiGet( "GXH_vTIPDSC1"), AV17TipDsc1) != 0 )
                                       {
                                          Rfr0gs = true;
                                       }
                                       /* Set Refresh If Tipabr1 Changed */
                                       if ( StringUtil.StrCmp(cgiGet( "GXH_vTIPABR1"), AV66TipAbr1) != 0 )
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
                                       /* Set Refresh If Tipdsc2 Changed */
                                       if ( StringUtil.StrCmp(cgiGet( "GXH_vTIPDSC2"), AV21TipDsc2) != 0 )
                                       {
                                          Rfr0gs = true;
                                       }
                                       /* Set Refresh If Tipabr2 Changed */
                                       if ( StringUtil.StrCmp(cgiGet( "GXH_vTIPABR2"), AV67TipAbr2) != 0 )
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
                                       /* Set Refresh If Tipdsc3 Changed */
                                       if ( StringUtil.StrCmp(cgiGet( "GXH_vTIPDSC3"), AV25TipDsc3) != 0 )
                                       {
                                          Rfr0gs = true;
                                       }
                                       /* Set Refresh If Tipabr3 Changed */
                                       if ( StringUtil.StrCmp(cgiGet( "GXH_vTIPABR3"), AV68TipAbr3) != 0 )
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

      protected void WE1O2( )
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

      protected void PA1O2( )
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
                                       string AV17TipDsc1 ,
                                       string AV66TipAbr1 ,
                                       string AV19DynamicFiltersSelector2 ,
                                       short AV20DynamicFiltersOperator2 ,
                                       string AV21TipDsc2 ,
                                       string AV67TipAbr2 ,
                                       string AV23DynamicFiltersSelector3 ,
                                       short AV24DynamicFiltersOperator3 ,
                                       string AV25TipDsc3 ,
                                       string AV68TipAbr3 ,
                                       bool AV18DynamicFiltersEnabled2 ,
                                       bool AV22DynamicFiltersEnabled3 ,
                                       string AV71Pgmname ,
                                       string AV35TFTipAbr ,
                                       string AV36TFTipAbr_Sel ,
                                       string AV33TFTipDsc ,
                                       string AV34TFTipDsc_Sel ,
                                       short AV59TFTipVta_Sel ,
                                       short AV60TFTipCmp_Sel ,
                                       short AV61TFTipRHo_Sel ,
                                       short AV62TFTipCxP_Sel ,
                                       short AV63TFTipBan_Sel ,
                                       GxSimpleCollection<short> AV65TFTipSts_Sels ,
                                       short AV13OrderedBy ,
                                       bool AV14OrderedDsc ,
                                       GeneXus.Programs.wwpbaseobjects.SdtWWPGridState AV10GridState ,
                                       bool AV27DynamicFiltersIgnoreFirst ,
                                       bool AV26DynamicFiltersRemoving )
      {
         initialize_formulas( ) ;
         GxWebStd.set_html_headers( context, 0, "", "");
         /* Execute user event: Refresh */
         E251O2 ();
         GRID_nCurrentRecord = 0;
         RF1O2( ) ;
         GXKey = Crypto.GetSiteKey( );
         send_integrity_footer_hashes( ) ;
         GXKey = Crypto.GetSiteKey( );
         /* End function gxgrGrid_refresh */
      }

      protected void send_integrity_hashes( )
      {
         GxWebStd.gx_hidden_field( context, "gxhash_TIPCOD", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( A149TipCod, "")), context));
         GxWebStd.gx_hidden_field( context, "TIPCOD", StringUtil.RTrim( A149TipCod));
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
         RF1O2( ) ;
         if ( isFullAjaxMode( ) )
         {
            send_integrity_footer_hashes( ) ;
         }
      }

      protected void initialize_formulas( )
      {
         /* GeneXus formulas. */
         AV71Pgmname = "Configuracion.TipoDocumentoWW";
         context.Gx_err = 0;
      }

      protected void RF1O2( )
      {
         initialize_formulas( ) ;
         clear_multi_value_controls( ) ;
         if ( isAjaxCallMode( ) )
         {
            GridContainer.ClearRows();
         }
         wbStart = 110;
         /* Execute user event: Refresh */
         E251O2 ();
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
                                                 A1919TipSts ,
                                                 AV95Configuracion_tipodocumentowwds_24_tftipsts_sels ,
                                                 AV72Configuracion_tipodocumentowwds_1_dynamicfiltersselector1 ,
                                                 AV73Configuracion_tipodocumentowwds_2_dynamicfiltersoperator1 ,
                                                 AV74Configuracion_tipodocumentowwds_3_tipdsc1 ,
                                                 AV75Configuracion_tipodocumentowwds_4_tipabr1 ,
                                                 AV76Configuracion_tipodocumentowwds_5_dynamicfiltersenabled2 ,
                                                 AV77Configuracion_tipodocumentowwds_6_dynamicfiltersselector2 ,
                                                 AV78Configuracion_tipodocumentowwds_7_dynamicfiltersoperator2 ,
                                                 AV79Configuracion_tipodocumentowwds_8_tipdsc2 ,
                                                 AV80Configuracion_tipodocumentowwds_9_tipabr2 ,
                                                 AV81Configuracion_tipodocumentowwds_10_dynamicfiltersenabled3 ,
                                                 AV82Configuracion_tipodocumentowwds_11_dynamicfiltersselector3 ,
                                                 AV83Configuracion_tipodocumentowwds_12_dynamicfiltersoperator3 ,
                                                 AV84Configuracion_tipodocumentowwds_13_tipdsc3 ,
                                                 AV85Configuracion_tipodocumentowwds_14_tipabr3 ,
                                                 AV87Configuracion_tipodocumentowwds_16_tftipabr_sel ,
                                                 AV86Configuracion_tipodocumentowwds_15_tftipabr ,
                                                 AV89Configuracion_tipodocumentowwds_18_tftipdsc_sel ,
                                                 AV88Configuracion_tipodocumentowwds_17_tftipdsc ,
                                                 AV90Configuracion_tipodocumentowwds_19_tftipvta_sel ,
                                                 AV91Configuracion_tipodocumentowwds_20_tftipcmp_sel ,
                                                 AV92Configuracion_tipodocumentowwds_21_tftiprho_sel ,
                                                 AV93Configuracion_tipodocumentowwds_22_tftipcxp_sel ,
                                                 AV94Configuracion_tipodocumentowwds_23_tftipban_sel ,
                                                 AV95Configuracion_tipodocumentowwds_24_tftipsts_sels.Count ,
                                                 A1910TipDsc ,
                                                 A306TipAbr ,
                                                 A1921TipVta ,
                                                 A1906TipCmp ,
                                                 A1915TipRHo ,
                                                 A1909TipCxP ,
                                                 A1903TipBan ,
                                                 AV13OrderedBy ,
                                                 AV14OrderedDsc } ,
                                                 new int[]{
                                                 TypeConstants.SHORT, TypeConstants.SHORT, TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.SHORT, TypeConstants.SHORT, TypeConstants.SHORT, TypeConstants.SHORT,
                                                 TypeConstants.SHORT, TypeConstants.INT, TypeConstants.SHORT, TypeConstants.SHORT, TypeConstants.SHORT, TypeConstants.SHORT, TypeConstants.SHORT, TypeConstants.SHORT, TypeConstants.BOOLEAN
                                                 }
            });
            lV74Configuracion_tipodocumentowwds_3_tipdsc1 = StringUtil.PadR( StringUtil.RTrim( AV74Configuracion_tipodocumentowwds_3_tipdsc1), 100, "%");
            lV74Configuracion_tipodocumentowwds_3_tipdsc1 = StringUtil.PadR( StringUtil.RTrim( AV74Configuracion_tipodocumentowwds_3_tipdsc1), 100, "%");
            lV75Configuracion_tipodocumentowwds_4_tipabr1 = StringUtil.PadR( StringUtil.RTrim( AV75Configuracion_tipodocumentowwds_4_tipabr1), 5, "%");
            lV75Configuracion_tipodocumentowwds_4_tipabr1 = StringUtil.PadR( StringUtil.RTrim( AV75Configuracion_tipodocumentowwds_4_tipabr1), 5, "%");
            lV79Configuracion_tipodocumentowwds_8_tipdsc2 = StringUtil.PadR( StringUtil.RTrim( AV79Configuracion_tipodocumentowwds_8_tipdsc2), 100, "%");
            lV79Configuracion_tipodocumentowwds_8_tipdsc2 = StringUtil.PadR( StringUtil.RTrim( AV79Configuracion_tipodocumentowwds_8_tipdsc2), 100, "%");
            lV80Configuracion_tipodocumentowwds_9_tipabr2 = StringUtil.PadR( StringUtil.RTrim( AV80Configuracion_tipodocumentowwds_9_tipabr2), 5, "%");
            lV80Configuracion_tipodocumentowwds_9_tipabr2 = StringUtil.PadR( StringUtil.RTrim( AV80Configuracion_tipodocumentowwds_9_tipabr2), 5, "%");
            lV84Configuracion_tipodocumentowwds_13_tipdsc3 = StringUtil.PadR( StringUtil.RTrim( AV84Configuracion_tipodocumentowwds_13_tipdsc3), 100, "%");
            lV84Configuracion_tipodocumentowwds_13_tipdsc3 = StringUtil.PadR( StringUtil.RTrim( AV84Configuracion_tipodocumentowwds_13_tipdsc3), 100, "%");
            lV85Configuracion_tipodocumentowwds_14_tipabr3 = StringUtil.PadR( StringUtil.RTrim( AV85Configuracion_tipodocumentowwds_14_tipabr3), 5, "%");
            lV85Configuracion_tipodocumentowwds_14_tipabr3 = StringUtil.PadR( StringUtil.RTrim( AV85Configuracion_tipodocumentowwds_14_tipabr3), 5, "%");
            lV86Configuracion_tipodocumentowwds_15_tftipabr = StringUtil.PadR( StringUtil.RTrim( AV86Configuracion_tipodocumentowwds_15_tftipabr), 5, "%");
            lV88Configuracion_tipodocumentowwds_17_tftipdsc = StringUtil.PadR( StringUtil.RTrim( AV88Configuracion_tipodocumentowwds_17_tftipdsc), 100, "%");
            /* Using cursor H001O2 */
            pr_default.execute(0, new Object[] {lV74Configuracion_tipodocumentowwds_3_tipdsc1, lV74Configuracion_tipodocumentowwds_3_tipdsc1, lV75Configuracion_tipodocumentowwds_4_tipabr1, lV75Configuracion_tipodocumentowwds_4_tipabr1, lV79Configuracion_tipodocumentowwds_8_tipdsc2, lV79Configuracion_tipodocumentowwds_8_tipdsc2, lV80Configuracion_tipodocumentowwds_9_tipabr2, lV80Configuracion_tipodocumentowwds_9_tipabr2, lV84Configuracion_tipodocumentowwds_13_tipdsc3, lV84Configuracion_tipodocumentowwds_13_tipdsc3, lV85Configuracion_tipodocumentowwds_14_tipabr3, lV85Configuracion_tipodocumentowwds_14_tipabr3, lV86Configuracion_tipodocumentowwds_15_tftipabr, AV87Configuracion_tipodocumentowwds_16_tftipabr_sel, lV88Configuracion_tipodocumentowwds_17_tftipdsc, AV89Configuracion_tipodocumentowwds_18_tftipdsc_sel, GXPagingFrom2, GXPagingTo2, GXPagingTo2});
            nGXsfl_110_idx = 1;
            sGXsfl_110_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_110_idx), 4, 0), 4, "0");
            SubsflControlProps_1102( ) ;
            while ( ( (pr_default.getStatus(0) != 101) ) && ( ( ( subGrid_Rows == 0 ) || ( GRID_nCurrentRecord < subGrid_fnc_Recordsperpage( ) ) ) ) )
            {
               A1919TipSts = H001O2_A1919TipSts[0];
               A1903TipBan = H001O2_A1903TipBan[0];
               A1909TipCxP = H001O2_A1909TipCxP[0];
               A1915TipRHo = H001O2_A1915TipRHo[0];
               A1906TipCmp = H001O2_A1906TipCmp[0];
               A1921TipVta = H001O2_A1921TipVta[0];
               A1910TipDsc = H001O2_A1910TipDsc[0];
               A306TipAbr = H001O2_A306TipAbr[0];
               A149TipCod = H001O2_A149TipCod[0];
               E261O2 ();
               pr_default.readNext(0);
            }
            GRID_nEOF = (short)(((pr_default.getStatus(0) == 101) ? 1 : 0));
            GxWebStd.gx_hidden_field( context, "GRID_nEOF", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRID_nEOF), 1, 0, ".", "")));
            pr_default.close(0);
            wbEnd = 110;
            WB1O0( ) ;
         }
         bGXsfl_110_Refreshing = true;
      }

      protected void send_integrity_lvl_hashes1O2( )
      {
         GxWebStd.gx_hidden_field( context, "vPGMNAME", StringUtil.RTrim( AV71Pgmname));
         GxWebStd.gx_hidden_field( context, "gxhash_vPGMNAME", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( AV71Pgmname, "")), context));
         GxWebStd.gx_hidden_field( context, "gxhash_TIPCOD"+"_"+sGXsfl_110_idx, GetSecureSignedToken( sGXsfl_110_idx, StringUtil.RTrim( context.localUtil.Format( A149TipCod, "")), context));
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
         AV72Configuracion_tipodocumentowwds_1_dynamicfiltersselector1 = AV15DynamicFiltersSelector1;
         AV73Configuracion_tipodocumentowwds_2_dynamicfiltersoperator1 = AV16DynamicFiltersOperator1;
         AV74Configuracion_tipodocumentowwds_3_tipdsc1 = AV17TipDsc1;
         AV75Configuracion_tipodocumentowwds_4_tipabr1 = AV66TipAbr1;
         AV76Configuracion_tipodocumentowwds_5_dynamicfiltersenabled2 = AV18DynamicFiltersEnabled2;
         AV77Configuracion_tipodocumentowwds_6_dynamicfiltersselector2 = AV19DynamicFiltersSelector2;
         AV78Configuracion_tipodocumentowwds_7_dynamicfiltersoperator2 = AV20DynamicFiltersOperator2;
         AV79Configuracion_tipodocumentowwds_8_tipdsc2 = AV21TipDsc2;
         AV80Configuracion_tipodocumentowwds_9_tipabr2 = AV67TipAbr2;
         AV81Configuracion_tipodocumentowwds_10_dynamicfiltersenabled3 = AV22DynamicFiltersEnabled3;
         AV82Configuracion_tipodocumentowwds_11_dynamicfiltersselector3 = AV23DynamicFiltersSelector3;
         AV83Configuracion_tipodocumentowwds_12_dynamicfiltersoperator3 = AV24DynamicFiltersOperator3;
         AV84Configuracion_tipodocumentowwds_13_tipdsc3 = AV25TipDsc3;
         AV85Configuracion_tipodocumentowwds_14_tipabr3 = AV68TipAbr3;
         AV86Configuracion_tipodocumentowwds_15_tftipabr = AV35TFTipAbr;
         AV87Configuracion_tipodocumentowwds_16_tftipabr_sel = AV36TFTipAbr_Sel;
         AV88Configuracion_tipodocumentowwds_17_tftipdsc = AV33TFTipDsc;
         AV89Configuracion_tipodocumentowwds_18_tftipdsc_sel = AV34TFTipDsc_Sel;
         AV90Configuracion_tipodocumentowwds_19_tftipvta_sel = AV59TFTipVta_Sel;
         AV91Configuracion_tipodocumentowwds_20_tftipcmp_sel = AV60TFTipCmp_Sel;
         AV92Configuracion_tipodocumentowwds_21_tftiprho_sel = AV61TFTipRHo_Sel;
         AV93Configuracion_tipodocumentowwds_22_tftipcxp_sel = AV62TFTipCxP_Sel;
         AV94Configuracion_tipodocumentowwds_23_tftipban_sel = AV63TFTipBan_Sel;
         AV95Configuracion_tipodocumentowwds_24_tftipsts_sels = AV65TFTipSts_Sels;
         pr_default.dynParam(1, new Object[]{ new Object[]{
                                              A1919TipSts ,
                                              AV95Configuracion_tipodocumentowwds_24_tftipsts_sels ,
                                              AV72Configuracion_tipodocumentowwds_1_dynamicfiltersselector1 ,
                                              AV73Configuracion_tipodocumentowwds_2_dynamicfiltersoperator1 ,
                                              AV74Configuracion_tipodocumentowwds_3_tipdsc1 ,
                                              AV75Configuracion_tipodocumentowwds_4_tipabr1 ,
                                              AV76Configuracion_tipodocumentowwds_5_dynamicfiltersenabled2 ,
                                              AV77Configuracion_tipodocumentowwds_6_dynamicfiltersselector2 ,
                                              AV78Configuracion_tipodocumentowwds_7_dynamicfiltersoperator2 ,
                                              AV79Configuracion_tipodocumentowwds_8_tipdsc2 ,
                                              AV80Configuracion_tipodocumentowwds_9_tipabr2 ,
                                              AV81Configuracion_tipodocumentowwds_10_dynamicfiltersenabled3 ,
                                              AV82Configuracion_tipodocumentowwds_11_dynamicfiltersselector3 ,
                                              AV83Configuracion_tipodocumentowwds_12_dynamicfiltersoperator3 ,
                                              AV84Configuracion_tipodocumentowwds_13_tipdsc3 ,
                                              AV85Configuracion_tipodocumentowwds_14_tipabr3 ,
                                              AV87Configuracion_tipodocumentowwds_16_tftipabr_sel ,
                                              AV86Configuracion_tipodocumentowwds_15_tftipabr ,
                                              AV89Configuracion_tipodocumentowwds_18_tftipdsc_sel ,
                                              AV88Configuracion_tipodocumentowwds_17_tftipdsc ,
                                              AV90Configuracion_tipodocumentowwds_19_tftipvta_sel ,
                                              AV91Configuracion_tipodocumentowwds_20_tftipcmp_sel ,
                                              AV92Configuracion_tipodocumentowwds_21_tftiprho_sel ,
                                              AV93Configuracion_tipodocumentowwds_22_tftipcxp_sel ,
                                              AV94Configuracion_tipodocumentowwds_23_tftipban_sel ,
                                              AV95Configuracion_tipodocumentowwds_24_tftipsts_sels.Count ,
                                              A1910TipDsc ,
                                              A306TipAbr ,
                                              A1921TipVta ,
                                              A1906TipCmp ,
                                              A1915TipRHo ,
                                              A1909TipCxP ,
                                              A1903TipBan ,
                                              AV13OrderedBy ,
                                              AV14OrderedDsc } ,
                                              new int[]{
                                              TypeConstants.SHORT, TypeConstants.SHORT, TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.SHORT, TypeConstants.SHORT, TypeConstants.SHORT, TypeConstants.SHORT,
                                              TypeConstants.SHORT, TypeConstants.INT, TypeConstants.SHORT, TypeConstants.SHORT, TypeConstants.SHORT, TypeConstants.SHORT, TypeConstants.SHORT, TypeConstants.SHORT, TypeConstants.BOOLEAN
                                              }
         });
         lV74Configuracion_tipodocumentowwds_3_tipdsc1 = StringUtil.PadR( StringUtil.RTrim( AV74Configuracion_tipodocumentowwds_3_tipdsc1), 100, "%");
         lV74Configuracion_tipodocumentowwds_3_tipdsc1 = StringUtil.PadR( StringUtil.RTrim( AV74Configuracion_tipodocumentowwds_3_tipdsc1), 100, "%");
         lV75Configuracion_tipodocumentowwds_4_tipabr1 = StringUtil.PadR( StringUtil.RTrim( AV75Configuracion_tipodocumentowwds_4_tipabr1), 5, "%");
         lV75Configuracion_tipodocumentowwds_4_tipabr1 = StringUtil.PadR( StringUtil.RTrim( AV75Configuracion_tipodocumentowwds_4_tipabr1), 5, "%");
         lV79Configuracion_tipodocumentowwds_8_tipdsc2 = StringUtil.PadR( StringUtil.RTrim( AV79Configuracion_tipodocumentowwds_8_tipdsc2), 100, "%");
         lV79Configuracion_tipodocumentowwds_8_tipdsc2 = StringUtil.PadR( StringUtil.RTrim( AV79Configuracion_tipodocumentowwds_8_tipdsc2), 100, "%");
         lV80Configuracion_tipodocumentowwds_9_tipabr2 = StringUtil.PadR( StringUtil.RTrim( AV80Configuracion_tipodocumentowwds_9_tipabr2), 5, "%");
         lV80Configuracion_tipodocumentowwds_9_tipabr2 = StringUtil.PadR( StringUtil.RTrim( AV80Configuracion_tipodocumentowwds_9_tipabr2), 5, "%");
         lV84Configuracion_tipodocumentowwds_13_tipdsc3 = StringUtil.PadR( StringUtil.RTrim( AV84Configuracion_tipodocumentowwds_13_tipdsc3), 100, "%");
         lV84Configuracion_tipodocumentowwds_13_tipdsc3 = StringUtil.PadR( StringUtil.RTrim( AV84Configuracion_tipodocumentowwds_13_tipdsc3), 100, "%");
         lV85Configuracion_tipodocumentowwds_14_tipabr3 = StringUtil.PadR( StringUtil.RTrim( AV85Configuracion_tipodocumentowwds_14_tipabr3), 5, "%");
         lV85Configuracion_tipodocumentowwds_14_tipabr3 = StringUtil.PadR( StringUtil.RTrim( AV85Configuracion_tipodocumentowwds_14_tipabr3), 5, "%");
         lV86Configuracion_tipodocumentowwds_15_tftipabr = StringUtil.PadR( StringUtil.RTrim( AV86Configuracion_tipodocumentowwds_15_tftipabr), 5, "%");
         lV88Configuracion_tipodocumentowwds_17_tftipdsc = StringUtil.PadR( StringUtil.RTrim( AV88Configuracion_tipodocumentowwds_17_tftipdsc), 100, "%");
         /* Using cursor H001O3 */
         pr_default.execute(1, new Object[] {lV74Configuracion_tipodocumentowwds_3_tipdsc1, lV74Configuracion_tipodocumentowwds_3_tipdsc1, lV75Configuracion_tipodocumentowwds_4_tipabr1, lV75Configuracion_tipodocumentowwds_4_tipabr1, lV79Configuracion_tipodocumentowwds_8_tipdsc2, lV79Configuracion_tipodocumentowwds_8_tipdsc2, lV80Configuracion_tipodocumentowwds_9_tipabr2, lV80Configuracion_tipodocumentowwds_9_tipabr2, lV84Configuracion_tipodocumentowwds_13_tipdsc3, lV84Configuracion_tipodocumentowwds_13_tipdsc3, lV85Configuracion_tipodocumentowwds_14_tipabr3, lV85Configuracion_tipodocumentowwds_14_tipabr3, lV86Configuracion_tipodocumentowwds_15_tftipabr, AV87Configuracion_tipodocumentowwds_16_tftipabr_sel, lV88Configuracion_tipodocumentowwds_17_tftipdsc, AV89Configuracion_tipodocumentowwds_18_tftipdsc_sel});
         GRID_nRecordCount = H001O3_AGRID_nRecordCount[0];
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
         AV72Configuracion_tipodocumentowwds_1_dynamicfiltersselector1 = AV15DynamicFiltersSelector1;
         AV73Configuracion_tipodocumentowwds_2_dynamicfiltersoperator1 = AV16DynamicFiltersOperator1;
         AV74Configuracion_tipodocumentowwds_3_tipdsc1 = AV17TipDsc1;
         AV75Configuracion_tipodocumentowwds_4_tipabr1 = AV66TipAbr1;
         AV76Configuracion_tipodocumentowwds_5_dynamicfiltersenabled2 = AV18DynamicFiltersEnabled2;
         AV77Configuracion_tipodocumentowwds_6_dynamicfiltersselector2 = AV19DynamicFiltersSelector2;
         AV78Configuracion_tipodocumentowwds_7_dynamicfiltersoperator2 = AV20DynamicFiltersOperator2;
         AV79Configuracion_tipodocumentowwds_8_tipdsc2 = AV21TipDsc2;
         AV80Configuracion_tipodocumentowwds_9_tipabr2 = AV67TipAbr2;
         AV81Configuracion_tipodocumentowwds_10_dynamicfiltersenabled3 = AV22DynamicFiltersEnabled3;
         AV82Configuracion_tipodocumentowwds_11_dynamicfiltersselector3 = AV23DynamicFiltersSelector3;
         AV83Configuracion_tipodocumentowwds_12_dynamicfiltersoperator3 = AV24DynamicFiltersOperator3;
         AV84Configuracion_tipodocumentowwds_13_tipdsc3 = AV25TipDsc3;
         AV85Configuracion_tipodocumentowwds_14_tipabr3 = AV68TipAbr3;
         AV86Configuracion_tipodocumentowwds_15_tftipabr = AV35TFTipAbr;
         AV87Configuracion_tipodocumentowwds_16_tftipabr_sel = AV36TFTipAbr_Sel;
         AV88Configuracion_tipodocumentowwds_17_tftipdsc = AV33TFTipDsc;
         AV89Configuracion_tipodocumentowwds_18_tftipdsc_sel = AV34TFTipDsc_Sel;
         AV90Configuracion_tipodocumentowwds_19_tftipvta_sel = AV59TFTipVta_Sel;
         AV91Configuracion_tipodocumentowwds_20_tftipcmp_sel = AV60TFTipCmp_Sel;
         AV92Configuracion_tipodocumentowwds_21_tftiprho_sel = AV61TFTipRHo_Sel;
         AV93Configuracion_tipodocumentowwds_22_tftipcxp_sel = AV62TFTipCxP_Sel;
         AV94Configuracion_tipodocumentowwds_23_tftipban_sel = AV63TFTipBan_Sel;
         AV95Configuracion_tipodocumentowwds_24_tftipsts_sels = AV65TFTipSts_Sels;
         GRID_nFirstRecordOnPage = 0;
         GxWebStd.gx_hidden_field( context, "GRID_nFirstRecordOnPage", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRID_nFirstRecordOnPage), 15, 0, ".", "")));
         if ( isFullAjaxMode( ) )
         {
            gxgrGrid_refresh( subGrid_Rows, AV15DynamicFiltersSelector1, AV16DynamicFiltersOperator1, AV17TipDsc1, AV66TipAbr1, AV19DynamicFiltersSelector2, AV20DynamicFiltersOperator2, AV21TipDsc2, AV67TipAbr2, AV23DynamicFiltersSelector3, AV24DynamicFiltersOperator3, AV25TipDsc3, AV68TipAbr3, AV18DynamicFiltersEnabled2, AV22DynamicFiltersEnabled3, AV71Pgmname, AV35TFTipAbr, AV36TFTipAbr_Sel, AV33TFTipDsc, AV34TFTipDsc_Sel, AV59TFTipVta_Sel, AV60TFTipCmp_Sel, AV61TFTipRHo_Sel, AV62TFTipCxP_Sel, AV63TFTipBan_Sel, AV65TFTipSts_Sels, AV13OrderedBy, AV14OrderedDsc, AV10GridState, AV27DynamicFiltersIgnoreFirst, AV26DynamicFiltersRemoving) ;
         }
         send_integrity_footer_hashes( ) ;
         return 0 ;
      }

      protected short subgrid_nextpage( )
      {
         AV72Configuracion_tipodocumentowwds_1_dynamicfiltersselector1 = AV15DynamicFiltersSelector1;
         AV73Configuracion_tipodocumentowwds_2_dynamicfiltersoperator1 = AV16DynamicFiltersOperator1;
         AV74Configuracion_tipodocumentowwds_3_tipdsc1 = AV17TipDsc1;
         AV75Configuracion_tipodocumentowwds_4_tipabr1 = AV66TipAbr1;
         AV76Configuracion_tipodocumentowwds_5_dynamicfiltersenabled2 = AV18DynamicFiltersEnabled2;
         AV77Configuracion_tipodocumentowwds_6_dynamicfiltersselector2 = AV19DynamicFiltersSelector2;
         AV78Configuracion_tipodocumentowwds_7_dynamicfiltersoperator2 = AV20DynamicFiltersOperator2;
         AV79Configuracion_tipodocumentowwds_8_tipdsc2 = AV21TipDsc2;
         AV80Configuracion_tipodocumentowwds_9_tipabr2 = AV67TipAbr2;
         AV81Configuracion_tipodocumentowwds_10_dynamicfiltersenabled3 = AV22DynamicFiltersEnabled3;
         AV82Configuracion_tipodocumentowwds_11_dynamicfiltersselector3 = AV23DynamicFiltersSelector3;
         AV83Configuracion_tipodocumentowwds_12_dynamicfiltersoperator3 = AV24DynamicFiltersOperator3;
         AV84Configuracion_tipodocumentowwds_13_tipdsc3 = AV25TipDsc3;
         AV85Configuracion_tipodocumentowwds_14_tipabr3 = AV68TipAbr3;
         AV86Configuracion_tipodocumentowwds_15_tftipabr = AV35TFTipAbr;
         AV87Configuracion_tipodocumentowwds_16_tftipabr_sel = AV36TFTipAbr_Sel;
         AV88Configuracion_tipodocumentowwds_17_tftipdsc = AV33TFTipDsc;
         AV89Configuracion_tipodocumentowwds_18_tftipdsc_sel = AV34TFTipDsc_Sel;
         AV90Configuracion_tipodocumentowwds_19_tftipvta_sel = AV59TFTipVta_Sel;
         AV91Configuracion_tipodocumentowwds_20_tftipcmp_sel = AV60TFTipCmp_Sel;
         AV92Configuracion_tipodocumentowwds_21_tftiprho_sel = AV61TFTipRHo_Sel;
         AV93Configuracion_tipodocumentowwds_22_tftipcxp_sel = AV62TFTipCxP_Sel;
         AV94Configuracion_tipodocumentowwds_23_tftipban_sel = AV63TFTipBan_Sel;
         AV95Configuracion_tipodocumentowwds_24_tftipsts_sels = AV65TFTipSts_Sels;
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
            gxgrGrid_refresh( subGrid_Rows, AV15DynamicFiltersSelector1, AV16DynamicFiltersOperator1, AV17TipDsc1, AV66TipAbr1, AV19DynamicFiltersSelector2, AV20DynamicFiltersOperator2, AV21TipDsc2, AV67TipAbr2, AV23DynamicFiltersSelector3, AV24DynamicFiltersOperator3, AV25TipDsc3, AV68TipAbr3, AV18DynamicFiltersEnabled2, AV22DynamicFiltersEnabled3, AV71Pgmname, AV35TFTipAbr, AV36TFTipAbr_Sel, AV33TFTipDsc, AV34TFTipDsc_Sel, AV59TFTipVta_Sel, AV60TFTipCmp_Sel, AV61TFTipRHo_Sel, AV62TFTipCxP_Sel, AV63TFTipBan_Sel, AV65TFTipSts_Sels, AV13OrderedBy, AV14OrderedDsc, AV10GridState, AV27DynamicFiltersIgnoreFirst, AV26DynamicFiltersRemoving) ;
         }
         send_integrity_footer_hashes( ) ;
         return (short)(((GRID_nEOF==0) ? 0 : 2)) ;
      }

      protected short subgrid_previouspage( )
      {
         AV72Configuracion_tipodocumentowwds_1_dynamicfiltersselector1 = AV15DynamicFiltersSelector1;
         AV73Configuracion_tipodocumentowwds_2_dynamicfiltersoperator1 = AV16DynamicFiltersOperator1;
         AV74Configuracion_tipodocumentowwds_3_tipdsc1 = AV17TipDsc1;
         AV75Configuracion_tipodocumentowwds_4_tipabr1 = AV66TipAbr1;
         AV76Configuracion_tipodocumentowwds_5_dynamicfiltersenabled2 = AV18DynamicFiltersEnabled2;
         AV77Configuracion_tipodocumentowwds_6_dynamicfiltersselector2 = AV19DynamicFiltersSelector2;
         AV78Configuracion_tipodocumentowwds_7_dynamicfiltersoperator2 = AV20DynamicFiltersOperator2;
         AV79Configuracion_tipodocumentowwds_8_tipdsc2 = AV21TipDsc2;
         AV80Configuracion_tipodocumentowwds_9_tipabr2 = AV67TipAbr2;
         AV81Configuracion_tipodocumentowwds_10_dynamicfiltersenabled3 = AV22DynamicFiltersEnabled3;
         AV82Configuracion_tipodocumentowwds_11_dynamicfiltersselector3 = AV23DynamicFiltersSelector3;
         AV83Configuracion_tipodocumentowwds_12_dynamicfiltersoperator3 = AV24DynamicFiltersOperator3;
         AV84Configuracion_tipodocumentowwds_13_tipdsc3 = AV25TipDsc3;
         AV85Configuracion_tipodocumentowwds_14_tipabr3 = AV68TipAbr3;
         AV86Configuracion_tipodocumentowwds_15_tftipabr = AV35TFTipAbr;
         AV87Configuracion_tipodocumentowwds_16_tftipabr_sel = AV36TFTipAbr_Sel;
         AV88Configuracion_tipodocumentowwds_17_tftipdsc = AV33TFTipDsc;
         AV89Configuracion_tipodocumentowwds_18_tftipdsc_sel = AV34TFTipDsc_Sel;
         AV90Configuracion_tipodocumentowwds_19_tftipvta_sel = AV59TFTipVta_Sel;
         AV91Configuracion_tipodocumentowwds_20_tftipcmp_sel = AV60TFTipCmp_Sel;
         AV92Configuracion_tipodocumentowwds_21_tftiprho_sel = AV61TFTipRHo_Sel;
         AV93Configuracion_tipodocumentowwds_22_tftipcxp_sel = AV62TFTipCxP_Sel;
         AV94Configuracion_tipodocumentowwds_23_tftipban_sel = AV63TFTipBan_Sel;
         AV95Configuracion_tipodocumentowwds_24_tftipsts_sels = AV65TFTipSts_Sels;
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
            gxgrGrid_refresh( subGrid_Rows, AV15DynamicFiltersSelector1, AV16DynamicFiltersOperator1, AV17TipDsc1, AV66TipAbr1, AV19DynamicFiltersSelector2, AV20DynamicFiltersOperator2, AV21TipDsc2, AV67TipAbr2, AV23DynamicFiltersSelector3, AV24DynamicFiltersOperator3, AV25TipDsc3, AV68TipAbr3, AV18DynamicFiltersEnabled2, AV22DynamicFiltersEnabled3, AV71Pgmname, AV35TFTipAbr, AV36TFTipAbr_Sel, AV33TFTipDsc, AV34TFTipDsc_Sel, AV59TFTipVta_Sel, AV60TFTipCmp_Sel, AV61TFTipRHo_Sel, AV62TFTipCxP_Sel, AV63TFTipBan_Sel, AV65TFTipSts_Sels, AV13OrderedBy, AV14OrderedDsc, AV10GridState, AV27DynamicFiltersIgnoreFirst, AV26DynamicFiltersRemoving) ;
         }
         send_integrity_footer_hashes( ) ;
         return 0 ;
      }

      protected short subgrid_lastpage( )
      {
         AV72Configuracion_tipodocumentowwds_1_dynamicfiltersselector1 = AV15DynamicFiltersSelector1;
         AV73Configuracion_tipodocumentowwds_2_dynamicfiltersoperator1 = AV16DynamicFiltersOperator1;
         AV74Configuracion_tipodocumentowwds_3_tipdsc1 = AV17TipDsc1;
         AV75Configuracion_tipodocumentowwds_4_tipabr1 = AV66TipAbr1;
         AV76Configuracion_tipodocumentowwds_5_dynamicfiltersenabled2 = AV18DynamicFiltersEnabled2;
         AV77Configuracion_tipodocumentowwds_6_dynamicfiltersselector2 = AV19DynamicFiltersSelector2;
         AV78Configuracion_tipodocumentowwds_7_dynamicfiltersoperator2 = AV20DynamicFiltersOperator2;
         AV79Configuracion_tipodocumentowwds_8_tipdsc2 = AV21TipDsc2;
         AV80Configuracion_tipodocumentowwds_9_tipabr2 = AV67TipAbr2;
         AV81Configuracion_tipodocumentowwds_10_dynamicfiltersenabled3 = AV22DynamicFiltersEnabled3;
         AV82Configuracion_tipodocumentowwds_11_dynamicfiltersselector3 = AV23DynamicFiltersSelector3;
         AV83Configuracion_tipodocumentowwds_12_dynamicfiltersoperator3 = AV24DynamicFiltersOperator3;
         AV84Configuracion_tipodocumentowwds_13_tipdsc3 = AV25TipDsc3;
         AV85Configuracion_tipodocumentowwds_14_tipabr3 = AV68TipAbr3;
         AV86Configuracion_tipodocumentowwds_15_tftipabr = AV35TFTipAbr;
         AV87Configuracion_tipodocumentowwds_16_tftipabr_sel = AV36TFTipAbr_Sel;
         AV88Configuracion_tipodocumentowwds_17_tftipdsc = AV33TFTipDsc;
         AV89Configuracion_tipodocumentowwds_18_tftipdsc_sel = AV34TFTipDsc_Sel;
         AV90Configuracion_tipodocumentowwds_19_tftipvta_sel = AV59TFTipVta_Sel;
         AV91Configuracion_tipodocumentowwds_20_tftipcmp_sel = AV60TFTipCmp_Sel;
         AV92Configuracion_tipodocumentowwds_21_tftiprho_sel = AV61TFTipRHo_Sel;
         AV93Configuracion_tipodocumentowwds_22_tftipcxp_sel = AV62TFTipCxP_Sel;
         AV94Configuracion_tipodocumentowwds_23_tftipban_sel = AV63TFTipBan_Sel;
         AV95Configuracion_tipodocumentowwds_24_tftipsts_sels = AV65TFTipSts_Sels;
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
            gxgrGrid_refresh( subGrid_Rows, AV15DynamicFiltersSelector1, AV16DynamicFiltersOperator1, AV17TipDsc1, AV66TipAbr1, AV19DynamicFiltersSelector2, AV20DynamicFiltersOperator2, AV21TipDsc2, AV67TipAbr2, AV23DynamicFiltersSelector3, AV24DynamicFiltersOperator3, AV25TipDsc3, AV68TipAbr3, AV18DynamicFiltersEnabled2, AV22DynamicFiltersEnabled3, AV71Pgmname, AV35TFTipAbr, AV36TFTipAbr_Sel, AV33TFTipDsc, AV34TFTipDsc_Sel, AV59TFTipVta_Sel, AV60TFTipCmp_Sel, AV61TFTipRHo_Sel, AV62TFTipCxP_Sel, AV63TFTipBan_Sel, AV65TFTipSts_Sels, AV13OrderedBy, AV14OrderedDsc, AV10GridState, AV27DynamicFiltersIgnoreFirst, AV26DynamicFiltersRemoving) ;
         }
         send_integrity_footer_hashes( ) ;
         return 0 ;
      }

      protected int subgrid_gotopage( int nPageNo )
      {
         AV72Configuracion_tipodocumentowwds_1_dynamicfiltersselector1 = AV15DynamicFiltersSelector1;
         AV73Configuracion_tipodocumentowwds_2_dynamicfiltersoperator1 = AV16DynamicFiltersOperator1;
         AV74Configuracion_tipodocumentowwds_3_tipdsc1 = AV17TipDsc1;
         AV75Configuracion_tipodocumentowwds_4_tipabr1 = AV66TipAbr1;
         AV76Configuracion_tipodocumentowwds_5_dynamicfiltersenabled2 = AV18DynamicFiltersEnabled2;
         AV77Configuracion_tipodocumentowwds_6_dynamicfiltersselector2 = AV19DynamicFiltersSelector2;
         AV78Configuracion_tipodocumentowwds_7_dynamicfiltersoperator2 = AV20DynamicFiltersOperator2;
         AV79Configuracion_tipodocumentowwds_8_tipdsc2 = AV21TipDsc2;
         AV80Configuracion_tipodocumentowwds_9_tipabr2 = AV67TipAbr2;
         AV81Configuracion_tipodocumentowwds_10_dynamicfiltersenabled3 = AV22DynamicFiltersEnabled3;
         AV82Configuracion_tipodocumentowwds_11_dynamicfiltersselector3 = AV23DynamicFiltersSelector3;
         AV83Configuracion_tipodocumentowwds_12_dynamicfiltersoperator3 = AV24DynamicFiltersOperator3;
         AV84Configuracion_tipodocumentowwds_13_tipdsc3 = AV25TipDsc3;
         AV85Configuracion_tipodocumentowwds_14_tipabr3 = AV68TipAbr3;
         AV86Configuracion_tipodocumentowwds_15_tftipabr = AV35TFTipAbr;
         AV87Configuracion_tipodocumentowwds_16_tftipabr_sel = AV36TFTipAbr_Sel;
         AV88Configuracion_tipodocumentowwds_17_tftipdsc = AV33TFTipDsc;
         AV89Configuracion_tipodocumentowwds_18_tftipdsc_sel = AV34TFTipDsc_Sel;
         AV90Configuracion_tipodocumentowwds_19_tftipvta_sel = AV59TFTipVta_Sel;
         AV91Configuracion_tipodocumentowwds_20_tftipcmp_sel = AV60TFTipCmp_Sel;
         AV92Configuracion_tipodocumentowwds_21_tftiprho_sel = AV61TFTipRHo_Sel;
         AV93Configuracion_tipodocumentowwds_22_tftipcxp_sel = AV62TFTipCxP_Sel;
         AV94Configuracion_tipodocumentowwds_23_tftipban_sel = AV63TFTipBan_Sel;
         AV95Configuracion_tipodocumentowwds_24_tftipsts_sels = AV65TFTipSts_Sels;
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
            gxgrGrid_refresh( subGrid_Rows, AV15DynamicFiltersSelector1, AV16DynamicFiltersOperator1, AV17TipDsc1, AV66TipAbr1, AV19DynamicFiltersSelector2, AV20DynamicFiltersOperator2, AV21TipDsc2, AV67TipAbr2, AV23DynamicFiltersSelector3, AV24DynamicFiltersOperator3, AV25TipDsc3, AV68TipAbr3, AV18DynamicFiltersEnabled2, AV22DynamicFiltersEnabled3, AV71Pgmname, AV35TFTipAbr, AV36TFTipAbr_Sel, AV33TFTipDsc, AV34TFTipDsc_Sel, AV59TFTipVta_Sel, AV60TFTipCmp_Sel, AV61TFTipRHo_Sel, AV62TFTipCxP_Sel, AV63TFTipBan_Sel, AV65TFTipSts_Sels, AV13OrderedBy, AV14OrderedDsc, AV10GridState, AV27DynamicFiltersIgnoreFirst, AV26DynamicFiltersRemoving) ;
         }
         send_integrity_footer_hashes( ) ;
         return (int)(0) ;
      }

      protected void before_start_formulas( )
      {
         AV71Pgmname = "Configuracion.TipoDocumentoWW";
         context.Gx_err = 0;
         fix_multi_value_controls( ) ;
      }

      protected void STRUP1O0( )
      {
         /* Before Start, stand alone formulas. */
         before_start_formulas( ) ;
         /* Execute Start event if defined. */
         context.wbGlbDoneStart = 0;
         /* Execute user event: Start */
         E241O2 ();
         context.wbGlbDoneStart = 1;
         /* After Start, stand alone formulas. */
         if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
         {
            /* Read saved SDTs. */
            ajax_req_read_hidden_sdt(cgiGet( "vAGEXPORTDATA"), AV57AGExportData);
            ajax_req_read_hidden_sdt(cgiGet( "vDDO_TITLESETTINGSICONS"), AV51DDO_TitleSettingsIcons);
            /* Read saved values. */
            nRC_GXsfl_110 = (int)(context.localUtil.CToN( cgiGet( "nRC_GXsfl_110"), ".", ","));
            AV53GridCurrentPage = (long)(context.localUtil.CToN( cgiGet( "vGRIDCURRENTPAGE"), ".", ","));
            AV54GridPageCount = (long)(context.localUtil.CToN( cgiGet( "vGRIDPAGECOUNT"), ".", ","));
            AV55GridAppliedFilters = cgiGet( "vGRIDAPPLIEDFILTERS");
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
            AV17TipDsc1 = cgiGet( edtavTipdsc1_Internalname);
            AssignAttri("", false, "AV17TipDsc1", AV17TipDsc1);
            AV66TipAbr1 = cgiGet( edtavTipabr1_Internalname);
            AssignAttri("", false, "AV66TipAbr1", AV66TipAbr1);
            cmbavDynamicfiltersselector2.Name = cmbavDynamicfiltersselector2_Internalname;
            cmbavDynamicfiltersselector2.CurrentValue = cgiGet( cmbavDynamicfiltersselector2_Internalname);
            AV19DynamicFiltersSelector2 = cgiGet( cmbavDynamicfiltersselector2_Internalname);
            AssignAttri("", false, "AV19DynamicFiltersSelector2", AV19DynamicFiltersSelector2);
            cmbavDynamicfiltersoperator2.Name = cmbavDynamicfiltersoperator2_Internalname;
            cmbavDynamicfiltersoperator2.CurrentValue = cgiGet( cmbavDynamicfiltersoperator2_Internalname);
            AV20DynamicFiltersOperator2 = (short)(NumberUtil.Val( cgiGet( cmbavDynamicfiltersoperator2_Internalname), "."));
            AssignAttri("", false, "AV20DynamicFiltersOperator2", StringUtil.LTrimStr( (decimal)(AV20DynamicFiltersOperator2), 4, 0));
            AV21TipDsc2 = cgiGet( edtavTipdsc2_Internalname);
            AssignAttri("", false, "AV21TipDsc2", AV21TipDsc2);
            AV67TipAbr2 = cgiGet( edtavTipabr2_Internalname);
            AssignAttri("", false, "AV67TipAbr2", AV67TipAbr2);
            cmbavDynamicfiltersselector3.Name = cmbavDynamicfiltersselector3_Internalname;
            cmbavDynamicfiltersselector3.CurrentValue = cgiGet( cmbavDynamicfiltersselector3_Internalname);
            AV23DynamicFiltersSelector3 = cgiGet( cmbavDynamicfiltersselector3_Internalname);
            AssignAttri("", false, "AV23DynamicFiltersSelector3", AV23DynamicFiltersSelector3);
            cmbavDynamicfiltersoperator3.Name = cmbavDynamicfiltersoperator3_Internalname;
            cmbavDynamicfiltersoperator3.CurrentValue = cgiGet( cmbavDynamicfiltersoperator3_Internalname);
            AV24DynamicFiltersOperator3 = (short)(NumberUtil.Val( cgiGet( cmbavDynamicfiltersoperator3_Internalname), "."));
            AssignAttri("", false, "AV24DynamicFiltersOperator3", StringUtil.LTrimStr( (decimal)(AV24DynamicFiltersOperator3), 4, 0));
            AV25TipDsc3 = cgiGet( edtavTipdsc3_Internalname);
            AssignAttri("", false, "AV25TipDsc3", AV25TipDsc3);
            AV68TipAbr3 = cgiGet( edtavTipabr3_Internalname);
            AssignAttri("", false, "AV68TipAbr3", AV68TipAbr3);
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
            if ( StringUtil.StrCmp(cgiGet( "GXH_vTIPDSC1"), AV17TipDsc1) != 0 )
            {
               GRID_nFirstRecordOnPage = 0;
            }
            if ( StringUtil.StrCmp(cgiGet( "GXH_vTIPABR1"), AV66TipAbr1) != 0 )
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
            if ( StringUtil.StrCmp(cgiGet( "GXH_vTIPDSC2"), AV21TipDsc2) != 0 )
            {
               GRID_nFirstRecordOnPage = 0;
            }
            if ( StringUtil.StrCmp(cgiGet( "GXH_vTIPABR2"), AV67TipAbr2) != 0 )
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
            if ( StringUtil.StrCmp(cgiGet( "GXH_vTIPDSC3"), AV25TipDsc3) != 0 )
            {
               GRID_nFirstRecordOnPage = 0;
            }
            if ( StringUtil.StrCmp(cgiGet( "GXH_vTIPABR3"), AV68TipAbr3) != 0 )
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
         E241O2 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
      }

      protected void E241O2( )
      {
         /* Start Routine */
         returnInSub = false;
         subGrid_Rows = 10;
         GxWebStd.gx_hidden_field( context, "GRID_Rows", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid_Rows), 6, 0, ".", "")));
         Grid_empowerer_Gridinternalname = subGrid_Internalname;
         ucGrid_empowerer.SendProperty(context, "", false, Grid_empowerer_Internalname, "GridInternalName", Grid_empowerer_Gridinternalname);
         lblJsdynamicfilters_Caption = "";
         AssignProp("", false, lblJsdynamicfilters_Internalname, "Caption", lblJsdynamicfilters_Caption, true);
         AV15DynamicFiltersSelector1 = "TIPDSC";
         AssignAttri("", false, "AV15DynamicFiltersSelector1", AV15DynamicFiltersSelector1);
         /* Execute user subroutine: 'ENABLEDYNAMICFILTERS1' */
         S112 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
         AV19DynamicFiltersSelector2 = "TIPDSC";
         AssignAttri("", false, "AV19DynamicFiltersSelector2", AV19DynamicFiltersSelector2);
         /* Execute user subroutine: 'ENABLEDYNAMICFILTERS2' */
         S122 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
         AV23DynamicFiltersSelector3 = "TIPDSC";
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
         AV57AGExportData = new GXBaseCollection<GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTDropDownOptionsData_Item>( context, "Item", "");
         AV58AGExportDataItem = new GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTDropDownOptionsData_Item(context);
         AV58AGExportDataItem.gxTpr_Title = "PDF";
         AV58AGExportDataItem.gxTpr_Icon = context.convertURL( (string)(context.GetImagePath( "776fb79c-a0a1-4302-b5e5-d773dbe1a297", "", context.GetTheme( ))));
         AV58AGExportDataItem.gxTpr_Eventkey = "ExportReport";
         AV58AGExportDataItem.gxTpr_Isdivider = false;
         AV57AGExportData.Add(AV58AGExportDataItem, 0);
         AV58AGExportDataItem = new GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTDropDownOptionsData_Item(context);
         AV58AGExportDataItem.gxTpr_Title = "Excel";
         AV58AGExportDataItem.gxTpr_Icon = context.convertURL( (string)(context.GetImagePath( "da69a816-fd11-445b-8aaf-1a2f7f1acc93", "", context.GetTheme( ))));
         AV58AGExportDataItem.gxTpr_Eventkey = "Export";
         AV58AGExportDataItem.gxTpr_Isdivider = false;
         AV57AGExportData.Add(AV58AGExportDataItem, 0);
         Ddo_grid_Gridinternalname = subGrid_Internalname;
         ucDdo_grid.SendProperty(context, "", false, Ddo_grid_Internalname, "GridInternalName", Ddo_grid_Gridinternalname);
         Form.Caption = "Tipo de Documentos";
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
         GXt_SdtDVB_SDTDropDownOptionsTitleSettingsIcons1 = AV51DDO_TitleSettingsIcons;
         new GeneXus.Programs.wwpbaseobjects.getwwptitlesettingsicons(context ).execute( out  GXt_SdtDVB_SDTDropDownOptionsTitleSettingsIcons1) ;
         AV51DDO_TitleSettingsIcons = GXt_SdtDVB_SDTDropDownOptionsTitleSettingsIcons1;
         Gridpaginationbar_Rowsperpageselectedvalue = subGrid_Rows;
         ucGridpaginationbar.SendProperty(context, "", false, Gridpaginationbar_Internalname, "RowsPerPageSelectedValue", StringUtil.LTrimStr( (decimal)(Gridpaginationbar_Rowsperpageselectedvalue), 9, 0));
      }

      protected void E251O2( )
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
         if ( StringUtil.StrCmp(AV15DynamicFiltersSelector1, "TIPDSC") == 0 )
         {
            cmbavDynamicfiltersoperator1.addItem("0", "Comienza con", 0);
            cmbavDynamicfiltersoperator1.addItem("1", "Contiene", 0);
         }
         else if ( StringUtil.StrCmp(AV15DynamicFiltersSelector1, "TIPABR") == 0 )
         {
            cmbavDynamicfiltersoperator1.addItem("0", "Comienza con", 0);
            cmbavDynamicfiltersoperator1.addItem("1", "Contiene", 0);
         }
         if ( AV18DynamicFiltersEnabled2 )
         {
            cmbavDynamicfiltersoperator2.removeAllItems();
            if ( StringUtil.StrCmp(AV19DynamicFiltersSelector2, "TIPDSC") == 0 )
            {
               cmbavDynamicfiltersoperator2.addItem("0", "Comienza con", 0);
               cmbavDynamicfiltersoperator2.addItem("1", "Contiene", 0);
            }
            else if ( StringUtil.StrCmp(AV19DynamicFiltersSelector2, "TIPABR") == 0 )
            {
               cmbavDynamicfiltersoperator2.addItem("0", "Comienza con", 0);
               cmbavDynamicfiltersoperator2.addItem("1", "Contiene", 0);
            }
            if ( AV22DynamicFiltersEnabled3 )
            {
               cmbavDynamicfiltersoperator3.removeAllItems();
               if ( StringUtil.StrCmp(AV23DynamicFiltersSelector3, "TIPDSC") == 0 )
               {
                  cmbavDynamicfiltersoperator3.addItem("0", "Comienza con", 0);
                  cmbavDynamicfiltersoperator3.addItem("1", "Contiene", 0);
               }
               else if ( StringUtil.StrCmp(AV23DynamicFiltersSelector3, "TIPABR") == 0 )
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
         AV53GridCurrentPage = subGrid_fnc_Currentpage( );
         AssignAttri("", false, "AV53GridCurrentPage", StringUtil.LTrimStr( (decimal)(AV53GridCurrentPage), 10, 0));
         AV54GridPageCount = subGrid_fnc_Pagecount( );
         AssignAttri("", false, "AV54GridPageCount", StringUtil.LTrimStr( (decimal)(AV54GridPageCount), 10, 0));
         GXt_char2 = AV55GridAppliedFilters;
         new GeneXus.Programs.wwpbaseobjects.wwp_getappliedfiltersdescription(context ).execute(  AV71Pgmname, out  GXt_char2) ;
         AV55GridAppliedFilters = GXt_char2;
         AssignAttri("", false, "AV55GridAppliedFilters", AV55GridAppliedFilters);
         AV72Configuracion_tipodocumentowwds_1_dynamicfiltersselector1 = AV15DynamicFiltersSelector1;
         AV73Configuracion_tipodocumentowwds_2_dynamicfiltersoperator1 = AV16DynamicFiltersOperator1;
         AV74Configuracion_tipodocumentowwds_3_tipdsc1 = AV17TipDsc1;
         AV75Configuracion_tipodocumentowwds_4_tipabr1 = AV66TipAbr1;
         AV76Configuracion_tipodocumentowwds_5_dynamicfiltersenabled2 = AV18DynamicFiltersEnabled2;
         AV77Configuracion_tipodocumentowwds_6_dynamicfiltersselector2 = AV19DynamicFiltersSelector2;
         AV78Configuracion_tipodocumentowwds_7_dynamicfiltersoperator2 = AV20DynamicFiltersOperator2;
         AV79Configuracion_tipodocumentowwds_8_tipdsc2 = AV21TipDsc2;
         AV80Configuracion_tipodocumentowwds_9_tipabr2 = AV67TipAbr2;
         AV81Configuracion_tipodocumentowwds_10_dynamicfiltersenabled3 = AV22DynamicFiltersEnabled3;
         AV82Configuracion_tipodocumentowwds_11_dynamicfiltersselector3 = AV23DynamicFiltersSelector3;
         AV83Configuracion_tipodocumentowwds_12_dynamicfiltersoperator3 = AV24DynamicFiltersOperator3;
         AV84Configuracion_tipodocumentowwds_13_tipdsc3 = AV25TipDsc3;
         AV85Configuracion_tipodocumentowwds_14_tipabr3 = AV68TipAbr3;
         AV86Configuracion_tipodocumentowwds_15_tftipabr = AV35TFTipAbr;
         AV87Configuracion_tipodocumentowwds_16_tftipabr_sel = AV36TFTipAbr_Sel;
         AV88Configuracion_tipodocumentowwds_17_tftipdsc = AV33TFTipDsc;
         AV89Configuracion_tipodocumentowwds_18_tftipdsc_sel = AV34TFTipDsc_Sel;
         AV90Configuracion_tipodocumentowwds_19_tftipvta_sel = AV59TFTipVta_Sel;
         AV91Configuracion_tipodocumentowwds_20_tftipcmp_sel = AV60TFTipCmp_Sel;
         AV92Configuracion_tipodocumentowwds_21_tftiprho_sel = AV61TFTipRHo_Sel;
         AV93Configuracion_tipodocumentowwds_22_tftipcxp_sel = AV62TFTipCxP_Sel;
         AV94Configuracion_tipodocumentowwds_23_tftipban_sel = AV63TFTipBan_Sel;
         AV95Configuracion_tipodocumentowwds_24_tftipsts_sels = AV65TFTipSts_Sels;
         /*  Sending Event outputs  */
         cmbavDynamicfiltersoperator1.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV16DynamicFiltersOperator1), 4, 0));
         AssignProp("", false, cmbavDynamicfiltersoperator1_Internalname, "Values", cmbavDynamicfiltersoperator1.ToJavascriptSource(), true);
         cmbavDynamicfiltersoperator2.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV20DynamicFiltersOperator2), 4, 0));
         AssignProp("", false, cmbavDynamicfiltersoperator2_Internalname, "Values", cmbavDynamicfiltersoperator2.ToJavascriptSource(), true);
         cmbavDynamicfiltersoperator3.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV24DynamicFiltersOperator3), 4, 0));
         AssignProp("", false, cmbavDynamicfiltersoperator3_Internalname, "Values", cmbavDynamicfiltersoperator3.ToJavascriptSource(), true);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV10GridState", AV10GridState);
      }

      protected void E111O2( )
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
            AV52PageToGo = (int)(NumberUtil.Val( Gridpaginationbar_Selectedpage, "."));
            subgrid_gotopage( AV52PageToGo) ;
         }
      }

      protected void E121O2( )
      {
         /* Gridpaginationbar_Changerowsperpage Routine */
         returnInSub = false;
         subGrid_Rows = Gridpaginationbar_Rowsperpageselectedvalue;
         GxWebStd.gx_hidden_field( context, "GRID_Rows", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid_Rows), 6, 0, ".", "")));
         subgrid_firstpage( ) ;
         /*  Sending Event outputs  */
      }

      protected void E141O2( )
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
            if ( StringUtil.StrCmp(Ddo_grid_Selectedcolumn, "TipAbr") == 0 )
            {
               AV35TFTipAbr = Ddo_grid_Filteredtext_get;
               AssignAttri("", false, "AV35TFTipAbr", AV35TFTipAbr);
               AV36TFTipAbr_Sel = Ddo_grid_Selectedvalue_get;
               AssignAttri("", false, "AV36TFTipAbr_Sel", AV36TFTipAbr_Sel);
            }
            else if ( StringUtil.StrCmp(Ddo_grid_Selectedcolumn, "TipDsc") == 0 )
            {
               AV33TFTipDsc = Ddo_grid_Filteredtext_get;
               AssignAttri("", false, "AV33TFTipDsc", AV33TFTipDsc);
               AV34TFTipDsc_Sel = Ddo_grid_Selectedvalue_get;
               AssignAttri("", false, "AV34TFTipDsc_Sel", AV34TFTipDsc_Sel);
            }
            else if ( StringUtil.StrCmp(Ddo_grid_Selectedcolumn, "TipVta") == 0 )
            {
               AV59TFTipVta_Sel = (short)(NumberUtil.Val( Ddo_grid_Selectedvalue_get, "."));
               AssignAttri("", false, "AV59TFTipVta_Sel", StringUtil.Str( (decimal)(AV59TFTipVta_Sel), 1, 0));
            }
            else if ( StringUtil.StrCmp(Ddo_grid_Selectedcolumn, "TipCmp") == 0 )
            {
               AV60TFTipCmp_Sel = (short)(NumberUtil.Val( Ddo_grid_Selectedvalue_get, "."));
               AssignAttri("", false, "AV60TFTipCmp_Sel", StringUtil.Str( (decimal)(AV60TFTipCmp_Sel), 1, 0));
            }
            else if ( StringUtil.StrCmp(Ddo_grid_Selectedcolumn, "TipRHo") == 0 )
            {
               AV61TFTipRHo_Sel = (short)(NumberUtil.Val( Ddo_grid_Selectedvalue_get, "."));
               AssignAttri("", false, "AV61TFTipRHo_Sel", StringUtil.Str( (decimal)(AV61TFTipRHo_Sel), 1, 0));
            }
            else if ( StringUtil.StrCmp(Ddo_grid_Selectedcolumn, "TipCxP") == 0 )
            {
               AV62TFTipCxP_Sel = (short)(NumberUtil.Val( Ddo_grid_Selectedvalue_get, "."));
               AssignAttri("", false, "AV62TFTipCxP_Sel", StringUtil.Str( (decimal)(AV62TFTipCxP_Sel), 1, 0));
            }
            else if ( StringUtil.StrCmp(Ddo_grid_Selectedcolumn, "TipBan") == 0 )
            {
               AV63TFTipBan_Sel = (short)(NumberUtil.Val( Ddo_grid_Selectedvalue_get, "."));
               AssignAttri("", false, "AV63TFTipBan_Sel", StringUtil.Str( (decimal)(AV63TFTipBan_Sel), 1, 0));
            }
            else if ( StringUtil.StrCmp(Ddo_grid_Selectedcolumn, "TipSts") == 0 )
            {
               AV64TFTipSts_SelsJson = Ddo_grid_Selectedvalue_get;
               AssignAttri("", false, "AV64TFTipSts_SelsJson", AV64TFTipSts_SelsJson);
               AV65TFTipSts_Sels.FromJSonString(StringUtil.StringReplace( AV64TFTipSts_SelsJson, "\"", ""), null);
            }
            subgrid_firstpage( ) ;
         }
         /*  Sending Event outputs  */
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV65TFTipSts_Sels", AV65TFTipSts_Sels);
      }

      private void E261O2( )
      {
         /* Grid_Load Routine */
         returnInSub = false;
         cmbavGridactions.removeAllItems();
         cmbavGridactions.addItem("0", ";fa fa-bars", 0);
         cmbavGridactions.addItem("1", StringUtil.Format( "%1;%2", "Modificar", "fa fa-pen", "", "", "", "", "", "", ""), 0);
         cmbavGridactions.addItem("2", StringUtil.Format( "%1;%2", "Eliminar", "fa fa-times", "", "", "", "", "", "", ""), 0);
         GXKey = Crypto.GetSiteKey( );
         GXEncryptionTmp = "configuracion.tipodocumento.aspx"+UrlEncode(StringUtil.RTrim("DSP")) + "," + UrlEncode(StringUtil.RTrim(A149TipCod));
         edtTipDsc_Link = formatLink("configuracion.tipodocumento.aspx") + "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey);
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
         cmbavGridactions.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV56GridActions), 4, 0));
      }

      protected void E191O2( )
      {
         /* 'AddDynamicFilters1' Routine */
         returnInSub = false;
         AV18DynamicFiltersEnabled2 = true;
         AssignAttri("", false, "AV18DynamicFiltersEnabled2", AV18DynamicFiltersEnabled2);
         imgAdddynamicfilters1_Visible = 0;
         AssignProp("", false, imgAdddynamicfilters1_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(imgAdddynamicfilters1_Visible), 5, 0), true);
         imgRemovedynamicfilters1_Visible = 1;
         AssignProp("", false, imgRemovedynamicfilters1_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(imgRemovedynamicfilters1_Visible), 5, 0), true);
         gxgrGrid_refresh( subGrid_Rows, AV15DynamicFiltersSelector1, AV16DynamicFiltersOperator1, AV17TipDsc1, AV66TipAbr1, AV19DynamicFiltersSelector2, AV20DynamicFiltersOperator2, AV21TipDsc2, AV67TipAbr2, AV23DynamicFiltersSelector3, AV24DynamicFiltersOperator3, AV25TipDsc3, AV68TipAbr3, AV18DynamicFiltersEnabled2, AV22DynamicFiltersEnabled3, AV71Pgmname, AV35TFTipAbr, AV36TFTipAbr_Sel, AV33TFTipDsc, AV34TFTipDsc_Sel, AV59TFTipVta_Sel, AV60TFTipCmp_Sel, AV61TFTipRHo_Sel, AV62TFTipCxP_Sel, AV63TFTipBan_Sel, AV65TFTipSts_Sels, AV13OrderedBy, AV14OrderedDsc, AV10GridState, AV27DynamicFiltersIgnoreFirst, AV26DynamicFiltersRemoving) ;
         /*  Sending Event outputs  */
         cmbavDynamicfiltersoperator1.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV16DynamicFiltersOperator1), 4, 0));
         AssignProp("", false, cmbavDynamicfiltersoperator1_Internalname, "Values", cmbavDynamicfiltersoperator1.ToJavascriptSource(), true);
         cmbavDynamicfiltersoperator2.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV20DynamicFiltersOperator2), 4, 0));
         AssignProp("", false, cmbavDynamicfiltersoperator2_Internalname, "Values", cmbavDynamicfiltersoperator2.ToJavascriptSource(), true);
         cmbavDynamicfiltersoperator3.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV24DynamicFiltersOperator3), 4, 0));
         AssignProp("", false, cmbavDynamicfiltersoperator3_Internalname, "Values", cmbavDynamicfiltersoperator3.ToJavascriptSource(), true);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV10GridState", AV10GridState);
      }

      protected void E151O2( )
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
         gxgrGrid_refresh( subGrid_Rows, AV15DynamicFiltersSelector1, AV16DynamicFiltersOperator1, AV17TipDsc1, AV66TipAbr1, AV19DynamicFiltersSelector2, AV20DynamicFiltersOperator2, AV21TipDsc2, AV67TipAbr2, AV23DynamicFiltersSelector3, AV24DynamicFiltersOperator3, AV25TipDsc3, AV68TipAbr3, AV18DynamicFiltersEnabled2, AV22DynamicFiltersEnabled3, AV71Pgmname, AV35TFTipAbr, AV36TFTipAbr_Sel, AV33TFTipDsc, AV34TFTipDsc_Sel, AV59TFTipVta_Sel, AV60TFTipCmp_Sel, AV61TFTipRHo_Sel, AV62TFTipCxP_Sel, AV63TFTipBan_Sel, AV65TFTipSts_Sels, AV13OrderedBy, AV14OrderedDsc, AV10GridState, AV27DynamicFiltersIgnoreFirst, AV26DynamicFiltersRemoving) ;
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

      protected void E201O2( )
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

      protected void E211O2( )
      {
         /* 'AddDynamicFilters2' Routine */
         returnInSub = false;
         AV22DynamicFiltersEnabled3 = true;
         AssignAttri("", false, "AV22DynamicFiltersEnabled3", AV22DynamicFiltersEnabled3);
         imgAdddynamicfilters2_Visible = 0;
         AssignProp("", false, imgAdddynamicfilters2_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(imgAdddynamicfilters2_Visible), 5, 0), true);
         imgRemovedynamicfilters2_Visible = 1;
         AssignProp("", false, imgRemovedynamicfilters2_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(imgRemovedynamicfilters2_Visible), 5, 0), true);
         gxgrGrid_refresh( subGrid_Rows, AV15DynamicFiltersSelector1, AV16DynamicFiltersOperator1, AV17TipDsc1, AV66TipAbr1, AV19DynamicFiltersSelector2, AV20DynamicFiltersOperator2, AV21TipDsc2, AV67TipAbr2, AV23DynamicFiltersSelector3, AV24DynamicFiltersOperator3, AV25TipDsc3, AV68TipAbr3, AV18DynamicFiltersEnabled2, AV22DynamicFiltersEnabled3, AV71Pgmname, AV35TFTipAbr, AV36TFTipAbr_Sel, AV33TFTipDsc, AV34TFTipDsc_Sel, AV59TFTipVta_Sel, AV60TFTipCmp_Sel, AV61TFTipRHo_Sel, AV62TFTipCxP_Sel, AV63TFTipBan_Sel, AV65TFTipSts_Sels, AV13OrderedBy, AV14OrderedDsc, AV10GridState, AV27DynamicFiltersIgnoreFirst, AV26DynamicFiltersRemoving) ;
         /*  Sending Event outputs  */
         cmbavDynamicfiltersoperator1.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV16DynamicFiltersOperator1), 4, 0));
         AssignProp("", false, cmbavDynamicfiltersoperator1_Internalname, "Values", cmbavDynamicfiltersoperator1.ToJavascriptSource(), true);
         cmbavDynamicfiltersoperator2.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV20DynamicFiltersOperator2), 4, 0));
         AssignProp("", false, cmbavDynamicfiltersoperator2_Internalname, "Values", cmbavDynamicfiltersoperator2.ToJavascriptSource(), true);
         cmbavDynamicfiltersoperator3.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV24DynamicFiltersOperator3), 4, 0));
         AssignProp("", false, cmbavDynamicfiltersoperator3_Internalname, "Values", cmbavDynamicfiltersoperator3.ToJavascriptSource(), true);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV10GridState", AV10GridState);
      }

      protected void E161O2( )
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
         gxgrGrid_refresh( subGrid_Rows, AV15DynamicFiltersSelector1, AV16DynamicFiltersOperator1, AV17TipDsc1, AV66TipAbr1, AV19DynamicFiltersSelector2, AV20DynamicFiltersOperator2, AV21TipDsc2, AV67TipAbr2, AV23DynamicFiltersSelector3, AV24DynamicFiltersOperator3, AV25TipDsc3, AV68TipAbr3, AV18DynamicFiltersEnabled2, AV22DynamicFiltersEnabled3, AV71Pgmname, AV35TFTipAbr, AV36TFTipAbr_Sel, AV33TFTipDsc, AV34TFTipDsc_Sel, AV59TFTipVta_Sel, AV60TFTipCmp_Sel, AV61TFTipRHo_Sel, AV62TFTipCxP_Sel, AV63TFTipBan_Sel, AV65TFTipSts_Sels, AV13OrderedBy, AV14OrderedDsc, AV10GridState, AV27DynamicFiltersIgnoreFirst, AV26DynamicFiltersRemoving) ;
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

      protected void E221O2( )
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

      protected void E171O2( )
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
         gxgrGrid_refresh( subGrid_Rows, AV15DynamicFiltersSelector1, AV16DynamicFiltersOperator1, AV17TipDsc1, AV66TipAbr1, AV19DynamicFiltersSelector2, AV20DynamicFiltersOperator2, AV21TipDsc2, AV67TipAbr2, AV23DynamicFiltersSelector3, AV24DynamicFiltersOperator3, AV25TipDsc3, AV68TipAbr3, AV18DynamicFiltersEnabled2, AV22DynamicFiltersEnabled3, AV71Pgmname, AV35TFTipAbr, AV36TFTipAbr_Sel, AV33TFTipDsc, AV34TFTipDsc_Sel, AV59TFTipVta_Sel, AV60TFTipCmp_Sel, AV61TFTipRHo_Sel, AV62TFTipCxP_Sel, AV63TFTipBan_Sel, AV65TFTipSts_Sels, AV13OrderedBy, AV14OrderedDsc, AV10GridState, AV27DynamicFiltersIgnoreFirst, AV26DynamicFiltersRemoving) ;
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

      protected void E231O2( )
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

      protected void E271O2( )
      {
         /* Gridactions_Click Routine */
         returnInSub = false;
         if ( AV56GridActions == 1 )
         {
            /* Execute user subroutine: 'DO UPDATE' */
            S212 ();
            if ( returnInSub )
            {
               returnInSub = true;
               if (true) return;
            }
         }
         else if ( AV56GridActions == 2 )
         {
            /* Execute user subroutine: 'DO DELETE' */
            S222 ();
            if ( returnInSub )
            {
               returnInSub = true;
               if (true) return;
            }
         }
         AV56GridActions = 0;
         AssignAttri("", false, cmbavGridactions_Internalname, StringUtil.LTrimStr( (decimal)(AV56GridActions), 4, 0));
         /*  Sending Event outputs  */
         cmbavGridactions.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV56GridActions), 4, 0));
         AssignProp("", false, cmbavGridactions_Internalname, "Values", cmbavGridactions.ToJavascriptSource(), true);
      }

      protected void E181O2( )
      {
         /* 'DoInsert' Routine */
         returnInSub = false;
         GXKey = Crypto.GetSiteKey( );
         GXEncryptionTmp = "configuracion.tipodocumento.aspx"+UrlEncode(StringUtil.RTrim("INS")) + "," + UrlEncode(StringUtil.RTrim(""));
         CallWebObject(formatLink("configuracion.tipodocumento.aspx") + "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey));
         context.wjLocDisableFrm = 1;
      }

      protected void E131O2( )
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
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV65TFTipSts_Sels", AV65TFTipSts_Sels);
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
         edtavTipdsc1_Visible = 0;
         AssignProp("", false, edtavTipdsc1_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavTipdsc1_Visible), 5, 0), true);
         edtavTipabr1_Visible = 0;
         AssignProp("", false, edtavTipabr1_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavTipabr1_Visible), 5, 0), true);
         cmbavDynamicfiltersoperator1.Visible = 0;
         AssignProp("", false, cmbavDynamicfiltersoperator1_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(cmbavDynamicfiltersoperator1.Visible), 5, 0), true);
         if ( StringUtil.StrCmp(AV15DynamicFiltersSelector1, "TIPDSC") == 0 )
         {
            edtavTipdsc1_Visible = 1;
            AssignProp("", false, edtavTipdsc1_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavTipdsc1_Visible), 5, 0), true);
            cmbavDynamicfiltersoperator1.Visible = 1;
            AssignProp("", false, cmbavDynamicfiltersoperator1_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(cmbavDynamicfiltersoperator1.Visible), 5, 0), true);
         }
         else if ( StringUtil.StrCmp(AV15DynamicFiltersSelector1, "TIPABR") == 0 )
         {
            edtavTipabr1_Visible = 1;
            AssignProp("", false, edtavTipabr1_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavTipabr1_Visible), 5, 0), true);
            cmbavDynamicfiltersoperator1.Visible = 1;
            AssignProp("", false, cmbavDynamicfiltersoperator1_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(cmbavDynamicfiltersoperator1.Visible), 5, 0), true);
         }
      }

      protected void S122( )
      {
         /* 'ENABLEDYNAMICFILTERS2' Routine */
         returnInSub = false;
         edtavTipdsc2_Visible = 0;
         AssignProp("", false, edtavTipdsc2_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavTipdsc2_Visible), 5, 0), true);
         edtavTipabr2_Visible = 0;
         AssignProp("", false, edtavTipabr2_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavTipabr2_Visible), 5, 0), true);
         cmbavDynamicfiltersoperator2.Visible = 0;
         AssignProp("", false, cmbavDynamicfiltersoperator2_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(cmbavDynamicfiltersoperator2.Visible), 5, 0), true);
         if ( StringUtil.StrCmp(AV19DynamicFiltersSelector2, "TIPDSC") == 0 )
         {
            edtavTipdsc2_Visible = 1;
            AssignProp("", false, edtavTipdsc2_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavTipdsc2_Visible), 5, 0), true);
            cmbavDynamicfiltersoperator2.Visible = 1;
            AssignProp("", false, cmbavDynamicfiltersoperator2_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(cmbavDynamicfiltersoperator2.Visible), 5, 0), true);
         }
         else if ( StringUtil.StrCmp(AV19DynamicFiltersSelector2, "TIPABR") == 0 )
         {
            edtavTipabr2_Visible = 1;
            AssignProp("", false, edtavTipabr2_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavTipabr2_Visible), 5, 0), true);
            cmbavDynamicfiltersoperator2.Visible = 1;
            AssignProp("", false, cmbavDynamicfiltersoperator2_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(cmbavDynamicfiltersoperator2.Visible), 5, 0), true);
         }
      }

      protected void S132( )
      {
         /* 'ENABLEDYNAMICFILTERS3' Routine */
         returnInSub = false;
         edtavTipdsc3_Visible = 0;
         AssignProp("", false, edtavTipdsc3_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavTipdsc3_Visible), 5, 0), true);
         edtavTipabr3_Visible = 0;
         AssignProp("", false, edtavTipabr3_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavTipabr3_Visible), 5, 0), true);
         cmbavDynamicfiltersoperator3.Visible = 0;
         AssignProp("", false, cmbavDynamicfiltersoperator3_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(cmbavDynamicfiltersoperator3.Visible), 5, 0), true);
         if ( StringUtil.StrCmp(AV23DynamicFiltersSelector3, "TIPDSC") == 0 )
         {
            edtavTipdsc3_Visible = 1;
            AssignProp("", false, edtavTipdsc3_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavTipdsc3_Visible), 5, 0), true);
            cmbavDynamicfiltersoperator3.Visible = 1;
            AssignProp("", false, cmbavDynamicfiltersoperator3_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(cmbavDynamicfiltersoperator3.Visible), 5, 0), true);
         }
         else if ( StringUtil.StrCmp(AV23DynamicFiltersSelector3, "TIPABR") == 0 )
         {
            edtavTipabr3_Visible = 1;
            AssignProp("", false, edtavTipabr3_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavTipabr3_Visible), 5, 0), true);
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
         AV19DynamicFiltersSelector2 = "TIPDSC";
         AssignAttri("", false, "AV19DynamicFiltersSelector2", AV19DynamicFiltersSelector2);
         AV20DynamicFiltersOperator2 = 0;
         AssignAttri("", false, "AV20DynamicFiltersOperator2", StringUtil.LTrimStr( (decimal)(AV20DynamicFiltersOperator2), 4, 0));
         AV21TipDsc2 = "";
         AssignAttri("", false, "AV21TipDsc2", AV21TipDsc2);
         /* Execute user subroutine: 'ENABLEDYNAMICFILTERS2' */
         S122 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
         AV22DynamicFiltersEnabled3 = false;
         AssignAttri("", false, "AV22DynamicFiltersEnabled3", AV22DynamicFiltersEnabled3);
         AV23DynamicFiltersSelector3 = "TIPDSC";
         AssignAttri("", false, "AV23DynamicFiltersSelector3", AV23DynamicFiltersSelector3);
         AV24DynamicFiltersOperator3 = 0;
         AssignAttri("", false, "AV24DynamicFiltersOperator3", StringUtil.LTrimStr( (decimal)(AV24DynamicFiltersOperator3), 4, 0));
         AV25TipDsc3 = "";
         AssignAttri("", false, "AV25TipDsc3", AV25TipDsc3);
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
         GXEncryptionTmp = "configuracion.tipodocumento.aspx"+UrlEncode(StringUtil.RTrim("UPD")) + "," + UrlEncode(StringUtil.RTrim(A149TipCod));
         CallWebObject(formatLink("configuracion.tipodocumento.aspx") + "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey));
         context.wjLocDisableFrm = 1;
      }

      protected void S222( )
      {
         /* 'DO DELETE' Routine */
         returnInSub = false;
         GXKey = Crypto.GetSiteKey( );
         GXEncryptionTmp = "configuracion.tipodocumento.aspx"+UrlEncode(StringUtil.RTrim("DLT")) + "," + UrlEncode(StringUtil.RTrim(A149TipCod));
         CallWebObject(formatLink("configuracion.tipodocumento.aspx") + "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey));
         context.wjLocDisableFrm = 1;
      }

      protected void S152( )
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
         S162 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
         AV96GXV1 = 1;
         while ( AV96GXV1 <= AV10GridState.gxTpr_Filtervalues.Count )
         {
            AV11GridStateFilterValue = ((GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue)AV10GridState.gxTpr_Filtervalues.Item(AV96GXV1));
            if ( StringUtil.StrCmp(AV11GridStateFilterValue.gxTpr_Name, "TFTIPABR") == 0 )
            {
               AV35TFTipAbr = AV11GridStateFilterValue.gxTpr_Value;
               AssignAttri("", false, "AV35TFTipAbr", AV35TFTipAbr);
            }
            else if ( StringUtil.StrCmp(AV11GridStateFilterValue.gxTpr_Name, "TFTIPABR_SEL") == 0 )
            {
               AV36TFTipAbr_Sel = AV11GridStateFilterValue.gxTpr_Value;
               AssignAttri("", false, "AV36TFTipAbr_Sel", AV36TFTipAbr_Sel);
            }
            else if ( StringUtil.StrCmp(AV11GridStateFilterValue.gxTpr_Name, "TFTIPDSC") == 0 )
            {
               AV33TFTipDsc = AV11GridStateFilterValue.gxTpr_Value;
               AssignAttri("", false, "AV33TFTipDsc", AV33TFTipDsc);
            }
            else if ( StringUtil.StrCmp(AV11GridStateFilterValue.gxTpr_Name, "TFTIPDSC_SEL") == 0 )
            {
               AV34TFTipDsc_Sel = AV11GridStateFilterValue.gxTpr_Value;
               AssignAttri("", false, "AV34TFTipDsc_Sel", AV34TFTipDsc_Sel);
            }
            else if ( StringUtil.StrCmp(AV11GridStateFilterValue.gxTpr_Name, "TFTIPVTA_SEL") == 0 )
            {
               AV59TFTipVta_Sel = (short)(NumberUtil.Val( AV11GridStateFilterValue.gxTpr_Value, "."));
               AssignAttri("", false, "AV59TFTipVta_Sel", StringUtil.Str( (decimal)(AV59TFTipVta_Sel), 1, 0));
            }
            else if ( StringUtil.StrCmp(AV11GridStateFilterValue.gxTpr_Name, "TFTIPCMP_SEL") == 0 )
            {
               AV60TFTipCmp_Sel = (short)(NumberUtil.Val( AV11GridStateFilterValue.gxTpr_Value, "."));
               AssignAttri("", false, "AV60TFTipCmp_Sel", StringUtil.Str( (decimal)(AV60TFTipCmp_Sel), 1, 0));
            }
            else if ( StringUtil.StrCmp(AV11GridStateFilterValue.gxTpr_Name, "TFTIPRHO_SEL") == 0 )
            {
               AV61TFTipRHo_Sel = (short)(NumberUtil.Val( AV11GridStateFilterValue.gxTpr_Value, "."));
               AssignAttri("", false, "AV61TFTipRHo_Sel", StringUtil.Str( (decimal)(AV61TFTipRHo_Sel), 1, 0));
            }
            else if ( StringUtil.StrCmp(AV11GridStateFilterValue.gxTpr_Name, "TFTIPCXP_SEL") == 0 )
            {
               AV62TFTipCxP_Sel = (short)(NumberUtil.Val( AV11GridStateFilterValue.gxTpr_Value, "."));
               AssignAttri("", false, "AV62TFTipCxP_Sel", StringUtil.Str( (decimal)(AV62TFTipCxP_Sel), 1, 0));
            }
            else if ( StringUtil.StrCmp(AV11GridStateFilterValue.gxTpr_Name, "TFTIPBAN_SEL") == 0 )
            {
               AV63TFTipBan_Sel = (short)(NumberUtil.Val( AV11GridStateFilterValue.gxTpr_Value, "."));
               AssignAttri("", false, "AV63TFTipBan_Sel", StringUtil.Str( (decimal)(AV63TFTipBan_Sel), 1, 0));
            }
            else if ( StringUtil.StrCmp(AV11GridStateFilterValue.gxTpr_Name, "TFTIPSTS_SEL") == 0 )
            {
               AV64TFTipSts_SelsJson = AV11GridStateFilterValue.gxTpr_Value;
               AssignAttri("", false, "AV64TFTipSts_SelsJson", AV64TFTipSts_SelsJson);
               AV65TFTipSts_Sels.FromJSonString(AV64TFTipSts_SelsJson, null);
            }
            AV96GXV1 = (int)(AV96GXV1+1);
         }
         GXt_char2 = "";
         new GeneXus.Programs.wwpbaseobjects.wwp_getfilterval(context ).execute(  String.IsNullOrEmpty(StringUtil.RTrim( AV36TFTipAbr_Sel)),  AV36TFTipAbr_Sel, out  GXt_char2) ;
         GXt_char3 = "";
         new GeneXus.Programs.wwpbaseobjects.wwp_getfilterval(context ).execute(  String.IsNullOrEmpty(StringUtil.RTrim( AV34TFTipDsc_Sel)),  AV34TFTipDsc_Sel, out  GXt_char3) ;
         Ddo_grid_Selectedvalue_set = GXt_char2+"|"+GXt_char3+"|"+((0==AV59TFTipVta_Sel) ? "" : StringUtil.Str( (decimal)(AV59TFTipVta_Sel), 1, 0))+"|"+((0==AV60TFTipCmp_Sel) ? "" : StringUtil.Str( (decimal)(AV60TFTipCmp_Sel), 1, 0))+"|"+((0==AV61TFTipRHo_Sel) ? "" : StringUtil.Str( (decimal)(AV61TFTipRHo_Sel), 1, 0))+"|"+((0==AV62TFTipCxP_Sel) ? "" : StringUtil.Str( (decimal)(AV62TFTipCxP_Sel), 1, 0))+"|"+((0==AV63TFTipBan_Sel) ? "" : StringUtil.Str( (decimal)(AV63TFTipBan_Sel), 1, 0))+"|"+((AV65TFTipSts_Sels.Count==0) ? "" : AV64TFTipSts_SelsJson);
         ucDdo_grid.SendProperty(context, "", false, Ddo_grid_Internalname, "SelectedValue_set", Ddo_grid_Selectedvalue_set);
         GXt_char3 = "";
         new GeneXus.Programs.wwpbaseobjects.wwp_getfilterval(context ).execute(  String.IsNullOrEmpty(StringUtil.RTrim( AV35TFTipAbr)),  AV35TFTipAbr, out  GXt_char3) ;
         GXt_char2 = "";
         new GeneXus.Programs.wwpbaseobjects.wwp_getfilterval(context ).execute(  String.IsNullOrEmpty(StringUtil.RTrim( AV33TFTipDsc)),  AV33TFTipDsc, out  GXt_char2) ;
         Ddo_grid_Filteredtext_set = GXt_char3+"|"+GXt_char2+"||||||";
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
            if ( StringUtil.StrCmp(AV15DynamicFiltersSelector1, "TIPDSC") == 0 )
            {
               AV16DynamicFiltersOperator1 = AV12GridStateDynamicFilter.gxTpr_Operator;
               AssignAttri("", false, "AV16DynamicFiltersOperator1", StringUtil.LTrimStr( (decimal)(AV16DynamicFiltersOperator1), 4, 0));
               AV17TipDsc1 = AV12GridStateDynamicFilter.gxTpr_Value;
               AssignAttri("", false, "AV17TipDsc1", AV17TipDsc1);
            }
            else if ( StringUtil.StrCmp(AV15DynamicFiltersSelector1, "TIPABR") == 0 )
            {
               AV16DynamicFiltersOperator1 = AV12GridStateDynamicFilter.gxTpr_Operator;
               AssignAttri("", false, "AV16DynamicFiltersOperator1", StringUtil.LTrimStr( (decimal)(AV16DynamicFiltersOperator1), 4, 0));
               AV66TipAbr1 = AV12GridStateDynamicFilter.gxTpr_Value;
               AssignAttri("", false, "AV66TipAbr1", AV66TipAbr1);
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
               if ( StringUtil.StrCmp(AV19DynamicFiltersSelector2, "TIPDSC") == 0 )
               {
                  AV20DynamicFiltersOperator2 = AV12GridStateDynamicFilter.gxTpr_Operator;
                  AssignAttri("", false, "AV20DynamicFiltersOperator2", StringUtil.LTrimStr( (decimal)(AV20DynamicFiltersOperator2), 4, 0));
                  AV21TipDsc2 = AV12GridStateDynamicFilter.gxTpr_Value;
                  AssignAttri("", false, "AV21TipDsc2", AV21TipDsc2);
               }
               else if ( StringUtil.StrCmp(AV19DynamicFiltersSelector2, "TIPABR") == 0 )
               {
                  AV20DynamicFiltersOperator2 = AV12GridStateDynamicFilter.gxTpr_Operator;
                  AssignAttri("", false, "AV20DynamicFiltersOperator2", StringUtil.LTrimStr( (decimal)(AV20DynamicFiltersOperator2), 4, 0));
                  AV67TipAbr2 = AV12GridStateDynamicFilter.gxTpr_Value;
                  AssignAttri("", false, "AV67TipAbr2", AV67TipAbr2);
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
                  if ( StringUtil.StrCmp(AV23DynamicFiltersSelector3, "TIPDSC") == 0 )
                  {
                     AV24DynamicFiltersOperator3 = AV12GridStateDynamicFilter.gxTpr_Operator;
                     AssignAttri("", false, "AV24DynamicFiltersOperator3", StringUtil.LTrimStr( (decimal)(AV24DynamicFiltersOperator3), 4, 0));
                     AV25TipDsc3 = AV12GridStateDynamicFilter.gxTpr_Value;
                     AssignAttri("", false, "AV25TipDsc3", AV25TipDsc3);
                  }
                  else if ( StringUtil.StrCmp(AV23DynamicFiltersSelector3, "TIPABR") == 0 )
                  {
                     AV24DynamicFiltersOperator3 = AV12GridStateDynamicFilter.gxTpr_Operator;
                     AssignAttri("", false, "AV24DynamicFiltersOperator3", StringUtil.LTrimStr( (decimal)(AV24DynamicFiltersOperator3), 4, 0));
                     AV68TipAbr3 = AV12GridStateDynamicFilter.gxTpr_Value;
                     AssignAttri("", false, "AV68TipAbr3", AV68TipAbr3);
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
         AV10GridState.FromXml(AV30Session.Get(AV71Pgmname+"GridState"), null, "", "");
         AV10GridState.gxTpr_Orderedby = AV13OrderedBy;
         AV10GridState.gxTpr_Ordereddsc = AV14OrderedDsc;
         AV10GridState.gxTpr_Filtervalues.Clear();
         new GeneXus.Programs.wwpbaseobjects.wwp_gridstateaddfiltervalueandsel(context ).execute( ref  AV10GridState,  "TFTIPABR",  "Codigo Sunat",  !String.IsNullOrEmpty(StringUtil.RTrim( AV35TFTipAbr)),  0,  AV35TFTipAbr,  "",  !String.IsNullOrEmpty(StringUtil.RTrim( AV36TFTipAbr_Sel)),  AV36TFTipAbr_Sel,  "") ;
         new GeneXus.Programs.wwpbaseobjects.wwp_gridstateaddfiltervalueandsel(context ).execute( ref  AV10GridState,  "TFTIPDSC",  "Tipo de Documento",  !String.IsNullOrEmpty(StringUtil.RTrim( AV33TFTipDsc)),  0,  AV33TFTipDsc,  "",  !String.IsNullOrEmpty(StringUtil.RTrim( AV34TFTipDsc_Sel)),  AV34TFTipDsc_Sel,  "") ;
         new GeneXus.Programs.wwpbaseobjects.wwp_gridstateaddfiltervalue(context ).execute( ref  AV10GridState,  "TFTIPVTA_SEL",  "Afecta Registro Venta",  !(0==AV59TFTipVta_Sel),  0,  StringUtil.Trim( StringUtil.Str( (decimal)(AV59TFTipVta_Sel), 1, 0)),  "") ;
         new GeneXus.Programs.wwpbaseobjects.wwp_gridstateaddfiltervalue(context ).execute( ref  AV10GridState,  "TFTIPCMP_SEL",  "Afecta Registro Compra",  !(0==AV60TFTipCmp_Sel),  0,  StringUtil.Trim( StringUtil.Str( (decimal)(AV60TFTipCmp_Sel), 1, 0)),  "") ;
         new GeneXus.Programs.wwpbaseobjects.wwp_gridstateaddfiltervalue(context ).execute( ref  AV10GridState,  "TFTIPRHO_SEL",  "Afecta Honorarios",  !(0==AV61TFTipRHo_Sel),  0,  StringUtil.Trim( StringUtil.Str( (decimal)(AV61TFTipRHo_Sel), 1, 0)),  "") ;
         new GeneXus.Programs.wwpbaseobjects.wwp_gridstateaddfiltervalue(context ).execute( ref  AV10GridState,  "TFTIPCXP_SEL",  "Afecta Cuenta x Pagar",  !(0==AV62TFTipCxP_Sel),  0,  StringUtil.Trim( StringUtil.Str( (decimal)(AV62TFTipCxP_Sel), 1, 0)),  "") ;
         new GeneXus.Programs.wwpbaseobjects.wwp_gridstateaddfiltervalue(context ).execute( ref  AV10GridState,  "TFTIPBAN_SEL",  "Afecta Bancos",  !(0==AV63TFTipBan_Sel),  0,  StringUtil.Trim( StringUtil.Str( (decimal)(AV63TFTipBan_Sel), 1, 0)),  "") ;
         new GeneXus.Programs.wwpbaseobjects.wwp_gridstateaddfiltervalue(context ).execute( ref  AV10GridState,  "TFTIPSTS_SEL",  "Estado",  !(AV65TFTipSts_Sels.Count==0),  0,  AV65TFTipSts_Sels.ToJSonString(false),  "") ;
         /* Execute user subroutine: 'SAVEDYNFILTERSSTATE' */
         S182 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
         AV10GridState.gxTpr_Pagesize = StringUtil.Str( (decimal)(subGrid_Rows), 10, 0);
         AV10GridState.gxTpr_Currentpage = (short)(subGrid_fnc_Currentpage( ));
         new GeneXus.Programs.wwpbaseobjects.savegridstate(context ).execute(  AV71Pgmname+"GridState",  AV10GridState.ToXml(false, true, "", "")) ;
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
            if ( ( StringUtil.StrCmp(AV15DynamicFiltersSelector1, "TIPDSC") == 0 ) && ! String.IsNullOrEmpty(StringUtil.RTrim( AV17TipDsc1)) )
            {
               AV12GridStateDynamicFilter.gxTpr_Dsc = "Tipo de Documento";
               AV12GridStateDynamicFilter.gxTpr_Value = AV17TipDsc1;
               AV12GridStateDynamicFilter.gxTpr_Operator = AV16DynamicFiltersOperator1;
            }
            else if ( ( StringUtil.StrCmp(AV15DynamicFiltersSelector1, "TIPABR") == 0 ) && ! String.IsNullOrEmpty(StringUtil.RTrim( AV66TipAbr1)) )
            {
               AV12GridStateDynamicFilter.gxTpr_Dsc = "Codigo Sunat";
               AV12GridStateDynamicFilter.gxTpr_Value = AV66TipAbr1;
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
            if ( ( StringUtil.StrCmp(AV19DynamicFiltersSelector2, "TIPDSC") == 0 ) && ! String.IsNullOrEmpty(StringUtil.RTrim( AV21TipDsc2)) )
            {
               AV12GridStateDynamicFilter.gxTpr_Dsc = "Tipo de Documento";
               AV12GridStateDynamicFilter.gxTpr_Value = AV21TipDsc2;
               AV12GridStateDynamicFilter.gxTpr_Operator = AV20DynamicFiltersOperator2;
            }
            else if ( ( StringUtil.StrCmp(AV19DynamicFiltersSelector2, "TIPABR") == 0 ) && ! String.IsNullOrEmpty(StringUtil.RTrim( AV67TipAbr2)) )
            {
               AV12GridStateDynamicFilter.gxTpr_Dsc = "Codigo Sunat";
               AV12GridStateDynamicFilter.gxTpr_Value = AV67TipAbr2;
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
            if ( ( StringUtil.StrCmp(AV23DynamicFiltersSelector3, "TIPDSC") == 0 ) && ! String.IsNullOrEmpty(StringUtil.RTrim( AV25TipDsc3)) )
            {
               AV12GridStateDynamicFilter.gxTpr_Dsc = "Tipo de Documento";
               AV12GridStateDynamicFilter.gxTpr_Value = AV25TipDsc3;
               AV12GridStateDynamicFilter.gxTpr_Operator = AV24DynamicFiltersOperator3;
            }
            else if ( ( StringUtil.StrCmp(AV23DynamicFiltersSelector3, "TIPABR") == 0 ) && ! String.IsNullOrEmpty(StringUtil.RTrim( AV68TipAbr3)) )
            {
               AV12GridStateDynamicFilter.gxTpr_Dsc = "Codigo Sunat";
               AV12GridStateDynamicFilter.gxTpr_Value = AV68TipAbr3;
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
         AV8TrnContext.gxTpr_Callerobject = AV71Pgmname;
         AV8TrnContext.gxTpr_Callerondelete = true;
         AV8TrnContext.gxTpr_Callerurl = AV7HTTPRequest.ScriptName+"?"+AV7HTTPRequest.QueryString;
         AV8TrnContext.gxTpr_Transactionname = "Configuracion.TipoDocumento";
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
         new GeneXus.Programs.configuracion.tipodocumentowwexport(context ).execute( out  AV28ExcelFilename, out  AV29ErrorMessage) ;
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
         Innewwindow1_Target = formatLink("configuracion.tipodocumentowwexportreport.aspx") ;
         ucInnewwindow1.SendProperty(context, "", false, Innewwindow1_Internalname, "Target", Innewwindow1_Target);
         Innewwindow1_Height = "600";
         ucInnewwindow1.SendProperty(context, "", false, Innewwindow1_Internalname, "Height", Innewwindow1_Height);
         Innewwindow1_Width = "800";
         ucInnewwindow1.SendProperty(context, "", false, Innewwindow1_Internalname, "Width", Innewwindow1_Width);
         this.executeUsercontrolMethod("", false, "INNEWWINDOW1Container", "OpenWindow", "", new Object[] {});
      }

      protected void wb_table1_25_1O2( bool wbgen )
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
            GxWebStd.gx_label_ctrl( context, lblDynamicfiltersprefix1_Internalname, "Buscar en", "", "", lblDynamicfiltersprefix1_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "DataFilterDescriptionPrefix", 0, "", 1, 1, 0, 0, "HLP_Configuracion\\TipoDocumentoWW.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "", "left", "top", "", "flex-grow:1;", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "left", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, cmbavDynamicfiltersselector1_Internalname, "Dynamic Filters Selector1", "gx-form-item AttributeLabel", 0, true, "width: 25%;");
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 35,'',false,'" + sGXsfl_110_idx + "',0)\"";
            /* ComboBox */
            GxWebStd.gx_combobox_ctrl1( context, cmbavDynamicfiltersselector1, cmbavDynamicfiltersselector1_Internalname, StringUtil.RTrim( AV15DynamicFiltersSelector1), 1, cmbavDynamicfiltersselector1_Jsonclick, 5, "'"+""+"'"+",false,"+"'"+"EVDYNAMICFILTERSSELECTOR1.CLICK."+"'", "svchar", "", 1, cmbavDynamicfiltersselector1.Enabled, 0, 0, 0, "em", 0, "", "", "Attribute", "", "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,35);\"", "", true, 1, "HLP_Configuracion\\TipoDocumentoWW.htm");
            cmbavDynamicfiltersselector1.CurrentValue = StringUtil.RTrim( AV15DynamicFiltersSelector1);
            AssignProp("", false, cmbavDynamicfiltersselector1_Internalname, "Values", (string)(cmbavDynamicfiltersselector1.ToJavascriptSource()), true);
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "", "left", "top", "", "flex-grow:1;", "div");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblDynamicfiltersmiddle1_Internalname, "valor", "", "", lblDynamicfiltersmiddle1_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "DataFilterDescription", 0, "", 1, 1, 0, 0, "HLP_Configuracion\\TipoDocumentoWW.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "", "left", "top", "", "flex-grow:1;", "div");
            wb_table2_39_1O2( true) ;
         }
         else
         {
            wb_table2_39_1O2( false) ;
         }
         return  ;
      }

      protected void wb_table2_39_1O2e( bool wbgen )
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
            GxWebStd.gx_label_ctrl( context, lblDynamicfiltersprefix2_Internalname, "Buscar en", "", "", lblDynamicfiltersprefix2_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "DataFilterDescriptionPrefix", 0, "", 1, 1, 0, 0, "HLP_Configuracion\\TipoDocumentoWW.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "Invisible", "left", "top", "", "flex-grow:1;", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "left", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, cmbavDynamicfiltersselector2_Internalname, "Dynamic Filters Selector2", "gx-form-item AttributeLabel", 0, true, "width: 25%;");
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 60,'',false,'" + sGXsfl_110_idx + "',0)\"";
            /* ComboBox */
            GxWebStd.gx_combobox_ctrl1( context, cmbavDynamicfiltersselector2, cmbavDynamicfiltersselector2_Internalname, StringUtil.RTrim( AV19DynamicFiltersSelector2), 1, cmbavDynamicfiltersselector2_Jsonclick, 5, "'"+""+"'"+",false,"+"'"+"EVDYNAMICFILTERSSELECTOR2.CLICK."+"'", "svchar", "", 1, cmbavDynamicfiltersselector2.Enabled, 0, 0, 0, "em", 0, "", "", "Attribute", "", "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,60);\"", "", true, 1, "HLP_Configuracion\\TipoDocumentoWW.htm");
            cmbavDynamicfiltersselector2.CurrentValue = StringUtil.RTrim( AV19DynamicFiltersSelector2);
            AssignProp("", false, cmbavDynamicfiltersselector2_Internalname, "Values", (string)(cmbavDynamicfiltersselector2.ToJavascriptSource()), true);
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "Invisible", "left", "top", "", "flex-grow:1;", "div");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblDynamicfiltersmiddle2_Internalname, "valor", "", "", lblDynamicfiltersmiddle2_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "DataFilterDescription", 0, "", 1, 1, 0, 0, "HLP_Configuracion\\TipoDocumentoWW.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "Invisible", "left", "top", "", "flex-grow:1;", "div");
            wb_table3_64_1O2( true) ;
         }
         else
         {
            wb_table3_64_1O2( false) ;
         }
         return  ;
      }

      protected void wb_table3_64_1O2e( bool wbgen )
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
            GxWebStd.gx_label_ctrl( context, lblDynamicfiltersprefix3_Internalname, "Buscar en", "", "", lblDynamicfiltersprefix3_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "DataFilterDescriptionPrefix", 0, "", 1, 1, 0, 0, "HLP_Configuracion\\TipoDocumentoWW.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "Invisible", "left", "top", "", "flex-grow:1;", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "left", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, cmbavDynamicfiltersselector3_Internalname, "Dynamic Filters Selector3", "gx-form-item AttributeLabel", 0, true, "width: 25%;");
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 85,'',false,'" + sGXsfl_110_idx + "',0)\"";
            /* ComboBox */
            GxWebStd.gx_combobox_ctrl1( context, cmbavDynamicfiltersselector3, cmbavDynamicfiltersselector3_Internalname, StringUtil.RTrim( AV23DynamicFiltersSelector3), 1, cmbavDynamicfiltersselector3_Jsonclick, 5, "'"+""+"'"+",false,"+"'"+"EVDYNAMICFILTERSSELECTOR3.CLICK."+"'", "svchar", "", 1, cmbavDynamicfiltersselector3.Enabled, 0, 0, 0, "em", 0, "", "", "Attribute", "", "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,85);\"", "", true, 1, "HLP_Configuracion\\TipoDocumentoWW.htm");
            cmbavDynamicfiltersselector3.CurrentValue = StringUtil.RTrim( AV23DynamicFiltersSelector3);
            AssignProp("", false, cmbavDynamicfiltersselector3_Internalname, "Values", (string)(cmbavDynamicfiltersselector3.ToJavascriptSource()), true);
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "Invisible", "left", "top", "", "flex-grow:1;", "div");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblDynamicfiltersmiddle3_Internalname, "valor", "", "", lblDynamicfiltersmiddle3_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "DataFilterDescription", 0, "", 1, 1, 0, 0, "HLP_Configuracion\\TipoDocumentoWW.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "Invisible", "left", "top", "", "flex-grow:1;", "div");
            wb_table4_89_1O2( true) ;
         }
         else
         {
            wb_table4_89_1O2( false) ;
         }
         return  ;
      }

      protected void wb_table4_89_1O2e( bool wbgen )
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
            wb_table1_25_1O2e( true) ;
         }
         else
         {
            wb_table1_25_1O2e( false) ;
         }
      }

      protected void wb_table4_89_1O2( bool wbgen )
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
            GxWebStd.gx_combobox_ctrl1( context, cmbavDynamicfiltersoperator3, cmbavDynamicfiltersoperator3_Internalname, StringUtil.Trim( StringUtil.Str( (decimal)(AV24DynamicFiltersOperator3), 4, 0)), 1, cmbavDynamicfiltersoperator3_Jsonclick, 0, "'"+""+"'"+",false,"+"'"+""+"'", "int", "", cmbavDynamicfiltersoperator3.Visible, cmbavDynamicfiltersoperator3.Enabled, 0, 0, 0, "em", 0, "", "", "Attribute", "", "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,93);\"", "", true, 1, "HLP_Configuracion\\TipoDocumentoWW.htm");
            cmbavDynamicfiltersoperator3.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV24DynamicFiltersOperator3), 4, 0));
            AssignProp("", false, cmbavDynamicfiltersoperator3_Internalname, "Values", (string)(cmbavDynamicfiltersoperator3.ToJavascriptSource()), true);
            GxWebStd.gx_div_end( context, "left", "top", "div");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "<td id=\""+cellFilter_tipdsc3_cell_Internalname+"\"  class=''>") ;
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "left", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavTipdsc3_Internalname, "Tip Dsc3", "gx-form-item AttributeLabel", 0, true, "width: 25%;");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 96,'',false,'" + sGXsfl_110_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavTipdsc3_Internalname, StringUtil.RTrim( AV25TipDsc3), StringUtil.RTrim( context.localUtil.Format( AV25TipDsc3, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,96);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavTipdsc3_Jsonclick, 0, "Attribute", "", "", "", "", edtavTipdsc3_Visible, edtavTipdsc3_Enabled, 0, "text", "", 80, "chr", 1, "row", 100, 0, 0, 0, 1, -1, -1, true, "", "left", true, "", "HLP_Configuracion\\TipoDocumentoWW.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "<td id=\""+cellFilter_tipabr3_cell_Internalname+"\"  class=''>") ;
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "left", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavTipabr3_Internalname, "Tip Abr3", "gx-form-item AttributeLabel", 0, true, "width: 25%;");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 99,'',false,'" + sGXsfl_110_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavTipabr3_Internalname, StringUtil.RTrim( AV68TipAbr3), StringUtil.RTrim( context.localUtil.Format( AV68TipAbr3, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,99);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavTipabr3_Jsonclick, 0, "Attribute", "", "", "", "", edtavTipabr3_Visible, edtavTipabr3_Enabled, 0, "text", "", 5, "chr", 1, "row", 5, 0, 0, 0, 1, -1, -1, true, "", "left", true, "", "HLP_Configuracion\\TipoDocumentoWW.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "<td id=\""+cellDynamicfilters_removefilter3_cell_Internalname+"\"  class=''>") ;
            /* Active images/pictures */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 101,'',false,'',0)\"";
            ClassString = "Image";
            StyleString = "";
            sImgUrl = (string)(context.GetImagePath( "11a6ef14-1a5a-4077-91a2-f41ed9a3a662", "", context.GetTheme( )));
            GxWebStd.gx_bitmap( context, imgRemovedynamicfilters3_Internalname, sImgUrl, "", "", "", context.GetTheme( ), 1, 1, "", "Quitar filtro", 0, 0, 0, "px", 0, "px", 0, 0, 5, imgRemovedynamicfilters3_Jsonclick, "'"+""+"'"+",false,"+"'"+"E\\'REMOVEDYNAMICFILTERS3\\'."+"'", StyleString, ClassString, "", "", "", "", " "+"data-gx-image"+" "+TempTags, "", "", 1, false, false, context.GetImageSrcSet( sImgUrl), "HLP_Configuracion\\TipoDocumentoWW.htm");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "</tr>") ;
            /* End of table */
            context.WriteHtmlText( "</table>") ;
            wb_table4_89_1O2e( true) ;
         }
         else
         {
            wb_table4_89_1O2e( false) ;
         }
      }

      protected void wb_table3_64_1O2( bool wbgen )
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
            GxWebStd.gx_combobox_ctrl1( context, cmbavDynamicfiltersoperator2, cmbavDynamicfiltersoperator2_Internalname, StringUtil.Trim( StringUtil.Str( (decimal)(AV20DynamicFiltersOperator2), 4, 0)), 1, cmbavDynamicfiltersoperator2_Jsonclick, 0, "'"+""+"'"+",false,"+"'"+""+"'", "int", "", cmbavDynamicfiltersoperator2.Visible, cmbavDynamicfiltersoperator2.Enabled, 0, 0, 0, "em", 0, "", "", "Attribute", "", "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,68);\"", "", true, 1, "HLP_Configuracion\\TipoDocumentoWW.htm");
            cmbavDynamicfiltersoperator2.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV20DynamicFiltersOperator2), 4, 0));
            AssignProp("", false, cmbavDynamicfiltersoperator2_Internalname, "Values", (string)(cmbavDynamicfiltersoperator2.ToJavascriptSource()), true);
            GxWebStd.gx_div_end( context, "left", "top", "div");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "<td id=\""+cellFilter_tipdsc2_cell_Internalname+"\"  class=''>") ;
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "left", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavTipdsc2_Internalname, "Tip Dsc2", "gx-form-item AttributeLabel", 0, true, "width: 25%;");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 71,'',false,'" + sGXsfl_110_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavTipdsc2_Internalname, StringUtil.RTrim( AV21TipDsc2), StringUtil.RTrim( context.localUtil.Format( AV21TipDsc2, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,71);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavTipdsc2_Jsonclick, 0, "Attribute", "", "", "", "", edtavTipdsc2_Visible, edtavTipdsc2_Enabled, 0, "text", "", 80, "chr", 1, "row", 100, 0, 0, 0, 1, -1, -1, true, "", "left", true, "", "HLP_Configuracion\\TipoDocumentoWW.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "<td id=\""+cellFilter_tipabr2_cell_Internalname+"\"  class=''>") ;
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "left", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavTipabr2_Internalname, "Tip Abr2", "gx-form-item AttributeLabel", 0, true, "width: 25%;");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 74,'',false,'" + sGXsfl_110_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavTipabr2_Internalname, StringUtil.RTrim( AV67TipAbr2), StringUtil.RTrim( context.localUtil.Format( AV67TipAbr2, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,74);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavTipabr2_Jsonclick, 0, "Attribute", "", "", "", "", edtavTipabr2_Visible, edtavTipabr2_Enabled, 0, "text", "", 5, "chr", 1, "row", 5, 0, 0, 0, 1, -1, -1, true, "", "left", true, "", "HLP_Configuracion\\TipoDocumentoWW.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "<td id=\""+cellDynamicfilters_addfilter2_cell_Internalname+"\"  class=''>") ;
            /* Active images/pictures */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 76,'',false,'',0)\"";
            ClassString = "Image";
            StyleString = "";
            sImgUrl = (string)(context.GetImagePath( "27283ea5-332f-423b-b880-64b762622df3", "", context.GetTheme( )));
            GxWebStd.gx_bitmap( context, imgAdddynamicfilters2_Internalname, sImgUrl, "", "", "", context.GetTheme( ), imgAdddynamicfilters2_Visible, 1, "", "Agregar filtro", 0, 0, 0, "px", 0, "px", 0, 0, 5, imgAdddynamicfilters2_Jsonclick, "'"+""+"'"+",false,"+"'"+"E\\'ADDDYNAMICFILTERS2\\'."+"'", StyleString, ClassString, "", "", "", "", " "+"data-gx-image"+" "+TempTags, "", "", 1, false, false, context.GetImageSrcSet( sImgUrl), "HLP_Configuracion\\TipoDocumentoWW.htm");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "<td id=\""+cellDynamicfilters_removefilter2_cell_Internalname+"\"  class=''>") ;
            /* Active images/pictures */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 78,'',false,'',0)\"";
            ClassString = "Image";
            StyleString = "";
            sImgUrl = (string)(context.GetImagePath( "11a6ef14-1a5a-4077-91a2-f41ed9a3a662", "", context.GetTheme( )));
            GxWebStd.gx_bitmap( context, imgRemovedynamicfilters2_Internalname, sImgUrl, "", "", "", context.GetTheme( ), imgRemovedynamicfilters2_Visible, 1, "", "Quitar filtro", 0, 0, 0, "px", 0, "px", 0, 0, 5, imgRemovedynamicfilters2_Jsonclick, "'"+""+"'"+",false,"+"'"+"E\\'REMOVEDYNAMICFILTERS2\\'."+"'", StyleString, ClassString, "", "", "", "", " "+"data-gx-image"+" "+TempTags, "", "", 1, false, false, context.GetImageSrcSet( sImgUrl), "HLP_Configuracion\\TipoDocumentoWW.htm");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "</tr>") ;
            /* End of table */
            context.WriteHtmlText( "</table>") ;
            wb_table3_64_1O2e( true) ;
         }
         else
         {
            wb_table3_64_1O2e( false) ;
         }
      }

      protected void wb_table2_39_1O2( bool wbgen )
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
            GxWebStd.gx_combobox_ctrl1( context, cmbavDynamicfiltersoperator1, cmbavDynamicfiltersoperator1_Internalname, StringUtil.Trim( StringUtil.Str( (decimal)(AV16DynamicFiltersOperator1), 4, 0)), 1, cmbavDynamicfiltersoperator1_Jsonclick, 0, "'"+""+"'"+",false,"+"'"+""+"'", "int", "", cmbavDynamicfiltersoperator1.Visible, cmbavDynamicfiltersoperator1.Enabled, 0, 0, 0, "em", 0, "", "", "Attribute", "", "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,43);\"", "", true, 1, "HLP_Configuracion\\TipoDocumentoWW.htm");
            cmbavDynamicfiltersoperator1.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV16DynamicFiltersOperator1), 4, 0));
            AssignProp("", false, cmbavDynamicfiltersoperator1_Internalname, "Values", (string)(cmbavDynamicfiltersoperator1.ToJavascriptSource()), true);
            GxWebStd.gx_div_end( context, "left", "top", "div");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "<td id=\""+cellFilter_tipdsc1_cell_Internalname+"\"  class=''>") ;
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "left", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavTipdsc1_Internalname, "Tip Dsc1", "gx-form-item AttributeLabel", 0, true, "width: 25%;");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 46,'',false,'" + sGXsfl_110_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavTipdsc1_Internalname, StringUtil.RTrim( AV17TipDsc1), StringUtil.RTrim( context.localUtil.Format( AV17TipDsc1, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,46);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavTipdsc1_Jsonclick, 0, "Attribute", "", "", "", "", edtavTipdsc1_Visible, edtavTipdsc1_Enabled, 0, "text", "", 80, "chr", 1, "row", 100, 0, 0, 0, 1, -1, -1, true, "", "left", true, "", "HLP_Configuracion\\TipoDocumentoWW.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "<td id=\""+cellFilter_tipabr1_cell_Internalname+"\"  class=''>") ;
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "left", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavTipabr1_Internalname, "Tip Abr1", "gx-form-item AttributeLabel", 0, true, "width: 25%;");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 49,'',false,'" + sGXsfl_110_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavTipabr1_Internalname, StringUtil.RTrim( AV66TipAbr1), StringUtil.RTrim( context.localUtil.Format( AV66TipAbr1, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,49);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavTipabr1_Jsonclick, 0, "Attribute", "", "", "", "", edtavTipabr1_Visible, edtavTipabr1_Enabled, 0, "text", "", 5, "chr", 1, "row", 5, 0, 0, 0, 1, -1, -1, true, "", "left", true, "", "HLP_Configuracion\\TipoDocumentoWW.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "<td id=\""+cellDynamicfilters_addfilter1_cell_Internalname+"\"  class=''>") ;
            /* Active images/pictures */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 51,'',false,'',0)\"";
            ClassString = "Image";
            StyleString = "";
            sImgUrl = (string)(context.GetImagePath( "27283ea5-332f-423b-b880-64b762622df3", "", context.GetTheme( )));
            GxWebStd.gx_bitmap( context, imgAdddynamicfilters1_Internalname, sImgUrl, "", "", "", context.GetTheme( ), imgAdddynamicfilters1_Visible, 1, "", "Agregar filtro", 0, 0, 0, "px", 0, "px", 0, 0, 5, imgAdddynamicfilters1_Jsonclick, "'"+""+"'"+",false,"+"'"+"E\\'ADDDYNAMICFILTERS1\\'."+"'", StyleString, ClassString, "", "", "", "", " "+"data-gx-image"+" "+TempTags, "", "", 1, false, false, context.GetImageSrcSet( sImgUrl), "HLP_Configuracion\\TipoDocumentoWW.htm");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "<td id=\""+cellDynamicfilters_removefilter1_cell_Internalname+"\"  class=''>") ;
            /* Active images/pictures */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 53,'',false,'',0)\"";
            ClassString = "Image";
            StyleString = "";
            sImgUrl = (string)(context.GetImagePath( "11a6ef14-1a5a-4077-91a2-f41ed9a3a662", "", context.GetTheme( )));
            GxWebStd.gx_bitmap( context, imgRemovedynamicfilters1_Internalname, sImgUrl, "", "", "", context.GetTheme( ), imgRemovedynamicfilters1_Visible, 1, "", "Quitar filtro", 0, 0, 0, "px", 0, "px", 0, 0, 5, imgRemovedynamicfilters1_Jsonclick, "'"+""+"'"+",false,"+"'"+"E\\'REMOVEDYNAMICFILTERS1\\'."+"'", StyleString, ClassString, "", "", "", "", " "+"data-gx-image"+" "+TempTags, "", "", 1, false, false, context.GetImageSrcSet( sImgUrl), "HLP_Configuracion\\TipoDocumentoWW.htm");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "</tr>") ;
            /* End of table */
            context.WriteHtmlText( "</table>") ;
            wb_table2_39_1O2e( true) ;
         }
         else
         {
            wb_table2_39_1O2e( false) ;
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
         PA1O2( ) ;
         WS1O2( ) ;
         WE1O2( ) ;
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
            context.AddJavascriptSource(StringUtil.RTrim( ((string)Form.Jscriptsrc.Item(idxLst))), "?202281810293869", true, true);
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
         context.AddJavascriptSource("configuracion/tipodocumentoww.js", "?202281810293869", false, true);
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
         edtTipCod_Internalname = "TIPCOD_"+sGXsfl_110_idx;
         edtTipAbr_Internalname = "TIPABR_"+sGXsfl_110_idx;
         edtTipDsc_Internalname = "TIPDSC_"+sGXsfl_110_idx;
         edtTipVta_Internalname = "TIPVTA_"+sGXsfl_110_idx;
         edtTipCmp_Internalname = "TIPCMP_"+sGXsfl_110_idx;
         edtTipRHo_Internalname = "TIPRHO_"+sGXsfl_110_idx;
         chkTipCxP_Internalname = "TIPCXP_"+sGXsfl_110_idx;
         chkTipBan_Internalname = "TIPBAN_"+sGXsfl_110_idx;
         edtTipSts_Internalname = "TIPSTS_"+sGXsfl_110_idx;
      }

      protected void SubsflControlProps_fel_1102( )
      {
         cmbavGridactions_Internalname = "vGRIDACTIONS_"+sGXsfl_110_fel_idx;
         edtTipCod_Internalname = "TIPCOD_"+sGXsfl_110_fel_idx;
         edtTipAbr_Internalname = "TIPABR_"+sGXsfl_110_fel_idx;
         edtTipDsc_Internalname = "TIPDSC_"+sGXsfl_110_fel_idx;
         edtTipVta_Internalname = "TIPVTA_"+sGXsfl_110_fel_idx;
         edtTipCmp_Internalname = "TIPCMP_"+sGXsfl_110_fel_idx;
         edtTipRHo_Internalname = "TIPRHO_"+sGXsfl_110_fel_idx;
         chkTipCxP_Internalname = "TIPCXP_"+sGXsfl_110_fel_idx;
         chkTipBan_Internalname = "TIPBAN_"+sGXsfl_110_fel_idx;
         edtTipSts_Internalname = "TIPSTS_"+sGXsfl_110_fel_idx;
      }

      protected void sendrow_1102( )
      {
         SubsflControlProps_1102( ) ;
         WB1O0( ) ;
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
                  AV56GridActions = (short)(NumberUtil.Val( cmbavGridactions.getValidValue(StringUtil.Trim( StringUtil.Str( (decimal)(AV56GridActions), 4, 0))), "."));
                  AssignAttri("", false, cmbavGridactions_Internalname, StringUtil.LTrimStr( (decimal)(AV56GridActions), 4, 0));
               }
            }
            /* ComboBox */
            GridRow.AddColumnProperties("combobox", 2, isAjaxCallMode( ), new Object[] {(GXCombobox)cmbavGridactions,(string)cmbavGridactions_Internalname,StringUtil.Trim( StringUtil.Str( (decimal)(AV56GridActions), 4, 0)),(short)1,(string)cmbavGridactions_Jsonclick,(short)5,"'"+""+"'"+",false,"+"'"+"EVGRIDACTIONS.CLICK."+sGXsfl_110_idx+"'",(string)"int",(string)"",(short)-1,(short)1,(short)0,(short)0,(short)0,(string)"px",(short)0,(string)"px",(string)"",(string)"ConvertToDDO",(string)"WWActionGroupColumn",(string)"",TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+((cmbavGridactions.Enabled!=0)&&(cmbavGridactions.Visible!=0) ? " onblur=\""+""+";gx.evt.onblur(this,111);\"" : " "),(string)"",(bool)true,(short)1});
            cmbavGridactions.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV56GridActions), 4, 0));
            AssignProp("", false, cmbavGridactions_Internalname, "Values", (string)(cmbavGridactions.ToJavascriptSource()), !bGXsfl_110_Refreshing);
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"left"+"\""+" style=\""+"display:none;"+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtTipCod_Internalname,StringUtil.RTrim( A149TipCod),(string)"",(string)"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtTipCod_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn hidden-xs",(string)"",(short)0,(short)0,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)3,(short)0,(short)0,(short)110,(short)1,(short)-1,(short)-1,(bool)true,(string)"",(string)"left",(bool)true,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"left"+"\""+" style=\""+""+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtTipAbr_Internalname,StringUtil.RTrim( A306TipAbr),(string)"",(string)"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtTipAbr_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn hidden-xs",(string)"",(short)-1,(short)0,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)5,(short)0,(short)0,(short)110,(short)1,(short)-1,(short)-1,(bool)true,(string)"",(string)"left",(bool)true,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"left"+"\""+" style=\""+""+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtTipDsc_Internalname,StringUtil.RTrim( A1910TipDsc),(string)"",(string)"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)edtTipDsc_Link,(string)"",(string)"",(string)"",(string)edtTipDsc_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn",(string)"",(short)-1,(short)0,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)100,(short)0,(short)0,(short)110,(short)1,(short)-1,(short)-1,(bool)true,(string)"",(string)"left",(bool)true,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"right"+"\""+" style=\""+""+"\">") ;
            }
            /* Single line edit */
            ROClassString = "AttributeCheckBox";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtTipVta_Internalname,StringUtil.LTrim( StringUtil.NToC( (decimal)(A1921TipVta), 1, 0, ".", "")),StringUtil.LTrim( context.localUtil.Format( (decimal)(A1921TipVta), "9")),(string)" inputmode=\"numeric\" pattern=\"[0-9]*\""+"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtTipVta_Jsonclick,(short)0,(string)"AttributeCheckBox",(string)"",(string)ROClassString,(string)"WWColumn hidden-xs",(string)"",(short)-1,(short)0,(short)0,(string)"text",(string)"1",(short)0,(string)"px",(short)17,(string)"px",(short)1,(short)0,(short)0,(short)110,(short)1,(short)-1,(short)0,(bool)true,(string)"",(string)"right",(bool)false,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"right"+"\""+" style=\""+""+"\">") ;
            }
            /* Single line edit */
            ROClassString = "AttributeCheckBox";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtTipCmp_Internalname,StringUtil.LTrim( StringUtil.NToC( (decimal)(A1906TipCmp), 1, 0, ".", "")),StringUtil.LTrim( context.localUtil.Format( (decimal)(A1906TipCmp), "9")),(string)" inputmode=\"numeric\" pattern=\"[0-9]*\""+"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtTipCmp_Jsonclick,(short)0,(string)"AttributeCheckBox",(string)"",(string)ROClassString,(string)"WWColumn hidden-xs",(string)"",(short)-1,(short)0,(short)0,(string)"text",(string)"1",(short)0,(string)"px",(short)17,(string)"px",(short)1,(short)0,(short)0,(short)110,(short)1,(short)-1,(short)0,(bool)true,(string)"",(string)"right",(bool)false,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"right"+"\""+" style=\""+""+"\">") ;
            }
            /* Single line edit */
            ROClassString = "AttributeCheckBox";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtTipRHo_Internalname,StringUtil.LTrim( StringUtil.NToC( (decimal)(A1915TipRHo), 1, 0, ".", "")),StringUtil.LTrim( context.localUtil.Format( (decimal)(A1915TipRHo), "9")),(string)" inputmode=\"numeric\" pattern=\"[0-9]*\""+"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtTipRHo_Jsonclick,(short)0,(string)"AttributeCheckBox",(string)"",(string)ROClassString,(string)"WWColumn hidden-xs",(string)"",(short)-1,(short)0,(short)0,(string)"text",(string)"1",(short)0,(string)"px",(short)17,(string)"px",(short)1,(short)0,(short)0,(short)110,(short)1,(short)-1,(short)0,(bool)true,(string)"",(string)"right",(bool)false,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+""+"\""+" style=\""+""+"\">") ;
            }
            /* Check box */
            ClassString = "AttributeCheckBox";
            StyleString = "";
            GXCCtl = "TIPCXP_" + sGXsfl_110_idx;
            chkTipCxP.Name = GXCCtl;
            chkTipCxP.WebTags = "";
            chkTipCxP.Caption = "";
            AssignProp("", false, chkTipCxP_Internalname, "TitleCaption", chkTipCxP.Caption, !bGXsfl_110_Refreshing);
            chkTipCxP.CheckedValue = "0";
            A1909TipCxP = (short)(((StringUtil.StrCmp(StringUtil.LTrim( StringUtil.NToC( (decimal)(A1909TipCxP), 1, 0, ".", "")), "1")==0) ? 1 : 0));
            GridRow.AddColumnProperties("checkbox", 1, isAjaxCallMode( ), new Object[] {(string)chkTipCxP_Internalname,StringUtil.Str( (decimal)(A1909TipCxP), 1, 0),(string)"",(string)"",(short)-1,(short)0,(string)"1",(string)"",(string)StyleString,(string)ClassString,(string)"WWColumn hidden-xs",(string)"",(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+""+"\""+" style=\""+""+"\">") ;
            }
            /* Check box */
            ClassString = "AttributeCheckBox";
            StyleString = "";
            GXCCtl = "TIPBAN_" + sGXsfl_110_idx;
            chkTipBan.Name = GXCCtl;
            chkTipBan.WebTags = "";
            chkTipBan.Caption = "";
            AssignProp("", false, chkTipBan_Internalname, "TitleCaption", chkTipBan.Caption, !bGXsfl_110_Refreshing);
            chkTipBan.CheckedValue = "0";
            A1903TipBan = (short)(((StringUtil.StrCmp(StringUtil.LTrim( StringUtil.NToC( (decimal)(A1903TipBan), 1, 0, ".", "")), "1")==0) ? 1 : 0));
            GridRow.AddColumnProperties("checkbox", 1, isAjaxCallMode( ), new Object[] {(string)chkTipBan_Internalname,StringUtil.Str( (decimal)(A1903TipBan), 1, 0),(string)"",(string)"",(short)-1,(short)0,(string)"1",(string)"",(string)StyleString,(string)ClassString,(string)"WWColumn hidden-xs",(string)"",(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"right"+"\""+" style=\""+""+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtTipSts_Internalname,StringUtil.LTrim( StringUtil.NToC( (decimal)(A1919TipSts), 1, 0, ".", "")),StringUtil.LTrim( context.localUtil.Format( (decimal)(A1919TipSts), "9")),(string)" inputmode=\"numeric\" pattern=\"[0-9]*\""+"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtTipSts_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn hidden-xs",(string)"",(short)-1,(short)0,(short)0,(string)"text",(string)"1",(short)0,(string)"px",(short)17,(string)"px",(short)1,(short)0,(short)0,(short)110,(short)1,(short)-1,(short)0,(bool)true,(string)"",(string)"right",(bool)false,(string)""});
            send_integrity_lvl_hashes1O2( ) ;
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
         cmbavDynamicfiltersselector1.addItem("TIPDSC", "Tipo de Documento", 0);
         cmbavDynamicfiltersselector1.addItem("TIPABR", "Codigo Sunat", 0);
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
         cmbavDynamicfiltersselector2.addItem("TIPDSC", "Tipo de Documento", 0);
         cmbavDynamicfiltersselector2.addItem("TIPABR", "Codigo Sunat", 0);
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
         cmbavDynamicfiltersselector3.addItem("TIPDSC", "Tipo de Documento", 0);
         cmbavDynamicfiltersselector3.addItem("TIPABR", "Codigo Sunat", 0);
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
            AV56GridActions = (short)(NumberUtil.Val( cmbavGridactions.getValidValue(StringUtil.Trim( StringUtil.Str( (decimal)(AV56GridActions), 4, 0))), "."));
            AssignAttri("", false, cmbavGridactions_Internalname, StringUtil.LTrimStr( (decimal)(AV56GridActions), 4, 0));
         }
         GXCCtl = "TIPCXP_" + sGXsfl_110_idx;
         chkTipCxP.Name = GXCCtl;
         chkTipCxP.WebTags = "";
         chkTipCxP.Caption = "";
         AssignProp("", false, chkTipCxP_Internalname, "TitleCaption", chkTipCxP.Caption, !bGXsfl_110_Refreshing);
         chkTipCxP.CheckedValue = "0";
         A1909TipCxP = (short)(((StringUtil.StrCmp(StringUtil.LTrim( StringUtil.NToC( (decimal)(A1909TipCxP), 1, 0, ".", "")), "1")==0) ? 1 : 0));
         GXCCtl = "TIPBAN_" + sGXsfl_110_idx;
         chkTipBan.Name = GXCCtl;
         chkTipBan.WebTags = "";
         chkTipBan.Caption = "";
         AssignProp("", false, chkTipBan_Internalname, "TitleCaption", chkTipBan.Caption, !bGXsfl_110_Refreshing);
         chkTipBan.CheckedValue = "0";
         A1903TipBan = (short)(((StringUtil.StrCmp(StringUtil.LTrim( StringUtil.NToC( (decimal)(A1903TipBan), 1, 0, ".", "")), "1")==0) ? 1 : 0));
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
         edtavTipdsc1_Internalname = "vTIPDSC1";
         cellFilter_tipdsc1_cell_Internalname = "FILTER_TIPDSC1_CELL";
         edtavTipabr1_Internalname = "vTIPABR1";
         cellFilter_tipabr1_cell_Internalname = "FILTER_TIPABR1_CELL";
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
         edtavTipdsc2_Internalname = "vTIPDSC2";
         cellFilter_tipdsc2_cell_Internalname = "FILTER_TIPDSC2_CELL";
         edtavTipabr2_Internalname = "vTIPABR2";
         cellFilter_tipabr2_cell_Internalname = "FILTER_TIPABR2_CELL";
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
         edtavTipdsc3_Internalname = "vTIPDSC3";
         cellFilter_tipdsc3_cell_Internalname = "FILTER_TIPDSC3_CELL";
         edtavTipabr3_Internalname = "vTIPABR3";
         cellFilter_tipabr3_cell_Internalname = "FILTER_TIPABR3_CELL";
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
         edtTipCod_Internalname = "TIPCOD";
         edtTipAbr_Internalname = "TIPABR";
         edtTipDsc_Internalname = "TIPDSC";
         edtTipVta_Internalname = "TIPVTA";
         edtTipCmp_Internalname = "TIPCMP";
         edtTipRHo_Internalname = "TIPRHO";
         chkTipCxP_Internalname = "TIPCXP";
         chkTipBan_Internalname = "TIPBAN";
         edtTipSts_Internalname = "TIPSTS";
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
         edtTipSts_Jsonclick = "";
         chkTipBan.Caption = "";
         chkTipCxP.Caption = "";
         edtTipRHo_Jsonclick = "";
         edtTipCmp_Jsonclick = "";
         edtTipVta_Jsonclick = "";
         edtTipDsc_Jsonclick = "";
         edtTipAbr_Jsonclick = "";
         edtTipCod_Jsonclick = "";
         cmbavGridactions_Jsonclick = "";
         cmbavGridactions.Visible = -1;
         cmbavGridactions.Enabled = 1;
         imgRemovedynamicfilters1_Visible = 1;
         imgAdddynamicfilters1_Visible = 1;
         edtavTipabr1_Jsonclick = "";
         edtavTipabr1_Enabled = 1;
         edtavTipdsc1_Jsonclick = "";
         edtavTipdsc1_Enabled = 1;
         cmbavDynamicfiltersoperator1_Jsonclick = "";
         cmbavDynamicfiltersoperator1.Enabled = 1;
         imgRemovedynamicfilters2_Visible = 1;
         imgAdddynamicfilters2_Visible = 1;
         edtavTipabr2_Jsonclick = "";
         edtavTipabr2_Enabled = 1;
         edtavTipdsc2_Jsonclick = "";
         edtavTipdsc2_Enabled = 1;
         cmbavDynamicfiltersoperator2_Jsonclick = "";
         cmbavDynamicfiltersoperator2.Enabled = 1;
         edtavTipabr3_Jsonclick = "";
         edtavTipabr3_Enabled = 1;
         edtavTipdsc3_Jsonclick = "";
         edtavTipdsc3_Enabled = 1;
         cmbavDynamicfiltersoperator3_Jsonclick = "";
         cmbavDynamicfiltersoperator3.Enabled = 1;
         cmbavDynamicfiltersselector3_Jsonclick = "";
         cmbavDynamicfiltersselector3.Enabled = 1;
         cmbavDynamicfiltersselector2_Jsonclick = "";
         cmbavDynamicfiltersselector2.Enabled = 1;
         cmbavDynamicfiltersselector1_Jsonclick = "";
         cmbavDynamicfiltersselector1.Enabled = 1;
         cmbavDynamicfiltersoperator3.Visible = 1;
         edtavTipabr3_Visible = 1;
         edtavTipdsc3_Visible = 1;
         cmbavDynamicfiltersoperator2.Visible = 1;
         edtavTipabr2_Visible = 1;
         edtavTipdsc2_Visible = 1;
         cmbavDynamicfiltersoperator1.Visible = 1;
         edtavTipabr1_Visible = 1;
         edtavTipdsc1_Visible = 1;
         lblJsdynamicfilters_Caption = "JSDynamicFilters";
         subGrid_Allowcollapsing = 0;
         subGrid_Allowselection = 0;
         edtTipDsc_Link = "";
         subGrid_Sortable = 0;
         subGrid_Header = "";
         subGrid_Class = "GridWithPaginationBar WorkWith";
         subGrid_Backcolorstyle = 0;
         Grid_empowerer_Hastitlesettings = Convert.ToBoolean( -1);
         Innewwindow1_Target = "";
         Innewwindow1_Height = "50";
         Innewwindow1_Width = "50";
         Ddo_grid_Datalistproc = "Configuracion.TipoDocumentoWWGetFilterData";
         Ddo_grid_Datalistfixedvalues = "||1:WWP_TSChecked,2:WWP_TSUnChecked|1:WWP_TSChecked,2:WWP_TSUnChecked|1:WWP_TSChecked,2:WWP_TSUnChecked|1:WWP_TSChecked,2:WWP_TSUnChecked|1:WWP_TSChecked,2:WWP_TSUnChecked|1:ACTIVO,0:INACTIVO";
         Ddo_grid_Allowmultipleselection = "|||||||T";
         Ddo_grid_Datalisttype = "Dynamic|Dynamic|FixedValues|FixedValues|FixedValues|FixedValues|FixedValues|FixedValues";
         Ddo_grid_Includedatalist = "T";
         Ddo_grid_Filtertype = "Character|Character||||||";
         Ddo_grid_Includefilter = "T|T||||||";
         Ddo_grid_Includesortasc = "T";
         Ddo_grid_Columnssortvalues = "1|2|3|4|5|6|7|8";
         Ddo_grid_Columnids = "2:TipAbr|3:TipDsc|4:TipVta|5:TipCmp|6:TipRHo|7:TipCxP|8:TipBan|9:TipSts";
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
         Form.Caption = "Tipo de Documentos";
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
         setEventMetadata("REFRESH","{handler:'Refresh',iparms:[{av:'GRID_nFirstRecordOnPage'},{av:'GRID_nEOF'},{av:'cmbavDynamicfiltersselector1'},{av:'AV15DynamicFiltersSelector1',fld:'vDYNAMICFILTERSSELECTOR1',pic:''},{av:'AV18DynamicFiltersEnabled2',fld:'vDYNAMICFILTERSENABLED2',pic:''},{av:'cmbavDynamicfiltersselector2'},{av:'AV19DynamicFiltersSelector2',fld:'vDYNAMICFILTERSSELECTOR2',pic:''},{av:'AV22DynamicFiltersEnabled3',fld:'vDYNAMICFILTERSENABLED3',pic:''},{av:'cmbavDynamicfiltersselector3'},{av:'AV23DynamicFiltersSelector3',fld:'vDYNAMICFILTERSSELECTOR3',pic:''},{av:'subGrid_Rows',ctrl:'GRID',prop:'Rows'},{av:'cmbavDynamicfiltersoperator1'},{av:'AV16DynamicFiltersOperator1',fld:'vDYNAMICFILTERSOPERATOR1',pic:'ZZZ9'},{av:'AV17TipDsc1',fld:'vTIPDSC1',pic:''},{av:'AV66TipAbr1',fld:'vTIPABR1',pic:''},{av:'cmbavDynamicfiltersoperator2'},{av:'AV20DynamicFiltersOperator2',fld:'vDYNAMICFILTERSOPERATOR2',pic:'ZZZ9'},{av:'AV21TipDsc2',fld:'vTIPDSC2',pic:''},{av:'AV67TipAbr2',fld:'vTIPABR2',pic:''},{av:'cmbavDynamicfiltersoperator3'},{av:'AV24DynamicFiltersOperator3',fld:'vDYNAMICFILTERSOPERATOR3',pic:'ZZZ9'},{av:'AV25TipDsc3',fld:'vTIPDSC3',pic:''},{av:'AV68TipAbr3',fld:'vTIPABR3',pic:''},{av:'AV71Pgmname',fld:'vPGMNAME',pic:'',hsh:true},{av:'AV35TFTipAbr',fld:'vTFTIPABR',pic:''},{av:'AV36TFTipAbr_Sel',fld:'vTFTIPABR_SEL',pic:''},{av:'AV33TFTipDsc',fld:'vTFTIPDSC',pic:''},{av:'AV34TFTipDsc_Sel',fld:'vTFTIPDSC_SEL',pic:''},{av:'AV59TFTipVta_Sel',fld:'vTFTIPVTA_SEL',pic:'9'},{av:'AV60TFTipCmp_Sel',fld:'vTFTIPCMP_SEL',pic:'9'},{av:'AV61TFTipRHo_Sel',fld:'vTFTIPRHO_SEL',pic:'9'},{av:'AV62TFTipCxP_Sel',fld:'vTFTIPCXP_SEL',pic:'9'},{av:'AV63TFTipBan_Sel',fld:'vTFTIPBAN_SEL',pic:'9'},{av:'AV65TFTipSts_Sels',fld:'vTFTIPSTS_SELS',pic:''},{av:'AV13OrderedBy',fld:'vORDEREDBY',pic:'ZZZ9'},{av:'AV14OrderedDsc',fld:'vORDEREDDSC',pic:''},{av:'AV10GridState',fld:'vGRIDSTATE',pic:''},{av:'AV27DynamicFiltersIgnoreFirst',fld:'vDYNAMICFILTERSIGNOREFIRST',pic:''},{av:'AV26DynamicFiltersRemoving',fld:'vDYNAMICFILTERSREMOVING',pic:''}]");
         setEventMetadata("REFRESH",",oparms:[{av:'cmbavDynamicfiltersoperator1'},{av:'AV16DynamicFiltersOperator1',fld:'vDYNAMICFILTERSOPERATOR1',pic:'ZZZ9'},{av:'cmbavDynamicfiltersoperator2'},{av:'AV20DynamicFiltersOperator2',fld:'vDYNAMICFILTERSOPERATOR2',pic:'ZZZ9'},{av:'cmbavDynamicfiltersoperator3'},{av:'AV24DynamicFiltersOperator3',fld:'vDYNAMICFILTERSOPERATOR3',pic:'ZZZ9'},{av:'AV53GridCurrentPage',fld:'vGRIDCURRENTPAGE',pic:'ZZZZZZZZZ9'},{av:'AV54GridPageCount',fld:'vGRIDPAGECOUNT',pic:'ZZZZZZZZZ9'},{av:'AV55GridAppliedFilters',fld:'vGRIDAPPLIEDFILTERS',pic:''},{av:'AV10GridState',fld:'vGRIDSTATE',pic:''}]}");
         setEventMetadata("GRIDPAGINATIONBAR.CHANGEPAGE","{handler:'E111O2',iparms:[{av:'GRID_nFirstRecordOnPage'},{av:'GRID_nEOF'},{av:'subGrid_Rows',ctrl:'GRID',prop:'Rows'},{av:'cmbavDynamicfiltersselector1'},{av:'AV15DynamicFiltersSelector1',fld:'vDYNAMICFILTERSSELECTOR1',pic:''},{av:'cmbavDynamicfiltersoperator1'},{av:'AV16DynamicFiltersOperator1',fld:'vDYNAMICFILTERSOPERATOR1',pic:'ZZZ9'},{av:'AV17TipDsc1',fld:'vTIPDSC1',pic:''},{av:'AV66TipAbr1',fld:'vTIPABR1',pic:''},{av:'cmbavDynamicfiltersselector2'},{av:'AV19DynamicFiltersSelector2',fld:'vDYNAMICFILTERSSELECTOR2',pic:''},{av:'cmbavDynamicfiltersoperator2'},{av:'AV20DynamicFiltersOperator2',fld:'vDYNAMICFILTERSOPERATOR2',pic:'ZZZ9'},{av:'AV21TipDsc2',fld:'vTIPDSC2',pic:''},{av:'AV67TipAbr2',fld:'vTIPABR2',pic:''},{av:'cmbavDynamicfiltersselector3'},{av:'AV23DynamicFiltersSelector3',fld:'vDYNAMICFILTERSSELECTOR3',pic:''},{av:'cmbavDynamicfiltersoperator3'},{av:'AV24DynamicFiltersOperator3',fld:'vDYNAMICFILTERSOPERATOR3',pic:'ZZZ9'},{av:'AV25TipDsc3',fld:'vTIPDSC3',pic:''},{av:'AV68TipAbr3',fld:'vTIPABR3',pic:''},{av:'AV18DynamicFiltersEnabled2',fld:'vDYNAMICFILTERSENABLED2',pic:''},{av:'AV22DynamicFiltersEnabled3',fld:'vDYNAMICFILTERSENABLED3',pic:''},{av:'AV71Pgmname',fld:'vPGMNAME',pic:'',hsh:true},{av:'AV35TFTipAbr',fld:'vTFTIPABR',pic:''},{av:'AV36TFTipAbr_Sel',fld:'vTFTIPABR_SEL',pic:''},{av:'AV33TFTipDsc',fld:'vTFTIPDSC',pic:''},{av:'AV34TFTipDsc_Sel',fld:'vTFTIPDSC_SEL',pic:''},{av:'AV59TFTipVta_Sel',fld:'vTFTIPVTA_SEL',pic:'9'},{av:'AV60TFTipCmp_Sel',fld:'vTFTIPCMP_SEL',pic:'9'},{av:'AV61TFTipRHo_Sel',fld:'vTFTIPRHO_SEL',pic:'9'},{av:'AV62TFTipCxP_Sel',fld:'vTFTIPCXP_SEL',pic:'9'},{av:'AV63TFTipBan_Sel',fld:'vTFTIPBAN_SEL',pic:'9'},{av:'AV65TFTipSts_Sels',fld:'vTFTIPSTS_SELS',pic:''},{av:'AV13OrderedBy',fld:'vORDEREDBY',pic:'ZZZ9'},{av:'AV14OrderedDsc',fld:'vORDEREDDSC',pic:''},{av:'AV10GridState',fld:'vGRIDSTATE',pic:''},{av:'AV27DynamicFiltersIgnoreFirst',fld:'vDYNAMICFILTERSIGNOREFIRST',pic:''},{av:'AV26DynamicFiltersRemoving',fld:'vDYNAMICFILTERSREMOVING',pic:''},{av:'Gridpaginationbar_Selectedpage',ctrl:'GRIDPAGINATIONBAR',prop:'SelectedPage'}]");
         setEventMetadata("GRIDPAGINATIONBAR.CHANGEPAGE",",oparms:[]}");
         setEventMetadata("GRIDPAGINATIONBAR.CHANGEROWSPERPAGE","{handler:'E121O2',iparms:[{av:'GRID_nFirstRecordOnPage'},{av:'GRID_nEOF'},{av:'subGrid_Rows',ctrl:'GRID',prop:'Rows'},{av:'cmbavDynamicfiltersselector1'},{av:'AV15DynamicFiltersSelector1',fld:'vDYNAMICFILTERSSELECTOR1',pic:''},{av:'cmbavDynamicfiltersoperator1'},{av:'AV16DynamicFiltersOperator1',fld:'vDYNAMICFILTERSOPERATOR1',pic:'ZZZ9'},{av:'AV17TipDsc1',fld:'vTIPDSC1',pic:''},{av:'AV66TipAbr1',fld:'vTIPABR1',pic:''},{av:'cmbavDynamicfiltersselector2'},{av:'AV19DynamicFiltersSelector2',fld:'vDYNAMICFILTERSSELECTOR2',pic:''},{av:'cmbavDynamicfiltersoperator2'},{av:'AV20DynamicFiltersOperator2',fld:'vDYNAMICFILTERSOPERATOR2',pic:'ZZZ9'},{av:'AV21TipDsc2',fld:'vTIPDSC2',pic:''},{av:'AV67TipAbr2',fld:'vTIPABR2',pic:''},{av:'cmbavDynamicfiltersselector3'},{av:'AV23DynamicFiltersSelector3',fld:'vDYNAMICFILTERSSELECTOR3',pic:''},{av:'cmbavDynamicfiltersoperator3'},{av:'AV24DynamicFiltersOperator3',fld:'vDYNAMICFILTERSOPERATOR3',pic:'ZZZ9'},{av:'AV25TipDsc3',fld:'vTIPDSC3',pic:''},{av:'AV68TipAbr3',fld:'vTIPABR3',pic:''},{av:'AV18DynamicFiltersEnabled2',fld:'vDYNAMICFILTERSENABLED2',pic:''},{av:'AV22DynamicFiltersEnabled3',fld:'vDYNAMICFILTERSENABLED3',pic:''},{av:'AV71Pgmname',fld:'vPGMNAME',pic:'',hsh:true},{av:'AV35TFTipAbr',fld:'vTFTIPABR',pic:''},{av:'AV36TFTipAbr_Sel',fld:'vTFTIPABR_SEL',pic:''},{av:'AV33TFTipDsc',fld:'vTFTIPDSC',pic:''},{av:'AV34TFTipDsc_Sel',fld:'vTFTIPDSC_SEL',pic:''},{av:'AV59TFTipVta_Sel',fld:'vTFTIPVTA_SEL',pic:'9'},{av:'AV60TFTipCmp_Sel',fld:'vTFTIPCMP_SEL',pic:'9'},{av:'AV61TFTipRHo_Sel',fld:'vTFTIPRHO_SEL',pic:'9'},{av:'AV62TFTipCxP_Sel',fld:'vTFTIPCXP_SEL',pic:'9'},{av:'AV63TFTipBan_Sel',fld:'vTFTIPBAN_SEL',pic:'9'},{av:'AV65TFTipSts_Sels',fld:'vTFTIPSTS_SELS',pic:''},{av:'AV13OrderedBy',fld:'vORDEREDBY',pic:'ZZZ9'},{av:'AV14OrderedDsc',fld:'vORDEREDDSC',pic:''},{av:'AV10GridState',fld:'vGRIDSTATE',pic:''},{av:'AV27DynamicFiltersIgnoreFirst',fld:'vDYNAMICFILTERSIGNOREFIRST',pic:''},{av:'AV26DynamicFiltersRemoving',fld:'vDYNAMICFILTERSREMOVING',pic:''},{av:'Gridpaginationbar_Rowsperpageselectedvalue',ctrl:'GRIDPAGINATIONBAR',prop:'RowsPerPageSelectedValue'}]");
         setEventMetadata("GRIDPAGINATIONBAR.CHANGEROWSPERPAGE",",oparms:[{av:'subGrid_Rows',ctrl:'GRID',prop:'Rows'}]}");
         setEventMetadata("DDO_GRID.ONOPTIONCLICKED","{handler:'E141O2',iparms:[{av:'GRID_nFirstRecordOnPage'},{av:'GRID_nEOF'},{av:'subGrid_Rows',ctrl:'GRID',prop:'Rows'},{av:'cmbavDynamicfiltersselector1'},{av:'AV15DynamicFiltersSelector1',fld:'vDYNAMICFILTERSSELECTOR1',pic:''},{av:'cmbavDynamicfiltersoperator1'},{av:'AV16DynamicFiltersOperator1',fld:'vDYNAMICFILTERSOPERATOR1',pic:'ZZZ9'},{av:'AV17TipDsc1',fld:'vTIPDSC1',pic:''},{av:'AV66TipAbr1',fld:'vTIPABR1',pic:''},{av:'cmbavDynamicfiltersselector2'},{av:'AV19DynamicFiltersSelector2',fld:'vDYNAMICFILTERSSELECTOR2',pic:''},{av:'cmbavDynamicfiltersoperator2'},{av:'AV20DynamicFiltersOperator2',fld:'vDYNAMICFILTERSOPERATOR2',pic:'ZZZ9'},{av:'AV21TipDsc2',fld:'vTIPDSC2',pic:''},{av:'AV67TipAbr2',fld:'vTIPABR2',pic:''},{av:'cmbavDynamicfiltersselector3'},{av:'AV23DynamicFiltersSelector3',fld:'vDYNAMICFILTERSSELECTOR3',pic:''},{av:'cmbavDynamicfiltersoperator3'},{av:'AV24DynamicFiltersOperator3',fld:'vDYNAMICFILTERSOPERATOR3',pic:'ZZZ9'},{av:'AV25TipDsc3',fld:'vTIPDSC3',pic:''},{av:'AV68TipAbr3',fld:'vTIPABR3',pic:''},{av:'AV18DynamicFiltersEnabled2',fld:'vDYNAMICFILTERSENABLED2',pic:''},{av:'AV22DynamicFiltersEnabled3',fld:'vDYNAMICFILTERSENABLED3',pic:''},{av:'AV71Pgmname',fld:'vPGMNAME',pic:'',hsh:true},{av:'AV35TFTipAbr',fld:'vTFTIPABR',pic:''},{av:'AV36TFTipAbr_Sel',fld:'vTFTIPABR_SEL',pic:''},{av:'AV33TFTipDsc',fld:'vTFTIPDSC',pic:''},{av:'AV34TFTipDsc_Sel',fld:'vTFTIPDSC_SEL',pic:''},{av:'AV59TFTipVta_Sel',fld:'vTFTIPVTA_SEL',pic:'9'},{av:'AV60TFTipCmp_Sel',fld:'vTFTIPCMP_SEL',pic:'9'},{av:'AV61TFTipRHo_Sel',fld:'vTFTIPRHO_SEL',pic:'9'},{av:'AV62TFTipCxP_Sel',fld:'vTFTIPCXP_SEL',pic:'9'},{av:'AV63TFTipBan_Sel',fld:'vTFTIPBAN_SEL',pic:'9'},{av:'AV65TFTipSts_Sels',fld:'vTFTIPSTS_SELS',pic:''},{av:'AV13OrderedBy',fld:'vORDEREDBY',pic:'ZZZ9'},{av:'AV14OrderedDsc',fld:'vORDEREDDSC',pic:''},{av:'AV10GridState',fld:'vGRIDSTATE',pic:''},{av:'AV27DynamicFiltersIgnoreFirst',fld:'vDYNAMICFILTERSIGNOREFIRST',pic:''},{av:'AV26DynamicFiltersRemoving',fld:'vDYNAMICFILTERSREMOVING',pic:''},{av:'Ddo_grid_Activeeventkey',ctrl:'DDO_GRID',prop:'ActiveEventKey'},{av:'Ddo_grid_Selectedvalue_get',ctrl:'DDO_GRID',prop:'SelectedValue_get'},{av:'Ddo_grid_Filteredtext_get',ctrl:'DDO_GRID',prop:'FilteredText_get'},{av:'Ddo_grid_Selectedcolumn',ctrl:'DDO_GRID',prop:'SelectedColumn'}]");
         setEventMetadata("DDO_GRID.ONOPTIONCLICKED",",oparms:[{av:'AV13OrderedBy',fld:'vORDEREDBY',pic:'ZZZ9'},{av:'AV14OrderedDsc',fld:'vORDEREDDSC',pic:''},{av:'AV64TFTipSts_SelsJson',fld:'vTFTIPSTS_SELSJSON',pic:''},{av:'AV65TFTipSts_Sels',fld:'vTFTIPSTS_SELS',pic:''},{av:'AV63TFTipBan_Sel',fld:'vTFTIPBAN_SEL',pic:'9'},{av:'AV62TFTipCxP_Sel',fld:'vTFTIPCXP_SEL',pic:'9'},{av:'AV61TFTipRHo_Sel',fld:'vTFTIPRHO_SEL',pic:'9'},{av:'AV60TFTipCmp_Sel',fld:'vTFTIPCMP_SEL',pic:'9'},{av:'AV59TFTipVta_Sel',fld:'vTFTIPVTA_SEL',pic:'9'},{av:'AV33TFTipDsc',fld:'vTFTIPDSC',pic:''},{av:'AV34TFTipDsc_Sel',fld:'vTFTIPDSC_SEL',pic:''},{av:'AV35TFTipAbr',fld:'vTFTIPABR',pic:''},{av:'AV36TFTipAbr_Sel',fld:'vTFTIPABR_SEL',pic:''},{av:'Ddo_grid_Sortedstatus',ctrl:'DDO_GRID',prop:'SortedStatus'}]}");
         setEventMetadata("GRID.LOAD","{handler:'E261O2',iparms:[{av:'A149TipCod',fld:'TIPCOD',pic:'',hsh:true}]");
         setEventMetadata("GRID.LOAD",",oparms:[{av:'cmbavGridactions'},{av:'AV56GridActions',fld:'vGRIDACTIONS',pic:'ZZZ9'},{av:'edtTipDsc_Link',ctrl:'TIPDSC',prop:'Link'}]}");
         setEventMetadata("'ADDDYNAMICFILTERS1'","{handler:'E191O2',iparms:[{av:'GRID_nFirstRecordOnPage'},{av:'GRID_nEOF'},{av:'subGrid_Rows',ctrl:'GRID',prop:'Rows'},{av:'cmbavDynamicfiltersselector1'},{av:'AV15DynamicFiltersSelector1',fld:'vDYNAMICFILTERSSELECTOR1',pic:''},{av:'cmbavDynamicfiltersoperator1'},{av:'AV16DynamicFiltersOperator1',fld:'vDYNAMICFILTERSOPERATOR1',pic:'ZZZ9'},{av:'AV17TipDsc1',fld:'vTIPDSC1',pic:''},{av:'AV66TipAbr1',fld:'vTIPABR1',pic:''},{av:'cmbavDynamicfiltersselector2'},{av:'AV19DynamicFiltersSelector2',fld:'vDYNAMICFILTERSSELECTOR2',pic:''},{av:'cmbavDynamicfiltersoperator2'},{av:'AV20DynamicFiltersOperator2',fld:'vDYNAMICFILTERSOPERATOR2',pic:'ZZZ9'},{av:'AV21TipDsc2',fld:'vTIPDSC2',pic:''},{av:'AV67TipAbr2',fld:'vTIPABR2',pic:''},{av:'cmbavDynamicfiltersselector3'},{av:'AV23DynamicFiltersSelector3',fld:'vDYNAMICFILTERSSELECTOR3',pic:''},{av:'cmbavDynamicfiltersoperator3'},{av:'AV24DynamicFiltersOperator3',fld:'vDYNAMICFILTERSOPERATOR3',pic:'ZZZ9'},{av:'AV25TipDsc3',fld:'vTIPDSC3',pic:''},{av:'AV68TipAbr3',fld:'vTIPABR3',pic:''},{av:'AV18DynamicFiltersEnabled2',fld:'vDYNAMICFILTERSENABLED2',pic:''},{av:'AV22DynamicFiltersEnabled3',fld:'vDYNAMICFILTERSENABLED3',pic:''},{av:'AV71Pgmname',fld:'vPGMNAME',pic:'',hsh:true},{av:'AV35TFTipAbr',fld:'vTFTIPABR',pic:''},{av:'AV36TFTipAbr_Sel',fld:'vTFTIPABR_SEL',pic:''},{av:'AV33TFTipDsc',fld:'vTFTIPDSC',pic:''},{av:'AV34TFTipDsc_Sel',fld:'vTFTIPDSC_SEL',pic:''},{av:'AV59TFTipVta_Sel',fld:'vTFTIPVTA_SEL',pic:'9'},{av:'AV60TFTipCmp_Sel',fld:'vTFTIPCMP_SEL',pic:'9'},{av:'AV61TFTipRHo_Sel',fld:'vTFTIPRHO_SEL',pic:'9'},{av:'AV62TFTipCxP_Sel',fld:'vTFTIPCXP_SEL',pic:'9'},{av:'AV63TFTipBan_Sel',fld:'vTFTIPBAN_SEL',pic:'9'},{av:'AV65TFTipSts_Sels',fld:'vTFTIPSTS_SELS',pic:''},{av:'AV13OrderedBy',fld:'vORDEREDBY',pic:'ZZZ9'},{av:'AV14OrderedDsc',fld:'vORDEREDDSC',pic:''},{av:'AV10GridState',fld:'vGRIDSTATE',pic:''},{av:'AV27DynamicFiltersIgnoreFirst',fld:'vDYNAMICFILTERSIGNOREFIRST',pic:''},{av:'AV26DynamicFiltersRemoving',fld:'vDYNAMICFILTERSREMOVING',pic:''}]");
         setEventMetadata("'ADDDYNAMICFILTERS1'",",oparms:[{av:'AV18DynamicFiltersEnabled2',fld:'vDYNAMICFILTERSENABLED2',pic:''},{av:'imgAdddynamicfilters1_Visible',ctrl:'ADDDYNAMICFILTERS1',prop:'Visible'},{av:'imgRemovedynamicfilters1_Visible',ctrl:'REMOVEDYNAMICFILTERS1',prop:'Visible'},{av:'cmbavDynamicfiltersoperator1'},{av:'AV16DynamicFiltersOperator1',fld:'vDYNAMICFILTERSOPERATOR1',pic:'ZZZ9'},{av:'cmbavDynamicfiltersoperator2'},{av:'AV20DynamicFiltersOperator2',fld:'vDYNAMICFILTERSOPERATOR2',pic:'ZZZ9'},{av:'cmbavDynamicfiltersoperator3'},{av:'AV24DynamicFiltersOperator3',fld:'vDYNAMICFILTERSOPERATOR3',pic:'ZZZ9'},{av:'AV53GridCurrentPage',fld:'vGRIDCURRENTPAGE',pic:'ZZZZZZZZZ9'},{av:'AV54GridPageCount',fld:'vGRIDPAGECOUNT',pic:'ZZZZZZZZZ9'},{av:'AV55GridAppliedFilters',fld:'vGRIDAPPLIEDFILTERS',pic:''},{av:'AV10GridState',fld:'vGRIDSTATE',pic:''}]}");
         setEventMetadata("'REMOVEDYNAMICFILTERS1'","{handler:'E151O2',iparms:[{av:'GRID_nFirstRecordOnPage'},{av:'GRID_nEOF'},{av:'subGrid_Rows',ctrl:'GRID',prop:'Rows'},{av:'cmbavDynamicfiltersselector1'},{av:'AV15DynamicFiltersSelector1',fld:'vDYNAMICFILTERSSELECTOR1',pic:''},{av:'cmbavDynamicfiltersoperator1'},{av:'AV16DynamicFiltersOperator1',fld:'vDYNAMICFILTERSOPERATOR1',pic:'ZZZ9'},{av:'AV17TipDsc1',fld:'vTIPDSC1',pic:''},{av:'AV66TipAbr1',fld:'vTIPABR1',pic:''},{av:'cmbavDynamicfiltersselector2'},{av:'AV19DynamicFiltersSelector2',fld:'vDYNAMICFILTERSSELECTOR2',pic:''},{av:'cmbavDynamicfiltersoperator2'},{av:'AV20DynamicFiltersOperator2',fld:'vDYNAMICFILTERSOPERATOR2',pic:'ZZZ9'},{av:'AV21TipDsc2',fld:'vTIPDSC2',pic:''},{av:'AV67TipAbr2',fld:'vTIPABR2',pic:''},{av:'cmbavDynamicfiltersselector3'},{av:'AV23DynamicFiltersSelector3',fld:'vDYNAMICFILTERSSELECTOR3',pic:''},{av:'cmbavDynamicfiltersoperator3'},{av:'AV24DynamicFiltersOperator3',fld:'vDYNAMICFILTERSOPERATOR3',pic:'ZZZ9'},{av:'AV25TipDsc3',fld:'vTIPDSC3',pic:''},{av:'AV68TipAbr3',fld:'vTIPABR3',pic:''},{av:'AV18DynamicFiltersEnabled2',fld:'vDYNAMICFILTERSENABLED2',pic:''},{av:'AV22DynamicFiltersEnabled3',fld:'vDYNAMICFILTERSENABLED3',pic:''},{av:'AV71Pgmname',fld:'vPGMNAME',pic:'',hsh:true},{av:'AV35TFTipAbr',fld:'vTFTIPABR',pic:''},{av:'AV36TFTipAbr_Sel',fld:'vTFTIPABR_SEL',pic:''},{av:'AV33TFTipDsc',fld:'vTFTIPDSC',pic:''},{av:'AV34TFTipDsc_Sel',fld:'vTFTIPDSC_SEL',pic:''},{av:'AV59TFTipVta_Sel',fld:'vTFTIPVTA_SEL',pic:'9'},{av:'AV60TFTipCmp_Sel',fld:'vTFTIPCMP_SEL',pic:'9'},{av:'AV61TFTipRHo_Sel',fld:'vTFTIPRHO_SEL',pic:'9'},{av:'AV62TFTipCxP_Sel',fld:'vTFTIPCXP_SEL',pic:'9'},{av:'AV63TFTipBan_Sel',fld:'vTFTIPBAN_SEL',pic:'9'},{av:'AV65TFTipSts_Sels',fld:'vTFTIPSTS_SELS',pic:''},{av:'AV13OrderedBy',fld:'vORDEREDBY',pic:'ZZZ9'},{av:'AV14OrderedDsc',fld:'vORDEREDDSC',pic:''},{av:'AV10GridState',fld:'vGRIDSTATE',pic:''},{av:'AV27DynamicFiltersIgnoreFirst',fld:'vDYNAMICFILTERSIGNOREFIRST',pic:''},{av:'AV26DynamicFiltersRemoving',fld:'vDYNAMICFILTERSREMOVING',pic:''}]");
         setEventMetadata("'REMOVEDYNAMICFILTERS1'",",oparms:[{av:'AV26DynamicFiltersRemoving',fld:'vDYNAMICFILTERSREMOVING',pic:''},{av:'AV27DynamicFiltersIgnoreFirst',fld:'vDYNAMICFILTERSIGNOREFIRST',pic:''},{av:'AV10GridState',fld:'vGRIDSTATE',pic:''},{av:'AV18DynamicFiltersEnabled2',fld:'vDYNAMICFILTERSENABLED2',pic:''},{av:'cmbavDynamicfiltersselector2'},{av:'AV19DynamicFiltersSelector2',fld:'vDYNAMICFILTERSSELECTOR2',pic:''},{av:'cmbavDynamicfiltersoperator2'},{av:'AV20DynamicFiltersOperator2',fld:'vDYNAMICFILTERSOPERATOR2',pic:'ZZZ9'},{av:'AV21TipDsc2',fld:'vTIPDSC2',pic:''},{av:'AV22DynamicFiltersEnabled3',fld:'vDYNAMICFILTERSENABLED3',pic:''},{av:'cmbavDynamicfiltersselector3'},{av:'AV23DynamicFiltersSelector3',fld:'vDYNAMICFILTERSSELECTOR3',pic:''},{av:'cmbavDynamicfiltersoperator3'},{av:'AV24DynamicFiltersOperator3',fld:'vDYNAMICFILTERSOPERATOR3',pic:'ZZZ9'},{av:'AV25TipDsc3',fld:'vTIPDSC3',pic:''},{av:'imgAdddynamicfilters1_Visible',ctrl:'ADDDYNAMICFILTERS1',prop:'Visible'},{av:'imgRemovedynamicfilters1_Visible',ctrl:'REMOVEDYNAMICFILTERS1',prop:'Visible'},{av:'imgAdddynamicfilters2_Visible',ctrl:'ADDDYNAMICFILTERS2',prop:'Visible'},{av:'imgRemovedynamicfilters2_Visible',ctrl:'REMOVEDYNAMICFILTERS2',prop:'Visible'},{av:'cmbavDynamicfiltersselector1'},{av:'AV15DynamicFiltersSelector1',fld:'vDYNAMICFILTERSSELECTOR1',pic:''},{av:'cmbavDynamicfiltersoperator1'},{av:'AV16DynamicFiltersOperator1',fld:'vDYNAMICFILTERSOPERATOR1',pic:'ZZZ9'},{av:'AV17TipDsc1',fld:'vTIPDSC1',pic:''},{av:'AV66TipAbr1',fld:'vTIPABR1',pic:''},{av:'lblJsdynamicfilters_Caption',ctrl:'JSDYNAMICFILTERS',prop:'Caption'},{av:'AV67TipAbr2',fld:'vTIPABR2',pic:''},{av:'AV68TipAbr3',fld:'vTIPABR3',pic:''},{av:'edtavTipdsc2_Visible',ctrl:'vTIPDSC2',prop:'Visible'},{av:'edtavTipabr2_Visible',ctrl:'vTIPABR2',prop:'Visible'},{av:'edtavTipdsc3_Visible',ctrl:'vTIPDSC3',prop:'Visible'},{av:'edtavTipabr3_Visible',ctrl:'vTIPABR3',prop:'Visible'},{av:'edtavTipdsc1_Visible',ctrl:'vTIPDSC1',prop:'Visible'},{av:'edtavTipabr1_Visible',ctrl:'vTIPABR1',prop:'Visible'},{av:'AV53GridCurrentPage',fld:'vGRIDCURRENTPAGE',pic:'ZZZZZZZZZ9'},{av:'AV54GridPageCount',fld:'vGRIDPAGECOUNT',pic:'ZZZZZZZZZ9'},{av:'AV55GridAppliedFilters',fld:'vGRIDAPPLIEDFILTERS',pic:''}]}");
         setEventMetadata("VDYNAMICFILTERSSELECTOR1.CLICK","{handler:'E201O2',iparms:[{av:'cmbavDynamicfiltersselector1'},{av:'AV15DynamicFiltersSelector1',fld:'vDYNAMICFILTERSSELECTOR1',pic:''}]");
         setEventMetadata("VDYNAMICFILTERSSELECTOR1.CLICK",",oparms:[{av:'cmbavDynamicfiltersoperator1'},{av:'AV16DynamicFiltersOperator1',fld:'vDYNAMICFILTERSOPERATOR1',pic:'ZZZ9'},{av:'edtavTipdsc1_Visible',ctrl:'vTIPDSC1',prop:'Visible'},{av:'edtavTipabr1_Visible',ctrl:'vTIPABR1',prop:'Visible'}]}");
         setEventMetadata("'ADDDYNAMICFILTERS2'","{handler:'E211O2',iparms:[{av:'GRID_nFirstRecordOnPage'},{av:'GRID_nEOF'},{av:'subGrid_Rows',ctrl:'GRID',prop:'Rows'},{av:'cmbavDynamicfiltersselector1'},{av:'AV15DynamicFiltersSelector1',fld:'vDYNAMICFILTERSSELECTOR1',pic:''},{av:'cmbavDynamicfiltersoperator1'},{av:'AV16DynamicFiltersOperator1',fld:'vDYNAMICFILTERSOPERATOR1',pic:'ZZZ9'},{av:'AV17TipDsc1',fld:'vTIPDSC1',pic:''},{av:'AV66TipAbr1',fld:'vTIPABR1',pic:''},{av:'cmbavDynamicfiltersselector2'},{av:'AV19DynamicFiltersSelector2',fld:'vDYNAMICFILTERSSELECTOR2',pic:''},{av:'cmbavDynamicfiltersoperator2'},{av:'AV20DynamicFiltersOperator2',fld:'vDYNAMICFILTERSOPERATOR2',pic:'ZZZ9'},{av:'AV21TipDsc2',fld:'vTIPDSC2',pic:''},{av:'AV67TipAbr2',fld:'vTIPABR2',pic:''},{av:'cmbavDynamicfiltersselector3'},{av:'AV23DynamicFiltersSelector3',fld:'vDYNAMICFILTERSSELECTOR3',pic:''},{av:'cmbavDynamicfiltersoperator3'},{av:'AV24DynamicFiltersOperator3',fld:'vDYNAMICFILTERSOPERATOR3',pic:'ZZZ9'},{av:'AV25TipDsc3',fld:'vTIPDSC3',pic:''},{av:'AV68TipAbr3',fld:'vTIPABR3',pic:''},{av:'AV18DynamicFiltersEnabled2',fld:'vDYNAMICFILTERSENABLED2',pic:''},{av:'AV22DynamicFiltersEnabled3',fld:'vDYNAMICFILTERSENABLED3',pic:''},{av:'AV71Pgmname',fld:'vPGMNAME',pic:'',hsh:true},{av:'AV35TFTipAbr',fld:'vTFTIPABR',pic:''},{av:'AV36TFTipAbr_Sel',fld:'vTFTIPABR_SEL',pic:''},{av:'AV33TFTipDsc',fld:'vTFTIPDSC',pic:''},{av:'AV34TFTipDsc_Sel',fld:'vTFTIPDSC_SEL',pic:''},{av:'AV59TFTipVta_Sel',fld:'vTFTIPVTA_SEL',pic:'9'},{av:'AV60TFTipCmp_Sel',fld:'vTFTIPCMP_SEL',pic:'9'},{av:'AV61TFTipRHo_Sel',fld:'vTFTIPRHO_SEL',pic:'9'},{av:'AV62TFTipCxP_Sel',fld:'vTFTIPCXP_SEL',pic:'9'},{av:'AV63TFTipBan_Sel',fld:'vTFTIPBAN_SEL',pic:'9'},{av:'AV65TFTipSts_Sels',fld:'vTFTIPSTS_SELS',pic:''},{av:'AV13OrderedBy',fld:'vORDEREDBY',pic:'ZZZ9'},{av:'AV14OrderedDsc',fld:'vORDEREDDSC',pic:''},{av:'AV10GridState',fld:'vGRIDSTATE',pic:''},{av:'AV27DynamicFiltersIgnoreFirst',fld:'vDYNAMICFILTERSIGNOREFIRST',pic:''},{av:'AV26DynamicFiltersRemoving',fld:'vDYNAMICFILTERSREMOVING',pic:''}]");
         setEventMetadata("'ADDDYNAMICFILTERS2'",",oparms:[{av:'AV22DynamicFiltersEnabled3',fld:'vDYNAMICFILTERSENABLED3',pic:''},{av:'imgAdddynamicfilters2_Visible',ctrl:'ADDDYNAMICFILTERS2',prop:'Visible'},{av:'imgRemovedynamicfilters2_Visible',ctrl:'REMOVEDYNAMICFILTERS2',prop:'Visible'},{av:'cmbavDynamicfiltersoperator1'},{av:'AV16DynamicFiltersOperator1',fld:'vDYNAMICFILTERSOPERATOR1',pic:'ZZZ9'},{av:'cmbavDynamicfiltersoperator2'},{av:'AV20DynamicFiltersOperator2',fld:'vDYNAMICFILTERSOPERATOR2',pic:'ZZZ9'},{av:'cmbavDynamicfiltersoperator3'},{av:'AV24DynamicFiltersOperator3',fld:'vDYNAMICFILTERSOPERATOR3',pic:'ZZZ9'},{av:'AV53GridCurrentPage',fld:'vGRIDCURRENTPAGE',pic:'ZZZZZZZZZ9'},{av:'AV54GridPageCount',fld:'vGRIDPAGECOUNT',pic:'ZZZZZZZZZ9'},{av:'AV55GridAppliedFilters',fld:'vGRIDAPPLIEDFILTERS',pic:''},{av:'AV10GridState',fld:'vGRIDSTATE',pic:''}]}");
         setEventMetadata("'REMOVEDYNAMICFILTERS2'","{handler:'E161O2',iparms:[{av:'GRID_nFirstRecordOnPage'},{av:'GRID_nEOF'},{av:'subGrid_Rows',ctrl:'GRID',prop:'Rows'},{av:'cmbavDynamicfiltersselector1'},{av:'AV15DynamicFiltersSelector1',fld:'vDYNAMICFILTERSSELECTOR1',pic:''},{av:'cmbavDynamicfiltersoperator1'},{av:'AV16DynamicFiltersOperator1',fld:'vDYNAMICFILTERSOPERATOR1',pic:'ZZZ9'},{av:'AV17TipDsc1',fld:'vTIPDSC1',pic:''},{av:'AV66TipAbr1',fld:'vTIPABR1',pic:''},{av:'cmbavDynamicfiltersselector2'},{av:'AV19DynamicFiltersSelector2',fld:'vDYNAMICFILTERSSELECTOR2',pic:''},{av:'cmbavDynamicfiltersoperator2'},{av:'AV20DynamicFiltersOperator2',fld:'vDYNAMICFILTERSOPERATOR2',pic:'ZZZ9'},{av:'AV21TipDsc2',fld:'vTIPDSC2',pic:''},{av:'AV67TipAbr2',fld:'vTIPABR2',pic:''},{av:'cmbavDynamicfiltersselector3'},{av:'AV23DynamicFiltersSelector3',fld:'vDYNAMICFILTERSSELECTOR3',pic:''},{av:'cmbavDynamicfiltersoperator3'},{av:'AV24DynamicFiltersOperator3',fld:'vDYNAMICFILTERSOPERATOR3',pic:'ZZZ9'},{av:'AV25TipDsc3',fld:'vTIPDSC3',pic:''},{av:'AV68TipAbr3',fld:'vTIPABR3',pic:''},{av:'AV18DynamicFiltersEnabled2',fld:'vDYNAMICFILTERSENABLED2',pic:''},{av:'AV22DynamicFiltersEnabled3',fld:'vDYNAMICFILTERSENABLED3',pic:''},{av:'AV71Pgmname',fld:'vPGMNAME',pic:'',hsh:true},{av:'AV35TFTipAbr',fld:'vTFTIPABR',pic:''},{av:'AV36TFTipAbr_Sel',fld:'vTFTIPABR_SEL',pic:''},{av:'AV33TFTipDsc',fld:'vTFTIPDSC',pic:''},{av:'AV34TFTipDsc_Sel',fld:'vTFTIPDSC_SEL',pic:''},{av:'AV59TFTipVta_Sel',fld:'vTFTIPVTA_SEL',pic:'9'},{av:'AV60TFTipCmp_Sel',fld:'vTFTIPCMP_SEL',pic:'9'},{av:'AV61TFTipRHo_Sel',fld:'vTFTIPRHO_SEL',pic:'9'},{av:'AV62TFTipCxP_Sel',fld:'vTFTIPCXP_SEL',pic:'9'},{av:'AV63TFTipBan_Sel',fld:'vTFTIPBAN_SEL',pic:'9'},{av:'AV65TFTipSts_Sels',fld:'vTFTIPSTS_SELS',pic:''},{av:'AV13OrderedBy',fld:'vORDEREDBY',pic:'ZZZ9'},{av:'AV14OrderedDsc',fld:'vORDEREDDSC',pic:''},{av:'AV10GridState',fld:'vGRIDSTATE',pic:''},{av:'AV27DynamicFiltersIgnoreFirst',fld:'vDYNAMICFILTERSIGNOREFIRST',pic:''},{av:'AV26DynamicFiltersRemoving',fld:'vDYNAMICFILTERSREMOVING',pic:''}]");
         setEventMetadata("'REMOVEDYNAMICFILTERS2'",",oparms:[{av:'AV26DynamicFiltersRemoving',fld:'vDYNAMICFILTERSREMOVING',pic:''},{av:'AV18DynamicFiltersEnabled2',fld:'vDYNAMICFILTERSENABLED2',pic:''},{av:'AV10GridState',fld:'vGRIDSTATE',pic:''},{av:'cmbavDynamicfiltersselector2'},{av:'AV19DynamicFiltersSelector2',fld:'vDYNAMICFILTERSSELECTOR2',pic:''},{av:'cmbavDynamicfiltersoperator2'},{av:'AV20DynamicFiltersOperator2',fld:'vDYNAMICFILTERSOPERATOR2',pic:'ZZZ9'},{av:'AV21TipDsc2',fld:'vTIPDSC2',pic:''},{av:'AV22DynamicFiltersEnabled3',fld:'vDYNAMICFILTERSENABLED3',pic:''},{av:'cmbavDynamicfiltersselector3'},{av:'AV23DynamicFiltersSelector3',fld:'vDYNAMICFILTERSSELECTOR3',pic:''},{av:'cmbavDynamicfiltersoperator3'},{av:'AV24DynamicFiltersOperator3',fld:'vDYNAMICFILTERSOPERATOR3',pic:'ZZZ9'},{av:'AV25TipDsc3',fld:'vTIPDSC3',pic:''},{av:'imgAdddynamicfilters1_Visible',ctrl:'ADDDYNAMICFILTERS1',prop:'Visible'},{av:'imgRemovedynamicfilters1_Visible',ctrl:'REMOVEDYNAMICFILTERS1',prop:'Visible'},{av:'imgAdddynamicfilters2_Visible',ctrl:'ADDDYNAMICFILTERS2',prop:'Visible'},{av:'imgRemovedynamicfilters2_Visible',ctrl:'REMOVEDYNAMICFILTERS2',prop:'Visible'},{av:'cmbavDynamicfiltersselector1'},{av:'AV15DynamicFiltersSelector1',fld:'vDYNAMICFILTERSSELECTOR1',pic:''},{av:'cmbavDynamicfiltersoperator1'},{av:'AV16DynamicFiltersOperator1',fld:'vDYNAMICFILTERSOPERATOR1',pic:'ZZZ9'},{av:'AV17TipDsc1',fld:'vTIPDSC1',pic:''},{av:'AV66TipAbr1',fld:'vTIPABR1',pic:''},{av:'lblJsdynamicfilters_Caption',ctrl:'JSDYNAMICFILTERS',prop:'Caption'},{av:'AV67TipAbr2',fld:'vTIPABR2',pic:''},{av:'AV68TipAbr3',fld:'vTIPABR3',pic:''},{av:'edtavTipdsc2_Visible',ctrl:'vTIPDSC2',prop:'Visible'},{av:'edtavTipabr2_Visible',ctrl:'vTIPABR2',prop:'Visible'},{av:'edtavTipdsc3_Visible',ctrl:'vTIPDSC3',prop:'Visible'},{av:'edtavTipabr3_Visible',ctrl:'vTIPABR3',prop:'Visible'},{av:'edtavTipdsc1_Visible',ctrl:'vTIPDSC1',prop:'Visible'},{av:'edtavTipabr1_Visible',ctrl:'vTIPABR1',prop:'Visible'},{av:'AV53GridCurrentPage',fld:'vGRIDCURRENTPAGE',pic:'ZZZZZZZZZ9'},{av:'AV54GridPageCount',fld:'vGRIDPAGECOUNT',pic:'ZZZZZZZZZ9'},{av:'AV55GridAppliedFilters',fld:'vGRIDAPPLIEDFILTERS',pic:''}]}");
         setEventMetadata("VDYNAMICFILTERSSELECTOR2.CLICK","{handler:'E221O2',iparms:[{av:'cmbavDynamicfiltersselector2'},{av:'AV19DynamicFiltersSelector2',fld:'vDYNAMICFILTERSSELECTOR2',pic:''}]");
         setEventMetadata("VDYNAMICFILTERSSELECTOR2.CLICK",",oparms:[{av:'cmbavDynamicfiltersoperator2'},{av:'AV20DynamicFiltersOperator2',fld:'vDYNAMICFILTERSOPERATOR2',pic:'ZZZ9'},{av:'edtavTipdsc2_Visible',ctrl:'vTIPDSC2',prop:'Visible'},{av:'edtavTipabr2_Visible',ctrl:'vTIPABR2',prop:'Visible'}]}");
         setEventMetadata("'REMOVEDYNAMICFILTERS3'","{handler:'E171O2',iparms:[{av:'GRID_nFirstRecordOnPage'},{av:'GRID_nEOF'},{av:'subGrid_Rows',ctrl:'GRID',prop:'Rows'},{av:'cmbavDynamicfiltersselector1'},{av:'AV15DynamicFiltersSelector1',fld:'vDYNAMICFILTERSSELECTOR1',pic:''},{av:'cmbavDynamicfiltersoperator1'},{av:'AV16DynamicFiltersOperator1',fld:'vDYNAMICFILTERSOPERATOR1',pic:'ZZZ9'},{av:'AV17TipDsc1',fld:'vTIPDSC1',pic:''},{av:'AV66TipAbr1',fld:'vTIPABR1',pic:''},{av:'cmbavDynamicfiltersselector2'},{av:'AV19DynamicFiltersSelector2',fld:'vDYNAMICFILTERSSELECTOR2',pic:''},{av:'cmbavDynamicfiltersoperator2'},{av:'AV20DynamicFiltersOperator2',fld:'vDYNAMICFILTERSOPERATOR2',pic:'ZZZ9'},{av:'AV21TipDsc2',fld:'vTIPDSC2',pic:''},{av:'AV67TipAbr2',fld:'vTIPABR2',pic:''},{av:'cmbavDynamicfiltersselector3'},{av:'AV23DynamicFiltersSelector3',fld:'vDYNAMICFILTERSSELECTOR3',pic:''},{av:'cmbavDynamicfiltersoperator3'},{av:'AV24DynamicFiltersOperator3',fld:'vDYNAMICFILTERSOPERATOR3',pic:'ZZZ9'},{av:'AV25TipDsc3',fld:'vTIPDSC3',pic:''},{av:'AV68TipAbr3',fld:'vTIPABR3',pic:''},{av:'AV18DynamicFiltersEnabled2',fld:'vDYNAMICFILTERSENABLED2',pic:''},{av:'AV22DynamicFiltersEnabled3',fld:'vDYNAMICFILTERSENABLED3',pic:''},{av:'AV71Pgmname',fld:'vPGMNAME',pic:'',hsh:true},{av:'AV35TFTipAbr',fld:'vTFTIPABR',pic:''},{av:'AV36TFTipAbr_Sel',fld:'vTFTIPABR_SEL',pic:''},{av:'AV33TFTipDsc',fld:'vTFTIPDSC',pic:''},{av:'AV34TFTipDsc_Sel',fld:'vTFTIPDSC_SEL',pic:''},{av:'AV59TFTipVta_Sel',fld:'vTFTIPVTA_SEL',pic:'9'},{av:'AV60TFTipCmp_Sel',fld:'vTFTIPCMP_SEL',pic:'9'},{av:'AV61TFTipRHo_Sel',fld:'vTFTIPRHO_SEL',pic:'9'},{av:'AV62TFTipCxP_Sel',fld:'vTFTIPCXP_SEL',pic:'9'},{av:'AV63TFTipBan_Sel',fld:'vTFTIPBAN_SEL',pic:'9'},{av:'AV65TFTipSts_Sels',fld:'vTFTIPSTS_SELS',pic:''},{av:'AV13OrderedBy',fld:'vORDEREDBY',pic:'ZZZ9'},{av:'AV14OrderedDsc',fld:'vORDEREDDSC',pic:''},{av:'AV10GridState',fld:'vGRIDSTATE',pic:''},{av:'AV27DynamicFiltersIgnoreFirst',fld:'vDYNAMICFILTERSIGNOREFIRST',pic:''},{av:'AV26DynamicFiltersRemoving',fld:'vDYNAMICFILTERSREMOVING',pic:''}]");
         setEventMetadata("'REMOVEDYNAMICFILTERS3'",",oparms:[{av:'AV26DynamicFiltersRemoving',fld:'vDYNAMICFILTERSREMOVING',pic:''},{av:'AV22DynamicFiltersEnabled3',fld:'vDYNAMICFILTERSENABLED3',pic:''},{av:'AV10GridState',fld:'vGRIDSTATE',pic:''},{av:'AV18DynamicFiltersEnabled2',fld:'vDYNAMICFILTERSENABLED2',pic:''},{av:'cmbavDynamicfiltersselector2'},{av:'AV19DynamicFiltersSelector2',fld:'vDYNAMICFILTERSSELECTOR2',pic:''},{av:'cmbavDynamicfiltersoperator2'},{av:'AV20DynamicFiltersOperator2',fld:'vDYNAMICFILTERSOPERATOR2',pic:'ZZZ9'},{av:'AV21TipDsc2',fld:'vTIPDSC2',pic:''},{av:'cmbavDynamicfiltersselector3'},{av:'AV23DynamicFiltersSelector3',fld:'vDYNAMICFILTERSSELECTOR3',pic:''},{av:'cmbavDynamicfiltersoperator3'},{av:'AV24DynamicFiltersOperator3',fld:'vDYNAMICFILTERSOPERATOR3',pic:'ZZZ9'},{av:'AV25TipDsc3',fld:'vTIPDSC3',pic:''},{av:'imgAdddynamicfilters1_Visible',ctrl:'ADDDYNAMICFILTERS1',prop:'Visible'},{av:'imgRemovedynamicfilters1_Visible',ctrl:'REMOVEDYNAMICFILTERS1',prop:'Visible'},{av:'imgAdddynamicfilters2_Visible',ctrl:'ADDDYNAMICFILTERS2',prop:'Visible'},{av:'imgRemovedynamicfilters2_Visible',ctrl:'REMOVEDYNAMICFILTERS2',prop:'Visible'},{av:'cmbavDynamicfiltersselector1'},{av:'AV15DynamicFiltersSelector1',fld:'vDYNAMICFILTERSSELECTOR1',pic:''},{av:'cmbavDynamicfiltersoperator1'},{av:'AV16DynamicFiltersOperator1',fld:'vDYNAMICFILTERSOPERATOR1',pic:'ZZZ9'},{av:'AV17TipDsc1',fld:'vTIPDSC1',pic:''},{av:'AV66TipAbr1',fld:'vTIPABR1',pic:''},{av:'lblJsdynamicfilters_Caption',ctrl:'JSDYNAMICFILTERS',prop:'Caption'},{av:'AV67TipAbr2',fld:'vTIPABR2',pic:''},{av:'AV68TipAbr3',fld:'vTIPABR3',pic:''},{av:'edtavTipdsc2_Visible',ctrl:'vTIPDSC2',prop:'Visible'},{av:'edtavTipabr2_Visible',ctrl:'vTIPABR2',prop:'Visible'},{av:'edtavTipdsc3_Visible',ctrl:'vTIPDSC3',prop:'Visible'},{av:'edtavTipabr3_Visible',ctrl:'vTIPABR3',prop:'Visible'},{av:'edtavTipdsc1_Visible',ctrl:'vTIPDSC1',prop:'Visible'},{av:'edtavTipabr1_Visible',ctrl:'vTIPABR1',prop:'Visible'},{av:'AV53GridCurrentPage',fld:'vGRIDCURRENTPAGE',pic:'ZZZZZZZZZ9'},{av:'AV54GridPageCount',fld:'vGRIDPAGECOUNT',pic:'ZZZZZZZZZ9'},{av:'AV55GridAppliedFilters',fld:'vGRIDAPPLIEDFILTERS',pic:''}]}");
         setEventMetadata("VDYNAMICFILTERSSELECTOR3.CLICK","{handler:'E231O2',iparms:[{av:'cmbavDynamicfiltersselector3'},{av:'AV23DynamicFiltersSelector3',fld:'vDYNAMICFILTERSSELECTOR3',pic:''}]");
         setEventMetadata("VDYNAMICFILTERSSELECTOR3.CLICK",",oparms:[{av:'cmbavDynamicfiltersoperator3'},{av:'AV24DynamicFiltersOperator3',fld:'vDYNAMICFILTERSOPERATOR3',pic:'ZZZ9'},{av:'edtavTipdsc3_Visible',ctrl:'vTIPDSC3',prop:'Visible'},{av:'edtavTipabr3_Visible',ctrl:'vTIPABR3',prop:'Visible'}]}");
         setEventMetadata("VGRIDACTIONS.CLICK","{handler:'E271O2',iparms:[{av:'cmbavGridactions'},{av:'AV56GridActions',fld:'vGRIDACTIONS',pic:'ZZZ9'},{av:'A149TipCod',fld:'TIPCOD',pic:'',hsh:true}]");
         setEventMetadata("VGRIDACTIONS.CLICK",",oparms:[{av:'cmbavGridactions'},{av:'AV56GridActions',fld:'vGRIDACTIONS',pic:'ZZZ9'}]}");
         setEventMetadata("'DOINSERT'","{handler:'E181O2',iparms:[{av:'A149TipCod',fld:'TIPCOD',pic:'',hsh:true}]");
         setEventMetadata("'DOINSERT'",",oparms:[]}");
         setEventMetadata("DDO_AGEXPORT.ONOPTIONCLICKED","{handler:'E131O2',iparms:[{av:'Ddo_agexport_Activeeventkey',ctrl:'DDO_AGEXPORT',prop:'ActiveEventKey'},{av:'AV71Pgmname',fld:'vPGMNAME',pic:'',hsh:true},{av:'AV65TFTipSts_Sels',fld:'vTFTIPSTS_SELS',pic:''},{av:'AV36TFTipAbr_Sel',fld:'vTFTIPABR_SEL',pic:''},{av:'AV34TFTipDsc_Sel',fld:'vTFTIPDSC_SEL',pic:''},{av:'AV59TFTipVta_Sel',fld:'vTFTIPVTA_SEL',pic:'9'},{av:'AV60TFTipCmp_Sel',fld:'vTFTIPCMP_SEL',pic:'9'},{av:'AV61TFTipRHo_Sel',fld:'vTFTIPRHO_SEL',pic:'9'},{av:'AV62TFTipCxP_Sel',fld:'vTFTIPCXP_SEL',pic:'9'},{av:'AV63TFTipBan_Sel',fld:'vTFTIPBAN_SEL',pic:'9'},{av:'AV64TFTipSts_SelsJson',fld:'vTFTIPSTS_SELSJSON',pic:''},{av:'AV35TFTipAbr',fld:'vTFTIPABR',pic:''},{av:'AV33TFTipDsc',fld:'vTFTIPDSC',pic:''},{av:'AV13OrderedBy',fld:'vORDEREDBY',pic:'ZZZ9'},{av:'AV14OrderedDsc',fld:'vORDEREDDSC',pic:''},{av:'AV10GridState',fld:'vGRIDSTATE',pic:''},{av:'AV26DynamicFiltersRemoving',fld:'vDYNAMICFILTERSREMOVING',pic:''},{av:'cmbavDynamicfiltersselector1'},{av:'AV15DynamicFiltersSelector1',fld:'vDYNAMICFILTERSSELECTOR1',pic:''},{av:'cmbavDynamicfiltersselector2'},{av:'AV19DynamicFiltersSelector2',fld:'vDYNAMICFILTERSSELECTOR2',pic:''},{av:'cmbavDynamicfiltersselector3'},{av:'AV23DynamicFiltersSelector3',fld:'vDYNAMICFILTERSSELECTOR3',pic:''}]");
         setEventMetadata("DDO_AGEXPORT.ONOPTIONCLICKED",",oparms:[{av:'Innewwindow1_Target',ctrl:'INNEWWINDOW1',prop:'Target'},{av:'Innewwindow1_Height',ctrl:'INNEWWINDOW1',prop:'Height'},{av:'Innewwindow1_Width',ctrl:'INNEWWINDOW1',prop:'Width'},{av:'AV10GridState',fld:'vGRIDSTATE',pic:''},{av:'AV13OrderedBy',fld:'vORDEREDBY',pic:'ZZZ9'},{av:'AV14OrderedDsc',fld:'vORDEREDDSC',pic:''},{av:'AV64TFTipSts_SelsJson',fld:'vTFTIPSTS_SELSJSON',pic:''},{av:'AV65TFTipSts_Sels',fld:'vTFTIPSTS_SELS',pic:''},{av:'AV63TFTipBan_Sel',fld:'vTFTIPBAN_SEL',pic:'9'},{av:'AV62TFTipCxP_Sel',fld:'vTFTIPCXP_SEL',pic:'9'},{av:'AV61TFTipRHo_Sel',fld:'vTFTIPRHO_SEL',pic:'9'},{av:'AV60TFTipCmp_Sel',fld:'vTFTIPCMP_SEL',pic:'9'},{av:'AV59TFTipVta_Sel',fld:'vTFTIPVTA_SEL',pic:'9'},{av:'AV34TFTipDsc_Sel',fld:'vTFTIPDSC_SEL',pic:''},{av:'AV33TFTipDsc',fld:'vTFTIPDSC',pic:''},{av:'AV36TFTipAbr_Sel',fld:'vTFTIPABR_SEL',pic:''},{av:'AV35TFTipAbr',fld:'vTFTIPABR',pic:''},{av:'Ddo_grid_Selectedvalue_set',ctrl:'DDO_GRID',prop:'SelectedValue_set'},{av:'Ddo_grid_Filteredtext_set',ctrl:'DDO_GRID',prop:'FilteredText_set'},{av:'subGrid_Rows',ctrl:'GRID',prop:'Rows'},{av:'GRID_nFirstRecordOnPage'},{av:'GRID_nEOF'},{av:'cmbavDynamicfiltersselector1'},{av:'AV15DynamicFiltersSelector1',fld:'vDYNAMICFILTERSSELECTOR1',pic:''},{av:'cmbavDynamicfiltersoperator1'},{av:'AV16DynamicFiltersOperator1',fld:'vDYNAMICFILTERSOPERATOR1',pic:'ZZZ9'},{av:'AV17TipDsc1',fld:'vTIPDSC1',pic:''},{av:'AV66TipAbr1',fld:'vTIPABR1',pic:''},{av:'cmbavDynamicfiltersselector2'},{av:'AV19DynamicFiltersSelector2',fld:'vDYNAMICFILTERSSELECTOR2',pic:''},{av:'cmbavDynamicfiltersoperator2'},{av:'AV20DynamicFiltersOperator2',fld:'vDYNAMICFILTERSOPERATOR2',pic:'ZZZ9'},{av:'AV21TipDsc2',fld:'vTIPDSC2',pic:''},{av:'AV67TipAbr2',fld:'vTIPABR2',pic:''},{av:'cmbavDynamicfiltersselector3'},{av:'AV23DynamicFiltersSelector3',fld:'vDYNAMICFILTERSSELECTOR3',pic:''},{av:'cmbavDynamicfiltersoperator3'},{av:'AV24DynamicFiltersOperator3',fld:'vDYNAMICFILTERSOPERATOR3',pic:'ZZZ9'},{av:'AV25TipDsc3',fld:'vTIPDSC3',pic:''},{av:'AV68TipAbr3',fld:'vTIPABR3',pic:''},{av:'AV18DynamicFiltersEnabled2',fld:'vDYNAMICFILTERSENABLED2',pic:''},{av:'AV22DynamicFiltersEnabled3',fld:'vDYNAMICFILTERSENABLED3',pic:''},{av:'AV71Pgmname',fld:'vPGMNAME',pic:'',hsh:true},{av:'AV27DynamicFiltersIgnoreFirst',fld:'vDYNAMICFILTERSIGNOREFIRST',pic:''},{av:'AV26DynamicFiltersRemoving',fld:'vDYNAMICFILTERSREMOVING',pic:''},{av:'Ddo_grid_Sortedstatus',ctrl:'DDO_GRID',prop:'SortedStatus'},{av:'imgAdddynamicfilters1_Visible',ctrl:'ADDDYNAMICFILTERS1',prop:'Visible'},{av:'imgRemovedynamicfilters1_Visible',ctrl:'REMOVEDYNAMICFILTERS1',prop:'Visible'},{av:'imgAdddynamicfilters2_Visible',ctrl:'ADDDYNAMICFILTERS2',prop:'Visible'},{av:'imgRemovedynamicfilters2_Visible',ctrl:'REMOVEDYNAMICFILTERS2',prop:'Visible'},{av:'lblJsdynamicfilters_Caption',ctrl:'JSDYNAMICFILTERS',prop:'Caption'},{av:'edtavTipdsc1_Visible',ctrl:'vTIPDSC1',prop:'Visible'},{av:'edtavTipabr1_Visible',ctrl:'vTIPABR1',prop:'Visible'},{av:'edtavTipdsc2_Visible',ctrl:'vTIPDSC2',prop:'Visible'},{av:'edtavTipabr2_Visible',ctrl:'vTIPABR2',prop:'Visible'},{av:'edtavTipdsc3_Visible',ctrl:'vTIPDSC3',prop:'Visible'},{av:'edtavTipabr3_Visible',ctrl:'vTIPABR3',prop:'Visible'}]}");
         setEventMetadata("NULL","{handler:'Valid_Tipsts',iparms:[]");
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
         Ddo_grid_Filteredtext_get = "";
         Ddo_grid_Selectedcolumn = "";
         Ddo_agexport_Activeeventkey = "";
         gxfirstwebparm = "";
         gxfirstwebparm_bkp = "";
         AV15DynamicFiltersSelector1 = "";
         AV17TipDsc1 = "";
         AV66TipAbr1 = "";
         AV19DynamicFiltersSelector2 = "";
         AV21TipDsc2 = "";
         AV67TipAbr2 = "";
         AV23DynamicFiltersSelector3 = "";
         AV25TipDsc3 = "";
         AV68TipAbr3 = "";
         AV71Pgmname = "";
         AV35TFTipAbr = "";
         AV36TFTipAbr_Sel = "";
         AV33TFTipDsc = "";
         AV34TFTipDsc_Sel = "";
         AV65TFTipSts_Sels = new GxSimpleCollection<short>();
         AV10GridState = new GeneXus.Programs.wwpbaseobjects.SdtWWPGridState(context);
         sDynURL = "";
         FormProcess = "";
         bodyStyle = "";
         GXKey = "";
         AV55GridAppliedFilters = "";
         AV57AGExportData = new GXBaseCollection<GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTDropDownOptionsData_Item>( context, "Item", "");
         AV51DDO_TitleSettingsIcons = new GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTDropDownOptionsTitleSettingsIcons(context);
         AV64TFTipSts_SelsJson = "";
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
         A149TipCod = "";
         A306TipAbr = "";
         A1910TipDsc = "";
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
         AV95Configuracion_tipodocumentowwds_24_tftipsts_sels = new GxSimpleCollection<short>();
         scmdbuf = "";
         lV74Configuracion_tipodocumentowwds_3_tipdsc1 = "";
         lV75Configuracion_tipodocumentowwds_4_tipabr1 = "";
         lV79Configuracion_tipodocumentowwds_8_tipdsc2 = "";
         lV80Configuracion_tipodocumentowwds_9_tipabr2 = "";
         lV84Configuracion_tipodocumentowwds_13_tipdsc3 = "";
         lV85Configuracion_tipodocumentowwds_14_tipabr3 = "";
         lV86Configuracion_tipodocumentowwds_15_tftipabr = "";
         lV88Configuracion_tipodocumentowwds_17_tftipdsc = "";
         AV72Configuracion_tipodocumentowwds_1_dynamicfiltersselector1 = "";
         AV74Configuracion_tipodocumentowwds_3_tipdsc1 = "";
         AV75Configuracion_tipodocumentowwds_4_tipabr1 = "";
         AV77Configuracion_tipodocumentowwds_6_dynamicfiltersselector2 = "";
         AV79Configuracion_tipodocumentowwds_8_tipdsc2 = "";
         AV80Configuracion_tipodocumentowwds_9_tipabr2 = "";
         AV82Configuracion_tipodocumentowwds_11_dynamicfiltersselector3 = "";
         AV84Configuracion_tipodocumentowwds_13_tipdsc3 = "";
         AV85Configuracion_tipodocumentowwds_14_tipabr3 = "";
         AV87Configuracion_tipodocumentowwds_16_tftipabr_sel = "";
         AV86Configuracion_tipodocumentowwds_15_tftipabr = "";
         AV89Configuracion_tipodocumentowwds_18_tftipdsc_sel = "";
         AV88Configuracion_tipodocumentowwds_17_tftipdsc = "";
         H001O2_A1919TipSts = new short[1] ;
         H001O2_A1903TipBan = new short[1] ;
         H001O2_A1909TipCxP = new short[1] ;
         H001O2_A1915TipRHo = new short[1] ;
         H001O2_A1906TipCmp = new short[1] ;
         H001O2_A1921TipVta = new short[1] ;
         H001O2_A1910TipDsc = new string[] {""} ;
         H001O2_A306TipAbr = new string[] {""} ;
         H001O2_A149TipCod = new string[] {""} ;
         H001O3_AGRID_nRecordCount = new long[1] ;
         imgAdddynamicfilters1_Jsonclick = "";
         imgRemovedynamicfilters1_Jsonclick = "";
         imgAdddynamicfilters2_Jsonclick = "";
         imgRemovedynamicfilters2_Jsonclick = "";
         imgRemovedynamicfilters3_Jsonclick = "";
         AV58AGExportDataItem = new GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTDropDownOptionsData_Item(context);
         GXt_SdtDVB_SDTDropDownOptionsTitleSettingsIcons1 = new GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTDropDownOptionsTitleSettingsIcons(context);
         AV6WWPContext = new GeneXus.Programs.wwpbaseobjects.SdtWWPContext(context);
         GXEncryptionTmp = "";
         GridRow = new GXWebRow();
         AV30Session = context.GetSession();
         AV11GridStateFilterValue = new GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue(context);
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
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.configuracion.tipodocumentoww__default(),
            new Object[][] {
                new Object[] {
               H001O2_A1919TipSts, H001O2_A1903TipBan, H001O2_A1909TipCxP, H001O2_A1915TipRHo, H001O2_A1906TipCmp, H001O2_A1921TipVta, H001O2_A1910TipDsc, H001O2_A306TipAbr, H001O2_A149TipCod
               }
               , new Object[] {
               H001O3_AGRID_nRecordCount
               }
            }
         );
         AV71Pgmname = "Configuracion.TipoDocumentoWW";
         /* GeneXus formulas. */
         AV71Pgmname = "Configuracion.TipoDocumentoWW";
         context.Gx_err = 0;
      }

      private short GRID_nEOF ;
      private short nGotPars ;
      private short GxWebError ;
      private short AV16DynamicFiltersOperator1 ;
      private short AV20DynamicFiltersOperator2 ;
      private short AV24DynamicFiltersOperator3 ;
      private short AV59TFTipVta_Sel ;
      private short AV60TFTipCmp_Sel ;
      private short AV61TFTipRHo_Sel ;
      private short AV62TFTipCxP_Sel ;
      private short AV63TFTipBan_Sel ;
      private short AV13OrderedBy ;
      private short initialized ;
      private short gxajaxcallmode ;
      private short wbEnd ;
      private short wbStart ;
      private short subGrid_Backcolorstyle ;
      private short subGrid_Titlebackstyle ;
      private short subGrid_Sortable ;
      private short AV56GridActions ;
      private short A1921TipVta ;
      private short A1906TipCmp ;
      private short A1915TipRHo ;
      private short A1909TipCxP ;
      private short A1903TipBan ;
      private short A1919TipSts ;
      private short subGrid_Allowselection ;
      private short subGrid_Allowhovering ;
      private short subGrid_Allowcollapsing ;
      private short subGrid_Collapsed ;
      private short nDonePA ;
      private short AV73Configuracion_tipodocumentowwds_2_dynamicfiltersoperator1 ;
      private short AV78Configuracion_tipodocumentowwds_7_dynamicfiltersoperator2 ;
      private short AV83Configuracion_tipodocumentowwds_12_dynamicfiltersoperator3 ;
      private short AV90Configuracion_tipodocumentowwds_19_tftipvta_sel ;
      private short AV91Configuracion_tipodocumentowwds_20_tftipcmp_sel ;
      private short AV92Configuracion_tipodocumentowwds_21_tftiprho_sel ;
      private short AV93Configuracion_tipodocumentowwds_22_tftipcxp_sel ;
      private short AV94Configuracion_tipodocumentowwds_23_tftipban_sel ;
      private short nGXWrapped ;
      private short subGrid_Backstyle ;
      private int subGrid_Rows ;
      private int Gridpaginationbar_Rowsperpageselectedvalue ;
      private int nRC_GXsfl_110 ;
      private int nGXsfl_110_idx=1 ;
      private int Gridpaginationbar_Pagestoshow ;
      private int subGrid_Titlebackcolor ;
      private int subGrid_Allbackcolor ;
      private int subGrid_Selectedindex ;
      private int subGrid_Selectioncolor ;
      private int subGrid_Hoveringcolor ;
      private int subGrid_Islastpage ;
      private int GXPagingFrom2 ;
      private int GXPagingTo2 ;
      private int AV95Configuracion_tipodocumentowwds_24_tftipsts_sels_Count ;
      private int AV52PageToGo ;
      private int imgAdddynamicfilters1_Visible ;
      private int imgRemovedynamicfilters1_Visible ;
      private int imgAdddynamicfilters2_Visible ;
      private int imgRemovedynamicfilters2_Visible ;
      private int edtavTipdsc1_Visible ;
      private int edtavTipabr1_Visible ;
      private int edtavTipdsc2_Visible ;
      private int edtavTipabr2_Visible ;
      private int edtavTipdsc3_Visible ;
      private int edtavTipabr3_Visible ;
      private int AV96GXV1 ;
      private int edtavTipdsc3_Enabled ;
      private int edtavTipabr3_Enabled ;
      private int edtavTipdsc2_Enabled ;
      private int edtavTipabr2_Enabled ;
      private int edtavTipdsc1_Enabled ;
      private int edtavTipabr1_Enabled ;
      private int idxLst ;
      private int subGrid_Backcolor ;
      private long GRID_nFirstRecordOnPage ;
      private long AV53GridCurrentPage ;
      private long AV54GridPageCount ;
      private long GRID_nCurrentRecord ;
      private long GRID_nRecordCount ;
      private string Gridpaginationbar_Selectedpage ;
      private string Ddo_grid_Activeeventkey ;
      private string Ddo_grid_Selectedvalue_get ;
      private string Ddo_grid_Filteredtext_get ;
      private string Ddo_grid_Selectedcolumn ;
      private string Ddo_agexport_Activeeventkey ;
      private string gxfirstwebparm ;
      private string gxfirstwebparm_bkp ;
      private string sGXsfl_110_idx="0001" ;
      private string AV17TipDsc1 ;
      private string AV66TipAbr1 ;
      private string AV21TipDsc2 ;
      private string AV67TipAbr2 ;
      private string AV25TipDsc3 ;
      private string AV68TipAbr3 ;
      private string AV71Pgmname ;
      private string AV35TFTipAbr ;
      private string AV36TFTipAbr_Sel ;
      private string AV33TFTipDsc ;
      private string AV34TFTipDsc_Sel ;
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
      private string A149TipCod ;
      private string A306TipAbr ;
      private string A1910TipDsc ;
      private string edtTipDsc_Link ;
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
      private string edtTipCod_Internalname ;
      private string edtTipAbr_Internalname ;
      private string edtTipDsc_Internalname ;
      private string edtTipVta_Internalname ;
      private string edtTipCmp_Internalname ;
      private string edtTipRHo_Internalname ;
      private string chkTipCxP_Internalname ;
      private string chkTipBan_Internalname ;
      private string edtTipSts_Internalname ;
      private string cmbavDynamicfiltersselector1_Internalname ;
      private string cmbavDynamicfiltersoperator1_Internalname ;
      private string cmbavDynamicfiltersselector2_Internalname ;
      private string cmbavDynamicfiltersoperator2_Internalname ;
      private string cmbavDynamicfiltersselector3_Internalname ;
      private string cmbavDynamicfiltersoperator3_Internalname ;
      private string scmdbuf ;
      private string lV74Configuracion_tipodocumentowwds_3_tipdsc1 ;
      private string lV75Configuracion_tipodocumentowwds_4_tipabr1 ;
      private string lV79Configuracion_tipodocumentowwds_8_tipdsc2 ;
      private string lV80Configuracion_tipodocumentowwds_9_tipabr2 ;
      private string lV84Configuracion_tipodocumentowwds_13_tipdsc3 ;
      private string lV85Configuracion_tipodocumentowwds_14_tipabr3 ;
      private string lV86Configuracion_tipodocumentowwds_15_tftipabr ;
      private string lV88Configuracion_tipodocumentowwds_17_tftipdsc ;
      private string AV74Configuracion_tipodocumentowwds_3_tipdsc1 ;
      private string AV75Configuracion_tipodocumentowwds_4_tipabr1 ;
      private string AV79Configuracion_tipodocumentowwds_8_tipdsc2 ;
      private string AV80Configuracion_tipodocumentowwds_9_tipabr2 ;
      private string AV84Configuracion_tipodocumentowwds_13_tipdsc3 ;
      private string AV85Configuracion_tipodocumentowwds_14_tipabr3 ;
      private string AV87Configuracion_tipodocumentowwds_16_tftipabr_sel ;
      private string AV86Configuracion_tipodocumentowwds_15_tftipabr ;
      private string AV89Configuracion_tipodocumentowwds_18_tftipdsc_sel ;
      private string AV88Configuracion_tipodocumentowwds_17_tftipdsc ;
      private string edtavTipdsc1_Internalname ;
      private string edtavTipabr1_Internalname ;
      private string edtavTipdsc2_Internalname ;
      private string edtavTipabr2_Internalname ;
      private string edtavTipdsc3_Internalname ;
      private string edtavTipabr3_Internalname ;
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
      private string cellFilter_tipdsc3_cell_Internalname ;
      private string edtavTipdsc3_Jsonclick ;
      private string cellFilter_tipabr3_cell_Internalname ;
      private string edtavTipabr3_Jsonclick ;
      private string cellDynamicfilters_removefilter3_cell_Internalname ;
      private string sImgUrl ;
      private string tblTablemergeddynamicfilters2_Internalname ;
      private string cmbavDynamicfiltersoperator2_Jsonclick ;
      private string cellFilter_tipdsc2_cell_Internalname ;
      private string edtavTipdsc2_Jsonclick ;
      private string cellFilter_tipabr2_cell_Internalname ;
      private string edtavTipabr2_Jsonclick ;
      private string cellDynamicfilters_addfilter2_cell_Internalname ;
      private string cellDynamicfilters_removefilter2_cell_Internalname ;
      private string tblTablemergeddynamicfilters1_Internalname ;
      private string cmbavDynamicfiltersoperator1_Jsonclick ;
      private string cellFilter_tipdsc1_cell_Internalname ;
      private string edtavTipdsc1_Jsonclick ;
      private string cellFilter_tipabr1_cell_Internalname ;
      private string edtavTipabr1_Jsonclick ;
      private string cellDynamicfilters_addfilter1_cell_Internalname ;
      private string cellDynamicfilters_removefilter1_cell_Internalname ;
      private string sGXsfl_110_fel_idx="0001" ;
      private string GXCCtl ;
      private string cmbavGridactions_Jsonclick ;
      private string ROClassString ;
      private string edtTipCod_Jsonclick ;
      private string edtTipAbr_Jsonclick ;
      private string edtTipDsc_Jsonclick ;
      private string edtTipVta_Jsonclick ;
      private string edtTipCmp_Jsonclick ;
      private string edtTipRHo_Jsonclick ;
      private string edtTipSts_Jsonclick ;
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
      private bool AV76Configuracion_tipodocumentowwds_5_dynamicfiltersenabled2 ;
      private bool AV81Configuracion_tipodocumentowwds_10_dynamicfiltersenabled3 ;
      private bool returnInSub ;
      private bool gx_refresh_fired ;
      private string AV64TFTipSts_SelsJson ;
      private string AV15DynamicFiltersSelector1 ;
      private string AV19DynamicFiltersSelector2 ;
      private string AV23DynamicFiltersSelector3 ;
      private string AV55GridAppliedFilters ;
      private string AV72Configuracion_tipodocumentowwds_1_dynamicfiltersselector1 ;
      private string AV77Configuracion_tipodocumentowwds_6_dynamicfiltersselector2 ;
      private string AV82Configuracion_tipodocumentowwds_11_dynamicfiltersselector3 ;
      private string AV28ExcelFilename ;
      private string AV29ErrorMessage ;
      private GxSimpleCollection<short> AV65TFTipSts_Sels ;
      private GxSimpleCollection<short> AV95Configuracion_tipodocumentowwds_24_tftipsts_sels ;
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
      private GXCheckbox chkTipCxP ;
      private GXCheckbox chkTipBan ;
      private IDataStoreProvider pr_default ;
      private short[] H001O2_A1919TipSts ;
      private short[] H001O2_A1903TipBan ;
      private short[] H001O2_A1909TipCxP ;
      private short[] H001O2_A1915TipRHo ;
      private short[] H001O2_A1906TipCmp ;
      private short[] H001O2_A1921TipVta ;
      private string[] H001O2_A1910TipDsc ;
      private string[] H001O2_A306TipAbr ;
      private string[] H001O2_A149TipCod ;
      private long[] H001O3_AGRID_nRecordCount ;
      private msglist BackMsgLst ;
      private msglist LclMsgLst ;
      private GxHttpRequest AV7HTTPRequest ;
      private GXBaseCollection<GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTDropDownOptionsData_Item> AV57AGExportData ;
      private GXWebForm Form ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPContext AV6WWPContext ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPTransactionContext AV8TrnContext ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPGridState AV10GridState ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue AV11GridStateFilterValue ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter AV12GridStateDynamicFilter ;
      private GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTDropDownOptionsTitleSettingsIcons AV51DDO_TitleSettingsIcons ;
      private GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTDropDownOptionsTitleSettingsIcons GXt_SdtDVB_SDTDropDownOptionsTitleSettingsIcons1 ;
      private GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTDropDownOptionsData_Item AV58AGExportDataItem ;
   }

   public class tipodocumentoww__default : DataStoreHelperBase, IDataStoreHelper
   {
      protected Object[] conditional_H001O2( IGxContext context ,
                                             short A1919TipSts ,
                                             GxSimpleCollection<short> AV95Configuracion_tipodocumentowwds_24_tftipsts_sels ,
                                             string AV72Configuracion_tipodocumentowwds_1_dynamicfiltersselector1 ,
                                             short AV73Configuracion_tipodocumentowwds_2_dynamicfiltersoperator1 ,
                                             string AV74Configuracion_tipodocumentowwds_3_tipdsc1 ,
                                             string AV75Configuracion_tipodocumentowwds_4_tipabr1 ,
                                             bool AV76Configuracion_tipodocumentowwds_5_dynamicfiltersenabled2 ,
                                             string AV77Configuracion_tipodocumentowwds_6_dynamicfiltersselector2 ,
                                             short AV78Configuracion_tipodocumentowwds_7_dynamicfiltersoperator2 ,
                                             string AV79Configuracion_tipodocumentowwds_8_tipdsc2 ,
                                             string AV80Configuracion_tipodocumentowwds_9_tipabr2 ,
                                             bool AV81Configuracion_tipodocumentowwds_10_dynamicfiltersenabled3 ,
                                             string AV82Configuracion_tipodocumentowwds_11_dynamicfiltersselector3 ,
                                             short AV83Configuracion_tipodocumentowwds_12_dynamicfiltersoperator3 ,
                                             string AV84Configuracion_tipodocumentowwds_13_tipdsc3 ,
                                             string AV85Configuracion_tipodocumentowwds_14_tipabr3 ,
                                             string AV87Configuracion_tipodocumentowwds_16_tftipabr_sel ,
                                             string AV86Configuracion_tipodocumentowwds_15_tftipabr ,
                                             string AV89Configuracion_tipodocumentowwds_18_tftipdsc_sel ,
                                             string AV88Configuracion_tipodocumentowwds_17_tftipdsc ,
                                             short AV90Configuracion_tipodocumentowwds_19_tftipvta_sel ,
                                             short AV91Configuracion_tipodocumentowwds_20_tftipcmp_sel ,
                                             short AV92Configuracion_tipodocumentowwds_21_tftiprho_sel ,
                                             short AV93Configuracion_tipodocumentowwds_22_tftipcxp_sel ,
                                             short AV94Configuracion_tipodocumentowwds_23_tftipban_sel ,
                                             int AV95Configuracion_tipodocumentowwds_24_tftipsts_sels_Count ,
                                             string A1910TipDsc ,
                                             string A306TipAbr ,
                                             short A1921TipVta ,
                                             short A1906TipCmp ,
                                             short A1915TipRHo ,
                                             short A1909TipCxP ,
                                             short A1903TipBan ,
                                             short AV13OrderedBy ,
                                             bool AV14OrderedDsc )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int4 = new short[19];
         Object[] GXv_Object5 = new Object[2];
         string sSelectString;
         string sFromString;
         string sOrderString;
         sSelectString = " [TipSts], [TipBan], [TipCxP], [TipRHo], [TipCmp], [TipVta], [TipDsc], [TipAbr], [TipCod]";
         sFromString = " FROM [CTIPDOC]";
         sOrderString = "";
         if ( ( StringUtil.StrCmp(AV72Configuracion_tipodocumentowwds_1_dynamicfiltersselector1, "TIPDSC") == 0 ) && ( AV73Configuracion_tipodocumentowwds_2_dynamicfiltersoperator1 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV74Configuracion_tipodocumentowwds_3_tipdsc1)) ) )
         {
            AddWhere(sWhereString, "([TipDsc] like @lV74Configuracion_tipodocumentowwds_3_tipdsc1)");
         }
         else
         {
            GXv_int4[0] = 1;
         }
         if ( ( StringUtil.StrCmp(AV72Configuracion_tipodocumentowwds_1_dynamicfiltersselector1, "TIPDSC") == 0 ) && ( AV73Configuracion_tipodocumentowwds_2_dynamicfiltersoperator1 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV74Configuracion_tipodocumentowwds_3_tipdsc1)) ) )
         {
            AddWhere(sWhereString, "([TipDsc] like '%' + @lV74Configuracion_tipodocumentowwds_3_tipdsc1)");
         }
         else
         {
            GXv_int4[1] = 1;
         }
         if ( ( StringUtil.StrCmp(AV72Configuracion_tipodocumentowwds_1_dynamicfiltersselector1, "TIPABR") == 0 ) && ( AV73Configuracion_tipodocumentowwds_2_dynamicfiltersoperator1 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV75Configuracion_tipodocumentowwds_4_tipabr1)) ) )
         {
            AddWhere(sWhereString, "([TipAbr] like @lV75Configuracion_tipodocumentowwds_4_tipabr1)");
         }
         else
         {
            GXv_int4[2] = 1;
         }
         if ( ( StringUtil.StrCmp(AV72Configuracion_tipodocumentowwds_1_dynamicfiltersselector1, "TIPABR") == 0 ) && ( AV73Configuracion_tipodocumentowwds_2_dynamicfiltersoperator1 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV75Configuracion_tipodocumentowwds_4_tipabr1)) ) )
         {
            AddWhere(sWhereString, "([TipAbr] like '%' + @lV75Configuracion_tipodocumentowwds_4_tipabr1)");
         }
         else
         {
            GXv_int4[3] = 1;
         }
         if ( AV76Configuracion_tipodocumentowwds_5_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV77Configuracion_tipodocumentowwds_6_dynamicfiltersselector2, "TIPDSC") == 0 ) && ( AV78Configuracion_tipodocumentowwds_7_dynamicfiltersoperator2 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV79Configuracion_tipodocumentowwds_8_tipdsc2)) ) )
         {
            AddWhere(sWhereString, "([TipDsc] like @lV79Configuracion_tipodocumentowwds_8_tipdsc2)");
         }
         else
         {
            GXv_int4[4] = 1;
         }
         if ( AV76Configuracion_tipodocumentowwds_5_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV77Configuracion_tipodocumentowwds_6_dynamicfiltersselector2, "TIPDSC") == 0 ) && ( AV78Configuracion_tipodocumentowwds_7_dynamicfiltersoperator2 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV79Configuracion_tipodocumentowwds_8_tipdsc2)) ) )
         {
            AddWhere(sWhereString, "([TipDsc] like '%' + @lV79Configuracion_tipodocumentowwds_8_tipdsc2)");
         }
         else
         {
            GXv_int4[5] = 1;
         }
         if ( AV76Configuracion_tipodocumentowwds_5_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV77Configuracion_tipodocumentowwds_6_dynamicfiltersselector2, "TIPABR") == 0 ) && ( AV78Configuracion_tipodocumentowwds_7_dynamicfiltersoperator2 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV80Configuracion_tipodocumentowwds_9_tipabr2)) ) )
         {
            AddWhere(sWhereString, "([TipAbr] like @lV80Configuracion_tipodocumentowwds_9_tipabr2)");
         }
         else
         {
            GXv_int4[6] = 1;
         }
         if ( AV76Configuracion_tipodocumentowwds_5_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV77Configuracion_tipodocumentowwds_6_dynamicfiltersselector2, "TIPABR") == 0 ) && ( AV78Configuracion_tipodocumentowwds_7_dynamicfiltersoperator2 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV80Configuracion_tipodocumentowwds_9_tipabr2)) ) )
         {
            AddWhere(sWhereString, "([TipAbr] like '%' + @lV80Configuracion_tipodocumentowwds_9_tipabr2)");
         }
         else
         {
            GXv_int4[7] = 1;
         }
         if ( AV81Configuracion_tipodocumentowwds_10_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV82Configuracion_tipodocumentowwds_11_dynamicfiltersselector3, "TIPDSC") == 0 ) && ( AV83Configuracion_tipodocumentowwds_12_dynamicfiltersoperator3 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV84Configuracion_tipodocumentowwds_13_tipdsc3)) ) )
         {
            AddWhere(sWhereString, "([TipDsc] like @lV84Configuracion_tipodocumentowwds_13_tipdsc3)");
         }
         else
         {
            GXv_int4[8] = 1;
         }
         if ( AV81Configuracion_tipodocumentowwds_10_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV82Configuracion_tipodocumentowwds_11_dynamicfiltersselector3, "TIPDSC") == 0 ) && ( AV83Configuracion_tipodocumentowwds_12_dynamicfiltersoperator3 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV84Configuracion_tipodocumentowwds_13_tipdsc3)) ) )
         {
            AddWhere(sWhereString, "([TipDsc] like '%' + @lV84Configuracion_tipodocumentowwds_13_tipdsc3)");
         }
         else
         {
            GXv_int4[9] = 1;
         }
         if ( AV81Configuracion_tipodocumentowwds_10_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV82Configuracion_tipodocumentowwds_11_dynamicfiltersselector3, "TIPABR") == 0 ) && ( AV83Configuracion_tipodocumentowwds_12_dynamicfiltersoperator3 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV85Configuracion_tipodocumentowwds_14_tipabr3)) ) )
         {
            AddWhere(sWhereString, "([TipAbr] like @lV85Configuracion_tipodocumentowwds_14_tipabr3)");
         }
         else
         {
            GXv_int4[10] = 1;
         }
         if ( AV81Configuracion_tipodocumentowwds_10_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV82Configuracion_tipodocumentowwds_11_dynamicfiltersselector3, "TIPABR") == 0 ) && ( AV83Configuracion_tipodocumentowwds_12_dynamicfiltersoperator3 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV85Configuracion_tipodocumentowwds_14_tipabr3)) ) )
         {
            AddWhere(sWhereString, "([TipAbr] like '%' + @lV85Configuracion_tipodocumentowwds_14_tipabr3)");
         }
         else
         {
            GXv_int4[11] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV87Configuracion_tipodocumentowwds_16_tftipabr_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV86Configuracion_tipodocumentowwds_15_tftipabr)) ) )
         {
            AddWhere(sWhereString, "([TipAbr] like @lV86Configuracion_tipodocumentowwds_15_tftipabr)");
         }
         else
         {
            GXv_int4[12] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV87Configuracion_tipodocumentowwds_16_tftipabr_sel)) )
         {
            AddWhere(sWhereString, "([TipAbr] = @AV87Configuracion_tipodocumentowwds_16_tftipabr_sel)");
         }
         else
         {
            GXv_int4[13] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV89Configuracion_tipodocumentowwds_18_tftipdsc_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV88Configuracion_tipodocumentowwds_17_tftipdsc)) ) )
         {
            AddWhere(sWhereString, "([TipDsc] like @lV88Configuracion_tipodocumentowwds_17_tftipdsc)");
         }
         else
         {
            GXv_int4[14] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV89Configuracion_tipodocumentowwds_18_tftipdsc_sel)) )
         {
            AddWhere(sWhereString, "([TipDsc] = @AV89Configuracion_tipodocumentowwds_18_tftipdsc_sel)");
         }
         else
         {
            GXv_int4[15] = 1;
         }
         if ( AV90Configuracion_tipodocumentowwds_19_tftipvta_sel == 1 )
         {
            AddWhere(sWhereString, "([TipVta] = 1)");
         }
         if ( AV90Configuracion_tipodocumentowwds_19_tftipvta_sel == 2 )
         {
            AddWhere(sWhereString, "([TipVta] = 0)");
         }
         if ( AV91Configuracion_tipodocumentowwds_20_tftipcmp_sel == 1 )
         {
            AddWhere(sWhereString, "([TipCmp] = 1)");
         }
         if ( AV91Configuracion_tipodocumentowwds_20_tftipcmp_sel == 2 )
         {
            AddWhere(sWhereString, "([TipCmp] = 0)");
         }
         if ( AV92Configuracion_tipodocumentowwds_21_tftiprho_sel == 1 )
         {
            AddWhere(sWhereString, "([TipRHo] = 1)");
         }
         if ( AV92Configuracion_tipodocumentowwds_21_tftiprho_sel == 2 )
         {
            AddWhere(sWhereString, "([TipRHo] = 0)");
         }
         if ( AV93Configuracion_tipodocumentowwds_22_tftipcxp_sel == 1 )
         {
            AddWhere(sWhereString, "([TipCxP] = 1)");
         }
         if ( AV93Configuracion_tipodocumentowwds_22_tftipcxp_sel == 2 )
         {
            AddWhere(sWhereString, "([TipCxP] = 0)");
         }
         if ( AV94Configuracion_tipodocumentowwds_23_tftipban_sel == 1 )
         {
            AddWhere(sWhereString, "([TipBan] = 1)");
         }
         if ( AV94Configuracion_tipodocumentowwds_23_tftipban_sel == 2 )
         {
            AddWhere(sWhereString, "([TipBan] = 0)");
         }
         if ( AV95Configuracion_tipodocumentowwds_24_tftipsts_sels_Count > 0 )
         {
            AddWhere(sWhereString, "("+new GxDbmsUtils( new GxSqlServer()).ValueList(AV95Configuracion_tipodocumentowwds_24_tftipsts_sels, "[TipSts] IN (", ")")+")");
         }
         if ( ( AV13OrderedBy == 1 ) && ! AV14OrderedDsc )
         {
            sOrderString += " ORDER BY [TipAbr]";
         }
         else if ( ( AV13OrderedBy == 1 ) && ( AV14OrderedDsc ) )
         {
            sOrderString += " ORDER BY [TipAbr] DESC";
         }
         else if ( ( AV13OrderedBy == 2 ) && ! AV14OrderedDsc )
         {
            sOrderString += " ORDER BY [TipDsc]";
         }
         else if ( ( AV13OrderedBy == 2 ) && ( AV14OrderedDsc ) )
         {
            sOrderString += " ORDER BY [TipDsc] DESC";
         }
         else if ( ( AV13OrderedBy == 3 ) && ! AV14OrderedDsc )
         {
            sOrderString += " ORDER BY [TipVta]";
         }
         else if ( ( AV13OrderedBy == 3 ) && ( AV14OrderedDsc ) )
         {
            sOrderString += " ORDER BY [TipVta] DESC";
         }
         else if ( ( AV13OrderedBy == 4 ) && ! AV14OrderedDsc )
         {
            sOrderString += " ORDER BY [TipCmp]";
         }
         else if ( ( AV13OrderedBy == 4 ) && ( AV14OrderedDsc ) )
         {
            sOrderString += " ORDER BY [TipCmp] DESC";
         }
         else if ( ( AV13OrderedBy == 5 ) && ! AV14OrderedDsc )
         {
            sOrderString += " ORDER BY [TipRHo]";
         }
         else if ( ( AV13OrderedBy == 5 ) && ( AV14OrderedDsc ) )
         {
            sOrderString += " ORDER BY [TipRHo] DESC";
         }
         else if ( ( AV13OrderedBy == 6 ) && ! AV14OrderedDsc )
         {
            sOrderString += " ORDER BY [TipCxP]";
         }
         else if ( ( AV13OrderedBy == 6 ) && ( AV14OrderedDsc ) )
         {
            sOrderString += " ORDER BY [TipCxP] DESC";
         }
         else if ( ( AV13OrderedBy == 7 ) && ! AV14OrderedDsc )
         {
            sOrderString += " ORDER BY [TipBan]";
         }
         else if ( ( AV13OrderedBy == 7 ) && ( AV14OrderedDsc ) )
         {
            sOrderString += " ORDER BY [TipBan] DESC";
         }
         else if ( ( AV13OrderedBy == 8 ) && ! AV14OrderedDsc )
         {
            sOrderString += " ORDER BY [TipSts]";
         }
         else if ( ( AV13OrderedBy == 8 ) && ( AV14OrderedDsc ) )
         {
            sOrderString += " ORDER BY [TipSts] DESC";
         }
         else if ( true )
         {
            sOrderString += " ORDER BY [TipCod]";
         }
         scmdbuf = "SELECT " + sSelectString + sFromString + sWhereString + sOrderString + "" + " OFFSET " + "@GXPagingFrom2" + " ROWS FETCH NEXT CAST((SELECT CASE WHEN " + "@GXPagingTo2" + " > 0 THEN " + "@GXPagingTo2" + " ELSE 1e9 END) AS INTEGER) ROWS ONLY";
         GXv_Object5[0] = scmdbuf;
         GXv_Object5[1] = GXv_int4;
         return GXv_Object5 ;
      }

      protected Object[] conditional_H001O3( IGxContext context ,
                                             short A1919TipSts ,
                                             GxSimpleCollection<short> AV95Configuracion_tipodocumentowwds_24_tftipsts_sels ,
                                             string AV72Configuracion_tipodocumentowwds_1_dynamicfiltersselector1 ,
                                             short AV73Configuracion_tipodocumentowwds_2_dynamicfiltersoperator1 ,
                                             string AV74Configuracion_tipodocumentowwds_3_tipdsc1 ,
                                             string AV75Configuracion_tipodocumentowwds_4_tipabr1 ,
                                             bool AV76Configuracion_tipodocumentowwds_5_dynamicfiltersenabled2 ,
                                             string AV77Configuracion_tipodocumentowwds_6_dynamicfiltersselector2 ,
                                             short AV78Configuracion_tipodocumentowwds_7_dynamicfiltersoperator2 ,
                                             string AV79Configuracion_tipodocumentowwds_8_tipdsc2 ,
                                             string AV80Configuracion_tipodocumentowwds_9_tipabr2 ,
                                             bool AV81Configuracion_tipodocumentowwds_10_dynamicfiltersenabled3 ,
                                             string AV82Configuracion_tipodocumentowwds_11_dynamicfiltersselector3 ,
                                             short AV83Configuracion_tipodocumentowwds_12_dynamicfiltersoperator3 ,
                                             string AV84Configuracion_tipodocumentowwds_13_tipdsc3 ,
                                             string AV85Configuracion_tipodocumentowwds_14_tipabr3 ,
                                             string AV87Configuracion_tipodocumentowwds_16_tftipabr_sel ,
                                             string AV86Configuracion_tipodocumentowwds_15_tftipabr ,
                                             string AV89Configuracion_tipodocumentowwds_18_tftipdsc_sel ,
                                             string AV88Configuracion_tipodocumentowwds_17_tftipdsc ,
                                             short AV90Configuracion_tipodocumentowwds_19_tftipvta_sel ,
                                             short AV91Configuracion_tipodocumentowwds_20_tftipcmp_sel ,
                                             short AV92Configuracion_tipodocumentowwds_21_tftiprho_sel ,
                                             short AV93Configuracion_tipodocumentowwds_22_tftipcxp_sel ,
                                             short AV94Configuracion_tipodocumentowwds_23_tftipban_sel ,
                                             int AV95Configuracion_tipodocumentowwds_24_tftipsts_sels_Count ,
                                             string A1910TipDsc ,
                                             string A306TipAbr ,
                                             short A1921TipVta ,
                                             short A1906TipCmp ,
                                             short A1915TipRHo ,
                                             short A1909TipCxP ,
                                             short A1903TipBan ,
                                             short AV13OrderedBy ,
                                             bool AV14OrderedDsc )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int6 = new short[16];
         Object[] GXv_Object7 = new Object[2];
         scmdbuf = "SELECT COUNT(*) FROM [CTIPDOC]";
         if ( ( StringUtil.StrCmp(AV72Configuracion_tipodocumentowwds_1_dynamicfiltersselector1, "TIPDSC") == 0 ) && ( AV73Configuracion_tipodocumentowwds_2_dynamicfiltersoperator1 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV74Configuracion_tipodocumentowwds_3_tipdsc1)) ) )
         {
            AddWhere(sWhereString, "([TipDsc] like @lV74Configuracion_tipodocumentowwds_3_tipdsc1)");
         }
         else
         {
            GXv_int6[0] = 1;
         }
         if ( ( StringUtil.StrCmp(AV72Configuracion_tipodocumentowwds_1_dynamicfiltersselector1, "TIPDSC") == 0 ) && ( AV73Configuracion_tipodocumentowwds_2_dynamicfiltersoperator1 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV74Configuracion_tipodocumentowwds_3_tipdsc1)) ) )
         {
            AddWhere(sWhereString, "([TipDsc] like '%' + @lV74Configuracion_tipodocumentowwds_3_tipdsc1)");
         }
         else
         {
            GXv_int6[1] = 1;
         }
         if ( ( StringUtil.StrCmp(AV72Configuracion_tipodocumentowwds_1_dynamicfiltersselector1, "TIPABR") == 0 ) && ( AV73Configuracion_tipodocumentowwds_2_dynamicfiltersoperator1 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV75Configuracion_tipodocumentowwds_4_tipabr1)) ) )
         {
            AddWhere(sWhereString, "([TipAbr] like @lV75Configuracion_tipodocumentowwds_4_tipabr1)");
         }
         else
         {
            GXv_int6[2] = 1;
         }
         if ( ( StringUtil.StrCmp(AV72Configuracion_tipodocumentowwds_1_dynamicfiltersselector1, "TIPABR") == 0 ) && ( AV73Configuracion_tipodocumentowwds_2_dynamicfiltersoperator1 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV75Configuracion_tipodocumentowwds_4_tipabr1)) ) )
         {
            AddWhere(sWhereString, "([TipAbr] like '%' + @lV75Configuracion_tipodocumentowwds_4_tipabr1)");
         }
         else
         {
            GXv_int6[3] = 1;
         }
         if ( AV76Configuracion_tipodocumentowwds_5_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV77Configuracion_tipodocumentowwds_6_dynamicfiltersselector2, "TIPDSC") == 0 ) && ( AV78Configuracion_tipodocumentowwds_7_dynamicfiltersoperator2 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV79Configuracion_tipodocumentowwds_8_tipdsc2)) ) )
         {
            AddWhere(sWhereString, "([TipDsc] like @lV79Configuracion_tipodocumentowwds_8_tipdsc2)");
         }
         else
         {
            GXv_int6[4] = 1;
         }
         if ( AV76Configuracion_tipodocumentowwds_5_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV77Configuracion_tipodocumentowwds_6_dynamicfiltersselector2, "TIPDSC") == 0 ) && ( AV78Configuracion_tipodocumentowwds_7_dynamicfiltersoperator2 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV79Configuracion_tipodocumentowwds_8_tipdsc2)) ) )
         {
            AddWhere(sWhereString, "([TipDsc] like '%' + @lV79Configuracion_tipodocumentowwds_8_tipdsc2)");
         }
         else
         {
            GXv_int6[5] = 1;
         }
         if ( AV76Configuracion_tipodocumentowwds_5_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV77Configuracion_tipodocumentowwds_6_dynamicfiltersselector2, "TIPABR") == 0 ) && ( AV78Configuracion_tipodocumentowwds_7_dynamicfiltersoperator2 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV80Configuracion_tipodocumentowwds_9_tipabr2)) ) )
         {
            AddWhere(sWhereString, "([TipAbr] like @lV80Configuracion_tipodocumentowwds_9_tipabr2)");
         }
         else
         {
            GXv_int6[6] = 1;
         }
         if ( AV76Configuracion_tipodocumentowwds_5_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV77Configuracion_tipodocumentowwds_6_dynamicfiltersselector2, "TIPABR") == 0 ) && ( AV78Configuracion_tipodocumentowwds_7_dynamicfiltersoperator2 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV80Configuracion_tipodocumentowwds_9_tipabr2)) ) )
         {
            AddWhere(sWhereString, "([TipAbr] like '%' + @lV80Configuracion_tipodocumentowwds_9_tipabr2)");
         }
         else
         {
            GXv_int6[7] = 1;
         }
         if ( AV81Configuracion_tipodocumentowwds_10_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV82Configuracion_tipodocumentowwds_11_dynamicfiltersselector3, "TIPDSC") == 0 ) && ( AV83Configuracion_tipodocumentowwds_12_dynamicfiltersoperator3 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV84Configuracion_tipodocumentowwds_13_tipdsc3)) ) )
         {
            AddWhere(sWhereString, "([TipDsc] like @lV84Configuracion_tipodocumentowwds_13_tipdsc3)");
         }
         else
         {
            GXv_int6[8] = 1;
         }
         if ( AV81Configuracion_tipodocumentowwds_10_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV82Configuracion_tipodocumentowwds_11_dynamicfiltersselector3, "TIPDSC") == 0 ) && ( AV83Configuracion_tipodocumentowwds_12_dynamicfiltersoperator3 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV84Configuracion_tipodocumentowwds_13_tipdsc3)) ) )
         {
            AddWhere(sWhereString, "([TipDsc] like '%' + @lV84Configuracion_tipodocumentowwds_13_tipdsc3)");
         }
         else
         {
            GXv_int6[9] = 1;
         }
         if ( AV81Configuracion_tipodocumentowwds_10_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV82Configuracion_tipodocumentowwds_11_dynamicfiltersselector3, "TIPABR") == 0 ) && ( AV83Configuracion_tipodocumentowwds_12_dynamicfiltersoperator3 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV85Configuracion_tipodocumentowwds_14_tipabr3)) ) )
         {
            AddWhere(sWhereString, "([TipAbr] like @lV85Configuracion_tipodocumentowwds_14_tipabr3)");
         }
         else
         {
            GXv_int6[10] = 1;
         }
         if ( AV81Configuracion_tipodocumentowwds_10_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV82Configuracion_tipodocumentowwds_11_dynamicfiltersselector3, "TIPABR") == 0 ) && ( AV83Configuracion_tipodocumentowwds_12_dynamicfiltersoperator3 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV85Configuracion_tipodocumentowwds_14_tipabr3)) ) )
         {
            AddWhere(sWhereString, "([TipAbr] like '%' + @lV85Configuracion_tipodocumentowwds_14_tipabr3)");
         }
         else
         {
            GXv_int6[11] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV87Configuracion_tipodocumentowwds_16_tftipabr_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV86Configuracion_tipodocumentowwds_15_tftipabr)) ) )
         {
            AddWhere(sWhereString, "([TipAbr] like @lV86Configuracion_tipodocumentowwds_15_tftipabr)");
         }
         else
         {
            GXv_int6[12] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV87Configuracion_tipodocumentowwds_16_tftipabr_sel)) )
         {
            AddWhere(sWhereString, "([TipAbr] = @AV87Configuracion_tipodocumentowwds_16_tftipabr_sel)");
         }
         else
         {
            GXv_int6[13] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV89Configuracion_tipodocumentowwds_18_tftipdsc_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV88Configuracion_tipodocumentowwds_17_tftipdsc)) ) )
         {
            AddWhere(sWhereString, "([TipDsc] like @lV88Configuracion_tipodocumentowwds_17_tftipdsc)");
         }
         else
         {
            GXv_int6[14] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV89Configuracion_tipodocumentowwds_18_tftipdsc_sel)) )
         {
            AddWhere(sWhereString, "([TipDsc] = @AV89Configuracion_tipodocumentowwds_18_tftipdsc_sel)");
         }
         else
         {
            GXv_int6[15] = 1;
         }
         if ( AV90Configuracion_tipodocumentowwds_19_tftipvta_sel == 1 )
         {
            AddWhere(sWhereString, "([TipVta] = 1)");
         }
         if ( AV90Configuracion_tipodocumentowwds_19_tftipvta_sel == 2 )
         {
            AddWhere(sWhereString, "([TipVta] = 0)");
         }
         if ( AV91Configuracion_tipodocumentowwds_20_tftipcmp_sel == 1 )
         {
            AddWhere(sWhereString, "([TipCmp] = 1)");
         }
         if ( AV91Configuracion_tipodocumentowwds_20_tftipcmp_sel == 2 )
         {
            AddWhere(sWhereString, "([TipCmp] = 0)");
         }
         if ( AV92Configuracion_tipodocumentowwds_21_tftiprho_sel == 1 )
         {
            AddWhere(sWhereString, "([TipRHo] = 1)");
         }
         if ( AV92Configuracion_tipodocumentowwds_21_tftiprho_sel == 2 )
         {
            AddWhere(sWhereString, "([TipRHo] = 0)");
         }
         if ( AV93Configuracion_tipodocumentowwds_22_tftipcxp_sel == 1 )
         {
            AddWhere(sWhereString, "([TipCxP] = 1)");
         }
         if ( AV93Configuracion_tipodocumentowwds_22_tftipcxp_sel == 2 )
         {
            AddWhere(sWhereString, "([TipCxP] = 0)");
         }
         if ( AV94Configuracion_tipodocumentowwds_23_tftipban_sel == 1 )
         {
            AddWhere(sWhereString, "([TipBan] = 1)");
         }
         if ( AV94Configuracion_tipodocumentowwds_23_tftipban_sel == 2 )
         {
            AddWhere(sWhereString, "([TipBan] = 0)");
         }
         if ( AV95Configuracion_tipodocumentowwds_24_tftipsts_sels_Count > 0 )
         {
            AddWhere(sWhereString, "("+new GxDbmsUtils( new GxSqlServer()).ValueList(AV95Configuracion_tipodocumentowwds_24_tftipsts_sels, "[TipSts] IN (", ")")+")");
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
                     return conditional_H001O2(context, (short)dynConstraints[0] , (GxSimpleCollection<short>)dynConstraints[1] , (string)dynConstraints[2] , (short)dynConstraints[3] , (string)dynConstraints[4] , (string)dynConstraints[5] , (bool)dynConstraints[6] , (string)dynConstraints[7] , (short)dynConstraints[8] , (string)dynConstraints[9] , (string)dynConstraints[10] , (bool)dynConstraints[11] , (string)dynConstraints[12] , (short)dynConstraints[13] , (string)dynConstraints[14] , (string)dynConstraints[15] , (string)dynConstraints[16] , (string)dynConstraints[17] , (string)dynConstraints[18] , (string)dynConstraints[19] , (short)dynConstraints[20] , (short)dynConstraints[21] , (short)dynConstraints[22] , (short)dynConstraints[23] , (short)dynConstraints[24] , (int)dynConstraints[25] , (string)dynConstraints[26] , (string)dynConstraints[27] , (short)dynConstraints[28] , (short)dynConstraints[29] , (short)dynConstraints[30] , (short)dynConstraints[31] , (short)dynConstraints[32] , (short)dynConstraints[33] , (bool)dynConstraints[34] );
               case 1 :
                     return conditional_H001O3(context, (short)dynConstraints[0] , (GxSimpleCollection<short>)dynConstraints[1] , (string)dynConstraints[2] , (short)dynConstraints[3] , (string)dynConstraints[4] , (string)dynConstraints[5] , (bool)dynConstraints[6] , (string)dynConstraints[7] , (short)dynConstraints[8] , (string)dynConstraints[9] , (string)dynConstraints[10] , (bool)dynConstraints[11] , (string)dynConstraints[12] , (short)dynConstraints[13] , (string)dynConstraints[14] , (string)dynConstraints[15] , (string)dynConstraints[16] , (string)dynConstraints[17] , (string)dynConstraints[18] , (string)dynConstraints[19] , (short)dynConstraints[20] , (short)dynConstraints[21] , (short)dynConstraints[22] , (short)dynConstraints[23] , (short)dynConstraints[24] , (int)dynConstraints[25] , (string)dynConstraints[26] , (string)dynConstraints[27] , (short)dynConstraints[28] , (short)dynConstraints[29] , (short)dynConstraints[30] , (short)dynConstraints[31] , (short)dynConstraints[32] , (short)dynConstraints[33] , (bool)dynConstraints[34] );
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
          Object[] prmH001O2;
          prmH001O2 = new Object[] {
          new ParDef("@lV74Configuracion_tipodocumentowwds_3_tipdsc1",GXType.NChar,100,0) ,
          new ParDef("@lV74Configuracion_tipodocumentowwds_3_tipdsc1",GXType.NChar,100,0) ,
          new ParDef("@lV75Configuracion_tipodocumentowwds_4_tipabr1",GXType.NChar,5,0) ,
          new ParDef("@lV75Configuracion_tipodocumentowwds_4_tipabr1",GXType.NChar,5,0) ,
          new ParDef("@lV79Configuracion_tipodocumentowwds_8_tipdsc2",GXType.NChar,100,0) ,
          new ParDef("@lV79Configuracion_tipodocumentowwds_8_tipdsc2",GXType.NChar,100,0) ,
          new ParDef("@lV80Configuracion_tipodocumentowwds_9_tipabr2",GXType.NChar,5,0) ,
          new ParDef("@lV80Configuracion_tipodocumentowwds_9_tipabr2",GXType.NChar,5,0) ,
          new ParDef("@lV84Configuracion_tipodocumentowwds_13_tipdsc3",GXType.NChar,100,0) ,
          new ParDef("@lV84Configuracion_tipodocumentowwds_13_tipdsc3",GXType.NChar,100,0) ,
          new ParDef("@lV85Configuracion_tipodocumentowwds_14_tipabr3",GXType.NChar,5,0) ,
          new ParDef("@lV85Configuracion_tipodocumentowwds_14_tipabr3",GXType.NChar,5,0) ,
          new ParDef("@lV86Configuracion_tipodocumentowwds_15_tftipabr",GXType.NChar,5,0) ,
          new ParDef("@AV87Configuracion_tipodocumentowwds_16_tftipabr_sel",GXType.NChar,5,0) ,
          new ParDef("@lV88Configuracion_tipodocumentowwds_17_tftipdsc",GXType.NChar,100,0) ,
          new ParDef("@AV89Configuracion_tipodocumentowwds_18_tftipdsc_sel",GXType.NChar,100,0) ,
          new ParDef("@GXPagingFrom2",GXType.Int32,9,0) ,
          new ParDef("@GXPagingTo2",GXType.Int32,9,0) ,
          new ParDef("@GXPagingTo2",GXType.Int32,9,0)
          };
          Object[] prmH001O3;
          prmH001O3 = new Object[] {
          new ParDef("@lV74Configuracion_tipodocumentowwds_3_tipdsc1",GXType.NChar,100,0) ,
          new ParDef("@lV74Configuracion_tipodocumentowwds_3_tipdsc1",GXType.NChar,100,0) ,
          new ParDef("@lV75Configuracion_tipodocumentowwds_4_tipabr1",GXType.NChar,5,0) ,
          new ParDef("@lV75Configuracion_tipodocumentowwds_4_tipabr1",GXType.NChar,5,0) ,
          new ParDef("@lV79Configuracion_tipodocumentowwds_8_tipdsc2",GXType.NChar,100,0) ,
          new ParDef("@lV79Configuracion_tipodocumentowwds_8_tipdsc2",GXType.NChar,100,0) ,
          new ParDef("@lV80Configuracion_tipodocumentowwds_9_tipabr2",GXType.NChar,5,0) ,
          new ParDef("@lV80Configuracion_tipodocumentowwds_9_tipabr2",GXType.NChar,5,0) ,
          new ParDef("@lV84Configuracion_tipodocumentowwds_13_tipdsc3",GXType.NChar,100,0) ,
          new ParDef("@lV84Configuracion_tipodocumentowwds_13_tipdsc3",GXType.NChar,100,0) ,
          new ParDef("@lV85Configuracion_tipodocumentowwds_14_tipabr3",GXType.NChar,5,0) ,
          new ParDef("@lV85Configuracion_tipodocumentowwds_14_tipabr3",GXType.NChar,5,0) ,
          new ParDef("@lV86Configuracion_tipodocumentowwds_15_tftipabr",GXType.NChar,5,0) ,
          new ParDef("@AV87Configuracion_tipodocumentowwds_16_tftipabr_sel",GXType.NChar,5,0) ,
          new ParDef("@lV88Configuracion_tipodocumentowwds_17_tftipdsc",GXType.NChar,100,0) ,
          new ParDef("@AV89Configuracion_tipodocumentowwds_18_tftipdsc_sel",GXType.NChar,100,0)
          };
          def= new CursorDef[] {
              new CursorDef("H001O2", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH001O2,11, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("H001O3", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH001O3,1, GxCacheFrequency.OFF ,true,false )
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
                ((short[]) buf[2])[0] = rslt.getShort(3);
                ((short[]) buf[3])[0] = rslt.getShort(4);
                ((short[]) buf[4])[0] = rslt.getShort(5);
                ((short[]) buf[5])[0] = rslt.getShort(6);
                ((string[]) buf[6])[0] = rslt.getString(7, 100);
                ((string[]) buf[7])[0] = rslt.getString(8, 5);
                ((string[]) buf[8])[0] = rslt.getString(9, 3);
                return;
             case 1 :
                ((long[]) buf[0])[0] = rslt.getLong(1);
                return;
       }
    }

 }

}
