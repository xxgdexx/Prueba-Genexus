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
namespace GeneXus.Programs.reloj_interface {
   public class reloj_codigoidww : GXDataArea
   {
      public reloj_codigoidww( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDataStore2 = context.GetDataStore("DataStore2");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusTheme");
      }

      public reloj_codigoidww( IGxContext context )
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
               AV17RHTrabajadorNombres1 = GetPar( "RHTrabajadorNombres1");
               AV18Reloj_Nombre1 = GetPar( "Reloj_Nombre1");
               AV19HorarioDescripcion1 = GetPar( "HorarioDescripcion1");
               cmbavDynamicfiltersselector2.FromJSonString( GetNextPar( ));
               AV21DynamicFiltersSelector2 = GetPar( "DynamicFiltersSelector2");
               cmbavDynamicfiltersoperator2.FromJSonString( GetNextPar( ));
               AV22DynamicFiltersOperator2 = (short)(NumberUtil.Val( GetPar( "DynamicFiltersOperator2"), "."));
               AV23RHTrabajadorNombres2 = GetPar( "RHTrabajadorNombres2");
               AV24Reloj_Nombre2 = GetPar( "Reloj_Nombre2");
               AV25HorarioDescripcion2 = GetPar( "HorarioDescripcion2");
               cmbavDynamicfiltersselector3.FromJSonString( GetNextPar( ));
               AV27DynamicFiltersSelector3 = GetPar( "DynamicFiltersSelector3");
               cmbavDynamicfiltersoperator3.FromJSonString( GetNextPar( ));
               AV28DynamicFiltersOperator3 = (short)(NumberUtil.Val( GetPar( "DynamicFiltersOperator3"), "."));
               AV29RHTrabajadorNombres3 = GetPar( "RHTrabajadorNombres3");
               AV30Reloj_Nombre3 = GetPar( "Reloj_Nombre3");
               AV31HorarioDescripcion3 = GetPar( "HorarioDescripcion3");
               AV20DynamicFiltersEnabled2 = StringUtil.StrToBool( GetPar( "DynamicFiltersEnabled2"));
               AV26DynamicFiltersEnabled3 = StringUtil.StrToBool( GetPar( "DynamicFiltersEnabled3"));
               AV71Pgmname = GetPar( "Pgmname");
               AV37TFCodigoId = GetPar( "TFCodigoId");
               AV38TFCodigoId_Sel = GetPar( "TFCodigoId_Sel");
               AV41TFReloj_Nombre = GetPar( "TFReloj_Nombre");
               AV42TFReloj_Nombre_Sel = GetPar( "TFReloj_Nombre_Sel");
               AV43TFLectura_Ini = context.localUtil.ParseDTimeParm( GetPar( "TFLectura_Ini"));
               AV44TFLectura_Ini_To = context.localUtil.ParseDTimeParm( GetPar( "TFLectura_Ini_To"));
               AV55TFRHTrabajadorNombres = GetPar( "TFRHTrabajadorNombres");
               AV56TFRHTrabajadorNombres_Sel = GetPar( "TFRHTrabajadorNombres_Sel");
               AV59TFHorarioDescripcion = GetPar( "TFHorarioDescripcion");
               AV60TFHorarioDescripcion_Sel = GetPar( "TFHorarioDescripcion_Sel");
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
               gxgrGrid_refresh( subGrid_Rows, AV15DynamicFiltersSelector1, AV16DynamicFiltersOperator1, AV17RHTrabajadorNombres1, AV18Reloj_Nombre1, AV19HorarioDescripcion1, AV21DynamicFiltersSelector2, AV22DynamicFiltersOperator2, AV23RHTrabajadorNombres2, AV24Reloj_Nombre2, AV25HorarioDescripcion2, AV27DynamicFiltersSelector3, AV28DynamicFiltersOperator3, AV29RHTrabajadorNombres3, AV30Reloj_Nombre3, AV31HorarioDescripcion3, AV20DynamicFiltersEnabled2, AV26DynamicFiltersEnabled3, AV71Pgmname, AV37TFCodigoId, AV38TFCodigoId_Sel, AV41TFReloj_Nombre, AV42TFReloj_Nombre_Sel, AV43TFLectura_Ini, AV44TFLectura_Ini_To, AV55TFRHTrabajadorNombres, AV56TFRHTrabajadorNombres_Sel, AV59TFHorarioDescripcion, AV60TFHorarioDescripcion_Sel, AV13OrderedBy, AV14OrderedDsc, AV10GridState, AV33DynamicFiltersIgnoreFirst, AV32DynamicFiltersRemoving) ;
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
         PA7M2( ) ;
         gxajaxcallmode = (short)((isAjaxCallMode( ) ? 1 : 0));
         if ( ( gxajaxcallmode == 0 ) && ( GxWebError == 0 ) )
         {
            START7M2( ) ;
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
         context.AddJavascriptSource("gxcfg.js", "?20228181416240", false, true);
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
         context.WriteHtmlTextNl( "<form id=\"MAINFORM\" autocomplete=\"off\" name=\"MAINFORM\" method=\"post\" tabindex=-1  class=\"form-horizontal Form\" data-gx-class=\"form-horizontal Form\" novalidate action=\""+formatLink("reloj_interface.reloj_codigoidww.aspx") +"\">") ;
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
         GxWebStd.gx_hidden_field( context, "GXH_vRHTRABAJADORNOMBRES1", AV17RHTrabajadorNombres1);
         GxWebStd.gx_hidden_field( context, "GXH_vRELOJ_NOMBRE1", AV18Reloj_Nombre1);
         GxWebStd.gx_hidden_field( context, "GXH_vHORARIODESCRIPCION1", AV19HorarioDescripcion1);
         GxWebStd.gx_hidden_field( context, "GXH_vDYNAMICFILTERSSELECTOR2", AV21DynamicFiltersSelector2);
         GxWebStd.gx_hidden_field( context, "GXH_vDYNAMICFILTERSOPERATOR2", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV22DynamicFiltersOperator2), 4, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "GXH_vRHTRABAJADORNOMBRES2", AV23RHTrabajadorNombres2);
         GxWebStd.gx_hidden_field( context, "GXH_vRELOJ_NOMBRE2", AV24Reloj_Nombre2);
         GxWebStd.gx_hidden_field( context, "GXH_vHORARIODESCRIPCION2", AV25HorarioDescripcion2);
         GxWebStd.gx_hidden_field( context, "GXH_vDYNAMICFILTERSSELECTOR3", AV27DynamicFiltersSelector3);
         GxWebStd.gx_hidden_field( context, "GXH_vDYNAMICFILTERSOPERATOR3", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV28DynamicFiltersOperator3), 4, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "GXH_vRHTRABAJADORNOMBRES3", AV29RHTrabajadorNombres3);
         GxWebStd.gx_hidden_field( context, "GXH_vRELOJ_NOMBRE3", AV30Reloj_Nombre3);
         GxWebStd.gx_hidden_field( context, "GXH_vHORARIODESCRIPCION3", AV31HorarioDescripcion3);
         /* Send saved values. */
         send_integrity_footer_hashes( ) ;
         GxWebStd.gx_hidden_field( context, "nRC_GXsfl_119", StringUtil.LTrim( StringUtil.NToC( (decimal)(nRC_GXsfl_119), 8, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "vGRIDCURRENTPAGE", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV63GridCurrentPage), 10, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "vGRIDPAGECOUNT", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV64GridPageCount), 10, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "vGRIDAPPLIEDFILTERS", AV65GridAppliedFilters);
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "vAGEXPORTDATA", AV67AGExportData);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt("vAGEXPORTDATA", AV67AGExportData);
         }
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "vDDO_TITLESETTINGSICONS", AV61DDO_TitleSettingsIcons);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt("vDDO_TITLESETTINGSICONS", AV61DDO_TitleSettingsIcons);
         }
         GxWebStd.gx_hidden_field( context, "vDDO_LECTURA_INIAUXDATETO", context.localUtil.DToC( AV46DDO_Lectura_IniAuxDateTo, 0, "/"));
         GxWebStd.gx_boolean_hidden_field( context, "vDYNAMICFILTERSENABLED2", AV20DynamicFiltersEnabled2);
         GxWebStd.gx_boolean_hidden_field( context, "vDYNAMICFILTERSENABLED3", AV26DynamicFiltersEnabled3);
         GxWebStd.gx_hidden_field( context, "vPGMNAME", StringUtil.RTrim( AV71Pgmname));
         GxWebStd.gx_hidden_field( context, "gxhash_vPGMNAME", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( AV71Pgmname, "")), context));
         GxWebStd.gx_hidden_field( context, "vTFCODIGOID", AV37TFCodigoId);
         GxWebStd.gx_hidden_field( context, "vTFCODIGOID_SEL", AV38TFCodigoId_Sel);
         GxWebStd.gx_hidden_field( context, "vTFRELOJ_NOMBRE", AV41TFReloj_Nombre);
         GxWebStd.gx_hidden_field( context, "vTFRELOJ_NOMBRE_SEL", AV42TFReloj_Nombre_Sel);
         GxWebStd.gx_hidden_field( context, "vTFLECTURA_INI", context.localUtil.TToC( AV43TFLectura_Ini, 10, 8, 0, 0, "/", ":", " "));
         GxWebStd.gx_hidden_field( context, "vTFLECTURA_INI_TO", context.localUtil.TToC( AV44TFLectura_Ini_To, 10, 8, 0, 0, "/", ":", " "));
         GxWebStd.gx_hidden_field( context, "vTFRHTRABAJADORNOMBRES", AV55TFRHTrabajadorNombres);
         GxWebStd.gx_hidden_field( context, "vTFRHTRABAJADORNOMBRES_SEL", AV56TFRHTrabajadorNombres_Sel);
         GxWebStd.gx_hidden_field( context, "vTFHORARIODESCRIPCION", AV59TFHorarioDescripcion);
         GxWebStd.gx_hidden_field( context, "vTFHORARIODESCRIPCION_SEL", AV60TFHorarioDescripcion_Sel);
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
         GxWebStd.gx_hidden_field( context, "RELOJ_ID", StringUtil.LTrim( StringUtil.NToC( (decimal)(A2498Reloj_ID), 4, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "HORARIOID", StringUtil.LTrim( StringUtil.NToC( (decimal)(A2591HorarioID), 4, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "GRID_nFirstRecordOnPage", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRID_nFirstRecordOnPage), 15, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "GRID_nEOF", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRID_nEOF), 1, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "vDDO_LECTURA_INIAUXDATE", context.localUtil.DToC( AV45DDO_Lectura_IniAuxDate, 0, "/"));
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
            WE7M2( ) ;
            context.WriteHtmlText( "</div>") ;
         }
      }

      public override void DispatchEvents( )
      {
         EVT7M2( ) ;
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
         return formatLink("reloj_interface.reloj_codigoidww.aspx")  ;
      }

      public override string GetPgmname( )
      {
         return "Reloj_Interface.Reloj_CodigoIDWW" ;
      }

      public override string GetPgmdesc( )
      {
         return "Codigos Registrados en Reloj" ;
      }

      protected void WB7M0( )
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
            GxWebStd.gx_button_ctrl( context, bttBtninsert_Internalname, "gx.evt.setGridEvt("+StringUtil.Str( (decimal)(119), 3, 0)+","+"null"+");", "Agregar", bttBtninsert_Jsonclick, 5, "Agregar", "", StyleString, ClassString, 1, 1, "standard", "'"+""+"'"+",false,"+"'"+"E\\'DOINSERT\\'."+"'", TempTags, "", context.GetButtonType( ), "HLP_Reloj_Interface\\Reloj_CodigoIDWW.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "left", "top", "", "", "div");
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 21,'',false,'',0)\"";
            ClassString = "ColumnsSelector";
            StyleString = "";
            GxWebStd.gx_button_ctrl( context, bttBtnagexport_Internalname, "gx.evt.setGridEvt("+StringUtil.Str( (decimal)(119), 3, 0)+","+"null"+");", "Reportes", bttBtnagexport_Jsonclick, 0, "Reportes", "", StyleString, ClassString, 1, 0, "standard", "'"+""+"'"+",false,"+"'"+""+"'", TempTags, "", context.GetButtonType( ), "HLP_Reloj_Interface\\Reloj_CodigoIDWW.htm");
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
            wb_table1_25_7M2( true) ;
         }
         else
         {
            wb_table1_25_7M2( false) ;
         }
         return  ;
      }

      protected void wb_table1_25_7M2e( bool wbgen )
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
               context.SendWebValue( "Trabajador ID") ;
               context.WriteHtmlTextNl( "</th>") ;
               context.WriteHtmlText( "<th align=\""+"left"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+""+""+"\" "+">") ;
               context.SendWebValue( "Reloj") ;
               context.WriteHtmlTextNl( "</th>") ;
               context.WriteHtmlText( "<th align=\""+"right"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+""+""+"\" "+">") ;
               context.SendWebValue( "Fecha Registro") ;
               context.WriteHtmlTextNl( "</th>") ;
               context.WriteHtmlText( "<th align=\""+"left"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+""+""+"\" "+">") ;
               context.SendWebValue( "Trabajador") ;
               context.WriteHtmlTextNl( "</th>") ;
               context.WriteHtmlText( "<th align=\""+"left"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+""+""+"\" "+">") ;
               context.SendWebValue( "Horario") ;
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
               GridColumn.AddObjectProperty("Value", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV66GridActions), 4, 0, ".", "")));
               GridContainer.AddColumnProperties(GridColumn);
               GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
               GridColumn.AddObjectProperty("Value", A2431CodigoId);
               GridContainer.AddColumnProperties(GridColumn);
               GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
               GridColumn.AddObjectProperty("Value", A2592Reloj_Nombre);
               GridColumn.AddObjectProperty("Link", StringUtil.RTrim( edtReloj_Nombre_Link));
               GridContainer.AddColumnProperties(GridColumn);
               GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
               GridColumn.AddObjectProperty("Value", context.localUtil.TToC( A2415Lectura_Ini, 10, 8, 0, 3, "/", ":", " "));
               GridContainer.AddColumnProperties(GridColumn);
               GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
               GridColumn.AddObjectProperty("Value", A2590RHTrabajadorNombres);
               GridColumn.AddObjectProperty("Link", StringUtil.RTrim( edtRHTrabajadorNombres_Link));
               GridContainer.AddColumnProperties(GridColumn);
               GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
               GridColumn.AddObjectProperty("Value", A2593HorarioDescripcion);
               GridColumn.AddObjectProperty("Link", StringUtil.RTrim( edtHorarioDescripcion_Link));
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
            ucGridpaginationbar.SetProperty("CurrentPage", AV63GridCurrentPage);
            ucGridpaginationbar.SetProperty("PageCount", AV64GridPageCount);
            ucGridpaginationbar.SetProperty("AppliedFilters", AV65GridAppliedFilters);
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
            ucDdo_agexport.SetProperty("DropDownOptionsData", AV67AGExportData);
            ucDdo_agexport.Render(context, "dvelop.gxbootstrap.ddoregular", Ddo_agexport_Internalname, "DDO_AGEXPORTContainer");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblJsdynamicfilters_Internalname, lblJsdynamicfilters_Caption, "", "", lblJsdynamicfilters_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "", 0, "", 1, 1, 0, 1, "HLP_Reloj_Interface\\Reloj_CodigoIDWW.htm");
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
            ucDdo_grid.SetProperty("DropDownOptionsTitleSettingsIcons", AV61DDO_TitleSettingsIcons);
            ucDdo_grid.Render(context, "dvelop.gxbootstrap.ddogridtitlesettingsm", Ddo_grid_Internalname, "DDO_GRIDContainer");
            /* User Defined Control */
            ucInnewwindow1.Render(context, "innewwindow", Innewwindow1_Internalname, "INNEWWINDOW1Container");
            /* User Defined Control */
            ucGrid_empowerer.SetProperty("HasTitleSettings", Grid_empowerer_Hastitlesettings);
            ucGrid_empowerer.Render(context, "wwp.gridempowerer", Grid_empowerer_Internalname, "GRID_EMPOWERERContainer");
            /* Div Control */
            GxWebStd.gx_div_start( context, divDdo_lectura_iniauxdates_Internalname, 1, 0, "px", 0, "px", "Invisible", "left", "top", "", "", "div");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 138,'',false,'" + sGXsfl_119_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavDdo_lectura_iniauxdatetext_Internalname, AV47DDO_Lectura_IniAuxDateText, StringUtil.RTrim( context.localUtil.Format( AV47DDO_Lectura_IniAuxDateText, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,138);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavDdo_lectura_iniauxdatetext_Jsonclick, 0, "Attribute", "", "", "", "", 1, 1, 0, "text", "", 40, "chr", 1, "row", 40, 0, 0, 0, 1, -1, -1, true, "", "left", true, "", "HLP_Reloj_Interface\\Reloj_CodigoIDWW.htm");
            /* User Defined Control */
            ucTflectura_ini_rangepicker.SetProperty("Start Date", AV45DDO_Lectura_IniAuxDate);
            ucTflectura_ini_rangepicker.SetProperty("End Date", AV46DDO_Lectura_IniAuxDateTo);
            ucTflectura_ini_rangepicker.Render(context, "wwp.daterangepicker", Tflectura_ini_rangepicker_Internalname, "TFLECTURA_INI_RANGEPICKERContainer");
            GxWebStd.gx_div_end( context, "left", "top", "div");
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

      protected void START7M2( )
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
            Form.Meta.addItem("description", "Codigos Registrados en Reloj", 0) ;
         }
         context.wjLoc = "";
         context.nUserReturn = 0;
         context.wbHandled = 0;
         if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
         {
         }
         wbErr = false;
         STRUP7M0( ) ;
      }

      protected void WS7M2( )
      {
         START7M2( ) ;
         EVT7M2( ) ;
      }

      protected void EVT7M2( )
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
                              E117M2 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "GRIDPAGINATIONBAR.CHANGEROWSPERPAGE") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              E127M2 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "DDO_AGEXPORT.ONOPTIONCLICKED") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              E137M2 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "DDO_GRID.ONOPTIONCLICKED") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              E147M2 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "'REMOVEDYNAMICFILTERS1'") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              /* Execute user event: 'RemoveDynamicFilters1' */
                              E157M2 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "'REMOVEDYNAMICFILTERS2'") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              /* Execute user event: 'RemoveDynamicFilters2' */
                              E167M2 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "'REMOVEDYNAMICFILTERS3'") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              /* Execute user event: 'RemoveDynamicFilters3' */
                              E177M2 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "'DOINSERT'") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              /* Execute user event: 'DoInsert' */
                              E187M2 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "'ADDDYNAMICFILTERS1'") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              /* Execute user event: 'AddDynamicFilters1' */
                              E197M2 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "VDYNAMICFILTERSSELECTOR1.CLICK") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              E207M2 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "'ADDDYNAMICFILTERS2'") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              /* Execute user event: 'AddDynamicFilters2' */
                              E217M2 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "VDYNAMICFILTERSSELECTOR2.CLICK") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              E227M2 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "VDYNAMICFILTERSSELECTOR3.CLICK") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              E237M2 ();
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
                              AV66GridActions = (short)(NumberUtil.Val( cgiGet( cmbavGridactions_Internalname), "."));
                              AssignAttri("", false, cmbavGridactions_Internalname, StringUtil.LTrimStr( (decimal)(AV66GridActions), 4, 0));
                              A2431CodigoId = cgiGet( edtCodigoId_Internalname);
                              A2592Reloj_Nombre = cgiGet( edtReloj_Nombre_Internalname);
                              A2415Lectura_Ini = context.localUtil.CToT( cgiGet( edtLectura_Ini_Internalname), 0);
                              A2590RHTrabajadorNombres = cgiGet( edtRHTrabajadorNombres_Internalname);
                              A2593HorarioDescripcion = cgiGet( edtHorarioDescripcion_Internalname);
                              sEvtType = StringUtil.Right( sEvt, 1);
                              if ( StringUtil.StrCmp(sEvtType, ".") == 0 )
                              {
                                 sEvt = StringUtil.Left( sEvt, (short)(StringUtil.Len( sEvt)-1));
                                 if ( StringUtil.StrCmp(sEvt, "START") == 0 )
                                 {
                                    context.wbHandled = 1;
                                    dynload_actions( ) ;
                                    /* Execute user event: Start */
                                    E247M2 ();
                                 }
                                 else if ( StringUtil.StrCmp(sEvt, "REFRESH") == 0 )
                                 {
                                    context.wbHandled = 1;
                                    dynload_actions( ) ;
                                    /* Execute user event: Refresh */
                                    E257M2 ();
                                 }
                                 else if ( StringUtil.StrCmp(sEvt, "GRID.LOAD") == 0 )
                                 {
                                    context.wbHandled = 1;
                                    dynload_actions( ) ;
                                    E267M2 ();
                                 }
                                 else if ( StringUtil.StrCmp(sEvt, "VGRIDACTIONS.CLICK") == 0 )
                                 {
                                    context.wbHandled = 1;
                                    dynload_actions( ) ;
                                    E277M2 ();
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
                                       /* Set Refresh If Rhtrabajadornombres1 Changed */
                                       if ( StringUtil.StrCmp(cgiGet( "GXH_vRHTRABAJADORNOMBRES1"), AV17RHTrabajadorNombres1) != 0 )
                                       {
                                          Rfr0gs = true;
                                       }
                                       /* Set Refresh If Reloj_nombre1 Changed */
                                       if ( StringUtil.StrCmp(cgiGet( "GXH_vRELOJ_NOMBRE1"), AV18Reloj_Nombre1) != 0 )
                                       {
                                          Rfr0gs = true;
                                       }
                                       /* Set Refresh If Horariodescripcion1 Changed */
                                       if ( StringUtil.StrCmp(cgiGet( "GXH_vHORARIODESCRIPCION1"), AV19HorarioDescripcion1) != 0 )
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
                                       /* Set Refresh If Rhtrabajadornombres2 Changed */
                                       if ( StringUtil.StrCmp(cgiGet( "GXH_vRHTRABAJADORNOMBRES2"), AV23RHTrabajadorNombres2) != 0 )
                                       {
                                          Rfr0gs = true;
                                       }
                                       /* Set Refresh If Reloj_nombre2 Changed */
                                       if ( StringUtil.StrCmp(cgiGet( "GXH_vRELOJ_NOMBRE2"), AV24Reloj_Nombre2) != 0 )
                                       {
                                          Rfr0gs = true;
                                       }
                                       /* Set Refresh If Horariodescripcion2 Changed */
                                       if ( StringUtil.StrCmp(cgiGet( "GXH_vHORARIODESCRIPCION2"), AV25HorarioDescripcion2) != 0 )
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
                                       /* Set Refresh If Rhtrabajadornombres3 Changed */
                                       if ( StringUtil.StrCmp(cgiGet( "GXH_vRHTRABAJADORNOMBRES3"), AV29RHTrabajadorNombres3) != 0 )
                                       {
                                          Rfr0gs = true;
                                       }
                                       /* Set Refresh If Reloj_nombre3 Changed */
                                       if ( StringUtil.StrCmp(cgiGet( "GXH_vRELOJ_NOMBRE3"), AV30Reloj_Nombre3) != 0 )
                                       {
                                          Rfr0gs = true;
                                       }
                                       /* Set Refresh If Horariodescripcion3 Changed */
                                       if ( StringUtil.StrCmp(cgiGet( "GXH_vHORARIODESCRIPCION3"), AV31HorarioDescripcion3) != 0 )
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

      protected void WE7M2( )
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

      protected void PA7M2( )
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
                                       string AV17RHTrabajadorNombres1 ,
                                       string AV18Reloj_Nombre1 ,
                                       string AV19HorarioDescripcion1 ,
                                       string AV21DynamicFiltersSelector2 ,
                                       short AV22DynamicFiltersOperator2 ,
                                       string AV23RHTrabajadorNombres2 ,
                                       string AV24Reloj_Nombre2 ,
                                       string AV25HorarioDescripcion2 ,
                                       string AV27DynamicFiltersSelector3 ,
                                       short AV28DynamicFiltersOperator3 ,
                                       string AV29RHTrabajadorNombres3 ,
                                       string AV30Reloj_Nombre3 ,
                                       string AV31HorarioDescripcion3 ,
                                       bool AV20DynamicFiltersEnabled2 ,
                                       bool AV26DynamicFiltersEnabled3 ,
                                       string AV71Pgmname ,
                                       string AV37TFCodigoId ,
                                       string AV38TFCodigoId_Sel ,
                                       string AV41TFReloj_Nombre ,
                                       string AV42TFReloj_Nombre_Sel ,
                                       DateTime AV43TFLectura_Ini ,
                                       DateTime AV44TFLectura_Ini_To ,
                                       string AV55TFRHTrabajadorNombres ,
                                       string AV56TFRHTrabajadorNombres_Sel ,
                                       string AV59TFHorarioDescripcion ,
                                       string AV60TFHorarioDescripcion_Sel ,
                                       short AV13OrderedBy ,
                                       bool AV14OrderedDsc ,
                                       GeneXus.Programs.wwpbaseobjects.SdtWWPGridState AV10GridState ,
                                       bool AV33DynamicFiltersIgnoreFirst ,
                                       bool AV32DynamicFiltersRemoving )
      {
         initialize_formulas( ) ;
         GxWebStd.set_html_headers( context, 0, "", "");
         /* Execute user event: Refresh */
         E257M2 ();
         GRID_nCurrentRecord = 0;
         RF7M2( ) ;
         GXKey = Crypto.GetSiteKey( );
         send_integrity_footer_hashes( ) ;
         GXKey = Crypto.GetSiteKey( );
         /* End function gxgrGrid_refresh */
      }

      protected void send_integrity_hashes( )
      {
         GxWebStd.gx_hidden_field( context, "gxhash_CODIGOID", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( A2431CodigoId, "")), context));
         GxWebStd.gx_hidden_field( context, "CODIGOID", A2431CodigoId);
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
      }

      public void Refresh( )
      {
         send_integrity_hashes( ) ;
         RF7M2( ) ;
         if ( isFullAjaxMode( ) )
         {
            send_integrity_footer_hashes( ) ;
         }
      }

      protected void initialize_formulas( )
      {
         /* GeneXus formulas. */
         AV71Pgmname = "Reloj_Interface.Reloj_CodigoIDWW";
         context.Gx_err = 0;
      }

      protected void RF7M2( )
      {
         initialize_formulas( ) ;
         clear_multi_value_controls( ) ;
         if ( isAjaxCallMode( ) )
         {
            GridContainer.ClearRows();
         }
         wbStart = 119;
         /* Execute user event: Refresh */
         E257M2 ();
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
                                                 AV72Reloj_interface_reloj_codigoidwwds_1_dynamicfiltersselector1 ,
                                                 AV73Reloj_interface_reloj_codigoidwwds_2_dynamicfiltersoperator1 ,
                                                 AV74Reloj_interface_reloj_codigoidwwds_3_rhtrabajadornombres1 ,
                                                 AV75Reloj_interface_reloj_codigoidwwds_4_reloj_nombre1 ,
                                                 AV76Reloj_interface_reloj_codigoidwwds_5_horariodescripcion1 ,
                                                 AV77Reloj_interface_reloj_codigoidwwds_6_dynamicfiltersenabled2 ,
                                                 AV78Reloj_interface_reloj_codigoidwwds_7_dynamicfiltersselector2 ,
                                                 AV79Reloj_interface_reloj_codigoidwwds_8_dynamicfiltersoperator2 ,
                                                 AV80Reloj_interface_reloj_codigoidwwds_9_rhtrabajadornombres2 ,
                                                 AV81Reloj_interface_reloj_codigoidwwds_10_reloj_nombre2 ,
                                                 AV82Reloj_interface_reloj_codigoidwwds_11_horariodescripcion2 ,
                                                 AV83Reloj_interface_reloj_codigoidwwds_12_dynamicfiltersenabled3 ,
                                                 AV84Reloj_interface_reloj_codigoidwwds_13_dynamicfiltersselector3 ,
                                                 AV85Reloj_interface_reloj_codigoidwwds_14_dynamicfiltersoperator3 ,
                                                 AV86Reloj_interface_reloj_codigoidwwds_15_rhtrabajadornombres3 ,
                                                 AV87Reloj_interface_reloj_codigoidwwds_16_reloj_nombre3 ,
                                                 AV88Reloj_interface_reloj_codigoidwwds_17_horariodescripcion3 ,
                                                 AV90Reloj_interface_reloj_codigoidwwds_19_tfcodigoid_sel ,
                                                 AV89Reloj_interface_reloj_codigoidwwds_18_tfcodigoid ,
                                                 AV92Reloj_interface_reloj_codigoidwwds_21_tfreloj_nombre_sel ,
                                                 AV91Reloj_interface_reloj_codigoidwwds_20_tfreloj_nombre ,
                                                 AV93Reloj_interface_reloj_codigoidwwds_22_tflectura_ini ,
                                                 AV94Reloj_interface_reloj_codigoidwwds_23_tflectura_ini_to ,
                                                 AV96Reloj_interface_reloj_codigoidwwds_25_tfrhtrabajadornombres_sel ,
                                                 AV95Reloj_interface_reloj_codigoidwwds_24_tfrhtrabajadornombres ,
                                                 AV98Reloj_interface_reloj_codigoidwwds_27_tfhorariodescripcion_sel ,
                                                 AV97Reloj_interface_reloj_codigoidwwds_26_tfhorariodescripcion ,
                                                 A2525TrabApePat ,
                                                 A2526TrabApeMat ,
                                                 A2527TrabNombres ,
                                                 A2592Reloj_Nombre ,
                                                 A2593HorarioDescripcion ,
                                                 A2431CodigoId ,
                                                 A2415Lectura_Ini ,
                                                 AV13OrderedBy ,
                                                 AV14OrderedDsc } ,
                                                 new int[]{
                                                 TypeConstants.SHORT, TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.DATE, TypeConstants.DATE, TypeConstants.BOOLEAN, TypeConstants.BOOLEAN, TypeConstants.BOOLEAN,
                                                 TypeConstants.DATE, TypeConstants.SHORT, TypeConstants.BOOLEAN
                                                 }
            });
            lV74Reloj_interface_reloj_codigoidwwds_3_rhtrabajadornombres1 = StringUtil.Concat( StringUtil.RTrim( AV74Reloj_interface_reloj_codigoidwwds_3_rhtrabajadornombres1), "%", "");
            lV74Reloj_interface_reloj_codigoidwwds_3_rhtrabajadornombres1 = StringUtil.Concat( StringUtil.RTrim( AV74Reloj_interface_reloj_codigoidwwds_3_rhtrabajadornombres1), "%", "");
            lV75Reloj_interface_reloj_codigoidwwds_4_reloj_nombre1 = StringUtil.Concat( StringUtil.RTrim( AV75Reloj_interface_reloj_codigoidwwds_4_reloj_nombre1), "%", "");
            lV75Reloj_interface_reloj_codigoidwwds_4_reloj_nombre1 = StringUtil.Concat( StringUtil.RTrim( AV75Reloj_interface_reloj_codigoidwwds_4_reloj_nombre1), "%", "");
            lV76Reloj_interface_reloj_codigoidwwds_5_horariodescripcion1 = StringUtil.Concat( StringUtil.RTrim( AV76Reloj_interface_reloj_codigoidwwds_5_horariodescripcion1), "%", "");
            lV76Reloj_interface_reloj_codigoidwwds_5_horariodescripcion1 = StringUtil.Concat( StringUtil.RTrim( AV76Reloj_interface_reloj_codigoidwwds_5_horariodescripcion1), "%", "");
            lV80Reloj_interface_reloj_codigoidwwds_9_rhtrabajadornombres2 = StringUtil.Concat( StringUtil.RTrim( AV80Reloj_interface_reloj_codigoidwwds_9_rhtrabajadornombres2), "%", "");
            lV80Reloj_interface_reloj_codigoidwwds_9_rhtrabajadornombres2 = StringUtil.Concat( StringUtil.RTrim( AV80Reloj_interface_reloj_codigoidwwds_9_rhtrabajadornombres2), "%", "");
            lV81Reloj_interface_reloj_codigoidwwds_10_reloj_nombre2 = StringUtil.Concat( StringUtil.RTrim( AV81Reloj_interface_reloj_codigoidwwds_10_reloj_nombre2), "%", "");
            lV81Reloj_interface_reloj_codigoidwwds_10_reloj_nombre2 = StringUtil.Concat( StringUtil.RTrim( AV81Reloj_interface_reloj_codigoidwwds_10_reloj_nombre2), "%", "");
            lV82Reloj_interface_reloj_codigoidwwds_11_horariodescripcion2 = StringUtil.Concat( StringUtil.RTrim( AV82Reloj_interface_reloj_codigoidwwds_11_horariodescripcion2), "%", "");
            lV82Reloj_interface_reloj_codigoidwwds_11_horariodescripcion2 = StringUtil.Concat( StringUtil.RTrim( AV82Reloj_interface_reloj_codigoidwwds_11_horariodescripcion2), "%", "");
            lV86Reloj_interface_reloj_codigoidwwds_15_rhtrabajadornombres3 = StringUtil.Concat( StringUtil.RTrim( AV86Reloj_interface_reloj_codigoidwwds_15_rhtrabajadornombres3), "%", "");
            lV86Reloj_interface_reloj_codigoidwwds_15_rhtrabajadornombres3 = StringUtil.Concat( StringUtil.RTrim( AV86Reloj_interface_reloj_codigoidwwds_15_rhtrabajadornombres3), "%", "");
            lV87Reloj_interface_reloj_codigoidwwds_16_reloj_nombre3 = StringUtil.Concat( StringUtil.RTrim( AV87Reloj_interface_reloj_codigoidwwds_16_reloj_nombre3), "%", "");
            lV87Reloj_interface_reloj_codigoidwwds_16_reloj_nombre3 = StringUtil.Concat( StringUtil.RTrim( AV87Reloj_interface_reloj_codigoidwwds_16_reloj_nombre3), "%", "");
            lV88Reloj_interface_reloj_codigoidwwds_17_horariodescripcion3 = StringUtil.Concat( StringUtil.RTrim( AV88Reloj_interface_reloj_codigoidwwds_17_horariodescripcion3), "%", "");
            lV88Reloj_interface_reloj_codigoidwwds_17_horariodescripcion3 = StringUtil.Concat( StringUtil.RTrim( AV88Reloj_interface_reloj_codigoidwwds_17_horariodescripcion3), "%", "");
            lV89Reloj_interface_reloj_codigoidwwds_18_tfcodigoid = StringUtil.Concat( StringUtil.RTrim( AV89Reloj_interface_reloj_codigoidwwds_18_tfcodigoid), "%", "");
            lV91Reloj_interface_reloj_codigoidwwds_20_tfreloj_nombre = StringUtil.Concat( StringUtil.RTrim( AV91Reloj_interface_reloj_codigoidwwds_20_tfreloj_nombre), "%", "");
            lV95Reloj_interface_reloj_codigoidwwds_24_tfrhtrabajadornombres = StringUtil.Concat( StringUtil.RTrim( AV95Reloj_interface_reloj_codigoidwwds_24_tfrhtrabajadornombres), "%", "");
            lV97Reloj_interface_reloj_codigoidwwds_26_tfhorariodescripcion = StringUtil.Concat( StringUtil.RTrim( AV97Reloj_interface_reloj_codigoidwwds_26_tfhorariodescripcion), "%", "");
            /* Using cursor H007M2 */
            pr_default.execute(0, new Object[] {lV74Reloj_interface_reloj_codigoidwwds_3_rhtrabajadornombres1, lV74Reloj_interface_reloj_codigoidwwds_3_rhtrabajadornombres1, lV75Reloj_interface_reloj_codigoidwwds_4_reloj_nombre1, lV75Reloj_interface_reloj_codigoidwwds_4_reloj_nombre1, lV76Reloj_interface_reloj_codigoidwwds_5_horariodescripcion1, lV76Reloj_interface_reloj_codigoidwwds_5_horariodescripcion1, lV80Reloj_interface_reloj_codigoidwwds_9_rhtrabajadornombres2, lV80Reloj_interface_reloj_codigoidwwds_9_rhtrabajadornombres2, lV81Reloj_interface_reloj_codigoidwwds_10_reloj_nombre2, lV81Reloj_interface_reloj_codigoidwwds_10_reloj_nombre2, lV82Reloj_interface_reloj_codigoidwwds_11_horariodescripcion2, lV82Reloj_interface_reloj_codigoidwwds_11_horariodescripcion2, lV86Reloj_interface_reloj_codigoidwwds_15_rhtrabajadornombres3, lV86Reloj_interface_reloj_codigoidwwds_15_rhtrabajadornombres3, lV87Reloj_interface_reloj_codigoidwwds_16_reloj_nombre3, lV87Reloj_interface_reloj_codigoidwwds_16_reloj_nombre3, lV88Reloj_interface_reloj_codigoidwwds_17_horariodescripcion3, lV88Reloj_interface_reloj_codigoidwwds_17_horariodescripcion3, lV89Reloj_interface_reloj_codigoidwwds_18_tfcodigoid, AV90Reloj_interface_reloj_codigoidwwds_19_tfcodigoid_sel, lV91Reloj_interface_reloj_codigoidwwds_20_tfreloj_nombre, AV92Reloj_interface_reloj_codigoidwwds_21_tfreloj_nombre_sel, AV93Reloj_interface_reloj_codigoidwwds_22_tflectura_ini, AV94Reloj_interface_reloj_codigoidwwds_23_tflectura_ini_to, lV95Reloj_interface_reloj_codigoidwwds_24_tfrhtrabajadornombres, AV96Reloj_interface_reloj_codigoidwwds_25_tfrhtrabajadornombres_sel, lV97Reloj_interface_reloj_codigoidwwds_26_tfhorariodescripcion, AV98Reloj_interface_reloj_codigoidwwds_27_tfhorariodescripcion_sel, GXPagingFrom2, GXPagingTo2, GXPagingTo2});
            nGXsfl_119_idx = 1;
            sGXsfl_119_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_119_idx), 4, 0), 4, "0");
            SubsflControlProps_1192( ) ;
            while ( ( (pr_default.getStatus(0) != 101) ) && ( ( ( subGrid_Rows == 0 ) || ( GRID_nCurrentRecord < subGrid_fnc_Recordsperpage( ) ) ) ) )
            {
               A2589RHTrabajadorCodigo = H007M2_A2589RHTrabajadorCodigo[0];
               A2498Reloj_ID = H007M2_A2498Reloj_ID[0];
               A2591HorarioID = H007M2_A2591HorarioID[0];
               A2593HorarioDescripcion = H007M2_A2593HorarioDescripcion[0];
               A2590RHTrabajadorNombres = H007M2_A2590RHTrabajadorNombres[0];
               A2415Lectura_Ini = H007M2_A2415Lectura_Ini[0];
               A2592Reloj_Nombre = H007M2_A2592Reloj_Nombre[0];
               A2431CodigoId = H007M2_A2431CodigoId[0];
               A2525TrabApePat = H007M2_A2525TrabApePat[0];
               n2525TrabApePat = H007M2_n2525TrabApePat[0];
               A2526TrabApeMat = H007M2_A2526TrabApeMat[0];
               n2526TrabApeMat = H007M2_n2526TrabApeMat[0];
               A2527TrabNombres = H007M2_A2527TrabNombres[0];
               n2527TrabNombres = H007M2_n2527TrabNombres[0];
               A2525TrabApePat = H007M2_A2525TrabApePat[0];
               n2525TrabApePat = H007M2_n2525TrabApePat[0];
               A2526TrabApeMat = H007M2_A2526TrabApeMat[0];
               n2526TrabApeMat = H007M2_n2526TrabApeMat[0];
               A2527TrabNombres = H007M2_A2527TrabNombres[0];
               n2527TrabNombres = H007M2_n2527TrabNombres[0];
               A2592Reloj_Nombre = H007M2_A2592Reloj_Nombre[0];
               A2593HorarioDescripcion = H007M2_A2593HorarioDescripcion[0];
               E267M2 ();
               pr_default.readNext(0);
            }
            GRID_nEOF = (short)(((pr_default.getStatus(0) == 101) ? 1 : 0));
            GxWebStd.gx_hidden_field( context, "GRID_nEOF", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRID_nEOF), 1, 0, ".", "")));
            pr_default.close(0);
            wbEnd = 119;
            WB7M0( ) ;
         }
         bGXsfl_119_Refreshing = true;
      }

      protected void send_integrity_lvl_hashes7M2( )
      {
         GxWebStd.gx_hidden_field( context, "vPGMNAME", StringUtil.RTrim( AV71Pgmname));
         GxWebStd.gx_hidden_field( context, "gxhash_vPGMNAME", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( AV71Pgmname, "")), context));
         GxWebStd.gx_hidden_field( context, "gxhash_CODIGOID"+"_"+sGXsfl_119_idx, GetSecureSignedToken( sGXsfl_119_idx, StringUtil.RTrim( context.localUtil.Format( A2431CodigoId, "")), context));
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
         AV72Reloj_interface_reloj_codigoidwwds_1_dynamicfiltersselector1 = AV15DynamicFiltersSelector1;
         AV73Reloj_interface_reloj_codigoidwwds_2_dynamicfiltersoperator1 = AV16DynamicFiltersOperator1;
         AV74Reloj_interface_reloj_codigoidwwds_3_rhtrabajadornombres1 = AV17RHTrabajadorNombres1;
         AV75Reloj_interface_reloj_codigoidwwds_4_reloj_nombre1 = AV18Reloj_Nombre1;
         AV76Reloj_interface_reloj_codigoidwwds_5_horariodescripcion1 = AV19HorarioDescripcion1;
         AV77Reloj_interface_reloj_codigoidwwds_6_dynamicfiltersenabled2 = AV20DynamicFiltersEnabled2;
         AV78Reloj_interface_reloj_codigoidwwds_7_dynamicfiltersselector2 = AV21DynamicFiltersSelector2;
         AV79Reloj_interface_reloj_codigoidwwds_8_dynamicfiltersoperator2 = AV22DynamicFiltersOperator2;
         AV80Reloj_interface_reloj_codigoidwwds_9_rhtrabajadornombres2 = AV23RHTrabajadorNombres2;
         AV81Reloj_interface_reloj_codigoidwwds_10_reloj_nombre2 = AV24Reloj_Nombre2;
         AV82Reloj_interface_reloj_codigoidwwds_11_horariodescripcion2 = AV25HorarioDescripcion2;
         AV83Reloj_interface_reloj_codigoidwwds_12_dynamicfiltersenabled3 = AV26DynamicFiltersEnabled3;
         AV84Reloj_interface_reloj_codigoidwwds_13_dynamicfiltersselector3 = AV27DynamicFiltersSelector3;
         AV85Reloj_interface_reloj_codigoidwwds_14_dynamicfiltersoperator3 = AV28DynamicFiltersOperator3;
         AV86Reloj_interface_reloj_codigoidwwds_15_rhtrabajadornombres3 = AV29RHTrabajadorNombres3;
         AV87Reloj_interface_reloj_codigoidwwds_16_reloj_nombre3 = AV30Reloj_Nombre3;
         AV88Reloj_interface_reloj_codigoidwwds_17_horariodescripcion3 = AV31HorarioDescripcion3;
         AV89Reloj_interface_reloj_codigoidwwds_18_tfcodigoid = AV37TFCodigoId;
         AV90Reloj_interface_reloj_codigoidwwds_19_tfcodigoid_sel = AV38TFCodigoId_Sel;
         AV91Reloj_interface_reloj_codigoidwwds_20_tfreloj_nombre = AV41TFReloj_Nombre;
         AV92Reloj_interface_reloj_codigoidwwds_21_tfreloj_nombre_sel = AV42TFReloj_Nombre_Sel;
         AV93Reloj_interface_reloj_codigoidwwds_22_tflectura_ini = AV43TFLectura_Ini;
         AV94Reloj_interface_reloj_codigoidwwds_23_tflectura_ini_to = AV44TFLectura_Ini_To;
         AV95Reloj_interface_reloj_codigoidwwds_24_tfrhtrabajadornombres = AV55TFRHTrabajadorNombres;
         AV96Reloj_interface_reloj_codigoidwwds_25_tfrhtrabajadornombres_sel = AV56TFRHTrabajadorNombres_Sel;
         AV97Reloj_interface_reloj_codigoidwwds_26_tfhorariodescripcion = AV59TFHorarioDescripcion;
         AV98Reloj_interface_reloj_codigoidwwds_27_tfhorariodescripcion_sel = AV60TFHorarioDescripcion_Sel;
         pr_default.dynParam(1, new Object[]{ new Object[]{
                                              AV72Reloj_interface_reloj_codigoidwwds_1_dynamicfiltersselector1 ,
                                              AV73Reloj_interface_reloj_codigoidwwds_2_dynamicfiltersoperator1 ,
                                              AV74Reloj_interface_reloj_codigoidwwds_3_rhtrabajadornombres1 ,
                                              AV75Reloj_interface_reloj_codigoidwwds_4_reloj_nombre1 ,
                                              AV76Reloj_interface_reloj_codigoidwwds_5_horariodescripcion1 ,
                                              AV77Reloj_interface_reloj_codigoidwwds_6_dynamicfiltersenabled2 ,
                                              AV78Reloj_interface_reloj_codigoidwwds_7_dynamicfiltersselector2 ,
                                              AV79Reloj_interface_reloj_codigoidwwds_8_dynamicfiltersoperator2 ,
                                              AV80Reloj_interface_reloj_codigoidwwds_9_rhtrabajadornombres2 ,
                                              AV81Reloj_interface_reloj_codigoidwwds_10_reloj_nombre2 ,
                                              AV82Reloj_interface_reloj_codigoidwwds_11_horariodescripcion2 ,
                                              AV83Reloj_interface_reloj_codigoidwwds_12_dynamicfiltersenabled3 ,
                                              AV84Reloj_interface_reloj_codigoidwwds_13_dynamicfiltersselector3 ,
                                              AV85Reloj_interface_reloj_codigoidwwds_14_dynamicfiltersoperator3 ,
                                              AV86Reloj_interface_reloj_codigoidwwds_15_rhtrabajadornombres3 ,
                                              AV87Reloj_interface_reloj_codigoidwwds_16_reloj_nombre3 ,
                                              AV88Reloj_interface_reloj_codigoidwwds_17_horariodescripcion3 ,
                                              AV90Reloj_interface_reloj_codigoidwwds_19_tfcodigoid_sel ,
                                              AV89Reloj_interface_reloj_codigoidwwds_18_tfcodigoid ,
                                              AV92Reloj_interface_reloj_codigoidwwds_21_tfreloj_nombre_sel ,
                                              AV91Reloj_interface_reloj_codigoidwwds_20_tfreloj_nombre ,
                                              AV93Reloj_interface_reloj_codigoidwwds_22_tflectura_ini ,
                                              AV94Reloj_interface_reloj_codigoidwwds_23_tflectura_ini_to ,
                                              AV96Reloj_interface_reloj_codigoidwwds_25_tfrhtrabajadornombres_sel ,
                                              AV95Reloj_interface_reloj_codigoidwwds_24_tfrhtrabajadornombres ,
                                              AV98Reloj_interface_reloj_codigoidwwds_27_tfhorariodescripcion_sel ,
                                              AV97Reloj_interface_reloj_codigoidwwds_26_tfhorariodescripcion ,
                                              A2525TrabApePat ,
                                              A2526TrabApeMat ,
                                              A2527TrabNombres ,
                                              A2592Reloj_Nombre ,
                                              A2593HorarioDescripcion ,
                                              A2431CodigoId ,
                                              A2415Lectura_Ini ,
                                              AV13OrderedBy ,
                                              AV14OrderedDsc } ,
                                              new int[]{
                                              TypeConstants.SHORT, TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.DATE, TypeConstants.DATE, TypeConstants.BOOLEAN, TypeConstants.BOOLEAN, TypeConstants.BOOLEAN,
                                              TypeConstants.DATE, TypeConstants.SHORT, TypeConstants.BOOLEAN
                                              }
         });
         lV74Reloj_interface_reloj_codigoidwwds_3_rhtrabajadornombres1 = StringUtil.Concat( StringUtil.RTrim( AV74Reloj_interface_reloj_codigoidwwds_3_rhtrabajadornombres1), "%", "");
         lV74Reloj_interface_reloj_codigoidwwds_3_rhtrabajadornombres1 = StringUtil.Concat( StringUtil.RTrim( AV74Reloj_interface_reloj_codigoidwwds_3_rhtrabajadornombres1), "%", "");
         lV75Reloj_interface_reloj_codigoidwwds_4_reloj_nombre1 = StringUtil.Concat( StringUtil.RTrim( AV75Reloj_interface_reloj_codigoidwwds_4_reloj_nombre1), "%", "");
         lV75Reloj_interface_reloj_codigoidwwds_4_reloj_nombre1 = StringUtil.Concat( StringUtil.RTrim( AV75Reloj_interface_reloj_codigoidwwds_4_reloj_nombre1), "%", "");
         lV76Reloj_interface_reloj_codigoidwwds_5_horariodescripcion1 = StringUtil.Concat( StringUtil.RTrim( AV76Reloj_interface_reloj_codigoidwwds_5_horariodescripcion1), "%", "");
         lV76Reloj_interface_reloj_codigoidwwds_5_horariodescripcion1 = StringUtil.Concat( StringUtil.RTrim( AV76Reloj_interface_reloj_codigoidwwds_5_horariodescripcion1), "%", "");
         lV80Reloj_interface_reloj_codigoidwwds_9_rhtrabajadornombres2 = StringUtil.Concat( StringUtil.RTrim( AV80Reloj_interface_reloj_codigoidwwds_9_rhtrabajadornombres2), "%", "");
         lV80Reloj_interface_reloj_codigoidwwds_9_rhtrabajadornombres2 = StringUtil.Concat( StringUtil.RTrim( AV80Reloj_interface_reloj_codigoidwwds_9_rhtrabajadornombres2), "%", "");
         lV81Reloj_interface_reloj_codigoidwwds_10_reloj_nombre2 = StringUtil.Concat( StringUtil.RTrim( AV81Reloj_interface_reloj_codigoidwwds_10_reloj_nombre2), "%", "");
         lV81Reloj_interface_reloj_codigoidwwds_10_reloj_nombre2 = StringUtil.Concat( StringUtil.RTrim( AV81Reloj_interface_reloj_codigoidwwds_10_reloj_nombre2), "%", "");
         lV82Reloj_interface_reloj_codigoidwwds_11_horariodescripcion2 = StringUtil.Concat( StringUtil.RTrim( AV82Reloj_interface_reloj_codigoidwwds_11_horariodescripcion2), "%", "");
         lV82Reloj_interface_reloj_codigoidwwds_11_horariodescripcion2 = StringUtil.Concat( StringUtil.RTrim( AV82Reloj_interface_reloj_codigoidwwds_11_horariodescripcion2), "%", "");
         lV86Reloj_interface_reloj_codigoidwwds_15_rhtrabajadornombres3 = StringUtil.Concat( StringUtil.RTrim( AV86Reloj_interface_reloj_codigoidwwds_15_rhtrabajadornombres3), "%", "");
         lV86Reloj_interface_reloj_codigoidwwds_15_rhtrabajadornombres3 = StringUtil.Concat( StringUtil.RTrim( AV86Reloj_interface_reloj_codigoidwwds_15_rhtrabajadornombres3), "%", "");
         lV87Reloj_interface_reloj_codigoidwwds_16_reloj_nombre3 = StringUtil.Concat( StringUtil.RTrim( AV87Reloj_interface_reloj_codigoidwwds_16_reloj_nombre3), "%", "");
         lV87Reloj_interface_reloj_codigoidwwds_16_reloj_nombre3 = StringUtil.Concat( StringUtil.RTrim( AV87Reloj_interface_reloj_codigoidwwds_16_reloj_nombre3), "%", "");
         lV88Reloj_interface_reloj_codigoidwwds_17_horariodescripcion3 = StringUtil.Concat( StringUtil.RTrim( AV88Reloj_interface_reloj_codigoidwwds_17_horariodescripcion3), "%", "");
         lV88Reloj_interface_reloj_codigoidwwds_17_horariodescripcion3 = StringUtil.Concat( StringUtil.RTrim( AV88Reloj_interface_reloj_codigoidwwds_17_horariodescripcion3), "%", "");
         lV89Reloj_interface_reloj_codigoidwwds_18_tfcodigoid = StringUtil.Concat( StringUtil.RTrim( AV89Reloj_interface_reloj_codigoidwwds_18_tfcodigoid), "%", "");
         lV91Reloj_interface_reloj_codigoidwwds_20_tfreloj_nombre = StringUtil.Concat( StringUtil.RTrim( AV91Reloj_interface_reloj_codigoidwwds_20_tfreloj_nombre), "%", "");
         lV95Reloj_interface_reloj_codigoidwwds_24_tfrhtrabajadornombres = StringUtil.Concat( StringUtil.RTrim( AV95Reloj_interface_reloj_codigoidwwds_24_tfrhtrabajadornombres), "%", "");
         lV97Reloj_interface_reloj_codigoidwwds_26_tfhorariodescripcion = StringUtil.Concat( StringUtil.RTrim( AV97Reloj_interface_reloj_codigoidwwds_26_tfhorariodescripcion), "%", "");
         /* Using cursor H007M3 */
         pr_default.execute(1, new Object[] {lV74Reloj_interface_reloj_codigoidwwds_3_rhtrabajadornombres1, lV74Reloj_interface_reloj_codigoidwwds_3_rhtrabajadornombres1, lV75Reloj_interface_reloj_codigoidwwds_4_reloj_nombre1, lV75Reloj_interface_reloj_codigoidwwds_4_reloj_nombre1, lV76Reloj_interface_reloj_codigoidwwds_5_horariodescripcion1, lV76Reloj_interface_reloj_codigoidwwds_5_horariodescripcion1, lV80Reloj_interface_reloj_codigoidwwds_9_rhtrabajadornombres2, lV80Reloj_interface_reloj_codigoidwwds_9_rhtrabajadornombres2, lV81Reloj_interface_reloj_codigoidwwds_10_reloj_nombre2, lV81Reloj_interface_reloj_codigoidwwds_10_reloj_nombre2, lV82Reloj_interface_reloj_codigoidwwds_11_horariodescripcion2, lV82Reloj_interface_reloj_codigoidwwds_11_horariodescripcion2, lV86Reloj_interface_reloj_codigoidwwds_15_rhtrabajadornombres3, lV86Reloj_interface_reloj_codigoidwwds_15_rhtrabajadornombres3, lV87Reloj_interface_reloj_codigoidwwds_16_reloj_nombre3, lV87Reloj_interface_reloj_codigoidwwds_16_reloj_nombre3, lV88Reloj_interface_reloj_codigoidwwds_17_horariodescripcion3, lV88Reloj_interface_reloj_codigoidwwds_17_horariodescripcion3, lV89Reloj_interface_reloj_codigoidwwds_18_tfcodigoid, AV90Reloj_interface_reloj_codigoidwwds_19_tfcodigoid_sel, lV91Reloj_interface_reloj_codigoidwwds_20_tfreloj_nombre, AV92Reloj_interface_reloj_codigoidwwds_21_tfreloj_nombre_sel, AV93Reloj_interface_reloj_codigoidwwds_22_tflectura_ini, AV94Reloj_interface_reloj_codigoidwwds_23_tflectura_ini_to, lV95Reloj_interface_reloj_codigoidwwds_24_tfrhtrabajadornombres, AV96Reloj_interface_reloj_codigoidwwds_25_tfrhtrabajadornombres_sel, lV97Reloj_interface_reloj_codigoidwwds_26_tfhorariodescripcion, AV98Reloj_interface_reloj_codigoidwwds_27_tfhorariodescripcion_sel});
         GRID_nRecordCount = H007M3_AGRID_nRecordCount[0];
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
         AV72Reloj_interface_reloj_codigoidwwds_1_dynamicfiltersselector1 = AV15DynamicFiltersSelector1;
         AV73Reloj_interface_reloj_codigoidwwds_2_dynamicfiltersoperator1 = AV16DynamicFiltersOperator1;
         AV74Reloj_interface_reloj_codigoidwwds_3_rhtrabajadornombres1 = AV17RHTrabajadorNombres1;
         AV75Reloj_interface_reloj_codigoidwwds_4_reloj_nombre1 = AV18Reloj_Nombre1;
         AV76Reloj_interface_reloj_codigoidwwds_5_horariodescripcion1 = AV19HorarioDescripcion1;
         AV77Reloj_interface_reloj_codigoidwwds_6_dynamicfiltersenabled2 = AV20DynamicFiltersEnabled2;
         AV78Reloj_interface_reloj_codigoidwwds_7_dynamicfiltersselector2 = AV21DynamicFiltersSelector2;
         AV79Reloj_interface_reloj_codigoidwwds_8_dynamicfiltersoperator2 = AV22DynamicFiltersOperator2;
         AV80Reloj_interface_reloj_codigoidwwds_9_rhtrabajadornombres2 = AV23RHTrabajadorNombres2;
         AV81Reloj_interface_reloj_codigoidwwds_10_reloj_nombre2 = AV24Reloj_Nombre2;
         AV82Reloj_interface_reloj_codigoidwwds_11_horariodescripcion2 = AV25HorarioDescripcion2;
         AV83Reloj_interface_reloj_codigoidwwds_12_dynamicfiltersenabled3 = AV26DynamicFiltersEnabled3;
         AV84Reloj_interface_reloj_codigoidwwds_13_dynamicfiltersselector3 = AV27DynamicFiltersSelector3;
         AV85Reloj_interface_reloj_codigoidwwds_14_dynamicfiltersoperator3 = AV28DynamicFiltersOperator3;
         AV86Reloj_interface_reloj_codigoidwwds_15_rhtrabajadornombres3 = AV29RHTrabajadorNombres3;
         AV87Reloj_interface_reloj_codigoidwwds_16_reloj_nombre3 = AV30Reloj_Nombre3;
         AV88Reloj_interface_reloj_codigoidwwds_17_horariodescripcion3 = AV31HorarioDescripcion3;
         AV89Reloj_interface_reloj_codigoidwwds_18_tfcodigoid = AV37TFCodigoId;
         AV90Reloj_interface_reloj_codigoidwwds_19_tfcodigoid_sel = AV38TFCodigoId_Sel;
         AV91Reloj_interface_reloj_codigoidwwds_20_tfreloj_nombre = AV41TFReloj_Nombre;
         AV92Reloj_interface_reloj_codigoidwwds_21_tfreloj_nombre_sel = AV42TFReloj_Nombre_Sel;
         AV93Reloj_interface_reloj_codigoidwwds_22_tflectura_ini = AV43TFLectura_Ini;
         AV94Reloj_interface_reloj_codigoidwwds_23_tflectura_ini_to = AV44TFLectura_Ini_To;
         AV95Reloj_interface_reloj_codigoidwwds_24_tfrhtrabajadornombres = AV55TFRHTrabajadorNombres;
         AV96Reloj_interface_reloj_codigoidwwds_25_tfrhtrabajadornombres_sel = AV56TFRHTrabajadorNombres_Sel;
         AV97Reloj_interface_reloj_codigoidwwds_26_tfhorariodescripcion = AV59TFHorarioDescripcion;
         AV98Reloj_interface_reloj_codigoidwwds_27_tfhorariodescripcion_sel = AV60TFHorarioDescripcion_Sel;
         GRID_nFirstRecordOnPage = 0;
         GxWebStd.gx_hidden_field( context, "GRID_nFirstRecordOnPage", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRID_nFirstRecordOnPage), 15, 0, ".", "")));
         if ( isFullAjaxMode( ) )
         {
            gxgrGrid_refresh( subGrid_Rows, AV15DynamicFiltersSelector1, AV16DynamicFiltersOperator1, AV17RHTrabajadorNombres1, AV18Reloj_Nombre1, AV19HorarioDescripcion1, AV21DynamicFiltersSelector2, AV22DynamicFiltersOperator2, AV23RHTrabajadorNombres2, AV24Reloj_Nombre2, AV25HorarioDescripcion2, AV27DynamicFiltersSelector3, AV28DynamicFiltersOperator3, AV29RHTrabajadorNombres3, AV30Reloj_Nombre3, AV31HorarioDescripcion3, AV20DynamicFiltersEnabled2, AV26DynamicFiltersEnabled3, AV71Pgmname, AV37TFCodigoId, AV38TFCodigoId_Sel, AV41TFReloj_Nombre, AV42TFReloj_Nombre_Sel, AV43TFLectura_Ini, AV44TFLectura_Ini_To, AV55TFRHTrabajadorNombres, AV56TFRHTrabajadorNombres_Sel, AV59TFHorarioDescripcion, AV60TFHorarioDescripcion_Sel, AV13OrderedBy, AV14OrderedDsc, AV10GridState, AV33DynamicFiltersIgnoreFirst, AV32DynamicFiltersRemoving) ;
         }
         send_integrity_footer_hashes( ) ;
         return 0 ;
      }

      protected short subgrid_nextpage( )
      {
         AV72Reloj_interface_reloj_codigoidwwds_1_dynamicfiltersselector1 = AV15DynamicFiltersSelector1;
         AV73Reloj_interface_reloj_codigoidwwds_2_dynamicfiltersoperator1 = AV16DynamicFiltersOperator1;
         AV74Reloj_interface_reloj_codigoidwwds_3_rhtrabajadornombres1 = AV17RHTrabajadorNombres1;
         AV75Reloj_interface_reloj_codigoidwwds_4_reloj_nombre1 = AV18Reloj_Nombre1;
         AV76Reloj_interface_reloj_codigoidwwds_5_horariodescripcion1 = AV19HorarioDescripcion1;
         AV77Reloj_interface_reloj_codigoidwwds_6_dynamicfiltersenabled2 = AV20DynamicFiltersEnabled2;
         AV78Reloj_interface_reloj_codigoidwwds_7_dynamicfiltersselector2 = AV21DynamicFiltersSelector2;
         AV79Reloj_interface_reloj_codigoidwwds_8_dynamicfiltersoperator2 = AV22DynamicFiltersOperator2;
         AV80Reloj_interface_reloj_codigoidwwds_9_rhtrabajadornombres2 = AV23RHTrabajadorNombres2;
         AV81Reloj_interface_reloj_codigoidwwds_10_reloj_nombre2 = AV24Reloj_Nombre2;
         AV82Reloj_interface_reloj_codigoidwwds_11_horariodescripcion2 = AV25HorarioDescripcion2;
         AV83Reloj_interface_reloj_codigoidwwds_12_dynamicfiltersenabled3 = AV26DynamicFiltersEnabled3;
         AV84Reloj_interface_reloj_codigoidwwds_13_dynamicfiltersselector3 = AV27DynamicFiltersSelector3;
         AV85Reloj_interface_reloj_codigoidwwds_14_dynamicfiltersoperator3 = AV28DynamicFiltersOperator3;
         AV86Reloj_interface_reloj_codigoidwwds_15_rhtrabajadornombres3 = AV29RHTrabajadorNombres3;
         AV87Reloj_interface_reloj_codigoidwwds_16_reloj_nombre3 = AV30Reloj_Nombre3;
         AV88Reloj_interface_reloj_codigoidwwds_17_horariodescripcion3 = AV31HorarioDescripcion3;
         AV89Reloj_interface_reloj_codigoidwwds_18_tfcodigoid = AV37TFCodigoId;
         AV90Reloj_interface_reloj_codigoidwwds_19_tfcodigoid_sel = AV38TFCodigoId_Sel;
         AV91Reloj_interface_reloj_codigoidwwds_20_tfreloj_nombre = AV41TFReloj_Nombre;
         AV92Reloj_interface_reloj_codigoidwwds_21_tfreloj_nombre_sel = AV42TFReloj_Nombre_Sel;
         AV93Reloj_interface_reloj_codigoidwwds_22_tflectura_ini = AV43TFLectura_Ini;
         AV94Reloj_interface_reloj_codigoidwwds_23_tflectura_ini_to = AV44TFLectura_Ini_To;
         AV95Reloj_interface_reloj_codigoidwwds_24_tfrhtrabajadornombres = AV55TFRHTrabajadorNombres;
         AV96Reloj_interface_reloj_codigoidwwds_25_tfrhtrabajadornombres_sel = AV56TFRHTrabajadorNombres_Sel;
         AV97Reloj_interface_reloj_codigoidwwds_26_tfhorariodescripcion = AV59TFHorarioDescripcion;
         AV98Reloj_interface_reloj_codigoidwwds_27_tfhorariodescripcion_sel = AV60TFHorarioDescripcion_Sel;
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
            gxgrGrid_refresh( subGrid_Rows, AV15DynamicFiltersSelector1, AV16DynamicFiltersOperator1, AV17RHTrabajadorNombres1, AV18Reloj_Nombre1, AV19HorarioDescripcion1, AV21DynamicFiltersSelector2, AV22DynamicFiltersOperator2, AV23RHTrabajadorNombres2, AV24Reloj_Nombre2, AV25HorarioDescripcion2, AV27DynamicFiltersSelector3, AV28DynamicFiltersOperator3, AV29RHTrabajadorNombres3, AV30Reloj_Nombre3, AV31HorarioDescripcion3, AV20DynamicFiltersEnabled2, AV26DynamicFiltersEnabled3, AV71Pgmname, AV37TFCodigoId, AV38TFCodigoId_Sel, AV41TFReloj_Nombre, AV42TFReloj_Nombre_Sel, AV43TFLectura_Ini, AV44TFLectura_Ini_To, AV55TFRHTrabajadorNombres, AV56TFRHTrabajadorNombres_Sel, AV59TFHorarioDescripcion, AV60TFHorarioDescripcion_Sel, AV13OrderedBy, AV14OrderedDsc, AV10GridState, AV33DynamicFiltersIgnoreFirst, AV32DynamicFiltersRemoving) ;
         }
         send_integrity_footer_hashes( ) ;
         return (short)(((GRID_nEOF==0) ? 0 : 2)) ;
      }

      protected short subgrid_previouspage( )
      {
         AV72Reloj_interface_reloj_codigoidwwds_1_dynamicfiltersselector1 = AV15DynamicFiltersSelector1;
         AV73Reloj_interface_reloj_codigoidwwds_2_dynamicfiltersoperator1 = AV16DynamicFiltersOperator1;
         AV74Reloj_interface_reloj_codigoidwwds_3_rhtrabajadornombres1 = AV17RHTrabajadorNombres1;
         AV75Reloj_interface_reloj_codigoidwwds_4_reloj_nombre1 = AV18Reloj_Nombre1;
         AV76Reloj_interface_reloj_codigoidwwds_5_horariodescripcion1 = AV19HorarioDescripcion1;
         AV77Reloj_interface_reloj_codigoidwwds_6_dynamicfiltersenabled2 = AV20DynamicFiltersEnabled2;
         AV78Reloj_interface_reloj_codigoidwwds_7_dynamicfiltersselector2 = AV21DynamicFiltersSelector2;
         AV79Reloj_interface_reloj_codigoidwwds_8_dynamicfiltersoperator2 = AV22DynamicFiltersOperator2;
         AV80Reloj_interface_reloj_codigoidwwds_9_rhtrabajadornombres2 = AV23RHTrabajadorNombres2;
         AV81Reloj_interface_reloj_codigoidwwds_10_reloj_nombre2 = AV24Reloj_Nombre2;
         AV82Reloj_interface_reloj_codigoidwwds_11_horariodescripcion2 = AV25HorarioDescripcion2;
         AV83Reloj_interface_reloj_codigoidwwds_12_dynamicfiltersenabled3 = AV26DynamicFiltersEnabled3;
         AV84Reloj_interface_reloj_codigoidwwds_13_dynamicfiltersselector3 = AV27DynamicFiltersSelector3;
         AV85Reloj_interface_reloj_codigoidwwds_14_dynamicfiltersoperator3 = AV28DynamicFiltersOperator3;
         AV86Reloj_interface_reloj_codigoidwwds_15_rhtrabajadornombres3 = AV29RHTrabajadorNombres3;
         AV87Reloj_interface_reloj_codigoidwwds_16_reloj_nombre3 = AV30Reloj_Nombre3;
         AV88Reloj_interface_reloj_codigoidwwds_17_horariodescripcion3 = AV31HorarioDescripcion3;
         AV89Reloj_interface_reloj_codigoidwwds_18_tfcodigoid = AV37TFCodigoId;
         AV90Reloj_interface_reloj_codigoidwwds_19_tfcodigoid_sel = AV38TFCodigoId_Sel;
         AV91Reloj_interface_reloj_codigoidwwds_20_tfreloj_nombre = AV41TFReloj_Nombre;
         AV92Reloj_interface_reloj_codigoidwwds_21_tfreloj_nombre_sel = AV42TFReloj_Nombre_Sel;
         AV93Reloj_interface_reloj_codigoidwwds_22_tflectura_ini = AV43TFLectura_Ini;
         AV94Reloj_interface_reloj_codigoidwwds_23_tflectura_ini_to = AV44TFLectura_Ini_To;
         AV95Reloj_interface_reloj_codigoidwwds_24_tfrhtrabajadornombres = AV55TFRHTrabajadorNombres;
         AV96Reloj_interface_reloj_codigoidwwds_25_tfrhtrabajadornombres_sel = AV56TFRHTrabajadorNombres_Sel;
         AV97Reloj_interface_reloj_codigoidwwds_26_tfhorariodescripcion = AV59TFHorarioDescripcion;
         AV98Reloj_interface_reloj_codigoidwwds_27_tfhorariodescripcion_sel = AV60TFHorarioDescripcion_Sel;
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
            gxgrGrid_refresh( subGrid_Rows, AV15DynamicFiltersSelector1, AV16DynamicFiltersOperator1, AV17RHTrabajadorNombres1, AV18Reloj_Nombre1, AV19HorarioDescripcion1, AV21DynamicFiltersSelector2, AV22DynamicFiltersOperator2, AV23RHTrabajadorNombres2, AV24Reloj_Nombre2, AV25HorarioDescripcion2, AV27DynamicFiltersSelector3, AV28DynamicFiltersOperator3, AV29RHTrabajadorNombres3, AV30Reloj_Nombre3, AV31HorarioDescripcion3, AV20DynamicFiltersEnabled2, AV26DynamicFiltersEnabled3, AV71Pgmname, AV37TFCodigoId, AV38TFCodigoId_Sel, AV41TFReloj_Nombre, AV42TFReloj_Nombre_Sel, AV43TFLectura_Ini, AV44TFLectura_Ini_To, AV55TFRHTrabajadorNombres, AV56TFRHTrabajadorNombres_Sel, AV59TFHorarioDescripcion, AV60TFHorarioDescripcion_Sel, AV13OrderedBy, AV14OrderedDsc, AV10GridState, AV33DynamicFiltersIgnoreFirst, AV32DynamicFiltersRemoving) ;
         }
         send_integrity_footer_hashes( ) ;
         return 0 ;
      }

      protected short subgrid_lastpage( )
      {
         AV72Reloj_interface_reloj_codigoidwwds_1_dynamicfiltersselector1 = AV15DynamicFiltersSelector1;
         AV73Reloj_interface_reloj_codigoidwwds_2_dynamicfiltersoperator1 = AV16DynamicFiltersOperator1;
         AV74Reloj_interface_reloj_codigoidwwds_3_rhtrabajadornombres1 = AV17RHTrabajadorNombres1;
         AV75Reloj_interface_reloj_codigoidwwds_4_reloj_nombre1 = AV18Reloj_Nombre1;
         AV76Reloj_interface_reloj_codigoidwwds_5_horariodescripcion1 = AV19HorarioDescripcion1;
         AV77Reloj_interface_reloj_codigoidwwds_6_dynamicfiltersenabled2 = AV20DynamicFiltersEnabled2;
         AV78Reloj_interface_reloj_codigoidwwds_7_dynamicfiltersselector2 = AV21DynamicFiltersSelector2;
         AV79Reloj_interface_reloj_codigoidwwds_8_dynamicfiltersoperator2 = AV22DynamicFiltersOperator2;
         AV80Reloj_interface_reloj_codigoidwwds_9_rhtrabajadornombres2 = AV23RHTrabajadorNombres2;
         AV81Reloj_interface_reloj_codigoidwwds_10_reloj_nombre2 = AV24Reloj_Nombre2;
         AV82Reloj_interface_reloj_codigoidwwds_11_horariodescripcion2 = AV25HorarioDescripcion2;
         AV83Reloj_interface_reloj_codigoidwwds_12_dynamicfiltersenabled3 = AV26DynamicFiltersEnabled3;
         AV84Reloj_interface_reloj_codigoidwwds_13_dynamicfiltersselector3 = AV27DynamicFiltersSelector3;
         AV85Reloj_interface_reloj_codigoidwwds_14_dynamicfiltersoperator3 = AV28DynamicFiltersOperator3;
         AV86Reloj_interface_reloj_codigoidwwds_15_rhtrabajadornombres3 = AV29RHTrabajadorNombres3;
         AV87Reloj_interface_reloj_codigoidwwds_16_reloj_nombre3 = AV30Reloj_Nombre3;
         AV88Reloj_interface_reloj_codigoidwwds_17_horariodescripcion3 = AV31HorarioDescripcion3;
         AV89Reloj_interface_reloj_codigoidwwds_18_tfcodigoid = AV37TFCodigoId;
         AV90Reloj_interface_reloj_codigoidwwds_19_tfcodigoid_sel = AV38TFCodigoId_Sel;
         AV91Reloj_interface_reloj_codigoidwwds_20_tfreloj_nombre = AV41TFReloj_Nombre;
         AV92Reloj_interface_reloj_codigoidwwds_21_tfreloj_nombre_sel = AV42TFReloj_Nombre_Sel;
         AV93Reloj_interface_reloj_codigoidwwds_22_tflectura_ini = AV43TFLectura_Ini;
         AV94Reloj_interface_reloj_codigoidwwds_23_tflectura_ini_to = AV44TFLectura_Ini_To;
         AV95Reloj_interface_reloj_codigoidwwds_24_tfrhtrabajadornombres = AV55TFRHTrabajadorNombres;
         AV96Reloj_interface_reloj_codigoidwwds_25_tfrhtrabajadornombres_sel = AV56TFRHTrabajadorNombres_Sel;
         AV97Reloj_interface_reloj_codigoidwwds_26_tfhorariodescripcion = AV59TFHorarioDescripcion;
         AV98Reloj_interface_reloj_codigoidwwds_27_tfhorariodescripcion_sel = AV60TFHorarioDescripcion_Sel;
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
            gxgrGrid_refresh( subGrid_Rows, AV15DynamicFiltersSelector1, AV16DynamicFiltersOperator1, AV17RHTrabajadorNombres1, AV18Reloj_Nombre1, AV19HorarioDescripcion1, AV21DynamicFiltersSelector2, AV22DynamicFiltersOperator2, AV23RHTrabajadorNombres2, AV24Reloj_Nombre2, AV25HorarioDescripcion2, AV27DynamicFiltersSelector3, AV28DynamicFiltersOperator3, AV29RHTrabajadorNombres3, AV30Reloj_Nombre3, AV31HorarioDescripcion3, AV20DynamicFiltersEnabled2, AV26DynamicFiltersEnabled3, AV71Pgmname, AV37TFCodigoId, AV38TFCodigoId_Sel, AV41TFReloj_Nombre, AV42TFReloj_Nombre_Sel, AV43TFLectura_Ini, AV44TFLectura_Ini_To, AV55TFRHTrabajadorNombres, AV56TFRHTrabajadorNombres_Sel, AV59TFHorarioDescripcion, AV60TFHorarioDescripcion_Sel, AV13OrderedBy, AV14OrderedDsc, AV10GridState, AV33DynamicFiltersIgnoreFirst, AV32DynamicFiltersRemoving) ;
         }
         send_integrity_footer_hashes( ) ;
         return 0 ;
      }

      protected int subgrid_gotopage( int nPageNo )
      {
         AV72Reloj_interface_reloj_codigoidwwds_1_dynamicfiltersselector1 = AV15DynamicFiltersSelector1;
         AV73Reloj_interface_reloj_codigoidwwds_2_dynamicfiltersoperator1 = AV16DynamicFiltersOperator1;
         AV74Reloj_interface_reloj_codigoidwwds_3_rhtrabajadornombres1 = AV17RHTrabajadorNombres1;
         AV75Reloj_interface_reloj_codigoidwwds_4_reloj_nombre1 = AV18Reloj_Nombre1;
         AV76Reloj_interface_reloj_codigoidwwds_5_horariodescripcion1 = AV19HorarioDescripcion1;
         AV77Reloj_interface_reloj_codigoidwwds_6_dynamicfiltersenabled2 = AV20DynamicFiltersEnabled2;
         AV78Reloj_interface_reloj_codigoidwwds_7_dynamicfiltersselector2 = AV21DynamicFiltersSelector2;
         AV79Reloj_interface_reloj_codigoidwwds_8_dynamicfiltersoperator2 = AV22DynamicFiltersOperator2;
         AV80Reloj_interface_reloj_codigoidwwds_9_rhtrabajadornombres2 = AV23RHTrabajadorNombres2;
         AV81Reloj_interface_reloj_codigoidwwds_10_reloj_nombre2 = AV24Reloj_Nombre2;
         AV82Reloj_interface_reloj_codigoidwwds_11_horariodescripcion2 = AV25HorarioDescripcion2;
         AV83Reloj_interface_reloj_codigoidwwds_12_dynamicfiltersenabled3 = AV26DynamicFiltersEnabled3;
         AV84Reloj_interface_reloj_codigoidwwds_13_dynamicfiltersselector3 = AV27DynamicFiltersSelector3;
         AV85Reloj_interface_reloj_codigoidwwds_14_dynamicfiltersoperator3 = AV28DynamicFiltersOperator3;
         AV86Reloj_interface_reloj_codigoidwwds_15_rhtrabajadornombres3 = AV29RHTrabajadorNombres3;
         AV87Reloj_interface_reloj_codigoidwwds_16_reloj_nombre3 = AV30Reloj_Nombre3;
         AV88Reloj_interface_reloj_codigoidwwds_17_horariodescripcion3 = AV31HorarioDescripcion3;
         AV89Reloj_interface_reloj_codigoidwwds_18_tfcodigoid = AV37TFCodigoId;
         AV90Reloj_interface_reloj_codigoidwwds_19_tfcodigoid_sel = AV38TFCodigoId_Sel;
         AV91Reloj_interface_reloj_codigoidwwds_20_tfreloj_nombre = AV41TFReloj_Nombre;
         AV92Reloj_interface_reloj_codigoidwwds_21_tfreloj_nombre_sel = AV42TFReloj_Nombre_Sel;
         AV93Reloj_interface_reloj_codigoidwwds_22_tflectura_ini = AV43TFLectura_Ini;
         AV94Reloj_interface_reloj_codigoidwwds_23_tflectura_ini_to = AV44TFLectura_Ini_To;
         AV95Reloj_interface_reloj_codigoidwwds_24_tfrhtrabajadornombres = AV55TFRHTrabajadorNombres;
         AV96Reloj_interface_reloj_codigoidwwds_25_tfrhtrabajadornombres_sel = AV56TFRHTrabajadorNombres_Sel;
         AV97Reloj_interface_reloj_codigoidwwds_26_tfhorariodescripcion = AV59TFHorarioDescripcion;
         AV98Reloj_interface_reloj_codigoidwwds_27_tfhorariodescripcion_sel = AV60TFHorarioDescripcion_Sel;
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
            gxgrGrid_refresh( subGrid_Rows, AV15DynamicFiltersSelector1, AV16DynamicFiltersOperator1, AV17RHTrabajadorNombres1, AV18Reloj_Nombre1, AV19HorarioDescripcion1, AV21DynamicFiltersSelector2, AV22DynamicFiltersOperator2, AV23RHTrabajadorNombres2, AV24Reloj_Nombre2, AV25HorarioDescripcion2, AV27DynamicFiltersSelector3, AV28DynamicFiltersOperator3, AV29RHTrabajadorNombres3, AV30Reloj_Nombre3, AV31HorarioDescripcion3, AV20DynamicFiltersEnabled2, AV26DynamicFiltersEnabled3, AV71Pgmname, AV37TFCodigoId, AV38TFCodigoId_Sel, AV41TFReloj_Nombre, AV42TFReloj_Nombre_Sel, AV43TFLectura_Ini, AV44TFLectura_Ini_To, AV55TFRHTrabajadorNombres, AV56TFRHTrabajadorNombres_Sel, AV59TFHorarioDescripcion, AV60TFHorarioDescripcion_Sel, AV13OrderedBy, AV14OrderedDsc, AV10GridState, AV33DynamicFiltersIgnoreFirst, AV32DynamicFiltersRemoving) ;
         }
         send_integrity_footer_hashes( ) ;
         return (int)(0) ;
      }

      protected void before_start_formulas( )
      {
         AV71Pgmname = "Reloj_Interface.Reloj_CodigoIDWW";
         context.Gx_err = 0;
         fix_multi_value_controls( ) ;
      }

      protected void STRUP7M0( )
      {
         /* Before Start, stand alone formulas. */
         before_start_formulas( ) ;
         /* Execute Start event if defined. */
         context.wbGlbDoneStart = 0;
         /* Execute user event: Start */
         E247M2 ();
         context.wbGlbDoneStart = 1;
         /* After Start, stand alone formulas. */
         if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
         {
            /* Read saved SDTs. */
            ajax_req_read_hidden_sdt(cgiGet( "vAGEXPORTDATA"), AV67AGExportData);
            ajax_req_read_hidden_sdt(cgiGet( "vDDO_TITLESETTINGSICONS"), AV61DDO_TitleSettingsIcons);
            /* Read saved values. */
            nRC_GXsfl_119 = (int)(context.localUtil.CToN( cgiGet( "nRC_GXsfl_119"), ".", ","));
            AV63GridCurrentPage = (long)(context.localUtil.CToN( cgiGet( "vGRIDCURRENTPAGE"), ".", ","));
            AV64GridPageCount = (long)(context.localUtil.CToN( cgiGet( "vGRIDPAGECOUNT"), ".", ","));
            AV65GridAppliedFilters = cgiGet( "vGRIDAPPLIEDFILTERS");
            AV45DDO_Lectura_IniAuxDate = context.localUtil.CToD( cgiGet( "vDDO_LECTURA_INIAUXDATE"), 0);
            AV46DDO_Lectura_IniAuxDateTo = context.localUtil.CToD( cgiGet( "vDDO_LECTURA_INIAUXDATETO"), 0);
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
            AV17RHTrabajadorNombres1 = cgiGet( edtavRhtrabajadornombres1_Internalname);
            AssignAttri("", false, "AV17RHTrabajadorNombres1", AV17RHTrabajadorNombres1);
            AV18Reloj_Nombre1 = cgiGet( edtavReloj_nombre1_Internalname);
            AssignAttri("", false, "AV18Reloj_Nombre1", AV18Reloj_Nombre1);
            AV19HorarioDescripcion1 = cgiGet( edtavHorariodescripcion1_Internalname);
            AssignAttri("", false, "AV19HorarioDescripcion1", AV19HorarioDescripcion1);
            cmbavDynamicfiltersselector2.Name = cmbavDynamicfiltersselector2_Internalname;
            cmbavDynamicfiltersselector2.CurrentValue = cgiGet( cmbavDynamicfiltersselector2_Internalname);
            AV21DynamicFiltersSelector2 = cgiGet( cmbavDynamicfiltersselector2_Internalname);
            AssignAttri("", false, "AV21DynamicFiltersSelector2", AV21DynamicFiltersSelector2);
            cmbavDynamicfiltersoperator2.Name = cmbavDynamicfiltersoperator2_Internalname;
            cmbavDynamicfiltersoperator2.CurrentValue = cgiGet( cmbavDynamicfiltersoperator2_Internalname);
            AV22DynamicFiltersOperator2 = (short)(NumberUtil.Val( cgiGet( cmbavDynamicfiltersoperator2_Internalname), "."));
            AssignAttri("", false, "AV22DynamicFiltersOperator2", StringUtil.LTrimStr( (decimal)(AV22DynamicFiltersOperator2), 4, 0));
            AV23RHTrabajadorNombres2 = cgiGet( edtavRhtrabajadornombres2_Internalname);
            AssignAttri("", false, "AV23RHTrabajadorNombres2", AV23RHTrabajadorNombres2);
            AV24Reloj_Nombre2 = cgiGet( edtavReloj_nombre2_Internalname);
            AssignAttri("", false, "AV24Reloj_Nombre2", AV24Reloj_Nombre2);
            AV25HorarioDescripcion2 = cgiGet( edtavHorariodescripcion2_Internalname);
            AssignAttri("", false, "AV25HorarioDescripcion2", AV25HorarioDescripcion2);
            cmbavDynamicfiltersselector3.Name = cmbavDynamicfiltersselector3_Internalname;
            cmbavDynamicfiltersselector3.CurrentValue = cgiGet( cmbavDynamicfiltersselector3_Internalname);
            AV27DynamicFiltersSelector3 = cgiGet( cmbavDynamicfiltersselector3_Internalname);
            AssignAttri("", false, "AV27DynamicFiltersSelector3", AV27DynamicFiltersSelector3);
            cmbavDynamicfiltersoperator3.Name = cmbavDynamicfiltersoperator3_Internalname;
            cmbavDynamicfiltersoperator3.CurrentValue = cgiGet( cmbavDynamicfiltersoperator3_Internalname);
            AV28DynamicFiltersOperator3 = (short)(NumberUtil.Val( cgiGet( cmbavDynamicfiltersoperator3_Internalname), "."));
            AssignAttri("", false, "AV28DynamicFiltersOperator3", StringUtil.LTrimStr( (decimal)(AV28DynamicFiltersOperator3), 4, 0));
            AV29RHTrabajadorNombres3 = cgiGet( edtavRhtrabajadornombres3_Internalname);
            AssignAttri("", false, "AV29RHTrabajadorNombres3", AV29RHTrabajadorNombres3);
            AV30Reloj_Nombre3 = cgiGet( edtavReloj_nombre3_Internalname);
            AssignAttri("", false, "AV30Reloj_Nombre3", AV30Reloj_Nombre3);
            AV31HorarioDescripcion3 = cgiGet( edtavHorariodescripcion3_Internalname);
            AssignAttri("", false, "AV31HorarioDescripcion3", AV31HorarioDescripcion3);
            AV47DDO_Lectura_IniAuxDateText = cgiGet( edtavDdo_lectura_iniauxdatetext_Internalname);
            AssignAttri("", false, "AV47DDO_Lectura_IniAuxDateText", AV47DDO_Lectura_IniAuxDateText);
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
            if ( StringUtil.StrCmp(cgiGet( "GXH_vRHTRABAJADORNOMBRES1"), AV17RHTrabajadorNombres1) != 0 )
            {
               GRID_nFirstRecordOnPage = 0;
            }
            if ( StringUtil.StrCmp(cgiGet( "GXH_vRELOJ_NOMBRE1"), AV18Reloj_Nombre1) != 0 )
            {
               GRID_nFirstRecordOnPage = 0;
            }
            if ( StringUtil.StrCmp(cgiGet( "GXH_vHORARIODESCRIPCION1"), AV19HorarioDescripcion1) != 0 )
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
            if ( StringUtil.StrCmp(cgiGet( "GXH_vRHTRABAJADORNOMBRES2"), AV23RHTrabajadorNombres2) != 0 )
            {
               GRID_nFirstRecordOnPage = 0;
            }
            if ( StringUtil.StrCmp(cgiGet( "GXH_vRELOJ_NOMBRE2"), AV24Reloj_Nombre2) != 0 )
            {
               GRID_nFirstRecordOnPage = 0;
            }
            if ( StringUtil.StrCmp(cgiGet( "GXH_vHORARIODESCRIPCION2"), AV25HorarioDescripcion2) != 0 )
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
            if ( StringUtil.StrCmp(cgiGet( "GXH_vRHTRABAJADORNOMBRES3"), AV29RHTrabajadorNombres3) != 0 )
            {
               GRID_nFirstRecordOnPage = 0;
            }
            if ( StringUtil.StrCmp(cgiGet( "GXH_vRELOJ_NOMBRE3"), AV30Reloj_Nombre3) != 0 )
            {
               GRID_nFirstRecordOnPage = 0;
            }
            if ( StringUtil.StrCmp(cgiGet( "GXH_vHORARIODESCRIPCION3"), AV31HorarioDescripcion3) != 0 )
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
         E247M2 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
      }

      protected void E247M2( )
      {
         /* Start Routine */
         returnInSub = false;
         this.executeUsercontrolMethod("", false, "TFLECTURA_INI_RANGEPICKERContainer", "Attach", "", new Object[] {(string)edtavDdo_lectura_iniauxdatetext_Internalname});
         subGrid_Rows = 10;
         GxWebStd.gx_hidden_field( context, "GRID_Rows", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid_Rows), 6, 0, ".", "")));
         Grid_empowerer_Gridinternalname = subGrid_Internalname;
         ucGrid_empowerer.SendProperty(context, "", false, Grid_empowerer_Internalname, "GridInternalName", Grid_empowerer_Gridinternalname);
         lblJsdynamicfilters_Caption = "";
         AssignProp("", false, lblJsdynamicfilters_Internalname, "Caption", lblJsdynamicfilters_Caption, true);
         AV15DynamicFiltersSelector1 = "RHTRABAJADORNOMBRES";
         AssignAttri("", false, "AV15DynamicFiltersSelector1", AV15DynamicFiltersSelector1);
         /* Execute user subroutine: 'ENABLEDYNAMICFILTERS1' */
         S112 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
         AV21DynamicFiltersSelector2 = "RHTRABAJADORNOMBRES";
         AssignAttri("", false, "AV21DynamicFiltersSelector2", AV21DynamicFiltersSelector2);
         /* Execute user subroutine: 'ENABLEDYNAMICFILTERS2' */
         S122 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
         AV27DynamicFiltersSelector3 = "RHTRABAJADORNOMBRES";
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
         AV67AGExportData = new GXBaseCollection<GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTDropDownOptionsData_Item>( context, "Item", "");
         AV68AGExportDataItem = new GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTDropDownOptionsData_Item(context);
         AV68AGExportDataItem.gxTpr_Title = "PDF";
         AV68AGExportDataItem.gxTpr_Icon = context.convertURL( (string)(context.GetImagePath( "776fb79c-a0a1-4302-b5e5-d773dbe1a297", "", context.GetTheme( ))));
         AV68AGExportDataItem.gxTpr_Eventkey = "ExportReport";
         AV68AGExportDataItem.gxTpr_Isdivider = false;
         AV67AGExportData.Add(AV68AGExportDataItem, 0);
         AV68AGExportDataItem = new GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTDropDownOptionsData_Item(context);
         AV68AGExportDataItem.gxTpr_Title = "Excel";
         AV68AGExportDataItem.gxTpr_Icon = context.convertURL( (string)(context.GetImagePath( "da69a816-fd11-445b-8aaf-1a2f7f1acc93", "", context.GetTheme( ))));
         AV68AGExportDataItem.gxTpr_Eventkey = "Export";
         AV68AGExportDataItem.gxTpr_Isdivider = false;
         AV67AGExportData.Add(AV68AGExportDataItem, 0);
         Ddo_grid_Gridinternalname = subGrid_Internalname;
         ucDdo_grid.SendProperty(context, "", false, Ddo_grid_Internalname, "GridInternalName", Ddo_grid_Gridinternalname);
         Form.Caption = "Codigos Registrados en Reloj";
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
         GXt_SdtDVB_SDTDropDownOptionsTitleSettingsIcons1 = AV61DDO_TitleSettingsIcons;
         new GeneXus.Programs.wwpbaseobjects.getwwptitlesettingsicons(context ).execute( out  GXt_SdtDVB_SDTDropDownOptionsTitleSettingsIcons1) ;
         AV61DDO_TitleSettingsIcons = GXt_SdtDVB_SDTDropDownOptionsTitleSettingsIcons1;
         Gridpaginationbar_Rowsperpageselectedvalue = subGrid_Rows;
         ucGridpaginationbar.SendProperty(context, "", false, Gridpaginationbar_Internalname, "RowsPerPageSelectedValue", StringUtil.LTrimStr( (decimal)(Gridpaginationbar_Rowsperpageselectedvalue), 9, 0));
      }

      protected void E257M2( )
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
         if ( StringUtil.StrCmp(AV15DynamicFiltersSelector1, "RHTRABAJADORNOMBRES") == 0 )
         {
            cmbavDynamicfiltersoperator1.addItem("0", "Comienza con", 0);
            cmbavDynamicfiltersoperator1.addItem("1", "Contiene", 0);
         }
         else if ( StringUtil.StrCmp(AV15DynamicFiltersSelector1, "RELOJ_NOMBRE") == 0 )
         {
            cmbavDynamicfiltersoperator1.addItem("0", "Comienza con", 0);
            cmbavDynamicfiltersoperator1.addItem("1", "Contiene", 0);
         }
         else if ( StringUtil.StrCmp(AV15DynamicFiltersSelector1, "HORARIODESCRIPCION") == 0 )
         {
            cmbavDynamicfiltersoperator1.addItem("0", "Comienza con", 0);
            cmbavDynamicfiltersoperator1.addItem("1", "Contiene", 0);
         }
         if ( AV20DynamicFiltersEnabled2 )
         {
            cmbavDynamicfiltersoperator2.removeAllItems();
            if ( StringUtil.StrCmp(AV21DynamicFiltersSelector2, "RHTRABAJADORNOMBRES") == 0 )
            {
               cmbavDynamicfiltersoperator2.addItem("0", "Comienza con", 0);
               cmbavDynamicfiltersoperator2.addItem("1", "Contiene", 0);
            }
            else if ( StringUtil.StrCmp(AV21DynamicFiltersSelector2, "RELOJ_NOMBRE") == 0 )
            {
               cmbavDynamicfiltersoperator2.addItem("0", "Comienza con", 0);
               cmbavDynamicfiltersoperator2.addItem("1", "Contiene", 0);
            }
            else if ( StringUtil.StrCmp(AV21DynamicFiltersSelector2, "HORARIODESCRIPCION") == 0 )
            {
               cmbavDynamicfiltersoperator2.addItem("0", "Comienza con", 0);
               cmbavDynamicfiltersoperator2.addItem("1", "Contiene", 0);
            }
            if ( AV26DynamicFiltersEnabled3 )
            {
               cmbavDynamicfiltersoperator3.removeAllItems();
               if ( StringUtil.StrCmp(AV27DynamicFiltersSelector3, "RHTRABAJADORNOMBRES") == 0 )
               {
                  cmbavDynamicfiltersoperator3.addItem("0", "Comienza con", 0);
                  cmbavDynamicfiltersoperator3.addItem("1", "Contiene", 0);
               }
               else if ( StringUtil.StrCmp(AV27DynamicFiltersSelector3, "RELOJ_NOMBRE") == 0 )
               {
                  cmbavDynamicfiltersoperator3.addItem("0", "Comienza con", 0);
                  cmbavDynamicfiltersoperator3.addItem("1", "Contiene", 0);
               }
               else if ( StringUtil.StrCmp(AV27DynamicFiltersSelector3, "HORARIODESCRIPCION") == 0 )
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
         AV63GridCurrentPage = subGrid_fnc_Currentpage( );
         AssignAttri("", false, "AV63GridCurrentPage", StringUtil.LTrimStr( (decimal)(AV63GridCurrentPage), 10, 0));
         AV64GridPageCount = subGrid_fnc_Pagecount( );
         AssignAttri("", false, "AV64GridPageCount", StringUtil.LTrimStr( (decimal)(AV64GridPageCount), 10, 0));
         GXt_char2 = AV65GridAppliedFilters;
         new GeneXus.Programs.wwpbaseobjects.wwp_getappliedfiltersdescription(context ).execute(  AV71Pgmname, out  GXt_char2) ;
         AV65GridAppliedFilters = GXt_char2;
         AssignAttri("", false, "AV65GridAppliedFilters", AV65GridAppliedFilters);
         AV72Reloj_interface_reloj_codigoidwwds_1_dynamicfiltersselector1 = AV15DynamicFiltersSelector1;
         AV73Reloj_interface_reloj_codigoidwwds_2_dynamicfiltersoperator1 = AV16DynamicFiltersOperator1;
         AV74Reloj_interface_reloj_codigoidwwds_3_rhtrabajadornombres1 = AV17RHTrabajadorNombres1;
         AV75Reloj_interface_reloj_codigoidwwds_4_reloj_nombre1 = AV18Reloj_Nombre1;
         AV76Reloj_interface_reloj_codigoidwwds_5_horariodescripcion1 = AV19HorarioDescripcion1;
         AV77Reloj_interface_reloj_codigoidwwds_6_dynamicfiltersenabled2 = AV20DynamicFiltersEnabled2;
         AV78Reloj_interface_reloj_codigoidwwds_7_dynamicfiltersselector2 = AV21DynamicFiltersSelector2;
         AV79Reloj_interface_reloj_codigoidwwds_8_dynamicfiltersoperator2 = AV22DynamicFiltersOperator2;
         AV80Reloj_interface_reloj_codigoidwwds_9_rhtrabajadornombres2 = AV23RHTrabajadorNombres2;
         AV81Reloj_interface_reloj_codigoidwwds_10_reloj_nombre2 = AV24Reloj_Nombre2;
         AV82Reloj_interface_reloj_codigoidwwds_11_horariodescripcion2 = AV25HorarioDescripcion2;
         AV83Reloj_interface_reloj_codigoidwwds_12_dynamicfiltersenabled3 = AV26DynamicFiltersEnabled3;
         AV84Reloj_interface_reloj_codigoidwwds_13_dynamicfiltersselector3 = AV27DynamicFiltersSelector3;
         AV85Reloj_interface_reloj_codigoidwwds_14_dynamicfiltersoperator3 = AV28DynamicFiltersOperator3;
         AV86Reloj_interface_reloj_codigoidwwds_15_rhtrabajadornombres3 = AV29RHTrabajadorNombres3;
         AV87Reloj_interface_reloj_codigoidwwds_16_reloj_nombre3 = AV30Reloj_Nombre3;
         AV88Reloj_interface_reloj_codigoidwwds_17_horariodescripcion3 = AV31HorarioDescripcion3;
         AV89Reloj_interface_reloj_codigoidwwds_18_tfcodigoid = AV37TFCodigoId;
         AV90Reloj_interface_reloj_codigoidwwds_19_tfcodigoid_sel = AV38TFCodigoId_Sel;
         AV91Reloj_interface_reloj_codigoidwwds_20_tfreloj_nombre = AV41TFReloj_Nombre;
         AV92Reloj_interface_reloj_codigoidwwds_21_tfreloj_nombre_sel = AV42TFReloj_Nombre_Sel;
         AV93Reloj_interface_reloj_codigoidwwds_22_tflectura_ini = AV43TFLectura_Ini;
         AV94Reloj_interface_reloj_codigoidwwds_23_tflectura_ini_to = AV44TFLectura_Ini_To;
         AV95Reloj_interface_reloj_codigoidwwds_24_tfrhtrabajadornombres = AV55TFRHTrabajadorNombres;
         AV96Reloj_interface_reloj_codigoidwwds_25_tfrhtrabajadornombres_sel = AV56TFRHTrabajadorNombres_Sel;
         AV97Reloj_interface_reloj_codigoidwwds_26_tfhorariodescripcion = AV59TFHorarioDescripcion;
         AV98Reloj_interface_reloj_codigoidwwds_27_tfhorariodescripcion_sel = AV60TFHorarioDescripcion_Sel;
         /*  Sending Event outputs  */
         cmbavDynamicfiltersoperator1.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV16DynamicFiltersOperator1), 4, 0));
         AssignProp("", false, cmbavDynamicfiltersoperator1_Internalname, "Values", cmbavDynamicfiltersoperator1.ToJavascriptSource(), true);
         cmbavDynamicfiltersoperator2.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV22DynamicFiltersOperator2), 4, 0));
         AssignProp("", false, cmbavDynamicfiltersoperator2_Internalname, "Values", cmbavDynamicfiltersoperator2.ToJavascriptSource(), true);
         cmbavDynamicfiltersoperator3.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV28DynamicFiltersOperator3), 4, 0));
         AssignProp("", false, cmbavDynamicfiltersoperator3_Internalname, "Values", cmbavDynamicfiltersoperator3.ToJavascriptSource(), true);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV10GridState", AV10GridState);
      }

      protected void E117M2( )
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
            AV62PageToGo = (int)(NumberUtil.Val( Gridpaginationbar_Selectedpage, "."));
            subgrid_gotopage( AV62PageToGo) ;
         }
      }

      protected void E127M2( )
      {
         /* Gridpaginationbar_Changerowsperpage Routine */
         returnInSub = false;
         subGrid_Rows = Gridpaginationbar_Rowsperpageselectedvalue;
         GxWebStd.gx_hidden_field( context, "GRID_Rows", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid_Rows), 6, 0, ".", "")));
         subgrid_firstpage( ) ;
         /*  Sending Event outputs  */
      }

      protected void E147M2( )
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
            if ( StringUtil.StrCmp(Ddo_grid_Selectedcolumn, "CodigoId") == 0 )
            {
               AV37TFCodigoId = Ddo_grid_Filteredtext_get;
               AssignAttri("", false, "AV37TFCodigoId", AV37TFCodigoId);
               AV38TFCodigoId_Sel = Ddo_grid_Selectedvalue_get;
               AssignAttri("", false, "AV38TFCodigoId_Sel", AV38TFCodigoId_Sel);
            }
            else if ( StringUtil.StrCmp(Ddo_grid_Selectedcolumn, "Reloj_Nombre") == 0 )
            {
               AV41TFReloj_Nombre = Ddo_grid_Filteredtext_get;
               AssignAttri("", false, "AV41TFReloj_Nombre", AV41TFReloj_Nombre);
               AV42TFReloj_Nombre_Sel = Ddo_grid_Selectedvalue_get;
               AssignAttri("", false, "AV42TFReloj_Nombre_Sel", AV42TFReloj_Nombre_Sel);
            }
            else if ( StringUtil.StrCmp(Ddo_grid_Selectedcolumn, "Lectura_Ini") == 0 )
            {
               AV43TFLectura_Ini = context.localUtil.CToT( Ddo_grid_Filteredtext_get, 2);
               AssignAttri("", false, "AV43TFLectura_Ini", context.localUtil.TToC( AV43TFLectura_Ini, 10, 8, 0, 3, "/", ":", " "));
               AV44TFLectura_Ini_To = context.localUtil.CToT( Ddo_grid_Filteredtextto_get, 2);
               AssignAttri("", false, "AV44TFLectura_Ini_To", context.localUtil.TToC( AV44TFLectura_Ini_To, 10, 8, 0, 3, "/", ":", " "));
               if ( ! (DateTime.MinValue==AV44TFLectura_Ini_To) )
               {
                  AV44TFLectura_Ini_To = context.localUtil.YMDHMSToT( (short)(DateTimeUtil.Year( AV44TFLectura_Ini_To)), (short)(DateTimeUtil.Month( AV44TFLectura_Ini_To)), (short)(DateTimeUtil.Day( AV44TFLectura_Ini_To)), 23, 59, 59);
                  AssignAttri("", false, "AV44TFLectura_Ini_To", context.localUtil.TToC( AV44TFLectura_Ini_To, 10, 8, 0, 3, "/", ":", " "));
               }
            }
            else if ( StringUtil.StrCmp(Ddo_grid_Selectedcolumn, "RHTrabajadorNombres") == 0 )
            {
               AV55TFRHTrabajadorNombres = Ddo_grid_Filteredtext_get;
               AssignAttri("", false, "AV55TFRHTrabajadorNombres", AV55TFRHTrabajadorNombres);
               AV56TFRHTrabajadorNombres_Sel = Ddo_grid_Selectedvalue_get;
               AssignAttri("", false, "AV56TFRHTrabajadorNombres_Sel", AV56TFRHTrabajadorNombres_Sel);
            }
            else if ( StringUtil.StrCmp(Ddo_grid_Selectedcolumn, "HorarioDescripcion") == 0 )
            {
               AV59TFHorarioDescripcion = Ddo_grid_Filteredtext_get;
               AssignAttri("", false, "AV59TFHorarioDescripcion", AV59TFHorarioDescripcion);
               AV60TFHorarioDescripcion_Sel = Ddo_grid_Selectedvalue_get;
               AssignAttri("", false, "AV60TFHorarioDescripcion_Sel", AV60TFHorarioDescripcion_Sel);
            }
            subgrid_firstpage( ) ;
         }
         /*  Sending Event outputs  */
      }

      private void E267M2( )
      {
         /* Grid_Load Routine */
         returnInSub = false;
         cmbavGridactions.removeAllItems();
         cmbavGridactions.addItem("0", ";fa fa-bars", 0);
         cmbavGridactions.addItem("1", StringUtil.Format( "%1;%2", "Modificar", "fa fa-pen", "", "", "", "", "", "", ""), 0);
         cmbavGridactions.addItem("2", StringUtil.Format( "%1;%2", "Eliminar", "fa fa-times", "", "", "", "", "", "", ""), 0);
         GXKey = Crypto.GetSiteKey( );
         GXEncryptionTmp = "reloj_interface.reloj.aspx"+UrlEncode(StringUtil.RTrim("DSP")) + "," + UrlEncode(StringUtil.LTrimStr(A2498Reloj_ID,4,0));
         edtReloj_Nombre_Link = formatLink("reloj_interface.reloj.aspx") + "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey);
         GXKey = Crypto.GetSiteKey( );
         GXEncryptionTmp = "reloj_interface.reloj_codigoid.aspx"+UrlEncode(StringUtil.RTrim("DSP")) + "," + UrlEncode(StringUtil.RTrim(A2431CodigoId));
         edtRHTrabajadorNombres_Link = formatLink("reloj_interface.reloj_codigoid.aspx") + "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey);
         GXKey = Crypto.GetSiteKey( );
         GXEncryptionTmp = "reloj_interface.reloj_horario.aspx"+UrlEncode(StringUtil.RTrim("DSP")) + "," + UrlEncode(StringUtil.LTrimStr(A2591HorarioID,4,0));
         edtHorarioDescripcion_Link = formatLink("reloj_interface.reloj_horario.aspx") + "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey);
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
         cmbavGridactions.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV66GridActions), 4, 0));
      }

      protected void E197M2( )
      {
         /* 'AddDynamicFilters1' Routine */
         returnInSub = false;
         AV20DynamicFiltersEnabled2 = true;
         AssignAttri("", false, "AV20DynamicFiltersEnabled2", AV20DynamicFiltersEnabled2);
         imgAdddynamicfilters1_Visible = 0;
         AssignProp("", false, imgAdddynamicfilters1_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(imgAdddynamicfilters1_Visible), 5, 0), true);
         imgRemovedynamicfilters1_Visible = 1;
         AssignProp("", false, imgRemovedynamicfilters1_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(imgRemovedynamicfilters1_Visible), 5, 0), true);
         gxgrGrid_refresh( subGrid_Rows, AV15DynamicFiltersSelector1, AV16DynamicFiltersOperator1, AV17RHTrabajadorNombres1, AV18Reloj_Nombre1, AV19HorarioDescripcion1, AV21DynamicFiltersSelector2, AV22DynamicFiltersOperator2, AV23RHTrabajadorNombres2, AV24Reloj_Nombre2, AV25HorarioDescripcion2, AV27DynamicFiltersSelector3, AV28DynamicFiltersOperator3, AV29RHTrabajadorNombres3, AV30Reloj_Nombre3, AV31HorarioDescripcion3, AV20DynamicFiltersEnabled2, AV26DynamicFiltersEnabled3, AV71Pgmname, AV37TFCodigoId, AV38TFCodigoId_Sel, AV41TFReloj_Nombre, AV42TFReloj_Nombre_Sel, AV43TFLectura_Ini, AV44TFLectura_Ini_To, AV55TFRHTrabajadorNombres, AV56TFRHTrabajadorNombres_Sel, AV59TFHorarioDescripcion, AV60TFHorarioDescripcion_Sel, AV13OrderedBy, AV14OrderedDsc, AV10GridState, AV33DynamicFiltersIgnoreFirst, AV32DynamicFiltersRemoving) ;
         /*  Sending Event outputs  */
         cmbavDynamicfiltersoperator1.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV16DynamicFiltersOperator1), 4, 0));
         AssignProp("", false, cmbavDynamicfiltersoperator1_Internalname, "Values", cmbavDynamicfiltersoperator1.ToJavascriptSource(), true);
         cmbavDynamicfiltersoperator2.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV22DynamicFiltersOperator2), 4, 0));
         AssignProp("", false, cmbavDynamicfiltersoperator2_Internalname, "Values", cmbavDynamicfiltersoperator2.ToJavascriptSource(), true);
         cmbavDynamicfiltersoperator3.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV28DynamicFiltersOperator3), 4, 0));
         AssignProp("", false, cmbavDynamicfiltersoperator3_Internalname, "Values", cmbavDynamicfiltersoperator3.ToJavascriptSource(), true);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV10GridState", AV10GridState);
      }

      protected void E157M2( )
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
         gxgrGrid_refresh( subGrid_Rows, AV15DynamicFiltersSelector1, AV16DynamicFiltersOperator1, AV17RHTrabajadorNombres1, AV18Reloj_Nombre1, AV19HorarioDescripcion1, AV21DynamicFiltersSelector2, AV22DynamicFiltersOperator2, AV23RHTrabajadorNombres2, AV24Reloj_Nombre2, AV25HorarioDescripcion2, AV27DynamicFiltersSelector3, AV28DynamicFiltersOperator3, AV29RHTrabajadorNombres3, AV30Reloj_Nombre3, AV31HorarioDescripcion3, AV20DynamicFiltersEnabled2, AV26DynamicFiltersEnabled3, AV71Pgmname, AV37TFCodigoId, AV38TFCodigoId_Sel, AV41TFReloj_Nombre, AV42TFReloj_Nombre_Sel, AV43TFLectura_Ini, AV44TFLectura_Ini_To, AV55TFRHTrabajadorNombres, AV56TFRHTrabajadorNombres_Sel, AV59TFHorarioDescripcion, AV60TFHorarioDescripcion_Sel, AV13OrderedBy, AV14OrderedDsc, AV10GridState, AV33DynamicFiltersIgnoreFirst, AV32DynamicFiltersRemoving) ;
         /*  Sending Event outputs  */
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV10GridState", AV10GridState);
         cmbavDynamicfiltersselector2.CurrentValue = StringUtil.RTrim( AV21DynamicFiltersSelector2);
         AssignProp("", false, cmbavDynamicfiltersselector2_Internalname, "Values", cmbavDynamicfiltersselector2.ToJavascriptSource(), true);
         cmbavDynamicfiltersoperator2.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV22DynamicFiltersOperator2), 4, 0));
         AssignProp("", false, cmbavDynamicfiltersoperator2_Internalname, "Values", cmbavDynamicfiltersoperator2.ToJavascriptSource(), true);
         cmbavDynamicfiltersselector3.CurrentValue = StringUtil.RTrim( AV27DynamicFiltersSelector3);
         AssignProp("", false, cmbavDynamicfiltersselector3_Internalname, "Values", cmbavDynamicfiltersselector3.ToJavascriptSource(), true);
         cmbavDynamicfiltersoperator3.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV28DynamicFiltersOperator3), 4, 0));
         AssignProp("", false, cmbavDynamicfiltersoperator3_Internalname, "Values", cmbavDynamicfiltersoperator3.ToJavascriptSource(), true);
         cmbavDynamicfiltersselector1.CurrentValue = StringUtil.RTrim( AV15DynamicFiltersSelector1);
         AssignProp("", false, cmbavDynamicfiltersselector1_Internalname, "Values", cmbavDynamicfiltersselector1.ToJavascriptSource(), true);
         cmbavDynamicfiltersoperator1.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV16DynamicFiltersOperator1), 4, 0));
         AssignProp("", false, cmbavDynamicfiltersoperator1_Internalname, "Values", cmbavDynamicfiltersoperator1.ToJavascriptSource(), true);
      }

      protected void E207M2( )
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

      protected void E217M2( )
      {
         /* 'AddDynamicFilters2' Routine */
         returnInSub = false;
         AV26DynamicFiltersEnabled3 = true;
         AssignAttri("", false, "AV26DynamicFiltersEnabled3", AV26DynamicFiltersEnabled3);
         imgAdddynamicfilters2_Visible = 0;
         AssignProp("", false, imgAdddynamicfilters2_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(imgAdddynamicfilters2_Visible), 5, 0), true);
         imgRemovedynamicfilters2_Visible = 1;
         AssignProp("", false, imgRemovedynamicfilters2_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(imgRemovedynamicfilters2_Visible), 5, 0), true);
         gxgrGrid_refresh( subGrid_Rows, AV15DynamicFiltersSelector1, AV16DynamicFiltersOperator1, AV17RHTrabajadorNombres1, AV18Reloj_Nombre1, AV19HorarioDescripcion1, AV21DynamicFiltersSelector2, AV22DynamicFiltersOperator2, AV23RHTrabajadorNombres2, AV24Reloj_Nombre2, AV25HorarioDescripcion2, AV27DynamicFiltersSelector3, AV28DynamicFiltersOperator3, AV29RHTrabajadorNombres3, AV30Reloj_Nombre3, AV31HorarioDescripcion3, AV20DynamicFiltersEnabled2, AV26DynamicFiltersEnabled3, AV71Pgmname, AV37TFCodigoId, AV38TFCodigoId_Sel, AV41TFReloj_Nombre, AV42TFReloj_Nombre_Sel, AV43TFLectura_Ini, AV44TFLectura_Ini_To, AV55TFRHTrabajadorNombres, AV56TFRHTrabajadorNombres_Sel, AV59TFHorarioDescripcion, AV60TFHorarioDescripcion_Sel, AV13OrderedBy, AV14OrderedDsc, AV10GridState, AV33DynamicFiltersIgnoreFirst, AV32DynamicFiltersRemoving) ;
         /*  Sending Event outputs  */
         cmbavDynamicfiltersoperator1.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV16DynamicFiltersOperator1), 4, 0));
         AssignProp("", false, cmbavDynamicfiltersoperator1_Internalname, "Values", cmbavDynamicfiltersoperator1.ToJavascriptSource(), true);
         cmbavDynamicfiltersoperator2.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV22DynamicFiltersOperator2), 4, 0));
         AssignProp("", false, cmbavDynamicfiltersoperator2_Internalname, "Values", cmbavDynamicfiltersoperator2.ToJavascriptSource(), true);
         cmbavDynamicfiltersoperator3.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV28DynamicFiltersOperator3), 4, 0));
         AssignProp("", false, cmbavDynamicfiltersoperator3_Internalname, "Values", cmbavDynamicfiltersoperator3.ToJavascriptSource(), true);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV10GridState", AV10GridState);
      }

      protected void E167M2( )
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
         gxgrGrid_refresh( subGrid_Rows, AV15DynamicFiltersSelector1, AV16DynamicFiltersOperator1, AV17RHTrabajadorNombres1, AV18Reloj_Nombre1, AV19HorarioDescripcion1, AV21DynamicFiltersSelector2, AV22DynamicFiltersOperator2, AV23RHTrabajadorNombres2, AV24Reloj_Nombre2, AV25HorarioDescripcion2, AV27DynamicFiltersSelector3, AV28DynamicFiltersOperator3, AV29RHTrabajadorNombres3, AV30Reloj_Nombre3, AV31HorarioDescripcion3, AV20DynamicFiltersEnabled2, AV26DynamicFiltersEnabled3, AV71Pgmname, AV37TFCodigoId, AV38TFCodigoId_Sel, AV41TFReloj_Nombre, AV42TFReloj_Nombre_Sel, AV43TFLectura_Ini, AV44TFLectura_Ini_To, AV55TFRHTrabajadorNombres, AV56TFRHTrabajadorNombres_Sel, AV59TFHorarioDescripcion, AV60TFHorarioDescripcion_Sel, AV13OrderedBy, AV14OrderedDsc, AV10GridState, AV33DynamicFiltersIgnoreFirst, AV32DynamicFiltersRemoving) ;
         /*  Sending Event outputs  */
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV10GridState", AV10GridState);
         cmbavDynamicfiltersselector2.CurrentValue = StringUtil.RTrim( AV21DynamicFiltersSelector2);
         AssignProp("", false, cmbavDynamicfiltersselector2_Internalname, "Values", cmbavDynamicfiltersselector2.ToJavascriptSource(), true);
         cmbavDynamicfiltersoperator2.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV22DynamicFiltersOperator2), 4, 0));
         AssignProp("", false, cmbavDynamicfiltersoperator2_Internalname, "Values", cmbavDynamicfiltersoperator2.ToJavascriptSource(), true);
         cmbavDynamicfiltersselector3.CurrentValue = StringUtil.RTrim( AV27DynamicFiltersSelector3);
         AssignProp("", false, cmbavDynamicfiltersselector3_Internalname, "Values", cmbavDynamicfiltersselector3.ToJavascriptSource(), true);
         cmbavDynamicfiltersoperator3.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV28DynamicFiltersOperator3), 4, 0));
         AssignProp("", false, cmbavDynamicfiltersoperator3_Internalname, "Values", cmbavDynamicfiltersoperator3.ToJavascriptSource(), true);
         cmbavDynamicfiltersselector1.CurrentValue = StringUtil.RTrim( AV15DynamicFiltersSelector1);
         AssignProp("", false, cmbavDynamicfiltersselector1_Internalname, "Values", cmbavDynamicfiltersselector1.ToJavascriptSource(), true);
         cmbavDynamicfiltersoperator1.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV16DynamicFiltersOperator1), 4, 0));
         AssignProp("", false, cmbavDynamicfiltersoperator1_Internalname, "Values", cmbavDynamicfiltersoperator1.ToJavascriptSource(), true);
      }

      protected void E227M2( )
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

      protected void E177M2( )
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
         gxgrGrid_refresh( subGrid_Rows, AV15DynamicFiltersSelector1, AV16DynamicFiltersOperator1, AV17RHTrabajadorNombres1, AV18Reloj_Nombre1, AV19HorarioDescripcion1, AV21DynamicFiltersSelector2, AV22DynamicFiltersOperator2, AV23RHTrabajadorNombres2, AV24Reloj_Nombre2, AV25HorarioDescripcion2, AV27DynamicFiltersSelector3, AV28DynamicFiltersOperator3, AV29RHTrabajadorNombres3, AV30Reloj_Nombre3, AV31HorarioDescripcion3, AV20DynamicFiltersEnabled2, AV26DynamicFiltersEnabled3, AV71Pgmname, AV37TFCodigoId, AV38TFCodigoId_Sel, AV41TFReloj_Nombre, AV42TFReloj_Nombre_Sel, AV43TFLectura_Ini, AV44TFLectura_Ini_To, AV55TFRHTrabajadorNombres, AV56TFRHTrabajadorNombres_Sel, AV59TFHorarioDescripcion, AV60TFHorarioDescripcion_Sel, AV13OrderedBy, AV14OrderedDsc, AV10GridState, AV33DynamicFiltersIgnoreFirst, AV32DynamicFiltersRemoving) ;
         /*  Sending Event outputs  */
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV10GridState", AV10GridState);
         cmbavDynamicfiltersselector2.CurrentValue = StringUtil.RTrim( AV21DynamicFiltersSelector2);
         AssignProp("", false, cmbavDynamicfiltersselector2_Internalname, "Values", cmbavDynamicfiltersselector2.ToJavascriptSource(), true);
         cmbavDynamicfiltersoperator2.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV22DynamicFiltersOperator2), 4, 0));
         AssignProp("", false, cmbavDynamicfiltersoperator2_Internalname, "Values", cmbavDynamicfiltersoperator2.ToJavascriptSource(), true);
         cmbavDynamicfiltersselector3.CurrentValue = StringUtil.RTrim( AV27DynamicFiltersSelector3);
         AssignProp("", false, cmbavDynamicfiltersselector3_Internalname, "Values", cmbavDynamicfiltersselector3.ToJavascriptSource(), true);
         cmbavDynamicfiltersoperator3.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV28DynamicFiltersOperator3), 4, 0));
         AssignProp("", false, cmbavDynamicfiltersoperator3_Internalname, "Values", cmbavDynamicfiltersoperator3.ToJavascriptSource(), true);
         cmbavDynamicfiltersselector1.CurrentValue = StringUtil.RTrim( AV15DynamicFiltersSelector1);
         AssignProp("", false, cmbavDynamicfiltersselector1_Internalname, "Values", cmbavDynamicfiltersselector1.ToJavascriptSource(), true);
         cmbavDynamicfiltersoperator1.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV16DynamicFiltersOperator1), 4, 0));
         AssignProp("", false, cmbavDynamicfiltersoperator1_Internalname, "Values", cmbavDynamicfiltersoperator1.ToJavascriptSource(), true);
      }

      protected void E237M2( )
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

      protected void E277M2( )
      {
         /* Gridactions_Click Routine */
         returnInSub = false;
         if ( AV66GridActions == 1 )
         {
            /* Execute user subroutine: 'DO UPDATE' */
            S212 ();
            if ( returnInSub )
            {
               returnInSub = true;
               if (true) return;
            }
         }
         else if ( AV66GridActions == 2 )
         {
            /* Execute user subroutine: 'DO DELETE' */
            S222 ();
            if ( returnInSub )
            {
               returnInSub = true;
               if (true) return;
            }
         }
         AV66GridActions = 0;
         AssignAttri("", false, cmbavGridactions_Internalname, StringUtil.LTrimStr( (decimal)(AV66GridActions), 4, 0));
         /*  Sending Event outputs  */
         cmbavGridactions.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV66GridActions), 4, 0));
         AssignProp("", false, cmbavGridactions_Internalname, "Values", cmbavGridactions.ToJavascriptSource(), true);
      }

      protected void E187M2( )
      {
         /* 'DoInsert' Routine */
         returnInSub = false;
         GXKey = Crypto.GetSiteKey( );
         GXEncryptionTmp = "reloj_interface.reloj_codigoid.aspx"+UrlEncode(StringUtil.RTrim("INS")) + "," + UrlEncode(StringUtil.RTrim(""));
         CallWebObject(formatLink("reloj_interface.reloj_codigoid.aspx") + "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey));
         context.wjLocDisableFrm = 1;
      }

      protected void E137M2( )
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
         cmbavDynamicfiltersselector2.CurrentValue = StringUtil.RTrim( AV21DynamicFiltersSelector2);
         AssignProp("", false, cmbavDynamicfiltersselector2_Internalname, "Values", cmbavDynamicfiltersselector2.ToJavascriptSource(), true);
         cmbavDynamicfiltersoperator2.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV22DynamicFiltersOperator2), 4, 0));
         AssignProp("", false, cmbavDynamicfiltersoperator2_Internalname, "Values", cmbavDynamicfiltersoperator2.ToJavascriptSource(), true);
         cmbavDynamicfiltersselector3.CurrentValue = StringUtil.RTrim( AV27DynamicFiltersSelector3);
         AssignProp("", false, cmbavDynamicfiltersselector3_Internalname, "Values", cmbavDynamicfiltersselector3.ToJavascriptSource(), true);
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
         edtavRhtrabajadornombres1_Visible = 0;
         AssignProp("", false, edtavRhtrabajadornombres1_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavRhtrabajadornombres1_Visible), 5, 0), true);
         edtavReloj_nombre1_Visible = 0;
         AssignProp("", false, edtavReloj_nombre1_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavReloj_nombre1_Visible), 5, 0), true);
         edtavHorariodescripcion1_Visible = 0;
         AssignProp("", false, edtavHorariodescripcion1_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavHorariodescripcion1_Visible), 5, 0), true);
         cmbavDynamicfiltersoperator1.Visible = 0;
         AssignProp("", false, cmbavDynamicfiltersoperator1_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(cmbavDynamicfiltersoperator1.Visible), 5, 0), true);
         if ( StringUtil.StrCmp(AV15DynamicFiltersSelector1, "RHTRABAJADORNOMBRES") == 0 )
         {
            edtavRhtrabajadornombres1_Visible = 1;
            AssignProp("", false, edtavRhtrabajadornombres1_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavRhtrabajadornombres1_Visible), 5, 0), true);
            cmbavDynamicfiltersoperator1.Visible = 1;
            AssignProp("", false, cmbavDynamicfiltersoperator1_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(cmbavDynamicfiltersoperator1.Visible), 5, 0), true);
         }
         else if ( StringUtil.StrCmp(AV15DynamicFiltersSelector1, "RELOJ_NOMBRE") == 0 )
         {
            edtavReloj_nombre1_Visible = 1;
            AssignProp("", false, edtavReloj_nombre1_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavReloj_nombre1_Visible), 5, 0), true);
            cmbavDynamicfiltersoperator1.Visible = 1;
            AssignProp("", false, cmbavDynamicfiltersoperator1_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(cmbavDynamicfiltersoperator1.Visible), 5, 0), true);
         }
         else if ( StringUtil.StrCmp(AV15DynamicFiltersSelector1, "HORARIODESCRIPCION") == 0 )
         {
            edtavHorariodescripcion1_Visible = 1;
            AssignProp("", false, edtavHorariodescripcion1_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavHorariodescripcion1_Visible), 5, 0), true);
            cmbavDynamicfiltersoperator1.Visible = 1;
            AssignProp("", false, cmbavDynamicfiltersoperator1_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(cmbavDynamicfiltersoperator1.Visible), 5, 0), true);
         }
      }

      protected void S122( )
      {
         /* 'ENABLEDYNAMICFILTERS2' Routine */
         returnInSub = false;
         edtavRhtrabajadornombres2_Visible = 0;
         AssignProp("", false, edtavRhtrabajadornombres2_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavRhtrabajadornombres2_Visible), 5, 0), true);
         edtavReloj_nombre2_Visible = 0;
         AssignProp("", false, edtavReloj_nombre2_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavReloj_nombre2_Visible), 5, 0), true);
         edtavHorariodescripcion2_Visible = 0;
         AssignProp("", false, edtavHorariodescripcion2_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavHorariodescripcion2_Visible), 5, 0), true);
         cmbavDynamicfiltersoperator2.Visible = 0;
         AssignProp("", false, cmbavDynamicfiltersoperator2_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(cmbavDynamicfiltersoperator2.Visible), 5, 0), true);
         if ( StringUtil.StrCmp(AV21DynamicFiltersSelector2, "RHTRABAJADORNOMBRES") == 0 )
         {
            edtavRhtrabajadornombres2_Visible = 1;
            AssignProp("", false, edtavRhtrabajadornombres2_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavRhtrabajadornombres2_Visible), 5, 0), true);
            cmbavDynamicfiltersoperator2.Visible = 1;
            AssignProp("", false, cmbavDynamicfiltersoperator2_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(cmbavDynamicfiltersoperator2.Visible), 5, 0), true);
         }
         else if ( StringUtil.StrCmp(AV21DynamicFiltersSelector2, "RELOJ_NOMBRE") == 0 )
         {
            edtavReloj_nombre2_Visible = 1;
            AssignProp("", false, edtavReloj_nombre2_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavReloj_nombre2_Visible), 5, 0), true);
            cmbavDynamicfiltersoperator2.Visible = 1;
            AssignProp("", false, cmbavDynamicfiltersoperator2_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(cmbavDynamicfiltersoperator2.Visible), 5, 0), true);
         }
         else if ( StringUtil.StrCmp(AV21DynamicFiltersSelector2, "HORARIODESCRIPCION") == 0 )
         {
            edtavHorariodescripcion2_Visible = 1;
            AssignProp("", false, edtavHorariodescripcion2_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavHorariodescripcion2_Visible), 5, 0), true);
            cmbavDynamicfiltersoperator2.Visible = 1;
            AssignProp("", false, cmbavDynamicfiltersoperator2_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(cmbavDynamicfiltersoperator2.Visible), 5, 0), true);
         }
      }

      protected void S132( )
      {
         /* 'ENABLEDYNAMICFILTERS3' Routine */
         returnInSub = false;
         edtavRhtrabajadornombres3_Visible = 0;
         AssignProp("", false, edtavRhtrabajadornombres3_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavRhtrabajadornombres3_Visible), 5, 0), true);
         edtavReloj_nombre3_Visible = 0;
         AssignProp("", false, edtavReloj_nombre3_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavReloj_nombre3_Visible), 5, 0), true);
         edtavHorariodescripcion3_Visible = 0;
         AssignProp("", false, edtavHorariodescripcion3_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavHorariodescripcion3_Visible), 5, 0), true);
         cmbavDynamicfiltersoperator3.Visible = 0;
         AssignProp("", false, cmbavDynamicfiltersoperator3_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(cmbavDynamicfiltersoperator3.Visible), 5, 0), true);
         if ( StringUtil.StrCmp(AV27DynamicFiltersSelector3, "RHTRABAJADORNOMBRES") == 0 )
         {
            edtavRhtrabajadornombres3_Visible = 1;
            AssignProp("", false, edtavRhtrabajadornombres3_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavRhtrabajadornombres3_Visible), 5, 0), true);
            cmbavDynamicfiltersoperator3.Visible = 1;
            AssignProp("", false, cmbavDynamicfiltersoperator3_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(cmbavDynamicfiltersoperator3.Visible), 5, 0), true);
         }
         else if ( StringUtil.StrCmp(AV27DynamicFiltersSelector3, "RELOJ_NOMBRE") == 0 )
         {
            edtavReloj_nombre3_Visible = 1;
            AssignProp("", false, edtavReloj_nombre3_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavReloj_nombre3_Visible), 5, 0), true);
            cmbavDynamicfiltersoperator3.Visible = 1;
            AssignProp("", false, cmbavDynamicfiltersoperator3_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(cmbavDynamicfiltersoperator3.Visible), 5, 0), true);
         }
         else if ( StringUtil.StrCmp(AV27DynamicFiltersSelector3, "HORARIODESCRIPCION") == 0 )
         {
            edtavHorariodescripcion3_Visible = 1;
            AssignProp("", false, edtavHorariodescripcion3_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavHorariodescripcion3_Visible), 5, 0), true);
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
         AV21DynamicFiltersSelector2 = "RHTRABAJADORNOMBRES";
         AssignAttri("", false, "AV21DynamicFiltersSelector2", AV21DynamicFiltersSelector2);
         AV22DynamicFiltersOperator2 = 0;
         AssignAttri("", false, "AV22DynamicFiltersOperator2", StringUtil.LTrimStr( (decimal)(AV22DynamicFiltersOperator2), 4, 0));
         AV23RHTrabajadorNombres2 = "";
         AssignAttri("", false, "AV23RHTrabajadorNombres2", AV23RHTrabajadorNombres2);
         /* Execute user subroutine: 'ENABLEDYNAMICFILTERS2' */
         S122 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
         AV26DynamicFiltersEnabled3 = false;
         AssignAttri("", false, "AV26DynamicFiltersEnabled3", AV26DynamicFiltersEnabled3);
         AV27DynamicFiltersSelector3 = "RHTRABAJADORNOMBRES";
         AssignAttri("", false, "AV27DynamicFiltersSelector3", AV27DynamicFiltersSelector3);
         AV28DynamicFiltersOperator3 = 0;
         AssignAttri("", false, "AV28DynamicFiltersOperator3", StringUtil.LTrimStr( (decimal)(AV28DynamicFiltersOperator3), 4, 0));
         AV29RHTrabajadorNombres3 = "";
         AssignAttri("", false, "AV29RHTrabajadorNombres3", AV29RHTrabajadorNombres3);
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
         GXEncryptionTmp = "reloj_interface.reloj_codigoid.aspx"+UrlEncode(StringUtil.RTrim("UPD")) + "," + UrlEncode(StringUtil.RTrim(A2431CodigoId));
         CallWebObject(formatLink("reloj_interface.reloj_codigoid.aspx") + "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey));
         context.wjLocDisableFrm = 1;
      }

      protected void S222( )
      {
         /* 'DO DELETE' Routine */
         returnInSub = false;
         GXKey = Crypto.GetSiteKey( );
         GXEncryptionTmp = "reloj_interface.reloj_codigoid.aspx"+UrlEncode(StringUtil.RTrim("DLT")) + "," + UrlEncode(StringUtil.RTrim(A2431CodigoId));
         CallWebObject(formatLink("reloj_interface.reloj_codigoid.aspx") + "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey));
         context.wjLocDisableFrm = 1;
      }

      protected void S152( )
      {
         /* 'LOADGRIDSTATE' Routine */
         returnInSub = false;
         if ( StringUtil.StrCmp(AV36Session.Get(AV71Pgmname+"GridState"), "") == 0 )
         {
            AV10GridState.FromXml(new GeneXus.Programs.wwpbaseobjects.loadgridstate(context).executeUdp(  AV71Pgmname+"GridState"), null, "", "");
         }
         else
         {
            AV10GridState.FromXml(AV36Session.Get(AV71Pgmname+"GridState"), null, "", "");
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
         AV99GXV1 = 1;
         while ( AV99GXV1 <= AV10GridState.gxTpr_Filtervalues.Count )
         {
            AV11GridStateFilterValue = ((GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue)AV10GridState.gxTpr_Filtervalues.Item(AV99GXV1));
            if ( StringUtil.StrCmp(AV11GridStateFilterValue.gxTpr_Name, "TFCODIGOID") == 0 )
            {
               AV37TFCodigoId = AV11GridStateFilterValue.gxTpr_Value;
               AssignAttri("", false, "AV37TFCodigoId", AV37TFCodigoId);
            }
            else if ( StringUtil.StrCmp(AV11GridStateFilterValue.gxTpr_Name, "TFCODIGOID_SEL") == 0 )
            {
               AV38TFCodigoId_Sel = AV11GridStateFilterValue.gxTpr_Value;
               AssignAttri("", false, "AV38TFCodigoId_Sel", AV38TFCodigoId_Sel);
            }
            else if ( StringUtil.StrCmp(AV11GridStateFilterValue.gxTpr_Name, "TFRELOJ_NOMBRE") == 0 )
            {
               AV41TFReloj_Nombre = AV11GridStateFilterValue.gxTpr_Value;
               AssignAttri("", false, "AV41TFReloj_Nombre", AV41TFReloj_Nombre);
            }
            else if ( StringUtil.StrCmp(AV11GridStateFilterValue.gxTpr_Name, "TFRELOJ_NOMBRE_SEL") == 0 )
            {
               AV42TFReloj_Nombre_Sel = AV11GridStateFilterValue.gxTpr_Value;
               AssignAttri("", false, "AV42TFReloj_Nombre_Sel", AV42TFReloj_Nombre_Sel);
            }
            else if ( StringUtil.StrCmp(AV11GridStateFilterValue.gxTpr_Name, "TFLECTURA_INI") == 0 )
            {
               AV43TFLectura_Ini = context.localUtil.CToT( AV11GridStateFilterValue.gxTpr_Value, 2);
               AssignAttri("", false, "AV43TFLectura_Ini", context.localUtil.TToC( AV43TFLectura_Ini, 10, 8, 0, 3, "/", ":", " "));
               AV44TFLectura_Ini_To = context.localUtil.CToT( AV11GridStateFilterValue.gxTpr_Valueto, 2);
               AssignAttri("", false, "AV44TFLectura_Ini_To", context.localUtil.TToC( AV44TFLectura_Ini_To, 10, 8, 0, 3, "/", ":", " "));
               AV45DDO_Lectura_IniAuxDate = DateTimeUtil.ResetTime(AV43TFLectura_Ini);
               AssignAttri("", false, "AV45DDO_Lectura_IniAuxDate", context.localUtil.Format(AV45DDO_Lectura_IniAuxDate, "99/99/9999"));
               AV46DDO_Lectura_IniAuxDateTo = DateTimeUtil.ResetTime(AV44TFLectura_Ini_To);
               AssignAttri("", false, "AV46DDO_Lectura_IniAuxDateTo", context.localUtil.Format(AV46DDO_Lectura_IniAuxDateTo, "99/99/9999"));
            }
            else if ( StringUtil.StrCmp(AV11GridStateFilterValue.gxTpr_Name, "TFRHTRABAJADORNOMBRES") == 0 )
            {
               AV55TFRHTrabajadorNombres = AV11GridStateFilterValue.gxTpr_Value;
               AssignAttri("", false, "AV55TFRHTrabajadorNombres", AV55TFRHTrabajadorNombres);
            }
            else if ( StringUtil.StrCmp(AV11GridStateFilterValue.gxTpr_Name, "TFRHTRABAJADORNOMBRES_SEL") == 0 )
            {
               AV56TFRHTrabajadorNombres_Sel = AV11GridStateFilterValue.gxTpr_Value;
               AssignAttri("", false, "AV56TFRHTrabajadorNombres_Sel", AV56TFRHTrabajadorNombres_Sel);
            }
            else if ( StringUtil.StrCmp(AV11GridStateFilterValue.gxTpr_Name, "TFHORARIODESCRIPCION") == 0 )
            {
               AV59TFHorarioDescripcion = AV11GridStateFilterValue.gxTpr_Value;
               AssignAttri("", false, "AV59TFHorarioDescripcion", AV59TFHorarioDescripcion);
            }
            else if ( StringUtil.StrCmp(AV11GridStateFilterValue.gxTpr_Name, "TFHORARIODESCRIPCION_SEL") == 0 )
            {
               AV60TFHorarioDescripcion_Sel = AV11GridStateFilterValue.gxTpr_Value;
               AssignAttri("", false, "AV60TFHorarioDescripcion_Sel", AV60TFHorarioDescripcion_Sel);
            }
            AV99GXV1 = (int)(AV99GXV1+1);
         }
         GXt_char2 = "";
         new GeneXus.Programs.wwpbaseobjects.wwp_getfilterval(context ).execute(  String.IsNullOrEmpty(StringUtil.RTrim( AV38TFCodigoId_Sel)),  AV38TFCodigoId_Sel, out  GXt_char2) ;
         GXt_char3 = "";
         new GeneXus.Programs.wwpbaseobjects.wwp_getfilterval(context ).execute(  String.IsNullOrEmpty(StringUtil.RTrim( AV42TFReloj_Nombre_Sel)),  AV42TFReloj_Nombre_Sel, out  GXt_char3) ;
         GXt_char4 = "";
         new GeneXus.Programs.wwpbaseobjects.wwp_getfilterval(context ).execute(  String.IsNullOrEmpty(StringUtil.RTrim( AV56TFRHTrabajadorNombres_Sel)),  AV56TFRHTrabajadorNombres_Sel, out  GXt_char4) ;
         GXt_char5 = "";
         new GeneXus.Programs.wwpbaseobjects.wwp_getfilterval(context ).execute(  String.IsNullOrEmpty(StringUtil.RTrim( AV60TFHorarioDescripcion_Sel)),  AV60TFHorarioDescripcion_Sel, out  GXt_char5) ;
         Ddo_grid_Selectedvalue_set = GXt_char2+"|"+GXt_char3+"||"+GXt_char4+"|"+GXt_char5;
         ucDdo_grid.SendProperty(context, "", false, Ddo_grid_Internalname, "SelectedValue_set", Ddo_grid_Selectedvalue_set);
         GXt_char5 = "";
         new GeneXus.Programs.wwpbaseobjects.wwp_getfilterval(context ).execute(  String.IsNullOrEmpty(StringUtil.RTrim( AV37TFCodigoId)),  AV37TFCodigoId, out  GXt_char5) ;
         GXt_char4 = "";
         new GeneXus.Programs.wwpbaseobjects.wwp_getfilterval(context ).execute(  String.IsNullOrEmpty(StringUtil.RTrim( AV41TFReloj_Nombre)),  AV41TFReloj_Nombre, out  GXt_char4) ;
         GXt_char3 = "";
         new GeneXus.Programs.wwpbaseobjects.wwp_getfilterval(context ).execute(  String.IsNullOrEmpty(StringUtil.RTrim( AV55TFRHTrabajadorNombres)),  AV55TFRHTrabajadorNombres, out  GXt_char3) ;
         GXt_char2 = "";
         new GeneXus.Programs.wwpbaseobjects.wwp_getfilterval(context ).execute(  String.IsNullOrEmpty(StringUtil.RTrim( AV59TFHorarioDescripcion)),  AV59TFHorarioDescripcion, out  GXt_char2) ;
         Ddo_grid_Filteredtext_set = GXt_char5+"|"+GXt_char4+"|"+((DateTime.MinValue==AV43TFLectura_Ini) ? "" : context.localUtil.DToC( AV45DDO_Lectura_IniAuxDate, 2, "/"))+"|"+GXt_char3+"|"+GXt_char2;
         ucDdo_grid.SendProperty(context, "", false, Ddo_grid_Internalname, "FilteredText_set", Ddo_grid_Filteredtext_set);
         Ddo_grid_Filteredtextto_set = "||"+((DateTime.MinValue==AV44TFLectura_Ini_To) ? "" : context.localUtil.DToC( AV46DDO_Lectura_IniAuxDateTo, 2, "/"))+"||";
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
            if ( StringUtil.StrCmp(AV15DynamicFiltersSelector1, "RHTRABAJADORNOMBRES") == 0 )
            {
               AV16DynamicFiltersOperator1 = AV12GridStateDynamicFilter.gxTpr_Operator;
               AssignAttri("", false, "AV16DynamicFiltersOperator1", StringUtil.LTrimStr( (decimal)(AV16DynamicFiltersOperator1), 4, 0));
               AV17RHTrabajadorNombres1 = AV12GridStateDynamicFilter.gxTpr_Value;
               AssignAttri("", false, "AV17RHTrabajadorNombres1", AV17RHTrabajadorNombres1);
            }
            else if ( StringUtil.StrCmp(AV15DynamicFiltersSelector1, "RELOJ_NOMBRE") == 0 )
            {
               AV16DynamicFiltersOperator1 = AV12GridStateDynamicFilter.gxTpr_Operator;
               AssignAttri("", false, "AV16DynamicFiltersOperator1", StringUtil.LTrimStr( (decimal)(AV16DynamicFiltersOperator1), 4, 0));
               AV18Reloj_Nombre1 = AV12GridStateDynamicFilter.gxTpr_Value;
               AssignAttri("", false, "AV18Reloj_Nombre1", AV18Reloj_Nombre1);
            }
            else if ( StringUtil.StrCmp(AV15DynamicFiltersSelector1, "HORARIODESCRIPCION") == 0 )
            {
               AV16DynamicFiltersOperator1 = AV12GridStateDynamicFilter.gxTpr_Operator;
               AssignAttri("", false, "AV16DynamicFiltersOperator1", StringUtil.LTrimStr( (decimal)(AV16DynamicFiltersOperator1), 4, 0));
               AV19HorarioDescripcion1 = AV12GridStateDynamicFilter.gxTpr_Value;
               AssignAttri("", false, "AV19HorarioDescripcion1", AV19HorarioDescripcion1);
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
               if ( StringUtil.StrCmp(AV21DynamicFiltersSelector2, "RHTRABAJADORNOMBRES") == 0 )
               {
                  AV22DynamicFiltersOperator2 = AV12GridStateDynamicFilter.gxTpr_Operator;
                  AssignAttri("", false, "AV22DynamicFiltersOperator2", StringUtil.LTrimStr( (decimal)(AV22DynamicFiltersOperator2), 4, 0));
                  AV23RHTrabajadorNombres2 = AV12GridStateDynamicFilter.gxTpr_Value;
                  AssignAttri("", false, "AV23RHTrabajadorNombres2", AV23RHTrabajadorNombres2);
               }
               else if ( StringUtil.StrCmp(AV21DynamicFiltersSelector2, "RELOJ_NOMBRE") == 0 )
               {
                  AV22DynamicFiltersOperator2 = AV12GridStateDynamicFilter.gxTpr_Operator;
                  AssignAttri("", false, "AV22DynamicFiltersOperator2", StringUtil.LTrimStr( (decimal)(AV22DynamicFiltersOperator2), 4, 0));
                  AV24Reloj_Nombre2 = AV12GridStateDynamicFilter.gxTpr_Value;
                  AssignAttri("", false, "AV24Reloj_Nombre2", AV24Reloj_Nombre2);
               }
               else if ( StringUtil.StrCmp(AV21DynamicFiltersSelector2, "HORARIODESCRIPCION") == 0 )
               {
                  AV22DynamicFiltersOperator2 = AV12GridStateDynamicFilter.gxTpr_Operator;
                  AssignAttri("", false, "AV22DynamicFiltersOperator2", StringUtil.LTrimStr( (decimal)(AV22DynamicFiltersOperator2), 4, 0));
                  AV25HorarioDescripcion2 = AV12GridStateDynamicFilter.gxTpr_Value;
                  AssignAttri("", false, "AV25HorarioDescripcion2", AV25HorarioDescripcion2);
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
                  if ( StringUtil.StrCmp(AV27DynamicFiltersSelector3, "RHTRABAJADORNOMBRES") == 0 )
                  {
                     AV28DynamicFiltersOperator3 = AV12GridStateDynamicFilter.gxTpr_Operator;
                     AssignAttri("", false, "AV28DynamicFiltersOperator3", StringUtil.LTrimStr( (decimal)(AV28DynamicFiltersOperator3), 4, 0));
                     AV29RHTrabajadorNombres3 = AV12GridStateDynamicFilter.gxTpr_Value;
                     AssignAttri("", false, "AV29RHTrabajadorNombres3", AV29RHTrabajadorNombres3);
                  }
                  else if ( StringUtil.StrCmp(AV27DynamicFiltersSelector3, "RELOJ_NOMBRE") == 0 )
                  {
                     AV28DynamicFiltersOperator3 = AV12GridStateDynamicFilter.gxTpr_Operator;
                     AssignAttri("", false, "AV28DynamicFiltersOperator3", StringUtil.LTrimStr( (decimal)(AV28DynamicFiltersOperator3), 4, 0));
                     AV30Reloj_Nombre3 = AV12GridStateDynamicFilter.gxTpr_Value;
                     AssignAttri("", false, "AV30Reloj_Nombre3", AV30Reloj_Nombre3);
                  }
                  else if ( StringUtil.StrCmp(AV27DynamicFiltersSelector3, "HORARIODESCRIPCION") == 0 )
                  {
                     AV28DynamicFiltersOperator3 = AV12GridStateDynamicFilter.gxTpr_Operator;
                     AssignAttri("", false, "AV28DynamicFiltersOperator3", StringUtil.LTrimStr( (decimal)(AV28DynamicFiltersOperator3), 4, 0));
                     AV31HorarioDescripcion3 = AV12GridStateDynamicFilter.gxTpr_Value;
                     AssignAttri("", false, "AV31HorarioDescripcion3", AV31HorarioDescripcion3);
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
         AV10GridState.FromXml(AV36Session.Get(AV71Pgmname+"GridState"), null, "", "");
         AV10GridState.gxTpr_Orderedby = AV13OrderedBy;
         AV10GridState.gxTpr_Ordereddsc = AV14OrderedDsc;
         AV10GridState.gxTpr_Filtervalues.Clear();
         new GeneXus.Programs.wwpbaseobjects.wwp_gridstateaddfiltervalueandsel(context ).execute( ref  AV10GridState,  "TFCODIGOID",  "Trabajador ID",  !String.IsNullOrEmpty(StringUtil.RTrim( AV37TFCodigoId)),  0,  AV37TFCodigoId,  "",  !String.IsNullOrEmpty(StringUtil.RTrim( AV38TFCodigoId_Sel)),  AV38TFCodigoId_Sel,  "") ;
         new GeneXus.Programs.wwpbaseobjects.wwp_gridstateaddfiltervalueandsel(context ).execute( ref  AV10GridState,  "TFRELOJ_NOMBRE",  "Reloj",  !String.IsNullOrEmpty(StringUtil.RTrim( AV41TFReloj_Nombre)),  0,  AV41TFReloj_Nombre,  "",  !String.IsNullOrEmpty(StringUtil.RTrim( AV42TFReloj_Nombre_Sel)),  AV42TFReloj_Nombre_Sel,  "") ;
         new GeneXus.Programs.wwpbaseobjects.wwp_gridstateaddfiltervalue(context ).execute( ref  AV10GridState,  "TFLECTURA_INI",  "Fecha Registro",  !((DateTime.MinValue==AV43TFLectura_Ini)&&(DateTime.MinValue==AV44TFLectura_Ini_To)),  0,  StringUtil.Trim( context.localUtil.TToC( AV43TFLectura_Ini, 10, 8, 0, 3, "/", ":", " ")),  StringUtil.Trim( context.localUtil.TToC( AV44TFLectura_Ini_To, 10, 8, 0, 3, "/", ":", " "))) ;
         new GeneXus.Programs.wwpbaseobjects.wwp_gridstateaddfiltervalueandsel(context ).execute( ref  AV10GridState,  "TFRHTRABAJADORNOMBRES",  "Trabajador",  !String.IsNullOrEmpty(StringUtil.RTrim( AV55TFRHTrabajadorNombres)),  0,  AV55TFRHTrabajadorNombres,  "",  !String.IsNullOrEmpty(StringUtil.RTrim( AV56TFRHTrabajadorNombres_Sel)),  AV56TFRHTrabajadorNombres_Sel,  "") ;
         new GeneXus.Programs.wwpbaseobjects.wwp_gridstateaddfiltervalueandsel(context ).execute( ref  AV10GridState,  "TFHORARIODESCRIPCION",  "Horario",  !String.IsNullOrEmpty(StringUtil.RTrim( AV59TFHorarioDescripcion)),  0,  AV59TFHorarioDescripcion,  "",  !String.IsNullOrEmpty(StringUtil.RTrim( AV60TFHorarioDescripcion_Sel)),  AV60TFHorarioDescripcion_Sel,  "") ;
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
         if ( ! AV33DynamicFiltersIgnoreFirst )
         {
            AV12GridStateDynamicFilter = new GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter(context);
            AV12GridStateDynamicFilter.gxTpr_Selected = AV15DynamicFiltersSelector1;
            if ( ( StringUtil.StrCmp(AV15DynamicFiltersSelector1, "RHTRABAJADORNOMBRES") == 0 ) && ! String.IsNullOrEmpty(StringUtil.RTrim( AV17RHTrabajadorNombres1)) )
            {
               AV12GridStateDynamicFilter.gxTpr_Dsc = "Nombres";
               AV12GridStateDynamicFilter.gxTpr_Value = AV17RHTrabajadorNombres1;
               AV12GridStateDynamicFilter.gxTpr_Operator = AV16DynamicFiltersOperator1;
            }
            else if ( ( StringUtil.StrCmp(AV15DynamicFiltersSelector1, "RELOJ_NOMBRE") == 0 ) && ! String.IsNullOrEmpty(StringUtil.RTrim( AV18Reloj_Nombre1)) )
            {
               AV12GridStateDynamicFilter.gxTpr_Dsc = "Reloj_Nombre";
               AV12GridStateDynamicFilter.gxTpr_Value = AV18Reloj_Nombre1;
               AV12GridStateDynamicFilter.gxTpr_Operator = AV16DynamicFiltersOperator1;
            }
            else if ( ( StringUtil.StrCmp(AV15DynamicFiltersSelector1, "HORARIODESCRIPCION") == 0 ) && ! String.IsNullOrEmpty(StringUtil.RTrim( AV19HorarioDescripcion1)) )
            {
               AV12GridStateDynamicFilter.gxTpr_Dsc = "Horario";
               AV12GridStateDynamicFilter.gxTpr_Value = AV19HorarioDescripcion1;
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
            if ( ( StringUtil.StrCmp(AV21DynamicFiltersSelector2, "RHTRABAJADORNOMBRES") == 0 ) && ! String.IsNullOrEmpty(StringUtil.RTrim( AV23RHTrabajadorNombres2)) )
            {
               AV12GridStateDynamicFilter.gxTpr_Dsc = "Nombres";
               AV12GridStateDynamicFilter.gxTpr_Value = AV23RHTrabajadorNombres2;
               AV12GridStateDynamicFilter.gxTpr_Operator = AV22DynamicFiltersOperator2;
            }
            else if ( ( StringUtil.StrCmp(AV21DynamicFiltersSelector2, "RELOJ_NOMBRE") == 0 ) && ! String.IsNullOrEmpty(StringUtil.RTrim( AV24Reloj_Nombre2)) )
            {
               AV12GridStateDynamicFilter.gxTpr_Dsc = "Reloj_Nombre";
               AV12GridStateDynamicFilter.gxTpr_Value = AV24Reloj_Nombre2;
               AV12GridStateDynamicFilter.gxTpr_Operator = AV22DynamicFiltersOperator2;
            }
            else if ( ( StringUtil.StrCmp(AV21DynamicFiltersSelector2, "HORARIODESCRIPCION") == 0 ) && ! String.IsNullOrEmpty(StringUtil.RTrim( AV25HorarioDescripcion2)) )
            {
               AV12GridStateDynamicFilter.gxTpr_Dsc = "Horario";
               AV12GridStateDynamicFilter.gxTpr_Value = AV25HorarioDescripcion2;
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
            if ( ( StringUtil.StrCmp(AV27DynamicFiltersSelector3, "RHTRABAJADORNOMBRES") == 0 ) && ! String.IsNullOrEmpty(StringUtil.RTrim( AV29RHTrabajadorNombres3)) )
            {
               AV12GridStateDynamicFilter.gxTpr_Dsc = "Nombres";
               AV12GridStateDynamicFilter.gxTpr_Value = AV29RHTrabajadorNombres3;
               AV12GridStateDynamicFilter.gxTpr_Operator = AV28DynamicFiltersOperator3;
            }
            else if ( ( StringUtil.StrCmp(AV27DynamicFiltersSelector3, "RELOJ_NOMBRE") == 0 ) && ! String.IsNullOrEmpty(StringUtil.RTrim( AV30Reloj_Nombre3)) )
            {
               AV12GridStateDynamicFilter.gxTpr_Dsc = "Reloj_Nombre";
               AV12GridStateDynamicFilter.gxTpr_Value = AV30Reloj_Nombre3;
               AV12GridStateDynamicFilter.gxTpr_Operator = AV28DynamicFiltersOperator3;
            }
            else if ( ( StringUtil.StrCmp(AV27DynamicFiltersSelector3, "HORARIODESCRIPCION") == 0 ) && ! String.IsNullOrEmpty(StringUtil.RTrim( AV31HorarioDescripcion3)) )
            {
               AV12GridStateDynamicFilter.gxTpr_Dsc = "Horario";
               AV12GridStateDynamicFilter.gxTpr_Value = AV31HorarioDescripcion3;
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
         AV8TrnContext.gxTpr_Callerobject = AV71Pgmname;
         AV8TrnContext.gxTpr_Callerondelete = true;
         AV8TrnContext.gxTpr_Callerurl = AV7HTTPRequest.ScriptName+"?"+AV7HTTPRequest.QueryString;
         AV8TrnContext.gxTpr_Transactionname = "Reloj_Interface.Reloj_CodigoID";
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
         new GeneXus.Programs.reloj_interface.reloj_codigoidwwexport(context ).execute( out  AV34ExcelFilename, out  AV35ErrorMessage) ;
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
         Innewwindow1_Target = formatLink("reloj_interface.reloj_codigoidwwexportreport.aspx") ;
         ucInnewwindow1.SendProperty(context, "", false, Innewwindow1_Internalname, "Target", Innewwindow1_Target);
         Innewwindow1_Height = "600";
         ucInnewwindow1.SendProperty(context, "", false, Innewwindow1_Internalname, "Height", Innewwindow1_Height);
         Innewwindow1_Width = "800";
         ucInnewwindow1.SendProperty(context, "", false, Innewwindow1_Internalname, "Width", Innewwindow1_Width);
         this.executeUsercontrolMethod("", false, "INNEWWINDOW1Container", "OpenWindow", "", new Object[] {});
      }

      protected void wb_table1_25_7M2( bool wbgen )
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
            GxWebStd.gx_label_ctrl( context, lblDynamicfiltersprefix1_Internalname, "Buscar en", "", "", lblDynamicfiltersprefix1_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "DataFilterDescriptionPrefix", 0, "", 1, 1, 0, 0, "HLP_Reloj_Interface\\Reloj_CodigoIDWW.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "", "left", "top", "", "flex-grow:1;", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "left", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, cmbavDynamicfiltersselector1_Internalname, "Dynamic Filters Selector1", "gx-form-item AttributeLabel", 0, true, "width: 25%;");
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 35,'',false,'" + sGXsfl_119_idx + "',0)\"";
            /* ComboBox */
            GxWebStd.gx_combobox_ctrl1( context, cmbavDynamicfiltersselector1, cmbavDynamicfiltersselector1_Internalname, StringUtil.RTrim( AV15DynamicFiltersSelector1), 1, cmbavDynamicfiltersselector1_Jsonclick, 5, "'"+""+"'"+",false,"+"'"+"EVDYNAMICFILTERSSELECTOR1.CLICK."+"'", "svchar", "", 1, cmbavDynamicfiltersselector1.Enabled, 0, 0, 0, "em", 0, "", "", "Attribute", "", "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,35);\"", "", true, 1, "HLP_Reloj_Interface\\Reloj_CodigoIDWW.htm");
            cmbavDynamicfiltersselector1.CurrentValue = StringUtil.RTrim( AV15DynamicFiltersSelector1);
            AssignProp("", false, cmbavDynamicfiltersselector1_Internalname, "Values", (string)(cmbavDynamicfiltersselector1.ToJavascriptSource()), true);
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "", "left", "top", "", "flex-grow:1;", "div");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblDynamicfiltersmiddle1_Internalname, "valor", "", "", lblDynamicfiltersmiddle1_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "DataFilterDescription", 0, "", 1, 1, 0, 0, "HLP_Reloj_Interface\\Reloj_CodigoIDWW.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "", "left", "top", "", "flex-grow:1;", "div");
            wb_table2_39_7M2( true) ;
         }
         else
         {
            wb_table2_39_7M2( false) ;
         }
         return  ;
      }

      protected void wb_table2_39_7M2e( bool wbgen )
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
            GxWebStd.gx_label_ctrl( context, lblDynamicfiltersprefix2_Internalname, "Buscar en", "", "", lblDynamicfiltersprefix2_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "DataFilterDescriptionPrefix", 0, "", 1, 1, 0, 0, "HLP_Reloj_Interface\\Reloj_CodigoIDWW.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "Invisible", "left", "top", "", "flex-grow:1;", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "left", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, cmbavDynamicfiltersselector2_Internalname, "Dynamic Filters Selector2", "gx-form-item AttributeLabel", 0, true, "width: 25%;");
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 63,'',false,'" + sGXsfl_119_idx + "',0)\"";
            /* ComboBox */
            GxWebStd.gx_combobox_ctrl1( context, cmbavDynamicfiltersselector2, cmbavDynamicfiltersselector2_Internalname, StringUtil.RTrim( AV21DynamicFiltersSelector2), 1, cmbavDynamicfiltersselector2_Jsonclick, 5, "'"+""+"'"+",false,"+"'"+"EVDYNAMICFILTERSSELECTOR2.CLICK."+"'", "svchar", "", 1, cmbavDynamicfiltersselector2.Enabled, 0, 0, 0, "em", 0, "", "", "Attribute", "", "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,63);\"", "", true, 1, "HLP_Reloj_Interface\\Reloj_CodigoIDWW.htm");
            cmbavDynamicfiltersselector2.CurrentValue = StringUtil.RTrim( AV21DynamicFiltersSelector2);
            AssignProp("", false, cmbavDynamicfiltersselector2_Internalname, "Values", (string)(cmbavDynamicfiltersselector2.ToJavascriptSource()), true);
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "Invisible", "left", "top", "", "flex-grow:1;", "div");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblDynamicfiltersmiddle2_Internalname, "valor", "", "", lblDynamicfiltersmiddle2_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "DataFilterDescription", 0, "", 1, 1, 0, 0, "HLP_Reloj_Interface\\Reloj_CodigoIDWW.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "Invisible", "left", "top", "", "flex-grow:1;", "div");
            wb_table3_67_7M2( true) ;
         }
         else
         {
            wb_table3_67_7M2( false) ;
         }
         return  ;
      }

      protected void wb_table3_67_7M2e( bool wbgen )
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
            GxWebStd.gx_label_ctrl( context, lblDynamicfiltersprefix3_Internalname, "Buscar en", "", "", lblDynamicfiltersprefix3_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "DataFilterDescriptionPrefix", 0, "", 1, 1, 0, 0, "HLP_Reloj_Interface\\Reloj_CodigoIDWW.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "Invisible", "left", "top", "", "flex-grow:1;", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "left", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, cmbavDynamicfiltersselector3_Internalname, "Dynamic Filters Selector3", "gx-form-item AttributeLabel", 0, true, "width: 25%;");
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 91,'',false,'" + sGXsfl_119_idx + "',0)\"";
            /* ComboBox */
            GxWebStd.gx_combobox_ctrl1( context, cmbavDynamicfiltersselector3, cmbavDynamicfiltersselector3_Internalname, StringUtil.RTrim( AV27DynamicFiltersSelector3), 1, cmbavDynamicfiltersselector3_Jsonclick, 5, "'"+""+"'"+",false,"+"'"+"EVDYNAMICFILTERSSELECTOR3.CLICK."+"'", "svchar", "", 1, cmbavDynamicfiltersselector3.Enabled, 0, 0, 0, "em", 0, "", "", "Attribute", "", "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,91);\"", "", true, 1, "HLP_Reloj_Interface\\Reloj_CodigoIDWW.htm");
            cmbavDynamicfiltersselector3.CurrentValue = StringUtil.RTrim( AV27DynamicFiltersSelector3);
            AssignProp("", false, cmbavDynamicfiltersselector3_Internalname, "Values", (string)(cmbavDynamicfiltersselector3.ToJavascriptSource()), true);
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "Invisible", "left", "top", "", "flex-grow:1;", "div");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblDynamicfiltersmiddle3_Internalname, "valor", "", "", lblDynamicfiltersmiddle3_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "DataFilterDescription", 0, "", 1, 1, 0, 0, "HLP_Reloj_Interface\\Reloj_CodigoIDWW.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "Invisible", "left", "top", "", "flex-grow:1;", "div");
            wb_table4_95_7M2( true) ;
         }
         else
         {
            wb_table4_95_7M2( false) ;
         }
         return  ;
      }

      protected void wb_table4_95_7M2e( bool wbgen )
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
            wb_table1_25_7M2e( true) ;
         }
         else
         {
            wb_table1_25_7M2e( false) ;
         }
      }

      protected void wb_table4_95_7M2( bool wbgen )
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
            GxWebStd.gx_combobox_ctrl1( context, cmbavDynamicfiltersoperator3, cmbavDynamicfiltersoperator3_Internalname, StringUtil.Trim( StringUtil.Str( (decimal)(AV28DynamicFiltersOperator3), 4, 0)), 1, cmbavDynamicfiltersoperator3_Jsonclick, 0, "'"+""+"'"+",false,"+"'"+""+"'", "int", "", cmbavDynamicfiltersoperator3.Visible, cmbavDynamicfiltersoperator3.Enabled, 0, 0, 0, "em", 0, "", "", "Attribute", "", "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,99);\"", "", true, 1, "HLP_Reloj_Interface\\Reloj_CodigoIDWW.htm");
            cmbavDynamicfiltersoperator3.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV28DynamicFiltersOperator3), 4, 0));
            AssignProp("", false, cmbavDynamicfiltersoperator3_Internalname, "Values", (string)(cmbavDynamicfiltersoperator3.ToJavascriptSource()), true);
            GxWebStd.gx_div_end( context, "left", "top", "div");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "<td id=\""+cellFilter_rhtrabajadornombres3_cell_Internalname+"\"  class=''>") ;
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "left", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavRhtrabajadornombres3_Internalname, "RHTrabajador Nombres3", "gx-form-item AttributeLabel", 0, true, "width: 25%;");
            /* Multiple line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 102,'',false,'" + sGXsfl_119_idx + "',0)\"";
            ClassString = "Attribute";
            StyleString = "";
            ClassString = "Attribute";
            StyleString = "";
            GxWebStd.gx_html_textarea( context, edtavRhtrabajadornombres3_Internalname, AV29RHTrabajadorNombres3, "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,102);\"", 0, edtavRhtrabajadornombres3_Visible, edtavRhtrabajadornombres3_Enabled, 0, 80, "chr", 4, "row", StyleString, ClassString, "", "", "300", -1, 0, "", "", -1, true, "", "'"+""+"'"+",false,"+"'"+""+"'", 0, "HLP_Reloj_Interface\\Reloj_CodigoIDWW.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "<td id=\""+cellFilter_reloj_nombre3_cell_Internalname+"\"  class=''>") ;
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "left", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavReloj_nombre3_Internalname, "Reloj_Nombre3", "gx-form-item AttributeLabel", 0, true, "width: 25%;");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 105,'',false,'" + sGXsfl_119_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavReloj_nombre3_Internalname, AV30Reloj_Nombre3, StringUtil.RTrim( context.localUtil.Format( AV30Reloj_Nombre3, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,105);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavReloj_nombre3_Jsonclick, 0, "Attribute", "", "", "", "", edtavReloj_nombre3_Visible, edtavReloj_nombre3_Enabled, 0, "text", "", 50, "chr", 1, "row", 50, 0, 0, 0, 1, -1, -1, true, "", "left", true, "", "HLP_Reloj_Interface\\Reloj_CodigoIDWW.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "<td id=\""+cellFilter_horariodescripcion3_cell_Internalname+"\"  class=''>") ;
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "left", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavHorariodescripcion3_Internalname, "Horario Descripcion3", "gx-form-item AttributeLabel", 0, true, "width: 25%;");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 108,'',false,'" + sGXsfl_119_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavHorariodescripcion3_Internalname, AV31HorarioDescripcion3, StringUtil.RTrim( context.localUtil.Format( AV31HorarioDescripcion3, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,108);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavHorariodescripcion3_Jsonclick, 0, "Attribute", "", "", "", "", edtavHorariodescripcion3_Visible, edtavHorariodescripcion3_Enabled, 0, "text", "", 80, "chr", 1, "row", 100, 0, 0, 0, 1, -1, -1, true, "", "left", true, "", "HLP_Reloj_Interface\\Reloj_CodigoIDWW.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "<td id=\""+cellDynamicfilters_removefilter3_cell_Internalname+"\"  class=''>") ;
            /* Active images/pictures */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 110,'',false,'',0)\"";
            ClassString = "Image";
            StyleString = "";
            sImgUrl = (string)(context.GetImagePath( "11a6ef14-1a5a-4077-91a2-f41ed9a3a662", "", context.GetTheme( )));
            GxWebStd.gx_bitmap( context, imgRemovedynamicfilters3_Internalname, sImgUrl, "", "", "", context.GetTheme( ), 1, 1, "", "Quitar filtro", 0, 0, 0, "px", 0, "px", 0, 0, 5, imgRemovedynamicfilters3_Jsonclick, "'"+""+"'"+",false,"+"'"+"E\\'REMOVEDYNAMICFILTERS3\\'."+"'", StyleString, ClassString, "", "", "", "", " "+"data-gx-image"+" "+TempTags, "", "", 1, false, false, context.GetImageSrcSet( sImgUrl), "HLP_Reloj_Interface\\Reloj_CodigoIDWW.htm");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "</tr>") ;
            /* End of table */
            context.WriteHtmlText( "</table>") ;
            wb_table4_95_7M2e( true) ;
         }
         else
         {
            wb_table4_95_7M2e( false) ;
         }
      }

      protected void wb_table3_67_7M2( bool wbgen )
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
            GxWebStd.gx_combobox_ctrl1( context, cmbavDynamicfiltersoperator2, cmbavDynamicfiltersoperator2_Internalname, StringUtil.Trim( StringUtil.Str( (decimal)(AV22DynamicFiltersOperator2), 4, 0)), 1, cmbavDynamicfiltersoperator2_Jsonclick, 0, "'"+""+"'"+",false,"+"'"+""+"'", "int", "", cmbavDynamicfiltersoperator2.Visible, cmbavDynamicfiltersoperator2.Enabled, 0, 0, 0, "em", 0, "", "", "Attribute", "", "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,71);\"", "", true, 1, "HLP_Reloj_Interface\\Reloj_CodigoIDWW.htm");
            cmbavDynamicfiltersoperator2.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV22DynamicFiltersOperator2), 4, 0));
            AssignProp("", false, cmbavDynamicfiltersoperator2_Internalname, "Values", (string)(cmbavDynamicfiltersoperator2.ToJavascriptSource()), true);
            GxWebStd.gx_div_end( context, "left", "top", "div");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "<td id=\""+cellFilter_rhtrabajadornombres2_cell_Internalname+"\"  class=''>") ;
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "left", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavRhtrabajadornombres2_Internalname, "RHTrabajador Nombres2", "gx-form-item AttributeLabel", 0, true, "width: 25%;");
            /* Multiple line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 74,'',false,'" + sGXsfl_119_idx + "',0)\"";
            ClassString = "Attribute";
            StyleString = "";
            ClassString = "Attribute";
            StyleString = "";
            GxWebStd.gx_html_textarea( context, edtavRhtrabajadornombres2_Internalname, AV23RHTrabajadorNombres2, "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,74);\"", 0, edtavRhtrabajadornombres2_Visible, edtavRhtrabajadornombres2_Enabled, 0, 80, "chr", 4, "row", StyleString, ClassString, "", "", "300", -1, 0, "", "", -1, true, "", "'"+""+"'"+",false,"+"'"+""+"'", 0, "HLP_Reloj_Interface\\Reloj_CodigoIDWW.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "<td id=\""+cellFilter_reloj_nombre2_cell_Internalname+"\"  class=''>") ;
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "left", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavReloj_nombre2_Internalname, "Reloj_Nombre2", "gx-form-item AttributeLabel", 0, true, "width: 25%;");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 77,'',false,'" + sGXsfl_119_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavReloj_nombre2_Internalname, AV24Reloj_Nombre2, StringUtil.RTrim( context.localUtil.Format( AV24Reloj_Nombre2, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,77);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavReloj_nombre2_Jsonclick, 0, "Attribute", "", "", "", "", edtavReloj_nombre2_Visible, edtavReloj_nombre2_Enabled, 0, "text", "", 50, "chr", 1, "row", 50, 0, 0, 0, 1, -1, -1, true, "", "left", true, "", "HLP_Reloj_Interface\\Reloj_CodigoIDWW.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "<td id=\""+cellFilter_horariodescripcion2_cell_Internalname+"\"  class=''>") ;
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "left", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavHorariodescripcion2_Internalname, "Horario Descripcion2", "gx-form-item AttributeLabel", 0, true, "width: 25%;");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 80,'',false,'" + sGXsfl_119_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavHorariodescripcion2_Internalname, AV25HorarioDescripcion2, StringUtil.RTrim( context.localUtil.Format( AV25HorarioDescripcion2, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,80);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavHorariodescripcion2_Jsonclick, 0, "Attribute", "", "", "", "", edtavHorariodescripcion2_Visible, edtavHorariodescripcion2_Enabled, 0, "text", "", 80, "chr", 1, "row", 100, 0, 0, 0, 1, -1, -1, true, "", "left", true, "", "HLP_Reloj_Interface\\Reloj_CodigoIDWW.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "<td id=\""+cellDynamicfilters_addfilter2_cell_Internalname+"\"  class=''>") ;
            /* Active images/pictures */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 82,'',false,'',0)\"";
            ClassString = "Image";
            StyleString = "";
            sImgUrl = (string)(context.GetImagePath( "27283ea5-332f-423b-b880-64b762622df3", "", context.GetTheme( )));
            GxWebStd.gx_bitmap( context, imgAdddynamicfilters2_Internalname, sImgUrl, "", "", "", context.GetTheme( ), imgAdddynamicfilters2_Visible, 1, "", "Agregar filtro", 0, 0, 0, "px", 0, "px", 0, 0, 5, imgAdddynamicfilters2_Jsonclick, "'"+""+"'"+",false,"+"'"+"E\\'ADDDYNAMICFILTERS2\\'."+"'", StyleString, ClassString, "", "", "", "", " "+"data-gx-image"+" "+TempTags, "", "", 1, false, false, context.GetImageSrcSet( sImgUrl), "HLP_Reloj_Interface\\Reloj_CodigoIDWW.htm");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "<td id=\""+cellDynamicfilters_removefilter2_cell_Internalname+"\"  class=''>") ;
            /* Active images/pictures */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 84,'',false,'',0)\"";
            ClassString = "Image";
            StyleString = "";
            sImgUrl = (string)(context.GetImagePath( "11a6ef14-1a5a-4077-91a2-f41ed9a3a662", "", context.GetTheme( )));
            GxWebStd.gx_bitmap( context, imgRemovedynamicfilters2_Internalname, sImgUrl, "", "", "", context.GetTheme( ), imgRemovedynamicfilters2_Visible, 1, "", "Quitar filtro", 0, 0, 0, "px", 0, "px", 0, 0, 5, imgRemovedynamicfilters2_Jsonclick, "'"+""+"'"+",false,"+"'"+"E\\'REMOVEDYNAMICFILTERS2\\'."+"'", StyleString, ClassString, "", "", "", "", " "+"data-gx-image"+" "+TempTags, "", "", 1, false, false, context.GetImageSrcSet( sImgUrl), "HLP_Reloj_Interface\\Reloj_CodigoIDWW.htm");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "</tr>") ;
            /* End of table */
            context.WriteHtmlText( "</table>") ;
            wb_table3_67_7M2e( true) ;
         }
         else
         {
            wb_table3_67_7M2e( false) ;
         }
      }

      protected void wb_table2_39_7M2( bool wbgen )
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
            GxWebStd.gx_combobox_ctrl1( context, cmbavDynamicfiltersoperator1, cmbavDynamicfiltersoperator1_Internalname, StringUtil.Trim( StringUtil.Str( (decimal)(AV16DynamicFiltersOperator1), 4, 0)), 1, cmbavDynamicfiltersoperator1_Jsonclick, 0, "'"+""+"'"+",false,"+"'"+""+"'", "int", "", cmbavDynamicfiltersoperator1.Visible, cmbavDynamicfiltersoperator1.Enabled, 0, 0, 0, "em", 0, "", "", "Attribute", "", "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,43);\"", "", true, 1, "HLP_Reloj_Interface\\Reloj_CodigoIDWW.htm");
            cmbavDynamicfiltersoperator1.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV16DynamicFiltersOperator1), 4, 0));
            AssignProp("", false, cmbavDynamicfiltersoperator1_Internalname, "Values", (string)(cmbavDynamicfiltersoperator1.ToJavascriptSource()), true);
            GxWebStd.gx_div_end( context, "left", "top", "div");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "<td id=\""+cellFilter_rhtrabajadornombres1_cell_Internalname+"\"  class=''>") ;
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "left", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavRhtrabajadornombres1_Internalname, "RHTrabajador Nombres1", "gx-form-item AttributeLabel", 0, true, "width: 25%;");
            /* Multiple line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 46,'',false,'" + sGXsfl_119_idx + "',0)\"";
            ClassString = "Attribute";
            StyleString = "";
            ClassString = "Attribute";
            StyleString = "";
            GxWebStd.gx_html_textarea( context, edtavRhtrabajadornombres1_Internalname, AV17RHTrabajadorNombres1, "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,46);\"", 0, edtavRhtrabajadornombres1_Visible, edtavRhtrabajadornombres1_Enabled, 0, 80, "chr", 4, "row", StyleString, ClassString, "", "", "300", -1, 0, "", "", -1, true, "", "'"+""+"'"+",false,"+"'"+""+"'", 0, "HLP_Reloj_Interface\\Reloj_CodigoIDWW.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "<td id=\""+cellFilter_reloj_nombre1_cell_Internalname+"\"  class=''>") ;
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "left", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavReloj_nombre1_Internalname, "Reloj_Nombre1", "gx-form-item AttributeLabel", 0, true, "width: 25%;");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 49,'',false,'" + sGXsfl_119_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavReloj_nombre1_Internalname, AV18Reloj_Nombre1, StringUtil.RTrim( context.localUtil.Format( AV18Reloj_Nombre1, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,49);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavReloj_nombre1_Jsonclick, 0, "Attribute", "", "", "", "", edtavReloj_nombre1_Visible, edtavReloj_nombre1_Enabled, 0, "text", "", 50, "chr", 1, "row", 50, 0, 0, 0, 1, -1, -1, true, "", "left", true, "", "HLP_Reloj_Interface\\Reloj_CodigoIDWW.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "<td id=\""+cellFilter_horariodescripcion1_cell_Internalname+"\"  class=''>") ;
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "left", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavHorariodescripcion1_Internalname, "Horario Descripcion1", "gx-form-item AttributeLabel", 0, true, "width: 25%;");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 52,'',false,'" + sGXsfl_119_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavHorariodescripcion1_Internalname, AV19HorarioDescripcion1, StringUtil.RTrim( context.localUtil.Format( AV19HorarioDescripcion1, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,52);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavHorariodescripcion1_Jsonclick, 0, "Attribute", "", "", "", "", edtavHorariodescripcion1_Visible, edtavHorariodescripcion1_Enabled, 0, "text", "", 80, "chr", 1, "row", 100, 0, 0, 0, 1, -1, -1, true, "", "left", true, "", "HLP_Reloj_Interface\\Reloj_CodigoIDWW.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "<td id=\""+cellDynamicfilters_addfilter1_cell_Internalname+"\"  class=''>") ;
            /* Active images/pictures */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 54,'',false,'',0)\"";
            ClassString = "Image";
            StyleString = "";
            sImgUrl = (string)(context.GetImagePath( "27283ea5-332f-423b-b880-64b762622df3", "", context.GetTheme( )));
            GxWebStd.gx_bitmap( context, imgAdddynamicfilters1_Internalname, sImgUrl, "", "", "", context.GetTheme( ), imgAdddynamicfilters1_Visible, 1, "", "Agregar filtro", 0, 0, 0, "px", 0, "px", 0, 0, 5, imgAdddynamicfilters1_Jsonclick, "'"+""+"'"+",false,"+"'"+"E\\'ADDDYNAMICFILTERS1\\'."+"'", StyleString, ClassString, "", "", "", "", " "+"data-gx-image"+" "+TempTags, "", "", 1, false, false, context.GetImageSrcSet( sImgUrl), "HLP_Reloj_Interface\\Reloj_CodigoIDWW.htm");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "<td id=\""+cellDynamicfilters_removefilter1_cell_Internalname+"\"  class=''>") ;
            /* Active images/pictures */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 56,'',false,'',0)\"";
            ClassString = "Image";
            StyleString = "";
            sImgUrl = (string)(context.GetImagePath( "11a6ef14-1a5a-4077-91a2-f41ed9a3a662", "", context.GetTheme( )));
            GxWebStd.gx_bitmap( context, imgRemovedynamicfilters1_Internalname, sImgUrl, "", "", "", context.GetTheme( ), imgRemovedynamicfilters1_Visible, 1, "", "Quitar filtro", 0, 0, 0, "px", 0, "px", 0, 0, 5, imgRemovedynamicfilters1_Jsonclick, "'"+""+"'"+",false,"+"'"+"E\\'REMOVEDYNAMICFILTERS1\\'."+"'", StyleString, ClassString, "", "", "", "", " "+"data-gx-image"+" "+TempTags, "", "", 1, false, false, context.GetImageSrcSet( sImgUrl), "HLP_Reloj_Interface\\Reloj_CodigoIDWW.htm");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "</tr>") ;
            /* End of table */
            context.WriteHtmlText( "</table>") ;
            wb_table2_39_7M2e( true) ;
         }
         else
         {
            wb_table2_39_7M2e( false) ;
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
         PA7M2( ) ;
         WS7M2( ) ;
         WE7M2( ) ;
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
            context.AddJavascriptSource(StringUtil.RTrim( ((string)Form.Jscriptsrc.Item(idxLst))), "?20228181416662", true, true);
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
         context.AddJavascriptSource("reloj_interface/reloj_codigoidww.js", "?20228181416662", false, true);
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

      protected void SubsflControlProps_1192( )
      {
         cmbavGridactions_Internalname = "vGRIDACTIONS_"+sGXsfl_119_idx;
         edtCodigoId_Internalname = "CODIGOID_"+sGXsfl_119_idx;
         edtReloj_Nombre_Internalname = "RELOJ_NOMBRE_"+sGXsfl_119_idx;
         edtLectura_Ini_Internalname = "LECTURA_INI_"+sGXsfl_119_idx;
         edtRHTrabajadorNombres_Internalname = "RHTRABAJADORNOMBRES_"+sGXsfl_119_idx;
         edtHorarioDescripcion_Internalname = "HORARIODESCRIPCION_"+sGXsfl_119_idx;
      }

      protected void SubsflControlProps_fel_1192( )
      {
         cmbavGridactions_Internalname = "vGRIDACTIONS_"+sGXsfl_119_fel_idx;
         edtCodigoId_Internalname = "CODIGOID_"+sGXsfl_119_fel_idx;
         edtReloj_Nombre_Internalname = "RELOJ_NOMBRE_"+sGXsfl_119_fel_idx;
         edtLectura_Ini_Internalname = "LECTURA_INI_"+sGXsfl_119_fel_idx;
         edtRHTrabajadorNombres_Internalname = "RHTRABAJADORNOMBRES_"+sGXsfl_119_fel_idx;
         edtHorarioDescripcion_Internalname = "HORARIODESCRIPCION_"+sGXsfl_119_fel_idx;
      }

      protected void sendrow_1192( )
      {
         SubsflControlProps_1192( ) ;
         WB7M0( ) ;
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
                  AV66GridActions = (short)(NumberUtil.Val( cmbavGridactions.getValidValue(StringUtil.Trim( StringUtil.Str( (decimal)(AV66GridActions), 4, 0))), "."));
                  AssignAttri("", false, cmbavGridactions_Internalname, StringUtil.LTrimStr( (decimal)(AV66GridActions), 4, 0));
               }
            }
            /* ComboBox */
            GridRow.AddColumnProperties("combobox", 2, isAjaxCallMode( ), new Object[] {(GXCombobox)cmbavGridactions,(string)cmbavGridactions_Internalname,StringUtil.Trim( StringUtil.Str( (decimal)(AV66GridActions), 4, 0)),(short)1,(string)cmbavGridactions_Jsonclick,(short)5,"'"+""+"'"+",false,"+"'"+"EVGRIDACTIONS.CLICK."+sGXsfl_119_idx+"'",(string)"int",(string)"",(short)-1,(short)1,(short)0,(short)0,(short)0,(string)"px",(short)0,(string)"px",(string)"",(string)"ConvertToDDO",(string)"WWActionGroupColumn",(string)"",TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+((cmbavGridactions.Enabled!=0)&&(cmbavGridactions.Visible!=0) ? " onblur=\""+""+";gx.evt.onblur(this,120);\"" : " "),(string)"",(bool)true,(short)1});
            cmbavGridactions.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV66GridActions), 4, 0));
            AssignProp("", false, cmbavGridactions_Internalname, "Values", (string)(cmbavGridactions.ToJavascriptSource()), !bGXsfl_119_Refreshing);
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"left"+"\""+" style=\""+""+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtCodigoId_Internalname,(string)A2431CodigoId,(string)"",(string)"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtCodigoId_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn hidden-xs",(string)"",(short)-1,(short)0,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)25,(short)0,(short)0,(short)119,(short)1,(short)-1,(short)-1,(bool)true,(string)"",(string)"left",(bool)true,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"left"+"\""+" style=\""+""+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtReloj_Nombre_Internalname,(string)A2592Reloj_Nombre,(string)"",(string)"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)edtReloj_Nombre_Link,(string)"",(string)"",(string)"",(string)edtReloj_Nombre_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn hidden-xs",(string)"",(short)-1,(short)0,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)50,(short)0,(short)0,(short)119,(short)1,(short)-1,(short)-1,(bool)true,(string)"",(string)"left",(bool)true,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"right"+"\""+" style=\""+""+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtLectura_Ini_Internalname,context.localUtil.TToC( A2415Lectura_Ini, 10, 8, 0, 3, "/", ":", " "),context.localUtil.Format( A2415Lectura_Ini, "99/99/9999 99:99:99"),(string)"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtLectura_Ini_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn hidden-xs",(string)"",(short)-1,(short)0,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)19,(short)0,(short)0,(short)119,(short)1,(short)-1,(short)0,(bool)true,(string)"",(string)"right",(bool)false,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"left"+"\""+" style=\""+""+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtRHTrabajadorNombres_Internalname,(string)A2590RHTrabajadorNombres,(string)"",(string)"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)edtRHTrabajadorNombres_Link,(string)"",(string)"",(string)"",(string)edtRHTrabajadorNombres_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn",(string)"",(short)-1,(short)0,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)300,(short)0,(short)0,(short)119,(short)1,(short)-1,(short)-1,(bool)true,(string)"",(string)"left",(bool)true,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"left"+"\""+" style=\""+""+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtHorarioDescripcion_Internalname,(string)A2593HorarioDescripcion,(string)"",(string)"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)edtHorarioDescripcion_Link,(string)"",(string)"",(string)"",(string)edtHorarioDescripcion_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn hidden-xs",(string)"",(short)-1,(short)0,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)100,(short)0,(short)0,(short)119,(short)1,(short)-1,(short)-1,(bool)true,(string)"",(string)"left",(bool)true,(string)""});
            send_integrity_lvl_hashes7M2( ) ;
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
         cmbavDynamicfiltersselector1.addItem("RHTRABAJADORNOMBRES", "Nombres", 0);
         cmbavDynamicfiltersselector1.addItem("RELOJ_NOMBRE", "Reloj_Nombre", 0);
         cmbavDynamicfiltersselector1.addItem("HORARIODESCRIPCION", "Horario", 0);
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
         cmbavDynamicfiltersselector2.addItem("RHTRABAJADORNOMBRES", "Nombres", 0);
         cmbavDynamicfiltersselector2.addItem("RELOJ_NOMBRE", "Reloj_Nombre", 0);
         cmbavDynamicfiltersselector2.addItem("HORARIODESCRIPCION", "Horario", 0);
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
         cmbavDynamicfiltersselector3.Name = "vDYNAMICFILTERSSELECTOR3";
         cmbavDynamicfiltersselector3.WebTags = "";
         cmbavDynamicfiltersselector3.addItem("RHTRABAJADORNOMBRES", "Nombres", 0);
         cmbavDynamicfiltersselector3.addItem("RELOJ_NOMBRE", "Reloj_Nombre", 0);
         cmbavDynamicfiltersselector3.addItem("HORARIODESCRIPCION", "Horario", 0);
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
         GXCCtl = "vGRIDACTIONS_" + sGXsfl_119_idx;
         cmbavGridactions.Name = GXCCtl;
         cmbavGridactions.WebTags = "";
         if ( cmbavGridactions.ItemCount > 0 )
         {
            AV66GridActions = (short)(NumberUtil.Val( cmbavGridactions.getValidValue(StringUtil.Trim( StringUtil.Str( (decimal)(AV66GridActions), 4, 0))), "."));
            AssignAttri("", false, cmbavGridactions_Internalname, StringUtil.LTrimStr( (decimal)(AV66GridActions), 4, 0));
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
         edtavRhtrabajadornombres1_Internalname = "vRHTRABAJADORNOMBRES1";
         cellFilter_rhtrabajadornombres1_cell_Internalname = "FILTER_RHTRABAJADORNOMBRES1_CELL";
         edtavReloj_nombre1_Internalname = "vRELOJ_NOMBRE1";
         cellFilter_reloj_nombre1_cell_Internalname = "FILTER_RELOJ_NOMBRE1_CELL";
         edtavHorariodescripcion1_Internalname = "vHORARIODESCRIPCION1";
         cellFilter_horariodescripcion1_cell_Internalname = "FILTER_HORARIODESCRIPCION1_CELL";
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
         edtavRhtrabajadornombres2_Internalname = "vRHTRABAJADORNOMBRES2";
         cellFilter_rhtrabajadornombres2_cell_Internalname = "FILTER_RHTRABAJADORNOMBRES2_CELL";
         edtavReloj_nombre2_Internalname = "vRELOJ_NOMBRE2";
         cellFilter_reloj_nombre2_cell_Internalname = "FILTER_RELOJ_NOMBRE2_CELL";
         edtavHorariodescripcion2_Internalname = "vHORARIODESCRIPCION2";
         cellFilter_horariodescripcion2_cell_Internalname = "FILTER_HORARIODESCRIPCION2_CELL";
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
         edtavRhtrabajadornombres3_Internalname = "vRHTRABAJADORNOMBRES3";
         cellFilter_rhtrabajadornombres3_cell_Internalname = "FILTER_RHTRABAJADORNOMBRES3_CELL";
         edtavReloj_nombre3_Internalname = "vRELOJ_NOMBRE3";
         cellFilter_reloj_nombre3_cell_Internalname = "FILTER_RELOJ_NOMBRE3_CELL";
         edtavHorariodescripcion3_Internalname = "vHORARIODESCRIPCION3";
         cellFilter_horariodescripcion3_cell_Internalname = "FILTER_HORARIODESCRIPCION3_CELL";
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
         edtCodigoId_Internalname = "CODIGOID";
         edtReloj_Nombre_Internalname = "RELOJ_NOMBRE";
         edtLectura_Ini_Internalname = "LECTURA_INI";
         edtRHTrabajadorNombres_Internalname = "RHTRABAJADORNOMBRES";
         edtHorarioDescripcion_Internalname = "HORARIODESCRIPCION";
         Gridpaginationbar_Internalname = "GRIDPAGINATIONBAR";
         divGridtablewithpaginationbar_Internalname = "GRIDTABLEWITHPAGINATIONBAR";
         divTablemain_Internalname = "TABLEMAIN";
         Ddo_agexport_Internalname = "DDO_AGEXPORT";
         lblJsdynamicfilters_Internalname = "JSDYNAMICFILTERS";
         Ddo_grid_Internalname = "DDO_GRID";
         Innewwindow1_Internalname = "INNEWWINDOW1";
         Grid_empowerer_Internalname = "GRID_EMPOWERER";
         edtavDdo_lectura_iniauxdatetext_Internalname = "vDDO_LECTURA_INIAUXDATETEXT";
         Tflectura_ini_rangepicker_Internalname = "TFLECTURA_INI_RANGEPICKER";
         divDdo_lectura_iniauxdates_Internalname = "DDO_LECTURA_INIAUXDATES";
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
         edtHorarioDescripcion_Jsonclick = "";
         edtRHTrabajadorNombres_Jsonclick = "";
         edtLectura_Ini_Jsonclick = "";
         edtReloj_Nombre_Jsonclick = "";
         edtCodigoId_Jsonclick = "";
         cmbavGridactions_Jsonclick = "";
         cmbavGridactions.Visible = -1;
         cmbavGridactions.Enabled = 1;
         imgRemovedynamicfilters1_Visible = 1;
         imgAdddynamicfilters1_Visible = 1;
         edtavHorariodescripcion1_Jsonclick = "";
         edtavHorariodescripcion1_Enabled = 1;
         edtavReloj_nombre1_Jsonclick = "";
         edtavReloj_nombre1_Enabled = 1;
         edtavRhtrabajadornombres1_Enabled = 1;
         cmbavDynamicfiltersoperator1_Jsonclick = "";
         cmbavDynamicfiltersoperator1.Enabled = 1;
         imgRemovedynamicfilters2_Visible = 1;
         imgAdddynamicfilters2_Visible = 1;
         edtavHorariodescripcion2_Jsonclick = "";
         edtavHorariodescripcion2_Enabled = 1;
         edtavReloj_nombre2_Jsonclick = "";
         edtavReloj_nombre2_Enabled = 1;
         edtavRhtrabajadornombres2_Enabled = 1;
         cmbavDynamicfiltersoperator2_Jsonclick = "";
         cmbavDynamicfiltersoperator2.Enabled = 1;
         edtavHorariodescripcion3_Jsonclick = "";
         edtavHorariodescripcion3_Enabled = 1;
         edtavReloj_nombre3_Jsonclick = "";
         edtavReloj_nombre3_Enabled = 1;
         edtavRhtrabajadornombres3_Enabled = 1;
         cmbavDynamicfiltersoperator3_Jsonclick = "";
         cmbavDynamicfiltersoperator3.Enabled = 1;
         cmbavDynamicfiltersselector3_Jsonclick = "";
         cmbavDynamicfiltersselector3.Enabled = 1;
         cmbavDynamicfiltersselector2_Jsonclick = "";
         cmbavDynamicfiltersselector2.Enabled = 1;
         cmbavDynamicfiltersselector1_Jsonclick = "";
         cmbavDynamicfiltersselector1.Enabled = 1;
         cmbavDynamicfiltersoperator3.Visible = 1;
         edtavHorariodescripcion3_Visible = 1;
         edtavReloj_nombre3_Visible = 1;
         edtavRhtrabajadornombres3_Visible = 1;
         cmbavDynamicfiltersoperator2.Visible = 1;
         edtavHorariodescripcion2_Visible = 1;
         edtavReloj_nombre2_Visible = 1;
         edtavRhtrabajadornombres2_Visible = 1;
         cmbavDynamicfiltersoperator1.Visible = 1;
         edtavHorariodescripcion1_Visible = 1;
         edtavReloj_nombre1_Visible = 1;
         edtavRhtrabajadornombres1_Visible = 1;
         edtavDdo_lectura_iniauxdatetext_Jsonclick = "";
         lblJsdynamicfilters_Caption = "JSDynamicFilters";
         subGrid_Allowcollapsing = 0;
         subGrid_Allowselection = 0;
         edtHorarioDescripcion_Link = "";
         edtRHTrabajadorNombres_Link = "";
         edtReloj_Nombre_Link = "";
         subGrid_Sortable = 0;
         subGrid_Header = "";
         subGrid_Class = "GridWithPaginationBar WorkWith";
         subGrid_Backcolorstyle = 0;
         Grid_empowerer_Hastitlesettings = Convert.ToBoolean( -1);
         Innewwindow1_Target = "";
         Innewwindow1_Height = "50";
         Innewwindow1_Width = "50";
         Ddo_grid_Datalistproc = "Reloj_Interface.Reloj_CodigoIDWWGetFilterData";
         Ddo_grid_Datalisttype = "Dynamic|Dynamic||Dynamic|Dynamic";
         Ddo_grid_Includedatalist = "T|T||T|T";
         Ddo_grid_Filterisrange = "||P||";
         Ddo_grid_Filtertype = "Character|Character|Date|Character|Character";
         Ddo_grid_Includefilter = "T";
         Ddo_grid_Includesortasc = "T";
         Ddo_grid_Columnssortvalues = "2|3|4|1|5";
         Ddo_grid_Columnids = "1:CodigoId|2:Reloj_Nombre|3:Lectura_Ini|4:RHTrabajadorNombres|5:HorarioDescripcion";
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
         Form.Caption = "Codigos Registrados en Reloj";
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
         setEventMetadata("REFRESH","{handler:'Refresh',iparms:[{av:'GRID_nFirstRecordOnPage'},{av:'GRID_nEOF'},{av:'cmbavDynamicfiltersselector1'},{av:'AV15DynamicFiltersSelector1',fld:'vDYNAMICFILTERSSELECTOR1',pic:''},{av:'AV20DynamicFiltersEnabled2',fld:'vDYNAMICFILTERSENABLED2',pic:''},{av:'cmbavDynamicfiltersselector2'},{av:'AV21DynamicFiltersSelector2',fld:'vDYNAMICFILTERSSELECTOR2',pic:''},{av:'AV26DynamicFiltersEnabled3',fld:'vDYNAMICFILTERSENABLED3',pic:''},{av:'cmbavDynamicfiltersselector3'},{av:'AV27DynamicFiltersSelector3',fld:'vDYNAMICFILTERSSELECTOR3',pic:''},{av:'subGrid_Rows',ctrl:'GRID',prop:'Rows'},{av:'cmbavDynamicfiltersoperator1'},{av:'AV16DynamicFiltersOperator1',fld:'vDYNAMICFILTERSOPERATOR1',pic:'ZZZ9'},{av:'AV17RHTrabajadorNombres1',fld:'vRHTRABAJADORNOMBRES1',pic:''},{av:'AV18Reloj_Nombre1',fld:'vRELOJ_NOMBRE1',pic:''},{av:'AV19HorarioDescripcion1',fld:'vHORARIODESCRIPCION1',pic:''},{av:'cmbavDynamicfiltersoperator2'},{av:'AV22DynamicFiltersOperator2',fld:'vDYNAMICFILTERSOPERATOR2',pic:'ZZZ9'},{av:'AV23RHTrabajadorNombres2',fld:'vRHTRABAJADORNOMBRES2',pic:''},{av:'AV24Reloj_Nombre2',fld:'vRELOJ_NOMBRE2',pic:''},{av:'AV25HorarioDescripcion2',fld:'vHORARIODESCRIPCION2',pic:''},{av:'cmbavDynamicfiltersoperator3'},{av:'AV28DynamicFiltersOperator3',fld:'vDYNAMICFILTERSOPERATOR3',pic:'ZZZ9'},{av:'AV29RHTrabajadorNombres3',fld:'vRHTRABAJADORNOMBRES3',pic:''},{av:'AV30Reloj_Nombre3',fld:'vRELOJ_NOMBRE3',pic:''},{av:'AV31HorarioDescripcion3',fld:'vHORARIODESCRIPCION3',pic:''},{av:'AV71Pgmname',fld:'vPGMNAME',pic:'',hsh:true},{av:'AV37TFCodigoId',fld:'vTFCODIGOID',pic:''},{av:'AV38TFCodigoId_Sel',fld:'vTFCODIGOID_SEL',pic:''},{av:'AV41TFReloj_Nombre',fld:'vTFRELOJ_NOMBRE',pic:''},{av:'AV42TFReloj_Nombre_Sel',fld:'vTFRELOJ_NOMBRE_SEL',pic:''},{av:'AV43TFLectura_Ini',fld:'vTFLECTURA_INI',pic:'99/99/9999 99:99:99'},{av:'AV44TFLectura_Ini_To',fld:'vTFLECTURA_INI_TO',pic:'99/99/9999 99:99:99'},{av:'AV55TFRHTrabajadorNombres',fld:'vTFRHTRABAJADORNOMBRES',pic:''},{av:'AV56TFRHTrabajadorNombres_Sel',fld:'vTFRHTRABAJADORNOMBRES_SEL',pic:''},{av:'AV59TFHorarioDescripcion',fld:'vTFHORARIODESCRIPCION',pic:''},{av:'AV60TFHorarioDescripcion_Sel',fld:'vTFHORARIODESCRIPCION_SEL',pic:''},{av:'AV13OrderedBy',fld:'vORDEREDBY',pic:'ZZZ9'},{av:'AV14OrderedDsc',fld:'vORDEREDDSC',pic:''},{av:'AV10GridState',fld:'vGRIDSTATE',pic:''},{av:'AV33DynamicFiltersIgnoreFirst',fld:'vDYNAMICFILTERSIGNOREFIRST',pic:''},{av:'AV32DynamicFiltersRemoving',fld:'vDYNAMICFILTERSREMOVING',pic:''}]");
         setEventMetadata("REFRESH",",oparms:[{av:'cmbavDynamicfiltersoperator1'},{av:'AV16DynamicFiltersOperator1',fld:'vDYNAMICFILTERSOPERATOR1',pic:'ZZZ9'},{av:'cmbavDynamicfiltersoperator2'},{av:'AV22DynamicFiltersOperator2',fld:'vDYNAMICFILTERSOPERATOR2',pic:'ZZZ9'},{av:'cmbavDynamicfiltersoperator3'},{av:'AV28DynamicFiltersOperator3',fld:'vDYNAMICFILTERSOPERATOR3',pic:'ZZZ9'},{av:'AV63GridCurrentPage',fld:'vGRIDCURRENTPAGE',pic:'ZZZZZZZZZ9'},{av:'AV64GridPageCount',fld:'vGRIDPAGECOUNT',pic:'ZZZZZZZZZ9'},{av:'AV65GridAppliedFilters',fld:'vGRIDAPPLIEDFILTERS',pic:''},{av:'AV10GridState',fld:'vGRIDSTATE',pic:''}]}");
         setEventMetadata("GRIDPAGINATIONBAR.CHANGEPAGE","{handler:'E117M2',iparms:[{av:'GRID_nFirstRecordOnPage'},{av:'GRID_nEOF'},{av:'subGrid_Rows',ctrl:'GRID',prop:'Rows'},{av:'cmbavDynamicfiltersselector1'},{av:'AV15DynamicFiltersSelector1',fld:'vDYNAMICFILTERSSELECTOR1',pic:''},{av:'cmbavDynamicfiltersoperator1'},{av:'AV16DynamicFiltersOperator1',fld:'vDYNAMICFILTERSOPERATOR1',pic:'ZZZ9'},{av:'AV17RHTrabajadorNombres1',fld:'vRHTRABAJADORNOMBRES1',pic:''},{av:'AV18Reloj_Nombre1',fld:'vRELOJ_NOMBRE1',pic:''},{av:'AV19HorarioDescripcion1',fld:'vHORARIODESCRIPCION1',pic:''},{av:'cmbavDynamicfiltersselector2'},{av:'AV21DynamicFiltersSelector2',fld:'vDYNAMICFILTERSSELECTOR2',pic:''},{av:'cmbavDynamicfiltersoperator2'},{av:'AV22DynamicFiltersOperator2',fld:'vDYNAMICFILTERSOPERATOR2',pic:'ZZZ9'},{av:'AV23RHTrabajadorNombres2',fld:'vRHTRABAJADORNOMBRES2',pic:''},{av:'AV24Reloj_Nombre2',fld:'vRELOJ_NOMBRE2',pic:''},{av:'AV25HorarioDescripcion2',fld:'vHORARIODESCRIPCION2',pic:''},{av:'cmbavDynamicfiltersselector3'},{av:'AV27DynamicFiltersSelector3',fld:'vDYNAMICFILTERSSELECTOR3',pic:''},{av:'cmbavDynamicfiltersoperator3'},{av:'AV28DynamicFiltersOperator3',fld:'vDYNAMICFILTERSOPERATOR3',pic:'ZZZ9'},{av:'AV29RHTrabajadorNombres3',fld:'vRHTRABAJADORNOMBRES3',pic:''},{av:'AV30Reloj_Nombre3',fld:'vRELOJ_NOMBRE3',pic:''},{av:'AV31HorarioDescripcion3',fld:'vHORARIODESCRIPCION3',pic:''},{av:'AV20DynamicFiltersEnabled2',fld:'vDYNAMICFILTERSENABLED2',pic:''},{av:'AV26DynamicFiltersEnabled3',fld:'vDYNAMICFILTERSENABLED3',pic:''},{av:'AV71Pgmname',fld:'vPGMNAME',pic:'',hsh:true},{av:'AV37TFCodigoId',fld:'vTFCODIGOID',pic:''},{av:'AV38TFCodigoId_Sel',fld:'vTFCODIGOID_SEL',pic:''},{av:'AV41TFReloj_Nombre',fld:'vTFRELOJ_NOMBRE',pic:''},{av:'AV42TFReloj_Nombre_Sel',fld:'vTFRELOJ_NOMBRE_SEL',pic:''},{av:'AV43TFLectura_Ini',fld:'vTFLECTURA_INI',pic:'99/99/9999 99:99:99'},{av:'AV44TFLectura_Ini_To',fld:'vTFLECTURA_INI_TO',pic:'99/99/9999 99:99:99'},{av:'AV55TFRHTrabajadorNombres',fld:'vTFRHTRABAJADORNOMBRES',pic:''},{av:'AV56TFRHTrabajadorNombres_Sel',fld:'vTFRHTRABAJADORNOMBRES_SEL',pic:''},{av:'AV59TFHorarioDescripcion',fld:'vTFHORARIODESCRIPCION',pic:''},{av:'AV60TFHorarioDescripcion_Sel',fld:'vTFHORARIODESCRIPCION_SEL',pic:''},{av:'AV13OrderedBy',fld:'vORDEREDBY',pic:'ZZZ9'},{av:'AV14OrderedDsc',fld:'vORDEREDDSC',pic:''},{av:'AV10GridState',fld:'vGRIDSTATE',pic:''},{av:'AV33DynamicFiltersIgnoreFirst',fld:'vDYNAMICFILTERSIGNOREFIRST',pic:''},{av:'AV32DynamicFiltersRemoving',fld:'vDYNAMICFILTERSREMOVING',pic:''},{av:'Gridpaginationbar_Selectedpage',ctrl:'GRIDPAGINATIONBAR',prop:'SelectedPage'}]");
         setEventMetadata("GRIDPAGINATIONBAR.CHANGEPAGE",",oparms:[]}");
         setEventMetadata("GRIDPAGINATIONBAR.CHANGEROWSPERPAGE","{handler:'E127M2',iparms:[{av:'GRID_nFirstRecordOnPage'},{av:'GRID_nEOF'},{av:'subGrid_Rows',ctrl:'GRID',prop:'Rows'},{av:'cmbavDynamicfiltersselector1'},{av:'AV15DynamicFiltersSelector1',fld:'vDYNAMICFILTERSSELECTOR1',pic:''},{av:'cmbavDynamicfiltersoperator1'},{av:'AV16DynamicFiltersOperator1',fld:'vDYNAMICFILTERSOPERATOR1',pic:'ZZZ9'},{av:'AV17RHTrabajadorNombres1',fld:'vRHTRABAJADORNOMBRES1',pic:''},{av:'AV18Reloj_Nombre1',fld:'vRELOJ_NOMBRE1',pic:''},{av:'AV19HorarioDescripcion1',fld:'vHORARIODESCRIPCION1',pic:''},{av:'cmbavDynamicfiltersselector2'},{av:'AV21DynamicFiltersSelector2',fld:'vDYNAMICFILTERSSELECTOR2',pic:''},{av:'cmbavDynamicfiltersoperator2'},{av:'AV22DynamicFiltersOperator2',fld:'vDYNAMICFILTERSOPERATOR2',pic:'ZZZ9'},{av:'AV23RHTrabajadorNombres2',fld:'vRHTRABAJADORNOMBRES2',pic:''},{av:'AV24Reloj_Nombre2',fld:'vRELOJ_NOMBRE2',pic:''},{av:'AV25HorarioDescripcion2',fld:'vHORARIODESCRIPCION2',pic:''},{av:'cmbavDynamicfiltersselector3'},{av:'AV27DynamicFiltersSelector3',fld:'vDYNAMICFILTERSSELECTOR3',pic:''},{av:'cmbavDynamicfiltersoperator3'},{av:'AV28DynamicFiltersOperator3',fld:'vDYNAMICFILTERSOPERATOR3',pic:'ZZZ9'},{av:'AV29RHTrabajadorNombres3',fld:'vRHTRABAJADORNOMBRES3',pic:''},{av:'AV30Reloj_Nombre3',fld:'vRELOJ_NOMBRE3',pic:''},{av:'AV31HorarioDescripcion3',fld:'vHORARIODESCRIPCION3',pic:''},{av:'AV20DynamicFiltersEnabled2',fld:'vDYNAMICFILTERSENABLED2',pic:''},{av:'AV26DynamicFiltersEnabled3',fld:'vDYNAMICFILTERSENABLED3',pic:''},{av:'AV71Pgmname',fld:'vPGMNAME',pic:'',hsh:true},{av:'AV37TFCodigoId',fld:'vTFCODIGOID',pic:''},{av:'AV38TFCodigoId_Sel',fld:'vTFCODIGOID_SEL',pic:''},{av:'AV41TFReloj_Nombre',fld:'vTFRELOJ_NOMBRE',pic:''},{av:'AV42TFReloj_Nombre_Sel',fld:'vTFRELOJ_NOMBRE_SEL',pic:''},{av:'AV43TFLectura_Ini',fld:'vTFLECTURA_INI',pic:'99/99/9999 99:99:99'},{av:'AV44TFLectura_Ini_To',fld:'vTFLECTURA_INI_TO',pic:'99/99/9999 99:99:99'},{av:'AV55TFRHTrabajadorNombres',fld:'vTFRHTRABAJADORNOMBRES',pic:''},{av:'AV56TFRHTrabajadorNombres_Sel',fld:'vTFRHTRABAJADORNOMBRES_SEL',pic:''},{av:'AV59TFHorarioDescripcion',fld:'vTFHORARIODESCRIPCION',pic:''},{av:'AV60TFHorarioDescripcion_Sel',fld:'vTFHORARIODESCRIPCION_SEL',pic:''},{av:'AV13OrderedBy',fld:'vORDEREDBY',pic:'ZZZ9'},{av:'AV14OrderedDsc',fld:'vORDEREDDSC',pic:''},{av:'AV10GridState',fld:'vGRIDSTATE',pic:''},{av:'AV33DynamicFiltersIgnoreFirst',fld:'vDYNAMICFILTERSIGNOREFIRST',pic:''},{av:'AV32DynamicFiltersRemoving',fld:'vDYNAMICFILTERSREMOVING',pic:''},{av:'Gridpaginationbar_Rowsperpageselectedvalue',ctrl:'GRIDPAGINATIONBAR',prop:'RowsPerPageSelectedValue'}]");
         setEventMetadata("GRIDPAGINATIONBAR.CHANGEROWSPERPAGE",",oparms:[{av:'subGrid_Rows',ctrl:'GRID',prop:'Rows'}]}");
         setEventMetadata("DDO_GRID.ONOPTIONCLICKED","{handler:'E147M2',iparms:[{av:'GRID_nFirstRecordOnPage'},{av:'GRID_nEOF'},{av:'subGrid_Rows',ctrl:'GRID',prop:'Rows'},{av:'cmbavDynamicfiltersselector1'},{av:'AV15DynamicFiltersSelector1',fld:'vDYNAMICFILTERSSELECTOR1',pic:''},{av:'cmbavDynamicfiltersoperator1'},{av:'AV16DynamicFiltersOperator1',fld:'vDYNAMICFILTERSOPERATOR1',pic:'ZZZ9'},{av:'AV17RHTrabajadorNombres1',fld:'vRHTRABAJADORNOMBRES1',pic:''},{av:'AV18Reloj_Nombre1',fld:'vRELOJ_NOMBRE1',pic:''},{av:'AV19HorarioDescripcion1',fld:'vHORARIODESCRIPCION1',pic:''},{av:'cmbavDynamicfiltersselector2'},{av:'AV21DynamicFiltersSelector2',fld:'vDYNAMICFILTERSSELECTOR2',pic:''},{av:'cmbavDynamicfiltersoperator2'},{av:'AV22DynamicFiltersOperator2',fld:'vDYNAMICFILTERSOPERATOR2',pic:'ZZZ9'},{av:'AV23RHTrabajadorNombres2',fld:'vRHTRABAJADORNOMBRES2',pic:''},{av:'AV24Reloj_Nombre2',fld:'vRELOJ_NOMBRE2',pic:''},{av:'AV25HorarioDescripcion2',fld:'vHORARIODESCRIPCION2',pic:''},{av:'cmbavDynamicfiltersselector3'},{av:'AV27DynamicFiltersSelector3',fld:'vDYNAMICFILTERSSELECTOR3',pic:''},{av:'cmbavDynamicfiltersoperator3'},{av:'AV28DynamicFiltersOperator3',fld:'vDYNAMICFILTERSOPERATOR3',pic:'ZZZ9'},{av:'AV29RHTrabajadorNombres3',fld:'vRHTRABAJADORNOMBRES3',pic:''},{av:'AV30Reloj_Nombre3',fld:'vRELOJ_NOMBRE3',pic:''},{av:'AV31HorarioDescripcion3',fld:'vHORARIODESCRIPCION3',pic:''},{av:'AV20DynamicFiltersEnabled2',fld:'vDYNAMICFILTERSENABLED2',pic:''},{av:'AV26DynamicFiltersEnabled3',fld:'vDYNAMICFILTERSENABLED3',pic:''},{av:'AV71Pgmname',fld:'vPGMNAME',pic:'',hsh:true},{av:'AV37TFCodigoId',fld:'vTFCODIGOID',pic:''},{av:'AV38TFCodigoId_Sel',fld:'vTFCODIGOID_SEL',pic:''},{av:'AV41TFReloj_Nombre',fld:'vTFRELOJ_NOMBRE',pic:''},{av:'AV42TFReloj_Nombre_Sel',fld:'vTFRELOJ_NOMBRE_SEL',pic:''},{av:'AV43TFLectura_Ini',fld:'vTFLECTURA_INI',pic:'99/99/9999 99:99:99'},{av:'AV44TFLectura_Ini_To',fld:'vTFLECTURA_INI_TO',pic:'99/99/9999 99:99:99'},{av:'AV55TFRHTrabajadorNombres',fld:'vTFRHTRABAJADORNOMBRES',pic:''},{av:'AV56TFRHTrabajadorNombres_Sel',fld:'vTFRHTRABAJADORNOMBRES_SEL',pic:''},{av:'AV59TFHorarioDescripcion',fld:'vTFHORARIODESCRIPCION',pic:''},{av:'AV60TFHorarioDescripcion_Sel',fld:'vTFHORARIODESCRIPCION_SEL',pic:''},{av:'AV13OrderedBy',fld:'vORDEREDBY',pic:'ZZZ9'},{av:'AV14OrderedDsc',fld:'vORDEREDDSC',pic:''},{av:'AV10GridState',fld:'vGRIDSTATE',pic:''},{av:'AV33DynamicFiltersIgnoreFirst',fld:'vDYNAMICFILTERSIGNOREFIRST',pic:''},{av:'AV32DynamicFiltersRemoving',fld:'vDYNAMICFILTERSREMOVING',pic:''},{av:'Ddo_grid_Activeeventkey',ctrl:'DDO_GRID',prop:'ActiveEventKey'},{av:'Ddo_grid_Selectedvalue_get',ctrl:'DDO_GRID',prop:'SelectedValue_get'},{av:'Ddo_grid_Selectedcolumn',ctrl:'DDO_GRID',prop:'SelectedColumn'},{av:'Ddo_grid_Filteredtext_get',ctrl:'DDO_GRID',prop:'FilteredText_get'},{av:'Ddo_grid_Filteredtextto_get',ctrl:'DDO_GRID',prop:'FilteredTextTo_get'}]");
         setEventMetadata("DDO_GRID.ONOPTIONCLICKED",",oparms:[{av:'AV13OrderedBy',fld:'vORDEREDBY',pic:'ZZZ9'},{av:'AV14OrderedDsc',fld:'vORDEREDDSC',pic:''},{av:'AV37TFCodigoId',fld:'vTFCODIGOID',pic:''},{av:'AV38TFCodigoId_Sel',fld:'vTFCODIGOID_SEL',pic:''},{av:'AV41TFReloj_Nombre',fld:'vTFRELOJ_NOMBRE',pic:''},{av:'AV42TFReloj_Nombre_Sel',fld:'vTFRELOJ_NOMBRE_SEL',pic:''},{av:'AV43TFLectura_Ini',fld:'vTFLECTURA_INI',pic:'99/99/9999 99:99:99'},{av:'AV44TFLectura_Ini_To',fld:'vTFLECTURA_INI_TO',pic:'99/99/9999 99:99:99'},{av:'AV55TFRHTrabajadorNombres',fld:'vTFRHTRABAJADORNOMBRES',pic:''},{av:'AV56TFRHTrabajadorNombres_Sel',fld:'vTFRHTRABAJADORNOMBRES_SEL',pic:''},{av:'AV59TFHorarioDescripcion',fld:'vTFHORARIODESCRIPCION',pic:''},{av:'AV60TFHorarioDescripcion_Sel',fld:'vTFHORARIODESCRIPCION_SEL',pic:''},{av:'Ddo_grid_Sortedstatus',ctrl:'DDO_GRID',prop:'SortedStatus'}]}");
         setEventMetadata("GRID.LOAD","{handler:'E267M2',iparms:[{av:'A2498Reloj_ID',fld:'RELOJ_ID',pic:'ZZZ9'},{av:'A2431CodigoId',fld:'CODIGOID',pic:'',hsh:true},{av:'A2591HorarioID',fld:'HORARIOID',pic:'ZZZ9'}]");
         setEventMetadata("GRID.LOAD",",oparms:[{av:'cmbavGridactions'},{av:'AV66GridActions',fld:'vGRIDACTIONS',pic:'ZZZ9'},{av:'edtReloj_Nombre_Link',ctrl:'RELOJ_NOMBRE',prop:'Link'},{av:'edtRHTrabajadorNombres_Link',ctrl:'RHTRABAJADORNOMBRES',prop:'Link'},{av:'edtHorarioDescripcion_Link',ctrl:'HORARIODESCRIPCION',prop:'Link'}]}");
         setEventMetadata("'ADDDYNAMICFILTERS1'","{handler:'E197M2',iparms:[{av:'GRID_nFirstRecordOnPage'},{av:'GRID_nEOF'},{av:'subGrid_Rows',ctrl:'GRID',prop:'Rows'},{av:'cmbavDynamicfiltersselector1'},{av:'AV15DynamicFiltersSelector1',fld:'vDYNAMICFILTERSSELECTOR1',pic:''},{av:'cmbavDynamicfiltersoperator1'},{av:'AV16DynamicFiltersOperator1',fld:'vDYNAMICFILTERSOPERATOR1',pic:'ZZZ9'},{av:'AV17RHTrabajadorNombres1',fld:'vRHTRABAJADORNOMBRES1',pic:''},{av:'AV18Reloj_Nombre1',fld:'vRELOJ_NOMBRE1',pic:''},{av:'AV19HorarioDescripcion1',fld:'vHORARIODESCRIPCION1',pic:''},{av:'cmbavDynamicfiltersselector2'},{av:'AV21DynamicFiltersSelector2',fld:'vDYNAMICFILTERSSELECTOR2',pic:''},{av:'cmbavDynamicfiltersoperator2'},{av:'AV22DynamicFiltersOperator2',fld:'vDYNAMICFILTERSOPERATOR2',pic:'ZZZ9'},{av:'AV23RHTrabajadorNombres2',fld:'vRHTRABAJADORNOMBRES2',pic:''},{av:'AV24Reloj_Nombre2',fld:'vRELOJ_NOMBRE2',pic:''},{av:'AV25HorarioDescripcion2',fld:'vHORARIODESCRIPCION2',pic:''},{av:'cmbavDynamicfiltersselector3'},{av:'AV27DynamicFiltersSelector3',fld:'vDYNAMICFILTERSSELECTOR3',pic:''},{av:'cmbavDynamicfiltersoperator3'},{av:'AV28DynamicFiltersOperator3',fld:'vDYNAMICFILTERSOPERATOR3',pic:'ZZZ9'},{av:'AV29RHTrabajadorNombres3',fld:'vRHTRABAJADORNOMBRES3',pic:''},{av:'AV30Reloj_Nombre3',fld:'vRELOJ_NOMBRE3',pic:''},{av:'AV31HorarioDescripcion3',fld:'vHORARIODESCRIPCION3',pic:''},{av:'AV20DynamicFiltersEnabled2',fld:'vDYNAMICFILTERSENABLED2',pic:''},{av:'AV26DynamicFiltersEnabled3',fld:'vDYNAMICFILTERSENABLED3',pic:''},{av:'AV71Pgmname',fld:'vPGMNAME',pic:'',hsh:true},{av:'AV37TFCodigoId',fld:'vTFCODIGOID',pic:''},{av:'AV38TFCodigoId_Sel',fld:'vTFCODIGOID_SEL',pic:''},{av:'AV41TFReloj_Nombre',fld:'vTFRELOJ_NOMBRE',pic:''},{av:'AV42TFReloj_Nombre_Sel',fld:'vTFRELOJ_NOMBRE_SEL',pic:''},{av:'AV43TFLectura_Ini',fld:'vTFLECTURA_INI',pic:'99/99/9999 99:99:99'},{av:'AV44TFLectura_Ini_To',fld:'vTFLECTURA_INI_TO',pic:'99/99/9999 99:99:99'},{av:'AV55TFRHTrabajadorNombres',fld:'vTFRHTRABAJADORNOMBRES',pic:''},{av:'AV56TFRHTrabajadorNombres_Sel',fld:'vTFRHTRABAJADORNOMBRES_SEL',pic:''},{av:'AV59TFHorarioDescripcion',fld:'vTFHORARIODESCRIPCION',pic:''},{av:'AV60TFHorarioDescripcion_Sel',fld:'vTFHORARIODESCRIPCION_SEL',pic:''},{av:'AV13OrderedBy',fld:'vORDEREDBY',pic:'ZZZ9'},{av:'AV14OrderedDsc',fld:'vORDEREDDSC',pic:''},{av:'AV10GridState',fld:'vGRIDSTATE',pic:''},{av:'AV33DynamicFiltersIgnoreFirst',fld:'vDYNAMICFILTERSIGNOREFIRST',pic:''},{av:'AV32DynamicFiltersRemoving',fld:'vDYNAMICFILTERSREMOVING',pic:''}]");
         setEventMetadata("'ADDDYNAMICFILTERS1'",",oparms:[{av:'AV20DynamicFiltersEnabled2',fld:'vDYNAMICFILTERSENABLED2',pic:''},{av:'imgAdddynamicfilters1_Visible',ctrl:'ADDDYNAMICFILTERS1',prop:'Visible'},{av:'imgRemovedynamicfilters1_Visible',ctrl:'REMOVEDYNAMICFILTERS1',prop:'Visible'},{av:'cmbavDynamicfiltersoperator1'},{av:'AV16DynamicFiltersOperator1',fld:'vDYNAMICFILTERSOPERATOR1',pic:'ZZZ9'},{av:'cmbavDynamicfiltersoperator2'},{av:'AV22DynamicFiltersOperator2',fld:'vDYNAMICFILTERSOPERATOR2',pic:'ZZZ9'},{av:'cmbavDynamicfiltersoperator3'},{av:'AV28DynamicFiltersOperator3',fld:'vDYNAMICFILTERSOPERATOR3',pic:'ZZZ9'},{av:'AV63GridCurrentPage',fld:'vGRIDCURRENTPAGE',pic:'ZZZZZZZZZ9'},{av:'AV64GridPageCount',fld:'vGRIDPAGECOUNT',pic:'ZZZZZZZZZ9'},{av:'AV65GridAppliedFilters',fld:'vGRIDAPPLIEDFILTERS',pic:''},{av:'AV10GridState',fld:'vGRIDSTATE',pic:''}]}");
         setEventMetadata("'REMOVEDYNAMICFILTERS1'","{handler:'E157M2',iparms:[{av:'GRID_nFirstRecordOnPage'},{av:'GRID_nEOF'},{av:'subGrid_Rows',ctrl:'GRID',prop:'Rows'},{av:'cmbavDynamicfiltersselector1'},{av:'AV15DynamicFiltersSelector1',fld:'vDYNAMICFILTERSSELECTOR1',pic:''},{av:'cmbavDynamicfiltersoperator1'},{av:'AV16DynamicFiltersOperator1',fld:'vDYNAMICFILTERSOPERATOR1',pic:'ZZZ9'},{av:'AV17RHTrabajadorNombres1',fld:'vRHTRABAJADORNOMBRES1',pic:''},{av:'AV18Reloj_Nombre1',fld:'vRELOJ_NOMBRE1',pic:''},{av:'AV19HorarioDescripcion1',fld:'vHORARIODESCRIPCION1',pic:''},{av:'cmbavDynamicfiltersselector2'},{av:'AV21DynamicFiltersSelector2',fld:'vDYNAMICFILTERSSELECTOR2',pic:''},{av:'cmbavDynamicfiltersoperator2'},{av:'AV22DynamicFiltersOperator2',fld:'vDYNAMICFILTERSOPERATOR2',pic:'ZZZ9'},{av:'AV23RHTrabajadorNombres2',fld:'vRHTRABAJADORNOMBRES2',pic:''},{av:'AV24Reloj_Nombre2',fld:'vRELOJ_NOMBRE2',pic:''},{av:'AV25HorarioDescripcion2',fld:'vHORARIODESCRIPCION2',pic:''},{av:'cmbavDynamicfiltersselector3'},{av:'AV27DynamicFiltersSelector3',fld:'vDYNAMICFILTERSSELECTOR3',pic:''},{av:'cmbavDynamicfiltersoperator3'},{av:'AV28DynamicFiltersOperator3',fld:'vDYNAMICFILTERSOPERATOR3',pic:'ZZZ9'},{av:'AV29RHTrabajadorNombres3',fld:'vRHTRABAJADORNOMBRES3',pic:''},{av:'AV30Reloj_Nombre3',fld:'vRELOJ_NOMBRE3',pic:''},{av:'AV31HorarioDescripcion3',fld:'vHORARIODESCRIPCION3',pic:''},{av:'AV20DynamicFiltersEnabled2',fld:'vDYNAMICFILTERSENABLED2',pic:''},{av:'AV26DynamicFiltersEnabled3',fld:'vDYNAMICFILTERSENABLED3',pic:''},{av:'AV71Pgmname',fld:'vPGMNAME',pic:'',hsh:true},{av:'AV37TFCodigoId',fld:'vTFCODIGOID',pic:''},{av:'AV38TFCodigoId_Sel',fld:'vTFCODIGOID_SEL',pic:''},{av:'AV41TFReloj_Nombre',fld:'vTFRELOJ_NOMBRE',pic:''},{av:'AV42TFReloj_Nombre_Sel',fld:'vTFRELOJ_NOMBRE_SEL',pic:''},{av:'AV43TFLectura_Ini',fld:'vTFLECTURA_INI',pic:'99/99/9999 99:99:99'},{av:'AV44TFLectura_Ini_To',fld:'vTFLECTURA_INI_TO',pic:'99/99/9999 99:99:99'},{av:'AV55TFRHTrabajadorNombres',fld:'vTFRHTRABAJADORNOMBRES',pic:''},{av:'AV56TFRHTrabajadorNombres_Sel',fld:'vTFRHTRABAJADORNOMBRES_SEL',pic:''},{av:'AV59TFHorarioDescripcion',fld:'vTFHORARIODESCRIPCION',pic:''},{av:'AV60TFHorarioDescripcion_Sel',fld:'vTFHORARIODESCRIPCION_SEL',pic:''},{av:'AV13OrderedBy',fld:'vORDEREDBY',pic:'ZZZ9'},{av:'AV14OrderedDsc',fld:'vORDEREDDSC',pic:''},{av:'AV10GridState',fld:'vGRIDSTATE',pic:''},{av:'AV33DynamicFiltersIgnoreFirst',fld:'vDYNAMICFILTERSIGNOREFIRST',pic:''},{av:'AV32DynamicFiltersRemoving',fld:'vDYNAMICFILTERSREMOVING',pic:''}]");
         setEventMetadata("'REMOVEDYNAMICFILTERS1'",",oparms:[{av:'AV32DynamicFiltersRemoving',fld:'vDYNAMICFILTERSREMOVING',pic:''},{av:'AV33DynamicFiltersIgnoreFirst',fld:'vDYNAMICFILTERSIGNOREFIRST',pic:''},{av:'AV10GridState',fld:'vGRIDSTATE',pic:''},{av:'AV20DynamicFiltersEnabled2',fld:'vDYNAMICFILTERSENABLED2',pic:''},{av:'cmbavDynamicfiltersselector2'},{av:'AV21DynamicFiltersSelector2',fld:'vDYNAMICFILTERSSELECTOR2',pic:''},{av:'cmbavDynamicfiltersoperator2'},{av:'AV22DynamicFiltersOperator2',fld:'vDYNAMICFILTERSOPERATOR2',pic:'ZZZ9'},{av:'AV23RHTrabajadorNombres2',fld:'vRHTRABAJADORNOMBRES2',pic:''},{av:'AV26DynamicFiltersEnabled3',fld:'vDYNAMICFILTERSENABLED3',pic:''},{av:'cmbavDynamicfiltersselector3'},{av:'AV27DynamicFiltersSelector3',fld:'vDYNAMICFILTERSSELECTOR3',pic:''},{av:'cmbavDynamicfiltersoperator3'},{av:'AV28DynamicFiltersOperator3',fld:'vDYNAMICFILTERSOPERATOR3',pic:'ZZZ9'},{av:'AV29RHTrabajadorNombres3',fld:'vRHTRABAJADORNOMBRES3',pic:''},{av:'imgAdddynamicfilters1_Visible',ctrl:'ADDDYNAMICFILTERS1',prop:'Visible'},{av:'imgRemovedynamicfilters1_Visible',ctrl:'REMOVEDYNAMICFILTERS1',prop:'Visible'},{av:'imgAdddynamicfilters2_Visible',ctrl:'ADDDYNAMICFILTERS2',prop:'Visible'},{av:'imgRemovedynamicfilters2_Visible',ctrl:'REMOVEDYNAMICFILTERS2',prop:'Visible'},{av:'cmbavDynamicfiltersselector1'},{av:'AV15DynamicFiltersSelector1',fld:'vDYNAMICFILTERSSELECTOR1',pic:''},{av:'cmbavDynamicfiltersoperator1'},{av:'AV16DynamicFiltersOperator1',fld:'vDYNAMICFILTERSOPERATOR1',pic:'ZZZ9'},{av:'AV17RHTrabajadorNombres1',fld:'vRHTRABAJADORNOMBRES1',pic:''},{av:'AV18Reloj_Nombre1',fld:'vRELOJ_NOMBRE1',pic:''},{av:'AV19HorarioDescripcion1',fld:'vHORARIODESCRIPCION1',pic:''},{av:'lblJsdynamicfilters_Caption',ctrl:'JSDYNAMICFILTERS',prop:'Caption'},{av:'AV24Reloj_Nombre2',fld:'vRELOJ_NOMBRE2',pic:''},{av:'AV25HorarioDescripcion2',fld:'vHORARIODESCRIPCION2',pic:''},{av:'AV30Reloj_Nombre3',fld:'vRELOJ_NOMBRE3',pic:''},{av:'AV31HorarioDescripcion3',fld:'vHORARIODESCRIPCION3',pic:''},{av:'edtavRhtrabajadornombres2_Visible',ctrl:'vRHTRABAJADORNOMBRES2',prop:'Visible'},{av:'edtavReloj_nombre2_Visible',ctrl:'vRELOJ_NOMBRE2',prop:'Visible'},{av:'edtavHorariodescripcion2_Visible',ctrl:'vHORARIODESCRIPCION2',prop:'Visible'},{av:'edtavRhtrabajadornombres3_Visible',ctrl:'vRHTRABAJADORNOMBRES3',prop:'Visible'},{av:'edtavReloj_nombre3_Visible',ctrl:'vRELOJ_NOMBRE3',prop:'Visible'},{av:'edtavHorariodescripcion3_Visible',ctrl:'vHORARIODESCRIPCION3',prop:'Visible'},{av:'edtavRhtrabajadornombres1_Visible',ctrl:'vRHTRABAJADORNOMBRES1',prop:'Visible'},{av:'edtavReloj_nombre1_Visible',ctrl:'vRELOJ_NOMBRE1',prop:'Visible'},{av:'edtavHorariodescripcion1_Visible',ctrl:'vHORARIODESCRIPCION1',prop:'Visible'},{av:'AV63GridCurrentPage',fld:'vGRIDCURRENTPAGE',pic:'ZZZZZZZZZ9'},{av:'AV64GridPageCount',fld:'vGRIDPAGECOUNT',pic:'ZZZZZZZZZ9'},{av:'AV65GridAppliedFilters',fld:'vGRIDAPPLIEDFILTERS',pic:''}]}");
         setEventMetadata("VDYNAMICFILTERSSELECTOR1.CLICK","{handler:'E207M2',iparms:[{av:'cmbavDynamicfiltersselector1'},{av:'AV15DynamicFiltersSelector1',fld:'vDYNAMICFILTERSSELECTOR1',pic:''}]");
         setEventMetadata("VDYNAMICFILTERSSELECTOR1.CLICK",",oparms:[{av:'cmbavDynamicfiltersoperator1'},{av:'AV16DynamicFiltersOperator1',fld:'vDYNAMICFILTERSOPERATOR1',pic:'ZZZ9'},{av:'edtavRhtrabajadornombres1_Visible',ctrl:'vRHTRABAJADORNOMBRES1',prop:'Visible'},{av:'edtavReloj_nombre1_Visible',ctrl:'vRELOJ_NOMBRE1',prop:'Visible'},{av:'edtavHorariodescripcion1_Visible',ctrl:'vHORARIODESCRIPCION1',prop:'Visible'}]}");
         setEventMetadata("'ADDDYNAMICFILTERS2'","{handler:'E217M2',iparms:[{av:'GRID_nFirstRecordOnPage'},{av:'GRID_nEOF'},{av:'subGrid_Rows',ctrl:'GRID',prop:'Rows'},{av:'cmbavDynamicfiltersselector1'},{av:'AV15DynamicFiltersSelector1',fld:'vDYNAMICFILTERSSELECTOR1',pic:''},{av:'cmbavDynamicfiltersoperator1'},{av:'AV16DynamicFiltersOperator1',fld:'vDYNAMICFILTERSOPERATOR1',pic:'ZZZ9'},{av:'AV17RHTrabajadorNombres1',fld:'vRHTRABAJADORNOMBRES1',pic:''},{av:'AV18Reloj_Nombre1',fld:'vRELOJ_NOMBRE1',pic:''},{av:'AV19HorarioDescripcion1',fld:'vHORARIODESCRIPCION1',pic:''},{av:'cmbavDynamicfiltersselector2'},{av:'AV21DynamicFiltersSelector2',fld:'vDYNAMICFILTERSSELECTOR2',pic:''},{av:'cmbavDynamicfiltersoperator2'},{av:'AV22DynamicFiltersOperator2',fld:'vDYNAMICFILTERSOPERATOR2',pic:'ZZZ9'},{av:'AV23RHTrabajadorNombres2',fld:'vRHTRABAJADORNOMBRES2',pic:''},{av:'AV24Reloj_Nombre2',fld:'vRELOJ_NOMBRE2',pic:''},{av:'AV25HorarioDescripcion2',fld:'vHORARIODESCRIPCION2',pic:''},{av:'cmbavDynamicfiltersselector3'},{av:'AV27DynamicFiltersSelector3',fld:'vDYNAMICFILTERSSELECTOR3',pic:''},{av:'cmbavDynamicfiltersoperator3'},{av:'AV28DynamicFiltersOperator3',fld:'vDYNAMICFILTERSOPERATOR3',pic:'ZZZ9'},{av:'AV29RHTrabajadorNombres3',fld:'vRHTRABAJADORNOMBRES3',pic:''},{av:'AV30Reloj_Nombre3',fld:'vRELOJ_NOMBRE3',pic:''},{av:'AV31HorarioDescripcion3',fld:'vHORARIODESCRIPCION3',pic:''},{av:'AV20DynamicFiltersEnabled2',fld:'vDYNAMICFILTERSENABLED2',pic:''},{av:'AV26DynamicFiltersEnabled3',fld:'vDYNAMICFILTERSENABLED3',pic:''},{av:'AV71Pgmname',fld:'vPGMNAME',pic:'',hsh:true},{av:'AV37TFCodigoId',fld:'vTFCODIGOID',pic:''},{av:'AV38TFCodigoId_Sel',fld:'vTFCODIGOID_SEL',pic:''},{av:'AV41TFReloj_Nombre',fld:'vTFRELOJ_NOMBRE',pic:''},{av:'AV42TFReloj_Nombre_Sel',fld:'vTFRELOJ_NOMBRE_SEL',pic:''},{av:'AV43TFLectura_Ini',fld:'vTFLECTURA_INI',pic:'99/99/9999 99:99:99'},{av:'AV44TFLectura_Ini_To',fld:'vTFLECTURA_INI_TO',pic:'99/99/9999 99:99:99'},{av:'AV55TFRHTrabajadorNombres',fld:'vTFRHTRABAJADORNOMBRES',pic:''},{av:'AV56TFRHTrabajadorNombres_Sel',fld:'vTFRHTRABAJADORNOMBRES_SEL',pic:''},{av:'AV59TFHorarioDescripcion',fld:'vTFHORARIODESCRIPCION',pic:''},{av:'AV60TFHorarioDescripcion_Sel',fld:'vTFHORARIODESCRIPCION_SEL',pic:''},{av:'AV13OrderedBy',fld:'vORDEREDBY',pic:'ZZZ9'},{av:'AV14OrderedDsc',fld:'vORDEREDDSC',pic:''},{av:'AV10GridState',fld:'vGRIDSTATE',pic:''},{av:'AV33DynamicFiltersIgnoreFirst',fld:'vDYNAMICFILTERSIGNOREFIRST',pic:''},{av:'AV32DynamicFiltersRemoving',fld:'vDYNAMICFILTERSREMOVING',pic:''}]");
         setEventMetadata("'ADDDYNAMICFILTERS2'",",oparms:[{av:'AV26DynamicFiltersEnabled3',fld:'vDYNAMICFILTERSENABLED3',pic:''},{av:'imgAdddynamicfilters2_Visible',ctrl:'ADDDYNAMICFILTERS2',prop:'Visible'},{av:'imgRemovedynamicfilters2_Visible',ctrl:'REMOVEDYNAMICFILTERS2',prop:'Visible'},{av:'cmbavDynamicfiltersoperator1'},{av:'AV16DynamicFiltersOperator1',fld:'vDYNAMICFILTERSOPERATOR1',pic:'ZZZ9'},{av:'cmbavDynamicfiltersoperator2'},{av:'AV22DynamicFiltersOperator2',fld:'vDYNAMICFILTERSOPERATOR2',pic:'ZZZ9'},{av:'cmbavDynamicfiltersoperator3'},{av:'AV28DynamicFiltersOperator3',fld:'vDYNAMICFILTERSOPERATOR3',pic:'ZZZ9'},{av:'AV63GridCurrentPage',fld:'vGRIDCURRENTPAGE',pic:'ZZZZZZZZZ9'},{av:'AV64GridPageCount',fld:'vGRIDPAGECOUNT',pic:'ZZZZZZZZZ9'},{av:'AV65GridAppliedFilters',fld:'vGRIDAPPLIEDFILTERS',pic:''},{av:'AV10GridState',fld:'vGRIDSTATE',pic:''}]}");
         setEventMetadata("'REMOVEDYNAMICFILTERS2'","{handler:'E167M2',iparms:[{av:'GRID_nFirstRecordOnPage'},{av:'GRID_nEOF'},{av:'subGrid_Rows',ctrl:'GRID',prop:'Rows'},{av:'cmbavDynamicfiltersselector1'},{av:'AV15DynamicFiltersSelector1',fld:'vDYNAMICFILTERSSELECTOR1',pic:''},{av:'cmbavDynamicfiltersoperator1'},{av:'AV16DynamicFiltersOperator1',fld:'vDYNAMICFILTERSOPERATOR1',pic:'ZZZ9'},{av:'AV17RHTrabajadorNombres1',fld:'vRHTRABAJADORNOMBRES1',pic:''},{av:'AV18Reloj_Nombre1',fld:'vRELOJ_NOMBRE1',pic:''},{av:'AV19HorarioDescripcion1',fld:'vHORARIODESCRIPCION1',pic:''},{av:'cmbavDynamicfiltersselector2'},{av:'AV21DynamicFiltersSelector2',fld:'vDYNAMICFILTERSSELECTOR2',pic:''},{av:'cmbavDynamicfiltersoperator2'},{av:'AV22DynamicFiltersOperator2',fld:'vDYNAMICFILTERSOPERATOR2',pic:'ZZZ9'},{av:'AV23RHTrabajadorNombres2',fld:'vRHTRABAJADORNOMBRES2',pic:''},{av:'AV24Reloj_Nombre2',fld:'vRELOJ_NOMBRE2',pic:''},{av:'AV25HorarioDescripcion2',fld:'vHORARIODESCRIPCION2',pic:''},{av:'cmbavDynamicfiltersselector3'},{av:'AV27DynamicFiltersSelector3',fld:'vDYNAMICFILTERSSELECTOR3',pic:''},{av:'cmbavDynamicfiltersoperator3'},{av:'AV28DynamicFiltersOperator3',fld:'vDYNAMICFILTERSOPERATOR3',pic:'ZZZ9'},{av:'AV29RHTrabajadorNombres3',fld:'vRHTRABAJADORNOMBRES3',pic:''},{av:'AV30Reloj_Nombre3',fld:'vRELOJ_NOMBRE3',pic:''},{av:'AV31HorarioDescripcion3',fld:'vHORARIODESCRIPCION3',pic:''},{av:'AV20DynamicFiltersEnabled2',fld:'vDYNAMICFILTERSENABLED2',pic:''},{av:'AV26DynamicFiltersEnabled3',fld:'vDYNAMICFILTERSENABLED3',pic:''},{av:'AV71Pgmname',fld:'vPGMNAME',pic:'',hsh:true},{av:'AV37TFCodigoId',fld:'vTFCODIGOID',pic:''},{av:'AV38TFCodigoId_Sel',fld:'vTFCODIGOID_SEL',pic:''},{av:'AV41TFReloj_Nombre',fld:'vTFRELOJ_NOMBRE',pic:''},{av:'AV42TFReloj_Nombre_Sel',fld:'vTFRELOJ_NOMBRE_SEL',pic:''},{av:'AV43TFLectura_Ini',fld:'vTFLECTURA_INI',pic:'99/99/9999 99:99:99'},{av:'AV44TFLectura_Ini_To',fld:'vTFLECTURA_INI_TO',pic:'99/99/9999 99:99:99'},{av:'AV55TFRHTrabajadorNombres',fld:'vTFRHTRABAJADORNOMBRES',pic:''},{av:'AV56TFRHTrabajadorNombres_Sel',fld:'vTFRHTRABAJADORNOMBRES_SEL',pic:''},{av:'AV59TFHorarioDescripcion',fld:'vTFHORARIODESCRIPCION',pic:''},{av:'AV60TFHorarioDescripcion_Sel',fld:'vTFHORARIODESCRIPCION_SEL',pic:''},{av:'AV13OrderedBy',fld:'vORDEREDBY',pic:'ZZZ9'},{av:'AV14OrderedDsc',fld:'vORDEREDDSC',pic:''},{av:'AV10GridState',fld:'vGRIDSTATE',pic:''},{av:'AV33DynamicFiltersIgnoreFirst',fld:'vDYNAMICFILTERSIGNOREFIRST',pic:''},{av:'AV32DynamicFiltersRemoving',fld:'vDYNAMICFILTERSREMOVING',pic:''}]");
         setEventMetadata("'REMOVEDYNAMICFILTERS2'",",oparms:[{av:'AV32DynamicFiltersRemoving',fld:'vDYNAMICFILTERSREMOVING',pic:''},{av:'AV20DynamicFiltersEnabled2',fld:'vDYNAMICFILTERSENABLED2',pic:''},{av:'AV10GridState',fld:'vGRIDSTATE',pic:''},{av:'cmbavDynamicfiltersselector2'},{av:'AV21DynamicFiltersSelector2',fld:'vDYNAMICFILTERSSELECTOR2',pic:''},{av:'cmbavDynamicfiltersoperator2'},{av:'AV22DynamicFiltersOperator2',fld:'vDYNAMICFILTERSOPERATOR2',pic:'ZZZ9'},{av:'AV23RHTrabajadorNombres2',fld:'vRHTRABAJADORNOMBRES2',pic:''},{av:'AV26DynamicFiltersEnabled3',fld:'vDYNAMICFILTERSENABLED3',pic:''},{av:'cmbavDynamicfiltersselector3'},{av:'AV27DynamicFiltersSelector3',fld:'vDYNAMICFILTERSSELECTOR3',pic:''},{av:'cmbavDynamicfiltersoperator3'},{av:'AV28DynamicFiltersOperator3',fld:'vDYNAMICFILTERSOPERATOR3',pic:'ZZZ9'},{av:'AV29RHTrabajadorNombres3',fld:'vRHTRABAJADORNOMBRES3',pic:''},{av:'imgAdddynamicfilters1_Visible',ctrl:'ADDDYNAMICFILTERS1',prop:'Visible'},{av:'imgRemovedynamicfilters1_Visible',ctrl:'REMOVEDYNAMICFILTERS1',prop:'Visible'},{av:'imgAdddynamicfilters2_Visible',ctrl:'ADDDYNAMICFILTERS2',prop:'Visible'},{av:'imgRemovedynamicfilters2_Visible',ctrl:'REMOVEDYNAMICFILTERS2',prop:'Visible'},{av:'cmbavDynamicfiltersselector1'},{av:'AV15DynamicFiltersSelector1',fld:'vDYNAMICFILTERSSELECTOR1',pic:''},{av:'cmbavDynamicfiltersoperator1'},{av:'AV16DynamicFiltersOperator1',fld:'vDYNAMICFILTERSOPERATOR1',pic:'ZZZ9'},{av:'AV17RHTrabajadorNombres1',fld:'vRHTRABAJADORNOMBRES1',pic:''},{av:'AV18Reloj_Nombre1',fld:'vRELOJ_NOMBRE1',pic:''},{av:'AV19HorarioDescripcion1',fld:'vHORARIODESCRIPCION1',pic:''},{av:'lblJsdynamicfilters_Caption',ctrl:'JSDYNAMICFILTERS',prop:'Caption'},{av:'AV24Reloj_Nombre2',fld:'vRELOJ_NOMBRE2',pic:''},{av:'AV25HorarioDescripcion2',fld:'vHORARIODESCRIPCION2',pic:''},{av:'AV30Reloj_Nombre3',fld:'vRELOJ_NOMBRE3',pic:''},{av:'AV31HorarioDescripcion3',fld:'vHORARIODESCRIPCION3',pic:''},{av:'edtavRhtrabajadornombres2_Visible',ctrl:'vRHTRABAJADORNOMBRES2',prop:'Visible'},{av:'edtavReloj_nombre2_Visible',ctrl:'vRELOJ_NOMBRE2',prop:'Visible'},{av:'edtavHorariodescripcion2_Visible',ctrl:'vHORARIODESCRIPCION2',prop:'Visible'},{av:'edtavRhtrabajadornombres3_Visible',ctrl:'vRHTRABAJADORNOMBRES3',prop:'Visible'},{av:'edtavReloj_nombre3_Visible',ctrl:'vRELOJ_NOMBRE3',prop:'Visible'},{av:'edtavHorariodescripcion3_Visible',ctrl:'vHORARIODESCRIPCION3',prop:'Visible'},{av:'edtavRhtrabajadornombres1_Visible',ctrl:'vRHTRABAJADORNOMBRES1',prop:'Visible'},{av:'edtavReloj_nombre1_Visible',ctrl:'vRELOJ_NOMBRE1',prop:'Visible'},{av:'edtavHorariodescripcion1_Visible',ctrl:'vHORARIODESCRIPCION1',prop:'Visible'},{av:'AV63GridCurrentPage',fld:'vGRIDCURRENTPAGE',pic:'ZZZZZZZZZ9'},{av:'AV64GridPageCount',fld:'vGRIDPAGECOUNT',pic:'ZZZZZZZZZ9'},{av:'AV65GridAppliedFilters',fld:'vGRIDAPPLIEDFILTERS',pic:''}]}");
         setEventMetadata("VDYNAMICFILTERSSELECTOR2.CLICK","{handler:'E227M2',iparms:[{av:'cmbavDynamicfiltersselector2'},{av:'AV21DynamicFiltersSelector2',fld:'vDYNAMICFILTERSSELECTOR2',pic:''}]");
         setEventMetadata("VDYNAMICFILTERSSELECTOR2.CLICK",",oparms:[{av:'cmbavDynamicfiltersoperator2'},{av:'AV22DynamicFiltersOperator2',fld:'vDYNAMICFILTERSOPERATOR2',pic:'ZZZ9'},{av:'edtavRhtrabajadornombres2_Visible',ctrl:'vRHTRABAJADORNOMBRES2',prop:'Visible'},{av:'edtavReloj_nombre2_Visible',ctrl:'vRELOJ_NOMBRE2',prop:'Visible'},{av:'edtavHorariodescripcion2_Visible',ctrl:'vHORARIODESCRIPCION2',prop:'Visible'}]}");
         setEventMetadata("'REMOVEDYNAMICFILTERS3'","{handler:'E177M2',iparms:[{av:'GRID_nFirstRecordOnPage'},{av:'GRID_nEOF'},{av:'subGrid_Rows',ctrl:'GRID',prop:'Rows'},{av:'cmbavDynamicfiltersselector1'},{av:'AV15DynamicFiltersSelector1',fld:'vDYNAMICFILTERSSELECTOR1',pic:''},{av:'cmbavDynamicfiltersoperator1'},{av:'AV16DynamicFiltersOperator1',fld:'vDYNAMICFILTERSOPERATOR1',pic:'ZZZ9'},{av:'AV17RHTrabajadorNombres1',fld:'vRHTRABAJADORNOMBRES1',pic:''},{av:'AV18Reloj_Nombre1',fld:'vRELOJ_NOMBRE1',pic:''},{av:'AV19HorarioDescripcion1',fld:'vHORARIODESCRIPCION1',pic:''},{av:'cmbavDynamicfiltersselector2'},{av:'AV21DynamicFiltersSelector2',fld:'vDYNAMICFILTERSSELECTOR2',pic:''},{av:'cmbavDynamicfiltersoperator2'},{av:'AV22DynamicFiltersOperator2',fld:'vDYNAMICFILTERSOPERATOR2',pic:'ZZZ9'},{av:'AV23RHTrabajadorNombres2',fld:'vRHTRABAJADORNOMBRES2',pic:''},{av:'AV24Reloj_Nombre2',fld:'vRELOJ_NOMBRE2',pic:''},{av:'AV25HorarioDescripcion2',fld:'vHORARIODESCRIPCION2',pic:''},{av:'cmbavDynamicfiltersselector3'},{av:'AV27DynamicFiltersSelector3',fld:'vDYNAMICFILTERSSELECTOR3',pic:''},{av:'cmbavDynamicfiltersoperator3'},{av:'AV28DynamicFiltersOperator3',fld:'vDYNAMICFILTERSOPERATOR3',pic:'ZZZ9'},{av:'AV29RHTrabajadorNombres3',fld:'vRHTRABAJADORNOMBRES3',pic:''},{av:'AV30Reloj_Nombre3',fld:'vRELOJ_NOMBRE3',pic:''},{av:'AV31HorarioDescripcion3',fld:'vHORARIODESCRIPCION3',pic:''},{av:'AV20DynamicFiltersEnabled2',fld:'vDYNAMICFILTERSENABLED2',pic:''},{av:'AV26DynamicFiltersEnabled3',fld:'vDYNAMICFILTERSENABLED3',pic:''},{av:'AV71Pgmname',fld:'vPGMNAME',pic:'',hsh:true},{av:'AV37TFCodigoId',fld:'vTFCODIGOID',pic:''},{av:'AV38TFCodigoId_Sel',fld:'vTFCODIGOID_SEL',pic:''},{av:'AV41TFReloj_Nombre',fld:'vTFRELOJ_NOMBRE',pic:''},{av:'AV42TFReloj_Nombre_Sel',fld:'vTFRELOJ_NOMBRE_SEL',pic:''},{av:'AV43TFLectura_Ini',fld:'vTFLECTURA_INI',pic:'99/99/9999 99:99:99'},{av:'AV44TFLectura_Ini_To',fld:'vTFLECTURA_INI_TO',pic:'99/99/9999 99:99:99'},{av:'AV55TFRHTrabajadorNombres',fld:'vTFRHTRABAJADORNOMBRES',pic:''},{av:'AV56TFRHTrabajadorNombres_Sel',fld:'vTFRHTRABAJADORNOMBRES_SEL',pic:''},{av:'AV59TFHorarioDescripcion',fld:'vTFHORARIODESCRIPCION',pic:''},{av:'AV60TFHorarioDescripcion_Sel',fld:'vTFHORARIODESCRIPCION_SEL',pic:''},{av:'AV13OrderedBy',fld:'vORDEREDBY',pic:'ZZZ9'},{av:'AV14OrderedDsc',fld:'vORDEREDDSC',pic:''},{av:'AV10GridState',fld:'vGRIDSTATE',pic:''},{av:'AV33DynamicFiltersIgnoreFirst',fld:'vDYNAMICFILTERSIGNOREFIRST',pic:''},{av:'AV32DynamicFiltersRemoving',fld:'vDYNAMICFILTERSREMOVING',pic:''}]");
         setEventMetadata("'REMOVEDYNAMICFILTERS3'",",oparms:[{av:'AV32DynamicFiltersRemoving',fld:'vDYNAMICFILTERSREMOVING',pic:''},{av:'AV26DynamicFiltersEnabled3',fld:'vDYNAMICFILTERSENABLED3',pic:''},{av:'AV10GridState',fld:'vGRIDSTATE',pic:''},{av:'AV20DynamicFiltersEnabled2',fld:'vDYNAMICFILTERSENABLED2',pic:''},{av:'cmbavDynamicfiltersselector2'},{av:'AV21DynamicFiltersSelector2',fld:'vDYNAMICFILTERSSELECTOR2',pic:''},{av:'cmbavDynamicfiltersoperator2'},{av:'AV22DynamicFiltersOperator2',fld:'vDYNAMICFILTERSOPERATOR2',pic:'ZZZ9'},{av:'AV23RHTrabajadorNombres2',fld:'vRHTRABAJADORNOMBRES2',pic:''},{av:'cmbavDynamicfiltersselector3'},{av:'AV27DynamicFiltersSelector3',fld:'vDYNAMICFILTERSSELECTOR3',pic:''},{av:'cmbavDynamicfiltersoperator3'},{av:'AV28DynamicFiltersOperator3',fld:'vDYNAMICFILTERSOPERATOR3',pic:'ZZZ9'},{av:'AV29RHTrabajadorNombres3',fld:'vRHTRABAJADORNOMBRES3',pic:''},{av:'imgAdddynamicfilters1_Visible',ctrl:'ADDDYNAMICFILTERS1',prop:'Visible'},{av:'imgRemovedynamicfilters1_Visible',ctrl:'REMOVEDYNAMICFILTERS1',prop:'Visible'},{av:'imgAdddynamicfilters2_Visible',ctrl:'ADDDYNAMICFILTERS2',prop:'Visible'},{av:'imgRemovedynamicfilters2_Visible',ctrl:'REMOVEDYNAMICFILTERS2',prop:'Visible'},{av:'cmbavDynamicfiltersselector1'},{av:'AV15DynamicFiltersSelector1',fld:'vDYNAMICFILTERSSELECTOR1',pic:''},{av:'cmbavDynamicfiltersoperator1'},{av:'AV16DynamicFiltersOperator1',fld:'vDYNAMICFILTERSOPERATOR1',pic:'ZZZ9'},{av:'AV17RHTrabajadorNombres1',fld:'vRHTRABAJADORNOMBRES1',pic:''},{av:'AV18Reloj_Nombre1',fld:'vRELOJ_NOMBRE1',pic:''},{av:'AV19HorarioDescripcion1',fld:'vHORARIODESCRIPCION1',pic:''},{av:'lblJsdynamicfilters_Caption',ctrl:'JSDYNAMICFILTERS',prop:'Caption'},{av:'AV24Reloj_Nombre2',fld:'vRELOJ_NOMBRE2',pic:''},{av:'AV25HorarioDescripcion2',fld:'vHORARIODESCRIPCION2',pic:''},{av:'AV30Reloj_Nombre3',fld:'vRELOJ_NOMBRE3',pic:''},{av:'AV31HorarioDescripcion3',fld:'vHORARIODESCRIPCION3',pic:''},{av:'edtavRhtrabajadornombres2_Visible',ctrl:'vRHTRABAJADORNOMBRES2',prop:'Visible'},{av:'edtavReloj_nombre2_Visible',ctrl:'vRELOJ_NOMBRE2',prop:'Visible'},{av:'edtavHorariodescripcion2_Visible',ctrl:'vHORARIODESCRIPCION2',prop:'Visible'},{av:'edtavRhtrabajadornombres3_Visible',ctrl:'vRHTRABAJADORNOMBRES3',prop:'Visible'},{av:'edtavReloj_nombre3_Visible',ctrl:'vRELOJ_NOMBRE3',prop:'Visible'},{av:'edtavHorariodescripcion3_Visible',ctrl:'vHORARIODESCRIPCION3',prop:'Visible'},{av:'edtavRhtrabajadornombres1_Visible',ctrl:'vRHTRABAJADORNOMBRES1',prop:'Visible'},{av:'edtavReloj_nombre1_Visible',ctrl:'vRELOJ_NOMBRE1',prop:'Visible'},{av:'edtavHorariodescripcion1_Visible',ctrl:'vHORARIODESCRIPCION1',prop:'Visible'},{av:'AV63GridCurrentPage',fld:'vGRIDCURRENTPAGE',pic:'ZZZZZZZZZ9'},{av:'AV64GridPageCount',fld:'vGRIDPAGECOUNT',pic:'ZZZZZZZZZ9'},{av:'AV65GridAppliedFilters',fld:'vGRIDAPPLIEDFILTERS',pic:''}]}");
         setEventMetadata("VDYNAMICFILTERSSELECTOR3.CLICK","{handler:'E237M2',iparms:[{av:'cmbavDynamicfiltersselector3'},{av:'AV27DynamicFiltersSelector3',fld:'vDYNAMICFILTERSSELECTOR3',pic:''}]");
         setEventMetadata("VDYNAMICFILTERSSELECTOR3.CLICK",",oparms:[{av:'cmbavDynamicfiltersoperator3'},{av:'AV28DynamicFiltersOperator3',fld:'vDYNAMICFILTERSOPERATOR3',pic:'ZZZ9'},{av:'edtavRhtrabajadornombres3_Visible',ctrl:'vRHTRABAJADORNOMBRES3',prop:'Visible'},{av:'edtavReloj_nombre3_Visible',ctrl:'vRELOJ_NOMBRE3',prop:'Visible'},{av:'edtavHorariodescripcion3_Visible',ctrl:'vHORARIODESCRIPCION3',prop:'Visible'}]}");
         setEventMetadata("VGRIDACTIONS.CLICK","{handler:'E277M2',iparms:[{av:'cmbavGridactions'},{av:'AV66GridActions',fld:'vGRIDACTIONS',pic:'ZZZ9'},{av:'A2431CodigoId',fld:'CODIGOID',pic:'',hsh:true}]");
         setEventMetadata("VGRIDACTIONS.CLICK",",oparms:[{av:'cmbavGridactions'},{av:'AV66GridActions',fld:'vGRIDACTIONS',pic:'ZZZ9'}]}");
         setEventMetadata("'DOINSERT'","{handler:'E187M2',iparms:[{av:'A2431CodigoId',fld:'CODIGOID',pic:'',hsh:true}]");
         setEventMetadata("'DOINSERT'",",oparms:[]}");
         setEventMetadata("DDO_AGEXPORT.ONOPTIONCLICKED","{handler:'E137M2',iparms:[{av:'Ddo_agexport_Activeeventkey',ctrl:'DDO_AGEXPORT',prop:'ActiveEventKey'},{av:'AV71Pgmname',fld:'vPGMNAME',pic:'',hsh:true},{av:'AV38TFCodigoId_Sel',fld:'vTFCODIGOID_SEL',pic:''},{av:'AV42TFReloj_Nombre_Sel',fld:'vTFRELOJ_NOMBRE_SEL',pic:''},{av:'AV56TFRHTrabajadorNombres_Sel',fld:'vTFRHTRABAJADORNOMBRES_SEL',pic:''},{av:'AV60TFHorarioDescripcion_Sel',fld:'vTFHORARIODESCRIPCION_SEL',pic:''},{av:'AV37TFCodigoId',fld:'vTFCODIGOID',pic:''},{av:'AV41TFReloj_Nombre',fld:'vTFRELOJ_NOMBRE',pic:''},{av:'AV43TFLectura_Ini',fld:'vTFLECTURA_INI',pic:'99/99/9999 99:99:99'},{av:'AV45DDO_Lectura_IniAuxDate',fld:'vDDO_LECTURA_INIAUXDATE',pic:''},{av:'AV55TFRHTrabajadorNombres',fld:'vTFRHTRABAJADORNOMBRES',pic:''},{av:'AV59TFHorarioDescripcion',fld:'vTFHORARIODESCRIPCION',pic:''},{av:'AV44TFLectura_Ini_To',fld:'vTFLECTURA_INI_TO',pic:'99/99/9999 99:99:99'},{av:'AV46DDO_Lectura_IniAuxDateTo',fld:'vDDO_LECTURA_INIAUXDATETO',pic:''},{av:'AV13OrderedBy',fld:'vORDEREDBY',pic:'ZZZ9'},{av:'AV14OrderedDsc',fld:'vORDEREDDSC',pic:''},{av:'AV10GridState',fld:'vGRIDSTATE',pic:''},{av:'AV32DynamicFiltersRemoving',fld:'vDYNAMICFILTERSREMOVING',pic:''},{av:'cmbavDynamicfiltersselector1'},{av:'AV15DynamicFiltersSelector1',fld:'vDYNAMICFILTERSSELECTOR1',pic:''},{av:'cmbavDynamicfiltersselector2'},{av:'AV21DynamicFiltersSelector2',fld:'vDYNAMICFILTERSSELECTOR2',pic:''},{av:'cmbavDynamicfiltersselector3'},{av:'AV27DynamicFiltersSelector3',fld:'vDYNAMICFILTERSSELECTOR3',pic:''}]");
         setEventMetadata("DDO_AGEXPORT.ONOPTIONCLICKED",",oparms:[{av:'Innewwindow1_Target',ctrl:'INNEWWINDOW1',prop:'Target'},{av:'Innewwindow1_Height',ctrl:'INNEWWINDOW1',prop:'Height'},{av:'Innewwindow1_Width',ctrl:'INNEWWINDOW1',prop:'Width'},{av:'AV10GridState',fld:'vGRIDSTATE',pic:''},{av:'AV13OrderedBy',fld:'vORDEREDBY',pic:'ZZZ9'},{av:'AV14OrderedDsc',fld:'vORDEREDDSC',pic:''},{av:'AV60TFHorarioDescripcion_Sel',fld:'vTFHORARIODESCRIPCION_SEL',pic:''},{av:'AV59TFHorarioDescripcion',fld:'vTFHORARIODESCRIPCION',pic:''},{av:'AV56TFRHTrabajadorNombres_Sel',fld:'vTFRHTRABAJADORNOMBRES_SEL',pic:''},{av:'AV55TFRHTrabajadorNombres',fld:'vTFRHTRABAJADORNOMBRES',pic:''},{av:'AV43TFLectura_Ini',fld:'vTFLECTURA_INI',pic:'99/99/9999 99:99:99'},{av:'AV44TFLectura_Ini_To',fld:'vTFLECTURA_INI_TO',pic:'99/99/9999 99:99:99'},{av:'AV45DDO_Lectura_IniAuxDate',fld:'vDDO_LECTURA_INIAUXDATE',pic:''},{av:'AV46DDO_Lectura_IniAuxDateTo',fld:'vDDO_LECTURA_INIAUXDATETO',pic:''},{av:'AV42TFReloj_Nombre_Sel',fld:'vTFRELOJ_NOMBRE_SEL',pic:''},{av:'AV41TFReloj_Nombre',fld:'vTFRELOJ_NOMBRE',pic:''},{av:'AV38TFCodigoId_Sel',fld:'vTFCODIGOID_SEL',pic:''},{av:'AV37TFCodigoId',fld:'vTFCODIGOID',pic:''},{av:'Ddo_grid_Selectedvalue_set',ctrl:'DDO_GRID',prop:'SelectedValue_set'},{av:'Ddo_grid_Filteredtext_set',ctrl:'DDO_GRID',prop:'FilteredText_set'},{av:'Ddo_grid_Filteredtextto_set',ctrl:'DDO_GRID',prop:'FilteredTextTo_set'},{av:'subGrid_Rows',ctrl:'GRID',prop:'Rows'},{av:'GRID_nFirstRecordOnPage'},{av:'GRID_nEOF'},{av:'cmbavDynamicfiltersselector1'},{av:'AV15DynamicFiltersSelector1',fld:'vDYNAMICFILTERSSELECTOR1',pic:''},{av:'cmbavDynamicfiltersoperator1'},{av:'AV16DynamicFiltersOperator1',fld:'vDYNAMICFILTERSOPERATOR1',pic:'ZZZ9'},{av:'AV17RHTrabajadorNombres1',fld:'vRHTRABAJADORNOMBRES1',pic:''},{av:'AV18Reloj_Nombre1',fld:'vRELOJ_NOMBRE1',pic:''},{av:'AV19HorarioDescripcion1',fld:'vHORARIODESCRIPCION1',pic:''},{av:'cmbavDynamicfiltersselector2'},{av:'AV21DynamicFiltersSelector2',fld:'vDYNAMICFILTERSSELECTOR2',pic:''},{av:'cmbavDynamicfiltersoperator2'},{av:'AV22DynamicFiltersOperator2',fld:'vDYNAMICFILTERSOPERATOR2',pic:'ZZZ9'},{av:'AV23RHTrabajadorNombres2',fld:'vRHTRABAJADORNOMBRES2',pic:''},{av:'AV24Reloj_Nombre2',fld:'vRELOJ_NOMBRE2',pic:''},{av:'AV25HorarioDescripcion2',fld:'vHORARIODESCRIPCION2',pic:''},{av:'cmbavDynamicfiltersselector3'},{av:'AV27DynamicFiltersSelector3',fld:'vDYNAMICFILTERSSELECTOR3',pic:''},{av:'cmbavDynamicfiltersoperator3'},{av:'AV28DynamicFiltersOperator3',fld:'vDYNAMICFILTERSOPERATOR3',pic:'ZZZ9'},{av:'AV29RHTrabajadorNombres3',fld:'vRHTRABAJADORNOMBRES3',pic:''},{av:'AV30Reloj_Nombre3',fld:'vRELOJ_NOMBRE3',pic:''},{av:'AV31HorarioDescripcion3',fld:'vHORARIODESCRIPCION3',pic:''},{av:'AV20DynamicFiltersEnabled2',fld:'vDYNAMICFILTERSENABLED2',pic:''},{av:'AV26DynamicFiltersEnabled3',fld:'vDYNAMICFILTERSENABLED3',pic:''},{av:'AV71Pgmname',fld:'vPGMNAME',pic:'',hsh:true},{av:'AV33DynamicFiltersIgnoreFirst',fld:'vDYNAMICFILTERSIGNOREFIRST',pic:''},{av:'AV32DynamicFiltersRemoving',fld:'vDYNAMICFILTERSREMOVING',pic:''},{av:'Ddo_grid_Sortedstatus',ctrl:'DDO_GRID',prop:'SortedStatus'},{av:'imgAdddynamicfilters1_Visible',ctrl:'ADDDYNAMICFILTERS1',prop:'Visible'},{av:'imgRemovedynamicfilters1_Visible',ctrl:'REMOVEDYNAMICFILTERS1',prop:'Visible'},{av:'imgAdddynamicfilters2_Visible',ctrl:'ADDDYNAMICFILTERS2',prop:'Visible'},{av:'imgRemovedynamicfilters2_Visible',ctrl:'REMOVEDYNAMICFILTERS2',prop:'Visible'},{av:'lblJsdynamicfilters_Caption',ctrl:'JSDYNAMICFILTERS',prop:'Caption'},{av:'edtavRhtrabajadornombres1_Visible',ctrl:'vRHTRABAJADORNOMBRES1',prop:'Visible'},{av:'edtavReloj_nombre1_Visible',ctrl:'vRELOJ_NOMBRE1',prop:'Visible'},{av:'edtavHorariodescripcion1_Visible',ctrl:'vHORARIODESCRIPCION1',prop:'Visible'},{av:'edtavRhtrabajadornombres2_Visible',ctrl:'vRHTRABAJADORNOMBRES2',prop:'Visible'},{av:'edtavReloj_nombre2_Visible',ctrl:'vRELOJ_NOMBRE2',prop:'Visible'},{av:'edtavHorariodescripcion2_Visible',ctrl:'vHORARIODESCRIPCION2',prop:'Visible'},{av:'edtavRhtrabajadornombres3_Visible',ctrl:'vRHTRABAJADORNOMBRES3',prop:'Visible'},{av:'edtavReloj_nombre3_Visible',ctrl:'vRELOJ_NOMBRE3',prop:'Visible'},{av:'edtavHorariodescripcion3_Visible',ctrl:'vHORARIODESCRIPCION3',prop:'Visible'}]}");
         setEventMetadata("NULL","{handler:'Valid_Horariodescripcion',iparms:[]");
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
         AV17RHTrabajadorNombres1 = "";
         AV18Reloj_Nombre1 = "";
         AV19HorarioDescripcion1 = "";
         AV21DynamicFiltersSelector2 = "";
         AV23RHTrabajadorNombres2 = "";
         AV24Reloj_Nombre2 = "";
         AV25HorarioDescripcion2 = "";
         AV27DynamicFiltersSelector3 = "";
         AV29RHTrabajadorNombres3 = "";
         AV30Reloj_Nombre3 = "";
         AV31HorarioDescripcion3 = "";
         AV71Pgmname = "";
         AV37TFCodigoId = "";
         AV38TFCodigoId_Sel = "";
         AV41TFReloj_Nombre = "";
         AV42TFReloj_Nombre_Sel = "";
         AV43TFLectura_Ini = (DateTime)(DateTime.MinValue);
         AV44TFLectura_Ini_To = (DateTime)(DateTime.MinValue);
         AV55TFRHTrabajadorNombres = "";
         AV56TFRHTrabajadorNombres_Sel = "";
         AV59TFHorarioDescripcion = "";
         AV60TFHorarioDescripcion_Sel = "";
         AV10GridState = new GeneXus.Programs.wwpbaseobjects.SdtWWPGridState(context);
         sDynURL = "";
         FormProcess = "";
         bodyStyle = "";
         GXKey = "";
         AV65GridAppliedFilters = "";
         AV67AGExportData = new GXBaseCollection<GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTDropDownOptionsData_Item>( context, "Item", "");
         AV61DDO_TitleSettingsIcons = new GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTDropDownOptionsTitleSettingsIcons(context);
         AV46DDO_Lectura_IniAuxDateTo = DateTime.MinValue;
         AV45DDO_Lectura_IniAuxDate = DateTime.MinValue;
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
         A2431CodigoId = "";
         A2592Reloj_Nombre = "";
         A2415Lectura_Ini = (DateTime)(DateTime.MinValue);
         A2590RHTrabajadorNombres = "";
         A2593HorarioDescripcion = "";
         ucGridpaginationbar = new GXUserControl();
         ucDdo_agexport = new GXUserControl();
         lblJsdynamicfilters_Jsonclick = "";
         ucDdo_grid = new GXUserControl();
         ucInnewwindow1 = new GXUserControl();
         ucGrid_empowerer = new GXUserControl();
         AV47DDO_Lectura_IniAuxDateText = "";
         ucTflectura_ini_rangepicker = new GXUserControl();
         sEvt = "";
         EvtGridId = "";
         EvtRowId = "";
         sEvtType = "";
         scmdbuf = "";
         lV74Reloj_interface_reloj_codigoidwwds_3_rhtrabajadornombres1 = "";
         lV75Reloj_interface_reloj_codigoidwwds_4_reloj_nombre1 = "";
         lV76Reloj_interface_reloj_codigoidwwds_5_horariodescripcion1 = "";
         lV80Reloj_interface_reloj_codigoidwwds_9_rhtrabajadornombres2 = "";
         lV81Reloj_interface_reloj_codigoidwwds_10_reloj_nombre2 = "";
         lV82Reloj_interface_reloj_codigoidwwds_11_horariodescripcion2 = "";
         lV86Reloj_interface_reloj_codigoidwwds_15_rhtrabajadornombres3 = "";
         lV87Reloj_interface_reloj_codigoidwwds_16_reloj_nombre3 = "";
         lV88Reloj_interface_reloj_codigoidwwds_17_horariodescripcion3 = "";
         lV89Reloj_interface_reloj_codigoidwwds_18_tfcodigoid = "";
         lV91Reloj_interface_reloj_codigoidwwds_20_tfreloj_nombre = "";
         lV95Reloj_interface_reloj_codigoidwwds_24_tfrhtrabajadornombres = "";
         lV97Reloj_interface_reloj_codigoidwwds_26_tfhorariodescripcion = "";
         AV72Reloj_interface_reloj_codigoidwwds_1_dynamicfiltersselector1 = "";
         AV74Reloj_interface_reloj_codigoidwwds_3_rhtrabajadornombres1 = "";
         AV75Reloj_interface_reloj_codigoidwwds_4_reloj_nombre1 = "";
         AV76Reloj_interface_reloj_codigoidwwds_5_horariodescripcion1 = "";
         AV78Reloj_interface_reloj_codigoidwwds_7_dynamicfiltersselector2 = "";
         AV80Reloj_interface_reloj_codigoidwwds_9_rhtrabajadornombres2 = "";
         AV81Reloj_interface_reloj_codigoidwwds_10_reloj_nombre2 = "";
         AV82Reloj_interface_reloj_codigoidwwds_11_horariodescripcion2 = "";
         AV84Reloj_interface_reloj_codigoidwwds_13_dynamicfiltersselector3 = "";
         AV86Reloj_interface_reloj_codigoidwwds_15_rhtrabajadornombres3 = "";
         AV87Reloj_interface_reloj_codigoidwwds_16_reloj_nombre3 = "";
         AV88Reloj_interface_reloj_codigoidwwds_17_horariodescripcion3 = "";
         AV90Reloj_interface_reloj_codigoidwwds_19_tfcodigoid_sel = "";
         AV89Reloj_interface_reloj_codigoidwwds_18_tfcodigoid = "";
         AV92Reloj_interface_reloj_codigoidwwds_21_tfreloj_nombre_sel = "";
         AV91Reloj_interface_reloj_codigoidwwds_20_tfreloj_nombre = "";
         AV93Reloj_interface_reloj_codigoidwwds_22_tflectura_ini = (DateTime)(DateTime.MinValue);
         AV94Reloj_interface_reloj_codigoidwwds_23_tflectura_ini_to = (DateTime)(DateTime.MinValue);
         AV96Reloj_interface_reloj_codigoidwwds_25_tfrhtrabajadornombres_sel = "";
         AV95Reloj_interface_reloj_codigoidwwds_24_tfrhtrabajadornombres = "";
         AV98Reloj_interface_reloj_codigoidwwds_27_tfhorariodescripcion_sel = "";
         AV97Reloj_interface_reloj_codigoidwwds_26_tfhorariodescripcion = "";
         A2525TrabApePat = "";
         A2526TrabApeMat = "";
         A2527TrabNombres = "";
         H007M2_A2589RHTrabajadorCodigo = new string[] {""} ;
         H007M2_A2498Reloj_ID = new short[1] ;
         H007M2_A2591HorarioID = new short[1] ;
         H007M2_A2593HorarioDescripcion = new string[] {""} ;
         H007M2_A2590RHTrabajadorNombres = new string[] {""} ;
         H007M2_A2415Lectura_Ini = new DateTime[] {DateTime.MinValue} ;
         H007M2_A2592Reloj_Nombre = new string[] {""} ;
         H007M2_A2431CodigoId = new string[] {""} ;
         H007M2_A2525TrabApePat = new string[] {""} ;
         H007M2_n2525TrabApePat = new bool[] {false} ;
         H007M2_A2526TrabApeMat = new string[] {""} ;
         H007M2_n2526TrabApeMat = new bool[] {false} ;
         H007M2_A2527TrabNombres = new string[] {""} ;
         H007M2_n2527TrabNombres = new bool[] {false} ;
         A2589RHTrabajadorCodigo = "";
         H007M3_AGRID_nRecordCount = new long[1] ;
         imgAdddynamicfilters1_Jsonclick = "";
         imgRemovedynamicfilters1_Jsonclick = "";
         imgAdddynamicfilters2_Jsonclick = "";
         imgRemovedynamicfilters2_Jsonclick = "";
         imgRemovedynamicfilters3_Jsonclick = "";
         AV68AGExportDataItem = new GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTDropDownOptionsData_Item(context);
         GXt_SdtDVB_SDTDropDownOptionsTitleSettingsIcons1 = new GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTDropDownOptionsTitleSettingsIcons(context);
         AV6WWPContext = new GeneXus.Programs.wwpbaseobjects.SdtWWPContext(context);
         GXEncryptionTmp = "";
         GridRow = new GXWebRow();
         AV36Session = context.GetSession();
         AV11GridStateFilterValue = new GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue(context);
         GXt_char5 = "";
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
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.reloj_interface.reloj_codigoidww__default(),
            new Object[][] {
                new Object[] {
               H007M2_A2589RHTrabajadorCodigo, H007M2_A2498Reloj_ID, H007M2_A2591HorarioID, H007M2_A2593HorarioDescripcion, H007M2_A2590RHTrabajadorNombres, H007M2_A2415Lectura_Ini, H007M2_A2592Reloj_Nombre, H007M2_A2431CodigoId, H007M2_A2525TrabApePat, H007M2_n2525TrabApePat,
               H007M2_A2526TrabApeMat, H007M2_n2526TrabApeMat, H007M2_A2527TrabNombres, H007M2_n2527TrabNombres
               }
               , new Object[] {
               H007M3_AGRID_nRecordCount
               }
            }
         );
         AV71Pgmname = "Reloj_Interface.Reloj_CodigoIDWW";
         /* GeneXus formulas. */
         AV71Pgmname = "Reloj_Interface.Reloj_CodigoIDWW";
         context.Gx_err = 0;
      }

      private short GRID_nEOF ;
      private short nGotPars ;
      private short GxWebError ;
      private short AV16DynamicFiltersOperator1 ;
      private short AV22DynamicFiltersOperator2 ;
      private short AV28DynamicFiltersOperator3 ;
      private short AV13OrderedBy ;
      private short initialized ;
      private short gxajaxcallmode ;
      private short A2498Reloj_ID ;
      private short A2591HorarioID ;
      private short wbEnd ;
      private short wbStart ;
      private short subGrid_Backcolorstyle ;
      private short subGrid_Titlebackstyle ;
      private short subGrid_Sortable ;
      private short AV66GridActions ;
      private short subGrid_Allowselection ;
      private short subGrid_Allowhovering ;
      private short subGrid_Allowcollapsing ;
      private short subGrid_Collapsed ;
      private short nDonePA ;
      private short AV73Reloj_interface_reloj_codigoidwwds_2_dynamicfiltersoperator1 ;
      private short AV79Reloj_interface_reloj_codigoidwwds_8_dynamicfiltersoperator2 ;
      private short AV85Reloj_interface_reloj_codigoidwwds_14_dynamicfiltersoperator3 ;
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
      private int AV62PageToGo ;
      private int imgAdddynamicfilters1_Visible ;
      private int imgRemovedynamicfilters1_Visible ;
      private int imgAdddynamicfilters2_Visible ;
      private int imgRemovedynamicfilters2_Visible ;
      private int edtavRhtrabajadornombres1_Visible ;
      private int edtavReloj_nombre1_Visible ;
      private int edtavHorariodescripcion1_Visible ;
      private int edtavRhtrabajadornombres2_Visible ;
      private int edtavReloj_nombre2_Visible ;
      private int edtavHorariodescripcion2_Visible ;
      private int edtavRhtrabajadornombres3_Visible ;
      private int edtavReloj_nombre3_Visible ;
      private int edtavHorariodescripcion3_Visible ;
      private int AV99GXV1 ;
      private int edtavRhtrabajadornombres3_Enabled ;
      private int edtavReloj_nombre3_Enabled ;
      private int edtavHorariodescripcion3_Enabled ;
      private int edtavRhtrabajadornombres2_Enabled ;
      private int edtavReloj_nombre2_Enabled ;
      private int edtavHorariodescripcion2_Enabled ;
      private int edtavRhtrabajadornombres1_Enabled ;
      private int edtavReloj_nombre1_Enabled ;
      private int edtavHorariodescripcion1_Enabled ;
      private int idxLst ;
      private int subGrid_Backcolor ;
      private long GRID_nFirstRecordOnPage ;
      private long AV63GridCurrentPage ;
      private long AV64GridPageCount ;
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
      private string sGXsfl_119_idx="0001" ;
      private string AV71Pgmname ;
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
      private string edtReloj_Nombre_Link ;
      private string edtRHTrabajadorNombres_Link ;
      private string edtHorarioDescripcion_Link ;
      private string Gridpaginationbar_Internalname ;
      private string divHtml_bottomauxiliarcontrols_Internalname ;
      private string Ddo_agexport_Internalname ;
      private string lblJsdynamicfilters_Internalname ;
      private string lblJsdynamicfilters_Caption ;
      private string lblJsdynamicfilters_Jsonclick ;
      private string Ddo_grid_Internalname ;
      private string Innewwindow1_Internalname ;
      private string Grid_empowerer_Internalname ;
      private string divDdo_lectura_iniauxdates_Internalname ;
      private string edtavDdo_lectura_iniauxdatetext_Internalname ;
      private string edtavDdo_lectura_iniauxdatetext_Jsonclick ;
      private string Tflectura_ini_rangepicker_Internalname ;
      private string sEvt ;
      private string EvtGridId ;
      private string EvtRowId ;
      private string sEvtType ;
      private string cmbavGridactions_Internalname ;
      private string edtCodigoId_Internalname ;
      private string edtReloj_Nombre_Internalname ;
      private string edtLectura_Ini_Internalname ;
      private string edtRHTrabajadorNombres_Internalname ;
      private string edtHorarioDescripcion_Internalname ;
      private string cmbavDynamicfiltersselector1_Internalname ;
      private string cmbavDynamicfiltersoperator1_Internalname ;
      private string cmbavDynamicfiltersselector2_Internalname ;
      private string cmbavDynamicfiltersoperator2_Internalname ;
      private string cmbavDynamicfiltersselector3_Internalname ;
      private string cmbavDynamicfiltersoperator3_Internalname ;
      private string scmdbuf ;
      private string edtavRhtrabajadornombres1_Internalname ;
      private string edtavReloj_nombre1_Internalname ;
      private string edtavHorariodescripcion1_Internalname ;
      private string edtavRhtrabajadornombres2_Internalname ;
      private string edtavReloj_nombre2_Internalname ;
      private string edtavHorariodescripcion2_Internalname ;
      private string edtavRhtrabajadornombres3_Internalname ;
      private string edtavReloj_nombre3_Internalname ;
      private string edtavHorariodescripcion3_Internalname ;
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
      private string cellFilter_rhtrabajadornombres3_cell_Internalname ;
      private string cellFilter_reloj_nombre3_cell_Internalname ;
      private string edtavReloj_nombre3_Jsonclick ;
      private string cellFilter_horariodescripcion3_cell_Internalname ;
      private string edtavHorariodescripcion3_Jsonclick ;
      private string cellDynamicfilters_removefilter3_cell_Internalname ;
      private string sImgUrl ;
      private string tblTablemergeddynamicfilters2_Internalname ;
      private string cmbavDynamicfiltersoperator2_Jsonclick ;
      private string cellFilter_rhtrabajadornombres2_cell_Internalname ;
      private string cellFilter_reloj_nombre2_cell_Internalname ;
      private string edtavReloj_nombre2_Jsonclick ;
      private string cellFilter_horariodescripcion2_cell_Internalname ;
      private string edtavHorariodescripcion2_Jsonclick ;
      private string cellDynamicfilters_addfilter2_cell_Internalname ;
      private string cellDynamicfilters_removefilter2_cell_Internalname ;
      private string tblTablemergeddynamicfilters1_Internalname ;
      private string cmbavDynamicfiltersoperator1_Jsonclick ;
      private string cellFilter_rhtrabajadornombres1_cell_Internalname ;
      private string cellFilter_reloj_nombre1_cell_Internalname ;
      private string edtavReloj_nombre1_Jsonclick ;
      private string cellFilter_horariodescripcion1_cell_Internalname ;
      private string edtavHorariodescripcion1_Jsonclick ;
      private string cellDynamicfilters_addfilter1_cell_Internalname ;
      private string cellDynamicfilters_removefilter1_cell_Internalname ;
      private string sGXsfl_119_fel_idx="0001" ;
      private string GXCCtl ;
      private string cmbavGridactions_Jsonclick ;
      private string ROClassString ;
      private string edtCodigoId_Jsonclick ;
      private string edtReloj_Nombre_Jsonclick ;
      private string edtLectura_Ini_Jsonclick ;
      private string edtRHTrabajadorNombres_Jsonclick ;
      private string edtHorarioDescripcion_Jsonclick ;
      private DateTime AV43TFLectura_Ini ;
      private DateTime AV44TFLectura_Ini_To ;
      private DateTime A2415Lectura_Ini ;
      private DateTime AV93Reloj_interface_reloj_codigoidwwds_22_tflectura_ini ;
      private DateTime AV94Reloj_interface_reloj_codigoidwwds_23_tflectura_ini_to ;
      private DateTime AV46DDO_Lectura_IniAuxDateTo ;
      private DateTime AV45DDO_Lectura_IniAuxDate ;
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
      private bool AV77Reloj_interface_reloj_codigoidwwds_6_dynamicfiltersenabled2 ;
      private bool AV83Reloj_interface_reloj_codigoidwwds_12_dynamicfiltersenabled3 ;
      private bool n2525TrabApePat ;
      private bool n2526TrabApeMat ;
      private bool n2527TrabNombres ;
      private bool returnInSub ;
      private bool gx_refresh_fired ;
      private string AV15DynamicFiltersSelector1 ;
      private string AV17RHTrabajadorNombres1 ;
      private string AV18Reloj_Nombre1 ;
      private string AV19HorarioDescripcion1 ;
      private string AV21DynamicFiltersSelector2 ;
      private string AV23RHTrabajadorNombres2 ;
      private string AV24Reloj_Nombre2 ;
      private string AV25HorarioDescripcion2 ;
      private string AV27DynamicFiltersSelector3 ;
      private string AV29RHTrabajadorNombres3 ;
      private string AV30Reloj_Nombre3 ;
      private string AV31HorarioDescripcion3 ;
      private string AV37TFCodigoId ;
      private string AV38TFCodigoId_Sel ;
      private string AV41TFReloj_Nombre ;
      private string AV42TFReloj_Nombre_Sel ;
      private string AV55TFRHTrabajadorNombres ;
      private string AV56TFRHTrabajadorNombres_Sel ;
      private string AV59TFHorarioDescripcion ;
      private string AV60TFHorarioDescripcion_Sel ;
      private string AV65GridAppliedFilters ;
      private string A2431CodigoId ;
      private string A2592Reloj_Nombre ;
      private string A2590RHTrabajadorNombres ;
      private string A2593HorarioDescripcion ;
      private string AV47DDO_Lectura_IniAuxDateText ;
      private string lV74Reloj_interface_reloj_codigoidwwds_3_rhtrabajadornombres1 ;
      private string lV75Reloj_interface_reloj_codigoidwwds_4_reloj_nombre1 ;
      private string lV76Reloj_interface_reloj_codigoidwwds_5_horariodescripcion1 ;
      private string lV80Reloj_interface_reloj_codigoidwwds_9_rhtrabajadornombres2 ;
      private string lV81Reloj_interface_reloj_codigoidwwds_10_reloj_nombre2 ;
      private string lV82Reloj_interface_reloj_codigoidwwds_11_horariodescripcion2 ;
      private string lV86Reloj_interface_reloj_codigoidwwds_15_rhtrabajadornombres3 ;
      private string lV87Reloj_interface_reloj_codigoidwwds_16_reloj_nombre3 ;
      private string lV88Reloj_interface_reloj_codigoidwwds_17_horariodescripcion3 ;
      private string lV89Reloj_interface_reloj_codigoidwwds_18_tfcodigoid ;
      private string lV91Reloj_interface_reloj_codigoidwwds_20_tfreloj_nombre ;
      private string lV95Reloj_interface_reloj_codigoidwwds_24_tfrhtrabajadornombres ;
      private string lV97Reloj_interface_reloj_codigoidwwds_26_tfhorariodescripcion ;
      private string AV72Reloj_interface_reloj_codigoidwwds_1_dynamicfiltersselector1 ;
      private string AV74Reloj_interface_reloj_codigoidwwds_3_rhtrabajadornombres1 ;
      private string AV75Reloj_interface_reloj_codigoidwwds_4_reloj_nombre1 ;
      private string AV76Reloj_interface_reloj_codigoidwwds_5_horariodescripcion1 ;
      private string AV78Reloj_interface_reloj_codigoidwwds_7_dynamicfiltersselector2 ;
      private string AV80Reloj_interface_reloj_codigoidwwds_9_rhtrabajadornombres2 ;
      private string AV81Reloj_interface_reloj_codigoidwwds_10_reloj_nombre2 ;
      private string AV82Reloj_interface_reloj_codigoidwwds_11_horariodescripcion2 ;
      private string AV84Reloj_interface_reloj_codigoidwwds_13_dynamicfiltersselector3 ;
      private string AV86Reloj_interface_reloj_codigoidwwds_15_rhtrabajadornombres3 ;
      private string AV87Reloj_interface_reloj_codigoidwwds_16_reloj_nombre3 ;
      private string AV88Reloj_interface_reloj_codigoidwwds_17_horariodescripcion3 ;
      private string AV90Reloj_interface_reloj_codigoidwwds_19_tfcodigoid_sel ;
      private string AV89Reloj_interface_reloj_codigoidwwds_18_tfcodigoid ;
      private string AV92Reloj_interface_reloj_codigoidwwds_21_tfreloj_nombre_sel ;
      private string AV91Reloj_interface_reloj_codigoidwwds_20_tfreloj_nombre ;
      private string AV96Reloj_interface_reloj_codigoidwwds_25_tfrhtrabajadornombres_sel ;
      private string AV95Reloj_interface_reloj_codigoidwwds_24_tfrhtrabajadornombres ;
      private string AV98Reloj_interface_reloj_codigoidwwds_27_tfhorariodescripcion_sel ;
      private string AV97Reloj_interface_reloj_codigoidwwds_26_tfhorariodescripcion ;
      private string A2525TrabApePat ;
      private string A2526TrabApeMat ;
      private string A2527TrabNombres ;
      private string A2589RHTrabajadorCodigo ;
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
      private GXUserControl ucTflectura_ini_rangepicker ;
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
      private string[] H007M2_A2589RHTrabajadorCodigo ;
      private short[] H007M2_A2498Reloj_ID ;
      private short[] H007M2_A2591HorarioID ;
      private string[] H007M2_A2593HorarioDescripcion ;
      private string[] H007M2_A2590RHTrabajadorNombres ;
      private DateTime[] H007M2_A2415Lectura_Ini ;
      private string[] H007M2_A2592Reloj_Nombre ;
      private string[] H007M2_A2431CodigoId ;
      private string[] H007M2_A2525TrabApePat ;
      private bool[] H007M2_n2525TrabApePat ;
      private string[] H007M2_A2526TrabApeMat ;
      private bool[] H007M2_n2526TrabApeMat ;
      private string[] H007M2_A2527TrabNombres ;
      private bool[] H007M2_n2527TrabNombres ;
      private long[] H007M3_AGRID_nRecordCount ;
      private msglist BackMsgLst ;
      private msglist LclMsgLst ;
      private GxHttpRequest AV7HTTPRequest ;
      private GXBaseCollection<GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTDropDownOptionsData_Item> AV67AGExportData ;
      private GXWebForm Form ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPContext AV6WWPContext ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPTransactionContext AV8TrnContext ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPGridState AV10GridState ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue AV11GridStateFilterValue ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter AV12GridStateDynamicFilter ;
      private GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTDropDownOptionsTitleSettingsIcons AV61DDO_TitleSettingsIcons ;
      private GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTDropDownOptionsTitleSettingsIcons GXt_SdtDVB_SDTDropDownOptionsTitleSettingsIcons1 ;
      private GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTDropDownOptionsData_Item AV68AGExportDataItem ;
   }

   public class reloj_codigoidww__default : DataStoreHelperBase, IDataStoreHelper
   {
      protected Object[] conditional_H007M2( IGxContext context ,
                                             string AV72Reloj_interface_reloj_codigoidwwds_1_dynamicfiltersselector1 ,
                                             short AV73Reloj_interface_reloj_codigoidwwds_2_dynamicfiltersoperator1 ,
                                             string AV74Reloj_interface_reloj_codigoidwwds_3_rhtrabajadornombres1 ,
                                             string AV75Reloj_interface_reloj_codigoidwwds_4_reloj_nombre1 ,
                                             string AV76Reloj_interface_reloj_codigoidwwds_5_horariodescripcion1 ,
                                             bool AV77Reloj_interface_reloj_codigoidwwds_6_dynamicfiltersenabled2 ,
                                             string AV78Reloj_interface_reloj_codigoidwwds_7_dynamicfiltersselector2 ,
                                             short AV79Reloj_interface_reloj_codigoidwwds_8_dynamicfiltersoperator2 ,
                                             string AV80Reloj_interface_reloj_codigoidwwds_9_rhtrabajadornombres2 ,
                                             string AV81Reloj_interface_reloj_codigoidwwds_10_reloj_nombre2 ,
                                             string AV82Reloj_interface_reloj_codigoidwwds_11_horariodescripcion2 ,
                                             bool AV83Reloj_interface_reloj_codigoidwwds_12_dynamicfiltersenabled3 ,
                                             string AV84Reloj_interface_reloj_codigoidwwds_13_dynamicfiltersselector3 ,
                                             short AV85Reloj_interface_reloj_codigoidwwds_14_dynamicfiltersoperator3 ,
                                             string AV86Reloj_interface_reloj_codigoidwwds_15_rhtrabajadornombres3 ,
                                             string AV87Reloj_interface_reloj_codigoidwwds_16_reloj_nombre3 ,
                                             string AV88Reloj_interface_reloj_codigoidwwds_17_horariodescripcion3 ,
                                             string AV90Reloj_interface_reloj_codigoidwwds_19_tfcodigoid_sel ,
                                             string AV89Reloj_interface_reloj_codigoidwwds_18_tfcodigoid ,
                                             string AV92Reloj_interface_reloj_codigoidwwds_21_tfreloj_nombre_sel ,
                                             string AV91Reloj_interface_reloj_codigoidwwds_20_tfreloj_nombre ,
                                             DateTime AV93Reloj_interface_reloj_codigoidwwds_22_tflectura_ini ,
                                             DateTime AV94Reloj_interface_reloj_codigoidwwds_23_tflectura_ini_to ,
                                             string AV96Reloj_interface_reloj_codigoidwwds_25_tfrhtrabajadornombres_sel ,
                                             string AV95Reloj_interface_reloj_codigoidwwds_24_tfrhtrabajadornombres ,
                                             string AV98Reloj_interface_reloj_codigoidwwds_27_tfhorariodescripcion_sel ,
                                             string AV97Reloj_interface_reloj_codigoidwwds_26_tfhorariodescripcion ,
                                             string A2525TrabApePat ,
                                             string A2526TrabApeMat ,
                                             string A2527TrabNombres ,
                                             string A2592Reloj_Nombre ,
                                             string A2593HorarioDescripcion ,
                                             string A2431CodigoId ,
                                             DateTime A2415Lectura_Ini ,
                                             short AV13OrderedBy ,
                                             bool AV14OrderedDsc )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int6 = new short[31];
         Object[] GXv_Object7 = new Object[2];
         string sSelectString;
         string sFromString;
         string sOrderString;
         sSelectString = " T1.[RHTrabajadorCodigo] AS RHTrabajadorCodigo, T1.[Reloj_ID] AS Reloj_ID, T1.[HorarioID] AS HorarioID, T4.[Horario_Dsc] AS HorarioDescripcion, RTRIM(LTRIM(COALESCE( T2.[TrabApePat], ''))) + ' ' + RTRIM(LTRIM(COALESCE( T2.[TrabApeMat], ''))) + ' ' + RTRIM(LTRIM(COALESCE( T2.[TrabNombres], ''))) AS RHTrabajadorNombres, T1.[Lectura_Ini], T3.[Reloj_Nom] AS Reloj_Nombre, T1.[CodigoId], T2.[TrabApePat], T2.[TrabApeMat], T2.[TrabNombres]";
         sFromString = " FROM ((([Reloj_CodigoID] T1 INNER JOIN [Trab_Trabajador] T2 ON T2.[TrabCodigo] = T1.[RHTrabajadorCodigo]) INNER JOIN [Reloj] T3 ON T3.[RelojID] = T1.[Reloj_ID]) INNER JOIN [Reloj_Horario] T4 ON T4.[Horario_ID] = T1.[HorarioID])";
         sOrderString = "";
         if ( ( StringUtil.StrCmp(AV72Reloj_interface_reloj_codigoidwwds_1_dynamicfiltersselector1, "RHTRABAJADORNOMBRES") == 0 ) && ( AV73Reloj_interface_reloj_codigoidwwds_2_dynamicfiltersoperator1 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV74Reloj_interface_reloj_codigoidwwds_3_rhtrabajadornombres1)) ) )
         {
            AddWhere(sWhereString, "(RTRIM(LTRIM(T2.[TrabApePat])) + ' ' + RTRIM(LTRIM(T2.[TrabApeMat])) + ' ' + RTRIM(LTRIM(T2.[TrabNombres])) like @lV74Reloj_interface_reloj_codigoidwwds_3_rhtrabajadornombres1)");
         }
         else
         {
            GXv_int6[0] = 1;
         }
         if ( ( StringUtil.StrCmp(AV72Reloj_interface_reloj_codigoidwwds_1_dynamicfiltersselector1, "RHTRABAJADORNOMBRES") == 0 ) && ( AV73Reloj_interface_reloj_codigoidwwds_2_dynamicfiltersoperator1 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV74Reloj_interface_reloj_codigoidwwds_3_rhtrabajadornombres1)) ) )
         {
            AddWhere(sWhereString, "(RTRIM(LTRIM(T2.[TrabApePat])) + ' ' + RTRIM(LTRIM(T2.[TrabApeMat])) + ' ' + RTRIM(LTRIM(T2.[TrabNombres])) like '%' + @lV74Reloj_interface_reloj_codigoidwwds_3_rhtrabajadornombres1)");
         }
         else
         {
            GXv_int6[1] = 1;
         }
         if ( ( StringUtil.StrCmp(AV72Reloj_interface_reloj_codigoidwwds_1_dynamicfiltersselector1, "RELOJ_NOMBRE") == 0 ) && ( AV73Reloj_interface_reloj_codigoidwwds_2_dynamicfiltersoperator1 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV75Reloj_interface_reloj_codigoidwwds_4_reloj_nombre1)) ) )
         {
            AddWhere(sWhereString, "(T3.[Reloj_Nom] like @lV75Reloj_interface_reloj_codigoidwwds_4_reloj_nombre1)");
         }
         else
         {
            GXv_int6[2] = 1;
         }
         if ( ( StringUtil.StrCmp(AV72Reloj_interface_reloj_codigoidwwds_1_dynamicfiltersselector1, "RELOJ_NOMBRE") == 0 ) && ( AV73Reloj_interface_reloj_codigoidwwds_2_dynamicfiltersoperator1 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV75Reloj_interface_reloj_codigoidwwds_4_reloj_nombre1)) ) )
         {
            AddWhere(sWhereString, "(T3.[Reloj_Nom] like '%' + @lV75Reloj_interface_reloj_codigoidwwds_4_reloj_nombre1)");
         }
         else
         {
            GXv_int6[3] = 1;
         }
         if ( ( StringUtil.StrCmp(AV72Reloj_interface_reloj_codigoidwwds_1_dynamicfiltersselector1, "HORARIODESCRIPCION") == 0 ) && ( AV73Reloj_interface_reloj_codigoidwwds_2_dynamicfiltersoperator1 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV76Reloj_interface_reloj_codigoidwwds_5_horariodescripcion1)) ) )
         {
            AddWhere(sWhereString, "(T4.[Horario_Dsc] like @lV76Reloj_interface_reloj_codigoidwwds_5_horariodescripcion1)");
         }
         else
         {
            GXv_int6[4] = 1;
         }
         if ( ( StringUtil.StrCmp(AV72Reloj_interface_reloj_codigoidwwds_1_dynamicfiltersselector1, "HORARIODESCRIPCION") == 0 ) && ( AV73Reloj_interface_reloj_codigoidwwds_2_dynamicfiltersoperator1 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV76Reloj_interface_reloj_codigoidwwds_5_horariodescripcion1)) ) )
         {
            AddWhere(sWhereString, "(T4.[Horario_Dsc] like '%' + @lV76Reloj_interface_reloj_codigoidwwds_5_horariodescripcion1)");
         }
         else
         {
            GXv_int6[5] = 1;
         }
         if ( AV77Reloj_interface_reloj_codigoidwwds_6_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV78Reloj_interface_reloj_codigoidwwds_7_dynamicfiltersselector2, "RHTRABAJADORNOMBRES") == 0 ) && ( AV79Reloj_interface_reloj_codigoidwwds_8_dynamicfiltersoperator2 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV80Reloj_interface_reloj_codigoidwwds_9_rhtrabajadornombres2)) ) )
         {
            AddWhere(sWhereString, "(RTRIM(LTRIM(T2.[TrabApePat])) + ' ' + RTRIM(LTRIM(T2.[TrabApeMat])) + ' ' + RTRIM(LTRIM(T2.[TrabNombres])) like @lV80Reloj_interface_reloj_codigoidwwds_9_rhtrabajadornombres2)");
         }
         else
         {
            GXv_int6[6] = 1;
         }
         if ( AV77Reloj_interface_reloj_codigoidwwds_6_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV78Reloj_interface_reloj_codigoidwwds_7_dynamicfiltersselector2, "RHTRABAJADORNOMBRES") == 0 ) && ( AV79Reloj_interface_reloj_codigoidwwds_8_dynamicfiltersoperator2 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV80Reloj_interface_reloj_codigoidwwds_9_rhtrabajadornombres2)) ) )
         {
            AddWhere(sWhereString, "(RTRIM(LTRIM(T2.[TrabApePat])) + ' ' + RTRIM(LTRIM(T2.[TrabApeMat])) + ' ' + RTRIM(LTRIM(T2.[TrabNombres])) like '%' + @lV80Reloj_interface_reloj_codigoidwwds_9_rhtrabajadornombres2)");
         }
         else
         {
            GXv_int6[7] = 1;
         }
         if ( AV77Reloj_interface_reloj_codigoidwwds_6_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV78Reloj_interface_reloj_codigoidwwds_7_dynamicfiltersselector2, "RELOJ_NOMBRE") == 0 ) && ( AV79Reloj_interface_reloj_codigoidwwds_8_dynamicfiltersoperator2 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV81Reloj_interface_reloj_codigoidwwds_10_reloj_nombre2)) ) )
         {
            AddWhere(sWhereString, "(T3.[Reloj_Nom] like @lV81Reloj_interface_reloj_codigoidwwds_10_reloj_nombre2)");
         }
         else
         {
            GXv_int6[8] = 1;
         }
         if ( AV77Reloj_interface_reloj_codigoidwwds_6_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV78Reloj_interface_reloj_codigoidwwds_7_dynamicfiltersselector2, "RELOJ_NOMBRE") == 0 ) && ( AV79Reloj_interface_reloj_codigoidwwds_8_dynamicfiltersoperator2 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV81Reloj_interface_reloj_codigoidwwds_10_reloj_nombre2)) ) )
         {
            AddWhere(sWhereString, "(T3.[Reloj_Nom] like '%' + @lV81Reloj_interface_reloj_codigoidwwds_10_reloj_nombre2)");
         }
         else
         {
            GXv_int6[9] = 1;
         }
         if ( AV77Reloj_interface_reloj_codigoidwwds_6_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV78Reloj_interface_reloj_codigoidwwds_7_dynamicfiltersselector2, "HORARIODESCRIPCION") == 0 ) && ( AV79Reloj_interface_reloj_codigoidwwds_8_dynamicfiltersoperator2 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV82Reloj_interface_reloj_codigoidwwds_11_horariodescripcion2)) ) )
         {
            AddWhere(sWhereString, "(T4.[Horario_Dsc] like @lV82Reloj_interface_reloj_codigoidwwds_11_horariodescripcion2)");
         }
         else
         {
            GXv_int6[10] = 1;
         }
         if ( AV77Reloj_interface_reloj_codigoidwwds_6_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV78Reloj_interface_reloj_codigoidwwds_7_dynamicfiltersselector2, "HORARIODESCRIPCION") == 0 ) && ( AV79Reloj_interface_reloj_codigoidwwds_8_dynamicfiltersoperator2 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV82Reloj_interface_reloj_codigoidwwds_11_horariodescripcion2)) ) )
         {
            AddWhere(sWhereString, "(T4.[Horario_Dsc] like '%' + @lV82Reloj_interface_reloj_codigoidwwds_11_horariodescripcion2)");
         }
         else
         {
            GXv_int6[11] = 1;
         }
         if ( AV83Reloj_interface_reloj_codigoidwwds_12_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV84Reloj_interface_reloj_codigoidwwds_13_dynamicfiltersselector3, "RHTRABAJADORNOMBRES") == 0 ) && ( AV85Reloj_interface_reloj_codigoidwwds_14_dynamicfiltersoperator3 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV86Reloj_interface_reloj_codigoidwwds_15_rhtrabajadornombres3)) ) )
         {
            AddWhere(sWhereString, "(RTRIM(LTRIM(T2.[TrabApePat])) + ' ' + RTRIM(LTRIM(T2.[TrabApeMat])) + ' ' + RTRIM(LTRIM(T2.[TrabNombres])) like @lV86Reloj_interface_reloj_codigoidwwds_15_rhtrabajadornombres3)");
         }
         else
         {
            GXv_int6[12] = 1;
         }
         if ( AV83Reloj_interface_reloj_codigoidwwds_12_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV84Reloj_interface_reloj_codigoidwwds_13_dynamicfiltersselector3, "RHTRABAJADORNOMBRES") == 0 ) && ( AV85Reloj_interface_reloj_codigoidwwds_14_dynamicfiltersoperator3 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV86Reloj_interface_reloj_codigoidwwds_15_rhtrabajadornombres3)) ) )
         {
            AddWhere(sWhereString, "(RTRIM(LTRIM(T2.[TrabApePat])) + ' ' + RTRIM(LTRIM(T2.[TrabApeMat])) + ' ' + RTRIM(LTRIM(T2.[TrabNombres])) like '%' + @lV86Reloj_interface_reloj_codigoidwwds_15_rhtrabajadornombres3)");
         }
         else
         {
            GXv_int6[13] = 1;
         }
         if ( AV83Reloj_interface_reloj_codigoidwwds_12_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV84Reloj_interface_reloj_codigoidwwds_13_dynamicfiltersselector3, "RELOJ_NOMBRE") == 0 ) && ( AV85Reloj_interface_reloj_codigoidwwds_14_dynamicfiltersoperator3 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV87Reloj_interface_reloj_codigoidwwds_16_reloj_nombre3)) ) )
         {
            AddWhere(sWhereString, "(T3.[Reloj_Nom] like @lV87Reloj_interface_reloj_codigoidwwds_16_reloj_nombre3)");
         }
         else
         {
            GXv_int6[14] = 1;
         }
         if ( AV83Reloj_interface_reloj_codigoidwwds_12_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV84Reloj_interface_reloj_codigoidwwds_13_dynamicfiltersselector3, "RELOJ_NOMBRE") == 0 ) && ( AV85Reloj_interface_reloj_codigoidwwds_14_dynamicfiltersoperator3 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV87Reloj_interface_reloj_codigoidwwds_16_reloj_nombre3)) ) )
         {
            AddWhere(sWhereString, "(T3.[Reloj_Nom] like '%' + @lV87Reloj_interface_reloj_codigoidwwds_16_reloj_nombre3)");
         }
         else
         {
            GXv_int6[15] = 1;
         }
         if ( AV83Reloj_interface_reloj_codigoidwwds_12_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV84Reloj_interface_reloj_codigoidwwds_13_dynamicfiltersselector3, "HORARIODESCRIPCION") == 0 ) && ( AV85Reloj_interface_reloj_codigoidwwds_14_dynamicfiltersoperator3 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV88Reloj_interface_reloj_codigoidwwds_17_horariodescripcion3)) ) )
         {
            AddWhere(sWhereString, "(T4.[Horario_Dsc] like @lV88Reloj_interface_reloj_codigoidwwds_17_horariodescripcion3)");
         }
         else
         {
            GXv_int6[16] = 1;
         }
         if ( AV83Reloj_interface_reloj_codigoidwwds_12_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV84Reloj_interface_reloj_codigoidwwds_13_dynamicfiltersselector3, "HORARIODESCRIPCION") == 0 ) && ( AV85Reloj_interface_reloj_codigoidwwds_14_dynamicfiltersoperator3 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV88Reloj_interface_reloj_codigoidwwds_17_horariodescripcion3)) ) )
         {
            AddWhere(sWhereString, "(T4.[Horario_Dsc] like '%' + @lV88Reloj_interface_reloj_codigoidwwds_17_horariodescripcion3)");
         }
         else
         {
            GXv_int6[17] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV90Reloj_interface_reloj_codigoidwwds_19_tfcodigoid_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV89Reloj_interface_reloj_codigoidwwds_18_tfcodigoid)) ) )
         {
            AddWhere(sWhereString, "(T1.[CodigoId] like @lV89Reloj_interface_reloj_codigoidwwds_18_tfcodigoid)");
         }
         else
         {
            GXv_int6[18] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV90Reloj_interface_reloj_codigoidwwds_19_tfcodigoid_sel)) )
         {
            AddWhere(sWhereString, "(T1.[CodigoId] = @AV90Reloj_interface_reloj_codigoidwwds_19_tfcodigoid_sel)");
         }
         else
         {
            GXv_int6[19] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV92Reloj_interface_reloj_codigoidwwds_21_tfreloj_nombre_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV91Reloj_interface_reloj_codigoidwwds_20_tfreloj_nombre)) ) )
         {
            AddWhere(sWhereString, "(T3.[Reloj_Nom] like @lV91Reloj_interface_reloj_codigoidwwds_20_tfreloj_nombre)");
         }
         else
         {
            GXv_int6[20] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV92Reloj_interface_reloj_codigoidwwds_21_tfreloj_nombre_sel)) )
         {
            AddWhere(sWhereString, "(T3.[Reloj_Nom] = @AV92Reloj_interface_reloj_codigoidwwds_21_tfreloj_nombre_sel)");
         }
         else
         {
            GXv_int6[21] = 1;
         }
         if ( ! (DateTime.MinValue==AV93Reloj_interface_reloj_codigoidwwds_22_tflectura_ini) )
         {
            AddWhere(sWhereString, "(T1.[Lectura_Ini] >= @AV93Reloj_interface_reloj_codigoidwwds_22_tflectura_ini)");
         }
         else
         {
            GXv_int6[22] = 1;
         }
         if ( ! (DateTime.MinValue==AV94Reloj_interface_reloj_codigoidwwds_23_tflectura_ini_to) )
         {
            AddWhere(sWhereString, "(T1.[Lectura_Ini] <= @AV94Reloj_interface_reloj_codigoidwwds_23_tflectura_ini_to)");
         }
         else
         {
            GXv_int6[23] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV96Reloj_interface_reloj_codigoidwwds_25_tfrhtrabajadornombres_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV95Reloj_interface_reloj_codigoidwwds_24_tfrhtrabajadornombres)) ) )
         {
            AddWhere(sWhereString, "(RTRIM(LTRIM(T2.[TrabApePat])) + ' ' + RTRIM(LTRIM(T2.[TrabApeMat])) + ' ' + RTRIM(LTRIM(T2.[TrabNombres])) like @lV95Reloj_interface_reloj_codigoidwwds_24_tfrhtrabajadornombres)");
         }
         else
         {
            GXv_int6[24] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV96Reloj_interface_reloj_codigoidwwds_25_tfrhtrabajadornombres_sel)) )
         {
            AddWhere(sWhereString, "(RTRIM(LTRIM(T2.[TrabApePat])) + ' ' + RTRIM(LTRIM(T2.[TrabApeMat])) + ' ' + RTRIM(LTRIM(T2.[TrabNombres])) = @AV96Reloj_interface_reloj_codigoidwwds_25_tfrhtrabajadornombres_sel)");
         }
         else
         {
            GXv_int6[25] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV98Reloj_interface_reloj_codigoidwwds_27_tfhorariodescripcion_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV97Reloj_interface_reloj_codigoidwwds_26_tfhorariodescripcion)) ) )
         {
            AddWhere(sWhereString, "(T4.[Horario_Dsc] like @lV97Reloj_interface_reloj_codigoidwwds_26_tfhorariodescripcion)");
         }
         else
         {
            GXv_int6[26] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV98Reloj_interface_reloj_codigoidwwds_27_tfhorariodescripcion_sel)) )
         {
            AddWhere(sWhereString, "(T4.[Horario_Dsc] = @AV98Reloj_interface_reloj_codigoidwwds_27_tfhorariodescripcion_sel)");
         }
         else
         {
            GXv_int6[27] = 1;
         }
         if ( ( AV13OrderedBy == 1 ) && ! AV14OrderedDsc )
         {
            sOrderString += " ORDER BY [RHTrabajadorNombres]";
         }
         else if ( ( AV13OrderedBy == 1 ) && ( AV14OrderedDsc ) )
         {
            sOrderString += " ORDER BY [RHTrabajadorNombres] DESC";
         }
         else if ( ( AV13OrderedBy == 2 ) && ! AV14OrderedDsc )
         {
            sOrderString += " ORDER BY T1.[CodigoId]";
         }
         else if ( ( AV13OrderedBy == 2 ) && ( AV14OrderedDsc ) )
         {
            sOrderString += " ORDER BY T1.[CodigoId] DESC";
         }
         else if ( ( AV13OrderedBy == 3 ) && ! AV14OrderedDsc )
         {
            sOrderString += " ORDER BY T3.[Reloj_Nom]";
         }
         else if ( ( AV13OrderedBy == 3 ) && ( AV14OrderedDsc ) )
         {
            sOrderString += " ORDER BY T3.[Reloj_Nom] DESC";
         }
         else if ( ( AV13OrderedBy == 4 ) && ! AV14OrderedDsc )
         {
            sOrderString += " ORDER BY T1.[Lectura_Ini]";
         }
         else if ( ( AV13OrderedBy == 4 ) && ( AV14OrderedDsc ) )
         {
            sOrderString += " ORDER BY T1.[Lectura_Ini] DESC";
         }
         else if ( ( AV13OrderedBy == 5 ) && ! AV14OrderedDsc )
         {
            sOrderString += " ORDER BY T4.[Horario_Dsc]";
         }
         else if ( ( AV13OrderedBy == 5 ) && ( AV14OrderedDsc ) )
         {
            sOrderString += " ORDER BY T4.[Horario_Dsc] DESC";
         }
         else if ( true )
         {
            sOrderString += " ORDER BY T1.[CodigoId]";
         }
         scmdbuf = "SELECT " + sSelectString + sFromString + sWhereString + sOrderString + "" + " OFFSET " + "@GXPagingFrom2" + " ROWS FETCH NEXT CAST((SELECT CASE WHEN " + "@GXPagingTo2" + " > 0 THEN " + "@GXPagingTo2" + " ELSE 1e9 END) AS INTEGER) ROWS ONLY";
         GXv_Object7[0] = scmdbuf;
         GXv_Object7[1] = GXv_int6;
         return GXv_Object7 ;
      }

      protected Object[] conditional_H007M3( IGxContext context ,
                                             string AV72Reloj_interface_reloj_codigoidwwds_1_dynamicfiltersselector1 ,
                                             short AV73Reloj_interface_reloj_codigoidwwds_2_dynamicfiltersoperator1 ,
                                             string AV74Reloj_interface_reloj_codigoidwwds_3_rhtrabajadornombres1 ,
                                             string AV75Reloj_interface_reloj_codigoidwwds_4_reloj_nombre1 ,
                                             string AV76Reloj_interface_reloj_codigoidwwds_5_horariodescripcion1 ,
                                             bool AV77Reloj_interface_reloj_codigoidwwds_6_dynamicfiltersenabled2 ,
                                             string AV78Reloj_interface_reloj_codigoidwwds_7_dynamicfiltersselector2 ,
                                             short AV79Reloj_interface_reloj_codigoidwwds_8_dynamicfiltersoperator2 ,
                                             string AV80Reloj_interface_reloj_codigoidwwds_9_rhtrabajadornombres2 ,
                                             string AV81Reloj_interface_reloj_codigoidwwds_10_reloj_nombre2 ,
                                             string AV82Reloj_interface_reloj_codigoidwwds_11_horariodescripcion2 ,
                                             bool AV83Reloj_interface_reloj_codigoidwwds_12_dynamicfiltersenabled3 ,
                                             string AV84Reloj_interface_reloj_codigoidwwds_13_dynamicfiltersselector3 ,
                                             short AV85Reloj_interface_reloj_codigoidwwds_14_dynamicfiltersoperator3 ,
                                             string AV86Reloj_interface_reloj_codigoidwwds_15_rhtrabajadornombres3 ,
                                             string AV87Reloj_interface_reloj_codigoidwwds_16_reloj_nombre3 ,
                                             string AV88Reloj_interface_reloj_codigoidwwds_17_horariodescripcion3 ,
                                             string AV90Reloj_interface_reloj_codigoidwwds_19_tfcodigoid_sel ,
                                             string AV89Reloj_interface_reloj_codigoidwwds_18_tfcodigoid ,
                                             string AV92Reloj_interface_reloj_codigoidwwds_21_tfreloj_nombre_sel ,
                                             string AV91Reloj_interface_reloj_codigoidwwds_20_tfreloj_nombre ,
                                             DateTime AV93Reloj_interface_reloj_codigoidwwds_22_tflectura_ini ,
                                             DateTime AV94Reloj_interface_reloj_codigoidwwds_23_tflectura_ini_to ,
                                             string AV96Reloj_interface_reloj_codigoidwwds_25_tfrhtrabajadornombres_sel ,
                                             string AV95Reloj_interface_reloj_codigoidwwds_24_tfrhtrabajadornombres ,
                                             string AV98Reloj_interface_reloj_codigoidwwds_27_tfhorariodescripcion_sel ,
                                             string AV97Reloj_interface_reloj_codigoidwwds_26_tfhorariodescripcion ,
                                             string A2525TrabApePat ,
                                             string A2526TrabApeMat ,
                                             string A2527TrabNombres ,
                                             string A2592Reloj_Nombre ,
                                             string A2593HorarioDescripcion ,
                                             string A2431CodigoId ,
                                             DateTime A2415Lectura_Ini ,
                                             short AV13OrderedBy ,
                                             bool AV14OrderedDsc )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int8 = new short[28];
         Object[] GXv_Object9 = new Object[2];
         scmdbuf = "SELECT COUNT(*) FROM ((([Reloj_CodigoID] T1 INNER JOIN [Trab_Trabajador] T2 ON T2.[TrabCodigo] = T1.[RHTrabajadorCodigo]) INNER JOIN [Reloj] T3 ON T3.[RelojID] = T1.[Reloj_ID]) INNER JOIN [Reloj_Horario] T4 ON T4.[Horario_ID] = T1.[HorarioID])";
         if ( ( StringUtil.StrCmp(AV72Reloj_interface_reloj_codigoidwwds_1_dynamicfiltersselector1, "RHTRABAJADORNOMBRES") == 0 ) && ( AV73Reloj_interface_reloj_codigoidwwds_2_dynamicfiltersoperator1 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV74Reloj_interface_reloj_codigoidwwds_3_rhtrabajadornombres1)) ) )
         {
            AddWhere(sWhereString, "(RTRIM(LTRIM(T2.[TrabApePat])) + ' ' + RTRIM(LTRIM(T2.[TrabApeMat])) + ' ' + RTRIM(LTRIM(T2.[TrabNombres])) like @lV74Reloj_interface_reloj_codigoidwwds_3_rhtrabajadornombres1)");
         }
         else
         {
            GXv_int8[0] = 1;
         }
         if ( ( StringUtil.StrCmp(AV72Reloj_interface_reloj_codigoidwwds_1_dynamicfiltersselector1, "RHTRABAJADORNOMBRES") == 0 ) && ( AV73Reloj_interface_reloj_codigoidwwds_2_dynamicfiltersoperator1 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV74Reloj_interface_reloj_codigoidwwds_3_rhtrabajadornombres1)) ) )
         {
            AddWhere(sWhereString, "(RTRIM(LTRIM(T2.[TrabApePat])) + ' ' + RTRIM(LTRIM(T2.[TrabApeMat])) + ' ' + RTRIM(LTRIM(T2.[TrabNombres])) like '%' + @lV74Reloj_interface_reloj_codigoidwwds_3_rhtrabajadornombres1)");
         }
         else
         {
            GXv_int8[1] = 1;
         }
         if ( ( StringUtil.StrCmp(AV72Reloj_interface_reloj_codigoidwwds_1_dynamicfiltersselector1, "RELOJ_NOMBRE") == 0 ) && ( AV73Reloj_interface_reloj_codigoidwwds_2_dynamicfiltersoperator1 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV75Reloj_interface_reloj_codigoidwwds_4_reloj_nombre1)) ) )
         {
            AddWhere(sWhereString, "(T3.[Reloj_Nom] like @lV75Reloj_interface_reloj_codigoidwwds_4_reloj_nombre1)");
         }
         else
         {
            GXv_int8[2] = 1;
         }
         if ( ( StringUtil.StrCmp(AV72Reloj_interface_reloj_codigoidwwds_1_dynamicfiltersselector1, "RELOJ_NOMBRE") == 0 ) && ( AV73Reloj_interface_reloj_codigoidwwds_2_dynamicfiltersoperator1 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV75Reloj_interface_reloj_codigoidwwds_4_reloj_nombre1)) ) )
         {
            AddWhere(sWhereString, "(T3.[Reloj_Nom] like '%' + @lV75Reloj_interface_reloj_codigoidwwds_4_reloj_nombre1)");
         }
         else
         {
            GXv_int8[3] = 1;
         }
         if ( ( StringUtil.StrCmp(AV72Reloj_interface_reloj_codigoidwwds_1_dynamicfiltersselector1, "HORARIODESCRIPCION") == 0 ) && ( AV73Reloj_interface_reloj_codigoidwwds_2_dynamicfiltersoperator1 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV76Reloj_interface_reloj_codigoidwwds_5_horariodescripcion1)) ) )
         {
            AddWhere(sWhereString, "(T4.[Horario_Dsc] like @lV76Reloj_interface_reloj_codigoidwwds_5_horariodescripcion1)");
         }
         else
         {
            GXv_int8[4] = 1;
         }
         if ( ( StringUtil.StrCmp(AV72Reloj_interface_reloj_codigoidwwds_1_dynamicfiltersselector1, "HORARIODESCRIPCION") == 0 ) && ( AV73Reloj_interface_reloj_codigoidwwds_2_dynamicfiltersoperator1 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV76Reloj_interface_reloj_codigoidwwds_5_horariodescripcion1)) ) )
         {
            AddWhere(sWhereString, "(T4.[Horario_Dsc] like '%' + @lV76Reloj_interface_reloj_codigoidwwds_5_horariodescripcion1)");
         }
         else
         {
            GXv_int8[5] = 1;
         }
         if ( AV77Reloj_interface_reloj_codigoidwwds_6_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV78Reloj_interface_reloj_codigoidwwds_7_dynamicfiltersselector2, "RHTRABAJADORNOMBRES") == 0 ) && ( AV79Reloj_interface_reloj_codigoidwwds_8_dynamicfiltersoperator2 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV80Reloj_interface_reloj_codigoidwwds_9_rhtrabajadornombres2)) ) )
         {
            AddWhere(sWhereString, "(RTRIM(LTRIM(T2.[TrabApePat])) + ' ' + RTRIM(LTRIM(T2.[TrabApeMat])) + ' ' + RTRIM(LTRIM(T2.[TrabNombres])) like @lV80Reloj_interface_reloj_codigoidwwds_9_rhtrabajadornombres2)");
         }
         else
         {
            GXv_int8[6] = 1;
         }
         if ( AV77Reloj_interface_reloj_codigoidwwds_6_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV78Reloj_interface_reloj_codigoidwwds_7_dynamicfiltersselector2, "RHTRABAJADORNOMBRES") == 0 ) && ( AV79Reloj_interface_reloj_codigoidwwds_8_dynamicfiltersoperator2 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV80Reloj_interface_reloj_codigoidwwds_9_rhtrabajadornombres2)) ) )
         {
            AddWhere(sWhereString, "(RTRIM(LTRIM(T2.[TrabApePat])) + ' ' + RTRIM(LTRIM(T2.[TrabApeMat])) + ' ' + RTRIM(LTRIM(T2.[TrabNombres])) like '%' + @lV80Reloj_interface_reloj_codigoidwwds_9_rhtrabajadornombres2)");
         }
         else
         {
            GXv_int8[7] = 1;
         }
         if ( AV77Reloj_interface_reloj_codigoidwwds_6_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV78Reloj_interface_reloj_codigoidwwds_7_dynamicfiltersselector2, "RELOJ_NOMBRE") == 0 ) && ( AV79Reloj_interface_reloj_codigoidwwds_8_dynamicfiltersoperator2 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV81Reloj_interface_reloj_codigoidwwds_10_reloj_nombre2)) ) )
         {
            AddWhere(sWhereString, "(T3.[Reloj_Nom] like @lV81Reloj_interface_reloj_codigoidwwds_10_reloj_nombre2)");
         }
         else
         {
            GXv_int8[8] = 1;
         }
         if ( AV77Reloj_interface_reloj_codigoidwwds_6_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV78Reloj_interface_reloj_codigoidwwds_7_dynamicfiltersselector2, "RELOJ_NOMBRE") == 0 ) && ( AV79Reloj_interface_reloj_codigoidwwds_8_dynamicfiltersoperator2 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV81Reloj_interface_reloj_codigoidwwds_10_reloj_nombre2)) ) )
         {
            AddWhere(sWhereString, "(T3.[Reloj_Nom] like '%' + @lV81Reloj_interface_reloj_codigoidwwds_10_reloj_nombre2)");
         }
         else
         {
            GXv_int8[9] = 1;
         }
         if ( AV77Reloj_interface_reloj_codigoidwwds_6_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV78Reloj_interface_reloj_codigoidwwds_7_dynamicfiltersselector2, "HORARIODESCRIPCION") == 0 ) && ( AV79Reloj_interface_reloj_codigoidwwds_8_dynamicfiltersoperator2 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV82Reloj_interface_reloj_codigoidwwds_11_horariodescripcion2)) ) )
         {
            AddWhere(sWhereString, "(T4.[Horario_Dsc] like @lV82Reloj_interface_reloj_codigoidwwds_11_horariodescripcion2)");
         }
         else
         {
            GXv_int8[10] = 1;
         }
         if ( AV77Reloj_interface_reloj_codigoidwwds_6_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV78Reloj_interface_reloj_codigoidwwds_7_dynamicfiltersselector2, "HORARIODESCRIPCION") == 0 ) && ( AV79Reloj_interface_reloj_codigoidwwds_8_dynamicfiltersoperator2 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV82Reloj_interface_reloj_codigoidwwds_11_horariodescripcion2)) ) )
         {
            AddWhere(sWhereString, "(T4.[Horario_Dsc] like '%' + @lV82Reloj_interface_reloj_codigoidwwds_11_horariodescripcion2)");
         }
         else
         {
            GXv_int8[11] = 1;
         }
         if ( AV83Reloj_interface_reloj_codigoidwwds_12_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV84Reloj_interface_reloj_codigoidwwds_13_dynamicfiltersselector3, "RHTRABAJADORNOMBRES") == 0 ) && ( AV85Reloj_interface_reloj_codigoidwwds_14_dynamicfiltersoperator3 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV86Reloj_interface_reloj_codigoidwwds_15_rhtrabajadornombres3)) ) )
         {
            AddWhere(sWhereString, "(RTRIM(LTRIM(T2.[TrabApePat])) + ' ' + RTRIM(LTRIM(T2.[TrabApeMat])) + ' ' + RTRIM(LTRIM(T2.[TrabNombres])) like @lV86Reloj_interface_reloj_codigoidwwds_15_rhtrabajadornombres3)");
         }
         else
         {
            GXv_int8[12] = 1;
         }
         if ( AV83Reloj_interface_reloj_codigoidwwds_12_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV84Reloj_interface_reloj_codigoidwwds_13_dynamicfiltersselector3, "RHTRABAJADORNOMBRES") == 0 ) && ( AV85Reloj_interface_reloj_codigoidwwds_14_dynamicfiltersoperator3 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV86Reloj_interface_reloj_codigoidwwds_15_rhtrabajadornombres3)) ) )
         {
            AddWhere(sWhereString, "(RTRIM(LTRIM(T2.[TrabApePat])) + ' ' + RTRIM(LTRIM(T2.[TrabApeMat])) + ' ' + RTRIM(LTRIM(T2.[TrabNombres])) like '%' + @lV86Reloj_interface_reloj_codigoidwwds_15_rhtrabajadornombres3)");
         }
         else
         {
            GXv_int8[13] = 1;
         }
         if ( AV83Reloj_interface_reloj_codigoidwwds_12_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV84Reloj_interface_reloj_codigoidwwds_13_dynamicfiltersselector3, "RELOJ_NOMBRE") == 0 ) && ( AV85Reloj_interface_reloj_codigoidwwds_14_dynamicfiltersoperator3 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV87Reloj_interface_reloj_codigoidwwds_16_reloj_nombre3)) ) )
         {
            AddWhere(sWhereString, "(T3.[Reloj_Nom] like @lV87Reloj_interface_reloj_codigoidwwds_16_reloj_nombre3)");
         }
         else
         {
            GXv_int8[14] = 1;
         }
         if ( AV83Reloj_interface_reloj_codigoidwwds_12_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV84Reloj_interface_reloj_codigoidwwds_13_dynamicfiltersselector3, "RELOJ_NOMBRE") == 0 ) && ( AV85Reloj_interface_reloj_codigoidwwds_14_dynamicfiltersoperator3 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV87Reloj_interface_reloj_codigoidwwds_16_reloj_nombre3)) ) )
         {
            AddWhere(sWhereString, "(T3.[Reloj_Nom] like '%' + @lV87Reloj_interface_reloj_codigoidwwds_16_reloj_nombre3)");
         }
         else
         {
            GXv_int8[15] = 1;
         }
         if ( AV83Reloj_interface_reloj_codigoidwwds_12_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV84Reloj_interface_reloj_codigoidwwds_13_dynamicfiltersselector3, "HORARIODESCRIPCION") == 0 ) && ( AV85Reloj_interface_reloj_codigoidwwds_14_dynamicfiltersoperator3 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV88Reloj_interface_reloj_codigoidwwds_17_horariodescripcion3)) ) )
         {
            AddWhere(sWhereString, "(T4.[Horario_Dsc] like @lV88Reloj_interface_reloj_codigoidwwds_17_horariodescripcion3)");
         }
         else
         {
            GXv_int8[16] = 1;
         }
         if ( AV83Reloj_interface_reloj_codigoidwwds_12_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV84Reloj_interface_reloj_codigoidwwds_13_dynamicfiltersselector3, "HORARIODESCRIPCION") == 0 ) && ( AV85Reloj_interface_reloj_codigoidwwds_14_dynamicfiltersoperator3 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV88Reloj_interface_reloj_codigoidwwds_17_horariodescripcion3)) ) )
         {
            AddWhere(sWhereString, "(T4.[Horario_Dsc] like '%' + @lV88Reloj_interface_reloj_codigoidwwds_17_horariodescripcion3)");
         }
         else
         {
            GXv_int8[17] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV90Reloj_interface_reloj_codigoidwwds_19_tfcodigoid_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV89Reloj_interface_reloj_codigoidwwds_18_tfcodigoid)) ) )
         {
            AddWhere(sWhereString, "(T1.[CodigoId] like @lV89Reloj_interface_reloj_codigoidwwds_18_tfcodigoid)");
         }
         else
         {
            GXv_int8[18] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV90Reloj_interface_reloj_codigoidwwds_19_tfcodigoid_sel)) )
         {
            AddWhere(sWhereString, "(T1.[CodigoId] = @AV90Reloj_interface_reloj_codigoidwwds_19_tfcodigoid_sel)");
         }
         else
         {
            GXv_int8[19] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV92Reloj_interface_reloj_codigoidwwds_21_tfreloj_nombre_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV91Reloj_interface_reloj_codigoidwwds_20_tfreloj_nombre)) ) )
         {
            AddWhere(sWhereString, "(T3.[Reloj_Nom] like @lV91Reloj_interface_reloj_codigoidwwds_20_tfreloj_nombre)");
         }
         else
         {
            GXv_int8[20] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV92Reloj_interface_reloj_codigoidwwds_21_tfreloj_nombre_sel)) )
         {
            AddWhere(sWhereString, "(T3.[Reloj_Nom] = @AV92Reloj_interface_reloj_codigoidwwds_21_tfreloj_nombre_sel)");
         }
         else
         {
            GXv_int8[21] = 1;
         }
         if ( ! (DateTime.MinValue==AV93Reloj_interface_reloj_codigoidwwds_22_tflectura_ini) )
         {
            AddWhere(sWhereString, "(T1.[Lectura_Ini] >= @AV93Reloj_interface_reloj_codigoidwwds_22_tflectura_ini)");
         }
         else
         {
            GXv_int8[22] = 1;
         }
         if ( ! (DateTime.MinValue==AV94Reloj_interface_reloj_codigoidwwds_23_tflectura_ini_to) )
         {
            AddWhere(sWhereString, "(T1.[Lectura_Ini] <= @AV94Reloj_interface_reloj_codigoidwwds_23_tflectura_ini_to)");
         }
         else
         {
            GXv_int8[23] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV96Reloj_interface_reloj_codigoidwwds_25_tfrhtrabajadornombres_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV95Reloj_interface_reloj_codigoidwwds_24_tfrhtrabajadornombres)) ) )
         {
            AddWhere(sWhereString, "(RTRIM(LTRIM(T2.[TrabApePat])) + ' ' + RTRIM(LTRIM(T2.[TrabApeMat])) + ' ' + RTRIM(LTRIM(T2.[TrabNombres])) like @lV95Reloj_interface_reloj_codigoidwwds_24_tfrhtrabajadornombres)");
         }
         else
         {
            GXv_int8[24] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV96Reloj_interface_reloj_codigoidwwds_25_tfrhtrabajadornombres_sel)) )
         {
            AddWhere(sWhereString, "(RTRIM(LTRIM(T2.[TrabApePat])) + ' ' + RTRIM(LTRIM(T2.[TrabApeMat])) + ' ' + RTRIM(LTRIM(T2.[TrabNombres])) = @AV96Reloj_interface_reloj_codigoidwwds_25_tfrhtrabajadornombres_sel)");
         }
         else
         {
            GXv_int8[25] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV98Reloj_interface_reloj_codigoidwwds_27_tfhorariodescripcion_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV97Reloj_interface_reloj_codigoidwwds_26_tfhorariodescripcion)) ) )
         {
            AddWhere(sWhereString, "(T4.[Horario_Dsc] like @lV97Reloj_interface_reloj_codigoidwwds_26_tfhorariodescripcion)");
         }
         else
         {
            GXv_int8[26] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV98Reloj_interface_reloj_codigoidwwds_27_tfhorariodescripcion_sel)) )
         {
            AddWhere(sWhereString, "(T4.[Horario_Dsc] = @AV98Reloj_interface_reloj_codigoidwwds_27_tfhorariodescripcion_sel)");
         }
         else
         {
            GXv_int8[27] = 1;
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
                     return conditional_H007M2(context, (string)dynConstraints[0] , (short)dynConstraints[1] , (string)dynConstraints[2] , (string)dynConstraints[3] , (string)dynConstraints[4] , (bool)dynConstraints[5] , (string)dynConstraints[6] , (short)dynConstraints[7] , (string)dynConstraints[8] , (string)dynConstraints[9] , (string)dynConstraints[10] , (bool)dynConstraints[11] , (string)dynConstraints[12] , (short)dynConstraints[13] , (string)dynConstraints[14] , (string)dynConstraints[15] , (string)dynConstraints[16] , (string)dynConstraints[17] , (string)dynConstraints[18] , (string)dynConstraints[19] , (string)dynConstraints[20] , (DateTime)dynConstraints[21] , (DateTime)dynConstraints[22] , (string)dynConstraints[23] , (string)dynConstraints[24] , (string)dynConstraints[25] , (string)dynConstraints[26] , (string)dynConstraints[27] , (string)dynConstraints[28] , (string)dynConstraints[29] , (string)dynConstraints[30] , (string)dynConstraints[31] , (string)dynConstraints[32] , (DateTime)dynConstraints[33] , (short)dynConstraints[34] , (bool)dynConstraints[35] );
               case 1 :
                     return conditional_H007M3(context, (string)dynConstraints[0] , (short)dynConstraints[1] , (string)dynConstraints[2] , (string)dynConstraints[3] , (string)dynConstraints[4] , (bool)dynConstraints[5] , (string)dynConstraints[6] , (short)dynConstraints[7] , (string)dynConstraints[8] , (string)dynConstraints[9] , (string)dynConstraints[10] , (bool)dynConstraints[11] , (string)dynConstraints[12] , (short)dynConstraints[13] , (string)dynConstraints[14] , (string)dynConstraints[15] , (string)dynConstraints[16] , (string)dynConstraints[17] , (string)dynConstraints[18] , (string)dynConstraints[19] , (string)dynConstraints[20] , (DateTime)dynConstraints[21] , (DateTime)dynConstraints[22] , (string)dynConstraints[23] , (string)dynConstraints[24] , (string)dynConstraints[25] , (string)dynConstraints[26] , (string)dynConstraints[27] , (string)dynConstraints[28] , (string)dynConstraints[29] , (string)dynConstraints[30] , (string)dynConstraints[31] , (string)dynConstraints[32] , (DateTime)dynConstraints[33] , (short)dynConstraints[34] , (bool)dynConstraints[35] );
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
          Object[] prmH007M2;
          prmH007M2 = new Object[] {
          new ParDef("@lV74Reloj_interface_reloj_codigoidwwds_3_rhtrabajadornombres1",GXType.VarChar,300,0) ,
          new ParDef("@lV74Reloj_interface_reloj_codigoidwwds_3_rhtrabajadornombres1",GXType.VarChar,300,0) ,
          new ParDef("@lV75Reloj_interface_reloj_codigoidwwds_4_reloj_nombre1",GXType.NVarChar,50,0) ,
          new ParDef("@lV75Reloj_interface_reloj_codigoidwwds_4_reloj_nombre1",GXType.NVarChar,50,0) ,
          new ParDef("@lV76Reloj_interface_reloj_codigoidwwds_5_horariodescripcion1",GXType.NVarChar,100,5) ,
          new ParDef("@lV76Reloj_interface_reloj_codigoidwwds_5_horariodescripcion1",GXType.NVarChar,100,5) ,
          new ParDef("@lV80Reloj_interface_reloj_codigoidwwds_9_rhtrabajadornombres2",GXType.VarChar,300,0) ,
          new ParDef("@lV80Reloj_interface_reloj_codigoidwwds_9_rhtrabajadornombres2",GXType.VarChar,300,0) ,
          new ParDef("@lV81Reloj_interface_reloj_codigoidwwds_10_reloj_nombre2",GXType.NVarChar,50,0) ,
          new ParDef("@lV81Reloj_interface_reloj_codigoidwwds_10_reloj_nombre2",GXType.NVarChar,50,0) ,
          new ParDef("@lV82Reloj_interface_reloj_codigoidwwds_11_horariodescripcion2",GXType.NVarChar,100,5) ,
          new ParDef("@lV82Reloj_interface_reloj_codigoidwwds_11_horariodescripcion2",GXType.NVarChar,100,5) ,
          new ParDef("@lV86Reloj_interface_reloj_codigoidwwds_15_rhtrabajadornombres3",GXType.VarChar,300,0) ,
          new ParDef("@lV86Reloj_interface_reloj_codigoidwwds_15_rhtrabajadornombres3",GXType.VarChar,300,0) ,
          new ParDef("@lV87Reloj_interface_reloj_codigoidwwds_16_reloj_nombre3",GXType.NVarChar,50,0) ,
          new ParDef("@lV87Reloj_interface_reloj_codigoidwwds_16_reloj_nombre3",GXType.NVarChar,50,0) ,
          new ParDef("@lV88Reloj_interface_reloj_codigoidwwds_17_horariodescripcion3",GXType.NVarChar,100,5) ,
          new ParDef("@lV88Reloj_interface_reloj_codigoidwwds_17_horariodescripcion3",GXType.NVarChar,100,5) ,
          new ParDef("@lV89Reloj_interface_reloj_codigoidwwds_18_tfcodigoid",GXType.NVarChar,25,0) ,
          new ParDef("@AV90Reloj_interface_reloj_codigoidwwds_19_tfcodigoid_sel",GXType.NVarChar,25,0) ,
          new ParDef("@lV91Reloj_interface_reloj_codigoidwwds_20_tfreloj_nombre",GXType.NVarChar,50,0) ,
          new ParDef("@AV92Reloj_interface_reloj_codigoidwwds_21_tfreloj_nombre_sel",GXType.NVarChar,50,0) ,
          new ParDef("@AV93Reloj_interface_reloj_codigoidwwds_22_tflectura_ini",GXType.DateTime,10,8) ,
          new ParDef("@AV94Reloj_interface_reloj_codigoidwwds_23_tflectura_ini_to",GXType.DateTime,10,8) ,
          new ParDef("@lV95Reloj_interface_reloj_codigoidwwds_24_tfrhtrabajadornombres",GXType.VarChar,300,0) ,
          new ParDef("@AV96Reloj_interface_reloj_codigoidwwds_25_tfrhtrabajadornombres_sel",GXType.VarChar,300,0) ,
          new ParDef("@lV97Reloj_interface_reloj_codigoidwwds_26_tfhorariodescripcion",GXType.NVarChar,100,5) ,
          new ParDef("@AV98Reloj_interface_reloj_codigoidwwds_27_tfhorariodescripcion_sel",GXType.NVarChar,100,5) ,
          new ParDef("@GXPagingFrom2",GXType.Int32,9,0) ,
          new ParDef("@GXPagingTo2",GXType.Int32,9,0) ,
          new ParDef("@GXPagingTo2",GXType.Int32,9,0)
          };
          Object[] prmH007M3;
          prmH007M3 = new Object[] {
          new ParDef("@lV74Reloj_interface_reloj_codigoidwwds_3_rhtrabajadornombres1",GXType.VarChar,300,0) ,
          new ParDef("@lV74Reloj_interface_reloj_codigoidwwds_3_rhtrabajadornombres1",GXType.VarChar,300,0) ,
          new ParDef("@lV75Reloj_interface_reloj_codigoidwwds_4_reloj_nombre1",GXType.NVarChar,50,0) ,
          new ParDef("@lV75Reloj_interface_reloj_codigoidwwds_4_reloj_nombre1",GXType.NVarChar,50,0) ,
          new ParDef("@lV76Reloj_interface_reloj_codigoidwwds_5_horariodescripcion1",GXType.NVarChar,100,5) ,
          new ParDef("@lV76Reloj_interface_reloj_codigoidwwds_5_horariodescripcion1",GXType.NVarChar,100,5) ,
          new ParDef("@lV80Reloj_interface_reloj_codigoidwwds_9_rhtrabajadornombres2",GXType.VarChar,300,0) ,
          new ParDef("@lV80Reloj_interface_reloj_codigoidwwds_9_rhtrabajadornombres2",GXType.VarChar,300,0) ,
          new ParDef("@lV81Reloj_interface_reloj_codigoidwwds_10_reloj_nombre2",GXType.NVarChar,50,0) ,
          new ParDef("@lV81Reloj_interface_reloj_codigoidwwds_10_reloj_nombre2",GXType.NVarChar,50,0) ,
          new ParDef("@lV82Reloj_interface_reloj_codigoidwwds_11_horariodescripcion2",GXType.NVarChar,100,5) ,
          new ParDef("@lV82Reloj_interface_reloj_codigoidwwds_11_horariodescripcion2",GXType.NVarChar,100,5) ,
          new ParDef("@lV86Reloj_interface_reloj_codigoidwwds_15_rhtrabajadornombres3",GXType.VarChar,300,0) ,
          new ParDef("@lV86Reloj_interface_reloj_codigoidwwds_15_rhtrabajadornombres3",GXType.VarChar,300,0) ,
          new ParDef("@lV87Reloj_interface_reloj_codigoidwwds_16_reloj_nombre3",GXType.NVarChar,50,0) ,
          new ParDef("@lV87Reloj_interface_reloj_codigoidwwds_16_reloj_nombre3",GXType.NVarChar,50,0) ,
          new ParDef("@lV88Reloj_interface_reloj_codigoidwwds_17_horariodescripcion3",GXType.NVarChar,100,5) ,
          new ParDef("@lV88Reloj_interface_reloj_codigoidwwds_17_horariodescripcion3",GXType.NVarChar,100,5) ,
          new ParDef("@lV89Reloj_interface_reloj_codigoidwwds_18_tfcodigoid",GXType.NVarChar,25,0) ,
          new ParDef("@AV90Reloj_interface_reloj_codigoidwwds_19_tfcodigoid_sel",GXType.NVarChar,25,0) ,
          new ParDef("@lV91Reloj_interface_reloj_codigoidwwds_20_tfreloj_nombre",GXType.NVarChar,50,0) ,
          new ParDef("@AV92Reloj_interface_reloj_codigoidwwds_21_tfreloj_nombre_sel",GXType.NVarChar,50,0) ,
          new ParDef("@AV93Reloj_interface_reloj_codigoidwwds_22_tflectura_ini",GXType.DateTime,10,8) ,
          new ParDef("@AV94Reloj_interface_reloj_codigoidwwds_23_tflectura_ini_to",GXType.DateTime,10,8) ,
          new ParDef("@lV95Reloj_interface_reloj_codigoidwwds_24_tfrhtrabajadornombres",GXType.VarChar,300,0) ,
          new ParDef("@AV96Reloj_interface_reloj_codigoidwwds_25_tfrhtrabajadornombres_sel",GXType.VarChar,300,0) ,
          new ParDef("@lV97Reloj_interface_reloj_codigoidwwds_26_tfhorariodescripcion",GXType.NVarChar,100,5) ,
          new ParDef("@AV98Reloj_interface_reloj_codigoidwwds_27_tfhorariodescripcion_sel",GXType.NVarChar,100,5)
          };
          def= new CursorDef[] {
              new CursorDef("H007M2", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH007M2,11, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("H007M3", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH007M3,1, GxCacheFrequency.OFF ,true,false )
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
                ((short[]) buf[2])[0] = rslt.getShort(3);
                ((string[]) buf[3])[0] = rslt.getVarchar(4);
                ((string[]) buf[4])[0] = rslt.getVarchar(5);
                ((DateTime[]) buf[5])[0] = rslt.getGXDateTime(6);
                ((string[]) buf[6])[0] = rslt.getVarchar(7);
                ((string[]) buf[7])[0] = rslt.getVarchar(8);
                ((string[]) buf[8])[0] = rslt.getVarchar(9);
                ((bool[]) buf[9])[0] = rslt.wasNull(9);
                ((string[]) buf[10])[0] = rslt.getVarchar(10);
                ((bool[]) buf[11])[0] = rslt.wasNull(10);
                ((string[]) buf[12])[0] = rslt.getVarchar(11);
                ((bool[]) buf[13])[0] = rslt.wasNull(11);
                return;
             case 1 :
                ((long[]) buf[0])[0] = rslt.getLong(1);
                return;
       }
    }

 }

}
