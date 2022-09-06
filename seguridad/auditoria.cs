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
   public class auditoria : GXDataArea
   {
      public auditoria( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDataStore2 = context.GetDataStore("DataStore2");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusTheme");
      }

      public auditoria( IGxContext context )
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
         dynavUsucod = new GXCombobox();
         cmbavSgaumod = new GXCombobox();
         cmbavSgaufechoperator = new GXCombobox();
         cmbSGAuMod = new GXCombobox();
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
            else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxCallCrl"+"_"+"vUSUCOD") == 0 )
            {
               setAjaxCallMode();
               if ( ! IsValidAjaxCall( true) )
               {
                  GxWebError = 1;
                  return  ;
               }
               GXDLVvUSUCOD0I2( ) ;
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
               nRC_GXsfl_57 = (int)(NumberUtil.Val( GetPar( "nRC_GXsfl_57"), "."));
               nGXsfl_57_idx = (int)(NumberUtil.Val( GetPar( "nGXsfl_57_idx"), "."));
               sGXsfl_57_idx = GetPar( "sGXsfl_57_idx");
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
               dynavUsucod.FromJSonString( GetNextPar( ));
               AV68UsuCod = GetPar( "UsuCod");
               cmbavSgaumod.FromJSonString( GetNextPar( ));
               AV40SGAuMod = GetPar( "SGAuMod");
               cmbavSgaufechoperator.FromJSonString( GetNextPar( ));
               AV39SGAuFechOperator = (short)(NumberUtil.Val( GetPar( "SGAuFechOperator"), "."));
               AV36SGAuFech = context.localUtil.ParseDateParm( GetPar( "SGAuFech"));
               AV73Pgmname = GetPar( "Pgmname");
               AV34SGAuDocGls = GetPar( "SGAuDocGls");
               AV38SGAuFech_To = context.localUtil.ParseDateParm( GetPar( "SGAuFech_To"));
               ajax_req_read_hidden_sdt(GetNextPar( ), AV70TFSGAuMod_Sels);
               AV55TFSGAuFecha = context.localUtil.ParseDTimeParm( GetPar( "TFSGAuFecha"));
               AV56TFSGAuFecha_To = context.localUtil.ParseDTimeParm( GetPar( "TFSGAuFecha_To"));
               AV47TFSGAuDocGls = GetPar( "TFSGAuDocGls");
               AV48TFSGAuDocGls_Sel = GetPar( "TFSGAuDocGls_Sel");
               AV49TFSGAuDocNum = GetPar( "TFSGAuDocNum");
               AV50TFSGAuDocNum_Sel = GetPar( "TFSGAuDocNum_Sel");
               AV51TFSGAuDocRef = GetPar( "TFSGAuDocRef");
               AV52TFSGAuDocRef_Sel = GetPar( "TFSGAuDocRef_Sel");
               AV59TFSGAuTipCod = GetPar( "TFSGAuTipCod");
               AV60TFSGAuTipCod_Sel = GetPar( "TFSGAuTipCod_Sel");
               AV61TFSGAuTipo = GetPar( "TFSGAuTipo");
               AV62TFSGAuTipo_Sel = GetPar( "TFSGAuTipo_Sel");
               AV63TFSGAuUsuCod = GetPar( "TFSGAuUsuCod");
               AV64TFSGAuUsuCod_Sel = GetPar( "TFSGAuUsuCod_Sel");
               AV30OrderedBy = (short)(NumberUtil.Val( GetPar( "OrderedBy"), "."));
               AV31OrderedDsc = StringUtil.StrToBool( GetPar( "OrderedDsc"));
               Gx_date = context.localUtil.ParseDateParm( GetPar( "Gx_date"));
               setAjaxCallMode();
               if ( ! IsValidAjaxCall( true) )
               {
                  GxWebError = 1;
                  return  ;
               }
               gxgrGrid_refresh( subGrid_Rows, AV68UsuCod, AV40SGAuMod, AV39SGAuFechOperator, AV36SGAuFech, AV73Pgmname, AV34SGAuDocGls, AV38SGAuFech_To, AV70TFSGAuMod_Sels, AV55TFSGAuFecha, AV56TFSGAuFecha_To, AV47TFSGAuDocGls, AV48TFSGAuDocGls_Sel, AV49TFSGAuDocNum, AV50TFSGAuDocNum_Sel, AV51TFSGAuDocRef, AV52TFSGAuDocRef_Sel, AV59TFSGAuTipCod, AV60TFSGAuTipCod_Sel, AV61TFSGAuTipo, AV62TFSGAuTipo_Sel, AV63TFSGAuUsuCod, AV64TFSGAuUsuCod_Sel, AV30OrderedBy, AV31OrderedDsc, Gx_date) ;
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
         PA0I2( ) ;
         gxajaxcallmode = (short)((isAjaxCallMode( ) ? 1 : 0));
         if ( ( gxajaxcallmode == 0 ) && ( GxWebError == 0 ) )
         {
            START0I2( ) ;
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
         context.AddJavascriptSource("gxcfg.js", "?20228181027580", false, true);
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
         context.AddJavascriptSource("DVelop/Shared/daterangepicker/locales.js", "", false, true);
         context.AddJavascriptSource("DVelop/Shared/daterangepicker/wwp-daterangepicker.js", "", false, true);
         context.AddJavascriptSource("DVelop/Shared/daterangepicker/moment.min.js", "", false, true);
         context.AddJavascriptSource("DVelop/Shared/daterangepicker/daterangepicker.min.js", "", false, true);
         context.AddJavascriptSource("DVelop/Shared/WorkWithPlusCommon.js", "", false, true);
         context.AddJavascriptSource("DVelop/DateRangePicker/DateRangePickerRender.js", "", false, true);
         context.AddJavascriptSource("DVelop/Bootstrap/Shared/DVelopBootstrap.js", "", false, true);
         context.AddJavascriptSource("DVelop/Shared/WorkWithPlusCommon.js", "", false, true);
         context.AddJavascriptSource("DVelop/Bootstrap/DropDownOptions/BootstrapDropDownOptionsRender.js", "", false, true);
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
         context.WriteHtmlTextNl( "<form id=\"MAINFORM\" autocomplete=\"off\" name=\"MAINFORM\" method=\"post\" tabindex=-1  class=\"form-horizontal Form\" data-gx-class=\"form-horizontal Form\" novalidate action=\""+formatLink("seguridad.auditoria.aspx") +"\">") ;
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
         GxWebStd.gx_hidden_field( context, "gxhash_vPGMNAME", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( AV73Pgmname, "")), context));
         GxWebStd.gx_hidden_field( context, "gxhash_vTODAY", GetSecureSignedToken( "", Gx_date, context));
         GXKey = Crypto.GetSiteKey( );
      }

      protected void SendCloseFormHiddens( )
      {
         /* Send hidden variables. */
         GxWebStd.gx_hidden_field( context, "GXH_vUSUCOD", StringUtil.RTrim( AV68UsuCod));
         GxWebStd.gx_hidden_field( context, "GXH_vSGAUMOD", AV40SGAuMod);
         GxWebStd.gx_hidden_field( context, "GXH_vSGAUFECHOPERATOR", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV39SGAuFechOperator), 4, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "GXH_vSGAUFECH", context.localUtil.Format(AV36SGAuFech, "99/99/99"));
         /* Send saved values. */
         send_integrity_footer_hashes( ) ;
         GxWebStd.gx_hidden_field( context, "nRC_GXsfl_57", StringUtil.LTrim( StringUtil.NToC( (decimal)(nRC_GXsfl_57), 8, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "vGRIDCURRENTPAGE", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV23GridCurrentPage), 10, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "vGRIDPAGECOUNT", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV24GridPageCount), 10, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "vGRIDAPPLIEDFILTERS", AV22GridAppliedFilters);
         GxWebStd.gx_hidden_field( context, "vSGAUFECH_TO", context.localUtil.DToC( AV38SGAuFech_To, 0, "/"));
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "vDDO_TITLESETTINGSICONS", AV11DDO_TitleSettingsIcons);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt("vDDO_TITLESETTINGSICONS", AV11DDO_TitleSettingsIcons);
         }
         GxWebStd.gx_hidden_field( context, "vDDO_SGAUFECHAAUXDATETO", context.localUtil.DToC( AV7DDO_SGAuFechaAuxDateTo, 0, "/"));
         GxWebStd.gx_hidden_field( context, "vPGMNAME", StringUtil.RTrim( AV73Pgmname));
         GxWebStd.gx_hidden_field( context, "gxhash_vPGMNAME", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( AV73Pgmname, "")), context));
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "vTFSGAUMOD_SELS", AV70TFSGAuMod_Sels);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt("vTFSGAUMOD_SELS", AV70TFSGAuMod_Sels);
         }
         GxWebStd.gx_hidden_field( context, "vTFSGAUFECHA", context.localUtil.TToC( AV55TFSGAuFecha, 10, 8, 0, 0, "/", ":", " "));
         GxWebStd.gx_hidden_field( context, "vTFSGAUFECHA_TO", context.localUtil.TToC( AV56TFSGAuFecha_To, 10, 8, 0, 0, "/", ":", " "));
         GxWebStd.gx_hidden_field( context, "vTFSGAUDOCGLS", AV47TFSGAuDocGls);
         GxWebStd.gx_hidden_field( context, "vTFSGAUDOCGLS_SEL", AV48TFSGAuDocGls_Sel);
         GxWebStd.gx_hidden_field( context, "vTFSGAUDOCNUM", AV49TFSGAuDocNum);
         GxWebStd.gx_hidden_field( context, "vTFSGAUDOCNUM_SEL", AV50TFSGAuDocNum_Sel);
         GxWebStd.gx_hidden_field( context, "vTFSGAUDOCREF", AV51TFSGAuDocRef);
         GxWebStd.gx_hidden_field( context, "vTFSGAUDOCREF_SEL", AV52TFSGAuDocRef_Sel);
         GxWebStd.gx_hidden_field( context, "vTFSGAUTIPCOD", AV59TFSGAuTipCod);
         GxWebStd.gx_hidden_field( context, "vTFSGAUTIPCOD_SEL", AV60TFSGAuTipCod_Sel);
         GxWebStd.gx_hidden_field( context, "vTFSGAUTIPO", AV61TFSGAuTipo);
         GxWebStd.gx_hidden_field( context, "vTFSGAUTIPO_SEL", AV62TFSGAuTipo_Sel);
         GxWebStd.gx_hidden_field( context, "vTFSGAUUSUCOD", AV63TFSGAuUsuCod);
         GxWebStd.gx_hidden_field( context, "vTFSGAUUSUCOD_SEL", AV64TFSGAuUsuCod_Sel);
         GxWebStd.gx_hidden_field( context, "vORDEREDBY", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV30OrderedBy), 4, 0, ".", "")));
         GxWebStd.gx_boolean_hidden_field( context, "vORDEREDDSC", AV31OrderedDsc);
         GxWebStd.gx_hidden_field( context, "vTODAY", context.localUtil.DToC( Gx_date, 0, "/"));
         GxWebStd.gx_hidden_field( context, "gxhash_vTODAY", GetSecureSignedToken( "", Gx_date, context));
         GxWebStd.gx_hidden_field( context, "GRID_nFirstRecordOnPage", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRID_nFirstRecordOnPage), 15, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "GRID_nEOF", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRID_nEOF), 1, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "vSGAUFECH", context.localUtil.DToC( AV36SGAuFech, 0, "/"));
         GxWebStd.gx_hidden_field( context, "vDDO_SGAUFECHAAUXDATE", context.localUtil.DToC( AV5DDO_SGAuFechaAuxDate, 0, "/"));
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
         GxWebStd.gx_hidden_field( context, "GRID_Rows", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid_Rows), 6, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "GRIDPAGINATIONBAR_Selectedpage", StringUtil.RTrim( Gridpaginationbar_Selectedpage));
         GxWebStd.gx_hidden_field( context, "GRIDPAGINATIONBAR_Rowsperpageselectedvalue", StringUtil.LTrim( StringUtil.NToC( (decimal)(Gridpaginationbar_Rowsperpageselectedvalue), 9, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "DDO_GRID_Activeeventkey", StringUtil.RTrim( Ddo_grid_Activeeventkey));
         GxWebStd.gx_hidden_field( context, "DDO_GRID_Selectedvalue_get", StringUtil.RTrim( Ddo_grid_Selectedvalue_get));
         GxWebStd.gx_hidden_field( context, "DDO_GRID_Filteredtextto_get", StringUtil.RTrim( Ddo_grid_Filteredtextto_get));
         GxWebStd.gx_hidden_field( context, "DDO_GRID_Filteredtext_get", StringUtil.RTrim( Ddo_grid_Filteredtext_get));
         GxWebStd.gx_hidden_field( context, "DDO_GRID_Selectedcolumn", StringUtil.RTrim( Ddo_grid_Selectedcolumn));
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
            WE0I2( ) ;
            context.WriteHtmlText( "</div>") ;
         }
      }

      public override void DispatchEvents( )
      {
         EVT0I2( ) ;
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
         return formatLink("seguridad.auditoria.aspx")  ;
      }

      public override string GetPgmname( )
      {
         return "Seguridad.Auditoria" ;
      }

      public override string GetPgmdesc( )
      {
         return "Auditoria" ;
      }

      protected void WB0I0( )
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
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "", "left", "top", "", "flex-grow:1;", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divTablafiltros_Internalname, 1, 0, "px", 0, "px", "", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-6 DataContentCell", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+dynavUsucod_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, dynavUsucod_Internalname, "Usuario", "col-sm-3 AttributeLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 22,'',false,'" + sGXsfl_57_idx + "',0)\"";
            /* ComboBox */
            GxWebStd.gx_combobox_ctrl1( context, dynavUsucod, dynavUsucod_Internalname, StringUtil.RTrim( AV68UsuCod), 1, dynavUsucod_Jsonclick, 0, "'"+""+"'"+",false,"+"'"+""+"'", "char", "", 1, dynavUsucod.Enabled, 0, 0, 0, "em", 0, "", "", "Attribute", "", "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,22);\"", "", true, 1, "HLP_Seguridad\\Auditoria.htm");
            dynavUsucod.CurrentValue = StringUtil.RTrim( AV68UsuCod);
            AssignProp("", false, dynavUsucod_Internalname, "Values", (string)(dynavUsucod.ToJavascriptSource()), true);
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-6 DataContentCell", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+cmbavSgaumod_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, cmbavSgaumod_Internalname, "Modulo", "col-sm-3 AttributeLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 26,'',false,'" + sGXsfl_57_idx + "',0)\"";
            /* ComboBox */
            GxWebStd.gx_combobox_ctrl1( context, cmbavSgaumod, cmbavSgaumod_Internalname, StringUtil.RTrim( AV40SGAuMod), 1, cmbavSgaumod_Jsonclick, 0, "'"+""+"'"+",false,"+"'"+""+"'", "svchar", "", 1, cmbavSgaumod.Enabled, 0, 0, 0, "em", 0, "", "", "Attribute", "", "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,26);\"", "", true, 1, "HLP_Seguridad\\Auditoria.htm");
            cmbavSgaumod.CurrentValue = StringUtil.RTrim( AV40SGAuMod);
            AssignProp("", false, cmbavSgaumod_Internalname, "Values", (string)(cmbavSgaumod.ToJavascriptSource()), true);
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-6 DataContentCell", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtavSgaudocgls_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavSgaudocgls_Internalname, "Glosa", "col-sm-3 AttributeRealWidthLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 31,'',false,'" + sGXsfl_57_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavSgaudocgls_Internalname, AV34SGAuDocGls, StringUtil.RTrim( context.localUtil.Format( AV34SGAuDocGls, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,31);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavSgaudocgls_Jsonclick, 0, "AttributeRealWidth", "", "", "", "", 1, edtavSgaudocgls_Enabled, 0, "text", "", 80, "chr", 1, "row", 100, 0, 0, 0, 1, -1, -1, true, "", "left", true, "", "HLP_Seguridad\\Auditoria.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-6 DataContentCell", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divTablesplittedfiltertextsgaufech_Internalname, 1, 0, "px", 0, "px", "Table", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-3 MergeLabelCell", "left", "top", "", "", "div");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblFiltertextsgaufech_Internalname, "Fecha", "", "", lblFiltertextsgaufech_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "DataFilterDescription", 0, "", 1, 1, 0, 0, "HLP_Seguridad\\Auditoria.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-9", "left", "top", "", "", "div");
            wb_table1_38_0I2( true) ;
         }
         else
         {
            wb_table1_38_0I2( false) ;
         }
         return  ;
      }

      protected void wb_table1_38_0I2e( bool wbgen )
      {
         if ( wbgen )
         {
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
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
               context.WriteHtmlText( "<div id=\""+"GridContainer"+"DivS\" data-gxgridid=\"57\">") ;
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
               context.WriteHtmlText( "<th align=\""+"left"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+""+""+"\" "+">") ;
               context.SendWebValue( "Modulo") ;
               context.WriteHtmlTextNl( "</th>") ;
               context.WriteHtmlText( "<th align=\""+"right"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+""+""+"\" "+">") ;
               context.SendWebValue( "Fecha Hora") ;
               context.WriteHtmlTextNl( "</th>") ;
               context.WriteHtmlText( "<th align=\""+"left"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+""+""+"\" "+">") ;
               context.SendWebValue( "Glosa") ;
               context.WriteHtmlTextNl( "</th>") ;
               context.WriteHtmlText( "<th align=\""+"left"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+""+""+"\" "+">") ;
               context.SendWebValue( "N° Documento") ;
               context.WriteHtmlTextNl( "</th>") ;
               context.WriteHtmlText( "<th align=\""+"left"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+""+""+"\" "+">") ;
               context.SendWebValue( "Doc.Referencia") ;
               context.WriteHtmlTextNl( "</th>") ;
               context.WriteHtmlText( "<th align=\""+"left"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+""+""+"\" "+">") ;
               context.SendWebValue( "Tipo Documento") ;
               context.WriteHtmlTextNl( "</th>") ;
               context.WriteHtmlText( "<th align=\""+"left"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+""+""+"\" "+">") ;
               context.SendWebValue( "Tipo") ;
               context.WriteHtmlTextNl( "</th>") ;
               context.WriteHtmlText( "<th align=\""+"left"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+""+""+"\" "+">") ;
               context.SendWebValue( "Usuario") ;
               context.WriteHtmlTextNl( "</th>") ;
               context.WriteHtmlText( "<th align=\""+"right"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+"display:none;"+""+"\" "+">") ;
               context.SendWebValue( "Fecha") ;
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
               GridColumn.AddObjectProperty("Value", A337SGAuMod);
               GridContainer.AddColumnProperties(GridColumn);
               GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
               GridColumn.AddObjectProperty("Value", context.localUtil.TToC( A338SGAuFecha, 10, 8, 0, 3, "/", ":", " "));
               GridContainer.AddColumnProperties(GridColumn);
               GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
               GridColumn.AddObjectProperty("Value", A1843SGAuDocGls);
               GridContainer.AddColumnProperties(GridColumn);
               GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
               GridColumn.AddObjectProperty("Value", A1844SGAuDocNum);
               GridContainer.AddColumnProperties(GridColumn);
               GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
               GridColumn.AddObjectProperty("Value", A1845SGAuDocRef);
               GridContainer.AddColumnProperties(GridColumn);
               GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
               GridColumn.AddObjectProperty("Value", A1847SGAuTipCod);
               GridContainer.AddColumnProperties(GridColumn);
               GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
               GridColumn.AddObjectProperty("Value", A1848SGAuTipo);
               GridContainer.AddColumnProperties(GridColumn);
               GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
               GridColumn.AddObjectProperty("Value", A1849SGAuUsuCod);
               GridContainer.AddColumnProperties(GridColumn);
               GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
               GridColumn.AddObjectProperty("Value", context.localUtil.Format(A1846SGAuFech, "99/99/99"));
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
         if ( wbEnd == 57 )
         {
            wbEnd = 0;
            nRC_GXsfl_57 = (int)(nGXsfl_57_idx-1);
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
            ucGridpaginationbar.SetProperty("CurrentPage", AV23GridCurrentPage);
            ucGridpaginationbar.SetProperty("PageCount", AV24GridPageCount);
            ucGridpaginationbar.SetProperty("AppliedFilters", AV22GridAppliedFilters);
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
            ucSgaufech_rangepicker.SetProperty("Start Date", AV36SGAuFech);
            ucSgaufech_rangepicker.SetProperty("End Date", AV38SGAuFech_To);
            ucSgaufech_rangepicker.Render(context, "wwp.daterangepicker", Sgaufech_rangepicker_Internalname, "SGAUFECH_RANGEPICKERContainer");
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
            ucDdo_grid.SetProperty("DropDownOptionsTitleSettingsIcons", AV11DDO_TitleSettingsIcons);
            ucDdo_grid.Render(context, "dvelop.gxbootstrap.ddogridtitlesettingsm", Ddo_grid_Internalname, "DDO_GRIDContainer");
            /* User Defined Control */
            ucGrid_empowerer.SetProperty("HasTitleSettings", Grid_empowerer_Hastitlesettings);
            ucGrid_empowerer.Render(context, "wwp.gridempowerer", Grid_empowerer_Internalname, "GRID_EMPOWERERContainer");
            /* Div Control */
            GxWebStd.gx_div_start( context, divDdo_sgaufechaauxdates_Internalname, 1, 0, "px", 0, "px", "Invisible", "left", "top", "", "", "div");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 77,'',false,'" + sGXsfl_57_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavDdo_sgaufechaauxdatetext_Internalname, AV6DDO_SGAuFechaAuxDateText, StringUtil.RTrim( context.localUtil.Format( AV6DDO_SGAuFechaAuxDateText, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,77);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavDdo_sgaufechaauxdatetext_Jsonclick, 0, "Attribute", "", "", "", "", 1, 1, 0, "text", "", 40, "chr", 1, "row", 40, 0, 0, 0, 1, -1, -1, true, "", "left", true, "", "HLP_Seguridad\\Auditoria.htm");
            /* User Defined Control */
            ucTfsgaufecha_rangepicker.SetProperty("Start Date", AV5DDO_SGAuFechaAuxDate);
            ucTfsgaufecha_rangepicker.SetProperty("End Date", AV7DDO_SGAuFechaAuxDateTo);
            ucTfsgaufecha_rangepicker.Render(context, "wwp.daterangepicker", Tfsgaufecha_rangepicker_Internalname, "TFSGAUFECHA_RANGEPICKERContainer");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
         }
         if ( wbEnd == 57 )
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

      protected void START0I2( )
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
            Form.Meta.addItem("description", "Auditoria", 0) ;
         }
         context.wjLoc = "";
         context.nUserReturn = 0;
         context.wbHandled = 0;
         if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
         {
         }
         wbErr = false;
         STRUP0I0( ) ;
      }

      protected void WS0I2( )
      {
         START0I2( ) ;
         EVT0I2( ) ;
      }

      protected void EVT0I2( )
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
                              E110I2 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "GRIDPAGINATIONBAR.CHANGEROWSPERPAGE") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              E120I2 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "SGAUFECH_RANGEPICKER.DATERANGECHANGED") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              E130I2 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "DDO_GRID.ONOPTIONCLICKED") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              E140I2 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "VSGAUFECHOPERATOR.CLICK") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              E150I2 ();
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
                           if ( ( StringUtil.StrCmp(StringUtil.Left( sEvt, 5), "START") == 0 ) || ( StringUtil.StrCmp(StringUtil.Left( sEvt, 7), "REFRESH") == 0 ) || ( StringUtil.StrCmp(StringUtil.Left( sEvt, 9), "GRID.LOAD") == 0 ) || ( StringUtil.StrCmp(StringUtil.Left( sEvt, 5), "ENTER") == 0 ) || ( StringUtil.StrCmp(StringUtil.Left( sEvt, 6), "CANCEL") == 0 ) )
                           {
                              nGXsfl_57_idx = (int)(NumberUtil.Val( sEvtType, "."));
                              sGXsfl_57_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_57_idx), 4, 0), 4, "0");
                              SubsflControlProps_572( ) ;
                              cmbSGAuMod.Name = cmbSGAuMod_Internalname;
                              cmbSGAuMod.CurrentValue = cgiGet( cmbSGAuMod_Internalname);
                              A337SGAuMod = cgiGet( cmbSGAuMod_Internalname);
                              A338SGAuFecha = context.localUtil.CToT( cgiGet( edtSGAuFecha_Internalname), 0);
                              A1843SGAuDocGls = cgiGet( edtSGAuDocGls_Internalname);
                              A1844SGAuDocNum = cgiGet( edtSGAuDocNum_Internalname);
                              A1845SGAuDocRef = cgiGet( edtSGAuDocRef_Internalname);
                              A1847SGAuTipCod = cgiGet( edtSGAuTipCod_Internalname);
                              A1848SGAuTipo = cgiGet( edtSGAuTipo_Internalname);
                              A1849SGAuUsuCod = cgiGet( edtSGAuUsuCod_Internalname);
                              A1846SGAuFech = DateTimeUtil.ResetTime(context.localUtil.CToT( cgiGet( edtSGAuFech_Internalname), 0));
                              sEvtType = StringUtil.Right( sEvt, 1);
                              if ( StringUtil.StrCmp(sEvtType, ".") == 0 )
                              {
                                 sEvt = StringUtil.Left( sEvt, (short)(StringUtil.Len( sEvt)-1));
                                 if ( StringUtil.StrCmp(sEvt, "START") == 0 )
                                 {
                                    context.wbHandled = 1;
                                    dynload_actions( ) ;
                                    /* Execute user event: Start */
                                    E160I2 ();
                                 }
                                 else if ( StringUtil.StrCmp(sEvt, "REFRESH") == 0 )
                                 {
                                    context.wbHandled = 1;
                                    dynload_actions( ) ;
                                    /* Execute user event: Refresh */
                                    E170I2 ();
                                 }
                                 else if ( StringUtil.StrCmp(sEvt, "GRID.LOAD") == 0 )
                                 {
                                    context.wbHandled = 1;
                                    dynload_actions( ) ;
                                    E180I2 ();
                                 }
                                 else if ( StringUtil.StrCmp(sEvt, "ENTER") == 0 )
                                 {
                                    context.wbHandled = 1;
                                    if ( ! wbErr )
                                    {
                                       Rfr0gs = false;
                                       /* Set Refresh If Usucod Changed */
                                       if ( StringUtil.StrCmp(cgiGet( "GXH_vUSUCOD"), AV68UsuCod) != 0 )
                                       {
                                          Rfr0gs = true;
                                       }
                                       /* Set Refresh If Sgaumod Changed */
                                       if ( StringUtil.StrCmp(cgiGet( "GXH_vSGAUMOD"), AV40SGAuMod) != 0 )
                                       {
                                          Rfr0gs = true;
                                       }
                                       /* Set Refresh If Sgaufechoperator Changed */
                                       if ( ( context.localUtil.CToN( cgiGet( "GXH_vSGAUFECHOPERATOR"), ".", ",") != Convert.ToDecimal( AV39SGAuFechOperator )) )
                                       {
                                          Rfr0gs = true;
                                       }
                                       /* Set Refresh If Sgaufech Changed */
                                       if ( context.localUtil.CToT( cgiGet( "GXH_vSGAUFECH"), 0) != AV36SGAuFech )
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

      protected void WE0I2( )
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

      protected void PA0I2( )
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
               GX_FocusControl = dynavUsucod_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            }
            nDonePA = 1;
         }
      }

      protected void dynload_actions( )
      {
         /* End function dynload_actions */
      }

      protected void GXDLVvUSUCOD0I2( )
      {
         if ( ! context.isAjaxRequest( ) )
         {
            context.GX_webresponse.AppendHeader("Cache-Control", "no-store");
         }
         AddString( "[[") ;
         GXDLVvUSUCOD_data0I2( ) ;
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

      protected void GXVvUSUCOD_html0I2( )
      {
         string gxdynajaxvalue;
         GXDLVvUSUCOD_data0I2( ) ;
         gxdynajaxindex = 1;
         if ( ! ( gxdyncontrolsrefreshing && context.isAjaxRequest( ) ) )
         {
            dynavUsucod.removeAllItems();
         }
         while ( gxdynajaxindex <= gxdynajaxctrlcodr.Count )
         {
            gxdynajaxvalue = ((string)gxdynajaxctrlcodr.Item(gxdynajaxindex));
            dynavUsucod.addItem(gxdynajaxvalue, ((string)gxdynajaxctrldescr.Item(gxdynajaxindex)), 0);
            gxdynajaxindex = (int)(gxdynajaxindex+1);
         }
      }

      protected void GXDLVvUSUCOD_data0I2( )
      {
         gxdynajaxctrlcodr.Clear();
         gxdynajaxctrldescr.Clear();
         gxdynajaxctrlcodr.Add("");
         gxdynajaxctrldescr.Add("(Ninguno)");
         /* Using cursor H000I2 */
         pr_default.execute(0);
         while ( (pr_default.getStatus(0) != 101) )
         {
            gxdynajaxctrlcodr.Add(StringUtil.RTrim( H000I2_A348UsuCod[0]));
            gxdynajaxctrldescr.Add(StringUtil.RTrim( H000I2_A2019UsuNom[0]));
            pr_default.readNext(0);
         }
         pr_default.close(0);
      }

      protected void gxnrGrid_newrow( )
      {
         GxWebStd.set_html_headers( context, 0, "", "");
         SubsflControlProps_572( ) ;
         while ( nGXsfl_57_idx <= nRC_GXsfl_57 )
         {
            sendrow_572( ) ;
            nGXsfl_57_idx = ((subGrid_Islastpage==1)&&(nGXsfl_57_idx+1>subGrid_fnc_Recordsperpage( )) ? 1 : nGXsfl_57_idx+1);
            sGXsfl_57_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_57_idx), 4, 0), 4, "0");
            SubsflControlProps_572( ) ;
         }
         AddString( context.httpAjaxContext.getJSONContainerResponse( GridContainer)) ;
         /* End function gxnrGrid_newrow */
      }

      protected void gxgrGrid_refresh( int subGrid_Rows ,
                                       string AV68UsuCod ,
                                       string AV40SGAuMod ,
                                       short AV39SGAuFechOperator ,
                                       DateTime AV36SGAuFech ,
                                       string AV73Pgmname ,
                                       string AV34SGAuDocGls ,
                                       DateTime AV38SGAuFech_To ,
                                       GxSimpleCollection<string> AV70TFSGAuMod_Sels ,
                                       DateTime AV55TFSGAuFecha ,
                                       DateTime AV56TFSGAuFecha_To ,
                                       string AV47TFSGAuDocGls ,
                                       string AV48TFSGAuDocGls_Sel ,
                                       string AV49TFSGAuDocNum ,
                                       string AV50TFSGAuDocNum_Sel ,
                                       string AV51TFSGAuDocRef ,
                                       string AV52TFSGAuDocRef_Sel ,
                                       string AV59TFSGAuTipCod ,
                                       string AV60TFSGAuTipCod_Sel ,
                                       string AV61TFSGAuTipo ,
                                       string AV62TFSGAuTipo_Sel ,
                                       string AV63TFSGAuUsuCod ,
                                       string AV64TFSGAuUsuCod_Sel ,
                                       short AV30OrderedBy ,
                                       bool AV31OrderedDsc ,
                                       DateTime Gx_date )
      {
         initialize_formulas( ) ;
         GxWebStd.set_html_headers( context, 0, "", "");
         /* Execute user event: Refresh */
         E170I2 ();
         GRID_nCurrentRecord = 0;
         RF0I2( ) ;
         GXKey = Crypto.GetSiteKey( );
         send_integrity_footer_hashes( ) ;
         GXKey = Crypto.GetSiteKey( );
         /* End function gxgrGrid_refresh */
      }

      protected void send_integrity_hashes( )
      {
      }

      protected void clear_multi_value_controls( )
      {
         if ( context.isAjaxRequest( ) )
         {
            GXVvUSUCOD_html0I2( ) ;
            dynload_actions( ) ;
            before_start_formulas( ) ;
         }
      }

      protected void fix_multi_value_controls( )
      {
         if ( dynavUsucod.ItemCount > 0 )
         {
            AV68UsuCod = dynavUsucod.getValidValue(AV68UsuCod);
            AssignAttri("", false, "AV68UsuCod", AV68UsuCod);
         }
         if ( context.isAjaxRequest( ) )
         {
            dynavUsucod.CurrentValue = StringUtil.RTrim( AV68UsuCod);
            AssignProp("", false, dynavUsucod_Internalname, "Values", dynavUsucod.ToJavascriptSource(), true);
         }
         if ( cmbavSgaumod.ItemCount > 0 )
         {
            AV40SGAuMod = cmbavSgaumod.getValidValue(AV40SGAuMod);
            AssignAttri("", false, "AV40SGAuMod", AV40SGAuMod);
         }
         if ( context.isAjaxRequest( ) )
         {
            cmbavSgaumod.CurrentValue = StringUtil.RTrim( AV40SGAuMod);
            AssignProp("", false, cmbavSgaumod_Internalname, "Values", cmbavSgaumod.ToJavascriptSource(), true);
         }
         if ( cmbavSgaufechoperator.ItemCount > 0 )
         {
            AV39SGAuFechOperator = (short)(NumberUtil.Val( cmbavSgaufechoperator.getValidValue(StringUtil.Trim( StringUtil.Str( (decimal)(AV39SGAuFechOperator), 4, 0))), "."));
            AssignAttri("", false, "AV39SGAuFechOperator", StringUtil.LTrimStr( (decimal)(AV39SGAuFechOperator), 4, 0));
         }
         if ( context.isAjaxRequest( ) )
         {
            cmbavSgaufechoperator.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV39SGAuFechOperator), 4, 0));
            AssignProp("", false, cmbavSgaufechoperator_Internalname, "Values", cmbavSgaufechoperator.ToJavascriptSource(), true);
         }
      }

      public void Refresh( )
      {
         send_integrity_hashes( ) ;
         RF0I2( ) ;
         if ( isFullAjaxMode( ) )
         {
            send_integrity_footer_hashes( ) ;
         }
      }

      protected void initialize_formulas( )
      {
         /* GeneXus formulas. */
         Gx_date = DateTimeUtil.Today( context);
         AV73Pgmname = "Seguridad.Auditoria";
         context.Gx_err = 0;
      }

      protected void RF0I2( )
      {
         initialize_formulas( ) ;
         clear_multi_value_controls( ) ;
         if ( isAjaxCallMode( ) )
         {
            GridContainer.ClearRows();
         }
         wbStart = 57;
         /* Execute user event: Refresh */
         E170I2 ();
         nGXsfl_57_idx = 1;
         sGXsfl_57_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_57_idx), 4, 0), 4, "0");
         SubsflControlProps_572( ) ;
         bGXsfl_57_Refreshing = true;
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
            SubsflControlProps_572( ) ;
            GXPagingFrom2 = (int)(((subGrid_Rows==0) ? 0 : GRID_nFirstRecordOnPage));
            GXPagingTo2 = ((subGrid_Rows==0) ? 10000 : subGrid_fnc_Recordsperpage( )+1);
            pr_default.dynParam(1, new Object[]{ new Object[]{
                                                 A337SGAuMod ,
                                                 AV79Seguridad_auditoriads_6_tfsgaumod_sels ,
                                                 AV74Seguridad_auditoriads_1_usucod ,
                                                 AV75Seguridad_auditoriads_2_sgaumod ,
                                                 AV39SGAuFechOperator ,
                                                 AV77Seguridad_auditoriads_4_sgaufech ,
                                                 AV78Seguridad_auditoriads_5_sgaufech_to ,
                                                 AV79Seguridad_auditoriads_6_tfsgaumod_sels.Count ,
                                                 AV80Seguridad_auditoriads_7_tfsgaufecha ,
                                                 AV81Seguridad_auditoriads_8_tfsgaufecha_to ,
                                                 AV83Seguridad_auditoriads_10_tfsgaudocgls_sel ,
                                                 AV82Seguridad_auditoriads_9_tfsgaudocgls ,
                                                 AV85Seguridad_auditoriads_12_tfsgaudocnum_sel ,
                                                 AV84Seguridad_auditoriads_11_tfsgaudocnum ,
                                                 AV87Seguridad_auditoriads_14_tfsgaudocref_sel ,
                                                 AV86Seguridad_auditoriads_13_tfsgaudocref ,
                                                 AV89Seguridad_auditoriads_16_tfsgautipcod_sel ,
                                                 AV88Seguridad_auditoriads_15_tfsgautipcod ,
                                                 AV91Seguridad_auditoriads_18_tfsgautipo_sel ,
                                                 AV90Seguridad_auditoriads_17_tfsgautipo ,
                                                 AV93Seguridad_auditoriads_20_tfsgauusucod_sel ,
                                                 AV92Seguridad_auditoriads_19_tfsgauusucod ,
                                                 A1849SGAuUsuCod ,
                                                 A1846SGAuFech ,
                                                 A338SGAuFecha ,
                                                 A1843SGAuDocGls ,
                                                 A1844SGAuDocNum ,
                                                 A1845SGAuDocRef ,
                                                 A1847SGAuTipCod ,
                                                 A1848SGAuTipo ,
                                                 AV30OrderedBy ,
                                                 AV31OrderedDsc ,
                                                 AV76Seguridad_auditoriads_3_sgaudocgls } ,
                                                 new int[]{
                                                 TypeConstants.SHORT, TypeConstants.DATE, TypeConstants.DATE, TypeConstants.INT, TypeConstants.DATE, TypeConstants.DATE, TypeConstants.DATE, TypeConstants.DATE, TypeConstants.SHORT, TypeConstants.BOOLEAN
                                                 }
            });
            lV76Seguridad_auditoriads_3_sgaudocgls = StringUtil.Concat( StringUtil.RTrim( AV76Seguridad_auditoriads_3_sgaudocgls), "%", "");
            lV82Seguridad_auditoriads_9_tfsgaudocgls = StringUtil.Concat( StringUtil.RTrim( AV82Seguridad_auditoriads_9_tfsgaudocgls), "%", "");
            lV84Seguridad_auditoriads_11_tfsgaudocnum = StringUtil.Concat( StringUtil.RTrim( AV84Seguridad_auditoriads_11_tfsgaudocnum), "%", "");
            lV86Seguridad_auditoriads_13_tfsgaudocref = StringUtil.Concat( StringUtil.RTrim( AV86Seguridad_auditoriads_13_tfsgaudocref), "%", "");
            lV88Seguridad_auditoriads_15_tfsgautipcod = StringUtil.Concat( StringUtil.RTrim( AV88Seguridad_auditoriads_15_tfsgautipcod), "%", "");
            lV90Seguridad_auditoriads_17_tfsgautipo = StringUtil.Concat( StringUtil.RTrim( AV90Seguridad_auditoriads_17_tfsgautipo), "%", "");
            lV92Seguridad_auditoriads_19_tfsgauusucod = StringUtil.Concat( StringUtil.RTrim( AV92Seguridad_auditoriads_19_tfsgauusucod), "%", "");
            /* Using cursor H000I3 */
            pr_default.execute(1, new Object[] {lV76Seguridad_auditoriads_3_sgaudocgls, AV74Seguridad_auditoriads_1_usucod, AV75Seguridad_auditoriads_2_sgaumod, AV77Seguridad_auditoriads_4_sgaufech, AV77Seguridad_auditoriads_4_sgaufech, AV77Seguridad_auditoriads_4_sgaufech, AV77Seguridad_auditoriads_4_sgaufech, AV78Seguridad_auditoriads_5_sgaufech_to, AV80Seguridad_auditoriads_7_tfsgaufecha, AV81Seguridad_auditoriads_8_tfsgaufecha_to, lV82Seguridad_auditoriads_9_tfsgaudocgls, AV83Seguridad_auditoriads_10_tfsgaudocgls_sel, lV84Seguridad_auditoriads_11_tfsgaudocnum, AV85Seguridad_auditoriads_12_tfsgaudocnum_sel, lV86Seguridad_auditoriads_13_tfsgaudocref, AV87Seguridad_auditoriads_14_tfsgaudocref_sel, lV88Seguridad_auditoriads_15_tfsgautipcod, AV89Seguridad_auditoriads_16_tfsgautipcod_sel, lV90Seguridad_auditoriads_17_tfsgautipo, AV91Seguridad_auditoriads_18_tfsgautipo_sel, lV92Seguridad_auditoriads_19_tfsgauusucod, AV93Seguridad_auditoriads_20_tfsgauusucod_sel, GXPagingFrom2, GXPagingTo2, GXPagingTo2});
            nGXsfl_57_idx = 1;
            sGXsfl_57_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_57_idx), 4, 0), 4, "0");
            SubsflControlProps_572( ) ;
            while ( ( (pr_default.getStatus(1) != 101) ) && ( ( ( subGrid_Rows == 0 ) || ( GRID_nCurrentRecord < subGrid_fnc_Recordsperpage( ) ) ) ) )
            {
               A1846SGAuFech = H000I3_A1846SGAuFech[0];
               A1849SGAuUsuCod = H000I3_A1849SGAuUsuCod[0];
               A1848SGAuTipo = H000I3_A1848SGAuTipo[0];
               A1847SGAuTipCod = H000I3_A1847SGAuTipCod[0];
               A1845SGAuDocRef = H000I3_A1845SGAuDocRef[0];
               A1844SGAuDocNum = H000I3_A1844SGAuDocNum[0];
               A1843SGAuDocGls = H000I3_A1843SGAuDocGls[0];
               A338SGAuFecha = H000I3_A338SGAuFecha[0];
               A337SGAuMod = H000I3_A337SGAuMod[0];
               E180I2 ();
               pr_default.readNext(1);
            }
            GRID_nEOF = (short)(((pr_default.getStatus(1) == 101) ? 1 : 0));
            GxWebStd.gx_hidden_field( context, "GRID_nEOF", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRID_nEOF), 1, 0, ".", "")));
            pr_default.close(1);
            wbEnd = 57;
            WB0I0( ) ;
         }
         bGXsfl_57_Refreshing = true;
      }

      protected void send_integrity_lvl_hashes0I2( )
      {
         GxWebStd.gx_hidden_field( context, "vPGMNAME", StringUtil.RTrim( AV73Pgmname));
         GxWebStd.gx_hidden_field( context, "gxhash_vPGMNAME", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( AV73Pgmname, "")), context));
         GxWebStd.gx_hidden_field( context, "vTODAY", context.localUtil.DToC( Gx_date, 0, "/"));
         GxWebStd.gx_hidden_field( context, "gxhash_vTODAY", GetSecureSignedToken( "", Gx_date, context));
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
         AV74Seguridad_auditoriads_1_usucod = AV68UsuCod;
         AV75Seguridad_auditoriads_2_sgaumod = AV40SGAuMod;
         AV76Seguridad_auditoriads_3_sgaudocgls = AV34SGAuDocGls;
         AV77Seguridad_auditoriads_4_sgaufech = AV36SGAuFech;
         AV78Seguridad_auditoriads_5_sgaufech_to = AV38SGAuFech_To;
         AV79Seguridad_auditoriads_6_tfsgaumod_sels = AV70TFSGAuMod_Sels;
         AV80Seguridad_auditoriads_7_tfsgaufecha = AV55TFSGAuFecha;
         AV81Seguridad_auditoriads_8_tfsgaufecha_to = AV56TFSGAuFecha_To;
         AV82Seguridad_auditoriads_9_tfsgaudocgls = AV47TFSGAuDocGls;
         AV83Seguridad_auditoriads_10_tfsgaudocgls_sel = AV48TFSGAuDocGls_Sel;
         AV84Seguridad_auditoriads_11_tfsgaudocnum = AV49TFSGAuDocNum;
         AV85Seguridad_auditoriads_12_tfsgaudocnum_sel = AV50TFSGAuDocNum_Sel;
         AV86Seguridad_auditoriads_13_tfsgaudocref = AV51TFSGAuDocRef;
         AV87Seguridad_auditoriads_14_tfsgaudocref_sel = AV52TFSGAuDocRef_Sel;
         AV88Seguridad_auditoriads_15_tfsgautipcod = AV59TFSGAuTipCod;
         AV89Seguridad_auditoriads_16_tfsgautipcod_sel = AV60TFSGAuTipCod_Sel;
         AV90Seguridad_auditoriads_17_tfsgautipo = AV61TFSGAuTipo;
         AV91Seguridad_auditoriads_18_tfsgautipo_sel = AV62TFSGAuTipo_Sel;
         AV92Seguridad_auditoriads_19_tfsgauusucod = AV63TFSGAuUsuCod;
         AV93Seguridad_auditoriads_20_tfsgauusucod_sel = AV64TFSGAuUsuCod_Sel;
         pr_default.dynParam(2, new Object[]{ new Object[]{
                                              A337SGAuMod ,
                                              AV79Seguridad_auditoriads_6_tfsgaumod_sels ,
                                              AV74Seguridad_auditoriads_1_usucod ,
                                              AV75Seguridad_auditoriads_2_sgaumod ,
                                              AV39SGAuFechOperator ,
                                              AV77Seguridad_auditoriads_4_sgaufech ,
                                              AV78Seguridad_auditoriads_5_sgaufech_to ,
                                              AV79Seguridad_auditoriads_6_tfsgaumod_sels.Count ,
                                              AV80Seguridad_auditoriads_7_tfsgaufecha ,
                                              AV81Seguridad_auditoriads_8_tfsgaufecha_to ,
                                              AV83Seguridad_auditoriads_10_tfsgaudocgls_sel ,
                                              AV82Seguridad_auditoriads_9_tfsgaudocgls ,
                                              AV85Seguridad_auditoriads_12_tfsgaudocnum_sel ,
                                              AV84Seguridad_auditoriads_11_tfsgaudocnum ,
                                              AV87Seguridad_auditoriads_14_tfsgaudocref_sel ,
                                              AV86Seguridad_auditoriads_13_tfsgaudocref ,
                                              AV89Seguridad_auditoriads_16_tfsgautipcod_sel ,
                                              AV88Seguridad_auditoriads_15_tfsgautipcod ,
                                              AV91Seguridad_auditoriads_18_tfsgautipo_sel ,
                                              AV90Seguridad_auditoriads_17_tfsgautipo ,
                                              AV93Seguridad_auditoriads_20_tfsgauusucod_sel ,
                                              AV92Seguridad_auditoriads_19_tfsgauusucod ,
                                              A1849SGAuUsuCod ,
                                              A1846SGAuFech ,
                                              A338SGAuFecha ,
                                              A1843SGAuDocGls ,
                                              A1844SGAuDocNum ,
                                              A1845SGAuDocRef ,
                                              A1847SGAuTipCod ,
                                              A1848SGAuTipo ,
                                              AV30OrderedBy ,
                                              AV31OrderedDsc ,
                                              AV76Seguridad_auditoriads_3_sgaudocgls } ,
                                              new int[]{
                                              TypeConstants.SHORT, TypeConstants.DATE, TypeConstants.DATE, TypeConstants.INT, TypeConstants.DATE, TypeConstants.DATE, TypeConstants.DATE, TypeConstants.DATE, TypeConstants.SHORT, TypeConstants.BOOLEAN
                                              }
         });
         lV76Seguridad_auditoriads_3_sgaudocgls = StringUtil.Concat( StringUtil.RTrim( AV76Seguridad_auditoriads_3_sgaudocgls), "%", "");
         lV82Seguridad_auditoriads_9_tfsgaudocgls = StringUtil.Concat( StringUtil.RTrim( AV82Seguridad_auditoriads_9_tfsgaudocgls), "%", "");
         lV84Seguridad_auditoriads_11_tfsgaudocnum = StringUtil.Concat( StringUtil.RTrim( AV84Seguridad_auditoriads_11_tfsgaudocnum), "%", "");
         lV86Seguridad_auditoriads_13_tfsgaudocref = StringUtil.Concat( StringUtil.RTrim( AV86Seguridad_auditoriads_13_tfsgaudocref), "%", "");
         lV88Seguridad_auditoriads_15_tfsgautipcod = StringUtil.Concat( StringUtil.RTrim( AV88Seguridad_auditoriads_15_tfsgautipcod), "%", "");
         lV90Seguridad_auditoriads_17_tfsgautipo = StringUtil.Concat( StringUtil.RTrim( AV90Seguridad_auditoriads_17_tfsgautipo), "%", "");
         lV92Seguridad_auditoriads_19_tfsgauusucod = StringUtil.Concat( StringUtil.RTrim( AV92Seguridad_auditoriads_19_tfsgauusucod), "%", "");
         /* Using cursor H000I4 */
         pr_default.execute(2, new Object[] {lV76Seguridad_auditoriads_3_sgaudocgls, AV74Seguridad_auditoriads_1_usucod, AV75Seguridad_auditoriads_2_sgaumod, AV77Seguridad_auditoriads_4_sgaufech, AV77Seguridad_auditoriads_4_sgaufech, AV77Seguridad_auditoriads_4_sgaufech, AV77Seguridad_auditoriads_4_sgaufech, AV78Seguridad_auditoriads_5_sgaufech_to, AV80Seguridad_auditoriads_7_tfsgaufecha, AV81Seguridad_auditoriads_8_tfsgaufecha_to, lV82Seguridad_auditoriads_9_tfsgaudocgls, AV83Seguridad_auditoriads_10_tfsgaudocgls_sel, lV84Seguridad_auditoriads_11_tfsgaudocnum, AV85Seguridad_auditoriads_12_tfsgaudocnum_sel, lV86Seguridad_auditoriads_13_tfsgaudocref, AV87Seguridad_auditoriads_14_tfsgaudocref_sel, lV88Seguridad_auditoriads_15_tfsgautipcod, AV89Seguridad_auditoriads_16_tfsgautipcod_sel, lV90Seguridad_auditoriads_17_tfsgautipo, AV91Seguridad_auditoriads_18_tfsgautipo_sel, lV92Seguridad_auditoriads_19_tfsgauusucod, AV93Seguridad_auditoriads_20_tfsgauusucod_sel});
         GRID_nRecordCount = H000I4_AGRID_nRecordCount[0];
         pr_default.close(2);
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
         AV74Seguridad_auditoriads_1_usucod = AV68UsuCod;
         AV75Seguridad_auditoriads_2_sgaumod = AV40SGAuMod;
         AV76Seguridad_auditoriads_3_sgaudocgls = AV34SGAuDocGls;
         AV77Seguridad_auditoriads_4_sgaufech = AV36SGAuFech;
         AV78Seguridad_auditoriads_5_sgaufech_to = AV38SGAuFech_To;
         AV79Seguridad_auditoriads_6_tfsgaumod_sels = AV70TFSGAuMod_Sels;
         AV80Seguridad_auditoriads_7_tfsgaufecha = AV55TFSGAuFecha;
         AV81Seguridad_auditoriads_8_tfsgaufecha_to = AV56TFSGAuFecha_To;
         AV82Seguridad_auditoriads_9_tfsgaudocgls = AV47TFSGAuDocGls;
         AV83Seguridad_auditoriads_10_tfsgaudocgls_sel = AV48TFSGAuDocGls_Sel;
         AV84Seguridad_auditoriads_11_tfsgaudocnum = AV49TFSGAuDocNum;
         AV85Seguridad_auditoriads_12_tfsgaudocnum_sel = AV50TFSGAuDocNum_Sel;
         AV86Seguridad_auditoriads_13_tfsgaudocref = AV51TFSGAuDocRef;
         AV87Seguridad_auditoriads_14_tfsgaudocref_sel = AV52TFSGAuDocRef_Sel;
         AV88Seguridad_auditoriads_15_tfsgautipcod = AV59TFSGAuTipCod;
         AV89Seguridad_auditoriads_16_tfsgautipcod_sel = AV60TFSGAuTipCod_Sel;
         AV90Seguridad_auditoriads_17_tfsgautipo = AV61TFSGAuTipo;
         AV91Seguridad_auditoriads_18_tfsgautipo_sel = AV62TFSGAuTipo_Sel;
         AV92Seguridad_auditoriads_19_tfsgauusucod = AV63TFSGAuUsuCod;
         AV93Seguridad_auditoriads_20_tfsgauusucod_sel = AV64TFSGAuUsuCod_Sel;
         GRID_nFirstRecordOnPage = 0;
         GxWebStd.gx_hidden_field( context, "GRID_nFirstRecordOnPage", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRID_nFirstRecordOnPage), 15, 0, ".", "")));
         if ( isFullAjaxMode( ) )
         {
            gxgrGrid_refresh( subGrid_Rows, AV68UsuCod, AV40SGAuMod, AV39SGAuFechOperator, AV36SGAuFech, AV73Pgmname, AV34SGAuDocGls, AV38SGAuFech_To, AV70TFSGAuMod_Sels, AV55TFSGAuFecha, AV56TFSGAuFecha_To, AV47TFSGAuDocGls, AV48TFSGAuDocGls_Sel, AV49TFSGAuDocNum, AV50TFSGAuDocNum_Sel, AV51TFSGAuDocRef, AV52TFSGAuDocRef_Sel, AV59TFSGAuTipCod, AV60TFSGAuTipCod_Sel, AV61TFSGAuTipo, AV62TFSGAuTipo_Sel, AV63TFSGAuUsuCod, AV64TFSGAuUsuCod_Sel, AV30OrderedBy, AV31OrderedDsc, Gx_date) ;
         }
         send_integrity_footer_hashes( ) ;
         return 0 ;
      }

      protected short subgrid_nextpage( )
      {
         AV74Seguridad_auditoriads_1_usucod = AV68UsuCod;
         AV75Seguridad_auditoriads_2_sgaumod = AV40SGAuMod;
         AV76Seguridad_auditoriads_3_sgaudocgls = AV34SGAuDocGls;
         AV77Seguridad_auditoriads_4_sgaufech = AV36SGAuFech;
         AV78Seguridad_auditoriads_5_sgaufech_to = AV38SGAuFech_To;
         AV79Seguridad_auditoriads_6_tfsgaumod_sels = AV70TFSGAuMod_Sels;
         AV80Seguridad_auditoriads_7_tfsgaufecha = AV55TFSGAuFecha;
         AV81Seguridad_auditoriads_8_tfsgaufecha_to = AV56TFSGAuFecha_To;
         AV82Seguridad_auditoriads_9_tfsgaudocgls = AV47TFSGAuDocGls;
         AV83Seguridad_auditoriads_10_tfsgaudocgls_sel = AV48TFSGAuDocGls_Sel;
         AV84Seguridad_auditoriads_11_tfsgaudocnum = AV49TFSGAuDocNum;
         AV85Seguridad_auditoriads_12_tfsgaudocnum_sel = AV50TFSGAuDocNum_Sel;
         AV86Seguridad_auditoriads_13_tfsgaudocref = AV51TFSGAuDocRef;
         AV87Seguridad_auditoriads_14_tfsgaudocref_sel = AV52TFSGAuDocRef_Sel;
         AV88Seguridad_auditoriads_15_tfsgautipcod = AV59TFSGAuTipCod;
         AV89Seguridad_auditoriads_16_tfsgautipcod_sel = AV60TFSGAuTipCod_Sel;
         AV90Seguridad_auditoriads_17_tfsgautipo = AV61TFSGAuTipo;
         AV91Seguridad_auditoriads_18_tfsgautipo_sel = AV62TFSGAuTipo_Sel;
         AV92Seguridad_auditoriads_19_tfsgauusucod = AV63TFSGAuUsuCod;
         AV93Seguridad_auditoriads_20_tfsgauusucod_sel = AV64TFSGAuUsuCod_Sel;
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
            gxgrGrid_refresh( subGrid_Rows, AV68UsuCod, AV40SGAuMod, AV39SGAuFechOperator, AV36SGAuFech, AV73Pgmname, AV34SGAuDocGls, AV38SGAuFech_To, AV70TFSGAuMod_Sels, AV55TFSGAuFecha, AV56TFSGAuFecha_To, AV47TFSGAuDocGls, AV48TFSGAuDocGls_Sel, AV49TFSGAuDocNum, AV50TFSGAuDocNum_Sel, AV51TFSGAuDocRef, AV52TFSGAuDocRef_Sel, AV59TFSGAuTipCod, AV60TFSGAuTipCod_Sel, AV61TFSGAuTipo, AV62TFSGAuTipo_Sel, AV63TFSGAuUsuCod, AV64TFSGAuUsuCod_Sel, AV30OrderedBy, AV31OrderedDsc, Gx_date) ;
         }
         send_integrity_footer_hashes( ) ;
         return (short)(((GRID_nEOF==0) ? 0 : 2)) ;
      }

      protected short subgrid_previouspage( )
      {
         AV74Seguridad_auditoriads_1_usucod = AV68UsuCod;
         AV75Seguridad_auditoriads_2_sgaumod = AV40SGAuMod;
         AV76Seguridad_auditoriads_3_sgaudocgls = AV34SGAuDocGls;
         AV77Seguridad_auditoriads_4_sgaufech = AV36SGAuFech;
         AV78Seguridad_auditoriads_5_sgaufech_to = AV38SGAuFech_To;
         AV79Seguridad_auditoriads_6_tfsgaumod_sels = AV70TFSGAuMod_Sels;
         AV80Seguridad_auditoriads_7_tfsgaufecha = AV55TFSGAuFecha;
         AV81Seguridad_auditoriads_8_tfsgaufecha_to = AV56TFSGAuFecha_To;
         AV82Seguridad_auditoriads_9_tfsgaudocgls = AV47TFSGAuDocGls;
         AV83Seguridad_auditoriads_10_tfsgaudocgls_sel = AV48TFSGAuDocGls_Sel;
         AV84Seguridad_auditoriads_11_tfsgaudocnum = AV49TFSGAuDocNum;
         AV85Seguridad_auditoriads_12_tfsgaudocnum_sel = AV50TFSGAuDocNum_Sel;
         AV86Seguridad_auditoriads_13_tfsgaudocref = AV51TFSGAuDocRef;
         AV87Seguridad_auditoriads_14_tfsgaudocref_sel = AV52TFSGAuDocRef_Sel;
         AV88Seguridad_auditoriads_15_tfsgautipcod = AV59TFSGAuTipCod;
         AV89Seguridad_auditoriads_16_tfsgautipcod_sel = AV60TFSGAuTipCod_Sel;
         AV90Seguridad_auditoriads_17_tfsgautipo = AV61TFSGAuTipo;
         AV91Seguridad_auditoriads_18_tfsgautipo_sel = AV62TFSGAuTipo_Sel;
         AV92Seguridad_auditoriads_19_tfsgauusucod = AV63TFSGAuUsuCod;
         AV93Seguridad_auditoriads_20_tfsgauusucod_sel = AV64TFSGAuUsuCod_Sel;
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
            gxgrGrid_refresh( subGrid_Rows, AV68UsuCod, AV40SGAuMod, AV39SGAuFechOperator, AV36SGAuFech, AV73Pgmname, AV34SGAuDocGls, AV38SGAuFech_To, AV70TFSGAuMod_Sels, AV55TFSGAuFecha, AV56TFSGAuFecha_To, AV47TFSGAuDocGls, AV48TFSGAuDocGls_Sel, AV49TFSGAuDocNum, AV50TFSGAuDocNum_Sel, AV51TFSGAuDocRef, AV52TFSGAuDocRef_Sel, AV59TFSGAuTipCod, AV60TFSGAuTipCod_Sel, AV61TFSGAuTipo, AV62TFSGAuTipo_Sel, AV63TFSGAuUsuCod, AV64TFSGAuUsuCod_Sel, AV30OrderedBy, AV31OrderedDsc, Gx_date) ;
         }
         send_integrity_footer_hashes( ) ;
         return 0 ;
      }

      protected short subgrid_lastpage( )
      {
         AV74Seguridad_auditoriads_1_usucod = AV68UsuCod;
         AV75Seguridad_auditoriads_2_sgaumod = AV40SGAuMod;
         AV76Seguridad_auditoriads_3_sgaudocgls = AV34SGAuDocGls;
         AV77Seguridad_auditoriads_4_sgaufech = AV36SGAuFech;
         AV78Seguridad_auditoriads_5_sgaufech_to = AV38SGAuFech_To;
         AV79Seguridad_auditoriads_6_tfsgaumod_sels = AV70TFSGAuMod_Sels;
         AV80Seguridad_auditoriads_7_tfsgaufecha = AV55TFSGAuFecha;
         AV81Seguridad_auditoriads_8_tfsgaufecha_to = AV56TFSGAuFecha_To;
         AV82Seguridad_auditoriads_9_tfsgaudocgls = AV47TFSGAuDocGls;
         AV83Seguridad_auditoriads_10_tfsgaudocgls_sel = AV48TFSGAuDocGls_Sel;
         AV84Seguridad_auditoriads_11_tfsgaudocnum = AV49TFSGAuDocNum;
         AV85Seguridad_auditoriads_12_tfsgaudocnum_sel = AV50TFSGAuDocNum_Sel;
         AV86Seguridad_auditoriads_13_tfsgaudocref = AV51TFSGAuDocRef;
         AV87Seguridad_auditoriads_14_tfsgaudocref_sel = AV52TFSGAuDocRef_Sel;
         AV88Seguridad_auditoriads_15_tfsgautipcod = AV59TFSGAuTipCod;
         AV89Seguridad_auditoriads_16_tfsgautipcod_sel = AV60TFSGAuTipCod_Sel;
         AV90Seguridad_auditoriads_17_tfsgautipo = AV61TFSGAuTipo;
         AV91Seguridad_auditoriads_18_tfsgautipo_sel = AV62TFSGAuTipo_Sel;
         AV92Seguridad_auditoriads_19_tfsgauusucod = AV63TFSGAuUsuCod;
         AV93Seguridad_auditoriads_20_tfsgauusucod_sel = AV64TFSGAuUsuCod_Sel;
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
            gxgrGrid_refresh( subGrid_Rows, AV68UsuCod, AV40SGAuMod, AV39SGAuFechOperator, AV36SGAuFech, AV73Pgmname, AV34SGAuDocGls, AV38SGAuFech_To, AV70TFSGAuMod_Sels, AV55TFSGAuFecha, AV56TFSGAuFecha_To, AV47TFSGAuDocGls, AV48TFSGAuDocGls_Sel, AV49TFSGAuDocNum, AV50TFSGAuDocNum_Sel, AV51TFSGAuDocRef, AV52TFSGAuDocRef_Sel, AV59TFSGAuTipCod, AV60TFSGAuTipCod_Sel, AV61TFSGAuTipo, AV62TFSGAuTipo_Sel, AV63TFSGAuUsuCod, AV64TFSGAuUsuCod_Sel, AV30OrderedBy, AV31OrderedDsc, Gx_date) ;
         }
         send_integrity_footer_hashes( ) ;
         return 0 ;
      }

      protected int subgrid_gotopage( int nPageNo )
      {
         AV74Seguridad_auditoriads_1_usucod = AV68UsuCod;
         AV75Seguridad_auditoriads_2_sgaumod = AV40SGAuMod;
         AV76Seguridad_auditoriads_3_sgaudocgls = AV34SGAuDocGls;
         AV77Seguridad_auditoriads_4_sgaufech = AV36SGAuFech;
         AV78Seguridad_auditoriads_5_sgaufech_to = AV38SGAuFech_To;
         AV79Seguridad_auditoriads_6_tfsgaumod_sels = AV70TFSGAuMod_Sels;
         AV80Seguridad_auditoriads_7_tfsgaufecha = AV55TFSGAuFecha;
         AV81Seguridad_auditoriads_8_tfsgaufecha_to = AV56TFSGAuFecha_To;
         AV82Seguridad_auditoriads_9_tfsgaudocgls = AV47TFSGAuDocGls;
         AV83Seguridad_auditoriads_10_tfsgaudocgls_sel = AV48TFSGAuDocGls_Sel;
         AV84Seguridad_auditoriads_11_tfsgaudocnum = AV49TFSGAuDocNum;
         AV85Seguridad_auditoriads_12_tfsgaudocnum_sel = AV50TFSGAuDocNum_Sel;
         AV86Seguridad_auditoriads_13_tfsgaudocref = AV51TFSGAuDocRef;
         AV87Seguridad_auditoriads_14_tfsgaudocref_sel = AV52TFSGAuDocRef_Sel;
         AV88Seguridad_auditoriads_15_tfsgautipcod = AV59TFSGAuTipCod;
         AV89Seguridad_auditoriads_16_tfsgautipcod_sel = AV60TFSGAuTipCod_Sel;
         AV90Seguridad_auditoriads_17_tfsgautipo = AV61TFSGAuTipo;
         AV91Seguridad_auditoriads_18_tfsgautipo_sel = AV62TFSGAuTipo_Sel;
         AV92Seguridad_auditoriads_19_tfsgauusucod = AV63TFSGAuUsuCod;
         AV93Seguridad_auditoriads_20_tfsgauusucod_sel = AV64TFSGAuUsuCod_Sel;
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
            gxgrGrid_refresh( subGrid_Rows, AV68UsuCod, AV40SGAuMod, AV39SGAuFechOperator, AV36SGAuFech, AV73Pgmname, AV34SGAuDocGls, AV38SGAuFech_To, AV70TFSGAuMod_Sels, AV55TFSGAuFecha, AV56TFSGAuFecha_To, AV47TFSGAuDocGls, AV48TFSGAuDocGls_Sel, AV49TFSGAuDocNum, AV50TFSGAuDocNum_Sel, AV51TFSGAuDocRef, AV52TFSGAuDocRef_Sel, AV59TFSGAuTipCod, AV60TFSGAuTipCod_Sel, AV61TFSGAuTipo, AV62TFSGAuTipo_Sel, AV63TFSGAuUsuCod, AV64TFSGAuUsuCod_Sel, AV30OrderedBy, AV31OrderedDsc, Gx_date) ;
         }
         send_integrity_footer_hashes( ) ;
         return (int)(0) ;
      }

      protected void before_start_formulas( )
      {
         Gx_date = DateTimeUtil.Today( context);
         AV73Pgmname = "Seguridad.Auditoria";
         context.Gx_err = 0;
         GXVvUSUCOD_html0I2( ) ;
         fix_multi_value_controls( ) ;
      }

      protected void STRUP0I0( )
      {
         /* Before Start, stand alone formulas. */
         before_start_formulas( ) ;
         /* Execute Start event if defined. */
         context.wbGlbDoneStart = 0;
         /* Execute user event: Start */
         E160I2 ();
         context.wbGlbDoneStart = 1;
         /* After Start, stand alone formulas. */
         if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
         {
            /* Read saved SDTs. */
            ajax_req_read_hidden_sdt(cgiGet( "vDDO_TITLESETTINGSICONS"), AV11DDO_TitleSettingsIcons);
            /* Read saved values. */
            nRC_GXsfl_57 = (int)(context.localUtil.CToN( cgiGet( "nRC_GXsfl_57"), ".", ","));
            AV23GridCurrentPage = (long)(context.localUtil.CToN( cgiGet( "vGRIDCURRENTPAGE"), ".", ","));
            AV24GridPageCount = (long)(context.localUtil.CToN( cgiGet( "vGRIDPAGECOUNT"), ".", ","));
            AV22GridAppliedFilters = cgiGet( "vGRIDAPPLIEDFILTERS");
            AV36SGAuFech = context.localUtil.CToD( cgiGet( "vSGAUFECH"), 0);
            AV38SGAuFech_To = context.localUtil.CToD( cgiGet( "vSGAUFECH_TO"), 0);
            AV5DDO_SGAuFechaAuxDate = context.localUtil.CToD( cgiGet( "vDDO_SGAUFECHAAUXDATE"), 0);
            AV7DDO_SGAuFechaAuxDateTo = context.localUtil.CToD( cgiGet( "vDDO_SGAUFECHAAUXDATETO"), 0);
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
            /* Read variables values. */
            dynavUsucod.Name = dynavUsucod_Internalname;
            dynavUsucod.CurrentValue = cgiGet( dynavUsucod_Internalname);
            AV68UsuCod = cgiGet( dynavUsucod_Internalname);
            AssignAttri("", false, "AV68UsuCod", AV68UsuCod);
            cmbavSgaumod.Name = cmbavSgaumod_Internalname;
            cmbavSgaumod.CurrentValue = cgiGet( cmbavSgaumod_Internalname);
            AV40SGAuMod = cgiGet( cmbavSgaumod_Internalname);
            AssignAttri("", false, "AV40SGAuMod", AV40SGAuMod);
            AV34SGAuDocGls = cgiGet( edtavSgaudocgls_Internalname);
            AssignAttri("", false, "AV34SGAuDocGls", AV34SGAuDocGls);
            cmbavSgaufechoperator.Name = cmbavSgaufechoperator_Internalname;
            cmbavSgaufechoperator.CurrentValue = cgiGet( cmbavSgaufechoperator_Internalname);
            AV39SGAuFechOperator = (short)(NumberUtil.Val( cgiGet( cmbavSgaufechoperator_Internalname), "."));
            AssignAttri("", false, "AV39SGAuFechOperator", StringUtil.LTrimStr( (decimal)(AV39SGAuFechOperator), 4, 0));
            AV37SGAuFech_RangeText = cgiGet( edtavSgaufech_rangetext_Internalname);
            AssignAttri("", false, "AV37SGAuFech_RangeText", AV37SGAuFech_RangeText);
            AV6DDO_SGAuFechaAuxDateText = cgiGet( edtavDdo_sgaufechaauxdatetext_Internalname);
            AssignAttri("", false, "AV6DDO_SGAuFechaAuxDateText", AV6DDO_SGAuFechaAuxDateText);
            /* Read subfile selected row values. */
            /* Read hidden variables. */
            GXKey = Crypto.GetSiteKey( );
            /* Check if conditions changed and reset current page numbers */
            if ( StringUtil.StrCmp(cgiGet( "GXH_vUSUCOD"), AV68UsuCod) != 0 )
            {
               GRID_nFirstRecordOnPage = 0;
            }
            if ( StringUtil.StrCmp(cgiGet( "GXH_vSGAUMOD"), AV40SGAuMod) != 0 )
            {
               GRID_nFirstRecordOnPage = 0;
            }
            if ( ( context.localUtil.CToN( cgiGet( "GXH_vSGAUFECHOPERATOR"), ".", ",") != Convert.ToDecimal( AV39SGAuFechOperator )) )
            {
               GRID_nFirstRecordOnPage = 0;
            }
            if ( DateTimeUtil.ResetTime ( context.localUtil.CToD( cgiGet( "GXH_vSGAUFECH"), 2) ) != DateTimeUtil.ResetTime ( AV36SGAuFech ) )
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
         E160I2 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
      }

      protected void E160I2( )
      {
         /* Start Routine */
         returnInSub = false;
         this.executeUsercontrolMethod("", false, "TFSGAUFECHA_RANGEPICKERContainer", "Attach", "", new Object[] {(string)edtavDdo_sgaufechaauxdatetext_Internalname});
         subGrid_Rows = 10;
         GxWebStd.gx_hidden_field( context, "GRID_Rows", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid_Rows), 6, 0, ".", "")));
         Grid_empowerer_Gridinternalname = subGrid_Internalname;
         ucGrid_empowerer.SendProperty(context, "", false, Grid_empowerer_Internalname, "GridInternalName", Grid_empowerer_Gridinternalname);
         AV36SGAuFech = DateTimeUtil.Today( context);
         AssignAttri("", false, "AV36SGAuFech", context.localUtil.Format(AV36SGAuFech, "99/99/99"));
         this.executeUsercontrolMethod("", false, "SGAUFECH_RANGEPICKERContainer", "Attach", "", new Object[] {(string)edtavSgaufech_rangetext_Internalname});
         Ddo_grid_Gridinternalname = subGrid_Internalname;
         ucDdo_grid.SendProperty(context, "", false, Ddo_grid_Internalname, "GridInternalName", Ddo_grid_Gridinternalname);
         Form.Caption = "Auditoria";
         AssignProp("", false, "FORM", "Caption", Form.Caption, true);
         /* Execute user subroutine: 'PREPARETRANSACTION' */
         S112 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
         /* Execute user subroutine: 'UPDATESGAUFECHOPERATORVALUES' */
         S122 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
         /* Execute user subroutine: 'LOADGRIDSTATE' */
         S132 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
         if ( AV30OrderedBy < 1 )
         {
            AV30OrderedBy = 1;
            AssignAttri("", false, "AV30OrderedBy", StringUtil.LTrimStr( (decimal)(AV30OrderedBy), 4, 0));
            /* Execute user subroutine: 'SETDDOSORTEDSTATUS' */
            S142 ();
            if ( returnInSub )
            {
               returnInSub = true;
               if (true) return;
            }
         }
         GXt_SdtDVB_SDTDropDownOptionsTitleSettingsIcons1 = AV11DDO_TitleSettingsIcons;
         new GeneXus.Programs.wwpbaseobjects.getwwptitlesettingsicons(context ).execute( out  GXt_SdtDVB_SDTDropDownOptionsTitleSettingsIcons1) ;
         AV11DDO_TitleSettingsIcons = GXt_SdtDVB_SDTDropDownOptionsTitleSettingsIcons1;
         Gridpaginationbar_Rowsperpageselectedvalue = subGrid_Rows;
         ucGridpaginationbar.SendProperty(context, "", false, Gridpaginationbar_Internalname, "RowsPerPageSelectedValue", StringUtil.LTrimStr( (decimal)(Gridpaginationbar_Rowsperpageselectedvalue), 9, 0));
      }

      protected void E170I2( )
      {
         if ( gx_refresh_fired )
         {
            return  ;
         }
         gx_refresh_fired = true;
         /* Refresh Routine */
         returnInSub = false;
         new GeneXus.Programs.wwpbaseobjects.loadwwpcontext(context ).execute( out  AV67WWPContext) ;
         /* Execute user subroutine: 'SAVEGRIDSTATE' */
         S152 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
         AV23GridCurrentPage = subGrid_fnc_Currentpage( );
         AssignAttri("", false, "AV23GridCurrentPage", StringUtil.LTrimStr( (decimal)(AV23GridCurrentPage), 10, 0));
         AV24GridPageCount = subGrid_fnc_Pagecount( );
         AssignAttri("", false, "AV24GridPageCount", StringUtil.LTrimStr( (decimal)(AV24GridPageCount), 10, 0));
         GXt_char2 = AV22GridAppliedFilters;
         new GeneXus.Programs.wwpbaseobjects.wwp_getappliedfiltersdescription(context ).execute(  AV73Pgmname, out  GXt_char2) ;
         AV22GridAppliedFilters = GXt_char2;
         AssignAttri("", false, "AV22GridAppliedFilters", AV22GridAppliedFilters);
         AV74Seguridad_auditoriads_1_usucod = AV68UsuCod;
         AV75Seguridad_auditoriads_2_sgaumod = AV40SGAuMod;
         AV76Seguridad_auditoriads_3_sgaudocgls = AV34SGAuDocGls;
         AV77Seguridad_auditoriads_4_sgaufech = AV36SGAuFech;
         AV78Seguridad_auditoriads_5_sgaufech_to = AV38SGAuFech_To;
         AV79Seguridad_auditoriads_6_tfsgaumod_sels = AV70TFSGAuMod_Sels;
         AV80Seguridad_auditoriads_7_tfsgaufecha = AV55TFSGAuFecha;
         AV81Seguridad_auditoriads_8_tfsgaufecha_to = AV56TFSGAuFecha_To;
         AV82Seguridad_auditoriads_9_tfsgaudocgls = AV47TFSGAuDocGls;
         AV83Seguridad_auditoriads_10_tfsgaudocgls_sel = AV48TFSGAuDocGls_Sel;
         AV84Seguridad_auditoriads_11_tfsgaudocnum = AV49TFSGAuDocNum;
         AV85Seguridad_auditoriads_12_tfsgaudocnum_sel = AV50TFSGAuDocNum_Sel;
         AV86Seguridad_auditoriads_13_tfsgaudocref = AV51TFSGAuDocRef;
         AV87Seguridad_auditoriads_14_tfsgaudocref_sel = AV52TFSGAuDocRef_Sel;
         AV88Seguridad_auditoriads_15_tfsgautipcod = AV59TFSGAuTipCod;
         AV89Seguridad_auditoriads_16_tfsgautipcod_sel = AV60TFSGAuTipCod_Sel;
         AV90Seguridad_auditoriads_17_tfsgautipo = AV61TFSGAuTipo;
         AV91Seguridad_auditoriads_18_tfsgautipo_sel = AV62TFSGAuTipo_Sel;
         AV92Seguridad_auditoriads_19_tfsgauusucod = AV63TFSGAuUsuCod;
         AV93Seguridad_auditoriads_20_tfsgauusucod_sel = AV64TFSGAuUsuCod_Sel;
         /*  Sending Event outputs  */
      }

      protected void E110I2( )
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
            AV32PageToGo = (int)(NumberUtil.Val( Gridpaginationbar_Selectedpage, "."));
            subgrid_gotopage( AV32PageToGo) ;
         }
      }

      protected void E120I2( )
      {
         /* Gridpaginationbar_Changerowsperpage Routine */
         returnInSub = false;
         subGrid_Rows = Gridpaginationbar_Rowsperpageselectedvalue;
         GxWebStd.gx_hidden_field( context, "GRID_Rows", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid_Rows), 6, 0, ".", "")));
         subgrid_firstpage( ) ;
         /*  Sending Event outputs  */
      }

      protected void E140I2( )
      {
         /* Ddo_grid_Onoptionclicked Routine */
         returnInSub = false;
         if ( ( StringUtil.StrCmp(Ddo_grid_Activeeventkey, "<#OrderASC#>") == 0 ) || ( StringUtil.StrCmp(Ddo_grid_Activeeventkey, "<#OrderDSC#>") == 0 ) )
         {
            AV30OrderedBy = (short)(NumberUtil.Val( Ddo_grid_Selectedvalue_get, "."));
            AssignAttri("", false, "AV30OrderedBy", StringUtil.LTrimStr( (decimal)(AV30OrderedBy), 4, 0));
            AV31OrderedDsc = ((StringUtil.StrCmp(Ddo_grid_Activeeventkey, "<#OrderDSC#>")==0) ? true : false);
            AssignAttri("", false, "AV31OrderedDsc", AV31OrderedDsc);
            /* Execute user subroutine: 'SETDDOSORTEDSTATUS' */
            S142 ();
            if ( returnInSub )
            {
               returnInSub = true;
               if (true) return;
            }
            subgrid_firstpage( ) ;
         }
         else if ( StringUtil.StrCmp(Ddo_grid_Activeeventkey, "<#Filter#>") == 0 )
         {
            if ( StringUtil.StrCmp(Ddo_grid_Selectedcolumn, "SGAuMod") == 0 )
            {
               AV69TFSGAuMod_SelsJson = Ddo_grid_Selectedvalue_get;
               AssignAttri("", false, "AV69TFSGAuMod_SelsJson", AV69TFSGAuMod_SelsJson);
               AV70TFSGAuMod_Sels.FromJSonString(AV69TFSGAuMod_SelsJson, null);
            }
            else if ( StringUtil.StrCmp(Ddo_grid_Selectedcolumn, "SGAuFecha") == 0 )
            {
               AV55TFSGAuFecha = context.localUtil.CToT( Ddo_grid_Filteredtext_get, 2);
               AssignAttri("", false, "AV55TFSGAuFecha", context.localUtil.TToC( AV55TFSGAuFecha, 8, 5, 0, 3, "/", ":", " "));
               AV56TFSGAuFecha_To = context.localUtil.CToT( Ddo_grid_Filteredtextto_get, 2);
               AssignAttri("", false, "AV56TFSGAuFecha_To", context.localUtil.TToC( AV56TFSGAuFecha_To, 8, 5, 0, 3, "/", ":", " "));
               if ( ! (DateTime.MinValue==AV56TFSGAuFecha_To) )
               {
                  AV56TFSGAuFecha_To = context.localUtil.YMDHMSToT( (short)(DateTimeUtil.Year( AV56TFSGAuFecha_To)), (short)(DateTimeUtil.Month( AV56TFSGAuFecha_To)), (short)(DateTimeUtil.Day( AV56TFSGAuFecha_To)), 23, 59, 59);
                  AssignAttri("", false, "AV56TFSGAuFecha_To", context.localUtil.TToC( AV56TFSGAuFecha_To, 8, 5, 0, 3, "/", ":", " "));
               }
            }
            else if ( StringUtil.StrCmp(Ddo_grid_Selectedcolumn, "SGAuDocGls") == 0 )
            {
               AV47TFSGAuDocGls = Ddo_grid_Filteredtext_get;
               AssignAttri("", false, "AV47TFSGAuDocGls", AV47TFSGAuDocGls);
               AV48TFSGAuDocGls_Sel = Ddo_grid_Selectedvalue_get;
               AssignAttri("", false, "AV48TFSGAuDocGls_Sel", AV48TFSGAuDocGls_Sel);
            }
            else if ( StringUtil.StrCmp(Ddo_grid_Selectedcolumn, "SGAuDocNum") == 0 )
            {
               AV49TFSGAuDocNum = Ddo_grid_Filteredtext_get;
               AssignAttri("", false, "AV49TFSGAuDocNum", AV49TFSGAuDocNum);
               AV50TFSGAuDocNum_Sel = Ddo_grid_Selectedvalue_get;
               AssignAttri("", false, "AV50TFSGAuDocNum_Sel", AV50TFSGAuDocNum_Sel);
            }
            else if ( StringUtil.StrCmp(Ddo_grid_Selectedcolumn, "SGAuDocRef") == 0 )
            {
               AV51TFSGAuDocRef = Ddo_grid_Filteredtext_get;
               AssignAttri("", false, "AV51TFSGAuDocRef", AV51TFSGAuDocRef);
               AV52TFSGAuDocRef_Sel = Ddo_grid_Selectedvalue_get;
               AssignAttri("", false, "AV52TFSGAuDocRef_Sel", AV52TFSGAuDocRef_Sel);
            }
            else if ( StringUtil.StrCmp(Ddo_grid_Selectedcolumn, "SGAuTipCod") == 0 )
            {
               AV59TFSGAuTipCod = Ddo_grid_Filteredtext_get;
               AssignAttri("", false, "AV59TFSGAuTipCod", AV59TFSGAuTipCod);
               AV60TFSGAuTipCod_Sel = Ddo_grid_Selectedvalue_get;
               AssignAttri("", false, "AV60TFSGAuTipCod_Sel", AV60TFSGAuTipCod_Sel);
            }
            else if ( StringUtil.StrCmp(Ddo_grid_Selectedcolumn, "SGAuTipo") == 0 )
            {
               AV61TFSGAuTipo = Ddo_grid_Filteredtext_get;
               AssignAttri("", false, "AV61TFSGAuTipo", AV61TFSGAuTipo);
               AV62TFSGAuTipo_Sel = Ddo_grid_Selectedvalue_get;
               AssignAttri("", false, "AV62TFSGAuTipo_Sel", AV62TFSGAuTipo_Sel);
            }
            else if ( StringUtil.StrCmp(Ddo_grid_Selectedcolumn, "SGAuUsuCod") == 0 )
            {
               AV63TFSGAuUsuCod = Ddo_grid_Filteredtext_get;
               AssignAttri("", false, "AV63TFSGAuUsuCod", AV63TFSGAuUsuCod);
               AV64TFSGAuUsuCod_Sel = Ddo_grid_Selectedvalue_get;
               AssignAttri("", false, "AV64TFSGAuUsuCod_Sel", AV64TFSGAuUsuCod_Sel);
            }
            subgrid_firstpage( ) ;
         }
         /*  Sending Event outputs  */
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV70TFSGAuMod_Sels", AV70TFSGAuMod_Sels);
      }

      private void E180I2( )
      {
         /* Grid_Load Routine */
         returnInSub = false;
         /* Load Method */
         if ( wbStart != -1 )
         {
            wbStart = 57;
         }
         sendrow_572( ) ;
         GRID_nCurrentRecord = (long)(GRID_nCurrentRecord+1);
         if ( isFullAjaxMode( ) && ! bGXsfl_57_Refreshing )
         {
            DoAjaxLoad(57, GridRow);
         }
      }

      protected void E150I2( )
      {
         /* Sgaufechoperator_Click Routine */
         returnInSub = false;
         AV36SGAuFech = DateTime.MinValue;
         AssignAttri("", false, "AV36SGAuFech", context.localUtil.Format(AV36SGAuFech, "99/99/99"));
         AV38SGAuFech_To = DateTime.MinValue;
         AssignAttri("", false, "AV38SGAuFech_To", context.localUtil.Format(AV38SGAuFech_To, "99/99/99"));
         /* Execute user subroutine: 'UPDATESGAUFECHOPERATORVALUES' */
         S122 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
         gxgrGrid_refresh( subGrid_Rows, AV68UsuCod, AV40SGAuMod, AV39SGAuFechOperator, AV36SGAuFech, AV73Pgmname, AV34SGAuDocGls, AV38SGAuFech_To, AV70TFSGAuMod_Sels, AV55TFSGAuFecha, AV56TFSGAuFecha_To, AV47TFSGAuDocGls, AV48TFSGAuDocGls_Sel, AV49TFSGAuDocNum, AV50TFSGAuDocNum_Sel, AV51TFSGAuDocRef, AV52TFSGAuDocRef_Sel, AV59TFSGAuTipCod, AV60TFSGAuTipCod_Sel, AV61TFSGAuTipo, AV62TFSGAuTipo_Sel, AV63TFSGAuUsuCod, AV64TFSGAuUsuCod_Sel, AV30OrderedBy, AV31OrderedDsc, Gx_date) ;
         /*  Sending Event outputs  */
      }

      protected void E130I2( )
      {
         /* Sgaufech_rangepicker_Daterangechanged Routine */
         returnInSub = false;
         AssignAttri("", false, "AV36SGAuFech", context.localUtil.Format(AV36SGAuFech, "99/99/99"));
         AssignAttri("", false, "AV38SGAuFech_To", context.localUtil.Format(AV38SGAuFech_To, "99/99/99"));
         gxgrGrid_refresh( subGrid_Rows, AV68UsuCod, AV40SGAuMod, AV39SGAuFechOperator, AV36SGAuFech, AV73Pgmname, AV34SGAuDocGls, AV38SGAuFech_To, AV70TFSGAuMod_Sels, AV55TFSGAuFecha, AV56TFSGAuFecha_To, AV47TFSGAuDocGls, AV48TFSGAuDocGls_Sel, AV49TFSGAuDocNum, AV50TFSGAuDocNum_Sel, AV51TFSGAuDocRef, AV52TFSGAuDocRef_Sel, AV59TFSGAuTipCod, AV60TFSGAuTipCod_Sel, AV61TFSGAuTipo, AV62TFSGAuTipo_Sel, AV63TFSGAuUsuCod, AV64TFSGAuUsuCod_Sel, AV30OrderedBy, AV31OrderedDsc, Gx_date) ;
         /*  Sending Event outputs  */
      }

      protected void S142( )
      {
         /* 'SETDDOSORTEDSTATUS' Routine */
         returnInSub = false;
         Ddo_grid_Sortedstatus = StringUtil.Trim( StringUtil.Str( (decimal)(AV30OrderedBy), 4, 0))+":"+(AV31OrderedDsc ? "DSC" : "ASC");
         ucDdo_grid.SendProperty(context, "", false, Ddo_grid_Internalname, "SortedStatus", Ddo_grid_Sortedstatus);
      }

      protected void S132( )
      {
         /* 'LOADGRIDSTATE' Routine */
         returnInSub = false;
         if ( StringUtil.StrCmp(AV33Session.Get(AV73Pgmname+"GridState"), "") == 0 )
         {
            AV25GridState.FromXml(new GeneXus.Programs.wwpbaseobjects.loadgridstate(context).executeUdp(  AV73Pgmname+"GridState"), null, "", "");
         }
         else
         {
            AV25GridState.FromXml(AV33Session.Get(AV73Pgmname+"GridState"), null, "", "");
         }
         AV30OrderedBy = AV25GridState.gxTpr_Orderedby;
         AssignAttri("", false, "AV30OrderedBy", StringUtil.LTrimStr( (decimal)(AV30OrderedBy), 4, 0));
         AV31OrderedDsc = AV25GridState.gxTpr_Ordereddsc;
         AssignAttri("", false, "AV31OrderedDsc", AV31OrderedDsc);
         /* Execute user subroutine: 'SETDDOSORTEDSTATUS' */
         S142 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
         AV94GXV1 = 1;
         while ( AV94GXV1 <= AV25GridState.gxTpr_Filtervalues.Count )
         {
            AV27GridStateFilterValue = ((GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue)AV25GridState.gxTpr_Filtervalues.Item(AV94GXV1));
            if ( StringUtil.StrCmp(AV27GridStateFilterValue.gxTpr_Name, "USUCOD") == 0 )
            {
               AV68UsuCod = AV27GridStateFilterValue.gxTpr_Value;
               AssignAttri("", false, "AV68UsuCod", AV68UsuCod);
            }
            else if ( StringUtil.StrCmp(AV27GridStateFilterValue.gxTpr_Name, "SGAUMOD") == 0 )
            {
               AV40SGAuMod = AV27GridStateFilterValue.gxTpr_Value;
               AssignAttri("", false, "AV40SGAuMod", AV40SGAuMod);
            }
            else if ( StringUtil.StrCmp(AV27GridStateFilterValue.gxTpr_Name, "SGAUDOCGLS") == 0 )
            {
               AV34SGAuDocGls = AV27GridStateFilterValue.gxTpr_Value;
               AssignAttri("", false, "AV34SGAuDocGls", AV34SGAuDocGls);
            }
            else if ( StringUtil.StrCmp(AV27GridStateFilterValue.gxTpr_Name, "SGAUFECH") == 0 )
            {
               AV36SGAuFech = context.localUtil.CToD( AV27GridStateFilterValue.gxTpr_Value, 2);
               AssignAttri("", false, "AV36SGAuFech", context.localUtil.Format(AV36SGAuFech, "99/99/99"));
               AV39SGAuFechOperator = AV27GridStateFilterValue.gxTpr_Operator;
               AssignAttri("", false, "AV39SGAuFechOperator", StringUtil.LTrimStr( (decimal)(AV39SGAuFechOperator), 4, 0));
               AV38SGAuFech_To = context.localUtil.CToD( AV27GridStateFilterValue.gxTpr_Valueto, 2);
               AssignAttri("", false, "AV38SGAuFech_To", context.localUtil.Format(AV38SGAuFech_To, "99/99/99"));
               /* Execute user subroutine: 'UPDATESGAUFECHOPERATORVALUES' */
               S122 ();
               if ( returnInSub )
               {
                  returnInSub = true;
                  if (true) return;
               }
            }
            else if ( StringUtil.StrCmp(AV27GridStateFilterValue.gxTpr_Name, "TFSGAUMOD_SEL") == 0 )
            {
               AV69TFSGAuMod_SelsJson = AV27GridStateFilterValue.gxTpr_Value;
               AssignAttri("", false, "AV69TFSGAuMod_SelsJson", AV69TFSGAuMod_SelsJson);
               AV70TFSGAuMod_Sels.FromJSonString(AV69TFSGAuMod_SelsJson, null);
            }
            else if ( StringUtil.StrCmp(AV27GridStateFilterValue.gxTpr_Name, "TFSGAUFECHA") == 0 )
            {
               AV55TFSGAuFecha = context.localUtil.CToT( AV27GridStateFilterValue.gxTpr_Value, 2);
               AssignAttri("", false, "AV55TFSGAuFecha", context.localUtil.TToC( AV55TFSGAuFecha, 8, 5, 0, 3, "/", ":", " "));
               AV56TFSGAuFecha_To = context.localUtil.CToT( AV27GridStateFilterValue.gxTpr_Valueto, 2);
               AssignAttri("", false, "AV56TFSGAuFecha_To", context.localUtil.TToC( AV56TFSGAuFecha_To, 8, 5, 0, 3, "/", ":", " "));
               AV5DDO_SGAuFechaAuxDate = DateTimeUtil.ResetTime(AV55TFSGAuFecha);
               AssignAttri("", false, "AV5DDO_SGAuFechaAuxDate", context.localUtil.Format(AV5DDO_SGAuFechaAuxDate, "99/99/99"));
               AV7DDO_SGAuFechaAuxDateTo = DateTimeUtil.ResetTime(AV56TFSGAuFecha_To);
               AssignAttri("", false, "AV7DDO_SGAuFechaAuxDateTo", context.localUtil.Format(AV7DDO_SGAuFechaAuxDateTo, "99/99/99"));
            }
            else if ( StringUtil.StrCmp(AV27GridStateFilterValue.gxTpr_Name, "TFSGAUDOCGLS") == 0 )
            {
               AV47TFSGAuDocGls = AV27GridStateFilterValue.gxTpr_Value;
               AssignAttri("", false, "AV47TFSGAuDocGls", AV47TFSGAuDocGls);
            }
            else if ( StringUtil.StrCmp(AV27GridStateFilterValue.gxTpr_Name, "TFSGAUDOCGLS_SEL") == 0 )
            {
               AV48TFSGAuDocGls_Sel = AV27GridStateFilterValue.gxTpr_Value;
               AssignAttri("", false, "AV48TFSGAuDocGls_Sel", AV48TFSGAuDocGls_Sel);
            }
            else if ( StringUtil.StrCmp(AV27GridStateFilterValue.gxTpr_Name, "TFSGAUDOCNUM") == 0 )
            {
               AV49TFSGAuDocNum = AV27GridStateFilterValue.gxTpr_Value;
               AssignAttri("", false, "AV49TFSGAuDocNum", AV49TFSGAuDocNum);
            }
            else if ( StringUtil.StrCmp(AV27GridStateFilterValue.gxTpr_Name, "TFSGAUDOCNUM_SEL") == 0 )
            {
               AV50TFSGAuDocNum_Sel = AV27GridStateFilterValue.gxTpr_Value;
               AssignAttri("", false, "AV50TFSGAuDocNum_Sel", AV50TFSGAuDocNum_Sel);
            }
            else if ( StringUtil.StrCmp(AV27GridStateFilterValue.gxTpr_Name, "TFSGAUDOCREF") == 0 )
            {
               AV51TFSGAuDocRef = AV27GridStateFilterValue.gxTpr_Value;
               AssignAttri("", false, "AV51TFSGAuDocRef", AV51TFSGAuDocRef);
            }
            else if ( StringUtil.StrCmp(AV27GridStateFilterValue.gxTpr_Name, "TFSGAUDOCREF_SEL") == 0 )
            {
               AV52TFSGAuDocRef_Sel = AV27GridStateFilterValue.gxTpr_Value;
               AssignAttri("", false, "AV52TFSGAuDocRef_Sel", AV52TFSGAuDocRef_Sel);
            }
            else if ( StringUtil.StrCmp(AV27GridStateFilterValue.gxTpr_Name, "TFSGAUTIPCOD") == 0 )
            {
               AV59TFSGAuTipCod = AV27GridStateFilterValue.gxTpr_Value;
               AssignAttri("", false, "AV59TFSGAuTipCod", AV59TFSGAuTipCod);
            }
            else if ( StringUtil.StrCmp(AV27GridStateFilterValue.gxTpr_Name, "TFSGAUTIPCOD_SEL") == 0 )
            {
               AV60TFSGAuTipCod_Sel = AV27GridStateFilterValue.gxTpr_Value;
               AssignAttri("", false, "AV60TFSGAuTipCod_Sel", AV60TFSGAuTipCod_Sel);
            }
            else if ( StringUtil.StrCmp(AV27GridStateFilterValue.gxTpr_Name, "TFSGAUTIPO") == 0 )
            {
               AV61TFSGAuTipo = AV27GridStateFilterValue.gxTpr_Value;
               AssignAttri("", false, "AV61TFSGAuTipo", AV61TFSGAuTipo);
            }
            else if ( StringUtil.StrCmp(AV27GridStateFilterValue.gxTpr_Name, "TFSGAUTIPO_SEL") == 0 )
            {
               AV62TFSGAuTipo_Sel = AV27GridStateFilterValue.gxTpr_Value;
               AssignAttri("", false, "AV62TFSGAuTipo_Sel", AV62TFSGAuTipo_Sel);
            }
            else if ( StringUtil.StrCmp(AV27GridStateFilterValue.gxTpr_Name, "TFSGAUUSUCOD") == 0 )
            {
               AV63TFSGAuUsuCod = AV27GridStateFilterValue.gxTpr_Value;
               AssignAttri("", false, "AV63TFSGAuUsuCod", AV63TFSGAuUsuCod);
            }
            else if ( StringUtil.StrCmp(AV27GridStateFilterValue.gxTpr_Name, "TFSGAUUSUCOD_SEL") == 0 )
            {
               AV64TFSGAuUsuCod_Sel = AV27GridStateFilterValue.gxTpr_Value;
               AssignAttri("", false, "AV64TFSGAuUsuCod_Sel", AV64TFSGAuUsuCod_Sel);
            }
            AV94GXV1 = (int)(AV94GXV1+1);
         }
         GXt_char2 = "";
         new GeneXus.Programs.wwpbaseobjects.wwp_getfilterval(context ).execute(  (AV70TFSGAuMod_Sels.Count==0),  AV69TFSGAuMod_SelsJson, out  GXt_char2) ;
         GXt_char3 = "";
         new GeneXus.Programs.wwpbaseobjects.wwp_getfilterval(context ).execute(  String.IsNullOrEmpty(StringUtil.RTrim( AV48TFSGAuDocGls_Sel)),  AV48TFSGAuDocGls_Sel, out  GXt_char3) ;
         GXt_char4 = "";
         new GeneXus.Programs.wwpbaseobjects.wwp_getfilterval(context ).execute(  String.IsNullOrEmpty(StringUtil.RTrim( AV50TFSGAuDocNum_Sel)),  AV50TFSGAuDocNum_Sel, out  GXt_char4) ;
         GXt_char5 = "";
         new GeneXus.Programs.wwpbaseobjects.wwp_getfilterval(context ).execute(  String.IsNullOrEmpty(StringUtil.RTrim( AV52TFSGAuDocRef_Sel)),  AV52TFSGAuDocRef_Sel, out  GXt_char5) ;
         GXt_char6 = "";
         new GeneXus.Programs.wwpbaseobjects.wwp_getfilterval(context ).execute(  String.IsNullOrEmpty(StringUtil.RTrim( AV60TFSGAuTipCod_Sel)),  AV60TFSGAuTipCod_Sel, out  GXt_char6) ;
         GXt_char7 = "";
         new GeneXus.Programs.wwpbaseobjects.wwp_getfilterval(context ).execute(  String.IsNullOrEmpty(StringUtil.RTrim( AV62TFSGAuTipo_Sel)),  AV62TFSGAuTipo_Sel, out  GXt_char7) ;
         GXt_char8 = "";
         new GeneXus.Programs.wwpbaseobjects.wwp_getfilterval(context ).execute(  String.IsNullOrEmpty(StringUtil.RTrim( AV64TFSGAuUsuCod_Sel)),  AV64TFSGAuUsuCod_Sel, out  GXt_char8) ;
         Ddo_grid_Selectedvalue_set = GXt_char2+"||"+GXt_char3+"|"+GXt_char4+"|"+GXt_char5+"|"+GXt_char6+"|"+GXt_char7+"|"+GXt_char8;
         ucDdo_grid.SendProperty(context, "", false, Ddo_grid_Internalname, "SelectedValue_set", Ddo_grid_Selectedvalue_set);
         GXt_char8 = "";
         new GeneXus.Programs.wwpbaseobjects.wwp_getfilterval(context ).execute(  String.IsNullOrEmpty(StringUtil.RTrim( AV47TFSGAuDocGls)),  AV47TFSGAuDocGls, out  GXt_char8) ;
         GXt_char7 = "";
         new GeneXus.Programs.wwpbaseobjects.wwp_getfilterval(context ).execute(  String.IsNullOrEmpty(StringUtil.RTrim( AV49TFSGAuDocNum)),  AV49TFSGAuDocNum, out  GXt_char7) ;
         GXt_char6 = "";
         new GeneXus.Programs.wwpbaseobjects.wwp_getfilterval(context ).execute(  String.IsNullOrEmpty(StringUtil.RTrim( AV51TFSGAuDocRef)),  AV51TFSGAuDocRef, out  GXt_char6) ;
         GXt_char5 = "";
         new GeneXus.Programs.wwpbaseobjects.wwp_getfilterval(context ).execute(  String.IsNullOrEmpty(StringUtil.RTrim( AV59TFSGAuTipCod)),  AV59TFSGAuTipCod, out  GXt_char5) ;
         GXt_char4 = "";
         new GeneXus.Programs.wwpbaseobjects.wwp_getfilterval(context ).execute(  String.IsNullOrEmpty(StringUtil.RTrim( AV61TFSGAuTipo)),  AV61TFSGAuTipo, out  GXt_char4) ;
         GXt_char3 = "";
         new GeneXus.Programs.wwpbaseobjects.wwp_getfilterval(context ).execute(  String.IsNullOrEmpty(StringUtil.RTrim( AV63TFSGAuUsuCod)),  AV63TFSGAuUsuCod, out  GXt_char3) ;
         Ddo_grid_Filteredtext_set = "|"+((DateTime.MinValue==AV55TFSGAuFecha) ? "" : context.localUtil.DToC( AV5DDO_SGAuFechaAuxDate, 2, "/"))+"|"+GXt_char8+"|"+GXt_char7+"|"+GXt_char6+"|"+GXt_char5+"|"+GXt_char4+"|"+GXt_char3;
         ucDdo_grid.SendProperty(context, "", false, Ddo_grid_Internalname, "FilteredText_set", Ddo_grid_Filteredtext_set);
         Ddo_grid_Filteredtextto_set = "|"+((DateTime.MinValue==AV56TFSGAuFecha_To) ? "" : context.localUtil.DToC( AV7DDO_SGAuFechaAuxDateTo, 2, "/"))+"||||||";
         ucDdo_grid.SendProperty(context, "", false, Ddo_grid_Internalname, "FilteredTextTo_set", Ddo_grid_Filteredtextto_set);
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( StringUtil.Trim( AV25GridState.gxTpr_Pagesize))) )
         {
            subGrid_Rows = (int)(NumberUtil.Val( AV25GridState.gxTpr_Pagesize, "."));
            GxWebStd.gx_hidden_field( context, "GRID_Rows", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid_Rows), 6, 0, ".", "")));
         }
         subgrid_gotopage( AV25GridState.gxTpr_Currentpage) ;
      }

      protected void S152( )
      {
         /* 'SAVEGRIDSTATE' Routine */
         returnInSub = false;
         AV25GridState.FromXml(AV33Session.Get(AV73Pgmname+"GridState"), null, "", "");
         AV25GridState.gxTpr_Orderedby = AV30OrderedBy;
         AV25GridState.gxTpr_Ordereddsc = AV31OrderedDsc;
         AV25GridState.gxTpr_Filtervalues.Clear();
         new GeneXus.Programs.wwpbaseobjects.wwp_gridstateaddfiltervalue(context ).execute( ref  AV25GridState,  "USUCOD",  "Usuario",  !String.IsNullOrEmpty(StringUtil.RTrim( AV68UsuCod)),  0,  AV68UsuCod,  "") ;
         new GeneXus.Programs.wwpbaseobjects.wwp_gridstateaddfiltervalue(context ).execute( ref  AV25GridState,  "SGAUMOD",  "Modulo",  !String.IsNullOrEmpty(StringUtil.RTrim( AV40SGAuMod)),  0,  AV40SGAuMod,  "") ;
         new GeneXus.Programs.wwpbaseobjects.wwp_gridstateaddfiltervalue(context ).execute( ref  AV25GridState,  "SGAUDOCGLS",  "Glosa",  !String.IsNullOrEmpty(StringUtil.RTrim( AV34SGAuDocGls)),  0,  AV34SGAuDocGls,  "") ;
         new GeneXus.Programs.wwpbaseobjects.wwp_gridstateaddfiltervalue(context ).execute( ref  AV25GridState,  "SGAUFECH",  "Fecha",  true,  AV39SGAuFechOperator,  StringUtil.Trim( context.localUtil.DToC( AV36SGAuFech, 2, "/")),  StringUtil.Trim( context.localUtil.DToC( AV38SGAuFech_To, 2, "/"))) ;
         new GeneXus.Programs.wwpbaseobjects.wwp_gridstateaddfiltervalue(context ).execute( ref  AV25GridState,  "TFSGAUMOD_SEL",  "Modulo",  !(AV70TFSGAuMod_Sels.Count==0),  0,  AV70TFSGAuMod_Sels.ToJSonString(false),  "") ;
         new GeneXus.Programs.wwpbaseobjects.wwp_gridstateaddfiltervalue(context ).execute( ref  AV25GridState,  "TFSGAUFECHA",  "Fecha Hora",  !((DateTime.MinValue==AV55TFSGAuFecha)&&(DateTime.MinValue==AV56TFSGAuFecha_To)),  0,  StringUtil.Trim( context.localUtil.TToC( AV55TFSGAuFecha, 8, 5, 0, 3, "/", ":", " ")),  StringUtil.Trim( context.localUtil.TToC( AV56TFSGAuFecha_To, 8, 5, 0, 3, "/", ":", " "))) ;
         new GeneXus.Programs.wwpbaseobjects.wwp_gridstateaddfiltervalueandsel(context ).execute( ref  AV25GridState,  "TFSGAUDOCGLS",  "Glosa",  !String.IsNullOrEmpty(StringUtil.RTrim( AV47TFSGAuDocGls)),  0,  AV47TFSGAuDocGls,  "",  !String.IsNullOrEmpty(StringUtil.RTrim( AV48TFSGAuDocGls_Sel)),  AV48TFSGAuDocGls_Sel,  "") ;
         new GeneXus.Programs.wwpbaseobjects.wwp_gridstateaddfiltervalueandsel(context ).execute( ref  AV25GridState,  "TFSGAUDOCNUM",  "N° Documento",  !String.IsNullOrEmpty(StringUtil.RTrim( AV49TFSGAuDocNum)),  0,  AV49TFSGAuDocNum,  "",  !String.IsNullOrEmpty(StringUtil.RTrim( AV50TFSGAuDocNum_Sel)),  AV50TFSGAuDocNum_Sel,  "") ;
         new GeneXus.Programs.wwpbaseobjects.wwp_gridstateaddfiltervalueandsel(context ).execute( ref  AV25GridState,  "TFSGAUDOCREF",  "Doc.Referencia",  !String.IsNullOrEmpty(StringUtil.RTrim( AV51TFSGAuDocRef)),  0,  AV51TFSGAuDocRef,  "",  !String.IsNullOrEmpty(StringUtil.RTrim( AV52TFSGAuDocRef_Sel)),  AV52TFSGAuDocRef_Sel,  "") ;
         new GeneXus.Programs.wwpbaseobjects.wwp_gridstateaddfiltervalueandsel(context ).execute( ref  AV25GridState,  "TFSGAUTIPCOD",  "Tipo Documento",  !String.IsNullOrEmpty(StringUtil.RTrim( AV59TFSGAuTipCod)),  0,  AV59TFSGAuTipCod,  "",  !String.IsNullOrEmpty(StringUtil.RTrim( AV60TFSGAuTipCod_Sel)),  AV60TFSGAuTipCod_Sel,  "") ;
         new GeneXus.Programs.wwpbaseobjects.wwp_gridstateaddfiltervalueandsel(context ).execute( ref  AV25GridState,  "TFSGAUTIPO",  "Tipo",  !String.IsNullOrEmpty(StringUtil.RTrim( AV61TFSGAuTipo)),  0,  AV61TFSGAuTipo,  "",  !String.IsNullOrEmpty(StringUtil.RTrim( AV62TFSGAuTipo_Sel)),  AV62TFSGAuTipo_Sel,  "") ;
         new GeneXus.Programs.wwpbaseobjects.wwp_gridstateaddfiltervalueandsel(context ).execute( ref  AV25GridState,  "TFSGAUUSUCOD",  "Usuario",  !String.IsNullOrEmpty(StringUtil.RTrim( AV63TFSGAuUsuCod)),  0,  AV63TFSGAuUsuCod,  "",  !String.IsNullOrEmpty(StringUtil.RTrim( AV64TFSGAuUsuCod_Sel)),  AV64TFSGAuUsuCod_Sel,  "") ;
         AV25GridState.gxTpr_Pagesize = StringUtil.Str( (decimal)(subGrid_Rows), 10, 0);
         AV25GridState.gxTpr_Currentpage = (short)(subGrid_fnc_Currentpage( ));
         new GeneXus.Programs.wwpbaseobjects.savegridstate(context ).execute(  AV73Pgmname+"GridState",  AV25GridState.ToXml(false, true, "", "")) ;
      }

      protected void S112( )
      {
         /* 'PREPARETRANSACTION' Routine */
         returnInSub = false;
         AV65TrnContext = new GeneXus.Programs.wwpbaseobjects.SdtWWPTransactionContext(context);
         AV65TrnContext.gxTpr_Callerobject = AV73Pgmname;
         AV65TrnContext.gxTpr_Callerondelete = true;
         AV65TrnContext.gxTpr_Callerurl = AV28HTTPRequest.ScriptName+"?"+AV28HTTPRequest.QueryString;
         AV65TrnContext.gxTpr_Transactionname = "SGAUDITORIA";
         AV33Session.Set("TrnContext", AV65TrnContext.ToXml(false, true, "", ""));
      }

      protected void S122( )
      {
         /* 'UPDATESGAUFECHOPERATORVALUES' Routine */
         returnInSub = false;
         cellSgaufech_range_cell_Class = "Invisible";
         AssignProp("", false, cellSgaufech_range_cell_Internalname, "Class", cellSgaufech_range_cell_Class, true);
         if ( AV39SGAuFechOperator == 0 )
         {
            AV36SGAuFech = Gx_date;
            AssignAttri("", false, "AV36SGAuFech", context.localUtil.Format(AV36SGAuFech, "99/99/99"));
         }
         else if ( AV39SGAuFechOperator == 1 )
         {
            AV36SGAuFech = Gx_date;
            AssignAttri("", false, "AV36SGAuFech", context.localUtil.Format(AV36SGAuFech, "99/99/99"));
         }
         else if ( AV39SGAuFechOperator == 2 )
         {
            AV36SGAuFech = Gx_date;
            AssignAttri("", false, "AV36SGAuFech", context.localUtil.Format(AV36SGAuFech, "99/99/99"));
         }
         else if ( AV39SGAuFechOperator == 3 )
         {
            cellSgaufech_range_cell_Class = "";
            AssignProp("", false, cellSgaufech_range_cell_Internalname, "Class", cellSgaufech_range_cell_Class, true);
         }
      }

      protected void wb_table1_38_0I2( bool wbgen )
      {
         if ( wbgen )
         {
            /* Table start */
            sStyleString = "";
            GxWebStd.gx_table_start( context, tblTablemergedsgaufech_Internalname, tblTablemergedsgaufech_Internalname, "", "TableMerged", 0, "", "", 0, 0, sStyleString, "", "", 0);
            context.WriteHtmlText( "<tr>") ;
            context.WriteHtmlText( "<td class='MergeDataCell'>") ;
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "left", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, cmbavSgaufechoperator_Internalname, "SGAu Fech Operator", "gx-form-item AttributeLabel", 0, true, "width: 25%;");
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 42,'',false,'" + sGXsfl_57_idx + "',0)\"";
            /* ComboBox */
            GxWebStd.gx_combobox_ctrl1( context, cmbavSgaufechoperator, cmbavSgaufechoperator_Internalname, StringUtil.Trim( StringUtil.Str( (decimal)(AV39SGAuFechOperator), 4, 0)), 1, cmbavSgaufechoperator_Jsonclick, 5, "'"+""+"'"+",false,"+"'"+"EVSGAUFECHOPERATOR.CLICK."+"'", "int", "", 1, cmbavSgaufechoperator.Enabled, 0, 0, 0, "em", 0, "", "", "Attribute", "", "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,42);\"", "", true, 1, "HLP_Seguridad\\Auditoria.htm");
            cmbavSgaufechoperator.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV39SGAuFechOperator), 4, 0));
            AssignProp("", false, cmbavSgaufechoperator_Internalname, "Values", (string)(cmbavSgaufechoperator.ToJavascriptSource()), true);
            GxWebStd.gx_div_end( context, "left", "top", "div");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "<td id=\""+cellSgaufech_range_cell_Internalname+"\"  class='"+cellSgaufech_range_cell_Class+"'>") ;
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "left", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavSgaufech_rangetext_Internalname, "SGAu Fech_Range Text", "gx-form-item AttributeLabel", 0, true, "width: 25%;");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 45,'',false,'" + sGXsfl_57_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavSgaufech_rangetext_Internalname, AV37SGAuFech_RangeText, StringUtil.RTrim( context.localUtil.Format( AV37SGAuFech_RangeText, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,45);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavSgaufech_rangetext_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtavSgaufech_rangetext_Enabled, 0, "text", "", 40, "chr", 1, "row", 40, 0, 0, 0, 1, -1, -1, true, "", "left", true, "", "HLP_Seguridad\\Auditoria.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "</tr>") ;
            /* End of table */
            context.WriteHtmlText( "</table>") ;
            wb_table1_38_0I2e( true) ;
         }
         else
         {
            wb_table1_38_0I2e( false) ;
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
         PA0I2( ) ;
         WS0I2( ) ;
         WE0I2( ) ;
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
            context.AddJavascriptSource(StringUtil.RTrim( ((string)Form.Jscriptsrc.Item(idxLst))), "?20228181028276", true, true);
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
         context.AddJavascriptSource("seguridad/auditoria.js", "?20228181028277", false, true);
         context.AddJavascriptSource("DVelop/Bootstrap/Shared/DVelopBootstrap.js", "", false, true);
         context.AddJavascriptSource("DVelop/Shared/WorkWithPlusCommon.js", "", false, true);
         context.AddJavascriptSource("DVelop/Bootstrap/Panel/BootstrapPanelRender.js", "", false, true);
         context.AddJavascriptSource("DVelop/Bootstrap/Shared/DVelopBootstrap.js", "", false, true);
         context.AddJavascriptSource("DVelop/Shared/WorkWithPlusCommon.js", "", false, true);
         context.AddJavascriptSource("DVelop/DVPaginationBar/DVPaginationBarRender.js", "", false, true);
         context.AddJavascriptSource("DVelop/Shared/daterangepicker/locales.js", "", false, true);
         context.AddJavascriptSource("DVelop/Shared/daterangepicker/wwp-daterangepicker.js", "", false, true);
         context.AddJavascriptSource("DVelop/Shared/daterangepicker/moment.min.js", "", false, true);
         context.AddJavascriptSource("DVelop/Shared/daterangepicker/daterangepicker.min.js", "", false, true);
         context.AddJavascriptSource("DVelop/Shared/WorkWithPlusCommon.js", "", false, true);
         context.AddJavascriptSource("DVelop/DateRangePicker/DateRangePickerRender.js", "", false, true);
         context.AddJavascriptSource("DVelop/Bootstrap/Shared/DVelopBootstrap.js", "", false, true);
         context.AddJavascriptSource("DVelop/Shared/WorkWithPlusCommon.js", "", false, true);
         context.AddJavascriptSource("DVelop/Bootstrap/DropDownOptions/BootstrapDropDownOptionsRender.js", "", false, true);
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

      protected void SubsflControlProps_572( )
      {
         cmbSGAuMod_Internalname = "SGAUMOD_"+sGXsfl_57_idx;
         edtSGAuFecha_Internalname = "SGAUFECHA_"+sGXsfl_57_idx;
         edtSGAuDocGls_Internalname = "SGAUDOCGLS_"+sGXsfl_57_idx;
         edtSGAuDocNum_Internalname = "SGAUDOCNUM_"+sGXsfl_57_idx;
         edtSGAuDocRef_Internalname = "SGAUDOCREF_"+sGXsfl_57_idx;
         edtSGAuTipCod_Internalname = "SGAUTIPCOD_"+sGXsfl_57_idx;
         edtSGAuTipo_Internalname = "SGAUTIPO_"+sGXsfl_57_idx;
         edtSGAuUsuCod_Internalname = "SGAUUSUCOD_"+sGXsfl_57_idx;
         edtSGAuFech_Internalname = "SGAUFECH_"+sGXsfl_57_idx;
      }

      protected void SubsflControlProps_fel_572( )
      {
         cmbSGAuMod_Internalname = "SGAUMOD_"+sGXsfl_57_fel_idx;
         edtSGAuFecha_Internalname = "SGAUFECHA_"+sGXsfl_57_fel_idx;
         edtSGAuDocGls_Internalname = "SGAUDOCGLS_"+sGXsfl_57_fel_idx;
         edtSGAuDocNum_Internalname = "SGAUDOCNUM_"+sGXsfl_57_fel_idx;
         edtSGAuDocRef_Internalname = "SGAUDOCREF_"+sGXsfl_57_fel_idx;
         edtSGAuTipCod_Internalname = "SGAUTIPCOD_"+sGXsfl_57_fel_idx;
         edtSGAuTipo_Internalname = "SGAUTIPO_"+sGXsfl_57_fel_idx;
         edtSGAuUsuCod_Internalname = "SGAUUSUCOD_"+sGXsfl_57_fel_idx;
         edtSGAuFech_Internalname = "SGAUFECH_"+sGXsfl_57_fel_idx;
      }

      protected void sendrow_572( )
      {
         SubsflControlProps_572( ) ;
         WB0I0( ) ;
         if ( ( subGrid_Rows * 1 == 0 ) || ( nGXsfl_57_idx <= subGrid_fnc_Recordsperpage( ) * 1 ) )
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
               if ( ((int)((nGXsfl_57_idx) % (2))) == 0 )
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
               context.WriteHtmlText( " gxrow=\""+sGXsfl_57_idx+"\">") ;
            }
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"left"+"\""+" style=\""+""+"\">") ;
            }
            if ( ( cmbSGAuMod.ItemCount == 0 ) && isAjaxCallMode( ) )
            {
               GXCCtl = "SGAUMOD_" + sGXsfl_57_idx;
               cmbSGAuMod.Name = GXCCtl;
               cmbSGAuMod.WebTags = "";
               cmbSGAuMod.addItem("SEG", "Seguridad", 0);
               cmbSGAuMod.addItem("CLI", "Ventas", 0);
               cmbSGAuMod.addItem("PRV", "Compras", 0);
               cmbSGAuMod.addItem("TES", "Bancos", 0);
               cmbSGAuMod.addItem("CON", "Contabilidad", 0);
               cmbSGAuMod.addItem("PRO", "Producción", 0);
               cmbSGAuMod.addItem("PLA", "Planilla", 0);
               cmbSGAuMod.addItem("ALM", "Almacen", 0);
               cmbSGAuMod.addItem("OTR", "Otros", 0);
               if ( cmbSGAuMod.ItemCount > 0 )
               {
                  A337SGAuMod = cmbSGAuMod.getValidValue(A337SGAuMod);
               }
            }
            /* ComboBox */
            GridRow.AddColumnProperties("combobox", 2, isAjaxCallMode( ), new Object[] {(GXCombobox)cmbSGAuMod,(string)cmbSGAuMod_Internalname,StringUtil.RTrim( A337SGAuMod),(short)1,(string)cmbSGAuMod_Jsonclick,(short)0,(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"svchar",(string)"",(short)-1,(short)0,(short)0,(short)0,(short)0,(string)"px",(short)0,(string)"px",(string)"",(string)"Attribute",(string)"WWColumn hidden-xs",(string)"",(string)"",(string)"",(bool)true,(short)1});
            cmbSGAuMod.CurrentValue = StringUtil.RTrim( A337SGAuMod);
            AssignProp("", false, cmbSGAuMod_Internalname, "Values", (string)(cmbSGAuMod.ToJavascriptSource()), !bGXsfl_57_Refreshing);
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"right"+"\""+" style=\""+""+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtSGAuFecha_Internalname,context.localUtil.TToC( A338SGAuFecha, 10, 8, 0, 3, "/", ":", " "),context.localUtil.Format( A338SGAuFecha, "99/99/99 99:99"),(string)"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtSGAuFecha_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn",(string)"",(short)-1,(short)0,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)14,(short)0,(short)0,(short)57,(short)1,(short)-1,(short)0,(bool)true,(string)"",(string)"right",(bool)false,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"left"+"\""+" style=\""+""+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtSGAuDocGls_Internalname,(string)A1843SGAuDocGls,(string)"",(string)"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtSGAuDocGls_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn",(string)"",(short)-1,(short)0,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)100,(short)0,(short)0,(short)57,(short)1,(short)-1,(short)-1,(bool)true,(string)"",(string)"left",(bool)true,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"left"+"\""+" style=\""+""+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtSGAuDocNum_Internalname,(string)A1844SGAuDocNum,(string)"",(string)"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtSGAuDocNum_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn hidden-xs",(string)"",(short)-1,(short)0,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)20,(short)0,(short)0,(short)57,(short)1,(short)-1,(short)-1,(bool)true,(string)"",(string)"left",(bool)true,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"left"+"\""+" style=\""+""+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtSGAuDocRef_Internalname,(string)A1845SGAuDocRef,(string)"",(string)"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtSGAuDocRef_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn hidden-xs",(string)"",(short)-1,(short)0,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)20,(short)0,(short)0,(short)57,(short)1,(short)-1,(short)-1,(bool)true,(string)"",(string)"left",(bool)true,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"left"+"\""+" style=\""+""+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtSGAuTipCod_Internalname,(string)A1847SGAuTipCod,(string)"",(string)"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtSGAuTipCod_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn",(string)"",(short)-1,(short)0,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)5,(short)0,(short)0,(short)57,(short)1,(short)-1,(short)-1,(bool)true,(string)"",(string)"left",(bool)true,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"left"+"\""+" style=\""+""+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtSGAuTipo_Internalname,(string)A1848SGAuTipo,(string)"",(string)"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtSGAuTipo_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn hidden-xs",(string)"",(short)-1,(short)0,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)20,(short)0,(short)0,(short)57,(short)1,(short)-1,(short)-1,(bool)true,(string)"",(string)"left",(bool)true,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"left"+"\""+" style=\""+""+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtSGAuUsuCod_Internalname,(string)A1849SGAuUsuCod,(string)"",(string)"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtSGAuUsuCod_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn hidden-xs",(string)"",(short)-1,(short)0,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)10,(short)0,(short)0,(short)57,(short)1,(short)-1,(short)-1,(bool)true,(string)"",(string)"left",(bool)true,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"right"+"\""+" style=\""+"display:none;"+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtSGAuFech_Internalname,context.localUtil.Format(A1846SGAuFech, "99/99/99"),context.localUtil.Format( A1846SGAuFech, "99/99/99"),(string)"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtSGAuFech_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn hidden-xs",(string)"",(short)0,(short)0,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)8,(short)0,(short)0,(short)57,(short)1,(short)-1,(short)0,(bool)true,(string)"",(string)"right",(bool)false,(string)""});
            send_integrity_lvl_hashes0I2( ) ;
            GridContainer.AddRow(GridRow);
            nGXsfl_57_idx = ((subGrid_Islastpage==1)&&(nGXsfl_57_idx+1>subGrid_fnc_Recordsperpage( )) ? 1 : nGXsfl_57_idx+1);
            sGXsfl_57_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_57_idx), 4, 0), 4, "0");
            SubsflControlProps_572( ) ;
         }
         /* End function sendrow_572 */
      }

      protected void init_web_controls( )
      {
         dynavUsucod.Name = "vUSUCOD";
         dynavUsucod.WebTags = "";
         cmbavSgaumod.Name = "vSGAUMOD";
         cmbavSgaumod.WebTags = "";
         cmbavSgaumod.addItem("", "(Ninguno)", 0);
         cmbavSgaumod.addItem("SEG", "Seguridad", 0);
         cmbavSgaumod.addItem("CLI", "Ventas", 0);
         cmbavSgaumod.addItem("PRV", "Compras", 0);
         cmbavSgaumod.addItem("TES", "Bancos", 0);
         cmbavSgaumod.addItem("CON", "Contabilidad", 0);
         cmbavSgaumod.addItem("PRO", "Producción", 0);
         cmbavSgaumod.addItem("PLA", "Planilla", 0);
         cmbavSgaumod.addItem("ALM", "Almacen", 0);
         cmbavSgaumod.addItem("OTR", "Otros", 0);
         if ( cmbavSgaumod.ItemCount > 0 )
         {
            AV40SGAuMod = cmbavSgaumod.getValidValue(AV40SGAuMod);
            AssignAttri("", false, "AV40SGAuMod", AV40SGAuMod);
         }
         cmbavSgaufechoperator.Name = "vSGAUFECHOPERATOR";
         cmbavSgaufechoperator.WebTags = "";
         cmbavSgaufechoperator.addItem("0", "Hoy", 0);
         cmbavSgaufechoperator.addItem("1", "Pasado", 0);
         cmbavSgaufechoperator.addItem("2", "En el futuro", 0);
         cmbavSgaufechoperator.addItem("3", "Período", 0);
         if ( cmbavSgaufechoperator.ItemCount > 0 )
         {
            AV39SGAuFechOperator = (short)(NumberUtil.Val( cmbavSgaufechoperator.getValidValue(StringUtil.Trim( StringUtil.Str( (decimal)(AV39SGAuFechOperator), 4, 0))), "."));
            AssignAttri("", false, "AV39SGAuFechOperator", StringUtil.LTrimStr( (decimal)(AV39SGAuFechOperator), 4, 0));
         }
         GXCCtl = "SGAUMOD_" + sGXsfl_57_idx;
         cmbSGAuMod.Name = GXCCtl;
         cmbSGAuMod.WebTags = "";
         cmbSGAuMod.addItem("SEG", "Seguridad", 0);
         cmbSGAuMod.addItem("CLI", "Ventas", 0);
         cmbSGAuMod.addItem("PRV", "Compras", 0);
         cmbSGAuMod.addItem("TES", "Bancos", 0);
         cmbSGAuMod.addItem("CON", "Contabilidad", 0);
         cmbSGAuMod.addItem("PRO", "Producción", 0);
         cmbSGAuMod.addItem("PLA", "Planilla", 0);
         cmbSGAuMod.addItem("ALM", "Almacen", 0);
         cmbSGAuMod.addItem("OTR", "Otros", 0);
         if ( cmbSGAuMod.ItemCount > 0 )
         {
            A337SGAuMod = cmbSGAuMod.getValidValue(A337SGAuMod);
         }
         /* End function init_web_controls */
      }

      protected void init_default_properties( )
      {
         dynavUsucod_Internalname = "vUSUCOD";
         cmbavSgaumod_Internalname = "vSGAUMOD";
         edtavSgaudocgls_Internalname = "vSGAUDOCGLS";
         lblFiltertextsgaufech_Internalname = "FILTERTEXTSGAUFECH";
         cmbavSgaufechoperator_Internalname = "vSGAUFECHOPERATOR";
         edtavSgaufech_rangetext_Internalname = "vSGAUFECH_RANGETEXT";
         cellSgaufech_range_cell_Internalname = "SGAUFECH_RANGE_CELL";
         tblTablemergedsgaufech_Internalname = "TABLEMERGEDSGAUFECH";
         divTablesplittedfiltertextsgaufech_Internalname = "TABLESPLITTEDFILTERTEXTSGAUFECH";
         divTablafiltros_Internalname = "TABLAFILTROS";
         divTableactions_Internalname = "TABLEACTIONS";
         divTablerightheader_Internalname = "TABLERIGHTHEADER";
         divTableheadercontent_Internalname = "TABLEHEADERCONTENT";
         divTableheader_Internalname = "TABLEHEADER";
         Dvpanel_tableheader_Internalname = "DVPANEL_TABLEHEADER";
         cmbSGAuMod_Internalname = "SGAUMOD";
         edtSGAuFecha_Internalname = "SGAUFECHA";
         edtSGAuDocGls_Internalname = "SGAUDOCGLS";
         edtSGAuDocNum_Internalname = "SGAUDOCNUM";
         edtSGAuDocRef_Internalname = "SGAUDOCREF";
         edtSGAuTipCod_Internalname = "SGAUTIPCOD";
         edtSGAuTipo_Internalname = "SGAUTIPO";
         edtSGAuUsuCod_Internalname = "SGAUUSUCOD";
         edtSGAuFech_Internalname = "SGAUFECH";
         Gridpaginationbar_Internalname = "GRIDPAGINATIONBAR";
         divGridtablewithpaginationbar_Internalname = "GRIDTABLEWITHPAGINATIONBAR";
         divTablemain_Internalname = "TABLEMAIN";
         Sgaufech_rangepicker_Internalname = "SGAUFECH_RANGEPICKER";
         Ddo_grid_Internalname = "DDO_GRID";
         Grid_empowerer_Internalname = "GRID_EMPOWERER";
         edtavDdo_sgaufechaauxdatetext_Internalname = "vDDO_SGAUFECHAAUXDATETEXT";
         Tfsgaufecha_rangepicker_Internalname = "TFSGAUFECHA_RANGEPICKER";
         divDdo_sgaufechaauxdates_Internalname = "DDO_SGAUFECHAAUXDATES";
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
         edtSGAuFech_Jsonclick = "";
         edtSGAuUsuCod_Jsonclick = "";
         edtSGAuTipo_Jsonclick = "";
         edtSGAuTipCod_Jsonclick = "";
         edtSGAuDocRef_Jsonclick = "";
         edtSGAuDocNum_Jsonclick = "";
         edtSGAuDocGls_Jsonclick = "";
         edtSGAuFecha_Jsonclick = "";
         cmbSGAuMod_Jsonclick = "";
         edtavSgaufech_rangetext_Jsonclick = "";
         edtavSgaufech_rangetext_Enabled = 1;
         cellSgaufech_range_cell_Class = "";
         cmbavSgaufechoperator_Jsonclick = "";
         cmbavSgaufechoperator.Enabled = 1;
         edtavDdo_sgaufechaauxdatetext_Jsonclick = "";
         subGrid_Allowcollapsing = 0;
         subGrid_Allowselection = 0;
         subGrid_Sortable = 0;
         subGrid_Header = "";
         subGrid_Class = "GridWithPaginationBar WorkWith";
         subGrid_Backcolorstyle = 0;
         edtavSgaudocgls_Jsonclick = "";
         edtavSgaudocgls_Enabled = 1;
         cmbavSgaumod_Jsonclick = "";
         cmbavSgaumod.Enabled = 1;
         dynavUsucod_Jsonclick = "";
         dynavUsucod.Enabled = 1;
         Grid_empowerer_Hastitlesettings = Convert.ToBoolean( -1);
         Ddo_grid_Datalistproc = "Seguridad.AuditoriaGetFilterData";
         Ddo_grid_Datalistfixedvalues = "SEG:Seguridad,CLI:Ventas,PRV:Compras,TES:Bancos,CON:Contabilidad,PRO:Producción,PLA:Planilla,ALM:Almacen,OTR:Otros|||||||";
         Ddo_grid_Allowmultipleselection = "T|||||||";
         Ddo_grid_Datalisttype = "FixedValues||Dynamic|Dynamic|Dynamic|Dynamic|Dynamic|Dynamic";
         Ddo_grid_Includedatalist = "T||T|T|T|T|T|T";
         Ddo_grid_Filterisrange = "|P||||||";
         Ddo_grid_Filtertype = "|Date|Character|Character|Character|Character|Character|Character";
         Ddo_grid_Includefilter = "|T|T|T|T|T|T|T";
         Ddo_grid_Includesortasc = "T";
         Ddo_grid_Columnssortvalues = "2|3|4|5|6|7|8|9";
         Ddo_grid_Columnids = "0:SGAuMod|1:SGAuFecha|2:SGAuDocGls|3:SGAuDocNum|4:SGAuDocRef|5:SGAuTipCod|6:SGAuTipo|7:SGAuUsuCod";
         Ddo_grid_Gridinternalname = "";
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
         Form.Caption = "Auditoria";
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
         setEventMetadata("REFRESH","{handler:'Refresh',iparms:[{av:'GRID_nFirstRecordOnPage'},{av:'GRID_nEOF'},{av:'subGrid_Rows',ctrl:'GRID',prop:'Rows'},{av:'cmbavSgaumod'},{av:'AV40SGAuMod',fld:'vSGAUMOD',pic:''},{av:'cmbavSgaufechoperator'},{av:'AV39SGAuFechOperator',fld:'vSGAUFECHOPERATOR',pic:'ZZZ9'},{av:'AV36SGAuFech',fld:'vSGAUFECH',pic:''},{av:'AV73Pgmname',fld:'vPGMNAME',pic:'',hsh:true},{av:'AV34SGAuDocGls',fld:'vSGAUDOCGLS',pic:''},{av:'AV38SGAuFech_To',fld:'vSGAUFECH_TO',pic:''},{av:'AV70TFSGAuMod_Sels',fld:'vTFSGAUMOD_SELS',pic:''},{av:'AV55TFSGAuFecha',fld:'vTFSGAUFECHA',pic:'99/99/99 99:99'},{av:'AV56TFSGAuFecha_To',fld:'vTFSGAUFECHA_TO',pic:'99/99/99 99:99'},{av:'AV47TFSGAuDocGls',fld:'vTFSGAUDOCGLS',pic:''},{av:'AV48TFSGAuDocGls_Sel',fld:'vTFSGAUDOCGLS_SEL',pic:''},{av:'AV49TFSGAuDocNum',fld:'vTFSGAUDOCNUM',pic:''},{av:'AV50TFSGAuDocNum_Sel',fld:'vTFSGAUDOCNUM_SEL',pic:''},{av:'AV51TFSGAuDocRef',fld:'vTFSGAUDOCREF',pic:''},{av:'AV52TFSGAuDocRef_Sel',fld:'vTFSGAUDOCREF_SEL',pic:''},{av:'AV59TFSGAuTipCod',fld:'vTFSGAUTIPCOD',pic:''},{av:'AV60TFSGAuTipCod_Sel',fld:'vTFSGAUTIPCOD_SEL',pic:''},{av:'AV61TFSGAuTipo',fld:'vTFSGAUTIPO',pic:''},{av:'AV62TFSGAuTipo_Sel',fld:'vTFSGAUTIPO_SEL',pic:''},{av:'AV63TFSGAuUsuCod',fld:'vTFSGAUUSUCOD',pic:''},{av:'AV64TFSGAuUsuCod_Sel',fld:'vTFSGAUUSUCOD_SEL',pic:''},{av:'AV30OrderedBy',fld:'vORDEREDBY',pic:'ZZZ9'},{av:'AV31OrderedDsc',fld:'vORDEREDDSC',pic:''},{av:'Gx_date',fld:'vTODAY',pic:'',hsh:true},{av:'dynavUsucod'},{av:'AV68UsuCod',fld:'vUSUCOD',pic:''}]");
         setEventMetadata("REFRESH",",oparms:[{av:'AV23GridCurrentPage',fld:'vGRIDCURRENTPAGE',pic:'ZZZZZZZZZ9'},{av:'AV24GridPageCount',fld:'vGRIDPAGECOUNT',pic:'ZZZZZZZZZ9'},{av:'AV22GridAppliedFilters',fld:'vGRIDAPPLIEDFILTERS',pic:''},{av:'dynavUsucod'},{av:'AV68UsuCod',fld:'vUSUCOD',pic:''}]}");
         setEventMetadata("GRIDPAGINATIONBAR.CHANGEPAGE","{handler:'E110I2',iparms:[{av:'GRID_nFirstRecordOnPage'},{av:'GRID_nEOF'},{av:'subGrid_Rows',ctrl:'GRID',prop:'Rows'},{av:'cmbavSgaumod'},{av:'AV40SGAuMod',fld:'vSGAUMOD',pic:''},{av:'cmbavSgaufechoperator'},{av:'AV39SGAuFechOperator',fld:'vSGAUFECHOPERATOR',pic:'ZZZ9'},{av:'AV36SGAuFech',fld:'vSGAUFECH',pic:''},{av:'AV73Pgmname',fld:'vPGMNAME',pic:'',hsh:true},{av:'AV34SGAuDocGls',fld:'vSGAUDOCGLS',pic:''},{av:'AV38SGAuFech_To',fld:'vSGAUFECH_TO',pic:''},{av:'AV70TFSGAuMod_Sels',fld:'vTFSGAUMOD_SELS',pic:''},{av:'AV55TFSGAuFecha',fld:'vTFSGAUFECHA',pic:'99/99/99 99:99'},{av:'AV56TFSGAuFecha_To',fld:'vTFSGAUFECHA_TO',pic:'99/99/99 99:99'},{av:'AV47TFSGAuDocGls',fld:'vTFSGAUDOCGLS',pic:''},{av:'AV48TFSGAuDocGls_Sel',fld:'vTFSGAUDOCGLS_SEL',pic:''},{av:'AV49TFSGAuDocNum',fld:'vTFSGAUDOCNUM',pic:''},{av:'AV50TFSGAuDocNum_Sel',fld:'vTFSGAUDOCNUM_SEL',pic:''},{av:'AV51TFSGAuDocRef',fld:'vTFSGAUDOCREF',pic:''},{av:'AV52TFSGAuDocRef_Sel',fld:'vTFSGAUDOCREF_SEL',pic:''},{av:'AV59TFSGAuTipCod',fld:'vTFSGAUTIPCOD',pic:''},{av:'AV60TFSGAuTipCod_Sel',fld:'vTFSGAUTIPCOD_SEL',pic:''},{av:'AV61TFSGAuTipo',fld:'vTFSGAUTIPO',pic:''},{av:'AV62TFSGAuTipo_Sel',fld:'vTFSGAUTIPO_SEL',pic:''},{av:'AV63TFSGAuUsuCod',fld:'vTFSGAUUSUCOD',pic:''},{av:'AV64TFSGAuUsuCod_Sel',fld:'vTFSGAUUSUCOD_SEL',pic:''},{av:'AV30OrderedBy',fld:'vORDEREDBY',pic:'ZZZ9'},{av:'AV31OrderedDsc',fld:'vORDEREDDSC',pic:''},{av:'Gx_date',fld:'vTODAY',pic:'',hsh:true},{av:'Gridpaginationbar_Selectedpage',ctrl:'GRIDPAGINATIONBAR',prop:'SelectedPage'},{av:'dynavUsucod'},{av:'AV68UsuCod',fld:'vUSUCOD',pic:''}]");
         setEventMetadata("GRIDPAGINATIONBAR.CHANGEPAGE",",oparms:[{av:'dynavUsucod'},{av:'AV68UsuCod',fld:'vUSUCOD',pic:''}]}");
         setEventMetadata("GRIDPAGINATIONBAR.CHANGEROWSPERPAGE","{handler:'E120I2',iparms:[{av:'GRID_nFirstRecordOnPage'},{av:'GRID_nEOF'},{av:'subGrid_Rows',ctrl:'GRID',prop:'Rows'},{av:'cmbavSgaumod'},{av:'AV40SGAuMod',fld:'vSGAUMOD',pic:''},{av:'cmbavSgaufechoperator'},{av:'AV39SGAuFechOperator',fld:'vSGAUFECHOPERATOR',pic:'ZZZ9'},{av:'AV36SGAuFech',fld:'vSGAUFECH',pic:''},{av:'AV73Pgmname',fld:'vPGMNAME',pic:'',hsh:true},{av:'AV34SGAuDocGls',fld:'vSGAUDOCGLS',pic:''},{av:'AV38SGAuFech_To',fld:'vSGAUFECH_TO',pic:''},{av:'AV70TFSGAuMod_Sels',fld:'vTFSGAUMOD_SELS',pic:''},{av:'AV55TFSGAuFecha',fld:'vTFSGAUFECHA',pic:'99/99/99 99:99'},{av:'AV56TFSGAuFecha_To',fld:'vTFSGAUFECHA_TO',pic:'99/99/99 99:99'},{av:'AV47TFSGAuDocGls',fld:'vTFSGAUDOCGLS',pic:''},{av:'AV48TFSGAuDocGls_Sel',fld:'vTFSGAUDOCGLS_SEL',pic:''},{av:'AV49TFSGAuDocNum',fld:'vTFSGAUDOCNUM',pic:''},{av:'AV50TFSGAuDocNum_Sel',fld:'vTFSGAUDOCNUM_SEL',pic:''},{av:'AV51TFSGAuDocRef',fld:'vTFSGAUDOCREF',pic:''},{av:'AV52TFSGAuDocRef_Sel',fld:'vTFSGAUDOCREF_SEL',pic:''},{av:'AV59TFSGAuTipCod',fld:'vTFSGAUTIPCOD',pic:''},{av:'AV60TFSGAuTipCod_Sel',fld:'vTFSGAUTIPCOD_SEL',pic:''},{av:'AV61TFSGAuTipo',fld:'vTFSGAUTIPO',pic:''},{av:'AV62TFSGAuTipo_Sel',fld:'vTFSGAUTIPO_SEL',pic:''},{av:'AV63TFSGAuUsuCod',fld:'vTFSGAUUSUCOD',pic:''},{av:'AV64TFSGAuUsuCod_Sel',fld:'vTFSGAUUSUCOD_SEL',pic:''},{av:'AV30OrderedBy',fld:'vORDEREDBY',pic:'ZZZ9'},{av:'AV31OrderedDsc',fld:'vORDEREDDSC',pic:''},{av:'Gx_date',fld:'vTODAY',pic:'',hsh:true},{av:'Gridpaginationbar_Rowsperpageselectedvalue',ctrl:'GRIDPAGINATIONBAR',prop:'RowsPerPageSelectedValue'},{av:'dynavUsucod'},{av:'AV68UsuCod',fld:'vUSUCOD',pic:''}]");
         setEventMetadata("GRIDPAGINATIONBAR.CHANGEROWSPERPAGE",",oparms:[{av:'subGrid_Rows',ctrl:'GRID',prop:'Rows'},{av:'dynavUsucod'},{av:'AV68UsuCod',fld:'vUSUCOD',pic:''}]}");
         setEventMetadata("DDO_GRID.ONOPTIONCLICKED","{handler:'E140I2',iparms:[{av:'GRID_nFirstRecordOnPage'},{av:'GRID_nEOF'},{av:'subGrid_Rows',ctrl:'GRID',prop:'Rows'},{av:'cmbavSgaumod'},{av:'AV40SGAuMod',fld:'vSGAUMOD',pic:''},{av:'cmbavSgaufechoperator'},{av:'AV39SGAuFechOperator',fld:'vSGAUFECHOPERATOR',pic:'ZZZ9'},{av:'AV36SGAuFech',fld:'vSGAUFECH',pic:''},{av:'AV73Pgmname',fld:'vPGMNAME',pic:'',hsh:true},{av:'AV34SGAuDocGls',fld:'vSGAUDOCGLS',pic:''},{av:'AV38SGAuFech_To',fld:'vSGAUFECH_TO',pic:''},{av:'AV70TFSGAuMod_Sels',fld:'vTFSGAUMOD_SELS',pic:''},{av:'AV55TFSGAuFecha',fld:'vTFSGAUFECHA',pic:'99/99/99 99:99'},{av:'AV56TFSGAuFecha_To',fld:'vTFSGAUFECHA_TO',pic:'99/99/99 99:99'},{av:'AV47TFSGAuDocGls',fld:'vTFSGAUDOCGLS',pic:''},{av:'AV48TFSGAuDocGls_Sel',fld:'vTFSGAUDOCGLS_SEL',pic:''},{av:'AV49TFSGAuDocNum',fld:'vTFSGAUDOCNUM',pic:''},{av:'AV50TFSGAuDocNum_Sel',fld:'vTFSGAUDOCNUM_SEL',pic:''},{av:'AV51TFSGAuDocRef',fld:'vTFSGAUDOCREF',pic:''},{av:'AV52TFSGAuDocRef_Sel',fld:'vTFSGAUDOCREF_SEL',pic:''},{av:'AV59TFSGAuTipCod',fld:'vTFSGAUTIPCOD',pic:''},{av:'AV60TFSGAuTipCod_Sel',fld:'vTFSGAUTIPCOD_SEL',pic:''},{av:'AV61TFSGAuTipo',fld:'vTFSGAUTIPO',pic:''},{av:'AV62TFSGAuTipo_Sel',fld:'vTFSGAUTIPO_SEL',pic:''},{av:'AV63TFSGAuUsuCod',fld:'vTFSGAUUSUCOD',pic:''},{av:'AV64TFSGAuUsuCod_Sel',fld:'vTFSGAUUSUCOD_SEL',pic:''},{av:'AV30OrderedBy',fld:'vORDEREDBY',pic:'ZZZ9'},{av:'AV31OrderedDsc',fld:'vORDEREDDSC',pic:''},{av:'Gx_date',fld:'vTODAY',pic:'',hsh:true},{av:'Ddo_grid_Activeeventkey',ctrl:'DDO_GRID',prop:'ActiveEventKey'},{av:'Ddo_grid_Selectedvalue_get',ctrl:'DDO_GRID',prop:'SelectedValue_get'},{av:'Ddo_grid_Filteredtextto_get',ctrl:'DDO_GRID',prop:'FilteredTextTo_get'},{av:'Ddo_grid_Filteredtext_get',ctrl:'DDO_GRID',prop:'FilteredText_get'},{av:'Ddo_grid_Selectedcolumn',ctrl:'DDO_GRID',prop:'SelectedColumn'},{av:'dynavUsucod'},{av:'AV68UsuCod',fld:'vUSUCOD',pic:''}]");
         setEventMetadata("DDO_GRID.ONOPTIONCLICKED",",oparms:[{av:'AV30OrderedBy',fld:'vORDEREDBY',pic:'ZZZ9'},{av:'AV31OrderedDsc',fld:'vORDEREDDSC',pic:''},{av:'AV63TFSGAuUsuCod',fld:'vTFSGAUUSUCOD',pic:''},{av:'AV64TFSGAuUsuCod_Sel',fld:'vTFSGAUUSUCOD_SEL',pic:''},{av:'AV61TFSGAuTipo',fld:'vTFSGAUTIPO',pic:''},{av:'AV62TFSGAuTipo_Sel',fld:'vTFSGAUTIPO_SEL',pic:''},{av:'AV59TFSGAuTipCod',fld:'vTFSGAUTIPCOD',pic:''},{av:'AV60TFSGAuTipCod_Sel',fld:'vTFSGAUTIPCOD_SEL',pic:''},{av:'AV51TFSGAuDocRef',fld:'vTFSGAUDOCREF',pic:''},{av:'AV52TFSGAuDocRef_Sel',fld:'vTFSGAUDOCREF_SEL',pic:''},{av:'AV49TFSGAuDocNum',fld:'vTFSGAUDOCNUM',pic:''},{av:'AV50TFSGAuDocNum_Sel',fld:'vTFSGAUDOCNUM_SEL',pic:''},{av:'AV47TFSGAuDocGls',fld:'vTFSGAUDOCGLS',pic:''},{av:'AV48TFSGAuDocGls_Sel',fld:'vTFSGAUDOCGLS_SEL',pic:''},{av:'AV55TFSGAuFecha',fld:'vTFSGAUFECHA',pic:'99/99/99 99:99'},{av:'AV56TFSGAuFecha_To',fld:'vTFSGAUFECHA_TO',pic:'99/99/99 99:99'},{av:'AV69TFSGAuMod_SelsJson',fld:'vTFSGAUMOD_SELSJSON',pic:''},{av:'AV70TFSGAuMod_Sels',fld:'vTFSGAUMOD_SELS',pic:''},{av:'Ddo_grid_Sortedstatus',ctrl:'DDO_GRID',prop:'SortedStatus'},{av:'dynavUsucod'},{av:'AV68UsuCod',fld:'vUSUCOD',pic:''}]}");
         setEventMetadata("GRID.LOAD","{handler:'E180I2',iparms:[{av:'dynavUsucod'},{av:'AV68UsuCod',fld:'vUSUCOD',pic:''}]");
         setEventMetadata("GRID.LOAD",",oparms:[{av:'dynavUsucod'},{av:'AV68UsuCod',fld:'vUSUCOD',pic:''}]}");
         setEventMetadata("VSGAUFECHOPERATOR.CLICK","{handler:'E150I2',iparms:[{av:'GRID_nFirstRecordOnPage'},{av:'GRID_nEOF'},{av:'subGrid_Rows',ctrl:'GRID',prop:'Rows'},{av:'cmbavSgaumod'},{av:'AV40SGAuMod',fld:'vSGAUMOD',pic:''},{av:'cmbavSgaufechoperator'},{av:'AV39SGAuFechOperator',fld:'vSGAUFECHOPERATOR',pic:'ZZZ9'},{av:'AV36SGAuFech',fld:'vSGAUFECH',pic:''},{av:'AV73Pgmname',fld:'vPGMNAME',pic:'',hsh:true},{av:'AV34SGAuDocGls',fld:'vSGAUDOCGLS',pic:''},{av:'AV38SGAuFech_To',fld:'vSGAUFECH_TO',pic:''},{av:'AV70TFSGAuMod_Sels',fld:'vTFSGAUMOD_SELS',pic:''},{av:'AV55TFSGAuFecha',fld:'vTFSGAUFECHA',pic:'99/99/99 99:99'},{av:'AV56TFSGAuFecha_To',fld:'vTFSGAUFECHA_TO',pic:'99/99/99 99:99'},{av:'AV47TFSGAuDocGls',fld:'vTFSGAUDOCGLS',pic:''},{av:'AV48TFSGAuDocGls_Sel',fld:'vTFSGAUDOCGLS_SEL',pic:''},{av:'AV49TFSGAuDocNum',fld:'vTFSGAUDOCNUM',pic:''},{av:'AV50TFSGAuDocNum_Sel',fld:'vTFSGAUDOCNUM_SEL',pic:''},{av:'AV51TFSGAuDocRef',fld:'vTFSGAUDOCREF',pic:''},{av:'AV52TFSGAuDocRef_Sel',fld:'vTFSGAUDOCREF_SEL',pic:''},{av:'AV59TFSGAuTipCod',fld:'vTFSGAUTIPCOD',pic:''},{av:'AV60TFSGAuTipCod_Sel',fld:'vTFSGAUTIPCOD_SEL',pic:''},{av:'AV61TFSGAuTipo',fld:'vTFSGAUTIPO',pic:''},{av:'AV62TFSGAuTipo_Sel',fld:'vTFSGAUTIPO_SEL',pic:''},{av:'AV63TFSGAuUsuCod',fld:'vTFSGAUUSUCOD',pic:''},{av:'AV64TFSGAuUsuCod_Sel',fld:'vTFSGAUUSUCOD_SEL',pic:''},{av:'AV30OrderedBy',fld:'vORDEREDBY',pic:'ZZZ9'},{av:'AV31OrderedDsc',fld:'vORDEREDDSC',pic:''},{av:'Gx_date',fld:'vTODAY',pic:'',hsh:true},{av:'dynavUsucod'},{av:'AV68UsuCod',fld:'vUSUCOD',pic:''}]");
         setEventMetadata("VSGAUFECHOPERATOR.CLICK",",oparms:[{av:'AV36SGAuFech',fld:'vSGAUFECH',pic:''},{av:'AV38SGAuFech_To',fld:'vSGAUFECH_TO',pic:''},{av:'cellSgaufech_range_cell_Class',ctrl:'SGAUFECH_RANGE_CELL',prop:'Class'},{av:'AV23GridCurrentPage',fld:'vGRIDCURRENTPAGE',pic:'ZZZZZZZZZ9'},{av:'AV24GridPageCount',fld:'vGRIDPAGECOUNT',pic:'ZZZZZZZZZ9'},{av:'AV22GridAppliedFilters',fld:'vGRIDAPPLIEDFILTERS',pic:''},{av:'dynavUsucod'},{av:'AV68UsuCod',fld:'vUSUCOD',pic:''}]}");
         setEventMetadata("SGAUFECH_RANGEPICKER.DATERANGECHANGED","{handler:'E130I2',iparms:[{av:'GRID_nFirstRecordOnPage'},{av:'GRID_nEOF'},{av:'subGrid_Rows',ctrl:'GRID',prop:'Rows'},{av:'cmbavSgaumod'},{av:'AV40SGAuMod',fld:'vSGAUMOD',pic:''},{av:'cmbavSgaufechoperator'},{av:'AV39SGAuFechOperator',fld:'vSGAUFECHOPERATOR',pic:'ZZZ9'},{av:'AV36SGAuFech',fld:'vSGAUFECH',pic:''},{av:'AV73Pgmname',fld:'vPGMNAME',pic:'',hsh:true},{av:'AV34SGAuDocGls',fld:'vSGAUDOCGLS',pic:''},{av:'AV38SGAuFech_To',fld:'vSGAUFECH_TO',pic:''},{av:'AV70TFSGAuMod_Sels',fld:'vTFSGAUMOD_SELS',pic:''},{av:'AV55TFSGAuFecha',fld:'vTFSGAUFECHA',pic:'99/99/99 99:99'},{av:'AV56TFSGAuFecha_To',fld:'vTFSGAUFECHA_TO',pic:'99/99/99 99:99'},{av:'AV47TFSGAuDocGls',fld:'vTFSGAUDOCGLS',pic:''},{av:'AV48TFSGAuDocGls_Sel',fld:'vTFSGAUDOCGLS_SEL',pic:''},{av:'AV49TFSGAuDocNum',fld:'vTFSGAUDOCNUM',pic:''},{av:'AV50TFSGAuDocNum_Sel',fld:'vTFSGAUDOCNUM_SEL',pic:''},{av:'AV51TFSGAuDocRef',fld:'vTFSGAUDOCREF',pic:''},{av:'AV52TFSGAuDocRef_Sel',fld:'vTFSGAUDOCREF_SEL',pic:''},{av:'AV59TFSGAuTipCod',fld:'vTFSGAUTIPCOD',pic:''},{av:'AV60TFSGAuTipCod_Sel',fld:'vTFSGAUTIPCOD_SEL',pic:''},{av:'AV61TFSGAuTipo',fld:'vTFSGAUTIPO',pic:''},{av:'AV62TFSGAuTipo_Sel',fld:'vTFSGAUTIPO_SEL',pic:''},{av:'AV63TFSGAuUsuCod',fld:'vTFSGAUUSUCOD',pic:''},{av:'AV64TFSGAuUsuCod_Sel',fld:'vTFSGAUUSUCOD_SEL',pic:''},{av:'AV30OrderedBy',fld:'vORDEREDBY',pic:'ZZZ9'},{av:'AV31OrderedDsc',fld:'vORDEREDDSC',pic:''},{av:'Gx_date',fld:'vTODAY',pic:'',hsh:true},{av:'dynavUsucod'},{av:'AV68UsuCod',fld:'vUSUCOD',pic:''}]");
         setEventMetadata("SGAUFECH_RANGEPICKER.DATERANGECHANGED",",oparms:[{av:'AV36SGAuFech',fld:'vSGAUFECH',pic:''},{av:'AV38SGAuFech_To',fld:'vSGAUFECH_TO',pic:''},{av:'AV23GridCurrentPage',fld:'vGRIDCURRENTPAGE',pic:'ZZZZZZZZZ9'},{av:'AV24GridPageCount',fld:'vGRIDPAGECOUNT',pic:'ZZZZZZZZZ9'},{av:'AV22GridAppliedFilters',fld:'vGRIDAPPLIEDFILTERS',pic:''},{av:'dynavUsucod'},{av:'AV68UsuCod',fld:'vUSUCOD',pic:''}]}");
         setEventMetadata("NULL","{handler:'Valid_Sgaufech',iparms:[{av:'dynavUsucod'},{av:'AV68UsuCod',fld:'vUSUCOD',pic:''}]");
         setEventMetadata("NULL",",oparms:[{av:'dynavUsucod'},{av:'AV68UsuCod',fld:'vUSUCOD',pic:''}]}");
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
         gxfirstwebparm = "";
         gxfirstwebparm_bkp = "";
         AV68UsuCod = "";
         AV40SGAuMod = "";
         AV36SGAuFech = DateTime.MinValue;
         AV73Pgmname = "";
         AV34SGAuDocGls = "";
         AV38SGAuFech_To = DateTime.MinValue;
         AV70TFSGAuMod_Sels = new GxSimpleCollection<string>();
         AV55TFSGAuFecha = (DateTime)(DateTime.MinValue);
         AV56TFSGAuFecha_To = (DateTime)(DateTime.MinValue);
         AV47TFSGAuDocGls = "";
         AV48TFSGAuDocGls_Sel = "";
         AV49TFSGAuDocNum = "";
         AV50TFSGAuDocNum_Sel = "";
         AV51TFSGAuDocRef = "";
         AV52TFSGAuDocRef_Sel = "";
         AV59TFSGAuTipCod = "";
         AV60TFSGAuTipCod_Sel = "";
         AV61TFSGAuTipo = "";
         AV62TFSGAuTipo_Sel = "";
         AV63TFSGAuUsuCod = "";
         AV64TFSGAuUsuCod_Sel = "";
         Gx_date = DateTime.MinValue;
         sDynURL = "";
         FormProcess = "";
         bodyStyle = "";
         GXKey = "";
         AV22GridAppliedFilters = "";
         AV11DDO_TitleSettingsIcons = new GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTDropDownOptionsTitleSettingsIcons(context);
         AV7DDO_SGAuFechaAuxDateTo = DateTime.MinValue;
         AV5DDO_SGAuFechaAuxDate = DateTime.MinValue;
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
         lblFiltertextsgaufech_Jsonclick = "";
         ClassString = "";
         StyleString = "";
         GridContainer = new GXWebGrid( context);
         sStyleString = "";
         subGrid_Linesclass = "";
         GridColumn = new GXWebColumn();
         A337SGAuMod = "";
         A338SGAuFecha = (DateTime)(DateTime.MinValue);
         A1843SGAuDocGls = "";
         A1844SGAuDocNum = "";
         A1845SGAuDocRef = "";
         A1847SGAuTipCod = "";
         A1848SGAuTipo = "";
         A1849SGAuUsuCod = "";
         A1846SGAuFech = DateTime.MinValue;
         ucGridpaginationbar = new GXUserControl();
         ucSgaufech_rangepicker = new GXUserControl();
         ucDdo_grid = new GXUserControl();
         ucGrid_empowerer = new GXUserControl();
         AV6DDO_SGAuFechaAuxDateText = "";
         ucTfsgaufecha_rangepicker = new GXUserControl();
         sEvt = "";
         EvtGridId = "";
         EvtRowId = "";
         sEvtType = "";
         gxdynajaxctrlcodr = new GeneXus.Utils.GxStringCollection();
         gxdynajaxctrldescr = new GeneXus.Utils.GxStringCollection();
         gxwrpcisep = "";
         scmdbuf = "";
         H000I2_A348UsuCod = new string[] {""} ;
         H000I2_A2019UsuNom = new string[] {""} ;
         H000I2_A2039UsuSts = new short[1] ;
         AV79Seguridad_auditoriads_6_tfsgaumod_sels = new GxSimpleCollection<string>();
         lV76Seguridad_auditoriads_3_sgaudocgls = "";
         lV82Seguridad_auditoriads_9_tfsgaudocgls = "";
         lV84Seguridad_auditoriads_11_tfsgaudocnum = "";
         lV86Seguridad_auditoriads_13_tfsgaudocref = "";
         lV88Seguridad_auditoriads_15_tfsgautipcod = "";
         lV90Seguridad_auditoriads_17_tfsgautipo = "";
         lV92Seguridad_auditoriads_19_tfsgauusucod = "";
         AV74Seguridad_auditoriads_1_usucod = "";
         AV75Seguridad_auditoriads_2_sgaumod = "";
         AV77Seguridad_auditoriads_4_sgaufech = DateTime.MinValue;
         AV78Seguridad_auditoriads_5_sgaufech_to = DateTime.MinValue;
         AV80Seguridad_auditoriads_7_tfsgaufecha = (DateTime)(DateTime.MinValue);
         AV81Seguridad_auditoriads_8_tfsgaufecha_to = (DateTime)(DateTime.MinValue);
         AV83Seguridad_auditoriads_10_tfsgaudocgls_sel = "";
         AV82Seguridad_auditoriads_9_tfsgaudocgls = "";
         AV85Seguridad_auditoriads_12_tfsgaudocnum_sel = "";
         AV84Seguridad_auditoriads_11_tfsgaudocnum = "";
         AV87Seguridad_auditoriads_14_tfsgaudocref_sel = "";
         AV86Seguridad_auditoriads_13_tfsgaudocref = "";
         AV89Seguridad_auditoriads_16_tfsgautipcod_sel = "";
         AV88Seguridad_auditoriads_15_tfsgautipcod = "";
         AV91Seguridad_auditoriads_18_tfsgautipo_sel = "";
         AV90Seguridad_auditoriads_17_tfsgautipo = "";
         AV93Seguridad_auditoriads_20_tfsgauusucod_sel = "";
         AV92Seguridad_auditoriads_19_tfsgauusucod = "";
         AV76Seguridad_auditoriads_3_sgaudocgls = "";
         H000I3_A1846SGAuFech = new DateTime[] {DateTime.MinValue} ;
         H000I3_A1849SGAuUsuCod = new string[] {""} ;
         H000I3_A1848SGAuTipo = new string[] {""} ;
         H000I3_A1847SGAuTipCod = new string[] {""} ;
         H000I3_A1845SGAuDocRef = new string[] {""} ;
         H000I3_A1844SGAuDocNum = new string[] {""} ;
         H000I3_A1843SGAuDocGls = new string[] {""} ;
         H000I3_A338SGAuFecha = new DateTime[] {DateTime.MinValue} ;
         H000I3_A337SGAuMod = new string[] {""} ;
         H000I4_AGRID_nRecordCount = new long[1] ;
         AV37SGAuFech_RangeText = "";
         GXt_SdtDVB_SDTDropDownOptionsTitleSettingsIcons1 = new GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTDropDownOptionsTitleSettingsIcons(context);
         AV67WWPContext = new GeneXus.Programs.wwpbaseobjects.SdtWWPContext(context);
         AV69TFSGAuMod_SelsJson = "";
         GridRow = new GXWebRow();
         AV33Session = context.GetSession();
         AV25GridState = new GeneXus.Programs.wwpbaseobjects.SdtWWPGridState(context);
         AV27GridStateFilterValue = new GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue(context);
         GXt_char2 = "";
         GXt_char8 = "";
         GXt_char7 = "";
         GXt_char6 = "";
         GXt_char5 = "";
         GXt_char4 = "";
         GXt_char3 = "";
         AV65TrnContext = new GeneXus.Programs.wwpbaseobjects.SdtWWPTransactionContext(context);
         AV28HTTPRequest = new GxHttpRequest( context);
         BackMsgLst = new msglist();
         LclMsgLst = new msglist();
         GXCCtl = "";
         ROClassString = "";
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.seguridad.auditoria__default(),
            new Object[][] {
                new Object[] {
               H000I2_A348UsuCod, H000I2_A2019UsuNom, H000I2_A2039UsuSts
               }
               , new Object[] {
               H000I3_A1846SGAuFech, H000I3_A1849SGAuUsuCod, H000I3_A1848SGAuTipo, H000I3_A1847SGAuTipCod, H000I3_A1845SGAuDocRef, H000I3_A1844SGAuDocNum, H000I3_A1843SGAuDocGls, H000I3_A338SGAuFecha, H000I3_A337SGAuMod
               }
               , new Object[] {
               H000I4_AGRID_nRecordCount
               }
            }
         );
         Gx_date = DateTimeUtil.Today( context);
         AV73Pgmname = "Seguridad.Auditoria";
         /* GeneXus formulas. */
         Gx_date = DateTimeUtil.Today( context);
         AV73Pgmname = "Seguridad.Auditoria";
         context.Gx_err = 0;
      }

      private short GRID_nEOF ;
      private short nGotPars ;
      private short GxWebError ;
      private short AV39SGAuFechOperator ;
      private short AV30OrderedBy ;
      private short initialized ;
      private short gxajaxcallmode ;
      private short wbEnd ;
      private short wbStart ;
      private short subGrid_Backcolorstyle ;
      private short subGrid_Titlebackstyle ;
      private short subGrid_Sortable ;
      private short subGrid_Allowselection ;
      private short subGrid_Allowhovering ;
      private short subGrid_Allowcollapsing ;
      private short subGrid_Collapsed ;
      private short nDonePA ;
      private short nGXWrapped ;
      private short subGrid_Backstyle ;
      private int subGrid_Rows ;
      private int Gridpaginationbar_Rowsperpageselectedvalue ;
      private int nRC_GXsfl_57 ;
      private int nGXsfl_57_idx=1 ;
      private int Gridpaginationbar_Pagestoshow ;
      private int edtavSgaudocgls_Enabled ;
      private int subGrid_Titlebackcolor ;
      private int subGrid_Allbackcolor ;
      private int subGrid_Selectedindex ;
      private int subGrid_Selectioncolor ;
      private int subGrid_Hoveringcolor ;
      private int gxdynajaxindex ;
      private int subGrid_Islastpage ;
      private int GXPagingFrom2 ;
      private int GXPagingTo2 ;
      private int AV79Seguridad_auditoriads_6_tfsgaumod_sels_Count ;
      private int AV32PageToGo ;
      private int AV94GXV1 ;
      private int edtavSgaufech_rangetext_Enabled ;
      private int idxLst ;
      private int subGrid_Backcolor ;
      private long GRID_nFirstRecordOnPage ;
      private long AV23GridCurrentPage ;
      private long AV24GridPageCount ;
      private long GRID_nCurrentRecord ;
      private long GRID_nRecordCount ;
      private string Gridpaginationbar_Selectedpage ;
      private string Ddo_grid_Activeeventkey ;
      private string Ddo_grid_Selectedvalue_get ;
      private string Ddo_grid_Filteredtextto_get ;
      private string Ddo_grid_Filteredtext_get ;
      private string Ddo_grid_Selectedcolumn ;
      private string gxfirstwebparm ;
      private string gxfirstwebparm_bkp ;
      private string sGXsfl_57_idx="0001" ;
      private string AV68UsuCod ;
      private string AV73Pgmname ;
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
      private string Grid_empowerer_Gridinternalname ;
      private string GX_FocusControl ;
      private string sPrefix ;
      private string divLayoutmaintable_Internalname ;
      private string divTablemain_Internalname ;
      private string Dvpanel_tableheader_Internalname ;
      private string divTableheader_Internalname ;
      private string divTableheadercontent_Internalname ;
      private string divTableactions_Internalname ;
      private string divTablafiltros_Internalname ;
      private string dynavUsucod_Internalname ;
      private string TempTags ;
      private string dynavUsucod_Jsonclick ;
      private string cmbavSgaumod_Internalname ;
      private string cmbavSgaumod_Jsonclick ;
      private string edtavSgaudocgls_Internalname ;
      private string edtavSgaudocgls_Jsonclick ;
      private string divTablesplittedfiltertextsgaufech_Internalname ;
      private string lblFiltertextsgaufech_Internalname ;
      private string lblFiltertextsgaufech_Jsonclick ;
      private string divTablerightheader_Internalname ;
      private string ClassString ;
      private string StyleString ;
      private string divGridtablewithpaginationbar_Internalname ;
      private string sStyleString ;
      private string subGrid_Internalname ;
      private string subGrid_Class ;
      private string subGrid_Linesclass ;
      private string subGrid_Header ;
      private string Gridpaginationbar_Internalname ;
      private string divHtml_bottomauxiliarcontrols_Internalname ;
      private string Sgaufech_rangepicker_Internalname ;
      private string Ddo_grid_Internalname ;
      private string Grid_empowerer_Internalname ;
      private string divDdo_sgaufechaauxdates_Internalname ;
      private string edtavDdo_sgaufechaauxdatetext_Internalname ;
      private string edtavDdo_sgaufechaauxdatetext_Jsonclick ;
      private string Tfsgaufecha_rangepicker_Internalname ;
      private string sEvt ;
      private string EvtGridId ;
      private string EvtRowId ;
      private string sEvtType ;
      private string cmbSGAuMod_Internalname ;
      private string edtSGAuFecha_Internalname ;
      private string edtSGAuDocGls_Internalname ;
      private string edtSGAuDocNum_Internalname ;
      private string edtSGAuDocRef_Internalname ;
      private string edtSGAuTipCod_Internalname ;
      private string edtSGAuTipo_Internalname ;
      private string edtSGAuUsuCod_Internalname ;
      private string edtSGAuFech_Internalname ;
      private string gxwrpcisep ;
      private string scmdbuf ;
      private string cmbavSgaufechoperator_Internalname ;
      private string AV74Seguridad_auditoriads_1_usucod ;
      private string edtavSgaufech_rangetext_Internalname ;
      private string GXt_char2 ;
      private string GXt_char8 ;
      private string GXt_char7 ;
      private string GXt_char6 ;
      private string GXt_char5 ;
      private string GXt_char4 ;
      private string GXt_char3 ;
      private string cellSgaufech_range_cell_Class ;
      private string cellSgaufech_range_cell_Internalname ;
      private string tblTablemergedsgaufech_Internalname ;
      private string cmbavSgaufechoperator_Jsonclick ;
      private string edtavSgaufech_rangetext_Jsonclick ;
      private string sGXsfl_57_fel_idx="0001" ;
      private string GXCCtl ;
      private string cmbSGAuMod_Jsonclick ;
      private string ROClassString ;
      private string edtSGAuFecha_Jsonclick ;
      private string edtSGAuDocGls_Jsonclick ;
      private string edtSGAuDocNum_Jsonclick ;
      private string edtSGAuDocRef_Jsonclick ;
      private string edtSGAuTipCod_Jsonclick ;
      private string edtSGAuTipo_Jsonclick ;
      private string edtSGAuUsuCod_Jsonclick ;
      private string edtSGAuFech_Jsonclick ;
      private DateTime AV55TFSGAuFecha ;
      private DateTime AV56TFSGAuFecha_To ;
      private DateTime A338SGAuFecha ;
      private DateTime AV80Seguridad_auditoriads_7_tfsgaufecha ;
      private DateTime AV81Seguridad_auditoriads_8_tfsgaufecha_to ;
      private DateTime AV36SGAuFech ;
      private DateTime AV38SGAuFech_To ;
      private DateTime Gx_date ;
      private DateTime AV7DDO_SGAuFechaAuxDateTo ;
      private DateTime AV5DDO_SGAuFechaAuxDate ;
      private DateTime A1846SGAuFech ;
      private DateTime AV77Seguridad_auditoriads_4_sgaufech ;
      private DateTime AV78Seguridad_auditoriads_5_sgaufech_to ;
      private bool entryPointCalled ;
      private bool toggleJsOutput ;
      private bool AV31OrderedDsc ;
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
      private bool bGXsfl_57_Refreshing=false ;
      private bool returnInSub ;
      private bool gx_refresh_fired ;
      private string AV69TFSGAuMod_SelsJson ;
      private string AV40SGAuMod ;
      private string AV34SGAuDocGls ;
      private string AV47TFSGAuDocGls ;
      private string AV48TFSGAuDocGls_Sel ;
      private string AV49TFSGAuDocNum ;
      private string AV50TFSGAuDocNum_Sel ;
      private string AV51TFSGAuDocRef ;
      private string AV52TFSGAuDocRef_Sel ;
      private string AV59TFSGAuTipCod ;
      private string AV60TFSGAuTipCod_Sel ;
      private string AV61TFSGAuTipo ;
      private string AV62TFSGAuTipo_Sel ;
      private string AV63TFSGAuUsuCod ;
      private string AV64TFSGAuUsuCod_Sel ;
      private string AV22GridAppliedFilters ;
      private string A337SGAuMod ;
      private string A1843SGAuDocGls ;
      private string A1844SGAuDocNum ;
      private string A1845SGAuDocRef ;
      private string A1847SGAuTipCod ;
      private string A1848SGAuTipo ;
      private string A1849SGAuUsuCod ;
      private string AV6DDO_SGAuFechaAuxDateText ;
      private string lV76Seguridad_auditoriads_3_sgaudocgls ;
      private string lV82Seguridad_auditoriads_9_tfsgaudocgls ;
      private string lV84Seguridad_auditoriads_11_tfsgaudocnum ;
      private string lV86Seguridad_auditoriads_13_tfsgaudocref ;
      private string lV88Seguridad_auditoriads_15_tfsgautipcod ;
      private string lV90Seguridad_auditoriads_17_tfsgautipo ;
      private string lV92Seguridad_auditoriads_19_tfsgauusucod ;
      private string AV75Seguridad_auditoriads_2_sgaumod ;
      private string AV83Seguridad_auditoriads_10_tfsgaudocgls_sel ;
      private string AV82Seguridad_auditoriads_9_tfsgaudocgls ;
      private string AV85Seguridad_auditoriads_12_tfsgaudocnum_sel ;
      private string AV84Seguridad_auditoriads_11_tfsgaudocnum ;
      private string AV87Seguridad_auditoriads_14_tfsgaudocref_sel ;
      private string AV86Seguridad_auditoriads_13_tfsgaudocref ;
      private string AV89Seguridad_auditoriads_16_tfsgautipcod_sel ;
      private string AV88Seguridad_auditoriads_15_tfsgautipcod ;
      private string AV91Seguridad_auditoriads_18_tfsgautipo_sel ;
      private string AV90Seguridad_auditoriads_17_tfsgautipo ;
      private string AV93Seguridad_auditoriads_20_tfsgauusucod_sel ;
      private string AV92Seguridad_auditoriads_19_tfsgauusucod ;
      private string AV76Seguridad_auditoriads_3_sgaudocgls ;
      private string AV37SGAuFech_RangeText ;
      private IGxSession AV33Session ;
      private GeneXus.Utils.GxStringCollection gxdynajaxctrlcodr ;
      private GeneXus.Utils.GxStringCollection gxdynajaxctrldescr ;
      private GXWebGrid GridContainer ;
      private GXWebRow GridRow ;
      private GXWebColumn GridColumn ;
      private GXUserControl ucDvpanel_tableheader ;
      private GXUserControl ucGridpaginationbar ;
      private GXUserControl ucSgaufech_rangepicker ;
      private GXUserControl ucDdo_grid ;
      private GXUserControl ucGrid_empowerer ;
      private GXUserControl ucTfsgaufecha_rangepicker ;
      private IGxDataStore dsDataStore2 ;
      private IGxDataStore dsDefault ;
      private GXCombobox dynavUsucod ;
      private GXCombobox cmbavSgaumod ;
      private GXCombobox cmbavSgaufechoperator ;
      private GXCombobox cmbSGAuMod ;
      private IDataStoreProvider pr_default ;
      private string[] H000I2_A348UsuCod ;
      private string[] H000I2_A2019UsuNom ;
      private short[] H000I2_A2039UsuSts ;
      private DateTime[] H000I3_A1846SGAuFech ;
      private string[] H000I3_A1849SGAuUsuCod ;
      private string[] H000I3_A1848SGAuTipo ;
      private string[] H000I3_A1847SGAuTipCod ;
      private string[] H000I3_A1845SGAuDocRef ;
      private string[] H000I3_A1844SGAuDocNum ;
      private string[] H000I3_A1843SGAuDocGls ;
      private DateTime[] H000I3_A338SGAuFecha ;
      private string[] H000I3_A337SGAuMod ;
      private long[] H000I4_AGRID_nRecordCount ;
      private msglist BackMsgLst ;
      private msglist LclMsgLst ;
      private GxHttpRequest AV28HTTPRequest ;
      private GxSimpleCollection<string> AV70TFSGAuMod_Sels ;
      private GxSimpleCollection<string> AV79Seguridad_auditoriads_6_tfsgaumod_sels ;
      private GXWebForm Form ;
      private GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTDropDownOptionsTitleSettingsIcons AV11DDO_TitleSettingsIcons ;
      private GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTDropDownOptionsTitleSettingsIcons GXt_SdtDVB_SDTDropDownOptionsTitleSettingsIcons1 ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPGridState AV25GridState ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue AV27GridStateFilterValue ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPTransactionContext AV65TrnContext ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPContext AV67WWPContext ;
   }

   public class auditoria__default : DataStoreHelperBase, IDataStoreHelper
   {
      protected Object[] conditional_H000I3( IGxContext context ,
                                             string A337SGAuMod ,
                                             GxSimpleCollection<string> AV79Seguridad_auditoriads_6_tfsgaumod_sels ,
                                             string AV74Seguridad_auditoriads_1_usucod ,
                                             string AV75Seguridad_auditoriads_2_sgaumod ,
                                             short AV39SGAuFechOperator ,
                                             DateTime AV77Seguridad_auditoriads_4_sgaufech ,
                                             DateTime AV78Seguridad_auditoriads_5_sgaufech_to ,
                                             int AV79Seguridad_auditoriads_6_tfsgaumod_sels_Count ,
                                             DateTime AV80Seguridad_auditoriads_7_tfsgaufecha ,
                                             DateTime AV81Seguridad_auditoriads_8_tfsgaufecha_to ,
                                             string AV83Seguridad_auditoriads_10_tfsgaudocgls_sel ,
                                             string AV82Seguridad_auditoriads_9_tfsgaudocgls ,
                                             string AV85Seguridad_auditoriads_12_tfsgaudocnum_sel ,
                                             string AV84Seguridad_auditoriads_11_tfsgaudocnum ,
                                             string AV87Seguridad_auditoriads_14_tfsgaudocref_sel ,
                                             string AV86Seguridad_auditoriads_13_tfsgaudocref ,
                                             string AV89Seguridad_auditoriads_16_tfsgautipcod_sel ,
                                             string AV88Seguridad_auditoriads_15_tfsgautipcod ,
                                             string AV91Seguridad_auditoriads_18_tfsgautipo_sel ,
                                             string AV90Seguridad_auditoriads_17_tfsgautipo ,
                                             string AV93Seguridad_auditoriads_20_tfsgauusucod_sel ,
                                             string AV92Seguridad_auditoriads_19_tfsgauusucod ,
                                             string A1849SGAuUsuCod ,
                                             DateTime A1846SGAuFech ,
                                             DateTime A338SGAuFecha ,
                                             string A1843SGAuDocGls ,
                                             string A1844SGAuDocNum ,
                                             string A1845SGAuDocRef ,
                                             string A1847SGAuTipCod ,
                                             string A1848SGAuTipo ,
                                             short AV30OrderedBy ,
                                             bool AV31OrderedDsc ,
                                             string AV76Seguridad_auditoriads_3_sgaudocgls )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int9 = new short[25];
         Object[] GXv_Object10 = new Object[2];
         string sSelectString;
         string sFromString;
         string sOrderString;
         sSelectString = " [SGAuFech], [SGAuUsuCod], [SGAuTipo], [SGAuTipCod], [SGAuDocRef], [SGAuDocNum], [SGAuDocGls], [SGAuFecha], [SGAuMod]";
         sFromString = " FROM [SGAUDITORIA]";
         sOrderString = "";
         AddWhere(sWhereString, "([SGAuDocGls] like '%' + @lV76Seguridad_auditoriads_3_sgaudocgls + '%')");
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV74Seguridad_auditoriads_1_usucod)) )
         {
            AddWhere(sWhereString, "([SGAuUsuCod] = @AV74Seguridad_auditoriads_1_usucod)");
         }
         else
         {
            GXv_int9[1] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV75Seguridad_auditoriads_2_sgaumod)) )
         {
            AddWhere(sWhereString, "([SGAuMod] = @AV75Seguridad_auditoriads_2_sgaumod)");
         }
         else
         {
            GXv_int9[2] = 1;
         }
         if ( ( AV39SGAuFechOperator == 0 ) && ( ! (DateTime.MinValue==AV77Seguridad_auditoriads_4_sgaufech) ) )
         {
            AddWhere(sWhereString, "([SGAuFech] = @AV77Seguridad_auditoriads_4_sgaufech)");
         }
         else
         {
            GXv_int9[3] = 1;
         }
         if ( ( AV39SGAuFechOperator == 1 ) && ( ! (DateTime.MinValue==AV77Seguridad_auditoriads_4_sgaufech) ) )
         {
            AddWhere(sWhereString, "([SGAuFech] < @AV77Seguridad_auditoriads_4_sgaufech)");
         }
         else
         {
            GXv_int9[4] = 1;
         }
         if ( ( AV39SGAuFechOperator == 2 ) && ( ! (DateTime.MinValue==AV77Seguridad_auditoriads_4_sgaufech) ) )
         {
            AddWhere(sWhereString, "([SGAuFech] > @AV77Seguridad_auditoriads_4_sgaufech)");
         }
         else
         {
            GXv_int9[5] = 1;
         }
         if ( ( AV39SGAuFechOperator == 3 ) && ( ! (DateTime.MinValue==AV77Seguridad_auditoriads_4_sgaufech) ) )
         {
            AddWhere(sWhereString, "([SGAuFech] >= @AV77Seguridad_auditoriads_4_sgaufech)");
         }
         else
         {
            GXv_int9[6] = 1;
         }
         if ( ( AV39SGAuFechOperator == 3 ) && ( ! (DateTime.MinValue==AV78Seguridad_auditoriads_5_sgaufech_to) ) )
         {
            AddWhere(sWhereString, "([SGAuFech] <= @AV78Seguridad_auditoriads_5_sgaufech_to)");
         }
         else
         {
            GXv_int9[7] = 1;
         }
         if ( AV79Seguridad_auditoriads_6_tfsgaumod_sels_Count > 0 )
         {
            AddWhere(sWhereString, "("+new GxDbmsUtils( new GxSqlServer()).ValueList(AV79Seguridad_auditoriads_6_tfsgaumod_sels, "[SGAuMod] IN (", ")")+")");
         }
         if ( ! (DateTime.MinValue==AV80Seguridad_auditoriads_7_tfsgaufecha) )
         {
            AddWhere(sWhereString, "([SGAuFecha] >= @AV80Seguridad_auditoriads_7_tfsgaufecha)");
         }
         else
         {
            GXv_int9[8] = 1;
         }
         if ( ! (DateTime.MinValue==AV81Seguridad_auditoriads_8_tfsgaufecha_to) )
         {
            AddWhere(sWhereString, "([SGAuFecha] <= @AV81Seguridad_auditoriads_8_tfsgaufecha_to)");
         }
         else
         {
            GXv_int9[9] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV83Seguridad_auditoriads_10_tfsgaudocgls_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV82Seguridad_auditoriads_9_tfsgaudocgls)) ) )
         {
            AddWhere(sWhereString, "([SGAuDocGls] like @lV82Seguridad_auditoriads_9_tfsgaudocgls)");
         }
         else
         {
            GXv_int9[10] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV83Seguridad_auditoriads_10_tfsgaudocgls_sel)) )
         {
            AddWhere(sWhereString, "([SGAuDocGls] = @AV83Seguridad_auditoriads_10_tfsgaudocgls_sel)");
         }
         else
         {
            GXv_int9[11] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV85Seguridad_auditoriads_12_tfsgaudocnum_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV84Seguridad_auditoriads_11_tfsgaudocnum)) ) )
         {
            AddWhere(sWhereString, "([SGAuDocNum] like @lV84Seguridad_auditoriads_11_tfsgaudocnum)");
         }
         else
         {
            GXv_int9[12] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV85Seguridad_auditoriads_12_tfsgaudocnum_sel)) )
         {
            AddWhere(sWhereString, "([SGAuDocNum] = @AV85Seguridad_auditoriads_12_tfsgaudocnum_sel)");
         }
         else
         {
            GXv_int9[13] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV87Seguridad_auditoriads_14_tfsgaudocref_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV86Seguridad_auditoriads_13_tfsgaudocref)) ) )
         {
            AddWhere(sWhereString, "([SGAuDocRef] like @lV86Seguridad_auditoriads_13_tfsgaudocref)");
         }
         else
         {
            GXv_int9[14] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV87Seguridad_auditoriads_14_tfsgaudocref_sel)) )
         {
            AddWhere(sWhereString, "([SGAuDocRef] = @AV87Seguridad_auditoriads_14_tfsgaudocref_sel)");
         }
         else
         {
            GXv_int9[15] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV89Seguridad_auditoriads_16_tfsgautipcod_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV88Seguridad_auditoriads_15_tfsgautipcod)) ) )
         {
            AddWhere(sWhereString, "([SGAuTipCod] like @lV88Seguridad_auditoriads_15_tfsgautipcod)");
         }
         else
         {
            GXv_int9[16] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV89Seguridad_auditoriads_16_tfsgautipcod_sel)) )
         {
            AddWhere(sWhereString, "([SGAuTipCod] = @AV89Seguridad_auditoriads_16_tfsgautipcod_sel)");
         }
         else
         {
            GXv_int9[17] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV91Seguridad_auditoriads_18_tfsgautipo_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV90Seguridad_auditoriads_17_tfsgautipo)) ) )
         {
            AddWhere(sWhereString, "([SGAuTipo] like @lV90Seguridad_auditoriads_17_tfsgautipo)");
         }
         else
         {
            GXv_int9[18] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV91Seguridad_auditoriads_18_tfsgautipo_sel)) )
         {
            AddWhere(sWhereString, "([SGAuTipo] = @AV91Seguridad_auditoriads_18_tfsgautipo_sel)");
         }
         else
         {
            GXv_int9[19] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV93Seguridad_auditoriads_20_tfsgauusucod_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV92Seguridad_auditoriads_19_tfsgauusucod)) ) )
         {
            AddWhere(sWhereString, "([SGAuUsuCod] like @lV92Seguridad_auditoriads_19_tfsgauusucod)");
         }
         else
         {
            GXv_int9[20] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV93Seguridad_auditoriads_20_tfsgauusucod_sel)) )
         {
            AddWhere(sWhereString, "([SGAuUsuCod] = @AV93Seguridad_auditoriads_20_tfsgauusucod_sel)");
         }
         else
         {
            GXv_int9[21] = 1;
         }
         if ( AV30OrderedBy == 1 )
         {
            sOrderString += " ORDER BY [SGAuMod], [SGAuFecha]";
         }
         else if ( ( AV30OrderedBy == 2 ) && ! AV31OrderedDsc )
         {
            sOrderString += " ORDER BY [SGAuMod]";
         }
         else if ( ( AV30OrderedBy == 2 ) && ( AV31OrderedDsc ) )
         {
            sOrderString += " ORDER BY [SGAuMod] DESC";
         }
         else if ( ( AV30OrderedBy == 3 ) && ! AV31OrderedDsc )
         {
            sOrderString += " ORDER BY [SGAuFecha]";
         }
         else if ( ( AV30OrderedBy == 3 ) && ( AV31OrderedDsc ) )
         {
            sOrderString += " ORDER BY [SGAuFecha] DESC";
         }
         else if ( ( AV30OrderedBy == 4 ) && ! AV31OrderedDsc )
         {
            sOrderString += " ORDER BY [SGAuDocGls]";
         }
         else if ( ( AV30OrderedBy == 4 ) && ( AV31OrderedDsc ) )
         {
            sOrderString += " ORDER BY [SGAuDocGls] DESC";
         }
         else if ( ( AV30OrderedBy == 5 ) && ! AV31OrderedDsc )
         {
            sOrderString += " ORDER BY [SGAuDocNum]";
         }
         else if ( ( AV30OrderedBy == 5 ) && ( AV31OrderedDsc ) )
         {
            sOrderString += " ORDER BY [SGAuDocNum] DESC";
         }
         else if ( ( AV30OrderedBy == 6 ) && ! AV31OrderedDsc )
         {
            sOrderString += " ORDER BY [SGAuDocRef]";
         }
         else if ( ( AV30OrderedBy == 6 ) && ( AV31OrderedDsc ) )
         {
            sOrderString += " ORDER BY [SGAuDocRef] DESC";
         }
         else if ( ( AV30OrderedBy == 7 ) && ! AV31OrderedDsc )
         {
            sOrderString += " ORDER BY [SGAuTipCod]";
         }
         else if ( ( AV30OrderedBy == 7 ) && ( AV31OrderedDsc ) )
         {
            sOrderString += " ORDER BY [SGAuTipCod] DESC";
         }
         else if ( ( AV30OrderedBy == 8 ) && ! AV31OrderedDsc )
         {
            sOrderString += " ORDER BY [SGAuTipo]";
         }
         else if ( ( AV30OrderedBy == 8 ) && ( AV31OrderedDsc ) )
         {
            sOrderString += " ORDER BY [SGAuTipo] DESC";
         }
         else if ( ( AV30OrderedBy == 9 ) && ! AV31OrderedDsc )
         {
            sOrderString += " ORDER BY [SGAuUsuCod]";
         }
         else if ( ( AV30OrderedBy == 9 ) && ( AV31OrderedDsc ) )
         {
            sOrderString += " ORDER BY [SGAuUsuCod] DESC";
         }
         else if ( true )
         {
            sOrderString += " ORDER BY [SGAuMod], [SGAuFecha]";
         }
         scmdbuf = "SELECT " + sSelectString + sFromString + sWhereString + sOrderString + "" + " OFFSET " + "@GXPagingFrom2" + " ROWS FETCH NEXT CAST((SELECT CASE WHEN " + "@GXPagingTo2" + " > 0 THEN " + "@GXPagingTo2" + " ELSE 1e9 END) AS INTEGER) ROWS ONLY";
         GXv_Object10[0] = scmdbuf;
         GXv_Object10[1] = GXv_int9;
         return GXv_Object10 ;
      }

      protected Object[] conditional_H000I4( IGxContext context ,
                                             string A337SGAuMod ,
                                             GxSimpleCollection<string> AV79Seguridad_auditoriads_6_tfsgaumod_sels ,
                                             string AV74Seguridad_auditoriads_1_usucod ,
                                             string AV75Seguridad_auditoriads_2_sgaumod ,
                                             short AV39SGAuFechOperator ,
                                             DateTime AV77Seguridad_auditoriads_4_sgaufech ,
                                             DateTime AV78Seguridad_auditoriads_5_sgaufech_to ,
                                             int AV79Seguridad_auditoriads_6_tfsgaumod_sels_Count ,
                                             DateTime AV80Seguridad_auditoriads_7_tfsgaufecha ,
                                             DateTime AV81Seguridad_auditoriads_8_tfsgaufecha_to ,
                                             string AV83Seguridad_auditoriads_10_tfsgaudocgls_sel ,
                                             string AV82Seguridad_auditoriads_9_tfsgaudocgls ,
                                             string AV85Seguridad_auditoriads_12_tfsgaudocnum_sel ,
                                             string AV84Seguridad_auditoriads_11_tfsgaudocnum ,
                                             string AV87Seguridad_auditoriads_14_tfsgaudocref_sel ,
                                             string AV86Seguridad_auditoriads_13_tfsgaudocref ,
                                             string AV89Seguridad_auditoriads_16_tfsgautipcod_sel ,
                                             string AV88Seguridad_auditoriads_15_tfsgautipcod ,
                                             string AV91Seguridad_auditoriads_18_tfsgautipo_sel ,
                                             string AV90Seguridad_auditoriads_17_tfsgautipo ,
                                             string AV93Seguridad_auditoriads_20_tfsgauusucod_sel ,
                                             string AV92Seguridad_auditoriads_19_tfsgauusucod ,
                                             string A1849SGAuUsuCod ,
                                             DateTime A1846SGAuFech ,
                                             DateTime A338SGAuFecha ,
                                             string A1843SGAuDocGls ,
                                             string A1844SGAuDocNum ,
                                             string A1845SGAuDocRef ,
                                             string A1847SGAuTipCod ,
                                             string A1848SGAuTipo ,
                                             short AV30OrderedBy ,
                                             bool AV31OrderedDsc ,
                                             string AV76Seguridad_auditoriads_3_sgaudocgls )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int11 = new short[22];
         Object[] GXv_Object12 = new Object[2];
         scmdbuf = "SELECT COUNT(*) FROM [SGAUDITORIA]";
         AddWhere(sWhereString, "([SGAuDocGls] like '%' + @lV76Seguridad_auditoriads_3_sgaudocgls + '%')");
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV74Seguridad_auditoriads_1_usucod)) )
         {
            AddWhere(sWhereString, "([SGAuUsuCod] = @AV74Seguridad_auditoriads_1_usucod)");
         }
         else
         {
            GXv_int11[1] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV75Seguridad_auditoriads_2_sgaumod)) )
         {
            AddWhere(sWhereString, "([SGAuMod] = @AV75Seguridad_auditoriads_2_sgaumod)");
         }
         else
         {
            GXv_int11[2] = 1;
         }
         if ( ( AV39SGAuFechOperator == 0 ) && ( ! (DateTime.MinValue==AV77Seguridad_auditoriads_4_sgaufech) ) )
         {
            AddWhere(sWhereString, "([SGAuFech] = @AV77Seguridad_auditoriads_4_sgaufech)");
         }
         else
         {
            GXv_int11[3] = 1;
         }
         if ( ( AV39SGAuFechOperator == 1 ) && ( ! (DateTime.MinValue==AV77Seguridad_auditoriads_4_sgaufech) ) )
         {
            AddWhere(sWhereString, "([SGAuFech] < @AV77Seguridad_auditoriads_4_sgaufech)");
         }
         else
         {
            GXv_int11[4] = 1;
         }
         if ( ( AV39SGAuFechOperator == 2 ) && ( ! (DateTime.MinValue==AV77Seguridad_auditoriads_4_sgaufech) ) )
         {
            AddWhere(sWhereString, "([SGAuFech] > @AV77Seguridad_auditoriads_4_sgaufech)");
         }
         else
         {
            GXv_int11[5] = 1;
         }
         if ( ( AV39SGAuFechOperator == 3 ) && ( ! (DateTime.MinValue==AV77Seguridad_auditoriads_4_sgaufech) ) )
         {
            AddWhere(sWhereString, "([SGAuFech] >= @AV77Seguridad_auditoriads_4_sgaufech)");
         }
         else
         {
            GXv_int11[6] = 1;
         }
         if ( ( AV39SGAuFechOperator == 3 ) && ( ! (DateTime.MinValue==AV78Seguridad_auditoriads_5_sgaufech_to) ) )
         {
            AddWhere(sWhereString, "([SGAuFech] <= @AV78Seguridad_auditoriads_5_sgaufech_to)");
         }
         else
         {
            GXv_int11[7] = 1;
         }
         if ( AV79Seguridad_auditoriads_6_tfsgaumod_sels_Count > 0 )
         {
            AddWhere(sWhereString, "("+new GxDbmsUtils( new GxSqlServer()).ValueList(AV79Seguridad_auditoriads_6_tfsgaumod_sels, "[SGAuMod] IN (", ")")+")");
         }
         if ( ! (DateTime.MinValue==AV80Seguridad_auditoriads_7_tfsgaufecha) )
         {
            AddWhere(sWhereString, "([SGAuFecha] >= @AV80Seguridad_auditoriads_7_tfsgaufecha)");
         }
         else
         {
            GXv_int11[8] = 1;
         }
         if ( ! (DateTime.MinValue==AV81Seguridad_auditoriads_8_tfsgaufecha_to) )
         {
            AddWhere(sWhereString, "([SGAuFecha] <= @AV81Seguridad_auditoriads_8_tfsgaufecha_to)");
         }
         else
         {
            GXv_int11[9] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV83Seguridad_auditoriads_10_tfsgaudocgls_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV82Seguridad_auditoriads_9_tfsgaudocgls)) ) )
         {
            AddWhere(sWhereString, "([SGAuDocGls] like @lV82Seguridad_auditoriads_9_tfsgaudocgls)");
         }
         else
         {
            GXv_int11[10] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV83Seguridad_auditoriads_10_tfsgaudocgls_sel)) )
         {
            AddWhere(sWhereString, "([SGAuDocGls] = @AV83Seguridad_auditoriads_10_tfsgaudocgls_sel)");
         }
         else
         {
            GXv_int11[11] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV85Seguridad_auditoriads_12_tfsgaudocnum_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV84Seguridad_auditoriads_11_tfsgaudocnum)) ) )
         {
            AddWhere(sWhereString, "([SGAuDocNum] like @lV84Seguridad_auditoriads_11_tfsgaudocnum)");
         }
         else
         {
            GXv_int11[12] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV85Seguridad_auditoriads_12_tfsgaudocnum_sel)) )
         {
            AddWhere(sWhereString, "([SGAuDocNum] = @AV85Seguridad_auditoriads_12_tfsgaudocnum_sel)");
         }
         else
         {
            GXv_int11[13] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV87Seguridad_auditoriads_14_tfsgaudocref_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV86Seguridad_auditoriads_13_tfsgaudocref)) ) )
         {
            AddWhere(sWhereString, "([SGAuDocRef] like @lV86Seguridad_auditoriads_13_tfsgaudocref)");
         }
         else
         {
            GXv_int11[14] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV87Seguridad_auditoriads_14_tfsgaudocref_sel)) )
         {
            AddWhere(sWhereString, "([SGAuDocRef] = @AV87Seguridad_auditoriads_14_tfsgaudocref_sel)");
         }
         else
         {
            GXv_int11[15] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV89Seguridad_auditoriads_16_tfsgautipcod_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV88Seguridad_auditoriads_15_tfsgautipcod)) ) )
         {
            AddWhere(sWhereString, "([SGAuTipCod] like @lV88Seguridad_auditoriads_15_tfsgautipcod)");
         }
         else
         {
            GXv_int11[16] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV89Seguridad_auditoriads_16_tfsgautipcod_sel)) )
         {
            AddWhere(sWhereString, "([SGAuTipCod] = @AV89Seguridad_auditoriads_16_tfsgautipcod_sel)");
         }
         else
         {
            GXv_int11[17] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV91Seguridad_auditoriads_18_tfsgautipo_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV90Seguridad_auditoriads_17_tfsgautipo)) ) )
         {
            AddWhere(sWhereString, "([SGAuTipo] like @lV90Seguridad_auditoriads_17_tfsgautipo)");
         }
         else
         {
            GXv_int11[18] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV91Seguridad_auditoriads_18_tfsgautipo_sel)) )
         {
            AddWhere(sWhereString, "([SGAuTipo] = @AV91Seguridad_auditoriads_18_tfsgautipo_sel)");
         }
         else
         {
            GXv_int11[19] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV93Seguridad_auditoriads_20_tfsgauusucod_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV92Seguridad_auditoriads_19_tfsgauusucod)) ) )
         {
            AddWhere(sWhereString, "([SGAuUsuCod] like @lV92Seguridad_auditoriads_19_tfsgauusucod)");
         }
         else
         {
            GXv_int11[20] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV93Seguridad_auditoriads_20_tfsgauusucod_sel)) )
         {
            AddWhere(sWhereString, "([SGAuUsuCod] = @AV93Seguridad_auditoriads_20_tfsgauusucod_sel)");
         }
         else
         {
            GXv_int11[21] = 1;
         }
         scmdbuf += sWhereString;
         if ( AV30OrderedBy == 1 )
         {
            scmdbuf += "";
         }
         else if ( ( AV30OrderedBy == 2 ) && ! AV31OrderedDsc )
         {
            scmdbuf += "";
         }
         else if ( ( AV30OrderedBy == 2 ) && ( AV31OrderedDsc ) )
         {
            scmdbuf += "";
         }
         else if ( ( AV30OrderedBy == 3 ) && ! AV31OrderedDsc )
         {
            scmdbuf += "";
         }
         else if ( ( AV30OrderedBy == 3 ) && ( AV31OrderedDsc ) )
         {
            scmdbuf += "";
         }
         else if ( ( AV30OrderedBy == 4 ) && ! AV31OrderedDsc )
         {
            scmdbuf += "";
         }
         else if ( ( AV30OrderedBy == 4 ) && ( AV31OrderedDsc ) )
         {
            scmdbuf += "";
         }
         else if ( ( AV30OrderedBy == 5 ) && ! AV31OrderedDsc )
         {
            scmdbuf += "";
         }
         else if ( ( AV30OrderedBy == 5 ) && ( AV31OrderedDsc ) )
         {
            scmdbuf += "";
         }
         else if ( ( AV30OrderedBy == 6 ) && ! AV31OrderedDsc )
         {
            scmdbuf += "";
         }
         else if ( ( AV30OrderedBy == 6 ) && ( AV31OrderedDsc ) )
         {
            scmdbuf += "";
         }
         else if ( ( AV30OrderedBy == 7 ) && ! AV31OrderedDsc )
         {
            scmdbuf += "";
         }
         else if ( ( AV30OrderedBy == 7 ) && ( AV31OrderedDsc ) )
         {
            scmdbuf += "";
         }
         else if ( ( AV30OrderedBy == 8 ) && ! AV31OrderedDsc )
         {
            scmdbuf += "";
         }
         else if ( ( AV30OrderedBy == 8 ) && ( AV31OrderedDsc ) )
         {
            scmdbuf += "";
         }
         else if ( ( AV30OrderedBy == 9 ) && ! AV31OrderedDsc )
         {
            scmdbuf += "";
         }
         else if ( ( AV30OrderedBy == 9 ) && ( AV31OrderedDsc ) )
         {
            scmdbuf += "";
         }
         else if ( true )
         {
            scmdbuf += "";
         }
         GXv_Object12[0] = scmdbuf;
         GXv_Object12[1] = GXv_int11;
         return GXv_Object12 ;
      }

      public override Object [] getDynamicStatement( int cursor ,
                                                     IGxContext context ,
                                                     Object [] dynConstraints )
      {
         switch ( cursor )
         {
               case 1 :
                     return conditional_H000I3(context, (string)dynConstraints[0] , (GxSimpleCollection<string>)dynConstraints[1] , (string)dynConstraints[2] , (string)dynConstraints[3] , (short)dynConstraints[4] , (DateTime)dynConstraints[5] , (DateTime)dynConstraints[6] , (int)dynConstraints[7] , (DateTime)dynConstraints[8] , (DateTime)dynConstraints[9] , (string)dynConstraints[10] , (string)dynConstraints[11] , (string)dynConstraints[12] , (string)dynConstraints[13] , (string)dynConstraints[14] , (string)dynConstraints[15] , (string)dynConstraints[16] , (string)dynConstraints[17] , (string)dynConstraints[18] , (string)dynConstraints[19] , (string)dynConstraints[20] , (string)dynConstraints[21] , (string)dynConstraints[22] , (DateTime)dynConstraints[23] , (DateTime)dynConstraints[24] , (string)dynConstraints[25] , (string)dynConstraints[26] , (string)dynConstraints[27] , (string)dynConstraints[28] , (string)dynConstraints[29] , (short)dynConstraints[30] , (bool)dynConstraints[31] , (string)dynConstraints[32] );
               case 2 :
                     return conditional_H000I4(context, (string)dynConstraints[0] , (GxSimpleCollection<string>)dynConstraints[1] , (string)dynConstraints[2] , (string)dynConstraints[3] , (short)dynConstraints[4] , (DateTime)dynConstraints[5] , (DateTime)dynConstraints[6] , (int)dynConstraints[7] , (DateTime)dynConstraints[8] , (DateTime)dynConstraints[9] , (string)dynConstraints[10] , (string)dynConstraints[11] , (string)dynConstraints[12] , (string)dynConstraints[13] , (string)dynConstraints[14] , (string)dynConstraints[15] , (string)dynConstraints[16] , (string)dynConstraints[17] , (string)dynConstraints[18] , (string)dynConstraints[19] , (string)dynConstraints[20] , (string)dynConstraints[21] , (string)dynConstraints[22] , (DateTime)dynConstraints[23] , (DateTime)dynConstraints[24] , (string)dynConstraints[25] , (string)dynConstraints[26] , (string)dynConstraints[27] , (string)dynConstraints[28] , (string)dynConstraints[29] , (short)dynConstraints[30] , (bool)dynConstraints[31] , (string)dynConstraints[32] );
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
       };
    }

    private static CursorDef[] def;
    private void cursorDefinitions( )
    {
       if ( def == null )
       {
          Object[] prmH000I2;
          prmH000I2 = new Object[] {
          };
          Object[] prmH000I3;
          prmH000I3 = new Object[] {
          new ParDef("@lV76Seguridad_auditoriads_3_sgaudocgls",GXType.NVarChar,100,0) ,
          new ParDef("@AV74Seguridad_auditoriads_1_usucod",GXType.NChar,10,0) ,
          new ParDef("@AV75Seguridad_auditoriads_2_sgaumod",GXType.NVarChar,5,0) ,
          new ParDef("@AV77Seguridad_auditoriads_4_sgaufech",GXType.Date,8,0) ,
          new ParDef("@AV77Seguridad_auditoriads_4_sgaufech",GXType.Date,8,0) ,
          new ParDef("@AV77Seguridad_auditoriads_4_sgaufech",GXType.Date,8,0) ,
          new ParDef("@AV77Seguridad_auditoriads_4_sgaufech",GXType.Date,8,0) ,
          new ParDef("@AV78Seguridad_auditoriads_5_sgaufech_to",GXType.Date,8,0) ,
          new ParDef("@AV80Seguridad_auditoriads_7_tfsgaufecha",GXType.DateTime,8,5) ,
          new ParDef("@AV81Seguridad_auditoriads_8_tfsgaufecha_to",GXType.DateTime,8,5) ,
          new ParDef("@lV82Seguridad_auditoriads_9_tfsgaudocgls",GXType.NVarChar,100,0) ,
          new ParDef("@AV83Seguridad_auditoriads_10_tfsgaudocgls_sel",GXType.NVarChar,100,0) ,
          new ParDef("@lV84Seguridad_auditoriads_11_tfsgaudocnum",GXType.NVarChar,20,0) ,
          new ParDef("@AV85Seguridad_auditoriads_12_tfsgaudocnum_sel",GXType.NVarChar,20,0) ,
          new ParDef("@lV86Seguridad_auditoriads_13_tfsgaudocref",GXType.NVarChar,20,0) ,
          new ParDef("@AV87Seguridad_auditoriads_14_tfsgaudocref_sel",GXType.NVarChar,20,0) ,
          new ParDef("@lV88Seguridad_auditoriads_15_tfsgautipcod",GXType.NVarChar,5,0) ,
          new ParDef("@AV89Seguridad_auditoriads_16_tfsgautipcod_sel",GXType.NVarChar,5,0) ,
          new ParDef("@lV90Seguridad_auditoriads_17_tfsgautipo",GXType.NVarChar,20,0) ,
          new ParDef("@AV91Seguridad_auditoriads_18_tfsgautipo_sel",GXType.NVarChar,20,0) ,
          new ParDef("@lV92Seguridad_auditoriads_19_tfsgauusucod",GXType.NVarChar,10,0) ,
          new ParDef("@AV93Seguridad_auditoriads_20_tfsgauusucod_sel",GXType.NVarChar,10,0) ,
          new ParDef("@GXPagingFrom2",GXType.Int32,9,0) ,
          new ParDef("@GXPagingTo2",GXType.Int32,9,0) ,
          new ParDef("@GXPagingTo2",GXType.Int32,9,0)
          };
          Object[] prmH000I4;
          prmH000I4 = new Object[] {
          new ParDef("@lV76Seguridad_auditoriads_3_sgaudocgls",GXType.NVarChar,100,0) ,
          new ParDef("@AV74Seguridad_auditoriads_1_usucod",GXType.NChar,10,0) ,
          new ParDef("@AV75Seguridad_auditoriads_2_sgaumod",GXType.NVarChar,5,0) ,
          new ParDef("@AV77Seguridad_auditoriads_4_sgaufech",GXType.Date,8,0) ,
          new ParDef("@AV77Seguridad_auditoriads_4_sgaufech",GXType.Date,8,0) ,
          new ParDef("@AV77Seguridad_auditoriads_4_sgaufech",GXType.Date,8,0) ,
          new ParDef("@AV77Seguridad_auditoriads_4_sgaufech",GXType.Date,8,0) ,
          new ParDef("@AV78Seguridad_auditoriads_5_sgaufech_to",GXType.Date,8,0) ,
          new ParDef("@AV80Seguridad_auditoriads_7_tfsgaufecha",GXType.DateTime,8,5) ,
          new ParDef("@AV81Seguridad_auditoriads_8_tfsgaufecha_to",GXType.DateTime,8,5) ,
          new ParDef("@lV82Seguridad_auditoriads_9_tfsgaudocgls",GXType.NVarChar,100,0) ,
          new ParDef("@AV83Seguridad_auditoriads_10_tfsgaudocgls_sel",GXType.NVarChar,100,0) ,
          new ParDef("@lV84Seguridad_auditoriads_11_tfsgaudocnum",GXType.NVarChar,20,0) ,
          new ParDef("@AV85Seguridad_auditoriads_12_tfsgaudocnum_sel",GXType.NVarChar,20,0) ,
          new ParDef("@lV86Seguridad_auditoriads_13_tfsgaudocref",GXType.NVarChar,20,0) ,
          new ParDef("@AV87Seguridad_auditoriads_14_tfsgaudocref_sel",GXType.NVarChar,20,0) ,
          new ParDef("@lV88Seguridad_auditoriads_15_tfsgautipcod",GXType.NVarChar,5,0) ,
          new ParDef("@AV89Seguridad_auditoriads_16_tfsgautipcod_sel",GXType.NVarChar,5,0) ,
          new ParDef("@lV90Seguridad_auditoriads_17_tfsgautipo",GXType.NVarChar,20,0) ,
          new ParDef("@AV91Seguridad_auditoriads_18_tfsgautipo_sel",GXType.NVarChar,20,0) ,
          new ParDef("@lV92Seguridad_auditoriads_19_tfsgauusucod",GXType.NVarChar,10,0) ,
          new ParDef("@AV93Seguridad_auditoriads_20_tfsgauusucod_sel",GXType.NVarChar,10,0)
          };
          def= new CursorDef[] {
              new CursorDef("H000I2", "SELECT [UsuCod], [UsuNom], [UsuSts] FROM [SGUSUARIOS] WHERE [UsuSts] = 1 ORDER BY [UsuNom] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH000I2,0, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("H000I3", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH000I3,11, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("H000I4", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH000I4,1, GxCacheFrequency.OFF ,true,false )
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
                ((string[]) buf[0])[0] = rslt.getString(1, 10);
                ((string[]) buf[1])[0] = rslt.getString(2, 100);
                ((short[]) buf[2])[0] = rslt.getShort(3);
                return;
             case 1 :
                ((DateTime[]) buf[0])[0] = rslt.getGXDate(1);
                ((string[]) buf[1])[0] = rslt.getVarchar(2);
                ((string[]) buf[2])[0] = rslt.getVarchar(3);
                ((string[]) buf[3])[0] = rslt.getVarchar(4);
                ((string[]) buf[4])[0] = rslt.getVarchar(5);
                ((string[]) buf[5])[0] = rslt.getVarchar(6);
                ((string[]) buf[6])[0] = rslt.getVarchar(7);
                ((DateTime[]) buf[7])[0] = rslt.getGXDateTime(8);
                ((string[]) buf[8])[0] = rslt.getVarchar(9);
                return;
             case 2 :
                ((long[]) buf[0])[0] = rslt.getLong(1);
                return;
       }
    }

 }

}
