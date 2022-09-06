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
   public class usuariosww : GXDataArea
   {
      public usuariosww( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDataStore2 = context.GetDataStore("DataStore2");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusTheme");
      }

      public usuariosww( IGxContext context )
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
         cmbUsuSts = new GXCombobox();
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
               AV94UsuVendDsc1 = GetPar( "UsuVendDsc1");
               AV95UsuTieDsc1 = GetPar( "UsuTieDsc1");
               AV89UsuNom1 = GetPar( "UsuNom1");
               cmbavDynamicfiltersselector2.FromJSonString( GetNextPar( ));
               AV19DynamicFiltersSelector2 = GetPar( "DynamicFiltersSelector2");
               cmbavDynamicfiltersoperator2.FromJSonString( GetNextPar( ));
               AV20DynamicFiltersOperator2 = (short)(NumberUtil.Val( GetPar( "DynamicFiltersOperator2"), "."));
               AV96UsuVendDsc2 = GetPar( "UsuVendDsc2");
               AV97UsuTieDsc2 = GetPar( "UsuTieDsc2");
               AV90UsuNom2 = GetPar( "UsuNom2");
               cmbavDynamicfiltersselector3.FromJSonString( GetNextPar( ));
               AV23DynamicFiltersSelector3 = GetPar( "DynamicFiltersSelector3");
               cmbavDynamicfiltersoperator3.FromJSonString( GetNextPar( ));
               AV24DynamicFiltersOperator3 = (short)(NumberUtil.Val( GetPar( "DynamicFiltersOperator3"), "."));
               AV98UsuVendDsc3 = GetPar( "UsuVendDsc3");
               AV99UsuTieDsc3 = GetPar( "UsuTieDsc3");
               AV91UsuNom3 = GetPar( "UsuNom3");
               AV18DynamicFiltersEnabled2 = StringUtil.StrToBool( GetPar( "DynamicFiltersEnabled2"));
               AV22DynamicFiltersEnabled3 = StringUtil.StrToBool( GetPar( "DynamicFiltersEnabled3"));
               AV106Pgmname = GetPar( "Pgmname");
               AV31TFUsuCod = GetPar( "TFUsuCod");
               AV32TFUsuCod_Sel = GetPar( "TFUsuCod_Sel");
               AV35TFUsuNom = GetPar( "TFUsuNom");
               AV36TFUsuNom_Sel = GetPar( "TFUsuNom_Sel");
               AV67TFUsuEMAIL = GetPar( "TFUsuEMAIL");
               AV68TFUsuEMAIL_Sel = GetPar( "TFUsuEMAIL_Sel");
               ajax_req_read_hidden_sdt(GetNextPar( ), AV93TFUsuSts_Sels);
               AV100TFUsuVendDsc = GetPar( "TFUsuVendDsc");
               AV101TFUsuVendDsc_Sel = GetPar( "TFUsuVendDsc_Sel");
               AV102TFUsuTieDsc = GetPar( "TFUsuTieDsc");
               AV103TFUsuTieDsc_Sel = GetPar( "TFUsuTieDsc_Sel");
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
               gxgrGrid_refresh( subGrid_Rows, AV15DynamicFiltersSelector1, AV16DynamicFiltersOperator1, AV94UsuVendDsc1, AV95UsuTieDsc1, AV89UsuNom1, AV19DynamicFiltersSelector2, AV20DynamicFiltersOperator2, AV96UsuVendDsc2, AV97UsuTieDsc2, AV90UsuNom2, AV23DynamicFiltersSelector3, AV24DynamicFiltersOperator3, AV98UsuVendDsc3, AV99UsuTieDsc3, AV91UsuNom3, AV18DynamicFiltersEnabled2, AV22DynamicFiltersEnabled3, AV106Pgmname, AV31TFUsuCod, AV32TFUsuCod_Sel, AV35TFUsuNom, AV36TFUsuNom_Sel, AV67TFUsuEMAIL, AV68TFUsuEMAIL_Sel, AV93TFUsuSts_Sels, AV100TFUsuVendDsc, AV101TFUsuVendDsc_Sel, AV102TFUsuTieDsc, AV103TFUsuTieDsc_Sel, AV13OrderedBy, AV14OrderedDsc, AV10GridState, AV27DynamicFiltersIgnoreFirst, AV26DynamicFiltersRemoving) ;
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
         PA0H2( ) ;
         gxajaxcallmode = (short)((isAjaxCallMode( ) ? 1 : 0));
         if ( ( gxajaxcallmode == 0 ) && ( GxWebError == 0 ) )
         {
            START0H2( ) ;
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
         context.AddJavascriptSource("gxcfg.js", "?202281810281096", false, true);
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
         context.WriteHtmlTextNl( "<form id=\"MAINFORM\" autocomplete=\"off\" name=\"MAINFORM\" method=\"post\" tabindex=-1  class=\"form-horizontal Form\" data-gx-class=\"form-horizontal Form\" novalidate action=\""+formatLink("seguridad.usuariosww.aspx") +"\">") ;
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
         GxWebStd.gx_hidden_field( context, "gxhash_vPGMNAME", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( AV106Pgmname, "")), context));
         GXKey = Crypto.GetSiteKey( );
      }

      protected void SendCloseFormHiddens( )
      {
         /* Send hidden variables. */
         GxWebStd.gx_hidden_field( context, "GXH_vDYNAMICFILTERSSELECTOR1", AV15DynamicFiltersSelector1);
         GxWebStd.gx_hidden_field( context, "GXH_vDYNAMICFILTERSOPERATOR1", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV16DynamicFiltersOperator1), 4, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "GXH_vUSUVENDDSC1", StringUtil.RTrim( AV94UsuVendDsc1));
         GxWebStd.gx_hidden_field( context, "GXH_vUSUTIEDSC1", StringUtil.RTrim( AV95UsuTieDsc1));
         GxWebStd.gx_hidden_field( context, "GXH_vUSUNOM1", StringUtil.RTrim( AV89UsuNom1));
         GxWebStd.gx_hidden_field( context, "GXH_vDYNAMICFILTERSSELECTOR2", AV19DynamicFiltersSelector2);
         GxWebStd.gx_hidden_field( context, "GXH_vDYNAMICFILTERSOPERATOR2", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV20DynamicFiltersOperator2), 4, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "GXH_vUSUVENDDSC2", StringUtil.RTrim( AV96UsuVendDsc2));
         GxWebStd.gx_hidden_field( context, "GXH_vUSUTIEDSC2", StringUtil.RTrim( AV97UsuTieDsc2));
         GxWebStd.gx_hidden_field( context, "GXH_vUSUNOM2", StringUtil.RTrim( AV90UsuNom2));
         GxWebStd.gx_hidden_field( context, "GXH_vDYNAMICFILTERSSELECTOR3", AV23DynamicFiltersSelector3);
         GxWebStd.gx_hidden_field( context, "GXH_vDYNAMICFILTERSOPERATOR3", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV24DynamicFiltersOperator3), 4, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "GXH_vUSUVENDDSC3", StringUtil.RTrim( AV98UsuVendDsc3));
         GxWebStd.gx_hidden_field( context, "GXH_vUSUTIEDSC3", StringUtil.RTrim( AV99UsuTieDsc3));
         GxWebStd.gx_hidden_field( context, "GXH_vUSUNOM3", StringUtil.RTrim( AV91UsuNom3));
         /* Send saved values. */
         send_integrity_footer_hashes( ) ;
         GxWebStd.gx_hidden_field( context, "nRC_GXsfl_119", StringUtil.LTrim( StringUtil.NToC( (decimal)(nRC_GXsfl_119), 8, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "vGRIDCURRENTPAGE", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV83GridCurrentPage), 10, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "vGRIDPAGECOUNT", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV84GridPageCount), 10, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "vGRIDAPPLIEDFILTERS", AV85GridAppliedFilters);
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "vAGEXPORTDATA", AV87AGExportData);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt("vAGEXPORTDATA", AV87AGExportData);
         }
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "vDDO_TITLESETTINGSICONS", AV81DDO_TitleSettingsIcons);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt("vDDO_TITLESETTINGSICONS", AV81DDO_TitleSettingsIcons);
         }
         GxWebStd.gx_boolean_hidden_field( context, "vDYNAMICFILTERSENABLED2", AV18DynamicFiltersEnabled2);
         GxWebStd.gx_boolean_hidden_field( context, "vDYNAMICFILTERSENABLED3", AV22DynamicFiltersEnabled3);
         GxWebStd.gx_hidden_field( context, "vPGMNAME", StringUtil.RTrim( AV106Pgmname));
         GxWebStd.gx_hidden_field( context, "gxhash_vPGMNAME", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( AV106Pgmname, "")), context));
         GxWebStd.gx_hidden_field( context, "vTFUSUCOD", StringUtil.RTrim( AV31TFUsuCod));
         GxWebStd.gx_hidden_field( context, "vTFUSUCOD_SEL", StringUtil.RTrim( AV32TFUsuCod_Sel));
         GxWebStd.gx_hidden_field( context, "vTFUSUNOM", StringUtil.RTrim( AV35TFUsuNom));
         GxWebStd.gx_hidden_field( context, "vTFUSUNOM_SEL", StringUtil.RTrim( AV36TFUsuNom_Sel));
         GxWebStd.gx_hidden_field( context, "vTFUSUEMAIL", AV67TFUsuEMAIL);
         GxWebStd.gx_hidden_field( context, "vTFUSUEMAIL_SEL", AV68TFUsuEMAIL_Sel);
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "vTFUSUSTS_SELS", AV93TFUsuSts_Sels);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt("vTFUSUSTS_SELS", AV93TFUsuSts_Sels);
         }
         GxWebStd.gx_hidden_field( context, "vTFUSUVENDDSC", StringUtil.RTrim( AV100TFUsuVendDsc));
         GxWebStd.gx_hidden_field( context, "vTFUSUVENDDSC_SEL", StringUtil.RTrim( AV101TFUsuVendDsc_Sel));
         GxWebStd.gx_hidden_field( context, "vTFUSUTIEDSC", StringUtil.RTrim( AV102TFUsuTieDsc));
         GxWebStd.gx_hidden_field( context, "vTFUSUTIEDSC_SEL", StringUtil.RTrim( AV103TFUsuTieDsc_Sel));
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
         GxWebStd.gx_hidden_field( context, "USUVEND", StringUtil.LTrim( StringUtil.NToC( (decimal)(A2041UsuVend), 6, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "USUTIECOD", StringUtil.LTrim( StringUtil.NToC( (decimal)(A2040UsuTieCod), 6, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "vTFUSUSTS_SELSJSON", AV92TFUsuSts_SelsJson);
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
            WE0H2( ) ;
            context.WriteHtmlText( "</div>") ;
         }
      }

      public override void DispatchEvents( )
      {
         EVT0H2( ) ;
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
         return formatLink("seguridad.usuariosww.aspx")  ;
      }

      public override string GetPgmname( )
      {
         return "Seguridad.UsuariosWW" ;
      }

      public override string GetPgmdesc( )
      {
         return " Usuarios" ;
      }

      protected void WB0H0( )
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
            ClassString = "ButtonColor Button";
            StyleString = "";
            GxWebStd.gx_button_ctrl( context, bttBtninsert_Internalname, "gx.evt.setGridEvt("+StringUtil.Str( (decimal)(119), 3, 0)+","+"null"+");", "Agregar", bttBtninsert_Jsonclick, 5, "Agregar", "", StyleString, ClassString, 1, 1, "standard", "'"+""+"'"+",false,"+"'"+"E\\'DOINSERT\\'."+"'", TempTags, "", context.GetButtonType( ), "HLP_Seguridad\\UsuariosWW.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "left", "top", "", "", "div");
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 21,'',false,'',0)\"";
            ClassString = "ColumnsSelector";
            StyleString = "";
            GxWebStd.gx_button_ctrl( context, bttBtnagexport_Internalname, "gx.evt.setGridEvt("+StringUtil.Str( (decimal)(119), 3, 0)+","+"null"+");", "Reportes", bttBtnagexport_Jsonclick, 0, "Reportes", "", StyleString, ClassString, 1, 0, "standard", "'"+""+"'"+",false,"+"'"+""+"'", TempTags, "", context.GetButtonType( ), "HLP_Seguridad\\UsuariosWW.htm");
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
            wb_table1_25_0H2( true) ;
         }
         else
         {
            wb_table1_25_0H2( false) ;
         }
         return  ;
      }

      protected void wb_table1_25_0H2e( bool wbgen )
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
               context.SendWebValue( "Usuario") ;
               context.WriteHtmlTextNl( "</th>") ;
               context.WriteHtmlText( "<th align=\""+"left"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+""+""+"\" "+">") ;
               context.SendWebValue( "Nombre Usuario") ;
               context.WriteHtmlTextNl( "</th>") ;
               context.WriteHtmlText( "<th align=\""+"left"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+""+""+"\" "+">") ;
               context.SendWebValue( "E-Mail") ;
               context.WriteHtmlTextNl( "</th>") ;
               context.WriteHtmlText( "<th align=\""+"right"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+""+""+"\" "+">") ;
               context.SendWebValue( "Estado") ;
               context.WriteHtmlTextNl( "</th>") ;
               context.WriteHtmlText( "<th align=\""+"left"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+""+""+"\" "+">") ;
               context.SendWebValue( "Vendedor") ;
               context.WriteHtmlTextNl( "</th>") ;
               context.WriteHtmlText( "<th align=\""+"left"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+""+""+"\" "+">") ;
               context.SendWebValue( "Local") ;
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
               GridColumn.AddObjectProperty("Value", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV86GridActions), 4, 0, ".", "")));
               GridContainer.AddColumnProperties(GridColumn);
               GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
               GridColumn.AddObjectProperty("Value", StringUtil.RTrim( A348UsuCod));
               GridColumn.AddObjectProperty("Columnclass", StringUtil.RTrim( edtUsuCod_Columnclass));
               GridColumn.AddObjectProperty("Columnheaderclass", StringUtil.RTrim( edtUsuCod_Columnheaderclass));
               GridColumn.AddObjectProperty("Link", StringUtil.RTrim( edtUsuCod_Link));
               GridContainer.AddColumnProperties(GridColumn);
               GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
               GridColumn.AddObjectProperty("Value", StringUtil.RTrim( A2019UsuNom));
               GridColumn.AddObjectProperty("Columnclass", StringUtil.RTrim( edtUsuNom_Columnclass));
               GridColumn.AddObjectProperty("Columnheaderclass", StringUtil.RTrim( edtUsuNom_Columnheaderclass));
               GridColumn.AddObjectProperty("Link", StringUtil.RTrim( edtUsuNom_Link));
               GridContainer.AddColumnProperties(GridColumn);
               GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
               GridColumn.AddObjectProperty("Value", A2014UsuEMAIL);
               GridColumn.AddObjectProperty("Columnclass", StringUtil.RTrim( edtUsuEMAIL_Columnclass));
               GridColumn.AddObjectProperty("Columnheaderclass", StringUtil.RTrim( edtUsuEMAIL_Columnheaderclass));
               GridContainer.AddColumnProperties(GridColumn);
               GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
               GridColumn.AddObjectProperty("Value", StringUtil.LTrim( StringUtil.NToC( (decimal)(A2039UsuSts), 1, 0, ".", "")));
               GridColumn.AddObjectProperty("Columnclass", StringUtil.RTrim( cmbUsuSts_Columnclass));
               GridColumn.AddObjectProperty("Columnheaderclass", StringUtil.RTrim( cmbUsuSts_Columnheaderclass));
               GridContainer.AddColumnProperties(GridColumn);
               GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
               GridColumn.AddObjectProperty("Value", StringUtil.RTrim( A2097UsuVendDsc));
               GridColumn.AddObjectProperty("Link", StringUtil.RTrim( edtUsuVendDsc_Link));
               GridContainer.AddColumnProperties(GridColumn);
               GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
               GridColumn.AddObjectProperty("Value", StringUtil.RTrim( A2096UsuTieDsc));
               GridColumn.AddObjectProperty("Link", StringUtil.RTrim( edtUsuTieDsc_Link));
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
            ucGridpaginationbar.SetProperty("CurrentPage", AV83GridCurrentPage);
            ucGridpaginationbar.SetProperty("PageCount", AV84GridPageCount);
            ucGridpaginationbar.SetProperty("AppliedFilters", AV85GridAppliedFilters);
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
            ucDdo_agexport.SetProperty("DropDownOptionsData", AV87AGExportData);
            ucDdo_agexport.Render(context, "dvelop.gxbootstrap.ddoregular", Ddo_agexport_Internalname, "DDO_AGEXPORTContainer");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblJsdynamicfilters_Internalname, lblJsdynamicfilters_Caption, "", "", lblJsdynamicfilters_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "", 0, "", 1, 1, 0, 1, "HLP_Seguridad\\UsuariosWW.htm");
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
            ucDdo_grid.SetProperty("DropDownOptionsTitleSettingsIcons", AV81DDO_TitleSettingsIcons);
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

      protected void START0H2( )
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
            Form.Meta.addItem("description", " Usuarios", 0) ;
         }
         context.wjLoc = "";
         context.nUserReturn = 0;
         context.wbHandled = 0;
         if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
         {
         }
         wbErr = false;
         STRUP0H0( ) ;
      }

      protected void WS0H2( )
      {
         START0H2( ) ;
         EVT0H2( ) ;
      }

      protected void EVT0H2( )
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
                              E110H2 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "GRIDPAGINATIONBAR.CHANGEROWSPERPAGE") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              E120H2 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "DDO_AGEXPORT.ONOPTIONCLICKED") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              E130H2 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "DDO_GRID.ONOPTIONCLICKED") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              E140H2 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "'REMOVEDYNAMICFILTERS1'") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              /* Execute user event: 'RemoveDynamicFilters1' */
                              E150H2 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "'REMOVEDYNAMICFILTERS2'") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              /* Execute user event: 'RemoveDynamicFilters2' */
                              E160H2 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "'REMOVEDYNAMICFILTERS3'") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              /* Execute user event: 'RemoveDynamicFilters3' */
                              E170H2 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "'DOINSERT'") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              /* Execute user event: 'DoInsert' */
                              E180H2 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "'ADDDYNAMICFILTERS1'") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              /* Execute user event: 'AddDynamicFilters1' */
                              E190H2 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "VDYNAMICFILTERSSELECTOR1.CLICK") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              E200H2 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "'ADDDYNAMICFILTERS2'") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              /* Execute user event: 'AddDynamicFilters2' */
                              E210H2 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "VDYNAMICFILTERSSELECTOR2.CLICK") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              E220H2 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "VDYNAMICFILTERSSELECTOR3.CLICK") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              E230H2 ();
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
                              AV86GridActions = (short)(NumberUtil.Val( cgiGet( cmbavGridactions_Internalname), "."));
                              AssignAttri("", false, cmbavGridactions_Internalname, StringUtil.LTrimStr( (decimal)(AV86GridActions), 4, 0));
                              A348UsuCod = cgiGet( edtUsuCod_Internalname);
                              A2019UsuNom = cgiGet( edtUsuNom_Internalname);
                              A2014UsuEMAIL = cgiGet( edtUsuEMAIL_Internalname);
                              cmbUsuSts.Name = cmbUsuSts_Internalname;
                              cmbUsuSts.CurrentValue = cgiGet( cmbUsuSts_Internalname);
                              A2039UsuSts = (short)(NumberUtil.Val( cgiGet( cmbUsuSts_Internalname), "."));
                              A2097UsuVendDsc = cgiGet( edtUsuVendDsc_Internalname);
                              A2096UsuTieDsc = cgiGet( edtUsuTieDsc_Internalname);
                              sEvtType = StringUtil.Right( sEvt, 1);
                              if ( StringUtil.StrCmp(sEvtType, ".") == 0 )
                              {
                                 sEvt = StringUtil.Left( sEvt, (short)(StringUtil.Len( sEvt)-1));
                                 if ( StringUtil.StrCmp(sEvt, "START") == 0 )
                                 {
                                    context.wbHandled = 1;
                                    dynload_actions( ) ;
                                    /* Execute user event: Start */
                                    E240H2 ();
                                 }
                                 else if ( StringUtil.StrCmp(sEvt, "REFRESH") == 0 )
                                 {
                                    context.wbHandled = 1;
                                    dynload_actions( ) ;
                                    /* Execute user event: Refresh */
                                    E250H2 ();
                                 }
                                 else if ( StringUtil.StrCmp(sEvt, "GRID.LOAD") == 0 )
                                 {
                                    context.wbHandled = 1;
                                    dynload_actions( ) ;
                                    E260H2 ();
                                 }
                                 else if ( StringUtil.StrCmp(sEvt, "VGRIDACTIONS.CLICK") == 0 )
                                 {
                                    context.wbHandled = 1;
                                    dynload_actions( ) ;
                                    E270H2 ();
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
                                       /* Set Refresh If Usuvenddsc1 Changed */
                                       if ( StringUtil.StrCmp(cgiGet( "GXH_vUSUVENDDSC1"), AV94UsuVendDsc1) != 0 )
                                       {
                                          Rfr0gs = true;
                                       }
                                       /* Set Refresh If Usutiedsc1 Changed */
                                       if ( StringUtil.StrCmp(cgiGet( "GXH_vUSUTIEDSC1"), AV95UsuTieDsc1) != 0 )
                                       {
                                          Rfr0gs = true;
                                       }
                                       /* Set Refresh If Usunom1 Changed */
                                       if ( StringUtil.StrCmp(cgiGet( "GXH_vUSUNOM1"), AV89UsuNom1) != 0 )
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
                                       /* Set Refresh If Usuvenddsc2 Changed */
                                       if ( StringUtil.StrCmp(cgiGet( "GXH_vUSUVENDDSC2"), AV96UsuVendDsc2) != 0 )
                                       {
                                          Rfr0gs = true;
                                       }
                                       /* Set Refresh If Usutiedsc2 Changed */
                                       if ( StringUtil.StrCmp(cgiGet( "GXH_vUSUTIEDSC2"), AV97UsuTieDsc2) != 0 )
                                       {
                                          Rfr0gs = true;
                                       }
                                       /* Set Refresh If Usunom2 Changed */
                                       if ( StringUtil.StrCmp(cgiGet( "GXH_vUSUNOM2"), AV90UsuNom2) != 0 )
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
                                       /* Set Refresh If Usuvenddsc3 Changed */
                                       if ( StringUtil.StrCmp(cgiGet( "GXH_vUSUVENDDSC3"), AV98UsuVendDsc3) != 0 )
                                       {
                                          Rfr0gs = true;
                                       }
                                       /* Set Refresh If Usutiedsc3 Changed */
                                       if ( StringUtil.StrCmp(cgiGet( "GXH_vUSUTIEDSC3"), AV99UsuTieDsc3) != 0 )
                                       {
                                          Rfr0gs = true;
                                       }
                                       /* Set Refresh If Usunom3 Changed */
                                       if ( StringUtil.StrCmp(cgiGet( "GXH_vUSUNOM3"), AV91UsuNom3) != 0 )
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

      protected void WE0H2( )
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

      protected void PA0H2( )
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
                                       string AV94UsuVendDsc1 ,
                                       string AV95UsuTieDsc1 ,
                                       string AV89UsuNom1 ,
                                       string AV19DynamicFiltersSelector2 ,
                                       short AV20DynamicFiltersOperator2 ,
                                       string AV96UsuVendDsc2 ,
                                       string AV97UsuTieDsc2 ,
                                       string AV90UsuNom2 ,
                                       string AV23DynamicFiltersSelector3 ,
                                       short AV24DynamicFiltersOperator3 ,
                                       string AV98UsuVendDsc3 ,
                                       string AV99UsuTieDsc3 ,
                                       string AV91UsuNom3 ,
                                       bool AV18DynamicFiltersEnabled2 ,
                                       bool AV22DynamicFiltersEnabled3 ,
                                       string AV106Pgmname ,
                                       string AV31TFUsuCod ,
                                       string AV32TFUsuCod_Sel ,
                                       string AV35TFUsuNom ,
                                       string AV36TFUsuNom_Sel ,
                                       string AV67TFUsuEMAIL ,
                                       string AV68TFUsuEMAIL_Sel ,
                                       GxSimpleCollection<short> AV93TFUsuSts_Sels ,
                                       string AV100TFUsuVendDsc ,
                                       string AV101TFUsuVendDsc_Sel ,
                                       string AV102TFUsuTieDsc ,
                                       string AV103TFUsuTieDsc_Sel ,
                                       short AV13OrderedBy ,
                                       bool AV14OrderedDsc ,
                                       GeneXus.Programs.wwpbaseobjects.SdtWWPGridState AV10GridState ,
                                       bool AV27DynamicFiltersIgnoreFirst ,
                                       bool AV26DynamicFiltersRemoving )
      {
         initialize_formulas( ) ;
         GxWebStd.set_html_headers( context, 0, "", "");
         /* Execute user event: Refresh */
         E250H2 ();
         GRID_nCurrentRecord = 0;
         RF0H2( ) ;
         GXKey = Crypto.GetSiteKey( );
         send_integrity_footer_hashes( ) ;
         GXKey = Crypto.GetSiteKey( );
         /* End function gxgrGrid_refresh */
      }

      protected void send_integrity_hashes( )
      {
         GxWebStd.gx_hidden_field( context, "gxhash_USUCOD", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( A348UsuCod, "")), context));
         GxWebStd.gx_hidden_field( context, "USUCOD", StringUtil.RTrim( A348UsuCod));
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
         RF0H2( ) ;
         if ( isFullAjaxMode( ) )
         {
            send_integrity_footer_hashes( ) ;
         }
      }

      protected void initialize_formulas( )
      {
         /* GeneXus formulas. */
         AV106Pgmname = "Seguridad.UsuariosWW";
         context.Gx_err = 0;
      }

      protected void RF0H2( )
      {
         initialize_formulas( ) ;
         clear_multi_value_controls( ) ;
         if ( isAjaxCallMode( ) )
         {
            GridContainer.ClearRows();
         }
         wbStart = 119;
         /* Execute user event: Refresh */
         E250H2 ();
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
                                                 A2039UsuSts ,
                                                 AV130Seguridad_usuarioswwds_24_tfususts_sels ,
                                                 AV107Seguridad_usuarioswwds_1_dynamicfiltersselector1 ,
                                                 AV108Seguridad_usuarioswwds_2_dynamicfiltersoperator1 ,
                                                 AV109Seguridad_usuarioswwds_3_usuvenddsc1 ,
                                                 AV110Seguridad_usuarioswwds_4_usutiedsc1 ,
                                                 AV111Seguridad_usuarioswwds_5_usunom1 ,
                                                 AV112Seguridad_usuarioswwds_6_dynamicfiltersenabled2 ,
                                                 AV113Seguridad_usuarioswwds_7_dynamicfiltersselector2 ,
                                                 AV114Seguridad_usuarioswwds_8_dynamicfiltersoperator2 ,
                                                 AV115Seguridad_usuarioswwds_9_usuvenddsc2 ,
                                                 AV116Seguridad_usuarioswwds_10_usutiedsc2 ,
                                                 AV117Seguridad_usuarioswwds_11_usunom2 ,
                                                 AV118Seguridad_usuarioswwds_12_dynamicfiltersenabled3 ,
                                                 AV119Seguridad_usuarioswwds_13_dynamicfiltersselector3 ,
                                                 AV120Seguridad_usuarioswwds_14_dynamicfiltersoperator3 ,
                                                 AV121Seguridad_usuarioswwds_15_usuvenddsc3 ,
                                                 AV122Seguridad_usuarioswwds_16_usutiedsc3 ,
                                                 AV123Seguridad_usuarioswwds_17_usunom3 ,
                                                 AV125Seguridad_usuarioswwds_19_tfusucod_sel ,
                                                 AV124Seguridad_usuarioswwds_18_tfusucod ,
                                                 AV127Seguridad_usuarioswwds_21_tfusunom_sel ,
                                                 AV126Seguridad_usuarioswwds_20_tfusunom ,
                                                 AV129Seguridad_usuarioswwds_23_tfusuemail_sel ,
                                                 AV128Seguridad_usuarioswwds_22_tfusuemail ,
                                                 AV130Seguridad_usuarioswwds_24_tfususts_sels.Count ,
                                                 AV132Seguridad_usuarioswwds_26_tfusuvenddsc_sel ,
                                                 AV131Seguridad_usuarioswwds_25_tfusuvenddsc ,
                                                 AV134Seguridad_usuarioswwds_28_tfusutiedsc_sel ,
                                                 AV133Seguridad_usuarioswwds_27_tfusutiedsc ,
                                                 A2097UsuVendDsc ,
                                                 A2096UsuTieDsc ,
                                                 A2019UsuNom ,
                                                 A348UsuCod ,
                                                 A2014UsuEMAIL ,
                                                 AV13OrderedBy ,
                                                 AV14OrderedDsc } ,
                                                 new int[]{
                                                 TypeConstants.SHORT, TypeConstants.SHORT, TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.INT, TypeConstants.SHORT, TypeConstants.BOOLEAN
                                                 }
            });
            lV109Seguridad_usuarioswwds_3_usuvenddsc1 = StringUtil.PadR( StringUtil.RTrim( AV109Seguridad_usuarioswwds_3_usuvenddsc1), 100, "%");
            lV109Seguridad_usuarioswwds_3_usuvenddsc1 = StringUtil.PadR( StringUtil.RTrim( AV109Seguridad_usuarioswwds_3_usuvenddsc1), 100, "%");
            lV110Seguridad_usuarioswwds_4_usutiedsc1 = StringUtil.PadR( StringUtil.RTrim( AV110Seguridad_usuarioswwds_4_usutiedsc1), 100, "%");
            lV110Seguridad_usuarioswwds_4_usutiedsc1 = StringUtil.PadR( StringUtil.RTrim( AV110Seguridad_usuarioswwds_4_usutiedsc1), 100, "%");
            lV111Seguridad_usuarioswwds_5_usunom1 = StringUtil.PadR( StringUtil.RTrim( AV111Seguridad_usuarioswwds_5_usunom1), 100, "%");
            lV111Seguridad_usuarioswwds_5_usunom1 = StringUtil.PadR( StringUtil.RTrim( AV111Seguridad_usuarioswwds_5_usunom1), 100, "%");
            lV115Seguridad_usuarioswwds_9_usuvenddsc2 = StringUtil.PadR( StringUtil.RTrim( AV115Seguridad_usuarioswwds_9_usuvenddsc2), 100, "%");
            lV115Seguridad_usuarioswwds_9_usuvenddsc2 = StringUtil.PadR( StringUtil.RTrim( AV115Seguridad_usuarioswwds_9_usuvenddsc2), 100, "%");
            lV116Seguridad_usuarioswwds_10_usutiedsc2 = StringUtil.PadR( StringUtil.RTrim( AV116Seguridad_usuarioswwds_10_usutiedsc2), 100, "%");
            lV116Seguridad_usuarioswwds_10_usutiedsc2 = StringUtil.PadR( StringUtil.RTrim( AV116Seguridad_usuarioswwds_10_usutiedsc2), 100, "%");
            lV117Seguridad_usuarioswwds_11_usunom2 = StringUtil.PadR( StringUtil.RTrim( AV117Seguridad_usuarioswwds_11_usunom2), 100, "%");
            lV117Seguridad_usuarioswwds_11_usunom2 = StringUtil.PadR( StringUtil.RTrim( AV117Seguridad_usuarioswwds_11_usunom2), 100, "%");
            lV121Seguridad_usuarioswwds_15_usuvenddsc3 = StringUtil.PadR( StringUtil.RTrim( AV121Seguridad_usuarioswwds_15_usuvenddsc3), 100, "%");
            lV121Seguridad_usuarioswwds_15_usuvenddsc3 = StringUtil.PadR( StringUtil.RTrim( AV121Seguridad_usuarioswwds_15_usuvenddsc3), 100, "%");
            lV122Seguridad_usuarioswwds_16_usutiedsc3 = StringUtil.PadR( StringUtil.RTrim( AV122Seguridad_usuarioswwds_16_usutiedsc3), 100, "%");
            lV122Seguridad_usuarioswwds_16_usutiedsc3 = StringUtil.PadR( StringUtil.RTrim( AV122Seguridad_usuarioswwds_16_usutiedsc3), 100, "%");
            lV123Seguridad_usuarioswwds_17_usunom3 = StringUtil.PadR( StringUtil.RTrim( AV123Seguridad_usuarioswwds_17_usunom3), 100, "%");
            lV123Seguridad_usuarioswwds_17_usunom3 = StringUtil.PadR( StringUtil.RTrim( AV123Seguridad_usuarioswwds_17_usunom3), 100, "%");
            lV124Seguridad_usuarioswwds_18_tfusucod = StringUtil.PadR( StringUtil.RTrim( AV124Seguridad_usuarioswwds_18_tfusucod), 10, "%");
            lV126Seguridad_usuarioswwds_20_tfusunom = StringUtil.PadR( StringUtil.RTrim( AV126Seguridad_usuarioswwds_20_tfusunom), 100, "%");
            lV128Seguridad_usuarioswwds_22_tfusuemail = StringUtil.Concat( StringUtil.RTrim( AV128Seguridad_usuarioswwds_22_tfusuemail), "%", "");
            lV131Seguridad_usuarioswwds_25_tfusuvenddsc = StringUtil.PadR( StringUtil.RTrim( AV131Seguridad_usuarioswwds_25_tfusuvenddsc), 100, "%");
            lV133Seguridad_usuarioswwds_27_tfusutiedsc = StringUtil.PadR( StringUtil.RTrim( AV133Seguridad_usuarioswwds_27_tfusutiedsc), 100, "%");
            /* Using cursor H000H2 */
            pr_default.execute(0, new Object[] {lV109Seguridad_usuarioswwds_3_usuvenddsc1, lV109Seguridad_usuarioswwds_3_usuvenddsc1, lV110Seguridad_usuarioswwds_4_usutiedsc1, lV110Seguridad_usuarioswwds_4_usutiedsc1, lV111Seguridad_usuarioswwds_5_usunom1, lV111Seguridad_usuarioswwds_5_usunom1, lV115Seguridad_usuarioswwds_9_usuvenddsc2, lV115Seguridad_usuarioswwds_9_usuvenddsc2, lV116Seguridad_usuarioswwds_10_usutiedsc2, lV116Seguridad_usuarioswwds_10_usutiedsc2, lV117Seguridad_usuarioswwds_11_usunom2, lV117Seguridad_usuarioswwds_11_usunom2, lV121Seguridad_usuarioswwds_15_usuvenddsc3, lV121Seguridad_usuarioswwds_15_usuvenddsc3, lV122Seguridad_usuarioswwds_16_usutiedsc3, lV122Seguridad_usuarioswwds_16_usutiedsc3, lV123Seguridad_usuarioswwds_17_usunom3, lV123Seguridad_usuarioswwds_17_usunom3, lV124Seguridad_usuarioswwds_18_tfusucod, AV125Seguridad_usuarioswwds_19_tfusucod_sel, lV126Seguridad_usuarioswwds_20_tfusunom, AV127Seguridad_usuarioswwds_21_tfusunom_sel, lV128Seguridad_usuarioswwds_22_tfusuemail, AV129Seguridad_usuarioswwds_23_tfusuemail_sel, lV131Seguridad_usuarioswwds_25_tfusuvenddsc, AV132Seguridad_usuarioswwds_26_tfusuvenddsc_sel, lV133Seguridad_usuarioswwds_27_tfusutiedsc, AV134Seguridad_usuarioswwds_28_tfusutiedsc_sel, GXPagingFrom2, GXPagingTo2, GXPagingTo2});
            nGXsfl_119_idx = 1;
            sGXsfl_119_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_119_idx), 4, 0), 4, "0");
            SubsflControlProps_1192( ) ;
            while ( ( (pr_default.getStatus(0) != 101) ) && ( ( ( subGrid_Rows == 0 ) || ( GRID_nCurrentRecord < subGrid_fnc_Recordsperpage( ) ) ) ) )
            {
               A2041UsuVend = H000H2_A2041UsuVend[0];
               A2040UsuTieCod = H000H2_A2040UsuTieCod[0];
               A2096UsuTieDsc = H000H2_A2096UsuTieDsc[0];
               A2097UsuVendDsc = H000H2_A2097UsuVendDsc[0];
               A2039UsuSts = H000H2_A2039UsuSts[0];
               A2014UsuEMAIL = H000H2_A2014UsuEMAIL[0];
               A2019UsuNom = H000H2_A2019UsuNom[0];
               A348UsuCod = H000H2_A348UsuCod[0];
               A2097UsuVendDsc = H000H2_A2097UsuVendDsc[0];
               A2096UsuTieDsc = H000H2_A2096UsuTieDsc[0];
               E260H2 ();
               pr_default.readNext(0);
            }
            GRID_nEOF = (short)(((pr_default.getStatus(0) == 101) ? 1 : 0));
            GxWebStd.gx_hidden_field( context, "GRID_nEOF", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRID_nEOF), 1, 0, ".", "")));
            pr_default.close(0);
            wbEnd = 119;
            WB0H0( ) ;
         }
         bGXsfl_119_Refreshing = true;
      }

      protected void send_integrity_lvl_hashes0H2( )
      {
         GxWebStd.gx_hidden_field( context, "vPGMNAME", StringUtil.RTrim( AV106Pgmname));
         GxWebStd.gx_hidden_field( context, "gxhash_vPGMNAME", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( AV106Pgmname, "")), context));
         GxWebStd.gx_hidden_field( context, "gxhash_USUCOD"+"_"+sGXsfl_119_idx, GetSecureSignedToken( sGXsfl_119_idx, StringUtil.RTrim( context.localUtil.Format( A348UsuCod, "")), context));
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
         AV107Seguridad_usuarioswwds_1_dynamicfiltersselector1 = AV15DynamicFiltersSelector1;
         AV108Seguridad_usuarioswwds_2_dynamicfiltersoperator1 = AV16DynamicFiltersOperator1;
         AV109Seguridad_usuarioswwds_3_usuvenddsc1 = AV94UsuVendDsc1;
         AV110Seguridad_usuarioswwds_4_usutiedsc1 = AV95UsuTieDsc1;
         AV111Seguridad_usuarioswwds_5_usunom1 = AV89UsuNom1;
         AV112Seguridad_usuarioswwds_6_dynamicfiltersenabled2 = AV18DynamicFiltersEnabled2;
         AV113Seguridad_usuarioswwds_7_dynamicfiltersselector2 = AV19DynamicFiltersSelector2;
         AV114Seguridad_usuarioswwds_8_dynamicfiltersoperator2 = AV20DynamicFiltersOperator2;
         AV115Seguridad_usuarioswwds_9_usuvenddsc2 = AV96UsuVendDsc2;
         AV116Seguridad_usuarioswwds_10_usutiedsc2 = AV97UsuTieDsc2;
         AV117Seguridad_usuarioswwds_11_usunom2 = AV90UsuNom2;
         AV118Seguridad_usuarioswwds_12_dynamicfiltersenabled3 = AV22DynamicFiltersEnabled3;
         AV119Seguridad_usuarioswwds_13_dynamicfiltersselector3 = AV23DynamicFiltersSelector3;
         AV120Seguridad_usuarioswwds_14_dynamicfiltersoperator3 = AV24DynamicFiltersOperator3;
         AV121Seguridad_usuarioswwds_15_usuvenddsc3 = AV98UsuVendDsc3;
         AV122Seguridad_usuarioswwds_16_usutiedsc3 = AV99UsuTieDsc3;
         AV123Seguridad_usuarioswwds_17_usunom3 = AV91UsuNom3;
         AV124Seguridad_usuarioswwds_18_tfusucod = AV31TFUsuCod;
         AV125Seguridad_usuarioswwds_19_tfusucod_sel = AV32TFUsuCod_Sel;
         AV126Seguridad_usuarioswwds_20_tfusunom = AV35TFUsuNom;
         AV127Seguridad_usuarioswwds_21_tfusunom_sel = AV36TFUsuNom_Sel;
         AV128Seguridad_usuarioswwds_22_tfusuemail = AV67TFUsuEMAIL;
         AV129Seguridad_usuarioswwds_23_tfusuemail_sel = AV68TFUsuEMAIL_Sel;
         AV130Seguridad_usuarioswwds_24_tfususts_sels = AV93TFUsuSts_Sels;
         AV131Seguridad_usuarioswwds_25_tfusuvenddsc = AV100TFUsuVendDsc;
         AV132Seguridad_usuarioswwds_26_tfusuvenddsc_sel = AV101TFUsuVendDsc_Sel;
         AV133Seguridad_usuarioswwds_27_tfusutiedsc = AV102TFUsuTieDsc;
         AV134Seguridad_usuarioswwds_28_tfusutiedsc_sel = AV103TFUsuTieDsc_Sel;
         pr_default.dynParam(1, new Object[]{ new Object[]{
                                              A2039UsuSts ,
                                              AV130Seguridad_usuarioswwds_24_tfususts_sels ,
                                              AV107Seguridad_usuarioswwds_1_dynamicfiltersselector1 ,
                                              AV108Seguridad_usuarioswwds_2_dynamicfiltersoperator1 ,
                                              AV109Seguridad_usuarioswwds_3_usuvenddsc1 ,
                                              AV110Seguridad_usuarioswwds_4_usutiedsc1 ,
                                              AV111Seguridad_usuarioswwds_5_usunom1 ,
                                              AV112Seguridad_usuarioswwds_6_dynamicfiltersenabled2 ,
                                              AV113Seguridad_usuarioswwds_7_dynamicfiltersselector2 ,
                                              AV114Seguridad_usuarioswwds_8_dynamicfiltersoperator2 ,
                                              AV115Seguridad_usuarioswwds_9_usuvenddsc2 ,
                                              AV116Seguridad_usuarioswwds_10_usutiedsc2 ,
                                              AV117Seguridad_usuarioswwds_11_usunom2 ,
                                              AV118Seguridad_usuarioswwds_12_dynamicfiltersenabled3 ,
                                              AV119Seguridad_usuarioswwds_13_dynamicfiltersselector3 ,
                                              AV120Seguridad_usuarioswwds_14_dynamicfiltersoperator3 ,
                                              AV121Seguridad_usuarioswwds_15_usuvenddsc3 ,
                                              AV122Seguridad_usuarioswwds_16_usutiedsc3 ,
                                              AV123Seguridad_usuarioswwds_17_usunom3 ,
                                              AV125Seguridad_usuarioswwds_19_tfusucod_sel ,
                                              AV124Seguridad_usuarioswwds_18_tfusucod ,
                                              AV127Seguridad_usuarioswwds_21_tfusunom_sel ,
                                              AV126Seguridad_usuarioswwds_20_tfusunom ,
                                              AV129Seguridad_usuarioswwds_23_tfusuemail_sel ,
                                              AV128Seguridad_usuarioswwds_22_tfusuemail ,
                                              AV130Seguridad_usuarioswwds_24_tfususts_sels.Count ,
                                              AV132Seguridad_usuarioswwds_26_tfusuvenddsc_sel ,
                                              AV131Seguridad_usuarioswwds_25_tfusuvenddsc ,
                                              AV134Seguridad_usuarioswwds_28_tfusutiedsc_sel ,
                                              AV133Seguridad_usuarioswwds_27_tfusutiedsc ,
                                              A2097UsuVendDsc ,
                                              A2096UsuTieDsc ,
                                              A2019UsuNom ,
                                              A348UsuCod ,
                                              A2014UsuEMAIL ,
                                              AV13OrderedBy ,
                                              AV14OrderedDsc } ,
                                              new int[]{
                                              TypeConstants.SHORT, TypeConstants.SHORT, TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.INT, TypeConstants.SHORT, TypeConstants.BOOLEAN
                                              }
         });
         lV109Seguridad_usuarioswwds_3_usuvenddsc1 = StringUtil.PadR( StringUtil.RTrim( AV109Seguridad_usuarioswwds_3_usuvenddsc1), 100, "%");
         lV109Seguridad_usuarioswwds_3_usuvenddsc1 = StringUtil.PadR( StringUtil.RTrim( AV109Seguridad_usuarioswwds_3_usuvenddsc1), 100, "%");
         lV110Seguridad_usuarioswwds_4_usutiedsc1 = StringUtil.PadR( StringUtil.RTrim( AV110Seguridad_usuarioswwds_4_usutiedsc1), 100, "%");
         lV110Seguridad_usuarioswwds_4_usutiedsc1 = StringUtil.PadR( StringUtil.RTrim( AV110Seguridad_usuarioswwds_4_usutiedsc1), 100, "%");
         lV111Seguridad_usuarioswwds_5_usunom1 = StringUtil.PadR( StringUtil.RTrim( AV111Seguridad_usuarioswwds_5_usunom1), 100, "%");
         lV111Seguridad_usuarioswwds_5_usunom1 = StringUtil.PadR( StringUtil.RTrim( AV111Seguridad_usuarioswwds_5_usunom1), 100, "%");
         lV115Seguridad_usuarioswwds_9_usuvenddsc2 = StringUtil.PadR( StringUtil.RTrim( AV115Seguridad_usuarioswwds_9_usuvenddsc2), 100, "%");
         lV115Seguridad_usuarioswwds_9_usuvenddsc2 = StringUtil.PadR( StringUtil.RTrim( AV115Seguridad_usuarioswwds_9_usuvenddsc2), 100, "%");
         lV116Seguridad_usuarioswwds_10_usutiedsc2 = StringUtil.PadR( StringUtil.RTrim( AV116Seguridad_usuarioswwds_10_usutiedsc2), 100, "%");
         lV116Seguridad_usuarioswwds_10_usutiedsc2 = StringUtil.PadR( StringUtil.RTrim( AV116Seguridad_usuarioswwds_10_usutiedsc2), 100, "%");
         lV117Seguridad_usuarioswwds_11_usunom2 = StringUtil.PadR( StringUtil.RTrim( AV117Seguridad_usuarioswwds_11_usunom2), 100, "%");
         lV117Seguridad_usuarioswwds_11_usunom2 = StringUtil.PadR( StringUtil.RTrim( AV117Seguridad_usuarioswwds_11_usunom2), 100, "%");
         lV121Seguridad_usuarioswwds_15_usuvenddsc3 = StringUtil.PadR( StringUtil.RTrim( AV121Seguridad_usuarioswwds_15_usuvenddsc3), 100, "%");
         lV121Seguridad_usuarioswwds_15_usuvenddsc3 = StringUtil.PadR( StringUtil.RTrim( AV121Seguridad_usuarioswwds_15_usuvenddsc3), 100, "%");
         lV122Seguridad_usuarioswwds_16_usutiedsc3 = StringUtil.PadR( StringUtil.RTrim( AV122Seguridad_usuarioswwds_16_usutiedsc3), 100, "%");
         lV122Seguridad_usuarioswwds_16_usutiedsc3 = StringUtil.PadR( StringUtil.RTrim( AV122Seguridad_usuarioswwds_16_usutiedsc3), 100, "%");
         lV123Seguridad_usuarioswwds_17_usunom3 = StringUtil.PadR( StringUtil.RTrim( AV123Seguridad_usuarioswwds_17_usunom3), 100, "%");
         lV123Seguridad_usuarioswwds_17_usunom3 = StringUtil.PadR( StringUtil.RTrim( AV123Seguridad_usuarioswwds_17_usunom3), 100, "%");
         lV124Seguridad_usuarioswwds_18_tfusucod = StringUtil.PadR( StringUtil.RTrim( AV124Seguridad_usuarioswwds_18_tfusucod), 10, "%");
         lV126Seguridad_usuarioswwds_20_tfusunom = StringUtil.PadR( StringUtil.RTrim( AV126Seguridad_usuarioswwds_20_tfusunom), 100, "%");
         lV128Seguridad_usuarioswwds_22_tfusuemail = StringUtil.Concat( StringUtil.RTrim( AV128Seguridad_usuarioswwds_22_tfusuemail), "%", "");
         lV131Seguridad_usuarioswwds_25_tfusuvenddsc = StringUtil.PadR( StringUtil.RTrim( AV131Seguridad_usuarioswwds_25_tfusuvenddsc), 100, "%");
         lV133Seguridad_usuarioswwds_27_tfusutiedsc = StringUtil.PadR( StringUtil.RTrim( AV133Seguridad_usuarioswwds_27_tfusutiedsc), 100, "%");
         /* Using cursor H000H3 */
         pr_default.execute(1, new Object[] {lV109Seguridad_usuarioswwds_3_usuvenddsc1, lV109Seguridad_usuarioswwds_3_usuvenddsc1, lV110Seguridad_usuarioswwds_4_usutiedsc1, lV110Seguridad_usuarioswwds_4_usutiedsc1, lV111Seguridad_usuarioswwds_5_usunom1, lV111Seguridad_usuarioswwds_5_usunom1, lV115Seguridad_usuarioswwds_9_usuvenddsc2, lV115Seguridad_usuarioswwds_9_usuvenddsc2, lV116Seguridad_usuarioswwds_10_usutiedsc2, lV116Seguridad_usuarioswwds_10_usutiedsc2, lV117Seguridad_usuarioswwds_11_usunom2, lV117Seguridad_usuarioswwds_11_usunom2, lV121Seguridad_usuarioswwds_15_usuvenddsc3, lV121Seguridad_usuarioswwds_15_usuvenddsc3, lV122Seguridad_usuarioswwds_16_usutiedsc3, lV122Seguridad_usuarioswwds_16_usutiedsc3, lV123Seguridad_usuarioswwds_17_usunom3, lV123Seguridad_usuarioswwds_17_usunom3, lV124Seguridad_usuarioswwds_18_tfusucod, AV125Seguridad_usuarioswwds_19_tfusucod_sel, lV126Seguridad_usuarioswwds_20_tfusunom, AV127Seguridad_usuarioswwds_21_tfusunom_sel, lV128Seguridad_usuarioswwds_22_tfusuemail, AV129Seguridad_usuarioswwds_23_tfusuemail_sel, lV131Seguridad_usuarioswwds_25_tfusuvenddsc, AV132Seguridad_usuarioswwds_26_tfusuvenddsc_sel, lV133Seguridad_usuarioswwds_27_tfusutiedsc, AV134Seguridad_usuarioswwds_28_tfusutiedsc_sel});
         GRID_nRecordCount = H000H3_AGRID_nRecordCount[0];
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
         AV107Seguridad_usuarioswwds_1_dynamicfiltersselector1 = AV15DynamicFiltersSelector1;
         AV108Seguridad_usuarioswwds_2_dynamicfiltersoperator1 = AV16DynamicFiltersOperator1;
         AV109Seguridad_usuarioswwds_3_usuvenddsc1 = AV94UsuVendDsc1;
         AV110Seguridad_usuarioswwds_4_usutiedsc1 = AV95UsuTieDsc1;
         AV111Seguridad_usuarioswwds_5_usunom1 = AV89UsuNom1;
         AV112Seguridad_usuarioswwds_6_dynamicfiltersenabled2 = AV18DynamicFiltersEnabled2;
         AV113Seguridad_usuarioswwds_7_dynamicfiltersselector2 = AV19DynamicFiltersSelector2;
         AV114Seguridad_usuarioswwds_8_dynamicfiltersoperator2 = AV20DynamicFiltersOperator2;
         AV115Seguridad_usuarioswwds_9_usuvenddsc2 = AV96UsuVendDsc2;
         AV116Seguridad_usuarioswwds_10_usutiedsc2 = AV97UsuTieDsc2;
         AV117Seguridad_usuarioswwds_11_usunom2 = AV90UsuNom2;
         AV118Seguridad_usuarioswwds_12_dynamicfiltersenabled3 = AV22DynamicFiltersEnabled3;
         AV119Seguridad_usuarioswwds_13_dynamicfiltersselector3 = AV23DynamicFiltersSelector3;
         AV120Seguridad_usuarioswwds_14_dynamicfiltersoperator3 = AV24DynamicFiltersOperator3;
         AV121Seguridad_usuarioswwds_15_usuvenddsc3 = AV98UsuVendDsc3;
         AV122Seguridad_usuarioswwds_16_usutiedsc3 = AV99UsuTieDsc3;
         AV123Seguridad_usuarioswwds_17_usunom3 = AV91UsuNom3;
         AV124Seguridad_usuarioswwds_18_tfusucod = AV31TFUsuCod;
         AV125Seguridad_usuarioswwds_19_tfusucod_sel = AV32TFUsuCod_Sel;
         AV126Seguridad_usuarioswwds_20_tfusunom = AV35TFUsuNom;
         AV127Seguridad_usuarioswwds_21_tfusunom_sel = AV36TFUsuNom_Sel;
         AV128Seguridad_usuarioswwds_22_tfusuemail = AV67TFUsuEMAIL;
         AV129Seguridad_usuarioswwds_23_tfusuemail_sel = AV68TFUsuEMAIL_Sel;
         AV130Seguridad_usuarioswwds_24_tfususts_sels = AV93TFUsuSts_Sels;
         AV131Seguridad_usuarioswwds_25_tfusuvenddsc = AV100TFUsuVendDsc;
         AV132Seguridad_usuarioswwds_26_tfusuvenddsc_sel = AV101TFUsuVendDsc_Sel;
         AV133Seguridad_usuarioswwds_27_tfusutiedsc = AV102TFUsuTieDsc;
         AV134Seguridad_usuarioswwds_28_tfusutiedsc_sel = AV103TFUsuTieDsc_Sel;
         GRID_nFirstRecordOnPage = 0;
         GxWebStd.gx_hidden_field( context, "GRID_nFirstRecordOnPage", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRID_nFirstRecordOnPage), 15, 0, ".", "")));
         if ( isFullAjaxMode( ) )
         {
            gxgrGrid_refresh( subGrid_Rows, AV15DynamicFiltersSelector1, AV16DynamicFiltersOperator1, AV94UsuVendDsc1, AV95UsuTieDsc1, AV89UsuNom1, AV19DynamicFiltersSelector2, AV20DynamicFiltersOperator2, AV96UsuVendDsc2, AV97UsuTieDsc2, AV90UsuNom2, AV23DynamicFiltersSelector3, AV24DynamicFiltersOperator3, AV98UsuVendDsc3, AV99UsuTieDsc3, AV91UsuNom3, AV18DynamicFiltersEnabled2, AV22DynamicFiltersEnabled3, AV106Pgmname, AV31TFUsuCod, AV32TFUsuCod_Sel, AV35TFUsuNom, AV36TFUsuNom_Sel, AV67TFUsuEMAIL, AV68TFUsuEMAIL_Sel, AV93TFUsuSts_Sels, AV100TFUsuVendDsc, AV101TFUsuVendDsc_Sel, AV102TFUsuTieDsc, AV103TFUsuTieDsc_Sel, AV13OrderedBy, AV14OrderedDsc, AV10GridState, AV27DynamicFiltersIgnoreFirst, AV26DynamicFiltersRemoving) ;
         }
         send_integrity_footer_hashes( ) ;
         return 0 ;
      }

      protected short subgrid_nextpage( )
      {
         AV107Seguridad_usuarioswwds_1_dynamicfiltersselector1 = AV15DynamicFiltersSelector1;
         AV108Seguridad_usuarioswwds_2_dynamicfiltersoperator1 = AV16DynamicFiltersOperator1;
         AV109Seguridad_usuarioswwds_3_usuvenddsc1 = AV94UsuVendDsc1;
         AV110Seguridad_usuarioswwds_4_usutiedsc1 = AV95UsuTieDsc1;
         AV111Seguridad_usuarioswwds_5_usunom1 = AV89UsuNom1;
         AV112Seguridad_usuarioswwds_6_dynamicfiltersenabled2 = AV18DynamicFiltersEnabled2;
         AV113Seguridad_usuarioswwds_7_dynamicfiltersselector2 = AV19DynamicFiltersSelector2;
         AV114Seguridad_usuarioswwds_8_dynamicfiltersoperator2 = AV20DynamicFiltersOperator2;
         AV115Seguridad_usuarioswwds_9_usuvenddsc2 = AV96UsuVendDsc2;
         AV116Seguridad_usuarioswwds_10_usutiedsc2 = AV97UsuTieDsc2;
         AV117Seguridad_usuarioswwds_11_usunom2 = AV90UsuNom2;
         AV118Seguridad_usuarioswwds_12_dynamicfiltersenabled3 = AV22DynamicFiltersEnabled3;
         AV119Seguridad_usuarioswwds_13_dynamicfiltersselector3 = AV23DynamicFiltersSelector3;
         AV120Seguridad_usuarioswwds_14_dynamicfiltersoperator3 = AV24DynamicFiltersOperator3;
         AV121Seguridad_usuarioswwds_15_usuvenddsc3 = AV98UsuVendDsc3;
         AV122Seguridad_usuarioswwds_16_usutiedsc3 = AV99UsuTieDsc3;
         AV123Seguridad_usuarioswwds_17_usunom3 = AV91UsuNom3;
         AV124Seguridad_usuarioswwds_18_tfusucod = AV31TFUsuCod;
         AV125Seguridad_usuarioswwds_19_tfusucod_sel = AV32TFUsuCod_Sel;
         AV126Seguridad_usuarioswwds_20_tfusunom = AV35TFUsuNom;
         AV127Seguridad_usuarioswwds_21_tfusunom_sel = AV36TFUsuNom_Sel;
         AV128Seguridad_usuarioswwds_22_tfusuemail = AV67TFUsuEMAIL;
         AV129Seguridad_usuarioswwds_23_tfusuemail_sel = AV68TFUsuEMAIL_Sel;
         AV130Seguridad_usuarioswwds_24_tfususts_sels = AV93TFUsuSts_Sels;
         AV131Seguridad_usuarioswwds_25_tfusuvenddsc = AV100TFUsuVendDsc;
         AV132Seguridad_usuarioswwds_26_tfusuvenddsc_sel = AV101TFUsuVendDsc_Sel;
         AV133Seguridad_usuarioswwds_27_tfusutiedsc = AV102TFUsuTieDsc;
         AV134Seguridad_usuarioswwds_28_tfusutiedsc_sel = AV103TFUsuTieDsc_Sel;
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
            gxgrGrid_refresh( subGrid_Rows, AV15DynamicFiltersSelector1, AV16DynamicFiltersOperator1, AV94UsuVendDsc1, AV95UsuTieDsc1, AV89UsuNom1, AV19DynamicFiltersSelector2, AV20DynamicFiltersOperator2, AV96UsuVendDsc2, AV97UsuTieDsc2, AV90UsuNom2, AV23DynamicFiltersSelector3, AV24DynamicFiltersOperator3, AV98UsuVendDsc3, AV99UsuTieDsc3, AV91UsuNom3, AV18DynamicFiltersEnabled2, AV22DynamicFiltersEnabled3, AV106Pgmname, AV31TFUsuCod, AV32TFUsuCod_Sel, AV35TFUsuNom, AV36TFUsuNom_Sel, AV67TFUsuEMAIL, AV68TFUsuEMAIL_Sel, AV93TFUsuSts_Sels, AV100TFUsuVendDsc, AV101TFUsuVendDsc_Sel, AV102TFUsuTieDsc, AV103TFUsuTieDsc_Sel, AV13OrderedBy, AV14OrderedDsc, AV10GridState, AV27DynamicFiltersIgnoreFirst, AV26DynamicFiltersRemoving) ;
         }
         send_integrity_footer_hashes( ) ;
         return (short)(((GRID_nEOF==0) ? 0 : 2)) ;
      }

      protected short subgrid_previouspage( )
      {
         AV107Seguridad_usuarioswwds_1_dynamicfiltersselector1 = AV15DynamicFiltersSelector1;
         AV108Seguridad_usuarioswwds_2_dynamicfiltersoperator1 = AV16DynamicFiltersOperator1;
         AV109Seguridad_usuarioswwds_3_usuvenddsc1 = AV94UsuVendDsc1;
         AV110Seguridad_usuarioswwds_4_usutiedsc1 = AV95UsuTieDsc1;
         AV111Seguridad_usuarioswwds_5_usunom1 = AV89UsuNom1;
         AV112Seguridad_usuarioswwds_6_dynamicfiltersenabled2 = AV18DynamicFiltersEnabled2;
         AV113Seguridad_usuarioswwds_7_dynamicfiltersselector2 = AV19DynamicFiltersSelector2;
         AV114Seguridad_usuarioswwds_8_dynamicfiltersoperator2 = AV20DynamicFiltersOperator2;
         AV115Seguridad_usuarioswwds_9_usuvenddsc2 = AV96UsuVendDsc2;
         AV116Seguridad_usuarioswwds_10_usutiedsc2 = AV97UsuTieDsc2;
         AV117Seguridad_usuarioswwds_11_usunom2 = AV90UsuNom2;
         AV118Seguridad_usuarioswwds_12_dynamicfiltersenabled3 = AV22DynamicFiltersEnabled3;
         AV119Seguridad_usuarioswwds_13_dynamicfiltersselector3 = AV23DynamicFiltersSelector3;
         AV120Seguridad_usuarioswwds_14_dynamicfiltersoperator3 = AV24DynamicFiltersOperator3;
         AV121Seguridad_usuarioswwds_15_usuvenddsc3 = AV98UsuVendDsc3;
         AV122Seguridad_usuarioswwds_16_usutiedsc3 = AV99UsuTieDsc3;
         AV123Seguridad_usuarioswwds_17_usunom3 = AV91UsuNom3;
         AV124Seguridad_usuarioswwds_18_tfusucod = AV31TFUsuCod;
         AV125Seguridad_usuarioswwds_19_tfusucod_sel = AV32TFUsuCod_Sel;
         AV126Seguridad_usuarioswwds_20_tfusunom = AV35TFUsuNom;
         AV127Seguridad_usuarioswwds_21_tfusunom_sel = AV36TFUsuNom_Sel;
         AV128Seguridad_usuarioswwds_22_tfusuemail = AV67TFUsuEMAIL;
         AV129Seguridad_usuarioswwds_23_tfusuemail_sel = AV68TFUsuEMAIL_Sel;
         AV130Seguridad_usuarioswwds_24_tfususts_sels = AV93TFUsuSts_Sels;
         AV131Seguridad_usuarioswwds_25_tfusuvenddsc = AV100TFUsuVendDsc;
         AV132Seguridad_usuarioswwds_26_tfusuvenddsc_sel = AV101TFUsuVendDsc_Sel;
         AV133Seguridad_usuarioswwds_27_tfusutiedsc = AV102TFUsuTieDsc;
         AV134Seguridad_usuarioswwds_28_tfusutiedsc_sel = AV103TFUsuTieDsc_Sel;
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
            gxgrGrid_refresh( subGrid_Rows, AV15DynamicFiltersSelector1, AV16DynamicFiltersOperator1, AV94UsuVendDsc1, AV95UsuTieDsc1, AV89UsuNom1, AV19DynamicFiltersSelector2, AV20DynamicFiltersOperator2, AV96UsuVendDsc2, AV97UsuTieDsc2, AV90UsuNom2, AV23DynamicFiltersSelector3, AV24DynamicFiltersOperator3, AV98UsuVendDsc3, AV99UsuTieDsc3, AV91UsuNom3, AV18DynamicFiltersEnabled2, AV22DynamicFiltersEnabled3, AV106Pgmname, AV31TFUsuCod, AV32TFUsuCod_Sel, AV35TFUsuNom, AV36TFUsuNom_Sel, AV67TFUsuEMAIL, AV68TFUsuEMAIL_Sel, AV93TFUsuSts_Sels, AV100TFUsuVendDsc, AV101TFUsuVendDsc_Sel, AV102TFUsuTieDsc, AV103TFUsuTieDsc_Sel, AV13OrderedBy, AV14OrderedDsc, AV10GridState, AV27DynamicFiltersIgnoreFirst, AV26DynamicFiltersRemoving) ;
         }
         send_integrity_footer_hashes( ) ;
         return 0 ;
      }

      protected short subgrid_lastpage( )
      {
         AV107Seguridad_usuarioswwds_1_dynamicfiltersselector1 = AV15DynamicFiltersSelector1;
         AV108Seguridad_usuarioswwds_2_dynamicfiltersoperator1 = AV16DynamicFiltersOperator1;
         AV109Seguridad_usuarioswwds_3_usuvenddsc1 = AV94UsuVendDsc1;
         AV110Seguridad_usuarioswwds_4_usutiedsc1 = AV95UsuTieDsc1;
         AV111Seguridad_usuarioswwds_5_usunom1 = AV89UsuNom1;
         AV112Seguridad_usuarioswwds_6_dynamicfiltersenabled2 = AV18DynamicFiltersEnabled2;
         AV113Seguridad_usuarioswwds_7_dynamicfiltersselector2 = AV19DynamicFiltersSelector2;
         AV114Seguridad_usuarioswwds_8_dynamicfiltersoperator2 = AV20DynamicFiltersOperator2;
         AV115Seguridad_usuarioswwds_9_usuvenddsc2 = AV96UsuVendDsc2;
         AV116Seguridad_usuarioswwds_10_usutiedsc2 = AV97UsuTieDsc2;
         AV117Seguridad_usuarioswwds_11_usunom2 = AV90UsuNom2;
         AV118Seguridad_usuarioswwds_12_dynamicfiltersenabled3 = AV22DynamicFiltersEnabled3;
         AV119Seguridad_usuarioswwds_13_dynamicfiltersselector3 = AV23DynamicFiltersSelector3;
         AV120Seguridad_usuarioswwds_14_dynamicfiltersoperator3 = AV24DynamicFiltersOperator3;
         AV121Seguridad_usuarioswwds_15_usuvenddsc3 = AV98UsuVendDsc3;
         AV122Seguridad_usuarioswwds_16_usutiedsc3 = AV99UsuTieDsc3;
         AV123Seguridad_usuarioswwds_17_usunom3 = AV91UsuNom3;
         AV124Seguridad_usuarioswwds_18_tfusucod = AV31TFUsuCod;
         AV125Seguridad_usuarioswwds_19_tfusucod_sel = AV32TFUsuCod_Sel;
         AV126Seguridad_usuarioswwds_20_tfusunom = AV35TFUsuNom;
         AV127Seguridad_usuarioswwds_21_tfusunom_sel = AV36TFUsuNom_Sel;
         AV128Seguridad_usuarioswwds_22_tfusuemail = AV67TFUsuEMAIL;
         AV129Seguridad_usuarioswwds_23_tfusuemail_sel = AV68TFUsuEMAIL_Sel;
         AV130Seguridad_usuarioswwds_24_tfususts_sels = AV93TFUsuSts_Sels;
         AV131Seguridad_usuarioswwds_25_tfusuvenddsc = AV100TFUsuVendDsc;
         AV132Seguridad_usuarioswwds_26_tfusuvenddsc_sel = AV101TFUsuVendDsc_Sel;
         AV133Seguridad_usuarioswwds_27_tfusutiedsc = AV102TFUsuTieDsc;
         AV134Seguridad_usuarioswwds_28_tfusutiedsc_sel = AV103TFUsuTieDsc_Sel;
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
            gxgrGrid_refresh( subGrid_Rows, AV15DynamicFiltersSelector1, AV16DynamicFiltersOperator1, AV94UsuVendDsc1, AV95UsuTieDsc1, AV89UsuNom1, AV19DynamicFiltersSelector2, AV20DynamicFiltersOperator2, AV96UsuVendDsc2, AV97UsuTieDsc2, AV90UsuNom2, AV23DynamicFiltersSelector3, AV24DynamicFiltersOperator3, AV98UsuVendDsc3, AV99UsuTieDsc3, AV91UsuNom3, AV18DynamicFiltersEnabled2, AV22DynamicFiltersEnabled3, AV106Pgmname, AV31TFUsuCod, AV32TFUsuCod_Sel, AV35TFUsuNom, AV36TFUsuNom_Sel, AV67TFUsuEMAIL, AV68TFUsuEMAIL_Sel, AV93TFUsuSts_Sels, AV100TFUsuVendDsc, AV101TFUsuVendDsc_Sel, AV102TFUsuTieDsc, AV103TFUsuTieDsc_Sel, AV13OrderedBy, AV14OrderedDsc, AV10GridState, AV27DynamicFiltersIgnoreFirst, AV26DynamicFiltersRemoving) ;
         }
         send_integrity_footer_hashes( ) ;
         return 0 ;
      }

      protected int subgrid_gotopage( int nPageNo )
      {
         AV107Seguridad_usuarioswwds_1_dynamicfiltersselector1 = AV15DynamicFiltersSelector1;
         AV108Seguridad_usuarioswwds_2_dynamicfiltersoperator1 = AV16DynamicFiltersOperator1;
         AV109Seguridad_usuarioswwds_3_usuvenddsc1 = AV94UsuVendDsc1;
         AV110Seguridad_usuarioswwds_4_usutiedsc1 = AV95UsuTieDsc1;
         AV111Seguridad_usuarioswwds_5_usunom1 = AV89UsuNom1;
         AV112Seguridad_usuarioswwds_6_dynamicfiltersenabled2 = AV18DynamicFiltersEnabled2;
         AV113Seguridad_usuarioswwds_7_dynamicfiltersselector2 = AV19DynamicFiltersSelector2;
         AV114Seguridad_usuarioswwds_8_dynamicfiltersoperator2 = AV20DynamicFiltersOperator2;
         AV115Seguridad_usuarioswwds_9_usuvenddsc2 = AV96UsuVendDsc2;
         AV116Seguridad_usuarioswwds_10_usutiedsc2 = AV97UsuTieDsc2;
         AV117Seguridad_usuarioswwds_11_usunom2 = AV90UsuNom2;
         AV118Seguridad_usuarioswwds_12_dynamicfiltersenabled3 = AV22DynamicFiltersEnabled3;
         AV119Seguridad_usuarioswwds_13_dynamicfiltersselector3 = AV23DynamicFiltersSelector3;
         AV120Seguridad_usuarioswwds_14_dynamicfiltersoperator3 = AV24DynamicFiltersOperator3;
         AV121Seguridad_usuarioswwds_15_usuvenddsc3 = AV98UsuVendDsc3;
         AV122Seguridad_usuarioswwds_16_usutiedsc3 = AV99UsuTieDsc3;
         AV123Seguridad_usuarioswwds_17_usunom3 = AV91UsuNom3;
         AV124Seguridad_usuarioswwds_18_tfusucod = AV31TFUsuCod;
         AV125Seguridad_usuarioswwds_19_tfusucod_sel = AV32TFUsuCod_Sel;
         AV126Seguridad_usuarioswwds_20_tfusunom = AV35TFUsuNom;
         AV127Seguridad_usuarioswwds_21_tfusunom_sel = AV36TFUsuNom_Sel;
         AV128Seguridad_usuarioswwds_22_tfusuemail = AV67TFUsuEMAIL;
         AV129Seguridad_usuarioswwds_23_tfusuemail_sel = AV68TFUsuEMAIL_Sel;
         AV130Seguridad_usuarioswwds_24_tfususts_sels = AV93TFUsuSts_Sels;
         AV131Seguridad_usuarioswwds_25_tfusuvenddsc = AV100TFUsuVendDsc;
         AV132Seguridad_usuarioswwds_26_tfusuvenddsc_sel = AV101TFUsuVendDsc_Sel;
         AV133Seguridad_usuarioswwds_27_tfusutiedsc = AV102TFUsuTieDsc;
         AV134Seguridad_usuarioswwds_28_tfusutiedsc_sel = AV103TFUsuTieDsc_Sel;
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
            gxgrGrid_refresh( subGrid_Rows, AV15DynamicFiltersSelector1, AV16DynamicFiltersOperator1, AV94UsuVendDsc1, AV95UsuTieDsc1, AV89UsuNom1, AV19DynamicFiltersSelector2, AV20DynamicFiltersOperator2, AV96UsuVendDsc2, AV97UsuTieDsc2, AV90UsuNom2, AV23DynamicFiltersSelector3, AV24DynamicFiltersOperator3, AV98UsuVendDsc3, AV99UsuTieDsc3, AV91UsuNom3, AV18DynamicFiltersEnabled2, AV22DynamicFiltersEnabled3, AV106Pgmname, AV31TFUsuCod, AV32TFUsuCod_Sel, AV35TFUsuNom, AV36TFUsuNom_Sel, AV67TFUsuEMAIL, AV68TFUsuEMAIL_Sel, AV93TFUsuSts_Sels, AV100TFUsuVendDsc, AV101TFUsuVendDsc_Sel, AV102TFUsuTieDsc, AV103TFUsuTieDsc_Sel, AV13OrderedBy, AV14OrderedDsc, AV10GridState, AV27DynamicFiltersIgnoreFirst, AV26DynamicFiltersRemoving) ;
         }
         send_integrity_footer_hashes( ) ;
         return (int)(0) ;
      }

      protected void before_start_formulas( )
      {
         AV106Pgmname = "Seguridad.UsuariosWW";
         context.Gx_err = 0;
         fix_multi_value_controls( ) ;
      }

      protected void STRUP0H0( )
      {
         /* Before Start, stand alone formulas. */
         before_start_formulas( ) ;
         /* Execute Start event if defined. */
         context.wbGlbDoneStart = 0;
         /* Execute user event: Start */
         E240H2 ();
         context.wbGlbDoneStart = 1;
         /* After Start, stand alone formulas. */
         if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
         {
            /* Read saved SDTs. */
            ajax_req_read_hidden_sdt(cgiGet( "vAGEXPORTDATA"), AV87AGExportData);
            ajax_req_read_hidden_sdt(cgiGet( "vDDO_TITLESETTINGSICONS"), AV81DDO_TitleSettingsIcons);
            /* Read saved values. */
            nRC_GXsfl_119 = (int)(context.localUtil.CToN( cgiGet( "nRC_GXsfl_119"), ".", ","));
            AV83GridCurrentPage = (long)(context.localUtil.CToN( cgiGet( "vGRIDCURRENTPAGE"), ".", ","));
            AV84GridPageCount = (long)(context.localUtil.CToN( cgiGet( "vGRIDPAGECOUNT"), ".", ","));
            AV85GridAppliedFilters = cgiGet( "vGRIDAPPLIEDFILTERS");
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
            AV94UsuVendDsc1 = cgiGet( edtavUsuvenddsc1_Internalname);
            AssignAttri("", false, "AV94UsuVendDsc1", AV94UsuVendDsc1);
            AV95UsuTieDsc1 = cgiGet( edtavUsutiedsc1_Internalname);
            AssignAttri("", false, "AV95UsuTieDsc1", AV95UsuTieDsc1);
            AV89UsuNom1 = cgiGet( edtavUsunom1_Internalname);
            AssignAttri("", false, "AV89UsuNom1", AV89UsuNom1);
            cmbavDynamicfiltersselector2.Name = cmbavDynamicfiltersselector2_Internalname;
            cmbavDynamicfiltersselector2.CurrentValue = cgiGet( cmbavDynamicfiltersselector2_Internalname);
            AV19DynamicFiltersSelector2 = cgiGet( cmbavDynamicfiltersselector2_Internalname);
            AssignAttri("", false, "AV19DynamicFiltersSelector2", AV19DynamicFiltersSelector2);
            cmbavDynamicfiltersoperator2.Name = cmbavDynamicfiltersoperator2_Internalname;
            cmbavDynamicfiltersoperator2.CurrentValue = cgiGet( cmbavDynamicfiltersoperator2_Internalname);
            AV20DynamicFiltersOperator2 = (short)(NumberUtil.Val( cgiGet( cmbavDynamicfiltersoperator2_Internalname), "."));
            AssignAttri("", false, "AV20DynamicFiltersOperator2", StringUtil.LTrimStr( (decimal)(AV20DynamicFiltersOperator2), 4, 0));
            AV96UsuVendDsc2 = cgiGet( edtavUsuvenddsc2_Internalname);
            AssignAttri("", false, "AV96UsuVendDsc2", AV96UsuVendDsc2);
            AV97UsuTieDsc2 = cgiGet( edtavUsutiedsc2_Internalname);
            AssignAttri("", false, "AV97UsuTieDsc2", AV97UsuTieDsc2);
            AV90UsuNom2 = cgiGet( edtavUsunom2_Internalname);
            AssignAttri("", false, "AV90UsuNom2", AV90UsuNom2);
            cmbavDynamicfiltersselector3.Name = cmbavDynamicfiltersselector3_Internalname;
            cmbavDynamicfiltersselector3.CurrentValue = cgiGet( cmbavDynamicfiltersselector3_Internalname);
            AV23DynamicFiltersSelector3 = cgiGet( cmbavDynamicfiltersselector3_Internalname);
            AssignAttri("", false, "AV23DynamicFiltersSelector3", AV23DynamicFiltersSelector3);
            cmbavDynamicfiltersoperator3.Name = cmbavDynamicfiltersoperator3_Internalname;
            cmbavDynamicfiltersoperator3.CurrentValue = cgiGet( cmbavDynamicfiltersoperator3_Internalname);
            AV24DynamicFiltersOperator3 = (short)(NumberUtil.Val( cgiGet( cmbavDynamicfiltersoperator3_Internalname), "."));
            AssignAttri("", false, "AV24DynamicFiltersOperator3", StringUtil.LTrimStr( (decimal)(AV24DynamicFiltersOperator3), 4, 0));
            AV98UsuVendDsc3 = cgiGet( edtavUsuvenddsc3_Internalname);
            AssignAttri("", false, "AV98UsuVendDsc3", AV98UsuVendDsc3);
            AV99UsuTieDsc3 = cgiGet( edtavUsutiedsc3_Internalname);
            AssignAttri("", false, "AV99UsuTieDsc3", AV99UsuTieDsc3);
            AV91UsuNom3 = cgiGet( edtavUsunom3_Internalname);
            AssignAttri("", false, "AV91UsuNom3", AV91UsuNom3);
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
            if ( StringUtil.StrCmp(cgiGet( "GXH_vUSUVENDDSC1"), AV94UsuVendDsc1) != 0 )
            {
               GRID_nFirstRecordOnPage = 0;
            }
            if ( StringUtil.StrCmp(cgiGet( "GXH_vUSUTIEDSC1"), AV95UsuTieDsc1) != 0 )
            {
               GRID_nFirstRecordOnPage = 0;
            }
            if ( StringUtil.StrCmp(cgiGet( "GXH_vUSUNOM1"), AV89UsuNom1) != 0 )
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
            if ( StringUtil.StrCmp(cgiGet( "GXH_vUSUVENDDSC2"), AV96UsuVendDsc2) != 0 )
            {
               GRID_nFirstRecordOnPage = 0;
            }
            if ( StringUtil.StrCmp(cgiGet( "GXH_vUSUTIEDSC2"), AV97UsuTieDsc2) != 0 )
            {
               GRID_nFirstRecordOnPage = 0;
            }
            if ( StringUtil.StrCmp(cgiGet( "GXH_vUSUNOM2"), AV90UsuNom2) != 0 )
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
            if ( StringUtil.StrCmp(cgiGet( "GXH_vUSUVENDDSC3"), AV98UsuVendDsc3) != 0 )
            {
               GRID_nFirstRecordOnPage = 0;
            }
            if ( StringUtil.StrCmp(cgiGet( "GXH_vUSUTIEDSC3"), AV99UsuTieDsc3) != 0 )
            {
               GRID_nFirstRecordOnPage = 0;
            }
            if ( StringUtil.StrCmp(cgiGet( "GXH_vUSUNOM3"), AV91UsuNom3) != 0 )
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
         E240H2 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
      }

      protected void E240H2( )
      {
         /* Start Routine */
         returnInSub = false;
         subGrid_Rows = 10;
         GxWebStd.gx_hidden_field( context, "GRID_Rows", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid_Rows), 6, 0, ".", "")));
         Grid_empowerer_Gridinternalname = subGrid_Internalname;
         ucGrid_empowerer.SendProperty(context, "", false, Grid_empowerer_Internalname, "GridInternalName", Grid_empowerer_Gridinternalname);
         lblJsdynamicfilters_Caption = "";
         AssignProp("", false, lblJsdynamicfilters_Internalname, "Caption", lblJsdynamicfilters_Caption, true);
         AV15DynamicFiltersSelector1 = "USUVENDDSC";
         AssignAttri("", false, "AV15DynamicFiltersSelector1", AV15DynamicFiltersSelector1);
         /* Execute user subroutine: 'ENABLEDYNAMICFILTERS1' */
         S112 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
         AV19DynamicFiltersSelector2 = "USUVENDDSC";
         AssignAttri("", false, "AV19DynamicFiltersSelector2", AV19DynamicFiltersSelector2);
         /* Execute user subroutine: 'ENABLEDYNAMICFILTERS2' */
         S122 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
         AV23DynamicFiltersSelector3 = "USUVENDDSC";
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
         AV87AGExportData = new GXBaseCollection<GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTDropDownOptionsData_Item>( context, "Item", "");
         AV88AGExportDataItem = new GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTDropDownOptionsData_Item(context);
         AV88AGExportDataItem.gxTpr_Title = "PDF";
         AV88AGExportDataItem.gxTpr_Icon = context.convertURL( (string)(context.GetImagePath( "776fb79c-a0a1-4302-b5e5-d773dbe1a297", "", context.GetTheme( ))));
         AV88AGExportDataItem.gxTpr_Eventkey = "ExportReport";
         AV88AGExportDataItem.gxTpr_Isdivider = false;
         AV87AGExportData.Add(AV88AGExportDataItem, 0);
         AV88AGExportDataItem = new GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTDropDownOptionsData_Item(context);
         AV88AGExportDataItem.gxTpr_Title = "Excel";
         AV88AGExportDataItem.gxTpr_Icon = context.convertURL( (string)(context.GetImagePath( "da69a816-fd11-445b-8aaf-1a2f7f1acc93", "", context.GetTheme( ))));
         AV88AGExportDataItem.gxTpr_Eventkey = "Export";
         AV88AGExportDataItem.gxTpr_Isdivider = false;
         AV87AGExportData.Add(AV88AGExportDataItem, 0);
         Ddo_grid_Gridinternalname = subGrid_Internalname;
         ucDdo_grid.SendProperty(context, "", false, Ddo_grid_Internalname, "GridInternalName", Ddo_grid_Gridinternalname);
         Form.Caption = " Usuarios";
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
         GXt_SdtDVB_SDTDropDownOptionsTitleSettingsIcons1 = AV81DDO_TitleSettingsIcons;
         new GeneXus.Programs.wwpbaseobjects.getwwptitlesettingsicons(context ).execute( out  GXt_SdtDVB_SDTDropDownOptionsTitleSettingsIcons1) ;
         AV81DDO_TitleSettingsIcons = GXt_SdtDVB_SDTDropDownOptionsTitleSettingsIcons1;
         Gridpaginationbar_Rowsperpageselectedvalue = subGrid_Rows;
         ucGridpaginationbar.SendProperty(context, "", false, Gridpaginationbar_Internalname, "RowsPerPageSelectedValue", StringUtil.LTrimStr( (decimal)(Gridpaginationbar_Rowsperpageselectedvalue), 9, 0));
      }

      protected void E250H2( )
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
         if ( StringUtil.StrCmp(AV15DynamicFiltersSelector1, "USUVENDDSC") == 0 )
         {
            cmbavDynamicfiltersoperator1.addItem("0", "Comienza con", 0);
            cmbavDynamicfiltersoperator1.addItem("1", "Contiene", 0);
         }
         else if ( StringUtil.StrCmp(AV15DynamicFiltersSelector1, "USUTIEDSC") == 0 )
         {
            cmbavDynamicfiltersoperator1.addItem("0", "Comienza con", 0);
            cmbavDynamicfiltersoperator1.addItem("1", "Contiene", 0);
         }
         else if ( StringUtil.StrCmp(AV15DynamicFiltersSelector1, "USUNOM") == 0 )
         {
            cmbavDynamicfiltersoperator1.addItem("0", "Comienza con", 0);
            cmbavDynamicfiltersoperator1.addItem("1", "Contiene", 0);
         }
         if ( AV18DynamicFiltersEnabled2 )
         {
            cmbavDynamicfiltersoperator2.removeAllItems();
            if ( StringUtil.StrCmp(AV19DynamicFiltersSelector2, "USUVENDDSC") == 0 )
            {
               cmbavDynamicfiltersoperator2.addItem("0", "Comienza con", 0);
               cmbavDynamicfiltersoperator2.addItem("1", "Contiene", 0);
            }
            else if ( StringUtil.StrCmp(AV19DynamicFiltersSelector2, "USUTIEDSC") == 0 )
            {
               cmbavDynamicfiltersoperator2.addItem("0", "Comienza con", 0);
               cmbavDynamicfiltersoperator2.addItem("1", "Contiene", 0);
            }
            else if ( StringUtil.StrCmp(AV19DynamicFiltersSelector2, "USUNOM") == 0 )
            {
               cmbavDynamicfiltersoperator2.addItem("0", "Comienza con", 0);
               cmbavDynamicfiltersoperator2.addItem("1", "Contiene", 0);
            }
            if ( AV22DynamicFiltersEnabled3 )
            {
               cmbavDynamicfiltersoperator3.removeAllItems();
               if ( StringUtil.StrCmp(AV23DynamicFiltersSelector3, "USUVENDDSC") == 0 )
               {
                  cmbavDynamicfiltersoperator3.addItem("0", "Comienza con", 0);
                  cmbavDynamicfiltersoperator3.addItem("1", "Contiene", 0);
               }
               else if ( StringUtil.StrCmp(AV23DynamicFiltersSelector3, "USUTIEDSC") == 0 )
               {
                  cmbavDynamicfiltersoperator3.addItem("0", "Comienza con", 0);
                  cmbavDynamicfiltersoperator3.addItem("1", "Contiene", 0);
               }
               else if ( StringUtil.StrCmp(AV23DynamicFiltersSelector3, "USUNOM") == 0 )
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
         AV83GridCurrentPage = subGrid_fnc_Currentpage( );
         AssignAttri("", false, "AV83GridCurrentPage", StringUtil.LTrimStr( (decimal)(AV83GridCurrentPage), 10, 0));
         AV84GridPageCount = subGrid_fnc_Pagecount( );
         AssignAttri("", false, "AV84GridPageCount", StringUtil.LTrimStr( (decimal)(AV84GridPageCount), 10, 0));
         GXt_char2 = AV85GridAppliedFilters;
         new GeneXus.Programs.wwpbaseobjects.wwp_getappliedfiltersdescription(context ).execute(  AV106Pgmname, out  GXt_char2) ;
         AV85GridAppliedFilters = GXt_char2;
         AssignAttri("", false, "AV85GridAppliedFilters", AV85GridAppliedFilters);
         edtUsuCod_Columnheaderclass = "WWColumn";
         AssignProp("", false, edtUsuCod_Internalname, "Columnheaderclass", edtUsuCod_Columnheaderclass, !bGXsfl_119_Refreshing);
         edtUsuNom_Columnheaderclass = "WWColumn hidden-xs";
         AssignProp("", false, edtUsuNom_Internalname, "Columnheaderclass", edtUsuNom_Columnheaderclass, !bGXsfl_119_Refreshing);
         edtUsuEMAIL_Columnheaderclass = "WWColumn hidden-xs";
         AssignProp("", false, edtUsuEMAIL_Internalname, "Columnheaderclass", edtUsuEMAIL_Columnheaderclass, !bGXsfl_119_Refreshing);
         cmbUsuSts_Columnheaderclass = "WWColumn hidden-xs";
         AssignProp("", false, cmbUsuSts_Internalname, "Columnheaderclass", cmbUsuSts_Columnheaderclass, !bGXsfl_119_Refreshing);
         AV107Seguridad_usuarioswwds_1_dynamicfiltersselector1 = AV15DynamicFiltersSelector1;
         AV108Seguridad_usuarioswwds_2_dynamicfiltersoperator1 = AV16DynamicFiltersOperator1;
         AV109Seguridad_usuarioswwds_3_usuvenddsc1 = AV94UsuVendDsc1;
         AV110Seguridad_usuarioswwds_4_usutiedsc1 = AV95UsuTieDsc1;
         AV111Seguridad_usuarioswwds_5_usunom1 = AV89UsuNom1;
         AV112Seguridad_usuarioswwds_6_dynamicfiltersenabled2 = AV18DynamicFiltersEnabled2;
         AV113Seguridad_usuarioswwds_7_dynamicfiltersselector2 = AV19DynamicFiltersSelector2;
         AV114Seguridad_usuarioswwds_8_dynamicfiltersoperator2 = AV20DynamicFiltersOperator2;
         AV115Seguridad_usuarioswwds_9_usuvenddsc2 = AV96UsuVendDsc2;
         AV116Seguridad_usuarioswwds_10_usutiedsc2 = AV97UsuTieDsc2;
         AV117Seguridad_usuarioswwds_11_usunom2 = AV90UsuNom2;
         AV118Seguridad_usuarioswwds_12_dynamicfiltersenabled3 = AV22DynamicFiltersEnabled3;
         AV119Seguridad_usuarioswwds_13_dynamicfiltersselector3 = AV23DynamicFiltersSelector3;
         AV120Seguridad_usuarioswwds_14_dynamicfiltersoperator3 = AV24DynamicFiltersOperator3;
         AV121Seguridad_usuarioswwds_15_usuvenddsc3 = AV98UsuVendDsc3;
         AV122Seguridad_usuarioswwds_16_usutiedsc3 = AV99UsuTieDsc3;
         AV123Seguridad_usuarioswwds_17_usunom3 = AV91UsuNom3;
         AV124Seguridad_usuarioswwds_18_tfusucod = AV31TFUsuCod;
         AV125Seguridad_usuarioswwds_19_tfusucod_sel = AV32TFUsuCod_Sel;
         AV126Seguridad_usuarioswwds_20_tfusunom = AV35TFUsuNom;
         AV127Seguridad_usuarioswwds_21_tfusunom_sel = AV36TFUsuNom_Sel;
         AV128Seguridad_usuarioswwds_22_tfusuemail = AV67TFUsuEMAIL;
         AV129Seguridad_usuarioswwds_23_tfusuemail_sel = AV68TFUsuEMAIL_Sel;
         AV130Seguridad_usuarioswwds_24_tfususts_sels = AV93TFUsuSts_Sels;
         AV131Seguridad_usuarioswwds_25_tfusuvenddsc = AV100TFUsuVendDsc;
         AV132Seguridad_usuarioswwds_26_tfusuvenddsc_sel = AV101TFUsuVendDsc_Sel;
         AV133Seguridad_usuarioswwds_27_tfusutiedsc = AV102TFUsuTieDsc;
         AV134Seguridad_usuarioswwds_28_tfusutiedsc_sel = AV103TFUsuTieDsc_Sel;
         /*  Sending Event outputs  */
         cmbavDynamicfiltersoperator1.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV16DynamicFiltersOperator1), 4, 0));
         AssignProp("", false, cmbavDynamicfiltersoperator1_Internalname, "Values", cmbavDynamicfiltersoperator1.ToJavascriptSource(), true);
         cmbavDynamicfiltersoperator2.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV20DynamicFiltersOperator2), 4, 0));
         AssignProp("", false, cmbavDynamicfiltersoperator2_Internalname, "Values", cmbavDynamicfiltersoperator2.ToJavascriptSource(), true);
         cmbavDynamicfiltersoperator3.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV24DynamicFiltersOperator3), 4, 0));
         AssignProp("", false, cmbavDynamicfiltersoperator3_Internalname, "Values", cmbavDynamicfiltersoperator3.ToJavascriptSource(), true);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV10GridState", AV10GridState);
      }

      protected void E110H2( )
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
            AV82PageToGo = (int)(NumberUtil.Val( Gridpaginationbar_Selectedpage, "."));
            subgrid_gotopage( AV82PageToGo) ;
         }
      }

      protected void E120H2( )
      {
         /* Gridpaginationbar_Changerowsperpage Routine */
         returnInSub = false;
         subGrid_Rows = Gridpaginationbar_Rowsperpageselectedvalue;
         GxWebStd.gx_hidden_field( context, "GRID_Rows", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid_Rows), 6, 0, ".", "")));
         subgrid_firstpage( ) ;
         /*  Sending Event outputs  */
      }

      protected void E140H2( )
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
            if ( StringUtil.StrCmp(Ddo_grid_Selectedcolumn, "UsuCod") == 0 )
            {
               AV31TFUsuCod = Ddo_grid_Filteredtext_get;
               AssignAttri("", false, "AV31TFUsuCod", AV31TFUsuCod);
               AV32TFUsuCod_Sel = Ddo_grid_Selectedvalue_get;
               AssignAttri("", false, "AV32TFUsuCod_Sel", AV32TFUsuCod_Sel);
            }
            else if ( StringUtil.StrCmp(Ddo_grid_Selectedcolumn, "UsuNom") == 0 )
            {
               AV35TFUsuNom = Ddo_grid_Filteredtext_get;
               AssignAttri("", false, "AV35TFUsuNom", AV35TFUsuNom);
               AV36TFUsuNom_Sel = Ddo_grid_Selectedvalue_get;
               AssignAttri("", false, "AV36TFUsuNom_Sel", AV36TFUsuNom_Sel);
            }
            else if ( StringUtil.StrCmp(Ddo_grid_Selectedcolumn, "UsuEMAIL") == 0 )
            {
               AV67TFUsuEMAIL = Ddo_grid_Filteredtext_get;
               AssignAttri("", false, "AV67TFUsuEMAIL", AV67TFUsuEMAIL);
               AV68TFUsuEMAIL_Sel = Ddo_grid_Selectedvalue_get;
               AssignAttri("", false, "AV68TFUsuEMAIL_Sel", AV68TFUsuEMAIL_Sel);
            }
            else if ( StringUtil.StrCmp(Ddo_grid_Selectedcolumn, "UsuSts") == 0 )
            {
               AV92TFUsuSts_SelsJson = Ddo_grid_Selectedvalue_get;
               AssignAttri("", false, "AV92TFUsuSts_SelsJson", AV92TFUsuSts_SelsJson);
               AV93TFUsuSts_Sels.FromJSonString(StringUtil.StringReplace( AV92TFUsuSts_SelsJson, "\"", ""), null);
            }
            else if ( StringUtil.StrCmp(Ddo_grid_Selectedcolumn, "UsuVendDsc") == 0 )
            {
               AV100TFUsuVendDsc = Ddo_grid_Filteredtext_get;
               AssignAttri("", false, "AV100TFUsuVendDsc", AV100TFUsuVendDsc);
               AV101TFUsuVendDsc_Sel = Ddo_grid_Selectedvalue_get;
               AssignAttri("", false, "AV101TFUsuVendDsc_Sel", AV101TFUsuVendDsc_Sel);
            }
            else if ( StringUtil.StrCmp(Ddo_grid_Selectedcolumn, "UsuTieDsc") == 0 )
            {
               AV102TFUsuTieDsc = Ddo_grid_Filteredtext_get;
               AssignAttri("", false, "AV102TFUsuTieDsc", AV102TFUsuTieDsc);
               AV103TFUsuTieDsc_Sel = Ddo_grid_Selectedvalue_get;
               AssignAttri("", false, "AV103TFUsuTieDsc_Sel", AV103TFUsuTieDsc_Sel);
            }
            subgrid_firstpage( ) ;
         }
         /*  Sending Event outputs  */
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV93TFUsuSts_Sels", AV93TFUsuSts_Sels);
      }

      private void E260H2( )
      {
         /* Grid_Load Routine */
         returnInSub = false;
         cmbavGridactions.removeAllItems();
         cmbavGridactions.addItem("0", ";fa fa-bars", 0);
         cmbavGridactions.addItem("1", StringUtil.Format( "%1;%2", "Modificar", "fa fa-pen", "", "", "", "", "", "", ""), 0);
         cmbavGridactions.addItem("2", StringUtil.Format( "%1;%2", "Eliminar", "fa fa-times", "", "", "", "", "", "", ""), 0);
         GXKey = Crypto.GetSiteKey( );
         GXEncryptionTmp = "seguridad.usuariosseries.aspx"+UrlEncode(StringUtil.RTrim("DSP")) + "," + UrlEncode(StringUtil.RTrim(A348UsuCod));
         edtUsuCod_Link = formatLink("seguridad.usuariosseries.aspx") + "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey);
         GXKey = Crypto.GetSiteKey( );
         GXEncryptionTmp = "seguridad.usuariosopciones.aspx"+UrlEncode(StringUtil.RTrim("DSP")) + "," + UrlEncode(StringUtil.RTrim(A348UsuCod));
         edtUsuNom_Link = formatLink("seguridad.usuariosopciones.aspx") + "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey);
         GXKey = Crypto.GetSiteKey( );
         GXEncryptionTmp = "configuracion.vendedores.aspx"+UrlEncode(StringUtil.RTrim("DSP")) + "," + UrlEncode(StringUtil.LTrimStr(A2041UsuVend,6,0));
         edtUsuVendDsc_Link = formatLink("configuracion.vendedores.aspx") + "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey);
         GXKey = Crypto.GetSiteKey( );
         GXEncryptionTmp = "seguridad.locales.aspx"+UrlEncode(StringUtil.RTrim("DSP")) + "," + UrlEncode(StringUtil.LTrimStr(A2040UsuTieCod,6,0));
         edtUsuTieDsc_Link = formatLink("seguridad.locales.aspx") + "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey);
         edtUsuCod_Columnclass = ((A2039UsuSts==0) ? "WWColumn WWColumnDanger WWColumnDangerSingleCell" : "WWColumn");
         edtUsuNom_Columnclass = ((A2039UsuSts==0) ? "WWColumn hidden-xs WWColumnDanger WWColumnDangerSingleCell" : "WWColumn hidden-xs");
         edtUsuEMAIL_Columnclass = ((A2039UsuSts==0) ? "WWColumn hidden-xs WWColumnDanger WWColumnDangerSingleCell" : "WWColumn hidden-xs");
         cmbUsuSts_Columnclass = ((A2039UsuSts==0) ? "WWColumn hidden-xs WWColumnDanger WWColumnDangerSingleCell" : "WWColumn hidden-xs");
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
         cmbavGridactions.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV86GridActions), 4, 0));
      }

      protected void E190H2( )
      {
         /* 'AddDynamicFilters1' Routine */
         returnInSub = false;
         AV18DynamicFiltersEnabled2 = true;
         AssignAttri("", false, "AV18DynamicFiltersEnabled2", AV18DynamicFiltersEnabled2);
         imgAdddynamicfilters1_Visible = 0;
         AssignProp("", false, imgAdddynamicfilters1_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(imgAdddynamicfilters1_Visible), 5, 0), true);
         imgRemovedynamicfilters1_Visible = 1;
         AssignProp("", false, imgRemovedynamicfilters1_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(imgRemovedynamicfilters1_Visible), 5, 0), true);
         gxgrGrid_refresh( subGrid_Rows, AV15DynamicFiltersSelector1, AV16DynamicFiltersOperator1, AV94UsuVendDsc1, AV95UsuTieDsc1, AV89UsuNom1, AV19DynamicFiltersSelector2, AV20DynamicFiltersOperator2, AV96UsuVendDsc2, AV97UsuTieDsc2, AV90UsuNom2, AV23DynamicFiltersSelector3, AV24DynamicFiltersOperator3, AV98UsuVendDsc3, AV99UsuTieDsc3, AV91UsuNom3, AV18DynamicFiltersEnabled2, AV22DynamicFiltersEnabled3, AV106Pgmname, AV31TFUsuCod, AV32TFUsuCod_Sel, AV35TFUsuNom, AV36TFUsuNom_Sel, AV67TFUsuEMAIL, AV68TFUsuEMAIL_Sel, AV93TFUsuSts_Sels, AV100TFUsuVendDsc, AV101TFUsuVendDsc_Sel, AV102TFUsuTieDsc, AV103TFUsuTieDsc_Sel, AV13OrderedBy, AV14OrderedDsc, AV10GridState, AV27DynamicFiltersIgnoreFirst, AV26DynamicFiltersRemoving) ;
         /*  Sending Event outputs  */
         cmbavDynamicfiltersoperator1.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV16DynamicFiltersOperator1), 4, 0));
         AssignProp("", false, cmbavDynamicfiltersoperator1_Internalname, "Values", cmbavDynamicfiltersoperator1.ToJavascriptSource(), true);
         cmbavDynamicfiltersoperator2.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV20DynamicFiltersOperator2), 4, 0));
         AssignProp("", false, cmbavDynamicfiltersoperator2_Internalname, "Values", cmbavDynamicfiltersoperator2.ToJavascriptSource(), true);
         cmbavDynamicfiltersoperator3.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV24DynamicFiltersOperator3), 4, 0));
         AssignProp("", false, cmbavDynamicfiltersoperator3_Internalname, "Values", cmbavDynamicfiltersoperator3.ToJavascriptSource(), true);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV10GridState", AV10GridState);
      }

      protected void E150H2( )
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
         gxgrGrid_refresh( subGrid_Rows, AV15DynamicFiltersSelector1, AV16DynamicFiltersOperator1, AV94UsuVendDsc1, AV95UsuTieDsc1, AV89UsuNom1, AV19DynamicFiltersSelector2, AV20DynamicFiltersOperator2, AV96UsuVendDsc2, AV97UsuTieDsc2, AV90UsuNom2, AV23DynamicFiltersSelector3, AV24DynamicFiltersOperator3, AV98UsuVendDsc3, AV99UsuTieDsc3, AV91UsuNom3, AV18DynamicFiltersEnabled2, AV22DynamicFiltersEnabled3, AV106Pgmname, AV31TFUsuCod, AV32TFUsuCod_Sel, AV35TFUsuNom, AV36TFUsuNom_Sel, AV67TFUsuEMAIL, AV68TFUsuEMAIL_Sel, AV93TFUsuSts_Sels, AV100TFUsuVendDsc, AV101TFUsuVendDsc_Sel, AV102TFUsuTieDsc, AV103TFUsuTieDsc_Sel, AV13OrderedBy, AV14OrderedDsc, AV10GridState, AV27DynamicFiltersIgnoreFirst, AV26DynamicFiltersRemoving) ;
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

      protected void E200H2( )
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

      protected void E210H2( )
      {
         /* 'AddDynamicFilters2' Routine */
         returnInSub = false;
         AV22DynamicFiltersEnabled3 = true;
         AssignAttri("", false, "AV22DynamicFiltersEnabled3", AV22DynamicFiltersEnabled3);
         imgAdddynamicfilters2_Visible = 0;
         AssignProp("", false, imgAdddynamicfilters2_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(imgAdddynamicfilters2_Visible), 5, 0), true);
         imgRemovedynamicfilters2_Visible = 1;
         AssignProp("", false, imgRemovedynamicfilters2_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(imgRemovedynamicfilters2_Visible), 5, 0), true);
         gxgrGrid_refresh( subGrid_Rows, AV15DynamicFiltersSelector1, AV16DynamicFiltersOperator1, AV94UsuVendDsc1, AV95UsuTieDsc1, AV89UsuNom1, AV19DynamicFiltersSelector2, AV20DynamicFiltersOperator2, AV96UsuVendDsc2, AV97UsuTieDsc2, AV90UsuNom2, AV23DynamicFiltersSelector3, AV24DynamicFiltersOperator3, AV98UsuVendDsc3, AV99UsuTieDsc3, AV91UsuNom3, AV18DynamicFiltersEnabled2, AV22DynamicFiltersEnabled3, AV106Pgmname, AV31TFUsuCod, AV32TFUsuCod_Sel, AV35TFUsuNom, AV36TFUsuNom_Sel, AV67TFUsuEMAIL, AV68TFUsuEMAIL_Sel, AV93TFUsuSts_Sels, AV100TFUsuVendDsc, AV101TFUsuVendDsc_Sel, AV102TFUsuTieDsc, AV103TFUsuTieDsc_Sel, AV13OrderedBy, AV14OrderedDsc, AV10GridState, AV27DynamicFiltersIgnoreFirst, AV26DynamicFiltersRemoving) ;
         /*  Sending Event outputs  */
         cmbavDynamicfiltersoperator1.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV16DynamicFiltersOperator1), 4, 0));
         AssignProp("", false, cmbavDynamicfiltersoperator1_Internalname, "Values", cmbavDynamicfiltersoperator1.ToJavascriptSource(), true);
         cmbavDynamicfiltersoperator2.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV20DynamicFiltersOperator2), 4, 0));
         AssignProp("", false, cmbavDynamicfiltersoperator2_Internalname, "Values", cmbavDynamicfiltersoperator2.ToJavascriptSource(), true);
         cmbavDynamicfiltersoperator3.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV24DynamicFiltersOperator3), 4, 0));
         AssignProp("", false, cmbavDynamicfiltersoperator3_Internalname, "Values", cmbavDynamicfiltersoperator3.ToJavascriptSource(), true);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV10GridState", AV10GridState);
      }

      protected void E160H2( )
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
         gxgrGrid_refresh( subGrid_Rows, AV15DynamicFiltersSelector1, AV16DynamicFiltersOperator1, AV94UsuVendDsc1, AV95UsuTieDsc1, AV89UsuNom1, AV19DynamicFiltersSelector2, AV20DynamicFiltersOperator2, AV96UsuVendDsc2, AV97UsuTieDsc2, AV90UsuNom2, AV23DynamicFiltersSelector3, AV24DynamicFiltersOperator3, AV98UsuVendDsc3, AV99UsuTieDsc3, AV91UsuNom3, AV18DynamicFiltersEnabled2, AV22DynamicFiltersEnabled3, AV106Pgmname, AV31TFUsuCod, AV32TFUsuCod_Sel, AV35TFUsuNom, AV36TFUsuNom_Sel, AV67TFUsuEMAIL, AV68TFUsuEMAIL_Sel, AV93TFUsuSts_Sels, AV100TFUsuVendDsc, AV101TFUsuVendDsc_Sel, AV102TFUsuTieDsc, AV103TFUsuTieDsc_Sel, AV13OrderedBy, AV14OrderedDsc, AV10GridState, AV27DynamicFiltersIgnoreFirst, AV26DynamicFiltersRemoving) ;
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

      protected void E220H2( )
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

      protected void E170H2( )
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
         gxgrGrid_refresh( subGrid_Rows, AV15DynamicFiltersSelector1, AV16DynamicFiltersOperator1, AV94UsuVendDsc1, AV95UsuTieDsc1, AV89UsuNom1, AV19DynamicFiltersSelector2, AV20DynamicFiltersOperator2, AV96UsuVendDsc2, AV97UsuTieDsc2, AV90UsuNom2, AV23DynamicFiltersSelector3, AV24DynamicFiltersOperator3, AV98UsuVendDsc3, AV99UsuTieDsc3, AV91UsuNom3, AV18DynamicFiltersEnabled2, AV22DynamicFiltersEnabled3, AV106Pgmname, AV31TFUsuCod, AV32TFUsuCod_Sel, AV35TFUsuNom, AV36TFUsuNom_Sel, AV67TFUsuEMAIL, AV68TFUsuEMAIL_Sel, AV93TFUsuSts_Sels, AV100TFUsuVendDsc, AV101TFUsuVendDsc_Sel, AV102TFUsuTieDsc, AV103TFUsuTieDsc_Sel, AV13OrderedBy, AV14OrderedDsc, AV10GridState, AV27DynamicFiltersIgnoreFirst, AV26DynamicFiltersRemoving) ;
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

      protected void E230H2( )
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

      protected void E270H2( )
      {
         /* Gridactions_Click Routine */
         returnInSub = false;
         if ( AV86GridActions == 1 )
         {
            /* Execute user subroutine: 'DO UPDATE' */
            S212 ();
            if ( returnInSub )
            {
               returnInSub = true;
               if (true) return;
            }
         }
         else if ( AV86GridActions == 2 )
         {
            /* Execute user subroutine: 'DO DELETE' */
            S222 ();
            if ( returnInSub )
            {
               returnInSub = true;
               if (true) return;
            }
         }
         AV86GridActions = 0;
         AssignAttri("", false, cmbavGridactions_Internalname, StringUtil.LTrimStr( (decimal)(AV86GridActions), 4, 0));
         /*  Sending Event outputs  */
         cmbavGridactions.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV86GridActions), 4, 0));
         AssignProp("", false, cmbavGridactions_Internalname, "Values", cmbavGridactions.ToJavascriptSource(), true);
      }

      protected void E180H2( )
      {
         /* 'DoInsert' Routine */
         returnInSub = false;
         GXKey = Crypto.GetSiteKey( );
         GXEncryptionTmp = "seguridad.usuarios.aspx"+UrlEncode(StringUtil.RTrim("INS")) + "," + UrlEncode(StringUtil.RTrim(""));
         CallWebObject(formatLink("seguridad.usuarios.aspx") + "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey));
         context.wjLocDisableFrm = 1;
      }

      protected void E130H2( )
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
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV93TFUsuSts_Sels", AV93TFUsuSts_Sels);
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
         edtavUsuvenddsc1_Visible = 0;
         AssignProp("", false, edtavUsuvenddsc1_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavUsuvenddsc1_Visible), 5, 0), true);
         edtavUsutiedsc1_Visible = 0;
         AssignProp("", false, edtavUsutiedsc1_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavUsutiedsc1_Visible), 5, 0), true);
         edtavUsunom1_Visible = 0;
         AssignProp("", false, edtavUsunom1_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavUsunom1_Visible), 5, 0), true);
         cmbavDynamicfiltersoperator1.Visible = 0;
         AssignProp("", false, cmbavDynamicfiltersoperator1_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(cmbavDynamicfiltersoperator1.Visible), 5, 0), true);
         if ( StringUtil.StrCmp(AV15DynamicFiltersSelector1, "USUVENDDSC") == 0 )
         {
            edtavUsuvenddsc1_Visible = 1;
            AssignProp("", false, edtavUsuvenddsc1_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavUsuvenddsc1_Visible), 5, 0), true);
            cmbavDynamicfiltersoperator1.Visible = 1;
            AssignProp("", false, cmbavDynamicfiltersoperator1_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(cmbavDynamicfiltersoperator1.Visible), 5, 0), true);
         }
         else if ( StringUtil.StrCmp(AV15DynamicFiltersSelector1, "USUTIEDSC") == 0 )
         {
            edtavUsutiedsc1_Visible = 1;
            AssignProp("", false, edtavUsutiedsc1_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavUsutiedsc1_Visible), 5, 0), true);
            cmbavDynamicfiltersoperator1.Visible = 1;
            AssignProp("", false, cmbavDynamicfiltersoperator1_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(cmbavDynamicfiltersoperator1.Visible), 5, 0), true);
         }
         else if ( StringUtil.StrCmp(AV15DynamicFiltersSelector1, "USUNOM") == 0 )
         {
            edtavUsunom1_Visible = 1;
            AssignProp("", false, edtavUsunom1_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavUsunom1_Visible), 5, 0), true);
            cmbavDynamicfiltersoperator1.Visible = 1;
            AssignProp("", false, cmbavDynamicfiltersoperator1_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(cmbavDynamicfiltersoperator1.Visible), 5, 0), true);
         }
      }

      protected void S122( )
      {
         /* 'ENABLEDYNAMICFILTERS2' Routine */
         returnInSub = false;
         edtavUsuvenddsc2_Visible = 0;
         AssignProp("", false, edtavUsuvenddsc2_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavUsuvenddsc2_Visible), 5, 0), true);
         edtavUsutiedsc2_Visible = 0;
         AssignProp("", false, edtavUsutiedsc2_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavUsutiedsc2_Visible), 5, 0), true);
         edtavUsunom2_Visible = 0;
         AssignProp("", false, edtavUsunom2_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavUsunom2_Visible), 5, 0), true);
         cmbavDynamicfiltersoperator2.Visible = 0;
         AssignProp("", false, cmbavDynamicfiltersoperator2_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(cmbavDynamicfiltersoperator2.Visible), 5, 0), true);
         if ( StringUtil.StrCmp(AV19DynamicFiltersSelector2, "USUVENDDSC") == 0 )
         {
            edtavUsuvenddsc2_Visible = 1;
            AssignProp("", false, edtavUsuvenddsc2_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavUsuvenddsc2_Visible), 5, 0), true);
            cmbavDynamicfiltersoperator2.Visible = 1;
            AssignProp("", false, cmbavDynamicfiltersoperator2_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(cmbavDynamicfiltersoperator2.Visible), 5, 0), true);
         }
         else if ( StringUtil.StrCmp(AV19DynamicFiltersSelector2, "USUTIEDSC") == 0 )
         {
            edtavUsutiedsc2_Visible = 1;
            AssignProp("", false, edtavUsutiedsc2_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavUsutiedsc2_Visible), 5, 0), true);
            cmbavDynamicfiltersoperator2.Visible = 1;
            AssignProp("", false, cmbavDynamicfiltersoperator2_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(cmbavDynamicfiltersoperator2.Visible), 5, 0), true);
         }
         else if ( StringUtil.StrCmp(AV19DynamicFiltersSelector2, "USUNOM") == 0 )
         {
            edtavUsunom2_Visible = 1;
            AssignProp("", false, edtavUsunom2_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavUsunom2_Visible), 5, 0), true);
            cmbavDynamicfiltersoperator2.Visible = 1;
            AssignProp("", false, cmbavDynamicfiltersoperator2_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(cmbavDynamicfiltersoperator2.Visible), 5, 0), true);
         }
      }

      protected void S132( )
      {
         /* 'ENABLEDYNAMICFILTERS3' Routine */
         returnInSub = false;
         edtavUsuvenddsc3_Visible = 0;
         AssignProp("", false, edtavUsuvenddsc3_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavUsuvenddsc3_Visible), 5, 0), true);
         edtavUsutiedsc3_Visible = 0;
         AssignProp("", false, edtavUsutiedsc3_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavUsutiedsc3_Visible), 5, 0), true);
         edtavUsunom3_Visible = 0;
         AssignProp("", false, edtavUsunom3_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavUsunom3_Visible), 5, 0), true);
         cmbavDynamicfiltersoperator3.Visible = 0;
         AssignProp("", false, cmbavDynamicfiltersoperator3_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(cmbavDynamicfiltersoperator3.Visible), 5, 0), true);
         if ( StringUtil.StrCmp(AV23DynamicFiltersSelector3, "USUVENDDSC") == 0 )
         {
            edtavUsuvenddsc3_Visible = 1;
            AssignProp("", false, edtavUsuvenddsc3_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavUsuvenddsc3_Visible), 5, 0), true);
            cmbavDynamicfiltersoperator3.Visible = 1;
            AssignProp("", false, cmbavDynamicfiltersoperator3_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(cmbavDynamicfiltersoperator3.Visible), 5, 0), true);
         }
         else if ( StringUtil.StrCmp(AV23DynamicFiltersSelector3, "USUTIEDSC") == 0 )
         {
            edtavUsutiedsc3_Visible = 1;
            AssignProp("", false, edtavUsutiedsc3_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavUsutiedsc3_Visible), 5, 0), true);
            cmbavDynamicfiltersoperator3.Visible = 1;
            AssignProp("", false, cmbavDynamicfiltersoperator3_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(cmbavDynamicfiltersoperator3.Visible), 5, 0), true);
         }
         else if ( StringUtil.StrCmp(AV23DynamicFiltersSelector3, "USUNOM") == 0 )
         {
            edtavUsunom3_Visible = 1;
            AssignProp("", false, edtavUsunom3_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavUsunom3_Visible), 5, 0), true);
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
         AV19DynamicFiltersSelector2 = "USUVENDDSC";
         AssignAttri("", false, "AV19DynamicFiltersSelector2", AV19DynamicFiltersSelector2);
         AV20DynamicFiltersOperator2 = 0;
         AssignAttri("", false, "AV20DynamicFiltersOperator2", StringUtil.LTrimStr( (decimal)(AV20DynamicFiltersOperator2), 4, 0));
         AV96UsuVendDsc2 = "";
         AssignAttri("", false, "AV96UsuVendDsc2", AV96UsuVendDsc2);
         /* Execute user subroutine: 'ENABLEDYNAMICFILTERS2' */
         S122 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
         AV22DynamicFiltersEnabled3 = false;
         AssignAttri("", false, "AV22DynamicFiltersEnabled3", AV22DynamicFiltersEnabled3);
         AV23DynamicFiltersSelector3 = "USUVENDDSC";
         AssignAttri("", false, "AV23DynamicFiltersSelector3", AV23DynamicFiltersSelector3);
         AV24DynamicFiltersOperator3 = 0;
         AssignAttri("", false, "AV24DynamicFiltersOperator3", StringUtil.LTrimStr( (decimal)(AV24DynamicFiltersOperator3), 4, 0));
         AV98UsuVendDsc3 = "";
         AssignAttri("", false, "AV98UsuVendDsc3", AV98UsuVendDsc3);
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
         GXEncryptionTmp = "seguridad.usuarios.aspx"+UrlEncode(StringUtil.RTrim("UPD")) + "," + UrlEncode(StringUtil.RTrim(A348UsuCod));
         CallWebObject(formatLink("seguridad.usuarios.aspx") + "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey));
         context.wjLocDisableFrm = 1;
      }

      protected void S222( )
      {
         /* 'DO DELETE' Routine */
         returnInSub = false;
         GXKey = Crypto.GetSiteKey( );
         GXEncryptionTmp = "seguridad.usuarios.aspx"+UrlEncode(StringUtil.RTrim("DLT")) + "," + UrlEncode(StringUtil.RTrim(A348UsuCod));
         CallWebObject(formatLink("seguridad.usuarios.aspx") + "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey));
         context.wjLocDisableFrm = 1;
      }

      protected void S152( )
      {
         /* 'LOADGRIDSTATE' Routine */
         returnInSub = false;
         if ( StringUtil.StrCmp(AV30Session.Get(AV106Pgmname+"GridState"), "") == 0 )
         {
            AV10GridState.FromXml(new GeneXus.Programs.wwpbaseobjects.loadgridstate(context).executeUdp(  AV106Pgmname+"GridState"), null, "", "");
         }
         else
         {
            AV10GridState.FromXml(AV30Session.Get(AV106Pgmname+"GridState"), null, "", "");
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
         AV135GXV1 = 1;
         while ( AV135GXV1 <= AV10GridState.gxTpr_Filtervalues.Count )
         {
            AV11GridStateFilterValue = ((GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue)AV10GridState.gxTpr_Filtervalues.Item(AV135GXV1));
            if ( StringUtil.StrCmp(AV11GridStateFilterValue.gxTpr_Name, "TFUSUCOD") == 0 )
            {
               AV31TFUsuCod = AV11GridStateFilterValue.gxTpr_Value;
               AssignAttri("", false, "AV31TFUsuCod", AV31TFUsuCod);
            }
            else if ( StringUtil.StrCmp(AV11GridStateFilterValue.gxTpr_Name, "TFUSUCOD_SEL") == 0 )
            {
               AV32TFUsuCod_Sel = AV11GridStateFilterValue.gxTpr_Value;
               AssignAttri("", false, "AV32TFUsuCod_Sel", AV32TFUsuCod_Sel);
            }
            else if ( StringUtil.StrCmp(AV11GridStateFilterValue.gxTpr_Name, "TFUSUNOM") == 0 )
            {
               AV35TFUsuNom = AV11GridStateFilterValue.gxTpr_Value;
               AssignAttri("", false, "AV35TFUsuNom", AV35TFUsuNom);
            }
            else if ( StringUtil.StrCmp(AV11GridStateFilterValue.gxTpr_Name, "TFUSUNOM_SEL") == 0 )
            {
               AV36TFUsuNom_Sel = AV11GridStateFilterValue.gxTpr_Value;
               AssignAttri("", false, "AV36TFUsuNom_Sel", AV36TFUsuNom_Sel);
            }
            else if ( StringUtil.StrCmp(AV11GridStateFilterValue.gxTpr_Name, "TFUSUEMAIL") == 0 )
            {
               AV67TFUsuEMAIL = AV11GridStateFilterValue.gxTpr_Value;
               AssignAttri("", false, "AV67TFUsuEMAIL", AV67TFUsuEMAIL);
            }
            else if ( StringUtil.StrCmp(AV11GridStateFilterValue.gxTpr_Name, "TFUSUEMAIL_SEL") == 0 )
            {
               AV68TFUsuEMAIL_Sel = AV11GridStateFilterValue.gxTpr_Value;
               AssignAttri("", false, "AV68TFUsuEMAIL_Sel", AV68TFUsuEMAIL_Sel);
            }
            else if ( StringUtil.StrCmp(AV11GridStateFilterValue.gxTpr_Name, "TFUSUSTS_SEL") == 0 )
            {
               AV92TFUsuSts_SelsJson = AV11GridStateFilterValue.gxTpr_Value;
               AssignAttri("", false, "AV92TFUsuSts_SelsJson", AV92TFUsuSts_SelsJson);
               AV93TFUsuSts_Sels.FromJSonString(AV92TFUsuSts_SelsJson, null);
            }
            else if ( StringUtil.StrCmp(AV11GridStateFilterValue.gxTpr_Name, "TFUSUVENDDSC") == 0 )
            {
               AV100TFUsuVendDsc = AV11GridStateFilterValue.gxTpr_Value;
               AssignAttri("", false, "AV100TFUsuVendDsc", AV100TFUsuVendDsc);
            }
            else if ( StringUtil.StrCmp(AV11GridStateFilterValue.gxTpr_Name, "TFUSUVENDDSC_SEL") == 0 )
            {
               AV101TFUsuVendDsc_Sel = AV11GridStateFilterValue.gxTpr_Value;
               AssignAttri("", false, "AV101TFUsuVendDsc_Sel", AV101TFUsuVendDsc_Sel);
            }
            else if ( StringUtil.StrCmp(AV11GridStateFilterValue.gxTpr_Name, "TFUSUTIEDSC") == 0 )
            {
               AV102TFUsuTieDsc = AV11GridStateFilterValue.gxTpr_Value;
               AssignAttri("", false, "AV102TFUsuTieDsc", AV102TFUsuTieDsc);
            }
            else if ( StringUtil.StrCmp(AV11GridStateFilterValue.gxTpr_Name, "TFUSUTIEDSC_SEL") == 0 )
            {
               AV103TFUsuTieDsc_Sel = AV11GridStateFilterValue.gxTpr_Value;
               AssignAttri("", false, "AV103TFUsuTieDsc_Sel", AV103TFUsuTieDsc_Sel);
            }
            AV135GXV1 = (int)(AV135GXV1+1);
         }
         GXt_char2 = "";
         new GeneXus.Programs.wwpbaseobjects.wwp_getfilterval(context ).execute(  String.IsNullOrEmpty(StringUtil.RTrim( AV32TFUsuCod_Sel)),  AV32TFUsuCod_Sel, out  GXt_char2) ;
         GXt_char3 = "";
         new GeneXus.Programs.wwpbaseobjects.wwp_getfilterval(context ).execute(  String.IsNullOrEmpty(StringUtil.RTrim( AV36TFUsuNom_Sel)),  AV36TFUsuNom_Sel, out  GXt_char3) ;
         GXt_char4 = "";
         new GeneXus.Programs.wwpbaseobjects.wwp_getfilterval(context ).execute(  String.IsNullOrEmpty(StringUtil.RTrim( AV68TFUsuEMAIL_Sel)),  AV68TFUsuEMAIL_Sel, out  GXt_char4) ;
         GXt_char5 = "";
         new GeneXus.Programs.wwpbaseobjects.wwp_getfilterval(context ).execute(  String.IsNullOrEmpty(StringUtil.RTrim( AV101TFUsuVendDsc_Sel)),  AV101TFUsuVendDsc_Sel, out  GXt_char5) ;
         GXt_char6 = "";
         new GeneXus.Programs.wwpbaseobjects.wwp_getfilterval(context ).execute(  String.IsNullOrEmpty(StringUtil.RTrim( AV103TFUsuTieDsc_Sel)),  AV103TFUsuTieDsc_Sel, out  GXt_char6) ;
         Ddo_grid_Selectedvalue_set = GXt_char2+"|"+GXt_char3+"|"+GXt_char4+"|"+((AV93TFUsuSts_Sels.Count==0) ? "" : AV92TFUsuSts_SelsJson)+"|"+GXt_char5+"|"+GXt_char6;
         ucDdo_grid.SendProperty(context, "", false, Ddo_grid_Internalname, "SelectedValue_set", Ddo_grid_Selectedvalue_set);
         GXt_char6 = "";
         new GeneXus.Programs.wwpbaseobjects.wwp_getfilterval(context ).execute(  String.IsNullOrEmpty(StringUtil.RTrim( AV31TFUsuCod)),  AV31TFUsuCod, out  GXt_char6) ;
         GXt_char5 = "";
         new GeneXus.Programs.wwpbaseobjects.wwp_getfilterval(context ).execute(  String.IsNullOrEmpty(StringUtil.RTrim( AV35TFUsuNom)),  AV35TFUsuNom, out  GXt_char5) ;
         GXt_char4 = "";
         new GeneXus.Programs.wwpbaseobjects.wwp_getfilterval(context ).execute(  String.IsNullOrEmpty(StringUtil.RTrim( AV67TFUsuEMAIL)),  AV67TFUsuEMAIL, out  GXt_char4) ;
         GXt_char3 = "";
         new GeneXus.Programs.wwpbaseobjects.wwp_getfilterval(context ).execute(  String.IsNullOrEmpty(StringUtil.RTrim( AV100TFUsuVendDsc)),  AV100TFUsuVendDsc, out  GXt_char3) ;
         GXt_char2 = "";
         new GeneXus.Programs.wwpbaseobjects.wwp_getfilterval(context ).execute(  String.IsNullOrEmpty(StringUtil.RTrim( AV102TFUsuTieDsc)),  AV102TFUsuTieDsc, out  GXt_char2) ;
         Ddo_grid_Filteredtext_set = GXt_char6+"|"+GXt_char5+"|"+GXt_char4+"||"+GXt_char3+"|"+GXt_char2;
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
            if ( StringUtil.StrCmp(AV15DynamicFiltersSelector1, "USUVENDDSC") == 0 )
            {
               AV16DynamicFiltersOperator1 = AV12GridStateDynamicFilter.gxTpr_Operator;
               AssignAttri("", false, "AV16DynamicFiltersOperator1", StringUtil.LTrimStr( (decimal)(AV16DynamicFiltersOperator1), 4, 0));
               AV94UsuVendDsc1 = AV12GridStateDynamicFilter.gxTpr_Value;
               AssignAttri("", false, "AV94UsuVendDsc1", AV94UsuVendDsc1);
            }
            else if ( StringUtil.StrCmp(AV15DynamicFiltersSelector1, "USUTIEDSC") == 0 )
            {
               AV16DynamicFiltersOperator1 = AV12GridStateDynamicFilter.gxTpr_Operator;
               AssignAttri("", false, "AV16DynamicFiltersOperator1", StringUtil.LTrimStr( (decimal)(AV16DynamicFiltersOperator1), 4, 0));
               AV95UsuTieDsc1 = AV12GridStateDynamicFilter.gxTpr_Value;
               AssignAttri("", false, "AV95UsuTieDsc1", AV95UsuTieDsc1);
            }
            else if ( StringUtil.StrCmp(AV15DynamicFiltersSelector1, "USUNOM") == 0 )
            {
               AV16DynamicFiltersOperator1 = AV12GridStateDynamicFilter.gxTpr_Operator;
               AssignAttri("", false, "AV16DynamicFiltersOperator1", StringUtil.LTrimStr( (decimal)(AV16DynamicFiltersOperator1), 4, 0));
               AV89UsuNom1 = AV12GridStateDynamicFilter.gxTpr_Value;
               AssignAttri("", false, "AV89UsuNom1", AV89UsuNom1);
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
               if ( StringUtil.StrCmp(AV19DynamicFiltersSelector2, "USUVENDDSC") == 0 )
               {
                  AV20DynamicFiltersOperator2 = AV12GridStateDynamicFilter.gxTpr_Operator;
                  AssignAttri("", false, "AV20DynamicFiltersOperator2", StringUtil.LTrimStr( (decimal)(AV20DynamicFiltersOperator2), 4, 0));
                  AV96UsuVendDsc2 = AV12GridStateDynamicFilter.gxTpr_Value;
                  AssignAttri("", false, "AV96UsuVendDsc2", AV96UsuVendDsc2);
               }
               else if ( StringUtil.StrCmp(AV19DynamicFiltersSelector2, "USUTIEDSC") == 0 )
               {
                  AV20DynamicFiltersOperator2 = AV12GridStateDynamicFilter.gxTpr_Operator;
                  AssignAttri("", false, "AV20DynamicFiltersOperator2", StringUtil.LTrimStr( (decimal)(AV20DynamicFiltersOperator2), 4, 0));
                  AV97UsuTieDsc2 = AV12GridStateDynamicFilter.gxTpr_Value;
                  AssignAttri("", false, "AV97UsuTieDsc2", AV97UsuTieDsc2);
               }
               else if ( StringUtil.StrCmp(AV19DynamicFiltersSelector2, "USUNOM") == 0 )
               {
                  AV20DynamicFiltersOperator2 = AV12GridStateDynamicFilter.gxTpr_Operator;
                  AssignAttri("", false, "AV20DynamicFiltersOperator2", StringUtil.LTrimStr( (decimal)(AV20DynamicFiltersOperator2), 4, 0));
                  AV90UsuNom2 = AV12GridStateDynamicFilter.gxTpr_Value;
                  AssignAttri("", false, "AV90UsuNom2", AV90UsuNom2);
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
                  if ( StringUtil.StrCmp(AV23DynamicFiltersSelector3, "USUVENDDSC") == 0 )
                  {
                     AV24DynamicFiltersOperator3 = AV12GridStateDynamicFilter.gxTpr_Operator;
                     AssignAttri("", false, "AV24DynamicFiltersOperator3", StringUtil.LTrimStr( (decimal)(AV24DynamicFiltersOperator3), 4, 0));
                     AV98UsuVendDsc3 = AV12GridStateDynamicFilter.gxTpr_Value;
                     AssignAttri("", false, "AV98UsuVendDsc3", AV98UsuVendDsc3);
                  }
                  else if ( StringUtil.StrCmp(AV23DynamicFiltersSelector3, "USUTIEDSC") == 0 )
                  {
                     AV24DynamicFiltersOperator3 = AV12GridStateDynamicFilter.gxTpr_Operator;
                     AssignAttri("", false, "AV24DynamicFiltersOperator3", StringUtil.LTrimStr( (decimal)(AV24DynamicFiltersOperator3), 4, 0));
                     AV99UsuTieDsc3 = AV12GridStateDynamicFilter.gxTpr_Value;
                     AssignAttri("", false, "AV99UsuTieDsc3", AV99UsuTieDsc3);
                  }
                  else if ( StringUtil.StrCmp(AV23DynamicFiltersSelector3, "USUNOM") == 0 )
                  {
                     AV24DynamicFiltersOperator3 = AV12GridStateDynamicFilter.gxTpr_Operator;
                     AssignAttri("", false, "AV24DynamicFiltersOperator3", StringUtil.LTrimStr( (decimal)(AV24DynamicFiltersOperator3), 4, 0));
                     AV91UsuNom3 = AV12GridStateDynamicFilter.gxTpr_Value;
                     AssignAttri("", false, "AV91UsuNom3", AV91UsuNom3);
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
         AV10GridState.FromXml(AV30Session.Get(AV106Pgmname+"GridState"), null, "", "");
         AV10GridState.gxTpr_Orderedby = AV13OrderedBy;
         AV10GridState.gxTpr_Ordereddsc = AV14OrderedDsc;
         AV10GridState.gxTpr_Filtervalues.Clear();
         new GeneXus.Programs.wwpbaseobjects.wwp_gridstateaddfiltervalueandsel(context ).execute( ref  AV10GridState,  "TFUSUCOD",  "Usuario",  !String.IsNullOrEmpty(StringUtil.RTrim( AV31TFUsuCod)),  0,  AV31TFUsuCod,  "",  !String.IsNullOrEmpty(StringUtil.RTrim( AV32TFUsuCod_Sel)),  AV32TFUsuCod_Sel,  "") ;
         new GeneXus.Programs.wwpbaseobjects.wwp_gridstateaddfiltervalueandsel(context ).execute( ref  AV10GridState,  "TFUSUNOM",  "Nombre Usuario",  !String.IsNullOrEmpty(StringUtil.RTrim( AV35TFUsuNom)),  0,  AV35TFUsuNom,  "",  !String.IsNullOrEmpty(StringUtil.RTrim( AV36TFUsuNom_Sel)),  AV36TFUsuNom_Sel,  "") ;
         new GeneXus.Programs.wwpbaseobjects.wwp_gridstateaddfiltervalueandsel(context ).execute( ref  AV10GridState,  "TFUSUEMAIL",  "E-Mail",  !String.IsNullOrEmpty(StringUtil.RTrim( AV67TFUsuEMAIL)),  0,  AV67TFUsuEMAIL,  "",  !String.IsNullOrEmpty(StringUtil.RTrim( AV68TFUsuEMAIL_Sel)),  AV68TFUsuEMAIL_Sel,  "") ;
         new GeneXus.Programs.wwpbaseobjects.wwp_gridstateaddfiltervalue(context ).execute( ref  AV10GridState,  "TFUSUSTS_SEL",  "Estado",  !(AV93TFUsuSts_Sels.Count==0),  0,  AV93TFUsuSts_Sels.ToJSonString(false),  "") ;
         new GeneXus.Programs.wwpbaseobjects.wwp_gridstateaddfiltervalueandsel(context ).execute( ref  AV10GridState,  "TFUSUVENDDSC",  "Vendedor",  !String.IsNullOrEmpty(StringUtil.RTrim( AV100TFUsuVendDsc)),  0,  AV100TFUsuVendDsc,  "",  !String.IsNullOrEmpty(StringUtil.RTrim( AV101TFUsuVendDsc_Sel)),  AV101TFUsuVendDsc_Sel,  "") ;
         new GeneXus.Programs.wwpbaseobjects.wwp_gridstateaddfiltervalueandsel(context ).execute( ref  AV10GridState,  "TFUSUTIEDSC",  "Local",  !String.IsNullOrEmpty(StringUtil.RTrim( AV102TFUsuTieDsc)),  0,  AV102TFUsuTieDsc,  "",  !String.IsNullOrEmpty(StringUtil.RTrim( AV103TFUsuTieDsc_Sel)),  AV103TFUsuTieDsc_Sel,  "") ;
         /* Execute user subroutine: 'SAVEDYNFILTERSSTATE' */
         S182 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
         AV10GridState.gxTpr_Pagesize = StringUtil.Str( (decimal)(subGrid_Rows), 10, 0);
         AV10GridState.gxTpr_Currentpage = (short)(subGrid_fnc_Currentpage( ));
         new GeneXus.Programs.wwpbaseobjects.savegridstate(context ).execute(  AV106Pgmname+"GridState",  AV10GridState.ToXml(false, true, "", "")) ;
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
            if ( ( StringUtil.StrCmp(AV15DynamicFiltersSelector1, "USUVENDDSC") == 0 ) && ! String.IsNullOrEmpty(StringUtil.RTrim( AV94UsuVendDsc1)) )
            {
               AV12GridStateDynamicFilter.gxTpr_Dsc = "Vendedor";
               AV12GridStateDynamicFilter.gxTpr_Value = AV94UsuVendDsc1;
               AV12GridStateDynamicFilter.gxTpr_Operator = AV16DynamicFiltersOperator1;
            }
            else if ( ( StringUtil.StrCmp(AV15DynamicFiltersSelector1, "USUTIEDSC") == 0 ) && ! String.IsNullOrEmpty(StringUtil.RTrim( AV95UsuTieDsc1)) )
            {
               AV12GridStateDynamicFilter.gxTpr_Dsc = "Local";
               AV12GridStateDynamicFilter.gxTpr_Value = AV95UsuTieDsc1;
               AV12GridStateDynamicFilter.gxTpr_Operator = AV16DynamicFiltersOperator1;
            }
            else if ( ( StringUtil.StrCmp(AV15DynamicFiltersSelector1, "USUNOM") == 0 ) && ! String.IsNullOrEmpty(StringUtil.RTrim( AV89UsuNom1)) )
            {
               AV12GridStateDynamicFilter.gxTpr_Dsc = "Nombre de Usuario";
               AV12GridStateDynamicFilter.gxTpr_Value = AV89UsuNom1;
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
            if ( ( StringUtil.StrCmp(AV19DynamicFiltersSelector2, "USUVENDDSC") == 0 ) && ! String.IsNullOrEmpty(StringUtil.RTrim( AV96UsuVendDsc2)) )
            {
               AV12GridStateDynamicFilter.gxTpr_Dsc = "Vendedor";
               AV12GridStateDynamicFilter.gxTpr_Value = AV96UsuVendDsc2;
               AV12GridStateDynamicFilter.gxTpr_Operator = AV20DynamicFiltersOperator2;
            }
            else if ( ( StringUtil.StrCmp(AV19DynamicFiltersSelector2, "USUTIEDSC") == 0 ) && ! String.IsNullOrEmpty(StringUtil.RTrim( AV97UsuTieDsc2)) )
            {
               AV12GridStateDynamicFilter.gxTpr_Dsc = "Local";
               AV12GridStateDynamicFilter.gxTpr_Value = AV97UsuTieDsc2;
               AV12GridStateDynamicFilter.gxTpr_Operator = AV20DynamicFiltersOperator2;
            }
            else if ( ( StringUtil.StrCmp(AV19DynamicFiltersSelector2, "USUNOM") == 0 ) && ! String.IsNullOrEmpty(StringUtil.RTrim( AV90UsuNom2)) )
            {
               AV12GridStateDynamicFilter.gxTpr_Dsc = "Nombre de Usuario";
               AV12GridStateDynamicFilter.gxTpr_Value = AV90UsuNom2;
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
            if ( ( StringUtil.StrCmp(AV23DynamicFiltersSelector3, "USUVENDDSC") == 0 ) && ! String.IsNullOrEmpty(StringUtil.RTrim( AV98UsuVendDsc3)) )
            {
               AV12GridStateDynamicFilter.gxTpr_Dsc = "Vendedor";
               AV12GridStateDynamicFilter.gxTpr_Value = AV98UsuVendDsc3;
               AV12GridStateDynamicFilter.gxTpr_Operator = AV24DynamicFiltersOperator3;
            }
            else if ( ( StringUtil.StrCmp(AV23DynamicFiltersSelector3, "USUTIEDSC") == 0 ) && ! String.IsNullOrEmpty(StringUtil.RTrim( AV99UsuTieDsc3)) )
            {
               AV12GridStateDynamicFilter.gxTpr_Dsc = "Local";
               AV12GridStateDynamicFilter.gxTpr_Value = AV99UsuTieDsc3;
               AV12GridStateDynamicFilter.gxTpr_Operator = AV24DynamicFiltersOperator3;
            }
            else if ( ( StringUtil.StrCmp(AV23DynamicFiltersSelector3, "USUNOM") == 0 ) && ! String.IsNullOrEmpty(StringUtil.RTrim( AV91UsuNom3)) )
            {
               AV12GridStateDynamicFilter.gxTpr_Dsc = "Nombre de Usuario";
               AV12GridStateDynamicFilter.gxTpr_Value = AV91UsuNom3;
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
         AV8TrnContext.gxTpr_Callerobject = AV106Pgmname;
         AV8TrnContext.gxTpr_Callerondelete = true;
         AV8TrnContext.gxTpr_Callerurl = AV7HTTPRequest.ScriptName+"?"+AV7HTTPRequest.QueryString;
         AV8TrnContext.gxTpr_Transactionname = "Seguridad.Usuarios";
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
         new GeneXus.Programs.seguridad.usuarioswwexport(context ).execute( out  AV28ExcelFilename, out  AV29ErrorMessage) ;
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
         Innewwindow1_Target = formatLink("seguridad.usuarioswwexportreport.aspx") ;
         ucInnewwindow1.SendProperty(context, "", false, Innewwindow1_Internalname, "Target", Innewwindow1_Target);
         Innewwindow1_Height = "600";
         ucInnewwindow1.SendProperty(context, "", false, Innewwindow1_Internalname, "Height", Innewwindow1_Height);
         Innewwindow1_Width = "800";
         ucInnewwindow1.SendProperty(context, "", false, Innewwindow1_Internalname, "Width", Innewwindow1_Width);
         this.executeUsercontrolMethod("", false, "INNEWWINDOW1Container", "OpenWindow", "", new Object[] {});
      }

      protected void wb_table1_25_0H2( bool wbgen )
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
            GxWebStd.gx_label_ctrl( context, lblDynamicfiltersprefix1_Internalname, "Buscar en", "", "", lblDynamicfiltersprefix1_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "DataFilterDescriptionPrefix", 0, "", 1, 1, 0, 0, "HLP_Seguridad\\UsuariosWW.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "", "left", "top", "", "flex-grow:1;", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "left", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, cmbavDynamicfiltersselector1_Internalname, "Dynamic Filters Selector1", "gx-form-item AttributeLabel", 0, true, "width: 25%;");
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 35,'',false,'" + sGXsfl_119_idx + "',0)\"";
            /* ComboBox */
            GxWebStd.gx_combobox_ctrl1( context, cmbavDynamicfiltersselector1, cmbavDynamicfiltersselector1_Internalname, StringUtil.RTrim( AV15DynamicFiltersSelector1), 1, cmbavDynamicfiltersselector1_Jsonclick, 5, "'"+""+"'"+",false,"+"'"+"EVDYNAMICFILTERSSELECTOR1.CLICK."+"'", "svchar", "", 1, cmbavDynamicfiltersselector1.Enabled, 0, 0, 0, "em", 0, "", "", "Attribute", "", "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,35);\"", "", true, 1, "HLP_Seguridad\\UsuariosWW.htm");
            cmbavDynamicfiltersselector1.CurrentValue = StringUtil.RTrim( AV15DynamicFiltersSelector1);
            AssignProp("", false, cmbavDynamicfiltersselector1_Internalname, "Values", (string)(cmbavDynamicfiltersselector1.ToJavascriptSource()), true);
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "", "left", "top", "", "flex-grow:1;", "div");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblDynamicfiltersmiddle1_Internalname, "valor", "", "", lblDynamicfiltersmiddle1_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "DataFilterDescription", 0, "", 1, 1, 0, 0, "HLP_Seguridad\\UsuariosWW.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "", "left", "top", "", "flex-grow:1;", "div");
            wb_table2_39_0H2( true) ;
         }
         else
         {
            wb_table2_39_0H2( false) ;
         }
         return  ;
      }

      protected void wb_table2_39_0H2e( bool wbgen )
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
            GxWebStd.gx_label_ctrl( context, lblDynamicfiltersprefix2_Internalname, "Buscar en", "", "", lblDynamicfiltersprefix2_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "DataFilterDescriptionPrefix", 0, "", 1, 1, 0, 0, "HLP_Seguridad\\UsuariosWW.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "Invisible", "left", "top", "", "flex-grow:1;", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "left", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, cmbavDynamicfiltersselector2_Internalname, "Dynamic Filters Selector2", "gx-form-item AttributeLabel", 0, true, "width: 25%;");
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 63,'',false,'" + sGXsfl_119_idx + "',0)\"";
            /* ComboBox */
            GxWebStd.gx_combobox_ctrl1( context, cmbavDynamicfiltersselector2, cmbavDynamicfiltersselector2_Internalname, StringUtil.RTrim( AV19DynamicFiltersSelector2), 1, cmbavDynamicfiltersselector2_Jsonclick, 5, "'"+""+"'"+",false,"+"'"+"EVDYNAMICFILTERSSELECTOR2.CLICK."+"'", "svchar", "", 1, cmbavDynamicfiltersselector2.Enabled, 0, 0, 0, "em", 0, "", "", "Attribute", "", "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,63);\"", "", true, 1, "HLP_Seguridad\\UsuariosWW.htm");
            cmbavDynamicfiltersselector2.CurrentValue = StringUtil.RTrim( AV19DynamicFiltersSelector2);
            AssignProp("", false, cmbavDynamicfiltersselector2_Internalname, "Values", (string)(cmbavDynamicfiltersselector2.ToJavascriptSource()), true);
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "Invisible", "left", "top", "", "flex-grow:1;", "div");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblDynamicfiltersmiddle2_Internalname, "valor", "", "", lblDynamicfiltersmiddle2_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "DataFilterDescription", 0, "", 1, 1, 0, 0, "HLP_Seguridad\\UsuariosWW.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "Invisible", "left", "top", "", "flex-grow:1;", "div");
            wb_table3_67_0H2( true) ;
         }
         else
         {
            wb_table3_67_0H2( false) ;
         }
         return  ;
      }

      protected void wb_table3_67_0H2e( bool wbgen )
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
            GxWebStd.gx_label_ctrl( context, lblDynamicfiltersprefix3_Internalname, "Buscar en", "", "", lblDynamicfiltersprefix3_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "DataFilterDescriptionPrefix", 0, "", 1, 1, 0, 0, "HLP_Seguridad\\UsuariosWW.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "Invisible", "left", "top", "", "flex-grow:1;", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "left", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, cmbavDynamicfiltersselector3_Internalname, "Dynamic Filters Selector3", "gx-form-item AttributeLabel", 0, true, "width: 25%;");
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 91,'',false,'" + sGXsfl_119_idx + "',0)\"";
            /* ComboBox */
            GxWebStd.gx_combobox_ctrl1( context, cmbavDynamicfiltersselector3, cmbavDynamicfiltersselector3_Internalname, StringUtil.RTrim( AV23DynamicFiltersSelector3), 1, cmbavDynamicfiltersselector3_Jsonclick, 5, "'"+""+"'"+",false,"+"'"+"EVDYNAMICFILTERSSELECTOR3.CLICK."+"'", "svchar", "", 1, cmbavDynamicfiltersselector3.Enabled, 0, 0, 0, "em", 0, "", "", "Attribute", "", "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,91);\"", "", true, 1, "HLP_Seguridad\\UsuariosWW.htm");
            cmbavDynamicfiltersselector3.CurrentValue = StringUtil.RTrim( AV23DynamicFiltersSelector3);
            AssignProp("", false, cmbavDynamicfiltersselector3_Internalname, "Values", (string)(cmbavDynamicfiltersselector3.ToJavascriptSource()), true);
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "Invisible", "left", "top", "", "flex-grow:1;", "div");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblDynamicfiltersmiddle3_Internalname, "valor", "", "", lblDynamicfiltersmiddle3_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "DataFilterDescription", 0, "", 1, 1, 0, 0, "HLP_Seguridad\\UsuariosWW.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "Invisible", "left", "top", "", "flex-grow:1;", "div");
            wb_table4_95_0H2( true) ;
         }
         else
         {
            wb_table4_95_0H2( false) ;
         }
         return  ;
      }

      protected void wb_table4_95_0H2e( bool wbgen )
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
            wb_table1_25_0H2e( true) ;
         }
         else
         {
            wb_table1_25_0H2e( false) ;
         }
      }

      protected void wb_table4_95_0H2( bool wbgen )
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
            GxWebStd.gx_combobox_ctrl1( context, cmbavDynamicfiltersoperator3, cmbavDynamicfiltersoperator3_Internalname, StringUtil.Trim( StringUtil.Str( (decimal)(AV24DynamicFiltersOperator3), 4, 0)), 1, cmbavDynamicfiltersoperator3_Jsonclick, 0, "'"+""+"'"+",false,"+"'"+""+"'", "int", "", cmbavDynamicfiltersoperator3.Visible, cmbavDynamicfiltersoperator3.Enabled, 0, 0, 0, "em", 0, "", "", "Attribute", "", "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,99);\"", "", true, 1, "HLP_Seguridad\\UsuariosWW.htm");
            cmbavDynamicfiltersoperator3.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV24DynamicFiltersOperator3), 4, 0));
            AssignProp("", false, cmbavDynamicfiltersoperator3_Internalname, "Values", (string)(cmbavDynamicfiltersoperator3.ToJavascriptSource()), true);
            GxWebStd.gx_div_end( context, "left", "top", "div");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "<td id=\""+cellFilter_usuvenddsc3_cell_Internalname+"\"  class=''>") ;
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "left", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavUsuvenddsc3_Internalname, "Usu Vend Dsc3", "gx-form-item AttributeLabel", 0, true, "width: 25%;");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 102,'',false,'" + sGXsfl_119_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavUsuvenddsc3_Internalname, StringUtil.RTrim( AV98UsuVendDsc3), StringUtil.RTrim( context.localUtil.Format( AV98UsuVendDsc3, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,102);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavUsuvenddsc3_Jsonclick, 0, "Attribute", "", "", "", "", edtavUsuvenddsc3_Visible, edtavUsuvenddsc3_Enabled, 0, "text", "", 80, "chr", 1, "row", 100, 0, 0, 0, 1, -1, -1, true, "", "left", true, "", "HLP_Seguridad\\UsuariosWW.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "<td id=\""+cellFilter_usutiedsc3_cell_Internalname+"\"  class=''>") ;
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "left", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavUsutiedsc3_Internalname, "Usu Tie Dsc3", "gx-form-item AttributeLabel", 0, true, "width: 25%;");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 105,'',false,'" + sGXsfl_119_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavUsutiedsc3_Internalname, StringUtil.RTrim( AV99UsuTieDsc3), StringUtil.RTrim( context.localUtil.Format( AV99UsuTieDsc3, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,105);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavUsutiedsc3_Jsonclick, 0, "Attribute", "", "", "", "", edtavUsutiedsc3_Visible, edtavUsutiedsc3_Enabled, 0, "text", "", 80, "chr", 1, "row", 100, 0, 0, 0, 1, -1, -1, true, "", "left", true, "", "HLP_Seguridad\\UsuariosWW.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "<td id=\""+cellFilter_usunom3_cell_Internalname+"\"  class=''>") ;
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "left", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavUsunom3_Internalname, "Usu Nom3", "gx-form-item AttributeLabel", 0, true, "width: 25%;");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 108,'',false,'" + sGXsfl_119_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavUsunom3_Internalname, StringUtil.RTrim( AV91UsuNom3), StringUtil.RTrim( context.localUtil.Format( AV91UsuNom3, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,108);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavUsunom3_Jsonclick, 0, "Attribute", "", "", "", "", edtavUsunom3_Visible, edtavUsunom3_Enabled, 0, "text", "", 80, "chr", 1, "row", 100, 0, 0, 0, 1, -1, -1, true, "", "left", true, "", "HLP_Seguridad\\UsuariosWW.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "<td id=\""+cellDynamicfilters_removefilter3_cell_Internalname+"\"  class=''>") ;
            /* Active images/pictures */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 110,'',false,'',0)\"";
            ClassString = "Image";
            StyleString = "";
            sImgUrl = (string)(context.GetImagePath( "11a6ef14-1a5a-4077-91a2-f41ed9a3a662", "", context.GetTheme( )));
            GxWebStd.gx_bitmap( context, imgRemovedynamicfilters3_Internalname, sImgUrl, "", "", "", context.GetTheme( ), 1, 1, "", "Quitar filtro", 0, 0, 0, "px", 0, "px", 0, 0, 5, imgRemovedynamicfilters3_Jsonclick, "'"+""+"'"+",false,"+"'"+"E\\'REMOVEDYNAMICFILTERS3\\'."+"'", StyleString, ClassString, "", "", "", "", " "+"data-gx-image"+" "+TempTags, "", "", 1, false, false, context.GetImageSrcSet( sImgUrl), "HLP_Seguridad\\UsuariosWW.htm");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "</tr>") ;
            /* End of table */
            context.WriteHtmlText( "</table>") ;
            wb_table4_95_0H2e( true) ;
         }
         else
         {
            wb_table4_95_0H2e( false) ;
         }
      }

      protected void wb_table3_67_0H2( bool wbgen )
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
            GxWebStd.gx_combobox_ctrl1( context, cmbavDynamicfiltersoperator2, cmbavDynamicfiltersoperator2_Internalname, StringUtil.Trim( StringUtil.Str( (decimal)(AV20DynamicFiltersOperator2), 4, 0)), 1, cmbavDynamicfiltersoperator2_Jsonclick, 0, "'"+""+"'"+",false,"+"'"+""+"'", "int", "", cmbavDynamicfiltersoperator2.Visible, cmbavDynamicfiltersoperator2.Enabled, 0, 0, 0, "em", 0, "", "", "Attribute", "", "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,71);\"", "", true, 1, "HLP_Seguridad\\UsuariosWW.htm");
            cmbavDynamicfiltersoperator2.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV20DynamicFiltersOperator2), 4, 0));
            AssignProp("", false, cmbavDynamicfiltersoperator2_Internalname, "Values", (string)(cmbavDynamicfiltersoperator2.ToJavascriptSource()), true);
            GxWebStd.gx_div_end( context, "left", "top", "div");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "<td id=\""+cellFilter_usuvenddsc2_cell_Internalname+"\"  class=''>") ;
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "left", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavUsuvenddsc2_Internalname, "Usu Vend Dsc2", "gx-form-item AttributeLabel", 0, true, "width: 25%;");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 74,'',false,'" + sGXsfl_119_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavUsuvenddsc2_Internalname, StringUtil.RTrim( AV96UsuVendDsc2), StringUtil.RTrim( context.localUtil.Format( AV96UsuVendDsc2, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,74);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavUsuvenddsc2_Jsonclick, 0, "Attribute", "", "", "", "", edtavUsuvenddsc2_Visible, edtavUsuvenddsc2_Enabled, 0, "text", "", 80, "chr", 1, "row", 100, 0, 0, 0, 1, -1, -1, true, "", "left", true, "", "HLP_Seguridad\\UsuariosWW.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "<td id=\""+cellFilter_usutiedsc2_cell_Internalname+"\"  class=''>") ;
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "left", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavUsutiedsc2_Internalname, "Usu Tie Dsc2", "gx-form-item AttributeLabel", 0, true, "width: 25%;");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 77,'',false,'" + sGXsfl_119_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavUsutiedsc2_Internalname, StringUtil.RTrim( AV97UsuTieDsc2), StringUtil.RTrim( context.localUtil.Format( AV97UsuTieDsc2, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,77);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavUsutiedsc2_Jsonclick, 0, "Attribute", "", "", "", "", edtavUsutiedsc2_Visible, edtavUsutiedsc2_Enabled, 0, "text", "", 80, "chr", 1, "row", 100, 0, 0, 0, 1, -1, -1, true, "", "left", true, "", "HLP_Seguridad\\UsuariosWW.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "<td id=\""+cellFilter_usunom2_cell_Internalname+"\"  class=''>") ;
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "left", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavUsunom2_Internalname, "Usu Nom2", "gx-form-item AttributeLabel", 0, true, "width: 25%;");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 80,'',false,'" + sGXsfl_119_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavUsunom2_Internalname, StringUtil.RTrim( AV90UsuNom2), StringUtil.RTrim( context.localUtil.Format( AV90UsuNom2, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,80);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavUsunom2_Jsonclick, 0, "Attribute", "", "", "", "", edtavUsunom2_Visible, edtavUsunom2_Enabled, 0, "text", "", 80, "chr", 1, "row", 100, 0, 0, 0, 1, -1, -1, true, "", "left", true, "", "HLP_Seguridad\\UsuariosWW.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "<td id=\""+cellDynamicfilters_addfilter2_cell_Internalname+"\"  class=''>") ;
            /* Active images/pictures */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 82,'',false,'',0)\"";
            ClassString = "Image";
            StyleString = "";
            sImgUrl = (string)(context.GetImagePath( "27283ea5-332f-423b-b880-64b762622df3", "", context.GetTheme( )));
            GxWebStd.gx_bitmap( context, imgAdddynamicfilters2_Internalname, sImgUrl, "", "", "", context.GetTheme( ), imgAdddynamicfilters2_Visible, 1, "", "Agregar filtro", 0, 0, 0, "px", 0, "px", 0, 0, 5, imgAdddynamicfilters2_Jsonclick, "'"+""+"'"+",false,"+"'"+"E\\'ADDDYNAMICFILTERS2\\'."+"'", StyleString, ClassString, "", "", "", "", " "+"data-gx-image"+" "+TempTags, "", "", 1, false, false, context.GetImageSrcSet( sImgUrl), "HLP_Seguridad\\UsuariosWW.htm");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "<td id=\""+cellDynamicfilters_removefilter2_cell_Internalname+"\"  class=''>") ;
            /* Active images/pictures */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 84,'',false,'',0)\"";
            ClassString = "Image";
            StyleString = "";
            sImgUrl = (string)(context.GetImagePath( "11a6ef14-1a5a-4077-91a2-f41ed9a3a662", "", context.GetTheme( )));
            GxWebStd.gx_bitmap( context, imgRemovedynamicfilters2_Internalname, sImgUrl, "", "", "", context.GetTheme( ), imgRemovedynamicfilters2_Visible, 1, "", "Quitar filtro", 0, 0, 0, "px", 0, "px", 0, 0, 5, imgRemovedynamicfilters2_Jsonclick, "'"+""+"'"+",false,"+"'"+"E\\'REMOVEDYNAMICFILTERS2\\'."+"'", StyleString, ClassString, "", "", "", "", " "+"data-gx-image"+" "+TempTags, "", "", 1, false, false, context.GetImageSrcSet( sImgUrl), "HLP_Seguridad\\UsuariosWW.htm");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "</tr>") ;
            /* End of table */
            context.WriteHtmlText( "</table>") ;
            wb_table3_67_0H2e( true) ;
         }
         else
         {
            wb_table3_67_0H2e( false) ;
         }
      }

      protected void wb_table2_39_0H2( bool wbgen )
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
            GxWebStd.gx_combobox_ctrl1( context, cmbavDynamicfiltersoperator1, cmbavDynamicfiltersoperator1_Internalname, StringUtil.Trim( StringUtil.Str( (decimal)(AV16DynamicFiltersOperator1), 4, 0)), 1, cmbavDynamicfiltersoperator1_Jsonclick, 0, "'"+""+"'"+",false,"+"'"+""+"'", "int", "", cmbavDynamicfiltersoperator1.Visible, cmbavDynamicfiltersoperator1.Enabled, 0, 0, 0, "em", 0, "", "", "Attribute", "", "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,43);\"", "", true, 1, "HLP_Seguridad\\UsuariosWW.htm");
            cmbavDynamicfiltersoperator1.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV16DynamicFiltersOperator1), 4, 0));
            AssignProp("", false, cmbavDynamicfiltersoperator1_Internalname, "Values", (string)(cmbavDynamicfiltersoperator1.ToJavascriptSource()), true);
            GxWebStd.gx_div_end( context, "left", "top", "div");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "<td id=\""+cellFilter_usuvenddsc1_cell_Internalname+"\"  class=''>") ;
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "left", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavUsuvenddsc1_Internalname, "Usu Vend Dsc1", "gx-form-item AttributeLabel", 0, true, "width: 25%;");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 46,'',false,'" + sGXsfl_119_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavUsuvenddsc1_Internalname, StringUtil.RTrim( AV94UsuVendDsc1), StringUtil.RTrim( context.localUtil.Format( AV94UsuVendDsc1, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,46);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavUsuvenddsc1_Jsonclick, 0, "Attribute", "", "", "", "", edtavUsuvenddsc1_Visible, edtavUsuvenddsc1_Enabled, 0, "text", "", 80, "chr", 1, "row", 100, 0, 0, 0, 1, -1, -1, true, "", "left", true, "", "HLP_Seguridad\\UsuariosWW.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "<td id=\""+cellFilter_usutiedsc1_cell_Internalname+"\"  class=''>") ;
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "left", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavUsutiedsc1_Internalname, "Usu Tie Dsc1", "gx-form-item AttributeLabel", 0, true, "width: 25%;");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 49,'',false,'" + sGXsfl_119_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavUsutiedsc1_Internalname, StringUtil.RTrim( AV95UsuTieDsc1), StringUtil.RTrim( context.localUtil.Format( AV95UsuTieDsc1, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,49);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavUsutiedsc1_Jsonclick, 0, "Attribute", "", "", "", "", edtavUsutiedsc1_Visible, edtavUsutiedsc1_Enabled, 0, "text", "", 80, "chr", 1, "row", 100, 0, 0, 0, 1, -1, -1, true, "", "left", true, "", "HLP_Seguridad\\UsuariosWW.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "<td id=\""+cellFilter_usunom1_cell_Internalname+"\"  class=''>") ;
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "left", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavUsunom1_Internalname, "Usu Nom1", "gx-form-item AttributeLabel", 0, true, "width: 25%;");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 52,'',false,'" + sGXsfl_119_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavUsunom1_Internalname, StringUtil.RTrim( AV89UsuNom1), StringUtil.RTrim( context.localUtil.Format( AV89UsuNom1, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,52);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavUsunom1_Jsonclick, 0, "Attribute", "", "", "", "", edtavUsunom1_Visible, edtavUsunom1_Enabled, 0, "text", "", 80, "chr", 1, "row", 100, 0, 0, 0, 1, -1, -1, true, "", "left", true, "", "HLP_Seguridad\\UsuariosWW.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "<td id=\""+cellDynamicfilters_addfilter1_cell_Internalname+"\"  class=''>") ;
            /* Active images/pictures */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 54,'',false,'',0)\"";
            ClassString = "Image";
            StyleString = "";
            sImgUrl = (string)(context.GetImagePath( "27283ea5-332f-423b-b880-64b762622df3", "", context.GetTheme( )));
            GxWebStd.gx_bitmap( context, imgAdddynamicfilters1_Internalname, sImgUrl, "", "", "", context.GetTheme( ), imgAdddynamicfilters1_Visible, 1, "", "Agregar filtro", 0, 0, 0, "px", 0, "px", 0, 0, 5, imgAdddynamicfilters1_Jsonclick, "'"+""+"'"+",false,"+"'"+"E\\'ADDDYNAMICFILTERS1\\'."+"'", StyleString, ClassString, "", "", "", "", " "+"data-gx-image"+" "+TempTags, "", "", 1, false, false, context.GetImageSrcSet( sImgUrl), "HLP_Seguridad\\UsuariosWW.htm");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "<td id=\""+cellDynamicfilters_removefilter1_cell_Internalname+"\"  class=''>") ;
            /* Active images/pictures */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 56,'',false,'',0)\"";
            ClassString = "Image";
            StyleString = "";
            sImgUrl = (string)(context.GetImagePath( "11a6ef14-1a5a-4077-91a2-f41ed9a3a662", "", context.GetTheme( )));
            GxWebStd.gx_bitmap( context, imgRemovedynamicfilters1_Internalname, sImgUrl, "", "", "", context.GetTheme( ), imgRemovedynamicfilters1_Visible, 1, "", "Quitar filtro", 0, 0, 0, "px", 0, "px", 0, 0, 5, imgRemovedynamicfilters1_Jsonclick, "'"+""+"'"+",false,"+"'"+"E\\'REMOVEDYNAMICFILTERS1\\'."+"'", StyleString, ClassString, "", "", "", "", " "+"data-gx-image"+" "+TempTags, "", "", 1, false, false, context.GetImageSrcSet( sImgUrl), "HLP_Seguridad\\UsuariosWW.htm");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "</tr>") ;
            /* End of table */
            context.WriteHtmlText( "</table>") ;
            wb_table2_39_0H2e( true) ;
         }
         else
         {
            wb_table2_39_0H2e( false) ;
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
         PA0H2( ) ;
         WS0H2( ) ;
         WE0H2( ) ;
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
            context.AddJavascriptSource(StringUtil.RTrim( ((string)Form.Jscriptsrc.Item(idxLst))), "?202281810281982", true, true);
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
         context.AddJavascriptSource("seguridad/usuariosww.js", "?202281810281982", false, true);
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
         edtUsuCod_Internalname = "USUCOD_"+sGXsfl_119_idx;
         edtUsuNom_Internalname = "USUNOM_"+sGXsfl_119_idx;
         edtUsuEMAIL_Internalname = "USUEMAIL_"+sGXsfl_119_idx;
         cmbUsuSts_Internalname = "USUSTS_"+sGXsfl_119_idx;
         edtUsuVendDsc_Internalname = "USUVENDDSC_"+sGXsfl_119_idx;
         edtUsuTieDsc_Internalname = "USUTIEDSC_"+sGXsfl_119_idx;
      }

      protected void SubsflControlProps_fel_1192( )
      {
         cmbavGridactions_Internalname = "vGRIDACTIONS_"+sGXsfl_119_fel_idx;
         edtUsuCod_Internalname = "USUCOD_"+sGXsfl_119_fel_idx;
         edtUsuNom_Internalname = "USUNOM_"+sGXsfl_119_fel_idx;
         edtUsuEMAIL_Internalname = "USUEMAIL_"+sGXsfl_119_fel_idx;
         cmbUsuSts_Internalname = "USUSTS_"+sGXsfl_119_fel_idx;
         edtUsuVendDsc_Internalname = "USUVENDDSC_"+sGXsfl_119_fel_idx;
         edtUsuTieDsc_Internalname = "USUTIEDSC_"+sGXsfl_119_fel_idx;
      }

      protected void sendrow_1192( )
      {
         SubsflControlProps_1192( ) ;
         WB0H0( ) ;
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
                  AV86GridActions = (short)(NumberUtil.Val( cmbavGridactions.getValidValue(StringUtil.Trim( StringUtil.Str( (decimal)(AV86GridActions), 4, 0))), "."));
                  AssignAttri("", false, cmbavGridactions_Internalname, StringUtil.LTrimStr( (decimal)(AV86GridActions), 4, 0));
               }
            }
            /* ComboBox */
            GridRow.AddColumnProperties("combobox", 2, isAjaxCallMode( ), new Object[] {(GXCombobox)cmbavGridactions,(string)cmbavGridactions_Internalname,StringUtil.Trim( StringUtil.Str( (decimal)(AV86GridActions), 4, 0)),(short)1,(string)cmbavGridactions_Jsonclick,(short)5,"'"+""+"'"+",false,"+"'"+"EVGRIDACTIONS.CLICK."+sGXsfl_119_idx+"'",(string)"int",(string)"",(short)-1,(short)1,(short)0,(short)0,(short)0,(string)"px",(short)0,(string)"px",(string)"",(string)"ConvertToDDO",(string)"WWActionGroupColumn",(string)"",TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+((cmbavGridactions.Enabled!=0)&&(cmbavGridactions.Visible!=0) ? " onblur=\""+""+";gx.evt.onblur(this,120);\"" : " "),(string)"",(bool)true,(short)1});
            cmbavGridactions.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV86GridActions), 4, 0));
            AssignProp("", false, cmbavGridactions_Internalname, "Values", (string)(cmbavGridactions.ToJavascriptSource()), !bGXsfl_119_Refreshing);
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"left"+"\""+" style=\""+""+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtUsuCod_Internalname,StringUtil.RTrim( A348UsuCod),(string)"",(string)"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)edtUsuCod_Link,(string)"",(string)"",(string)"",(string)edtUsuCod_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)edtUsuCod_Columnclass,(string)edtUsuCod_Columnheaderclass,(short)-1,(short)0,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)10,(short)0,(short)0,(short)119,(short)1,(short)-1,(short)-1,(bool)true,(string)"",(string)"left",(bool)true,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"left"+"\""+" style=\""+""+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtUsuNom_Internalname,StringUtil.RTrim( A2019UsuNom),(string)"",(string)"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)edtUsuNom_Link,(string)"",(string)"",(string)"",(string)edtUsuNom_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)edtUsuNom_Columnclass,(string)edtUsuNom_Columnheaderclass,(short)-1,(short)0,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)100,(short)0,(short)0,(short)119,(short)1,(short)-1,(short)-1,(bool)true,(string)"",(string)"left",(bool)true,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"left"+"\""+" style=\""+""+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtUsuEMAIL_Internalname,(string)A2014UsuEMAIL,(string)"",(string)"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtUsuEMAIL_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)edtUsuEMAIL_Columnclass,(string)edtUsuEMAIL_Columnheaderclass,(short)-1,(short)0,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)100,(short)0,(short)0,(short)119,(short)1,(short)-1,(short)-1,(bool)true,(string)"",(string)"left",(bool)true,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"right"+"\""+" style=\""+""+"\">") ;
            }
            if ( ( cmbUsuSts.ItemCount == 0 ) && isAjaxCallMode( ) )
            {
               GXCCtl = "USUSTS_" + sGXsfl_119_idx;
               cmbUsuSts.Name = GXCCtl;
               cmbUsuSts.WebTags = "";
               cmbUsuSts.addItem("1", "ACTIVO", 0);
               cmbUsuSts.addItem("0", "INACTIVO", 0);
               if ( cmbUsuSts.ItemCount > 0 )
               {
                  A2039UsuSts = (short)(NumberUtil.Val( cmbUsuSts.getValidValue(StringUtil.Trim( StringUtil.Str( (decimal)(A2039UsuSts), 1, 0))), "."));
               }
            }
            /* ComboBox */
            GridRow.AddColumnProperties("combobox", 2, isAjaxCallMode( ), new Object[] {(GXCombobox)cmbUsuSts,(string)cmbUsuSts_Internalname,StringUtil.Trim( StringUtil.Str( (decimal)(A2039UsuSts), 1, 0)),(short)1,(string)cmbUsuSts_Jsonclick,(short)0,(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"int",(string)"",(short)-1,(short)0,(short)0,(short)0,(short)0,(string)"px",(short)0,(string)"px",(string)"",(string)"Attribute",(string)cmbUsuSts_Columnclass,(string)cmbUsuSts_Columnheaderclass,(string)"",(string)"",(bool)true,(short)1});
            cmbUsuSts.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(A2039UsuSts), 1, 0));
            AssignProp("", false, cmbUsuSts_Internalname, "Values", (string)(cmbUsuSts.ToJavascriptSource()), !bGXsfl_119_Refreshing);
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"left"+"\""+" style=\""+""+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtUsuVendDsc_Internalname,StringUtil.RTrim( A2097UsuVendDsc),(string)"",(string)"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)edtUsuVendDsc_Link,(string)"",(string)"",(string)"",(string)edtUsuVendDsc_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn hidden-xs",(string)"",(short)-1,(short)0,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)100,(short)0,(short)0,(short)119,(short)1,(short)-1,(short)-1,(bool)true,(string)"",(string)"left",(bool)true,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"left"+"\""+" style=\""+""+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtUsuTieDsc_Internalname,StringUtil.RTrim( A2096UsuTieDsc),(string)"",(string)"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)edtUsuTieDsc_Link,(string)"",(string)"",(string)"",(string)edtUsuTieDsc_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn hidden-xs",(string)"",(short)-1,(short)0,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)100,(short)0,(short)0,(short)119,(short)1,(short)-1,(short)-1,(bool)true,(string)"",(string)"left",(bool)true,(string)""});
            send_integrity_lvl_hashes0H2( ) ;
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
         cmbavDynamicfiltersselector1.addItem("USUVENDDSC", "Vendedor", 0);
         cmbavDynamicfiltersselector1.addItem("USUTIEDSC", "Local", 0);
         cmbavDynamicfiltersselector1.addItem("USUNOM", "Nombre de Usuario", 0);
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
         cmbavDynamicfiltersselector2.addItem("USUVENDDSC", "Vendedor", 0);
         cmbavDynamicfiltersselector2.addItem("USUTIEDSC", "Local", 0);
         cmbavDynamicfiltersselector2.addItem("USUNOM", "Nombre de Usuario", 0);
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
         cmbavDynamicfiltersselector3.addItem("USUVENDDSC", "Vendedor", 0);
         cmbavDynamicfiltersselector3.addItem("USUTIEDSC", "Local", 0);
         cmbavDynamicfiltersselector3.addItem("USUNOM", "Nombre de Usuario", 0);
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
         GXCCtl = "vGRIDACTIONS_" + sGXsfl_119_idx;
         cmbavGridactions.Name = GXCCtl;
         cmbavGridactions.WebTags = "";
         if ( cmbavGridactions.ItemCount > 0 )
         {
            AV86GridActions = (short)(NumberUtil.Val( cmbavGridactions.getValidValue(StringUtil.Trim( StringUtil.Str( (decimal)(AV86GridActions), 4, 0))), "."));
            AssignAttri("", false, cmbavGridactions_Internalname, StringUtil.LTrimStr( (decimal)(AV86GridActions), 4, 0));
         }
         GXCCtl = "USUSTS_" + sGXsfl_119_idx;
         cmbUsuSts.Name = GXCCtl;
         cmbUsuSts.WebTags = "";
         cmbUsuSts.addItem("1", "ACTIVO", 0);
         cmbUsuSts.addItem("0", "INACTIVO", 0);
         if ( cmbUsuSts.ItemCount > 0 )
         {
            A2039UsuSts = (short)(NumberUtil.Val( cmbUsuSts.getValidValue(StringUtil.Trim( StringUtil.Str( (decimal)(A2039UsuSts), 1, 0))), "."));
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
         edtavUsuvenddsc1_Internalname = "vUSUVENDDSC1";
         cellFilter_usuvenddsc1_cell_Internalname = "FILTER_USUVENDDSC1_CELL";
         edtavUsutiedsc1_Internalname = "vUSUTIEDSC1";
         cellFilter_usutiedsc1_cell_Internalname = "FILTER_USUTIEDSC1_CELL";
         edtavUsunom1_Internalname = "vUSUNOM1";
         cellFilter_usunom1_cell_Internalname = "FILTER_USUNOM1_CELL";
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
         edtavUsuvenddsc2_Internalname = "vUSUVENDDSC2";
         cellFilter_usuvenddsc2_cell_Internalname = "FILTER_USUVENDDSC2_CELL";
         edtavUsutiedsc2_Internalname = "vUSUTIEDSC2";
         cellFilter_usutiedsc2_cell_Internalname = "FILTER_USUTIEDSC2_CELL";
         edtavUsunom2_Internalname = "vUSUNOM2";
         cellFilter_usunom2_cell_Internalname = "FILTER_USUNOM2_CELL";
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
         edtavUsuvenddsc3_Internalname = "vUSUVENDDSC3";
         cellFilter_usuvenddsc3_cell_Internalname = "FILTER_USUVENDDSC3_CELL";
         edtavUsutiedsc3_Internalname = "vUSUTIEDSC3";
         cellFilter_usutiedsc3_cell_Internalname = "FILTER_USUTIEDSC3_CELL";
         edtavUsunom3_Internalname = "vUSUNOM3";
         cellFilter_usunom3_cell_Internalname = "FILTER_USUNOM3_CELL";
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
         edtUsuCod_Internalname = "USUCOD";
         edtUsuNom_Internalname = "USUNOM";
         edtUsuEMAIL_Internalname = "USUEMAIL";
         cmbUsuSts_Internalname = "USUSTS";
         edtUsuVendDsc_Internalname = "USUVENDDSC";
         edtUsuTieDsc_Internalname = "USUTIEDSC";
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
         edtUsuTieDsc_Jsonclick = "";
         edtUsuVendDsc_Jsonclick = "";
         cmbUsuSts_Jsonclick = "";
         edtUsuEMAIL_Jsonclick = "";
         edtUsuNom_Jsonclick = "";
         edtUsuCod_Jsonclick = "";
         cmbavGridactions_Jsonclick = "";
         cmbavGridactions.Visible = -1;
         cmbavGridactions.Enabled = 1;
         imgRemovedynamicfilters1_Visible = 1;
         imgAdddynamicfilters1_Visible = 1;
         edtavUsunom1_Jsonclick = "";
         edtavUsunom1_Enabled = 1;
         edtavUsutiedsc1_Jsonclick = "";
         edtavUsutiedsc1_Enabled = 1;
         edtavUsuvenddsc1_Jsonclick = "";
         edtavUsuvenddsc1_Enabled = 1;
         cmbavDynamicfiltersoperator1_Jsonclick = "";
         cmbavDynamicfiltersoperator1.Enabled = 1;
         imgRemovedynamicfilters2_Visible = 1;
         imgAdddynamicfilters2_Visible = 1;
         edtavUsunom2_Jsonclick = "";
         edtavUsunom2_Enabled = 1;
         edtavUsutiedsc2_Jsonclick = "";
         edtavUsutiedsc2_Enabled = 1;
         edtavUsuvenddsc2_Jsonclick = "";
         edtavUsuvenddsc2_Enabled = 1;
         cmbavDynamicfiltersoperator2_Jsonclick = "";
         cmbavDynamicfiltersoperator2.Enabled = 1;
         edtavUsunom3_Jsonclick = "";
         edtavUsunom3_Enabled = 1;
         edtavUsutiedsc3_Jsonclick = "";
         edtavUsutiedsc3_Enabled = 1;
         edtavUsuvenddsc3_Jsonclick = "";
         edtavUsuvenddsc3_Enabled = 1;
         cmbavDynamicfiltersoperator3_Jsonclick = "";
         cmbavDynamicfiltersoperator3.Enabled = 1;
         cmbavDynamicfiltersselector3_Jsonclick = "";
         cmbavDynamicfiltersselector3.Enabled = 1;
         cmbavDynamicfiltersselector2_Jsonclick = "";
         cmbavDynamicfiltersselector2.Enabled = 1;
         cmbavDynamicfiltersselector1_Jsonclick = "";
         cmbavDynamicfiltersselector1.Enabled = 1;
         cmbavDynamicfiltersoperator3.Visible = 1;
         edtavUsunom3_Visible = 1;
         edtavUsutiedsc3_Visible = 1;
         edtavUsuvenddsc3_Visible = 1;
         cmbavDynamicfiltersoperator2.Visible = 1;
         edtavUsunom2_Visible = 1;
         edtavUsutiedsc2_Visible = 1;
         edtavUsuvenddsc2_Visible = 1;
         cmbavDynamicfiltersoperator1.Visible = 1;
         edtavUsunom1_Visible = 1;
         edtavUsutiedsc1_Visible = 1;
         edtavUsuvenddsc1_Visible = 1;
         lblJsdynamicfilters_Caption = "JSDynamicFilters";
         subGrid_Allowcollapsing = 0;
         subGrid_Allowselection = 0;
         edtUsuTieDsc_Link = "";
         edtUsuVendDsc_Link = "";
         cmbUsuSts_Columnheaderclass = "";
         cmbUsuSts_Columnclass = "WWColumn hidden-xs";
         edtUsuEMAIL_Columnheaderclass = "";
         edtUsuEMAIL_Columnclass = "WWColumn hidden-xs";
         edtUsuNom_Link = "";
         edtUsuNom_Columnheaderclass = "";
         edtUsuNom_Columnclass = "WWColumn hidden-xs";
         edtUsuCod_Link = "";
         edtUsuCod_Columnheaderclass = "";
         edtUsuCod_Columnclass = "WWColumn";
         subGrid_Sortable = 0;
         subGrid_Header = "";
         subGrid_Class = "GridWithPaginationBar WorkWith";
         subGrid_Backcolorstyle = 0;
         Grid_empowerer_Hastitlesettings = Convert.ToBoolean( -1);
         Innewwindow1_Target = "";
         Innewwindow1_Height = "50";
         Innewwindow1_Width = "50";
         Ddo_grid_Datalistproc = "Seguridad.UsuariosWWGetFilterData";
         Ddo_grid_Datalistfixedvalues = "|||1:ACTIVO,0:INACTIVO||";
         Ddo_grid_Allowmultipleselection = "|||T||";
         Ddo_grid_Datalisttype = "Dynamic|Dynamic|Dynamic|FixedValues|Dynamic|Dynamic";
         Ddo_grid_Includedatalist = "T";
         Ddo_grid_Filtertype = "Character|Character|Character||Character|Character";
         Ddo_grid_Includefilter = "T|T|T||T|T";
         Ddo_grid_Includesortasc = "T";
         Ddo_grid_Columnssortvalues = "1|2|3|4|5|6";
         Ddo_grid_Columnids = "1:UsuCod|2:UsuNom|3:UsuEMAIL|4:UsuSts|5:UsuVendDsc|6:UsuTieDsc";
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
         Form.Caption = " Usuarios";
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
         setEventMetadata("REFRESH","{handler:'Refresh',iparms:[{av:'GRID_nFirstRecordOnPage'},{av:'GRID_nEOF'},{av:'cmbavDynamicfiltersselector1'},{av:'AV15DynamicFiltersSelector1',fld:'vDYNAMICFILTERSSELECTOR1',pic:''},{av:'AV18DynamicFiltersEnabled2',fld:'vDYNAMICFILTERSENABLED2',pic:''},{av:'cmbavDynamicfiltersselector2'},{av:'AV19DynamicFiltersSelector2',fld:'vDYNAMICFILTERSSELECTOR2',pic:''},{av:'AV22DynamicFiltersEnabled3',fld:'vDYNAMICFILTERSENABLED3',pic:''},{av:'cmbavDynamicfiltersselector3'},{av:'AV23DynamicFiltersSelector3',fld:'vDYNAMICFILTERSSELECTOR3',pic:''},{av:'subGrid_Rows',ctrl:'GRID',prop:'Rows'},{av:'cmbavDynamicfiltersoperator1'},{av:'AV16DynamicFiltersOperator1',fld:'vDYNAMICFILTERSOPERATOR1',pic:'ZZZ9'},{av:'AV94UsuVendDsc1',fld:'vUSUVENDDSC1',pic:''},{av:'AV95UsuTieDsc1',fld:'vUSUTIEDSC1',pic:''},{av:'AV89UsuNom1',fld:'vUSUNOM1',pic:''},{av:'cmbavDynamicfiltersoperator2'},{av:'AV20DynamicFiltersOperator2',fld:'vDYNAMICFILTERSOPERATOR2',pic:'ZZZ9'},{av:'AV96UsuVendDsc2',fld:'vUSUVENDDSC2',pic:''},{av:'AV97UsuTieDsc2',fld:'vUSUTIEDSC2',pic:''},{av:'AV90UsuNom2',fld:'vUSUNOM2',pic:''},{av:'cmbavDynamicfiltersoperator3'},{av:'AV24DynamicFiltersOperator3',fld:'vDYNAMICFILTERSOPERATOR3',pic:'ZZZ9'},{av:'AV98UsuVendDsc3',fld:'vUSUVENDDSC3',pic:''},{av:'AV99UsuTieDsc3',fld:'vUSUTIEDSC3',pic:''},{av:'AV91UsuNom3',fld:'vUSUNOM3',pic:''},{av:'AV106Pgmname',fld:'vPGMNAME',pic:'',hsh:true},{av:'AV31TFUsuCod',fld:'vTFUSUCOD',pic:''},{av:'AV32TFUsuCod_Sel',fld:'vTFUSUCOD_SEL',pic:''},{av:'AV35TFUsuNom',fld:'vTFUSUNOM',pic:''},{av:'AV36TFUsuNom_Sel',fld:'vTFUSUNOM_SEL',pic:''},{av:'AV67TFUsuEMAIL',fld:'vTFUSUEMAIL',pic:''},{av:'AV68TFUsuEMAIL_Sel',fld:'vTFUSUEMAIL_SEL',pic:''},{av:'AV93TFUsuSts_Sels',fld:'vTFUSUSTS_SELS',pic:''},{av:'AV100TFUsuVendDsc',fld:'vTFUSUVENDDSC',pic:''},{av:'AV101TFUsuVendDsc_Sel',fld:'vTFUSUVENDDSC_SEL',pic:''},{av:'AV102TFUsuTieDsc',fld:'vTFUSUTIEDSC',pic:''},{av:'AV103TFUsuTieDsc_Sel',fld:'vTFUSUTIEDSC_SEL',pic:''},{av:'AV13OrderedBy',fld:'vORDEREDBY',pic:'ZZZ9'},{av:'AV14OrderedDsc',fld:'vORDEREDDSC',pic:''},{av:'AV10GridState',fld:'vGRIDSTATE',pic:''},{av:'AV27DynamicFiltersIgnoreFirst',fld:'vDYNAMICFILTERSIGNOREFIRST',pic:''},{av:'AV26DynamicFiltersRemoving',fld:'vDYNAMICFILTERSREMOVING',pic:''}]");
         setEventMetadata("REFRESH",",oparms:[{av:'cmbavDynamicfiltersoperator1'},{av:'AV16DynamicFiltersOperator1',fld:'vDYNAMICFILTERSOPERATOR1',pic:'ZZZ9'},{av:'cmbavDynamicfiltersoperator2'},{av:'AV20DynamicFiltersOperator2',fld:'vDYNAMICFILTERSOPERATOR2',pic:'ZZZ9'},{av:'cmbavDynamicfiltersoperator3'},{av:'AV24DynamicFiltersOperator3',fld:'vDYNAMICFILTERSOPERATOR3',pic:'ZZZ9'},{av:'AV83GridCurrentPage',fld:'vGRIDCURRENTPAGE',pic:'ZZZZZZZZZ9'},{av:'AV84GridPageCount',fld:'vGRIDPAGECOUNT',pic:'ZZZZZZZZZ9'},{av:'AV85GridAppliedFilters',fld:'vGRIDAPPLIEDFILTERS',pic:''},{av:'edtUsuCod_Columnheaderclass',ctrl:'USUCOD',prop:'Columnheaderclass'},{av:'edtUsuNom_Columnheaderclass',ctrl:'USUNOM',prop:'Columnheaderclass'},{av:'edtUsuEMAIL_Columnheaderclass',ctrl:'USUEMAIL',prop:'Columnheaderclass'},{av:'cmbUsuSts'},{av:'AV10GridState',fld:'vGRIDSTATE',pic:''}]}");
         setEventMetadata("GRIDPAGINATIONBAR.CHANGEPAGE","{handler:'E110H2',iparms:[{av:'GRID_nFirstRecordOnPage'},{av:'GRID_nEOF'},{av:'subGrid_Rows',ctrl:'GRID',prop:'Rows'},{av:'cmbavDynamicfiltersselector1'},{av:'AV15DynamicFiltersSelector1',fld:'vDYNAMICFILTERSSELECTOR1',pic:''},{av:'cmbavDynamicfiltersoperator1'},{av:'AV16DynamicFiltersOperator1',fld:'vDYNAMICFILTERSOPERATOR1',pic:'ZZZ9'},{av:'AV94UsuVendDsc1',fld:'vUSUVENDDSC1',pic:''},{av:'AV95UsuTieDsc1',fld:'vUSUTIEDSC1',pic:''},{av:'AV89UsuNom1',fld:'vUSUNOM1',pic:''},{av:'cmbavDynamicfiltersselector2'},{av:'AV19DynamicFiltersSelector2',fld:'vDYNAMICFILTERSSELECTOR2',pic:''},{av:'cmbavDynamicfiltersoperator2'},{av:'AV20DynamicFiltersOperator2',fld:'vDYNAMICFILTERSOPERATOR2',pic:'ZZZ9'},{av:'AV96UsuVendDsc2',fld:'vUSUVENDDSC2',pic:''},{av:'AV97UsuTieDsc2',fld:'vUSUTIEDSC2',pic:''},{av:'AV90UsuNom2',fld:'vUSUNOM2',pic:''},{av:'cmbavDynamicfiltersselector3'},{av:'AV23DynamicFiltersSelector3',fld:'vDYNAMICFILTERSSELECTOR3',pic:''},{av:'cmbavDynamicfiltersoperator3'},{av:'AV24DynamicFiltersOperator3',fld:'vDYNAMICFILTERSOPERATOR3',pic:'ZZZ9'},{av:'AV98UsuVendDsc3',fld:'vUSUVENDDSC3',pic:''},{av:'AV99UsuTieDsc3',fld:'vUSUTIEDSC3',pic:''},{av:'AV91UsuNom3',fld:'vUSUNOM3',pic:''},{av:'AV18DynamicFiltersEnabled2',fld:'vDYNAMICFILTERSENABLED2',pic:''},{av:'AV22DynamicFiltersEnabled3',fld:'vDYNAMICFILTERSENABLED3',pic:''},{av:'AV106Pgmname',fld:'vPGMNAME',pic:'',hsh:true},{av:'AV31TFUsuCod',fld:'vTFUSUCOD',pic:''},{av:'AV32TFUsuCod_Sel',fld:'vTFUSUCOD_SEL',pic:''},{av:'AV35TFUsuNom',fld:'vTFUSUNOM',pic:''},{av:'AV36TFUsuNom_Sel',fld:'vTFUSUNOM_SEL',pic:''},{av:'AV67TFUsuEMAIL',fld:'vTFUSUEMAIL',pic:''},{av:'AV68TFUsuEMAIL_Sel',fld:'vTFUSUEMAIL_SEL',pic:''},{av:'AV93TFUsuSts_Sels',fld:'vTFUSUSTS_SELS',pic:''},{av:'AV100TFUsuVendDsc',fld:'vTFUSUVENDDSC',pic:''},{av:'AV101TFUsuVendDsc_Sel',fld:'vTFUSUVENDDSC_SEL',pic:''},{av:'AV102TFUsuTieDsc',fld:'vTFUSUTIEDSC',pic:''},{av:'AV103TFUsuTieDsc_Sel',fld:'vTFUSUTIEDSC_SEL',pic:''},{av:'AV13OrderedBy',fld:'vORDEREDBY',pic:'ZZZ9'},{av:'AV14OrderedDsc',fld:'vORDEREDDSC',pic:''},{av:'AV10GridState',fld:'vGRIDSTATE',pic:''},{av:'AV27DynamicFiltersIgnoreFirst',fld:'vDYNAMICFILTERSIGNOREFIRST',pic:''},{av:'AV26DynamicFiltersRemoving',fld:'vDYNAMICFILTERSREMOVING',pic:''},{av:'Gridpaginationbar_Selectedpage',ctrl:'GRIDPAGINATIONBAR',prop:'SelectedPage'}]");
         setEventMetadata("GRIDPAGINATIONBAR.CHANGEPAGE",",oparms:[]}");
         setEventMetadata("GRIDPAGINATIONBAR.CHANGEROWSPERPAGE","{handler:'E120H2',iparms:[{av:'GRID_nFirstRecordOnPage'},{av:'GRID_nEOF'},{av:'subGrid_Rows',ctrl:'GRID',prop:'Rows'},{av:'cmbavDynamicfiltersselector1'},{av:'AV15DynamicFiltersSelector1',fld:'vDYNAMICFILTERSSELECTOR1',pic:''},{av:'cmbavDynamicfiltersoperator1'},{av:'AV16DynamicFiltersOperator1',fld:'vDYNAMICFILTERSOPERATOR1',pic:'ZZZ9'},{av:'AV94UsuVendDsc1',fld:'vUSUVENDDSC1',pic:''},{av:'AV95UsuTieDsc1',fld:'vUSUTIEDSC1',pic:''},{av:'AV89UsuNom1',fld:'vUSUNOM1',pic:''},{av:'cmbavDynamicfiltersselector2'},{av:'AV19DynamicFiltersSelector2',fld:'vDYNAMICFILTERSSELECTOR2',pic:''},{av:'cmbavDynamicfiltersoperator2'},{av:'AV20DynamicFiltersOperator2',fld:'vDYNAMICFILTERSOPERATOR2',pic:'ZZZ9'},{av:'AV96UsuVendDsc2',fld:'vUSUVENDDSC2',pic:''},{av:'AV97UsuTieDsc2',fld:'vUSUTIEDSC2',pic:''},{av:'AV90UsuNom2',fld:'vUSUNOM2',pic:''},{av:'cmbavDynamicfiltersselector3'},{av:'AV23DynamicFiltersSelector3',fld:'vDYNAMICFILTERSSELECTOR3',pic:''},{av:'cmbavDynamicfiltersoperator3'},{av:'AV24DynamicFiltersOperator3',fld:'vDYNAMICFILTERSOPERATOR3',pic:'ZZZ9'},{av:'AV98UsuVendDsc3',fld:'vUSUVENDDSC3',pic:''},{av:'AV99UsuTieDsc3',fld:'vUSUTIEDSC3',pic:''},{av:'AV91UsuNom3',fld:'vUSUNOM3',pic:''},{av:'AV18DynamicFiltersEnabled2',fld:'vDYNAMICFILTERSENABLED2',pic:''},{av:'AV22DynamicFiltersEnabled3',fld:'vDYNAMICFILTERSENABLED3',pic:''},{av:'AV106Pgmname',fld:'vPGMNAME',pic:'',hsh:true},{av:'AV31TFUsuCod',fld:'vTFUSUCOD',pic:''},{av:'AV32TFUsuCod_Sel',fld:'vTFUSUCOD_SEL',pic:''},{av:'AV35TFUsuNom',fld:'vTFUSUNOM',pic:''},{av:'AV36TFUsuNom_Sel',fld:'vTFUSUNOM_SEL',pic:''},{av:'AV67TFUsuEMAIL',fld:'vTFUSUEMAIL',pic:''},{av:'AV68TFUsuEMAIL_Sel',fld:'vTFUSUEMAIL_SEL',pic:''},{av:'AV93TFUsuSts_Sels',fld:'vTFUSUSTS_SELS',pic:''},{av:'AV100TFUsuVendDsc',fld:'vTFUSUVENDDSC',pic:''},{av:'AV101TFUsuVendDsc_Sel',fld:'vTFUSUVENDDSC_SEL',pic:''},{av:'AV102TFUsuTieDsc',fld:'vTFUSUTIEDSC',pic:''},{av:'AV103TFUsuTieDsc_Sel',fld:'vTFUSUTIEDSC_SEL',pic:''},{av:'AV13OrderedBy',fld:'vORDEREDBY',pic:'ZZZ9'},{av:'AV14OrderedDsc',fld:'vORDEREDDSC',pic:''},{av:'AV10GridState',fld:'vGRIDSTATE',pic:''},{av:'AV27DynamicFiltersIgnoreFirst',fld:'vDYNAMICFILTERSIGNOREFIRST',pic:''},{av:'AV26DynamicFiltersRemoving',fld:'vDYNAMICFILTERSREMOVING',pic:''},{av:'Gridpaginationbar_Rowsperpageselectedvalue',ctrl:'GRIDPAGINATIONBAR',prop:'RowsPerPageSelectedValue'}]");
         setEventMetadata("GRIDPAGINATIONBAR.CHANGEROWSPERPAGE",",oparms:[{av:'subGrid_Rows',ctrl:'GRID',prop:'Rows'}]}");
         setEventMetadata("DDO_GRID.ONOPTIONCLICKED","{handler:'E140H2',iparms:[{av:'GRID_nFirstRecordOnPage'},{av:'GRID_nEOF'},{av:'subGrid_Rows',ctrl:'GRID',prop:'Rows'},{av:'cmbavDynamicfiltersselector1'},{av:'AV15DynamicFiltersSelector1',fld:'vDYNAMICFILTERSSELECTOR1',pic:''},{av:'cmbavDynamicfiltersoperator1'},{av:'AV16DynamicFiltersOperator1',fld:'vDYNAMICFILTERSOPERATOR1',pic:'ZZZ9'},{av:'AV94UsuVendDsc1',fld:'vUSUVENDDSC1',pic:''},{av:'AV95UsuTieDsc1',fld:'vUSUTIEDSC1',pic:''},{av:'AV89UsuNom1',fld:'vUSUNOM1',pic:''},{av:'cmbavDynamicfiltersselector2'},{av:'AV19DynamicFiltersSelector2',fld:'vDYNAMICFILTERSSELECTOR2',pic:''},{av:'cmbavDynamicfiltersoperator2'},{av:'AV20DynamicFiltersOperator2',fld:'vDYNAMICFILTERSOPERATOR2',pic:'ZZZ9'},{av:'AV96UsuVendDsc2',fld:'vUSUVENDDSC2',pic:''},{av:'AV97UsuTieDsc2',fld:'vUSUTIEDSC2',pic:''},{av:'AV90UsuNom2',fld:'vUSUNOM2',pic:''},{av:'cmbavDynamicfiltersselector3'},{av:'AV23DynamicFiltersSelector3',fld:'vDYNAMICFILTERSSELECTOR3',pic:''},{av:'cmbavDynamicfiltersoperator3'},{av:'AV24DynamicFiltersOperator3',fld:'vDYNAMICFILTERSOPERATOR3',pic:'ZZZ9'},{av:'AV98UsuVendDsc3',fld:'vUSUVENDDSC3',pic:''},{av:'AV99UsuTieDsc3',fld:'vUSUTIEDSC3',pic:''},{av:'AV91UsuNom3',fld:'vUSUNOM3',pic:''},{av:'AV18DynamicFiltersEnabled2',fld:'vDYNAMICFILTERSENABLED2',pic:''},{av:'AV22DynamicFiltersEnabled3',fld:'vDYNAMICFILTERSENABLED3',pic:''},{av:'AV106Pgmname',fld:'vPGMNAME',pic:'',hsh:true},{av:'AV31TFUsuCod',fld:'vTFUSUCOD',pic:''},{av:'AV32TFUsuCod_Sel',fld:'vTFUSUCOD_SEL',pic:''},{av:'AV35TFUsuNom',fld:'vTFUSUNOM',pic:''},{av:'AV36TFUsuNom_Sel',fld:'vTFUSUNOM_SEL',pic:''},{av:'AV67TFUsuEMAIL',fld:'vTFUSUEMAIL',pic:''},{av:'AV68TFUsuEMAIL_Sel',fld:'vTFUSUEMAIL_SEL',pic:''},{av:'AV93TFUsuSts_Sels',fld:'vTFUSUSTS_SELS',pic:''},{av:'AV100TFUsuVendDsc',fld:'vTFUSUVENDDSC',pic:''},{av:'AV101TFUsuVendDsc_Sel',fld:'vTFUSUVENDDSC_SEL',pic:''},{av:'AV102TFUsuTieDsc',fld:'vTFUSUTIEDSC',pic:''},{av:'AV103TFUsuTieDsc_Sel',fld:'vTFUSUTIEDSC_SEL',pic:''},{av:'AV13OrderedBy',fld:'vORDEREDBY',pic:'ZZZ9'},{av:'AV14OrderedDsc',fld:'vORDEREDDSC',pic:''},{av:'AV10GridState',fld:'vGRIDSTATE',pic:''},{av:'AV27DynamicFiltersIgnoreFirst',fld:'vDYNAMICFILTERSIGNOREFIRST',pic:''},{av:'AV26DynamicFiltersRemoving',fld:'vDYNAMICFILTERSREMOVING',pic:''},{av:'Ddo_grid_Activeeventkey',ctrl:'DDO_GRID',prop:'ActiveEventKey'},{av:'Ddo_grid_Selectedvalue_get',ctrl:'DDO_GRID',prop:'SelectedValue_get'},{av:'Ddo_grid_Filteredtext_get',ctrl:'DDO_GRID',prop:'FilteredText_get'},{av:'Ddo_grid_Selectedcolumn',ctrl:'DDO_GRID',prop:'SelectedColumn'}]");
         setEventMetadata("DDO_GRID.ONOPTIONCLICKED",",oparms:[{av:'AV13OrderedBy',fld:'vORDEREDBY',pic:'ZZZ9'},{av:'AV14OrderedDsc',fld:'vORDEREDDSC',pic:''},{av:'AV102TFUsuTieDsc',fld:'vTFUSUTIEDSC',pic:''},{av:'AV103TFUsuTieDsc_Sel',fld:'vTFUSUTIEDSC_SEL',pic:''},{av:'AV100TFUsuVendDsc',fld:'vTFUSUVENDDSC',pic:''},{av:'AV101TFUsuVendDsc_Sel',fld:'vTFUSUVENDDSC_SEL',pic:''},{av:'AV92TFUsuSts_SelsJson',fld:'vTFUSUSTS_SELSJSON',pic:''},{av:'AV93TFUsuSts_Sels',fld:'vTFUSUSTS_SELS',pic:''},{av:'AV67TFUsuEMAIL',fld:'vTFUSUEMAIL',pic:''},{av:'AV68TFUsuEMAIL_Sel',fld:'vTFUSUEMAIL_SEL',pic:''},{av:'AV35TFUsuNom',fld:'vTFUSUNOM',pic:''},{av:'AV36TFUsuNom_Sel',fld:'vTFUSUNOM_SEL',pic:''},{av:'AV31TFUsuCod',fld:'vTFUSUCOD',pic:''},{av:'AV32TFUsuCod_Sel',fld:'vTFUSUCOD_SEL',pic:''},{av:'Ddo_grid_Sortedstatus',ctrl:'DDO_GRID',prop:'SortedStatus'}]}");
         setEventMetadata("GRID.LOAD","{handler:'E260H2',iparms:[{av:'A348UsuCod',fld:'USUCOD',pic:'',hsh:true},{av:'A2041UsuVend',fld:'USUVEND',pic:'ZZZZZ9'},{av:'A2040UsuTieCod',fld:'USUTIECOD',pic:'ZZZZZ9'},{av:'cmbUsuSts'},{av:'A2039UsuSts',fld:'USUSTS',pic:'9'}]");
         setEventMetadata("GRID.LOAD",",oparms:[{av:'cmbavGridactions'},{av:'AV86GridActions',fld:'vGRIDACTIONS',pic:'ZZZ9'},{av:'edtUsuCod_Link',ctrl:'USUCOD',prop:'Link'},{av:'edtUsuNom_Link',ctrl:'USUNOM',prop:'Link'},{av:'edtUsuVendDsc_Link',ctrl:'USUVENDDSC',prop:'Link'},{av:'edtUsuTieDsc_Link',ctrl:'USUTIEDSC',prop:'Link'},{av:'edtUsuCod_Columnclass',ctrl:'USUCOD',prop:'Columnclass'},{av:'edtUsuNom_Columnclass',ctrl:'USUNOM',prop:'Columnclass'},{av:'edtUsuEMAIL_Columnclass',ctrl:'USUEMAIL',prop:'Columnclass'},{av:'cmbUsuSts'}]}");
         setEventMetadata("'ADDDYNAMICFILTERS1'","{handler:'E190H2',iparms:[{av:'GRID_nFirstRecordOnPage'},{av:'GRID_nEOF'},{av:'subGrid_Rows',ctrl:'GRID',prop:'Rows'},{av:'cmbavDynamicfiltersselector1'},{av:'AV15DynamicFiltersSelector1',fld:'vDYNAMICFILTERSSELECTOR1',pic:''},{av:'cmbavDynamicfiltersoperator1'},{av:'AV16DynamicFiltersOperator1',fld:'vDYNAMICFILTERSOPERATOR1',pic:'ZZZ9'},{av:'AV94UsuVendDsc1',fld:'vUSUVENDDSC1',pic:''},{av:'AV95UsuTieDsc1',fld:'vUSUTIEDSC1',pic:''},{av:'AV89UsuNom1',fld:'vUSUNOM1',pic:''},{av:'cmbavDynamicfiltersselector2'},{av:'AV19DynamicFiltersSelector2',fld:'vDYNAMICFILTERSSELECTOR2',pic:''},{av:'cmbavDynamicfiltersoperator2'},{av:'AV20DynamicFiltersOperator2',fld:'vDYNAMICFILTERSOPERATOR2',pic:'ZZZ9'},{av:'AV96UsuVendDsc2',fld:'vUSUVENDDSC2',pic:''},{av:'AV97UsuTieDsc2',fld:'vUSUTIEDSC2',pic:''},{av:'AV90UsuNom2',fld:'vUSUNOM2',pic:''},{av:'cmbavDynamicfiltersselector3'},{av:'AV23DynamicFiltersSelector3',fld:'vDYNAMICFILTERSSELECTOR3',pic:''},{av:'cmbavDynamicfiltersoperator3'},{av:'AV24DynamicFiltersOperator3',fld:'vDYNAMICFILTERSOPERATOR3',pic:'ZZZ9'},{av:'AV98UsuVendDsc3',fld:'vUSUVENDDSC3',pic:''},{av:'AV99UsuTieDsc3',fld:'vUSUTIEDSC3',pic:''},{av:'AV91UsuNom3',fld:'vUSUNOM3',pic:''},{av:'AV18DynamicFiltersEnabled2',fld:'vDYNAMICFILTERSENABLED2',pic:''},{av:'AV22DynamicFiltersEnabled3',fld:'vDYNAMICFILTERSENABLED3',pic:''},{av:'AV106Pgmname',fld:'vPGMNAME',pic:'',hsh:true},{av:'AV31TFUsuCod',fld:'vTFUSUCOD',pic:''},{av:'AV32TFUsuCod_Sel',fld:'vTFUSUCOD_SEL',pic:''},{av:'AV35TFUsuNom',fld:'vTFUSUNOM',pic:''},{av:'AV36TFUsuNom_Sel',fld:'vTFUSUNOM_SEL',pic:''},{av:'AV67TFUsuEMAIL',fld:'vTFUSUEMAIL',pic:''},{av:'AV68TFUsuEMAIL_Sel',fld:'vTFUSUEMAIL_SEL',pic:''},{av:'AV93TFUsuSts_Sels',fld:'vTFUSUSTS_SELS',pic:''},{av:'AV100TFUsuVendDsc',fld:'vTFUSUVENDDSC',pic:''},{av:'AV101TFUsuVendDsc_Sel',fld:'vTFUSUVENDDSC_SEL',pic:''},{av:'AV102TFUsuTieDsc',fld:'vTFUSUTIEDSC',pic:''},{av:'AV103TFUsuTieDsc_Sel',fld:'vTFUSUTIEDSC_SEL',pic:''},{av:'AV13OrderedBy',fld:'vORDEREDBY',pic:'ZZZ9'},{av:'AV14OrderedDsc',fld:'vORDEREDDSC',pic:''},{av:'AV10GridState',fld:'vGRIDSTATE',pic:''},{av:'AV27DynamicFiltersIgnoreFirst',fld:'vDYNAMICFILTERSIGNOREFIRST',pic:''},{av:'AV26DynamicFiltersRemoving',fld:'vDYNAMICFILTERSREMOVING',pic:''}]");
         setEventMetadata("'ADDDYNAMICFILTERS1'",",oparms:[{av:'AV18DynamicFiltersEnabled2',fld:'vDYNAMICFILTERSENABLED2',pic:''},{av:'imgAdddynamicfilters1_Visible',ctrl:'ADDDYNAMICFILTERS1',prop:'Visible'},{av:'imgRemovedynamicfilters1_Visible',ctrl:'REMOVEDYNAMICFILTERS1',prop:'Visible'},{av:'cmbavDynamicfiltersoperator1'},{av:'AV16DynamicFiltersOperator1',fld:'vDYNAMICFILTERSOPERATOR1',pic:'ZZZ9'},{av:'cmbavDynamicfiltersoperator2'},{av:'AV20DynamicFiltersOperator2',fld:'vDYNAMICFILTERSOPERATOR2',pic:'ZZZ9'},{av:'cmbavDynamicfiltersoperator3'},{av:'AV24DynamicFiltersOperator3',fld:'vDYNAMICFILTERSOPERATOR3',pic:'ZZZ9'},{av:'AV83GridCurrentPage',fld:'vGRIDCURRENTPAGE',pic:'ZZZZZZZZZ9'},{av:'AV84GridPageCount',fld:'vGRIDPAGECOUNT',pic:'ZZZZZZZZZ9'},{av:'AV85GridAppliedFilters',fld:'vGRIDAPPLIEDFILTERS',pic:''},{av:'edtUsuCod_Columnheaderclass',ctrl:'USUCOD',prop:'Columnheaderclass'},{av:'edtUsuNom_Columnheaderclass',ctrl:'USUNOM',prop:'Columnheaderclass'},{av:'edtUsuEMAIL_Columnheaderclass',ctrl:'USUEMAIL',prop:'Columnheaderclass'},{av:'cmbUsuSts'},{av:'AV10GridState',fld:'vGRIDSTATE',pic:''}]}");
         setEventMetadata("'REMOVEDYNAMICFILTERS1'","{handler:'E150H2',iparms:[{av:'GRID_nFirstRecordOnPage'},{av:'GRID_nEOF'},{av:'subGrid_Rows',ctrl:'GRID',prop:'Rows'},{av:'cmbavDynamicfiltersselector1'},{av:'AV15DynamicFiltersSelector1',fld:'vDYNAMICFILTERSSELECTOR1',pic:''},{av:'cmbavDynamicfiltersoperator1'},{av:'AV16DynamicFiltersOperator1',fld:'vDYNAMICFILTERSOPERATOR1',pic:'ZZZ9'},{av:'AV94UsuVendDsc1',fld:'vUSUVENDDSC1',pic:''},{av:'AV95UsuTieDsc1',fld:'vUSUTIEDSC1',pic:''},{av:'AV89UsuNom1',fld:'vUSUNOM1',pic:''},{av:'cmbavDynamicfiltersselector2'},{av:'AV19DynamicFiltersSelector2',fld:'vDYNAMICFILTERSSELECTOR2',pic:''},{av:'cmbavDynamicfiltersoperator2'},{av:'AV20DynamicFiltersOperator2',fld:'vDYNAMICFILTERSOPERATOR2',pic:'ZZZ9'},{av:'AV96UsuVendDsc2',fld:'vUSUVENDDSC2',pic:''},{av:'AV97UsuTieDsc2',fld:'vUSUTIEDSC2',pic:''},{av:'AV90UsuNom2',fld:'vUSUNOM2',pic:''},{av:'cmbavDynamicfiltersselector3'},{av:'AV23DynamicFiltersSelector3',fld:'vDYNAMICFILTERSSELECTOR3',pic:''},{av:'cmbavDynamicfiltersoperator3'},{av:'AV24DynamicFiltersOperator3',fld:'vDYNAMICFILTERSOPERATOR3',pic:'ZZZ9'},{av:'AV98UsuVendDsc3',fld:'vUSUVENDDSC3',pic:''},{av:'AV99UsuTieDsc3',fld:'vUSUTIEDSC3',pic:''},{av:'AV91UsuNom3',fld:'vUSUNOM3',pic:''},{av:'AV18DynamicFiltersEnabled2',fld:'vDYNAMICFILTERSENABLED2',pic:''},{av:'AV22DynamicFiltersEnabled3',fld:'vDYNAMICFILTERSENABLED3',pic:''},{av:'AV106Pgmname',fld:'vPGMNAME',pic:'',hsh:true},{av:'AV31TFUsuCod',fld:'vTFUSUCOD',pic:''},{av:'AV32TFUsuCod_Sel',fld:'vTFUSUCOD_SEL',pic:''},{av:'AV35TFUsuNom',fld:'vTFUSUNOM',pic:''},{av:'AV36TFUsuNom_Sel',fld:'vTFUSUNOM_SEL',pic:''},{av:'AV67TFUsuEMAIL',fld:'vTFUSUEMAIL',pic:''},{av:'AV68TFUsuEMAIL_Sel',fld:'vTFUSUEMAIL_SEL',pic:''},{av:'AV93TFUsuSts_Sels',fld:'vTFUSUSTS_SELS',pic:''},{av:'AV100TFUsuVendDsc',fld:'vTFUSUVENDDSC',pic:''},{av:'AV101TFUsuVendDsc_Sel',fld:'vTFUSUVENDDSC_SEL',pic:''},{av:'AV102TFUsuTieDsc',fld:'vTFUSUTIEDSC',pic:''},{av:'AV103TFUsuTieDsc_Sel',fld:'vTFUSUTIEDSC_SEL',pic:''},{av:'AV13OrderedBy',fld:'vORDEREDBY',pic:'ZZZ9'},{av:'AV14OrderedDsc',fld:'vORDEREDDSC',pic:''},{av:'AV10GridState',fld:'vGRIDSTATE',pic:''},{av:'AV27DynamicFiltersIgnoreFirst',fld:'vDYNAMICFILTERSIGNOREFIRST',pic:''},{av:'AV26DynamicFiltersRemoving',fld:'vDYNAMICFILTERSREMOVING',pic:''}]");
         setEventMetadata("'REMOVEDYNAMICFILTERS1'",",oparms:[{av:'AV26DynamicFiltersRemoving',fld:'vDYNAMICFILTERSREMOVING',pic:''},{av:'AV27DynamicFiltersIgnoreFirst',fld:'vDYNAMICFILTERSIGNOREFIRST',pic:''},{av:'AV10GridState',fld:'vGRIDSTATE',pic:''},{av:'AV18DynamicFiltersEnabled2',fld:'vDYNAMICFILTERSENABLED2',pic:''},{av:'cmbavDynamicfiltersselector2'},{av:'AV19DynamicFiltersSelector2',fld:'vDYNAMICFILTERSSELECTOR2',pic:''},{av:'cmbavDynamicfiltersoperator2'},{av:'AV20DynamicFiltersOperator2',fld:'vDYNAMICFILTERSOPERATOR2',pic:'ZZZ9'},{av:'AV96UsuVendDsc2',fld:'vUSUVENDDSC2',pic:''},{av:'AV22DynamicFiltersEnabled3',fld:'vDYNAMICFILTERSENABLED3',pic:''},{av:'cmbavDynamicfiltersselector3'},{av:'AV23DynamicFiltersSelector3',fld:'vDYNAMICFILTERSSELECTOR3',pic:''},{av:'cmbavDynamicfiltersoperator3'},{av:'AV24DynamicFiltersOperator3',fld:'vDYNAMICFILTERSOPERATOR3',pic:'ZZZ9'},{av:'AV98UsuVendDsc3',fld:'vUSUVENDDSC3',pic:''},{av:'imgAdddynamicfilters1_Visible',ctrl:'ADDDYNAMICFILTERS1',prop:'Visible'},{av:'imgRemovedynamicfilters1_Visible',ctrl:'REMOVEDYNAMICFILTERS1',prop:'Visible'},{av:'imgAdddynamicfilters2_Visible',ctrl:'ADDDYNAMICFILTERS2',prop:'Visible'},{av:'imgRemovedynamicfilters2_Visible',ctrl:'REMOVEDYNAMICFILTERS2',prop:'Visible'},{av:'cmbavDynamicfiltersselector1'},{av:'AV15DynamicFiltersSelector1',fld:'vDYNAMICFILTERSSELECTOR1',pic:''},{av:'cmbavDynamicfiltersoperator1'},{av:'AV16DynamicFiltersOperator1',fld:'vDYNAMICFILTERSOPERATOR1',pic:'ZZZ9'},{av:'AV94UsuVendDsc1',fld:'vUSUVENDDSC1',pic:''},{av:'AV95UsuTieDsc1',fld:'vUSUTIEDSC1',pic:''},{av:'AV89UsuNom1',fld:'vUSUNOM1',pic:''},{av:'lblJsdynamicfilters_Caption',ctrl:'JSDYNAMICFILTERS',prop:'Caption'},{av:'AV97UsuTieDsc2',fld:'vUSUTIEDSC2',pic:''},{av:'AV90UsuNom2',fld:'vUSUNOM2',pic:''},{av:'AV99UsuTieDsc3',fld:'vUSUTIEDSC3',pic:''},{av:'AV91UsuNom3',fld:'vUSUNOM3',pic:''},{av:'edtavUsuvenddsc2_Visible',ctrl:'vUSUVENDDSC2',prop:'Visible'},{av:'edtavUsutiedsc2_Visible',ctrl:'vUSUTIEDSC2',prop:'Visible'},{av:'edtavUsunom2_Visible',ctrl:'vUSUNOM2',prop:'Visible'},{av:'edtavUsuvenddsc3_Visible',ctrl:'vUSUVENDDSC3',prop:'Visible'},{av:'edtavUsutiedsc3_Visible',ctrl:'vUSUTIEDSC3',prop:'Visible'},{av:'edtavUsunom3_Visible',ctrl:'vUSUNOM3',prop:'Visible'},{av:'edtavUsuvenddsc1_Visible',ctrl:'vUSUVENDDSC1',prop:'Visible'},{av:'edtavUsutiedsc1_Visible',ctrl:'vUSUTIEDSC1',prop:'Visible'},{av:'edtavUsunom1_Visible',ctrl:'vUSUNOM1',prop:'Visible'},{av:'AV83GridCurrentPage',fld:'vGRIDCURRENTPAGE',pic:'ZZZZZZZZZ9'},{av:'AV84GridPageCount',fld:'vGRIDPAGECOUNT',pic:'ZZZZZZZZZ9'},{av:'AV85GridAppliedFilters',fld:'vGRIDAPPLIEDFILTERS',pic:''},{av:'edtUsuCod_Columnheaderclass',ctrl:'USUCOD',prop:'Columnheaderclass'},{av:'edtUsuNom_Columnheaderclass',ctrl:'USUNOM',prop:'Columnheaderclass'},{av:'edtUsuEMAIL_Columnheaderclass',ctrl:'USUEMAIL',prop:'Columnheaderclass'},{av:'cmbUsuSts'}]}");
         setEventMetadata("VDYNAMICFILTERSSELECTOR1.CLICK","{handler:'E200H2',iparms:[{av:'cmbavDynamicfiltersselector1'},{av:'AV15DynamicFiltersSelector1',fld:'vDYNAMICFILTERSSELECTOR1',pic:''}]");
         setEventMetadata("VDYNAMICFILTERSSELECTOR1.CLICK",",oparms:[{av:'cmbavDynamicfiltersoperator1'},{av:'AV16DynamicFiltersOperator1',fld:'vDYNAMICFILTERSOPERATOR1',pic:'ZZZ9'},{av:'edtavUsuvenddsc1_Visible',ctrl:'vUSUVENDDSC1',prop:'Visible'},{av:'edtavUsutiedsc1_Visible',ctrl:'vUSUTIEDSC1',prop:'Visible'},{av:'edtavUsunom1_Visible',ctrl:'vUSUNOM1',prop:'Visible'}]}");
         setEventMetadata("'ADDDYNAMICFILTERS2'","{handler:'E210H2',iparms:[{av:'GRID_nFirstRecordOnPage'},{av:'GRID_nEOF'},{av:'subGrid_Rows',ctrl:'GRID',prop:'Rows'},{av:'cmbavDynamicfiltersselector1'},{av:'AV15DynamicFiltersSelector1',fld:'vDYNAMICFILTERSSELECTOR1',pic:''},{av:'cmbavDynamicfiltersoperator1'},{av:'AV16DynamicFiltersOperator1',fld:'vDYNAMICFILTERSOPERATOR1',pic:'ZZZ9'},{av:'AV94UsuVendDsc1',fld:'vUSUVENDDSC1',pic:''},{av:'AV95UsuTieDsc1',fld:'vUSUTIEDSC1',pic:''},{av:'AV89UsuNom1',fld:'vUSUNOM1',pic:''},{av:'cmbavDynamicfiltersselector2'},{av:'AV19DynamicFiltersSelector2',fld:'vDYNAMICFILTERSSELECTOR2',pic:''},{av:'cmbavDynamicfiltersoperator2'},{av:'AV20DynamicFiltersOperator2',fld:'vDYNAMICFILTERSOPERATOR2',pic:'ZZZ9'},{av:'AV96UsuVendDsc2',fld:'vUSUVENDDSC2',pic:''},{av:'AV97UsuTieDsc2',fld:'vUSUTIEDSC2',pic:''},{av:'AV90UsuNom2',fld:'vUSUNOM2',pic:''},{av:'cmbavDynamicfiltersselector3'},{av:'AV23DynamicFiltersSelector3',fld:'vDYNAMICFILTERSSELECTOR3',pic:''},{av:'cmbavDynamicfiltersoperator3'},{av:'AV24DynamicFiltersOperator3',fld:'vDYNAMICFILTERSOPERATOR3',pic:'ZZZ9'},{av:'AV98UsuVendDsc3',fld:'vUSUVENDDSC3',pic:''},{av:'AV99UsuTieDsc3',fld:'vUSUTIEDSC3',pic:''},{av:'AV91UsuNom3',fld:'vUSUNOM3',pic:''},{av:'AV18DynamicFiltersEnabled2',fld:'vDYNAMICFILTERSENABLED2',pic:''},{av:'AV22DynamicFiltersEnabled3',fld:'vDYNAMICFILTERSENABLED3',pic:''},{av:'AV106Pgmname',fld:'vPGMNAME',pic:'',hsh:true},{av:'AV31TFUsuCod',fld:'vTFUSUCOD',pic:''},{av:'AV32TFUsuCod_Sel',fld:'vTFUSUCOD_SEL',pic:''},{av:'AV35TFUsuNom',fld:'vTFUSUNOM',pic:''},{av:'AV36TFUsuNom_Sel',fld:'vTFUSUNOM_SEL',pic:''},{av:'AV67TFUsuEMAIL',fld:'vTFUSUEMAIL',pic:''},{av:'AV68TFUsuEMAIL_Sel',fld:'vTFUSUEMAIL_SEL',pic:''},{av:'AV93TFUsuSts_Sels',fld:'vTFUSUSTS_SELS',pic:''},{av:'AV100TFUsuVendDsc',fld:'vTFUSUVENDDSC',pic:''},{av:'AV101TFUsuVendDsc_Sel',fld:'vTFUSUVENDDSC_SEL',pic:''},{av:'AV102TFUsuTieDsc',fld:'vTFUSUTIEDSC',pic:''},{av:'AV103TFUsuTieDsc_Sel',fld:'vTFUSUTIEDSC_SEL',pic:''},{av:'AV13OrderedBy',fld:'vORDEREDBY',pic:'ZZZ9'},{av:'AV14OrderedDsc',fld:'vORDEREDDSC',pic:''},{av:'AV10GridState',fld:'vGRIDSTATE',pic:''},{av:'AV27DynamicFiltersIgnoreFirst',fld:'vDYNAMICFILTERSIGNOREFIRST',pic:''},{av:'AV26DynamicFiltersRemoving',fld:'vDYNAMICFILTERSREMOVING',pic:''}]");
         setEventMetadata("'ADDDYNAMICFILTERS2'",",oparms:[{av:'AV22DynamicFiltersEnabled3',fld:'vDYNAMICFILTERSENABLED3',pic:''},{av:'imgAdddynamicfilters2_Visible',ctrl:'ADDDYNAMICFILTERS2',prop:'Visible'},{av:'imgRemovedynamicfilters2_Visible',ctrl:'REMOVEDYNAMICFILTERS2',prop:'Visible'},{av:'cmbavDynamicfiltersoperator1'},{av:'AV16DynamicFiltersOperator1',fld:'vDYNAMICFILTERSOPERATOR1',pic:'ZZZ9'},{av:'cmbavDynamicfiltersoperator2'},{av:'AV20DynamicFiltersOperator2',fld:'vDYNAMICFILTERSOPERATOR2',pic:'ZZZ9'},{av:'cmbavDynamicfiltersoperator3'},{av:'AV24DynamicFiltersOperator3',fld:'vDYNAMICFILTERSOPERATOR3',pic:'ZZZ9'},{av:'AV83GridCurrentPage',fld:'vGRIDCURRENTPAGE',pic:'ZZZZZZZZZ9'},{av:'AV84GridPageCount',fld:'vGRIDPAGECOUNT',pic:'ZZZZZZZZZ9'},{av:'AV85GridAppliedFilters',fld:'vGRIDAPPLIEDFILTERS',pic:''},{av:'edtUsuCod_Columnheaderclass',ctrl:'USUCOD',prop:'Columnheaderclass'},{av:'edtUsuNom_Columnheaderclass',ctrl:'USUNOM',prop:'Columnheaderclass'},{av:'edtUsuEMAIL_Columnheaderclass',ctrl:'USUEMAIL',prop:'Columnheaderclass'},{av:'cmbUsuSts'},{av:'AV10GridState',fld:'vGRIDSTATE',pic:''}]}");
         setEventMetadata("'REMOVEDYNAMICFILTERS2'","{handler:'E160H2',iparms:[{av:'GRID_nFirstRecordOnPage'},{av:'GRID_nEOF'},{av:'subGrid_Rows',ctrl:'GRID',prop:'Rows'},{av:'cmbavDynamicfiltersselector1'},{av:'AV15DynamicFiltersSelector1',fld:'vDYNAMICFILTERSSELECTOR1',pic:''},{av:'cmbavDynamicfiltersoperator1'},{av:'AV16DynamicFiltersOperator1',fld:'vDYNAMICFILTERSOPERATOR1',pic:'ZZZ9'},{av:'AV94UsuVendDsc1',fld:'vUSUVENDDSC1',pic:''},{av:'AV95UsuTieDsc1',fld:'vUSUTIEDSC1',pic:''},{av:'AV89UsuNom1',fld:'vUSUNOM1',pic:''},{av:'cmbavDynamicfiltersselector2'},{av:'AV19DynamicFiltersSelector2',fld:'vDYNAMICFILTERSSELECTOR2',pic:''},{av:'cmbavDynamicfiltersoperator2'},{av:'AV20DynamicFiltersOperator2',fld:'vDYNAMICFILTERSOPERATOR2',pic:'ZZZ9'},{av:'AV96UsuVendDsc2',fld:'vUSUVENDDSC2',pic:''},{av:'AV97UsuTieDsc2',fld:'vUSUTIEDSC2',pic:''},{av:'AV90UsuNom2',fld:'vUSUNOM2',pic:''},{av:'cmbavDynamicfiltersselector3'},{av:'AV23DynamicFiltersSelector3',fld:'vDYNAMICFILTERSSELECTOR3',pic:''},{av:'cmbavDynamicfiltersoperator3'},{av:'AV24DynamicFiltersOperator3',fld:'vDYNAMICFILTERSOPERATOR3',pic:'ZZZ9'},{av:'AV98UsuVendDsc3',fld:'vUSUVENDDSC3',pic:''},{av:'AV99UsuTieDsc3',fld:'vUSUTIEDSC3',pic:''},{av:'AV91UsuNom3',fld:'vUSUNOM3',pic:''},{av:'AV18DynamicFiltersEnabled2',fld:'vDYNAMICFILTERSENABLED2',pic:''},{av:'AV22DynamicFiltersEnabled3',fld:'vDYNAMICFILTERSENABLED3',pic:''},{av:'AV106Pgmname',fld:'vPGMNAME',pic:'',hsh:true},{av:'AV31TFUsuCod',fld:'vTFUSUCOD',pic:''},{av:'AV32TFUsuCod_Sel',fld:'vTFUSUCOD_SEL',pic:''},{av:'AV35TFUsuNom',fld:'vTFUSUNOM',pic:''},{av:'AV36TFUsuNom_Sel',fld:'vTFUSUNOM_SEL',pic:''},{av:'AV67TFUsuEMAIL',fld:'vTFUSUEMAIL',pic:''},{av:'AV68TFUsuEMAIL_Sel',fld:'vTFUSUEMAIL_SEL',pic:''},{av:'AV93TFUsuSts_Sels',fld:'vTFUSUSTS_SELS',pic:''},{av:'AV100TFUsuVendDsc',fld:'vTFUSUVENDDSC',pic:''},{av:'AV101TFUsuVendDsc_Sel',fld:'vTFUSUVENDDSC_SEL',pic:''},{av:'AV102TFUsuTieDsc',fld:'vTFUSUTIEDSC',pic:''},{av:'AV103TFUsuTieDsc_Sel',fld:'vTFUSUTIEDSC_SEL',pic:''},{av:'AV13OrderedBy',fld:'vORDEREDBY',pic:'ZZZ9'},{av:'AV14OrderedDsc',fld:'vORDEREDDSC',pic:''},{av:'AV10GridState',fld:'vGRIDSTATE',pic:''},{av:'AV27DynamicFiltersIgnoreFirst',fld:'vDYNAMICFILTERSIGNOREFIRST',pic:''},{av:'AV26DynamicFiltersRemoving',fld:'vDYNAMICFILTERSREMOVING',pic:''}]");
         setEventMetadata("'REMOVEDYNAMICFILTERS2'",",oparms:[{av:'AV26DynamicFiltersRemoving',fld:'vDYNAMICFILTERSREMOVING',pic:''},{av:'AV18DynamicFiltersEnabled2',fld:'vDYNAMICFILTERSENABLED2',pic:''},{av:'AV10GridState',fld:'vGRIDSTATE',pic:''},{av:'cmbavDynamicfiltersselector2'},{av:'AV19DynamicFiltersSelector2',fld:'vDYNAMICFILTERSSELECTOR2',pic:''},{av:'cmbavDynamicfiltersoperator2'},{av:'AV20DynamicFiltersOperator2',fld:'vDYNAMICFILTERSOPERATOR2',pic:'ZZZ9'},{av:'AV96UsuVendDsc2',fld:'vUSUVENDDSC2',pic:''},{av:'AV22DynamicFiltersEnabled3',fld:'vDYNAMICFILTERSENABLED3',pic:''},{av:'cmbavDynamicfiltersselector3'},{av:'AV23DynamicFiltersSelector3',fld:'vDYNAMICFILTERSSELECTOR3',pic:''},{av:'cmbavDynamicfiltersoperator3'},{av:'AV24DynamicFiltersOperator3',fld:'vDYNAMICFILTERSOPERATOR3',pic:'ZZZ9'},{av:'AV98UsuVendDsc3',fld:'vUSUVENDDSC3',pic:''},{av:'imgAdddynamicfilters1_Visible',ctrl:'ADDDYNAMICFILTERS1',prop:'Visible'},{av:'imgRemovedynamicfilters1_Visible',ctrl:'REMOVEDYNAMICFILTERS1',prop:'Visible'},{av:'imgAdddynamicfilters2_Visible',ctrl:'ADDDYNAMICFILTERS2',prop:'Visible'},{av:'imgRemovedynamicfilters2_Visible',ctrl:'REMOVEDYNAMICFILTERS2',prop:'Visible'},{av:'cmbavDynamicfiltersselector1'},{av:'AV15DynamicFiltersSelector1',fld:'vDYNAMICFILTERSSELECTOR1',pic:''},{av:'cmbavDynamicfiltersoperator1'},{av:'AV16DynamicFiltersOperator1',fld:'vDYNAMICFILTERSOPERATOR1',pic:'ZZZ9'},{av:'AV94UsuVendDsc1',fld:'vUSUVENDDSC1',pic:''},{av:'AV95UsuTieDsc1',fld:'vUSUTIEDSC1',pic:''},{av:'AV89UsuNom1',fld:'vUSUNOM1',pic:''},{av:'lblJsdynamicfilters_Caption',ctrl:'JSDYNAMICFILTERS',prop:'Caption'},{av:'AV97UsuTieDsc2',fld:'vUSUTIEDSC2',pic:''},{av:'AV90UsuNom2',fld:'vUSUNOM2',pic:''},{av:'AV99UsuTieDsc3',fld:'vUSUTIEDSC3',pic:''},{av:'AV91UsuNom3',fld:'vUSUNOM3',pic:''},{av:'edtavUsuvenddsc2_Visible',ctrl:'vUSUVENDDSC2',prop:'Visible'},{av:'edtavUsutiedsc2_Visible',ctrl:'vUSUTIEDSC2',prop:'Visible'},{av:'edtavUsunom2_Visible',ctrl:'vUSUNOM2',prop:'Visible'},{av:'edtavUsuvenddsc3_Visible',ctrl:'vUSUVENDDSC3',prop:'Visible'},{av:'edtavUsutiedsc3_Visible',ctrl:'vUSUTIEDSC3',prop:'Visible'},{av:'edtavUsunom3_Visible',ctrl:'vUSUNOM3',prop:'Visible'},{av:'edtavUsuvenddsc1_Visible',ctrl:'vUSUVENDDSC1',prop:'Visible'},{av:'edtavUsutiedsc1_Visible',ctrl:'vUSUTIEDSC1',prop:'Visible'},{av:'edtavUsunom1_Visible',ctrl:'vUSUNOM1',prop:'Visible'},{av:'AV83GridCurrentPage',fld:'vGRIDCURRENTPAGE',pic:'ZZZZZZZZZ9'},{av:'AV84GridPageCount',fld:'vGRIDPAGECOUNT',pic:'ZZZZZZZZZ9'},{av:'AV85GridAppliedFilters',fld:'vGRIDAPPLIEDFILTERS',pic:''},{av:'edtUsuCod_Columnheaderclass',ctrl:'USUCOD',prop:'Columnheaderclass'},{av:'edtUsuNom_Columnheaderclass',ctrl:'USUNOM',prop:'Columnheaderclass'},{av:'edtUsuEMAIL_Columnheaderclass',ctrl:'USUEMAIL',prop:'Columnheaderclass'},{av:'cmbUsuSts'}]}");
         setEventMetadata("VDYNAMICFILTERSSELECTOR2.CLICK","{handler:'E220H2',iparms:[{av:'cmbavDynamicfiltersselector2'},{av:'AV19DynamicFiltersSelector2',fld:'vDYNAMICFILTERSSELECTOR2',pic:''}]");
         setEventMetadata("VDYNAMICFILTERSSELECTOR2.CLICK",",oparms:[{av:'cmbavDynamicfiltersoperator2'},{av:'AV20DynamicFiltersOperator2',fld:'vDYNAMICFILTERSOPERATOR2',pic:'ZZZ9'},{av:'edtavUsuvenddsc2_Visible',ctrl:'vUSUVENDDSC2',prop:'Visible'},{av:'edtavUsutiedsc2_Visible',ctrl:'vUSUTIEDSC2',prop:'Visible'},{av:'edtavUsunom2_Visible',ctrl:'vUSUNOM2',prop:'Visible'}]}");
         setEventMetadata("'REMOVEDYNAMICFILTERS3'","{handler:'E170H2',iparms:[{av:'GRID_nFirstRecordOnPage'},{av:'GRID_nEOF'},{av:'subGrid_Rows',ctrl:'GRID',prop:'Rows'},{av:'cmbavDynamicfiltersselector1'},{av:'AV15DynamicFiltersSelector1',fld:'vDYNAMICFILTERSSELECTOR1',pic:''},{av:'cmbavDynamicfiltersoperator1'},{av:'AV16DynamicFiltersOperator1',fld:'vDYNAMICFILTERSOPERATOR1',pic:'ZZZ9'},{av:'AV94UsuVendDsc1',fld:'vUSUVENDDSC1',pic:''},{av:'AV95UsuTieDsc1',fld:'vUSUTIEDSC1',pic:''},{av:'AV89UsuNom1',fld:'vUSUNOM1',pic:''},{av:'cmbavDynamicfiltersselector2'},{av:'AV19DynamicFiltersSelector2',fld:'vDYNAMICFILTERSSELECTOR2',pic:''},{av:'cmbavDynamicfiltersoperator2'},{av:'AV20DynamicFiltersOperator2',fld:'vDYNAMICFILTERSOPERATOR2',pic:'ZZZ9'},{av:'AV96UsuVendDsc2',fld:'vUSUVENDDSC2',pic:''},{av:'AV97UsuTieDsc2',fld:'vUSUTIEDSC2',pic:''},{av:'AV90UsuNom2',fld:'vUSUNOM2',pic:''},{av:'cmbavDynamicfiltersselector3'},{av:'AV23DynamicFiltersSelector3',fld:'vDYNAMICFILTERSSELECTOR3',pic:''},{av:'cmbavDynamicfiltersoperator3'},{av:'AV24DynamicFiltersOperator3',fld:'vDYNAMICFILTERSOPERATOR3',pic:'ZZZ9'},{av:'AV98UsuVendDsc3',fld:'vUSUVENDDSC3',pic:''},{av:'AV99UsuTieDsc3',fld:'vUSUTIEDSC3',pic:''},{av:'AV91UsuNom3',fld:'vUSUNOM3',pic:''},{av:'AV18DynamicFiltersEnabled2',fld:'vDYNAMICFILTERSENABLED2',pic:''},{av:'AV22DynamicFiltersEnabled3',fld:'vDYNAMICFILTERSENABLED3',pic:''},{av:'AV106Pgmname',fld:'vPGMNAME',pic:'',hsh:true},{av:'AV31TFUsuCod',fld:'vTFUSUCOD',pic:''},{av:'AV32TFUsuCod_Sel',fld:'vTFUSUCOD_SEL',pic:''},{av:'AV35TFUsuNom',fld:'vTFUSUNOM',pic:''},{av:'AV36TFUsuNom_Sel',fld:'vTFUSUNOM_SEL',pic:''},{av:'AV67TFUsuEMAIL',fld:'vTFUSUEMAIL',pic:''},{av:'AV68TFUsuEMAIL_Sel',fld:'vTFUSUEMAIL_SEL',pic:''},{av:'AV93TFUsuSts_Sels',fld:'vTFUSUSTS_SELS',pic:''},{av:'AV100TFUsuVendDsc',fld:'vTFUSUVENDDSC',pic:''},{av:'AV101TFUsuVendDsc_Sel',fld:'vTFUSUVENDDSC_SEL',pic:''},{av:'AV102TFUsuTieDsc',fld:'vTFUSUTIEDSC',pic:''},{av:'AV103TFUsuTieDsc_Sel',fld:'vTFUSUTIEDSC_SEL',pic:''},{av:'AV13OrderedBy',fld:'vORDEREDBY',pic:'ZZZ9'},{av:'AV14OrderedDsc',fld:'vORDEREDDSC',pic:''},{av:'AV10GridState',fld:'vGRIDSTATE',pic:''},{av:'AV27DynamicFiltersIgnoreFirst',fld:'vDYNAMICFILTERSIGNOREFIRST',pic:''},{av:'AV26DynamicFiltersRemoving',fld:'vDYNAMICFILTERSREMOVING',pic:''}]");
         setEventMetadata("'REMOVEDYNAMICFILTERS3'",",oparms:[{av:'AV26DynamicFiltersRemoving',fld:'vDYNAMICFILTERSREMOVING',pic:''},{av:'AV22DynamicFiltersEnabled3',fld:'vDYNAMICFILTERSENABLED3',pic:''},{av:'AV10GridState',fld:'vGRIDSTATE',pic:''},{av:'AV18DynamicFiltersEnabled2',fld:'vDYNAMICFILTERSENABLED2',pic:''},{av:'cmbavDynamicfiltersselector2'},{av:'AV19DynamicFiltersSelector2',fld:'vDYNAMICFILTERSSELECTOR2',pic:''},{av:'cmbavDynamicfiltersoperator2'},{av:'AV20DynamicFiltersOperator2',fld:'vDYNAMICFILTERSOPERATOR2',pic:'ZZZ9'},{av:'AV96UsuVendDsc2',fld:'vUSUVENDDSC2',pic:''},{av:'cmbavDynamicfiltersselector3'},{av:'AV23DynamicFiltersSelector3',fld:'vDYNAMICFILTERSSELECTOR3',pic:''},{av:'cmbavDynamicfiltersoperator3'},{av:'AV24DynamicFiltersOperator3',fld:'vDYNAMICFILTERSOPERATOR3',pic:'ZZZ9'},{av:'AV98UsuVendDsc3',fld:'vUSUVENDDSC3',pic:''},{av:'imgAdddynamicfilters1_Visible',ctrl:'ADDDYNAMICFILTERS1',prop:'Visible'},{av:'imgRemovedynamicfilters1_Visible',ctrl:'REMOVEDYNAMICFILTERS1',prop:'Visible'},{av:'imgAdddynamicfilters2_Visible',ctrl:'ADDDYNAMICFILTERS2',prop:'Visible'},{av:'imgRemovedynamicfilters2_Visible',ctrl:'REMOVEDYNAMICFILTERS2',prop:'Visible'},{av:'cmbavDynamicfiltersselector1'},{av:'AV15DynamicFiltersSelector1',fld:'vDYNAMICFILTERSSELECTOR1',pic:''},{av:'cmbavDynamicfiltersoperator1'},{av:'AV16DynamicFiltersOperator1',fld:'vDYNAMICFILTERSOPERATOR1',pic:'ZZZ9'},{av:'AV94UsuVendDsc1',fld:'vUSUVENDDSC1',pic:''},{av:'AV95UsuTieDsc1',fld:'vUSUTIEDSC1',pic:''},{av:'AV89UsuNom1',fld:'vUSUNOM1',pic:''},{av:'lblJsdynamicfilters_Caption',ctrl:'JSDYNAMICFILTERS',prop:'Caption'},{av:'AV97UsuTieDsc2',fld:'vUSUTIEDSC2',pic:''},{av:'AV90UsuNom2',fld:'vUSUNOM2',pic:''},{av:'AV99UsuTieDsc3',fld:'vUSUTIEDSC3',pic:''},{av:'AV91UsuNom3',fld:'vUSUNOM3',pic:''},{av:'edtavUsuvenddsc2_Visible',ctrl:'vUSUVENDDSC2',prop:'Visible'},{av:'edtavUsutiedsc2_Visible',ctrl:'vUSUTIEDSC2',prop:'Visible'},{av:'edtavUsunom2_Visible',ctrl:'vUSUNOM2',prop:'Visible'},{av:'edtavUsuvenddsc3_Visible',ctrl:'vUSUVENDDSC3',prop:'Visible'},{av:'edtavUsutiedsc3_Visible',ctrl:'vUSUTIEDSC3',prop:'Visible'},{av:'edtavUsunom3_Visible',ctrl:'vUSUNOM3',prop:'Visible'},{av:'edtavUsuvenddsc1_Visible',ctrl:'vUSUVENDDSC1',prop:'Visible'},{av:'edtavUsutiedsc1_Visible',ctrl:'vUSUTIEDSC1',prop:'Visible'},{av:'edtavUsunom1_Visible',ctrl:'vUSUNOM1',prop:'Visible'},{av:'AV83GridCurrentPage',fld:'vGRIDCURRENTPAGE',pic:'ZZZZZZZZZ9'},{av:'AV84GridPageCount',fld:'vGRIDPAGECOUNT',pic:'ZZZZZZZZZ9'},{av:'AV85GridAppliedFilters',fld:'vGRIDAPPLIEDFILTERS',pic:''},{av:'edtUsuCod_Columnheaderclass',ctrl:'USUCOD',prop:'Columnheaderclass'},{av:'edtUsuNom_Columnheaderclass',ctrl:'USUNOM',prop:'Columnheaderclass'},{av:'edtUsuEMAIL_Columnheaderclass',ctrl:'USUEMAIL',prop:'Columnheaderclass'},{av:'cmbUsuSts'}]}");
         setEventMetadata("VDYNAMICFILTERSSELECTOR3.CLICK","{handler:'E230H2',iparms:[{av:'cmbavDynamicfiltersselector3'},{av:'AV23DynamicFiltersSelector3',fld:'vDYNAMICFILTERSSELECTOR3',pic:''}]");
         setEventMetadata("VDYNAMICFILTERSSELECTOR3.CLICK",",oparms:[{av:'cmbavDynamicfiltersoperator3'},{av:'AV24DynamicFiltersOperator3',fld:'vDYNAMICFILTERSOPERATOR3',pic:'ZZZ9'},{av:'edtavUsuvenddsc3_Visible',ctrl:'vUSUVENDDSC3',prop:'Visible'},{av:'edtavUsutiedsc3_Visible',ctrl:'vUSUTIEDSC3',prop:'Visible'},{av:'edtavUsunom3_Visible',ctrl:'vUSUNOM3',prop:'Visible'}]}");
         setEventMetadata("VGRIDACTIONS.CLICK","{handler:'E270H2',iparms:[{av:'cmbavGridactions'},{av:'AV86GridActions',fld:'vGRIDACTIONS',pic:'ZZZ9'},{av:'A348UsuCod',fld:'USUCOD',pic:'',hsh:true}]");
         setEventMetadata("VGRIDACTIONS.CLICK",",oparms:[{av:'cmbavGridactions'},{av:'AV86GridActions',fld:'vGRIDACTIONS',pic:'ZZZ9'}]}");
         setEventMetadata("'DOINSERT'","{handler:'E180H2',iparms:[{av:'A348UsuCod',fld:'USUCOD',pic:'',hsh:true}]");
         setEventMetadata("'DOINSERT'",",oparms:[]}");
         setEventMetadata("DDO_AGEXPORT.ONOPTIONCLICKED","{handler:'E130H2',iparms:[{av:'Ddo_agexport_Activeeventkey',ctrl:'DDO_AGEXPORT',prop:'ActiveEventKey'},{av:'AV106Pgmname',fld:'vPGMNAME',pic:'',hsh:true},{av:'AV93TFUsuSts_Sels',fld:'vTFUSUSTS_SELS',pic:''},{av:'AV32TFUsuCod_Sel',fld:'vTFUSUCOD_SEL',pic:''},{av:'AV36TFUsuNom_Sel',fld:'vTFUSUNOM_SEL',pic:''},{av:'AV68TFUsuEMAIL_Sel',fld:'vTFUSUEMAIL_SEL',pic:''},{av:'AV92TFUsuSts_SelsJson',fld:'vTFUSUSTS_SELSJSON',pic:''},{av:'AV101TFUsuVendDsc_Sel',fld:'vTFUSUVENDDSC_SEL',pic:''},{av:'AV103TFUsuTieDsc_Sel',fld:'vTFUSUTIEDSC_SEL',pic:''},{av:'AV31TFUsuCod',fld:'vTFUSUCOD',pic:''},{av:'AV35TFUsuNom',fld:'vTFUSUNOM',pic:''},{av:'AV67TFUsuEMAIL',fld:'vTFUSUEMAIL',pic:''},{av:'AV100TFUsuVendDsc',fld:'vTFUSUVENDDSC',pic:''},{av:'AV102TFUsuTieDsc',fld:'vTFUSUTIEDSC',pic:''},{av:'AV13OrderedBy',fld:'vORDEREDBY',pic:'ZZZ9'},{av:'AV14OrderedDsc',fld:'vORDEREDDSC',pic:''},{av:'AV10GridState',fld:'vGRIDSTATE',pic:''},{av:'AV26DynamicFiltersRemoving',fld:'vDYNAMICFILTERSREMOVING',pic:''},{av:'cmbavDynamicfiltersselector1'},{av:'AV15DynamicFiltersSelector1',fld:'vDYNAMICFILTERSSELECTOR1',pic:''},{av:'cmbavDynamicfiltersselector2'},{av:'AV19DynamicFiltersSelector2',fld:'vDYNAMICFILTERSSELECTOR2',pic:''},{av:'cmbavDynamicfiltersselector3'},{av:'AV23DynamicFiltersSelector3',fld:'vDYNAMICFILTERSSELECTOR3',pic:''}]");
         setEventMetadata("DDO_AGEXPORT.ONOPTIONCLICKED",",oparms:[{av:'Innewwindow1_Target',ctrl:'INNEWWINDOW1',prop:'Target'},{av:'Innewwindow1_Height',ctrl:'INNEWWINDOW1',prop:'Height'},{av:'Innewwindow1_Width',ctrl:'INNEWWINDOW1',prop:'Width'},{av:'AV10GridState',fld:'vGRIDSTATE',pic:''},{av:'AV13OrderedBy',fld:'vORDEREDBY',pic:'ZZZ9'},{av:'AV14OrderedDsc',fld:'vORDEREDDSC',pic:''},{av:'AV103TFUsuTieDsc_Sel',fld:'vTFUSUTIEDSC_SEL',pic:''},{av:'AV102TFUsuTieDsc',fld:'vTFUSUTIEDSC',pic:''},{av:'AV101TFUsuVendDsc_Sel',fld:'vTFUSUVENDDSC_SEL',pic:''},{av:'AV100TFUsuVendDsc',fld:'vTFUSUVENDDSC',pic:''},{av:'AV92TFUsuSts_SelsJson',fld:'vTFUSUSTS_SELSJSON',pic:''},{av:'AV93TFUsuSts_Sels',fld:'vTFUSUSTS_SELS',pic:''},{av:'AV68TFUsuEMAIL_Sel',fld:'vTFUSUEMAIL_SEL',pic:''},{av:'AV67TFUsuEMAIL',fld:'vTFUSUEMAIL',pic:''},{av:'AV36TFUsuNom_Sel',fld:'vTFUSUNOM_SEL',pic:''},{av:'AV35TFUsuNom',fld:'vTFUSUNOM',pic:''},{av:'AV32TFUsuCod_Sel',fld:'vTFUSUCOD_SEL',pic:''},{av:'AV31TFUsuCod',fld:'vTFUSUCOD',pic:''},{av:'Ddo_grid_Selectedvalue_set',ctrl:'DDO_GRID',prop:'SelectedValue_set'},{av:'Ddo_grid_Filteredtext_set',ctrl:'DDO_GRID',prop:'FilteredText_set'},{av:'subGrid_Rows',ctrl:'GRID',prop:'Rows'},{av:'GRID_nFirstRecordOnPage'},{av:'GRID_nEOF'},{av:'cmbavDynamicfiltersselector1'},{av:'AV15DynamicFiltersSelector1',fld:'vDYNAMICFILTERSSELECTOR1',pic:''},{av:'cmbavDynamicfiltersoperator1'},{av:'AV16DynamicFiltersOperator1',fld:'vDYNAMICFILTERSOPERATOR1',pic:'ZZZ9'},{av:'AV94UsuVendDsc1',fld:'vUSUVENDDSC1',pic:''},{av:'AV95UsuTieDsc1',fld:'vUSUTIEDSC1',pic:''},{av:'AV89UsuNom1',fld:'vUSUNOM1',pic:''},{av:'cmbavDynamicfiltersselector2'},{av:'AV19DynamicFiltersSelector2',fld:'vDYNAMICFILTERSSELECTOR2',pic:''},{av:'cmbavDynamicfiltersoperator2'},{av:'AV20DynamicFiltersOperator2',fld:'vDYNAMICFILTERSOPERATOR2',pic:'ZZZ9'},{av:'AV96UsuVendDsc2',fld:'vUSUVENDDSC2',pic:''},{av:'AV97UsuTieDsc2',fld:'vUSUTIEDSC2',pic:''},{av:'AV90UsuNom2',fld:'vUSUNOM2',pic:''},{av:'cmbavDynamicfiltersselector3'},{av:'AV23DynamicFiltersSelector3',fld:'vDYNAMICFILTERSSELECTOR3',pic:''},{av:'cmbavDynamicfiltersoperator3'},{av:'AV24DynamicFiltersOperator3',fld:'vDYNAMICFILTERSOPERATOR3',pic:'ZZZ9'},{av:'AV98UsuVendDsc3',fld:'vUSUVENDDSC3',pic:''},{av:'AV99UsuTieDsc3',fld:'vUSUTIEDSC3',pic:''},{av:'AV91UsuNom3',fld:'vUSUNOM3',pic:''},{av:'AV18DynamicFiltersEnabled2',fld:'vDYNAMICFILTERSENABLED2',pic:''},{av:'AV22DynamicFiltersEnabled3',fld:'vDYNAMICFILTERSENABLED3',pic:''},{av:'AV106Pgmname',fld:'vPGMNAME',pic:'',hsh:true},{av:'AV27DynamicFiltersIgnoreFirst',fld:'vDYNAMICFILTERSIGNOREFIRST',pic:''},{av:'AV26DynamicFiltersRemoving',fld:'vDYNAMICFILTERSREMOVING',pic:''},{av:'Ddo_grid_Sortedstatus',ctrl:'DDO_GRID',prop:'SortedStatus'},{av:'imgAdddynamicfilters1_Visible',ctrl:'ADDDYNAMICFILTERS1',prop:'Visible'},{av:'imgRemovedynamicfilters1_Visible',ctrl:'REMOVEDYNAMICFILTERS1',prop:'Visible'},{av:'imgAdddynamicfilters2_Visible',ctrl:'ADDDYNAMICFILTERS2',prop:'Visible'},{av:'imgRemovedynamicfilters2_Visible',ctrl:'REMOVEDYNAMICFILTERS2',prop:'Visible'},{av:'lblJsdynamicfilters_Caption',ctrl:'JSDYNAMICFILTERS',prop:'Caption'},{av:'edtavUsuvenddsc1_Visible',ctrl:'vUSUVENDDSC1',prop:'Visible'},{av:'edtavUsutiedsc1_Visible',ctrl:'vUSUTIEDSC1',prop:'Visible'},{av:'edtavUsunom1_Visible',ctrl:'vUSUNOM1',prop:'Visible'},{av:'edtavUsuvenddsc2_Visible',ctrl:'vUSUVENDDSC2',prop:'Visible'},{av:'edtavUsutiedsc2_Visible',ctrl:'vUSUTIEDSC2',prop:'Visible'},{av:'edtavUsunom2_Visible',ctrl:'vUSUNOM2',prop:'Visible'},{av:'edtavUsuvenddsc3_Visible',ctrl:'vUSUVENDDSC3',prop:'Visible'},{av:'edtavUsutiedsc3_Visible',ctrl:'vUSUTIEDSC3',prop:'Visible'},{av:'edtavUsunom3_Visible',ctrl:'vUSUNOM3',prop:'Visible'}]}");
         setEventMetadata("NULL","{handler:'Valid_Usutiedsc',iparms:[]");
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
         AV94UsuVendDsc1 = "";
         AV95UsuTieDsc1 = "";
         AV89UsuNom1 = "";
         AV19DynamicFiltersSelector2 = "";
         AV96UsuVendDsc2 = "";
         AV97UsuTieDsc2 = "";
         AV90UsuNom2 = "";
         AV23DynamicFiltersSelector3 = "";
         AV98UsuVendDsc3 = "";
         AV99UsuTieDsc3 = "";
         AV91UsuNom3 = "";
         AV106Pgmname = "";
         AV31TFUsuCod = "";
         AV32TFUsuCod_Sel = "";
         AV35TFUsuNom = "";
         AV36TFUsuNom_Sel = "";
         AV67TFUsuEMAIL = "";
         AV68TFUsuEMAIL_Sel = "";
         AV93TFUsuSts_Sels = new GxSimpleCollection<short>();
         AV100TFUsuVendDsc = "";
         AV101TFUsuVendDsc_Sel = "";
         AV102TFUsuTieDsc = "";
         AV103TFUsuTieDsc_Sel = "";
         AV10GridState = new GeneXus.Programs.wwpbaseobjects.SdtWWPGridState(context);
         sDynURL = "";
         FormProcess = "";
         bodyStyle = "";
         GXKey = "";
         AV85GridAppliedFilters = "";
         AV87AGExportData = new GXBaseCollection<GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTDropDownOptionsData_Item>( context, "Item", "");
         AV81DDO_TitleSettingsIcons = new GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTDropDownOptionsTitleSettingsIcons(context);
         AV92TFUsuSts_SelsJson = "";
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
         A348UsuCod = "";
         A2019UsuNom = "";
         A2014UsuEMAIL = "";
         A2097UsuVendDsc = "";
         A2096UsuTieDsc = "";
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
         AV130Seguridad_usuarioswwds_24_tfususts_sels = new GxSimpleCollection<short>();
         scmdbuf = "";
         lV109Seguridad_usuarioswwds_3_usuvenddsc1 = "";
         lV110Seguridad_usuarioswwds_4_usutiedsc1 = "";
         lV111Seguridad_usuarioswwds_5_usunom1 = "";
         lV115Seguridad_usuarioswwds_9_usuvenddsc2 = "";
         lV116Seguridad_usuarioswwds_10_usutiedsc2 = "";
         lV117Seguridad_usuarioswwds_11_usunom2 = "";
         lV121Seguridad_usuarioswwds_15_usuvenddsc3 = "";
         lV122Seguridad_usuarioswwds_16_usutiedsc3 = "";
         lV123Seguridad_usuarioswwds_17_usunom3 = "";
         lV124Seguridad_usuarioswwds_18_tfusucod = "";
         lV126Seguridad_usuarioswwds_20_tfusunom = "";
         lV128Seguridad_usuarioswwds_22_tfusuemail = "";
         lV131Seguridad_usuarioswwds_25_tfusuvenddsc = "";
         lV133Seguridad_usuarioswwds_27_tfusutiedsc = "";
         AV107Seguridad_usuarioswwds_1_dynamicfiltersselector1 = "";
         AV109Seguridad_usuarioswwds_3_usuvenddsc1 = "";
         AV110Seguridad_usuarioswwds_4_usutiedsc1 = "";
         AV111Seguridad_usuarioswwds_5_usunom1 = "";
         AV113Seguridad_usuarioswwds_7_dynamicfiltersselector2 = "";
         AV115Seguridad_usuarioswwds_9_usuvenddsc2 = "";
         AV116Seguridad_usuarioswwds_10_usutiedsc2 = "";
         AV117Seguridad_usuarioswwds_11_usunom2 = "";
         AV119Seguridad_usuarioswwds_13_dynamicfiltersselector3 = "";
         AV121Seguridad_usuarioswwds_15_usuvenddsc3 = "";
         AV122Seguridad_usuarioswwds_16_usutiedsc3 = "";
         AV123Seguridad_usuarioswwds_17_usunom3 = "";
         AV125Seguridad_usuarioswwds_19_tfusucod_sel = "";
         AV124Seguridad_usuarioswwds_18_tfusucod = "";
         AV127Seguridad_usuarioswwds_21_tfusunom_sel = "";
         AV126Seguridad_usuarioswwds_20_tfusunom = "";
         AV129Seguridad_usuarioswwds_23_tfusuemail_sel = "";
         AV128Seguridad_usuarioswwds_22_tfusuemail = "";
         AV132Seguridad_usuarioswwds_26_tfusuvenddsc_sel = "";
         AV131Seguridad_usuarioswwds_25_tfusuvenddsc = "";
         AV134Seguridad_usuarioswwds_28_tfusutiedsc_sel = "";
         AV133Seguridad_usuarioswwds_27_tfusutiedsc = "";
         H000H2_A2041UsuVend = new int[1] ;
         H000H2_A2040UsuTieCod = new int[1] ;
         H000H2_A2096UsuTieDsc = new string[] {""} ;
         H000H2_A2097UsuVendDsc = new string[] {""} ;
         H000H2_A2039UsuSts = new short[1] ;
         H000H2_A2014UsuEMAIL = new string[] {""} ;
         H000H2_A2019UsuNom = new string[] {""} ;
         H000H2_A348UsuCod = new string[] {""} ;
         H000H3_AGRID_nRecordCount = new long[1] ;
         imgAdddynamicfilters1_Jsonclick = "";
         imgRemovedynamicfilters1_Jsonclick = "";
         imgAdddynamicfilters2_Jsonclick = "";
         imgRemovedynamicfilters2_Jsonclick = "";
         imgRemovedynamicfilters3_Jsonclick = "";
         AV88AGExportDataItem = new GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTDropDownOptionsData_Item(context);
         GXt_SdtDVB_SDTDropDownOptionsTitleSettingsIcons1 = new GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTDropDownOptionsTitleSettingsIcons(context);
         AV6WWPContext = new GeneXus.Programs.wwpbaseobjects.SdtWWPContext(context);
         GXEncryptionTmp = "";
         GridRow = new GXWebRow();
         AV30Session = context.GetSession();
         AV11GridStateFilterValue = new GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue(context);
         GXt_char6 = "";
         GXt_char5 = "";
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
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.seguridad.usuariosww__default(),
            new Object[][] {
                new Object[] {
               H000H2_A2041UsuVend, H000H2_A2040UsuTieCod, H000H2_A2096UsuTieDsc, H000H2_A2097UsuVendDsc, H000H2_A2039UsuSts, H000H2_A2014UsuEMAIL, H000H2_A2019UsuNom, H000H2_A348UsuCod
               }
               , new Object[] {
               H000H3_AGRID_nRecordCount
               }
            }
         );
         AV106Pgmname = "Seguridad.UsuariosWW";
         /* GeneXus formulas. */
         AV106Pgmname = "Seguridad.UsuariosWW";
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
      private short AV86GridActions ;
      private short A2039UsuSts ;
      private short subGrid_Allowselection ;
      private short subGrid_Allowhovering ;
      private short subGrid_Allowcollapsing ;
      private short subGrid_Collapsed ;
      private short nDonePA ;
      private short AV108Seguridad_usuarioswwds_2_dynamicfiltersoperator1 ;
      private short AV114Seguridad_usuarioswwds_8_dynamicfiltersoperator2 ;
      private short AV120Seguridad_usuarioswwds_14_dynamicfiltersoperator3 ;
      private short nGXWrapped ;
      private short subGrid_Backstyle ;
      private int subGrid_Rows ;
      private int Gridpaginationbar_Rowsperpageselectedvalue ;
      private int nRC_GXsfl_119 ;
      private int nGXsfl_119_idx=1 ;
      private int A2041UsuVend ;
      private int A2040UsuTieCod ;
      private int Gridpaginationbar_Pagestoshow ;
      private int subGrid_Titlebackcolor ;
      private int subGrid_Allbackcolor ;
      private int subGrid_Selectedindex ;
      private int subGrid_Selectioncolor ;
      private int subGrid_Hoveringcolor ;
      private int subGrid_Islastpage ;
      private int GXPagingFrom2 ;
      private int GXPagingTo2 ;
      private int AV130Seguridad_usuarioswwds_24_tfususts_sels_Count ;
      private int AV82PageToGo ;
      private int imgAdddynamicfilters1_Visible ;
      private int imgRemovedynamicfilters1_Visible ;
      private int imgAdddynamicfilters2_Visible ;
      private int imgRemovedynamicfilters2_Visible ;
      private int edtavUsuvenddsc1_Visible ;
      private int edtavUsutiedsc1_Visible ;
      private int edtavUsunom1_Visible ;
      private int edtavUsuvenddsc2_Visible ;
      private int edtavUsutiedsc2_Visible ;
      private int edtavUsunom2_Visible ;
      private int edtavUsuvenddsc3_Visible ;
      private int edtavUsutiedsc3_Visible ;
      private int edtavUsunom3_Visible ;
      private int AV135GXV1 ;
      private int edtavUsuvenddsc3_Enabled ;
      private int edtavUsutiedsc3_Enabled ;
      private int edtavUsunom3_Enabled ;
      private int edtavUsuvenddsc2_Enabled ;
      private int edtavUsutiedsc2_Enabled ;
      private int edtavUsunom2_Enabled ;
      private int edtavUsuvenddsc1_Enabled ;
      private int edtavUsutiedsc1_Enabled ;
      private int edtavUsunom1_Enabled ;
      private int idxLst ;
      private int subGrid_Backcolor ;
      private long GRID_nFirstRecordOnPage ;
      private long AV83GridCurrentPage ;
      private long AV84GridPageCount ;
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
      private string AV94UsuVendDsc1 ;
      private string AV95UsuTieDsc1 ;
      private string AV89UsuNom1 ;
      private string AV96UsuVendDsc2 ;
      private string AV97UsuTieDsc2 ;
      private string AV90UsuNom2 ;
      private string AV98UsuVendDsc3 ;
      private string AV99UsuTieDsc3 ;
      private string AV91UsuNom3 ;
      private string AV106Pgmname ;
      private string AV31TFUsuCod ;
      private string AV32TFUsuCod_Sel ;
      private string AV35TFUsuNom ;
      private string AV36TFUsuNom_Sel ;
      private string AV100TFUsuVendDsc ;
      private string AV101TFUsuVendDsc_Sel ;
      private string AV102TFUsuTieDsc ;
      private string AV103TFUsuTieDsc_Sel ;
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
      private string A348UsuCod ;
      private string edtUsuCod_Columnclass ;
      private string edtUsuCod_Columnheaderclass ;
      private string edtUsuCod_Link ;
      private string A2019UsuNom ;
      private string edtUsuNom_Columnclass ;
      private string edtUsuNom_Columnheaderclass ;
      private string edtUsuNom_Link ;
      private string edtUsuEMAIL_Columnclass ;
      private string edtUsuEMAIL_Columnheaderclass ;
      private string cmbUsuSts_Columnclass ;
      private string cmbUsuSts_Columnheaderclass ;
      private string A2097UsuVendDsc ;
      private string edtUsuVendDsc_Link ;
      private string A2096UsuTieDsc ;
      private string edtUsuTieDsc_Link ;
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
      private string edtUsuCod_Internalname ;
      private string edtUsuNom_Internalname ;
      private string edtUsuEMAIL_Internalname ;
      private string cmbUsuSts_Internalname ;
      private string edtUsuVendDsc_Internalname ;
      private string edtUsuTieDsc_Internalname ;
      private string cmbavDynamicfiltersselector1_Internalname ;
      private string cmbavDynamicfiltersoperator1_Internalname ;
      private string cmbavDynamicfiltersselector2_Internalname ;
      private string cmbavDynamicfiltersoperator2_Internalname ;
      private string cmbavDynamicfiltersselector3_Internalname ;
      private string cmbavDynamicfiltersoperator3_Internalname ;
      private string scmdbuf ;
      private string lV109Seguridad_usuarioswwds_3_usuvenddsc1 ;
      private string lV110Seguridad_usuarioswwds_4_usutiedsc1 ;
      private string lV111Seguridad_usuarioswwds_5_usunom1 ;
      private string lV115Seguridad_usuarioswwds_9_usuvenddsc2 ;
      private string lV116Seguridad_usuarioswwds_10_usutiedsc2 ;
      private string lV117Seguridad_usuarioswwds_11_usunom2 ;
      private string lV121Seguridad_usuarioswwds_15_usuvenddsc3 ;
      private string lV122Seguridad_usuarioswwds_16_usutiedsc3 ;
      private string lV123Seguridad_usuarioswwds_17_usunom3 ;
      private string lV124Seguridad_usuarioswwds_18_tfusucod ;
      private string lV126Seguridad_usuarioswwds_20_tfusunom ;
      private string lV131Seguridad_usuarioswwds_25_tfusuvenddsc ;
      private string lV133Seguridad_usuarioswwds_27_tfusutiedsc ;
      private string AV109Seguridad_usuarioswwds_3_usuvenddsc1 ;
      private string AV110Seguridad_usuarioswwds_4_usutiedsc1 ;
      private string AV111Seguridad_usuarioswwds_5_usunom1 ;
      private string AV115Seguridad_usuarioswwds_9_usuvenddsc2 ;
      private string AV116Seguridad_usuarioswwds_10_usutiedsc2 ;
      private string AV117Seguridad_usuarioswwds_11_usunom2 ;
      private string AV121Seguridad_usuarioswwds_15_usuvenddsc3 ;
      private string AV122Seguridad_usuarioswwds_16_usutiedsc3 ;
      private string AV123Seguridad_usuarioswwds_17_usunom3 ;
      private string AV125Seguridad_usuarioswwds_19_tfusucod_sel ;
      private string AV124Seguridad_usuarioswwds_18_tfusucod ;
      private string AV127Seguridad_usuarioswwds_21_tfusunom_sel ;
      private string AV126Seguridad_usuarioswwds_20_tfusunom ;
      private string AV132Seguridad_usuarioswwds_26_tfusuvenddsc_sel ;
      private string AV131Seguridad_usuarioswwds_25_tfusuvenddsc ;
      private string AV134Seguridad_usuarioswwds_28_tfusutiedsc_sel ;
      private string AV133Seguridad_usuarioswwds_27_tfusutiedsc ;
      private string edtavUsuvenddsc1_Internalname ;
      private string edtavUsutiedsc1_Internalname ;
      private string edtavUsunom1_Internalname ;
      private string edtavUsuvenddsc2_Internalname ;
      private string edtavUsutiedsc2_Internalname ;
      private string edtavUsunom2_Internalname ;
      private string edtavUsuvenddsc3_Internalname ;
      private string edtavUsutiedsc3_Internalname ;
      private string edtavUsunom3_Internalname ;
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
      private string GXt_char6 ;
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
      private string cellFilter_usuvenddsc3_cell_Internalname ;
      private string edtavUsuvenddsc3_Jsonclick ;
      private string cellFilter_usutiedsc3_cell_Internalname ;
      private string edtavUsutiedsc3_Jsonclick ;
      private string cellFilter_usunom3_cell_Internalname ;
      private string edtavUsunom3_Jsonclick ;
      private string cellDynamicfilters_removefilter3_cell_Internalname ;
      private string sImgUrl ;
      private string tblTablemergeddynamicfilters2_Internalname ;
      private string cmbavDynamicfiltersoperator2_Jsonclick ;
      private string cellFilter_usuvenddsc2_cell_Internalname ;
      private string edtavUsuvenddsc2_Jsonclick ;
      private string cellFilter_usutiedsc2_cell_Internalname ;
      private string edtavUsutiedsc2_Jsonclick ;
      private string cellFilter_usunom2_cell_Internalname ;
      private string edtavUsunom2_Jsonclick ;
      private string cellDynamicfilters_addfilter2_cell_Internalname ;
      private string cellDynamicfilters_removefilter2_cell_Internalname ;
      private string tblTablemergeddynamicfilters1_Internalname ;
      private string cmbavDynamicfiltersoperator1_Jsonclick ;
      private string cellFilter_usuvenddsc1_cell_Internalname ;
      private string edtavUsuvenddsc1_Jsonclick ;
      private string cellFilter_usutiedsc1_cell_Internalname ;
      private string edtavUsutiedsc1_Jsonclick ;
      private string cellFilter_usunom1_cell_Internalname ;
      private string edtavUsunom1_Jsonclick ;
      private string cellDynamicfilters_addfilter1_cell_Internalname ;
      private string cellDynamicfilters_removefilter1_cell_Internalname ;
      private string sGXsfl_119_fel_idx="0001" ;
      private string GXCCtl ;
      private string cmbavGridactions_Jsonclick ;
      private string ROClassString ;
      private string edtUsuCod_Jsonclick ;
      private string edtUsuNom_Jsonclick ;
      private string edtUsuEMAIL_Jsonclick ;
      private string cmbUsuSts_Jsonclick ;
      private string edtUsuVendDsc_Jsonclick ;
      private string edtUsuTieDsc_Jsonclick ;
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
      private bool bGXsfl_119_Refreshing=false ;
      private bool gxdyncontrolsrefreshing ;
      private bool AV112Seguridad_usuarioswwds_6_dynamicfiltersenabled2 ;
      private bool AV118Seguridad_usuarioswwds_12_dynamicfiltersenabled3 ;
      private bool returnInSub ;
      private bool gx_refresh_fired ;
      private string AV92TFUsuSts_SelsJson ;
      private string AV15DynamicFiltersSelector1 ;
      private string AV19DynamicFiltersSelector2 ;
      private string AV23DynamicFiltersSelector3 ;
      private string AV67TFUsuEMAIL ;
      private string AV68TFUsuEMAIL_Sel ;
      private string AV85GridAppliedFilters ;
      private string A2014UsuEMAIL ;
      private string lV128Seguridad_usuarioswwds_22_tfusuemail ;
      private string AV107Seguridad_usuarioswwds_1_dynamicfiltersselector1 ;
      private string AV113Seguridad_usuarioswwds_7_dynamicfiltersselector2 ;
      private string AV119Seguridad_usuarioswwds_13_dynamicfiltersselector3 ;
      private string AV129Seguridad_usuarioswwds_23_tfusuemail_sel ;
      private string AV128Seguridad_usuarioswwds_22_tfusuemail ;
      private string AV28ExcelFilename ;
      private string AV29ErrorMessage ;
      private GxSimpleCollection<short> AV93TFUsuSts_Sels ;
      private GxSimpleCollection<short> AV130Seguridad_usuarioswwds_24_tfususts_sels ;
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
      private GXCombobox cmbUsuSts ;
      private IDataStoreProvider pr_default ;
      private int[] H000H2_A2041UsuVend ;
      private int[] H000H2_A2040UsuTieCod ;
      private string[] H000H2_A2096UsuTieDsc ;
      private string[] H000H2_A2097UsuVendDsc ;
      private short[] H000H2_A2039UsuSts ;
      private string[] H000H2_A2014UsuEMAIL ;
      private string[] H000H2_A2019UsuNom ;
      private string[] H000H2_A348UsuCod ;
      private long[] H000H3_AGRID_nRecordCount ;
      private msglist BackMsgLst ;
      private msglist LclMsgLst ;
      private GxHttpRequest AV7HTTPRequest ;
      private GXBaseCollection<GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTDropDownOptionsData_Item> AV87AGExportData ;
      private GXWebForm Form ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPContext AV6WWPContext ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPTransactionContext AV8TrnContext ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPGridState AV10GridState ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue AV11GridStateFilterValue ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter AV12GridStateDynamicFilter ;
      private GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTDropDownOptionsTitleSettingsIcons AV81DDO_TitleSettingsIcons ;
      private GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTDropDownOptionsTitleSettingsIcons GXt_SdtDVB_SDTDropDownOptionsTitleSettingsIcons1 ;
      private GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTDropDownOptionsData_Item AV88AGExportDataItem ;
   }

   public class usuariosww__default : DataStoreHelperBase, IDataStoreHelper
   {
      protected Object[] conditional_H000H2( IGxContext context ,
                                             short A2039UsuSts ,
                                             GxSimpleCollection<short> AV130Seguridad_usuarioswwds_24_tfususts_sels ,
                                             string AV107Seguridad_usuarioswwds_1_dynamicfiltersselector1 ,
                                             short AV108Seguridad_usuarioswwds_2_dynamicfiltersoperator1 ,
                                             string AV109Seguridad_usuarioswwds_3_usuvenddsc1 ,
                                             string AV110Seguridad_usuarioswwds_4_usutiedsc1 ,
                                             string AV111Seguridad_usuarioswwds_5_usunom1 ,
                                             bool AV112Seguridad_usuarioswwds_6_dynamicfiltersenabled2 ,
                                             string AV113Seguridad_usuarioswwds_7_dynamicfiltersselector2 ,
                                             short AV114Seguridad_usuarioswwds_8_dynamicfiltersoperator2 ,
                                             string AV115Seguridad_usuarioswwds_9_usuvenddsc2 ,
                                             string AV116Seguridad_usuarioswwds_10_usutiedsc2 ,
                                             string AV117Seguridad_usuarioswwds_11_usunom2 ,
                                             bool AV118Seguridad_usuarioswwds_12_dynamicfiltersenabled3 ,
                                             string AV119Seguridad_usuarioswwds_13_dynamicfiltersselector3 ,
                                             short AV120Seguridad_usuarioswwds_14_dynamicfiltersoperator3 ,
                                             string AV121Seguridad_usuarioswwds_15_usuvenddsc3 ,
                                             string AV122Seguridad_usuarioswwds_16_usutiedsc3 ,
                                             string AV123Seguridad_usuarioswwds_17_usunom3 ,
                                             string AV125Seguridad_usuarioswwds_19_tfusucod_sel ,
                                             string AV124Seguridad_usuarioswwds_18_tfusucod ,
                                             string AV127Seguridad_usuarioswwds_21_tfusunom_sel ,
                                             string AV126Seguridad_usuarioswwds_20_tfusunom ,
                                             string AV129Seguridad_usuarioswwds_23_tfusuemail_sel ,
                                             string AV128Seguridad_usuarioswwds_22_tfusuemail ,
                                             int AV130Seguridad_usuarioswwds_24_tfususts_sels_Count ,
                                             string AV132Seguridad_usuarioswwds_26_tfusuvenddsc_sel ,
                                             string AV131Seguridad_usuarioswwds_25_tfusuvenddsc ,
                                             string AV134Seguridad_usuarioswwds_28_tfusutiedsc_sel ,
                                             string AV133Seguridad_usuarioswwds_27_tfusutiedsc ,
                                             string A2097UsuVendDsc ,
                                             string A2096UsuTieDsc ,
                                             string A2019UsuNom ,
                                             string A348UsuCod ,
                                             string A2014UsuEMAIL ,
                                             short AV13OrderedBy ,
                                             bool AV14OrderedDsc )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int7 = new short[31];
         Object[] GXv_Object8 = new Object[2];
         string sSelectString;
         string sFromString;
         string sOrderString;
         sSelectString = " T1.[UsuVend] AS UsuVend, T1.[UsuTieCod] AS UsuTieCod, T3.[TieDsc] AS UsuTieDsc, T2.[VenDsc] AS UsuVendDsc, T1.[UsuSts], T1.[UsuEMAIL], T1.[UsuNom], T1.[UsuCod]";
         sFromString = " FROM (([SGUSUARIOS] T1 INNER JOIN [CVENDEDORES] T2 ON T2.[VenCod] = T1.[UsuVend]) INNER JOIN [SGTIENDAS] T3 ON T3.[TieCod] = T1.[UsuTieCod])";
         sOrderString = "";
         if ( ( StringUtil.StrCmp(AV107Seguridad_usuarioswwds_1_dynamicfiltersselector1, "USUVENDDSC") == 0 ) && ( AV108Seguridad_usuarioswwds_2_dynamicfiltersoperator1 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV109Seguridad_usuarioswwds_3_usuvenddsc1)) ) )
         {
            AddWhere(sWhereString, "(T2.[VenDsc] like @lV109Seguridad_usuarioswwds_3_usuvenddsc1)");
         }
         else
         {
            GXv_int7[0] = 1;
         }
         if ( ( StringUtil.StrCmp(AV107Seguridad_usuarioswwds_1_dynamicfiltersselector1, "USUVENDDSC") == 0 ) && ( AV108Seguridad_usuarioswwds_2_dynamicfiltersoperator1 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV109Seguridad_usuarioswwds_3_usuvenddsc1)) ) )
         {
            AddWhere(sWhereString, "(T2.[VenDsc] like '%' + @lV109Seguridad_usuarioswwds_3_usuvenddsc1)");
         }
         else
         {
            GXv_int7[1] = 1;
         }
         if ( ( StringUtil.StrCmp(AV107Seguridad_usuarioswwds_1_dynamicfiltersselector1, "USUTIEDSC") == 0 ) && ( AV108Seguridad_usuarioswwds_2_dynamicfiltersoperator1 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV110Seguridad_usuarioswwds_4_usutiedsc1)) ) )
         {
            AddWhere(sWhereString, "(T3.[TieDsc] like @lV110Seguridad_usuarioswwds_4_usutiedsc1)");
         }
         else
         {
            GXv_int7[2] = 1;
         }
         if ( ( StringUtil.StrCmp(AV107Seguridad_usuarioswwds_1_dynamicfiltersselector1, "USUTIEDSC") == 0 ) && ( AV108Seguridad_usuarioswwds_2_dynamicfiltersoperator1 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV110Seguridad_usuarioswwds_4_usutiedsc1)) ) )
         {
            AddWhere(sWhereString, "(T3.[TieDsc] like '%' + @lV110Seguridad_usuarioswwds_4_usutiedsc1)");
         }
         else
         {
            GXv_int7[3] = 1;
         }
         if ( ( StringUtil.StrCmp(AV107Seguridad_usuarioswwds_1_dynamicfiltersselector1, "USUNOM") == 0 ) && ( AV108Seguridad_usuarioswwds_2_dynamicfiltersoperator1 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV111Seguridad_usuarioswwds_5_usunom1)) ) )
         {
            AddWhere(sWhereString, "(T1.[UsuNom] like @lV111Seguridad_usuarioswwds_5_usunom1)");
         }
         else
         {
            GXv_int7[4] = 1;
         }
         if ( ( StringUtil.StrCmp(AV107Seguridad_usuarioswwds_1_dynamicfiltersselector1, "USUNOM") == 0 ) && ( AV108Seguridad_usuarioswwds_2_dynamicfiltersoperator1 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV111Seguridad_usuarioswwds_5_usunom1)) ) )
         {
            AddWhere(sWhereString, "(T1.[UsuNom] like '%' + @lV111Seguridad_usuarioswwds_5_usunom1)");
         }
         else
         {
            GXv_int7[5] = 1;
         }
         if ( AV112Seguridad_usuarioswwds_6_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV113Seguridad_usuarioswwds_7_dynamicfiltersselector2, "USUVENDDSC") == 0 ) && ( AV114Seguridad_usuarioswwds_8_dynamicfiltersoperator2 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV115Seguridad_usuarioswwds_9_usuvenddsc2)) ) )
         {
            AddWhere(sWhereString, "(T2.[VenDsc] like @lV115Seguridad_usuarioswwds_9_usuvenddsc2)");
         }
         else
         {
            GXv_int7[6] = 1;
         }
         if ( AV112Seguridad_usuarioswwds_6_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV113Seguridad_usuarioswwds_7_dynamicfiltersselector2, "USUVENDDSC") == 0 ) && ( AV114Seguridad_usuarioswwds_8_dynamicfiltersoperator2 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV115Seguridad_usuarioswwds_9_usuvenddsc2)) ) )
         {
            AddWhere(sWhereString, "(T2.[VenDsc] like '%' + @lV115Seguridad_usuarioswwds_9_usuvenddsc2)");
         }
         else
         {
            GXv_int7[7] = 1;
         }
         if ( AV112Seguridad_usuarioswwds_6_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV113Seguridad_usuarioswwds_7_dynamicfiltersselector2, "USUTIEDSC") == 0 ) && ( AV114Seguridad_usuarioswwds_8_dynamicfiltersoperator2 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV116Seguridad_usuarioswwds_10_usutiedsc2)) ) )
         {
            AddWhere(sWhereString, "(T3.[TieDsc] like @lV116Seguridad_usuarioswwds_10_usutiedsc2)");
         }
         else
         {
            GXv_int7[8] = 1;
         }
         if ( AV112Seguridad_usuarioswwds_6_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV113Seguridad_usuarioswwds_7_dynamicfiltersselector2, "USUTIEDSC") == 0 ) && ( AV114Seguridad_usuarioswwds_8_dynamicfiltersoperator2 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV116Seguridad_usuarioswwds_10_usutiedsc2)) ) )
         {
            AddWhere(sWhereString, "(T3.[TieDsc] like '%' + @lV116Seguridad_usuarioswwds_10_usutiedsc2)");
         }
         else
         {
            GXv_int7[9] = 1;
         }
         if ( AV112Seguridad_usuarioswwds_6_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV113Seguridad_usuarioswwds_7_dynamicfiltersselector2, "USUNOM") == 0 ) && ( AV114Seguridad_usuarioswwds_8_dynamicfiltersoperator2 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV117Seguridad_usuarioswwds_11_usunom2)) ) )
         {
            AddWhere(sWhereString, "(T1.[UsuNom] like @lV117Seguridad_usuarioswwds_11_usunom2)");
         }
         else
         {
            GXv_int7[10] = 1;
         }
         if ( AV112Seguridad_usuarioswwds_6_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV113Seguridad_usuarioswwds_7_dynamicfiltersselector2, "USUNOM") == 0 ) && ( AV114Seguridad_usuarioswwds_8_dynamicfiltersoperator2 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV117Seguridad_usuarioswwds_11_usunom2)) ) )
         {
            AddWhere(sWhereString, "(T1.[UsuNom] like '%' + @lV117Seguridad_usuarioswwds_11_usunom2)");
         }
         else
         {
            GXv_int7[11] = 1;
         }
         if ( AV118Seguridad_usuarioswwds_12_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV119Seguridad_usuarioswwds_13_dynamicfiltersselector3, "USUVENDDSC") == 0 ) && ( AV120Seguridad_usuarioswwds_14_dynamicfiltersoperator3 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV121Seguridad_usuarioswwds_15_usuvenddsc3)) ) )
         {
            AddWhere(sWhereString, "(T2.[VenDsc] like @lV121Seguridad_usuarioswwds_15_usuvenddsc3)");
         }
         else
         {
            GXv_int7[12] = 1;
         }
         if ( AV118Seguridad_usuarioswwds_12_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV119Seguridad_usuarioswwds_13_dynamicfiltersselector3, "USUVENDDSC") == 0 ) && ( AV120Seguridad_usuarioswwds_14_dynamicfiltersoperator3 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV121Seguridad_usuarioswwds_15_usuvenddsc3)) ) )
         {
            AddWhere(sWhereString, "(T2.[VenDsc] like '%' + @lV121Seguridad_usuarioswwds_15_usuvenddsc3)");
         }
         else
         {
            GXv_int7[13] = 1;
         }
         if ( AV118Seguridad_usuarioswwds_12_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV119Seguridad_usuarioswwds_13_dynamicfiltersselector3, "USUTIEDSC") == 0 ) && ( AV120Seguridad_usuarioswwds_14_dynamicfiltersoperator3 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV122Seguridad_usuarioswwds_16_usutiedsc3)) ) )
         {
            AddWhere(sWhereString, "(T3.[TieDsc] like @lV122Seguridad_usuarioswwds_16_usutiedsc3)");
         }
         else
         {
            GXv_int7[14] = 1;
         }
         if ( AV118Seguridad_usuarioswwds_12_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV119Seguridad_usuarioswwds_13_dynamicfiltersselector3, "USUTIEDSC") == 0 ) && ( AV120Seguridad_usuarioswwds_14_dynamicfiltersoperator3 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV122Seguridad_usuarioswwds_16_usutiedsc3)) ) )
         {
            AddWhere(sWhereString, "(T3.[TieDsc] like '%' + @lV122Seguridad_usuarioswwds_16_usutiedsc3)");
         }
         else
         {
            GXv_int7[15] = 1;
         }
         if ( AV118Seguridad_usuarioswwds_12_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV119Seguridad_usuarioswwds_13_dynamicfiltersselector3, "USUNOM") == 0 ) && ( AV120Seguridad_usuarioswwds_14_dynamicfiltersoperator3 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV123Seguridad_usuarioswwds_17_usunom3)) ) )
         {
            AddWhere(sWhereString, "(T1.[UsuNom] like @lV123Seguridad_usuarioswwds_17_usunom3)");
         }
         else
         {
            GXv_int7[16] = 1;
         }
         if ( AV118Seguridad_usuarioswwds_12_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV119Seguridad_usuarioswwds_13_dynamicfiltersselector3, "USUNOM") == 0 ) && ( AV120Seguridad_usuarioswwds_14_dynamicfiltersoperator3 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV123Seguridad_usuarioswwds_17_usunom3)) ) )
         {
            AddWhere(sWhereString, "(T1.[UsuNom] like '%' + @lV123Seguridad_usuarioswwds_17_usunom3)");
         }
         else
         {
            GXv_int7[17] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV125Seguridad_usuarioswwds_19_tfusucod_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV124Seguridad_usuarioswwds_18_tfusucod)) ) )
         {
            AddWhere(sWhereString, "(T1.[UsuCod] like @lV124Seguridad_usuarioswwds_18_tfusucod)");
         }
         else
         {
            GXv_int7[18] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV125Seguridad_usuarioswwds_19_tfusucod_sel)) )
         {
            AddWhere(sWhereString, "(T1.[UsuCod] = @AV125Seguridad_usuarioswwds_19_tfusucod_sel)");
         }
         else
         {
            GXv_int7[19] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV127Seguridad_usuarioswwds_21_tfusunom_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV126Seguridad_usuarioswwds_20_tfusunom)) ) )
         {
            AddWhere(sWhereString, "(T1.[UsuNom] like @lV126Seguridad_usuarioswwds_20_tfusunom)");
         }
         else
         {
            GXv_int7[20] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV127Seguridad_usuarioswwds_21_tfusunom_sel)) )
         {
            AddWhere(sWhereString, "(T1.[UsuNom] = @AV127Seguridad_usuarioswwds_21_tfusunom_sel)");
         }
         else
         {
            GXv_int7[21] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV129Seguridad_usuarioswwds_23_tfusuemail_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV128Seguridad_usuarioswwds_22_tfusuemail)) ) )
         {
            AddWhere(sWhereString, "(T1.[UsuEMAIL] like @lV128Seguridad_usuarioswwds_22_tfusuemail)");
         }
         else
         {
            GXv_int7[22] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV129Seguridad_usuarioswwds_23_tfusuemail_sel)) )
         {
            AddWhere(sWhereString, "(T1.[UsuEMAIL] = @AV129Seguridad_usuarioswwds_23_tfusuemail_sel)");
         }
         else
         {
            GXv_int7[23] = 1;
         }
         if ( AV130Seguridad_usuarioswwds_24_tfususts_sels_Count > 0 )
         {
            AddWhere(sWhereString, "("+new GxDbmsUtils( new GxSqlServer()).ValueList(AV130Seguridad_usuarioswwds_24_tfususts_sels, "T1.[UsuSts] IN (", ")")+")");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV132Seguridad_usuarioswwds_26_tfusuvenddsc_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV131Seguridad_usuarioswwds_25_tfusuvenddsc)) ) )
         {
            AddWhere(sWhereString, "(T2.[VenDsc] like @lV131Seguridad_usuarioswwds_25_tfusuvenddsc)");
         }
         else
         {
            GXv_int7[24] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV132Seguridad_usuarioswwds_26_tfusuvenddsc_sel)) )
         {
            AddWhere(sWhereString, "(T2.[VenDsc] = @AV132Seguridad_usuarioswwds_26_tfusuvenddsc_sel)");
         }
         else
         {
            GXv_int7[25] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV134Seguridad_usuarioswwds_28_tfusutiedsc_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV133Seguridad_usuarioswwds_27_tfusutiedsc)) ) )
         {
            AddWhere(sWhereString, "(T3.[TieDsc] like @lV133Seguridad_usuarioswwds_27_tfusutiedsc)");
         }
         else
         {
            GXv_int7[26] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV134Seguridad_usuarioswwds_28_tfusutiedsc_sel)) )
         {
            AddWhere(sWhereString, "(T3.[TieDsc] = @AV134Seguridad_usuarioswwds_28_tfusutiedsc_sel)");
         }
         else
         {
            GXv_int7[27] = 1;
         }
         if ( ( AV13OrderedBy == 1 ) && ! AV14OrderedDsc )
         {
            sOrderString += " ORDER BY T1.[UsuCod]";
         }
         else if ( ( AV13OrderedBy == 1 ) && ( AV14OrderedDsc ) )
         {
            sOrderString += " ORDER BY T1.[UsuCod] DESC";
         }
         else if ( ( AV13OrderedBy == 2 ) && ! AV14OrderedDsc )
         {
            sOrderString += " ORDER BY T1.[UsuNom]";
         }
         else if ( ( AV13OrderedBy == 2 ) && ( AV14OrderedDsc ) )
         {
            sOrderString += " ORDER BY T1.[UsuNom] DESC";
         }
         else if ( ( AV13OrderedBy == 3 ) && ! AV14OrderedDsc )
         {
            sOrderString += " ORDER BY T1.[UsuEMAIL]";
         }
         else if ( ( AV13OrderedBy == 3 ) && ( AV14OrderedDsc ) )
         {
            sOrderString += " ORDER BY T1.[UsuEMAIL] DESC";
         }
         else if ( ( AV13OrderedBy == 4 ) && ! AV14OrderedDsc )
         {
            sOrderString += " ORDER BY T1.[UsuSts]";
         }
         else if ( ( AV13OrderedBy == 4 ) && ( AV14OrderedDsc ) )
         {
            sOrderString += " ORDER BY T1.[UsuSts] DESC";
         }
         else if ( ( AV13OrderedBy == 5 ) && ! AV14OrderedDsc )
         {
            sOrderString += " ORDER BY T2.[VenDsc]";
         }
         else if ( ( AV13OrderedBy == 5 ) && ( AV14OrderedDsc ) )
         {
            sOrderString += " ORDER BY T2.[VenDsc] DESC";
         }
         else if ( ( AV13OrderedBy == 6 ) && ! AV14OrderedDsc )
         {
            sOrderString += " ORDER BY T3.[TieDsc]";
         }
         else if ( ( AV13OrderedBy == 6 ) && ( AV14OrderedDsc ) )
         {
            sOrderString += " ORDER BY T3.[TieDsc] DESC";
         }
         else if ( true )
         {
            sOrderString += " ORDER BY T1.[UsuCod]";
         }
         scmdbuf = "SELECT " + sSelectString + sFromString + sWhereString + sOrderString + "" + " OFFSET " + "@GXPagingFrom2" + " ROWS FETCH NEXT CAST((SELECT CASE WHEN " + "@GXPagingTo2" + " > 0 THEN " + "@GXPagingTo2" + " ELSE 1e9 END) AS INTEGER) ROWS ONLY";
         GXv_Object8[0] = scmdbuf;
         GXv_Object8[1] = GXv_int7;
         return GXv_Object8 ;
      }

      protected Object[] conditional_H000H3( IGxContext context ,
                                             short A2039UsuSts ,
                                             GxSimpleCollection<short> AV130Seguridad_usuarioswwds_24_tfususts_sels ,
                                             string AV107Seguridad_usuarioswwds_1_dynamicfiltersselector1 ,
                                             short AV108Seguridad_usuarioswwds_2_dynamicfiltersoperator1 ,
                                             string AV109Seguridad_usuarioswwds_3_usuvenddsc1 ,
                                             string AV110Seguridad_usuarioswwds_4_usutiedsc1 ,
                                             string AV111Seguridad_usuarioswwds_5_usunom1 ,
                                             bool AV112Seguridad_usuarioswwds_6_dynamicfiltersenabled2 ,
                                             string AV113Seguridad_usuarioswwds_7_dynamicfiltersselector2 ,
                                             short AV114Seguridad_usuarioswwds_8_dynamicfiltersoperator2 ,
                                             string AV115Seguridad_usuarioswwds_9_usuvenddsc2 ,
                                             string AV116Seguridad_usuarioswwds_10_usutiedsc2 ,
                                             string AV117Seguridad_usuarioswwds_11_usunom2 ,
                                             bool AV118Seguridad_usuarioswwds_12_dynamicfiltersenabled3 ,
                                             string AV119Seguridad_usuarioswwds_13_dynamicfiltersselector3 ,
                                             short AV120Seguridad_usuarioswwds_14_dynamicfiltersoperator3 ,
                                             string AV121Seguridad_usuarioswwds_15_usuvenddsc3 ,
                                             string AV122Seguridad_usuarioswwds_16_usutiedsc3 ,
                                             string AV123Seguridad_usuarioswwds_17_usunom3 ,
                                             string AV125Seguridad_usuarioswwds_19_tfusucod_sel ,
                                             string AV124Seguridad_usuarioswwds_18_tfusucod ,
                                             string AV127Seguridad_usuarioswwds_21_tfusunom_sel ,
                                             string AV126Seguridad_usuarioswwds_20_tfusunom ,
                                             string AV129Seguridad_usuarioswwds_23_tfusuemail_sel ,
                                             string AV128Seguridad_usuarioswwds_22_tfusuemail ,
                                             int AV130Seguridad_usuarioswwds_24_tfususts_sels_Count ,
                                             string AV132Seguridad_usuarioswwds_26_tfusuvenddsc_sel ,
                                             string AV131Seguridad_usuarioswwds_25_tfusuvenddsc ,
                                             string AV134Seguridad_usuarioswwds_28_tfusutiedsc_sel ,
                                             string AV133Seguridad_usuarioswwds_27_tfusutiedsc ,
                                             string A2097UsuVendDsc ,
                                             string A2096UsuTieDsc ,
                                             string A2019UsuNom ,
                                             string A348UsuCod ,
                                             string A2014UsuEMAIL ,
                                             short AV13OrderedBy ,
                                             bool AV14OrderedDsc )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int9 = new short[28];
         Object[] GXv_Object10 = new Object[2];
         scmdbuf = "SELECT COUNT(*) FROM (([SGUSUARIOS] T1 INNER JOIN [CVENDEDORES] T2 ON T2.[VenCod] = T1.[UsuVend]) INNER JOIN [SGTIENDAS] T3 ON T3.[TieCod] = T1.[UsuTieCod])";
         if ( ( StringUtil.StrCmp(AV107Seguridad_usuarioswwds_1_dynamicfiltersselector1, "USUVENDDSC") == 0 ) && ( AV108Seguridad_usuarioswwds_2_dynamicfiltersoperator1 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV109Seguridad_usuarioswwds_3_usuvenddsc1)) ) )
         {
            AddWhere(sWhereString, "(T2.[VenDsc] like @lV109Seguridad_usuarioswwds_3_usuvenddsc1)");
         }
         else
         {
            GXv_int9[0] = 1;
         }
         if ( ( StringUtil.StrCmp(AV107Seguridad_usuarioswwds_1_dynamicfiltersselector1, "USUVENDDSC") == 0 ) && ( AV108Seguridad_usuarioswwds_2_dynamicfiltersoperator1 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV109Seguridad_usuarioswwds_3_usuvenddsc1)) ) )
         {
            AddWhere(sWhereString, "(T2.[VenDsc] like '%' + @lV109Seguridad_usuarioswwds_3_usuvenddsc1)");
         }
         else
         {
            GXv_int9[1] = 1;
         }
         if ( ( StringUtil.StrCmp(AV107Seguridad_usuarioswwds_1_dynamicfiltersselector1, "USUTIEDSC") == 0 ) && ( AV108Seguridad_usuarioswwds_2_dynamicfiltersoperator1 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV110Seguridad_usuarioswwds_4_usutiedsc1)) ) )
         {
            AddWhere(sWhereString, "(T3.[TieDsc] like @lV110Seguridad_usuarioswwds_4_usutiedsc1)");
         }
         else
         {
            GXv_int9[2] = 1;
         }
         if ( ( StringUtil.StrCmp(AV107Seguridad_usuarioswwds_1_dynamicfiltersselector1, "USUTIEDSC") == 0 ) && ( AV108Seguridad_usuarioswwds_2_dynamicfiltersoperator1 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV110Seguridad_usuarioswwds_4_usutiedsc1)) ) )
         {
            AddWhere(sWhereString, "(T3.[TieDsc] like '%' + @lV110Seguridad_usuarioswwds_4_usutiedsc1)");
         }
         else
         {
            GXv_int9[3] = 1;
         }
         if ( ( StringUtil.StrCmp(AV107Seguridad_usuarioswwds_1_dynamicfiltersselector1, "USUNOM") == 0 ) && ( AV108Seguridad_usuarioswwds_2_dynamicfiltersoperator1 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV111Seguridad_usuarioswwds_5_usunom1)) ) )
         {
            AddWhere(sWhereString, "(T1.[UsuNom] like @lV111Seguridad_usuarioswwds_5_usunom1)");
         }
         else
         {
            GXv_int9[4] = 1;
         }
         if ( ( StringUtil.StrCmp(AV107Seguridad_usuarioswwds_1_dynamicfiltersselector1, "USUNOM") == 0 ) && ( AV108Seguridad_usuarioswwds_2_dynamicfiltersoperator1 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV111Seguridad_usuarioswwds_5_usunom1)) ) )
         {
            AddWhere(sWhereString, "(T1.[UsuNom] like '%' + @lV111Seguridad_usuarioswwds_5_usunom1)");
         }
         else
         {
            GXv_int9[5] = 1;
         }
         if ( AV112Seguridad_usuarioswwds_6_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV113Seguridad_usuarioswwds_7_dynamicfiltersselector2, "USUVENDDSC") == 0 ) && ( AV114Seguridad_usuarioswwds_8_dynamicfiltersoperator2 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV115Seguridad_usuarioswwds_9_usuvenddsc2)) ) )
         {
            AddWhere(sWhereString, "(T2.[VenDsc] like @lV115Seguridad_usuarioswwds_9_usuvenddsc2)");
         }
         else
         {
            GXv_int9[6] = 1;
         }
         if ( AV112Seguridad_usuarioswwds_6_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV113Seguridad_usuarioswwds_7_dynamicfiltersselector2, "USUVENDDSC") == 0 ) && ( AV114Seguridad_usuarioswwds_8_dynamicfiltersoperator2 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV115Seguridad_usuarioswwds_9_usuvenddsc2)) ) )
         {
            AddWhere(sWhereString, "(T2.[VenDsc] like '%' + @lV115Seguridad_usuarioswwds_9_usuvenddsc2)");
         }
         else
         {
            GXv_int9[7] = 1;
         }
         if ( AV112Seguridad_usuarioswwds_6_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV113Seguridad_usuarioswwds_7_dynamicfiltersselector2, "USUTIEDSC") == 0 ) && ( AV114Seguridad_usuarioswwds_8_dynamicfiltersoperator2 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV116Seguridad_usuarioswwds_10_usutiedsc2)) ) )
         {
            AddWhere(sWhereString, "(T3.[TieDsc] like @lV116Seguridad_usuarioswwds_10_usutiedsc2)");
         }
         else
         {
            GXv_int9[8] = 1;
         }
         if ( AV112Seguridad_usuarioswwds_6_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV113Seguridad_usuarioswwds_7_dynamicfiltersselector2, "USUTIEDSC") == 0 ) && ( AV114Seguridad_usuarioswwds_8_dynamicfiltersoperator2 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV116Seguridad_usuarioswwds_10_usutiedsc2)) ) )
         {
            AddWhere(sWhereString, "(T3.[TieDsc] like '%' + @lV116Seguridad_usuarioswwds_10_usutiedsc2)");
         }
         else
         {
            GXv_int9[9] = 1;
         }
         if ( AV112Seguridad_usuarioswwds_6_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV113Seguridad_usuarioswwds_7_dynamicfiltersselector2, "USUNOM") == 0 ) && ( AV114Seguridad_usuarioswwds_8_dynamicfiltersoperator2 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV117Seguridad_usuarioswwds_11_usunom2)) ) )
         {
            AddWhere(sWhereString, "(T1.[UsuNom] like @lV117Seguridad_usuarioswwds_11_usunom2)");
         }
         else
         {
            GXv_int9[10] = 1;
         }
         if ( AV112Seguridad_usuarioswwds_6_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV113Seguridad_usuarioswwds_7_dynamicfiltersselector2, "USUNOM") == 0 ) && ( AV114Seguridad_usuarioswwds_8_dynamicfiltersoperator2 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV117Seguridad_usuarioswwds_11_usunom2)) ) )
         {
            AddWhere(sWhereString, "(T1.[UsuNom] like '%' + @lV117Seguridad_usuarioswwds_11_usunom2)");
         }
         else
         {
            GXv_int9[11] = 1;
         }
         if ( AV118Seguridad_usuarioswwds_12_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV119Seguridad_usuarioswwds_13_dynamicfiltersselector3, "USUVENDDSC") == 0 ) && ( AV120Seguridad_usuarioswwds_14_dynamicfiltersoperator3 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV121Seguridad_usuarioswwds_15_usuvenddsc3)) ) )
         {
            AddWhere(sWhereString, "(T2.[VenDsc] like @lV121Seguridad_usuarioswwds_15_usuvenddsc3)");
         }
         else
         {
            GXv_int9[12] = 1;
         }
         if ( AV118Seguridad_usuarioswwds_12_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV119Seguridad_usuarioswwds_13_dynamicfiltersselector3, "USUVENDDSC") == 0 ) && ( AV120Seguridad_usuarioswwds_14_dynamicfiltersoperator3 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV121Seguridad_usuarioswwds_15_usuvenddsc3)) ) )
         {
            AddWhere(sWhereString, "(T2.[VenDsc] like '%' + @lV121Seguridad_usuarioswwds_15_usuvenddsc3)");
         }
         else
         {
            GXv_int9[13] = 1;
         }
         if ( AV118Seguridad_usuarioswwds_12_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV119Seguridad_usuarioswwds_13_dynamicfiltersselector3, "USUTIEDSC") == 0 ) && ( AV120Seguridad_usuarioswwds_14_dynamicfiltersoperator3 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV122Seguridad_usuarioswwds_16_usutiedsc3)) ) )
         {
            AddWhere(sWhereString, "(T3.[TieDsc] like @lV122Seguridad_usuarioswwds_16_usutiedsc3)");
         }
         else
         {
            GXv_int9[14] = 1;
         }
         if ( AV118Seguridad_usuarioswwds_12_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV119Seguridad_usuarioswwds_13_dynamicfiltersselector3, "USUTIEDSC") == 0 ) && ( AV120Seguridad_usuarioswwds_14_dynamicfiltersoperator3 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV122Seguridad_usuarioswwds_16_usutiedsc3)) ) )
         {
            AddWhere(sWhereString, "(T3.[TieDsc] like '%' + @lV122Seguridad_usuarioswwds_16_usutiedsc3)");
         }
         else
         {
            GXv_int9[15] = 1;
         }
         if ( AV118Seguridad_usuarioswwds_12_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV119Seguridad_usuarioswwds_13_dynamicfiltersselector3, "USUNOM") == 0 ) && ( AV120Seguridad_usuarioswwds_14_dynamicfiltersoperator3 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV123Seguridad_usuarioswwds_17_usunom3)) ) )
         {
            AddWhere(sWhereString, "(T1.[UsuNom] like @lV123Seguridad_usuarioswwds_17_usunom3)");
         }
         else
         {
            GXv_int9[16] = 1;
         }
         if ( AV118Seguridad_usuarioswwds_12_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV119Seguridad_usuarioswwds_13_dynamicfiltersselector3, "USUNOM") == 0 ) && ( AV120Seguridad_usuarioswwds_14_dynamicfiltersoperator3 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV123Seguridad_usuarioswwds_17_usunom3)) ) )
         {
            AddWhere(sWhereString, "(T1.[UsuNom] like '%' + @lV123Seguridad_usuarioswwds_17_usunom3)");
         }
         else
         {
            GXv_int9[17] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV125Seguridad_usuarioswwds_19_tfusucod_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV124Seguridad_usuarioswwds_18_tfusucod)) ) )
         {
            AddWhere(sWhereString, "(T1.[UsuCod] like @lV124Seguridad_usuarioswwds_18_tfusucod)");
         }
         else
         {
            GXv_int9[18] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV125Seguridad_usuarioswwds_19_tfusucod_sel)) )
         {
            AddWhere(sWhereString, "(T1.[UsuCod] = @AV125Seguridad_usuarioswwds_19_tfusucod_sel)");
         }
         else
         {
            GXv_int9[19] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV127Seguridad_usuarioswwds_21_tfusunom_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV126Seguridad_usuarioswwds_20_tfusunom)) ) )
         {
            AddWhere(sWhereString, "(T1.[UsuNom] like @lV126Seguridad_usuarioswwds_20_tfusunom)");
         }
         else
         {
            GXv_int9[20] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV127Seguridad_usuarioswwds_21_tfusunom_sel)) )
         {
            AddWhere(sWhereString, "(T1.[UsuNom] = @AV127Seguridad_usuarioswwds_21_tfusunom_sel)");
         }
         else
         {
            GXv_int9[21] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV129Seguridad_usuarioswwds_23_tfusuemail_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV128Seguridad_usuarioswwds_22_tfusuemail)) ) )
         {
            AddWhere(sWhereString, "(T1.[UsuEMAIL] like @lV128Seguridad_usuarioswwds_22_tfusuemail)");
         }
         else
         {
            GXv_int9[22] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV129Seguridad_usuarioswwds_23_tfusuemail_sel)) )
         {
            AddWhere(sWhereString, "(T1.[UsuEMAIL] = @AV129Seguridad_usuarioswwds_23_tfusuemail_sel)");
         }
         else
         {
            GXv_int9[23] = 1;
         }
         if ( AV130Seguridad_usuarioswwds_24_tfususts_sels_Count > 0 )
         {
            AddWhere(sWhereString, "("+new GxDbmsUtils( new GxSqlServer()).ValueList(AV130Seguridad_usuarioswwds_24_tfususts_sels, "T1.[UsuSts] IN (", ")")+")");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV132Seguridad_usuarioswwds_26_tfusuvenddsc_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV131Seguridad_usuarioswwds_25_tfusuvenddsc)) ) )
         {
            AddWhere(sWhereString, "(T2.[VenDsc] like @lV131Seguridad_usuarioswwds_25_tfusuvenddsc)");
         }
         else
         {
            GXv_int9[24] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV132Seguridad_usuarioswwds_26_tfusuvenddsc_sel)) )
         {
            AddWhere(sWhereString, "(T2.[VenDsc] = @AV132Seguridad_usuarioswwds_26_tfusuvenddsc_sel)");
         }
         else
         {
            GXv_int9[25] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV134Seguridad_usuarioswwds_28_tfusutiedsc_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV133Seguridad_usuarioswwds_27_tfusutiedsc)) ) )
         {
            AddWhere(sWhereString, "(T3.[TieDsc] like @lV133Seguridad_usuarioswwds_27_tfusutiedsc)");
         }
         else
         {
            GXv_int9[26] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV134Seguridad_usuarioswwds_28_tfusutiedsc_sel)) )
         {
            AddWhere(sWhereString, "(T3.[TieDsc] = @AV134Seguridad_usuarioswwds_28_tfusutiedsc_sel)");
         }
         else
         {
            GXv_int9[27] = 1;
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
         else if ( true )
         {
            scmdbuf += "";
         }
         GXv_Object10[0] = scmdbuf;
         GXv_Object10[1] = GXv_int9;
         return GXv_Object10 ;
      }

      public override Object [] getDynamicStatement( int cursor ,
                                                     IGxContext context ,
                                                     Object [] dynConstraints )
      {
         switch ( cursor )
         {
               case 0 :
                     return conditional_H000H2(context, (short)dynConstraints[0] , (GxSimpleCollection<short>)dynConstraints[1] , (string)dynConstraints[2] , (short)dynConstraints[3] , (string)dynConstraints[4] , (string)dynConstraints[5] , (string)dynConstraints[6] , (bool)dynConstraints[7] , (string)dynConstraints[8] , (short)dynConstraints[9] , (string)dynConstraints[10] , (string)dynConstraints[11] , (string)dynConstraints[12] , (bool)dynConstraints[13] , (string)dynConstraints[14] , (short)dynConstraints[15] , (string)dynConstraints[16] , (string)dynConstraints[17] , (string)dynConstraints[18] , (string)dynConstraints[19] , (string)dynConstraints[20] , (string)dynConstraints[21] , (string)dynConstraints[22] , (string)dynConstraints[23] , (string)dynConstraints[24] , (int)dynConstraints[25] , (string)dynConstraints[26] , (string)dynConstraints[27] , (string)dynConstraints[28] , (string)dynConstraints[29] , (string)dynConstraints[30] , (string)dynConstraints[31] , (string)dynConstraints[32] , (string)dynConstraints[33] , (string)dynConstraints[34] , (short)dynConstraints[35] , (bool)dynConstraints[36] );
               case 1 :
                     return conditional_H000H3(context, (short)dynConstraints[0] , (GxSimpleCollection<short>)dynConstraints[1] , (string)dynConstraints[2] , (short)dynConstraints[3] , (string)dynConstraints[4] , (string)dynConstraints[5] , (string)dynConstraints[6] , (bool)dynConstraints[7] , (string)dynConstraints[8] , (short)dynConstraints[9] , (string)dynConstraints[10] , (string)dynConstraints[11] , (string)dynConstraints[12] , (bool)dynConstraints[13] , (string)dynConstraints[14] , (short)dynConstraints[15] , (string)dynConstraints[16] , (string)dynConstraints[17] , (string)dynConstraints[18] , (string)dynConstraints[19] , (string)dynConstraints[20] , (string)dynConstraints[21] , (string)dynConstraints[22] , (string)dynConstraints[23] , (string)dynConstraints[24] , (int)dynConstraints[25] , (string)dynConstraints[26] , (string)dynConstraints[27] , (string)dynConstraints[28] , (string)dynConstraints[29] , (string)dynConstraints[30] , (string)dynConstraints[31] , (string)dynConstraints[32] , (string)dynConstraints[33] , (string)dynConstraints[34] , (short)dynConstraints[35] , (bool)dynConstraints[36] );
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
          Object[] prmH000H2;
          prmH000H2 = new Object[] {
          new ParDef("@lV109Seguridad_usuarioswwds_3_usuvenddsc1",GXType.NChar,100,0) ,
          new ParDef("@lV109Seguridad_usuarioswwds_3_usuvenddsc1",GXType.NChar,100,0) ,
          new ParDef("@lV110Seguridad_usuarioswwds_4_usutiedsc1",GXType.NChar,100,0) ,
          new ParDef("@lV110Seguridad_usuarioswwds_4_usutiedsc1",GXType.NChar,100,0) ,
          new ParDef("@lV111Seguridad_usuarioswwds_5_usunom1",GXType.NChar,100,0) ,
          new ParDef("@lV111Seguridad_usuarioswwds_5_usunom1",GXType.NChar,100,0) ,
          new ParDef("@lV115Seguridad_usuarioswwds_9_usuvenddsc2",GXType.NChar,100,0) ,
          new ParDef("@lV115Seguridad_usuarioswwds_9_usuvenddsc2",GXType.NChar,100,0) ,
          new ParDef("@lV116Seguridad_usuarioswwds_10_usutiedsc2",GXType.NChar,100,0) ,
          new ParDef("@lV116Seguridad_usuarioswwds_10_usutiedsc2",GXType.NChar,100,0) ,
          new ParDef("@lV117Seguridad_usuarioswwds_11_usunom2",GXType.NChar,100,0) ,
          new ParDef("@lV117Seguridad_usuarioswwds_11_usunom2",GXType.NChar,100,0) ,
          new ParDef("@lV121Seguridad_usuarioswwds_15_usuvenddsc3",GXType.NChar,100,0) ,
          new ParDef("@lV121Seguridad_usuarioswwds_15_usuvenddsc3",GXType.NChar,100,0) ,
          new ParDef("@lV122Seguridad_usuarioswwds_16_usutiedsc3",GXType.NChar,100,0) ,
          new ParDef("@lV122Seguridad_usuarioswwds_16_usutiedsc3",GXType.NChar,100,0) ,
          new ParDef("@lV123Seguridad_usuarioswwds_17_usunom3",GXType.NChar,100,0) ,
          new ParDef("@lV123Seguridad_usuarioswwds_17_usunom3",GXType.NChar,100,0) ,
          new ParDef("@lV124Seguridad_usuarioswwds_18_tfusucod",GXType.NChar,10,0) ,
          new ParDef("@AV125Seguridad_usuarioswwds_19_tfusucod_sel",GXType.NChar,10,0) ,
          new ParDef("@lV126Seguridad_usuarioswwds_20_tfusunom",GXType.NChar,100,0) ,
          new ParDef("@AV127Seguridad_usuarioswwds_21_tfusunom_sel",GXType.NChar,100,0) ,
          new ParDef("@lV128Seguridad_usuarioswwds_22_tfusuemail",GXType.NVarChar,100,0) ,
          new ParDef("@AV129Seguridad_usuarioswwds_23_tfusuemail_sel",GXType.NVarChar,100,0) ,
          new ParDef("@lV131Seguridad_usuarioswwds_25_tfusuvenddsc",GXType.NChar,100,0) ,
          new ParDef("@AV132Seguridad_usuarioswwds_26_tfusuvenddsc_sel",GXType.NChar,100,0) ,
          new ParDef("@lV133Seguridad_usuarioswwds_27_tfusutiedsc",GXType.NChar,100,0) ,
          new ParDef("@AV134Seguridad_usuarioswwds_28_tfusutiedsc_sel",GXType.NChar,100,0) ,
          new ParDef("@GXPagingFrom2",GXType.Int32,9,0) ,
          new ParDef("@GXPagingTo2",GXType.Int32,9,0) ,
          new ParDef("@GXPagingTo2",GXType.Int32,9,0)
          };
          Object[] prmH000H3;
          prmH000H3 = new Object[] {
          new ParDef("@lV109Seguridad_usuarioswwds_3_usuvenddsc1",GXType.NChar,100,0) ,
          new ParDef("@lV109Seguridad_usuarioswwds_3_usuvenddsc1",GXType.NChar,100,0) ,
          new ParDef("@lV110Seguridad_usuarioswwds_4_usutiedsc1",GXType.NChar,100,0) ,
          new ParDef("@lV110Seguridad_usuarioswwds_4_usutiedsc1",GXType.NChar,100,0) ,
          new ParDef("@lV111Seguridad_usuarioswwds_5_usunom1",GXType.NChar,100,0) ,
          new ParDef("@lV111Seguridad_usuarioswwds_5_usunom1",GXType.NChar,100,0) ,
          new ParDef("@lV115Seguridad_usuarioswwds_9_usuvenddsc2",GXType.NChar,100,0) ,
          new ParDef("@lV115Seguridad_usuarioswwds_9_usuvenddsc2",GXType.NChar,100,0) ,
          new ParDef("@lV116Seguridad_usuarioswwds_10_usutiedsc2",GXType.NChar,100,0) ,
          new ParDef("@lV116Seguridad_usuarioswwds_10_usutiedsc2",GXType.NChar,100,0) ,
          new ParDef("@lV117Seguridad_usuarioswwds_11_usunom2",GXType.NChar,100,0) ,
          new ParDef("@lV117Seguridad_usuarioswwds_11_usunom2",GXType.NChar,100,0) ,
          new ParDef("@lV121Seguridad_usuarioswwds_15_usuvenddsc3",GXType.NChar,100,0) ,
          new ParDef("@lV121Seguridad_usuarioswwds_15_usuvenddsc3",GXType.NChar,100,0) ,
          new ParDef("@lV122Seguridad_usuarioswwds_16_usutiedsc3",GXType.NChar,100,0) ,
          new ParDef("@lV122Seguridad_usuarioswwds_16_usutiedsc3",GXType.NChar,100,0) ,
          new ParDef("@lV123Seguridad_usuarioswwds_17_usunom3",GXType.NChar,100,0) ,
          new ParDef("@lV123Seguridad_usuarioswwds_17_usunom3",GXType.NChar,100,0) ,
          new ParDef("@lV124Seguridad_usuarioswwds_18_tfusucod",GXType.NChar,10,0) ,
          new ParDef("@AV125Seguridad_usuarioswwds_19_tfusucod_sel",GXType.NChar,10,0) ,
          new ParDef("@lV126Seguridad_usuarioswwds_20_tfusunom",GXType.NChar,100,0) ,
          new ParDef("@AV127Seguridad_usuarioswwds_21_tfusunom_sel",GXType.NChar,100,0) ,
          new ParDef("@lV128Seguridad_usuarioswwds_22_tfusuemail",GXType.NVarChar,100,0) ,
          new ParDef("@AV129Seguridad_usuarioswwds_23_tfusuemail_sel",GXType.NVarChar,100,0) ,
          new ParDef("@lV131Seguridad_usuarioswwds_25_tfusuvenddsc",GXType.NChar,100,0) ,
          new ParDef("@AV132Seguridad_usuarioswwds_26_tfusuvenddsc_sel",GXType.NChar,100,0) ,
          new ParDef("@lV133Seguridad_usuarioswwds_27_tfusutiedsc",GXType.NChar,100,0) ,
          new ParDef("@AV134Seguridad_usuarioswwds_28_tfusutiedsc_sel",GXType.NChar,100,0)
          };
          def= new CursorDef[] {
              new CursorDef("H000H2", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH000H2,11, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("H000H3", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH000H3,1, GxCacheFrequency.OFF ,true,false )
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
                ((int[]) buf[1])[0] = rslt.getInt(2);
                ((string[]) buf[2])[0] = rslt.getString(3, 100);
                ((string[]) buf[3])[0] = rslt.getString(4, 100);
                ((short[]) buf[4])[0] = rslt.getShort(5);
                ((string[]) buf[5])[0] = rslt.getVarchar(6);
                ((string[]) buf[6])[0] = rslt.getString(7, 100);
                ((string[]) buf[7])[0] = rslt.getString(8, 10);
                return;
             case 1 :
                ((long[]) buf[0])[0] = rslt.getLong(1);
                return;
       }
    }

 }

}
