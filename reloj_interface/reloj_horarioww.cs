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
   public class reloj_horarioww : GXDataArea
   {
      public reloj_horarioww( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDataStore2 = context.GetDataStore("DataStore2");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusTheme");
      }

      public reloj_horarioww( IGxContext context )
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
               nRC_GXsfl_33 = (int)(NumberUtil.Val( GetPar( "nRC_GXsfl_33"), "."));
               nGXsfl_33_idx = (int)(NumberUtil.Val( GetPar( "nGXsfl_33_idx"), "."));
               sGXsfl_33_idx = GetPar( "sGXsfl_33_idx");
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
               AV64Pgmname = GetPar( "Pgmname");
               AV31TFHorario_ID = (short)(NumberUtil.Val( GetPar( "TFHorario_ID"), "."));
               AV32TFHorario_ID_To = (short)(NumberUtil.Val( GetPar( "TFHorario_ID_To"), "."));
               AV33TFHorario_Dsc = GetPar( "TFHorario_Dsc");
               AV34TFHorario_Dsc_Sel = GetPar( "TFHorario_Dsc_Sel");
               AV35TFHorario_Dia_Ini_01 = DateTimeUtil.ResetDate(context.localUtil.ParseDTimeParm( GetPar( "TFHorario_Dia_Ini_01")));
               AV36TFHorario_Dia_Ini_01_To = DateTimeUtil.ResetDate(context.localUtil.ParseDTimeParm( GetPar( "TFHorario_Dia_Ini_01_To")));
               AV40TFHorario_Dia_Fin_01 = DateTimeUtil.ResetDate(context.localUtil.ParseDTimeParm( GetPar( "TFHorario_Dia_Fin_01")));
               AV41TFHorario_Dia_Fin_01_To = DateTimeUtil.ResetDate(context.localUtil.ParseDTimeParm( GetPar( "TFHorario_Dia_Fin_01_To")));
               AV45TFHorario_Vigencia = context.localUtil.ParseDTimeParm( GetPar( "TFHorario_Vigencia"));
               AV46TFHorario_Vigencia_To = context.localUtil.ParseDTimeParm( GetPar( "TFHorario_Vigencia_To"));
               AV13OrderedBy = (short)(NumberUtil.Val( GetPar( "OrderedBy"), "."));
               AV14OrderedDsc = StringUtil.StrToBool( GetPar( "OrderedDsc"));
               setAjaxCallMode();
               if ( ! IsValidAjaxCall( true) )
               {
                  GxWebError = 1;
                  return  ;
               }
               gxgrGrid_refresh( subGrid_Rows, AV64Pgmname, AV31TFHorario_ID, AV32TFHorario_ID_To, AV33TFHorario_Dsc, AV34TFHorario_Dsc_Sel, AV35TFHorario_Dia_Ini_01, AV36TFHorario_Dia_Ini_01_To, AV40TFHorario_Dia_Fin_01, AV41TFHorario_Dia_Fin_01_To, AV45TFHorario_Vigencia, AV46TFHorario_Vigencia_To, AV13OrderedBy, AV14OrderedDsc) ;
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
         PA7D2( ) ;
         gxajaxcallmode = (short)((isAjaxCallMode( ) ? 1 : 0));
         if ( ( gxajaxcallmode == 0 ) && ( GxWebError == 0 ) )
         {
            START7D2( ) ;
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
         context.AddJavascriptSource("gxcfg.js", "?202281810322344", false, true);
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
         context.WriteHtmlTextNl( "<form id=\"MAINFORM\" autocomplete=\"off\" name=\"MAINFORM\" method=\"post\" tabindex=-1  class=\"form-horizontal Form\" data-gx-class=\"form-horizontal Form\" novalidate action=\""+formatLink("reloj_interface.reloj_horarioww.aspx") +"\">") ;
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
         GXKey = Crypto.GetSiteKey( );
      }

      protected void SendCloseFormHiddens( )
      {
         /* Send hidden variables. */
         /* Send saved values. */
         send_integrity_footer_hashes( ) ;
         GxWebStd.gx_hidden_field( context, "nRC_GXsfl_33", StringUtil.LTrim( StringUtil.NToC( (decimal)(nRC_GXsfl_33), 8, 0, ".", "")));
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
         GxWebStd.gx_hidden_field( context, "vDDO_HORARIO_DIA_INI_01AUXDATETO", context.localUtil.DToC( AV38DDO_Horario_Dia_Ini_01AuxDateTo, 0, "/"));
         GxWebStd.gx_hidden_field( context, "vDDO_HORARIO_DIA_FIN_01AUXDATETO", context.localUtil.DToC( AV43DDO_Horario_Dia_Fin_01AuxDateTo, 0, "/"));
         GxWebStd.gx_hidden_field( context, "vDDO_HORARIO_VIGENCIAAUXDATETO", context.localUtil.DToC( AV48DDO_Horario_VigenciaAuxDateTo, 0, "/"));
         GxWebStd.gx_hidden_field( context, "vPGMNAME", StringUtil.RTrim( AV64Pgmname));
         GxWebStd.gx_hidden_field( context, "gxhash_vPGMNAME", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( AV64Pgmname, "")), context));
         GxWebStd.gx_hidden_field( context, "vTFHORARIO_ID", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV31TFHorario_ID), 4, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "vTFHORARIO_ID_TO", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV32TFHorario_ID_To), 4, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "vTFHORARIO_DSC", AV33TFHorario_Dsc);
         GxWebStd.gx_hidden_field( context, "vTFHORARIO_DSC_SEL", AV34TFHorario_Dsc_Sel);
         GxWebStd.gx_hidden_field( context, "vTFHORARIO_DIA_INI_01", context.localUtil.TToC( AV35TFHorario_Dia_Ini_01, 10, 8, 0, 0, "/", ":", " "));
         GxWebStd.gx_hidden_field( context, "vTFHORARIO_DIA_INI_01_TO", context.localUtil.TToC( AV36TFHorario_Dia_Ini_01_To, 10, 8, 0, 0, "/", ":", " "));
         GxWebStd.gx_hidden_field( context, "vTFHORARIO_DIA_FIN_01", context.localUtil.TToC( AV40TFHorario_Dia_Fin_01, 10, 8, 0, 0, "/", ":", " "));
         GxWebStd.gx_hidden_field( context, "vTFHORARIO_DIA_FIN_01_TO", context.localUtil.TToC( AV41TFHorario_Dia_Fin_01_To, 10, 8, 0, 0, "/", ":", " "));
         GxWebStd.gx_hidden_field( context, "vTFHORARIO_VIGENCIA", context.localUtil.TToC( AV45TFHorario_Vigencia, 10, 8, 0, 0, "/", ":", " "));
         GxWebStd.gx_hidden_field( context, "vTFHORARIO_VIGENCIA_TO", context.localUtil.TToC( AV46TFHorario_Vigencia_To, 10, 8, 0, 0, "/", ":", " "));
         GxWebStd.gx_hidden_field( context, "vORDEREDBY", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV13OrderedBy), 4, 0, ".", "")));
         GxWebStd.gx_boolean_hidden_field( context, "vORDEREDDSC", AV14OrderedDsc);
         GxWebStd.gx_hidden_field( context, "GRID_nFirstRecordOnPage", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRID_nFirstRecordOnPage), 15, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "GRID_nEOF", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRID_nEOF), 1, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "vDDO_HORARIO_DIA_INI_01AUXDATE", context.localUtil.DToC( AV37DDO_Horario_Dia_Ini_01AuxDate, 0, "/"));
         GxWebStd.gx_hidden_field( context, "vDDO_HORARIO_DIA_FIN_01AUXDATE", context.localUtil.DToC( AV42DDO_Horario_Dia_Fin_01AuxDate, 0, "/"));
         GxWebStd.gx_hidden_field( context, "vDDO_HORARIO_VIGENCIAAUXDATE", context.localUtil.DToC( AV47DDO_Horario_VigenciaAuxDate, 0, "/"));
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
            WE7D2( ) ;
            context.WriteHtmlText( "</div>") ;
         }
      }

      public override void DispatchEvents( )
      {
         EVT7D2( ) ;
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
         return formatLink("reloj_interface.reloj_horarioww.aspx")  ;
      }

      public override string GetPgmname( )
      {
         return "Reloj_Interface.Reloj_HorarioWW" ;
      }

      public override string GetPgmdesc( )
      {
         return "Horario del Personal" ;
      }

      protected void WB7D0( )
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
            GxWebStd.gx_button_ctrl( context, bttBtninsert_Internalname, "gx.evt.setGridEvt("+StringUtil.Str( (decimal)(33), 2, 0)+","+"null"+");", "Agregar", bttBtninsert_Jsonclick, 5, "Agregar", "", StyleString, ClassString, 1, 1, "standard", "'"+""+"'"+",false,"+"'"+"E\\'DOINSERT\\'."+"'", TempTags, "", context.GetButtonType( ), "HLP_Reloj_Interface\\Reloj_HorarioWW.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "left", "top", "", "", "div");
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 21,'',false,'',0)\"";
            ClassString = "ColumnsSelector";
            StyleString = "";
            GxWebStd.gx_button_ctrl( context, bttBtnagexport_Internalname, "gx.evt.setGridEvt("+StringUtil.Str( (decimal)(33), 2, 0)+","+"null"+");", "Reportes", bttBtnagexport_Jsonclick, 0, "Reportes", "", StyleString, ClassString, 1, 0, "standard", "'"+""+"'"+",false,"+"'"+""+"'", TempTags, "", context.GetButtonType( ), "HLP_Reloj_Interface\\Reloj_HorarioWW.htm");
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
               context.WriteHtmlText( "<div id=\""+"GridContainer"+"DivS\" data-gxgridid=\"33\">") ;
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
               context.SendWebValue( "Horario_Dsc") ;
               context.WriteHtmlTextNl( "</th>") ;
               context.WriteHtmlText( "<th align=\""+"center"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+""+""+"\" "+">") ;
               context.SendWebValue( "Horario Ingreso") ;
               context.WriteHtmlTextNl( "</th>") ;
               context.WriteHtmlText( "<th align=\""+"center"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+""+""+"\" "+">") ;
               context.SendWebValue( "Horario Salida") ;
               context.WriteHtmlTextNl( "</th>") ;
               context.WriteHtmlText( "<th align=\""+"right"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+""+""+"\" "+">") ;
               context.SendWebValue( "Fecha Registro") ;
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
               GridColumn.AddObjectProperty("Value", StringUtil.LTrim( StringUtil.NToC( (decimal)(A2432Horario_ID), 4, 0, ".", "")));
               GridContainer.AddColumnProperties(GridColumn);
               GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
               GridColumn.AddObjectProperty("Value", A2433Horario_Dsc);
               GridColumn.AddObjectProperty("Link", StringUtil.RTrim( edtHorario_Dsc_Link));
               GridContainer.AddColumnProperties(GridColumn);
               GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
               GridColumn.AddObjectProperty("Value", context.localUtil.TToC( A2434Horario_Dia_Ini_01, 10, 8, 0, 3, "/", ":", " "));
               GridContainer.AddColumnProperties(GridColumn);
               GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
               GridColumn.AddObjectProperty("Value", context.localUtil.TToC( A2441Horario_Dia_Fin_01, 10, 8, 0, 3, "/", ":", " "));
               GridContainer.AddColumnProperties(GridColumn);
               GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
               GridColumn.AddObjectProperty("Value", context.localUtil.TToC( A2462Horario_Vigencia, 10, 8, 0, 3, "/", ":", " "));
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
         if ( wbEnd == 33 )
         {
            wbEnd = 0;
            nRC_GXsfl_33 = (int)(nGXsfl_33_idx-1);
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
            /* Div Control */
            GxWebStd.gx_div_start( context, divDdo_horario_dia_ini_01auxdates_Internalname, 1, 0, "px", 0, "px", "Invisible", "left", "top", "", "", "div");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 51,'',false,'" + sGXsfl_33_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavDdo_horario_dia_ini_01auxdatetext_Internalname, AV39DDO_Horario_Dia_Ini_01AuxDateText, StringUtil.RTrim( context.localUtil.Format( AV39DDO_Horario_Dia_Ini_01AuxDateText, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,51);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavDdo_horario_dia_ini_01auxdatetext_Jsonclick, 0, "Attribute", "", "", "", "", 1, 1, 0, "text", "", 40, "chr", 1, "row", 40, 0, 0, 0, 1, -1, -1, true, "", "left", true, "", "HLP_Reloj_Interface\\Reloj_HorarioWW.htm");
            /* User Defined Control */
            ucTfhorario_dia_ini_01_rangepicker.SetProperty("Start Date", AV37DDO_Horario_Dia_Ini_01AuxDate);
            ucTfhorario_dia_ini_01_rangepicker.SetProperty("End Date", AV38DDO_Horario_Dia_Ini_01AuxDateTo);
            ucTfhorario_dia_ini_01_rangepicker.Render(context, "wwp.daterangepicker", Tfhorario_dia_ini_01_rangepicker_Internalname, "TFHORARIO_DIA_INI_01_RANGEPICKERContainer");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divDdo_horario_dia_fin_01auxdates_Internalname, 1, 0, "px", 0, "px", "Invisible", "left", "top", "", "", "div");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 54,'',false,'" + sGXsfl_33_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavDdo_horario_dia_fin_01auxdatetext_Internalname, AV44DDO_Horario_Dia_Fin_01AuxDateText, StringUtil.RTrim( context.localUtil.Format( AV44DDO_Horario_Dia_Fin_01AuxDateText, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,54);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavDdo_horario_dia_fin_01auxdatetext_Jsonclick, 0, "Attribute", "", "", "", "", 1, 1, 0, "text", "", 40, "chr", 1, "row", 40, 0, 0, 0, 1, -1, -1, true, "", "left", true, "", "HLP_Reloj_Interface\\Reloj_HorarioWW.htm");
            /* User Defined Control */
            ucTfhorario_dia_fin_01_rangepicker.SetProperty("Start Date", AV42DDO_Horario_Dia_Fin_01AuxDate);
            ucTfhorario_dia_fin_01_rangepicker.SetProperty("End Date", AV43DDO_Horario_Dia_Fin_01AuxDateTo);
            ucTfhorario_dia_fin_01_rangepicker.Render(context, "wwp.daterangepicker", Tfhorario_dia_fin_01_rangepicker_Internalname, "TFHORARIO_DIA_FIN_01_RANGEPICKERContainer");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divDdo_horario_vigenciaauxdates_Internalname, 1, 0, "px", 0, "px", "Invisible", "left", "top", "", "", "div");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 57,'',false,'" + sGXsfl_33_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavDdo_horario_vigenciaauxdatetext_Internalname, AV49DDO_Horario_VigenciaAuxDateText, StringUtil.RTrim( context.localUtil.Format( AV49DDO_Horario_VigenciaAuxDateText, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,57);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavDdo_horario_vigenciaauxdatetext_Jsonclick, 0, "Attribute", "", "", "", "", 1, 1, 0, "text", "", 40, "chr", 1, "row", 40, 0, 0, 0, 1, -1, -1, true, "", "left", true, "", "HLP_Reloj_Interface\\Reloj_HorarioWW.htm");
            /* User Defined Control */
            ucTfhorario_vigencia_rangepicker.SetProperty("Start Date", AV47DDO_Horario_VigenciaAuxDate);
            ucTfhorario_vigencia_rangepicker.SetProperty("End Date", AV48DDO_Horario_VigenciaAuxDateTo);
            ucTfhorario_vigencia_rangepicker.Render(context, "wwp.daterangepicker", Tfhorario_vigencia_rangepicker_Internalname, "TFHORARIO_VIGENCIA_RANGEPICKERContainer");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
         }
         if ( wbEnd == 33 )
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

      protected void START7D2( )
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
            Form.Meta.addItem("description", "Horario del Personal", 0) ;
         }
         context.wjLoc = "";
         context.nUserReturn = 0;
         context.wbHandled = 0;
         if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
         {
         }
         wbErr = false;
         STRUP7D0( ) ;
      }

      protected void WS7D2( )
      {
         START7D2( ) ;
         EVT7D2( ) ;
      }

      protected void EVT7D2( )
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
                              E117D2 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "GRIDPAGINATIONBAR.CHANGEROWSPERPAGE") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              E127D2 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "DDO_AGEXPORT.ONOPTIONCLICKED") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              E137D2 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "DDO_GRID.ONOPTIONCLICKED") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              E147D2 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "'DOINSERT'") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              /* Execute user event: 'DoInsert' */
                              E157D2 ();
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
                              nGXsfl_33_idx = (int)(NumberUtil.Val( sEvtType, "."));
                              sGXsfl_33_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_33_idx), 4, 0), 4, "0");
                              SubsflControlProps_332( ) ;
                              cmbavGridactions.Name = cmbavGridactions_Internalname;
                              cmbavGridactions.CurrentValue = cgiGet( cmbavGridactions_Internalname);
                              AV57GridActions = (short)(NumberUtil.Val( cgiGet( cmbavGridactions_Internalname), "."));
                              AssignAttri("", false, cmbavGridactions_Internalname, StringUtil.LTrimStr( (decimal)(AV57GridActions), 4, 0));
                              A2432Horario_ID = (short)(context.localUtil.CToN( cgiGet( edtHorario_ID_Internalname), ".", ","));
                              A2433Horario_Dsc = cgiGet( edtHorario_Dsc_Internalname);
                              A2434Horario_Dia_Ini_01 = DateTimeUtil.ResetDate(context.localUtil.CToT( cgiGet( edtHorario_Dia_Ini_01_Internalname), 0));
                              A2441Horario_Dia_Fin_01 = DateTimeUtil.ResetDate(context.localUtil.CToT( cgiGet( edtHorario_Dia_Fin_01_Internalname), 0));
                              A2462Horario_Vigencia = context.localUtil.CToT( cgiGet( edtHorario_Vigencia_Internalname), 0);
                              sEvtType = StringUtil.Right( sEvt, 1);
                              if ( StringUtil.StrCmp(sEvtType, ".") == 0 )
                              {
                                 sEvt = StringUtil.Left( sEvt, (short)(StringUtil.Len( sEvt)-1));
                                 if ( StringUtil.StrCmp(sEvt, "START") == 0 )
                                 {
                                    context.wbHandled = 1;
                                    dynload_actions( ) ;
                                    /* Execute user event: Start */
                                    E167D2 ();
                                 }
                                 else if ( StringUtil.StrCmp(sEvt, "REFRESH") == 0 )
                                 {
                                    context.wbHandled = 1;
                                    dynload_actions( ) ;
                                    /* Execute user event: Refresh */
                                    E177D2 ();
                                 }
                                 else if ( StringUtil.StrCmp(sEvt, "GRID.LOAD") == 0 )
                                 {
                                    context.wbHandled = 1;
                                    dynload_actions( ) ;
                                    E187D2 ();
                                 }
                                 else if ( StringUtil.StrCmp(sEvt, "VGRIDACTIONS.CLICK") == 0 )
                                 {
                                    context.wbHandled = 1;
                                    dynload_actions( ) ;
                                    E197D2 ();
                                 }
                                 else if ( StringUtil.StrCmp(sEvt, "ENTER") == 0 )
                                 {
                                    context.wbHandled = 1;
                                    if ( ! wbErr )
                                    {
                                       Rfr0gs = false;
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

      protected void WE7D2( )
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

      protected void PA7D2( )
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
               GX_FocusControl = edtavDdo_horario_dia_ini_01auxdatetext_Internalname;
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
         SubsflControlProps_332( ) ;
         while ( nGXsfl_33_idx <= nRC_GXsfl_33 )
         {
            sendrow_332( ) ;
            nGXsfl_33_idx = ((subGrid_Islastpage==1)&&(nGXsfl_33_idx+1>subGrid_fnc_Recordsperpage( )) ? 1 : nGXsfl_33_idx+1);
            sGXsfl_33_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_33_idx), 4, 0), 4, "0");
            SubsflControlProps_332( ) ;
         }
         AddString( context.httpAjaxContext.getJSONContainerResponse( GridContainer)) ;
         /* End function gxnrGrid_newrow */
      }

      protected void gxgrGrid_refresh( int subGrid_Rows ,
                                       string AV64Pgmname ,
                                       short AV31TFHorario_ID ,
                                       short AV32TFHorario_ID_To ,
                                       string AV33TFHorario_Dsc ,
                                       string AV34TFHorario_Dsc_Sel ,
                                       DateTime AV35TFHorario_Dia_Ini_01 ,
                                       DateTime AV36TFHorario_Dia_Ini_01_To ,
                                       DateTime AV40TFHorario_Dia_Fin_01 ,
                                       DateTime AV41TFHorario_Dia_Fin_01_To ,
                                       DateTime AV45TFHorario_Vigencia ,
                                       DateTime AV46TFHorario_Vigencia_To ,
                                       short AV13OrderedBy ,
                                       bool AV14OrderedDsc )
      {
         initialize_formulas( ) ;
         GxWebStd.set_html_headers( context, 0, "", "");
         /* Execute user event: Refresh */
         E177D2 ();
         GRID_nCurrentRecord = 0;
         RF7D2( ) ;
         GXKey = Crypto.GetSiteKey( );
         send_integrity_footer_hashes( ) ;
         GXKey = Crypto.GetSiteKey( );
         /* End function gxgrGrid_refresh */
      }

      protected void send_integrity_hashes( )
      {
         GxWebStd.gx_hidden_field( context, "gxhash_HORARIO_ID", GetSecureSignedToken( "", context.localUtil.Format( (decimal)(A2432Horario_ID), "ZZZ9"), context));
         GxWebStd.gx_hidden_field( context, "HORARIO_ID", StringUtil.LTrim( StringUtil.NToC( (decimal)(A2432Horario_ID), 4, 0, ".", "")));
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
      }

      public void Refresh( )
      {
         send_integrity_hashes( ) ;
         RF7D2( ) ;
         if ( isFullAjaxMode( ) )
         {
            send_integrity_footer_hashes( ) ;
         }
      }

      protected void initialize_formulas( )
      {
         /* GeneXus formulas. */
         AV64Pgmname = "Reloj_Interface.Reloj_HorarioWW";
         context.Gx_err = 0;
      }

      protected void RF7D2( )
      {
         initialize_formulas( ) ;
         clear_multi_value_controls( ) ;
         if ( isAjaxCallMode( ) )
         {
            GridContainer.ClearRows();
         }
         wbStart = 33;
         /* Execute user event: Refresh */
         E177D2 ();
         nGXsfl_33_idx = 1;
         sGXsfl_33_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_33_idx), 4, 0), 4, "0");
         SubsflControlProps_332( ) ;
         bGXsfl_33_Refreshing = true;
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
            SubsflControlProps_332( ) ;
            GXPagingFrom2 = (int)(((subGrid_Rows==0) ? 0 : GRID_nFirstRecordOnPage));
            GXPagingTo2 = ((subGrid_Rows==0) ? 10000 : subGrid_fnc_Recordsperpage( )+1);
            pr_default.dynParam(0, new Object[]{ new Object[]{
                                                 AV65Reloj_interface_reloj_horariowwds_1_tfhorario_id ,
                                                 AV66Reloj_interface_reloj_horariowwds_2_tfhorario_id_to ,
                                                 AV68Reloj_interface_reloj_horariowwds_4_tfhorario_dsc_sel ,
                                                 AV67Reloj_interface_reloj_horariowwds_3_tfhorario_dsc ,
                                                 AV69Reloj_interface_reloj_horariowwds_5_tfhorario_dia_ini_01 ,
                                                 AV70Reloj_interface_reloj_horariowwds_6_tfhorario_dia_ini_01_to ,
                                                 AV71Reloj_interface_reloj_horariowwds_7_tfhorario_dia_fin_01 ,
                                                 AV72Reloj_interface_reloj_horariowwds_8_tfhorario_dia_fin_01_to ,
                                                 AV73Reloj_interface_reloj_horariowwds_9_tfhorario_vigencia ,
                                                 AV74Reloj_interface_reloj_horariowwds_10_tfhorario_vigencia_to ,
                                                 A2432Horario_ID ,
                                                 A2433Horario_Dsc ,
                                                 A2434Horario_Dia_Ini_01 ,
                                                 A2441Horario_Dia_Fin_01 ,
                                                 A2462Horario_Vigencia ,
                                                 AV13OrderedBy ,
                                                 AV14OrderedDsc } ,
                                                 new int[]{
                                                 TypeConstants.SHORT, TypeConstants.SHORT, TypeConstants.DATE, TypeConstants.DATE, TypeConstants.DATE, TypeConstants.DATE, TypeConstants.DATE, TypeConstants.DATE, TypeConstants.SHORT, TypeConstants.DATE,
                                                 TypeConstants.DATE, TypeConstants.DATE, TypeConstants.SHORT, TypeConstants.BOOLEAN
                                                 }
            });
            lV67Reloj_interface_reloj_horariowwds_3_tfhorario_dsc = StringUtil.Concat( StringUtil.RTrim( AV67Reloj_interface_reloj_horariowwds_3_tfhorario_dsc), "%", "");
            /* Using cursor H007D2 */
            pr_default.execute(0, new Object[] {AV65Reloj_interface_reloj_horariowwds_1_tfhorario_id, AV66Reloj_interface_reloj_horariowwds_2_tfhorario_id_to, lV67Reloj_interface_reloj_horariowwds_3_tfhorario_dsc, AV68Reloj_interface_reloj_horariowwds_4_tfhorario_dsc_sel, AV69Reloj_interface_reloj_horariowwds_5_tfhorario_dia_ini_01, AV70Reloj_interface_reloj_horariowwds_6_tfhorario_dia_ini_01_to, AV71Reloj_interface_reloj_horariowwds_7_tfhorario_dia_fin_01, AV72Reloj_interface_reloj_horariowwds_8_tfhorario_dia_fin_01_to, AV73Reloj_interface_reloj_horariowwds_9_tfhorario_vigencia, AV74Reloj_interface_reloj_horariowwds_10_tfhorario_vigencia_to, GXPagingFrom2, GXPagingTo2, GXPagingTo2});
            nGXsfl_33_idx = 1;
            sGXsfl_33_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_33_idx), 4, 0), 4, "0");
            SubsflControlProps_332( ) ;
            while ( ( (pr_default.getStatus(0) != 101) ) && ( ( ( subGrid_Rows == 0 ) || ( GRID_nCurrentRecord < subGrid_fnc_Recordsperpage( ) ) ) ) )
            {
               A2462Horario_Vigencia = H007D2_A2462Horario_Vigencia[0];
               A2441Horario_Dia_Fin_01 = H007D2_A2441Horario_Dia_Fin_01[0];
               A2434Horario_Dia_Ini_01 = H007D2_A2434Horario_Dia_Ini_01[0];
               A2433Horario_Dsc = H007D2_A2433Horario_Dsc[0];
               A2432Horario_ID = H007D2_A2432Horario_ID[0];
               E187D2 ();
               pr_default.readNext(0);
            }
            GRID_nEOF = (short)(((pr_default.getStatus(0) == 101) ? 1 : 0));
            GxWebStd.gx_hidden_field( context, "GRID_nEOF", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRID_nEOF), 1, 0, ".", "")));
            pr_default.close(0);
            wbEnd = 33;
            WB7D0( ) ;
         }
         bGXsfl_33_Refreshing = true;
      }

      protected void send_integrity_lvl_hashes7D2( )
      {
         GxWebStd.gx_hidden_field( context, "vPGMNAME", StringUtil.RTrim( AV64Pgmname));
         GxWebStd.gx_hidden_field( context, "gxhash_vPGMNAME", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( AV64Pgmname, "")), context));
         GxWebStd.gx_hidden_field( context, "gxhash_HORARIO_ID"+"_"+sGXsfl_33_idx, GetSecureSignedToken( sGXsfl_33_idx, context.localUtil.Format( (decimal)(A2432Horario_ID), "ZZZ9"), context));
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
         AV65Reloj_interface_reloj_horariowwds_1_tfhorario_id = AV31TFHorario_ID;
         AV66Reloj_interface_reloj_horariowwds_2_tfhorario_id_to = AV32TFHorario_ID_To;
         AV67Reloj_interface_reloj_horariowwds_3_tfhorario_dsc = AV33TFHorario_Dsc;
         AV68Reloj_interface_reloj_horariowwds_4_tfhorario_dsc_sel = AV34TFHorario_Dsc_Sel;
         AV69Reloj_interface_reloj_horariowwds_5_tfhorario_dia_ini_01 = AV35TFHorario_Dia_Ini_01;
         AV70Reloj_interface_reloj_horariowwds_6_tfhorario_dia_ini_01_to = AV36TFHorario_Dia_Ini_01_To;
         AV71Reloj_interface_reloj_horariowwds_7_tfhorario_dia_fin_01 = AV40TFHorario_Dia_Fin_01;
         AV72Reloj_interface_reloj_horariowwds_8_tfhorario_dia_fin_01_to = AV41TFHorario_Dia_Fin_01_To;
         AV73Reloj_interface_reloj_horariowwds_9_tfhorario_vigencia = AV45TFHorario_Vigencia;
         AV74Reloj_interface_reloj_horariowwds_10_tfhorario_vigencia_to = AV46TFHorario_Vigencia_To;
         pr_default.dynParam(1, new Object[]{ new Object[]{
                                              AV65Reloj_interface_reloj_horariowwds_1_tfhorario_id ,
                                              AV66Reloj_interface_reloj_horariowwds_2_tfhorario_id_to ,
                                              AV68Reloj_interface_reloj_horariowwds_4_tfhorario_dsc_sel ,
                                              AV67Reloj_interface_reloj_horariowwds_3_tfhorario_dsc ,
                                              AV69Reloj_interface_reloj_horariowwds_5_tfhorario_dia_ini_01 ,
                                              AV70Reloj_interface_reloj_horariowwds_6_tfhorario_dia_ini_01_to ,
                                              AV71Reloj_interface_reloj_horariowwds_7_tfhorario_dia_fin_01 ,
                                              AV72Reloj_interface_reloj_horariowwds_8_tfhorario_dia_fin_01_to ,
                                              AV73Reloj_interface_reloj_horariowwds_9_tfhorario_vigencia ,
                                              AV74Reloj_interface_reloj_horariowwds_10_tfhorario_vigencia_to ,
                                              A2432Horario_ID ,
                                              A2433Horario_Dsc ,
                                              A2434Horario_Dia_Ini_01 ,
                                              A2441Horario_Dia_Fin_01 ,
                                              A2462Horario_Vigencia ,
                                              AV13OrderedBy ,
                                              AV14OrderedDsc } ,
                                              new int[]{
                                              TypeConstants.SHORT, TypeConstants.SHORT, TypeConstants.DATE, TypeConstants.DATE, TypeConstants.DATE, TypeConstants.DATE, TypeConstants.DATE, TypeConstants.DATE, TypeConstants.SHORT, TypeConstants.DATE,
                                              TypeConstants.DATE, TypeConstants.DATE, TypeConstants.SHORT, TypeConstants.BOOLEAN
                                              }
         });
         lV67Reloj_interface_reloj_horariowwds_3_tfhorario_dsc = StringUtil.Concat( StringUtil.RTrim( AV67Reloj_interface_reloj_horariowwds_3_tfhorario_dsc), "%", "");
         /* Using cursor H007D3 */
         pr_default.execute(1, new Object[] {AV65Reloj_interface_reloj_horariowwds_1_tfhorario_id, AV66Reloj_interface_reloj_horariowwds_2_tfhorario_id_to, lV67Reloj_interface_reloj_horariowwds_3_tfhorario_dsc, AV68Reloj_interface_reloj_horariowwds_4_tfhorario_dsc_sel, AV69Reloj_interface_reloj_horariowwds_5_tfhorario_dia_ini_01, AV70Reloj_interface_reloj_horariowwds_6_tfhorario_dia_ini_01_to, AV71Reloj_interface_reloj_horariowwds_7_tfhorario_dia_fin_01, AV72Reloj_interface_reloj_horariowwds_8_tfhorario_dia_fin_01_to, AV73Reloj_interface_reloj_horariowwds_9_tfhorario_vigencia, AV74Reloj_interface_reloj_horariowwds_10_tfhorario_vigencia_to});
         GRID_nRecordCount = H007D3_AGRID_nRecordCount[0];
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
         AV65Reloj_interface_reloj_horariowwds_1_tfhorario_id = AV31TFHorario_ID;
         AV66Reloj_interface_reloj_horariowwds_2_tfhorario_id_to = AV32TFHorario_ID_To;
         AV67Reloj_interface_reloj_horariowwds_3_tfhorario_dsc = AV33TFHorario_Dsc;
         AV68Reloj_interface_reloj_horariowwds_4_tfhorario_dsc_sel = AV34TFHorario_Dsc_Sel;
         AV69Reloj_interface_reloj_horariowwds_5_tfhorario_dia_ini_01 = AV35TFHorario_Dia_Ini_01;
         AV70Reloj_interface_reloj_horariowwds_6_tfhorario_dia_ini_01_to = AV36TFHorario_Dia_Ini_01_To;
         AV71Reloj_interface_reloj_horariowwds_7_tfhorario_dia_fin_01 = AV40TFHorario_Dia_Fin_01;
         AV72Reloj_interface_reloj_horariowwds_8_tfhorario_dia_fin_01_to = AV41TFHorario_Dia_Fin_01_To;
         AV73Reloj_interface_reloj_horariowwds_9_tfhorario_vigencia = AV45TFHorario_Vigencia;
         AV74Reloj_interface_reloj_horariowwds_10_tfhorario_vigencia_to = AV46TFHorario_Vigencia_To;
         GRID_nFirstRecordOnPage = 0;
         GxWebStd.gx_hidden_field( context, "GRID_nFirstRecordOnPage", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRID_nFirstRecordOnPage), 15, 0, ".", "")));
         if ( isFullAjaxMode( ) )
         {
            gxgrGrid_refresh( subGrid_Rows, AV64Pgmname, AV31TFHorario_ID, AV32TFHorario_ID_To, AV33TFHorario_Dsc, AV34TFHorario_Dsc_Sel, AV35TFHorario_Dia_Ini_01, AV36TFHorario_Dia_Ini_01_To, AV40TFHorario_Dia_Fin_01, AV41TFHorario_Dia_Fin_01_To, AV45TFHorario_Vigencia, AV46TFHorario_Vigencia_To, AV13OrderedBy, AV14OrderedDsc) ;
         }
         send_integrity_footer_hashes( ) ;
         return 0 ;
      }

      protected short subgrid_nextpage( )
      {
         AV65Reloj_interface_reloj_horariowwds_1_tfhorario_id = AV31TFHorario_ID;
         AV66Reloj_interface_reloj_horariowwds_2_tfhorario_id_to = AV32TFHorario_ID_To;
         AV67Reloj_interface_reloj_horariowwds_3_tfhorario_dsc = AV33TFHorario_Dsc;
         AV68Reloj_interface_reloj_horariowwds_4_tfhorario_dsc_sel = AV34TFHorario_Dsc_Sel;
         AV69Reloj_interface_reloj_horariowwds_5_tfhorario_dia_ini_01 = AV35TFHorario_Dia_Ini_01;
         AV70Reloj_interface_reloj_horariowwds_6_tfhorario_dia_ini_01_to = AV36TFHorario_Dia_Ini_01_To;
         AV71Reloj_interface_reloj_horariowwds_7_tfhorario_dia_fin_01 = AV40TFHorario_Dia_Fin_01;
         AV72Reloj_interface_reloj_horariowwds_8_tfhorario_dia_fin_01_to = AV41TFHorario_Dia_Fin_01_To;
         AV73Reloj_interface_reloj_horariowwds_9_tfhorario_vigencia = AV45TFHorario_Vigencia;
         AV74Reloj_interface_reloj_horariowwds_10_tfhorario_vigencia_to = AV46TFHorario_Vigencia_To;
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
            gxgrGrid_refresh( subGrid_Rows, AV64Pgmname, AV31TFHorario_ID, AV32TFHorario_ID_To, AV33TFHorario_Dsc, AV34TFHorario_Dsc_Sel, AV35TFHorario_Dia_Ini_01, AV36TFHorario_Dia_Ini_01_To, AV40TFHorario_Dia_Fin_01, AV41TFHorario_Dia_Fin_01_To, AV45TFHorario_Vigencia, AV46TFHorario_Vigencia_To, AV13OrderedBy, AV14OrderedDsc) ;
         }
         send_integrity_footer_hashes( ) ;
         return (short)(((GRID_nEOF==0) ? 0 : 2)) ;
      }

      protected short subgrid_previouspage( )
      {
         AV65Reloj_interface_reloj_horariowwds_1_tfhorario_id = AV31TFHorario_ID;
         AV66Reloj_interface_reloj_horariowwds_2_tfhorario_id_to = AV32TFHorario_ID_To;
         AV67Reloj_interface_reloj_horariowwds_3_tfhorario_dsc = AV33TFHorario_Dsc;
         AV68Reloj_interface_reloj_horariowwds_4_tfhorario_dsc_sel = AV34TFHorario_Dsc_Sel;
         AV69Reloj_interface_reloj_horariowwds_5_tfhorario_dia_ini_01 = AV35TFHorario_Dia_Ini_01;
         AV70Reloj_interface_reloj_horariowwds_6_tfhorario_dia_ini_01_to = AV36TFHorario_Dia_Ini_01_To;
         AV71Reloj_interface_reloj_horariowwds_7_tfhorario_dia_fin_01 = AV40TFHorario_Dia_Fin_01;
         AV72Reloj_interface_reloj_horariowwds_8_tfhorario_dia_fin_01_to = AV41TFHorario_Dia_Fin_01_To;
         AV73Reloj_interface_reloj_horariowwds_9_tfhorario_vigencia = AV45TFHorario_Vigencia;
         AV74Reloj_interface_reloj_horariowwds_10_tfhorario_vigencia_to = AV46TFHorario_Vigencia_To;
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
            gxgrGrid_refresh( subGrid_Rows, AV64Pgmname, AV31TFHorario_ID, AV32TFHorario_ID_To, AV33TFHorario_Dsc, AV34TFHorario_Dsc_Sel, AV35TFHorario_Dia_Ini_01, AV36TFHorario_Dia_Ini_01_To, AV40TFHorario_Dia_Fin_01, AV41TFHorario_Dia_Fin_01_To, AV45TFHorario_Vigencia, AV46TFHorario_Vigencia_To, AV13OrderedBy, AV14OrderedDsc) ;
         }
         send_integrity_footer_hashes( ) ;
         return 0 ;
      }

      protected short subgrid_lastpage( )
      {
         AV65Reloj_interface_reloj_horariowwds_1_tfhorario_id = AV31TFHorario_ID;
         AV66Reloj_interface_reloj_horariowwds_2_tfhorario_id_to = AV32TFHorario_ID_To;
         AV67Reloj_interface_reloj_horariowwds_3_tfhorario_dsc = AV33TFHorario_Dsc;
         AV68Reloj_interface_reloj_horariowwds_4_tfhorario_dsc_sel = AV34TFHorario_Dsc_Sel;
         AV69Reloj_interface_reloj_horariowwds_5_tfhorario_dia_ini_01 = AV35TFHorario_Dia_Ini_01;
         AV70Reloj_interface_reloj_horariowwds_6_tfhorario_dia_ini_01_to = AV36TFHorario_Dia_Ini_01_To;
         AV71Reloj_interface_reloj_horariowwds_7_tfhorario_dia_fin_01 = AV40TFHorario_Dia_Fin_01;
         AV72Reloj_interface_reloj_horariowwds_8_tfhorario_dia_fin_01_to = AV41TFHorario_Dia_Fin_01_To;
         AV73Reloj_interface_reloj_horariowwds_9_tfhorario_vigencia = AV45TFHorario_Vigencia;
         AV74Reloj_interface_reloj_horariowwds_10_tfhorario_vigencia_to = AV46TFHorario_Vigencia_To;
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
            gxgrGrid_refresh( subGrid_Rows, AV64Pgmname, AV31TFHorario_ID, AV32TFHorario_ID_To, AV33TFHorario_Dsc, AV34TFHorario_Dsc_Sel, AV35TFHorario_Dia_Ini_01, AV36TFHorario_Dia_Ini_01_To, AV40TFHorario_Dia_Fin_01, AV41TFHorario_Dia_Fin_01_To, AV45TFHorario_Vigencia, AV46TFHorario_Vigencia_To, AV13OrderedBy, AV14OrderedDsc) ;
         }
         send_integrity_footer_hashes( ) ;
         return 0 ;
      }

      protected int subgrid_gotopage( int nPageNo )
      {
         AV65Reloj_interface_reloj_horariowwds_1_tfhorario_id = AV31TFHorario_ID;
         AV66Reloj_interface_reloj_horariowwds_2_tfhorario_id_to = AV32TFHorario_ID_To;
         AV67Reloj_interface_reloj_horariowwds_3_tfhorario_dsc = AV33TFHorario_Dsc;
         AV68Reloj_interface_reloj_horariowwds_4_tfhorario_dsc_sel = AV34TFHorario_Dsc_Sel;
         AV69Reloj_interface_reloj_horariowwds_5_tfhorario_dia_ini_01 = AV35TFHorario_Dia_Ini_01;
         AV70Reloj_interface_reloj_horariowwds_6_tfhorario_dia_ini_01_to = AV36TFHorario_Dia_Ini_01_To;
         AV71Reloj_interface_reloj_horariowwds_7_tfhorario_dia_fin_01 = AV40TFHorario_Dia_Fin_01;
         AV72Reloj_interface_reloj_horariowwds_8_tfhorario_dia_fin_01_to = AV41TFHorario_Dia_Fin_01_To;
         AV73Reloj_interface_reloj_horariowwds_9_tfhorario_vigencia = AV45TFHorario_Vigencia;
         AV74Reloj_interface_reloj_horariowwds_10_tfhorario_vigencia_to = AV46TFHorario_Vigencia_To;
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
            gxgrGrid_refresh( subGrid_Rows, AV64Pgmname, AV31TFHorario_ID, AV32TFHorario_ID_To, AV33TFHorario_Dsc, AV34TFHorario_Dsc_Sel, AV35TFHorario_Dia_Ini_01, AV36TFHorario_Dia_Ini_01_To, AV40TFHorario_Dia_Fin_01, AV41TFHorario_Dia_Fin_01_To, AV45TFHorario_Vigencia, AV46TFHorario_Vigencia_To, AV13OrderedBy, AV14OrderedDsc) ;
         }
         send_integrity_footer_hashes( ) ;
         return (int)(0) ;
      }

      protected void before_start_formulas( )
      {
         AV64Pgmname = "Reloj_Interface.Reloj_HorarioWW";
         context.Gx_err = 0;
         fix_multi_value_controls( ) ;
      }

      protected void STRUP7D0( )
      {
         /* Before Start, stand alone formulas. */
         before_start_formulas( ) ;
         /* Execute Start event if defined. */
         context.wbGlbDoneStart = 0;
         /* Execute user event: Start */
         E167D2 ();
         context.wbGlbDoneStart = 1;
         /* After Start, stand alone formulas. */
         if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
         {
            /* Read saved SDTs. */
            ajax_req_read_hidden_sdt(cgiGet( "vAGEXPORTDATA"), AV58AGExportData);
            ajax_req_read_hidden_sdt(cgiGet( "vDDO_TITLESETTINGSICONS"), AV52DDO_TitleSettingsIcons);
            /* Read saved values. */
            nRC_GXsfl_33 = (int)(context.localUtil.CToN( cgiGet( "nRC_GXsfl_33"), ".", ","));
            AV54GridCurrentPage = (long)(context.localUtil.CToN( cgiGet( "vGRIDCURRENTPAGE"), ".", ","));
            AV55GridPageCount = (long)(context.localUtil.CToN( cgiGet( "vGRIDPAGECOUNT"), ".", ","));
            AV56GridAppliedFilters = cgiGet( "vGRIDAPPLIEDFILTERS");
            AV37DDO_Horario_Dia_Ini_01AuxDate = context.localUtil.CToD( cgiGet( "vDDO_HORARIO_DIA_INI_01AUXDATE"), 0);
            AV38DDO_Horario_Dia_Ini_01AuxDateTo = context.localUtil.CToD( cgiGet( "vDDO_HORARIO_DIA_INI_01AUXDATETO"), 0);
            AV42DDO_Horario_Dia_Fin_01AuxDate = context.localUtil.CToD( cgiGet( "vDDO_HORARIO_DIA_FIN_01AUXDATE"), 0);
            AV43DDO_Horario_Dia_Fin_01AuxDateTo = context.localUtil.CToD( cgiGet( "vDDO_HORARIO_DIA_FIN_01AUXDATETO"), 0);
            AV47DDO_Horario_VigenciaAuxDate = context.localUtil.CToD( cgiGet( "vDDO_HORARIO_VIGENCIAAUXDATE"), 0);
            AV48DDO_Horario_VigenciaAuxDateTo = context.localUtil.CToD( cgiGet( "vDDO_HORARIO_VIGENCIAAUXDATETO"), 0);
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
            AV39DDO_Horario_Dia_Ini_01AuxDateText = cgiGet( edtavDdo_horario_dia_ini_01auxdatetext_Internalname);
            AssignAttri("", false, "AV39DDO_Horario_Dia_Ini_01AuxDateText", AV39DDO_Horario_Dia_Ini_01AuxDateText);
            AV44DDO_Horario_Dia_Fin_01AuxDateText = cgiGet( edtavDdo_horario_dia_fin_01auxdatetext_Internalname);
            AssignAttri("", false, "AV44DDO_Horario_Dia_Fin_01AuxDateText", AV44DDO_Horario_Dia_Fin_01AuxDateText);
            AV49DDO_Horario_VigenciaAuxDateText = cgiGet( edtavDdo_horario_vigenciaauxdatetext_Internalname);
            AssignAttri("", false, "AV49DDO_Horario_VigenciaAuxDateText", AV49DDO_Horario_VigenciaAuxDateText);
            /* Read subfile selected row values. */
            /* Read hidden variables. */
            GXKey = Crypto.GetSiteKey( );
            /* Check if conditions changed and reset current page numbers */
         }
         else
         {
            dynload_actions( ) ;
         }
      }

      protected void GXStart( )
      {
         /* Execute user event: Start */
         E167D2 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
      }

      protected void E167D2( )
      {
         /* Start Routine */
         returnInSub = false;
         this.executeUsercontrolMethod("", false, "TFHORARIO_VIGENCIA_RANGEPICKERContainer", "Attach", "", new Object[] {(string)edtavDdo_horario_vigenciaauxdatetext_Internalname});
         this.executeUsercontrolMethod("", false, "TFHORARIO_DIA_FIN_01_RANGEPICKERContainer", "Attach", "", new Object[] {(string)edtavDdo_horario_dia_fin_01auxdatetext_Internalname});
         this.executeUsercontrolMethod("", false, "TFHORARIO_DIA_INI_01_RANGEPICKERContainer", "Attach", "", new Object[] {(string)edtavDdo_horario_dia_ini_01auxdatetext_Internalname});
         subGrid_Rows = 10;
         GxWebStd.gx_hidden_field( context, "GRID_Rows", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid_Rows), 6, 0, ".", "")));
         Grid_empowerer_Gridinternalname = subGrid_Internalname;
         ucGrid_empowerer.SendProperty(context, "", false, Grid_empowerer_Internalname, "GridInternalName", Grid_empowerer_Gridinternalname);
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
         Form.Caption = "Horario del Personal";
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
         GXt_SdtDVB_SDTDropDownOptionsTitleSettingsIcons1 = AV52DDO_TitleSettingsIcons;
         new GeneXus.Programs.wwpbaseobjects.getwwptitlesettingsicons(context ).execute( out  GXt_SdtDVB_SDTDropDownOptionsTitleSettingsIcons1) ;
         AV52DDO_TitleSettingsIcons = GXt_SdtDVB_SDTDropDownOptionsTitleSettingsIcons1;
         Gridpaginationbar_Rowsperpageselectedvalue = subGrid_Rows;
         ucGridpaginationbar.SendProperty(context, "", false, Gridpaginationbar_Internalname, "RowsPerPageSelectedValue", StringUtil.LTrimStr( (decimal)(Gridpaginationbar_Rowsperpageselectedvalue), 9, 0));
      }

      protected void E177D2( )
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
         AV54GridCurrentPage = subGrid_fnc_Currentpage( );
         AssignAttri("", false, "AV54GridCurrentPage", StringUtil.LTrimStr( (decimal)(AV54GridCurrentPage), 10, 0));
         AV55GridPageCount = subGrid_fnc_Pagecount( );
         AssignAttri("", false, "AV55GridPageCount", StringUtil.LTrimStr( (decimal)(AV55GridPageCount), 10, 0));
         GXt_char2 = AV56GridAppliedFilters;
         new GeneXus.Programs.wwpbaseobjects.wwp_getappliedfiltersdescription(context ).execute(  AV64Pgmname, out  GXt_char2) ;
         AV56GridAppliedFilters = GXt_char2;
         AssignAttri("", false, "AV56GridAppliedFilters", AV56GridAppliedFilters);
         AV65Reloj_interface_reloj_horariowwds_1_tfhorario_id = AV31TFHorario_ID;
         AV66Reloj_interface_reloj_horariowwds_2_tfhorario_id_to = AV32TFHorario_ID_To;
         AV67Reloj_interface_reloj_horariowwds_3_tfhorario_dsc = AV33TFHorario_Dsc;
         AV68Reloj_interface_reloj_horariowwds_4_tfhorario_dsc_sel = AV34TFHorario_Dsc_Sel;
         AV69Reloj_interface_reloj_horariowwds_5_tfhorario_dia_ini_01 = AV35TFHorario_Dia_Ini_01;
         AV70Reloj_interface_reloj_horariowwds_6_tfhorario_dia_ini_01_to = AV36TFHorario_Dia_Ini_01_To;
         AV71Reloj_interface_reloj_horariowwds_7_tfhorario_dia_fin_01 = AV40TFHorario_Dia_Fin_01;
         AV72Reloj_interface_reloj_horariowwds_8_tfhorario_dia_fin_01_to = AV41TFHorario_Dia_Fin_01_To;
         AV73Reloj_interface_reloj_horariowwds_9_tfhorario_vigencia = AV45TFHorario_Vigencia;
         AV74Reloj_interface_reloj_horariowwds_10_tfhorario_vigencia_to = AV46TFHorario_Vigencia_To;
         /*  Sending Event outputs  */
      }

      protected void E117D2( )
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

      protected void E127D2( )
      {
         /* Gridpaginationbar_Changerowsperpage Routine */
         returnInSub = false;
         subGrid_Rows = Gridpaginationbar_Rowsperpageselectedvalue;
         GxWebStd.gx_hidden_field( context, "GRID_Rows", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid_Rows), 6, 0, ".", "")));
         subgrid_firstpage( ) ;
         /*  Sending Event outputs  */
      }

      protected void E147D2( )
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
            if ( StringUtil.StrCmp(Ddo_grid_Selectedcolumn, "Horario_ID") == 0 )
            {
               AV31TFHorario_ID = (short)(NumberUtil.Val( Ddo_grid_Filteredtext_get, "."));
               AssignAttri("", false, "AV31TFHorario_ID", StringUtil.LTrimStr( (decimal)(AV31TFHorario_ID), 4, 0));
               AV32TFHorario_ID_To = (short)(NumberUtil.Val( Ddo_grid_Filteredtextto_get, "."));
               AssignAttri("", false, "AV32TFHorario_ID_To", StringUtil.LTrimStr( (decimal)(AV32TFHorario_ID_To), 4, 0));
            }
            else if ( StringUtil.StrCmp(Ddo_grid_Selectedcolumn, "Horario_Dsc") == 0 )
            {
               AV33TFHorario_Dsc = Ddo_grid_Filteredtext_get;
               AssignAttri("", false, "AV33TFHorario_Dsc", AV33TFHorario_Dsc);
               AV34TFHorario_Dsc_Sel = Ddo_grid_Selectedvalue_get;
               AssignAttri("", false, "AV34TFHorario_Dsc_Sel", AV34TFHorario_Dsc_Sel);
            }
            else if ( StringUtil.StrCmp(Ddo_grid_Selectedcolumn, "Horario_Dia_Ini_01") == 0 )
            {
               AV35TFHorario_Dia_Ini_01 = DateTimeUtil.ResetDate(context.localUtil.CToT( Ddo_grid_Filteredtext_get, 2));
               AssignAttri("", false, "AV35TFHorario_Dia_Ini_01", context.localUtil.TToC( AV35TFHorario_Dia_Ini_01, 0, 5, 0, 3, "/", ":", " "));
               AV36TFHorario_Dia_Ini_01_To = DateTimeUtil.ResetDate(context.localUtil.CToT( Ddo_grid_Filteredtextto_get, 2));
               AssignAttri("", false, "AV36TFHorario_Dia_Ini_01_To", context.localUtil.TToC( AV36TFHorario_Dia_Ini_01_To, 0, 5, 0, 3, "/", ":", " "));
               if ( ! (DateTime.MinValue==AV36TFHorario_Dia_Ini_01_To) )
               {
                  AV36TFHorario_Dia_Ini_01_To = DateTimeUtil.ResetDate(context.localUtil.YMDHMSToT( (short)(DateTimeUtil.Year( AV36TFHorario_Dia_Ini_01_To)), (short)(DateTimeUtil.Month( AV36TFHorario_Dia_Ini_01_To)), (short)(DateTimeUtil.Day( AV36TFHorario_Dia_Ini_01_To)), 23, 59, 59));
                  AssignAttri("", false, "AV36TFHorario_Dia_Ini_01_To", context.localUtil.TToC( AV36TFHorario_Dia_Ini_01_To, 0, 5, 0, 3, "/", ":", " "));
               }
            }
            else if ( StringUtil.StrCmp(Ddo_grid_Selectedcolumn, "Horario_Dia_Fin_01") == 0 )
            {
               AV40TFHorario_Dia_Fin_01 = DateTimeUtil.ResetDate(context.localUtil.CToT( Ddo_grid_Filteredtext_get, 2));
               AssignAttri("", false, "AV40TFHorario_Dia_Fin_01", context.localUtil.TToC( AV40TFHorario_Dia_Fin_01, 0, 5, 0, 3, "/", ":", " "));
               AV41TFHorario_Dia_Fin_01_To = DateTimeUtil.ResetDate(context.localUtil.CToT( Ddo_grid_Filteredtextto_get, 2));
               AssignAttri("", false, "AV41TFHorario_Dia_Fin_01_To", context.localUtil.TToC( AV41TFHorario_Dia_Fin_01_To, 0, 5, 0, 3, "/", ":", " "));
               if ( ! (DateTime.MinValue==AV41TFHorario_Dia_Fin_01_To) )
               {
                  AV41TFHorario_Dia_Fin_01_To = DateTimeUtil.ResetDate(context.localUtil.YMDHMSToT( (short)(DateTimeUtil.Year( AV41TFHorario_Dia_Fin_01_To)), (short)(DateTimeUtil.Month( AV41TFHorario_Dia_Fin_01_To)), (short)(DateTimeUtil.Day( AV41TFHorario_Dia_Fin_01_To)), 23, 59, 59));
                  AssignAttri("", false, "AV41TFHorario_Dia_Fin_01_To", context.localUtil.TToC( AV41TFHorario_Dia_Fin_01_To, 0, 5, 0, 3, "/", ":", " "));
               }
            }
            else if ( StringUtil.StrCmp(Ddo_grid_Selectedcolumn, "Horario_Vigencia") == 0 )
            {
               AV45TFHorario_Vigencia = context.localUtil.CToT( Ddo_grid_Filteredtext_get, 2);
               AssignAttri("", false, "AV45TFHorario_Vigencia", context.localUtil.TToC( AV45TFHorario_Vigencia, 10, 8, 0, 3, "/", ":", " "));
               AV46TFHorario_Vigencia_To = context.localUtil.CToT( Ddo_grid_Filteredtextto_get, 2);
               AssignAttri("", false, "AV46TFHorario_Vigencia_To", context.localUtil.TToC( AV46TFHorario_Vigencia_To, 10, 8, 0, 3, "/", ":", " "));
               if ( ! (DateTime.MinValue==AV46TFHorario_Vigencia_To) )
               {
                  AV46TFHorario_Vigencia_To = context.localUtil.YMDHMSToT( (short)(DateTimeUtil.Year( AV46TFHorario_Vigencia_To)), (short)(DateTimeUtil.Month( AV46TFHorario_Vigencia_To)), (short)(DateTimeUtil.Day( AV46TFHorario_Vigencia_To)), 23, 59, 59);
                  AssignAttri("", false, "AV46TFHorario_Vigencia_To", context.localUtil.TToC( AV46TFHorario_Vigencia_To, 10, 8, 0, 3, "/", ":", " "));
               }
            }
            subgrid_firstpage( ) ;
         }
         /*  Sending Event outputs  */
      }

      private void E187D2( )
      {
         /* Grid_Load Routine */
         returnInSub = false;
         cmbavGridactions.removeAllItems();
         cmbavGridactions.addItem("0", ";fa fa-bars", 0);
         cmbavGridactions.addItem("1", StringUtil.Format( "%1;%2", "Modificar", "fa fa-pen", "", "", "", "", "", "", ""), 0);
         cmbavGridactions.addItem("2", StringUtil.Format( "%1;%2", "Eliminar", "fa fa-times", "", "", "", "", "", "", ""), 0);
         cmbavGridactions.addItem("3", StringUtil.Format( "%1;%2", "Visualizar", "fa fa-search", "", "", "", "", "", "", ""), 0);
         GXKey = Crypto.GetSiteKey( );
         GXEncryptionTmp = "reloj_interface.reloj_horario.aspx"+UrlEncode(StringUtil.RTrim("DSP")) + "," + UrlEncode(StringUtil.LTrimStr(A2432Horario_ID,4,0));
         edtHorario_Dsc_Link = formatLink("reloj_interface.reloj_horario.aspx") + "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey);
         /* Load Method */
         if ( wbStart != -1 )
         {
            wbStart = 33;
         }
         sendrow_332( ) ;
         GRID_nCurrentRecord = (long)(GRID_nCurrentRecord+1);
         if ( isFullAjaxMode( ) && ! bGXsfl_33_Refreshing )
         {
            DoAjaxLoad(33, GridRow);
         }
         /*  Sending Event outputs  */
         cmbavGridactions.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV57GridActions), 4, 0));
      }

      protected void E197D2( )
      {
         /* Gridactions_Click Routine */
         returnInSub = false;
         if ( AV57GridActions == 1 )
         {
            /* Execute user subroutine: 'DO UPDATE' */
            S152 ();
            if ( returnInSub )
            {
               returnInSub = true;
               if (true) return;
            }
         }
         else if ( AV57GridActions == 2 )
         {
            /* Execute user subroutine: 'DO DELETE' */
            S162 ();
            if ( returnInSub )
            {
               returnInSub = true;
               if (true) return;
            }
         }
         else if ( AV57GridActions == 3 )
         {
            /* Execute user subroutine: 'DO DISPLAY' */
            S172 ();
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

      protected void E157D2( )
      {
         /* 'DoInsert' Routine */
         returnInSub = false;
         GXKey = Crypto.GetSiteKey( );
         GXEncryptionTmp = "reloj_interface.reloj_horario.aspx"+UrlEncode(StringUtil.RTrim("INS")) + "," + UrlEncode(StringUtil.LTrimStr(0,1,0));
         CallWebObject(formatLink("reloj_interface.reloj_horario.aspx") + "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey));
         context.wjLocDisableFrm = 1;
      }

      protected void E137D2( )
      {
         /* Ddo_agexport_Onoptionclicked Routine */
         returnInSub = false;
         if ( StringUtil.StrCmp(Ddo_agexport_Activeeventkey, "ExportReport") == 0 )
         {
            /* Execute user subroutine: 'DOEXPORTREPORT' */
            S182 ();
            if ( returnInSub )
            {
               returnInSub = true;
               if (true) return;
            }
         }
         else if ( StringUtil.StrCmp(Ddo_agexport_Activeeventkey, "Export") == 0 )
         {
            /* Execute user subroutine: 'DOEXPORT' */
            S192 ();
            if ( returnInSub )
            {
               returnInSub = true;
               if (true) return;
            }
         }
         /*  Sending Event outputs  */
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
         GXEncryptionTmp = "reloj_interface.reloj_horario.aspx"+UrlEncode(StringUtil.RTrim("UPD")) + "," + UrlEncode(StringUtil.LTrimStr(A2432Horario_ID,4,0));
         CallWebObject(formatLink("reloj_interface.reloj_horario.aspx") + "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey));
         context.wjLocDisableFrm = 1;
      }

      protected void S162( )
      {
         /* 'DO DELETE' Routine */
         returnInSub = false;
         GXKey = Crypto.GetSiteKey( );
         GXEncryptionTmp = "reloj_interface.reloj_horario.aspx"+UrlEncode(StringUtil.RTrim("DLT")) + "," + UrlEncode(StringUtil.LTrimStr(A2432Horario_ID,4,0));
         CallWebObject(formatLink("reloj_interface.reloj_horario.aspx") + "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey));
         context.wjLocDisableFrm = 1;
      }

      protected void S172( )
      {
         /* 'DO DISPLAY' Routine */
         returnInSub = false;
         GXKey = Crypto.GetSiteKey( );
         GXEncryptionTmp = "reloj_interface.reloj_horario.aspx"+UrlEncode(StringUtil.RTrim("DSP")) + "," + UrlEncode(StringUtil.LTrimStr(A2432Horario_ID,4,0));
         CallWebObject(formatLink("reloj_interface.reloj_horario.aspx") + "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey));
         context.wjLocDisableFrm = 1;
      }

      protected void S122( )
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
         S132 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
         AV75GXV1 = 1;
         while ( AV75GXV1 <= AV10GridState.gxTpr_Filtervalues.Count )
         {
            AV11GridStateFilterValue = ((GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue)AV10GridState.gxTpr_Filtervalues.Item(AV75GXV1));
            if ( StringUtil.StrCmp(AV11GridStateFilterValue.gxTpr_Name, "TFHORARIO_ID") == 0 )
            {
               AV31TFHorario_ID = (short)(NumberUtil.Val( AV11GridStateFilterValue.gxTpr_Value, "."));
               AssignAttri("", false, "AV31TFHorario_ID", StringUtil.LTrimStr( (decimal)(AV31TFHorario_ID), 4, 0));
               AV32TFHorario_ID_To = (short)(NumberUtil.Val( AV11GridStateFilterValue.gxTpr_Valueto, "."));
               AssignAttri("", false, "AV32TFHorario_ID_To", StringUtil.LTrimStr( (decimal)(AV32TFHorario_ID_To), 4, 0));
            }
            else if ( StringUtil.StrCmp(AV11GridStateFilterValue.gxTpr_Name, "TFHORARIO_DSC") == 0 )
            {
               AV33TFHorario_Dsc = AV11GridStateFilterValue.gxTpr_Value;
               AssignAttri("", false, "AV33TFHorario_Dsc", AV33TFHorario_Dsc);
            }
            else if ( StringUtil.StrCmp(AV11GridStateFilterValue.gxTpr_Name, "TFHORARIO_DSC_SEL") == 0 )
            {
               AV34TFHorario_Dsc_Sel = AV11GridStateFilterValue.gxTpr_Value;
               AssignAttri("", false, "AV34TFHorario_Dsc_Sel", AV34TFHorario_Dsc_Sel);
            }
            else if ( StringUtil.StrCmp(AV11GridStateFilterValue.gxTpr_Name, "TFHORARIO_DIA_INI_01") == 0 )
            {
               AV35TFHorario_Dia_Ini_01 = DateTimeUtil.ResetDate(context.localUtil.CToT( AV11GridStateFilterValue.gxTpr_Value, 2));
               AssignAttri("", false, "AV35TFHorario_Dia_Ini_01", context.localUtil.TToC( AV35TFHorario_Dia_Ini_01, 0, 5, 0, 3, "/", ":", " "));
               AV36TFHorario_Dia_Ini_01_To = DateTimeUtil.ResetDate(context.localUtil.CToT( AV11GridStateFilterValue.gxTpr_Valueto, 2));
               AssignAttri("", false, "AV36TFHorario_Dia_Ini_01_To", context.localUtil.TToC( AV36TFHorario_Dia_Ini_01_To, 0, 5, 0, 3, "/", ":", " "));
               AV37DDO_Horario_Dia_Ini_01AuxDate = DateTimeUtil.ResetTime(AV35TFHorario_Dia_Ini_01);
               AssignAttri("", false, "AV37DDO_Horario_Dia_Ini_01AuxDate", context.localUtil.Format(AV37DDO_Horario_Dia_Ini_01AuxDate, "99/99/99"));
               AV38DDO_Horario_Dia_Ini_01AuxDateTo = DateTimeUtil.ResetTime(AV36TFHorario_Dia_Ini_01_To);
               AssignAttri("", false, "AV38DDO_Horario_Dia_Ini_01AuxDateTo", context.localUtil.Format(AV38DDO_Horario_Dia_Ini_01AuxDateTo, "99/99/99"));
            }
            else if ( StringUtil.StrCmp(AV11GridStateFilterValue.gxTpr_Name, "TFHORARIO_DIA_FIN_01") == 0 )
            {
               AV40TFHorario_Dia_Fin_01 = DateTimeUtil.ResetDate(context.localUtil.CToT( AV11GridStateFilterValue.gxTpr_Value, 2));
               AssignAttri("", false, "AV40TFHorario_Dia_Fin_01", context.localUtil.TToC( AV40TFHorario_Dia_Fin_01, 0, 5, 0, 3, "/", ":", " "));
               AV41TFHorario_Dia_Fin_01_To = DateTimeUtil.ResetDate(context.localUtil.CToT( AV11GridStateFilterValue.gxTpr_Valueto, 2));
               AssignAttri("", false, "AV41TFHorario_Dia_Fin_01_To", context.localUtil.TToC( AV41TFHorario_Dia_Fin_01_To, 0, 5, 0, 3, "/", ":", " "));
               AV42DDO_Horario_Dia_Fin_01AuxDate = DateTimeUtil.ResetTime(AV40TFHorario_Dia_Fin_01);
               AssignAttri("", false, "AV42DDO_Horario_Dia_Fin_01AuxDate", context.localUtil.Format(AV42DDO_Horario_Dia_Fin_01AuxDate, "99/99/99"));
               AV43DDO_Horario_Dia_Fin_01AuxDateTo = DateTimeUtil.ResetTime(AV41TFHorario_Dia_Fin_01_To);
               AssignAttri("", false, "AV43DDO_Horario_Dia_Fin_01AuxDateTo", context.localUtil.Format(AV43DDO_Horario_Dia_Fin_01AuxDateTo, "99/99/99"));
            }
            else if ( StringUtil.StrCmp(AV11GridStateFilterValue.gxTpr_Name, "TFHORARIO_VIGENCIA") == 0 )
            {
               AV45TFHorario_Vigencia = context.localUtil.CToT( AV11GridStateFilterValue.gxTpr_Value, 2);
               AssignAttri("", false, "AV45TFHorario_Vigencia", context.localUtil.TToC( AV45TFHorario_Vigencia, 10, 8, 0, 3, "/", ":", " "));
               AV46TFHorario_Vigencia_To = context.localUtil.CToT( AV11GridStateFilterValue.gxTpr_Valueto, 2);
               AssignAttri("", false, "AV46TFHorario_Vigencia_To", context.localUtil.TToC( AV46TFHorario_Vigencia_To, 10, 8, 0, 3, "/", ":", " "));
               AV47DDO_Horario_VigenciaAuxDate = DateTimeUtil.ResetTime(AV45TFHorario_Vigencia);
               AssignAttri("", false, "AV47DDO_Horario_VigenciaAuxDate", context.localUtil.Format(AV47DDO_Horario_VigenciaAuxDate, "99/99/9999"));
               AV48DDO_Horario_VigenciaAuxDateTo = DateTimeUtil.ResetTime(AV46TFHorario_Vigencia_To);
               AssignAttri("", false, "AV48DDO_Horario_VigenciaAuxDateTo", context.localUtil.Format(AV48DDO_Horario_VigenciaAuxDateTo, "99/99/9999"));
            }
            AV75GXV1 = (int)(AV75GXV1+1);
         }
         GXt_char2 = "";
         new GeneXus.Programs.wwpbaseobjects.wwp_getfilterval(context ).execute(  String.IsNullOrEmpty(StringUtil.RTrim( AV34TFHorario_Dsc_Sel)),  AV34TFHorario_Dsc_Sel, out  GXt_char2) ;
         Ddo_grid_Selectedvalue_set = "|"+GXt_char2+"|||";
         ucDdo_grid.SendProperty(context, "", false, Ddo_grid_Internalname, "SelectedValue_set", Ddo_grid_Selectedvalue_set);
         GXt_char2 = "";
         new GeneXus.Programs.wwpbaseobjects.wwp_getfilterval(context ).execute(  String.IsNullOrEmpty(StringUtil.RTrim( AV33TFHorario_Dsc)),  AV33TFHorario_Dsc, out  GXt_char2) ;
         Ddo_grid_Filteredtext_set = ((0==AV31TFHorario_ID) ? "" : StringUtil.Str( (decimal)(AV31TFHorario_ID), 4, 0))+"|"+GXt_char2+"|"+((DateTime.MinValue==AV35TFHorario_Dia_Ini_01) ? "" : context.localUtil.DToC( AV37DDO_Horario_Dia_Ini_01AuxDate, 2, "/"))+"|"+((DateTime.MinValue==AV40TFHorario_Dia_Fin_01) ? "" : context.localUtil.DToC( AV42DDO_Horario_Dia_Fin_01AuxDate, 2, "/"))+"|"+((DateTime.MinValue==AV45TFHorario_Vigencia) ? "" : context.localUtil.DToC( AV47DDO_Horario_VigenciaAuxDate, 2, "/"));
         ucDdo_grid.SendProperty(context, "", false, Ddo_grid_Internalname, "FilteredText_set", Ddo_grid_Filteredtext_set);
         Ddo_grid_Filteredtextto_set = ((0==AV32TFHorario_ID_To) ? "" : StringUtil.Str( (decimal)(AV32TFHorario_ID_To), 4, 0))+"||"+((DateTime.MinValue==AV36TFHorario_Dia_Ini_01_To) ? "" : context.localUtil.DToC( AV38DDO_Horario_Dia_Ini_01AuxDateTo, 2, "/"))+"|"+((DateTime.MinValue==AV41TFHorario_Dia_Fin_01_To) ? "" : context.localUtil.DToC( AV43DDO_Horario_Dia_Fin_01AuxDateTo, 2, "/"))+"|"+((DateTime.MinValue==AV46TFHorario_Vigencia_To) ? "" : context.localUtil.DToC( AV48DDO_Horario_VigenciaAuxDateTo, 2, "/"));
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
         AV10GridState.FromXml(AV30Session.Get(AV64Pgmname+"GridState"), null, "", "");
         AV10GridState.gxTpr_Orderedby = AV13OrderedBy;
         AV10GridState.gxTpr_Ordereddsc = AV14OrderedDsc;
         AV10GridState.gxTpr_Filtervalues.Clear();
         new GeneXus.Programs.wwpbaseobjects.wwp_gridstateaddfiltervalue(context ).execute( ref  AV10GridState,  "TFHORARIO_ID",  "ID",  !((0==AV31TFHorario_ID)&&(0==AV32TFHorario_ID_To)),  0,  StringUtil.Trim( StringUtil.Str( (decimal)(AV31TFHorario_ID), 4, 0)),  StringUtil.Trim( StringUtil.Str( (decimal)(AV32TFHorario_ID_To), 4, 0))) ;
         new GeneXus.Programs.wwpbaseobjects.wwp_gridstateaddfiltervalueandsel(context ).execute( ref  AV10GridState,  "TFHORARIO_DSC",  "Horario_Dsc",  !String.IsNullOrEmpty(StringUtil.RTrim( AV33TFHorario_Dsc)),  0,  AV33TFHorario_Dsc,  "",  !String.IsNullOrEmpty(StringUtil.RTrim( AV34TFHorario_Dsc_Sel)),  AV34TFHorario_Dsc_Sel,  "") ;
         new GeneXus.Programs.wwpbaseobjects.wwp_gridstateaddfiltervalue(context ).execute( ref  AV10GridState,  "TFHORARIO_DIA_INI_01",  "Horario Ingreso",  !((DateTime.MinValue==AV35TFHorario_Dia_Ini_01)&&(DateTime.MinValue==AV36TFHorario_Dia_Ini_01_To)),  0,  StringUtil.Trim( context.localUtil.TToC( AV35TFHorario_Dia_Ini_01, 0, 5, 0, 3, "/", ":", " ")),  StringUtil.Trim( context.localUtil.TToC( AV36TFHorario_Dia_Ini_01_To, 0, 5, 0, 3, "/", ":", " "))) ;
         new GeneXus.Programs.wwpbaseobjects.wwp_gridstateaddfiltervalue(context ).execute( ref  AV10GridState,  "TFHORARIO_DIA_FIN_01",  "Horario Salida",  !((DateTime.MinValue==AV40TFHorario_Dia_Fin_01)&&(DateTime.MinValue==AV41TFHorario_Dia_Fin_01_To)),  0,  StringUtil.Trim( context.localUtil.TToC( AV40TFHorario_Dia_Fin_01, 0, 5, 0, 3, "/", ":", " ")),  StringUtil.Trim( context.localUtil.TToC( AV41TFHorario_Dia_Fin_01_To, 0, 5, 0, 3, "/", ":", " "))) ;
         new GeneXus.Programs.wwpbaseobjects.wwp_gridstateaddfiltervalue(context ).execute( ref  AV10GridState,  "TFHORARIO_VIGENCIA",  "Fecha Registro",  !((DateTime.MinValue==AV45TFHorario_Vigencia)&&(DateTime.MinValue==AV46TFHorario_Vigencia_To)),  0,  StringUtil.Trim( context.localUtil.TToC( AV45TFHorario_Vigencia, 10, 8, 0, 3, "/", ":", " ")),  StringUtil.Trim( context.localUtil.TToC( AV46TFHorario_Vigencia_To, 10, 8, 0, 3, "/", ":", " "))) ;
         AV10GridState.gxTpr_Pagesize = StringUtil.Str( (decimal)(subGrid_Rows), 10, 0);
         AV10GridState.gxTpr_Currentpage = (short)(subGrid_fnc_Currentpage( ));
         new GeneXus.Programs.wwpbaseobjects.savegridstate(context ).execute(  AV64Pgmname+"GridState",  AV10GridState.ToXml(false, true, "", "")) ;
      }

      protected void S112( )
      {
         /* 'PREPARETRANSACTION' Routine */
         returnInSub = false;
         AV8TrnContext = new GeneXus.Programs.wwpbaseobjects.SdtWWPTransactionContext(context);
         AV8TrnContext.gxTpr_Callerobject = AV64Pgmname;
         AV8TrnContext.gxTpr_Callerondelete = true;
         AV8TrnContext.gxTpr_Callerurl = AV7HTTPRequest.ScriptName+"?"+AV7HTTPRequest.QueryString;
         AV8TrnContext.gxTpr_Transactionname = "Reloj_Interface.Reloj_Horario";
         AV30Session.Set("TrnContext", AV8TrnContext.ToXml(false, true, "", ""));
      }

      protected void S192( )
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
         new GeneXus.Programs.reloj_interface.reloj_horariowwexport(context ).execute( out  AV28ExcelFilename, out  AV29ErrorMessage) ;
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

      protected void S182( )
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
         Innewwindow1_Target = formatLink("reloj_interface.reloj_horariowwexportreport.aspx") ;
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
         PA7D2( ) ;
         WS7D2( ) ;
         WE7D2( ) ;
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
            context.AddJavascriptSource(StringUtil.RTrim( ((string)Form.Jscriptsrc.Item(idxLst))), "?20228181032268", true, true);
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
         context.AddJavascriptSource("reloj_interface/reloj_horarioww.js", "?20228181032268", false, true);
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
         context.AddJavascriptSource("DVelop/Shared/daterangepicker/locales.js", "", false, true);
         context.AddJavascriptSource("DVelop/Shared/daterangepicker/wwp-daterangepicker.js", "", false, true);
         context.AddJavascriptSource("DVelop/Shared/daterangepicker/moment.min.js", "", false, true);
         context.AddJavascriptSource("DVelop/Shared/daterangepicker/daterangepicker.min.js", "", false, true);
         context.AddJavascriptSource("DVelop/Shared/WorkWithPlusCommon.js", "", false, true);
         context.AddJavascriptSource("DVelop/DateRangePicker/DateRangePickerRender.js", "", false, true);
         /* End function include_jscripts */
      }

      protected void SubsflControlProps_332( )
      {
         cmbavGridactions_Internalname = "vGRIDACTIONS_"+sGXsfl_33_idx;
         edtHorario_ID_Internalname = "HORARIO_ID_"+sGXsfl_33_idx;
         edtHorario_Dsc_Internalname = "HORARIO_DSC_"+sGXsfl_33_idx;
         edtHorario_Dia_Ini_01_Internalname = "HORARIO_DIA_INI_01_"+sGXsfl_33_idx;
         edtHorario_Dia_Fin_01_Internalname = "HORARIO_DIA_FIN_01_"+sGXsfl_33_idx;
         edtHorario_Vigencia_Internalname = "HORARIO_VIGENCIA_"+sGXsfl_33_idx;
      }

      protected void SubsflControlProps_fel_332( )
      {
         cmbavGridactions_Internalname = "vGRIDACTIONS_"+sGXsfl_33_fel_idx;
         edtHorario_ID_Internalname = "HORARIO_ID_"+sGXsfl_33_fel_idx;
         edtHorario_Dsc_Internalname = "HORARIO_DSC_"+sGXsfl_33_fel_idx;
         edtHorario_Dia_Ini_01_Internalname = "HORARIO_DIA_INI_01_"+sGXsfl_33_fel_idx;
         edtHorario_Dia_Fin_01_Internalname = "HORARIO_DIA_FIN_01_"+sGXsfl_33_fel_idx;
         edtHorario_Vigencia_Internalname = "HORARIO_VIGENCIA_"+sGXsfl_33_fel_idx;
      }

      protected void sendrow_332( )
      {
         SubsflControlProps_332( ) ;
         WB7D0( ) ;
         if ( ( subGrid_Rows * 1 == 0 ) || ( nGXsfl_33_idx <= subGrid_fnc_Recordsperpage( ) * 1 ) )
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
               if ( ((int)((nGXsfl_33_idx) % (2))) == 0 )
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
               context.WriteHtmlText( " gxrow=\""+sGXsfl_33_idx+"\">") ;
            }
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"right"+"\""+" style=\""+""+"\">") ;
            }
            TempTags = " " + ((cmbavGridactions.Enabled!=0)&&(cmbavGridactions.Visible!=0) ? " onfocus=\"gx.evt.onfocus(this, 34,'',false,'"+sGXsfl_33_idx+"',33)\"" : " ");
            if ( ( cmbavGridactions.ItemCount == 0 ) && isAjaxCallMode( ) )
            {
               GXCCtl = "vGRIDACTIONS_" + sGXsfl_33_idx;
               cmbavGridactions.Name = GXCCtl;
               cmbavGridactions.WebTags = "";
               if ( cmbavGridactions.ItemCount > 0 )
               {
                  AV57GridActions = (short)(NumberUtil.Val( cmbavGridactions.getValidValue(StringUtil.Trim( StringUtil.Str( (decimal)(AV57GridActions), 4, 0))), "."));
                  AssignAttri("", false, cmbavGridactions_Internalname, StringUtil.LTrimStr( (decimal)(AV57GridActions), 4, 0));
               }
            }
            /* ComboBox */
            GridRow.AddColumnProperties("combobox", 2, isAjaxCallMode( ), new Object[] {(GXCombobox)cmbavGridactions,(string)cmbavGridactions_Internalname,StringUtil.Trim( StringUtil.Str( (decimal)(AV57GridActions), 4, 0)),(short)1,(string)cmbavGridactions_Jsonclick,(short)5,"'"+""+"'"+",false,"+"'"+"EVGRIDACTIONS.CLICK."+sGXsfl_33_idx+"'",(string)"int",(string)"",(short)-1,(short)1,(short)0,(short)0,(short)0,(string)"px",(short)0,(string)"px",(string)"",(string)"ConvertToDDO",(string)"WWActionGroupColumn",(string)"",TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+((cmbavGridactions.Enabled!=0)&&(cmbavGridactions.Visible!=0) ? " onblur=\""+""+";gx.evt.onblur(this,34);\"" : " "),(string)"",(bool)true,(short)1});
            cmbavGridactions.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV57GridActions), 4, 0));
            AssignProp("", false, cmbavGridactions_Internalname, "Values", (string)(cmbavGridactions.ToJavascriptSource()), !bGXsfl_33_Refreshing);
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"right"+"\""+" style=\""+""+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtHorario_ID_Internalname,StringUtil.LTrim( StringUtil.NToC( (decimal)(A2432Horario_ID), 4, 0, ".", "")),StringUtil.LTrim( context.localUtil.Format( (decimal)(A2432Horario_ID), "ZZZ9")),(string)" inputmode=\"numeric\" pattern=\"[0-9]*\""+"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtHorario_ID_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn hidden-xs",(string)"",(short)-1,(short)0,(short)0,(string)"text",(string)"1",(short)0,(string)"px",(short)17,(string)"px",(short)4,(short)0,(short)0,(short)33,(short)1,(short)-1,(short)0,(bool)true,(string)"",(string)"right",(bool)false,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"left"+"\""+" style=\""+""+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtHorario_Dsc_Internalname,(string)A2433Horario_Dsc,(string)"",(string)"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)edtHorario_Dsc_Link,(string)"",(string)"",(string)"",(string)edtHorario_Dsc_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn",(string)"",(short)-1,(short)0,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)100,(short)0,(short)0,(short)33,(short)1,(short)-1,(short)-1,(bool)true,(string)"",(string)"left",(bool)true,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"center"+"\""+" style=\""+""+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtHorario_Dia_Ini_01_Internalname,context.localUtil.TToC( A2434Horario_Dia_Ini_01, 10, 8, 0, 3, "/", ":", " "),context.localUtil.Format( A2434Horario_Dia_Ini_01, "99:99"),(string)"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtHorario_Dia_Ini_01_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn hidden-xs",(string)"",(short)-1,(short)0,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)5,(short)0,(short)0,(short)33,(short)1,(short)-1,(short)0,(bool)true,(string)"Dominio_Hora",(string)"center",(bool)false,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"center"+"\""+" style=\""+""+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtHorario_Dia_Fin_01_Internalname,context.localUtil.TToC( A2441Horario_Dia_Fin_01, 10, 8, 0, 3, "/", ":", " "),context.localUtil.Format( A2441Horario_Dia_Fin_01, "99:99"),(string)"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtHorario_Dia_Fin_01_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn",(string)"",(short)-1,(short)0,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)5,(short)0,(short)0,(short)33,(short)1,(short)-1,(short)0,(bool)true,(string)"Dominio_Hora",(string)"center",(bool)false,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"right"+"\""+" style=\""+""+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtHorario_Vigencia_Internalname,context.localUtil.TToC( A2462Horario_Vigencia, 10, 8, 0, 3, "/", ":", " "),context.localUtil.Format( A2462Horario_Vigencia, "99/99/9999 99:99:99"),(string)"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtHorario_Vigencia_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn",(string)"",(short)-1,(short)0,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)19,(short)0,(short)0,(short)33,(short)1,(short)-1,(short)0,(bool)true,(string)"",(string)"right",(bool)false,(string)""});
            send_integrity_lvl_hashes7D2( ) ;
            GridContainer.AddRow(GridRow);
            nGXsfl_33_idx = ((subGrid_Islastpage==1)&&(nGXsfl_33_idx+1>subGrid_fnc_Recordsperpage( )) ? 1 : nGXsfl_33_idx+1);
            sGXsfl_33_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_33_idx), 4, 0), 4, "0");
            SubsflControlProps_332( ) ;
         }
         /* End function sendrow_332 */
      }

      protected void init_web_controls( )
      {
         GXCCtl = "vGRIDACTIONS_" + sGXsfl_33_idx;
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
         divTablerightheader_Internalname = "TABLERIGHTHEADER";
         divTableheadercontent_Internalname = "TABLEHEADERCONTENT";
         divTableheader_Internalname = "TABLEHEADER";
         Dvpanel_tableheader_Internalname = "DVPANEL_TABLEHEADER";
         cmbavGridactions_Internalname = "vGRIDACTIONS";
         edtHorario_ID_Internalname = "HORARIO_ID";
         edtHorario_Dsc_Internalname = "HORARIO_DSC";
         edtHorario_Dia_Ini_01_Internalname = "HORARIO_DIA_INI_01";
         edtHorario_Dia_Fin_01_Internalname = "HORARIO_DIA_FIN_01";
         edtHorario_Vigencia_Internalname = "HORARIO_VIGENCIA";
         Gridpaginationbar_Internalname = "GRIDPAGINATIONBAR";
         divGridtablewithpaginationbar_Internalname = "GRIDTABLEWITHPAGINATIONBAR";
         divTablemain_Internalname = "TABLEMAIN";
         Ddo_agexport_Internalname = "DDO_AGEXPORT";
         Ddo_grid_Internalname = "DDO_GRID";
         Innewwindow1_Internalname = "INNEWWINDOW1";
         Grid_empowerer_Internalname = "GRID_EMPOWERER";
         edtavDdo_horario_dia_ini_01auxdatetext_Internalname = "vDDO_HORARIO_DIA_INI_01AUXDATETEXT";
         Tfhorario_dia_ini_01_rangepicker_Internalname = "TFHORARIO_DIA_INI_01_RANGEPICKER";
         divDdo_horario_dia_ini_01auxdates_Internalname = "DDO_HORARIO_DIA_INI_01AUXDATES";
         edtavDdo_horario_dia_fin_01auxdatetext_Internalname = "vDDO_HORARIO_DIA_FIN_01AUXDATETEXT";
         Tfhorario_dia_fin_01_rangepicker_Internalname = "TFHORARIO_DIA_FIN_01_RANGEPICKER";
         divDdo_horario_dia_fin_01auxdates_Internalname = "DDO_HORARIO_DIA_FIN_01AUXDATES";
         edtavDdo_horario_vigenciaauxdatetext_Internalname = "vDDO_HORARIO_VIGENCIAAUXDATETEXT";
         Tfhorario_vigencia_rangepicker_Internalname = "TFHORARIO_VIGENCIA_RANGEPICKER";
         divDdo_horario_vigenciaauxdates_Internalname = "DDO_HORARIO_VIGENCIAAUXDATES";
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
         edtHorario_Vigencia_Jsonclick = "";
         edtHorario_Dia_Fin_01_Jsonclick = "";
         edtHorario_Dia_Ini_01_Jsonclick = "";
         edtHorario_Dsc_Jsonclick = "";
         edtHorario_ID_Jsonclick = "";
         cmbavGridactions_Jsonclick = "";
         cmbavGridactions.Visible = -1;
         cmbavGridactions.Enabled = 1;
         edtavDdo_horario_vigenciaauxdatetext_Jsonclick = "";
         edtavDdo_horario_dia_fin_01auxdatetext_Jsonclick = "";
         edtavDdo_horario_dia_ini_01auxdatetext_Jsonclick = "";
         subGrid_Allowcollapsing = 0;
         subGrid_Allowselection = 0;
         edtHorario_Dsc_Link = "";
         subGrid_Sortable = 0;
         subGrid_Header = "";
         subGrid_Class = "GridWithPaginationBar WorkWith";
         subGrid_Backcolorstyle = 0;
         Grid_empowerer_Hastitlesettings = Convert.ToBoolean( -1);
         Innewwindow1_Target = "";
         Innewwindow1_Height = "50";
         Innewwindow1_Width = "50";
         Ddo_grid_Datalistproc = "Reloj_Interface.Reloj_HorarioWWGetFilterData";
         Ddo_grid_Datalisttype = "|Dynamic|||";
         Ddo_grid_Includedatalist = "|T|||";
         Ddo_grid_Filterisrange = "T||P|P|P";
         Ddo_grid_Filtertype = "Numeric|Character|Date|Date|Date";
         Ddo_grid_Includefilter = "T";
         Ddo_grid_Includesortasc = "T";
         Ddo_grid_Columnssortvalues = "1|2|3|4|5";
         Ddo_grid_Columnids = "1:Horario_ID|2:Horario_Dsc|3:Horario_Dia_Ini_01|4:Horario_Dia_Fin_01|5:Horario_Vigencia";
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
         Form.Caption = "Horario del Personal";
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
         setEventMetadata("REFRESH","{handler:'Refresh',iparms:[{av:'GRID_nFirstRecordOnPage'},{av:'GRID_nEOF'},{av:'subGrid_Rows',ctrl:'GRID',prop:'Rows'},{av:'AV64Pgmname',fld:'vPGMNAME',pic:'',hsh:true},{av:'AV31TFHorario_ID',fld:'vTFHORARIO_ID',pic:'ZZZ9'},{av:'AV32TFHorario_ID_To',fld:'vTFHORARIO_ID_TO',pic:'ZZZ9'},{av:'AV33TFHorario_Dsc',fld:'vTFHORARIO_DSC',pic:''},{av:'AV34TFHorario_Dsc_Sel',fld:'vTFHORARIO_DSC_SEL',pic:''},{av:'AV35TFHorario_Dia_Ini_01',fld:'vTFHORARIO_DIA_INI_01',pic:'99:99'},{av:'AV36TFHorario_Dia_Ini_01_To',fld:'vTFHORARIO_DIA_INI_01_TO',pic:'99:99'},{av:'AV40TFHorario_Dia_Fin_01',fld:'vTFHORARIO_DIA_FIN_01',pic:'99:99'},{av:'AV41TFHorario_Dia_Fin_01_To',fld:'vTFHORARIO_DIA_FIN_01_TO',pic:'99:99'},{av:'AV45TFHorario_Vigencia',fld:'vTFHORARIO_VIGENCIA',pic:'99/99/9999 99:99:99'},{av:'AV46TFHorario_Vigencia_To',fld:'vTFHORARIO_VIGENCIA_TO',pic:'99/99/9999 99:99:99'},{av:'AV13OrderedBy',fld:'vORDEREDBY',pic:'ZZZ9'},{av:'AV14OrderedDsc',fld:'vORDEREDDSC',pic:''}]");
         setEventMetadata("REFRESH",",oparms:[{av:'AV54GridCurrentPage',fld:'vGRIDCURRENTPAGE',pic:'ZZZZZZZZZ9'},{av:'AV55GridPageCount',fld:'vGRIDPAGECOUNT',pic:'ZZZZZZZZZ9'},{av:'AV56GridAppliedFilters',fld:'vGRIDAPPLIEDFILTERS',pic:''}]}");
         setEventMetadata("GRIDPAGINATIONBAR.CHANGEPAGE","{handler:'E117D2',iparms:[{av:'GRID_nFirstRecordOnPage'},{av:'GRID_nEOF'},{av:'subGrid_Rows',ctrl:'GRID',prop:'Rows'},{av:'AV64Pgmname',fld:'vPGMNAME',pic:'',hsh:true},{av:'AV31TFHorario_ID',fld:'vTFHORARIO_ID',pic:'ZZZ9'},{av:'AV32TFHorario_ID_To',fld:'vTFHORARIO_ID_TO',pic:'ZZZ9'},{av:'AV33TFHorario_Dsc',fld:'vTFHORARIO_DSC',pic:''},{av:'AV34TFHorario_Dsc_Sel',fld:'vTFHORARIO_DSC_SEL',pic:''},{av:'AV35TFHorario_Dia_Ini_01',fld:'vTFHORARIO_DIA_INI_01',pic:'99:99'},{av:'AV36TFHorario_Dia_Ini_01_To',fld:'vTFHORARIO_DIA_INI_01_TO',pic:'99:99'},{av:'AV40TFHorario_Dia_Fin_01',fld:'vTFHORARIO_DIA_FIN_01',pic:'99:99'},{av:'AV41TFHorario_Dia_Fin_01_To',fld:'vTFHORARIO_DIA_FIN_01_TO',pic:'99:99'},{av:'AV45TFHorario_Vigencia',fld:'vTFHORARIO_VIGENCIA',pic:'99/99/9999 99:99:99'},{av:'AV46TFHorario_Vigencia_To',fld:'vTFHORARIO_VIGENCIA_TO',pic:'99/99/9999 99:99:99'},{av:'AV13OrderedBy',fld:'vORDEREDBY',pic:'ZZZ9'},{av:'AV14OrderedDsc',fld:'vORDEREDDSC',pic:''},{av:'Gridpaginationbar_Selectedpage',ctrl:'GRIDPAGINATIONBAR',prop:'SelectedPage'}]");
         setEventMetadata("GRIDPAGINATIONBAR.CHANGEPAGE",",oparms:[]}");
         setEventMetadata("GRIDPAGINATIONBAR.CHANGEROWSPERPAGE","{handler:'E127D2',iparms:[{av:'GRID_nFirstRecordOnPage'},{av:'GRID_nEOF'},{av:'subGrid_Rows',ctrl:'GRID',prop:'Rows'},{av:'AV64Pgmname',fld:'vPGMNAME',pic:'',hsh:true},{av:'AV31TFHorario_ID',fld:'vTFHORARIO_ID',pic:'ZZZ9'},{av:'AV32TFHorario_ID_To',fld:'vTFHORARIO_ID_TO',pic:'ZZZ9'},{av:'AV33TFHorario_Dsc',fld:'vTFHORARIO_DSC',pic:''},{av:'AV34TFHorario_Dsc_Sel',fld:'vTFHORARIO_DSC_SEL',pic:''},{av:'AV35TFHorario_Dia_Ini_01',fld:'vTFHORARIO_DIA_INI_01',pic:'99:99'},{av:'AV36TFHorario_Dia_Ini_01_To',fld:'vTFHORARIO_DIA_INI_01_TO',pic:'99:99'},{av:'AV40TFHorario_Dia_Fin_01',fld:'vTFHORARIO_DIA_FIN_01',pic:'99:99'},{av:'AV41TFHorario_Dia_Fin_01_To',fld:'vTFHORARIO_DIA_FIN_01_TO',pic:'99:99'},{av:'AV45TFHorario_Vigencia',fld:'vTFHORARIO_VIGENCIA',pic:'99/99/9999 99:99:99'},{av:'AV46TFHorario_Vigencia_To',fld:'vTFHORARIO_VIGENCIA_TO',pic:'99/99/9999 99:99:99'},{av:'AV13OrderedBy',fld:'vORDEREDBY',pic:'ZZZ9'},{av:'AV14OrderedDsc',fld:'vORDEREDDSC',pic:''},{av:'Gridpaginationbar_Rowsperpageselectedvalue',ctrl:'GRIDPAGINATIONBAR',prop:'RowsPerPageSelectedValue'}]");
         setEventMetadata("GRIDPAGINATIONBAR.CHANGEROWSPERPAGE",",oparms:[{av:'subGrid_Rows',ctrl:'GRID',prop:'Rows'}]}");
         setEventMetadata("DDO_GRID.ONOPTIONCLICKED","{handler:'E147D2',iparms:[{av:'GRID_nFirstRecordOnPage'},{av:'GRID_nEOF'},{av:'subGrid_Rows',ctrl:'GRID',prop:'Rows'},{av:'AV64Pgmname',fld:'vPGMNAME',pic:'',hsh:true},{av:'AV31TFHorario_ID',fld:'vTFHORARIO_ID',pic:'ZZZ9'},{av:'AV32TFHorario_ID_To',fld:'vTFHORARIO_ID_TO',pic:'ZZZ9'},{av:'AV33TFHorario_Dsc',fld:'vTFHORARIO_DSC',pic:''},{av:'AV34TFHorario_Dsc_Sel',fld:'vTFHORARIO_DSC_SEL',pic:''},{av:'AV35TFHorario_Dia_Ini_01',fld:'vTFHORARIO_DIA_INI_01',pic:'99:99'},{av:'AV36TFHorario_Dia_Ini_01_To',fld:'vTFHORARIO_DIA_INI_01_TO',pic:'99:99'},{av:'AV40TFHorario_Dia_Fin_01',fld:'vTFHORARIO_DIA_FIN_01',pic:'99:99'},{av:'AV41TFHorario_Dia_Fin_01_To',fld:'vTFHORARIO_DIA_FIN_01_TO',pic:'99:99'},{av:'AV45TFHorario_Vigencia',fld:'vTFHORARIO_VIGENCIA',pic:'99/99/9999 99:99:99'},{av:'AV46TFHorario_Vigencia_To',fld:'vTFHORARIO_VIGENCIA_TO',pic:'99/99/9999 99:99:99'},{av:'AV13OrderedBy',fld:'vORDEREDBY',pic:'ZZZ9'},{av:'AV14OrderedDsc',fld:'vORDEREDDSC',pic:''},{av:'Ddo_grid_Activeeventkey',ctrl:'DDO_GRID',prop:'ActiveEventKey'},{av:'Ddo_grid_Selectedvalue_get',ctrl:'DDO_GRID',prop:'SelectedValue_get'},{av:'Ddo_grid_Selectedcolumn',ctrl:'DDO_GRID',prop:'SelectedColumn'},{av:'Ddo_grid_Filteredtext_get',ctrl:'DDO_GRID',prop:'FilteredText_get'},{av:'Ddo_grid_Filteredtextto_get',ctrl:'DDO_GRID',prop:'FilteredTextTo_get'}]");
         setEventMetadata("DDO_GRID.ONOPTIONCLICKED",",oparms:[{av:'AV13OrderedBy',fld:'vORDEREDBY',pic:'ZZZ9'},{av:'AV14OrderedDsc',fld:'vORDEREDDSC',pic:''},{av:'AV31TFHorario_ID',fld:'vTFHORARIO_ID',pic:'ZZZ9'},{av:'AV32TFHorario_ID_To',fld:'vTFHORARIO_ID_TO',pic:'ZZZ9'},{av:'AV33TFHorario_Dsc',fld:'vTFHORARIO_DSC',pic:''},{av:'AV34TFHorario_Dsc_Sel',fld:'vTFHORARIO_DSC_SEL',pic:''},{av:'AV35TFHorario_Dia_Ini_01',fld:'vTFHORARIO_DIA_INI_01',pic:'99:99'},{av:'AV36TFHorario_Dia_Ini_01_To',fld:'vTFHORARIO_DIA_INI_01_TO',pic:'99:99'},{av:'AV40TFHorario_Dia_Fin_01',fld:'vTFHORARIO_DIA_FIN_01',pic:'99:99'},{av:'AV41TFHorario_Dia_Fin_01_To',fld:'vTFHORARIO_DIA_FIN_01_TO',pic:'99:99'},{av:'AV45TFHorario_Vigencia',fld:'vTFHORARIO_VIGENCIA',pic:'99/99/9999 99:99:99'},{av:'AV46TFHorario_Vigencia_To',fld:'vTFHORARIO_VIGENCIA_TO',pic:'99/99/9999 99:99:99'},{av:'Ddo_grid_Sortedstatus',ctrl:'DDO_GRID',prop:'SortedStatus'}]}");
         setEventMetadata("GRID.LOAD","{handler:'E187D2',iparms:[{av:'A2432Horario_ID',fld:'HORARIO_ID',pic:'ZZZ9',hsh:true}]");
         setEventMetadata("GRID.LOAD",",oparms:[{av:'cmbavGridactions'},{av:'AV57GridActions',fld:'vGRIDACTIONS',pic:'ZZZ9'},{av:'edtHorario_Dsc_Link',ctrl:'HORARIO_DSC',prop:'Link'}]}");
         setEventMetadata("VGRIDACTIONS.CLICK","{handler:'E197D2',iparms:[{av:'cmbavGridactions'},{av:'AV57GridActions',fld:'vGRIDACTIONS',pic:'ZZZ9'},{av:'A2432Horario_ID',fld:'HORARIO_ID',pic:'ZZZ9',hsh:true}]");
         setEventMetadata("VGRIDACTIONS.CLICK",",oparms:[{av:'cmbavGridactions'},{av:'AV57GridActions',fld:'vGRIDACTIONS',pic:'ZZZ9'}]}");
         setEventMetadata("'DOINSERT'","{handler:'E157D2',iparms:[{av:'A2432Horario_ID',fld:'HORARIO_ID',pic:'ZZZ9',hsh:true}]");
         setEventMetadata("'DOINSERT'",",oparms:[]}");
         setEventMetadata("DDO_AGEXPORT.ONOPTIONCLICKED","{handler:'E137D2',iparms:[{av:'Ddo_agexport_Activeeventkey',ctrl:'DDO_AGEXPORT',prop:'ActiveEventKey'},{av:'AV64Pgmname',fld:'vPGMNAME',pic:'',hsh:true},{av:'AV34TFHorario_Dsc_Sel',fld:'vTFHORARIO_DSC_SEL',pic:''},{av:'AV31TFHorario_ID',fld:'vTFHORARIO_ID',pic:'ZZZ9'},{av:'AV33TFHorario_Dsc',fld:'vTFHORARIO_DSC',pic:''},{av:'AV35TFHorario_Dia_Ini_01',fld:'vTFHORARIO_DIA_INI_01',pic:'99:99'},{av:'AV37DDO_Horario_Dia_Ini_01AuxDate',fld:'vDDO_HORARIO_DIA_INI_01AUXDATE',pic:''},{av:'AV40TFHorario_Dia_Fin_01',fld:'vTFHORARIO_DIA_FIN_01',pic:'99:99'},{av:'AV42DDO_Horario_Dia_Fin_01AuxDate',fld:'vDDO_HORARIO_DIA_FIN_01AUXDATE',pic:''},{av:'AV45TFHorario_Vigencia',fld:'vTFHORARIO_VIGENCIA',pic:'99/99/9999 99:99:99'},{av:'AV47DDO_Horario_VigenciaAuxDate',fld:'vDDO_HORARIO_VIGENCIAAUXDATE',pic:''},{av:'AV32TFHorario_ID_To',fld:'vTFHORARIO_ID_TO',pic:'ZZZ9'},{av:'AV36TFHorario_Dia_Ini_01_To',fld:'vTFHORARIO_DIA_INI_01_TO',pic:'99:99'},{av:'AV38DDO_Horario_Dia_Ini_01AuxDateTo',fld:'vDDO_HORARIO_DIA_INI_01AUXDATETO',pic:''},{av:'AV41TFHorario_Dia_Fin_01_To',fld:'vTFHORARIO_DIA_FIN_01_TO',pic:'99:99'},{av:'AV43DDO_Horario_Dia_Fin_01AuxDateTo',fld:'vDDO_HORARIO_DIA_FIN_01AUXDATETO',pic:''},{av:'AV46TFHorario_Vigencia_To',fld:'vTFHORARIO_VIGENCIA_TO',pic:'99/99/9999 99:99:99'},{av:'AV48DDO_Horario_VigenciaAuxDateTo',fld:'vDDO_HORARIO_VIGENCIAAUXDATETO',pic:''},{av:'AV13OrderedBy',fld:'vORDEREDBY',pic:'ZZZ9'},{av:'AV14OrderedDsc',fld:'vORDEREDDSC',pic:''}]");
         setEventMetadata("DDO_AGEXPORT.ONOPTIONCLICKED",",oparms:[{av:'Innewwindow1_Target',ctrl:'INNEWWINDOW1',prop:'Target'},{av:'Innewwindow1_Height',ctrl:'INNEWWINDOW1',prop:'Height'},{av:'Innewwindow1_Width',ctrl:'INNEWWINDOW1',prop:'Width'},{av:'AV13OrderedBy',fld:'vORDEREDBY',pic:'ZZZ9'},{av:'AV14OrderedDsc',fld:'vORDEREDDSC',pic:''},{av:'AV45TFHorario_Vigencia',fld:'vTFHORARIO_VIGENCIA',pic:'99/99/9999 99:99:99'},{av:'AV46TFHorario_Vigencia_To',fld:'vTFHORARIO_VIGENCIA_TO',pic:'99/99/9999 99:99:99'},{av:'AV47DDO_Horario_VigenciaAuxDate',fld:'vDDO_HORARIO_VIGENCIAAUXDATE',pic:''},{av:'AV48DDO_Horario_VigenciaAuxDateTo',fld:'vDDO_HORARIO_VIGENCIAAUXDATETO',pic:''},{av:'AV40TFHorario_Dia_Fin_01',fld:'vTFHORARIO_DIA_FIN_01',pic:'99:99'},{av:'AV41TFHorario_Dia_Fin_01_To',fld:'vTFHORARIO_DIA_FIN_01_TO',pic:'99:99'},{av:'AV42DDO_Horario_Dia_Fin_01AuxDate',fld:'vDDO_HORARIO_DIA_FIN_01AUXDATE',pic:''},{av:'AV43DDO_Horario_Dia_Fin_01AuxDateTo',fld:'vDDO_HORARIO_DIA_FIN_01AUXDATETO',pic:''},{av:'AV35TFHorario_Dia_Ini_01',fld:'vTFHORARIO_DIA_INI_01',pic:'99:99'},{av:'AV36TFHorario_Dia_Ini_01_To',fld:'vTFHORARIO_DIA_INI_01_TO',pic:'99:99'},{av:'AV37DDO_Horario_Dia_Ini_01AuxDate',fld:'vDDO_HORARIO_DIA_INI_01AUXDATE',pic:''},{av:'AV38DDO_Horario_Dia_Ini_01AuxDateTo',fld:'vDDO_HORARIO_DIA_INI_01AUXDATETO',pic:''},{av:'AV34TFHorario_Dsc_Sel',fld:'vTFHORARIO_DSC_SEL',pic:''},{av:'AV33TFHorario_Dsc',fld:'vTFHORARIO_DSC',pic:''},{av:'AV31TFHorario_ID',fld:'vTFHORARIO_ID',pic:'ZZZ9'},{av:'AV32TFHorario_ID_To',fld:'vTFHORARIO_ID_TO',pic:'ZZZ9'},{av:'Ddo_grid_Selectedvalue_set',ctrl:'DDO_GRID',prop:'SelectedValue_set'},{av:'Ddo_grid_Filteredtext_set',ctrl:'DDO_GRID',prop:'FilteredText_set'},{av:'Ddo_grid_Filteredtextto_set',ctrl:'DDO_GRID',prop:'FilteredTextTo_set'},{av:'subGrid_Rows',ctrl:'GRID',prop:'Rows'},{av:'GRID_nFirstRecordOnPage'},{av:'GRID_nEOF'},{av:'AV64Pgmname',fld:'vPGMNAME',pic:'',hsh:true},{av:'Ddo_grid_Sortedstatus',ctrl:'DDO_GRID',prop:'SortedStatus'}]}");
         setEventMetadata("NULL","{handler:'Valid_Horario_vigencia',iparms:[]");
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
         AV64Pgmname = "";
         AV33TFHorario_Dsc = "";
         AV34TFHorario_Dsc_Sel = "";
         AV35TFHorario_Dia_Ini_01 = (DateTime)(DateTime.MinValue);
         AV36TFHorario_Dia_Ini_01_To = (DateTime)(DateTime.MinValue);
         AV40TFHorario_Dia_Fin_01 = (DateTime)(DateTime.MinValue);
         AV41TFHorario_Dia_Fin_01_To = (DateTime)(DateTime.MinValue);
         AV45TFHorario_Vigencia = (DateTime)(DateTime.MinValue);
         AV46TFHorario_Vigencia_To = (DateTime)(DateTime.MinValue);
         sDynURL = "";
         FormProcess = "";
         bodyStyle = "";
         GXKey = "";
         AV56GridAppliedFilters = "";
         AV58AGExportData = new GXBaseCollection<GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTDropDownOptionsData_Item>( context, "Item", "");
         AV52DDO_TitleSettingsIcons = new GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTDropDownOptionsTitleSettingsIcons(context);
         AV38DDO_Horario_Dia_Ini_01AuxDateTo = DateTime.MinValue;
         AV43DDO_Horario_Dia_Fin_01AuxDateTo = DateTime.MinValue;
         AV48DDO_Horario_VigenciaAuxDateTo = DateTime.MinValue;
         AV37DDO_Horario_Dia_Ini_01AuxDate = DateTime.MinValue;
         AV42DDO_Horario_Dia_Fin_01AuxDate = DateTime.MinValue;
         AV47DDO_Horario_VigenciaAuxDate = DateTime.MinValue;
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
         A2433Horario_Dsc = "";
         A2434Horario_Dia_Ini_01 = (DateTime)(DateTime.MinValue);
         A2441Horario_Dia_Fin_01 = (DateTime)(DateTime.MinValue);
         A2462Horario_Vigencia = (DateTime)(DateTime.MinValue);
         ucGridpaginationbar = new GXUserControl();
         ucDdo_agexport = new GXUserControl();
         ucDdo_grid = new GXUserControl();
         ucInnewwindow1 = new GXUserControl();
         ucGrid_empowerer = new GXUserControl();
         AV39DDO_Horario_Dia_Ini_01AuxDateText = "";
         ucTfhorario_dia_ini_01_rangepicker = new GXUserControl();
         AV44DDO_Horario_Dia_Fin_01AuxDateText = "";
         ucTfhorario_dia_fin_01_rangepicker = new GXUserControl();
         AV49DDO_Horario_VigenciaAuxDateText = "";
         ucTfhorario_vigencia_rangepicker = new GXUserControl();
         sEvt = "";
         EvtGridId = "";
         EvtRowId = "";
         sEvtType = "";
         scmdbuf = "";
         lV67Reloj_interface_reloj_horariowwds_3_tfhorario_dsc = "";
         AV68Reloj_interface_reloj_horariowwds_4_tfhorario_dsc_sel = "";
         AV67Reloj_interface_reloj_horariowwds_3_tfhorario_dsc = "";
         AV69Reloj_interface_reloj_horariowwds_5_tfhorario_dia_ini_01 = (DateTime)(DateTime.MinValue);
         AV70Reloj_interface_reloj_horariowwds_6_tfhorario_dia_ini_01_to = (DateTime)(DateTime.MinValue);
         AV71Reloj_interface_reloj_horariowwds_7_tfhorario_dia_fin_01 = (DateTime)(DateTime.MinValue);
         AV72Reloj_interface_reloj_horariowwds_8_tfhorario_dia_fin_01_to = (DateTime)(DateTime.MinValue);
         AV73Reloj_interface_reloj_horariowwds_9_tfhorario_vigencia = (DateTime)(DateTime.MinValue);
         AV74Reloj_interface_reloj_horariowwds_10_tfhorario_vigencia_to = (DateTime)(DateTime.MinValue);
         H007D2_A2462Horario_Vigencia = new DateTime[] {DateTime.MinValue} ;
         H007D2_A2441Horario_Dia_Fin_01 = new DateTime[] {DateTime.MinValue} ;
         H007D2_A2434Horario_Dia_Ini_01 = new DateTime[] {DateTime.MinValue} ;
         H007D2_A2433Horario_Dsc = new string[] {""} ;
         H007D2_A2432Horario_ID = new short[1] ;
         H007D3_AGRID_nRecordCount = new long[1] ;
         AV59AGExportDataItem = new GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTDropDownOptionsData_Item(context);
         GXt_SdtDVB_SDTDropDownOptionsTitleSettingsIcons1 = new GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTDropDownOptionsTitleSettingsIcons(context);
         AV6WWPContext = new GeneXus.Programs.wwpbaseobjects.SdtWWPContext(context);
         GXEncryptionTmp = "";
         GridRow = new GXWebRow();
         AV30Session = context.GetSession();
         AV10GridState = new GeneXus.Programs.wwpbaseobjects.SdtWWPGridState(context);
         AV11GridStateFilterValue = new GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue(context);
         GXt_char2 = "";
         AV8TrnContext = new GeneXus.Programs.wwpbaseobjects.SdtWWPTransactionContext(context);
         AV7HTTPRequest = new GxHttpRequest( context);
         AV28ExcelFilename = "";
         AV29ErrorMessage = "";
         BackMsgLst = new msglist();
         LclMsgLst = new msglist();
         GXCCtl = "";
         ROClassString = "";
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.reloj_interface.reloj_horarioww__default(),
            new Object[][] {
                new Object[] {
               H007D2_A2462Horario_Vigencia, H007D2_A2441Horario_Dia_Fin_01, H007D2_A2434Horario_Dia_Ini_01, H007D2_A2433Horario_Dsc, H007D2_A2432Horario_ID
               }
               , new Object[] {
               H007D3_AGRID_nRecordCount
               }
            }
         );
         AV64Pgmname = "Reloj_Interface.Reloj_HorarioWW";
         /* GeneXus formulas. */
         AV64Pgmname = "Reloj_Interface.Reloj_HorarioWW";
         context.Gx_err = 0;
      }

      private short GRID_nEOF ;
      private short nGotPars ;
      private short GxWebError ;
      private short AV31TFHorario_ID ;
      private short AV32TFHorario_ID_To ;
      private short AV13OrderedBy ;
      private short initialized ;
      private short gxajaxcallmode ;
      private short wbEnd ;
      private short wbStart ;
      private short subGrid_Backcolorstyle ;
      private short subGrid_Titlebackstyle ;
      private short subGrid_Sortable ;
      private short AV57GridActions ;
      private short A2432Horario_ID ;
      private short subGrid_Allowselection ;
      private short subGrid_Allowhovering ;
      private short subGrid_Allowcollapsing ;
      private short subGrid_Collapsed ;
      private short nDonePA ;
      private short AV65Reloj_interface_reloj_horariowwds_1_tfhorario_id ;
      private short AV66Reloj_interface_reloj_horariowwds_2_tfhorario_id_to ;
      private short nGXWrapped ;
      private short subGrid_Backstyle ;
      private int subGrid_Rows ;
      private int Gridpaginationbar_Rowsperpageselectedvalue ;
      private int nRC_GXsfl_33 ;
      private int nGXsfl_33_idx=1 ;
      private int Gridpaginationbar_Pagestoshow ;
      private int subGrid_Titlebackcolor ;
      private int subGrid_Allbackcolor ;
      private int subGrid_Selectedindex ;
      private int subGrid_Selectioncolor ;
      private int subGrid_Hoveringcolor ;
      private int subGrid_Islastpage ;
      private int GXPagingFrom2 ;
      private int GXPagingTo2 ;
      private int AV53PageToGo ;
      private int AV75GXV1 ;
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
      private string sGXsfl_33_idx="0001" ;
      private string AV64Pgmname ;
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
      private string edtHorario_Dsc_Link ;
      private string Gridpaginationbar_Internalname ;
      private string divHtml_bottomauxiliarcontrols_Internalname ;
      private string Ddo_agexport_Internalname ;
      private string Ddo_grid_Internalname ;
      private string Innewwindow1_Internalname ;
      private string Grid_empowerer_Internalname ;
      private string divDdo_horario_dia_ini_01auxdates_Internalname ;
      private string edtavDdo_horario_dia_ini_01auxdatetext_Internalname ;
      private string edtavDdo_horario_dia_ini_01auxdatetext_Jsonclick ;
      private string Tfhorario_dia_ini_01_rangepicker_Internalname ;
      private string divDdo_horario_dia_fin_01auxdates_Internalname ;
      private string edtavDdo_horario_dia_fin_01auxdatetext_Internalname ;
      private string edtavDdo_horario_dia_fin_01auxdatetext_Jsonclick ;
      private string Tfhorario_dia_fin_01_rangepicker_Internalname ;
      private string divDdo_horario_vigenciaauxdates_Internalname ;
      private string edtavDdo_horario_vigenciaauxdatetext_Internalname ;
      private string edtavDdo_horario_vigenciaauxdatetext_Jsonclick ;
      private string Tfhorario_vigencia_rangepicker_Internalname ;
      private string sEvt ;
      private string EvtGridId ;
      private string EvtRowId ;
      private string sEvtType ;
      private string cmbavGridactions_Internalname ;
      private string edtHorario_ID_Internalname ;
      private string edtHorario_Dsc_Internalname ;
      private string edtHorario_Dia_Ini_01_Internalname ;
      private string edtHorario_Dia_Fin_01_Internalname ;
      private string edtHorario_Vigencia_Internalname ;
      private string scmdbuf ;
      private string GXEncryptionTmp ;
      private string GXt_char2 ;
      private string sGXsfl_33_fel_idx="0001" ;
      private string GXCCtl ;
      private string cmbavGridactions_Jsonclick ;
      private string ROClassString ;
      private string edtHorario_ID_Jsonclick ;
      private string edtHorario_Dsc_Jsonclick ;
      private string edtHorario_Dia_Ini_01_Jsonclick ;
      private string edtHorario_Dia_Fin_01_Jsonclick ;
      private string edtHorario_Vigencia_Jsonclick ;
      private DateTime AV35TFHorario_Dia_Ini_01 ;
      private DateTime AV36TFHorario_Dia_Ini_01_To ;
      private DateTime AV40TFHorario_Dia_Fin_01 ;
      private DateTime AV41TFHorario_Dia_Fin_01_To ;
      private DateTime AV45TFHorario_Vigencia ;
      private DateTime AV46TFHorario_Vigencia_To ;
      private DateTime A2434Horario_Dia_Ini_01 ;
      private DateTime A2441Horario_Dia_Fin_01 ;
      private DateTime A2462Horario_Vigencia ;
      private DateTime AV69Reloj_interface_reloj_horariowwds_5_tfhorario_dia_ini_01 ;
      private DateTime AV70Reloj_interface_reloj_horariowwds_6_tfhorario_dia_ini_01_to ;
      private DateTime AV71Reloj_interface_reloj_horariowwds_7_tfhorario_dia_fin_01 ;
      private DateTime AV72Reloj_interface_reloj_horariowwds_8_tfhorario_dia_fin_01_to ;
      private DateTime AV73Reloj_interface_reloj_horariowwds_9_tfhorario_vigencia ;
      private DateTime AV74Reloj_interface_reloj_horariowwds_10_tfhorario_vigencia_to ;
      private DateTime AV38DDO_Horario_Dia_Ini_01AuxDateTo ;
      private DateTime AV43DDO_Horario_Dia_Fin_01AuxDateTo ;
      private DateTime AV48DDO_Horario_VigenciaAuxDateTo ;
      private DateTime AV37DDO_Horario_Dia_Ini_01AuxDate ;
      private DateTime AV42DDO_Horario_Dia_Fin_01AuxDate ;
      private DateTime AV47DDO_Horario_VigenciaAuxDate ;
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
      private bool bGXsfl_33_Refreshing=false ;
      private bool gxdyncontrolsrefreshing ;
      private bool returnInSub ;
      private bool gx_refresh_fired ;
      private string AV33TFHorario_Dsc ;
      private string AV34TFHorario_Dsc_Sel ;
      private string AV56GridAppliedFilters ;
      private string A2433Horario_Dsc ;
      private string AV39DDO_Horario_Dia_Ini_01AuxDateText ;
      private string AV44DDO_Horario_Dia_Fin_01AuxDateText ;
      private string AV49DDO_Horario_VigenciaAuxDateText ;
      private string lV67Reloj_interface_reloj_horariowwds_3_tfhorario_dsc ;
      private string AV68Reloj_interface_reloj_horariowwds_4_tfhorario_dsc_sel ;
      private string AV67Reloj_interface_reloj_horariowwds_3_tfhorario_dsc ;
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
      private GXUserControl ucTfhorario_dia_ini_01_rangepicker ;
      private GXUserControl ucTfhorario_dia_fin_01_rangepicker ;
      private GXUserControl ucTfhorario_vigencia_rangepicker ;
      private IGxDataStore dsDataStore2 ;
      private IGxDataStore dsDefault ;
      private GXCombobox cmbavGridactions ;
      private IDataStoreProvider pr_default ;
      private DateTime[] H007D2_A2462Horario_Vigencia ;
      private DateTime[] H007D2_A2441Horario_Dia_Fin_01 ;
      private DateTime[] H007D2_A2434Horario_Dia_Ini_01 ;
      private string[] H007D2_A2433Horario_Dsc ;
      private short[] H007D2_A2432Horario_ID ;
      private long[] H007D3_AGRID_nRecordCount ;
      private msglist BackMsgLst ;
      private msglist LclMsgLst ;
      private GxHttpRequest AV7HTTPRequest ;
      private GXBaseCollection<GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTDropDownOptionsData_Item> AV58AGExportData ;
      private GXWebForm Form ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPContext AV6WWPContext ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPTransactionContext AV8TrnContext ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPGridState AV10GridState ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue AV11GridStateFilterValue ;
      private GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTDropDownOptionsTitleSettingsIcons AV52DDO_TitleSettingsIcons ;
      private GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTDropDownOptionsTitleSettingsIcons GXt_SdtDVB_SDTDropDownOptionsTitleSettingsIcons1 ;
      private GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTDropDownOptionsData_Item AV59AGExportDataItem ;
   }

   public class reloj_horarioww__default : DataStoreHelperBase, IDataStoreHelper
   {
      protected Object[] conditional_H007D2( IGxContext context ,
                                             short AV65Reloj_interface_reloj_horariowwds_1_tfhorario_id ,
                                             short AV66Reloj_interface_reloj_horariowwds_2_tfhorario_id_to ,
                                             string AV68Reloj_interface_reloj_horariowwds_4_tfhorario_dsc_sel ,
                                             string AV67Reloj_interface_reloj_horariowwds_3_tfhorario_dsc ,
                                             DateTime AV69Reloj_interface_reloj_horariowwds_5_tfhorario_dia_ini_01 ,
                                             DateTime AV70Reloj_interface_reloj_horariowwds_6_tfhorario_dia_ini_01_to ,
                                             DateTime AV71Reloj_interface_reloj_horariowwds_7_tfhorario_dia_fin_01 ,
                                             DateTime AV72Reloj_interface_reloj_horariowwds_8_tfhorario_dia_fin_01_to ,
                                             DateTime AV73Reloj_interface_reloj_horariowwds_9_tfhorario_vigencia ,
                                             DateTime AV74Reloj_interface_reloj_horariowwds_10_tfhorario_vigencia_to ,
                                             short A2432Horario_ID ,
                                             string A2433Horario_Dsc ,
                                             DateTime A2434Horario_Dia_Ini_01 ,
                                             DateTime A2441Horario_Dia_Fin_01 ,
                                             DateTime A2462Horario_Vigencia ,
                                             short AV13OrderedBy ,
                                             bool AV14OrderedDsc )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int3 = new short[13];
         Object[] GXv_Object4 = new Object[2];
         string sSelectString;
         string sFromString;
         string sOrderString;
         sSelectString = " [Horario_Vigencia], [Horario_Dia_Fin_01], [Horario_Dia_Ini_01], [Horario_Dsc], [Horario_ID]";
         sFromString = " FROM [Reloj_Horario]";
         sOrderString = "";
         if ( ! (0==AV65Reloj_interface_reloj_horariowwds_1_tfhorario_id) )
         {
            AddWhere(sWhereString, "([Horario_ID] >= @AV65Reloj_interface_reloj_horariowwds_1_tfhorario_id)");
         }
         else
         {
            GXv_int3[0] = 1;
         }
         if ( ! (0==AV66Reloj_interface_reloj_horariowwds_2_tfhorario_id_to) )
         {
            AddWhere(sWhereString, "([Horario_ID] <= @AV66Reloj_interface_reloj_horariowwds_2_tfhorario_id_to)");
         }
         else
         {
            GXv_int3[1] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV68Reloj_interface_reloj_horariowwds_4_tfhorario_dsc_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV67Reloj_interface_reloj_horariowwds_3_tfhorario_dsc)) ) )
         {
            AddWhere(sWhereString, "([Horario_Dsc] like @lV67Reloj_interface_reloj_horariowwds_3_tfhorario_dsc)");
         }
         else
         {
            GXv_int3[2] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV68Reloj_interface_reloj_horariowwds_4_tfhorario_dsc_sel)) )
         {
            AddWhere(sWhereString, "([Horario_Dsc] = @AV68Reloj_interface_reloj_horariowwds_4_tfhorario_dsc_sel)");
         }
         else
         {
            GXv_int3[3] = 1;
         }
         if ( ! (DateTime.MinValue==AV69Reloj_interface_reloj_horariowwds_5_tfhorario_dia_ini_01) )
         {
            AddWhere(sWhereString, "([Horario_Dia_Ini_01] >= @AV69Reloj_interface_reloj_horariowwds_5_tfhorario_dia_ini_01)");
         }
         else
         {
            GXv_int3[4] = 1;
         }
         if ( ! (DateTime.MinValue==AV70Reloj_interface_reloj_horariowwds_6_tfhorario_dia_ini_01_to) )
         {
            AddWhere(sWhereString, "([Horario_Dia_Ini_01] <= @AV70Reloj_interface_reloj_horariowwds_6_tfhorario_dia_ini_01_to)");
         }
         else
         {
            GXv_int3[5] = 1;
         }
         if ( ! (DateTime.MinValue==AV71Reloj_interface_reloj_horariowwds_7_tfhorario_dia_fin_01) )
         {
            AddWhere(sWhereString, "([Horario_Dia_Fin_01] >= @AV71Reloj_interface_reloj_horariowwds_7_tfhorario_dia_fin_01)");
         }
         else
         {
            GXv_int3[6] = 1;
         }
         if ( ! (DateTime.MinValue==AV72Reloj_interface_reloj_horariowwds_8_tfhorario_dia_fin_01_to) )
         {
            AddWhere(sWhereString, "([Horario_Dia_Fin_01] <= @AV72Reloj_interface_reloj_horariowwds_8_tfhorario_dia_fin_01_to)");
         }
         else
         {
            GXv_int3[7] = 1;
         }
         if ( ! (DateTime.MinValue==AV73Reloj_interface_reloj_horariowwds_9_tfhorario_vigencia) )
         {
            AddWhere(sWhereString, "([Horario_Vigencia] >= @AV73Reloj_interface_reloj_horariowwds_9_tfhorario_vigencia)");
         }
         else
         {
            GXv_int3[8] = 1;
         }
         if ( ! (DateTime.MinValue==AV74Reloj_interface_reloj_horariowwds_10_tfhorario_vigencia_to) )
         {
            AddWhere(sWhereString, "([Horario_Vigencia] <= @AV74Reloj_interface_reloj_horariowwds_10_tfhorario_vigencia_to)");
         }
         else
         {
            GXv_int3[9] = 1;
         }
         if ( ( AV13OrderedBy == 1 ) && ! AV14OrderedDsc )
         {
            sOrderString += " ORDER BY [Horario_ID]";
         }
         else if ( ( AV13OrderedBy == 1 ) && ( AV14OrderedDsc ) )
         {
            sOrderString += " ORDER BY [Horario_ID] DESC";
         }
         else if ( ( AV13OrderedBy == 2 ) && ! AV14OrderedDsc )
         {
            sOrderString += " ORDER BY [Horario_Dsc]";
         }
         else if ( ( AV13OrderedBy == 2 ) && ( AV14OrderedDsc ) )
         {
            sOrderString += " ORDER BY [Horario_Dsc] DESC";
         }
         else if ( ( AV13OrderedBy == 3 ) && ! AV14OrderedDsc )
         {
            sOrderString += " ORDER BY [Horario_Dia_Ini_01]";
         }
         else if ( ( AV13OrderedBy == 3 ) && ( AV14OrderedDsc ) )
         {
            sOrderString += " ORDER BY [Horario_Dia_Ini_01] DESC";
         }
         else if ( ( AV13OrderedBy == 4 ) && ! AV14OrderedDsc )
         {
            sOrderString += " ORDER BY [Horario_Dia_Fin_01]";
         }
         else if ( ( AV13OrderedBy == 4 ) && ( AV14OrderedDsc ) )
         {
            sOrderString += " ORDER BY [Horario_Dia_Fin_01] DESC";
         }
         else if ( ( AV13OrderedBy == 5 ) && ! AV14OrderedDsc )
         {
            sOrderString += " ORDER BY [Horario_Vigencia]";
         }
         else if ( ( AV13OrderedBy == 5 ) && ( AV14OrderedDsc ) )
         {
            sOrderString += " ORDER BY [Horario_Vigencia] DESC";
         }
         else if ( true )
         {
            sOrderString += " ORDER BY [Horario_ID]";
         }
         scmdbuf = "SELECT " + sSelectString + sFromString + sWhereString + sOrderString + "" + " OFFSET " + "@GXPagingFrom2" + " ROWS FETCH NEXT CAST((SELECT CASE WHEN " + "@GXPagingTo2" + " > 0 THEN " + "@GXPagingTo2" + " ELSE 1e9 END) AS INTEGER) ROWS ONLY";
         GXv_Object4[0] = scmdbuf;
         GXv_Object4[1] = GXv_int3;
         return GXv_Object4 ;
      }

      protected Object[] conditional_H007D3( IGxContext context ,
                                             short AV65Reloj_interface_reloj_horariowwds_1_tfhorario_id ,
                                             short AV66Reloj_interface_reloj_horariowwds_2_tfhorario_id_to ,
                                             string AV68Reloj_interface_reloj_horariowwds_4_tfhorario_dsc_sel ,
                                             string AV67Reloj_interface_reloj_horariowwds_3_tfhorario_dsc ,
                                             DateTime AV69Reloj_interface_reloj_horariowwds_5_tfhorario_dia_ini_01 ,
                                             DateTime AV70Reloj_interface_reloj_horariowwds_6_tfhorario_dia_ini_01_to ,
                                             DateTime AV71Reloj_interface_reloj_horariowwds_7_tfhorario_dia_fin_01 ,
                                             DateTime AV72Reloj_interface_reloj_horariowwds_8_tfhorario_dia_fin_01_to ,
                                             DateTime AV73Reloj_interface_reloj_horariowwds_9_tfhorario_vigencia ,
                                             DateTime AV74Reloj_interface_reloj_horariowwds_10_tfhorario_vigencia_to ,
                                             short A2432Horario_ID ,
                                             string A2433Horario_Dsc ,
                                             DateTime A2434Horario_Dia_Ini_01 ,
                                             DateTime A2441Horario_Dia_Fin_01 ,
                                             DateTime A2462Horario_Vigencia ,
                                             short AV13OrderedBy ,
                                             bool AV14OrderedDsc )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int5 = new short[10];
         Object[] GXv_Object6 = new Object[2];
         scmdbuf = "SELECT COUNT(*) FROM [Reloj_Horario]";
         if ( ! (0==AV65Reloj_interface_reloj_horariowwds_1_tfhorario_id) )
         {
            AddWhere(sWhereString, "([Horario_ID] >= @AV65Reloj_interface_reloj_horariowwds_1_tfhorario_id)");
         }
         else
         {
            GXv_int5[0] = 1;
         }
         if ( ! (0==AV66Reloj_interface_reloj_horariowwds_2_tfhorario_id_to) )
         {
            AddWhere(sWhereString, "([Horario_ID] <= @AV66Reloj_interface_reloj_horariowwds_2_tfhorario_id_to)");
         }
         else
         {
            GXv_int5[1] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV68Reloj_interface_reloj_horariowwds_4_tfhorario_dsc_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV67Reloj_interface_reloj_horariowwds_3_tfhorario_dsc)) ) )
         {
            AddWhere(sWhereString, "([Horario_Dsc] like @lV67Reloj_interface_reloj_horariowwds_3_tfhorario_dsc)");
         }
         else
         {
            GXv_int5[2] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV68Reloj_interface_reloj_horariowwds_4_tfhorario_dsc_sel)) )
         {
            AddWhere(sWhereString, "([Horario_Dsc] = @AV68Reloj_interface_reloj_horariowwds_4_tfhorario_dsc_sel)");
         }
         else
         {
            GXv_int5[3] = 1;
         }
         if ( ! (DateTime.MinValue==AV69Reloj_interface_reloj_horariowwds_5_tfhorario_dia_ini_01) )
         {
            AddWhere(sWhereString, "([Horario_Dia_Ini_01] >= @AV69Reloj_interface_reloj_horariowwds_5_tfhorario_dia_ini_01)");
         }
         else
         {
            GXv_int5[4] = 1;
         }
         if ( ! (DateTime.MinValue==AV70Reloj_interface_reloj_horariowwds_6_tfhorario_dia_ini_01_to) )
         {
            AddWhere(sWhereString, "([Horario_Dia_Ini_01] <= @AV70Reloj_interface_reloj_horariowwds_6_tfhorario_dia_ini_01_to)");
         }
         else
         {
            GXv_int5[5] = 1;
         }
         if ( ! (DateTime.MinValue==AV71Reloj_interface_reloj_horariowwds_7_tfhorario_dia_fin_01) )
         {
            AddWhere(sWhereString, "([Horario_Dia_Fin_01] >= @AV71Reloj_interface_reloj_horariowwds_7_tfhorario_dia_fin_01)");
         }
         else
         {
            GXv_int5[6] = 1;
         }
         if ( ! (DateTime.MinValue==AV72Reloj_interface_reloj_horariowwds_8_tfhorario_dia_fin_01_to) )
         {
            AddWhere(sWhereString, "([Horario_Dia_Fin_01] <= @AV72Reloj_interface_reloj_horariowwds_8_tfhorario_dia_fin_01_to)");
         }
         else
         {
            GXv_int5[7] = 1;
         }
         if ( ! (DateTime.MinValue==AV73Reloj_interface_reloj_horariowwds_9_tfhorario_vigencia) )
         {
            AddWhere(sWhereString, "([Horario_Vigencia] >= @AV73Reloj_interface_reloj_horariowwds_9_tfhorario_vigencia)");
         }
         else
         {
            GXv_int5[8] = 1;
         }
         if ( ! (DateTime.MinValue==AV74Reloj_interface_reloj_horariowwds_10_tfhorario_vigencia_to) )
         {
            AddWhere(sWhereString, "([Horario_Vigencia] <= @AV74Reloj_interface_reloj_horariowwds_10_tfhorario_vigencia_to)");
         }
         else
         {
            GXv_int5[9] = 1;
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
                     return conditional_H007D2(context, (short)dynConstraints[0] , (short)dynConstraints[1] , (string)dynConstraints[2] , (string)dynConstraints[3] , (DateTime)dynConstraints[4] , (DateTime)dynConstraints[5] , (DateTime)dynConstraints[6] , (DateTime)dynConstraints[7] , (DateTime)dynConstraints[8] , (DateTime)dynConstraints[9] , (short)dynConstraints[10] , (string)dynConstraints[11] , (DateTime)dynConstraints[12] , (DateTime)dynConstraints[13] , (DateTime)dynConstraints[14] , (short)dynConstraints[15] , (bool)dynConstraints[16] );
               case 1 :
                     return conditional_H007D3(context, (short)dynConstraints[0] , (short)dynConstraints[1] , (string)dynConstraints[2] , (string)dynConstraints[3] , (DateTime)dynConstraints[4] , (DateTime)dynConstraints[5] , (DateTime)dynConstraints[6] , (DateTime)dynConstraints[7] , (DateTime)dynConstraints[8] , (DateTime)dynConstraints[9] , (short)dynConstraints[10] , (string)dynConstraints[11] , (DateTime)dynConstraints[12] , (DateTime)dynConstraints[13] , (DateTime)dynConstraints[14] , (short)dynConstraints[15] , (bool)dynConstraints[16] );
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
          Object[] prmH007D2;
          prmH007D2 = new Object[] {
          new ParDef("@AV65Reloj_interface_reloj_horariowwds_1_tfhorario_id",GXType.Int16,4,0) ,
          new ParDef("@AV66Reloj_interface_reloj_horariowwds_2_tfhorario_id_to",GXType.Int16,4,0) ,
          new ParDef("@lV67Reloj_interface_reloj_horariowwds_3_tfhorario_dsc",GXType.NVarChar,100,5) ,
          new ParDef("@AV68Reloj_interface_reloj_horariowwds_4_tfhorario_dsc_sel",GXType.NVarChar,100,5) ,
          new ParDef("@AV69Reloj_interface_reloj_horariowwds_5_tfhorario_dia_ini_01",GXType.DateTime,0,5) ,
          new ParDef("@AV70Reloj_interface_reloj_horariowwds_6_tfhorario_dia_ini_01_to",GXType.DateTime,0,5) ,
          new ParDef("@AV71Reloj_interface_reloj_horariowwds_7_tfhorario_dia_fin_01",GXType.DateTime,0,5) ,
          new ParDef("@AV72Reloj_interface_reloj_horariowwds_8_tfhorario_dia_fin_01_to",GXType.DateTime,0,5) ,
          new ParDef("@AV73Reloj_interface_reloj_horariowwds_9_tfhorario_vigencia",GXType.DateTime,10,8) ,
          new ParDef("@AV74Reloj_interface_reloj_horariowwds_10_tfhorario_vigencia_to",GXType.DateTime,10,8) ,
          new ParDef("@GXPagingFrom2",GXType.Int32,9,0) ,
          new ParDef("@GXPagingTo2",GXType.Int32,9,0) ,
          new ParDef("@GXPagingTo2",GXType.Int32,9,0)
          };
          Object[] prmH007D3;
          prmH007D3 = new Object[] {
          new ParDef("@AV65Reloj_interface_reloj_horariowwds_1_tfhorario_id",GXType.Int16,4,0) ,
          new ParDef("@AV66Reloj_interface_reloj_horariowwds_2_tfhorario_id_to",GXType.Int16,4,0) ,
          new ParDef("@lV67Reloj_interface_reloj_horariowwds_3_tfhorario_dsc",GXType.NVarChar,100,5) ,
          new ParDef("@AV68Reloj_interface_reloj_horariowwds_4_tfhorario_dsc_sel",GXType.NVarChar,100,5) ,
          new ParDef("@AV69Reloj_interface_reloj_horariowwds_5_tfhorario_dia_ini_01",GXType.DateTime,0,5) ,
          new ParDef("@AV70Reloj_interface_reloj_horariowwds_6_tfhorario_dia_ini_01_to",GXType.DateTime,0,5) ,
          new ParDef("@AV71Reloj_interface_reloj_horariowwds_7_tfhorario_dia_fin_01",GXType.DateTime,0,5) ,
          new ParDef("@AV72Reloj_interface_reloj_horariowwds_8_tfhorario_dia_fin_01_to",GXType.DateTime,0,5) ,
          new ParDef("@AV73Reloj_interface_reloj_horariowwds_9_tfhorario_vigencia",GXType.DateTime,10,8) ,
          new ParDef("@AV74Reloj_interface_reloj_horariowwds_10_tfhorario_vigencia_to",GXType.DateTime,10,8)
          };
          def= new CursorDef[] {
              new CursorDef("H007D2", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH007D2,11, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("H007D3", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH007D3,1, GxCacheFrequency.OFF ,true,false )
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
                ((DateTime[]) buf[0])[0] = rslt.getGXDateTime(1);
                ((DateTime[]) buf[1])[0] = rslt.getGXDateTime(2);
                ((DateTime[]) buf[2])[0] = rslt.getGXDateTime(3);
                ((string[]) buf[3])[0] = rslt.getVarchar(4);
                ((short[]) buf[4])[0] = rslt.getShort(5);
                return;
             case 1 :
                ((long[]) buf[0])[0] = rslt.getLong(1);
                return;
       }
    }

 }

}
