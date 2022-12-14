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
namespace GeneXus.Programs.generales {
   public class wwbusquedaproducto : GXDataArea
   {
      public wwbusquedaproducto( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDataStore2 = context.GetDataStore("DataStore2");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusTheme");
      }

      public wwbusquedaproducto( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsDataStore2 = context.GetDataStore("DataStore2");
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( out string aP0_OutProdCod ,
                           out string aP1_OutProdDsc ,
                           string aP2_InTipo )
      {
         this.AV61OutProdCod = "" ;
         this.AV62OutProdDsc = "" ;
         this.AV64InTipo = aP2_InTipo;
         executePrivate();
         aP0_OutProdCod=this.AV61OutProdCod;
         aP1_OutProdDsc=this.AV62OutProdDsc;
      }

      void executePrivate( )
      {
         isStatic = false;
         webExecute();
      }

      protected override void createObjects( )
      {
         chkProdVta = new GXCheckbox();
         chkProdCmp = new GXCheckbox();
         cmbProdSts = new GXCombobox();
      }

      protected void INITWEB( )
      {
         initialize_properties( ) ;
         if ( nGotPars == 0 )
         {
            entryPointCalled = false;
            gxfirstwebparm = GetFirstPar( "OutProdCod");
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
               gxfirstwebparm = GetFirstPar( "OutProdCod");
            }
            else if ( StringUtil.StrCmp(gxfirstwebparm, "gxfullajaxEvt") == 0 )
            {
               if ( ! IsValidAjaxCall( true) )
               {
                  GxWebError = 1;
                  return  ;
               }
               gxfirstwebparm = GetFirstPar( "OutProdCod");
            }
            else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxNewRow_"+"Grid") == 0 )
            {
               nRC_GXsfl_27 = (int)(NumberUtil.Val( GetPar( "nRC_GXsfl_27"), "."));
               nGXsfl_27_idx = (int)(NumberUtil.Val( GetPar( "nGXsfl_27_idx"), "."));
               sGXsfl_27_idx = GetPar( "sGXsfl_27_idx");
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
               AV60FilterFullText = GetPar( "FilterFullText");
               AV64InTipo = GetPar( "InTipo");
               AV71Pgmname = GetPar( "Pgmname");
               AV13OrderedBy = (short)(NumberUtil.Val( GetPar( "OrderedBy"), "."));
               AV14OrderedDsc = StringUtil.StrToBool( GetPar( "OrderedDsc"));
               AV40TFProdCod = GetPar( "TFProdCod");
               AV41TFProdCod_Sel = GetPar( "TFProdCod_Sel");
               AV42TFProdDsc = GetPar( "TFProdDsc");
               AV43TFProdDsc_Sel = GetPar( "TFProdDsc_Sel");
               AV65TFUniAbr = GetPar( "TFUniAbr");
               AV66TFUniAbr_Sel = GetPar( "TFUniAbr_Sel");
               AV67TFProdReferencias = GetPar( "TFProdReferencias");
               AV68TFProdReferencias_Sel = GetPar( "TFProdReferencias_Sel");
               setAjaxCallMode();
               if ( ! IsValidAjaxCall( true) )
               {
                  GxWebError = 1;
                  return  ;
               }
               gxgrGrid_refresh( subGrid_Rows, AV60FilterFullText, AV64InTipo, AV71Pgmname, AV13OrderedBy, AV14OrderedDsc, AV40TFProdCod, AV41TFProdCod_Sel, AV42TFProdDsc, AV43TFProdDsc_Sel, AV65TFUniAbr, AV66TFUniAbr_Sel, AV67TFProdReferencias, AV68TFProdReferencias_Sel) ;
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
            if ( ! entryPointCalled && ! ( isAjaxCallMode( ) || isFullAjaxMode( ) ) )
            {
               AV61OutProdCod = gxfirstwebparm;
               AssignAttri("", false, "AV61OutProdCod", AV61OutProdCod);
               if ( StringUtil.StrCmp(gxfirstwebparm, "viewer") != 0 )
               {
                  AV62OutProdDsc = GetPar( "OutProdDsc");
                  AssignAttri("", false, "AV62OutProdDsc", AV62OutProdDsc);
                  AV64InTipo = GetPar( "InTipo");
                  AssignAttri("", false, "AV64InTipo", AV64InTipo);
               }
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
            MasterPageObj = (GXMasterPage) ClassLoader.GetInstance("wwpbaseobjects.workwithplusmasterpageprompt", "GeneXus.Programs.wwpbaseobjects.workwithplusmasterpageprompt", new Object[] {new GxContext( context.handle, context.DataStores, context.HttpContext)});
            MasterPageObj.setDataArea(this,true);
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
         PA2N2( ) ;
         gxajaxcallmode = (short)((isAjaxCallMode( ) ? 1 : 0));
         if ( ( gxajaxcallmode == 0 ) && ( GxWebError == 0 ) )
         {
            START2N2( ) ;
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
         context.AddJavascriptSource("gxcfg.js", "?202281810304490", false, true);
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
         context.AddJavascriptSource("DVelop/Shared/WorkWithPlusCommon.js", "", false, true);
         context.AddJavascriptSource("DVelop/GridEmpowerer/GridEmpowererRender.js", "", false, true);
         context.WriteHtmlText( Form.Headerrawhtml) ;
         context.CloseHtmlHeader();
         if ( context.isSpaRequest( ) )
         {
            disableOutput();
         }
         FormProcess = " data-HasEnter=\"true\" data-Skiponenter=\"false\"";
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
         context.WriteHtmlText( " "+"class=\"form-horizontal FormNoBackgroundColor\""+" "+ "style='"+bodyStyle+"'") ;
         context.WriteHtmlText( FormProcess+">") ;
         context.skipLines(1);
         context.WriteHtmlTextNl( "<form id=\"MAINFORM\" autocomplete=\"off\" name=\"MAINFORM\" method=\"post\" tabindex=-1  class=\"form-horizontal FormNoBackgroundColor\" data-gx-class=\"form-horizontal FormNoBackgroundColor\" novalidate action=\""+formatLink("generales.wwbusquedaproducto.aspx", new object[] {UrlEncode(StringUtil.RTrim(AV61OutProdCod)),UrlEncode(StringUtil.RTrim(AV62OutProdDsc)),UrlEncode(StringUtil.RTrim(AV64InTipo))}, new string[] {"OutProdCod","OutProdDsc","InTipo"}) +"\">") ;
         GxWebStd.gx_hidden_field( context, "_EventName", "");
         GxWebStd.gx_hidden_field( context, "_EventGridId", "");
         GxWebStd.gx_hidden_field( context, "_EventRowId", "");
         context.WriteHtmlText( "<input type=\"submit\" title=\"submit\" style=\"display:block;height:0;border:0;padding:0\" disabled>") ;
         AssignProp("", false, "FORM", "Class", "form-horizontal FormNoBackgroundColor", true);
         toggleJsOutput = isJsOutputEnabled( );
         if ( context.isSpaRequest( ) )
         {
            disableJsOutput();
         }
      }

      protected void send_integrity_footer_hashes( )
      {
         GxWebStd.gx_hidden_field( context, "gxhash_vPGMNAME", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( AV71Pgmname, "")), context));
         GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
      }

      protected void SendCloseFormHiddens( )
      {
         /* Send hidden variables. */
         GxWebStd.gx_hidden_field( context, "GXH_vFILTERFULLTEXT", AV60FilterFullText);
         /* Send saved values. */
         send_integrity_footer_hashes( ) ;
         GxWebStd.gx_hidden_field( context, "nRC_GXsfl_27", StringUtil.LTrim( StringUtil.NToC( (decimal)(nRC_GXsfl_27), 8, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "vGRIDCURRENTPAGE", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV54GridCurrentPage), 10, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "vGRIDPAGECOUNT", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV55GridPageCount), 10, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "vGRIDAPPLIEDFILTERS", AV56GridAppliedFilters);
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "vDDO_TITLESETTINGSICONS", AV52DDO_TitleSettingsIcons);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt("vDDO_TITLESETTINGSICONS", AV52DDO_TitleSettingsIcons);
         }
         GxWebStd.gx_hidden_field( context, "vPGMNAME", StringUtil.RTrim( AV71Pgmname));
         GxWebStd.gx_hidden_field( context, "gxhash_vPGMNAME", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( AV71Pgmname, "")), context));
         GxWebStd.gx_hidden_field( context, "vORDEREDBY", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV13OrderedBy), 4, 0, ".", "")));
         GxWebStd.gx_boolean_hidden_field( context, "vORDEREDDSC", AV14OrderedDsc);
         GxWebStd.gx_hidden_field( context, "vTFPRODCOD", StringUtil.RTrim( AV40TFProdCod));
         GxWebStd.gx_hidden_field( context, "vTFPRODCOD_SEL", StringUtil.RTrim( AV41TFProdCod_Sel));
         GxWebStd.gx_hidden_field( context, "vTFPRODDSC", StringUtil.RTrim( AV42TFProdDsc));
         GxWebStd.gx_hidden_field( context, "vTFPRODDSC_SEL", StringUtil.RTrim( AV43TFProdDsc_Sel));
         GxWebStd.gx_hidden_field( context, "vTFUNIABR", StringUtil.RTrim( AV65TFUniAbr));
         GxWebStd.gx_hidden_field( context, "vTFUNIABR_SEL", StringUtil.RTrim( AV66TFUniAbr_Sel));
         GxWebStd.gx_hidden_field( context, "vTFPRODREFERENCIAS", AV67TFProdReferencias);
         GxWebStd.gx_hidden_field( context, "vTFPRODREFERENCIAS_SEL", AV68TFProdReferencias_Sel);
         GxWebStd.gx_hidden_field( context, "vOUTPRODCOD", StringUtil.RTrim( AV61OutProdCod));
         GxWebStd.gx_hidden_field( context, "vOUTPRODDSC", StringUtil.RTrim( AV62OutProdDsc));
         GxWebStd.gx_hidden_field( context, "vINTIPO", AV64InTipo);
         GxWebStd.gx_hidden_field( context, "GRID_nFirstRecordOnPage", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRID_nFirstRecordOnPage), 15, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "GRID_nEOF", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRID_nEOF), 1, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "PRODREF1", StringUtil.RTrim( A1705ProdRef1));
         GxWebStd.gx_hidden_field( context, "PRODREF2", StringUtil.RTrim( A1707ProdRef2));
         GxWebStd.gx_hidden_field( context, "PRODREF3", StringUtil.RTrim( A1708ProdRef3));
         GxWebStd.gx_hidden_field( context, "PRODREF4", StringUtil.RTrim( A1709ProdRef4));
         GxWebStd.gx_hidden_field( context, "PRODREF5", StringUtil.RTrim( A1710ProdRef5));
         GxWebStd.gx_hidden_field( context, "PRODREF6", StringUtil.RTrim( A1711ProdRef6));
         GxWebStd.gx_hidden_field( context, "PRODREF7", StringUtil.RTrim( A1712ProdRef7));
         GxWebStd.gx_hidden_field( context, "PRODREF8", StringUtil.RTrim( A1713ProdRef8));
         GxWebStd.gx_hidden_field( context, "PRODREF9", StringUtil.RTrim( A1714ProdRef9));
         GxWebStd.gx_hidden_field( context, "PRODREF10", StringUtil.RTrim( A1706ProdRef10));
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
         GxWebStd.gx_hidden_field( context, "DDO_GRID_Datalistproc", StringUtil.RTrim( Ddo_grid_Datalistproc));
         GxWebStd.gx_hidden_field( context, "GRID_EMPOWERER_Gridinternalname", StringUtil.RTrim( Grid_empowerer_Gridinternalname));
         GxWebStd.gx_hidden_field( context, "GRID_EMPOWERER_Hastitlesettings", StringUtil.BoolToStr( Grid_empowerer_Hastitlesettings));
         GxWebStd.gx_hidden_field( context, "GRID_Rows", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid_Rows), 6, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "GRIDPAGINATIONBAR_Selectedpage", StringUtil.RTrim( Gridpaginationbar_Selectedpage));
         GxWebStd.gx_hidden_field( context, "GRIDPAGINATIONBAR_Rowsperpageselectedvalue", StringUtil.LTrim( StringUtil.NToC( (decimal)(Gridpaginationbar_Rowsperpageselectedvalue), 9, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "DDO_GRID_Activeeventkey", StringUtil.RTrim( Ddo_grid_Activeeventkey));
         GxWebStd.gx_hidden_field( context, "DDO_GRID_Selectedvalue_get", StringUtil.RTrim( Ddo_grid_Selectedvalue_get));
         GxWebStd.gx_hidden_field( context, "DDO_GRID_Selectedcolumn", StringUtil.RTrim( Ddo_grid_Selectedcolumn));
         GxWebStd.gx_hidden_field( context, "DDO_GRID_Filteredtext_get", StringUtil.RTrim( Ddo_grid_Filteredtext_get));
         GxWebStd.gx_hidden_field( context, "GRID_Rows", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid_Rows), 6, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "GRIDPAGINATIONBAR_Selectedpage", StringUtil.RTrim( Gridpaginationbar_Selectedpage));
         GxWebStd.gx_hidden_field( context, "GRIDPAGINATIONBAR_Rowsperpageselectedvalue", StringUtil.LTrim( StringUtil.NToC( (decimal)(Gridpaginationbar_Rowsperpageselectedvalue), 9, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "DDO_GRID_Activeeventkey", StringUtil.RTrim( Ddo_grid_Activeeventkey));
         GxWebStd.gx_hidden_field( context, "DDO_GRID_Selectedvalue_get", StringUtil.RTrim( Ddo_grid_Selectedvalue_get));
         GxWebStd.gx_hidden_field( context, "DDO_GRID_Selectedcolumn", StringUtil.RTrim( Ddo_grid_Selectedcolumn));
         GxWebStd.gx_hidden_field( context, "DDO_GRID_Filteredtext_get", StringUtil.RTrim( Ddo_grid_Filteredtext_get));
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
            GxWebStd.ClassAttribute( context, "gx-ct-body"+" "+(String.IsNullOrEmpty(StringUtil.RTrim( Form.Class)) ? "form-horizontal FormNoBackgroundColor" : Form.Class)+"-fx");
            context.WriteHtmlText( ">") ;
            WE2N2( ) ;
            context.WriteHtmlText( "</div>") ;
         }
      }

      public override void DispatchEvents( )
      {
         EVT2N2( ) ;
      }

      public override bool HasEnterEvent( )
      {
         return true ;
      }

      public override GXWebForm GetForm( )
      {
         return Form ;
      }

      public override string GetSelfLink( )
      {
         return formatLink("generales.wwbusquedaproducto.aspx", new object[] {UrlEncode(StringUtil.RTrim(AV61OutProdCod)),UrlEncode(StringUtil.RTrim(AV62OutProdDsc)),UrlEncode(StringUtil.RTrim(AV64InTipo))}, new string[] {"OutProdCod","OutProdDsc","InTipo"})  ;
      }

      public override string GetPgmname( )
      {
         return "Generales.WWBusquedaProducto" ;
      }

      public override string GetPgmdesc( )
      {
         return "Selecciona  Producto" ;
      }

      protected void WB2N0( )
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
            wb_table1_13_2N2( true) ;
         }
         else
         {
            wb_table1_13_2N2( false) ;
         }
         return  ;
      }

      protected void wb_table1_13_2N2e( bool wbgen )
      {
         if ( wbgen )
         {
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
               context.WriteHtmlText( "<div id=\""+"GridContainer"+"DivS\" data-gxgridid=\"27\">") ;
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
               context.SendWebValue( "") ;
               context.WriteHtmlTextNl( "</th>") ;
               context.WriteHtmlText( "<th align=\""+"left"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+""+""+"\" "+">") ;
               context.SendWebValue( "Codigo") ;
               context.WriteHtmlTextNl( "</th>") ;
               context.WriteHtmlText( "<th align=\""+"left"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+""+""+"\" "+">") ;
               context.SendWebValue( "Producto / Servicio") ;
               context.WriteHtmlTextNl( "</th>") ;
               context.WriteHtmlText( "<th align=\""+"left"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+""+""+"\" "+">") ;
               context.SendWebValue( "U.Medida") ;
               context.WriteHtmlTextNl( "</th>") ;
               context.WriteHtmlText( "<th align=\""+"left"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+""+""+"\" "+">") ;
               context.SendWebValue( "Referencias") ;
               context.WriteHtmlTextNl( "</th>") ;
               context.WriteHtmlText( "<th align=\""+"right"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+"display:none;"+""+"\" "+">") ;
               context.SendWebValue( "Codigo Unidad Medida") ;
               context.WriteHtmlTextNl( "</th>") ;
               context.WriteHtmlText( "<th align=\""+""+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+"display:none;"+""+"\" "+">") ;
               context.SendWebValue( "Destinado Venta") ;
               context.WriteHtmlTextNl( "</th>") ;
               context.WriteHtmlText( "<th align=\""+""+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+"display:none;"+""+"\" "+">") ;
               context.SendWebValue( "Destinado Compra") ;
               context.WriteHtmlTextNl( "</th>") ;
               context.WriteHtmlText( "<th align=\""+"right"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+"display:none;"+""+"\" "+">") ;
               context.SendWebValue( "Situacion") ;
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
               GridColumn.AddObjectProperty("Value", StringUtil.RTrim( AV57Select));
               GridColumn.AddObjectProperty("Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtavSelect_Enabled), 5, 0, ".", "")));
               GridContainer.AddColumnProperties(GridColumn);
               GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
               GridColumn.AddObjectProperty("Value", StringUtil.RTrim( A28ProdCod));
               GridContainer.AddColumnProperties(GridColumn);
               GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
               GridColumn.AddObjectProperty("Value", StringUtil.RTrim( A55ProdDsc));
               GridColumn.AddObjectProperty("Link", StringUtil.RTrim( edtProdDsc_Link));
               GridContainer.AddColumnProperties(GridColumn);
               GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
               GridColumn.AddObjectProperty("Value", StringUtil.RTrim( A1997UniAbr));
               GridContainer.AddColumnProperties(GridColumn);
               GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
               GridColumn.AddObjectProperty("Value", A1715ProdReferencias);
               GridContainer.AddColumnProperties(GridColumn);
               GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
               GridColumn.AddObjectProperty("Value", StringUtil.LTrim( StringUtil.NToC( (decimal)(A49UniCod), 6, 0, ".", "")));
               GridContainer.AddColumnProperties(GridColumn);
               GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
               GridColumn.AddObjectProperty("Value", StringUtil.LTrim( StringUtil.NToC( (decimal)(A1724ProdVta), 1, 0, ".", "")));
               GridContainer.AddColumnProperties(GridColumn);
               GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
               GridColumn.AddObjectProperty("Value", StringUtil.LTrim( StringUtil.NToC( (decimal)(A1679ProdCmp), 1, 0, ".", "")));
               GridContainer.AddColumnProperties(GridColumn);
               GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
               GridColumn.AddObjectProperty("Value", StringUtil.LTrim( StringUtil.NToC( (decimal)(A1718ProdSts), 1, 0, ".", "")));
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
         if ( wbEnd == 27 )
         {
            wbEnd = 0;
            nRC_GXsfl_27 = (int)(nGXsfl_27_idx-1);
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
            ucDdo_grid.SetProperty("Caption", Ddo_grid_Caption);
            ucDdo_grid.SetProperty("ColumnIds", Ddo_grid_Columnids);
            ucDdo_grid.SetProperty("ColumnsSortValues", Ddo_grid_Columnssortvalues);
            ucDdo_grid.SetProperty("IncludeSortASC", Ddo_grid_Includesortasc);
            ucDdo_grid.SetProperty("IncludeFilter", Ddo_grid_Includefilter);
            ucDdo_grid.SetProperty("FilterType", Ddo_grid_Filtertype);
            ucDdo_grid.SetProperty("IncludeDataList", Ddo_grid_Includedatalist);
            ucDdo_grid.SetProperty("DataListType", Ddo_grid_Datalisttype);
            ucDdo_grid.SetProperty("DataListProc", Ddo_grid_Datalistproc);
            ucDdo_grid.SetProperty("DropDownOptionsTitleSettingsIcons", AV52DDO_TitleSettingsIcons);
            ucDdo_grid.Render(context, "dvelop.gxbootstrap.ddogridtitlesettingsm", Ddo_grid_Internalname, "DDO_GRIDContainer");
            /* User Defined Control */
            ucGrid_empowerer.SetProperty("HasTitleSettings", Grid_empowerer_Hastitlesettings);
            ucGrid_empowerer.Render(context, "wwp.gridempowerer", Grid_empowerer_Internalname, "GRID_EMPOWERERContainer");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
         }
         if ( wbEnd == 27 )
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

      protected void START2N2( )
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
            Form.Meta.addItem("description", "Selecciona  Producto", 0) ;
         }
         context.wjLoc = "";
         context.nUserReturn = 0;
         context.wbHandled = 0;
         if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
         {
         }
         wbErr = false;
         STRUP2N0( ) ;
      }

      protected void WS2N2( )
      {
         START2N2( ) ;
         EVT2N2( ) ;
      }

      protected void EVT2N2( )
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
                              E112N2 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "GRIDPAGINATIONBAR.CHANGEROWSPERPAGE") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              E122N2 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "DDO_GRID.ONOPTIONCLICKED") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              E132N2 ();
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
                           if ( ( StringUtil.StrCmp(StringUtil.Left( sEvt, 5), "START") == 0 ) || ( StringUtil.StrCmp(StringUtil.Left( sEvt, 7), "REFRESH") == 0 ) || ( StringUtil.StrCmp(StringUtil.Left( sEvt, 9), "GRID.LOAD") == 0 ) || ( StringUtil.StrCmp(StringUtil.Left( sEvt, 5), "ENTER") == 0 ) || ( StringUtil.StrCmp(StringUtil.Left( sEvt, 6), "CANCEL") == 0 ) || ( StringUtil.StrCmp(StringUtil.Left( sEvt, 5), "ENTER") == 0 ) )
                           {
                              nGXsfl_27_idx = (int)(NumberUtil.Val( sEvtType, "."));
                              sGXsfl_27_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_27_idx), 4, 0), 4, "0");
                              SubsflControlProps_272( ) ;
                              AV57Select = cgiGet( edtavSelect_Internalname);
                              AssignAttri("", false, edtavSelect_Internalname, AV57Select);
                              A28ProdCod = StringUtil.Upper( cgiGet( edtProdCod_Internalname));
                              A55ProdDsc = cgiGet( edtProdDsc_Internalname);
                              A1997UniAbr = cgiGet( edtUniAbr_Internalname);
                              A1715ProdReferencias = cgiGet( edtProdReferencias_Internalname);
                              A49UniCod = (int)(context.localUtil.CToN( cgiGet( edtUniCod_Internalname), ".", ","));
                              A1724ProdVta = (short)(((StringUtil.StrCmp(cgiGet( chkProdVta_Internalname), "1")==0) ? 1 : 0));
                              A1679ProdCmp = (short)(((StringUtil.StrCmp(cgiGet( chkProdCmp_Internalname), "1")==0) ? 1 : 0));
                              cmbProdSts.Name = cmbProdSts_Internalname;
                              cmbProdSts.CurrentValue = cgiGet( cmbProdSts_Internalname);
                              A1718ProdSts = (short)(NumberUtil.Val( cgiGet( cmbProdSts_Internalname), "."));
                              sEvtType = StringUtil.Right( sEvt, 1);
                              if ( StringUtil.StrCmp(sEvtType, ".") == 0 )
                              {
                                 sEvt = StringUtil.Left( sEvt, (short)(StringUtil.Len( sEvt)-1));
                                 if ( StringUtil.StrCmp(sEvt, "START") == 0 )
                                 {
                                    context.wbHandled = 1;
                                    dynload_actions( ) ;
                                    /* Execute user event: Start */
                                    E142N2 ();
                                 }
                                 else if ( StringUtil.StrCmp(sEvt, "REFRESH") == 0 )
                                 {
                                    context.wbHandled = 1;
                                    dynload_actions( ) ;
                                    /* Execute user event: Refresh */
                                    E152N2 ();
                                 }
                                 else if ( StringUtil.StrCmp(sEvt, "GRID.LOAD") == 0 )
                                 {
                                    context.wbHandled = 1;
                                    dynload_actions( ) ;
                                    E162N2 ();
                                 }
                                 else if ( StringUtil.StrCmp(sEvt, "ENTER") == 0 )
                                 {
                                    context.wbHandled = 1;
                                    if ( ! wbErr )
                                    {
                                       Rfr0gs = false;
                                       /* Set Refresh If Filterfulltext Changed */
                                       if ( StringUtil.StrCmp(cgiGet( "GXH_vFILTERFULLTEXT"), AV60FilterFullText) != 0 )
                                       {
                                          Rfr0gs = true;
                                       }
                                       if ( ! Rfr0gs )
                                       {
                                          /* Execute user event: Enter */
                                          E172N2 ();
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

      protected void WE2N2( )
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

      protected void PA2N2( )
      {
         if ( nDonePA == 0 )
         {
            if ( String.IsNullOrEmpty(StringUtil.RTrim( context.GetCookie( "GX_SESSION_ID"))) )
            {
               gxcookieaux = context.SetCookie( "GX_SESSION_ID", Encrypt64( Crypto.GetEncryptionKey( ), Crypto.GetServerKey( )), "", (DateTime)(DateTime.MinValue), "", (short)(context.GetHttpSecure( )));
            }
            GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
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
               GX_FocusControl = edtavFilterfulltext_Internalname;
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
         SubsflControlProps_272( ) ;
         while ( nGXsfl_27_idx <= nRC_GXsfl_27 )
         {
            sendrow_272( ) ;
            nGXsfl_27_idx = ((subGrid_Islastpage==1)&&(nGXsfl_27_idx+1>subGrid_fnc_Recordsperpage( )) ? 1 : nGXsfl_27_idx+1);
            sGXsfl_27_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_27_idx), 4, 0), 4, "0");
            SubsflControlProps_272( ) ;
         }
         AddString( context.httpAjaxContext.getJSONContainerResponse( GridContainer)) ;
         /* End function gxnrGrid_newrow */
      }

      protected void gxgrGrid_refresh( int subGrid_Rows ,
                                       string AV60FilterFullText ,
                                       string AV64InTipo ,
                                       string AV71Pgmname ,
                                       short AV13OrderedBy ,
                                       bool AV14OrderedDsc ,
                                       string AV40TFProdCod ,
                                       string AV41TFProdCod_Sel ,
                                       string AV42TFProdDsc ,
                                       string AV43TFProdDsc_Sel ,
                                       string AV65TFUniAbr ,
                                       string AV66TFUniAbr_Sel ,
                                       string AV67TFProdReferencias ,
                                       string AV68TFProdReferencias_Sel )
      {
         initialize_formulas( ) ;
         GxWebStd.set_html_headers( context, 0, "", "");
         /* Execute user event: Refresh */
         E152N2 ();
         GRID_nCurrentRecord = 0;
         RF2N2( ) ;
         GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
         send_integrity_footer_hashes( ) ;
         GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
         /* End function gxgrGrid_refresh */
      }

      protected void send_integrity_hashes( )
      {
         GxWebStd.gx_hidden_field( context, "gxhash_PRODCOD", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( A28ProdCod, "@!")), context));
         GxWebStd.gx_hidden_field( context, "PRODCOD", StringUtil.RTrim( A28ProdCod));
         GxWebStd.gx_hidden_field( context, "gxhash_PRODDSC", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( A55ProdDsc, "")), context));
         GxWebStd.gx_hidden_field( context, "PRODDSC", StringUtil.RTrim( A55ProdDsc));
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
         RF2N2( ) ;
         if ( isFullAjaxMode( ) )
         {
            send_integrity_footer_hashes( ) ;
         }
      }

      protected void initialize_formulas( )
      {
         /* GeneXus formulas. */
         AV71Pgmname = "Generales.WWBusquedaProducto";
         context.Gx_err = 0;
         edtavSelect_Enabled = 0;
         AssignProp("", false, edtavSelect_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavSelect_Enabled), 5, 0), !bGXsfl_27_Refreshing);
      }

      protected void RF2N2( )
      {
         initialize_formulas( ) ;
         clear_multi_value_controls( ) ;
         if ( isAjaxCallMode( ) )
         {
            GridContainer.ClearRows();
         }
         wbStart = 27;
         /* Execute user event: Refresh */
         E152N2 ();
         nGXsfl_27_idx = 1;
         sGXsfl_27_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_27_idx), 4, 0), 4, "0");
         SubsflControlProps_272( ) ;
         bGXsfl_27_Refreshing = true;
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
            SubsflControlProps_272( ) ;
            GXPagingFrom2 = (int)(((subGrid_Rows==0) ? 0 : GRID_nFirstRecordOnPage));
            GXPagingTo2 = ((subGrid_Rows==0) ? 10000 : subGrid_fnc_Recordsperpage( )+1);
            pr_default.dynParam(0, new Object[]{ new Object[]{
                                                 AV60FilterFullText ,
                                                 AV41TFProdCod_Sel ,
                                                 AV40TFProdCod ,
                                                 AV43TFProdDsc_Sel ,
                                                 AV42TFProdDsc ,
                                                 AV66TFUniAbr_Sel ,
                                                 AV65TFUniAbr ,
                                                 AV68TFProdReferencias_Sel ,
                                                 AV67TFProdReferencias ,
                                                 AV64InTipo ,
                                                 A28ProdCod ,
                                                 A55ProdDsc ,
                                                 A1997UniAbr ,
                                                 A1705ProdRef1 ,
                                                 A1707ProdRef2 ,
                                                 A1708ProdRef3 ,
                                                 A1709ProdRef4 ,
                                                 A1710ProdRef5 ,
                                                 A1711ProdRef6 ,
                                                 A1712ProdRef7 ,
                                                 A1713ProdRef8 ,
                                                 A1714ProdRef9 ,
                                                 A1706ProdRef10 ,
                                                 A1724ProdVta ,
                                                 A1679ProdCmp ,
                                                 AV13OrderedBy ,
                                                 AV14OrderedDsc ,
                                                 A1718ProdSts } ,
                                                 new int[]{
                                                 TypeConstants.SHORT, TypeConstants.SHORT, TypeConstants.SHORT, TypeConstants.BOOLEAN, TypeConstants.SHORT
                                                 }
            });
            lV60FilterFullText = StringUtil.Concat( StringUtil.RTrim( AV60FilterFullText), "%", "");
            lV60FilterFullText = StringUtil.Concat( StringUtil.RTrim( AV60FilterFullText), "%", "");
            lV60FilterFullText = StringUtil.Concat( StringUtil.RTrim( AV60FilterFullText), "%", "");
            lV60FilterFullText = StringUtil.Concat( StringUtil.RTrim( AV60FilterFullText), "%", "");
            lV40TFProdCod = StringUtil.PadR( StringUtil.RTrim( AV40TFProdCod), 15, "%");
            lV42TFProdDsc = StringUtil.PadR( StringUtil.RTrim( AV42TFProdDsc), 100, "%");
            lV65TFUniAbr = StringUtil.PadR( StringUtil.RTrim( AV65TFUniAbr), 5, "%");
            lV67TFProdReferencias = StringUtil.Concat( StringUtil.RTrim( AV67TFProdReferencias), "%", "");
            /* Using cursor H002N2 */
            pr_default.execute(0, new Object[] {lV60FilterFullText, lV60FilterFullText, lV60FilterFullText, lV60FilterFullText, lV40TFProdCod, AV41TFProdCod_Sel, lV42TFProdDsc, AV43TFProdDsc_Sel, lV65TFUniAbr, AV66TFUniAbr_Sel, lV67TFProdReferencias, AV68TFProdReferencias_Sel, GXPagingFrom2, GXPagingTo2, GXPagingTo2});
            nGXsfl_27_idx = 1;
            sGXsfl_27_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_27_idx), 4, 0), 4, "0");
            SubsflControlProps_272( ) ;
            while ( ( (pr_default.getStatus(0) != 101) ) && ( ( ( subGrid_Rows == 0 ) || ( GRID_nCurrentRecord < subGrid_fnc_Recordsperpage( ) ) ) ) )
            {
               A1718ProdSts = H002N2_A1718ProdSts[0];
               A1679ProdCmp = H002N2_A1679ProdCmp[0];
               A1724ProdVta = H002N2_A1724ProdVta[0];
               A49UniCod = H002N2_A49UniCod[0];
               A1997UniAbr = H002N2_A1997UniAbr[0];
               A55ProdDsc = H002N2_A55ProdDsc[0];
               A28ProdCod = H002N2_A28ProdCod[0];
               A1706ProdRef10 = H002N2_A1706ProdRef10[0];
               A1714ProdRef9 = H002N2_A1714ProdRef9[0];
               A1713ProdRef8 = H002N2_A1713ProdRef8[0];
               A1712ProdRef7 = H002N2_A1712ProdRef7[0];
               A1711ProdRef6 = H002N2_A1711ProdRef6[0];
               A1710ProdRef5 = H002N2_A1710ProdRef5[0];
               A1709ProdRef4 = H002N2_A1709ProdRef4[0];
               A1708ProdRef3 = H002N2_A1708ProdRef3[0];
               A1707ProdRef2 = H002N2_A1707ProdRef2[0];
               A1705ProdRef1 = H002N2_A1705ProdRef1[0];
               A1997UniAbr = H002N2_A1997UniAbr[0];
               A1715ProdReferencias = StringUtil.Trim( A1705ProdRef1) + " " + StringUtil.Trim( A1707ProdRef2) + " " + StringUtil.Trim( A1708ProdRef3) + " " + StringUtil.Trim( A1709ProdRef4) + " " + StringUtil.Trim( A1710ProdRef5) + " " + StringUtil.Trim( A1711ProdRef6) + " " + StringUtil.Trim( A1712ProdRef7) + " " + StringUtil.Trim( A1713ProdRef8) + " " + StringUtil.Trim( A1714ProdRef9) + " " + StringUtil.Trim( A1706ProdRef10);
               E162N2 ();
               pr_default.readNext(0);
            }
            GRID_nEOF = (short)(((pr_default.getStatus(0) == 101) ? 1 : 0));
            GxWebStd.gx_hidden_field( context, "GRID_nEOF", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRID_nEOF), 1, 0, ".", "")));
            pr_default.close(0);
            wbEnd = 27;
            WB2N0( ) ;
         }
         bGXsfl_27_Refreshing = true;
      }

      protected void send_integrity_lvl_hashes2N2( )
      {
         GxWebStd.gx_hidden_field( context, "vPGMNAME", StringUtil.RTrim( AV71Pgmname));
         GxWebStd.gx_hidden_field( context, "gxhash_vPGMNAME", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( AV71Pgmname, "")), context));
         GxWebStd.gx_hidden_field( context, "gxhash_PRODCOD"+"_"+sGXsfl_27_idx, GetSecureSignedToken( sGXsfl_27_idx, StringUtil.RTrim( context.localUtil.Format( A28ProdCod, "@!")), context));
         GxWebStd.gx_hidden_field( context, "gxhash_PRODDSC"+"_"+sGXsfl_27_idx, GetSecureSignedToken( sGXsfl_27_idx, StringUtil.RTrim( context.localUtil.Format( A55ProdDsc, "")), context));
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
         pr_default.dynParam(1, new Object[]{ new Object[]{
                                              AV60FilterFullText ,
                                              AV41TFProdCod_Sel ,
                                              AV40TFProdCod ,
                                              AV43TFProdDsc_Sel ,
                                              AV42TFProdDsc ,
                                              AV66TFUniAbr_Sel ,
                                              AV65TFUniAbr ,
                                              AV68TFProdReferencias_Sel ,
                                              AV67TFProdReferencias ,
                                              AV64InTipo ,
                                              A28ProdCod ,
                                              A55ProdDsc ,
                                              A1997UniAbr ,
                                              A1705ProdRef1 ,
                                              A1707ProdRef2 ,
                                              A1708ProdRef3 ,
                                              A1709ProdRef4 ,
                                              A1710ProdRef5 ,
                                              A1711ProdRef6 ,
                                              A1712ProdRef7 ,
                                              A1713ProdRef8 ,
                                              A1714ProdRef9 ,
                                              A1706ProdRef10 ,
                                              A1724ProdVta ,
                                              A1679ProdCmp ,
                                              AV13OrderedBy ,
                                              AV14OrderedDsc ,
                                              A1718ProdSts } ,
                                              new int[]{
                                              TypeConstants.SHORT, TypeConstants.SHORT, TypeConstants.SHORT, TypeConstants.BOOLEAN, TypeConstants.SHORT
                                              }
         });
         lV60FilterFullText = StringUtil.Concat( StringUtil.RTrim( AV60FilterFullText), "%", "");
         lV60FilterFullText = StringUtil.Concat( StringUtil.RTrim( AV60FilterFullText), "%", "");
         lV60FilterFullText = StringUtil.Concat( StringUtil.RTrim( AV60FilterFullText), "%", "");
         lV60FilterFullText = StringUtil.Concat( StringUtil.RTrim( AV60FilterFullText), "%", "");
         lV40TFProdCod = StringUtil.PadR( StringUtil.RTrim( AV40TFProdCod), 15, "%");
         lV42TFProdDsc = StringUtil.PadR( StringUtil.RTrim( AV42TFProdDsc), 100, "%");
         lV65TFUniAbr = StringUtil.PadR( StringUtil.RTrim( AV65TFUniAbr), 5, "%");
         lV67TFProdReferencias = StringUtil.Concat( StringUtil.RTrim( AV67TFProdReferencias), "%", "");
         /* Using cursor H002N3 */
         pr_default.execute(1, new Object[] {lV60FilterFullText, lV60FilterFullText, lV60FilterFullText, lV60FilterFullText, lV40TFProdCod, AV41TFProdCod_Sel, lV42TFProdDsc, AV43TFProdDsc_Sel, lV65TFUniAbr, AV66TFUniAbr_Sel, lV67TFProdReferencias, AV68TFProdReferencias_Sel});
         GRID_nRecordCount = H002N3_AGRID_nRecordCount[0];
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
         GRID_nFirstRecordOnPage = 0;
         GxWebStd.gx_hidden_field( context, "GRID_nFirstRecordOnPage", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRID_nFirstRecordOnPage), 15, 0, ".", "")));
         if ( isFullAjaxMode( ) )
         {
            gxgrGrid_refresh( subGrid_Rows, AV60FilterFullText, AV64InTipo, AV71Pgmname, AV13OrderedBy, AV14OrderedDsc, AV40TFProdCod, AV41TFProdCod_Sel, AV42TFProdDsc, AV43TFProdDsc_Sel, AV65TFUniAbr, AV66TFUniAbr_Sel, AV67TFProdReferencias, AV68TFProdReferencias_Sel) ;
         }
         send_integrity_footer_hashes( ) ;
         return 0 ;
      }

      protected short subgrid_nextpage( )
      {
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
            gxgrGrid_refresh( subGrid_Rows, AV60FilterFullText, AV64InTipo, AV71Pgmname, AV13OrderedBy, AV14OrderedDsc, AV40TFProdCod, AV41TFProdCod_Sel, AV42TFProdDsc, AV43TFProdDsc_Sel, AV65TFUniAbr, AV66TFUniAbr_Sel, AV67TFProdReferencias, AV68TFProdReferencias_Sel) ;
         }
         send_integrity_footer_hashes( ) ;
         return (short)(((GRID_nEOF==0) ? 0 : 2)) ;
      }

      protected short subgrid_previouspage( )
      {
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
            gxgrGrid_refresh( subGrid_Rows, AV60FilterFullText, AV64InTipo, AV71Pgmname, AV13OrderedBy, AV14OrderedDsc, AV40TFProdCod, AV41TFProdCod_Sel, AV42TFProdDsc, AV43TFProdDsc_Sel, AV65TFUniAbr, AV66TFUniAbr_Sel, AV67TFProdReferencias, AV68TFProdReferencias_Sel) ;
         }
         send_integrity_footer_hashes( ) ;
         return 0 ;
      }

      protected short subgrid_lastpage( )
      {
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
            gxgrGrid_refresh( subGrid_Rows, AV60FilterFullText, AV64InTipo, AV71Pgmname, AV13OrderedBy, AV14OrderedDsc, AV40TFProdCod, AV41TFProdCod_Sel, AV42TFProdDsc, AV43TFProdDsc_Sel, AV65TFUniAbr, AV66TFUniAbr_Sel, AV67TFProdReferencias, AV68TFProdReferencias_Sel) ;
         }
         send_integrity_footer_hashes( ) ;
         return 0 ;
      }

      protected int subgrid_gotopage( int nPageNo )
      {
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
            gxgrGrid_refresh( subGrid_Rows, AV60FilterFullText, AV64InTipo, AV71Pgmname, AV13OrderedBy, AV14OrderedDsc, AV40TFProdCod, AV41TFProdCod_Sel, AV42TFProdDsc, AV43TFProdDsc_Sel, AV65TFUniAbr, AV66TFUniAbr_Sel, AV67TFProdReferencias, AV68TFProdReferencias_Sel) ;
         }
         send_integrity_footer_hashes( ) ;
         return (int)(0) ;
      }

      protected void before_start_formulas( )
      {
         AV71Pgmname = "Generales.WWBusquedaProducto";
         context.Gx_err = 0;
         edtavSelect_Enabled = 0;
         AssignProp("", false, edtavSelect_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavSelect_Enabled), 5, 0), !bGXsfl_27_Refreshing);
         fix_multi_value_controls( ) ;
      }

      protected void STRUP2N0( )
      {
         /* Before Start, stand alone formulas. */
         before_start_formulas( ) ;
         /* Execute Start event if defined. */
         context.wbGlbDoneStart = 0;
         /* Execute user event: Start */
         E142N2 ();
         context.wbGlbDoneStart = 1;
         /* After Start, stand alone formulas. */
         if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
         {
            /* Read saved SDTs. */
            ajax_req_read_hidden_sdt(cgiGet( "vDDO_TITLESETTINGSICONS"), AV52DDO_TitleSettingsIcons);
            /* Read saved values. */
            nRC_GXsfl_27 = (int)(context.localUtil.CToN( cgiGet( "nRC_GXsfl_27"), ".", ","));
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
            Ddo_grid_Datalistproc = cgiGet( "DDO_GRID_Datalistproc");
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
            /* Read variables values. */
            AV60FilterFullText = cgiGet( edtavFilterfulltext_Internalname);
            AssignAttri("", false, "AV60FilterFullText", AV60FilterFullText);
            /* Read subfile selected row values. */
            /* Read hidden variables. */
            GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
            /* Check if conditions changed and reset current page numbers */
            if ( StringUtil.StrCmp(cgiGet( "GXH_vFILTERFULLTEXT"), AV60FilterFullText) != 0 )
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
         E142N2 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
      }

      protected void E142N2( )
      {
         /* Start Routine */
         returnInSub = false;
         subGrid_Rows = 10;
         GxWebStd.gx_hidden_field( context, "GRID_Rows", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid_Rows), 6, 0, ".", "")));
         Grid_empowerer_Gridinternalname = subGrid_Internalname;
         ucGrid_empowerer.SendProperty(context, "", false, Grid_empowerer_Internalname, "GridInternalName", Grid_empowerer_Gridinternalname);
         Ddo_grid_Gridinternalname = subGrid_Internalname;
         ucDdo_grid.SendProperty(context, "", false, Ddo_grid_Internalname, "GridInternalName", Ddo_grid_Gridinternalname);
         Form.Caption = "Selecciona  Producto";
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

      protected void E152N2( )
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
         new GeneXus.Programs.wwpbaseobjects.wwp_getappliedfiltersdescription(context ).execute(  AV71Pgmname, out  GXt_char2) ;
         AV56GridAppliedFilters = GXt_char2;
         AssignAttri("", false, "AV56GridAppliedFilters", AV56GridAppliedFilters);
         /*  Sending Event outputs  */
      }

      protected void E112N2( )
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

      protected void E122N2( )
      {
         /* Gridpaginationbar_Changerowsperpage Routine */
         returnInSub = false;
         subGrid_Rows = Gridpaginationbar_Rowsperpageselectedvalue;
         GxWebStd.gx_hidden_field( context, "GRID_Rows", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid_Rows), 6, 0, ".", "")));
         subgrid_firstpage( ) ;
         /*  Sending Event outputs  */
      }

      protected void E132N2( )
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
            if ( StringUtil.StrCmp(Ddo_grid_Selectedcolumn, "ProdCod") == 0 )
            {
               AV40TFProdCod = Ddo_grid_Filteredtext_get;
               AssignAttri("", false, "AV40TFProdCod", AV40TFProdCod);
               AV41TFProdCod_Sel = Ddo_grid_Selectedvalue_get;
               AssignAttri("", false, "AV41TFProdCod_Sel", AV41TFProdCod_Sel);
            }
            else if ( StringUtil.StrCmp(Ddo_grid_Selectedcolumn, "ProdDsc") == 0 )
            {
               AV42TFProdDsc = Ddo_grid_Filteredtext_get;
               AssignAttri("", false, "AV42TFProdDsc", AV42TFProdDsc);
               AV43TFProdDsc_Sel = Ddo_grid_Selectedvalue_get;
               AssignAttri("", false, "AV43TFProdDsc_Sel", AV43TFProdDsc_Sel);
            }
            else if ( StringUtil.StrCmp(Ddo_grid_Selectedcolumn, "UniAbr") == 0 )
            {
               AV65TFUniAbr = Ddo_grid_Filteredtext_get;
               AssignAttri("", false, "AV65TFUniAbr", AV65TFUniAbr);
               AV66TFUniAbr_Sel = Ddo_grid_Selectedvalue_get;
               AssignAttri("", false, "AV66TFUniAbr_Sel", AV66TFUniAbr_Sel);
            }
            else if ( StringUtil.StrCmp(Ddo_grid_Selectedcolumn, "ProdReferencias") == 0 )
            {
               AV67TFProdReferencias = Ddo_grid_Filteredtext_get;
               AssignAttri("", false, "AV67TFProdReferencias", AV67TFProdReferencias);
               AV68TFProdReferencias_Sel = Ddo_grid_Selectedvalue_get;
               AssignAttri("", false, "AV68TFProdReferencias_Sel", AV68TFProdReferencias_Sel);
            }
            subgrid_firstpage( ) ;
         }
         /*  Sending Event outputs  */
      }

      private void E162N2( )
      {
         /* Grid_Load Routine */
         returnInSub = false;
         AV57Select = "<i class=\"fas fa-check\"></i>";
         AssignAttri("", false, edtavSelect_Internalname, AV57Select);
         GXKey = Crypto.GetSiteKey( );
         GXEncryptionTmp = "almacen.productos.aspx"+UrlEncode(StringUtil.RTrim("DSP")) + "," + UrlEncode(StringUtil.RTrim(A28ProdCod));
         edtProdDsc_Link = formatLink("almacen.productos.aspx") + "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey);
         /* Load Method */
         if ( wbStart != -1 )
         {
            wbStart = 27;
         }
         sendrow_272( ) ;
         GRID_nCurrentRecord = (long)(GRID_nCurrentRecord+1);
         if ( isFullAjaxMode( ) && ! bGXsfl_27_Refreshing )
         {
            DoAjaxLoad(27, GridRow);
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

      protected void S122( )
      {
         /* 'LOADGRIDSTATE' Routine */
         returnInSub = false;
         if ( StringUtil.StrCmp(AV39Session.Get(AV71Pgmname+"GridState"), "") == 0 )
         {
            AV10GridState.FromXml(new GeneXus.Programs.wwpbaseobjects.loadgridstate(context).executeUdp(  AV71Pgmname+"GridState"), null, "", "");
         }
         else
         {
            AV10GridState.FromXml(AV39Session.Get(AV71Pgmname+"GridState"), null, "", "");
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
         AV72GXV1 = 1;
         while ( AV72GXV1 <= AV10GridState.gxTpr_Filtervalues.Count )
         {
            AV11GridStateFilterValue = ((GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue)AV10GridState.gxTpr_Filtervalues.Item(AV72GXV1));
            if ( StringUtil.StrCmp(AV11GridStateFilterValue.gxTpr_Name, "FILTERFULLTEXT") == 0 )
            {
               AV60FilterFullText = AV11GridStateFilterValue.gxTpr_Value;
               AssignAttri("", false, "AV60FilterFullText", AV60FilterFullText);
            }
            else if ( StringUtil.StrCmp(AV11GridStateFilterValue.gxTpr_Name, "TFPRODCOD") == 0 )
            {
               AV40TFProdCod = AV11GridStateFilterValue.gxTpr_Value;
               AssignAttri("", false, "AV40TFProdCod", AV40TFProdCod);
            }
            else if ( StringUtil.StrCmp(AV11GridStateFilterValue.gxTpr_Name, "TFPRODCOD_SEL") == 0 )
            {
               AV41TFProdCod_Sel = AV11GridStateFilterValue.gxTpr_Value;
               AssignAttri("", false, "AV41TFProdCod_Sel", AV41TFProdCod_Sel);
            }
            else if ( StringUtil.StrCmp(AV11GridStateFilterValue.gxTpr_Name, "TFPRODDSC") == 0 )
            {
               AV42TFProdDsc = AV11GridStateFilterValue.gxTpr_Value;
               AssignAttri("", false, "AV42TFProdDsc", AV42TFProdDsc);
            }
            else if ( StringUtil.StrCmp(AV11GridStateFilterValue.gxTpr_Name, "TFPRODDSC_SEL") == 0 )
            {
               AV43TFProdDsc_Sel = AV11GridStateFilterValue.gxTpr_Value;
               AssignAttri("", false, "AV43TFProdDsc_Sel", AV43TFProdDsc_Sel);
            }
            else if ( StringUtil.StrCmp(AV11GridStateFilterValue.gxTpr_Name, "TFUNIABR") == 0 )
            {
               AV65TFUniAbr = AV11GridStateFilterValue.gxTpr_Value;
               AssignAttri("", false, "AV65TFUniAbr", AV65TFUniAbr);
            }
            else if ( StringUtil.StrCmp(AV11GridStateFilterValue.gxTpr_Name, "TFUNIABR_SEL") == 0 )
            {
               AV66TFUniAbr_Sel = AV11GridStateFilterValue.gxTpr_Value;
               AssignAttri("", false, "AV66TFUniAbr_Sel", AV66TFUniAbr_Sel);
            }
            else if ( StringUtil.StrCmp(AV11GridStateFilterValue.gxTpr_Name, "TFPRODREFERENCIAS") == 0 )
            {
               AV67TFProdReferencias = AV11GridStateFilterValue.gxTpr_Value;
               AssignAttri("", false, "AV67TFProdReferencias", AV67TFProdReferencias);
            }
            else if ( StringUtil.StrCmp(AV11GridStateFilterValue.gxTpr_Name, "TFPRODREFERENCIAS_SEL") == 0 )
            {
               AV68TFProdReferencias_Sel = AV11GridStateFilterValue.gxTpr_Value;
               AssignAttri("", false, "AV68TFProdReferencias_Sel", AV68TFProdReferencias_Sel);
            }
            AV72GXV1 = (int)(AV72GXV1+1);
         }
         GXt_char2 = "";
         new GeneXus.Programs.wwpbaseobjects.wwp_getfilterval(context ).execute(  String.IsNullOrEmpty(StringUtil.RTrim( AV41TFProdCod_Sel)),  AV41TFProdCod_Sel, out  GXt_char2) ;
         GXt_char3 = "";
         new GeneXus.Programs.wwpbaseobjects.wwp_getfilterval(context ).execute(  String.IsNullOrEmpty(StringUtil.RTrim( AV43TFProdDsc_Sel)),  AV43TFProdDsc_Sel, out  GXt_char3) ;
         GXt_char4 = "";
         new GeneXus.Programs.wwpbaseobjects.wwp_getfilterval(context ).execute(  String.IsNullOrEmpty(StringUtil.RTrim( AV66TFUniAbr_Sel)),  AV66TFUniAbr_Sel, out  GXt_char4) ;
         GXt_char5 = "";
         new GeneXus.Programs.wwpbaseobjects.wwp_getfilterval(context ).execute(  String.IsNullOrEmpty(StringUtil.RTrim( AV68TFProdReferencias_Sel)),  AV68TFProdReferencias_Sel, out  GXt_char5) ;
         Ddo_grid_Selectedvalue_set = GXt_char2+"|"+GXt_char3+"|"+GXt_char4+"|"+GXt_char5;
         ucDdo_grid.SendProperty(context, "", false, Ddo_grid_Internalname, "SelectedValue_set", Ddo_grid_Selectedvalue_set);
         GXt_char5 = "";
         new GeneXus.Programs.wwpbaseobjects.wwp_getfilterval(context ).execute(  String.IsNullOrEmpty(StringUtil.RTrim( AV40TFProdCod)),  AV40TFProdCod, out  GXt_char5) ;
         GXt_char4 = "";
         new GeneXus.Programs.wwpbaseobjects.wwp_getfilterval(context ).execute(  String.IsNullOrEmpty(StringUtil.RTrim( AV42TFProdDsc)),  AV42TFProdDsc, out  GXt_char4) ;
         GXt_char3 = "";
         new GeneXus.Programs.wwpbaseobjects.wwp_getfilterval(context ).execute(  String.IsNullOrEmpty(StringUtil.RTrim( AV65TFUniAbr)),  AV65TFUniAbr, out  GXt_char3) ;
         GXt_char2 = "";
         new GeneXus.Programs.wwpbaseobjects.wwp_getfilterval(context ).execute(  String.IsNullOrEmpty(StringUtil.RTrim( AV67TFProdReferencias)),  AV67TFProdReferencias, out  GXt_char2) ;
         Ddo_grid_Filteredtext_set = GXt_char5+"|"+GXt_char4+"|"+GXt_char3+"|"+GXt_char2;
         ucDdo_grid.SendProperty(context, "", false, Ddo_grid_Internalname, "FilteredText_set", Ddo_grid_Filteredtext_set);
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
         AV10GridState.FromXml(AV39Session.Get(AV71Pgmname+"GridState"), null, "", "");
         AV10GridState.gxTpr_Orderedby = AV13OrderedBy;
         AV10GridState.gxTpr_Ordereddsc = AV14OrderedDsc;
         AV10GridState.gxTpr_Filtervalues.Clear();
         new GeneXus.Programs.wwpbaseobjects.wwp_gridstateaddfiltervalue(context ).execute( ref  AV10GridState,  "FILTERFULLTEXT",  "",  !String.IsNullOrEmpty(StringUtil.RTrim( AV60FilterFullText)),  0,  AV60FilterFullText,  "") ;
         new GeneXus.Programs.wwpbaseobjects.wwp_gridstateaddfiltervalueandsel(context ).execute( ref  AV10GridState,  "TFPRODCOD",  "Codigo",  !String.IsNullOrEmpty(StringUtil.RTrim( AV40TFProdCod)),  0,  AV40TFProdCod,  "",  !String.IsNullOrEmpty(StringUtil.RTrim( AV41TFProdCod_Sel)),  AV41TFProdCod_Sel,  "") ;
         new GeneXus.Programs.wwpbaseobjects.wwp_gridstateaddfiltervalueandsel(context ).execute( ref  AV10GridState,  "TFPRODDSC",  "Producto / Servicio",  !String.IsNullOrEmpty(StringUtil.RTrim( AV42TFProdDsc)),  0,  AV42TFProdDsc,  "",  !String.IsNullOrEmpty(StringUtil.RTrim( AV43TFProdDsc_Sel)),  AV43TFProdDsc_Sel,  "") ;
         new GeneXus.Programs.wwpbaseobjects.wwp_gridstateaddfiltervalueandsel(context ).execute( ref  AV10GridState,  "TFUNIABR",  "U.Medida",  !String.IsNullOrEmpty(StringUtil.RTrim( AV65TFUniAbr)),  0,  AV65TFUniAbr,  "",  !String.IsNullOrEmpty(StringUtil.RTrim( AV66TFUniAbr_Sel)),  AV66TFUniAbr_Sel,  "") ;
         new GeneXus.Programs.wwpbaseobjects.wwp_gridstateaddfiltervalueandsel(context ).execute( ref  AV10GridState,  "TFPRODREFERENCIAS",  "Referencias",  !String.IsNullOrEmpty(StringUtil.RTrim( AV67TFProdReferencias)),  0,  AV67TFProdReferencias,  "",  !String.IsNullOrEmpty(StringUtil.RTrim( AV68TFProdReferencias_Sel)),  AV68TFProdReferencias_Sel,  "") ;
         AV10GridState.gxTpr_Pagesize = StringUtil.Str( (decimal)(subGrid_Rows), 10, 0);
         AV10GridState.gxTpr_Currentpage = (short)(subGrid_fnc_Currentpage( ));
         new GeneXus.Programs.wwpbaseobjects.savegridstate(context ).execute(  AV71Pgmname+"GridState",  AV10GridState.ToXml(false, true, "", "")) ;
      }

      protected void S112( )
      {
         /* 'PREPARETRANSACTION' Routine */
         returnInSub = false;
         AV8TrnContext = new GeneXus.Programs.wwpbaseobjects.SdtWWPTransactionContext(context);
         AV8TrnContext.gxTpr_Callerobject = AV71Pgmname;
         AV8TrnContext.gxTpr_Callerondelete = true;
         AV8TrnContext.gxTpr_Callerurl = AV7HTTPRequest.ScriptName+"?"+AV7HTTPRequest.QueryString;
         AV8TrnContext.gxTpr_Transactionname = "APRODUCTOS";
         AV39Session.Set("TrnContext", AV8TrnContext.ToXml(false, true, "", ""));
      }

      public void GXEnter( )
      {
         /* Execute user event: Enter */
         E172N2 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
      }

      protected void E172N2( )
      {
         /* Enter Routine */
         returnInSub = false;
         AV61OutProdCod = A28ProdCod;
         AssignAttri("", false, "AV61OutProdCod", AV61OutProdCod);
         AV62OutProdDsc = A55ProdDsc;
         AssignAttri("", false, "AV62OutProdDsc", AV62OutProdDsc);
         context.setWebReturnParms(new Object[] {(string)AV61OutProdCod,(string)AV62OutProdDsc});
         context.setWebReturnParmsMetadata(new Object[] {"AV61OutProdCod","AV62OutProdDsc"});
         context.wjLocDisableFrm = 1;
         context.nUserReturn = 1;
         returnInSub = true;
         if (true) return;
         /*  Sending Event outputs  */
      }

      protected void wb_table1_13_2N2( bool wbgen )
      {
         if ( wbgen )
         {
            /* Table start */
            sStyleString = "";
            GxWebStd.gx_table_start( context, tblTablefilters_Internalname, tblTablefilters_Internalname, "", "", 0, "", "", 1, 2, sStyleString, "", "", 0);
            context.WriteHtmlText( "<tr>") ;
            context.WriteHtmlText( "<td>") ;
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group gx-default-form-group", "left", "top", ""+" data-gx-for=\""+edtavFilterfulltext_Internalname+"\"", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 75, "%", 0, "px", "gx-form-item gx-attribute", "left", "top", "", "", "div");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 18,'',false,'" + sGXsfl_27_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavFilterfulltext_Internalname, AV60FilterFullText, StringUtil.RTrim( context.localUtil.Format( AV60FilterFullText, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,18);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "Buscar", edtavFilterfulltext_Jsonclick, 0, "AttributeRealWidth", "", "", "", "", 1, edtavFilterfulltext_Enabled, 0, "text", "", 80, "chr", 1, "row", 100, 0, 0, 0, 1, -1, -1, true, "WWPFullTextFilter", "left", true, "", "HLP_Generales\\WWBusquedaProducto.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "</tr>") ;
            /* End of table */
            context.WriteHtmlText( "</table>") ;
            wb_table1_13_2N2e( true) ;
         }
         else
         {
            wb_table1_13_2N2e( false) ;
         }
      }

      public override void setparameters( Object[] obj )
      {
         createObjects();
         initialize();
         AV61OutProdCod = (string)getParm(obj,0);
         AssignAttri("", false, "AV61OutProdCod", AV61OutProdCod);
         AV62OutProdDsc = (string)getParm(obj,1);
         AssignAttri("", false, "AV62OutProdDsc", AV62OutProdDsc);
         AV64InTipo = (string)getParm(obj,2);
         AssignAttri("", false, "AV64InTipo", AV64InTipo);
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
         PA2N2( ) ;
         WS2N2( ) ;
         WE2N2( ) ;
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
            context.AddJavascriptSource(StringUtil.RTrim( ((string)Form.Jscriptsrc.Item(idxLst))), "?202281810304679", true, true);
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
         context.AddJavascriptSource("generales/wwbusquedaproducto.js", "?202281810304679", false, true);
         context.AddJavascriptSource("DVelop/Bootstrap/Shared/DVelopBootstrap.js", "", false, true);
         context.AddJavascriptSource("DVelop/Shared/WorkWithPlusCommon.js", "", false, true);
         context.AddJavascriptSource("DVelop/Bootstrap/Panel/BootstrapPanelRender.js", "", false, true);
         context.AddJavascriptSource("DVelop/Bootstrap/Shared/DVelopBootstrap.js", "", false, true);
         context.AddJavascriptSource("DVelop/Shared/WorkWithPlusCommon.js", "", false, true);
         context.AddJavascriptSource("DVelop/DVPaginationBar/DVPaginationBarRender.js", "", false, true);
         context.AddJavascriptSource("DVelop/Bootstrap/Shared/DVelopBootstrap.js", "", false, true);
         context.AddJavascriptSource("DVelop/Shared/WorkWithPlusCommon.js", "", false, true);
         context.AddJavascriptSource("DVelop/Bootstrap/DropDownOptions/BootstrapDropDownOptionsRender.js", "", false, true);
         context.AddJavascriptSource("DVelop/Shared/WorkWithPlusCommon.js", "", false, true);
         context.AddJavascriptSource("DVelop/GridEmpowerer/GridEmpowererRender.js", "", false, true);
         /* End function include_jscripts */
      }

      protected void SubsflControlProps_272( )
      {
         edtavSelect_Internalname = "vSELECT_"+sGXsfl_27_idx;
         edtProdCod_Internalname = "PRODCOD_"+sGXsfl_27_idx;
         edtProdDsc_Internalname = "PRODDSC_"+sGXsfl_27_idx;
         edtUniAbr_Internalname = "UNIABR_"+sGXsfl_27_idx;
         edtProdReferencias_Internalname = "PRODREFERENCIAS_"+sGXsfl_27_idx;
         edtUniCod_Internalname = "UNICOD_"+sGXsfl_27_idx;
         chkProdVta_Internalname = "PRODVTA_"+sGXsfl_27_idx;
         chkProdCmp_Internalname = "PRODCMP_"+sGXsfl_27_idx;
         cmbProdSts_Internalname = "PRODSTS_"+sGXsfl_27_idx;
      }

      protected void SubsflControlProps_fel_272( )
      {
         edtavSelect_Internalname = "vSELECT_"+sGXsfl_27_fel_idx;
         edtProdCod_Internalname = "PRODCOD_"+sGXsfl_27_fel_idx;
         edtProdDsc_Internalname = "PRODDSC_"+sGXsfl_27_fel_idx;
         edtUniAbr_Internalname = "UNIABR_"+sGXsfl_27_fel_idx;
         edtProdReferencias_Internalname = "PRODREFERENCIAS_"+sGXsfl_27_fel_idx;
         edtUniCod_Internalname = "UNICOD_"+sGXsfl_27_fel_idx;
         chkProdVta_Internalname = "PRODVTA_"+sGXsfl_27_fel_idx;
         chkProdCmp_Internalname = "PRODCMP_"+sGXsfl_27_fel_idx;
         cmbProdSts_Internalname = "PRODSTS_"+sGXsfl_27_fel_idx;
      }

      protected void sendrow_272( )
      {
         SubsflControlProps_272( ) ;
         WB2N0( ) ;
         if ( ( subGrid_Rows * 1 == 0 ) || ( nGXsfl_27_idx <= subGrid_fnc_Recordsperpage( ) * 1 ) )
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
               if ( ((int)((nGXsfl_27_idx) % (2))) == 0 )
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
               context.WriteHtmlText( " gxrow=\""+sGXsfl_27_idx+"\">") ;
            }
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"left"+"\""+" style=\""+""+"\">") ;
            }
            /* Single line edit */
            TempTags = " " + ((edtavSelect_Enabled!=0)&&(edtavSelect_Visible!=0) ? " onfocus=\"gx.evt.onfocus(this, 28,'',false,'"+sGXsfl_27_idx+"',27)\"" : " ");
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtavSelect_Internalname,StringUtil.RTrim( AV57Select),(string)"",TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+((edtavSelect_Enabled!=0)&&(edtavSelect_Visible!=0) ? " onblur=\""+""+";gx.evt.onblur(this,28);\"" : " "),"'"+""+"'"+",false,"+"'"+"EENTER."+sGXsfl_27_idx+"'",(string)"",(string)"",(string)"Seleccionar",(string)"",(string)edtavSelect_Jsonclick,(short)5,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWIconActionColumn",(string)"",(short)-1,(int)edtavSelect_Enabled,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)20,(short)0,(short)1,(short)27,(short)1,(short)-1,(short)-1,(bool)true,(string)"",(string)"left",(bool)true,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"left"+"\""+" style=\""+""+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtProdCod_Internalname,StringUtil.RTrim( A28ProdCod),StringUtil.RTrim( context.localUtil.Format( A28ProdCod, "@!")),(string)"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtProdCod_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn hidden-xs",(string)"",(short)-1,(short)0,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)15,(short)0,(short)0,(short)27,(short)1,(short)-1,(short)-1,(bool)true,(string)"",(string)"left",(bool)true,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"left"+"\""+" style=\""+""+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtProdDsc_Internalname,StringUtil.RTrim( A55ProdDsc),(string)"",(string)"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)edtProdDsc_Link,(string)"",(string)"",(string)"",(string)edtProdDsc_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn",(string)"",(short)-1,(short)0,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)100,(short)0,(short)0,(short)27,(short)1,(short)-1,(short)-1,(bool)true,(string)"",(string)"left",(bool)true,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"left"+"\""+" style=\""+""+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtUniAbr_Internalname,StringUtil.RTrim( A1997UniAbr),(string)"",(string)"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtUniAbr_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn",(string)"",(short)-1,(short)0,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)5,(short)0,(short)0,(short)27,(short)1,(short)-1,(short)-1,(bool)true,(string)"",(string)"left",(bool)true,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"left"+"\""+" style=\""+""+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtProdReferencias_Internalname,(string)A1715ProdReferencias,(string)"",(string)"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtProdReferencias_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn",(string)"",(short)-1,(short)0,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)200,(short)0,(short)0,(short)27,(short)1,(short)-1,(short)-1,(bool)true,(string)"",(string)"left",(bool)true,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"right"+"\""+" style=\""+"display:none;"+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtUniCod_Internalname,StringUtil.LTrim( StringUtil.NToC( (decimal)(A49UniCod), 6, 0, ".", "")),StringUtil.LTrim( context.localUtil.Format( (decimal)(A49UniCod), "ZZZZZ9")),(string)" inputmode=\"numeric\" pattern=\"[0-9]*\""+"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtUniCod_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn hidden-xs",(string)"",(short)0,(short)0,(short)0,(string)"text",(string)"1",(short)0,(string)"px",(short)17,(string)"px",(short)6,(short)0,(short)0,(short)27,(short)1,(short)-1,(short)0,(bool)true,(string)"",(string)"right",(bool)false,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+""+"\""+" style=\""+"display:none;"+"\">") ;
            }
            /* Check box */
            ClassString = "Attribute";
            StyleString = "";
            GXCCtl = "PRODVTA_" + sGXsfl_27_idx;
            chkProdVta.Name = GXCCtl;
            chkProdVta.WebTags = "";
            chkProdVta.Caption = "";
            AssignProp("", false, chkProdVta_Internalname, "TitleCaption", chkProdVta.Caption, !bGXsfl_27_Refreshing);
            chkProdVta.CheckedValue = "0";
            A1724ProdVta = (short)(((StringUtil.StrCmp(StringUtil.LTrim( StringUtil.NToC( (decimal)(A1724ProdVta), 1, 0, ".", "")), "1")==0) ? 1 : 0));
            GridRow.AddColumnProperties("checkbox", 1, isAjaxCallMode( ), new Object[] {(string)chkProdVta_Internalname,StringUtil.Str( (decimal)(A1724ProdVta), 1, 0),(string)"",(string)"",(short)0,(short)0,(string)"1",(string)"",(string)StyleString,(string)ClassString,(string)"WWColumn hidden-xs",(string)"",(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+""+"\""+" style=\""+"display:none;"+"\">") ;
            }
            /* Check box */
            ClassString = "Attribute";
            StyleString = "";
            GXCCtl = "PRODCMP_" + sGXsfl_27_idx;
            chkProdCmp.Name = GXCCtl;
            chkProdCmp.WebTags = "";
            chkProdCmp.Caption = "";
            AssignProp("", false, chkProdCmp_Internalname, "TitleCaption", chkProdCmp.Caption, !bGXsfl_27_Refreshing);
            chkProdCmp.CheckedValue = "0";
            A1679ProdCmp = (short)(((StringUtil.StrCmp(StringUtil.LTrim( StringUtil.NToC( (decimal)(A1679ProdCmp), 1, 0, ".", "")), "1")==0) ? 1 : 0));
            GridRow.AddColumnProperties("checkbox", 1, isAjaxCallMode( ), new Object[] {(string)chkProdCmp_Internalname,StringUtil.Str( (decimal)(A1679ProdCmp), 1, 0),(string)"",(string)"",(short)0,(short)0,(string)"1",(string)"",(string)StyleString,(string)ClassString,(string)"WWColumn hidden-xs",(string)"",(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"right"+"\""+" style=\""+"display:none;"+"\">") ;
            }
            if ( ( cmbProdSts.ItemCount == 0 ) && isAjaxCallMode( ) )
            {
               GXCCtl = "PRODSTS_" + sGXsfl_27_idx;
               cmbProdSts.Name = GXCCtl;
               cmbProdSts.WebTags = "";
               cmbProdSts.addItem("1", "ACTIVO", 0);
               cmbProdSts.addItem("0", "INACTIVO", 0);
               if ( cmbProdSts.ItemCount > 0 )
               {
                  A1718ProdSts = (short)(NumberUtil.Val( cmbProdSts.getValidValue(StringUtil.Trim( StringUtil.Str( (decimal)(A1718ProdSts), 1, 0))), "."));
               }
            }
            /* ComboBox */
            GridRow.AddColumnProperties("combobox", 2, isAjaxCallMode( ), new Object[] {(GXCombobox)cmbProdSts,(string)cmbProdSts_Internalname,StringUtil.Trim( StringUtil.Str( (decimal)(A1718ProdSts), 1, 0)),(short)1,(string)cmbProdSts_Jsonclick,(short)0,(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"int",(string)"",(short)0,(short)0,(short)0,(short)0,(short)0,(string)"px",(short)0,(string)"px",(string)"",(string)"Attribute",(string)"WWColumn hidden-xs",(string)"",(string)"",(string)"",(bool)true,(short)1});
            cmbProdSts.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(A1718ProdSts), 1, 0));
            AssignProp("", false, cmbProdSts_Internalname, "Values", (string)(cmbProdSts.ToJavascriptSource()), !bGXsfl_27_Refreshing);
            send_integrity_lvl_hashes2N2( ) ;
            GridContainer.AddRow(GridRow);
            nGXsfl_27_idx = ((subGrid_Islastpage==1)&&(nGXsfl_27_idx+1>subGrid_fnc_Recordsperpage( )) ? 1 : nGXsfl_27_idx+1);
            sGXsfl_27_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_27_idx), 4, 0), 4, "0");
            SubsflControlProps_272( ) ;
         }
         /* End function sendrow_272 */
      }

      protected void init_web_controls( )
      {
         GXCCtl = "PRODVTA_" + sGXsfl_27_idx;
         chkProdVta.Name = GXCCtl;
         chkProdVta.WebTags = "";
         chkProdVta.Caption = "";
         AssignProp("", false, chkProdVta_Internalname, "TitleCaption", chkProdVta.Caption, !bGXsfl_27_Refreshing);
         chkProdVta.CheckedValue = "0";
         A1724ProdVta = (short)(((StringUtil.StrCmp(StringUtil.LTrim( StringUtil.NToC( (decimal)(A1724ProdVta), 1, 0, ".", "")), "1")==0) ? 1 : 0));
         GXCCtl = "PRODCMP_" + sGXsfl_27_idx;
         chkProdCmp.Name = GXCCtl;
         chkProdCmp.WebTags = "";
         chkProdCmp.Caption = "";
         AssignProp("", false, chkProdCmp_Internalname, "TitleCaption", chkProdCmp.Caption, !bGXsfl_27_Refreshing);
         chkProdCmp.CheckedValue = "0";
         A1679ProdCmp = (short)(((StringUtil.StrCmp(StringUtil.LTrim( StringUtil.NToC( (decimal)(A1679ProdCmp), 1, 0, ".", "")), "1")==0) ? 1 : 0));
         GXCCtl = "PRODSTS_" + sGXsfl_27_idx;
         cmbProdSts.Name = GXCCtl;
         cmbProdSts.WebTags = "";
         cmbProdSts.addItem("1", "ACTIVO", 0);
         cmbProdSts.addItem("0", "INACTIVO", 0);
         if ( cmbProdSts.ItemCount > 0 )
         {
            A1718ProdSts = (short)(NumberUtil.Val( cmbProdSts.getValidValue(StringUtil.Trim( StringUtil.Str( (decimal)(A1718ProdSts), 1, 0))), "."));
         }
         /* End function init_web_controls */
      }

      protected void init_default_properties( )
      {
         edtavFilterfulltext_Internalname = "vFILTERFULLTEXT";
         tblTablefilters_Internalname = "TABLEFILTERS";
         divTableheader_Internalname = "TABLEHEADER";
         Dvpanel_tableheader_Internalname = "DVPANEL_TABLEHEADER";
         edtavSelect_Internalname = "vSELECT";
         edtProdCod_Internalname = "PRODCOD";
         edtProdDsc_Internalname = "PRODDSC";
         edtUniAbr_Internalname = "UNIABR";
         edtProdReferencias_Internalname = "PRODREFERENCIAS";
         edtUniCod_Internalname = "UNICOD";
         chkProdVta_Internalname = "PRODVTA";
         chkProdCmp_Internalname = "PRODCMP";
         cmbProdSts_Internalname = "PRODSTS";
         Gridpaginationbar_Internalname = "GRIDPAGINATIONBAR";
         divGridtablewithpaginationbar_Internalname = "GRIDTABLEWITHPAGINATIONBAR";
         divTablemain_Internalname = "TABLEMAIN";
         Ddo_grid_Internalname = "DDO_GRID";
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
         cmbProdSts_Jsonclick = "";
         chkProdCmp.Caption = "";
         chkProdVta.Caption = "";
         edtUniCod_Jsonclick = "";
         edtProdReferencias_Jsonclick = "";
         edtUniAbr_Jsonclick = "";
         edtProdDsc_Jsonclick = "";
         edtProdCod_Jsonclick = "";
         edtavSelect_Jsonclick = "";
         edtavSelect_Visible = -1;
         edtavFilterfulltext_Jsonclick = "";
         edtavFilterfulltext_Enabled = 1;
         subGrid_Allowcollapsing = 0;
         subGrid_Allowselection = 0;
         edtProdDsc_Link = "";
         edtavSelect_Enabled = 1;
         subGrid_Sortable = 0;
         subGrid_Header = "";
         subGrid_Class = "GridWithPaginationBar WorkWith";
         subGrid_Backcolorstyle = 0;
         Grid_empowerer_Hastitlesettings = Convert.ToBoolean( -1);
         Ddo_grid_Datalistproc = "Generales.WWBusquedaProductoGetFilterData";
         Ddo_grid_Datalisttype = "Dynamic|Dynamic|Dynamic|Dynamic";
         Ddo_grid_Includedatalist = "T";
         Ddo_grid_Filtertype = "Character|Character|Character|Character";
         Ddo_grid_Includefilter = "T";
         Ddo_grid_Includesortasc = "T|T|T|";
         Ddo_grid_Columnssortvalues = "1|2|3|";
         Ddo_grid_Columnids = "1:ProdCod|2:ProdDsc|3:UniAbr|4:ProdReferencias";
         Ddo_grid_Gridinternalname = "";
         Gridpaginationbar_Rowsperpagecaption = "WWP_PagingRowsPerPage";
         Gridpaginationbar_Emptygridcaption = "WWP_PagingEmptyGridCaption";
         Gridpaginationbar_Caption = "P?gina <CURRENT_PAGE> de <TOTAL_PAGES>";
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
         Form.Caption = "Selecciona  Producto";
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
         setEventMetadata("REFRESH","{handler:'Refresh',iparms:[{av:'GRID_nFirstRecordOnPage'},{av:'GRID_nEOF'},{av:'AV64InTipo',fld:'vINTIPO',pic:''},{av:'subGrid_Rows',ctrl:'GRID',prop:'Rows'},{av:'AV60FilterFullText',fld:'vFILTERFULLTEXT',pic:''},{av:'AV71Pgmname',fld:'vPGMNAME',pic:'',hsh:true},{av:'AV13OrderedBy',fld:'vORDEREDBY',pic:'ZZZ9'},{av:'AV14OrderedDsc',fld:'vORDEREDDSC',pic:''},{av:'AV40TFProdCod',fld:'vTFPRODCOD',pic:'@!'},{av:'AV41TFProdCod_Sel',fld:'vTFPRODCOD_SEL',pic:'@!'},{av:'AV42TFProdDsc',fld:'vTFPRODDSC',pic:''},{av:'AV43TFProdDsc_Sel',fld:'vTFPRODDSC_SEL',pic:''},{av:'AV65TFUniAbr',fld:'vTFUNIABR',pic:''},{av:'AV66TFUniAbr_Sel',fld:'vTFUNIABR_SEL',pic:''},{av:'AV67TFProdReferencias',fld:'vTFPRODREFERENCIAS',pic:''},{av:'AV68TFProdReferencias_Sel',fld:'vTFPRODREFERENCIAS_SEL',pic:''}]");
         setEventMetadata("REFRESH",",oparms:[{av:'AV54GridCurrentPage',fld:'vGRIDCURRENTPAGE',pic:'ZZZZZZZZZ9'},{av:'AV55GridPageCount',fld:'vGRIDPAGECOUNT',pic:'ZZZZZZZZZ9'},{av:'AV56GridAppliedFilters',fld:'vGRIDAPPLIEDFILTERS',pic:''}]}");
         setEventMetadata("GRIDPAGINATIONBAR.CHANGEPAGE","{handler:'E112N2',iparms:[{av:'GRID_nFirstRecordOnPage'},{av:'GRID_nEOF'},{av:'subGrid_Rows',ctrl:'GRID',prop:'Rows'},{av:'AV60FilterFullText',fld:'vFILTERFULLTEXT',pic:''},{av:'AV64InTipo',fld:'vINTIPO',pic:''},{av:'AV71Pgmname',fld:'vPGMNAME',pic:'',hsh:true},{av:'AV13OrderedBy',fld:'vORDEREDBY',pic:'ZZZ9'},{av:'AV14OrderedDsc',fld:'vORDEREDDSC',pic:''},{av:'AV40TFProdCod',fld:'vTFPRODCOD',pic:'@!'},{av:'AV41TFProdCod_Sel',fld:'vTFPRODCOD_SEL',pic:'@!'},{av:'AV42TFProdDsc',fld:'vTFPRODDSC',pic:''},{av:'AV43TFProdDsc_Sel',fld:'vTFPRODDSC_SEL',pic:''},{av:'AV65TFUniAbr',fld:'vTFUNIABR',pic:''},{av:'AV66TFUniAbr_Sel',fld:'vTFUNIABR_SEL',pic:''},{av:'AV67TFProdReferencias',fld:'vTFPRODREFERENCIAS',pic:''},{av:'AV68TFProdReferencias_Sel',fld:'vTFPRODREFERENCIAS_SEL',pic:''},{av:'Gridpaginationbar_Selectedpage',ctrl:'GRIDPAGINATIONBAR',prop:'SelectedPage'}]");
         setEventMetadata("GRIDPAGINATIONBAR.CHANGEPAGE",",oparms:[]}");
         setEventMetadata("GRIDPAGINATIONBAR.CHANGEROWSPERPAGE","{handler:'E122N2',iparms:[{av:'GRID_nFirstRecordOnPage'},{av:'GRID_nEOF'},{av:'subGrid_Rows',ctrl:'GRID',prop:'Rows'},{av:'AV60FilterFullText',fld:'vFILTERFULLTEXT',pic:''},{av:'AV64InTipo',fld:'vINTIPO',pic:''},{av:'AV71Pgmname',fld:'vPGMNAME',pic:'',hsh:true},{av:'AV13OrderedBy',fld:'vORDEREDBY',pic:'ZZZ9'},{av:'AV14OrderedDsc',fld:'vORDEREDDSC',pic:''},{av:'AV40TFProdCod',fld:'vTFPRODCOD',pic:'@!'},{av:'AV41TFProdCod_Sel',fld:'vTFPRODCOD_SEL',pic:'@!'},{av:'AV42TFProdDsc',fld:'vTFPRODDSC',pic:''},{av:'AV43TFProdDsc_Sel',fld:'vTFPRODDSC_SEL',pic:''},{av:'AV65TFUniAbr',fld:'vTFUNIABR',pic:''},{av:'AV66TFUniAbr_Sel',fld:'vTFUNIABR_SEL',pic:''},{av:'AV67TFProdReferencias',fld:'vTFPRODREFERENCIAS',pic:''},{av:'AV68TFProdReferencias_Sel',fld:'vTFPRODREFERENCIAS_SEL',pic:''},{av:'Gridpaginationbar_Rowsperpageselectedvalue',ctrl:'GRIDPAGINATIONBAR',prop:'RowsPerPageSelectedValue'}]");
         setEventMetadata("GRIDPAGINATIONBAR.CHANGEROWSPERPAGE",",oparms:[{av:'subGrid_Rows',ctrl:'GRID',prop:'Rows'}]}");
         setEventMetadata("DDO_GRID.ONOPTIONCLICKED","{handler:'E132N2',iparms:[{av:'GRID_nFirstRecordOnPage'},{av:'GRID_nEOF'},{av:'subGrid_Rows',ctrl:'GRID',prop:'Rows'},{av:'AV60FilterFullText',fld:'vFILTERFULLTEXT',pic:''},{av:'AV64InTipo',fld:'vINTIPO',pic:''},{av:'AV71Pgmname',fld:'vPGMNAME',pic:'',hsh:true},{av:'AV13OrderedBy',fld:'vORDEREDBY',pic:'ZZZ9'},{av:'AV14OrderedDsc',fld:'vORDEREDDSC',pic:''},{av:'AV40TFProdCod',fld:'vTFPRODCOD',pic:'@!'},{av:'AV41TFProdCod_Sel',fld:'vTFPRODCOD_SEL',pic:'@!'},{av:'AV42TFProdDsc',fld:'vTFPRODDSC',pic:''},{av:'AV43TFProdDsc_Sel',fld:'vTFPRODDSC_SEL',pic:''},{av:'AV65TFUniAbr',fld:'vTFUNIABR',pic:''},{av:'AV66TFUniAbr_Sel',fld:'vTFUNIABR_SEL',pic:''},{av:'AV67TFProdReferencias',fld:'vTFPRODREFERENCIAS',pic:''},{av:'AV68TFProdReferencias_Sel',fld:'vTFPRODREFERENCIAS_SEL',pic:''},{av:'Ddo_grid_Activeeventkey',ctrl:'DDO_GRID',prop:'ActiveEventKey'},{av:'Ddo_grid_Selectedvalue_get',ctrl:'DDO_GRID',prop:'SelectedValue_get'},{av:'Ddo_grid_Selectedcolumn',ctrl:'DDO_GRID',prop:'SelectedColumn'},{av:'Ddo_grid_Filteredtext_get',ctrl:'DDO_GRID',prop:'FilteredText_get'}]");
         setEventMetadata("DDO_GRID.ONOPTIONCLICKED",",oparms:[{av:'AV13OrderedBy',fld:'vORDEREDBY',pic:'ZZZ9'},{av:'AV14OrderedDsc',fld:'vORDEREDDSC',pic:''},{av:'AV40TFProdCod',fld:'vTFPRODCOD',pic:'@!'},{av:'AV41TFProdCod_Sel',fld:'vTFPRODCOD_SEL',pic:'@!'},{av:'AV42TFProdDsc',fld:'vTFPRODDSC',pic:''},{av:'AV43TFProdDsc_Sel',fld:'vTFPRODDSC_SEL',pic:''},{av:'AV65TFUniAbr',fld:'vTFUNIABR',pic:''},{av:'AV66TFUniAbr_Sel',fld:'vTFUNIABR_SEL',pic:''},{av:'AV67TFProdReferencias',fld:'vTFPRODREFERENCIAS',pic:''},{av:'AV68TFProdReferencias_Sel',fld:'vTFPRODREFERENCIAS_SEL',pic:''},{av:'Ddo_grid_Sortedstatus',ctrl:'DDO_GRID',prop:'SortedStatus'}]}");
         setEventMetadata("GRID.LOAD","{handler:'E162N2',iparms:[{av:'A28ProdCod',fld:'PRODCOD',pic:'@!',hsh:true}]");
         setEventMetadata("GRID.LOAD",",oparms:[{av:'AV57Select',fld:'vSELECT',pic:''},{av:'edtProdDsc_Link',ctrl:'PRODDSC',prop:'Link'}]}");
         setEventMetadata("ENTER","{handler:'E172N2',iparms:[{av:'A28ProdCod',fld:'PRODCOD',pic:'@!',hsh:true},{av:'A55ProdDsc',fld:'PRODDSC',pic:'',hsh:true}]");
         setEventMetadata("ENTER",",oparms:[{av:'AV61OutProdCod',fld:'vOUTPRODCOD',pic:'@!'},{av:'AV62OutProdDsc',fld:'vOUTPRODDSC',pic:''}]}");
         setEventMetadata("VALID_UNICOD","{handler:'Valid_Unicod',iparms:[]");
         setEventMetadata("VALID_UNICOD",",oparms:[]}");
         setEventMetadata("NULL","{handler:'Valid_Prodsts',iparms:[]");
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
         AV61OutProdCod = "";
         AV62OutProdDsc = "";
         wcpOAV64InTipo = "";
         Gridpaginationbar_Selectedpage = "";
         Ddo_grid_Activeeventkey = "";
         Ddo_grid_Selectedvalue_get = "";
         Ddo_grid_Selectedcolumn = "";
         Ddo_grid_Filteredtext_get = "";
         gxfirstwebparm = "";
         gxfirstwebparm_bkp = "";
         AV60FilterFullText = "";
         AV71Pgmname = "";
         AV40TFProdCod = "";
         AV41TFProdCod_Sel = "";
         AV42TFProdDsc = "";
         AV43TFProdDsc_Sel = "";
         AV65TFUniAbr = "";
         AV66TFUniAbr_Sel = "";
         AV67TFProdReferencias = "";
         AV68TFProdReferencias_Sel = "";
         sDynURL = "";
         FormProcess = "";
         bodyStyle = "";
         GXKey = "";
         AV56GridAppliedFilters = "";
         AV52DDO_TitleSettingsIcons = new GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTDropDownOptionsTitleSettingsIcons(context);
         A1705ProdRef1 = "";
         A1707ProdRef2 = "";
         A1708ProdRef3 = "";
         A1709ProdRef4 = "";
         A1710ProdRef5 = "";
         A1711ProdRef6 = "";
         A1712ProdRef7 = "";
         A1713ProdRef8 = "";
         A1714ProdRef9 = "";
         A1706ProdRef10 = "";
         Ddo_grid_Caption = "";
         Ddo_grid_Filteredtext_set = "";
         Ddo_grid_Selectedvalue_set = "";
         Ddo_grid_Sortedstatus = "";
         Grid_empowerer_Gridinternalname = "";
         GX_FocusControl = "";
         Form = new GXWebForm();
         sPrefix = "";
         ucDvpanel_tableheader = new GXUserControl();
         ClassString = "";
         StyleString = "";
         GridContainer = new GXWebGrid( context);
         sStyleString = "";
         subGrid_Linesclass = "";
         GridColumn = new GXWebColumn();
         AV57Select = "";
         A28ProdCod = "";
         A55ProdDsc = "";
         A1997UniAbr = "";
         A1715ProdReferencias = "";
         ucGridpaginationbar = new GXUserControl();
         ucDdo_grid = new GXUserControl();
         ucGrid_empowerer = new GXUserControl();
         sEvt = "";
         EvtGridId = "";
         EvtRowId = "";
         sEvtType = "";
         scmdbuf = "";
         lV60FilterFullText = "";
         lV40TFProdCod = "";
         lV42TFProdDsc = "";
         lV65TFUniAbr = "";
         lV67TFProdReferencias = "";
         H002N2_A1718ProdSts = new short[1] ;
         H002N2_A1679ProdCmp = new short[1] ;
         H002N2_A1724ProdVta = new short[1] ;
         H002N2_A49UniCod = new int[1] ;
         H002N2_A1997UniAbr = new string[] {""} ;
         H002N2_A55ProdDsc = new string[] {""} ;
         H002N2_A28ProdCod = new string[] {""} ;
         H002N2_A1706ProdRef10 = new string[] {""} ;
         H002N2_A1714ProdRef9 = new string[] {""} ;
         H002N2_A1713ProdRef8 = new string[] {""} ;
         H002N2_A1712ProdRef7 = new string[] {""} ;
         H002N2_A1711ProdRef6 = new string[] {""} ;
         H002N2_A1710ProdRef5 = new string[] {""} ;
         H002N2_A1709ProdRef4 = new string[] {""} ;
         H002N2_A1708ProdRef3 = new string[] {""} ;
         H002N2_A1707ProdRef2 = new string[] {""} ;
         H002N2_A1705ProdRef1 = new string[] {""} ;
         H002N3_AGRID_nRecordCount = new long[1] ;
         GXt_SdtDVB_SDTDropDownOptionsTitleSettingsIcons1 = new GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTDropDownOptionsTitleSettingsIcons(context);
         AV6WWPContext = new GeneXus.Programs.wwpbaseobjects.SdtWWPContext(context);
         GXEncryptionTmp = "";
         GridRow = new GXWebRow();
         AV39Session = context.GetSession();
         AV10GridState = new GeneXus.Programs.wwpbaseobjects.SdtWWPGridState(context);
         AV11GridStateFilterValue = new GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue(context);
         GXt_char5 = "";
         GXt_char4 = "";
         GXt_char3 = "";
         GXt_char2 = "";
         AV8TrnContext = new GeneXus.Programs.wwpbaseobjects.SdtWWPTransactionContext(context);
         AV7HTTPRequest = new GxHttpRequest( context);
         TempTags = "";
         BackMsgLst = new msglist();
         LclMsgLst = new msglist();
         ROClassString = "";
         GXCCtl = "";
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.generales.wwbusquedaproducto__default(),
            new Object[][] {
                new Object[] {
               H002N2_A1718ProdSts, H002N2_A1679ProdCmp, H002N2_A1724ProdVta, H002N2_A49UniCod, H002N2_A1997UniAbr, H002N2_A55ProdDsc, H002N2_A28ProdCod, H002N2_A1706ProdRef10, H002N2_A1714ProdRef9, H002N2_A1713ProdRef8,
               H002N2_A1712ProdRef7, H002N2_A1711ProdRef6, H002N2_A1710ProdRef5, H002N2_A1709ProdRef4, H002N2_A1708ProdRef3, H002N2_A1707ProdRef2, H002N2_A1705ProdRef1
               }
               , new Object[] {
               H002N3_AGRID_nRecordCount
               }
            }
         );
         AV71Pgmname = "Generales.WWBusquedaProducto";
         /* GeneXus formulas. */
         AV71Pgmname = "Generales.WWBusquedaProducto";
         context.Gx_err = 0;
         edtavSelect_Enabled = 0;
      }

      private short GRID_nEOF ;
      private short nGotPars ;
      private short GxWebError ;
      private short AV13OrderedBy ;
      private short initialized ;
      private short gxajaxcallmode ;
      private short wbEnd ;
      private short wbStart ;
      private short subGrid_Backcolorstyle ;
      private short subGrid_Titlebackstyle ;
      private short subGrid_Sortable ;
      private short A1724ProdVta ;
      private short A1679ProdCmp ;
      private short A1718ProdSts ;
      private short subGrid_Allowselection ;
      private short subGrid_Allowhovering ;
      private short subGrid_Allowcollapsing ;
      private short subGrid_Collapsed ;
      private short nDonePA ;
      private short gxcookieaux ;
      private short nGXWrapped ;
      private short subGrid_Backstyle ;
      private int subGrid_Rows ;
      private int Gridpaginationbar_Rowsperpageselectedvalue ;
      private int nRC_GXsfl_27 ;
      private int nGXsfl_27_idx=1 ;
      private int Gridpaginationbar_Pagestoshow ;
      private int subGrid_Titlebackcolor ;
      private int subGrid_Allbackcolor ;
      private int edtavSelect_Enabled ;
      private int A49UniCod ;
      private int subGrid_Selectedindex ;
      private int subGrid_Selectioncolor ;
      private int subGrid_Hoveringcolor ;
      private int subGrid_Islastpage ;
      private int GXPagingFrom2 ;
      private int GXPagingTo2 ;
      private int AV53PageToGo ;
      private int AV72GXV1 ;
      private int edtavFilterfulltext_Enabled ;
      private int idxLst ;
      private int subGrid_Backcolor ;
      private int edtavSelect_Visible ;
      private long GRID_nFirstRecordOnPage ;
      private long AV54GridCurrentPage ;
      private long AV55GridPageCount ;
      private long GRID_nCurrentRecord ;
      private long GRID_nRecordCount ;
      private string AV61OutProdCod ;
      private string AV62OutProdDsc ;
      private string Gridpaginationbar_Selectedpage ;
      private string Ddo_grid_Activeeventkey ;
      private string Ddo_grid_Selectedvalue_get ;
      private string Ddo_grid_Selectedcolumn ;
      private string Ddo_grid_Filteredtext_get ;
      private string gxfirstwebparm ;
      private string gxfirstwebparm_bkp ;
      private string sGXsfl_27_idx="0001" ;
      private string AV71Pgmname ;
      private string AV40TFProdCod ;
      private string AV41TFProdCod_Sel ;
      private string AV42TFProdDsc ;
      private string AV43TFProdDsc_Sel ;
      private string AV65TFUniAbr ;
      private string AV66TFUniAbr_Sel ;
      private string sDynURL ;
      private string FormProcess ;
      private string bodyStyle ;
      private string GXKey ;
      private string A1705ProdRef1 ;
      private string A1707ProdRef2 ;
      private string A1708ProdRef3 ;
      private string A1709ProdRef4 ;
      private string A1710ProdRef5 ;
      private string A1711ProdRef6 ;
      private string A1712ProdRef7 ;
      private string A1713ProdRef8 ;
      private string A1714ProdRef9 ;
      private string A1706ProdRef10 ;
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
      private string Ddo_grid_Datalistproc ;
      private string Grid_empowerer_Gridinternalname ;
      private string GX_FocusControl ;
      private string sPrefix ;
      private string divLayoutmaintable_Internalname ;
      private string divTablemain_Internalname ;
      private string Dvpanel_tableheader_Internalname ;
      private string divTableheader_Internalname ;
      private string ClassString ;
      private string StyleString ;
      private string divGridtablewithpaginationbar_Internalname ;
      private string sStyleString ;
      private string subGrid_Internalname ;
      private string subGrid_Class ;
      private string subGrid_Linesclass ;
      private string subGrid_Header ;
      private string AV57Select ;
      private string A28ProdCod ;
      private string A55ProdDsc ;
      private string edtProdDsc_Link ;
      private string A1997UniAbr ;
      private string Gridpaginationbar_Internalname ;
      private string divHtml_bottomauxiliarcontrols_Internalname ;
      private string Ddo_grid_Internalname ;
      private string Grid_empowerer_Internalname ;
      private string sEvt ;
      private string EvtGridId ;
      private string EvtRowId ;
      private string sEvtType ;
      private string edtavSelect_Internalname ;
      private string edtProdCod_Internalname ;
      private string edtProdDsc_Internalname ;
      private string edtUniAbr_Internalname ;
      private string edtProdReferencias_Internalname ;
      private string edtUniCod_Internalname ;
      private string chkProdVta_Internalname ;
      private string chkProdCmp_Internalname ;
      private string cmbProdSts_Internalname ;
      private string edtavFilterfulltext_Internalname ;
      private string scmdbuf ;
      private string lV40TFProdCod ;
      private string lV42TFProdDsc ;
      private string lV65TFUniAbr ;
      private string GXEncryptionTmp ;
      private string GXt_char5 ;
      private string GXt_char4 ;
      private string GXt_char3 ;
      private string GXt_char2 ;
      private string tblTablefilters_Internalname ;
      private string TempTags ;
      private string edtavFilterfulltext_Jsonclick ;
      private string sGXsfl_27_fel_idx="0001" ;
      private string ROClassString ;
      private string edtavSelect_Jsonclick ;
      private string edtProdCod_Jsonclick ;
      private string edtProdDsc_Jsonclick ;
      private string edtUniAbr_Jsonclick ;
      private string edtProdReferencias_Jsonclick ;
      private string edtUniCod_Jsonclick ;
      private string GXCCtl ;
      private string cmbProdSts_Jsonclick ;
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
      private bool bGXsfl_27_Refreshing=false ;
      private bool gxdyncontrolsrefreshing ;
      private bool returnInSub ;
      private bool gx_refresh_fired ;
      private string AV64InTipo ;
      private string wcpOAV64InTipo ;
      private string AV60FilterFullText ;
      private string AV67TFProdReferencias ;
      private string AV68TFProdReferencias_Sel ;
      private string AV56GridAppliedFilters ;
      private string A1715ProdReferencias ;
      private string lV60FilterFullText ;
      private string lV67TFProdReferencias ;
      private IGxSession AV39Session ;
      private GXWebGrid GridContainer ;
      private GXWebRow GridRow ;
      private GXWebColumn GridColumn ;
      private GXUserControl ucDvpanel_tableheader ;
      private GXUserControl ucGridpaginationbar ;
      private GXUserControl ucDdo_grid ;
      private GXUserControl ucGrid_empowerer ;
      private IGxDataStore dsDataStore2 ;
      private IGxDataStore dsDefault ;
      private GXCheckbox chkProdVta ;
      private GXCheckbox chkProdCmp ;
      private GXCombobox cmbProdSts ;
      private IDataStoreProvider pr_default ;
      private short[] H002N2_A1718ProdSts ;
      private short[] H002N2_A1679ProdCmp ;
      private short[] H002N2_A1724ProdVta ;
      private int[] H002N2_A49UniCod ;
      private string[] H002N2_A1997UniAbr ;
      private string[] H002N2_A55ProdDsc ;
      private string[] H002N2_A28ProdCod ;
      private string[] H002N2_A1706ProdRef10 ;
      private string[] H002N2_A1714ProdRef9 ;
      private string[] H002N2_A1713ProdRef8 ;
      private string[] H002N2_A1712ProdRef7 ;
      private string[] H002N2_A1711ProdRef6 ;
      private string[] H002N2_A1710ProdRef5 ;
      private string[] H002N2_A1709ProdRef4 ;
      private string[] H002N2_A1708ProdRef3 ;
      private string[] H002N2_A1707ProdRef2 ;
      private string[] H002N2_A1705ProdRef1 ;
      private long[] H002N3_AGRID_nRecordCount ;
      private msglist BackMsgLst ;
      private msglist LclMsgLst ;
      private string aP0_OutProdCod ;
      private string aP1_OutProdDsc ;
      private GxHttpRequest AV7HTTPRequest ;
      private GXWebForm Form ;
      private GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTDropDownOptionsTitleSettingsIcons AV52DDO_TitleSettingsIcons ;
      private GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTDropDownOptionsTitleSettingsIcons GXt_SdtDVB_SDTDropDownOptionsTitleSettingsIcons1 ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPGridState AV10GridState ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue AV11GridStateFilterValue ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPTransactionContext AV8TrnContext ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPContext AV6WWPContext ;
   }

   public class wwbusquedaproducto__default : DataStoreHelperBase, IDataStoreHelper
   {
      protected Object[] conditional_H002N2( IGxContext context ,
                                             string AV60FilterFullText ,
                                             string AV41TFProdCod_Sel ,
                                             string AV40TFProdCod ,
                                             string AV43TFProdDsc_Sel ,
                                             string AV42TFProdDsc ,
                                             string AV66TFUniAbr_Sel ,
                                             string AV65TFUniAbr ,
                                             string AV68TFProdReferencias_Sel ,
                                             string AV67TFProdReferencias ,
                                             string AV64InTipo ,
                                             string A28ProdCod ,
                                             string A55ProdDsc ,
                                             string A1997UniAbr ,
                                             string A1705ProdRef1 ,
                                             string A1707ProdRef2 ,
                                             string A1708ProdRef3 ,
                                             string A1709ProdRef4 ,
                                             string A1710ProdRef5 ,
                                             string A1711ProdRef6 ,
                                             string A1712ProdRef7 ,
                                             string A1713ProdRef8 ,
                                             string A1714ProdRef9 ,
                                             string A1706ProdRef10 ,
                                             short A1724ProdVta ,
                                             short A1679ProdCmp ,
                                             short AV13OrderedBy ,
                                             bool AV14OrderedDsc ,
                                             short A1718ProdSts )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int6 = new short[15];
         Object[] GXv_Object7 = new Object[2];
         string sSelectString;
         string sFromString;
         string sOrderString;
         sSelectString = " T1.[ProdSts], T1.[ProdCmp], T1.[ProdVta], T1.[UniCod], T2.[UniAbr], T1.[ProdDsc], T1.[ProdCod], T1.[ProdRef10], T1.[ProdRef9], T1.[ProdRef8], T1.[ProdRef7], T1.[ProdRef6], T1.[ProdRef5], T1.[ProdRef4], T1.[ProdRef3], T1.[ProdRef2], T1.[ProdRef1]";
         sFromString = " FROM ([APRODUCTOS] T1 INNER JOIN [CUNIDADMEDIDA] T2 ON T2.[UniCod] = T1.[UniCod])";
         sOrderString = "";
         AddWhere(sWhereString, "(T1.[ProdSts] = 1)");
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV60FilterFullText)) )
         {
            AddWhere(sWhereString, "(( T1.[ProdCod] like '%' + @lV60FilterFullText) or ( T1.[ProdDsc] like '%' + @lV60FilterFullText) or ( T2.[UniAbr] like '%' + @lV60FilterFullText) or ( RTRIM(LTRIM(T1.[ProdRef1])) + ' ' + RTRIM(LTRIM(T1.[ProdRef2])) + ' ' + RTRIM(LTRIM(T1.[ProdRef3])) + ' ' + RTRIM(LTRIM(T1.[ProdRef4])) + ' ' + RTRIM(LTRIM(T1.[ProdRef5])) + ' ' + RTRIM(LTRIM(T1.[ProdRef6])) + ' ' + RTRIM(LTRIM(T1.[ProdRef7])) + ' ' + RTRIM(LTRIM(T1.[ProdRef8])) + ' ' + RTRIM(LTRIM(T1.[ProdRef9])) + ' ' + RTRIM(LTRIM(T1.[ProdRef10])) like '%' + @lV60FilterFullText))");
         }
         else
         {
            GXv_int6[0] = 1;
            GXv_int6[1] = 1;
            GXv_int6[2] = 1;
            GXv_int6[3] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV41TFProdCod_Sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV40TFProdCod)) ) )
         {
            AddWhere(sWhereString, "(T1.[ProdCod] like @lV40TFProdCod)");
         }
         else
         {
            GXv_int6[4] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV41TFProdCod_Sel)) )
         {
            AddWhere(sWhereString, "(T1.[ProdCod] = @AV41TFProdCod_Sel)");
         }
         else
         {
            GXv_int6[5] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV43TFProdDsc_Sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV42TFProdDsc)) ) )
         {
            AddWhere(sWhereString, "(T1.[ProdDsc] like @lV42TFProdDsc)");
         }
         else
         {
            GXv_int6[6] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV43TFProdDsc_Sel)) )
         {
            AddWhere(sWhereString, "(T1.[ProdDsc] = @AV43TFProdDsc_Sel)");
         }
         else
         {
            GXv_int6[7] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV66TFUniAbr_Sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV65TFUniAbr)) ) )
         {
            AddWhere(sWhereString, "(T2.[UniAbr] like @lV65TFUniAbr)");
         }
         else
         {
            GXv_int6[8] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV66TFUniAbr_Sel)) )
         {
            AddWhere(sWhereString, "(T2.[UniAbr] = @AV66TFUniAbr_Sel)");
         }
         else
         {
            GXv_int6[9] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV68TFProdReferencias_Sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV67TFProdReferencias)) ) )
         {
            AddWhere(sWhereString, "(RTRIM(LTRIM(T1.[ProdRef1])) + ' ' + RTRIM(LTRIM(T1.[ProdRef2])) + ' ' + RTRIM(LTRIM(T1.[ProdRef3])) + ' ' + RTRIM(LTRIM(T1.[ProdRef4])) + ' ' + RTRIM(LTRIM(T1.[ProdRef5])) + ' ' + RTRIM(LTRIM(T1.[ProdRef6])) + ' ' + RTRIM(LTRIM(T1.[ProdRef7])) + ' ' + RTRIM(LTRIM(T1.[ProdRef8])) + ' ' + RTRIM(LTRIM(T1.[ProdRef9])) + ' ' + RTRIM(LTRIM(T1.[ProdRef10])) like @lV67TFProdReferencias)");
         }
         else
         {
            GXv_int6[10] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV68TFProdReferencias_Sel)) )
         {
            AddWhere(sWhereString, "(RTRIM(LTRIM(T1.[ProdRef1])) + ' ' + RTRIM(LTRIM(T1.[ProdRef2])) + ' ' + RTRIM(LTRIM(T1.[ProdRef3])) + ' ' + RTRIM(LTRIM(T1.[ProdRef4])) + ' ' + RTRIM(LTRIM(T1.[ProdRef5])) + ' ' + RTRIM(LTRIM(T1.[ProdRef6])) + ' ' + RTRIM(LTRIM(T1.[ProdRef7])) + ' ' + RTRIM(LTRIM(T1.[ProdRef8])) + ' ' + RTRIM(LTRIM(T1.[ProdRef9])) + ' ' + RTRIM(LTRIM(T1.[ProdRef10])) = @AV68TFProdReferencias_Sel)");
         }
         else
         {
            GXv_int6[11] = 1;
         }
         if ( StringUtil.StrCmp(AV64InTipo, "V") == 0 )
         {
            AddWhere(sWhereString, "(T1.[ProdVta] = 1)");
         }
         if ( StringUtil.StrCmp(AV64InTipo, "C") == 0 )
         {
            AddWhere(sWhereString, "(T1.[ProdCmp] = 1)");
         }
         if ( ( AV13OrderedBy == 1 ) && ! AV14OrderedDsc )
         {
            sOrderString += " ORDER BY T1.[ProdCod]";
         }
         else if ( ( AV13OrderedBy == 1 ) && ( AV14OrderedDsc ) )
         {
            sOrderString += " ORDER BY T1.[ProdCod] DESC";
         }
         else if ( ( AV13OrderedBy == 2 ) && ! AV14OrderedDsc )
         {
            sOrderString += " ORDER BY T1.[ProdDsc]";
         }
         else if ( ( AV13OrderedBy == 2 ) && ( AV14OrderedDsc ) )
         {
            sOrderString += " ORDER BY T1.[ProdDsc] DESC";
         }
         else if ( ( AV13OrderedBy == 3 ) && ! AV14OrderedDsc )
         {
            sOrderString += " ORDER BY T2.[UniAbr]";
         }
         else if ( ( AV13OrderedBy == 3 ) && ( AV14OrderedDsc ) )
         {
            sOrderString += " ORDER BY T2.[UniAbr] DESC";
         }
         else if ( true )
         {
            sOrderString += " ORDER BY T1.[ProdCod]";
         }
         scmdbuf = "SELECT " + sSelectString + sFromString + sWhereString + sOrderString + "" + " OFFSET " + "@GXPagingFrom2" + " ROWS FETCH NEXT CAST((SELECT CASE WHEN " + "@GXPagingTo2" + " > 0 THEN " + "@GXPagingTo2" + " ELSE 1e9 END) AS INTEGER) ROWS ONLY";
         GXv_Object7[0] = scmdbuf;
         GXv_Object7[1] = GXv_int6;
         return GXv_Object7 ;
      }

      protected Object[] conditional_H002N3( IGxContext context ,
                                             string AV60FilterFullText ,
                                             string AV41TFProdCod_Sel ,
                                             string AV40TFProdCod ,
                                             string AV43TFProdDsc_Sel ,
                                             string AV42TFProdDsc ,
                                             string AV66TFUniAbr_Sel ,
                                             string AV65TFUniAbr ,
                                             string AV68TFProdReferencias_Sel ,
                                             string AV67TFProdReferencias ,
                                             string AV64InTipo ,
                                             string A28ProdCod ,
                                             string A55ProdDsc ,
                                             string A1997UniAbr ,
                                             string A1705ProdRef1 ,
                                             string A1707ProdRef2 ,
                                             string A1708ProdRef3 ,
                                             string A1709ProdRef4 ,
                                             string A1710ProdRef5 ,
                                             string A1711ProdRef6 ,
                                             string A1712ProdRef7 ,
                                             string A1713ProdRef8 ,
                                             string A1714ProdRef9 ,
                                             string A1706ProdRef10 ,
                                             short A1724ProdVta ,
                                             short A1679ProdCmp ,
                                             short AV13OrderedBy ,
                                             bool AV14OrderedDsc ,
                                             short A1718ProdSts )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int8 = new short[12];
         Object[] GXv_Object9 = new Object[2];
         scmdbuf = "SELECT COUNT(*) FROM ([APRODUCTOS] T1 INNER JOIN [CUNIDADMEDIDA] T2 ON T2.[UniCod] = T1.[UniCod])";
         AddWhere(sWhereString, "(T1.[ProdSts] = 1)");
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV60FilterFullText)) )
         {
            AddWhere(sWhereString, "(( T1.[ProdCod] like '%' + @lV60FilterFullText) or ( T1.[ProdDsc] like '%' + @lV60FilterFullText) or ( T2.[UniAbr] like '%' + @lV60FilterFullText) or ( RTRIM(LTRIM(T1.[ProdRef1])) + ' ' + RTRIM(LTRIM(T1.[ProdRef2])) + ' ' + RTRIM(LTRIM(T1.[ProdRef3])) + ' ' + RTRIM(LTRIM(T1.[ProdRef4])) + ' ' + RTRIM(LTRIM(T1.[ProdRef5])) + ' ' + RTRIM(LTRIM(T1.[ProdRef6])) + ' ' + RTRIM(LTRIM(T1.[ProdRef7])) + ' ' + RTRIM(LTRIM(T1.[ProdRef8])) + ' ' + RTRIM(LTRIM(T1.[ProdRef9])) + ' ' + RTRIM(LTRIM(T1.[ProdRef10])) like '%' + @lV60FilterFullText))");
         }
         else
         {
            GXv_int8[0] = 1;
            GXv_int8[1] = 1;
            GXv_int8[2] = 1;
            GXv_int8[3] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV41TFProdCod_Sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV40TFProdCod)) ) )
         {
            AddWhere(sWhereString, "(T1.[ProdCod] like @lV40TFProdCod)");
         }
         else
         {
            GXv_int8[4] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV41TFProdCod_Sel)) )
         {
            AddWhere(sWhereString, "(T1.[ProdCod] = @AV41TFProdCod_Sel)");
         }
         else
         {
            GXv_int8[5] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV43TFProdDsc_Sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV42TFProdDsc)) ) )
         {
            AddWhere(sWhereString, "(T1.[ProdDsc] like @lV42TFProdDsc)");
         }
         else
         {
            GXv_int8[6] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV43TFProdDsc_Sel)) )
         {
            AddWhere(sWhereString, "(T1.[ProdDsc] = @AV43TFProdDsc_Sel)");
         }
         else
         {
            GXv_int8[7] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV66TFUniAbr_Sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV65TFUniAbr)) ) )
         {
            AddWhere(sWhereString, "(T2.[UniAbr] like @lV65TFUniAbr)");
         }
         else
         {
            GXv_int8[8] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV66TFUniAbr_Sel)) )
         {
            AddWhere(sWhereString, "(T2.[UniAbr] = @AV66TFUniAbr_Sel)");
         }
         else
         {
            GXv_int8[9] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV68TFProdReferencias_Sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV67TFProdReferencias)) ) )
         {
            AddWhere(sWhereString, "(RTRIM(LTRIM(T1.[ProdRef1])) + ' ' + RTRIM(LTRIM(T1.[ProdRef2])) + ' ' + RTRIM(LTRIM(T1.[ProdRef3])) + ' ' + RTRIM(LTRIM(T1.[ProdRef4])) + ' ' + RTRIM(LTRIM(T1.[ProdRef5])) + ' ' + RTRIM(LTRIM(T1.[ProdRef6])) + ' ' + RTRIM(LTRIM(T1.[ProdRef7])) + ' ' + RTRIM(LTRIM(T1.[ProdRef8])) + ' ' + RTRIM(LTRIM(T1.[ProdRef9])) + ' ' + RTRIM(LTRIM(T1.[ProdRef10])) like @lV67TFProdReferencias)");
         }
         else
         {
            GXv_int8[10] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV68TFProdReferencias_Sel)) )
         {
            AddWhere(sWhereString, "(RTRIM(LTRIM(T1.[ProdRef1])) + ' ' + RTRIM(LTRIM(T1.[ProdRef2])) + ' ' + RTRIM(LTRIM(T1.[ProdRef3])) + ' ' + RTRIM(LTRIM(T1.[ProdRef4])) + ' ' + RTRIM(LTRIM(T1.[ProdRef5])) + ' ' + RTRIM(LTRIM(T1.[ProdRef6])) + ' ' + RTRIM(LTRIM(T1.[ProdRef7])) + ' ' + RTRIM(LTRIM(T1.[ProdRef8])) + ' ' + RTRIM(LTRIM(T1.[ProdRef9])) + ' ' + RTRIM(LTRIM(T1.[ProdRef10])) = @AV68TFProdReferencias_Sel)");
         }
         else
         {
            GXv_int8[11] = 1;
         }
         if ( StringUtil.StrCmp(AV64InTipo, "V") == 0 )
         {
            AddWhere(sWhereString, "(T1.[ProdVta] = 1)");
         }
         if ( StringUtil.StrCmp(AV64InTipo, "C") == 0 )
         {
            AddWhere(sWhereString, "(T1.[ProdCmp] = 1)");
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
                     return conditional_H002N2(context, (string)dynConstraints[0] , (string)dynConstraints[1] , (string)dynConstraints[2] , (string)dynConstraints[3] , (string)dynConstraints[4] , (string)dynConstraints[5] , (string)dynConstraints[6] , (string)dynConstraints[7] , (string)dynConstraints[8] , (string)dynConstraints[9] , (string)dynConstraints[10] , (string)dynConstraints[11] , (string)dynConstraints[12] , (string)dynConstraints[13] , (string)dynConstraints[14] , (string)dynConstraints[15] , (string)dynConstraints[16] , (string)dynConstraints[17] , (string)dynConstraints[18] , (string)dynConstraints[19] , (string)dynConstraints[20] , (string)dynConstraints[21] , (string)dynConstraints[22] , (short)dynConstraints[23] , (short)dynConstraints[24] , (short)dynConstraints[25] , (bool)dynConstraints[26] , (short)dynConstraints[27] );
               case 1 :
                     return conditional_H002N3(context, (string)dynConstraints[0] , (string)dynConstraints[1] , (string)dynConstraints[2] , (string)dynConstraints[3] , (string)dynConstraints[4] , (string)dynConstraints[5] , (string)dynConstraints[6] , (string)dynConstraints[7] , (string)dynConstraints[8] , (string)dynConstraints[9] , (string)dynConstraints[10] , (string)dynConstraints[11] , (string)dynConstraints[12] , (string)dynConstraints[13] , (string)dynConstraints[14] , (string)dynConstraints[15] , (string)dynConstraints[16] , (string)dynConstraints[17] , (string)dynConstraints[18] , (string)dynConstraints[19] , (string)dynConstraints[20] , (string)dynConstraints[21] , (string)dynConstraints[22] , (short)dynConstraints[23] , (short)dynConstraints[24] , (short)dynConstraints[25] , (bool)dynConstraints[26] , (short)dynConstraints[27] );
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
          Object[] prmH002N2;
          prmH002N2 = new Object[] {
          new ParDef("@lV60FilterFullText",GXType.NVarChar,100,0) ,
          new ParDef("@lV60FilterFullText",GXType.NVarChar,100,0) ,
          new ParDef("@lV60FilterFullText",GXType.NVarChar,100,0) ,
          new ParDef("@lV60FilterFullText",GXType.VarChar,100,0) ,
          new ParDef("@lV40TFProdCod",GXType.NChar,15,0) ,
          new ParDef("@AV41TFProdCod_Sel",GXType.NChar,15,0) ,
          new ParDef("@lV42TFProdDsc",GXType.NChar,100,0) ,
          new ParDef("@AV43TFProdDsc_Sel",GXType.NChar,100,0) ,
          new ParDef("@lV65TFUniAbr",GXType.NChar,5,0) ,
          new ParDef("@AV66TFUniAbr_Sel",GXType.NChar,5,0) ,
          new ParDef("@lV67TFProdReferencias",GXType.VarChar,200,0) ,
          new ParDef("@AV68TFProdReferencias_Sel",GXType.VarChar,200,0) ,
          new ParDef("@GXPagingFrom2",GXType.Int32,9,0) ,
          new ParDef("@GXPagingTo2",GXType.Int32,9,0) ,
          new ParDef("@GXPagingTo2",GXType.Int32,9,0)
          };
          Object[] prmH002N3;
          prmH002N3 = new Object[] {
          new ParDef("@lV60FilterFullText",GXType.NVarChar,100,0) ,
          new ParDef("@lV60FilterFullText",GXType.NVarChar,100,0) ,
          new ParDef("@lV60FilterFullText",GXType.NVarChar,100,0) ,
          new ParDef("@lV60FilterFullText",GXType.VarChar,100,0) ,
          new ParDef("@lV40TFProdCod",GXType.NChar,15,0) ,
          new ParDef("@AV41TFProdCod_Sel",GXType.NChar,15,0) ,
          new ParDef("@lV42TFProdDsc",GXType.NChar,100,0) ,
          new ParDef("@AV43TFProdDsc_Sel",GXType.NChar,100,0) ,
          new ParDef("@lV65TFUniAbr",GXType.NChar,5,0) ,
          new ParDef("@AV66TFUniAbr_Sel",GXType.NChar,5,0) ,
          new ParDef("@lV67TFProdReferencias",GXType.VarChar,200,0) ,
          new ParDef("@AV68TFProdReferencias_Sel",GXType.VarChar,200,0)
          };
          def= new CursorDef[] {
              new CursorDef("H002N2", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH002N2,11, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("H002N3", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH002N3,1, GxCacheFrequency.OFF ,true,false )
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
                ((int[]) buf[3])[0] = rslt.getInt(4);
                ((string[]) buf[4])[0] = rslt.getString(5, 5);
                ((string[]) buf[5])[0] = rslt.getString(6, 100);
                ((string[]) buf[6])[0] = rslt.getString(7, 15);
                ((string[]) buf[7])[0] = rslt.getString(8, 20);
                ((string[]) buf[8])[0] = rslt.getString(9, 20);
                ((string[]) buf[9])[0] = rslt.getString(10, 20);
                ((string[]) buf[10])[0] = rslt.getString(11, 20);
                ((string[]) buf[11])[0] = rslt.getString(12, 20);
                ((string[]) buf[12])[0] = rslt.getString(13, 20);
                ((string[]) buf[13])[0] = rslt.getString(14, 20);
                ((string[]) buf[14])[0] = rslt.getString(15, 20);
                ((string[]) buf[15])[0] = rslt.getString(16, 20);
                ((string[]) buf[16])[0] = rslt.getString(17, 20);
                return;
             case 1 :
                ((long[]) buf[0])[0] = rslt.getLong(1);
                return;
       }
    }

 }

}
