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
   public class numeraciondocumentosww : GXDataArea
   {
      public numeraciondocumentosww( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDataStore2 = context.GetDataStore("DataStore2");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusTheme");
      }

      public numeraciondocumentosww( IGxContext context )
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
         cmbavCordoc1 = new GXCombobox();
         cmbavDynamicfiltersselector2 = new GXCombobox();
         cmbavDynamicfiltersoperator2 = new GXCombobox();
         cmbavCordoc2 = new GXCombobox();
         cmbavDynamicfiltersselector3 = new GXCombobox();
         cmbavDynamicfiltersoperator3 = new GXCombobox();
         cmbavCordoc3 = new GXCombobox();
         cmbavGridactions = new GXCombobox();
         chkCorFE = new GXCheckbox();
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
               nRC_GXsfl_119 = (int)(NumberUtil.Val( GetPar( "nRC_GXsfl_119"), "."));
               nGXsfl_119_idx = (int)(NumberUtil.Val( GetPar( "nGXsfl_119_idx"), "."));
               sGXsfl_119_idx = GetPar( "sGXsfl_119_idx");
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
               cmbavCordoc1.FromJSonString( GetNextPar( ));
               AV17CorDoc1 = GetPar( "CorDoc1");
               AV18NumDoc1 = (long)(NumberUtil.Val( GetPar( "NumDoc1"), "."));
               AV19CorSerie1 = GetPar( "CorSerie1");
               cmbavDynamicfiltersselector2.FromJSonString( GetNextPar( ));
               AV21DynamicFiltersSelector2 = GetPar( "DynamicFiltersSelector2");
               cmbavDynamicfiltersoperator2.FromJSonString( GetNextPar( ));
               AV22DynamicFiltersOperator2 = (short)(NumberUtil.Val( GetPar( "DynamicFiltersOperator2"), "."));
               cmbavCordoc2.FromJSonString( GetNextPar( ));
               AV23CorDoc2 = GetPar( "CorDoc2");
               AV24NumDoc2 = (long)(NumberUtil.Val( GetPar( "NumDoc2"), "."));
               AV25CorSerie2 = GetPar( "CorSerie2");
               cmbavDynamicfiltersselector3.FromJSonString( GetNextPar( ));
               AV27DynamicFiltersSelector3 = GetPar( "DynamicFiltersSelector3");
               cmbavDynamicfiltersoperator3.FromJSonString( GetNextPar( ));
               AV28DynamicFiltersOperator3 = (short)(NumberUtil.Val( GetPar( "DynamicFiltersOperator3"), "."));
               cmbavCordoc3.FromJSonString( GetNextPar( ));
               AV29CorDoc3 = GetPar( "CorDoc3");
               AV30NumDoc3 = (long)(NumberUtil.Val( GetPar( "NumDoc3"), "."));
               AV31CorSerie3 = GetPar( "CorSerie3");
               AV20DynamicFiltersEnabled2 = StringUtil.StrToBool( GetPar( "DynamicFiltersEnabled2"));
               AV26DynamicFiltersEnabled3 = StringUtil.StrToBool( GetPar( "DynamicFiltersEnabled3"));
               AV56Pgmname = GetPar( "Pgmname");
               AV37TFCorDoc = GetPar( "TFCorDoc");
               AV38TFCorDoc_Sel = GetPar( "TFCorDoc_Sel");
               AV39TFNumDoc = (long)(NumberUtil.Val( GetPar( "TFNumDoc"), "."));
               AV40TFNumDoc_To = (long)(NumberUtil.Val( GetPar( "TFNumDoc_To"), "."));
               AV41TFCorSerie = GetPar( "TFCorSerie");
               AV42TFCorSerie_Sel = GetPar( "TFCorSerie_Sel");
               AV43TFCorFE_Sel = (short)(NumberUtil.Val( GetPar( "TFCorFE_Sel"), "."));
               AV44TFCorFormato = GetPar( "TFCorFormato");
               AV45TFCorFormato_Sel = GetPar( "TFCorFormato_Sel");
               AV13OrderedBy = (short)(NumberUtil.Val( GetPar( "OrderedBy"), "."));
               AV14OrderedDsc = StringUtil.StrToBool( GetPar( "OrderedDsc"));
               ajax_req_read_hidden_sdt(GetNextPar( ), AV10GridState);
               AV33DynamicFiltersIgnoreFirst = StringUtil.StrToBool( GetPar( "DynamicFiltersIgnoreFirst"));
               AV32DynamicFiltersRemoving = StringUtil.StrToBool( GetPar( "DynamicFiltersRemoving"));
               setAjaxCallMode();
               if ( ! IsValidAjaxCall( true) )
               {
                  GxWebError = 1;
                  return  ;
               }
               gxgrGrid_refresh( subGrid_Rows, AV15DynamicFiltersSelector1, AV16DynamicFiltersOperator1, AV17CorDoc1, AV18NumDoc1, AV19CorSerie1, AV21DynamicFiltersSelector2, AV22DynamicFiltersOperator2, AV23CorDoc2, AV24NumDoc2, AV25CorSerie2, AV27DynamicFiltersSelector3, AV28DynamicFiltersOperator3, AV29CorDoc3, AV30NumDoc3, AV31CorSerie3, AV20DynamicFiltersEnabled2, AV26DynamicFiltersEnabled3, AV56Pgmname, AV37TFCorDoc, AV38TFCorDoc_Sel, AV39TFNumDoc, AV40TFNumDoc_To, AV41TFCorSerie, AV42TFCorSerie_Sel, AV43TFCorFE_Sel, AV44TFCorFormato, AV45TFCorFormato_Sel, AV13OrderedBy, AV14OrderedDsc, AV10GridState, AV33DynamicFiltersIgnoreFirst, AV32DynamicFiltersRemoving) ;
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
         PA0F2( ) ;
         gxajaxcallmode = (short)((isAjaxCallMode( ) ? 1 : 0));
         if ( ( gxajaxcallmode == 0 ) && ( GxWebError == 0 ) )
         {
            START0F2( ) ;
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
         context.AddJavascriptSource("gxcfg.js", "?202281810274072", false, true);
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
         context.WriteHtmlTextNl( "<form id=\"MAINFORM\" autocomplete=\"off\" name=\"MAINFORM\" method=\"post\" tabindex=-1  class=\"form-horizontal Form\" data-gx-class=\"form-horizontal Form\" novalidate action=\""+formatLink("seguridad.numeraciondocumentosww.aspx") +"\">") ;
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
         GxWebStd.gx_hidden_field( context, "GXH_vCORDOC1", StringUtil.RTrim( AV17CorDoc1));
         GxWebStd.gx_hidden_field( context, "GXH_vNUMDOC1", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV18NumDoc1), 10, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "GXH_vCORSERIE1", StringUtil.RTrim( AV19CorSerie1));
         GxWebStd.gx_hidden_field( context, "GXH_vDYNAMICFILTERSSELECTOR2", AV21DynamicFiltersSelector2);
         GxWebStd.gx_hidden_field( context, "GXH_vDYNAMICFILTERSOPERATOR2", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV22DynamicFiltersOperator2), 4, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "GXH_vCORDOC2", StringUtil.RTrim( AV23CorDoc2));
         GxWebStd.gx_hidden_field( context, "GXH_vNUMDOC2", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV24NumDoc2), 10, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "GXH_vCORSERIE2", StringUtil.RTrim( AV25CorSerie2));
         GxWebStd.gx_hidden_field( context, "GXH_vDYNAMICFILTERSSELECTOR3", AV27DynamicFiltersSelector3);
         GxWebStd.gx_hidden_field( context, "GXH_vDYNAMICFILTERSOPERATOR3", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV28DynamicFiltersOperator3), 4, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "GXH_vCORDOC3", StringUtil.RTrim( AV29CorDoc3));
         GxWebStd.gx_hidden_field( context, "GXH_vNUMDOC3", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV30NumDoc3), 10, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "GXH_vCORSERIE3", StringUtil.RTrim( AV31CorSerie3));
         /* Send saved values. */
         send_integrity_footer_hashes( ) ;
         GxWebStd.gx_hidden_field( context, "nRC_GXsfl_119", StringUtil.LTrim( StringUtil.NToC( (decimal)(nRC_GXsfl_119), 8, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "vGRIDCURRENTPAGE", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV48GridCurrentPage), 10, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "vGRIDPAGECOUNT", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV49GridPageCount), 10, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "vGRIDAPPLIEDFILTERS", AV50GridAppliedFilters);
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "vAGEXPORTDATA", AV52AGExportData);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt("vAGEXPORTDATA", AV52AGExportData);
         }
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "vDDO_TITLESETTINGSICONS", AV46DDO_TitleSettingsIcons);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt("vDDO_TITLESETTINGSICONS", AV46DDO_TitleSettingsIcons);
         }
         GxWebStd.gx_boolean_hidden_field( context, "vDYNAMICFILTERSENABLED2", AV20DynamicFiltersEnabled2);
         GxWebStd.gx_boolean_hidden_field( context, "vDYNAMICFILTERSENABLED3", AV26DynamicFiltersEnabled3);
         GxWebStd.gx_hidden_field( context, "vPGMNAME", StringUtil.RTrim( AV56Pgmname));
         GxWebStd.gx_hidden_field( context, "gxhash_vPGMNAME", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( AV56Pgmname, "")), context));
         GxWebStd.gx_hidden_field( context, "vTFCORDOC", StringUtil.RTrim( AV37TFCorDoc));
         GxWebStd.gx_hidden_field( context, "vTFCORDOC_SEL", StringUtil.RTrim( AV38TFCorDoc_Sel));
         GxWebStd.gx_hidden_field( context, "vTFNUMDOC", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV39TFNumDoc), 10, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "vTFNUMDOC_TO", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV40TFNumDoc_To), 10, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "vTFCORSERIE", StringUtil.RTrim( AV41TFCorSerie));
         GxWebStd.gx_hidden_field( context, "vTFCORSERIE_SEL", StringUtil.RTrim( AV42TFCorSerie_Sel));
         GxWebStd.gx_hidden_field( context, "vTFCORFE_SEL", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV43TFCorFE_Sel), 1, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "vTFCORFORMATO", AV44TFCorFormato);
         GxWebStd.gx_hidden_field( context, "vTFCORFORMATO_SEL", AV45TFCorFormato_Sel);
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
         GxWebStd.gx_boolean_hidden_field( context, "vDYNAMICFILTERSIGNOREFIRST", AV33DynamicFiltersIgnoreFirst);
         GxWebStd.gx_boolean_hidden_field( context, "vDYNAMICFILTERSREMOVING", AV32DynamicFiltersRemoving);
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
            WE0F2( ) ;
            context.WriteHtmlText( "</div>") ;
         }
      }

      public override void DispatchEvents( )
      {
         EVT0F2( ) ;
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
         return formatLink("seguridad.numeraciondocumentosww.aspx")  ;
      }

      public override string GetPgmname( )
      {
         return "Seguridad.NumeracionDocumentosWW" ;
      }

      public override string GetPgmdesc( )
      {
         return " Numeracion Documentos" ;
      }

      protected void WB0F0( )
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
            GxWebStd.gx_button_ctrl( context, bttBtninsert_Internalname, "gx.evt.setGridEvt("+StringUtil.Str( (decimal)(119), 3, 0)+","+"null"+");", "Agregar", bttBtninsert_Jsonclick, 5, "Agregar", "", StyleString, ClassString, 1, 1, "standard", "'"+""+"'"+",false,"+"'"+"E\\'DOINSERT\\'."+"'", TempTags, "", context.GetButtonType( ), "HLP_Seguridad\\NumeracionDocumentosWW.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "left", "top", "", "", "div");
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 21,'',false,'',0)\"";
            ClassString = "ColumnsSelector";
            StyleString = "";
            GxWebStd.gx_button_ctrl( context, bttBtnagexport_Internalname, "gx.evt.setGridEvt("+StringUtil.Str( (decimal)(119), 3, 0)+","+"null"+");", "Reportes", bttBtnagexport_Jsonclick, 0, "Reportes", "", StyleString, ClassString, 1, 0, "standard", "'"+""+"'"+",false,"+"'"+""+"'", TempTags, "", context.GetButtonType( ), "HLP_Seguridad\\NumeracionDocumentosWW.htm");
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
            wb_table1_25_0F2( true) ;
         }
         else
         {
            wb_table1_25_0F2( false) ;
         }
         return  ;
      }

      protected void wb_table1_25_0F2e( bool wbgen )
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
               context.WriteHtmlText( "<div id=\""+"GridContainer"+"DivS\" data-gxgridid=\"119\">") ;
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
               context.SendWebValue( "Documento") ;
               context.WriteHtmlTextNl( "</th>") ;
               context.WriteHtmlText( "<th align=\""+"right"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+""+""+"\" "+">") ;
               context.SendWebValue( "N° Documento") ;
               context.WriteHtmlTextNl( "</th>") ;
               context.WriteHtmlText( "<th align=\""+"left"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+""+""+"\" "+">") ;
               context.SendWebValue( "Serie") ;
               context.WriteHtmlTextNl( "</th>") ;
               context.WriteHtmlText( "<th align=\""+""+"\" "+" nowrap=\"nowrap\" "+" class=\""+"AttributeCheckBox"+"\" "+" style=\""+""+""+"\" "+">") ;
               context.SendWebValue( "Electronica") ;
               context.WriteHtmlTextNl( "</th>") ;
               context.WriteHtmlText( "<th align=\""+"left"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+""+""+"\" "+">") ;
               context.SendWebValue( "Formato") ;
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
               GridColumn.AddObjectProperty("Value", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV51GridActions), 4, 0, ".", "")));
               GridContainer.AddColumnProperties(GridColumn);
               GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
               GridColumn.AddObjectProperty("Value", StringUtil.RTrim( A339CorDoc));
               GridContainer.AddColumnProperties(GridColumn);
               GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
               GridColumn.AddObjectProperty("Value", StringUtil.LTrim( StringUtil.NToC( (decimal)(A1377NumDoc), 10, 0, ".", "")));
               GridColumn.AddObjectProperty("Link", StringUtil.RTrim( edtNumDoc_Link));
               GridContainer.AddColumnProperties(GridColumn);
               GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
               GridColumn.AddObjectProperty("Value", StringUtil.RTrim( A340CorSerie));
               GridContainer.AddColumnProperties(GridColumn);
               GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
               GridColumn.AddObjectProperty("Value", StringUtil.LTrim( StringUtil.NToC( (decimal)(A756CorFE), 1, 0, ".", "")));
               GridContainer.AddColumnProperties(GridColumn);
               GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
               GridColumn.AddObjectProperty("Value", A757CorFormato);
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
         if ( wbEnd == 119 )
         {
            wbEnd = 0;
            nRC_GXsfl_119 = (int)(nGXsfl_119_idx-1);
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
            ucGridpaginationbar.SetProperty("CurrentPage", AV48GridCurrentPage);
            ucGridpaginationbar.SetProperty("PageCount", AV49GridPageCount);
            ucGridpaginationbar.SetProperty("AppliedFilters", AV50GridAppliedFilters);
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
            ucDdo_agexport.SetProperty("DropDownOptionsData", AV52AGExportData);
            ucDdo_agexport.Render(context, "dvelop.gxbootstrap.ddoregular", Ddo_agexport_Internalname, "DDO_AGEXPORTContainer");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblJsdynamicfilters_Internalname, lblJsdynamicfilters_Caption, "", "", lblJsdynamicfilters_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "", 0, "", 1, 1, 0, 1, "HLP_Seguridad\\NumeracionDocumentosWW.htm");
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
            ucDdo_grid.SetProperty("DataListFixedValues", Ddo_grid_Datalistfixedvalues);
            ucDdo_grid.SetProperty("DataListProc", Ddo_grid_Datalistproc);
            ucDdo_grid.SetProperty("DropDownOptionsTitleSettingsIcons", AV46DDO_TitleSettingsIcons);
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
         if ( wbEnd == 119 )
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

      protected void START0F2( )
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
            Form.Meta.addItem("description", " Numeracion Documentos", 0) ;
         }
         context.wjLoc = "";
         context.nUserReturn = 0;
         context.wbHandled = 0;
         if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
         {
         }
         wbErr = false;
         STRUP0F0( ) ;
      }

      protected void WS0F2( )
      {
         START0F2( ) ;
         EVT0F2( ) ;
      }

      protected void EVT0F2( )
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
                              E110F2 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "GRIDPAGINATIONBAR.CHANGEROWSPERPAGE") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              E120F2 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "DDO_AGEXPORT.ONOPTIONCLICKED") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              E130F2 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "DDO_GRID.ONOPTIONCLICKED") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              E140F2 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "'REMOVEDYNAMICFILTERS1'") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              /* Execute user event: 'RemoveDynamicFilters1' */
                              E150F2 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "'REMOVEDYNAMICFILTERS2'") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              /* Execute user event: 'RemoveDynamicFilters2' */
                              E160F2 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "'REMOVEDYNAMICFILTERS3'") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              /* Execute user event: 'RemoveDynamicFilters3' */
                              E170F2 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "'DOINSERT'") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              /* Execute user event: 'DoInsert' */
                              E180F2 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "'ADDDYNAMICFILTERS1'") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              /* Execute user event: 'AddDynamicFilters1' */
                              E190F2 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "VDYNAMICFILTERSSELECTOR1.CLICK") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              E200F2 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "'ADDDYNAMICFILTERS2'") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              /* Execute user event: 'AddDynamicFilters2' */
                              E210F2 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "VDYNAMICFILTERSSELECTOR2.CLICK") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              E220F2 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "VDYNAMICFILTERSSELECTOR3.CLICK") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              E230F2 ();
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
                              nGXsfl_119_idx = (int)(NumberUtil.Val( sEvtType, "."));
                              sGXsfl_119_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_119_idx), 4, 0), 4, "0");
                              SubsflControlProps_1192( ) ;
                              cmbavGridactions.Name = cmbavGridactions_Internalname;
                              cmbavGridactions.CurrentValue = cgiGet( cmbavGridactions_Internalname);
                              AV51GridActions = (short)(NumberUtil.Val( cgiGet( cmbavGridactions_Internalname), "."));
                              AssignAttri("", false, cmbavGridactions_Internalname, StringUtil.LTrimStr( (decimal)(AV51GridActions), 4, 0));
                              A339CorDoc = cgiGet( edtCorDoc_Internalname);
                              A1377NumDoc = (long)(context.localUtil.CToN( cgiGet( edtNumDoc_Internalname), ".", ","));
                              A340CorSerie = cgiGet( edtCorSerie_Internalname);
                              A756CorFE = (short)(((StringUtil.StrCmp(cgiGet( chkCorFE_Internalname), "1")==0) ? 1 : 0));
                              A757CorFormato = cgiGet( edtCorFormato_Internalname);
                              sEvtType = StringUtil.Right( sEvt, 1);
                              if ( StringUtil.StrCmp(sEvtType, ".") == 0 )
                              {
                                 sEvt = StringUtil.Left( sEvt, (short)(StringUtil.Len( sEvt)-1));
                                 if ( StringUtil.StrCmp(sEvt, "START") == 0 )
                                 {
                                    context.wbHandled = 1;
                                    dynload_actions( ) ;
                                    /* Execute user event: Start */
                                    E240F2 ();
                                 }
                                 else if ( StringUtil.StrCmp(sEvt, "REFRESH") == 0 )
                                 {
                                    context.wbHandled = 1;
                                    dynload_actions( ) ;
                                    /* Execute user event: Refresh */
                                    E250F2 ();
                                 }
                                 else if ( StringUtil.StrCmp(sEvt, "GRID.LOAD") == 0 )
                                 {
                                    context.wbHandled = 1;
                                    dynload_actions( ) ;
                                    E260F2 ();
                                 }
                                 else if ( StringUtil.StrCmp(sEvt, "VGRIDACTIONS.CLICK") == 0 )
                                 {
                                    context.wbHandled = 1;
                                    dynload_actions( ) ;
                                    E270F2 ();
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
                                       /* Set Refresh If Cordoc1 Changed */
                                       if ( StringUtil.StrCmp(cgiGet( "GXH_vCORDOC1"), AV17CorDoc1) != 0 )
                                       {
                                          Rfr0gs = true;
                                       }
                                       /* Set Refresh If Numdoc1 Changed */
                                       if ( ( context.localUtil.CToN( cgiGet( "GXH_vNUMDOC1"), ".", ",") != Convert.ToDecimal( AV18NumDoc1 )) )
                                       {
                                          Rfr0gs = true;
                                       }
                                       /* Set Refresh If Corserie1 Changed */
                                       if ( StringUtil.StrCmp(cgiGet( "GXH_vCORSERIE1"), AV19CorSerie1) != 0 )
                                       {
                                          Rfr0gs = true;
                                       }
                                       /* Set Refresh If Dynamicfiltersselector2 Changed */
                                       if ( StringUtil.StrCmp(cgiGet( "GXH_vDYNAMICFILTERSSELECTOR2"), AV21DynamicFiltersSelector2) != 0 )
                                       {
                                          Rfr0gs = true;
                                       }
                                       /* Set Refresh If Dynamicfiltersoperator2 Changed */
                                       if ( ( context.localUtil.CToN( cgiGet( "GXH_vDYNAMICFILTERSOPERATOR2"), ".", ",") != Convert.ToDecimal( AV22DynamicFiltersOperator2 )) )
                                       {
                                          Rfr0gs = true;
                                       }
                                       /* Set Refresh If Cordoc2 Changed */
                                       if ( StringUtil.StrCmp(cgiGet( "GXH_vCORDOC2"), AV23CorDoc2) != 0 )
                                       {
                                          Rfr0gs = true;
                                       }
                                       /* Set Refresh If Numdoc2 Changed */
                                       if ( ( context.localUtil.CToN( cgiGet( "GXH_vNUMDOC2"), ".", ",") != Convert.ToDecimal( AV24NumDoc2 )) )
                                       {
                                          Rfr0gs = true;
                                       }
                                       /* Set Refresh If Corserie2 Changed */
                                       if ( StringUtil.StrCmp(cgiGet( "GXH_vCORSERIE2"), AV25CorSerie2) != 0 )
                                       {
                                          Rfr0gs = true;
                                       }
                                       /* Set Refresh If Dynamicfiltersselector3 Changed */
                                       if ( StringUtil.StrCmp(cgiGet( "GXH_vDYNAMICFILTERSSELECTOR3"), AV27DynamicFiltersSelector3) != 0 )
                                       {
                                          Rfr0gs = true;
                                       }
                                       /* Set Refresh If Dynamicfiltersoperator3 Changed */
                                       if ( ( context.localUtil.CToN( cgiGet( "GXH_vDYNAMICFILTERSOPERATOR3"), ".", ",") != Convert.ToDecimal( AV28DynamicFiltersOperator3 )) )
                                       {
                                          Rfr0gs = true;
                                       }
                                       /* Set Refresh If Cordoc3 Changed */
                                       if ( StringUtil.StrCmp(cgiGet( "GXH_vCORDOC3"), AV29CorDoc3) != 0 )
                                       {
                                          Rfr0gs = true;
                                       }
                                       /* Set Refresh If Numdoc3 Changed */
                                       if ( ( context.localUtil.CToN( cgiGet( "GXH_vNUMDOC3"), ".", ",") != Convert.ToDecimal( AV30NumDoc3 )) )
                                       {
                                          Rfr0gs = true;
                                       }
                                       /* Set Refresh If Corserie3 Changed */
                                       if ( StringUtil.StrCmp(cgiGet( "GXH_vCORSERIE3"), AV31CorSerie3) != 0 )
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

      protected void WE0F2( )
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

      protected void PA0F2( )
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
         SubsflControlProps_1192( ) ;
         while ( nGXsfl_119_idx <= nRC_GXsfl_119 )
         {
            sendrow_1192( ) ;
            nGXsfl_119_idx = ((subGrid_Islastpage==1)&&(nGXsfl_119_idx+1>subGrid_fnc_Recordsperpage( )) ? 1 : nGXsfl_119_idx+1);
            sGXsfl_119_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_119_idx), 4, 0), 4, "0");
            SubsflControlProps_1192( ) ;
         }
         AddString( context.httpAjaxContext.getJSONContainerResponse( GridContainer)) ;
         /* End function gxnrGrid_newrow */
      }

      protected void gxgrGrid_refresh( int subGrid_Rows ,
                                       string AV15DynamicFiltersSelector1 ,
                                       short AV16DynamicFiltersOperator1 ,
                                       string AV17CorDoc1 ,
                                       long AV18NumDoc1 ,
                                       string AV19CorSerie1 ,
                                       string AV21DynamicFiltersSelector2 ,
                                       short AV22DynamicFiltersOperator2 ,
                                       string AV23CorDoc2 ,
                                       long AV24NumDoc2 ,
                                       string AV25CorSerie2 ,
                                       string AV27DynamicFiltersSelector3 ,
                                       short AV28DynamicFiltersOperator3 ,
                                       string AV29CorDoc3 ,
                                       long AV30NumDoc3 ,
                                       string AV31CorSerie3 ,
                                       bool AV20DynamicFiltersEnabled2 ,
                                       bool AV26DynamicFiltersEnabled3 ,
                                       string AV56Pgmname ,
                                       string AV37TFCorDoc ,
                                       string AV38TFCorDoc_Sel ,
                                       long AV39TFNumDoc ,
                                       long AV40TFNumDoc_To ,
                                       string AV41TFCorSerie ,
                                       string AV42TFCorSerie_Sel ,
                                       short AV43TFCorFE_Sel ,
                                       string AV44TFCorFormato ,
                                       string AV45TFCorFormato_Sel ,
                                       short AV13OrderedBy ,
                                       bool AV14OrderedDsc ,
                                       GeneXus.Programs.wwpbaseobjects.SdtWWPGridState AV10GridState ,
                                       bool AV33DynamicFiltersIgnoreFirst ,
                                       bool AV32DynamicFiltersRemoving )
      {
         initialize_formulas( ) ;
         GxWebStd.set_html_headers( context, 0, "", "");
         /* Execute user event: Refresh */
         E250F2 ();
         GRID_nCurrentRecord = 0;
         RF0F2( ) ;
         GXKey = Crypto.GetSiteKey( );
         send_integrity_footer_hashes( ) ;
         GXKey = Crypto.GetSiteKey( );
         /* End function gxgrGrid_refresh */
      }

      protected void send_integrity_hashes( )
      {
         GxWebStd.gx_hidden_field( context, "gxhash_CORDOC", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( A339CorDoc, "")), context));
         GxWebStd.gx_hidden_field( context, "CORDOC", StringUtil.RTrim( A339CorDoc));
         GxWebStd.gx_hidden_field( context, "gxhash_CORSERIE", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( A340CorSerie, "")), context));
         GxWebStd.gx_hidden_field( context, "CORSERIE", StringUtil.RTrim( A340CorSerie));
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
         if ( cmbavCordoc1.ItemCount > 0 )
         {
            AV17CorDoc1 = cmbavCordoc1.getValidValue(AV17CorDoc1);
            AssignAttri("", false, "AV17CorDoc1", AV17CorDoc1);
         }
         if ( context.isAjaxRequest( ) )
         {
            cmbavCordoc1.CurrentValue = StringUtil.RTrim( AV17CorDoc1);
            AssignProp("", false, cmbavCordoc1_Internalname, "Values", cmbavCordoc1.ToJavascriptSource(), true);
         }
         if ( cmbavDynamicfiltersselector2.ItemCount > 0 )
         {
            AV21DynamicFiltersSelector2 = cmbavDynamicfiltersselector2.getValidValue(AV21DynamicFiltersSelector2);
            AssignAttri("", false, "AV21DynamicFiltersSelector2", AV21DynamicFiltersSelector2);
         }
         if ( context.isAjaxRequest( ) )
         {
            cmbavDynamicfiltersselector2.CurrentValue = StringUtil.RTrim( AV21DynamicFiltersSelector2);
            AssignProp("", false, cmbavDynamicfiltersselector2_Internalname, "Values", cmbavDynamicfiltersselector2.ToJavascriptSource(), true);
         }
         if ( cmbavDynamicfiltersoperator2.ItemCount > 0 )
         {
            AV22DynamicFiltersOperator2 = (short)(NumberUtil.Val( cmbavDynamicfiltersoperator2.getValidValue(StringUtil.Trim( StringUtil.Str( (decimal)(AV22DynamicFiltersOperator2), 4, 0))), "."));
            AssignAttri("", false, "AV22DynamicFiltersOperator2", StringUtil.LTrimStr( (decimal)(AV22DynamicFiltersOperator2), 4, 0));
         }
         if ( context.isAjaxRequest( ) )
         {
            cmbavDynamicfiltersoperator2.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV22DynamicFiltersOperator2), 4, 0));
            AssignProp("", false, cmbavDynamicfiltersoperator2_Internalname, "Values", cmbavDynamicfiltersoperator2.ToJavascriptSource(), true);
         }
         if ( cmbavCordoc2.ItemCount > 0 )
         {
            AV23CorDoc2 = cmbavCordoc2.getValidValue(AV23CorDoc2);
            AssignAttri("", false, "AV23CorDoc2", AV23CorDoc2);
         }
         if ( context.isAjaxRequest( ) )
         {
            cmbavCordoc2.CurrentValue = StringUtil.RTrim( AV23CorDoc2);
            AssignProp("", false, cmbavCordoc2_Internalname, "Values", cmbavCordoc2.ToJavascriptSource(), true);
         }
         if ( cmbavDynamicfiltersselector3.ItemCount > 0 )
         {
            AV27DynamicFiltersSelector3 = cmbavDynamicfiltersselector3.getValidValue(AV27DynamicFiltersSelector3);
            AssignAttri("", false, "AV27DynamicFiltersSelector3", AV27DynamicFiltersSelector3);
         }
         if ( context.isAjaxRequest( ) )
         {
            cmbavDynamicfiltersselector3.CurrentValue = StringUtil.RTrim( AV27DynamicFiltersSelector3);
            AssignProp("", false, cmbavDynamicfiltersselector3_Internalname, "Values", cmbavDynamicfiltersselector3.ToJavascriptSource(), true);
         }
         if ( cmbavDynamicfiltersoperator3.ItemCount > 0 )
         {
            AV28DynamicFiltersOperator3 = (short)(NumberUtil.Val( cmbavDynamicfiltersoperator3.getValidValue(StringUtil.Trim( StringUtil.Str( (decimal)(AV28DynamicFiltersOperator3), 4, 0))), "."));
            AssignAttri("", false, "AV28DynamicFiltersOperator3", StringUtil.LTrimStr( (decimal)(AV28DynamicFiltersOperator3), 4, 0));
         }
         if ( context.isAjaxRequest( ) )
         {
            cmbavDynamicfiltersoperator3.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV28DynamicFiltersOperator3), 4, 0));
            AssignProp("", false, cmbavDynamicfiltersoperator3_Internalname, "Values", cmbavDynamicfiltersoperator3.ToJavascriptSource(), true);
         }
         if ( cmbavCordoc3.ItemCount > 0 )
         {
            AV29CorDoc3 = cmbavCordoc3.getValidValue(AV29CorDoc3);
            AssignAttri("", false, "AV29CorDoc3", AV29CorDoc3);
         }
         if ( context.isAjaxRequest( ) )
         {
            cmbavCordoc3.CurrentValue = StringUtil.RTrim( AV29CorDoc3);
            AssignProp("", false, cmbavCordoc3_Internalname, "Values", cmbavCordoc3.ToJavascriptSource(), true);
         }
      }

      public void Refresh( )
      {
         send_integrity_hashes( ) ;
         RF0F2( ) ;
         if ( isFullAjaxMode( ) )
         {
            send_integrity_footer_hashes( ) ;
         }
      }

      protected void initialize_formulas( )
      {
         /* GeneXus formulas. */
         AV56Pgmname = "Seguridad.NumeracionDocumentosWW";
         context.Gx_err = 0;
      }

      protected void RF0F2( )
      {
         initialize_formulas( ) ;
         clear_multi_value_controls( ) ;
         if ( isAjaxCallMode( ) )
         {
            GridContainer.ClearRows();
         }
         wbStart = 119;
         /* Execute user event: Refresh */
         E250F2 ();
         nGXsfl_119_idx = 1;
         sGXsfl_119_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_119_idx), 4, 0), 4, "0");
         SubsflControlProps_1192( ) ;
         bGXsfl_119_Refreshing = true;
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
            SubsflControlProps_1192( ) ;
            GXPagingFrom2 = (int)(((subGrid_Rows==0) ? 0 : GRID_nFirstRecordOnPage));
            GXPagingTo2 = ((subGrid_Rows==0) ? 10000 : subGrid_fnc_Recordsperpage( )+1);
            pr_default.dynParam(0, new Object[]{ new Object[]{
                                                 AV57Seguridad_numeraciondocumentoswwds_1_dynamicfiltersselector1 ,
                                                 AV59Seguridad_numeraciondocumentoswwds_3_cordoc1 ,
                                                 AV58Seguridad_numeraciondocumentoswwds_2_dynamicfiltersoperator1 ,
                                                 AV60Seguridad_numeraciondocumentoswwds_4_numdoc1 ,
                                                 AV61Seguridad_numeraciondocumentoswwds_5_corserie1 ,
                                                 AV62Seguridad_numeraciondocumentoswwds_6_dynamicfiltersenabled2 ,
                                                 AV63Seguridad_numeraciondocumentoswwds_7_dynamicfiltersselector2 ,
                                                 AV65Seguridad_numeraciondocumentoswwds_9_cordoc2 ,
                                                 AV64Seguridad_numeraciondocumentoswwds_8_dynamicfiltersoperator2 ,
                                                 AV66Seguridad_numeraciondocumentoswwds_10_numdoc2 ,
                                                 AV67Seguridad_numeraciondocumentoswwds_11_corserie2 ,
                                                 AV68Seguridad_numeraciondocumentoswwds_12_dynamicfiltersenabled3 ,
                                                 AV69Seguridad_numeraciondocumentoswwds_13_dynamicfiltersselector3 ,
                                                 AV71Seguridad_numeraciondocumentoswwds_15_cordoc3 ,
                                                 AV70Seguridad_numeraciondocumentoswwds_14_dynamicfiltersoperator3 ,
                                                 AV72Seguridad_numeraciondocumentoswwds_16_numdoc3 ,
                                                 AV73Seguridad_numeraciondocumentoswwds_17_corserie3 ,
                                                 AV75Seguridad_numeraciondocumentoswwds_19_tfcordoc_sel ,
                                                 AV74Seguridad_numeraciondocumentoswwds_18_tfcordoc ,
                                                 AV76Seguridad_numeraciondocumentoswwds_20_tfnumdoc ,
                                                 AV77Seguridad_numeraciondocumentoswwds_21_tfnumdoc_to ,
                                                 AV79Seguridad_numeraciondocumentoswwds_23_tfcorserie_sel ,
                                                 AV78Seguridad_numeraciondocumentoswwds_22_tfcorserie ,
                                                 AV80Seguridad_numeraciondocumentoswwds_24_tfcorfe_sel ,
                                                 AV82Seguridad_numeraciondocumentoswwds_26_tfcorformato_sel ,
                                                 AV81Seguridad_numeraciondocumentoswwds_25_tfcorformato ,
                                                 A339CorDoc ,
                                                 A1377NumDoc ,
                                                 A340CorSerie ,
                                                 A756CorFE ,
                                                 A757CorFormato ,
                                                 AV13OrderedBy ,
                                                 AV14OrderedDsc } ,
                                                 new int[]{
                                                 TypeConstants.SHORT, TypeConstants.LONG, TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.LONG, TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.LONG, TypeConstants.LONG, TypeConstants.LONG,
                                                 TypeConstants.SHORT, TypeConstants.LONG, TypeConstants.SHORT, TypeConstants.SHORT, TypeConstants.BOOLEAN
                                                 }
            });
            lV61Seguridad_numeraciondocumentoswwds_5_corserie1 = StringUtil.PadR( StringUtil.RTrim( AV61Seguridad_numeraciondocumentoswwds_5_corserie1), 4, "%");
            lV61Seguridad_numeraciondocumentoswwds_5_corserie1 = StringUtil.PadR( StringUtil.RTrim( AV61Seguridad_numeraciondocumentoswwds_5_corserie1), 4, "%");
            lV67Seguridad_numeraciondocumentoswwds_11_corserie2 = StringUtil.PadR( StringUtil.RTrim( AV67Seguridad_numeraciondocumentoswwds_11_corserie2), 4, "%");
            lV67Seguridad_numeraciondocumentoswwds_11_corserie2 = StringUtil.PadR( StringUtil.RTrim( AV67Seguridad_numeraciondocumentoswwds_11_corserie2), 4, "%");
            lV73Seguridad_numeraciondocumentoswwds_17_corserie3 = StringUtil.PadR( StringUtil.RTrim( AV73Seguridad_numeraciondocumentoswwds_17_corserie3), 4, "%");
            lV73Seguridad_numeraciondocumentoswwds_17_corserie3 = StringUtil.PadR( StringUtil.RTrim( AV73Seguridad_numeraciondocumentoswwds_17_corserie3), 4, "%");
            lV74Seguridad_numeraciondocumentoswwds_18_tfcordoc = StringUtil.PadR( StringUtil.RTrim( AV74Seguridad_numeraciondocumentoswwds_18_tfcordoc), 10, "%");
            lV78Seguridad_numeraciondocumentoswwds_22_tfcorserie = StringUtil.PadR( StringUtil.RTrim( AV78Seguridad_numeraciondocumentoswwds_22_tfcorserie), 4, "%");
            lV81Seguridad_numeraciondocumentoswwds_25_tfcorformato = StringUtil.Concat( StringUtil.RTrim( AV81Seguridad_numeraciondocumentoswwds_25_tfcorformato), "%", "");
            /* Using cursor H000F2 */
            pr_default.execute(0, new Object[] {AV59Seguridad_numeraciondocumentoswwds_3_cordoc1, AV60Seguridad_numeraciondocumentoswwds_4_numdoc1, AV60Seguridad_numeraciondocumentoswwds_4_numdoc1, AV60Seguridad_numeraciondocumentoswwds_4_numdoc1, lV61Seguridad_numeraciondocumentoswwds_5_corserie1, lV61Seguridad_numeraciondocumentoswwds_5_corserie1, AV65Seguridad_numeraciondocumentoswwds_9_cordoc2, AV66Seguridad_numeraciondocumentoswwds_10_numdoc2, AV66Seguridad_numeraciondocumentoswwds_10_numdoc2, AV66Seguridad_numeraciondocumentoswwds_10_numdoc2, lV67Seguridad_numeraciondocumentoswwds_11_corserie2, lV67Seguridad_numeraciondocumentoswwds_11_corserie2, AV71Seguridad_numeraciondocumentoswwds_15_cordoc3, AV72Seguridad_numeraciondocumentoswwds_16_numdoc3, AV72Seguridad_numeraciondocumentoswwds_16_numdoc3, AV72Seguridad_numeraciondocumentoswwds_16_numdoc3, lV73Seguridad_numeraciondocumentoswwds_17_corserie3, lV73Seguridad_numeraciondocumentoswwds_17_corserie3, lV74Seguridad_numeraciondocumentoswwds_18_tfcordoc, AV75Seguridad_numeraciondocumentoswwds_19_tfcordoc_sel, AV76Seguridad_numeraciondocumentoswwds_20_tfnumdoc, AV77Seguridad_numeraciondocumentoswwds_21_tfnumdoc_to, lV78Seguridad_numeraciondocumentoswwds_22_tfcorserie, AV79Seguridad_numeraciondocumentoswwds_23_tfcorserie_sel, lV81Seguridad_numeraciondocumentoswwds_25_tfcorformato, AV82Seguridad_numeraciondocumentoswwds_26_tfcorformato_sel, GXPagingFrom2, GXPagingTo2, GXPagingTo2});
            nGXsfl_119_idx = 1;
            sGXsfl_119_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_119_idx), 4, 0), 4, "0");
            SubsflControlProps_1192( ) ;
            while ( ( (pr_default.getStatus(0) != 101) ) && ( ( ( subGrid_Rows == 0 ) || ( GRID_nCurrentRecord < subGrid_fnc_Recordsperpage( ) ) ) ) )
            {
               A757CorFormato = H000F2_A757CorFormato[0];
               A756CorFE = H000F2_A756CorFE[0];
               A340CorSerie = H000F2_A340CorSerie[0];
               A1377NumDoc = H000F2_A1377NumDoc[0];
               A339CorDoc = H000F2_A339CorDoc[0];
               E260F2 ();
               pr_default.readNext(0);
            }
            GRID_nEOF = (short)(((pr_default.getStatus(0) == 101) ? 1 : 0));
            GxWebStd.gx_hidden_field( context, "GRID_nEOF", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRID_nEOF), 1, 0, ".", "")));
            pr_default.close(0);
            wbEnd = 119;
            WB0F0( ) ;
         }
         bGXsfl_119_Refreshing = true;
      }

      protected void send_integrity_lvl_hashes0F2( )
      {
         GxWebStd.gx_hidden_field( context, "vPGMNAME", StringUtil.RTrim( AV56Pgmname));
         GxWebStd.gx_hidden_field( context, "gxhash_vPGMNAME", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( AV56Pgmname, "")), context));
         GxWebStd.gx_hidden_field( context, "gxhash_CORDOC"+"_"+sGXsfl_119_idx, GetSecureSignedToken( sGXsfl_119_idx, StringUtil.RTrim( context.localUtil.Format( A339CorDoc, "")), context));
         GxWebStd.gx_hidden_field( context, "gxhash_CORSERIE"+"_"+sGXsfl_119_idx, GetSecureSignedToken( sGXsfl_119_idx, StringUtil.RTrim( context.localUtil.Format( A340CorSerie, "")), context));
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
         AV57Seguridad_numeraciondocumentoswwds_1_dynamicfiltersselector1 = AV15DynamicFiltersSelector1;
         AV58Seguridad_numeraciondocumentoswwds_2_dynamicfiltersoperator1 = AV16DynamicFiltersOperator1;
         AV59Seguridad_numeraciondocumentoswwds_3_cordoc1 = AV17CorDoc1;
         AV60Seguridad_numeraciondocumentoswwds_4_numdoc1 = AV18NumDoc1;
         AV61Seguridad_numeraciondocumentoswwds_5_corserie1 = AV19CorSerie1;
         AV62Seguridad_numeraciondocumentoswwds_6_dynamicfiltersenabled2 = AV20DynamicFiltersEnabled2;
         AV63Seguridad_numeraciondocumentoswwds_7_dynamicfiltersselector2 = AV21DynamicFiltersSelector2;
         AV64Seguridad_numeraciondocumentoswwds_8_dynamicfiltersoperator2 = AV22DynamicFiltersOperator2;
         AV65Seguridad_numeraciondocumentoswwds_9_cordoc2 = AV23CorDoc2;
         AV66Seguridad_numeraciondocumentoswwds_10_numdoc2 = AV24NumDoc2;
         AV67Seguridad_numeraciondocumentoswwds_11_corserie2 = AV25CorSerie2;
         AV68Seguridad_numeraciondocumentoswwds_12_dynamicfiltersenabled3 = AV26DynamicFiltersEnabled3;
         AV69Seguridad_numeraciondocumentoswwds_13_dynamicfiltersselector3 = AV27DynamicFiltersSelector3;
         AV70Seguridad_numeraciondocumentoswwds_14_dynamicfiltersoperator3 = AV28DynamicFiltersOperator3;
         AV71Seguridad_numeraciondocumentoswwds_15_cordoc3 = AV29CorDoc3;
         AV72Seguridad_numeraciondocumentoswwds_16_numdoc3 = AV30NumDoc3;
         AV73Seguridad_numeraciondocumentoswwds_17_corserie3 = AV31CorSerie3;
         AV74Seguridad_numeraciondocumentoswwds_18_tfcordoc = AV37TFCorDoc;
         AV75Seguridad_numeraciondocumentoswwds_19_tfcordoc_sel = AV38TFCorDoc_Sel;
         AV76Seguridad_numeraciondocumentoswwds_20_tfnumdoc = AV39TFNumDoc;
         AV77Seguridad_numeraciondocumentoswwds_21_tfnumdoc_to = AV40TFNumDoc_To;
         AV78Seguridad_numeraciondocumentoswwds_22_tfcorserie = AV41TFCorSerie;
         AV79Seguridad_numeraciondocumentoswwds_23_tfcorserie_sel = AV42TFCorSerie_Sel;
         AV80Seguridad_numeraciondocumentoswwds_24_tfcorfe_sel = AV43TFCorFE_Sel;
         AV81Seguridad_numeraciondocumentoswwds_25_tfcorformato = AV44TFCorFormato;
         AV82Seguridad_numeraciondocumentoswwds_26_tfcorformato_sel = AV45TFCorFormato_Sel;
         pr_default.dynParam(1, new Object[]{ new Object[]{
                                              AV57Seguridad_numeraciondocumentoswwds_1_dynamicfiltersselector1 ,
                                              AV59Seguridad_numeraciondocumentoswwds_3_cordoc1 ,
                                              AV58Seguridad_numeraciondocumentoswwds_2_dynamicfiltersoperator1 ,
                                              AV60Seguridad_numeraciondocumentoswwds_4_numdoc1 ,
                                              AV61Seguridad_numeraciondocumentoswwds_5_corserie1 ,
                                              AV62Seguridad_numeraciondocumentoswwds_6_dynamicfiltersenabled2 ,
                                              AV63Seguridad_numeraciondocumentoswwds_7_dynamicfiltersselector2 ,
                                              AV65Seguridad_numeraciondocumentoswwds_9_cordoc2 ,
                                              AV64Seguridad_numeraciondocumentoswwds_8_dynamicfiltersoperator2 ,
                                              AV66Seguridad_numeraciondocumentoswwds_10_numdoc2 ,
                                              AV67Seguridad_numeraciondocumentoswwds_11_corserie2 ,
                                              AV68Seguridad_numeraciondocumentoswwds_12_dynamicfiltersenabled3 ,
                                              AV69Seguridad_numeraciondocumentoswwds_13_dynamicfiltersselector3 ,
                                              AV71Seguridad_numeraciondocumentoswwds_15_cordoc3 ,
                                              AV70Seguridad_numeraciondocumentoswwds_14_dynamicfiltersoperator3 ,
                                              AV72Seguridad_numeraciondocumentoswwds_16_numdoc3 ,
                                              AV73Seguridad_numeraciondocumentoswwds_17_corserie3 ,
                                              AV75Seguridad_numeraciondocumentoswwds_19_tfcordoc_sel ,
                                              AV74Seguridad_numeraciondocumentoswwds_18_tfcordoc ,
                                              AV76Seguridad_numeraciondocumentoswwds_20_tfnumdoc ,
                                              AV77Seguridad_numeraciondocumentoswwds_21_tfnumdoc_to ,
                                              AV79Seguridad_numeraciondocumentoswwds_23_tfcorserie_sel ,
                                              AV78Seguridad_numeraciondocumentoswwds_22_tfcorserie ,
                                              AV80Seguridad_numeraciondocumentoswwds_24_tfcorfe_sel ,
                                              AV82Seguridad_numeraciondocumentoswwds_26_tfcorformato_sel ,
                                              AV81Seguridad_numeraciondocumentoswwds_25_tfcorformato ,
                                              A339CorDoc ,
                                              A1377NumDoc ,
                                              A340CorSerie ,
                                              A756CorFE ,
                                              A757CorFormato ,
                                              AV13OrderedBy ,
                                              AV14OrderedDsc } ,
                                              new int[]{
                                              TypeConstants.SHORT, TypeConstants.LONG, TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.LONG, TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.LONG, TypeConstants.LONG, TypeConstants.LONG,
                                              TypeConstants.SHORT, TypeConstants.LONG, TypeConstants.SHORT, TypeConstants.SHORT, TypeConstants.BOOLEAN
                                              }
         });
         lV61Seguridad_numeraciondocumentoswwds_5_corserie1 = StringUtil.PadR( StringUtil.RTrim( AV61Seguridad_numeraciondocumentoswwds_5_corserie1), 4, "%");
         lV61Seguridad_numeraciondocumentoswwds_5_corserie1 = StringUtil.PadR( StringUtil.RTrim( AV61Seguridad_numeraciondocumentoswwds_5_corserie1), 4, "%");
         lV67Seguridad_numeraciondocumentoswwds_11_corserie2 = StringUtil.PadR( StringUtil.RTrim( AV67Seguridad_numeraciondocumentoswwds_11_corserie2), 4, "%");
         lV67Seguridad_numeraciondocumentoswwds_11_corserie2 = StringUtil.PadR( StringUtil.RTrim( AV67Seguridad_numeraciondocumentoswwds_11_corserie2), 4, "%");
         lV73Seguridad_numeraciondocumentoswwds_17_corserie3 = StringUtil.PadR( StringUtil.RTrim( AV73Seguridad_numeraciondocumentoswwds_17_corserie3), 4, "%");
         lV73Seguridad_numeraciondocumentoswwds_17_corserie3 = StringUtil.PadR( StringUtil.RTrim( AV73Seguridad_numeraciondocumentoswwds_17_corserie3), 4, "%");
         lV74Seguridad_numeraciondocumentoswwds_18_tfcordoc = StringUtil.PadR( StringUtil.RTrim( AV74Seguridad_numeraciondocumentoswwds_18_tfcordoc), 10, "%");
         lV78Seguridad_numeraciondocumentoswwds_22_tfcorserie = StringUtil.PadR( StringUtil.RTrim( AV78Seguridad_numeraciondocumentoswwds_22_tfcorserie), 4, "%");
         lV81Seguridad_numeraciondocumentoswwds_25_tfcorformato = StringUtil.Concat( StringUtil.RTrim( AV81Seguridad_numeraciondocumentoswwds_25_tfcorformato), "%", "");
         /* Using cursor H000F3 */
         pr_default.execute(1, new Object[] {AV59Seguridad_numeraciondocumentoswwds_3_cordoc1, AV60Seguridad_numeraciondocumentoswwds_4_numdoc1, AV60Seguridad_numeraciondocumentoswwds_4_numdoc1, AV60Seguridad_numeraciondocumentoswwds_4_numdoc1, lV61Seguridad_numeraciondocumentoswwds_5_corserie1, lV61Seguridad_numeraciondocumentoswwds_5_corserie1, AV65Seguridad_numeraciondocumentoswwds_9_cordoc2, AV66Seguridad_numeraciondocumentoswwds_10_numdoc2, AV66Seguridad_numeraciondocumentoswwds_10_numdoc2, AV66Seguridad_numeraciondocumentoswwds_10_numdoc2, lV67Seguridad_numeraciondocumentoswwds_11_corserie2, lV67Seguridad_numeraciondocumentoswwds_11_corserie2, AV71Seguridad_numeraciondocumentoswwds_15_cordoc3, AV72Seguridad_numeraciondocumentoswwds_16_numdoc3, AV72Seguridad_numeraciondocumentoswwds_16_numdoc3, AV72Seguridad_numeraciondocumentoswwds_16_numdoc3, lV73Seguridad_numeraciondocumentoswwds_17_corserie3, lV73Seguridad_numeraciondocumentoswwds_17_corserie3, lV74Seguridad_numeraciondocumentoswwds_18_tfcordoc, AV75Seguridad_numeraciondocumentoswwds_19_tfcordoc_sel, AV76Seguridad_numeraciondocumentoswwds_20_tfnumdoc, AV77Seguridad_numeraciondocumentoswwds_21_tfnumdoc_to, lV78Seguridad_numeraciondocumentoswwds_22_tfcorserie, AV79Seguridad_numeraciondocumentoswwds_23_tfcorserie_sel, lV81Seguridad_numeraciondocumentoswwds_25_tfcorformato, AV82Seguridad_numeraciondocumentoswwds_26_tfcorformato_sel});
         GRID_nRecordCount = H000F3_AGRID_nRecordCount[0];
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
         AV57Seguridad_numeraciondocumentoswwds_1_dynamicfiltersselector1 = AV15DynamicFiltersSelector1;
         AV58Seguridad_numeraciondocumentoswwds_2_dynamicfiltersoperator1 = AV16DynamicFiltersOperator1;
         AV59Seguridad_numeraciondocumentoswwds_3_cordoc1 = AV17CorDoc1;
         AV60Seguridad_numeraciondocumentoswwds_4_numdoc1 = AV18NumDoc1;
         AV61Seguridad_numeraciondocumentoswwds_5_corserie1 = AV19CorSerie1;
         AV62Seguridad_numeraciondocumentoswwds_6_dynamicfiltersenabled2 = AV20DynamicFiltersEnabled2;
         AV63Seguridad_numeraciondocumentoswwds_7_dynamicfiltersselector2 = AV21DynamicFiltersSelector2;
         AV64Seguridad_numeraciondocumentoswwds_8_dynamicfiltersoperator2 = AV22DynamicFiltersOperator2;
         AV65Seguridad_numeraciondocumentoswwds_9_cordoc2 = AV23CorDoc2;
         AV66Seguridad_numeraciondocumentoswwds_10_numdoc2 = AV24NumDoc2;
         AV67Seguridad_numeraciondocumentoswwds_11_corserie2 = AV25CorSerie2;
         AV68Seguridad_numeraciondocumentoswwds_12_dynamicfiltersenabled3 = AV26DynamicFiltersEnabled3;
         AV69Seguridad_numeraciondocumentoswwds_13_dynamicfiltersselector3 = AV27DynamicFiltersSelector3;
         AV70Seguridad_numeraciondocumentoswwds_14_dynamicfiltersoperator3 = AV28DynamicFiltersOperator3;
         AV71Seguridad_numeraciondocumentoswwds_15_cordoc3 = AV29CorDoc3;
         AV72Seguridad_numeraciondocumentoswwds_16_numdoc3 = AV30NumDoc3;
         AV73Seguridad_numeraciondocumentoswwds_17_corserie3 = AV31CorSerie3;
         AV74Seguridad_numeraciondocumentoswwds_18_tfcordoc = AV37TFCorDoc;
         AV75Seguridad_numeraciondocumentoswwds_19_tfcordoc_sel = AV38TFCorDoc_Sel;
         AV76Seguridad_numeraciondocumentoswwds_20_tfnumdoc = AV39TFNumDoc;
         AV77Seguridad_numeraciondocumentoswwds_21_tfnumdoc_to = AV40TFNumDoc_To;
         AV78Seguridad_numeraciondocumentoswwds_22_tfcorserie = AV41TFCorSerie;
         AV79Seguridad_numeraciondocumentoswwds_23_tfcorserie_sel = AV42TFCorSerie_Sel;
         AV80Seguridad_numeraciondocumentoswwds_24_tfcorfe_sel = AV43TFCorFE_Sel;
         AV81Seguridad_numeraciondocumentoswwds_25_tfcorformato = AV44TFCorFormato;
         AV82Seguridad_numeraciondocumentoswwds_26_tfcorformato_sel = AV45TFCorFormato_Sel;
         GRID_nFirstRecordOnPage = 0;
         GxWebStd.gx_hidden_field( context, "GRID_nFirstRecordOnPage", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRID_nFirstRecordOnPage), 15, 0, ".", "")));
         if ( isFullAjaxMode( ) )
         {
            gxgrGrid_refresh( subGrid_Rows, AV15DynamicFiltersSelector1, AV16DynamicFiltersOperator1, AV17CorDoc1, AV18NumDoc1, AV19CorSerie1, AV21DynamicFiltersSelector2, AV22DynamicFiltersOperator2, AV23CorDoc2, AV24NumDoc2, AV25CorSerie2, AV27DynamicFiltersSelector3, AV28DynamicFiltersOperator3, AV29CorDoc3, AV30NumDoc3, AV31CorSerie3, AV20DynamicFiltersEnabled2, AV26DynamicFiltersEnabled3, AV56Pgmname, AV37TFCorDoc, AV38TFCorDoc_Sel, AV39TFNumDoc, AV40TFNumDoc_To, AV41TFCorSerie, AV42TFCorSerie_Sel, AV43TFCorFE_Sel, AV44TFCorFormato, AV45TFCorFormato_Sel, AV13OrderedBy, AV14OrderedDsc, AV10GridState, AV33DynamicFiltersIgnoreFirst, AV32DynamicFiltersRemoving) ;
         }
         send_integrity_footer_hashes( ) ;
         return 0 ;
      }

      protected short subgrid_nextpage( )
      {
         AV57Seguridad_numeraciondocumentoswwds_1_dynamicfiltersselector1 = AV15DynamicFiltersSelector1;
         AV58Seguridad_numeraciondocumentoswwds_2_dynamicfiltersoperator1 = AV16DynamicFiltersOperator1;
         AV59Seguridad_numeraciondocumentoswwds_3_cordoc1 = AV17CorDoc1;
         AV60Seguridad_numeraciondocumentoswwds_4_numdoc1 = AV18NumDoc1;
         AV61Seguridad_numeraciondocumentoswwds_5_corserie1 = AV19CorSerie1;
         AV62Seguridad_numeraciondocumentoswwds_6_dynamicfiltersenabled2 = AV20DynamicFiltersEnabled2;
         AV63Seguridad_numeraciondocumentoswwds_7_dynamicfiltersselector2 = AV21DynamicFiltersSelector2;
         AV64Seguridad_numeraciondocumentoswwds_8_dynamicfiltersoperator2 = AV22DynamicFiltersOperator2;
         AV65Seguridad_numeraciondocumentoswwds_9_cordoc2 = AV23CorDoc2;
         AV66Seguridad_numeraciondocumentoswwds_10_numdoc2 = AV24NumDoc2;
         AV67Seguridad_numeraciondocumentoswwds_11_corserie2 = AV25CorSerie2;
         AV68Seguridad_numeraciondocumentoswwds_12_dynamicfiltersenabled3 = AV26DynamicFiltersEnabled3;
         AV69Seguridad_numeraciondocumentoswwds_13_dynamicfiltersselector3 = AV27DynamicFiltersSelector3;
         AV70Seguridad_numeraciondocumentoswwds_14_dynamicfiltersoperator3 = AV28DynamicFiltersOperator3;
         AV71Seguridad_numeraciondocumentoswwds_15_cordoc3 = AV29CorDoc3;
         AV72Seguridad_numeraciondocumentoswwds_16_numdoc3 = AV30NumDoc3;
         AV73Seguridad_numeraciondocumentoswwds_17_corserie3 = AV31CorSerie3;
         AV74Seguridad_numeraciondocumentoswwds_18_tfcordoc = AV37TFCorDoc;
         AV75Seguridad_numeraciondocumentoswwds_19_tfcordoc_sel = AV38TFCorDoc_Sel;
         AV76Seguridad_numeraciondocumentoswwds_20_tfnumdoc = AV39TFNumDoc;
         AV77Seguridad_numeraciondocumentoswwds_21_tfnumdoc_to = AV40TFNumDoc_To;
         AV78Seguridad_numeraciondocumentoswwds_22_tfcorserie = AV41TFCorSerie;
         AV79Seguridad_numeraciondocumentoswwds_23_tfcorserie_sel = AV42TFCorSerie_Sel;
         AV80Seguridad_numeraciondocumentoswwds_24_tfcorfe_sel = AV43TFCorFE_Sel;
         AV81Seguridad_numeraciondocumentoswwds_25_tfcorformato = AV44TFCorFormato;
         AV82Seguridad_numeraciondocumentoswwds_26_tfcorformato_sel = AV45TFCorFormato_Sel;
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
            gxgrGrid_refresh( subGrid_Rows, AV15DynamicFiltersSelector1, AV16DynamicFiltersOperator1, AV17CorDoc1, AV18NumDoc1, AV19CorSerie1, AV21DynamicFiltersSelector2, AV22DynamicFiltersOperator2, AV23CorDoc2, AV24NumDoc2, AV25CorSerie2, AV27DynamicFiltersSelector3, AV28DynamicFiltersOperator3, AV29CorDoc3, AV30NumDoc3, AV31CorSerie3, AV20DynamicFiltersEnabled2, AV26DynamicFiltersEnabled3, AV56Pgmname, AV37TFCorDoc, AV38TFCorDoc_Sel, AV39TFNumDoc, AV40TFNumDoc_To, AV41TFCorSerie, AV42TFCorSerie_Sel, AV43TFCorFE_Sel, AV44TFCorFormato, AV45TFCorFormato_Sel, AV13OrderedBy, AV14OrderedDsc, AV10GridState, AV33DynamicFiltersIgnoreFirst, AV32DynamicFiltersRemoving) ;
         }
         send_integrity_footer_hashes( ) ;
         return (short)(((GRID_nEOF==0) ? 0 : 2)) ;
      }

      protected short subgrid_previouspage( )
      {
         AV57Seguridad_numeraciondocumentoswwds_1_dynamicfiltersselector1 = AV15DynamicFiltersSelector1;
         AV58Seguridad_numeraciondocumentoswwds_2_dynamicfiltersoperator1 = AV16DynamicFiltersOperator1;
         AV59Seguridad_numeraciondocumentoswwds_3_cordoc1 = AV17CorDoc1;
         AV60Seguridad_numeraciondocumentoswwds_4_numdoc1 = AV18NumDoc1;
         AV61Seguridad_numeraciondocumentoswwds_5_corserie1 = AV19CorSerie1;
         AV62Seguridad_numeraciondocumentoswwds_6_dynamicfiltersenabled2 = AV20DynamicFiltersEnabled2;
         AV63Seguridad_numeraciondocumentoswwds_7_dynamicfiltersselector2 = AV21DynamicFiltersSelector2;
         AV64Seguridad_numeraciondocumentoswwds_8_dynamicfiltersoperator2 = AV22DynamicFiltersOperator2;
         AV65Seguridad_numeraciondocumentoswwds_9_cordoc2 = AV23CorDoc2;
         AV66Seguridad_numeraciondocumentoswwds_10_numdoc2 = AV24NumDoc2;
         AV67Seguridad_numeraciondocumentoswwds_11_corserie2 = AV25CorSerie2;
         AV68Seguridad_numeraciondocumentoswwds_12_dynamicfiltersenabled3 = AV26DynamicFiltersEnabled3;
         AV69Seguridad_numeraciondocumentoswwds_13_dynamicfiltersselector3 = AV27DynamicFiltersSelector3;
         AV70Seguridad_numeraciondocumentoswwds_14_dynamicfiltersoperator3 = AV28DynamicFiltersOperator3;
         AV71Seguridad_numeraciondocumentoswwds_15_cordoc3 = AV29CorDoc3;
         AV72Seguridad_numeraciondocumentoswwds_16_numdoc3 = AV30NumDoc3;
         AV73Seguridad_numeraciondocumentoswwds_17_corserie3 = AV31CorSerie3;
         AV74Seguridad_numeraciondocumentoswwds_18_tfcordoc = AV37TFCorDoc;
         AV75Seguridad_numeraciondocumentoswwds_19_tfcordoc_sel = AV38TFCorDoc_Sel;
         AV76Seguridad_numeraciondocumentoswwds_20_tfnumdoc = AV39TFNumDoc;
         AV77Seguridad_numeraciondocumentoswwds_21_tfnumdoc_to = AV40TFNumDoc_To;
         AV78Seguridad_numeraciondocumentoswwds_22_tfcorserie = AV41TFCorSerie;
         AV79Seguridad_numeraciondocumentoswwds_23_tfcorserie_sel = AV42TFCorSerie_Sel;
         AV80Seguridad_numeraciondocumentoswwds_24_tfcorfe_sel = AV43TFCorFE_Sel;
         AV81Seguridad_numeraciondocumentoswwds_25_tfcorformato = AV44TFCorFormato;
         AV82Seguridad_numeraciondocumentoswwds_26_tfcorformato_sel = AV45TFCorFormato_Sel;
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
            gxgrGrid_refresh( subGrid_Rows, AV15DynamicFiltersSelector1, AV16DynamicFiltersOperator1, AV17CorDoc1, AV18NumDoc1, AV19CorSerie1, AV21DynamicFiltersSelector2, AV22DynamicFiltersOperator2, AV23CorDoc2, AV24NumDoc2, AV25CorSerie2, AV27DynamicFiltersSelector3, AV28DynamicFiltersOperator3, AV29CorDoc3, AV30NumDoc3, AV31CorSerie3, AV20DynamicFiltersEnabled2, AV26DynamicFiltersEnabled3, AV56Pgmname, AV37TFCorDoc, AV38TFCorDoc_Sel, AV39TFNumDoc, AV40TFNumDoc_To, AV41TFCorSerie, AV42TFCorSerie_Sel, AV43TFCorFE_Sel, AV44TFCorFormato, AV45TFCorFormato_Sel, AV13OrderedBy, AV14OrderedDsc, AV10GridState, AV33DynamicFiltersIgnoreFirst, AV32DynamicFiltersRemoving) ;
         }
         send_integrity_footer_hashes( ) ;
         return 0 ;
      }

      protected short subgrid_lastpage( )
      {
         AV57Seguridad_numeraciondocumentoswwds_1_dynamicfiltersselector1 = AV15DynamicFiltersSelector1;
         AV58Seguridad_numeraciondocumentoswwds_2_dynamicfiltersoperator1 = AV16DynamicFiltersOperator1;
         AV59Seguridad_numeraciondocumentoswwds_3_cordoc1 = AV17CorDoc1;
         AV60Seguridad_numeraciondocumentoswwds_4_numdoc1 = AV18NumDoc1;
         AV61Seguridad_numeraciondocumentoswwds_5_corserie1 = AV19CorSerie1;
         AV62Seguridad_numeraciondocumentoswwds_6_dynamicfiltersenabled2 = AV20DynamicFiltersEnabled2;
         AV63Seguridad_numeraciondocumentoswwds_7_dynamicfiltersselector2 = AV21DynamicFiltersSelector2;
         AV64Seguridad_numeraciondocumentoswwds_8_dynamicfiltersoperator2 = AV22DynamicFiltersOperator2;
         AV65Seguridad_numeraciondocumentoswwds_9_cordoc2 = AV23CorDoc2;
         AV66Seguridad_numeraciondocumentoswwds_10_numdoc2 = AV24NumDoc2;
         AV67Seguridad_numeraciondocumentoswwds_11_corserie2 = AV25CorSerie2;
         AV68Seguridad_numeraciondocumentoswwds_12_dynamicfiltersenabled3 = AV26DynamicFiltersEnabled3;
         AV69Seguridad_numeraciondocumentoswwds_13_dynamicfiltersselector3 = AV27DynamicFiltersSelector3;
         AV70Seguridad_numeraciondocumentoswwds_14_dynamicfiltersoperator3 = AV28DynamicFiltersOperator3;
         AV71Seguridad_numeraciondocumentoswwds_15_cordoc3 = AV29CorDoc3;
         AV72Seguridad_numeraciondocumentoswwds_16_numdoc3 = AV30NumDoc3;
         AV73Seguridad_numeraciondocumentoswwds_17_corserie3 = AV31CorSerie3;
         AV74Seguridad_numeraciondocumentoswwds_18_tfcordoc = AV37TFCorDoc;
         AV75Seguridad_numeraciondocumentoswwds_19_tfcordoc_sel = AV38TFCorDoc_Sel;
         AV76Seguridad_numeraciondocumentoswwds_20_tfnumdoc = AV39TFNumDoc;
         AV77Seguridad_numeraciondocumentoswwds_21_tfnumdoc_to = AV40TFNumDoc_To;
         AV78Seguridad_numeraciondocumentoswwds_22_tfcorserie = AV41TFCorSerie;
         AV79Seguridad_numeraciondocumentoswwds_23_tfcorserie_sel = AV42TFCorSerie_Sel;
         AV80Seguridad_numeraciondocumentoswwds_24_tfcorfe_sel = AV43TFCorFE_Sel;
         AV81Seguridad_numeraciondocumentoswwds_25_tfcorformato = AV44TFCorFormato;
         AV82Seguridad_numeraciondocumentoswwds_26_tfcorformato_sel = AV45TFCorFormato_Sel;
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
            gxgrGrid_refresh( subGrid_Rows, AV15DynamicFiltersSelector1, AV16DynamicFiltersOperator1, AV17CorDoc1, AV18NumDoc1, AV19CorSerie1, AV21DynamicFiltersSelector2, AV22DynamicFiltersOperator2, AV23CorDoc2, AV24NumDoc2, AV25CorSerie2, AV27DynamicFiltersSelector3, AV28DynamicFiltersOperator3, AV29CorDoc3, AV30NumDoc3, AV31CorSerie3, AV20DynamicFiltersEnabled2, AV26DynamicFiltersEnabled3, AV56Pgmname, AV37TFCorDoc, AV38TFCorDoc_Sel, AV39TFNumDoc, AV40TFNumDoc_To, AV41TFCorSerie, AV42TFCorSerie_Sel, AV43TFCorFE_Sel, AV44TFCorFormato, AV45TFCorFormato_Sel, AV13OrderedBy, AV14OrderedDsc, AV10GridState, AV33DynamicFiltersIgnoreFirst, AV32DynamicFiltersRemoving) ;
         }
         send_integrity_footer_hashes( ) ;
         return 0 ;
      }

      protected int subgrid_gotopage( int nPageNo )
      {
         AV57Seguridad_numeraciondocumentoswwds_1_dynamicfiltersselector1 = AV15DynamicFiltersSelector1;
         AV58Seguridad_numeraciondocumentoswwds_2_dynamicfiltersoperator1 = AV16DynamicFiltersOperator1;
         AV59Seguridad_numeraciondocumentoswwds_3_cordoc1 = AV17CorDoc1;
         AV60Seguridad_numeraciondocumentoswwds_4_numdoc1 = AV18NumDoc1;
         AV61Seguridad_numeraciondocumentoswwds_5_corserie1 = AV19CorSerie1;
         AV62Seguridad_numeraciondocumentoswwds_6_dynamicfiltersenabled2 = AV20DynamicFiltersEnabled2;
         AV63Seguridad_numeraciondocumentoswwds_7_dynamicfiltersselector2 = AV21DynamicFiltersSelector2;
         AV64Seguridad_numeraciondocumentoswwds_8_dynamicfiltersoperator2 = AV22DynamicFiltersOperator2;
         AV65Seguridad_numeraciondocumentoswwds_9_cordoc2 = AV23CorDoc2;
         AV66Seguridad_numeraciondocumentoswwds_10_numdoc2 = AV24NumDoc2;
         AV67Seguridad_numeraciondocumentoswwds_11_corserie2 = AV25CorSerie2;
         AV68Seguridad_numeraciondocumentoswwds_12_dynamicfiltersenabled3 = AV26DynamicFiltersEnabled3;
         AV69Seguridad_numeraciondocumentoswwds_13_dynamicfiltersselector3 = AV27DynamicFiltersSelector3;
         AV70Seguridad_numeraciondocumentoswwds_14_dynamicfiltersoperator3 = AV28DynamicFiltersOperator3;
         AV71Seguridad_numeraciondocumentoswwds_15_cordoc3 = AV29CorDoc3;
         AV72Seguridad_numeraciondocumentoswwds_16_numdoc3 = AV30NumDoc3;
         AV73Seguridad_numeraciondocumentoswwds_17_corserie3 = AV31CorSerie3;
         AV74Seguridad_numeraciondocumentoswwds_18_tfcordoc = AV37TFCorDoc;
         AV75Seguridad_numeraciondocumentoswwds_19_tfcordoc_sel = AV38TFCorDoc_Sel;
         AV76Seguridad_numeraciondocumentoswwds_20_tfnumdoc = AV39TFNumDoc;
         AV77Seguridad_numeraciondocumentoswwds_21_tfnumdoc_to = AV40TFNumDoc_To;
         AV78Seguridad_numeraciondocumentoswwds_22_tfcorserie = AV41TFCorSerie;
         AV79Seguridad_numeraciondocumentoswwds_23_tfcorserie_sel = AV42TFCorSerie_Sel;
         AV80Seguridad_numeraciondocumentoswwds_24_tfcorfe_sel = AV43TFCorFE_Sel;
         AV81Seguridad_numeraciondocumentoswwds_25_tfcorformato = AV44TFCorFormato;
         AV82Seguridad_numeraciondocumentoswwds_26_tfcorformato_sel = AV45TFCorFormato_Sel;
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
            gxgrGrid_refresh( subGrid_Rows, AV15DynamicFiltersSelector1, AV16DynamicFiltersOperator1, AV17CorDoc1, AV18NumDoc1, AV19CorSerie1, AV21DynamicFiltersSelector2, AV22DynamicFiltersOperator2, AV23CorDoc2, AV24NumDoc2, AV25CorSerie2, AV27DynamicFiltersSelector3, AV28DynamicFiltersOperator3, AV29CorDoc3, AV30NumDoc3, AV31CorSerie3, AV20DynamicFiltersEnabled2, AV26DynamicFiltersEnabled3, AV56Pgmname, AV37TFCorDoc, AV38TFCorDoc_Sel, AV39TFNumDoc, AV40TFNumDoc_To, AV41TFCorSerie, AV42TFCorSerie_Sel, AV43TFCorFE_Sel, AV44TFCorFormato, AV45TFCorFormato_Sel, AV13OrderedBy, AV14OrderedDsc, AV10GridState, AV33DynamicFiltersIgnoreFirst, AV32DynamicFiltersRemoving) ;
         }
         send_integrity_footer_hashes( ) ;
         return (int)(0) ;
      }

      protected void before_start_formulas( )
      {
         AV56Pgmname = "Seguridad.NumeracionDocumentosWW";
         context.Gx_err = 0;
         fix_multi_value_controls( ) ;
      }

      protected void STRUP0F0( )
      {
         /* Before Start, stand alone formulas. */
         before_start_formulas( ) ;
         /* Execute Start event if defined. */
         context.wbGlbDoneStart = 0;
         /* Execute user event: Start */
         E240F2 ();
         context.wbGlbDoneStart = 1;
         /* After Start, stand alone formulas. */
         if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
         {
            /* Read saved SDTs. */
            ajax_req_read_hidden_sdt(cgiGet( "vAGEXPORTDATA"), AV52AGExportData);
            ajax_req_read_hidden_sdt(cgiGet( "vDDO_TITLESETTINGSICONS"), AV46DDO_TitleSettingsIcons);
            /* Read saved values. */
            nRC_GXsfl_119 = (int)(context.localUtil.CToN( cgiGet( "nRC_GXsfl_119"), ".", ","));
            AV48GridCurrentPage = (long)(context.localUtil.CToN( cgiGet( "vGRIDCURRENTPAGE"), ".", ","));
            AV49GridPageCount = (long)(context.localUtil.CToN( cgiGet( "vGRIDPAGECOUNT"), ".", ","));
            AV50GridAppliedFilters = cgiGet( "vGRIDAPPLIEDFILTERS");
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
            cmbavCordoc1.Name = cmbavCordoc1_Internalname;
            cmbavCordoc1.CurrentValue = cgiGet( cmbavCordoc1_Internalname);
            AV17CorDoc1 = cgiGet( cmbavCordoc1_Internalname);
            AssignAttri("", false, "AV17CorDoc1", AV17CorDoc1);
            if ( ( ( context.localUtil.CToN( cgiGet( edtavNumdoc1_Internalname), ".", ",") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtavNumdoc1_Internalname), ".", ",") > Convert.ToDecimal( 9999999999L )) ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "vNUMDOC1");
               GX_FocusControl = edtavNumdoc1_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               AV18NumDoc1 = 0;
               AssignAttri("", false, "AV18NumDoc1", StringUtil.LTrimStr( (decimal)(AV18NumDoc1), 10, 0));
            }
            else
            {
               AV18NumDoc1 = (long)(context.localUtil.CToN( cgiGet( edtavNumdoc1_Internalname), ".", ","));
               AssignAttri("", false, "AV18NumDoc1", StringUtil.LTrimStr( (decimal)(AV18NumDoc1), 10, 0));
            }
            AV19CorSerie1 = cgiGet( edtavCorserie1_Internalname);
            AssignAttri("", false, "AV19CorSerie1", AV19CorSerie1);
            cmbavDynamicfiltersselector2.Name = cmbavDynamicfiltersselector2_Internalname;
            cmbavDynamicfiltersselector2.CurrentValue = cgiGet( cmbavDynamicfiltersselector2_Internalname);
            AV21DynamicFiltersSelector2 = cgiGet( cmbavDynamicfiltersselector2_Internalname);
            AssignAttri("", false, "AV21DynamicFiltersSelector2", AV21DynamicFiltersSelector2);
            cmbavDynamicfiltersoperator2.Name = cmbavDynamicfiltersoperator2_Internalname;
            cmbavDynamicfiltersoperator2.CurrentValue = cgiGet( cmbavDynamicfiltersoperator2_Internalname);
            AV22DynamicFiltersOperator2 = (short)(NumberUtil.Val( cgiGet( cmbavDynamicfiltersoperator2_Internalname), "."));
            AssignAttri("", false, "AV22DynamicFiltersOperator2", StringUtil.LTrimStr( (decimal)(AV22DynamicFiltersOperator2), 4, 0));
            cmbavCordoc2.Name = cmbavCordoc2_Internalname;
            cmbavCordoc2.CurrentValue = cgiGet( cmbavCordoc2_Internalname);
            AV23CorDoc2 = cgiGet( cmbavCordoc2_Internalname);
            AssignAttri("", false, "AV23CorDoc2", AV23CorDoc2);
            if ( ( ( context.localUtil.CToN( cgiGet( edtavNumdoc2_Internalname), ".", ",") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtavNumdoc2_Internalname), ".", ",") > Convert.ToDecimal( 9999999999L )) ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "vNUMDOC2");
               GX_FocusControl = edtavNumdoc2_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               AV24NumDoc2 = 0;
               AssignAttri("", false, "AV24NumDoc2", StringUtil.LTrimStr( (decimal)(AV24NumDoc2), 10, 0));
            }
            else
            {
               AV24NumDoc2 = (long)(context.localUtil.CToN( cgiGet( edtavNumdoc2_Internalname), ".", ","));
               AssignAttri("", false, "AV24NumDoc2", StringUtil.LTrimStr( (decimal)(AV24NumDoc2), 10, 0));
            }
            AV25CorSerie2 = cgiGet( edtavCorserie2_Internalname);
            AssignAttri("", false, "AV25CorSerie2", AV25CorSerie2);
            cmbavDynamicfiltersselector3.Name = cmbavDynamicfiltersselector3_Internalname;
            cmbavDynamicfiltersselector3.CurrentValue = cgiGet( cmbavDynamicfiltersselector3_Internalname);
            AV27DynamicFiltersSelector3 = cgiGet( cmbavDynamicfiltersselector3_Internalname);
            AssignAttri("", false, "AV27DynamicFiltersSelector3", AV27DynamicFiltersSelector3);
            cmbavDynamicfiltersoperator3.Name = cmbavDynamicfiltersoperator3_Internalname;
            cmbavDynamicfiltersoperator3.CurrentValue = cgiGet( cmbavDynamicfiltersoperator3_Internalname);
            AV28DynamicFiltersOperator3 = (short)(NumberUtil.Val( cgiGet( cmbavDynamicfiltersoperator3_Internalname), "."));
            AssignAttri("", false, "AV28DynamicFiltersOperator3", StringUtil.LTrimStr( (decimal)(AV28DynamicFiltersOperator3), 4, 0));
            cmbavCordoc3.Name = cmbavCordoc3_Internalname;
            cmbavCordoc3.CurrentValue = cgiGet( cmbavCordoc3_Internalname);
            AV29CorDoc3 = cgiGet( cmbavCordoc3_Internalname);
            AssignAttri("", false, "AV29CorDoc3", AV29CorDoc3);
            if ( ( ( context.localUtil.CToN( cgiGet( edtavNumdoc3_Internalname), ".", ",") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtavNumdoc3_Internalname), ".", ",") > Convert.ToDecimal( 9999999999L )) ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "vNUMDOC3");
               GX_FocusControl = edtavNumdoc3_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               AV30NumDoc3 = 0;
               AssignAttri("", false, "AV30NumDoc3", StringUtil.LTrimStr( (decimal)(AV30NumDoc3), 10, 0));
            }
            else
            {
               AV30NumDoc3 = (long)(context.localUtil.CToN( cgiGet( edtavNumdoc3_Internalname), ".", ","));
               AssignAttri("", false, "AV30NumDoc3", StringUtil.LTrimStr( (decimal)(AV30NumDoc3), 10, 0));
            }
            AV31CorSerie3 = cgiGet( edtavCorserie3_Internalname);
            AssignAttri("", false, "AV31CorSerie3", AV31CorSerie3);
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
            if ( StringUtil.StrCmp(cgiGet( "GXH_vCORDOC1"), AV17CorDoc1) != 0 )
            {
               GRID_nFirstRecordOnPage = 0;
            }
            if ( ( context.localUtil.CToN( cgiGet( "GXH_vNUMDOC1"), ".", ",") != Convert.ToDecimal( AV18NumDoc1 )) )
            {
               GRID_nFirstRecordOnPage = 0;
            }
            if ( StringUtil.StrCmp(cgiGet( "GXH_vCORSERIE1"), AV19CorSerie1) != 0 )
            {
               GRID_nFirstRecordOnPage = 0;
            }
            if ( StringUtil.StrCmp(cgiGet( "GXH_vDYNAMICFILTERSSELECTOR2"), AV21DynamicFiltersSelector2) != 0 )
            {
               GRID_nFirstRecordOnPage = 0;
            }
            if ( ( context.localUtil.CToN( cgiGet( "GXH_vDYNAMICFILTERSOPERATOR2"), ".", ",") != Convert.ToDecimal( AV22DynamicFiltersOperator2 )) )
            {
               GRID_nFirstRecordOnPage = 0;
            }
            if ( StringUtil.StrCmp(cgiGet( "GXH_vCORDOC2"), AV23CorDoc2) != 0 )
            {
               GRID_nFirstRecordOnPage = 0;
            }
            if ( ( context.localUtil.CToN( cgiGet( "GXH_vNUMDOC2"), ".", ",") != Convert.ToDecimal( AV24NumDoc2 )) )
            {
               GRID_nFirstRecordOnPage = 0;
            }
            if ( StringUtil.StrCmp(cgiGet( "GXH_vCORSERIE2"), AV25CorSerie2) != 0 )
            {
               GRID_nFirstRecordOnPage = 0;
            }
            if ( StringUtil.StrCmp(cgiGet( "GXH_vDYNAMICFILTERSSELECTOR3"), AV27DynamicFiltersSelector3) != 0 )
            {
               GRID_nFirstRecordOnPage = 0;
            }
            if ( ( context.localUtil.CToN( cgiGet( "GXH_vDYNAMICFILTERSOPERATOR3"), ".", ",") != Convert.ToDecimal( AV28DynamicFiltersOperator3 )) )
            {
               GRID_nFirstRecordOnPage = 0;
            }
            if ( StringUtil.StrCmp(cgiGet( "GXH_vCORDOC3"), AV29CorDoc3) != 0 )
            {
               GRID_nFirstRecordOnPage = 0;
            }
            if ( ( context.localUtil.CToN( cgiGet( "GXH_vNUMDOC3"), ".", ",") != Convert.ToDecimal( AV30NumDoc3 )) )
            {
               GRID_nFirstRecordOnPage = 0;
            }
            if ( StringUtil.StrCmp(cgiGet( "GXH_vCORSERIE3"), AV31CorSerie3) != 0 )
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
         E240F2 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
      }

      protected void E240F2( )
      {
         /* Start Routine */
         returnInSub = false;
         subGrid_Rows = 10;
         GxWebStd.gx_hidden_field( context, "GRID_Rows", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid_Rows), 6, 0, ".", "")));
         Grid_empowerer_Gridinternalname = subGrid_Internalname;
         ucGrid_empowerer.SendProperty(context, "", false, Grid_empowerer_Internalname, "GridInternalName", Grid_empowerer_Gridinternalname);
         lblJsdynamicfilters_Caption = "";
         AssignProp("", false, lblJsdynamicfilters_Internalname, "Caption", lblJsdynamicfilters_Caption, true);
         AV15DynamicFiltersSelector1 = "CORDOC";
         AssignAttri("", false, "AV15DynamicFiltersSelector1", AV15DynamicFiltersSelector1);
         /* Execute user subroutine: 'ENABLEDYNAMICFILTERS1' */
         S112 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
         AV21DynamicFiltersSelector2 = "CORDOC";
         AssignAttri("", false, "AV21DynamicFiltersSelector2", AV21DynamicFiltersSelector2);
         /* Execute user subroutine: 'ENABLEDYNAMICFILTERS2' */
         S122 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
         AV27DynamicFiltersSelector3 = "CORDOC";
         AssignAttri("", false, "AV27DynamicFiltersSelector3", AV27DynamicFiltersSelector3);
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
         AV52AGExportData = new GXBaseCollection<GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTDropDownOptionsData_Item>( context, "Item", "");
         AV53AGExportDataItem = new GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTDropDownOptionsData_Item(context);
         AV53AGExportDataItem.gxTpr_Title = "PDF";
         AV53AGExportDataItem.gxTpr_Icon = context.convertURL( (string)(context.GetImagePath( "776fb79c-a0a1-4302-b5e5-d773dbe1a297", "", context.GetTheme( ))));
         AV53AGExportDataItem.gxTpr_Eventkey = "ExportReport";
         AV53AGExportDataItem.gxTpr_Isdivider = false;
         AV52AGExportData.Add(AV53AGExportDataItem, 0);
         AV53AGExportDataItem = new GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTDropDownOptionsData_Item(context);
         AV53AGExportDataItem.gxTpr_Title = "Excel";
         AV53AGExportDataItem.gxTpr_Icon = context.convertURL( (string)(context.GetImagePath( "da69a816-fd11-445b-8aaf-1a2f7f1acc93", "", context.GetTheme( ))));
         AV53AGExportDataItem.gxTpr_Eventkey = "Export";
         AV53AGExportDataItem.gxTpr_Isdivider = false;
         AV52AGExportData.Add(AV53AGExportDataItem, 0);
         Ddo_grid_Gridinternalname = subGrid_Internalname;
         ucDdo_grid.SendProperty(context, "", false, Ddo_grid_Internalname, "GridInternalName", Ddo_grid_Gridinternalname);
         Form.Caption = " Numeracion Documentos";
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
         GXt_SdtDVB_SDTDropDownOptionsTitleSettingsIcons1 = AV46DDO_TitleSettingsIcons;
         new GeneXus.Programs.wwpbaseobjects.getwwptitlesettingsicons(context ).execute( out  GXt_SdtDVB_SDTDropDownOptionsTitleSettingsIcons1) ;
         AV46DDO_TitleSettingsIcons = GXt_SdtDVB_SDTDropDownOptionsTitleSettingsIcons1;
         Gridpaginationbar_Rowsperpageselectedvalue = subGrid_Rows;
         ucGridpaginationbar.SendProperty(context, "", false, Gridpaginationbar_Internalname, "RowsPerPageSelectedValue", StringUtil.LTrimStr( (decimal)(Gridpaginationbar_Rowsperpageselectedvalue), 9, 0));
      }

      protected void E250F2( )
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
         if ( StringUtil.StrCmp(AV15DynamicFiltersSelector1, "NUMDOC") == 0 )
         {
            cmbavDynamicfiltersoperator1.addItem("0", "<", 0);
            cmbavDynamicfiltersoperator1.addItem("1", "=", 0);
            cmbavDynamicfiltersoperator1.addItem("2", ">", 0);
         }
         else if ( StringUtil.StrCmp(AV15DynamicFiltersSelector1, "CORSERIE") == 0 )
         {
            cmbavDynamicfiltersoperator1.addItem("0", "Comienza con", 0);
            cmbavDynamicfiltersoperator1.addItem("1", "Contiene", 0);
         }
         if ( AV20DynamicFiltersEnabled2 )
         {
            cmbavDynamicfiltersoperator2.removeAllItems();
            if ( StringUtil.StrCmp(AV21DynamicFiltersSelector2, "NUMDOC") == 0 )
            {
               cmbavDynamicfiltersoperator2.addItem("0", "<", 0);
               cmbavDynamicfiltersoperator2.addItem("1", "=", 0);
               cmbavDynamicfiltersoperator2.addItem("2", ">", 0);
            }
            else if ( StringUtil.StrCmp(AV21DynamicFiltersSelector2, "CORSERIE") == 0 )
            {
               cmbavDynamicfiltersoperator2.addItem("0", "Comienza con", 0);
               cmbavDynamicfiltersoperator2.addItem("1", "Contiene", 0);
            }
            if ( AV26DynamicFiltersEnabled3 )
            {
               cmbavDynamicfiltersoperator3.removeAllItems();
               if ( StringUtil.StrCmp(AV27DynamicFiltersSelector3, "NUMDOC") == 0 )
               {
                  cmbavDynamicfiltersoperator3.addItem("0", "<", 0);
                  cmbavDynamicfiltersoperator3.addItem("1", "=", 0);
                  cmbavDynamicfiltersoperator3.addItem("2", ">", 0);
               }
               else if ( StringUtil.StrCmp(AV27DynamicFiltersSelector3, "CORSERIE") == 0 )
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
         AV48GridCurrentPage = subGrid_fnc_Currentpage( );
         AssignAttri("", false, "AV48GridCurrentPage", StringUtil.LTrimStr( (decimal)(AV48GridCurrentPage), 10, 0));
         AV49GridPageCount = subGrid_fnc_Pagecount( );
         AssignAttri("", false, "AV49GridPageCount", StringUtil.LTrimStr( (decimal)(AV49GridPageCount), 10, 0));
         GXt_char2 = AV50GridAppliedFilters;
         new GeneXus.Programs.wwpbaseobjects.wwp_getappliedfiltersdescription(context ).execute(  AV56Pgmname, out  GXt_char2) ;
         AV50GridAppliedFilters = GXt_char2;
         AssignAttri("", false, "AV50GridAppliedFilters", AV50GridAppliedFilters);
         AV57Seguridad_numeraciondocumentoswwds_1_dynamicfiltersselector1 = AV15DynamicFiltersSelector1;
         AV58Seguridad_numeraciondocumentoswwds_2_dynamicfiltersoperator1 = AV16DynamicFiltersOperator1;
         AV59Seguridad_numeraciondocumentoswwds_3_cordoc1 = AV17CorDoc1;
         AV60Seguridad_numeraciondocumentoswwds_4_numdoc1 = AV18NumDoc1;
         AV61Seguridad_numeraciondocumentoswwds_5_corserie1 = AV19CorSerie1;
         AV62Seguridad_numeraciondocumentoswwds_6_dynamicfiltersenabled2 = AV20DynamicFiltersEnabled2;
         AV63Seguridad_numeraciondocumentoswwds_7_dynamicfiltersselector2 = AV21DynamicFiltersSelector2;
         AV64Seguridad_numeraciondocumentoswwds_8_dynamicfiltersoperator2 = AV22DynamicFiltersOperator2;
         AV65Seguridad_numeraciondocumentoswwds_9_cordoc2 = AV23CorDoc2;
         AV66Seguridad_numeraciondocumentoswwds_10_numdoc2 = AV24NumDoc2;
         AV67Seguridad_numeraciondocumentoswwds_11_corserie2 = AV25CorSerie2;
         AV68Seguridad_numeraciondocumentoswwds_12_dynamicfiltersenabled3 = AV26DynamicFiltersEnabled3;
         AV69Seguridad_numeraciondocumentoswwds_13_dynamicfiltersselector3 = AV27DynamicFiltersSelector3;
         AV70Seguridad_numeraciondocumentoswwds_14_dynamicfiltersoperator3 = AV28DynamicFiltersOperator3;
         AV71Seguridad_numeraciondocumentoswwds_15_cordoc3 = AV29CorDoc3;
         AV72Seguridad_numeraciondocumentoswwds_16_numdoc3 = AV30NumDoc3;
         AV73Seguridad_numeraciondocumentoswwds_17_corserie3 = AV31CorSerie3;
         AV74Seguridad_numeraciondocumentoswwds_18_tfcordoc = AV37TFCorDoc;
         AV75Seguridad_numeraciondocumentoswwds_19_tfcordoc_sel = AV38TFCorDoc_Sel;
         AV76Seguridad_numeraciondocumentoswwds_20_tfnumdoc = AV39TFNumDoc;
         AV77Seguridad_numeraciondocumentoswwds_21_tfnumdoc_to = AV40TFNumDoc_To;
         AV78Seguridad_numeraciondocumentoswwds_22_tfcorserie = AV41TFCorSerie;
         AV79Seguridad_numeraciondocumentoswwds_23_tfcorserie_sel = AV42TFCorSerie_Sel;
         AV80Seguridad_numeraciondocumentoswwds_24_tfcorfe_sel = AV43TFCorFE_Sel;
         AV81Seguridad_numeraciondocumentoswwds_25_tfcorformato = AV44TFCorFormato;
         AV82Seguridad_numeraciondocumentoswwds_26_tfcorformato_sel = AV45TFCorFormato_Sel;
         /*  Sending Event outputs  */
         cmbavDynamicfiltersoperator1.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV16DynamicFiltersOperator1), 4, 0));
         AssignProp("", false, cmbavDynamicfiltersoperator1_Internalname, "Values", cmbavDynamicfiltersoperator1.ToJavascriptSource(), true);
         cmbavDynamicfiltersoperator2.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV22DynamicFiltersOperator2), 4, 0));
         AssignProp("", false, cmbavDynamicfiltersoperator2_Internalname, "Values", cmbavDynamicfiltersoperator2.ToJavascriptSource(), true);
         cmbavDynamicfiltersoperator3.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV28DynamicFiltersOperator3), 4, 0));
         AssignProp("", false, cmbavDynamicfiltersoperator3_Internalname, "Values", cmbavDynamicfiltersoperator3.ToJavascriptSource(), true);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV10GridState", AV10GridState);
      }

      protected void E110F2( )
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
            AV47PageToGo = (int)(NumberUtil.Val( Gridpaginationbar_Selectedpage, "."));
            subgrid_gotopage( AV47PageToGo) ;
         }
      }

      protected void E120F2( )
      {
         /* Gridpaginationbar_Changerowsperpage Routine */
         returnInSub = false;
         subGrid_Rows = Gridpaginationbar_Rowsperpageselectedvalue;
         GxWebStd.gx_hidden_field( context, "GRID_Rows", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid_Rows), 6, 0, ".", "")));
         subgrid_firstpage( ) ;
         /*  Sending Event outputs  */
      }

      protected void E140F2( )
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
            if ( StringUtil.StrCmp(Ddo_grid_Selectedcolumn, "CorDoc") == 0 )
            {
               AV37TFCorDoc = Ddo_grid_Filteredtext_get;
               AssignAttri("", false, "AV37TFCorDoc", AV37TFCorDoc);
               AV38TFCorDoc_Sel = Ddo_grid_Selectedvalue_get;
               AssignAttri("", false, "AV38TFCorDoc_Sel", AV38TFCorDoc_Sel);
            }
            else if ( StringUtil.StrCmp(Ddo_grid_Selectedcolumn, "NumDoc") == 0 )
            {
               AV39TFNumDoc = (long)(NumberUtil.Val( Ddo_grid_Filteredtext_get, "."));
               AssignAttri("", false, "AV39TFNumDoc", StringUtil.LTrimStr( (decimal)(AV39TFNumDoc), 10, 0));
               AV40TFNumDoc_To = (long)(NumberUtil.Val( Ddo_grid_Filteredtextto_get, "."));
               AssignAttri("", false, "AV40TFNumDoc_To", StringUtil.LTrimStr( (decimal)(AV40TFNumDoc_To), 10, 0));
            }
            else if ( StringUtil.StrCmp(Ddo_grid_Selectedcolumn, "CorSerie") == 0 )
            {
               AV41TFCorSerie = Ddo_grid_Filteredtext_get;
               AssignAttri("", false, "AV41TFCorSerie", AV41TFCorSerie);
               AV42TFCorSerie_Sel = Ddo_grid_Selectedvalue_get;
               AssignAttri("", false, "AV42TFCorSerie_Sel", AV42TFCorSerie_Sel);
            }
            else if ( StringUtil.StrCmp(Ddo_grid_Selectedcolumn, "CorFE") == 0 )
            {
               AV43TFCorFE_Sel = (short)(NumberUtil.Val( Ddo_grid_Selectedvalue_get, "."));
               AssignAttri("", false, "AV43TFCorFE_Sel", StringUtil.Str( (decimal)(AV43TFCorFE_Sel), 1, 0));
            }
            else if ( StringUtil.StrCmp(Ddo_grid_Selectedcolumn, "CorFormato") == 0 )
            {
               AV44TFCorFormato = Ddo_grid_Filteredtext_get;
               AssignAttri("", false, "AV44TFCorFormato", AV44TFCorFormato);
               AV45TFCorFormato_Sel = Ddo_grid_Selectedvalue_get;
               AssignAttri("", false, "AV45TFCorFormato_Sel", AV45TFCorFormato_Sel);
            }
            subgrid_firstpage( ) ;
         }
         /*  Sending Event outputs  */
      }

      private void E260F2( )
      {
         /* Grid_Load Routine */
         returnInSub = false;
         cmbavGridactions.removeAllItems();
         cmbavGridactions.addItem("0", ";fa fa-bars", 0);
         cmbavGridactions.addItem("1", StringUtil.Format( "%1;%2", "Modificar", "fa fa-pen", "", "", "", "", "", "", ""), 0);
         cmbavGridactions.addItem("2", StringUtil.Format( "%1;%2", "Eliminar", "fa fa-times", "", "", "", "", "", "", ""), 0);
         GXKey = Crypto.GetSiteKey( );
         GXEncryptionTmp = "seguridad.numeraciondocumentos.aspx"+UrlEncode(StringUtil.RTrim("DSP")) + "," + UrlEncode(StringUtil.RTrim(A339CorDoc)) + "," + UrlEncode(StringUtil.RTrim(A340CorSerie));
         edtNumDoc_Link = formatLink("seguridad.numeraciondocumentos.aspx") + "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey);
         /* Load Method */
         if ( wbStart != -1 )
         {
            wbStart = 119;
         }
         sendrow_1192( ) ;
         GRID_nCurrentRecord = (long)(GRID_nCurrentRecord+1);
         if ( isFullAjaxMode( ) && ! bGXsfl_119_Refreshing )
         {
            DoAjaxLoad(119, GridRow);
         }
         /*  Sending Event outputs  */
         cmbavGridactions.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV51GridActions), 4, 0));
      }

      protected void E190F2( )
      {
         /* 'AddDynamicFilters1' Routine */
         returnInSub = false;
         AV20DynamicFiltersEnabled2 = true;
         AssignAttri("", false, "AV20DynamicFiltersEnabled2", AV20DynamicFiltersEnabled2);
         imgAdddynamicfilters1_Visible = 0;
         AssignProp("", false, imgAdddynamicfilters1_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(imgAdddynamicfilters1_Visible), 5, 0), true);
         imgRemovedynamicfilters1_Visible = 1;
         AssignProp("", false, imgRemovedynamicfilters1_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(imgRemovedynamicfilters1_Visible), 5, 0), true);
         /*  Sending Event outputs  */
      }

      protected void E150F2( )
      {
         /* 'RemoveDynamicFilters1' Routine */
         returnInSub = false;
         AV32DynamicFiltersRemoving = true;
         AssignAttri("", false, "AV32DynamicFiltersRemoving", AV32DynamicFiltersRemoving);
         AV33DynamicFiltersIgnoreFirst = true;
         AssignAttri("", false, "AV33DynamicFiltersIgnoreFirst", AV33DynamicFiltersIgnoreFirst);
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
         AV32DynamicFiltersRemoving = false;
         AssignAttri("", false, "AV32DynamicFiltersRemoving", AV32DynamicFiltersRemoving);
         AV33DynamicFiltersIgnoreFirst = false;
         AssignAttri("", false, "AV33DynamicFiltersIgnoreFirst", AV33DynamicFiltersIgnoreFirst);
         gxgrGrid_refresh( subGrid_Rows, AV15DynamicFiltersSelector1, AV16DynamicFiltersOperator1, AV17CorDoc1, AV18NumDoc1, AV19CorSerie1, AV21DynamicFiltersSelector2, AV22DynamicFiltersOperator2, AV23CorDoc2, AV24NumDoc2, AV25CorSerie2, AV27DynamicFiltersSelector3, AV28DynamicFiltersOperator3, AV29CorDoc3, AV30NumDoc3, AV31CorSerie3, AV20DynamicFiltersEnabled2, AV26DynamicFiltersEnabled3, AV56Pgmname, AV37TFCorDoc, AV38TFCorDoc_Sel, AV39TFNumDoc, AV40TFNumDoc_To, AV41TFCorSerie, AV42TFCorSerie_Sel, AV43TFCorFE_Sel, AV44TFCorFormato, AV45TFCorFormato_Sel, AV13OrderedBy, AV14OrderedDsc, AV10GridState, AV33DynamicFiltersIgnoreFirst, AV32DynamicFiltersRemoving) ;
         /*  Sending Event outputs  */
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV10GridState", AV10GridState);
         cmbavDynamicfiltersselector2.CurrentValue = StringUtil.RTrim( AV21DynamicFiltersSelector2);
         AssignProp("", false, cmbavDynamicfiltersselector2_Internalname, "Values", cmbavDynamicfiltersselector2.ToJavascriptSource(), true);
         cmbavCordoc2.CurrentValue = StringUtil.RTrim( AV23CorDoc2);
         AssignProp("", false, cmbavCordoc2_Internalname, "Values", cmbavCordoc2.ToJavascriptSource(), true);
         cmbavDynamicfiltersselector3.CurrentValue = StringUtil.RTrim( AV27DynamicFiltersSelector3);
         AssignProp("", false, cmbavDynamicfiltersselector3_Internalname, "Values", cmbavDynamicfiltersselector3.ToJavascriptSource(), true);
         cmbavCordoc3.CurrentValue = StringUtil.RTrim( AV29CorDoc3);
         AssignProp("", false, cmbavCordoc3_Internalname, "Values", cmbavCordoc3.ToJavascriptSource(), true);
         cmbavDynamicfiltersselector1.CurrentValue = StringUtil.RTrim( AV15DynamicFiltersSelector1);
         AssignProp("", false, cmbavDynamicfiltersselector1_Internalname, "Values", cmbavDynamicfiltersselector1.ToJavascriptSource(), true);
         cmbavCordoc1.CurrentValue = StringUtil.RTrim( AV17CorDoc1);
         AssignProp("", false, cmbavCordoc1_Internalname, "Values", cmbavCordoc1.ToJavascriptSource(), true);
         cmbavDynamicfiltersoperator1.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV16DynamicFiltersOperator1), 4, 0));
         AssignProp("", false, cmbavDynamicfiltersoperator1_Internalname, "Values", cmbavDynamicfiltersoperator1.ToJavascriptSource(), true);
         cmbavDynamicfiltersoperator2.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV22DynamicFiltersOperator2), 4, 0));
         AssignProp("", false, cmbavDynamicfiltersoperator2_Internalname, "Values", cmbavDynamicfiltersoperator2.ToJavascriptSource(), true);
         cmbavDynamicfiltersoperator3.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV28DynamicFiltersOperator3), 4, 0));
         AssignProp("", false, cmbavDynamicfiltersoperator3_Internalname, "Values", cmbavDynamicfiltersoperator3.ToJavascriptSource(), true);
      }

      protected void E200F2( )
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

      protected void E210F2( )
      {
         /* 'AddDynamicFilters2' Routine */
         returnInSub = false;
         AV26DynamicFiltersEnabled3 = true;
         AssignAttri("", false, "AV26DynamicFiltersEnabled3", AV26DynamicFiltersEnabled3);
         imgAdddynamicfilters2_Visible = 0;
         AssignProp("", false, imgAdddynamicfilters2_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(imgAdddynamicfilters2_Visible), 5, 0), true);
         imgRemovedynamicfilters2_Visible = 1;
         AssignProp("", false, imgRemovedynamicfilters2_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(imgRemovedynamicfilters2_Visible), 5, 0), true);
         /*  Sending Event outputs  */
      }

      protected void E160F2( )
      {
         /* 'RemoveDynamicFilters2' Routine */
         returnInSub = false;
         AV32DynamicFiltersRemoving = true;
         AssignAttri("", false, "AV32DynamicFiltersRemoving", AV32DynamicFiltersRemoving);
         AV20DynamicFiltersEnabled2 = false;
         AssignAttri("", false, "AV20DynamicFiltersEnabled2", AV20DynamicFiltersEnabled2);
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
         AV32DynamicFiltersRemoving = false;
         AssignAttri("", false, "AV32DynamicFiltersRemoving", AV32DynamicFiltersRemoving);
         gxgrGrid_refresh( subGrid_Rows, AV15DynamicFiltersSelector1, AV16DynamicFiltersOperator1, AV17CorDoc1, AV18NumDoc1, AV19CorSerie1, AV21DynamicFiltersSelector2, AV22DynamicFiltersOperator2, AV23CorDoc2, AV24NumDoc2, AV25CorSerie2, AV27DynamicFiltersSelector3, AV28DynamicFiltersOperator3, AV29CorDoc3, AV30NumDoc3, AV31CorSerie3, AV20DynamicFiltersEnabled2, AV26DynamicFiltersEnabled3, AV56Pgmname, AV37TFCorDoc, AV38TFCorDoc_Sel, AV39TFNumDoc, AV40TFNumDoc_To, AV41TFCorSerie, AV42TFCorSerie_Sel, AV43TFCorFE_Sel, AV44TFCorFormato, AV45TFCorFormato_Sel, AV13OrderedBy, AV14OrderedDsc, AV10GridState, AV33DynamicFiltersIgnoreFirst, AV32DynamicFiltersRemoving) ;
         /*  Sending Event outputs  */
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV10GridState", AV10GridState);
         cmbavDynamicfiltersselector2.CurrentValue = StringUtil.RTrim( AV21DynamicFiltersSelector2);
         AssignProp("", false, cmbavDynamicfiltersselector2_Internalname, "Values", cmbavDynamicfiltersselector2.ToJavascriptSource(), true);
         cmbavCordoc2.CurrentValue = StringUtil.RTrim( AV23CorDoc2);
         AssignProp("", false, cmbavCordoc2_Internalname, "Values", cmbavCordoc2.ToJavascriptSource(), true);
         cmbavDynamicfiltersselector3.CurrentValue = StringUtil.RTrim( AV27DynamicFiltersSelector3);
         AssignProp("", false, cmbavDynamicfiltersselector3_Internalname, "Values", cmbavDynamicfiltersselector3.ToJavascriptSource(), true);
         cmbavCordoc3.CurrentValue = StringUtil.RTrim( AV29CorDoc3);
         AssignProp("", false, cmbavCordoc3_Internalname, "Values", cmbavCordoc3.ToJavascriptSource(), true);
         cmbavDynamicfiltersselector1.CurrentValue = StringUtil.RTrim( AV15DynamicFiltersSelector1);
         AssignProp("", false, cmbavDynamicfiltersselector1_Internalname, "Values", cmbavDynamicfiltersselector1.ToJavascriptSource(), true);
         cmbavCordoc1.CurrentValue = StringUtil.RTrim( AV17CorDoc1);
         AssignProp("", false, cmbavCordoc1_Internalname, "Values", cmbavCordoc1.ToJavascriptSource(), true);
         cmbavDynamicfiltersoperator1.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV16DynamicFiltersOperator1), 4, 0));
         AssignProp("", false, cmbavDynamicfiltersoperator1_Internalname, "Values", cmbavDynamicfiltersoperator1.ToJavascriptSource(), true);
         cmbavDynamicfiltersoperator2.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV22DynamicFiltersOperator2), 4, 0));
         AssignProp("", false, cmbavDynamicfiltersoperator2_Internalname, "Values", cmbavDynamicfiltersoperator2.ToJavascriptSource(), true);
         cmbavDynamicfiltersoperator3.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV28DynamicFiltersOperator3), 4, 0));
         AssignProp("", false, cmbavDynamicfiltersoperator3_Internalname, "Values", cmbavDynamicfiltersoperator3.ToJavascriptSource(), true);
      }

      protected void E220F2( )
      {
         /* Dynamicfiltersselector2_Click Routine */
         returnInSub = false;
         AV22DynamicFiltersOperator2 = 0;
         AssignAttri("", false, "AV22DynamicFiltersOperator2", StringUtil.LTrimStr( (decimal)(AV22DynamicFiltersOperator2), 4, 0));
         /* Execute user subroutine: 'ENABLEDYNAMICFILTERS2' */
         S122 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
         /*  Sending Event outputs  */
         cmbavDynamicfiltersoperator2.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV22DynamicFiltersOperator2), 4, 0));
         AssignProp("", false, cmbavDynamicfiltersoperator2_Internalname, "Values", cmbavDynamicfiltersoperator2.ToJavascriptSource(), true);
      }

      protected void E170F2( )
      {
         /* 'RemoveDynamicFilters3' Routine */
         returnInSub = false;
         AV32DynamicFiltersRemoving = true;
         AssignAttri("", false, "AV32DynamicFiltersRemoving", AV32DynamicFiltersRemoving);
         AV26DynamicFiltersEnabled3 = false;
         AssignAttri("", false, "AV26DynamicFiltersEnabled3", AV26DynamicFiltersEnabled3);
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
         AV32DynamicFiltersRemoving = false;
         AssignAttri("", false, "AV32DynamicFiltersRemoving", AV32DynamicFiltersRemoving);
         gxgrGrid_refresh( subGrid_Rows, AV15DynamicFiltersSelector1, AV16DynamicFiltersOperator1, AV17CorDoc1, AV18NumDoc1, AV19CorSerie1, AV21DynamicFiltersSelector2, AV22DynamicFiltersOperator2, AV23CorDoc2, AV24NumDoc2, AV25CorSerie2, AV27DynamicFiltersSelector3, AV28DynamicFiltersOperator3, AV29CorDoc3, AV30NumDoc3, AV31CorSerie3, AV20DynamicFiltersEnabled2, AV26DynamicFiltersEnabled3, AV56Pgmname, AV37TFCorDoc, AV38TFCorDoc_Sel, AV39TFNumDoc, AV40TFNumDoc_To, AV41TFCorSerie, AV42TFCorSerie_Sel, AV43TFCorFE_Sel, AV44TFCorFormato, AV45TFCorFormato_Sel, AV13OrderedBy, AV14OrderedDsc, AV10GridState, AV33DynamicFiltersIgnoreFirst, AV32DynamicFiltersRemoving) ;
         /*  Sending Event outputs  */
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV10GridState", AV10GridState);
         cmbavDynamicfiltersselector2.CurrentValue = StringUtil.RTrim( AV21DynamicFiltersSelector2);
         AssignProp("", false, cmbavDynamicfiltersselector2_Internalname, "Values", cmbavDynamicfiltersselector2.ToJavascriptSource(), true);
         cmbavCordoc2.CurrentValue = StringUtil.RTrim( AV23CorDoc2);
         AssignProp("", false, cmbavCordoc2_Internalname, "Values", cmbavCordoc2.ToJavascriptSource(), true);
         cmbavDynamicfiltersselector3.CurrentValue = StringUtil.RTrim( AV27DynamicFiltersSelector3);
         AssignProp("", false, cmbavDynamicfiltersselector3_Internalname, "Values", cmbavDynamicfiltersselector3.ToJavascriptSource(), true);
         cmbavCordoc3.CurrentValue = StringUtil.RTrim( AV29CorDoc3);
         AssignProp("", false, cmbavCordoc3_Internalname, "Values", cmbavCordoc3.ToJavascriptSource(), true);
         cmbavDynamicfiltersselector1.CurrentValue = StringUtil.RTrim( AV15DynamicFiltersSelector1);
         AssignProp("", false, cmbavDynamicfiltersselector1_Internalname, "Values", cmbavDynamicfiltersselector1.ToJavascriptSource(), true);
         cmbavCordoc1.CurrentValue = StringUtil.RTrim( AV17CorDoc1);
         AssignProp("", false, cmbavCordoc1_Internalname, "Values", cmbavCordoc1.ToJavascriptSource(), true);
         cmbavDynamicfiltersoperator1.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV16DynamicFiltersOperator1), 4, 0));
         AssignProp("", false, cmbavDynamicfiltersoperator1_Internalname, "Values", cmbavDynamicfiltersoperator1.ToJavascriptSource(), true);
         cmbavDynamicfiltersoperator2.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV22DynamicFiltersOperator2), 4, 0));
         AssignProp("", false, cmbavDynamicfiltersoperator2_Internalname, "Values", cmbavDynamicfiltersoperator2.ToJavascriptSource(), true);
         cmbavDynamicfiltersoperator3.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV28DynamicFiltersOperator3), 4, 0));
         AssignProp("", false, cmbavDynamicfiltersoperator3_Internalname, "Values", cmbavDynamicfiltersoperator3.ToJavascriptSource(), true);
      }

      protected void E230F2( )
      {
         /* Dynamicfiltersselector3_Click Routine */
         returnInSub = false;
         AV28DynamicFiltersOperator3 = 0;
         AssignAttri("", false, "AV28DynamicFiltersOperator3", StringUtil.LTrimStr( (decimal)(AV28DynamicFiltersOperator3), 4, 0));
         /* Execute user subroutine: 'ENABLEDYNAMICFILTERS3' */
         S132 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
         /*  Sending Event outputs  */
         cmbavDynamicfiltersoperator3.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV28DynamicFiltersOperator3), 4, 0));
         AssignProp("", false, cmbavDynamicfiltersoperator3_Internalname, "Values", cmbavDynamicfiltersoperator3.ToJavascriptSource(), true);
      }

      protected void E270F2( )
      {
         /* Gridactions_Click Routine */
         returnInSub = false;
         if ( AV51GridActions == 1 )
         {
            /* Execute user subroutine: 'DO UPDATE' */
            S212 ();
            if ( returnInSub )
            {
               returnInSub = true;
               if (true) return;
            }
         }
         else if ( AV51GridActions == 2 )
         {
            /* Execute user subroutine: 'DO DELETE' */
            S222 ();
            if ( returnInSub )
            {
               returnInSub = true;
               if (true) return;
            }
         }
         AV51GridActions = 0;
         AssignAttri("", false, cmbavGridactions_Internalname, StringUtil.LTrimStr( (decimal)(AV51GridActions), 4, 0));
         /*  Sending Event outputs  */
         cmbavGridactions.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV51GridActions), 4, 0));
         AssignProp("", false, cmbavGridactions_Internalname, "Values", cmbavGridactions.ToJavascriptSource(), true);
      }

      protected void E180F2( )
      {
         /* 'DoInsert' Routine */
         returnInSub = false;
         GXKey = Crypto.GetSiteKey( );
         GXEncryptionTmp = "seguridad.numeraciondocumentos.aspx"+UrlEncode(StringUtil.RTrim("INS")) + "," + UrlEncode(StringUtil.RTrim("")) + "," + UrlEncode(StringUtil.RTrim(""));
         CallWebObject(formatLink("seguridad.numeraciondocumentos.aspx") + "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey));
         context.wjLocDisableFrm = 1;
      }

      protected void E130F2( )
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
         cmbavCordoc1.CurrentValue = StringUtil.RTrim( AV17CorDoc1);
         AssignProp("", false, cmbavCordoc1_Internalname, "Values", cmbavCordoc1.ToJavascriptSource(), true);
         cmbavDynamicfiltersoperator1.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV16DynamicFiltersOperator1), 4, 0));
         AssignProp("", false, cmbavDynamicfiltersoperator1_Internalname, "Values", cmbavDynamicfiltersoperator1.ToJavascriptSource(), true);
         cmbavDynamicfiltersselector2.CurrentValue = StringUtil.RTrim( AV21DynamicFiltersSelector2);
         AssignProp("", false, cmbavDynamicfiltersselector2_Internalname, "Values", cmbavDynamicfiltersselector2.ToJavascriptSource(), true);
         cmbavCordoc2.CurrentValue = StringUtil.RTrim( AV23CorDoc2);
         AssignProp("", false, cmbavCordoc2_Internalname, "Values", cmbavCordoc2.ToJavascriptSource(), true);
         cmbavDynamicfiltersoperator2.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV22DynamicFiltersOperator2), 4, 0));
         AssignProp("", false, cmbavDynamicfiltersoperator2_Internalname, "Values", cmbavDynamicfiltersoperator2.ToJavascriptSource(), true);
         cmbavDynamicfiltersselector3.CurrentValue = StringUtil.RTrim( AV27DynamicFiltersSelector3);
         AssignProp("", false, cmbavDynamicfiltersselector3_Internalname, "Values", cmbavDynamicfiltersselector3.ToJavascriptSource(), true);
         cmbavCordoc3.CurrentValue = StringUtil.RTrim( AV29CorDoc3);
         AssignProp("", false, cmbavCordoc3_Internalname, "Values", cmbavCordoc3.ToJavascriptSource(), true);
         cmbavDynamicfiltersoperator3.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV28DynamicFiltersOperator3), 4, 0));
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
         cmbavCordoc1.Visible = 0;
         AssignProp("", false, cmbavCordoc1_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(cmbavCordoc1.Visible), 5, 0), true);
         edtavNumdoc1_Visible = 0;
         AssignProp("", false, edtavNumdoc1_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavNumdoc1_Visible), 5, 0), true);
         edtavCorserie1_Visible = 0;
         AssignProp("", false, edtavCorserie1_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavCorserie1_Visible), 5, 0), true);
         cmbavDynamicfiltersoperator1.Visible = 0;
         AssignProp("", false, cmbavDynamicfiltersoperator1_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(cmbavDynamicfiltersoperator1.Visible), 5, 0), true);
         if ( StringUtil.StrCmp(AV15DynamicFiltersSelector1, "CORDOC") == 0 )
         {
            cmbavCordoc1.Visible = 1;
            AssignProp("", false, cmbavCordoc1_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(cmbavCordoc1.Visible), 5, 0), true);
         }
         else if ( StringUtil.StrCmp(AV15DynamicFiltersSelector1, "NUMDOC") == 0 )
         {
            edtavNumdoc1_Visible = 1;
            AssignProp("", false, edtavNumdoc1_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavNumdoc1_Visible), 5, 0), true);
            cmbavDynamicfiltersoperator1.Visible = 1;
            AssignProp("", false, cmbavDynamicfiltersoperator1_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(cmbavDynamicfiltersoperator1.Visible), 5, 0), true);
         }
         else if ( StringUtil.StrCmp(AV15DynamicFiltersSelector1, "CORSERIE") == 0 )
         {
            edtavCorserie1_Visible = 1;
            AssignProp("", false, edtavCorserie1_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavCorserie1_Visible), 5, 0), true);
            cmbavDynamicfiltersoperator1.Visible = 1;
            AssignProp("", false, cmbavDynamicfiltersoperator1_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(cmbavDynamicfiltersoperator1.Visible), 5, 0), true);
         }
      }

      protected void S122( )
      {
         /* 'ENABLEDYNAMICFILTERS2' Routine */
         returnInSub = false;
         cmbavCordoc2.Visible = 0;
         AssignProp("", false, cmbavCordoc2_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(cmbavCordoc2.Visible), 5, 0), true);
         edtavNumdoc2_Visible = 0;
         AssignProp("", false, edtavNumdoc2_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavNumdoc2_Visible), 5, 0), true);
         edtavCorserie2_Visible = 0;
         AssignProp("", false, edtavCorserie2_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavCorserie2_Visible), 5, 0), true);
         cmbavDynamicfiltersoperator2.Visible = 0;
         AssignProp("", false, cmbavDynamicfiltersoperator2_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(cmbavDynamicfiltersoperator2.Visible), 5, 0), true);
         if ( StringUtil.StrCmp(AV21DynamicFiltersSelector2, "CORDOC") == 0 )
         {
            cmbavCordoc2.Visible = 1;
            AssignProp("", false, cmbavCordoc2_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(cmbavCordoc2.Visible), 5, 0), true);
         }
         else if ( StringUtil.StrCmp(AV21DynamicFiltersSelector2, "NUMDOC") == 0 )
         {
            edtavNumdoc2_Visible = 1;
            AssignProp("", false, edtavNumdoc2_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavNumdoc2_Visible), 5, 0), true);
            cmbavDynamicfiltersoperator2.Visible = 1;
            AssignProp("", false, cmbavDynamicfiltersoperator2_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(cmbavDynamicfiltersoperator2.Visible), 5, 0), true);
         }
         else if ( StringUtil.StrCmp(AV21DynamicFiltersSelector2, "CORSERIE") == 0 )
         {
            edtavCorserie2_Visible = 1;
            AssignProp("", false, edtavCorserie2_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavCorserie2_Visible), 5, 0), true);
            cmbavDynamicfiltersoperator2.Visible = 1;
            AssignProp("", false, cmbavDynamicfiltersoperator2_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(cmbavDynamicfiltersoperator2.Visible), 5, 0), true);
         }
      }

      protected void S132( )
      {
         /* 'ENABLEDYNAMICFILTERS3' Routine */
         returnInSub = false;
         cmbavCordoc3.Visible = 0;
         AssignProp("", false, cmbavCordoc3_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(cmbavCordoc3.Visible), 5, 0), true);
         edtavNumdoc3_Visible = 0;
         AssignProp("", false, edtavNumdoc3_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavNumdoc3_Visible), 5, 0), true);
         edtavCorserie3_Visible = 0;
         AssignProp("", false, edtavCorserie3_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavCorserie3_Visible), 5, 0), true);
         cmbavDynamicfiltersoperator3.Visible = 0;
         AssignProp("", false, cmbavDynamicfiltersoperator3_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(cmbavDynamicfiltersoperator3.Visible), 5, 0), true);
         if ( StringUtil.StrCmp(AV27DynamicFiltersSelector3, "CORDOC") == 0 )
         {
            cmbavCordoc3.Visible = 1;
            AssignProp("", false, cmbavCordoc3_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(cmbavCordoc3.Visible), 5, 0), true);
         }
         else if ( StringUtil.StrCmp(AV27DynamicFiltersSelector3, "NUMDOC") == 0 )
         {
            edtavNumdoc3_Visible = 1;
            AssignProp("", false, edtavNumdoc3_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavNumdoc3_Visible), 5, 0), true);
            cmbavDynamicfiltersoperator3.Visible = 1;
            AssignProp("", false, cmbavDynamicfiltersoperator3_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(cmbavDynamicfiltersoperator3.Visible), 5, 0), true);
         }
         else if ( StringUtil.StrCmp(AV27DynamicFiltersSelector3, "CORSERIE") == 0 )
         {
            edtavCorserie3_Visible = 1;
            AssignProp("", false, edtavCorserie3_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavCorserie3_Visible), 5, 0), true);
            cmbavDynamicfiltersoperator3.Visible = 1;
            AssignProp("", false, cmbavDynamicfiltersoperator3_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(cmbavDynamicfiltersoperator3.Visible), 5, 0), true);
         }
      }

      protected void S192( )
      {
         /* 'RESETDYNFILTERS' Routine */
         returnInSub = false;
         AV20DynamicFiltersEnabled2 = false;
         AssignAttri("", false, "AV20DynamicFiltersEnabled2", AV20DynamicFiltersEnabled2);
         AV21DynamicFiltersSelector2 = "CORDOC";
         AssignAttri("", false, "AV21DynamicFiltersSelector2", AV21DynamicFiltersSelector2);
         AV23CorDoc2 = "";
         AssignAttri("", false, "AV23CorDoc2", AV23CorDoc2);
         /* Execute user subroutine: 'ENABLEDYNAMICFILTERS2' */
         S122 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
         AV26DynamicFiltersEnabled3 = false;
         AssignAttri("", false, "AV26DynamicFiltersEnabled3", AV26DynamicFiltersEnabled3);
         AV27DynamicFiltersSelector3 = "CORDOC";
         AssignAttri("", false, "AV27DynamicFiltersSelector3", AV27DynamicFiltersSelector3);
         AV29CorDoc3 = "";
         AssignAttri("", false, "AV29CorDoc3", AV29CorDoc3);
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
         GXEncryptionTmp = "seguridad.numeraciondocumentos.aspx"+UrlEncode(StringUtil.RTrim("UPD")) + "," + UrlEncode(StringUtil.RTrim(A339CorDoc)) + "," + UrlEncode(StringUtil.RTrim(A340CorSerie));
         CallWebObject(formatLink("seguridad.numeraciondocumentos.aspx") + "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey));
         context.wjLocDisableFrm = 1;
      }

      protected void S222( )
      {
         /* 'DO DELETE' Routine */
         returnInSub = false;
         GXKey = Crypto.GetSiteKey( );
         GXEncryptionTmp = "seguridad.numeraciondocumentos.aspx"+UrlEncode(StringUtil.RTrim("DLT")) + "," + UrlEncode(StringUtil.RTrim(A339CorDoc)) + "," + UrlEncode(StringUtil.RTrim(A340CorSerie));
         CallWebObject(formatLink("seguridad.numeraciondocumentos.aspx") + "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey));
         context.wjLocDisableFrm = 1;
      }

      protected void S152( )
      {
         /* 'LOADGRIDSTATE' Routine */
         returnInSub = false;
         if ( StringUtil.StrCmp(AV36Session.Get(AV56Pgmname+"GridState"), "") == 0 )
         {
            AV10GridState.FromXml(new GeneXus.Programs.wwpbaseobjects.loadgridstate(context).executeUdp(  AV56Pgmname+"GridState"), null, "", "");
         }
         else
         {
            AV10GridState.FromXml(AV36Session.Get(AV56Pgmname+"GridState"), null, "", "");
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
            if ( StringUtil.StrCmp(AV11GridStateFilterValue.gxTpr_Name, "TFCORDOC") == 0 )
            {
               AV37TFCorDoc = AV11GridStateFilterValue.gxTpr_Value;
               AssignAttri("", false, "AV37TFCorDoc", AV37TFCorDoc);
            }
            else if ( StringUtil.StrCmp(AV11GridStateFilterValue.gxTpr_Name, "TFCORDOC_SEL") == 0 )
            {
               AV38TFCorDoc_Sel = AV11GridStateFilterValue.gxTpr_Value;
               AssignAttri("", false, "AV38TFCorDoc_Sel", AV38TFCorDoc_Sel);
            }
            else if ( StringUtil.StrCmp(AV11GridStateFilterValue.gxTpr_Name, "TFNUMDOC") == 0 )
            {
               AV39TFNumDoc = (long)(NumberUtil.Val( AV11GridStateFilterValue.gxTpr_Value, "."));
               AssignAttri("", false, "AV39TFNumDoc", StringUtil.LTrimStr( (decimal)(AV39TFNumDoc), 10, 0));
               AV40TFNumDoc_To = (long)(NumberUtil.Val( AV11GridStateFilterValue.gxTpr_Valueto, "."));
               AssignAttri("", false, "AV40TFNumDoc_To", StringUtil.LTrimStr( (decimal)(AV40TFNumDoc_To), 10, 0));
            }
            else if ( StringUtil.StrCmp(AV11GridStateFilterValue.gxTpr_Name, "TFCORSERIE") == 0 )
            {
               AV41TFCorSerie = AV11GridStateFilterValue.gxTpr_Value;
               AssignAttri("", false, "AV41TFCorSerie", AV41TFCorSerie);
            }
            else if ( StringUtil.StrCmp(AV11GridStateFilterValue.gxTpr_Name, "TFCORSERIE_SEL") == 0 )
            {
               AV42TFCorSerie_Sel = AV11GridStateFilterValue.gxTpr_Value;
               AssignAttri("", false, "AV42TFCorSerie_Sel", AV42TFCorSerie_Sel);
            }
            else if ( StringUtil.StrCmp(AV11GridStateFilterValue.gxTpr_Name, "TFCORFE_SEL") == 0 )
            {
               AV43TFCorFE_Sel = (short)(NumberUtil.Val( AV11GridStateFilterValue.gxTpr_Value, "."));
               AssignAttri("", false, "AV43TFCorFE_Sel", StringUtil.Str( (decimal)(AV43TFCorFE_Sel), 1, 0));
            }
            else if ( StringUtil.StrCmp(AV11GridStateFilterValue.gxTpr_Name, "TFCORFORMATO") == 0 )
            {
               AV44TFCorFormato = AV11GridStateFilterValue.gxTpr_Value;
               AssignAttri("", false, "AV44TFCorFormato", AV44TFCorFormato);
            }
            else if ( StringUtil.StrCmp(AV11GridStateFilterValue.gxTpr_Name, "TFCORFORMATO_SEL") == 0 )
            {
               AV45TFCorFormato_Sel = AV11GridStateFilterValue.gxTpr_Value;
               AssignAttri("", false, "AV45TFCorFormato_Sel", AV45TFCorFormato_Sel);
            }
            AV83GXV1 = (int)(AV83GXV1+1);
         }
         GXt_char2 = "";
         new GeneXus.Programs.wwpbaseobjects.wwp_getfilterval(context ).execute(  String.IsNullOrEmpty(StringUtil.RTrim( AV38TFCorDoc_Sel)),  AV38TFCorDoc_Sel, out  GXt_char2) ;
         GXt_char3 = "";
         new GeneXus.Programs.wwpbaseobjects.wwp_getfilterval(context ).execute(  String.IsNullOrEmpty(StringUtil.RTrim( AV42TFCorSerie_Sel)),  AV42TFCorSerie_Sel, out  GXt_char3) ;
         GXt_char4 = "";
         new GeneXus.Programs.wwpbaseobjects.wwp_getfilterval(context ).execute(  String.IsNullOrEmpty(StringUtil.RTrim( AV45TFCorFormato_Sel)),  AV45TFCorFormato_Sel, out  GXt_char4) ;
         Ddo_grid_Selectedvalue_set = GXt_char2+"||"+GXt_char3+"|"+((0==AV43TFCorFE_Sel) ? "" : StringUtil.Str( (decimal)(AV43TFCorFE_Sel), 1, 0))+"|"+GXt_char4;
         ucDdo_grid.SendProperty(context, "", false, Ddo_grid_Internalname, "SelectedValue_set", Ddo_grid_Selectedvalue_set);
         GXt_char4 = "";
         new GeneXus.Programs.wwpbaseobjects.wwp_getfilterval(context ).execute(  String.IsNullOrEmpty(StringUtil.RTrim( AV37TFCorDoc)),  AV37TFCorDoc, out  GXt_char4) ;
         GXt_char3 = "";
         new GeneXus.Programs.wwpbaseobjects.wwp_getfilterval(context ).execute(  String.IsNullOrEmpty(StringUtil.RTrim( AV41TFCorSerie)),  AV41TFCorSerie, out  GXt_char3) ;
         GXt_char2 = "";
         new GeneXus.Programs.wwpbaseobjects.wwp_getfilterval(context ).execute(  String.IsNullOrEmpty(StringUtil.RTrim( AV44TFCorFormato)),  AV44TFCorFormato, out  GXt_char2) ;
         Ddo_grid_Filteredtext_set = GXt_char4+"|"+((0==AV39TFNumDoc) ? "" : StringUtil.Str( (decimal)(AV39TFNumDoc), 10, 0))+"|"+GXt_char3+"||"+GXt_char2;
         ucDdo_grid.SendProperty(context, "", false, Ddo_grid_Internalname, "FilteredText_set", Ddo_grid_Filteredtext_set);
         Ddo_grid_Filteredtextto_set = "|"+((0==AV40TFNumDoc_To) ? "" : StringUtil.Str( (decimal)(AV40TFNumDoc_To), 10, 0))+"|||";
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
         cmbavDynamicfiltersoperator1.Visible = 0;
         AssignProp("", false, cmbavDynamicfiltersoperator1_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(cmbavDynamicfiltersoperator1.Visible), 5, 0), true);
         imgAdddynamicfilters2_Visible = 1;
         AssignProp("", false, imgAdddynamicfilters2_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(imgAdddynamicfilters2_Visible), 5, 0), true);
         imgRemovedynamicfilters2_Visible = 0;
         AssignProp("", false, imgRemovedynamicfilters2_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(imgRemovedynamicfilters2_Visible), 5, 0), true);
         cmbavDynamicfiltersoperator2.Visible = 0;
         AssignProp("", false, cmbavDynamicfiltersoperator2_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(cmbavDynamicfiltersoperator2.Visible), 5, 0), true);
         cmbavDynamicfiltersoperator3.Visible = 0;
         AssignProp("", false, cmbavDynamicfiltersoperator3_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(cmbavDynamicfiltersoperator3.Visible), 5, 0), true);
         if ( AV10GridState.gxTpr_Dynamicfilters.Count >= 1 )
         {
            AV12GridStateDynamicFilter = ((GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter)AV10GridState.gxTpr_Dynamicfilters.Item(1));
            AV15DynamicFiltersSelector1 = AV12GridStateDynamicFilter.gxTpr_Selected;
            AssignAttri("", false, "AV15DynamicFiltersSelector1", AV15DynamicFiltersSelector1);
            if ( StringUtil.StrCmp(AV15DynamicFiltersSelector1, "CORDOC") == 0 )
            {
               AV17CorDoc1 = AV12GridStateDynamicFilter.gxTpr_Value;
               AssignAttri("", false, "AV17CorDoc1", AV17CorDoc1);
            }
            else if ( StringUtil.StrCmp(AV15DynamicFiltersSelector1, "NUMDOC") == 0 )
            {
               AV16DynamicFiltersOperator1 = AV12GridStateDynamicFilter.gxTpr_Operator;
               AssignAttri("", false, "AV16DynamicFiltersOperator1", StringUtil.LTrimStr( (decimal)(AV16DynamicFiltersOperator1), 4, 0));
               AV18NumDoc1 = (long)(NumberUtil.Val( AV12GridStateDynamicFilter.gxTpr_Value, "."));
               AssignAttri("", false, "AV18NumDoc1", StringUtil.LTrimStr( (decimal)(AV18NumDoc1), 10, 0));
            }
            else if ( StringUtil.StrCmp(AV15DynamicFiltersSelector1, "CORSERIE") == 0 )
            {
               AV16DynamicFiltersOperator1 = AV12GridStateDynamicFilter.gxTpr_Operator;
               AssignAttri("", false, "AV16DynamicFiltersOperator1", StringUtil.LTrimStr( (decimal)(AV16DynamicFiltersOperator1), 4, 0));
               AV19CorSerie1 = AV12GridStateDynamicFilter.gxTpr_Value;
               AssignAttri("", false, "AV19CorSerie1", AV19CorSerie1);
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
               AV20DynamicFiltersEnabled2 = true;
               AssignAttri("", false, "AV20DynamicFiltersEnabled2", AV20DynamicFiltersEnabled2);
               AV12GridStateDynamicFilter = ((GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter)AV10GridState.gxTpr_Dynamicfilters.Item(2));
               AV21DynamicFiltersSelector2 = AV12GridStateDynamicFilter.gxTpr_Selected;
               AssignAttri("", false, "AV21DynamicFiltersSelector2", AV21DynamicFiltersSelector2);
               if ( StringUtil.StrCmp(AV21DynamicFiltersSelector2, "CORDOC") == 0 )
               {
                  AV23CorDoc2 = AV12GridStateDynamicFilter.gxTpr_Value;
                  AssignAttri("", false, "AV23CorDoc2", AV23CorDoc2);
               }
               else if ( StringUtil.StrCmp(AV21DynamicFiltersSelector2, "NUMDOC") == 0 )
               {
                  AV22DynamicFiltersOperator2 = AV12GridStateDynamicFilter.gxTpr_Operator;
                  AssignAttri("", false, "AV22DynamicFiltersOperator2", StringUtil.LTrimStr( (decimal)(AV22DynamicFiltersOperator2), 4, 0));
                  AV24NumDoc2 = (long)(NumberUtil.Val( AV12GridStateDynamicFilter.gxTpr_Value, "."));
                  AssignAttri("", false, "AV24NumDoc2", StringUtil.LTrimStr( (decimal)(AV24NumDoc2), 10, 0));
               }
               else if ( StringUtil.StrCmp(AV21DynamicFiltersSelector2, "CORSERIE") == 0 )
               {
                  AV22DynamicFiltersOperator2 = AV12GridStateDynamicFilter.gxTpr_Operator;
                  AssignAttri("", false, "AV22DynamicFiltersOperator2", StringUtil.LTrimStr( (decimal)(AV22DynamicFiltersOperator2), 4, 0));
                  AV25CorSerie2 = AV12GridStateDynamicFilter.gxTpr_Value;
                  AssignAttri("", false, "AV25CorSerie2", AV25CorSerie2);
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
                  AV26DynamicFiltersEnabled3 = true;
                  AssignAttri("", false, "AV26DynamicFiltersEnabled3", AV26DynamicFiltersEnabled3);
                  AV12GridStateDynamicFilter = ((GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter)AV10GridState.gxTpr_Dynamicfilters.Item(3));
                  AV27DynamicFiltersSelector3 = AV12GridStateDynamicFilter.gxTpr_Selected;
                  AssignAttri("", false, "AV27DynamicFiltersSelector3", AV27DynamicFiltersSelector3);
                  if ( StringUtil.StrCmp(AV27DynamicFiltersSelector3, "CORDOC") == 0 )
                  {
                     AV29CorDoc3 = AV12GridStateDynamicFilter.gxTpr_Value;
                     AssignAttri("", false, "AV29CorDoc3", AV29CorDoc3);
                  }
                  else if ( StringUtil.StrCmp(AV27DynamicFiltersSelector3, "NUMDOC") == 0 )
                  {
                     AV28DynamicFiltersOperator3 = AV12GridStateDynamicFilter.gxTpr_Operator;
                     AssignAttri("", false, "AV28DynamicFiltersOperator3", StringUtil.LTrimStr( (decimal)(AV28DynamicFiltersOperator3), 4, 0));
                     AV30NumDoc3 = (long)(NumberUtil.Val( AV12GridStateDynamicFilter.gxTpr_Value, "."));
                     AssignAttri("", false, "AV30NumDoc3", StringUtil.LTrimStr( (decimal)(AV30NumDoc3), 10, 0));
                  }
                  else if ( StringUtil.StrCmp(AV27DynamicFiltersSelector3, "CORSERIE") == 0 )
                  {
                     AV28DynamicFiltersOperator3 = AV12GridStateDynamicFilter.gxTpr_Operator;
                     AssignAttri("", false, "AV28DynamicFiltersOperator3", StringUtil.LTrimStr( (decimal)(AV28DynamicFiltersOperator3), 4, 0));
                     AV31CorSerie3 = AV12GridStateDynamicFilter.gxTpr_Value;
                     AssignAttri("", false, "AV31CorSerie3", AV31CorSerie3);
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
         if ( AV32DynamicFiltersRemoving )
         {
            lblJsdynamicfilters_Caption = "";
            AssignProp("", false, lblJsdynamicfilters_Internalname, "Caption", lblJsdynamicfilters_Caption, true);
         }
      }

      protected void S172( )
      {
         /* 'SAVEGRIDSTATE' Routine */
         returnInSub = false;
         AV10GridState.FromXml(AV36Session.Get(AV56Pgmname+"GridState"), null, "", "");
         AV10GridState.gxTpr_Orderedby = AV13OrderedBy;
         AV10GridState.gxTpr_Ordereddsc = AV14OrderedDsc;
         AV10GridState.gxTpr_Filtervalues.Clear();
         new GeneXus.Programs.wwpbaseobjects.wwp_gridstateaddfiltervalueandsel(context ).execute( ref  AV10GridState,  "TFCORDOC",  "Documento",  !String.IsNullOrEmpty(StringUtil.RTrim( AV37TFCorDoc)),  0,  AV37TFCorDoc,  "",  !String.IsNullOrEmpty(StringUtil.RTrim( AV38TFCorDoc_Sel)),  AV38TFCorDoc_Sel,  "") ;
         new GeneXus.Programs.wwpbaseobjects.wwp_gridstateaddfiltervalue(context ).execute( ref  AV10GridState,  "TFNUMDOC",  "N° Documento",  !((0==AV39TFNumDoc)&&(0==AV40TFNumDoc_To)),  0,  StringUtil.Trim( StringUtil.Str( (decimal)(AV39TFNumDoc), 10, 0)),  StringUtil.Trim( StringUtil.Str( (decimal)(AV40TFNumDoc_To), 10, 0))) ;
         new GeneXus.Programs.wwpbaseobjects.wwp_gridstateaddfiltervalueandsel(context ).execute( ref  AV10GridState,  "TFCORSERIE",  "Serie",  !String.IsNullOrEmpty(StringUtil.RTrim( AV41TFCorSerie)),  0,  AV41TFCorSerie,  "",  !String.IsNullOrEmpty(StringUtil.RTrim( AV42TFCorSerie_Sel)),  AV42TFCorSerie_Sel,  "") ;
         new GeneXus.Programs.wwpbaseobjects.wwp_gridstateaddfiltervalue(context ).execute( ref  AV10GridState,  "TFCORFE_SEL",  "Electronica",  !(0==AV43TFCorFE_Sel),  0,  StringUtil.Trim( StringUtil.Str( (decimal)(AV43TFCorFE_Sel), 1, 0)),  "") ;
         new GeneXus.Programs.wwpbaseobjects.wwp_gridstateaddfiltervalueandsel(context ).execute( ref  AV10GridState,  "TFCORFORMATO",  "Formato",  !String.IsNullOrEmpty(StringUtil.RTrim( AV44TFCorFormato)),  0,  AV44TFCorFormato,  "",  !String.IsNullOrEmpty(StringUtil.RTrim( AV45TFCorFormato_Sel)),  AV45TFCorFormato_Sel,  "") ;
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
         if ( ! AV33DynamicFiltersIgnoreFirst )
         {
            AV12GridStateDynamicFilter = new GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter(context);
            AV12GridStateDynamicFilter.gxTpr_Selected = AV15DynamicFiltersSelector1;
            if ( ( StringUtil.StrCmp(AV15DynamicFiltersSelector1, "CORDOC") == 0 ) && ! String.IsNullOrEmpty(StringUtil.RTrim( AV17CorDoc1)) )
            {
               AV12GridStateDynamicFilter.gxTpr_Dsc = "Tipo Documento";
               AV12GridStateDynamicFilter.gxTpr_Value = AV17CorDoc1;
            }
            else if ( ( StringUtil.StrCmp(AV15DynamicFiltersSelector1, "NUMDOC") == 0 ) && ! (0==AV18NumDoc1) )
            {
               AV12GridStateDynamicFilter.gxTpr_Dsc = "N° Documento";
               AV12GridStateDynamicFilter.gxTpr_Value = StringUtil.Str( (decimal)(AV18NumDoc1), 10, 0);
               AV12GridStateDynamicFilter.gxTpr_Operator = AV16DynamicFiltersOperator1;
            }
            else if ( ( StringUtil.StrCmp(AV15DynamicFiltersSelector1, "CORSERIE") == 0 ) && ! String.IsNullOrEmpty(StringUtil.RTrim( AV19CorSerie1)) )
            {
               AV12GridStateDynamicFilter.gxTpr_Dsc = "Serie";
               AV12GridStateDynamicFilter.gxTpr_Value = AV19CorSerie1;
               AV12GridStateDynamicFilter.gxTpr_Operator = AV16DynamicFiltersOperator1;
            }
            if ( AV32DynamicFiltersRemoving || ! String.IsNullOrEmpty(StringUtil.RTrim( AV12GridStateDynamicFilter.gxTpr_Value)) )
            {
               AV10GridState.gxTpr_Dynamicfilters.Add(AV12GridStateDynamicFilter, 0);
            }
         }
         if ( AV20DynamicFiltersEnabled2 )
         {
            AV12GridStateDynamicFilter = new GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter(context);
            AV12GridStateDynamicFilter.gxTpr_Selected = AV21DynamicFiltersSelector2;
            if ( ( StringUtil.StrCmp(AV21DynamicFiltersSelector2, "CORDOC") == 0 ) && ! String.IsNullOrEmpty(StringUtil.RTrim( AV23CorDoc2)) )
            {
               AV12GridStateDynamicFilter.gxTpr_Dsc = "Tipo Documento";
               AV12GridStateDynamicFilter.gxTpr_Value = AV23CorDoc2;
            }
            else if ( ( StringUtil.StrCmp(AV21DynamicFiltersSelector2, "NUMDOC") == 0 ) && ! (0==AV24NumDoc2) )
            {
               AV12GridStateDynamicFilter.gxTpr_Dsc = "N° Documento";
               AV12GridStateDynamicFilter.gxTpr_Value = StringUtil.Str( (decimal)(AV24NumDoc2), 10, 0);
               AV12GridStateDynamicFilter.gxTpr_Operator = AV22DynamicFiltersOperator2;
            }
            else if ( ( StringUtil.StrCmp(AV21DynamicFiltersSelector2, "CORSERIE") == 0 ) && ! String.IsNullOrEmpty(StringUtil.RTrim( AV25CorSerie2)) )
            {
               AV12GridStateDynamicFilter.gxTpr_Dsc = "Serie";
               AV12GridStateDynamicFilter.gxTpr_Value = AV25CorSerie2;
               AV12GridStateDynamicFilter.gxTpr_Operator = AV22DynamicFiltersOperator2;
            }
            if ( AV32DynamicFiltersRemoving || ! String.IsNullOrEmpty(StringUtil.RTrim( AV12GridStateDynamicFilter.gxTpr_Value)) )
            {
               AV10GridState.gxTpr_Dynamicfilters.Add(AV12GridStateDynamicFilter, 0);
            }
         }
         if ( AV26DynamicFiltersEnabled3 )
         {
            AV12GridStateDynamicFilter = new GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter(context);
            AV12GridStateDynamicFilter.gxTpr_Selected = AV27DynamicFiltersSelector3;
            if ( ( StringUtil.StrCmp(AV27DynamicFiltersSelector3, "CORDOC") == 0 ) && ! String.IsNullOrEmpty(StringUtil.RTrim( AV29CorDoc3)) )
            {
               AV12GridStateDynamicFilter.gxTpr_Dsc = "Tipo Documento";
               AV12GridStateDynamicFilter.gxTpr_Value = AV29CorDoc3;
            }
            else if ( ( StringUtil.StrCmp(AV27DynamicFiltersSelector3, "NUMDOC") == 0 ) && ! (0==AV30NumDoc3) )
            {
               AV12GridStateDynamicFilter.gxTpr_Dsc = "N° Documento";
               AV12GridStateDynamicFilter.gxTpr_Value = StringUtil.Str( (decimal)(AV30NumDoc3), 10, 0);
               AV12GridStateDynamicFilter.gxTpr_Operator = AV28DynamicFiltersOperator3;
            }
            else if ( ( StringUtil.StrCmp(AV27DynamicFiltersSelector3, "CORSERIE") == 0 ) && ! String.IsNullOrEmpty(StringUtil.RTrim( AV31CorSerie3)) )
            {
               AV12GridStateDynamicFilter.gxTpr_Dsc = "Serie";
               AV12GridStateDynamicFilter.gxTpr_Value = AV31CorSerie3;
               AV12GridStateDynamicFilter.gxTpr_Operator = AV28DynamicFiltersOperator3;
            }
            if ( AV32DynamicFiltersRemoving || ! String.IsNullOrEmpty(StringUtil.RTrim( AV12GridStateDynamicFilter.gxTpr_Value)) )
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
         AV8TrnContext.gxTpr_Transactionname = "Seguridad.NumeracionDocumentos";
         AV36Session.Set("TrnContext", AV8TrnContext.ToXml(false, true, "", ""));
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
         new GeneXus.Programs.seguridad.numeraciondocumentoswwexport(context ).execute( out  AV34ExcelFilename, out  AV35ErrorMessage) ;
         if ( StringUtil.StrCmp(AV34ExcelFilename, "") != 0 )
         {
            CallWebObject(formatLink(AV34ExcelFilename) );
            context.wjLocDisableFrm = 0;
         }
         else
         {
            GX_msglist.addItem(AV35ErrorMessage);
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
         Innewwindow1_Target = formatLink("seguridad.numeraciondocumentoswwexportreport.aspx") ;
         ucInnewwindow1.SendProperty(context, "", false, Innewwindow1_Internalname, "Target", Innewwindow1_Target);
         Innewwindow1_Height = "600";
         ucInnewwindow1.SendProperty(context, "", false, Innewwindow1_Internalname, "Height", Innewwindow1_Height);
         Innewwindow1_Width = "800";
         ucInnewwindow1.SendProperty(context, "", false, Innewwindow1_Internalname, "Width", Innewwindow1_Width);
         this.executeUsercontrolMethod("", false, "INNEWWINDOW1Container", "OpenWindow", "", new Object[] {});
      }

      protected void wb_table1_25_0F2( bool wbgen )
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
            GxWebStd.gx_label_ctrl( context, lblDynamicfiltersprefix1_Internalname, "Buscar en", "", "", lblDynamicfiltersprefix1_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "DataFilterDescriptionPrefix", 0, "", 1, 1, 0, 0, "HLP_Seguridad\\NumeracionDocumentosWW.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "", "left", "top", "", "flex-grow:1;", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "left", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, cmbavDynamicfiltersselector1_Internalname, "Dynamic Filters Selector1", "gx-form-item AttributeLabel", 0, true, "width: 25%;");
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 35,'',false,'" + sGXsfl_119_idx + "',0)\"";
            /* ComboBox */
            GxWebStd.gx_combobox_ctrl1( context, cmbavDynamicfiltersselector1, cmbavDynamicfiltersselector1_Internalname, StringUtil.RTrim( AV15DynamicFiltersSelector1), 1, cmbavDynamicfiltersselector1_Jsonclick, 5, "'"+""+"'"+",false,"+"'"+"EVDYNAMICFILTERSSELECTOR1.CLICK."+"'", "svchar", "", 1, cmbavDynamicfiltersselector1.Enabled, 0, 0, 0, "em", 0, "", "", "Attribute", "", "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,35);\"", "", true, 1, "HLP_Seguridad\\NumeracionDocumentosWW.htm");
            cmbavDynamicfiltersselector1.CurrentValue = StringUtil.RTrim( AV15DynamicFiltersSelector1);
            AssignProp("", false, cmbavDynamicfiltersselector1_Internalname, "Values", (string)(cmbavDynamicfiltersselector1.ToJavascriptSource()), true);
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "", "left", "top", "", "flex-grow:1;", "div");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblDynamicfiltersmiddle1_Internalname, "valor", "", "", lblDynamicfiltersmiddle1_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "DataFilterDescription", 0, "", 1, 1, 0, 0, "HLP_Seguridad\\NumeracionDocumentosWW.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "", "left", "top", "", "flex-grow:1;", "div");
            wb_table2_39_0F2( true) ;
         }
         else
         {
            wb_table2_39_0F2( false) ;
         }
         return  ;
      }

      protected void wb_table2_39_0F2e( bool wbgen )
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
            GxWebStd.gx_label_ctrl( context, lblDynamicfiltersprefix2_Internalname, "Buscar en", "", "", lblDynamicfiltersprefix2_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "DataFilterDescriptionPrefix", 0, "", 1, 1, 0, 0, "HLP_Seguridad\\NumeracionDocumentosWW.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "Invisible", "left", "top", "", "flex-grow:1;", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "left", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, cmbavDynamicfiltersselector2_Internalname, "Dynamic Filters Selector2", "gx-form-item AttributeLabel", 0, true, "width: 25%;");
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 63,'',false,'" + sGXsfl_119_idx + "',0)\"";
            /* ComboBox */
            GxWebStd.gx_combobox_ctrl1( context, cmbavDynamicfiltersselector2, cmbavDynamicfiltersselector2_Internalname, StringUtil.RTrim( AV21DynamicFiltersSelector2), 1, cmbavDynamicfiltersselector2_Jsonclick, 5, "'"+""+"'"+",false,"+"'"+"EVDYNAMICFILTERSSELECTOR2.CLICK."+"'", "svchar", "", 1, cmbavDynamicfiltersselector2.Enabled, 0, 0, 0, "em", 0, "", "", "Attribute", "", "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,63);\"", "", true, 1, "HLP_Seguridad\\NumeracionDocumentosWW.htm");
            cmbavDynamicfiltersselector2.CurrentValue = StringUtil.RTrim( AV21DynamicFiltersSelector2);
            AssignProp("", false, cmbavDynamicfiltersselector2_Internalname, "Values", (string)(cmbavDynamicfiltersselector2.ToJavascriptSource()), true);
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "Invisible", "left", "top", "", "flex-grow:1;", "div");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblDynamicfiltersmiddle2_Internalname, "valor", "", "", lblDynamicfiltersmiddle2_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "DataFilterDescription", 0, "", 1, 1, 0, 0, "HLP_Seguridad\\NumeracionDocumentosWW.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "Invisible", "left", "top", "", "flex-grow:1;", "div");
            wb_table3_67_0F2( true) ;
         }
         else
         {
            wb_table3_67_0F2( false) ;
         }
         return  ;
      }

      protected void wb_table3_67_0F2e( bool wbgen )
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
            GxWebStd.gx_label_ctrl( context, lblDynamicfiltersprefix3_Internalname, "Buscar en", "", "", lblDynamicfiltersprefix3_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "DataFilterDescriptionPrefix", 0, "", 1, 1, 0, 0, "HLP_Seguridad\\NumeracionDocumentosWW.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "Invisible", "left", "top", "", "flex-grow:1;", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "left", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, cmbavDynamicfiltersselector3_Internalname, "Dynamic Filters Selector3", "gx-form-item AttributeLabel", 0, true, "width: 25%;");
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 91,'',false,'" + sGXsfl_119_idx + "',0)\"";
            /* ComboBox */
            GxWebStd.gx_combobox_ctrl1( context, cmbavDynamicfiltersselector3, cmbavDynamicfiltersselector3_Internalname, StringUtil.RTrim( AV27DynamicFiltersSelector3), 1, cmbavDynamicfiltersselector3_Jsonclick, 5, "'"+""+"'"+",false,"+"'"+"EVDYNAMICFILTERSSELECTOR3.CLICK."+"'", "svchar", "", 1, cmbavDynamicfiltersselector3.Enabled, 0, 0, 0, "em", 0, "", "", "Attribute", "", "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,91);\"", "", true, 1, "HLP_Seguridad\\NumeracionDocumentosWW.htm");
            cmbavDynamicfiltersselector3.CurrentValue = StringUtil.RTrim( AV27DynamicFiltersSelector3);
            AssignProp("", false, cmbavDynamicfiltersselector3_Internalname, "Values", (string)(cmbavDynamicfiltersselector3.ToJavascriptSource()), true);
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "Invisible", "left", "top", "", "flex-grow:1;", "div");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblDynamicfiltersmiddle3_Internalname, "valor", "", "", lblDynamicfiltersmiddle3_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "DataFilterDescription", 0, "", 1, 1, 0, 0, "HLP_Seguridad\\NumeracionDocumentosWW.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "Invisible", "left", "top", "", "flex-grow:1;", "div");
            wb_table4_95_0F2( true) ;
         }
         else
         {
            wb_table4_95_0F2( false) ;
         }
         return  ;
      }

      protected void wb_table4_95_0F2e( bool wbgen )
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
            wb_table1_25_0F2e( true) ;
         }
         else
         {
            wb_table1_25_0F2e( false) ;
         }
      }

      protected void wb_table4_95_0F2( bool wbgen )
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
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 99,'',false,'" + sGXsfl_119_idx + "',0)\"";
            /* ComboBox */
            GxWebStd.gx_combobox_ctrl1( context, cmbavDynamicfiltersoperator3, cmbavDynamicfiltersoperator3_Internalname, StringUtil.Trim( StringUtil.Str( (decimal)(AV28DynamicFiltersOperator3), 4, 0)), 1, cmbavDynamicfiltersoperator3_Jsonclick, 0, "'"+""+"'"+",false,"+"'"+""+"'", "int", "", cmbavDynamicfiltersoperator3.Visible, cmbavDynamicfiltersoperator3.Enabled, 0, 0, 0, "em", 0, "", "", "Attribute", "", "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,99);\"", "", true, 1, "HLP_Seguridad\\NumeracionDocumentosWW.htm");
            cmbavDynamicfiltersoperator3.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV28DynamicFiltersOperator3), 4, 0));
            AssignProp("", false, cmbavDynamicfiltersoperator3_Internalname, "Values", (string)(cmbavDynamicfiltersoperator3.ToJavascriptSource()), true);
            GxWebStd.gx_div_end( context, "left", "top", "div");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "<td id=\""+cellFilter_cordoc3_cell_Internalname+"\"  class=''>") ;
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "left", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, cmbavCordoc3_Internalname, "Cor Doc3", "gx-form-item AttributeLabel", 0, true, "width: 25%;");
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 102,'',false,'" + sGXsfl_119_idx + "',0)\"";
            /* ComboBox */
            GxWebStd.gx_combobox_ctrl1( context, cmbavCordoc3, cmbavCordoc3_Internalname, StringUtil.RTrim( AV29CorDoc3), 1, cmbavCordoc3_Jsonclick, 0, "'"+""+"'"+",false,"+"'"+""+"'", "char", "", cmbavCordoc3.Visible, cmbavCordoc3.Enabled, 0, 0, 0, "em", 0, "", "", "Attribute", "", "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,102);\"", "", true, 1, "HLP_Seguridad\\NumeracionDocumentosWW.htm");
            cmbavCordoc3.CurrentValue = StringUtil.RTrim( AV29CorDoc3);
            AssignProp("", false, cmbavCordoc3_Internalname, "Values", (string)(cmbavCordoc3.ToJavascriptSource()), true);
            GxWebStd.gx_div_end( context, "left", "top", "div");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "<td id=\""+cellFilter_numdoc3_cell_Internalname+"\"  class=''>") ;
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "left", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavNumdoc3_Internalname, "Num Doc3", "gx-form-item AttributeLabel", 0, true, "width: 25%;");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 105,'',false,'" + sGXsfl_119_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavNumdoc3_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(AV30NumDoc3), 10, 0, ".", "")), StringUtil.LTrim( ((edtavNumdoc3_Enabled!=0) ? context.localUtil.Format( (decimal)(AV30NumDoc3), "ZZZZZZZZZ9") : context.localUtil.Format( (decimal)(AV30NumDoc3), "ZZZZZZZZZ9"))), " inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onblur(this,105);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavNumdoc3_Jsonclick, 0, "Attribute", "", "", "", "", edtavNumdoc3_Visible, edtavNumdoc3_Enabled, 0, "text", "1", 10, "chr", 1, "row", 10, 0, 0, 0, 1, -1, 0, true, "", "right", false, "", "HLP_Seguridad\\NumeracionDocumentosWW.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "<td id=\""+cellFilter_corserie3_cell_Internalname+"\"  class=''>") ;
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "left", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavCorserie3_Internalname, "Cor Serie3", "gx-form-item AttributeLabel", 0, true, "width: 25%;");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 108,'',false,'" + sGXsfl_119_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavCorserie3_Internalname, StringUtil.RTrim( AV31CorSerie3), StringUtil.RTrim( context.localUtil.Format( AV31CorSerie3, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,108);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavCorserie3_Jsonclick, 0, "Attribute", "", "", "", "", edtavCorserie3_Visible, edtavCorserie3_Enabled, 0, "text", "", 4, "chr", 1, "row", 4, 0, 0, 0, 1, -1, -1, true, "", "left", true, "", "HLP_Seguridad\\NumeracionDocumentosWW.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "<td id=\""+cellDynamicfilters_removefilter3_cell_Internalname+"\"  class=''>") ;
            /* Active images/pictures */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 110,'',false,'',0)\"";
            ClassString = "Image";
            StyleString = "";
            sImgUrl = (string)(context.GetImagePath( "11a6ef14-1a5a-4077-91a2-f41ed9a3a662", "", context.GetTheme( )));
            GxWebStd.gx_bitmap( context, imgRemovedynamicfilters3_Internalname, sImgUrl, "", "", "", context.GetTheme( ), 1, 1, "", "Quitar filtro", 0, 0, 0, "px", 0, "px", 0, 0, 5, imgRemovedynamicfilters3_Jsonclick, "'"+""+"'"+",false,"+"'"+"E\\'REMOVEDYNAMICFILTERS3\\'."+"'", StyleString, ClassString, "", "", "", "", " "+"data-gx-image"+" "+TempTags, "", "", 1, false, false, context.GetImageSrcSet( sImgUrl), "HLP_Seguridad\\NumeracionDocumentosWW.htm");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "</tr>") ;
            /* End of table */
            context.WriteHtmlText( "</table>") ;
            wb_table4_95_0F2e( true) ;
         }
         else
         {
            wb_table4_95_0F2e( false) ;
         }
      }

      protected void wb_table3_67_0F2( bool wbgen )
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
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 71,'',false,'" + sGXsfl_119_idx + "',0)\"";
            /* ComboBox */
            GxWebStd.gx_combobox_ctrl1( context, cmbavDynamicfiltersoperator2, cmbavDynamicfiltersoperator2_Internalname, StringUtil.Trim( StringUtil.Str( (decimal)(AV22DynamicFiltersOperator2), 4, 0)), 1, cmbavDynamicfiltersoperator2_Jsonclick, 0, "'"+""+"'"+",false,"+"'"+""+"'", "int", "", cmbavDynamicfiltersoperator2.Visible, cmbavDynamicfiltersoperator2.Enabled, 0, 0, 0, "em", 0, "", "", "Attribute", "", "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,71);\"", "", true, 1, "HLP_Seguridad\\NumeracionDocumentosWW.htm");
            cmbavDynamicfiltersoperator2.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV22DynamicFiltersOperator2), 4, 0));
            AssignProp("", false, cmbavDynamicfiltersoperator2_Internalname, "Values", (string)(cmbavDynamicfiltersoperator2.ToJavascriptSource()), true);
            GxWebStd.gx_div_end( context, "left", "top", "div");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "<td id=\""+cellFilter_cordoc2_cell_Internalname+"\"  class=''>") ;
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "left", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, cmbavCordoc2_Internalname, "Cor Doc2", "gx-form-item AttributeLabel", 0, true, "width: 25%;");
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 74,'',false,'" + sGXsfl_119_idx + "',0)\"";
            /* ComboBox */
            GxWebStd.gx_combobox_ctrl1( context, cmbavCordoc2, cmbavCordoc2_Internalname, StringUtil.RTrim( AV23CorDoc2), 1, cmbavCordoc2_Jsonclick, 0, "'"+""+"'"+",false,"+"'"+""+"'", "char", "", cmbavCordoc2.Visible, cmbavCordoc2.Enabled, 0, 0, 0, "em", 0, "", "", "Attribute", "", "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,74);\"", "", true, 1, "HLP_Seguridad\\NumeracionDocumentosWW.htm");
            cmbavCordoc2.CurrentValue = StringUtil.RTrim( AV23CorDoc2);
            AssignProp("", false, cmbavCordoc2_Internalname, "Values", (string)(cmbavCordoc2.ToJavascriptSource()), true);
            GxWebStd.gx_div_end( context, "left", "top", "div");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "<td id=\""+cellFilter_numdoc2_cell_Internalname+"\"  class=''>") ;
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "left", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavNumdoc2_Internalname, "Num Doc2", "gx-form-item AttributeLabel", 0, true, "width: 25%;");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 77,'',false,'" + sGXsfl_119_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavNumdoc2_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(AV24NumDoc2), 10, 0, ".", "")), StringUtil.LTrim( ((edtavNumdoc2_Enabled!=0) ? context.localUtil.Format( (decimal)(AV24NumDoc2), "ZZZZZZZZZ9") : context.localUtil.Format( (decimal)(AV24NumDoc2), "ZZZZZZZZZ9"))), " inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onblur(this,77);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavNumdoc2_Jsonclick, 0, "Attribute", "", "", "", "", edtavNumdoc2_Visible, edtavNumdoc2_Enabled, 0, "text", "1", 10, "chr", 1, "row", 10, 0, 0, 0, 1, -1, 0, true, "", "right", false, "", "HLP_Seguridad\\NumeracionDocumentosWW.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "<td id=\""+cellFilter_corserie2_cell_Internalname+"\"  class=''>") ;
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "left", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavCorserie2_Internalname, "Cor Serie2", "gx-form-item AttributeLabel", 0, true, "width: 25%;");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 80,'',false,'" + sGXsfl_119_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavCorserie2_Internalname, StringUtil.RTrim( AV25CorSerie2), StringUtil.RTrim( context.localUtil.Format( AV25CorSerie2, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,80);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavCorserie2_Jsonclick, 0, "Attribute", "", "", "", "", edtavCorserie2_Visible, edtavCorserie2_Enabled, 0, "text", "", 4, "chr", 1, "row", 4, 0, 0, 0, 1, -1, -1, true, "", "left", true, "", "HLP_Seguridad\\NumeracionDocumentosWW.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "<td id=\""+cellDynamicfilters_addfilter2_cell_Internalname+"\"  class=''>") ;
            /* Active images/pictures */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 82,'',false,'',0)\"";
            ClassString = "Image";
            StyleString = "";
            sImgUrl = (string)(context.GetImagePath( "27283ea5-332f-423b-b880-64b762622df3", "", context.GetTheme( )));
            GxWebStd.gx_bitmap( context, imgAdddynamicfilters2_Internalname, sImgUrl, "", "", "", context.GetTheme( ), imgAdddynamicfilters2_Visible, 1, "", "Agregar filtro", 0, 0, 0, "px", 0, "px", 0, 0, 5, imgAdddynamicfilters2_Jsonclick, "'"+""+"'"+",false,"+"'"+"E\\'ADDDYNAMICFILTERS2\\'."+"'", StyleString, ClassString, "", "", "", "", " "+"data-gx-image"+" "+TempTags, "", "", 1, false, false, context.GetImageSrcSet( sImgUrl), "HLP_Seguridad\\NumeracionDocumentosWW.htm");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "<td id=\""+cellDynamicfilters_removefilter2_cell_Internalname+"\"  class=''>") ;
            /* Active images/pictures */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 84,'',false,'',0)\"";
            ClassString = "Image";
            StyleString = "";
            sImgUrl = (string)(context.GetImagePath( "11a6ef14-1a5a-4077-91a2-f41ed9a3a662", "", context.GetTheme( )));
            GxWebStd.gx_bitmap( context, imgRemovedynamicfilters2_Internalname, sImgUrl, "", "", "", context.GetTheme( ), imgRemovedynamicfilters2_Visible, 1, "", "Quitar filtro", 0, 0, 0, "px", 0, "px", 0, 0, 5, imgRemovedynamicfilters2_Jsonclick, "'"+""+"'"+",false,"+"'"+"E\\'REMOVEDYNAMICFILTERS2\\'."+"'", StyleString, ClassString, "", "", "", "", " "+"data-gx-image"+" "+TempTags, "", "", 1, false, false, context.GetImageSrcSet( sImgUrl), "HLP_Seguridad\\NumeracionDocumentosWW.htm");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "</tr>") ;
            /* End of table */
            context.WriteHtmlText( "</table>") ;
            wb_table3_67_0F2e( true) ;
         }
         else
         {
            wb_table3_67_0F2e( false) ;
         }
      }

      protected void wb_table2_39_0F2( bool wbgen )
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
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 43,'',false,'" + sGXsfl_119_idx + "',0)\"";
            /* ComboBox */
            GxWebStd.gx_combobox_ctrl1( context, cmbavDynamicfiltersoperator1, cmbavDynamicfiltersoperator1_Internalname, StringUtil.Trim( StringUtil.Str( (decimal)(AV16DynamicFiltersOperator1), 4, 0)), 1, cmbavDynamicfiltersoperator1_Jsonclick, 0, "'"+""+"'"+",false,"+"'"+""+"'", "int", "", cmbavDynamicfiltersoperator1.Visible, cmbavDynamicfiltersoperator1.Enabled, 0, 0, 0, "em", 0, "", "", "Attribute", "", "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,43);\"", "", true, 1, "HLP_Seguridad\\NumeracionDocumentosWW.htm");
            cmbavDynamicfiltersoperator1.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV16DynamicFiltersOperator1), 4, 0));
            AssignProp("", false, cmbavDynamicfiltersoperator1_Internalname, "Values", (string)(cmbavDynamicfiltersoperator1.ToJavascriptSource()), true);
            GxWebStd.gx_div_end( context, "left", "top", "div");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "<td id=\""+cellFilter_cordoc1_cell_Internalname+"\"  class=''>") ;
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "left", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, cmbavCordoc1_Internalname, "Cor Doc1", "gx-form-item AttributeLabel", 0, true, "width: 25%;");
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 46,'',false,'" + sGXsfl_119_idx + "',0)\"";
            /* ComboBox */
            GxWebStd.gx_combobox_ctrl1( context, cmbavCordoc1, cmbavCordoc1_Internalname, StringUtil.RTrim( AV17CorDoc1), 1, cmbavCordoc1_Jsonclick, 0, "'"+""+"'"+",false,"+"'"+""+"'", "char", "", cmbavCordoc1.Visible, cmbavCordoc1.Enabled, 0, 0, 0, "em", 0, "", "", "Attribute", "", "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,46);\"", "", true, 1, "HLP_Seguridad\\NumeracionDocumentosWW.htm");
            cmbavCordoc1.CurrentValue = StringUtil.RTrim( AV17CorDoc1);
            AssignProp("", false, cmbavCordoc1_Internalname, "Values", (string)(cmbavCordoc1.ToJavascriptSource()), true);
            GxWebStd.gx_div_end( context, "left", "top", "div");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "<td id=\""+cellFilter_numdoc1_cell_Internalname+"\"  class=''>") ;
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "left", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavNumdoc1_Internalname, "Num Doc1", "gx-form-item AttributeLabel", 0, true, "width: 25%;");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 49,'',false,'" + sGXsfl_119_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavNumdoc1_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(AV18NumDoc1), 10, 0, ".", "")), StringUtil.LTrim( ((edtavNumdoc1_Enabled!=0) ? context.localUtil.Format( (decimal)(AV18NumDoc1), "ZZZZZZZZZ9") : context.localUtil.Format( (decimal)(AV18NumDoc1), "ZZZZZZZZZ9"))), " inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onblur(this,49);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavNumdoc1_Jsonclick, 0, "Attribute", "", "", "", "", edtavNumdoc1_Visible, edtavNumdoc1_Enabled, 0, "text", "1", 10, "chr", 1, "row", 10, 0, 0, 0, 1, -1, 0, true, "", "right", false, "", "HLP_Seguridad\\NumeracionDocumentosWW.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "<td id=\""+cellFilter_corserie1_cell_Internalname+"\"  class=''>") ;
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "left", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavCorserie1_Internalname, "Cor Serie1", "gx-form-item AttributeLabel", 0, true, "width: 25%;");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 52,'',false,'" + sGXsfl_119_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavCorserie1_Internalname, StringUtil.RTrim( AV19CorSerie1), StringUtil.RTrim( context.localUtil.Format( AV19CorSerie1, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,52);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavCorserie1_Jsonclick, 0, "Attribute", "", "", "", "", edtavCorserie1_Visible, edtavCorserie1_Enabled, 0, "text", "", 4, "chr", 1, "row", 4, 0, 0, 0, 1, -1, -1, true, "", "left", true, "", "HLP_Seguridad\\NumeracionDocumentosWW.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "<td id=\""+cellDynamicfilters_addfilter1_cell_Internalname+"\"  class=''>") ;
            /* Active images/pictures */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 54,'',false,'',0)\"";
            ClassString = "Image";
            StyleString = "";
            sImgUrl = (string)(context.GetImagePath( "27283ea5-332f-423b-b880-64b762622df3", "", context.GetTheme( )));
            GxWebStd.gx_bitmap( context, imgAdddynamicfilters1_Internalname, sImgUrl, "", "", "", context.GetTheme( ), imgAdddynamicfilters1_Visible, 1, "", "Agregar filtro", 0, 0, 0, "px", 0, "px", 0, 0, 5, imgAdddynamicfilters1_Jsonclick, "'"+""+"'"+",false,"+"'"+"E\\'ADDDYNAMICFILTERS1\\'."+"'", StyleString, ClassString, "", "", "", "", " "+"data-gx-image"+" "+TempTags, "", "", 1, false, false, context.GetImageSrcSet( sImgUrl), "HLP_Seguridad\\NumeracionDocumentosWW.htm");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "<td id=\""+cellDynamicfilters_removefilter1_cell_Internalname+"\"  class=''>") ;
            /* Active images/pictures */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 56,'',false,'',0)\"";
            ClassString = "Image";
            StyleString = "";
            sImgUrl = (string)(context.GetImagePath( "11a6ef14-1a5a-4077-91a2-f41ed9a3a662", "", context.GetTheme( )));
            GxWebStd.gx_bitmap( context, imgRemovedynamicfilters1_Internalname, sImgUrl, "", "", "", context.GetTheme( ), imgRemovedynamicfilters1_Visible, 1, "", "Quitar filtro", 0, 0, 0, "px", 0, "px", 0, 0, 5, imgRemovedynamicfilters1_Jsonclick, "'"+""+"'"+",false,"+"'"+"E\\'REMOVEDYNAMICFILTERS1\\'."+"'", StyleString, ClassString, "", "", "", "", " "+"data-gx-image"+" "+TempTags, "", "", 1, false, false, context.GetImageSrcSet( sImgUrl), "HLP_Seguridad\\NumeracionDocumentosWW.htm");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "</tr>") ;
            /* End of table */
            context.WriteHtmlText( "</table>") ;
            wb_table2_39_0F2e( true) ;
         }
         else
         {
            wb_table2_39_0F2e( false) ;
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
         PA0F2( ) ;
         WS0F2( ) ;
         WE0F2( ) ;
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
            context.AddJavascriptSource(StringUtil.RTrim( ((string)Form.Jscriptsrc.Item(idxLst))), "?20228181027496", true, true);
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
         context.AddJavascriptSource("seguridad/numeraciondocumentosww.js", "?20228181027496", false, true);
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

      protected void SubsflControlProps_1192( )
      {
         cmbavGridactions_Internalname = "vGRIDACTIONS_"+sGXsfl_119_idx;
         edtCorDoc_Internalname = "CORDOC_"+sGXsfl_119_idx;
         edtNumDoc_Internalname = "NUMDOC_"+sGXsfl_119_idx;
         edtCorSerie_Internalname = "CORSERIE_"+sGXsfl_119_idx;
         chkCorFE_Internalname = "CORFE_"+sGXsfl_119_idx;
         edtCorFormato_Internalname = "CORFORMATO_"+sGXsfl_119_idx;
      }

      protected void SubsflControlProps_fel_1192( )
      {
         cmbavGridactions_Internalname = "vGRIDACTIONS_"+sGXsfl_119_fel_idx;
         edtCorDoc_Internalname = "CORDOC_"+sGXsfl_119_fel_idx;
         edtNumDoc_Internalname = "NUMDOC_"+sGXsfl_119_fel_idx;
         edtCorSerie_Internalname = "CORSERIE_"+sGXsfl_119_fel_idx;
         chkCorFE_Internalname = "CORFE_"+sGXsfl_119_fel_idx;
         edtCorFormato_Internalname = "CORFORMATO_"+sGXsfl_119_fel_idx;
      }

      protected void sendrow_1192( )
      {
         SubsflControlProps_1192( ) ;
         WB0F0( ) ;
         if ( ( subGrid_Rows * 1 == 0 ) || ( nGXsfl_119_idx <= subGrid_fnc_Recordsperpage( ) * 1 ) )
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
               if ( ((int)((nGXsfl_119_idx) % (2))) == 0 )
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
               context.WriteHtmlText( " gxrow=\""+sGXsfl_119_idx+"\">") ;
            }
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"right"+"\""+" style=\""+""+"\">") ;
            }
            TempTags = " " + ((cmbavGridactions.Enabled!=0)&&(cmbavGridactions.Visible!=0) ? " onfocus=\"gx.evt.onfocus(this, 120,'',false,'"+sGXsfl_119_idx+"',119)\"" : " ");
            if ( ( cmbavGridactions.ItemCount == 0 ) && isAjaxCallMode( ) )
            {
               GXCCtl = "vGRIDACTIONS_" + sGXsfl_119_idx;
               cmbavGridactions.Name = GXCCtl;
               cmbavGridactions.WebTags = "";
               if ( cmbavGridactions.ItemCount > 0 )
               {
                  AV51GridActions = (short)(NumberUtil.Val( cmbavGridactions.getValidValue(StringUtil.Trim( StringUtil.Str( (decimal)(AV51GridActions), 4, 0))), "."));
                  AssignAttri("", false, cmbavGridactions_Internalname, StringUtil.LTrimStr( (decimal)(AV51GridActions), 4, 0));
               }
            }
            /* ComboBox */
            GridRow.AddColumnProperties("combobox", 2, isAjaxCallMode( ), new Object[] {(GXCombobox)cmbavGridactions,(string)cmbavGridactions_Internalname,StringUtil.Trim( StringUtil.Str( (decimal)(AV51GridActions), 4, 0)),(short)1,(string)cmbavGridactions_Jsonclick,(short)5,"'"+""+"'"+",false,"+"'"+"EVGRIDACTIONS.CLICK."+sGXsfl_119_idx+"'",(string)"int",(string)"",(short)-1,(short)1,(short)0,(short)0,(short)0,(string)"px",(short)0,(string)"px",(string)"",(string)"ConvertToDDO",(string)"WWActionGroupColumn",(string)"",TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+((cmbavGridactions.Enabled!=0)&&(cmbavGridactions.Visible!=0) ? " onblur=\""+""+";gx.evt.onblur(this,120);\"" : " "),(string)"",(bool)true,(short)1});
            cmbavGridactions.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV51GridActions), 4, 0));
            AssignProp("", false, cmbavGridactions_Internalname, "Values", (string)(cmbavGridactions.ToJavascriptSource()), !bGXsfl_119_Refreshing);
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"left"+"\""+" style=\""+""+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtCorDoc_Internalname,StringUtil.RTrim( A339CorDoc),(string)"",(string)"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtCorDoc_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn",(string)"",(short)-1,(short)0,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)10,(short)0,(short)0,(short)119,(short)1,(short)-1,(short)-1,(bool)true,(string)"",(string)"left",(bool)true,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"right"+"\""+" style=\""+""+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtNumDoc_Internalname,StringUtil.LTrim( StringUtil.NToC( (decimal)(A1377NumDoc), 10, 0, ".", "")),StringUtil.LTrim( context.localUtil.Format( (decimal)(A1377NumDoc), "ZZZZZZZZZ9")),(string)" inputmode=\"numeric\" pattern=\"[0-9]*\""+"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)edtNumDoc_Link,(string)"",(string)"",(string)"",(string)edtNumDoc_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn",(string)"",(short)-1,(short)0,(short)0,(string)"text",(string)"1",(short)0,(string)"px",(short)17,(string)"px",(short)10,(short)0,(short)0,(short)119,(short)1,(short)-1,(short)0,(bool)true,(string)"",(string)"right",(bool)false,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"left"+"\""+" style=\""+""+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtCorSerie_Internalname,StringUtil.RTrim( A340CorSerie),(string)"",(string)"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtCorSerie_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn",(string)"",(short)-1,(short)0,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)4,(short)0,(short)0,(short)119,(short)1,(short)-1,(short)-1,(bool)true,(string)"",(string)"left",(bool)true,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+""+"\""+" style=\""+""+"\">") ;
            }
            /* Check box */
            ClassString = "AttributeCheckBox";
            StyleString = "";
            GXCCtl = "CORFE_" + sGXsfl_119_idx;
            chkCorFE.Name = GXCCtl;
            chkCorFE.WebTags = "";
            chkCorFE.Caption = "";
            AssignProp("", false, chkCorFE_Internalname, "TitleCaption", chkCorFE.Caption, !bGXsfl_119_Refreshing);
            chkCorFE.CheckedValue = "0";
            A756CorFE = (short)(((StringUtil.StrCmp(StringUtil.LTrim( StringUtil.NToC( (decimal)(A756CorFE), 1, 0, ".", "")), "1")==0) ? 1 : 0));
            GridRow.AddColumnProperties("checkbox", 1, isAjaxCallMode( ), new Object[] {(string)chkCorFE_Internalname,StringUtil.Str( (decimal)(A756CorFE), 1, 0),(string)"",(string)"",(short)-1,(short)0,(string)"1",(string)"",(string)StyleString,(string)ClassString,(string)"WWColumn hidden-xs",(string)"",(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"left"+"\""+" style=\""+""+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtCorFormato_Internalname,(string)A757CorFormato,(string)"",(string)"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtCorFormato_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn hidden-xs",(string)"",(short)-1,(short)0,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)50,(short)0,(short)0,(short)119,(short)1,(short)-1,(short)-1,(bool)true,(string)"",(string)"left",(bool)true,(string)""});
            send_integrity_lvl_hashes0F2( ) ;
            GridContainer.AddRow(GridRow);
            nGXsfl_119_idx = ((subGrid_Islastpage==1)&&(nGXsfl_119_idx+1>subGrid_fnc_Recordsperpage( )) ? 1 : nGXsfl_119_idx+1);
            sGXsfl_119_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_119_idx), 4, 0), 4, "0");
            SubsflControlProps_1192( ) ;
         }
         /* End function sendrow_1192 */
      }

      protected void init_web_controls( )
      {
         cmbavDynamicfiltersselector1.Name = "vDYNAMICFILTERSSELECTOR1";
         cmbavDynamicfiltersselector1.WebTags = "";
         cmbavDynamicfiltersselector1.addItem("CORDOC", "Tipo Documento", 0);
         cmbavDynamicfiltersselector1.addItem("NUMDOC", "N° Documento", 0);
         cmbavDynamicfiltersselector1.addItem("CORSERIE", "Serie", 0);
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
         cmbavCordoc1.Name = "vCORDOC1";
         cmbavCordoc1.WebTags = "";
         cmbavCordoc1.addItem("", "(Ninguno)", 0);
         cmbavCordoc1.addItem("FACTURA", "FACTURA", 0);
         cmbavCordoc1.addItem("NOTCREDITO", "NOTA DE CREDITO", 0);
         cmbavCordoc1.addItem("NOTDEBITO", "NOTA DE DEBITO", 0);
         cmbavCordoc1.addItem("BOLETA", "BOLETA", 0);
         cmbavCordoc1.addItem("REMISION", "REMISION", 0);
         cmbavCordoc1.addItem("LETRA", "LETRA DE CAMBIO", 0);
         cmbavCordoc1.addItem("PERCEPCION", "PERCEPCION", 0);
         cmbavCordoc1.addItem("RECIBO", "RECIBO", 0);
         cmbavCordoc1.addItem("ENTRADA", "ENTRADA", 0);
         cmbavCordoc1.addItem("SALIDA", "SALIDA", 0);
         cmbavCordoc1.addItem("ORDENCOMPR", "ORDEN DE COMPRA", 0);
         cmbavCordoc1.addItem("RETENCION", "RETENCION", 0);
         cmbavCordoc1.addItem("TICKET", "TICKET", 0);
         if ( cmbavCordoc1.ItemCount > 0 )
         {
            AV17CorDoc1 = cmbavCordoc1.getValidValue(AV17CorDoc1);
            AssignAttri("", false, "AV17CorDoc1", AV17CorDoc1);
         }
         cmbavDynamicfiltersselector2.Name = "vDYNAMICFILTERSSELECTOR2";
         cmbavDynamicfiltersselector2.WebTags = "";
         cmbavDynamicfiltersselector2.addItem("CORDOC", "Tipo Documento", 0);
         cmbavDynamicfiltersselector2.addItem("NUMDOC", "N° Documento", 0);
         cmbavDynamicfiltersselector2.addItem("CORSERIE", "Serie", 0);
         if ( cmbavDynamicfiltersselector2.ItemCount > 0 )
         {
            AV21DynamicFiltersSelector2 = cmbavDynamicfiltersselector2.getValidValue(AV21DynamicFiltersSelector2);
            AssignAttri("", false, "AV21DynamicFiltersSelector2", AV21DynamicFiltersSelector2);
         }
         cmbavDynamicfiltersoperator2.Name = "vDYNAMICFILTERSOPERATOR2";
         cmbavDynamicfiltersoperator2.WebTags = "";
         cmbavDynamicfiltersoperator2.addItem("0", "Comienza con", 0);
         cmbavDynamicfiltersoperator2.addItem("1", "Contiene", 0);
         if ( cmbavDynamicfiltersoperator2.ItemCount > 0 )
         {
            AV22DynamicFiltersOperator2 = (short)(NumberUtil.Val( cmbavDynamicfiltersoperator2.getValidValue(StringUtil.Trim( StringUtil.Str( (decimal)(AV22DynamicFiltersOperator2), 4, 0))), "."));
            AssignAttri("", false, "AV22DynamicFiltersOperator2", StringUtil.LTrimStr( (decimal)(AV22DynamicFiltersOperator2), 4, 0));
         }
         cmbavCordoc2.Name = "vCORDOC2";
         cmbavCordoc2.WebTags = "";
         cmbavCordoc2.addItem("", "(Ninguno)", 0);
         cmbavCordoc2.addItem("FACTURA", "FACTURA", 0);
         cmbavCordoc2.addItem("NOTCREDITO", "NOTA DE CREDITO", 0);
         cmbavCordoc2.addItem("NOTDEBITO", "NOTA DE DEBITO", 0);
         cmbavCordoc2.addItem("BOLETA", "BOLETA", 0);
         cmbavCordoc2.addItem("REMISION", "REMISION", 0);
         cmbavCordoc2.addItem("LETRA", "LETRA DE CAMBIO", 0);
         cmbavCordoc2.addItem("PERCEPCION", "PERCEPCION", 0);
         cmbavCordoc2.addItem("RECIBO", "RECIBO", 0);
         cmbavCordoc2.addItem("ENTRADA", "ENTRADA", 0);
         cmbavCordoc2.addItem("SALIDA", "SALIDA", 0);
         cmbavCordoc2.addItem("ORDENCOMPR", "ORDEN DE COMPRA", 0);
         cmbavCordoc2.addItem("RETENCION", "RETENCION", 0);
         cmbavCordoc2.addItem("TICKET", "TICKET", 0);
         if ( cmbavCordoc2.ItemCount > 0 )
         {
            AV23CorDoc2 = cmbavCordoc2.getValidValue(AV23CorDoc2);
            AssignAttri("", false, "AV23CorDoc2", AV23CorDoc2);
         }
         cmbavDynamicfiltersselector3.Name = "vDYNAMICFILTERSSELECTOR3";
         cmbavDynamicfiltersselector3.WebTags = "";
         cmbavDynamicfiltersselector3.addItem("CORDOC", "Tipo Documento", 0);
         cmbavDynamicfiltersselector3.addItem("NUMDOC", "N° Documento", 0);
         cmbavDynamicfiltersselector3.addItem("CORSERIE", "Serie", 0);
         if ( cmbavDynamicfiltersselector3.ItemCount > 0 )
         {
            AV27DynamicFiltersSelector3 = cmbavDynamicfiltersselector3.getValidValue(AV27DynamicFiltersSelector3);
            AssignAttri("", false, "AV27DynamicFiltersSelector3", AV27DynamicFiltersSelector3);
         }
         cmbavDynamicfiltersoperator3.Name = "vDYNAMICFILTERSOPERATOR3";
         cmbavDynamicfiltersoperator3.WebTags = "";
         cmbavDynamicfiltersoperator3.addItem("0", "Comienza con", 0);
         cmbavDynamicfiltersoperator3.addItem("1", "Contiene", 0);
         if ( cmbavDynamicfiltersoperator3.ItemCount > 0 )
         {
            AV28DynamicFiltersOperator3 = (short)(NumberUtil.Val( cmbavDynamicfiltersoperator3.getValidValue(StringUtil.Trim( StringUtil.Str( (decimal)(AV28DynamicFiltersOperator3), 4, 0))), "."));
            AssignAttri("", false, "AV28DynamicFiltersOperator3", StringUtil.LTrimStr( (decimal)(AV28DynamicFiltersOperator3), 4, 0));
         }
         cmbavCordoc3.Name = "vCORDOC3";
         cmbavCordoc3.WebTags = "";
         cmbavCordoc3.addItem("", "(Ninguno)", 0);
         cmbavCordoc3.addItem("FACTURA", "FACTURA", 0);
         cmbavCordoc3.addItem("NOTCREDITO", "NOTA DE CREDITO", 0);
         cmbavCordoc3.addItem("NOTDEBITO", "NOTA DE DEBITO", 0);
         cmbavCordoc3.addItem("BOLETA", "BOLETA", 0);
         cmbavCordoc3.addItem("REMISION", "REMISION", 0);
         cmbavCordoc3.addItem("LETRA", "LETRA DE CAMBIO", 0);
         cmbavCordoc3.addItem("PERCEPCION", "PERCEPCION", 0);
         cmbavCordoc3.addItem("RECIBO", "RECIBO", 0);
         cmbavCordoc3.addItem("ENTRADA", "ENTRADA", 0);
         cmbavCordoc3.addItem("SALIDA", "SALIDA", 0);
         cmbavCordoc3.addItem("ORDENCOMPR", "ORDEN DE COMPRA", 0);
         cmbavCordoc3.addItem("RETENCION", "RETENCION", 0);
         cmbavCordoc3.addItem("TICKET", "TICKET", 0);
         if ( cmbavCordoc3.ItemCount > 0 )
         {
            AV29CorDoc3 = cmbavCordoc3.getValidValue(AV29CorDoc3);
            AssignAttri("", false, "AV29CorDoc3", AV29CorDoc3);
         }
         GXCCtl = "vGRIDACTIONS_" + sGXsfl_119_idx;
         cmbavGridactions.Name = GXCCtl;
         cmbavGridactions.WebTags = "";
         if ( cmbavGridactions.ItemCount > 0 )
         {
            AV51GridActions = (short)(NumberUtil.Val( cmbavGridactions.getValidValue(StringUtil.Trim( StringUtil.Str( (decimal)(AV51GridActions), 4, 0))), "."));
            AssignAttri("", false, cmbavGridactions_Internalname, StringUtil.LTrimStr( (decimal)(AV51GridActions), 4, 0));
         }
         GXCCtl = "CORFE_" + sGXsfl_119_idx;
         chkCorFE.Name = GXCCtl;
         chkCorFE.WebTags = "";
         chkCorFE.Caption = "";
         AssignProp("", false, chkCorFE_Internalname, "TitleCaption", chkCorFE.Caption, !bGXsfl_119_Refreshing);
         chkCorFE.CheckedValue = "0";
         A756CorFE = (short)(((StringUtil.StrCmp(StringUtil.LTrim( StringUtil.NToC( (decimal)(A756CorFE), 1, 0, ".", "")), "1")==0) ? 1 : 0));
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
         cmbavCordoc1_Internalname = "vCORDOC1";
         cellFilter_cordoc1_cell_Internalname = "FILTER_CORDOC1_CELL";
         edtavNumdoc1_Internalname = "vNUMDOC1";
         cellFilter_numdoc1_cell_Internalname = "FILTER_NUMDOC1_CELL";
         edtavCorserie1_Internalname = "vCORSERIE1";
         cellFilter_corserie1_cell_Internalname = "FILTER_CORSERIE1_CELL";
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
         cmbavCordoc2_Internalname = "vCORDOC2";
         cellFilter_cordoc2_cell_Internalname = "FILTER_CORDOC2_CELL";
         edtavNumdoc2_Internalname = "vNUMDOC2";
         cellFilter_numdoc2_cell_Internalname = "FILTER_NUMDOC2_CELL";
         edtavCorserie2_Internalname = "vCORSERIE2";
         cellFilter_corserie2_cell_Internalname = "FILTER_CORSERIE2_CELL";
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
         cmbavCordoc3_Internalname = "vCORDOC3";
         cellFilter_cordoc3_cell_Internalname = "FILTER_CORDOC3_CELL";
         edtavNumdoc3_Internalname = "vNUMDOC3";
         cellFilter_numdoc3_cell_Internalname = "FILTER_NUMDOC3_CELL";
         edtavCorserie3_Internalname = "vCORSERIE3";
         cellFilter_corserie3_cell_Internalname = "FILTER_CORSERIE3_CELL";
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
         edtCorDoc_Internalname = "CORDOC";
         edtNumDoc_Internalname = "NUMDOC";
         edtCorSerie_Internalname = "CORSERIE";
         chkCorFE_Internalname = "CORFE";
         edtCorFormato_Internalname = "CORFORMATO";
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
         edtCorFormato_Jsonclick = "";
         chkCorFE.Caption = "";
         edtCorSerie_Jsonclick = "";
         edtNumDoc_Jsonclick = "";
         edtCorDoc_Jsonclick = "";
         cmbavGridactions_Jsonclick = "";
         cmbavGridactions.Visible = -1;
         cmbavGridactions.Enabled = 1;
         imgRemovedynamicfilters1_Visible = 1;
         imgAdddynamicfilters1_Visible = 1;
         edtavCorserie1_Jsonclick = "";
         edtavCorserie1_Enabled = 1;
         edtavNumdoc1_Jsonclick = "";
         edtavNumdoc1_Enabled = 1;
         cmbavCordoc1_Jsonclick = "";
         cmbavCordoc1.Enabled = 1;
         cmbavDynamicfiltersoperator1_Jsonclick = "";
         cmbavDynamicfiltersoperator1.Enabled = 1;
         imgRemovedynamicfilters2_Visible = 1;
         imgAdddynamicfilters2_Visible = 1;
         edtavCorserie2_Jsonclick = "";
         edtavCorserie2_Enabled = 1;
         edtavNumdoc2_Jsonclick = "";
         edtavNumdoc2_Enabled = 1;
         cmbavCordoc2_Jsonclick = "";
         cmbavCordoc2.Enabled = 1;
         cmbavDynamicfiltersoperator2_Jsonclick = "";
         cmbavDynamicfiltersoperator2.Enabled = 1;
         edtavCorserie3_Jsonclick = "";
         edtavCorserie3_Enabled = 1;
         edtavNumdoc3_Jsonclick = "";
         edtavNumdoc3_Enabled = 1;
         cmbavCordoc3_Jsonclick = "";
         cmbavCordoc3.Enabled = 1;
         cmbavDynamicfiltersoperator3_Jsonclick = "";
         cmbavDynamicfiltersoperator3.Enabled = 1;
         cmbavDynamicfiltersselector3_Jsonclick = "";
         cmbavDynamicfiltersselector3.Enabled = 1;
         cmbavDynamicfiltersselector2_Jsonclick = "";
         cmbavDynamicfiltersselector2.Enabled = 1;
         cmbavDynamicfiltersselector1_Jsonclick = "";
         cmbavDynamicfiltersselector1.Enabled = 1;
         cmbavDynamicfiltersoperator3.Visible = 1;
         edtavCorserie3_Visible = 1;
         edtavNumdoc3_Visible = 1;
         cmbavCordoc3.Visible = 1;
         cmbavDynamicfiltersoperator2.Visible = 1;
         edtavCorserie2_Visible = 1;
         edtavNumdoc2_Visible = 1;
         cmbavCordoc2.Visible = 1;
         cmbavDynamicfiltersoperator1.Visible = 1;
         edtavCorserie1_Visible = 1;
         edtavNumdoc1_Visible = 1;
         cmbavCordoc1.Visible = 1;
         lblJsdynamicfilters_Caption = "JSDynamicFilters";
         subGrid_Allowcollapsing = 0;
         subGrid_Allowselection = 0;
         edtNumDoc_Link = "";
         subGrid_Sortable = 0;
         subGrid_Header = "";
         subGrid_Class = "GridWithPaginationBar WorkWith";
         subGrid_Backcolorstyle = 0;
         Grid_empowerer_Hastitlesettings = Convert.ToBoolean( -1);
         Innewwindow1_Target = "";
         Innewwindow1_Height = "50";
         Innewwindow1_Width = "50";
         Ddo_grid_Datalistproc = "Seguridad.NumeracionDocumentosWWGetFilterData";
         Ddo_grid_Datalistfixedvalues = "|||1:WWP_TSChecked,2:WWP_TSUnChecked|";
         Ddo_grid_Datalisttype = "Dynamic||Dynamic|FixedValues|Dynamic";
         Ddo_grid_Includedatalist = "T||T|T|T";
         Ddo_grid_Filterisrange = "|T|||";
         Ddo_grid_Filtertype = "Character|Numeric|Character||Character";
         Ddo_grid_Includefilter = "T|T|T||T";
         Ddo_grid_Includesortasc = "T";
         Ddo_grid_Columnssortvalues = "2|3|4|5|6";
         Ddo_grid_Columnids = "1:CorDoc|2:NumDoc|3:CorSerie|4:CorFE|5:CorFormato";
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
         Form.Caption = " Numeracion Documentos";
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
         setEventMetadata("REFRESH","{handler:'Refresh',iparms:[{av:'GRID_nFirstRecordOnPage'},{av:'GRID_nEOF'},{av:'cmbavDynamicfiltersselector1'},{av:'AV15DynamicFiltersSelector1',fld:'vDYNAMICFILTERSSELECTOR1',pic:''},{av:'AV20DynamicFiltersEnabled2',fld:'vDYNAMICFILTERSENABLED2',pic:''},{av:'cmbavDynamicfiltersselector2'},{av:'AV21DynamicFiltersSelector2',fld:'vDYNAMICFILTERSSELECTOR2',pic:''},{av:'AV26DynamicFiltersEnabled3',fld:'vDYNAMICFILTERSENABLED3',pic:''},{av:'cmbavDynamicfiltersselector3'},{av:'AV27DynamicFiltersSelector3',fld:'vDYNAMICFILTERSSELECTOR3',pic:''},{av:'subGrid_Rows',ctrl:'GRID',prop:'Rows'},{av:'cmbavDynamicfiltersoperator1'},{av:'AV16DynamicFiltersOperator1',fld:'vDYNAMICFILTERSOPERATOR1',pic:'ZZZ9'},{av:'cmbavCordoc1'},{av:'AV17CorDoc1',fld:'vCORDOC1',pic:''},{av:'AV18NumDoc1',fld:'vNUMDOC1',pic:'ZZZZZZZZZ9'},{av:'AV19CorSerie1',fld:'vCORSERIE1',pic:''},{av:'cmbavDynamicfiltersoperator2'},{av:'AV22DynamicFiltersOperator2',fld:'vDYNAMICFILTERSOPERATOR2',pic:'ZZZ9'},{av:'cmbavCordoc2'},{av:'AV23CorDoc2',fld:'vCORDOC2',pic:''},{av:'AV24NumDoc2',fld:'vNUMDOC2',pic:'ZZZZZZZZZ9'},{av:'AV25CorSerie2',fld:'vCORSERIE2',pic:''},{av:'cmbavDynamicfiltersoperator3'},{av:'AV28DynamicFiltersOperator3',fld:'vDYNAMICFILTERSOPERATOR3',pic:'ZZZ9'},{av:'cmbavCordoc3'},{av:'AV29CorDoc3',fld:'vCORDOC3',pic:''},{av:'AV30NumDoc3',fld:'vNUMDOC3',pic:'ZZZZZZZZZ9'},{av:'AV31CorSerie3',fld:'vCORSERIE3',pic:''},{av:'AV56Pgmname',fld:'vPGMNAME',pic:'',hsh:true},{av:'AV37TFCorDoc',fld:'vTFCORDOC',pic:''},{av:'AV38TFCorDoc_Sel',fld:'vTFCORDOC_SEL',pic:''},{av:'AV39TFNumDoc',fld:'vTFNUMDOC',pic:'ZZZZZZZZZ9'},{av:'AV40TFNumDoc_To',fld:'vTFNUMDOC_TO',pic:'ZZZZZZZZZ9'},{av:'AV41TFCorSerie',fld:'vTFCORSERIE',pic:''},{av:'AV42TFCorSerie_Sel',fld:'vTFCORSERIE_SEL',pic:''},{av:'AV43TFCorFE_Sel',fld:'vTFCORFE_SEL',pic:'9'},{av:'AV44TFCorFormato',fld:'vTFCORFORMATO',pic:''},{av:'AV45TFCorFormato_Sel',fld:'vTFCORFORMATO_SEL',pic:''},{av:'AV13OrderedBy',fld:'vORDEREDBY',pic:'ZZZ9'},{av:'AV14OrderedDsc',fld:'vORDEREDDSC',pic:''},{av:'AV10GridState',fld:'vGRIDSTATE',pic:''},{av:'AV33DynamicFiltersIgnoreFirst',fld:'vDYNAMICFILTERSIGNOREFIRST',pic:''},{av:'AV32DynamicFiltersRemoving',fld:'vDYNAMICFILTERSREMOVING',pic:''}]");
         setEventMetadata("REFRESH",",oparms:[{av:'cmbavDynamicfiltersoperator1'},{av:'AV16DynamicFiltersOperator1',fld:'vDYNAMICFILTERSOPERATOR1',pic:'ZZZ9'},{av:'cmbavDynamicfiltersoperator2'},{av:'AV22DynamicFiltersOperator2',fld:'vDYNAMICFILTERSOPERATOR2',pic:'ZZZ9'},{av:'cmbavDynamicfiltersoperator3'},{av:'AV28DynamicFiltersOperator3',fld:'vDYNAMICFILTERSOPERATOR3',pic:'ZZZ9'},{av:'AV48GridCurrentPage',fld:'vGRIDCURRENTPAGE',pic:'ZZZZZZZZZ9'},{av:'AV49GridPageCount',fld:'vGRIDPAGECOUNT',pic:'ZZZZZZZZZ9'},{av:'AV50GridAppliedFilters',fld:'vGRIDAPPLIEDFILTERS',pic:''},{av:'AV10GridState',fld:'vGRIDSTATE',pic:''}]}");
         setEventMetadata("GRIDPAGINATIONBAR.CHANGEPAGE","{handler:'E110F2',iparms:[{av:'GRID_nFirstRecordOnPage'},{av:'GRID_nEOF'},{av:'subGrid_Rows',ctrl:'GRID',prop:'Rows'},{av:'cmbavDynamicfiltersselector1'},{av:'AV15DynamicFiltersSelector1',fld:'vDYNAMICFILTERSSELECTOR1',pic:''},{av:'cmbavDynamicfiltersoperator1'},{av:'AV16DynamicFiltersOperator1',fld:'vDYNAMICFILTERSOPERATOR1',pic:'ZZZ9'},{av:'cmbavCordoc1'},{av:'AV17CorDoc1',fld:'vCORDOC1',pic:''},{av:'AV18NumDoc1',fld:'vNUMDOC1',pic:'ZZZZZZZZZ9'},{av:'AV19CorSerie1',fld:'vCORSERIE1',pic:''},{av:'cmbavDynamicfiltersselector2'},{av:'AV21DynamicFiltersSelector2',fld:'vDYNAMICFILTERSSELECTOR2',pic:''},{av:'cmbavDynamicfiltersoperator2'},{av:'AV22DynamicFiltersOperator2',fld:'vDYNAMICFILTERSOPERATOR2',pic:'ZZZ9'},{av:'cmbavCordoc2'},{av:'AV23CorDoc2',fld:'vCORDOC2',pic:''},{av:'AV24NumDoc2',fld:'vNUMDOC2',pic:'ZZZZZZZZZ9'},{av:'AV25CorSerie2',fld:'vCORSERIE2',pic:''},{av:'cmbavDynamicfiltersselector3'},{av:'AV27DynamicFiltersSelector3',fld:'vDYNAMICFILTERSSELECTOR3',pic:''},{av:'cmbavDynamicfiltersoperator3'},{av:'AV28DynamicFiltersOperator3',fld:'vDYNAMICFILTERSOPERATOR3',pic:'ZZZ9'},{av:'cmbavCordoc3'},{av:'AV29CorDoc3',fld:'vCORDOC3',pic:''},{av:'AV30NumDoc3',fld:'vNUMDOC3',pic:'ZZZZZZZZZ9'},{av:'AV31CorSerie3',fld:'vCORSERIE3',pic:''},{av:'AV20DynamicFiltersEnabled2',fld:'vDYNAMICFILTERSENABLED2',pic:''},{av:'AV26DynamicFiltersEnabled3',fld:'vDYNAMICFILTERSENABLED3',pic:''},{av:'AV56Pgmname',fld:'vPGMNAME',pic:'',hsh:true},{av:'AV37TFCorDoc',fld:'vTFCORDOC',pic:''},{av:'AV38TFCorDoc_Sel',fld:'vTFCORDOC_SEL',pic:''},{av:'AV39TFNumDoc',fld:'vTFNUMDOC',pic:'ZZZZZZZZZ9'},{av:'AV40TFNumDoc_To',fld:'vTFNUMDOC_TO',pic:'ZZZZZZZZZ9'},{av:'AV41TFCorSerie',fld:'vTFCORSERIE',pic:''},{av:'AV42TFCorSerie_Sel',fld:'vTFCORSERIE_SEL',pic:''},{av:'AV43TFCorFE_Sel',fld:'vTFCORFE_SEL',pic:'9'},{av:'AV44TFCorFormato',fld:'vTFCORFORMATO',pic:''},{av:'AV45TFCorFormato_Sel',fld:'vTFCORFORMATO_SEL',pic:''},{av:'AV13OrderedBy',fld:'vORDEREDBY',pic:'ZZZ9'},{av:'AV14OrderedDsc',fld:'vORDEREDDSC',pic:''},{av:'AV10GridState',fld:'vGRIDSTATE',pic:''},{av:'AV33DynamicFiltersIgnoreFirst',fld:'vDYNAMICFILTERSIGNOREFIRST',pic:''},{av:'AV32DynamicFiltersRemoving',fld:'vDYNAMICFILTERSREMOVING',pic:''},{av:'Gridpaginationbar_Selectedpage',ctrl:'GRIDPAGINATIONBAR',prop:'SelectedPage'}]");
         setEventMetadata("GRIDPAGINATIONBAR.CHANGEPAGE",",oparms:[]}");
         setEventMetadata("GRIDPAGINATIONBAR.CHANGEROWSPERPAGE","{handler:'E120F2',iparms:[{av:'GRID_nFirstRecordOnPage'},{av:'GRID_nEOF'},{av:'subGrid_Rows',ctrl:'GRID',prop:'Rows'},{av:'cmbavDynamicfiltersselector1'},{av:'AV15DynamicFiltersSelector1',fld:'vDYNAMICFILTERSSELECTOR1',pic:''},{av:'cmbavDynamicfiltersoperator1'},{av:'AV16DynamicFiltersOperator1',fld:'vDYNAMICFILTERSOPERATOR1',pic:'ZZZ9'},{av:'cmbavCordoc1'},{av:'AV17CorDoc1',fld:'vCORDOC1',pic:''},{av:'AV18NumDoc1',fld:'vNUMDOC1',pic:'ZZZZZZZZZ9'},{av:'AV19CorSerie1',fld:'vCORSERIE1',pic:''},{av:'cmbavDynamicfiltersselector2'},{av:'AV21DynamicFiltersSelector2',fld:'vDYNAMICFILTERSSELECTOR2',pic:''},{av:'cmbavDynamicfiltersoperator2'},{av:'AV22DynamicFiltersOperator2',fld:'vDYNAMICFILTERSOPERATOR2',pic:'ZZZ9'},{av:'cmbavCordoc2'},{av:'AV23CorDoc2',fld:'vCORDOC2',pic:''},{av:'AV24NumDoc2',fld:'vNUMDOC2',pic:'ZZZZZZZZZ9'},{av:'AV25CorSerie2',fld:'vCORSERIE2',pic:''},{av:'cmbavDynamicfiltersselector3'},{av:'AV27DynamicFiltersSelector3',fld:'vDYNAMICFILTERSSELECTOR3',pic:''},{av:'cmbavDynamicfiltersoperator3'},{av:'AV28DynamicFiltersOperator3',fld:'vDYNAMICFILTERSOPERATOR3',pic:'ZZZ9'},{av:'cmbavCordoc3'},{av:'AV29CorDoc3',fld:'vCORDOC3',pic:''},{av:'AV30NumDoc3',fld:'vNUMDOC3',pic:'ZZZZZZZZZ9'},{av:'AV31CorSerie3',fld:'vCORSERIE3',pic:''},{av:'AV20DynamicFiltersEnabled2',fld:'vDYNAMICFILTERSENABLED2',pic:''},{av:'AV26DynamicFiltersEnabled3',fld:'vDYNAMICFILTERSENABLED3',pic:''},{av:'AV56Pgmname',fld:'vPGMNAME',pic:'',hsh:true},{av:'AV37TFCorDoc',fld:'vTFCORDOC',pic:''},{av:'AV38TFCorDoc_Sel',fld:'vTFCORDOC_SEL',pic:''},{av:'AV39TFNumDoc',fld:'vTFNUMDOC',pic:'ZZZZZZZZZ9'},{av:'AV40TFNumDoc_To',fld:'vTFNUMDOC_TO',pic:'ZZZZZZZZZ9'},{av:'AV41TFCorSerie',fld:'vTFCORSERIE',pic:''},{av:'AV42TFCorSerie_Sel',fld:'vTFCORSERIE_SEL',pic:''},{av:'AV43TFCorFE_Sel',fld:'vTFCORFE_SEL',pic:'9'},{av:'AV44TFCorFormato',fld:'vTFCORFORMATO',pic:''},{av:'AV45TFCorFormato_Sel',fld:'vTFCORFORMATO_SEL',pic:''},{av:'AV13OrderedBy',fld:'vORDEREDBY',pic:'ZZZ9'},{av:'AV14OrderedDsc',fld:'vORDEREDDSC',pic:''},{av:'AV10GridState',fld:'vGRIDSTATE',pic:''},{av:'AV33DynamicFiltersIgnoreFirst',fld:'vDYNAMICFILTERSIGNOREFIRST',pic:''},{av:'AV32DynamicFiltersRemoving',fld:'vDYNAMICFILTERSREMOVING',pic:''},{av:'Gridpaginationbar_Rowsperpageselectedvalue',ctrl:'GRIDPAGINATIONBAR',prop:'RowsPerPageSelectedValue'}]");
         setEventMetadata("GRIDPAGINATIONBAR.CHANGEROWSPERPAGE",",oparms:[{av:'subGrid_Rows',ctrl:'GRID',prop:'Rows'}]}");
         setEventMetadata("DDO_GRID.ONOPTIONCLICKED","{handler:'E140F2',iparms:[{av:'GRID_nFirstRecordOnPage'},{av:'GRID_nEOF'},{av:'subGrid_Rows',ctrl:'GRID',prop:'Rows'},{av:'cmbavDynamicfiltersselector1'},{av:'AV15DynamicFiltersSelector1',fld:'vDYNAMICFILTERSSELECTOR1',pic:''},{av:'cmbavDynamicfiltersoperator1'},{av:'AV16DynamicFiltersOperator1',fld:'vDYNAMICFILTERSOPERATOR1',pic:'ZZZ9'},{av:'cmbavCordoc1'},{av:'AV17CorDoc1',fld:'vCORDOC1',pic:''},{av:'AV18NumDoc1',fld:'vNUMDOC1',pic:'ZZZZZZZZZ9'},{av:'AV19CorSerie1',fld:'vCORSERIE1',pic:''},{av:'cmbavDynamicfiltersselector2'},{av:'AV21DynamicFiltersSelector2',fld:'vDYNAMICFILTERSSELECTOR2',pic:''},{av:'cmbavDynamicfiltersoperator2'},{av:'AV22DynamicFiltersOperator2',fld:'vDYNAMICFILTERSOPERATOR2',pic:'ZZZ9'},{av:'cmbavCordoc2'},{av:'AV23CorDoc2',fld:'vCORDOC2',pic:''},{av:'AV24NumDoc2',fld:'vNUMDOC2',pic:'ZZZZZZZZZ9'},{av:'AV25CorSerie2',fld:'vCORSERIE2',pic:''},{av:'cmbavDynamicfiltersselector3'},{av:'AV27DynamicFiltersSelector3',fld:'vDYNAMICFILTERSSELECTOR3',pic:''},{av:'cmbavDynamicfiltersoperator3'},{av:'AV28DynamicFiltersOperator3',fld:'vDYNAMICFILTERSOPERATOR3',pic:'ZZZ9'},{av:'cmbavCordoc3'},{av:'AV29CorDoc3',fld:'vCORDOC3',pic:''},{av:'AV30NumDoc3',fld:'vNUMDOC3',pic:'ZZZZZZZZZ9'},{av:'AV31CorSerie3',fld:'vCORSERIE3',pic:''},{av:'AV20DynamicFiltersEnabled2',fld:'vDYNAMICFILTERSENABLED2',pic:''},{av:'AV26DynamicFiltersEnabled3',fld:'vDYNAMICFILTERSENABLED3',pic:''},{av:'AV56Pgmname',fld:'vPGMNAME',pic:'',hsh:true},{av:'AV37TFCorDoc',fld:'vTFCORDOC',pic:''},{av:'AV38TFCorDoc_Sel',fld:'vTFCORDOC_SEL',pic:''},{av:'AV39TFNumDoc',fld:'vTFNUMDOC',pic:'ZZZZZZZZZ9'},{av:'AV40TFNumDoc_To',fld:'vTFNUMDOC_TO',pic:'ZZZZZZZZZ9'},{av:'AV41TFCorSerie',fld:'vTFCORSERIE',pic:''},{av:'AV42TFCorSerie_Sel',fld:'vTFCORSERIE_SEL',pic:''},{av:'AV43TFCorFE_Sel',fld:'vTFCORFE_SEL',pic:'9'},{av:'AV44TFCorFormato',fld:'vTFCORFORMATO',pic:''},{av:'AV45TFCorFormato_Sel',fld:'vTFCORFORMATO_SEL',pic:''},{av:'AV13OrderedBy',fld:'vORDEREDBY',pic:'ZZZ9'},{av:'AV14OrderedDsc',fld:'vORDEREDDSC',pic:''},{av:'AV10GridState',fld:'vGRIDSTATE',pic:''},{av:'AV33DynamicFiltersIgnoreFirst',fld:'vDYNAMICFILTERSIGNOREFIRST',pic:''},{av:'AV32DynamicFiltersRemoving',fld:'vDYNAMICFILTERSREMOVING',pic:''},{av:'Ddo_grid_Activeeventkey',ctrl:'DDO_GRID',prop:'ActiveEventKey'},{av:'Ddo_grid_Selectedvalue_get',ctrl:'DDO_GRID',prop:'SelectedValue_get'},{av:'Ddo_grid_Selectedcolumn',ctrl:'DDO_GRID',prop:'SelectedColumn'},{av:'Ddo_grid_Filteredtext_get',ctrl:'DDO_GRID',prop:'FilteredText_get'},{av:'Ddo_grid_Filteredtextto_get',ctrl:'DDO_GRID',prop:'FilteredTextTo_get'}]");
         setEventMetadata("DDO_GRID.ONOPTIONCLICKED",",oparms:[{av:'AV13OrderedBy',fld:'vORDEREDBY',pic:'ZZZ9'},{av:'AV14OrderedDsc',fld:'vORDEREDDSC',pic:''},{av:'AV37TFCorDoc',fld:'vTFCORDOC',pic:''},{av:'AV38TFCorDoc_Sel',fld:'vTFCORDOC_SEL',pic:''},{av:'AV39TFNumDoc',fld:'vTFNUMDOC',pic:'ZZZZZZZZZ9'},{av:'AV40TFNumDoc_To',fld:'vTFNUMDOC_TO',pic:'ZZZZZZZZZ9'},{av:'AV41TFCorSerie',fld:'vTFCORSERIE',pic:''},{av:'AV42TFCorSerie_Sel',fld:'vTFCORSERIE_SEL',pic:''},{av:'AV43TFCorFE_Sel',fld:'vTFCORFE_SEL',pic:'9'},{av:'AV44TFCorFormato',fld:'vTFCORFORMATO',pic:''},{av:'AV45TFCorFormato_Sel',fld:'vTFCORFORMATO_SEL',pic:''},{av:'Ddo_grid_Sortedstatus',ctrl:'DDO_GRID',prop:'SortedStatus'}]}");
         setEventMetadata("GRID.LOAD","{handler:'E260F2',iparms:[{av:'A339CorDoc',fld:'CORDOC',pic:'',hsh:true},{av:'A340CorSerie',fld:'CORSERIE',pic:'',hsh:true}]");
         setEventMetadata("GRID.LOAD",",oparms:[{av:'cmbavGridactions'},{av:'AV51GridActions',fld:'vGRIDACTIONS',pic:'ZZZ9'},{av:'edtNumDoc_Link',ctrl:'NUMDOC',prop:'Link'}]}");
         setEventMetadata("'ADDDYNAMICFILTERS1'","{handler:'E190F2',iparms:[]");
         setEventMetadata("'ADDDYNAMICFILTERS1'",",oparms:[{av:'AV20DynamicFiltersEnabled2',fld:'vDYNAMICFILTERSENABLED2',pic:''},{av:'imgAdddynamicfilters1_Visible',ctrl:'ADDDYNAMICFILTERS1',prop:'Visible'},{av:'imgRemovedynamicfilters1_Visible',ctrl:'REMOVEDYNAMICFILTERS1',prop:'Visible'}]}");
         setEventMetadata("'REMOVEDYNAMICFILTERS1'","{handler:'E150F2',iparms:[{av:'GRID_nFirstRecordOnPage'},{av:'GRID_nEOF'},{av:'subGrid_Rows',ctrl:'GRID',prop:'Rows'},{av:'cmbavDynamicfiltersselector1'},{av:'AV15DynamicFiltersSelector1',fld:'vDYNAMICFILTERSSELECTOR1',pic:''},{av:'cmbavDynamicfiltersoperator1'},{av:'AV16DynamicFiltersOperator1',fld:'vDYNAMICFILTERSOPERATOR1',pic:'ZZZ9'},{av:'cmbavCordoc1'},{av:'AV17CorDoc1',fld:'vCORDOC1',pic:''},{av:'AV18NumDoc1',fld:'vNUMDOC1',pic:'ZZZZZZZZZ9'},{av:'AV19CorSerie1',fld:'vCORSERIE1',pic:''},{av:'cmbavDynamicfiltersselector2'},{av:'AV21DynamicFiltersSelector2',fld:'vDYNAMICFILTERSSELECTOR2',pic:''},{av:'cmbavDynamicfiltersoperator2'},{av:'AV22DynamicFiltersOperator2',fld:'vDYNAMICFILTERSOPERATOR2',pic:'ZZZ9'},{av:'cmbavCordoc2'},{av:'AV23CorDoc2',fld:'vCORDOC2',pic:''},{av:'AV24NumDoc2',fld:'vNUMDOC2',pic:'ZZZZZZZZZ9'},{av:'AV25CorSerie2',fld:'vCORSERIE2',pic:''},{av:'cmbavDynamicfiltersselector3'},{av:'AV27DynamicFiltersSelector3',fld:'vDYNAMICFILTERSSELECTOR3',pic:''},{av:'cmbavDynamicfiltersoperator3'},{av:'AV28DynamicFiltersOperator3',fld:'vDYNAMICFILTERSOPERATOR3',pic:'ZZZ9'},{av:'cmbavCordoc3'},{av:'AV29CorDoc3',fld:'vCORDOC3',pic:''},{av:'AV30NumDoc3',fld:'vNUMDOC3',pic:'ZZZZZZZZZ9'},{av:'AV31CorSerie3',fld:'vCORSERIE3',pic:''},{av:'AV20DynamicFiltersEnabled2',fld:'vDYNAMICFILTERSENABLED2',pic:''},{av:'AV26DynamicFiltersEnabled3',fld:'vDYNAMICFILTERSENABLED3',pic:''},{av:'AV56Pgmname',fld:'vPGMNAME',pic:'',hsh:true},{av:'AV37TFCorDoc',fld:'vTFCORDOC',pic:''},{av:'AV38TFCorDoc_Sel',fld:'vTFCORDOC_SEL',pic:''},{av:'AV39TFNumDoc',fld:'vTFNUMDOC',pic:'ZZZZZZZZZ9'},{av:'AV40TFNumDoc_To',fld:'vTFNUMDOC_TO',pic:'ZZZZZZZZZ9'},{av:'AV41TFCorSerie',fld:'vTFCORSERIE',pic:''},{av:'AV42TFCorSerie_Sel',fld:'vTFCORSERIE_SEL',pic:''},{av:'AV43TFCorFE_Sel',fld:'vTFCORFE_SEL',pic:'9'},{av:'AV44TFCorFormato',fld:'vTFCORFORMATO',pic:''},{av:'AV45TFCorFormato_Sel',fld:'vTFCORFORMATO_SEL',pic:''},{av:'AV13OrderedBy',fld:'vORDEREDBY',pic:'ZZZ9'},{av:'AV14OrderedDsc',fld:'vORDEREDDSC',pic:''},{av:'AV10GridState',fld:'vGRIDSTATE',pic:''},{av:'AV33DynamicFiltersIgnoreFirst',fld:'vDYNAMICFILTERSIGNOREFIRST',pic:''},{av:'AV32DynamicFiltersRemoving',fld:'vDYNAMICFILTERSREMOVING',pic:''}]");
         setEventMetadata("'REMOVEDYNAMICFILTERS1'",",oparms:[{av:'AV32DynamicFiltersRemoving',fld:'vDYNAMICFILTERSREMOVING',pic:''},{av:'AV33DynamicFiltersIgnoreFirst',fld:'vDYNAMICFILTERSIGNOREFIRST',pic:''},{av:'AV10GridState',fld:'vGRIDSTATE',pic:''},{av:'AV20DynamicFiltersEnabled2',fld:'vDYNAMICFILTERSENABLED2',pic:''},{av:'cmbavDynamicfiltersselector2'},{av:'AV21DynamicFiltersSelector2',fld:'vDYNAMICFILTERSSELECTOR2',pic:''},{av:'cmbavCordoc2'},{av:'AV23CorDoc2',fld:'vCORDOC2',pic:''},{av:'AV26DynamicFiltersEnabled3',fld:'vDYNAMICFILTERSENABLED3',pic:''},{av:'cmbavDynamicfiltersselector3'},{av:'AV27DynamicFiltersSelector3',fld:'vDYNAMICFILTERSSELECTOR3',pic:''},{av:'cmbavCordoc3'},{av:'AV29CorDoc3',fld:'vCORDOC3',pic:''},{av:'imgAdddynamicfilters1_Visible',ctrl:'ADDDYNAMICFILTERS1',prop:'Visible'},{av:'imgRemovedynamicfilters1_Visible',ctrl:'REMOVEDYNAMICFILTERS1',prop:'Visible'},{av:'cmbavDynamicfiltersoperator1'},{av:'imgAdddynamicfilters2_Visible',ctrl:'ADDDYNAMICFILTERS2',prop:'Visible'},{av:'imgRemovedynamicfilters2_Visible',ctrl:'REMOVEDYNAMICFILTERS2',prop:'Visible'},{av:'cmbavDynamicfiltersoperator2'},{av:'cmbavDynamicfiltersoperator3'},{av:'cmbavDynamicfiltersselector1'},{av:'AV15DynamicFiltersSelector1',fld:'vDYNAMICFILTERSSELECTOR1',pic:''},{av:'cmbavCordoc1'},{av:'AV17CorDoc1',fld:'vCORDOC1',pic:''},{av:'AV16DynamicFiltersOperator1',fld:'vDYNAMICFILTERSOPERATOR1',pic:'ZZZ9'},{av:'AV18NumDoc1',fld:'vNUMDOC1',pic:'ZZZZZZZZZ9'},{av:'AV19CorSerie1',fld:'vCORSERIE1',pic:''},{av:'lblJsdynamicfilters_Caption',ctrl:'JSDYNAMICFILTERS',prop:'Caption'},{av:'AV22DynamicFiltersOperator2',fld:'vDYNAMICFILTERSOPERATOR2',pic:'ZZZ9'},{av:'AV24NumDoc2',fld:'vNUMDOC2',pic:'ZZZZZZZZZ9'},{av:'AV25CorSerie2',fld:'vCORSERIE2',pic:''},{av:'AV28DynamicFiltersOperator3',fld:'vDYNAMICFILTERSOPERATOR3',pic:'ZZZ9'},{av:'AV30NumDoc3',fld:'vNUMDOC3',pic:'ZZZZZZZZZ9'},{av:'AV31CorSerie3',fld:'vCORSERIE3',pic:''},{av:'edtavNumdoc2_Visible',ctrl:'vNUMDOC2',prop:'Visible'},{av:'edtavCorserie2_Visible',ctrl:'vCORSERIE2',prop:'Visible'},{av:'edtavNumdoc3_Visible',ctrl:'vNUMDOC3',prop:'Visible'},{av:'edtavCorserie3_Visible',ctrl:'vCORSERIE3',prop:'Visible'},{av:'edtavNumdoc1_Visible',ctrl:'vNUMDOC1',prop:'Visible'},{av:'edtavCorserie1_Visible',ctrl:'vCORSERIE1',prop:'Visible'},{av:'AV48GridCurrentPage',fld:'vGRIDCURRENTPAGE',pic:'ZZZZZZZZZ9'},{av:'AV49GridPageCount',fld:'vGRIDPAGECOUNT',pic:'ZZZZZZZZZ9'},{av:'AV50GridAppliedFilters',fld:'vGRIDAPPLIEDFILTERS',pic:''}]}");
         setEventMetadata("VDYNAMICFILTERSSELECTOR1.CLICK","{handler:'E200F2',iparms:[{av:'cmbavDynamicfiltersselector1'},{av:'AV15DynamicFiltersSelector1',fld:'vDYNAMICFILTERSSELECTOR1',pic:''}]");
         setEventMetadata("VDYNAMICFILTERSSELECTOR1.CLICK",",oparms:[{av:'cmbavDynamicfiltersoperator1'},{av:'AV16DynamicFiltersOperator1',fld:'vDYNAMICFILTERSOPERATOR1',pic:'ZZZ9'},{av:'cmbavCordoc1'},{av:'edtavNumdoc1_Visible',ctrl:'vNUMDOC1',prop:'Visible'},{av:'edtavCorserie1_Visible',ctrl:'vCORSERIE1',prop:'Visible'}]}");
         setEventMetadata("'ADDDYNAMICFILTERS2'","{handler:'E210F2',iparms:[]");
         setEventMetadata("'ADDDYNAMICFILTERS2'",",oparms:[{av:'AV26DynamicFiltersEnabled3',fld:'vDYNAMICFILTERSENABLED3',pic:''},{av:'imgAdddynamicfilters2_Visible',ctrl:'ADDDYNAMICFILTERS2',prop:'Visible'},{av:'imgRemovedynamicfilters2_Visible',ctrl:'REMOVEDYNAMICFILTERS2',prop:'Visible'}]}");
         setEventMetadata("'REMOVEDYNAMICFILTERS2'","{handler:'E160F2',iparms:[{av:'GRID_nFirstRecordOnPage'},{av:'GRID_nEOF'},{av:'subGrid_Rows',ctrl:'GRID',prop:'Rows'},{av:'cmbavDynamicfiltersselector1'},{av:'AV15DynamicFiltersSelector1',fld:'vDYNAMICFILTERSSELECTOR1',pic:''},{av:'cmbavDynamicfiltersoperator1'},{av:'AV16DynamicFiltersOperator1',fld:'vDYNAMICFILTERSOPERATOR1',pic:'ZZZ9'},{av:'cmbavCordoc1'},{av:'AV17CorDoc1',fld:'vCORDOC1',pic:''},{av:'AV18NumDoc1',fld:'vNUMDOC1',pic:'ZZZZZZZZZ9'},{av:'AV19CorSerie1',fld:'vCORSERIE1',pic:''},{av:'cmbavDynamicfiltersselector2'},{av:'AV21DynamicFiltersSelector2',fld:'vDYNAMICFILTERSSELECTOR2',pic:''},{av:'cmbavDynamicfiltersoperator2'},{av:'AV22DynamicFiltersOperator2',fld:'vDYNAMICFILTERSOPERATOR2',pic:'ZZZ9'},{av:'cmbavCordoc2'},{av:'AV23CorDoc2',fld:'vCORDOC2',pic:''},{av:'AV24NumDoc2',fld:'vNUMDOC2',pic:'ZZZZZZZZZ9'},{av:'AV25CorSerie2',fld:'vCORSERIE2',pic:''},{av:'cmbavDynamicfiltersselector3'},{av:'AV27DynamicFiltersSelector3',fld:'vDYNAMICFILTERSSELECTOR3',pic:''},{av:'cmbavDynamicfiltersoperator3'},{av:'AV28DynamicFiltersOperator3',fld:'vDYNAMICFILTERSOPERATOR3',pic:'ZZZ9'},{av:'cmbavCordoc3'},{av:'AV29CorDoc3',fld:'vCORDOC3',pic:''},{av:'AV30NumDoc3',fld:'vNUMDOC3',pic:'ZZZZZZZZZ9'},{av:'AV31CorSerie3',fld:'vCORSERIE3',pic:''},{av:'AV20DynamicFiltersEnabled2',fld:'vDYNAMICFILTERSENABLED2',pic:''},{av:'AV26DynamicFiltersEnabled3',fld:'vDYNAMICFILTERSENABLED3',pic:''},{av:'AV56Pgmname',fld:'vPGMNAME',pic:'',hsh:true},{av:'AV37TFCorDoc',fld:'vTFCORDOC',pic:''},{av:'AV38TFCorDoc_Sel',fld:'vTFCORDOC_SEL',pic:''},{av:'AV39TFNumDoc',fld:'vTFNUMDOC',pic:'ZZZZZZZZZ9'},{av:'AV40TFNumDoc_To',fld:'vTFNUMDOC_TO',pic:'ZZZZZZZZZ9'},{av:'AV41TFCorSerie',fld:'vTFCORSERIE',pic:''},{av:'AV42TFCorSerie_Sel',fld:'vTFCORSERIE_SEL',pic:''},{av:'AV43TFCorFE_Sel',fld:'vTFCORFE_SEL',pic:'9'},{av:'AV44TFCorFormato',fld:'vTFCORFORMATO',pic:''},{av:'AV45TFCorFormato_Sel',fld:'vTFCORFORMATO_SEL',pic:''},{av:'AV13OrderedBy',fld:'vORDEREDBY',pic:'ZZZ9'},{av:'AV14OrderedDsc',fld:'vORDEREDDSC',pic:''},{av:'AV10GridState',fld:'vGRIDSTATE',pic:''},{av:'AV33DynamicFiltersIgnoreFirst',fld:'vDYNAMICFILTERSIGNOREFIRST',pic:''},{av:'AV32DynamicFiltersRemoving',fld:'vDYNAMICFILTERSREMOVING',pic:''}]");
         setEventMetadata("'REMOVEDYNAMICFILTERS2'",",oparms:[{av:'AV32DynamicFiltersRemoving',fld:'vDYNAMICFILTERSREMOVING',pic:''},{av:'AV20DynamicFiltersEnabled2',fld:'vDYNAMICFILTERSENABLED2',pic:''},{av:'AV10GridState',fld:'vGRIDSTATE',pic:''},{av:'cmbavDynamicfiltersselector2'},{av:'AV21DynamicFiltersSelector2',fld:'vDYNAMICFILTERSSELECTOR2',pic:''},{av:'cmbavCordoc2'},{av:'AV23CorDoc2',fld:'vCORDOC2',pic:''},{av:'AV26DynamicFiltersEnabled3',fld:'vDYNAMICFILTERSENABLED3',pic:''},{av:'cmbavDynamicfiltersselector3'},{av:'AV27DynamicFiltersSelector3',fld:'vDYNAMICFILTERSSELECTOR3',pic:''},{av:'cmbavCordoc3'},{av:'AV29CorDoc3',fld:'vCORDOC3',pic:''},{av:'imgAdddynamicfilters1_Visible',ctrl:'ADDDYNAMICFILTERS1',prop:'Visible'},{av:'imgRemovedynamicfilters1_Visible',ctrl:'REMOVEDYNAMICFILTERS1',prop:'Visible'},{av:'cmbavDynamicfiltersoperator1'},{av:'imgAdddynamicfilters2_Visible',ctrl:'ADDDYNAMICFILTERS2',prop:'Visible'},{av:'imgRemovedynamicfilters2_Visible',ctrl:'REMOVEDYNAMICFILTERS2',prop:'Visible'},{av:'cmbavDynamicfiltersoperator2'},{av:'cmbavDynamicfiltersoperator3'},{av:'cmbavDynamicfiltersselector1'},{av:'AV15DynamicFiltersSelector1',fld:'vDYNAMICFILTERSSELECTOR1',pic:''},{av:'cmbavCordoc1'},{av:'AV17CorDoc1',fld:'vCORDOC1',pic:''},{av:'AV16DynamicFiltersOperator1',fld:'vDYNAMICFILTERSOPERATOR1',pic:'ZZZ9'},{av:'AV18NumDoc1',fld:'vNUMDOC1',pic:'ZZZZZZZZZ9'},{av:'AV19CorSerie1',fld:'vCORSERIE1',pic:''},{av:'lblJsdynamicfilters_Caption',ctrl:'JSDYNAMICFILTERS',prop:'Caption'},{av:'AV22DynamicFiltersOperator2',fld:'vDYNAMICFILTERSOPERATOR2',pic:'ZZZ9'},{av:'AV24NumDoc2',fld:'vNUMDOC2',pic:'ZZZZZZZZZ9'},{av:'AV25CorSerie2',fld:'vCORSERIE2',pic:''},{av:'AV28DynamicFiltersOperator3',fld:'vDYNAMICFILTERSOPERATOR3',pic:'ZZZ9'},{av:'AV30NumDoc3',fld:'vNUMDOC3',pic:'ZZZZZZZZZ9'},{av:'AV31CorSerie3',fld:'vCORSERIE3',pic:''},{av:'edtavNumdoc2_Visible',ctrl:'vNUMDOC2',prop:'Visible'},{av:'edtavCorserie2_Visible',ctrl:'vCORSERIE2',prop:'Visible'},{av:'edtavNumdoc3_Visible',ctrl:'vNUMDOC3',prop:'Visible'},{av:'edtavCorserie3_Visible',ctrl:'vCORSERIE3',prop:'Visible'},{av:'edtavNumdoc1_Visible',ctrl:'vNUMDOC1',prop:'Visible'},{av:'edtavCorserie1_Visible',ctrl:'vCORSERIE1',prop:'Visible'},{av:'AV48GridCurrentPage',fld:'vGRIDCURRENTPAGE',pic:'ZZZZZZZZZ9'},{av:'AV49GridPageCount',fld:'vGRIDPAGECOUNT',pic:'ZZZZZZZZZ9'},{av:'AV50GridAppliedFilters',fld:'vGRIDAPPLIEDFILTERS',pic:''}]}");
         setEventMetadata("VDYNAMICFILTERSSELECTOR2.CLICK","{handler:'E220F2',iparms:[{av:'cmbavDynamicfiltersselector2'},{av:'AV21DynamicFiltersSelector2',fld:'vDYNAMICFILTERSSELECTOR2',pic:''}]");
         setEventMetadata("VDYNAMICFILTERSSELECTOR2.CLICK",",oparms:[{av:'cmbavDynamicfiltersoperator2'},{av:'AV22DynamicFiltersOperator2',fld:'vDYNAMICFILTERSOPERATOR2',pic:'ZZZ9'},{av:'cmbavCordoc2'},{av:'edtavNumdoc2_Visible',ctrl:'vNUMDOC2',prop:'Visible'},{av:'edtavCorserie2_Visible',ctrl:'vCORSERIE2',prop:'Visible'}]}");
         setEventMetadata("'REMOVEDYNAMICFILTERS3'","{handler:'E170F2',iparms:[{av:'GRID_nFirstRecordOnPage'},{av:'GRID_nEOF'},{av:'subGrid_Rows',ctrl:'GRID',prop:'Rows'},{av:'cmbavDynamicfiltersselector1'},{av:'AV15DynamicFiltersSelector1',fld:'vDYNAMICFILTERSSELECTOR1',pic:''},{av:'cmbavDynamicfiltersoperator1'},{av:'AV16DynamicFiltersOperator1',fld:'vDYNAMICFILTERSOPERATOR1',pic:'ZZZ9'},{av:'cmbavCordoc1'},{av:'AV17CorDoc1',fld:'vCORDOC1',pic:''},{av:'AV18NumDoc1',fld:'vNUMDOC1',pic:'ZZZZZZZZZ9'},{av:'AV19CorSerie1',fld:'vCORSERIE1',pic:''},{av:'cmbavDynamicfiltersselector2'},{av:'AV21DynamicFiltersSelector2',fld:'vDYNAMICFILTERSSELECTOR2',pic:''},{av:'cmbavDynamicfiltersoperator2'},{av:'AV22DynamicFiltersOperator2',fld:'vDYNAMICFILTERSOPERATOR2',pic:'ZZZ9'},{av:'cmbavCordoc2'},{av:'AV23CorDoc2',fld:'vCORDOC2',pic:''},{av:'AV24NumDoc2',fld:'vNUMDOC2',pic:'ZZZZZZZZZ9'},{av:'AV25CorSerie2',fld:'vCORSERIE2',pic:''},{av:'cmbavDynamicfiltersselector3'},{av:'AV27DynamicFiltersSelector3',fld:'vDYNAMICFILTERSSELECTOR3',pic:''},{av:'cmbavDynamicfiltersoperator3'},{av:'AV28DynamicFiltersOperator3',fld:'vDYNAMICFILTERSOPERATOR3',pic:'ZZZ9'},{av:'cmbavCordoc3'},{av:'AV29CorDoc3',fld:'vCORDOC3',pic:''},{av:'AV30NumDoc3',fld:'vNUMDOC3',pic:'ZZZZZZZZZ9'},{av:'AV31CorSerie3',fld:'vCORSERIE3',pic:''},{av:'AV20DynamicFiltersEnabled2',fld:'vDYNAMICFILTERSENABLED2',pic:''},{av:'AV26DynamicFiltersEnabled3',fld:'vDYNAMICFILTERSENABLED3',pic:''},{av:'AV56Pgmname',fld:'vPGMNAME',pic:'',hsh:true},{av:'AV37TFCorDoc',fld:'vTFCORDOC',pic:''},{av:'AV38TFCorDoc_Sel',fld:'vTFCORDOC_SEL',pic:''},{av:'AV39TFNumDoc',fld:'vTFNUMDOC',pic:'ZZZZZZZZZ9'},{av:'AV40TFNumDoc_To',fld:'vTFNUMDOC_TO',pic:'ZZZZZZZZZ9'},{av:'AV41TFCorSerie',fld:'vTFCORSERIE',pic:''},{av:'AV42TFCorSerie_Sel',fld:'vTFCORSERIE_SEL',pic:''},{av:'AV43TFCorFE_Sel',fld:'vTFCORFE_SEL',pic:'9'},{av:'AV44TFCorFormato',fld:'vTFCORFORMATO',pic:''},{av:'AV45TFCorFormato_Sel',fld:'vTFCORFORMATO_SEL',pic:''},{av:'AV13OrderedBy',fld:'vORDEREDBY',pic:'ZZZ9'},{av:'AV14OrderedDsc',fld:'vORDEREDDSC',pic:''},{av:'AV10GridState',fld:'vGRIDSTATE',pic:''},{av:'AV33DynamicFiltersIgnoreFirst',fld:'vDYNAMICFILTERSIGNOREFIRST',pic:''},{av:'AV32DynamicFiltersRemoving',fld:'vDYNAMICFILTERSREMOVING',pic:''}]");
         setEventMetadata("'REMOVEDYNAMICFILTERS3'",",oparms:[{av:'AV32DynamicFiltersRemoving',fld:'vDYNAMICFILTERSREMOVING',pic:''},{av:'AV26DynamicFiltersEnabled3',fld:'vDYNAMICFILTERSENABLED3',pic:''},{av:'AV10GridState',fld:'vGRIDSTATE',pic:''},{av:'AV20DynamicFiltersEnabled2',fld:'vDYNAMICFILTERSENABLED2',pic:''},{av:'cmbavDynamicfiltersselector2'},{av:'AV21DynamicFiltersSelector2',fld:'vDYNAMICFILTERSSELECTOR2',pic:''},{av:'cmbavCordoc2'},{av:'AV23CorDoc2',fld:'vCORDOC2',pic:''},{av:'cmbavDynamicfiltersselector3'},{av:'AV27DynamicFiltersSelector3',fld:'vDYNAMICFILTERSSELECTOR3',pic:''},{av:'cmbavCordoc3'},{av:'AV29CorDoc3',fld:'vCORDOC3',pic:''},{av:'imgAdddynamicfilters1_Visible',ctrl:'ADDDYNAMICFILTERS1',prop:'Visible'},{av:'imgRemovedynamicfilters1_Visible',ctrl:'REMOVEDYNAMICFILTERS1',prop:'Visible'},{av:'cmbavDynamicfiltersoperator1'},{av:'imgAdddynamicfilters2_Visible',ctrl:'ADDDYNAMICFILTERS2',prop:'Visible'},{av:'imgRemovedynamicfilters2_Visible',ctrl:'REMOVEDYNAMICFILTERS2',prop:'Visible'},{av:'cmbavDynamicfiltersoperator2'},{av:'cmbavDynamicfiltersoperator3'},{av:'cmbavDynamicfiltersselector1'},{av:'AV15DynamicFiltersSelector1',fld:'vDYNAMICFILTERSSELECTOR1',pic:''},{av:'cmbavCordoc1'},{av:'AV17CorDoc1',fld:'vCORDOC1',pic:''},{av:'AV16DynamicFiltersOperator1',fld:'vDYNAMICFILTERSOPERATOR1',pic:'ZZZ9'},{av:'AV18NumDoc1',fld:'vNUMDOC1',pic:'ZZZZZZZZZ9'},{av:'AV19CorSerie1',fld:'vCORSERIE1',pic:''},{av:'lblJsdynamicfilters_Caption',ctrl:'JSDYNAMICFILTERS',prop:'Caption'},{av:'AV22DynamicFiltersOperator2',fld:'vDYNAMICFILTERSOPERATOR2',pic:'ZZZ9'},{av:'AV24NumDoc2',fld:'vNUMDOC2',pic:'ZZZZZZZZZ9'},{av:'AV25CorSerie2',fld:'vCORSERIE2',pic:''},{av:'AV28DynamicFiltersOperator3',fld:'vDYNAMICFILTERSOPERATOR3',pic:'ZZZ9'},{av:'AV30NumDoc3',fld:'vNUMDOC3',pic:'ZZZZZZZZZ9'},{av:'AV31CorSerie3',fld:'vCORSERIE3',pic:''},{av:'edtavNumdoc2_Visible',ctrl:'vNUMDOC2',prop:'Visible'},{av:'edtavCorserie2_Visible',ctrl:'vCORSERIE2',prop:'Visible'},{av:'edtavNumdoc3_Visible',ctrl:'vNUMDOC3',prop:'Visible'},{av:'edtavCorserie3_Visible',ctrl:'vCORSERIE3',prop:'Visible'},{av:'edtavNumdoc1_Visible',ctrl:'vNUMDOC1',prop:'Visible'},{av:'edtavCorserie1_Visible',ctrl:'vCORSERIE1',prop:'Visible'},{av:'AV48GridCurrentPage',fld:'vGRIDCURRENTPAGE',pic:'ZZZZZZZZZ9'},{av:'AV49GridPageCount',fld:'vGRIDPAGECOUNT',pic:'ZZZZZZZZZ9'},{av:'AV50GridAppliedFilters',fld:'vGRIDAPPLIEDFILTERS',pic:''}]}");
         setEventMetadata("VDYNAMICFILTERSSELECTOR3.CLICK","{handler:'E230F2',iparms:[{av:'cmbavDynamicfiltersselector3'},{av:'AV27DynamicFiltersSelector3',fld:'vDYNAMICFILTERSSELECTOR3',pic:''}]");
         setEventMetadata("VDYNAMICFILTERSSELECTOR3.CLICK",",oparms:[{av:'cmbavDynamicfiltersoperator3'},{av:'AV28DynamicFiltersOperator3',fld:'vDYNAMICFILTERSOPERATOR3',pic:'ZZZ9'},{av:'cmbavCordoc3'},{av:'edtavNumdoc3_Visible',ctrl:'vNUMDOC3',prop:'Visible'},{av:'edtavCorserie3_Visible',ctrl:'vCORSERIE3',prop:'Visible'}]}");
         setEventMetadata("VGRIDACTIONS.CLICK","{handler:'E270F2',iparms:[{av:'cmbavGridactions'},{av:'AV51GridActions',fld:'vGRIDACTIONS',pic:'ZZZ9'},{av:'A339CorDoc',fld:'CORDOC',pic:'',hsh:true},{av:'A340CorSerie',fld:'CORSERIE',pic:'',hsh:true}]");
         setEventMetadata("VGRIDACTIONS.CLICK",",oparms:[{av:'cmbavGridactions'},{av:'AV51GridActions',fld:'vGRIDACTIONS',pic:'ZZZ9'}]}");
         setEventMetadata("'DOINSERT'","{handler:'E180F2',iparms:[{av:'A339CorDoc',fld:'CORDOC',pic:'',hsh:true},{av:'A340CorSerie',fld:'CORSERIE',pic:'',hsh:true}]");
         setEventMetadata("'DOINSERT'",",oparms:[]}");
         setEventMetadata("DDO_AGEXPORT.ONOPTIONCLICKED","{handler:'E130F2',iparms:[{av:'Ddo_agexport_Activeeventkey',ctrl:'DDO_AGEXPORT',prop:'ActiveEventKey'},{av:'AV56Pgmname',fld:'vPGMNAME',pic:'',hsh:true},{av:'AV38TFCorDoc_Sel',fld:'vTFCORDOC_SEL',pic:''},{av:'AV42TFCorSerie_Sel',fld:'vTFCORSERIE_SEL',pic:''},{av:'AV43TFCorFE_Sel',fld:'vTFCORFE_SEL',pic:'9'},{av:'AV45TFCorFormato_Sel',fld:'vTFCORFORMATO_SEL',pic:''},{av:'AV37TFCorDoc',fld:'vTFCORDOC',pic:''},{av:'AV39TFNumDoc',fld:'vTFNUMDOC',pic:'ZZZZZZZZZ9'},{av:'AV41TFCorSerie',fld:'vTFCORSERIE',pic:''},{av:'AV44TFCorFormato',fld:'vTFCORFORMATO',pic:''},{av:'AV40TFNumDoc_To',fld:'vTFNUMDOC_TO',pic:'ZZZZZZZZZ9'},{av:'AV13OrderedBy',fld:'vORDEREDBY',pic:'ZZZ9'},{av:'AV14OrderedDsc',fld:'vORDEREDDSC',pic:''},{av:'AV10GridState',fld:'vGRIDSTATE',pic:''},{av:'AV32DynamicFiltersRemoving',fld:'vDYNAMICFILTERSREMOVING',pic:''},{av:'cmbavDynamicfiltersselector1'},{av:'AV15DynamicFiltersSelector1',fld:'vDYNAMICFILTERSSELECTOR1',pic:''},{av:'cmbavDynamicfiltersselector2'},{av:'AV21DynamicFiltersSelector2',fld:'vDYNAMICFILTERSSELECTOR2',pic:''},{av:'cmbavDynamicfiltersselector3'},{av:'AV27DynamicFiltersSelector3',fld:'vDYNAMICFILTERSSELECTOR3',pic:''}]");
         setEventMetadata("DDO_AGEXPORT.ONOPTIONCLICKED",",oparms:[{av:'Innewwindow1_Target',ctrl:'INNEWWINDOW1',prop:'Target'},{av:'Innewwindow1_Height',ctrl:'INNEWWINDOW1',prop:'Height'},{av:'Innewwindow1_Width',ctrl:'INNEWWINDOW1',prop:'Width'},{av:'AV10GridState',fld:'vGRIDSTATE',pic:''},{av:'AV13OrderedBy',fld:'vORDEREDBY',pic:'ZZZ9'},{av:'AV14OrderedDsc',fld:'vORDEREDDSC',pic:''},{av:'AV45TFCorFormato_Sel',fld:'vTFCORFORMATO_SEL',pic:''},{av:'AV44TFCorFormato',fld:'vTFCORFORMATO',pic:''},{av:'AV43TFCorFE_Sel',fld:'vTFCORFE_SEL',pic:'9'},{av:'AV42TFCorSerie_Sel',fld:'vTFCORSERIE_SEL',pic:''},{av:'AV41TFCorSerie',fld:'vTFCORSERIE',pic:''},{av:'AV39TFNumDoc',fld:'vTFNUMDOC',pic:'ZZZZZZZZZ9'},{av:'AV40TFNumDoc_To',fld:'vTFNUMDOC_TO',pic:'ZZZZZZZZZ9'},{av:'AV38TFCorDoc_Sel',fld:'vTFCORDOC_SEL',pic:''},{av:'AV37TFCorDoc',fld:'vTFCORDOC',pic:''},{av:'Ddo_grid_Selectedvalue_set',ctrl:'DDO_GRID',prop:'SelectedValue_set'},{av:'Ddo_grid_Filteredtext_set',ctrl:'DDO_GRID',prop:'FilteredText_set'},{av:'Ddo_grid_Filteredtextto_set',ctrl:'DDO_GRID',prop:'FilteredTextTo_set'},{av:'subGrid_Rows',ctrl:'GRID',prop:'Rows'},{av:'GRID_nFirstRecordOnPage'},{av:'GRID_nEOF'},{av:'cmbavDynamicfiltersselector1'},{av:'AV15DynamicFiltersSelector1',fld:'vDYNAMICFILTERSSELECTOR1',pic:''},{av:'cmbavDynamicfiltersoperator1'},{av:'AV16DynamicFiltersOperator1',fld:'vDYNAMICFILTERSOPERATOR1',pic:'ZZZ9'},{av:'cmbavCordoc1'},{av:'AV17CorDoc1',fld:'vCORDOC1',pic:''},{av:'AV18NumDoc1',fld:'vNUMDOC1',pic:'ZZZZZZZZZ9'},{av:'AV19CorSerie1',fld:'vCORSERIE1',pic:''},{av:'cmbavDynamicfiltersselector2'},{av:'AV21DynamicFiltersSelector2',fld:'vDYNAMICFILTERSSELECTOR2',pic:''},{av:'cmbavDynamicfiltersoperator2'},{av:'AV22DynamicFiltersOperator2',fld:'vDYNAMICFILTERSOPERATOR2',pic:'ZZZ9'},{av:'cmbavCordoc2'},{av:'AV23CorDoc2',fld:'vCORDOC2',pic:''},{av:'AV24NumDoc2',fld:'vNUMDOC2',pic:'ZZZZZZZZZ9'},{av:'AV25CorSerie2',fld:'vCORSERIE2',pic:''},{av:'cmbavDynamicfiltersselector3'},{av:'AV27DynamicFiltersSelector3',fld:'vDYNAMICFILTERSSELECTOR3',pic:''},{av:'cmbavDynamicfiltersoperator3'},{av:'AV28DynamicFiltersOperator3',fld:'vDYNAMICFILTERSOPERATOR3',pic:'ZZZ9'},{av:'cmbavCordoc3'},{av:'AV29CorDoc3',fld:'vCORDOC3',pic:''},{av:'AV30NumDoc3',fld:'vNUMDOC3',pic:'ZZZZZZZZZ9'},{av:'AV31CorSerie3',fld:'vCORSERIE3',pic:''},{av:'AV20DynamicFiltersEnabled2',fld:'vDYNAMICFILTERSENABLED2',pic:''},{av:'AV26DynamicFiltersEnabled3',fld:'vDYNAMICFILTERSENABLED3',pic:''},{av:'AV56Pgmname',fld:'vPGMNAME',pic:'',hsh:true},{av:'AV33DynamicFiltersIgnoreFirst',fld:'vDYNAMICFILTERSIGNOREFIRST',pic:''},{av:'AV32DynamicFiltersRemoving',fld:'vDYNAMICFILTERSREMOVING',pic:''},{av:'Ddo_grid_Sortedstatus',ctrl:'DDO_GRID',prop:'SortedStatus'},{av:'imgAdddynamicfilters1_Visible',ctrl:'ADDDYNAMICFILTERS1',prop:'Visible'},{av:'imgRemovedynamicfilters1_Visible',ctrl:'REMOVEDYNAMICFILTERS1',prop:'Visible'},{av:'imgAdddynamicfilters2_Visible',ctrl:'ADDDYNAMICFILTERS2',prop:'Visible'},{av:'imgRemovedynamicfilters2_Visible',ctrl:'REMOVEDYNAMICFILTERS2',prop:'Visible'},{av:'lblJsdynamicfilters_Caption',ctrl:'JSDYNAMICFILTERS',prop:'Caption'},{av:'edtavNumdoc1_Visible',ctrl:'vNUMDOC1',prop:'Visible'},{av:'edtavCorserie1_Visible',ctrl:'vCORSERIE1',prop:'Visible'},{av:'edtavNumdoc2_Visible',ctrl:'vNUMDOC2',prop:'Visible'},{av:'edtavCorserie2_Visible',ctrl:'vCORSERIE2',prop:'Visible'},{av:'edtavNumdoc3_Visible',ctrl:'vNUMDOC3',prop:'Visible'},{av:'edtavCorserie3_Visible',ctrl:'vCORSERIE3',prop:'Visible'}]}");
         setEventMetadata("NULL","{handler:'Valid_Corformato',iparms:[]");
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
         AV17CorDoc1 = "";
         AV19CorSerie1 = "";
         AV21DynamicFiltersSelector2 = "";
         AV23CorDoc2 = "";
         AV25CorSerie2 = "";
         AV27DynamicFiltersSelector3 = "";
         AV29CorDoc3 = "";
         AV31CorSerie3 = "";
         AV56Pgmname = "";
         AV37TFCorDoc = "";
         AV38TFCorDoc_Sel = "";
         AV41TFCorSerie = "";
         AV42TFCorSerie_Sel = "";
         AV44TFCorFormato = "";
         AV45TFCorFormato_Sel = "";
         AV10GridState = new GeneXus.Programs.wwpbaseobjects.SdtWWPGridState(context);
         sDynURL = "";
         FormProcess = "";
         bodyStyle = "";
         GXKey = "";
         AV50GridAppliedFilters = "";
         AV52AGExportData = new GXBaseCollection<GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTDropDownOptionsData_Item>( context, "Item", "");
         AV46DDO_TitleSettingsIcons = new GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTDropDownOptionsTitleSettingsIcons(context);
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
         A339CorDoc = "";
         A340CorSerie = "";
         A757CorFormato = "";
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
         scmdbuf = "";
         lV61Seguridad_numeraciondocumentoswwds_5_corserie1 = "";
         lV67Seguridad_numeraciondocumentoswwds_11_corserie2 = "";
         lV73Seguridad_numeraciondocumentoswwds_17_corserie3 = "";
         lV74Seguridad_numeraciondocumentoswwds_18_tfcordoc = "";
         lV78Seguridad_numeraciondocumentoswwds_22_tfcorserie = "";
         lV81Seguridad_numeraciondocumentoswwds_25_tfcorformato = "";
         AV57Seguridad_numeraciondocumentoswwds_1_dynamicfiltersselector1 = "";
         AV59Seguridad_numeraciondocumentoswwds_3_cordoc1 = "";
         AV61Seguridad_numeraciondocumentoswwds_5_corserie1 = "";
         AV63Seguridad_numeraciondocumentoswwds_7_dynamicfiltersselector2 = "";
         AV65Seguridad_numeraciondocumentoswwds_9_cordoc2 = "";
         AV67Seguridad_numeraciondocumentoswwds_11_corserie2 = "";
         AV69Seguridad_numeraciondocumentoswwds_13_dynamicfiltersselector3 = "";
         AV71Seguridad_numeraciondocumentoswwds_15_cordoc3 = "";
         AV73Seguridad_numeraciondocumentoswwds_17_corserie3 = "";
         AV75Seguridad_numeraciondocumentoswwds_19_tfcordoc_sel = "";
         AV74Seguridad_numeraciondocumentoswwds_18_tfcordoc = "";
         AV79Seguridad_numeraciondocumentoswwds_23_tfcorserie_sel = "";
         AV78Seguridad_numeraciondocumentoswwds_22_tfcorserie = "";
         AV82Seguridad_numeraciondocumentoswwds_26_tfcorformato_sel = "";
         AV81Seguridad_numeraciondocumentoswwds_25_tfcorformato = "";
         H000F2_A757CorFormato = new string[] {""} ;
         H000F2_A756CorFE = new short[1] ;
         H000F2_A340CorSerie = new string[] {""} ;
         H000F2_A1377NumDoc = new long[1] ;
         H000F2_A339CorDoc = new string[] {""} ;
         H000F3_AGRID_nRecordCount = new long[1] ;
         imgAdddynamicfilters1_Jsonclick = "";
         imgRemovedynamicfilters1_Jsonclick = "";
         imgAdddynamicfilters2_Jsonclick = "";
         imgRemovedynamicfilters2_Jsonclick = "";
         imgRemovedynamicfilters3_Jsonclick = "";
         AV53AGExportDataItem = new GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTDropDownOptionsData_Item(context);
         GXt_SdtDVB_SDTDropDownOptionsTitleSettingsIcons1 = new GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTDropDownOptionsTitleSettingsIcons(context);
         AV6WWPContext = new GeneXus.Programs.wwpbaseobjects.SdtWWPContext(context);
         GXEncryptionTmp = "";
         GridRow = new GXWebRow();
         AV36Session = context.GetSession();
         AV11GridStateFilterValue = new GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue(context);
         GXt_char4 = "";
         GXt_char3 = "";
         GXt_char2 = "";
         AV12GridStateDynamicFilter = new GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter(context);
         AV8TrnContext = new GeneXus.Programs.wwpbaseobjects.SdtWWPTransactionContext(context);
         AV7HTTPRequest = new GxHttpRequest( context);
         AV34ExcelFilename = "";
         AV35ErrorMessage = "";
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
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.seguridad.numeraciondocumentosww__default(),
            new Object[][] {
                new Object[] {
               H000F2_A757CorFormato, H000F2_A756CorFE, H000F2_A340CorSerie, H000F2_A1377NumDoc, H000F2_A339CorDoc
               }
               , new Object[] {
               H000F3_AGRID_nRecordCount
               }
            }
         );
         AV56Pgmname = "Seguridad.NumeracionDocumentosWW";
         /* GeneXus formulas. */
         AV56Pgmname = "Seguridad.NumeracionDocumentosWW";
         context.Gx_err = 0;
      }

      private short GRID_nEOF ;
      private short nGotPars ;
      private short GxWebError ;
      private short AV16DynamicFiltersOperator1 ;
      private short AV22DynamicFiltersOperator2 ;
      private short AV28DynamicFiltersOperator3 ;
      private short AV43TFCorFE_Sel ;
      private short AV13OrderedBy ;
      private short initialized ;
      private short gxajaxcallmode ;
      private short wbEnd ;
      private short wbStart ;
      private short subGrid_Backcolorstyle ;
      private short subGrid_Titlebackstyle ;
      private short subGrid_Sortable ;
      private short AV51GridActions ;
      private short A756CorFE ;
      private short subGrid_Allowselection ;
      private short subGrid_Allowhovering ;
      private short subGrid_Allowcollapsing ;
      private short subGrid_Collapsed ;
      private short nDonePA ;
      private short AV58Seguridad_numeraciondocumentoswwds_2_dynamicfiltersoperator1 ;
      private short AV64Seguridad_numeraciondocumentoswwds_8_dynamicfiltersoperator2 ;
      private short AV70Seguridad_numeraciondocumentoswwds_14_dynamicfiltersoperator3 ;
      private short AV80Seguridad_numeraciondocumentoswwds_24_tfcorfe_sel ;
      private short nGXWrapped ;
      private short subGrid_Backstyle ;
      private int subGrid_Rows ;
      private int Gridpaginationbar_Rowsperpageselectedvalue ;
      private int nRC_GXsfl_119 ;
      private int nGXsfl_119_idx=1 ;
      private int Gridpaginationbar_Pagestoshow ;
      private int subGrid_Titlebackcolor ;
      private int subGrid_Allbackcolor ;
      private int subGrid_Selectedindex ;
      private int subGrid_Selectioncolor ;
      private int subGrid_Hoveringcolor ;
      private int subGrid_Islastpage ;
      private int GXPagingFrom2 ;
      private int GXPagingTo2 ;
      private int AV47PageToGo ;
      private int imgAdddynamicfilters1_Visible ;
      private int imgRemovedynamicfilters1_Visible ;
      private int imgAdddynamicfilters2_Visible ;
      private int imgRemovedynamicfilters2_Visible ;
      private int edtavNumdoc1_Visible ;
      private int edtavCorserie1_Visible ;
      private int edtavNumdoc2_Visible ;
      private int edtavCorserie2_Visible ;
      private int edtavNumdoc3_Visible ;
      private int edtavCorserie3_Visible ;
      private int AV83GXV1 ;
      private int edtavNumdoc3_Enabled ;
      private int edtavCorserie3_Enabled ;
      private int edtavNumdoc2_Enabled ;
      private int edtavCorserie2_Enabled ;
      private int edtavNumdoc1_Enabled ;
      private int edtavCorserie1_Enabled ;
      private int idxLst ;
      private int subGrid_Backcolor ;
      private long GRID_nFirstRecordOnPage ;
      private long AV18NumDoc1 ;
      private long AV24NumDoc2 ;
      private long AV30NumDoc3 ;
      private long AV39TFNumDoc ;
      private long AV40TFNumDoc_To ;
      private long AV48GridCurrentPage ;
      private long AV49GridPageCount ;
      private long A1377NumDoc ;
      private long GRID_nCurrentRecord ;
      private long AV60Seguridad_numeraciondocumentoswwds_4_numdoc1 ;
      private long AV66Seguridad_numeraciondocumentoswwds_10_numdoc2 ;
      private long AV72Seguridad_numeraciondocumentoswwds_16_numdoc3 ;
      private long AV76Seguridad_numeraciondocumentoswwds_20_tfnumdoc ;
      private long AV77Seguridad_numeraciondocumentoswwds_21_tfnumdoc_to ;
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
      private string sGXsfl_119_idx="0001" ;
      private string AV17CorDoc1 ;
      private string AV19CorSerie1 ;
      private string AV23CorDoc2 ;
      private string AV25CorSerie2 ;
      private string AV29CorDoc3 ;
      private string AV31CorSerie3 ;
      private string AV56Pgmname ;
      private string AV37TFCorDoc ;
      private string AV38TFCorDoc_Sel ;
      private string AV41TFCorSerie ;
      private string AV42TFCorSerie_Sel ;
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
      private string A339CorDoc ;
      private string edtNumDoc_Link ;
      private string A340CorSerie ;
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
      private string edtCorDoc_Internalname ;
      private string edtNumDoc_Internalname ;
      private string edtCorSerie_Internalname ;
      private string chkCorFE_Internalname ;
      private string edtCorFormato_Internalname ;
      private string cmbavDynamicfiltersselector1_Internalname ;
      private string cmbavDynamicfiltersoperator1_Internalname ;
      private string cmbavCordoc1_Internalname ;
      private string cmbavDynamicfiltersselector2_Internalname ;
      private string cmbavDynamicfiltersoperator2_Internalname ;
      private string cmbavCordoc2_Internalname ;
      private string cmbavDynamicfiltersselector3_Internalname ;
      private string cmbavDynamicfiltersoperator3_Internalname ;
      private string cmbavCordoc3_Internalname ;
      private string scmdbuf ;
      private string lV61Seguridad_numeraciondocumentoswwds_5_corserie1 ;
      private string lV67Seguridad_numeraciondocumentoswwds_11_corserie2 ;
      private string lV73Seguridad_numeraciondocumentoswwds_17_corserie3 ;
      private string lV74Seguridad_numeraciondocumentoswwds_18_tfcordoc ;
      private string lV78Seguridad_numeraciondocumentoswwds_22_tfcorserie ;
      private string AV59Seguridad_numeraciondocumentoswwds_3_cordoc1 ;
      private string AV61Seguridad_numeraciondocumentoswwds_5_corserie1 ;
      private string AV65Seguridad_numeraciondocumentoswwds_9_cordoc2 ;
      private string AV67Seguridad_numeraciondocumentoswwds_11_corserie2 ;
      private string AV71Seguridad_numeraciondocumentoswwds_15_cordoc3 ;
      private string AV73Seguridad_numeraciondocumentoswwds_17_corserie3 ;
      private string AV75Seguridad_numeraciondocumentoswwds_19_tfcordoc_sel ;
      private string AV74Seguridad_numeraciondocumentoswwds_18_tfcordoc ;
      private string AV79Seguridad_numeraciondocumentoswwds_23_tfcorserie_sel ;
      private string AV78Seguridad_numeraciondocumentoswwds_22_tfcorserie ;
      private string edtavNumdoc1_Internalname ;
      private string edtavCorserie1_Internalname ;
      private string edtavNumdoc2_Internalname ;
      private string edtavCorserie2_Internalname ;
      private string edtavNumdoc3_Internalname ;
      private string edtavCorserie3_Internalname ;
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
      private string cellFilter_cordoc3_cell_Internalname ;
      private string cmbavCordoc3_Jsonclick ;
      private string cellFilter_numdoc3_cell_Internalname ;
      private string edtavNumdoc3_Jsonclick ;
      private string cellFilter_corserie3_cell_Internalname ;
      private string edtavCorserie3_Jsonclick ;
      private string cellDynamicfilters_removefilter3_cell_Internalname ;
      private string sImgUrl ;
      private string tblTablemergeddynamicfilters2_Internalname ;
      private string cmbavDynamicfiltersoperator2_Jsonclick ;
      private string cellFilter_cordoc2_cell_Internalname ;
      private string cmbavCordoc2_Jsonclick ;
      private string cellFilter_numdoc2_cell_Internalname ;
      private string edtavNumdoc2_Jsonclick ;
      private string cellFilter_corserie2_cell_Internalname ;
      private string edtavCorserie2_Jsonclick ;
      private string cellDynamicfilters_addfilter2_cell_Internalname ;
      private string cellDynamicfilters_removefilter2_cell_Internalname ;
      private string tblTablemergeddynamicfilters1_Internalname ;
      private string cmbavDynamicfiltersoperator1_Jsonclick ;
      private string cellFilter_cordoc1_cell_Internalname ;
      private string cmbavCordoc1_Jsonclick ;
      private string cellFilter_numdoc1_cell_Internalname ;
      private string edtavNumdoc1_Jsonclick ;
      private string cellFilter_corserie1_cell_Internalname ;
      private string edtavCorserie1_Jsonclick ;
      private string cellDynamicfilters_addfilter1_cell_Internalname ;
      private string cellDynamicfilters_removefilter1_cell_Internalname ;
      private string sGXsfl_119_fel_idx="0001" ;
      private string GXCCtl ;
      private string cmbavGridactions_Jsonclick ;
      private string ROClassString ;
      private string edtCorDoc_Jsonclick ;
      private string edtNumDoc_Jsonclick ;
      private string edtCorSerie_Jsonclick ;
      private string edtCorFormato_Jsonclick ;
      private bool entryPointCalled ;
      private bool toggleJsOutput ;
      private bool AV20DynamicFiltersEnabled2 ;
      private bool AV26DynamicFiltersEnabled3 ;
      private bool AV14OrderedDsc ;
      private bool AV33DynamicFiltersIgnoreFirst ;
      private bool AV32DynamicFiltersRemoving ;
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
      private bool bGXsfl_119_Refreshing=false ;
      private bool gxdyncontrolsrefreshing ;
      private bool AV62Seguridad_numeraciondocumentoswwds_6_dynamicfiltersenabled2 ;
      private bool AV68Seguridad_numeraciondocumentoswwds_12_dynamicfiltersenabled3 ;
      private bool returnInSub ;
      private bool gx_refresh_fired ;
      private string AV15DynamicFiltersSelector1 ;
      private string AV21DynamicFiltersSelector2 ;
      private string AV27DynamicFiltersSelector3 ;
      private string AV44TFCorFormato ;
      private string AV45TFCorFormato_Sel ;
      private string AV50GridAppliedFilters ;
      private string A757CorFormato ;
      private string lV81Seguridad_numeraciondocumentoswwds_25_tfcorformato ;
      private string AV57Seguridad_numeraciondocumentoswwds_1_dynamicfiltersselector1 ;
      private string AV63Seguridad_numeraciondocumentoswwds_7_dynamicfiltersselector2 ;
      private string AV69Seguridad_numeraciondocumentoswwds_13_dynamicfiltersselector3 ;
      private string AV82Seguridad_numeraciondocumentoswwds_26_tfcorformato_sel ;
      private string AV81Seguridad_numeraciondocumentoswwds_25_tfcorformato ;
      private string AV34ExcelFilename ;
      private string AV35ErrorMessage ;
      private IGxSession AV36Session ;
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
      private GXCombobox cmbavCordoc1 ;
      private GXCombobox cmbavDynamicfiltersselector2 ;
      private GXCombobox cmbavDynamicfiltersoperator2 ;
      private GXCombobox cmbavCordoc2 ;
      private GXCombobox cmbavDynamicfiltersselector3 ;
      private GXCombobox cmbavDynamicfiltersoperator3 ;
      private GXCombobox cmbavCordoc3 ;
      private GXCombobox cmbavGridactions ;
      private GXCheckbox chkCorFE ;
      private IDataStoreProvider pr_default ;
      private string[] H000F2_A757CorFormato ;
      private short[] H000F2_A756CorFE ;
      private string[] H000F2_A340CorSerie ;
      private long[] H000F2_A1377NumDoc ;
      private string[] H000F2_A339CorDoc ;
      private long[] H000F3_AGRID_nRecordCount ;
      private msglist BackMsgLst ;
      private msglist LclMsgLst ;
      private GxHttpRequest AV7HTTPRequest ;
      private GXBaseCollection<GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTDropDownOptionsData_Item> AV52AGExportData ;
      private GXWebForm Form ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPContext AV6WWPContext ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPTransactionContext AV8TrnContext ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPGridState AV10GridState ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue AV11GridStateFilterValue ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter AV12GridStateDynamicFilter ;
      private GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTDropDownOptionsTitleSettingsIcons AV46DDO_TitleSettingsIcons ;
      private GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTDropDownOptionsTitleSettingsIcons GXt_SdtDVB_SDTDropDownOptionsTitleSettingsIcons1 ;
      private GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTDropDownOptionsData_Item AV53AGExportDataItem ;
   }

   public class numeraciondocumentosww__default : DataStoreHelperBase, IDataStoreHelper
   {
      protected Object[] conditional_H000F2( IGxContext context ,
                                             string AV57Seguridad_numeraciondocumentoswwds_1_dynamicfiltersselector1 ,
                                             string AV59Seguridad_numeraciondocumentoswwds_3_cordoc1 ,
                                             short AV58Seguridad_numeraciondocumentoswwds_2_dynamicfiltersoperator1 ,
                                             long AV60Seguridad_numeraciondocumentoswwds_4_numdoc1 ,
                                             string AV61Seguridad_numeraciondocumentoswwds_5_corserie1 ,
                                             bool AV62Seguridad_numeraciondocumentoswwds_6_dynamicfiltersenabled2 ,
                                             string AV63Seguridad_numeraciondocumentoswwds_7_dynamicfiltersselector2 ,
                                             string AV65Seguridad_numeraciondocumentoswwds_9_cordoc2 ,
                                             short AV64Seguridad_numeraciondocumentoswwds_8_dynamicfiltersoperator2 ,
                                             long AV66Seguridad_numeraciondocumentoswwds_10_numdoc2 ,
                                             string AV67Seguridad_numeraciondocumentoswwds_11_corserie2 ,
                                             bool AV68Seguridad_numeraciondocumentoswwds_12_dynamicfiltersenabled3 ,
                                             string AV69Seguridad_numeraciondocumentoswwds_13_dynamicfiltersselector3 ,
                                             string AV71Seguridad_numeraciondocumentoswwds_15_cordoc3 ,
                                             short AV70Seguridad_numeraciondocumentoswwds_14_dynamicfiltersoperator3 ,
                                             long AV72Seguridad_numeraciondocumentoswwds_16_numdoc3 ,
                                             string AV73Seguridad_numeraciondocumentoswwds_17_corserie3 ,
                                             string AV75Seguridad_numeraciondocumentoswwds_19_tfcordoc_sel ,
                                             string AV74Seguridad_numeraciondocumentoswwds_18_tfcordoc ,
                                             long AV76Seguridad_numeraciondocumentoswwds_20_tfnumdoc ,
                                             long AV77Seguridad_numeraciondocumentoswwds_21_tfnumdoc_to ,
                                             string AV79Seguridad_numeraciondocumentoswwds_23_tfcorserie_sel ,
                                             string AV78Seguridad_numeraciondocumentoswwds_22_tfcorserie ,
                                             short AV80Seguridad_numeraciondocumentoswwds_24_tfcorfe_sel ,
                                             string AV82Seguridad_numeraciondocumentoswwds_26_tfcorformato_sel ,
                                             string AV81Seguridad_numeraciondocumentoswwds_25_tfcorformato ,
                                             string A339CorDoc ,
                                             long A1377NumDoc ,
                                             string A340CorSerie ,
                                             short A756CorFE ,
                                             string A757CorFormato ,
                                             short AV13OrderedBy ,
                                             bool AV14OrderedDsc )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int5 = new short[29];
         Object[] GXv_Object6 = new Object[2];
         string sSelectString;
         string sFromString;
         string sOrderString;
         sSelectString = " [CorFormato], [CorFE], [CorSerie], [NumDoc], [CorDoc]";
         sFromString = " FROM [SGCDOCUMENTOS]";
         sOrderString = "";
         if ( ( StringUtil.StrCmp(AV57Seguridad_numeraciondocumentoswwds_1_dynamicfiltersselector1, "CORDOC") == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV59Seguridad_numeraciondocumentoswwds_3_cordoc1)) ) )
         {
            AddWhere(sWhereString, "([CorDoc] = @AV59Seguridad_numeraciondocumentoswwds_3_cordoc1)");
         }
         else
         {
            GXv_int5[0] = 1;
         }
         if ( ( StringUtil.StrCmp(AV57Seguridad_numeraciondocumentoswwds_1_dynamicfiltersselector1, "NUMDOC") == 0 ) && ( AV58Seguridad_numeraciondocumentoswwds_2_dynamicfiltersoperator1 == 0 ) && ( ! (0==AV60Seguridad_numeraciondocumentoswwds_4_numdoc1) ) )
         {
            AddWhere(sWhereString, "([NumDoc] < @AV60Seguridad_numeraciondocumentoswwds_4_numdoc1)");
         }
         else
         {
            GXv_int5[1] = 1;
         }
         if ( ( StringUtil.StrCmp(AV57Seguridad_numeraciondocumentoswwds_1_dynamicfiltersselector1, "NUMDOC") == 0 ) && ( AV58Seguridad_numeraciondocumentoswwds_2_dynamicfiltersoperator1 == 1 ) && ( ! (0==AV60Seguridad_numeraciondocumentoswwds_4_numdoc1) ) )
         {
            AddWhere(sWhereString, "([NumDoc] = @AV60Seguridad_numeraciondocumentoswwds_4_numdoc1)");
         }
         else
         {
            GXv_int5[2] = 1;
         }
         if ( ( StringUtil.StrCmp(AV57Seguridad_numeraciondocumentoswwds_1_dynamicfiltersselector1, "NUMDOC") == 0 ) && ( AV58Seguridad_numeraciondocumentoswwds_2_dynamicfiltersoperator1 == 2 ) && ( ! (0==AV60Seguridad_numeraciondocumentoswwds_4_numdoc1) ) )
         {
            AddWhere(sWhereString, "([NumDoc] > @AV60Seguridad_numeraciondocumentoswwds_4_numdoc1)");
         }
         else
         {
            GXv_int5[3] = 1;
         }
         if ( ( StringUtil.StrCmp(AV57Seguridad_numeraciondocumentoswwds_1_dynamicfiltersselector1, "CORSERIE") == 0 ) && ( AV58Seguridad_numeraciondocumentoswwds_2_dynamicfiltersoperator1 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV61Seguridad_numeraciondocumentoswwds_5_corserie1)) ) )
         {
            AddWhere(sWhereString, "([CorSerie] like @lV61Seguridad_numeraciondocumentoswwds_5_corserie1)");
         }
         else
         {
            GXv_int5[4] = 1;
         }
         if ( ( StringUtil.StrCmp(AV57Seguridad_numeraciondocumentoswwds_1_dynamicfiltersselector1, "CORSERIE") == 0 ) && ( AV58Seguridad_numeraciondocumentoswwds_2_dynamicfiltersoperator1 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV61Seguridad_numeraciondocumentoswwds_5_corserie1)) ) )
         {
            AddWhere(sWhereString, "([CorSerie] like '%' + @lV61Seguridad_numeraciondocumentoswwds_5_corserie1)");
         }
         else
         {
            GXv_int5[5] = 1;
         }
         if ( AV62Seguridad_numeraciondocumentoswwds_6_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV63Seguridad_numeraciondocumentoswwds_7_dynamicfiltersselector2, "CORDOC") == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV65Seguridad_numeraciondocumentoswwds_9_cordoc2)) ) )
         {
            AddWhere(sWhereString, "([CorDoc] = @AV65Seguridad_numeraciondocumentoswwds_9_cordoc2)");
         }
         else
         {
            GXv_int5[6] = 1;
         }
         if ( AV62Seguridad_numeraciondocumentoswwds_6_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV63Seguridad_numeraciondocumentoswwds_7_dynamicfiltersselector2, "NUMDOC") == 0 ) && ( AV64Seguridad_numeraciondocumentoswwds_8_dynamicfiltersoperator2 == 0 ) && ( ! (0==AV66Seguridad_numeraciondocumentoswwds_10_numdoc2) ) )
         {
            AddWhere(sWhereString, "([NumDoc] < @AV66Seguridad_numeraciondocumentoswwds_10_numdoc2)");
         }
         else
         {
            GXv_int5[7] = 1;
         }
         if ( AV62Seguridad_numeraciondocumentoswwds_6_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV63Seguridad_numeraciondocumentoswwds_7_dynamicfiltersselector2, "NUMDOC") == 0 ) && ( AV64Seguridad_numeraciondocumentoswwds_8_dynamicfiltersoperator2 == 1 ) && ( ! (0==AV66Seguridad_numeraciondocumentoswwds_10_numdoc2) ) )
         {
            AddWhere(sWhereString, "([NumDoc] = @AV66Seguridad_numeraciondocumentoswwds_10_numdoc2)");
         }
         else
         {
            GXv_int5[8] = 1;
         }
         if ( AV62Seguridad_numeraciondocumentoswwds_6_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV63Seguridad_numeraciondocumentoswwds_7_dynamicfiltersselector2, "NUMDOC") == 0 ) && ( AV64Seguridad_numeraciondocumentoswwds_8_dynamicfiltersoperator2 == 2 ) && ( ! (0==AV66Seguridad_numeraciondocumentoswwds_10_numdoc2) ) )
         {
            AddWhere(sWhereString, "([NumDoc] > @AV66Seguridad_numeraciondocumentoswwds_10_numdoc2)");
         }
         else
         {
            GXv_int5[9] = 1;
         }
         if ( AV62Seguridad_numeraciondocumentoswwds_6_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV63Seguridad_numeraciondocumentoswwds_7_dynamicfiltersselector2, "CORSERIE") == 0 ) && ( AV64Seguridad_numeraciondocumentoswwds_8_dynamicfiltersoperator2 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV67Seguridad_numeraciondocumentoswwds_11_corserie2)) ) )
         {
            AddWhere(sWhereString, "([CorSerie] like @lV67Seguridad_numeraciondocumentoswwds_11_corserie2)");
         }
         else
         {
            GXv_int5[10] = 1;
         }
         if ( AV62Seguridad_numeraciondocumentoswwds_6_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV63Seguridad_numeraciondocumentoswwds_7_dynamicfiltersselector2, "CORSERIE") == 0 ) && ( AV64Seguridad_numeraciondocumentoswwds_8_dynamicfiltersoperator2 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV67Seguridad_numeraciondocumentoswwds_11_corserie2)) ) )
         {
            AddWhere(sWhereString, "([CorSerie] like '%' + @lV67Seguridad_numeraciondocumentoswwds_11_corserie2)");
         }
         else
         {
            GXv_int5[11] = 1;
         }
         if ( AV68Seguridad_numeraciondocumentoswwds_12_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV69Seguridad_numeraciondocumentoswwds_13_dynamicfiltersselector3, "CORDOC") == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV71Seguridad_numeraciondocumentoswwds_15_cordoc3)) ) )
         {
            AddWhere(sWhereString, "([CorDoc] = @AV71Seguridad_numeraciondocumentoswwds_15_cordoc3)");
         }
         else
         {
            GXv_int5[12] = 1;
         }
         if ( AV68Seguridad_numeraciondocumentoswwds_12_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV69Seguridad_numeraciondocumentoswwds_13_dynamicfiltersselector3, "NUMDOC") == 0 ) && ( AV70Seguridad_numeraciondocumentoswwds_14_dynamicfiltersoperator3 == 0 ) && ( ! (0==AV72Seguridad_numeraciondocumentoswwds_16_numdoc3) ) )
         {
            AddWhere(sWhereString, "([NumDoc] < @AV72Seguridad_numeraciondocumentoswwds_16_numdoc3)");
         }
         else
         {
            GXv_int5[13] = 1;
         }
         if ( AV68Seguridad_numeraciondocumentoswwds_12_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV69Seguridad_numeraciondocumentoswwds_13_dynamicfiltersselector3, "NUMDOC") == 0 ) && ( AV70Seguridad_numeraciondocumentoswwds_14_dynamicfiltersoperator3 == 1 ) && ( ! (0==AV72Seguridad_numeraciondocumentoswwds_16_numdoc3) ) )
         {
            AddWhere(sWhereString, "([NumDoc] = @AV72Seguridad_numeraciondocumentoswwds_16_numdoc3)");
         }
         else
         {
            GXv_int5[14] = 1;
         }
         if ( AV68Seguridad_numeraciondocumentoswwds_12_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV69Seguridad_numeraciondocumentoswwds_13_dynamicfiltersselector3, "NUMDOC") == 0 ) && ( AV70Seguridad_numeraciondocumentoswwds_14_dynamicfiltersoperator3 == 2 ) && ( ! (0==AV72Seguridad_numeraciondocumentoswwds_16_numdoc3) ) )
         {
            AddWhere(sWhereString, "([NumDoc] > @AV72Seguridad_numeraciondocumentoswwds_16_numdoc3)");
         }
         else
         {
            GXv_int5[15] = 1;
         }
         if ( AV68Seguridad_numeraciondocumentoswwds_12_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV69Seguridad_numeraciondocumentoswwds_13_dynamicfiltersselector3, "CORSERIE") == 0 ) && ( AV70Seguridad_numeraciondocumentoswwds_14_dynamicfiltersoperator3 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV73Seguridad_numeraciondocumentoswwds_17_corserie3)) ) )
         {
            AddWhere(sWhereString, "([CorSerie] like @lV73Seguridad_numeraciondocumentoswwds_17_corserie3)");
         }
         else
         {
            GXv_int5[16] = 1;
         }
         if ( AV68Seguridad_numeraciondocumentoswwds_12_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV69Seguridad_numeraciondocumentoswwds_13_dynamicfiltersselector3, "CORSERIE") == 0 ) && ( AV70Seguridad_numeraciondocumentoswwds_14_dynamicfiltersoperator3 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV73Seguridad_numeraciondocumentoswwds_17_corserie3)) ) )
         {
            AddWhere(sWhereString, "([CorSerie] like '%' + @lV73Seguridad_numeraciondocumentoswwds_17_corserie3)");
         }
         else
         {
            GXv_int5[17] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV75Seguridad_numeraciondocumentoswwds_19_tfcordoc_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV74Seguridad_numeraciondocumentoswwds_18_tfcordoc)) ) )
         {
            AddWhere(sWhereString, "([CorDoc] like @lV74Seguridad_numeraciondocumentoswwds_18_tfcordoc)");
         }
         else
         {
            GXv_int5[18] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV75Seguridad_numeraciondocumentoswwds_19_tfcordoc_sel)) )
         {
            AddWhere(sWhereString, "([CorDoc] = @AV75Seguridad_numeraciondocumentoswwds_19_tfcordoc_sel)");
         }
         else
         {
            GXv_int5[19] = 1;
         }
         if ( ! (0==AV76Seguridad_numeraciondocumentoswwds_20_tfnumdoc) )
         {
            AddWhere(sWhereString, "([NumDoc] >= @AV76Seguridad_numeraciondocumentoswwds_20_tfnumdoc)");
         }
         else
         {
            GXv_int5[20] = 1;
         }
         if ( ! (0==AV77Seguridad_numeraciondocumentoswwds_21_tfnumdoc_to) )
         {
            AddWhere(sWhereString, "([NumDoc] <= @AV77Seguridad_numeraciondocumentoswwds_21_tfnumdoc_to)");
         }
         else
         {
            GXv_int5[21] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV79Seguridad_numeraciondocumentoswwds_23_tfcorserie_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV78Seguridad_numeraciondocumentoswwds_22_tfcorserie)) ) )
         {
            AddWhere(sWhereString, "([CorSerie] like @lV78Seguridad_numeraciondocumentoswwds_22_tfcorserie)");
         }
         else
         {
            GXv_int5[22] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV79Seguridad_numeraciondocumentoswwds_23_tfcorserie_sel)) )
         {
            AddWhere(sWhereString, "([CorSerie] = @AV79Seguridad_numeraciondocumentoswwds_23_tfcorserie_sel)");
         }
         else
         {
            GXv_int5[23] = 1;
         }
         if ( AV80Seguridad_numeraciondocumentoswwds_24_tfcorfe_sel == 1 )
         {
            AddWhere(sWhereString, "([CorFE] = 1)");
         }
         if ( AV80Seguridad_numeraciondocumentoswwds_24_tfcorfe_sel == 2 )
         {
            AddWhere(sWhereString, "([CorFE] = 0)");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV82Seguridad_numeraciondocumentoswwds_26_tfcorformato_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV81Seguridad_numeraciondocumentoswwds_25_tfcorformato)) ) )
         {
            AddWhere(sWhereString, "([CorFormato] like @lV81Seguridad_numeraciondocumentoswwds_25_tfcorformato)");
         }
         else
         {
            GXv_int5[24] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV82Seguridad_numeraciondocumentoswwds_26_tfcorformato_sel)) )
         {
            AddWhere(sWhereString, "([CorFormato] = @AV82Seguridad_numeraciondocumentoswwds_26_tfcorformato_sel)");
         }
         else
         {
            GXv_int5[25] = 1;
         }
         if ( AV13OrderedBy == 1 )
         {
            sOrderString += " ORDER BY [CorDoc], [NumDoc]";
         }
         else if ( ( AV13OrderedBy == 2 ) && ! AV14OrderedDsc )
         {
            sOrderString += " ORDER BY [CorDoc]";
         }
         else if ( ( AV13OrderedBy == 2 ) && ( AV14OrderedDsc ) )
         {
            sOrderString += " ORDER BY [CorDoc] DESC";
         }
         else if ( ( AV13OrderedBy == 3 ) && ! AV14OrderedDsc )
         {
            sOrderString += " ORDER BY [NumDoc]";
         }
         else if ( ( AV13OrderedBy == 3 ) && ( AV14OrderedDsc ) )
         {
            sOrderString += " ORDER BY [NumDoc] DESC";
         }
         else if ( ( AV13OrderedBy == 4 ) && ! AV14OrderedDsc )
         {
            sOrderString += " ORDER BY [CorSerie]";
         }
         else if ( ( AV13OrderedBy == 4 ) && ( AV14OrderedDsc ) )
         {
            sOrderString += " ORDER BY [CorSerie] DESC";
         }
         else if ( ( AV13OrderedBy == 5 ) && ! AV14OrderedDsc )
         {
            sOrderString += " ORDER BY [CorFE]";
         }
         else if ( ( AV13OrderedBy == 5 ) && ( AV14OrderedDsc ) )
         {
            sOrderString += " ORDER BY [CorFE] DESC";
         }
         else if ( ( AV13OrderedBy == 6 ) && ! AV14OrderedDsc )
         {
            sOrderString += " ORDER BY [CorFormato]";
         }
         else if ( ( AV13OrderedBy == 6 ) && ( AV14OrderedDsc ) )
         {
            sOrderString += " ORDER BY [CorFormato] DESC";
         }
         else if ( true )
         {
            sOrderString += " ORDER BY [CorDoc], [CorSerie]";
         }
         scmdbuf = "SELECT " + sSelectString + sFromString + sWhereString + sOrderString + "" + " OFFSET " + "@GXPagingFrom2" + " ROWS FETCH NEXT CAST((SELECT CASE WHEN " + "@GXPagingTo2" + " > 0 THEN " + "@GXPagingTo2" + " ELSE 1e9 END) AS INTEGER) ROWS ONLY";
         GXv_Object6[0] = scmdbuf;
         GXv_Object6[1] = GXv_int5;
         return GXv_Object6 ;
      }

      protected Object[] conditional_H000F3( IGxContext context ,
                                             string AV57Seguridad_numeraciondocumentoswwds_1_dynamicfiltersselector1 ,
                                             string AV59Seguridad_numeraciondocumentoswwds_3_cordoc1 ,
                                             short AV58Seguridad_numeraciondocumentoswwds_2_dynamicfiltersoperator1 ,
                                             long AV60Seguridad_numeraciondocumentoswwds_4_numdoc1 ,
                                             string AV61Seguridad_numeraciondocumentoswwds_5_corserie1 ,
                                             bool AV62Seguridad_numeraciondocumentoswwds_6_dynamicfiltersenabled2 ,
                                             string AV63Seguridad_numeraciondocumentoswwds_7_dynamicfiltersselector2 ,
                                             string AV65Seguridad_numeraciondocumentoswwds_9_cordoc2 ,
                                             short AV64Seguridad_numeraciondocumentoswwds_8_dynamicfiltersoperator2 ,
                                             long AV66Seguridad_numeraciondocumentoswwds_10_numdoc2 ,
                                             string AV67Seguridad_numeraciondocumentoswwds_11_corserie2 ,
                                             bool AV68Seguridad_numeraciondocumentoswwds_12_dynamicfiltersenabled3 ,
                                             string AV69Seguridad_numeraciondocumentoswwds_13_dynamicfiltersselector3 ,
                                             string AV71Seguridad_numeraciondocumentoswwds_15_cordoc3 ,
                                             short AV70Seguridad_numeraciondocumentoswwds_14_dynamicfiltersoperator3 ,
                                             long AV72Seguridad_numeraciondocumentoswwds_16_numdoc3 ,
                                             string AV73Seguridad_numeraciondocumentoswwds_17_corserie3 ,
                                             string AV75Seguridad_numeraciondocumentoswwds_19_tfcordoc_sel ,
                                             string AV74Seguridad_numeraciondocumentoswwds_18_tfcordoc ,
                                             long AV76Seguridad_numeraciondocumentoswwds_20_tfnumdoc ,
                                             long AV77Seguridad_numeraciondocumentoswwds_21_tfnumdoc_to ,
                                             string AV79Seguridad_numeraciondocumentoswwds_23_tfcorserie_sel ,
                                             string AV78Seguridad_numeraciondocumentoswwds_22_tfcorserie ,
                                             short AV80Seguridad_numeraciondocumentoswwds_24_tfcorfe_sel ,
                                             string AV82Seguridad_numeraciondocumentoswwds_26_tfcorformato_sel ,
                                             string AV81Seguridad_numeraciondocumentoswwds_25_tfcorformato ,
                                             string A339CorDoc ,
                                             long A1377NumDoc ,
                                             string A340CorSerie ,
                                             short A756CorFE ,
                                             string A757CorFormato ,
                                             short AV13OrderedBy ,
                                             bool AV14OrderedDsc )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int7 = new short[26];
         Object[] GXv_Object8 = new Object[2];
         scmdbuf = "SELECT COUNT(*) FROM [SGCDOCUMENTOS]";
         if ( ( StringUtil.StrCmp(AV57Seguridad_numeraciondocumentoswwds_1_dynamicfiltersselector1, "CORDOC") == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV59Seguridad_numeraciondocumentoswwds_3_cordoc1)) ) )
         {
            AddWhere(sWhereString, "([CorDoc] = @AV59Seguridad_numeraciondocumentoswwds_3_cordoc1)");
         }
         else
         {
            GXv_int7[0] = 1;
         }
         if ( ( StringUtil.StrCmp(AV57Seguridad_numeraciondocumentoswwds_1_dynamicfiltersselector1, "NUMDOC") == 0 ) && ( AV58Seguridad_numeraciondocumentoswwds_2_dynamicfiltersoperator1 == 0 ) && ( ! (0==AV60Seguridad_numeraciondocumentoswwds_4_numdoc1) ) )
         {
            AddWhere(sWhereString, "([NumDoc] < @AV60Seguridad_numeraciondocumentoswwds_4_numdoc1)");
         }
         else
         {
            GXv_int7[1] = 1;
         }
         if ( ( StringUtil.StrCmp(AV57Seguridad_numeraciondocumentoswwds_1_dynamicfiltersselector1, "NUMDOC") == 0 ) && ( AV58Seguridad_numeraciondocumentoswwds_2_dynamicfiltersoperator1 == 1 ) && ( ! (0==AV60Seguridad_numeraciondocumentoswwds_4_numdoc1) ) )
         {
            AddWhere(sWhereString, "([NumDoc] = @AV60Seguridad_numeraciondocumentoswwds_4_numdoc1)");
         }
         else
         {
            GXv_int7[2] = 1;
         }
         if ( ( StringUtil.StrCmp(AV57Seguridad_numeraciondocumentoswwds_1_dynamicfiltersselector1, "NUMDOC") == 0 ) && ( AV58Seguridad_numeraciondocumentoswwds_2_dynamicfiltersoperator1 == 2 ) && ( ! (0==AV60Seguridad_numeraciondocumentoswwds_4_numdoc1) ) )
         {
            AddWhere(sWhereString, "([NumDoc] > @AV60Seguridad_numeraciondocumentoswwds_4_numdoc1)");
         }
         else
         {
            GXv_int7[3] = 1;
         }
         if ( ( StringUtil.StrCmp(AV57Seguridad_numeraciondocumentoswwds_1_dynamicfiltersselector1, "CORSERIE") == 0 ) && ( AV58Seguridad_numeraciondocumentoswwds_2_dynamicfiltersoperator1 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV61Seguridad_numeraciondocumentoswwds_5_corserie1)) ) )
         {
            AddWhere(sWhereString, "([CorSerie] like @lV61Seguridad_numeraciondocumentoswwds_5_corserie1)");
         }
         else
         {
            GXv_int7[4] = 1;
         }
         if ( ( StringUtil.StrCmp(AV57Seguridad_numeraciondocumentoswwds_1_dynamicfiltersselector1, "CORSERIE") == 0 ) && ( AV58Seguridad_numeraciondocumentoswwds_2_dynamicfiltersoperator1 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV61Seguridad_numeraciondocumentoswwds_5_corserie1)) ) )
         {
            AddWhere(sWhereString, "([CorSerie] like '%' + @lV61Seguridad_numeraciondocumentoswwds_5_corserie1)");
         }
         else
         {
            GXv_int7[5] = 1;
         }
         if ( AV62Seguridad_numeraciondocumentoswwds_6_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV63Seguridad_numeraciondocumentoswwds_7_dynamicfiltersselector2, "CORDOC") == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV65Seguridad_numeraciondocumentoswwds_9_cordoc2)) ) )
         {
            AddWhere(sWhereString, "([CorDoc] = @AV65Seguridad_numeraciondocumentoswwds_9_cordoc2)");
         }
         else
         {
            GXv_int7[6] = 1;
         }
         if ( AV62Seguridad_numeraciondocumentoswwds_6_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV63Seguridad_numeraciondocumentoswwds_7_dynamicfiltersselector2, "NUMDOC") == 0 ) && ( AV64Seguridad_numeraciondocumentoswwds_8_dynamicfiltersoperator2 == 0 ) && ( ! (0==AV66Seguridad_numeraciondocumentoswwds_10_numdoc2) ) )
         {
            AddWhere(sWhereString, "([NumDoc] < @AV66Seguridad_numeraciondocumentoswwds_10_numdoc2)");
         }
         else
         {
            GXv_int7[7] = 1;
         }
         if ( AV62Seguridad_numeraciondocumentoswwds_6_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV63Seguridad_numeraciondocumentoswwds_7_dynamicfiltersselector2, "NUMDOC") == 0 ) && ( AV64Seguridad_numeraciondocumentoswwds_8_dynamicfiltersoperator2 == 1 ) && ( ! (0==AV66Seguridad_numeraciondocumentoswwds_10_numdoc2) ) )
         {
            AddWhere(sWhereString, "([NumDoc] = @AV66Seguridad_numeraciondocumentoswwds_10_numdoc2)");
         }
         else
         {
            GXv_int7[8] = 1;
         }
         if ( AV62Seguridad_numeraciondocumentoswwds_6_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV63Seguridad_numeraciondocumentoswwds_7_dynamicfiltersselector2, "NUMDOC") == 0 ) && ( AV64Seguridad_numeraciondocumentoswwds_8_dynamicfiltersoperator2 == 2 ) && ( ! (0==AV66Seguridad_numeraciondocumentoswwds_10_numdoc2) ) )
         {
            AddWhere(sWhereString, "([NumDoc] > @AV66Seguridad_numeraciondocumentoswwds_10_numdoc2)");
         }
         else
         {
            GXv_int7[9] = 1;
         }
         if ( AV62Seguridad_numeraciondocumentoswwds_6_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV63Seguridad_numeraciondocumentoswwds_7_dynamicfiltersselector2, "CORSERIE") == 0 ) && ( AV64Seguridad_numeraciondocumentoswwds_8_dynamicfiltersoperator2 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV67Seguridad_numeraciondocumentoswwds_11_corserie2)) ) )
         {
            AddWhere(sWhereString, "([CorSerie] like @lV67Seguridad_numeraciondocumentoswwds_11_corserie2)");
         }
         else
         {
            GXv_int7[10] = 1;
         }
         if ( AV62Seguridad_numeraciondocumentoswwds_6_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV63Seguridad_numeraciondocumentoswwds_7_dynamicfiltersselector2, "CORSERIE") == 0 ) && ( AV64Seguridad_numeraciondocumentoswwds_8_dynamicfiltersoperator2 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV67Seguridad_numeraciondocumentoswwds_11_corserie2)) ) )
         {
            AddWhere(sWhereString, "([CorSerie] like '%' + @lV67Seguridad_numeraciondocumentoswwds_11_corserie2)");
         }
         else
         {
            GXv_int7[11] = 1;
         }
         if ( AV68Seguridad_numeraciondocumentoswwds_12_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV69Seguridad_numeraciondocumentoswwds_13_dynamicfiltersselector3, "CORDOC") == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV71Seguridad_numeraciondocumentoswwds_15_cordoc3)) ) )
         {
            AddWhere(sWhereString, "([CorDoc] = @AV71Seguridad_numeraciondocumentoswwds_15_cordoc3)");
         }
         else
         {
            GXv_int7[12] = 1;
         }
         if ( AV68Seguridad_numeraciondocumentoswwds_12_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV69Seguridad_numeraciondocumentoswwds_13_dynamicfiltersselector3, "NUMDOC") == 0 ) && ( AV70Seguridad_numeraciondocumentoswwds_14_dynamicfiltersoperator3 == 0 ) && ( ! (0==AV72Seguridad_numeraciondocumentoswwds_16_numdoc3) ) )
         {
            AddWhere(sWhereString, "([NumDoc] < @AV72Seguridad_numeraciondocumentoswwds_16_numdoc3)");
         }
         else
         {
            GXv_int7[13] = 1;
         }
         if ( AV68Seguridad_numeraciondocumentoswwds_12_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV69Seguridad_numeraciondocumentoswwds_13_dynamicfiltersselector3, "NUMDOC") == 0 ) && ( AV70Seguridad_numeraciondocumentoswwds_14_dynamicfiltersoperator3 == 1 ) && ( ! (0==AV72Seguridad_numeraciondocumentoswwds_16_numdoc3) ) )
         {
            AddWhere(sWhereString, "([NumDoc] = @AV72Seguridad_numeraciondocumentoswwds_16_numdoc3)");
         }
         else
         {
            GXv_int7[14] = 1;
         }
         if ( AV68Seguridad_numeraciondocumentoswwds_12_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV69Seguridad_numeraciondocumentoswwds_13_dynamicfiltersselector3, "NUMDOC") == 0 ) && ( AV70Seguridad_numeraciondocumentoswwds_14_dynamicfiltersoperator3 == 2 ) && ( ! (0==AV72Seguridad_numeraciondocumentoswwds_16_numdoc3) ) )
         {
            AddWhere(sWhereString, "([NumDoc] > @AV72Seguridad_numeraciondocumentoswwds_16_numdoc3)");
         }
         else
         {
            GXv_int7[15] = 1;
         }
         if ( AV68Seguridad_numeraciondocumentoswwds_12_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV69Seguridad_numeraciondocumentoswwds_13_dynamicfiltersselector3, "CORSERIE") == 0 ) && ( AV70Seguridad_numeraciondocumentoswwds_14_dynamicfiltersoperator3 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV73Seguridad_numeraciondocumentoswwds_17_corserie3)) ) )
         {
            AddWhere(sWhereString, "([CorSerie] like @lV73Seguridad_numeraciondocumentoswwds_17_corserie3)");
         }
         else
         {
            GXv_int7[16] = 1;
         }
         if ( AV68Seguridad_numeraciondocumentoswwds_12_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV69Seguridad_numeraciondocumentoswwds_13_dynamicfiltersselector3, "CORSERIE") == 0 ) && ( AV70Seguridad_numeraciondocumentoswwds_14_dynamicfiltersoperator3 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV73Seguridad_numeraciondocumentoswwds_17_corserie3)) ) )
         {
            AddWhere(sWhereString, "([CorSerie] like '%' + @lV73Seguridad_numeraciondocumentoswwds_17_corserie3)");
         }
         else
         {
            GXv_int7[17] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV75Seguridad_numeraciondocumentoswwds_19_tfcordoc_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV74Seguridad_numeraciondocumentoswwds_18_tfcordoc)) ) )
         {
            AddWhere(sWhereString, "([CorDoc] like @lV74Seguridad_numeraciondocumentoswwds_18_tfcordoc)");
         }
         else
         {
            GXv_int7[18] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV75Seguridad_numeraciondocumentoswwds_19_tfcordoc_sel)) )
         {
            AddWhere(sWhereString, "([CorDoc] = @AV75Seguridad_numeraciondocumentoswwds_19_tfcordoc_sel)");
         }
         else
         {
            GXv_int7[19] = 1;
         }
         if ( ! (0==AV76Seguridad_numeraciondocumentoswwds_20_tfnumdoc) )
         {
            AddWhere(sWhereString, "([NumDoc] >= @AV76Seguridad_numeraciondocumentoswwds_20_tfnumdoc)");
         }
         else
         {
            GXv_int7[20] = 1;
         }
         if ( ! (0==AV77Seguridad_numeraciondocumentoswwds_21_tfnumdoc_to) )
         {
            AddWhere(sWhereString, "([NumDoc] <= @AV77Seguridad_numeraciondocumentoswwds_21_tfnumdoc_to)");
         }
         else
         {
            GXv_int7[21] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV79Seguridad_numeraciondocumentoswwds_23_tfcorserie_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV78Seguridad_numeraciondocumentoswwds_22_tfcorserie)) ) )
         {
            AddWhere(sWhereString, "([CorSerie] like @lV78Seguridad_numeraciondocumentoswwds_22_tfcorserie)");
         }
         else
         {
            GXv_int7[22] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV79Seguridad_numeraciondocumentoswwds_23_tfcorserie_sel)) )
         {
            AddWhere(sWhereString, "([CorSerie] = @AV79Seguridad_numeraciondocumentoswwds_23_tfcorserie_sel)");
         }
         else
         {
            GXv_int7[23] = 1;
         }
         if ( AV80Seguridad_numeraciondocumentoswwds_24_tfcorfe_sel == 1 )
         {
            AddWhere(sWhereString, "([CorFE] = 1)");
         }
         if ( AV80Seguridad_numeraciondocumentoswwds_24_tfcorfe_sel == 2 )
         {
            AddWhere(sWhereString, "([CorFE] = 0)");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV82Seguridad_numeraciondocumentoswwds_26_tfcorformato_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV81Seguridad_numeraciondocumentoswwds_25_tfcorformato)) ) )
         {
            AddWhere(sWhereString, "([CorFormato] like @lV81Seguridad_numeraciondocumentoswwds_25_tfcorformato)");
         }
         else
         {
            GXv_int7[24] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV82Seguridad_numeraciondocumentoswwds_26_tfcorformato_sel)) )
         {
            AddWhere(sWhereString, "([CorFormato] = @AV82Seguridad_numeraciondocumentoswwds_26_tfcorformato_sel)");
         }
         else
         {
            GXv_int7[25] = 1;
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
                     return conditional_H000F2(context, (string)dynConstraints[0] , (string)dynConstraints[1] , (short)dynConstraints[2] , (long)dynConstraints[3] , (string)dynConstraints[4] , (bool)dynConstraints[5] , (string)dynConstraints[6] , (string)dynConstraints[7] , (short)dynConstraints[8] , (long)dynConstraints[9] , (string)dynConstraints[10] , (bool)dynConstraints[11] , (string)dynConstraints[12] , (string)dynConstraints[13] , (short)dynConstraints[14] , (long)dynConstraints[15] , (string)dynConstraints[16] , (string)dynConstraints[17] , (string)dynConstraints[18] , (long)dynConstraints[19] , (long)dynConstraints[20] , (string)dynConstraints[21] , (string)dynConstraints[22] , (short)dynConstraints[23] , (string)dynConstraints[24] , (string)dynConstraints[25] , (string)dynConstraints[26] , (long)dynConstraints[27] , (string)dynConstraints[28] , (short)dynConstraints[29] , (string)dynConstraints[30] , (short)dynConstraints[31] , (bool)dynConstraints[32] );
               case 1 :
                     return conditional_H000F3(context, (string)dynConstraints[0] , (string)dynConstraints[1] , (short)dynConstraints[2] , (long)dynConstraints[3] , (string)dynConstraints[4] , (bool)dynConstraints[5] , (string)dynConstraints[6] , (string)dynConstraints[7] , (short)dynConstraints[8] , (long)dynConstraints[9] , (string)dynConstraints[10] , (bool)dynConstraints[11] , (string)dynConstraints[12] , (string)dynConstraints[13] , (short)dynConstraints[14] , (long)dynConstraints[15] , (string)dynConstraints[16] , (string)dynConstraints[17] , (string)dynConstraints[18] , (long)dynConstraints[19] , (long)dynConstraints[20] , (string)dynConstraints[21] , (string)dynConstraints[22] , (short)dynConstraints[23] , (string)dynConstraints[24] , (string)dynConstraints[25] , (string)dynConstraints[26] , (long)dynConstraints[27] , (string)dynConstraints[28] , (short)dynConstraints[29] , (string)dynConstraints[30] , (short)dynConstraints[31] , (bool)dynConstraints[32] );
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
          Object[] prmH000F2;
          prmH000F2 = new Object[] {
          new ParDef("@AV59Seguridad_numeraciondocumentoswwds_3_cordoc1",GXType.NChar,10,0) ,
          new ParDef("@AV60Seguridad_numeraciondocumentoswwds_4_numdoc1",GXType.Decimal,10,0) ,
          new ParDef("@AV60Seguridad_numeraciondocumentoswwds_4_numdoc1",GXType.Decimal,10,0) ,
          new ParDef("@AV60Seguridad_numeraciondocumentoswwds_4_numdoc1",GXType.Decimal,10,0) ,
          new ParDef("@lV61Seguridad_numeraciondocumentoswwds_5_corserie1",GXType.NChar,4,0) ,
          new ParDef("@lV61Seguridad_numeraciondocumentoswwds_5_corserie1",GXType.NChar,4,0) ,
          new ParDef("@AV65Seguridad_numeraciondocumentoswwds_9_cordoc2",GXType.NChar,10,0) ,
          new ParDef("@AV66Seguridad_numeraciondocumentoswwds_10_numdoc2",GXType.Decimal,10,0) ,
          new ParDef("@AV66Seguridad_numeraciondocumentoswwds_10_numdoc2",GXType.Decimal,10,0) ,
          new ParDef("@AV66Seguridad_numeraciondocumentoswwds_10_numdoc2",GXType.Decimal,10,0) ,
          new ParDef("@lV67Seguridad_numeraciondocumentoswwds_11_corserie2",GXType.NChar,4,0) ,
          new ParDef("@lV67Seguridad_numeraciondocumentoswwds_11_corserie2",GXType.NChar,4,0) ,
          new ParDef("@AV71Seguridad_numeraciondocumentoswwds_15_cordoc3",GXType.NChar,10,0) ,
          new ParDef("@AV72Seguridad_numeraciondocumentoswwds_16_numdoc3",GXType.Decimal,10,0) ,
          new ParDef("@AV72Seguridad_numeraciondocumentoswwds_16_numdoc3",GXType.Decimal,10,0) ,
          new ParDef("@AV72Seguridad_numeraciondocumentoswwds_16_numdoc3",GXType.Decimal,10,0) ,
          new ParDef("@lV73Seguridad_numeraciondocumentoswwds_17_corserie3",GXType.NChar,4,0) ,
          new ParDef("@lV73Seguridad_numeraciondocumentoswwds_17_corserie3",GXType.NChar,4,0) ,
          new ParDef("@lV74Seguridad_numeraciondocumentoswwds_18_tfcordoc",GXType.NChar,10,0) ,
          new ParDef("@AV75Seguridad_numeraciondocumentoswwds_19_tfcordoc_sel",GXType.NChar,10,0) ,
          new ParDef("@AV76Seguridad_numeraciondocumentoswwds_20_tfnumdoc",GXType.Decimal,10,0) ,
          new ParDef("@AV77Seguridad_numeraciondocumentoswwds_21_tfnumdoc_to",GXType.Decimal,10,0) ,
          new ParDef("@lV78Seguridad_numeraciondocumentoswwds_22_tfcorserie",GXType.NChar,4,0) ,
          new ParDef("@AV79Seguridad_numeraciondocumentoswwds_23_tfcorserie_sel",GXType.NChar,4,0) ,
          new ParDef("@lV81Seguridad_numeraciondocumentoswwds_25_tfcorformato",GXType.NVarChar,50,0) ,
          new ParDef("@AV82Seguridad_numeraciondocumentoswwds_26_tfcorformato_sel",GXType.NVarChar,50,0) ,
          new ParDef("@GXPagingFrom2",GXType.Int32,9,0) ,
          new ParDef("@GXPagingTo2",GXType.Int32,9,0) ,
          new ParDef("@GXPagingTo2",GXType.Int32,9,0)
          };
          Object[] prmH000F3;
          prmH000F3 = new Object[] {
          new ParDef("@AV59Seguridad_numeraciondocumentoswwds_3_cordoc1",GXType.NChar,10,0) ,
          new ParDef("@AV60Seguridad_numeraciondocumentoswwds_4_numdoc1",GXType.Decimal,10,0) ,
          new ParDef("@AV60Seguridad_numeraciondocumentoswwds_4_numdoc1",GXType.Decimal,10,0) ,
          new ParDef("@AV60Seguridad_numeraciondocumentoswwds_4_numdoc1",GXType.Decimal,10,0) ,
          new ParDef("@lV61Seguridad_numeraciondocumentoswwds_5_corserie1",GXType.NChar,4,0) ,
          new ParDef("@lV61Seguridad_numeraciondocumentoswwds_5_corserie1",GXType.NChar,4,0) ,
          new ParDef("@AV65Seguridad_numeraciondocumentoswwds_9_cordoc2",GXType.NChar,10,0) ,
          new ParDef("@AV66Seguridad_numeraciondocumentoswwds_10_numdoc2",GXType.Decimal,10,0) ,
          new ParDef("@AV66Seguridad_numeraciondocumentoswwds_10_numdoc2",GXType.Decimal,10,0) ,
          new ParDef("@AV66Seguridad_numeraciondocumentoswwds_10_numdoc2",GXType.Decimal,10,0) ,
          new ParDef("@lV67Seguridad_numeraciondocumentoswwds_11_corserie2",GXType.NChar,4,0) ,
          new ParDef("@lV67Seguridad_numeraciondocumentoswwds_11_corserie2",GXType.NChar,4,0) ,
          new ParDef("@AV71Seguridad_numeraciondocumentoswwds_15_cordoc3",GXType.NChar,10,0) ,
          new ParDef("@AV72Seguridad_numeraciondocumentoswwds_16_numdoc3",GXType.Decimal,10,0) ,
          new ParDef("@AV72Seguridad_numeraciondocumentoswwds_16_numdoc3",GXType.Decimal,10,0) ,
          new ParDef("@AV72Seguridad_numeraciondocumentoswwds_16_numdoc3",GXType.Decimal,10,0) ,
          new ParDef("@lV73Seguridad_numeraciondocumentoswwds_17_corserie3",GXType.NChar,4,0) ,
          new ParDef("@lV73Seguridad_numeraciondocumentoswwds_17_corserie3",GXType.NChar,4,0) ,
          new ParDef("@lV74Seguridad_numeraciondocumentoswwds_18_tfcordoc",GXType.NChar,10,0) ,
          new ParDef("@AV75Seguridad_numeraciondocumentoswwds_19_tfcordoc_sel",GXType.NChar,10,0) ,
          new ParDef("@AV76Seguridad_numeraciondocumentoswwds_20_tfnumdoc",GXType.Decimal,10,0) ,
          new ParDef("@AV77Seguridad_numeraciondocumentoswwds_21_tfnumdoc_to",GXType.Decimal,10,0) ,
          new ParDef("@lV78Seguridad_numeraciondocumentoswwds_22_tfcorserie",GXType.NChar,4,0) ,
          new ParDef("@AV79Seguridad_numeraciondocumentoswwds_23_tfcorserie_sel",GXType.NChar,4,0) ,
          new ParDef("@lV81Seguridad_numeraciondocumentoswwds_25_tfcorformato",GXType.NVarChar,50,0) ,
          new ParDef("@AV82Seguridad_numeraciondocumentoswwds_26_tfcorformato_sel",GXType.NVarChar,50,0)
          };
          def= new CursorDef[] {
              new CursorDef("H000F2", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH000F2,11, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("H000F3", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH000F3,1, GxCacheFrequency.OFF ,true,false )
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
                ((string[]) buf[0])[0] = rslt.getVarchar(1);
                ((short[]) buf[1])[0] = rslt.getShort(2);
                ((string[]) buf[2])[0] = rslt.getString(3, 4);
                ((long[]) buf[3])[0] = rslt.getLong(4);
                ((string[]) buf[4])[0] = rslt.getString(5, 10);
                return;
             case 1 :
                ((long[]) buf[0])[0] = rslt.getLong(1);
                return;
       }
    }

 }

}
