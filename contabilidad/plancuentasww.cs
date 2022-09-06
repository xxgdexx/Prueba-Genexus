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
   public class plancuentasww : GXDataArea
   {
      public plancuentasww( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDataStore2 = context.GetDataStore("DataStore2");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusTheme");
      }

      public plancuentasww( IGxContext context )
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
         cmbavCuemov1 = new GXCombobox();
         cmbavDynamicfiltersselector2 = new GXCombobox();
         cmbavDynamicfiltersoperator2 = new GXCombobox();
         cmbavCuemov2 = new GXCombobox();
         cmbavDynamicfiltersselector3 = new GXCombobox();
         cmbavDynamicfiltersoperator3 = new GXCombobox();
         cmbavCuemov3 = new GXCombobox();
         cmbavGridactions = new GXCombobox();
         cmbCueSts = new GXCombobox();
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
               AV84CueCod1 = GetPar( "CueCod1");
               AV17CueDsc1 = GetPar( "CueDsc1");
               cmbavCuemov1.FromJSonString( GetNextPar( ));
               AV92CueMov1 = (short)(NumberUtil.Val( GetPar( "CueMov1"), "."));
               cmbavDynamicfiltersselector2.FromJSonString( GetNextPar( ));
               AV20DynamicFiltersSelector2 = GetPar( "DynamicFiltersSelector2");
               cmbavDynamicfiltersoperator2.FromJSonString( GetNextPar( ));
               AV21DynamicFiltersOperator2 = (short)(NumberUtil.Val( GetPar( "DynamicFiltersOperator2"), "."));
               AV85CueCod2 = GetPar( "CueCod2");
               AV22CueDsc2 = GetPar( "CueDsc2");
               cmbavCuemov2.FromJSonString( GetNextPar( ));
               AV93CueMov2 = (short)(NumberUtil.Val( GetPar( "CueMov2"), "."));
               cmbavDynamicfiltersselector3.FromJSonString( GetNextPar( ));
               AV25DynamicFiltersSelector3 = GetPar( "DynamicFiltersSelector3");
               cmbavDynamicfiltersoperator3.FromJSonString( GetNextPar( ));
               AV26DynamicFiltersOperator3 = (short)(NumberUtil.Val( GetPar( "DynamicFiltersOperator3"), "."));
               AV86CueCod3 = GetPar( "CueCod3");
               AV27CueDsc3 = GetPar( "CueDsc3");
               cmbavCuemov3.FromJSonString( GetNextPar( ));
               AV94CueMov3 = (short)(NumberUtil.Val( GetPar( "CueMov3"), "."));
               AV19DynamicFiltersEnabled2 = StringUtil.StrToBool( GetPar( "DynamicFiltersEnabled2"));
               AV24DynamicFiltersEnabled3 = StringUtil.StrToBool( GetPar( "DynamicFiltersEnabled3"));
               AV97Pgmname = GetPar( "Pgmname");
               AV34TFCueCod = GetPar( "TFCueCod");
               AV35TFCueCod_Sel = GetPar( "TFCueCod_Sel");
               AV36TFCueDsc = GetPar( "TFCueDsc");
               AV37TFCueDsc_Sel = GetPar( "TFCueDsc_Sel");
               AV87TFCueMov_Sel = (short)(NumberUtil.Val( GetPar( "TFCueMov_Sel"), "."));
               AV88TFCueMon_Sel = (short)(NumberUtil.Val( GetPar( "TFCueMon_Sel"), "."));
               AV89TFCueCos_Sel = (short)(NumberUtil.Val( GetPar( "TFCueCos_Sel"), "."));
               AV48TFCueGasDebe = GetPar( "TFCueGasDebe");
               AV49TFCueGasDebe_Sel = GetPar( "TFCueGasDebe_Sel");
               AV50TFCueGasHaber = GetPar( "TFCueGasHaber");
               AV51TFCueGasHaber_Sel = GetPar( "TFCueGasHaber_Sel");
               ajax_req_read_hidden_sdt(GetNextPar( ), AV91TFCueSts_Sels);
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
               gxgrGrid_refresh( subGrid_Rows, AV15DynamicFiltersSelector1, AV16DynamicFiltersOperator1, AV84CueCod1, AV17CueDsc1, AV92CueMov1, AV20DynamicFiltersSelector2, AV21DynamicFiltersOperator2, AV85CueCod2, AV22CueDsc2, AV93CueMov2, AV25DynamicFiltersSelector3, AV26DynamicFiltersOperator3, AV86CueCod3, AV27CueDsc3, AV94CueMov3, AV19DynamicFiltersEnabled2, AV24DynamicFiltersEnabled3, AV97Pgmname, AV34TFCueCod, AV35TFCueCod_Sel, AV36TFCueDsc, AV37TFCueDsc_Sel, AV87TFCueMov_Sel, AV88TFCueMon_Sel, AV89TFCueCos_Sel, AV48TFCueGasDebe, AV49TFCueGasDebe_Sel, AV50TFCueGasHaber, AV51TFCueGasHaber_Sel, AV91TFCueSts_Sels, AV13OrderedBy, AV14OrderedDsc, AV10GridState, AV30DynamicFiltersIgnoreFirst, AV29DynamicFiltersRemoving) ;
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
         PA292( ) ;
         gxajaxcallmode = (short)((isAjaxCallMode( ) ? 1 : 0));
         if ( ( gxajaxcallmode == 0 ) && ( GxWebError == 0 ) )
         {
            START292( ) ;
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
         context.AddJavascriptSource("gxcfg.js", "?202281810302081", false, true);
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
         context.WriteHtmlTextNl( "<form id=\"MAINFORM\" autocomplete=\"off\" name=\"MAINFORM\" method=\"post\" tabindex=-1  class=\"form-horizontal Form\" data-gx-class=\"form-horizontal Form\" novalidate action=\""+formatLink("contabilidad.plancuentasww.aspx") +"\">") ;
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
         GxWebStd.gx_hidden_field( context, "gxhash_vPGMNAME", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( AV97Pgmname, "")), context));
         GXKey = Crypto.GetSiteKey( );
      }

      protected void SendCloseFormHiddens( )
      {
         /* Send hidden variables. */
         GxWebStd.gx_hidden_field( context, "GXH_vDYNAMICFILTERSSELECTOR1", AV15DynamicFiltersSelector1);
         GxWebStd.gx_hidden_field( context, "GXH_vDYNAMICFILTERSOPERATOR1", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV16DynamicFiltersOperator1), 4, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "GXH_vCUECOD1", StringUtil.RTrim( AV84CueCod1));
         GxWebStd.gx_hidden_field( context, "GXH_vCUEDSC1", StringUtil.RTrim( AV17CueDsc1));
         GxWebStd.gx_hidden_field( context, "GXH_vCUEMOV1", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV92CueMov1), 1, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "GXH_vDYNAMICFILTERSSELECTOR2", AV20DynamicFiltersSelector2);
         GxWebStd.gx_hidden_field( context, "GXH_vDYNAMICFILTERSOPERATOR2", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV21DynamicFiltersOperator2), 4, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "GXH_vCUECOD2", StringUtil.RTrim( AV85CueCod2));
         GxWebStd.gx_hidden_field( context, "GXH_vCUEDSC2", StringUtil.RTrim( AV22CueDsc2));
         GxWebStd.gx_hidden_field( context, "GXH_vCUEMOV2", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV93CueMov2), 1, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "GXH_vDYNAMICFILTERSSELECTOR3", AV25DynamicFiltersSelector3);
         GxWebStd.gx_hidden_field( context, "GXH_vDYNAMICFILTERSOPERATOR3", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV26DynamicFiltersOperator3), 4, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "GXH_vCUECOD3", StringUtil.RTrim( AV86CueCod3));
         GxWebStd.gx_hidden_field( context, "GXH_vCUEDSC3", StringUtil.RTrim( AV27CueDsc3));
         GxWebStd.gx_hidden_field( context, "GXH_vCUEMOV3", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV94CueMov3), 1, 0, ".", "")));
         /* Send saved values. */
         send_integrity_footer_hashes( ) ;
         GxWebStd.gx_hidden_field( context, "nRC_GXsfl_119", StringUtil.LTrim( StringUtil.NToC( (decimal)(nRC_GXsfl_119), 8, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "vGRIDCURRENTPAGE", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV78GridCurrentPage), 10, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "vGRIDPAGECOUNT", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV79GridPageCount), 10, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "vGRIDAPPLIEDFILTERS", AV80GridAppliedFilters);
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "vAGEXPORTDATA", AV82AGExportData);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt("vAGEXPORTDATA", AV82AGExportData);
         }
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "vDDO_TITLESETTINGSICONS", AV76DDO_TitleSettingsIcons);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt("vDDO_TITLESETTINGSICONS", AV76DDO_TitleSettingsIcons);
         }
         GxWebStd.gx_boolean_hidden_field( context, "vDYNAMICFILTERSENABLED2", AV19DynamicFiltersEnabled2);
         GxWebStd.gx_boolean_hidden_field( context, "vDYNAMICFILTERSENABLED3", AV24DynamicFiltersEnabled3);
         GxWebStd.gx_hidden_field( context, "vPGMNAME", StringUtil.RTrim( AV97Pgmname));
         GxWebStd.gx_hidden_field( context, "gxhash_vPGMNAME", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( AV97Pgmname, "")), context));
         GxWebStd.gx_hidden_field( context, "vTFCUECOD", StringUtil.RTrim( AV34TFCueCod));
         GxWebStd.gx_hidden_field( context, "vTFCUECOD_SEL", StringUtil.RTrim( AV35TFCueCod_Sel));
         GxWebStd.gx_hidden_field( context, "vTFCUEDSC", StringUtil.RTrim( AV36TFCueDsc));
         GxWebStd.gx_hidden_field( context, "vTFCUEDSC_SEL", StringUtil.RTrim( AV37TFCueDsc_Sel));
         GxWebStd.gx_hidden_field( context, "vTFCUEMOV_SEL", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV87TFCueMov_Sel), 1, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "vTFCUEMON_SEL", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV88TFCueMon_Sel), 1, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "vTFCUECOS_SEL", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV89TFCueCos_Sel), 1, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "vTFCUEGASDEBE", StringUtil.RTrim( AV48TFCueGasDebe));
         GxWebStd.gx_hidden_field( context, "vTFCUEGASDEBE_SEL", StringUtil.RTrim( AV49TFCueGasDebe_Sel));
         GxWebStd.gx_hidden_field( context, "vTFCUEGASHABER", StringUtil.RTrim( AV50TFCueGasHaber));
         GxWebStd.gx_hidden_field( context, "vTFCUEGASHABER_SEL", StringUtil.RTrim( AV51TFCueGasHaber_Sel));
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "vTFCUESTS_SELS", AV91TFCueSts_Sels);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt("vTFCUESTS_SELS", AV91TFCueSts_Sels);
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
         GxWebStd.gx_boolean_hidden_field( context, "vDYNAMICFILTERSIGNOREFIRST", AV30DynamicFiltersIgnoreFirst);
         GxWebStd.gx_boolean_hidden_field( context, "vDYNAMICFILTERSREMOVING", AV29DynamicFiltersRemoving);
         GxWebStd.gx_hidden_field( context, "vTFCUESTS_SELSJSON", AV90TFCueSts_SelsJson);
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
            WE292( ) ;
            context.WriteHtmlText( "</div>") ;
         }
      }

      public override void DispatchEvents( )
      {
         EVT292( ) ;
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
         return formatLink("contabilidad.plancuentasww.aspx")  ;
      }

      public override string GetPgmname( )
      {
         return "Contabilidad.PlanCuentasWW" ;
      }

      public override string GetPgmdesc( )
      {
         return " Plan de Cuentas" ;
      }

      protected void WB290( )
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
            GxWebStd.gx_button_ctrl( context, bttBtninsert_Internalname, "gx.evt.setGridEvt("+StringUtil.Str( (decimal)(119), 3, 0)+","+"null"+");", "Agregar", bttBtninsert_Jsonclick, 5, "Agregar", "", StyleString, ClassString, 1, 1, "standard", "'"+""+"'"+",false,"+"'"+"E\\'DOINSERT\\'."+"'", TempTags, "", context.GetButtonType( ), "HLP_Contabilidad\\PlanCuentasWW.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "left", "top", "", "", "div");
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 21,'',false,'',0)\"";
            ClassString = "ColumnsSelector";
            StyleString = "";
            GxWebStd.gx_button_ctrl( context, bttBtnagexport_Internalname, "gx.evt.setGridEvt("+StringUtil.Str( (decimal)(119), 3, 0)+","+"null"+");", "Reportes", bttBtnagexport_Jsonclick, 0, "Reportes", "", StyleString, ClassString, 1, 0, "standard", "'"+""+"'"+",false,"+"'"+""+"'", TempTags, "", context.GetButtonType( ), "HLP_Contabilidad\\PlanCuentasWW.htm");
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
            wb_table1_25_292( true) ;
         }
         else
         {
            wb_table1_25_292( false) ;
         }
         return  ;
      }

      protected void wb_table1_25_292e( bool wbgen )
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
               context.SendWebValue( "Cuenta Contable") ;
               context.WriteHtmlTextNl( "</th>") ;
               context.WriteHtmlText( "<th align=\""+"left"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+""+""+"\" "+">") ;
               context.SendWebValue( "Descripción") ;
               context.WriteHtmlTextNl( "</th>") ;
               context.WriteHtmlText( "<th align=\""+"right"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"AttributeCheckBox"+"\" "+" style=\""+""+""+"\" "+">") ;
               context.SendWebValue( "Movimiento") ;
               context.WriteHtmlTextNl( "</th>") ;
               context.WriteHtmlText( "<th align=\""+"right"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"AttributeCheckBox"+"\" "+" style=\""+""+""+"\" "+">") ;
               context.SendWebValue( "Monetaria") ;
               context.WriteHtmlTextNl( "</th>") ;
               context.WriteHtmlText( "<th align=\""+"right"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"AttributeCheckBox"+"\" "+" style=\""+""+""+"\" "+">") ;
               context.SendWebValue( "Centro de Costos") ;
               context.WriteHtmlTextNl( "</th>") ;
               context.WriteHtmlText( "<th align=\""+"left"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+""+""+"\" "+">") ;
               context.SendWebValue( "Gasto Debe") ;
               context.WriteHtmlTextNl( "</th>") ;
               context.WriteHtmlText( "<th align=\""+"left"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+""+""+"\" "+">") ;
               context.SendWebValue( "Gasto Haber") ;
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
               GridColumn.AddObjectProperty("Value", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV81GridActions), 4, 0, ".", "")));
               GridContainer.AddColumnProperties(GridColumn);
               GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
               GridColumn.AddObjectProperty("Value", StringUtil.RTrim( A91CueCod));
               GridContainer.AddColumnProperties(GridColumn);
               GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
               GridColumn.AddObjectProperty("Value", StringUtil.RTrim( A860CueDsc));
               GridColumn.AddObjectProperty("Link", StringUtil.RTrim( edtCueDsc_Link));
               GridContainer.AddColumnProperties(GridColumn);
               GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
               GridColumn.AddObjectProperty("Value", StringUtil.LTrim( StringUtil.NToC( (decimal)(A867CueMov), 1, 0, ".", "")));
               GridContainer.AddColumnProperties(GridColumn);
               GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
               GridColumn.AddObjectProperty("Value", StringUtil.LTrim( StringUtil.NToC( (decimal)(A864CueMon), 1, 0, ".", "")));
               GridContainer.AddColumnProperties(GridColumn);
               GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
               GridColumn.AddObjectProperty("Value", StringUtil.LTrim( StringUtil.NToC( (decimal)(A859CueCos), 1, 0, ".", "")));
               GridContainer.AddColumnProperties(GridColumn);
               GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
               GridColumn.AddObjectProperty("Value", StringUtil.RTrim( A109CueGasDebe));
               GridContainer.AddColumnProperties(GridColumn);
               GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
               GridColumn.AddObjectProperty("Value", StringUtil.RTrim( A110CueGasHaber));
               GridContainer.AddColumnProperties(GridColumn);
               GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
               GridColumn.AddObjectProperty("Value", StringUtil.LTrim( StringUtil.NToC( (decimal)(A873CueSts), 1, 0, ".", "")));
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
            ucGridpaginationbar.SetProperty("CurrentPage", AV78GridCurrentPage);
            ucGridpaginationbar.SetProperty("PageCount", AV79GridPageCount);
            ucGridpaginationbar.SetProperty("AppliedFilters", AV80GridAppliedFilters);
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
            ucDdo_agexport.SetProperty("DropDownOptionsData", AV82AGExportData);
            ucDdo_agexport.Render(context, "dvelop.gxbootstrap.ddoregular", Ddo_agexport_Internalname, "DDO_AGEXPORTContainer");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblJsdynamicfilters_Internalname, lblJsdynamicfilters_Caption, "", "", lblJsdynamicfilters_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "", 0, "", 1, 1, 0, 1, "HLP_Contabilidad\\PlanCuentasWW.htm");
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
            ucDdo_grid.SetProperty("DropDownOptionsTitleSettingsIcons", AV76DDO_TitleSettingsIcons);
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

      protected void START292( )
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
            Form.Meta.addItem("description", " Plan de Cuentas", 0) ;
         }
         context.wjLoc = "";
         context.nUserReturn = 0;
         context.wbHandled = 0;
         if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
         {
         }
         wbErr = false;
         STRUP290( ) ;
      }

      protected void WS292( )
      {
         START292( ) ;
         EVT292( ) ;
      }

      protected void EVT292( )
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
                              E11292 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "GRIDPAGINATIONBAR.CHANGEROWSPERPAGE") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              E12292 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "DDO_AGEXPORT.ONOPTIONCLICKED") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              E13292 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "DDO_GRID.ONOPTIONCLICKED") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              E14292 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "'REMOVEDYNAMICFILTERS1'") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              /* Execute user event: 'RemoveDynamicFilters1' */
                              E15292 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "'REMOVEDYNAMICFILTERS2'") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              /* Execute user event: 'RemoveDynamicFilters2' */
                              E16292 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "'REMOVEDYNAMICFILTERS3'") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              /* Execute user event: 'RemoveDynamicFilters3' */
                              E17292 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "'DOINSERT'") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              /* Execute user event: 'DoInsert' */
                              E18292 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "'ADDDYNAMICFILTERS1'") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              /* Execute user event: 'AddDynamicFilters1' */
                              E19292 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "VDYNAMICFILTERSSELECTOR1.CLICK") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              E20292 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "'ADDDYNAMICFILTERS2'") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              /* Execute user event: 'AddDynamicFilters2' */
                              E21292 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "VDYNAMICFILTERSSELECTOR2.CLICK") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              E22292 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "VDYNAMICFILTERSSELECTOR3.CLICK") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              E23292 ();
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
                              AV81GridActions = (short)(NumberUtil.Val( cgiGet( cmbavGridactions_Internalname), "."));
                              AssignAttri("", false, cmbavGridactions_Internalname, StringUtil.LTrimStr( (decimal)(AV81GridActions), 4, 0));
                              A91CueCod = cgiGet( edtCueCod_Internalname);
                              A860CueDsc = cgiGet( edtCueDsc_Internalname);
                              A867CueMov = (short)(context.localUtil.CToN( cgiGet( edtCueMov_Internalname), ".", ","));
                              A864CueMon = (short)(context.localUtil.CToN( cgiGet( edtCueMon_Internalname), ".", ","));
                              A859CueCos = (short)(context.localUtil.CToN( cgiGet( edtCueCos_Internalname), ".", ","));
                              A109CueGasDebe = cgiGet( edtCueGasDebe_Internalname);
                              n109CueGasDebe = false;
                              A110CueGasHaber = cgiGet( edtCueGasHaber_Internalname);
                              n110CueGasHaber = false;
                              cmbCueSts.Name = cmbCueSts_Internalname;
                              cmbCueSts.CurrentValue = cgiGet( cmbCueSts_Internalname);
                              A873CueSts = (short)(NumberUtil.Val( cgiGet( cmbCueSts_Internalname), "."));
                              sEvtType = StringUtil.Right( sEvt, 1);
                              if ( StringUtil.StrCmp(sEvtType, ".") == 0 )
                              {
                                 sEvt = StringUtil.Left( sEvt, (short)(StringUtil.Len( sEvt)-1));
                                 if ( StringUtil.StrCmp(sEvt, "START") == 0 )
                                 {
                                    context.wbHandled = 1;
                                    dynload_actions( ) ;
                                    /* Execute user event: Start */
                                    E24292 ();
                                 }
                                 else if ( StringUtil.StrCmp(sEvt, "REFRESH") == 0 )
                                 {
                                    context.wbHandled = 1;
                                    dynload_actions( ) ;
                                    /* Execute user event: Refresh */
                                    E25292 ();
                                 }
                                 else if ( StringUtil.StrCmp(sEvt, "GRID.LOAD") == 0 )
                                 {
                                    context.wbHandled = 1;
                                    dynload_actions( ) ;
                                    E26292 ();
                                 }
                                 else if ( StringUtil.StrCmp(sEvt, "VGRIDACTIONS.CLICK") == 0 )
                                 {
                                    context.wbHandled = 1;
                                    dynload_actions( ) ;
                                    E27292 ();
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
                                       /* Set Refresh If Cuecod1 Changed */
                                       if ( StringUtil.StrCmp(cgiGet( "GXH_vCUECOD1"), AV84CueCod1) != 0 )
                                       {
                                          Rfr0gs = true;
                                       }
                                       /* Set Refresh If Cuedsc1 Changed */
                                       if ( StringUtil.StrCmp(cgiGet( "GXH_vCUEDSC1"), AV17CueDsc1) != 0 )
                                       {
                                          Rfr0gs = true;
                                       }
                                       /* Set Refresh If Cuemov1 Changed */
                                       if ( ( context.localUtil.CToN( cgiGet( "GXH_vCUEMOV1"), ".", ",") != Convert.ToDecimal( AV92CueMov1 )) )
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
                                       /* Set Refresh If Cuecod2 Changed */
                                       if ( StringUtil.StrCmp(cgiGet( "GXH_vCUECOD2"), AV85CueCod2) != 0 )
                                       {
                                          Rfr0gs = true;
                                       }
                                       /* Set Refresh If Cuedsc2 Changed */
                                       if ( StringUtil.StrCmp(cgiGet( "GXH_vCUEDSC2"), AV22CueDsc2) != 0 )
                                       {
                                          Rfr0gs = true;
                                       }
                                       /* Set Refresh If Cuemov2 Changed */
                                       if ( ( context.localUtil.CToN( cgiGet( "GXH_vCUEMOV2"), ".", ",") != Convert.ToDecimal( AV93CueMov2 )) )
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
                                       /* Set Refresh If Cuecod3 Changed */
                                       if ( StringUtil.StrCmp(cgiGet( "GXH_vCUECOD3"), AV86CueCod3) != 0 )
                                       {
                                          Rfr0gs = true;
                                       }
                                       /* Set Refresh If Cuedsc3 Changed */
                                       if ( StringUtil.StrCmp(cgiGet( "GXH_vCUEDSC3"), AV27CueDsc3) != 0 )
                                       {
                                          Rfr0gs = true;
                                       }
                                       /* Set Refresh If Cuemov3 Changed */
                                       if ( ( context.localUtil.CToN( cgiGet( "GXH_vCUEMOV3"), ".", ",") != Convert.ToDecimal( AV94CueMov3 )) )
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

      protected void WE292( )
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

      protected void PA292( )
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
                                       string AV84CueCod1 ,
                                       string AV17CueDsc1 ,
                                       short AV92CueMov1 ,
                                       string AV20DynamicFiltersSelector2 ,
                                       short AV21DynamicFiltersOperator2 ,
                                       string AV85CueCod2 ,
                                       string AV22CueDsc2 ,
                                       short AV93CueMov2 ,
                                       string AV25DynamicFiltersSelector3 ,
                                       short AV26DynamicFiltersOperator3 ,
                                       string AV86CueCod3 ,
                                       string AV27CueDsc3 ,
                                       short AV94CueMov3 ,
                                       bool AV19DynamicFiltersEnabled2 ,
                                       bool AV24DynamicFiltersEnabled3 ,
                                       string AV97Pgmname ,
                                       string AV34TFCueCod ,
                                       string AV35TFCueCod_Sel ,
                                       string AV36TFCueDsc ,
                                       string AV37TFCueDsc_Sel ,
                                       short AV87TFCueMov_Sel ,
                                       short AV88TFCueMon_Sel ,
                                       short AV89TFCueCos_Sel ,
                                       string AV48TFCueGasDebe ,
                                       string AV49TFCueGasDebe_Sel ,
                                       string AV50TFCueGasHaber ,
                                       string AV51TFCueGasHaber_Sel ,
                                       GxSimpleCollection<short> AV91TFCueSts_Sels ,
                                       short AV13OrderedBy ,
                                       bool AV14OrderedDsc ,
                                       GeneXus.Programs.wwpbaseobjects.SdtWWPGridState AV10GridState ,
                                       bool AV30DynamicFiltersIgnoreFirst ,
                                       bool AV29DynamicFiltersRemoving )
      {
         initialize_formulas( ) ;
         GxWebStd.set_html_headers( context, 0, "", "");
         /* Execute user event: Refresh */
         E25292 ();
         GRID_nCurrentRecord = 0;
         RF292( ) ;
         GXKey = Crypto.GetSiteKey( );
         send_integrity_footer_hashes( ) ;
         GXKey = Crypto.GetSiteKey( );
         /* End function gxgrGrid_refresh */
      }

      protected void send_integrity_hashes( )
      {
         GxWebStd.gx_hidden_field( context, "gxhash_CUECOD", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( A91CueCod, "")), context));
         GxWebStd.gx_hidden_field( context, "CUECOD", StringUtil.RTrim( A91CueCod));
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
         if ( cmbavCuemov1.ItemCount > 0 )
         {
            AV92CueMov1 = (short)(NumberUtil.Val( cmbavCuemov1.getValidValue(StringUtil.Trim( StringUtil.Str( (decimal)(AV92CueMov1), 1, 0))), "."));
            AssignAttri("", false, "AV92CueMov1", StringUtil.Str( (decimal)(AV92CueMov1), 1, 0));
         }
         if ( context.isAjaxRequest( ) )
         {
            cmbavCuemov1.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV92CueMov1), 1, 0));
            AssignProp("", false, cmbavCuemov1_Internalname, "Values", cmbavCuemov1.ToJavascriptSource(), true);
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
         if ( cmbavCuemov2.ItemCount > 0 )
         {
            AV93CueMov2 = (short)(NumberUtil.Val( cmbavCuemov2.getValidValue(StringUtil.Trim( StringUtil.Str( (decimal)(AV93CueMov2), 1, 0))), "."));
            AssignAttri("", false, "AV93CueMov2", StringUtil.Str( (decimal)(AV93CueMov2), 1, 0));
         }
         if ( context.isAjaxRequest( ) )
         {
            cmbavCuemov2.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV93CueMov2), 1, 0));
            AssignProp("", false, cmbavCuemov2_Internalname, "Values", cmbavCuemov2.ToJavascriptSource(), true);
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
         if ( cmbavCuemov3.ItemCount > 0 )
         {
            AV94CueMov3 = (short)(NumberUtil.Val( cmbavCuemov3.getValidValue(StringUtil.Trim( StringUtil.Str( (decimal)(AV94CueMov3), 1, 0))), "."));
            AssignAttri("", false, "AV94CueMov3", StringUtil.Str( (decimal)(AV94CueMov3), 1, 0));
         }
         if ( context.isAjaxRequest( ) )
         {
            cmbavCuemov3.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV94CueMov3), 1, 0));
            AssignProp("", false, cmbavCuemov3_Internalname, "Values", cmbavCuemov3.ToJavascriptSource(), true);
         }
      }

      public void Refresh( )
      {
         send_integrity_hashes( ) ;
         RF292( ) ;
         if ( isFullAjaxMode( ) )
         {
            send_integrity_footer_hashes( ) ;
         }
      }

      protected void initialize_formulas( )
      {
         /* GeneXus formulas. */
         AV97Pgmname = "Contabilidad.PlanCuentasWW";
         context.Gx_err = 0;
      }

      protected void RF292( )
      {
         initialize_formulas( ) ;
         clear_multi_value_controls( ) ;
         if ( isAjaxCallMode( ) )
         {
            GridContainer.ClearRows();
         }
         wbStart = 119;
         /* Execute user event: Refresh */
         E25292 ();
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
                                                 A873CueSts ,
                                                 AV126Contabilidad_plancuentaswwds_29_tfcuests_sels ,
                                                 AV98Contabilidad_plancuentaswwds_1_dynamicfiltersselector1 ,
                                                 AV99Contabilidad_plancuentaswwds_2_dynamicfiltersoperator1 ,
                                                 AV100Contabilidad_plancuentaswwds_3_cuecod1 ,
                                                 AV101Contabilidad_plancuentaswwds_4_cuedsc1 ,
                                                 AV103Contabilidad_plancuentaswwds_6_dynamicfiltersenabled2 ,
                                                 AV104Contabilidad_plancuentaswwds_7_dynamicfiltersselector2 ,
                                                 AV105Contabilidad_plancuentaswwds_8_dynamicfiltersoperator2 ,
                                                 AV106Contabilidad_plancuentaswwds_9_cuecod2 ,
                                                 AV107Contabilidad_plancuentaswwds_10_cuedsc2 ,
                                                 AV109Contabilidad_plancuentaswwds_12_dynamicfiltersenabled3 ,
                                                 AV110Contabilidad_plancuentaswwds_13_dynamicfiltersselector3 ,
                                                 AV111Contabilidad_plancuentaswwds_14_dynamicfiltersoperator3 ,
                                                 AV112Contabilidad_plancuentaswwds_15_cuecod3 ,
                                                 AV113Contabilidad_plancuentaswwds_16_cuedsc3 ,
                                                 AV116Contabilidad_plancuentaswwds_19_tfcuecod_sel ,
                                                 AV115Contabilidad_plancuentaswwds_18_tfcuecod ,
                                                 AV118Contabilidad_plancuentaswwds_21_tfcuedsc_sel ,
                                                 AV117Contabilidad_plancuentaswwds_20_tfcuedsc ,
                                                 AV119Contabilidad_plancuentaswwds_22_tfcuemov_sel ,
                                                 AV120Contabilidad_plancuentaswwds_23_tfcuemon_sel ,
                                                 AV121Contabilidad_plancuentaswwds_24_tfcuecos_sel ,
                                                 AV123Contabilidad_plancuentaswwds_26_tfcuegasdebe_sel ,
                                                 AV122Contabilidad_plancuentaswwds_25_tfcuegasdebe ,
                                                 AV125Contabilidad_plancuentaswwds_28_tfcuegashaber_sel ,
                                                 AV124Contabilidad_plancuentaswwds_27_tfcuegashaber ,
                                                 AV126Contabilidad_plancuentaswwds_29_tfcuests_sels.Count ,
                                                 A91CueCod ,
                                                 A860CueDsc ,
                                                 A867CueMov ,
                                                 AV102Contabilidad_plancuentaswwds_5_cuemov1 ,
                                                 AV108Contabilidad_plancuentaswwds_11_cuemov2 ,
                                                 AV114Contabilidad_plancuentaswwds_17_cuemov3 ,
                                                 A864CueMon ,
                                                 A859CueCos ,
                                                 A109CueGasDebe ,
                                                 A110CueGasHaber ,
                                                 AV13OrderedBy ,
                                                 AV14OrderedDsc } ,
                                                 new int[]{
                                                 TypeConstants.SHORT, TypeConstants.SHORT, TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.SHORT, TypeConstants.SHORT, TypeConstants.SHORT, TypeConstants.INT,
                                                 TypeConstants.SHORT, TypeConstants.SHORT, TypeConstants.SHORT, TypeConstants.SHORT, TypeConstants.SHORT, TypeConstants.SHORT, TypeConstants.BOOLEAN, TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.BOOLEAN
                                                 }
            });
            lV100Contabilidad_plancuentaswwds_3_cuecod1 = StringUtil.PadR( StringUtil.RTrim( AV100Contabilidad_plancuentaswwds_3_cuecod1), 15, "%");
            lV100Contabilidad_plancuentaswwds_3_cuecod1 = StringUtil.PadR( StringUtil.RTrim( AV100Contabilidad_plancuentaswwds_3_cuecod1), 15, "%");
            lV101Contabilidad_plancuentaswwds_4_cuedsc1 = StringUtil.PadR( StringUtil.RTrim( AV101Contabilidad_plancuentaswwds_4_cuedsc1), 100, "%");
            lV101Contabilidad_plancuentaswwds_4_cuedsc1 = StringUtil.PadR( StringUtil.RTrim( AV101Contabilidad_plancuentaswwds_4_cuedsc1), 100, "%");
            lV106Contabilidad_plancuentaswwds_9_cuecod2 = StringUtil.PadR( StringUtil.RTrim( AV106Contabilidad_plancuentaswwds_9_cuecod2), 15, "%");
            lV106Contabilidad_plancuentaswwds_9_cuecod2 = StringUtil.PadR( StringUtil.RTrim( AV106Contabilidad_plancuentaswwds_9_cuecod2), 15, "%");
            lV107Contabilidad_plancuentaswwds_10_cuedsc2 = StringUtil.PadR( StringUtil.RTrim( AV107Contabilidad_plancuentaswwds_10_cuedsc2), 100, "%");
            lV107Contabilidad_plancuentaswwds_10_cuedsc2 = StringUtil.PadR( StringUtil.RTrim( AV107Contabilidad_plancuentaswwds_10_cuedsc2), 100, "%");
            lV112Contabilidad_plancuentaswwds_15_cuecod3 = StringUtil.PadR( StringUtil.RTrim( AV112Contabilidad_plancuentaswwds_15_cuecod3), 15, "%");
            lV112Contabilidad_plancuentaswwds_15_cuecod3 = StringUtil.PadR( StringUtil.RTrim( AV112Contabilidad_plancuentaswwds_15_cuecod3), 15, "%");
            lV113Contabilidad_plancuentaswwds_16_cuedsc3 = StringUtil.PadR( StringUtil.RTrim( AV113Contabilidad_plancuentaswwds_16_cuedsc3), 100, "%");
            lV113Contabilidad_plancuentaswwds_16_cuedsc3 = StringUtil.PadR( StringUtil.RTrim( AV113Contabilidad_plancuentaswwds_16_cuedsc3), 100, "%");
            lV115Contabilidad_plancuentaswwds_18_tfcuecod = StringUtil.PadR( StringUtil.RTrim( AV115Contabilidad_plancuentaswwds_18_tfcuecod), 15, "%");
            lV117Contabilidad_plancuentaswwds_20_tfcuedsc = StringUtil.PadR( StringUtil.RTrim( AV117Contabilidad_plancuentaswwds_20_tfcuedsc), 100, "%");
            lV122Contabilidad_plancuentaswwds_25_tfcuegasdebe = StringUtil.PadR( StringUtil.RTrim( AV122Contabilidad_plancuentaswwds_25_tfcuegasdebe), 15, "%");
            lV124Contabilidad_plancuentaswwds_27_tfcuegashaber = StringUtil.PadR( StringUtil.RTrim( AV124Contabilidad_plancuentaswwds_27_tfcuegashaber), 15, "%");
            /* Using cursor H00292 */
            pr_default.execute(0, new Object[] {lV100Contabilidad_plancuentaswwds_3_cuecod1, lV100Contabilidad_plancuentaswwds_3_cuecod1, lV101Contabilidad_plancuentaswwds_4_cuedsc1, lV101Contabilidad_plancuentaswwds_4_cuedsc1, AV102Contabilidad_plancuentaswwds_5_cuemov1, lV106Contabilidad_plancuentaswwds_9_cuecod2, lV106Contabilidad_plancuentaswwds_9_cuecod2, lV107Contabilidad_plancuentaswwds_10_cuedsc2, lV107Contabilidad_plancuentaswwds_10_cuedsc2, AV108Contabilidad_plancuentaswwds_11_cuemov2, lV112Contabilidad_plancuentaswwds_15_cuecod3, lV112Contabilidad_plancuentaswwds_15_cuecod3, lV113Contabilidad_plancuentaswwds_16_cuedsc3, lV113Contabilidad_plancuentaswwds_16_cuedsc3, AV114Contabilidad_plancuentaswwds_17_cuemov3, lV115Contabilidad_plancuentaswwds_18_tfcuecod, AV116Contabilidad_plancuentaswwds_19_tfcuecod_sel, lV117Contabilidad_plancuentaswwds_20_tfcuedsc, AV118Contabilidad_plancuentaswwds_21_tfcuedsc_sel, lV122Contabilidad_plancuentaswwds_25_tfcuegasdebe, AV123Contabilidad_plancuentaswwds_26_tfcuegasdebe_sel, lV124Contabilidad_plancuentaswwds_27_tfcuegashaber, AV125Contabilidad_plancuentaswwds_28_tfcuegashaber_sel, GXPagingFrom2, GXPagingTo2, GXPagingTo2});
            nGXsfl_119_idx = 1;
            sGXsfl_119_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_119_idx), 4, 0), 4, "0");
            SubsflControlProps_1192( ) ;
            while ( ( (pr_default.getStatus(0) != 101) ) && ( ( ( subGrid_Rows == 0 ) || ( GRID_nCurrentRecord < subGrid_fnc_Recordsperpage( ) ) ) ) )
            {
               A873CueSts = H00292_A873CueSts[0];
               A110CueGasHaber = H00292_A110CueGasHaber[0];
               n110CueGasHaber = H00292_n110CueGasHaber[0];
               A109CueGasDebe = H00292_A109CueGasDebe[0];
               n109CueGasDebe = H00292_n109CueGasDebe[0];
               A859CueCos = H00292_A859CueCos[0];
               A864CueMon = H00292_A864CueMon[0];
               A867CueMov = H00292_A867CueMov[0];
               A860CueDsc = H00292_A860CueDsc[0];
               A91CueCod = H00292_A91CueCod[0];
               E26292 ();
               pr_default.readNext(0);
            }
            GRID_nEOF = (short)(((pr_default.getStatus(0) == 101) ? 1 : 0));
            GxWebStd.gx_hidden_field( context, "GRID_nEOF", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRID_nEOF), 1, 0, ".", "")));
            pr_default.close(0);
            wbEnd = 119;
            WB290( ) ;
         }
         bGXsfl_119_Refreshing = true;
      }

      protected void send_integrity_lvl_hashes292( )
      {
         GxWebStd.gx_hidden_field( context, "vPGMNAME", StringUtil.RTrim( AV97Pgmname));
         GxWebStd.gx_hidden_field( context, "gxhash_vPGMNAME", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( AV97Pgmname, "")), context));
         GxWebStd.gx_hidden_field( context, "gxhash_CUECOD"+"_"+sGXsfl_119_idx, GetSecureSignedToken( sGXsfl_119_idx, StringUtil.RTrim( context.localUtil.Format( A91CueCod, "")), context));
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
         AV98Contabilidad_plancuentaswwds_1_dynamicfiltersselector1 = AV15DynamicFiltersSelector1;
         AV99Contabilidad_plancuentaswwds_2_dynamicfiltersoperator1 = AV16DynamicFiltersOperator1;
         AV100Contabilidad_plancuentaswwds_3_cuecod1 = AV84CueCod1;
         AV101Contabilidad_plancuentaswwds_4_cuedsc1 = AV17CueDsc1;
         AV102Contabilidad_plancuentaswwds_5_cuemov1 = AV92CueMov1;
         AV103Contabilidad_plancuentaswwds_6_dynamicfiltersenabled2 = AV19DynamicFiltersEnabled2;
         AV104Contabilidad_plancuentaswwds_7_dynamicfiltersselector2 = AV20DynamicFiltersSelector2;
         AV105Contabilidad_plancuentaswwds_8_dynamicfiltersoperator2 = AV21DynamicFiltersOperator2;
         AV106Contabilidad_plancuentaswwds_9_cuecod2 = AV85CueCod2;
         AV107Contabilidad_plancuentaswwds_10_cuedsc2 = AV22CueDsc2;
         AV108Contabilidad_plancuentaswwds_11_cuemov2 = AV93CueMov2;
         AV109Contabilidad_plancuentaswwds_12_dynamicfiltersenabled3 = AV24DynamicFiltersEnabled3;
         AV110Contabilidad_plancuentaswwds_13_dynamicfiltersselector3 = AV25DynamicFiltersSelector3;
         AV111Contabilidad_plancuentaswwds_14_dynamicfiltersoperator3 = AV26DynamicFiltersOperator3;
         AV112Contabilidad_plancuentaswwds_15_cuecod3 = AV86CueCod3;
         AV113Contabilidad_plancuentaswwds_16_cuedsc3 = AV27CueDsc3;
         AV114Contabilidad_plancuentaswwds_17_cuemov3 = AV94CueMov3;
         AV115Contabilidad_plancuentaswwds_18_tfcuecod = AV34TFCueCod;
         AV116Contabilidad_plancuentaswwds_19_tfcuecod_sel = AV35TFCueCod_Sel;
         AV117Contabilidad_plancuentaswwds_20_tfcuedsc = AV36TFCueDsc;
         AV118Contabilidad_plancuentaswwds_21_tfcuedsc_sel = AV37TFCueDsc_Sel;
         AV119Contabilidad_plancuentaswwds_22_tfcuemov_sel = AV87TFCueMov_Sel;
         AV120Contabilidad_plancuentaswwds_23_tfcuemon_sel = AV88TFCueMon_Sel;
         AV121Contabilidad_plancuentaswwds_24_tfcuecos_sel = AV89TFCueCos_Sel;
         AV122Contabilidad_plancuentaswwds_25_tfcuegasdebe = AV48TFCueGasDebe;
         AV123Contabilidad_plancuentaswwds_26_tfcuegasdebe_sel = AV49TFCueGasDebe_Sel;
         AV124Contabilidad_plancuentaswwds_27_tfcuegashaber = AV50TFCueGasHaber;
         AV125Contabilidad_plancuentaswwds_28_tfcuegashaber_sel = AV51TFCueGasHaber_Sel;
         AV126Contabilidad_plancuentaswwds_29_tfcuests_sels = AV91TFCueSts_Sels;
         pr_default.dynParam(1, new Object[]{ new Object[]{
                                              A873CueSts ,
                                              AV126Contabilidad_plancuentaswwds_29_tfcuests_sels ,
                                              AV98Contabilidad_plancuentaswwds_1_dynamicfiltersselector1 ,
                                              AV99Contabilidad_plancuentaswwds_2_dynamicfiltersoperator1 ,
                                              AV100Contabilidad_plancuentaswwds_3_cuecod1 ,
                                              AV101Contabilidad_plancuentaswwds_4_cuedsc1 ,
                                              AV103Contabilidad_plancuentaswwds_6_dynamicfiltersenabled2 ,
                                              AV104Contabilidad_plancuentaswwds_7_dynamicfiltersselector2 ,
                                              AV105Contabilidad_plancuentaswwds_8_dynamicfiltersoperator2 ,
                                              AV106Contabilidad_plancuentaswwds_9_cuecod2 ,
                                              AV107Contabilidad_plancuentaswwds_10_cuedsc2 ,
                                              AV109Contabilidad_plancuentaswwds_12_dynamicfiltersenabled3 ,
                                              AV110Contabilidad_plancuentaswwds_13_dynamicfiltersselector3 ,
                                              AV111Contabilidad_plancuentaswwds_14_dynamicfiltersoperator3 ,
                                              AV112Contabilidad_plancuentaswwds_15_cuecod3 ,
                                              AV113Contabilidad_plancuentaswwds_16_cuedsc3 ,
                                              AV116Contabilidad_plancuentaswwds_19_tfcuecod_sel ,
                                              AV115Contabilidad_plancuentaswwds_18_tfcuecod ,
                                              AV118Contabilidad_plancuentaswwds_21_tfcuedsc_sel ,
                                              AV117Contabilidad_plancuentaswwds_20_tfcuedsc ,
                                              AV119Contabilidad_plancuentaswwds_22_tfcuemov_sel ,
                                              AV120Contabilidad_plancuentaswwds_23_tfcuemon_sel ,
                                              AV121Contabilidad_plancuentaswwds_24_tfcuecos_sel ,
                                              AV123Contabilidad_plancuentaswwds_26_tfcuegasdebe_sel ,
                                              AV122Contabilidad_plancuentaswwds_25_tfcuegasdebe ,
                                              AV125Contabilidad_plancuentaswwds_28_tfcuegashaber_sel ,
                                              AV124Contabilidad_plancuentaswwds_27_tfcuegashaber ,
                                              AV126Contabilidad_plancuentaswwds_29_tfcuests_sels.Count ,
                                              A91CueCod ,
                                              A860CueDsc ,
                                              A867CueMov ,
                                              AV102Contabilidad_plancuentaswwds_5_cuemov1 ,
                                              AV108Contabilidad_plancuentaswwds_11_cuemov2 ,
                                              AV114Contabilidad_plancuentaswwds_17_cuemov3 ,
                                              A864CueMon ,
                                              A859CueCos ,
                                              A109CueGasDebe ,
                                              A110CueGasHaber ,
                                              AV13OrderedBy ,
                                              AV14OrderedDsc } ,
                                              new int[]{
                                              TypeConstants.SHORT, TypeConstants.SHORT, TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.SHORT, TypeConstants.SHORT, TypeConstants.SHORT, TypeConstants.INT,
                                              TypeConstants.SHORT, TypeConstants.SHORT, TypeConstants.SHORT, TypeConstants.SHORT, TypeConstants.SHORT, TypeConstants.SHORT, TypeConstants.BOOLEAN, TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.BOOLEAN
                                              }
         });
         lV100Contabilidad_plancuentaswwds_3_cuecod1 = StringUtil.PadR( StringUtil.RTrim( AV100Contabilidad_plancuentaswwds_3_cuecod1), 15, "%");
         lV100Contabilidad_plancuentaswwds_3_cuecod1 = StringUtil.PadR( StringUtil.RTrim( AV100Contabilidad_plancuentaswwds_3_cuecod1), 15, "%");
         lV101Contabilidad_plancuentaswwds_4_cuedsc1 = StringUtil.PadR( StringUtil.RTrim( AV101Contabilidad_plancuentaswwds_4_cuedsc1), 100, "%");
         lV101Contabilidad_plancuentaswwds_4_cuedsc1 = StringUtil.PadR( StringUtil.RTrim( AV101Contabilidad_plancuentaswwds_4_cuedsc1), 100, "%");
         lV106Contabilidad_plancuentaswwds_9_cuecod2 = StringUtil.PadR( StringUtil.RTrim( AV106Contabilidad_plancuentaswwds_9_cuecod2), 15, "%");
         lV106Contabilidad_plancuentaswwds_9_cuecod2 = StringUtil.PadR( StringUtil.RTrim( AV106Contabilidad_plancuentaswwds_9_cuecod2), 15, "%");
         lV107Contabilidad_plancuentaswwds_10_cuedsc2 = StringUtil.PadR( StringUtil.RTrim( AV107Contabilidad_plancuentaswwds_10_cuedsc2), 100, "%");
         lV107Contabilidad_plancuentaswwds_10_cuedsc2 = StringUtil.PadR( StringUtil.RTrim( AV107Contabilidad_plancuentaswwds_10_cuedsc2), 100, "%");
         lV112Contabilidad_plancuentaswwds_15_cuecod3 = StringUtil.PadR( StringUtil.RTrim( AV112Contabilidad_plancuentaswwds_15_cuecod3), 15, "%");
         lV112Contabilidad_plancuentaswwds_15_cuecod3 = StringUtil.PadR( StringUtil.RTrim( AV112Contabilidad_plancuentaswwds_15_cuecod3), 15, "%");
         lV113Contabilidad_plancuentaswwds_16_cuedsc3 = StringUtil.PadR( StringUtil.RTrim( AV113Contabilidad_plancuentaswwds_16_cuedsc3), 100, "%");
         lV113Contabilidad_plancuentaswwds_16_cuedsc3 = StringUtil.PadR( StringUtil.RTrim( AV113Contabilidad_plancuentaswwds_16_cuedsc3), 100, "%");
         lV115Contabilidad_plancuentaswwds_18_tfcuecod = StringUtil.PadR( StringUtil.RTrim( AV115Contabilidad_plancuentaswwds_18_tfcuecod), 15, "%");
         lV117Contabilidad_plancuentaswwds_20_tfcuedsc = StringUtil.PadR( StringUtil.RTrim( AV117Contabilidad_plancuentaswwds_20_tfcuedsc), 100, "%");
         lV122Contabilidad_plancuentaswwds_25_tfcuegasdebe = StringUtil.PadR( StringUtil.RTrim( AV122Contabilidad_plancuentaswwds_25_tfcuegasdebe), 15, "%");
         lV124Contabilidad_plancuentaswwds_27_tfcuegashaber = StringUtil.PadR( StringUtil.RTrim( AV124Contabilidad_plancuentaswwds_27_tfcuegashaber), 15, "%");
         /* Using cursor H00293 */
         pr_default.execute(1, new Object[] {lV100Contabilidad_plancuentaswwds_3_cuecod1, lV100Contabilidad_plancuentaswwds_3_cuecod1, lV101Contabilidad_plancuentaswwds_4_cuedsc1, lV101Contabilidad_plancuentaswwds_4_cuedsc1, AV102Contabilidad_plancuentaswwds_5_cuemov1, lV106Contabilidad_plancuentaswwds_9_cuecod2, lV106Contabilidad_plancuentaswwds_9_cuecod2, lV107Contabilidad_plancuentaswwds_10_cuedsc2, lV107Contabilidad_plancuentaswwds_10_cuedsc2, AV108Contabilidad_plancuentaswwds_11_cuemov2, lV112Contabilidad_plancuentaswwds_15_cuecod3, lV112Contabilidad_plancuentaswwds_15_cuecod3, lV113Contabilidad_plancuentaswwds_16_cuedsc3, lV113Contabilidad_plancuentaswwds_16_cuedsc3, AV114Contabilidad_plancuentaswwds_17_cuemov3, lV115Contabilidad_plancuentaswwds_18_tfcuecod, AV116Contabilidad_plancuentaswwds_19_tfcuecod_sel, lV117Contabilidad_plancuentaswwds_20_tfcuedsc, AV118Contabilidad_plancuentaswwds_21_tfcuedsc_sel, lV122Contabilidad_plancuentaswwds_25_tfcuegasdebe, AV123Contabilidad_plancuentaswwds_26_tfcuegasdebe_sel, lV124Contabilidad_plancuentaswwds_27_tfcuegashaber, AV125Contabilidad_plancuentaswwds_28_tfcuegashaber_sel});
         GRID_nRecordCount = H00293_AGRID_nRecordCount[0];
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
         AV98Contabilidad_plancuentaswwds_1_dynamicfiltersselector1 = AV15DynamicFiltersSelector1;
         AV99Contabilidad_plancuentaswwds_2_dynamicfiltersoperator1 = AV16DynamicFiltersOperator1;
         AV100Contabilidad_plancuentaswwds_3_cuecod1 = AV84CueCod1;
         AV101Contabilidad_plancuentaswwds_4_cuedsc1 = AV17CueDsc1;
         AV102Contabilidad_plancuentaswwds_5_cuemov1 = AV92CueMov1;
         AV103Contabilidad_plancuentaswwds_6_dynamicfiltersenabled2 = AV19DynamicFiltersEnabled2;
         AV104Contabilidad_plancuentaswwds_7_dynamicfiltersselector2 = AV20DynamicFiltersSelector2;
         AV105Contabilidad_plancuentaswwds_8_dynamicfiltersoperator2 = AV21DynamicFiltersOperator2;
         AV106Contabilidad_plancuentaswwds_9_cuecod2 = AV85CueCod2;
         AV107Contabilidad_plancuentaswwds_10_cuedsc2 = AV22CueDsc2;
         AV108Contabilidad_plancuentaswwds_11_cuemov2 = AV93CueMov2;
         AV109Contabilidad_plancuentaswwds_12_dynamicfiltersenabled3 = AV24DynamicFiltersEnabled3;
         AV110Contabilidad_plancuentaswwds_13_dynamicfiltersselector3 = AV25DynamicFiltersSelector3;
         AV111Contabilidad_plancuentaswwds_14_dynamicfiltersoperator3 = AV26DynamicFiltersOperator3;
         AV112Contabilidad_plancuentaswwds_15_cuecod3 = AV86CueCod3;
         AV113Contabilidad_plancuentaswwds_16_cuedsc3 = AV27CueDsc3;
         AV114Contabilidad_plancuentaswwds_17_cuemov3 = AV94CueMov3;
         AV115Contabilidad_plancuentaswwds_18_tfcuecod = AV34TFCueCod;
         AV116Contabilidad_plancuentaswwds_19_tfcuecod_sel = AV35TFCueCod_Sel;
         AV117Contabilidad_plancuentaswwds_20_tfcuedsc = AV36TFCueDsc;
         AV118Contabilidad_plancuentaswwds_21_tfcuedsc_sel = AV37TFCueDsc_Sel;
         AV119Contabilidad_plancuentaswwds_22_tfcuemov_sel = AV87TFCueMov_Sel;
         AV120Contabilidad_plancuentaswwds_23_tfcuemon_sel = AV88TFCueMon_Sel;
         AV121Contabilidad_plancuentaswwds_24_tfcuecos_sel = AV89TFCueCos_Sel;
         AV122Contabilidad_plancuentaswwds_25_tfcuegasdebe = AV48TFCueGasDebe;
         AV123Contabilidad_plancuentaswwds_26_tfcuegasdebe_sel = AV49TFCueGasDebe_Sel;
         AV124Contabilidad_plancuentaswwds_27_tfcuegashaber = AV50TFCueGasHaber;
         AV125Contabilidad_plancuentaswwds_28_tfcuegashaber_sel = AV51TFCueGasHaber_Sel;
         AV126Contabilidad_plancuentaswwds_29_tfcuests_sels = AV91TFCueSts_Sels;
         GRID_nFirstRecordOnPage = 0;
         GxWebStd.gx_hidden_field( context, "GRID_nFirstRecordOnPage", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRID_nFirstRecordOnPage), 15, 0, ".", "")));
         if ( isFullAjaxMode( ) )
         {
            gxgrGrid_refresh( subGrid_Rows, AV15DynamicFiltersSelector1, AV16DynamicFiltersOperator1, AV84CueCod1, AV17CueDsc1, AV92CueMov1, AV20DynamicFiltersSelector2, AV21DynamicFiltersOperator2, AV85CueCod2, AV22CueDsc2, AV93CueMov2, AV25DynamicFiltersSelector3, AV26DynamicFiltersOperator3, AV86CueCod3, AV27CueDsc3, AV94CueMov3, AV19DynamicFiltersEnabled2, AV24DynamicFiltersEnabled3, AV97Pgmname, AV34TFCueCod, AV35TFCueCod_Sel, AV36TFCueDsc, AV37TFCueDsc_Sel, AV87TFCueMov_Sel, AV88TFCueMon_Sel, AV89TFCueCos_Sel, AV48TFCueGasDebe, AV49TFCueGasDebe_Sel, AV50TFCueGasHaber, AV51TFCueGasHaber_Sel, AV91TFCueSts_Sels, AV13OrderedBy, AV14OrderedDsc, AV10GridState, AV30DynamicFiltersIgnoreFirst, AV29DynamicFiltersRemoving) ;
         }
         send_integrity_footer_hashes( ) ;
         return 0 ;
      }

      protected short subgrid_nextpage( )
      {
         AV98Contabilidad_plancuentaswwds_1_dynamicfiltersselector1 = AV15DynamicFiltersSelector1;
         AV99Contabilidad_plancuentaswwds_2_dynamicfiltersoperator1 = AV16DynamicFiltersOperator1;
         AV100Contabilidad_plancuentaswwds_3_cuecod1 = AV84CueCod1;
         AV101Contabilidad_plancuentaswwds_4_cuedsc1 = AV17CueDsc1;
         AV102Contabilidad_plancuentaswwds_5_cuemov1 = AV92CueMov1;
         AV103Contabilidad_plancuentaswwds_6_dynamicfiltersenabled2 = AV19DynamicFiltersEnabled2;
         AV104Contabilidad_plancuentaswwds_7_dynamicfiltersselector2 = AV20DynamicFiltersSelector2;
         AV105Contabilidad_plancuentaswwds_8_dynamicfiltersoperator2 = AV21DynamicFiltersOperator2;
         AV106Contabilidad_plancuentaswwds_9_cuecod2 = AV85CueCod2;
         AV107Contabilidad_plancuentaswwds_10_cuedsc2 = AV22CueDsc2;
         AV108Contabilidad_plancuentaswwds_11_cuemov2 = AV93CueMov2;
         AV109Contabilidad_plancuentaswwds_12_dynamicfiltersenabled3 = AV24DynamicFiltersEnabled3;
         AV110Contabilidad_plancuentaswwds_13_dynamicfiltersselector3 = AV25DynamicFiltersSelector3;
         AV111Contabilidad_plancuentaswwds_14_dynamicfiltersoperator3 = AV26DynamicFiltersOperator3;
         AV112Contabilidad_plancuentaswwds_15_cuecod3 = AV86CueCod3;
         AV113Contabilidad_plancuentaswwds_16_cuedsc3 = AV27CueDsc3;
         AV114Contabilidad_plancuentaswwds_17_cuemov3 = AV94CueMov3;
         AV115Contabilidad_plancuentaswwds_18_tfcuecod = AV34TFCueCod;
         AV116Contabilidad_plancuentaswwds_19_tfcuecod_sel = AV35TFCueCod_Sel;
         AV117Contabilidad_plancuentaswwds_20_tfcuedsc = AV36TFCueDsc;
         AV118Contabilidad_plancuentaswwds_21_tfcuedsc_sel = AV37TFCueDsc_Sel;
         AV119Contabilidad_plancuentaswwds_22_tfcuemov_sel = AV87TFCueMov_Sel;
         AV120Contabilidad_plancuentaswwds_23_tfcuemon_sel = AV88TFCueMon_Sel;
         AV121Contabilidad_plancuentaswwds_24_tfcuecos_sel = AV89TFCueCos_Sel;
         AV122Contabilidad_plancuentaswwds_25_tfcuegasdebe = AV48TFCueGasDebe;
         AV123Contabilidad_plancuentaswwds_26_tfcuegasdebe_sel = AV49TFCueGasDebe_Sel;
         AV124Contabilidad_plancuentaswwds_27_tfcuegashaber = AV50TFCueGasHaber;
         AV125Contabilidad_plancuentaswwds_28_tfcuegashaber_sel = AV51TFCueGasHaber_Sel;
         AV126Contabilidad_plancuentaswwds_29_tfcuests_sels = AV91TFCueSts_Sels;
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
            gxgrGrid_refresh( subGrid_Rows, AV15DynamicFiltersSelector1, AV16DynamicFiltersOperator1, AV84CueCod1, AV17CueDsc1, AV92CueMov1, AV20DynamicFiltersSelector2, AV21DynamicFiltersOperator2, AV85CueCod2, AV22CueDsc2, AV93CueMov2, AV25DynamicFiltersSelector3, AV26DynamicFiltersOperator3, AV86CueCod3, AV27CueDsc3, AV94CueMov3, AV19DynamicFiltersEnabled2, AV24DynamicFiltersEnabled3, AV97Pgmname, AV34TFCueCod, AV35TFCueCod_Sel, AV36TFCueDsc, AV37TFCueDsc_Sel, AV87TFCueMov_Sel, AV88TFCueMon_Sel, AV89TFCueCos_Sel, AV48TFCueGasDebe, AV49TFCueGasDebe_Sel, AV50TFCueGasHaber, AV51TFCueGasHaber_Sel, AV91TFCueSts_Sels, AV13OrderedBy, AV14OrderedDsc, AV10GridState, AV30DynamicFiltersIgnoreFirst, AV29DynamicFiltersRemoving) ;
         }
         send_integrity_footer_hashes( ) ;
         return (short)(((GRID_nEOF==0) ? 0 : 2)) ;
      }

      protected short subgrid_previouspage( )
      {
         AV98Contabilidad_plancuentaswwds_1_dynamicfiltersselector1 = AV15DynamicFiltersSelector1;
         AV99Contabilidad_plancuentaswwds_2_dynamicfiltersoperator1 = AV16DynamicFiltersOperator1;
         AV100Contabilidad_plancuentaswwds_3_cuecod1 = AV84CueCod1;
         AV101Contabilidad_plancuentaswwds_4_cuedsc1 = AV17CueDsc1;
         AV102Contabilidad_plancuentaswwds_5_cuemov1 = AV92CueMov1;
         AV103Contabilidad_plancuentaswwds_6_dynamicfiltersenabled2 = AV19DynamicFiltersEnabled2;
         AV104Contabilidad_plancuentaswwds_7_dynamicfiltersselector2 = AV20DynamicFiltersSelector2;
         AV105Contabilidad_plancuentaswwds_8_dynamicfiltersoperator2 = AV21DynamicFiltersOperator2;
         AV106Contabilidad_plancuentaswwds_9_cuecod2 = AV85CueCod2;
         AV107Contabilidad_plancuentaswwds_10_cuedsc2 = AV22CueDsc2;
         AV108Contabilidad_plancuentaswwds_11_cuemov2 = AV93CueMov2;
         AV109Contabilidad_plancuentaswwds_12_dynamicfiltersenabled3 = AV24DynamicFiltersEnabled3;
         AV110Contabilidad_plancuentaswwds_13_dynamicfiltersselector3 = AV25DynamicFiltersSelector3;
         AV111Contabilidad_plancuentaswwds_14_dynamicfiltersoperator3 = AV26DynamicFiltersOperator3;
         AV112Contabilidad_plancuentaswwds_15_cuecod3 = AV86CueCod3;
         AV113Contabilidad_plancuentaswwds_16_cuedsc3 = AV27CueDsc3;
         AV114Contabilidad_plancuentaswwds_17_cuemov3 = AV94CueMov3;
         AV115Contabilidad_plancuentaswwds_18_tfcuecod = AV34TFCueCod;
         AV116Contabilidad_plancuentaswwds_19_tfcuecod_sel = AV35TFCueCod_Sel;
         AV117Contabilidad_plancuentaswwds_20_tfcuedsc = AV36TFCueDsc;
         AV118Contabilidad_plancuentaswwds_21_tfcuedsc_sel = AV37TFCueDsc_Sel;
         AV119Contabilidad_plancuentaswwds_22_tfcuemov_sel = AV87TFCueMov_Sel;
         AV120Contabilidad_plancuentaswwds_23_tfcuemon_sel = AV88TFCueMon_Sel;
         AV121Contabilidad_plancuentaswwds_24_tfcuecos_sel = AV89TFCueCos_Sel;
         AV122Contabilidad_plancuentaswwds_25_tfcuegasdebe = AV48TFCueGasDebe;
         AV123Contabilidad_plancuentaswwds_26_tfcuegasdebe_sel = AV49TFCueGasDebe_Sel;
         AV124Contabilidad_plancuentaswwds_27_tfcuegashaber = AV50TFCueGasHaber;
         AV125Contabilidad_plancuentaswwds_28_tfcuegashaber_sel = AV51TFCueGasHaber_Sel;
         AV126Contabilidad_plancuentaswwds_29_tfcuests_sels = AV91TFCueSts_Sels;
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
            gxgrGrid_refresh( subGrid_Rows, AV15DynamicFiltersSelector1, AV16DynamicFiltersOperator1, AV84CueCod1, AV17CueDsc1, AV92CueMov1, AV20DynamicFiltersSelector2, AV21DynamicFiltersOperator2, AV85CueCod2, AV22CueDsc2, AV93CueMov2, AV25DynamicFiltersSelector3, AV26DynamicFiltersOperator3, AV86CueCod3, AV27CueDsc3, AV94CueMov3, AV19DynamicFiltersEnabled2, AV24DynamicFiltersEnabled3, AV97Pgmname, AV34TFCueCod, AV35TFCueCod_Sel, AV36TFCueDsc, AV37TFCueDsc_Sel, AV87TFCueMov_Sel, AV88TFCueMon_Sel, AV89TFCueCos_Sel, AV48TFCueGasDebe, AV49TFCueGasDebe_Sel, AV50TFCueGasHaber, AV51TFCueGasHaber_Sel, AV91TFCueSts_Sels, AV13OrderedBy, AV14OrderedDsc, AV10GridState, AV30DynamicFiltersIgnoreFirst, AV29DynamicFiltersRemoving) ;
         }
         send_integrity_footer_hashes( ) ;
         return 0 ;
      }

      protected short subgrid_lastpage( )
      {
         AV98Contabilidad_plancuentaswwds_1_dynamicfiltersselector1 = AV15DynamicFiltersSelector1;
         AV99Contabilidad_plancuentaswwds_2_dynamicfiltersoperator1 = AV16DynamicFiltersOperator1;
         AV100Contabilidad_plancuentaswwds_3_cuecod1 = AV84CueCod1;
         AV101Contabilidad_plancuentaswwds_4_cuedsc1 = AV17CueDsc1;
         AV102Contabilidad_plancuentaswwds_5_cuemov1 = AV92CueMov1;
         AV103Contabilidad_plancuentaswwds_6_dynamicfiltersenabled2 = AV19DynamicFiltersEnabled2;
         AV104Contabilidad_plancuentaswwds_7_dynamicfiltersselector2 = AV20DynamicFiltersSelector2;
         AV105Contabilidad_plancuentaswwds_8_dynamicfiltersoperator2 = AV21DynamicFiltersOperator2;
         AV106Contabilidad_plancuentaswwds_9_cuecod2 = AV85CueCod2;
         AV107Contabilidad_plancuentaswwds_10_cuedsc2 = AV22CueDsc2;
         AV108Contabilidad_plancuentaswwds_11_cuemov2 = AV93CueMov2;
         AV109Contabilidad_plancuentaswwds_12_dynamicfiltersenabled3 = AV24DynamicFiltersEnabled3;
         AV110Contabilidad_plancuentaswwds_13_dynamicfiltersselector3 = AV25DynamicFiltersSelector3;
         AV111Contabilidad_plancuentaswwds_14_dynamicfiltersoperator3 = AV26DynamicFiltersOperator3;
         AV112Contabilidad_plancuentaswwds_15_cuecod3 = AV86CueCod3;
         AV113Contabilidad_plancuentaswwds_16_cuedsc3 = AV27CueDsc3;
         AV114Contabilidad_plancuentaswwds_17_cuemov3 = AV94CueMov3;
         AV115Contabilidad_plancuentaswwds_18_tfcuecod = AV34TFCueCod;
         AV116Contabilidad_plancuentaswwds_19_tfcuecod_sel = AV35TFCueCod_Sel;
         AV117Contabilidad_plancuentaswwds_20_tfcuedsc = AV36TFCueDsc;
         AV118Contabilidad_plancuentaswwds_21_tfcuedsc_sel = AV37TFCueDsc_Sel;
         AV119Contabilidad_plancuentaswwds_22_tfcuemov_sel = AV87TFCueMov_Sel;
         AV120Contabilidad_plancuentaswwds_23_tfcuemon_sel = AV88TFCueMon_Sel;
         AV121Contabilidad_plancuentaswwds_24_tfcuecos_sel = AV89TFCueCos_Sel;
         AV122Contabilidad_plancuentaswwds_25_tfcuegasdebe = AV48TFCueGasDebe;
         AV123Contabilidad_plancuentaswwds_26_tfcuegasdebe_sel = AV49TFCueGasDebe_Sel;
         AV124Contabilidad_plancuentaswwds_27_tfcuegashaber = AV50TFCueGasHaber;
         AV125Contabilidad_plancuentaswwds_28_tfcuegashaber_sel = AV51TFCueGasHaber_Sel;
         AV126Contabilidad_plancuentaswwds_29_tfcuests_sels = AV91TFCueSts_Sels;
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
            gxgrGrid_refresh( subGrid_Rows, AV15DynamicFiltersSelector1, AV16DynamicFiltersOperator1, AV84CueCod1, AV17CueDsc1, AV92CueMov1, AV20DynamicFiltersSelector2, AV21DynamicFiltersOperator2, AV85CueCod2, AV22CueDsc2, AV93CueMov2, AV25DynamicFiltersSelector3, AV26DynamicFiltersOperator3, AV86CueCod3, AV27CueDsc3, AV94CueMov3, AV19DynamicFiltersEnabled2, AV24DynamicFiltersEnabled3, AV97Pgmname, AV34TFCueCod, AV35TFCueCod_Sel, AV36TFCueDsc, AV37TFCueDsc_Sel, AV87TFCueMov_Sel, AV88TFCueMon_Sel, AV89TFCueCos_Sel, AV48TFCueGasDebe, AV49TFCueGasDebe_Sel, AV50TFCueGasHaber, AV51TFCueGasHaber_Sel, AV91TFCueSts_Sels, AV13OrderedBy, AV14OrderedDsc, AV10GridState, AV30DynamicFiltersIgnoreFirst, AV29DynamicFiltersRemoving) ;
         }
         send_integrity_footer_hashes( ) ;
         return 0 ;
      }

      protected int subgrid_gotopage( int nPageNo )
      {
         AV98Contabilidad_plancuentaswwds_1_dynamicfiltersselector1 = AV15DynamicFiltersSelector1;
         AV99Contabilidad_plancuentaswwds_2_dynamicfiltersoperator1 = AV16DynamicFiltersOperator1;
         AV100Contabilidad_plancuentaswwds_3_cuecod1 = AV84CueCod1;
         AV101Contabilidad_plancuentaswwds_4_cuedsc1 = AV17CueDsc1;
         AV102Contabilidad_plancuentaswwds_5_cuemov1 = AV92CueMov1;
         AV103Contabilidad_plancuentaswwds_6_dynamicfiltersenabled2 = AV19DynamicFiltersEnabled2;
         AV104Contabilidad_plancuentaswwds_7_dynamicfiltersselector2 = AV20DynamicFiltersSelector2;
         AV105Contabilidad_plancuentaswwds_8_dynamicfiltersoperator2 = AV21DynamicFiltersOperator2;
         AV106Contabilidad_plancuentaswwds_9_cuecod2 = AV85CueCod2;
         AV107Contabilidad_plancuentaswwds_10_cuedsc2 = AV22CueDsc2;
         AV108Contabilidad_plancuentaswwds_11_cuemov2 = AV93CueMov2;
         AV109Contabilidad_plancuentaswwds_12_dynamicfiltersenabled3 = AV24DynamicFiltersEnabled3;
         AV110Contabilidad_plancuentaswwds_13_dynamicfiltersselector3 = AV25DynamicFiltersSelector3;
         AV111Contabilidad_plancuentaswwds_14_dynamicfiltersoperator3 = AV26DynamicFiltersOperator3;
         AV112Contabilidad_plancuentaswwds_15_cuecod3 = AV86CueCod3;
         AV113Contabilidad_plancuentaswwds_16_cuedsc3 = AV27CueDsc3;
         AV114Contabilidad_plancuentaswwds_17_cuemov3 = AV94CueMov3;
         AV115Contabilidad_plancuentaswwds_18_tfcuecod = AV34TFCueCod;
         AV116Contabilidad_plancuentaswwds_19_tfcuecod_sel = AV35TFCueCod_Sel;
         AV117Contabilidad_plancuentaswwds_20_tfcuedsc = AV36TFCueDsc;
         AV118Contabilidad_plancuentaswwds_21_tfcuedsc_sel = AV37TFCueDsc_Sel;
         AV119Contabilidad_plancuentaswwds_22_tfcuemov_sel = AV87TFCueMov_Sel;
         AV120Contabilidad_plancuentaswwds_23_tfcuemon_sel = AV88TFCueMon_Sel;
         AV121Contabilidad_plancuentaswwds_24_tfcuecos_sel = AV89TFCueCos_Sel;
         AV122Contabilidad_plancuentaswwds_25_tfcuegasdebe = AV48TFCueGasDebe;
         AV123Contabilidad_plancuentaswwds_26_tfcuegasdebe_sel = AV49TFCueGasDebe_Sel;
         AV124Contabilidad_plancuentaswwds_27_tfcuegashaber = AV50TFCueGasHaber;
         AV125Contabilidad_plancuentaswwds_28_tfcuegashaber_sel = AV51TFCueGasHaber_Sel;
         AV126Contabilidad_plancuentaswwds_29_tfcuests_sels = AV91TFCueSts_Sels;
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
            gxgrGrid_refresh( subGrid_Rows, AV15DynamicFiltersSelector1, AV16DynamicFiltersOperator1, AV84CueCod1, AV17CueDsc1, AV92CueMov1, AV20DynamicFiltersSelector2, AV21DynamicFiltersOperator2, AV85CueCod2, AV22CueDsc2, AV93CueMov2, AV25DynamicFiltersSelector3, AV26DynamicFiltersOperator3, AV86CueCod3, AV27CueDsc3, AV94CueMov3, AV19DynamicFiltersEnabled2, AV24DynamicFiltersEnabled3, AV97Pgmname, AV34TFCueCod, AV35TFCueCod_Sel, AV36TFCueDsc, AV37TFCueDsc_Sel, AV87TFCueMov_Sel, AV88TFCueMon_Sel, AV89TFCueCos_Sel, AV48TFCueGasDebe, AV49TFCueGasDebe_Sel, AV50TFCueGasHaber, AV51TFCueGasHaber_Sel, AV91TFCueSts_Sels, AV13OrderedBy, AV14OrderedDsc, AV10GridState, AV30DynamicFiltersIgnoreFirst, AV29DynamicFiltersRemoving) ;
         }
         send_integrity_footer_hashes( ) ;
         return (int)(0) ;
      }

      protected void before_start_formulas( )
      {
         AV97Pgmname = "Contabilidad.PlanCuentasWW";
         context.Gx_err = 0;
         fix_multi_value_controls( ) ;
      }

      protected void STRUP290( )
      {
         /* Before Start, stand alone formulas. */
         before_start_formulas( ) ;
         /* Execute Start event if defined. */
         context.wbGlbDoneStart = 0;
         /* Execute user event: Start */
         E24292 ();
         context.wbGlbDoneStart = 1;
         /* After Start, stand alone formulas. */
         if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
         {
            /* Read saved SDTs. */
            ajax_req_read_hidden_sdt(cgiGet( "vAGEXPORTDATA"), AV82AGExportData);
            ajax_req_read_hidden_sdt(cgiGet( "vDDO_TITLESETTINGSICONS"), AV76DDO_TitleSettingsIcons);
            /* Read saved values. */
            nRC_GXsfl_119 = (int)(context.localUtil.CToN( cgiGet( "nRC_GXsfl_119"), ".", ","));
            AV78GridCurrentPage = (long)(context.localUtil.CToN( cgiGet( "vGRIDCURRENTPAGE"), ".", ","));
            AV79GridPageCount = (long)(context.localUtil.CToN( cgiGet( "vGRIDPAGECOUNT"), ".", ","));
            AV80GridAppliedFilters = cgiGet( "vGRIDAPPLIEDFILTERS");
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
            AV84CueCod1 = cgiGet( edtavCuecod1_Internalname);
            AssignAttri("", false, "AV84CueCod1", AV84CueCod1);
            AV17CueDsc1 = cgiGet( edtavCuedsc1_Internalname);
            AssignAttri("", false, "AV17CueDsc1", AV17CueDsc1);
            cmbavCuemov1.Name = cmbavCuemov1_Internalname;
            cmbavCuemov1.CurrentValue = cgiGet( cmbavCuemov1_Internalname);
            AV92CueMov1 = (short)(NumberUtil.Val( cgiGet( cmbavCuemov1_Internalname), "."));
            AssignAttri("", false, "AV92CueMov1", StringUtil.Str( (decimal)(AV92CueMov1), 1, 0));
            cmbavDynamicfiltersselector2.Name = cmbavDynamicfiltersselector2_Internalname;
            cmbavDynamicfiltersselector2.CurrentValue = cgiGet( cmbavDynamicfiltersselector2_Internalname);
            AV20DynamicFiltersSelector2 = cgiGet( cmbavDynamicfiltersselector2_Internalname);
            AssignAttri("", false, "AV20DynamicFiltersSelector2", AV20DynamicFiltersSelector2);
            cmbavDynamicfiltersoperator2.Name = cmbavDynamicfiltersoperator2_Internalname;
            cmbavDynamicfiltersoperator2.CurrentValue = cgiGet( cmbavDynamicfiltersoperator2_Internalname);
            AV21DynamicFiltersOperator2 = (short)(NumberUtil.Val( cgiGet( cmbavDynamicfiltersoperator2_Internalname), "."));
            AssignAttri("", false, "AV21DynamicFiltersOperator2", StringUtil.LTrimStr( (decimal)(AV21DynamicFiltersOperator2), 4, 0));
            AV85CueCod2 = cgiGet( edtavCuecod2_Internalname);
            AssignAttri("", false, "AV85CueCod2", AV85CueCod2);
            AV22CueDsc2 = cgiGet( edtavCuedsc2_Internalname);
            AssignAttri("", false, "AV22CueDsc2", AV22CueDsc2);
            cmbavCuemov2.Name = cmbavCuemov2_Internalname;
            cmbavCuemov2.CurrentValue = cgiGet( cmbavCuemov2_Internalname);
            AV93CueMov2 = (short)(NumberUtil.Val( cgiGet( cmbavCuemov2_Internalname), "."));
            AssignAttri("", false, "AV93CueMov2", StringUtil.Str( (decimal)(AV93CueMov2), 1, 0));
            cmbavDynamicfiltersselector3.Name = cmbavDynamicfiltersselector3_Internalname;
            cmbavDynamicfiltersselector3.CurrentValue = cgiGet( cmbavDynamicfiltersselector3_Internalname);
            AV25DynamicFiltersSelector3 = cgiGet( cmbavDynamicfiltersselector3_Internalname);
            AssignAttri("", false, "AV25DynamicFiltersSelector3", AV25DynamicFiltersSelector3);
            cmbavDynamicfiltersoperator3.Name = cmbavDynamicfiltersoperator3_Internalname;
            cmbavDynamicfiltersoperator3.CurrentValue = cgiGet( cmbavDynamicfiltersoperator3_Internalname);
            AV26DynamicFiltersOperator3 = (short)(NumberUtil.Val( cgiGet( cmbavDynamicfiltersoperator3_Internalname), "."));
            AssignAttri("", false, "AV26DynamicFiltersOperator3", StringUtil.LTrimStr( (decimal)(AV26DynamicFiltersOperator3), 4, 0));
            AV86CueCod3 = cgiGet( edtavCuecod3_Internalname);
            AssignAttri("", false, "AV86CueCod3", AV86CueCod3);
            AV27CueDsc3 = cgiGet( edtavCuedsc3_Internalname);
            AssignAttri("", false, "AV27CueDsc3", AV27CueDsc3);
            cmbavCuemov3.Name = cmbavCuemov3_Internalname;
            cmbavCuemov3.CurrentValue = cgiGet( cmbavCuemov3_Internalname);
            AV94CueMov3 = (short)(NumberUtil.Val( cgiGet( cmbavCuemov3_Internalname), "."));
            AssignAttri("", false, "AV94CueMov3", StringUtil.Str( (decimal)(AV94CueMov3), 1, 0));
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
            if ( StringUtil.StrCmp(cgiGet( "GXH_vCUECOD1"), AV84CueCod1) != 0 )
            {
               GRID_nFirstRecordOnPage = 0;
            }
            if ( StringUtil.StrCmp(cgiGet( "GXH_vCUEDSC1"), AV17CueDsc1) != 0 )
            {
               GRID_nFirstRecordOnPage = 0;
            }
            if ( ( context.localUtil.CToN( cgiGet( "GXH_vCUEMOV1"), ".", ",") != Convert.ToDecimal( AV92CueMov1 )) )
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
            if ( StringUtil.StrCmp(cgiGet( "GXH_vCUECOD2"), AV85CueCod2) != 0 )
            {
               GRID_nFirstRecordOnPage = 0;
            }
            if ( StringUtil.StrCmp(cgiGet( "GXH_vCUEDSC2"), AV22CueDsc2) != 0 )
            {
               GRID_nFirstRecordOnPage = 0;
            }
            if ( ( context.localUtil.CToN( cgiGet( "GXH_vCUEMOV2"), ".", ",") != Convert.ToDecimal( AV93CueMov2 )) )
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
            if ( StringUtil.StrCmp(cgiGet( "GXH_vCUECOD3"), AV86CueCod3) != 0 )
            {
               GRID_nFirstRecordOnPage = 0;
            }
            if ( StringUtil.StrCmp(cgiGet( "GXH_vCUEDSC3"), AV27CueDsc3) != 0 )
            {
               GRID_nFirstRecordOnPage = 0;
            }
            if ( ( context.localUtil.CToN( cgiGet( "GXH_vCUEMOV3"), ".", ",") != Convert.ToDecimal( AV94CueMov3 )) )
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
         E24292 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
      }

      protected void E24292( )
      {
         /* Start Routine */
         returnInSub = false;
         subGrid_Rows = 10;
         GxWebStd.gx_hidden_field( context, "GRID_Rows", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid_Rows), 6, 0, ".", "")));
         Grid_empowerer_Gridinternalname = subGrid_Internalname;
         ucGrid_empowerer.SendProperty(context, "", false, Grid_empowerer_Internalname, "GridInternalName", Grid_empowerer_Gridinternalname);
         lblJsdynamicfilters_Caption = "";
         AssignProp("", false, lblJsdynamicfilters_Internalname, "Caption", lblJsdynamicfilters_Caption, true);
         AV15DynamicFiltersSelector1 = "CUECOD";
         AssignAttri("", false, "AV15DynamicFiltersSelector1", AV15DynamicFiltersSelector1);
         /* Execute user subroutine: 'ENABLEDYNAMICFILTERS1' */
         S112 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
         AV20DynamicFiltersSelector2 = "CUECOD";
         AssignAttri("", false, "AV20DynamicFiltersSelector2", AV20DynamicFiltersSelector2);
         /* Execute user subroutine: 'ENABLEDYNAMICFILTERS2' */
         S122 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
         AV25DynamicFiltersSelector3 = "CUECOD";
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
         AV82AGExportData = new GXBaseCollection<GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTDropDownOptionsData_Item>( context, "Item", "");
         AV83AGExportDataItem = new GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTDropDownOptionsData_Item(context);
         AV83AGExportDataItem.gxTpr_Title = "PDF";
         AV83AGExportDataItem.gxTpr_Icon = context.convertURL( (string)(context.GetImagePath( "776fb79c-a0a1-4302-b5e5-d773dbe1a297", "", context.GetTheme( ))));
         AV83AGExportDataItem.gxTpr_Eventkey = "ExportReport";
         AV83AGExportDataItem.gxTpr_Isdivider = false;
         AV82AGExportData.Add(AV83AGExportDataItem, 0);
         AV83AGExportDataItem = new GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTDropDownOptionsData_Item(context);
         AV83AGExportDataItem.gxTpr_Title = "Excel";
         AV83AGExportDataItem.gxTpr_Icon = context.convertURL( (string)(context.GetImagePath( "da69a816-fd11-445b-8aaf-1a2f7f1acc93", "", context.GetTheme( ))));
         AV83AGExportDataItem.gxTpr_Eventkey = "Export";
         AV83AGExportDataItem.gxTpr_Isdivider = false;
         AV82AGExportData.Add(AV83AGExportDataItem, 0);
         Ddo_grid_Gridinternalname = subGrid_Internalname;
         ucDdo_grid.SendProperty(context, "", false, Ddo_grid_Internalname, "GridInternalName", Ddo_grid_Gridinternalname);
         Form.Caption = " Plan de Cuentas";
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
         GXt_SdtDVB_SDTDropDownOptionsTitleSettingsIcons1 = AV76DDO_TitleSettingsIcons;
         new GeneXus.Programs.wwpbaseobjects.getwwptitlesettingsicons(context ).execute( out  GXt_SdtDVB_SDTDropDownOptionsTitleSettingsIcons1) ;
         AV76DDO_TitleSettingsIcons = GXt_SdtDVB_SDTDropDownOptionsTitleSettingsIcons1;
         Gridpaginationbar_Rowsperpageselectedvalue = subGrid_Rows;
         ucGridpaginationbar.SendProperty(context, "", false, Gridpaginationbar_Internalname, "RowsPerPageSelectedValue", StringUtil.LTrimStr( (decimal)(Gridpaginationbar_Rowsperpageselectedvalue), 9, 0));
      }

      protected void E25292( )
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
         if ( StringUtil.StrCmp(AV15DynamicFiltersSelector1, "CUECOD") == 0 )
         {
            cmbavDynamicfiltersoperator1.addItem("0", "Comienza con", 0);
            cmbavDynamicfiltersoperator1.addItem("1", "Contiene", 0);
         }
         else if ( StringUtil.StrCmp(AV15DynamicFiltersSelector1, "CUEDSC") == 0 )
         {
            cmbavDynamicfiltersoperator1.addItem("0", "Comienza con", 0);
            cmbavDynamicfiltersoperator1.addItem("1", "Contiene", 0);
         }
         if ( AV19DynamicFiltersEnabled2 )
         {
            cmbavDynamicfiltersoperator2.removeAllItems();
            if ( StringUtil.StrCmp(AV20DynamicFiltersSelector2, "CUECOD") == 0 )
            {
               cmbavDynamicfiltersoperator2.addItem("0", "Comienza con", 0);
               cmbavDynamicfiltersoperator2.addItem("1", "Contiene", 0);
            }
            else if ( StringUtil.StrCmp(AV20DynamicFiltersSelector2, "CUEDSC") == 0 )
            {
               cmbavDynamicfiltersoperator2.addItem("0", "Comienza con", 0);
               cmbavDynamicfiltersoperator2.addItem("1", "Contiene", 0);
            }
            if ( AV24DynamicFiltersEnabled3 )
            {
               cmbavDynamicfiltersoperator3.removeAllItems();
               if ( StringUtil.StrCmp(AV25DynamicFiltersSelector3, "CUECOD") == 0 )
               {
                  cmbavDynamicfiltersoperator3.addItem("0", "Comienza con", 0);
                  cmbavDynamicfiltersoperator3.addItem("1", "Contiene", 0);
               }
               else if ( StringUtil.StrCmp(AV25DynamicFiltersSelector3, "CUEDSC") == 0 )
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
         AV78GridCurrentPage = subGrid_fnc_Currentpage( );
         AssignAttri("", false, "AV78GridCurrentPage", StringUtil.LTrimStr( (decimal)(AV78GridCurrentPage), 10, 0));
         AV79GridPageCount = subGrid_fnc_Pagecount( );
         AssignAttri("", false, "AV79GridPageCount", StringUtil.LTrimStr( (decimal)(AV79GridPageCount), 10, 0));
         GXt_char2 = AV80GridAppliedFilters;
         new GeneXus.Programs.wwpbaseobjects.wwp_getappliedfiltersdescription(context ).execute(  AV97Pgmname, out  GXt_char2) ;
         AV80GridAppliedFilters = GXt_char2;
         AssignAttri("", false, "AV80GridAppliedFilters", AV80GridAppliedFilters);
         AV98Contabilidad_plancuentaswwds_1_dynamicfiltersselector1 = AV15DynamicFiltersSelector1;
         AV99Contabilidad_plancuentaswwds_2_dynamicfiltersoperator1 = AV16DynamicFiltersOperator1;
         AV100Contabilidad_plancuentaswwds_3_cuecod1 = AV84CueCod1;
         AV101Contabilidad_plancuentaswwds_4_cuedsc1 = AV17CueDsc1;
         AV102Contabilidad_plancuentaswwds_5_cuemov1 = AV92CueMov1;
         AV103Contabilidad_plancuentaswwds_6_dynamicfiltersenabled2 = AV19DynamicFiltersEnabled2;
         AV104Contabilidad_plancuentaswwds_7_dynamicfiltersselector2 = AV20DynamicFiltersSelector2;
         AV105Contabilidad_plancuentaswwds_8_dynamicfiltersoperator2 = AV21DynamicFiltersOperator2;
         AV106Contabilidad_plancuentaswwds_9_cuecod2 = AV85CueCod2;
         AV107Contabilidad_plancuentaswwds_10_cuedsc2 = AV22CueDsc2;
         AV108Contabilidad_plancuentaswwds_11_cuemov2 = AV93CueMov2;
         AV109Contabilidad_plancuentaswwds_12_dynamicfiltersenabled3 = AV24DynamicFiltersEnabled3;
         AV110Contabilidad_plancuentaswwds_13_dynamicfiltersselector3 = AV25DynamicFiltersSelector3;
         AV111Contabilidad_plancuentaswwds_14_dynamicfiltersoperator3 = AV26DynamicFiltersOperator3;
         AV112Contabilidad_plancuentaswwds_15_cuecod3 = AV86CueCod3;
         AV113Contabilidad_plancuentaswwds_16_cuedsc3 = AV27CueDsc3;
         AV114Contabilidad_plancuentaswwds_17_cuemov3 = AV94CueMov3;
         AV115Contabilidad_plancuentaswwds_18_tfcuecod = AV34TFCueCod;
         AV116Contabilidad_plancuentaswwds_19_tfcuecod_sel = AV35TFCueCod_Sel;
         AV117Contabilidad_plancuentaswwds_20_tfcuedsc = AV36TFCueDsc;
         AV118Contabilidad_plancuentaswwds_21_tfcuedsc_sel = AV37TFCueDsc_Sel;
         AV119Contabilidad_plancuentaswwds_22_tfcuemov_sel = AV87TFCueMov_Sel;
         AV120Contabilidad_plancuentaswwds_23_tfcuemon_sel = AV88TFCueMon_Sel;
         AV121Contabilidad_plancuentaswwds_24_tfcuecos_sel = AV89TFCueCos_Sel;
         AV122Contabilidad_plancuentaswwds_25_tfcuegasdebe = AV48TFCueGasDebe;
         AV123Contabilidad_plancuentaswwds_26_tfcuegasdebe_sel = AV49TFCueGasDebe_Sel;
         AV124Contabilidad_plancuentaswwds_27_tfcuegashaber = AV50TFCueGasHaber;
         AV125Contabilidad_plancuentaswwds_28_tfcuegashaber_sel = AV51TFCueGasHaber_Sel;
         AV126Contabilidad_plancuentaswwds_29_tfcuests_sels = AV91TFCueSts_Sels;
         /*  Sending Event outputs  */
         cmbavDynamicfiltersoperator1.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV16DynamicFiltersOperator1), 4, 0));
         AssignProp("", false, cmbavDynamicfiltersoperator1_Internalname, "Values", cmbavDynamicfiltersoperator1.ToJavascriptSource(), true);
         cmbavDynamicfiltersoperator2.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV21DynamicFiltersOperator2), 4, 0));
         AssignProp("", false, cmbavDynamicfiltersoperator2_Internalname, "Values", cmbavDynamicfiltersoperator2.ToJavascriptSource(), true);
         cmbavDynamicfiltersoperator3.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV26DynamicFiltersOperator3), 4, 0));
         AssignProp("", false, cmbavDynamicfiltersoperator3_Internalname, "Values", cmbavDynamicfiltersoperator3.ToJavascriptSource(), true);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV10GridState", AV10GridState);
      }

      protected void E11292( )
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
            AV77PageToGo = (int)(NumberUtil.Val( Gridpaginationbar_Selectedpage, "."));
            subgrid_gotopage( AV77PageToGo) ;
         }
      }

      protected void E12292( )
      {
         /* Gridpaginationbar_Changerowsperpage Routine */
         returnInSub = false;
         subGrid_Rows = Gridpaginationbar_Rowsperpageselectedvalue;
         GxWebStd.gx_hidden_field( context, "GRID_Rows", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid_Rows), 6, 0, ".", "")));
         subgrid_firstpage( ) ;
         /*  Sending Event outputs  */
      }

      protected void E14292( )
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
            if ( StringUtil.StrCmp(Ddo_grid_Selectedcolumn, "CueCod") == 0 )
            {
               AV34TFCueCod = Ddo_grid_Filteredtext_get;
               AssignAttri("", false, "AV34TFCueCod", AV34TFCueCod);
               AV35TFCueCod_Sel = Ddo_grid_Selectedvalue_get;
               AssignAttri("", false, "AV35TFCueCod_Sel", AV35TFCueCod_Sel);
            }
            else if ( StringUtil.StrCmp(Ddo_grid_Selectedcolumn, "CueDsc") == 0 )
            {
               AV36TFCueDsc = Ddo_grid_Filteredtext_get;
               AssignAttri("", false, "AV36TFCueDsc", AV36TFCueDsc);
               AV37TFCueDsc_Sel = Ddo_grid_Selectedvalue_get;
               AssignAttri("", false, "AV37TFCueDsc_Sel", AV37TFCueDsc_Sel);
            }
            else if ( StringUtil.StrCmp(Ddo_grid_Selectedcolumn, "CueMov") == 0 )
            {
               AV87TFCueMov_Sel = (short)(NumberUtil.Val( Ddo_grid_Selectedvalue_get, "."));
               AssignAttri("", false, "AV87TFCueMov_Sel", StringUtil.Str( (decimal)(AV87TFCueMov_Sel), 1, 0));
            }
            else if ( StringUtil.StrCmp(Ddo_grid_Selectedcolumn, "CueMon") == 0 )
            {
               AV88TFCueMon_Sel = (short)(NumberUtil.Val( Ddo_grid_Selectedvalue_get, "."));
               AssignAttri("", false, "AV88TFCueMon_Sel", StringUtil.Str( (decimal)(AV88TFCueMon_Sel), 1, 0));
            }
            else if ( StringUtil.StrCmp(Ddo_grid_Selectedcolumn, "CueCos") == 0 )
            {
               AV89TFCueCos_Sel = (short)(NumberUtil.Val( Ddo_grid_Selectedvalue_get, "."));
               AssignAttri("", false, "AV89TFCueCos_Sel", StringUtil.Str( (decimal)(AV89TFCueCos_Sel), 1, 0));
            }
            else if ( StringUtil.StrCmp(Ddo_grid_Selectedcolumn, "CueGasDebe") == 0 )
            {
               AV48TFCueGasDebe = Ddo_grid_Filteredtext_get;
               AssignAttri("", false, "AV48TFCueGasDebe", AV48TFCueGasDebe);
               AV49TFCueGasDebe_Sel = Ddo_grid_Selectedvalue_get;
               AssignAttri("", false, "AV49TFCueGasDebe_Sel", AV49TFCueGasDebe_Sel);
            }
            else if ( StringUtil.StrCmp(Ddo_grid_Selectedcolumn, "CueGasHaber") == 0 )
            {
               AV50TFCueGasHaber = Ddo_grid_Filteredtext_get;
               AssignAttri("", false, "AV50TFCueGasHaber", AV50TFCueGasHaber);
               AV51TFCueGasHaber_Sel = Ddo_grid_Selectedvalue_get;
               AssignAttri("", false, "AV51TFCueGasHaber_Sel", AV51TFCueGasHaber_Sel);
            }
            else if ( StringUtil.StrCmp(Ddo_grid_Selectedcolumn, "CueSts") == 0 )
            {
               AV90TFCueSts_SelsJson = Ddo_grid_Selectedvalue_get;
               AssignAttri("", false, "AV90TFCueSts_SelsJson", AV90TFCueSts_SelsJson);
               AV91TFCueSts_Sels.FromJSonString(StringUtil.StringReplace( AV90TFCueSts_SelsJson, "\"", ""), null);
            }
            subgrid_firstpage( ) ;
         }
         /*  Sending Event outputs  */
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV91TFCueSts_Sels", AV91TFCueSts_Sels);
      }

      private void E26292( )
      {
         /* Grid_Load Routine */
         returnInSub = false;
         cmbavGridactions.removeAllItems();
         cmbavGridactions.addItem("0", ";fa fa-bars", 0);
         cmbavGridactions.addItem("1", StringUtil.Format( "%1;%2", "Modificar", "fa fa-pen", "", "", "", "", "", "", ""), 0);
         cmbavGridactions.addItem("2", StringUtil.Format( "%1;%2", "Eliminar", "fa fa-times", "", "", "", "", "", "", ""), 0);
         GXKey = Crypto.GetSiteKey( );
         GXEncryptionTmp = "contabilidad.plancuentas.aspx"+UrlEncode(StringUtil.RTrim("DSP")) + "," + UrlEncode(StringUtil.RTrim(A91CueCod));
         edtCueDsc_Link = formatLink("contabilidad.plancuentas.aspx") + "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey);
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
         cmbavGridactions.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV81GridActions), 4, 0));
      }

      protected void E19292( )
      {
         /* 'AddDynamicFilters1' Routine */
         returnInSub = false;
         AV19DynamicFiltersEnabled2 = true;
         AssignAttri("", false, "AV19DynamicFiltersEnabled2", AV19DynamicFiltersEnabled2);
         imgAdddynamicfilters1_Visible = 0;
         AssignProp("", false, imgAdddynamicfilters1_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(imgAdddynamicfilters1_Visible), 5, 0), true);
         imgRemovedynamicfilters1_Visible = 1;
         AssignProp("", false, imgRemovedynamicfilters1_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(imgRemovedynamicfilters1_Visible), 5, 0), true);
         gxgrGrid_refresh( subGrid_Rows, AV15DynamicFiltersSelector1, AV16DynamicFiltersOperator1, AV84CueCod1, AV17CueDsc1, AV92CueMov1, AV20DynamicFiltersSelector2, AV21DynamicFiltersOperator2, AV85CueCod2, AV22CueDsc2, AV93CueMov2, AV25DynamicFiltersSelector3, AV26DynamicFiltersOperator3, AV86CueCod3, AV27CueDsc3, AV94CueMov3, AV19DynamicFiltersEnabled2, AV24DynamicFiltersEnabled3, AV97Pgmname, AV34TFCueCod, AV35TFCueCod_Sel, AV36TFCueDsc, AV37TFCueDsc_Sel, AV87TFCueMov_Sel, AV88TFCueMon_Sel, AV89TFCueCos_Sel, AV48TFCueGasDebe, AV49TFCueGasDebe_Sel, AV50TFCueGasHaber, AV51TFCueGasHaber_Sel, AV91TFCueSts_Sels, AV13OrderedBy, AV14OrderedDsc, AV10GridState, AV30DynamicFiltersIgnoreFirst, AV29DynamicFiltersRemoving) ;
         /*  Sending Event outputs  */
         cmbavDynamicfiltersoperator1.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV16DynamicFiltersOperator1), 4, 0));
         AssignProp("", false, cmbavDynamicfiltersoperator1_Internalname, "Values", cmbavDynamicfiltersoperator1.ToJavascriptSource(), true);
         cmbavDynamicfiltersoperator2.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV21DynamicFiltersOperator2), 4, 0));
         AssignProp("", false, cmbavDynamicfiltersoperator2_Internalname, "Values", cmbavDynamicfiltersoperator2.ToJavascriptSource(), true);
         cmbavDynamicfiltersoperator3.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV26DynamicFiltersOperator3), 4, 0));
         AssignProp("", false, cmbavDynamicfiltersoperator3_Internalname, "Values", cmbavDynamicfiltersoperator3.ToJavascriptSource(), true);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV10GridState", AV10GridState);
      }

      protected void E15292( )
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
         gxgrGrid_refresh( subGrid_Rows, AV15DynamicFiltersSelector1, AV16DynamicFiltersOperator1, AV84CueCod1, AV17CueDsc1, AV92CueMov1, AV20DynamicFiltersSelector2, AV21DynamicFiltersOperator2, AV85CueCod2, AV22CueDsc2, AV93CueMov2, AV25DynamicFiltersSelector3, AV26DynamicFiltersOperator3, AV86CueCod3, AV27CueDsc3, AV94CueMov3, AV19DynamicFiltersEnabled2, AV24DynamicFiltersEnabled3, AV97Pgmname, AV34TFCueCod, AV35TFCueCod_Sel, AV36TFCueDsc, AV37TFCueDsc_Sel, AV87TFCueMov_Sel, AV88TFCueMon_Sel, AV89TFCueCos_Sel, AV48TFCueGasDebe, AV49TFCueGasDebe_Sel, AV50TFCueGasHaber, AV51TFCueGasHaber_Sel, AV91TFCueSts_Sels, AV13OrderedBy, AV14OrderedDsc, AV10GridState, AV30DynamicFiltersIgnoreFirst, AV29DynamicFiltersRemoving) ;
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
         cmbavCuemov1.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV92CueMov1), 1, 0));
         AssignProp("", false, cmbavCuemov1_Internalname, "Values", cmbavCuemov1.ToJavascriptSource(), true);
         cmbavCuemov2.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV93CueMov2), 1, 0));
         AssignProp("", false, cmbavCuemov2_Internalname, "Values", cmbavCuemov2.ToJavascriptSource(), true);
         cmbavCuemov3.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV94CueMov3), 1, 0));
         AssignProp("", false, cmbavCuemov3_Internalname, "Values", cmbavCuemov3.ToJavascriptSource(), true);
      }

      protected void E20292( )
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

      protected void E21292( )
      {
         /* 'AddDynamicFilters2' Routine */
         returnInSub = false;
         AV24DynamicFiltersEnabled3 = true;
         AssignAttri("", false, "AV24DynamicFiltersEnabled3", AV24DynamicFiltersEnabled3);
         imgAdddynamicfilters2_Visible = 0;
         AssignProp("", false, imgAdddynamicfilters2_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(imgAdddynamicfilters2_Visible), 5, 0), true);
         imgRemovedynamicfilters2_Visible = 1;
         AssignProp("", false, imgRemovedynamicfilters2_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(imgRemovedynamicfilters2_Visible), 5, 0), true);
         gxgrGrid_refresh( subGrid_Rows, AV15DynamicFiltersSelector1, AV16DynamicFiltersOperator1, AV84CueCod1, AV17CueDsc1, AV92CueMov1, AV20DynamicFiltersSelector2, AV21DynamicFiltersOperator2, AV85CueCod2, AV22CueDsc2, AV93CueMov2, AV25DynamicFiltersSelector3, AV26DynamicFiltersOperator3, AV86CueCod3, AV27CueDsc3, AV94CueMov3, AV19DynamicFiltersEnabled2, AV24DynamicFiltersEnabled3, AV97Pgmname, AV34TFCueCod, AV35TFCueCod_Sel, AV36TFCueDsc, AV37TFCueDsc_Sel, AV87TFCueMov_Sel, AV88TFCueMon_Sel, AV89TFCueCos_Sel, AV48TFCueGasDebe, AV49TFCueGasDebe_Sel, AV50TFCueGasHaber, AV51TFCueGasHaber_Sel, AV91TFCueSts_Sels, AV13OrderedBy, AV14OrderedDsc, AV10GridState, AV30DynamicFiltersIgnoreFirst, AV29DynamicFiltersRemoving) ;
         /*  Sending Event outputs  */
         cmbavDynamicfiltersoperator1.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV16DynamicFiltersOperator1), 4, 0));
         AssignProp("", false, cmbavDynamicfiltersoperator1_Internalname, "Values", cmbavDynamicfiltersoperator1.ToJavascriptSource(), true);
         cmbavDynamicfiltersoperator2.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV21DynamicFiltersOperator2), 4, 0));
         AssignProp("", false, cmbavDynamicfiltersoperator2_Internalname, "Values", cmbavDynamicfiltersoperator2.ToJavascriptSource(), true);
         cmbavDynamicfiltersoperator3.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV26DynamicFiltersOperator3), 4, 0));
         AssignProp("", false, cmbavDynamicfiltersoperator3_Internalname, "Values", cmbavDynamicfiltersoperator3.ToJavascriptSource(), true);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV10GridState", AV10GridState);
      }

      protected void E16292( )
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
         gxgrGrid_refresh( subGrid_Rows, AV15DynamicFiltersSelector1, AV16DynamicFiltersOperator1, AV84CueCod1, AV17CueDsc1, AV92CueMov1, AV20DynamicFiltersSelector2, AV21DynamicFiltersOperator2, AV85CueCod2, AV22CueDsc2, AV93CueMov2, AV25DynamicFiltersSelector3, AV26DynamicFiltersOperator3, AV86CueCod3, AV27CueDsc3, AV94CueMov3, AV19DynamicFiltersEnabled2, AV24DynamicFiltersEnabled3, AV97Pgmname, AV34TFCueCod, AV35TFCueCod_Sel, AV36TFCueDsc, AV37TFCueDsc_Sel, AV87TFCueMov_Sel, AV88TFCueMon_Sel, AV89TFCueCos_Sel, AV48TFCueGasDebe, AV49TFCueGasDebe_Sel, AV50TFCueGasHaber, AV51TFCueGasHaber_Sel, AV91TFCueSts_Sels, AV13OrderedBy, AV14OrderedDsc, AV10GridState, AV30DynamicFiltersIgnoreFirst, AV29DynamicFiltersRemoving) ;
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
         cmbavCuemov1.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV92CueMov1), 1, 0));
         AssignProp("", false, cmbavCuemov1_Internalname, "Values", cmbavCuemov1.ToJavascriptSource(), true);
         cmbavCuemov2.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV93CueMov2), 1, 0));
         AssignProp("", false, cmbavCuemov2_Internalname, "Values", cmbavCuemov2.ToJavascriptSource(), true);
         cmbavCuemov3.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV94CueMov3), 1, 0));
         AssignProp("", false, cmbavCuemov3_Internalname, "Values", cmbavCuemov3.ToJavascriptSource(), true);
      }

      protected void E22292( )
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

      protected void E17292( )
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
         gxgrGrid_refresh( subGrid_Rows, AV15DynamicFiltersSelector1, AV16DynamicFiltersOperator1, AV84CueCod1, AV17CueDsc1, AV92CueMov1, AV20DynamicFiltersSelector2, AV21DynamicFiltersOperator2, AV85CueCod2, AV22CueDsc2, AV93CueMov2, AV25DynamicFiltersSelector3, AV26DynamicFiltersOperator3, AV86CueCod3, AV27CueDsc3, AV94CueMov3, AV19DynamicFiltersEnabled2, AV24DynamicFiltersEnabled3, AV97Pgmname, AV34TFCueCod, AV35TFCueCod_Sel, AV36TFCueDsc, AV37TFCueDsc_Sel, AV87TFCueMov_Sel, AV88TFCueMon_Sel, AV89TFCueCos_Sel, AV48TFCueGasDebe, AV49TFCueGasDebe_Sel, AV50TFCueGasHaber, AV51TFCueGasHaber_Sel, AV91TFCueSts_Sels, AV13OrderedBy, AV14OrderedDsc, AV10GridState, AV30DynamicFiltersIgnoreFirst, AV29DynamicFiltersRemoving) ;
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
         cmbavCuemov1.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV92CueMov1), 1, 0));
         AssignProp("", false, cmbavCuemov1_Internalname, "Values", cmbavCuemov1.ToJavascriptSource(), true);
         cmbavCuemov2.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV93CueMov2), 1, 0));
         AssignProp("", false, cmbavCuemov2_Internalname, "Values", cmbavCuemov2.ToJavascriptSource(), true);
         cmbavCuemov3.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV94CueMov3), 1, 0));
         AssignProp("", false, cmbavCuemov3_Internalname, "Values", cmbavCuemov3.ToJavascriptSource(), true);
      }

      protected void E23292( )
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

      protected void E27292( )
      {
         /* Gridactions_Click Routine */
         returnInSub = false;
         if ( AV81GridActions == 1 )
         {
            /* Execute user subroutine: 'DO UPDATE' */
            S212 ();
            if ( returnInSub )
            {
               returnInSub = true;
               if (true) return;
            }
         }
         else if ( AV81GridActions == 2 )
         {
            /* Execute user subroutine: 'DO DELETE' */
            S222 ();
            if ( returnInSub )
            {
               returnInSub = true;
               if (true) return;
            }
         }
         AV81GridActions = 0;
         AssignAttri("", false, cmbavGridactions_Internalname, StringUtil.LTrimStr( (decimal)(AV81GridActions), 4, 0));
         /*  Sending Event outputs  */
         cmbavGridactions.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV81GridActions), 4, 0));
         AssignProp("", false, cmbavGridactions_Internalname, "Values", cmbavGridactions.ToJavascriptSource(), true);
      }

      protected void E18292( )
      {
         /* 'DoInsert' Routine */
         returnInSub = false;
         GXKey = Crypto.GetSiteKey( );
         GXEncryptionTmp = "contabilidad.plancuentas.aspx"+UrlEncode(StringUtil.RTrim("INS")) + "," + UrlEncode(StringUtil.RTrim(""));
         CallWebObject(formatLink("contabilidad.plancuentas.aspx") + "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey));
         context.wjLocDisableFrm = 1;
      }

      protected void E13292( )
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
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV91TFCueSts_Sels", AV91TFCueSts_Sels);
         cmbavDynamicfiltersselector1.CurrentValue = StringUtil.RTrim( AV15DynamicFiltersSelector1);
         AssignProp("", false, cmbavDynamicfiltersselector1_Internalname, "Values", cmbavDynamicfiltersselector1.ToJavascriptSource(), true);
         cmbavDynamicfiltersoperator1.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV16DynamicFiltersOperator1), 4, 0));
         AssignProp("", false, cmbavDynamicfiltersoperator1_Internalname, "Values", cmbavDynamicfiltersoperator1.ToJavascriptSource(), true);
         cmbavCuemov1.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV92CueMov1), 1, 0));
         AssignProp("", false, cmbavCuemov1_Internalname, "Values", cmbavCuemov1.ToJavascriptSource(), true);
         cmbavDynamicfiltersselector2.CurrentValue = StringUtil.RTrim( AV20DynamicFiltersSelector2);
         AssignProp("", false, cmbavDynamicfiltersselector2_Internalname, "Values", cmbavDynamicfiltersselector2.ToJavascriptSource(), true);
         cmbavDynamicfiltersoperator2.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV21DynamicFiltersOperator2), 4, 0));
         AssignProp("", false, cmbavDynamicfiltersoperator2_Internalname, "Values", cmbavDynamicfiltersoperator2.ToJavascriptSource(), true);
         cmbavCuemov2.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV93CueMov2), 1, 0));
         AssignProp("", false, cmbavCuemov2_Internalname, "Values", cmbavCuemov2.ToJavascriptSource(), true);
         cmbavDynamicfiltersselector3.CurrentValue = StringUtil.RTrim( AV25DynamicFiltersSelector3);
         AssignProp("", false, cmbavDynamicfiltersselector3_Internalname, "Values", cmbavDynamicfiltersselector3.ToJavascriptSource(), true);
         cmbavDynamicfiltersoperator3.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV26DynamicFiltersOperator3), 4, 0));
         AssignProp("", false, cmbavDynamicfiltersoperator3_Internalname, "Values", cmbavDynamicfiltersoperator3.ToJavascriptSource(), true);
         cmbavCuemov3.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV94CueMov3), 1, 0));
         AssignProp("", false, cmbavCuemov3_Internalname, "Values", cmbavCuemov3.ToJavascriptSource(), true);
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
         edtavCuecod1_Visible = 0;
         AssignProp("", false, edtavCuecod1_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavCuecod1_Visible), 5, 0), true);
         edtavCuedsc1_Visible = 0;
         AssignProp("", false, edtavCuedsc1_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavCuedsc1_Visible), 5, 0), true);
         cmbavCuemov1.Visible = 0;
         AssignProp("", false, cmbavCuemov1_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(cmbavCuemov1.Visible), 5, 0), true);
         cmbavDynamicfiltersoperator1.Visible = 0;
         AssignProp("", false, cmbavDynamicfiltersoperator1_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(cmbavDynamicfiltersoperator1.Visible), 5, 0), true);
         if ( StringUtil.StrCmp(AV15DynamicFiltersSelector1, "CUECOD") == 0 )
         {
            edtavCuecod1_Visible = 1;
            AssignProp("", false, edtavCuecod1_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavCuecod1_Visible), 5, 0), true);
            cmbavDynamicfiltersoperator1.Visible = 1;
            AssignProp("", false, cmbavDynamicfiltersoperator1_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(cmbavDynamicfiltersoperator1.Visible), 5, 0), true);
         }
         else if ( StringUtil.StrCmp(AV15DynamicFiltersSelector1, "CUEDSC") == 0 )
         {
            edtavCuedsc1_Visible = 1;
            AssignProp("", false, edtavCuedsc1_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavCuedsc1_Visible), 5, 0), true);
            cmbavDynamicfiltersoperator1.Visible = 1;
            AssignProp("", false, cmbavDynamicfiltersoperator1_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(cmbavDynamicfiltersoperator1.Visible), 5, 0), true);
         }
         else if ( StringUtil.StrCmp(AV15DynamicFiltersSelector1, "CUEMOV") == 0 )
         {
            cmbavCuemov1.Visible = 1;
            AssignProp("", false, cmbavCuemov1_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(cmbavCuemov1.Visible), 5, 0), true);
         }
      }

      protected void S122( )
      {
         /* 'ENABLEDYNAMICFILTERS2' Routine */
         returnInSub = false;
         edtavCuecod2_Visible = 0;
         AssignProp("", false, edtavCuecod2_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavCuecod2_Visible), 5, 0), true);
         edtavCuedsc2_Visible = 0;
         AssignProp("", false, edtavCuedsc2_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavCuedsc2_Visible), 5, 0), true);
         cmbavCuemov2.Visible = 0;
         AssignProp("", false, cmbavCuemov2_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(cmbavCuemov2.Visible), 5, 0), true);
         cmbavDynamicfiltersoperator2.Visible = 0;
         AssignProp("", false, cmbavDynamicfiltersoperator2_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(cmbavDynamicfiltersoperator2.Visible), 5, 0), true);
         if ( StringUtil.StrCmp(AV20DynamicFiltersSelector2, "CUECOD") == 0 )
         {
            edtavCuecod2_Visible = 1;
            AssignProp("", false, edtavCuecod2_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavCuecod2_Visible), 5, 0), true);
            cmbavDynamicfiltersoperator2.Visible = 1;
            AssignProp("", false, cmbavDynamicfiltersoperator2_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(cmbavDynamicfiltersoperator2.Visible), 5, 0), true);
         }
         else if ( StringUtil.StrCmp(AV20DynamicFiltersSelector2, "CUEDSC") == 0 )
         {
            edtavCuedsc2_Visible = 1;
            AssignProp("", false, edtavCuedsc2_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavCuedsc2_Visible), 5, 0), true);
            cmbavDynamicfiltersoperator2.Visible = 1;
            AssignProp("", false, cmbavDynamicfiltersoperator2_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(cmbavDynamicfiltersoperator2.Visible), 5, 0), true);
         }
         else if ( StringUtil.StrCmp(AV20DynamicFiltersSelector2, "CUEMOV") == 0 )
         {
            cmbavCuemov2.Visible = 1;
            AssignProp("", false, cmbavCuemov2_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(cmbavCuemov2.Visible), 5, 0), true);
         }
      }

      protected void S132( )
      {
         /* 'ENABLEDYNAMICFILTERS3' Routine */
         returnInSub = false;
         edtavCuecod3_Visible = 0;
         AssignProp("", false, edtavCuecod3_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavCuecod3_Visible), 5, 0), true);
         edtavCuedsc3_Visible = 0;
         AssignProp("", false, edtavCuedsc3_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavCuedsc3_Visible), 5, 0), true);
         cmbavCuemov3.Visible = 0;
         AssignProp("", false, cmbavCuemov3_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(cmbavCuemov3.Visible), 5, 0), true);
         cmbavDynamicfiltersoperator3.Visible = 0;
         AssignProp("", false, cmbavDynamicfiltersoperator3_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(cmbavDynamicfiltersoperator3.Visible), 5, 0), true);
         if ( StringUtil.StrCmp(AV25DynamicFiltersSelector3, "CUECOD") == 0 )
         {
            edtavCuecod3_Visible = 1;
            AssignProp("", false, edtavCuecod3_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavCuecod3_Visible), 5, 0), true);
            cmbavDynamicfiltersoperator3.Visible = 1;
            AssignProp("", false, cmbavDynamicfiltersoperator3_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(cmbavDynamicfiltersoperator3.Visible), 5, 0), true);
         }
         else if ( StringUtil.StrCmp(AV25DynamicFiltersSelector3, "CUEDSC") == 0 )
         {
            edtavCuedsc3_Visible = 1;
            AssignProp("", false, edtavCuedsc3_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavCuedsc3_Visible), 5, 0), true);
            cmbavDynamicfiltersoperator3.Visible = 1;
            AssignProp("", false, cmbavDynamicfiltersoperator3_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(cmbavDynamicfiltersoperator3.Visible), 5, 0), true);
         }
         else if ( StringUtil.StrCmp(AV25DynamicFiltersSelector3, "CUEMOV") == 0 )
         {
            cmbavCuemov3.Visible = 1;
            AssignProp("", false, cmbavCuemov3_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(cmbavCuemov3.Visible), 5, 0), true);
         }
      }

      protected void S192( )
      {
         /* 'RESETDYNFILTERS' Routine */
         returnInSub = false;
         AV19DynamicFiltersEnabled2 = false;
         AssignAttri("", false, "AV19DynamicFiltersEnabled2", AV19DynamicFiltersEnabled2);
         AV20DynamicFiltersSelector2 = "CUECOD";
         AssignAttri("", false, "AV20DynamicFiltersSelector2", AV20DynamicFiltersSelector2);
         AV21DynamicFiltersOperator2 = 0;
         AssignAttri("", false, "AV21DynamicFiltersOperator2", StringUtil.LTrimStr( (decimal)(AV21DynamicFiltersOperator2), 4, 0));
         AV85CueCod2 = "";
         AssignAttri("", false, "AV85CueCod2", AV85CueCod2);
         /* Execute user subroutine: 'ENABLEDYNAMICFILTERS2' */
         S122 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
         AV24DynamicFiltersEnabled3 = false;
         AssignAttri("", false, "AV24DynamicFiltersEnabled3", AV24DynamicFiltersEnabled3);
         AV25DynamicFiltersSelector3 = "CUECOD";
         AssignAttri("", false, "AV25DynamicFiltersSelector3", AV25DynamicFiltersSelector3);
         AV26DynamicFiltersOperator3 = 0;
         AssignAttri("", false, "AV26DynamicFiltersOperator3", StringUtil.LTrimStr( (decimal)(AV26DynamicFiltersOperator3), 4, 0));
         AV86CueCod3 = "";
         AssignAttri("", false, "AV86CueCod3", AV86CueCod3);
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
         GXEncryptionTmp = "contabilidad.plancuentas.aspx"+UrlEncode(StringUtil.RTrim("UPD")) + "," + UrlEncode(StringUtil.RTrim(A91CueCod));
         CallWebObject(formatLink("contabilidad.plancuentas.aspx") + "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey));
         context.wjLocDisableFrm = 1;
      }

      protected void S222( )
      {
         /* 'DO DELETE' Routine */
         returnInSub = false;
         GXKey = Crypto.GetSiteKey( );
         GXEncryptionTmp = "contabilidad.plancuentas.aspx"+UrlEncode(StringUtil.RTrim("DLT")) + "," + UrlEncode(StringUtil.RTrim(A91CueCod));
         CallWebObject(formatLink("contabilidad.plancuentas.aspx") + "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey));
         context.wjLocDisableFrm = 1;
      }

      protected void S152( )
      {
         /* 'LOADGRIDSTATE' Routine */
         returnInSub = false;
         if ( StringUtil.StrCmp(AV33Session.Get(AV97Pgmname+"GridState"), "") == 0 )
         {
            AV10GridState.FromXml(new GeneXus.Programs.wwpbaseobjects.loadgridstate(context).executeUdp(  AV97Pgmname+"GridState"), null, "", "");
         }
         else
         {
            AV10GridState.FromXml(AV33Session.Get(AV97Pgmname+"GridState"), null, "", "");
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
         AV127GXV1 = 1;
         while ( AV127GXV1 <= AV10GridState.gxTpr_Filtervalues.Count )
         {
            AV11GridStateFilterValue = ((GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue)AV10GridState.gxTpr_Filtervalues.Item(AV127GXV1));
            if ( StringUtil.StrCmp(AV11GridStateFilterValue.gxTpr_Name, "TFCUECOD") == 0 )
            {
               AV34TFCueCod = AV11GridStateFilterValue.gxTpr_Value;
               AssignAttri("", false, "AV34TFCueCod", AV34TFCueCod);
            }
            else if ( StringUtil.StrCmp(AV11GridStateFilterValue.gxTpr_Name, "TFCUECOD_SEL") == 0 )
            {
               AV35TFCueCod_Sel = AV11GridStateFilterValue.gxTpr_Value;
               AssignAttri("", false, "AV35TFCueCod_Sel", AV35TFCueCod_Sel);
            }
            else if ( StringUtil.StrCmp(AV11GridStateFilterValue.gxTpr_Name, "TFCUEDSC") == 0 )
            {
               AV36TFCueDsc = AV11GridStateFilterValue.gxTpr_Value;
               AssignAttri("", false, "AV36TFCueDsc", AV36TFCueDsc);
            }
            else if ( StringUtil.StrCmp(AV11GridStateFilterValue.gxTpr_Name, "TFCUEDSC_SEL") == 0 )
            {
               AV37TFCueDsc_Sel = AV11GridStateFilterValue.gxTpr_Value;
               AssignAttri("", false, "AV37TFCueDsc_Sel", AV37TFCueDsc_Sel);
            }
            else if ( StringUtil.StrCmp(AV11GridStateFilterValue.gxTpr_Name, "TFCUEMOV_SEL") == 0 )
            {
               AV87TFCueMov_Sel = (short)(NumberUtil.Val( AV11GridStateFilterValue.gxTpr_Value, "."));
               AssignAttri("", false, "AV87TFCueMov_Sel", StringUtil.Str( (decimal)(AV87TFCueMov_Sel), 1, 0));
            }
            else if ( StringUtil.StrCmp(AV11GridStateFilterValue.gxTpr_Name, "TFCUEMON_SEL") == 0 )
            {
               AV88TFCueMon_Sel = (short)(NumberUtil.Val( AV11GridStateFilterValue.gxTpr_Value, "."));
               AssignAttri("", false, "AV88TFCueMon_Sel", StringUtil.Str( (decimal)(AV88TFCueMon_Sel), 1, 0));
            }
            else if ( StringUtil.StrCmp(AV11GridStateFilterValue.gxTpr_Name, "TFCUECOS_SEL") == 0 )
            {
               AV89TFCueCos_Sel = (short)(NumberUtil.Val( AV11GridStateFilterValue.gxTpr_Value, "."));
               AssignAttri("", false, "AV89TFCueCos_Sel", StringUtil.Str( (decimal)(AV89TFCueCos_Sel), 1, 0));
            }
            else if ( StringUtil.StrCmp(AV11GridStateFilterValue.gxTpr_Name, "TFCUEGASDEBE") == 0 )
            {
               AV48TFCueGasDebe = AV11GridStateFilterValue.gxTpr_Value;
               AssignAttri("", false, "AV48TFCueGasDebe", AV48TFCueGasDebe);
            }
            else if ( StringUtil.StrCmp(AV11GridStateFilterValue.gxTpr_Name, "TFCUEGASDEBE_SEL") == 0 )
            {
               AV49TFCueGasDebe_Sel = AV11GridStateFilterValue.gxTpr_Value;
               AssignAttri("", false, "AV49TFCueGasDebe_Sel", AV49TFCueGasDebe_Sel);
            }
            else if ( StringUtil.StrCmp(AV11GridStateFilterValue.gxTpr_Name, "TFCUEGASHABER") == 0 )
            {
               AV50TFCueGasHaber = AV11GridStateFilterValue.gxTpr_Value;
               AssignAttri("", false, "AV50TFCueGasHaber", AV50TFCueGasHaber);
            }
            else if ( StringUtil.StrCmp(AV11GridStateFilterValue.gxTpr_Name, "TFCUEGASHABER_SEL") == 0 )
            {
               AV51TFCueGasHaber_Sel = AV11GridStateFilterValue.gxTpr_Value;
               AssignAttri("", false, "AV51TFCueGasHaber_Sel", AV51TFCueGasHaber_Sel);
            }
            else if ( StringUtil.StrCmp(AV11GridStateFilterValue.gxTpr_Name, "TFCUESTS_SEL") == 0 )
            {
               AV90TFCueSts_SelsJson = AV11GridStateFilterValue.gxTpr_Value;
               AssignAttri("", false, "AV90TFCueSts_SelsJson", AV90TFCueSts_SelsJson);
               AV91TFCueSts_Sels.FromJSonString(AV90TFCueSts_SelsJson, null);
            }
            AV127GXV1 = (int)(AV127GXV1+1);
         }
         GXt_char2 = "";
         new GeneXus.Programs.wwpbaseobjects.wwp_getfilterval(context ).execute(  String.IsNullOrEmpty(StringUtil.RTrim( AV35TFCueCod_Sel)),  AV35TFCueCod_Sel, out  GXt_char2) ;
         GXt_char3 = "";
         new GeneXus.Programs.wwpbaseobjects.wwp_getfilterval(context ).execute(  String.IsNullOrEmpty(StringUtil.RTrim( AV37TFCueDsc_Sel)),  AV37TFCueDsc_Sel, out  GXt_char3) ;
         GXt_char4 = "";
         new GeneXus.Programs.wwpbaseobjects.wwp_getfilterval(context ).execute(  String.IsNullOrEmpty(StringUtil.RTrim( AV49TFCueGasDebe_Sel)),  AV49TFCueGasDebe_Sel, out  GXt_char4) ;
         GXt_char5 = "";
         new GeneXus.Programs.wwpbaseobjects.wwp_getfilterval(context ).execute(  String.IsNullOrEmpty(StringUtil.RTrim( AV51TFCueGasHaber_Sel)),  AV51TFCueGasHaber_Sel, out  GXt_char5) ;
         Ddo_grid_Selectedvalue_set = GXt_char2+"|"+GXt_char3+"|"+((0==AV87TFCueMov_Sel) ? "" : StringUtil.Str( (decimal)(AV87TFCueMov_Sel), 1, 0))+"|"+((0==AV88TFCueMon_Sel) ? "" : StringUtil.Str( (decimal)(AV88TFCueMon_Sel), 1, 0))+"|"+((0==AV89TFCueCos_Sel) ? "" : StringUtil.Str( (decimal)(AV89TFCueCos_Sel), 1, 0))+"|"+GXt_char4+"|"+GXt_char5+"|"+((AV91TFCueSts_Sels.Count==0) ? "" : AV90TFCueSts_SelsJson);
         ucDdo_grid.SendProperty(context, "", false, Ddo_grid_Internalname, "SelectedValue_set", Ddo_grid_Selectedvalue_set);
         GXt_char5 = "";
         new GeneXus.Programs.wwpbaseobjects.wwp_getfilterval(context ).execute(  String.IsNullOrEmpty(StringUtil.RTrim( AV34TFCueCod)),  AV34TFCueCod, out  GXt_char5) ;
         GXt_char4 = "";
         new GeneXus.Programs.wwpbaseobjects.wwp_getfilterval(context ).execute(  String.IsNullOrEmpty(StringUtil.RTrim( AV36TFCueDsc)),  AV36TFCueDsc, out  GXt_char4) ;
         GXt_char3 = "";
         new GeneXus.Programs.wwpbaseobjects.wwp_getfilterval(context ).execute(  String.IsNullOrEmpty(StringUtil.RTrim( AV48TFCueGasDebe)),  AV48TFCueGasDebe, out  GXt_char3) ;
         GXt_char2 = "";
         new GeneXus.Programs.wwpbaseobjects.wwp_getfilterval(context ).execute(  String.IsNullOrEmpty(StringUtil.RTrim( AV50TFCueGasHaber)),  AV50TFCueGasHaber, out  GXt_char2) ;
         Ddo_grid_Filteredtext_set = GXt_char5+"|"+GXt_char4+"||||"+GXt_char3+"|"+GXt_char2+"|";
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
            if ( StringUtil.StrCmp(AV15DynamicFiltersSelector1, "CUECOD") == 0 )
            {
               AV16DynamicFiltersOperator1 = AV12GridStateDynamicFilter.gxTpr_Operator;
               AssignAttri("", false, "AV16DynamicFiltersOperator1", StringUtil.LTrimStr( (decimal)(AV16DynamicFiltersOperator1), 4, 0));
               AV84CueCod1 = AV12GridStateDynamicFilter.gxTpr_Value;
               AssignAttri("", false, "AV84CueCod1", AV84CueCod1);
            }
            else if ( StringUtil.StrCmp(AV15DynamicFiltersSelector1, "CUEDSC") == 0 )
            {
               AV16DynamicFiltersOperator1 = AV12GridStateDynamicFilter.gxTpr_Operator;
               AssignAttri("", false, "AV16DynamicFiltersOperator1", StringUtil.LTrimStr( (decimal)(AV16DynamicFiltersOperator1), 4, 0));
               AV17CueDsc1 = AV12GridStateDynamicFilter.gxTpr_Value;
               AssignAttri("", false, "AV17CueDsc1", AV17CueDsc1);
            }
            else if ( StringUtil.StrCmp(AV15DynamicFiltersSelector1, "CUEMOV") == 0 )
            {
               AV92CueMov1 = (short)(NumberUtil.Val( AV12GridStateDynamicFilter.gxTpr_Value, "."));
               AssignAttri("", false, "AV92CueMov1", StringUtil.Str( (decimal)(AV92CueMov1), 1, 0));
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
               if ( StringUtil.StrCmp(AV20DynamicFiltersSelector2, "CUECOD") == 0 )
               {
                  AV21DynamicFiltersOperator2 = AV12GridStateDynamicFilter.gxTpr_Operator;
                  AssignAttri("", false, "AV21DynamicFiltersOperator2", StringUtil.LTrimStr( (decimal)(AV21DynamicFiltersOperator2), 4, 0));
                  AV85CueCod2 = AV12GridStateDynamicFilter.gxTpr_Value;
                  AssignAttri("", false, "AV85CueCod2", AV85CueCod2);
               }
               else if ( StringUtil.StrCmp(AV20DynamicFiltersSelector2, "CUEDSC") == 0 )
               {
                  AV21DynamicFiltersOperator2 = AV12GridStateDynamicFilter.gxTpr_Operator;
                  AssignAttri("", false, "AV21DynamicFiltersOperator2", StringUtil.LTrimStr( (decimal)(AV21DynamicFiltersOperator2), 4, 0));
                  AV22CueDsc2 = AV12GridStateDynamicFilter.gxTpr_Value;
                  AssignAttri("", false, "AV22CueDsc2", AV22CueDsc2);
               }
               else if ( StringUtil.StrCmp(AV20DynamicFiltersSelector2, "CUEMOV") == 0 )
               {
                  AV93CueMov2 = (short)(NumberUtil.Val( AV12GridStateDynamicFilter.gxTpr_Value, "."));
                  AssignAttri("", false, "AV93CueMov2", StringUtil.Str( (decimal)(AV93CueMov2), 1, 0));
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
                  if ( StringUtil.StrCmp(AV25DynamicFiltersSelector3, "CUECOD") == 0 )
                  {
                     AV26DynamicFiltersOperator3 = AV12GridStateDynamicFilter.gxTpr_Operator;
                     AssignAttri("", false, "AV26DynamicFiltersOperator3", StringUtil.LTrimStr( (decimal)(AV26DynamicFiltersOperator3), 4, 0));
                     AV86CueCod3 = AV12GridStateDynamicFilter.gxTpr_Value;
                     AssignAttri("", false, "AV86CueCod3", AV86CueCod3);
                  }
                  else if ( StringUtil.StrCmp(AV25DynamicFiltersSelector3, "CUEDSC") == 0 )
                  {
                     AV26DynamicFiltersOperator3 = AV12GridStateDynamicFilter.gxTpr_Operator;
                     AssignAttri("", false, "AV26DynamicFiltersOperator3", StringUtil.LTrimStr( (decimal)(AV26DynamicFiltersOperator3), 4, 0));
                     AV27CueDsc3 = AV12GridStateDynamicFilter.gxTpr_Value;
                     AssignAttri("", false, "AV27CueDsc3", AV27CueDsc3);
                  }
                  else if ( StringUtil.StrCmp(AV25DynamicFiltersSelector3, "CUEMOV") == 0 )
                  {
                     AV94CueMov3 = (short)(NumberUtil.Val( AV12GridStateDynamicFilter.gxTpr_Value, "."));
                     AssignAttri("", false, "AV94CueMov3", StringUtil.Str( (decimal)(AV94CueMov3), 1, 0));
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
         AV10GridState.FromXml(AV33Session.Get(AV97Pgmname+"GridState"), null, "", "");
         AV10GridState.gxTpr_Orderedby = AV13OrderedBy;
         AV10GridState.gxTpr_Ordereddsc = AV14OrderedDsc;
         AV10GridState.gxTpr_Filtervalues.Clear();
         new GeneXus.Programs.wwpbaseobjects.wwp_gridstateaddfiltervalueandsel(context ).execute( ref  AV10GridState,  "TFCUECOD",  "Cuenta Contable",  !String.IsNullOrEmpty(StringUtil.RTrim( AV34TFCueCod)),  0,  AV34TFCueCod,  "",  !String.IsNullOrEmpty(StringUtil.RTrim( AV35TFCueCod_Sel)),  AV35TFCueCod_Sel,  "") ;
         new GeneXus.Programs.wwpbaseobjects.wwp_gridstateaddfiltervalueandsel(context ).execute( ref  AV10GridState,  "TFCUEDSC",  "Descripción",  !String.IsNullOrEmpty(StringUtil.RTrim( AV36TFCueDsc)),  0,  AV36TFCueDsc,  "",  !String.IsNullOrEmpty(StringUtil.RTrim( AV37TFCueDsc_Sel)),  AV37TFCueDsc_Sel,  "") ;
         new GeneXus.Programs.wwpbaseobjects.wwp_gridstateaddfiltervalue(context ).execute( ref  AV10GridState,  "TFCUEMOV_SEL",  "Movimiento",  !(0==AV87TFCueMov_Sel),  0,  StringUtil.Trim( StringUtil.Str( (decimal)(AV87TFCueMov_Sel), 1, 0)),  "") ;
         new GeneXus.Programs.wwpbaseobjects.wwp_gridstateaddfiltervalue(context ).execute( ref  AV10GridState,  "TFCUEMON_SEL",  "Monetaria",  !(0==AV88TFCueMon_Sel),  0,  StringUtil.Trim( StringUtil.Str( (decimal)(AV88TFCueMon_Sel), 1, 0)),  "") ;
         new GeneXus.Programs.wwpbaseobjects.wwp_gridstateaddfiltervalue(context ).execute( ref  AV10GridState,  "TFCUECOS_SEL",  "Centro de Costos",  !(0==AV89TFCueCos_Sel),  0,  StringUtil.Trim( StringUtil.Str( (decimal)(AV89TFCueCos_Sel), 1, 0)),  "") ;
         new GeneXus.Programs.wwpbaseobjects.wwp_gridstateaddfiltervalueandsel(context ).execute( ref  AV10GridState,  "TFCUEGASDEBE",  "Gasto Debe",  !String.IsNullOrEmpty(StringUtil.RTrim( AV48TFCueGasDebe)),  0,  AV48TFCueGasDebe,  "",  !String.IsNullOrEmpty(StringUtil.RTrim( AV49TFCueGasDebe_Sel)),  AV49TFCueGasDebe_Sel,  "") ;
         new GeneXus.Programs.wwpbaseobjects.wwp_gridstateaddfiltervalueandsel(context ).execute( ref  AV10GridState,  "TFCUEGASHABER",  "Gasto Haber",  !String.IsNullOrEmpty(StringUtil.RTrim( AV50TFCueGasHaber)),  0,  AV50TFCueGasHaber,  "",  !String.IsNullOrEmpty(StringUtil.RTrim( AV51TFCueGasHaber_Sel)),  AV51TFCueGasHaber_Sel,  "") ;
         new GeneXus.Programs.wwpbaseobjects.wwp_gridstateaddfiltervalue(context ).execute( ref  AV10GridState,  "TFCUESTS_SEL",  "Estado",  !(AV91TFCueSts_Sels.Count==0),  0,  AV91TFCueSts_Sels.ToJSonString(false),  "") ;
         /* Execute user subroutine: 'SAVEDYNFILTERSSTATE' */
         S182 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
         AV10GridState.gxTpr_Pagesize = StringUtil.Str( (decimal)(subGrid_Rows), 10, 0);
         AV10GridState.gxTpr_Currentpage = (short)(subGrid_fnc_Currentpage( ));
         new GeneXus.Programs.wwpbaseobjects.savegridstate(context ).execute(  AV97Pgmname+"GridState",  AV10GridState.ToXml(false, true, "", "")) ;
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
            if ( ( StringUtil.StrCmp(AV15DynamicFiltersSelector1, "CUECOD") == 0 ) && ! String.IsNullOrEmpty(StringUtil.RTrim( AV84CueCod1)) )
            {
               AV12GridStateDynamicFilter.gxTpr_Dsc = "Cuenta Contable";
               AV12GridStateDynamicFilter.gxTpr_Value = AV84CueCod1;
               AV12GridStateDynamicFilter.gxTpr_Operator = AV16DynamicFiltersOperator1;
            }
            else if ( ( StringUtil.StrCmp(AV15DynamicFiltersSelector1, "CUEDSC") == 0 ) && ! String.IsNullOrEmpty(StringUtil.RTrim( AV17CueDsc1)) )
            {
               AV12GridStateDynamicFilter.gxTpr_Dsc = "Descripción";
               AV12GridStateDynamicFilter.gxTpr_Value = AV17CueDsc1;
               AV12GridStateDynamicFilter.gxTpr_Operator = AV16DynamicFiltersOperator1;
            }
            else if ( StringUtil.StrCmp(AV15DynamicFiltersSelector1, "CUEMOV") == 0 )
            {
               AV12GridStateDynamicFilter.gxTpr_Dsc = "Movimiento Cuenta";
               AV12GridStateDynamicFilter.gxTpr_Value = StringUtil.Str( (decimal)(AV92CueMov1), 1, 0);
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
            if ( ( StringUtil.StrCmp(AV20DynamicFiltersSelector2, "CUECOD") == 0 ) && ! String.IsNullOrEmpty(StringUtil.RTrim( AV85CueCod2)) )
            {
               AV12GridStateDynamicFilter.gxTpr_Dsc = "Cuenta Contable";
               AV12GridStateDynamicFilter.gxTpr_Value = AV85CueCod2;
               AV12GridStateDynamicFilter.gxTpr_Operator = AV21DynamicFiltersOperator2;
            }
            else if ( ( StringUtil.StrCmp(AV20DynamicFiltersSelector2, "CUEDSC") == 0 ) && ! String.IsNullOrEmpty(StringUtil.RTrim( AV22CueDsc2)) )
            {
               AV12GridStateDynamicFilter.gxTpr_Dsc = "Descripción";
               AV12GridStateDynamicFilter.gxTpr_Value = AV22CueDsc2;
               AV12GridStateDynamicFilter.gxTpr_Operator = AV21DynamicFiltersOperator2;
            }
            else if ( StringUtil.StrCmp(AV20DynamicFiltersSelector2, "CUEMOV") == 0 )
            {
               AV12GridStateDynamicFilter.gxTpr_Dsc = "Movimiento Cuenta";
               AV12GridStateDynamicFilter.gxTpr_Value = StringUtil.Str( (decimal)(AV93CueMov2), 1, 0);
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
            if ( ( StringUtil.StrCmp(AV25DynamicFiltersSelector3, "CUECOD") == 0 ) && ! String.IsNullOrEmpty(StringUtil.RTrim( AV86CueCod3)) )
            {
               AV12GridStateDynamicFilter.gxTpr_Dsc = "Cuenta Contable";
               AV12GridStateDynamicFilter.gxTpr_Value = AV86CueCod3;
               AV12GridStateDynamicFilter.gxTpr_Operator = AV26DynamicFiltersOperator3;
            }
            else if ( ( StringUtil.StrCmp(AV25DynamicFiltersSelector3, "CUEDSC") == 0 ) && ! String.IsNullOrEmpty(StringUtil.RTrim( AV27CueDsc3)) )
            {
               AV12GridStateDynamicFilter.gxTpr_Dsc = "Descripción";
               AV12GridStateDynamicFilter.gxTpr_Value = AV27CueDsc3;
               AV12GridStateDynamicFilter.gxTpr_Operator = AV26DynamicFiltersOperator3;
            }
            else if ( StringUtil.StrCmp(AV25DynamicFiltersSelector3, "CUEMOV") == 0 )
            {
               AV12GridStateDynamicFilter.gxTpr_Dsc = "Movimiento Cuenta";
               AV12GridStateDynamicFilter.gxTpr_Value = StringUtil.Str( (decimal)(AV94CueMov3), 1, 0);
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
         AV8TrnContext.gxTpr_Callerobject = AV97Pgmname;
         AV8TrnContext.gxTpr_Callerondelete = true;
         AV8TrnContext.gxTpr_Callerurl = AV7HTTPRequest.ScriptName+"?"+AV7HTTPRequest.QueryString;
         AV8TrnContext.gxTpr_Transactionname = "Contabilidad.PlanCuentas";
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
         new GeneXus.Programs.contabilidad.plancuentaswwexport(context ).execute( out  AV31ExcelFilename, out  AV32ErrorMessage) ;
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
         Innewwindow1_Target = formatLink("contabilidad.plancuentaswwexportreport.aspx") ;
         ucInnewwindow1.SendProperty(context, "", false, Innewwindow1_Internalname, "Target", Innewwindow1_Target);
         Innewwindow1_Height = "600";
         ucInnewwindow1.SendProperty(context, "", false, Innewwindow1_Internalname, "Height", Innewwindow1_Height);
         Innewwindow1_Width = "800";
         ucInnewwindow1.SendProperty(context, "", false, Innewwindow1_Internalname, "Width", Innewwindow1_Width);
         this.executeUsercontrolMethod("", false, "INNEWWINDOW1Container", "OpenWindow", "", new Object[] {});
      }

      protected void wb_table1_25_292( bool wbgen )
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
            GxWebStd.gx_label_ctrl( context, lblDynamicfiltersprefix1_Internalname, "Buscar en", "", "", lblDynamicfiltersprefix1_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "DataFilterDescriptionPrefix", 0, "", 1, 1, 0, 0, "HLP_Contabilidad\\PlanCuentasWW.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "", "left", "top", "", "flex-grow:1;", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "left", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, cmbavDynamicfiltersselector1_Internalname, "Dynamic Filters Selector1", "gx-form-item AttributeLabel", 0, true, "width: 25%;");
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 35,'',false,'" + sGXsfl_119_idx + "',0)\"";
            /* ComboBox */
            GxWebStd.gx_combobox_ctrl1( context, cmbavDynamicfiltersselector1, cmbavDynamicfiltersselector1_Internalname, StringUtil.RTrim( AV15DynamicFiltersSelector1), 1, cmbavDynamicfiltersselector1_Jsonclick, 5, "'"+""+"'"+",false,"+"'"+"EVDYNAMICFILTERSSELECTOR1.CLICK."+"'", "svchar", "", 1, cmbavDynamicfiltersselector1.Enabled, 0, 0, 0, "em", 0, "", "", "Attribute", "", "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,35);\"", "", true, 1, "HLP_Contabilidad\\PlanCuentasWW.htm");
            cmbavDynamicfiltersselector1.CurrentValue = StringUtil.RTrim( AV15DynamicFiltersSelector1);
            AssignProp("", false, cmbavDynamicfiltersselector1_Internalname, "Values", (string)(cmbavDynamicfiltersselector1.ToJavascriptSource()), true);
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "", "left", "top", "", "flex-grow:1;", "div");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblDynamicfiltersmiddle1_Internalname, "valor", "", "", lblDynamicfiltersmiddle1_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "DataFilterDescription", 0, "", 1, 1, 0, 0, "HLP_Contabilidad\\PlanCuentasWW.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "", "left", "top", "", "flex-grow:1;", "div");
            wb_table2_39_292( true) ;
         }
         else
         {
            wb_table2_39_292( false) ;
         }
         return  ;
      }

      protected void wb_table2_39_292e( bool wbgen )
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
            GxWebStd.gx_label_ctrl( context, lblDynamicfiltersprefix2_Internalname, "Buscar en", "", "", lblDynamicfiltersprefix2_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "DataFilterDescriptionPrefix", 0, "", 1, 1, 0, 0, "HLP_Contabilidad\\PlanCuentasWW.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "Invisible", "left", "top", "", "flex-grow:1;", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "left", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, cmbavDynamicfiltersselector2_Internalname, "Dynamic Filters Selector2", "gx-form-item AttributeLabel", 0, true, "width: 25%;");
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 63,'',false,'" + sGXsfl_119_idx + "',0)\"";
            /* ComboBox */
            GxWebStd.gx_combobox_ctrl1( context, cmbavDynamicfiltersselector2, cmbavDynamicfiltersselector2_Internalname, StringUtil.RTrim( AV20DynamicFiltersSelector2), 1, cmbavDynamicfiltersselector2_Jsonclick, 5, "'"+""+"'"+",false,"+"'"+"EVDYNAMICFILTERSSELECTOR2.CLICK."+"'", "svchar", "", 1, cmbavDynamicfiltersselector2.Enabled, 0, 0, 0, "em", 0, "", "", "Attribute", "", "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,63);\"", "", true, 1, "HLP_Contabilidad\\PlanCuentasWW.htm");
            cmbavDynamicfiltersselector2.CurrentValue = StringUtil.RTrim( AV20DynamicFiltersSelector2);
            AssignProp("", false, cmbavDynamicfiltersselector2_Internalname, "Values", (string)(cmbavDynamicfiltersselector2.ToJavascriptSource()), true);
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "Invisible", "left", "top", "", "flex-grow:1;", "div");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblDynamicfiltersmiddle2_Internalname, "valor", "", "", lblDynamicfiltersmiddle2_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "DataFilterDescription", 0, "", 1, 1, 0, 0, "HLP_Contabilidad\\PlanCuentasWW.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "Invisible", "left", "top", "", "flex-grow:1;", "div");
            wb_table3_67_292( true) ;
         }
         else
         {
            wb_table3_67_292( false) ;
         }
         return  ;
      }

      protected void wb_table3_67_292e( bool wbgen )
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
            GxWebStd.gx_label_ctrl( context, lblDynamicfiltersprefix3_Internalname, "Buscar en", "", "", lblDynamicfiltersprefix3_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "DataFilterDescriptionPrefix", 0, "", 1, 1, 0, 0, "HLP_Contabilidad\\PlanCuentasWW.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "Invisible", "left", "top", "", "flex-grow:1;", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "left", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, cmbavDynamicfiltersselector3_Internalname, "Dynamic Filters Selector3", "gx-form-item AttributeLabel", 0, true, "width: 25%;");
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 91,'',false,'" + sGXsfl_119_idx + "',0)\"";
            /* ComboBox */
            GxWebStd.gx_combobox_ctrl1( context, cmbavDynamicfiltersselector3, cmbavDynamicfiltersselector3_Internalname, StringUtil.RTrim( AV25DynamicFiltersSelector3), 1, cmbavDynamicfiltersselector3_Jsonclick, 5, "'"+""+"'"+",false,"+"'"+"EVDYNAMICFILTERSSELECTOR3.CLICK."+"'", "svchar", "", 1, cmbavDynamicfiltersselector3.Enabled, 0, 0, 0, "em", 0, "", "", "Attribute", "", "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,91);\"", "", true, 1, "HLP_Contabilidad\\PlanCuentasWW.htm");
            cmbavDynamicfiltersselector3.CurrentValue = StringUtil.RTrim( AV25DynamicFiltersSelector3);
            AssignProp("", false, cmbavDynamicfiltersselector3_Internalname, "Values", (string)(cmbavDynamicfiltersselector3.ToJavascriptSource()), true);
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "Invisible", "left", "top", "", "flex-grow:1;", "div");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblDynamicfiltersmiddle3_Internalname, "valor", "", "", lblDynamicfiltersmiddle3_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "DataFilterDescription", 0, "", 1, 1, 0, 0, "HLP_Contabilidad\\PlanCuentasWW.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "Invisible", "left", "top", "", "flex-grow:1;", "div");
            wb_table4_95_292( true) ;
         }
         else
         {
            wb_table4_95_292( false) ;
         }
         return  ;
      }

      protected void wb_table4_95_292e( bool wbgen )
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
            wb_table1_25_292e( true) ;
         }
         else
         {
            wb_table1_25_292e( false) ;
         }
      }

      protected void wb_table4_95_292( bool wbgen )
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
            GxWebStd.gx_combobox_ctrl1( context, cmbavDynamicfiltersoperator3, cmbavDynamicfiltersoperator3_Internalname, StringUtil.Trim( StringUtil.Str( (decimal)(AV26DynamicFiltersOperator3), 4, 0)), 1, cmbavDynamicfiltersoperator3_Jsonclick, 0, "'"+""+"'"+",false,"+"'"+""+"'", "int", "", cmbavDynamicfiltersoperator3.Visible, cmbavDynamicfiltersoperator3.Enabled, 0, 0, 0, "em", 0, "", "", "Attribute", "", "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,99);\"", "", true, 1, "HLP_Contabilidad\\PlanCuentasWW.htm");
            cmbavDynamicfiltersoperator3.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV26DynamicFiltersOperator3), 4, 0));
            AssignProp("", false, cmbavDynamicfiltersoperator3_Internalname, "Values", (string)(cmbavDynamicfiltersoperator3.ToJavascriptSource()), true);
            GxWebStd.gx_div_end( context, "left", "top", "div");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "<td id=\""+cellFilter_cuecod3_cell_Internalname+"\"  class=''>") ;
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "left", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavCuecod3_Internalname, "Cue Cod3", "gx-form-item AttributeLabel", 0, true, "width: 25%;");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 102,'',false,'" + sGXsfl_119_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavCuecod3_Internalname, StringUtil.RTrim( AV86CueCod3), StringUtil.RTrim( context.localUtil.Format( AV86CueCod3, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,102);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavCuecod3_Jsonclick, 0, "Attribute", "", "", "", "", edtavCuecod3_Visible, edtavCuecod3_Enabled, 0, "text", "", 15, "chr", 1, "row", 15, 0, 0, 0, 1, -1, -1, true, "", "left", true, "", "HLP_Contabilidad\\PlanCuentasWW.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "<td id=\""+cellFilter_cuedsc3_cell_Internalname+"\"  class=''>") ;
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "left", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavCuedsc3_Internalname, "Cue Dsc3", "gx-form-item AttributeLabel", 0, true, "width: 25%;");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 105,'',false,'" + sGXsfl_119_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavCuedsc3_Internalname, StringUtil.RTrim( AV27CueDsc3), StringUtil.RTrim( context.localUtil.Format( AV27CueDsc3, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,105);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavCuedsc3_Jsonclick, 0, "Attribute", "", "", "", "", edtavCuedsc3_Visible, edtavCuedsc3_Enabled, 0, "text", "", 80, "chr", 1, "row", 100, 0, 0, 0, 1, -1, -1, true, "", "left", true, "", "HLP_Contabilidad\\PlanCuentasWW.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "<td id=\""+cellFilter_cuemov3_cell_Internalname+"\"  class=''>") ;
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "left", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, cmbavCuemov3_Internalname, "Cue Mov3", "gx-form-item AttributeLabel", 0, true, "width: 25%;");
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 108,'',false,'" + sGXsfl_119_idx + "',0)\"";
            /* ComboBox */
            GxWebStd.gx_combobox_ctrl1( context, cmbavCuemov3, cmbavCuemov3_Internalname, StringUtil.Trim( StringUtil.Str( (decimal)(AV94CueMov3), 1, 0)), 1, cmbavCuemov3_Jsonclick, 0, "'"+""+"'"+",false,"+"'"+""+"'", "int", "", cmbavCuemov3.Visible, cmbavCuemov3.Enabled, 0, 0, 0, "em", 0, "", "", "Attribute", "", "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,108);\"", "", true, 1, "HLP_Contabilidad\\PlanCuentasWW.htm");
            cmbavCuemov3.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV94CueMov3), 1, 0));
            AssignProp("", false, cmbavCuemov3_Internalname, "Values", (string)(cmbavCuemov3.ToJavascriptSource()), true);
            GxWebStd.gx_div_end( context, "left", "top", "div");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "<td id=\""+cellDynamicfilters_removefilter3_cell_Internalname+"\"  class=''>") ;
            /* Active images/pictures */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 110,'',false,'',0)\"";
            ClassString = "Image";
            StyleString = "";
            sImgUrl = (string)(context.GetImagePath( "11a6ef14-1a5a-4077-91a2-f41ed9a3a662", "", context.GetTheme( )));
            GxWebStd.gx_bitmap( context, imgRemovedynamicfilters3_Internalname, sImgUrl, "", "", "", context.GetTheme( ), 1, 1, "", "Quitar filtro", 0, 0, 0, "px", 0, "px", 0, 0, 5, imgRemovedynamicfilters3_Jsonclick, "'"+""+"'"+",false,"+"'"+"E\\'REMOVEDYNAMICFILTERS3\\'."+"'", StyleString, ClassString, "", "", "", "", " "+"data-gx-image"+" "+TempTags, "", "", 1, false, false, context.GetImageSrcSet( sImgUrl), "HLP_Contabilidad\\PlanCuentasWW.htm");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "</tr>") ;
            /* End of table */
            context.WriteHtmlText( "</table>") ;
            wb_table4_95_292e( true) ;
         }
         else
         {
            wb_table4_95_292e( false) ;
         }
      }

      protected void wb_table3_67_292( bool wbgen )
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
            GxWebStd.gx_combobox_ctrl1( context, cmbavDynamicfiltersoperator2, cmbavDynamicfiltersoperator2_Internalname, StringUtil.Trim( StringUtil.Str( (decimal)(AV21DynamicFiltersOperator2), 4, 0)), 1, cmbavDynamicfiltersoperator2_Jsonclick, 0, "'"+""+"'"+",false,"+"'"+""+"'", "int", "", cmbavDynamicfiltersoperator2.Visible, cmbavDynamicfiltersoperator2.Enabled, 0, 0, 0, "em", 0, "", "", "Attribute", "", "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,71);\"", "", true, 1, "HLP_Contabilidad\\PlanCuentasWW.htm");
            cmbavDynamicfiltersoperator2.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV21DynamicFiltersOperator2), 4, 0));
            AssignProp("", false, cmbavDynamicfiltersoperator2_Internalname, "Values", (string)(cmbavDynamicfiltersoperator2.ToJavascriptSource()), true);
            GxWebStd.gx_div_end( context, "left", "top", "div");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "<td id=\""+cellFilter_cuecod2_cell_Internalname+"\"  class=''>") ;
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "left", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavCuecod2_Internalname, "Cue Cod2", "gx-form-item AttributeLabel", 0, true, "width: 25%;");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 74,'',false,'" + sGXsfl_119_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavCuecod2_Internalname, StringUtil.RTrim( AV85CueCod2), StringUtil.RTrim( context.localUtil.Format( AV85CueCod2, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,74);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavCuecod2_Jsonclick, 0, "Attribute", "", "", "", "", edtavCuecod2_Visible, edtavCuecod2_Enabled, 0, "text", "", 15, "chr", 1, "row", 15, 0, 0, 0, 1, -1, -1, true, "", "left", true, "", "HLP_Contabilidad\\PlanCuentasWW.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "<td id=\""+cellFilter_cuedsc2_cell_Internalname+"\"  class=''>") ;
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "left", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavCuedsc2_Internalname, "Cue Dsc2", "gx-form-item AttributeLabel", 0, true, "width: 25%;");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 77,'',false,'" + sGXsfl_119_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavCuedsc2_Internalname, StringUtil.RTrim( AV22CueDsc2), StringUtil.RTrim( context.localUtil.Format( AV22CueDsc2, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,77);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavCuedsc2_Jsonclick, 0, "Attribute", "", "", "", "", edtavCuedsc2_Visible, edtavCuedsc2_Enabled, 0, "text", "", 80, "chr", 1, "row", 100, 0, 0, 0, 1, -1, -1, true, "", "left", true, "", "HLP_Contabilidad\\PlanCuentasWW.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "<td id=\""+cellFilter_cuemov2_cell_Internalname+"\"  class=''>") ;
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "left", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, cmbavCuemov2_Internalname, "Cue Mov2", "gx-form-item AttributeLabel", 0, true, "width: 25%;");
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 80,'',false,'" + sGXsfl_119_idx + "',0)\"";
            /* ComboBox */
            GxWebStd.gx_combobox_ctrl1( context, cmbavCuemov2, cmbavCuemov2_Internalname, StringUtil.Trim( StringUtil.Str( (decimal)(AV93CueMov2), 1, 0)), 1, cmbavCuemov2_Jsonclick, 0, "'"+""+"'"+",false,"+"'"+""+"'", "int", "", cmbavCuemov2.Visible, cmbavCuemov2.Enabled, 0, 0, 0, "em", 0, "", "", "Attribute", "", "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,80);\"", "", true, 1, "HLP_Contabilidad\\PlanCuentasWW.htm");
            cmbavCuemov2.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV93CueMov2), 1, 0));
            AssignProp("", false, cmbavCuemov2_Internalname, "Values", (string)(cmbavCuemov2.ToJavascriptSource()), true);
            GxWebStd.gx_div_end( context, "left", "top", "div");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "<td id=\""+cellDynamicfilters_addfilter2_cell_Internalname+"\"  class=''>") ;
            /* Active images/pictures */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 82,'',false,'',0)\"";
            ClassString = "Image";
            StyleString = "";
            sImgUrl = (string)(context.GetImagePath( "27283ea5-332f-423b-b880-64b762622df3", "", context.GetTheme( )));
            GxWebStd.gx_bitmap( context, imgAdddynamicfilters2_Internalname, sImgUrl, "", "", "", context.GetTheme( ), imgAdddynamicfilters2_Visible, 1, "", "Agregar filtro", 0, 0, 0, "px", 0, "px", 0, 0, 5, imgAdddynamicfilters2_Jsonclick, "'"+""+"'"+",false,"+"'"+"E\\'ADDDYNAMICFILTERS2\\'."+"'", StyleString, ClassString, "", "", "", "", " "+"data-gx-image"+" "+TempTags, "", "", 1, false, false, context.GetImageSrcSet( sImgUrl), "HLP_Contabilidad\\PlanCuentasWW.htm");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "<td id=\""+cellDynamicfilters_removefilter2_cell_Internalname+"\"  class=''>") ;
            /* Active images/pictures */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 84,'',false,'',0)\"";
            ClassString = "Image";
            StyleString = "";
            sImgUrl = (string)(context.GetImagePath( "11a6ef14-1a5a-4077-91a2-f41ed9a3a662", "", context.GetTheme( )));
            GxWebStd.gx_bitmap( context, imgRemovedynamicfilters2_Internalname, sImgUrl, "", "", "", context.GetTheme( ), imgRemovedynamicfilters2_Visible, 1, "", "Quitar filtro", 0, 0, 0, "px", 0, "px", 0, 0, 5, imgRemovedynamicfilters2_Jsonclick, "'"+""+"'"+",false,"+"'"+"E\\'REMOVEDYNAMICFILTERS2\\'."+"'", StyleString, ClassString, "", "", "", "", " "+"data-gx-image"+" "+TempTags, "", "", 1, false, false, context.GetImageSrcSet( sImgUrl), "HLP_Contabilidad\\PlanCuentasWW.htm");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "</tr>") ;
            /* End of table */
            context.WriteHtmlText( "</table>") ;
            wb_table3_67_292e( true) ;
         }
         else
         {
            wb_table3_67_292e( false) ;
         }
      }

      protected void wb_table2_39_292( bool wbgen )
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
            GxWebStd.gx_combobox_ctrl1( context, cmbavDynamicfiltersoperator1, cmbavDynamicfiltersoperator1_Internalname, StringUtil.Trim( StringUtil.Str( (decimal)(AV16DynamicFiltersOperator1), 4, 0)), 1, cmbavDynamicfiltersoperator1_Jsonclick, 0, "'"+""+"'"+",false,"+"'"+""+"'", "int", "", cmbavDynamicfiltersoperator1.Visible, cmbavDynamicfiltersoperator1.Enabled, 0, 0, 0, "em", 0, "", "", "Attribute", "", "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,43);\"", "", true, 1, "HLP_Contabilidad\\PlanCuentasWW.htm");
            cmbavDynamicfiltersoperator1.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV16DynamicFiltersOperator1), 4, 0));
            AssignProp("", false, cmbavDynamicfiltersoperator1_Internalname, "Values", (string)(cmbavDynamicfiltersoperator1.ToJavascriptSource()), true);
            GxWebStd.gx_div_end( context, "left", "top", "div");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "<td id=\""+cellFilter_cuecod1_cell_Internalname+"\"  class=''>") ;
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "left", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavCuecod1_Internalname, "Cue Cod1", "gx-form-item AttributeLabel", 0, true, "width: 25%;");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 46,'',false,'" + sGXsfl_119_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavCuecod1_Internalname, StringUtil.RTrim( AV84CueCod1), StringUtil.RTrim( context.localUtil.Format( AV84CueCod1, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,46);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavCuecod1_Jsonclick, 0, "Attribute", "", "", "", "", edtavCuecod1_Visible, edtavCuecod1_Enabled, 0, "text", "", 15, "chr", 1, "row", 15, 0, 0, 0, 1, -1, -1, true, "", "left", true, "", "HLP_Contabilidad\\PlanCuentasWW.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "<td id=\""+cellFilter_cuedsc1_cell_Internalname+"\"  class=''>") ;
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "left", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavCuedsc1_Internalname, "Cue Dsc1", "gx-form-item AttributeLabel", 0, true, "width: 25%;");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 49,'',false,'" + sGXsfl_119_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavCuedsc1_Internalname, StringUtil.RTrim( AV17CueDsc1), StringUtil.RTrim( context.localUtil.Format( AV17CueDsc1, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,49);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavCuedsc1_Jsonclick, 0, "Attribute", "", "", "", "", edtavCuedsc1_Visible, edtavCuedsc1_Enabled, 0, "text", "", 80, "chr", 1, "row", 100, 0, 0, 0, 1, -1, -1, true, "", "left", true, "", "HLP_Contabilidad\\PlanCuentasWW.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "<td id=\""+cellFilter_cuemov1_cell_Internalname+"\"  class=''>") ;
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "left", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, cmbavCuemov1_Internalname, "Cue Mov1", "gx-form-item AttributeLabel", 0, true, "width: 25%;");
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 52,'',false,'" + sGXsfl_119_idx + "',0)\"";
            /* ComboBox */
            GxWebStd.gx_combobox_ctrl1( context, cmbavCuemov1, cmbavCuemov1_Internalname, StringUtil.Trim( StringUtil.Str( (decimal)(AV92CueMov1), 1, 0)), 1, cmbavCuemov1_Jsonclick, 0, "'"+""+"'"+",false,"+"'"+""+"'", "int", "", cmbavCuemov1.Visible, cmbavCuemov1.Enabled, 0, 0, 0, "em", 0, "", "", "Attribute", "", "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,52);\"", "", true, 1, "HLP_Contabilidad\\PlanCuentasWW.htm");
            cmbavCuemov1.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV92CueMov1), 1, 0));
            AssignProp("", false, cmbavCuemov1_Internalname, "Values", (string)(cmbavCuemov1.ToJavascriptSource()), true);
            GxWebStd.gx_div_end( context, "left", "top", "div");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "<td id=\""+cellDynamicfilters_addfilter1_cell_Internalname+"\"  class=''>") ;
            /* Active images/pictures */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 54,'',false,'',0)\"";
            ClassString = "Image";
            StyleString = "";
            sImgUrl = (string)(context.GetImagePath( "27283ea5-332f-423b-b880-64b762622df3", "", context.GetTheme( )));
            GxWebStd.gx_bitmap( context, imgAdddynamicfilters1_Internalname, sImgUrl, "", "", "", context.GetTheme( ), imgAdddynamicfilters1_Visible, 1, "", "Agregar filtro", 0, 0, 0, "px", 0, "px", 0, 0, 5, imgAdddynamicfilters1_Jsonclick, "'"+""+"'"+",false,"+"'"+"E\\'ADDDYNAMICFILTERS1\\'."+"'", StyleString, ClassString, "", "", "", "", " "+"data-gx-image"+" "+TempTags, "", "", 1, false, false, context.GetImageSrcSet( sImgUrl), "HLP_Contabilidad\\PlanCuentasWW.htm");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "<td id=\""+cellDynamicfilters_removefilter1_cell_Internalname+"\"  class=''>") ;
            /* Active images/pictures */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 56,'',false,'',0)\"";
            ClassString = "Image";
            StyleString = "";
            sImgUrl = (string)(context.GetImagePath( "11a6ef14-1a5a-4077-91a2-f41ed9a3a662", "", context.GetTheme( )));
            GxWebStd.gx_bitmap( context, imgRemovedynamicfilters1_Internalname, sImgUrl, "", "", "", context.GetTheme( ), imgRemovedynamicfilters1_Visible, 1, "", "Quitar filtro", 0, 0, 0, "px", 0, "px", 0, 0, 5, imgRemovedynamicfilters1_Jsonclick, "'"+""+"'"+",false,"+"'"+"E\\'REMOVEDYNAMICFILTERS1\\'."+"'", StyleString, ClassString, "", "", "", "", " "+"data-gx-image"+" "+TempTags, "", "", 1, false, false, context.GetImageSrcSet( sImgUrl), "HLP_Contabilidad\\PlanCuentasWW.htm");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "</tr>") ;
            /* End of table */
            context.WriteHtmlText( "</table>") ;
            wb_table2_39_292e( true) ;
         }
         else
         {
            wb_table2_39_292e( false) ;
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
         PA292( ) ;
         WS292( ) ;
         WE292( ) ;
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
            context.AddJavascriptSource(StringUtil.RTrim( ((string)Form.Jscriptsrc.Item(idxLst))), "?202281810302664", true, true);
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
         context.AddJavascriptSource("contabilidad/plancuentasww.js", "?202281810302664", false, true);
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
         edtCueCod_Internalname = "CUECOD_"+sGXsfl_119_idx;
         edtCueDsc_Internalname = "CUEDSC_"+sGXsfl_119_idx;
         edtCueMov_Internalname = "CUEMOV_"+sGXsfl_119_idx;
         edtCueMon_Internalname = "CUEMON_"+sGXsfl_119_idx;
         edtCueCos_Internalname = "CUECOS_"+sGXsfl_119_idx;
         edtCueGasDebe_Internalname = "CUEGASDEBE_"+sGXsfl_119_idx;
         edtCueGasHaber_Internalname = "CUEGASHABER_"+sGXsfl_119_idx;
         cmbCueSts_Internalname = "CUESTS_"+sGXsfl_119_idx;
      }

      protected void SubsflControlProps_fel_1192( )
      {
         cmbavGridactions_Internalname = "vGRIDACTIONS_"+sGXsfl_119_fel_idx;
         edtCueCod_Internalname = "CUECOD_"+sGXsfl_119_fel_idx;
         edtCueDsc_Internalname = "CUEDSC_"+sGXsfl_119_fel_idx;
         edtCueMov_Internalname = "CUEMOV_"+sGXsfl_119_fel_idx;
         edtCueMon_Internalname = "CUEMON_"+sGXsfl_119_fel_idx;
         edtCueCos_Internalname = "CUECOS_"+sGXsfl_119_fel_idx;
         edtCueGasDebe_Internalname = "CUEGASDEBE_"+sGXsfl_119_fel_idx;
         edtCueGasHaber_Internalname = "CUEGASHABER_"+sGXsfl_119_fel_idx;
         cmbCueSts_Internalname = "CUESTS_"+sGXsfl_119_fel_idx;
      }

      protected void sendrow_1192( )
      {
         SubsflControlProps_1192( ) ;
         WB290( ) ;
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
                  AV81GridActions = (short)(NumberUtil.Val( cmbavGridactions.getValidValue(StringUtil.Trim( StringUtil.Str( (decimal)(AV81GridActions), 4, 0))), "."));
                  AssignAttri("", false, cmbavGridactions_Internalname, StringUtil.LTrimStr( (decimal)(AV81GridActions), 4, 0));
               }
            }
            /* ComboBox */
            GridRow.AddColumnProperties("combobox", 2, isAjaxCallMode( ), new Object[] {(GXCombobox)cmbavGridactions,(string)cmbavGridactions_Internalname,StringUtil.Trim( StringUtil.Str( (decimal)(AV81GridActions), 4, 0)),(short)1,(string)cmbavGridactions_Jsonclick,(short)5,"'"+""+"'"+",false,"+"'"+"EVGRIDACTIONS.CLICK."+sGXsfl_119_idx+"'",(string)"int",(string)"",(short)-1,(short)1,(short)0,(short)0,(short)0,(string)"px",(short)0,(string)"px",(string)"",(string)"ConvertToDDO",(string)"WWActionGroupColumn",(string)"",TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+((cmbavGridactions.Enabled!=0)&&(cmbavGridactions.Visible!=0) ? " onblur=\""+""+";gx.evt.onblur(this,120);\"" : " "),(string)"",(bool)true,(short)1});
            cmbavGridactions.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV81GridActions), 4, 0));
            AssignProp("", false, cmbavGridactions_Internalname, "Values", (string)(cmbavGridactions.ToJavascriptSource()), !bGXsfl_119_Refreshing);
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"left"+"\""+" style=\""+""+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtCueCod_Internalname,StringUtil.RTrim( A91CueCod),(string)"",(string)"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtCueCod_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn hidden-xs",(string)"",(short)-1,(short)0,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)15,(short)0,(short)0,(short)119,(short)1,(short)-1,(short)-1,(bool)true,(string)"",(string)"left",(bool)true,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"left"+"\""+" style=\""+""+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtCueDsc_Internalname,StringUtil.RTrim( A860CueDsc),(string)"",(string)"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)edtCueDsc_Link,(string)"",(string)"",(string)"",(string)edtCueDsc_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn",(string)"",(short)-1,(short)0,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)100,(short)0,(short)0,(short)119,(short)1,(short)-1,(short)-1,(bool)true,(string)"",(string)"left",(bool)true,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"right"+"\""+" style=\""+""+"\">") ;
            }
            /* Single line edit */
            ROClassString = "AttributeCheckBox";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtCueMov_Internalname,StringUtil.LTrim( StringUtil.NToC( (decimal)(A867CueMov), 1, 0, ".", "")),StringUtil.LTrim( context.localUtil.Format( (decimal)(A867CueMov), "9")),(string)" inputmode=\"numeric\" pattern=\"[0-9]*\""+"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtCueMov_Jsonclick,(short)0,(string)"AttributeCheckBox",(string)"",(string)ROClassString,(string)"WWColumn hidden-xs",(string)"",(short)-1,(short)0,(short)0,(string)"text",(string)"1",(short)0,(string)"px",(short)17,(string)"px",(short)1,(short)0,(short)0,(short)119,(short)1,(short)-1,(short)0,(bool)true,(string)"",(string)"right",(bool)false,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"right"+"\""+" style=\""+""+"\">") ;
            }
            /* Single line edit */
            ROClassString = "AttributeCheckBox";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtCueMon_Internalname,StringUtil.LTrim( StringUtil.NToC( (decimal)(A864CueMon), 1, 0, ".", "")),StringUtil.LTrim( context.localUtil.Format( (decimal)(A864CueMon), "9")),(string)" inputmode=\"numeric\" pattern=\"[0-9]*\""+"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtCueMon_Jsonclick,(short)0,(string)"AttributeCheckBox",(string)"",(string)ROClassString,(string)"WWColumn hidden-xs",(string)"",(short)-1,(short)0,(short)0,(string)"text",(string)"1",(short)0,(string)"px",(short)17,(string)"px",(short)1,(short)0,(short)0,(short)119,(short)1,(short)-1,(short)0,(bool)true,(string)"",(string)"right",(bool)false,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"right"+"\""+" style=\""+""+"\">") ;
            }
            /* Single line edit */
            ROClassString = "AttributeCheckBox";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtCueCos_Internalname,StringUtil.LTrim( StringUtil.NToC( (decimal)(A859CueCos), 1, 0, ".", "")),StringUtil.LTrim( context.localUtil.Format( (decimal)(A859CueCos), "9")),(string)" inputmode=\"numeric\" pattern=\"[0-9]*\""+"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtCueCos_Jsonclick,(short)0,(string)"AttributeCheckBox",(string)"",(string)ROClassString,(string)"WWColumn hidden-xs",(string)"",(short)-1,(short)0,(short)0,(string)"text",(string)"1",(short)0,(string)"px",(short)17,(string)"px",(short)1,(short)0,(short)0,(short)119,(short)1,(short)-1,(short)0,(bool)true,(string)"",(string)"right",(bool)false,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"left"+"\""+" style=\""+""+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtCueGasDebe_Internalname,StringUtil.RTrim( A109CueGasDebe),(string)"",(string)"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtCueGasDebe_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn hidden-xs",(string)"",(short)-1,(short)0,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)15,(short)0,(short)0,(short)119,(short)1,(short)-1,(short)-1,(bool)true,(string)"",(string)"left",(bool)true,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"left"+"\""+" style=\""+""+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtCueGasHaber_Internalname,StringUtil.RTrim( A110CueGasHaber),(string)"",(string)"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtCueGasHaber_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn hidden-xs",(string)"",(short)-1,(short)0,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)15,(short)0,(short)0,(short)119,(short)1,(short)-1,(short)-1,(bool)true,(string)"",(string)"left",(bool)true,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"right"+"\""+" style=\""+""+"\">") ;
            }
            if ( ( cmbCueSts.ItemCount == 0 ) && isAjaxCallMode( ) )
            {
               GXCCtl = "CUESTS_" + sGXsfl_119_idx;
               cmbCueSts.Name = GXCCtl;
               cmbCueSts.WebTags = "";
               cmbCueSts.addItem("1", "ACTIVO", 0);
               cmbCueSts.addItem("0", "INACTIVO", 0);
               if ( cmbCueSts.ItemCount > 0 )
               {
                  A873CueSts = (short)(NumberUtil.Val( cmbCueSts.getValidValue(StringUtil.Trim( StringUtil.Str( (decimal)(A873CueSts), 1, 0))), "."));
               }
            }
            /* ComboBox */
            GridRow.AddColumnProperties("combobox", 2, isAjaxCallMode( ), new Object[] {(GXCombobox)cmbCueSts,(string)cmbCueSts_Internalname,StringUtil.Trim( StringUtil.Str( (decimal)(A873CueSts), 1, 0)),(short)1,(string)cmbCueSts_Jsonclick,(short)0,(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"int",(string)"",(short)-1,(short)0,(short)0,(short)0,(short)0,(string)"px",(short)0,(string)"px",(string)"",(string)"Attribute",(string)"WWColumn hidden-xs",(string)"",(string)"",(string)"",(bool)true,(short)1});
            cmbCueSts.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(A873CueSts), 1, 0));
            AssignProp("", false, cmbCueSts_Internalname, "Values", (string)(cmbCueSts.ToJavascriptSource()), !bGXsfl_119_Refreshing);
            send_integrity_lvl_hashes292( ) ;
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
         cmbavDynamicfiltersselector1.addItem("CUECOD", "Cuenta Contable", 0);
         cmbavDynamicfiltersselector1.addItem("CUEDSC", "Descripción", 0);
         cmbavDynamicfiltersselector1.addItem("CUEMOV", "Movimiento Cuenta", 0);
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
         cmbavCuemov1.Name = "vCUEMOV1";
         cmbavCuemov1.WebTags = "";
         cmbavCuemov1.addItem("1", "SOLO MOVIMIENTO", 0);
         cmbavCuemov1.addItem("0", "CUENTAS TITULO", 0);
         if ( cmbavCuemov1.ItemCount > 0 )
         {
            AV92CueMov1 = (short)(NumberUtil.Val( cmbavCuemov1.getValidValue(StringUtil.Trim( StringUtil.Str( (decimal)(AV92CueMov1), 1, 0))), "."));
            AssignAttri("", false, "AV92CueMov1", StringUtil.Str( (decimal)(AV92CueMov1), 1, 0));
         }
         cmbavDynamicfiltersselector2.Name = "vDYNAMICFILTERSSELECTOR2";
         cmbavDynamicfiltersselector2.WebTags = "";
         cmbavDynamicfiltersselector2.addItem("CUECOD", "Cuenta Contable", 0);
         cmbavDynamicfiltersselector2.addItem("CUEDSC", "Descripción", 0);
         cmbavDynamicfiltersselector2.addItem("CUEMOV", "Movimiento Cuenta", 0);
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
         cmbavCuemov2.Name = "vCUEMOV2";
         cmbavCuemov2.WebTags = "";
         cmbavCuemov2.addItem("1", "SOLO MOVIMIENTO", 0);
         cmbavCuemov2.addItem("0", "CUENTAS TITULO", 0);
         if ( cmbavCuemov2.ItemCount > 0 )
         {
            AV93CueMov2 = (short)(NumberUtil.Val( cmbavCuemov2.getValidValue(StringUtil.Trim( StringUtil.Str( (decimal)(AV93CueMov2), 1, 0))), "."));
            AssignAttri("", false, "AV93CueMov2", StringUtil.Str( (decimal)(AV93CueMov2), 1, 0));
         }
         cmbavDynamicfiltersselector3.Name = "vDYNAMICFILTERSSELECTOR3";
         cmbavDynamicfiltersselector3.WebTags = "";
         cmbavDynamicfiltersselector3.addItem("CUECOD", "Cuenta Contable", 0);
         cmbavDynamicfiltersselector3.addItem("CUEDSC", "Descripción", 0);
         cmbavDynamicfiltersselector3.addItem("CUEMOV", "Movimiento Cuenta", 0);
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
         cmbavCuemov3.Name = "vCUEMOV3";
         cmbavCuemov3.WebTags = "";
         cmbavCuemov3.addItem("1", "SOLO MOVIMIENTO", 0);
         cmbavCuemov3.addItem("0", "CUENTAS TITULO", 0);
         if ( cmbavCuemov3.ItemCount > 0 )
         {
            AV94CueMov3 = (short)(NumberUtil.Val( cmbavCuemov3.getValidValue(StringUtil.Trim( StringUtil.Str( (decimal)(AV94CueMov3), 1, 0))), "."));
            AssignAttri("", false, "AV94CueMov3", StringUtil.Str( (decimal)(AV94CueMov3), 1, 0));
         }
         GXCCtl = "vGRIDACTIONS_" + sGXsfl_119_idx;
         cmbavGridactions.Name = GXCCtl;
         cmbavGridactions.WebTags = "";
         if ( cmbavGridactions.ItemCount > 0 )
         {
            AV81GridActions = (short)(NumberUtil.Val( cmbavGridactions.getValidValue(StringUtil.Trim( StringUtil.Str( (decimal)(AV81GridActions), 4, 0))), "."));
            AssignAttri("", false, cmbavGridactions_Internalname, StringUtil.LTrimStr( (decimal)(AV81GridActions), 4, 0));
         }
         GXCCtl = "CUESTS_" + sGXsfl_119_idx;
         cmbCueSts.Name = GXCCtl;
         cmbCueSts.WebTags = "";
         cmbCueSts.addItem("1", "ACTIVO", 0);
         cmbCueSts.addItem("0", "INACTIVO", 0);
         if ( cmbCueSts.ItemCount > 0 )
         {
            A873CueSts = (short)(NumberUtil.Val( cmbCueSts.getValidValue(StringUtil.Trim( StringUtil.Str( (decimal)(A873CueSts), 1, 0))), "."));
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
         edtavCuecod1_Internalname = "vCUECOD1";
         cellFilter_cuecod1_cell_Internalname = "FILTER_CUECOD1_CELL";
         edtavCuedsc1_Internalname = "vCUEDSC1";
         cellFilter_cuedsc1_cell_Internalname = "FILTER_CUEDSC1_CELL";
         cmbavCuemov1_Internalname = "vCUEMOV1";
         cellFilter_cuemov1_cell_Internalname = "FILTER_CUEMOV1_CELL";
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
         edtavCuecod2_Internalname = "vCUECOD2";
         cellFilter_cuecod2_cell_Internalname = "FILTER_CUECOD2_CELL";
         edtavCuedsc2_Internalname = "vCUEDSC2";
         cellFilter_cuedsc2_cell_Internalname = "FILTER_CUEDSC2_CELL";
         cmbavCuemov2_Internalname = "vCUEMOV2";
         cellFilter_cuemov2_cell_Internalname = "FILTER_CUEMOV2_CELL";
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
         edtavCuecod3_Internalname = "vCUECOD3";
         cellFilter_cuecod3_cell_Internalname = "FILTER_CUECOD3_CELL";
         edtavCuedsc3_Internalname = "vCUEDSC3";
         cellFilter_cuedsc3_cell_Internalname = "FILTER_CUEDSC3_CELL";
         cmbavCuemov3_Internalname = "vCUEMOV3";
         cellFilter_cuemov3_cell_Internalname = "FILTER_CUEMOV3_CELL";
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
         edtCueCod_Internalname = "CUECOD";
         edtCueDsc_Internalname = "CUEDSC";
         edtCueMov_Internalname = "CUEMOV";
         edtCueMon_Internalname = "CUEMON";
         edtCueCos_Internalname = "CUECOS";
         edtCueGasDebe_Internalname = "CUEGASDEBE";
         edtCueGasHaber_Internalname = "CUEGASHABER";
         cmbCueSts_Internalname = "CUESTS";
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
         cmbCueSts_Jsonclick = "";
         edtCueGasHaber_Jsonclick = "";
         edtCueGasDebe_Jsonclick = "";
         edtCueCos_Jsonclick = "";
         edtCueMon_Jsonclick = "";
         edtCueMov_Jsonclick = "";
         edtCueDsc_Jsonclick = "";
         edtCueCod_Jsonclick = "";
         cmbavGridactions_Jsonclick = "";
         cmbavGridactions.Visible = -1;
         cmbavGridactions.Enabled = 1;
         imgRemovedynamicfilters1_Visible = 1;
         imgAdddynamicfilters1_Visible = 1;
         cmbavCuemov1_Jsonclick = "";
         cmbavCuemov1.Enabled = 1;
         edtavCuedsc1_Jsonclick = "";
         edtavCuedsc1_Enabled = 1;
         edtavCuecod1_Jsonclick = "";
         edtavCuecod1_Enabled = 1;
         cmbavDynamicfiltersoperator1_Jsonclick = "";
         cmbavDynamicfiltersoperator1.Enabled = 1;
         imgRemovedynamicfilters2_Visible = 1;
         imgAdddynamicfilters2_Visible = 1;
         cmbavCuemov2_Jsonclick = "";
         cmbavCuemov2.Enabled = 1;
         edtavCuedsc2_Jsonclick = "";
         edtavCuedsc2_Enabled = 1;
         edtavCuecod2_Jsonclick = "";
         edtavCuecod2_Enabled = 1;
         cmbavDynamicfiltersoperator2_Jsonclick = "";
         cmbavDynamicfiltersoperator2.Enabled = 1;
         cmbavCuemov3_Jsonclick = "";
         cmbavCuemov3.Enabled = 1;
         edtavCuedsc3_Jsonclick = "";
         edtavCuedsc3_Enabled = 1;
         edtavCuecod3_Jsonclick = "";
         edtavCuecod3_Enabled = 1;
         cmbavDynamicfiltersoperator3_Jsonclick = "";
         cmbavDynamicfiltersoperator3.Enabled = 1;
         cmbavDynamicfiltersselector3_Jsonclick = "";
         cmbavDynamicfiltersselector3.Enabled = 1;
         cmbavDynamicfiltersselector2_Jsonclick = "";
         cmbavDynamicfiltersselector2.Enabled = 1;
         cmbavDynamicfiltersselector1_Jsonclick = "";
         cmbavDynamicfiltersselector1.Enabled = 1;
         cmbavDynamicfiltersoperator3.Visible = 1;
         cmbavCuemov3.Visible = 1;
         edtavCuedsc3_Visible = 1;
         edtavCuecod3_Visible = 1;
         cmbavDynamicfiltersoperator2.Visible = 1;
         cmbavCuemov2.Visible = 1;
         edtavCuedsc2_Visible = 1;
         edtavCuecod2_Visible = 1;
         cmbavDynamicfiltersoperator1.Visible = 1;
         cmbavCuemov1.Visible = 1;
         edtavCuedsc1_Visible = 1;
         edtavCuecod1_Visible = 1;
         lblJsdynamicfilters_Caption = "JSDynamicFilters";
         subGrid_Allowcollapsing = 0;
         subGrid_Allowselection = 0;
         edtCueDsc_Link = "";
         subGrid_Sortable = 0;
         subGrid_Header = "";
         subGrid_Class = "GridWithPaginationBar WorkWith";
         subGrid_Backcolorstyle = 0;
         Grid_empowerer_Hastitlesettings = Convert.ToBoolean( -1);
         Innewwindow1_Target = "";
         Innewwindow1_Height = "50";
         Innewwindow1_Width = "50";
         Ddo_grid_Datalistproc = "Contabilidad.PlanCuentasWWGetFilterData";
         Ddo_grid_Datalistfixedvalues = "||1:WWP_TSChecked,2:WWP_TSUnChecked|1:WWP_TSChecked,2:WWP_TSUnChecked|1:WWP_TSChecked,2:WWP_TSUnChecked|||1:ACTIVO,0:INACTIVO";
         Ddo_grid_Allowmultipleselection = "|||||||T";
         Ddo_grid_Datalisttype = "Dynamic|Dynamic|FixedValues|FixedValues|FixedValues|Dynamic|Dynamic|FixedValues";
         Ddo_grid_Includedatalist = "T";
         Ddo_grid_Filtertype = "Character|Character||||Character|Character|";
         Ddo_grid_Includefilter = "T|T||||T|T|";
         Ddo_grid_Includesortasc = "T";
         Ddo_grid_Columnssortvalues = "1|2|3|4|5|6|7|8";
         Ddo_grid_Columnids = "1:CueCod|2:CueDsc|3:CueMov|4:CueMon|5:CueCos|6:CueGasDebe|7:CueGasHaber|8:CueSts";
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
         Form.Caption = " Plan de Cuentas";
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
         setEventMetadata("REFRESH","{handler:'Refresh',iparms:[{av:'GRID_nFirstRecordOnPage'},{av:'GRID_nEOF'},{av:'cmbavDynamicfiltersselector1'},{av:'AV15DynamicFiltersSelector1',fld:'vDYNAMICFILTERSSELECTOR1',pic:''},{av:'AV19DynamicFiltersEnabled2',fld:'vDYNAMICFILTERSENABLED2',pic:''},{av:'cmbavDynamicfiltersselector2'},{av:'AV20DynamicFiltersSelector2',fld:'vDYNAMICFILTERSSELECTOR2',pic:''},{av:'AV24DynamicFiltersEnabled3',fld:'vDYNAMICFILTERSENABLED3',pic:''},{av:'cmbavDynamicfiltersselector3'},{av:'AV25DynamicFiltersSelector3',fld:'vDYNAMICFILTERSSELECTOR3',pic:''},{av:'subGrid_Rows',ctrl:'GRID',prop:'Rows'},{av:'cmbavDynamicfiltersoperator1'},{av:'AV16DynamicFiltersOperator1',fld:'vDYNAMICFILTERSOPERATOR1',pic:'ZZZ9'},{av:'AV84CueCod1',fld:'vCUECOD1',pic:''},{av:'AV17CueDsc1',fld:'vCUEDSC1',pic:''},{av:'cmbavCuemov1'},{av:'AV92CueMov1',fld:'vCUEMOV1',pic:'9'},{av:'cmbavDynamicfiltersoperator2'},{av:'AV21DynamicFiltersOperator2',fld:'vDYNAMICFILTERSOPERATOR2',pic:'ZZZ9'},{av:'AV85CueCod2',fld:'vCUECOD2',pic:''},{av:'AV22CueDsc2',fld:'vCUEDSC2',pic:''},{av:'cmbavCuemov2'},{av:'AV93CueMov2',fld:'vCUEMOV2',pic:'9'},{av:'cmbavDynamicfiltersoperator3'},{av:'AV26DynamicFiltersOperator3',fld:'vDYNAMICFILTERSOPERATOR3',pic:'ZZZ9'},{av:'AV86CueCod3',fld:'vCUECOD3',pic:''},{av:'AV27CueDsc3',fld:'vCUEDSC3',pic:''},{av:'cmbavCuemov3'},{av:'AV94CueMov3',fld:'vCUEMOV3',pic:'9'},{av:'AV97Pgmname',fld:'vPGMNAME',pic:'',hsh:true},{av:'AV34TFCueCod',fld:'vTFCUECOD',pic:''},{av:'AV35TFCueCod_Sel',fld:'vTFCUECOD_SEL',pic:''},{av:'AV36TFCueDsc',fld:'vTFCUEDSC',pic:''},{av:'AV37TFCueDsc_Sel',fld:'vTFCUEDSC_SEL',pic:''},{av:'AV87TFCueMov_Sel',fld:'vTFCUEMOV_SEL',pic:'9'},{av:'AV88TFCueMon_Sel',fld:'vTFCUEMON_SEL',pic:'9'},{av:'AV89TFCueCos_Sel',fld:'vTFCUECOS_SEL',pic:'9'},{av:'AV48TFCueGasDebe',fld:'vTFCUEGASDEBE',pic:''},{av:'AV49TFCueGasDebe_Sel',fld:'vTFCUEGASDEBE_SEL',pic:''},{av:'AV50TFCueGasHaber',fld:'vTFCUEGASHABER',pic:''},{av:'AV51TFCueGasHaber_Sel',fld:'vTFCUEGASHABER_SEL',pic:''},{av:'AV91TFCueSts_Sels',fld:'vTFCUESTS_SELS',pic:''},{av:'AV13OrderedBy',fld:'vORDEREDBY',pic:'ZZZ9'},{av:'AV14OrderedDsc',fld:'vORDEREDDSC',pic:''},{av:'AV10GridState',fld:'vGRIDSTATE',pic:''},{av:'AV30DynamicFiltersIgnoreFirst',fld:'vDYNAMICFILTERSIGNOREFIRST',pic:''},{av:'AV29DynamicFiltersRemoving',fld:'vDYNAMICFILTERSREMOVING',pic:''}]");
         setEventMetadata("REFRESH",",oparms:[{av:'cmbavDynamicfiltersoperator1'},{av:'AV16DynamicFiltersOperator1',fld:'vDYNAMICFILTERSOPERATOR1',pic:'ZZZ9'},{av:'cmbavDynamicfiltersoperator2'},{av:'AV21DynamicFiltersOperator2',fld:'vDYNAMICFILTERSOPERATOR2',pic:'ZZZ9'},{av:'cmbavDynamicfiltersoperator3'},{av:'AV26DynamicFiltersOperator3',fld:'vDYNAMICFILTERSOPERATOR3',pic:'ZZZ9'},{av:'AV78GridCurrentPage',fld:'vGRIDCURRENTPAGE',pic:'ZZZZZZZZZ9'},{av:'AV79GridPageCount',fld:'vGRIDPAGECOUNT',pic:'ZZZZZZZZZ9'},{av:'AV80GridAppliedFilters',fld:'vGRIDAPPLIEDFILTERS',pic:''},{av:'AV10GridState',fld:'vGRIDSTATE',pic:''}]}");
         setEventMetadata("GRIDPAGINATIONBAR.CHANGEPAGE","{handler:'E11292',iparms:[{av:'GRID_nFirstRecordOnPage'},{av:'GRID_nEOF'},{av:'subGrid_Rows',ctrl:'GRID',prop:'Rows'},{av:'cmbavDynamicfiltersselector1'},{av:'AV15DynamicFiltersSelector1',fld:'vDYNAMICFILTERSSELECTOR1',pic:''},{av:'cmbavDynamicfiltersoperator1'},{av:'AV16DynamicFiltersOperator1',fld:'vDYNAMICFILTERSOPERATOR1',pic:'ZZZ9'},{av:'AV84CueCod1',fld:'vCUECOD1',pic:''},{av:'AV17CueDsc1',fld:'vCUEDSC1',pic:''},{av:'cmbavCuemov1'},{av:'AV92CueMov1',fld:'vCUEMOV1',pic:'9'},{av:'cmbavDynamicfiltersselector2'},{av:'AV20DynamicFiltersSelector2',fld:'vDYNAMICFILTERSSELECTOR2',pic:''},{av:'cmbavDynamicfiltersoperator2'},{av:'AV21DynamicFiltersOperator2',fld:'vDYNAMICFILTERSOPERATOR2',pic:'ZZZ9'},{av:'AV85CueCod2',fld:'vCUECOD2',pic:''},{av:'AV22CueDsc2',fld:'vCUEDSC2',pic:''},{av:'cmbavCuemov2'},{av:'AV93CueMov2',fld:'vCUEMOV2',pic:'9'},{av:'cmbavDynamicfiltersselector3'},{av:'AV25DynamicFiltersSelector3',fld:'vDYNAMICFILTERSSELECTOR3',pic:''},{av:'cmbavDynamicfiltersoperator3'},{av:'AV26DynamicFiltersOperator3',fld:'vDYNAMICFILTERSOPERATOR3',pic:'ZZZ9'},{av:'AV86CueCod3',fld:'vCUECOD3',pic:''},{av:'AV27CueDsc3',fld:'vCUEDSC3',pic:''},{av:'cmbavCuemov3'},{av:'AV94CueMov3',fld:'vCUEMOV3',pic:'9'},{av:'AV19DynamicFiltersEnabled2',fld:'vDYNAMICFILTERSENABLED2',pic:''},{av:'AV24DynamicFiltersEnabled3',fld:'vDYNAMICFILTERSENABLED3',pic:''},{av:'AV97Pgmname',fld:'vPGMNAME',pic:'',hsh:true},{av:'AV34TFCueCod',fld:'vTFCUECOD',pic:''},{av:'AV35TFCueCod_Sel',fld:'vTFCUECOD_SEL',pic:''},{av:'AV36TFCueDsc',fld:'vTFCUEDSC',pic:''},{av:'AV37TFCueDsc_Sel',fld:'vTFCUEDSC_SEL',pic:''},{av:'AV87TFCueMov_Sel',fld:'vTFCUEMOV_SEL',pic:'9'},{av:'AV88TFCueMon_Sel',fld:'vTFCUEMON_SEL',pic:'9'},{av:'AV89TFCueCos_Sel',fld:'vTFCUECOS_SEL',pic:'9'},{av:'AV48TFCueGasDebe',fld:'vTFCUEGASDEBE',pic:''},{av:'AV49TFCueGasDebe_Sel',fld:'vTFCUEGASDEBE_SEL',pic:''},{av:'AV50TFCueGasHaber',fld:'vTFCUEGASHABER',pic:''},{av:'AV51TFCueGasHaber_Sel',fld:'vTFCUEGASHABER_SEL',pic:''},{av:'AV91TFCueSts_Sels',fld:'vTFCUESTS_SELS',pic:''},{av:'AV13OrderedBy',fld:'vORDEREDBY',pic:'ZZZ9'},{av:'AV14OrderedDsc',fld:'vORDEREDDSC',pic:''},{av:'AV10GridState',fld:'vGRIDSTATE',pic:''},{av:'AV30DynamicFiltersIgnoreFirst',fld:'vDYNAMICFILTERSIGNOREFIRST',pic:''},{av:'AV29DynamicFiltersRemoving',fld:'vDYNAMICFILTERSREMOVING',pic:''},{av:'Gridpaginationbar_Selectedpage',ctrl:'GRIDPAGINATIONBAR',prop:'SelectedPage'}]");
         setEventMetadata("GRIDPAGINATIONBAR.CHANGEPAGE",",oparms:[]}");
         setEventMetadata("GRIDPAGINATIONBAR.CHANGEROWSPERPAGE","{handler:'E12292',iparms:[{av:'GRID_nFirstRecordOnPage'},{av:'GRID_nEOF'},{av:'subGrid_Rows',ctrl:'GRID',prop:'Rows'},{av:'cmbavDynamicfiltersselector1'},{av:'AV15DynamicFiltersSelector1',fld:'vDYNAMICFILTERSSELECTOR1',pic:''},{av:'cmbavDynamicfiltersoperator1'},{av:'AV16DynamicFiltersOperator1',fld:'vDYNAMICFILTERSOPERATOR1',pic:'ZZZ9'},{av:'AV84CueCod1',fld:'vCUECOD1',pic:''},{av:'AV17CueDsc1',fld:'vCUEDSC1',pic:''},{av:'cmbavCuemov1'},{av:'AV92CueMov1',fld:'vCUEMOV1',pic:'9'},{av:'cmbavDynamicfiltersselector2'},{av:'AV20DynamicFiltersSelector2',fld:'vDYNAMICFILTERSSELECTOR2',pic:''},{av:'cmbavDynamicfiltersoperator2'},{av:'AV21DynamicFiltersOperator2',fld:'vDYNAMICFILTERSOPERATOR2',pic:'ZZZ9'},{av:'AV85CueCod2',fld:'vCUECOD2',pic:''},{av:'AV22CueDsc2',fld:'vCUEDSC2',pic:''},{av:'cmbavCuemov2'},{av:'AV93CueMov2',fld:'vCUEMOV2',pic:'9'},{av:'cmbavDynamicfiltersselector3'},{av:'AV25DynamicFiltersSelector3',fld:'vDYNAMICFILTERSSELECTOR3',pic:''},{av:'cmbavDynamicfiltersoperator3'},{av:'AV26DynamicFiltersOperator3',fld:'vDYNAMICFILTERSOPERATOR3',pic:'ZZZ9'},{av:'AV86CueCod3',fld:'vCUECOD3',pic:''},{av:'AV27CueDsc3',fld:'vCUEDSC3',pic:''},{av:'cmbavCuemov3'},{av:'AV94CueMov3',fld:'vCUEMOV3',pic:'9'},{av:'AV19DynamicFiltersEnabled2',fld:'vDYNAMICFILTERSENABLED2',pic:''},{av:'AV24DynamicFiltersEnabled3',fld:'vDYNAMICFILTERSENABLED3',pic:''},{av:'AV97Pgmname',fld:'vPGMNAME',pic:'',hsh:true},{av:'AV34TFCueCod',fld:'vTFCUECOD',pic:''},{av:'AV35TFCueCod_Sel',fld:'vTFCUECOD_SEL',pic:''},{av:'AV36TFCueDsc',fld:'vTFCUEDSC',pic:''},{av:'AV37TFCueDsc_Sel',fld:'vTFCUEDSC_SEL',pic:''},{av:'AV87TFCueMov_Sel',fld:'vTFCUEMOV_SEL',pic:'9'},{av:'AV88TFCueMon_Sel',fld:'vTFCUEMON_SEL',pic:'9'},{av:'AV89TFCueCos_Sel',fld:'vTFCUECOS_SEL',pic:'9'},{av:'AV48TFCueGasDebe',fld:'vTFCUEGASDEBE',pic:''},{av:'AV49TFCueGasDebe_Sel',fld:'vTFCUEGASDEBE_SEL',pic:''},{av:'AV50TFCueGasHaber',fld:'vTFCUEGASHABER',pic:''},{av:'AV51TFCueGasHaber_Sel',fld:'vTFCUEGASHABER_SEL',pic:''},{av:'AV91TFCueSts_Sels',fld:'vTFCUESTS_SELS',pic:''},{av:'AV13OrderedBy',fld:'vORDEREDBY',pic:'ZZZ9'},{av:'AV14OrderedDsc',fld:'vORDEREDDSC',pic:''},{av:'AV10GridState',fld:'vGRIDSTATE',pic:''},{av:'AV30DynamicFiltersIgnoreFirst',fld:'vDYNAMICFILTERSIGNOREFIRST',pic:''},{av:'AV29DynamicFiltersRemoving',fld:'vDYNAMICFILTERSREMOVING',pic:''},{av:'Gridpaginationbar_Rowsperpageselectedvalue',ctrl:'GRIDPAGINATIONBAR',prop:'RowsPerPageSelectedValue'}]");
         setEventMetadata("GRIDPAGINATIONBAR.CHANGEROWSPERPAGE",",oparms:[{av:'subGrid_Rows',ctrl:'GRID',prop:'Rows'}]}");
         setEventMetadata("DDO_GRID.ONOPTIONCLICKED","{handler:'E14292',iparms:[{av:'GRID_nFirstRecordOnPage'},{av:'GRID_nEOF'},{av:'subGrid_Rows',ctrl:'GRID',prop:'Rows'},{av:'cmbavDynamicfiltersselector1'},{av:'AV15DynamicFiltersSelector1',fld:'vDYNAMICFILTERSSELECTOR1',pic:''},{av:'cmbavDynamicfiltersoperator1'},{av:'AV16DynamicFiltersOperator1',fld:'vDYNAMICFILTERSOPERATOR1',pic:'ZZZ9'},{av:'AV84CueCod1',fld:'vCUECOD1',pic:''},{av:'AV17CueDsc1',fld:'vCUEDSC1',pic:''},{av:'cmbavCuemov1'},{av:'AV92CueMov1',fld:'vCUEMOV1',pic:'9'},{av:'cmbavDynamicfiltersselector2'},{av:'AV20DynamicFiltersSelector2',fld:'vDYNAMICFILTERSSELECTOR2',pic:''},{av:'cmbavDynamicfiltersoperator2'},{av:'AV21DynamicFiltersOperator2',fld:'vDYNAMICFILTERSOPERATOR2',pic:'ZZZ9'},{av:'AV85CueCod2',fld:'vCUECOD2',pic:''},{av:'AV22CueDsc2',fld:'vCUEDSC2',pic:''},{av:'cmbavCuemov2'},{av:'AV93CueMov2',fld:'vCUEMOV2',pic:'9'},{av:'cmbavDynamicfiltersselector3'},{av:'AV25DynamicFiltersSelector3',fld:'vDYNAMICFILTERSSELECTOR3',pic:''},{av:'cmbavDynamicfiltersoperator3'},{av:'AV26DynamicFiltersOperator3',fld:'vDYNAMICFILTERSOPERATOR3',pic:'ZZZ9'},{av:'AV86CueCod3',fld:'vCUECOD3',pic:''},{av:'AV27CueDsc3',fld:'vCUEDSC3',pic:''},{av:'cmbavCuemov3'},{av:'AV94CueMov3',fld:'vCUEMOV3',pic:'9'},{av:'AV19DynamicFiltersEnabled2',fld:'vDYNAMICFILTERSENABLED2',pic:''},{av:'AV24DynamicFiltersEnabled3',fld:'vDYNAMICFILTERSENABLED3',pic:''},{av:'AV97Pgmname',fld:'vPGMNAME',pic:'',hsh:true},{av:'AV34TFCueCod',fld:'vTFCUECOD',pic:''},{av:'AV35TFCueCod_Sel',fld:'vTFCUECOD_SEL',pic:''},{av:'AV36TFCueDsc',fld:'vTFCUEDSC',pic:''},{av:'AV37TFCueDsc_Sel',fld:'vTFCUEDSC_SEL',pic:''},{av:'AV87TFCueMov_Sel',fld:'vTFCUEMOV_SEL',pic:'9'},{av:'AV88TFCueMon_Sel',fld:'vTFCUEMON_SEL',pic:'9'},{av:'AV89TFCueCos_Sel',fld:'vTFCUECOS_SEL',pic:'9'},{av:'AV48TFCueGasDebe',fld:'vTFCUEGASDEBE',pic:''},{av:'AV49TFCueGasDebe_Sel',fld:'vTFCUEGASDEBE_SEL',pic:''},{av:'AV50TFCueGasHaber',fld:'vTFCUEGASHABER',pic:''},{av:'AV51TFCueGasHaber_Sel',fld:'vTFCUEGASHABER_SEL',pic:''},{av:'AV91TFCueSts_Sels',fld:'vTFCUESTS_SELS',pic:''},{av:'AV13OrderedBy',fld:'vORDEREDBY',pic:'ZZZ9'},{av:'AV14OrderedDsc',fld:'vORDEREDDSC',pic:''},{av:'AV10GridState',fld:'vGRIDSTATE',pic:''},{av:'AV30DynamicFiltersIgnoreFirst',fld:'vDYNAMICFILTERSIGNOREFIRST',pic:''},{av:'AV29DynamicFiltersRemoving',fld:'vDYNAMICFILTERSREMOVING',pic:''},{av:'Ddo_grid_Activeeventkey',ctrl:'DDO_GRID',prop:'ActiveEventKey'},{av:'Ddo_grid_Selectedvalue_get',ctrl:'DDO_GRID',prop:'SelectedValue_get'},{av:'Ddo_grid_Filteredtext_get',ctrl:'DDO_GRID',prop:'FilteredText_get'},{av:'Ddo_grid_Selectedcolumn',ctrl:'DDO_GRID',prop:'SelectedColumn'}]");
         setEventMetadata("DDO_GRID.ONOPTIONCLICKED",",oparms:[{av:'AV13OrderedBy',fld:'vORDEREDBY',pic:'ZZZ9'},{av:'AV14OrderedDsc',fld:'vORDEREDDSC',pic:''},{av:'AV90TFCueSts_SelsJson',fld:'vTFCUESTS_SELSJSON',pic:''},{av:'AV91TFCueSts_Sels',fld:'vTFCUESTS_SELS',pic:''},{av:'AV50TFCueGasHaber',fld:'vTFCUEGASHABER',pic:''},{av:'AV51TFCueGasHaber_Sel',fld:'vTFCUEGASHABER_SEL',pic:''},{av:'AV48TFCueGasDebe',fld:'vTFCUEGASDEBE',pic:''},{av:'AV49TFCueGasDebe_Sel',fld:'vTFCUEGASDEBE_SEL',pic:''},{av:'AV89TFCueCos_Sel',fld:'vTFCUECOS_SEL',pic:'9'},{av:'AV88TFCueMon_Sel',fld:'vTFCUEMON_SEL',pic:'9'},{av:'AV87TFCueMov_Sel',fld:'vTFCUEMOV_SEL',pic:'9'},{av:'AV36TFCueDsc',fld:'vTFCUEDSC',pic:''},{av:'AV37TFCueDsc_Sel',fld:'vTFCUEDSC_SEL',pic:''},{av:'AV34TFCueCod',fld:'vTFCUECOD',pic:''},{av:'AV35TFCueCod_Sel',fld:'vTFCUECOD_SEL',pic:''},{av:'Ddo_grid_Sortedstatus',ctrl:'DDO_GRID',prop:'SortedStatus'}]}");
         setEventMetadata("GRID.LOAD","{handler:'E26292',iparms:[{av:'A91CueCod',fld:'CUECOD',pic:'',hsh:true}]");
         setEventMetadata("GRID.LOAD",",oparms:[{av:'cmbavGridactions'},{av:'AV81GridActions',fld:'vGRIDACTIONS',pic:'ZZZ9'},{av:'edtCueDsc_Link',ctrl:'CUEDSC',prop:'Link'}]}");
         setEventMetadata("'ADDDYNAMICFILTERS1'","{handler:'E19292',iparms:[{av:'GRID_nFirstRecordOnPage'},{av:'GRID_nEOF'},{av:'subGrid_Rows',ctrl:'GRID',prop:'Rows'},{av:'cmbavDynamicfiltersselector1'},{av:'AV15DynamicFiltersSelector1',fld:'vDYNAMICFILTERSSELECTOR1',pic:''},{av:'cmbavDynamicfiltersoperator1'},{av:'AV16DynamicFiltersOperator1',fld:'vDYNAMICFILTERSOPERATOR1',pic:'ZZZ9'},{av:'AV84CueCod1',fld:'vCUECOD1',pic:''},{av:'AV17CueDsc1',fld:'vCUEDSC1',pic:''},{av:'cmbavCuemov1'},{av:'AV92CueMov1',fld:'vCUEMOV1',pic:'9'},{av:'cmbavDynamicfiltersselector2'},{av:'AV20DynamicFiltersSelector2',fld:'vDYNAMICFILTERSSELECTOR2',pic:''},{av:'cmbavDynamicfiltersoperator2'},{av:'AV21DynamicFiltersOperator2',fld:'vDYNAMICFILTERSOPERATOR2',pic:'ZZZ9'},{av:'AV85CueCod2',fld:'vCUECOD2',pic:''},{av:'AV22CueDsc2',fld:'vCUEDSC2',pic:''},{av:'cmbavCuemov2'},{av:'AV93CueMov2',fld:'vCUEMOV2',pic:'9'},{av:'cmbavDynamicfiltersselector3'},{av:'AV25DynamicFiltersSelector3',fld:'vDYNAMICFILTERSSELECTOR3',pic:''},{av:'cmbavDynamicfiltersoperator3'},{av:'AV26DynamicFiltersOperator3',fld:'vDYNAMICFILTERSOPERATOR3',pic:'ZZZ9'},{av:'AV86CueCod3',fld:'vCUECOD3',pic:''},{av:'AV27CueDsc3',fld:'vCUEDSC3',pic:''},{av:'cmbavCuemov3'},{av:'AV94CueMov3',fld:'vCUEMOV3',pic:'9'},{av:'AV19DynamicFiltersEnabled2',fld:'vDYNAMICFILTERSENABLED2',pic:''},{av:'AV24DynamicFiltersEnabled3',fld:'vDYNAMICFILTERSENABLED3',pic:''},{av:'AV97Pgmname',fld:'vPGMNAME',pic:'',hsh:true},{av:'AV34TFCueCod',fld:'vTFCUECOD',pic:''},{av:'AV35TFCueCod_Sel',fld:'vTFCUECOD_SEL',pic:''},{av:'AV36TFCueDsc',fld:'vTFCUEDSC',pic:''},{av:'AV37TFCueDsc_Sel',fld:'vTFCUEDSC_SEL',pic:''},{av:'AV87TFCueMov_Sel',fld:'vTFCUEMOV_SEL',pic:'9'},{av:'AV88TFCueMon_Sel',fld:'vTFCUEMON_SEL',pic:'9'},{av:'AV89TFCueCos_Sel',fld:'vTFCUECOS_SEL',pic:'9'},{av:'AV48TFCueGasDebe',fld:'vTFCUEGASDEBE',pic:''},{av:'AV49TFCueGasDebe_Sel',fld:'vTFCUEGASDEBE_SEL',pic:''},{av:'AV50TFCueGasHaber',fld:'vTFCUEGASHABER',pic:''},{av:'AV51TFCueGasHaber_Sel',fld:'vTFCUEGASHABER_SEL',pic:''},{av:'AV91TFCueSts_Sels',fld:'vTFCUESTS_SELS',pic:''},{av:'AV13OrderedBy',fld:'vORDEREDBY',pic:'ZZZ9'},{av:'AV14OrderedDsc',fld:'vORDEREDDSC',pic:''},{av:'AV10GridState',fld:'vGRIDSTATE',pic:''},{av:'AV30DynamicFiltersIgnoreFirst',fld:'vDYNAMICFILTERSIGNOREFIRST',pic:''},{av:'AV29DynamicFiltersRemoving',fld:'vDYNAMICFILTERSREMOVING',pic:''}]");
         setEventMetadata("'ADDDYNAMICFILTERS1'",",oparms:[{av:'AV19DynamicFiltersEnabled2',fld:'vDYNAMICFILTERSENABLED2',pic:''},{av:'imgAdddynamicfilters1_Visible',ctrl:'ADDDYNAMICFILTERS1',prop:'Visible'},{av:'imgRemovedynamicfilters1_Visible',ctrl:'REMOVEDYNAMICFILTERS1',prop:'Visible'},{av:'cmbavDynamicfiltersoperator1'},{av:'AV16DynamicFiltersOperator1',fld:'vDYNAMICFILTERSOPERATOR1',pic:'ZZZ9'},{av:'cmbavDynamicfiltersoperator2'},{av:'AV21DynamicFiltersOperator2',fld:'vDYNAMICFILTERSOPERATOR2',pic:'ZZZ9'},{av:'cmbavDynamicfiltersoperator3'},{av:'AV26DynamicFiltersOperator3',fld:'vDYNAMICFILTERSOPERATOR3',pic:'ZZZ9'},{av:'AV78GridCurrentPage',fld:'vGRIDCURRENTPAGE',pic:'ZZZZZZZZZ9'},{av:'AV79GridPageCount',fld:'vGRIDPAGECOUNT',pic:'ZZZZZZZZZ9'},{av:'AV80GridAppliedFilters',fld:'vGRIDAPPLIEDFILTERS',pic:''},{av:'AV10GridState',fld:'vGRIDSTATE',pic:''}]}");
         setEventMetadata("'REMOVEDYNAMICFILTERS1'","{handler:'E15292',iparms:[{av:'GRID_nFirstRecordOnPage'},{av:'GRID_nEOF'},{av:'subGrid_Rows',ctrl:'GRID',prop:'Rows'},{av:'cmbavDynamicfiltersselector1'},{av:'AV15DynamicFiltersSelector1',fld:'vDYNAMICFILTERSSELECTOR1',pic:''},{av:'cmbavDynamicfiltersoperator1'},{av:'AV16DynamicFiltersOperator1',fld:'vDYNAMICFILTERSOPERATOR1',pic:'ZZZ9'},{av:'AV84CueCod1',fld:'vCUECOD1',pic:''},{av:'AV17CueDsc1',fld:'vCUEDSC1',pic:''},{av:'cmbavCuemov1'},{av:'AV92CueMov1',fld:'vCUEMOV1',pic:'9'},{av:'cmbavDynamicfiltersselector2'},{av:'AV20DynamicFiltersSelector2',fld:'vDYNAMICFILTERSSELECTOR2',pic:''},{av:'cmbavDynamicfiltersoperator2'},{av:'AV21DynamicFiltersOperator2',fld:'vDYNAMICFILTERSOPERATOR2',pic:'ZZZ9'},{av:'AV85CueCod2',fld:'vCUECOD2',pic:''},{av:'AV22CueDsc2',fld:'vCUEDSC2',pic:''},{av:'cmbavCuemov2'},{av:'AV93CueMov2',fld:'vCUEMOV2',pic:'9'},{av:'cmbavDynamicfiltersselector3'},{av:'AV25DynamicFiltersSelector3',fld:'vDYNAMICFILTERSSELECTOR3',pic:''},{av:'cmbavDynamicfiltersoperator3'},{av:'AV26DynamicFiltersOperator3',fld:'vDYNAMICFILTERSOPERATOR3',pic:'ZZZ9'},{av:'AV86CueCod3',fld:'vCUECOD3',pic:''},{av:'AV27CueDsc3',fld:'vCUEDSC3',pic:''},{av:'cmbavCuemov3'},{av:'AV94CueMov3',fld:'vCUEMOV3',pic:'9'},{av:'AV19DynamicFiltersEnabled2',fld:'vDYNAMICFILTERSENABLED2',pic:''},{av:'AV24DynamicFiltersEnabled3',fld:'vDYNAMICFILTERSENABLED3',pic:''},{av:'AV97Pgmname',fld:'vPGMNAME',pic:'',hsh:true},{av:'AV34TFCueCod',fld:'vTFCUECOD',pic:''},{av:'AV35TFCueCod_Sel',fld:'vTFCUECOD_SEL',pic:''},{av:'AV36TFCueDsc',fld:'vTFCUEDSC',pic:''},{av:'AV37TFCueDsc_Sel',fld:'vTFCUEDSC_SEL',pic:''},{av:'AV87TFCueMov_Sel',fld:'vTFCUEMOV_SEL',pic:'9'},{av:'AV88TFCueMon_Sel',fld:'vTFCUEMON_SEL',pic:'9'},{av:'AV89TFCueCos_Sel',fld:'vTFCUECOS_SEL',pic:'9'},{av:'AV48TFCueGasDebe',fld:'vTFCUEGASDEBE',pic:''},{av:'AV49TFCueGasDebe_Sel',fld:'vTFCUEGASDEBE_SEL',pic:''},{av:'AV50TFCueGasHaber',fld:'vTFCUEGASHABER',pic:''},{av:'AV51TFCueGasHaber_Sel',fld:'vTFCUEGASHABER_SEL',pic:''},{av:'AV91TFCueSts_Sels',fld:'vTFCUESTS_SELS',pic:''},{av:'AV13OrderedBy',fld:'vORDEREDBY',pic:'ZZZ9'},{av:'AV14OrderedDsc',fld:'vORDEREDDSC',pic:''},{av:'AV10GridState',fld:'vGRIDSTATE',pic:''},{av:'AV30DynamicFiltersIgnoreFirst',fld:'vDYNAMICFILTERSIGNOREFIRST',pic:''},{av:'AV29DynamicFiltersRemoving',fld:'vDYNAMICFILTERSREMOVING',pic:''}]");
         setEventMetadata("'REMOVEDYNAMICFILTERS1'",",oparms:[{av:'AV29DynamicFiltersRemoving',fld:'vDYNAMICFILTERSREMOVING',pic:''},{av:'AV30DynamicFiltersIgnoreFirst',fld:'vDYNAMICFILTERSIGNOREFIRST',pic:''},{av:'AV10GridState',fld:'vGRIDSTATE',pic:''},{av:'AV19DynamicFiltersEnabled2',fld:'vDYNAMICFILTERSENABLED2',pic:''},{av:'cmbavDynamicfiltersselector2'},{av:'AV20DynamicFiltersSelector2',fld:'vDYNAMICFILTERSSELECTOR2',pic:''},{av:'cmbavDynamicfiltersoperator2'},{av:'AV21DynamicFiltersOperator2',fld:'vDYNAMICFILTERSOPERATOR2',pic:'ZZZ9'},{av:'AV85CueCod2',fld:'vCUECOD2',pic:''},{av:'AV24DynamicFiltersEnabled3',fld:'vDYNAMICFILTERSENABLED3',pic:''},{av:'cmbavDynamicfiltersselector3'},{av:'AV25DynamicFiltersSelector3',fld:'vDYNAMICFILTERSSELECTOR3',pic:''},{av:'cmbavDynamicfiltersoperator3'},{av:'AV26DynamicFiltersOperator3',fld:'vDYNAMICFILTERSOPERATOR3',pic:'ZZZ9'},{av:'AV86CueCod3',fld:'vCUECOD3',pic:''},{av:'imgAdddynamicfilters1_Visible',ctrl:'ADDDYNAMICFILTERS1',prop:'Visible'},{av:'imgRemovedynamicfilters1_Visible',ctrl:'REMOVEDYNAMICFILTERS1',prop:'Visible'},{av:'imgAdddynamicfilters2_Visible',ctrl:'ADDDYNAMICFILTERS2',prop:'Visible'},{av:'imgRemovedynamicfilters2_Visible',ctrl:'REMOVEDYNAMICFILTERS2',prop:'Visible'},{av:'cmbavDynamicfiltersselector1'},{av:'AV15DynamicFiltersSelector1',fld:'vDYNAMICFILTERSSELECTOR1',pic:''},{av:'cmbavDynamicfiltersoperator1'},{av:'AV16DynamicFiltersOperator1',fld:'vDYNAMICFILTERSOPERATOR1',pic:'ZZZ9'},{av:'AV84CueCod1',fld:'vCUECOD1',pic:''},{av:'AV17CueDsc1',fld:'vCUEDSC1',pic:''},{av:'cmbavCuemov1'},{av:'AV92CueMov1',fld:'vCUEMOV1',pic:'9'},{av:'lblJsdynamicfilters_Caption',ctrl:'JSDYNAMICFILTERS',prop:'Caption'},{av:'AV22CueDsc2',fld:'vCUEDSC2',pic:''},{av:'cmbavCuemov2'},{av:'AV93CueMov2',fld:'vCUEMOV2',pic:'9'},{av:'AV27CueDsc3',fld:'vCUEDSC3',pic:''},{av:'cmbavCuemov3'},{av:'AV94CueMov3',fld:'vCUEMOV3',pic:'9'},{av:'edtavCuecod2_Visible',ctrl:'vCUECOD2',prop:'Visible'},{av:'edtavCuedsc2_Visible',ctrl:'vCUEDSC2',prop:'Visible'},{av:'edtavCuecod3_Visible',ctrl:'vCUECOD3',prop:'Visible'},{av:'edtavCuedsc3_Visible',ctrl:'vCUEDSC3',prop:'Visible'},{av:'edtavCuecod1_Visible',ctrl:'vCUECOD1',prop:'Visible'},{av:'edtavCuedsc1_Visible',ctrl:'vCUEDSC1',prop:'Visible'},{av:'AV78GridCurrentPage',fld:'vGRIDCURRENTPAGE',pic:'ZZZZZZZZZ9'},{av:'AV79GridPageCount',fld:'vGRIDPAGECOUNT',pic:'ZZZZZZZZZ9'},{av:'AV80GridAppliedFilters',fld:'vGRIDAPPLIEDFILTERS',pic:''}]}");
         setEventMetadata("VDYNAMICFILTERSSELECTOR1.CLICK","{handler:'E20292',iparms:[{av:'cmbavDynamicfiltersselector1'},{av:'AV15DynamicFiltersSelector1',fld:'vDYNAMICFILTERSSELECTOR1',pic:''}]");
         setEventMetadata("VDYNAMICFILTERSSELECTOR1.CLICK",",oparms:[{av:'cmbavDynamicfiltersoperator1'},{av:'AV16DynamicFiltersOperator1',fld:'vDYNAMICFILTERSOPERATOR1',pic:'ZZZ9'},{av:'edtavCuecod1_Visible',ctrl:'vCUECOD1',prop:'Visible'},{av:'edtavCuedsc1_Visible',ctrl:'vCUEDSC1',prop:'Visible'},{av:'cmbavCuemov1'}]}");
         setEventMetadata("'ADDDYNAMICFILTERS2'","{handler:'E21292',iparms:[{av:'GRID_nFirstRecordOnPage'},{av:'GRID_nEOF'},{av:'subGrid_Rows',ctrl:'GRID',prop:'Rows'},{av:'cmbavDynamicfiltersselector1'},{av:'AV15DynamicFiltersSelector1',fld:'vDYNAMICFILTERSSELECTOR1',pic:''},{av:'cmbavDynamicfiltersoperator1'},{av:'AV16DynamicFiltersOperator1',fld:'vDYNAMICFILTERSOPERATOR1',pic:'ZZZ9'},{av:'AV84CueCod1',fld:'vCUECOD1',pic:''},{av:'AV17CueDsc1',fld:'vCUEDSC1',pic:''},{av:'cmbavCuemov1'},{av:'AV92CueMov1',fld:'vCUEMOV1',pic:'9'},{av:'cmbavDynamicfiltersselector2'},{av:'AV20DynamicFiltersSelector2',fld:'vDYNAMICFILTERSSELECTOR2',pic:''},{av:'cmbavDynamicfiltersoperator2'},{av:'AV21DynamicFiltersOperator2',fld:'vDYNAMICFILTERSOPERATOR2',pic:'ZZZ9'},{av:'AV85CueCod2',fld:'vCUECOD2',pic:''},{av:'AV22CueDsc2',fld:'vCUEDSC2',pic:''},{av:'cmbavCuemov2'},{av:'AV93CueMov2',fld:'vCUEMOV2',pic:'9'},{av:'cmbavDynamicfiltersselector3'},{av:'AV25DynamicFiltersSelector3',fld:'vDYNAMICFILTERSSELECTOR3',pic:''},{av:'cmbavDynamicfiltersoperator3'},{av:'AV26DynamicFiltersOperator3',fld:'vDYNAMICFILTERSOPERATOR3',pic:'ZZZ9'},{av:'AV86CueCod3',fld:'vCUECOD3',pic:''},{av:'AV27CueDsc3',fld:'vCUEDSC3',pic:''},{av:'cmbavCuemov3'},{av:'AV94CueMov3',fld:'vCUEMOV3',pic:'9'},{av:'AV19DynamicFiltersEnabled2',fld:'vDYNAMICFILTERSENABLED2',pic:''},{av:'AV24DynamicFiltersEnabled3',fld:'vDYNAMICFILTERSENABLED3',pic:''},{av:'AV97Pgmname',fld:'vPGMNAME',pic:'',hsh:true},{av:'AV34TFCueCod',fld:'vTFCUECOD',pic:''},{av:'AV35TFCueCod_Sel',fld:'vTFCUECOD_SEL',pic:''},{av:'AV36TFCueDsc',fld:'vTFCUEDSC',pic:''},{av:'AV37TFCueDsc_Sel',fld:'vTFCUEDSC_SEL',pic:''},{av:'AV87TFCueMov_Sel',fld:'vTFCUEMOV_SEL',pic:'9'},{av:'AV88TFCueMon_Sel',fld:'vTFCUEMON_SEL',pic:'9'},{av:'AV89TFCueCos_Sel',fld:'vTFCUECOS_SEL',pic:'9'},{av:'AV48TFCueGasDebe',fld:'vTFCUEGASDEBE',pic:''},{av:'AV49TFCueGasDebe_Sel',fld:'vTFCUEGASDEBE_SEL',pic:''},{av:'AV50TFCueGasHaber',fld:'vTFCUEGASHABER',pic:''},{av:'AV51TFCueGasHaber_Sel',fld:'vTFCUEGASHABER_SEL',pic:''},{av:'AV91TFCueSts_Sels',fld:'vTFCUESTS_SELS',pic:''},{av:'AV13OrderedBy',fld:'vORDEREDBY',pic:'ZZZ9'},{av:'AV14OrderedDsc',fld:'vORDEREDDSC',pic:''},{av:'AV10GridState',fld:'vGRIDSTATE',pic:''},{av:'AV30DynamicFiltersIgnoreFirst',fld:'vDYNAMICFILTERSIGNOREFIRST',pic:''},{av:'AV29DynamicFiltersRemoving',fld:'vDYNAMICFILTERSREMOVING',pic:''}]");
         setEventMetadata("'ADDDYNAMICFILTERS2'",",oparms:[{av:'AV24DynamicFiltersEnabled3',fld:'vDYNAMICFILTERSENABLED3',pic:''},{av:'imgAdddynamicfilters2_Visible',ctrl:'ADDDYNAMICFILTERS2',prop:'Visible'},{av:'imgRemovedynamicfilters2_Visible',ctrl:'REMOVEDYNAMICFILTERS2',prop:'Visible'},{av:'cmbavDynamicfiltersoperator1'},{av:'AV16DynamicFiltersOperator1',fld:'vDYNAMICFILTERSOPERATOR1',pic:'ZZZ9'},{av:'cmbavDynamicfiltersoperator2'},{av:'AV21DynamicFiltersOperator2',fld:'vDYNAMICFILTERSOPERATOR2',pic:'ZZZ9'},{av:'cmbavDynamicfiltersoperator3'},{av:'AV26DynamicFiltersOperator3',fld:'vDYNAMICFILTERSOPERATOR3',pic:'ZZZ9'},{av:'AV78GridCurrentPage',fld:'vGRIDCURRENTPAGE',pic:'ZZZZZZZZZ9'},{av:'AV79GridPageCount',fld:'vGRIDPAGECOUNT',pic:'ZZZZZZZZZ9'},{av:'AV80GridAppliedFilters',fld:'vGRIDAPPLIEDFILTERS',pic:''},{av:'AV10GridState',fld:'vGRIDSTATE',pic:''}]}");
         setEventMetadata("'REMOVEDYNAMICFILTERS2'","{handler:'E16292',iparms:[{av:'GRID_nFirstRecordOnPage'},{av:'GRID_nEOF'},{av:'subGrid_Rows',ctrl:'GRID',prop:'Rows'},{av:'cmbavDynamicfiltersselector1'},{av:'AV15DynamicFiltersSelector1',fld:'vDYNAMICFILTERSSELECTOR1',pic:''},{av:'cmbavDynamicfiltersoperator1'},{av:'AV16DynamicFiltersOperator1',fld:'vDYNAMICFILTERSOPERATOR1',pic:'ZZZ9'},{av:'AV84CueCod1',fld:'vCUECOD1',pic:''},{av:'AV17CueDsc1',fld:'vCUEDSC1',pic:''},{av:'cmbavCuemov1'},{av:'AV92CueMov1',fld:'vCUEMOV1',pic:'9'},{av:'cmbavDynamicfiltersselector2'},{av:'AV20DynamicFiltersSelector2',fld:'vDYNAMICFILTERSSELECTOR2',pic:''},{av:'cmbavDynamicfiltersoperator2'},{av:'AV21DynamicFiltersOperator2',fld:'vDYNAMICFILTERSOPERATOR2',pic:'ZZZ9'},{av:'AV85CueCod2',fld:'vCUECOD2',pic:''},{av:'AV22CueDsc2',fld:'vCUEDSC2',pic:''},{av:'cmbavCuemov2'},{av:'AV93CueMov2',fld:'vCUEMOV2',pic:'9'},{av:'cmbavDynamicfiltersselector3'},{av:'AV25DynamicFiltersSelector3',fld:'vDYNAMICFILTERSSELECTOR3',pic:''},{av:'cmbavDynamicfiltersoperator3'},{av:'AV26DynamicFiltersOperator3',fld:'vDYNAMICFILTERSOPERATOR3',pic:'ZZZ9'},{av:'AV86CueCod3',fld:'vCUECOD3',pic:''},{av:'AV27CueDsc3',fld:'vCUEDSC3',pic:''},{av:'cmbavCuemov3'},{av:'AV94CueMov3',fld:'vCUEMOV3',pic:'9'},{av:'AV19DynamicFiltersEnabled2',fld:'vDYNAMICFILTERSENABLED2',pic:''},{av:'AV24DynamicFiltersEnabled3',fld:'vDYNAMICFILTERSENABLED3',pic:''},{av:'AV97Pgmname',fld:'vPGMNAME',pic:'',hsh:true},{av:'AV34TFCueCod',fld:'vTFCUECOD',pic:''},{av:'AV35TFCueCod_Sel',fld:'vTFCUECOD_SEL',pic:''},{av:'AV36TFCueDsc',fld:'vTFCUEDSC',pic:''},{av:'AV37TFCueDsc_Sel',fld:'vTFCUEDSC_SEL',pic:''},{av:'AV87TFCueMov_Sel',fld:'vTFCUEMOV_SEL',pic:'9'},{av:'AV88TFCueMon_Sel',fld:'vTFCUEMON_SEL',pic:'9'},{av:'AV89TFCueCos_Sel',fld:'vTFCUECOS_SEL',pic:'9'},{av:'AV48TFCueGasDebe',fld:'vTFCUEGASDEBE',pic:''},{av:'AV49TFCueGasDebe_Sel',fld:'vTFCUEGASDEBE_SEL',pic:''},{av:'AV50TFCueGasHaber',fld:'vTFCUEGASHABER',pic:''},{av:'AV51TFCueGasHaber_Sel',fld:'vTFCUEGASHABER_SEL',pic:''},{av:'AV91TFCueSts_Sels',fld:'vTFCUESTS_SELS',pic:''},{av:'AV13OrderedBy',fld:'vORDEREDBY',pic:'ZZZ9'},{av:'AV14OrderedDsc',fld:'vORDEREDDSC',pic:''},{av:'AV10GridState',fld:'vGRIDSTATE',pic:''},{av:'AV30DynamicFiltersIgnoreFirst',fld:'vDYNAMICFILTERSIGNOREFIRST',pic:''},{av:'AV29DynamicFiltersRemoving',fld:'vDYNAMICFILTERSREMOVING',pic:''}]");
         setEventMetadata("'REMOVEDYNAMICFILTERS2'",",oparms:[{av:'AV29DynamicFiltersRemoving',fld:'vDYNAMICFILTERSREMOVING',pic:''},{av:'AV19DynamicFiltersEnabled2',fld:'vDYNAMICFILTERSENABLED2',pic:''},{av:'AV10GridState',fld:'vGRIDSTATE',pic:''},{av:'cmbavDynamicfiltersselector2'},{av:'AV20DynamicFiltersSelector2',fld:'vDYNAMICFILTERSSELECTOR2',pic:''},{av:'cmbavDynamicfiltersoperator2'},{av:'AV21DynamicFiltersOperator2',fld:'vDYNAMICFILTERSOPERATOR2',pic:'ZZZ9'},{av:'AV85CueCod2',fld:'vCUECOD2',pic:''},{av:'AV24DynamicFiltersEnabled3',fld:'vDYNAMICFILTERSENABLED3',pic:''},{av:'cmbavDynamicfiltersselector3'},{av:'AV25DynamicFiltersSelector3',fld:'vDYNAMICFILTERSSELECTOR3',pic:''},{av:'cmbavDynamicfiltersoperator3'},{av:'AV26DynamicFiltersOperator3',fld:'vDYNAMICFILTERSOPERATOR3',pic:'ZZZ9'},{av:'AV86CueCod3',fld:'vCUECOD3',pic:''},{av:'imgAdddynamicfilters1_Visible',ctrl:'ADDDYNAMICFILTERS1',prop:'Visible'},{av:'imgRemovedynamicfilters1_Visible',ctrl:'REMOVEDYNAMICFILTERS1',prop:'Visible'},{av:'imgAdddynamicfilters2_Visible',ctrl:'ADDDYNAMICFILTERS2',prop:'Visible'},{av:'imgRemovedynamicfilters2_Visible',ctrl:'REMOVEDYNAMICFILTERS2',prop:'Visible'},{av:'cmbavDynamicfiltersselector1'},{av:'AV15DynamicFiltersSelector1',fld:'vDYNAMICFILTERSSELECTOR1',pic:''},{av:'cmbavDynamicfiltersoperator1'},{av:'AV16DynamicFiltersOperator1',fld:'vDYNAMICFILTERSOPERATOR1',pic:'ZZZ9'},{av:'AV84CueCod1',fld:'vCUECOD1',pic:''},{av:'AV17CueDsc1',fld:'vCUEDSC1',pic:''},{av:'cmbavCuemov1'},{av:'AV92CueMov1',fld:'vCUEMOV1',pic:'9'},{av:'lblJsdynamicfilters_Caption',ctrl:'JSDYNAMICFILTERS',prop:'Caption'},{av:'AV22CueDsc2',fld:'vCUEDSC2',pic:''},{av:'cmbavCuemov2'},{av:'AV93CueMov2',fld:'vCUEMOV2',pic:'9'},{av:'AV27CueDsc3',fld:'vCUEDSC3',pic:''},{av:'cmbavCuemov3'},{av:'AV94CueMov3',fld:'vCUEMOV3',pic:'9'},{av:'edtavCuecod2_Visible',ctrl:'vCUECOD2',prop:'Visible'},{av:'edtavCuedsc2_Visible',ctrl:'vCUEDSC2',prop:'Visible'},{av:'edtavCuecod3_Visible',ctrl:'vCUECOD3',prop:'Visible'},{av:'edtavCuedsc3_Visible',ctrl:'vCUEDSC3',prop:'Visible'},{av:'edtavCuecod1_Visible',ctrl:'vCUECOD1',prop:'Visible'},{av:'edtavCuedsc1_Visible',ctrl:'vCUEDSC1',prop:'Visible'},{av:'AV78GridCurrentPage',fld:'vGRIDCURRENTPAGE',pic:'ZZZZZZZZZ9'},{av:'AV79GridPageCount',fld:'vGRIDPAGECOUNT',pic:'ZZZZZZZZZ9'},{av:'AV80GridAppliedFilters',fld:'vGRIDAPPLIEDFILTERS',pic:''}]}");
         setEventMetadata("VDYNAMICFILTERSSELECTOR2.CLICK","{handler:'E22292',iparms:[{av:'cmbavDynamicfiltersselector2'},{av:'AV20DynamicFiltersSelector2',fld:'vDYNAMICFILTERSSELECTOR2',pic:''}]");
         setEventMetadata("VDYNAMICFILTERSSELECTOR2.CLICK",",oparms:[{av:'cmbavDynamicfiltersoperator2'},{av:'AV21DynamicFiltersOperator2',fld:'vDYNAMICFILTERSOPERATOR2',pic:'ZZZ9'},{av:'edtavCuecod2_Visible',ctrl:'vCUECOD2',prop:'Visible'},{av:'edtavCuedsc2_Visible',ctrl:'vCUEDSC2',prop:'Visible'},{av:'cmbavCuemov2'}]}");
         setEventMetadata("'REMOVEDYNAMICFILTERS3'","{handler:'E17292',iparms:[{av:'GRID_nFirstRecordOnPage'},{av:'GRID_nEOF'},{av:'subGrid_Rows',ctrl:'GRID',prop:'Rows'},{av:'cmbavDynamicfiltersselector1'},{av:'AV15DynamicFiltersSelector1',fld:'vDYNAMICFILTERSSELECTOR1',pic:''},{av:'cmbavDynamicfiltersoperator1'},{av:'AV16DynamicFiltersOperator1',fld:'vDYNAMICFILTERSOPERATOR1',pic:'ZZZ9'},{av:'AV84CueCod1',fld:'vCUECOD1',pic:''},{av:'AV17CueDsc1',fld:'vCUEDSC1',pic:''},{av:'cmbavCuemov1'},{av:'AV92CueMov1',fld:'vCUEMOV1',pic:'9'},{av:'cmbavDynamicfiltersselector2'},{av:'AV20DynamicFiltersSelector2',fld:'vDYNAMICFILTERSSELECTOR2',pic:''},{av:'cmbavDynamicfiltersoperator2'},{av:'AV21DynamicFiltersOperator2',fld:'vDYNAMICFILTERSOPERATOR2',pic:'ZZZ9'},{av:'AV85CueCod2',fld:'vCUECOD2',pic:''},{av:'AV22CueDsc2',fld:'vCUEDSC2',pic:''},{av:'cmbavCuemov2'},{av:'AV93CueMov2',fld:'vCUEMOV2',pic:'9'},{av:'cmbavDynamicfiltersselector3'},{av:'AV25DynamicFiltersSelector3',fld:'vDYNAMICFILTERSSELECTOR3',pic:''},{av:'cmbavDynamicfiltersoperator3'},{av:'AV26DynamicFiltersOperator3',fld:'vDYNAMICFILTERSOPERATOR3',pic:'ZZZ9'},{av:'AV86CueCod3',fld:'vCUECOD3',pic:''},{av:'AV27CueDsc3',fld:'vCUEDSC3',pic:''},{av:'cmbavCuemov3'},{av:'AV94CueMov3',fld:'vCUEMOV3',pic:'9'},{av:'AV19DynamicFiltersEnabled2',fld:'vDYNAMICFILTERSENABLED2',pic:''},{av:'AV24DynamicFiltersEnabled3',fld:'vDYNAMICFILTERSENABLED3',pic:''},{av:'AV97Pgmname',fld:'vPGMNAME',pic:'',hsh:true},{av:'AV34TFCueCod',fld:'vTFCUECOD',pic:''},{av:'AV35TFCueCod_Sel',fld:'vTFCUECOD_SEL',pic:''},{av:'AV36TFCueDsc',fld:'vTFCUEDSC',pic:''},{av:'AV37TFCueDsc_Sel',fld:'vTFCUEDSC_SEL',pic:''},{av:'AV87TFCueMov_Sel',fld:'vTFCUEMOV_SEL',pic:'9'},{av:'AV88TFCueMon_Sel',fld:'vTFCUEMON_SEL',pic:'9'},{av:'AV89TFCueCos_Sel',fld:'vTFCUECOS_SEL',pic:'9'},{av:'AV48TFCueGasDebe',fld:'vTFCUEGASDEBE',pic:''},{av:'AV49TFCueGasDebe_Sel',fld:'vTFCUEGASDEBE_SEL',pic:''},{av:'AV50TFCueGasHaber',fld:'vTFCUEGASHABER',pic:''},{av:'AV51TFCueGasHaber_Sel',fld:'vTFCUEGASHABER_SEL',pic:''},{av:'AV91TFCueSts_Sels',fld:'vTFCUESTS_SELS',pic:''},{av:'AV13OrderedBy',fld:'vORDEREDBY',pic:'ZZZ9'},{av:'AV14OrderedDsc',fld:'vORDEREDDSC',pic:''},{av:'AV10GridState',fld:'vGRIDSTATE',pic:''},{av:'AV30DynamicFiltersIgnoreFirst',fld:'vDYNAMICFILTERSIGNOREFIRST',pic:''},{av:'AV29DynamicFiltersRemoving',fld:'vDYNAMICFILTERSREMOVING',pic:''}]");
         setEventMetadata("'REMOVEDYNAMICFILTERS3'",",oparms:[{av:'AV29DynamicFiltersRemoving',fld:'vDYNAMICFILTERSREMOVING',pic:''},{av:'AV24DynamicFiltersEnabled3',fld:'vDYNAMICFILTERSENABLED3',pic:''},{av:'AV10GridState',fld:'vGRIDSTATE',pic:''},{av:'AV19DynamicFiltersEnabled2',fld:'vDYNAMICFILTERSENABLED2',pic:''},{av:'cmbavDynamicfiltersselector2'},{av:'AV20DynamicFiltersSelector2',fld:'vDYNAMICFILTERSSELECTOR2',pic:''},{av:'cmbavDynamicfiltersoperator2'},{av:'AV21DynamicFiltersOperator2',fld:'vDYNAMICFILTERSOPERATOR2',pic:'ZZZ9'},{av:'AV85CueCod2',fld:'vCUECOD2',pic:''},{av:'cmbavDynamicfiltersselector3'},{av:'AV25DynamicFiltersSelector3',fld:'vDYNAMICFILTERSSELECTOR3',pic:''},{av:'cmbavDynamicfiltersoperator3'},{av:'AV26DynamicFiltersOperator3',fld:'vDYNAMICFILTERSOPERATOR3',pic:'ZZZ9'},{av:'AV86CueCod3',fld:'vCUECOD3',pic:''},{av:'imgAdddynamicfilters1_Visible',ctrl:'ADDDYNAMICFILTERS1',prop:'Visible'},{av:'imgRemovedynamicfilters1_Visible',ctrl:'REMOVEDYNAMICFILTERS1',prop:'Visible'},{av:'imgAdddynamicfilters2_Visible',ctrl:'ADDDYNAMICFILTERS2',prop:'Visible'},{av:'imgRemovedynamicfilters2_Visible',ctrl:'REMOVEDYNAMICFILTERS2',prop:'Visible'},{av:'cmbavDynamicfiltersselector1'},{av:'AV15DynamicFiltersSelector1',fld:'vDYNAMICFILTERSSELECTOR1',pic:''},{av:'cmbavDynamicfiltersoperator1'},{av:'AV16DynamicFiltersOperator1',fld:'vDYNAMICFILTERSOPERATOR1',pic:'ZZZ9'},{av:'AV84CueCod1',fld:'vCUECOD1',pic:''},{av:'AV17CueDsc1',fld:'vCUEDSC1',pic:''},{av:'cmbavCuemov1'},{av:'AV92CueMov1',fld:'vCUEMOV1',pic:'9'},{av:'lblJsdynamicfilters_Caption',ctrl:'JSDYNAMICFILTERS',prop:'Caption'},{av:'AV22CueDsc2',fld:'vCUEDSC2',pic:''},{av:'cmbavCuemov2'},{av:'AV93CueMov2',fld:'vCUEMOV2',pic:'9'},{av:'AV27CueDsc3',fld:'vCUEDSC3',pic:''},{av:'cmbavCuemov3'},{av:'AV94CueMov3',fld:'vCUEMOV3',pic:'9'},{av:'edtavCuecod2_Visible',ctrl:'vCUECOD2',prop:'Visible'},{av:'edtavCuedsc2_Visible',ctrl:'vCUEDSC2',prop:'Visible'},{av:'edtavCuecod3_Visible',ctrl:'vCUECOD3',prop:'Visible'},{av:'edtavCuedsc3_Visible',ctrl:'vCUEDSC3',prop:'Visible'},{av:'edtavCuecod1_Visible',ctrl:'vCUECOD1',prop:'Visible'},{av:'edtavCuedsc1_Visible',ctrl:'vCUEDSC1',prop:'Visible'},{av:'AV78GridCurrentPage',fld:'vGRIDCURRENTPAGE',pic:'ZZZZZZZZZ9'},{av:'AV79GridPageCount',fld:'vGRIDPAGECOUNT',pic:'ZZZZZZZZZ9'},{av:'AV80GridAppliedFilters',fld:'vGRIDAPPLIEDFILTERS',pic:''}]}");
         setEventMetadata("VDYNAMICFILTERSSELECTOR3.CLICK","{handler:'E23292',iparms:[{av:'cmbavDynamicfiltersselector3'},{av:'AV25DynamicFiltersSelector3',fld:'vDYNAMICFILTERSSELECTOR3',pic:''}]");
         setEventMetadata("VDYNAMICFILTERSSELECTOR3.CLICK",",oparms:[{av:'cmbavDynamicfiltersoperator3'},{av:'AV26DynamicFiltersOperator3',fld:'vDYNAMICFILTERSOPERATOR3',pic:'ZZZ9'},{av:'edtavCuecod3_Visible',ctrl:'vCUECOD3',prop:'Visible'},{av:'edtavCuedsc3_Visible',ctrl:'vCUEDSC3',prop:'Visible'},{av:'cmbavCuemov3'}]}");
         setEventMetadata("VGRIDACTIONS.CLICK","{handler:'E27292',iparms:[{av:'cmbavGridactions'},{av:'AV81GridActions',fld:'vGRIDACTIONS',pic:'ZZZ9'},{av:'A91CueCod',fld:'CUECOD',pic:'',hsh:true}]");
         setEventMetadata("VGRIDACTIONS.CLICK",",oparms:[{av:'cmbavGridactions'},{av:'AV81GridActions',fld:'vGRIDACTIONS',pic:'ZZZ9'}]}");
         setEventMetadata("'DOINSERT'","{handler:'E18292',iparms:[{av:'A91CueCod',fld:'CUECOD',pic:'',hsh:true}]");
         setEventMetadata("'DOINSERT'",",oparms:[]}");
         setEventMetadata("DDO_AGEXPORT.ONOPTIONCLICKED","{handler:'E13292',iparms:[{av:'Ddo_agexport_Activeeventkey',ctrl:'DDO_AGEXPORT',prop:'ActiveEventKey'},{av:'AV97Pgmname',fld:'vPGMNAME',pic:'',hsh:true},{av:'AV91TFCueSts_Sels',fld:'vTFCUESTS_SELS',pic:''},{av:'AV35TFCueCod_Sel',fld:'vTFCUECOD_SEL',pic:''},{av:'AV37TFCueDsc_Sel',fld:'vTFCUEDSC_SEL',pic:''},{av:'AV87TFCueMov_Sel',fld:'vTFCUEMOV_SEL',pic:'9'},{av:'AV88TFCueMon_Sel',fld:'vTFCUEMON_SEL',pic:'9'},{av:'AV89TFCueCos_Sel',fld:'vTFCUECOS_SEL',pic:'9'},{av:'AV49TFCueGasDebe_Sel',fld:'vTFCUEGASDEBE_SEL',pic:''},{av:'AV51TFCueGasHaber_Sel',fld:'vTFCUEGASHABER_SEL',pic:''},{av:'AV90TFCueSts_SelsJson',fld:'vTFCUESTS_SELSJSON',pic:''},{av:'AV34TFCueCod',fld:'vTFCUECOD',pic:''},{av:'AV36TFCueDsc',fld:'vTFCUEDSC',pic:''},{av:'AV48TFCueGasDebe',fld:'vTFCUEGASDEBE',pic:''},{av:'AV50TFCueGasHaber',fld:'vTFCUEGASHABER',pic:''},{av:'AV13OrderedBy',fld:'vORDEREDBY',pic:'ZZZ9'},{av:'AV14OrderedDsc',fld:'vORDEREDDSC',pic:''},{av:'AV10GridState',fld:'vGRIDSTATE',pic:''},{av:'AV29DynamicFiltersRemoving',fld:'vDYNAMICFILTERSREMOVING',pic:''},{av:'cmbavDynamicfiltersselector1'},{av:'AV15DynamicFiltersSelector1',fld:'vDYNAMICFILTERSSELECTOR1',pic:''},{av:'cmbavDynamicfiltersselector2'},{av:'AV20DynamicFiltersSelector2',fld:'vDYNAMICFILTERSSELECTOR2',pic:''},{av:'cmbavDynamicfiltersselector3'},{av:'AV25DynamicFiltersSelector3',fld:'vDYNAMICFILTERSSELECTOR3',pic:''}]");
         setEventMetadata("DDO_AGEXPORT.ONOPTIONCLICKED",",oparms:[{av:'Innewwindow1_Target',ctrl:'INNEWWINDOW1',prop:'Target'},{av:'Innewwindow1_Height',ctrl:'INNEWWINDOW1',prop:'Height'},{av:'Innewwindow1_Width',ctrl:'INNEWWINDOW1',prop:'Width'},{av:'AV10GridState',fld:'vGRIDSTATE',pic:''},{av:'AV13OrderedBy',fld:'vORDEREDBY',pic:'ZZZ9'},{av:'AV14OrderedDsc',fld:'vORDEREDDSC',pic:''},{av:'AV90TFCueSts_SelsJson',fld:'vTFCUESTS_SELSJSON',pic:''},{av:'AV91TFCueSts_Sels',fld:'vTFCUESTS_SELS',pic:''},{av:'AV51TFCueGasHaber_Sel',fld:'vTFCUEGASHABER_SEL',pic:''},{av:'AV50TFCueGasHaber',fld:'vTFCUEGASHABER',pic:''},{av:'AV49TFCueGasDebe_Sel',fld:'vTFCUEGASDEBE_SEL',pic:''},{av:'AV48TFCueGasDebe',fld:'vTFCUEGASDEBE',pic:''},{av:'AV89TFCueCos_Sel',fld:'vTFCUECOS_SEL',pic:'9'},{av:'AV88TFCueMon_Sel',fld:'vTFCUEMON_SEL',pic:'9'},{av:'AV87TFCueMov_Sel',fld:'vTFCUEMOV_SEL',pic:'9'},{av:'AV37TFCueDsc_Sel',fld:'vTFCUEDSC_SEL',pic:''},{av:'AV36TFCueDsc',fld:'vTFCUEDSC',pic:''},{av:'AV35TFCueCod_Sel',fld:'vTFCUECOD_SEL',pic:''},{av:'AV34TFCueCod',fld:'vTFCUECOD',pic:''},{av:'Ddo_grid_Selectedvalue_set',ctrl:'DDO_GRID',prop:'SelectedValue_set'},{av:'Ddo_grid_Filteredtext_set',ctrl:'DDO_GRID',prop:'FilteredText_set'},{av:'subGrid_Rows',ctrl:'GRID',prop:'Rows'},{av:'GRID_nFirstRecordOnPage'},{av:'GRID_nEOF'},{av:'cmbavDynamicfiltersselector1'},{av:'AV15DynamicFiltersSelector1',fld:'vDYNAMICFILTERSSELECTOR1',pic:''},{av:'cmbavDynamicfiltersoperator1'},{av:'AV16DynamicFiltersOperator1',fld:'vDYNAMICFILTERSOPERATOR1',pic:'ZZZ9'},{av:'AV84CueCod1',fld:'vCUECOD1',pic:''},{av:'AV17CueDsc1',fld:'vCUEDSC1',pic:''},{av:'cmbavCuemov1'},{av:'AV92CueMov1',fld:'vCUEMOV1',pic:'9'},{av:'cmbavDynamicfiltersselector2'},{av:'AV20DynamicFiltersSelector2',fld:'vDYNAMICFILTERSSELECTOR2',pic:''},{av:'cmbavDynamicfiltersoperator2'},{av:'AV21DynamicFiltersOperator2',fld:'vDYNAMICFILTERSOPERATOR2',pic:'ZZZ9'},{av:'AV85CueCod2',fld:'vCUECOD2',pic:''},{av:'AV22CueDsc2',fld:'vCUEDSC2',pic:''},{av:'cmbavCuemov2'},{av:'AV93CueMov2',fld:'vCUEMOV2',pic:'9'},{av:'cmbavDynamicfiltersselector3'},{av:'AV25DynamicFiltersSelector3',fld:'vDYNAMICFILTERSSELECTOR3',pic:''},{av:'cmbavDynamicfiltersoperator3'},{av:'AV26DynamicFiltersOperator3',fld:'vDYNAMICFILTERSOPERATOR3',pic:'ZZZ9'},{av:'AV86CueCod3',fld:'vCUECOD3',pic:''},{av:'AV27CueDsc3',fld:'vCUEDSC3',pic:''},{av:'cmbavCuemov3'},{av:'AV94CueMov3',fld:'vCUEMOV3',pic:'9'},{av:'AV19DynamicFiltersEnabled2',fld:'vDYNAMICFILTERSENABLED2',pic:''},{av:'AV24DynamicFiltersEnabled3',fld:'vDYNAMICFILTERSENABLED3',pic:''},{av:'AV97Pgmname',fld:'vPGMNAME',pic:'',hsh:true},{av:'AV30DynamicFiltersIgnoreFirst',fld:'vDYNAMICFILTERSIGNOREFIRST',pic:''},{av:'AV29DynamicFiltersRemoving',fld:'vDYNAMICFILTERSREMOVING',pic:''},{av:'Ddo_grid_Sortedstatus',ctrl:'DDO_GRID',prop:'SortedStatus'},{av:'imgAdddynamicfilters1_Visible',ctrl:'ADDDYNAMICFILTERS1',prop:'Visible'},{av:'imgRemovedynamicfilters1_Visible',ctrl:'REMOVEDYNAMICFILTERS1',prop:'Visible'},{av:'imgAdddynamicfilters2_Visible',ctrl:'ADDDYNAMICFILTERS2',prop:'Visible'},{av:'imgRemovedynamicfilters2_Visible',ctrl:'REMOVEDYNAMICFILTERS2',prop:'Visible'},{av:'lblJsdynamicfilters_Caption',ctrl:'JSDYNAMICFILTERS',prop:'Caption'},{av:'edtavCuecod1_Visible',ctrl:'vCUECOD1',prop:'Visible'},{av:'edtavCuedsc1_Visible',ctrl:'vCUEDSC1',prop:'Visible'},{av:'edtavCuecod2_Visible',ctrl:'vCUECOD2',prop:'Visible'},{av:'edtavCuedsc2_Visible',ctrl:'vCUEDSC2',prop:'Visible'},{av:'edtavCuecod3_Visible',ctrl:'vCUECOD3',prop:'Visible'},{av:'edtavCuedsc3_Visible',ctrl:'vCUEDSC3',prop:'Visible'}]}");
         setEventMetadata("NULL","{handler:'Valid_Cuests',iparms:[]");
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
         AV84CueCod1 = "";
         AV17CueDsc1 = "";
         AV20DynamicFiltersSelector2 = "";
         AV85CueCod2 = "";
         AV22CueDsc2 = "";
         AV25DynamicFiltersSelector3 = "";
         AV86CueCod3 = "";
         AV27CueDsc3 = "";
         AV97Pgmname = "";
         AV34TFCueCod = "";
         AV35TFCueCod_Sel = "";
         AV36TFCueDsc = "";
         AV37TFCueDsc_Sel = "";
         AV48TFCueGasDebe = "";
         AV49TFCueGasDebe_Sel = "";
         AV50TFCueGasHaber = "";
         AV51TFCueGasHaber_Sel = "";
         AV91TFCueSts_Sels = new GxSimpleCollection<short>();
         AV10GridState = new GeneXus.Programs.wwpbaseobjects.SdtWWPGridState(context);
         sDynURL = "";
         FormProcess = "";
         bodyStyle = "";
         GXKey = "";
         AV80GridAppliedFilters = "";
         AV82AGExportData = new GXBaseCollection<GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTDropDownOptionsData_Item>( context, "Item", "");
         AV76DDO_TitleSettingsIcons = new GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTDropDownOptionsTitleSettingsIcons(context);
         AV90TFCueSts_SelsJson = "";
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
         A91CueCod = "";
         A860CueDsc = "";
         A109CueGasDebe = "";
         A110CueGasHaber = "";
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
         AV126Contabilidad_plancuentaswwds_29_tfcuests_sels = new GxSimpleCollection<short>();
         scmdbuf = "";
         lV100Contabilidad_plancuentaswwds_3_cuecod1 = "";
         lV101Contabilidad_plancuentaswwds_4_cuedsc1 = "";
         lV106Contabilidad_plancuentaswwds_9_cuecod2 = "";
         lV107Contabilidad_plancuentaswwds_10_cuedsc2 = "";
         lV112Contabilidad_plancuentaswwds_15_cuecod3 = "";
         lV113Contabilidad_plancuentaswwds_16_cuedsc3 = "";
         lV115Contabilidad_plancuentaswwds_18_tfcuecod = "";
         lV117Contabilidad_plancuentaswwds_20_tfcuedsc = "";
         lV122Contabilidad_plancuentaswwds_25_tfcuegasdebe = "";
         lV124Contabilidad_plancuentaswwds_27_tfcuegashaber = "";
         AV98Contabilidad_plancuentaswwds_1_dynamicfiltersselector1 = "";
         AV100Contabilidad_plancuentaswwds_3_cuecod1 = "";
         AV101Contabilidad_plancuentaswwds_4_cuedsc1 = "";
         AV104Contabilidad_plancuentaswwds_7_dynamicfiltersselector2 = "";
         AV106Contabilidad_plancuentaswwds_9_cuecod2 = "";
         AV107Contabilidad_plancuentaswwds_10_cuedsc2 = "";
         AV110Contabilidad_plancuentaswwds_13_dynamicfiltersselector3 = "";
         AV112Contabilidad_plancuentaswwds_15_cuecod3 = "";
         AV113Contabilidad_plancuentaswwds_16_cuedsc3 = "";
         AV116Contabilidad_plancuentaswwds_19_tfcuecod_sel = "";
         AV115Contabilidad_plancuentaswwds_18_tfcuecod = "";
         AV118Contabilidad_plancuentaswwds_21_tfcuedsc_sel = "";
         AV117Contabilidad_plancuentaswwds_20_tfcuedsc = "";
         AV123Contabilidad_plancuentaswwds_26_tfcuegasdebe_sel = "";
         AV122Contabilidad_plancuentaswwds_25_tfcuegasdebe = "";
         AV125Contabilidad_plancuentaswwds_28_tfcuegashaber_sel = "";
         AV124Contabilidad_plancuentaswwds_27_tfcuegashaber = "";
         H00292_A873CueSts = new short[1] ;
         H00292_A110CueGasHaber = new string[] {""} ;
         H00292_n110CueGasHaber = new bool[] {false} ;
         H00292_A109CueGasDebe = new string[] {""} ;
         H00292_n109CueGasDebe = new bool[] {false} ;
         H00292_A859CueCos = new short[1] ;
         H00292_A864CueMon = new short[1] ;
         H00292_A867CueMov = new short[1] ;
         H00292_A860CueDsc = new string[] {""} ;
         H00292_A91CueCod = new string[] {""} ;
         H00293_AGRID_nRecordCount = new long[1] ;
         imgAdddynamicfilters1_Jsonclick = "";
         imgRemovedynamicfilters1_Jsonclick = "";
         imgAdddynamicfilters2_Jsonclick = "";
         imgRemovedynamicfilters2_Jsonclick = "";
         imgRemovedynamicfilters3_Jsonclick = "";
         AV83AGExportDataItem = new GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTDropDownOptionsData_Item(context);
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
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.contabilidad.plancuentasww__default(),
            new Object[][] {
                new Object[] {
               H00292_A873CueSts, H00292_A110CueGasHaber, H00292_n110CueGasHaber, H00292_A109CueGasDebe, H00292_n109CueGasDebe, H00292_A859CueCos, H00292_A864CueMon, H00292_A867CueMov, H00292_A860CueDsc, H00292_A91CueCod
               }
               , new Object[] {
               H00293_AGRID_nRecordCount
               }
            }
         );
         AV97Pgmname = "Contabilidad.PlanCuentasWW";
         /* GeneXus formulas. */
         AV97Pgmname = "Contabilidad.PlanCuentasWW";
         context.Gx_err = 0;
      }

      private short GRID_nEOF ;
      private short nGotPars ;
      private short GxWebError ;
      private short AV16DynamicFiltersOperator1 ;
      private short AV92CueMov1 ;
      private short AV21DynamicFiltersOperator2 ;
      private short AV93CueMov2 ;
      private short AV26DynamicFiltersOperator3 ;
      private short AV94CueMov3 ;
      private short AV87TFCueMov_Sel ;
      private short AV88TFCueMon_Sel ;
      private short AV89TFCueCos_Sel ;
      private short AV13OrderedBy ;
      private short initialized ;
      private short gxajaxcallmode ;
      private short wbEnd ;
      private short wbStart ;
      private short subGrid_Backcolorstyle ;
      private short subGrid_Titlebackstyle ;
      private short subGrid_Sortable ;
      private short AV81GridActions ;
      private short A867CueMov ;
      private short A864CueMon ;
      private short A859CueCos ;
      private short A873CueSts ;
      private short subGrid_Allowselection ;
      private short subGrid_Allowhovering ;
      private short subGrid_Allowcollapsing ;
      private short subGrid_Collapsed ;
      private short nDonePA ;
      private short AV99Contabilidad_plancuentaswwds_2_dynamicfiltersoperator1 ;
      private short AV105Contabilidad_plancuentaswwds_8_dynamicfiltersoperator2 ;
      private short AV111Contabilidad_plancuentaswwds_14_dynamicfiltersoperator3 ;
      private short AV119Contabilidad_plancuentaswwds_22_tfcuemov_sel ;
      private short AV120Contabilidad_plancuentaswwds_23_tfcuemon_sel ;
      private short AV121Contabilidad_plancuentaswwds_24_tfcuecos_sel ;
      private short AV102Contabilidad_plancuentaswwds_5_cuemov1 ;
      private short AV108Contabilidad_plancuentaswwds_11_cuemov2 ;
      private short AV114Contabilidad_plancuentaswwds_17_cuemov3 ;
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
      private int AV126Contabilidad_plancuentaswwds_29_tfcuests_sels_Count ;
      private int AV77PageToGo ;
      private int imgAdddynamicfilters1_Visible ;
      private int imgRemovedynamicfilters1_Visible ;
      private int imgAdddynamicfilters2_Visible ;
      private int imgRemovedynamicfilters2_Visible ;
      private int edtavCuecod1_Visible ;
      private int edtavCuedsc1_Visible ;
      private int edtavCuecod2_Visible ;
      private int edtavCuedsc2_Visible ;
      private int edtavCuecod3_Visible ;
      private int edtavCuedsc3_Visible ;
      private int AV127GXV1 ;
      private int edtavCuecod3_Enabled ;
      private int edtavCuedsc3_Enabled ;
      private int edtavCuecod2_Enabled ;
      private int edtavCuedsc2_Enabled ;
      private int edtavCuecod1_Enabled ;
      private int edtavCuedsc1_Enabled ;
      private int idxLst ;
      private int subGrid_Backcolor ;
      private long GRID_nFirstRecordOnPage ;
      private long AV78GridCurrentPage ;
      private long AV79GridPageCount ;
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
      private string sGXsfl_119_idx="0001" ;
      private string AV84CueCod1 ;
      private string AV17CueDsc1 ;
      private string AV85CueCod2 ;
      private string AV22CueDsc2 ;
      private string AV86CueCod3 ;
      private string AV27CueDsc3 ;
      private string AV97Pgmname ;
      private string AV34TFCueCod ;
      private string AV35TFCueCod_Sel ;
      private string AV36TFCueDsc ;
      private string AV37TFCueDsc_Sel ;
      private string AV48TFCueGasDebe ;
      private string AV49TFCueGasDebe_Sel ;
      private string AV50TFCueGasHaber ;
      private string AV51TFCueGasHaber_Sel ;
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
      private string A91CueCod ;
      private string A860CueDsc ;
      private string edtCueDsc_Link ;
      private string A109CueGasDebe ;
      private string A110CueGasHaber ;
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
      private string edtCueCod_Internalname ;
      private string edtCueDsc_Internalname ;
      private string edtCueMov_Internalname ;
      private string edtCueMon_Internalname ;
      private string edtCueCos_Internalname ;
      private string edtCueGasDebe_Internalname ;
      private string edtCueGasHaber_Internalname ;
      private string cmbCueSts_Internalname ;
      private string cmbavDynamicfiltersselector1_Internalname ;
      private string cmbavDynamicfiltersoperator1_Internalname ;
      private string cmbavCuemov1_Internalname ;
      private string cmbavDynamicfiltersselector2_Internalname ;
      private string cmbavDynamicfiltersoperator2_Internalname ;
      private string cmbavCuemov2_Internalname ;
      private string cmbavDynamicfiltersselector3_Internalname ;
      private string cmbavDynamicfiltersoperator3_Internalname ;
      private string cmbavCuemov3_Internalname ;
      private string scmdbuf ;
      private string lV100Contabilidad_plancuentaswwds_3_cuecod1 ;
      private string lV101Contabilidad_plancuentaswwds_4_cuedsc1 ;
      private string lV106Contabilidad_plancuentaswwds_9_cuecod2 ;
      private string lV107Contabilidad_plancuentaswwds_10_cuedsc2 ;
      private string lV112Contabilidad_plancuentaswwds_15_cuecod3 ;
      private string lV113Contabilidad_plancuentaswwds_16_cuedsc3 ;
      private string lV115Contabilidad_plancuentaswwds_18_tfcuecod ;
      private string lV117Contabilidad_plancuentaswwds_20_tfcuedsc ;
      private string lV122Contabilidad_plancuentaswwds_25_tfcuegasdebe ;
      private string lV124Contabilidad_plancuentaswwds_27_tfcuegashaber ;
      private string AV100Contabilidad_plancuentaswwds_3_cuecod1 ;
      private string AV101Contabilidad_plancuentaswwds_4_cuedsc1 ;
      private string AV106Contabilidad_plancuentaswwds_9_cuecod2 ;
      private string AV107Contabilidad_plancuentaswwds_10_cuedsc2 ;
      private string AV112Contabilidad_plancuentaswwds_15_cuecod3 ;
      private string AV113Contabilidad_plancuentaswwds_16_cuedsc3 ;
      private string AV116Contabilidad_plancuentaswwds_19_tfcuecod_sel ;
      private string AV115Contabilidad_plancuentaswwds_18_tfcuecod ;
      private string AV118Contabilidad_plancuentaswwds_21_tfcuedsc_sel ;
      private string AV117Contabilidad_plancuentaswwds_20_tfcuedsc ;
      private string AV123Contabilidad_plancuentaswwds_26_tfcuegasdebe_sel ;
      private string AV122Contabilidad_plancuentaswwds_25_tfcuegasdebe ;
      private string AV125Contabilidad_plancuentaswwds_28_tfcuegashaber_sel ;
      private string AV124Contabilidad_plancuentaswwds_27_tfcuegashaber ;
      private string edtavCuecod1_Internalname ;
      private string edtavCuedsc1_Internalname ;
      private string edtavCuecod2_Internalname ;
      private string edtavCuedsc2_Internalname ;
      private string edtavCuecod3_Internalname ;
      private string edtavCuedsc3_Internalname ;
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
      private string cellFilter_cuecod3_cell_Internalname ;
      private string edtavCuecod3_Jsonclick ;
      private string cellFilter_cuedsc3_cell_Internalname ;
      private string edtavCuedsc3_Jsonclick ;
      private string cellFilter_cuemov3_cell_Internalname ;
      private string cmbavCuemov3_Jsonclick ;
      private string cellDynamicfilters_removefilter3_cell_Internalname ;
      private string sImgUrl ;
      private string tblTablemergeddynamicfilters2_Internalname ;
      private string cmbavDynamicfiltersoperator2_Jsonclick ;
      private string cellFilter_cuecod2_cell_Internalname ;
      private string edtavCuecod2_Jsonclick ;
      private string cellFilter_cuedsc2_cell_Internalname ;
      private string edtavCuedsc2_Jsonclick ;
      private string cellFilter_cuemov2_cell_Internalname ;
      private string cmbavCuemov2_Jsonclick ;
      private string cellDynamicfilters_addfilter2_cell_Internalname ;
      private string cellDynamicfilters_removefilter2_cell_Internalname ;
      private string tblTablemergeddynamicfilters1_Internalname ;
      private string cmbavDynamicfiltersoperator1_Jsonclick ;
      private string cellFilter_cuecod1_cell_Internalname ;
      private string edtavCuecod1_Jsonclick ;
      private string cellFilter_cuedsc1_cell_Internalname ;
      private string edtavCuedsc1_Jsonclick ;
      private string cellFilter_cuemov1_cell_Internalname ;
      private string cmbavCuemov1_Jsonclick ;
      private string cellDynamicfilters_addfilter1_cell_Internalname ;
      private string cellDynamicfilters_removefilter1_cell_Internalname ;
      private string sGXsfl_119_fel_idx="0001" ;
      private string GXCCtl ;
      private string cmbavGridactions_Jsonclick ;
      private string ROClassString ;
      private string edtCueCod_Jsonclick ;
      private string edtCueDsc_Jsonclick ;
      private string edtCueMov_Jsonclick ;
      private string edtCueMon_Jsonclick ;
      private string edtCueCos_Jsonclick ;
      private string edtCueGasDebe_Jsonclick ;
      private string edtCueGasHaber_Jsonclick ;
      private string cmbCueSts_Jsonclick ;
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
      private bool n109CueGasDebe ;
      private bool n110CueGasHaber ;
      private bool bGXsfl_119_Refreshing=false ;
      private bool gxdyncontrolsrefreshing ;
      private bool AV103Contabilidad_plancuentaswwds_6_dynamicfiltersenabled2 ;
      private bool AV109Contabilidad_plancuentaswwds_12_dynamicfiltersenabled3 ;
      private bool returnInSub ;
      private bool gx_refresh_fired ;
      private string AV90TFCueSts_SelsJson ;
      private string AV15DynamicFiltersSelector1 ;
      private string AV20DynamicFiltersSelector2 ;
      private string AV25DynamicFiltersSelector3 ;
      private string AV80GridAppliedFilters ;
      private string AV98Contabilidad_plancuentaswwds_1_dynamicfiltersselector1 ;
      private string AV104Contabilidad_plancuentaswwds_7_dynamicfiltersselector2 ;
      private string AV110Contabilidad_plancuentaswwds_13_dynamicfiltersselector3 ;
      private string AV31ExcelFilename ;
      private string AV32ErrorMessage ;
      private GxSimpleCollection<short> AV91TFCueSts_Sels ;
      private GxSimpleCollection<short> AV126Contabilidad_plancuentaswwds_29_tfcuests_sels ;
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
      private IGxDataStore dsDataStore2 ;
      private IGxDataStore dsDefault ;
      private GXCombobox cmbavDynamicfiltersselector1 ;
      private GXCombobox cmbavDynamicfiltersoperator1 ;
      private GXCombobox cmbavCuemov1 ;
      private GXCombobox cmbavDynamicfiltersselector2 ;
      private GXCombobox cmbavDynamicfiltersoperator2 ;
      private GXCombobox cmbavCuemov2 ;
      private GXCombobox cmbavDynamicfiltersselector3 ;
      private GXCombobox cmbavDynamicfiltersoperator3 ;
      private GXCombobox cmbavCuemov3 ;
      private GXCombobox cmbavGridactions ;
      private GXCombobox cmbCueSts ;
      private IDataStoreProvider pr_default ;
      private short[] H00292_A873CueSts ;
      private string[] H00292_A110CueGasHaber ;
      private bool[] H00292_n110CueGasHaber ;
      private string[] H00292_A109CueGasDebe ;
      private bool[] H00292_n109CueGasDebe ;
      private short[] H00292_A859CueCos ;
      private short[] H00292_A864CueMon ;
      private short[] H00292_A867CueMov ;
      private string[] H00292_A860CueDsc ;
      private string[] H00292_A91CueCod ;
      private long[] H00293_AGRID_nRecordCount ;
      private msglist BackMsgLst ;
      private msglist LclMsgLst ;
      private GxHttpRequest AV7HTTPRequest ;
      private GXBaseCollection<GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTDropDownOptionsData_Item> AV82AGExportData ;
      private GXWebForm Form ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPContext AV6WWPContext ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPTransactionContext AV8TrnContext ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPGridState AV10GridState ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue AV11GridStateFilterValue ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter AV12GridStateDynamicFilter ;
      private GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTDropDownOptionsTitleSettingsIcons AV76DDO_TitleSettingsIcons ;
      private GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTDropDownOptionsTitleSettingsIcons GXt_SdtDVB_SDTDropDownOptionsTitleSettingsIcons1 ;
      private GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTDropDownOptionsData_Item AV83AGExportDataItem ;
   }

   public class plancuentasww__default : DataStoreHelperBase, IDataStoreHelper
   {
      protected Object[] conditional_H00292( IGxContext context ,
                                             short A873CueSts ,
                                             GxSimpleCollection<short> AV126Contabilidad_plancuentaswwds_29_tfcuests_sels ,
                                             string AV98Contabilidad_plancuentaswwds_1_dynamicfiltersselector1 ,
                                             short AV99Contabilidad_plancuentaswwds_2_dynamicfiltersoperator1 ,
                                             string AV100Contabilidad_plancuentaswwds_3_cuecod1 ,
                                             string AV101Contabilidad_plancuentaswwds_4_cuedsc1 ,
                                             bool AV103Contabilidad_plancuentaswwds_6_dynamicfiltersenabled2 ,
                                             string AV104Contabilidad_plancuentaswwds_7_dynamicfiltersselector2 ,
                                             short AV105Contabilidad_plancuentaswwds_8_dynamicfiltersoperator2 ,
                                             string AV106Contabilidad_plancuentaswwds_9_cuecod2 ,
                                             string AV107Contabilidad_plancuentaswwds_10_cuedsc2 ,
                                             bool AV109Contabilidad_plancuentaswwds_12_dynamicfiltersenabled3 ,
                                             string AV110Contabilidad_plancuentaswwds_13_dynamicfiltersselector3 ,
                                             short AV111Contabilidad_plancuentaswwds_14_dynamicfiltersoperator3 ,
                                             string AV112Contabilidad_plancuentaswwds_15_cuecod3 ,
                                             string AV113Contabilidad_plancuentaswwds_16_cuedsc3 ,
                                             string AV116Contabilidad_plancuentaswwds_19_tfcuecod_sel ,
                                             string AV115Contabilidad_plancuentaswwds_18_tfcuecod ,
                                             string AV118Contabilidad_plancuentaswwds_21_tfcuedsc_sel ,
                                             string AV117Contabilidad_plancuentaswwds_20_tfcuedsc ,
                                             short AV119Contabilidad_plancuentaswwds_22_tfcuemov_sel ,
                                             short AV120Contabilidad_plancuentaswwds_23_tfcuemon_sel ,
                                             short AV121Contabilidad_plancuentaswwds_24_tfcuecos_sel ,
                                             string AV123Contabilidad_plancuentaswwds_26_tfcuegasdebe_sel ,
                                             string AV122Contabilidad_plancuentaswwds_25_tfcuegasdebe ,
                                             string AV125Contabilidad_plancuentaswwds_28_tfcuegashaber_sel ,
                                             string AV124Contabilidad_plancuentaswwds_27_tfcuegashaber ,
                                             int AV126Contabilidad_plancuentaswwds_29_tfcuests_sels_Count ,
                                             string A91CueCod ,
                                             string A860CueDsc ,
                                             short A867CueMov ,
                                             short AV102Contabilidad_plancuentaswwds_5_cuemov1 ,
                                             short AV108Contabilidad_plancuentaswwds_11_cuemov2 ,
                                             short AV114Contabilidad_plancuentaswwds_17_cuemov3 ,
                                             short A864CueMon ,
                                             short A859CueCos ,
                                             string A109CueGasDebe ,
                                             string A110CueGasHaber ,
                                             short AV13OrderedBy ,
                                             bool AV14OrderedDsc )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int6 = new short[26];
         Object[] GXv_Object7 = new Object[2];
         string sSelectString;
         string sFromString;
         string sOrderString;
         sSelectString = " [CueSts], [CueGasHaber], [CueGasDebe], [CueCos], [CueMon], [CueMov], [CueDsc], [CueCod]";
         sFromString = " FROM [CBPLANCUENTA]";
         sOrderString = "";
         if ( ( StringUtil.StrCmp(AV98Contabilidad_plancuentaswwds_1_dynamicfiltersselector1, "CUECOD") == 0 ) && ( AV99Contabilidad_plancuentaswwds_2_dynamicfiltersoperator1 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV100Contabilidad_plancuentaswwds_3_cuecod1)) ) )
         {
            AddWhere(sWhereString, "([CueCod] like @lV100Contabilidad_plancuentaswwds_3_cuecod1)");
         }
         else
         {
            GXv_int6[0] = 1;
         }
         if ( ( StringUtil.StrCmp(AV98Contabilidad_plancuentaswwds_1_dynamicfiltersselector1, "CUECOD") == 0 ) && ( AV99Contabilidad_plancuentaswwds_2_dynamicfiltersoperator1 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV100Contabilidad_plancuentaswwds_3_cuecod1)) ) )
         {
            AddWhere(sWhereString, "([CueCod] like '%' + @lV100Contabilidad_plancuentaswwds_3_cuecod1)");
         }
         else
         {
            GXv_int6[1] = 1;
         }
         if ( ( StringUtil.StrCmp(AV98Contabilidad_plancuentaswwds_1_dynamicfiltersselector1, "CUEDSC") == 0 ) && ( AV99Contabilidad_plancuentaswwds_2_dynamicfiltersoperator1 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV101Contabilidad_plancuentaswwds_4_cuedsc1)) ) )
         {
            AddWhere(sWhereString, "([CueDsc] like @lV101Contabilidad_plancuentaswwds_4_cuedsc1)");
         }
         else
         {
            GXv_int6[2] = 1;
         }
         if ( ( StringUtil.StrCmp(AV98Contabilidad_plancuentaswwds_1_dynamicfiltersselector1, "CUEDSC") == 0 ) && ( AV99Contabilidad_plancuentaswwds_2_dynamicfiltersoperator1 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV101Contabilidad_plancuentaswwds_4_cuedsc1)) ) )
         {
            AddWhere(sWhereString, "([CueDsc] like '%' + @lV101Contabilidad_plancuentaswwds_4_cuedsc1)");
         }
         else
         {
            GXv_int6[3] = 1;
         }
         if ( StringUtil.StrCmp(AV98Contabilidad_plancuentaswwds_1_dynamicfiltersselector1, "CUEMOV") == 0 )
         {
            AddWhere(sWhereString, "([CueMov] = @AV102Contabilidad_plancuentaswwds_5_cuemov1)");
         }
         else
         {
            GXv_int6[4] = 1;
         }
         if ( AV103Contabilidad_plancuentaswwds_6_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV104Contabilidad_plancuentaswwds_7_dynamicfiltersselector2, "CUECOD") == 0 ) && ( AV105Contabilidad_plancuentaswwds_8_dynamicfiltersoperator2 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV106Contabilidad_plancuentaswwds_9_cuecod2)) ) )
         {
            AddWhere(sWhereString, "([CueCod] like @lV106Contabilidad_plancuentaswwds_9_cuecod2)");
         }
         else
         {
            GXv_int6[5] = 1;
         }
         if ( AV103Contabilidad_plancuentaswwds_6_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV104Contabilidad_plancuentaswwds_7_dynamicfiltersselector2, "CUECOD") == 0 ) && ( AV105Contabilidad_plancuentaswwds_8_dynamicfiltersoperator2 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV106Contabilidad_plancuentaswwds_9_cuecod2)) ) )
         {
            AddWhere(sWhereString, "([CueCod] like '%' + @lV106Contabilidad_plancuentaswwds_9_cuecod2)");
         }
         else
         {
            GXv_int6[6] = 1;
         }
         if ( AV103Contabilidad_plancuentaswwds_6_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV104Contabilidad_plancuentaswwds_7_dynamicfiltersselector2, "CUEDSC") == 0 ) && ( AV105Contabilidad_plancuentaswwds_8_dynamicfiltersoperator2 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV107Contabilidad_plancuentaswwds_10_cuedsc2)) ) )
         {
            AddWhere(sWhereString, "([CueDsc] like @lV107Contabilidad_plancuentaswwds_10_cuedsc2)");
         }
         else
         {
            GXv_int6[7] = 1;
         }
         if ( AV103Contabilidad_plancuentaswwds_6_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV104Contabilidad_plancuentaswwds_7_dynamicfiltersselector2, "CUEDSC") == 0 ) && ( AV105Contabilidad_plancuentaswwds_8_dynamicfiltersoperator2 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV107Contabilidad_plancuentaswwds_10_cuedsc2)) ) )
         {
            AddWhere(sWhereString, "([CueDsc] like '%' + @lV107Contabilidad_plancuentaswwds_10_cuedsc2)");
         }
         else
         {
            GXv_int6[8] = 1;
         }
         if ( AV103Contabilidad_plancuentaswwds_6_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV104Contabilidad_plancuentaswwds_7_dynamicfiltersselector2, "CUEMOV") == 0 ) )
         {
            AddWhere(sWhereString, "([CueMov] = @AV108Contabilidad_plancuentaswwds_11_cuemov2)");
         }
         else
         {
            GXv_int6[9] = 1;
         }
         if ( AV109Contabilidad_plancuentaswwds_12_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV110Contabilidad_plancuentaswwds_13_dynamicfiltersselector3, "CUECOD") == 0 ) && ( AV111Contabilidad_plancuentaswwds_14_dynamicfiltersoperator3 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV112Contabilidad_plancuentaswwds_15_cuecod3)) ) )
         {
            AddWhere(sWhereString, "([CueCod] like @lV112Contabilidad_plancuentaswwds_15_cuecod3)");
         }
         else
         {
            GXv_int6[10] = 1;
         }
         if ( AV109Contabilidad_plancuentaswwds_12_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV110Contabilidad_plancuentaswwds_13_dynamicfiltersselector3, "CUECOD") == 0 ) && ( AV111Contabilidad_plancuentaswwds_14_dynamicfiltersoperator3 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV112Contabilidad_plancuentaswwds_15_cuecod3)) ) )
         {
            AddWhere(sWhereString, "([CueCod] like '%' + @lV112Contabilidad_plancuentaswwds_15_cuecod3)");
         }
         else
         {
            GXv_int6[11] = 1;
         }
         if ( AV109Contabilidad_plancuentaswwds_12_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV110Contabilidad_plancuentaswwds_13_dynamicfiltersselector3, "CUEDSC") == 0 ) && ( AV111Contabilidad_plancuentaswwds_14_dynamicfiltersoperator3 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV113Contabilidad_plancuentaswwds_16_cuedsc3)) ) )
         {
            AddWhere(sWhereString, "([CueDsc] like @lV113Contabilidad_plancuentaswwds_16_cuedsc3)");
         }
         else
         {
            GXv_int6[12] = 1;
         }
         if ( AV109Contabilidad_plancuentaswwds_12_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV110Contabilidad_plancuentaswwds_13_dynamicfiltersselector3, "CUEDSC") == 0 ) && ( AV111Contabilidad_plancuentaswwds_14_dynamicfiltersoperator3 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV113Contabilidad_plancuentaswwds_16_cuedsc3)) ) )
         {
            AddWhere(sWhereString, "([CueDsc] like '%' + @lV113Contabilidad_plancuentaswwds_16_cuedsc3)");
         }
         else
         {
            GXv_int6[13] = 1;
         }
         if ( AV109Contabilidad_plancuentaswwds_12_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV110Contabilidad_plancuentaswwds_13_dynamicfiltersselector3, "CUEMOV") == 0 ) )
         {
            AddWhere(sWhereString, "([CueMov] = @AV114Contabilidad_plancuentaswwds_17_cuemov3)");
         }
         else
         {
            GXv_int6[14] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV116Contabilidad_plancuentaswwds_19_tfcuecod_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV115Contabilidad_plancuentaswwds_18_tfcuecod)) ) )
         {
            AddWhere(sWhereString, "([CueCod] like @lV115Contabilidad_plancuentaswwds_18_tfcuecod)");
         }
         else
         {
            GXv_int6[15] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV116Contabilidad_plancuentaswwds_19_tfcuecod_sel)) )
         {
            AddWhere(sWhereString, "([CueCod] = @AV116Contabilidad_plancuentaswwds_19_tfcuecod_sel)");
         }
         else
         {
            GXv_int6[16] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV118Contabilidad_plancuentaswwds_21_tfcuedsc_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV117Contabilidad_plancuentaswwds_20_tfcuedsc)) ) )
         {
            AddWhere(sWhereString, "([CueDsc] like @lV117Contabilidad_plancuentaswwds_20_tfcuedsc)");
         }
         else
         {
            GXv_int6[17] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV118Contabilidad_plancuentaswwds_21_tfcuedsc_sel)) )
         {
            AddWhere(sWhereString, "([CueDsc] = @AV118Contabilidad_plancuentaswwds_21_tfcuedsc_sel)");
         }
         else
         {
            GXv_int6[18] = 1;
         }
         if ( AV119Contabilidad_plancuentaswwds_22_tfcuemov_sel == 1 )
         {
            AddWhere(sWhereString, "([CueMov] = 1)");
         }
         if ( AV119Contabilidad_plancuentaswwds_22_tfcuemov_sel == 2 )
         {
            AddWhere(sWhereString, "([CueMov] = 0)");
         }
         if ( AV120Contabilidad_plancuentaswwds_23_tfcuemon_sel == 1 )
         {
            AddWhere(sWhereString, "([CueMon] = 1)");
         }
         if ( AV120Contabilidad_plancuentaswwds_23_tfcuemon_sel == 2 )
         {
            AddWhere(sWhereString, "([CueMon] = 0)");
         }
         if ( AV121Contabilidad_plancuentaswwds_24_tfcuecos_sel == 1 )
         {
            AddWhere(sWhereString, "([CueCos] = 1)");
         }
         if ( AV121Contabilidad_plancuentaswwds_24_tfcuecos_sel == 2 )
         {
            AddWhere(sWhereString, "([CueCos] = 0)");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV123Contabilidad_plancuentaswwds_26_tfcuegasdebe_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV122Contabilidad_plancuentaswwds_25_tfcuegasdebe)) ) )
         {
            AddWhere(sWhereString, "([CueGasDebe] like @lV122Contabilidad_plancuentaswwds_25_tfcuegasdebe)");
         }
         else
         {
            GXv_int6[19] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV123Contabilidad_plancuentaswwds_26_tfcuegasdebe_sel)) )
         {
            AddWhere(sWhereString, "([CueGasDebe] = @AV123Contabilidad_plancuentaswwds_26_tfcuegasdebe_sel)");
         }
         else
         {
            GXv_int6[20] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV125Contabilidad_plancuentaswwds_28_tfcuegashaber_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV124Contabilidad_plancuentaswwds_27_tfcuegashaber)) ) )
         {
            AddWhere(sWhereString, "([CueGasHaber] like @lV124Contabilidad_plancuentaswwds_27_tfcuegashaber)");
         }
         else
         {
            GXv_int6[21] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV125Contabilidad_plancuentaswwds_28_tfcuegashaber_sel)) )
         {
            AddWhere(sWhereString, "([CueGasHaber] = @AV125Contabilidad_plancuentaswwds_28_tfcuegashaber_sel)");
         }
         else
         {
            GXv_int6[22] = 1;
         }
         if ( AV126Contabilidad_plancuentaswwds_29_tfcuests_sels_Count > 0 )
         {
            AddWhere(sWhereString, "("+new GxDbmsUtils( new GxSqlServer()).ValueList(AV126Contabilidad_plancuentaswwds_29_tfcuests_sels, "[CueSts] IN (", ")")+")");
         }
         if ( ( AV13OrderedBy == 1 ) && ! AV14OrderedDsc )
         {
            sOrderString += " ORDER BY [CueCod]";
         }
         else if ( ( AV13OrderedBy == 1 ) && ( AV14OrderedDsc ) )
         {
            sOrderString += " ORDER BY [CueCod] DESC";
         }
         else if ( ( AV13OrderedBy == 2 ) && ! AV14OrderedDsc )
         {
            sOrderString += " ORDER BY [CueDsc]";
         }
         else if ( ( AV13OrderedBy == 2 ) && ( AV14OrderedDsc ) )
         {
            sOrderString += " ORDER BY [CueDsc] DESC";
         }
         else if ( ( AV13OrderedBy == 3 ) && ! AV14OrderedDsc )
         {
            sOrderString += " ORDER BY [CueMov]";
         }
         else if ( ( AV13OrderedBy == 3 ) && ( AV14OrderedDsc ) )
         {
            sOrderString += " ORDER BY [CueMov] DESC";
         }
         else if ( ( AV13OrderedBy == 4 ) && ! AV14OrderedDsc )
         {
            sOrderString += " ORDER BY [CueMon]";
         }
         else if ( ( AV13OrderedBy == 4 ) && ( AV14OrderedDsc ) )
         {
            sOrderString += " ORDER BY [CueMon] DESC";
         }
         else if ( ( AV13OrderedBy == 5 ) && ! AV14OrderedDsc )
         {
            sOrderString += " ORDER BY [CueCos]";
         }
         else if ( ( AV13OrderedBy == 5 ) && ( AV14OrderedDsc ) )
         {
            sOrderString += " ORDER BY [CueCos] DESC";
         }
         else if ( ( AV13OrderedBy == 6 ) && ! AV14OrderedDsc )
         {
            sOrderString += " ORDER BY [CueGasDebe]";
         }
         else if ( ( AV13OrderedBy == 6 ) && ( AV14OrderedDsc ) )
         {
            sOrderString += " ORDER BY [CueGasDebe] DESC";
         }
         else if ( ( AV13OrderedBy == 7 ) && ! AV14OrderedDsc )
         {
            sOrderString += " ORDER BY [CueGasHaber]";
         }
         else if ( ( AV13OrderedBy == 7 ) && ( AV14OrderedDsc ) )
         {
            sOrderString += " ORDER BY [CueGasHaber] DESC";
         }
         else if ( ( AV13OrderedBy == 8 ) && ! AV14OrderedDsc )
         {
            sOrderString += " ORDER BY [CueSts]";
         }
         else if ( ( AV13OrderedBy == 8 ) && ( AV14OrderedDsc ) )
         {
            sOrderString += " ORDER BY [CueSts] DESC";
         }
         else if ( true )
         {
            sOrderString += " ORDER BY [CueCod]";
         }
         scmdbuf = "SELECT " + sSelectString + sFromString + sWhereString + sOrderString + "" + " OFFSET " + "@GXPagingFrom2" + " ROWS FETCH NEXT CAST((SELECT CASE WHEN " + "@GXPagingTo2" + " > 0 THEN " + "@GXPagingTo2" + " ELSE 1e9 END) AS INTEGER) ROWS ONLY";
         GXv_Object7[0] = scmdbuf;
         GXv_Object7[1] = GXv_int6;
         return GXv_Object7 ;
      }

      protected Object[] conditional_H00293( IGxContext context ,
                                             short A873CueSts ,
                                             GxSimpleCollection<short> AV126Contabilidad_plancuentaswwds_29_tfcuests_sels ,
                                             string AV98Contabilidad_plancuentaswwds_1_dynamicfiltersselector1 ,
                                             short AV99Contabilidad_plancuentaswwds_2_dynamicfiltersoperator1 ,
                                             string AV100Contabilidad_plancuentaswwds_3_cuecod1 ,
                                             string AV101Contabilidad_plancuentaswwds_4_cuedsc1 ,
                                             bool AV103Contabilidad_plancuentaswwds_6_dynamicfiltersenabled2 ,
                                             string AV104Contabilidad_plancuentaswwds_7_dynamicfiltersselector2 ,
                                             short AV105Contabilidad_plancuentaswwds_8_dynamicfiltersoperator2 ,
                                             string AV106Contabilidad_plancuentaswwds_9_cuecod2 ,
                                             string AV107Contabilidad_plancuentaswwds_10_cuedsc2 ,
                                             bool AV109Contabilidad_plancuentaswwds_12_dynamicfiltersenabled3 ,
                                             string AV110Contabilidad_plancuentaswwds_13_dynamicfiltersselector3 ,
                                             short AV111Contabilidad_plancuentaswwds_14_dynamicfiltersoperator3 ,
                                             string AV112Contabilidad_plancuentaswwds_15_cuecod3 ,
                                             string AV113Contabilidad_plancuentaswwds_16_cuedsc3 ,
                                             string AV116Contabilidad_plancuentaswwds_19_tfcuecod_sel ,
                                             string AV115Contabilidad_plancuentaswwds_18_tfcuecod ,
                                             string AV118Contabilidad_plancuentaswwds_21_tfcuedsc_sel ,
                                             string AV117Contabilidad_plancuentaswwds_20_tfcuedsc ,
                                             short AV119Contabilidad_plancuentaswwds_22_tfcuemov_sel ,
                                             short AV120Contabilidad_plancuentaswwds_23_tfcuemon_sel ,
                                             short AV121Contabilidad_plancuentaswwds_24_tfcuecos_sel ,
                                             string AV123Contabilidad_plancuentaswwds_26_tfcuegasdebe_sel ,
                                             string AV122Contabilidad_plancuentaswwds_25_tfcuegasdebe ,
                                             string AV125Contabilidad_plancuentaswwds_28_tfcuegashaber_sel ,
                                             string AV124Contabilidad_plancuentaswwds_27_tfcuegashaber ,
                                             int AV126Contabilidad_plancuentaswwds_29_tfcuests_sels_Count ,
                                             string A91CueCod ,
                                             string A860CueDsc ,
                                             short A867CueMov ,
                                             short AV102Contabilidad_plancuentaswwds_5_cuemov1 ,
                                             short AV108Contabilidad_plancuentaswwds_11_cuemov2 ,
                                             short AV114Contabilidad_plancuentaswwds_17_cuemov3 ,
                                             short A864CueMon ,
                                             short A859CueCos ,
                                             string A109CueGasDebe ,
                                             string A110CueGasHaber ,
                                             short AV13OrderedBy ,
                                             bool AV14OrderedDsc )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int8 = new short[23];
         Object[] GXv_Object9 = new Object[2];
         scmdbuf = "SELECT COUNT(*) FROM [CBPLANCUENTA]";
         if ( ( StringUtil.StrCmp(AV98Contabilidad_plancuentaswwds_1_dynamicfiltersselector1, "CUECOD") == 0 ) && ( AV99Contabilidad_plancuentaswwds_2_dynamicfiltersoperator1 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV100Contabilidad_plancuentaswwds_3_cuecod1)) ) )
         {
            AddWhere(sWhereString, "([CueCod] like @lV100Contabilidad_plancuentaswwds_3_cuecod1)");
         }
         else
         {
            GXv_int8[0] = 1;
         }
         if ( ( StringUtil.StrCmp(AV98Contabilidad_plancuentaswwds_1_dynamicfiltersselector1, "CUECOD") == 0 ) && ( AV99Contabilidad_plancuentaswwds_2_dynamicfiltersoperator1 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV100Contabilidad_plancuentaswwds_3_cuecod1)) ) )
         {
            AddWhere(sWhereString, "([CueCod] like '%' + @lV100Contabilidad_plancuentaswwds_3_cuecod1)");
         }
         else
         {
            GXv_int8[1] = 1;
         }
         if ( ( StringUtil.StrCmp(AV98Contabilidad_plancuentaswwds_1_dynamicfiltersselector1, "CUEDSC") == 0 ) && ( AV99Contabilidad_plancuentaswwds_2_dynamicfiltersoperator1 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV101Contabilidad_plancuentaswwds_4_cuedsc1)) ) )
         {
            AddWhere(sWhereString, "([CueDsc] like @lV101Contabilidad_plancuentaswwds_4_cuedsc1)");
         }
         else
         {
            GXv_int8[2] = 1;
         }
         if ( ( StringUtil.StrCmp(AV98Contabilidad_plancuentaswwds_1_dynamicfiltersselector1, "CUEDSC") == 0 ) && ( AV99Contabilidad_plancuentaswwds_2_dynamicfiltersoperator1 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV101Contabilidad_plancuentaswwds_4_cuedsc1)) ) )
         {
            AddWhere(sWhereString, "([CueDsc] like '%' + @lV101Contabilidad_plancuentaswwds_4_cuedsc1)");
         }
         else
         {
            GXv_int8[3] = 1;
         }
         if ( StringUtil.StrCmp(AV98Contabilidad_plancuentaswwds_1_dynamicfiltersselector1, "CUEMOV") == 0 )
         {
            AddWhere(sWhereString, "([CueMov] = @AV102Contabilidad_plancuentaswwds_5_cuemov1)");
         }
         else
         {
            GXv_int8[4] = 1;
         }
         if ( AV103Contabilidad_plancuentaswwds_6_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV104Contabilidad_plancuentaswwds_7_dynamicfiltersselector2, "CUECOD") == 0 ) && ( AV105Contabilidad_plancuentaswwds_8_dynamicfiltersoperator2 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV106Contabilidad_plancuentaswwds_9_cuecod2)) ) )
         {
            AddWhere(sWhereString, "([CueCod] like @lV106Contabilidad_plancuentaswwds_9_cuecod2)");
         }
         else
         {
            GXv_int8[5] = 1;
         }
         if ( AV103Contabilidad_plancuentaswwds_6_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV104Contabilidad_plancuentaswwds_7_dynamicfiltersselector2, "CUECOD") == 0 ) && ( AV105Contabilidad_plancuentaswwds_8_dynamicfiltersoperator2 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV106Contabilidad_plancuentaswwds_9_cuecod2)) ) )
         {
            AddWhere(sWhereString, "([CueCod] like '%' + @lV106Contabilidad_plancuentaswwds_9_cuecod2)");
         }
         else
         {
            GXv_int8[6] = 1;
         }
         if ( AV103Contabilidad_plancuentaswwds_6_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV104Contabilidad_plancuentaswwds_7_dynamicfiltersselector2, "CUEDSC") == 0 ) && ( AV105Contabilidad_plancuentaswwds_8_dynamicfiltersoperator2 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV107Contabilidad_plancuentaswwds_10_cuedsc2)) ) )
         {
            AddWhere(sWhereString, "([CueDsc] like @lV107Contabilidad_plancuentaswwds_10_cuedsc2)");
         }
         else
         {
            GXv_int8[7] = 1;
         }
         if ( AV103Contabilidad_plancuentaswwds_6_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV104Contabilidad_plancuentaswwds_7_dynamicfiltersselector2, "CUEDSC") == 0 ) && ( AV105Contabilidad_plancuentaswwds_8_dynamicfiltersoperator2 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV107Contabilidad_plancuentaswwds_10_cuedsc2)) ) )
         {
            AddWhere(sWhereString, "([CueDsc] like '%' + @lV107Contabilidad_plancuentaswwds_10_cuedsc2)");
         }
         else
         {
            GXv_int8[8] = 1;
         }
         if ( AV103Contabilidad_plancuentaswwds_6_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV104Contabilidad_plancuentaswwds_7_dynamicfiltersselector2, "CUEMOV") == 0 ) )
         {
            AddWhere(sWhereString, "([CueMov] = @AV108Contabilidad_plancuentaswwds_11_cuemov2)");
         }
         else
         {
            GXv_int8[9] = 1;
         }
         if ( AV109Contabilidad_plancuentaswwds_12_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV110Contabilidad_plancuentaswwds_13_dynamicfiltersselector3, "CUECOD") == 0 ) && ( AV111Contabilidad_plancuentaswwds_14_dynamicfiltersoperator3 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV112Contabilidad_plancuentaswwds_15_cuecod3)) ) )
         {
            AddWhere(sWhereString, "([CueCod] like @lV112Contabilidad_plancuentaswwds_15_cuecod3)");
         }
         else
         {
            GXv_int8[10] = 1;
         }
         if ( AV109Contabilidad_plancuentaswwds_12_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV110Contabilidad_plancuentaswwds_13_dynamicfiltersselector3, "CUECOD") == 0 ) && ( AV111Contabilidad_plancuentaswwds_14_dynamicfiltersoperator3 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV112Contabilidad_plancuentaswwds_15_cuecod3)) ) )
         {
            AddWhere(sWhereString, "([CueCod] like '%' + @lV112Contabilidad_plancuentaswwds_15_cuecod3)");
         }
         else
         {
            GXv_int8[11] = 1;
         }
         if ( AV109Contabilidad_plancuentaswwds_12_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV110Contabilidad_plancuentaswwds_13_dynamicfiltersselector3, "CUEDSC") == 0 ) && ( AV111Contabilidad_plancuentaswwds_14_dynamicfiltersoperator3 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV113Contabilidad_plancuentaswwds_16_cuedsc3)) ) )
         {
            AddWhere(sWhereString, "([CueDsc] like @lV113Contabilidad_plancuentaswwds_16_cuedsc3)");
         }
         else
         {
            GXv_int8[12] = 1;
         }
         if ( AV109Contabilidad_plancuentaswwds_12_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV110Contabilidad_plancuentaswwds_13_dynamicfiltersselector3, "CUEDSC") == 0 ) && ( AV111Contabilidad_plancuentaswwds_14_dynamicfiltersoperator3 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV113Contabilidad_plancuentaswwds_16_cuedsc3)) ) )
         {
            AddWhere(sWhereString, "([CueDsc] like '%' + @lV113Contabilidad_plancuentaswwds_16_cuedsc3)");
         }
         else
         {
            GXv_int8[13] = 1;
         }
         if ( AV109Contabilidad_plancuentaswwds_12_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV110Contabilidad_plancuentaswwds_13_dynamicfiltersselector3, "CUEMOV") == 0 ) )
         {
            AddWhere(sWhereString, "([CueMov] = @AV114Contabilidad_plancuentaswwds_17_cuemov3)");
         }
         else
         {
            GXv_int8[14] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV116Contabilidad_plancuentaswwds_19_tfcuecod_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV115Contabilidad_plancuentaswwds_18_tfcuecod)) ) )
         {
            AddWhere(sWhereString, "([CueCod] like @lV115Contabilidad_plancuentaswwds_18_tfcuecod)");
         }
         else
         {
            GXv_int8[15] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV116Contabilidad_plancuentaswwds_19_tfcuecod_sel)) )
         {
            AddWhere(sWhereString, "([CueCod] = @AV116Contabilidad_plancuentaswwds_19_tfcuecod_sel)");
         }
         else
         {
            GXv_int8[16] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV118Contabilidad_plancuentaswwds_21_tfcuedsc_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV117Contabilidad_plancuentaswwds_20_tfcuedsc)) ) )
         {
            AddWhere(sWhereString, "([CueDsc] like @lV117Contabilidad_plancuentaswwds_20_tfcuedsc)");
         }
         else
         {
            GXv_int8[17] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV118Contabilidad_plancuentaswwds_21_tfcuedsc_sel)) )
         {
            AddWhere(sWhereString, "([CueDsc] = @AV118Contabilidad_plancuentaswwds_21_tfcuedsc_sel)");
         }
         else
         {
            GXv_int8[18] = 1;
         }
         if ( AV119Contabilidad_plancuentaswwds_22_tfcuemov_sel == 1 )
         {
            AddWhere(sWhereString, "([CueMov] = 1)");
         }
         if ( AV119Contabilidad_plancuentaswwds_22_tfcuemov_sel == 2 )
         {
            AddWhere(sWhereString, "([CueMov] = 0)");
         }
         if ( AV120Contabilidad_plancuentaswwds_23_tfcuemon_sel == 1 )
         {
            AddWhere(sWhereString, "([CueMon] = 1)");
         }
         if ( AV120Contabilidad_plancuentaswwds_23_tfcuemon_sel == 2 )
         {
            AddWhere(sWhereString, "([CueMon] = 0)");
         }
         if ( AV121Contabilidad_plancuentaswwds_24_tfcuecos_sel == 1 )
         {
            AddWhere(sWhereString, "([CueCos] = 1)");
         }
         if ( AV121Contabilidad_plancuentaswwds_24_tfcuecos_sel == 2 )
         {
            AddWhere(sWhereString, "([CueCos] = 0)");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV123Contabilidad_plancuentaswwds_26_tfcuegasdebe_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV122Contabilidad_plancuentaswwds_25_tfcuegasdebe)) ) )
         {
            AddWhere(sWhereString, "([CueGasDebe] like @lV122Contabilidad_plancuentaswwds_25_tfcuegasdebe)");
         }
         else
         {
            GXv_int8[19] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV123Contabilidad_plancuentaswwds_26_tfcuegasdebe_sel)) )
         {
            AddWhere(sWhereString, "([CueGasDebe] = @AV123Contabilidad_plancuentaswwds_26_tfcuegasdebe_sel)");
         }
         else
         {
            GXv_int8[20] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV125Contabilidad_plancuentaswwds_28_tfcuegashaber_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV124Contabilidad_plancuentaswwds_27_tfcuegashaber)) ) )
         {
            AddWhere(sWhereString, "([CueGasHaber] like @lV124Contabilidad_plancuentaswwds_27_tfcuegashaber)");
         }
         else
         {
            GXv_int8[21] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV125Contabilidad_plancuentaswwds_28_tfcuegashaber_sel)) )
         {
            AddWhere(sWhereString, "([CueGasHaber] = @AV125Contabilidad_plancuentaswwds_28_tfcuegashaber_sel)");
         }
         else
         {
            GXv_int8[22] = 1;
         }
         if ( AV126Contabilidad_plancuentaswwds_29_tfcuests_sels_Count > 0 )
         {
            AddWhere(sWhereString, "("+new GxDbmsUtils( new GxSqlServer()).ValueList(AV126Contabilidad_plancuentaswwds_29_tfcuests_sels, "[CueSts] IN (", ")")+")");
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
                     return conditional_H00292(context, (short)dynConstraints[0] , (GxSimpleCollection<short>)dynConstraints[1] , (string)dynConstraints[2] , (short)dynConstraints[3] , (string)dynConstraints[4] , (string)dynConstraints[5] , (bool)dynConstraints[6] , (string)dynConstraints[7] , (short)dynConstraints[8] , (string)dynConstraints[9] , (string)dynConstraints[10] , (bool)dynConstraints[11] , (string)dynConstraints[12] , (short)dynConstraints[13] , (string)dynConstraints[14] , (string)dynConstraints[15] , (string)dynConstraints[16] , (string)dynConstraints[17] , (string)dynConstraints[18] , (string)dynConstraints[19] , (short)dynConstraints[20] , (short)dynConstraints[21] , (short)dynConstraints[22] , (string)dynConstraints[23] , (string)dynConstraints[24] , (string)dynConstraints[25] , (string)dynConstraints[26] , (int)dynConstraints[27] , (string)dynConstraints[28] , (string)dynConstraints[29] , (short)dynConstraints[30] , (short)dynConstraints[31] , (short)dynConstraints[32] , (short)dynConstraints[33] , (short)dynConstraints[34] , (short)dynConstraints[35] , (string)dynConstraints[36] , (string)dynConstraints[37] , (short)dynConstraints[38] , (bool)dynConstraints[39] );
               case 1 :
                     return conditional_H00293(context, (short)dynConstraints[0] , (GxSimpleCollection<short>)dynConstraints[1] , (string)dynConstraints[2] , (short)dynConstraints[3] , (string)dynConstraints[4] , (string)dynConstraints[5] , (bool)dynConstraints[6] , (string)dynConstraints[7] , (short)dynConstraints[8] , (string)dynConstraints[9] , (string)dynConstraints[10] , (bool)dynConstraints[11] , (string)dynConstraints[12] , (short)dynConstraints[13] , (string)dynConstraints[14] , (string)dynConstraints[15] , (string)dynConstraints[16] , (string)dynConstraints[17] , (string)dynConstraints[18] , (string)dynConstraints[19] , (short)dynConstraints[20] , (short)dynConstraints[21] , (short)dynConstraints[22] , (string)dynConstraints[23] , (string)dynConstraints[24] , (string)dynConstraints[25] , (string)dynConstraints[26] , (int)dynConstraints[27] , (string)dynConstraints[28] , (string)dynConstraints[29] , (short)dynConstraints[30] , (short)dynConstraints[31] , (short)dynConstraints[32] , (short)dynConstraints[33] , (short)dynConstraints[34] , (short)dynConstraints[35] , (string)dynConstraints[36] , (string)dynConstraints[37] , (short)dynConstraints[38] , (bool)dynConstraints[39] );
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
          Object[] prmH00292;
          prmH00292 = new Object[] {
          new ParDef("@lV100Contabilidad_plancuentaswwds_3_cuecod1",GXType.NChar,15,0) ,
          new ParDef("@lV100Contabilidad_plancuentaswwds_3_cuecod1",GXType.NChar,15,0) ,
          new ParDef("@lV101Contabilidad_plancuentaswwds_4_cuedsc1",GXType.NChar,100,0) ,
          new ParDef("@lV101Contabilidad_plancuentaswwds_4_cuedsc1",GXType.NChar,100,0) ,
          new ParDef("@AV102Contabilidad_plancuentaswwds_5_cuemov1",GXType.Int16,1,0) ,
          new ParDef("@lV106Contabilidad_plancuentaswwds_9_cuecod2",GXType.NChar,15,0) ,
          new ParDef("@lV106Contabilidad_plancuentaswwds_9_cuecod2",GXType.NChar,15,0) ,
          new ParDef("@lV107Contabilidad_plancuentaswwds_10_cuedsc2",GXType.NChar,100,0) ,
          new ParDef("@lV107Contabilidad_plancuentaswwds_10_cuedsc2",GXType.NChar,100,0) ,
          new ParDef("@AV108Contabilidad_plancuentaswwds_11_cuemov2",GXType.Int16,1,0) ,
          new ParDef("@lV112Contabilidad_plancuentaswwds_15_cuecod3",GXType.NChar,15,0) ,
          new ParDef("@lV112Contabilidad_plancuentaswwds_15_cuecod3",GXType.NChar,15,0) ,
          new ParDef("@lV113Contabilidad_plancuentaswwds_16_cuedsc3",GXType.NChar,100,0) ,
          new ParDef("@lV113Contabilidad_plancuentaswwds_16_cuedsc3",GXType.NChar,100,0) ,
          new ParDef("@AV114Contabilidad_plancuentaswwds_17_cuemov3",GXType.Int16,1,0) ,
          new ParDef("@lV115Contabilidad_plancuentaswwds_18_tfcuecod",GXType.NChar,15,0) ,
          new ParDef("@AV116Contabilidad_plancuentaswwds_19_tfcuecod_sel",GXType.NChar,15,0) ,
          new ParDef("@lV117Contabilidad_plancuentaswwds_20_tfcuedsc",GXType.NChar,100,0) ,
          new ParDef("@AV118Contabilidad_plancuentaswwds_21_tfcuedsc_sel",GXType.NChar,100,0) ,
          new ParDef("@lV122Contabilidad_plancuentaswwds_25_tfcuegasdebe",GXType.NChar,15,0) ,
          new ParDef("@AV123Contabilidad_plancuentaswwds_26_tfcuegasdebe_sel",GXType.NChar,15,0) ,
          new ParDef("@lV124Contabilidad_plancuentaswwds_27_tfcuegashaber",GXType.NChar,15,0) ,
          new ParDef("@AV125Contabilidad_plancuentaswwds_28_tfcuegashaber_sel",GXType.NChar,15,0) ,
          new ParDef("@GXPagingFrom2",GXType.Int32,9,0) ,
          new ParDef("@GXPagingTo2",GXType.Int32,9,0) ,
          new ParDef("@GXPagingTo2",GXType.Int32,9,0)
          };
          Object[] prmH00293;
          prmH00293 = new Object[] {
          new ParDef("@lV100Contabilidad_plancuentaswwds_3_cuecod1",GXType.NChar,15,0) ,
          new ParDef("@lV100Contabilidad_plancuentaswwds_3_cuecod1",GXType.NChar,15,0) ,
          new ParDef("@lV101Contabilidad_plancuentaswwds_4_cuedsc1",GXType.NChar,100,0) ,
          new ParDef("@lV101Contabilidad_plancuentaswwds_4_cuedsc1",GXType.NChar,100,0) ,
          new ParDef("@AV102Contabilidad_plancuentaswwds_5_cuemov1",GXType.Int16,1,0) ,
          new ParDef("@lV106Contabilidad_plancuentaswwds_9_cuecod2",GXType.NChar,15,0) ,
          new ParDef("@lV106Contabilidad_plancuentaswwds_9_cuecod2",GXType.NChar,15,0) ,
          new ParDef("@lV107Contabilidad_plancuentaswwds_10_cuedsc2",GXType.NChar,100,0) ,
          new ParDef("@lV107Contabilidad_plancuentaswwds_10_cuedsc2",GXType.NChar,100,0) ,
          new ParDef("@AV108Contabilidad_plancuentaswwds_11_cuemov2",GXType.Int16,1,0) ,
          new ParDef("@lV112Contabilidad_plancuentaswwds_15_cuecod3",GXType.NChar,15,0) ,
          new ParDef("@lV112Contabilidad_plancuentaswwds_15_cuecod3",GXType.NChar,15,0) ,
          new ParDef("@lV113Contabilidad_plancuentaswwds_16_cuedsc3",GXType.NChar,100,0) ,
          new ParDef("@lV113Contabilidad_plancuentaswwds_16_cuedsc3",GXType.NChar,100,0) ,
          new ParDef("@AV114Contabilidad_plancuentaswwds_17_cuemov3",GXType.Int16,1,0) ,
          new ParDef("@lV115Contabilidad_plancuentaswwds_18_tfcuecod",GXType.NChar,15,0) ,
          new ParDef("@AV116Contabilidad_plancuentaswwds_19_tfcuecod_sel",GXType.NChar,15,0) ,
          new ParDef("@lV117Contabilidad_plancuentaswwds_20_tfcuedsc",GXType.NChar,100,0) ,
          new ParDef("@AV118Contabilidad_plancuentaswwds_21_tfcuedsc_sel",GXType.NChar,100,0) ,
          new ParDef("@lV122Contabilidad_plancuentaswwds_25_tfcuegasdebe",GXType.NChar,15,0) ,
          new ParDef("@AV123Contabilidad_plancuentaswwds_26_tfcuegasdebe_sel",GXType.NChar,15,0) ,
          new ParDef("@lV124Contabilidad_plancuentaswwds_27_tfcuegashaber",GXType.NChar,15,0) ,
          new ParDef("@AV125Contabilidad_plancuentaswwds_28_tfcuegashaber_sel",GXType.NChar,15,0)
          };
          def= new CursorDef[] {
              new CursorDef("H00292", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH00292,11, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("H00293", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH00293,1, GxCacheFrequency.OFF ,true,false )
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
                ((string[]) buf[1])[0] = rslt.getString(2, 15);
                ((bool[]) buf[2])[0] = rslt.wasNull(2);
                ((string[]) buf[3])[0] = rslt.getString(3, 15);
                ((bool[]) buf[4])[0] = rslt.wasNull(3);
                ((short[]) buf[5])[0] = rslt.getShort(4);
                ((short[]) buf[6])[0] = rslt.getShort(5);
                ((short[]) buf[7])[0] = rslt.getShort(6);
                ((string[]) buf[8])[0] = rslt.getString(7, 100);
                ((string[]) buf[9])[0] = rslt.getString(8, 15);
                return;
             case 1 :
                ((long[]) buf[0])[0] = rslt.getLong(1);
                return;
       }
    }

 }

}
