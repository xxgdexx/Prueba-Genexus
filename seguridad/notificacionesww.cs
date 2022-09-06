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
   public class notificacionesww : GXDataArea
   {
      public notificacionesww( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDataStore2 = context.GetDataStore("DataStore2");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusTheme");
      }

      public notificacionesww( IGxContext context )
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
         cmbSGNotificacionIconClass = new GXCombobox();
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
               nRC_GXsfl_101 = (int)(NumberUtil.Val( GetPar( "nRC_GXsfl_101"), "."));
               nGXsfl_101_idx = (int)(NumberUtil.Val( GetPar( "nGXsfl_101_idx"), "."));
               sGXsfl_101_idx = GetPar( "sGXsfl_101_idx");
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
               AV17SGNotificacionTitulo1 = GetPar( "SGNotificacionTitulo1");
               cmbavDynamicfiltersselector2.FromJSonString( GetNextPar( ));
               AV19DynamicFiltersSelector2 = GetPar( "DynamicFiltersSelector2");
               cmbavDynamicfiltersoperator2.FromJSonString( GetNextPar( ));
               AV20DynamicFiltersOperator2 = (short)(NumberUtil.Val( GetPar( "DynamicFiltersOperator2"), "."));
               AV21SGNotificacionTitulo2 = GetPar( "SGNotificacionTitulo2");
               cmbavDynamicfiltersselector3.FromJSonString( GetNextPar( ));
               AV23DynamicFiltersSelector3 = GetPar( "DynamicFiltersSelector3");
               cmbavDynamicfiltersoperator3.FromJSonString( GetNextPar( ));
               AV24DynamicFiltersOperator3 = (short)(NumberUtil.Val( GetPar( "DynamicFiltersOperator3"), "."));
               AV25SGNotificacionTitulo3 = GetPar( "SGNotificacionTitulo3");
               AV60Pgmname = GetPar( "Pgmname");
               AV18DynamicFiltersEnabled2 = StringUtil.StrToBool( GetPar( "DynamicFiltersEnabled2"));
               AV22DynamicFiltersEnabled3 = StringUtil.StrToBool( GetPar( "DynamicFiltersEnabled3"));
               AV31TFSGNotificacionID = (long)(NumberUtil.Val( GetPar( "TFSGNotificacionID"), "."));
               AV32TFSGNotificacionID_To = (long)(NumberUtil.Val( GetPar( "TFSGNotificacionID_To"), "."));
               AV33TFSGNotificacionTitulo = GetPar( "TFSGNotificacionTitulo");
               AV34TFSGNotificacionTitulo_Sel = GetPar( "TFSGNotificacionTitulo_Sel");
               AV35TFSGNotificacionDescripcion = GetPar( "TFSGNotificacionDescripcion");
               AV36TFSGNotificacionDescripcion_Sel = GetPar( "TFSGNotificacionDescripcion_Sel");
               AV37TFSGNotificacionFecha = context.localUtil.ParseDTimeParm( GetPar( "TFSGNotificacionFecha"));
               AV38TFSGNotificacionFecha_To = context.localUtil.ParseDTimeParm( GetPar( "TFSGNotificacionFecha_To"));
               AV42TFSGNotificacionUsuario = GetPar( "TFSGNotificacionUsuario");
               AV43TFSGNotificacionUsuario_Sel = GetPar( "TFSGNotificacionUsuario_Sel");
               AV44TFSGNotificacionUsuarioDsc = GetPar( "TFSGNotificacionUsuarioDsc");
               AV45TFSGNotificacionUsuarioDsc_Sel = GetPar( "TFSGNotificacionUsuarioDsc_Sel");
               ajax_req_read_hidden_sdt(GetNextPar( ), AV47TFSGNotificacionIconClass_Sels);
               AV48TFSGNotificacionTUsuario = (short)(NumberUtil.Val( GetPar( "TFSGNotificacionTUsuario"), "."));
               AV49TFSGNotificacionTUsuario_To = (short)(NumberUtil.Val( GetPar( "TFSGNotificacionTUsuario_To"), "."));
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
               gxgrGrid_refresh( subGrid_Rows, AV15DynamicFiltersSelector1, AV16DynamicFiltersOperator1, AV17SGNotificacionTitulo1, AV19DynamicFiltersSelector2, AV20DynamicFiltersOperator2, AV21SGNotificacionTitulo2, AV23DynamicFiltersSelector3, AV24DynamicFiltersOperator3, AV25SGNotificacionTitulo3, AV60Pgmname, AV18DynamicFiltersEnabled2, AV22DynamicFiltersEnabled3, AV31TFSGNotificacionID, AV32TFSGNotificacionID_To, AV33TFSGNotificacionTitulo, AV34TFSGNotificacionTitulo_Sel, AV35TFSGNotificacionDescripcion, AV36TFSGNotificacionDescripcion_Sel, AV37TFSGNotificacionFecha, AV38TFSGNotificacionFecha_To, AV42TFSGNotificacionUsuario, AV43TFSGNotificacionUsuario_Sel, AV44TFSGNotificacionUsuarioDsc, AV45TFSGNotificacionUsuarioDsc_Sel, AV47TFSGNotificacionIconClass_Sels, AV48TFSGNotificacionTUsuario, AV49TFSGNotificacionTUsuario_To, AV13OrderedBy, AV14OrderedDsc, AV10GridState, AV27DynamicFiltersIgnoreFirst, AV26DynamicFiltersRemoving) ;
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
         PA2S2( ) ;
         gxajaxcallmode = (short)((isAjaxCallMode( ) ? 1 : 0));
         if ( ( gxajaxcallmode == 0 ) && ( GxWebError == 0 ) )
         {
            START2S2( ) ;
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
         context.AddJavascriptSource("gxcfg.js", "?202281810304934", false, true);
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
         context.WriteHtmlTextNl( "<form id=\"MAINFORM\" autocomplete=\"off\" name=\"MAINFORM\" method=\"post\" tabindex=-1  class=\"form-horizontal Form\" data-gx-class=\"form-horizontal Form\" novalidate action=\""+formatLink("seguridad.notificacionesww.aspx") +"\">") ;
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
         GxWebStd.gx_hidden_field( context, "gxhash_vPGMNAME", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( AV60Pgmname, "")), context));
         GXKey = Crypto.GetSiteKey( );
      }

      protected void SendCloseFormHiddens( )
      {
         /* Send hidden variables. */
         GxWebStd.gx_hidden_field( context, "GXH_vDYNAMICFILTERSSELECTOR1", AV15DynamicFiltersSelector1);
         GxWebStd.gx_hidden_field( context, "GXH_vDYNAMICFILTERSOPERATOR1", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV16DynamicFiltersOperator1), 4, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "GXH_vSGNOTIFICACIONTITULO1", AV17SGNotificacionTitulo1);
         GxWebStd.gx_hidden_field( context, "GXH_vDYNAMICFILTERSSELECTOR2", AV19DynamicFiltersSelector2);
         GxWebStd.gx_hidden_field( context, "GXH_vDYNAMICFILTERSOPERATOR2", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV20DynamicFiltersOperator2), 4, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "GXH_vSGNOTIFICACIONTITULO2", AV21SGNotificacionTitulo2);
         GxWebStd.gx_hidden_field( context, "GXH_vDYNAMICFILTERSSELECTOR3", AV23DynamicFiltersSelector3);
         GxWebStd.gx_hidden_field( context, "GXH_vDYNAMICFILTERSOPERATOR3", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV24DynamicFiltersOperator3), 4, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "GXH_vSGNOTIFICACIONTITULO3", AV25SGNotificacionTitulo3);
         /* Send saved values. */
         send_integrity_footer_hashes( ) ;
         GxWebStd.gx_hidden_field( context, "nRC_GXsfl_101", StringUtil.LTrim( StringUtil.NToC( (decimal)(nRC_GXsfl_101), 8, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "vGRIDCURRENTPAGE", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV52GridCurrentPage), 10, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "vGRIDPAGECOUNT", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV53GridPageCount), 10, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "vGRIDAPPLIEDFILTERS", AV54GridAppliedFilters);
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "vAGEXPORTDATA", AV56AGExportData);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt("vAGEXPORTDATA", AV56AGExportData);
         }
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "vDDO_TITLESETTINGSICONS", AV50DDO_TitleSettingsIcons);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt("vDDO_TITLESETTINGSICONS", AV50DDO_TitleSettingsIcons);
         }
         GxWebStd.gx_hidden_field( context, "vDDO_SGNOTIFICACIONFECHAAUXDATETO", context.localUtil.DToC( AV40DDO_SGNotificacionFechaAuxDateTo, 0, "/"));
         GxWebStd.gx_hidden_field( context, "vPGMNAME", StringUtil.RTrim( AV60Pgmname));
         GxWebStd.gx_hidden_field( context, "gxhash_vPGMNAME", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( AV60Pgmname, "")), context));
         GxWebStd.gx_boolean_hidden_field( context, "vDYNAMICFILTERSENABLED2", AV18DynamicFiltersEnabled2);
         GxWebStd.gx_boolean_hidden_field( context, "vDYNAMICFILTERSENABLED3", AV22DynamicFiltersEnabled3);
         GxWebStd.gx_hidden_field( context, "vTFSGNOTIFICACIONID", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV31TFSGNotificacionID), 10, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "vTFSGNOTIFICACIONID_TO", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV32TFSGNotificacionID_To), 10, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "vTFSGNOTIFICACIONTITULO", AV33TFSGNotificacionTitulo);
         GxWebStd.gx_hidden_field( context, "vTFSGNOTIFICACIONTITULO_SEL", AV34TFSGNotificacionTitulo_Sel);
         GxWebStd.gx_hidden_field( context, "vTFSGNOTIFICACIONDESCRIPCION", AV35TFSGNotificacionDescripcion);
         GxWebStd.gx_hidden_field( context, "vTFSGNOTIFICACIONDESCRIPCION_SEL", AV36TFSGNotificacionDescripcion_Sel);
         GxWebStd.gx_hidden_field( context, "vTFSGNOTIFICACIONFECHA", context.localUtil.TToC( AV37TFSGNotificacionFecha, 10, 8, 0, 0, "/", ":", " "));
         GxWebStd.gx_hidden_field( context, "vTFSGNOTIFICACIONFECHA_TO", context.localUtil.TToC( AV38TFSGNotificacionFecha_To, 10, 8, 0, 0, "/", ":", " "));
         GxWebStd.gx_hidden_field( context, "vTFSGNOTIFICACIONUSUARIO", StringUtil.RTrim( AV42TFSGNotificacionUsuario));
         GxWebStd.gx_hidden_field( context, "vTFSGNOTIFICACIONUSUARIO_SEL", StringUtil.RTrim( AV43TFSGNotificacionUsuario_Sel));
         GxWebStd.gx_hidden_field( context, "vTFSGNOTIFICACIONUSUARIODSC", StringUtil.RTrim( AV44TFSGNotificacionUsuarioDsc));
         GxWebStd.gx_hidden_field( context, "vTFSGNOTIFICACIONUSUARIODSC_SEL", StringUtil.RTrim( AV45TFSGNotificacionUsuarioDsc_Sel));
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "vTFSGNOTIFICACIONICONCLASS_SELS", AV47TFSGNotificacionIconClass_Sels);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt("vTFSGNOTIFICACIONICONCLASS_SELS", AV47TFSGNotificacionIconClass_Sels);
         }
         GxWebStd.gx_hidden_field( context, "vTFSGNOTIFICACIONTUSUARIO", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV48TFSGNotificacionTUsuario), 4, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "vTFSGNOTIFICACIONTUSUARIO_TO", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV49TFSGNotificacionTUsuario_To), 4, 0, ".", "")));
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
         GxWebStd.gx_hidden_field( context, "vTFSGNOTIFICACIONICONCLASS_SELSJSON", AV46TFSGNotificacionIconClass_SelsJson);
         GxWebStd.gx_hidden_field( context, "GRID_nFirstRecordOnPage", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRID_nFirstRecordOnPage), 15, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "GRID_nEOF", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRID_nEOF), 1, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "vDDO_SGNOTIFICACIONFECHAAUXDATE", context.localUtil.DToC( AV39DDO_SGNotificacionFechaAuxDate, 0, "/"));
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
            WE2S2( ) ;
            context.WriteHtmlText( "</div>") ;
         }
      }

      public override void DispatchEvents( )
      {
         EVT2S2( ) ;
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
         return formatLink("seguridad.notificacionesww.aspx")  ;
      }

      public override string GetPgmname( )
      {
         return "Seguridad.NotificacionesWW" ;
      }

      public override string GetPgmdesc( )
      {
         return " Notificaciones" ;
      }

      protected void WB2S0( )
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
            GxWebStd.gx_button_ctrl( context, bttBtninsert_Internalname, "gx.evt.setGridEvt("+StringUtil.Str( (decimal)(101), 3, 0)+","+"null"+");", "Agregar", bttBtninsert_Jsonclick, 5, "Agregar", "", StyleString, ClassString, 1, 1, "standard", "'"+""+"'"+",false,"+"'"+"E\\'DOINSERT\\'."+"'", TempTags, "", context.GetButtonType( ), "HLP_Seguridad\\NotificacionesWW.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "left", "top", "", "", "div");
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 21,'',false,'',0)\"";
            ClassString = "ColumnsSelector";
            StyleString = "";
            GxWebStd.gx_button_ctrl( context, bttBtnagexport_Internalname, "gx.evt.setGridEvt("+StringUtil.Str( (decimal)(101), 3, 0)+","+"null"+");", "Reportes", bttBtnagexport_Jsonclick, 0, "Reportes", "", StyleString, ClassString, 1, 0, "standard", "'"+""+"'"+",false,"+"'"+""+"'", TempTags, "", context.GetButtonType( ), "HLP_Seguridad\\NotificacionesWW.htm");
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
            wb_table1_25_2S2( true) ;
         }
         else
         {
            wb_table1_25_2S2( false) ;
         }
         return  ;
      }

      protected void wb_table1_25_2S2e( bool wbgen )
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
               context.WriteHtmlText( "<div id=\""+"GridContainer"+"DivS\" data-gxgridid=\"101\">") ;
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
               context.SendWebValue( "ID") ;
               context.WriteHtmlTextNl( "</th>") ;
               context.WriteHtmlText( "<th align=\""+"left"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+""+""+"\" "+">") ;
               context.SendWebValue( "Titulo") ;
               context.WriteHtmlTextNl( "</th>") ;
               context.WriteHtmlText( "<th align=\""+"left"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+""+""+"\" "+">") ;
               context.SendWebValue( "Descripción") ;
               context.WriteHtmlTextNl( "</th>") ;
               context.WriteHtmlText( "<th align=\""+"right"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+""+""+"\" "+">") ;
               context.SendWebValue( "Hora") ;
               context.WriteHtmlTextNl( "</th>") ;
               context.WriteHtmlText( "<th align=\""+"left"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+""+""+"\" "+">") ;
               context.SendWebValue( "Usuario") ;
               context.WriteHtmlTextNl( "</th>") ;
               context.WriteHtmlText( "<th align=\""+"left"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+""+""+"\" "+">") ;
               context.SendWebValue( "Usuario") ;
               context.WriteHtmlTextNl( "</th>") ;
               context.WriteHtmlText( "<th align=\""+"left"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+""+""+"\" "+">") ;
               context.SendWebValue( "Icon Class") ;
               context.WriteHtmlTextNl( "</th>") ;
               context.WriteHtmlText( "<th align=\""+"right"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+""+""+"\" "+">") ;
               context.SendWebValue( "Usuarios") ;
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
               GridColumn.AddObjectProperty("Value", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV55GridActions), 4, 0, ".", "")));
               GridContainer.AddColumnProperties(GridColumn);
               GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
               GridColumn.AddObjectProperty("Value", StringUtil.LTrim( StringUtil.NToC( (decimal)(A2237SGNotificacionID), 10, 0, ".", "")));
               GridContainer.AddColumnProperties(GridColumn);
               GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
               GridColumn.AddObjectProperty("Value", A2238SGNotificacionTitulo);
               GridColumn.AddObjectProperty("Link", StringUtil.RTrim( edtSGNotificacionTitulo_Link));
               GridContainer.AddColumnProperties(GridColumn);
               GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
               GridColumn.AddObjectProperty("Value", A2239SGNotificacionDescripcion);
               GridContainer.AddColumnProperties(GridColumn);
               GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
               GridColumn.AddObjectProperty("Value", context.localUtil.TToC( A2240SGNotificacionFecha, 10, 8, 0, 3, "/", ":", " "));
               GridContainer.AddColumnProperties(GridColumn);
               GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
               GridColumn.AddObjectProperty("Value", StringUtil.RTrim( A2241SGNotificacionUsuario));
               GridColumn.AddObjectProperty("Link", StringUtil.RTrim( edtSGNotificacionUsuario_Link));
               GridContainer.AddColumnProperties(GridColumn);
               GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
               GridColumn.AddObjectProperty("Value", StringUtil.RTrim( A2242SGNotificacionUsuarioDsc));
               GridColumn.AddObjectProperty("Link", StringUtil.RTrim( edtSGNotificacionUsuarioDsc_Link));
               GridContainer.AddColumnProperties(GridColumn);
               GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
               GridColumn.AddObjectProperty("Value", A2243SGNotificacionIconClass);
               GridContainer.AddColumnProperties(GridColumn);
               GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
               GridColumn.AddObjectProperty("Value", StringUtil.LTrim( StringUtil.NToC( (decimal)(A2244SGNotificacionTUsuario), 4, 0, ".", "")));
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
         if ( wbEnd == 101 )
         {
            wbEnd = 0;
            nRC_GXsfl_101 = (int)(nGXsfl_101_idx-1);
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
            ucGridpaginationbar.SetProperty("CurrentPage", AV52GridCurrentPage);
            ucGridpaginationbar.SetProperty("PageCount", AV53GridPageCount);
            ucGridpaginationbar.SetProperty("AppliedFilters", AV54GridAppliedFilters);
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
            ucDdo_agexport.SetProperty("DropDownOptionsData", AV56AGExportData);
            ucDdo_agexport.Render(context, "dvelop.gxbootstrap.ddoregular", Ddo_agexport_Internalname, "DDO_AGEXPORTContainer");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblJsdynamicfilters_Internalname, lblJsdynamicfilters_Caption, "", "", lblJsdynamicfilters_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "", 0, "", 1, 1, 0, 1, "HLP_Seguridad\\NotificacionesWW.htm");
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
            ucDdo_grid.SetProperty("DropDownOptionsTitleSettingsIcons", AV50DDO_TitleSettingsIcons);
            ucDdo_grid.Render(context, "dvelop.gxbootstrap.ddogridtitlesettingsm", Ddo_grid_Internalname, "DDO_GRIDContainer");
            /* User Defined Control */
            ucInnewwindow1.Render(context, "innewwindow", Innewwindow1_Internalname, "INNEWWINDOW1Container");
            /* User Defined Control */
            ucGrid_empowerer.SetProperty("HasTitleSettings", Grid_empowerer_Hastitlesettings);
            ucGrid_empowerer.Render(context, "wwp.gridempowerer", Grid_empowerer_Internalname, "GRID_EMPOWERERContainer");
            /* Div Control */
            GxWebStd.gx_div_start( context, divDdo_sgnotificacionfechaauxdates_Internalname, 1, 0, "px", 0, "px", "Invisible", "left", "top", "", "", "div");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 123,'',false,'" + sGXsfl_101_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavDdo_sgnotificacionfechaauxdatetext_Internalname, AV41DDO_SGNotificacionFechaAuxDateText, StringUtil.RTrim( context.localUtil.Format( AV41DDO_SGNotificacionFechaAuxDateText, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,123);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavDdo_sgnotificacionfechaauxdatetext_Jsonclick, 0, "Attribute", "", "", "", "", 1, 1, 0, "text", "", 40, "chr", 1, "row", 40, 0, 0, 0, 1, -1, -1, true, "", "left", true, "", "HLP_Seguridad\\NotificacionesWW.htm");
            /* User Defined Control */
            ucTfsgnotificacionfecha_rangepicker.SetProperty("Start Date", AV39DDO_SGNotificacionFechaAuxDate);
            ucTfsgnotificacionfecha_rangepicker.SetProperty("End Date", AV40DDO_SGNotificacionFechaAuxDateTo);
            ucTfsgnotificacionfecha_rangepicker.Render(context, "wwp.daterangepicker", Tfsgnotificacionfecha_rangepicker_Internalname, "TFSGNOTIFICACIONFECHA_RANGEPICKERContainer");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
         }
         if ( wbEnd == 101 )
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

      protected void START2S2( )
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
            Form.Meta.addItem("description", " Notificaciones", 0) ;
         }
         context.wjLoc = "";
         context.nUserReturn = 0;
         context.wbHandled = 0;
         if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
         {
         }
         wbErr = false;
         STRUP2S0( ) ;
      }

      protected void WS2S2( )
      {
         START2S2( ) ;
         EVT2S2( ) ;
      }

      protected void EVT2S2( )
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
                              E112S2 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "GRIDPAGINATIONBAR.CHANGEROWSPERPAGE") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              E122S2 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "DDO_AGEXPORT.ONOPTIONCLICKED") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              E132S2 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "DDO_GRID.ONOPTIONCLICKED") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              E142S2 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "'REMOVEDYNAMICFILTERS1'") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              /* Execute user event: 'RemoveDynamicFilters1' */
                              E152S2 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "'REMOVEDYNAMICFILTERS2'") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              /* Execute user event: 'RemoveDynamicFilters2' */
                              E162S2 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "'REMOVEDYNAMICFILTERS3'") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              /* Execute user event: 'RemoveDynamicFilters3' */
                              E172S2 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "'DOINSERT'") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              /* Execute user event: 'DoInsert' */
                              E182S2 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "'ADDDYNAMICFILTERS1'") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              /* Execute user event: 'AddDynamicFilters1' */
                              E192S2 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "VDYNAMICFILTERSSELECTOR1.CLICK") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              E202S2 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "'ADDDYNAMICFILTERS2'") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              /* Execute user event: 'AddDynamicFilters2' */
                              E212S2 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "VDYNAMICFILTERSSELECTOR2.CLICK") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              E222S2 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "VDYNAMICFILTERSSELECTOR3.CLICK") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              E232S2 ();
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
                              nGXsfl_101_idx = (int)(NumberUtil.Val( sEvtType, "."));
                              sGXsfl_101_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_101_idx), 4, 0), 4, "0");
                              SubsflControlProps_1012( ) ;
                              cmbavGridactions.Name = cmbavGridactions_Internalname;
                              cmbavGridactions.CurrentValue = cgiGet( cmbavGridactions_Internalname);
                              AV55GridActions = (short)(NumberUtil.Val( cgiGet( cmbavGridactions_Internalname), "."));
                              AssignAttri("", false, cmbavGridactions_Internalname, StringUtil.LTrimStr( (decimal)(AV55GridActions), 4, 0));
                              A2237SGNotificacionID = (long)(context.localUtil.CToN( cgiGet( edtSGNotificacionID_Internalname), ".", ","));
                              A2238SGNotificacionTitulo = cgiGet( edtSGNotificacionTitulo_Internalname);
                              A2239SGNotificacionDescripcion = cgiGet( edtSGNotificacionDescripcion_Internalname);
                              A2240SGNotificacionFecha = context.localUtil.CToT( cgiGet( edtSGNotificacionFecha_Internalname), 0);
                              A2241SGNotificacionUsuario = cgiGet( edtSGNotificacionUsuario_Internalname);
                              A2242SGNotificacionUsuarioDsc = cgiGet( edtSGNotificacionUsuarioDsc_Internalname);
                              cmbSGNotificacionIconClass.Name = cmbSGNotificacionIconClass_Internalname;
                              cmbSGNotificacionIconClass.CurrentValue = cgiGet( cmbSGNotificacionIconClass_Internalname);
                              A2243SGNotificacionIconClass = cgiGet( cmbSGNotificacionIconClass_Internalname);
                              A2244SGNotificacionTUsuario = (short)(context.localUtil.CToN( cgiGet( edtSGNotificacionTUsuario_Internalname), ".", ","));
                              sEvtType = StringUtil.Right( sEvt, 1);
                              if ( StringUtil.StrCmp(sEvtType, ".") == 0 )
                              {
                                 sEvt = StringUtil.Left( sEvt, (short)(StringUtil.Len( sEvt)-1));
                                 if ( StringUtil.StrCmp(sEvt, "START") == 0 )
                                 {
                                    context.wbHandled = 1;
                                    dynload_actions( ) ;
                                    /* Execute user event: Start */
                                    E242S2 ();
                                 }
                                 else if ( StringUtil.StrCmp(sEvt, "REFRESH") == 0 )
                                 {
                                    context.wbHandled = 1;
                                    dynload_actions( ) ;
                                    /* Execute user event: Refresh */
                                    E252S2 ();
                                 }
                                 else if ( StringUtil.StrCmp(sEvt, "GRID.LOAD") == 0 )
                                 {
                                    context.wbHandled = 1;
                                    dynload_actions( ) ;
                                    E262S2 ();
                                 }
                                 else if ( StringUtil.StrCmp(sEvt, "VGRIDACTIONS.CLICK") == 0 )
                                 {
                                    context.wbHandled = 1;
                                    dynload_actions( ) ;
                                    E272S2 ();
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
                                       /* Set Refresh If Sgnotificaciontitulo1 Changed */
                                       if ( StringUtil.StrCmp(cgiGet( "GXH_vSGNOTIFICACIONTITULO1"), AV17SGNotificacionTitulo1) != 0 )
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
                                       /* Set Refresh If Sgnotificaciontitulo2 Changed */
                                       if ( StringUtil.StrCmp(cgiGet( "GXH_vSGNOTIFICACIONTITULO2"), AV21SGNotificacionTitulo2) != 0 )
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
                                       /* Set Refresh If Sgnotificaciontitulo3 Changed */
                                       if ( StringUtil.StrCmp(cgiGet( "GXH_vSGNOTIFICACIONTITULO3"), AV25SGNotificacionTitulo3) != 0 )
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

      protected void WE2S2( )
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

      protected void PA2S2( )
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
         SubsflControlProps_1012( ) ;
         while ( nGXsfl_101_idx <= nRC_GXsfl_101 )
         {
            sendrow_1012( ) ;
            nGXsfl_101_idx = ((subGrid_Islastpage==1)&&(nGXsfl_101_idx+1>subGrid_fnc_Recordsperpage( )) ? 1 : nGXsfl_101_idx+1);
            sGXsfl_101_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_101_idx), 4, 0), 4, "0");
            SubsflControlProps_1012( ) ;
         }
         AddString( context.httpAjaxContext.getJSONContainerResponse( GridContainer)) ;
         /* End function gxnrGrid_newrow */
      }

      protected void gxgrGrid_refresh( int subGrid_Rows ,
                                       string AV15DynamicFiltersSelector1 ,
                                       short AV16DynamicFiltersOperator1 ,
                                       string AV17SGNotificacionTitulo1 ,
                                       string AV19DynamicFiltersSelector2 ,
                                       short AV20DynamicFiltersOperator2 ,
                                       string AV21SGNotificacionTitulo2 ,
                                       string AV23DynamicFiltersSelector3 ,
                                       short AV24DynamicFiltersOperator3 ,
                                       string AV25SGNotificacionTitulo3 ,
                                       string AV60Pgmname ,
                                       bool AV18DynamicFiltersEnabled2 ,
                                       bool AV22DynamicFiltersEnabled3 ,
                                       long AV31TFSGNotificacionID ,
                                       long AV32TFSGNotificacionID_To ,
                                       string AV33TFSGNotificacionTitulo ,
                                       string AV34TFSGNotificacionTitulo_Sel ,
                                       string AV35TFSGNotificacionDescripcion ,
                                       string AV36TFSGNotificacionDescripcion_Sel ,
                                       DateTime AV37TFSGNotificacionFecha ,
                                       DateTime AV38TFSGNotificacionFecha_To ,
                                       string AV42TFSGNotificacionUsuario ,
                                       string AV43TFSGNotificacionUsuario_Sel ,
                                       string AV44TFSGNotificacionUsuarioDsc ,
                                       string AV45TFSGNotificacionUsuarioDsc_Sel ,
                                       GxSimpleCollection<string> AV47TFSGNotificacionIconClass_Sels ,
                                       short AV48TFSGNotificacionTUsuario ,
                                       short AV49TFSGNotificacionTUsuario_To ,
                                       short AV13OrderedBy ,
                                       bool AV14OrderedDsc ,
                                       GeneXus.Programs.wwpbaseobjects.SdtWWPGridState AV10GridState ,
                                       bool AV27DynamicFiltersIgnoreFirst ,
                                       bool AV26DynamicFiltersRemoving )
      {
         initialize_formulas( ) ;
         GxWebStd.set_html_headers( context, 0, "", "");
         /* Execute user event: Refresh */
         E252S2 ();
         GRID_nCurrentRecord = 0;
         RF2S2( ) ;
         GXKey = Crypto.GetSiteKey( );
         send_integrity_footer_hashes( ) ;
         GXKey = Crypto.GetSiteKey( );
         /* End function gxgrGrid_refresh */
      }

      protected void send_integrity_hashes( )
      {
         GxWebStd.gx_hidden_field( context, "gxhash_SGNOTIFICACIONID", GetSecureSignedToken( "", context.localUtil.Format( (decimal)(A2237SGNotificacionID), "ZZZZZZZZZ9"), context));
         GxWebStd.gx_hidden_field( context, "SGNOTIFICACIONID", StringUtil.LTrim( StringUtil.NToC( (decimal)(A2237SGNotificacionID), 10, 0, ".", "")));
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
         RF2S2( ) ;
         if ( isFullAjaxMode( ) )
         {
            send_integrity_footer_hashes( ) ;
         }
      }

      protected void initialize_formulas( )
      {
         /* GeneXus formulas. */
         AV60Pgmname = "Seguridad.NotificacionesWW";
         context.Gx_err = 0;
      }

      protected void RF2S2( )
      {
         initialize_formulas( ) ;
         clear_multi_value_controls( ) ;
         if ( isAjaxCallMode( ) )
         {
            GridContainer.ClearRows();
         }
         wbStart = 101;
         /* Execute user event: Refresh */
         E252S2 ();
         nGXsfl_101_idx = 1;
         sGXsfl_101_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_101_idx), 4, 0), 4, "0");
         SubsflControlProps_1012( ) ;
         bGXsfl_101_Refreshing = true;
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
            SubsflControlProps_1012( ) ;
            GXPagingFrom2 = (int)(((subGrid_Rows==0) ? 0 : GRID_nFirstRecordOnPage));
            GXPagingTo2 = ((subGrid_Rows==0) ? 10000 : subGrid_fnc_Recordsperpage( )+1);
            pr_default.dynParam(0, new Object[]{ new Object[]{
                                                 A2243SGNotificacionIconClass ,
                                                 AV84Seguridad_notificacioneswwds_24_tfsgnotificacioniconclass_sels ,
                                                 AV61Seguridad_notificacioneswwds_1_dynamicfiltersselector1 ,
                                                 AV62Seguridad_notificacioneswwds_2_dynamicfiltersoperator1 ,
                                                 AV63Seguridad_notificacioneswwds_3_sgnotificaciontitulo1 ,
                                                 AV64Seguridad_notificacioneswwds_4_dynamicfiltersenabled2 ,
                                                 AV65Seguridad_notificacioneswwds_5_dynamicfiltersselector2 ,
                                                 AV66Seguridad_notificacioneswwds_6_dynamicfiltersoperator2 ,
                                                 AV67Seguridad_notificacioneswwds_7_sgnotificaciontitulo2 ,
                                                 AV68Seguridad_notificacioneswwds_8_dynamicfiltersenabled3 ,
                                                 AV69Seguridad_notificacioneswwds_9_dynamicfiltersselector3 ,
                                                 AV70Seguridad_notificacioneswwds_10_dynamicfiltersoperator3 ,
                                                 AV71Seguridad_notificacioneswwds_11_sgnotificaciontitulo3 ,
                                                 AV72Seguridad_notificacioneswwds_12_tfsgnotificacionid ,
                                                 AV73Seguridad_notificacioneswwds_13_tfsgnotificacionid_to ,
                                                 AV75Seguridad_notificacioneswwds_15_tfsgnotificaciontitulo_sel ,
                                                 AV74Seguridad_notificacioneswwds_14_tfsgnotificaciontitulo ,
                                                 AV77Seguridad_notificacioneswwds_17_tfsgnotificaciondescripcion_sel ,
                                                 AV76Seguridad_notificacioneswwds_16_tfsgnotificaciondescripcion ,
                                                 AV78Seguridad_notificacioneswwds_18_tfsgnotificacionfecha ,
                                                 AV79Seguridad_notificacioneswwds_19_tfsgnotificacionfecha_to ,
                                                 AV81Seguridad_notificacioneswwds_21_tfsgnotificacionusuario_sel ,
                                                 AV80Seguridad_notificacioneswwds_20_tfsgnotificacionusuario ,
                                                 AV83Seguridad_notificacioneswwds_23_tfsgnotificacionusuariodsc_sel ,
                                                 AV82Seguridad_notificacioneswwds_22_tfsgnotificacionusuariodsc ,
                                                 AV84Seguridad_notificacioneswwds_24_tfsgnotificacioniconclass_sels.Count ,
                                                 AV85Seguridad_notificacioneswwds_25_tfsgnotificaciontusuario ,
                                                 AV86Seguridad_notificacioneswwds_26_tfsgnotificaciontusuario_to ,
                                                 A2238SGNotificacionTitulo ,
                                                 A2237SGNotificacionID ,
                                                 A2239SGNotificacionDescripcion ,
                                                 A2240SGNotificacionFecha ,
                                                 A2241SGNotificacionUsuario ,
                                                 A2242SGNotificacionUsuarioDsc ,
                                                 A2244SGNotificacionTUsuario ,
                                                 AV13OrderedBy ,
                                                 AV14OrderedDsc } ,
                                                 new int[]{
                                                 TypeConstants.SHORT, TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.LONG, TypeConstants.LONG, TypeConstants.DATE, TypeConstants.DATE, TypeConstants.INT,
                                                 TypeConstants.SHORT, TypeConstants.SHORT, TypeConstants.LONG, TypeConstants.DATE, TypeConstants.SHORT, TypeConstants.SHORT, TypeConstants.BOOLEAN
                                                 }
            });
            lV63Seguridad_notificacioneswwds_3_sgnotificaciontitulo1 = StringUtil.Concat( StringUtil.RTrim( AV63Seguridad_notificacioneswwds_3_sgnotificaciontitulo1), "%", "");
            lV63Seguridad_notificacioneswwds_3_sgnotificaciontitulo1 = StringUtil.Concat( StringUtil.RTrim( AV63Seguridad_notificacioneswwds_3_sgnotificaciontitulo1), "%", "");
            lV67Seguridad_notificacioneswwds_7_sgnotificaciontitulo2 = StringUtil.Concat( StringUtil.RTrim( AV67Seguridad_notificacioneswwds_7_sgnotificaciontitulo2), "%", "");
            lV67Seguridad_notificacioneswwds_7_sgnotificaciontitulo2 = StringUtil.Concat( StringUtil.RTrim( AV67Seguridad_notificacioneswwds_7_sgnotificaciontitulo2), "%", "");
            lV71Seguridad_notificacioneswwds_11_sgnotificaciontitulo3 = StringUtil.Concat( StringUtil.RTrim( AV71Seguridad_notificacioneswwds_11_sgnotificaciontitulo3), "%", "");
            lV71Seguridad_notificacioneswwds_11_sgnotificaciontitulo3 = StringUtil.Concat( StringUtil.RTrim( AV71Seguridad_notificacioneswwds_11_sgnotificaciontitulo3), "%", "");
            lV74Seguridad_notificacioneswwds_14_tfsgnotificaciontitulo = StringUtil.Concat( StringUtil.RTrim( AV74Seguridad_notificacioneswwds_14_tfsgnotificaciontitulo), "%", "");
            lV76Seguridad_notificacioneswwds_16_tfsgnotificaciondescripcion = StringUtil.Concat( StringUtil.RTrim( AV76Seguridad_notificacioneswwds_16_tfsgnotificaciondescripcion), "%", "");
            lV80Seguridad_notificacioneswwds_20_tfsgnotificacionusuario = StringUtil.PadR( StringUtil.RTrim( AV80Seguridad_notificacioneswwds_20_tfsgnotificacionusuario), 10, "%");
            lV82Seguridad_notificacioneswwds_22_tfsgnotificacionusuariodsc = StringUtil.PadR( StringUtil.RTrim( AV82Seguridad_notificacioneswwds_22_tfsgnotificacionusuariodsc), 100, "%");
            /* Using cursor H002S2 */
            pr_default.execute(0, new Object[] {lV63Seguridad_notificacioneswwds_3_sgnotificaciontitulo1, lV63Seguridad_notificacioneswwds_3_sgnotificaciontitulo1, lV67Seguridad_notificacioneswwds_7_sgnotificaciontitulo2, lV67Seguridad_notificacioneswwds_7_sgnotificaciontitulo2, lV71Seguridad_notificacioneswwds_11_sgnotificaciontitulo3, lV71Seguridad_notificacioneswwds_11_sgnotificaciontitulo3, AV72Seguridad_notificacioneswwds_12_tfsgnotificacionid, AV73Seguridad_notificacioneswwds_13_tfsgnotificacionid_to, lV74Seguridad_notificacioneswwds_14_tfsgnotificaciontitulo, AV75Seguridad_notificacioneswwds_15_tfsgnotificaciontitulo_sel, lV76Seguridad_notificacioneswwds_16_tfsgnotificaciondescripcion, AV77Seguridad_notificacioneswwds_17_tfsgnotificaciondescripcion_sel, AV78Seguridad_notificacioneswwds_18_tfsgnotificacionfecha, AV79Seguridad_notificacioneswwds_19_tfsgnotificacionfecha_to, lV80Seguridad_notificacioneswwds_20_tfsgnotificacionusuario, AV81Seguridad_notificacioneswwds_21_tfsgnotificacionusuario_sel, lV82Seguridad_notificacioneswwds_22_tfsgnotificacionusuariodsc, AV83Seguridad_notificacioneswwds_23_tfsgnotificacionusuariodsc_sel, AV85Seguridad_notificacioneswwds_25_tfsgnotificaciontusuario, AV86Seguridad_notificacioneswwds_26_tfsgnotificaciontusuario_to, GXPagingFrom2, GXPagingTo2, GXPagingTo2});
            nGXsfl_101_idx = 1;
            sGXsfl_101_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_101_idx), 4, 0), 4, "0");
            SubsflControlProps_1012( ) ;
            while ( ( (pr_default.getStatus(0) != 101) ) && ( ( ( subGrid_Rows == 0 ) || ( GRID_nCurrentRecord < subGrid_fnc_Recordsperpage( ) ) ) ) )
            {
               A2244SGNotificacionTUsuario = H002S2_A2244SGNotificacionTUsuario[0];
               A2243SGNotificacionIconClass = H002S2_A2243SGNotificacionIconClass[0];
               A2242SGNotificacionUsuarioDsc = H002S2_A2242SGNotificacionUsuarioDsc[0];
               A2241SGNotificacionUsuario = H002S2_A2241SGNotificacionUsuario[0];
               A2240SGNotificacionFecha = H002S2_A2240SGNotificacionFecha[0];
               A2239SGNotificacionDescripcion = H002S2_A2239SGNotificacionDescripcion[0];
               A2238SGNotificacionTitulo = H002S2_A2238SGNotificacionTitulo[0];
               A2237SGNotificacionID = H002S2_A2237SGNotificacionID[0];
               A2242SGNotificacionUsuarioDsc = H002S2_A2242SGNotificacionUsuarioDsc[0];
               E262S2 ();
               pr_default.readNext(0);
            }
            GRID_nEOF = (short)(((pr_default.getStatus(0) == 101) ? 1 : 0));
            GxWebStd.gx_hidden_field( context, "GRID_nEOF", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRID_nEOF), 1, 0, ".", "")));
            pr_default.close(0);
            wbEnd = 101;
            WB2S0( ) ;
         }
         bGXsfl_101_Refreshing = true;
      }

      protected void send_integrity_lvl_hashes2S2( )
      {
         GxWebStd.gx_hidden_field( context, "vPGMNAME", StringUtil.RTrim( AV60Pgmname));
         GxWebStd.gx_hidden_field( context, "gxhash_vPGMNAME", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( AV60Pgmname, "")), context));
         GxWebStd.gx_hidden_field( context, "gxhash_SGNOTIFICACIONID"+"_"+sGXsfl_101_idx, GetSecureSignedToken( sGXsfl_101_idx, context.localUtil.Format( (decimal)(A2237SGNotificacionID), "ZZZZZZZZZ9"), context));
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
         AV61Seguridad_notificacioneswwds_1_dynamicfiltersselector1 = AV15DynamicFiltersSelector1;
         AV62Seguridad_notificacioneswwds_2_dynamicfiltersoperator1 = AV16DynamicFiltersOperator1;
         AV63Seguridad_notificacioneswwds_3_sgnotificaciontitulo1 = AV17SGNotificacionTitulo1;
         AV64Seguridad_notificacioneswwds_4_dynamicfiltersenabled2 = AV18DynamicFiltersEnabled2;
         AV65Seguridad_notificacioneswwds_5_dynamicfiltersselector2 = AV19DynamicFiltersSelector2;
         AV66Seguridad_notificacioneswwds_6_dynamicfiltersoperator2 = AV20DynamicFiltersOperator2;
         AV67Seguridad_notificacioneswwds_7_sgnotificaciontitulo2 = AV21SGNotificacionTitulo2;
         AV68Seguridad_notificacioneswwds_8_dynamicfiltersenabled3 = AV22DynamicFiltersEnabled3;
         AV69Seguridad_notificacioneswwds_9_dynamicfiltersselector3 = AV23DynamicFiltersSelector3;
         AV70Seguridad_notificacioneswwds_10_dynamicfiltersoperator3 = AV24DynamicFiltersOperator3;
         AV71Seguridad_notificacioneswwds_11_sgnotificaciontitulo3 = AV25SGNotificacionTitulo3;
         AV72Seguridad_notificacioneswwds_12_tfsgnotificacionid = AV31TFSGNotificacionID;
         AV73Seguridad_notificacioneswwds_13_tfsgnotificacionid_to = AV32TFSGNotificacionID_To;
         AV74Seguridad_notificacioneswwds_14_tfsgnotificaciontitulo = AV33TFSGNotificacionTitulo;
         AV75Seguridad_notificacioneswwds_15_tfsgnotificaciontitulo_sel = AV34TFSGNotificacionTitulo_Sel;
         AV76Seguridad_notificacioneswwds_16_tfsgnotificaciondescripcion = AV35TFSGNotificacionDescripcion;
         AV77Seguridad_notificacioneswwds_17_tfsgnotificaciondescripcion_sel = AV36TFSGNotificacionDescripcion_Sel;
         AV78Seguridad_notificacioneswwds_18_tfsgnotificacionfecha = AV37TFSGNotificacionFecha;
         AV79Seguridad_notificacioneswwds_19_tfsgnotificacionfecha_to = AV38TFSGNotificacionFecha_To;
         AV80Seguridad_notificacioneswwds_20_tfsgnotificacionusuario = AV42TFSGNotificacionUsuario;
         AV81Seguridad_notificacioneswwds_21_tfsgnotificacionusuario_sel = AV43TFSGNotificacionUsuario_Sel;
         AV82Seguridad_notificacioneswwds_22_tfsgnotificacionusuariodsc = AV44TFSGNotificacionUsuarioDsc;
         AV83Seguridad_notificacioneswwds_23_tfsgnotificacionusuariodsc_sel = AV45TFSGNotificacionUsuarioDsc_Sel;
         AV84Seguridad_notificacioneswwds_24_tfsgnotificacioniconclass_sels = AV47TFSGNotificacionIconClass_Sels;
         AV85Seguridad_notificacioneswwds_25_tfsgnotificaciontusuario = AV48TFSGNotificacionTUsuario;
         AV86Seguridad_notificacioneswwds_26_tfsgnotificaciontusuario_to = AV49TFSGNotificacionTUsuario_To;
         pr_default.dynParam(1, new Object[]{ new Object[]{
                                              A2243SGNotificacionIconClass ,
                                              AV84Seguridad_notificacioneswwds_24_tfsgnotificacioniconclass_sels ,
                                              AV61Seguridad_notificacioneswwds_1_dynamicfiltersselector1 ,
                                              AV62Seguridad_notificacioneswwds_2_dynamicfiltersoperator1 ,
                                              AV63Seguridad_notificacioneswwds_3_sgnotificaciontitulo1 ,
                                              AV64Seguridad_notificacioneswwds_4_dynamicfiltersenabled2 ,
                                              AV65Seguridad_notificacioneswwds_5_dynamicfiltersselector2 ,
                                              AV66Seguridad_notificacioneswwds_6_dynamicfiltersoperator2 ,
                                              AV67Seguridad_notificacioneswwds_7_sgnotificaciontitulo2 ,
                                              AV68Seguridad_notificacioneswwds_8_dynamicfiltersenabled3 ,
                                              AV69Seguridad_notificacioneswwds_9_dynamicfiltersselector3 ,
                                              AV70Seguridad_notificacioneswwds_10_dynamicfiltersoperator3 ,
                                              AV71Seguridad_notificacioneswwds_11_sgnotificaciontitulo3 ,
                                              AV72Seguridad_notificacioneswwds_12_tfsgnotificacionid ,
                                              AV73Seguridad_notificacioneswwds_13_tfsgnotificacionid_to ,
                                              AV75Seguridad_notificacioneswwds_15_tfsgnotificaciontitulo_sel ,
                                              AV74Seguridad_notificacioneswwds_14_tfsgnotificaciontitulo ,
                                              AV77Seguridad_notificacioneswwds_17_tfsgnotificaciondescripcion_sel ,
                                              AV76Seguridad_notificacioneswwds_16_tfsgnotificaciondescripcion ,
                                              AV78Seguridad_notificacioneswwds_18_tfsgnotificacionfecha ,
                                              AV79Seguridad_notificacioneswwds_19_tfsgnotificacionfecha_to ,
                                              AV81Seguridad_notificacioneswwds_21_tfsgnotificacionusuario_sel ,
                                              AV80Seguridad_notificacioneswwds_20_tfsgnotificacionusuario ,
                                              AV83Seguridad_notificacioneswwds_23_tfsgnotificacionusuariodsc_sel ,
                                              AV82Seguridad_notificacioneswwds_22_tfsgnotificacionusuariodsc ,
                                              AV84Seguridad_notificacioneswwds_24_tfsgnotificacioniconclass_sels.Count ,
                                              AV85Seguridad_notificacioneswwds_25_tfsgnotificaciontusuario ,
                                              AV86Seguridad_notificacioneswwds_26_tfsgnotificaciontusuario_to ,
                                              A2238SGNotificacionTitulo ,
                                              A2237SGNotificacionID ,
                                              A2239SGNotificacionDescripcion ,
                                              A2240SGNotificacionFecha ,
                                              A2241SGNotificacionUsuario ,
                                              A2242SGNotificacionUsuarioDsc ,
                                              A2244SGNotificacionTUsuario ,
                                              AV13OrderedBy ,
                                              AV14OrderedDsc } ,
                                              new int[]{
                                              TypeConstants.SHORT, TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.LONG, TypeConstants.LONG, TypeConstants.DATE, TypeConstants.DATE, TypeConstants.INT,
                                              TypeConstants.SHORT, TypeConstants.SHORT, TypeConstants.LONG, TypeConstants.DATE, TypeConstants.SHORT, TypeConstants.SHORT, TypeConstants.BOOLEAN
                                              }
         });
         lV63Seguridad_notificacioneswwds_3_sgnotificaciontitulo1 = StringUtil.Concat( StringUtil.RTrim( AV63Seguridad_notificacioneswwds_3_sgnotificaciontitulo1), "%", "");
         lV63Seguridad_notificacioneswwds_3_sgnotificaciontitulo1 = StringUtil.Concat( StringUtil.RTrim( AV63Seguridad_notificacioneswwds_3_sgnotificaciontitulo1), "%", "");
         lV67Seguridad_notificacioneswwds_7_sgnotificaciontitulo2 = StringUtil.Concat( StringUtil.RTrim( AV67Seguridad_notificacioneswwds_7_sgnotificaciontitulo2), "%", "");
         lV67Seguridad_notificacioneswwds_7_sgnotificaciontitulo2 = StringUtil.Concat( StringUtil.RTrim( AV67Seguridad_notificacioneswwds_7_sgnotificaciontitulo2), "%", "");
         lV71Seguridad_notificacioneswwds_11_sgnotificaciontitulo3 = StringUtil.Concat( StringUtil.RTrim( AV71Seguridad_notificacioneswwds_11_sgnotificaciontitulo3), "%", "");
         lV71Seguridad_notificacioneswwds_11_sgnotificaciontitulo3 = StringUtil.Concat( StringUtil.RTrim( AV71Seguridad_notificacioneswwds_11_sgnotificaciontitulo3), "%", "");
         lV74Seguridad_notificacioneswwds_14_tfsgnotificaciontitulo = StringUtil.Concat( StringUtil.RTrim( AV74Seguridad_notificacioneswwds_14_tfsgnotificaciontitulo), "%", "");
         lV76Seguridad_notificacioneswwds_16_tfsgnotificaciondescripcion = StringUtil.Concat( StringUtil.RTrim( AV76Seguridad_notificacioneswwds_16_tfsgnotificaciondescripcion), "%", "");
         lV80Seguridad_notificacioneswwds_20_tfsgnotificacionusuario = StringUtil.PadR( StringUtil.RTrim( AV80Seguridad_notificacioneswwds_20_tfsgnotificacionusuario), 10, "%");
         lV82Seguridad_notificacioneswwds_22_tfsgnotificacionusuariodsc = StringUtil.PadR( StringUtil.RTrim( AV82Seguridad_notificacioneswwds_22_tfsgnotificacionusuariodsc), 100, "%");
         /* Using cursor H002S3 */
         pr_default.execute(1, new Object[] {lV63Seguridad_notificacioneswwds_3_sgnotificaciontitulo1, lV63Seguridad_notificacioneswwds_3_sgnotificaciontitulo1, lV67Seguridad_notificacioneswwds_7_sgnotificaciontitulo2, lV67Seguridad_notificacioneswwds_7_sgnotificaciontitulo2, lV71Seguridad_notificacioneswwds_11_sgnotificaciontitulo3, lV71Seguridad_notificacioneswwds_11_sgnotificaciontitulo3, AV72Seguridad_notificacioneswwds_12_tfsgnotificacionid, AV73Seguridad_notificacioneswwds_13_tfsgnotificacionid_to, lV74Seguridad_notificacioneswwds_14_tfsgnotificaciontitulo, AV75Seguridad_notificacioneswwds_15_tfsgnotificaciontitulo_sel, lV76Seguridad_notificacioneswwds_16_tfsgnotificaciondescripcion, AV77Seguridad_notificacioneswwds_17_tfsgnotificaciondescripcion_sel, AV78Seguridad_notificacioneswwds_18_tfsgnotificacionfecha, AV79Seguridad_notificacioneswwds_19_tfsgnotificacionfecha_to, lV80Seguridad_notificacioneswwds_20_tfsgnotificacionusuario, AV81Seguridad_notificacioneswwds_21_tfsgnotificacionusuario_sel, lV82Seguridad_notificacioneswwds_22_tfsgnotificacionusuariodsc, AV83Seguridad_notificacioneswwds_23_tfsgnotificacionusuariodsc_sel, AV85Seguridad_notificacioneswwds_25_tfsgnotificaciontusuario, AV86Seguridad_notificacioneswwds_26_tfsgnotificaciontusuario_to});
         GRID_nRecordCount = H002S3_AGRID_nRecordCount[0];
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
         AV61Seguridad_notificacioneswwds_1_dynamicfiltersselector1 = AV15DynamicFiltersSelector1;
         AV62Seguridad_notificacioneswwds_2_dynamicfiltersoperator1 = AV16DynamicFiltersOperator1;
         AV63Seguridad_notificacioneswwds_3_sgnotificaciontitulo1 = AV17SGNotificacionTitulo1;
         AV64Seguridad_notificacioneswwds_4_dynamicfiltersenabled2 = AV18DynamicFiltersEnabled2;
         AV65Seguridad_notificacioneswwds_5_dynamicfiltersselector2 = AV19DynamicFiltersSelector2;
         AV66Seguridad_notificacioneswwds_6_dynamicfiltersoperator2 = AV20DynamicFiltersOperator2;
         AV67Seguridad_notificacioneswwds_7_sgnotificaciontitulo2 = AV21SGNotificacionTitulo2;
         AV68Seguridad_notificacioneswwds_8_dynamicfiltersenabled3 = AV22DynamicFiltersEnabled3;
         AV69Seguridad_notificacioneswwds_9_dynamicfiltersselector3 = AV23DynamicFiltersSelector3;
         AV70Seguridad_notificacioneswwds_10_dynamicfiltersoperator3 = AV24DynamicFiltersOperator3;
         AV71Seguridad_notificacioneswwds_11_sgnotificaciontitulo3 = AV25SGNotificacionTitulo3;
         AV72Seguridad_notificacioneswwds_12_tfsgnotificacionid = AV31TFSGNotificacionID;
         AV73Seguridad_notificacioneswwds_13_tfsgnotificacionid_to = AV32TFSGNotificacionID_To;
         AV74Seguridad_notificacioneswwds_14_tfsgnotificaciontitulo = AV33TFSGNotificacionTitulo;
         AV75Seguridad_notificacioneswwds_15_tfsgnotificaciontitulo_sel = AV34TFSGNotificacionTitulo_Sel;
         AV76Seguridad_notificacioneswwds_16_tfsgnotificaciondescripcion = AV35TFSGNotificacionDescripcion;
         AV77Seguridad_notificacioneswwds_17_tfsgnotificaciondescripcion_sel = AV36TFSGNotificacionDescripcion_Sel;
         AV78Seguridad_notificacioneswwds_18_tfsgnotificacionfecha = AV37TFSGNotificacionFecha;
         AV79Seguridad_notificacioneswwds_19_tfsgnotificacionfecha_to = AV38TFSGNotificacionFecha_To;
         AV80Seguridad_notificacioneswwds_20_tfsgnotificacionusuario = AV42TFSGNotificacionUsuario;
         AV81Seguridad_notificacioneswwds_21_tfsgnotificacionusuario_sel = AV43TFSGNotificacionUsuario_Sel;
         AV82Seguridad_notificacioneswwds_22_tfsgnotificacionusuariodsc = AV44TFSGNotificacionUsuarioDsc;
         AV83Seguridad_notificacioneswwds_23_tfsgnotificacionusuariodsc_sel = AV45TFSGNotificacionUsuarioDsc_Sel;
         AV84Seguridad_notificacioneswwds_24_tfsgnotificacioniconclass_sels = AV47TFSGNotificacionIconClass_Sels;
         AV85Seguridad_notificacioneswwds_25_tfsgnotificaciontusuario = AV48TFSGNotificacionTUsuario;
         AV86Seguridad_notificacioneswwds_26_tfsgnotificaciontusuario_to = AV49TFSGNotificacionTUsuario_To;
         GRID_nFirstRecordOnPage = 0;
         GxWebStd.gx_hidden_field( context, "GRID_nFirstRecordOnPage", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRID_nFirstRecordOnPage), 15, 0, ".", "")));
         if ( isFullAjaxMode( ) )
         {
            gxgrGrid_refresh( subGrid_Rows, AV15DynamicFiltersSelector1, AV16DynamicFiltersOperator1, AV17SGNotificacionTitulo1, AV19DynamicFiltersSelector2, AV20DynamicFiltersOperator2, AV21SGNotificacionTitulo2, AV23DynamicFiltersSelector3, AV24DynamicFiltersOperator3, AV25SGNotificacionTitulo3, AV60Pgmname, AV18DynamicFiltersEnabled2, AV22DynamicFiltersEnabled3, AV31TFSGNotificacionID, AV32TFSGNotificacionID_To, AV33TFSGNotificacionTitulo, AV34TFSGNotificacionTitulo_Sel, AV35TFSGNotificacionDescripcion, AV36TFSGNotificacionDescripcion_Sel, AV37TFSGNotificacionFecha, AV38TFSGNotificacionFecha_To, AV42TFSGNotificacionUsuario, AV43TFSGNotificacionUsuario_Sel, AV44TFSGNotificacionUsuarioDsc, AV45TFSGNotificacionUsuarioDsc_Sel, AV47TFSGNotificacionIconClass_Sels, AV48TFSGNotificacionTUsuario, AV49TFSGNotificacionTUsuario_To, AV13OrderedBy, AV14OrderedDsc, AV10GridState, AV27DynamicFiltersIgnoreFirst, AV26DynamicFiltersRemoving) ;
         }
         send_integrity_footer_hashes( ) ;
         return 0 ;
      }

      protected short subgrid_nextpage( )
      {
         AV61Seguridad_notificacioneswwds_1_dynamicfiltersselector1 = AV15DynamicFiltersSelector1;
         AV62Seguridad_notificacioneswwds_2_dynamicfiltersoperator1 = AV16DynamicFiltersOperator1;
         AV63Seguridad_notificacioneswwds_3_sgnotificaciontitulo1 = AV17SGNotificacionTitulo1;
         AV64Seguridad_notificacioneswwds_4_dynamicfiltersenabled2 = AV18DynamicFiltersEnabled2;
         AV65Seguridad_notificacioneswwds_5_dynamicfiltersselector2 = AV19DynamicFiltersSelector2;
         AV66Seguridad_notificacioneswwds_6_dynamicfiltersoperator2 = AV20DynamicFiltersOperator2;
         AV67Seguridad_notificacioneswwds_7_sgnotificaciontitulo2 = AV21SGNotificacionTitulo2;
         AV68Seguridad_notificacioneswwds_8_dynamicfiltersenabled3 = AV22DynamicFiltersEnabled3;
         AV69Seguridad_notificacioneswwds_9_dynamicfiltersselector3 = AV23DynamicFiltersSelector3;
         AV70Seguridad_notificacioneswwds_10_dynamicfiltersoperator3 = AV24DynamicFiltersOperator3;
         AV71Seguridad_notificacioneswwds_11_sgnotificaciontitulo3 = AV25SGNotificacionTitulo3;
         AV72Seguridad_notificacioneswwds_12_tfsgnotificacionid = AV31TFSGNotificacionID;
         AV73Seguridad_notificacioneswwds_13_tfsgnotificacionid_to = AV32TFSGNotificacionID_To;
         AV74Seguridad_notificacioneswwds_14_tfsgnotificaciontitulo = AV33TFSGNotificacionTitulo;
         AV75Seguridad_notificacioneswwds_15_tfsgnotificaciontitulo_sel = AV34TFSGNotificacionTitulo_Sel;
         AV76Seguridad_notificacioneswwds_16_tfsgnotificaciondescripcion = AV35TFSGNotificacionDescripcion;
         AV77Seguridad_notificacioneswwds_17_tfsgnotificaciondescripcion_sel = AV36TFSGNotificacionDescripcion_Sel;
         AV78Seguridad_notificacioneswwds_18_tfsgnotificacionfecha = AV37TFSGNotificacionFecha;
         AV79Seguridad_notificacioneswwds_19_tfsgnotificacionfecha_to = AV38TFSGNotificacionFecha_To;
         AV80Seguridad_notificacioneswwds_20_tfsgnotificacionusuario = AV42TFSGNotificacionUsuario;
         AV81Seguridad_notificacioneswwds_21_tfsgnotificacionusuario_sel = AV43TFSGNotificacionUsuario_Sel;
         AV82Seguridad_notificacioneswwds_22_tfsgnotificacionusuariodsc = AV44TFSGNotificacionUsuarioDsc;
         AV83Seguridad_notificacioneswwds_23_tfsgnotificacionusuariodsc_sel = AV45TFSGNotificacionUsuarioDsc_Sel;
         AV84Seguridad_notificacioneswwds_24_tfsgnotificacioniconclass_sels = AV47TFSGNotificacionIconClass_Sels;
         AV85Seguridad_notificacioneswwds_25_tfsgnotificaciontusuario = AV48TFSGNotificacionTUsuario;
         AV86Seguridad_notificacioneswwds_26_tfsgnotificaciontusuario_to = AV49TFSGNotificacionTUsuario_To;
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
            gxgrGrid_refresh( subGrid_Rows, AV15DynamicFiltersSelector1, AV16DynamicFiltersOperator1, AV17SGNotificacionTitulo1, AV19DynamicFiltersSelector2, AV20DynamicFiltersOperator2, AV21SGNotificacionTitulo2, AV23DynamicFiltersSelector3, AV24DynamicFiltersOperator3, AV25SGNotificacionTitulo3, AV60Pgmname, AV18DynamicFiltersEnabled2, AV22DynamicFiltersEnabled3, AV31TFSGNotificacionID, AV32TFSGNotificacionID_To, AV33TFSGNotificacionTitulo, AV34TFSGNotificacionTitulo_Sel, AV35TFSGNotificacionDescripcion, AV36TFSGNotificacionDescripcion_Sel, AV37TFSGNotificacionFecha, AV38TFSGNotificacionFecha_To, AV42TFSGNotificacionUsuario, AV43TFSGNotificacionUsuario_Sel, AV44TFSGNotificacionUsuarioDsc, AV45TFSGNotificacionUsuarioDsc_Sel, AV47TFSGNotificacionIconClass_Sels, AV48TFSGNotificacionTUsuario, AV49TFSGNotificacionTUsuario_To, AV13OrderedBy, AV14OrderedDsc, AV10GridState, AV27DynamicFiltersIgnoreFirst, AV26DynamicFiltersRemoving) ;
         }
         send_integrity_footer_hashes( ) ;
         return (short)(((GRID_nEOF==0) ? 0 : 2)) ;
      }

      protected short subgrid_previouspage( )
      {
         AV61Seguridad_notificacioneswwds_1_dynamicfiltersselector1 = AV15DynamicFiltersSelector1;
         AV62Seguridad_notificacioneswwds_2_dynamicfiltersoperator1 = AV16DynamicFiltersOperator1;
         AV63Seguridad_notificacioneswwds_3_sgnotificaciontitulo1 = AV17SGNotificacionTitulo1;
         AV64Seguridad_notificacioneswwds_4_dynamicfiltersenabled2 = AV18DynamicFiltersEnabled2;
         AV65Seguridad_notificacioneswwds_5_dynamicfiltersselector2 = AV19DynamicFiltersSelector2;
         AV66Seguridad_notificacioneswwds_6_dynamicfiltersoperator2 = AV20DynamicFiltersOperator2;
         AV67Seguridad_notificacioneswwds_7_sgnotificaciontitulo2 = AV21SGNotificacionTitulo2;
         AV68Seguridad_notificacioneswwds_8_dynamicfiltersenabled3 = AV22DynamicFiltersEnabled3;
         AV69Seguridad_notificacioneswwds_9_dynamicfiltersselector3 = AV23DynamicFiltersSelector3;
         AV70Seguridad_notificacioneswwds_10_dynamicfiltersoperator3 = AV24DynamicFiltersOperator3;
         AV71Seguridad_notificacioneswwds_11_sgnotificaciontitulo3 = AV25SGNotificacionTitulo3;
         AV72Seguridad_notificacioneswwds_12_tfsgnotificacionid = AV31TFSGNotificacionID;
         AV73Seguridad_notificacioneswwds_13_tfsgnotificacionid_to = AV32TFSGNotificacionID_To;
         AV74Seguridad_notificacioneswwds_14_tfsgnotificaciontitulo = AV33TFSGNotificacionTitulo;
         AV75Seguridad_notificacioneswwds_15_tfsgnotificaciontitulo_sel = AV34TFSGNotificacionTitulo_Sel;
         AV76Seguridad_notificacioneswwds_16_tfsgnotificaciondescripcion = AV35TFSGNotificacionDescripcion;
         AV77Seguridad_notificacioneswwds_17_tfsgnotificaciondescripcion_sel = AV36TFSGNotificacionDescripcion_Sel;
         AV78Seguridad_notificacioneswwds_18_tfsgnotificacionfecha = AV37TFSGNotificacionFecha;
         AV79Seguridad_notificacioneswwds_19_tfsgnotificacionfecha_to = AV38TFSGNotificacionFecha_To;
         AV80Seguridad_notificacioneswwds_20_tfsgnotificacionusuario = AV42TFSGNotificacionUsuario;
         AV81Seguridad_notificacioneswwds_21_tfsgnotificacionusuario_sel = AV43TFSGNotificacionUsuario_Sel;
         AV82Seguridad_notificacioneswwds_22_tfsgnotificacionusuariodsc = AV44TFSGNotificacionUsuarioDsc;
         AV83Seguridad_notificacioneswwds_23_tfsgnotificacionusuariodsc_sel = AV45TFSGNotificacionUsuarioDsc_Sel;
         AV84Seguridad_notificacioneswwds_24_tfsgnotificacioniconclass_sels = AV47TFSGNotificacionIconClass_Sels;
         AV85Seguridad_notificacioneswwds_25_tfsgnotificaciontusuario = AV48TFSGNotificacionTUsuario;
         AV86Seguridad_notificacioneswwds_26_tfsgnotificaciontusuario_to = AV49TFSGNotificacionTUsuario_To;
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
            gxgrGrid_refresh( subGrid_Rows, AV15DynamicFiltersSelector1, AV16DynamicFiltersOperator1, AV17SGNotificacionTitulo1, AV19DynamicFiltersSelector2, AV20DynamicFiltersOperator2, AV21SGNotificacionTitulo2, AV23DynamicFiltersSelector3, AV24DynamicFiltersOperator3, AV25SGNotificacionTitulo3, AV60Pgmname, AV18DynamicFiltersEnabled2, AV22DynamicFiltersEnabled3, AV31TFSGNotificacionID, AV32TFSGNotificacionID_To, AV33TFSGNotificacionTitulo, AV34TFSGNotificacionTitulo_Sel, AV35TFSGNotificacionDescripcion, AV36TFSGNotificacionDescripcion_Sel, AV37TFSGNotificacionFecha, AV38TFSGNotificacionFecha_To, AV42TFSGNotificacionUsuario, AV43TFSGNotificacionUsuario_Sel, AV44TFSGNotificacionUsuarioDsc, AV45TFSGNotificacionUsuarioDsc_Sel, AV47TFSGNotificacionIconClass_Sels, AV48TFSGNotificacionTUsuario, AV49TFSGNotificacionTUsuario_To, AV13OrderedBy, AV14OrderedDsc, AV10GridState, AV27DynamicFiltersIgnoreFirst, AV26DynamicFiltersRemoving) ;
         }
         send_integrity_footer_hashes( ) ;
         return 0 ;
      }

      protected short subgrid_lastpage( )
      {
         AV61Seguridad_notificacioneswwds_1_dynamicfiltersselector1 = AV15DynamicFiltersSelector1;
         AV62Seguridad_notificacioneswwds_2_dynamicfiltersoperator1 = AV16DynamicFiltersOperator1;
         AV63Seguridad_notificacioneswwds_3_sgnotificaciontitulo1 = AV17SGNotificacionTitulo1;
         AV64Seguridad_notificacioneswwds_4_dynamicfiltersenabled2 = AV18DynamicFiltersEnabled2;
         AV65Seguridad_notificacioneswwds_5_dynamicfiltersselector2 = AV19DynamicFiltersSelector2;
         AV66Seguridad_notificacioneswwds_6_dynamicfiltersoperator2 = AV20DynamicFiltersOperator2;
         AV67Seguridad_notificacioneswwds_7_sgnotificaciontitulo2 = AV21SGNotificacionTitulo2;
         AV68Seguridad_notificacioneswwds_8_dynamicfiltersenabled3 = AV22DynamicFiltersEnabled3;
         AV69Seguridad_notificacioneswwds_9_dynamicfiltersselector3 = AV23DynamicFiltersSelector3;
         AV70Seguridad_notificacioneswwds_10_dynamicfiltersoperator3 = AV24DynamicFiltersOperator3;
         AV71Seguridad_notificacioneswwds_11_sgnotificaciontitulo3 = AV25SGNotificacionTitulo3;
         AV72Seguridad_notificacioneswwds_12_tfsgnotificacionid = AV31TFSGNotificacionID;
         AV73Seguridad_notificacioneswwds_13_tfsgnotificacionid_to = AV32TFSGNotificacionID_To;
         AV74Seguridad_notificacioneswwds_14_tfsgnotificaciontitulo = AV33TFSGNotificacionTitulo;
         AV75Seguridad_notificacioneswwds_15_tfsgnotificaciontitulo_sel = AV34TFSGNotificacionTitulo_Sel;
         AV76Seguridad_notificacioneswwds_16_tfsgnotificaciondescripcion = AV35TFSGNotificacionDescripcion;
         AV77Seguridad_notificacioneswwds_17_tfsgnotificaciondescripcion_sel = AV36TFSGNotificacionDescripcion_Sel;
         AV78Seguridad_notificacioneswwds_18_tfsgnotificacionfecha = AV37TFSGNotificacionFecha;
         AV79Seguridad_notificacioneswwds_19_tfsgnotificacionfecha_to = AV38TFSGNotificacionFecha_To;
         AV80Seguridad_notificacioneswwds_20_tfsgnotificacionusuario = AV42TFSGNotificacionUsuario;
         AV81Seguridad_notificacioneswwds_21_tfsgnotificacionusuario_sel = AV43TFSGNotificacionUsuario_Sel;
         AV82Seguridad_notificacioneswwds_22_tfsgnotificacionusuariodsc = AV44TFSGNotificacionUsuarioDsc;
         AV83Seguridad_notificacioneswwds_23_tfsgnotificacionusuariodsc_sel = AV45TFSGNotificacionUsuarioDsc_Sel;
         AV84Seguridad_notificacioneswwds_24_tfsgnotificacioniconclass_sels = AV47TFSGNotificacionIconClass_Sels;
         AV85Seguridad_notificacioneswwds_25_tfsgnotificaciontusuario = AV48TFSGNotificacionTUsuario;
         AV86Seguridad_notificacioneswwds_26_tfsgnotificaciontusuario_to = AV49TFSGNotificacionTUsuario_To;
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
            gxgrGrid_refresh( subGrid_Rows, AV15DynamicFiltersSelector1, AV16DynamicFiltersOperator1, AV17SGNotificacionTitulo1, AV19DynamicFiltersSelector2, AV20DynamicFiltersOperator2, AV21SGNotificacionTitulo2, AV23DynamicFiltersSelector3, AV24DynamicFiltersOperator3, AV25SGNotificacionTitulo3, AV60Pgmname, AV18DynamicFiltersEnabled2, AV22DynamicFiltersEnabled3, AV31TFSGNotificacionID, AV32TFSGNotificacionID_To, AV33TFSGNotificacionTitulo, AV34TFSGNotificacionTitulo_Sel, AV35TFSGNotificacionDescripcion, AV36TFSGNotificacionDescripcion_Sel, AV37TFSGNotificacionFecha, AV38TFSGNotificacionFecha_To, AV42TFSGNotificacionUsuario, AV43TFSGNotificacionUsuario_Sel, AV44TFSGNotificacionUsuarioDsc, AV45TFSGNotificacionUsuarioDsc_Sel, AV47TFSGNotificacionIconClass_Sels, AV48TFSGNotificacionTUsuario, AV49TFSGNotificacionTUsuario_To, AV13OrderedBy, AV14OrderedDsc, AV10GridState, AV27DynamicFiltersIgnoreFirst, AV26DynamicFiltersRemoving) ;
         }
         send_integrity_footer_hashes( ) ;
         return 0 ;
      }

      protected int subgrid_gotopage( int nPageNo )
      {
         AV61Seguridad_notificacioneswwds_1_dynamicfiltersselector1 = AV15DynamicFiltersSelector1;
         AV62Seguridad_notificacioneswwds_2_dynamicfiltersoperator1 = AV16DynamicFiltersOperator1;
         AV63Seguridad_notificacioneswwds_3_sgnotificaciontitulo1 = AV17SGNotificacionTitulo1;
         AV64Seguridad_notificacioneswwds_4_dynamicfiltersenabled2 = AV18DynamicFiltersEnabled2;
         AV65Seguridad_notificacioneswwds_5_dynamicfiltersselector2 = AV19DynamicFiltersSelector2;
         AV66Seguridad_notificacioneswwds_6_dynamicfiltersoperator2 = AV20DynamicFiltersOperator2;
         AV67Seguridad_notificacioneswwds_7_sgnotificaciontitulo2 = AV21SGNotificacionTitulo2;
         AV68Seguridad_notificacioneswwds_8_dynamicfiltersenabled3 = AV22DynamicFiltersEnabled3;
         AV69Seguridad_notificacioneswwds_9_dynamicfiltersselector3 = AV23DynamicFiltersSelector3;
         AV70Seguridad_notificacioneswwds_10_dynamicfiltersoperator3 = AV24DynamicFiltersOperator3;
         AV71Seguridad_notificacioneswwds_11_sgnotificaciontitulo3 = AV25SGNotificacionTitulo3;
         AV72Seguridad_notificacioneswwds_12_tfsgnotificacionid = AV31TFSGNotificacionID;
         AV73Seguridad_notificacioneswwds_13_tfsgnotificacionid_to = AV32TFSGNotificacionID_To;
         AV74Seguridad_notificacioneswwds_14_tfsgnotificaciontitulo = AV33TFSGNotificacionTitulo;
         AV75Seguridad_notificacioneswwds_15_tfsgnotificaciontitulo_sel = AV34TFSGNotificacionTitulo_Sel;
         AV76Seguridad_notificacioneswwds_16_tfsgnotificaciondescripcion = AV35TFSGNotificacionDescripcion;
         AV77Seguridad_notificacioneswwds_17_tfsgnotificaciondescripcion_sel = AV36TFSGNotificacionDescripcion_Sel;
         AV78Seguridad_notificacioneswwds_18_tfsgnotificacionfecha = AV37TFSGNotificacionFecha;
         AV79Seguridad_notificacioneswwds_19_tfsgnotificacionfecha_to = AV38TFSGNotificacionFecha_To;
         AV80Seguridad_notificacioneswwds_20_tfsgnotificacionusuario = AV42TFSGNotificacionUsuario;
         AV81Seguridad_notificacioneswwds_21_tfsgnotificacionusuario_sel = AV43TFSGNotificacionUsuario_Sel;
         AV82Seguridad_notificacioneswwds_22_tfsgnotificacionusuariodsc = AV44TFSGNotificacionUsuarioDsc;
         AV83Seguridad_notificacioneswwds_23_tfsgnotificacionusuariodsc_sel = AV45TFSGNotificacionUsuarioDsc_Sel;
         AV84Seguridad_notificacioneswwds_24_tfsgnotificacioniconclass_sels = AV47TFSGNotificacionIconClass_Sels;
         AV85Seguridad_notificacioneswwds_25_tfsgnotificaciontusuario = AV48TFSGNotificacionTUsuario;
         AV86Seguridad_notificacioneswwds_26_tfsgnotificaciontusuario_to = AV49TFSGNotificacionTUsuario_To;
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
            gxgrGrid_refresh( subGrid_Rows, AV15DynamicFiltersSelector1, AV16DynamicFiltersOperator1, AV17SGNotificacionTitulo1, AV19DynamicFiltersSelector2, AV20DynamicFiltersOperator2, AV21SGNotificacionTitulo2, AV23DynamicFiltersSelector3, AV24DynamicFiltersOperator3, AV25SGNotificacionTitulo3, AV60Pgmname, AV18DynamicFiltersEnabled2, AV22DynamicFiltersEnabled3, AV31TFSGNotificacionID, AV32TFSGNotificacionID_To, AV33TFSGNotificacionTitulo, AV34TFSGNotificacionTitulo_Sel, AV35TFSGNotificacionDescripcion, AV36TFSGNotificacionDescripcion_Sel, AV37TFSGNotificacionFecha, AV38TFSGNotificacionFecha_To, AV42TFSGNotificacionUsuario, AV43TFSGNotificacionUsuario_Sel, AV44TFSGNotificacionUsuarioDsc, AV45TFSGNotificacionUsuarioDsc_Sel, AV47TFSGNotificacionIconClass_Sels, AV48TFSGNotificacionTUsuario, AV49TFSGNotificacionTUsuario_To, AV13OrderedBy, AV14OrderedDsc, AV10GridState, AV27DynamicFiltersIgnoreFirst, AV26DynamicFiltersRemoving) ;
         }
         send_integrity_footer_hashes( ) ;
         return (int)(0) ;
      }

      protected void before_start_formulas( )
      {
         AV60Pgmname = "Seguridad.NotificacionesWW";
         context.Gx_err = 0;
         fix_multi_value_controls( ) ;
      }

      protected void STRUP2S0( )
      {
         /* Before Start, stand alone formulas. */
         before_start_formulas( ) ;
         /* Execute Start event if defined. */
         context.wbGlbDoneStart = 0;
         /* Execute user event: Start */
         E242S2 ();
         context.wbGlbDoneStart = 1;
         /* After Start, stand alone formulas. */
         if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
         {
            /* Read saved SDTs. */
            ajax_req_read_hidden_sdt(cgiGet( "vAGEXPORTDATA"), AV56AGExportData);
            ajax_req_read_hidden_sdt(cgiGet( "vDDO_TITLESETTINGSICONS"), AV50DDO_TitleSettingsIcons);
            /* Read saved values. */
            nRC_GXsfl_101 = (int)(context.localUtil.CToN( cgiGet( "nRC_GXsfl_101"), ".", ","));
            AV52GridCurrentPage = (long)(context.localUtil.CToN( cgiGet( "vGRIDCURRENTPAGE"), ".", ","));
            AV53GridPageCount = (long)(context.localUtil.CToN( cgiGet( "vGRIDPAGECOUNT"), ".", ","));
            AV54GridAppliedFilters = cgiGet( "vGRIDAPPLIEDFILTERS");
            AV39DDO_SGNotificacionFechaAuxDate = context.localUtil.CToD( cgiGet( "vDDO_SGNOTIFICACIONFECHAAUXDATE"), 0);
            AV40DDO_SGNotificacionFechaAuxDateTo = context.localUtil.CToD( cgiGet( "vDDO_SGNOTIFICACIONFECHAAUXDATETO"), 0);
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
            cmbavDynamicfiltersselector1.Name = cmbavDynamicfiltersselector1_Internalname;
            cmbavDynamicfiltersselector1.CurrentValue = cgiGet( cmbavDynamicfiltersselector1_Internalname);
            AV15DynamicFiltersSelector1 = cgiGet( cmbavDynamicfiltersselector1_Internalname);
            AssignAttri("", false, "AV15DynamicFiltersSelector1", AV15DynamicFiltersSelector1);
            cmbavDynamicfiltersoperator1.Name = cmbavDynamicfiltersoperator1_Internalname;
            cmbavDynamicfiltersoperator1.CurrentValue = cgiGet( cmbavDynamicfiltersoperator1_Internalname);
            AV16DynamicFiltersOperator1 = (short)(NumberUtil.Val( cgiGet( cmbavDynamicfiltersoperator1_Internalname), "."));
            AssignAttri("", false, "AV16DynamicFiltersOperator1", StringUtil.LTrimStr( (decimal)(AV16DynamicFiltersOperator1), 4, 0));
            AV17SGNotificacionTitulo1 = cgiGet( edtavSgnotificaciontitulo1_Internalname);
            AssignAttri("", false, "AV17SGNotificacionTitulo1", AV17SGNotificacionTitulo1);
            cmbavDynamicfiltersselector2.Name = cmbavDynamicfiltersselector2_Internalname;
            cmbavDynamicfiltersselector2.CurrentValue = cgiGet( cmbavDynamicfiltersselector2_Internalname);
            AV19DynamicFiltersSelector2 = cgiGet( cmbavDynamicfiltersselector2_Internalname);
            AssignAttri("", false, "AV19DynamicFiltersSelector2", AV19DynamicFiltersSelector2);
            cmbavDynamicfiltersoperator2.Name = cmbavDynamicfiltersoperator2_Internalname;
            cmbavDynamicfiltersoperator2.CurrentValue = cgiGet( cmbavDynamicfiltersoperator2_Internalname);
            AV20DynamicFiltersOperator2 = (short)(NumberUtil.Val( cgiGet( cmbavDynamicfiltersoperator2_Internalname), "."));
            AssignAttri("", false, "AV20DynamicFiltersOperator2", StringUtil.LTrimStr( (decimal)(AV20DynamicFiltersOperator2), 4, 0));
            AV21SGNotificacionTitulo2 = cgiGet( edtavSgnotificaciontitulo2_Internalname);
            AssignAttri("", false, "AV21SGNotificacionTitulo2", AV21SGNotificacionTitulo2);
            cmbavDynamicfiltersselector3.Name = cmbavDynamicfiltersselector3_Internalname;
            cmbavDynamicfiltersselector3.CurrentValue = cgiGet( cmbavDynamicfiltersselector3_Internalname);
            AV23DynamicFiltersSelector3 = cgiGet( cmbavDynamicfiltersselector3_Internalname);
            AssignAttri("", false, "AV23DynamicFiltersSelector3", AV23DynamicFiltersSelector3);
            cmbavDynamicfiltersoperator3.Name = cmbavDynamicfiltersoperator3_Internalname;
            cmbavDynamicfiltersoperator3.CurrentValue = cgiGet( cmbavDynamicfiltersoperator3_Internalname);
            AV24DynamicFiltersOperator3 = (short)(NumberUtil.Val( cgiGet( cmbavDynamicfiltersoperator3_Internalname), "."));
            AssignAttri("", false, "AV24DynamicFiltersOperator3", StringUtil.LTrimStr( (decimal)(AV24DynamicFiltersOperator3), 4, 0));
            AV25SGNotificacionTitulo3 = cgiGet( edtavSgnotificaciontitulo3_Internalname);
            AssignAttri("", false, "AV25SGNotificacionTitulo3", AV25SGNotificacionTitulo3);
            AV41DDO_SGNotificacionFechaAuxDateText = cgiGet( edtavDdo_sgnotificacionfechaauxdatetext_Internalname);
            AssignAttri("", false, "AV41DDO_SGNotificacionFechaAuxDateText", AV41DDO_SGNotificacionFechaAuxDateText);
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
            if ( StringUtil.StrCmp(cgiGet( "GXH_vSGNOTIFICACIONTITULO1"), AV17SGNotificacionTitulo1) != 0 )
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
            if ( StringUtil.StrCmp(cgiGet( "GXH_vSGNOTIFICACIONTITULO2"), AV21SGNotificacionTitulo2) != 0 )
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
            if ( StringUtil.StrCmp(cgiGet( "GXH_vSGNOTIFICACIONTITULO3"), AV25SGNotificacionTitulo3) != 0 )
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
         E242S2 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
      }

      protected void E242S2( )
      {
         /* Start Routine */
         returnInSub = false;
         this.executeUsercontrolMethod("", false, "TFSGNOTIFICACIONFECHA_RANGEPICKERContainer", "Attach", "", new Object[] {(string)edtavDdo_sgnotificacionfechaauxdatetext_Internalname});
         subGrid_Rows = 10;
         GxWebStd.gx_hidden_field( context, "GRID_Rows", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid_Rows), 6, 0, ".", "")));
         Grid_empowerer_Gridinternalname = subGrid_Internalname;
         ucGrid_empowerer.SendProperty(context, "", false, Grid_empowerer_Internalname, "GridInternalName", Grid_empowerer_Gridinternalname);
         lblJsdynamicfilters_Caption = "";
         AssignProp("", false, lblJsdynamicfilters_Internalname, "Caption", lblJsdynamicfilters_Caption, true);
         AV15DynamicFiltersSelector1 = "SGNOTIFICACIONTITULO";
         AssignAttri("", false, "AV15DynamicFiltersSelector1", AV15DynamicFiltersSelector1);
         /* Execute user subroutine: 'ENABLEDYNAMICFILTERS1' */
         S112 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
         AV19DynamicFiltersSelector2 = "SGNOTIFICACIONTITULO";
         AssignAttri("", false, "AV19DynamicFiltersSelector2", AV19DynamicFiltersSelector2);
         /* Execute user subroutine: 'ENABLEDYNAMICFILTERS2' */
         S122 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
         AV23DynamicFiltersSelector3 = "SGNOTIFICACIONTITULO";
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
         AV56AGExportData = new GXBaseCollection<GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTDropDownOptionsData_Item>( context, "Item", "");
         AV57AGExportDataItem = new GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTDropDownOptionsData_Item(context);
         AV57AGExportDataItem.gxTpr_Title = "PDF";
         AV57AGExportDataItem.gxTpr_Icon = context.convertURL( (string)(context.GetImagePath( "776fb79c-a0a1-4302-b5e5-d773dbe1a297", "", context.GetTheme( ))));
         AV57AGExportDataItem.gxTpr_Eventkey = "ExportReport";
         AV57AGExportDataItem.gxTpr_Isdivider = false;
         AV56AGExportData.Add(AV57AGExportDataItem, 0);
         AV57AGExportDataItem = new GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTDropDownOptionsData_Item(context);
         AV57AGExportDataItem.gxTpr_Title = "Excel";
         AV57AGExportDataItem.gxTpr_Icon = context.convertURL( (string)(context.GetImagePath( "da69a816-fd11-445b-8aaf-1a2f7f1acc93", "", context.GetTheme( ))));
         AV57AGExportDataItem.gxTpr_Eventkey = "Export";
         AV57AGExportDataItem.gxTpr_Isdivider = false;
         AV56AGExportData.Add(AV57AGExportDataItem, 0);
         Ddo_grid_Gridinternalname = subGrid_Internalname;
         ucDdo_grid.SendProperty(context, "", false, Ddo_grid_Internalname, "GridInternalName", Ddo_grid_Gridinternalname);
         Form.Caption = " Notificaciones";
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
         GXt_SdtDVB_SDTDropDownOptionsTitleSettingsIcons1 = AV50DDO_TitleSettingsIcons;
         new GeneXus.Programs.wwpbaseobjects.getwwptitlesettingsicons(context ).execute( out  GXt_SdtDVB_SDTDropDownOptionsTitleSettingsIcons1) ;
         AV50DDO_TitleSettingsIcons = GXt_SdtDVB_SDTDropDownOptionsTitleSettingsIcons1;
         Gridpaginationbar_Rowsperpageselectedvalue = subGrid_Rows;
         ucGridpaginationbar.SendProperty(context, "", false, Gridpaginationbar_Internalname, "RowsPerPageSelectedValue", StringUtil.LTrimStr( (decimal)(Gridpaginationbar_Rowsperpageselectedvalue), 9, 0));
      }

      protected void E252S2( )
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
         AV52GridCurrentPage = subGrid_fnc_Currentpage( );
         AssignAttri("", false, "AV52GridCurrentPage", StringUtil.LTrimStr( (decimal)(AV52GridCurrentPage), 10, 0));
         AV53GridPageCount = subGrid_fnc_Pagecount( );
         AssignAttri("", false, "AV53GridPageCount", StringUtil.LTrimStr( (decimal)(AV53GridPageCount), 10, 0));
         GXt_char2 = AV54GridAppliedFilters;
         new GeneXus.Programs.wwpbaseobjects.wwp_getappliedfiltersdescription(context ).execute(  AV60Pgmname, out  GXt_char2) ;
         AV54GridAppliedFilters = GXt_char2;
         AssignAttri("", false, "AV54GridAppliedFilters", AV54GridAppliedFilters);
         AV61Seguridad_notificacioneswwds_1_dynamicfiltersselector1 = AV15DynamicFiltersSelector1;
         AV62Seguridad_notificacioneswwds_2_dynamicfiltersoperator1 = AV16DynamicFiltersOperator1;
         AV63Seguridad_notificacioneswwds_3_sgnotificaciontitulo1 = AV17SGNotificacionTitulo1;
         AV64Seguridad_notificacioneswwds_4_dynamicfiltersenabled2 = AV18DynamicFiltersEnabled2;
         AV65Seguridad_notificacioneswwds_5_dynamicfiltersselector2 = AV19DynamicFiltersSelector2;
         AV66Seguridad_notificacioneswwds_6_dynamicfiltersoperator2 = AV20DynamicFiltersOperator2;
         AV67Seguridad_notificacioneswwds_7_sgnotificaciontitulo2 = AV21SGNotificacionTitulo2;
         AV68Seguridad_notificacioneswwds_8_dynamicfiltersenabled3 = AV22DynamicFiltersEnabled3;
         AV69Seguridad_notificacioneswwds_9_dynamicfiltersselector3 = AV23DynamicFiltersSelector3;
         AV70Seguridad_notificacioneswwds_10_dynamicfiltersoperator3 = AV24DynamicFiltersOperator3;
         AV71Seguridad_notificacioneswwds_11_sgnotificaciontitulo3 = AV25SGNotificacionTitulo3;
         AV72Seguridad_notificacioneswwds_12_tfsgnotificacionid = AV31TFSGNotificacionID;
         AV73Seguridad_notificacioneswwds_13_tfsgnotificacionid_to = AV32TFSGNotificacionID_To;
         AV74Seguridad_notificacioneswwds_14_tfsgnotificaciontitulo = AV33TFSGNotificacionTitulo;
         AV75Seguridad_notificacioneswwds_15_tfsgnotificaciontitulo_sel = AV34TFSGNotificacionTitulo_Sel;
         AV76Seguridad_notificacioneswwds_16_tfsgnotificaciondescripcion = AV35TFSGNotificacionDescripcion;
         AV77Seguridad_notificacioneswwds_17_tfsgnotificaciondescripcion_sel = AV36TFSGNotificacionDescripcion_Sel;
         AV78Seguridad_notificacioneswwds_18_tfsgnotificacionfecha = AV37TFSGNotificacionFecha;
         AV79Seguridad_notificacioneswwds_19_tfsgnotificacionfecha_to = AV38TFSGNotificacionFecha_To;
         AV80Seguridad_notificacioneswwds_20_tfsgnotificacionusuario = AV42TFSGNotificacionUsuario;
         AV81Seguridad_notificacioneswwds_21_tfsgnotificacionusuario_sel = AV43TFSGNotificacionUsuario_Sel;
         AV82Seguridad_notificacioneswwds_22_tfsgnotificacionusuariodsc = AV44TFSGNotificacionUsuarioDsc;
         AV83Seguridad_notificacioneswwds_23_tfsgnotificacionusuariodsc_sel = AV45TFSGNotificacionUsuarioDsc_Sel;
         AV84Seguridad_notificacioneswwds_24_tfsgnotificacioniconclass_sels = AV47TFSGNotificacionIconClass_Sels;
         AV85Seguridad_notificacioneswwds_25_tfsgnotificaciontusuario = AV48TFSGNotificacionTUsuario;
         AV86Seguridad_notificacioneswwds_26_tfsgnotificaciontusuario_to = AV49TFSGNotificacionTUsuario_To;
         /*  Sending Event outputs  */
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV10GridState", AV10GridState);
      }

      protected void E112S2( )
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
            AV51PageToGo = (int)(NumberUtil.Val( Gridpaginationbar_Selectedpage, "."));
            subgrid_gotopage( AV51PageToGo) ;
         }
      }

      protected void E122S2( )
      {
         /* Gridpaginationbar_Changerowsperpage Routine */
         returnInSub = false;
         subGrid_Rows = Gridpaginationbar_Rowsperpageselectedvalue;
         GxWebStd.gx_hidden_field( context, "GRID_Rows", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid_Rows), 6, 0, ".", "")));
         subgrid_firstpage( ) ;
         /*  Sending Event outputs  */
      }

      protected void E142S2( )
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
            if ( StringUtil.StrCmp(Ddo_grid_Selectedcolumn, "SGNotificacionID") == 0 )
            {
               AV31TFSGNotificacionID = (long)(NumberUtil.Val( Ddo_grid_Filteredtext_get, "."));
               AssignAttri("", false, "AV31TFSGNotificacionID", StringUtil.LTrimStr( (decimal)(AV31TFSGNotificacionID), 10, 0));
               AV32TFSGNotificacionID_To = (long)(NumberUtil.Val( Ddo_grid_Filteredtextto_get, "."));
               AssignAttri("", false, "AV32TFSGNotificacionID_To", StringUtil.LTrimStr( (decimal)(AV32TFSGNotificacionID_To), 10, 0));
            }
            else if ( StringUtil.StrCmp(Ddo_grid_Selectedcolumn, "SGNotificacionTitulo") == 0 )
            {
               AV33TFSGNotificacionTitulo = Ddo_grid_Filteredtext_get;
               AssignAttri("", false, "AV33TFSGNotificacionTitulo", AV33TFSGNotificacionTitulo);
               AV34TFSGNotificacionTitulo_Sel = Ddo_grid_Selectedvalue_get;
               AssignAttri("", false, "AV34TFSGNotificacionTitulo_Sel", AV34TFSGNotificacionTitulo_Sel);
            }
            else if ( StringUtil.StrCmp(Ddo_grid_Selectedcolumn, "SGNotificacionDescripcion") == 0 )
            {
               AV35TFSGNotificacionDescripcion = Ddo_grid_Filteredtext_get;
               AssignAttri("", false, "AV35TFSGNotificacionDescripcion", AV35TFSGNotificacionDescripcion);
               AV36TFSGNotificacionDescripcion_Sel = Ddo_grid_Selectedvalue_get;
               AssignAttri("", false, "AV36TFSGNotificacionDescripcion_Sel", AV36TFSGNotificacionDescripcion_Sel);
            }
            else if ( StringUtil.StrCmp(Ddo_grid_Selectedcolumn, "SGNotificacionFecha") == 0 )
            {
               AV37TFSGNotificacionFecha = context.localUtil.CToT( Ddo_grid_Filteredtext_get, 2);
               AssignAttri("", false, "AV37TFSGNotificacionFecha", context.localUtil.TToC( AV37TFSGNotificacionFecha, 8, 5, 0, 3, "/", ":", " "));
               AV38TFSGNotificacionFecha_To = context.localUtil.CToT( Ddo_grid_Filteredtextto_get, 2);
               AssignAttri("", false, "AV38TFSGNotificacionFecha_To", context.localUtil.TToC( AV38TFSGNotificacionFecha_To, 8, 5, 0, 3, "/", ":", " "));
               if ( ! (DateTime.MinValue==AV38TFSGNotificacionFecha_To) )
               {
                  AV38TFSGNotificacionFecha_To = context.localUtil.YMDHMSToT( (short)(DateTimeUtil.Year( AV38TFSGNotificacionFecha_To)), (short)(DateTimeUtil.Month( AV38TFSGNotificacionFecha_To)), (short)(DateTimeUtil.Day( AV38TFSGNotificacionFecha_To)), 23, 59, 59);
                  AssignAttri("", false, "AV38TFSGNotificacionFecha_To", context.localUtil.TToC( AV38TFSGNotificacionFecha_To, 8, 5, 0, 3, "/", ":", " "));
               }
            }
            else if ( StringUtil.StrCmp(Ddo_grid_Selectedcolumn, "SGNotificacionUsuario") == 0 )
            {
               AV42TFSGNotificacionUsuario = Ddo_grid_Filteredtext_get;
               AssignAttri("", false, "AV42TFSGNotificacionUsuario", AV42TFSGNotificacionUsuario);
               AV43TFSGNotificacionUsuario_Sel = Ddo_grid_Selectedvalue_get;
               AssignAttri("", false, "AV43TFSGNotificacionUsuario_Sel", AV43TFSGNotificacionUsuario_Sel);
            }
            else if ( StringUtil.StrCmp(Ddo_grid_Selectedcolumn, "SGNotificacionUsuarioDsc") == 0 )
            {
               AV44TFSGNotificacionUsuarioDsc = Ddo_grid_Filteredtext_get;
               AssignAttri("", false, "AV44TFSGNotificacionUsuarioDsc", AV44TFSGNotificacionUsuarioDsc);
               AV45TFSGNotificacionUsuarioDsc_Sel = Ddo_grid_Selectedvalue_get;
               AssignAttri("", false, "AV45TFSGNotificacionUsuarioDsc_Sel", AV45TFSGNotificacionUsuarioDsc_Sel);
            }
            else if ( StringUtil.StrCmp(Ddo_grid_Selectedcolumn, "SGNotificacionIconClass") == 0 )
            {
               AV46TFSGNotificacionIconClass_SelsJson = Ddo_grid_Selectedvalue_get;
               AssignAttri("", false, "AV46TFSGNotificacionIconClass_SelsJson", AV46TFSGNotificacionIconClass_SelsJson);
               AV47TFSGNotificacionIconClass_Sels.FromJSonString(AV46TFSGNotificacionIconClass_SelsJson, null);
            }
            else if ( StringUtil.StrCmp(Ddo_grid_Selectedcolumn, "SGNotificacionTUsuario") == 0 )
            {
               AV48TFSGNotificacionTUsuario = (short)(NumberUtil.Val( Ddo_grid_Filteredtext_get, "."));
               AssignAttri("", false, "AV48TFSGNotificacionTUsuario", StringUtil.LTrimStr( (decimal)(AV48TFSGNotificacionTUsuario), 4, 0));
               AV49TFSGNotificacionTUsuario_To = (short)(NumberUtil.Val( Ddo_grid_Filteredtextto_get, "."));
               AssignAttri("", false, "AV49TFSGNotificacionTUsuario_To", StringUtil.LTrimStr( (decimal)(AV49TFSGNotificacionTUsuario_To), 4, 0));
            }
            subgrid_firstpage( ) ;
         }
         /*  Sending Event outputs  */
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV47TFSGNotificacionIconClass_Sels", AV47TFSGNotificacionIconClass_Sels);
      }

      private void E262S2( )
      {
         /* Grid_Load Routine */
         returnInSub = false;
         cmbavGridactions.removeAllItems();
         cmbavGridactions.addItem("0", ";fa fa-bars", 0);
         cmbavGridactions.addItem("1", StringUtil.Format( "%1;%2", "Modificar", "fa fa-pen", "", "", "", "", "", "", ""), 0);
         cmbavGridactions.addItem("2", StringUtil.Format( "%1;%2", "Eliminar", "fa fa-times", "", "", "", "", "", "", ""), 0);
         GXKey = Crypto.GetSiteKey( );
         GXEncryptionTmp = "seguridad.notificaciones.aspx"+UrlEncode(StringUtil.RTrim("DSP")) + "," + UrlEncode(StringUtil.LTrimStr(A2237SGNotificacionID,10,0));
         edtSGNotificacionTitulo_Link = formatLink("seguridad.notificaciones.aspx") + "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey);
         GXKey = Crypto.GetSiteKey( );
         GXEncryptionTmp = "seguridad.usuariosseries.aspx"+UrlEncode(StringUtil.RTrim("DSP")) + "," + UrlEncode(StringUtil.RTrim(A2241SGNotificacionUsuario));
         edtSGNotificacionUsuario_Link = formatLink("seguridad.usuariosseries.aspx") + "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey);
         GXKey = Crypto.GetSiteKey( );
         GXEncryptionTmp = "seguridad.usuariosopciones.aspx"+UrlEncode(StringUtil.RTrim("DSP")) + "," + UrlEncode(StringUtil.RTrim(A2241SGNotificacionUsuario));
         edtSGNotificacionUsuarioDsc_Link = formatLink("seguridad.usuariosopciones.aspx") + "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey);
         /* Load Method */
         if ( wbStart != -1 )
         {
            wbStart = 101;
         }
         sendrow_1012( ) ;
         GRID_nCurrentRecord = (long)(GRID_nCurrentRecord+1);
         if ( isFullAjaxMode( ) && ! bGXsfl_101_Refreshing )
         {
            DoAjaxLoad(101, GridRow);
         }
         /*  Sending Event outputs  */
         cmbavGridactions.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV55GridActions), 4, 0));
      }

      protected void E192S2( )
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

      protected void E152S2( )
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
         gxgrGrid_refresh( subGrid_Rows, AV15DynamicFiltersSelector1, AV16DynamicFiltersOperator1, AV17SGNotificacionTitulo1, AV19DynamicFiltersSelector2, AV20DynamicFiltersOperator2, AV21SGNotificacionTitulo2, AV23DynamicFiltersSelector3, AV24DynamicFiltersOperator3, AV25SGNotificacionTitulo3, AV60Pgmname, AV18DynamicFiltersEnabled2, AV22DynamicFiltersEnabled3, AV31TFSGNotificacionID, AV32TFSGNotificacionID_To, AV33TFSGNotificacionTitulo, AV34TFSGNotificacionTitulo_Sel, AV35TFSGNotificacionDescripcion, AV36TFSGNotificacionDescripcion_Sel, AV37TFSGNotificacionFecha, AV38TFSGNotificacionFecha_To, AV42TFSGNotificacionUsuario, AV43TFSGNotificacionUsuario_Sel, AV44TFSGNotificacionUsuarioDsc, AV45TFSGNotificacionUsuarioDsc_Sel, AV47TFSGNotificacionIconClass_Sels, AV48TFSGNotificacionTUsuario, AV49TFSGNotificacionTUsuario_To, AV13OrderedBy, AV14OrderedDsc, AV10GridState, AV27DynamicFiltersIgnoreFirst, AV26DynamicFiltersRemoving) ;
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

      protected void E202S2( )
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

      protected void E212S2( )
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

      protected void E162S2( )
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
         gxgrGrid_refresh( subGrid_Rows, AV15DynamicFiltersSelector1, AV16DynamicFiltersOperator1, AV17SGNotificacionTitulo1, AV19DynamicFiltersSelector2, AV20DynamicFiltersOperator2, AV21SGNotificacionTitulo2, AV23DynamicFiltersSelector3, AV24DynamicFiltersOperator3, AV25SGNotificacionTitulo3, AV60Pgmname, AV18DynamicFiltersEnabled2, AV22DynamicFiltersEnabled3, AV31TFSGNotificacionID, AV32TFSGNotificacionID_To, AV33TFSGNotificacionTitulo, AV34TFSGNotificacionTitulo_Sel, AV35TFSGNotificacionDescripcion, AV36TFSGNotificacionDescripcion_Sel, AV37TFSGNotificacionFecha, AV38TFSGNotificacionFecha_To, AV42TFSGNotificacionUsuario, AV43TFSGNotificacionUsuario_Sel, AV44TFSGNotificacionUsuarioDsc, AV45TFSGNotificacionUsuarioDsc_Sel, AV47TFSGNotificacionIconClass_Sels, AV48TFSGNotificacionTUsuario, AV49TFSGNotificacionTUsuario_To, AV13OrderedBy, AV14OrderedDsc, AV10GridState, AV27DynamicFiltersIgnoreFirst, AV26DynamicFiltersRemoving) ;
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

      protected void E222S2( )
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

      protected void E172S2( )
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
         gxgrGrid_refresh( subGrid_Rows, AV15DynamicFiltersSelector1, AV16DynamicFiltersOperator1, AV17SGNotificacionTitulo1, AV19DynamicFiltersSelector2, AV20DynamicFiltersOperator2, AV21SGNotificacionTitulo2, AV23DynamicFiltersSelector3, AV24DynamicFiltersOperator3, AV25SGNotificacionTitulo3, AV60Pgmname, AV18DynamicFiltersEnabled2, AV22DynamicFiltersEnabled3, AV31TFSGNotificacionID, AV32TFSGNotificacionID_To, AV33TFSGNotificacionTitulo, AV34TFSGNotificacionTitulo_Sel, AV35TFSGNotificacionDescripcion, AV36TFSGNotificacionDescripcion_Sel, AV37TFSGNotificacionFecha, AV38TFSGNotificacionFecha_To, AV42TFSGNotificacionUsuario, AV43TFSGNotificacionUsuario_Sel, AV44TFSGNotificacionUsuarioDsc, AV45TFSGNotificacionUsuarioDsc_Sel, AV47TFSGNotificacionIconClass_Sels, AV48TFSGNotificacionTUsuario, AV49TFSGNotificacionTUsuario_To, AV13OrderedBy, AV14OrderedDsc, AV10GridState, AV27DynamicFiltersIgnoreFirst, AV26DynamicFiltersRemoving) ;
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

      protected void E232S2( )
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

      protected void E272S2( )
      {
         /* Gridactions_Click Routine */
         returnInSub = false;
         if ( AV55GridActions == 1 )
         {
            /* Execute user subroutine: 'DO UPDATE' */
            S212 ();
            if ( returnInSub )
            {
               returnInSub = true;
               if (true) return;
            }
         }
         else if ( AV55GridActions == 2 )
         {
            /* Execute user subroutine: 'DO DELETE' */
            S222 ();
            if ( returnInSub )
            {
               returnInSub = true;
               if (true) return;
            }
         }
         AV55GridActions = 0;
         AssignAttri("", false, cmbavGridactions_Internalname, StringUtil.LTrimStr( (decimal)(AV55GridActions), 4, 0));
         /*  Sending Event outputs  */
         cmbavGridactions.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV55GridActions), 4, 0));
         AssignProp("", false, cmbavGridactions_Internalname, "Values", cmbavGridactions.ToJavascriptSource(), true);
      }

      protected void E182S2( )
      {
         /* 'DoInsert' Routine */
         returnInSub = false;
         GXKey = Crypto.GetSiteKey( );
         GXEncryptionTmp = "seguridad.notificaciones.aspx"+UrlEncode(StringUtil.RTrim("INS")) + "," + UrlEncode(StringUtil.LTrimStr(0,1,0));
         CallWebObject(formatLink("seguridad.notificaciones.aspx") + "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey));
         context.wjLocDisableFrm = 1;
      }

      protected void E132S2( )
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
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV47TFSGNotificacionIconClass_Sels", AV47TFSGNotificacionIconClass_Sels);
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
         edtavSgnotificaciontitulo1_Visible = 0;
         AssignProp("", false, edtavSgnotificaciontitulo1_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavSgnotificaciontitulo1_Visible), 5, 0), true);
         cmbavDynamicfiltersoperator1.Visible = 0;
         AssignProp("", false, cmbavDynamicfiltersoperator1_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(cmbavDynamicfiltersoperator1.Visible), 5, 0), true);
         if ( StringUtil.StrCmp(AV15DynamicFiltersSelector1, "SGNOTIFICACIONTITULO") == 0 )
         {
            edtavSgnotificaciontitulo1_Visible = 1;
            AssignProp("", false, edtavSgnotificaciontitulo1_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavSgnotificaciontitulo1_Visible), 5, 0), true);
            cmbavDynamicfiltersoperator1.Visible = 1;
            AssignProp("", false, cmbavDynamicfiltersoperator1_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(cmbavDynamicfiltersoperator1.Visible), 5, 0), true);
         }
      }

      protected void S122( )
      {
         /* 'ENABLEDYNAMICFILTERS2' Routine */
         returnInSub = false;
         edtavSgnotificaciontitulo2_Visible = 0;
         AssignProp("", false, edtavSgnotificaciontitulo2_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavSgnotificaciontitulo2_Visible), 5, 0), true);
         cmbavDynamicfiltersoperator2.Visible = 0;
         AssignProp("", false, cmbavDynamicfiltersoperator2_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(cmbavDynamicfiltersoperator2.Visible), 5, 0), true);
         if ( StringUtil.StrCmp(AV19DynamicFiltersSelector2, "SGNOTIFICACIONTITULO") == 0 )
         {
            edtavSgnotificaciontitulo2_Visible = 1;
            AssignProp("", false, edtavSgnotificaciontitulo2_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavSgnotificaciontitulo2_Visible), 5, 0), true);
            cmbavDynamicfiltersoperator2.Visible = 1;
            AssignProp("", false, cmbavDynamicfiltersoperator2_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(cmbavDynamicfiltersoperator2.Visible), 5, 0), true);
         }
      }

      protected void S132( )
      {
         /* 'ENABLEDYNAMICFILTERS3' Routine */
         returnInSub = false;
         edtavSgnotificaciontitulo3_Visible = 0;
         AssignProp("", false, edtavSgnotificaciontitulo3_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavSgnotificaciontitulo3_Visible), 5, 0), true);
         cmbavDynamicfiltersoperator3.Visible = 0;
         AssignProp("", false, cmbavDynamicfiltersoperator3_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(cmbavDynamicfiltersoperator3.Visible), 5, 0), true);
         if ( StringUtil.StrCmp(AV23DynamicFiltersSelector3, "SGNOTIFICACIONTITULO") == 0 )
         {
            edtavSgnotificaciontitulo3_Visible = 1;
            AssignProp("", false, edtavSgnotificaciontitulo3_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavSgnotificaciontitulo3_Visible), 5, 0), true);
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
         AV19DynamicFiltersSelector2 = "SGNOTIFICACIONTITULO";
         AssignAttri("", false, "AV19DynamicFiltersSelector2", AV19DynamicFiltersSelector2);
         AV20DynamicFiltersOperator2 = 0;
         AssignAttri("", false, "AV20DynamicFiltersOperator2", StringUtil.LTrimStr( (decimal)(AV20DynamicFiltersOperator2), 4, 0));
         AV21SGNotificacionTitulo2 = "";
         AssignAttri("", false, "AV21SGNotificacionTitulo2", AV21SGNotificacionTitulo2);
         /* Execute user subroutine: 'ENABLEDYNAMICFILTERS2' */
         S122 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
         AV22DynamicFiltersEnabled3 = false;
         AssignAttri("", false, "AV22DynamicFiltersEnabled3", AV22DynamicFiltersEnabled3);
         AV23DynamicFiltersSelector3 = "SGNOTIFICACIONTITULO";
         AssignAttri("", false, "AV23DynamicFiltersSelector3", AV23DynamicFiltersSelector3);
         AV24DynamicFiltersOperator3 = 0;
         AssignAttri("", false, "AV24DynamicFiltersOperator3", StringUtil.LTrimStr( (decimal)(AV24DynamicFiltersOperator3), 4, 0));
         AV25SGNotificacionTitulo3 = "";
         AssignAttri("", false, "AV25SGNotificacionTitulo3", AV25SGNotificacionTitulo3);
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
         GXEncryptionTmp = "seguridad.notificaciones.aspx"+UrlEncode(StringUtil.RTrim("UPD")) + "," + UrlEncode(StringUtil.LTrimStr(A2237SGNotificacionID,10,0));
         CallWebObject(formatLink("seguridad.notificaciones.aspx") + "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey));
         context.wjLocDisableFrm = 1;
      }

      protected void S222( )
      {
         /* 'DO DELETE' Routine */
         returnInSub = false;
         GXKey = Crypto.GetSiteKey( );
         GXEncryptionTmp = "seguridad.notificaciones.aspx"+UrlEncode(StringUtil.RTrim("DLT")) + "," + UrlEncode(StringUtil.LTrimStr(A2237SGNotificacionID,10,0));
         CallWebObject(formatLink("seguridad.notificaciones.aspx") + "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey));
         context.wjLocDisableFrm = 1;
      }

      protected void S152( )
      {
         /* 'LOADGRIDSTATE' Routine */
         returnInSub = false;
         if ( StringUtil.StrCmp(AV30Session.Get(AV60Pgmname+"GridState"), "") == 0 )
         {
            AV10GridState.FromXml(new GeneXus.Programs.wwpbaseobjects.loadgridstate(context).executeUdp(  AV60Pgmname+"GridState"), null, "", "");
         }
         else
         {
            AV10GridState.FromXml(AV30Session.Get(AV60Pgmname+"GridState"), null, "", "");
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
         AV87GXV1 = 1;
         while ( AV87GXV1 <= AV10GridState.gxTpr_Filtervalues.Count )
         {
            AV11GridStateFilterValue = ((GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue)AV10GridState.gxTpr_Filtervalues.Item(AV87GXV1));
            if ( StringUtil.StrCmp(AV11GridStateFilterValue.gxTpr_Name, "TFSGNOTIFICACIONID") == 0 )
            {
               AV31TFSGNotificacionID = (long)(NumberUtil.Val( AV11GridStateFilterValue.gxTpr_Value, "."));
               AssignAttri("", false, "AV31TFSGNotificacionID", StringUtil.LTrimStr( (decimal)(AV31TFSGNotificacionID), 10, 0));
               AV32TFSGNotificacionID_To = (long)(NumberUtil.Val( AV11GridStateFilterValue.gxTpr_Valueto, "."));
               AssignAttri("", false, "AV32TFSGNotificacionID_To", StringUtil.LTrimStr( (decimal)(AV32TFSGNotificacionID_To), 10, 0));
            }
            else if ( StringUtil.StrCmp(AV11GridStateFilterValue.gxTpr_Name, "TFSGNOTIFICACIONTITULO") == 0 )
            {
               AV33TFSGNotificacionTitulo = AV11GridStateFilterValue.gxTpr_Value;
               AssignAttri("", false, "AV33TFSGNotificacionTitulo", AV33TFSGNotificacionTitulo);
            }
            else if ( StringUtil.StrCmp(AV11GridStateFilterValue.gxTpr_Name, "TFSGNOTIFICACIONTITULO_SEL") == 0 )
            {
               AV34TFSGNotificacionTitulo_Sel = AV11GridStateFilterValue.gxTpr_Value;
               AssignAttri("", false, "AV34TFSGNotificacionTitulo_Sel", AV34TFSGNotificacionTitulo_Sel);
            }
            else if ( StringUtil.StrCmp(AV11GridStateFilterValue.gxTpr_Name, "TFSGNOTIFICACIONDESCRIPCION") == 0 )
            {
               AV35TFSGNotificacionDescripcion = AV11GridStateFilterValue.gxTpr_Value;
               AssignAttri("", false, "AV35TFSGNotificacionDescripcion", AV35TFSGNotificacionDescripcion);
            }
            else if ( StringUtil.StrCmp(AV11GridStateFilterValue.gxTpr_Name, "TFSGNOTIFICACIONDESCRIPCION_SEL") == 0 )
            {
               AV36TFSGNotificacionDescripcion_Sel = AV11GridStateFilterValue.gxTpr_Value;
               AssignAttri("", false, "AV36TFSGNotificacionDescripcion_Sel", AV36TFSGNotificacionDescripcion_Sel);
            }
            else if ( StringUtil.StrCmp(AV11GridStateFilterValue.gxTpr_Name, "TFSGNOTIFICACIONFECHA") == 0 )
            {
               AV37TFSGNotificacionFecha = context.localUtil.CToT( AV11GridStateFilterValue.gxTpr_Value, 2);
               AssignAttri("", false, "AV37TFSGNotificacionFecha", context.localUtil.TToC( AV37TFSGNotificacionFecha, 8, 5, 0, 3, "/", ":", " "));
               AV38TFSGNotificacionFecha_To = context.localUtil.CToT( AV11GridStateFilterValue.gxTpr_Valueto, 2);
               AssignAttri("", false, "AV38TFSGNotificacionFecha_To", context.localUtil.TToC( AV38TFSGNotificacionFecha_To, 8, 5, 0, 3, "/", ":", " "));
               AV39DDO_SGNotificacionFechaAuxDate = DateTimeUtil.ResetTime(AV37TFSGNotificacionFecha);
               AssignAttri("", false, "AV39DDO_SGNotificacionFechaAuxDate", context.localUtil.Format(AV39DDO_SGNotificacionFechaAuxDate, "99/99/99"));
               AV40DDO_SGNotificacionFechaAuxDateTo = DateTimeUtil.ResetTime(AV38TFSGNotificacionFecha_To);
               AssignAttri("", false, "AV40DDO_SGNotificacionFechaAuxDateTo", context.localUtil.Format(AV40DDO_SGNotificacionFechaAuxDateTo, "99/99/99"));
            }
            else if ( StringUtil.StrCmp(AV11GridStateFilterValue.gxTpr_Name, "TFSGNOTIFICACIONUSUARIO") == 0 )
            {
               AV42TFSGNotificacionUsuario = AV11GridStateFilterValue.gxTpr_Value;
               AssignAttri("", false, "AV42TFSGNotificacionUsuario", AV42TFSGNotificacionUsuario);
            }
            else if ( StringUtil.StrCmp(AV11GridStateFilterValue.gxTpr_Name, "TFSGNOTIFICACIONUSUARIO_SEL") == 0 )
            {
               AV43TFSGNotificacionUsuario_Sel = AV11GridStateFilterValue.gxTpr_Value;
               AssignAttri("", false, "AV43TFSGNotificacionUsuario_Sel", AV43TFSGNotificacionUsuario_Sel);
            }
            else if ( StringUtil.StrCmp(AV11GridStateFilterValue.gxTpr_Name, "TFSGNOTIFICACIONUSUARIODSC") == 0 )
            {
               AV44TFSGNotificacionUsuarioDsc = AV11GridStateFilterValue.gxTpr_Value;
               AssignAttri("", false, "AV44TFSGNotificacionUsuarioDsc", AV44TFSGNotificacionUsuarioDsc);
            }
            else if ( StringUtil.StrCmp(AV11GridStateFilterValue.gxTpr_Name, "TFSGNOTIFICACIONUSUARIODSC_SEL") == 0 )
            {
               AV45TFSGNotificacionUsuarioDsc_Sel = AV11GridStateFilterValue.gxTpr_Value;
               AssignAttri("", false, "AV45TFSGNotificacionUsuarioDsc_Sel", AV45TFSGNotificacionUsuarioDsc_Sel);
            }
            else if ( StringUtil.StrCmp(AV11GridStateFilterValue.gxTpr_Name, "TFSGNOTIFICACIONICONCLASS_SEL") == 0 )
            {
               AV46TFSGNotificacionIconClass_SelsJson = AV11GridStateFilterValue.gxTpr_Value;
               AssignAttri("", false, "AV46TFSGNotificacionIconClass_SelsJson", AV46TFSGNotificacionIconClass_SelsJson);
               AV47TFSGNotificacionIconClass_Sels.FromJSonString(AV46TFSGNotificacionIconClass_SelsJson, null);
            }
            else if ( StringUtil.StrCmp(AV11GridStateFilterValue.gxTpr_Name, "TFSGNOTIFICACIONTUSUARIO") == 0 )
            {
               AV48TFSGNotificacionTUsuario = (short)(NumberUtil.Val( AV11GridStateFilterValue.gxTpr_Value, "."));
               AssignAttri("", false, "AV48TFSGNotificacionTUsuario", StringUtil.LTrimStr( (decimal)(AV48TFSGNotificacionTUsuario), 4, 0));
               AV49TFSGNotificacionTUsuario_To = (short)(NumberUtil.Val( AV11GridStateFilterValue.gxTpr_Valueto, "."));
               AssignAttri("", false, "AV49TFSGNotificacionTUsuario_To", StringUtil.LTrimStr( (decimal)(AV49TFSGNotificacionTUsuario_To), 4, 0));
            }
            AV87GXV1 = (int)(AV87GXV1+1);
         }
         GXt_char2 = "";
         new GeneXus.Programs.wwpbaseobjects.wwp_getfilterval(context ).execute(  String.IsNullOrEmpty(StringUtil.RTrim( AV34TFSGNotificacionTitulo_Sel)),  AV34TFSGNotificacionTitulo_Sel, out  GXt_char2) ;
         GXt_char3 = "";
         new GeneXus.Programs.wwpbaseobjects.wwp_getfilterval(context ).execute(  String.IsNullOrEmpty(StringUtil.RTrim( AV36TFSGNotificacionDescripcion_Sel)),  AV36TFSGNotificacionDescripcion_Sel, out  GXt_char3) ;
         GXt_char4 = "";
         new GeneXus.Programs.wwpbaseobjects.wwp_getfilterval(context ).execute(  String.IsNullOrEmpty(StringUtil.RTrim( AV43TFSGNotificacionUsuario_Sel)),  AV43TFSGNotificacionUsuario_Sel, out  GXt_char4) ;
         GXt_char5 = "";
         new GeneXus.Programs.wwpbaseobjects.wwp_getfilterval(context ).execute(  String.IsNullOrEmpty(StringUtil.RTrim( AV45TFSGNotificacionUsuarioDsc_Sel)),  AV45TFSGNotificacionUsuarioDsc_Sel, out  GXt_char5) ;
         GXt_char6 = "";
         new GeneXus.Programs.wwpbaseobjects.wwp_getfilterval(context ).execute(  (AV47TFSGNotificacionIconClass_Sels.Count==0),  AV46TFSGNotificacionIconClass_SelsJson, out  GXt_char6) ;
         Ddo_grid_Selectedvalue_set = "|"+GXt_char2+"|"+GXt_char3+"||"+GXt_char4+"|"+GXt_char5+"|"+GXt_char6+"|";
         ucDdo_grid.SendProperty(context, "", false, Ddo_grid_Internalname, "SelectedValue_set", Ddo_grid_Selectedvalue_set);
         GXt_char6 = "";
         new GeneXus.Programs.wwpbaseobjects.wwp_getfilterval(context ).execute(  String.IsNullOrEmpty(StringUtil.RTrim( AV33TFSGNotificacionTitulo)),  AV33TFSGNotificacionTitulo, out  GXt_char6) ;
         GXt_char5 = "";
         new GeneXus.Programs.wwpbaseobjects.wwp_getfilterval(context ).execute(  String.IsNullOrEmpty(StringUtil.RTrim( AV35TFSGNotificacionDescripcion)),  AV35TFSGNotificacionDescripcion, out  GXt_char5) ;
         GXt_char4 = "";
         new GeneXus.Programs.wwpbaseobjects.wwp_getfilterval(context ).execute(  String.IsNullOrEmpty(StringUtil.RTrim( AV42TFSGNotificacionUsuario)),  AV42TFSGNotificacionUsuario, out  GXt_char4) ;
         GXt_char3 = "";
         new GeneXus.Programs.wwpbaseobjects.wwp_getfilterval(context ).execute(  String.IsNullOrEmpty(StringUtil.RTrim( AV44TFSGNotificacionUsuarioDsc)),  AV44TFSGNotificacionUsuarioDsc, out  GXt_char3) ;
         Ddo_grid_Filteredtext_set = ((0==AV31TFSGNotificacionID) ? "" : StringUtil.Str( (decimal)(AV31TFSGNotificacionID), 10, 0))+"|"+GXt_char6+"|"+GXt_char5+"|"+((DateTime.MinValue==AV37TFSGNotificacionFecha) ? "" : context.localUtil.DToC( AV39DDO_SGNotificacionFechaAuxDate, 2, "/"))+"|"+GXt_char4+"|"+GXt_char3+"||"+((0==AV48TFSGNotificacionTUsuario) ? "" : StringUtil.Str( (decimal)(AV48TFSGNotificacionTUsuario), 4, 0));
         ucDdo_grid.SendProperty(context, "", false, Ddo_grid_Internalname, "FilteredText_set", Ddo_grid_Filteredtext_set);
         Ddo_grid_Filteredtextto_set = ((0==AV32TFSGNotificacionID_To) ? "" : StringUtil.Str( (decimal)(AV32TFSGNotificacionID_To), 10, 0))+"|||"+((DateTime.MinValue==AV38TFSGNotificacionFecha_To) ? "" : context.localUtil.DToC( AV40DDO_SGNotificacionFechaAuxDateTo, 2, "/"))+"||||"+((0==AV49TFSGNotificacionTUsuario_To) ? "" : StringUtil.Str( (decimal)(AV49TFSGNotificacionTUsuario_To), 4, 0));
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
            if ( StringUtil.StrCmp(AV15DynamicFiltersSelector1, "SGNOTIFICACIONTITULO") == 0 )
            {
               AV16DynamicFiltersOperator1 = AV12GridStateDynamicFilter.gxTpr_Operator;
               AssignAttri("", false, "AV16DynamicFiltersOperator1", StringUtil.LTrimStr( (decimal)(AV16DynamicFiltersOperator1), 4, 0));
               AV17SGNotificacionTitulo1 = AV12GridStateDynamicFilter.gxTpr_Value;
               AssignAttri("", false, "AV17SGNotificacionTitulo1", AV17SGNotificacionTitulo1);
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
               if ( StringUtil.StrCmp(AV19DynamicFiltersSelector2, "SGNOTIFICACIONTITULO") == 0 )
               {
                  AV20DynamicFiltersOperator2 = AV12GridStateDynamicFilter.gxTpr_Operator;
                  AssignAttri("", false, "AV20DynamicFiltersOperator2", StringUtil.LTrimStr( (decimal)(AV20DynamicFiltersOperator2), 4, 0));
                  AV21SGNotificacionTitulo2 = AV12GridStateDynamicFilter.gxTpr_Value;
                  AssignAttri("", false, "AV21SGNotificacionTitulo2", AV21SGNotificacionTitulo2);
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
                  if ( StringUtil.StrCmp(AV23DynamicFiltersSelector3, "SGNOTIFICACIONTITULO") == 0 )
                  {
                     AV24DynamicFiltersOperator3 = AV12GridStateDynamicFilter.gxTpr_Operator;
                     AssignAttri("", false, "AV24DynamicFiltersOperator3", StringUtil.LTrimStr( (decimal)(AV24DynamicFiltersOperator3), 4, 0));
                     AV25SGNotificacionTitulo3 = AV12GridStateDynamicFilter.gxTpr_Value;
                     AssignAttri("", false, "AV25SGNotificacionTitulo3", AV25SGNotificacionTitulo3);
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
         AV10GridState.FromXml(AV30Session.Get(AV60Pgmname+"GridState"), null, "", "");
         AV10GridState.gxTpr_Orderedby = AV13OrderedBy;
         AV10GridState.gxTpr_Ordereddsc = AV14OrderedDsc;
         AV10GridState.gxTpr_Filtervalues.Clear();
         new GeneXus.Programs.wwpbaseobjects.wwp_gridstateaddfiltervalue(context ).execute( ref  AV10GridState,  "TFSGNOTIFICACIONID",  "ID",  !((0==AV31TFSGNotificacionID)&&(0==AV32TFSGNotificacionID_To)),  0,  StringUtil.Trim( StringUtil.Str( (decimal)(AV31TFSGNotificacionID), 10, 0)),  StringUtil.Trim( StringUtil.Str( (decimal)(AV32TFSGNotificacionID_To), 10, 0))) ;
         new GeneXus.Programs.wwpbaseobjects.wwp_gridstateaddfiltervalueandsel(context ).execute( ref  AV10GridState,  "TFSGNOTIFICACIONTITULO",  "Titulo",  !String.IsNullOrEmpty(StringUtil.RTrim( AV33TFSGNotificacionTitulo)),  0,  AV33TFSGNotificacionTitulo,  "",  !String.IsNullOrEmpty(StringUtil.RTrim( AV34TFSGNotificacionTitulo_Sel)),  AV34TFSGNotificacionTitulo_Sel,  "") ;
         new GeneXus.Programs.wwpbaseobjects.wwp_gridstateaddfiltervalueandsel(context ).execute( ref  AV10GridState,  "TFSGNOTIFICACIONDESCRIPCION",  "Descripción",  !String.IsNullOrEmpty(StringUtil.RTrim( AV35TFSGNotificacionDescripcion)),  0,  AV35TFSGNotificacionDescripcion,  "",  !String.IsNullOrEmpty(StringUtil.RTrim( AV36TFSGNotificacionDescripcion_Sel)),  AV36TFSGNotificacionDescripcion_Sel,  "") ;
         new GeneXus.Programs.wwpbaseobjects.wwp_gridstateaddfiltervalue(context ).execute( ref  AV10GridState,  "TFSGNOTIFICACIONFECHA",  "Hora",  !((DateTime.MinValue==AV37TFSGNotificacionFecha)&&(DateTime.MinValue==AV38TFSGNotificacionFecha_To)),  0,  StringUtil.Trim( context.localUtil.TToC( AV37TFSGNotificacionFecha, 8, 5, 0, 3, "/", ":", " ")),  StringUtil.Trim( context.localUtil.TToC( AV38TFSGNotificacionFecha_To, 8, 5, 0, 3, "/", ":", " "))) ;
         new GeneXus.Programs.wwpbaseobjects.wwp_gridstateaddfiltervalueandsel(context ).execute( ref  AV10GridState,  "TFSGNOTIFICACIONUSUARIO",  "Usuario",  !String.IsNullOrEmpty(StringUtil.RTrim( AV42TFSGNotificacionUsuario)),  0,  AV42TFSGNotificacionUsuario,  "",  !String.IsNullOrEmpty(StringUtil.RTrim( AV43TFSGNotificacionUsuario_Sel)),  AV43TFSGNotificacionUsuario_Sel,  "") ;
         new GeneXus.Programs.wwpbaseobjects.wwp_gridstateaddfiltervalueandsel(context ).execute( ref  AV10GridState,  "TFSGNOTIFICACIONUSUARIODSC",  "Usuario",  !String.IsNullOrEmpty(StringUtil.RTrim( AV44TFSGNotificacionUsuarioDsc)),  0,  AV44TFSGNotificacionUsuarioDsc,  "",  !String.IsNullOrEmpty(StringUtil.RTrim( AV45TFSGNotificacionUsuarioDsc_Sel)),  AV45TFSGNotificacionUsuarioDsc_Sel,  "") ;
         new GeneXus.Programs.wwpbaseobjects.wwp_gridstateaddfiltervalue(context ).execute( ref  AV10GridState,  "TFSGNOTIFICACIONICONCLASS_SEL",  "Icon Class",  !(AV47TFSGNotificacionIconClass_Sels.Count==0),  0,  AV47TFSGNotificacionIconClass_Sels.ToJSonString(false),  "") ;
         new GeneXus.Programs.wwpbaseobjects.wwp_gridstateaddfiltervalue(context ).execute( ref  AV10GridState,  "TFSGNOTIFICACIONTUSUARIO",  "Usuarios",  !((0==AV48TFSGNotificacionTUsuario)&&(0==AV49TFSGNotificacionTUsuario_To)),  0,  StringUtil.Trim( StringUtil.Str( (decimal)(AV48TFSGNotificacionTUsuario), 4, 0)),  StringUtil.Trim( StringUtil.Str( (decimal)(AV49TFSGNotificacionTUsuario_To), 4, 0))) ;
         /* Execute user subroutine: 'SAVEDYNFILTERSSTATE' */
         S182 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
         AV10GridState.gxTpr_Pagesize = StringUtil.Str( (decimal)(subGrid_Rows), 10, 0);
         AV10GridState.gxTpr_Currentpage = (short)(subGrid_fnc_Currentpage( ));
         new GeneXus.Programs.wwpbaseobjects.savegridstate(context ).execute(  AV60Pgmname+"GridState",  AV10GridState.ToXml(false, true, "", "")) ;
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
            if ( ( StringUtil.StrCmp(AV15DynamicFiltersSelector1, "SGNOTIFICACIONTITULO") == 0 ) && ! String.IsNullOrEmpty(StringUtil.RTrim( AV17SGNotificacionTitulo1)) )
            {
               AV12GridStateDynamicFilter.gxTpr_Dsc = "Titulo";
               AV12GridStateDynamicFilter.gxTpr_Value = AV17SGNotificacionTitulo1;
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
            if ( ( StringUtil.StrCmp(AV19DynamicFiltersSelector2, "SGNOTIFICACIONTITULO") == 0 ) && ! String.IsNullOrEmpty(StringUtil.RTrim( AV21SGNotificacionTitulo2)) )
            {
               AV12GridStateDynamicFilter.gxTpr_Dsc = "Titulo";
               AV12GridStateDynamicFilter.gxTpr_Value = AV21SGNotificacionTitulo2;
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
            if ( ( StringUtil.StrCmp(AV23DynamicFiltersSelector3, "SGNOTIFICACIONTITULO") == 0 ) && ! String.IsNullOrEmpty(StringUtil.RTrim( AV25SGNotificacionTitulo3)) )
            {
               AV12GridStateDynamicFilter.gxTpr_Dsc = "Titulo";
               AV12GridStateDynamicFilter.gxTpr_Value = AV25SGNotificacionTitulo3;
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
         AV8TrnContext.gxTpr_Callerobject = AV60Pgmname;
         AV8TrnContext.gxTpr_Callerondelete = true;
         AV8TrnContext.gxTpr_Callerurl = AV7HTTPRequest.ScriptName+"?"+AV7HTTPRequest.QueryString;
         AV8TrnContext.gxTpr_Transactionname = "Seguridad.Notificaciones";
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
         new GeneXus.Programs.seguridad.notificacioneswwexport(context ).execute( out  AV28ExcelFilename, out  AV29ErrorMessage) ;
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
         Innewwindow1_Target = formatLink("seguridad.notificacioneswwexportreport.aspx") ;
         ucInnewwindow1.SendProperty(context, "", false, Innewwindow1_Internalname, "Target", Innewwindow1_Target);
         Innewwindow1_Height = "600";
         ucInnewwindow1.SendProperty(context, "", false, Innewwindow1_Internalname, "Height", Innewwindow1_Height);
         Innewwindow1_Width = "800";
         ucInnewwindow1.SendProperty(context, "", false, Innewwindow1_Internalname, "Width", Innewwindow1_Width);
         this.executeUsercontrolMethod("", false, "INNEWWINDOW1Container", "OpenWindow", "", new Object[] {});
      }

      protected void wb_table1_25_2S2( bool wbgen )
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
            GxWebStd.gx_label_ctrl( context, lblDynamicfiltersprefix1_Internalname, "Buscar en", "", "", lblDynamicfiltersprefix1_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "DataFilterDescriptionPrefix", 0, "", 1, 1, 0, 0, "HLP_Seguridad\\NotificacionesWW.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "", "left", "top", "", "flex-grow:1;", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "left", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, cmbavDynamicfiltersselector1_Internalname, "Dynamic Filters Selector1", "gx-form-item AttributeLabel", 0, true, "width: 25%;");
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 35,'',false,'" + sGXsfl_101_idx + "',0)\"";
            /* ComboBox */
            GxWebStd.gx_combobox_ctrl1( context, cmbavDynamicfiltersselector1, cmbavDynamicfiltersselector1_Internalname, StringUtil.RTrim( AV15DynamicFiltersSelector1), 1, cmbavDynamicfiltersselector1_Jsonclick, 5, "'"+""+"'"+",false,"+"'"+"EVDYNAMICFILTERSSELECTOR1.CLICK."+"'", "svchar", "", 1, cmbavDynamicfiltersselector1.Enabled, 0, 0, 0, "em", 0, "", "", "Attribute", "", "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,35);\"", "", true, 1, "HLP_Seguridad\\NotificacionesWW.htm");
            cmbavDynamicfiltersselector1.CurrentValue = StringUtil.RTrim( AV15DynamicFiltersSelector1);
            AssignProp("", false, cmbavDynamicfiltersselector1_Internalname, "Values", (string)(cmbavDynamicfiltersselector1.ToJavascriptSource()), true);
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "", "left", "top", "", "flex-grow:1;", "div");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblDynamicfiltersmiddle1_Internalname, "valor", "", "", lblDynamicfiltersmiddle1_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "DataFilterDescription", 0, "", 1, 1, 0, 0, "HLP_Seguridad\\NotificacionesWW.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "", "left", "top", "", "flex-grow:1;", "div");
            wb_table2_39_2S2( true) ;
         }
         else
         {
            wb_table2_39_2S2( false) ;
         }
         return  ;
      }

      protected void wb_table2_39_2S2e( bool wbgen )
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
            GxWebStd.gx_label_ctrl( context, lblDynamicfiltersprefix2_Internalname, "Buscar en", "", "", lblDynamicfiltersprefix2_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "DataFilterDescriptionPrefix", 0, "", 1, 1, 0, 0, "HLP_Seguridad\\NotificacionesWW.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "Invisible", "left", "top", "", "flex-grow:1;", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "left", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, cmbavDynamicfiltersselector2_Internalname, "Dynamic Filters Selector2", "gx-form-item AttributeLabel", 0, true, "width: 25%;");
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 57,'',false,'" + sGXsfl_101_idx + "',0)\"";
            /* ComboBox */
            GxWebStd.gx_combobox_ctrl1( context, cmbavDynamicfiltersselector2, cmbavDynamicfiltersselector2_Internalname, StringUtil.RTrim( AV19DynamicFiltersSelector2), 1, cmbavDynamicfiltersselector2_Jsonclick, 5, "'"+""+"'"+",false,"+"'"+"EVDYNAMICFILTERSSELECTOR2.CLICK."+"'", "svchar", "", 1, cmbavDynamicfiltersselector2.Enabled, 0, 0, 0, "em", 0, "", "", "Attribute", "", "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,57);\"", "", true, 1, "HLP_Seguridad\\NotificacionesWW.htm");
            cmbavDynamicfiltersselector2.CurrentValue = StringUtil.RTrim( AV19DynamicFiltersSelector2);
            AssignProp("", false, cmbavDynamicfiltersselector2_Internalname, "Values", (string)(cmbavDynamicfiltersselector2.ToJavascriptSource()), true);
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "Invisible", "left", "top", "", "flex-grow:1;", "div");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblDynamicfiltersmiddle2_Internalname, "valor", "", "", lblDynamicfiltersmiddle2_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "DataFilterDescription", 0, "", 1, 1, 0, 0, "HLP_Seguridad\\NotificacionesWW.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "Invisible", "left", "top", "", "flex-grow:1;", "div");
            wb_table3_61_2S2( true) ;
         }
         else
         {
            wb_table3_61_2S2( false) ;
         }
         return  ;
      }

      protected void wb_table3_61_2S2e( bool wbgen )
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
            GxWebStd.gx_label_ctrl( context, lblDynamicfiltersprefix3_Internalname, "Buscar en", "", "", lblDynamicfiltersprefix3_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "DataFilterDescriptionPrefix", 0, "", 1, 1, 0, 0, "HLP_Seguridad\\NotificacionesWW.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "Invisible", "left", "top", "", "flex-grow:1;", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "left", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, cmbavDynamicfiltersselector3_Internalname, "Dynamic Filters Selector3", "gx-form-item AttributeLabel", 0, true, "width: 25%;");
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 79,'',false,'" + sGXsfl_101_idx + "',0)\"";
            /* ComboBox */
            GxWebStd.gx_combobox_ctrl1( context, cmbavDynamicfiltersselector3, cmbavDynamicfiltersselector3_Internalname, StringUtil.RTrim( AV23DynamicFiltersSelector3), 1, cmbavDynamicfiltersselector3_Jsonclick, 5, "'"+""+"'"+",false,"+"'"+"EVDYNAMICFILTERSSELECTOR3.CLICK."+"'", "svchar", "", 1, cmbavDynamicfiltersselector3.Enabled, 0, 0, 0, "em", 0, "", "", "Attribute", "", "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,79);\"", "", true, 1, "HLP_Seguridad\\NotificacionesWW.htm");
            cmbavDynamicfiltersselector3.CurrentValue = StringUtil.RTrim( AV23DynamicFiltersSelector3);
            AssignProp("", false, cmbavDynamicfiltersselector3_Internalname, "Values", (string)(cmbavDynamicfiltersselector3.ToJavascriptSource()), true);
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "Invisible", "left", "top", "", "flex-grow:1;", "div");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblDynamicfiltersmiddle3_Internalname, "valor", "", "", lblDynamicfiltersmiddle3_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "DataFilterDescription", 0, "", 1, 1, 0, 0, "HLP_Seguridad\\NotificacionesWW.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "Invisible", "left", "top", "", "flex-grow:1;", "div");
            wb_table4_83_2S2( true) ;
         }
         else
         {
            wb_table4_83_2S2( false) ;
         }
         return  ;
      }

      protected void wb_table4_83_2S2e( bool wbgen )
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
            wb_table1_25_2S2e( true) ;
         }
         else
         {
            wb_table1_25_2S2e( false) ;
         }
      }

      protected void wb_table4_83_2S2( bool wbgen )
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
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 87,'',false,'" + sGXsfl_101_idx + "',0)\"";
            /* ComboBox */
            GxWebStd.gx_combobox_ctrl1( context, cmbavDynamicfiltersoperator3, cmbavDynamicfiltersoperator3_Internalname, StringUtil.Trim( StringUtil.Str( (decimal)(AV24DynamicFiltersOperator3), 4, 0)), 1, cmbavDynamicfiltersoperator3_Jsonclick, 0, "'"+""+"'"+",false,"+"'"+""+"'", "int", "", cmbavDynamicfiltersoperator3.Visible, cmbavDynamicfiltersoperator3.Enabled, 0, 0, 0, "em", 0, "", "", "Attribute", "", "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,87);\"", "", true, 1, "HLP_Seguridad\\NotificacionesWW.htm");
            cmbavDynamicfiltersoperator3.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV24DynamicFiltersOperator3), 4, 0));
            AssignProp("", false, cmbavDynamicfiltersoperator3_Internalname, "Values", (string)(cmbavDynamicfiltersoperator3.ToJavascriptSource()), true);
            GxWebStd.gx_div_end( context, "left", "top", "div");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "<td id=\""+cellFilter_sgnotificaciontitulo3_cell_Internalname+"\"  class=''>") ;
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "left", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavSgnotificaciontitulo3_Internalname, "SGNotificacion Titulo3", "gx-form-item AttributeLabel", 0, true, "width: 25%;");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 90,'',false,'" + sGXsfl_101_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavSgnotificaciontitulo3_Internalname, AV25SGNotificacionTitulo3, StringUtil.RTrim( context.localUtil.Format( AV25SGNotificacionTitulo3, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,90);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavSgnotificaciontitulo3_Jsonclick, 0, "Attribute", "", "", "", "", edtavSgnotificaciontitulo3_Visible, edtavSgnotificaciontitulo3_Enabled, 0, "text", "", 80, "chr", 1, "row", 100, 0, 0, 0, 1, -1, -1, true, "", "left", true, "", "HLP_Seguridad\\NotificacionesWW.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "<td id=\""+cellDynamicfilters_removefilter3_cell_Internalname+"\"  class=''>") ;
            /* Active images/pictures */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 92,'',false,'',0)\"";
            ClassString = "Image";
            StyleString = "";
            sImgUrl = (string)(context.GetImagePath( "11a6ef14-1a5a-4077-91a2-f41ed9a3a662", "", context.GetTheme( )));
            GxWebStd.gx_bitmap( context, imgRemovedynamicfilters3_Internalname, sImgUrl, "", "", "", context.GetTheme( ), 1, 1, "", "Quitar filtro", 0, 0, 0, "px", 0, "px", 0, 0, 5, imgRemovedynamicfilters3_Jsonclick, "'"+""+"'"+",false,"+"'"+"E\\'REMOVEDYNAMICFILTERS3\\'."+"'", StyleString, ClassString, "", "", "", "", " "+"data-gx-image"+" "+TempTags, "", "", 1, false, false, context.GetImageSrcSet( sImgUrl), "HLP_Seguridad\\NotificacionesWW.htm");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "</tr>") ;
            /* End of table */
            context.WriteHtmlText( "</table>") ;
            wb_table4_83_2S2e( true) ;
         }
         else
         {
            wb_table4_83_2S2e( false) ;
         }
      }

      protected void wb_table3_61_2S2( bool wbgen )
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
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 65,'',false,'" + sGXsfl_101_idx + "',0)\"";
            /* ComboBox */
            GxWebStd.gx_combobox_ctrl1( context, cmbavDynamicfiltersoperator2, cmbavDynamicfiltersoperator2_Internalname, StringUtil.Trim( StringUtil.Str( (decimal)(AV20DynamicFiltersOperator2), 4, 0)), 1, cmbavDynamicfiltersoperator2_Jsonclick, 0, "'"+""+"'"+",false,"+"'"+""+"'", "int", "", cmbavDynamicfiltersoperator2.Visible, cmbavDynamicfiltersoperator2.Enabled, 0, 0, 0, "em", 0, "", "", "Attribute", "", "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,65);\"", "", true, 1, "HLP_Seguridad\\NotificacionesWW.htm");
            cmbavDynamicfiltersoperator2.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV20DynamicFiltersOperator2), 4, 0));
            AssignProp("", false, cmbavDynamicfiltersoperator2_Internalname, "Values", (string)(cmbavDynamicfiltersoperator2.ToJavascriptSource()), true);
            GxWebStd.gx_div_end( context, "left", "top", "div");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "<td id=\""+cellFilter_sgnotificaciontitulo2_cell_Internalname+"\"  class=''>") ;
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "left", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavSgnotificaciontitulo2_Internalname, "SGNotificacion Titulo2", "gx-form-item AttributeLabel", 0, true, "width: 25%;");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 68,'',false,'" + sGXsfl_101_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavSgnotificaciontitulo2_Internalname, AV21SGNotificacionTitulo2, StringUtil.RTrim( context.localUtil.Format( AV21SGNotificacionTitulo2, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,68);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavSgnotificaciontitulo2_Jsonclick, 0, "Attribute", "", "", "", "", edtavSgnotificaciontitulo2_Visible, edtavSgnotificaciontitulo2_Enabled, 0, "text", "", 80, "chr", 1, "row", 100, 0, 0, 0, 1, -1, -1, true, "", "left", true, "", "HLP_Seguridad\\NotificacionesWW.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "<td id=\""+cellDynamicfilters_addfilter2_cell_Internalname+"\"  class=''>") ;
            /* Active images/pictures */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 70,'',false,'',0)\"";
            ClassString = "Image";
            StyleString = "";
            sImgUrl = (string)(context.GetImagePath( "27283ea5-332f-423b-b880-64b762622df3", "", context.GetTheme( )));
            GxWebStd.gx_bitmap( context, imgAdddynamicfilters2_Internalname, sImgUrl, "", "", "", context.GetTheme( ), imgAdddynamicfilters2_Visible, 1, "", "Agregar filtro", 0, 0, 0, "px", 0, "px", 0, 0, 5, imgAdddynamicfilters2_Jsonclick, "'"+""+"'"+",false,"+"'"+"E\\'ADDDYNAMICFILTERS2\\'."+"'", StyleString, ClassString, "", "", "", "", " "+"data-gx-image"+" "+TempTags, "", "", 1, false, false, context.GetImageSrcSet( sImgUrl), "HLP_Seguridad\\NotificacionesWW.htm");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "<td id=\""+cellDynamicfilters_removefilter2_cell_Internalname+"\"  class=''>") ;
            /* Active images/pictures */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 72,'',false,'',0)\"";
            ClassString = "Image";
            StyleString = "";
            sImgUrl = (string)(context.GetImagePath( "11a6ef14-1a5a-4077-91a2-f41ed9a3a662", "", context.GetTheme( )));
            GxWebStd.gx_bitmap( context, imgRemovedynamicfilters2_Internalname, sImgUrl, "", "", "", context.GetTheme( ), imgRemovedynamicfilters2_Visible, 1, "", "Quitar filtro", 0, 0, 0, "px", 0, "px", 0, 0, 5, imgRemovedynamicfilters2_Jsonclick, "'"+""+"'"+",false,"+"'"+"E\\'REMOVEDYNAMICFILTERS2\\'."+"'", StyleString, ClassString, "", "", "", "", " "+"data-gx-image"+" "+TempTags, "", "", 1, false, false, context.GetImageSrcSet( sImgUrl), "HLP_Seguridad\\NotificacionesWW.htm");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "</tr>") ;
            /* End of table */
            context.WriteHtmlText( "</table>") ;
            wb_table3_61_2S2e( true) ;
         }
         else
         {
            wb_table3_61_2S2e( false) ;
         }
      }

      protected void wb_table2_39_2S2( bool wbgen )
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
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 43,'',false,'" + sGXsfl_101_idx + "',0)\"";
            /* ComboBox */
            GxWebStd.gx_combobox_ctrl1( context, cmbavDynamicfiltersoperator1, cmbavDynamicfiltersoperator1_Internalname, StringUtil.Trim( StringUtil.Str( (decimal)(AV16DynamicFiltersOperator1), 4, 0)), 1, cmbavDynamicfiltersoperator1_Jsonclick, 0, "'"+""+"'"+",false,"+"'"+""+"'", "int", "", cmbavDynamicfiltersoperator1.Visible, cmbavDynamicfiltersoperator1.Enabled, 0, 0, 0, "em", 0, "", "", "Attribute", "", "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,43);\"", "", true, 1, "HLP_Seguridad\\NotificacionesWW.htm");
            cmbavDynamicfiltersoperator1.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV16DynamicFiltersOperator1), 4, 0));
            AssignProp("", false, cmbavDynamicfiltersoperator1_Internalname, "Values", (string)(cmbavDynamicfiltersoperator1.ToJavascriptSource()), true);
            GxWebStd.gx_div_end( context, "left", "top", "div");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "<td id=\""+cellFilter_sgnotificaciontitulo1_cell_Internalname+"\"  class=''>") ;
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "left", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavSgnotificaciontitulo1_Internalname, "SGNotificacion Titulo1", "gx-form-item AttributeLabel", 0, true, "width: 25%;");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 46,'',false,'" + sGXsfl_101_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavSgnotificaciontitulo1_Internalname, AV17SGNotificacionTitulo1, StringUtil.RTrim( context.localUtil.Format( AV17SGNotificacionTitulo1, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,46);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavSgnotificaciontitulo1_Jsonclick, 0, "Attribute", "", "", "", "", edtavSgnotificaciontitulo1_Visible, edtavSgnotificaciontitulo1_Enabled, 0, "text", "", 80, "chr", 1, "row", 100, 0, 0, 0, 1, -1, -1, true, "", "left", true, "", "HLP_Seguridad\\NotificacionesWW.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "<td id=\""+cellDynamicfilters_addfilter1_cell_Internalname+"\"  class=''>") ;
            /* Active images/pictures */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 48,'',false,'',0)\"";
            ClassString = "Image";
            StyleString = "";
            sImgUrl = (string)(context.GetImagePath( "27283ea5-332f-423b-b880-64b762622df3", "", context.GetTheme( )));
            GxWebStd.gx_bitmap( context, imgAdddynamicfilters1_Internalname, sImgUrl, "", "", "", context.GetTheme( ), imgAdddynamicfilters1_Visible, 1, "", "Agregar filtro", 0, 0, 0, "px", 0, "px", 0, 0, 5, imgAdddynamicfilters1_Jsonclick, "'"+""+"'"+",false,"+"'"+"E\\'ADDDYNAMICFILTERS1\\'."+"'", StyleString, ClassString, "", "", "", "", " "+"data-gx-image"+" "+TempTags, "", "", 1, false, false, context.GetImageSrcSet( sImgUrl), "HLP_Seguridad\\NotificacionesWW.htm");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "<td id=\""+cellDynamicfilters_removefilter1_cell_Internalname+"\"  class=''>") ;
            /* Active images/pictures */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 50,'',false,'',0)\"";
            ClassString = "Image";
            StyleString = "";
            sImgUrl = (string)(context.GetImagePath( "11a6ef14-1a5a-4077-91a2-f41ed9a3a662", "", context.GetTheme( )));
            GxWebStd.gx_bitmap( context, imgRemovedynamicfilters1_Internalname, sImgUrl, "", "", "", context.GetTheme( ), imgRemovedynamicfilters1_Visible, 1, "", "Quitar filtro", 0, 0, 0, "px", 0, "px", 0, 0, 5, imgRemovedynamicfilters1_Jsonclick, "'"+""+"'"+",false,"+"'"+"E\\'REMOVEDYNAMICFILTERS1\\'."+"'", StyleString, ClassString, "", "", "", "", " "+"data-gx-image"+" "+TempTags, "", "", 1, false, false, context.GetImageSrcSet( sImgUrl), "HLP_Seguridad\\NotificacionesWW.htm");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "</tr>") ;
            /* End of table */
            context.WriteHtmlText( "</table>") ;
            wb_table2_39_2S2e( true) ;
         }
         else
         {
            wb_table2_39_2S2e( false) ;
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
         PA2S2( ) ;
         WS2S2( ) ;
         WE2S2( ) ;
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
            context.AddJavascriptSource(StringUtil.RTrim( ((string)Form.Jscriptsrc.Item(idxLst))), "?202281810305415", true, true);
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
         context.AddJavascriptSource("seguridad/notificacionesww.js", "?202281810305416", false, true);
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

      protected void SubsflControlProps_1012( )
      {
         cmbavGridactions_Internalname = "vGRIDACTIONS_"+sGXsfl_101_idx;
         edtSGNotificacionID_Internalname = "SGNOTIFICACIONID_"+sGXsfl_101_idx;
         edtSGNotificacionTitulo_Internalname = "SGNOTIFICACIONTITULO_"+sGXsfl_101_idx;
         edtSGNotificacionDescripcion_Internalname = "SGNOTIFICACIONDESCRIPCION_"+sGXsfl_101_idx;
         edtSGNotificacionFecha_Internalname = "SGNOTIFICACIONFECHA_"+sGXsfl_101_idx;
         edtSGNotificacionUsuario_Internalname = "SGNOTIFICACIONUSUARIO_"+sGXsfl_101_idx;
         edtSGNotificacionUsuarioDsc_Internalname = "SGNOTIFICACIONUSUARIODSC_"+sGXsfl_101_idx;
         cmbSGNotificacionIconClass_Internalname = "SGNOTIFICACIONICONCLASS_"+sGXsfl_101_idx;
         edtSGNotificacionTUsuario_Internalname = "SGNOTIFICACIONTUSUARIO_"+sGXsfl_101_idx;
      }

      protected void SubsflControlProps_fel_1012( )
      {
         cmbavGridactions_Internalname = "vGRIDACTIONS_"+sGXsfl_101_fel_idx;
         edtSGNotificacionID_Internalname = "SGNOTIFICACIONID_"+sGXsfl_101_fel_idx;
         edtSGNotificacionTitulo_Internalname = "SGNOTIFICACIONTITULO_"+sGXsfl_101_fel_idx;
         edtSGNotificacionDescripcion_Internalname = "SGNOTIFICACIONDESCRIPCION_"+sGXsfl_101_fel_idx;
         edtSGNotificacionFecha_Internalname = "SGNOTIFICACIONFECHA_"+sGXsfl_101_fel_idx;
         edtSGNotificacionUsuario_Internalname = "SGNOTIFICACIONUSUARIO_"+sGXsfl_101_fel_idx;
         edtSGNotificacionUsuarioDsc_Internalname = "SGNOTIFICACIONUSUARIODSC_"+sGXsfl_101_fel_idx;
         cmbSGNotificacionIconClass_Internalname = "SGNOTIFICACIONICONCLASS_"+sGXsfl_101_fel_idx;
         edtSGNotificacionTUsuario_Internalname = "SGNOTIFICACIONTUSUARIO_"+sGXsfl_101_fel_idx;
      }

      protected void sendrow_1012( )
      {
         SubsflControlProps_1012( ) ;
         WB2S0( ) ;
         if ( ( subGrid_Rows * 1 == 0 ) || ( nGXsfl_101_idx <= subGrid_fnc_Recordsperpage( ) * 1 ) )
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
               if ( ((int)((nGXsfl_101_idx) % (2))) == 0 )
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
               context.WriteHtmlText( " gxrow=\""+sGXsfl_101_idx+"\">") ;
            }
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"right"+"\""+" style=\""+""+"\">") ;
            }
            TempTags = " " + ((cmbavGridactions.Enabled!=0)&&(cmbavGridactions.Visible!=0) ? " onfocus=\"gx.evt.onfocus(this, 102,'',false,'"+sGXsfl_101_idx+"',101)\"" : " ");
            if ( ( cmbavGridactions.ItemCount == 0 ) && isAjaxCallMode( ) )
            {
               GXCCtl = "vGRIDACTIONS_" + sGXsfl_101_idx;
               cmbavGridactions.Name = GXCCtl;
               cmbavGridactions.WebTags = "";
               if ( cmbavGridactions.ItemCount > 0 )
               {
                  AV55GridActions = (short)(NumberUtil.Val( cmbavGridactions.getValidValue(StringUtil.Trim( StringUtil.Str( (decimal)(AV55GridActions), 4, 0))), "."));
                  AssignAttri("", false, cmbavGridactions_Internalname, StringUtil.LTrimStr( (decimal)(AV55GridActions), 4, 0));
               }
            }
            /* ComboBox */
            GridRow.AddColumnProperties("combobox", 2, isAjaxCallMode( ), new Object[] {(GXCombobox)cmbavGridactions,(string)cmbavGridactions_Internalname,StringUtil.Trim( StringUtil.Str( (decimal)(AV55GridActions), 4, 0)),(short)1,(string)cmbavGridactions_Jsonclick,(short)5,"'"+""+"'"+",false,"+"'"+"EVGRIDACTIONS.CLICK."+sGXsfl_101_idx+"'",(string)"int",(string)"",(short)-1,(short)1,(short)0,(short)0,(short)0,(string)"px",(short)0,(string)"px",(string)"",(string)"ConvertToDDO",(string)"WWActionGroupColumn",(string)"",TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+((cmbavGridactions.Enabled!=0)&&(cmbavGridactions.Visible!=0) ? " onblur=\""+""+";gx.evt.onblur(this,102);\"" : " "),(string)"",(bool)true,(short)1});
            cmbavGridactions.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV55GridActions), 4, 0));
            AssignProp("", false, cmbavGridactions_Internalname, "Values", (string)(cmbavGridactions.ToJavascriptSource()), !bGXsfl_101_Refreshing);
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"right"+"\""+" style=\""+""+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtSGNotificacionID_Internalname,StringUtil.LTrim( StringUtil.NToC( (decimal)(A2237SGNotificacionID), 10, 0, ".", "")),StringUtil.LTrim( context.localUtil.Format( (decimal)(A2237SGNotificacionID), "ZZZZZZZZZ9")),(string)" inputmode=\"numeric\" pattern=\"[0-9]*\""+"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtSGNotificacionID_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn hidden-xs",(string)"",(short)-1,(short)0,(short)0,(string)"text",(string)"1",(short)0,(string)"px",(short)17,(string)"px",(short)10,(short)0,(short)0,(short)101,(short)1,(short)-1,(short)0,(bool)true,(string)"",(string)"right",(bool)false,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"left"+"\""+" style=\""+""+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtSGNotificacionTitulo_Internalname,(string)A2238SGNotificacionTitulo,(string)"",(string)"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)edtSGNotificacionTitulo_Link,(string)"",(string)"",(string)"",(string)edtSGNotificacionTitulo_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn",(string)"",(short)-1,(short)0,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)100,(short)0,(short)0,(short)101,(short)1,(short)-1,(short)-1,(bool)true,(string)"",(string)"left",(bool)true,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"left"+"\""+" style=\""+""+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtSGNotificacionDescripcion_Internalname,(string)A2239SGNotificacionDescripcion,(string)"",(string)"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtSGNotificacionDescripcion_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn hidden-xs",(string)"",(short)-1,(short)0,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)200,(short)0,(short)0,(short)101,(short)1,(short)-1,(short)-1,(bool)true,(string)"",(string)"left",(bool)true,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"right"+"\""+" style=\""+""+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtSGNotificacionFecha_Internalname,context.localUtil.TToC( A2240SGNotificacionFecha, 10, 8, 0, 3, "/", ":", " "),context.localUtil.Format( A2240SGNotificacionFecha, "99/99/99 99:99"),(string)"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtSGNotificacionFecha_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn hidden-xs",(string)"",(short)-1,(short)0,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)14,(short)0,(short)0,(short)101,(short)1,(short)-1,(short)0,(bool)true,(string)"",(string)"right",(bool)false,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"left"+"\""+" style=\""+""+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtSGNotificacionUsuario_Internalname,StringUtil.RTrim( A2241SGNotificacionUsuario),(string)"",(string)"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)edtSGNotificacionUsuario_Link,(string)"",(string)"",(string)"",(string)edtSGNotificacionUsuario_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn hidden-xs",(string)"",(short)-1,(short)0,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)10,(short)0,(short)0,(short)101,(short)1,(short)-1,(short)-1,(bool)true,(string)"",(string)"left",(bool)true,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"left"+"\""+" style=\""+""+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtSGNotificacionUsuarioDsc_Internalname,StringUtil.RTrim( A2242SGNotificacionUsuarioDsc),(string)"",(string)"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)edtSGNotificacionUsuarioDsc_Link,(string)"",(string)"",(string)"",(string)edtSGNotificacionUsuarioDsc_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn hidden-xs",(string)"",(short)-1,(short)0,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)100,(short)0,(short)0,(short)101,(short)1,(short)-1,(short)-1,(bool)true,(string)"",(string)"left",(bool)true,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"left"+"\""+" style=\""+""+"\">") ;
            }
            if ( ( cmbSGNotificacionIconClass.ItemCount == 0 ) && isAjaxCallMode( ) )
            {
               GXCCtl = "SGNOTIFICACIONICONCLASS_" + sGXsfl_101_idx;
               cmbSGNotificacionIconClass.Name = GXCCtl;
               cmbSGNotificacionIconClass.WebTags = "";
               cmbSGNotificacionIconClass.addItem("fas fa-info NotificationFontIconInfoLight", "Informativo", 0);
               cmbSGNotificacionIconClass.addItem("fas fa-clipboard-check NotificationFontIconInfo", "Verificación", 0);
               cmbSGNotificacionIconClass.addItem("far fa-thumbs-up NotificationFontIconSuccess", "Conforme", 0);
               cmbSGNotificacionIconClass.addItem("fas fa-exclamation-triangle NotificationFontIconDanger", "Urgente", 0);
               if ( cmbSGNotificacionIconClass.ItemCount > 0 )
               {
                  A2243SGNotificacionIconClass = cmbSGNotificacionIconClass.getValidValue(A2243SGNotificacionIconClass);
               }
            }
            /* ComboBox */
            GridRow.AddColumnProperties("combobox", 2, isAjaxCallMode( ), new Object[] {(GXCombobox)cmbSGNotificacionIconClass,(string)cmbSGNotificacionIconClass_Internalname,StringUtil.RTrim( A2243SGNotificacionIconClass),(short)1,(string)cmbSGNotificacionIconClass_Jsonclick,(short)0,(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"svchar",(string)"",(short)-1,(short)0,(short)0,(short)0,(short)0,(string)"px",(short)0,(string)"px",(string)"",(string)"Attribute",(string)"WWColumn hidden-xs",(string)"",(string)"",(string)"",(bool)true,(short)1});
            cmbSGNotificacionIconClass.CurrentValue = StringUtil.RTrim( A2243SGNotificacionIconClass);
            AssignProp("", false, cmbSGNotificacionIconClass_Internalname, "Values", (string)(cmbSGNotificacionIconClass.ToJavascriptSource()), !bGXsfl_101_Refreshing);
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"right"+"\""+" style=\""+""+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtSGNotificacionTUsuario_Internalname,StringUtil.LTrim( StringUtil.NToC( (decimal)(A2244SGNotificacionTUsuario), 4, 0, ".", "")),StringUtil.LTrim( context.localUtil.Format( (decimal)(A2244SGNotificacionTUsuario), "ZZZ9")),(string)" inputmode=\"numeric\" pattern=\"[0-9]*\""+"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtSGNotificacionTUsuario_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn hidden-xs",(string)"",(short)-1,(short)0,(short)0,(string)"text",(string)"1",(short)0,(string)"px",(short)17,(string)"px",(short)4,(short)0,(short)0,(short)101,(short)1,(short)-1,(short)0,(bool)true,(string)"",(string)"right",(bool)false,(string)""});
            send_integrity_lvl_hashes2S2( ) ;
            GridContainer.AddRow(GridRow);
            nGXsfl_101_idx = ((subGrid_Islastpage==1)&&(nGXsfl_101_idx+1>subGrid_fnc_Recordsperpage( )) ? 1 : nGXsfl_101_idx+1);
            sGXsfl_101_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_101_idx), 4, 0), 4, "0");
            SubsflControlProps_1012( ) ;
         }
         /* End function sendrow_1012 */
      }

      protected void init_web_controls( )
      {
         cmbavDynamicfiltersselector1.Name = "vDYNAMICFILTERSSELECTOR1";
         cmbavDynamicfiltersselector1.WebTags = "";
         cmbavDynamicfiltersselector1.addItem("SGNOTIFICACIONTITULO", "Titulo", 0);
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
         cmbavDynamicfiltersselector2.addItem("SGNOTIFICACIONTITULO", "Titulo", 0);
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
         cmbavDynamicfiltersselector3.addItem("SGNOTIFICACIONTITULO", "Titulo", 0);
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
         GXCCtl = "vGRIDACTIONS_" + sGXsfl_101_idx;
         cmbavGridactions.Name = GXCCtl;
         cmbavGridactions.WebTags = "";
         if ( cmbavGridactions.ItemCount > 0 )
         {
            AV55GridActions = (short)(NumberUtil.Val( cmbavGridactions.getValidValue(StringUtil.Trim( StringUtil.Str( (decimal)(AV55GridActions), 4, 0))), "."));
            AssignAttri("", false, cmbavGridactions_Internalname, StringUtil.LTrimStr( (decimal)(AV55GridActions), 4, 0));
         }
         GXCCtl = "SGNOTIFICACIONICONCLASS_" + sGXsfl_101_idx;
         cmbSGNotificacionIconClass.Name = GXCCtl;
         cmbSGNotificacionIconClass.WebTags = "";
         cmbSGNotificacionIconClass.addItem("fas fa-info NotificationFontIconInfoLight", "Informativo", 0);
         cmbSGNotificacionIconClass.addItem("fas fa-clipboard-check NotificationFontIconInfo", "Verificación", 0);
         cmbSGNotificacionIconClass.addItem("far fa-thumbs-up NotificationFontIconSuccess", "Conforme", 0);
         cmbSGNotificacionIconClass.addItem("fas fa-exclamation-triangle NotificationFontIconDanger", "Urgente", 0);
         if ( cmbSGNotificacionIconClass.ItemCount > 0 )
         {
            A2243SGNotificacionIconClass = cmbSGNotificacionIconClass.getValidValue(A2243SGNotificacionIconClass);
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
         edtavSgnotificaciontitulo1_Internalname = "vSGNOTIFICACIONTITULO1";
         cellFilter_sgnotificaciontitulo1_cell_Internalname = "FILTER_SGNOTIFICACIONTITULO1_CELL";
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
         edtavSgnotificaciontitulo2_Internalname = "vSGNOTIFICACIONTITULO2";
         cellFilter_sgnotificaciontitulo2_cell_Internalname = "FILTER_SGNOTIFICACIONTITULO2_CELL";
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
         edtavSgnotificaciontitulo3_Internalname = "vSGNOTIFICACIONTITULO3";
         cellFilter_sgnotificaciontitulo3_cell_Internalname = "FILTER_SGNOTIFICACIONTITULO3_CELL";
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
         edtSGNotificacionID_Internalname = "SGNOTIFICACIONID";
         edtSGNotificacionTitulo_Internalname = "SGNOTIFICACIONTITULO";
         edtSGNotificacionDescripcion_Internalname = "SGNOTIFICACIONDESCRIPCION";
         edtSGNotificacionFecha_Internalname = "SGNOTIFICACIONFECHA";
         edtSGNotificacionUsuario_Internalname = "SGNOTIFICACIONUSUARIO";
         edtSGNotificacionUsuarioDsc_Internalname = "SGNOTIFICACIONUSUARIODSC";
         cmbSGNotificacionIconClass_Internalname = "SGNOTIFICACIONICONCLASS";
         edtSGNotificacionTUsuario_Internalname = "SGNOTIFICACIONTUSUARIO";
         Gridpaginationbar_Internalname = "GRIDPAGINATIONBAR";
         divGridtablewithpaginationbar_Internalname = "GRIDTABLEWITHPAGINATIONBAR";
         divTablemain_Internalname = "TABLEMAIN";
         Ddo_agexport_Internalname = "DDO_AGEXPORT";
         lblJsdynamicfilters_Internalname = "JSDYNAMICFILTERS";
         Ddo_grid_Internalname = "DDO_GRID";
         Innewwindow1_Internalname = "INNEWWINDOW1";
         Grid_empowerer_Internalname = "GRID_EMPOWERER";
         edtavDdo_sgnotificacionfechaauxdatetext_Internalname = "vDDO_SGNOTIFICACIONFECHAAUXDATETEXT";
         Tfsgnotificacionfecha_rangepicker_Internalname = "TFSGNOTIFICACIONFECHA_RANGEPICKER";
         divDdo_sgnotificacionfechaauxdates_Internalname = "DDO_SGNOTIFICACIONFECHAAUXDATES";
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
         edtSGNotificacionTUsuario_Jsonclick = "";
         cmbSGNotificacionIconClass_Jsonclick = "";
         edtSGNotificacionUsuarioDsc_Jsonclick = "";
         edtSGNotificacionUsuario_Jsonclick = "";
         edtSGNotificacionFecha_Jsonclick = "";
         edtSGNotificacionDescripcion_Jsonclick = "";
         edtSGNotificacionTitulo_Jsonclick = "";
         edtSGNotificacionID_Jsonclick = "";
         cmbavGridactions_Jsonclick = "";
         cmbavGridactions.Visible = -1;
         cmbavGridactions.Enabled = 1;
         imgRemovedynamicfilters1_Visible = 1;
         imgAdddynamicfilters1_Visible = 1;
         edtavSgnotificaciontitulo1_Jsonclick = "";
         edtavSgnotificaciontitulo1_Enabled = 1;
         cmbavDynamicfiltersoperator1_Jsonclick = "";
         cmbavDynamicfiltersoperator1.Enabled = 1;
         imgRemovedynamicfilters2_Visible = 1;
         imgAdddynamicfilters2_Visible = 1;
         edtavSgnotificaciontitulo2_Jsonclick = "";
         edtavSgnotificaciontitulo2_Enabled = 1;
         cmbavDynamicfiltersoperator2_Jsonclick = "";
         cmbavDynamicfiltersoperator2.Enabled = 1;
         edtavSgnotificaciontitulo3_Jsonclick = "";
         edtavSgnotificaciontitulo3_Enabled = 1;
         cmbavDynamicfiltersoperator3_Jsonclick = "";
         cmbavDynamicfiltersoperator3.Enabled = 1;
         cmbavDynamicfiltersselector3_Jsonclick = "";
         cmbavDynamicfiltersselector3.Enabled = 1;
         cmbavDynamicfiltersselector2_Jsonclick = "";
         cmbavDynamicfiltersselector2.Enabled = 1;
         cmbavDynamicfiltersselector1_Jsonclick = "";
         cmbavDynamicfiltersselector1.Enabled = 1;
         cmbavDynamicfiltersoperator3.Visible = 1;
         edtavSgnotificaciontitulo3_Visible = 1;
         cmbavDynamicfiltersoperator2.Visible = 1;
         edtavSgnotificaciontitulo2_Visible = 1;
         cmbavDynamicfiltersoperator1.Visible = 1;
         edtavSgnotificaciontitulo1_Visible = 1;
         edtavDdo_sgnotificacionfechaauxdatetext_Jsonclick = "";
         lblJsdynamicfilters_Caption = "JSDynamicFilters";
         subGrid_Allowcollapsing = 0;
         subGrid_Allowselection = 0;
         edtSGNotificacionUsuarioDsc_Link = "";
         edtSGNotificacionUsuario_Link = "";
         edtSGNotificacionTitulo_Link = "";
         subGrid_Sortable = 0;
         subGrid_Header = "";
         subGrid_Class = "GridWithPaginationBar WorkWith";
         subGrid_Backcolorstyle = 0;
         Grid_empowerer_Hastitlesettings = Convert.ToBoolean( -1);
         Innewwindow1_Target = "";
         Innewwindow1_Height = "50";
         Innewwindow1_Width = "50";
         Ddo_grid_Datalistproc = "Seguridad.NotificacionesWWGetFilterData";
         Ddo_grid_Datalistfixedvalues = "||||||fas fa-info NotificationFontIconInfoLight:Informativo,fas fa-clipboard-check NotificationFontIconInfo:Verificación,far fa-thumbs-up NotificationFontIconSuccess:Conforme,fas fa-exclamation-triangle NotificationFontIconDanger:Urgente|";
         Ddo_grid_Allowmultipleselection = "||||||T|";
         Ddo_grid_Datalisttype = "|Dynamic|Dynamic||Dynamic|Dynamic|FixedValues|";
         Ddo_grid_Includedatalist = "|T|T||T|T|T|";
         Ddo_grid_Filterisrange = "T|||P||||T";
         Ddo_grid_Filtertype = "Numeric|Character|Character|Date|Character|Character||Numeric";
         Ddo_grid_Includefilter = "T|T|T|T|T|T||T";
         Ddo_grid_Includesortasc = "T";
         Ddo_grid_Columnssortvalues = "2|1|3|4|5|6|7|8";
         Ddo_grid_Columnids = "1:SGNotificacionID|2:SGNotificacionTitulo|3:SGNotificacionDescripcion|4:SGNotificacionFecha|5:SGNotificacionUsuario|6:SGNotificacionUsuarioDsc|7:SGNotificacionIconClass|8:SGNotificacionTUsuario";
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
         Form.Caption = " Notificaciones";
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
         setEventMetadata("REFRESH","{handler:'Refresh',iparms:[{av:'GRID_nFirstRecordOnPage'},{av:'GRID_nEOF'},{av:'subGrid_Rows',ctrl:'GRID',prop:'Rows'},{av:'cmbavDynamicfiltersselector1'},{av:'AV15DynamicFiltersSelector1',fld:'vDYNAMICFILTERSSELECTOR1',pic:''},{av:'cmbavDynamicfiltersoperator1'},{av:'AV16DynamicFiltersOperator1',fld:'vDYNAMICFILTERSOPERATOR1',pic:'ZZZ9'},{av:'AV17SGNotificacionTitulo1',fld:'vSGNOTIFICACIONTITULO1',pic:''},{av:'cmbavDynamicfiltersselector2'},{av:'AV19DynamicFiltersSelector2',fld:'vDYNAMICFILTERSSELECTOR2',pic:''},{av:'cmbavDynamicfiltersoperator2'},{av:'AV20DynamicFiltersOperator2',fld:'vDYNAMICFILTERSOPERATOR2',pic:'ZZZ9'},{av:'AV21SGNotificacionTitulo2',fld:'vSGNOTIFICACIONTITULO2',pic:''},{av:'cmbavDynamicfiltersselector3'},{av:'AV23DynamicFiltersSelector3',fld:'vDYNAMICFILTERSSELECTOR3',pic:''},{av:'cmbavDynamicfiltersoperator3'},{av:'AV24DynamicFiltersOperator3',fld:'vDYNAMICFILTERSOPERATOR3',pic:'ZZZ9'},{av:'AV25SGNotificacionTitulo3',fld:'vSGNOTIFICACIONTITULO3',pic:''},{av:'AV60Pgmname',fld:'vPGMNAME',pic:'',hsh:true},{av:'AV18DynamicFiltersEnabled2',fld:'vDYNAMICFILTERSENABLED2',pic:''},{av:'AV22DynamicFiltersEnabled3',fld:'vDYNAMICFILTERSENABLED3',pic:''},{av:'AV31TFSGNotificacionID',fld:'vTFSGNOTIFICACIONID',pic:'ZZZZZZZZZ9'},{av:'AV32TFSGNotificacionID_To',fld:'vTFSGNOTIFICACIONID_TO',pic:'ZZZZZZZZZ9'},{av:'AV33TFSGNotificacionTitulo',fld:'vTFSGNOTIFICACIONTITULO',pic:''},{av:'AV34TFSGNotificacionTitulo_Sel',fld:'vTFSGNOTIFICACIONTITULO_SEL',pic:''},{av:'AV35TFSGNotificacionDescripcion',fld:'vTFSGNOTIFICACIONDESCRIPCION',pic:''},{av:'AV36TFSGNotificacionDescripcion_Sel',fld:'vTFSGNOTIFICACIONDESCRIPCION_SEL',pic:''},{av:'AV37TFSGNotificacionFecha',fld:'vTFSGNOTIFICACIONFECHA',pic:'99/99/99 99:99'},{av:'AV38TFSGNotificacionFecha_To',fld:'vTFSGNOTIFICACIONFECHA_TO',pic:'99/99/99 99:99'},{av:'AV42TFSGNotificacionUsuario',fld:'vTFSGNOTIFICACIONUSUARIO',pic:''},{av:'AV43TFSGNotificacionUsuario_Sel',fld:'vTFSGNOTIFICACIONUSUARIO_SEL',pic:''},{av:'AV44TFSGNotificacionUsuarioDsc',fld:'vTFSGNOTIFICACIONUSUARIODSC',pic:''},{av:'AV45TFSGNotificacionUsuarioDsc_Sel',fld:'vTFSGNOTIFICACIONUSUARIODSC_SEL',pic:''},{av:'AV47TFSGNotificacionIconClass_Sels',fld:'vTFSGNOTIFICACIONICONCLASS_SELS',pic:''},{av:'AV48TFSGNotificacionTUsuario',fld:'vTFSGNOTIFICACIONTUSUARIO',pic:'ZZZ9'},{av:'AV49TFSGNotificacionTUsuario_To',fld:'vTFSGNOTIFICACIONTUSUARIO_TO',pic:'ZZZ9'},{av:'AV13OrderedBy',fld:'vORDEREDBY',pic:'ZZZ9'},{av:'AV14OrderedDsc',fld:'vORDEREDDSC',pic:''},{av:'AV10GridState',fld:'vGRIDSTATE',pic:''},{av:'AV27DynamicFiltersIgnoreFirst',fld:'vDYNAMICFILTERSIGNOREFIRST',pic:''},{av:'AV26DynamicFiltersRemoving',fld:'vDYNAMICFILTERSREMOVING',pic:''}]");
         setEventMetadata("REFRESH",",oparms:[{av:'AV52GridCurrentPage',fld:'vGRIDCURRENTPAGE',pic:'ZZZZZZZZZ9'},{av:'AV53GridPageCount',fld:'vGRIDPAGECOUNT',pic:'ZZZZZZZZZ9'},{av:'AV54GridAppliedFilters',fld:'vGRIDAPPLIEDFILTERS',pic:''},{av:'AV10GridState',fld:'vGRIDSTATE',pic:''}]}");
         setEventMetadata("GRIDPAGINATIONBAR.CHANGEPAGE","{handler:'E112S2',iparms:[{av:'GRID_nFirstRecordOnPage'},{av:'GRID_nEOF'},{av:'subGrid_Rows',ctrl:'GRID',prop:'Rows'},{av:'cmbavDynamicfiltersselector1'},{av:'AV15DynamicFiltersSelector1',fld:'vDYNAMICFILTERSSELECTOR1',pic:''},{av:'cmbavDynamicfiltersoperator1'},{av:'AV16DynamicFiltersOperator1',fld:'vDYNAMICFILTERSOPERATOR1',pic:'ZZZ9'},{av:'AV17SGNotificacionTitulo1',fld:'vSGNOTIFICACIONTITULO1',pic:''},{av:'cmbavDynamicfiltersselector2'},{av:'AV19DynamicFiltersSelector2',fld:'vDYNAMICFILTERSSELECTOR2',pic:''},{av:'cmbavDynamicfiltersoperator2'},{av:'AV20DynamicFiltersOperator2',fld:'vDYNAMICFILTERSOPERATOR2',pic:'ZZZ9'},{av:'AV21SGNotificacionTitulo2',fld:'vSGNOTIFICACIONTITULO2',pic:''},{av:'cmbavDynamicfiltersselector3'},{av:'AV23DynamicFiltersSelector3',fld:'vDYNAMICFILTERSSELECTOR3',pic:''},{av:'cmbavDynamicfiltersoperator3'},{av:'AV24DynamicFiltersOperator3',fld:'vDYNAMICFILTERSOPERATOR3',pic:'ZZZ9'},{av:'AV25SGNotificacionTitulo3',fld:'vSGNOTIFICACIONTITULO3',pic:''},{av:'AV60Pgmname',fld:'vPGMNAME',pic:'',hsh:true},{av:'AV18DynamicFiltersEnabled2',fld:'vDYNAMICFILTERSENABLED2',pic:''},{av:'AV22DynamicFiltersEnabled3',fld:'vDYNAMICFILTERSENABLED3',pic:''},{av:'AV31TFSGNotificacionID',fld:'vTFSGNOTIFICACIONID',pic:'ZZZZZZZZZ9'},{av:'AV32TFSGNotificacionID_To',fld:'vTFSGNOTIFICACIONID_TO',pic:'ZZZZZZZZZ9'},{av:'AV33TFSGNotificacionTitulo',fld:'vTFSGNOTIFICACIONTITULO',pic:''},{av:'AV34TFSGNotificacionTitulo_Sel',fld:'vTFSGNOTIFICACIONTITULO_SEL',pic:''},{av:'AV35TFSGNotificacionDescripcion',fld:'vTFSGNOTIFICACIONDESCRIPCION',pic:''},{av:'AV36TFSGNotificacionDescripcion_Sel',fld:'vTFSGNOTIFICACIONDESCRIPCION_SEL',pic:''},{av:'AV37TFSGNotificacionFecha',fld:'vTFSGNOTIFICACIONFECHA',pic:'99/99/99 99:99'},{av:'AV38TFSGNotificacionFecha_To',fld:'vTFSGNOTIFICACIONFECHA_TO',pic:'99/99/99 99:99'},{av:'AV42TFSGNotificacionUsuario',fld:'vTFSGNOTIFICACIONUSUARIO',pic:''},{av:'AV43TFSGNotificacionUsuario_Sel',fld:'vTFSGNOTIFICACIONUSUARIO_SEL',pic:''},{av:'AV44TFSGNotificacionUsuarioDsc',fld:'vTFSGNOTIFICACIONUSUARIODSC',pic:''},{av:'AV45TFSGNotificacionUsuarioDsc_Sel',fld:'vTFSGNOTIFICACIONUSUARIODSC_SEL',pic:''},{av:'AV47TFSGNotificacionIconClass_Sels',fld:'vTFSGNOTIFICACIONICONCLASS_SELS',pic:''},{av:'AV48TFSGNotificacionTUsuario',fld:'vTFSGNOTIFICACIONTUSUARIO',pic:'ZZZ9'},{av:'AV49TFSGNotificacionTUsuario_To',fld:'vTFSGNOTIFICACIONTUSUARIO_TO',pic:'ZZZ9'},{av:'AV13OrderedBy',fld:'vORDEREDBY',pic:'ZZZ9'},{av:'AV14OrderedDsc',fld:'vORDEREDDSC',pic:''},{av:'AV10GridState',fld:'vGRIDSTATE',pic:''},{av:'AV27DynamicFiltersIgnoreFirst',fld:'vDYNAMICFILTERSIGNOREFIRST',pic:''},{av:'AV26DynamicFiltersRemoving',fld:'vDYNAMICFILTERSREMOVING',pic:''},{av:'Gridpaginationbar_Selectedpage',ctrl:'GRIDPAGINATIONBAR',prop:'SelectedPage'}]");
         setEventMetadata("GRIDPAGINATIONBAR.CHANGEPAGE",",oparms:[]}");
         setEventMetadata("GRIDPAGINATIONBAR.CHANGEROWSPERPAGE","{handler:'E122S2',iparms:[{av:'GRID_nFirstRecordOnPage'},{av:'GRID_nEOF'},{av:'subGrid_Rows',ctrl:'GRID',prop:'Rows'},{av:'cmbavDynamicfiltersselector1'},{av:'AV15DynamicFiltersSelector1',fld:'vDYNAMICFILTERSSELECTOR1',pic:''},{av:'cmbavDynamicfiltersoperator1'},{av:'AV16DynamicFiltersOperator1',fld:'vDYNAMICFILTERSOPERATOR1',pic:'ZZZ9'},{av:'AV17SGNotificacionTitulo1',fld:'vSGNOTIFICACIONTITULO1',pic:''},{av:'cmbavDynamicfiltersselector2'},{av:'AV19DynamicFiltersSelector2',fld:'vDYNAMICFILTERSSELECTOR2',pic:''},{av:'cmbavDynamicfiltersoperator2'},{av:'AV20DynamicFiltersOperator2',fld:'vDYNAMICFILTERSOPERATOR2',pic:'ZZZ9'},{av:'AV21SGNotificacionTitulo2',fld:'vSGNOTIFICACIONTITULO2',pic:''},{av:'cmbavDynamicfiltersselector3'},{av:'AV23DynamicFiltersSelector3',fld:'vDYNAMICFILTERSSELECTOR3',pic:''},{av:'cmbavDynamicfiltersoperator3'},{av:'AV24DynamicFiltersOperator3',fld:'vDYNAMICFILTERSOPERATOR3',pic:'ZZZ9'},{av:'AV25SGNotificacionTitulo3',fld:'vSGNOTIFICACIONTITULO3',pic:''},{av:'AV60Pgmname',fld:'vPGMNAME',pic:'',hsh:true},{av:'AV18DynamicFiltersEnabled2',fld:'vDYNAMICFILTERSENABLED2',pic:''},{av:'AV22DynamicFiltersEnabled3',fld:'vDYNAMICFILTERSENABLED3',pic:''},{av:'AV31TFSGNotificacionID',fld:'vTFSGNOTIFICACIONID',pic:'ZZZZZZZZZ9'},{av:'AV32TFSGNotificacionID_To',fld:'vTFSGNOTIFICACIONID_TO',pic:'ZZZZZZZZZ9'},{av:'AV33TFSGNotificacionTitulo',fld:'vTFSGNOTIFICACIONTITULO',pic:''},{av:'AV34TFSGNotificacionTitulo_Sel',fld:'vTFSGNOTIFICACIONTITULO_SEL',pic:''},{av:'AV35TFSGNotificacionDescripcion',fld:'vTFSGNOTIFICACIONDESCRIPCION',pic:''},{av:'AV36TFSGNotificacionDescripcion_Sel',fld:'vTFSGNOTIFICACIONDESCRIPCION_SEL',pic:''},{av:'AV37TFSGNotificacionFecha',fld:'vTFSGNOTIFICACIONFECHA',pic:'99/99/99 99:99'},{av:'AV38TFSGNotificacionFecha_To',fld:'vTFSGNOTIFICACIONFECHA_TO',pic:'99/99/99 99:99'},{av:'AV42TFSGNotificacionUsuario',fld:'vTFSGNOTIFICACIONUSUARIO',pic:''},{av:'AV43TFSGNotificacionUsuario_Sel',fld:'vTFSGNOTIFICACIONUSUARIO_SEL',pic:''},{av:'AV44TFSGNotificacionUsuarioDsc',fld:'vTFSGNOTIFICACIONUSUARIODSC',pic:''},{av:'AV45TFSGNotificacionUsuarioDsc_Sel',fld:'vTFSGNOTIFICACIONUSUARIODSC_SEL',pic:''},{av:'AV47TFSGNotificacionIconClass_Sels',fld:'vTFSGNOTIFICACIONICONCLASS_SELS',pic:''},{av:'AV48TFSGNotificacionTUsuario',fld:'vTFSGNOTIFICACIONTUSUARIO',pic:'ZZZ9'},{av:'AV49TFSGNotificacionTUsuario_To',fld:'vTFSGNOTIFICACIONTUSUARIO_TO',pic:'ZZZ9'},{av:'AV13OrderedBy',fld:'vORDEREDBY',pic:'ZZZ9'},{av:'AV14OrderedDsc',fld:'vORDEREDDSC',pic:''},{av:'AV10GridState',fld:'vGRIDSTATE',pic:''},{av:'AV27DynamicFiltersIgnoreFirst',fld:'vDYNAMICFILTERSIGNOREFIRST',pic:''},{av:'AV26DynamicFiltersRemoving',fld:'vDYNAMICFILTERSREMOVING',pic:''},{av:'Gridpaginationbar_Rowsperpageselectedvalue',ctrl:'GRIDPAGINATIONBAR',prop:'RowsPerPageSelectedValue'}]");
         setEventMetadata("GRIDPAGINATIONBAR.CHANGEROWSPERPAGE",",oparms:[{av:'subGrid_Rows',ctrl:'GRID',prop:'Rows'}]}");
         setEventMetadata("DDO_GRID.ONOPTIONCLICKED","{handler:'E142S2',iparms:[{av:'GRID_nFirstRecordOnPage'},{av:'GRID_nEOF'},{av:'subGrid_Rows',ctrl:'GRID',prop:'Rows'},{av:'cmbavDynamicfiltersselector1'},{av:'AV15DynamicFiltersSelector1',fld:'vDYNAMICFILTERSSELECTOR1',pic:''},{av:'cmbavDynamicfiltersoperator1'},{av:'AV16DynamicFiltersOperator1',fld:'vDYNAMICFILTERSOPERATOR1',pic:'ZZZ9'},{av:'AV17SGNotificacionTitulo1',fld:'vSGNOTIFICACIONTITULO1',pic:''},{av:'cmbavDynamicfiltersselector2'},{av:'AV19DynamicFiltersSelector2',fld:'vDYNAMICFILTERSSELECTOR2',pic:''},{av:'cmbavDynamicfiltersoperator2'},{av:'AV20DynamicFiltersOperator2',fld:'vDYNAMICFILTERSOPERATOR2',pic:'ZZZ9'},{av:'AV21SGNotificacionTitulo2',fld:'vSGNOTIFICACIONTITULO2',pic:''},{av:'cmbavDynamicfiltersselector3'},{av:'AV23DynamicFiltersSelector3',fld:'vDYNAMICFILTERSSELECTOR3',pic:''},{av:'cmbavDynamicfiltersoperator3'},{av:'AV24DynamicFiltersOperator3',fld:'vDYNAMICFILTERSOPERATOR3',pic:'ZZZ9'},{av:'AV25SGNotificacionTitulo3',fld:'vSGNOTIFICACIONTITULO3',pic:''},{av:'AV60Pgmname',fld:'vPGMNAME',pic:'',hsh:true},{av:'AV18DynamicFiltersEnabled2',fld:'vDYNAMICFILTERSENABLED2',pic:''},{av:'AV22DynamicFiltersEnabled3',fld:'vDYNAMICFILTERSENABLED3',pic:''},{av:'AV31TFSGNotificacionID',fld:'vTFSGNOTIFICACIONID',pic:'ZZZZZZZZZ9'},{av:'AV32TFSGNotificacionID_To',fld:'vTFSGNOTIFICACIONID_TO',pic:'ZZZZZZZZZ9'},{av:'AV33TFSGNotificacionTitulo',fld:'vTFSGNOTIFICACIONTITULO',pic:''},{av:'AV34TFSGNotificacionTitulo_Sel',fld:'vTFSGNOTIFICACIONTITULO_SEL',pic:''},{av:'AV35TFSGNotificacionDescripcion',fld:'vTFSGNOTIFICACIONDESCRIPCION',pic:''},{av:'AV36TFSGNotificacionDescripcion_Sel',fld:'vTFSGNOTIFICACIONDESCRIPCION_SEL',pic:''},{av:'AV37TFSGNotificacionFecha',fld:'vTFSGNOTIFICACIONFECHA',pic:'99/99/99 99:99'},{av:'AV38TFSGNotificacionFecha_To',fld:'vTFSGNOTIFICACIONFECHA_TO',pic:'99/99/99 99:99'},{av:'AV42TFSGNotificacionUsuario',fld:'vTFSGNOTIFICACIONUSUARIO',pic:''},{av:'AV43TFSGNotificacionUsuario_Sel',fld:'vTFSGNOTIFICACIONUSUARIO_SEL',pic:''},{av:'AV44TFSGNotificacionUsuarioDsc',fld:'vTFSGNOTIFICACIONUSUARIODSC',pic:''},{av:'AV45TFSGNotificacionUsuarioDsc_Sel',fld:'vTFSGNOTIFICACIONUSUARIODSC_SEL',pic:''},{av:'AV47TFSGNotificacionIconClass_Sels',fld:'vTFSGNOTIFICACIONICONCLASS_SELS',pic:''},{av:'AV48TFSGNotificacionTUsuario',fld:'vTFSGNOTIFICACIONTUSUARIO',pic:'ZZZ9'},{av:'AV49TFSGNotificacionTUsuario_To',fld:'vTFSGNOTIFICACIONTUSUARIO_TO',pic:'ZZZ9'},{av:'AV13OrderedBy',fld:'vORDEREDBY',pic:'ZZZ9'},{av:'AV14OrderedDsc',fld:'vORDEREDDSC',pic:''},{av:'AV10GridState',fld:'vGRIDSTATE',pic:''},{av:'AV27DynamicFiltersIgnoreFirst',fld:'vDYNAMICFILTERSIGNOREFIRST',pic:''},{av:'AV26DynamicFiltersRemoving',fld:'vDYNAMICFILTERSREMOVING',pic:''},{av:'Ddo_grid_Activeeventkey',ctrl:'DDO_GRID',prop:'ActiveEventKey'},{av:'Ddo_grid_Selectedvalue_get',ctrl:'DDO_GRID',prop:'SelectedValue_get'},{av:'Ddo_grid_Filteredtextto_get',ctrl:'DDO_GRID',prop:'FilteredTextTo_get'},{av:'Ddo_grid_Filteredtext_get',ctrl:'DDO_GRID',prop:'FilteredText_get'},{av:'Ddo_grid_Selectedcolumn',ctrl:'DDO_GRID',prop:'SelectedColumn'}]");
         setEventMetadata("DDO_GRID.ONOPTIONCLICKED",",oparms:[{av:'AV13OrderedBy',fld:'vORDEREDBY',pic:'ZZZ9'},{av:'AV14OrderedDsc',fld:'vORDEREDDSC',pic:''},{av:'AV48TFSGNotificacionTUsuario',fld:'vTFSGNOTIFICACIONTUSUARIO',pic:'ZZZ9'},{av:'AV49TFSGNotificacionTUsuario_To',fld:'vTFSGNOTIFICACIONTUSUARIO_TO',pic:'ZZZ9'},{av:'AV46TFSGNotificacionIconClass_SelsJson',fld:'vTFSGNOTIFICACIONICONCLASS_SELSJSON',pic:''},{av:'AV47TFSGNotificacionIconClass_Sels',fld:'vTFSGNOTIFICACIONICONCLASS_SELS',pic:''},{av:'AV44TFSGNotificacionUsuarioDsc',fld:'vTFSGNOTIFICACIONUSUARIODSC',pic:''},{av:'AV45TFSGNotificacionUsuarioDsc_Sel',fld:'vTFSGNOTIFICACIONUSUARIODSC_SEL',pic:''},{av:'AV42TFSGNotificacionUsuario',fld:'vTFSGNOTIFICACIONUSUARIO',pic:''},{av:'AV43TFSGNotificacionUsuario_Sel',fld:'vTFSGNOTIFICACIONUSUARIO_SEL',pic:''},{av:'AV37TFSGNotificacionFecha',fld:'vTFSGNOTIFICACIONFECHA',pic:'99/99/99 99:99'},{av:'AV38TFSGNotificacionFecha_To',fld:'vTFSGNOTIFICACIONFECHA_TO',pic:'99/99/99 99:99'},{av:'AV35TFSGNotificacionDescripcion',fld:'vTFSGNOTIFICACIONDESCRIPCION',pic:''},{av:'AV36TFSGNotificacionDescripcion_Sel',fld:'vTFSGNOTIFICACIONDESCRIPCION_SEL',pic:''},{av:'AV33TFSGNotificacionTitulo',fld:'vTFSGNOTIFICACIONTITULO',pic:''},{av:'AV34TFSGNotificacionTitulo_Sel',fld:'vTFSGNOTIFICACIONTITULO_SEL',pic:''},{av:'AV31TFSGNotificacionID',fld:'vTFSGNOTIFICACIONID',pic:'ZZZZZZZZZ9'},{av:'AV32TFSGNotificacionID_To',fld:'vTFSGNOTIFICACIONID_TO',pic:'ZZZZZZZZZ9'},{av:'Ddo_grid_Sortedstatus',ctrl:'DDO_GRID',prop:'SortedStatus'}]}");
         setEventMetadata("GRID.LOAD","{handler:'E262S2',iparms:[{av:'A2237SGNotificacionID',fld:'SGNOTIFICACIONID',pic:'ZZZZZZZZZ9',hsh:true},{av:'A2241SGNotificacionUsuario',fld:'SGNOTIFICACIONUSUARIO',pic:''}]");
         setEventMetadata("GRID.LOAD",",oparms:[{av:'cmbavGridactions'},{av:'AV55GridActions',fld:'vGRIDACTIONS',pic:'ZZZ9'},{av:'edtSGNotificacionTitulo_Link',ctrl:'SGNOTIFICACIONTITULO',prop:'Link'},{av:'edtSGNotificacionUsuario_Link',ctrl:'SGNOTIFICACIONUSUARIO',prop:'Link'},{av:'edtSGNotificacionUsuarioDsc_Link',ctrl:'SGNOTIFICACIONUSUARIODSC',prop:'Link'}]}");
         setEventMetadata("'ADDDYNAMICFILTERS1'","{handler:'E192S2',iparms:[]");
         setEventMetadata("'ADDDYNAMICFILTERS1'",",oparms:[{av:'AV18DynamicFiltersEnabled2',fld:'vDYNAMICFILTERSENABLED2',pic:''},{av:'imgAdddynamicfilters1_Visible',ctrl:'ADDDYNAMICFILTERS1',prop:'Visible'},{av:'imgRemovedynamicfilters1_Visible',ctrl:'REMOVEDYNAMICFILTERS1',prop:'Visible'}]}");
         setEventMetadata("'REMOVEDYNAMICFILTERS1'","{handler:'E152S2',iparms:[{av:'GRID_nFirstRecordOnPage'},{av:'GRID_nEOF'},{av:'subGrid_Rows',ctrl:'GRID',prop:'Rows'},{av:'cmbavDynamicfiltersselector1'},{av:'AV15DynamicFiltersSelector1',fld:'vDYNAMICFILTERSSELECTOR1',pic:''},{av:'cmbavDynamicfiltersoperator1'},{av:'AV16DynamicFiltersOperator1',fld:'vDYNAMICFILTERSOPERATOR1',pic:'ZZZ9'},{av:'AV17SGNotificacionTitulo1',fld:'vSGNOTIFICACIONTITULO1',pic:''},{av:'cmbavDynamicfiltersselector2'},{av:'AV19DynamicFiltersSelector2',fld:'vDYNAMICFILTERSSELECTOR2',pic:''},{av:'cmbavDynamicfiltersoperator2'},{av:'AV20DynamicFiltersOperator2',fld:'vDYNAMICFILTERSOPERATOR2',pic:'ZZZ9'},{av:'AV21SGNotificacionTitulo2',fld:'vSGNOTIFICACIONTITULO2',pic:''},{av:'cmbavDynamicfiltersselector3'},{av:'AV23DynamicFiltersSelector3',fld:'vDYNAMICFILTERSSELECTOR3',pic:''},{av:'cmbavDynamicfiltersoperator3'},{av:'AV24DynamicFiltersOperator3',fld:'vDYNAMICFILTERSOPERATOR3',pic:'ZZZ9'},{av:'AV25SGNotificacionTitulo3',fld:'vSGNOTIFICACIONTITULO3',pic:''},{av:'AV60Pgmname',fld:'vPGMNAME',pic:'',hsh:true},{av:'AV18DynamicFiltersEnabled2',fld:'vDYNAMICFILTERSENABLED2',pic:''},{av:'AV22DynamicFiltersEnabled3',fld:'vDYNAMICFILTERSENABLED3',pic:''},{av:'AV31TFSGNotificacionID',fld:'vTFSGNOTIFICACIONID',pic:'ZZZZZZZZZ9'},{av:'AV32TFSGNotificacionID_To',fld:'vTFSGNOTIFICACIONID_TO',pic:'ZZZZZZZZZ9'},{av:'AV33TFSGNotificacionTitulo',fld:'vTFSGNOTIFICACIONTITULO',pic:''},{av:'AV34TFSGNotificacionTitulo_Sel',fld:'vTFSGNOTIFICACIONTITULO_SEL',pic:''},{av:'AV35TFSGNotificacionDescripcion',fld:'vTFSGNOTIFICACIONDESCRIPCION',pic:''},{av:'AV36TFSGNotificacionDescripcion_Sel',fld:'vTFSGNOTIFICACIONDESCRIPCION_SEL',pic:''},{av:'AV37TFSGNotificacionFecha',fld:'vTFSGNOTIFICACIONFECHA',pic:'99/99/99 99:99'},{av:'AV38TFSGNotificacionFecha_To',fld:'vTFSGNOTIFICACIONFECHA_TO',pic:'99/99/99 99:99'},{av:'AV42TFSGNotificacionUsuario',fld:'vTFSGNOTIFICACIONUSUARIO',pic:''},{av:'AV43TFSGNotificacionUsuario_Sel',fld:'vTFSGNOTIFICACIONUSUARIO_SEL',pic:''},{av:'AV44TFSGNotificacionUsuarioDsc',fld:'vTFSGNOTIFICACIONUSUARIODSC',pic:''},{av:'AV45TFSGNotificacionUsuarioDsc_Sel',fld:'vTFSGNOTIFICACIONUSUARIODSC_SEL',pic:''},{av:'AV47TFSGNotificacionIconClass_Sels',fld:'vTFSGNOTIFICACIONICONCLASS_SELS',pic:''},{av:'AV48TFSGNotificacionTUsuario',fld:'vTFSGNOTIFICACIONTUSUARIO',pic:'ZZZ9'},{av:'AV49TFSGNotificacionTUsuario_To',fld:'vTFSGNOTIFICACIONTUSUARIO_TO',pic:'ZZZ9'},{av:'AV13OrderedBy',fld:'vORDEREDBY',pic:'ZZZ9'},{av:'AV14OrderedDsc',fld:'vORDEREDDSC',pic:''},{av:'AV10GridState',fld:'vGRIDSTATE',pic:''},{av:'AV27DynamicFiltersIgnoreFirst',fld:'vDYNAMICFILTERSIGNOREFIRST',pic:''},{av:'AV26DynamicFiltersRemoving',fld:'vDYNAMICFILTERSREMOVING',pic:''}]");
         setEventMetadata("'REMOVEDYNAMICFILTERS1'",",oparms:[{av:'AV26DynamicFiltersRemoving',fld:'vDYNAMICFILTERSREMOVING',pic:''},{av:'AV27DynamicFiltersIgnoreFirst',fld:'vDYNAMICFILTERSIGNOREFIRST',pic:''},{av:'AV10GridState',fld:'vGRIDSTATE',pic:''},{av:'AV18DynamicFiltersEnabled2',fld:'vDYNAMICFILTERSENABLED2',pic:''},{av:'cmbavDynamicfiltersselector2'},{av:'AV19DynamicFiltersSelector2',fld:'vDYNAMICFILTERSSELECTOR2',pic:''},{av:'cmbavDynamicfiltersoperator2'},{av:'AV20DynamicFiltersOperator2',fld:'vDYNAMICFILTERSOPERATOR2',pic:'ZZZ9'},{av:'AV21SGNotificacionTitulo2',fld:'vSGNOTIFICACIONTITULO2',pic:''},{av:'AV22DynamicFiltersEnabled3',fld:'vDYNAMICFILTERSENABLED3',pic:''},{av:'cmbavDynamicfiltersselector3'},{av:'AV23DynamicFiltersSelector3',fld:'vDYNAMICFILTERSSELECTOR3',pic:''},{av:'cmbavDynamicfiltersoperator3'},{av:'AV24DynamicFiltersOperator3',fld:'vDYNAMICFILTERSOPERATOR3',pic:'ZZZ9'},{av:'AV25SGNotificacionTitulo3',fld:'vSGNOTIFICACIONTITULO3',pic:''},{av:'imgAdddynamicfilters1_Visible',ctrl:'ADDDYNAMICFILTERS1',prop:'Visible'},{av:'imgRemovedynamicfilters1_Visible',ctrl:'REMOVEDYNAMICFILTERS1',prop:'Visible'},{av:'imgAdddynamicfilters2_Visible',ctrl:'ADDDYNAMICFILTERS2',prop:'Visible'},{av:'imgRemovedynamicfilters2_Visible',ctrl:'REMOVEDYNAMICFILTERS2',prop:'Visible'},{av:'cmbavDynamicfiltersselector1'},{av:'AV15DynamicFiltersSelector1',fld:'vDYNAMICFILTERSSELECTOR1',pic:''},{av:'cmbavDynamicfiltersoperator1'},{av:'AV16DynamicFiltersOperator1',fld:'vDYNAMICFILTERSOPERATOR1',pic:'ZZZ9'},{av:'AV17SGNotificacionTitulo1',fld:'vSGNOTIFICACIONTITULO1',pic:''},{av:'lblJsdynamicfilters_Caption',ctrl:'JSDYNAMICFILTERS',prop:'Caption'},{av:'edtavSgnotificaciontitulo2_Visible',ctrl:'vSGNOTIFICACIONTITULO2',prop:'Visible'},{av:'edtavSgnotificaciontitulo3_Visible',ctrl:'vSGNOTIFICACIONTITULO3',prop:'Visible'},{av:'edtavSgnotificaciontitulo1_Visible',ctrl:'vSGNOTIFICACIONTITULO1',prop:'Visible'},{av:'AV52GridCurrentPage',fld:'vGRIDCURRENTPAGE',pic:'ZZZZZZZZZ9'},{av:'AV53GridPageCount',fld:'vGRIDPAGECOUNT',pic:'ZZZZZZZZZ9'},{av:'AV54GridAppliedFilters',fld:'vGRIDAPPLIEDFILTERS',pic:''}]}");
         setEventMetadata("VDYNAMICFILTERSSELECTOR1.CLICK","{handler:'E202S2',iparms:[{av:'cmbavDynamicfiltersselector1'},{av:'AV15DynamicFiltersSelector1',fld:'vDYNAMICFILTERSSELECTOR1',pic:''}]");
         setEventMetadata("VDYNAMICFILTERSSELECTOR1.CLICK",",oparms:[{av:'edtavSgnotificaciontitulo1_Visible',ctrl:'vSGNOTIFICACIONTITULO1',prop:'Visible'},{av:'cmbavDynamicfiltersoperator1'}]}");
         setEventMetadata("'ADDDYNAMICFILTERS2'","{handler:'E212S2',iparms:[]");
         setEventMetadata("'ADDDYNAMICFILTERS2'",",oparms:[{av:'AV22DynamicFiltersEnabled3',fld:'vDYNAMICFILTERSENABLED3',pic:''},{av:'imgAdddynamicfilters2_Visible',ctrl:'ADDDYNAMICFILTERS2',prop:'Visible'},{av:'imgRemovedynamicfilters2_Visible',ctrl:'REMOVEDYNAMICFILTERS2',prop:'Visible'}]}");
         setEventMetadata("'REMOVEDYNAMICFILTERS2'","{handler:'E162S2',iparms:[{av:'GRID_nFirstRecordOnPage'},{av:'GRID_nEOF'},{av:'subGrid_Rows',ctrl:'GRID',prop:'Rows'},{av:'cmbavDynamicfiltersselector1'},{av:'AV15DynamicFiltersSelector1',fld:'vDYNAMICFILTERSSELECTOR1',pic:''},{av:'cmbavDynamicfiltersoperator1'},{av:'AV16DynamicFiltersOperator1',fld:'vDYNAMICFILTERSOPERATOR1',pic:'ZZZ9'},{av:'AV17SGNotificacionTitulo1',fld:'vSGNOTIFICACIONTITULO1',pic:''},{av:'cmbavDynamicfiltersselector2'},{av:'AV19DynamicFiltersSelector2',fld:'vDYNAMICFILTERSSELECTOR2',pic:''},{av:'cmbavDynamicfiltersoperator2'},{av:'AV20DynamicFiltersOperator2',fld:'vDYNAMICFILTERSOPERATOR2',pic:'ZZZ9'},{av:'AV21SGNotificacionTitulo2',fld:'vSGNOTIFICACIONTITULO2',pic:''},{av:'cmbavDynamicfiltersselector3'},{av:'AV23DynamicFiltersSelector3',fld:'vDYNAMICFILTERSSELECTOR3',pic:''},{av:'cmbavDynamicfiltersoperator3'},{av:'AV24DynamicFiltersOperator3',fld:'vDYNAMICFILTERSOPERATOR3',pic:'ZZZ9'},{av:'AV25SGNotificacionTitulo3',fld:'vSGNOTIFICACIONTITULO3',pic:''},{av:'AV60Pgmname',fld:'vPGMNAME',pic:'',hsh:true},{av:'AV18DynamicFiltersEnabled2',fld:'vDYNAMICFILTERSENABLED2',pic:''},{av:'AV22DynamicFiltersEnabled3',fld:'vDYNAMICFILTERSENABLED3',pic:''},{av:'AV31TFSGNotificacionID',fld:'vTFSGNOTIFICACIONID',pic:'ZZZZZZZZZ9'},{av:'AV32TFSGNotificacionID_To',fld:'vTFSGNOTIFICACIONID_TO',pic:'ZZZZZZZZZ9'},{av:'AV33TFSGNotificacionTitulo',fld:'vTFSGNOTIFICACIONTITULO',pic:''},{av:'AV34TFSGNotificacionTitulo_Sel',fld:'vTFSGNOTIFICACIONTITULO_SEL',pic:''},{av:'AV35TFSGNotificacionDescripcion',fld:'vTFSGNOTIFICACIONDESCRIPCION',pic:''},{av:'AV36TFSGNotificacionDescripcion_Sel',fld:'vTFSGNOTIFICACIONDESCRIPCION_SEL',pic:''},{av:'AV37TFSGNotificacionFecha',fld:'vTFSGNOTIFICACIONFECHA',pic:'99/99/99 99:99'},{av:'AV38TFSGNotificacionFecha_To',fld:'vTFSGNOTIFICACIONFECHA_TO',pic:'99/99/99 99:99'},{av:'AV42TFSGNotificacionUsuario',fld:'vTFSGNOTIFICACIONUSUARIO',pic:''},{av:'AV43TFSGNotificacionUsuario_Sel',fld:'vTFSGNOTIFICACIONUSUARIO_SEL',pic:''},{av:'AV44TFSGNotificacionUsuarioDsc',fld:'vTFSGNOTIFICACIONUSUARIODSC',pic:''},{av:'AV45TFSGNotificacionUsuarioDsc_Sel',fld:'vTFSGNOTIFICACIONUSUARIODSC_SEL',pic:''},{av:'AV47TFSGNotificacionIconClass_Sels',fld:'vTFSGNOTIFICACIONICONCLASS_SELS',pic:''},{av:'AV48TFSGNotificacionTUsuario',fld:'vTFSGNOTIFICACIONTUSUARIO',pic:'ZZZ9'},{av:'AV49TFSGNotificacionTUsuario_To',fld:'vTFSGNOTIFICACIONTUSUARIO_TO',pic:'ZZZ9'},{av:'AV13OrderedBy',fld:'vORDEREDBY',pic:'ZZZ9'},{av:'AV14OrderedDsc',fld:'vORDEREDDSC',pic:''},{av:'AV10GridState',fld:'vGRIDSTATE',pic:''},{av:'AV27DynamicFiltersIgnoreFirst',fld:'vDYNAMICFILTERSIGNOREFIRST',pic:''},{av:'AV26DynamicFiltersRemoving',fld:'vDYNAMICFILTERSREMOVING',pic:''}]");
         setEventMetadata("'REMOVEDYNAMICFILTERS2'",",oparms:[{av:'AV26DynamicFiltersRemoving',fld:'vDYNAMICFILTERSREMOVING',pic:''},{av:'AV18DynamicFiltersEnabled2',fld:'vDYNAMICFILTERSENABLED2',pic:''},{av:'AV10GridState',fld:'vGRIDSTATE',pic:''},{av:'cmbavDynamicfiltersselector2'},{av:'AV19DynamicFiltersSelector2',fld:'vDYNAMICFILTERSSELECTOR2',pic:''},{av:'cmbavDynamicfiltersoperator2'},{av:'AV20DynamicFiltersOperator2',fld:'vDYNAMICFILTERSOPERATOR2',pic:'ZZZ9'},{av:'AV21SGNotificacionTitulo2',fld:'vSGNOTIFICACIONTITULO2',pic:''},{av:'AV22DynamicFiltersEnabled3',fld:'vDYNAMICFILTERSENABLED3',pic:''},{av:'cmbavDynamicfiltersselector3'},{av:'AV23DynamicFiltersSelector3',fld:'vDYNAMICFILTERSSELECTOR3',pic:''},{av:'cmbavDynamicfiltersoperator3'},{av:'AV24DynamicFiltersOperator3',fld:'vDYNAMICFILTERSOPERATOR3',pic:'ZZZ9'},{av:'AV25SGNotificacionTitulo3',fld:'vSGNOTIFICACIONTITULO3',pic:''},{av:'imgAdddynamicfilters1_Visible',ctrl:'ADDDYNAMICFILTERS1',prop:'Visible'},{av:'imgRemovedynamicfilters1_Visible',ctrl:'REMOVEDYNAMICFILTERS1',prop:'Visible'},{av:'imgAdddynamicfilters2_Visible',ctrl:'ADDDYNAMICFILTERS2',prop:'Visible'},{av:'imgRemovedynamicfilters2_Visible',ctrl:'REMOVEDYNAMICFILTERS2',prop:'Visible'},{av:'cmbavDynamicfiltersselector1'},{av:'AV15DynamicFiltersSelector1',fld:'vDYNAMICFILTERSSELECTOR1',pic:''},{av:'cmbavDynamicfiltersoperator1'},{av:'AV16DynamicFiltersOperator1',fld:'vDYNAMICFILTERSOPERATOR1',pic:'ZZZ9'},{av:'AV17SGNotificacionTitulo1',fld:'vSGNOTIFICACIONTITULO1',pic:''},{av:'lblJsdynamicfilters_Caption',ctrl:'JSDYNAMICFILTERS',prop:'Caption'},{av:'edtavSgnotificaciontitulo2_Visible',ctrl:'vSGNOTIFICACIONTITULO2',prop:'Visible'},{av:'edtavSgnotificaciontitulo3_Visible',ctrl:'vSGNOTIFICACIONTITULO3',prop:'Visible'},{av:'edtavSgnotificaciontitulo1_Visible',ctrl:'vSGNOTIFICACIONTITULO1',prop:'Visible'},{av:'AV52GridCurrentPage',fld:'vGRIDCURRENTPAGE',pic:'ZZZZZZZZZ9'},{av:'AV53GridPageCount',fld:'vGRIDPAGECOUNT',pic:'ZZZZZZZZZ9'},{av:'AV54GridAppliedFilters',fld:'vGRIDAPPLIEDFILTERS',pic:''}]}");
         setEventMetadata("VDYNAMICFILTERSSELECTOR2.CLICK","{handler:'E222S2',iparms:[{av:'cmbavDynamicfiltersselector2'},{av:'AV19DynamicFiltersSelector2',fld:'vDYNAMICFILTERSSELECTOR2',pic:''}]");
         setEventMetadata("VDYNAMICFILTERSSELECTOR2.CLICK",",oparms:[{av:'edtavSgnotificaciontitulo2_Visible',ctrl:'vSGNOTIFICACIONTITULO2',prop:'Visible'},{av:'cmbavDynamicfiltersoperator2'}]}");
         setEventMetadata("'REMOVEDYNAMICFILTERS3'","{handler:'E172S2',iparms:[{av:'GRID_nFirstRecordOnPage'},{av:'GRID_nEOF'},{av:'subGrid_Rows',ctrl:'GRID',prop:'Rows'},{av:'cmbavDynamicfiltersselector1'},{av:'AV15DynamicFiltersSelector1',fld:'vDYNAMICFILTERSSELECTOR1',pic:''},{av:'cmbavDynamicfiltersoperator1'},{av:'AV16DynamicFiltersOperator1',fld:'vDYNAMICFILTERSOPERATOR1',pic:'ZZZ9'},{av:'AV17SGNotificacionTitulo1',fld:'vSGNOTIFICACIONTITULO1',pic:''},{av:'cmbavDynamicfiltersselector2'},{av:'AV19DynamicFiltersSelector2',fld:'vDYNAMICFILTERSSELECTOR2',pic:''},{av:'cmbavDynamicfiltersoperator2'},{av:'AV20DynamicFiltersOperator2',fld:'vDYNAMICFILTERSOPERATOR2',pic:'ZZZ9'},{av:'AV21SGNotificacionTitulo2',fld:'vSGNOTIFICACIONTITULO2',pic:''},{av:'cmbavDynamicfiltersselector3'},{av:'AV23DynamicFiltersSelector3',fld:'vDYNAMICFILTERSSELECTOR3',pic:''},{av:'cmbavDynamicfiltersoperator3'},{av:'AV24DynamicFiltersOperator3',fld:'vDYNAMICFILTERSOPERATOR3',pic:'ZZZ9'},{av:'AV25SGNotificacionTitulo3',fld:'vSGNOTIFICACIONTITULO3',pic:''},{av:'AV60Pgmname',fld:'vPGMNAME',pic:'',hsh:true},{av:'AV18DynamicFiltersEnabled2',fld:'vDYNAMICFILTERSENABLED2',pic:''},{av:'AV22DynamicFiltersEnabled3',fld:'vDYNAMICFILTERSENABLED3',pic:''},{av:'AV31TFSGNotificacionID',fld:'vTFSGNOTIFICACIONID',pic:'ZZZZZZZZZ9'},{av:'AV32TFSGNotificacionID_To',fld:'vTFSGNOTIFICACIONID_TO',pic:'ZZZZZZZZZ9'},{av:'AV33TFSGNotificacionTitulo',fld:'vTFSGNOTIFICACIONTITULO',pic:''},{av:'AV34TFSGNotificacionTitulo_Sel',fld:'vTFSGNOTIFICACIONTITULO_SEL',pic:''},{av:'AV35TFSGNotificacionDescripcion',fld:'vTFSGNOTIFICACIONDESCRIPCION',pic:''},{av:'AV36TFSGNotificacionDescripcion_Sel',fld:'vTFSGNOTIFICACIONDESCRIPCION_SEL',pic:''},{av:'AV37TFSGNotificacionFecha',fld:'vTFSGNOTIFICACIONFECHA',pic:'99/99/99 99:99'},{av:'AV38TFSGNotificacionFecha_To',fld:'vTFSGNOTIFICACIONFECHA_TO',pic:'99/99/99 99:99'},{av:'AV42TFSGNotificacionUsuario',fld:'vTFSGNOTIFICACIONUSUARIO',pic:''},{av:'AV43TFSGNotificacionUsuario_Sel',fld:'vTFSGNOTIFICACIONUSUARIO_SEL',pic:''},{av:'AV44TFSGNotificacionUsuarioDsc',fld:'vTFSGNOTIFICACIONUSUARIODSC',pic:''},{av:'AV45TFSGNotificacionUsuarioDsc_Sel',fld:'vTFSGNOTIFICACIONUSUARIODSC_SEL',pic:''},{av:'AV47TFSGNotificacionIconClass_Sels',fld:'vTFSGNOTIFICACIONICONCLASS_SELS',pic:''},{av:'AV48TFSGNotificacionTUsuario',fld:'vTFSGNOTIFICACIONTUSUARIO',pic:'ZZZ9'},{av:'AV49TFSGNotificacionTUsuario_To',fld:'vTFSGNOTIFICACIONTUSUARIO_TO',pic:'ZZZ9'},{av:'AV13OrderedBy',fld:'vORDEREDBY',pic:'ZZZ9'},{av:'AV14OrderedDsc',fld:'vORDEREDDSC',pic:''},{av:'AV10GridState',fld:'vGRIDSTATE',pic:''},{av:'AV27DynamicFiltersIgnoreFirst',fld:'vDYNAMICFILTERSIGNOREFIRST',pic:''},{av:'AV26DynamicFiltersRemoving',fld:'vDYNAMICFILTERSREMOVING',pic:''}]");
         setEventMetadata("'REMOVEDYNAMICFILTERS3'",",oparms:[{av:'AV26DynamicFiltersRemoving',fld:'vDYNAMICFILTERSREMOVING',pic:''},{av:'AV22DynamicFiltersEnabled3',fld:'vDYNAMICFILTERSENABLED3',pic:''},{av:'AV10GridState',fld:'vGRIDSTATE',pic:''},{av:'AV18DynamicFiltersEnabled2',fld:'vDYNAMICFILTERSENABLED2',pic:''},{av:'cmbavDynamicfiltersselector2'},{av:'AV19DynamicFiltersSelector2',fld:'vDYNAMICFILTERSSELECTOR2',pic:''},{av:'cmbavDynamicfiltersoperator2'},{av:'AV20DynamicFiltersOperator2',fld:'vDYNAMICFILTERSOPERATOR2',pic:'ZZZ9'},{av:'AV21SGNotificacionTitulo2',fld:'vSGNOTIFICACIONTITULO2',pic:''},{av:'cmbavDynamicfiltersselector3'},{av:'AV23DynamicFiltersSelector3',fld:'vDYNAMICFILTERSSELECTOR3',pic:''},{av:'cmbavDynamicfiltersoperator3'},{av:'AV24DynamicFiltersOperator3',fld:'vDYNAMICFILTERSOPERATOR3',pic:'ZZZ9'},{av:'AV25SGNotificacionTitulo3',fld:'vSGNOTIFICACIONTITULO3',pic:''},{av:'imgAdddynamicfilters1_Visible',ctrl:'ADDDYNAMICFILTERS1',prop:'Visible'},{av:'imgRemovedynamicfilters1_Visible',ctrl:'REMOVEDYNAMICFILTERS1',prop:'Visible'},{av:'imgAdddynamicfilters2_Visible',ctrl:'ADDDYNAMICFILTERS2',prop:'Visible'},{av:'imgRemovedynamicfilters2_Visible',ctrl:'REMOVEDYNAMICFILTERS2',prop:'Visible'},{av:'cmbavDynamicfiltersselector1'},{av:'AV15DynamicFiltersSelector1',fld:'vDYNAMICFILTERSSELECTOR1',pic:''},{av:'cmbavDynamicfiltersoperator1'},{av:'AV16DynamicFiltersOperator1',fld:'vDYNAMICFILTERSOPERATOR1',pic:'ZZZ9'},{av:'AV17SGNotificacionTitulo1',fld:'vSGNOTIFICACIONTITULO1',pic:''},{av:'lblJsdynamicfilters_Caption',ctrl:'JSDYNAMICFILTERS',prop:'Caption'},{av:'edtavSgnotificaciontitulo2_Visible',ctrl:'vSGNOTIFICACIONTITULO2',prop:'Visible'},{av:'edtavSgnotificaciontitulo3_Visible',ctrl:'vSGNOTIFICACIONTITULO3',prop:'Visible'},{av:'edtavSgnotificaciontitulo1_Visible',ctrl:'vSGNOTIFICACIONTITULO1',prop:'Visible'},{av:'AV52GridCurrentPage',fld:'vGRIDCURRENTPAGE',pic:'ZZZZZZZZZ9'},{av:'AV53GridPageCount',fld:'vGRIDPAGECOUNT',pic:'ZZZZZZZZZ9'},{av:'AV54GridAppliedFilters',fld:'vGRIDAPPLIEDFILTERS',pic:''}]}");
         setEventMetadata("VDYNAMICFILTERSSELECTOR3.CLICK","{handler:'E232S2',iparms:[{av:'cmbavDynamicfiltersselector3'},{av:'AV23DynamicFiltersSelector3',fld:'vDYNAMICFILTERSSELECTOR3',pic:''}]");
         setEventMetadata("VDYNAMICFILTERSSELECTOR3.CLICK",",oparms:[{av:'edtavSgnotificaciontitulo3_Visible',ctrl:'vSGNOTIFICACIONTITULO3',prop:'Visible'},{av:'cmbavDynamicfiltersoperator3'}]}");
         setEventMetadata("VGRIDACTIONS.CLICK","{handler:'E272S2',iparms:[{av:'cmbavGridactions'},{av:'AV55GridActions',fld:'vGRIDACTIONS',pic:'ZZZ9'},{av:'A2237SGNotificacionID',fld:'SGNOTIFICACIONID',pic:'ZZZZZZZZZ9',hsh:true}]");
         setEventMetadata("VGRIDACTIONS.CLICK",",oparms:[{av:'cmbavGridactions'},{av:'AV55GridActions',fld:'vGRIDACTIONS',pic:'ZZZ9'}]}");
         setEventMetadata("'DOINSERT'","{handler:'E182S2',iparms:[{av:'A2237SGNotificacionID',fld:'SGNOTIFICACIONID',pic:'ZZZZZZZZZ9',hsh:true}]");
         setEventMetadata("'DOINSERT'",",oparms:[]}");
         setEventMetadata("DDO_AGEXPORT.ONOPTIONCLICKED","{handler:'E132S2',iparms:[{av:'Ddo_agexport_Activeeventkey',ctrl:'DDO_AGEXPORT',prop:'ActiveEventKey'},{av:'AV60Pgmname',fld:'vPGMNAME',pic:'',hsh:true},{av:'AV34TFSGNotificacionTitulo_Sel',fld:'vTFSGNOTIFICACIONTITULO_SEL',pic:''},{av:'AV36TFSGNotificacionDescripcion_Sel',fld:'vTFSGNOTIFICACIONDESCRIPCION_SEL',pic:''},{av:'AV43TFSGNotificacionUsuario_Sel',fld:'vTFSGNOTIFICACIONUSUARIO_SEL',pic:''},{av:'AV45TFSGNotificacionUsuarioDsc_Sel',fld:'vTFSGNOTIFICACIONUSUARIODSC_SEL',pic:''},{av:'AV47TFSGNotificacionIconClass_Sels',fld:'vTFSGNOTIFICACIONICONCLASS_SELS',pic:''},{av:'AV46TFSGNotificacionIconClass_SelsJson',fld:'vTFSGNOTIFICACIONICONCLASS_SELSJSON',pic:''},{av:'AV31TFSGNotificacionID',fld:'vTFSGNOTIFICACIONID',pic:'ZZZZZZZZZ9'},{av:'AV33TFSGNotificacionTitulo',fld:'vTFSGNOTIFICACIONTITULO',pic:''},{av:'AV35TFSGNotificacionDescripcion',fld:'vTFSGNOTIFICACIONDESCRIPCION',pic:''},{av:'AV37TFSGNotificacionFecha',fld:'vTFSGNOTIFICACIONFECHA',pic:'99/99/99 99:99'},{av:'AV39DDO_SGNotificacionFechaAuxDate',fld:'vDDO_SGNOTIFICACIONFECHAAUXDATE',pic:''},{av:'AV42TFSGNotificacionUsuario',fld:'vTFSGNOTIFICACIONUSUARIO',pic:''},{av:'AV44TFSGNotificacionUsuarioDsc',fld:'vTFSGNOTIFICACIONUSUARIODSC',pic:''},{av:'AV48TFSGNotificacionTUsuario',fld:'vTFSGNOTIFICACIONTUSUARIO',pic:'ZZZ9'},{av:'AV32TFSGNotificacionID_To',fld:'vTFSGNOTIFICACIONID_TO',pic:'ZZZZZZZZZ9'},{av:'AV38TFSGNotificacionFecha_To',fld:'vTFSGNOTIFICACIONFECHA_TO',pic:'99/99/99 99:99'},{av:'AV40DDO_SGNotificacionFechaAuxDateTo',fld:'vDDO_SGNOTIFICACIONFECHAAUXDATETO',pic:''},{av:'AV49TFSGNotificacionTUsuario_To',fld:'vTFSGNOTIFICACIONTUSUARIO_TO',pic:'ZZZ9'},{av:'AV13OrderedBy',fld:'vORDEREDBY',pic:'ZZZ9'},{av:'AV14OrderedDsc',fld:'vORDEREDDSC',pic:''},{av:'AV10GridState',fld:'vGRIDSTATE',pic:''},{av:'AV26DynamicFiltersRemoving',fld:'vDYNAMICFILTERSREMOVING',pic:''},{av:'cmbavDynamicfiltersselector1'},{av:'AV15DynamicFiltersSelector1',fld:'vDYNAMICFILTERSSELECTOR1',pic:''},{av:'cmbavDynamicfiltersselector2'},{av:'AV19DynamicFiltersSelector2',fld:'vDYNAMICFILTERSSELECTOR2',pic:''},{av:'cmbavDynamicfiltersselector3'},{av:'AV23DynamicFiltersSelector3',fld:'vDYNAMICFILTERSSELECTOR3',pic:''}]");
         setEventMetadata("DDO_AGEXPORT.ONOPTIONCLICKED",",oparms:[{av:'Innewwindow1_Target',ctrl:'INNEWWINDOW1',prop:'Target'},{av:'Innewwindow1_Height',ctrl:'INNEWWINDOW1',prop:'Height'},{av:'Innewwindow1_Width',ctrl:'INNEWWINDOW1',prop:'Width'},{av:'AV10GridState',fld:'vGRIDSTATE',pic:''},{av:'AV13OrderedBy',fld:'vORDEREDBY',pic:'ZZZ9'},{av:'AV14OrderedDsc',fld:'vORDEREDDSC',pic:''},{av:'AV48TFSGNotificacionTUsuario',fld:'vTFSGNOTIFICACIONTUSUARIO',pic:'ZZZ9'},{av:'AV49TFSGNotificacionTUsuario_To',fld:'vTFSGNOTIFICACIONTUSUARIO_TO',pic:'ZZZ9'},{av:'AV46TFSGNotificacionIconClass_SelsJson',fld:'vTFSGNOTIFICACIONICONCLASS_SELSJSON',pic:''},{av:'AV47TFSGNotificacionIconClass_Sels',fld:'vTFSGNOTIFICACIONICONCLASS_SELS',pic:''},{av:'AV45TFSGNotificacionUsuarioDsc_Sel',fld:'vTFSGNOTIFICACIONUSUARIODSC_SEL',pic:''},{av:'AV44TFSGNotificacionUsuarioDsc',fld:'vTFSGNOTIFICACIONUSUARIODSC',pic:''},{av:'AV43TFSGNotificacionUsuario_Sel',fld:'vTFSGNOTIFICACIONUSUARIO_SEL',pic:''},{av:'AV42TFSGNotificacionUsuario',fld:'vTFSGNOTIFICACIONUSUARIO',pic:''},{av:'AV37TFSGNotificacionFecha',fld:'vTFSGNOTIFICACIONFECHA',pic:'99/99/99 99:99'},{av:'AV38TFSGNotificacionFecha_To',fld:'vTFSGNOTIFICACIONFECHA_TO',pic:'99/99/99 99:99'},{av:'AV39DDO_SGNotificacionFechaAuxDate',fld:'vDDO_SGNOTIFICACIONFECHAAUXDATE',pic:''},{av:'AV40DDO_SGNotificacionFechaAuxDateTo',fld:'vDDO_SGNOTIFICACIONFECHAAUXDATETO',pic:''},{av:'AV36TFSGNotificacionDescripcion_Sel',fld:'vTFSGNOTIFICACIONDESCRIPCION_SEL',pic:''},{av:'AV35TFSGNotificacionDescripcion',fld:'vTFSGNOTIFICACIONDESCRIPCION',pic:''},{av:'AV34TFSGNotificacionTitulo_Sel',fld:'vTFSGNOTIFICACIONTITULO_SEL',pic:''},{av:'AV33TFSGNotificacionTitulo',fld:'vTFSGNOTIFICACIONTITULO',pic:''},{av:'AV31TFSGNotificacionID',fld:'vTFSGNOTIFICACIONID',pic:'ZZZZZZZZZ9'},{av:'AV32TFSGNotificacionID_To',fld:'vTFSGNOTIFICACIONID_TO',pic:'ZZZZZZZZZ9'},{av:'Ddo_grid_Selectedvalue_set',ctrl:'DDO_GRID',prop:'SelectedValue_set'},{av:'Ddo_grid_Filteredtext_set',ctrl:'DDO_GRID',prop:'FilteredText_set'},{av:'Ddo_grid_Filteredtextto_set',ctrl:'DDO_GRID',prop:'FilteredTextTo_set'},{av:'subGrid_Rows',ctrl:'GRID',prop:'Rows'},{av:'GRID_nFirstRecordOnPage'},{av:'GRID_nEOF'},{av:'cmbavDynamicfiltersselector1'},{av:'AV15DynamicFiltersSelector1',fld:'vDYNAMICFILTERSSELECTOR1',pic:''},{av:'cmbavDynamicfiltersoperator1'},{av:'AV16DynamicFiltersOperator1',fld:'vDYNAMICFILTERSOPERATOR1',pic:'ZZZ9'},{av:'AV17SGNotificacionTitulo1',fld:'vSGNOTIFICACIONTITULO1',pic:''},{av:'cmbavDynamicfiltersselector2'},{av:'AV19DynamicFiltersSelector2',fld:'vDYNAMICFILTERSSELECTOR2',pic:''},{av:'cmbavDynamicfiltersoperator2'},{av:'AV20DynamicFiltersOperator2',fld:'vDYNAMICFILTERSOPERATOR2',pic:'ZZZ9'},{av:'AV21SGNotificacionTitulo2',fld:'vSGNOTIFICACIONTITULO2',pic:''},{av:'cmbavDynamicfiltersselector3'},{av:'AV23DynamicFiltersSelector3',fld:'vDYNAMICFILTERSSELECTOR3',pic:''},{av:'cmbavDynamicfiltersoperator3'},{av:'AV24DynamicFiltersOperator3',fld:'vDYNAMICFILTERSOPERATOR3',pic:'ZZZ9'},{av:'AV25SGNotificacionTitulo3',fld:'vSGNOTIFICACIONTITULO3',pic:''},{av:'AV60Pgmname',fld:'vPGMNAME',pic:'',hsh:true},{av:'AV18DynamicFiltersEnabled2',fld:'vDYNAMICFILTERSENABLED2',pic:''},{av:'AV22DynamicFiltersEnabled3',fld:'vDYNAMICFILTERSENABLED3',pic:''},{av:'AV27DynamicFiltersIgnoreFirst',fld:'vDYNAMICFILTERSIGNOREFIRST',pic:''},{av:'AV26DynamicFiltersRemoving',fld:'vDYNAMICFILTERSREMOVING',pic:''},{av:'Ddo_grid_Sortedstatus',ctrl:'DDO_GRID',prop:'SortedStatus'},{av:'imgAdddynamicfilters1_Visible',ctrl:'ADDDYNAMICFILTERS1',prop:'Visible'},{av:'imgRemovedynamicfilters1_Visible',ctrl:'REMOVEDYNAMICFILTERS1',prop:'Visible'},{av:'imgAdddynamicfilters2_Visible',ctrl:'ADDDYNAMICFILTERS2',prop:'Visible'},{av:'imgRemovedynamicfilters2_Visible',ctrl:'REMOVEDYNAMICFILTERS2',prop:'Visible'},{av:'lblJsdynamicfilters_Caption',ctrl:'JSDYNAMICFILTERS',prop:'Caption'},{av:'edtavSgnotificaciontitulo1_Visible',ctrl:'vSGNOTIFICACIONTITULO1',prop:'Visible'},{av:'edtavSgnotificaciontitulo2_Visible',ctrl:'vSGNOTIFICACIONTITULO2',prop:'Visible'},{av:'edtavSgnotificaciontitulo3_Visible',ctrl:'vSGNOTIFICACIONTITULO3',prop:'Visible'}]}");
         setEventMetadata("VALID_SGNOTIFICACIONUSUARIO","{handler:'Valid_Sgnotificacionusuario',iparms:[]");
         setEventMetadata("VALID_SGNOTIFICACIONUSUARIO",",oparms:[]}");
         setEventMetadata("NULL","{handler:'Valid_Sgnotificaciontusuario',iparms:[]");
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
         AV17SGNotificacionTitulo1 = "";
         AV19DynamicFiltersSelector2 = "";
         AV21SGNotificacionTitulo2 = "";
         AV23DynamicFiltersSelector3 = "";
         AV25SGNotificacionTitulo3 = "";
         AV60Pgmname = "";
         AV33TFSGNotificacionTitulo = "";
         AV34TFSGNotificacionTitulo_Sel = "";
         AV35TFSGNotificacionDescripcion = "";
         AV36TFSGNotificacionDescripcion_Sel = "";
         AV37TFSGNotificacionFecha = (DateTime)(DateTime.MinValue);
         AV38TFSGNotificacionFecha_To = (DateTime)(DateTime.MinValue);
         AV42TFSGNotificacionUsuario = "";
         AV43TFSGNotificacionUsuario_Sel = "";
         AV44TFSGNotificacionUsuarioDsc = "";
         AV45TFSGNotificacionUsuarioDsc_Sel = "";
         AV47TFSGNotificacionIconClass_Sels = new GxSimpleCollection<string>();
         AV10GridState = new GeneXus.Programs.wwpbaseobjects.SdtWWPGridState(context);
         sDynURL = "";
         FormProcess = "";
         bodyStyle = "";
         GXKey = "";
         AV54GridAppliedFilters = "";
         AV56AGExportData = new GXBaseCollection<GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTDropDownOptionsData_Item>( context, "Item", "");
         AV50DDO_TitleSettingsIcons = new GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTDropDownOptionsTitleSettingsIcons(context);
         AV40DDO_SGNotificacionFechaAuxDateTo = DateTime.MinValue;
         AV46TFSGNotificacionIconClass_SelsJson = "";
         AV39DDO_SGNotificacionFechaAuxDate = DateTime.MinValue;
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
         A2238SGNotificacionTitulo = "";
         A2239SGNotificacionDescripcion = "";
         A2240SGNotificacionFecha = (DateTime)(DateTime.MinValue);
         A2241SGNotificacionUsuario = "";
         A2242SGNotificacionUsuarioDsc = "";
         A2243SGNotificacionIconClass = "";
         ucGridpaginationbar = new GXUserControl();
         ucDdo_agexport = new GXUserControl();
         lblJsdynamicfilters_Jsonclick = "";
         ucDdo_grid = new GXUserControl();
         ucInnewwindow1 = new GXUserControl();
         ucGrid_empowerer = new GXUserControl();
         AV41DDO_SGNotificacionFechaAuxDateText = "";
         ucTfsgnotificacionfecha_rangepicker = new GXUserControl();
         sEvt = "";
         EvtGridId = "";
         EvtRowId = "";
         sEvtType = "";
         AV84Seguridad_notificacioneswwds_24_tfsgnotificacioniconclass_sels = new GxSimpleCollection<string>();
         scmdbuf = "";
         lV63Seguridad_notificacioneswwds_3_sgnotificaciontitulo1 = "";
         lV67Seguridad_notificacioneswwds_7_sgnotificaciontitulo2 = "";
         lV71Seguridad_notificacioneswwds_11_sgnotificaciontitulo3 = "";
         lV74Seguridad_notificacioneswwds_14_tfsgnotificaciontitulo = "";
         lV76Seguridad_notificacioneswwds_16_tfsgnotificaciondescripcion = "";
         lV80Seguridad_notificacioneswwds_20_tfsgnotificacionusuario = "";
         lV82Seguridad_notificacioneswwds_22_tfsgnotificacionusuariodsc = "";
         AV61Seguridad_notificacioneswwds_1_dynamicfiltersselector1 = "";
         AV63Seguridad_notificacioneswwds_3_sgnotificaciontitulo1 = "";
         AV65Seguridad_notificacioneswwds_5_dynamicfiltersselector2 = "";
         AV67Seguridad_notificacioneswwds_7_sgnotificaciontitulo2 = "";
         AV69Seguridad_notificacioneswwds_9_dynamicfiltersselector3 = "";
         AV71Seguridad_notificacioneswwds_11_sgnotificaciontitulo3 = "";
         AV75Seguridad_notificacioneswwds_15_tfsgnotificaciontitulo_sel = "";
         AV74Seguridad_notificacioneswwds_14_tfsgnotificaciontitulo = "";
         AV77Seguridad_notificacioneswwds_17_tfsgnotificaciondescripcion_sel = "";
         AV76Seguridad_notificacioneswwds_16_tfsgnotificaciondescripcion = "";
         AV78Seguridad_notificacioneswwds_18_tfsgnotificacionfecha = (DateTime)(DateTime.MinValue);
         AV79Seguridad_notificacioneswwds_19_tfsgnotificacionfecha_to = (DateTime)(DateTime.MinValue);
         AV81Seguridad_notificacioneswwds_21_tfsgnotificacionusuario_sel = "";
         AV80Seguridad_notificacioneswwds_20_tfsgnotificacionusuario = "";
         AV83Seguridad_notificacioneswwds_23_tfsgnotificacionusuariodsc_sel = "";
         AV82Seguridad_notificacioneswwds_22_tfsgnotificacionusuariodsc = "";
         H002S2_A2244SGNotificacionTUsuario = new short[1] ;
         H002S2_A2243SGNotificacionIconClass = new string[] {""} ;
         H002S2_A2242SGNotificacionUsuarioDsc = new string[] {""} ;
         H002S2_A2241SGNotificacionUsuario = new string[] {""} ;
         H002S2_A2240SGNotificacionFecha = new DateTime[] {DateTime.MinValue} ;
         H002S2_A2239SGNotificacionDescripcion = new string[] {""} ;
         H002S2_A2238SGNotificacionTitulo = new string[] {""} ;
         H002S2_A2237SGNotificacionID = new long[1] ;
         H002S3_AGRID_nRecordCount = new long[1] ;
         imgAdddynamicfilters1_Jsonclick = "";
         imgRemovedynamicfilters1_Jsonclick = "";
         imgAdddynamicfilters2_Jsonclick = "";
         imgRemovedynamicfilters2_Jsonclick = "";
         imgRemovedynamicfilters3_Jsonclick = "";
         AV57AGExportDataItem = new GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTDropDownOptionsData_Item(context);
         GXt_SdtDVB_SDTDropDownOptionsTitleSettingsIcons1 = new GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTDropDownOptionsTitleSettingsIcons(context);
         AV6WWPContext = new GeneXus.Programs.wwpbaseobjects.SdtWWPContext(context);
         GXEncryptionTmp = "";
         GridRow = new GXWebRow();
         AV30Session = context.GetSession();
         AV11GridStateFilterValue = new GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue(context);
         GXt_char2 = "";
         GXt_char6 = "";
         GXt_char5 = "";
         GXt_char4 = "";
         GXt_char3 = "";
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
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.seguridad.notificacionesww__default(),
            new Object[][] {
                new Object[] {
               H002S2_A2244SGNotificacionTUsuario, H002S2_A2243SGNotificacionIconClass, H002S2_A2242SGNotificacionUsuarioDsc, H002S2_A2241SGNotificacionUsuario, H002S2_A2240SGNotificacionFecha, H002S2_A2239SGNotificacionDescripcion, H002S2_A2238SGNotificacionTitulo, H002S2_A2237SGNotificacionID
               }
               , new Object[] {
               H002S3_AGRID_nRecordCount
               }
            }
         );
         AV60Pgmname = "Seguridad.NotificacionesWW";
         /* GeneXus formulas. */
         AV60Pgmname = "Seguridad.NotificacionesWW";
         context.Gx_err = 0;
      }

      private short GRID_nEOF ;
      private short nGotPars ;
      private short GxWebError ;
      private short AV16DynamicFiltersOperator1 ;
      private short AV20DynamicFiltersOperator2 ;
      private short AV24DynamicFiltersOperator3 ;
      private short AV48TFSGNotificacionTUsuario ;
      private short AV49TFSGNotificacionTUsuario_To ;
      private short AV13OrderedBy ;
      private short initialized ;
      private short gxajaxcallmode ;
      private short wbEnd ;
      private short wbStart ;
      private short subGrid_Backcolorstyle ;
      private short subGrid_Titlebackstyle ;
      private short subGrid_Sortable ;
      private short AV55GridActions ;
      private short A2244SGNotificacionTUsuario ;
      private short subGrid_Allowselection ;
      private short subGrid_Allowhovering ;
      private short subGrid_Allowcollapsing ;
      private short subGrid_Collapsed ;
      private short nDonePA ;
      private short AV62Seguridad_notificacioneswwds_2_dynamicfiltersoperator1 ;
      private short AV66Seguridad_notificacioneswwds_6_dynamicfiltersoperator2 ;
      private short AV70Seguridad_notificacioneswwds_10_dynamicfiltersoperator3 ;
      private short AV85Seguridad_notificacioneswwds_25_tfsgnotificaciontusuario ;
      private short AV86Seguridad_notificacioneswwds_26_tfsgnotificaciontusuario_to ;
      private short nGXWrapped ;
      private short subGrid_Backstyle ;
      private int subGrid_Rows ;
      private int Gridpaginationbar_Rowsperpageselectedvalue ;
      private int nRC_GXsfl_101 ;
      private int nGXsfl_101_idx=1 ;
      private int Gridpaginationbar_Pagestoshow ;
      private int subGrid_Titlebackcolor ;
      private int subGrid_Allbackcolor ;
      private int subGrid_Selectedindex ;
      private int subGrid_Selectioncolor ;
      private int subGrid_Hoveringcolor ;
      private int subGrid_Islastpage ;
      private int GXPagingFrom2 ;
      private int GXPagingTo2 ;
      private int AV84Seguridad_notificacioneswwds_24_tfsgnotificacioniconclass_sels_Count ;
      private int AV51PageToGo ;
      private int imgAdddynamicfilters1_Visible ;
      private int imgRemovedynamicfilters1_Visible ;
      private int imgAdddynamicfilters2_Visible ;
      private int imgRemovedynamicfilters2_Visible ;
      private int edtavSgnotificaciontitulo1_Visible ;
      private int edtavSgnotificaciontitulo2_Visible ;
      private int edtavSgnotificaciontitulo3_Visible ;
      private int AV87GXV1 ;
      private int edtavSgnotificaciontitulo3_Enabled ;
      private int edtavSgnotificaciontitulo2_Enabled ;
      private int edtavSgnotificaciontitulo1_Enabled ;
      private int idxLst ;
      private int subGrid_Backcolor ;
      private long GRID_nFirstRecordOnPage ;
      private long AV31TFSGNotificacionID ;
      private long AV32TFSGNotificacionID_To ;
      private long AV52GridCurrentPage ;
      private long AV53GridPageCount ;
      private long A2237SGNotificacionID ;
      private long GRID_nCurrentRecord ;
      private long AV72Seguridad_notificacioneswwds_12_tfsgnotificacionid ;
      private long AV73Seguridad_notificacioneswwds_13_tfsgnotificacionid_to ;
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
      private string sGXsfl_101_idx="0001" ;
      private string AV60Pgmname ;
      private string AV42TFSGNotificacionUsuario ;
      private string AV43TFSGNotificacionUsuario_Sel ;
      private string AV44TFSGNotificacionUsuarioDsc ;
      private string AV45TFSGNotificacionUsuarioDsc_Sel ;
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
      private string edtSGNotificacionTitulo_Link ;
      private string A2241SGNotificacionUsuario ;
      private string edtSGNotificacionUsuario_Link ;
      private string A2242SGNotificacionUsuarioDsc ;
      private string edtSGNotificacionUsuarioDsc_Link ;
      private string Gridpaginationbar_Internalname ;
      private string divHtml_bottomauxiliarcontrols_Internalname ;
      private string Ddo_agexport_Internalname ;
      private string lblJsdynamicfilters_Internalname ;
      private string lblJsdynamicfilters_Caption ;
      private string lblJsdynamicfilters_Jsonclick ;
      private string Ddo_grid_Internalname ;
      private string Innewwindow1_Internalname ;
      private string Grid_empowerer_Internalname ;
      private string divDdo_sgnotificacionfechaauxdates_Internalname ;
      private string edtavDdo_sgnotificacionfechaauxdatetext_Internalname ;
      private string edtavDdo_sgnotificacionfechaauxdatetext_Jsonclick ;
      private string Tfsgnotificacionfecha_rangepicker_Internalname ;
      private string sEvt ;
      private string EvtGridId ;
      private string EvtRowId ;
      private string sEvtType ;
      private string cmbavGridactions_Internalname ;
      private string edtSGNotificacionID_Internalname ;
      private string edtSGNotificacionTitulo_Internalname ;
      private string edtSGNotificacionDescripcion_Internalname ;
      private string edtSGNotificacionFecha_Internalname ;
      private string edtSGNotificacionUsuario_Internalname ;
      private string edtSGNotificacionUsuarioDsc_Internalname ;
      private string cmbSGNotificacionIconClass_Internalname ;
      private string edtSGNotificacionTUsuario_Internalname ;
      private string cmbavDynamicfiltersselector1_Internalname ;
      private string cmbavDynamicfiltersoperator1_Internalname ;
      private string cmbavDynamicfiltersselector2_Internalname ;
      private string cmbavDynamicfiltersoperator2_Internalname ;
      private string cmbavDynamicfiltersselector3_Internalname ;
      private string cmbavDynamicfiltersoperator3_Internalname ;
      private string scmdbuf ;
      private string lV80Seguridad_notificacioneswwds_20_tfsgnotificacionusuario ;
      private string lV82Seguridad_notificacioneswwds_22_tfsgnotificacionusuariodsc ;
      private string AV81Seguridad_notificacioneswwds_21_tfsgnotificacionusuario_sel ;
      private string AV80Seguridad_notificacioneswwds_20_tfsgnotificacionusuario ;
      private string AV83Seguridad_notificacioneswwds_23_tfsgnotificacionusuariodsc_sel ;
      private string AV82Seguridad_notificacioneswwds_22_tfsgnotificacionusuariodsc ;
      private string edtavSgnotificaciontitulo1_Internalname ;
      private string edtavSgnotificaciontitulo2_Internalname ;
      private string edtavSgnotificaciontitulo3_Internalname ;
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
      private string GXt_char6 ;
      private string GXt_char5 ;
      private string GXt_char4 ;
      private string GXt_char3 ;
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
      private string cellFilter_sgnotificaciontitulo3_cell_Internalname ;
      private string edtavSgnotificaciontitulo3_Jsonclick ;
      private string cellDynamicfilters_removefilter3_cell_Internalname ;
      private string sImgUrl ;
      private string tblTablemergeddynamicfilters2_Internalname ;
      private string cmbavDynamicfiltersoperator2_Jsonclick ;
      private string cellFilter_sgnotificaciontitulo2_cell_Internalname ;
      private string edtavSgnotificaciontitulo2_Jsonclick ;
      private string cellDynamicfilters_addfilter2_cell_Internalname ;
      private string cellDynamicfilters_removefilter2_cell_Internalname ;
      private string tblTablemergeddynamicfilters1_Internalname ;
      private string cmbavDynamicfiltersoperator1_Jsonclick ;
      private string cellFilter_sgnotificaciontitulo1_cell_Internalname ;
      private string edtavSgnotificaciontitulo1_Jsonclick ;
      private string cellDynamicfilters_addfilter1_cell_Internalname ;
      private string cellDynamicfilters_removefilter1_cell_Internalname ;
      private string sGXsfl_101_fel_idx="0001" ;
      private string GXCCtl ;
      private string cmbavGridactions_Jsonclick ;
      private string ROClassString ;
      private string edtSGNotificacionID_Jsonclick ;
      private string edtSGNotificacionTitulo_Jsonclick ;
      private string edtSGNotificacionDescripcion_Jsonclick ;
      private string edtSGNotificacionFecha_Jsonclick ;
      private string edtSGNotificacionUsuario_Jsonclick ;
      private string edtSGNotificacionUsuarioDsc_Jsonclick ;
      private string cmbSGNotificacionIconClass_Jsonclick ;
      private string edtSGNotificacionTUsuario_Jsonclick ;
      private DateTime AV37TFSGNotificacionFecha ;
      private DateTime AV38TFSGNotificacionFecha_To ;
      private DateTime A2240SGNotificacionFecha ;
      private DateTime AV78Seguridad_notificacioneswwds_18_tfsgnotificacionfecha ;
      private DateTime AV79Seguridad_notificacioneswwds_19_tfsgnotificacionfecha_to ;
      private DateTime AV40DDO_SGNotificacionFechaAuxDateTo ;
      private DateTime AV39DDO_SGNotificacionFechaAuxDate ;
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
      private bool bGXsfl_101_Refreshing=false ;
      private bool gxdyncontrolsrefreshing ;
      private bool AV64Seguridad_notificacioneswwds_4_dynamicfiltersenabled2 ;
      private bool AV68Seguridad_notificacioneswwds_8_dynamicfiltersenabled3 ;
      private bool returnInSub ;
      private bool gx_refresh_fired ;
      private string AV46TFSGNotificacionIconClass_SelsJson ;
      private string AV15DynamicFiltersSelector1 ;
      private string AV17SGNotificacionTitulo1 ;
      private string AV19DynamicFiltersSelector2 ;
      private string AV21SGNotificacionTitulo2 ;
      private string AV23DynamicFiltersSelector3 ;
      private string AV25SGNotificacionTitulo3 ;
      private string AV33TFSGNotificacionTitulo ;
      private string AV34TFSGNotificacionTitulo_Sel ;
      private string AV35TFSGNotificacionDescripcion ;
      private string AV36TFSGNotificacionDescripcion_Sel ;
      private string AV54GridAppliedFilters ;
      private string A2238SGNotificacionTitulo ;
      private string A2239SGNotificacionDescripcion ;
      private string A2243SGNotificacionIconClass ;
      private string AV41DDO_SGNotificacionFechaAuxDateText ;
      private string lV63Seguridad_notificacioneswwds_3_sgnotificaciontitulo1 ;
      private string lV67Seguridad_notificacioneswwds_7_sgnotificaciontitulo2 ;
      private string lV71Seguridad_notificacioneswwds_11_sgnotificaciontitulo3 ;
      private string lV74Seguridad_notificacioneswwds_14_tfsgnotificaciontitulo ;
      private string lV76Seguridad_notificacioneswwds_16_tfsgnotificaciondescripcion ;
      private string AV61Seguridad_notificacioneswwds_1_dynamicfiltersselector1 ;
      private string AV63Seguridad_notificacioneswwds_3_sgnotificaciontitulo1 ;
      private string AV65Seguridad_notificacioneswwds_5_dynamicfiltersselector2 ;
      private string AV67Seguridad_notificacioneswwds_7_sgnotificaciontitulo2 ;
      private string AV69Seguridad_notificacioneswwds_9_dynamicfiltersselector3 ;
      private string AV71Seguridad_notificacioneswwds_11_sgnotificaciontitulo3 ;
      private string AV75Seguridad_notificacioneswwds_15_tfsgnotificaciontitulo_sel ;
      private string AV74Seguridad_notificacioneswwds_14_tfsgnotificaciontitulo ;
      private string AV77Seguridad_notificacioneswwds_17_tfsgnotificaciondescripcion_sel ;
      private string AV76Seguridad_notificacioneswwds_16_tfsgnotificaciondescripcion ;
      private string AV28ExcelFilename ;
      private string AV29ErrorMessage ;
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
      private GXUserControl ucTfsgnotificacionfecha_rangepicker ;
      private IGxDataStore dsDataStore2 ;
      private IGxDataStore dsDefault ;
      private GXCombobox cmbavDynamicfiltersselector1 ;
      private GXCombobox cmbavDynamicfiltersoperator1 ;
      private GXCombobox cmbavDynamicfiltersselector2 ;
      private GXCombobox cmbavDynamicfiltersoperator2 ;
      private GXCombobox cmbavDynamicfiltersselector3 ;
      private GXCombobox cmbavDynamicfiltersoperator3 ;
      private GXCombobox cmbavGridactions ;
      private GXCombobox cmbSGNotificacionIconClass ;
      private IDataStoreProvider pr_default ;
      private short[] H002S2_A2244SGNotificacionTUsuario ;
      private string[] H002S2_A2243SGNotificacionIconClass ;
      private string[] H002S2_A2242SGNotificacionUsuarioDsc ;
      private string[] H002S2_A2241SGNotificacionUsuario ;
      private DateTime[] H002S2_A2240SGNotificacionFecha ;
      private string[] H002S2_A2239SGNotificacionDescripcion ;
      private string[] H002S2_A2238SGNotificacionTitulo ;
      private long[] H002S2_A2237SGNotificacionID ;
      private long[] H002S3_AGRID_nRecordCount ;
      private msglist BackMsgLst ;
      private msglist LclMsgLst ;
      private GxHttpRequest AV7HTTPRequest ;
      private GxSimpleCollection<string> AV47TFSGNotificacionIconClass_Sels ;
      private GxSimpleCollection<string> AV84Seguridad_notificacioneswwds_24_tfsgnotificacioniconclass_sels ;
      private GXBaseCollection<GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTDropDownOptionsData_Item> AV56AGExportData ;
      private GXWebForm Form ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPContext AV6WWPContext ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPTransactionContext AV8TrnContext ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPGridState AV10GridState ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue AV11GridStateFilterValue ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter AV12GridStateDynamicFilter ;
      private GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTDropDownOptionsTitleSettingsIcons AV50DDO_TitleSettingsIcons ;
      private GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTDropDownOptionsTitleSettingsIcons GXt_SdtDVB_SDTDropDownOptionsTitleSettingsIcons1 ;
      private GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTDropDownOptionsData_Item AV57AGExportDataItem ;
   }

   public class notificacionesww__default : DataStoreHelperBase, IDataStoreHelper
   {
      protected Object[] conditional_H002S2( IGxContext context ,
                                             string A2243SGNotificacionIconClass ,
                                             GxSimpleCollection<string> AV84Seguridad_notificacioneswwds_24_tfsgnotificacioniconclass_sels ,
                                             string AV61Seguridad_notificacioneswwds_1_dynamicfiltersselector1 ,
                                             short AV62Seguridad_notificacioneswwds_2_dynamicfiltersoperator1 ,
                                             string AV63Seguridad_notificacioneswwds_3_sgnotificaciontitulo1 ,
                                             bool AV64Seguridad_notificacioneswwds_4_dynamicfiltersenabled2 ,
                                             string AV65Seguridad_notificacioneswwds_5_dynamicfiltersselector2 ,
                                             short AV66Seguridad_notificacioneswwds_6_dynamicfiltersoperator2 ,
                                             string AV67Seguridad_notificacioneswwds_7_sgnotificaciontitulo2 ,
                                             bool AV68Seguridad_notificacioneswwds_8_dynamicfiltersenabled3 ,
                                             string AV69Seguridad_notificacioneswwds_9_dynamicfiltersselector3 ,
                                             short AV70Seguridad_notificacioneswwds_10_dynamicfiltersoperator3 ,
                                             string AV71Seguridad_notificacioneswwds_11_sgnotificaciontitulo3 ,
                                             long AV72Seguridad_notificacioneswwds_12_tfsgnotificacionid ,
                                             long AV73Seguridad_notificacioneswwds_13_tfsgnotificacionid_to ,
                                             string AV75Seguridad_notificacioneswwds_15_tfsgnotificaciontitulo_sel ,
                                             string AV74Seguridad_notificacioneswwds_14_tfsgnotificaciontitulo ,
                                             string AV77Seguridad_notificacioneswwds_17_tfsgnotificaciondescripcion_sel ,
                                             string AV76Seguridad_notificacioneswwds_16_tfsgnotificaciondescripcion ,
                                             DateTime AV78Seguridad_notificacioneswwds_18_tfsgnotificacionfecha ,
                                             DateTime AV79Seguridad_notificacioneswwds_19_tfsgnotificacionfecha_to ,
                                             string AV81Seguridad_notificacioneswwds_21_tfsgnotificacionusuario_sel ,
                                             string AV80Seguridad_notificacioneswwds_20_tfsgnotificacionusuario ,
                                             string AV83Seguridad_notificacioneswwds_23_tfsgnotificacionusuariodsc_sel ,
                                             string AV82Seguridad_notificacioneswwds_22_tfsgnotificacionusuariodsc ,
                                             int AV84Seguridad_notificacioneswwds_24_tfsgnotificacioniconclass_sels_Count ,
                                             short AV85Seguridad_notificacioneswwds_25_tfsgnotificaciontusuario ,
                                             short AV86Seguridad_notificacioneswwds_26_tfsgnotificaciontusuario_to ,
                                             string A2238SGNotificacionTitulo ,
                                             long A2237SGNotificacionID ,
                                             string A2239SGNotificacionDescripcion ,
                                             DateTime A2240SGNotificacionFecha ,
                                             string A2241SGNotificacionUsuario ,
                                             string A2242SGNotificacionUsuarioDsc ,
                                             short A2244SGNotificacionTUsuario ,
                                             short AV13OrderedBy ,
                                             bool AV14OrderedDsc )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int7 = new short[23];
         Object[] GXv_Object8 = new Object[2];
         string sSelectString;
         string sFromString;
         string sOrderString;
         sSelectString = " T1.[SGNotificacionTUsuario], T1.[SGNotificacionIconClass], T2.[UsuNom] AS SGNotificacionUsuarioDsc, T1.[SGNotificacionUsuario] AS SGNotificacionUsuario, T1.[SGNotificacionFecha], T1.[SGNotificacionDescripcion], T1.[SGNotificacionTitulo], T1.[SGNotificacionID]";
         sFromString = " FROM ([SGNOTIFICACIONES] T1 INNER JOIN [SGUSUARIOS] T2 ON T2.[UsuCod] = T1.[SGNotificacionUsuario])";
         sOrderString = "";
         if ( ( StringUtil.StrCmp(AV61Seguridad_notificacioneswwds_1_dynamicfiltersselector1, "SGNOTIFICACIONTITULO") == 0 ) && ( AV62Seguridad_notificacioneswwds_2_dynamicfiltersoperator1 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV63Seguridad_notificacioneswwds_3_sgnotificaciontitulo1)) ) )
         {
            AddWhere(sWhereString, "(T1.[SGNotificacionTitulo] like @lV63Seguridad_notificacioneswwds_3_sgnotificaciontitulo1)");
         }
         else
         {
            GXv_int7[0] = 1;
         }
         if ( ( StringUtil.StrCmp(AV61Seguridad_notificacioneswwds_1_dynamicfiltersselector1, "SGNOTIFICACIONTITULO") == 0 ) && ( AV62Seguridad_notificacioneswwds_2_dynamicfiltersoperator1 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV63Seguridad_notificacioneswwds_3_sgnotificaciontitulo1)) ) )
         {
            AddWhere(sWhereString, "(T1.[SGNotificacionTitulo] like '%' + @lV63Seguridad_notificacioneswwds_3_sgnotificaciontitulo1)");
         }
         else
         {
            GXv_int7[1] = 1;
         }
         if ( AV64Seguridad_notificacioneswwds_4_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV65Seguridad_notificacioneswwds_5_dynamicfiltersselector2, "SGNOTIFICACIONTITULO") == 0 ) && ( AV66Seguridad_notificacioneswwds_6_dynamicfiltersoperator2 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV67Seguridad_notificacioneswwds_7_sgnotificaciontitulo2)) ) )
         {
            AddWhere(sWhereString, "(T1.[SGNotificacionTitulo] like @lV67Seguridad_notificacioneswwds_7_sgnotificaciontitulo2)");
         }
         else
         {
            GXv_int7[2] = 1;
         }
         if ( AV64Seguridad_notificacioneswwds_4_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV65Seguridad_notificacioneswwds_5_dynamicfiltersselector2, "SGNOTIFICACIONTITULO") == 0 ) && ( AV66Seguridad_notificacioneswwds_6_dynamicfiltersoperator2 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV67Seguridad_notificacioneswwds_7_sgnotificaciontitulo2)) ) )
         {
            AddWhere(sWhereString, "(T1.[SGNotificacionTitulo] like '%' + @lV67Seguridad_notificacioneswwds_7_sgnotificaciontitulo2)");
         }
         else
         {
            GXv_int7[3] = 1;
         }
         if ( AV68Seguridad_notificacioneswwds_8_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV69Seguridad_notificacioneswwds_9_dynamicfiltersselector3, "SGNOTIFICACIONTITULO") == 0 ) && ( AV70Seguridad_notificacioneswwds_10_dynamicfiltersoperator3 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV71Seguridad_notificacioneswwds_11_sgnotificaciontitulo3)) ) )
         {
            AddWhere(sWhereString, "(T1.[SGNotificacionTitulo] like @lV71Seguridad_notificacioneswwds_11_sgnotificaciontitulo3)");
         }
         else
         {
            GXv_int7[4] = 1;
         }
         if ( AV68Seguridad_notificacioneswwds_8_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV69Seguridad_notificacioneswwds_9_dynamicfiltersselector3, "SGNOTIFICACIONTITULO") == 0 ) && ( AV70Seguridad_notificacioneswwds_10_dynamicfiltersoperator3 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV71Seguridad_notificacioneswwds_11_sgnotificaciontitulo3)) ) )
         {
            AddWhere(sWhereString, "(T1.[SGNotificacionTitulo] like '%' + @lV71Seguridad_notificacioneswwds_11_sgnotificaciontitulo3)");
         }
         else
         {
            GXv_int7[5] = 1;
         }
         if ( ! (0==AV72Seguridad_notificacioneswwds_12_tfsgnotificacionid) )
         {
            AddWhere(sWhereString, "(T1.[SGNotificacionID] >= @AV72Seguridad_notificacioneswwds_12_tfsgnotificacionid)");
         }
         else
         {
            GXv_int7[6] = 1;
         }
         if ( ! (0==AV73Seguridad_notificacioneswwds_13_tfsgnotificacionid_to) )
         {
            AddWhere(sWhereString, "(T1.[SGNotificacionID] <= @AV73Seguridad_notificacioneswwds_13_tfsgnotificacionid_to)");
         }
         else
         {
            GXv_int7[7] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV75Seguridad_notificacioneswwds_15_tfsgnotificaciontitulo_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV74Seguridad_notificacioneswwds_14_tfsgnotificaciontitulo)) ) )
         {
            AddWhere(sWhereString, "(T1.[SGNotificacionTitulo] like @lV74Seguridad_notificacioneswwds_14_tfsgnotificaciontitulo)");
         }
         else
         {
            GXv_int7[8] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV75Seguridad_notificacioneswwds_15_tfsgnotificaciontitulo_sel)) )
         {
            AddWhere(sWhereString, "(T1.[SGNotificacionTitulo] = @AV75Seguridad_notificacioneswwds_15_tfsgnotificaciontitulo_sel)");
         }
         else
         {
            GXv_int7[9] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV77Seguridad_notificacioneswwds_17_tfsgnotificaciondescripcion_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV76Seguridad_notificacioneswwds_16_tfsgnotificaciondescripcion)) ) )
         {
            AddWhere(sWhereString, "(T1.[SGNotificacionDescripcion] like @lV76Seguridad_notificacioneswwds_16_tfsgnotificaciondescripcion)");
         }
         else
         {
            GXv_int7[10] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV77Seguridad_notificacioneswwds_17_tfsgnotificaciondescripcion_sel)) )
         {
            AddWhere(sWhereString, "(T1.[SGNotificacionDescripcion] = @AV77Seguridad_notificacioneswwds_17_tfsgnotificaciondescripcion_sel)");
         }
         else
         {
            GXv_int7[11] = 1;
         }
         if ( ! (DateTime.MinValue==AV78Seguridad_notificacioneswwds_18_tfsgnotificacionfecha) )
         {
            AddWhere(sWhereString, "(T1.[SGNotificacionFecha] >= @AV78Seguridad_notificacioneswwds_18_tfsgnotificacionfecha)");
         }
         else
         {
            GXv_int7[12] = 1;
         }
         if ( ! (DateTime.MinValue==AV79Seguridad_notificacioneswwds_19_tfsgnotificacionfecha_to) )
         {
            AddWhere(sWhereString, "(T1.[SGNotificacionFecha] <= @AV79Seguridad_notificacioneswwds_19_tfsgnotificacionfecha_to)");
         }
         else
         {
            GXv_int7[13] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV81Seguridad_notificacioneswwds_21_tfsgnotificacionusuario_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV80Seguridad_notificacioneswwds_20_tfsgnotificacionusuario)) ) )
         {
            AddWhere(sWhereString, "(T1.[SGNotificacionUsuario] like @lV80Seguridad_notificacioneswwds_20_tfsgnotificacionusuario)");
         }
         else
         {
            GXv_int7[14] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV81Seguridad_notificacioneswwds_21_tfsgnotificacionusuario_sel)) )
         {
            AddWhere(sWhereString, "(T1.[SGNotificacionUsuario] = @AV81Seguridad_notificacioneswwds_21_tfsgnotificacionusuario_sel)");
         }
         else
         {
            GXv_int7[15] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV83Seguridad_notificacioneswwds_23_tfsgnotificacionusuariodsc_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV82Seguridad_notificacioneswwds_22_tfsgnotificacionusuariodsc)) ) )
         {
            AddWhere(sWhereString, "(T2.[UsuNom] like @lV82Seguridad_notificacioneswwds_22_tfsgnotificacionusuariodsc)");
         }
         else
         {
            GXv_int7[16] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV83Seguridad_notificacioneswwds_23_tfsgnotificacionusuariodsc_sel)) )
         {
            AddWhere(sWhereString, "(T2.[UsuNom] = @AV83Seguridad_notificacioneswwds_23_tfsgnotificacionusuariodsc_sel)");
         }
         else
         {
            GXv_int7[17] = 1;
         }
         if ( AV84Seguridad_notificacioneswwds_24_tfsgnotificacioniconclass_sels_Count > 0 )
         {
            AddWhere(sWhereString, "("+new GxDbmsUtils( new GxSqlServer()).ValueList(AV84Seguridad_notificacioneswwds_24_tfsgnotificacioniconclass_sels, "T1.[SGNotificacionIconClass] IN (", ")")+")");
         }
         if ( ! (0==AV85Seguridad_notificacioneswwds_25_tfsgnotificaciontusuario) )
         {
            AddWhere(sWhereString, "(T1.[SGNotificacionTUsuario] >= @AV85Seguridad_notificacioneswwds_25_tfsgnotificaciontusuario)");
         }
         else
         {
            GXv_int7[18] = 1;
         }
         if ( ! (0==AV86Seguridad_notificacioneswwds_26_tfsgnotificaciontusuario_to) )
         {
            AddWhere(sWhereString, "(T1.[SGNotificacionTUsuario] <= @AV86Seguridad_notificacioneswwds_26_tfsgnotificaciontusuario_to)");
         }
         else
         {
            GXv_int7[19] = 1;
         }
         if ( ( AV13OrderedBy == 1 ) && ! AV14OrderedDsc )
         {
            sOrderString += " ORDER BY T1.[SGNotificacionTitulo]";
         }
         else if ( ( AV13OrderedBy == 1 ) && ( AV14OrderedDsc ) )
         {
            sOrderString += " ORDER BY T1.[SGNotificacionTitulo] DESC";
         }
         else if ( ( AV13OrderedBy == 2 ) && ! AV14OrderedDsc )
         {
            sOrderString += " ORDER BY T1.[SGNotificacionID]";
         }
         else if ( ( AV13OrderedBy == 2 ) && ( AV14OrderedDsc ) )
         {
            sOrderString += " ORDER BY T1.[SGNotificacionID] DESC";
         }
         else if ( ( AV13OrderedBy == 3 ) && ! AV14OrderedDsc )
         {
            sOrderString += " ORDER BY T1.[SGNotificacionDescripcion]";
         }
         else if ( ( AV13OrderedBy == 3 ) && ( AV14OrderedDsc ) )
         {
            sOrderString += " ORDER BY T1.[SGNotificacionDescripcion] DESC";
         }
         else if ( ( AV13OrderedBy == 4 ) && ! AV14OrderedDsc )
         {
            sOrderString += " ORDER BY T1.[SGNotificacionFecha]";
         }
         else if ( ( AV13OrderedBy == 4 ) && ( AV14OrderedDsc ) )
         {
            sOrderString += " ORDER BY T1.[SGNotificacionFecha] DESC";
         }
         else if ( ( AV13OrderedBy == 5 ) && ! AV14OrderedDsc )
         {
            sOrderString += " ORDER BY T1.[SGNotificacionUsuario]";
         }
         else if ( ( AV13OrderedBy == 5 ) && ( AV14OrderedDsc ) )
         {
            sOrderString += " ORDER BY T1.[SGNotificacionUsuario] DESC";
         }
         else if ( ( AV13OrderedBy == 6 ) && ! AV14OrderedDsc )
         {
            sOrderString += " ORDER BY T2.[UsuNom]";
         }
         else if ( ( AV13OrderedBy == 6 ) && ( AV14OrderedDsc ) )
         {
            sOrderString += " ORDER BY T2.[UsuNom] DESC";
         }
         else if ( ( AV13OrderedBy == 7 ) && ! AV14OrderedDsc )
         {
            sOrderString += " ORDER BY T1.[SGNotificacionIconClass]";
         }
         else if ( ( AV13OrderedBy == 7 ) && ( AV14OrderedDsc ) )
         {
            sOrderString += " ORDER BY T1.[SGNotificacionIconClass] DESC";
         }
         else if ( ( AV13OrderedBy == 8 ) && ! AV14OrderedDsc )
         {
            sOrderString += " ORDER BY T1.[SGNotificacionTUsuario]";
         }
         else if ( ( AV13OrderedBy == 8 ) && ( AV14OrderedDsc ) )
         {
            sOrderString += " ORDER BY T1.[SGNotificacionTUsuario] DESC";
         }
         else if ( true )
         {
            sOrderString += " ORDER BY T1.[SGNotificacionID]";
         }
         scmdbuf = "SELECT " + sSelectString + sFromString + sWhereString + sOrderString + "" + " OFFSET " + "@GXPagingFrom2" + " ROWS FETCH NEXT CAST((SELECT CASE WHEN " + "@GXPagingTo2" + " > 0 THEN " + "@GXPagingTo2" + " ELSE 1e9 END) AS INTEGER) ROWS ONLY";
         GXv_Object8[0] = scmdbuf;
         GXv_Object8[1] = GXv_int7;
         return GXv_Object8 ;
      }

      protected Object[] conditional_H002S3( IGxContext context ,
                                             string A2243SGNotificacionIconClass ,
                                             GxSimpleCollection<string> AV84Seguridad_notificacioneswwds_24_tfsgnotificacioniconclass_sels ,
                                             string AV61Seguridad_notificacioneswwds_1_dynamicfiltersselector1 ,
                                             short AV62Seguridad_notificacioneswwds_2_dynamicfiltersoperator1 ,
                                             string AV63Seguridad_notificacioneswwds_3_sgnotificaciontitulo1 ,
                                             bool AV64Seguridad_notificacioneswwds_4_dynamicfiltersenabled2 ,
                                             string AV65Seguridad_notificacioneswwds_5_dynamicfiltersselector2 ,
                                             short AV66Seguridad_notificacioneswwds_6_dynamicfiltersoperator2 ,
                                             string AV67Seguridad_notificacioneswwds_7_sgnotificaciontitulo2 ,
                                             bool AV68Seguridad_notificacioneswwds_8_dynamicfiltersenabled3 ,
                                             string AV69Seguridad_notificacioneswwds_9_dynamicfiltersselector3 ,
                                             short AV70Seguridad_notificacioneswwds_10_dynamicfiltersoperator3 ,
                                             string AV71Seguridad_notificacioneswwds_11_sgnotificaciontitulo3 ,
                                             long AV72Seguridad_notificacioneswwds_12_tfsgnotificacionid ,
                                             long AV73Seguridad_notificacioneswwds_13_tfsgnotificacionid_to ,
                                             string AV75Seguridad_notificacioneswwds_15_tfsgnotificaciontitulo_sel ,
                                             string AV74Seguridad_notificacioneswwds_14_tfsgnotificaciontitulo ,
                                             string AV77Seguridad_notificacioneswwds_17_tfsgnotificaciondescripcion_sel ,
                                             string AV76Seguridad_notificacioneswwds_16_tfsgnotificaciondescripcion ,
                                             DateTime AV78Seguridad_notificacioneswwds_18_tfsgnotificacionfecha ,
                                             DateTime AV79Seguridad_notificacioneswwds_19_tfsgnotificacionfecha_to ,
                                             string AV81Seguridad_notificacioneswwds_21_tfsgnotificacionusuario_sel ,
                                             string AV80Seguridad_notificacioneswwds_20_tfsgnotificacionusuario ,
                                             string AV83Seguridad_notificacioneswwds_23_tfsgnotificacionusuariodsc_sel ,
                                             string AV82Seguridad_notificacioneswwds_22_tfsgnotificacionusuariodsc ,
                                             int AV84Seguridad_notificacioneswwds_24_tfsgnotificacioniconclass_sels_Count ,
                                             short AV85Seguridad_notificacioneswwds_25_tfsgnotificaciontusuario ,
                                             short AV86Seguridad_notificacioneswwds_26_tfsgnotificaciontusuario_to ,
                                             string A2238SGNotificacionTitulo ,
                                             long A2237SGNotificacionID ,
                                             string A2239SGNotificacionDescripcion ,
                                             DateTime A2240SGNotificacionFecha ,
                                             string A2241SGNotificacionUsuario ,
                                             string A2242SGNotificacionUsuarioDsc ,
                                             short A2244SGNotificacionTUsuario ,
                                             short AV13OrderedBy ,
                                             bool AV14OrderedDsc )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int9 = new short[20];
         Object[] GXv_Object10 = new Object[2];
         scmdbuf = "SELECT COUNT(*) FROM ([SGNOTIFICACIONES] T1 INNER JOIN [SGUSUARIOS] T2 ON T2.[UsuCod] = T1.[SGNotificacionUsuario])";
         if ( ( StringUtil.StrCmp(AV61Seguridad_notificacioneswwds_1_dynamicfiltersselector1, "SGNOTIFICACIONTITULO") == 0 ) && ( AV62Seguridad_notificacioneswwds_2_dynamicfiltersoperator1 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV63Seguridad_notificacioneswwds_3_sgnotificaciontitulo1)) ) )
         {
            AddWhere(sWhereString, "(T1.[SGNotificacionTitulo] like @lV63Seguridad_notificacioneswwds_3_sgnotificaciontitulo1)");
         }
         else
         {
            GXv_int9[0] = 1;
         }
         if ( ( StringUtil.StrCmp(AV61Seguridad_notificacioneswwds_1_dynamicfiltersselector1, "SGNOTIFICACIONTITULO") == 0 ) && ( AV62Seguridad_notificacioneswwds_2_dynamicfiltersoperator1 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV63Seguridad_notificacioneswwds_3_sgnotificaciontitulo1)) ) )
         {
            AddWhere(sWhereString, "(T1.[SGNotificacionTitulo] like '%' + @lV63Seguridad_notificacioneswwds_3_sgnotificaciontitulo1)");
         }
         else
         {
            GXv_int9[1] = 1;
         }
         if ( AV64Seguridad_notificacioneswwds_4_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV65Seguridad_notificacioneswwds_5_dynamicfiltersselector2, "SGNOTIFICACIONTITULO") == 0 ) && ( AV66Seguridad_notificacioneswwds_6_dynamicfiltersoperator2 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV67Seguridad_notificacioneswwds_7_sgnotificaciontitulo2)) ) )
         {
            AddWhere(sWhereString, "(T1.[SGNotificacionTitulo] like @lV67Seguridad_notificacioneswwds_7_sgnotificaciontitulo2)");
         }
         else
         {
            GXv_int9[2] = 1;
         }
         if ( AV64Seguridad_notificacioneswwds_4_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV65Seguridad_notificacioneswwds_5_dynamicfiltersselector2, "SGNOTIFICACIONTITULO") == 0 ) && ( AV66Seguridad_notificacioneswwds_6_dynamicfiltersoperator2 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV67Seguridad_notificacioneswwds_7_sgnotificaciontitulo2)) ) )
         {
            AddWhere(sWhereString, "(T1.[SGNotificacionTitulo] like '%' + @lV67Seguridad_notificacioneswwds_7_sgnotificaciontitulo2)");
         }
         else
         {
            GXv_int9[3] = 1;
         }
         if ( AV68Seguridad_notificacioneswwds_8_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV69Seguridad_notificacioneswwds_9_dynamicfiltersselector3, "SGNOTIFICACIONTITULO") == 0 ) && ( AV70Seguridad_notificacioneswwds_10_dynamicfiltersoperator3 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV71Seguridad_notificacioneswwds_11_sgnotificaciontitulo3)) ) )
         {
            AddWhere(sWhereString, "(T1.[SGNotificacionTitulo] like @lV71Seguridad_notificacioneswwds_11_sgnotificaciontitulo3)");
         }
         else
         {
            GXv_int9[4] = 1;
         }
         if ( AV68Seguridad_notificacioneswwds_8_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV69Seguridad_notificacioneswwds_9_dynamicfiltersselector3, "SGNOTIFICACIONTITULO") == 0 ) && ( AV70Seguridad_notificacioneswwds_10_dynamicfiltersoperator3 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV71Seguridad_notificacioneswwds_11_sgnotificaciontitulo3)) ) )
         {
            AddWhere(sWhereString, "(T1.[SGNotificacionTitulo] like '%' + @lV71Seguridad_notificacioneswwds_11_sgnotificaciontitulo3)");
         }
         else
         {
            GXv_int9[5] = 1;
         }
         if ( ! (0==AV72Seguridad_notificacioneswwds_12_tfsgnotificacionid) )
         {
            AddWhere(sWhereString, "(T1.[SGNotificacionID] >= @AV72Seguridad_notificacioneswwds_12_tfsgnotificacionid)");
         }
         else
         {
            GXv_int9[6] = 1;
         }
         if ( ! (0==AV73Seguridad_notificacioneswwds_13_tfsgnotificacionid_to) )
         {
            AddWhere(sWhereString, "(T1.[SGNotificacionID] <= @AV73Seguridad_notificacioneswwds_13_tfsgnotificacionid_to)");
         }
         else
         {
            GXv_int9[7] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV75Seguridad_notificacioneswwds_15_tfsgnotificaciontitulo_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV74Seguridad_notificacioneswwds_14_tfsgnotificaciontitulo)) ) )
         {
            AddWhere(sWhereString, "(T1.[SGNotificacionTitulo] like @lV74Seguridad_notificacioneswwds_14_tfsgnotificaciontitulo)");
         }
         else
         {
            GXv_int9[8] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV75Seguridad_notificacioneswwds_15_tfsgnotificaciontitulo_sel)) )
         {
            AddWhere(sWhereString, "(T1.[SGNotificacionTitulo] = @AV75Seguridad_notificacioneswwds_15_tfsgnotificaciontitulo_sel)");
         }
         else
         {
            GXv_int9[9] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV77Seguridad_notificacioneswwds_17_tfsgnotificaciondescripcion_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV76Seguridad_notificacioneswwds_16_tfsgnotificaciondescripcion)) ) )
         {
            AddWhere(sWhereString, "(T1.[SGNotificacionDescripcion] like @lV76Seguridad_notificacioneswwds_16_tfsgnotificaciondescripcion)");
         }
         else
         {
            GXv_int9[10] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV77Seguridad_notificacioneswwds_17_tfsgnotificaciondescripcion_sel)) )
         {
            AddWhere(sWhereString, "(T1.[SGNotificacionDescripcion] = @AV77Seguridad_notificacioneswwds_17_tfsgnotificaciondescripcion_sel)");
         }
         else
         {
            GXv_int9[11] = 1;
         }
         if ( ! (DateTime.MinValue==AV78Seguridad_notificacioneswwds_18_tfsgnotificacionfecha) )
         {
            AddWhere(sWhereString, "(T1.[SGNotificacionFecha] >= @AV78Seguridad_notificacioneswwds_18_tfsgnotificacionfecha)");
         }
         else
         {
            GXv_int9[12] = 1;
         }
         if ( ! (DateTime.MinValue==AV79Seguridad_notificacioneswwds_19_tfsgnotificacionfecha_to) )
         {
            AddWhere(sWhereString, "(T1.[SGNotificacionFecha] <= @AV79Seguridad_notificacioneswwds_19_tfsgnotificacionfecha_to)");
         }
         else
         {
            GXv_int9[13] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV81Seguridad_notificacioneswwds_21_tfsgnotificacionusuario_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV80Seguridad_notificacioneswwds_20_tfsgnotificacionusuario)) ) )
         {
            AddWhere(sWhereString, "(T1.[SGNotificacionUsuario] like @lV80Seguridad_notificacioneswwds_20_tfsgnotificacionusuario)");
         }
         else
         {
            GXv_int9[14] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV81Seguridad_notificacioneswwds_21_tfsgnotificacionusuario_sel)) )
         {
            AddWhere(sWhereString, "(T1.[SGNotificacionUsuario] = @AV81Seguridad_notificacioneswwds_21_tfsgnotificacionusuario_sel)");
         }
         else
         {
            GXv_int9[15] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV83Seguridad_notificacioneswwds_23_tfsgnotificacionusuariodsc_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV82Seguridad_notificacioneswwds_22_tfsgnotificacionusuariodsc)) ) )
         {
            AddWhere(sWhereString, "(T2.[UsuNom] like @lV82Seguridad_notificacioneswwds_22_tfsgnotificacionusuariodsc)");
         }
         else
         {
            GXv_int9[16] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV83Seguridad_notificacioneswwds_23_tfsgnotificacionusuariodsc_sel)) )
         {
            AddWhere(sWhereString, "(T2.[UsuNom] = @AV83Seguridad_notificacioneswwds_23_tfsgnotificacionusuariodsc_sel)");
         }
         else
         {
            GXv_int9[17] = 1;
         }
         if ( AV84Seguridad_notificacioneswwds_24_tfsgnotificacioniconclass_sels_Count > 0 )
         {
            AddWhere(sWhereString, "("+new GxDbmsUtils( new GxSqlServer()).ValueList(AV84Seguridad_notificacioneswwds_24_tfsgnotificacioniconclass_sels, "T1.[SGNotificacionIconClass] IN (", ")")+")");
         }
         if ( ! (0==AV85Seguridad_notificacioneswwds_25_tfsgnotificaciontusuario) )
         {
            AddWhere(sWhereString, "(T1.[SGNotificacionTUsuario] >= @AV85Seguridad_notificacioneswwds_25_tfsgnotificaciontusuario)");
         }
         else
         {
            GXv_int9[18] = 1;
         }
         if ( ! (0==AV86Seguridad_notificacioneswwds_26_tfsgnotificaciontusuario_to) )
         {
            AddWhere(sWhereString, "(T1.[SGNotificacionTUsuario] <= @AV86Seguridad_notificacioneswwds_26_tfsgnotificaciontusuario_to)");
         }
         else
         {
            GXv_int9[19] = 1;
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
                     return conditional_H002S2(context, (string)dynConstraints[0] , (GxSimpleCollection<string>)dynConstraints[1] , (string)dynConstraints[2] , (short)dynConstraints[3] , (string)dynConstraints[4] , (bool)dynConstraints[5] , (string)dynConstraints[6] , (short)dynConstraints[7] , (string)dynConstraints[8] , (bool)dynConstraints[9] , (string)dynConstraints[10] , (short)dynConstraints[11] , (string)dynConstraints[12] , (long)dynConstraints[13] , (long)dynConstraints[14] , (string)dynConstraints[15] , (string)dynConstraints[16] , (string)dynConstraints[17] , (string)dynConstraints[18] , (DateTime)dynConstraints[19] , (DateTime)dynConstraints[20] , (string)dynConstraints[21] , (string)dynConstraints[22] , (string)dynConstraints[23] , (string)dynConstraints[24] , (int)dynConstraints[25] , (short)dynConstraints[26] , (short)dynConstraints[27] , (string)dynConstraints[28] , (long)dynConstraints[29] , (string)dynConstraints[30] , (DateTime)dynConstraints[31] , (string)dynConstraints[32] , (string)dynConstraints[33] , (short)dynConstraints[34] , (short)dynConstraints[35] , (bool)dynConstraints[36] );
               case 1 :
                     return conditional_H002S3(context, (string)dynConstraints[0] , (GxSimpleCollection<string>)dynConstraints[1] , (string)dynConstraints[2] , (short)dynConstraints[3] , (string)dynConstraints[4] , (bool)dynConstraints[5] , (string)dynConstraints[6] , (short)dynConstraints[7] , (string)dynConstraints[8] , (bool)dynConstraints[9] , (string)dynConstraints[10] , (short)dynConstraints[11] , (string)dynConstraints[12] , (long)dynConstraints[13] , (long)dynConstraints[14] , (string)dynConstraints[15] , (string)dynConstraints[16] , (string)dynConstraints[17] , (string)dynConstraints[18] , (DateTime)dynConstraints[19] , (DateTime)dynConstraints[20] , (string)dynConstraints[21] , (string)dynConstraints[22] , (string)dynConstraints[23] , (string)dynConstraints[24] , (int)dynConstraints[25] , (short)dynConstraints[26] , (short)dynConstraints[27] , (string)dynConstraints[28] , (long)dynConstraints[29] , (string)dynConstraints[30] , (DateTime)dynConstraints[31] , (string)dynConstraints[32] , (string)dynConstraints[33] , (short)dynConstraints[34] , (short)dynConstraints[35] , (bool)dynConstraints[36] );
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
          Object[] prmH002S2;
          prmH002S2 = new Object[] {
          new ParDef("@lV63Seguridad_notificacioneswwds_3_sgnotificaciontitulo1",GXType.NVarChar,100,0) ,
          new ParDef("@lV63Seguridad_notificacioneswwds_3_sgnotificaciontitulo1",GXType.NVarChar,100,0) ,
          new ParDef("@lV67Seguridad_notificacioneswwds_7_sgnotificaciontitulo2",GXType.NVarChar,100,0) ,
          new ParDef("@lV67Seguridad_notificacioneswwds_7_sgnotificaciontitulo2",GXType.NVarChar,100,0) ,
          new ParDef("@lV71Seguridad_notificacioneswwds_11_sgnotificaciontitulo3",GXType.NVarChar,100,0) ,
          new ParDef("@lV71Seguridad_notificacioneswwds_11_sgnotificaciontitulo3",GXType.NVarChar,100,0) ,
          new ParDef("@AV72Seguridad_notificacioneswwds_12_tfsgnotificacionid",GXType.Decimal,10,0) ,
          new ParDef("@AV73Seguridad_notificacioneswwds_13_tfsgnotificacionid_to",GXType.Decimal,10,0) ,
          new ParDef("@lV74Seguridad_notificacioneswwds_14_tfsgnotificaciontitulo",GXType.NVarChar,100,0) ,
          new ParDef("@AV75Seguridad_notificacioneswwds_15_tfsgnotificaciontitulo_sel",GXType.NVarChar,100,0) ,
          new ParDef("@lV76Seguridad_notificacioneswwds_16_tfsgnotificaciondescripcion",GXType.NVarChar,200,0) ,
          new ParDef("@AV77Seguridad_notificacioneswwds_17_tfsgnotificaciondescripcion_sel",GXType.NVarChar,200,0) ,
          new ParDef("@AV78Seguridad_notificacioneswwds_18_tfsgnotificacionfecha",GXType.DateTime,8,5) ,
          new ParDef("@AV79Seguridad_notificacioneswwds_19_tfsgnotificacionfecha_to",GXType.DateTime,8,5) ,
          new ParDef("@lV80Seguridad_notificacioneswwds_20_tfsgnotificacionusuario",GXType.NChar,10,0) ,
          new ParDef("@AV81Seguridad_notificacioneswwds_21_tfsgnotificacionusuario_sel",GXType.NChar,10,0) ,
          new ParDef("@lV82Seguridad_notificacioneswwds_22_tfsgnotificacionusuariodsc",GXType.NChar,100,0) ,
          new ParDef("@AV83Seguridad_notificacioneswwds_23_tfsgnotificacionusuariodsc_sel",GXType.NChar,100,0) ,
          new ParDef("@AV85Seguridad_notificacioneswwds_25_tfsgnotificaciontusuario",GXType.Int16,4,0) ,
          new ParDef("@AV86Seguridad_notificacioneswwds_26_tfsgnotificaciontusuario_to",GXType.Int16,4,0) ,
          new ParDef("@GXPagingFrom2",GXType.Int32,9,0) ,
          new ParDef("@GXPagingTo2",GXType.Int32,9,0) ,
          new ParDef("@GXPagingTo2",GXType.Int32,9,0)
          };
          Object[] prmH002S3;
          prmH002S3 = new Object[] {
          new ParDef("@lV63Seguridad_notificacioneswwds_3_sgnotificaciontitulo1",GXType.NVarChar,100,0) ,
          new ParDef("@lV63Seguridad_notificacioneswwds_3_sgnotificaciontitulo1",GXType.NVarChar,100,0) ,
          new ParDef("@lV67Seguridad_notificacioneswwds_7_sgnotificaciontitulo2",GXType.NVarChar,100,0) ,
          new ParDef("@lV67Seguridad_notificacioneswwds_7_sgnotificaciontitulo2",GXType.NVarChar,100,0) ,
          new ParDef("@lV71Seguridad_notificacioneswwds_11_sgnotificaciontitulo3",GXType.NVarChar,100,0) ,
          new ParDef("@lV71Seguridad_notificacioneswwds_11_sgnotificaciontitulo3",GXType.NVarChar,100,0) ,
          new ParDef("@AV72Seguridad_notificacioneswwds_12_tfsgnotificacionid",GXType.Decimal,10,0) ,
          new ParDef("@AV73Seguridad_notificacioneswwds_13_tfsgnotificacionid_to",GXType.Decimal,10,0) ,
          new ParDef("@lV74Seguridad_notificacioneswwds_14_tfsgnotificaciontitulo",GXType.NVarChar,100,0) ,
          new ParDef("@AV75Seguridad_notificacioneswwds_15_tfsgnotificaciontitulo_sel",GXType.NVarChar,100,0) ,
          new ParDef("@lV76Seguridad_notificacioneswwds_16_tfsgnotificaciondescripcion",GXType.NVarChar,200,0) ,
          new ParDef("@AV77Seguridad_notificacioneswwds_17_tfsgnotificaciondescripcion_sel",GXType.NVarChar,200,0) ,
          new ParDef("@AV78Seguridad_notificacioneswwds_18_tfsgnotificacionfecha",GXType.DateTime,8,5) ,
          new ParDef("@AV79Seguridad_notificacioneswwds_19_tfsgnotificacionfecha_to",GXType.DateTime,8,5) ,
          new ParDef("@lV80Seguridad_notificacioneswwds_20_tfsgnotificacionusuario",GXType.NChar,10,0) ,
          new ParDef("@AV81Seguridad_notificacioneswwds_21_tfsgnotificacionusuario_sel",GXType.NChar,10,0) ,
          new ParDef("@lV82Seguridad_notificacioneswwds_22_tfsgnotificacionusuariodsc",GXType.NChar,100,0) ,
          new ParDef("@AV83Seguridad_notificacioneswwds_23_tfsgnotificacionusuariodsc_sel",GXType.NChar,100,0) ,
          new ParDef("@AV85Seguridad_notificacioneswwds_25_tfsgnotificaciontusuario",GXType.Int16,4,0) ,
          new ParDef("@AV86Seguridad_notificacioneswwds_26_tfsgnotificaciontusuario_to",GXType.Int16,4,0)
          };
          def= new CursorDef[] {
              new CursorDef("H002S2", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH002S2,11, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("H002S3", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH002S3,1, GxCacheFrequency.OFF ,true,false )
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
                ((string[]) buf[1])[0] = rslt.getVarchar(2);
                ((string[]) buf[2])[0] = rslt.getString(3, 100);
                ((string[]) buf[3])[0] = rslt.getString(4, 10);
                ((DateTime[]) buf[4])[0] = rslt.getGXDateTime(5);
                ((string[]) buf[5])[0] = rslt.getVarchar(6);
                ((string[]) buf[6])[0] = rslt.getVarchar(7);
                ((long[]) buf[7])[0] = rslt.getLong(8);
                return;
             case 1 :
                ((long[]) buf[0])[0] = rslt.getLong(1);
                return;
       }
    }

 }

}
